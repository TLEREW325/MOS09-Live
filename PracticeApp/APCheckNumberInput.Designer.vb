<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APCheckNumberInput
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
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtFirstCheckNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(167, 84)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(75, 28)
        Me.cmdEnter.TabIndex = 0
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(248, 84)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 28)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtFirstCheckNumber
        '
        Me.txtFirstCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstCheckNumber.Location = New System.Drawing.Point(167, 42)
        Me.txtFirstCheckNumber.Name = "txtFirstCheckNumber"
        Me.txtFirstCheckNumber.Size = New System.Drawing.Size(156, 20)
        Me.txtFirstCheckNumber.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(30, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Starting Check Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'APCheckNumberInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 133)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFirstCheckNumber)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdEnter)
        Me.Name = "APCheckNumberInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enter First Check Number"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtFirstCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
