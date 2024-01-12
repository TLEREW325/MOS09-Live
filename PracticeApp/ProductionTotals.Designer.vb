<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionTotals
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvProductionTotals = New System.Windows.Forms.DataGridView
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.cmdViewTotals = New System.Windows.Forms.Button
        Me.cboMachineClass = New System.Windows.Forms.ComboBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.lblBannerLabel = New System.Windows.Forms.Label
        Me.MachineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalMachineHoursBolumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalInventoryPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSteelUsedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSteelCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalMachineHoursLYColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalInventoryPiecesLYColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalProductionQuantityLYColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSteelUsedLYColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSteelCostLYColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvProductionTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        'dgvProductionTotals
        '
        Me.dgvProductionTotals.AllowUserToAddRows = False
        Me.dgvProductionTotals.AllowUserToDeleteRows = False
        Me.dgvProductionTotals.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvProductionTotals.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionTotals.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvProductionTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductionTotals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MachineNumberColumn, Me.TotalMachineHoursBolumn, Me.TotalInventoryPiecesColumn, Me.TotalProductionQuantityColumn, Me.TotalSteelUsedColumn, Me.TotalSteelCostColumn, Me.TotalMachineHoursLYColumn, Me.TotalInventoryPiecesLYColumn, Me.TotalProductionQuantityLYColumn, Me.TotalSteelUsedLYColumn, Me.TotalSteelCostLYColumn})
        Me.dgvProductionTotals.GridColor = System.Drawing.Color.Blue
        Me.dgvProductionTotals.Location = New System.Drawing.Point(12, 105)
        Me.dgvProductionTotals.Name = "dgvProductionTotals"
        Me.dgvProductionTotals.Size = New System.Drawing.Size(1018, 644)
        Me.dgvProductionTotals.TabIndex = 1
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(12, 41)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(186, 21)
        Me.cboMonth.TabIndex = 2
        '
        'cmdViewTotals
        '
        Me.cmdViewTotals.Location = New System.Drawing.Point(224, 55)
        Me.cmdViewTotals.Name = "cmdViewTotals"
        Me.cmdViewTotals.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewTotals.TabIndex = 3
        Me.cmdViewTotals.Text = "View"
        Me.cmdViewTotals.UseVisualStyleBackColor = True
        '
        'cboMachineClass
        '
        Me.cboMachineClass.FormattingEnabled = True
        Me.cboMachineClass.Items.AddRange(New Object() {"Header", "Roller", "Lathe", "Mill", "Drill", "Grind", "Harden & Draw", "All Others"})
        Me.cboMachineClass.Location = New System.Drawing.Point(12, 75)
        Me.cboMachineClass.Name = "cboMachineClass"
        Me.cboMachineClass.Size = New System.Drawing.Size(186, 21)
        Me.cboMachineClass.TabIndex = 4
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 6
        Me.cmdPrint.Text = "Print Report"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(301, 55)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 7
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'lblBannerLabel
        '
        Me.lblBannerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBannerLabel.ForeColor = System.Drawing.Color.Navy
        Me.lblBannerLabel.Location = New System.Drawing.Point(497, 41)
        Me.lblBannerLabel.Name = "lblBannerLabel"
        Me.lblBannerLabel.Size = New System.Drawing.Size(325, 44)
        Me.lblBannerLabel.TabIndex = 8
        Me.lblBannerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MachineNumberColumn
        '
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineNumberColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.MachineNumberColumn.HeaderText = "Machine #"
        Me.MachineNumberColumn.Name = "MachineNumberColumn"
        '
        'TotalMachineHoursBolumn
        '
        DataGridViewCellStyle15.Format = "N1"
        DataGridViewCellStyle15.NullValue = "0"
        Me.TotalMachineHoursBolumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.TotalMachineHoursBolumn.HeaderText = "Total Machine Hours"
        Me.TotalMachineHoursBolumn.Name = "TotalMachineHoursBolumn"
        '
        'TotalInventoryPiecesColumn
        '
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.NullValue = "0"
        Me.TotalInventoryPiecesColumn.DefaultCellStyle = DataGridViewCellStyle16
        Me.TotalInventoryPiecesColumn.HeaderText = "Total Inventory Pieces"
        Me.TotalInventoryPiecesColumn.Name = "TotalInventoryPiecesColumn"
        '
        'TotalProductionQuantityColumn
        '
        DataGridViewCellStyle17.Format = "N0"
        DataGridViewCellStyle17.NullValue = "0"
        Me.TotalProductionQuantityColumn.DefaultCellStyle = DataGridViewCellStyle17
        Me.TotalProductionQuantityColumn.HeaderText = "Total Production Quantity"
        Me.TotalProductionQuantityColumn.Name = "TotalProductionQuantityColumn"
        '
        'TotalSteelUsedColumn
        '
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = "0"
        Me.TotalSteelUsedColumn.DefaultCellStyle = DataGridViewCellStyle18
        Me.TotalSteelUsedColumn.HeaderText = "Total Steel (lbs)"
        Me.TotalSteelUsedColumn.Name = "TotalSteelUsedColumn"
        '
        'TotalSteelCostColumn
        '
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = "0"
        Me.TotalSteelCostColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.TotalSteelCostColumn.HeaderText = "Total Steel Cost"
        Me.TotalSteelCostColumn.Name = "TotalSteelCostColumn"
        '
        'TotalMachineHoursLYColumn
        '
        DataGridViewCellStyle20.Format = "N1"
        DataGridViewCellStyle20.NullValue = "0"
        Me.TotalMachineHoursLYColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.TotalMachineHoursLYColumn.HeaderText = "Total Machine Hours (Last Year)"
        Me.TotalMachineHoursLYColumn.Name = "TotalMachineHoursLYColumn"
        '
        'TotalInventoryPiecesLYColumn
        '
        DataGridViewCellStyle21.Format = "N0"
        DataGridViewCellStyle21.NullValue = "0"
        Me.TotalInventoryPiecesLYColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.TotalInventoryPiecesLYColumn.HeaderText = "Total Inventory Pieces (Last Year)"
        Me.TotalInventoryPiecesLYColumn.Name = "TotalInventoryPiecesLYColumn"
        '
        'TotalProductionQuantityLYColumn
        '
        DataGridViewCellStyle22.Format = "N0"
        DataGridViewCellStyle22.NullValue = "0"
        Me.TotalProductionQuantityLYColumn.DefaultCellStyle = DataGridViewCellStyle22
        Me.TotalProductionQuantityLYColumn.HeaderText = "Total Production Quantity (Last Year)"
        Me.TotalProductionQuantityLYColumn.Name = "TotalProductionQuantityLYColumn"
        '
        'TotalSteelUsedLYColumn
        '
        DataGridViewCellStyle23.Format = "N2"
        DataGridViewCellStyle23.NullValue = "0"
        Me.TotalSteelUsedLYColumn.DefaultCellStyle = DataGridViewCellStyle23
        Me.TotalSteelUsedLYColumn.HeaderText = "Total Steel (lbs) (Last Year)"
        Me.TotalSteelUsedLYColumn.Name = "TotalSteelUsedLYColumn"
        '
        'TotalSteelCostLYColumn
        '
        DataGridViewCellStyle24.Format = "N2"
        DataGridViewCellStyle24.NullValue = "0"
        Me.TotalSteelCostLYColumn.DefaultCellStyle = DataGridViewCellStyle24
        Me.TotalSteelCostLYColumn.HeaderText = "Total Steel Cost (Last Year)"
        Me.TotalSteelCostLYColumn.Name = "TotalSteelCostLYColumn"
        '
        'ProductionTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.lblBannerLabel)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cboMachineClass)
        Me.Controls.Add(Me.cmdViewTotals)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.dgvProductionTotals)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ProductionTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Production Totals"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvProductionTotals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvProductionTotals As System.Windows.Forms.DataGridView
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewTotals As System.Windows.Forms.Button
    Friend WithEvents cboMachineClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lblBannerLabel As System.Windows.Forms.Label
    Friend WithEvents MachineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalMachineHoursBolumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalInventoryPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSteelUsedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSteelCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalMachineHoursLYColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalInventoryPiecesLYColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalProductionQuantityLYColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSteelUsedLYColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSteelCostLYColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
