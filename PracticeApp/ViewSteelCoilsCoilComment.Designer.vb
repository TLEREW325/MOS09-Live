<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelCoilsCoilComment
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
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(12, 38)
        Me.txtComment.MaxLength = 200
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ReadOnly = True
        Me.txtComment.Size = New System.Drawing.Size(485, 160)
        Me.txtComment.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Coil ID:"
        '
        'lblCoilID
        '
        Me.lblCoilID.AutoSize = True
        Me.lblCoilID.Location = New System.Drawing.Point(60, 13)
        Me.lblCoilID.Name = "lblCoilID"
        Me.lblCoilID.Size = New System.Drawing.Size(38, 13)
        Me.lblCoilID.TabIndex = 2
        Me.lblCoilID.Text = "Coil ID"
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
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdEdit.Location = New System.Drawing.Point(349, 209)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(71, 40)
        Me.cmdEdit.TabIndex = 5
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'ViewSteelCoilsCoilComment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 261)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAddUpdate)
        Me.Controls.Add(Me.lblCoilID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtComment)
        Me.MaximizeBox = False
        Me.Name = "ViewSteelCoilsCoilComment"
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
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
End Class
