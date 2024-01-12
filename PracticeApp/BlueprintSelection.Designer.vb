<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlueprintSelection
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdHeader = New System.Windows.Forms.Button
        Me.cmdMachining = New System.Windows.Forms.Button
        Me.cmdFinished = New System.Windows.Forms.Button
        Me.cmdTooling = New System.Windows.Forms.Button
        Me.cmdTWEAccessories = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(380, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Blueprint"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdHeader
        '
        Me.cmdHeader.Location = New System.Drawing.Point(13, 91)
        Me.cmdHeader.Name = "cmdHeader"
        Me.cmdHeader.Size = New System.Drawing.Size(71, 40)
        Me.cmdHeader.TabIndex = 1
        Me.cmdHeader.Text = "Header"
        Me.cmdHeader.UseVisualStyleBackColor = True
        '
        'cmdMachining
        '
        Me.cmdMachining.Location = New System.Drawing.Point(90, 91)
        Me.cmdMachining.Name = "cmdMachining"
        Me.cmdMachining.Size = New System.Drawing.Size(71, 40)
        Me.cmdMachining.TabIndex = 2
        Me.cmdMachining.Text = "Machining"
        Me.cmdMachining.UseVisualStyleBackColor = True
        '
        'cmdFinished
        '
        Me.cmdFinished.Location = New System.Drawing.Point(167, 91)
        Me.cmdFinished.Name = "cmdFinished"
        Me.cmdFinished.Size = New System.Drawing.Size(71, 40)
        Me.cmdFinished.TabIndex = 3
        Me.cmdFinished.Text = "Finished"
        Me.cmdFinished.UseVisualStyleBackColor = True
        '
        'cmdTooling
        '
        Me.cmdTooling.Location = New System.Drawing.Point(244, 91)
        Me.cmdTooling.Name = "cmdTooling"
        Me.cmdTooling.Size = New System.Drawing.Size(71, 40)
        Me.cmdTooling.TabIndex = 4
        Me.cmdTooling.Text = "Tooling"
        Me.cmdTooling.UseVisualStyleBackColor = True
        '
        'cmdTWEAccessories
        '
        Me.cmdTWEAccessories.Location = New System.Drawing.Point(321, 91)
        Me.cmdTWEAccessories.Name = "cmdTWEAccessories"
        Me.cmdTWEAccessories.Size = New System.Drawing.Size(71, 40)
        Me.cmdTWEAccessories.TabIndex = 5
        Me.cmdTWEAccessories.Text = "TWE Accessory"
        Me.cmdTWEAccessories.UseVisualStyleBackColor = True
        '
        'BlueprintSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 183)
        Me.Controls.Add(Me.cmdTWEAccessories)
        Me.Controls.Add(Me.cmdTooling)
        Me.Controls.Add(Me.cmdFinished)
        Me.Controls.Add(Me.cmdMachining)
        Me.Controls.Add(Me.cmdHeader)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "BlueprintSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Blueprint Selection"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdHeader As System.Windows.Forms.Button
    Friend WithEvents cmdMachining As System.Windows.Forms.Button
    Friend WithEvents cmdFinished As System.Windows.Forms.Button
    Friend WithEvents cmdTooling As System.Windows.Forms.Button
    Friend WithEvents cmdTWEAccessories As System.Windows.Forms.Button
End Class
