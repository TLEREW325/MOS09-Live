<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VendorInformation
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
        Dim tabVendorDetails As System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txt1099Name = New System.Windows.Forms.TextBox
        Me.lblName1099 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.chkVendor1099 = New System.Windows.Forms.CheckBox
        Me.gpxVendorPurchaseDetails = New System.Windows.Forms.GroupBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.txtTotalYTD = New System.Windows.Forms.TextBox
        Me.txtTotalMTD = New System.Windows.Forms.TextBox
        Me.txtYTDSteel = New System.Windows.Forms.TextBox
        Me.txtMTDSteel = New System.Windows.Forms.TextBox
        Me.txtYTDVouchers = New System.Windows.Forms.TextBox
        Me.txtMTDVouchers = New System.Windows.Forms.TextBox
        Me.txtLastActivityDate = New System.Windows.Forms.TextBox
        Me.txtYTDPurchases = New System.Windows.Forms.TextBox
        Me.txtCurrentBalance = New System.Windows.Forms.TextBox
        Me.txtMTDPurchases = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.gpxVendorReports = New System.Windows.Forms.GroupBox
        Me.cmdPurchaseActivityReport = New System.Windows.Forms.Button
        Me.cmdPaymentActivityReport = New System.Windows.Forms.Button
        Me.cmdPurchaseAnalysisReport = New System.Windows.Forms.Button
        Me.cmdVendorListingReport = New System.Windows.Forms.Button
        Me.cmdVendorReturns = New System.Windows.Forms.Button
        Me.cmdAgedPayablesReport = New System.Windows.Forms.Button
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveVendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintVendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteVendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReuploadW9ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintVendorListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintVendorPurchaseHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintVendorPaymentHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintAPAgingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPurchaseActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPurchaseAnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPaymentActivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxVendorInfo = New System.Windows.Forms.GroupBox
        Me.cboPreferredShipper = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.txtVendorTaxID = New System.Windows.Forms.TextBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCreditLimit = New System.Windows.Forms.TextBox
        Me.txtVendorComment = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblTaxIDLabel = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.dtpVendorDate = New System.Windows.Forms.DateTimePicker
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVendorAccount = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.chkWhitePaperCheck = New System.Windows.Forms.CheckBox
        Me.gpxVendorAddress = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.cboState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtZipCode = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.gpxVendorContact = New System.Windows.Forms.GroupBox
        Me.txtVendorEmail = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtFAXNumber = New System.Windows.Forms.TextBox
        Me.txtContactName = New System.Windows.Forms.TextBox
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtRemittanceEmail = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.cboAccountDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboDefaultItem = New System.Windows.Forms.ComboBox
        Me.NonInventoryItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDefaultGLAccount = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdOpenVendorReturns = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdOpenViewPurchasesForm = New System.Windows.Forms.Button
        Me.cmdOpenPOForm = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtItemDescription = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkProp65 = New System.Windows.Forms.CheckBox
        Me.chkIsoCompliant = New System.Windows.Forms.CheckBox
        Me.dtpApprovalDate = New System.Windows.Forms.DateTimePicker
        Me.cboApprovalCriteria = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtApprovedBy = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.NonInventoryItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdoOtherACH = New System.Windows.Forms.RadioButton
        Me.rdoFedexCheck = New System.Windows.Forms.RadioButton
        Me.rdoCheckCodeIntercompany = New System.Windows.Forms.RadioButton
        Me.rdoCheckCodeStandard = New System.Windows.Forms.RadioButton
        Me.tabVendorControl = New System.Windows.Forms.TabControl
        Me.tabCheckData = New System.Windows.Forms.TabPage
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtACHContactEmail = New System.Windows.Forms.TextBox
        Me.txtACHVerifyDate = New System.Windows.Forms.TextBox
        Me.txtACHContactPhone = New System.Windows.Forms.TextBox
        Me.txtACHContactName = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rdoSavings = New System.Windows.Forms.RadioButton
        Me.rdoChecking = New System.Windows.Forms.RadioButton
        Me.txtRoutingNumber = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.cmdUploadOpenW9 = New System.Windows.Forms.Button
        Me.cmdScanW9 = New System.Windows.Forms.Button
        tabVendorDetails = New System.Windows.Forms.TabPage
        tabVendorDetails.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gpxVendorPurchaseDetails.SuspendLayout()
        Me.gpxVendorReports.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxVendorInfo.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVendorAddress.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVendorContact.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tabVendorControl.SuspendLayout()
        Me.tabCheckData.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabVendorDetails
        '
        tabVendorDetails.Controls.Add(Me.GroupBox5)
        tabVendorDetails.Controls.Add(Me.gpxVendorPurchaseDetails)
        tabVendorDetails.Controls.Add(Me.gpxVendorReports)
        tabVendorDetails.Location = New System.Drawing.Point(4, 22)
        tabVendorDetails.Name = "tabVendorDetails"
        tabVendorDetails.Padding = New System.Windows.Forms.Padding(3)
        tabVendorDetails.Size = New System.Drawing.Size(394, 644)
        tabVendorDetails.TabIndex = 0
        tabVendorDetails.Text = "Vendor Details"
        tabVendorDetails.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txt1099Name)
        Me.GroupBox5.Controls.Add(Me.lblName1099)
        Me.GroupBox5.Controls.Add(Me.Label46)
        Me.GroupBox5.Controls.Add(Me.chkVendor1099)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 495)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(362, 143)
        Me.GroupBox5.TabIndex = 41
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Vendor 1099 Details"
        '
        'txt1099Name
        '
        Me.txt1099Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt1099Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt1099Name.Location = New System.Drawing.Point(79, 85)
        Me.txt1099Name.MaxLength = 100
        Me.txt1099Name.Multiline = True
        Me.txt1099Name.Name = "txt1099Name"
        Me.txt1099Name.Size = New System.Drawing.Size(268, 52)
        Me.txt1099Name.TabIndex = 42
        Me.txt1099Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblName1099
        '
        Me.lblName1099.Location = New System.Drawing.Point(6, 85)
        Me.lblName1099.Name = "lblName1099"
        Me.lblName1099.Size = New System.Drawing.Size(90, 20)
        Me.lblName1099.TabIndex = 41
        Me.lblName1099.Text = "1099 Name:"
        Me.lblName1099.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label46.ForeColor = System.Drawing.Color.Blue
        Me.Label46.Location = New System.Drawing.Point(78, 45)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(221, 37)
        Me.Label46.TabIndex = 40
        Me.Label46.Text = "Check box for yes - this can be adjusted after the voucher is paid."
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkVendor1099
        '
        Me.chkVendor1099.AutoSize = True
        Me.chkVendor1099.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVendor1099.Location = New System.Drawing.Point(79, 28)
        Me.chkVendor1099.Name = "chkVendor1099"
        Me.chkVendor1099.Size = New System.Drawing.Size(240, 17)
        Me.chkVendor1099.TabIndex = 0
        Me.chkVendor1099.Text = "Do we send the Vendor a 1099 Form?"
        Me.chkVendor1099.UseVisualStyleBackColor = True
        '
        'gpxVendorPurchaseDetails
        '
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label43)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtTotalYTD)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtTotalMTD)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtYTDSteel)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtMTDSteel)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtYTDVouchers)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtMTDVouchers)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtLastActivityDate)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtYTDPurchases)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtCurrentBalance)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.txtMTDPurchases)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label41)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label42)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label39)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label40)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label37)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label38)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label26)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label27)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label28)
        Me.gpxVendorPurchaseDetails.Controls.Add(Me.Label10)
        Me.gpxVendorPurchaseDetails.Location = New System.Drawing.Point(51, 9)
        Me.gpxVendorPurchaseDetails.Name = "gpxVendorPurchaseDetails"
        Me.gpxVendorPurchaseDetails.Size = New System.Drawing.Size(302, 355)
        Me.gpxVendorPurchaseDetails.TabIndex = 39
        Me.gpxVendorPurchaseDetails.TabStop = False
        Me.gpxVendorPurchaseDetails.Text = "Vendor Purchase Details"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Black
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Location = New System.Drawing.Point(9, 135)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(279, 2)
        Me.Label43.TabIndex = 24
        '
        'txtTotalYTD
        '
        Me.txtTotalYTD.BackColor = System.Drawing.Color.White
        Me.txtTotalYTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalYTD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalYTD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalYTD.Location = New System.Drawing.Point(151, 189)
        Me.txtTotalYTD.Name = "txtTotalYTD"
        Me.txtTotalYTD.ReadOnly = True
        Me.txtTotalYTD.Size = New System.Drawing.Size(137, 20)
        Me.txtTotalYTD.TabIndex = 40
        Me.txtTotalYTD.TabStop = False
        Me.txtTotalYTD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalMTD
        '
        Me.txtTotalMTD.BackColor = System.Drawing.Color.White
        Me.txtTotalMTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalMTD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalMTD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMTD.Location = New System.Drawing.Point(151, 156)
        Me.txtTotalMTD.Name = "txtTotalMTD"
        Me.txtTotalMTD.ReadOnly = True
        Me.txtTotalMTD.Size = New System.Drawing.Size(137, 20)
        Me.txtTotalMTD.TabIndex = 39
        Me.txtTotalMTD.TabStop = False
        Me.txtTotalMTD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYTDSteel
        '
        Me.txtYTDSteel.BackColor = System.Drawing.Color.White
        Me.txtYTDSteel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDSteel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDSteel.Location = New System.Drawing.Point(148, 98)
        Me.txtYTDSteel.Name = "txtYTDSteel"
        Me.txtYTDSteel.ReadOnly = True
        Me.txtYTDSteel.Size = New System.Drawing.Size(137, 20)
        Me.txtYTDSteel.TabIndex = 36
        Me.txtYTDSteel.TabStop = False
        Me.txtYTDSteel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDSteel
        '
        Me.txtMTDSteel.BackColor = System.Drawing.Color.White
        Me.txtMTDSteel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDSteel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDSteel.Location = New System.Drawing.Point(148, 72)
        Me.txtMTDSteel.Name = "txtMTDSteel"
        Me.txtMTDSteel.ReadOnly = True
        Me.txtMTDSteel.Size = New System.Drawing.Size(137, 20)
        Me.txtMTDSteel.TabIndex = 35
        Me.txtMTDSteel.TabStop = False
        Me.txtMTDSteel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYTDVouchers
        '
        Me.txtYTDVouchers.BackColor = System.Drawing.Color.White
        Me.txtYTDVouchers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDVouchers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDVouchers.Location = New System.Drawing.Point(151, 255)
        Me.txtYTDVouchers.Name = "txtYTDVouchers"
        Me.txtYTDVouchers.ReadOnly = True
        Me.txtYTDVouchers.Size = New System.Drawing.Size(137, 20)
        Me.txtYTDVouchers.TabIndex = 33
        Me.txtYTDVouchers.TabStop = False
        Me.txtYTDVouchers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDVouchers
        '
        Me.txtMTDVouchers.BackColor = System.Drawing.Color.White
        Me.txtMTDVouchers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDVouchers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDVouchers.Location = New System.Drawing.Point(151, 222)
        Me.txtMTDVouchers.Name = "txtMTDVouchers"
        Me.txtMTDVouchers.ReadOnly = True
        Me.txtMTDVouchers.Size = New System.Drawing.Size(137, 20)
        Me.txtMTDVouchers.TabIndex = 32
        Me.txtMTDVouchers.TabStop = False
        Me.txtMTDVouchers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLastActivityDate
        '
        Me.txtLastActivityDate.BackColor = System.Drawing.Color.White
        Me.txtLastActivityDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastActivityDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastActivityDate.Location = New System.Drawing.Point(151, 288)
        Me.txtLastActivityDate.Name = "txtLastActivityDate"
        Me.txtLastActivityDate.ReadOnly = True
        Me.txtLastActivityDate.Size = New System.Drawing.Size(137, 20)
        Me.txtLastActivityDate.TabIndex = 27
        Me.txtLastActivityDate.TabStop = False
        Me.txtLastActivityDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYTDPurchases
        '
        Me.txtYTDPurchases.BackColor = System.Drawing.Color.White
        Me.txtYTDPurchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTDPurchases.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYTDPurchases.Location = New System.Drawing.Point(148, 46)
        Me.txtYTDPurchases.Name = "txtYTDPurchases"
        Me.txtYTDPurchases.ReadOnly = True
        Me.txtYTDPurchases.Size = New System.Drawing.Size(137, 20)
        Me.txtYTDPurchases.TabIndex = 26
        Me.txtYTDPurchases.TabStop = False
        Me.txtYTDPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrentBalance
        '
        Me.txtCurrentBalance.BackColor = System.Drawing.Color.White
        Me.txtCurrentBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentBalance.Location = New System.Drawing.Point(151, 321)
        Me.txtCurrentBalance.Name = "txtCurrentBalance"
        Me.txtCurrentBalance.ReadOnly = True
        Me.txtCurrentBalance.Size = New System.Drawing.Size(137, 20)
        Me.txtCurrentBalance.TabIndex = 24
        Me.txtCurrentBalance.TabStop = False
        Me.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMTDPurchases
        '
        Me.txtMTDPurchases.BackColor = System.Drawing.Color.White
        Me.txtMTDPurchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMTDPurchases.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTDPurchases.Location = New System.Drawing.Point(148, 20)
        Me.txtMTDPurchases.Name = "txtMTDPurchases"
        Me.txtMTDPurchases.ReadOnly = True
        Me.txtMTDPurchases.Size = New System.Drawing.Size(137, 20)
        Me.txtMTDPurchases.TabIndex = 25
        Me.txtMTDPurchases.TabStop = False
        Me.txtMTDPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(9, 189)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(158, 20)
        Me.Label41.TabIndex = 42
        Me.Label41.Text = "YTD Total Purchases"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(9, 156)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(158, 20)
        Me.Label42.TabIndex = 41
        Me.Label42.Text = "MTD Total Purchases"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(6, 96)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(137, 20)
        Me.Label39.TabIndex = 38
        Me.Label39.Text = "YTD Steel Purchases (FY)"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(6, 71)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(137, 20)
        Me.Label40.TabIndex = 37
        Me.Label40.Text = "MTD Steel Purchases"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(9, 222)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(158, 20)
        Me.Label37.TabIndex = 34
        Me.Label37.Text = "MTD Vouchers"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(9, 255)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(158, 20)
        Me.Label38.TabIndex = 31
        Me.Label38.Text = "YTD Vouchers (FY)"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(6, 46)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(137, 20)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "YTD Purchases (FY)"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(9, 321)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(158, 20)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Current Balance"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(6, 21)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(137, 20)
        Me.Label28.TabIndex = 28
        Me.Label28.Text = "MTD Purchases"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(9, 288)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(158, 20)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Last Activity Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxVendorReports
        '
        Me.gpxVendorReports.Controls.Add(Me.cmdPurchaseActivityReport)
        Me.gpxVendorReports.Controls.Add(Me.cmdPaymentActivityReport)
        Me.gpxVendorReports.Controls.Add(Me.cmdPurchaseAnalysisReport)
        Me.gpxVendorReports.Controls.Add(Me.cmdVendorListingReport)
        Me.gpxVendorReports.Controls.Add(Me.cmdVendorReturns)
        Me.gpxVendorReports.Controls.Add(Me.cmdAgedPayablesReport)
        Me.gpxVendorReports.Controls.Add(Me.Label33)
        Me.gpxVendorReports.Controls.Add(Me.Label12)
        Me.gpxVendorReports.Controls.Add(Me.Label9)
        Me.gpxVendorReports.Controls.Add(Me.Label8)
        Me.gpxVendorReports.Controls.Add(Me.Label11)
        Me.gpxVendorReports.Controls.Add(Me.Label4)
        Me.gpxVendorReports.Location = New System.Drawing.Point(51, 370)
        Me.gpxVendorReports.Name = "gpxVendorReports"
        Me.gpxVendorReports.Size = New System.Drawing.Size(302, 119)
        Me.gpxVendorReports.TabIndex = 40
        Me.gpxVendorReports.TabStop = False
        Me.gpxVendorReports.Text = "Vendor Reports"
        '
        'cmdPurchaseActivityReport
        '
        Me.cmdPurchaseActivityReport.Location = New System.Drawing.Point(162, 56)
        Me.cmdPurchaseActivityReport.Name = "cmdPurchaseActivityReport"
        Me.cmdPurchaseActivityReport.Size = New System.Drawing.Size(20, 20)
        Me.cmdPurchaseActivityReport.TabIndex = 35
        Me.cmdPurchaseActivityReport.TabStop = False
        Me.cmdPurchaseActivityReport.UseVisualStyleBackColor = True
        '
        'cmdPaymentActivityReport
        '
        Me.cmdPaymentActivityReport.Location = New System.Drawing.Point(162, 86)
        Me.cmdPaymentActivityReport.Name = "cmdPaymentActivityReport"
        Me.cmdPaymentActivityReport.Size = New System.Drawing.Size(20, 20)
        Me.cmdPaymentActivityReport.TabIndex = 36
        Me.cmdPaymentActivityReport.TabStop = False
        Me.cmdPaymentActivityReport.UseVisualStyleBackColor = True
        '
        'cmdPurchaseAnalysisReport
        '
        Me.cmdPurchaseAnalysisReport.Location = New System.Drawing.Point(14, 26)
        Me.cmdPurchaseAnalysisReport.Name = "cmdPurchaseAnalysisReport"
        Me.cmdPurchaseAnalysisReport.Size = New System.Drawing.Size(20, 20)
        Me.cmdPurchaseAnalysisReport.TabIndex = 37
        Me.cmdPurchaseAnalysisReport.TabStop = False
        Me.cmdPurchaseAnalysisReport.UseVisualStyleBackColor = True
        '
        'cmdVendorListingReport
        '
        Me.cmdVendorListingReport.Location = New System.Drawing.Point(14, 58)
        Me.cmdVendorListingReport.Name = "cmdVendorListingReport"
        Me.cmdVendorListingReport.Size = New System.Drawing.Size(20, 20)
        Me.cmdVendorListingReport.TabIndex = 38
        Me.cmdVendorListingReport.TabStop = False
        Me.cmdVendorListingReport.UseVisualStyleBackColor = True
        '
        'cmdVendorReturns
        '
        Me.cmdVendorReturns.Location = New System.Drawing.Point(14, 86)
        Me.cmdVendorReturns.Name = "cmdVendorReturns"
        Me.cmdVendorReturns.Size = New System.Drawing.Size(20, 20)
        Me.cmdVendorReturns.TabIndex = 39
        Me.cmdVendorReturns.TabStop = False
        Me.cmdVendorReturns.UseVisualStyleBackColor = True
        '
        'cmdAgedPayablesReport
        '
        Me.cmdAgedPayablesReport.Location = New System.Drawing.Point(162, 26)
        Me.cmdAgedPayablesReport.Name = "cmdAgedPayablesReport"
        Me.cmdAgedPayablesReport.Size = New System.Drawing.Size(20, 20)
        Me.cmdAgedPayablesReport.TabIndex = 34
        Me.cmdAgedPayablesReport.TabStop = False
        Me.cmdAgedPayablesReport.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(40, 86)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(94, 20)
        Me.Label33.TabIndex = 14
        Me.Label33.Text = "Vendor Returns"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(194, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 20)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Aged Payables"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(40, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Puchase Analysis"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(40, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Vendor Listing"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(194, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Purchase Activity"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(194, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Payment Activity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveVendorToolStripMenuItem, Me.PrintVendorToolStripMenuItem, Me.DeleteVendorToolStripMenuItem, Me.ClearDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveVendorToolStripMenuItem
        '
        Me.SaveVendorToolStripMenuItem.Name = "SaveVendorToolStripMenuItem"
        Me.SaveVendorToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SaveVendorToolStripMenuItem.Text = "Save Vendor"
        '
        'PrintVendorToolStripMenuItem
        '
        Me.PrintVendorToolStripMenuItem.Name = "PrintVendorToolStripMenuItem"
        Me.PrintVendorToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PrintVendorToolStripMenuItem.Text = "Print Vendor"
        '
        'DeleteVendorToolStripMenuItem
        '
        Me.DeleteVendorToolStripMenuItem.Name = "DeleteVendorToolStripMenuItem"
        Me.DeleteVendorToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DeleteVendorToolStripMenuItem.Text = "Delete Vendor"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReuploadW9ToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReuploadW9ToolStripMenuItem
        '
        Me.ReuploadW9ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem, Me.UploadToolStripMenuItem})
        Me.ReuploadW9ToolStripMenuItem.Name = "ReuploadW9ToolStripMenuItem"
        Me.ReuploadW9ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ReuploadW9ToolStripMenuItem.Text = "Reupload W-9"
        '
        'ScanToolStripMenuItem
        '
        Me.ScanToolStripMenuItem.Name = "ScanToolStripMenuItem"
        Me.ScanToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem.Text = "Scan"
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.UploadToolStripMenuItem.Text = "Upload"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintVendorListingToolStripMenuItem, Me.PrintVendorPurchaseHistoryToolStripMenuItem, Me.PrintVendorPaymentHistoryToolStripMenuItem, Me.PrintAPAgingToolStripMenuItem, Me.PrintPurchaseActivityToolStripMenuItem, Me.PrintPurchaseAnalysisToolStripMenuItem, Me.PrintPaymentActivityReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintVendorListingToolStripMenuItem
        '
        Me.PrintVendorListingToolStripMenuItem.Name = "PrintVendorListingToolStripMenuItem"
        Me.PrintVendorListingToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintVendorListingToolStripMenuItem.Text = "Print Vendor Listing"
        '
        'PrintVendorPurchaseHistoryToolStripMenuItem
        '
        Me.PrintVendorPurchaseHistoryToolStripMenuItem.Name = "PrintVendorPurchaseHistoryToolStripMenuItem"
        Me.PrintVendorPurchaseHistoryToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintVendorPurchaseHistoryToolStripMenuItem.Text = "Print Vendor Purchase History"
        '
        'PrintVendorPaymentHistoryToolStripMenuItem
        '
        Me.PrintVendorPaymentHistoryToolStripMenuItem.Name = "PrintVendorPaymentHistoryToolStripMenuItem"
        Me.PrintVendorPaymentHistoryToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintVendorPaymentHistoryToolStripMenuItem.Text = "Print Vendor Payment History"
        '
        'PrintAPAgingToolStripMenuItem
        '
        Me.PrintAPAgingToolStripMenuItem.Name = "PrintAPAgingToolStripMenuItem"
        Me.PrintAPAgingToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintAPAgingToolStripMenuItem.Text = "Print AP Aging"
        '
        'PrintPurchaseActivityToolStripMenuItem
        '
        Me.PrintPurchaseActivityToolStripMenuItem.Name = "PrintPurchaseActivityToolStripMenuItem"
        Me.PrintPurchaseActivityToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintPurchaseActivityToolStripMenuItem.Text = "Print Purchase Activity"
        '
        'PrintPurchaseAnalysisToolStripMenuItem
        '
        Me.PrintPurchaseAnalysisToolStripMenuItem.Name = "PrintPurchaseAnalysisToolStripMenuItem"
        Me.PrintPurchaseAnalysisToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintPurchaseAnalysisToolStripMenuItem.Text = "Print Purchase Analysis"
        '
        'PrintPaymentActivityReportToolStripMenuItem
        '
        Me.PrintPaymentActivityReportToolStripMenuItem.Name = "PrintPaymentActivityReportToolStripMenuItem"
        Me.PrintPaymentActivityReportToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintPaymentActivityReportToolStripMenuItem.Text = "Print Payment Activity Report"
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
        'gpxVendorInfo
        '
        Me.gpxVendorInfo.Controls.Add(Me.cboPreferredShipper)
        Me.gpxVendorInfo.Controls.Add(Me.txtVendorName)
        Me.gpxVendorInfo.Controls.Add(Me.txtVendorTaxID)
        Me.gpxVendorInfo.Controls.Add(Me.cboPaymentTerms)
        Me.gpxVendorInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxVendorInfo.Controls.Add(Me.txtCreditLimit)
        Me.gpxVendorInfo.Controls.Add(Me.txtVendorComment)
        Me.gpxVendorInfo.Controls.Add(Me.Label25)
        Me.gpxVendorInfo.Controls.Add(Me.cboVendorClass)
        Me.gpxVendorInfo.Controls.Add(Me.lblTaxIDLabel)
        Me.gpxVendorInfo.Controls.Add(Me.Label6)
        Me.gpxVendorInfo.Controls.Add(Me.Label24)
        Me.gpxVendorInfo.Controls.Add(Me.dtpVendorDate)
        Me.gpxVendorInfo.Controls.Add(Me.Label30)
        Me.gpxVendorInfo.Controls.Add(Me.Label19)
        Me.gpxVendorInfo.Controls.Add(Me.Label7)
        Me.gpxVendorInfo.Controls.Add(Me.Label3)
        Me.gpxVendorInfo.Controls.Add(Me.cboVendorID)
        Me.gpxVendorInfo.Controls.Add(Me.Label2)
        Me.gpxVendorInfo.Controls.Add(Me.Label1)
        Me.gpxVendorInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxVendorInfo.Name = "gpxVendorInfo"
        Me.gpxVendorInfo.Size = New System.Drawing.Size(357, 547)
        Me.gpxVendorInfo.TabIndex = 0
        Me.gpxVendorInfo.TabStop = False
        Me.gpxVendorInfo.Text = "Vendor Information"
        '
        'cboPreferredShipper
        '
        Me.cboPreferredShipper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPreferredShipper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPreferredShipper.DataSource = Me.ShipMethodBindingSource
        Me.cboPreferredShipper.DisplayMember = "ShipMethID"
        Me.cboPreferredShipper.FormattingEnabled = True
        Me.cboPreferredShipper.Location = New System.Drawing.Point(134, 475)
        Me.cboPreferredShipper.Name = "cboPreferredShipper"
        Me.cboPreferredShipper.Size = New System.Drawing.Size(208, 21)
        Me.cboPreferredShipper.TabIndex = 9
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(21, 81)
        Me.txtVendorName.MaxLength = 100
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(322, 85)
        Me.txtVendorName.TabIndex = 1
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorTaxID
        '
        Me.txtVendorTaxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorTaxID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorTaxID.Location = New System.Drawing.Point(134, 402)
        Me.txtVendorTaxID.Name = "txtVendorTaxID"
        Me.txtVendorTaxID.Size = New System.Drawing.Size(208, 20)
        Me.txtVendorTaxID.TabIndex = 7
        Me.txtVendorTaxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTerms.DisplayMember = "PmtTermsID"
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(134, 438)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(208, 21)
        Me.cboPaymentTerms.TabIndex = 8
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(160, 180)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditLimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditLimit.Location = New System.Drawing.Point(134, 512)
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.Size = New System.Drawing.Size(208, 20)
        Me.txtCreditLimit.TabIndex = 10
        Me.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorComment
        '
        Me.txtVendorComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorComment.Location = New System.Drawing.Point(20, 293)
        Me.txtVendorComment.MaxLength = 200
        Me.txtVendorComment.Multiline = True
        Me.txtVendorComment.Name = "txtVendorComment"
        Me.txtVendorComment.Size = New System.Drawing.Size(322, 93)
        Me.txtVendorComment.TabIndex = 5
        Me.txtVendorComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(17, 476)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(107, 20)
        Me.Label25.TabIndex = 30
        Me.Label25.Text = "Preferred Shipper"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(160, 241)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(182, 21)
        Me.cboVendorClass.TabIndex = 4
        '
        'VendorClassBindingSource
        '
        Me.VendorClassBindingSource.DataMember = "VendorClass"
        Me.VendorClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblTaxIDLabel
        '
        Me.lblTaxIDLabel.Location = New System.Drawing.Point(17, 403)
        Me.lblTaxIDLabel.Name = "lblTaxIDLabel"
        Me.lblTaxIDLabel.Size = New System.Drawing.Size(107, 20)
        Me.lblTaxIDLabel.TabIndex = 7
        Me.lblTaxIDLabel.Text = "Vendor Tax ID"
        Me.lblTaxIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(269, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Comment (200 Characters MAX)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(17, 439)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(107, 20)
        Me.Label24.TabIndex = 28
        Me.Label24.Text = "Payment Terms"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpVendorDate
        '
        Me.dtpVendorDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpVendorDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVendorDate.Location = New System.Drawing.Point(160, 211)
        Me.dtpVendorDate.Name = "dtpVendorDate"
        Me.dtpVendorDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpVendorDate.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(17, 512)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(107, 20)
        Me.Label30.TabIndex = 32
        Me.Label30.Text = "Credit Limit"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(17, 211)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(149, 20)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "Creation Date"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Vendor Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(96, 29)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(247, 21)
        Me.cboVendorID.TabIndex = 0
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(326, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Vendor Name (100 characters MAX - will appear on Check)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Vendor ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorAccount
        '
        Me.txtVendorAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorAccount.Location = New System.Drawing.Point(18, 203)
        Me.txtVendorAccount.Name = "txtVendorAccount"
        Me.txtVendorAccount.Size = New System.Drawing.Size(352, 20)
        Me.txtVendorAccount.TabIndex = 41
        Me.txtVendorAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(18, 180)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(217, 20)
        Me.Label45.TabIndex = 34
        Me.Label45.Text = "Vendor Bank Account #"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkWhitePaperCheck
        '
        Me.chkWhitePaperCheck.AutoSize = True
        Me.chkWhitePaperCheck.Location = New System.Drawing.Point(15, 25)
        Me.chkWhitePaperCheck.Name = "chkWhitePaperCheck"
        Me.chkWhitePaperCheck.Size = New System.Drawing.Size(199, 17)
        Me.chkWhitePaperCheck.TabIndex = 36
        Me.chkWhitePaperCheck.Text = "White Paper Check? (Standard only)"
        Me.chkWhitePaperCheck.UseVisualStyleBackColor = True
        '
        'gpxVendorAddress
        '
        Me.gpxVendorAddress.Controls.Add(Me.Label18)
        Me.gpxVendorAddress.Controls.Add(Me.txtCountry)
        Me.gpxVendorAddress.Controls.Add(Me.cboState)
        Me.gpxVendorAddress.Controls.Add(Me.txtAddress1)
        Me.gpxVendorAddress.Controls.Add(Me.txtAddress2)
        Me.gpxVendorAddress.Controls.Add(Me.txtZipCode)
        Me.gpxVendorAddress.Controls.Add(Me.txtCity)
        Me.gpxVendorAddress.Controls.Add(Me.Label13)
        Me.gpxVendorAddress.Controls.Add(Me.Label17)
        Me.gpxVendorAddress.Controls.Add(Me.Label16)
        Me.gpxVendorAddress.Controls.Add(Me.Label15)
        Me.gpxVendorAddress.Controls.Add(Me.Label14)
        Me.gpxVendorAddress.Location = New System.Drawing.Point(29, 594)
        Me.gpxVendorAddress.Name = "gpxVendorAddress"
        Me.gpxVendorAddress.Size = New System.Drawing.Size(357, 214)
        Me.gpxVendorAddress.TabIndex = 11
        Me.gpxVendorAddress.TabStop = False
        Me.gpxVendorAddress.Text = "Vendor Remit To Address"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(212, 153)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 20)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Zip"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCountry
        '
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.Location = New System.Drawing.Point(96, 181)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(247, 20)
        Me.txtCountry.TabIndex = 17
        Me.txtCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboState
        '
        Me.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboState.DataSource = Me.StateTableBindingSource
        Me.cboState.DisplayMember = "StateCode"
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(96, 153)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(110, 21)
        Me.cboState.TabIndex = 15
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress1.Location = New System.Drawing.Point(96, 26)
        Me.txtAddress1.MaxLength = 100
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(247, 62)
        Me.txtAddress1.TabIndex = 12
        Me.txtAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddress2
        '
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress2.Location = New System.Drawing.Point(96, 97)
        Me.txtAddress2.MaxLength = 100
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(247, 20)
        Me.txtAddress2.TabIndex = 13
        Me.txtAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtZipCode
        '
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZipCode.Location = New System.Drawing.Point(250, 153)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(93, 20)
        Me.txtZipCode.TabIndex = 16
        Me.txtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(96, 125)
        Me.txtCity.MaxLength = 100
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(247, 20)
        Me.txtCity.TabIndex = 14
        Me.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 20)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Country"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 20)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Address 1"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(17, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 20)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Address 2"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(17, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 20)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "City"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(17, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 20)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "State"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxVendorContact
        '
        Me.gpxVendorContact.Controls.Add(Me.txtVendorEmail)
        Me.gpxVendorContact.Controls.Add(Me.Label23)
        Me.gpxVendorContact.Controls.Add(Me.txtFAXNumber)
        Me.gpxVendorContact.Controls.Add(Me.txtContactName)
        Me.gpxVendorContact.Controls.Add(Me.txtPhoneNumber)
        Me.gpxVendorContact.Controls.Add(Me.Label20)
        Me.gpxVendorContact.Controls.Add(Me.Label21)
        Me.gpxVendorContact.Controls.Add(Me.Label22)
        Me.gpxVendorContact.Location = New System.Drawing.Point(392, 41)
        Me.gpxVendorContact.Name = "gpxVendorContact"
        Me.gpxVendorContact.Size = New System.Drawing.Size(313, 354)
        Me.gpxVendorContact.TabIndex = 18
        Me.gpxVendorContact.TabStop = False
        Me.gpxVendorContact.Text = "Vendor Contact Info"
        '
        'txtVendorEmail
        '
        Me.txtVendorEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorEmail.CausesValidation = False
        Me.txtVendorEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorEmail.Location = New System.Drawing.Point(17, 241)
        Me.txtVendorEmail.MaxLength = 200
        Me.txtVendorEmail.Multiline = True
        Me.txtVendorEmail.Name = "txtVendorEmail"
        Me.txtVendorEmail.Size = New System.Drawing.Size(280, 96)
        Me.txtVendorEmail.TabIndex = 22
        Me.txtVendorEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(17, 218)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(279, 20)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "Email Address (for Purchasing/PO's)"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFAXNumber
        '
        Me.txtFAXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFAXNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFAXNumber.Location = New System.Drawing.Point(121, 183)
        Me.txtFAXNumber.Name = "txtFAXNumber"
        Me.txtFAXNumber.Size = New System.Drawing.Size(175, 20)
        Me.txtFAXNumber.TabIndex = 21
        Me.txtFAXNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContactName
        '
        Me.txtContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactName.Location = New System.Drawing.Point(17, 41)
        Me.txtContactName.MaxLength = 200
        Me.txtContactName.Multiline = True
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(280, 96)
        Me.txtContactName.TabIndex = 19
        Me.txtContactName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhoneNumber.Location = New System.Drawing.Point(121, 155)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(175, 20)
        Me.txtPhoneNumber.TabIndex = 20
        Me.txtPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(17, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(149, 20)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Contact Name(s)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(17, 155)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(107, 20)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Telephone Number"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(16, 183)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(107, 20)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "FAX Number"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemittanceEmail
        '
        Me.txtRemittanceEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemittanceEmail.CausesValidation = False
        Me.txtRemittanceEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemittanceEmail.Location = New System.Drawing.Point(18, 566)
        Me.txtRemittanceEmail.MaxLength = 200
        Me.txtRemittanceEmail.Multiline = True
        Me.txtRemittanceEmail.Name = "txtRemittanceEmail"
        Me.txtRemittanceEmail.Size = New System.Drawing.Size(357, 75)
        Me.txtRemittanceEmail.TabIndex = 49
        Me.txtRemittanceEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(18, 546)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(280, 20)
        Me.Label44.TabIndex = 25
        Me.Label44.Text = "Email Address (Auto-send A/P Remittance)"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAccountDescription
        '
        Me.cboAccountDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboAccountDescription.FormattingEnabled = True
        Me.cboAccountDescription.Location = New System.Drawing.Point(19, 142)
        Me.cboAccountDescription.Name = "cboAccountDescription"
        Me.cboAccountDescription.Size = New System.Drawing.Size(278, 21)
        Me.cboAccountDescription.TabIndex = 34
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(17, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(107, 20)
        Me.Label29.TabIndex = 37
        Me.Label29.Text = "Default Item"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDefaultItem
        '
        Me.cboDefaultItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDefaultItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDefaultItem.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboDefaultItem.DisplayMember = "ItemID"
        Me.cboDefaultItem.FormattingEnabled = True
        Me.cboDefaultItem.Location = New System.Drawing.Point(92, 19)
        Me.cboDefaultItem.Name = "cboDefaultItem"
        Me.cboDefaultItem.Size = New System.Drawing.Size(204, 21)
        Me.cboDefaultItem.TabIndex = 31
        '
        'NonInventoryItemListBindingSource
        '
        Me.NonInventoryItemListBindingSource.DataMember = "NonInventoryItemList"
        Me.NonInventoryItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDefaultGLAccount
        '
        Me.cboDefaultGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDefaultGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDefaultGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboDefaultGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboDefaultGLAccount.FormattingEnabled = True
        Me.cboDefaultGLAccount.Location = New System.Drawing.Point(93, 112)
        Me.cboDefaultGLAccount.Name = "cboDefaultGLAccount"
        Me.cboDefaultGLAccount.Size = New System.Drawing.Size(204, 21)
        Me.cboDefaultGLAccount.TabIndex = 33
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(16, 114)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(107, 20)
        Me.Label31.TabIndex = 33
        Me.Label31.Text = "Default GL #"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 768)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 47
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 768)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 46
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 768)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 45
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(828, 768)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 44
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdOpenVendorReturns
        '
        Me.cmdOpenVendorReturns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenVendorReturns.Location = New System.Drawing.Point(1059, 723)
        Me.cmdOpenVendorReturns.Name = "cmdOpenVendorReturns"
        Me.cmdOpenVendorReturns.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenVendorReturns.TabIndex = 43
        Me.cmdOpenVendorReturns.Text = "Return Form"
        Me.cmdOpenVendorReturns.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.ForeColor = System.Drawing.Color.Blue
        Me.cmdClear.Location = New System.Drawing.Point(828, 723)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 40
        Me.cmdClear.Text = "Clear All"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdOpenViewPurchasesForm
        '
        Me.cmdOpenViewPurchasesForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenViewPurchasesForm.Location = New System.Drawing.Point(982, 723)
        Me.cmdOpenViewPurchasesForm.Name = "cmdOpenViewPurchasesForm"
        Me.cmdOpenViewPurchasesForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenViewPurchasesForm.TabIndex = 42
        Me.cmdOpenViewPurchasesForm.Text = "Vendor Purchases"
        Me.cmdOpenViewPurchasesForm.UseVisualStyleBackColor = True
        '
        'cmdOpenPOForm
        '
        Me.cmdOpenPOForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenPOForm.Location = New System.Drawing.Point(905, 723)
        Me.cmdOpenPOForm.Name = "cmdOpenPOForm"
        Me.cmdOpenPOForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenPOForm.TabIndex = 41
        Me.cmdOpenPOForm.Text = "PO Form"
        Me.cmdOpenPOForm.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtItemDescription)
        Me.GroupBox1.Controls.Add(Me.cboDefaultItem)
        Me.GroupBox1.Controls.Add(Me.cboDefaultGLAccount)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.cboAccountDescription)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Location = New System.Drawing.Point(392, 630)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(313, 178)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Default Vendor Item"
        '
        'txtItemDescription
        '
        Me.txtItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemDescription.Location = New System.Drawing.Point(20, 49)
        Me.txtItemDescription.Multiline = True
        Me.txtItemDescription.Name = "txtItemDescription"
        Me.txtItemDescription.Size = New System.Drawing.Size(277, 54)
        Me.txtItemDescription.TabIndex = 32
        Me.txtItemDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkProp65)
        Me.GroupBox2.Controls.Add(Me.chkIsoCompliant)
        Me.GroupBox2.Controls.Add(Me.dtpApprovalDate)
        Me.GroupBox2.Controls.Add(Me.cboApprovalCriteria)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.txtApprovedBy)
        Me.GroupBox2.Location = New System.Drawing.Point(392, 449)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(313, 171)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ISO Details"
        '
        'chkProp65
        '
        Me.chkProp65.AutoSize = True
        Me.chkProp65.ForeColor = System.Drawing.Color.Blue
        Me.chkProp65.Location = New System.Drawing.Point(129, 22)
        Me.chkProp65.Name = "chkProp65"
        Me.chkProp65.Size = New System.Drawing.Size(118, 17)
        Me.chkProp65.TabIndex = 25
        Me.chkProp65.Text = "Prop 65 Compliant?"
        Me.chkProp65.UseVisualStyleBackColor = True
        '
        'chkIsoCompliant
        '
        Me.chkIsoCompliant.AutoSize = True
        Me.chkIsoCompliant.ForeColor = System.Drawing.Color.Blue
        Me.chkIsoCompliant.Location = New System.Drawing.Point(130, 49)
        Me.chkIsoCompliant.Name = "chkIsoCompliant"
        Me.chkIsoCompliant.Size = New System.Drawing.Size(99, 17)
        Me.chkIsoCompliant.TabIndex = 26
        Me.chkIsoCompliant.Text = "ISO Compliant?"
        Me.chkIsoCompliant.UseVisualStyleBackColor = True
        '
        'dtpApprovalDate
        '
        Me.dtpApprovalDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpApprovalDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpApprovalDate.Location = New System.Drawing.Point(130, 137)
        Me.dtpApprovalDate.Name = "dtpApprovalDate"
        Me.dtpApprovalDate.Size = New System.Drawing.Size(167, 20)
        Me.dtpApprovalDate.TabIndex = 29
        '
        'cboApprovalCriteria
        '
        Me.cboApprovalCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboApprovalCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboApprovalCriteria.FormattingEnabled = True
        Me.cboApprovalCriteria.Items.AddRange(New Object() {"Grandfathered", "ISO 9001", "Site Visit", "Customer Specified", "Sampling", "Reference"})
        Me.cboApprovalCriteria.Location = New System.Drawing.Point(129, 106)
        Me.cboApprovalCriteria.Name = "cboApprovalCriteria"
        Me.cboApprovalCriteria.Size = New System.Drawing.Size(167, 21)
        Me.cboApprovalCriteria.TabIndex = 28
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(21, 137)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(94, 20)
        Me.Label32.TabIndex = 30
        Me.Label32.Text = "Approval Date"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(21, 76)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(94, 20)
        Me.Label34.TabIndex = 7
        Me.Label34.Text = "Approved By?"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(21, 107)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(94, 20)
        Me.Label35.TabIndex = 28
        Me.Label35.Text = "Approval Criteria"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApprovedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApprovedBy.Location = New System.Drawing.Point(129, 76)
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Size = New System.Drawing.Size(167, 20)
        Me.txtApprovedBy.TabIndex = 27
        Me.txtApprovedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(392, 401)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(313, 45)
        Me.Label36.TabIndex = 39
        Me.Label36.Text = "A vendor may be deleted if it has no activity, otherwise it must be de-activated " & _
            "by its Vendor Class."
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'PaymentTermsTableAdapter
        '
        Me.PaymentTermsTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'NonInventoryItemListTableAdapter
        '
        Me.NonInventoryItemListTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoOtherACH)
        Me.GroupBox3.Controls.Add(Me.rdoFedexCheck)
        Me.GroupBox3.Controls.Add(Me.rdoCheckCodeIntercompany)
        Me.GroupBox3.Controls.Add(Me.rdoCheckCodeStandard)
        Me.GroupBox3.Controls.Add(Me.chkWhitePaperCheck)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(349, 161)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Check Data"
        '
        'rdoOtherACH
        '
        Me.rdoOtherACH.AutoSize = True
        Me.rdoOtherACH.ForeColor = System.Drawing.Color.Blue
        Me.rdoOtherACH.Location = New System.Drawing.Point(15, 137)
        Me.rdoOtherACH.Name = "rdoOtherACH"
        Me.rdoOtherACH.Size = New System.Drawing.Size(82, 17)
        Me.rdoOtherACH.TabIndex = 40
        Me.rdoOtherACH.TabStop = True
        Me.rdoOtherACH.Text = "Other ACH?"
        Me.rdoOtherACH.UseVisualStyleBackColor = True
        '
        'rdoFedexCheck
        '
        Me.rdoFedexCheck.AutoSize = True
        Me.rdoFedexCheck.ForeColor = System.Drawing.Color.Blue
        Me.rdoFedexCheck.Location = New System.Drawing.Point(15, 109)
        Me.rdoFedexCheck.Name = "rdoFedexCheck"
        Me.rdoFedexCheck.Size = New System.Drawing.Size(94, 17)
        Me.rdoFedexCheck.TabIndex = 39
        Me.rdoFedexCheck.TabStop = True
        Me.rdoFedexCheck.Text = "Fedex Check?"
        Me.rdoFedexCheck.UseVisualStyleBackColor = True
        '
        'rdoCheckCodeIntercompany
        '
        Me.rdoCheckCodeIntercompany.AutoSize = True
        Me.rdoCheckCodeIntercompany.ForeColor = System.Drawing.Color.Blue
        Me.rdoCheckCodeIntercompany.Location = New System.Drawing.Point(15, 81)
        Me.rdoCheckCodeIntercompany.Name = "rdoCheckCodeIntercompany"
        Me.rdoCheckCodeIntercompany.Size = New System.Drawing.Size(128, 17)
        Me.rdoCheckCodeIntercompany.TabIndex = 38
        Me.rdoCheckCodeIntercompany.Text = "Intercompany check?"
        Me.rdoCheckCodeIntercompany.UseVisualStyleBackColor = True
        '
        'rdoCheckCodeStandard
        '
        Me.rdoCheckCodeStandard.AutoSize = True
        Me.rdoCheckCodeStandard.Checked = True
        Me.rdoCheckCodeStandard.ForeColor = System.Drawing.Color.Blue
        Me.rdoCheckCodeStandard.Location = New System.Drawing.Point(15, 53)
        Me.rdoCheckCodeStandard.Name = "rdoCheckCodeStandard"
        Me.rdoCheckCodeStandard.Size = New System.Drawing.Size(145, 17)
        Me.rdoCheckCodeStandard.TabIndex = 37
        Me.rdoCheckCodeStandard.TabStop = True
        Me.rdoCheckCodeStandard.Text = "Standard Vendor Check?"
        Me.rdoCheckCodeStandard.UseVisualStyleBackColor = True
        '
        'tabVendorControl
        '
        Me.tabVendorControl.Controls.Add(tabVendorDetails)
        Me.tabVendorControl.Controls.Add(Me.tabCheckData)
        Me.tabVendorControl.Location = New System.Drawing.Point(728, 41)
        Me.tabVendorControl.Name = "tabVendorControl"
        Me.tabVendorControl.SelectedIndex = 0
        Me.tabVendorControl.Size = New System.Drawing.Size(402, 670)
        Me.tabVendorControl.TabIndex = 48
        '
        'tabCheckData
        '
        Me.tabCheckData.Controls.Add(Me.Label51)
        Me.tabCheckData.Controls.Add(Me.Label50)
        Me.tabCheckData.Controls.Add(Me.Label49)
        Me.tabCheckData.Controls.Add(Me.Label48)
        Me.tabCheckData.Controls.Add(Me.txtACHContactEmail)
        Me.tabCheckData.Controls.Add(Me.txtACHVerifyDate)
        Me.tabCheckData.Controls.Add(Me.txtACHContactPhone)
        Me.tabCheckData.Controls.Add(Me.txtACHContactName)
        Me.tabCheckData.Controls.Add(Me.GroupBox4)
        Me.tabCheckData.Controls.Add(Me.txtRoutingNumber)
        Me.tabCheckData.Controls.Add(Me.Label47)
        Me.tabCheckData.Controls.Add(Me.Label44)
        Me.tabCheckData.Controls.Add(Me.txtRemittanceEmail)
        Me.tabCheckData.Controls.Add(Me.txtVendorAccount)
        Me.tabCheckData.Controls.Add(Me.Label45)
        Me.tabCheckData.Controls.Add(Me.GroupBox3)
        Me.tabCheckData.Location = New System.Drawing.Point(4, 22)
        Me.tabCheckData.Name = "tabCheckData"
        Me.tabCheckData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCheckData.Size = New System.Drawing.Size(394, 644)
        Me.tabCheckData.TabIndex = 1
        Me.tabCheckData.Text = "Vendor Check/Auto-Pay Details"
        Me.tabCheckData.UseVisualStyleBackColor = True
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(18, 438)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(83, 20)
        Me.Label51.TabIndex = 53
        Me.Label51.Text = "Contact Email"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(18, 413)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(83, 20)
        Me.Label50.TabIndex = 52
        Me.Label50.Text = "Date"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(18, 388)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(83, 20)
        Me.Label49.TabIndex = 51
        Me.Label49.Text = "Contact Phone"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(18, 363)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(83, 20)
        Me.Label48.TabIndex = 50
        Me.Label48.Text = "Contact Name"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtACHContactEmail
        '
        Me.txtACHContactEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtACHContactEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtACHContactEmail.Location = New System.Drawing.Point(18, 461)
        Me.txtACHContactEmail.Multiline = True
        Me.txtACHContactEmail.Name = "txtACHContactEmail"
        Me.txtACHContactEmail.Size = New System.Drawing.Size(357, 75)
        Me.txtACHContactEmail.TabIndex = 48
        '
        'txtACHVerifyDate
        '
        Me.txtACHVerifyDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtACHVerifyDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtACHVerifyDate.Location = New System.Drawing.Point(109, 413)
        Me.txtACHVerifyDate.Name = "txtACHVerifyDate"
        Me.txtACHVerifyDate.Size = New System.Drawing.Size(266, 20)
        Me.txtACHVerifyDate.TabIndex = 47
        '
        'txtACHContactPhone
        '
        Me.txtACHContactPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtACHContactPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtACHContactPhone.Location = New System.Drawing.Point(109, 388)
        Me.txtACHContactPhone.Name = "txtACHContactPhone"
        Me.txtACHContactPhone.Size = New System.Drawing.Size(266, 20)
        Me.txtACHContactPhone.TabIndex = 46
        '
        'txtACHContactName
        '
        Me.txtACHContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtACHContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtACHContactName.Location = New System.Drawing.Point(109, 363)
        Me.txtACHContactName.Name = "txtACHContactName"
        Me.txtACHContactName.Size = New System.Drawing.Size(266, 20)
        Me.txtACHContactName.TabIndex = 45
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdoSavings)
        Me.GroupBox4.Controls.Add(Me.rdoChecking)
        Me.GroupBox4.Location = New System.Drawing.Point(53, 273)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(283, 67)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        '
        'rdoSavings
        '
        Me.rdoSavings.AutoSize = True
        Me.rdoSavings.Location = New System.Drawing.Point(15, 42)
        Me.rdoSavings.Name = "rdoSavings"
        Me.rdoSavings.Size = New System.Drawing.Size(106, 17)
        Me.rdoSavings.TabIndex = 44
        Me.rdoSavings.Text = "Savings Account"
        Me.rdoSavings.UseVisualStyleBackColor = True
        '
        'rdoChecking
        '
        Me.rdoChecking.AutoSize = True
        Me.rdoChecking.Checked = True
        Me.rdoChecking.Location = New System.Drawing.Point(15, 19)
        Me.rdoChecking.Name = "rdoChecking"
        Me.rdoChecking.Size = New System.Drawing.Size(113, 17)
        Me.rdoChecking.TabIndex = 43
        Me.rdoChecking.TabStop = True
        Me.rdoChecking.Text = "Checking Account"
        Me.rdoChecking.UseVisualStyleBackColor = True
        '
        'txtRoutingNumber
        '
        Me.txtRoutingNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoutingNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRoutingNumber.Location = New System.Drawing.Point(18, 247)
        Me.txtRoutingNumber.Name = "txtRoutingNumber"
        Me.txtRoutingNumber.Size = New System.Drawing.Size(352, 20)
        Me.txtRoutingNumber.TabIndex = 42
        Me.txtRoutingNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(18, 224)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(217, 20)
        Me.Label47.TabIndex = 38
        Me.Label47.Text = "Vendor Routing Number"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUploadOpenW9
        '
        Me.cmdUploadOpenW9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadOpenW9.Location = New System.Drawing.Point(751, 724)
        Me.cmdUploadOpenW9.Name = "cmdUploadOpenW9"
        Me.cmdUploadOpenW9.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadOpenW9.TabIndex = 49
        Me.cmdUploadOpenW9.Text = "Upload/ Open W9"
        Me.cmdUploadOpenW9.UseVisualStyleBackColor = True
        '
        'cmdScanW9
        '
        Me.cmdScanW9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdScanW9.Location = New System.Drawing.Point(751, 768)
        Me.cmdScanW9.Name = "cmdScanW9"
        Me.cmdScanW9.Size = New System.Drawing.Size(71, 40)
        Me.cmdScanW9.TabIndex = 50
        Me.cmdScanW9.Text = "Scan W9"
        Me.cmdScanW9.UseVisualStyleBackColor = True
        '
        'VendorInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdScanW9)
        Me.Controls.Add(Me.cmdUploadOpenW9)
        Me.Controls.Add(Me.tabVendorControl)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOpenPOForm)
        Me.Controls.Add(Me.cmdOpenViewPurchasesForm)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdOpenVendorReturns)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxVendorContact)
        Me.Controls.Add(Me.gpxVendorAddress)
        Me.Controls.Add(Me.gpxVendorInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "VendorInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Vendor Maintenance Form"
        tabVendorDetails.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gpxVendorPurchaseDetails.ResumeLayout(False)
        Me.gpxVendorPurchaseDetails.PerformLayout()
        Me.gpxVendorReports.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxVendorInfo.ResumeLayout(False)
        Me.gpxVendorInfo.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVendorAddress.ResumeLayout(False)
        Me.gpxVendorAddress.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVendorContact.ResumeLayout(False)
        Me.gpxVendorContact.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tabVendorControl.ResumeLayout(False)
        Me.tabCheckData.ResumeLayout(False)
        Me.tabCheckData.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxVendorInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTaxIDLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gpxVendorAddress As System.Windows.Forms.GroupBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMTDPurchases As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents gpxVendorContact As System.Windows.Forms.GroupBox
    Friend WithEvents txtFAXNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtYTDPurchases As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtVendorComment As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorTaxID As System.Windows.Forms.TextBox
    Friend WithEvents dtpVendorDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents gpxVendorPurchaseDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents gpxVendorReports As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdOpenVendorReturns As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmdPurchaseActivityReport As System.Windows.Forms.Button
    Friend WithEvents cmdPaymentActivityReport As System.Windows.Forms.Button
    Friend WithEvents cmdPurchaseAnalysisReport As System.Windows.Forms.Button
    Friend WithEvents cmdVendorListingReport As System.Windows.Forms.Button
    Friend WithEvents cmdVendorReturns As System.Windows.Forms.Button
    Friend WithEvents cmdAgedPayablesReport As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdOpenViewPurchasesForm As System.Windows.Forms.Button
    Friend WithEvents cmdOpenPOForm As System.Windows.Forms.Button
    Friend WithEvents cboDefaultGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboDefaultItem As System.Windows.Forms.ComboBox
    Friend WithEvents txtCreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents SaveVendorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintVendorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteVendorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboPreferredShipper As System.Windows.Forms.ComboBox
    Friend WithEvents txtLastActivityDate As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorEmail As System.Windows.Forms.TextBox
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintVendorListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintVendorPurchaseHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintVendorPaymentHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboAccountDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemDescription As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtApprovedBy As System.Windows.Forms.TextBox
    Friend WithEvents dtpApprovalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboApprovalCriteria As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents chkIsoCompliant As System.Windows.Forms.CheckBox
    Friend WithEvents PrintAPAgingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPurchaseActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPurchaseAnalysisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPaymentActivityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtYTDVouchers As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtMTDVouchers As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtYTDSteel As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtMTDSteel As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtTotalYTD As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMTD As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents NonInventoryItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonInventoryItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents chkProp65 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWhitePaperCheck As System.Windows.Forms.CheckBox
    Friend WithEvents txtRemittanceEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoCheckCodeIntercompany As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCheckCodeStandard As System.Windows.Forms.RadioButton
    Friend WithEvents txtVendorAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents rdoFedexCheck As System.Windows.Forms.RadioButton
    Friend WithEvents tabVendorControl As System.Windows.Forms.TabControl
    Friend WithEvents tabCheckData As System.Windows.Forms.TabPage
    Friend WithEvents txtRoutingNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSavings As System.Windows.Forms.RadioButton
    Friend WithEvents rdoChecking As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOtherACH As System.Windows.Forms.RadioButton
    Friend WithEvents txtACHContactEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtACHVerifyDate As System.Windows.Forms.TextBox
    Friend WithEvents txtACHContactPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtACHContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkVendor1099 As System.Windows.Forms.CheckBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cmdUploadOpenW9 As System.Windows.Forms.Button
    Friend WithEvents cmdScanW9 As System.Windows.Forms.Button
    Friend WithEvents ReuploadW9ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblName1099 As System.Windows.Forms.Label
    Friend WithEvents txt1099Name As System.Windows.Forms.TextBox
End Class
