<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewBlueprintSelectToolingPrint
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
        Me.dgvFiles = New System.Windows.Forms.DataGridView
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdSelect = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        CType(Me.dgvFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFiles
        '
        Me.dgvFiles.AllowUserToAddRows = False
        Me.dgvFiles.AllowUserToDeleteRows = False
        Me.dgvFiles.AllowUserToResizeColumns = False
        Me.dgvFiles.AllowUserToResizeRows = False
        Me.dgvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFiles.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileName})
        Me.dgvFiles.Location = New System.Drawing.Point(12, 12)
        Me.dgvFiles.MultiSelect = False
        Me.dgvFiles.Name = "dgvFiles"
        Me.dgvFiles.RowHeadersVisible = False
        Me.dgvFiles.Size = New System.Drawing.Size(383, 213)
        Me.dgvFiles.TabIndex = 0
        '
        'FileName
        '
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FileName.HeaderText = "File Name"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        '
        'cmdSelect
        '
        Me.cmdSelect.Location = New System.Drawing.Point(324, 231)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelect.TabIndex = 1
        Me.cmdSelect.Text = "Select"
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(12, 231)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'ViewBlueprintSelectToolingPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 283)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.dgvFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ViewBlueprintSelectToolingPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select File"
        CType(Me.dgvFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFiles As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
