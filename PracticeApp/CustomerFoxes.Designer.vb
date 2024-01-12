<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerFoxes
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
        Me.dgvFoxTable = New System.Windows.Forms.DataGridView
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlueprintNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlueprintRevisionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuotePriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderReferenceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PromiseDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuoteNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RawMaterialWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FinishedWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScrapWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FluxLoadNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LockedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdFoxForm = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvFoxTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
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
        'dgvFoxTable
        '
        Me.dgvFoxTable.AllowUserToAddRows = False
        Me.dgvFoxTable.AllowUserToDeleteRows = False
        Me.dgvFoxTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFoxTable.AutoGenerateColumns = False
        Me.dgvFoxTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFoxTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFoxTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFoxTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberColumn, Me.RMIDDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.BlueprintNumberDataGridViewTextBoxColumn, Me.BlueprintRevisionDataGridViewTextBoxColumn, Me.ProductionQuantityDataGridViewTextBoxColumn, Me.QuotePriceDataGridViewTextBoxColumn, Me.OrderReferenceNumberDataGridViewTextBoxColumn, Me.PromiseDateDataGridViewTextBoxColumn, Me.QuoteNumberDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.RawMaterialWeightDataGridViewTextBoxColumn, Me.FinishedWeightDataGridViewTextBoxColumn, Me.ScrapWeightDataGridViewTextBoxColumn, Me.FluxLoadNumberDataGridViewTextBoxColumn, Me.CreationDateDataGridViewTextBoxColumn, Me.CommentsDataGridViewTextBoxColumn, Me.CertificationTypeDataGridViewTextBoxColumn, Me.BoxTypeDataGridViewTextBoxColumn, Me.CustomerIDDataGridViewTextBoxColumn, Me.LockedDataGridViewTextBoxColumn})
        Me.dgvFoxTable.DataSource = Me.FOXTableBindingSource
        Me.dgvFoxTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvFoxTable.Location = New System.Drawing.Point(12, 41)
        Me.dgvFoxTable.Name = "dgvFoxTable"
        Me.dgvFoxTable.ReadOnly = True
        Me.dgvFoxTable.Size = New System.Drawing.Size(768, 472)
        Me.dgvFoxTable.TabIndex = 1
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        '
        'RMIDDataGridViewTextBoxColumn
        '
        Me.RMIDDataGridViewTextBoxColumn.DataPropertyName = "RMID"
        Me.RMIDDataGridViewTextBoxColumn.HeaderText = "RMID"
        Me.RMIDDataGridViewTextBoxColumn.Name = "RMIDDataGridViewTextBoxColumn"
        Me.RMIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'BlueprintNumberDataGridViewTextBoxColumn
        '
        Me.BlueprintNumberDataGridViewTextBoxColumn.DataPropertyName = "BlueprintNumber"
        Me.BlueprintNumberDataGridViewTextBoxColumn.HeaderText = "B/P #"
        Me.BlueprintNumberDataGridViewTextBoxColumn.Name = "BlueprintNumberDataGridViewTextBoxColumn"
        Me.BlueprintNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'BlueprintRevisionDataGridViewTextBoxColumn
        '
        Me.BlueprintRevisionDataGridViewTextBoxColumn.DataPropertyName = "BlueprintRevision"
        Me.BlueprintRevisionDataGridViewTextBoxColumn.HeaderText = "Rev. #"
        Me.BlueprintRevisionDataGridViewTextBoxColumn.Name = "BlueprintRevisionDataGridViewTextBoxColumn"
        Me.BlueprintRevisionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProductionQuantityDataGridViewTextBoxColumn
        '
        Me.ProductionQuantityDataGridViewTextBoxColumn.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.ProductionQuantityDataGridViewTextBoxColumn.Name = "ProductionQuantityDataGridViewTextBoxColumn"
        Me.ProductionQuantityDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuotePriceDataGridViewTextBoxColumn
        '
        Me.QuotePriceDataGridViewTextBoxColumn.DataPropertyName = "QuotePrice"
        Me.QuotePriceDataGridViewTextBoxColumn.HeaderText = "Price"
        Me.QuotePriceDataGridViewTextBoxColumn.Name = "QuotePriceDataGridViewTextBoxColumn"
        Me.QuotePriceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrderReferenceNumberDataGridViewTextBoxColumn
        '
        Me.OrderReferenceNumberDataGridViewTextBoxColumn.DataPropertyName = "OrderReferenceNumber"
        Me.OrderReferenceNumberDataGridViewTextBoxColumn.HeaderText = "SO #"
        Me.OrderReferenceNumberDataGridViewTextBoxColumn.Name = "OrderReferenceNumberDataGridViewTextBoxColumn"
        Me.OrderReferenceNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PromiseDateDataGridViewTextBoxColumn
        '
        Me.PromiseDateDataGridViewTextBoxColumn.DataPropertyName = "PromiseDate"
        Me.PromiseDateDataGridViewTextBoxColumn.HeaderText = "Promise Date"
        Me.PromiseDateDataGridViewTextBoxColumn.Name = "PromiseDateDataGridViewTextBoxColumn"
        Me.PromiseDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuoteNumberDataGridViewTextBoxColumn
        '
        Me.QuoteNumberDataGridViewTextBoxColumn.DataPropertyName = "QuoteNumber"
        Me.QuoteNumberDataGridViewTextBoxColumn.HeaderText = "Quote #"
        Me.QuoteNumberDataGridViewTextBoxColumn.Name = "QuoteNumberDataGridViewTextBoxColumn"
        Me.QuoteNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'RawMaterialWeightDataGridViewTextBoxColumn
        '
        Me.RawMaterialWeightDataGridViewTextBoxColumn.DataPropertyName = "RawMaterialWeight"
        Me.RawMaterialWeightDataGridViewTextBoxColumn.HeaderText = "RawMaterialWeight"
        Me.RawMaterialWeightDataGridViewTextBoxColumn.Name = "RawMaterialWeightDataGridViewTextBoxColumn"
        Me.RawMaterialWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.RawMaterialWeightDataGridViewTextBoxColumn.Visible = False
        '
        'FinishedWeightDataGridViewTextBoxColumn
        '
        Me.FinishedWeightDataGridViewTextBoxColumn.DataPropertyName = "FinishedWeight"
        Me.FinishedWeightDataGridViewTextBoxColumn.HeaderText = "FinishedWeight"
        Me.FinishedWeightDataGridViewTextBoxColumn.Name = "FinishedWeightDataGridViewTextBoxColumn"
        Me.FinishedWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.FinishedWeightDataGridViewTextBoxColumn.Visible = False
        '
        'ScrapWeightDataGridViewTextBoxColumn
        '
        Me.ScrapWeightDataGridViewTextBoxColumn.DataPropertyName = "ScrapWeight"
        Me.ScrapWeightDataGridViewTextBoxColumn.HeaderText = "ScrapWeight"
        Me.ScrapWeightDataGridViewTextBoxColumn.Name = "ScrapWeightDataGridViewTextBoxColumn"
        Me.ScrapWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.ScrapWeightDataGridViewTextBoxColumn.Visible = False
        '
        'FluxLoadNumberDataGridViewTextBoxColumn
        '
        Me.FluxLoadNumberDataGridViewTextBoxColumn.DataPropertyName = "FluxLoadNumber"
        Me.FluxLoadNumberDataGridViewTextBoxColumn.HeaderText = "FluxLoadNumber"
        Me.FluxLoadNumberDataGridViewTextBoxColumn.Name = "FluxLoadNumberDataGridViewTextBoxColumn"
        Me.FluxLoadNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.FluxLoadNumberDataGridViewTextBoxColumn.Visible = False
        '
        'CreationDateDataGridViewTextBoxColumn
        '
        Me.CreationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate"
        Me.CreationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate"
        Me.CreationDateDataGridViewTextBoxColumn.Name = "CreationDateDataGridViewTextBoxColumn"
        Me.CreationDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreationDateDataGridViewTextBoxColumn.Visible = False
        '
        'CommentsDataGridViewTextBoxColumn
        '
        Me.CommentsDataGridViewTextBoxColumn.DataPropertyName = "Comments"
        Me.CommentsDataGridViewTextBoxColumn.HeaderText = "Comments"
        Me.CommentsDataGridViewTextBoxColumn.Name = "CommentsDataGridViewTextBoxColumn"
        Me.CommentsDataGridViewTextBoxColumn.ReadOnly = True
        Me.CommentsDataGridViewTextBoxColumn.Visible = False
        '
        'CertificationTypeDataGridViewTextBoxColumn
        '
        Me.CertificationTypeDataGridViewTextBoxColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeDataGridViewTextBoxColumn.HeaderText = "CertificationType"
        Me.CertificationTypeDataGridViewTextBoxColumn.Name = "CertificationTypeDataGridViewTextBoxColumn"
        Me.CertificationTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.CertificationTypeDataGridViewTextBoxColumn.Visible = False
        '
        'BoxTypeDataGridViewTextBoxColumn
        '
        Me.BoxTypeDataGridViewTextBoxColumn.DataPropertyName = "BoxType"
        Me.BoxTypeDataGridViewTextBoxColumn.HeaderText = "BoxType"
        Me.BoxTypeDataGridViewTextBoxColumn.Name = "BoxTypeDataGridViewTextBoxColumn"
        Me.BoxTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.BoxTypeDataGridViewTextBoxColumn.Visible = False
        '
        'CustomerIDDataGridViewTextBoxColumn
        '
        Me.CustomerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.Name = "CustomerIDDataGridViewTextBoxColumn"
        Me.CustomerIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerIDDataGridViewTextBoxColumn.Visible = False
        '
        'LockedDataGridViewTextBoxColumn
        '
        Me.LockedDataGridViewTextBoxColumn.DataPropertyName = "Locked"
        Me.LockedDataGridViewTextBoxColumn.HeaderText = "Locked"
        Me.LockedDataGridViewTextBoxColumn.Name = "LockedDataGridViewTextBoxColumn"
        Me.LockedDataGridViewTextBoxColumn.ReadOnly = True
        Me.LockedDataGridViewTextBoxColumn.Visible = False
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdFoxForm
        '
        Me.cmdFoxForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFoxForm.Location = New System.Drawing.Point(555, 521)
        Me.cmdFoxForm.Name = "cmdFoxForm"
        Me.cmdFoxForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdFoxForm.TabIndex = 25
        Me.cmdFoxForm.Text = "FOX Form"
        Me.cmdFoxForm.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(632, 521)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 23
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(709, 521)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 24
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerFoxes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.cmdFoxForm)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvFoxTable)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CustomerFoxes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Customer FOXES"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvFoxTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvFoxTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents cmdFoxForm As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlueprintNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlueprintRevisionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuotePriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderReferenceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PromiseDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuoteNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RawMaterialWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishedWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScrapWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FluxLoadNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LockedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
