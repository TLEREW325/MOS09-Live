<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAnnealingLog
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
        Me.gpxVoucherMaintenance = New System.Windows.Forms.GroupBox
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.cboBase = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboProgram = New System.Windows.Forms.ComboBox
        Me.cboAnnealedLot = New System.Windows.Forms.ComboBox
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.lblProgram = New System.Windows.Forms.Label
        Me.lblAnnealedLot = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvAnnealingLog = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.gpxVoucherMaintenance.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvAnnealingLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxVoucherMaintenance
        '
        Me.gpxVoucherMaintenance.Controls.Add(Me.chkAllTypes)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cboBase)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label1)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cboProgram)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cboAnnealedLot)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cboCarbon)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cboHeatNumber)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cboSteelSize)
        Me.gpxVoucherMaintenance.Controls.Add(Me.lblProgram)
        Me.gpxVoucherMaintenance.Controls.Add(Me.lblAnnealedLot)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cmdView)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label6)
        Me.gpxVoucherMaintenance.Controls.Add(Me.cmdClear)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label7)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label2)
        Me.gpxVoucherMaintenance.Location = New System.Drawing.Point(29, 41)
        Me.gpxVoucherMaintenance.Name = "gpxVoucherMaintenance"
        Me.gpxVoucherMaintenance.Size = New System.Drawing.Size(300, 400)
        Me.gpxVoucherMaintenance.TabIndex = 0
        Me.gpxVoucherMaintenance.TabStop = False
        Me.gpxVoucherMaintenance.Text = "View By Filters"
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(116, 106)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 75
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'cboBase
        '
        Me.cboBase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBase.FormattingEnabled = True
        Me.cboBase.Location = New System.Drawing.Point(105, 291)
        Me.cboBase.Name = "cboBase"
        Me.cboBase.Size = New System.Drawing.Size(179, 21)
        Me.cboBase.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 291)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Base"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboProgram
        '
        Me.cboProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProgram.FormattingEnabled = True
        Me.cboProgram.Location = New System.Drawing.Point(105, 242)
        Me.cboProgram.Name = "cboProgram"
        Me.cboProgram.Size = New System.Drawing.Size(179, 21)
        Me.cboProgram.TabIndex = 19
        '
        'cboAnnealedLot
        '
        Me.cboAnnealedLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAnnealedLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAnnealedLot.FormattingEnabled = True
        Me.cboAnnealedLot.Location = New System.Drawing.Point(105, 33)
        Me.cboAnnealedLot.Name = "cboAnnealedLot"
        Me.cboAnnealedLot.Size = New System.Drawing.Size(179, 21)
        Me.cboAnnealedLot.TabIndex = 0
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(105, 77)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(179, 21)
        Me.cboCarbon.TabIndex = 1
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(105, 193)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboHeatNumber.TabIndex = 5
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(105, 146)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(179, 21)
        Me.cboSteelSize.TabIndex = 2
        '
        'lblProgram
        '
        Me.lblProgram.Location = New System.Drawing.Point(14, 242)
        Me.lblProgram.Name = "lblProgram"
        Me.lblProgram.Size = New System.Drawing.Size(100, 20)
        Me.lblProgram.TabIndex = 18
        Me.lblProgram.Text = "Program"
        Me.lblProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAnnealedLot
        '
        Me.lblAnnealedLot.Location = New System.Drawing.Point(14, 32)
        Me.lblAnnealedLot.Name = "lblAnnealedLot"
        Me.lblAnnealedLot.Size = New System.Drawing.Size(100, 20)
        Me.lblAnnealedLot.TabIndex = 17
        Me.lblAnnealedLot.Text = "Annealed Lot"
        Me.lblAnnealedLot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(136, 335)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 6
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Annealed Size"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 335)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 7
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Annealed Carbon"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Heat Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 20
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
        'dgvAnnealingLog
        '
        Me.dgvAnnealingLog.AllowUserToAddRows = False
        Me.dgvAnnealingLog.AllowUserToDeleteRows = False
        Me.dgvAnnealingLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnnealingLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAnnealingLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAnnealingLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAnnealingLog.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAnnealingLog.Location = New System.Drawing.Point(347, 41)
        Me.dgvAnnealingLog.Name = "dgvAnnealingLog"
        Me.dgvAnnealingLog.ReadOnly = True
        Me.dgvAnnealingLog.Size = New System.Drawing.Size(783, 722)
        Me.dgvAnnealingLog.TabIndex = 21
        Me.dgvAnnealingLog.TabStop = False
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(980, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 497)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 266)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Color codes"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(107, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(159, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "- Do Not Use - See Comment"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.LightCoral
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(78, 200)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(107, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "- Hold - See Comment"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Goldenrod
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(78, 152)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(107, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "- Ok - See Comment"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(78, 106)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(107, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "- Ok To Process"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(78, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ViewAnnealingLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvAnnealingLog)
        Me.Controls.Add(Me.gpxVoucherMaintenance)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAnnealingLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Annealing Log"
        Me.gpxVoucherMaintenance.ResumeLayout(False)
        Me.gpxVoucherMaintenance.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvAnnealingLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxVoucherMaintenance As System.Windows.Forms.GroupBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvAnnealingLog As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents CarbonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoundsAnnealedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboAnnealedLot As System.Windows.Forms.ComboBox
    Friend WithEvents lblAnnealedLot As System.Windows.Forms.Label
    Friend WithEvents cboProgram As System.Windows.Forms.ComboBox
    Friend WithEvents lblProgram As System.Windows.Forms.Label
    Friend WithEvents cboBase As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
End Class
