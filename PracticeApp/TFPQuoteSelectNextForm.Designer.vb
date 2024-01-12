<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TFPQuoteSelectNextForm
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
        Me.cmdCustomerMaintenance = New System.Windows.Forms.Button
        Me.cmdFOXMaintenance = New System.Windows.Forms.Button
        Me.cmdItemMaintenance = New System.Windows.Forms.Button
        Me.lblCustomerMaintenance = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblItemMaintenance = New System.Windows.Forms.Label
        Me.lblFOXCreated = New System.Windows.Forms.Label
        Me.lblPartCreated = New System.Windows.Forms.Label
        Me.lblCustomerCreated = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCustomerMaintenance
        '
        Me.cmdCustomerMaintenance.Location = New System.Drawing.Point(172, 105)
        Me.cmdCustomerMaintenance.Name = "cmdCustomerMaintenance"
        Me.cmdCustomerMaintenance.Size = New System.Drawing.Size(71, 40)
        Me.cmdCustomerMaintenance.TabIndex = 0
        Me.cmdCustomerMaintenance.Text = "Open"
        Me.cmdCustomerMaintenance.UseVisualStyleBackColor = True
        Me.cmdCustomerMaintenance.Visible = False
        '
        'cmdFOXMaintenance
        '
        Me.cmdFOXMaintenance.Location = New System.Drawing.Point(172, 151)
        Me.cmdFOXMaintenance.Name = "cmdFOXMaintenance"
        Me.cmdFOXMaintenance.Size = New System.Drawing.Size(71, 40)
        Me.cmdFOXMaintenance.TabIndex = 1
        Me.cmdFOXMaintenance.Text = "Open"
        Me.cmdFOXMaintenance.UseVisualStyleBackColor = True
        '
        'cmdItemMaintenance
        '
        Me.cmdItemMaintenance.Location = New System.Drawing.Point(172, 197)
        Me.cmdItemMaintenance.Name = "cmdItemMaintenance"
        Me.cmdItemMaintenance.Size = New System.Drawing.Size(71, 40)
        Me.cmdItemMaintenance.TabIndex = 2
        Me.cmdItemMaintenance.Text = "Open"
        Me.cmdItemMaintenance.UseVisualStyleBackColor = True
        '
        'lblCustomerMaintenance
        '
        Me.lblCustomerMaintenance.AutoSize = True
        Me.lblCustomerMaintenance.Location = New System.Drawing.Point(33, 119)
        Me.lblCustomerMaintenance.Name = "lblCustomerMaintenance"
        Me.lblCustomerMaintenance.Size = New System.Drawing.Size(116, 13)
        Me.lblCustomerMaintenance.TabIndex = 3
        Me.lblCustomerMaintenance.Text = "Customer Maintenance"
        Me.lblCustomerMaintenance.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "FOX Maintenance"
        '
        'lblItemMaintenance
        '
        Me.lblItemMaintenance.AutoSize = True
        Me.lblItemMaintenance.Location = New System.Drawing.Point(33, 211)
        Me.lblItemMaintenance.Name = "lblItemMaintenance"
        Me.lblItemMaintenance.Size = New System.Drawing.Size(92, 13)
        Me.lblItemMaintenance.TabIndex = 5
        Me.lblItemMaintenance.Text = "Item Maintenance"
        '
        'lblFOXCreated
        '
        Me.lblFOXCreated.AutoSize = True
        Me.lblFOXCreated.Location = New System.Drawing.Point(33, 62)
        Me.lblFOXCreated.Name = "lblFOXCreated"
        Me.lblFOXCreated.Size = New System.Drawing.Size(68, 13)
        Me.lblFOXCreated.TabIndex = 6
        Me.lblFOXCreated.Text = "FOX Created"
        '
        'lblPartCreated
        '
        Me.lblPartCreated.AutoSize = True
        Me.lblPartCreated.Location = New System.Drawing.Point(33, 49)
        Me.lblPartCreated.Name = "lblPartCreated"
        Me.lblPartCreated.Size = New System.Drawing.Size(66, 13)
        Me.lblPartCreated.TabIndex = 7
        Me.lblPartCreated.Text = "Part Created"
        '
        'lblCustomerCreated
        '
        Me.lblCustomerCreated.AutoSize = True
        Me.lblCustomerCreated.Location = New System.Drawing.Point(33, 36)
        Me.lblCustomerCreated.Name = "lblCustomerCreated"
        Me.lblCustomerCreated.Size = New System.Drawing.Size(91, 13)
        Me.lblCustomerCreated.TabIndex = 8
        Me.lblCustomerCreated.Text = "Customer Created"
        '
        'TFPQuoteSelectNextForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.lblCustomerCreated)
        Me.Controls.Add(Me.lblPartCreated)
        Me.Controls.Add(Me.lblFOXCreated)
        Me.Controls.Add(Me.lblItemMaintenance)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCustomerMaintenance)
        Me.Controls.Add(Me.cmdItemMaintenance)
        Me.Controls.Add(Me.cmdFOXMaintenance)
        Me.Controls.Add(Me.cmdCustomerMaintenance)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TFPQuoteSelectNextForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Next Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCustomerMaintenance As System.Windows.Forms.Button
    Friend WithEvents cmdFOXMaintenance As System.Windows.Forms.Button
    Friend WithEvents cmdItemMaintenance As System.Windows.Forms.Button
    Friend WithEvents lblCustomerMaintenance As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblItemMaintenance As System.Windows.Forms.Label
    Friend WithEvents lblFOXCreated As System.Windows.Forms.Label
    Friend WithEvents lblPartCreated As System.Windows.Forms.Label
    Friend WithEvents lblCustomerCreated As System.Windows.Forms.Label
End Class
