Imports System
Imports System.IO
Imports System.IO.TextReader
Imports System.IO.StreamReader
Imports System.Data.SqlClient

Public Class LoginPage
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Dim LastSessionID, NextSessionID As Integer

    Private Const FILE_NAME As String = "\\TFP-FS\TransferData\MOS09 Updates\User_Log.txt"

    Dim FocusedField As New usefulFunctions.FocusedItem()
    Dim wasDeleted As Boolean = False
    Dim notFinished As Boolean = False
    Dim DefaultDivision As New Dictionary(Of String, String)
    Dim SecurityLevel As New Dictionary(Of String, String)

    Public Sub New()
        InitializeComponent()
        LoadDivisionID()
        LoadEmployeeDefaultDivisionSecurityLevel()
        If con.State = ConnectionState.Open Then con.Close()
        'Disable Close Button on form
        Call Disable(Me)
        GlobalVerifyCode = "FAILED"

        TimeLabel.Text = "What time is it now"

        txtLoginName.Focus()
        If Environment.MachineName.ToLower.Contains("tablet") Or Environment.MachineName.ToLower.Contains("agler") Then
            cmdKeyboard.Visible = True
        End If
        Me.AcceptButton = cmdEnter
    End Sub

    Private Sub LoadDivisionID()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboDivisionID.Items.Add(reader.Item("DivisionKey"))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadEmployeeDefaultDivisionSecurityLevel()
        cmd = New SqlCommand("SELECT LoginName, DivisionKey, SecurityGroupID FROM EmployeeData", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) AndAlso Not reader.IsDBNull(1) AndAlso Not reader.IsDBNull(2) Then
                    If Not DefaultDivision.ContainsKey(reader.Item("LoginName")) Then
                        DefaultDivision.Add(reader.Item("LoginName"), reader.Item("DivisionKey"))
                    End If
                    If Not SecurityLevel.ContainsKey(reader.Item("LoginName")) Then
                        SecurityLevel.Add(reader.Item("LoginName"), reader.Item("SecurityGroupID"))
                    End If
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Timer2.Interval = 1000 Then
            TimeLabel.Text = DateTime.Now
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtLoginName.Clear()
        txtLoginPassword.Clear()
        txtLoginName.Focus()
        cboDivisionID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboDivisionID.Text) Then
            cboDivisionID.Text = ""
        End If
        If Not cboDivisionID.Enabled Then
            cboDivisionID.Enabled = True
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If canCheckLogin() Then

            cmd = New SqlCommand("SELECT DivisionKey, SecurityGroupID, SalesPersonID FROM EmployeeData WHERE LoginName = @LoginName AND LoginPassword = @LoginPassword", con)
            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = txtLoginName.Text
            cmd.Parameters.Add("@LoginPassword", SqlDbType.VarChar).Value = txtLoginPassword.Text

            Dim division As String = ""
            Dim securityLevel As Integer = 0
            Dim SalesPersonID As String = ""

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                If Not reader.IsDBNull(0) Then
                    division = reader.Item("DivisionKey")
                    EmployeeCompanyCode = division
                End If
                If Not reader.IsDBNull(1) Then
                    securityLevel = reader.Item("SecurityGroupID")
                End If
                If Not reader.IsDBNull(2) Then
                    SalesPersonID = reader.Item("SalesPersonID")
                End If
                con.Close()

                If securityLevel <> 0 Then
                    EmployeeSecurityCode = securityLevel
                Else
                    sendErrorToDataBase("LoginPage - cmdEnter_Click --Missing security group ID on database", "Login name :" + txtLoginName.Text, "Missing security group ID")
                End If

                If cboDivisionID.Text = "LLH" Then
                    If division = "ADM" And (EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1003) Then
                        'Continue
                    Else
                        MsgBox("You cannot log into this division.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                End If

                If (division.Equals("ADM") Or securityLevel = 1001 Or securityLevel = 1002 Or securityLevel = 1030 Or txtLoginName.Text.Equals("TBLACKBURN")) And Not cboDivisionID.Text.Equals(division) Then
                    If securityLevel = 1030 And cboDivisionID.Text <> "TWD" And cboDivisionID.Text <> "TFP" Then
                        MessageBox.Show("You are only authorized to be in TWD or TFP", "Unable ot proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        EmployeeCompanyCode = cboDivisionID.Text
                        EmployeeLoginName = txtLoginName.Text
                        EmployeeSalespersonCode = SalesPersonID
                        LoginPassword1 = txtLoginPassword.Text
                        LoginPassword2 = txtLoginPassword.Text
                        LoginCompany = cboDivisionID.Text
                        LoginLast = txtLoginName.Text

                        WriteUserLogonLog()

                        GlobalVerifyCode = "PASSED"

                        Me.Dispose()
                        Me.Close()
                    End If

                Else
                    EmployeeCompanyCode = cboDivisionID.Text
                    EmployeeLoginName = txtLoginName.Text
                    EmployeeSalespersonCode = SalesPersonID
                    LoginPassword1 = txtLoginPassword.Text
                    LoginPassword2 = txtLoginPassword.Text
                    LoginCompany = cboDivisionID.Text
                    LoginLast = txtLoginName.Text
                    WriteUserLogonLog()

                    GlobalVerifyCode = "PASSED"
                    Me.Dispose()
                    Me.Close()
                End If
            Else
                con.Close()
                MessageBox.Show("User name or password is not valid. Enter a valid User name and password.", "Invalid User Name or password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLoginPassword.SelectAll()
                txtLoginPassword.Focus()
            End If
        End If
    End Sub

    Private Function canCheckLogin() As Boolean
        If String.IsNullOrEmpty(txtLoginName.Text) Then
            MessageBox.Show("You must enter a login name", "Enter a login Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoginName.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLoginPassword.Text) Then
            MessageBox.Show("You must enter a password", "Enter a password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoginPassword.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboDivisionID.Text) Then
            MessageBox.Show("You must enter a division", "Enter a division", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDivisionID.Focus()
            Return False
        End If
        If cboDivisionID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid division", "Enter a valid division", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDivisionID.SelectAll()
            cboDivisionID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub txtLoginName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginName.TextChanged
        If txtLoginName.Focused Then
            FocusedField.Position = txtLoginName.SelectionStart
            FocusedField.SelectionLength = 0
            If wasDeleted Then
                wasDeleted = False
            End If
        Else
            If Not wasDeleted Then
                FocusedField.Position += 1
            Else
                wasDeleted = False
            End If
        End If
        If Not String.IsNullOrEmpty(txtLoginName.Text) Then
            If DefaultDivision.ContainsKey(txtLoginName.Text) Then
                cboDivisionID.Text = DefaultDivision(txtLoginName.Text)
                If cboDivisionID.Text.Equals("ADM") Or txtLoginName.Text.Equals("SAMRAY") Or txtLoginName.Text.Equals("TWHITE") Or txtLoginName.Text.Equals("TBLACKBURN") Or SecurityLevel(txtLoginName.Text).Equals(1001) Or SecurityLevel(txtLoginName.Text).Equals(1002) Or SecurityLevel(txtLoginName.Text).Equals(1030) Then
                    cboDivisionID.Enabled = True
                Else
                    cboDivisionID.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub txtLoginPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLoginPassword.GotFocus
        EmployeeSalespersonCode = cboSalesPersonID.Text
    End Sub

    Public Shared Sub ReadFromFile()
        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader("\\TFP-FS\TransferData\MOS09 Updates\User_Log.txt")
            Dim line As String
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Do
                line = sr.ReadLine()
                Console.WriteLine(line)
            Loop Until line Is Nothing
            sr.Close()
        Catch E As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(E.Message)
        End Try
    End Sub

    Public Shared Sub WriteToFile()
        ' Create an instance of StreamWriter to write text to a file.
        Dim sw As StreamWriter = New StreamWriter("\\TFP-FS\TransferData\MOS09 Updates\User_Log.txt")
        ' Add some text to the file.
        sw.WriteLine("TFP Corporation ")
        sw.WriteLine("User Log File.")
        sw.WriteLine("-------------------")
        ' Arbitrary objects can also be written to the file.
        sw.Write("The date is: ")
        sw.WriteLine(DateTime.Now)
        sw.WriteLine("User " & EmployeeLoginName & " " & EmployeeCompanyCode & " Logged in")
        sw.Close()
    End Sub

    Public Shared Sub Main()
        If Not File.Exists(FILE_NAME) Then
            Console.WriteLine("{0} does not exist.", FILE_NAME)
            Return
        End If
        Dim sr As StreamReader = File.OpenText(FILE_NAME)
        Dim input As String
        input = sr.ReadLine()
        While Not input Is Nothing
            Console.WriteLine(input)
            input = sr.ReadLine()
        End While
        Console.WriteLine("The end of the stream has been reached.")
        sr.Close()
    End Sub

    Public Shared Sub Overwrite()
        Dim sw As StreamWriter = File.AppendText("\\TFP-FS\TransferData\MOS09 Updates\User_Log.txt")
        sw.WriteLine("-------------------")
        ' Arbitrary objects can also be written to the file.
        sw.Write("The date is: ")
        sw.WriteLine(DateTime.Now)
        sw.WriteLine("User " & EmployeeLoginName & " " & EmployeeCompanyCode & " Logged in")
        ' Close the writer and underlying file.
        sw.Close()
        ' Open and read the file.
        Dim r As StreamReader = File.OpenText("\\TFP-FS\TransferData\MOS09 Updates\User_Log.txt")
        DumpLog(r)
    End Sub

    Public Shared Sub Log(ByVal logMessage As String, ByVal w As TextWriter)
        w.Write(ControlChars.CrLf & "Log Entry : ")
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
        w.WriteLine("  :")
        w.WriteLine("  :{0}", logMessage)
        w.WriteLine("-------------------------------")
        ' Update the underlying file.
        w.Flush()
    End Sub

    Public Shared Sub DumpLog(ByVal r As StreamReader)
        ' While not at the end of the file, read and write lines.
        Dim line As String
        line = r.ReadLine()
        While Not line Is Nothing
            Console.WriteLine(line)
            line = r.ReadLine()
        End While
        r.Close()
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Private Sub LoginPage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub WriteUserLogonLog()
        Dim MAXStatement As String = "SELECT MAX(SessionID) FROM UserLoginTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastSessionID = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastSessionID = 10000000
        End Try
        con.Close()

        NextSessionID = LastSessionID + 1
        cboSessionID.Text = NextSessionID

        Try
            'Write Data to UserLoginTable
            cmd = New SqlCommand("DECLARE @SessionID as int = (SELECT isnull(MAX(SessionID)+1, 10000001) FROM UserLoginTable); Insert Into UserLoginTable(SessionID, LoginName, LoginDateTime, LogoutDateTime, CompanyCode, TodaysDate)Values(@SessionID, @LoginName, @LoginDateTime, @LogoutDateTime, @CompanyCode, @TodaysDate); SELECT @SessionID;", con)

            With cmd.Parameters
                .Add("@LoginName", SqlDbType.VarChar).Value = txtLoginName.Text
                .Add("@LoginDateTime", SqlDbType.VarChar).Value = TimeLabel.Text
                .Add("@LogoutDateTime", SqlDbType.VarChar).Value = "10/10/2010"
                .Add("@CompanyCode", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@TodaysDate", SqlDbType.VarChar).Value = Now()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            NextSessionID = cmd.ExecuteScalar()
            con.Close()
        Catch ex As Exception
            'Nothing
        End Try
        GlobalSessionID = NextSessionID
    End Sub

    Private Sub cmdKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeyboard.Click
        If Me.Size.Height < 720 Or Me.Size.Width < 1280 Then
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Size = New System.Drawing.Size(1280, 720)
        End If
        gpxKeyboard.Visible = True
        cmdKeyboard.Visible = False
    End Sub

    ''input section start
    Private Sub cmdZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZero.Click
        addText(sender, e, "0")
    End Sub

    Private Sub cmdOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOne.Click
        addText(sender, e, "1")
    End Sub

    Private Sub cmdTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTwo.Click
        addText(sender, e, "2")
    End Sub

    Private Sub cmdThree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThree.Click
        addText(sender, e, "3")
    End Sub

    Private Sub cmdFour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFour.Click
        addText(sender, e, "4")
    End Sub

    Private Sub cmdFive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFive.Click
        addText(sender, e, "5")
    End Sub

    Private Sub cmdSix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSix.Click
        addText(sender, e, "6")
    End Sub

    Private Sub cmdSeven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeven.Click
        addText(sender, e, "7")
    End Sub

    Private Sub cmdEight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEight.Click
        addText(sender, e, "8")
    End Sub

    Private Sub cmdNine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNine.Click
        addText(sender, e, "9")
    End Sub

    Private Sub cmdL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL.Click
        addText(sender, e, "L")
    End Sub

    Private Sub cmdM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdM.Click
        addText(sender, e, "M")
    End Sub

    Private Sub cmdN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdN.Click
        addText(sender, e, "N")
    End Sub

    Private Sub cmdB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdB.Click
        addText(sender, e, "B")
    End Sub

    Private Sub cmdV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdV.Click
        addText(sender, e, "V")
    End Sub

    Private Sub cmdC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdC.Click
        addText(sender, e, "C")
    End Sub

    Private Sub cmdX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdX.Click
        addText(sender, e, "X")
    End Sub

    Private Sub cmdZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZ.Click
        addText(sender, e, "Z")
    End Sub

    Private Sub cmdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdA.Click
        addText(sender, e, "A")
    End Sub

    Private Sub cmdQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQ.Click
        addText(sender, e, "Q")
    End Sub

    Private Sub cmdW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdW.Click
        addText(sender, e, "W")
    End Sub

    Private Sub cmdE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdE.Click
        addText(sender, e, "E")
    End Sub

    Private Sub cmdR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdR.Click
        addText(sender, e, "R")
    End Sub

    Private Sub cmdT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdT.Click
        addText(sender, e, "T")
    End Sub

    Private Sub cmdY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdY.Click
        addText(sender, e, "Y")
    End Sub

    Private Sub cmdU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdU.Click
        addText(sender, e, "U")
    End Sub

    Private Sub cmdI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdI.Click
        addText(sender, e, "I")
    End Sub

    Private Sub cmdO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdO.Click
        addText(sender, e, "O")
    End Sub

    Private Sub cmdP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdP.Click
        addText(sender, e, "P")
    End Sub

    Private Sub cmdS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS.Click
        addText(sender, e, "S")
    End Sub

    Private Sub cmdD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdD.Click
        addText(sender, e, "D")
    End Sub

    Private Sub cmdF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF.Click
        addText(sender, e, "F")
    End Sub

    Private Sub cmdG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdG.Click
        addText(sender, e, "G")
    End Sub

    Private Sub cmdH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdH.Click
        addText(sender, e, "H")
    End Sub

    Private Sub cmdJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJ.Click
        addText(sender, e, "J")
    End Sub

    Private Sub cmdK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdK.Click
        addText(sender, e, "K")
    End Sub

    Private Sub cmdSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSpace.Click
        addText(sender, e, " ")
    End Sub

    Private Sub addText(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal tex As String, Optional ByVal charCount As Integer = 1)
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to see if there is a selection
            If FocusedField.SelectionLength > 0 Then
                cmdBackspace_Click(sender, e)
            End If
            If FocusedField.Position = FocusedField.Text.Length Then
                FocusedField.Text += tex
            Else
                If FocusedField.Position > FocusedField.Text.Length Then
                    FocusedField.Position = FocusedField.Text.Length
                End If
                FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + tex + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
            End If
            If charCount > 1 Then
                FocusedField.Position += charCount - 1
            End If
            If FocusedField.Position = 0 Then
                FocusedField.Position = 1
            End If
            FocusedField.Focus()
        End If
    End Sub

    Private Sub cmdBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackspace.Click
        If Not String.IsNullOrEmpty(FocusedField.Name) Then
            ''check to make sure there is something to delete
            If FocusedField.Text.Length > 0 Then
                wasDeleted = True
                ''check to see if there was a selection made
                If FocusedField.SelectionLength > 0 Then
                    Select Case True
                        Case FocusedField.SelectionLength = FocusedField.Text.Length
                            FocusedField.Text = ""
                            FocusedField.Position = 0
                            Exit Select
                        Case FocusedField.Position = 0
                            FocusedField.Text = FocusedField.Text.Substring(FocusedField.SelectionLength, FocusedField.Text.Length - FocusedField.SelectionLength)
                            Exit Select
                        Case FocusedField.SelectionLength = (FocusedField.Text.Length - FocusedField.Position)
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position)
                            FocusedField.Position = FocusedField.Text.Length
                            Exit Select
                        Case Else
                            If FocusedField.Position > FocusedField.Text.Length Then
                                FocusedField.Position = FocusedField.Text.Length
                            End If
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position) + FocusedField.Text.Substring(FocusedField.Position + FocusedField.SelectionLength, FocusedField.Text.Length - (FocusedField.Position + FocusedField.SelectionLength))
                    End Select
                    FocusedField.SelectionLength = 0
                Else
                    ''check to se if we are at the back of the text
                    If FocusedField.Position = FocusedField.Text.Length Then
                        FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Text.Length - 1)
                        FocusedField.Position = FocusedField.Text.Length
                    Else
                        If FocusedField.Position > 0 Then
                            FocusedField.Text = FocusedField.Text.Substring(0, FocusedField.Position - 1) + FocusedField.Text.Substring(FocusedField.Position, FocusedField.Text.Length - FocusedField.Position)
                            FocusedField.Position -= 1
                        End If
                    End If
                End If
            End If
            FocusedField.Focus()
        End If
    End Sub

    Private Sub txtLoginName_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLoginName.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtLoginName.SelectionStart
            FocusedField.SelectionLength = txtLoginName.SelectionLength
        End If
    End Sub

    Private Sub txtLoginPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginPassword.TextChanged
        If txtLoginPassword.Focused Then
            FocusedField.Position = txtLoginPassword.SelectionStart
            FocusedField.SelectionLength = 0
            If wasDeleted Then
                wasDeleted = False
            End If
        Else
            If Not wasDeleted Then
                FocusedField.Position += 1
            Else
                wasDeleted = False
            End If
        End If
    End Sub

    Private Sub txtLoginPassword_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLoginPassword.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = txtLoginPassword.SelectionStart
            FocusedField.SelectionLength = txtLoginPassword.SelectionLength
        End If
    End Sub

    Private Sub cboCompanyName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.TextChanged
        If cboDivisionID.Focused Then
            FocusedField.Position = cboDivisionID.SelectionStart
            FocusedField.SelectionLength = 0
            If wasDeleted Then
                wasDeleted = False
            End If
        Else
            If Not wasDeleted Then
                FocusedField.Position += 1
            Else
                wasDeleted = False
            End If
        End If
    End Sub

    Private Sub cboCompanyName_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboDivisionID.MouseUp
        If FocusedField.isSet() Then
            FocusedField.Position = cboDivisionID.SelectionStart
            FocusedField.SelectionLength = cboDivisionID.SelectionLength
        End If
    End Sub

    Private Sub cmdKeyboardEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeyboardEnter.Click
        Select Case FocusedField.name
            Case "txtLoginName"
                txtLoginPassword.Focus()
            Case "txtLoginPassword"
                cmdEnter.Focus()
            Case Else
                txtLoginName.Focus()
        End Select
    End Sub

    Private Sub cmdClearSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSelected.Click
        If FocusedField.isSet() Then
            Me.Controls(FocusedField.name).Text = ""
            Me.Controls(FocusedField.name).Focus()
        End If
    End Sub

    Private Sub txtLoginName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginName.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("txtLoginName") Then
                FocusedField = New FocusedItem(txtLoginName)
            Else
                txtLoginName.SelectionStart = FocusedField.position
            End If
        Else
            FocusedField = New FocusedItem(txtLoginName)
        End If
    End Sub

    Private Sub txtLoginPassword_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginPassword.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.name.Equals("txtLoginPassword") Then
                FocusedField = New FocusedItem(txtLoginPassword)
            Else
                txtLoginPassword.SelectionStart = FocusedField.position
            End If
        Else
            FocusedField = New FocusedItem(txtLoginPassword)
        End If
    End Sub

    Private Sub cboDivisionID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.Enter
        If FocusedField.isSet() Then
            If Not FocusedField.Name.Equals("cboDivisionID") Then
                FocusedField = New FocusedItem(cboDivisionID)
            Else
                cboDivisionID.SelectionStart = FocusedField.Position
            End If
        Else
            FocusedField = New FocusedItem(cboDivisionID)
        End If
    End Sub

    Private Sub cmdEnter_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Enter
        FocusedField = New FocusedItem()
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboDivisionID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDivisionID.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub LoginPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged

    End Sub
End Class

