<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeaderSetupSheet
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyFromToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBlueprintNumber = New System.Windows.Forms.ComboBox
        Me.cboMachineNumber = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblFOXNumber = New System.Windows.Forms.Label
        Me.lblCustomer = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblPartDescription = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvHeaderSetupData = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtOperator = New System.Windows.Forms.TextBox
        Me.cboBlueprintRevision = New System.Windows.Forms.ComboBox
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvHeaderSetupData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1034, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyFromToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CopyFromToolStripMenuItem
        '
        Me.CopyFromToolStripMenuItem.Name = "CopyFromToolStripMenuItem"
        Me.CopyFromToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.CopyFromToolStripMenuItem.Text = "Copy From"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(797, 48)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FOX Number"
        '
        'cboBlueprintNumber
        '
        Me.cboBlueprintNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBlueprintNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlueprintNumber.FormattingEnabled = True
        Me.cboBlueprintNumber.Location = New System.Drawing.Point(86, 30)
        Me.cboBlueprintNumber.Name = "cboBlueprintNumber"
        Me.cboBlueprintNumber.Size = New System.Drawing.Size(121, 21)
        Me.cboBlueprintNumber.TabIndex = 0
        '
        'cboMachineNumber
        '
        Me.cboMachineNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMachineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMachineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachineNumber.FormattingEnabled = True
        Me.cboMachineNumber.Location = New System.Drawing.Point(471, 32)
        Me.cboMachineNumber.Name = "cboMachineNumber"
        Me.cboMachineNumber.Size = New System.Drawing.Size(121, 21)
        Me.cboMachineNumber.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(377, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Machine Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Blueprint"
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFOXNumber.Location = New System.Drawing.Point(86, 66)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(121, 22)
        Me.lblFOXNumber.TabIndex = 7
        Me.lblFOXNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomer
        '
        Me.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomer.Location = New System.Drawing.Point(284, 66)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(210, 22)
        Me.lblCustomer.TabIndex = 9
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(227, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Customer"
        '
        'lblPartDescription
        '
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Location = New System.Drawing.Point(15, 120)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Size = New System.Drawing.Size(370, 79)
        Me.lblPartDescription.TabIndex = 11
        Me.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Part Description"
        '
        'dgvHeaderSetupData
        '
        Me.dgvHeaderSetupData.AllowUserToAddRows = False
        Me.dgvHeaderSetupData.AllowUserToDeleteRows = False
        Me.dgvHeaderSetupData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHeaderSetupData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvHeaderSetupData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeaderSetupData.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHeaderSetupData.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHeaderSetupData.Location = New System.Drawing.Point(0, 220)
        Me.dgvHeaderSetupData.MultiSelect = False
        Me.dgvHeaderSetupData.Name = "dgvHeaderSetupData"
        Me.dgvHeaderSetupData.RowHeadersVisible = False
        Me.dgvHeaderSetupData.RowTemplate.Height = 40
        Me.dgvHeaderSetupData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvHeaderSetupData.Size = New System.Drawing.Size(1034, 375)
        Me.dgvHeaderSetupData.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(414, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Comments"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(598, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Date Created"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(417, 120)
        Me.txtComments.MaxLength = 500
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(605, 79)
        Me.txtComments.TabIndex = 4
        '
        'dtpDate
        '
        Me.dtpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(674, 31)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(108, 20)
        Me.dtpDate.TabIndex = 16
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(951, 609)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(874, 48)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(220, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Blueprint Rev."
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(515, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Operator"
        '
        'txtOperator
        '
        Me.txtOperator.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOperator.Location = New System.Drawing.Point(579, 68)
        Me.txtOperator.MaxLength = 30
        Me.txtOperator.Name = "txtOperator"
        Me.txtOperator.Size = New System.Drawing.Size(203, 20)
        Me.txtOperator.TabIndex = 3
        '
        'cboBlueprintRevision
        '
        Me.cboBlueprintRevision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBlueprintRevision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlueprintRevision.FormattingEnabled = True
        Me.cboBlueprintRevision.Location = New System.Drawing.Point(300, 30)
        Me.cboBlueprintRevision.Name = "cboBlueprintRevision"
        Me.cboBlueprintRevision.Size = New System.Drawing.Size(57, 21)
        Me.cboBlueprintRevision.TabIndex = 1
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(874, 609)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 7
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(951, 48)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 22
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'HeaderSetupSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 661)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cboBlueprintRevision)
        Me.Controls.Add(Me.txtOperator)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgvHeaderSetupData)
        Me.Controls.Add(Me.lblPartDescription)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblFOXNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboMachineNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboBlueprintNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "HeaderSetupSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Header Setup Sheet"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvHeaderSetupData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBlueprintNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboMachineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFOXNumber As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPartDescription As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvHeaderSetupData As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOperator As System.Windows.Forms.TextBox
    Friend WithEvents cboBlueprintRevision As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents CopyFromToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
