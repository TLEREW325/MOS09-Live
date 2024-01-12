<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SOBrokenBoxForm
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
        Me.rdoBrokenBoxCharge = New System.Windows.Forms.RadioButton
        Me.rdoGoUpOneBox = New System.Windows.Forms.RadioButton
        Me.rdoGoDownOneBox = New System.Windows.Forms.RadioButton
        Me.lblHigher = New System.Windows.Forms.Label
        Me.lblLower = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.rdoNoCharge = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'rdoBrokenBoxCharge
        '
        Me.rdoBrokenBoxCharge.AutoSize = True
        Me.rdoBrokenBoxCharge.Checked = True
        Me.rdoBrokenBoxCharge.Location = New System.Drawing.Point(74, 36)
        Me.rdoBrokenBoxCharge.Name = "rdoBrokenBoxCharge"
        Me.rdoBrokenBoxCharge.Size = New System.Drawing.Size(234, 17)
        Me.rdoBrokenBoxCharge.TabIndex = 0
        Me.rdoBrokenBoxCharge.TabStop = True
        Me.rdoBrokenBoxCharge.Text = "Apply broken box charge to current quantity."
        Me.rdoBrokenBoxCharge.UseVisualStyleBackColor = True
        '
        'rdoGoUpOneBox
        '
        Me.rdoGoUpOneBox.AutoSize = True
        Me.rdoGoUpOneBox.Location = New System.Drawing.Point(74, 72)
        Me.rdoGoUpOneBox.Name = "rdoGoUpOneBox"
        Me.rdoGoUpOneBox.Size = New System.Drawing.Size(202, 17)
        Me.rdoGoUpOneBox.TabIndex = 1
        Me.rdoGoUpOneBox.Text = "Step up to higher even box quantity - "
        Me.rdoGoUpOneBox.UseVisualStyleBackColor = True
        '
        'rdoGoDownOneBox
        '
        Me.rdoGoDownOneBox.AutoSize = True
        Me.rdoGoDownOneBox.Location = New System.Drawing.Point(74, 108)
        Me.rdoGoDownOneBox.Name = "rdoGoDownOneBox"
        Me.rdoGoDownOneBox.Size = New System.Drawing.Size(185, 17)
        Me.rdoGoDownOneBox.TabIndex = 2
        Me.rdoGoDownOneBox.Text = "Step down to lower box quantity - "
        Me.rdoGoDownOneBox.UseVisualStyleBackColor = True
        '
        'lblHigher
        '
        Me.lblHigher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHigher.Location = New System.Drawing.Point(273, 69)
        Me.lblHigher.Name = "lblHigher"
        Me.lblHigher.Size = New System.Drawing.Size(100, 20)
        Me.lblHigher.TabIndex = 3
        Me.lblHigher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLower
        '
        Me.lblLower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLower.Location = New System.Drawing.Point(273, 105)
        Me.lblLower.Name = "lblLower"
        Me.lblLower.Size = New System.Drawing.Size(100, 20)
        Me.lblLower.TabIndex = 4
        Me.lblLower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(336, 159)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'rdoNoCharge
        '
        Me.rdoNoCharge.AutoSize = True
        Me.rdoNoCharge.Location = New System.Drawing.Point(74, 143)
        Me.rdoNoCharge.Name = "rdoNoCharge"
        Me.rdoNoCharge.Size = New System.Drawing.Size(109, 17)
        Me.rdoNoCharge.TabIndex = 6
        Me.rdoNoCharge.TabStop = True
        Me.rdoNoCharge.Text = "No Charge added"
        Me.rdoNoCharge.UseVisualStyleBackColor = True
        '
        'SOBrokenBoxForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 211)
        Me.Controls.Add(Me.rdoNoCharge)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblLower)
        Me.Controls.Add(Me.lblHigher)
        Me.Controls.Add(Me.rdoGoDownOneBox)
        Me.Controls.Add(Me.rdoGoUpOneBox)
        Me.Controls.Add(Me.rdoBrokenBoxCharge)
        Me.Name = "SOBrokenBoxForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Sales Order Broken Box Query"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdoBrokenBoxCharge As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGoUpOneBox As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGoDownOneBox As System.Windows.Forms.RadioButton
    Friend WithEvents lblHigher As System.Windows.Forms.Label
    Friend WithEvents lblLower As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents rdoNoCharge As System.Windows.Forms.RadioButton
End Class
