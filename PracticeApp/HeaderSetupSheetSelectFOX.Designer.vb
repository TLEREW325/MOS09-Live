<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeaderSetupSheetSelectFOX
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
        Me.dgvFOXes = New System.Windows.Forms.DataGridView
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        CType(Me.dgvFOXes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFOXes
        '
        Me.dgvFOXes.AllowUserToAddRows = False
        Me.dgvFOXes.AllowUserToDeleteRows = False
        Me.dgvFOXes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFOXes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFOXes.Location = New System.Drawing.Point(3, 2)
        Me.dgvFOXes.MultiSelect = False
        Me.dgvFOXes.Name = "dgvFOXes"
        Me.dgvFOXes.ReadOnly = True
        Me.dgvFOXes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFOXes.Size = New System.Drawing.Size(580, 290)
        Me.dgvFOXes.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(502, 303)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad.Location = New System.Drawing.Point(425, 303)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoad.TabIndex = 2
        Me.cmdLoad.Text = "Load Selected"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'HeaderSetupSheetSelectFOX
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 355)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.dgvFOXes)
        Me.Name = "HeaderSetupSheetSelectFOX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select FOX"
        CType(Me.dgvFOXes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFOXes As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
End Class
