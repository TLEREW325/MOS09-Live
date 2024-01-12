<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewShotTest
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
        Me.dgvShotAnalysis = New System.Windows.Forms.DataGridView
        Me.ScreenShotAnalysisTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblOMN104 = New System.Windows.Forms.Label
        Me.grpWeight = New System.Windows.Forms.GroupBox
        Me.txtTotalNorth = New System.Windows.Forms.TextBox
        Me.lbltotalNperc = New System.Windows.Forms.Label
        Me.lblperc5 = New System.Windows.Forms.Label
        Me.lblPAN = New System.Windows.Forms.Label
        Me.txtPAN = New System.Windows.Forms.TextBox
        Me.txtNorth94Perc = New System.Windows.Forms.TextBox
        Me.lblperc4 = New System.Windows.Forms.Label
        Me.txtNorth100Perc = New System.Windows.Forms.TextBox
        Me.lblperc3 = New System.Windows.Forms.Label
        Me.txtNorth95Perc = New System.Windows.Forms.TextBox
        Me.lblPerc2 = New System.Windows.Forms.Label
        Me.txtNorth96Perc = New System.Windows.Forms.TextBox
        Me.lblPerc1 = New System.Windows.Forms.Label
        Me.txtNorth104Perc = New System.Windows.Forms.TextBox
        Me.txtNorth94 = New System.Windows.Forms.TextBox
        Me.txtNorth100 = New System.Windows.Forms.TextBox
        Me.txtNorth95 = New System.Windows.Forms.TextBox
        Me.txtNorth96 = New System.Windows.Forms.TextBox
        Me.txtNorth104 = New System.Windows.Forms.TextBox
        Me.lblOMN94 = New System.Windows.Forms.Label
        Me.lblOMN100 = New System.Windows.Forms.Label
        Me.lblOMN95 = New System.Windows.Forms.Label
        Me.lblOMN96 = New System.Windows.Forms.Label
        Me.grpWeightS = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPANSouth = New System.Windows.Forms.TextBox
        Me.txtTotalSouth = New System.Windows.Forms.TextBox
        Me.lbltotalSperc = New System.Windows.Forms.Label
        Me.lblperc10 = New System.Windows.Forms.Label
        Me.txtSouth94Perc = New System.Windows.Forms.TextBox
        Me.lblPerc9 = New System.Windows.Forms.Label
        Me.txtSouth100Perc = New System.Windows.Forms.TextBox
        Me.lblPerc8 = New System.Windows.Forms.Label
        Me.txtSouth95Perc = New System.Windows.Forms.TextBox
        Me.lblperc7 = New System.Windows.Forms.Label
        Me.txtSouth96Perc = New System.Windows.Forms.TextBox
        Me.lblperc6 = New System.Windows.Forms.Label
        Me.txtSouth94 = New System.Windows.Forms.TextBox
        Me.txtSouth104Perc = New System.Windows.Forms.TextBox
        Me.txtSouth100 = New System.Windows.Forms.TextBox
        Me.txtSouth95 = New System.Windows.Forms.TextBox
        Me.txtSouth96 = New System.Windows.Forms.TextBox
        Me.txtSouth104 = New System.Windows.Forms.TextBox
        Me.lblOMS94 = New System.Windows.Forms.Label
        Me.lblOMS100 = New System.Windows.Forms.Label
        Me.lblOMS95 = New System.Windows.Forms.Label
        Me.lblOMS96 = New System.Windows.Forms.Label
        Me.lblOMS104 = New System.Windows.Forms.Label
        Me.grpAmps = New System.Windows.Forms.GroupBox
        Me.txtTotalAmps = New System.Windows.Forms.TextBox
        Me.lbltotalWperc = New System.Windows.Forms.Label
        Me.txtBlastWheel6Perc = New System.Windows.Forms.TextBox
        Me.lblperc16 = New System.Windows.Forms.Label
        Me.txtBlastWheel6 = New System.Windows.Forms.TextBox
        Me.lblWA6 = New System.Windows.Forms.Label
        Me.lblperc15 = New System.Windows.Forms.Label
        Me.txtBlastWheel5Perc = New System.Windows.Forms.TextBox
        Me.lblperc14 = New System.Windows.Forms.Label
        Me.txtBlastWheel4Perc = New System.Windows.Forms.TextBox
        Me.lblperc13 = New System.Windows.Forms.Label
        Me.txtBlastWheel3Perc = New System.Windows.Forms.TextBox
        Me.lblperc12 = New System.Windows.Forms.Label
        Me.txtBlastWheel2Perc = New System.Windows.Forms.TextBox
        Me.lblperc11 = New System.Windows.Forms.Label
        Me.txtBlastWheel1Perc = New System.Windows.Forms.TextBox
        Me.txtBlastWheel5 = New System.Windows.Forms.TextBox
        Me.txtBlastWheel4 = New System.Windows.Forms.TextBox
        Me.txtBlastWheel3 = New System.Windows.Forms.TextBox
        Me.txtBlastWheel2 = New System.Windows.Forms.TextBox
        Me.txtBlastWheel1 = New System.Windows.Forms.TextBox
        Me.lblWA5 = New System.Windows.Forms.Label
        Me.lblWA4 = New System.Windows.Forms.Label
        Me.lblWA3 = New System.Windows.Forms.Label
        Me.lblWA2 = New System.Windows.Forms.Label
        Me.lblWA1 = New System.Windows.Forms.Label
        Me.cmdCalculate = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cboShotID = New System.Windows.Forms.ComboBox
        Me.lblShot = New System.Windows.Forms.Label
        Me.cmdViewSave = New System.Windows.Forms.Button
        Me.lblAbrSize = New System.Windows.Forms.Label
        Me.txtAbrSize = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.lblDate = New System.Windows.Forms.Label
        Me.ScreenShotAnalysisTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ScreenShotAnalysisTableTableAdapter
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdView = New System.Windows.Forms.Button
        Me.ShotIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AbrasiveSizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PANNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.North104DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.North100DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.North96DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.North95DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.North94DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PANNumberSouth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.South104DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.South100DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.South96DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.South95DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.South94DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Wheel1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Wheel2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Wheel3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Wheel4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Wheel5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Wheel6DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvShotAnalysis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenShotAnalysisTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpWeight.SuspendLayout()
        Me.grpWeightS.SuspendLayout()
        Me.grpAmps.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvShotAnalysis
        '
        Me.dgvShotAnalysis.AutoGenerateColumns = False
        Me.dgvShotAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShotAnalysis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShotIDDataGridViewTextBoxColumn, Me.AbrasiveSizeDataGridViewTextBoxColumn, Me.DateCreatedDataGridViewTextBoxColumn, Me.PANNumberDataGridViewTextBoxColumn, Me.North104DataGridViewTextBoxColumn, Me.North100DataGridViewTextBoxColumn, Me.North96DataGridViewTextBoxColumn, Me.North95DataGridViewTextBoxColumn, Me.North94DataGridViewTextBoxColumn, Me.PANNumberSouth, Me.South104DataGridViewTextBoxColumn, Me.South100DataGridViewTextBoxColumn, Me.South96DataGridViewTextBoxColumn, Me.South95DataGridViewTextBoxColumn, Me.South94DataGridViewTextBoxColumn, Me.Wheel1DataGridViewTextBoxColumn, Me.Wheel2DataGridViewTextBoxColumn, Me.Wheel3DataGridViewTextBoxColumn, Me.Wheel4DataGridViewTextBoxColumn, Me.Wheel5DataGridViewTextBoxColumn, Me.Wheel6DataGridViewTextBoxColumn})
        Me.dgvShotAnalysis.DataSource = Me.ScreenShotAnalysisTableBindingSource
        Me.dgvShotAnalysis.Location = New System.Drawing.Point(309, 31)
        Me.dgvShotAnalysis.Name = "dgvShotAnalysis"
        Me.dgvShotAnalysis.ReadOnly = True
        Me.dgvShotAnalysis.Size = New System.Drawing.Size(721, 782)
        Me.dgvShotAnalysis.TabIndex = 0
        '
        'ScreenShotAnalysisTableBindingSource
        '
        Me.ScreenShotAnalysisTableBindingSource.DataMember = "ScreenShotAnalysisTable"
        Me.ScreenShotAnalysisTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblOMN104
        '
        Me.lblOMN104.AutoSize = True
        Me.lblOMN104.Location = New System.Drawing.Point(22, 26)
        Me.lblOMN104.Name = "lblOMN104"
        Me.lblOMN104.Size = New System.Drawing.Size(31, 13)
        Me.lblOMN104.TabIndex = 5
        Me.lblOMN104.Text = "108: "
        '
        'grpWeight
        '
        Me.grpWeight.Controls.Add(Me.txtTotalNorth)
        Me.grpWeight.Controls.Add(Me.lbltotalNperc)
        Me.grpWeight.Controls.Add(Me.lblperc5)
        Me.grpWeight.Controls.Add(Me.lblPAN)
        Me.grpWeight.Controls.Add(Me.txtPAN)
        Me.grpWeight.Controls.Add(Me.txtNorth94Perc)
        Me.grpWeight.Controls.Add(Me.lblperc4)
        Me.grpWeight.Controls.Add(Me.txtNorth100Perc)
        Me.grpWeight.Controls.Add(Me.lblperc3)
        Me.grpWeight.Controls.Add(Me.txtNorth95Perc)
        Me.grpWeight.Controls.Add(Me.lblPerc2)
        Me.grpWeight.Controls.Add(Me.txtNorth96Perc)
        Me.grpWeight.Controls.Add(Me.lblPerc1)
        Me.grpWeight.Controls.Add(Me.txtNorth104Perc)
        Me.grpWeight.Controls.Add(Me.txtNorth94)
        Me.grpWeight.Controls.Add(Me.txtNorth100)
        Me.grpWeight.Controls.Add(Me.txtNorth95)
        Me.grpWeight.Controls.Add(Me.txtNorth96)
        Me.grpWeight.Controls.Add(Me.txtNorth104)
        Me.grpWeight.Controls.Add(Me.lblOMN94)
        Me.grpWeight.Controls.Add(Me.lblOMN100)
        Me.grpWeight.Controls.Add(Me.lblOMN95)
        Me.grpWeight.Controls.Add(Me.lblOMN96)
        Me.grpWeight.Controls.Add(Me.lblOMN104)
        Me.grpWeight.Location = New System.Drawing.Point(8, 125)
        Me.grpWeight.Name = "grpWeight"
        Me.grpWeight.Size = New System.Drawing.Size(291, 150)
        Me.grpWeight.TabIndex = 4
        Me.grpWeight.TabStop = False
        Me.grpWeight.Text = "Operating Mix North"
        '
        'txtTotalNorth
        '
        Me.txtTotalNorth.Location = New System.Drawing.Point(235, 121)
        Me.txtTotalNorth.Name = "txtTotalNorth"
        Me.txtTotalNorth.ReadOnly = True
        Me.txtTotalNorth.Size = New System.Drawing.Size(49, 20)
        Me.txtTotalNorth.TabIndex = 33
        Me.txtTotalNorth.TabStop = False
        '
        'lbltotalNperc
        '
        Me.lbltotalNperc.AutoSize = True
        Me.lbltotalNperc.Location = New System.Drawing.Point(159, 124)
        Me.lbltotalNperc.Name = "lbltotalNperc"
        Me.lbltotalNperc.Size = New System.Drawing.Size(71, 13)
        Me.lbltotalNperc.TabIndex = 33
        Me.lbltotalNperc.Text = "Total Weight:"
        '
        'lblperc5
        '
        Me.lblperc5.AutoSize = True
        Me.lblperc5.Location = New System.Drawing.Point(165, 98)
        Me.lblperc5.Name = "lblperc5"
        Me.lblperc5.Size = New System.Drawing.Size(65, 13)
        Me.lblperc5.TabIndex = 20
        Me.lblperc5.Text = "Percentage:"
        '
        'lblPAN
        '
        Me.lblPAN.AutoSize = True
        Me.lblPAN.Location = New System.Drawing.Point(22, 125)
        Me.lblPAN.Name = "lblPAN"
        Me.lblPAN.Size = New System.Drawing.Size(32, 13)
        Me.lblPAN.TabIndex = 44
        Me.lblPAN.Text = "PAN:"
        '
        'txtPAN
        '
        Me.txtPAN.Location = New System.Drawing.Point(59, 122)
        Me.txtPAN.Name = "txtPAN"
        Me.txtPAN.Size = New System.Drawing.Size(100, 20)
        Me.txtPAN.TabIndex = 2
        '
        'txtNorth94Perc
        '
        Me.txtNorth94Perc.Location = New System.Drawing.Point(236, 95)
        Me.txtNorth94Perc.Name = "txtNorth94Perc"
        Me.txtNorth94Perc.ReadOnly = True
        Me.txtNorth94Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtNorth94Perc.TabIndex = 19
        Me.txtNorth94Perc.TabStop = False
        '
        'lblperc4
        '
        Me.lblperc4.AutoSize = True
        Me.lblperc4.Location = New System.Drawing.Point(165, 80)
        Me.lblperc4.Name = "lblperc4"
        Me.lblperc4.Size = New System.Drawing.Size(65, 13)
        Me.lblperc4.TabIndex = 18
        Me.lblperc4.Text = "Percentage:"
        '
        'txtNorth100Perc
        '
        Me.txtNorth100Perc.Location = New System.Drawing.Point(236, 77)
        Me.txtNorth100Perc.Name = "txtNorth100Perc"
        Me.txtNorth100Perc.ReadOnly = True
        Me.txtNorth100Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtNorth100Perc.TabIndex = 17
        Me.txtNorth100Perc.TabStop = False
        '
        'lblperc3
        '
        Me.lblperc3.AutoSize = True
        Me.lblperc3.Location = New System.Drawing.Point(165, 62)
        Me.lblperc3.Name = "lblperc3"
        Me.lblperc3.Size = New System.Drawing.Size(65, 13)
        Me.lblperc3.TabIndex = 16
        Me.lblperc3.Text = "Percentage:"
        '
        'txtNorth95Perc
        '
        Me.txtNorth95Perc.Location = New System.Drawing.Point(236, 59)
        Me.txtNorth95Perc.Name = "txtNorth95Perc"
        Me.txtNorth95Perc.ReadOnly = True
        Me.txtNorth95Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtNorth95Perc.TabIndex = 15
        Me.txtNorth95Perc.TabStop = False
        '
        'lblPerc2
        '
        Me.lblPerc2.AutoSize = True
        Me.lblPerc2.Location = New System.Drawing.Point(165, 44)
        Me.lblPerc2.Name = "lblPerc2"
        Me.lblPerc2.Size = New System.Drawing.Size(65, 13)
        Me.lblPerc2.TabIndex = 14
        Me.lblPerc2.Text = "Percentage:"
        '
        'txtNorth96Perc
        '
        Me.txtNorth96Perc.Location = New System.Drawing.Point(236, 41)
        Me.txtNorth96Perc.Name = "txtNorth96Perc"
        Me.txtNorth96Perc.ReadOnly = True
        Me.txtNorth96Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtNorth96Perc.TabIndex = 13
        Me.txtNorth96Perc.TabStop = False
        '
        'lblPerc1
        '
        Me.lblPerc1.AutoSize = True
        Me.lblPerc1.Location = New System.Drawing.Point(165, 26)
        Me.lblPerc1.Name = "lblPerc1"
        Me.lblPerc1.Size = New System.Drawing.Size(65, 13)
        Me.lblPerc1.TabIndex = 12
        Me.lblPerc1.Text = "Percentage:"
        '
        'txtNorth104Perc
        '
        Me.txtNorth104Perc.Location = New System.Drawing.Point(236, 23)
        Me.txtNorth104Perc.Name = "txtNorth104Perc"
        Me.txtNorth104Perc.ReadOnly = True
        Me.txtNorth104Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtNorth104Perc.TabIndex = 11
        Me.txtNorth104Perc.TabStop = False
        '
        'txtNorth94
        '
        Me.txtNorth94.Location = New System.Drawing.Point(59, 95)
        Me.txtNorth94.Name = "txtNorth94"
        Me.txtNorth94.Size = New System.Drawing.Size(100, 20)
        Me.txtNorth94.TabIndex = 4
        '
        'txtNorth100
        '
        Me.txtNorth100.Location = New System.Drawing.Point(59, 77)
        Me.txtNorth100.Name = "txtNorth100"
        Me.txtNorth100.Size = New System.Drawing.Size(100, 20)
        Me.txtNorth100.TabIndex = 3
        '
        'txtNorth95
        '
        Me.txtNorth95.Location = New System.Drawing.Point(59, 59)
        Me.txtNorth95.Name = "txtNorth95"
        Me.txtNorth95.Size = New System.Drawing.Size(100, 20)
        Me.txtNorth95.TabIndex = 2
        '
        'txtNorth96
        '
        Me.txtNorth96.Location = New System.Drawing.Point(59, 41)
        Me.txtNorth96.Name = "txtNorth96"
        Me.txtNorth96.Size = New System.Drawing.Size(100, 20)
        Me.txtNorth96.TabIndex = 1
        '
        'txtNorth104
        '
        Me.txtNorth104.Location = New System.Drawing.Point(59, 23)
        Me.txtNorth104.Name = "txtNorth104"
        Me.txtNorth104.Size = New System.Drawing.Size(100, 20)
        Me.txtNorth104.TabIndex = 0
        '
        'lblOMN94
        '
        Me.lblOMN94.AutoSize = True
        Me.lblOMN94.Location = New System.Drawing.Point(22, 98)
        Me.lblOMN94.Name = "lblOMN94"
        Me.lblOMN94.Size = New System.Drawing.Size(25, 13)
        Me.lblOMN94.TabIndex = 5
        Me.lblOMN94.Text = "97: "
        '
        'lblOMN100
        '
        Me.lblOMN100.AutoSize = True
        Me.lblOMN100.Location = New System.Drawing.Point(22, 80)
        Me.lblOMN100.Name = "lblOMN100"
        Me.lblOMN100.Size = New System.Drawing.Size(31, 13)
        Me.lblOMN100.TabIndex = 4
        Me.lblOMN100.Text = "104: "
        '
        'lblOMN95
        '
        Me.lblOMN95.AutoSize = True
        Me.lblOMN95.Location = New System.Drawing.Point(22, 62)
        Me.lblOMN95.Name = "lblOMN95"
        Me.lblOMN95.Size = New System.Drawing.Size(25, 13)
        Me.lblOMN95.TabIndex = 3
        Me.lblOMN95.Text = "97: "
        '
        'lblOMN96
        '
        Me.lblOMN96.AutoSize = True
        Me.lblOMN96.Location = New System.Drawing.Point(22, 44)
        Me.lblOMN96.Name = "lblOMN96"
        Me.lblOMN96.Size = New System.Drawing.Size(25, 13)
        Me.lblOMN96.TabIndex = 4
        Me.lblOMN96.Text = "99: "
        '
        'grpWeightS
        '
        Me.grpWeightS.Controls.Add(Me.Label1)
        Me.grpWeightS.Controls.Add(Me.txtPANSouth)
        Me.grpWeightS.Controls.Add(Me.txtTotalSouth)
        Me.grpWeightS.Controls.Add(Me.lbltotalSperc)
        Me.grpWeightS.Controls.Add(Me.lblperc10)
        Me.grpWeightS.Controls.Add(Me.txtSouth94Perc)
        Me.grpWeightS.Controls.Add(Me.lblPerc9)
        Me.grpWeightS.Controls.Add(Me.txtSouth100Perc)
        Me.grpWeightS.Controls.Add(Me.lblPerc8)
        Me.grpWeightS.Controls.Add(Me.txtSouth95Perc)
        Me.grpWeightS.Controls.Add(Me.lblperc7)
        Me.grpWeightS.Controls.Add(Me.txtSouth96Perc)
        Me.grpWeightS.Controls.Add(Me.lblperc6)
        Me.grpWeightS.Controls.Add(Me.txtSouth94)
        Me.grpWeightS.Controls.Add(Me.txtSouth104Perc)
        Me.grpWeightS.Controls.Add(Me.txtSouth100)
        Me.grpWeightS.Controls.Add(Me.txtSouth95)
        Me.grpWeightS.Controls.Add(Me.txtSouth96)
        Me.grpWeightS.Controls.Add(Me.txtSouth104)
        Me.grpWeightS.Controls.Add(Me.lblOMS94)
        Me.grpWeightS.Controls.Add(Me.lblOMS100)
        Me.grpWeightS.Controls.Add(Me.lblOMS95)
        Me.grpWeightS.Controls.Add(Me.lblOMS96)
        Me.grpWeightS.Controls.Add(Me.lblOMS104)
        Me.grpWeightS.Location = New System.Drawing.Point(8, 281)
        Me.grpWeightS.Name = "grpWeightS"
        Me.grpWeightS.Size = New System.Drawing.Size(291, 150)
        Me.grpWeightS.TabIndex = 5
        Me.grpWeightS.TabStop = False
        Me.grpWeightS.Text = "Operating Mix South"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "PAN:"
        '
        'txtPANSouth
        '
        Me.txtPANSouth.Location = New System.Drawing.Point(59, 120)
        Me.txtPANSouth.Name = "txtPANSouth"
        Me.txtPANSouth.Size = New System.Drawing.Size(100, 20)
        Me.txtPANSouth.TabIndex = 45
        '
        'txtTotalSouth
        '
        Me.txtTotalSouth.Location = New System.Drawing.Point(236, 120)
        Me.txtTotalSouth.Name = "txtTotalSouth"
        Me.txtTotalSouth.ReadOnly = True
        Me.txtTotalSouth.Size = New System.Drawing.Size(49, 20)
        Me.txtTotalSouth.TabIndex = 32
        Me.txtTotalSouth.TabStop = False
        '
        'lbltotalSperc
        '
        Me.lbltotalSperc.AutoSize = True
        Me.lbltotalSperc.Location = New System.Drawing.Point(159, 123)
        Me.lbltotalSperc.Name = "lbltotalSperc"
        Me.lbltotalSperc.Size = New System.Drawing.Size(71, 13)
        Me.lbltotalSperc.TabIndex = 31
        Me.lbltotalSperc.Text = "Total Weight:"
        '
        'lblperc10
        '
        Me.lblperc10.AutoSize = True
        Me.lblperc10.Location = New System.Drawing.Point(165, 98)
        Me.lblperc10.Name = "lblperc10"
        Me.lblperc10.Size = New System.Drawing.Size(65, 13)
        Me.lblperc10.TabIndex = 30
        Me.lblperc10.Text = "Percentage:"
        '
        'txtSouth94Perc
        '
        Me.txtSouth94Perc.Location = New System.Drawing.Point(236, 95)
        Me.txtSouth94Perc.Name = "txtSouth94Perc"
        Me.txtSouth94Perc.ReadOnly = True
        Me.txtSouth94Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtSouth94Perc.TabIndex = 29
        Me.txtSouth94Perc.TabStop = False
        '
        'lblPerc9
        '
        Me.lblPerc9.AutoSize = True
        Me.lblPerc9.Location = New System.Drawing.Point(165, 80)
        Me.lblPerc9.Name = "lblPerc9"
        Me.lblPerc9.Size = New System.Drawing.Size(65, 13)
        Me.lblPerc9.TabIndex = 28
        Me.lblPerc9.Text = "Percentage:"
        '
        'txtSouth100Perc
        '
        Me.txtSouth100Perc.Location = New System.Drawing.Point(236, 77)
        Me.txtSouth100Perc.Name = "txtSouth100Perc"
        Me.txtSouth100Perc.ReadOnly = True
        Me.txtSouth100Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtSouth100Perc.TabIndex = 27
        Me.txtSouth100Perc.TabStop = False
        '
        'lblPerc8
        '
        Me.lblPerc8.AutoSize = True
        Me.lblPerc8.Location = New System.Drawing.Point(165, 62)
        Me.lblPerc8.Name = "lblPerc8"
        Me.lblPerc8.Size = New System.Drawing.Size(65, 13)
        Me.lblPerc8.TabIndex = 26
        Me.lblPerc8.Text = "Percentage:"
        '
        'txtSouth95Perc
        '
        Me.txtSouth95Perc.Location = New System.Drawing.Point(236, 59)
        Me.txtSouth95Perc.Name = "txtSouth95Perc"
        Me.txtSouth95Perc.ReadOnly = True
        Me.txtSouth95Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtSouth95Perc.TabIndex = 25
        Me.txtSouth95Perc.TabStop = False
        '
        'lblperc7
        '
        Me.lblperc7.AutoSize = True
        Me.lblperc7.Location = New System.Drawing.Point(165, 44)
        Me.lblperc7.Name = "lblperc7"
        Me.lblperc7.Size = New System.Drawing.Size(65, 13)
        Me.lblperc7.TabIndex = 24
        Me.lblperc7.Text = "Percentage:"
        '
        'txtSouth96Perc
        '
        Me.txtSouth96Perc.Location = New System.Drawing.Point(236, 41)
        Me.txtSouth96Perc.Name = "txtSouth96Perc"
        Me.txtSouth96Perc.ReadOnly = True
        Me.txtSouth96Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtSouth96Perc.TabIndex = 23
        Me.txtSouth96Perc.TabStop = False
        '
        'lblperc6
        '
        Me.lblperc6.AutoSize = True
        Me.lblperc6.Location = New System.Drawing.Point(165, 26)
        Me.lblperc6.Name = "lblperc6"
        Me.lblperc6.Size = New System.Drawing.Size(65, 13)
        Me.lblperc6.TabIndex = 22
        Me.lblperc6.Text = "Percentage:"
        '
        'txtSouth94
        '
        Me.txtSouth94.Location = New System.Drawing.Point(59, 95)
        Me.txtSouth94.Name = "txtSouth94"
        Me.txtSouth94.Size = New System.Drawing.Size(100, 20)
        Me.txtSouth94.TabIndex = 4
        '
        'txtSouth104Perc
        '
        Me.txtSouth104Perc.Location = New System.Drawing.Point(236, 23)
        Me.txtSouth104Perc.Name = "txtSouth104Perc"
        Me.txtSouth104Perc.ReadOnly = True
        Me.txtSouth104Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtSouth104Perc.TabIndex = 21
        Me.txtSouth104Perc.TabStop = False
        '
        'txtSouth100
        '
        Me.txtSouth100.Location = New System.Drawing.Point(59, 77)
        Me.txtSouth100.Name = "txtSouth100"
        Me.txtSouth100.Size = New System.Drawing.Size(100, 20)
        Me.txtSouth100.TabIndex = 3
        '
        'txtSouth95
        '
        Me.txtSouth95.Location = New System.Drawing.Point(59, 59)
        Me.txtSouth95.Name = "txtSouth95"
        Me.txtSouth95.Size = New System.Drawing.Size(100, 20)
        Me.txtSouth95.TabIndex = 2
        '
        'txtSouth96
        '
        Me.txtSouth96.Location = New System.Drawing.Point(59, 41)
        Me.txtSouth96.Name = "txtSouth96"
        Me.txtSouth96.Size = New System.Drawing.Size(100, 20)
        Me.txtSouth96.TabIndex = 1
        '
        'txtSouth104
        '
        Me.txtSouth104.Location = New System.Drawing.Point(59, 23)
        Me.txtSouth104.Name = "txtSouth104"
        Me.txtSouth104.Size = New System.Drawing.Size(100, 20)
        Me.txtSouth104.TabIndex = 0
        '
        'lblOMS94
        '
        Me.lblOMS94.AutoSize = True
        Me.lblOMS94.Location = New System.Drawing.Point(22, 98)
        Me.lblOMS94.Name = "lblOMS94"
        Me.lblOMS94.Size = New System.Drawing.Size(22, 13)
        Me.lblOMS94.TabIndex = 5
        Me.lblOMS94.Text = "97:"
        '
        'lblOMS100
        '
        Me.lblOMS100.AutoSize = True
        Me.lblOMS100.Location = New System.Drawing.Point(22, 80)
        Me.lblOMS100.Name = "lblOMS100"
        Me.lblOMS100.Size = New System.Drawing.Size(28, 13)
        Me.lblOMS100.TabIndex = 4
        Me.lblOMS100.Text = "104:"
        '
        'lblOMS95
        '
        Me.lblOMS95.AutoSize = True
        Me.lblOMS95.Location = New System.Drawing.Point(22, 62)
        Me.lblOMS95.Name = "lblOMS95"
        Me.lblOMS95.Size = New System.Drawing.Size(22, 13)
        Me.lblOMS95.TabIndex = 3
        Me.lblOMS95.Text = "97:"
        '
        'lblOMS96
        '
        Me.lblOMS96.AutoSize = True
        Me.lblOMS96.Location = New System.Drawing.Point(22, 44)
        Me.lblOMS96.Name = "lblOMS96"
        Me.lblOMS96.Size = New System.Drawing.Size(22, 13)
        Me.lblOMS96.TabIndex = 2
        Me.lblOMS96.Text = "99:"
        '
        'lblOMS104
        '
        Me.lblOMS104.AutoSize = True
        Me.lblOMS104.Location = New System.Drawing.Point(22, 26)
        Me.lblOMS104.Name = "lblOMS104"
        Me.lblOMS104.Size = New System.Drawing.Size(31, 13)
        Me.lblOMS104.TabIndex = 1
        Me.lblOMS104.Text = "108: "
        '
        'grpAmps
        '
        Me.grpAmps.Controls.Add(Me.txtTotalAmps)
        Me.grpAmps.Controls.Add(Me.lbltotalWperc)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel6Perc)
        Me.grpAmps.Controls.Add(Me.lblperc16)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel6)
        Me.grpAmps.Controls.Add(Me.lblWA6)
        Me.grpAmps.Controls.Add(Me.lblperc15)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel5Perc)
        Me.grpAmps.Controls.Add(Me.lblperc14)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel4Perc)
        Me.grpAmps.Controls.Add(Me.lblperc13)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel3Perc)
        Me.grpAmps.Controls.Add(Me.lblperc12)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel2Perc)
        Me.grpAmps.Controls.Add(Me.lblperc11)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel1Perc)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel5)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel4)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel3)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel2)
        Me.grpAmps.Controls.Add(Me.txtBlastWheel1)
        Me.grpAmps.Controls.Add(Me.lblWA5)
        Me.grpAmps.Controls.Add(Me.lblWA4)
        Me.grpAmps.Controls.Add(Me.lblWA3)
        Me.grpAmps.Controls.Add(Me.lblWA2)
        Me.grpAmps.Controls.Add(Me.lblWA1)
        Me.grpAmps.Location = New System.Drawing.Point(8, 437)
        Me.grpAmps.Name = "grpAmps"
        Me.grpAmps.Size = New System.Drawing.Size(291, 168)
        Me.grpAmps.TabIndex = 6
        Me.grpAmps.TabStop = False
        Me.grpAmps.Text = "Wheel Amps"
        '
        'txtTotalAmps
        '
        Me.txtTotalAmps.Location = New System.Drawing.Point(236, 139)
        Me.txtTotalAmps.Name = "txtTotalAmps"
        Me.txtTotalAmps.ReadOnly = True
        Me.txtTotalAmps.Size = New System.Drawing.Size(49, 20)
        Me.txtTotalAmps.TabIndex = 33
        Me.txtTotalAmps.TabStop = False
        '
        'lbltotalWperc
        '
        Me.lbltotalWperc.AutoSize = True
        Me.lbltotalWperc.Location = New System.Drawing.Point(138, 142)
        Me.lbltotalWperc.Name = "lbltotalWperc"
        Me.lbltotalWperc.Size = New System.Drawing.Size(92, 13)
        Me.lbltotalWperc.TabIndex = 27
        Me.lbltotalWperc.Text = "Total Percentage:"
        '
        'txtBlastWheel6Perc
        '
        Me.txtBlastWheel6Perc.Location = New System.Drawing.Point(236, 113)
        Me.txtBlastWheel6Perc.Name = "txtBlastWheel6Perc"
        Me.txtBlastWheel6Perc.ReadOnly = True
        Me.txtBlastWheel6Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtBlastWheel6Perc.TabIndex = 26
        Me.txtBlastWheel6Perc.TabStop = False
        '
        'lblperc16
        '
        Me.lblperc16.AutoSize = True
        Me.lblperc16.Location = New System.Drawing.Point(165, 116)
        Me.lblperc16.Name = "lblperc16"
        Me.lblperc16.Size = New System.Drawing.Size(65, 13)
        Me.lblperc16.TabIndex = 25
        Me.lblperc16.Text = "Percentage:"
        '
        'txtBlastWheel6
        '
        Me.txtBlastWheel6.Location = New System.Drawing.Point(59, 113)
        Me.txtBlastWheel6.Name = "txtBlastWheel6"
        Me.txtBlastWheel6.Size = New System.Drawing.Size(100, 20)
        Me.txtBlastWheel6.TabIndex = 5
        '
        'lblWA6
        '
        Me.lblWA6.AutoSize = True
        Me.lblWA6.Location = New System.Drawing.Point(22, 116)
        Me.lblWA6.Name = "lblWA6"
        Me.lblWA6.Size = New System.Drawing.Size(16, 13)
        Me.lblWA6.TabIndex = 23
        Me.lblWA6.Text = "6:"
        '
        'lblperc15
        '
        Me.lblperc15.AutoSize = True
        Me.lblperc15.Location = New System.Drawing.Point(165, 98)
        Me.lblperc15.Name = "lblperc15"
        Me.lblperc15.Size = New System.Drawing.Size(65, 13)
        Me.lblperc15.TabIndex = 22
        Me.lblperc15.Text = "Percentage:"
        '
        'txtBlastWheel5Perc
        '
        Me.txtBlastWheel5Perc.Location = New System.Drawing.Point(236, 95)
        Me.txtBlastWheel5Perc.Name = "txtBlastWheel5Perc"
        Me.txtBlastWheel5Perc.ReadOnly = True
        Me.txtBlastWheel5Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtBlastWheel5Perc.TabIndex = 21
        Me.txtBlastWheel5Perc.TabStop = False
        '
        'lblperc14
        '
        Me.lblperc14.AutoSize = True
        Me.lblperc14.Location = New System.Drawing.Point(165, 80)
        Me.lblperc14.Name = "lblperc14"
        Me.lblperc14.Size = New System.Drawing.Size(65, 13)
        Me.lblperc14.TabIndex = 20
        Me.lblperc14.Text = "Percentage:"
        '
        'txtBlastWheel4Perc
        '
        Me.txtBlastWheel4Perc.Location = New System.Drawing.Point(236, 77)
        Me.txtBlastWheel4Perc.Name = "txtBlastWheel4Perc"
        Me.txtBlastWheel4Perc.ReadOnly = True
        Me.txtBlastWheel4Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtBlastWheel4Perc.TabIndex = 19
        Me.txtBlastWheel4Perc.TabStop = False
        '
        'lblperc13
        '
        Me.lblperc13.AutoSize = True
        Me.lblperc13.Location = New System.Drawing.Point(165, 62)
        Me.lblperc13.Name = "lblperc13"
        Me.lblperc13.Size = New System.Drawing.Size(65, 13)
        Me.lblperc13.TabIndex = 18
        Me.lblperc13.Text = "Percentage:"
        '
        'txtBlastWheel3Perc
        '
        Me.txtBlastWheel3Perc.Location = New System.Drawing.Point(236, 59)
        Me.txtBlastWheel3Perc.Name = "txtBlastWheel3Perc"
        Me.txtBlastWheel3Perc.ReadOnly = True
        Me.txtBlastWheel3Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtBlastWheel3Perc.TabIndex = 17
        Me.txtBlastWheel3Perc.TabStop = False
        '
        'lblperc12
        '
        Me.lblperc12.AutoSize = True
        Me.lblperc12.Location = New System.Drawing.Point(165, 44)
        Me.lblperc12.Name = "lblperc12"
        Me.lblperc12.Size = New System.Drawing.Size(65, 13)
        Me.lblperc12.TabIndex = 16
        Me.lblperc12.Text = "Percentage:"
        '
        'txtBlastWheel2Perc
        '
        Me.txtBlastWheel2Perc.Location = New System.Drawing.Point(236, 41)
        Me.txtBlastWheel2Perc.Name = "txtBlastWheel2Perc"
        Me.txtBlastWheel2Perc.ReadOnly = True
        Me.txtBlastWheel2Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtBlastWheel2Perc.TabIndex = 15
        Me.txtBlastWheel2Perc.TabStop = False
        '
        'lblperc11
        '
        Me.lblperc11.AutoSize = True
        Me.lblperc11.Location = New System.Drawing.Point(165, 26)
        Me.lblperc11.Name = "lblperc11"
        Me.lblperc11.Size = New System.Drawing.Size(65, 13)
        Me.lblperc11.TabIndex = 14
        Me.lblperc11.Text = "Percentage:"
        '
        'txtBlastWheel1Perc
        '
        Me.txtBlastWheel1Perc.Location = New System.Drawing.Point(236, 23)
        Me.txtBlastWheel1Perc.Name = "txtBlastWheel1Perc"
        Me.txtBlastWheel1Perc.ReadOnly = True
        Me.txtBlastWheel1Perc.Size = New System.Drawing.Size(49, 20)
        Me.txtBlastWheel1Perc.TabIndex = 13
        Me.txtBlastWheel1Perc.TabStop = False
        '
        'txtBlastWheel5
        '
        Me.txtBlastWheel5.Location = New System.Drawing.Point(59, 95)
        Me.txtBlastWheel5.Name = "txtBlastWheel5"
        Me.txtBlastWheel5.Size = New System.Drawing.Size(100, 20)
        Me.txtBlastWheel5.TabIndex = 4
        '
        'txtBlastWheel4
        '
        Me.txtBlastWheel4.Location = New System.Drawing.Point(59, 77)
        Me.txtBlastWheel4.Name = "txtBlastWheel4"
        Me.txtBlastWheel4.Size = New System.Drawing.Size(100, 20)
        Me.txtBlastWheel4.TabIndex = 3
        '
        'txtBlastWheel3
        '
        Me.txtBlastWheel3.Location = New System.Drawing.Point(59, 59)
        Me.txtBlastWheel3.Name = "txtBlastWheel3"
        Me.txtBlastWheel3.Size = New System.Drawing.Size(100, 20)
        Me.txtBlastWheel3.TabIndex = 2
        '
        'txtBlastWheel2
        '
        Me.txtBlastWheel2.Location = New System.Drawing.Point(59, 41)
        Me.txtBlastWheel2.Name = "txtBlastWheel2"
        Me.txtBlastWheel2.Size = New System.Drawing.Size(100, 20)
        Me.txtBlastWheel2.TabIndex = 1
        '
        'txtBlastWheel1
        '
        Me.txtBlastWheel1.Location = New System.Drawing.Point(59, 23)
        Me.txtBlastWheel1.Name = "txtBlastWheel1"
        Me.txtBlastWheel1.Size = New System.Drawing.Size(100, 20)
        Me.txtBlastWheel1.TabIndex = 0
        '
        'lblWA5
        '
        Me.lblWA5.AutoSize = True
        Me.lblWA5.Location = New System.Drawing.Point(22, 98)
        Me.lblWA5.Name = "lblWA5"
        Me.lblWA5.Size = New System.Drawing.Size(16, 13)
        Me.lblWA5.TabIndex = 5
        Me.lblWA5.Text = "5:"
        '
        'lblWA4
        '
        Me.lblWA4.AutoSize = True
        Me.lblWA4.Location = New System.Drawing.Point(22, 80)
        Me.lblWA4.Name = "lblWA4"
        Me.lblWA4.Size = New System.Drawing.Size(16, 13)
        Me.lblWA4.TabIndex = 4
        Me.lblWA4.Text = "4:"
        '
        'lblWA3
        '
        Me.lblWA3.AutoSize = True
        Me.lblWA3.Location = New System.Drawing.Point(22, 62)
        Me.lblWA3.Name = "lblWA3"
        Me.lblWA3.Size = New System.Drawing.Size(16, 13)
        Me.lblWA3.TabIndex = 3
        Me.lblWA3.Text = "3:"
        '
        'lblWA2
        '
        Me.lblWA2.AutoSize = True
        Me.lblWA2.Location = New System.Drawing.Point(22, 44)
        Me.lblWA2.Name = "lblWA2"
        Me.lblWA2.Size = New System.Drawing.Size(16, 13)
        Me.lblWA2.TabIndex = 2
        Me.lblWA2.Text = "2:"
        '
        'lblWA1
        '
        Me.lblWA1.AutoSize = True
        Me.lblWA1.Location = New System.Drawing.Point(22, 26)
        Me.lblWA1.Name = "lblWA1"
        Me.lblWA1.Size = New System.Drawing.Size(16, 13)
        Me.lblWA1.TabIndex = 1
        Me.lblWA1.Text = "1:"
        '
        'cmdCalculate
        '
        Me.cmdCalculate.Location = New System.Drawing.Point(187, 696)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.Size = New System.Drawing.Size(72, 39)
        Me.cmdCalculate.TabIndex = 10
        Me.cmdCalculate.Text = "Calculate"
        Me.cmdCalculate.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(46, 696)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(72, 39)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Location = New System.Drawing.Point(187, 774)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(72, 39)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cboShotID
        '
        Me.cboShotID.DisplayMember = "ShotID"
        Me.cboShotID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShotID.FormattingEnabled = True
        Me.cboShotID.Location = New System.Drawing.Point(117, 31)
        Me.cboShotID.Name = "cboShotID"
        Me.cboShotID.Size = New System.Drawing.Size(181, 21)
        Me.cboShotID.TabIndex = 0
        Me.cboShotID.ValueMember = "ShotID"
        '
        'lblShot
        '
        Me.lblShot.AutoSize = True
        Me.lblShot.Location = New System.Drawing.Point(12, 35)
        Me.lblShot.Name = "lblShot"
        Me.lblShot.Size = New System.Drawing.Size(70, 13)
        Me.lblShot.TabIndex = 37
        Me.lblShot.Text = "Shot Test ID:"
        '
        'cmdViewSave
        '
        Me.cmdViewSave.Location = New System.Drawing.Point(46, 618)
        Me.cmdViewSave.Name = "cmdViewSave"
        Me.cmdViewSave.Size = New System.Drawing.Size(72, 39)
        Me.cmdViewSave.TabIndex = 7
        Me.cmdViewSave.Text = "Save And View"
        Me.cmdViewSave.UseVisualStyleBackColor = True
        '
        'lblAbrSize
        '
        Me.lblAbrSize.AutoSize = True
        Me.lblAbrSize.Location = New System.Drawing.Point(12, 59)
        Me.lblAbrSize.Name = "lblAbrSize"
        Me.lblAbrSize.Size = New System.Drawing.Size(74, 13)
        Me.lblAbrSize.TabIndex = 39
        Me.lblAbrSize.Text = "Abrasive Size:"
        '
        'txtAbrSize
        '
        Me.txtAbrSize.Location = New System.Drawing.Point(117, 55)
        Me.txtAbrSize.Name = "txtAbrSize"
        Me.txtAbrSize.Size = New System.Drawing.Size(181, 20)
        Me.txtAbrSize.TabIndex = 1
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(117, 103)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpDate.TabIndex = 3
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(12, 107)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 41
        Me.lblDate.Text = "Date:"
        '
        'ScreenShotAnalysisTableTableAdapter
        '
        Me.ScreenShotAnalysisTableTableAdapter.ClearBeforeFill = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(187, 618)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(72, 39)
        Me.cmdDelete.TabIndex = 8
        Me.cmdDelete.Text = "Delete Shot Record"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 47
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportCSVToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExportCSVToolStripMenuItem
        '
        Me.ExportCSVToolStripMenuItem.Name = "ExportCSVToolStripMenuItem"
        Me.ExportCSVToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExportCSVToolStripMenuItem.Text = "Export Table"
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
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(46, 774)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(72, 39)
        Me.cmdView.TabIndex = 11
        Me.cmdView.Text = "View Report"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'ShotIDDataGridViewTextBoxColumn
        '
        Me.ShotIDDataGridViewTextBoxColumn.DataPropertyName = "ShotID"
        Me.ShotIDDataGridViewTextBoxColumn.HeaderText = "Shot ID"
        Me.ShotIDDataGridViewTextBoxColumn.Name = "ShotIDDataGridViewTextBoxColumn"
        Me.ShotIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AbrasiveSizeDataGridViewTextBoxColumn
        '
        Me.AbrasiveSizeDataGridViewTextBoxColumn.DataPropertyName = "AbrasiveSize"
        Me.AbrasiveSizeDataGridViewTextBoxColumn.HeaderText = "Abrasive Size"
        Me.AbrasiveSizeDataGridViewTextBoxColumn.Name = "AbrasiveSizeDataGridViewTextBoxColumn"
        Me.AbrasiveSizeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateCreatedDataGridViewTextBoxColumn
        '
        Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "Date Created"
        Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
        Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PANNumberDataGridViewTextBoxColumn
        '
        Me.PANNumberDataGridViewTextBoxColumn.DataPropertyName = "PANNumber"
        Me.PANNumberDataGridViewTextBoxColumn.HeaderText = "PAN Number North"
        Me.PANNumberDataGridViewTextBoxColumn.Name = "PANNumberDataGridViewTextBoxColumn"
        Me.PANNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'North104DataGridViewTextBoxColumn
        '
        Me.North104DataGridViewTextBoxColumn.DataPropertyName = "North104"
        Me.North104DataGridViewTextBoxColumn.HeaderText = "North 108"
        Me.North104DataGridViewTextBoxColumn.Name = "North104DataGridViewTextBoxColumn"
        Me.North104DataGridViewTextBoxColumn.ReadOnly = True
        '
        'North100DataGridViewTextBoxColumn
        '
        Me.North100DataGridViewTextBoxColumn.DataPropertyName = "North100"
        Me.North100DataGridViewTextBoxColumn.HeaderText = "North 99"
        Me.North100DataGridViewTextBoxColumn.Name = "North100DataGridViewTextBoxColumn"
        Me.North100DataGridViewTextBoxColumn.ReadOnly = True
        '
        'North96DataGridViewTextBoxColumn
        '
        Me.North96DataGridViewTextBoxColumn.DataPropertyName = "North96"
        Me.North96DataGridViewTextBoxColumn.HeaderText = "North 97"
        Me.North96DataGridViewTextBoxColumn.Name = "North96DataGridViewTextBoxColumn"
        Me.North96DataGridViewTextBoxColumn.ReadOnly = True
        '
        'North95DataGridViewTextBoxColumn
        '
        Me.North95DataGridViewTextBoxColumn.DataPropertyName = "North95"
        Me.North95DataGridViewTextBoxColumn.HeaderText = "North 104"
        Me.North95DataGridViewTextBoxColumn.Name = "North95DataGridViewTextBoxColumn"
        Me.North95DataGridViewTextBoxColumn.ReadOnly = True
        '
        'North94DataGridViewTextBoxColumn
        '
        Me.North94DataGridViewTextBoxColumn.DataPropertyName = "North94"
        Me.North94DataGridViewTextBoxColumn.HeaderText = "North 97"
        Me.North94DataGridViewTextBoxColumn.Name = "North94DataGridViewTextBoxColumn"
        Me.North94DataGridViewTextBoxColumn.ReadOnly = True
        '
        'PANNumberSouth
        '
        Me.PANNumberSouth.DataPropertyName = "PANNumberSouth"
        Me.PANNumberSouth.HeaderText = "PAN Number South"
        Me.PANNumberSouth.Name = "PANNumberSouth"
        Me.PANNumberSouth.ReadOnly = True
        '
        'South104DataGridViewTextBoxColumn
        '
        Me.South104DataGridViewTextBoxColumn.DataPropertyName = "South104"
        Me.South104DataGridViewTextBoxColumn.HeaderText = "South 108"
        Me.South104DataGridViewTextBoxColumn.Name = "South104DataGridViewTextBoxColumn"
        Me.South104DataGridViewTextBoxColumn.ReadOnly = True
        '
        'South100DataGridViewTextBoxColumn
        '
        Me.South100DataGridViewTextBoxColumn.DataPropertyName = "South100"
        Me.South100DataGridViewTextBoxColumn.HeaderText = "South 99"
        Me.South100DataGridViewTextBoxColumn.Name = "South100DataGridViewTextBoxColumn"
        Me.South100DataGridViewTextBoxColumn.ReadOnly = True
        '
        'South96DataGridViewTextBoxColumn
        '
        Me.South96DataGridViewTextBoxColumn.DataPropertyName = "South96"
        Me.South96DataGridViewTextBoxColumn.HeaderText = "South 97"
        Me.South96DataGridViewTextBoxColumn.Name = "South96DataGridViewTextBoxColumn"
        Me.South96DataGridViewTextBoxColumn.ReadOnly = True
        '
        'South95DataGridViewTextBoxColumn
        '
        Me.South95DataGridViewTextBoxColumn.DataPropertyName = "South95"
        Me.South95DataGridViewTextBoxColumn.HeaderText = "South 104"
        Me.South95DataGridViewTextBoxColumn.Name = "South95DataGridViewTextBoxColumn"
        Me.South95DataGridViewTextBoxColumn.ReadOnly = True
        '
        'South94DataGridViewTextBoxColumn
        '
        Me.South94DataGridViewTextBoxColumn.DataPropertyName = "South94"
        Me.South94DataGridViewTextBoxColumn.HeaderText = "South 97"
        Me.South94DataGridViewTextBoxColumn.Name = "South94DataGridViewTextBoxColumn"
        Me.South94DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Wheel1DataGridViewTextBoxColumn
        '
        Me.Wheel1DataGridViewTextBoxColumn.DataPropertyName = "Wheel1"
        Me.Wheel1DataGridViewTextBoxColumn.HeaderText = "Wheel 1"
        Me.Wheel1DataGridViewTextBoxColumn.Name = "Wheel1DataGridViewTextBoxColumn"
        Me.Wheel1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Wheel2DataGridViewTextBoxColumn
        '
        Me.Wheel2DataGridViewTextBoxColumn.DataPropertyName = "Wheel2"
        Me.Wheel2DataGridViewTextBoxColumn.HeaderText = "Wheel 2"
        Me.Wheel2DataGridViewTextBoxColumn.Name = "Wheel2DataGridViewTextBoxColumn"
        Me.Wheel2DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Wheel3DataGridViewTextBoxColumn
        '
        Me.Wheel3DataGridViewTextBoxColumn.DataPropertyName = "Wheel3"
        Me.Wheel3DataGridViewTextBoxColumn.HeaderText = "Wheel 3"
        Me.Wheel3DataGridViewTextBoxColumn.Name = "Wheel3DataGridViewTextBoxColumn"
        Me.Wheel3DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Wheel4DataGridViewTextBoxColumn
        '
        Me.Wheel4DataGridViewTextBoxColumn.DataPropertyName = "Wheel4"
        Me.Wheel4DataGridViewTextBoxColumn.HeaderText = "Wheel 4"
        Me.Wheel4DataGridViewTextBoxColumn.Name = "Wheel4DataGridViewTextBoxColumn"
        Me.Wheel4DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Wheel5DataGridViewTextBoxColumn
        '
        Me.Wheel5DataGridViewTextBoxColumn.DataPropertyName = "Wheel5"
        Me.Wheel5DataGridViewTextBoxColumn.HeaderText = "Wheel 5"
        Me.Wheel5DataGridViewTextBoxColumn.Name = "Wheel5DataGridViewTextBoxColumn"
        Me.Wheel5DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Wheel6DataGridViewTextBoxColumn
        '
        Me.Wheel6DataGridViewTextBoxColumn.DataPropertyName = "Wheel6"
        Me.Wheel6DataGridViewTextBoxColumn.HeaderText = "Wheel 6"
        Me.Wheel6DataGridViewTextBoxColumn.Name = "Wheel6DataGridViewTextBoxColumn"
        Me.Wheel6DataGridViewTextBoxColumn.ReadOnly = True
        '
        'ViewShotTest
        '
        Me.AcceptButton = Me.cmdViewSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtAbrSize)
        Me.Controls.Add(Me.lblAbrSize)
        Me.Controls.Add(Me.cmdViewSave)
        Me.Controls.Add(Me.lblShot)
        Me.Controls.Add(Me.cboShotID)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdCalculate)
        Me.Controls.Add(Me.grpAmps)
        Me.Controls.Add(Me.grpWeightS)
        Me.Controls.Add(Me.grpWeight)
        Me.Controls.Add(Me.dgvShotAnalysis)
        Me.KeyPreview = True
        Me.Name = "ViewShotTest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shot Screening Analysis Report"
        CType(Me.dgvShotAnalysis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenShotAnalysisTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpWeight.ResumeLayout(False)
        Me.grpWeight.PerformLayout()
        Me.grpWeightS.ResumeLayout(False)
        Me.grpWeightS.PerformLayout()
        Me.grpAmps.ResumeLayout(False)
        Me.grpAmps.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvShotAnalysis As System.Windows.Forms.DataGridView
    Friend WithEvents lblOMN104 As System.Windows.Forms.Label
    Friend WithEvents grpWeight As System.Windows.Forms.GroupBox
    Friend WithEvents lblOMN94 As System.Windows.Forms.Label
    Friend WithEvents lblOMN100 As System.Windows.Forms.Label
    Friend WithEvents lblOMN95 As System.Windows.Forms.Label
    Friend WithEvents lblOMN96 As System.Windows.Forms.Label
    Friend WithEvents grpWeightS As System.Windows.Forms.GroupBox
    Friend WithEvents lblOMS94 As System.Windows.Forms.Label
    Friend WithEvents lblOMS100 As System.Windows.Forms.Label
    Friend WithEvents lblOMS95 As System.Windows.Forms.Label
    Friend WithEvents lblOMS96 As System.Windows.Forms.Label
    Friend WithEvents lblOMS104 As System.Windows.Forms.Label
    Friend WithEvents grpAmps As System.Windows.Forms.GroupBox
    Friend WithEvents lblWA5 As System.Windows.Forms.Label
    Friend WithEvents lblWA4 As System.Windows.Forms.Label
    Friend WithEvents lblWA3 As System.Windows.Forms.Label
    Friend WithEvents lblWA2 As System.Windows.Forms.Label
    Friend WithEvents lblWA1 As System.Windows.Forms.Label
    Friend WithEvents txtNorth94 As System.Windows.Forms.TextBox
    Friend WithEvents txtNorth100 As System.Windows.Forms.TextBox
    Friend WithEvents txtNorth95 As System.Windows.Forms.TextBox
    Friend WithEvents txtNorth96 As System.Windows.Forms.TextBox
    Friend WithEvents txtNorth104 As System.Windows.Forms.TextBox
    Friend WithEvents txtSouth94 As System.Windows.Forms.TextBox
    Friend WithEvents txtSouth100 As System.Windows.Forms.TextBox
    Friend WithEvents txtSouth95 As System.Windows.Forms.TextBox
    Friend WithEvents txtSouth96 As System.Windows.Forms.TextBox
    Friend WithEvents txtSouth104 As System.Windows.Forms.TextBox
    Friend WithEvents txtBlastWheel5 As System.Windows.Forms.TextBox
    Friend WithEvents txtBlastWheel4 As System.Windows.Forms.TextBox
    Friend WithEvents txtBlastWheel3 As System.Windows.Forms.TextBox
    Friend WithEvents txtBlastWheel2 As System.Windows.Forms.TextBox
    Friend WithEvents txtBlastWheel1 As System.Windows.Forms.TextBox
    Friend WithEvents lblperc5 As System.Windows.Forms.Label
    Friend WithEvents txtNorth94Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc4 As System.Windows.Forms.Label
    Friend WithEvents txtNorth100Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc3 As System.Windows.Forms.Label
    Friend WithEvents txtNorth95Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblPerc2 As System.Windows.Forms.Label
    Friend WithEvents txtNorth96Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblPerc1 As System.Windows.Forms.Label
    Friend WithEvents txtNorth104Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc10 As System.Windows.Forms.Label
    Friend WithEvents txtSouth94Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblPerc9 As System.Windows.Forms.Label
    Friend WithEvents txtSouth100Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblPerc8 As System.Windows.Forms.Label
    Friend WithEvents txtSouth95Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc7 As System.Windows.Forms.Label
    Friend WithEvents txtSouth96Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc6 As System.Windows.Forms.Label
    Friend WithEvents txtSouth104Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc15 As System.Windows.Forms.Label
    Friend WithEvents txtBlastWheel5Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc14 As System.Windows.Forms.Label
    Friend WithEvents txtBlastWheel4Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc13 As System.Windows.Forms.Label
    Friend WithEvents txtBlastWheel3Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc12 As System.Windows.Forms.Label
    Friend WithEvents txtBlastWheel2Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc11 As System.Windows.Forms.Label
    Friend WithEvents txtBlastWheel1Perc As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalculate As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtBlastWheel6Perc As System.Windows.Forms.TextBox
    Friend WithEvents lblperc16 As System.Windows.Forms.Label
    Friend WithEvents txtBlastWheel6 As System.Windows.Forms.TextBox
    Friend WithEvents lblWA6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSouth As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalSperc As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmps As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalWperc As System.Windows.Forms.Label
    Friend WithEvents txtTotalNorth As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalNperc As System.Windows.Forms.Label
    Friend WithEvents cboShotID As System.Windows.Forms.ComboBox
    Friend WithEvents lblShot As System.Windows.Forms.Label
    Friend WithEvents cmdViewSave As System.Windows.Forms.Button
    Friend WithEvents lblAbrSize As System.Windows.Forms.Label
    Friend WithEvents txtAbrSize As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblPAN As System.Windows.Forms.Label
    Friend WithEvents txtPAN As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ScreenShotAnalysisTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ScreenShotAnalysisTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ScreenShotAnalysisTableTableAdapter
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents txtPANSouth As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShotIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbrasiveSizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCreatedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PANNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents North104DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents North100DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents North96DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents North95DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents North94DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PANNumberSouth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents South104DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents South100DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents South96DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents South95DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents South94DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wheel1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wheel2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wheel3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wheel4DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wheel5DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wheel6DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
