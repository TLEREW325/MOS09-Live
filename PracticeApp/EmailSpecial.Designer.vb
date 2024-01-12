<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailSpecial
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
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.txtReturnAddress = New System.Windows.Forms.TextBox
        Me.txtEmailBody = New System.Windows.Forms.TextBox
        Me.txtEmailSubject = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNumberOfEmails = New System.Windows.Forms.TextBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSendEmail = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailAddress.Location = New System.Drawing.Point(118, 31)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(303, 20)
        Me.txtEmailAddress.TabIndex = 0
        '
        'txtReturnAddress
        '
        Me.txtReturnAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnAddress.Location = New System.Drawing.Point(118, 97)
        Me.txtReturnAddress.Name = "txtReturnAddress"
        Me.txtReturnAddress.Size = New System.Drawing.Size(303, 20)
        Me.txtReturnAddress.TabIndex = 1
        '
        'txtEmailBody
        '
        Me.txtEmailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailBody.Location = New System.Drawing.Point(118, 229)
        Me.txtEmailBody.Multiline = True
        Me.txtEmailBody.Name = "txtEmailBody"
        Me.txtEmailBody.Size = New System.Drawing.Size(303, 237)
        Me.txtEmailBody.TabIndex = 3
        '
        'txtEmailSubject
        '
        Me.txtEmailSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailSubject.Location = New System.Drawing.Point(118, 163)
        Me.txtEmailSubject.Name = "txtEmailSubject"
        Me.txtEmailSubject.Size = New System.Drawing.Size(303, 20)
        Me.txtEmailSubject.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Email Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Return Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Email Subject"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Email Body"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 512)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "# of Emails"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfEmails
        '
        Me.txtNumberOfEmails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfEmails.Location = New System.Drawing.Point(118, 512)
        Me.txtNumberOfEmails.Name = "txtNumberOfEmails"
        Me.txtNumberOfEmails.Size = New System.Drawing.Size(112, 20)
        Me.txtNumberOfEmails.TabIndex = 9
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(350, 597)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSendEmail
        '
        Me.cmdSendEmail.Location = New System.Drawing.Point(350, 497)
        Me.cmdSendEmail.Name = "cmdSendEmail"
        Me.cmdSendEmail.Size = New System.Drawing.Size(71, 40)
        Me.cmdSendEmail.TabIndex = 11
        Me.cmdSendEmail.Text = "Send Email"
        Me.cmdSendEmail.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(273, 597)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'EmailSpecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 649)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSendEmail)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtNumberOfEmails)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmailBody)
        Me.Controls.Add(Me.txtEmailSubject)
        Me.Controls.Add(Me.txtReturnAddress)
        Me.Controls.Add(Me.txtEmailAddress)
        Me.Name = "EmailSpecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtReturnAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailBody As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfEmails As System.Windows.Forms.TextBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSendEmail As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
End Class
