<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSteelLinesForReceiving
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
        Me.cmdSaveLines = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvSteelPOLines = New System.Windows.Forms.DataGridView
        Me.selectForReceiving = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.dgvSteelPOLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(89, 326)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 13
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 326)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectAll.TabIndex = 12
        Me.cmdSelectAll.Text = "Check All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSaveLines
        '
        Me.cmdSaveLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLines.Location = New System.Drawing.Point(497, 326)
        Me.cmdSaveLines.Name = "cmdSaveLines"
        Me.cmdSaveLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLines.TabIndex = 11
        Me.cmdSaveLines.Text = "Process For Receiving"
        Me.cmdSaveLines.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(574, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvSteelPOLines
        '
        Me.dgvSteelPOLines.AllowUserToAddRows = False
        Me.dgvSteelPOLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelPOLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSteelPOLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelPOLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelPOLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selectForReceiving})
        Me.dgvSteelPOLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelPOLines.Location = New System.Drawing.Point(12, 6)
        Me.dgvSteelPOLines.Name = "dgvSteelPOLines"
        Me.dgvSteelPOLines.Size = New System.Drawing.Size(633, 310)
        Me.dgvSteelPOLines.TabIndex = 14
        '
        'selectForReceiving
        '
        Me.selectForReceiving.HeaderText = "Select"
        Me.selectForReceiving.Name = "selectForReceiving"
        '
        'SelectSteelLinesForReceiving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.dgvSteelPOLines)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdSaveLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "SelectSteelLinesForReceiving"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select Steel Lines From Purchase Order"
        CType(Me.dgvSteelPOLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLines As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvSteelPOLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiveWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPurchaseLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchasePricePerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelVendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPurchaseOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selectForReceiving As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
