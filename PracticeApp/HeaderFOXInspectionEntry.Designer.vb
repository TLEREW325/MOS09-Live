<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeaderFOXInspectionEntry
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
        Me.lblMeasurement = New System.Windows.Forms.Label
        Me.txtMeasurement = New System.Windows.Forms.TextBox
        Me.cmdSubmit = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdGo = New System.Windows.Forms.Button
        Me.cmdNoGo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblMeasurement
        '
        Me.lblMeasurement.AutoSize = True
        Me.lblMeasurement.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeasurement.Location = New System.Drawing.Point(12, 27)
        Me.lblMeasurement.Name = "lblMeasurement"
        Me.lblMeasurement.Size = New System.Drawing.Size(153, 18)
        Me.lblMeasurement.TabIndex = 0
        Me.lblMeasurement.Text = "Sample Measurement"
        '
        'txtMeasurement
        '
        Me.txtMeasurement.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeasurement.Location = New System.Drawing.Point(171, 24)
        Me.txtMeasurement.Name = "txtMeasurement"
        Me.txtMeasurement.Size = New System.Drawing.Size(150, 24)
        Me.txtMeasurement.TabIndex = 0
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(80, 54)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(99, 60)
        Me.cmdSubmit.TabIndex = 1
        Me.cmdSubmit.Text = "Submit"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(222, 54)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(99, 60)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdGo
        '
        Me.cmdGo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGo.Location = New System.Drawing.Point(10, 24)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(99, 60)
        Me.cmdGo.TabIndex = 0
        Me.cmdGo.Text = "Go"
        Me.cmdGo.UseVisualStyleBackColor = True
        Me.cmdGo.Visible = False
        '
        'cmdNoGo
        '
        Me.cmdNoGo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdNoGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNoGo.Location = New System.Drawing.Point(115, 24)
        Me.cmdNoGo.Name = "cmdNoGo"
        Me.cmdNoGo.Size = New System.Drawing.Size(99, 60)
        Me.cmdNoGo.TabIndex = 1
        Me.cmdNoGo.Text = "NoGo"
        Me.cmdNoGo.UseVisualStyleBackColor = True
        Me.cmdNoGo.Visible = False
        '
        'HeaderFOXInspectionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 120)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdNoGo)
        Me.Controls.Add(Me.cmdGo)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.txtMeasurement)
        Me.Controls.Add(Me.lblMeasurement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HeaderFOXInspectionEntry"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Measurement Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMeasurement As System.Windows.Forms.Label
    Friend WithEvents txtMeasurement As System.Windows.Forms.TextBox
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdGo As System.Windows.Forms.Button
    Friend WithEvents cmdNoGo As System.Windows.Forms.Button
End Class
