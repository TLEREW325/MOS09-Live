<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewFOXInspectionEntries
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
        Me.grpFilters = New System.Windows.Forms.GroupBox
        Me.chkDaily = New System.Windows.Forms.CheckBox
        Me.cboEndingTime = New System.Windows.Forms.ComboBox
        Me.cboBeginningTime = New System.Windows.Forms.ComboBox
        Me.cboOperator = New System.Windows.Forms.ComboBox
        Me.lblOperator = New System.Windows.Forms.Label
        Me.lblBeginningTime = New System.Windows.Forms.Label
        Me.lblEndingTime = New System.Windows.Forms.Label
        Me.dtpEndingDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndingDate = New System.Windows.Forms.Label
        Me.lblBeginningDate = New System.Windows.Forms.Label
        Me.dtpBeginningDate = New System.Windows.Forms.DateTimePicker
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboMachine = New System.Windows.Forms.ComboBox
        Me.lblMachine = New System.Windows.Forms.Label
        Me.cboFOX = New System.Windows.Forms.ComboBox
        Me.lblFOX = New System.Windows.Forms.Label
        Me.dgvEntries = New System.Windows.Forms.DataGridView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.bgFoxLoad = New System.ComponentModel.BackgroundWorker
        Me.bgMachineLoad = New System.ComponentModel.BackgroundWorker
        Me.bgOperatorLoad = New System.ComponentModel.BackgroundWorker
        Me.cmdExit = New System.Windows.Forms.Button
        Me.lblRed = New System.Windows.Forms.Label
        Me.txtGreen = New System.Windows.Forms.TextBox
        Me.txtRed = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpFilters.SuspendLayout()
        CType(Me.dgvEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.chkDaily)
        Me.grpFilters.Controls.Add(Me.cboEndingTime)
        Me.grpFilters.Controls.Add(Me.cboBeginningTime)
        Me.grpFilters.Controls.Add(Me.cboOperator)
        Me.grpFilters.Controls.Add(Me.lblOperator)
        Me.grpFilters.Controls.Add(Me.lblBeginningTime)
        Me.grpFilters.Controls.Add(Me.lblEndingTime)
        Me.grpFilters.Controls.Add(Me.dtpEndingDate)
        Me.grpFilters.Controls.Add(Me.lblEndingDate)
        Me.grpFilters.Controls.Add(Me.lblBeginningDate)
        Me.grpFilters.Controls.Add(Me.dtpBeginningDate)
        Me.grpFilters.Controls.Add(Me.cmdView)
        Me.grpFilters.Controls.Add(Me.cmdClear)
        Me.grpFilters.Controls.Add(Me.cboMachine)
        Me.grpFilters.Controls.Add(Me.lblMachine)
        Me.grpFilters.Controls.Add(Me.cboFOX)
        Me.grpFilters.Controls.Add(Me.lblFOX)
        Me.grpFilters.Location = New System.Drawing.Point(29, 41)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(300, 356)
        Me.grpFilters.TabIndex = 0
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "View By Filters"
        '
        'chkDaily
        '
        Me.chkDaily.AutoSize = True
        Me.chkDaily.Location = New System.Drawing.Point(110, 221)
        Me.chkDaily.Name = "chkDaily"
        Me.chkDaily.Size = New System.Drawing.Size(49, 17)
        Me.chkDaily.TabIndex = 6
        Me.chkDaily.Text = "Daily"
        Me.chkDaily.UseVisualStyleBackColor = True
        '
        'cboEndingTime
        '
        Me.cboEndingTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEndingTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEndingTime.FormattingEnabled = True
        Me.cboEndingTime.Items.AddRange(New Object() {"12:00AM", "1:00AM", "2:00AM", "3:00AM", "4:00AM", "5:00AM", "6:00AM", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00PM", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "7:00PM", "8:00PM", "9:00PM", "10:00PM", "11:00PM"})
        Me.cboEndingTime.Location = New System.Drawing.Point(110, 188)
        Me.cboEndingTime.Name = "cboEndingTime"
        Me.cboEndingTime.Size = New System.Drawing.Size(174, 21)
        Me.cboEndingTime.TabIndex = 5
        '
        'cboBeginningTime
        '
        Me.cboBeginningTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBeginningTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBeginningTime.FormattingEnabled = True
        Me.cboBeginningTime.Items.AddRange(New Object() {"12:00AM", "1:00AM", "2:00AM", "3:00AM", "4:00AM", "5:00AM", "6:00AM", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00PM", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "7:00PM", "8:00PM", "9:00PM", "10:00PM", "11:00PM"})
        Me.cboBeginningTime.Location = New System.Drawing.Point(110, 155)
        Me.cboBeginningTime.Name = "cboBeginningTime"
        Me.cboBeginningTime.Size = New System.Drawing.Size(174, 21)
        Me.cboBeginningTime.TabIndex = 4
        '
        'cboOperator
        '
        Me.cboOperator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOperator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOperator.FormattingEnabled = True
        Me.cboOperator.Location = New System.Drawing.Point(110, 250)
        Me.cboOperator.Name = "cboOperator"
        Me.cboOperator.Size = New System.Drawing.Size(174, 21)
        Me.cboOperator.TabIndex = 7
        '
        'lblOperator
        '
        Me.lblOperator.Location = New System.Drawing.Point(6, 251)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(100, 20)
        Me.lblOperator.TabIndex = 30
        Me.lblOperator.Text = "Operator"
        Me.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeginningTime
        '
        Me.lblBeginningTime.Location = New System.Drawing.Point(6, 154)
        Me.lblBeginningTime.Name = "lblBeginningTime"
        Me.lblBeginningTime.Size = New System.Drawing.Size(100, 20)
        Me.lblBeginningTime.TabIndex = 29
        Me.lblBeginningTime.Text = "Beginning Time"
        Me.lblBeginningTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndingTime
        '
        Me.lblEndingTime.Location = New System.Drawing.Point(6, 186)
        Me.lblEndingTime.Name = "lblEndingTime"
        Me.lblEndingTime.Size = New System.Drawing.Size(100, 20)
        Me.lblEndingTime.TabIndex = 28
        Me.lblEndingTime.Text = "Ending Time"
        Me.lblEndingTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndingDate.Location = New System.Drawing.Point(110, 123)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.Size = New System.Drawing.Size(174, 20)
        Me.dtpEndingDate.TabIndex = 3
        '
        'lblEndingDate
        '
        Me.lblEndingDate.Location = New System.Drawing.Point(6, 122)
        Me.lblEndingDate.Name = "lblEndingDate"
        Me.lblEndingDate.Size = New System.Drawing.Size(100, 20)
        Me.lblEndingDate.TabIndex = 24
        Me.lblEndingDate.Text = "Ending Date"
        Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.Location = New System.Drawing.Point(6, 90)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(100, 20)
        Me.lblBeginningDate.TabIndex = 23
        Me.lblBeginningDate.Text = "Beginning Date"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginningDate.Location = New System.Drawing.Point(110, 91)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.Size = New System.Drawing.Size(174, 20)
        Me.dtpBeginningDate.TabIndex = 2
        '
        'cmdView
        '
        Me.cmdView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdView.Location = New System.Drawing.Point(136, 296)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 8
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(213, 296)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboMachine
        '
        Me.cboMachine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMachine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachine.FormattingEnabled = True
        Me.cboMachine.Location = New System.Drawing.Point(110, 58)
        Me.cboMachine.Name = "cboMachine"
        Me.cboMachine.Size = New System.Drawing.Size(175, 21)
        Me.cboMachine.TabIndex = 1
        '
        'lblMachine
        '
        Me.lblMachine.Location = New System.Drawing.Point(6, 58)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(100, 20)
        Me.lblMachine.TabIndex = 2
        Me.lblMachine.Text = "Machine"
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOX
        '
        Me.cboFOX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOX.FormattingEnabled = True
        Me.cboFOX.Location = New System.Drawing.Point(110, 25)
        Me.cboFOX.Name = "cboFOX"
        Me.cboFOX.Size = New System.Drawing.Size(175, 21)
        Me.cboFOX.TabIndex = 0
        '
        'lblFOX
        '
        Me.lblFOX.Location = New System.Drawing.Point(6, 26)
        Me.lblFOX.Name = "lblFOX"
        Me.lblFOX.Size = New System.Drawing.Size(100, 20)
        Me.lblFOX.TabIndex = 0
        Me.lblFOX.Text = "FOX"
        Me.lblFOX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvEntries
        '
        Me.dgvEntries.AllowUserToAddRows = False
        Me.dgvEntries.AllowUserToDeleteRows = False
        Me.dgvEntries.AllowUserToResizeColumns = False
        Me.dgvEntries.AllowUserToResizeRows = False
        Me.dgvEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEntries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvEntries.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvEntries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEntries.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEntries.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvEntries.Location = New System.Drawing.Point(346, 27)
        Me.dgvEntries.MultiSelect = False
        Me.dgvEntries.Name = "dgvEntries"
        Me.dgvEntries.ReadOnly = True
        Me.dgvEntries.RowHeadersVisible = False
        Me.dgvEntries.RowTemplate.ReadOnly = True
        Me.dgvEntries.Size = New System.Drawing.Size(696, 680)
        Me.dgvEntries.TabIndex = 1
        Me.dgvEntries.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        'bgFoxLoad
        '
        '
        'bgMachineLoad
        '
        '
        'bgOperatorLoad
        '
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'lblRed
        '
        Me.lblRed.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblRed.AutoSize = True
        Me.lblRed.Location = New System.Drawing.Point(603, 739)
        Me.lblRed.Name = "lblRed"
        Me.lblRed.Size = New System.Drawing.Size(90, 13)
        Me.lblRed.TabIndex = 3
        Me.lblRed.Text = "- Within tolerance"
        Me.lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtGreen
        '
        Me.txtGreen.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtGreen.BackColor = System.Drawing.Color.LightGreen
        Me.txtGreen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGreen.Location = New System.Drawing.Point(577, 735)
        Me.txtGreen.Multiline = True
        Me.txtGreen.Name = "txtGreen"
        Me.txtGreen.Size = New System.Drawing.Size(20, 20)
        Me.txtGreen.TabIndex = 4
        '
        'txtRed
        '
        Me.txtRed.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtRed.BackColor = System.Drawing.Color.LightCoral
        Me.txtRed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRed.Location = New System.Drawing.Point(738, 735)
        Me.txtRed.Multiline = True
        Me.txtRed.Name = "txtRed"
        Me.txtRed.Size = New System.Drawing.Size(20, 20)
        Me.txtRed.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(764, 739)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "- Out of tolerance"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ViewFOXInspectionEntries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.txtRed)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGreen)
        Me.Controls.Add(Me.lblRed)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvEntries)
        Me.Controls.Add(Me.grpFilters)
        Me.Name = "ViewFOXInspectionEntries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View FOX Inspection Entries"
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        CType(Me.dgvEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEntries As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboMachine As System.Windows.Forms.ComboBox
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents cboFOX As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOX As System.Windows.Forms.Label
    Friend WithEvents dtpEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndingDate As System.Windows.Forms.Label
    Friend WithEvents lblBeginningDate As System.Windows.Forms.Label
    Friend WithEvents dtpBeginningDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBeginningTime As System.Windows.Forms.Label
    Friend WithEvents lblEndingTime As System.Windows.Forms.Label
    Friend WithEvents lblOperator As System.Windows.Forms.Label
    Friend WithEvents cboOperator As System.Windows.Forms.ComboBox
    Friend WithEvents bgFoxLoad As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgMachineLoad As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgOperatorLoad As System.ComponentModel.BackgroundWorker
    Friend WithEvents cboEndingTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboBeginningTime As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents chkDaily As System.Windows.Forms.CheckBox
    Friend WithEvents lblRed As System.Windows.Forms.Label
    Friend WithEvents txtGreen As System.Windows.Forms.TextBox
    Friend WithEvents txtRed As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class