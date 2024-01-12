<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReprintInvoiceBatch
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
        Me.EmailInvoicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CRInvoiceViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXInvoiceTFF1 = New MOS09Program.CRXInvoiceTFF
        Me.CRXInvoice1 = New MOS09Program.CRXInvoice
        Me.dgvInvoiceHeader = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvInvoiceHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailInvoicesToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EmailInvoicesToolStripMenuItem
        '
        Me.EmailInvoicesToolStripMenuItem.Name = "EmailInvoicesToolStripMenuItem"
        Me.EmailInvoicesToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.EmailInvoicesToolStripMenuItem.Text = "Email Invoices"
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
        'CRInvoiceViewer
        '
        Me.CRInvoiceViewer.ActiveViewIndex = -1
        Me.CRInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRInvoiceViewer.DisplayGroupTree = False
        Me.CRInvoiceViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRInvoiceViewer.Location = New System.Drawing.Point(0, 24)
        Me.CRInvoiceViewer.Name = "CRInvoiceViewer"
        Me.CRInvoiceViewer.SelectionFormula = ""
        Me.CRInvoiceViewer.ShowGroupTreeButton = False
        Me.CRInvoiceViewer.ShowTextSearchButton = False
        Me.CRInvoiceViewer.ShowZoomButton = False
        Me.CRInvoiceViewer.Size = New System.Drawing.Size(1030, 608)
        Me.CRInvoiceViewer.TabIndex = 1
        Me.CRInvoiceViewer.ViewTimeSelectionFormula = ""
        '
        'dgvInvoiceHeader
        '
        Me.dgvInvoiceHeader.AllowUserToAddRows = False
        Me.dgvInvoiceHeader.AllowUserToDeleteRows = False
        Me.dgvInvoiceHeader.AutoGenerateColumns = False
        Me.dgvInvoiceHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.SalesOrderNumberColumn, Me.ShipmentNumberColumn, Me.DivisionIDColumn, Me.CustomerIDColumn})
        Me.dgvInvoiceHeader.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.dgvInvoiceHeader.Location = New System.Drawing.Point(376, 47)
        Me.dgvInvoiceHeader.Name = "dgvInvoiceHeader"
        Me.dgvInvoiceHeader.ReadOnly = True
        Me.dgvInvoiceHeader.Size = New System.Drawing.Size(377, 64)
        Me.dgvInvoiceHeader.TabIndex = 2
        Me.dgvInvoiceHeader.Visible = False
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "InvoiceDate"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
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
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReprintInvoiceBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 632)
        Me.Controls.Add(Me.CRInvoiceViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvInvoiceHeader)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ReprintInvoiceBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoice Batch"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvInvoiceHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CRInvoiceViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXInvoice1 As MOS09Program.CRXInvoice
    Friend WithEvents EmailInvoicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvInvoiceHeader As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CRXInvoiceTFF1 As MOS09Program.CRXInvoiceTFF
End Class
