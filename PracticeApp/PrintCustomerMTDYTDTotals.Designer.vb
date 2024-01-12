<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCustomerMTDYTDTotals
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
        Me.CRCustomerYTDViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXCustMTD_YTDInvoicesbyState1 = New MOS09Program.CRXCustMTD_YTDInvoicesbyState
        Me.CRXCustMTD_YTDInvoicesTerritory1 = New MOS09Program.CRXCustMTD_YTDInvoicesTerritory
        Me.CRXCustMTD_YTDInvoices1 = New MOS09Program.CRXCustMTD_YTDInvoices
        Me.cboCustomer = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.chkGroupByZip = New System.Windows.Forms.CheckBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSalesTerritory = New System.Windows.Forms.ComboBox
        Me.CRXCustMTD_YTDInvoicesZip1 = New MOS09Program.CRXCustMTD_YTDInvoicesZip
        Me.chkSalesTerritory = New System.Windows.Forms.CheckBox
        Me.CRXCustMTD_YTDInvoicesbyTerritory1 = New MOS09Program.CRXCustMTD_YTDInvoicesbyTerritory
        Me.chkState = New System.Windows.Forms.CheckBox
        Me.chkTerritory = New System.Windows.Forms.CheckBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'CRCustomerYTDViewer
        '
        Me.CRCustomerYTDViewer.ActiveViewIndex = 0
        Me.CRCustomerYTDViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRCustomerYTDViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCustomerYTDViewer.DisplayGroupTree = False
        Me.CRCustomerYTDViewer.Location = New System.Drawing.Point(183, 24)
        Me.CRCustomerYTDViewer.Name = "CRCustomerYTDViewer"
        Me.CRCustomerYTDViewer.ReportSource = Me.CRXCustMTD_YTDInvoicesbyState1
        Me.CRCustomerYTDViewer.ShowGroupTreeButton = False
        Me.CRCustomerYTDViewer.ShowTextSearchButton = False
        Me.CRCustomerYTDViewer.ShowZoomButton = False
        Me.CRCustomerYTDViewer.Size = New System.Drawing.Size(847, 608)
        Me.CRCustomerYTDViewer.TabIndex = 1
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomer.DataSource = Me.CustomerListBindingSource
        Me.cboCustomer.DisplayMember = "CustomerID"
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(14, 95)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(156, 21)
        Me.cboCustomer.TabIndex = 2
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
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(14, 384)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(75, 23)
        Me.cmdViewByFilters.TabIndex = 3
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(95, 384)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Customer"
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
        Me.Label2.Location = New System.Drawing.Point(11, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 20)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Filter Fields"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Customer Name"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(14, 141)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(156, 21)
        Me.cboCustomerName.TabIndex = 31
        '
        'chkGroupByZip
        '
        Me.chkGroupByZip.AutoSize = True
        Me.chkGroupByZip.Location = New System.Drawing.Point(17, 313)
        Me.chkGroupByZip.Name = "chkGroupByZip"
        Me.chkGroupByZip.Size = New System.Drawing.Size(116, 17)
        Me.chkGroupByZip.TabIndex = 38
        Me.chkGroupByZip.Text = "Group By Zip Code"
        Me.chkGroupByZip.UseVisualStyleBackColor = True
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Sales Territory"
        '
        'cboSalesTerritory
        '
        Me.cboSalesTerritory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesTerritory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesTerritory.DataSource = Me.CustomerListBindingSource
        Me.cboSalesTerritory.DisplayMember = "SalesTerritory"
        Me.cboSalesTerritory.FormattingEnabled = True
        Me.cboSalesTerritory.Location = New System.Drawing.Point(14, 202)
        Me.cboSalesTerritory.Name = "cboSalesTerritory"
        Me.cboSalesTerritory.Size = New System.Drawing.Size(156, 21)
        Me.cboSalesTerritory.TabIndex = 41
        '
        'chkSalesTerritory
        '
        Me.chkSalesTerritory.AutoSize = True
        Me.chkSalesTerritory.Location = New System.Drawing.Point(17, 349)
        Me.chkSalesTerritory.Name = "chkSalesTerritory"
        Me.chkSalesTerritory.Size = New System.Drawing.Size(140, 17)
        Me.chkSalesTerritory.TabIndex = 43
        Me.chkSalesTerritory.Text = "Group By Sales Territory"
        Me.chkSalesTerritory.UseVisualStyleBackColor = True
        '
        'chkState
        '
        Me.chkState.AutoSize = True
        Me.chkState.Location = New System.Drawing.Point(17, 277)
        Me.chkState.Name = "chkState"
        Me.chkState.Size = New System.Drawing.Size(87, 17)
        Me.chkState.TabIndex = 44
        Me.chkState.Text = "Sort by State"
        Me.chkState.UseVisualStyleBackColor = True
        '
        'chkTerritory
        '
        Me.chkTerritory.AutoSize = True
        Me.chkTerritory.Location = New System.Drawing.Point(17, 241)
        Me.chkTerritory.Name = "chkTerritory"
        Me.chkTerritory.Size = New System.Drawing.Size(100, 17)
        Me.chkTerritory.TabIndex = 45
        Me.chkTerritory.Text = "Sort by Territory"
        Me.chkTerritory.UseVisualStyleBackColor = True
        '
        'PrintCustomerMTDYTDTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.chkTerritory)
        Me.Controls.Add(Me.chkState)
        Me.Controls.Add(Me.chkSalesTerritory)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboSalesTerritory)
        Me.Controls.Add(Me.chkGroupByZip)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCustomerName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdViewByFilters)
        Me.Controls.Add(Me.cboCustomer)
        Me.Controls.Add(Me.CRCustomerYTDViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintCustomerMTDYTDTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation MTD / YTD Totals"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRCustomerYTDViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXCustMTD_YTDInvoices1 As MOS09Program.CRXCustMTD_YTDInvoices
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents chkGroupByZip As System.Windows.Forms.CheckBox
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSalesTerritory As System.Windows.Forms.ComboBox
    Friend WithEvents CRXCustMTD_YTDInvoicesZip1 As MOS09Program.CRXCustMTD_YTDInvoicesZip
    Friend WithEvents CRXCustMTD_YTDInvoicesTerritory1 As MOS09Program.CRXCustMTD_YTDInvoicesTerritory
    Friend WithEvents chkSalesTerritory As System.Windows.Forms.CheckBox
    Friend WithEvents CRXCustMTD_YTDInvoicesbyState1 As MOS09Program.CRXCustMTD_YTDInvoicesbyState
    Friend WithEvents CRXCustMTD_YTDInvoicesbyTerritory1 As MOS09Program.CRXCustMTD_YTDInvoicesbyTerritory
    Friend WithEvents chkState As System.Windows.Forms.CheckBox
    Friend WithEvents chkTerritory As System.Windows.Forms.CheckBox
End Class
