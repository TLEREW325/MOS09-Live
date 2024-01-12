<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelUsageByWeek
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxSteelData = New System.Windows.Forms.GroupBox
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.chkOmitZeroTotals = New System.Windows.Forms.CheckBox
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.dtpMonthYear = New System.Windows.Forms.DateTimePicker
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.lblSteelSize = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.dgvSteelMonthSummary = New System.Windows.Forms.DataGridView
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxSteelData.SuspendLayout()
        CType(Me.dgvSteelMonthSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 1
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        Me.PrintListingToolStripMenuItem.Visible = False
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
        'gpxSteelData
        '
        Me.gpxSteelData.Controls.Add(Me.chkAllTypes)
        Me.gpxSteelData.Controls.Add(Me.chkOmitZeroTotals)
        Me.gpxSteelData.Controls.Add(Me.lblEndDate)
        Me.gpxSteelData.Controls.Add(Me.dtpMonthYear)
        Me.gpxSteelData.Controls.Add(Me.cboSteelSize)
        Me.gpxSteelData.Controls.Add(Me.cboCarbon)
        Me.gpxSteelData.Controls.Add(Me.lblSteelSize)
        Me.gpxSteelData.Controls.Add(Me.cmdView)
        Me.gpxSteelData.Controls.Add(Me.cmdClear)
        Me.gpxSteelData.Controls.Add(Me.lblCarbon)
        Me.gpxSteelData.Location = New System.Drawing.Point(12, 27)
        Me.gpxSteelData.Name = "gpxSteelData"
        Me.gpxSteelData.Size = New System.Drawing.Size(300, 300)
        Me.gpxSteelData.TabIndex = 2
        Me.gpxSteelData.TabStop = False
        Me.gpxSteelData.Text = "View By Filters"
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(112, 83)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 1
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'chkOmitZeroTotals
        '
        Me.chkOmitZeroTotals.AutoSize = True
        Me.chkOmitZeroTotals.Location = New System.Drawing.Point(112, 209)
        Me.chkOmitZeroTotals.Name = "chkOmitZeroTotals"
        Me.chkOmitZeroTotals.Size = New System.Drawing.Size(104, 17)
        Me.chkOmitZeroTotals.TabIndex = 4
        Me.chkOmitZeroTotals.Text = "Omit Zero Totals"
        Me.chkOmitZeroTotals.UseVisualStyleBackColor = True
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(24, 169)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(78, 20)
        Me.lblEndDate.TabIndex = 25
        Me.lblEndDate.Text = "Month"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpMonthYear
        '
        Me.dtpMonthYear.CustomFormat = "MM/yyyy"
        Me.dtpMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonthYear.Location = New System.Drawing.Point(112, 169)
        Me.dtpMonthYear.Name = "dtpMonthYear"
        Me.dtpMonthYear.Size = New System.Drawing.Size(172, 20)
        Me.dtpMonthYear.TabIndex = 3
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(112, 129)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(172, 21)
        Me.cboSteelSize.TabIndex = 2
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(112, 35)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(172, 21)
        Me.cboCarbon.TabIndex = 0
        '
        'lblSteelSize
        '
        Me.lblSteelSize.Location = New System.Drawing.Point(24, 129)
        Me.lblSteelSize.Name = "lblSteelSize"
        Me.lblSteelSize.Size = New System.Drawing.Size(78, 20)
        Me.lblSteelSize.TabIndex = 10
        Me.lblSteelSize.Text = "Steel Size"
        Me.lblSteelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(132, 249)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 5
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(209, 249)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'lblCarbon
        '
        Me.lblCarbon.Location = New System.Drawing.Point(24, 35)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(78, 20)
        Me.lblCarbon.TabIndex = 4
        Me.lblCarbon.Text = "Steel Carbon"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSteelMonthSummary
        '
        Me.dgvSteelMonthSummary.AllowUserToAddRows = False
        Me.dgvSteelMonthSummary.AllowUserToDeleteRows = False
        Me.dgvSteelMonthSummary.AllowUserToResizeColumns = False
        Me.dgvSteelMonthSummary.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelMonthSummary.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSteelMonthSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelMonthSummary.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSteelMonthSummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSteelMonthSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSteelMonthSummary.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSteelMonthSummary.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelMonthSummary.Location = New System.Drawing.Point(318, 27)
        Me.dgvSteelMonthSummary.Name = "dgvSteelMonthSummary"
        Me.dgvSteelMonthSummary.ReadOnly = True
        Me.dgvSteelMonthSummary.Size = New System.Drawing.Size(724, 738)
        Me.dgvSteelMonthSummary.TabIndex = 7
        Me.dgvSteelMonthSummary.TabStop = False
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        Me.cmdPrint.Visible = False
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ViewSteelUsageByWeek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSteelMonthSummary)
        Me.Controls.Add(Me.gpxSteelData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ViewSteelUsageByWeek"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Steel Usage By Week"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxSteelData.ResumeLayout(False)
        Me.gpxSteelData.PerformLayout()
        CType(Me.dgvSteelMonthSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSteelData As System.Windows.Forms.GroupBox
    Friend WithEvents chkOmitZeroTotals As System.Windows.Forms.CheckBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpMonthYear As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents lblSteelSize As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents dgvSteelMonthSummary As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
End Class
