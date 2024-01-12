<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCommissionReport
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CRCommissionViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXCommissionReportbyTerritoryPaymentDate1 = New MOS09Program.CRXCommissionReportbyTerritoryPaymentDate
        Me.CRXCommissionReportbyTerritory1 = New MOS09Program.CRXCommissionReportbyTerritory
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboTerritory = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkInvoiceDate = New System.Windows.Forms.CheckBox
        Me.chkPaymentDate = New System.Windows.Forms.CheckBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
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
        'CRCommissionViewer
        '
        Me.CRCommissionViewer.ActiveViewIndex = 0
        Me.CRCommissionViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRCommissionViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCommissionViewer.DisplayGroupTree = False
        Me.CRCommissionViewer.Location = New System.Drawing.Point(178, 24)
        Me.CRCommissionViewer.Name = "CRCommissionViewer"
        Me.CRCommissionViewer.ReportSource = Me.CRXCommissionReportbyTerritoryPaymentDate1
        Me.CRCommissionViewer.ShowGroupTreeButton = False
        Me.CRCommissionViewer.ShowTextSearchButton = False
        Me.CRCommissionViewer.ShowZoomButton = False
        Me.CRCommissionViewer.Size = New System.Drawing.Size(850, 608)
        Me.CRCommissionViewer.TabIndex = 1
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(96, 208)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(75, 23)
        Me.cmdViewByFilters.TabIndex = 2
        Me.cmdViewByFilters.Text = "Filter"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboTerritory
        '
        Me.cboTerritory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTerritory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTerritory.DataSource = Me.CustomerListBindingSource
        Me.cboTerritory.DisplayMember = "SalesTerritory"
        Me.cboTerritory.FormattingEnabled = True
        Me.cboTerritory.Location = New System.Drawing.Point(11, 95)
        Me.cboTerritory.Name = "cboTerritory"
        Me.cboTerritory.Size = New System.Drawing.Size(160, 21)
        Me.cboTerritory.TabIndex = 3
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Territory"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(97, 254)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 20)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Filter Fields"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkInvoiceDate
        '
        Me.chkInvoiceDate.AutoSize = True
        Me.chkInvoiceDate.Location = New System.Drawing.Point(11, 132)
        Me.chkInvoiceDate.Name = "chkInvoiceDate"
        Me.chkInvoiceDate.Size = New System.Drawing.Size(87, 17)
        Me.chkInvoiceDate.TabIndex = 30
        Me.chkInvoiceDate.Text = "Invoice Date"
        Me.chkInvoiceDate.UseVisualStyleBackColor = True
        '
        'chkPaymentDate
        '
        Me.chkPaymentDate.AutoSize = True
        Me.chkPaymentDate.Location = New System.Drawing.Point(9, 170)
        Me.chkPaymentDate.Name = "chkPaymentDate"
        Me.chkPaymentDate.Size = New System.Drawing.Size(93, 17)
        Me.chkPaymentDate.TabIndex = 31
        Me.chkPaymentDate.Text = "Payment Date"
        Me.chkPaymentDate.UseVisualStyleBackColor = True
        '
        'PrintCommissionReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 632)
        Me.Controls.Add(Me.chkPaymentDate)
        Me.Controls.Add(Me.chkInvoiceDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTerritory)
        Me.Controls.Add(Me.cmdViewByFilters)
        Me.Controls.Add(Me.CRCommissionViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintCommissionReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Commission Report By Territory"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRCommissionViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXCommissionReportbyTerritory1 As MOS09Program.CRXCommissionReportbyTerritory
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cboTerritory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CRXCommissionReportbyTerritoryPaymentDate1 As MOS09Program.CRXCommissionReportbyTerritoryPaymentDate
    Friend WithEvents chkInvoiceDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkPaymentDate As System.Windows.Forms.CheckBox
End Class
