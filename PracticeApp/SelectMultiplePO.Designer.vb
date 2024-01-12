<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectMultiplePO
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
        Me.dgvSelectedPO = New System.Windows.Forms.DataGridView
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.cmdUncheckAll = New System.Windows.Forms.Button
        Me.SelectPO = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PONumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvSelectedPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSelectedPO
        '
        Me.dgvSelectedPO.AllowUserToAddRows = False
        Me.dgvSelectedPO.AllowUserToDeleteRows = False
        Me.dgvSelectedPO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSelectedPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelectedPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectPO, Me.PONumber})
        Me.dgvSelectedPO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvSelectedPO.Location = New System.Drawing.Point(12, 12)
        Me.dgvSelectedPO.Name = "dgvSelectedPO"
        Me.dgvSelectedPO.Size = New System.Drawing.Size(302, 294)
        Me.dgvSelectedPO.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(243, 309)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(166, 309)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckAll.Location = New System.Drawing.Point(12, 309)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdCheckAll.TabIndex = 3
        Me.cmdCheckAll.Text = "Check All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdUncheckAll
        '
        Me.cmdUncheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUncheckAll.Location = New System.Drawing.Point(89, 309)
        Me.cmdUncheckAll.Name = "cmdUncheckAll"
        Me.cmdUncheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdUncheckAll.TabIndex = 4
        Me.cmdUncheckAll.Text = "Uncheck All"
        Me.cmdUncheckAll.UseVisualStyleBackColor = True
        '
        'SelectPO
        '
        Me.SelectPO.FalseValue = "False"
        Me.SelectPO.HeaderText = "Select PO"
        Me.SelectPO.Name = "SelectPO"
        Me.SelectPO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SelectPO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SelectPO.TrueValue = "True"
        '
        'PONumber
        '
        Me.PONumber.HeaderText = "PO Number"
        Me.PONumber.Name = "PONumber"
        Me.PONumber.ReadOnly = True
        '
        'SelectMultiplePO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 361)
        Me.Controls.Add(Me.cmdUncheckAll)
        Me.Controls.Add(Me.cmdCheckAll)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.dgvSelectedPO)
        Me.Name = "SelectMultiplePO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Multiple PO"
        CType(Me.dgvSelectedPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSelectedPO As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdUncheckAll As System.Windows.Forms.Button
    Friend WithEvents SelectPO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PONumber As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
