<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintAllInvoiceDocs
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvInvoiceShipments = New System.Windows.Forms.DataGridView
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceShipmentQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.CRCertViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXTruweldNOCERT1 = New MOS09Program.CRXTruweldNOCERT
        Me.CRXInvoiceTFP1 = New MOS09Program.CRXInvoiceTFP
        Me.CRXInvoiceTFFBillOnly1 = New MOS09Program.CRXInvoiceTFFBillOnly
        Me.CRXTWCert011 = New MOS09Program.CRXTWCert01
        Me.CRXInvoice1 = New MOS09Program.CRXInvoice
        Me.CRXInvoiceTFF1 = New MOS09Program.CRXInvoiceTFF
        Me.CRXInvoiceBillOnly1 = New MOS09Program.CRXInvoiceBillOnly
        Me.InvoiceShipmentQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceShipmentQueryTableAdapter
        Me.CRXInvoiceBillOnlyTFP1 = New MOS09Program.CRXInvoiceBillOnlyTFP
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvInvoiceShipments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceShipmentQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(468, 249)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(410, 49)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Printing... Please wait."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvInvoiceShipments
        '
        Me.dgvInvoiceShipments.AllowUserToAddRows = False
        Me.dgvInvoiceShipments.AllowUserToDeleteRows = False
        Me.dgvInvoiceShipments.AutoGenerateColumns = False
        Me.dgvInvoiceShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceShipments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchNumberColumn, Me.CustomerIDColumn, Me.ShipmentNumberColumn, Me.DivisionIDColumn, Me.SalesOrderNumberColumn, Me.InvoiceNumberColumn})
        Me.dgvInvoiceShipments.DataSource = Me.InvoiceShipmentQueryBindingSource
        Me.dgvInvoiceShipments.Location = New System.Drawing.Point(124, 58)
        Me.dgvInvoiceShipments.Name = "dgvInvoiceShipments"
        Me.dgvInvoiceShipments.ReadOnly = True
        Me.dgvInvoiceShipments.Size = New System.Drawing.Size(240, 150)
        Me.dgvInvoiceShipments.TabIndex = 6
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        '
        'InvoiceShipmentQueryBindingSource
        '
        Me.InvoiceShipmentQueryBindingSource.DataMember = "InvoiceShipmentQuery"
        Me.InvoiceShipmentQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CRCertViewer
        '
        Me.CRCertViewer.ActiveViewIndex = 0
        Me.CRCertViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRCertViewer.DisplayGroupTree = False
        Me.CRCertViewer.Location = New System.Drawing.Point(32, 58)
        Me.CRCertViewer.Name = "CRCertViewer"
        Me.CRCertViewer.ReportSource = Me.CRXTruweldNOCERT1
        Me.CRCertViewer.Size = New System.Drawing.Size(423, 123)
        Me.CRCertViewer.TabIndex = 7
        '
        'InvoiceShipmentQueryTableAdapter
        '
        Me.InvoiceShipmentQueryTableAdapter.ClearBeforeFill = True
        '
        'PrintAllInvoiceDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CRCertViewer)
        Me.Controls.Add(Me.dgvInvoiceShipments)
        Me.Name = "PrintAllInvoiceDocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoices and Certs"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvInvoiceShipments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceShipmentQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CRCertViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXTWCert011 As MOS09Program.CRXTWCert01
    Friend WithEvents CRXInvoiceTFFBillOnly1 As MOS09Program.CRXInvoiceTFFBillOnly
    Friend WithEvents CRXInvoice1 As MOS09Program.CRXInvoice
    Friend WithEvents CRXInvoiceTFF1 As MOS09Program.CRXInvoiceTFF
    Friend WithEvents CRXInvoiceBillOnly1 As MOS09Program.CRXInvoiceBillOnly
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceShipments As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InvoiceShipmentQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceShipmentQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceShipmentQueryTableAdapter
    Friend WithEvents CRXInvoiceTFP1 As MOS09Program.CRXInvoiceTFP
    Friend WithEvents CRXInvoiceBillOnlyTFP1 As MOS09Program.CRXInvoiceBillOnlyTFP
    Friend WithEvents CRXTruweldNOCERT1 As MOS09Program.CRXTruweldNOCERT
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
