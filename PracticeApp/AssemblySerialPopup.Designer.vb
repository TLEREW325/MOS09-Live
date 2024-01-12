<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssemblySerialPopup
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBuildQuantity = New System.Windows.Forms.TextBox
        Me.dgvTempSerialLog = New System.Windows.Forms.DataGridView
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.AssemblySerialLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.AssemblySerialLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
        Me.cmdCreateAssemblies = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAssemblyPartNumber = New System.Windows.Forms.TextBox
        Me.lblInvoiceLabel = New System.Windows.Forms.Label
        Me.lblSerialNumber = New System.Windows.Forms.Label
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.chkAddNew = New System.Windows.Forms.CheckBox
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.lblTextSearch = New System.Windows.Forms.Label
        CType(Me.dgvTempSerialLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Quantity"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuildQuantity
        '
        Me.txtBuildQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuildQuantity.Location = New System.Drawing.Point(78, 12)
        Me.txtBuildQuantity.Name = "txtBuildQuantity"
        Me.txtBuildQuantity.Size = New System.Drawing.Size(113, 20)
        Me.txtBuildQuantity.TabIndex = 26
        '
        'dgvTempSerialLog
        '
        Me.dgvTempSerialLog.AllowUserToAddRows = False
        Me.dgvTempSerialLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTempSerialLog.AutoGenerateColumns = False
        Me.dgvTempSerialLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTempSerialLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTempSerialLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTempSerialLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTempSerialLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerialNumberColumn, Me.StatusColumn, Me.BuildDateColumn, Me.TotalCostColumn, Me.BuildNumberColumn, Me.CustomerIDColumn, Me.AssemblyPartNumberColumn, Me.DivisionIDColumn, Me.CommentColumn, Me.BatchNumberColumn, Me.TransactionNumberColumn, Me.ShipmentNumberColumn, Me.ShipmentDateColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.SelectColumn})
        Me.dgvTempSerialLog.DataSource = Me.AssemblySerialLogBindingSource
        Me.dgvTempSerialLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvTempSerialLog.Location = New System.Drawing.Point(7, 81)
        Me.dgvTempSerialLog.Name = "dgvTempSerialLog"
        Me.dgvTempSerialLog.Size = New System.Drawing.Size(573, 465)
        Me.dgvTempSerialLog.TabIndex = 30
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial Number"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        Me.SerialNumberColumn.ReadOnly = True
        Me.SerialNumberColumn.Width = 280
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Width = 150
        '
        'BuildDateColumn
        '
        Me.BuildDateColumn.DataPropertyName = "BuildDate"
        Me.BuildDateColumn.HeaderText = "Build Date"
        Me.BuildDateColumn.Name = "BuildDateColumn"
        Me.BuildDateColumn.Visible = False
        '
        'TotalCostColumn
        '
        Me.TotalCostColumn.DataPropertyName = "TotalCost"
        Me.TotalCostColumn.HeaderText = "TotalCost"
        Me.TotalCostColumn.Name = "TotalCostColumn"
        Me.TotalCostColumn.Visible = False
        '
        'BuildNumberColumn
        '
        Me.BuildNumberColumn.DataPropertyName = "BuildNumber"
        Me.BuildNumberColumn.HeaderText = "Build #"
        Me.BuildNumberColumn.Name = "BuildNumberColumn"
        Me.BuildNumberColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.Visible = False
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Visible = False
        Me.CommentColumn.Width = 150
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.Visible = False
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.Visible = False
        '
        'ShipmentDateColumn
        '
        Me.ShipmentDateColumn.DataPropertyName = "ShipmentDate"
        Me.ShipmentDateColumn.HeaderText = "ShipmentDate"
        Me.ShipmentDateColumn.Name = "ShipmentDateColumn"
        Me.ShipmentDateColumn.Visible = False
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.Visible = False
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "InvoiceDate"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Visible = False
        '
        'SelectColumn
        '
        Me.SelectColumn.FalseValue = "UNSELECTED"
        Me.SelectColumn.HeaderText = "Select?"
        Me.SelectColumn.Name = "SelectColumn"
        Me.SelectColumn.TrueValue = "SELECTED"
        '
        'AssemblySerialLogBindingSource
        '
        Me.AssemblySerialLogBindingSource.DataMember = "AssemblySerialLog"
        Me.AssemblySerialLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AssemblySerialLogTableAdapter
        '
        Me.AssemblySerialLogTableAdapter.ClearBeforeFill = True
        '
        'cmdCreateAssemblies
        '
        Me.cmdCreateAssemblies.Location = New System.Drawing.Point(432, 552)
        Me.cmdCreateAssemblies.Name = "cmdCreateAssemblies"
        Me.cmdCreateAssemblies.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateAssemblies.TabIndex = 31
        Me.cmdCreateAssemblies.Text = "ADD"
        Me.cmdCreateAssemblies.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(509, 552)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 33
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(239, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Part Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAssemblyPartNumber
        '
        Me.txtAssemblyPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssemblyPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAssemblyPartNumber.Location = New System.Drawing.Point(338, 12)
        Me.txtAssemblyPartNumber.Name = "txtAssemblyPartNumber"
        Me.txtAssemblyPartNumber.Size = New System.Drawing.Size(242, 20)
        Me.txtAssemblyPartNumber.TabIndex = 34
        '
        'lblInvoiceLabel
        '
        Me.lblInvoiceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceLabel.ForeColor = System.Drawing.Color.Blue
        Me.lblInvoiceLabel.Location = New System.Drawing.Point(27, 549)
        Me.lblInvoiceLabel.Name = "lblInvoiceLabel"
        Me.lblInvoiceLabel.Size = New System.Drawing.Size(378, 40)
        Me.lblInvoiceLabel.TabIndex = 36
        Me.lblInvoiceLabel.Text = "Select Serial Numbers in datagrid. Number selected must match the invoice quantit" & _
            "y."
        Me.lblInvoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.Location = New System.Drawing.Point(239, 46)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(93, 20)
        Me.lblSerialNumber.TabIndex = 38
        Me.lblSerialNumber.Text = "Add New Serial #"
        Me.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialNumber.Enabled = False
        Me.txtSerialNumber.Location = New System.Drawing.Point(337, 46)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(242, 20)
        Me.txtSerialNumber.TabIndex = 37
        '
        'chkAddNew
        '
        Me.chkAddNew.AutoSize = True
        Me.chkAddNew.Location = New System.Drawing.Point(218, 50)
        Me.chkAddNew.Name = "chkAddNew"
        Me.chkAddNew.Size = New System.Drawing.Size(15, 14)
        Me.chkAddNew.TabIndex = 39
        Me.chkAddNew.UseVisualStyleBackColor = True
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.Location = New System.Drawing.Point(78, 46)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(113, 20)
        Me.txtTextSearch.TabIndex = 40
        '
        'lblTextSearch
        '
        Me.lblTextSearch.Location = New System.Drawing.Point(9, 46)
        Me.lblTextSearch.Name = "lblTextSearch"
        Me.lblTextSearch.Size = New System.Drawing.Size(97, 20)
        Me.lblTextSearch.TabIndex = 41
        Me.lblTextSearch.Text = "Text Search"
        Me.lblTextSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AssemblySerialPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 602)
        Me.Controls.Add(Me.txtTextSearch)
        Me.Controls.Add(Me.lblTextSearch)
        Me.Controls.Add(Me.chkAddNew)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.lblInvoiceLabel)
        Me.Controls.Add(Me.txtBuildQuantity)
        Me.Controls.Add(Me.txtAssemblyPartNumber)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdCreateAssemblies)
        Me.Controls.Add(Me.dgvTempSerialLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AssemblySerialPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Assembly Serial Numbers"
        CType(Me.dgvTempSerialLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuildQuantity As System.Windows.Forms.TextBox
    Friend WithEvents dgvTempSerialLog As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents AssemblySerialLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
    Friend WithEvents cmdCreateAssemblies As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAssemblyPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceLabel As System.Windows.Forms.Label
    Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents chkAddNew As System.Windows.Forms.CheckBox
    Friend WithEvents SelectColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblTextSearch As System.Windows.Forms.Label
End Class
