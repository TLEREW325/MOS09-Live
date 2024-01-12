<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectCustomerReturnsForCredit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectCustomerReturnsForCredit))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdProcessForCredit = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.cmdUnCheckAll = New System.Windows.Forms.Button
        Me.dgvCustomerReturns = New System.Windows.Forms.DataGridView
        Me.dgvSerialLines = New System.Windows.Forms.DataGridView
        Me.ReturnProductHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.AssemblyPartNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDateColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblySerialTempTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReturnProductHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
        Me.AssemblySerialTempTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialTempTableTableAdapter
        Me.SelectForProcessing = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax2TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax3TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OtherTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReasonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvCustomerReturns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSerialLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdProcessForCredit
        '
        resources.ApplyResources(Me.cmdProcessForCredit, "cmdProcessForCredit")
        Me.cmdProcessForCredit.Name = "cmdProcessForCredit"
        Me.cmdProcessForCredit.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        resources.ApplyResources(Me.cmdExit, "cmdExit")
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdCheckAll
        '
        resources.ApplyResources(Me.cmdCheckAll, "cmdCheckAll")
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdUnCheckAll
        '
        resources.ApplyResources(Me.cmdUnCheckAll, "cmdUnCheckAll")
        Me.cmdUnCheckAll.Name = "cmdUnCheckAll"
        Me.cmdUnCheckAll.UseVisualStyleBackColor = True
        '
        'dgvCustomerReturns
        '
        Me.dgvCustomerReturns.AllowUserToAddRows = False
        Me.dgvCustomerReturns.AllowUserToDeleteRows = False
        resources.ApplyResources(Me.dgvCustomerReturns, "dgvCustomerReturns")
        Me.dgvCustomerReturns.AutoGenerateColumns = False
        Me.dgvCustomerReturns.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCustomerReturns.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCustomerReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerReturns.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForProcessing, Me.ReturnNumberColumn, Me.ReturnDateColumn, Me.CustomerIDColumn, Me.DivisionIDColumn, Me.SalesOrderNumberColumn, Me.SalespersonColumn, Me.CustomerPOColumn, Me.ProductTotalColumn, Me.FreightTotalColumn, Me.SalesTaxTotalColumn, Me.SalesTax2TotalColumn, Me.SalesTax3TotalColumn, Me.OtherTotalColumn, Me.ReturnTotalColumn, Me.ReasonColumn, Me.CustomerClassColumn, Me.FOBColumn, Me.ReturnStatusColumn})
        Me.dgvCustomerReturns.DataSource = Me.ReturnProductHeaderTableBindingSource
        Me.dgvCustomerReturns.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCustomerReturns.Name = "dgvCustomerReturns"
        '
        'dgvSerialLines
        '
        Me.dgvSerialLines.AllowUserToAddRows = False
        Me.dgvSerialLines.AllowUserToDeleteRows = False
        Me.dgvSerialLines.AutoGenerateColumns = False
        Me.dgvSerialLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerialLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn2, Me.SerialNumberColumn2, Me.DivisionIDColumn2, Me.TotalCostColumn2, Me.CommentColumn2, Me.BuildDateColumn2, Me.StatusColumn2, Me.BuildNumberColumn2, Me.CustomerIDColumn2, Me.BatchNumberColumn2, Me.TransactionNumberColumn2})
        Me.dgvSerialLines.DataSource = Me.AssemblySerialTempTableBindingSource
        resources.ApplyResources(Me.dgvSerialLines, "dgvSerialLines")
        Me.dgvSerialLines.Name = "dgvSerialLines"
        Me.dgvSerialLines.ReadOnly = True
        '
        'ReturnProductHeaderTableBindingSource
        '
        Me.ReturnProductHeaderTableBindingSource.DataMember = "ReturnProductHeaderTable"
        Me.ReturnProductHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AssemblyPartNumberColumn2
        '
        Me.AssemblyPartNumberColumn2.DataPropertyName = "AssemblyPartNumber"
        resources.ApplyResources(Me.AssemblyPartNumberColumn2, "AssemblyPartNumberColumn2")
        Me.AssemblyPartNumberColumn2.Name = "AssemblyPartNumberColumn2"
        Me.AssemblyPartNumberColumn2.ReadOnly = True
        '
        'SerialNumberColumn2
        '
        Me.SerialNumberColumn2.DataPropertyName = "SerialNumber"
        resources.ApplyResources(Me.SerialNumberColumn2, "SerialNumberColumn2")
        Me.SerialNumberColumn2.Name = "SerialNumberColumn2"
        Me.SerialNumberColumn2.ReadOnly = True
        '
        'DivisionIDColumn2
        '
        Me.DivisionIDColumn2.DataPropertyName = "DivisionID"
        resources.ApplyResources(Me.DivisionIDColumn2, "DivisionIDColumn2")
        Me.DivisionIDColumn2.Name = "DivisionIDColumn2"
        Me.DivisionIDColumn2.ReadOnly = True
        '
        'TotalCostColumn2
        '
        Me.TotalCostColumn2.DataPropertyName = "TotalCost"
        resources.ApplyResources(Me.TotalCostColumn2, "TotalCostColumn2")
        Me.TotalCostColumn2.Name = "TotalCostColumn2"
        Me.TotalCostColumn2.ReadOnly = True
        '
        'CommentColumn2
        '
        Me.CommentColumn2.DataPropertyName = "Comment"
        resources.ApplyResources(Me.CommentColumn2, "CommentColumn2")
        Me.CommentColumn2.Name = "CommentColumn2"
        Me.CommentColumn2.ReadOnly = True
        '
        'BuildDateColumn2
        '
        Me.BuildDateColumn2.DataPropertyName = "BuildDate"
        resources.ApplyResources(Me.BuildDateColumn2, "BuildDateColumn2")
        Me.BuildDateColumn2.Name = "BuildDateColumn2"
        Me.BuildDateColumn2.ReadOnly = True
        '
        'StatusColumn2
        '
        Me.StatusColumn2.DataPropertyName = "Status"
        resources.ApplyResources(Me.StatusColumn2, "StatusColumn2")
        Me.StatusColumn2.Name = "StatusColumn2"
        Me.StatusColumn2.ReadOnly = True
        '
        'BuildNumberColumn2
        '
        Me.BuildNumberColumn2.DataPropertyName = "BuildNumber"
        resources.ApplyResources(Me.BuildNumberColumn2, "BuildNumberColumn2")
        Me.BuildNumberColumn2.Name = "BuildNumberColumn2"
        Me.BuildNumberColumn2.ReadOnly = True
        '
        'CustomerIDColumn2
        '
        Me.CustomerIDColumn2.DataPropertyName = "CustomerID"
        resources.ApplyResources(Me.CustomerIDColumn2, "CustomerIDColumn2")
        Me.CustomerIDColumn2.Name = "CustomerIDColumn2"
        Me.CustomerIDColumn2.ReadOnly = True
        '
        'BatchNumberColumn2
        '
        Me.BatchNumberColumn2.DataPropertyName = "BatchNumber"
        resources.ApplyResources(Me.BatchNumberColumn2, "BatchNumberColumn2")
        Me.BatchNumberColumn2.Name = "BatchNumberColumn2"
        Me.BatchNumberColumn2.ReadOnly = True
        '
        'TransactionNumberColumn2
        '
        Me.TransactionNumberColumn2.DataPropertyName = "TransactionNumber"
        resources.ApplyResources(Me.TransactionNumberColumn2, "TransactionNumberColumn2")
        Me.TransactionNumberColumn2.Name = "TransactionNumberColumn2"
        Me.TransactionNumberColumn2.ReadOnly = True
        '
        'AssemblySerialTempTableBindingSource
        '
        Me.AssemblySerialTempTableBindingSource.DataMember = "AssemblySerialTempTable"
        Me.AssemblySerialTempTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReturnProductHeaderTableTableAdapter
        '
        Me.ReturnProductHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'AssemblySerialTempTableTableAdapter
        '
        Me.AssemblySerialTempTableTableAdapter.ClearBeforeFill = True
        '
        'SelectForProcessing
        '
        Me.SelectForProcessing.FalseValue = "UNSELECTED"
        resources.ApplyResources(Me.SelectForProcessing, "SelectForProcessing")
        Me.SelectForProcessing.Name = "SelectForProcessing"
        Me.SelectForProcessing.TrueValue = "SELECTED"
        '
        'ReturnNumberColumn
        '
        Me.ReturnNumberColumn.DataPropertyName = "ReturnNumber"
        resources.ApplyResources(Me.ReturnNumberColumn, "ReturnNumberColumn")
        Me.ReturnNumberColumn.Name = "ReturnNumberColumn"
        '
        'ReturnDateColumn
        '
        Me.ReturnDateColumn.DataPropertyName = "ReturnDate"
        resources.ApplyResources(Me.ReturnDateColumn, "ReturnDateColumn")
        Me.ReturnDateColumn.Name = "ReturnDateColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        resources.ApplyResources(Me.CustomerIDColumn, "CustomerIDColumn")
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        resources.ApplyResources(Me.DivisionIDColumn, "DivisionIDColumn")
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        resources.ApplyResources(Me.SalesOrderNumberColumn, "SalesOrderNumberColumn")
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        '
        'SalespersonColumn
        '
        Me.SalespersonColumn.DataPropertyName = "Salesperson"
        resources.ApplyResources(Me.SalespersonColumn, "SalespersonColumn")
        Me.SalespersonColumn.Name = "SalespersonColumn"
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        resources.ApplyResources(Me.CustomerPOColumn, "CustomerPOColumn")
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.ProductTotalColumn, "ProductTotalColumn")
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        '
        'FreightTotalColumn
        '
        Me.FreightTotalColumn.DataPropertyName = "FreightTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.FreightTotalColumn.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.FreightTotalColumn, "FreightTotalColumn")
        Me.FreightTotalColumn.Name = "FreightTotalColumn"
        '
        'SalesTaxTotalColumn
        '
        Me.SalesTaxTotalColumn.DataPropertyName = "SalesTaxTotal"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SalesTaxTotalColumn.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.SalesTaxTotalColumn, "SalesTaxTotalColumn")
        Me.SalesTaxTotalColumn.Name = "SalesTaxTotalColumn"
        '
        'SalesTax2TotalColumn
        '
        Me.SalesTax2TotalColumn.DataPropertyName = "SalesTax2Total"
        resources.ApplyResources(Me.SalesTax2TotalColumn, "SalesTax2TotalColumn")
        Me.SalesTax2TotalColumn.Name = "SalesTax2TotalColumn"
        '
        'SalesTax3TotalColumn
        '
        Me.SalesTax3TotalColumn.DataPropertyName = "SalesTax3Total"
        resources.ApplyResources(Me.SalesTax3TotalColumn, "SalesTax3TotalColumn")
        Me.SalesTax3TotalColumn.Name = "SalesTax3TotalColumn"
        '
        'OtherTotalColumn
        '
        Me.OtherTotalColumn.DataPropertyName = "OtherTotal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.OtherTotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.OtherTotalColumn, "OtherTotalColumn")
        Me.OtherTotalColumn.Name = "OtherTotalColumn"
        '
        'ReturnTotalColumn
        '
        Me.ReturnTotalColumn.DataPropertyName = "ReturnTotal"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ReturnTotalColumn.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.ReturnTotalColumn, "ReturnTotalColumn")
        Me.ReturnTotalColumn.Name = "ReturnTotalColumn"
        '
        'ReasonColumn
        '
        Me.ReasonColumn.DataPropertyName = "Reason"
        resources.ApplyResources(Me.ReasonColumn, "ReasonColumn")
        Me.ReasonColumn.Name = "ReasonColumn"
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        resources.ApplyResources(Me.CustomerClassColumn, "CustomerClassColumn")
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        resources.ApplyResources(Me.FOBColumn, "FOBColumn")
        Me.FOBColumn.Name = "FOBColumn"
        '
        'ReturnStatusColumn
        '
        Me.ReturnStatusColumn.DataPropertyName = "ReturnStatus"
        resources.ApplyResources(Me.ReturnStatusColumn, "ReturnStatusColumn")
        Me.ReturnStatusColumn.Name = "ReturnStatusColumn"
        '
        'SelectCustomerReturnsForCredit
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvCustomerReturns)
        Me.Controls.Add(Me.cmdProcessForCredit)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdCheckAll)
        Me.Controls.Add(Me.cmdUnCheckAll)
        Me.Controls.Add(Me.dgvSerialLines)
        Me.Name = "SelectCustomerReturnsForCredit"
        CType(Me.dgvCustomerReturns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSerialLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialTempTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdProcessForCredit As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdUnCheckAll As System.Windows.Forms.Button
    Friend WithEvents dgvCustomerReturns As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReturnProductHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
    Friend WithEvents dgvSerialLines As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblySerialTempTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialTempTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialTempTableTableAdapter
    Friend WithEvents AssemblyPartNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDateColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForProcessing As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax2TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax3TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
