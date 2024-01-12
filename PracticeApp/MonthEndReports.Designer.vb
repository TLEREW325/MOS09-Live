<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthEndReports
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
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cmdPrintReports = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CRConsignmentViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXConsignmentBillingMonth1 = New MOS09Program.CRXConsignmentBillingMonth
        Me.CRDailySales = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXInvoiceDailyTotalsMonth1 = New MOS09Program.CRXInvoiceDailyTotalsMonth
        Me.CRSalesbyItem = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXSalesByItemClass_TWDMonth1 = New MOS09Program.CRXSalesByItemClass_TWDMonth
        Me.lblPrinting = New System.Windows.Forms.Label
        Me.CRSalesbyState = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXCustMTD_YTDInvoicesbyStateMonth1 = New MOS09Program.CRXCustMTD_YTDInvoicesbyStateMonth
        Me.CRSalesbyTerritory = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXMonthEndCustomerReport1 = New MOS09Program.CRXMonthEndCustomerReport
        Me.CRXCustMTD_YTDInvoicesbyTerritoryMonth1 = New MOS09Program.CRXCustMTD_YTDInvoicesbyTerritoryMonth
        Me.dgvCustomerList = New System.Windows.Forms.DataGridView
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(409, 221)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(160, 114)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(174, 21)
        Me.cboMonth.TabIndex = 1
        '
        'lblMonth
        '
        Me.lblMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonth.Location = New System.Drawing.Point(99, 113)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(55, 23)
        Me.lblMonth.TabIndex = 2
        Me.lblMonth.Text = "Month"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintReports
        '
        Me.cmdPrintReports.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReports.Location = New System.Drawing.Point(355, 106)
        Me.cmdPrintReports.Name = "cmdPrintReports"
        Me.cmdPrintReports.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintReports.TabIndex = 3
        Me.cmdPrintReports.Text = "Print Reports"
        Me.cmdPrintReports.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(99, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Year"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboYear
        '
        Me.cboYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025"})
        Me.cboYear.Location = New System.Drawing.Point(160, 141)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(174, 21)
        Me.cboYear.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(99, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Division"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(160, 87)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(174, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CRConsignmentViewer
        '
        Me.CRConsignmentViewer.ActiveViewIndex = 0
        Me.CRConsignmentViewer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRConsignmentViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRConsignmentViewer.Location = New System.Drawing.Point(12, 69)
        Me.CRConsignmentViewer.Name = "CRConsignmentViewer"
        Me.CRConsignmentViewer.ReportSource = Me.CRXConsignmentBillingMonth1
        Me.CRConsignmentViewer.Size = New System.Drawing.Size(40, 40)
        Me.CRConsignmentViewer.TabIndex = 8
        Me.CRConsignmentViewer.TabStop = False
        Me.CRConsignmentViewer.Visible = False
        '
        'CRDailySales
        '
        Me.CRDailySales.ActiveViewIndex = 0
        Me.CRDailySales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRDailySales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRDailySales.Location = New System.Drawing.Point(12, 115)
        Me.CRDailySales.Name = "CRDailySales"
        Me.CRDailySales.ReportSource = Me.CRXInvoiceDailyTotalsMonth1
        Me.CRDailySales.Size = New System.Drawing.Size(40, 40)
        Me.CRDailySales.TabIndex = 9
        Me.CRDailySales.TabStop = False
        Me.CRDailySales.Visible = False
        '
        'CRSalesbyItem
        '
        Me.CRSalesbyItem.ActiveViewIndex = 0
        Me.CRSalesbyItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRSalesbyItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRSalesbyItem.Location = New System.Drawing.Point(12, 161)
        Me.CRSalesbyItem.Name = "CRSalesbyItem"
        Me.CRSalesbyItem.ReportSource = Me.CRXSalesByItemClass_TWDMonth1
        Me.CRSalesbyItem.Size = New System.Drawing.Size(81, 40)
        Me.CRSalesbyItem.TabIndex = 10
        Me.CRSalesbyItem.TabStop = False
        Me.CRSalesbyItem.Visible = False
        '
        'lblPrinting
        '
        Me.lblPrinting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrinting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrinting.ForeColor = System.Drawing.Color.Blue
        Me.lblPrinting.Location = New System.Drawing.Point(114, 196)
        Me.lblPrinting.Name = "lblPrinting"
        Me.lblPrinting.Size = New System.Drawing.Size(275, 34)
        Me.lblPrinting.TabIndex = 11
        '
        'CRSalesbyState
        '
        Me.CRSalesbyState.ActiveViewIndex = 0
        Me.CRSalesbyState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRSalesbyState.Location = New System.Drawing.Point(12, 208)
        Me.CRSalesbyState.Name = "CRSalesbyState"
        Me.CRSalesbyState.ReportSource = Me.CRXCustMTD_YTDInvoicesbyStateMonth1
        Me.CRSalesbyState.Size = New System.Drawing.Size(59, 53)
        Me.CRSalesbyState.TabIndex = 12
        Me.CRSalesbyState.Visible = False
        '
        'CRSalesbyTerritory
        '
        Me.CRSalesbyTerritory.ActiveViewIndex = 0
        Me.CRSalesbyTerritory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRSalesbyTerritory.Location = New System.Drawing.Point(78, 208)
        Me.CRSalesbyTerritory.Name = "CRSalesbyTerritory"
        Me.CRSalesbyTerritory.ReportSource = Me.CRXMonthEndCustomerReport1
        Me.CRSalesbyTerritory.Size = New System.Drawing.Size(76, 53)
        Me.CRSalesbyTerritory.TabIndex = 13
        Me.CRSalesbyTerritory.Visible = False
        '
        'dgvCustomerList
        '
        Me.dgvCustomerList.AllowUserToAddRows = False
        Me.dgvCustomerList.AllowUserToDeleteRows = False
        Me.dgvCustomerList.AutoGenerateColumns = False
        Me.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.CustomerNameColumn, Me.DivisionIDColumn, Me.CustomerClassColumn})
        Me.dgvCustomerList.DataSource = Me.CustomerListBindingSource
        Me.dgvCustomerList.Location = New System.Drawing.Point(160, 208)
        Me.dgvCustomerList.Name = "dgvCustomerList"
        Me.dgvCustomerList.Size = New System.Drawing.Size(49, 53)
        Me.dgvCustomerList.TabIndex = 14
        Me.dgvCustomerList.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'CustomerNameColumn
        '
        Me.CustomerNameColumn.DataPropertyName = "CustomerName"
        Me.CustomerNameColumn.HeaderText = "CustomerName"
        Me.CustomerNameColumn.Name = "CustomerNameColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "CustomerClass"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'MonthEndReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.dgvCustomerList)
        Me.Controls.Add(Me.CRSalesbyTerritory)
        Me.Controls.Add(Me.CRSalesbyState)
        Me.Controls.Add(Me.lblPrinting)
        Me.Controls.Add(Me.CRSalesbyItem)
        Me.Controls.Add(Me.CRDailySales)
        Me.Controls.Add(Me.CRConsignmentViewer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.cmdPrintReports)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "MonthEndReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Month End Sales Reports"
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cmdPrintReports As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CRConsignmentViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXConsignmentBillingMonth1 As MOS09Program.CRXConsignmentBillingMonth
    Friend WithEvents CRDailySales As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXInvoiceDailyTotalsMonth1 As MOS09Program.CRXInvoiceDailyTotalsMonth
    Friend WithEvents CRSalesbyItem As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXSalesByItemClass_TWDMonth1 As MOS09Program.CRXSalesByItemClass_TWDMonth
    Friend WithEvents lblPrinting As System.Windows.Forms.Label
    Friend WithEvents CRSalesbyState As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXCustMTD_YTDInvoicesbyStateMonth1 As MOS09Program.CRXCustMTD_YTDInvoicesbyStateMonth
    Friend WithEvents CRSalesbyTerritory As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXCustMTD_YTDInvoicesbyTerritoryMonth1 As MOS09Program.CRXCustMTD_YTDInvoicesbyTerritoryMonth
    Friend WithEvents dgvCustomerList As System.Windows.Forms.DataGridView
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents CRXMonthEndCustomerReport1 As MOS09Program.CRXMonthEndCustomerReport
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
