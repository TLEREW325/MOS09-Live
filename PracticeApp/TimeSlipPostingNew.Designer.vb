<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeSlipPostingNew
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvTimeSlipEntries = New System.Windows.Forms.DataGridView
        Me.MachineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesProducedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SetupHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolingHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OtherHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostingAddFGColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LaborRateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LaborExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverheadRateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverheadExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineRateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPricePerLBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessRemoveRMColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessAddFGColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineCostPerHourColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeSlipKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScrapWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXStepColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeSlipCombinedDataNewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.TSMenu01 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.grpPostTimeSlip = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdPost = New System.Windows.Forms.Button
        Me.lblDGVMessage = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdDeleteSelected = New System.Windows.Forms.Button
        Me.TimeSlipCombinedDataNewTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipCombinedDataNewTableAdapter
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        CType(Me.dgvTimeSlipEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeSlipCombinedDataNewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.grpPostTimeSlip.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTimeSlipEntries
        '
        Me.dgvTimeSlipEntries.AllowUserToAddRows = False
        Me.dgvTimeSlipEntries.AllowUserToDeleteRows = False
        Me.dgvTimeSlipEntries.AllowUserToResizeColumns = False
        Me.dgvTimeSlipEntries.AllowUserToResizeRows = False
        Me.dgvTimeSlipEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeSlipEntries.AutoGenerateColumns = False
        Me.dgvTimeSlipEntries.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTimeSlipEntries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTimeSlipEntries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTimeSlipEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSlipEntries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MachineIDColumn, Me.FOXNumberColumn, Me.EmployeeNameColumn, Me.PartNumberColumn, Me.RMIDColumn, Me.PiecesProducedColumn, Me.LineWeightColumn, Me.MachineHoursColumn, Me.SetupHoursColumn, Me.ToolingHoursColumn, Me.OtherHoursColumn, Me.TotalHoursColumn, Me.PostingDateColumn, Me.PostingAddFGColumn, Me.LaborRateColumn, Me.LaborExtendedCostColumn, Me.OverheadRateColumn, Me.OverheadExtendedCostColumn, Me.MachineRateColumn, Me.MachineExtendedCostColumn, Me.SteelPricePerLBColumn, Me.SteelExtendedCostColumn, Me.TotalExtendedCostColumn, Me.ProcessIDColumn, Me.ProcessRemoveRMColumn, Me.ProcessAddFGColumn, Me.DescriptionColumn, Me.MachineCostPerHourColumn, Me.TimeSlipKeyColumn, Me.LineKeyColumn, Me.DivisionIDColumn, Me.EmployeeIDColumn, Me.ShiftColumn, Me.StatusColumn, Me.PostedByColumn, Me.PrintDateColumn, Me.ScrapWeightColumn, Me.InventoryPiecesColumn, Me.FOXStepColumn, Me.ProductionNumberColumn})
        Me.dgvTimeSlipEntries.DataSource = Me.TimeSlipCombinedDataNewBindingSource
        Me.dgvTimeSlipEntries.GridColor = System.Drawing.Color.Purple
        Me.dgvTimeSlipEntries.Location = New System.Drawing.Point(12, 28)
        Me.dgvTimeSlipEntries.MultiSelect = False
        Me.dgvTimeSlipEntries.Name = "dgvTimeSlipEntries"
        Me.dgvTimeSlipEntries.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTimeSlipEntries.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTimeSlipEntries.Size = New System.Drawing.Size(1118, 686)
        Me.dgvTimeSlipEntries.TabIndex = 0
        '
        'MachineIDColumn
        '
        Me.MachineIDColumn.DataPropertyName = "MachineID"
        Me.MachineIDColumn.HeaderText = "Machine"
        Me.MachineIDColumn.Name = "MachineIDColumn"
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        '
        'EmployeeNameColumn
        '
        Me.EmployeeNameColumn.DataPropertyName = "EmployeeName"
        Me.EmployeeNameColumn.HeaderText = "Employee"
        Me.EmployeeNameColumn.Name = "EmployeeNameColumn"
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        '
        'PiecesProducedColumn
        '
        Me.PiecesProducedColumn.DataPropertyName = "PiecesProduced"
        Me.PiecesProducedColumn.HeaderText = "Pieces Produced"
        Me.PiecesProducedColumn.Name = "PiecesProducedColumn"
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        '
        'MachineHoursColumn
        '
        Me.MachineHoursColumn.DataPropertyName = "MachineHours"
        Me.MachineHoursColumn.HeaderText = "Machine Hours"
        Me.MachineHoursColumn.Name = "MachineHoursColumn"
        '
        'SetupHoursColumn
        '
        Me.SetupHoursColumn.DataPropertyName = "SetupHours"
        Me.SetupHoursColumn.HeaderText = "Setup Hours"
        Me.SetupHoursColumn.Name = "SetupHoursColumn"
        '
        'ToolingHoursColumn
        '
        Me.ToolingHoursColumn.DataPropertyName = "ToolingHours"
        Me.ToolingHoursColumn.HeaderText = "Tooling Hours"
        Me.ToolingHoursColumn.Name = "ToolingHoursColumn"
        '
        'OtherHoursColumn
        '
        Me.OtherHoursColumn.DataPropertyName = "OtherHours"
        Me.OtherHoursColumn.HeaderText = "Other Hours"
        Me.OtherHoursColumn.Name = "OtherHoursColumn"
        '
        'TotalHoursColumn
        '
        Me.TotalHoursColumn.DataPropertyName = "TotalHours"
        Me.TotalHoursColumn.HeaderText = "Total Hours"
        Me.TotalHoursColumn.Name = "TotalHoursColumn"
        '
        'PostingDateColumn
        '
        Me.PostingDateColumn.DataPropertyName = "PostingDate"
        Me.PostingDateColumn.HeaderText = "Post Date"
        Me.PostingDateColumn.Name = "PostingDateColumn"
        '
        'PostingAddFGColumn
        '
        Me.PostingAddFGColumn.DataPropertyName = "PostingAddFG"
        Me.PostingAddFGColumn.HeaderText = "ADD FG?"
        Me.PostingAddFGColumn.Name = "PostingAddFGColumn"
        '
        'LaborRateColumn
        '
        Me.LaborRateColumn.DataPropertyName = "LaborRate"
        Me.LaborRateColumn.HeaderText = "LaborRate"
        Me.LaborRateColumn.Name = "LaborRateColumn"
        Me.LaborRateColumn.Visible = False
        '
        'LaborExtendedCostColumn
        '
        Me.LaborExtendedCostColumn.DataPropertyName = "LaborExtendedCost"
        Me.LaborExtendedCostColumn.HeaderText = "LaborExtendedCost"
        Me.LaborExtendedCostColumn.Name = "LaborExtendedCostColumn"
        Me.LaborExtendedCostColumn.Visible = False
        '
        'OverheadRateColumn
        '
        Me.OverheadRateColumn.DataPropertyName = "OverheadRate"
        Me.OverheadRateColumn.HeaderText = "OverheadRate"
        Me.OverheadRateColumn.Name = "OverheadRateColumn"
        Me.OverheadRateColumn.Visible = False
        '
        'OverheadExtendedCostColumn
        '
        Me.OverheadExtendedCostColumn.DataPropertyName = "OverheadExtendedCost"
        Me.OverheadExtendedCostColumn.HeaderText = "OverheadExtendedCost"
        Me.OverheadExtendedCostColumn.Name = "OverheadExtendedCostColumn"
        Me.OverheadExtendedCostColumn.Visible = False
        '
        'MachineRateColumn
        '
        Me.MachineRateColumn.DataPropertyName = "MachineRate"
        Me.MachineRateColumn.HeaderText = "MachineRate"
        Me.MachineRateColumn.Name = "MachineRateColumn"
        Me.MachineRateColumn.Visible = False
        '
        'MachineExtendedCostColumn
        '
        Me.MachineExtendedCostColumn.DataPropertyName = "MachineExtendedCost"
        Me.MachineExtendedCostColumn.HeaderText = "MachineExtendedCost"
        Me.MachineExtendedCostColumn.Name = "MachineExtendedCostColumn"
        Me.MachineExtendedCostColumn.Visible = False
        '
        'SteelPricePerLBColumn
        '
        Me.SteelPricePerLBColumn.DataPropertyName = "SteelPricePerLB"
        Me.SteelPricePerLBColumn.HeaderText = "SteelPricePerLB"
        Me.SteelPricePerLBColumn.Name = "SteelPricePerLBColumn"
        Me.SteelPricePerLBColumn.Visible = False
        '
        'SteelExtendedCostColumn
        '
        Me.SteelExtendedCostColumn.DataPropertyName = "SteelExtendedCost"
        Me.SteelExtendedCostColumn.HeaderText = "SteelExtendedCost"
        Me.SteelExtendedCostColumn.Name = "SteelExtendedCostColumn"
        Me.SteelExtendedCostColumn.Visible = False
        '
        'TotalExtendedCostColumn
        '
        Me.TotalExtendedCostColumn.DataPropertyName = "TotalExtendedCost"
        Me.TotalExtendedCostColumn.HeaderText = "TotalExtendedCost"
        Me.TotalExtendedCostColumn.Name = "TotalExtendedCostColumn"
        Me.TotalExtendedCostColumn.Visible = False
        '
        'ProcessIDColumn
        '
        Me.ProcessIDColumn.DataPropertyName = "ProcessID"
        Me.ProcessIDColumn.HeaderText = "ProcessID"
        Me.ProcessIDColumn.Name = "ProcessIDColumn"
        Me.ProcessIDColumn.Visible = False
        '
        'ProcessRemoveRMColumn
        '
        Me.ProcessRemoveRMColumn.DataPropertyName = "ProcessRemoveRM"
        Me.ProcessRemoveRMColumn.HeaderText = "ProcessRemoveRM"
        Me.ProcessRemoveRMColumn.Name = "ProcessRemoveRMColumn"
        Me.ProcessRemoveRMColumn.Visible = False
        '
        'ProcessAddFGColumn
        '
        Me.ProcessAddFGColumn.DataPropertyName = "ProcessAddFG"
        Me.ProcessAddFGColumn.HeaderText = "ProcessAddFG"
        Me.ProcessAddFGColumn.Name = "ProcessAddFGColumn"
        Me.ProcessAddFGColumn.Visible = False
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Visible = False
        '
        'MachineCostPerHourColumn
        '
        Me.MachineCostPerHourColumn.DataPropertyName = "MachineCostPerHour"
        Me.MachineCostPerHourColumn.HeaderText = "MachineCostPerHour"
        Me.MachineCostPerHourColumn.Name = "MachineCostPerHourColumn"
        Me.MachineCostPerHourColumn.Visible = False
        '
        'TimeSlipKeyColumn
        '
        Me.TimeSlipKeyColumn.DataPropertyName = "TimeSlipKey"
        Me.TimeSlipKeyColumn.HeaderText = "TimeSlipKey"
        Me.TimeSlipKeyColumn.Name = "TimeSlipKeyColumn"
        Me.TimeSlipKeyColumn.Visible = False
        '
        'LineKeyColumn
        '
        Me.LineKeyColumn.DataPropertyName = "LineKey"
        Me.LineKeyColumn.HeaderText = "LineKey"
        Me.LineKeyColumn.Name = "LineKeyColumn"
        Me.LineKeyColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'EmployeeIDColumn
        '
        Me.EmployeeIDColumn.DataPropertyName = "EmployeeID"
        Me.EmployeeIDColumn.HeaderText = "EmployeeID"
        Me.EmployeeIDColumn.Name = "EmployeeIDColumn"
        Me.EmployeeIDColumn.Visible = False
        '
        'ShiftColumn
        '
        Me.ShiftColumn.DataPropertyName = "Shift"
        Me.ShiftColumn.HeaderText = "Shift"
        Me.ShiftColumn.Name = "ShiftColumn"
        Me.ShiftColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'PostedByColumn
        '
        Me.PostedByColumn.DataPropertyName = "PostedBy"
        Me.PostedByColumn.HeaderText = "PostedBy"
        Me.PostedByColumn.Name = "PostedByColumn"
        Me.PostedByColumn.Visible = False
        '
        'PrintDateColumn
        '
        Me.PrintDateColumn.DataPropertyName = "PrintDate"
        Me.PrintDateColumn.HeaderText = "PrintDate"
        Me.PrintDateColumn.Name = "PrintDateColumn"
        Me.PrintDateColumn.Visible = False
        '
        'ScrapWeightColumn
        '
        Me.ScrapWeightColumn.DataPropertyName = "ScrapWeight"
        Me.ScrapWeightColumn.HeaderText = "ScrapWeight"
        Me.ScrapWeightColumn.Name = "ScrapWeightColumn"
        Me.ScrapWeightColumn.Visible = False
        '
        'InventoryPiecesColumn
        '
        Me.InventoryPiecesColumn.DataPropertyName = "InventoryPieces"
        Me.InventoryPiecesColumn.HeaderText = "InventoryPieces"
        Me.InventoryPiecesColumn.Name = "InventoryPiecesColumn"
        Me.InventoryPiecesColumn.Visible = False
        '
        'FOXStepColumn
        '
        Me.FOXStepColumn.DataPropertyName = "FOXStep"
        Me.FOXStepColumn.HeaderText = "FOXStep"
        Me.FOXStepColumn.Name = "FOXStepColumn"
        Me.FOXStepColumn.Visible = False
        '
        'ProductionNumberColumn
        '
        Me.ProductionNumberColumn.DataPropertyName = "ProductionNumber"
        Me.ProductionNumberColumn.HeaderText = "ProductionNumber"
        Me.ProductionNumberColumn.Name = "ProductionNumberColumn"
        Me.ProductionNumberColumn.Visible = False
        '
        'TimeSlipCombinedDataNewBindingSource
        '
        Me.TimeSlipCombinedDataNewBindingSource.DataMember = "TimeSlipCombinedDataNew"
        Me.TimeSlipCombinedDataNewBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMenu01, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 80
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TSMenu01
        '
        Me.TSMenu01.Name = "TSMenu01"
        Me.TSMenu01.Size = New System.Drawing.Size(35, 20)
        Me.TSMenu01.Text = "File"
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
        'grpPostTimeSlip
        '
        Me.grpPostTimeSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpPostTimeSlip.Controls.Add(Me.Label16)
        Me.grpPostTimeSlip.Controls.Add(Me.cmdPost)
        Me.grpPostTimeSlip.Location = New System.Drawing.Point(12, 734)
        Me.grpPostTimeSlip.Name = "grpPostTimeSlip"
        Me.grpPostTimeSlip.Size = New System.Drawing.Size(310, 69)
        Me.grpPostTimeSlip.TabIndex = 81
        Me.grpPostTimeSlip.TabStop = False
        Me.grpPostTimeSlip.Text = "Post Time Slips"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(16, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(176, 35)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "No more changes can be made after posting time slips."
        '
        'cmdPost
        '
        Me.cmdPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPost.Enabled = False
        Me.cmdPost.ForeColor = System.Drawing.Color.Blue
        Me.cmdPost.Location = New System.Drawing.Point(222, 16)
        Me.cmdPost.Name = "cmdPost"
        Me.cmdPost.Size = New System.Drawing.Size(71, 40)
        Me.cmdPost.TabIndex = 82
        Me.cmdPost.Text = "Post Time Slips"
        Me.cmdPost.UseVisualStyleBackColor = True
        '
        'lblDGVMessage
        '
        Me.lblDGVMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDGVMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblDGVMessage.Location = New System.Drawing.Point(554, 755)
        Me.lblDGVMessage.Name = "lblDGVMessage"
        Me.lblDGVMessage.Size = New System.Drawing.Size(320, 19)
        Me.lblDGVMessage.TabIndex = 86
        Me.lblDGVMessage.Text = "***All changes made above will automatically be saved.***"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Location = New System.Drawing.Point(1059, 776)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 86
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.Location = New System.Drawing.Point(982, 776)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 87
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.LightGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(356, 750)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 90
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(385, 755)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "- Adds to Inventory"
        '
        'cmdDeleteSelected
        '
        Me.cmdDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSelected.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteSelected.Location = New System.Drawing.Point(905, 776)
        Me.cmdDeleteSelected.Name = "cmdDeleteSelected"
        Me.cmdDeleteSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelected.TabIndex = 92
        Me.cmdDeleteSelected.Text = "Delete Selected"
        Me.cmdDeleteSelected.UseVisualStyleBackColor = True
        '
        'TimeSlipCombinedDataNewTableAdapter
        '
        Me.TimeSlipCombinedDataNewTableAdapter.ClearBeforeFill = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(905, 734)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(225, 21)
        Me.cboDivisionID.TabIndex = 93
        '
        'TimeSlipPostingNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.cmdDeleteSelected)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblDGVMessage)
        Me.Controls.Add(Me.grpPostTimeSlip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvTimeSlipEntries)
        Me.Name = "TimeSlipPostingNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Time Slip Posting"
        CType(Me.dgvTimeSlipEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeSlipCombinedDataNewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpPostTimeSlip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvTimeSlipEntries As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TSMenu01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpPostTimeSlip As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdPost As System.Windows.Forms.Button
    Friend WithEvents lblDGVMessage As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents TimeSlipCombinedDataNewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimeSlipCombinedDataNewTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipCombinedDataNewTableAdapter
    Friend WithEvents MachineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesProducedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SetupHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolingHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingAddFGColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LaborRateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LaborExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverheadRateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverheadExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineRateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPricePerLBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessRemoveRMColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessAddFGColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineCostPerHourColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeSlipKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScrapWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXStepColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox

End Class
