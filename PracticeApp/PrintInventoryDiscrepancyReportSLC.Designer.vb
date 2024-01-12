<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintInventoryDiscrepancyReportSLC
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
        Me.CRInventoryViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXInv_RackDiscrepancySLC1 = New MOS09Program.CRXInv_RackDiscrepancySLC
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdFilter = New System.Windows.Forms.Button
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.chkCarrBolt = New System.Windows.Forms.CheckBox
        Me.chkCpgNuts = New System.Windows.Forms.CheckBox
        Me.chkEPOXY = New System.Windows.Forms.CheckBox
        Me.chkEXPANCHOR = New System.Windows.Forms.CheckBox
        Me.chkHEXBOLTS = New System.Windows.Forms.CheckBox
        Me.chkHEXNUTS = New System.Windows.Forms.CheckBox
        Me.chkTWFER = New System.Windows.Forms.CheckBox
        Me.chkJAMNUTS = New System.Windows.Forms.CheckBox
        Me.chkLAGBOLTS = New System.Windows.Forms.CheckBox
        Me.chkWeldStud = New System.Windows.Forms.CheckBox
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.chkUnselectAll = New System.Windows.Forms.CheckBox
        Me.chkLOCKNUTS = New System.Windows.Forms.CheckBox
        Me.chkMETRIC = New System.Windows.Forms.CheckBox
        Me.chkSCREWS = New System.Windows.Forms.CheckBox
        Me.chkTCBOLTS = New System.Windows.Forms.CheckBox
        Me.chkSOCKETSCREW = New System.Windows.Forms.CheckBox
        Me.chkWASHER = New System.Windows.Forms.CheckBox
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CRInventoryViewer
        '
        Me.CRInventoryViewer.ActiveViewIndex = 0
        Me.CRInventoryViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRInventoryViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRInventoryViewer.DisplayGroupTree = False
        Me.CRInventoryViewer.Location = New System.Drawing.Point(183, 12)
        Me.CRInventoryViewer.Name = "CRInventoryViewer"
        Me.CRInventoryViewer.ReportSource = Me.CRXInv_RackDiscrepancySLC1
        Me.CRInventoryViewer.ShowGroupTreeButton = False
        Me.CRInventoryViewer.ShowTextSearchButton = False
        Me.CRInventoryViewer.Size = New System.Drawing.Size(850, 608)
        Me.CRInventoryViewer.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 20)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Filter Fields"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(102, 597)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 33
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Item Class"
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdFilter
        '
        Me.cmdFilter.Location = New System.Drawing.Point(102, 558)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(75, 23)
        Me.cmdFilter.TabIndex = 30
        Me.cmdFilter.Text = "Filter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'chkCarrBolt
        '
        Me.chkCarrBolt.AutoSize = True
        Me.chkCarrBolt.Location = New System.Drawing.Point(12, 127)
        Me.chkCarrBolt.Name = "chkCarrBolt"
        Me.chkCarrBolt.Size = New System.Drawing.Size(119, 17)
        Me.chkCarrBolt.TabIndex = 35
        Me.chkCarrBolt.Text = "CARRIAGE BOLTS"
        Me.chkCarrBolt.UseVisualStyleBackColor = True
        '
        'chkCpgNuts
        '
        Me.chkCpgNuts.AutoSize = True
        Me.chkCpgNuts.Location = New System.Drawing.Point(12, 150)
        Me.chkCpgNuts.Name = "chkCpgNuts"
        Me.chkCpgNuts.Size = New System.Drawing.Size(81, 17)
        Me.chkCpgNuts.TabIndex = 36
        Me.chkCpgNuts.Text = "CPG NUTS"
        Me.chkCpgNuts.UseVisualStyleBackColor = True
        '
        'chkEPOXY
        '
        Me.chkEPOXY.AutoSize = True
        Me.chkEPOXY.Location = New System.Drawing.Point(12, 173)
        Me.chkEPOXY.Name = "chkEPOXY"
        Me.chkEPOXY.Size = New System.Drawing.Size(62, 17)
        Me.chkEPOXY.TabIndex = 37
        Me.chkEPOXY.Text = "EPOXY"
        Me.chkEPOXY.UseVisualStyleBackColor = True
        '
        'chkEXPANCHOR
        '
        Me.chkEXPANCHOR.AutoSize = True
        Me.chkEXPANCHOR.Location = New System.Drawing.Point(12, 196)
        Me.chkEXPANCHOR.Name = "chkEXPANCHOR"
        Me.chkEXPANCHOR.Size = New System.Drawing.Size(96, 17)
        Me.chkEXPANCHOR.TabIndex = 38
        Me.chkEXPANCHOR.Text = "EXP ANCHOR"
        Me.chkEXPANCHOR.UseVisualStyleBackColor = True
        '
        'chkHEXBOLTS
        '
        Me.chkHEXBOLTS.AutoSize = True
        Me.chkHEXBOLTS.Location = New System.Drawing.Point(12, 219)
        Me.chkHEXBOLTS.Name = "chkHEXBOLTS"
        Me.chkHEXBOLTS.Size = New System.Drawing.Size(86, 17)
        Me.chkHEXBOLTS.TabIndex = 39
        Me.chkHEXBOLTS.Text = "HEX BOLTS"
        Me.chkHEXBOLTS.UseVisualStyleBackColor = True
        '
        'chkHEXNUTS
        '
        Me.chkHEXNUTS.AutoSize = True
        Me.chkHEXNUTS.Location = New System.Drawing.Point(12, 242)
        Me.chkHEXNUTS.Name = "chkHEXNUTS"
        Me.chkHEXNUTS.Size = New System.Drawing.Size(81, 17)
        Me.chkHEXNUTS.TabIndex = 40
        Me.chkHEXNUTS.Text = "HEX NUTS"
        Me.chkHEXNUTS.UseVisualStyleBackColor = True
        '
        'chkTWFER
        '
        Me.chkTWFER.AutoSize = True
        Me.chkTWFER.Location = New System.Drawing.Point(12, 265)
        Me.chkTWFER.Name = "chkTWFER"
        Me.chkTWFER.Size = New System.Drawing.Size(83, 17)
        Me.chkTWFER.TabIndex = 41
        Me.chkTWFER.Text = "FERRULES"
        Me.chkTWFER.UseVisualStyleBackColor = True
        '
        'chkJAMNUTS
        '
        Me.chkJAMNUTS.AutoSize = True
        Me.chkJAMNUTS.Location = New System.Drawing.Point(12, 288)
        Me.chkJAMNUTS.Name = "chkJAMNUTS"
        Me.chkJAMNUTS.Size = New System.Drawing.Size(80, 17)
        Me.chkJAMNUTS.TabIndex = 42
        Me.chkJAMNUTS.Text = "JAM NUTS"
        Me.chkJAMNUTS.UseVisualStyleBackColor = True
        '
        'chkLAGBOLTS
        '
        Me.chkLAGBOLTS.AutoSize = True
        Me.chkLAGBOLTS.Location = New System.Drawing.Point(12, 311)
        Me.chkLAGBOLTS.Name = "chkLAGBOLTS"
        Me.chkLAGBOLTS.Size = New System.Drawing.Size(85, 17)
        Me.chkLAGBOLTS.TabIndex = 43
        Me.chkLAGBOLTS.Text = "LAG BOLTS"
        Me.chkLAGBOLTS.UseVisualStyleBackColor = True
        '
        'chkWeldStud
        '
        Me.chkWeldStud.AutoSize = True
        Me.chkWeldStud.Location = New System.Drawing.Point(12, 104)
        Me.chkWeldStud.Name = "chkWeldStud"
        Me.chkWeldStud.Size = New System.Drawing.Size(98, 17)
        Me.chkWeldStud.TabIndex = 44
        Me.chkWeldStud.Text = "WELD STUDS"
        Me.chkWeldStud.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(15, 491)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(70, 17)
        Me.chkSelectAll.TabIndex = 45
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'chkUnselectAll
        '
        Me.chkUnselectAll.AutoSize = True
        Me.chkUnselectAll.Location = New System.Drawing.Point(15, 524)
        Me.chkUnselectAll.Name = "chkUnselectAll"
        Me.chkUnselectAll.Size = New System.Drawing.Size(82, 17)
        Me.chkUnselectAll.TabIndex = 46
        Me.chkUnselectAll.Text = "Unselect All"
        Me.chkUnselectAll.UseVisualStyleBackColor = True
        '
        'chkLOCKNUTS
        '
        Me.chkLOCKNUTS.AutoSize = True
        Me.chkLOCKNUTS.Location = New System.Drawing.Point(12, 334)
        Me.chkLOCKNUTS.Name = "chkLOCKNUTS"
        Me.chkLOCKNUTS.Size = New System.Drawing.Size(87, 17)
        Me.chkLOCKNUTS.TabIndex = 47
        Me.chkLOCKNUTS.Text = "LOCK NUTS"
        Me.chkLOCKNUTS.UseVisualStyleBackColor = True
        '
        'chkMETRIC
        '
        Me.chkMETRIC.AutoSize = True
        Me.chkMETRIC.Location = New System.Drawing.Point(12, 357)
        Me.chkMETRIC.Name = "chkMETRIC"
        Me.chkMETRIC.Size = New System.Drawing.Size(67, 17)
        Me.chkMETRIC.TabIndex = 48
        Me.chkMETRIC.Text = "METRIC"
        Me.chkMETRIC.UseVisualStyleBackColor = True
        '
        'chkSCREWS
        '
        Me.chkSCREWS.AutoSize = True
        Me.chkSCREWS.Location = New System.Drawing.Point(12, 380)
        Me.chkSCREWS.Name = "chkSCREWS"
        Me.chkSCREWS.Size = New System.Drawing.Size(73, 17)
        Me.chkSCREWS.TabIndex = 49
        Me.chkSCREWS.Text = "SCREWS"
        Me.chkSCREWS.UseVisualStyleBackColor = True
        '
        'chkTCBOLTS
        '
        Me.chkTCBOLTS.AutoSize = True
        Me.chkTCBOLTS.Location = New System.Drawing.Point(12, 426)
        Me.chkTCBOLTS.Name = "chkTCBOLTS"
        Me.chkTCBOLTS.Size = New System.Drawing.Size(78, 17)
        Me.chkTCBOLTS.TabIndex = 51
        Me.chkTCBOLTS.Text = "TC BOLTS"
        Me.chkTCBOLTS.UseVisualStyleBackColor = True
        '
        'chkSOCKETSCREW
        '
        Me.chkSOCKETSCREW.AutoSize = True
        Me.chkSOCKETSCREW.Location = New System.Drawing.Point(12, 403)
        Me.chkSOCKETSCREW.Name = "chkSOCKETSCREW"
        Me.chkSOCKETSCREW.Size = New System.Drawing.Size(112, 17)
        Me.chkSOCKETSCREW.TabIndex = 50
        Me.chkSOCKETSCREW.Text = "SOCKET SCREW"
        Me.chkSOCKETSCREW.UseVisualStyleBackColor = True
        '
        'chkWASHER
        '
        Me.chkWASHER.AutoSize = True
        Me.chkWASHER.Location = New System.Drawing.Point(12, 449)
        Me.chkWASHER.Name = "chkWASHER"
        Me.chkWASHER.Size = New System.Drawing.Size(81, 17)
        Me.chkWASHER.TabIndex = 52
        Me.chkWASHER.Text = "WASHERS"
        Me.chkWASHER.UseVisualStyleBackColor = True
        '
        'PrintInventoryDiscrepancyReportSLC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.chkWASHER)
        Me.Controls.Add(Me.chkTCBOLTS)
        Me.Controls.Add(Me.chkSOCKETSCREW)
        Me.Controls.Add(Me.chkSCREWS)
        Me.Controls.Add(Me.chkMETRIC)
        Me.Controls.Add(Me.chkLOCKNUTS)
        Me.Controls.Add(Me.chkUnselectAll)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.chkWeldStud)
        Me.Controls.Add(Me.chkLAGBOLTS)
        Me.Controls.Add(Me.chkJAMNUTS)
        Me.Controls.Add(Me.chkTWFER)
        Me.Controls.Add(Me.chkHEXNUTS)
        Me.Controls.Add(Me.chkHEXBOLTS)
        Me.Controls.Add(Me.chkEXPANCHOR)
        Me.Controls.Add(Me.chkEPOXY)
        Me.Controls.Add(Me.chkCpgNuts)
        Me.Controls.Add(Me.chkCarrBolt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdFilter)
        Me.Controls.Add(Me.CRInventoryViewer)
        Me.Name = "PrintInventoryDiscrepancyReportSLC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Report"
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRInventoryViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents chkCarrBolt As System.Windows.Forms.CheckBox
    Friend WithEvents chkCpgNuts As System.Windows.Forms.CheckBox
    Friend WithEvents chkEPOXY As System.Windows.Forms.CheckBox
    Friend WithEvents chkEXPANCHOR As System.Windows.Forms.CheckBox
    Friend WithEvents chkHEXBOLTS As System.Windows.Forms.CheckBox
    Friend WithEvents chkHEXNUTS As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWFER As System.Windows.Forms.CheckBox
    Friend WithEvents chkJAMNUTS As System.Windows.Forms.CheckBox
    Friend WithEvents chkLAGBOLTS As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeldStud As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnselectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkLOCKNUTS As System.Windows.Forms.CheckBox
    Friend WithEvents chkMETRIC As System.Windows.Forms.CheckBox
    Friend WithEvents chkSCREWS As System.Windows.Forms.CheckBox
    Friend WithEvents chkTCBOLTS As System.Windows.Forms.CheckBox
    Friend WithEvents chkSOCKETSCREW As System.Windows.Forms.CheckBox
    Friend WithEvents chkWASHER As System.Windows.Forms.CheckBox
    Friend WithEvents CRXInv_RackDiscrepancySLC1 As MOS09Program.CRXInv_RackDiscrepancySLC
End Class
