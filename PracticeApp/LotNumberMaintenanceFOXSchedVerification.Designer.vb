<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotNumberMaintenanceFOXSchedVerification
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
        Dim Label54 As System.Windows.Forms.Label
        Dim Label55 As System.Windows.Forms.Label
        Dim Label58 As System.Windows.Forms.Label
        Dim Label36 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.dgvFOXRouting = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFOXNumber = New System.Windows.Forms.Label
        Me.gpxEditFOXProcesses = New System.Windows.Forms.GroupBox
        Me.cmdDeleteProcess = New System.Windows.Forms.Button
        Me.txtMachineDescription = New System.Windows.Forms.TextBox
        Me.cmdGenerateProcessStep = New System.Windows.Forms.Button
        Me.txtProcessStep = New System.Windows.Forms.TextBox
        Me.cboProcessID = New System.Windows.Forms.ComboBox
        Me.cmdAddProcess = New System.Windows.Forms.Button
        Me.chkAddToFinishedGoods = New System.Windows.Forms.CheckBox
        Label54 = New System.Windows.Forms.Label
        Label55 = New System.Windows.Forms.Label
        Label58 = New System.Windows.Forms.Label
        Label36 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgvFOXRouting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxEditFOXProcesses.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label54
        '
        Label54.ForeColor = System.Drawing.Color.Blue
        Label54.Location = New System.Drawing.Point(17, 358)
        Label54.Name = "Label54"
        Label54.Size = New System.Drawing.Size(192, 40)
        Label54.TabIndex = 58
        Label54.Text = "To DELETE - Select Process in datagrid and press ""DELETE"""
        Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label55
        '
        Label55.ForeColor = System.Drawing.Color.Blue
        Label55.Location = New System.Drawing.Point(55, 218)
        Label55.Name = "Label55"
        Label55.Size = New System.Drawing.Size(238, 40)
        Label55.TabIndex = 59
        Label55.Text = "Check this box if process adds to finished goods. Only one process in the FOX may" & _
            " do this."
        Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label58
        '
        Label58.ForeColor = System.Drawing.Color.Blue
        Label58.Location = New System.Drawing.Point(17, 316)
        Label58.Name = "Label58"
        Label58.Size = New System.Drawing.Size(276, 32)
        Label58.TabIndex = 62
        Label58.Text = "Changes made in the datagrid are automatically saved."
        Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Label36.Location = New System.Drawing.Point(17, 64)
        Label36.Name = "Label36"
        Label36.Size = New System.Drawing.Size(127, 20)
        Label36.TabIndex = 57
        Label36.Text = "Process ID"
        Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Label2.Location = New System.Drawing.Point(17, 32)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(127, 20)
        Label2.TabIndex = 55
        Label2.Text = "Process Step"
        Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(548, 383)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "Verified"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(625, 383)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'dgvFOXRouting
        '
        Me.dgvFOXRouting.AllowUserToAddRows = False
        Me.dgvFOXRouting.AllowUserToDeleteRows = False
        Me.dgvFOXRouting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFOXRouting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFOXRouting.Location = New System.Drawing.Point(323, 12)
        Me.dgvFOXRouting.Name = "dgvFOXRouting"
        Me.dgvFOXRouting.Size = New System.Drawing.Size(373, 365)
        Me.dgvFOXRouting.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(343, 387)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "FOX #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOXNumber.Location = New System.Drawing.Point(397, 387)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(100, 23)
        Me.lblFOXNumber.TabIndex = 5
        Me.lblFOXNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxEditFOXProcesses
        '
        Me.gpxEditFOXProcesses.Controls.Add(Me.cmdDeleteProcess)
        Me.gpxEditFOXProcesses.Controls.Add(Me.txtMachineDescription)
        Me.gpxEditFOXProcesses.Controls.Add(Label54)
        Me.gpxEditFOXProcesses.Controls.Add(Me.cmdGenerateProcessStep)
        Me.gpxEditFOXProcesses.Controls.Add(Label55)
        Me.gpxEditFOXProcesses.Controls.Add(Me.txtProcessStep)
        Me.gpxEditFOXProcesses.Controls.Add(Me.cboProcessID)
        Me.gpxEditFOXProcesses.Controls.Add(Label58)
        Me.gpxEditFOXProcesses.Controls.Add(Label36)
        Me.gpxEditFOXProcesses.Controls.Add(Me.cmdAddProcess)
        Me.gpxEditFOXProcesses.Controls.Add(Label2)
        Me.gpxEditFOXProcesses.Controls.Add(Me.chkAddToFinishedGoods)
        Me.gpxEditFOXProcesses.Location = New System.Drawing.Point(12, 12)
        Me.gpxEditFOXProcesses.Name = "gpxEditFOXProcesses"
        Me.gpxEditFOXProcesses.Size = New System.Drawing.Size(305, 414)
        Me.gpxEditFOXProcesses.TabIndex = 15
        Me.gpxEditFOXProcesses.TabStop = False
        Me.gpxEditFOXProcesses.Text = "FOX Processes ADD/DELETE"
        '
        'cmdDeleteProcess
        '
        Me.cmdDeleteProcess.Location = New System.Drawing.Point(222, 362)
        Me.cmdDeleteProcess.Name = "cmdDeleteProcess"
        Me.cmdDeleteProcess.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteProcess.TabIndex = 20
        Me.cmdDeleteProcess.Text = "Delete Process"
        Me.cmdDeleteProcess.UseVisualStyleBackColor = True
        '
        'txtMachineDescription
        '
        Me.txtMachineDescription.BackColor = System.Drawing.SystemColors.Control
        Me.txtMachineDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineDescription.Location = New System.Drawing.Point(20, 106)
        Me.txtMachineDescription.Multiline = True
        Me.txtMachineDescription.Name = "txtMachineDescription"
        Me.txtMachineDescription.ReadOnly = True
        Me.txtMachineDescription.Size = New System.Drawing.Size(273, 79)
        Me.txtMachineDescription.TabIndex = 32
        '
        'cmdGenerateProcessStep
        '
        Me.cmdGenerateProcessStep.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateProcessStep.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateProcessStep.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateProcessStep.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateProcessStep.Location = New System.Drawing.Point(99, 32)
        Me.cmdGenerateProcessStep.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateProcessStep.Name = "cmdGenerateProcessStep"
        Me.cmdGenerateProcessStep.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateProcessStep.TabIndex = 14
        Me.cmdGenerateProcessStep.TabStop = False
        Me.cmdGenerateProcessStep.Text = ">>"
        Me.cmdGenerateProcessStep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateProcessStep.UseVisualStyleBackColor = False
        '
        'txtProcessStep
        '
        Me.txtProcessStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessStep.Location = New System.Drawing.Point(131, 32)
        Me.txtProcessStep.Name = "txtProcessStep"
        Me.txtProcessStep.Size = New System.Drawing.Size(162, 20)
        Me.txtProcessStep.TabIndex = 15
        Me.txtProcessStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboProcessID
        '
        Me.cboProcessID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProcessID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProcessID.FormattingEnabled = True
        Me.cboProcessID.Location = New System.Drawing.Point(99, 64)
        Me.cboProcessID.Name = "cboProcessID"
        Me.cboProcessID.Size = New System.Drawing.Size(194, 21)
        Me.cboProcessID.TabIndex = 16
        '
        'cmdAddProcess
        '
        Me.cmdAddProcess.Location = New System.Drawing.Point(222, 269)
        Me.cmdAddProcess.Name = "cmdAddProcess"
        Me.cmdAddProcess.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddProcess.TabIndex = 18
        Me.cmdAddProcess.Text = "Add Process"
        Me.cmdAddProcess.UseVisualStyleBackColor = True
        '
        'chkAddToFinishedGoods
        '
        Me.chkAddToFinishedGoods.AutoSize = True
        Me.chkAddToFinishedGoods.Location = New System.Drawing.Point(156, 198)
        Me.chkAddToFinishedGoods.Name = "chkAddToFinishedGoods"
        Me.chkAddToFinishedGoods.Size = New System.Drawing.Size(137, 17)
        Me.chkAddToFinishedGoods.TabIndex = 17
        Me.chkAddToFinishedGoods.Text = "Add To Finished Goods"
        Me.chkAddToFinishedGoods.UseVisualStyleBackColor = True
        '
        'LotNumberMaintenanceFOXSchedVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 435)
        Me.Controls.Add(Me.gpxEditFOXProcesses)
        Me.Controls.Add(Me.lblFOXNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvFOXRouting)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "LotNumberMaintenanceFOXSchedVerification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FOX Sched Verification"
        CType(Me.dgvFOXRouting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxEditFOXProcesses.ResumeLayout(False)
        Me.gpxEditFOXProcesses.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents dgvFOXRouting As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFOXNumber As System.Windows.Forms.Label
    Friend WithEvents gpxEditFOXProcesses As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteProcess As System.Windows.Forms.Button
    Friend WithEvents txtMachineDescription As System.Windows.Forms.TextBox
    Friend WithEvents cmdGenerateProcessStep As System.Windows.Forms.Button
    Friend WithEvents txtProcessStep As System.Windows.Forms.TextBox
    Friend WithEvents cboProcessID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAddProcess As System.Windows.Forms.Button
    Friend WithEvents chkAddToFinishedGoods As System.Windows.Forms.CheckBox
End Class
