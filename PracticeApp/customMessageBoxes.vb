Module customMessageBoxes
    ''creates a custom messagebox for the user to show the mthat they are trying to do something that they should not be doing
    Function customWarningMessageBox(ByVal msg As String, ByVal title As String) As DialogResult
        Dim msgbx As New System.Windows.Forms.Form
        Dim txtbx As New System.Windows.Forms.TextBox
        Dim btnOk As New System.Windows.Forms.Button
        ''changes the txtbx so that it matches the scheme for all forms
        txtbx.Text = msg
        txtbx.Name = "txtMessage"
        txtbx.Font = New System.Drawing.Font(txtbx.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        txtbx.Size = New Size(360, 92)
        txtbx.BorderStyle = BorderStyle.None
        txtbx.BackColor = msgbx.BackColor
        txtbx.Multiline = True
        txtbx.TabStop = False
        txtbx.ReadOnly = True
        ''changes the btnYes so that it matched the scheme for all forms
        btnOk.Name = "cmdOk"
        btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes
        btnOk.Font = New System.Drawing.Font(btnOk.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btnOk.Text = "OK"
        btnOk.Size = New Size(99, 60)
        btnOk.TabIndex = 0
        ''changes the form and adds controls
        msgbx.Size = New Size(400, 200)
        msgbx.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        msgbx.MinimizeBox = False
        msgbx.MaximizeBox = False
        msgbx.ShowIcon = False
        msgbx.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        msgbx.Controls.Add(txtbx)
        msgbx.Controls.Add(btnOk)
        msgbx.Controls("txtMessage").Location = New System.Drawing.Point(12, 17)
        msgbx.Controls("cmdOk").Location = New System.Drawing.Point(280, 110)
        msgbx.Text = title
        msgbx.StartPosition = FormStartPosition.CenterScreen
        msgbx.ControlBox = False
        'If redTitle Then
        '    msgbx.FormBorderStyle = FormBorderStyle.None
        '    Dim txtTitle As New System.Windows.Forms.TextBox
        '    txtTitle.Name = "txtTitle"
        '    txtTitle.Text = title
        '    txtTitle.TabStop = False
        '    txtTitle.BackColor = Color.Red
        '    txtTitle.BorderStyle = BorderStyle.None
        '    txtTitle.ReadOnly = True
        '    txtTitle.ForeColor = Color.White
        '    txtTitle.Font = New System.Drawing.Font(txtTitle.Font.FontFamily, 11, FontStyle.Bold, GraphicsUnit.Point)
        '    txtTitle.Width = msgbx.Width
        '    msgbx.Controls.Add(txtTitle)
        '    msgbx.Controls("txtTitle").Location = New System.Drawing.Point(0, 0)
        'End If
        Return msgbx.ShowDialog()
    End Function
    ''creates a custom messagebox for the user to show them that they are trying to do something that they should not be doing
    Function customYesNoMessageBox(ByVal msg As String, Optional ByVal title As String = "Continue?") As DialogResult
        Dim msgbx As New System.Windows.Forms.Form
        Dim txtbx As New System.Windows.Forms.TextBox
        Dim btnYes As New System.Windows.Forms.Button
        Dim btnNo As New System.Windows.Forms.Button
        ''changes the txtbx so that it matches the scheme for all forms
        txtbx.Text = msg
        txtbx.Name = "txtMessage"
        txtbx.Font = New System.Drawing.Font(txtbx.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        txtbx.Size = New Size(360, 92)
        txtbx.BorderStyle = BorderStyle.None
        txtbx.BackColor = msgbx.BackColor
        txtbx.Multiline = True
        txtbx.TabStop = False
        txtbx.ReadOnly = True
        ''changes the btnYes so that it matched the scheme for all forms
        btnYes.Name = "cmdYes"
        btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes
        btnYes.Font = New System.Drawing.Font(btnYes.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btnYes.Text = "Yes"
        btnYes.Size = New Size(99, 60)
        btnYes.TabIndex = 0
        ''changes the btnNo so that it matches the scheme for all forms
        btnNo.Name = "cmdNo"
        btnNo.DialogResult = System.Windows.Forms.DialogResult.No
        btnNo.Font = New System.Drawing.Font(btnNo.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btnNo.Text = "No"
        btnNo.Size = New Size(99, 60)
        btnNo.TabIndex = 1
        ''changes the form and adds controls
        msgbx.Size = New Size(400, 200)
        msgbx.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        msgbx.MinimizeBox = False
        msgbx.MaximizeBox = False
        msgbx.ShowIcon = False
        msgbx.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        msgbx.Controls.Add(txtbx)
        msgbx.Controls.Add(btnNo)
        msgbx.Controls.Add(btnYes)
        msgbx.Controls("txtMessage").Location = New System.Drawing.Point(12, 12)
        msgbx.Controls("cmdYes").Location = New System.Drawing.Point(95, 110)
        msgbx.Controls("cmdNo").Location = New System.Drawing.Point(215, 110)
        msgbx.Text = title
        msgbx.StartPosition = FormStartPosition.CenterScreen

        Return msgbx.ShowDialog()
    End Function

    Function customVerifyUser(ByVal user As String) As List(Of String)
        Dim verifybx As New System.Windows.Forms.Form
        Dim lblLoginName As New System.Windows.Forms.Label
        Dim lblLoginPassword As New System.Windows.Forms.Label
        Dim txtbxLoginName As New System.Windows.Forms.TextBox
        Dim txtbxLoginPassword As New System.Windows.Forms.TextBox
        Dim btnSubmit As New System.Windows.Forms.Button
        Dim btnCancel As New System.Windows.Forms.Button
        ''changes the LoginName textbox
        txtbxLoginName.Text = user
        txtbxLoginName.Name = "txtLoginName"
        txtbxLoginName.Font = New System.Drawing.Font(txtbxLoginName.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        txtbxLoginName.Size = New Size(140, 24)
        txtbxLoginName.TabIndex = 3
        txtbxLoginName.CharacterCasing = CharacterCasing.Upper
        ''changes the LoginName textbox
        txtbxLoginPassword.Name = "txtLoginPass"
        txtbxLoginPassword.Font = New System.Drawing.Font(txtbxLoginPassword.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        txtbxLoginPassword.Size = New Size(140, 24)
        txtbxLoginPassword.TabIndex = 0
        txtbxLoginPassword.CharacterCasing = CharacterCasing.Upper
        txtbxLoginPassword.UseSystemPasswordChar = True
        ''changes the label for login name
        lblLoginName.Text = "Login Name"
        lblLoginName.Name = "lblLoginName"
        lblLoginName.Font = New System.Drawing.Font(lblLoginName.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        lblLoginName.Size = New Size(90, 20)
        ''changes the lablel for login password
        lblLoginPassword.Text = "Login Password"
        lblLoginPassword.Name = "lblLoginPass"
        lblLoginPassword.Font = New System.Drawing.Font(lblLoginName.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        lblLoginPassword.Size = New Size(120, 20)
        ''changes the btnSubmit so that it matched the scheme for all forms
        btnSubmit.Name = "cmdSubmit"
        btnSubmit.DialogResult = System.Windows.Forms.DialogResult.Yes
        btnSubmit.Font = New System.Drawing.Font(btnSubmit.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btnSubmit.Text = "Submit"
        btnSubmit.Size = New Size(99, 60)
        btnSubmit.TabIndex = 1
        ''changes the btnCancel so that it matches the scheme for all forms
        btnCancel.Name = "cmdCancel"
        btnCancel.DialogResult = System.Windows.Forms.DialogResult.No
        btnCancel.Font = New System.Drawing.Font(btnCancel.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btnCancel.Text = "Cancel"
        btnCancel.Size = New Size(99, 60)
        btnCancel.TabIndex = 2
        ''changes the form and adds controls
        verifybx.Size = New Size(400, 200)
        verifybx.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        'verifybx.MinimizeBox = False
        'verifybx.MaximizeBox = False
        verifybx.ControlBox = False
        verifybx.ShowIcon = False
        verifybx.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        verifybx.Controls.Add(lblLoginName)
        verifybx.Controls.Add(txtbxLoginName)
        verifybx.Controls.Add(txtbxLoginPassword)
        verifybx.Controls.Add(lblLoginPassword)
        verifybx.Controls.Add(btnCancel)
        verifybx.Controls.Add(btnSubmit)
        verifybx.Controls("cmdSubmit").Location = New System.Drawing.Point(81, 101)
        verifybx.Controls("cmdCancel").Location = New System.Drawing.Point(201, 101)
        verifybx.Controls("txtLoginName").Location = New System.Drawing.Point(178, 19)
        verifybx.Controls("txtLoginPass").Location = New System.Drawing.Point(178, 59)
        verifybx.Controls("lblLoginName").Location = New System.Drawing.Point(82, 22)
        verifybx.Controls("lblLoginPass").Location = New System.Drawing.Point(51, 62)
        verifybx.Text = "Verify User"
        verifybx.StartPosition = FormStartPosition.CenterScreen

        If verifybx.ShowDialog() = DialogResult.No Then
    Dim returnList1 As New List(Of String)
            returnList1.Add("INVALID")
            returnList1.Add("")
            Return returnList1
        End If
    Dim returnList As New List(Of String)
        returnList.Add(verifybx.Controls("txtLoginName").Text)
        returnList.Add(verifybx.Controls("txtLoginPass").Text)

        Return returnList
    End Function
    Function OverrideSteelMissMatch(Optional ByVal user As String = "", Optional ByVal attempts As Integer = 4) As List(Of String)
        Dim verifybx As New System.Windows.Forms.Form
        Dim lblMessage As New System.Windows.Forms.Label
        Dim lblLoginName As New System.Windows.Forms.Label
        Dim lblLoginPassword As New System.Windows.Forms.Label
        Dim txtbxLoginName As New System.Windows.Forms.TextBox
        Dim txtbxLoginPassword As New System.Windows.Forms.TextBox
        Dim btnSubmit As New System.Windows.Forms.Button
        Dim btnCancel As New System.Windows.Forms.Button

        ''changes the label for the message
        lblMessage.Text = "Steel doesn't match perfered type. Contact QC or Engineering to override or cancel."
        lblMessage.Name = "lblMessage"
        lblMessage.Font = New System.Drawing.Font(lblMessage.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        lblMessage.Size = New Size(310, 38)
        lblMessage.ForeColor = Color.Red
        ''changes the LoginName textbox
        txtbxLoginName.Text = user
        txtbxLoginName.Name = "txtLoginName"
        txtbxLoginName.Font = New System.Drawing.Font(txtbxLoginName.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        txtbxLoginName.Size = New Size(140, 24)
        txtbxLoginName.TabIndex = 0
        txtbxLoginName.CharacterCasing = CharacterCasing.Upper
        ''changes the LoginName textbox
        txtbxLoginPassword.Name = "txtLoginPass"
        txtbxLoginPassword.Font = New System.Drawing.Font(txtbxLoginPassword.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        txtbxLoginPassword.Size = New Size(140, 24)
        txtbxLoginPassword.TabIndex = 1
        txtbxLoginPassword.CharacterCasing = CharacterCasing.Upper
        txtbxLoginPassword.UseSystemPasswordChar = True
        ''changes the label for login name
        lblLoginName.Text = "Login Name"
        lblLoginName.Name = "lblLoginName"
        lblLoginName.Font = New System.Drawing.Font(lblLoginName.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        lblLoginName.Size = New Size(90, 20)
        ''changes the lablel for login password
        lblLoginPassword.Text = "Login Password"
        lblLoginPassword.Name = "lblLoginPass"
        lblLoginPassword.Font = New System.Drawing.Font(lblLoginName.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        lblLoginPassword.Size = New Size(120, 20)
        ''changes the btnSubmit so that it matched the scheme for all forms
        btnSubmit.Name = "cmdSubmit"
        btnSubmit.DialogResult = System.Windows.Forms.DialogResult.Yes
        btnSubmit.Font = New System.Drawing.Font(btnSubmit.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btnSubmit.Text = "Submit"
        btnSubmit.Size = New Size(99, 60)
        btnSubmit.TabIndex = 2
        ''changes the btnCancel so that it matches the scheme for all forms
        btnCancel.Name = "cmdCancel"
        btnCancel.DialogResult = System.Windows.Forms.DialogResult.No
        btnCancel.Font = New System.Drawing.Font(btnCancel.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btnCancel.Text = "Cancel"
        btnCancel.Size = New Size(99, 60)
        btnCancel.TabIndex = 3
        ''changes the form and adds controls
        verifybx.Size = New Size(400, 275)
        verifybx.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        'verifybx.MinimizeBox = False
        'verifybx.MaximizeBox = False
        verifybx.ControlBox = False
        verifybx.ShowIcon = False
        verifybx.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        verifybx.Controls.Add(lblMessage)
        verifybx.Controls.Add(lblLoginName)
        verifybx.Controls.Add(txtbxLoginName)
        verifybx.Controls.Add(txtbxLoginPassword)
        verifybx.Controls.Add(lblLoginPassword)
        verifybx.Controls.Add(btnCancel)
        verifybx.Controls.Add(btnSubmit)
        ''check attempts to make sure its not the default
        If attempts <= 3 Then
            If Not String.IsNullOrEmpty(user) Then
                txtbxLoginName.TabIndex = 3
                txtbxLoginPassword.TabIndex = 0
            End If
            Dim lblAttempts As New System.Windows.Forms.Label
            ''changes the label for the message
            lblAttempts.Text = "Attempt " + attempts.ToString() + " of 3"
            lblAttempts.Name = "lblAttempts"
            lblAttempts.Font = New System.Drawing.Font(lblAttempts.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
            lblAttempts.Size = New Size(99, 18)
            verifybx.Controls.Add(lblAttempts)
            verifybx.Controls("lblAttempts").Location = New System.Drawing.Point(150, 140)
        End If

        verifybx.Controls("cmdSubmit").Location = New System.Drawing.Point(81, 175)
        verifybx.Controls("cmdCancel").Location = New System.Drawing.Point(201, 175)
        verifybx.Controls("txtLoginName").Location = New System.Drawing.Point(178, 60)
        verifybx.Controls("txtLoginPass").Location = New System.Drawing.Point(178, 97)
        verifybx.Controls("lblLoginName").Location = New System.Drawing.Point(82, 65)
        verifybx.Controls("lblLoginPass").Location = New System.Drawing.Point(51, 100)
        verifybx.Controls("lblMessage").Location = New System.Drawing.Point(39, 10)
        verifybx.Text = "Override Prefered Steel"
        verifybx.StartPosition = FormStartPosition.CenterScreen

        If verifybx.ShowDialog() = DialogResult.No Then
            Dim returnList1 As New List(Of String)
            returnList1.Add("CANCELLED")
            returnList1.Add("")
            Return returnList1
        End If
        Dim returnList As New List(Of String)
        returnList.Add(verifybx.Controls("txtLoginName").Text)
        returnList.Add(verifybx.Controls("txtLoginPass").Text)

        Return returnList
    End Function

    Function CoilLeft() As Double
        Dim verifybx As New System.Windows.Forms.Form
        Dim lblMessage As New System.Windows.Forms.Label
        Dim btn25 As New System.Windows.Forms.Button
        Dim btn50 As New System.Windows.Forms.Button
        Dim btn75 As New System.Windows.Forms.Button
        Dim btn100 As New System.Windows.Forms.Button

        ''changes the label for the message
        lblMessage.Text = "Approximatly how much is left?"
        lblMessage.Name = "lblMessage"
        lblMessage.Font = New System.Drawing.Font(lblMessage.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        lblMessage.Size = New Size(211, 18)
        ''changes the btnSubmit so that it matched the scheme for all forms
        btn25.Name = "cmd25"
        btn25.DialogResult = System.Windows.Forms.DialogResult.OK
        btn25.Font = New System.Drawing.Font(btn25.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btn25.Text = "25%"
        btn25.Size = New Size(99, 60)
        btn25.TabIndex = 0
        ''changes the btnCancel so that it matches the scheme for all forms
        btn50.Name = "cmd50"
        btn50.DialogResult = System.Windows.Forms.DialogResult.Ignore
        btn50.Font = New System.Drawing.Font(btn50.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btn50.Text = "50%"
        btn50.Size = New Size(99, 60)
        btn50.TabIndex = 1
        ''changes the btnCancel so that it matches the scheme for all forms
        btn75.Name = "cmd75"
        btn75.DialogResult = System.Windows.Forms.DialogResult.Abort
        btn75.Font = New System.Drawing.Font(btn50.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btn75.Text = "75%"
        btn75.Size = New Size(99, 60)
        btn75.TabIndex = 2
        ''changes the btnCancel so that it matches the scheme for all forms
        btn100.Name = "cmd100"
        btn100.DialogResult = System.Windows.Forms.DialogResult.Retry
        btn100.Font = New System.Drawing.Font(btn50.Font.FontFamily, 11, FontStyle.Regular, GraphicsUnit.Point)
        btn100.Text = "100%"
        btn100.Size = New Size(99, 60)
        btn100.TabIndex = 1
        ''changes the form and adds controls
        verifybx.Size = New Size(450, 200)
        verifybx.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        'verifybx.MinimizeBox = False
        'verifybx.MaximizeBox = False
        verifybx.ControlBox = False
        verifybx.ShowIcon = False
        verifybx.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        verifybx.Controls.Add(lblMessage)
        verifybx.Controls.Add(btn25)
        verifybx.Controls.Add(btn50)
        verifybx.Controls.Add(btn75)
        verifybx.Controls.Add(btn100)

        verifybx.Controls("cmd25").Location = New System.Drawing.Point(12, 92)
        verifybx.Controls("cmd50").Location = New System.Drawing.Point(117, 92)
        verifybx.Controls("cmd75").Location = New System.Drawing.Point(222, 92)
        verifybx.Controls("cmd100").Location = New System.Drawing.Point(327, 92)
        verifybx.Controls("lblMessage").Location = New System.Drawing.Point(114, 28)
        verifybx.Text = "How much coil left"
        verifybx.StartPosition = FormStartPosition.CenterScreen

        Select Case verifybx.ShowDialog()
            Case DialogResult.OK
                Return 0.25
            Case DialogResult.Ignore
                Return 0.5
            Case DialogResult.Abort
                Return 0.75
            Case DialogResult.Retry
                Return 1.0
        End Select
        Return 0
    End Function
End Module
