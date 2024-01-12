<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelVendorReturnSelectReceiverLines
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
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdAddLines = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.dgvReturnLines = New System.Windows.Forms.DataGridView
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.dgvReturnLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(101, 333)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(70, 40)
        Me.cmdClearAll.TabIndex = 9
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 333)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(70, 40)
        Me.cmdSelectAll.TabIndex = 8
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdAddLines
        '
        Me.cmdAddLines.Location = New System.Drawing.Point(570, 332)
        Me.cmdAddLines.Name = "cmdAddLines"
        Me.cmdAddLines.Size = New System.Drawing.Size(70, 40)
        Me.cmdAddLines.TabIndex = 7
        Me.cmdAddLines.Text = "Add Lines"
        Me.cmdAddLines.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(646, 332)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 40)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'dgvReturnLines
        '
        Me.dgvReturnLines.AllowUserToAddRows = False
        Me.dgvReturnLines.AllowUserToDeleteRows = False
        Me.dgvReturnLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturnLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected})
        Me.dgvReturnLines.Location = New System.Drawing.Point(12, 12)
        Me.dgvReturnLines.Name = "dgvReturnLines"
        Me.dgvReturnLines.Size = New System.Drawing.Size(704, 314)
        Me.dgvReturnLines.TabIndex = 5
        '
        'Selected
        '
        Me.Selected.HeaderText = "Selected"
        Me.Selected.Name = "Selected"
        '
        'SteelVendorReturnSelectReceiverLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 377)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdAddLines)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.dgvReturnLines)
        Me.Name = "SteelVendorReturnSelectReceiverLines"
        Me.Text = "SteelVendorReturnSelectReceiverLines"
        CType(Me.dgvReturnLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdAddLines As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents dgvReturnLines As System.Windows.Forms.DataGridView
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
