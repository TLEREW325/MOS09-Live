<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TFPQuoteForm
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
        Dim ContactNameLabel As System.Windows.Forms.Label
        Dim CustomerNameLabel As System.Windows.Forms.Label
        Dim CustomerIDLabel As System.Windows.Forms.Label
        Dim Label80 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdGenerateQuote = New System.Windows.Forms.Button
        Me.dtpQuoteDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboQuoteNumber = New System.Windows.Forms.ComboBox
        Me.txtPreparedBy = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtMobileNumber = New System.Windows.Forms.TextBox
        Me.Label81 = New System.Windows.Forms.Label
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtRepAgency = New System.Windows.Forms.TextBox
        Me.cboRFQSource = New System.Windows.Forms.ComboBox
        Me.txtCustomerInqueryNumber = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.txtPhoneExtension = New System.Windows.Forms.TextBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.txtContactName = New System.Windows.Forms.TextBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ciLabel9 = New System.Windows.Forms.Label
        Me.ciLabel8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtQuoteRevisionLevel = New System.Windows.Forms.TextBox
        Me.Label79 = New System.Windows.Forms.Label
        Me.txtReferenceQuoteNumber = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.gpxPartInfo = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPartSize = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTFPPartNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPartDescription = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCustPartNo = New System.Windows.Forms.TextBox
        Me.tabctrl = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.nbrHaasMiniMill = New System.Windows.Forms.NumericUpDown
        Me.Label74 = New System.Windows.Forms.Label
        Me.nbrHaasMill = New System.Windows.Forms.NumericUpDown
        Me.Label70 = New System.Windows.Forms.Label
        Me.nbrBarFeed = New System.Windows.Forms.NumericUpDown
        Me.Label69 = New System.Windows.Forms.Label
        Me.nbrTapping = New System.Windows.Forms.NumericUpDown
        Me.Label25 = New System.Windows.Forms.Label
        Me.nbrGrinding = New System.Windows.Forms.NumericUpDown
        Me.Label26 = New System.Windows.Forms.Label
        Me.nbrMazakMill = New System.Windows.Forms.NumericUpDown
        Me.Label27 = New System.Windows.Forms.Label
        Me.nbrMazakLathe = New System.Windows.Forms.NumericUpDown
        Me.Label28 = New System.Windows.Forms.Label
        Me.nbrLatheWork = New System.Windows.Forms.NumericUpDown
        Me.Label29 = New System.Windows.Forms.Label
        Me.nbrShotPeen = New System.Windows.Forms.NumericUpDown
        Me.Label30 = New System.Windows.Forms.Label
        Me.nbrCounterSink = New System.Windows.Forms.NumericUpDown
        Me.Label31 = New System.Windows.Forms.Label
        Me.nbrDrilling = New System.Windows.Forms.NumericUpDown
        Me.Label32 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.nbrFlatRoll = New System.Windows.Forms.NumericUpDown
        Me.Label33 = New System.Windows.Forms.Label
        Me.nbrBoltMaker = New System.Windows.Forms.NumericUpDown
        Me.Label34 = New System.Windows.Forms.Label
        Me.nbrReed = New System.Windows.Forms.NumericUpDown
        Me.Label35 = New System.Windows.Forms.Label
        Me.nbrHandRollNo50 = New System.Windows.Forms.NumericUpDown
        Me.Label36 = New System.Windows.Forms.Label
        Me.nbrHandRoll = New System.Windows.Forms.NumericUpDown
        Me.Label37 = New System.Windows.Forms.Label
        Me.nbrNo40 = New System.Windows.Forms.NumericUpDown
        Me.Label38 = New System.Windows.Forms.Label
        Me.nbrNo360H60 = New System.Windows.Forms.NumericUpDown
        Me.Label39 = New System.Windows.Forms.Label
        Me.nbrNo20H20 = New System.Windows.Forms.NumericUpDown
        Me.Label40 = New System.Windows.Forms.Label
        Me.nbrNo10Slow = New System.Windows.Forms.NumericUpDown
        Me.Label41 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.nbrHotFormer = New System.Windows.Forms.NumericUpDown
        Me.Label24 = New System.Windows.Forms.Label
        Me.nbrCenterless = New System.Windows.Forms.NumericUpDown
        Me.Label23 = New System.Windows.Forms.Label
        Me.nbrPunchPress = New System.Windows.Forms.NumericUpDown
        Me.Label22 = New System.Windows.Forms.Label
        Me.nbrShave = New System.Windows.Forms.NumericUpDown
        Me.Label21 = New System.Windows.Forms.Label
        Me.nbrHandSlot = New System.Windows.Forms.NumericUpDown
        Me.Label20 = New System.Windows.Forms.Label
        Me.nbrSlot = New System.Windows.Forms.NumericUpDown
        Me.Label19 = New System.Windows.Forms.Label
        Me.nbrThreadCut = New System.Windows.Forms.NumericUpDown
        Me.Label18 = New System.Windows.Forms.Label
        Me.nbrPoint = New System.Windows.Forms.NumericUpDown
        Me.Label17 = New System.Windows.Forms.Label
        Me.nbrTrim = New System.Windows.Forms.NumericUpDown
        Me.Label16 = New System.Windows.Forms.Label
        Me.nbrExtrude = New System.Windows.Forms.NumericUpDown
        Me.Label9 = New System.Windows.Forms.Label
        Me.gpxHeader = New System.Windows.Forms.GroupBox
        Me.rdoHeader9899 = New System.Windows.Forms.RadioButton
        Me.rdoHeader104109112 = New System.Windows.Forms.RadioButton
        Me.rdoHeader20 = New System.Windows.Forms.RadioButton
        Me.rdoHeader1819 = New System.Windows.Forms.RadioButton
        Me.rdoHeader1221 = New System.Windows.Forms.RadioButton
        Me.rdoHeader5 = New System.Windows.Forms.RadioButton
        Me.rdoHeader46917 = New System.Windows.Forms.RadioButton
        Me.rdoHeader137814 = New System.Windows.Forms.RadioButton
        Me.rdoHeader1011 = New System.Windows.Forms.RadioButton
        Me.rdoHeaderNone = New System.Windows.Forms.RadioButton
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.Label78 = New System.Windows.Forms.Label
        Me.txtOutsideOtherOperationTotal = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtOtherOperationTotal = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.cmdDeleteOtherOperation = New System.Windows.Forms.Button
        Me.cmdAddOtherOperation = New System.Windows.Forms.Button
        Me.dgvOtherOperations = New System.Windows.Forms.DataGridView
        Me.txtSetupCharge = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtToolingCharge = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtMaterialCostPer = New System.Windows.Forms.TextBox
        Me.txtSpecialMaterialType = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.rdoSpecialMaterial = New System.Windows.Forms.RadioButton
        Me.rdoStainless = New System.Windows.Forms.RadioButton
        Me.rdoRebar = New System.Windows.Forms.RadioButton
        Me.rdoAlloy = New System.Windows.Forms.RadioButton
        Me.rdoC1038 = New System.Windows.Forms.RadioButton
        Me.rdoC1010ToC1018Annealed = New System.Windows.Forms.RadioButton
        Me.rdoC1010ToC1018 = New System.Windows.Forms.RadioButton
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.chkBake = New System.Windows.Forms.CheckBox
        Me.chkNickelPlating = New System.Windows.Forms.CheckBox
        Me.chkPicklePlate = New System.Windows.Forms.CheckBox
        Me.chkPhosphateAndOil = New System.Windows.Forms.CheckBox
        Me.chkOutsideHeatTreatOrPlating = New System.Windows.Forms.CheckBox
        Me.chkCaseHardening = New System.Windows.Forms.CheckBox
        Me.chkHeatTreat = New System.Windows.Forms.CheckBox
        Me.chkZincPlating = New System.Windows.Forms.CheckBox
        Me.chkAnneal = New System.Windows.Forms.CheckBox
        Me.chkTumbleAndWash = New System.Windows.Forms.CheckBox
        Me.chkWireCleaning = New System.Windows.Forms.CheckBox
        Me.TabPage10 = New System.Windows.Forms.TabPage
        Me.cmdAddSegment = New System.Windows.Forms.Button
        Me.txtFinishedWeight = New System.Windows.Forms.TextBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.txtScrapPercent = New System.Windows.Forms.TextBox
        Me.Label77 = New System.Windows.Forms.Label
        Me.cmdDeleteSegment = New System.Windows.Forms.Button
        Me.dgvSegments = New System.Windows.Forms.DataGridView
        Me.gpxDimensionalUnits = New System.Windows.Forms.GroupBox
        Me.rdoMetric = New System.Windows.Forms.RadioButton
        Me.rdoStandard = New System.Windows.Forms.RadioButton
        Me.gpxMaterialType = New System.Windows.Forms.GroupBox
        Me.rdoBronze = New System.Windows.Forms.RadioButton
        Me.rdoNavalBrass = New System.Windows.Forms.RadioButton
        Me.rdoFreeCutBrass = New System.Windows.Forms.RadioButton
        Me.rdoCopper = New System.Windows.Forms.RadioButton
        Me.rdoAluminum = New System.Windows.Forms.RadioButton
        Me.rdoSteel = New System.Windows.Forms.RadioButton
        Me.tabQC = New System.Windows.Forms.TabPage
        Me.QCGroupbox6 = New System.Windows.Forms.GroupBox
        Me.chkOutsideHTCertification = New System.Windows.Forms.CheckBox
        Me.nbrPPap = New System.Windows.Forms.NumericUpDown
        Me.Label63 = New System.Windows.Forms.Label
        Me.nbrISIR = New System.Windows.Forms.NumericUpDown
        Me.Label62 = New System.Windows.Forms.Label
        Me.nbrMagParticle = New System.Windows.Forms.NumericUpDown
        Me.Label61 = New System.Windows.Forms.Label
        Me.nbrPlating = New System.Windows.Forms.NumericUpDown
        Me.Label60 = New System.Windows.Forms.Label
        Me.nbrDimensional = New System.Windows.Forms.NumericUpDown
        Me.Label59 = New System.Windows.Forms.Label
        Me.nbrSPCRequired = New System.Windows.Forms.NumericUpDown
        Me.Label58 = New System.Windows.Forms.Label
        Me.nbrSamplesRequired = New System.Windows.Forms.NumericUpDown
        Me.Label57 = New System.Windows.Forms.Label
        Me.nbrCertificationRequired = New System.Windows.Forms.NumericUpDown
        Me.Label56 = New System.Windows.Forms.Label
        Me.nbrMillCertification = New System.Windows.Forms.NumericUpDown
        Me.Label55 = New System.Windows.Forms.Label
        Me.nbrChemistry = New System.Windows.Forms.NumericUpDown
        Me.Label54 = New System.Windows.Forms.Label
        Me.nbrNylonPatch = New System.Windows.Forms.NumericUpDown
        Me.Label53 = New System.Windows.Forms.Label
        Me.nbrCertificateOfCompliance = New System.Windows.Forms.NumericUpDown
        Me.Label50 = New System.Windows.Forms.Label
        Me.QCGroupBox5 = New System.Windows.Forms.GroupBox
        Me.nbrFurnaceChartCopy = New System.Windows.Forms.NumericUpDown
        Me.Label67 = New System.Windows.Forms.Label
        Me.nbrMicroDecarb = New System.Windows.Forms.NumericUpDown
        Me.Label66 = New System.Windows.Forms.Label
        Me.nbrMicroCaseDepth = New System.Windows.Forms.NumericUpDown
        Me.Label65 = New System.Windows.Forms.Label
        Me.nbrSurfaceandCore = New System.Windows.Forms.NumericUpDown
        Me.Label64 = New System.Windows.Forms.Label
        Me.QCGroupBox4 = New System.Windows.Forms.GroupBox
        Me.nbrTWDTensile = New System.Windows.Forms.NumericUpDown
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.nbrAdditionalSpecimen = New System.Windows.Forms.NumericUpDown
        Me.nbrWedgeBendShear = New System.Windows.Forms.NumericUpDown
        Me.chk5SpecimenMax = New System.Windows.Forms.CheckBox
        Me.QCGroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.nbrSaltSprayQuantity = New System.Windows.Forms.NumericUpDown
        Me.rdoSaltSprayNone = New System.Windows.Forms.RadioButton
        Me.Label44 = New System.Windows.Forms.Label
        Me.nbrSaltSprayAdditionalHours = New System.Windows.Forms.NumericUpDown
        Me.rdo168Hours = New System.Windows.Forms.RadioButton
        Me.rdo120Hours = New System.Windows.Forms.RadioButton
        Me.rdo96Hours = New System.Windows.Forms.RadioButton
        Me.rdo72Hours = New System.Windows.Forms.RadioButton
        Me.rdo48Hours = New System.Windows.Forms.RadioButton
        Me.rdo24Hours = New System.Windows.Forms.RadioButton
        Me.tabMarkup = New System.Windows.Forms.TabPage
        Me.cmdDeleteSelectedMarkup = New System.Windows.Forms.Button
        Me.cmdAddMarkup = New System.Windows.Forms.Button
        Me.dgvMarkupQuotes = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblDeliveryRequirement = New System.Windows.Forms.Label
        Me.txtDeliveryRequirements = New System.Windows.Forms.TextBox
        Me.dgvEstimatedCost = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.tabctrlPartNotes = New System.Windows.Forms.TabControl
        Me.tabPartInfo = New System.Windows.Forms.TabPage
        Me.tabNotesComments = New System.Windows.Forms.TabPage
        Me.Label47 = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.InternalNotes = New System.Windows.Forms.TabPage
        Me.Label51 = New System.Windows.Forms.Label
        Me.txtInternalNotes = New System.Windows.Forms.TextBox
        Me.cmdCreateEntries = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtStartWeight = New System.Windows.Forms.Label
        Me.Label75 = New System.Windows.Forms.Label
        Me.txtScrapWeight = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.cmdDuplicateQuote = New System.Windows.Forms.Button
        Me.dgvShipTotalsOutsideOpQC = New System.Windows.Forms.DataGridView
        ContactNameLabel = New System.Windows.Forms.Label
        CustomerNameLabel = New System.Windows.Forms.Label
        CustomerIDLabel = New System.Windows.Forms.Label
        Label80 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpxPartInfo.SuspendLayout()
        Me.tabctrl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.nbrHaasMiniMill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrHaasMill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrBarFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrTapping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrGrinding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMazakMill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMazakLathe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrLatheWork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrShotPeen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrCounterSink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrDrilling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.nbrFlatRoll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrBoltMaker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrReed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrHandRollNo50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrHandRoll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrNo40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrNo360H60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrNo20H20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrNo10Slow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nbrHotFormer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrCenterless, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrPunchPress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrShave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrHandSlot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrSlot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrThreadCut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrTrim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrExtrude, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxHeader.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        CType(Me.dgvOtherOperations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        CType(Me.dgvSegments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxDimensionalUnits.SuspendLayout()
        Me.gpxMaterialType.SuspendLayout()
        Me.tabQC.SuspendLayout()
        Me.QCGroupbox6.SuspendLayout()
        CType(Me.nbrPPap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrISIR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMagParticle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrPlating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrDimensional, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrSPCRequired, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrSamplesRequired, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrCertificationRequired, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMillCertification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrChemistry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrNylonPatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrCertificateOfCompliance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QCGroupBox5.SuspendLayout()
        CType(Me.nbrFurnaceChartCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMicroDecarb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMicroCaseDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrSurfaceandCore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QCGroupBox4.SuspendLayout()
        CType(Me.nbrTWDTensile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrAdditionalSpecimen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrWedgeBendShear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QCGroupBox3.SuspendLayout()
        CType(Me.nbrSaltSprayQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrSaltSprayAdditionalHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMarkup.SuspendLayout()
        CType(Me.dgvMarkupQuotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEstimatedCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabctrlPartNotes.SuspendLayout()
        Me.tabPartInfo.SuspendLayout()
        Me.tabNotesComments.SuspendLayout()
        Me.InternalNotes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvShipTotalsOutsideOpQC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContactNameLabel
        '
        ContactNameLabel.Location = New System.Drawing.Point(16, 75)
        ContactNameLabel.Name = "ContactNameLabel"
        ContactNameLabel.Size = New System.Drawing.Size(104, 20)
        ContactNameLabel.TabIndex = 13
        ContactNameLabel.Text = "Contact Name:"
        ContactNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerNameLabel
        '
        CustomerNameLabel.Location = New System.Drawing.Point(16, 48)
        CustomerNameLabel.Name = "CustomerNameLabel"
        CustomerNameLabel.Size = New System.Drawing.Size(104, 20)
        CustomerNameLabel.TabIndex = 12
        CustomerNameLabel.Text = "Customer Name:"
        CustomerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerIDLabel
        '
        CustomerIDLabel.Location = New System.Drawing.Point(16, 22)
        CustomerIDLabel.Name = "CustomerIDLabel"
        CustomerIDLabel.Size = New System.Drawing.Size(104, 20)
        CustomerIDLabel.TabIndex = 11
        CustomerIDLabel.Text = "Customer ID:"
        CustomerIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label80
        '
        Label80.Location = New System.Drawing.Point(14, 46)
        Label80.Name = "Label80"
        Label80.Size = New System.Drawing.Size(100, 20)
        Label80.TabIndex = 28
        Label80.Text = "Revision Level"
        Label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FToolStripMenuItem
        '
        Me.FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.FToolStripMenuItem.Name = "FToolStripMenuItem"
        Me.FToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
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
        'cmdGenerateQuote
        '
        Me.cmdGenerateQuote.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateQuote.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateQuote.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateQuote.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateQuote.Location = New System.Drawing.Point(114, 20)
        Me.cmdGenerateQuote.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateQuote.Name = "cmdGenerateQuote"
        Me.cmdGenerateQuote.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateQuote.TabIndex = 22
        Me.cmdGenerateQuote.TabStop = False
        Me.cmdGenerateQuote.Text = ">>"
        Me.cmdGenerateQuote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateQuote.UseVisualStyleBackColor = False
        '
        'dtpQuoteDate
        '
        Me.dtpQuoteDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpQuoteDate.Location = New System.Drawing.Point(146, 128)
        Me.dtpQuoteDate.Name = "dtpQuoteDate"
        Me.dtpQuoteDate.Size = New System.Drawing.Size(149, 20)
        Me.dtpQuoteDate.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 156)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Prepared By"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Quotation Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Quotation Number"
        '
        'cboQuoteNumber
        '
        Me.cboQuoteNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQuoteNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQuoteNumber.DisplayMember = "QuoteID"
        Me.cboQuoteNumber.FormattingEnabled = True
        Me.cboQuoteNumber.Location = New System.Drawing.Point(146, 19)
        Me.cboQuoteNumber.Name = "cboQuoteNumber"
        Me.cboQuoteNumber.Size = New System.Drawing.Size(149, 21)
        Me.cboQuoteNumber.TabIndex = 0
        '
        'txtPreparedBy
        '
        Me.txtPreparedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPreparedBy.Location = New System.Drawing.Point(146, 154)
        Me.txtPreparedBy.Margin = New System.Windows.Forms.Padding(3)
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.Size = New System.Drawing.Size(149, 21)
        Me.txtPreparedBy.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMobileNumber)
        Me.GroupBox1.Controls.Add(Me.Label81)
        Me.GroupBox1.Controls.Add(Me.txtPhone)
        Me.GroupBox1.Controls.Add(Me.txtFax)
        Me.GroupBox1.Controls.Add(Me.txtRepAgency)
        Me.GroupBox1.Controls.Add(Me.cboRFQSource)
        Me.GroupBox1.Controls.Add(Me.txtCustomerInqueryNumber)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.txtPhoneExtension)
        Me.GroupBox1.Controls.Add(Me.cboCustomerName)
        Me.GroupBox1.Controls.Add(Me.txtContactName)
        Me.GroupBox1.Controls.Add(Me.cboCustomerID)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label73)
        Me.GroupBox1.Controls.Add(Me.Label72)
        Me.GroupBox1.Controls.Add(Me.Label71)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(ContactNameLabel)
        Me.GroupBox1.Controls.Add(CustomerNameLabel)
        Me.GroupBox1.Controls.Add(CustomerIDLabel)
        Me.GroupBox1.Controls.Add(Me.ciLabel9)
        Me.GroupBox1.Controls.Add(Me.ciLabel8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 227)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(303, 310)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Information"
        '
        'txtMobileNumber
        '
        Me.txtMobileNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMobileNumber.Location = New System.Drawing.Point(107, 133)
        Me.txtMobileNumber.MaxLength = 15
        Me.txtMobileNumber.Name = "txtMobileNumber"
        Me.txtMobileNumber.Size = New System.Drawing.Size(188, 20)
        Me.txtMobileNumber.TabIndex = 5
        '
        'Label81
        '
        Me.Label81.Location = New System.Drawing.Point(16, 133)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(104, 20)
        Me.Label81.TabIndex = 27
        Me.Label81.Text = "Mobile No:"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPhone
        '
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Location = New System.Drawing.Point(107, 105)
        Me.txtPhone.MaxLength = 15
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(98, 20)
        Me.txtPhone.TabIndex = 3
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Location = New System.Drawing.Point(107, 161)
        Me.txtFax.MaxLength = 15
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(188, 20)
        Me.txtFax.TabIndex = 6
        '
        'txtRepAgency
        '
        Me.txtRepAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRepAgency.Location = New System.Drawing.Point(107, 245)
        Me.txtRepAgency.MaxLength = 30
        Me.txtRepAgency.Name = "txtRepAgency"
        Me.txtRepAgency.Size = New System.Drawing.Size(188, 20)
        Me.txtRepAgency.TabIndex = 9
        '
        'cboRFQSource
        '
        Me.cboRFQSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRFQSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRFQSource.FormattingEnabled = True
        Me.cboRFQSource.Items.AddRange(New Object() {"Inside Sales", "Manufacturing Representative", "Cold Call", "Web Page", "Unsolicited Fax", "Other"})
        Me.cboRFQSource.Location = New System.Drawing.Point(107, 273)
        Me.cboRFQSource.MaxLength = 30
        Me.cboRFQSource.Name = "cboRFQSource"
        Me.cboRFQSource.Size = New System.Drawing.Size(190, 21)
        Me.cboRFQSource.TabIndex = 10
        '
        'txtCustomerInqueryNumber
        '
        Me.txtCustomerInqueryNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerInqueryNumber.Location = New System.Drawing.Point(107, 217)
        Me.txtCustomerInqueryNumber.MaxLength = 40
        Me.txtCustomerInqueryNumber.Name = "txtCustomerInqueryNumber"
        Me.txtCustomerInqueryNumber.Size = New System.Drawing.Size(188, 20)
        Me.txtCustomerInqueryNumber.TabIndex = 8
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(211, 109)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(25, 13)
        Me.Label43.TabIndex = 20
        Me.Label43.Text = "Ext."
        '
        'txtPhoneExtension
        '
        Me.txtPhoneExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneExtension.Location = New System.Drawing.Point(239, 105)
        Me.txtPhoneExtension.Name = "txtPhoneExtension"
        Me.txtPhoneExtension.Size = New System.Drawing.Size(56, 20)
        Me.txtPhoneExtension.TabIndex = 4
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DisplayMember = "CustomerID"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(105, 48)
        Me.cboCustomerName.MaxLength = 50
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(190, 21)
        Me.cboCustomerName.TabIndex = 1
        '
        'txtContactName
        '
        Me.txtContactName.AcceptsTab = True
        Me.txtContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactName.Location = New System.Drawing.Point(105, 77)
        Me.txtContactName.MaxLength = 50
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(190, 20)
        Me.txtContactName.TabIndex = 2
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.Location = New System.Drawing.Point(105, 19)
        Me.cboCustomerID.MaxLength = 50
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(190, 21)
        Me.cboCustomerID.TabIndex = 0
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(107, 189)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(188, 20)
        Me.txtEmail.TabIndex = 7
        '
        'Label73
        '
        Me.Label73.Location = New System.Drawing.Point(16, 245)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(130, 20)
        Me.Label73.TabIndex = 26
        Me.Label73.Text = "Rep Agency"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label72
        '
        Me.Label72.Location = New System.Drawing.Point(16, 274)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(104, 20)
        Me.Label72.TabIndex = 23
        Me.Label72.Text = "RFQ Source"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label71
        '
        Me.Label71.Location = New System.Drawing.Point(16, 217)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(130, 20)
        Me.Label71.TabIndex = 22
        Me.Label71.Text = "Cust. Inquiry #"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Phone No:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ciLabel9
        '
        Me.ciLabel9.Location = New System.Drawing.Point(16, 189)
        Me.ciLabel9.Name = "ciLabel9"
        Me.ciLabel9.Size = New System.Drawing.Size(104, 20)
        Me.ciLabel9.TabIndex = 11
        Me.ciLabel9.Text = "E-mail Address:"
        Me.ciLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ciLabel8
        '
        Me.ciLabel8.Location = New System.Drawing.Point(16, 161)
        Me.ciLabel8.Name = "ciLabel8"
        Me.ciLabel8.Size = New System.Drawing.Size(104, 20)
        Me.ciLabel8.TabIndex = 9
        Me.ciLabel8.Text = "Fax Number:"
        Me.ciLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtQuoteRevisionLevel)
        Me.GroupBox2.Controls.Add(Label80)
        Me.GroupBox2.Controls.Add(Me.Label79)
        Me.GroupBox2.Controls.Add(Me.txtReferenceQuoteNumber)
        Me.GroupBox2.Controls.Add(Me.cboDivisionID)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cboQuoteNumber)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtPreparedBy)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cmdGenerateQuote)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.dtpQuoteDate)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(303, 183)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Quote Data"
        '
        'txtQuoteRevisionLevel
        '
        Me.txtQuoteRevisionLevel.AcceptsTab = True
        Me.txtQuoteRevisionLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteRevisionLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuoteRevisionLevel.Location = New System.Drawing.Point(214, 48)
        Me.txtQuoteRevisionLevel.MaxLength = 3
        Me.txtQuoteRevisionLevel.Name = "txtQuoteRevisionLevel"
        Me.txtQuoteRevisionLevel.Size = New System.Drawing.Size(81, 20)
        Me.txtQuoteRevisionLevel.TabIndex = 1
        Me.txtQuoteRevisionLevel.TabStop = False
        Me.txtQuoteRevisionLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(13, 75)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(129, 13)
        Me.Label79.TabIndex = 26
        Me.Label79.Text = "Reference Quote Number"
        '
        'txtReferenceQuoteNumber
        '
        Me.txtReferenceQuoteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceQuoteNumber.Location = New System.Drawing.Point(146, 74)
        Me.txtReferenceQuoteNumber.Margin = New System.Windows.Forms.Padding(3)
        Me.txtReferenceQuoteNumber.Name = "txtReferenceQuoteNumber"
        Me.txtReferenceQuoteNumber.Size = New System.Drawing.Size(149, 21)
        Me.txtReferenceQuoteNumber.TabIndex = 25
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DisplayMember = "QuoteID"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(146, 101)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(149, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Division"
        '
        'gpxPartInfo
        '
        Me.gpxPartInfo.BackColor = System.Drawing.SystemColors.Control
        Me.gpxPartInfo.Controls.Add(Me.Label13)
        Me.gpxPartInfo.Controls.Add(Me.txtPartSize)
        Me.gpxPartInfo.Controls.Add(Me.Label4)
        Me.gpxPartInfo.Controls.Add(Me.txtTFPPartNo)
        Me.gpxPartInfo.Controls.Add(Me.Label3)
        Me.gpxPartInfo.Controls.Add(Me.txtPartDescription)
        Me.gpxPartInfo.Controls.Add(Me.Label2)
        Me.gpxPartInfo.Controls.Add(Me.txtCustPartNo)
        Me.gpxPartInfo.Location = New System.Drawing.Point(2, 3)
        Me.gpxPartInfo.Name = "gpxPartInfo"
        Me.gpxPartInfo.Size = New System.Drawing.Size(303, 240)
        Me.gpxPartInfo.TabIndex = 26
        Me.gpxPartInfo.TabStop = False
        Me.gpxPartInfo.Text = "General Part Information"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 192)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Part Size"
        '
        'txtPartSize
        '
        Me.txtPartSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartSize.Location = New System.Drawing.Point(11, 208)
        Me.txtPartSize.MaxLength = 100
        Me.txtPartSize.Name = "txtPartSize"
        Me.txtPartSize.Size = New System.Drawing.Size(272, 20)
        Me.txtPartSize.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "TFP Part No. (if any)"
        '
        'txtTFPPartNo
        '
        Me.txtTFPPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTFPPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTFPPartNo.Location = New System.Drawing.Point(11, 80)
        Me.txtTFPPartNo.MaxLength = 50
        Me.txtTFPPartNo.Name = "txtTFPPartNo"
        Me.txtTFPPartNo.Size = New System.Drawing.Size(274, 20)
        Me.txtTFPPartNo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Part Description"
        '
        'txtPartDescription
        '
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartDescription.Location = New System.Drawing.Point(11, 129)
        Me.txtPartDescription.MaxLength = 250
        Me.txtPartDescription.Multiline = True
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.Size = New System.Drawing.Size(272, 53)
        Me.txtPartDescription.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer Part No."
        '
        'txtCustPartNo
        '
        Me.txtCustPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustPartNo.Location = New System.Drawing.Point(11, 35)
        Me.txtCustPartNo.MaxLength = 50
        Me.txtCustPartNo.Name = "txtCustPartNo"
        Me.txtCustPartNo.Size = New System.Drawing.Size(270, 20)
        Me.txtCustPartNo.TabIndex = 1
        '
        'tabctrl
        '
        Me.tabctrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tabctrl.Controls.Add(Me.TabPage1)
        Me.tabctrl.Controls.Add(Me.TabPage8)
        Me.tabctrl.Controls.Add(Me.TabPage10)
        Me.tabctrl.Controls.Add(Me.tabQC)
        Me.tabctrl.Controls.Add(Me.tabMarkup)
        Me.tabctrl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tabctrl.ItemSize = New System.Drawing.Size(19, 30)
        Me.tabctrl.Location = New System.Drawing.Point(321, 27)
        Me.tabctrl.Multiline = True
        Me.tabctrl.Name = "tabctrl"
        Me.tabctrl.SelectedIndex = 0
        Me.tabctrl.Size = New System.Drawing.Size(421, 792)
        Me.tabctrl.TabIndex = 8
        Me.tabctrl.Tag = ""
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.gpxHeader)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(413, 754)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = ""
        Me.TabPage1.Text = "Primary Machining"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.nbrHaasMiniMill)
        Me.GroupBox7.Controls.Add(Me.Label74)
        Me.GroupBox7.Controls.Add(Me.nbrHaasMill)
        Me.GroupBox7.Controls.Add(Me.Label70)
        Me.GroupBox7.Controls.Add(Me.nbrBarFeed)
        Me.GroupBox7.Controls.Add(Me.Label69)
        Me.GroupBox7.Controls.Add(Me.nbrTapping)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.nbrGrinding)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Controls.Add(Me.nbrMazakMill)
        Me.GroupBox7.Controls.Add(Me.Label27)
        Me.GroupBox7.Controls.Add(Me.nbrMazakLathe)
        Me.GroupBox7.Controls.Add(Me.Label28)
        Me.GroupBox7.Controls.Add(Me.nbrLatheWork)
        Me.GroupBox7.Controls.Add(Me.Label29)
        Me.GroupBox7.Controls.Add(Me.nbrShotPeen)
        Me.GroupBox7.Controls.Add(Me.Label30)
        Me.GroupBox7.Controls.Add(Me.nbrCounterSink)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Controls.Add(Me.nbrDrilling)
        Me.GroupBox7.Controls.Add(Me.Label32)
        Me.GroupBox7.Location = New System.Drawing.Point(223, 306)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(182, 317)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Select Miscellaneous Machining"
        '
        'nbrHaasMiniMill
        '
        Me.nbrHaasMiniMill.Location = New System.Drawing.Point(115, 286)
        Me.nbrHaasMiniMill.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrHaasMiniMill.Name = "nbrHaasMiniMill"
        Me.nbrHaasMiniMill.Size = New System.Drawing.Size(43, 20)
        Me.nbrHaasMiniMill.TabIndex = 66
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(27, 288)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(72, 13)
        Me.Label74.TabIndex = 65
        Me.Label74.Text = "Haas Mini Mill"
        '
        'nbrHaasMill
        '
        Me.nbrHaasMill.Location = New System.Drawing.Point(115, 260)
        Me.nbrHaasMill.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrHaasMill.Name = "nbrHaasMill"
        Me.nbrHaasMill.Size = New System.Drawing.Size(43, 20)
        Me.nbrHaasMill.TabIndex = 64
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(27, 262)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(50, 13)
        Me.Label70.TabIndex = 63
        Me.Label70.Text = "Haas Mill"
        '
        'nbrBarFeed
        '
        Me.nbrBarFeed.Location = New System.Drawing.Point(115, 234)
        Me.nbrBarFeed.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrBarFeed.Name = "nbrBarFeed"
        Me.nbrBarFeed.Size = New System.Drawing.Size(43, 20)
        Me.nbrBarFeed.TabIndex = 64
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(28, 236)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(50, 13)
        Me.Label69.TabIndex = 63
        Me.Label69.Text = "Bar Feed"
        '
        'nbrTapping
        '
        Me.nbrTapping.Location = New System.Drawing.Point(115, 208)
        Me.nbrTapping.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrTapping.Name = "nbrTapping"
        Me.nbrTapping.Size = New System.Drawing.Size(43, 20)
        Me.nbrTapping.TabIndex = 62
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(28, 210)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 13)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "Tapping"
        '
        'nbrGrinding
        '
        Me.nbrGrinding.Location = New System.Drawing.Point(115, 182)
        Me.nbrGrinding.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrGrinding.Name = "nbrGrinding"
        Me.nbrGrinding.Size = New System.Drawing.Size(43, 20)
        Me.nbrGrinding.TabIndex = 60
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(28, 184)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 13)
        Me.Label26.TabIndex = 59
        Me.Label26.Text = "Grinding"
        '
        'nbrMazakMill
        '
        Me.nbrMazakMill.Location = New System.Drawing.Point(115, 156)
        Me.nbrMazakMill.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrMazakMill.Name = "nbrMazakMill"
        Me.nbrMazakMill.Size = New System.Drawing.Size(43, 20)
        Me.nbrMazakMill.TabIndex = 58
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(28, 158)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(57, 13)
        Me.Label27.TabIndex = 57
        Me.Label27.Text = "Mazak Mill"
        '
        'nbrMazakLathe
        '
        Me.nbrMazakLathe.Location = New System.Drawing.Point(115, 130)
        Me.nbrMazakLathe.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrMazakLathe.Name = "nbrMazakLathe"
        Me.nbrMazakLathe.Size = New System.Drawing.Size(43, 20)
        Me.nbrMazakLathe.TabIndex = 56
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(26, 132)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(69, 13)
        Me.Label28.TabIndex = 55
        Me.Label28.Text = "Mazak Lathe"
        '
        'nbrLatheWork
        '
        Me.nbrLatheWork.Location = New System.Drawing.Point(115, 104)
        Me.nbrLatheWork.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrLatheWork.Name = "nbrLatheWork"
        Me.nbrLatheWork.Size = New System.Drawing.Size(43, 20)
        Me.nbrLatheWork.TabIndex = 54
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(26, 104)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(63, 13)
        Me.Label29.TabIndex = 53
        Me.Label29.Text = "Lathe Work"
        '
        'nbrShotPeen
        '
        Me.nbrShotPeen.Location = New System.Drawing.Point(115, 78)
        Me.nbrShotPeen.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrShotPeen.Name = "nbrShotPeen"
        Me.nbrShotPeen.Size = New System.Drawing.Size(43, 20)
        Me.nbrShotPeen.TabIndex = 52
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(26, 80)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(57, 13)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Shot Peen"
        '
        'nbrCounterSink
        '
        Me.nbrCounterSink.Location = New System.Drawing.Point(115, 52)
        Me.nbrCounterSink.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrCounterSink.Name = "nbrCounterSink"
        Me.nbrCounterSink.Size = New System.Drawing.Size(43, 20)
        Me.nbrCounterSink.TabIndex = 50
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(26, 54)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(68, 13)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "Counter Sink"
        '
        'nbrDrilling
        '
        Me.nbrDrilling.Location = New System.Drawing.Point(115, 26)
        Me.nbrDrilling.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrDrilling.Name = "nbrDrilling"
        Me.nbrDrilling.Size = New System.Drawing.Size(43, 20)
        Me.nbrDrilling.TabIndex = 48
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(26, 28)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(38, 13)
        Me.Label32.TabIndex = 47
        Me.Label32.Text = "Drilling"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.nbrFlatRoll)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.nbrBoltMaker)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.nbrReed)
        Me.GroupBox6.Controls.Add(Me.Label35)
        Me.GroupBox6.Controls.Add(Me.nbrHandRollNo50)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.nbrHandRoll)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.nbrNo40)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.nbrNo360H60)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.nbrNo20H20)
        Me.GroupBox6.Controls.Add(Me.Label40)
        Me.GroupBox6.Controls.Add(Me.nbrNo10Slow)
        Me.GroupBox6.Controls.Add(Me.Label41)
        Me.GroupBox6.Location = New System.Drawing.Point(16, 306)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(179, 317)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Select Rollers"
        '
        'nbrFlatRoll
        '
        Me.nbrFlatRoll.Location = New System.Drawing.Point(111, 232)
        Me.nbrFlatRoll.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrFlatRoll.Name = "nbrFlatRoll"
        Me.nbrFlatRoll.Size = New System.Drawing.Size(43, 20)
        Me.nbrFlatRoll.TabIndex = 66
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(14, 234)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(45, 13)
        Me.Label33.TabIndex = 65
        Me.Label33.Text = "Flat Roll"
        '
        'nbrBoltMaker
        '
        Me.nbrBoltMaker.Location = New System.Drawing.Point(111, 206)
        Me.nbrBoltMaker.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrBoltMaker.Name = "nbrBoltMaker"
        Me.nbrBoltMaker.Size = New System.Drawing.Size(43, 20)
        Me.nbrBoltMaker.TabIndex = 64
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(14, 208)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(58, 13)
        Me.Label34.TabIndex = 63
        Me.Label34.Text = "Bolt Maker"
        '
        'nbrReed
        '
        Me.nbrReed.Location = New System.Drawing.Point(111, 180)
        Me.nbrReed.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrReed.Name = "nbrReed"
        Me.nbrReed.Size = New System.Drawing.Size(43, 20)
        Me.nbrReed.TabIndex = 62
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(14, 182)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(33, 13)
        Me.Label35.TabIndex = 61
        Me.Label35.Text = "Reed"
        '
        'nbrHandRollNo50
        '
        Me.nbrHandRollNo50.Location = New System.Drawing.Point(111, 154)
        Me.nbrHandRollNo50.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrHandRollNo50.Name = "nbrHandRollNo50"
        Me.nbrHandRollNo50.Size = New System.Drawing.Size(43, 20)
        Me.nbrHandRollNo50.TabIndex = 60
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(14, 156)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(89, 13)
        Me.Label36.TabIndex = 59
        Me.Label36.Text = "Hand Roll No. 50"
        '
        'nbrHandRoll
        '
        Me.nbrHandRoll.Location = New System.Drawing.Point(111, 128)
        Me.nbrHandRoll.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrHandRoll.Name = "nbrHandRoll"
        Me.nbrHandRoll.Size = New System.Drawing.Size(43, 20)
        Me.nbrHandRoll.TabIndex = 58
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(14, 130)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(54, 13)
        Me.Label37.TabIndex = 57
        Me.Label37.Text = "Hand Roll"
        '
        'nbrNo40
        '
        Me.nbrNo40.Location = New System.Drawing.Point(111, 102)
        Me.nbrNo40.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrNo40.Name = "nbrNo40"
        Me.nbrNo40.Size = New System.Drawing.Size(43, 20)
        Me.nbrNo40.TabIndex = 56
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(14, 102)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(39, 13)
        Me.Label38.TabIndex = 55
        Me.Label38.Text = "No. 40"
        '
        'nbrNo360H60
        '
        Me.nbrNo360H60.Location = New System.Drawing.Point(111, 76)
        Me.nbrNo360H60.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrNo360H60.Name = "nbrNo360H60"
        Me.nbrNo360H60.Size = New System.Drawing.Size(43, 20)
        Me.nbrNo360H60.TabIndex = 54
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(14, 78)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(68, 13)
        Me.Label39.TabIndex = 53
        Me.Label39.Text = "No. 360 H60"
        '
        'nbrNo20H20
        '
        Me.nbrNo20H20.Location = New System.Drawing.Point(111, 50)
        Me.nbrNo20H20.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrNo20H20.Name = "nbrNo20H20"
        Me.nbrNo20H20.Size = New System.Drawing.Size(43, 20)
        Me.nbrNo20H20.TabIndex = 52
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(14, 52)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(62, 13)
        Me.Label40.TabIndex = 51
        Me.Label40.Text = "No. 20 H20"
        '
        'nbrNo10Slow
        '
        Me.nbrNo10Slow.Location = New System.Drawing.Point(111, 24)
        Me.nbrNo10Slow.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrNo10Slow.Name = "nbrNo10Slow"
        Me.nbrNo10Slow.Size = New System.Drawing.Size(43, 20)
        Me.nbrNo10Slow.TabIndex = 50
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(14, 26)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(65, 13)
        Me.Label41.TabIndex = 49
        Me.Label41.Text = "No. 10 Slow"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.nbrHotFormer)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.nbrCenterless)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.nbrPunchPress)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.nbrShave)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.nbrHandSlot)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.nbrSlot)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.nbrThreadCut)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.nbrPoint)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.nbrTrim)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.nbrExtrude)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(223, 17)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(182, 283)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Select Secondary Operations"
        '
        'nbrHotFormer
        '
        Me.nbrHotFormer.Location = New System.Drawing.Point(115, 253)
        Me.nbrHotFormer.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrHotFormer.Name = "nbrHotFormer"
        Me.nbrHotFormer.Size = New System.Drawing.Size(43, 20)
        Me.nbrHotFormer.TabIndex = 50
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(27, 255)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(59, 13)
        Me.Label24.TabIndex = 49
        Me.Label24.Text = "Hot Former"
        '
        'nbrCenterless
        '
        Me.nbrCenterless.Location = New System.Drawing.Point(115, 227)
        Me.nbrCenterless.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrCenterless.Name = "nbrCenterless"
        Me.nbrCenterless.Size = New System.Drawing.Size(43, 20)
        Me.nbrCenterless.TabIndex = 48
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(27, 229)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 47
        Me.Label23.Text = "Centerless"
        '
        'nbrPunchPress
        '
        Me.nbrPunchPress.Location = New System.Drawing.Point(115, 201)
        Me.nbrPunchPress.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrPunchPress.Name = "nbrPunchPress"
        Me.nbrPunchPress.Size = New System.Drawing.Size(43, 20)
        Me.nbrPunchPress.TabIndex = 46
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(27, 203)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Punch Press"
        '
        'nbrShave
        '
        Me.nbrShave.Location = New System.Drawing.Point(115, 175)
        Me.nbrShave.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrShave.Name = "nbrShave"
        Me.nbrShave.Size = New System.Drawing.Size(43, 20)
        Me.nbrShave.TabIndex = 44
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(27, 177)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Shave"
        '
        'nbrHandSlot
        '
        Me.nbrHandSlot.Location = New System.Drawing.Point(115, 149)
        Me.nbrHandSlot.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrHandSlot.Name = "nbrHandSlot"
        Me.nbrHandSlot.Size = New System.Drawing.Size(43, 20)
        Me.nbrHandSlot.TabIndex = 42
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(27, 151)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Hand Slot"
        '
        'nbrSlot
        '
        Me.nbrSlot.Location = New System.Drawing.Point(115, 123)
        Me.nbrSlot.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrSlot.Name = "nbrSlot"
        Me.nbrSlot.Size = New System.Drawing.Size(43, 20)
        Me.nbrSlot.TabIndex = 40
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(27, 125)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 13)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Slot"
        '
        'nbrThreadCut
        '
        Me.nbrThreadCut.Location = New System.Drawing.Point(115, 97)
        Me.nbrThreadCut.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrThreadCut.Name = "nbrThreadCut"
        Me.nbrThreadCut.Size = New System.Drawing.Size(43, 20)
        Me.nbrThreadCut.TabIndex = 38
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(27, 97)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Thread Cut"
        '
        'nbrPoint
        '
        Me.nbrPoint.Location = New System.Drawing.Point(115, 71)
        Me.nbrPoint.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrPoint.Name = "nbrPoint"
        Me.nbrPoint.Size = New System.Drawing.Size(43, 20)
        Me.nbrPoint.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(27, 73)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Point"
        '
        'nbrTrim
        '
        Me.nbrTrim.Location = New System.Drawing.Point(115, 45)
        Me.nbrTrim.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrTrim.Name = "nbrTrim"
        Me.nbrTrim.Size = New System.Drawing.Size(43, 20)
        Me.nbrTrim.TabIndex = 34
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Trim"
        '
        'nbrExtrude
        '
        Me.nbrExtrude.Location = New System.Drawing.Point(115, 19)
        Me.nbrExtrude.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrExtrude.Name = "nbrExtrude"
        Me.nbrExtrude.Size = New System.Drawing.Size(43, 20)
        Me.nbrExtrude.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Extrude"
        '
        'gpxHeader
        '
        Me.gpxHeader.Controls.Add(Me.rdoHeader9899)
        Me.gpxHeader.Controls.Add(Me.rdoHeader104109112)
        Me.gpxHeader.Controls.Add(Me.rdoHeader20)
        Me.gpxHeader.Controls.Add(Me.rdoHeader1819)
        Me.gpxHeader.Controls.Add(Me.rdoHeader1221)
        Me.gpxHeader.Controls.Add(Me.rdoHeader5)
        Me.gpxHeader.Controls.Add(Me.rdoHeader46917)
        Me.gpxHeader.Controls.Add(Me.rdoHeader137814)
        Me.gpxHeader.Controls.Add(Me.rdoHeader1011)
        Me.gpxHeader.Controls.Add(Me.rdoHeaderNone)
        Me.gpxHeader.Location = New System.Drawing.Point(16, 17)
        Me.gpxHeader.Name = "gpxHeader"
        Me.gpxHeader.Size = New System.Drawing.Size(179, 283)
        Me.gpxHeader.TabIndex = 0
        Me.gpxHeader.TabStop = False
        Me.gpxHeader.Text = "Select a Header"
        '
        'rdoHeader9899
        '
        Me.rdoHeader9899.AutoSize = True
        Me.rdoHeader9899.Location = New System.Drawing.Point(40, 240)
        Me.rdoHeader9899.Name = "rdoHeader9899"
        Me.rdoHeader9899.Size = New System.Drawing.Size(84, 17)
        Me.rdoHeader9899.TabIndex = 9
        Me.rdoHeader9899.Text = "Debar 98,99"
        Me.rdoHeader9899.UseVisualStyleBackColor = True
        '
        'rdoHeader104109112
        '
        Me.rdoHeader104109112.AutoSize = True
        Me.rdoHeader104109112.Location = New System.Drawing.Point(40, 217)
        Me.rdoHeader104109112.Name = "rdoHeader104109112"
        Me.rdoHeader104109112.Size = New System.Drawing.Size(84, 17)
        Me.rdoHeader104109112.TabIndex = 8
        Me.rdoHeader104109112.Text = "No. 109,112"
        Me.rdoHeader104109112.UseVisualStyleBackColor = True
        '
        'rdoHeader20
        '
        Me.rdoHeader20.AutoSize = True
        Me.rdoHeader20.Location = New System.Drawing.Point(40, 194)
        Me.rdoHeader20.Name = "rdoHeader20"
        Me.rdoHeader20.Size = New System.Drawing.Size(57, 17)
        Me.rdoHeader20.TabIndex = 7
        Me.rdoHeader20.Text = "No. 20"
        Me.rdoHeader20.UseVisualStyleBackColor = True
        '
        'rdoHeader1819
        '
        Me.rdoHeader1819.AutoSize = True
        Me.rdoHeader1819.Location = New System.Drawing.Point(40, 171)
        Me.rdoHeader1819.Name = "rdoHeader1819"
        Me.rdoHeader1819.Size = New System.Drawing.Size(87, 17)
        Me.rdoHeader1819.TabIndex = 6
        Me.rdoHeader1819.Text = "No. 18,19,22"
        Me.rdoHeader1819.UseVisualStyleBackColor = True
        '
        'rdoHeader1221
        '
        Me.rdoHeader1221.AutoSize = True
        Me.rdoHeader1221.Location = New System.Drawing.Point(40, 148)
        Me.rdoHeader1221.Name = "rdoHeader1221"
        Me.rdoHeader1221.Size = New System.Drawing.Size(72, 17)
        Me.rdoHeader1221.TabIndex = 5
        Me.rdoHeader1221.Text = "No. 12,21"
        Me.rdoHeader1221.UseVisualStyleBackColor = True
        '
        'rdoHeader5
        '
        Me.rdoHeader5.AutoSize = True
        Me.rdoHeader5.Location = New System.Drawing.Point(40, 125)
        Me.rdoHeader5.Name = "rdoHeader5"
        Me.rdoHeader5.Size = New System.Drawing.Size(51, 17)
        Me.rdoHeader5.TabIndex = 4
        Me.rdoHeader5.Text = "No. 5"
        Me.rdoHeader5.UseVisualStyleBackColor = True
        '
        'rdoHeader46917
        '
        Me.rdoHeader46917.AutoSize = True
        Me.rdoHeader46917.Location = New System.Drawing.Point(40, 102)
        Me.rdoHeader46917.Name = "rdoHeader46917"
        Me.rdoHeader46917.Size = New System.Drawing.Size(75, 17)
        Me.rdoHeader46917.TabIndex = 3
        Me.rdoHeader46917.Text = "No. 6,9,17"
        Me.rdoHeader46917.UseVisualStyleBackColor = True
        '
        'rdoHeader137814
        '
        Me.rdoHeader137814.AutoSize = True
        Me.rdoHeader137814.Location = New System.Drawing.Point(40, 79)
        Me.rdoHeader137814.Name = "rdoHeader137814"
        Me.rdoHeader137814.Size = New System.Drawing.Size(93, 17)
        Me.rdoHeader137814.TabIndex = 2
        Me.rdoHeader137814.Text = "No. 1,3,7,8,14"
        Me.rdoHeader137814.UseVisualStyleBackColor = True
        '
        'rdoHeader1011
        '
        Me.rdoHeader1011.AutoSize = True
        Me.rdoHeader1011.Location = New System.Drawing.Point(40, 56)
        Me.rdoHeader1011.Name = "rdoHeader1011"
        Me.rdoHeader1011.Size = New System.Drawing.Size(72, 17)
        Me.rdoHeader1011.TabIndex = 1
        Me.rdoHeader1011.Text = "No. 10,11"
        Me.rdoHeader1011.UseVisualStyleBackColor = True
        '
        'rdoHeaderNone
        '
        Me.rdoHeaderNone.AutoSize = True
        Me.rdoHeaderNone.Location = New System.Drawing.Point(40, 33)
        Me.rdoHeaderNone.Name = "rdoHeaderNone"
        Me.rdoHeaderNone.Size = New System.Drawing.Size(51, 17)
        Me.rdoHeaderNone.TabIndex = 0
        Me.rdoHeaderNone.Text = "None"
        Me.rdoHeaderNone.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage8.Controls.Add(Me.Label78)
        Me.TabPage8.Controls.Add(Me.txtOutsideOtherOperationTotal)
        Me.TabPage8.Controls.Add(Me.Label42)
        Me.TabPage8.Controls.Add(Me.txtOtherOperationTotal)
        Me.TabPage8.Controls.Add(Me.Label48)
        Me.TabPage8.Controls.Add(Me.cmdDeleteOtherOperation)
        Me.TabPage8.Controls.Add(Me.cmdAddOtherOperation)
        Me.TabPage8.Controls.Add(Me.dgvOtherOperations)
        Me.TabPage8.Controls.Add(Me.txtSetupCharge)
        Me.TabPage8.Controls.Add(Me.Label8)
        Me.TabPage8.Controls.Add(Me.txtToolingCharge)
        Me.TabPage8.Controls.Add(Me.Label15)
        Me.TabPage8.Controls.Add(Me.GroupBox9)
        Me.TabPage8.Controls.Add(Me.GroupBox8)
        Me.TabPage8.Location = New System.Drawing.Point(4, 34)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(413, 754)
        Me.TabPage8.TabIndex = 5
        Me.TabPage8.Text = "Weight Operations"
        '
        'Label78
        '
        Me.Label78.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label78.Location = New System.Drawing.Point(180, 633)
        Me.Label78.Margin = New System.Windows.Forms.Padding(3)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(89, 30)
        Me.Label78.TabIndex = 46
        Me.Label78.Text = "Outside Other Operation Total"
        '
        'txtOutsideOtherOperationTotal
        '
        Me.txtOutsideOtherOperationTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutsideOtherOperationTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutsideOtherOperationTotal.Location = New System.Drawing.Point(180, 664)
        Me.txtOutsideOtherOperationTotal.Margin = New System.Windows.Forms.Padding(3)
        Me.txtOutsideOtherOperationTotal.Name = "txtOutsideOtherOperationTotal"
        Me.txtOutsideOtherOperationTotal.Size = New System.Drawing.Size(89, 21)
        Me.txtOutsideOtherOperationTotal.TabIndex = 45
        Me.txtOutsideOtherOperationTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(7, 335)
        Me.Label42.Margin = New System.Windows.Forms.Padding(3)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(87, 13)
        Me.Label42.TabIndex = 44
        Me.Label42.Text = "Other Operations"
        '
        'txtOtherOperationTotal
        '
        Me.txtOtherOperationTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOtherOperationTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherOperationTotal.Location = New System.Drawing.Point(302, 664)
        Me.txtOtherOperationTotal.Margin = New System.Windows.Forms.Padding(3)
        Me.txtOtherOperationTotal.Name = "txtOtherOperationTotal"
        Me.txtOtherOperationTotal.Size = New System.Drawing.Size(98, 21)
        Me.txtOtherOperationTotal.TabIndex = 42
        Me.txtOtherOperationTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label48
        '
        Me.Label48.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label48.Location = New System.Drawing.Point(299, 632)
        Me.Label48.Margin = New System.Windows.Forms.Padding(3)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(92, 31)
        Me.Label48.TabIndex = 42
        Me.Label48.Text = "Inside Other Operation Total"
        '
        'cmdDeleteOtherOperation
        '
        Me.cmdDeleteOtherOperation.Location = New System.Drawing.Point(87, 645)
        Me.cmdDeleteOtherOperation.Name = "cmdDeleteOtherOperation"
        Me.cmdDeleteOtherOperation.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteOtherOperation.TabIndex = 43
        Me.cmdDeleteOtherOperation.Text = "Delete Selected"
        Me.cmdDeleteOtherOperation.UseVisualStyleBackColor = True
        '
        'cmdAddOtherOperation
        '
        Me.cmdAddOtherOperation.Location = New System.Drawing.Point(10, 645)
        Me.cmdAddOtherOperation.Name = "cmdAddOtherOperation"
        Me.cmdAddOtherOperation.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddOtherOperation.TabIndex = 42
        Me.cmdAddOtherOperation.Text = "Add Other Operation"
        Me.cmdAddOtherOperation.UseVisualStyleBackColor = True
        '
        'dgvOtherOperations
        '
        Me.dgvOtherOperations.AllowUserToAddRows = False
        Me.dgvOtherOperations.AllowUserToDeleteRows = False
        Me.dgvOtherOperations.AllowUserToResizeColumns = False
        Me.dgvOtherOperations.AllowUserToResizeRows = False
        Me.dgvOtherOperations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOtherOperations.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvOtherOperations.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherOperations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOtherOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOtherOperations.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOtherOperations.Location = New System.Drawing.Point(3, 364)
        Me.dgvOtherOperations.MultiSelect = False
        Me.dgvOtherOperations.Name = "dgvOtherOperations"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherOperations.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOtherOperations.RowHeadersVisible = False
        Me.dgvOtherOperations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvOtherOperations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvOtherOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOtherOperations.ShowCellErrors = False
        Me.dgvOtherOperations.ShowCellToolTips = False
        Me.dgvOtherOperations.ShowEditingIcon = False
        Me.dgvOtherOperations.ShowRowErrors = False
        Me.dgvOtherOperations.Size = New System.Drawing.Size(401, 253)
        Me.dgvOtherOperations.TabIndex = 9
        '
        'txtSetupCharge
        '
        Me.txtSetupCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSetupCharge.Location = New System.Drawing.Point(293, 301)
        Me.txtSetupCharge.Name = "txtSetupCharge"
        Me.txtSetupCharge.ReadOnly = True
        Me.txtSetupCharge.Size = New System.Drawing.Size(114, 20)
        Me.txtSetupCharge.TabIndex = 7
        Me.txtSetupCharge.Text = "0"
        Me.txtSetupCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(210, 285)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Enter Set-up Charge"
        '
        'txtToolingCharge
        '
        Me.txtToolingCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToolingCharge.Location = New System.Drawing.Point(87, 301)
        Me.txtToolingCharge.Name = "txtToolingCharge"
        Me.txtToolingCharge.Size = New System.Drawing.Size(103, 20)
        Me.txtToolingCharge.TabIndex = 5
        Me.txtToolingCharge.Text = "0"
        Me.txtToolingCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 283)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Enter Tooling Charge"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtMaterialCostPer)
        Me.GroupBox9.Controls.Add(Me.txtSpecialMaterialType)
        Me.GroupBox9.Controls.Add(Me.Label6)
        Me.GroupBox9.Controls.Add(Me.rdoSpecialMaterial)
        Me.GroupBox9.Controls.Add(Me.rdoStainless)
        Me.GroupBox9.Controls.Add(Me.rdoRebar)
        Me.GroupBox9.Controls.Add(Me.rdoAlloy)
        Me.GroupBox9.Controls.Add(Me.rdoC1038)
        Me.GroupBox9.Controls.Add(Me.rdoC1010ToC1018Annealed)
        Me.GroupBox9.Controls.Add(Me.rdoC1010ToC1018)
        Me.GroupBox9.Location = New System.Drawing.Point(207, 15)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(200, 258)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Raw Material"
        '
        'txtMaterialCostPer
        '
        Me.txtMaterialCostPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaterialCostPer.Location = New System.Drawing.Point(6, 216)
        Me.txtMaterialCostPer.Name = "txtMaterialCostPer"
        Me.txtMaterialCostPer.ReadOnly = True
        Me.txtMaterialCostPer.Size = New System.Drawing.Size(152, 20)
        Me.txtMaterialCostPer.TabIndex = 46
        Me.txtMaterialCostPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSpecialMaterialType
        '
        Me.txtSpecialMaterialType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialMaterialType.Location = New System.Drawing.Point(32, 167)
        Me.txtSpecialMaterialType.Name = "txtSpecialMaterialType"
        Me.txtSpecialMaterialType.ReadOnly = True
        Me.txtSpecialMaterialType.Size = New System.Drawing.Size(152, 20)
        Me.txtSpecialMaterialType.TabIndex = 45
        Me.txtSpecialMaterialType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Material Cost per CWT"
        '
        'rdoSpecialMaterial
        '
        Me.rdoSpecialMaterial.AutoSize = True
        Me.rdoSpecialMaterial.Location = New System.Drawing.Point(6, 139)
        Me.rdoSpecialMaterial.Name = "rdoSpecialMaterial"
        Me.rdoSpecialMaterial.Size = New System.Drawing.Size(100, 17)
        Me.rdoSpecialMaterial.TabIndex = 7
        Me.rdoSpecialMaterial.TabStop = True
        Me.rdoSpecialMaterial.Text = "Special Material"
        Me.rdoSpecialMaterial.UseVisualStyleBackColor = True
        '
        'rdoStainless
        '
        Me.rdoStainless.AutoSize = True
        Me.rdoStainless.Location = New System.Drawing.Point(6, 119)
        Me.rdoStainless.Name = "rdoStainless"
        Me.rdoStainless.Size = New System.Drawing.Size(67, 17)
        Me.rdoStainless.TabIndex = 6
        Me.rdoStainless.TabStop = True
        Me.rdoStainless.Text = "Stainless"
        Me.rdoStainless.UseVisualStyleBackColor = True
        '
        'rdoRebar
        '
        Me.rdoRebar.AutoSize = True
        Me.rdoRebar.Location = New System.Drawing.Point(6, 99)
        Me.rdoRebar.Name = "rdoRebar"
        Me.rdoRebar.Size = New System.Drawing.Size(54, 17)
        Me.rdoRebar.TabIndex = 5
        Me.rdoRebar.TabStop = True
        Me.rdoRebar.Text = "Rebar"
        Me.rdoRebar.UseVisualStyleBackColor = True
        '
        'rdoAlloy
        '
        Me.rdoAlloy.AutoSize = True
        Me.rdoAlloy.Location = New System.Drawing.Point(6, 79)
        Me.rdoAlloy.Name = "rdoAlloy"
        Me.rdoAlloy.Size = New System.Drawing.Size(47, 17)
        Me.rdoAlloy.TabIndex = 4
        Me.rdoAlloy.TabStop = True
        Me.rdoAlloy.Text = "Alloy"
        Me.rdoAlloy.UseVisualStyleBackColor = True
        '
        'rdoC1038
        '
        Me.rdoC1038.AutoSize = True
        Me.rdoC1038.Location = New System.Drawing.Point(6, 59)
        Me.rdoC1038.Name = "rdoC1038"
        Me.rdoC1038.Size = New System.Drawing.Size(56, 17)
        Me.rdoC1038.TabIndex = 3
        Me.rdoC1038.TabStop = True
        Me.rdoC1038.Text = "C1038"
        Me.rdoC1038.UseVisualStyleBackColor = True
        '
        'rdoC1010ToC1018Annealed
        '
        Me.rdoC1010ToC1018Annealed.AutoSize = True
        Me.rdoC1010ToC1018Annealed.Location = New System.Drawing.Point(6, 39)
        Me.rdoC1010ToC1018Annealed.Name = "rdoC1010ToC1018Annealed"
        Me.rdoC1010ToC1018Annealed.Size = New System.Drawing.Size(170, 17)
        Me.rdoC1010ToC1018Annealed.TabIndex = 2
        Me.rdoC1010ToC1018Annealed.TabStop = True
        Me.rdoC1010ToC1018Annealed.Text = "C1010A to C1018A (Annealed)"
        Me.rdoC1010ToC1018Annealed.UseVisualStyleBackColor = True
        '
        'rdoC1010ToC1018
        '
        Me.rdoC1010ToC1018.AutoSize = True
        Me.rdoC1010ToC1018.Location = New System.Drawing.Point(6, 19)
        Me.rdoC1010ToC1018.Name = "rdoC1010ToC1018"
        Me.rdoC1010ToC1018.Size = New System.Drawing.Size(105, 17)
        Me.rdoC1010ToC1018.TabIndex = 1
        Me.rdoC1010ToC1018.TabStop = True
        Me.rdoC1010ToC1018.Text = "C1010 to  C1018"
        Me.rdoC1010ToC1018.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkBake)
        Me.GroupBox8.Controls.Add(Me.chkNickelPlating)
        Me.GroupBox8.Controls.Add(Me.chkPicklePlate)
        Me.GroupBox8.Controls.Add(Me.chkPhosphateAndOil)
        Me.GroupBox8.Controls.Add(Me.chkOutsideHeatTreatOrPlating)
        Me.GroupBox8.Controls.Add(Me.chkCaseHardening)
        Me.GroupBox8.Controls.Add(Me.chkHeatTreat)
        Me.GroupBox8.Controls.Add(Me.chkZincPlating)
        Me.GroupBox8.Controls.Add(Me.chkAnneal)
        Me.GroupBox8.Controls.Add(Me.chkTumbleAndWash)
        Me.GroupBox8.Controls.Add(Me.chkWireCleaning)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 15)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(182, 258)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Weight Based Bulk Operations "
        '
        'chkBake
        '
        Me.chkBake.AutoSize = True
        Me.chkBake.Location = New System.Drawing.Point(20, 146)
        Me.chkBake.Name = "chkBake"
        Me.chkBake.Size = New System.Drawing.Size(51, 17)
        Me.chkBake.TabIndex = 10
        Me.chkBake.Text = "Bake"
        Me.chkBake.UseVisualStyleBackColor = True
        '
        'chkNickelPlating
        '
        Me.chkNickelPlating.AutoSize = True
        Me.chkNickelPlating.Location = New System.Drawing.Point(20, 125)
        Me.chkNickelPlating.Name = "chkNickelPlating"
        Me.chkNickelPlating.Size = New System.Drawing.Size(91, 17)
        Me.chkNickelPlating.TabIndex = 9
        Me.chkNickelPlating.Text = "Nickel Plating"
        Me.chkNickelPlating.UseVisualStyleBackColor = True
        '
        'chkPicklePlate
        '
        Me.chkPicklePlate.AutoSize = True
        Me.chkPicklePlate.Location = New System.Drawing.Point(20, 104)
        Me.chkPicklePlate.Name = "chkPicklePlate"
        Me.chkPicklePlate.Size = New System.Drawing.Size(90, 17)
        Me.chkPicklePlate.TabIndex = 8
        Me.chkPicklePlate.Text = "Pickle Plating"
        Me.chkPicklePlate.UseVisualStyleBackColor = True
        '
        'chkPhosphateAndOil
        '
        Me.chkPhosphateAndOil.AutoSize = True
        Me.chkPhosphateAndOil.Location = New System.Drawing.Point(20, 230)
        Me.chkPhosphateAndOil.Name = "chkPhosphateAndOil"
        Me.chkPhosphateAndOil.Size = New System.Drawing.Size(113, 17)
        Me.chkPhosphateAndOil.TabIndex = 7
        Me.chkPhosphateAndOil.Text = "Phosphate and Oil"
        Me.chkPhosphateAndOil.UseVisualStyleBackColor = True
        '
        'chkOutsideHeatTreatOrPlating
        '
        Me.chkOutsideHeatTreatOrPlating.AutoSize = True
        Me.chkOutsideHeatTreatOrPlating.Location = New System.Drawing.Point(20, 209)
        Me.chkOutsideHeatTreatOrPlating.Name = "chkOutsideHeatTreatOrPlating"
        Me.chkOutsideHeatTreatOrPlating.Size = New System.Drawing.Size(155, 17)
        Me.chkOutsideHeatTreatOrPlating.TabIndex = 6
        Me.chkOutsideHeatTreatOrPlating.Text = "Outside Heat Treat or Plate"
        Me.chkOutsideHeatTreatOrPlating.UseVisualStyleBackColor = True
        '
        'chkCaseHardening
        '
        Me.chkCaseHardening.AutoSize = True
        Me.chkCaseHardening.Location = New System.Drawing.Point(20, 188)
        Me.chkCaseHardening.Name = "chkCaseHardening"
        Me.chkCaseHardening.Size = New System.Drawing.Size(102, 17)
        Me.chkCaseHardening.TabIndex = 5
        Me.chkCaseHardening.Text = "Case Hardening"
        Me.chkCaseHardening.UseVisualStyleBackColor = True
        '
        'chkHeatTreat
        '
        Me.chkHeatTreat.AutoSize = True
        Me.chkHeatTreat.Location = New System.Drawing.Point(20, 167)
        Me.chkHeatTreat.Name = "chkHeatTreat"
        Me.chkHeatTreat.Size = New System.Drawing.Size(77, 17)
        Me.chkHeatTreat.TabIndex = 4
        Me.chkHeatTreat.Text = "Heat Treat"
        Me.chkHeatTreat.UseVisualStyleBackColor = True
        '
        'chkZincPlating
        '
        Me.chkZincPlating.AutoSize = True
        Me.chkZincPlating.Location = New System.Drawing.Point(20, 83)
        Me.chkZincPlating.Name = "chkZincPlating"
        Me.chkZincPlating.Size = New System.Drawing.Size(82, 17)
        Me.chkZincPlating.TabIndex = 3
        Me.chkZincPlating.Text = "Zinc Plating"
        Me.chkZincPlating.UseVisualStyleBackColor = True
        '
        'chkAnneal
        '
        Me.chkAnneal.AutoSize = True
        Me.chkAnneal.Location = New System.Drawing.Point(20, 62)
        Me.chkAnneal.Name = "chkAnneal"
        Me.chkAnneal.Size = New System.Drawing.Size(59, 17)
        Me.chkAnneal.TabIndex = 2
        Me.chkAnneal.Text = "Anneal"
        Me.chkAnneal.UseVisualStyleBackColor = True
        '
        'chkTumbleAndWash
        '
        Me.chkTumbleAndWash.AutoSize = True
        Me.chkTumbleAndWash.Location = New System.Drawing.Point(20, 41)
        Me.chkTumbleAndWash.Name = "chkTumbleAndWash"
        Me.chkTumbleAndWash.Size = New System.Drawing.Size(113, 17)
        Me.chkTumbleAndWash.TabIndex = 1
        Me.chkTumbleAndWash.Text = "Tumble and Wash"
        Me.chkTumbleAndWash.UseVisualStyleBackColor = True
        '
        'chkWireCleaning
        '
        Me.chkWireCleaning.AutoSize = True
        Me.chkWireCleaning.Location = New System.Drawing.Point(20, 20)
        Me.chkWireCleaning.Name = "chkWireCleaning"
        Me.chkWireCleaning.Size = New System.Drawing.Size(92, 17)
        Me.chkWireCleaning.TabIndex = 0
        Me.chkWireCleaning.Text = "Wire Cleaning"
        Me.chkWireCleaning.UseVisualStyleBackColor = True
        '
        'TabPage10
        '
        Me.TabPage10.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage10.Controls.Add(Me.cmdAddSegment)
        Me.TabPage10.Controls.Add(Me.txtFinishedWeight)
        Me.TabPage10.Controls.Add(Me.Label52)
        Me.TabPage10.Controls.Add(Me.txtScrapPercent)
        Me.TabPage10.Controls.Add(Me.Label77)
        Me.TabPage10.Controls.Add(Me.cmdDeleteSegment)
        Me.TabPage10.Controls.Add(Me.dgvSegments)
        Me.TabPage10.Controls.Add(Me.gpxDimensionalUnits)
        Me.TabPage10.Controls.Add(Me.gpxMaterialType)
        Me.TabPage10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage10.Location = New System.Drawing.Point(4, 34)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(413, 754)
        Me.TabPage10.TabIndex = 7
        Me.TabPage10.Text = "Weight Calculator"
        '
        'cmdAddSegment
        '
        Me.cmdAddSegment.Location = New System.Drawing.Point(25, 561)
        Me.cmdAddSegment.Name = "cmdAddSegment"
        Me.cmdAddSegment.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSegment.TabIndex = 7
        Me.cmdAddSegment.Text = "Add Segment"
        Me.cmdAddSegment.UseVisualStyleBackColor = True
        '
        'txtFinishedWeight
        '
        Me.txtFinishedWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFinishedWeight.Location = New System.Drawing.Point(306, 549)
        Me.txtFinishedWeight.MaxLength = 30
        Me.txtFinishedWeight.Name = "txtFinishedWeight"
        Me.txtFinishedWeight.ReadOnly = True
        Me.txtFinishedWeight.Size = New System.Drawing.Size(84, 20)
        Me.txtFinishedWeight.TabIndex = 44
        Me.txtFinishedWeight.TabStop = False
        Me.txtFinishedWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(214, 552)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(83, 13)
        Me.Label52.TabIndex = 45
        Me.Label52.Text = "Finished Weight"
        '
        'txtScrapPercent
        '
        Me.txtScrapPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScrapPercent.Location = New System.Drawing.Point(306, 588)
        Me.txtScrapPercent.MaxLength = 30
        Me.txtScrapPercent.Name = "txtScrapPercent"
        Me.txtScrapPercent.Size = New System.Drawing.Size(84, 20)
        Me.txtScrapPercent.TabIndex = 10
        Me.txtScrapPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(214, 591)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(75, 13)
        Me.Label77.TabIndex = 43
        Me.Label77.Text = "Scrap Percent"
        '
        'cmdDeleteSegment
        '
        Me.cmdDeleteSegment.Location = New System.Drawing.Point(102, 561)
        Me.cmdDeleteSegment.Name = "cmdDeleteSegment"
        Me.cmdDeleteSegment.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSegment.TabIndex = 9
        Me.cmdDeleteSegment.Text = "Delete Segment"
        Me.cmdDeleteSegment.UseVisualStyleBackColor = True
        '
        'dgvSegments
        '
        Me.dgvSegments.AllowUserToAddRows = False
        Me.dgvSegments.AllowUserToDeleteRows = False
        Me.dgvSegments.AllowUserToResizeColumns = False
        Me.dgvSegments.AllowUserToResizeRows = False
        Me.dgvSegments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSegments.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvSegments.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSegments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSegments.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSegments.Location = New System.Drawing.Point(6, 210)
        Me.dgvSegments.Name = "dgvSegments"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSegments.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSegments.RowHeadersVisible = False
        Me.dgvSegments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSegments.Size = New System.Drawing.Size(401, 318)
        Me.dgvSegments.TabIndex = 8
        '
        'gpxDimensionalUnits
        '
        Me.gpxDimensionalUnits.Controls.Add(Me.rdoMetric)
        Me.gpxDimensionalUnits.Controls.Add(Me.rdoStandard)
        Me.gpxDimensionalUnits.Location = New System.Drawing.Point(238, 65)
        Me.gpxDimensionalUnits.Name = "gpxDimensionalUnits"
        Me.gpxDimensionalUnits.Size = New System.Drawing.Size(114, 88)
        Me.gpxDimensionalUnits.TabIndex = 1
        Me.gpxDimensionalUnits.TabStop = False
        Me.gpxDimensionalUnits.Text = "Dimensional Units"
        '
        'rdoMetric
        '
        Me.rdoMetric.AutoSize = True
        Me.rdoMetric.Location = New System.Drawing.Point(25, 52)
        Me.rdoMetric.Name = "rdoMetric"
        Me.rdoMetric.Size = New System.Drawing.Size(54, 17)
        Me.rdoMetric.TabIndex = 1
        Me.rdoMetric.Text = "Metric"
        Me.rdoMetric.UseVisualStyleBackColor = True
        '
        'rdoStandard
        '
        Me.rdoStandard.AutoSize = True
        Me.rdoStandard.Checked = True
        Me.rdoStandard.Location = New System.Drawing.Point(25, 28)
        Me.rdoStandard.Name = "rdoStandard"
        Me.rdoStandard.Size = New System.Drawing.Size(68, 17)
        Me.rdoStandard.TabIndex = 0
        Me.rdoStandard.TabStop = True
        Me.rdoStandard.Text = "Standard"
        Me.rdoStandard.UseVisualStyleBackColor = True
        '
        'gpxMaterialType
        '
        Me.gpxMaterialType.Controls.Add(Me.rdoBronze)
        Me.gpxMaterialType.Controls.Add(Me.rdoNavalBrass)
        Me.gpxMaterialType.Controls.Add(Me.rdoFreeCutBrass)
        Me.gpxMaterialType.Controls.Add(Me.rdoCopper)
        Me.gpxMaterialType.Controls.Add(Me.rdoAluminum)
        Me.gpxMaterialType.Controls.Add(Me.rdoSteel)
        Me.gpxMaterialType.Location = New System.Drawing.Point(6, 6)
        Me.gpxMaterialType.Name = "gpxMaterialType"
        Me.gpxMaterialType.Size = New System.Drawing.Size(165, 194)
        Me.gpxMaterialType.TabIndex = 0
        Me.gpxMaterialType.TabStop = False
        Me.gpxMaterialType.Text = "Select Material Type"
        '
        'rdoBronze
        '
        Me.rdoBronze.AutoSize = True
        Me.rdoBronze.Location = New System.Drawing.Point(41, 139)
        Me.rdoBronze.Name = "rdoBronze"
        Me.rdoBronze.Size = New System.Drawing.Size(58, 17)
        Me.rdoBronze.TabIndex = 5
        Me.rdoBronze.Text = "Bronze"
        Me.rdoBronze.UseVisualStyleBackColor = True
        '
        'rdoNavalBrass
        '
        Me.rdoNavalBrass.AutoSize = True
        Me.rdoNavalBrass.Location = New System.Drawing.Point(41, 116)
        Me.rdoNavalBrass.Name = "rdoNavalBrass"
        Me.rdoNavalBrass.Size = New System.Drawing.Size(82, 17)
        Me.rdoNavalBrass.TabIndex = 4
        Me.rdoNavalBrass.Text = "Naval Brass"
        Me.rdoNavalBrass.UseVisualStyleBackColor = True
        '
        'rdoFreeCutBrass
        '
        Me.rdoFreeCutBrass.AutoSize = True
        Me.rdoFreeCutBrass.Location = New System.Drawing.Point(41, 93)
        Me.rdoFreeCutBrass.Name = "rdoFreeCutBrass"
        Me.rdoFreeCutBrass.Size = New System.Drawing.Size(94, 17)
        Me.rdoFreeCutBrass.TabIndex = 3
        Me.rdoFreeCutBrass.Text = "Free Cut Brass"
        Me.rdoFreeCutBrass.UseVisualStyleBackColor = True
        '
        'rdoCopper
        '
        Me.rdoCopper.AutoSize = True
        Me.rdoCopper.Location = New System.Drawing.Point(41, 70)
        Me.rdoCopper.Name = "rdoCopper"
        Me.rdoCopper.Size = New System.Drawing.Size(59, 17)
        Me.rdoCopper.TabIndex = 2
        Me.rdoCopper.Text = "Copper"
        Me.rdoCopper.UseVisualStyleBackColor = True
        '
        'rdoAluminum
        '
        Me.rdoAluminum.AutoSize = True
        Me.rdoAluminum.Location = New System.Drawing.Point(41, 47)
        Me.rdoAluminum.Name = "rdoAluminum"
        Me.rdoAluminum.Size = New System.Drawing.Size(70, 17)
        Me.rdoAluminum.TabIndex = 1
        Me.rdoAluminum.Text = "Aluminum"
        Me.rdoAluminum.UseVisualStyleBackColor = True
        '
        'rdoSteel
        '
        Me.rdoSteel.AutoSize = True
        Me.rdoSteel.Checked = True
        Me.rdoSteel.Location = New System.Drawing.Point(41, 24)
        Me.rdoSteel.Name = "rdoSteel"
        Me.rdoSteel.Size = New System.Drawing.Size(49, 17)
        Me.rdoSteel.TabIndex = 0
        Me.rdoSteel.TabStop = True
        Me.rdoSteel.Text = "Steel"
        Me.rdoSteel.UseVisualStyleBackColor = True
        '
        'tabQC
        '
        Me.tabQC.BackColor = System.Drawing.SystemColors.Control
        Me.tabQC.Controls.Add(Me.QCGroupbox6)
        Me.tabQC.Controls.Add(Me.QCGroupBox5)
        Me.tabQC.Controls.Add(Me.QCGroupBox4)
        Me.tabQC.Controls.Add(Me.QCGroupBox3)
        Me.tabQC.Location = New System.Drawing.Point(4, 34)
        Me.tabQC.Name = "tabQC"
        Me.tabQC.Padding = New System.Windows.Forms.Padding(3)
        Me.tabQC.Size = New System.Drawing.Size(413, 754)
        Me.tabQC.TabIndex = 11
        Me.tabQC.Text = "QC/QA"
        '
        'QCGroupbox6
        '
        Me.QCGroupbox6.Controls.Add(Me.chkOutsideHTCertification)
        Me.QCGroupbox6.Controls.Add(Me.nbrPPap)
        Me.QCGroupbox6.Controls.Add(Me.Label63)
        Me.QCGroupbox6.Controls.Add(Me.nbrISIR)
        Me.QCGroupbox6.Controls.Add(Me.Label62)
        Me.QCGroupbox6.Controls.Add(Me.nbrMagParticle)
        Me.QCGroupbox6.Controls.Add(Me.Label61)
        Me.QCGroupbox6.Controls.Add(Me.nbrPlating)
        Me.QCGroupbox6.Controls.Add(Me.Label60)
        Me.QCGroupbox6.Controls.Add(Me.nbrDimensional)
        Me.QCGroupbox6.Controls.Add(Me.Label59)
        Me.QCGroupbox6.Controls.Add(Me.nbrSPCRequired)
        Me.QCGroupbox6.Controls.Add(Me.Label58)
        Me.QCGroupbox6.Controls.Add(Me.nbrSamplesRequired)
        Me.QCGroupbox6.Controls.Add(Me.Label57)
        Me.QCGroupbox6.Controls.Add(Me.nbrCertificationRequired)
        Me.QCGroupbox6.Controls.Add(Me.Label56)
        Me.QCGroupbox6.Controls.Add(Me.nbrMillCertification)
        Me.QCGroupbox6.Controls.Add(Me.Label55)
        Me.QCGroupbox6.Controls.Add(Me.nbrChemistry)
        Me.QCGroupbox6.Controls.Add(Me.Label54)
        Me.QCGroupbox6.Controls.Add(Me.nbrNylonPatch)
        Me.QCGroupbox6.Controls.Add(Me.Label53)
        Me.QCGroupbox6.Controls.Add(Me.nbrCertificateOfCompliance)
        Me.QCGroupbox6.Controls.Add(Me.Label50)
        Me.QCGroupbox6.Location = New System.Drawing.Point(191, 15)
        Me.QCGroupbox6.Name = "QCGroupbox6"
        Me.QCGroupbox6.Size = New System.Drawing.Size(200, 372)
        Me.QCGroupbox6.TabIndex = 9
        Me.QCGroupbox6.TabStop = False
        Me.QCGroupbox6.Text = "Certifications"
        '
        'chkOutsideHTCertification
        '
        Me.chkOutsideHTCertification.AutoSize = True
        Me.chkOutsideHTCertification.Location = New System.Drawing.Point(16, 340)
        Me.chkOutsideHTCertification.Name = "chkOutsideHTCertification"
        Me.chkOutsideHTCertification.Size = New System.Drawing.Size(174, 17)
        Me.chkOutsideHTCertification.TabIndex = 57
        Me.chkOutsideHTCertification.Text = "Outside Heat Treat Certification"
        Me.chkOutsideHTCertification.UseVisualStyleBackColor = True
        '
        'nbrPPap
        '
        Me.nbrPPap.Location = New System.Drawing.Point(140, 311)
        Me.nbrPPap.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrPPap.Name = "nbrPPap"
        Me.nbrPPap.Size = New System.Drawing.Size(43, 20)
        Me.nbrPPap.TabIndex = 56
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(13, 313)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(36, 13)
        Me.Label63.TabIndex = 55
        Me.Label63.Text = "P-Pap"
        '
        'nbrISIR
        '
        Me.nbrISIR.Location = New System.Drawing.Point(140, 285)
        Me.nbrISIR.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrISIR.Name = "nbrISIR"
        Me.nbrISIR.Size = New System.Drawing.Size(43, 20)
        Me.nbrISIR.TabIndex = 54
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(13, 287)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(37, 13)
        Me.Label62.TabIndex = 53
        Me.Label62.Text = "I.S.I.R"
        '
        'nbrMagParticle
        '
        Me.nbrMagParticle.Location = New System.Drawing.Point(140, 259)
        Me.nbrMagParticle.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrMagParticle.Name = "nbrMagParticle"
        Me.nbrMagParticle.Size = New System.Drawing.Size(43, 20)
        Me.nbrMagParticle.TabIndex = 52
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(13, 261)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(66, 13)
        Me.Label61.TabIndex = 51
        Me.Label61.Text = "Mag Particle"
        '
        'nbrPlating
        '
        Me.nbrPlating.Location = New System.Drawing.Point(140, 233)
        Me.nbrPlating.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrPlating.Name = "nbrPlating"
        Me.nbrPlating.Size = New System.Drawing.Size(43, 20)
        Me.nbrPlating.TabIndex = 50
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(13, 235)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(39, 13)
        Me.Label60.TabIndex = 49
        Me.Label60.Text = "Plating"
        '
        'nbrDimensional
        '
        Me.nbrDimensional.Location = New System.Drawing.Point(140, 207)
        Me.nbrDimensional.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrDimensional.Name = "nbrDimensional"
        Me.nbrDimensional.Size = New System.Drawing.Size(43, 20)
        Me.nbrDimensional.TabIndex = 48
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(13, 209)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(64, 13)
        Me.Label59.TabIndex = 47
        Me.Label59.Text = "Dimensional"
        '
        'nbrSPCRequired
        '
        Me.nbrSPCRequired.Location = New System.Drawing.Point(140, 181)
        Me.nbrSPCRequired.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrSPCRequired.Name = "nbrSPCRequired"
        Me.nbrSPCRequired.Size = New System.Drawing.Size(43, 20)
        Me.nbrSPCRequired.TabIndex = 46
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(13, 183)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(83, 13)
        Me.Label58.TabIndex = 45
        Me.Label58.Text = "S.P.C. Required"
        '
        'nbrSamplesRequired
        '
        Me.nbrSamplesRequired.Location = New System.Drawing.Point(140, 155)
        Me.nbrSamplesRequired.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrSamplesRequired.Name = "nbrSamplesRequired"
        Me.nbrSamplesRequired.Size = New System.Drawing.Size(43, 20)
        Me.nbrSamplesRequired.TabIndex = 44
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(13, 157)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(93, 13)
        Me.Label57.TabIndex = 43
        Me.Label57.Text = "Samples Required"
        '
        'nbrCertificationRequired
        '
        Me.nbrCertificationRequired.Location = New System.Drawing.Point(140, 129)
        Me.nbrCertificationRequired.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrCertificationRequired.Name = "nbrCertificationRequired"
        Me.nbrCertificationRequired.Size = New System.Drawing.Size(43, 20)
        Me.nbrCertificationRequired.TabIndex = 42
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(13, 131)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(108, 13)
        Me.Label56.TabIndex = 41
        Me.Label56.Text = "Certification Required"
        '
        'nbrMillCertification
        '
        Me.nbrMillCertification.Location = New System.Drawing.Point(140, 103)
        Me.nbrMillCertification.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrMillCertification.Name = "nbrMillCertification"
        Me.nbrMillCertification.Size = New System.Drawing.Size(43, 20)
        Me.nbrMillCertification.TabIndex = 40
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(13, 105)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(80, 13)
        Me.Label55.TabIndex = 39
        Me.Label55.Text = "Mill Certification"
        '
        'nbrChemistry
        '
        Me.nbrChemistry.Location = New System.Drawing.Point(140, 77)
        Me.nbrChemistry.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrChemistry.Name = "nbrChemistry"
        Me.nbrChemistry.Size = New System.Drawing.Size(43, 20)
        Me.nbrChemistry.TabIndex = 38
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(13, 79)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(52, 13)
        Me.Label54.TabIndex = 37
        Me.Label54.Text = "Chemistry"
        '
        'nbrNylonPatch
        '
        Me.nbrNylonPatch.Location = New System.Drawing.Point(140, 51)
        Me.nbrNylonPatch.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrNylonPatch.Name = "nbrNylonPatch"
        Me.nbrNylonPatch.Size = New System.Drawing.Size(43, 20)
        Me.nbrNylonPatch.TabIndex = 36
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(13, 53)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(65, 13)
        Me.Label53.TabIndex = 35
        Me.Label53.Text = "Nylon Patch"
        '
        'nbrCertificateOfCompliance
        '
        Me.nbrCertificateOfCompliance.Location = New System.Drawing.Point(140, 24)
        Me.nbrCertificateOfCompliance.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrCertificateOfCompliance.Name = "nbrCertificateOfCompliance"
        Me.nbrCertificateOfCompliance.Size = New System.Drawing.Size(43, 20)
        Me.nbrCertificateOfCompliance.TabIndex = 34
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(13, 26)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(124, 13)
        Me.Label50.TabIndex = 33
        Me.Label50.Text = "Certificate of Compliance"
        '
        'QCGroupBox5
        '
        Me.QCGroupBox5.Controls.Add(Me.nbrFurnaceChartCopy)
        Me.QCGroupBox5.Controls.Add(Me.Label67)
        Me.QCGroupBox5.Controls.Add(Me.nbrMicroDecarb)
        Me.QCGroupBox5.Controls.Add(Me.Label66)
        Me.QCGroupBox5.Controls.Add(Me.nbrMicroCaseDepth)
        Me.QCGroupBox5.Controls.Add(Me.Label65)
        Me.QCGroupBox5.Controls.Add(Me.nbrSurfaceandCore)
        Me.QCGroupBox5.Controls.Add(Me.Label64)
        Me.QCGroupBox5.Location = New System.Drawing.Point(20, 269)
        Me.QCGroupBox5.Name = "QCGroupBox5"
        Me.QCGroupBox5.Size = New System.Drawing.Size(159, 142)
        Me.QCGroupBox5.TabIndex = 8
        Me.QCGroupBox5.TabStop = False
        Me.QCGroupBox5.Text = "Hardness Measurements"
        '
        'nbrFurnaceChartCopy
        '
        Me.nbrFurnaceChartCopy.Location = New System.Drawing.Point(109, 106)
        Me.nbrFurnaceChartCopy.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrFurnaceChartCopy.Name = "nbrFurnaceChartCopy"
        Me.nbrFurnaceChartCopy.Size = New System.Drawing.Size(43, 20)
        Me.nbrFurnaceChartCopy.TabIndex = 64
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(5, 108)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(101, 13)
        Me.Label67.TabIndex = 63
        Me.Label67.Text = "Furnace Chart Copy"
        '
        'nbrMicroDecarb
        '
        Me.nbrMicroDecarb.Location = New System.Drawing.Point(109, 80)
        Me.nbrMicroDecarb.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrMicroDecarb.Name = "nbrMicroDecarb"
        Me.nbrMicroDecarb.Size = New System.Drawing.Size(43, 20)
        Me.nbrMicroDecarb.TabIndex = 62
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(5, 82)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(71, 13)
        Me.Label66.TabIndex = 61
        Me.Label66.Text = "Micro Decarb"
        '
        'nbrMicroCaseDepth
        '
        Me.nbrMicroCaseDepth.Location = New System.Drawing.Point(109, 54)
        Me.nbrMicroCaseDepth.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrMicroCaseDepth.Name = "nbrMicroCaseDepth"
        Me.nbrMicroCaseDepth.Size = New System.Drawing.Size(43, 20)
        Me.nbrMicroCaseDepth.TabIndex = 60
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(5, 56)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(92, 13)
        Me.Label65.TabIndex = 59
        Me.Label65.Text = "Micro Case Depth"
        '
        'nbrSurfaceandCore
        '
        Me.nbrSurfaceandCore.Location = New System.Drawing.Point(109, 28)
        Me.nbrSurfaceandCore.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrSurfaceandCore.Name = "nbrSurfaceandCore"
        Me.nbrSurfaceandCore.Size = New System.Drawing.Size(43, 20)
        Me.nbrSurfaceandCore.TabIndex = 58
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(5, 30)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(90, 13)
        Me.Label64.TabIndex = 57
        Me.Label64.Text = "Surface and Core"
        '
        'QCGroupBox4
        '
        Me.QCGroupBox4.Controls.Add(Me.nbrTWDTensile)
        Me.QCGroupBox4.Controls.Add(Me.Label68)
        Me.QCGroupBox4.Controls.Add(Me.Label46)
        Me.QCGroupBox4.Controls.Add(Me.Label45)
        Me.QCGroupBox4.Controls.Add(Me.nbrAdditionalSpecimen)
        Me.QCGroupBox4.Controls.Add(Me.nbrWedgeBendShear)
        Me.QCGroupBox4.Controls.Add(Me.chk5SpecimenMax)
        Me.QCGroupBox4.Location = New System.Drawing.Point(20, 417)
        Me.QCGroupBox4.Name = "QCGroupBox4"
        Me.QCGroupBox4.Size = New System.Drawing.Size(159, 199)
        Me.QCGroupBox4.TabIndex = 7
        Me.QCGroupBox4.TabStop = False
        Me.QCGroupBox4.Text = "Tensile Proof Load and Ultimate"
        '
        'nbrTWDTensile
        '
        Me.nbrTWDTensile.Location = New System.Drawing.Point(106, 157)
        Me.nbrTWDTensile.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrTWDTensile.Name = "nbrTWDTensile"
        Me.nbrTWDTensile.Size = New System.Drawing.Size(43, 20)
        Me.nbrTWDTensile.TabIndex = 66
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(2, 159)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(85, 13)
        Me.Label68.TabIndex = 65
        Me.Label68.Text = "TruWeld Tensile"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(2, 108)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(101, 13)
        Me.Label46.TabIndex = 15
        Me.Label46.Text = "Wedge Bend Shear"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(2, 62)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(103, 13)
        Me.Label45.TabIndex = 14
        Me.Label45.Text = "Additional Specimen"
        '
        'nbrAdditionalSpecimen
        '
        Me.nbrAdditionalSpecimen.Location = New System.Drawing.Point(106, 60)
        Me.nbrAdditionalSpecimen.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrAdditionalSpecimen.Name = "nbrAdditionalSpecimen"
        Me.nbrAdditionalSpecimen.Size = New System.Drawing.Size(43, 20)
        Me.nbrAdditionalSpecimen.TabIndex = 13
        Me.nbrAdditionalSpecimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nbrWedgeBendShear
        '
        Me.nbrWedgeBendShear.Location = New System.Drawing.Point(106, 106)
        Me.nbrWedgeBendShear.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nbrWedgeBendShear.Name = "nbrWedgeBendShear"
        Me.nbrWedgeBendShear.Size = New System.Drawing.Size(43, 20)
        Me.nbrWedgeBendShear.TabIndex = 12
        Me.nbrWedgeBendShear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chk5SpecimenMax
        '
        Me.chk5SpecimenMax.AutoSize = True
        Me.chk5SpecimenMax.Location = New System.Drawing.Point(14, 42)
        Me.chk5SpecimenMax.Name = "chk5SpecimenMax"
        Me.chk5SpecimenMax.Size = New System.Drawing.Size(105, 17)
        Me.chk5SpecimenMax.TabIndex = 6
        Me.chk5SpecimenMax.Text = "5 Specimen Max"
        Me.chk5SpecimenMax.UseVisualStyleBackColor = True
        '
        'QCGroupBox3
        '
        Me.QCGroupBox3.Controls.Add(Me.Label1)
        Me.QCGroupBox3.Controls.Add(Me.nbrSaltSprayQuantity)
        Me.QCGroupBox3.Controls.Add(Me.rdoSaltSprayNone)
        Me.QCGroupBox3.Controls.Add(Me.Label44)
        Me.QCGroupBox3.Controls.Add(Me.nbrSaltSprayAdditionalHours)
        Me.QCGroupBox3.Controls.Add(Me.rdo168Hours)
        Me.QCGroupBox3.Controls.Add(Me.rdo120Hours)
        Me.QCGroupBox3.Controls.Add(Me.rdo96Hours)
        Me.QCGroupBox3.Controls.Add(Me.rdo72Hours)
        Me.QCGroupBox3.Controls.Add(Me.rdo48Hours)
        Me.QCGroupBox3.Controls.Add(Me.rdo24Hours)
        Me.QCGroupBox3.Location = New System.Drawing.Point(20, 15)
        Me.QCGroupBox3.Name = "QCGroupBox3"
        Me.QCGroupBox3.Size = New System.Drawing.Size(159, 248)
        Me.QCGroupBox3.TabIndex = 0
        Me.QCGroupBox3.TabStop = False
        Me.QCGroupBox3.Text = "Select Salt Spray Costs"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Quantity"
        '
        'nbrSaltSprayQuantity
        '
        Me.nbrSaltSprayQuantity.Location = New System.Drawing.Point(91, 181)
        Me.nbrSaltSprayQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrSaltSprayQuantity.Name = "nbrSaltSprayQuantity"
        Me.nbrSaltSprayQuantity.Size = New System.Drawing.Size(62, 20)
        Me.nbrSaltSprayQuantity.TabIndex = 8
        Me.nbrSaltSprayQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbrSaltSprayQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rdoSaltSprayNone
        '
        Me.rdoSaltSprayNone.AutoSize = True
        Me.rdoSaltSprayNone.Location = New System.Drawing.Point(37, 19)
        Me.rdoSaltSprayNone.Name = "rdoSaltSprayNone"
        Me.rdoSaltSprayNone.Size = New System.Drawing.Size(90, 17)
        Me.rdoSaltSprayNone.TabIndex = 10
        Me.rdoSaltSprayNone.TabStop = True
        Me.rdoSaltSprayNone.Text = "No Salt Spray"
        Me.rdoSaltSprayNone.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(6, 210)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(84, 13)
        Me.Label44.TabIndex = 9
        Me.Label44.Text = "Additional Hours"
        '
        'nbrSaltSprayAdditionalHours
        '
        Me.nbrSaltSprayAdditionalHours.Location = New System.Drawing.Point(91, 207)
        Me.nbrSaltSprayAdditionalHours.Name = "nbrSaltSprayAdditionalHours"
        Me.nbrSaltSprayAdditionalHours.Size = New System.Drawing.Size(62, 20)
        Me.nbrSaltSprayAdditionalHours.TabIndex = 9
        Me.nbrSaltSprayAdditionalHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rdo168Hours
        '
        Me.rdo168Hours.AutoSize = True
        Me.rdo168Hours.Location = New System.Drawing.Point(37, 157)
        Me.rdo168Hours.Name = "rdo168Hours"
        Me.rdo168Hours.Size = New System.Drawing.Size(74, 17)
        Me.rdo168Hours.TabIndex = 7
        Me.rdo168Hours.TabStop = True
        Me.rdo168Hours.Text = "168 Hours"
        Me.rdo168Hours.UseVisualStyleBackColor = True
        '
        'rdo120Hours
        '
        Me.rdo120Hours.AutoSize = True
        Me.rdo120Hours.Location = New System.Drawing.Point(37, 134)
        Me.rdo120Hours.Name = "rdo120Hours"
        Me.rdo120Hours.Size = New System.Drawing.Size(74, 17)
        Me.rdo120Hours.TabIndex = 4
        Me.rdo120Hours.TabStop = True
        Me.rdo120Hours.Text = "120 Hours"
        Me.rdo120Hours.UseVisualStyleBackColor = True
        '
        'rdo96Hours
        '
        Me.rdo96Hours.AutoSize = True
        Me.rdo96Hours.Location = New System.Drawing.Point(37, 111)
        Me.rdo96Hours.Name = "rdo96Hours"
        Me.rdo96Hours.Size = New System.Drawing.Size(68, 17)
        Me.rdo96Hours.TabIndex = 3
        Me.rdo96Hours.TabStop = True
        Me.rdo96Hours.Text = "96 Hours"
        Me.rdo96Hours.UseVisualStyleBackColor = True
        '
        'rdo72Hours
        '
        Me.rdo72Hours.AutoSize = True
        Me.rdo72Hours.Location = New System.Drawing.Point(37, 88)
        Me.rdo72Hours.Name = "rdo72Hours"
        Me.rdo72Hours.Size = New System.Drawing.Size(68, 17)
        Me.rdo72Hours.TabIndex = 2
        Me.rdo72Hours.TabStop = True
        Me.rdo72Hours.Text = "72 Hours"
        Me.rdo72Hours.UseVisualStyleBackColor = True
        '
        'rdo48Hours
        '
        Me.rdo48Hours.AutoSize = True
        Me.rdo48Hours.Location = New System.Drawing.Point(37, 65)
        Me.rdo48Hours.Name = "rdo48Hours"
        Me.rdo48Hours.Size = New System.Drawing.Size(68, 17)
        Me.rdo48Hours.TabIndex = 1
        Me.rdo48Hours.TabStop = True
        Me.rdo48Hours.Text = "48 Hours"
        Me.rdo48Hours.UseVisualStyleBackColor = True
        '
        'rdo24Hours
        '
        Me.rdo24Hours.AutoSize = True
        Me.rdo24Hours.Location = New System.Drawing.Point(37, 42)
        Me.rdo24Hours.Name = "rdo24Hours"
        Me.rdo24Hours.Size = New System.Drawing.Size(68, 17)
        Me.rdo24Hours.TabIndex = 0
        Me.rdo24Hours.TabStop = True
        Me.rdo24Hours.Text = "24 Hours"
        Me.rdo24Hours.UseVisualStyleBackColor = True
        '
        'tabMarkup
        '
        Me.tabMarkup.BackColor = System.Drawing.SystemColors.Control
        Me.tabMarkup.Controls.Add(Me.cmdDeleteSelectedMarkup)
        Me.tabMarkup.Controls.Add(Me.cmdAddMarkup)
        Me.tabMarkup.Controls.Add(Me.dgvMarkupQuotes)
        Me.tabMarkup.Controls.Add(Me.Label7)
        Me.tabMarkup.Location = New System.Drawing.Point(4, 34)
        Me.tabMarkup.Name = "tabMarkup"
        Me.tabMarkup.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMarkup.Size = New System.Drawing.Size(413, 754)
        Me.tabMarkup.TabIndex = 12
        Me.tabMarkup.Text = "Mark Up"
        '
        'cmdDeleteSelectedMarkup
        '
        Me.cmdDeleteSelectedMarkup.Location = New System.Drawing.Point(102, 424)
        Me.cmdDeleteSelectedMarkup.Name = "cmdDeleteSelectedMarkup"
        Me.cmdDeleteSelectedMarkup.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelectedMarkup.TabIndex = 76
        Me.cmdDeleteSelectedMarkup.Text = "Delete Markup"
        Me.cmdDeleteSelectedMarkup.UseVisualStyleBackColor = True
        '
        'cmdAddMarkup
        '
        Me.cmdAddMarkup.Location = New System.Drawing.Point(21, 424)
        Me.cmdAddMarkup.Name = "cmdAddMarkup"
        Me.cmdAddMarkup.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddMarkup.TabIndex = 42
        Me.cmdAddMarkup.Text = "Add Markup"
        Me.cmdAddMarkup.UseVisualStyleBackColor = True
        '
        'dgvMarkupQuotes
        '
        Me.dgvMarkupQuotes.AllowUserToAddRows = False
        Me.dgvMarkupQuotes.AllowUserToDeleteRows = False
        Me.dgvMarkupQuotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvMarkupQuotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgvMarkupQuotes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvMarkupQuotes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMarkupQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMarkupQuotes.ColumnHeadersVisible = False
        Me.dgvMarkupQuotes.Location = New System.Drawing.Point(3, 61)
        Me.dgvMarkupQuotes.Name = "dgvMarkupQuotes"
        Me.dgvMarkupQuotes.RowHeadersVisible = False
        Me.dgvMarkupQuotes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dgvMarkupQuotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMarkupQuotes.Size = New System.Drawing.Size(407, 343)
        Me.dgvMarkupQuotes.TabIndex = 75
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(126, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 42
        '
        'lblDeliveryRequirement
        '
        Me.lblDeliveryRequirement.AutoSize = True
        Me.lblDeliveryRequirement.Location = New System.Drawing.Point(18, 183)
        Me.lblDeliveryRequirement.Name = "lblDeliveryRequirement"
        Me.lblDeliveryRequirement.Size = New System.Drawing.Size(113, 13)
        Me.lblDeliveryRequirement.TabIndex = 41
        Me.lblDeliveryRequirement.Text = "Delivery Requirements"
        '
        'txtDeliveryRequirements
        '
        Me.txtDeliveryRequirements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeliveryRequirements.Location = New System.Drawing.Point(16, 199)
        Me.txtDeliveryRequirements.MaxLength = 50
        Me.txtDeliveryRequirements.Name = "txtDeliveryRequirements"
        Me.txtDeliveryRequirements.Size = New System.Drawing.Size(264, 20)
        Me.txtDeliveryRequirements.TabIndex = 40
        '
        'dgvEstimatedCost
        '
        Me.dgvEstimatedCost.AllowUserToAddRows = False
        Me.dgvEstimatedCost.AllowUserToDeleteRows = False
        Me.dgvEstimatedCost.AllowUserToResizeColumns = False
        Me.dgvEstimatedCost.AllowUserToResizeRows = False
        Me.dgvEstimatedCost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEstimatedCost.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvEstimatedCost.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvEstimatedCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEstimatedCost.ColumnHeadersVisible = False
        Me.dgvEstimatedCost.Location = New System.Drawing.Point(751, 27)
        Me.dgvEstimatedCost.MultiSelect = False
        Me.dgvEstimatedCost.Name = "dgvEstimatedCost"
        Me.dgvEstimatedCost.ReadOnly = True
        Me.dgvEstimatedCost.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvEstimatedCost.RowHeadersVisible = False
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvEstimatedCost.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvEstimatedCost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEstimatedCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEstimatedCost.Size = New System.Drawing.Size(274, 382)
        Me.dgvEstimatedCost.TabIndex = 28
        Me.dgvEstimatedCost.TabStop = False
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 779)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(805, 733)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(805, 779)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 13
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(882, 779)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 11
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 733)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'tabctrlPartNotes
        '
        Me.tabctrlPartNotes.Controls.Add(Me.tabPartInfo)
        Me.tabctrlPartNotes.Controls.Add(Me.tabNotesComments)
        Me.tabctrlPartNotes.Controls.Add(Me.InternalNotes)
        Me.tabctrlPartNotes.Location = New System.Drawing.Point(12, 552)
        Me.tabctrlPartNotes.Name = "tabctrlPartNotes"
        Me.tabctrlPartNotes.SelectedIndex = 0
        Me.tabctrlPartNotes.Size = New System.Drawing.Size(303, 269)
        Me.tabctrlPartNotes.TabIndex = 2
        '
        'tabPartInfo
        '
        Me.tabPartInfo.Controls.Add(Me.gpxPartInfo)
        Me.tabPartInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabPartInfo.Name = "tabPartInfo"
        Me.tabPartInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPartInfo.Size = New System.Drawing.Size(295, 243)
        Me.tabPartInfo.TabIndex = 0
        Me.tabPartInfo.Text = "Part Info"
        Me.tabPartInfo.UseVisualStyleBackColor = True
        '
        'tabNotesComments
        '
        Me.tabNotesComments.BackColor = System.Drawing.Color.Transparent
        Me.tabNotesComments.Controls.Add(Me.Label47)
        Me.tabNotesComments.Controls.Add(Me.txtNotes)
        Me.tabNotesComments.Controls.Add(Me.lblDeliveryRequirement)
        Me.tabNotesComments.Controls.Add(Me.txtDeliveryRequirements)
        Me.tabNotesComments.Location = New System.Drawing.Point(4, 22)
        Me.tabNotesComments.Name = "tabNotesComments"
        Me.tabNotesComments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNotesComments.Size = New System.Drawing.Size(295, 243)
        Me.tabNotesComments.TabIndex = 1
        Me.tabNotesComments.Text = "Comments / Delivery"
        Me.tabNotesComments.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(11, 15)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(98, 13)
        Me.Label47.TabIndex = 21
        Me.Label47.Text = "Notes / Comments:"
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Location = New System.Drawing.Point(12, 31)
        Me.txtNotes.MaxLength = 500
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(268, 126)
        Me.txtNotes.TabIndex = 0
        '
        'InternalNotes
        '
        Me.InternalNotes.BackColor = System.Drawing.Color.Transparent
        Me.InternalNotes.Controls.Add(Me.Label51)
        Me.InternalNotes.Controls.Add(Me.txtInternalNotes)
        Me.InternalNotes.Location = New System.Drawing.Point(4, 22)
        Me.InternalNotes.Name = "InternalNotes"
        Me.InternalNotes.Size = New System.Drawing.Size(295, 243)
        Me.InternalNotes.TabIndex = 2
        Me.InternalNotes.Text = "Internal Notes"
        Me.InternalNotes.UseVisualStyleBackColor = True
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(14, 22)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(76, 13)
        Me.Label51.TabIndex = 23
        Me.Label51.Text = "Internal Notes:"
        '
        'txtInternalNotes
        '
        Me.txtInternalNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInternalNotes.Location = New System.Drawing.Point(12, 39)
        Me.txtInternalNotes.MaxLength = 500
        Me.txtInternalNotes.Multiline = True
        Me.txtInternalNotes.Name = "txtInternalNotes"
        Me.txtInternalNotes.Size = New System.Drawing.Size(268, 185)
        Me.txtInternalNotes.TabIndex = 22
        '
        'cmdCreateEntries
        '
        Me.cmdCreateEntries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateEntries.ForeColor = System.Drawing.Color.Blue
        Me.cmdCreateEntries.Location = New System.Drawing.Point(184, 19)
        Me.cmdCreateEntries.Name = "cmdCreateEntries"
        Me.cmdCreateEntries.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateEntries.TabIndex = 10
        Me.cmdCreateEntries.Text = "Create Entries"
        Me.cmdCreateEntries.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.cmdCreateEntries)
        Me.GroupBox4.Location = New System.Drawing.Point(751, 654)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(276, 66)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Create Entries"
        '
        'Label49
        '
        Me.Label49.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label49.ForeColor = System.Drawing.Color.Blue
        Me.Label49.Location = New System.Drawing.Point(11, 19)
        Me.Label49.Margin = New System.Windows.Forms.Padding(3)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(167, 40)
        Me.Label49.TabIndex = 47
        Me.Label49.Text = "Creates FOX and Part entries. If the Customer is not in the system, this will add" & _
            " them."
        '
        'txtStartWeight
        '
        Me.txtStartWeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartWeight.Location = New System.Drawing.Point(864, 592)
        Me.txtStartWeight.Margin = New System.Windows.Forms.Padding(3)
        Me.txtStartWeight.Name = "txtStartWeight"
        Me.txtStartWeight.Size = New System.Drawing.Size(161, 23)
        Me.txtStartWeight.TabIndex = 42
        Me.txtStartWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label75
        '
        Me.Label75.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(756, 597)
        Me.Label75.Margin = New System.Windows.Forms.Padding(3)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(66, 13)
        Me.Label75.TabIndex = 41
        Me.Label75.Text = "Start Weight"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtScrapWeight
        '
        Me.txtScrapWeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScrapWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScrapWeight.Location = New System.Drawing.Point(864, 621)
        Me.txtScrapWeight.Margin = New System.Windows.Forms.Padding(3)
        Me.txtScrapWeight.Name = "txtScrapWeight"
        Me.txtScrapWeight.Size = New System.Drawing.Size(161, 23)
        Me.txtScrapWeight.TabIndex = 44
        Me.txtScrapWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label76
        '
        Me.Label76.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(756, 626)
        Me.Label76.Margin = New System.Windows.Forms.Padding(3)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(72, 13)
        Me.Label76.TabIndex = 43
        Me.Label76.Text = "Scrap Weight"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdDuplicateQuote
        '
        Me.cmdDuplicateQuote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDuplicateQuote.Location = New System.Drawing.Point(959, 733)
        Me.cmdDuplicateQuote.Name = "cmdDuplicateQuote"
        Me.cmdDuplicateQuote.Size = New System.Drawing.Size(71, 40)
        Me.cmdDuplicateQuote.TabIndex = 45
        Me.cmdDuplicateQuote.Text = "Duplicate Quote"
        Me.cmdDuplicateQuote.UseVisualStyleBackColor = True
        '
        'dgvShipTotalsOutsideOpQC
        '
        Me.dgvShipTotalsOutsideOpQC.AllowUserToAddRows = False
        Me.dgvShipTotalsOutsideOpQC.AllowUserToDeleteRows = False
        Me.dgvShipTotalsOutsideOpQC.AllowUserToResizeColumns = False
        Me.dgvShipTotalsOutsideOpQC.AllowUserToResizeRows = False
        Me.dgvShipTotalsOutsideOpQC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipTotalsOutsideOpQC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvShipTotalsOutsideOpQC.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvShipTotalsOutsideOpQC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipTotalsOutsideOpQC.ColumnHeadersVisible = False
        Me.dgvShipTotalsOutsideOpQC.Location = New System.Drawing.Point(751, 415)
        Me.dgvShipTotalsOutsideOpQC.MultiSelect = False
        Me.dgvShipTotalsOutsideOpQC.Name = "dgvShipTotalsOutsideOpQC"
        Me.dgvShipTotalsOutsideOpQC.ReadOnly = True
        Me.dgvShipTotalsOutsideOpQC.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvShipTotalsOutsideOpQC.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvShipTotalsOutsideOpQC.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvShipTotalsOutsideOpQC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvShipTotalsOutsideOpQC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShipTotalsOutsideOpQC.Size = New System.Drawing.Size(274, 160)
        Me.dgvShipTotalsOutsideOpQC.TabIndex = 46
        Me.dgvShipTotalsOutsideOpQC.TabStop = False
        '
        'TFPQuoteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvShipTotalsOutsideOpQC)
        Me.Controls.Add(Me.cmdDuplicateQuote)
        Me.Controls.Add(Me.txtScrapWeight)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.txtStartWeight)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.tabctrlPartNotes)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dgvEstimatedCost)
        Me.Controls.Add(Me.tabctrl)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1050, 750)
        Me.Name = "TFPQuoteForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Quote Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gpxPartInfo.ResumeLayout(False)
        Me.gpxPartInfo.PerformLayout()
        Me.tabctrl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.nbrHaasMiniMill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrHaasMill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrBarFeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrTapping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrGrinding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMazakMill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMazakLathe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrLatheWork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrShotPeen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrCounterSink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrDrilling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.nbrFlatRoll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrBoltMaker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrReed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrHandRollNo50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrHandRoll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrNo40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrNo360H60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrNo20H20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrNo10Slow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nbrHotFormer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrCenterless, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrPunchPress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrShave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrHandSlot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrSlot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrThreadCut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrTrim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrExtrude, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxHeader.ResumeLayout(False)
        Me.gpxHeader.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        CType(Me.dgvOtherOperations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.TabPage10.ResumeLayout(False)
        Me.TabPage10.PerformLayout()
        CType(Me.dgvSegments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxDimensionalUnits.ResumeLayout(False)
        Me.gpxDimensionalUnits.PerformLayout()
        Me.gpxMaterialType.ResumeLayout(False)
        Me.gpxMaterialType.PerformLayout()
        Me.tabQC.ResumeLayout(False)
        Me.QCGroupbox6.ResumeLayout(False)
        Me.QCGroupbox6.PerformLayout()
        CType(Me.nbrPPap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrISIR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMagParticle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrPlating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrDimensional, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrSPCRequired, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrSamplesRequired, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrCertificationRequired, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMillCertification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrChemistry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrNylonPatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrCertificateOfCompliance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QCGroupBox5.ResumeLayout(False)
        Me.QCGroupBox5.PerformLayout()
        CType(Me.nbrFurnaceChartCopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMicroDecarb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMicroCaseDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrSurfaceandCore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QCGroupBox4.ResumeLayout(False)
        Me.QCGroupBox4.PerformLayout()
        CType(Me.nbrTWDTensile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrAdditionalSpecimen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrWedgeBendShear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QCGroupBox3.ResumeLayout(False)
        Me.QCGroupBox3.PerformLayout()
        CType(Me.nbrSaltSprayQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrSaltSprayAdditionalHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMarkup.ResumeLayout(False)
        Me.tabMarkup.PerformLayout()
        CType(Me.dgvMarkupQuotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEstimatedCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabctrlPartNotes.ResumeLayout(False)
        Me.tabPartInfo.ResumeLayout(False)
        Me.tabNotesComments.ResumeLayout(False)
        Me.tabNotesComments.PerformLayout()
        Me.InternalNotes.ResumeLayout(False)
        Me.InternalNotes.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvShipTotalsOutsideOpQC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdGenerateQuote As System.Windows.Forms.Button
    Friend WithEvents dtpQuoteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboQuoteNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtPreparedBy As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents ciLabel9 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents ciLabel8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gpxPartInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPartSize As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTFPPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPartDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCustPartNo As System.Windows.Forms.TextBox
    Friend WithEvents tabctrl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents nbrSlot As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents nbrThreadCut As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents nbrPoint As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents nbrTrim As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents nbrExtrude As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gpxHeader As System.Windows.Forms.GroupBox
    Friend WithEvents rdoHeader9899 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader104109112 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader20 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader1819 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader1221 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader5 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader46917 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader137814 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeader1011 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHeaderNone As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents txtSetupCharge As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtToolingCharge As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rdoSpecialMaterial As System.Windows.Forms.RadioButton
    Friend WithEvents rdoStainless As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRebar As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAlloy As System.Windows.Forms.RadioButton
    Friend WithEvents rdoC1038 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoC1010ToC1018Annealed As System.Windows.Forms.RadioButton
    Friend WithEvents rdoC1010ToC1018 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPhosphateAndOil As System.Windows.Forms.CheckBox
    Friend WithEvents chkOutsideHeatTreatOrPlating As System.Windows.Forms.CheckBox
    Friend WithEvents chkCaseHardening As System.Windows.Forms.CheckBox
    Friend WithEvents chkHeatTreat As System.Windows.Forms.CheckBox
    Friend WithEvents chkZincPlating As System.Windows.Forms.CheckBox
    Friend WithEvents chkAnneal As System.Windows.Forms.CheckBox
    Friend WithEvents chkTumbleAndWash As System.Windows.Forms.CheckBox
    Friend WithEvents chkWireCleaning As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents gpxDimensionalUnits As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMetric As System.Windows.Forms.RadioButton
    Friend WithEvents rdoStandard As System.Windows.Forms.RadioButton
    Friend WithEvents gpxMaterialType As System.Windows.Forms.GroupBox
    Friend WithEvents rdoBronze As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNavalBrass As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFreeCutBrass As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCopper As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAluminum As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSteel As System.Windows.Forms.RadioButton
    Friend WithEvents tabQC As System.Windows.Forms.TabPage
    Friend WithEvents QCGroupbox6 As System.Windows.Forms.GroupBox
    Friend WithEvents QCGroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents QCGroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents nbrAdditionalSpecimen As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrWedgeBendShear As System.Windows.Forms.NumericUpDown
    Friend WithEvents chk5SpecimenMax As System.Windows.Forms.CheckBox
    Friend WithEvents QCGroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents nbrSaltSprayAdditionalHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents rdo168Hours As System.Windows.Forms.RadioButton
    Friend WithEvents rdo120Hours As System.Windows.Forms.RadioButton
    Friend WithEvents rdo96Hours As System.Windows.Forms.RadioButton
    Friend WithEvents rdo72Hours As System.Windows.Forms.RadioButton
    Friend WithEvents rdo48Hours As System.Windows.Forms.RadioButton
    Friend WithEvents rdo24Hours As System.Windows.Forms.RadioButton
    Friend WithEvents tabMarkup As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nbrHotFormer As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents nbrCenterless As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents nbrPunchPress As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents nbrShave As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents nbrHandSlot As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents nbrTapping As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents nbrGrinding As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents nbrMazakMill As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents nbrMazakLathe As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents nbrLatheWork As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents nbrShotPeen As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents nbrCounterSink As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents nbrDrilling As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents nbrFlatRoll As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents nbrBoltMaker As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents nbrReed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents nbrHandRollNo50 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents nbrHandRoll As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents nbrNo40 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents nbrNo360H60 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents nbrNo20H20 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents nbrNo10Slow As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents dgvEstimatedCost As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAddSegment As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPhoneExtension As System.Windows.Forms.TextBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents dgvMarkupQuotes As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAddMarkup As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteSelectedMarkup As System.Windows.Forms.Button
    Friend WithEvents dgvSegments As System.Windows.Forms.DataGridView
    Friend WithEvents cmdDeleteSegment As System.Windows.Forms.Button
    Friend WithEvents dgvOtherOperations As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAddOtherOperation As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteOtherOperation As System.Windows.Forms.Button
    Friend WithEvents txtOtherOperationTotal As System.Windows.Forms.Label
    Friend WithEvents lblDeliveryRequirement As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryRequirements As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents tabctrlPartNotes As System.Windows.Forms.TabControl
    Friend WithEvents tabPartInfo As System.Windows.Forms.TabPage
    Friend WithEvents tabNotesComments As System.Windows.Forms.TabPage
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents cmdCreateEntries As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialMaterialType As System.Windows.Forms.TextBox
    Friend WithEvents txtMaterialCostPer As System.Windows.Forms.TextBox
    Friend WithEvents nbrCertificateOfCompliance As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents nbrNylonPatch As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents nbrChemistry As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents nbrMillCertification As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents nbrCertificationRequired As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents nbrSamplesRequired As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents nbrSPCRequired As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents nbrDimensional As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents nbrPlating As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents nbrMagParticle As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents nbrISIR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents nbrPPap As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents nbrSurfaceandCore As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents nbrMicroCaseDepth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents nbrMicroDecarb As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents nbrFurnaceChartCopy As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents nbrTWDTensile As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents nbrHaasMill As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents nbrBarFeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents chkNickelPlating As System.Windows.Forms.CheckBox
    Friend WithEvents chkPicklePlate As System.Windows.Forms.CheckBox
    Friend WithEvents chkBake As System.Windows.Forms.CheckBox
    Friend WithEvents rdoSaltSprayNone As System.Windows.Forms.RadioButton
    Friend WithEvents cboRFQSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerInqueryNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents txtRepAgency As System.Windows.Forms.TextBox
    Friend WithEvents chkOutsideHTCertification As System.Windows.Forms.CheckBox
    Friend WithEvents txtStartWeight As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents txtScrapPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents txtScrapWeight As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nbrSaltSprayQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtFinishedWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cmdDuplicateQuote As System.Windows.Forms.Button
    Friend WithEvents nbrHaasMiniMill As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents dgvShipTotalsOutsideOpQC As System.Windows.Forms.DataGridView
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents txtOutsideOtherOperationTotal As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents txtReferenceQuoteNumber As System.Windows.Forms.Label
    Friend WithEvents InternalNotes As System.Windows.Forms.TabPage
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtInternalNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtQuoteRevisionLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtMobileNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label

End Class
