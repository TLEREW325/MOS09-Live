<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintMachineCostCenterReport
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CRXCostCenterFile1 = New MOS09Program.CRXCostCenterFile()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMachineClass = New System.Windows.Forms.ComboBox()
        Me.MachineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMachine = New System.Windows.Forms.ComboBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.CRCostViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TimeSlipCombinedDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipCombinedDataTableAdapter()
        Me.TimeSlipCombinedDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MachineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeSlipCombinedDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Machine Class"
        '
        'cboMachineClass
        '
        Me.cboMachineClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMachineClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachineClass.DataSource = Me.MachineTableBindingSource
        Me.cboMachineClass.DisplayMember = "MachineClass"
        Me.cboMachineClass.FormattingEnabled = True
        Me.cboMachineClass.Location = New System.Drawing.Point(5, 149)
        Me.cboMachineClass.Name = "cboMachineClass"
        Me.cboMachineClass.Size = New System.Drawing.Size(167, 21)
        Me.cboMachineClass.TabIndex = 13
        '
        'MachineTableBindingSource
        '
        Me.MachineTableBindingSource.DataMember = "MachineTable"
        Me.MachineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Machine"
        '
        'cboMachine
        '
        Me.cboMachine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMachine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachine.DataSource = Me.MachineTableBindingSource
        Me.cboMachine.DisplayMember = "MachineID"
        Me.cboMachine.FormattingEnabled = True
        Me.cboMachine.Location = New System.Drawing.Point(5, 90)
        Me.cboMachine.Name = "cboMachine"
        Me.cboMachine.Size = New System.Drawing.Size(167, 21)
        Me.cboMachine.TabIndex = 11
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(98, 189)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdFilter
        '
        Me.cmdFilter.Location = New System.Drawing.Point(6, 189)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(75, 23)
        Me.cmdFilter.TabIndex = 9
        Me.cmdFilter.Text = "Filter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'CRCostViewer
        '
        Me.CRCostViewer.ActiveViewIndex = -1
        Me.CRCostViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRCostViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCostViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRCostViewer.Location = New System.Drawing.Point(183, 27)
        Me.CRCostViewer.Name = "CRCostViewer"
        Me.CRCostViewer.ShowGroupTreeButton = False
        Me.CRCostViewer.ShowLogo = False
        Me.CRCostViewer.ShowParameterPanelButton = False
        Me.CRCostViewer.ShowTextSearchButton = False
        Me.CRCostViewer.ShowZoomButton = False
        Me.CRCostViewer.Size = New System.Drawing.Size(845, 608)
        Me.CRCostViewer.TabIndex = 8
        Me.CRCostViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TimeSlipCombinedDataTableAdapter
        '
        Me.TimeSlipCombinedDataTableAdapter.ClearBeforeFill = True
        '
        'TimeSlipCombinedDataBindingSource
        '
        Me.TimeSlipCombinedDataBindingSource.DataMember = "TimeSlipCombinedData"
        Me.TimeSlipCombinedDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'MachineTableTableAdapter
        '
        Me.MachineTableTableAdapter.ClearBeforeFill = True
        '
        'PrintMachineCostCenterReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 632)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboMachineClass)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMachine)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdFilter)
        Me.Controls.Add(Me.CRCostViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintMachineCostCenterReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Cost Center Report"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeSlipCombinedDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRXCostCenterFile1 As MOS09Program.CRXCostCenterFile
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMachineClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMachine As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents CRCostViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents MachineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents TimeSlipCombinedDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipCombinedDataTableAdapter
    Friend WithEvents TimeSlipCombinedDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MachineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter
End Class
