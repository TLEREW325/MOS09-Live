<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MillCertForm
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
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockCompositionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockMillCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewReceivingInspectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxMillCertData = New System.Windows.Forms.GroupBox
        Me.txtBOLNumber = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboMaterialOrigin = New System.Windows.Forms.ComboBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cmdGenerateHeatFileNumber = New System.Windows.Forms.Button
        Me.cboHeatFileNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblHeatFileNumber = New System.Windows.Forms.Label
        Me.cboSteelCarbon = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.dtpMillReceivingDate = New System.Windows.Forms.DateTimePicker
        Me.txtElongation = New System.Windows.Forms.TextBox
        Me.txtReductionOfArea = New System.Windows.Forms.TextBox
        Me.txtYield = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtUltimateTensile = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPoundsInHeat = New System.Windows.Forms.TextBox
        Me.txtCoilsInHeat = New System.Windows.Forms.TextBox
        Me.txtSteelPONumber = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpxChemicalMakeup = New System.Windows.Forms.GroupBox
        Me.HighMagnesium = New System.Windows.Forms.Label
        Me.LowMagnesium = New System.Windows.Forms.Label
        Me.lblMagnesium = New System.Windows.Forms.Label
        Me.txtMagnesium = New System.Windows.Forms.TextBox
        Me.HighTungsten = New System.Windows.Forms.Label
        Me.LowTungsten = New System.Windows.Forms.Label
        Me.lblTungsten = New System.Windows.Forms.Label
        Me.txtTungsten = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblColorCode = New System.Windows.Forms.Label
        Me.lblCEV = New System.Windows.Forms.Label
        Me.txtCEV = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.HighTin = New System.Windows.Forms.Label
        Me.LowTin = New System.Windows.Forms.Label
        Me.HighCopper = New System.Windows.Forms.Label
        Me.LowCopper = New System.Windows.Forms.Label
        Me.HighMolybdenum = New System.Windows.Forms.Label
        Me.LowMolybdenum = New System.Windows.Forms.Label
        Me.HighChromium = New System.Windows.Forms.Label
        Me.LowChromium = New System.Windows.Forms.Label
        Me.HighNickel = New System.Windows.Forms.Label
        Me.LowNickel = New System.Windows.Forms.Label
        Me.HighSilicon = New System.Windows.Forms.Label
        Me.LowSilicon = New System.Windows.Forms.Label
        Me.HighSulfur = New System.Windows.Forms.Label
        Me.LowSulfur = New System.Windows.Forms.Label
        Me.HighPhosporus = New System.Windows.Forms.Label
        Me.LowPhosporus = New System.Windows.Forms.Label
        Me.HighManganese = New System.Windows.Forms.Label
        Me.LowManganese = New System.Windows.Forms.Label
        Me.HighCarbon = New System.Windows.Forms.Label
        Me.LowCarbon = New System.Windows.Forms.Label
        Me.HighCobalt = New System.Windows.Forms.Label
        Me.LowCobalt = New System.Windows.Forms.Label
        Me.HighLead = New System.Windows.Forms.Label
        Me.LowLead = New System.Windows.Forms.Label
        Me.HighZinc = New System.Windows.Forms.Label
        Me.LowZinc = New System.Windows.Forms.Label
        Me.HighIron = New System.Windows.Forms.Label
        Me.LowIron = New System.Windows.Forms.Label
        Me.HighNiobium = New System.Windows.Forms.Label
        Me.LowNiobium = New System.Windows.Forms.Label
        Me.HighTitanium = New System.Windows.Forms.Label
        Me.LowTitanium = New System.Windows.Forms.Label
        Me.HighBoron = New System.Windows.Forms.Label
        Me.LowBoron = New System.Windows.Forms.Label
        Me.HighNitrogen = New System.Windows.Forms.Label
        Me.LowNitrogen = New System.Windows.Forms.Label
        Me.HighAluminum = New System.Windows.Forms.Label
        Me.LowAluminum = New System.Windows.Forms.Label
        Me.HighVanadium = New System.Windows.Forms.Label
        Me.LowVanadium = New System.Windows.Forms.Label
        Me.txtLead = New System.Windows.Forms.TextBox
        Me.lblLead = New System.Windows.Forms.Label
        Me.lblCobalt = New System.Windows.Forms.Label
        Me.txtIron = New System.Windows.Forms.TextBox
        Me.txtZinc = New System.Windows.Forms.TextBox
        Me.lblZinc = New System.Windows.Forms.Label
        Me.lblIron = New System.Windows.Forms.Label
        Me.txtCobalt = New System.Windows.Forms.TextBox
        Me.txtTitanium = New System.Windows.Forms.TextBox
        Me.lblTitanium = New System.Windows.Forms.Label
        Me.lblNiobium = New System.Windows.Forms.Label
        Me.txtNitrogen = New System.Windows.Forms.TextBox
        Me.txtAluminum = New System.Windows.Forms.TextBox
        Me.txtBoron = New System.Windows.Forms.TextBox
        Me.txtVanadium = New System.Windows.Forms.TextBox
        Me.txtTin = New System.Windows.Forms.TextBox
        Me.txtCopper = New System.Windows.Forms.TextBox
        Me.txtMolybdenum = New System.Windows.Forms.TextBox
        Me.txtChromium = New System.Windows.Forms.TextBox
        Me.lblBoron = New System.Windows.Forms.Label
        Me.lblNitrogen = New System.Windows.Forms.Label
        Me.lblVanadium = New System.Windows.Forms.Label
        Me.lblAluminum = New System.Windows.Forms.Label
        Me.lblTin = New System.Windows.Forms.Label
        Me.lblMolybdenum = New System.Windows.Forms.Label
        Me.lblCopper = New System.Windows.Forms.Label
        Me.txtNickel = New System.Windows.Forms.TextBox
        Me.txtNiobium = New System.Windows.Forms.TextBox
        Me.txtSilicon = New System.Windows.Forms.TextBox
        Me.txtSulfur = New System.Windows.Forms.TextBox
        Me.txtPhosphorus = New System.Windows.Forms.TextBox
        Me.txtManganese = New System.Windows.Forms.TextBox
        Me.txtCarbon = New System.Windows.Forms.TextBox
        Me.lblChromium = New System.Windows.Forms.Label
        Me.lblNickel = New System.Windows.Forms.Label
        Me.lblSulfur = New System.Windows.Forms.Label
        Me.lblSilicon = New System.Windows.Forms.Label
        Me.lblPhosporus = New System.Windows.Forms.Label
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.lblManganese = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdPullTestData = New System.Windows.Forms.Button
        Me.cmdFOXForm = New System.Windows.Forms.Button
        Me.cmdViewLotNumbers = New System.Windows.Forms.Button
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.Label38 = New System.Windows.Forms.Label
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpbxFinalize = New System.Windows.Forms.GroupBox
        Me.bgwkLoadChemicalCompounds = New System.ComponentModel.BackgroundWorker
        Me.gpxInspectionSheet = New System.Windows.Forms.GroupBox
        Me.lblFileCountMessage = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdSelectFile = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxMillCertData.SuspendLayout()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxChemicalMakeup.SuspendLayout()
        Me.grpbxFinalize.SuspendLayout()
        Me.gpxInspectionSheet.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(955, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 44
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(715, 773)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 41
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(795, 773)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 42
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(875, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 43
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1044, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDataToolStripMenuItem, Me.DeleteDataToolStripMenuItem, Me.ClearDataToolStripMenuItem, Me.PrintDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'DeleteDataToolStripMenuItem
        '
        Me.DeleteDataToolStripMenuItem.Name = "DeleteDataToolStripMenuItem"
        Me.DeleteDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.DeleteDataToolStripMenuItem.Text = "Delete Data"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'PrintDataToolStripMenuItem
        '
        Me.PrintDataToolStripMenuItem.Name = "PrintDataToolStripMenuItem"
        Me.PrintDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.PrintDataToolStripMenuItem.Text = "Print Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnLockCompositionToolStripMenuItem, Me.UnLockMillCertToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UnLockCompositionToolStripMenuItem
        '
        Me.UnLockCompositionToolStripMenuItem.Enabled = False
        Me.UnLockCompositionToolStripMenuItem.Name = "UnLockCompositionToolStripMenuItem"
        Me.UnLockCompositionToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.UnLockCompositionToolStripMenuItem.Text = "Un-Lock Chemical Composition"
        '
        'UnLockMillCertToolStripMenuItem
        '
        Me.UnLockMillCertToolStripMenuItem.Enabled = False
        Me.UnLockMillCertToolStripMenuItem.Name = "UnLockMillCertToolStripMenuItem"
        Me.UnLockMillCertToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.UnLockMillCertToolStripMenuItem.Text = "Un-Lock Mill Cert"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewReceivingInspectionToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ViewReceivingInspectionToolStripMenuItem
        '
        Me.ViewReceivingInspectionToolStripMenuItem.Name = "ViewReceivingInspectionToolStripMenuItem"
        Me.ViewReceivingInspectionToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ViewReceivingInspectionToolStripMenuItem.Text = "View Receiving Inspection"
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
        'gpxMillCertData
        '
        Me.gpxMillCertData.Controls.Add(Me.txtBOLNumber)
        Me.gpxMillCertData.Controls.Add(Me.Label16)
        Me.gpxMillCertData.Controls.Add(Me.cboMaterialOrigin)
        Me.gpxMillCertData.Controls.Add(Me.Label36)
        Me.gpxMillCertData.Controls.Add(Me.txtVendorName)
        Me.gpxMillCertData.Controls.Add(Me.cmdGenerateHeatFileNumber)
        Me.gpxMillCertData.Controls.Add(Me.cboHeatFileNumber)
        Me.gpxMillCertData.Controls.Add(Me.lblHeatFileNumber)
        Me.gpxMillCertData.Controls.Add(Me.cboSteelCarbon)
        Me.gpxMillCertData.Controls.Add(Me.Label4)
        Me.gpxMillCertData.Controls.Add(Me.cboHeatNumber)
        Me.gpxMillCertData.Controls.Add(Me.Label6)
        Me.gpxMillCertData.Controls.Add(Me.cboSteelSize)
        Me.gpxMillCertData.Controls.Add(Me.txtComment)
        Me.gpxMillCertData.Controls.Add(Me.dtpMillReceivingDate)
        Me.gpxMillCertData.Controls.Add(Me.txtElongation)
        Me.gpxMillCertData.Controls.Add(Me.txtReductionOfArea)
        Me.gpxMillCertData.Controls.Add(Me.txtYield)
        Me.gpxMillCertData.Controls.Add(Me.Label5)
        Me.gpxMillCertData.Controls.Add(Me.txtUltimateTensile)
        Me.gpxMillCertData.Controls.Add(Me.Label14)
        Me.gpxMillCertData.Controls.Add(Me.txtPoundsInHeat)
        Me.gpxMillCertData.Controls.Add(Me.txtCoilsInHeat)
        Me.gpxMillCertData.Controls.Add(Me.txtSteelPONumber)
        Me.gpxMillCertData.Controls.Add(Me.Label13)
        Me.gpxMillCertData.Controls.Add(Me.Label15)
        Me.gpxMillCertData.Controls.Add(Me.Label7)
        Me.gpxMillCertData.Controls.Add(Me.Label8)
        Me.gpxMillCertData.Controls.Add(Me.Label9)
        Me.gpxMillCertData.Controls.Add(Me.cboVendorID)
        Me.gpxMillCertData.Controls.Add(Me.Label10)
        Me.gpxMillCertData.Controls.Add(Me.Label11)
        Me.gpxMillCertData.Controls.Add(Me.Label1)
        Me.gpxMillCertData.Controls.Add(Me.Label12)
        Me.gpxMillCertData.Location = New System.Drawing.Point(29, 41)
        Me.gpxMillCertData.Name = "gpxMillCertData"
        Me.gpxMillCertData.Size = New System.Drawing.Size(350, 772)
        Me.gpxMillCertData.TabIndex = 0
        Me.gpxMillCertData.TabStop = False
        Me.gpxMillCertData.Text = "Mill Certification Data"
        '
        'txtBOLNumber
        '
        Me.txtBOLNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBOLNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBOLNumber.Location = New System.Drawing.Point(150, 561)
        Me.txtBOLNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBOLNumber.Name = "txtBOLNumber"
        Me.txtBOLNumber.Size = New System.Drawing.Size(179, 20)
        Me.txtBOLNumber.TabIndex = 16
        Me.txtBOLNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(18, 561)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 20)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "BOL Number"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMaterialOrigin
        '
        Me.cboMaterialOrigin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMaterialOrigin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMaterialOrigin.FormattingEnabled = True
        Me.cboMaterialOrigin.Items.AddRange(New Object() {"DOMESTIC", "FOREIGN"})
        Me.cboMaterialOrigin.Location = New System.Drawing.Point(150, 524)
        Me.cboMaterialOrigin.Margin = New System.Windows.Forms.Padding(5)
        Me.cboMaterialOrigin.Name = "cboMaterialOrigin"
        Me.cboMaterialOrigin.Size = New System.Drawing.Size(179, 21)
        Me.cboMaterialOrigin.TabIndex = 15
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(18, 525)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(110, 20)
        Me.Label36.TabIndex = 28
        Me.Label36.Text = "Material Origin"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(21, 203)
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(308, 20)
        Me.txtVendorName.TabIndex = 27
        Me.txtVendorName.TabStop = False
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateHeatFileNumber
        '
        Me.cmdGenerateHeatFileNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateHeatFileNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateHeatFileNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateHeatFileNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateHeatFileNumber.Location = New System.Drawing.Point(118, 34)
        Me.cmdGenerateHeatFileNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateHeatFileNumber.Name = "cmdGenerateHeatFileNumber"
        Me.cmdGenerateHeatFileNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateHeatFileNumber.TabIndex = 0
        Me.cmdGenerateHeatFileNumber.TabStop = False
        Me.cmdGenerateHeatFileNumber.Text = ">>"
        Me.cmdGenerateHeatFileNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateHeatFileNumber.UseVisualStyleBackColor = False
        '
        'cboHeatFileNumber
        '
        Me.cboHeatFileNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatFileNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatFileNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatFileNumber.DisplayMember = "HeatNumber"
        Me.cboHeatFileNumber.FormattingEnabled = True
        Me.cboHeatFileNumber.Location = New System.Drawing.Point(150, 33)
        Me.cboHeatFileNumber.Name = "cboHeatFileNumber"
        Me.cboHeatFileNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboHeatFileNumber.TabIndex = 1
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblHeatFileNumber
        '
        Me.lblHeatFileNumber.Location = New System.Drawing.Point(18, 33)
        Me.lblHeatFileNumber.Name = "lblHeatFileNumber"
        Me.lblHeatFileNumber.Size = New System.Drawing.Size(110, 21)
        Me.lblHeatFileNumber.TabIndex = 26
        Me.lblHeatFileNumber.Text = "Heat File Number"
        Me.lblHeatFileNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelCarbon
        '
        Me.cboSteelCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelCarbon.FormattingEnabled = True
        Me.cboSteelCarbon.Location = New System.Drawing.Point(150, 101)
        Me.cboSteelCarbon.Name = "cboSteelCarbon"
        Me.cboSteelCarbon.Size = New System.Drawing.Size(179, 21)
        Me.cboSteelCarbon.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 21)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Steel Diameter"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(150, 67)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboHeatNumber.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 21)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Steel Carbon"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(150, 135)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(179, 21)
        Me.cboSteelSize.TabIndex = 4
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(21, 633)
        Me.txtComment.MaxLength = 100
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(308, 122)
        Me.txtComment.TabIndex = 17
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpMillReceivingDate
        '
        Me.dtpMillReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMillReceivingDate.Location = New System.Drawing.Point(150, 236)
        Me.dtpMillReceivingDate.Name = "dtpMillReceivingDate"
        Me.dtpMillReceivingDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpMillReceivingDate.TabIndex = 7
        '
        'txtElongation
        '
        Me.txtElongation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElongation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtElongation.Location = New System.Drawing.Point(150, 488)
        Me.txtElongation.Name = "txtElongation"
        Me.txtElongation.Size = New System.Drawing.Size(179, 20)
        Me.txtElongation.TabIndex = 14
        Me.txtElongation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReductionOfArea
        '
        Me.txtReductionOfArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReductionOfArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReductionOfArea.Location = New System.Drawing.Point(150, 452)
        Me.txtReductionOfArea.Name = "txtReductionOfArea"
        Me.txtReductionOfArea.Size = New System.Drawing.Size(179, 20)
        Me.txtReductionOfArea.TabIndex = 13
        Me.txtReductionOfArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYield
        '
        Me.txtYield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYield.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYield.Location = New System.Drawing.Point(150, 416)
        Me.txtYield.Name = "txtYield"
        Me.txtYield.Size = New System.Drawing.Size(179, 20)
        Me.txtYield.TabIndex = 12
        Me.txtYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 21)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Heat Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUltimateTensile
        '
        Me.txtUltimateTensile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUltimateTensile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUltimateTensile.Location = New System.Drawing.Point(150, 380)
        Me.txtUltimateTensile.Name = "txtUltimateTensile"
        Me.txtUltimateTensile.Size = New System.Drawing.Size(179, 20)
        Me.txtUltimateTensile.TabIndex = 11
        Me.txtUltimateTensile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(18, 610)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 20)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Comment"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPoundsInHeat
        '
        Me.txtPoundsInHeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPoundsInHeat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPoundsInHeat.Location = New System.Drawing.Point(150, 344)
        Me.txtPoundsInHeat.Name = "txtPoundsInHeat"
        Me.txtPoundsInHeat.Size = New System.Drawing.Size(179, 20)
        Me.txtPoundsInHeat.TabIndex = 10
        Me.txtPoundsInHeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoilsInHeat
        '
        Me.txtCoilsInHeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilsInHeat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilsInHeat.Location = New System.Drawing.Point(150, 308)
        Me.txtCoilsInHeat.Name = "txtCoilsInHeat"
        Me.txtCoilsInHeat.Size = New System.Drawing.Size(179, 20)
        Me.txtCoilsInHeat.TabIndex = 9
        Me.txtCoilsInHeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSteelPONumber
        '
        Me.txtSteelPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelPONumber.Location = New System.Drawing.Point(150, 272)
        Me.txtSteelPONumber.Name = "txtSteelPONumber"
        Me.txtSteelPONumber.Size = New System.Drawing.Size(179, 20)
        Me.txtSteelPONumber.TabIndex = 8
        Me.txtSteelPONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 488)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 20)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Elongation (%)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(18, 452)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 20)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Reduction of Area (%)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 382)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Ultimate Tensile (PSI)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 418)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Yield (PSI)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 344)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "# Pounds in Heat"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(118, 169)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(211, 21)
        Me.cboVendorID.TabIndex = 5
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 272)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 20)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "PO Number"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 308)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "# Coils in Heat"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Steel Vendor ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 238)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 21)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Receiving Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Location = New System.Drawing.Point(40, 515)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtStatus.TabIndex = 106
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtStatus.Visible = False
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'gpxChemicalMakeup
        '
        Me.gpxChemicalMakeup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighMagnesium)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowMagnesium)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblMagnesium)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtMagnesium)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighTungsten)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowTungsten)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtStatus)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblTungsten)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtTungsten)
        Me.gpxChemicalMakeup.Controls.Add(Me.Label3)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblColorCode)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblCEV)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtCEV)
        Me.gpxChemicalMakeup.Controls.Add(Me.Label40)
        Me.gpxChemicalMakeup.Controls.Add(Me.Label39)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighTin)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowTin)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighCopper)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowCopper)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighMolybdenum)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowMolybdenum)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighChromium)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowChromium)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighNickel)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowNickel)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighSilicon)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowSilicon)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighSulfur)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowSulfur)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighPhosporus)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowPhosporus)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighManganese)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowManganese)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighCarbon)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowCarbon)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighCobalt)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowCobalt)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighLead)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowLead)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighZinc)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowZinc)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighIron)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowIron)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighNiobium)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowNiobium)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighTitanium)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowTitanium)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighBoron)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowBoron)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighNitrogen)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowNitrogen)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighAluminum)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowAluminum)
        Me.gpxChemicalMakeup.Controls.Add(Me.HighVanadium)
        Me.gpxChemicalMakeup.Controls.Add(Me.LowVanadium)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtLead)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblLead)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblCobalt)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtIron)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtZinc)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblZinc)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblIron)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtCobalt)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtTitanium)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblTitanium)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblNiobium)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtNitrogen)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtAluminum)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtBoron)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtVanadium)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtTin)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtCopper)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtMolybdenum)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtChromium)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblBoron)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblNitrogen)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblVanadium)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblAluminum)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblTin)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblMolybdenum)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblCopper)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtNickel)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtNiobium)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtSilicon)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtSulfur)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtPhosphorus)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtManganese)
        Me.gpxChemicalMakeup.Controls.Add(Me.txtCarbon)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblChromium)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblNickel)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblSulfur)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblSilicon)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblPhosporus)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblCarbon)
        Me.gpxChemicalMakeup.Controls.Add(Me.lblManganese)
        Me.gpxChemicalMakeup.Location = New System.Drawing.Point(385, 41)
        Me.gpxChemicalMakeup.Name = "gpxChemicalMakeup"
        Me.gpxChemicalMakeup.Size = New System.Drawing.Size(641, 591)
        Me.gpxChemicalMakeup.TabIndex = 16
        Me.gpxChemicalMakeup.TabStop = False
        Me.gpxChemicalMakeup.Text = "Chemical Composition of Heat Number"
        '
        'HighMagnesium
        '
        Me.HighMagnesium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighMagnesium.Location = New System.Drawing.Point(474, 474)
        Me.HighMagnesium.Name = "HighMagnesium"
        Me.HighMagnesium.Size = New System.Drawing.Size(41, 20)
        Me.HighMagnesium.TabIndex = 116
        Me.HighMagnesium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowMagnesium
        '
        Me.LowMagnesium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowMagnesium.Location = New System.Drawing.Point(427, 474)
        Me.LowMagnesium.Name = "LowMagnesium"
        Me.LowMagnesium.Size = New System.Drawing.Size(41, 20)
        Me.LowMagnesium.TabIndex = 115
        Me.LowMagnesium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMagnesium
        '
        Me.lblMagnesium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMagnesium.Location = New System.Drawing.Point(333, 474)
        Me.lblMagnesium.Name = "lblMagnesium"
        Me.lblMagnesium.Size = New System.Drawing.Size(88, 20)
        Me.lblMagnesium.TabIndex = 114
        Me.lblMagnesium.Text = "Magnesium (Mg)"
        Me.lblMagnesium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMagnesium
        '
        Me.txtMagnesium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtMagnesium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMagnesium.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMagnesium.Location = New System.Drawing.Point(522, 474)
        Me.txtMagnesium.Margin = New System.Windows.Forms.Padding(10)
        Me.txtMagnesium.Name = "txtMagnesium"
        Me.txtMagnesium.Size = New System.Drawing.Size(100, 20)
        Me.txtMagnesium.TabIndex = 37
        Me.txtMagnesium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HighTungsten
        '
        Me.HighTungsten.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighTungsten.Location = New System.Drawing.Point(474, 434)
        Me.HighTungsten.Name = "HighTungsten"
        Me.HighTungsten.Size = New System.Drawing.Size(41, 20)
        Me.HighTungsten.TabIndex = 112
        Me.HighTungsten.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowTungsten
        '
        Me.LowTungsten.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowTungsten.Location = New System.Drawing.Point(427, 434)
        Me.LowTungsten.Name = "LowTungsten"
        Me.LowTungsten.Size = New System.Drawing.Size(41, 20)
        Me.LowTungsten.TabIndex = 111
        Me.LowTungsten.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTungsten
        '
        Me.lblTungsten.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTungsten.Location = New System.Drawing.Point(333, 434)
        Me.lblTungsten.Name = "lblTungsten"
        Me.lblTungsten.Size = New System.Drawing.Size(88, 20)
        Me.lblTungsten.TabIndex = 110
        Me.lblTungsten.Text = "Tungsten (W)"
        Me.lblTungsten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTungsten
        '
        Me.txtTungsten.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtTungsten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTungsten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTungsten.Location = New System.Drawing.Point(522, 434)
        Me.txtTungsten.Margin = New System.Windows.Forms.Padding(10)
        Me.txtTungsten.Name = "txtTungsten"
        Me.txtTungsten.Size = New System.Drawing.Size(100, 20)
        Me.txtTungsten.TabIndex = 36
        Me.txtTungsten.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(35, 556)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 23)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "- Indicates not within tolerance."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColorCode
        '
        Me.lblColorCode.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblColorCode.BackColor = System.Drawing.Color.LightCoral
        Me.lblColorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColorCode.Location = New System.Drawing.Point(11, 557)
        Me.lblColorCode.Name = "lblColorCode"
        Me.lblColorCode.Size = New System.Drawing.Size(20, 20)
        Me.lblColorCode.TabIndex = 108
        Me.lblColorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCEV
        '
        Me.lblCEV.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCEV.Location = New System.Drawing.Point(296, 550)
        Me.lblCEV.Name = "lblCEV"
        Me.lblCEV.Size = New System.Drawing.Size(45, 20)
        Me.lblCEV.TabIndex = 107
        Me.lblCEV.Text = "CEV(%)"
        Me.lblCEV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCEV
        '
        Me.txtCEV.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtCEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCEV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEV.Location = New System.Drawing.Point(352, 550)
        Me.txtCEV.Name = "txtCEV"
        Me.txtCEV.ReadOnly = True
        Me.txtCEV.Size = New System.Drawing.Size(100, 20)
        Me.txtCEV.TabIndex = 106
        Me.txtCEV.TabStop = False
        Me.txtCEV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label40.ForeColor = System.Drawing.Color.Blue
        Me.Label40.Location = New System.Drawing.Point(425, 20)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(91, 20)
        Me.Label40.TabIndex = 105
        Me.Label40.Text = "Low / High"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(103, 21)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(91, 20)
        Me.Label39.TabIndex = 104
        Me.Label39.Text = "Low / High"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HighTin
        '
        Me.HighTin.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighTin.Location = New System.Drawing.Point(153, 434)
        Me.HighTin.Name = "HighTin"
        Me.HighTin.Size = New System.Drawing.Size(41, 20)
        Me.HighTin.TabIndex = 103
        Me.HighTin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowTin
        '
        Me.LowTin.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowTin.Location = New System.Drawing.Point(106, 434)
        Me.LowTin.Name = "LowTin"
        Me.LowTin.Size = New System.Drawing.Size(41, 20)
        Me.LowTin.TabIndex = 102
        Me.LowTin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighCopper
        '
        Me.HighCopper.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighCopper.Location = New System.Drawing.Point(153, 394)
        Me.HighCopper.Name = "HighCopper"
        Me.HighCopper.Size = New System.Drawing.Size(41, 20)
        Me.HighCopper.TabIndex = 101
        Me.HighCopper.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowCopper
        '
        Me.LowCopper.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowCopper.Location = New System.Drawing.Point(106, 394)
        Me.LowCopper.Name = "LowCopper"
        Me.LowCopper.Size = New System.Drawing.Size(41, 20)
        Me.LowCopper.TabIndex = 100
        Me.LowCopper.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighMolybdenum
        '
        Me.HighMolybdenum.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighMolybdenum.Location = New System.Drawing.Point(153, 354)
        Me.HighMolybdenum.Name = "HighMolybdenum"
        Me.HighMolybdenum.Size = New System.Drawing.Size(41, 20)
        Me.HighMolybdenum.TabIndex = 99
        Me.HighMolybdenum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowMolybdenum
        '
        Me.LowMolybdenum.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowMolybdenum.Location = New System.Drawing.Point(106, 354)
        Me.LowMolybdenum.Name = "LowMolybdenum"
        Me.LowMolybdenum.Size = New System.Drawing.Size(41, 20)
        Me.LowMolybdenum.TabIndex = 98
        Me.LowMolybdenum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighChromium
        '
        Me.HighChromium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighChromium.Location = New System.Drawing.Point(153, 314)
        Me.HighChromium.Name = "HighChromium"
        Me.HighChromium.Size = New System.Drawing.Size(41, 20)
        Me.HighChromium.TabIndex = 97
        Me.HighChromium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowChromium
        '
        Me.LowChromium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowChromium.Location = New System.Drawing.Point(106, 314)
        Me.LowChromium.Name = "LowChromium"
        Me.LowChromium.Size = New System.Drawing.Size(41, 20)
        Me.LowChromium.TabIndex = 96
        Me.LowChromium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighNickel
        '
        Me.HighNickel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighNickel.Location = New System.Drawing.Point(152, 274)
        Me.HighNickel.Name = "HighNickel"
        Me.HighNickel.Size = New System.Drawing.Size(41, 20)
        Me.HighNickel.TabIndex = 95
        Me.HighNickel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowNickel
        '
        Me.LowNickel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowNickel.Location = New System.Drawing.Point(106, 274)
        Me.LowNickel.Name = "LowNickel"
        Me.LowNickel.Size = New System.Drawing.Size(41, 20)
        Me.LowNickel.TabIndex = 94
        Me.LowNickel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighSilicon
        '
        Me.HighSilicon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighSilicon.Location = New System.Drawing.Point(153, 206)
        Me.HighSilicon.Name = "HighSilicon"
        Me.HighSilicon.Size = New System.Drawing.Size(41, 20)
        Me.HighSilicon.TabIndex = 93
        Me.HighSilicon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowSilicon
        '
        Me.LowSilicon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowSilicon.Location = New System.Drawing.Point(106, 206)
        Me.LowSilicon.Name = "LowSilicon"
        Me.LowSilicon.Size = New System.Drawing.Size(41, 20)
        Me.LowSilicon.TabIndex = 92
        Me.LowSilicon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighSulfur
        '
        Me.HighSulfur.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighSulfur.Location = New System.Drawing.Point(153, 168)
        Me.HighSulfur.Name = "HighSulfur"
        Me.HighSulfur.Size = New System.Drawing.Size(41, 20)
        Me.HighSulfur.TabIndex = 91
        Me.HighSulfur.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowSulfur
        '
        Me.LowSulfur.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowSulfur.Location = New System.Drawing.Point(106, 168)
        Me.LowSulfur.Name = "LowSulfur"
        Me.LowSulfur.Size = New System.Drawing.Size(41, 20)
        Me.LowSulfur.TabIndex = 90
        Me.LowSulfur.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighPhosporus
        '
        Me.HighPhosporus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighPhosporus.Location = New System.Drawing.Point(154, 130)
        Me.HighPhosporus.Name = "HighPhosporus"
        Me.HighPhosporus.Size = New System.Drawing.Size(41, 20)
        Me.HighPhosporus.TabIndex = 89
        Me.HighPhosporus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowPhosporus
        '
        Me.LowPhosporus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowPhosporus.Location = New System.Drawing.Point(106, 130)
        Me.LowPhosporus.Name = "LowPhosporus"
        Me.LowPhosporus.Size = New System.Drawing.Size(41, 20)
        Me.LowPhosporus.TabIndex = 88
        Me.LowPhosporus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighManganese
        '
        Me.HighManganese.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighManganese.Location = New System.Drawing.Point(154, 92)
        Me.HighManganese.Name = "HighManganese"
        Me.HighManganese.Size = New System.Drawing.Size(41, 20)
        Me.HighManganese.TabIndex = 87
        Me.HighManganese.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowManganese
        '
        Me.LowManganese.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowManganese.Location = New System.Drawing.Point(106, 92)
        Me.LowManganese.Name = "LowManganese"
        Me.LowManganese.Size = New System.Drawing.Size(41, 20)
        Me.LowManganese.TabIndex = 86
        Me.LowManganese.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighCarbon
        '
        Me.HighCarbon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighCarbon.Location = New System.Drawing.Point(153, 54)
        Me.HighCarbon.Name = "HighCarbon"
        Me.HighCarbon.Size = New System.Drawing.Size(41, 20)
        Me.HighCarbon.TabIndex = 85
        Me.HighCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowCarbon
        '
        Me.LowCarbon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowCarbon.Location = New System.Drawing.Point(106, 54)
        Me.LowCarbon.Name = "LowCarbon"
        Me.LowCarbon.Size = New System.Drawing.Size(41, 20)
        Me.LowCarbon.TabIndex = 84
        Me.LowCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighCobalt
        '
        Me.HighCobalt.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighCobalt.Location = New System.Drawing.Point(474, 394)
        Me.HighCobalt.Name = "HighCobalt"
        Me.HighCobalt.Size = New System.Drawing.Size(41, 20)
        Me.HighCobalt.TabIndex = 83
        Me.HighCobalt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowCobalt
        '
        Me.LowCobalt.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowCobalt.Location = New System.Drawing.Point(427, 394)
        Me.LowCobalt.Name = "LowCobalt"
        Me.LowCobalt.Size = New System.Drawing.Size(41, 20)
        Me.LowCobalt.TabIndex = 82
        Me.LowCobalt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighLead
        '
        Me.HighLead.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighLead.Location = New System.Drawing.Point(474, 354)
        Me.HighLead.Name = "HighLead"
        Me.HighLead.Size = New System.Drawing.Size(41, 20)
        Me.HighLead.TabIndex = 81
        Me.HighLead.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowLead
        '
        Me.LowLead.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowLead.Location = New System.Drawing.Point(427, 354)
        Me.LowLead.Name = "LowLead"
        Me.LowLead.Size = New System.Drawing.Size(41, 20)
        Me.LowLead.TabIndex = 80
        Me.LowLead.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighZinc
        '
        Me.HighZinc.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighZinc.Location = New System.Drawing.Point(474, 314)
        Me.HighZinc.Name = "HighZinc"
        Me.HighZinc.Size = New System.Drawing.Size(41, 20)
        Me.HighZinc.TabIndex = 79
        Me.HighZinc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowZinc
        '
        Me.LowZinc.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowZinc.Location = New System.Drawing.Point(427, 314)
        Me.LowZinc.Name = "LowZinc"
        Me.LowZinc.Size = New System.Drawing.Size(41, 20)
        Me.LowZinc.TabIndex = 78
        Me.LowZinc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighIron
        '
        Me.HighIron.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighIron.Location = New System.Drawing.Point(474, 274)
        Me.HighIron.Name = "HighIron"
        Me.HighIron.Size = New System.Drawing.Size(41, 20)
        Me.HighIron.TabIndex = 77
        Me.HighIron.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowIron
        '
        Me.LowIron.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowIron.Location = New System.Drawing.Point(427, 274)
        Me.LowIron.Name = "LowIron"
        Me.LowIron.Size = New System.Drawing.Size(41, 20)
        Me.LowIron.TabIndex = 76
        Me.LowIron.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighNiobium
        '
        Me.HighNiobium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HighNiobium.Location = New System.Drawing.Point(474, 206)
        Me.HighNiobium.Name = "HighNiobium"
        Me.HighNiobium.Size = New System.Drawing.Size(41, 20)
        Me.HighNiobium.TabIndex = 75
        Me.HighNiobium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowNiobium
        '
        Me.LowNiobium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LowNiobium.Location = New System.Drawing.Point(427, 206)
        Me.LowNiobium.Name = "LowNiobium"
        Me.LowNiobium.Size = New System.Drawing.Size(41, 20)
        Me.LowNiobium.TabIndex = 74
        Me.LowNiobium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighTitanium
        '
        Me.HighTitanium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighTitanium.Location = New System.Drawing.Point(474, 168)
        Me.HighTitanium.Name = "HighTitanium"
        Me.HighTitanium.Size = New System.Drawing.Size(41, 20)
        Me.HighTitanium.TabIndex = 73
        Me.HighTitanium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowTitanium
        '
        Me.LowTitanium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowTitanium.Location = New System.Drawing.Point(427, 168)
        Me.LowTitanium.Name = "LowTitanium"
        Me.LowTitanium.Size = New System.Drawing.Size(41, 20)
        Me.LowTitanium.TabIndex = 72
        Me.LowTitanium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighBoron
        '
        Me.HighBoron.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighBoron.Location = New System.Drawing.Point(474, 130)
        Me.HighBoron.Name = "HighBoron"
        Me.HighBoron.Size = New System.Drawing.Size(41, 20)
        Me.HighBoron.TabIndex = 71
        Me.HighBoron.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowBoron
        '
        Me.LowBoron.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowBoron.Location = New System.Drawing.Point(427, 130)
        Me.LowBoron.Name = "LowBoron"
        Me.LowBoron.Size = New System.Drawing.Size(41, 20)
        Me.LowBoron.TabIndex = 70
        Me.LowBoron.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighNitrogen
        '
        Me.HighNitrogen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighNitrogen.Location = New System.Drawing.Point(474, 92)
        Me.HighNitrogen.Name = "HighNitrogen"
        Me.HighNitrogen.Size = New System.Drawing.Size(41, 20)
        Me.HighNitrogen.TabIndex = 69
        Me.HighNitrogen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowNitrogen
        '
        Me.LowNitrogen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowNitrogen.Location = New System.Drawing.Point(427, 92)
        Me.LowNitrogen.Name = "LowNitrogen"
        Me.LowNitrogen.Size = New System.Drawing.Size(41, 20)
        Me.LowNitrogen.TabIndex = 68
        Me.LowNitrogen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighAluminum
        '
        Me.HighAluminum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighAluminum.Location = New System.Drawing.Point(474, 54)
        Me.HighAluminum.Name = "HighAluminum"
        Me.HighAluminum.Size = New System.Drawing.Size(41, 20)
        Me.HighAluminum.TabIndex = 67
        Me.HighAluminum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowAluminum
        '
        Me.LowAluminum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowAluminum.Location = New System.Drawing.Point(427, 54)
        Me.LowAluminum.Name = "LowAluminum"
        Me.LowAluminum.Size = New System.Drawing.Size(41, 20)
        Me.LowAluminum.TabIndex = 66
        Me.LowAluminum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HighVanadium
        '
        Me.HighVanadium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.HighVanadium.Location = New System.Drawing.Point(153, 474)
        Me.HighVanadium.Name = "HighVanadium"
        Me.HighVanadium.Size = New System.Drawing.Size(41, 20)
        Me.HighVanadium.TabIndex = 49
        Me.HighVanadium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LowVanadium
        '
        Me.LowVanadium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LowVanadium.Location = New System.Drawing.Point(106, 474)
        Me.LowVanadium.Name = "LowVanadium"
        Me.LowVanadium.Size = New System.Drawing.Size(41, 20)
        Me.LowVanadium.TabIndex = 48
        Me.LowVanadium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLead
        '
        Me.txtLead.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtLead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLead.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLead.Location = New System.Drawing.Point(522, 354)
        Me.txtLead.Margin = New System.Windows.Forms.Padding(10)
        Me.txtLead.Name = "txtLead"
        Me.txtLead.Size = New System.Drawing.Size(100, 20)
        Me.txtLead.TabIndex = 34
        Me.txtLead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLead
        '
        Me.lblLead.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblLead.Location = New System.Drawing.Point(333, 354)
        Me.lblLead.Name = "lblLead"
        Me.lblLead.Size = New System.Drawing.Size(88, 20)
        Me.lblLead.TabIndex = 65
        Me.lblLead.Text = "Lead (Pb)"
        Me.lblLead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCobalt
        '
        Me.lblCobalt.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCobalt.Location = New System.Drawing.Point(333, 394)
        Me.lblCobalt.Name = "lblCobalt"
        Me.lblCobalt.Size = New System.Drawing.Size(88, 20)
        Me.lblCobalt.TabIndex = 64
        Me.lblCobalt.Text = "Cobalt (Co)"
        Me.lblCobalt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIron
        '
        Me.txtIron.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtIron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIron.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIron.Location = New System.Drawing.Point(522, 274)
        Me.txtIron.Margin = New System.Windows.Forms.Padding(10)
        Me.txtIron.Name = "txtIron"
        Me.txtIron.Size = New System.Drawing.Size(100, 20)
        Me.txtIron.TabIndex = 32
        Me.txtIron.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtZinc
        '
        Me.txtZinc.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtZinc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZinc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZinc.Location = New System.Drawing.Point(522, 314)
        Me.txtZinc.Margin = New System.Windows.Forms.Padding(10)
        Me.txtZinc.Name = "txtZinc"
        Me.txtZinc.Size = New System.Drawing.Size(100, 20)
        Me.txtZinc.TabIndex = 33
        Me.txtZinc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblZinc
        '
        Me.lblZinc.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblZinc.Location = New System.Drawing.Point(333, 314)
        Me.lblZinc.Name = "lblZinc"
        Me.lblZinc.Size = New System.Drawing.Size(88, 20)
        Me.lblZinc.TabIndex = 62
        Me.lblZinc.Text = "Zinc (Zn)"
        Me.lblZinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIron
        '
        Me.lblIron.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblIron.Location = New System.Drawing.Point(333, 274)
        Me.lblIron.Name = "lblIron"
        Me.lblIron.Size = New System.Drawing.Size(88, 20)
        Me.lblIron.TabIndex = 61
        Me.lblIron.Text = "Iron (Fe)"
        Me.lblIron.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCobalt
        '
        Me.txtCobalt.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtCobalt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCobalt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCobalt.Location = New System.Drawing.Point(522, 394)
        Me.txtCobalt.Margin = New System.Windows.Forms.Padding(10)
        Me.txtCobalt.Name = "txtCobalt"
        Me.txtCobalt.Size = New System.Drawing.Size(100, 20)
        Me.txtCobalt.TabIndex = 35
        Me.txtCobalt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTitanium
        '
        Me.txtTitanium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTitanium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitanium.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTitanium.Location = New System.Drawing.Point(522, 168)
        Me.txtTitanium.Margin = New System.Windows.Forms.Padding(10)
        Me.txtTitanium.Name = "txtTitanium"
        Me.txtTitanium.Size = New System.Drawing.Size(100, 20)
        Me.txtTitanium.TabIndex = 30
        Me.txtTitanium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitanium
        '
        Me.lblTitanium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitanium.Location = New System.Drawing.Point(333, 168)
        Me.lblTitanium.Name = "lblTitanium"
        Me.lblTitanium.Size = New System.Drawing.Size(88, 20)
        Me.lblTitanium.TabIndex = 57
        Me.lblTitanium.Text = "Titanium (Ti)"
        Me.lblTitanium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNiobium
        '
        Me.lblNiobium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNiobium.Location = New System.Drawing.Point(333, 206)
        Me.lblNiobium.Name = "lblNiobium"
        Me.lblNiobium.Size = New System.Drawing.Size(88, 20)
        Me.lblNiobium.TabIndex = 56
        Me.lblNiobium.Text = "Niobium (Nb)"
        Me.lblNiobium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNitrogen
        '
        Me.txtNitrogen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNitrogen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNitrogen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNitrogen.Location = New System.Drawing.Point(522, 92)
        Me.txtNitrogen.Margin = New System.Windows.Forms.Padding(10)
        Me.txtNitrogen.Name = "txtNitrogen"
        Me.txtNitrogen.Size = New System.Drawing.Size(100, 20)
        Me.txtNitrogen.TabIndex = 28
        Me.txtNitrogen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAluminum
        '
        Me.txtAluminum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtAluminum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAluminum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAluminum.Location = New System.Drawing.Point(522, 54)
        Me.txtAluminum.Margin = New System.Windows.Forms.Padding(10)
        Me.txtAluminum.Name = "txtAluminum"
        Me.txtAluminum.Size = New System.Drawing.Size(100, 20)
        Me.txtAluminum.TabIndex = 27
        Me.txtAluminum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoron
        '
        Me.txtBoron.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBoron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoron.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoron.Location = New System.Drawing.Point(522, 130)
        Me.txtBoron.Margin = New System.Windows.Forms.Padding(10)
        Me.txtBoron.Name = "txtBoron"
        Me.txtBoron.Size = New System.Drawing.Size(100, 20)
        Me.txtBoron.TabIndex = 29
        Me.txtBoron.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVanadium
        '
        Me.txtVanadium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtVanadium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVanadium.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVanadium.Location = New System.Drawing.Point(204, 474)
        Me.txtVanadium.Margin = New System.Windows.Forms.Padding(10)
        Me.txtVanadium.Name = "txtVanadium"
        Me.txtVanadium.Size = New System.Drawing.Size(100, 20)
        Me.txtVanadium.TabIndex = 26
        Me.txtVanadium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTin
        '
        Me.txtTin.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTin.Location = New System.Drawing.Point(204, 434)
        Me.txtTin.Margin = New System.Windows.Forms.Padding(10)
        Me.txtTin.Name = "txtTin"
        Me.txtTin.Size = New System.Drawing.Size(100, 20)
        Me.txtTin.TabIndex = 25
        Me.txtTin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCopper
        '
        Me.txtCopper.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtCopper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCopper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCopper.Location = New System.Drawing.Point(204, 394)
        Me.txtCopper.Margin = New System.Windows.Forms.Padding(10)
        Me.txtCopper.Name = "txtCopper"
        Me.txtCopper.Size = New System.Drawing.Size(100, 20)
        Me.txtCopper.TabIndex = 24
        Me.txtCopper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMolybdenum
        '
        Me.txtMolybdenum.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtMolybdenum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMolybdenum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMolybdenum.Location = New System.Drawing.Point(204, 354)
        Me.txtMolybdenum.Margin = New System.Windows.Forms.Padding(10)
        Me.txtMolybdenum.Name = "txtMolybdenum"
        Me.txtMolybdenum.Size = New System.Drawing.Size(100, 20)
        Me.txtMolybdenum.TabIndex = 23
        Me.txtMolybdenum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtChromium
        '
        Me.txtChromium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtChromium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChromium.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChromium.Location = New System.Drawing.Point(204, 314)
        Me.txtChromium.Margin = New System.Windows.Forms.Padding(10)
        Me.txtChromium.Name = "txtChromium"
        Me.txtChromium.Size = New System.Drawing.Size(100, 20)
        Me.txtChromium.TabIndex = 22
        Me.txtChromium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBoron
        '
        Me.lblBoron.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblBoron.Location = New System.Drawing.Point(333, 130)
        Me.lblBoron.Name = "lblBoron"
        Me.lblBoron.Size = New System.Drawing.Size(88, 20)
        Me.lblBoron.TabIndex = 48
        Me.lblBoron.Text = "Boron (B)"
        Me.lblBoron.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNitrogen
        '
        Me.lblNitrogen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNitrogen.Location = New System.Drawing.Point(333, 92)
        Me.lblNitrogen.Name = "lblNitrogen"
        Me.lblNitrogen.Size = New System.Drawing.Size(88, 20)
        Me.lblNitrogen.TabIndex = 47
        Me.lblNitrogen.Text = "Nitrogen (N)"
        Me.lblNitrogen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVanadium
        '
        Me.lblVanadium.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblVanadium.Location = New System.Drawing.Point(14, 474)
        Me.lblVanadium.Name = "lblVanadium"
        Me.lblVanadium.Size = New System.Drawing.Size(106, 20)
        Me.lblVanadium.TabIndex = 46
        Me.lblVanadium.Text = "Vanadium (V)"
        Me.lblVanadium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAluminum
        '
        Me.lblAluminum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblAluminum.Location = New System.Drawing.Point(333, 54)
        Me.lblAluminum.Name = "lblAluminum"
        Me.lblAluminum.Size = New System.Drawing.Size(88, 20)
        Me.lblAluminum.TabIndex = 45
        Me.lblAluminum.Text = "Aluminum (Al)"
        Me.lblAluminum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTin
        '
        Me.lblTin.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTin.Location = New System.Drawing.Point(14, 434)
        Me.lblTin.Name = "lblTin"
        Me.lblTin.Size = New System.Drawing.Size(106, 20)
        Me.lblTin.TabIndex = 44
        Me.lblTin.Text = "Tin (Sn)"
        Me.lblTin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMolybdenum
        '
        Me.lblMolybdenum.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMolybdenum.Location = New System.Drawing.Point(14, 354)
        Me.lblMolybdenum.Name = "lblMolybdenum"
        Me.lblMolybdenum.Size = New System.Drawing.Size(106, 20)
        Me.lblMolybdenum.TabIndex = 43
        Me.lblMolybdenum.Text = "Molybdenum (Mo)"
        Me.lblMolybdenum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCopper
        '
        Me.lblCopper.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCopper.Location = New System.Drawing.Point(14, 394)
        Me.lblCopper.Name = "lblCopper"
        Me.lblCopper.Size = New System.Drawing.Size(106, 20)
        Me.lblCopper.TabIndex = 42
        Me.lblCopper.Text = "Copper (Cu)"
        Me.lblCopper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNickel
        '
        Me.txtNickel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNickel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNickel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNickel.Location = New System.Drawing.Point(204, 274)
        Me.txtNickel.Margin = New System.Windows.Forms.Padding(10)
        Me.txtNickel.Name = "txtNickel"
        Me.txtNickel.Size = New System.Drawing.Size(100, 20)
        Me.txtNickel.TabIndex = 21
        Me.txtNickel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNiobium
        '
        Me.txtNiobium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNiobium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNiobium.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNiobium.Location = New System.Drawing.Point(522, 206)
        Me.txtNiobium.Margin = New System.Windows.Forms.Padding(10)
        Me.txtNiobium.Name = "txtNiobium"
        Me.txtNiobium.Size = New System.Drawing.Size(100, 20)
        Me.txtNiobium.TabIndex = 31
        Me.txtNiobium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSilicon
        '
        Me.txtSilicon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSilicon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSilicon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSilicon.Location = New System.Drawing.Point(204, 206)
        Me.txtSilicon.Margin = New System.Windows.Forms.Padding(10)
        Me.txtSilicon.Name = "txtSilicon"
        Me.txtSilicon.Size = New System.Drawing.Size(100, 20)
        Me.txtSilicon.TabIndex = 20
        Me.txtSilicon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSulfur
        '
        Me.txtSulfur.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSulfur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSulfur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSulfur.Location = New System.Drawing.Point(204, 168)
        Me.txtSulfur.Margin = New System.Windows.Forms.Padding(10)
        Me.txtSulfur.Name = "txtSulfur"
        Me.txtSulfur.Size = New System.Drawing.Size(100, 20)
        Me.txtSulfur.TabIndex = 19
        Me.txtSulfur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPhosphorus
        '
        Me.txtPhosphorus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPhosphorus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhosphorus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhosphorus.Location = New System.Drawing.Point(204, 130)
        Me.txtPhosphorus.Margin = New System.Windows.Forms.Padding(10)
        Me.txtPhosphorus.Name = "txtPhosphorus"
        Me.txtPhosphorus.Size = New System.Drawing.Size(100, 20)
        Me.txtPhosphorus.TabIndex = 18
        Me.txtPhosphorus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtManganese
        '
        Me.txtManganese.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtManganese.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManganese.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtManganese.Location = New System.Drawing.Point(204, 92)
        Me.txtManganese.Margin = New System.Windows.Forms.Padding(10)
        Me.txtManganese.Name = "txtManganese"
        Me.txtManganese.Size = New System.Drawing.Size(100, 20)
        Me.txtManganese.TabIndex = 17
        Me.txtManganese.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCarbon
        '
        Me.txtCarbon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCarbon.Location = New System.Drawing.Point(204, 54)
        Me.txtCarbon.Margin = New System.Windows.Forms.Padding(10)
        Me.txtCarbon.Name = "txtCarbon"
        Me.txtCarbon.Size = New System.Drawing.Size(100, 20)
        Me.txtCarbon.TabIndex = 16
        Me.txtCarbon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblChromium
        '
        Me.lblChromium.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblChromium.Location = New System.Drawing.Point(14, 314)
        Me.lblChromium.Name = "lblChromium"
        Me.lblChromium.Size = New System.Drawing.Size(106, 20)
        Me.lblChromium.TabIndex = 34
        Me.lblChromium.Text = "Chromium (Cr)"
        Me.lblChromium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNickel
        '
        Me.lblNickel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNickel.Location = New System.Drawing.Point(14, 274)
        Me.lblNickel.Name = "lblNickel"
        Me.lblNickel.Size = New System.Drawing.Size(106, 20)
        Me.lblNickel.TabIndex = 33
        Me.lblNickel.Text = "Nickel (Ni)"
        Me.lblNickel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSulfur
        '
        Me.lblSulfur.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSulfur.Location = New System.Drawing.Point(14, 168)
        Me.lblSulfur.Name = "lblSulfur"
        Me.lblSulfur.Size = New System.Drawing.Size(106, 20)
        Me.lblSulfur.TabIndex = 32
        Me.lblSulfur.Text = "Sulfur (S)"
        Me.lblSulfur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSilicon
        '
        Me.lblSilicon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSilicon.Location = New System.Drawing.Point(14, 206)
        Me.lblSilicon.Name = "lblSilicon"
        Me.lblSilicon.Size = New System.Drawing.Size(106, 20)
        Me.lblSilicon.TabIndex = 31
        Me.lblSilicon.Text = "Silicon (Si)"
        Me.lblSilicon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhosporus
        '
        Me.lblPhosporus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPhosporus.Location = New System.Drawing.Point(14, 130)
        Me.lblPhosporus.Name = "lblPhosporus"
        Me.lblPhosporus.Size = New System.Drawing.Size(106, 20)
        Me.lblPhosporus.TabIndex = 30
        Me.lblPhosporus.Text = "Phosporus (P)"
        Me.lblPhosporus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCarbon
        '
        Me.lblCarbon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCarbon.Location = New System.Drawing.Point(14, 54)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(106, 20)
        Me.lblCarbon.TabIndex = 29
        Me.lblCarbon.Text = "Carbon (C)"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblManganese
        '
        Me.lblManganese.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblManganese.Location = New System.Drawing.Point(14, 92)
        Me.lblManganese.Name = "lblManganese"
        Me.lblManganese.Size = New System.Drawing.Size(106, 20)
        Me.lblManganese.TabIndex = 28
        Me.lblManganese.Text = "Manganese (Mn)"
        Me.lblManganese.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(635, 773)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 40
        Me.cmdClearAll.Text = "Clear"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdPullTestData
        '
        Me.cmdPullTestData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPullTestData.Location = New System.Drawing.Point(395, 773)
        Me.cmdPullTestData.Name = "cmdPullTestData"
        Me.cmdPullTestData.Size = New System.Drawing.Size(71, 40)
        Me.cmdPullTestData.TabIndex = 37
        Me.cmdPullTestData.Text = "Pull Test Data"
        Me.cmdPullTestData.UseVisualStyleBackColor = True
        '
        'cmdFOXForm
        '
        Me.cmdFOXForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFOXForm.Location = New System.Drawing.Point(475, 773)
        Me.cmdFOXForm.Name = "cmdFOXForm"
        Me.cmdFOXForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdFOXForm.TabIndex = 38
        Me.cmdFOXForm.Text = "FOX Form"
        Me.cmdFOXForm.UseVisualStyleBackColor = True
        '
        'cmdViewLotNumbers
        '
        Me.cmdViewLotNumbers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewLotNumbers.Location = New System.Drawing.Point(555, 773)
        Me.cmdViewLotNumbers.Name = "cmdViewLotNumbers"
        Me.cmdViewLotNumbers.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewLotNumbers.TabIndex = 39
        Me.cmdViewLotNumbers.Text = "View Lot Numbers"
        Me.cmdViewLotNumbers.UseVisualStyleBackColor = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.ForeColor = System.Drawing.Color.Blue
        Me.Label38.Location = New System.Drawing.Point(396, 642)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(310, 49)
        Me.Label38.TabIndex = 47
        Me.Label38.Text = "Program automatically verifies that chemistry is within the correct tolerances fo" & _
            "r each element / for each alloy."
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(215, 48)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnter.TabIndex = 36
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(20, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 90)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "To finish mill certification entry, you must hit the enter button. Once enter is " & _
            "clicked no more changes can be made to the certification."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpbxFinalize
        '
        Me.grpbxFinalize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxFinalize.Controls.Add(Me.Label2)
        Me.grpbxFinalize.Controls.Add(Me.cmdEnter)
        Me.grpbxFinalize.Location = New System.Drawing.Point(718, 642)
        Me.grpbxFinalize.Name = "grpbxFinalize"
        Me.grpbxFinalize.Size = New System.Drawing.Size(308, 125)
        Me.grpbxFinalize.TabIndex = 17
        Me.grpbxFinalize.TabStop = False
        Me.grpbxFinalize.Text = "Complete Entry"
        '
        'gpxInspectionSheet
        '
        Me.gpxInspectionSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxInspectionSheet.Controls.Add(Me.lblFileCountMessage)
        Me.gpxInspectionSheet.Controls.Add(Me.Label17)
        Me.gpxInspectionSheet.Controls.Add(Me.cmdSelectFile)
        Me.gpxInspectionSheet.Location = New System.Drawing.Point(396, 694)
        Me.gpxInspectionSheet.Name = "gpxInspectionSheet"
        Me.gpxInspectionSheet.Size = New System.Drawing.Size(308, 74)
        Me.gpxInspectionSheet.TabIndex = 109
        Me.gpxInspectionSheet.TabStop = False
        Me.gpxInspectionSheet.Text = "Upload Inspection Sheet"
        '
        'lblFileCountMessage
        '
        Me.lblFileCountMessage.ForeColor = System.Drawing.Color.Red
        Me.lblFileCountMessage.Location = New System.Drawing.Point(17, 48)
        Me.lblFileCountMessage.Name = "lblFileCountMessage"
        Me.lblFileCountMessage.Size = New System.Drawing.Size(175, 23)
        Me.lblFileCountMessage.TabIndex = 109
        Me.lblFileCountMessage.Text = "No files have been uploaded"
        Me.lblFileCountMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(17, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(175, 17)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "Upload Inspection Sheet"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectFile
        '
        Me.cmdSelectFile.Location = New System.Drawing.Point(212, 19)
        Me.cmdSelectFile.Name = "cmdSelectFile"
        Me.cmdSelectFile.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectFile.TabIndex = 36
        Me.cmdSelectFile.Text = "Select File"
        Me.cmdSelectFile.UseVisualStyleBackColor = True
        '
        'MillCertForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 825)
        Me.Controls.Add(Me.gpxInspectionSheet)
        Me.Controls.Add(Me.grpbxFinalize)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdViewLotNumbers)
        Me.Controls.Add(Me.cmdFOXForm)
        Me.Controls.Add(Me.cmdPullTestData)
        Me.Controls.Add(Me.gpxChemicalMakeup)
        Me.Controls.Add(Me.gpxMillCertData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MillCertForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Mill Certification"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxMillCertData.ResumeLayout(False)
        Me.gpxMillCertData.PerformLayout()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxChemicalMakeup.ResumeLayout(False)
        Me.gpxChemicalMakeup.PerformLayout()
        Me.grpbxFinalize.ResumeLayout(False)
        Me.gpxInspectionSheet.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxMillCertData As System.Windows.Forms.GroupBox
    Friend WithEvents gpxChemicalMakeup As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpMillReceivingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtElongation As System.Windows.Forms.TextBox
    Friend WithEvents txtReductionOfArea As System.Windows.Forms.TextBox
    Friend WithEvents txtYield As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimateTensile As System.Windows.Forms.TextBox
    Friend WithEvents txtPoundsInHeat As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilsInHeat As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelPONumber As System.Windows.Forms.TextBox
    Friend WithEvents txtNitrogen As System.Windows.Forms.TextBox
    Friend WithEvents txtAluminum As System.Windows.Forms.TextBox
    Friend WithEvents txtVanadium As System.Windows.Forms.TextBox
    Friend WithEvents txtTin As System.Windows.Forms.TextBox
    Friend WithEvents txtCopper As System.Windows.Forms.TextBox
    Friend WithEvents txtMolybdenum As System.Windows.Forms.TextBox
    Friend WithEvents txtChromium As System.Windows.Forms.TextBox
    Friend WithEvents lblBoron As System.Windows.Forms.Label
    Friend WithEvents lblNitrogen As System.Windows.Forms.Label
    Friend WithEvents lblVanadium As System.Windows.Forms.Label
    Friend WithEvents lblAluminum As System.Windows.Forms.Label
    Friend WithEvents lblTin As System.Windows.Forms.Label
    Friend WithEvents lblMolybdenum As System.Windows.Forms.Label
    Friend WithEvents lblCopper As System.Windows.Forms.Label
    Friend WithEvents txtNickel As System.Windows.Forms.TextBox
    Friend WithEvents txtNiobium As System.Windows.Forms.TextBox
    Friend WithEvents txtSilicon As System.Windows.Forms.TextBox
    Friend WithEvents txtSulfur As System.Windows.Forms.TextBox
    Friend WithEvents txtPhosphorus As System.Windows.Forms.TextBox
    Friend WithEvents txtManganese As System.Windows.Forms.TextBox
    Friend WithEvents txtCarbon As System.Windows.Forms.TextBox
    Friend WithEvents lblChromium As System.Windows.Forms.Label
    Friend WithEvents lblNickel As System.Windows.Forms.Label
    Friend WithEvents lblSulfur As System.Windows.Forms.Label
    Friend WithEvents lblSilicon As System.Windows.Forms.Label
    Friend WithEvents lblPhosporus As System.Windows.Forms.Label
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents lblManganese As System.Windows.Forms.Label
    Friend WithEvents txtTitanium As System.Windows.Forms.TextBox
    Friend WithEvents lblTitanium As System.Windows.Forms.Label
    Friend WithEvents txtBoron As System.Windows.Forms.TextBox
    Friend WithEvents lblNiobium As System.Windows.Forms.Label
    Friend WithEvents txtLead As System.Windows.Forms.TextBox
    Friend WithEvents lblLead As System.Windows.Forms.Label
    Friend WithEvents lblCobalt As System.Windows.Forms.Label
    Friend WithEvents txtIron As System.Windows.Forms.TextBox
    Friend WithEvents txtZinc As System.Windows.Forms.TextBox
    Friend WithEvents lblZinc As System.Windows.Forms.Label
    Friend WithEvents lblIron As System.Windows.Forms.Label
    Friend WithEvents txtCobalt As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdPullTestData As System.Windows.Forms.Button
    Friend WithEvents cmdFOXForm As System.Windows.Forms.Button
    Friend WithEvents cmdViewLotNumbers As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents HighVanadium As System.Windows.Forms.Label
    Friend WithEvents LowVanadium As System.Windows.Forms.Label
    Friend WithEvents HighTin As System.Windows.Forms.Label
    Friend WithEvents LowTin As System.Windows.Forms.Label
    Friend WithEvents HighCopper As System.Windows.Forms.Label
    Friend WithEvents LowCopper As System.Windows.Forms.Label
    Friend WithEvents HighMolybdenum As System.Windows.Forms.Label
    Friend WithEvents LowMolybdenum As System.Windows.Forms.Label
    Friend WithEvents HighChromium As System.Windows.Forms.Label
    Friend WithEvents LowChromium As System.Windows.Forms.Label
    Friend WithEvents HighNickel As System.Windows.Forms.Label
    Friend WithEvents LowNickel As System.Windows.Forms.Label
    Friend WithEvents HighSilicon As System.Windows.Forms.Label
    Friend WithEvents LowSilicon As System.Windows.Forms.Label
    Friend WithEvents HighSulfur As System.Windows.Forms.Label
    Friend WithEvents LowSulfur As System.Windows.Forms.Label
    Friend WithEvents HighPhosporus As System.Windows.Forms.Label
    Friend WithEvents LowPhosporus As System.Windows.Forms.Label
    Friend WithEvents HighManganese As System.Windows.Forms.Label
    Friend WithEvents LowManganese As System.Windows.Forms.Label
    Friend WithEvents HighCarbon As System.Windows.Forms.Label
    Friend WithEvents LowCarbon As System.Windows.Forms.Label
    Friend WithEvents HighCobalt As System.Windows.Forms.Label
    Friend WithEvents LowCobalt As System.Windows.Forms.Label
    Friend WithEvents HighLead As System.Windows.Forms.Label
    Friend WithEvents LowLead As System.Windows.Forms.Label
    Friend WithEvents HighZinc As System.Windows.Forms.Label
    Friend WithEvents LowZinc As System.Windows.Forms.Label
    Friend WithEvents HighIron As System.Windows.Forms.Label
    Friend WithEvents LowIron As System.Windows.Forms.Label
    Friend WithEvents HighNiobium As System.Windows.Forms.Label
    Friend WithEvents LowNiobium As System.Windows.Forms.Label
    Friend WithEvents HighTitanium As System.Windows.Forms.Label
    Friend WithEvents LowTitanium As System.Windows.Forms.Label
    Friend WithEvents HighBoron As System.Windows.Forms.Label
    Friend WithEvents LowBoron As System.Windows.Forms.Label
    Friend WithEvents HighNitrogen As System.Windows.Forms.Label
    Friend WithEvents LowNitrogen As System.Windows.Forms.Label
    Friend WithEvents HighAluminum As System.Windows.Forms.Label
    Friend WithEvents LowAluminum As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpbxFinalize As System.Windows.Forms.GroupBox
    Friend WithEvents lblCEV As System.Windows.Forms.Label
    Friend WithEvents txtCEV As System.Windows.Forms.TextBox
    Friend WithEvents cboSteelCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents bgwkLoadChemicalCompounds As System.ComponentModel.BackgroundWorker
    Friend WithEvents cboHeatFileNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblHeatFileNumber As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateHeatFileNumber As System.Windows.Forms.Button
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents UnLockCompositionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnLockMillCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboMaterialOrigin As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblColorCode As System.Windows.Forms.Label
    Friend WithEvents HighTungsten As System.Windows.Forms.Label
    Friend WithEvents LowTungsten As System.Windows.Forms.Label
    Friend WithEvents lblTungsten As System.Windows.Forms.Label
    Friend WithEvents txtTungsten As System.Windows.Forms.TextBox
    Friend WithEvents gpxInspectionSheet As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectFile As System.Windows.Forms.Button
    Friend WithEvents txtBOLNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblFileCountMessage As System.Windows.Forms.Label
    Friend WithEvents ViewReceivingInspectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HighMagnesium As System.Windows.Forms.Label
    Friend WithEvents LowMagnesium As System.Windows.Forms.Label
    Friend WithEvents lblMagnesium As System.Windows.Forms.Label
    Friend WithEvents txtMagnesium As System.Windows.Forms.TextBox
End Class
