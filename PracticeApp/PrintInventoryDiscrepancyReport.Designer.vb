<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintInventoryDiscrepancyReport
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
        Me.CRInventoryViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXInv_RackDiscrepancy1 = New MOS09Program.CRXInv_RackDiscrepancy()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter()
        Me.chkTWSC = New System.Windows.Forms.CheckBox()
        Me.chkTWDS = New System.Windows.Forms.CheckBox()
        Me.chkTWDB = New System.Windows.Forms.CheckBox()
        Me.chkTWTT = New System.Windows.Forms.CheckBox()
        Me.chkTWTP = New System.Windows.Forms.CheckBox()
        Me.chkTWPS = New System.Windows.Forms.CheckBox()
        Me.chkTWFER = New System.Windows.Forms.CheckBox()
        Me.chkTWCS = New System.Windows.Forms.CheckBox()
        Me.chkTWTR = New System.Windows.Forms.CheckBox()
        Me.chkTWCA = New System.Windows.Forms.CheckBox()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.chkUnselectAll = New System.Windows.Forms.CheckBox()
        Me.chkTWNT = New System.Windows.Forms.CheckBox()
        Me.chkTWKO = New System.Windows.Forms.CheckBox()
        Me.chkTWCD = New System.Windows.Forms.CheckBox()
        Me.chkTWSH = New System.Windows.Forms.CheckBox()
        Me.chkTWIT = New System.Windows.Forms.CheckBox()
        Me.chkTrufit = New System.Windows.Forms.CheckBox()
        Me.chkTWRA = New System.Windows.Forms.CheckBox()
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
        Me.CRInventoryViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRInventoryViewer.Location = New System.Drawing.Point(183, 12)
        Me.CRInventoryViewer.Name = "CRInventoryViewer"
        Me.CRInventoryViewer.ReportSource = Me.CRXInv_RackDiscrepancy1
        Me.CRInventoryViewer.ShowGroupTreeButton = False
        Me.CRInventoryViewer.ShowLogo = False
        Me.CRInventoryViewer.ShowParameterPanelButton = False
        Me.CRInventoryViewer.ShowTextSearchButton = False
        Me.CRInventoryViewer.ShowZoomButton = False
        Me.CRInventoryViewer.Size = New System.Drawing.Size(850, 608)
        Me.CRInventoryViewer.TabIndex = 0
        Me.CRInventoryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
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
        Me.Label1.Location = New System.Drawing.Point(12, 52)
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
        'chkTWSC
        '
        Me.chkTWSC.AutoSize = True
        Me.chkTWSC.Location = New System.Drawing.Point(12, 101)
        Me.chkTWSC.Name = "chkTWSC"
        Me.chkTWSC.Size = New System.Drawing.Size(134, 17)
        Me.chkTWSC.TabIndex = 35
        Me.chkTWSC.Text = "SHEAR CONNECTOR"
        Me.chkTWSC.UseVisualStyleBackColor = True
        '
        'chkTWDS
        '
        Me.chkTWDS.AutoSize = True
        Me.chkTWDS.Location = New System.Drawing.Point(12, 124)
        Me.chkTWDS.Name = "chkTWDS"
        Me.chkTWDS.Size = New System.Drawing.Size(89, 17)
        Me.chkTWDS.TabIndex = 36
        Me.chkTWDS.Text = "THRU-DECK"
        Me.chkTWDS.UseVisualStyleBackColor = True
        '
        'chkTWDB
        '
        Me.chkTWDB.AutoSize = True
        Me.chkTWDB.Location = New System.Drawing.Point(12, 147)
        Me.chkTWDB.Name = "chkTWDB"
        Me.chkTWDB.Size = New System.Drawing.Size(63, 17)
        Me.chkTWDB.TabIndex = 37
        Me.chkTWDB.Text = "DEBAR"
        Me.chkTWDB.UseVisualStyleBackColor = True
        '
        'chkTWTT
        '
        Me.chkTWTT.AutoSize = True
        Me.chkTWTT.Location = New System.Drawing.Point(12, 170)
        Me.chkTWTT.Name = "chkTWTT"
        Me.chkTWTT.Size = New System.Drawing.Size(100, 17)
        Me.chkTWTT.TabIndex = 38
        Me.chkTWTT.Text = "FULL THREAD"
        Me.chkTWTT.UseVisualStyleBackColor = True
        '
        'chkTWTP
        '
        Me.chkTWTP.AutoSize = True
        Me.chkTWTP.Location = New System.Drawing.Point(12, 193)
        Me.chkTWTP.Name = "chkTWTP"
        Me.chkTWTP.Size = New System.Drawing.Size(119, 17)
        Me.chkTWTP.TabIndex = 39
        Me.chkTWTP.Text = "PARTIAL THREAD"
        Me.chkTWTP.UseVisualStyleBackColor = True
        '
        'chkTWPS
        '
        Me.chkTWPS.AutoSize = True
        Me.chkTWPS.Location = New System.Drawing.Point(12, 216)
        Me.chkTWPS.Name = "chkTWPS"
        Me.chkTWPS.Size = New System.Drawing.Size(88, 17)
        Me.chkTWPS.TabIndex = 40
        Me.chkTWPS.Text = "PSR STUDS"
        Me.chkTWPS.UseVisualStyleBackColor = True
        '
        'chkTWFER
        '
        Me.chkTWFER.AutoSize = True
        Me.chkTWFER.Location = New System.Drawing.Point(12, 239)
        Me.chkTWFER.Name = "chkTWFER"
        Me.chkTWFER.Size = New System.Drawing.Size(83, 17)
        Me.chkTWFER.TabIndex = 41
        Me.chkTWFER.Text = "FERRULES"
        Me.chkTWFER.UseVisualStyleBackColor = True
        '
        'chkTWCS
        '
        Me.chkTWCS.AutoSize = True
        Me.chkTWCS.Location = New System.Drawing.Point(12, 262)
        Me.chkTWCS.Name = "chkTWCS"
        Me.chkTWCS.Size = New System.Drawing.Size(108, 17)
        Me.chkTWCS.TabIndex = 42
        Me.chkTWCS.Text = "COLLAR STUDS"
        Me.chkTWCS.UseVisualStyleBackColor = True
        '
        'chkTWTR
        '
        Me.chkTWTR.AutoSize = True
        Me.chkTWTR.Location = New System.Drawing.Point(12, 285)
        Me.chkTWTR.Name = "chkTWTR"
        Me.chkTWTR.Size = New System.Drawing.Size(155, 17)
        Me.chkTWTR.TabIndex = 43
        Me.chkTWTR.Text = "REDUCED BASE (TW TR)"
        Me.chkTWTR.UseVisualStyleBackColor = True
        '
        'chkTWCA
        '
        Me.chkTWCA.AutoSize = True
        Me.chkTWCA.Location = New System.Drawing.Point(12, 78)
        Me.chkTWCA.Name = "chkTWCA"
        Me.chkTWCA.Size = New System.Drawing.Size(134, 17)
        Me.chkTWCA.TabIndex = 44
        Me.chkTWCA.Text = "CONCRETE ANCHOR"
        Me.chkTWCA.UseVisualStyleBackColor = True
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
        'chkTWNT
        '
        Me.chkTWNT.AutoSize = True
        Me.chkTWNT.Location = New System.Drawing.Point(12, 308)
        Me.chkTWNT.Name = "chkTWNT"
        Me.chkTWNT.Size = New System.Drawing.Size(81, 17)
        Me.chkTWNT.TabIndex = 47
        Me.chkTWNT.Text = "NT STUDS"
        Me.chkTWNT.UseVisualStyleBackColor = True
        '
        'chkTWKO
        '
        Me.chkTWKO.AutoSize = True
        Me.chkTWKO.Location = New System.Drawing.Point(12, 331)
        Me.chkTWKO.Name = "chkTWKO"
        Me.chkTWKO.Size = New System.Drawing.Size(126, 17)
        Me.chkTWKO.TabIndex = 48
        Me.chkTWKO.Text = "KNOCK-OFF STUDS"
        Me.chkTWKO.UseVisualStyleBackColor = True
        '
        'chkTWCD
        '
        Me.chkTWCD.AutoSize = True
        Me.chkTWCD.Location = New System.Drawing.Point(12, 354)
        Me.chkTWCD.Name = "chkTWCD"
        Me.chkTWCD.Size = New System.Drawing.Size(81, 17)
        Me.chkTWCD.TabIndex = 49
        Me.chkTWCD.Text = "CD STUDS"
        Me.chkTWCD.UseVisualStyleBackColor = True
        '
        'chkTWSH
        '
        Me.chkTWSH.AutoSize = True
        Me.chkTWSH.Location = New System.Drawing.Point(12, 400)
        Me.chkTWSH.Name = "chkTWSH"
        Me.chkTWSH.Size = New System.Drawing.Size(81, 17)
        Me.chkTWSH.TabIndex = 51
        Me.chkTWSH.Text = "SH STUDS"
        Me.chkTWSH.UseVisualStyleBackColor = True
        '
        'chkTWIT
        '
        Me.chkTWIT.AutoSize = True
        Me.chkTWIT.Location = New System.Drawing.Point(12, 377)
        Me.chkTWIT.Name = "chkTWIT"
        Me.chkTWIT.Size = New System.Drawing.Size(76, 17)
        Me.chkTWIT.TabIndex = 50
        Me.chkTWIT.Text = "IT STUDS"
        Me.chkTWIT.UseVisualStyleBackColor = True
        '
        'chkTrufit
        '
        Me.chkTrufit.AutoSize = True
        Me.chkTrufit.Location = New System.Drawing.Point(12, 446)
        Me.chkTrufit.Name = "chkTrufit"
        Me.chkTrufit.Size = New System.Drawing.Size(65, 17)
        Me.chkTrufit.TabIndex = 52
        Me.chkTrufit.Text = "TRUFIT"
        Me.chkTrufit.UseVisualStyleBackColor = True
        '
        'chkTWRA
        '
        Me.chkTWRA.AutoSize = True
        Me.chkTWRA.Location = New System.Drawing.Point(12, 423)
        Me.chkTWRA.Name = "chkTWRA"
        Me.chkTWRA.Size = New System.Drawing.Size(106, 17)
        Me.chkTWRA.TabIndex = 53
        Me.chkTWRA.Text = "RA STUDS (RD)"
        Me.chkTWRA.UseVisualStyleBackColor = True
        '
        'PrintInventoryDiscrepancyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.chkTWRA)
        Me.Controls.Add(Me.chkTrufit)
        Me.Controls.Add(Me.chkTWSH)
        Me.Controls.Add(Me.chkTWIT)
        Me.Controls.Add(Me.chkTWCD)
        Me.Controls.Add(Me.chkTWKO)
        Me.Controls.Add(Me.chkTWNT)
        Me.Controls.Add(Me.chkUnselectAll)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.chkTWCA)
        Me.Controls.Add(Me.chkTWTR)
        Me.Controls.Add(Me.chkTWCS)
        Me.Controls.Add(Me.chkTWFER)
        Me.Controls.Add(Me.chkTWPS)
        Me.Controls.Add(Me.chkTWTP)
        Me.Controls.Add(Me.chkTWTT)
        Me.Controls.Add(Me.chkTWDB)
        Me.Controls.Add(Me.chkTWDS)
        Me.Controls.Add(Me.chkTWSC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdFilter)
        Me.Controls.Add(Me.CRInventoryViewer)
        Me.Name = "PrintInventoryDiscrepancyReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Report"
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRInventoryViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXInv_RackDiscrepancy1 As MOS09Program.CRXInv_RackDiscrepancy
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents chkTWSC As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWDS As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWDB As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWTT As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWTP As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWPS As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWFER As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWCS As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWTR As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWCA As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnselectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWNT As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWKO As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWCD As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWSH As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWIT As System.Windows.Forms.CheckBox
    Friend WithEvents chkTrufit As System.Windows.Forms.CheckBox
    Friend WithEvents chkTWRA As System.Windows.Forms.CheckBox
End Class
