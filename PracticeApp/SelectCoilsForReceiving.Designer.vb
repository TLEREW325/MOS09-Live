<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectCoilsForReceiving
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
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdReceiveCoils = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvCoilsToReceive = New System.Windows.Forms.DataGridView
        Me.selectCoil = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.dgvCoilsToReceive, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cmdReceiveCoils
        '
        Me.cmdReceiveCoils.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReceiveCoils.Location = New System.Drawing.Point(497, 326)
        Me.cmdReceiveCoils.Name = "cmdReceiveCoils"
        Me.cmdReceiveCoils.Size = New System.Drawing.Size(71, 40)
        Me.cmdReceiveCoils.TabIndex = 11
        Me.cmdReceiveCoils.Text = "Process For Receiving"
        Me.cmdReceiveCoils.UseVisualStyleBackColor = True
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
        'dgvCoilsToReceive
        '
        Me.dgvCoilsToReceive.AllowUserToAddRows = False
        Me.dgvCoilsToReceive.AllowUserToDeleteRows = False
        Me.dgvCoilsToReceive.AllowUserToResizeColumns = False
        Me.dgvCoilsToReceive.AllowUserToResizeRows = False
        Me.dgvCoilsToReceive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCoilsToReceive.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCoilsToReceive.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCoilsToReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoilsToReceive.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selectCoil})
        Me.dgvCoilsToReceive.Location = New System.Drawing.Point(12, 12)
        Me.dgvCoilsToReceive.MultiSelect = False
        Me.dgvCoilsToReceive.Name = "dgvCoilsToReceive"
        Me.dgvCoilsToReceive.RowHeadersVisible = False
        Me.dgvCoilsToReceive.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.dgvCoilsToReceive.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCoilsToReceive.Size = New System.Drawing.Size(633, 308)
        Me.dgvCoilsToReceive.TabIndex = 14
        '
        'selectCoil
        '
        Me.selectCoil.HeaderText = "Select Coil"
        Me.selectCoil.Name = "selectCoil"
        '
        'SelectCoilsForReceiving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 378)
        Me.Controls.Add(Me.dgvCoilsToReceive)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdReceiveCoils)
        Me.Controls.Add(Me.cmdExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SelectCoilsForReceiving"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Receiving Lines"
        CType(Me.dgvCoilsToReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdReceiveCoils As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCoilsToReceive As System.Windows.Forms.DataGridView
    Friend WithEvents selectCoil As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
