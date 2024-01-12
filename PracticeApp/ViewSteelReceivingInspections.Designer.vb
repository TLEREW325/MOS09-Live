<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelReceivingInspections
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxFilter = New System.Windows.Forms.GroupBox
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.chkUseDateRange = New System.Windows.Forms.CheckBox
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.cboSteelVendorName = New System.Windows.Forms.ComboBox
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.cboBOLNumber = New System.Windows.Forms.ComboBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.bsrInspection = New System.Windows.Forms.WebBrowser
        Me.pnlLoading = New System.Windows.Forms.Panel
        Me.lblLoadingText = New System.Windows.Forms.Label
        Me.tmrChangeText = New System.Windows.Forms.Timer(Me.components)
        Me.dgvFoundFiles = New System.Windows.Forms.DataGridView
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFilter.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.dgvFoundFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem})
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
        'gpxFilter
        '
        Me.gpxFilter.Controls.Add(Me.cboHeatNumber)
        Me.gpxFilter.Controls.Add(Me.cmdClear)
        Me.gpxFilter.Controls.Add(Me.cmdSearch)
        Me.gpxFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxFilter.Controls.Add(Me.chkUseDateRange)
        Me.gpxFilter.Controls.Add(Me.dtpStartDate)
        Me.gpxFilter.Controls.Add(Me.cboSteelVendorName)
        Me.gpxFilter.Controls.Add(Me.cboSteelVendor)
        Me.gpxFilter.Controls.Add(Me.cboBOLNumber)
        Me.gpxFilter.Controls.Add(Me.cboSteelSize)
        Me.gpxFilter.Controls.Add(Me.cboCarbon)
        Me.gpxFilter.Controls.Add(Me.Label7)
        Me.gpxFilter.Controls.Add(Me.Label4)
        Me.gpxFilter.Controls.Add(Me.Label3)
        Me.gpxFilter.Controls.Add(Me.Label2)
        Me.gpxFilter.Controls.Add(Me.Label1)
        Me.gpxFilter.Controls.Add(Me.Label6)
        Me.gpxFilter.Controls.Add(Me.Label5)
        Me.gpxFilter.Location = New System.Drawing.Point(12, 27)
        Me.gpxFilter.Name = "gpxFilter"
        Me.gpxFilter.Size = New System.Drawing.Size(289, 373)
        Me.gpxFilter.TabIndex = 1
        Me.gpxFilter.TabStop = False
        Me.gpxFilter.Text = "Filter"
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(116, 83)
        Me.cboHeatNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(165, 21)
        Me.cboHeatNumber.TabIndex = 2
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(210, 323)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(133, 323)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(71, 40)
        Me.cmdSearch.TabIndex = 9
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(116, 287)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpEndDate.TabIndex = 8
        '
        'chkUseDateRange
        '
        Me.chkUseDateRange.AutoSize = True
        Me.chkUseDateRange.Location = New System.Drawing.Point(116, 217)
        Me.chkUseDateRange.Name = "chkUseDateRange"
        Me.chkUseDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDateRange.TabIndex = 6
        Me.chkUseDateRange.Text = "Use Date Range"
        Me.chkUseDateRange.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(116, 249)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpStartDate.TabIndex = 7
        '
        'cboSteelVendorName
        '
        Me.cboSteelVendorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendorName.FormattingEnabled = True
        Me.cboSteelVendorName.Location = New System.Drawing.Point(25, 182)
        Me.cboSteelVendorName.Margin = New System.Windows.Forms.Padding(5, 3, 5, 5)
        Me.cboSteelVendorName.Name = "cboSteelVendorName"
        Me.cboSteelVendorName.Size = New System.Drawing.Size(256, 21)
        Me.cboSteelVendorName.TabIndex = 5
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(116, 155)
        Me.cboSteelVendor.Margin = New System.Windows.Forms.Padding(5, 5, 5, 3)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(165, 21)
        Me.cboSteelVendor.TabIndex = 4
        '
        'cboBOLNumber
        '
        Me.cboBOLNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBOLNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBOLNumber.FormattingEnabled = True
        Me.cboBOLNumber.Location = New System.Drawing.Point(116, 114)
        Me.cboBOLNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBOLNumber.Name = "cboBOLNumber"
        Me.cboBOLNumber.Size = New System.Drawing.Size(165, 21)
        Me.cboBOLNumber.TabIndex = 3
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(116, 52)
        Me.cboSteelSize.Margin = New System.Windows.Forms.Padding(5)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(165, 21)
        Me.cboSteelSize.TabIndex = 1
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(116, 21)
        Me.cboCarbon.Margin = New System.Windows.Forms.Padding(5)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(165, 21)
        Me.cboCarbon.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Heat Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Steel Vendor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "BOL Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Size"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Carbon"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(22, 287)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "End Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(22, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Start Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bsrInspection
        '
        Me.bsrInspection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bsrInspection.Location = New System.Drawing.Point(307, 27)
        Me.bsrInspection.MinimumSize = New System.Drawing.Size(20, 20)
        Me.bsrInspection.Name = "bsrInspection"
        Me.bsrInspection.Size = New System.Drawing.Size(715, 772)
        Me.bsrInspection.TabIndex = 2
        '
        'pnlLoading
        '
        Me.pnlLoading.Controls.Add(Me.lblLoadingText)
        Me.pnlLoading.Location = New System.Drawing.Point(510, 290)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(273, 100)
        Me.pnlLoading.TabIndex = 3
        Me.pnlLoading.Visible = False
        '
        'lblLoadingText
        '
        Me.lblLoadingText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblLoadingText.ForeColor = System.Drawing.Color.Blue
        Me.lblLoadingText.Location = New System.Drawing.Point(21, 38)
        Me.lblLoadingText.Name = "lblLoadingText"
        Me.lblLoadingText.Size = New System.Drawing.Size(236, 38)
        Me.lblLoadingText.TabIndex = 0
        Me.lblLoadingText.Text = "Locating entries, please wait."
        '
        'tmrChangeText
        '
        Me.tmrChangeText.Interval = 1000
        '
        'dgvFoundFiles
        '
        Me.dgvFoundFiles.AllowUserToAddRows = False
        Me.dgvFoundFiles.AllowUserToDeleteRows = False
        Me.dgvFoundFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvFoundFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFoundFiles.ColumnHeadersVisible = False
        Me.dgvFoundFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileName})
        Me.dgvFoundFiles.Location = New System.Drawing.Point(12, 428)
        Me.dgvFoundFiles.Name = "dgvFoundFiles"
        Me.dgvFoundFiles.ReadOnly = True
        Me.dgvFoundFiles.RowHeadersVisible = False
        Me.dgvFoundFiles.RowTemplate.Height = 30
        Me.dgvFoundFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFoundFiles.Size = New System.Drawing.Size(281, 371)
        Me.dgvFoundFiles.TabIndex = 4
        '
        'FileName
        '
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FileName.HeaderText = "FileName"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 412)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Found Files"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ViewSteelReceivingInspections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvFoundFiles)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.bsrInspection)
        Me.Controls.Add(Me.gpxFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(1050, 750)
        Me.Name = "ViewSteelReceivingInspections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Receiving Inspections"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFilter.ResumeLayout(False)
        Me.gpxFilter.PerformLayout()
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.dgvFoundFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBOLNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkUseDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSteelVendorName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents bsrInspection As System.Windows.Forms.WebBrowser
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents lblLoadingText As System.Windows.Forms.Label
    Friend WithEvents tmrChangeText As System.Windows.Forms.Timer
    Friend WithEvents dgvFoundFiles As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
