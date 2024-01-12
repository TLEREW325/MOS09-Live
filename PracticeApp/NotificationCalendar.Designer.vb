<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationCalendar
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
        Me.dgvCalendar = New System.Windows.Forms.DataGridView
        Me.cboCalendarMonth = New System.Windows.Forms.ComboBox
        Me.cboCalendarYear = New System.Windows.Forms.ComboBox
        Me.lblDivisionID = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.gpxFilters = New System.Windows.Forms.GroupBox
        Me.cboEmployee = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgvCalendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxFilters.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCalendar
        '
        Me.dgvCalendar.AllowUserToAddRows = False
        Me.dgvCalendar.AllowUserToDeleteRows = False
        Me.dgvCalendar.AllowUserToResizeColumns = False
        Me.dgvCalendar.AllowUserToResizeRows = False
        Me.dgvCalendar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCalendar.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCalendar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCalendar.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCalendar.Location = New System.Drawing.Point(273, 42)
        Me.dgvCalendar.MultiSelect = False
        Me.dgvCalendar.Name = "dgvCalendar"
        Me.dgvCalendar.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCalendar.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCalendar.RowHeadersVisible = False
        Me.dgvCalendar.RowHeadersWidth = 10
        Me.dgvCalendar.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCalendar.Size = New System.Drawing.Size(799, 626)
        Me.dgvCalendar.TabIndex = 10
        '
        'cboCalendarMonth
        '
        Me.cboCalendarMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCalendarMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCalendarMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCalendarMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCalendarMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCalendarMonth.FormattingEnabled = True
        Me.cboCalendarMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboCalendarMonth.Location = New System.Drawing.Point(439, 8)
        Me.cboCalendarMonth.Name = "cboCalendarMonth"
        Me.cboCalendarMonth.Size = New System.Drawing.Size(201, 28)
        Me.cboCalendarMonth.TabIndex = 16
        '
        'cboCalendarYear
        '
        Me.cboCalendarYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCalendarYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCalendarYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCalendarYear.FormattingEnabled = True
        Me.cboCalendarYear.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040"})
        Me.cboCalendarYear.Location = New System.Drawing.Point(739, 8)
        Me.cboCalendarYear.Name = "cboCalendarYear"
        Me.cboCalendarYear.Size = New System.Drawing.Size(185, 28)
        Me.cboCalendarYear.TabIndex = 17
        '
        'lblDivisionID
        '
        Me.lblDivisionID.Location = New System.Drawing.Point(16, 28)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(100, 23)
        Me.lblDivisionID.TabIndex = 18
        Me.lblDivisionID.Text = "Division ID"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(122, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(121, 21)
        Me.cboDivisionID.TabIndex = 19
        '
        'gpxFilters
        '
        Me.gpxFilters.Controls.Add(Me.cboEmployee)
        Me.gpxFilters.Controls.Add(Me.Label1)
        Me.gpxFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxFilters.Controls.Add(Me.lblDivisionID)
        Me.gpxFilters.Location = New System.Drawing.Point(14, 42)
        Me.gpxFilters.Margin = New System.Windows.Forms.Padding(5)
        Me.gpxFilters.Name = "gpxFilters"
        Me.gpxFilters.Size = New System.Drawing.Size(251, 126)
        Me.gpxFilters.TabIndex = 20
        Me.gpxFilters.TabStop = False
        Me.gpxFilters.Text = "Filters"
        '
        'cboEmployee
        '
        Me.cboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployee.Enabled = False
        Me.cboEmployee.FormattingEnabled = True
        Me.cboEmployee.Location = New System.Drawing.Point(80, 73)
        Me.cboEmployee.Margin = New System.Windows.Forms.Padding(5)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(163, 21)
        Me.cboEmployee.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 73)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 21)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Employee"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 197)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 134)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Adding/Viewing Notificaitons"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(16, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(224, 59)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "To add or view notifications, right click on the day and then select either Add N" & _
            "otification or Show Notifications."
        '
        'NotificationCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 679)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxFilters)
        Me.Controls.Add(Me.cboCalendarYear)
        Me.Controls.Add(Me.cboCalendarMonth)
        Me.Controls.Add(Me.dgvCalendar)
        Me.Name = "NotificationCalendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notification Calendar"
        CType(Me.dgvCalendar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxFilters.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCalendar As System.Windows.Forms.DataGridView
    Friend WithEvents cboCalendarMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboCalendarYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivisionID As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents gpxFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cboEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
