<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelCoilPopup
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
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCoilID = New System.Windows.Forms.Label
        Me.cmdAddUpdate = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(12, 36)
        Me.txtComment.MaxLength = 200
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(485, 74)
        Me.txtComment.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Coil ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCoilID
        '
        Me.lblCoilID.ForeColor = System.Drawing.Color.Blue
        Me.lblCoilID.Location = New System.Drawing.Point(60, 13)
        Me.lblCoilID.Name = "lblCoilID"
        Me.lblCoilID.Size = New System.Drawing.Size(250, 20)
        Me.lblCoilID.TabIndex = 2
        Me.lblCoilID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddUpdate
        '
        Me.cmdAddUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddUpdate.Location = New System.Drawing.Point(349, 209)
        Me.cmdAddUpdate.Name = "cmdAddUpdate"
        Me.cmdAddUpdate.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddUpdate.TabIndex = 3
        Me.cmdAddUpdate.Text = "Update"
        Me.cmdAddUpdate.UseVisualStyleBackColor = True
        Me.cmdAddUpdate.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdCancel.Location = New System.Drawing.Point(426, 209)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocation.Location = New System.Drawing.Point(12, 142)
        Me.txtLocation.MaxLength = 200
        Me.txtLocation.Multiline = True
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(485, 52)
        Me.txtLocation.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Coil Location:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SteelCoilPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 261)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAddUpdate)
        Me.Controls.Add(Me.lblCoilID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtComment)
        Me.MaximizeBox = False
        Me.Name = "SteelCoilPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Coil Comment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCoilID As System.Windows.Forms.Label
    Friend WithEvents cmdAddUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
