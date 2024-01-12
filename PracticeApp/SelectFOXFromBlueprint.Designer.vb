<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectFOXFromBlueprint
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
        Me.dgvFoundFOXs = New System.Windows.Forms.DataGridView
        Me.cmdSelect = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.chkShoqwOnlyCurrentRev = New System.Windows.Forms.CheckBox
        CType(Me.dgvFoundFOXs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFoundFOXs
        '
        Me.dgvFoundFOXs.AllowUserToAddRows = False
        Me.dgvFoundFOXs.AllowUserToDeleteRows = False
        Me.dgvFoundFOXs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFoundFOXs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFoundFOXs.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFoundFOXs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFoundFOXs.Location = New System.Drawing.Point(1, 1)
        Me.dgvFoundFOXs.Name = "dgvFoundFOXs"
        Me.dgvFoundFOXs.ReadOnly = True
        Me.dgvFoundFOXs.Size = New System.Drawing.Size(578, 260)
        Me.dgvFoundFOXs.TabIndex = 0
        '
        'cmdSelect
        '
        Me.cmdSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelect.Location = New System.Drawing.Point(419, 272)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelect.TabIndex = 6
        Me.cmdSelect.Text = "Select"
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(496, 272)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkShoqwOnlyCurrentRev
        '
        Me.chkShoqwOnlyCurrentRev.AutoSize = True
        Me.chkShoqwOnlyCurrentRev.Checked = True
        Me.chkShoqwOnlyCurrentRev.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShoqwOnlyCurrentRev.Location = New System.Drawing.Point(67, 285)
        Me.chkShoqwOnlyCurrentRev.Name = "chkShoqwOnlyCurrentRev"
        Me.chkShoqwOnlyCurrentRev.Size = New System.Drawing.Size(158, 17)
        Me.chkShoqwOnlyCurrentRev.TabIndex = 8
        Me.chkShoqwOnlyCurrentRev.Text = "Show Only Current Revision"
        Me.chkShoqwOnlyCurrentRev.UseVisualStyleBackColor = True
        '
        'SelectFOXFromBlueprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 324)
        Me.Controls.Add(Me.chkShoqwOnlyCurrentRev)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.dgvFoundFOXs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "SelectFOXFromBlueprint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select FOX From Blueprint"
        CType(Me.dgvFoundFOXs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFoundFOXs As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkShoqwOnlyCurrentRev As System.Windows.Forms.CheckBox
End Class
