<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewActivityLog
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvActivity = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxItemListFilters = New System.Windows.Forms.GroupBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.chkUseDateRange = New System.Windows.Forms.CheckBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpxLotFilters = New System.Windows.Forms.GroupBox
        Me.cboLotPartNumber = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdlotClear = New System.Windows.Forms.Button
        Me.cmdLotView = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtLotTextFilter = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpLotEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpLotStartDate = New System.Windows.Forms.DateTimePicker
        Me.chkLotUseDateRange = New System.Windows.Forms.CheckBox
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.dgvActivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxItemListFilters.SuspendLayout()
        Me.gpxLotFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvActivity
        '
        Me.dgvActivity.AllowUserToAddRows = False
        Me.dgvActivity.AllowUserToDeleteRows = False
        Me.dgvActivity.AllowUserToResizeRows = False
        Me.dgvActivity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvActivity.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvActivity.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvActivity.Location = New System.Drawing.Point(12, 12)
        Me.dgvActivity.Name = "dgvActivity"
        Me.dgvActivity.ReadOnly = True
        Me.dgvActivity.RowHeadersVisible = False
        Me.dgvActivity.Size = New System.Drawing.Size(1010, 641)
        Me.dgvActivity.TabIndex = 0
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(951, 659)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxItemListFilters
        '
        Me.gpxItemListFilters.Controls.Add(Me.cmdClear)
        Me.gpxItemListFilters.Controls.Add(Me.cmdView)
        Me.gpxItemListFilters.Controls.Add(Me.Label5)
        Me.gpxItemListFilters.Controls.Add(Me.txtTextFilter)
        Me.gpxItemListFilters.Controls.Add(Me.Label4)
        Me.gpxItemListFilters.Controls.Add(Me.dtpEndDate)
        Me.gpxItemListFilters.Controls.Add(Me.Label3)
        Me.gpxItemListFilters.Controls.Add(Me.dtpStartDate)
        Me.gpxItemListFilters.Controls.Add(Me.chkUseDateRange)
        Me.gpxItemListFilters.Controls.Add(Me.cboPartNumber)
        Me.gpxItemListFilters.Controls.Add(Me.Label2)
        Me.gpxItemListFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxItemListFilters.Controls.Add(Me.Label1)
        Me.gpxItemListFilters.Location = New System.Drawing.Point(12, 12)
        Me.gpxItemListFilters.Name = "gpxItemListFilters"
        Me.gpxItemListFilters.Size = New System.Drawing.Size(236, 333)
        Me.gpxItemListFilters.TabIndex = 30
        Me.gpxItemListFilters.TabStop = False
        Me.gpxItemListFilters.Text = "Item List Filters"
        Me.gpxItemListFilters.Visible = False
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(157, 280)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 7
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdView.Location = New System.Drawing.Point(80, 280)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 6
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Text Filter:"
        '
        'txtTextFilter
        '
        Me.txtTextFilter.Location = New System.Drawing.Point(78, 229)
        Me.txtTextFilter.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(150, 20)
        Me.txtTextFilter.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "End Date:"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(109, 185)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(119, 20)
        Me.dtpEndDate.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Start Date:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(109, 155)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(119, 20)
        Me.dtpStartDate.TabIndex = 3
        '
        'chkUseDateRange
        '
        Me.chkUseDateRange.AutoSize = True
        Me.chkUseDateRange.Location = New System.Drawing.Point(122, 130)
        Me.chkUseDateRange.Margin = New System.Windows.Forms.Padding(5)
        Me.chkUseDateRange.Name = "chkUseDateRange"
        Me.chkUseDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDateRange.TabIndex = 2
        Me.chkUseDateRange.Text = "Use Date Range"
        Me.chkUseDateRange.UseVisualStyleBackColor = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(10, 86)
        Me.cboPartNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(218, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Part Number:"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(78, 34)
        Me.cboDivisionID.Margin = New System.Windows.Forms.Padding(5)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(150, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Division ID:"
        '
        'gpxLotFilters
        '
        Me.gpxLotFilters.Controls.Add(Me.cboLotPartNumber)
        Me.gpxLotFilters.Controls.Add(Me.Label11)
        Me.gpxLotFilters.Controls.Add(Me.cmdlotClear)
        Me.gpxLotFilters.Controls.Add(Me.cmdLotView)
        Me.gpxLotFilters.Controls.Add(Me.Label6)
        Me.gpxLotFilters.Controls.Add(Me.txtLotTextFilter)
        Me.gpxLotFilters.Controls.Add(Me.Label7)
        Me.gpxLotFilters.Controls.Add(Me.dtpLotEndDate)
        Me.gpxLotFilters.Controls.Add(Me.Label8)
        Me.gpxLotFilters.Controls.Add(Me.dtpLotStartDate)
        Me.gpxLotFilters.Controls.Add(Me.chkLotUseDateRange)
        Me.gpxLotFilters.Controls.Add(Me.cboFOXNumber)
        Me.gpxLotFilters.Controls.Add(Me.Label9)
        Me.gpxLotFilters.Controls.Add(Me.cboLotNumber)
        Me.gpxLotFilters.Controls.Add(Me.Label10)
        Me.gpxLotFilters.Location = New System.Drawing.Point(12, 12)
        Me.gpxLotFilters.Name = "gpxLotFilters"
        Me.gpxLotFilters.Size = New System.Drawing.Size(236, 333)
        Me.gpxLotFilters.TabIndex = 31
        Me.gpxLotFilters.TabStop = False
        Me.gpxLotFilters.Text = "Lot Filters"
        Me.gpxLotFilters.Visible = False
        '
        'cboLotPartNumber
        '
        Me.cboLotPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotPartNumber.FormattingEnabled = True
        Me.cboLotPartNumber.Location = New System.Drawing.Point(78, 96)
        Me.cboLotPartNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboLotPartNumber.Name = "cboLotPartNumber"
        Me.cboLotPartNumber.Size = New System.Drawing.Size(150, 21)
        Me.cboLotPartNumber.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Part Number:"
        '
        'cmdlotClear
        '
        Me.cmdlotClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdlotClear.Location = New System.Drawing.Point(157, 280)
        Me.cmdlotClear.Name = "cmdlotClear"
        Me.cmdlotClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdlotClear.TabIndex = 8
        Me.cmdlotClear.Text = "Clear"
        Me.cmdlotClear.UseVisualStyleBackColor = True
        '
        'cmdLotView
        '
        Me.cmdLotView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLotView.Location = New System.Drawing.Point(80, 280)
        Me.cmdLotView.Name = "cmdLotView"
        Me.cmdLotView.Size = New System.Drawing.Size(71, 40)
        Me.cmdLotView.TabIndex = 7
        Me.cmdLotView.Text = "View"
        Me.cmdLotView.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Text Filter:"
        '
        'txtLotTextFilter
        '
        Me.txtLotTextFilter.Location = New System.Drawing.Point(78, 229)
        Me.txtLotTextFilter.Margin = New System.Windows.Forms.Padding(5)
        Me.txtLotTextFilter.Name = "txtLotTextFilter"
        Me.txtLotTextFilter.Size = New System.Drawing.Size(150, 20)
        Me.txtLotTextFilter.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "End Date:"
        '
        'dtpLotEndDate
        '
        Me.dtpLotEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLotEndDate.Location = New System.Drawing.Point(109, 185)
        Me.dtpLotEndDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpLotEndDate.Name = "dtpLotEndDate"
        Me.dtpLotEndDate.Size = New System.Drawing.Size(119, 20)
        Me.dtpLotEndDate.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Start Date:"
        '
        'dtpLotStartDate
        '
        Me.dtpLotStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLotStartDate.Location = New System.Drawing.Point(109, 155)
        Me.dtpLotStartDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpLotStartDate.Name = "dtpLotStartDate"
        Me.dtpLotStartDate.Size = New System.Drawing.Size(119, 20)
        Me.dtpLotStartDate.TabIndex = 4
        '
        'chkLotUseDateRange
        '
        Me.chkLotUseDateRange.AutoSize = True
        Me.chkLotUseDateRange.Location = New System.Drawing.Point(122, 130)
        Me.chkLotUseDateRange.Margin = New System.Windows.Forms.Padding(5)
        Me.chkLotUseDateRange.Name = "chkLotUseDateRange"
        Me.chkLotUseDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkLotUseDateRange.TabIndex = 3
        Me.chkLotUseDateRange.Text = "Use Date Range"
        Me.chkLotUseDateRange.UseVisualStyleBackColor = True
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(78, 65)
        Me.cboFOXNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(150, 21)
        Me.cboFOXNumber.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "FOX Number:"
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(78, 34)
        Me.cboLotNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(150, 21)
        Me.cboLotNumber.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Lot Number:"
        '
        'ViewActivityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.gpxLotFilters)
        Me.Controls.Add(Me.gpxItemListFilters)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvActivity)
        Me.Name = "ViewActivityLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Activity Log"
        CType(Me.dgvActivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxItemListFilters.ResumeLayout(False)
        Me.gpxItemListFilters.PerformLayout()
        Me.gpxLotFilters.ResumeLayout(False)
        Me.gpxLotFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvActivity As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxItemListFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkUseDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxLotFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cboLotPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdlotClear As System.Windows.Forms.Button
    Friend WithEvents cmdLotView As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLotTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpLotEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpLotStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkLotUseDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
