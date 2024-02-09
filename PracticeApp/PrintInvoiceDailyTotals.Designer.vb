<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintInvoiceDailyTotals
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
        Me.CRDailyViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRXInvoiceDailyTotals1 = New MOS09Program.CRXInvoiceDailyTotals()
        Me.rbSRLOnly = New System.Windows.Forms.RadioButton()
        Me.rbNotSRL = New System.Windows.Forms.RadioButton()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.rbHarrisRebar = New System.Windows.Forms.RadioButton()
        Me.rbNotHarris = New System.Windows.Forms.RadioButton()
        Me.CRXInvoiceDailyTotalsCanadian1 = New MOS09Program.CRXInvoiceDailyTotalsCanadian()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboItemClass = New System.Windows.Forms.ComboBox()
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter()
        Me.chkExclude = New System.Windows.Forms.CheckBox()
        Me.rdoAllCustomers = New System.Windows.Forms.RadioButton()
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1030, 24)
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
        'CRDailyViewer
        '
        Me.CRDailyViewer.ActiveViewIndex = 0
        Me.CRDailyViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRDailyViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRDailyViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRDailyViewer.Location = New System.Drawing.Point(183, 24)
        Me.CRDailyViewer.Name = "CRDailyViewer"
        Me.CRDailyViewer.ReportSource = Me.CRXInvoiceDailyTotals1
        Me.CRDailyViewer.ShowGroupTreeButton = False
        Me.CRDailyViewer.ShowLogo = False
        Me.CRDailyViewer.ShowParameterPanelButton = False
        Me.CRDailyViewer.ShowTextSearchButton = False
        Me.CRDailyViewer.ShowZoomButton = False
        Me.CRDailyViewer.Size = New System.Drawing.Size(847, 608)
        Me.CRDailyViewer.TabIndex = 1
        Me.CRDailyViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'rbSRLOnly
        '
        Me.rbSRLOnly.AutoSize = True
        Me.rbSRLOnly.Location = New System.Drawing.Point(12, 146)
        Me.rbSRLOnly.Name = "rbSRLOnly"
        Me.rbSRLOnly.Size = New System.Drawing.Size(70, 17)
        Me.rbSRLOnly.TabIndex = 3
        Me.rbSRLOnly.TabStop = True
        Me.rbSRLOnly.Text = "SRL Only"
        Me.rbSRLOnly.UseVisualStyleBackColor = True
        '
        'rbNotSRL
        '
        Me.rbNotSRL.AutoSize = True
        Me.rbNotSRL.Location = New System.Drawing.Point(12, 179)
        Me.rbNotSRL.Name = "rbNotSRL"
        Me.rbNotSRL.Size = New System.Drawing.Size(66, 17)
        Me.rbNotSRL.TabIndex = 4
        Me.rbNotSRL.TabStop = True
        Me.rbNotSRL.Text = "Not SRL"
        Me.rbNotSRL.UseVisualStyleBackColor = True
        '
        'cmdFilter
        '
        Me.cmdFilter.Location = New System.Drawing.Point(9, 511)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(75, 23)
        Me.cmdFilter.TabIndex = 11
        Me.cmdFilter.Text = "Filter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(90, 511)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'rbHarrisRebar
        '
        Me.rbHarrisRebar.AutoSize = True
        Me.rbHarrisRebar.Location = New System.Drawing.Point(12, 113)
        Me.rbHarrisRebar.Name = "rbHarrisRebar"
        Me.rbHarrisRebar.Size = New System.Drawing.Size(84, 17)
        Me.rbHarrisRebar.TabIndex = 2
        Me.rbHarrisRebar.TabStop = True
        Me.rbHarrisRebar.Text = "Harris Rebar"
        Me.rbHarrisRebar.UseVisualStyleBackColor = True
        '
        'rbNotHarris
        '
        Me.rbNotHarris.AutoSize = True
        Me.rbNotHarris.Location = New System.Drawing.Point(12, 212)
        Me.rbNotHarris.Name = "rbNotHarris"
        Me.rbNotHarris.Size = New System.Drawing.Size(72, 17)
        Me.rbNotHarris.TabIndex = 5
        Me.rbNotHarris.TabStop = True
        Me.rbNotHarris.Text = "Not Harris"
        Me.rbNotHarris.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Filter Fields"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(12, 279)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(156, 21)
        Me.cboItemClass.TabIndex = 7
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Item Class"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'chkExclude
        '
        Me.chkExclude.AutoSize = True
        Me.chkExclude.Location = New System.Drawing.Point(12, 316)
        Me.chkExclude.Name = "chkExclude"
        Me.chkExclude.Size = New System.Drawing.Size(115, 17)
        Me.chkExclude.TabIndex = 8
        Me.chkExclude.Text = "Exclude Item Class"
        Me.chkExclude.UseVisualStyleBackColor = True
        '
        'rdoAllCustomers
        '
        Me.rdoAllCustomers.AutoSize = True
        Me.rdoAllCustomers.Checked = True
        Me.rdoAllCustomers.Location = New System.Drawing.Point(12, 80)
        Me.rdoAllCustomers.Name = "rdoAllCustomers"
        Me.rdoAllCustomers.Size = New System.Drawing.Size(88, 17)
        Me.rdoAllCustomers.TabIndex = 1
        Me.rdoAllCustomers.TabStop = True
        Me.rdoAllCustomers.Text = "All Customers"
        Me.rdoAllCustomers.UseVisualStyleBackColor = True
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(12, 398)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(152, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(12, 451)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 375)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 428)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 20)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PrintInvoiceDailyTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpBeginDate)
        Me.Controls.Add(Me.rdoAllCustomers)
        Me.Controls.Add(Me.chkExclude)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboItemClass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rbNotHarris)
        Me.Controls.Add(Me.rbHarrisRebar)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdFilter)
        Me.Controls.Add(Me.rbNotSRL)
        Me.Controls.Add(Me.rbSRLOnly)
        Me.Controls.Add(Me.CRDailyViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintInvoiceDailyTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Daily Sales Totals"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CRDailyViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXInvoiceDailyTotalsCanadian1 As MOS09Program.CRXInvoiceDailyTotalsCanadian
    Friend WithEvents CRXInvoiceDailyTotals1 As MOS09Program.CRXInvoiceDailyTotals
    Friend WithEvents rbSRLOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotSRL As System.Windows.Forms.RadioButton
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents rbHarrisRebar As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotHarris As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents chkExclude As System.Windows.Forms.CheckBox
    Friend WithEvents rdoAllCustomers As System.Windows.Forms.RadioButton
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
