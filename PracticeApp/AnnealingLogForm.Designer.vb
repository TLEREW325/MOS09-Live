<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnealingLogForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintSampleTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockAnnealToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.gpxSelectLotNumber = New System.Windows.Forms.GroupBox
        Me.txtNumberOfCoils = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.dtpLotCreationDate = New System.Windows.Forms.DateTimePicker
        Me.cmdGenerateNew = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboAnnealLotNumber = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblLotNumber = New System.Windows.Forms.Label
        Me.txtSteelDescription = New System.Windows.Forms.TextBox
        Me.cboCoilID = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.txtCoilWeight = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.txtPreviousLot = New System.Windows.Forms.TextBox
        Me.dtpDateOut = New System.Windows.Forms.DateTimePicker
        Me.dtpDateIn = New System.Windows.Forms.DateTimePicker
        Me.txtBase = New System.Windows.Forms.TextBox
        Me.txtProgram = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.gpxSteelType = New System.Windows.Forms.GroupBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.txtAnnealSteelSize = New System.Windows.Forms.TextBox
        Me.txtAnnealCarbon = New System.Windows.Forms.TextBox
        Me.cmdAddCoil = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtAnnealedDescription = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dgvAnnealLotLines = New System.Windows.Forms.DataGridView
        Me.gpxLotData = New System.Windows.Forms.GroupBox
        Me.lblComments = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.lblQCMessage = New System.Windows.Forms.Label
        Me.gpxCoilsInLot = New System.Windows.Forms.GroupBox
        Me.txtCoilSize = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCoilCarbon = New System.Windows.Forms.TextBox
        Me.lblCoilCarbon = New System.Windows.Forms.Label
        Me.cboDeleteCoilID = New System.Windows.Forms.ComboBox
        Me.cmdRemoveCoil = New System.Windows.Forms.Button
        Me.cmdSplitCoil = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdPostAnnealingLot = New System.Windows.Forms.Button
        Me.tmrWaitToPrint = New System.Windows.Forms.Timer(Me.components)
        Me.bgwkCoilID = New System.ComponentModel.BackgroundWorker
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdThree = New System.Windows.Forms.Button
        Me.cmdTwo = New System.Windows.Forms.Button
        Me.cmdOne = New System.Windows.Forms.Button
        Me.cmdDecimal = New System.Windows.Forms.Button
        Me.cmdZero = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdNine = New System.Windows.Forms.Button
        Me.cmdEight = New System.Windows.Forms.Button
        Me.cmdSeven = New System.Windows.Forms.Button
        Me.cmdSix = New System.Windows.Forms.Button
        Me.cmdFive = New System.Windows.Forms.Button
        Me.cmdFour = New System.Windows.Forms.Button
        Me.cmdA = New System.Windows.Forms.Button
        Me.cmdDash = New System.Windows.Forms.Button
        Me.cmdForwardSlash = New System.Windows.Forms.Button
        Me.cmdBackspace = New System.Windows.Forms.Button
        Me.lstAnnealingSuggest = New System.Windows.Forms.ListBox
        Me.lstCarbonSuggest = New System.Windows.Forms.ListBox
        Me.lstSizeSuggest = New System.Windows.Forms.ListBox
        Me.lstCoilIDSuggest = New System.Windows.Forms.ListBox
        Me.cmdQ = New System.Windows.Forms.Button
        Me.cmdW = New System.Windows.Forms.Button
        Me.cmdE = New System.Windows.Forms.Button
        Me.cmdR = New System.Windows.Forms.Button
        Me.cmdT = New System.Windows.Forms.Button
        Me.cmdY = New System.Windows.Forms.Button
        Me.cmdU = New System.Windows.Forms.Button
        Me.cmdI = New System.Windows.Forms.Button
        Me.cmdO = New System.Windows.Forms.Button
        Me.cmdP = New System.Windows.Forms.Button
        Me.cmdZ = New System.Windows.Forms.Button
        Me.cmdL = New System.Windows.Forms.Button
        Me.cmdK = New System.Windows.Forms.Button
        Me.cmdJ = New System.Windows.Forms.Button
        Me.cmdH = New System.Windows.Forms.Button
        Me.cmdG = New System.Windows.Forms.Button
        Me.cmdF = New System.Windows.Forms.Button
        Me.cmdD = New System.Windows.Forms.Button
        Me.cmdS = New System.Windows.Forms.Button
        Me.cmdM = New System.Windows.Forms.Button
        Me.cmdN = New System.Windows.Forms.Button
        Me.cmdB = New System.Windows.Forms.Button
        Me.cmdV = New System.Windows.Forms.Button
        Me.cmdC = New System.Windows.Forms.Button
        Me.cmdX = New System.Windows.Forms.Button
        Me.cmdSpace = New System.Windows.Forms.Button
        Me.bgwkCoilIDSuggest = New System.ComponentModel.BackgroundWorker
        Me.tabAnnealLotData = New System.Windows.Forms.TabControl
        Me.tbAnnealingData = New System.Windows.Forms.TabPage
        Me.tbTestResults = New System.Windows.Forms.TabPage
        Me.grpTestResults = New System.Windows.Forms.GroupBox
        Me.txtSurfaceHardness = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtFreeFerrite = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtTensile = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSampleMicro = New System.Windows.Forms.TextBox
        Me.txtSampleBox = New System.Windows.Forms.TextBox
        Me.txtCoreHardness = New System.Windows.Forms.TextBox
        Me.txtSpheroid = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtTotalDecarb = New System.Windows.Forms.TextBox
        Me.tmrScanTime = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSelectLotNumber.SuspendLayout()
        Me.gpxSteelType.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvAnnealLotLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxLotData.SuspendLayout()
        Me.gpxCoilsInLot.SuspendLayout()
        Me.tabAnnealLotData.SuspendLayout()
        Me.tbAnnealingData.SuspendLayout()
        Me.tbTestResults.SuspendLayout()
        Me.grpTestResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1194, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDataToolStripMenuItem, Me.DeleteDataToolStripMenuItem, Me.PrintDataToolStripMenuItem, Me.ClearDataToolStripMenuItem, Me.PrintSampleTagToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 25)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'DeleteDataToolStripMenuItem
        '
        Me.DeleteDataToolStripMenuItem.Name = "DeleteDataToolStripMenuItem"
        Me.DeleteDataToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.DeleteDataToolStripMenuItem.Text = "Delete Data"
        '
        'PrintDataToolStripMenuItem
        '
        Me.PrintDataToolStripMenuItem.Name = "PrintDataToolStripMenuItem"
        Me.PrintDataToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.PrintDataToolStripMenuItem.Text = "Print Data"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'PrintSampleTagToolStripMenuItem
        '
        Me.PrintSampleTagToolStripMenuItem.Enabled = False
        Me.PrintSampleTagToolStripMenuItem.Name = "PrintSampleTagToolStripMenuItem"
        Me.PrintSampleTagToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.PrintSampleTagToolStripMenuItem.Text = "Print Sample Tag"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateTotalToolStripMenuItem, Me.UnLockAnnealToolStripMenuItem})
        Me.EditToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UpdateTotalToolStripMenuItem
        '
        Me.UpdateTotalToolStripMenuItem.Name = "UpdateTotalToolStripMenuItem"
        Me.UpdateTotalToolStripMenuItem.Size = New System.Drawing.Size(186, 26)
        Me.UpdateTotalToolStripMenuItem.Text = "Update Total"
        Me.UpdateTotalToolStripMenuItem.Visible = False
        '
        'UnLockAnnealToolStripMenuItem
        '
        Me.UnLockAnnealToolStripMenuItem.Name = "UnLockAnnealToolStripMenuItem"
        Me.UnLockAnnealToolStripMenuItem.Size = New System.Drawing.Size(186, 26)
        Me.UnLockAnnealToolStripMenuItem.Text = "Un-LockAnneal"
        Me.UnLockAnnealToolStripMenuItem.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(46, 25)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(104, 26)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(834, 363)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(100, 50)
        Me.cmdPrint.TabIndex = 44
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(722, 363)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(100, 87)
        Me.cmdSave.TabIndex = 42
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(1082, 662)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(100, 50)
        Me.cmdExit.TabIndex = 45
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(943, 363)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(100, 90)
        Me.cmdDelete.TabIndex = 43
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'gpxSelectLotNumber
        '
        Me.gpxSelectLotNumber.Controls.Add(Me.txtNumberOfCoils)
        Me.gpxSelectLotNumber.Controls.Add(Me.Label39)
        Me.gpxSelectLotNumber.Controls.Add(Me.txtTotalWeight)
        Me.gpxSelectLotNumber.Controls.Add(Me.Label38)
        Me.gpxSelectLotNumber.Controls.Add(Me.Label37)
        Me.gpxSelectLotNumber.Controls.Add(Me.dtpLotCreationDate)
        Me.gpxSelectLotNumber.Controls.Add(Me.cmdGenerateNew)
        Me.gpxSelectLotNumber.Controls.Add(Me.Label1)
        Me.gpxSelectLotNumber.Controls.Add(Me.cboAnnealLotNumber)
        Me.gpxSelectLotNumber.Controls.Add(Me.cboDivisionID)
        Me.gpxSelectLotNumber.Controls.Add(Me.Label13)
        Me.gpxSelectLotNumber.Location = New System.Drawing.Point(16, 32)
        Me.gpxSelectLotNumber.Name = "gpxSelectLotNumber"
        Me.gpxSelectLotNumber.Size = New System.Drawing.Size(350, 191)
        Me.gpxSelectLotNumber.TabIndex = 0
        Me.gpxSelectLotNumber.TabStop = False
        Me.gpxSelectLotNumber.Text = "Anneal Lot Number"
        '
        'txtNumberOfCoils
        '
        Me.txtNumberOfCoils.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfCoils.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfCoils.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfCoils.Location = New System.Drawing.Point(178, 159)
        Me.txtNumberOfCoils.MaxLength = 50
        Me.txtNumberOfCoils.Name = "txtNumberOfCoils"
        Me.txtNumberOfCoils.ReadOnly = True
        Me.txtNumberOfCoils.Size = New System.Drawing.Size(159, 26)
        Me.txtNumberOfCoils.TabIndex = 5
        Me.txtNumberOfCoils.TabStop = False
        Me.txtNumberOfCoils.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(12, 159)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(137, 20)
        Me.Label39.TabIndex = 78
        Me.Label39.Text = "Number Of Coils"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalWeight.Location = New System.Drawing.Point(178, 121)
        Me.txtTotalWeight.MaxLength = 50
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.ReadOnly = True
        Me.txtTotalWeight.Size = New System.Drawing.Size(159, 26)
        Me.txtTotalWeight.TabIndex = 4
        Me.txtTotalWeight.TabStop = False
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(6, 117)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(170, 32)
        Me.Label38.TabIndex = 74
        Me.Label38.Text = "Total Annealed Weight"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(6, 89)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(136, 20)
        Me.Label37.TabIndex = 72
        Me.Label37.Text = "Lot Creation Date"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpLotCreationDate
        '
        Me.dtpLotCreationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLotCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLotCreationDate.Location = New System.Drawing.Point(178, 88)
        Me.dtpLotCreationDate.Name = "dtpLotCreationDate"
        Me.dtpLotCreationDate.Size = New System.Drawing.Size(159, 26)
        Me.dtpLotCreationDate.TabIndex = 3
        '
        'cmdGenerateNew
        '
        Me.cmdGenerateNew.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNew.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNew.Location = New System.Drawing.Point(102, 19)
        Me.cmdGenerateNew.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNew.Name = "cmdGenerateNew"
        Me.cmdGenerateNew.Size = New System.Drawing.Size(63, 30)
        Me.cmdGenerateNew.TabIndex = 0
        Me.cmdGenerateNew.TabStop = False
        Me.cmdGenerateNew.Text = ">>"
        Me.cmdGenerateNew.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 20)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Anneal Lot Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAnnealLotNumber
        '
        Me.cboAnnealLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAnnealLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAnnealLotNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnnealLotNumber.FormattingEnabled = True
        Me.cboAnnealLotNumber.Location = New System.Drawing.Point(178, 19)
        Me.cboAnnealLotNumber.Name = "cboAnnealLotNumber"
        Me.cboAnnealLotNumber.Size = New System.Drawing.Size(159, 28)
        Me.cboAnnealLotNumber.TabIndex = 1
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(178, 54)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(159, 28)
        Me.cboDivisionID.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 20)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Division ID"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLotNumber
        '
        Me.lblLotNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLotNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotNumber.Location = New System.Drawing.Point(23, 19)
        Me.lblLotNumber.Name = "lblLotNumber"
        Me.lblLotNumber.Size = New System.Drawing.Size(76, 20)
        Me.lblLotNumber.TabIndex = 72
        Me.lblLotNumber.Text = "Coil ID"
        Me.lblLotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelDescription
        '
        Me.txtSteelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSteelDescription.Location = New System.Drawing.Point(15, 105)
        Me.txtSteelDescription.Multiline = True
        Me.txtSteelDescription.Name = "txtSteelDescription"
        Me.txtSteelDescription.ReadOnly = True
        Me.txtSteelDescription.Size = New System.Drawing.Size(318, 40)
        Me.txtSteelDescription.TabIndex = 9
        Me.txtSteelDescription.TabStop = False
        Me.txtSteelDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCoilID
        '
        Me.cboCoilID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboCoilID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCoilID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCoilID.FormattingEnabled = True
        Me.cboCoilID.Location = New System.Drawing.Point(133, 15)
        Me.cboCoilID.Name = "cboCoilID"
        Me.cboCoilID.Size = New System.Drawing.Size(188, 28)
        Me.cboCoilID.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 20)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Steel Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeatNumber.Location = New System.Drawing.Point(153, 19)
        Me.txtHeatNumber.MaxLength = 50
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(154, 26)
        Me.txtHeatNumber.TabIndex = 14
        Me.txtHeatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoilWeight
        '
        Me.txtCoilWeight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCoilWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilWeight.Location = New System.Drawing.Point(133, 111)
        Me.txtCoilWeight.Name = "txtCoilWeight"
        Me.txtCoilWeight.ReadOnly = True
        Me.txtCoilWeight.Size = New System.Drawing.Size(188, 26)
        Me.txtCoilWeight.TabIndex = 35
        Me.txtCoilWeight.TabStop = False
        Me.txtCoilWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 20)
        Me.Label12.TabIndex = 71
        Me.Label12.Text = "Heat Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(23, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 20)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Coil Weight"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Steel Size"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Carbon"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.Location = New System.Drawing.Point(834, 429)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(100, 50)
        Me.cmdClearAll.TabIndex = 38
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'txtPreviousLot
        '
        Me.txtPreviousLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPreviousLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPreviousLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreviousLot.Location = New System.Drawing.Point(153, 150)
        Me.txtPreviousLot.MaxLength = 50
        Me.txtPreviousLot.Name = "txtPreviousLot"
        Me.txtPreviousLot.Size = New System.Drawing.Size(154, 26)
        Me.txtPreviousLot.TabIndex = 25
        Me.txtPreviousLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDateOut
        '
        Me.dtpDateOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateOut.Location = New System.Drawing.Point(153, 118)
        Me.dtpDateOut.Name = "dtpDateOut"
        Me.dtpDateOut.Size = New System.Drawing.Size(154, 26)
        Me.dtpDateOut.TabIndex = 18
        '
        'dtpDateIn
        '
        Me.dtpDateIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateIn.Location = New System.Drawing.Point(153, 86)
        Me.dtpDateIn.Name = "dtpDateIn"
        Me.dtpDateIn.Size = New System.Drawing.Size(154, 26)
        Me.dtpDateIn.TabIndex = 17
        '
        'txtBase
        '
        Me.txtBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBase.Location = New System.Drawing.Point(57, 54)
        Me.txtBase.MaxLength = 50
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(70, 26)
        Me.txtBase.TabIndex = 15
        Me.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProgram
        '
        Me.txtProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProgram.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgram.Location = New System.Drawing.Point(237, 54)
        Me.txtProgram.MaxLength = 50
        Me.txtProgram.Name = "txtProgram"
        Me.txtProgram.Size = New System.Drawing.Size(70, 26)
        Me.txtProgram.TabIndex = 16
        Me.txtProgram.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 156)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(137, 20)
        Me.Label27.TabIndex = 96
        Me.Label27.Text = "Previous Anneal Lot #"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 20)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "Base"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(152, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 20)
        Me.Label16.TabIndex = 75
        Me.Label16.Text = "Program #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 92)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(127, 20)
        Me.Label19.TabIndex = 78
        Me.Label19.Text = "Date In"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 124)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 20)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Date Out"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxSteelType
        '
        Me.gpxSteelType.Controls.Add(Me.txtSteelDescription)
        Me.gpxSteelType.Controls.Add(Me.Label6)
        Me.gpxSteelType.Controls.Add(Me.cboSteelSize)
        Me.gpxSteelType.Controls.Add(Me.cboCarbon)
        Me.gpxSteelType.Controls.Add(Me.Label3)
        Me.gpxSteelType.Controls.Add(Me.Label4)
        Me.gpxSteelType.Location = New System.Drawing.Point(16, 224)
        Me.gpxSteelType.Name = "gpxSteelType"
        Me.gpxSteelType.Size = New System.Drawing.Size(350, 151)
        Me.gpxSteelType.TabIndex = 6
        Me.gpxSteelType.TabStop = False
        Me.gpxSteelType.Text = "Steel Data"
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(177, 53)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(159, 28)
        Me.cboSteelSize.TabIndex = 11
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(177, 19)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(159, 28)
        Me.cboCarbon.TabIndex = 10
        '
        'txtAnnealSteelSize
        '
        Me.txtAnnealSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnnealSteelSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnnealSteelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnealSteelSize.Location = New System.Drawing.Point(155, 54)
        Me.txtAnnealSteelSize.MaxLength = 50
        Me.txtAnnealSteelSize.Name = "txtAnnealSteelSize"
        Me.txtAnnealSteelSize.Size = New System.Drawing.Size(180, 26)
        Me.txtAnnealSteelSize.TabIndex = 111
        Me.txtAnnealSteelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAnnealCarbon
        '
        Me.txtAnnealCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnnealCarbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnnealCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnealCarbon.Location = New System.Drawing.Point(156, 22)
        Me.txtAnnealCarbon.MaxLength = 50
        Me.txtAnnealCarbon.Name = "txtAnnealCarbon"
        Me.txtAnnealCarbon.Size = New System.Drawing.Size(180, 26)
        Me.txtAnnealCarbon.TabIndex = 110
        Me.txtAnnealCarbon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdAddCoil
        '
        Me.cmdAddCoil.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdAddCoil.Location = New System.Drawing.Point(221, 143)
        Me.cmdAddCoil.Name = "cmdAddCoil"
        Me.cmdAddCoil.Size = New System.Drawing.Size(100, 50)
        Me.cmdAddCoil.TabIndex = 36
        Me.cmdAddCoil.Text = "Add Coil"
        Me.cmdAddCoil.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAnnealSteelSize)
        Me.GroupBox3.Controls.Add(Me.txtAnnealedDescription)
        Me.GroupBox3.Controls.Add(Me.txtAnnealCarbon)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 381)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(350, 157)
        Me.GroupBox3.TabIndex = 77
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Annealed Steel Data"
        '
        'txtAnnealedDescription
        '
        Me.txtAnnealedDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnnealedDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnnealedDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnealedDescription.Location = New System.Drawing.Point(19, 108)
        Me.txtAnnealedDescription.Multiline = True
        Me.txtAnnealedDescription.Name = "txtAnnealedDescription"
        Me.txtAnnealedDescription.ReadOnly = True
        Me.txtAnnealedDescription.Size = New System.Drawing.Size(318, 38)
        Me.txtAnnealedDescription.TabIndex = 13
        Me.txtAnnealedDescription.TabStop = False
        Me.txtAnnealedDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 20)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Steel Description"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Carbon"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "Steel Size"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvAnnealLotLines
        '
        Me.dgvAnnealLotLines.AllowUserToAddRows = False
        Me.dgvAnnealLotLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnnealLotLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAnnealLotLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAnnealLotLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAnnealLotLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAnnealLotLines.Location = New System.Drawing.Point(17, 219)
        Me.dgvAnnealLotLines.Name = "dgvAnnealLotLines"
        Me.dgvAnnealLotLines.ReadOnly = True
        Me.dgvAnnealLotLines.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAnnealLotLines.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAnnealLotLines.Size = New System.Drawing.Size(304, 227)
        Me.dgvAnnealLotLines.TabIndex = 37
        Me.dgvAnnealLotLines.TabStop = False
        '
        'gpxLotData
        '
        Me.gpxLotData.Controls.Add(Me.lblComments)
        Me.gpxLotData.Controls.Add(Me.txtComments)
        Me.gpxLotData.Controls.Add(Me.txtHeatNumber)
        Me.gpxLotData.Controls.Add(Me.txtBase)
        Me.gpxLotData.Controls.Add(Me.txtPreviousLot)
        Me.gpxLotData.Controls.Add(Me.dtpDateOut)
        Me.gpxLotData.Controls.Add(Me.dtpDateIn)
        Me.gpxLotData.Controls.Add(Me.Label12)
        Me.gpxLotData.Controls.Add(Me.txtProgram)
        Me.gpxLotData.Controls.Add(Me.Label18)
        Me.gpxLotData.Controls.Add(Me.Label27)
        Me.gpxLotData.Controls.Add(Me.Label19)
        Me.gpxLotData.Controls.Add(Me.Label16)
        Me.gpxLotData.Controls.Add(Me.Label17)
        Me.gpxLotData.Location = New System.Drawing.Point(6, 3)
        Me.gpxLotData.Name = "gpxLotData"
        Me.gpxLotData.Size = New System.Drawing.Size(316, 300)
        Me.gpxLotData.TabIndex = 14
        Me.gpxLotData.TabStop = False
        Me.gpxLotData.Text = "Annealing Lot Data"
        '
        'lblComments
        '
        Me.lblComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComments.Location = New System.Drawing.Point(0, 215)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(127, 20)
        Me.lblComments.TabIndex = 109
        Me.lblComments.Text = "Comment"
        Me.lblComments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(0, 239)
        Me.txtComments.MaxLength = 200
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(307, 53)
        Me.txtComments.TabIndex = 33
        Me.txtComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblQCMessage
        '
        Me.lblQCMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQCMessage.ForeColor = System.Drawing.Color.Green
        Me.lblQCMessage.Location = New System.Drawing.Point(359, 130)
        Me.lblQCMessage.Name = "lblQCMessage"
        Me.lblQCMessage.Size = New System.Drawing.Size(510, 103)
        Me.lblQCMessage.TabIndex = 112
        Me.lblQCMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblQCMessage.Visible = False
        '
        'gpxCoilsInLot
        '
        Me.gpxCoilsInLot.Controls.Add(Me.txtCoilSize)
        Me.gpxCoilsInLot.Controls.Add(Me.Label5)
        Me.gpxCoilsInLot.Controls.Add(Me.txtCoilCarbon)
        Me.gpxCoilsInLot.Controls.Add(Me.lblCoilCarbon)
        Me.gpxCoilsInLot.Controls.Add(Me.cboDeleteCoilID)
        Me.gpxCoilsInLot.Controls.Add(Me.cmdRemoveCoil)
        Me.gpxCoilsInLot.Controls.Add(Me.cmdSplitCoil)
        Me.gpxCoilsInLot.Controls.Add(Me.Label10)
        Me.gpxCoilsInLot.Controls.Add(Me.cmdAddCoil)
        Me.gpxCoilsInLot.Controls.Add(Me.dgvAnnealLotLines)
        Me.gpxCoilsInLot.Controls.Add(Me.cboCoilID)
        Me.gpxCoilsInLot.Controls.Add(Me.lblLotNumber)
        Me.gpxCoilsInLot.Controls.Add(Me.txtCoilWeight)
        Me.gpxCoilsInLot.Controls.Add(Me.Label9)
        Me.gpxCoilsInLot.Location = New System.Drawing.Point(372, 32)
        Me.gpxCoilsInLot.Name = "gpxCoilsInLot"
        Me.gpxCoilsInLot.Size = New System.Drawing.Size(334, 507)
        Me.gpxCoilsInLot.TabIndex = 34
        Me.gpxCoilsInLot.TabStop = False
        Me.gpxCoilsInLot.Text = "Steel Coils in Annealed Lot"
        '
        'txtCoilSize
        '
        Me.txtCoilSize.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCoilSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilSize.Location = New System.Drawing.Point(133, 79)
        Me.txtCoilSize.Name = "txtCoilSize"
        Me.txtCoilSize.ReadOnly = True
        Me.txtCoilSize.Size = New System.Drawing.Size(188, 26)
        Me.txtCoilSize.TabIndex = 82
        Me.txtCoilSize.TabStop = False
        Me.txtCoilSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Coil Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoilCarbon
        '
        Me.txtCoilCarbon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCoilCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilCarbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilCarbon.Location = New System.Drawing.Point(133, 47)
        Me.txtCoilCarbon.Name = "txtCoilCarbon"
        Me.txtCoilCarbon.ReadOnly = True
        Me.txtCoilCarbon.Size = New System.Drawing.Size(188, 26)
        Me.txtCoilCarbon.TabIndex = 80
        Me.txtCoilCarbon.TabStop = False
        Me.txtCoilCarbon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCoilCarbon
        '
        Me.lblCoilCarbon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCoilCarbon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilCarbon.Location = New System.Drawing.Point(23, 47)
        Me.lblCoilCarbon.Name = "lblCoilCarbon"
        Me.lblCoilCarbon.Size = New System.Drawing.Size(88, 20)
        Me.lblCoilCarbon.TabIndex = 81
        Me.lblCoilCarbon.Text = "Coil Carbon"
        Me.lblCoilCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeleteCoilID
        '
        Me.cboDeleteCoilID.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cboDeleteCoilID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteCoilID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteCoilID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDeleteCoilID.FormattingEnabled = True
        Me.cboDeleteCoilID.Location = New System.Drawing.Point(17, 465)
        Me.cboDeleteCoilID.Name = "cboDeleteCoilID"
        Me.cboDeleteCoilID.Size = New System.Drawing.Size(188, 28)
        Me.cboDeleteCoilID.TabIndex = 79
        '
        'cmdRemoveCoil
        '
        Me.cmdRemoveCoil.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdRemoveCoil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveCoil.Location = New System.Drawing.Point(221, 454)
        Me.cmdRemoveCoil.Name = "cmdRemoveCoil"
        Me.cmdRemoveCoil.Size = New System.Drawing.Size(100, 50)
        Me.cmdRemoveCoil.TabIndex = 78
        Me.cmdRemoveCoil.Text = "Remove Selected"
        Me.cmdRemoveCoil.UseVisualStyleBackColor = True
        '
        'cmdSplitCoil
        '
        Me.cmdSplitCoil.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdSplitCoil.Location = New System.Drawing.Point(17, 143)
        Me.cmdSplitCoil.Name = "cmdSplitCoil"
        Me.cmdSplitCoil.Size = New System.Drawing.Size(100, 50)
        Me.cmdSplitCoil.TabIndex = 75
        Me.cmdSplitCoil.Text = "Split Coil"
        Me.cmdSplitCoil.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(13, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(308, 20)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Coils in Annealing Lot"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdPostAnnealingLot
        '
        Me.cmdPostAnnealingLot.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPostAnnealingLot.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostAnnealingLot.Location = New System.Drawing.Point(722, 459)
        Me.cmdPostAnnealingLot.Name = "cmdPostAnnealingLot"
        Me.cmdPostAnnealingLot.Size = New System.Drawing.Size(100, 87)
        Me.cmdPostAnnealingLot.TabIndex = 78
        Me.cmdPostAnnealingLot.Text = "Post Annealing"
        Me.cmdPostAnnealingLot.UseVisualStyleBackColor = True
        '
        'tmrWaitToPrint
        '
        Me.tmrWaitToPrint.Interval = 5000
        '
        'bgwkCoilID
        '
        Me.bgwkCoilID.WorkerSupportsCancellation = True
        '
        'cmdEnter
        '
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(1082, 606)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(100, 50)
        Me.cmdEnter.TabIndex = 84
        Me.cmdEnter.TabStop = False
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(1082, 213)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(100, 50)
        Me.cmdThree.TabIndex = 83
        Me.cmdThree.TabStop = False
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdTwo
        '
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(1082, 157)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(100, 50)
        Me.cmdTwo.TabIndex = 82
        Me.cmdTwo.TabStop = False
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(1082, 101)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(100, 50)
        Me.cmdOne.TabIndex = 81
        Me.cmdOne.TabStop = False
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdDecimal
        '
        Me.cmdDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecimal.Location = New System.Drawing.Point(972, 606)
        Me.cmdDecimal.Name = "cmdDecimal"
        Me.cmdDecimal.Size = New System.Drawing.Size(100, 50)
        Me.cmdDecimal.TabIndex = 80
        Me.cmdDecimal.TabStop = False
        Me.cmdDecimal.Text = "."
        Me.cmdDecimal.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(1082, 45)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(100, 50)
        Me.cmdZero.TabIndex = 79
        Me.cmdZero.TabStop = False
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(834, 493)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(100, 50)
        Me.cmdClear.TabIndex = 91
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Clear Selection"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(1082, 549)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(100, 50)
        Me.cmdNine.TabIndex = 90
        Me.cmdNine.TabStop = False
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(1082, 493)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(100, 50)
        Me.cmdEight.TabIndex = 89
        Me.cmdEight.TabStop = False
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(1082, 437)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(100, 50)
        Me.cmdSeven.TabIndex = 88
        Me.cmdSeven.TabStop = False
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(1082, 381)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(100, 50)
        Me.cmdSix.TabIndex = 87
        Me.cmdSix.TabStop = False
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(1082, 325)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(100, 50)
        Me.cmdFive.TabIndex = 86
        Me.cmdFive.TabStop = False
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(1082, 269)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(100, 50)
        Me.cmdFour.TabIndex = 85
        Me.cmdFour.TabStop = False
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdA
        '
        Me.cmdA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdA.Location = New System.Drawing.Point(17, 605)
        Me.cmdA.Name = "cmdA"
        Me.cmdA.Size = New System.Drawing.Size(100, 50)
        Me.cmdA.TabIndex = 93
        Me.cmdA.TabStop = False
        Me.cmdA.Text = "A"
        Me.cmdA.UseVisualStyleBackColor = True
        '
        'cmdDash
        '
        Me.cmdDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDash.Location = New System.Drawing.Point(865, 661)
        Me.cmdDash.Name = "cmdDash"
        Me.cmdDash.Size = New System.Drawing.Size(100, 50)
        Me.cmdDash.TabIndex = 99
        Me.cmdDash.TabStop = False
        Me.cmdDash.Text = "-"
        Me.cmdDash.UseVisualStyleBackColor = True
        '
        'cmdForwardSlash
        '
        Me.cmdForwardSlash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdForwardSlash.Location = New System.Drawing.Point(759, 661)
        Me.cmdForwardSlash.Name = "cmdForwardSlash"
        Me.cmdForwardSlash.Size = New System.Drawing.Size(100, 50)
        Me.cmdForwardSlash.TabIndex = 98
        Me.cmdForwardSlash.TabStop = False
        Me.cmdForwardSlash.Text = "/"
        Me.cmdForwardSlash.UseVisualStyleBackColor = True
        '
        'cmdBackspace
        '
        Me.cmdBackspace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackspace.Location = New System.Drawing.Point(943, 459)
        Me.cmdBackspace.Name = "cmdBackspace"
        Me.cmdBackspace.Size = New System.Drawing.Size(100, 87)
        Me.cmdBackspace.TabIndex = 100
        Me.cmdBackspace.TabStop = False
        Me.cmdBackspace.Text = "Backspace"
        Me.cmdBackspace.UseVisualStyleBackColor = True
        '
        'lstAnnealingSuggest
        '
        Me.lstAnnealingSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAnnealingSuggest.FormattingEnabled = True
        Me.lstAnnealingSuggest.ItemHeight = 20
        Me.lstAnnealingSuggest.Location = New System.Drawing.Point(194, 79)
        Me.lstAnnealingSuggest.Name = "lstAnnealingSuggest"
        Me.lstAnnealingSuggest.Size = New System.Drawing.Size(159, 84)
        Me.lstAnnealingSuggest.TabIndex = 79
        Me.lstAnnealingSuggest.TabStop = False
        Me.lstAnnealingSuggest.Visible = False
        '
        'lstCarbonSuggest
        '
        Me.lstCarbonSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCarbonSuggest.FormattingEnabled = True
        Me.lstCarbonSuggest.ItemHeight = 20
        Me.lstCarbonSuggest.Location = New System.Drawing.Point(193, 271)
        Me.lstCarbonSuggest.Name = "lstCarbonSuggest"
        Me.lstCarbonSuggest.Size = New System.Drawing.Size(159, 84)
        Me.lstCarbonSuggest.TabIndex = 101
        Me.lstCarbonSuggest.TabStop = False
        Me.lstCarbonSuggest.Visible = False
        '
        'lstSizeSuggest
        '
        Me.lstSizeSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSizeSuggest.FormattingEnabled = True
        Me.lstSizeSuggest.ItemHeight = 20
        Me.lstSizeSuggest.Location = New System.Drawing.Point(193, 303)
        Me.lstSizeSuggest.Name = "lstSizeSuggest"
        Me.lstSizeSuggest.Size = New System.Drawing.Size(159, 84)
        Me.lstSizeSuggest.TabIndex = 74
        Me.lstSizeSuggest.TabStop = False
        Me.lstSizeSuggest.Visible = False
        '
        'lstCoilIDSuggest
        '
        Me.lstCoilIDSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCoilIDSuggest.FormattingEnabled = True
        Me.lstCoilIDSuggest.ItemHeight = 20
        Me.lstCoilIDSuggest.Location = New System.Drawing.Point(493, 75)
        Me.lstCoilIDSuggest.Name = "lstCoilIDSuggest"
        Me.lstCoilIDSuggest.Size = New System.Drawing.Size(200, 84)
        Me.lstCoilIDSuggest.TabIndex = 102
        Me.lstCoilIDSuggest.TabStop = False
        Me.lstCoilIDSuggest.Visible = False
        '
        'cmdQ
        '
        Me.cmdQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQ.Location = New System.Drawing.Point(17, 549)
        Me.cmdQ.Name = "cmdQ"
        Me.cmdQ.Size = New System.Drawing.Size(100, 50)
        Me.cmdQ.TabIndex = 103
        Me.cmdQ.TabStop = False
        Me.cmdQ.Text = "Q"
        Me.cmdQ.UseVisualStyleBackColor = True
        '
        'cmdW
        '
        Me.cmdW.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdW.Location = New System.Drawing.Point(123, 549)
        Me.cmdW.Name = "cmdW"
        Me.cmdW.Size = New System.Drawing.Size(100, 50)
        Me.cmdW.TabIndex = 104
        Me.cmdW.TabStop = False
        Me.cmdW.Text = "W"
        Me.cmdW.UseVisualStyleBackColor = True
        '
        'cmdE
        '
        Me.cmdE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdE.Location = New System.Drawing.Point(229, 549)
        Me.cmdE.Name = "cmdE"
        Me.cmdE.Size = New System.Drawing.Size(100, 50)
        Me.cmdE.TabIndex = 105
        Me.cmdE.TabStop = False
        Me.cmdE.Text = "E"
        Me.cmdE.UseVisualStyleBackColor = True
        '
        'cmdR
        '
        Me.cmdR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdR.Location = New System.Drawing.Point(335, 550)
        Me.cmdR.Name = "cmdR"
        Me.cmdR.Size = New System.Drawing.Size(100, 50)
        Me.cmdR.TabIndex = 106
        Me.cmdR.TabStop = False
        Me.cmdR.Text = "R"
        Me.cmdR.UseVisualStyleBackColor = True
        '
        'cmdT
        '
        Me.cmdT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdT.Location = New System.Drawing.Point(441, 550)
        Me.cmdT.Name = "cmdT"
        Me.cmdT.Size = New System.Drawing.Size(100, 50)
        Me.cmdT.TabIndex = 107
        Me.cmdT.TabStop = False
        Me.cmdT.Text = "T"
        Me.cmdT.UseVisualStyleBackColor = True
        '
        'cmdY
        '
        Me.cmdY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdY.Location = New System.Drawing.Point(547, 550)
        Me.cmdY.Name = "cmdY"
        Me.cmdY.Size = New System.Drawing.Size(100, 50)
        Me.cmdY.TabIndex = 108
        Me.cmdY.TabStop = False
        Me.cmdY.Text = "Y"
        Me.cmdY.UseVisualStyleBackColor = True
        '
        'cmdU
        '
        Me.cmdU.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdU.Location = New System.Drawing.Point(653, 550)
        Me.cmdU.Name = "cmdU"
        Me.cmdU.Size = New System.Drawing.Size(100, 50)
        Me.cmdU.TabIndex = 109
        Me.cmdU.TabStop = False
        Me.cmdU.Text = "U"
        Me.cmdU.UseVisualStyleBackColor = True
        '
        'cmdI
        '
        Me.cmdI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdI.Location = New System.Drawing.Point(759, 550)
        Me.cmdI.Name = "cmdI"
        Me.cmdI.Size = New System.Drawing.Size(100, 50)
        Me.cmdI.TabIndex = 110
        Me.cmdI.TabStop = False
        Me.cmdI.Text = "I"
        Me.cmdI.UseVisualStyleBackColor = True
        '
        'cmdO
        '
        Me.cmdO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdO.Location = New System.Drawing.Point(865, 549)
        Me.cmdO.Name = "cmdO"
        Me.cmdO.Size = New System.Drawing.Size(100, 50)
        Me.cmdO.TabIndex = 111
        Me.cmdO.TabStop = False
        Me.cmdO.Text = "O"
        Me.cmdO.UseVisualStyleBackColor = True
        '
        'cmdP
        '
        Me.cmdP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdP.Location = New System.Drawing.Point(972, 550)
        Me.cmdP.Name = "cmdP"
        Me.cmdP.Size = New System.Drawing.Size(100, 50)
        Me.cmdP.TabIndex = 112
        Me.cmdP.TabStop = False
        Me.cmdP.Text = "P"
        Me.cmdP.UseVisualStyleBackColor = True
        '
        'cmdZ
        '
        Me.cmdZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZ.Location = New System.Drawing.Point(17, 661)
        Me.cmdZ.Name = "cmdZ"
        Me.cmdZ.Size = New System.Drawing.Size(100, 50)
        Me.cmdZ.TabIndex = 113
        Me.cmdZ.TabStop = False
        Me.cmdZ.Text = "Z"
        Me.cmdZ.UseVisualStyleBackColor = True
        '
        'cmdL
        '
        Me.cmdL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdL.Location = New System.Drawing.Point(865, 606)
        Me.cmdL.Name = "cmdL"
        Me.cmdL.Size = New System.Drawing.Size(100, 50)
        Me.cmdL.TabIndex = 121
        Me.cmdL.TabStop = False
        Me.cmdL.Text = "L"
        Me.cmdL.UseVisualStyleBackColor = True
        '
        'cmdK
        '
        Me.cmdK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdK.Location = New System.Drawing.Point(759, 606)
        Me.cmdK.Name = "cmdK"
        Me.cmdK.Size = New System.Drawing.Size(100, 50)
        Me.cmdK.TabIndex = 120
        Me.cmdK.TabStop = False
        Me.cmdK.Text = "K"
        Me.cmdK.UseVisualStyleBackColor = True
        '
        'cmdJ
        '
        Me.cmdJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdJ.Location = New System.Drawing.Point(653, 606)
        Me.cmdJ.Name = "cmdJ"
        Me.cmdJ.Size = New System.Drawing.Size(100, 50)
        Me.cmdJ.TabIndex = 119
        Me.cmdJ.TabStop = False
        Me.cmdJ.Text = "J"
        Me.cmdJ.UseVisualStyleBackColor = True
        '
        'cmdH
        '
        Me.cmdH.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdH.Location = New System.Drawing.Point(547, 606)
        Me.cmdH.Name = "cmdH"
        Me.cmdH.Size = New System.Drawing.Size(100, 50)
        Me.cmdH.TabIndex = 118
        Me.cmdH.TabStop = False
        Me.cmdH.Text = "H"
        Me.cmdH.UseVisualStyleBackColor = True
        '
        'cmdG
        '
        Me.cmdG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdG.Location = New System.Drawing.Point(441, 606)
        Me.cmdG.Name = "cmdG"
        Me.cmdG.Size = New System.Drawing.Size(100, 50)
        Me.cmdG.TabIndex = 117
        Me.cmdG.TabStop = False
        Me.cmdG.Text = "G"
        Me.cmdG.UseVisualStyleBackColor = True
        '
        'cmdF
        '
        Me.cmdF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdF.Location = New System.Drawing.Point(335, 606)
        Me.cmdF.Name = "cmdF"
        Me.cmdF.Size = New System.Drawing.Size(100, 50)
        Me.cmdF.TabIndex = 116
        Me.cmdF.TabStop = False
        Me.cmdF.Text = "F"
        Me.cmdF.UseVisualStyleBackColor = True
        '
        'cmdD
        '
        Me.cmdD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdD.Location = New System.Drawing.Point(229, 605)
        Me.cmdD.Name = "cmdD"
        Me.cmdD.Size = New System.Drawing.Size(100, 50)
        Me.cmdD.TabIndex = 115
        Me.cmdD.TabStop = False
        Me.cmdD.Text = "D"
        Me.cmdD.UseVisualStyleBackColor = True
        '
        'cmdS
        '
        Me.cmdS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdS.Location = New System.Drawing.Point(123, 605)
        Me.cmdS.Name = "cmdS"
        Me.cmdS.Size = New System.Drawing.Size(100, 50)
        Me.cmdS.TabIndex = 114
        Me.cmdS.TabStop = False
        Me.cmdS.Text = "S"
        Me.cmdS.UseVisualStyleBackColor = True
        '
        'cmdM
        '
        Me.cmdM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdM.Location = New System.Drawing.Point(653, 661)
        Me.cmdM.Name = "cmdM"
        Me.cmdM.Size = New System.Drawing.Size(100, 50)
        Me.cmdM.TabIndex = 128
        Me.cmdM.TabStop = False
        Me.cmdM.Text = "M"
        Me.cmdM.UseVisualStyleBackColor = True
        '
        'cmdN
        '
        Me.cmdN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdN.Location = New System.Drawing.Point(547, 661)
        Me.cmdN.Name = "cmdN"
        Me.cmdN.Size = New System.Drawing.Size(100, 50)
        Me.cmdN.TabIndex = 127
        Me.cmdN.TabStop = False
        Me.cmdN.Text = "N"
        Me.cmdN.UseVisualStyleBackColor = True
        '
        'cmdB
        '
        Me.cmdB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdB.Location = New System.Drawing.Point(441, 661)
        Me.cmdB.Name = "cmdB"
        Me.cmdB.Size = New System.Drawing.Size(100, 50)
        Me.cmdB.TabIndex = 126
        Me.cmdB.TabStop = False
        Me.cmdB.Text = "B"
        Me.cmdB.UseVisualStyleBackColor = True
        '
        'cmdV
        '
        Me.cmdV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdV.Location = New System.Drawing.Point(335, 662)
        Me.cmdV.Name = "cmdV"
        Me.cmdV.Size = New System.Drawing.Size(100, 50)
        Me.cmdV.TabIndex = 125
        Me.cmdV.TabStop = False
        Me.cmdV.Text = "V"
        Me.cmdV.UseVisualStyleBackColor = True
        '
        'cmdC
        '
        Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdC.Location = New System.Drawing.Point(229, 661)
        Me.cmdC.Name = "cmdC"
        Me.cmdC.Size = New System.Drawing.Size(100, 50)
        Me.cmdC.TabIndex = 124
        Me.cmdC.TabStop = False
        Me.cmdC.Text = "C"
        Me.cmdC.UseVisualStyleBackColor = True
        '
        'cmdX
        '
        Me.cmdX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdX.Location = New System.Drawing.Point(123, 661)
        Me.cmdX.Name = "cmdX"
        Me.cmdX.Size = New System.Drawing.Size(100, 50)
        Me.cmdX.TabIndex = 123
        Me.cmdX.TabStop = False
        Me.cmdX.Text = "X"
        Me.cmdX.UseVisualStyleBackColor = True
        '
        'cmdSpace
        '
        Me.cmdSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSpace.Location = New System.Drawing.Point(971, 661)
        Me.cmdSpace.Name = "cmdSpace"
        Me.cmdSpace.Size = New System.Drawing.Size(100, 50)
        Me.cmdSpace.TabIndex = 132
        Me.cmdSpace.TabStop = False
        Me.cmdSpace.Text = "SPACE"
        Me.cmdSpace.UseVisualStyleBackColor = True
        '
        'bgwkCoilIDSuggest
        '
        Me.bgwkCoilIDSuggest.WorkerSupportsCancellation = True
        '
        'tabAnnealLotData
        '
        Me.tabAnnealLotData.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.tabAnnealLotData.Controls.Add(Me.tbAnnealingData)
        Me.tabAnnealLotData.Controls.Add(Me.tbTestResults)
        Me.tabAnnealLotData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAnnealLotData.Location = New System.Drawing.Point(712, 40)
        Me.tabAnnealLotData.Multiline = True
        Me.tabAnnealLotData.Name = "tabAnnealLotData"
        Me.tabAnnealLotData.SelectedIndex = 0
        Me.tabAnnealLotData.Size = New System.Drawing.Size(355, 317)
        Me.tabAnnealLotData.TabIndex = 133
        '
        'tbAnnealingData
        '
        Me.tbAnnealingData.BackColor = System.Drawing.SystemColors.Control
        Me.tbAnnealingData.Controls.Add(Me.gpxLotData)
        Me.tbAnnealingData.Location = New System.Drawing.Point(4, 4)
        Me.tbAnnealingData.Name = "tbAnnealingData"
        Me.tbAnnealingData.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAnnealingData.Size = New System.Drawing.Size(326, 309)
        Me.tbAnnealingData.TabIndex = 0
        Me.tbAnnealingData.Text = "Annealing Data"
        '
        'tbTestResults
        '
        Me.tbTestResults.BackColor = System.Drawing.SystemColors.Control
        Me.tbTestResults.Controls.Add(Me.grpTestResults)
        Me.tbTestResults.Location = New System.Drawing.Point(4, 4)
        Me.tbTestResults.Name = "tbTestResults"
        Me.tbTestResults.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTestResults.Size = New System.Drawing.Size(326, 309)
        Me.tbTestResults.TabIndex = 1
        Me.tbTestResults.Text = "Test Results"
        '
        'grpTestResults
        '
        Me.grpTestResults.Controls.Add(Me.txtSurfaceHardness)
        Me.grpTestResults.Controls.Add(Me.Label25)
        Me.grpTestResults.Controls.Add(Me.Label11)
        Me.grpTestResults.Controls.Add(Me.Label22)
        Me.grpTestResults.Controls.Add(Me.Label26)
        Me.grpTestResults.Controls.Add(Me.txtFreeFerrite)
        Me.grpTestResults.Controls.Add(Me.Label23)
        Me.grpTestResults.Controls.Add(Me.txtTensile)
        Me.grpTestResults.Controls.Add(Me.Label21)
        Me.grpTestResults.Controls.Add(Me.Label20)
        Me.grpTestResults.Controls.Add(Me.txtSampleMicro)
        Me.grpTestResults.Controls.Add(Me.txtSampleBox)
        Me.grpTestResults.Controls.Add(Me.txtCoreHardness)
        Me.grpTestResults.Controls.Add(Me.txtSpheroid)
        Me.grpTestResults.Controls.Add(Me.Label32)
        Me.grpTestResults.Controls.Add(Me.txtTotalDecarb)
        Me.grpTestResults.Location = New System.Drawing.Point(6, 6)
        Me.grpTestResults.Name = "grpTestResults"
        Me.grpTestResults.Size = New System.Drawing.Size(314, 300)
        Me.grpTestResults.TabIndex = 2
        Me.grpTestResults.TabStop = False
        Me.grpTestResults.Text = "Anneal Lot Test Results"
        '
        'txtSurfaceHardness
        '
        Me.txtSurfaceHardness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurfaceHardness.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSurfaceHardness.Location = New System.Drawing.Point(143, 41)
        Me.txtSurfaceHardness.Name = "txtSurfaceHardness"
        Me.txtSurfaceHardness.ReadOnly = True
        Me.txtSurfaceHardness.Size = New System.Drawing.Size(154, 23)
        Me.txtSurfaceHardness.TabIndex = 0
        Me.txtSurfaceHardness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(10, 154)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(127, 20)
        Me.Label25.TabIndex = 127
        Me.Label25.Text = "Spheroid %"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 212)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 20)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "Sample Box"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(10, 125)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(127, 20)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Total Decarb"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(10, 183)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(127, 20)
        Me.Label26.TabIndex = 129
        Me.Label26.Text = "Sample Micro"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreeFerrite
        '
        Me.txtFreeFerrite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreeFerrite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreeFerrite.Location = New System.Drawing.Point(143, 98)
        Me.txtFreeFerrite.Name = "txtFreeFerrite"
        Me.txtFreeFerrite.ReadOnly = True
        Me.txtFreeFerrite.Size = New System.Drawing.Size(154, 23)
        Me.txtFreeFerrite.TabIndex = 2
        Me.txtFreeFerrite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(10, 98)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(127, 20)
        Me.Label23.TabIndex = 123
        Me.Label23.Text = "Free Ferrite"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTensile
        '
        Me.txtTensile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTensile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTensile.Location = New System.Drawing.Point(143, 238)
        Me.txtTensile.Name = "txtTensile"
        Me.txtTensile.ReadOnly = True
        Me.txtTensile.Size = New System.Drawing.Size(154, 23)
        Me.txtTensile.TabIndex = 10
        Me.txtTensile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(10, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(127, 20)
        Me.Label21.TabIndex = 125
        Me.Label21.Text = "Surface Hardness"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(10, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 20)
        Me.Label20.TabIndex = 126
        Me.Label20.Text = "Core Hardness"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSampleMicro
        '
        Me.txtSampleMicro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSampleMicro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSampleMicro.Location = New System.Drawing.Point(143, 183)
        Me.txtSampleMicro.Name = "txtSampleMicro"
        Me.txtSampleMicro.ReadOnly = True
        Me.txtSampleMicro.Size = New System.Drawing.Size(154, 23)
        Me.txtSampleMicro.TabIndex = 6
        Me.txtSampleMicro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleBox
        '
        Me.txtSampleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSampleBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSampleBox.Location = New System.Drawing.Point(143, 212)
        Me.txtSampleBox.Name = "txtSampleBox"
        Me.txtSampleBox.ReadOnly = True
        Me.txtSampleBox.Size = New System.Drawing.Size(154, 23)
        Me.txtSampleBox.TabIndex = 7
        Me.txtSampleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoreHardness
        '
        Me.txtCoreHardness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoreHardness.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoreHardness.Location = New System.Drawing.Point(143, 70)
        Me.txtCoreHardness.Name = "txtCoreHardness"
        Me.txtCoreHardness.ReadOnly = True
        Me.txtCoreHardness.Size = New System.Drawing.Size(154, 23)
        Me.txtCoreHardness.TabIndex = 1
        Me.txtCoreHardness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSpheroid
        '
        Me.txtSpheroid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpheroid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpheroid.Location = New System.Drawing.Point(143, 154)
        Me.txtSpheroid.Name = "txtSpheroid"
        Me.txtSpheroid.ReadOnly = True
        Me.txtSpheroid.Size = New System.Drawing.Size(154, 23)
        Me.txtSpheroid.TabIndex = 4
        Me.txtSpheroid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(10, 236)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(127, 20)
        Me.Label32.TabIndex = 132
        Me.Label32.Text = "Raw Material Tensile"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalDecarb
        '
        Me.txtTotalDecarb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDecarb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalDecarb.Location = New System.Drawing.Point(143, 125)
        Me.txtTotalDecarb.Name = "txtTotalDecarb"
        Me.txtTotalDecarb.ReadOnly = True
        Me.txtTotalDecarb.Size = New System.Drawing.Size(154, 23)
        Me.txtTotalDecarb.TabIndex = 3
        Me.txtTotalDecarb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tmrScanTime
        '
        '
        'AnnealingLogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1194, 721)
        Me.Controls.Add(Me.lblQCMessage)
        Me.Controls.Add(Me.tabAnnealLotData)
        Me.Controls.Add(Me.cmdSpace)
        Me.Controls.Add(Me.cmdM)
        Me.Controls.Add(Me.cmdN)
        Me.Controls.Add(Me.cmdB)
        Me.Controls.Add(Me.cmdV)
        Me.Controls.Add(Me.cmdC)
        Me.Controls.Add(Me.cmdX)
        Me.Controls.Add(Me.cmdL)
        Me.Controls.Add(Me.cmdK)
        Me.Controls.Add(Me.cmdJ)
        Me.Controls.Add(Me.cmdH)
        Me.Controls.Add(Me.cmdG)
        Me.Controls.Add(Me.cmdF)
        Me.Controls.Add(Me.cmdD)
        Me.Controls.Add(Me.cmdS)
        Me.Controls.Add(Me.cmdZ)
        Me.Controls.Add(Me.cmdP)
        Me.Controls.Add(Me.cmdO)
        Me.Controls.Add(Me.cmdI)
        Me.Controls.Add(Me.cmdU)
        Me.Controls.Add(Me.cmdY)
        Me.Controls.Add(Me.cmdT)
        Me.Controls.Add(Me.cmdR)
        Me.Controls.Add(Me.cmdE)
        Me.Controls.Add(Me.cmdW)
        Me.Controls.Add(Me.cmdQ)
        Me.Controls.Add(Me.lstCoilIDSuggest)
        Me.Controls.Add(Me.lstSizeSuggest)
        Me.Controls.Add(Me.lstCarbonSuggest)
        Me.Controls.Add(Me.lstAnnealingSuggest)
        Me.Controls.Add(Me.cmdBackspace)
        Me.Controls.Add(Me.cmdDash)
        Me.Controls.Add(Me.cmdForwardSlash)
        Me.Controls.Add(Me.cmdA)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdNine)
        Me.Controls.Add(Me.cmdEight)
        Me.Controls.Add(Me.cmdSeven)
        Me.Controls.Add(Me.cmdSix)
        Me.Controls.Add(Me.cmdFive)
        Me.Controls.Add(Me.cmdFour)
        Me.Controls.Add(Me.cmdEnter)
        Me.Controls.Add(Me.cmdThree)
        Me.Controls.Add(Me.cmdTwo)
        Me.Controls.Add(Me.cmdOne)
        Me.Controls.Add(Me.cmdDecimal)
        Me.Controls.Add(Me.cmdZero)
        Me.Controls.Add(Me.cmdPostAnnealingLot)
        Me.Controls.Add(Me.gpxCoilsInLot)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gpxSteelType)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.gpxSelectLotNumber)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "AnnealingLogForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Annealing Log"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSelectLotNumber.ResumeLayout(False)
        Me.gpxSelectLotNumber.PerformLayout()
        Me.gpxSteelType.ResumeLayout(False)
        Me.gpxSteelType.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvAnnealLotLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxLotData.ResumeLayout(False)
        Me.gpxLotData.PerformLayout()
        Me.gpxCoilsInLot.ResumeLayout(False)
        Me.gpxCoilsInLot.PerformLayout()
        Me.tabAnnealLotData.ResumeLayout(False)
        Me.tbAnnealingData.ResumeLayout(False)
        Me.tbTestResults.ResumeLayout(False)
        Me.grpTestResults.ResumeLayout(False)
        Me.grpTestResults.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents gpxSelectLotNumber As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAnnealLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdGenerateNew As System.Windows.Forms.Button
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLotNumber As System.Windows.Forms.Label
    Friend WithEvents cboCoilID As System.Windows.Forms.ComboBox
    Friend WithEvents txtSteelDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPreviousLot As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateOut As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtProgram As System.Windows.Forms.TextBox
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents gpxSteelType As System.Windows.Forms.GroupBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAddCoil As System.Windows.Forms.Button
    Friend WithEvents txtNumberOfCoils As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpLotCreationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAnnealedDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvAnnealLotLines As System.Windows.Forms.DataGridView
    Friend WithEvents gpxLotData As System.Windows.Forms.GroupBox
    Friend WithEvents gpxCoilsInLot As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents txtAnnealSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents txtAnnealCarbon As System.Windows.Forms.TextBox
    Friend WithEvents cmdSplitCoil As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveCoil As System.Windows.Forms.Button
    Friend WithEvents cboDeleteCoilID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPostAnnealingLot As System.Windows.Forms.Button
    Friend WithEvents tmrWaitToPrint As System.Windows.Forms.Timer
    Friend WithEvents txtCoilSize As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCoilCarbon As System.Windows.Forms.TextBox
    Friend WithEvents lblCoilCarbon As System.Windows.Forms.Label
    Friend WithEvents bgwkCoilID As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdThree As System.Windows.Forms.Button
    Friend WithEvents cmdTwo As System.Windows.Forms.Button
    Friend WithEvents cmdOne As System.Windows.Forms.Button
    Friend WithEvents cmdDecimal As System.Windows.Forms.Button
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdNine As System.Windows.Forms.Button
    Friend WithEvents cmdEight As System.Windows.Forms.Button
    Friend WithEvents cmdSeven As System.Windows.Forms.Button
    Friend WithEvents cmdSix As System.Windows.Forms.Button
    Friend WithEvents cmdFive As System.Windows.Forms.Button
    Friend WithEvents cmdFour As System.Windows.Forms.Button
    Friend WithEvents cmdA As System.Windows.Forms.Button
    Friend WithEvents cmdDash As System.Windows.Forms.Button
    Friend WithEvents cmdForwardSlash As System.Windows.Forms.Button
    Friend WithEvents cmdBackspace As System.Windows.Forms.Button
    Friend WithEvents lstAnnealingSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstCarbonSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstSizeSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstCoilIDSuggest As System.Windows.Forms.ListBox
    Friend WithEvents cmdQ As System.Windows.Forms.Button
    Friend WithEvents cmdW As System.Windows.Forms.Button
    Friend WithEvents cmdE As System.Windows.Forms.Button
    Friend WithEvents cmdR As System.Windows.Forms.Button
    Friend WithEvents cmdT As System.Windows.Forms.Button
    Friend WithEvents cmdY As System.Windows.Forms.Button
    Friend WithEvents cmdU As System.Windows.Forms.Button
    Friend WithEvents cmdI As System.Windows.Forms.Button
    Friend WithEvents cmdO As System.Windows.Forms.Button
    Friend WithEvents cmdP As System.Windows.Forms.Button
    Friend WithEvents cmdZ As System.Windows.Forms.Button
    Friend WithEvents cmdL As System.Windows.Forms.Button
    Friend WithEvents cmdK As System.Windows.Forms.Button
    Friend WithEvents cmdJ As System.Windows.Forms.Button
    Friend WithEvents cmdH As System.Windows.Forms.Button
    Friend WithEvents cmdG As System.Windows.Forms.Button
    Friend WithEvents cmdF As System.Windows.Forms.Button
    Friend WithEvents cmdD As System.Windows.Forms.Button
    Friend WithEvents cmdS As System.Windows.Forms.Button
    Friend WithEvents cmdM As System.Windows.Forms.Button
    Friend WithEvents cmdN As System.Windows.Forms.Button
    Friend WithEvents cmdB As System.Windows.Forms.Button
    Friend WithEvents cmdV As System.Windows.Forms.Button
    Friend WithEvents cmdC As System.Windows.Forms.Button
    Friend WithEvents cmdX As System.Windows.Forms.Button
    Friend WithEvents cmdSpace As System.Windows.Forms.Button
    Friend WithEvents bgwkCoilIDSuggest As System.ComponentModel.BackgroundWorker
    Friend WithEvents UpdateTotalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnLockAnnealToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSampleTagToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabAnnealLotData As System.Windows.Forms.TabControl
    Friend WithEvents tbAnnealingData As System.Windows.Forms.TabPage
    Friend WithEvents tbTestResults As System.Windows.Forms.TabPage
    Friend WithEvents grpTestResults As System.Windows.Forms.GroupBox
    Friend WithEvents txtSurfaceHardness As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtFreeFerrite As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTensile As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSampleMicro As System.Windows.Forms.TextBox
    Friend WithEvents txtSampleBox As System.Windows.Forms.TextBox
    Friend WithEvents txtCoreHardness As System.Windows.Forms.TextBox
    Friend WithEvents txtSpheroid As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDecarb As System.Windows.Forms.TextBox
    Friend WithEvents tmrScanTime As System.Windows.Forms.Timer
    Friend WithEvents lblQCMessage As System.Windows.Forms.Label
End Class