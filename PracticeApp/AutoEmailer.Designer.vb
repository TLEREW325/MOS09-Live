<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoEmailer
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
        Me.txtFromAddress = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtToAddress = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFakeAddress = New System.Windows.Forms.TextBox
        Me.txtNumberOfEmails = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEmailSubject = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEmailBody = New System.Windows.Forms.TextBox
        Me.cmdSend = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtSMTP = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNetworkCredentials = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtFromAddress
        '
        Me.txtFromAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromAddress.Location = New System.Drawing.Point(12, 106)
        Me.txtFromAddress.Name = "txtFromAddress"
        Me.txtFromAddress.Size = New System.Drawing.Size(456, 20)
        Me.txtFromAddress.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(456, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From Email Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(456, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To Email Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtToAddress
        '
        Me.txtToAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToAddress.Location = New System.Drawing.Point(12, 47)
        Me.txtToAddress.Name = "txtToAddress"
        Me.txtToAddress.Size = New System.Drawing.Size(456, 20)
        Me.txtToAddress.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(456, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "FAKE From Email Address"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFakeAddress
        '
        Me.txtFakeAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFakeAddress.Location = New System.Drawing.Point(12, 165)
        Me.txtFakeAddress.Name = "txtFakeAddress"
        Me.txtFakeAddress.Size = New System.Drawing.Size(456, 20)
        Me.txtFakeAddress.TabIndex = 4
        '
        'txtNumberOfEmails
        '
        Me.txtNumberOfEmails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfEmails.Location = New System.Drawing.Point(12, 641)
        Me.txtNumberOfEmails.Name = "txtNumberOfEmails"
        Me.txtNumberOfEmails.Size = New System.Drawing.Size(97, 20)
        Me.txtNumberOfEmails.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 615)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "# of Emails"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(456, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "SUBJECT LINE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailSubject
        '
        Me.txtEmailSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailSubject.Location = New System.Drawing.Point(12, 224)
        Me.txtEmailSubject.Name = "txtEmailSubject"
        Me.txtEmailSubject.Size = New System.Drawing.Size(456, 20)
        Me.txtEmailSubject.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(456, 23)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "EMAIL BODY"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailBody
        '
        Me.txtEmailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailBody.Location = New System.Drawing.Point(12, 282)
        Me.txtEmailBody.Multiline = True
        Me.txtEmailBody.Name = "txtEmailBody"
        Me.txtEmailBody.Size = New System.Drawing.Size(456, 101)
        Me.txtEmailBody.TabIndex = 10
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(312, 620)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(75, 41)
        Me.cmdSend.TabIndex = 12
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(393, 620)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 41)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtSMTP
        '
        Me.txtSMTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSMTP.Location = New System.Drawing.Point(15, 443)
        Me.txtSMTP.Name = "txtSMTP"
        Me.txtSMTP.Size = New System.Drawing.Size(453, 20)
        Me.txtSMTP.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 417)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(456, 23)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "SMTP Client"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPort
        '
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPort.Location = New System.Drawing.Point(15, 500)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 474)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(456, 23)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "SMTP Port"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 533)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(456, 23)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Network Credentials"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNetworkCredentials
        '
        Me.txtNetworkCredentials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetworkCredentials.Location = New System.Drawing.Point(15, 559)
        Me.txtNetworkCredentials.Name = "txtNetworkCredentials"
        Me.txtNetworkCredentials.Size = New System.Drawing.Size(453, 20)
        Me.txtNetworkCredentials.TabIndex = 18
        '
        'AutoEmailer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 673)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNetworkCredentials)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSMTP)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmailBody)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEmailSubject)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNumberOfEmails)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFakeAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtToAddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFromAddress)
        Me.Name = "AutoEmailer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auto Emailer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFromAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtToAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFakeAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfEmails As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmailSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmailBody As System.Windows.Forms.TextBox
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtSMTP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNetworkCredentials As System.Windows.Forms.TextBox
End Class
