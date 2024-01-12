<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeaderTimeSlipVerification
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
        Me.dgvHeaderTimeSLipEntries = New System.Windows.Forms.DataGridView
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
        CType(Me.dgvHeaderTimeSLipEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.grpPostTimeSlip.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHeaderTimeSLipEntries
        '
        Me.dgvHeaderTimeSLipEntries.AllowUserToAddRows = False
        Me.dgvHeaderTimeSLipEntries.AllowUserToDeleteRows = False
        Me.dgvHeaderTimeSLipEntries.AllowUserToResizeColumns = False
        Me.dgvHeaderTimeSLipEntries.AllowUserToResizeRows = False
        Me.dgvHeaderTimeSLipEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHeaderTimeSLipEntries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHeaderTimeSLipEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeaderTimeSLipEntries.Location = New System.Drawing.Point(12, 27)
        Me.dgvHeaderTimeSLipEntries.MultiSelect = False
        Me.dgvHeaderTimeSLipEntries.Name = "dgvHeaderTimeSLipEntries"
        Me.dgvHeaderTimeSLipEntries.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeaderTimeSLipEntries.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvHeaderTimeSLipEntries.Size = New System.Drawing.Size(1018, 431)
        Me.dgvHeaderTimeSLipEntries.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMenu01, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        Me.grpPostTimeSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPostTimeSlip.Controls.Add(Me.Label16)
        Me.grpPostTimeSlip.Controls.Add(Me.cmdPost)
        Me.grpPostTimeSlip.Location = New System.Drawing.Point(627, 470)
        Me.grpPostTimeSlip.Name = "grpPostTimeSlip"
        Me.grpPostTimeSlip.Size = New System.Drawing.Size(310, 69)
        Me.grpPostTimeSlip.TabIndex = 81
        Me.grpPostTimeSlip.TabStop = False
        Me.grpPostTimeSlip.Text = "Post Time Slips"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(14, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(176, 48)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "No more changes can be made after posting header time slips."
        '
        'cmdPost
        '
        Me.cmdPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.lblDGVMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblDGVMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblDGVMessage.Location = New System.Drawing.Point(266, 470)
        Me.lblDGVMessage.Name = "lblDGVMessage"
        Me.lblDGVMessage.Size = New System.Drawing.Size(321, 33)
        Me.lblDGVMessage.TabIndex = 86
        Me.lblDGVMessage.Text = "***All changes made above will automatically be saved.***"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Location = New System.Drawing.Point(959, 486)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 86
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'HeaderTimeSlipVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 546)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblDGVMessage)
        Me.Controls.Add(Me.grpPostTimeSlip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvHeaderTimeSLipEntries)
        Me.Name = "HeaderTimeSlipVerification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Header Time Slip Verification"
        CType(Me.dgvHeaderTimeSLipEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpPostTimeSlip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvHeaderTimeSLipEntries As System.Windows.Forms.DataGridView
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

End Class
