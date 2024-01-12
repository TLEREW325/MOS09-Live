<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCorrectivePreventiceActionReport
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
        Me.cboCARNum = New System.Windows.Forms.ComboBox
        Me.RMATableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomer = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSupplier = New System.Windows.Forms.ComboBox
        Me.cboReviewModifyCreate = New System.Windows.Forms.ComboBox
        Me.cboProductChanged = New System.Windows.Forms.ComboBox
        Me.cboVerifiedBy = New System.Windows.Forms.ComboBox
        Me.cboOpenClosed = New System.Windows.Forms.ComboBox
        Me.rchContainmentAction = New System.Windows.Forms.RichTextBox
        Me.rchInterimCorrect = New System.Windows.Forms.RichTextBox
        Me.rchPermCorrAction = New System.Windows.Forms.RichTextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblExists = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivision = New System.Windows.Forms.ComboBox
        Me.txtChampion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblProblemDef = New System.Windows.Forms.Label
        Me.rchProblemDef = New System.Windows.Forms.RichTextBox
        Me.cmdReset = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.lblVerifyDate = New System.Windows.Forms.Label
        Me.lblChosen = New System.Windows.Forms.Label
        Me.dtpVerifyDate = New System.Windows.Forms.DateTimePicker
        Me.lblRoot = New System.Windows.Forms.Label
        Me.lblContainDate = New System.Windows.Forms.Label
        Me.lblContainment = New System.Windows.Forms.Label
        Me.lblDateofOccurrence = New System.Windows.Forms.Label
        Me.lblTeamChamp = New System.Windows.Forms.Label
        Me.lblDateOpened = New System.Windows.Forms.Label
        Me.rchRoot = New System.Windows.Forms.RichTextBox
        Me.dtpContainImpDate = New System.Windows.Forms.DateTimePicker
        Me.cboChampion = New System.Windows.Forms.ComboBox
        Me.dtpOccuranceDate = New System.Windows.Forms.DateTimePicker
        Me.dtpDateOpened = New System.Windows.Forms.DateTimePicker
        Me.lblSupplier = New System.Windows.Forms.Label
        Me.lblPart = New System.Windows.Forms.Label
        Me.lblCustomer = New System.Windows.Forms.Label
        Me.lblCar = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lblCloseDate = New System.Windows.Forms.Label
        Me.lblOpenClose = New System.Windows.Forms.Label
        Me.dtpStatusCARDate = New System.Windows.Forms.DateTimePicker
        Me.lblCarStatus = New System.Windows.Forms.Label
        Me.dtpCloseDate = New System.Windows.Forms.DateTimePicker
        Me.lblVerifiedBy = New System.Windows.Forms.Label
        Me.lblVerification = New System.Windows.Forms.Label
        Me.rchVerification = New System.Windows.Forms.RichTextBox
        Me.lblAuditorName = New System.Windows.Forms.Label
        Me.dtpdateofAudit = New System.Windows.Forms.DateTimePicker
        Me.lblProductChangeYes = New System.Windows.Forms.Label
        Me.txtNameOfAuditor = New System.Windows.Forms.TextBox
        Me.lblProductChange = New System.Windows.Forms.Label
        Me.lblReviewModCreate = New System.Windows.Forms.Label
        Me.lblPreventDate = New System.Windows.Forms.Label
        Me.dtpActionToPreventDate = New System.Windows.Forms.DateTimePicker
        Me.lblActiontoPreventRecurrence = New System.Windows.Forms.Label
        Me.rchActionToPreventReccurr = New System.Windows.Forms.RichTextBox
        Me.lblImpPermCorrActionDate = New System.Windows.Forms.Label
        Me.dtpImpPermActionDate = New System.Windows.Forms.DateTimePicker
        Me.lblImplementedCorrect = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.lblDept = New System.Windows.Forms.Label
        Me.txtNameOf = New System.Windows.Forms.TextBox
        Me.lblNameBy = New System.Windows.Forms.Label
        Me.txtReportedBy = New System.Windows.Forms.TextBox
        Me.lblReportedBy = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CRCustomerYTDViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXCorrectiveActionForm1 = New MOS09Program.CRXCorrectiveActionForm
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailAuthorizationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RMATableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RMATableTableAdapter
        Me.cmdSave = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip5 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip6 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdDelete = New System.Windows.Forms.Button
        CType(Me.RMATableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCARNum
        '
        Me.cboCARNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCARNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCARNum.DataSource = Me.RMATableBindingSource
        Me.cboCARNum.DisplayMember = "AuthorizationNumber"
        Me.cboCARNum.FormattingEnabled = True
        Me.cboCARNum.Location = New System.Drawing.Point(3, 19)
        Me.cboCARNum.Name = "cboCARNum"
        Me.cboCARNum.Size = New System.Drawing.Size(152, 21)
        Me.cboCARNum.TabIndex = 1
        '
        'RMATableBindingSource
        '
        Me.RMATableBindingSource.DataMember = "RMATable"
        Me.RMATableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomer.DataSource = Me.CustomerListBindingSource
        Me.cboCustomer.DisplayMember = "CustomerID"
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(3, 56)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(152, 21)
        Me.cboCustomer.TabIndex = 3
        Me.cboCustomer.ValueMember = "CustomerID"
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(3, 93)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(152, 21)
        Me.cboPartNumber.TabIndex = 4
        Me.cboPartNumber.ValueMember = "ItemID"
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboSupplier
        '
        Me.cboSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSupplier.DataSource = Me.CustomerListBindingSource
        Me.cboSupplier.DisplayMember = "CustomerID"
        Me.cboSupplier.FormattingEnabled = True
        Me.cboSupplier.Location = New System.Drawing.Point(3, 130)
        Me.cboSupplier.Name = "cboSupplier"
        Me.cboSupplier.Size = New System.Drawing.Size(152, 21)
        Me.cboSupplier.TabIndex = 5
        Me.cboSupplier.ValueMember = "CustomerID"
        '
        'cboReviewModifyCreate
        '
        Me.cboReviewModifyCreate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReviewModifyCreate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReviewModifyCreate.FormattingEnabled = True
        Me.cboReviewModifyCreate.Items.AddRange(New Object() {"Procedure", "Form/Checklist", "Work Instructions"})
        Me.cboReviewModifyCreate.Location = New System.Drawing.Point(3, 289)
        Me.cboReviewModifyCreate.Name = "cboReviewModifyCreate"
        Me.cboReviewModifyCreate.Size = New System.Drawing.Size(152, 21)
        Me.cboReviewModifyCreate.TabIndex = 22
        '
        'cboProductChanged
        '
        Me.cboProductChanged.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProductChanged.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProductChanged.FormattingEnabled = True
        Me.cboProductChanged.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboProductChanged.Location = New System.Drawing.Point(3, 329)
        Me.cboProductChanged.Name = "cboProductChanged"
        Me.cboProductChanged.Size = New System.Drawing.Size(152, 21)
        Me.cboProductChanged.TabIndex = 23
        '
        'cboVerifiedBy
        '
        Me.cboVerifiedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVerifiedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVerifiedBy.FormattingEnabled = True
        Me.cboVerifiedBy.Items.AddRange(New Object() {"Sam Ray", "Sue Balliet", "Eric Rupnow", "Justin Sparks", "Peter Workman", "Justen Davies", "Laurie Bower", "Adam Blackburn"})
        Me.cboVerifiedBy.Location = New System.Drawing.Point(3, 518)
        Me.cboVerifiedBy.Name = "cboVerifiedBy"
        Me.cboVerifiedBy.Size = New System.Drawing.Size(152, 21)
        Me.cboVerifiedBy.TabIndex = 27
        '
        'cboOpenClosed
        '
        Me.cboOpenClosed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOpenClosed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOpenClosed.FormattingEnabled = True
        Me.cboOpenClosed.Items.AddRange(New Object() {"Open", "Closed"})
        Me.cboOpenClosed.Location = New System.Drawing.Point(3, 597)
        Me.cboOpenClosed.Name = "cboOpenClosed"
        Me.cboOpenClosed.Size = New System.Drawing.Size(140, 21)
        Me.cboOpenClosed.TabIndex = 30
        '
        'rchContainmentAction
        '
        Me.rchContainmentAction.Location = New System.Drawing.Point(3, 342)
        Me.rchContainmentAction.Name = "rchContainmentAction"
        Me.rchContainmentAction.Size = New System.Drawing.Size(316, 37)
        Me.rchContainmentAction.TabIndex = 13
        Me.rchContainmentAction.Text = ""
        '
        'rchInterimCorrect
        '
        Me.rchInterimCorrect.Location = New System.Drawing.Point(3, 497)
        Me.rchInterimCorrect.Name = "rchInterimCorrect"
        Me.rchInterimCorrect.Size = New System.Drawing.Size(316, 78)
        Me.rchInterimCorrect.TabIndex = 16
        Me.rchInterimCorrect.Text = ""
        '
        'rchPermCorrAction
        '
        Me.rchPermCorrAction.Location = New System.Drawing.Point(3, 16)
        Me.rchPermCorrAction.Name = "rchPermCorrAction"
        Me.rchPermCorrAction.Size = New System.Drawing.Size(316, 78)
        Me.rchPermCorrAction.TabIndex = 18
        Me.rchPermCorrAction.Text = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(2, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(330, 653)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lblExists)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cboDivision)
        Me.TabPage1.Controls.Add(Me.txtChampion)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lblProblemDef)
        Me.TabPage1.Controls.Add(Me.rchProblemDef)
        Me.TabPage1.Controls.Add(Me.cmdReset)
        Me.TabPage1.Controls.Add(Me.cmdAdd)
        Me.TabPage1.Controls.Add(Me.lblVerifyDate)
        Me.TabPage1.Controls.Add(Me.lblChosen)
        Me.TabPage1.Controls.Add(Me.dtpVerifyDate)
        Me.TabPage1.Controls.Add(Me.lblRoot)
        Me.TabPage1.Controls.Add(Me.lblContainDate)
        Me.TabPage1.Controls.Add(Me.lblContainment)
        Me.TabPage1.Controls.Add(Me.lblDateofOccurrence)
        Me.TabPage1.Controls.Add(Me.lblTeamChamp)
        Me.TabPage1.Controls.Add(Me.lblDateOpened)
        Me.TabPage1.Controls.Add(Me.rchRoot)
        Me.TabPage1.Controls.Add(Me.dtpContainImpDate)
        Me.TabPage1.Controls.Add(Me.cboChampion)
        Me.TabPage1.Controls.Add(Me.rchInterimCorrect)
        Me.TabPage1.Controls.Add(Me.dtpOccuranceDate)
        Me.TabPage1.Controls.Add(Me.dtpDateOpened)
        Me.TabPage1.Controls.Add(Me.lblSupplier)
        Me.TabPage1.Controls.Add(Me.rchContainmentAction)
        Me.TabPage1.Controls.Add(Me.lblPart)
        Me.TabPage1.Controls.Add(Me.lblCustomer)
        Me.TabPage1.Controls.Add(Me.lblCar)
        Me.TabPage1.Controls.Add(Me.cboCARNum)
        Me.TabPage1.Controls.Add(Me.cboCustomer)
        Me.TabPage1.Controls.Add(Me.cboPartNumber)
        Me.TabPage1.Controls.Add(Me.cboSupplier)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(322, 627)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Page 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(162, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 63
        '
        'lblExists
        '
        Me.lblExists.AutoSize = True
        Me.lblExists.Enabled = False
        Me.lblExists.ForeColor = System.Drawing.Color.Red
        Me.lblExists.Location = New System.Drawing.Point(78, 3)
        Me.lblExists.Name = "lblExists"
        Me.lblExists.Size = New System.Drawing.Size(0, 13)
        Me.lblExists.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Division"
        '
        'cboDivision
        '
        Me.cboDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Items.AddRange(New Object() {"TWD", "TFP", "TWE", "TST"})
        Me.cboDivision.Location = New System.Drawing.Point(161, 19)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(152, 21)
        Me.cboDivision.TabIndex = 2
        '
        'txtChampion
        '
        Me.txtChampion.Location = New System.Drawing.Point(161, 167)
        Me.txtChampion.Name = "txtChampion"
        Me.txtChampion.Size = New System.Drawing.Size(155, 20)
        Me.txtChampion.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(158, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Team Champion"
        '
        'lblProblemDef
        '
        Me.lblProblemDef.AutoSize = True
        Me.lblProblemDef.Location = New System.Drawing.Point(3, 270)
        Me.lblProblemDef.Name = "lblProblemDef"
        Me.lblProblemDef.Size = New System.Drawing.Size(92, 13)
        Me.lblProblemDef.TabIndex = 37
        Me.lblProblemDef.Text = "Problem Definition"
        '
        'rchProblemDef
        '
        Me.rchProblemDef.Location = New System.Drawing.Point(3, 286)
        Me.rchProblemDef.Name = "rchProblemDef"
        Me.rchProblemDef.Size = New System.Drawing.Size(316, 37)
        Me.rchProblemDef.TabIndex = 12
        Me.rchProblemDef.Text = ""
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(241, 201)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(75, 23)
        Me.cmdReset.TabIndex = 10
        Me.cmdReset.Text = "Reset"
        Me.ToolTip2.SetToolTip(Me.cmdReset, "Will clear all persons from Team Details")
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(161, 201)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 9
        Me.cmdAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.cmdAdd, "Will add persons to Team Details")
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'lblVerifyDate
        '
        Me.lblVerifyDate.AutoSize = True
        Me.lblVerifyDate.Location = New System.Drawing.Point(3, 578)
        Me.lblVerifyDate.Name = "lblVerifyDate"
        Me.lblVerifyDate.Size = New System.Drawing.Size(85, 13)
        Me.lblVerifyDate.TabIndex = 33
        Me.lblVerifyDate.Text = "Verification Date"
        '
        'lblChosen
        '
        Me.lblChosen.AutoSize = True
        Me.lblChosen.Location = New System.Drawing.Point(3, 484)
        Me.lblChosen.Name = "lblChosen"
        Me.lblChosen.Size = New System.Drawing.Size(128, 13)
        Me.lblChosen.TabIndex = 32
        Me.lblChosen.Text = "Chosen Interim Correction"
        '
        'dtpVerifyDate
        '
        Me.dtpVerifyDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVerifyDate.Location = New System.Drawing.Point(3, 594)
        Me.dtpVerifyDate.Name = "dtpVerifyDate"
        Me.dtpVerifyDate.Size = New System.Drawing.Size(101, 20)
        Me.dtpVerifyDate.TabIndex = 17
        Me.dtpVerifyDate.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'lblRoot
        '
        Me.lblRoot.AutoSize = True
        Me.lblRoot.Location = New System.Drawing.Point(3, 418)
        Me.lblRoot.Name = "lblRoot"
        Me.lblRoot.Size = New System.Drawing.Size(74, 13)
        Me.lblRoot.TabIndex = 30
        Me.lblRoot.Text = "Root Cause(s)"
        '
        'lblContainDate
        '
        Me.lblContainDate.AutoSize = True
        Me.lblContainDate.Location = New System.Drawing.Point(3, 382)
        Me.lblContainDate.Name = "lblContainDate"
        Me.lblContainDate.Size = New System.Drawing.Size(104, 13)
        Me.lblContainDate.TabIndex = 29
        Me.lblContainDate.Text = "Implementation Date"
        '
        'lblContainment
        '
        Me.lblContainment.AutoSize = True
        Me.lblContainment.Location = New System.Drawing.Point(3, 326)
        Me.lblContainment.Name = "lblContainment"
        Me.lblContainment.Size = New System.Drawing.Size(110, 13)
        Me.lblContainment.TabIndex = 28
        Me.lblContainment.Text = "Containment Action(s)"
        '
        'lblDateofOccurrence
        '
        Me.lblDateofOccurrence.AutoSize = True
        Me.lblDateofOccurrence.Location = New System.Drawing.Point(3, 224)
        Me.lblDateofOccurrence.Name = "lblDateofOccurrence"
        Me.lblDateofOccurrence.Size = New System.Drawing.Size(101, 13)
        Me.lblDateofOccurrence.TabIndex = 27
        Me.lblDateofOccurrence.Text = "Date of Occurrence"
        '
        'lblTeamChamp
        '
        Me.lblTeamChamp.AutoSize = True
        Me.lblTeamChamp.Location = New System.Drawing.Point(3, 187)
        Me.lblTeamChamp.Name = "lblTeamChamp"
        Me.lblTeamChamp.Size = New System.Drawing.Size(69, 13)
        Me.lblTeamChamp.TabIndex = 26
        Me.lblTeamChamp.Text = "Team Details"
        '
        'lblDateOpened
        '
        Me.lblDateOpened.AutoSize = True
        Me.lblDateOpened.Location = New System.Drawing.Point(3, 151)
        Me.lblDateOpened.Name = "lblDateOpened"
        Me.lblDateOpened.Size = New System.Drawing.Size(71, 13)
        Me.lblDateOpened.TabIndex = 20
        Me.lblDateOpened.Text = "Date Opened"
        '
        'rchRoot
        '
        Me.rchRoot.Location = New System.Drawing.Point(3, 431)
        Me.rchRoot.Name = "rchRoot"
        Me.rchRoot.Size = New System.Drawing.Size(316, 50)
        Me.rchRoot.TabIndex = 15
        Me.rchRoot.Text = ""
        '
        'dtpContainImpDate
        '
        Me.dtpContainImpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpContainImpDate.Location = New System.Drawing.Point(3, 398)
        Me.dtpContainImpDate.Name = "dtpContainImpDate"
        Me.dtpContainImpDate.Size = New System.Drawing.Size(101, 20)
        Me.dtpContainImpDate.TabIndex = 14
        Me.dtpContainImpDate.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'cboChampion
        '
        Me.cboChampion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboChampion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboChampion.DisplayMember = "EmployeeFirst"
        Me.cboChampion.FormattingEnabled = True
        Me.cboChampion.Items.AddRange(New Object() {"Sam Ray (Quality Control)", "Sue Balliet (Quality Control)", "Eric Rupnow (Sales)", "Justin Sparks (Sales)", "Peter Workman (Sales)", "Justen Davies (Sales)", "Laurie Bower (Sales)", "Adam Blackburn (Sales)"})
        Me.cboChampion.Location = New System.Drawing.Point(3, 203)
        Me.cboChampion.Name = "cboChampion"
        Me.cboChampion.Size = New System.Drawing.Size(152, 21)
        Me.cboChampion.TabIndex = 8
        Me.cboChampion.ValueMember = "EmployeeFirst"
        '
        'dtpOccuranceDate
        '
        Me.dtpOccuranceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOccuranceDate.Location = New System.Drawing.Point(3, 240)
        Me.dtpOccuranceDate.Name = "dtpOccuranceDate"
        Me.dtpOccuranceDate.Size = New System.Drawing.Size(104, 20)
        Me.dtpOccuranceDate.TabIndex = 11
        Me.dtpOccuranceDate.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'dtpDateOpened
        '
        Me.dtpDateOpened.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateOpened.Location = New System.Drawing.Point(3, 167)
        Me.dtpDateOpened.Name = "dtpDateOpened"
        Me.dtpDateOpened.Size = New System.Drawing.Size(104, 20)
        Me.dtpDateOpened.TabIndex = 6
        Me.dtpDateOpened.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Location = New System.Drawing.Point(3, 114)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(45, 13)
        Me.lblSupplier.TabIndex = 19
        Me.lblSupplier.Text = "Supplier"
        '
        'lblPart
        '
        Me.lblPart.AutoSize = True
        Me.lblPart.Location = New System.Drawing.Point(3, 77)
        Me.lblPart.Name = "lblPart"
        Me.lblPart.Size = New System.Drawing.Size(66, 13)
        Me.lblPart.TabIndex = 18
        Me.lblPart.Text = "Part Number"
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Location = New System.Drawing.Point(3, 40)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(51, 13)
        Me.lblCustomer.TabIndex = 17
        Me.lblCustomer.Text = "Customer"
        '
        'lblCar
        '
        Me.lblCar.AutoSize = True
        Me.lblCar.Location = New System.Drawing.Point(3, 3)
        Me.lblCar.Name = "lblCar"
        Me.lblCar.Size = New System.Drawing.Size(69, 13)
        Me.lblCar.TabIndex = 16
        Me.lblCar.Text = "CAR Number"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblCloseDate)
        Me.TabPage2.Controls.Add(Me.lblOpenClose)
        Me.TabPage2.Controls.Add(Me.dtpStatusCARDate)
        Me.TabPage2.Controls.Add(Me.lblCarStatus)
        Me.TabPage2.Controls.Add(Me.cboOpenClosed)
        Me.TabPage2.Controls.Add(Me.dtpCloseDate)
        Me.TabPage2.Controls.Add(Me.cboVerifiedBy)
        Me.TabPage2.Controls.Add(Me.lblVerifiedBy)
        Me.TabPage2.Controls.Add(Me.lblVerification)
        Me.TabPage2.Controls.Add(Me.rchVerification)
        Me.TabPage2.Controls.Add(Me.lblAuditorName)
        Me.TabPage2.Controls.Add(Me.dtpdateofAudit)
        Me.TabPage2.Controls.Add(Me.lblProductChangeYes)
        Me.TabPage2.Controls.Add(Me.txtNameOfAuditor)
        Me.TabPage2.Controls.Add(Me.lblProductChange)
        Me.TabPage2.Controls.Add(Me.lblReviewModCreate)
        Me.TabPage2.Controls.Add(Me.lblPreventDate)
        Me.TabPage2.Controls.Add(Me.cboReviewModifyCreate)
        Me.TabPage2.Controls.Add(Me.dtpActionToPreventDate)
        Me.TabPage2.Controls.Add(Me.lblActiontoPreventRecurrence)
        Me.TabPage2.Controls.Add(Me.rchActionToPreventReccurr)
        Me.TabPage2.Controls.Add(Me.cboProductChanged)
        Me.TabPage2.Controls.Add(Me.lblImpPermCorrActionDate)
        Me.TabPage2.Controls.Add(Me.dtpImpPermActionDate)
        Me.TabPage2.Controls.Add(Me.lblImplementedCorrect)
        Me.TabPage2.Controls.Add(Me.rchPermCorrAction)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(322, 627)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Page 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblCloseDate
        '
        Me.lblCloseDate.AutoSize = True
        Me.lblCloseDate.Location = New System.Drawing.Point(3, 542)
        Me.lblCloseDate.Name = "lblCloseDate"
        Me.lblCloseDate.Size = New System.Drawing.Size(59, 13)
        Me.lblCloseDate.TabIndex = 53
        Me.lblCloseDate.Text = "Close Date"
        '
        'lblOpenClose
        '
        Me.lblOpenClose.AutoSize = True
        Me.lblOpenClose.Location = New System.Drawing.Point(3, 581)
        Me.lblOpenClose.Name = "lblOpenClose"
        Me.lblOpenClose.Size = New System.Drawing.Size(80, 13)
        Me.lblOpenClose.TabIndex = 52
        Me.lblOpenClose.Text = "Open or Closed"
        '
        'dtpStatusCARDate
        '
        Me.dtpStatusCARDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStatusCARDate.Location = New System.Drawing.Point(3, 558)
        Me.dtpStatusCARDate.Name = "dtpStatusCARDate"
        Me.dtpStatusCARDate.Size = New System.Drawing.Size(104, 20)
        Me.dtpStatusCARDate.TabIndex = 29
        Me.dtpStatusCARDate.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'lblCarStatus
        '
        Me.lblCarStatus.AutoSize = True
        Me.lblCarStatus.Location = New System.Drawing.Point(158, 503)
        Me.lblCarStatus.Name = "lblCarStatus"
        Me.lblCarStatus.Size = New System.Drawing.Size(68, 13)
        Me.lblCarStatus.TabIndex = 50
        Me.lblCarStatus.Text = "Verified Date"
        '
        'dtpCloseDate
        '
        Me.dtpCloseDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCloseDate.Location = New System.Drawing.Point(161, 519)
        Me.dtpCloseDate.Name = "dtpCloseDate"
        Me.dtpCloseDate.Size = New System.Drawing.Size(101, 20)
        Me.dtpCloseDate.TabIndex = 28
        Me.dtpCloseDate.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'lblVerifiedBy
        '
        Me.lblVerifiedBy.AutoSize = True
        Me.lblVerifiedBy.Location = New System.Drawing.Point(3, 502)
        Me.lblVerifiedBy.Name = "lblVerifiedBy"
        Me.lblVerifiedBy.Size = New System.Drawing.Size(57, 13)
        Me.lblVerifiedBy.TabIndex = 48
        Me.lblVerifiedBy.Text = "Verified By"
        '
        'lblVerification
        '
        Me.lblVerification.AutoSize = True
        Me.lblVerification.Location = New System.Drawing.Point(3, 405)
        Me.lblVerification.Name = "lblVerification"
        Me.lblVerification.Size = New System.Drawing.Size(59, 13)
        Me.lblVerification.TabIndex = 47
        Me.lblVerification.Text = "Verification"
        '
        'rchVerification
        '
        Me.rchVerification.Location = New System.Drawing.Point(3, 421)
        Me.rchVerification.Name = "rchVerification"
        Me.rchVerification.Size = New System.Drawing.Size(316, 78)
        Me.rchVerification.TabIndex = 26
        Me.rchVerification.Text = ""
        '
        'lblAuditorName
        '
        Me.lblAuditorName.AutoSize = True
        Me.lblAuditorName.Location = New System.Drawing.Point(28, 385)
        Me.lblAuditorName.Name = "lblAuditorName"
        Me.lblAuditorName.Size = New System.Drawing.Size(86, 13)
        Me.lblAuditorName.TabIndex = 45
        Me.lblAuditorName.Text = "Name of Auditor:"
        '
        'dtpdateofAudit
        '
        Me.dtpdateofAudit.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdateofAudit.Location = New System.Drawing.Point(116, 356)
        Me.dtpdateofAudit.Name = "dtpdateofAudit"
        Me.dtpdateofAudit.Size = New System.Drawing.Size(87, 20)
        Me.dtpdateofAudit.TabIndex = 24
        Me.dtpdateofAudit.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'lblProductChangeYes
        '
        Me.lblProductChangeYes.AutoSize = True
        Me.lblProductChangeYes.Location = New System.Drawing.Point(12, 360)
        Me.lblProductChangeYes.Name = "lblProductChangeYes"
        Me.lblProductChangeYes.Size = New System.Drawing.Size(102, 13)
        Me.lblProductChangeYes.TabIndex = 43
        Me.lblProductChangeYes.Text = "If Yes, date of audit:"
        '
        'txtNameOfAuditor
        '
        Me.txtNameOfAuditor.Location = New System.Drawing.Point(116, 382)
        Me.txtNameOfAuditor.Name = "txtNameOfAuditor"
        Me.txtNameOfAuditor.Size = New System.Drawing.Size(200, 20)
        Me.txtNameOfAuditor.TabIndex = 25
        '
        'lblProductChange
        '
        Me.lblProductChange.AutoSize = True
        Me.lblProductChange.Location = New System.Drawing.Point(3, 313)
        Me.lblProductChange.Name = "lblProductChange"
        Me.lblProductChange.Size = New System.Drawing.Size(209, 13)
        Me.lblProductChange.TabIndex = 41
        Me.lblProductChange.Text = "Has Process or Procedure been changed?"
        '
        'lblReviewModCreate
        '
        Me.lblReviewModCreate.AutoSize = True
        Me.lblReviewModCreate.Location = New System.Drawing.Point(3, 273)
        Me.lblReviewModCreate.Name = "lblReviewModCreate"
        Me.lblReviewModCreate.Size = New System.Drawing.Size(140, 13)
        Me.lblReviewModCreate.TabIndex = 40
        Me.lblReviewModCreate.Text = "Review/Modify/Recurrence"
        '
        'lblPreventDate
        '
        Me.lblPreventDate.AutoSize = True
        Me.lblPreventDate.Location = New System.Drawing.Point(3, 234)
        Me.lblPreventDate.Name = "lblPreventDate"
        Me.lblPreventDate.Size = New System.Drawing.Size(104, 13)
        Me.lblPreventDate.TabIndex = 39
        Me.lblPreventDate.Text = "Implementation Date"
        '
        'dtpActionToPreventDate
        '
        Me.dtpActionToPreventDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpActionToPreventDate.Location = New System.Drawing.Point(3, 250)
        Me.dtpActionToPreventDate.Name = "dtpActionToPreventDate"
        Me.dtpActionToPreventDate.Size = New System.Drawing.Size(104, 20)
        Me.dtpActionToPreventDate.TabIndex = 21
        Me.dtpActionToPreventDate.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'lblActiontoPreventRecurrence
        '
        Me.lblActiontoPreventRecurrence.AutoSize = True
        Me.lblActiontoPreventRecurrence.Location = New System.Drawing.Point(3, 137)
        Me.lblActiontoPreventRecurrence.Name = "lblActiontoPreventRecurrence"
        Me.lblActiontoPreventRecurrence.Size = New System.Drawing.Size(159, 13)
        Me.lblActiontoPreventRecurrence.TabIndex = 37
        Me.lblActiontoPreventRecurrence.Text = "Action(s) to Prevent Recurrence"
        '
        'rchActionToPreventReccurr
        '
        Me.rchActionToPreventReccurr.Location = New System.Drawing.Point(3, 153)
        Me.rchActionToPreventReccurr.Name = "rchActionToPreventReccurr"
        Me.rchActionToPreventReccurr.Size = New System.Drawing.Size(316, 78)
        Me.rchActionToPreventReccurr.TabIndex = 20
        Me.rchActionToPreventReccurr.Text = ""
        '
        'lblImpPermCorrActionDate
        '
        Me.lblImpPermCorrActionDate.AutoSize = True
        Me.lblImpPermCorrActionDate.Location = New System.Drawing.Point(3, 97)
        Me.lblImpPermCorrActionDate.Name = "lblImpPermCorrActionDate"
        Me.lblImpPermCorrActionDate.Size = New System.Drawing.Size(104, 13)
        Me.lblImpPermCorrActionDate.TabIndex = 35
        Me.lblImpPermCorrActionDate.Text = "Implementation Date"
        '
        'dtpImpPermActionDate
        '
        Me.dtpImpPermActionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpImpPermActionDate.Location = New System.Drawing.Point(3, 113)
        Me.dtpImpPermActionDate.Name = "dtpImpPermActionDate"
        Me.dtpImpPermActionDate.Size = New System.Drawing.Size(104, 20)
        Me.dtpImpPermActionDate.TabIndex = 19
        Me.dtpImpPermActionDate.Value = New Date(2022, 10, 21, 8, 59, 35, 0)
        '
        'lblImplementedCorrect
        '
        Me.lblImplementedCorrect.AutoSize = True
        Me.lblImplementedCorrect.Location = New System.Drawing.Point(3, 3)
        Me.lblImplementedCorrect.Name = "lblImplementedCorrect"
        Me.lblImplementedCorrect.Size = New System.Drawing.Size(216, 13)
        Me.lblImplementedCorrect.TabIndex = 17
        Me.lblImplementedCorrect.Text = "Implemented Permanent Corrective Action(s)"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtDept)
        Me.TabPage3.Controls.Add(Me.lblDept)
        Me.TabPage3.Controls.Add(Me.txtNameOf)
        Me.TabPage3.Controls.Add(Me.lblNameBy)
        Me.TabPage3.Controls.Add(Me.txtReportedBy)
        Me.TabPage3.Controls.Add(Me.lblReportedBy)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(322, 627)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Page 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(9, 106)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(294, 20)
        Me.txtDept.TabIndex = 33
        '
        'lblDept
        '
        Me.lblDept.AutoSize = True
        Me.lblDept.Location = New System.Drawing.Point(6, 90)
        Me.lblDept.Name = "lblDept"
        Me.lblDept.Size = New System.Drawing.Size(62, 13)
        Me.lblDept.TabIndex = 56
        Me.lblDept.Text = "Department"
        '
        'txtNameOf
        '
        Me.txtNameOf.Location = New System.Drawing.Point(9, 66)
        Me.txtNameOf.Name = "txtNameOf"
        Me.txtNameOf.Size = New System.Drawing.Size(294, 20)
        Me.txtNameOf.TabIndex = 32
        '
        'lblNameBy
        '
        Me.lblNameBy.AutoSize = True
        Me.lblNameBy.Location = New System.Drawing.Point(6, 50)
        Me.lblNameBy.Name = "lblNameBy"
        Me.lblNameBy.Size = New System.Drawing.Size(35, 13)
        Me.lblNameBy.TabIndex = 54
        Me.lblNameBy.Text = "Name"
        '
        'txtReportedBy
        '
        Me.txtReportedBy.Location = New System.Drawing.Point(9, 27)
        Me.txtReportedBy.Name = "txtReportedBy"
        Me.txtReportedBy.Size = New System.Drawing.Size(294, 20)
        Me.txtReportedBy.TabIndex = 31
        '
        'lblReportedBy
        '
        Me.lblReportedBy.AutoSize = True
        Me.lblReportedBy.Location = New System.Drawing.Point(6, 11)
        Me.lblReportedBy.Name = "lblReportedBy"
        Me.lblReportedBy.Size = New System.Drawing.Size(69, 13)
        Me.lblReportedBy.TabIndex = 53
        Me.lblReportedBy.Text = "Reported By:"
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(12, 686)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(91, 32)
        Me.cmdView.TabIndex = 34
        Me.cmdView.Text = "View"
        Me.ToolTip3.SetToolTip(Me.cmdView, "Views form")
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(120, 686)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(91, 32)
        Me.cmdClear.TabIndex = 35
        Me.cmdClear.Text = "Clear"
        Me.ToolTip4.SetToolTip(Me.cmdClear, "Clears Data")
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(228, 724)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(91, 32)
        Me.cmdExit.TabIndex = 36
        Me.cmdExit.Text = "Exit"
        Me.ToolTip6.SetToolTip(Me.cmdExit, "Exits Form")
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'CRCustomerYTDViewer
        '
        Me.CRCustomerYTDViewer.ActiveViewIndex = 0
        Me.CRCustomerYTDViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRCustomerYTDViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCustomerYTDViewer.DisplayGroupTree = False
        Me.CRCustomerYTDViewer.Location = New System.Drawing.Point(334, 27)
        Me.CRCustomerYTDViewer.Name = "CRCustomerYTDViewer"
        Me.CRCustomerYTDViewer.ReportSource = Me.CRXCorrectiveActionForm1
        Me.CRCustomerYTDViewer.ShowGroupTreeButton = False
        Me.CRCustomerYTDViewer.ShowTextSearchButton = False
        Me.CRCustomerYTDViewer.ShowZoomButton = False
        Me.CRCustomerYTDViewer.Size = New System.Drawing.Size(912, 722)
        Me.CRCustomerYTDViewer.TabIndex = 2
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1248, 24)
        Me.MenuStrip1.TabIndex = 37
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailAuthorizationToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'EmailAuthorizationToolStripMenuItem
        '
        Me.EmailAuthorizationToolStripMenuItem.Name = "EmailAuthorizationToolStripMenuItem"
        Me.EmailAuthorizationToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.EmailAuthorizationToolStripMenuItem.Text = "Email Authorization"
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
        'RMATableTableAdapter
        '
        Me.RMATableTableAdapter.ClearBeforeFill = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 724)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(91, 32)
        Me.cmdSave.TabIndex = 38
        Me.cmdSave.Text = "Save"
        Me.ToolTip5.SetToolTip(Me.cmdSave, "Saves Data")
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(120, 724)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(91, 32)
        Me.cmdDelete.TabIndex = 39
        Me.cmdDelete.Text = "Delete CAR"
        Me.ToolTip4.SetToolTip(Me.cmdDelete, "Clears Data")
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'PrintCorrectivePreventiceActionReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 761)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CRCustomerYTDViewer)
        Me.Name = "PrintCorrectivePreventiceActionReport"
        Me.Text = "PrintCorrectivePreventiceActionReport"
        CType(Me.RMATableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRCustomerYTDViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cboCARNum As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents cboReviewModifyCreate As System.Windows.Forms.ComboBox
    Friend WithEvents cboProductChanged As System.Windows.Forms.ComboBox
    Friend WithEvents cboVerifiedBy As System.Windows.Forms.ComboBox
    Friend WithEvents cboOpenClosed As System.Windows.Forms.ComboBox
    Friend WithEvents rchContainmentAction As System.Windows.Forms.RichTextBox
    Friend WithEvents rchInterimCorrect As System.Windows.Forms.RichTextBox
    Friend WithEvents rchPermCorrAction As System.Windows.Forms.RichTextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblCar As System.Windows.Forms.Label
    Friend WithEvents lblPart As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents dtpDateOpened As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents lblDateOpened As System.Windows.Forms.Label
    Friend WithEvents dtpOccuranceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents rchRoot As System.Windows.Forms.RichTextBox
    Friend WithEvents dtpContainImpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboChampion As System.Windows.Forms.ComboBox
    Friend WithEvents lblTeamChamp As System.Windows.Forms.Label
    Friend WithEvents lblDateofOccurrence As System.Windows.Forms.Label
    Friend WithEvents lblContainment As System.Windows.Forms.Label
    Friend WithEvents lblContainDate As System.Windows.Forms.Label
    Friend WithEvents lblVerifyDate As System.Windows.Forms.Label
    Friend WithEvents lblChosen As System.Windows.Forms.Label
    Friend WithEvents dtpVerifyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRoot As System.Windows.Forms.Label
    Friend WithEvents lblImplementedCorrect As System.Windows.Forms.Label
    Friend WithEvents lblPreventDate As System.Windows.Forms.Label
    Friend WithEvents dtpActionToPreventDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblActiontoPreventRecurrence As System.Windows.Forms.Label
    Friend WithEvents rchActionToPreventReccurr As System.Windows.Forms.RichTextBox
    Friend WithEvents lblImpPermCorrActionDate As System.Windows.Forms.Label
    Friend WithEvents dtpImpPermActionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpdateofAudit As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProductChangeYes As System.Windows.Forms.Label
    Friend WithEvents txtNameOfAuditor As System.Windows.Forms.TextBox
    Friend WithEvents lblProductChange As System.Windows.Forms.Label
    Friend WithEvents lblReviewModCreate As System.Windows.Forms.Label
    Friend WithEvents lblVerification As System.Windows.Forms.Label
    Friend WithEvents rchVerification As System.Windows.Forms.RichTextBox
    Friend WithEvents lblAuditorName As System.Windows.Forms.Label
    Friend WithEvents lblOpenClose As System.Windows.Forms.Label
    Friend WithEvents dtpStatusCARDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCarStatus As System.Windows.Forms.Label
    Friend WithEvents dtpCloseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVerifiedBy As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtNameOf As System.Windows.Forms.TextBox
    Friend WithEvents lblNameBy As System.Windows.Forms.Label
    Friend WithEvents txtReportedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblReportedBy As System.Windows.Forms.Label
    Friend WithEvents lblCloseDate As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents lblDept As System.Windows.Forms.Label
    Friend WithEvents CRXCorrectiveActionForm1 As MOS09Program.CRXCorrectiveActionForm
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents lblProblemDef As System.Windows.Forms.Label
    Friend WithEvents rchProblemDef As System.Windows.Forms.RichTextBox
    Friend WithEvents txtChampion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivision As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailAuthorizationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RMATableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RMATableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RMATableTableAdapter
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents lblExists As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip5 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip6 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
End Class
