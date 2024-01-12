<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewWIPPopup
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
        Me.dgvWIP = New System.Windows.Forms.DataGridView
        Me.pnlNoWIPData = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.dgvWIP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNoWIPData.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvWIP
        '
        Me.dgvWIP.AllowUserToAddRows = False
        Me.dgvWIP.AllowUserToDeleteRows = False
        Me.dgvWIP.AllowUserToResizeColumns = False
        Me.dgvWIP.AllowUserToResizeRows = False
        Me.dgvWIP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWIP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvWIP.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvWIP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvWIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWIP.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWIP.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvWIP.Location = New System.Drawing.Point(0, 0)
        Me.dgvWIP.MultiSelect = False
        Me.dgvWIP.Name = "dgvWIP"
        Me.dgvWIP.ReadOnly = True
        Me.dgvWIP.RowHeadersVisible = False
        Me.dgvWIP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvWIP.Size = New System.Drawing.Size(537, 396)
        Me.dgvWIP.TabIndex = 0
        '
        'pnlNoWIPData
        '
        Me.pnlNoWIPData.BackColor = System.Drawing.Color.White
        Me.pnlNoWIPData.Controls.Add(Me.Label18)
        Me.pnlNoWIPData.Location = New System.Drawing.Point(126, 176)
        Me.pnlNoWIPData.Name = "pnlNoWIPData"
        Me.pnlNoWIPData.Size = New System.Drawing.Size(277, 49)
        Me.pnlNoWIPData.TabIndex = 2
        Me.pnlNoWIPData.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(23, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(220, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "No Pieces currently in WIP"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(466, 402)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ViewWIPPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 446)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.pnlNoWIPData)
        Me.Controls.Add(Me.dgvWIP)
        Me.Name = "ViewWIPPopup"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View WIP"
        CType(Me.dgvWIP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNoWIPData.ResumeLayout(False)
        Me.pnlNoWIPData.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvWIP As System.Windows.Forms.DataGridView
    Friend WithEvents pnlNoWIPData As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
