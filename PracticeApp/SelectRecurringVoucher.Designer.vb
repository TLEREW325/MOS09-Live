<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectRecurringVoucher
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
        Me.dgvSelectLines = New System.Windows.Forms.DataGridView
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdAddToBatch = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.dgvSelectLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSelectLines
        '
        Me.dgvSelectLines.AllowUserToAddRows = False
        Me.dgvSelectLines.AllowUserToDeleteRows = False
        Me.dgvSelectLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSelectLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSelectLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSelectLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelectLines.Location = New System.Drawing.Point(12, 12)
        Me.dgvSelectLines.MultiSelect = False
        Me.dgvSelectLines.Name = "dgvSelectLines"
        Me.dgvSelectLines.RowHeadersVisible = False
        Me.dgvSelectLines.Size = New System.Drawing.Size(633, 305)
        Me.dgvSelectLines.TabIndex = 0
        Me.dgvSelectLines.TabStop = False
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(89, 326)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 17
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 326)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 16
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdAddToBatch
        '
        Me.cmdAddToBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddToBatch.Location = New System.Drawing.Point(497, 326)
        Me.cmdAddToBatch.Name = "cmdAddToBatch"
        Me.cmdAddToBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddToBatch.TabIndex = 15
        Me.cmdAddToBatch.Text = "Add To Batch"
        Me.cmdAddToBatch.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(574, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SelectRecurringVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdAddToBatch)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSelectLines)
        Me.Name = "SelectRecurringVoucher"
        Me.Text = "Select Recurring Voucher"
        CType(Me.dgvSelectLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSelectLines As System.Windows.Forms.DataGridView
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdAddToBatch As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button

End Class
