<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelReceivingMonthlySummary
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
        Me.gpxFilters = New System.Windows.Forms.GroupBox
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkUseDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndingDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginningDate = New System.Windows.Forms.DateTimePicker
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvReceivingMonthlySummary = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxFilters.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvReceivingMonthlySummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxFilters
        '
        Me.gpxFilters.Controls.Add(Me.chkAllTypes)
        Me.gpxFilters.Controls.Add(Me.cmdClear)
        Me.gpxFilters.Controls.Add(Me.cmdView)
        Me.gpxFilters.Controls.Add(Me.Label5)
        Me.gpxFilters.Controls.Add(Me.Label4)
        Me.gpxFilters.Controls.Add(Me.chkUseDateRange)
        Me.gpxFilters.Controls.Add(Me.dtpEndingDate)
        Me.gpxFilters.Controls.Add(Me.dtpBeginningDate)
        Me.gpxFilters.Controls.Add(Me.cboSteelSize)
        Me.gpxFilters.Controls.Add(Me.Label3)
        Me.gpxFilters.Controls.Add(Me.cboCarbon)
        Me.gpxFilters.Controls.Add(Me.Label2)
        Me.gpxFilters.Controls.Add(Me.lblVendorName)
        Me.gpxFilters.Controls.Add(Me.cboVendorID)
        Me.gpxFilters.Controls.Add(Me.Label1)
        Me.gpxFilters.Location = New System.Drawing.Point(12, 29)
        Me.gpxFilters.Name = "gpxFilters"
        Me.gpxFilters.Size = New System.Drawing.Size(300, 511)
        Me.gpxFilters.TabIndex = 0
        Me.gpxFilters.TabStop = False
        Me.gpxFilters.Text = "Filters"
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(113, 211)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 75
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(210, 456)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(133, 456)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 415)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "End Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 378)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Begin Date"
        '
        'chkUseDateRange
        '
        Me.chkUseDateRange.AutoSize = True
        Me.chkUseDateRange.Location = New System.Drawing.Point(103, 331)
        Me.chkUseDateRange.Name = "chkUseDateRange"
        Me.chkUseDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDateRange.TabIndex = 9
        Me.chkUseDateRange.Text = "Use Date Range"
        Me.chkUseDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndingDate.Location = New System.Drawing.Point(103, 411)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpEndingDate.TabIndex = 8
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginningDate.Location = New System.Drawing.Point(103, 374)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpBeginningDate.TabIndex = 7
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(103, 245)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(178, 21)
        Me.cboSteelSize.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Size"
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(103, 170)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(178, 21)
        Me.cboCarbon.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Grade"
        '
        'lblVendorName
        '
        Me.lblVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVendorName.Location = New System.Drawing.Point(18, 73)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(263, 59)
        Me.lblVendorName.TabIndex = 2
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(76, 35)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(205, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendor ID"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FielToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FielToolStripMenuItem
        '
        Me.FielToolStripMenuItem.Name = "FielToolStripMenuItem"
        Me.FielToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FielToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'dgvReceivingMonthlySummary
        '
        Me.dgvReceivingMonthlySummary.AllowUserToAddRows = False
        Me.dgvReceivingMonthlySummary.AllowUserToDeleteRows = False
        Me.dgvReceivingMonthlySummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceivingMonthlySummary.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceivingMonthlySummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = "0"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReceivingMonthlySummary.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReceivingMonthlySummary.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvReceivingMonthlySummary.Location = New System.Drawing.Point(330, 27)
        Me.dgvReceivingMonthlySummary.Name = "dgvReceivingMonthlySummary"
        Me.dgvReceivingMonthlySummary.ReadOnly = True
        Me.dgvReceivingMonthlySummary.Size = New System.Drawing.Size(700, 683)
        Me.dgvReceivingMonthlySummary.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'ViewSteelReceivingMonthlySummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvReceivingMonthlySummary)
        Me.Controls.Add(Me.gpxFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelReceivingMonthlySummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Steel Receiving Monthly Summary"
        Me.gpxFilters.ResumeLayout(False)
        Me.gpxFilters.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvReceivingMonthlySummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxFilters As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvReceivingMonthlySummary As System.Windows.Forms.DataGridView
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkUseDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginningDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
End Class
