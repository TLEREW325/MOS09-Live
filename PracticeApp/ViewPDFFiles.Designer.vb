<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPDFFiles
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
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.bsrFile = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Enabled = False
        Me.cmdPrevious.Location = New System.Drawing.Point(12, 12)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrevious.TabIndex = 0
        Me.cmdPrevious.Text = "Previous"
        Me.cmdPrevious.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNext.Location = New System.Drawing.Point(951, 12)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(71, 40)
        Me.cmdNext.TabIndex = 1
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'bsrFile
        '
        Me.bsrFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bsrFile.Location = New System.Drawing.Point(12, 58)
        Me.bsrFile.MinimumSize = New System.Drawing.Size(20, 20)
        Me.bsrFile.Name = "bsrFile"
        Me.bsrFile.Size = New System.Drawing.Size(1010, 641)
        Me.bsrFile.TabIndex = 2
        '
        'ViewPDFFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 711)
        Me.Controls.Add(Me.bsrFile)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Name = "ViewPDFFiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "View PDF Files"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents bsrFile As System.Windows.Forms.WebBrowser
End Class
