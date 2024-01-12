<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllCompanyTotals
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxCompanyData = New System.Windows.Forms.GroupBox
        Me.dtpDateSelection = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.tabTotals = New System.Windows.Forms.TabControl
        Me.tabCompanyTotals = New System.Windows.Forms.TabPage
        Me.dgvCompanyTotals = New System.Windows.Forms.DataGridView
        Me.tabMTDYTD = New System.Windows.Forms.TabPage
        Me.dgvMTDYTD = New System.Windows.Forms.DataGridView
        Me.tabARAging = New System.Windows.Forms.TabPage
        Me.dgvARAging = New System.Windows.Forms.DataGridView
        Me.tabAPAging = New System.Windows.Forms.TabPage
        Me.dgvAPAging = New System.Windows.Forms.DataGridView
        Me.tabConsignment = New System.Windows.Forms.TabPage
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTotalConsignmentSales = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.lblTotalConsignmentShipments = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.cmdClearConsignment = New System.Windows.Forms.Button
        Me.cmdViewConsignment = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.dtpConsignmentStartDate = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.dtpConsignmentEndDate = New System.Windows.Forms.DateTimePicker
        Me.dgvConsignmentTotals = New System.Windows.Forms.DataGridView
        Me.cmdReload = New System.Windows.Forms.Button
        Me.bgwkCompanyTotals = New System.ComponentModel.BackgroundWorker
        Me.bgwkLoadMTDYTD = New System.ComponentModel.BackgroundWorker
        Me.bgwkLoadARAging = New System.ComponentModel.BackgroundWorker
        Me.bgwkAPAging = New System.ComponentModel.BackgroundWorker
        Me.Label2 = New System.Windows.Forms.Label
        Me.gpxCompanyData.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.tabTotals.SuspendLayout()
        Me.tabCompanyTotals.SuspendLayout()
        CType(Me.dgvCompanyTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMTDYTD.SuspendLayout()
        CType(Me.dgvMTDYTD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabARAging.SuspendLayout()
        CType(Me.dgvARAging, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAPAging.SuspendLayout()
        CType(Me.dgvAPAging, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConsignment.SuspendLayout()
        CType(Me.dgvConsignmentTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxCompanyData
        '
        Me.gpxCompanyData.Controls.Add(Me.dtpDateSelection)
        Me.gpxCompanyData.Controls.Add(Me.Label1)
        Me.gpxCompanyData.Location = New System.Drawing.Point(10, 27)
        Me.gpxCompanyData.Name = "gpxCompanyData"
        Me.gpxCompanyData.Size = New System.Drawing.Size(211, 47)
        Me.gpxCompanyData.TabIndex = 0
        Me.gpxCompanyData.TabStop = False
        Me.gpxCompanyData.Text = "Date"
        '
        'dtpDateSelection
        '
        Me.dtpDateSelection.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateSelection.Location = New System.Drawing.Point(58, 14)
        Me.dtpDateSelection.Name = "dtpDateSelection"
        Me.dtpDateSelection.Size = New System.Drawing.Size(141, 20)
        Me.dtpDateSelection.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1134, 24)
        Me.MenuStrip1.TabIndex = 2
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
        'tabTotals
        '
        Me.tabTotals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTotals.Controls.Add(Me.tabCompanyTotals)
        Me.tabTotals.Controls.Add(Me.tabMTDYTD)
        Me.tabTotals.Controls.Add(Me.tabARAging)
        Me.tabTotals.Controls.Add(Me.tabAPAging)
        Me.tabTotals.Controls.Add(Me.tabConsignment)
        Me.tabTotals.Location = New System.Drawing.Point(10, 92)
        Me.tabTotals.Name = "tabTotals"
        Me.tabTotals.SelectedIndex = 0
        Me.tabTotals.Size = New System.Drawing.Size(1112, 657)
        Me.tabTotals.TabIndex = 4
        '
        'tabCompanyTotals
        '
        Me.tabCompanyTotals.Controls.Add(Me.dgvCompanyTotals)
        Me.tabCompanyTotals.Location = New System.Drawing.Point(4, 22)
        Me.tabCompanyTotals.Name = "tabCompanyTotals"
        Me.tabCompanyTotals.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCompanyTotals.Size = New System.Drawing.Size(1104, 631)
        Me.tabCompanyTotals.TabIndex = 0
        Me.tabCompanyTotals.Text = "Company Totals"
        Me.tabCompanyTotals.UseVisualStyleBackColor = True
        '
        'dgvCompanyTotals
        '
        Me.dgvCompanyTotals.AllowUserToAddRows = False
        Me.dgvCompanyTotals.AllowUserToDeleteRows = False
        Me.dgvCompanyTotals.AllowUserToResizeColumns = False
        Me.dgvCompanyTotals.AllowUserToResizeRows = False
        Me.dgvCompanyTotals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCompanyTotals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCompanyTotals.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCompanyTotals.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCompanyTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompanyTotals.Location = New System.Drawing.Point(6, 6)
        Me.dgvCompanyTotals.Name = "dgvCompanyTotals"
        Me.dgvCompanyTotals.ReadOnly = True
        Me.dgvCompanyTotals.RowHeadersVisible = False
        Me.dgvCompanyTotals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompanyTotals.Size = New System.Drawing.Size(1092, 619)
        Me.dgvCompanyTotals.TabIndex = 391
        '
        'tabMTDYTD
        '
        Me.tabMTDYTD.Controls.Add(Me.dgvMTDYTD)
        Me.tabMTDYTD.Location = New System.Drawing.Point(4, 22)
        Me.tabMTDYTD.Name = "tabMTDYTD"
        Me.tabMTDYTD.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMTDYTD.Size = New System.Drawing.Size(1104, 631)
        Me.tabMTDYTD.TabIndex = 1
        Me.tabMTDYTD.Text = "MTD and YTD Totals"
        Me.tabMTDYTD.UseVisualStyleBackColor = True
        '
        'dgvMTDYTD
        '
        Me.dgvMTDYTD.AllowUserToAddRows = False
        Me.dgvMTDYTD.AllowUserToDeleteRows = False
        Me.dgvMTDYTD.AllowUserToResizeColumns = False
        Me.dgvMTDYTD.AllowUserToResizeRows = False
        Me.dgvMTDYTD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMTDYTD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMTDYTD.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMTDYTD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMTDYTD.ColumnHeadersHeight = 70
        Me.dgvMTDYTD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMTDYTD.Location = New System.Drawing.Point(6, 6)
        Me.dgvMTDYTD.Name = "dgvMTDYTD"
        Me.dgvMTDYTD.ReadOnly = True
        Me.dgvMTDYTD.RowHeadersVisible = False
        Me.dgvMTDYTD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMTDYTD.Size = New System.Drawing.Size(1092, 619)
        Me.dgvMTDYTD.TabIndex = 392
        '
        'tabARAging
        '
        Me.tabARAging.Controls.Add(Me.dgvARAging)
        Me.tabARAging.Location = New System.Drawing.Point(4, 22)
        Me.tabARAging.Name = "tabARAging"
        Me.tabARAging.Padding = New System.Windows.Forms.Padding(3)
        Me.tabARAging.Size = New System.Drawing.Size(1104, 631)
        Me.tabARAging.TabIndex = 2
        Me.tabARAging.Text = "AR Aging Totals"
        Me.tabARAging.UseVisualStyleBackColor = True
        '
        'dgvARAging
        '
        Me.dgvARAging.AllowUserToAddRows = False
        Me.dgvARAging.AllowUserToDeleteRows = False
        Me.dgvARAging.AllowUserToResizeColumns = False
        Me.dgvARAging.AllowUserToResizeRows = False
        Me.dgvARAging.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvARAging.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvARAging.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvARAging.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvARAging.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvARAging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARAging.Location = New System.Drawing.Point(6, 6)
        Me.dgvARAging.Name = "dgvARAging"
        Me.dgvARAging.ReadOnly = True
        Me.dgvARAging.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvARAging.RowHeadersVisible = False
        Me.dgvARAging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvARAging.Size = New System.Drawing.Size(1092, 619)
        Me.dgvARAging.TabIndex = 393
        '
        'tabAPAging
        '
        Me.tabAPAging.BackColor = System.Drawing.Color.Transparent
        Me.tabAPAging.Controls.Add(Me.dgvAPAging)
        Me.tabAPAging.Location = New System.Drawing.Point(4, 22)
        Me.tabAPAging.Name = "tabAPAging"
        Me.tabAPAging.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAPAging.Size = New System.Drawing.Size(1104, 631)
        Me.tabAPAging.TabIndex = 3
        Me.tabAPAging.Text = "AP Aging Totals"
        Me.tabAPAging.UseVisualStyleBackColor = True
        '
        'dgvAPAging
        '
        Me.dgvAPAging.AllowUserToAddRows = False
        Me.dgvAPAging.AllowUserToDeleteRows = False
        Me.dgvAPAging.AllowUserToResizeColumns = False
        Me.dgvAPAging.AllowUserToResizeRows = False
        Me.dgvAPAging.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAPAging.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAPAging.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAPAging.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAPAging.Location = New System.Drawing.Point(6, 6)
        Me.dgvAPAging.Name = "dgvAPAging"
        Me.dgvAPAging.ReadOnly = True
        Me.dgvAPAging.RowHeadersVisible = False
        Me.dgvAPAging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAPAging.Size = New System.Drawing.Size(1092, 619)
        Me.dgvAPAging.TabIndex = 394
        '
        'tabConsignment
        '
        Me.tabConsignment.BackColor = System.Drawing.Color.Transparent
        Me.tabConsignment.Controls.Add(Me.cboDivisionID)
        Me.tabConsignment.Controls.Add(Me.Label3)
        Me.tabConsignment.Controls.Add(Me.lblTotalConsignmentSales)
        Me.tabConsignment.Controls.Add(Me.Label45)
        Me.tabConsignment.Controls.Add(Me.lblTotalConsignmentShipments)
        Me.tabConsignment.Controls.Add(Me.Label39)
        Me.tabConsignment.Controls.Add(Me.cmdClearConsignment)
        Me.tabConsignment.Controls.Add(Me.cmdViewConsignment)
        Me.tabConsignment.Controls.Add(Me.Label26)
        Me.tabConsignment.Controls.Add(Me.dtpConsignmentStartDate)
        Me.tabConsignment.Controls.Add(Me.Label23)
        Me.tabConsignment.Controls.Add(Me.dtpConsignmentEndDate)
        Me.tabConsignment.Controls.Add(Me.dgvConsignmentTotals)
        Me.tabConsignment.Location = New System.Drawing.Point(4, 22)
        Me.tabConsignment.Name = "tabConsignment"
        Me.tabConsignment.Size = New System.Drawing.Size(1104, 631)
        Me.tabConsignment.TabIndex = 4
        Me.tabConsignment.Text = "Consignment"
        Me.tabConsignment.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(498, 20)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(121, 21)
        Me.cboDivisionID.TabIndex = 100
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(425, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 21)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalConsignmentSales
        '
        Me.lblTotalConsignmentSales.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTotalConsignmentSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalConsignmentSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalConsignmentSales.Location = New System.Drawing.Point(537, 600)
        Me.lblTotalConsignmentSales.Name = "lblTotalConsignmentSales"
        Me.lblTotalConsignmentSales.Size = New System.Drawing.Size(186, 23)
        Me.lblTotalConsignmentSales.TabIndex = 98
        Me.lblTotalConsignmentSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(460, 605)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(71, 13)
        Me.Label45.TabIndex = 97
        Me.Label45.Text = "Total Sales"
        '
        'lblTotalConsignmentShipments
        '
        Me.lblTotalConsignmentShipments.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTotalConsignmentShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalConsignmentShipments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalConsignmentShipments.Location = New System.Drawing.Point(243, 600)
        Me.lblTotalConsignmentShipments.Name = "lblTotalConsignmentShipments"
        Me.lblTotalConsignmentShipments.Size = New System.Drawing.Size(186, 23)
        Me.lblTotalConsignmentShipments.TabIndex = 96
        Me.lblTotalConsignmentShipments.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label39
        '
        Me.Label39.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(139, 605)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(98, 13)
        Me.Label39.TabIndex = 95
        Me.Label39.Text = "Total Shipments"
        '
        'cmdClearConsignment
        '
        Me.cmdClearConsignment.Location = New System.Drawing.Point(744, 10)
        Me.cmdClearConsignment.Name = "cmdClearConsignment"
        Me.cmdClearConsignment.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearConsignment.TabIndex = 94
        Me.cmdClearConsignment.Text = "Clear"
        Me.cmdClearConsignment.UseVisualStyleBackColor = True
        '
        'cmdViewConsignment
        '
        Me.cmdViewConsignment.Location = New System.Drawing.Point(667, 10)
        Me.cmdViewConsignment.Name = "cmdViewConsignment"
        Me.cmdViewConsignment.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewConsignment.TabIndex = 93
        Me.cmdViewConsignment.Text = "View"
        Me.cmdViewConsignment.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(207, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(63, 20)
        Me.Label26.TabIndex = 92
        Me.Label26.Text = "End Date"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpConsignmentStartDate
        '
        Me.dtpConsignmentStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpConsignmentStartDate.Location = New System.Drawing.Point(72, 20)
        Me.dtpConsignmentStartDate.Name = "dtpConsignmentStartDate"
        Me.dtpConsignmentStartDate.Size = New System.Drawing.Size(105, 20)
        Me.dtpConsignmentStartDate.TabIndex = 40
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(3, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(63, 20)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "Start Date"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpConsignmentEndDate
        '
        Me.dtpConsignmentEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpConsignmentEndDate.Location = New System.Drawing.Point(276, 20)
        Me.dtpConsignmentEndDate.Name = "dtpConsignmentEndDate"
        Me.dtpConsignmentEndDate.Size = New System.Drawing.Size(105, 20)
        Me.dtpConsignmentEndDate.TabIndex = 91
        '
        'dgvConsignmentTotals
        '
        Me.dgvConsignmentTotals.AllowUserToAddRows = False
        Me.dgvConsignmentTotals.AllowUserToDeleteRows = False
        Me.dgvConsignmentTotals.AllowUserToResizeColumns = False
        Me.dgvConsignmentTotals.AllowUserToResizeRows = False
        DataGridViewCellStyle5.Format = "C2"
        Me.dgvConsignmentTotals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvConsignmentTotals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsignmentTotals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvConsignmentTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConsignmentTotals.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvConsignmentTotals.Location = New System.Drawing.Point(3, 59)
        Me.dgvConsignmentTotals.Name = "dgvConsignmentTotals"
        Me.dgvConsignmentTotals.ReadOnly = True
        Me.dgvConsignmentTotals.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.dgvConsignmentTotals.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvConsignmentTotals.RowTemplate.DefaultCellStyle.Format = "C2"
        Me.dgvConsignmentTotals.Size = New System.Drawing.Size(1098, 538)
        Me.dgvConsignmentTotals.TabIndex = 90
        '
        'cmdReload
        '
        Me.cmdReload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReload.Location = New System.Drawing.Point(227, 34)
        Me.cmdReload.Name = "cmdReload"
        Me.cmdReload.Size = New System.Drawing.Size(71, 40)
        Me.cmdReload.TabIndex = 87
        Me.cmdReload.Text = "Reload data"
        Me.cmdReload.UseVisualStyleBackColor = True
        '
        'bgwkCompanyTotals
        '
        '
        'bgwkLoadMTDYTD
        '
        '
        'bgwkLoadARAging
        '
        '
        'bgwkAPAging
        '
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(394, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(419, 31)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "AR and AP Aging are always today's date not date in date time picker"
        '
        'AllCompanyTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 761)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gpxCompanyData)
        Me.Controls.Add(Me.cmdReload)
        Me.Controls.Add(Me.tabTotals)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "AllCompanyTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation All Company Totals"
        Me.gpxCompanyData.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabTotals.ResumeLayout(False)
        Me.tabCompanyTotals.ResumeLayout(False)
        CType(Me.dgvCompanyTotals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMTDYTD.ResumeLayout(False)
        CType(Me.dgvMTDYTD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabARAging.ResumeLayout(False)
        CType(Me.dgvARAging, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAPAging.ResumeLayout(False)
        CType(Me.dgvAPAging, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConsignment.ResumeLayout(False)
        Me.tabConsignment.PerformLayout()
        CType(Me.dgvConsignmentTotals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxCompanyData As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDateSelection As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabTotals As System.Windows.Forms.TabControl
    Friend WithEvents tabCompanyTotals As System.Windows.Forms.TabPage
    Friend WithEvents tabMTDYTD As System.Windows.Forms.TabPage
    Friend WithEvents tabARAging As System.Windows.Forms.TabPage
    Friend WithEvents tabAPAging As System.Windows.Forms.TabPage
    Friend WithEvents cmdReload As System.Windows.Forms.Button
    Friend WithEvents bgwkCompanyTotals As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwkLoadMTDYTD As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwkLoadARAging As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwkAPAging As System.ComponentModel.BackgroundWorker
    Friend WithEvents tabConsignment As System.Windows.Forms.TabPage
    Friend WithEvents cmdClearConsignment As System.Windows.Forms.Button
    Friend WithEvents cmdViewConsignment As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dtpConsignmentStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtpConsignmentEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvConsignmentTotals As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalConsignmentShipments As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lblTotalConsignmentSales As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents dgvCompanyTotals As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMTDYTD As System.Windows.Forms.DataGridView
    Friend WithEvents dgvARAging As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAPAging As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
