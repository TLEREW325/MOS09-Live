<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeSlipPosting
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvTimeSlipEntries = New System.Windows.Forms.DataGridView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.TSMenu01 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.grpPostTimeSlip = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdPost = New System.Windows.Forms.Button
        Me.lblDGVMessage = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.bgwkPosting = New System.ComponentModel.BackgroundWorker
        Me.pnlPostingMessage = New System.Windows.Forms.Panel
        Me.lblPostingMessage = New System.Windows.Forms.Label
        Me.tmrPostingMessage = New System.Windows.Forms.Timer(Me.components)
        Me.gpxAccounting = New System.Windows.Forms.GroupBox
        Me.cmdPostSpecial = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdDeleteSelected = New System.Windows.Forms.Button
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgvTimeSlipEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.grpPostTimeSlip.SuspendLayout()
        Me.pnlPostingMessage.SuspendLayout()
        Me.gpxAccounting.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTimeSlipEntries
        '
        Me.dgvTimeSlipEntries.AllowUserToAddRows = False
        Me.dgvTimeSlipEntries.AllowUserToDeleteRows = False
        Me.dgvTimeSlipEntries.AllowUserToResizeColumns = False
        Me.dgvTimeSlipEntries.AllowUserToResizeRows = False
        Me.dgvTimeSlipEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeSlipEntries.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTimeSlipEntries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTimeSlipEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSlipEntries.Location = New System.Drawing.Point(12, 28)
        Me.dgvTimeSlipEntries.MultiSelect = False
        Me.dgvTimeSlipEntries.Name = "dgvTimeSlipEntries"
        Me.dgvTimeSlipEntries.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTimeSlipEntries.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTimeSlipEntries.Size = New System.Drawing.Size(1118, 686)
        Me.dgvTimeSlipEntries.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMenu01, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 80
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TSMenu01
        '
        Me.TSMenu01.Name = "TSMenu01"
        Me.TSMenu01.Size = New System.Drawing.Size(35, 20)
        Me.TSMenu01.Text = "File"
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
        'grpPostTimeSlip
        '
        Me.grpPostTimeSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpPostTimeSlip.Controls.Add(Me.Label16)
        Me.grpPostTimeSlip.Controls.Add(Me.cmdPost)
        Me.grpPostTimeSlip.Location = New System.Drawing.Point(12, 734)
        Me.grpPostTimeSlip.Name = "grpPostTimeSlip"
        Me.grpPostTimeSlip.Size = New System.Drawing.Size(310, 69)
        Me.grpPostTimeSlip.TabIndex = 81
        Me.grpPostTimeSlip.TabStop = False
        Me.grpPostTimeSlip.Text = "Post Time Slips"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(16, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(176, 35)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "No more changes can be made after posting time slips."
        '
        'cmdPost
        '
        Me.cmdPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPost.Enabled = False
        Me.cmdPost.ForeColor = System.Drawing.Color.Blue
        Me.cmdPost.Location = New System.Drawing.Point(222, 16)
        Me.cmdPost.Name = "cmdPost"
        Me.cmdPost.Size = New System.Drawing.Size(71, 40)
        Me.cmdPost.TabIndex = 82
        Me.cmdPost.Text = "Post Time Slips"
        Me.cmdPost.UseVisualStyleBackColor = True
        '
        'lblDGVMessage
        '
        Me.lblDGVMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDGVMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblDGVMessage.Location = New System.Drawing.Point(726, 735)
        Me.lblDGVMessage.Name = "lblDGVMessage"
        Me.lblDGVMessage.Size = New System.Drawing.Size(404, 19)
        Me.lblDGVMessage.TabIndex = 86
        Me.lblDGVMessage.Text = "***All changes made above will automatically be saved.***"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Location = New System.Drawing.Point(1059, 776)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 86
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.Location = New System.Drawing.Point(982, 776)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 87
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'bgwkPosting
        '
        '
        'pnlPostingMessage
        '
        Me.pnlPostingMessage.Controls.Add(Me.lblPostingMessage)
        Me.pnlPostingMessage.Location = New System.Drawing.Point(375, 269)
        Me.pnlPostingMessage.Name = "pnlPostingMessage"
        Me.pnlPostingMessage.Size = New System.Drawing.Size(318, 100)
        Me.pnlPostingMessage.TabIndex = 88
        Me.pnlPostingMessage.Visible = False
        '
        'lblPostingMessage
        '
        Me.lblPostingMessage.AutoSize = True
        Me.lblPostingMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostingMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblPostingMessage.Location = New System.Drawing.Point(83, 42)
        Me.lblPostingMessage.Name = "lblPostingMessage"
        Me.lblPostingMessage.Size = New System.Drawing.Size(127, 16)
        Me.lblPostingMessage.TabIndex = 0
        Me.lblPostingMessage.Text = "Posting please wait."
        '
        'tmrPostingMessage
        '
        Me.tmrPostingMessage.Interval = 1000
        '
        'gpxAccounting
        '
        Me.gpxAccounting.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.gpxAccounting.Controls.Add(Me.cmdPostSpecial)
        Me.gpxAccounting.Controls.Add(Me.Label1)
        Me.gpxAccounting.Location = New System.Drawing.Point(378, 734)
        Me.gpxAccounting.Name = "gpxAccounting"
        Me.gpxAccounting.Size = New System.Drawing.Size(281, 69)
        Me.gpxAccounting.TabIndex = 89
        Me.gpxAccounting.TabStop = False
        Me.gpxAccounting.Text = "Accounting Posting Special"
        Me.gpxAccounting.Visible = False
        '
        'cmdPostSpecial
        '
        Me.cmdPostSpecial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPostSpecial.Enabled = False
        Me.cmdPostSpecial.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostSpecial.Location = New System.Drawing.Point(181, 19)
        Me.cmdPostSpecial.Name = "cmdPostSpecial"
        Me.cmdPostSpecial.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostSpecial.TabIndex = 86
        Me.cmdPostSpecial.Text = "Post Special"
        Me.cmdPostSpecial.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 45)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Posts selected rows to Misc. Adjustment from Inventory Fasteners WIP "
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.LightGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(729, 780)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 90
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(758, 790)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "- Adds to Inventory"
        '
        'cmdDeleteSelected
        '
        Me.cmdDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSelected.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteSelected.Location = New System.Drawing.Point(905, 776)
        Me.cmdDeleteSelected.Name = "cmdDeleteSelected"
        Me.cmdDeleteSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelected.TabIndex = 92
        Me.cmdDeleteSelected.Text = "Delete Selected"
        Me.cmdDeleteSelected.UseVisualStyleBackColor = True
        '
        'TimeSlipPosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdDeleteSelected)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gpxAccounting)
        Me.Controls.Add(Me.pnlPostingMessage)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblDGVMessage)
        Me.Controls.Add(Me.grpPostTimeSlip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvTimeSlipEntries)
        Me.Name = "TimeSlipPosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Slip Posting"
        CType(Me.dgvTimeSlipEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpPostTimeSlip.ResumeLayout(False)
        Me.pnlPostingMessage.ResumeLayout(False)
        Me.pnlPostingMessage.PerformLayout()
        Me.gpxAccounting.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvTimeSlipEntries As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TSMenu01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpPostTimeSlip As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdPost As System.Windows.Forms.Button
    Friend WithEvents lblDGVMessage As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents bgwkPosting As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlPostingMessage As System.Windows.Forms.Panel
    Friend WithEvents lblPostingMessage As System.Windows.Forms.Label
    Friend WithEvents tmrPostingMessage As System.Windows.Forms.Timer
    Friend WithEvents gpxAccounting As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostSpecial As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource

End Class
