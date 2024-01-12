Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Diagnostics.Eventing.Reader
Imports System.Text
Imports System
Imports System.Math
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class ComputerUtilities
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim CarbonFilter, SteelSizeFilter, RMIDFilter As String
    Dim GetOldSteelSize, GetOldCarbon As String

    'Test Print using the PrintDocument Method
    Private WithEvents TestDocumentToPrint As PrintDocument

    'barcode variables
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLables As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    'Setup data connection and variables
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL1;Initial Catalog=TFPOperationsBackup;Integrated Security=True;Connect Timeout=30")

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub StartClient()
        'bgwk.ReportProgress(0)
        'AddHandler tmrConnectionTimer.Elapsed, AddressOf ConnectionTimer_Tick
        'AddHandler tmrWaitTimer.Elapsed, AddressOf tmrFileWaitTimer_Tick
        'AddHandler tmrMaxConnectionTime.Elapsed, AddressOf tmrMaxConnectionTime_Tick
        'Dim UserIP As String = GetLastIPAddress()
        'If Not UserIP.Equals("NONE") Then
        '    Console.WriteLine("Attempting to connect to IP " + UserIP + " on port " + port.ToString)
        '    Try
        '        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(UserIP)
        '        Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)
        '        Dim remoteEP As IPEndPoint = New IPEndPoint(ipAddress, port)

        '        client = New Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
        '        tmrConnectionTimer.Start()
        '        client.BeginConnect(remoteEP, New AsyncCallback(AddressOf ConnectCallback), client)
        '        connectDone.WaitOne()
        '        If client.Connected Then
        '            tmrMaxConnectionTime.Start()
        '            tmrConnectionTimer.Stop()
        '            ''AKNOWLEDGEMENT FOR CONNECTION
        '            ReceiveAknowledgement(client)
        '            AknowledgementReceived.WaitOne()
        '            AknowledgementReceived.Reset()
        '            ''SEND COMMAND
        '            SendCommand(client, "<MOS><ID>" + identNumber.ToString() + "</ID><Command>SCAN</Command></MOS>")
        '            CommandSent.WaitOne()
        '            CommandSent.Reset()
        '            ''AKNOWLEDGEMENT FOR COMMAND
        '            ReceiveAknowledgement(client)
        '            AknowledgementReceived.WaitOne()
        '            AknowledgementReceived.Reset()
        '            ''WAIT FOR RESPONSE OF ERROR OR SCANNING COMPLETED
        '            CurrentlyAwaiting = "ErrorOrResponse"
        '            tmrWaitTimer.Start()
        '            ReceiveErrorOrResponse(client)
        '            ReceiveErrorOrResponseHold.WaitOne()
        '            If tmrWaitTimer.Enabled Then tmrWaitTimer.Stop()
        '            ''Check to see if the operation was cancelled
        '            If Not ResetAll Then
        '                CurrentlyAwaiting = "File"
        '                Attempts = 1
        '                ''Check to see if greater than 20 seconds
        '                If 10000 * TotalPages > 20000 Then
        '                    ''Clamping the max wait time at 40 seconds
        '                    If 1000 * TotalPages > 40000 Then
        '                        tmrWaitTimer.Interval = 40000
        '                    Else
        '                        tmrWaitTimer.Interval = 10000 * TotalPages
        '                    End If
        '                Else
        '                    tmrWaitTimer.Interval = 20000
        '                End If
        '                ''Resets the max connection timer to 2 minutes
        '                tmrMaxConnectionTime.Stop()
        '                tmrMaxConnectionTime.Interval = tmrWaitTimer.Interval + 60000
        '                tmrMaxConnectionTime.Start()

        '                ''Starting timer and stating wait for file transfer confirmation
        '                tmrWaitTimer.Start()
        '                ReceiveFile(client)
        '                FileReceived.WaitOne()
        '                If tmrWaitTimer.Enabled Then tmrWaitTimer.Stop()
        '            End If
        '            tmrMaxConnectionTime.Stop()
        '            client.Shutdown(SocketShutdown.Both)
        '            client.Close()
        '        Else
        '            MessageBox.Show("Unable to connect to local system to scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If

        '    Catch ex As System.Exception
        '        Console.WriteLine(ex.ToString())
        '    End Try
        'Else
        '    Console.WriteLine("No valid IP address was found for the current user.")
        'End If
    End Sub

    Private Function GetLastIPAddress() As String
        ''Goes through the Event Log and finds the most recent entry for the current user. This will get the IP address.
        Dim test As String = Environment.UserDomainName + "\" + Environment.UserName
        Console.WriteLine("Checking IP address for user " + test)
        Dim query As New EventLogQuery("Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", PathType.LogName, "*[UserData/EventXML/User='" + test + "']")
        query.ReverseDirection = True

        Dim reader As New EventLogReader(query)

        Dim eventInstance As EventRecord = reader.ReadEvent()
        Dim pos As Integer = 0
        While eventInstance IsNot Nothing AndAlso pos < 50
            If eventInstance.Id = 21 Or eventInstance.Id = 22 Or eventInstance.Id = 25 Then
                Dim xmlString As String = eventInstance.ToXml()
                Dim firstTag As Integer = xmlString.LastIndexOf("<Address>") + 9
                Dim LastTag As Integer = xmlString.LastIndexOf("</Address>")
                Dim address As String = xmlString.Substring(firstTag, LastTag - firstTag)
                If address.Equals("LOCAL") Then
                    Return GetLocalIPV4Address()
                Else
                    Return address
                End If
            End If

            eventInstance = reader.ReadEvent()
            pos += 1
        End While
        Return "NONE"
    End Function

    Private Function GetLocalIPV4Address() As String
        ''We want the IPv4 Address not the IPv6
        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddress As IPAddress = Nothing

        Dim i As Integer = 0
        While ipAddress Is Nothing AndAlso i < ipHostInfo.AddressList.Length
            If ipHostInfo.AddressList(i).AddressFamily.ToString() = "InterNetwork" Then
                ipAddress = ipHostInfo.AddressList(i)
            Else
                i += 1
            End If
        End While

        If ipAddress Is Nothing Then ipAddress = ipHostInfo.AddressList(0)
        Return ipAddress.ToString()
    End Function

    Private Sub ComputerUtilities_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadOldRMID()
        LoadNewRMID()
        LoadRMIDForUpdate()

        If EmployeeLoginName = "LEREW" Then
            cmdTestEmail.Enabled = True
        Else
            cmdTestEmail.Enabled = False
        End If
    End Sub

    Public Sub LoadOldRMID()
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable ORDER BY RMID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboOldRMID.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboOldRMID.SelectedIndex = -1
    End Sub

    Public Sub LoadNewRMID()
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable WHERE SteelStatus <> 'CLOSED' ORDER BY RMID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboNewRMID.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboNewRMID.SelectedIndex = -1
    End Sub

    Public Sub LoadRMIDForUpdate()
        cmd = New SqlCommand("SELECT RMID FROM RawMaterialsTable ORDER BY RMID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "RawMaterialsTable")
        cboRMIDUpdateSteelSizeAndCarbon.DataSource = ds3.Tables("RawMaterialsTable")
        con.Close()
        cboRMIDUpdateSteelSizeAndCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSizeAndCarbonForUpdate()
        Dim CurrentSteelSize As String = ""
        Dim CurrentSteelCarbon As String = ""

        Dim CurrentSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = 'TWD'"
        Dim CurrentSteelSizeCommand As New SqlCommand(CurrentSteelSizeStatement, con)
        CurrentSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text

        Dim CurrentSteelCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = 'TWD'"
        Dim CurrentSteelCarbonCommand As New SqlCommand(CurrentSteelCarbonStatement, con)
        CurrentSteelCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CurrentSteelSize = CStr(CurrentSteelSizeCommand.ExecuteScalar)
        Catch ex As Exception
            CurrentSteelSize = ""
        End Try
        Try
            CurrentSteelCarbon = CStr(CurrentSteelCarbonCommand.ExecuteScalar)
        Catch ex As Exception
            CurrentSteelCarbon = ""
        End Try
        con.Close()

        If cboRMIDUpdateSteelSizeAndCarbon.Text = "" Then
            txtCarbonUpdate.Clear()
            txtSteelSizeUpdate.Clear()
        Else
            txtCarbonUpdate.Text = CurrentSteelCarbon
            txtSteelSizeUpdate.Text = CurrentSteelSize
        End If
    End Sub

    Private Sub cboRMIDUpdateSteelSizeAndCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRMIDUpdateSteelSizeAndCarbon.SelectedIndexChanged
        LoadSteelSizeAndCarbonForUpdate()
    End Sub

    Private Sub cmdUpdateSteelSizeAndCarbon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSteelSizeAndCarbon.Click
        'Validate Fields
        If txtSteelSizeUpdate.Text = "" Or txtCarbonUpdate.Text = "" Or cboRMIDUpdateSteelSizeAndCarbon.Text = "" Then
            MsgBox("You must have a valid RMID, Carbon, and Steel Size selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Update all tables that have steel size and steel carbon in them
        Dim button As DialogResult = MessageBox.Show("This will change steel carbon and steel size in all tables - Do you wish to continue?", "UPDATE STEEL DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Get Original Steel Carbon and Steel Size for the RMID
            Dim OriginalSteelCarbon As String = ""
            Dim OriginalSteelSize As String = ""

            Dim CurrentSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = 'TWD'"
            Dim CurrentSteelSizeCommand As New SqlCommand(CurrentSteelSizeStatement, con)
            CurrentSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text

            Dim CurrentSteelCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = 'TWD'"
            Dim CurrentSteelCarbonCommand As New SqlCommand(CurrentSteelCarbonStatement, con)
            CurrentSteelCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OriginalSteelSize = CStr(CurrentSteelSizeCommand.ExecuteScalar)
            Catch ex As Exception
                OriginalSteelSize = ""
            End Try
            Try
                OriginalSteelCarbon = CStr(CurrentSteelCarbonCommand.ExecuteScalar)
            Catch ex As Exception
                OriginalSteelCarbon = ""
            End Try
            con.Close()
            '*************************************************************************************************************
            'Update Steel Adjustment Table
            Try
                cmd = New SqlCommand("UPDATE SteelAdjustmentTable SET SteelCarbon = @SteelCarbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text
                    .Add("@SteelCarbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Steel Adj table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update Steel Change Coil and RMID Table
            Try
                cmd = New SqlCommand("UPDATE SteelChangeCoilAndRMID SET Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Steel Change Coil table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update Steel Costing Table
            Try
                cmd = New SqlCommand("UPDATE SteelCostingTable SET Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Steel Costing Table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update Steel Special Orders
            Try
                cmd = New SqlCommand("UPDATE SteelSpecialOrders SET Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Steel Special Orders Table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update Steel Transaction Table
            Try
                cmd = New SqlCommand("UPDATE SteelTransactionTable SET Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Steel Transaction Table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update Steel Valuation Table
            Try
                cmd = New SqlCommand("UPDATE SteelValuationTable SET SteelCarbon = @SteelCarbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text
                    .Add("@SteelCarbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Steel Valuation Table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update Charter Steel Coil Table
            Try
                cmd = New SqlCommand("UPDATE HeatNumberLog SET Carbon = @Carbon, SteelSize = @SteelSize WHERE Carbon = @Carbon2 AND SteelSize = @SteelSize2", con)

                With cmd.Parameters
                    .Add("@Carbon2", SqlDbType.VarChar).Value = OriginalSteelCarbon
                    .Add("@SteelSize2", SqlDbType.VarChar).Value = OriginalSteelSize
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Charter Coil Table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update Heat Number Log
            Try
                cmd = New SqlCommand("UPDATE HeatNumberLog SET SteelType = @SteelType, SteelSize = @SteelSize WHERE SteelType = @SteelType2 AND SteelSize = @SteelSize2", con)

                With cmd.Parameters
                    .Add("@SteelType2", SqlDbType.VarChar).Value = OriginalSteelCarbon
                    .Add("@SteelSize2", SqlDbType.VarChar).Value = OriginalSteelSize
                    .Add("@SteelType", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Heat Number Table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Update RMID Table
            Try
                cmd = New SqlCommand("UPDATE RawMaterialsTable SET Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = cboRMIDUpdateSteelSizeAndCarbon.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtCarbonUpdate.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtSteelSizeUpdate.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Update Steel Size/Carbon in Raw Materials Table Failure"
                ErrorDivision = "TWD"
                ErrorDescription = "RMID - " + cboRMIDUpdateSteelSizeAndCarbon.Text
                ErrorReferenceNumber = ""
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**************************************************************************************************************
            'Clear Fields
            txtSteelSizeUpdate.Clear()
            txtCarbonUpdate.Clear()
            cboRMIDUpdateSteelSizeAndCarbon.SelectedIndex = -1

            MsgBox("Steel Carbon / Steel Size has been updated.", MsgBoxStyle.OkCancel)
        ElseIf button = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdGetIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetIP.Click
        Dim UserIP As String = GetLastIPAddress()
        txtUserIP.Text = UserIP
    End Sub

    Private Sub cmdUpdateSteelInFOXES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSteelInFOXES.Click
        'Validate RMID
        Dim CheckForExistingRMID As Integer = 0

        Dim CheckForExistingRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE RMID = @RMID AND SteelStatus <> @SteelStatus"
        Dim CheckForExistingRMIDCommand As New SqlCommand(CheckForExistingRMIDStatement, con)
        CheckForExistingRMIDCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboNewRMID.Text
        CheckForExistingRMIDCommand.Parameters.Add("@SteelStatus", SqlDbType.VarChar).Value = "CLOSED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForExistingRMID = CInt(CheckForExistingRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForExistingRMID = 0
        End Try
        con.Close()

        If CheckForExistingRMID = 0 Then
            MsgBox("Steel does not exist or is closed. Update failed.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            'Update Active FOXES - Preferred
            cmd = New SqlCommand("UPDATE FOXTable SET RMID = @NewRMID WHERE RMID = @OldRMID AND Status = 'ACTIVE'", con)

            With cmd.Parameters
                .Add("@NewRMID", SqlDbType.VarChar).Value = cboNewRMID.Text
                .Add("@OldRMID", SqlDbType.VarChar).Value = cboOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Update Active FOXES - Alternate
            cmd = New SqlCommand("UPDATE FOXTable SET ScheduledRMID = @NewRMID WHERE ScheduledRMID = @OldRMID AND Status = 'ACTIVE'", con)

            With cmd.Parameters
                .Add("@NewRMID", SqlDbType.VarChar).Value = cboNewRMID.Text
                .Add("@OldRMID", SqlDbType.VarChar).Value = cboOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Continue
        End Try

        'Clear
        MsgBox("Steel in FOXES updated.", MsgBoxStyle.OkOnly)
        cboNewRMID.SelectedIndex = -1
        cboOldRMID.SelectedIndex = -1
    End Sub

    Private Sub cmdUploadCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadCSV.Click
        'Variables
        Dim ArrayIndex As Integer = 0
        Dim HeatFileArray(0 To 40) As String
        Dim MillCertFileName As String = ""
        Dim MillCertFileNameAndPath As String = ""
        Dim TempFileName As String = ""
        '*************************************************************************************************
        'Create Unique file name
        Dim FileDate As Date = Now()
        Dim FileMonth As Integer = 0
        Dim FileDay As Integer = 0
        Dim FileMinute As Integer = 0
        Dim FileYear As Integer = 0
        Dim strFileDay As String = ""
        Dim strFileMonth As String = ""
        Dim strFileYear As String = ""
        Dim strFileMinute As String = ""

        FileMonth = FileDate.Month
        FileDay = FileDate.Day
        FileYear = FileDate.Year
        FileMinute = FileDate.Minute

        If FileMonth < 10 Then
            strFileMonth = "0" + CStr(FileMonth)
        Else
            strFileMonth = CStr(FileMonth)
        End If
        If FileDay < 10 Then
            strFileDay = "0" + CStr(FileDay)
        Else
            strFileDay = CStr(FileDay)
        End If

        strFileYear = CStr(FileYear)
        strFileMinute = CStr(FileMinute)

        MillCertFileName = strFileMonth + strFileDay + strFileYear + strFileMinute
        MillCertFileNameAndPath = "\\TFP-SQL\TransferData\Charter Steel Mill Cert Flat Files\" + MillCertFileName + ".csv"

        'Open File Dialog Box
        If ofdOpenFlatFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        'Get filename from dialog box
        TempFileName = ofdOpenFlatFile.FileName

        If TempFileName = "" Then
            Exit Sub
        End If

        Try
            'Rename file
            File.Copy(TempFileName, MillCertFileNameAndPath)
        Catch ex As Exception
            'Rename file
            MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
            Exit Sub
        End Try

        'File Created
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'Read from file and write to table
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(MillCertFileNameAndPath)

            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")

            Dim currentRow As String()

            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String

                    For Each currentField In currentRow

                        HeatFileArray(ArrayIndex) = currentField
                        ArrayIndex = ArrayIndex + 1
                    Next

                    ArrayIndex = 0

                    'Get New Heat File Number
                    Dim LastHeatFileNumber, NextHeatFileNumber As Integer

                    Dim LastHeatFileNumberStatement As String = "SELECT MAX(HeatFileNumber) FROM HeatNumberLog"
                    Dim LastHeatFileNumberCommand As New SqlCommand(LastHeatFileNumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastHeatFileNumber = CInt(LastHeatFileNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastHeatFileNumber = 0
                    End Try
                    con.Close()

                    NextHeatFileNumber = LastHeatFileNumber + 1
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Reserve Heat File
                    cmd = New SqlCommand("INSERT INTO HeatNumberLog (HeatFileNumber, Status) values (@HeatFileNumber, @Status)", con)

                    With cmd.Parameters
                        .Add("@HeatFileNumber", SqlDbType.VarChar).Value = NextHeatFileNumber
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Get Raw Material Data from PO
                    Dim GetCarbon, GetSize, GetDescription As String

                    Dim GetCoilCarbonStatement As String = "SELECT Carbon FROM SteelPurchaseLineQuery WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber"
                    Dim GetCoilCarbonCommand As New SqlCommand(GetCoilCarbonStatement, con)
                    GetCoilCarbonCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = HeatFileArray(6)
                    GetCoilCarbonCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = 1

                    Dim GetCoilSizeStatement As String = "SELECT SteelSize FROM SteelPurchaseLineQuery WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber"
                    Dim GetCoilSizeCommand As New SqlCommand(GetCoilSizeStatement, con)
                    GetCoilSizeCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = HeatFileArray(6)
                    GetCoilSizeCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = 1

                    Dim GetCoilDescriptionStatement As String = "SELECT Description FROM SteelPurchaseLineQuery WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber"
                    Dim GetCoilDescriptionCommand As New SqlCommand(GetCoilDescriptionStatement, con)
                    GetCoilDescriptionCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = HeatFileArray(6)
                    GetCoilDescriptionCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = 1

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetCarbon = CStr(GetCoilCarbonCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetCarbon = ""
                    End Try
                    Try
                        GetSize = CStr(GetCoilSizeCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetSize = ""
                    End Try
                    Try
                        GetDescription = CStr(GetCoilDescriptionCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetDescription = ""
                    End Try
                    con.Close()

                    If HeatFileArray(1) = "" Then
                        MsgBox("Heat Number is missing.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    If GetCarbon = "" Then
                        MsgBox("Steel carbon is missing.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    If GetSize = "" Then
                        MsgBox("Steel size is missing.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    'Insert Into Heat Number Log Table
                    cmd = New SqlCommand("Update HeatNumberLog SET HeatNumber = @HeatNumber, SteelType = @SteelType, SteelSize = @SteelSize, VendorID = @VendorID, DateReceived = @DateReceived, SteelPONumber = @SteelPONumber, Comments = @Comments, Yield = @Yield, ReductionOfArea = @ReductionOfArea, Elongation = @Elongation, CoilsInHeat = @CoilsInHeat, PoundsInHeat = @PoundsInHeat, UltimateYield = @UltimateYield, Status = @Status, Carbon = @Carbon, Manganese = @Manganese, Phosphorus = @Phosphorus, Sulfur = @Sulfur, Silicon = @Silicon, Nickel = @Nickel, Chromium = @Chromium, Molybdenum = @Molybdenum, Copper = @Copper, Tin = @Tin, Vanadium = @Vanadium, Aluminum = @Aluminum, Nitrogen = @Nitrogen, Boron = @Boron, Titanium = @Titanium, Niobium = @Niobium, Cobalt = @Cobalt, Zinc = @Zinc, Iron = @Iron, Lead = @Lead, Tungsten = @Tungsten, Magnesium = @Magnesium, MaterialOrigin = @MaterialOrigin, BOLNumber = @BOLNumber, CEVValue = @CEVValue WHERE HeatFileNumber = @HeatFileNumber", con)

                    With cmd.Parameters
                        .Add("@HeatFileNumber", SqlDbType.VarChar).Value = NextHeatFileNumber
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatFileArray(1)
                        .Add("@SteelType", SqlDbType.VarChar).Value = GetCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = GetSize
                        .Add("@VendorID", SqlDbType.VarChar).Value = "CHARTERSTEEL"
                        .Add("@DateReceived", SqlDbType.VarChar).Value = Today()
                        .Add("@SteelPONumber", SqlDbType.VarChar).Value = HeatFileArray(6)
                        .Add("@Comments", SqlDbType.VarChar).Value = GetDescription
                        .Add("@Yield", SqlDbType.VarChar).Value = HeatFileArray(8)
                        .Add("@ReductionOfArea", SqlDbType.VarChar).Value = HeatFileArray(9)
                        .Add("@Elongation", SqlDbType.VarChar).Value = HeatFileArray(10)
                        .Add("@Carbon", SqlDbType.VarChar).Value = HeatFileArray(11)
                        .Add("@Manganese", SqlDbType.VarChar).Value = HeatFileArray(12)
                        .Add("@Phosphorus", SqlDbType.VarChar).Value = HeatFileArray(13)
                        .Add("@Sulfur", SqlDbType.VarChar).Value = HeatFileArray(14)
                        .Add("@Silicon", SqlDbType.VarChar).Value = HeatFileArray(15)
                        .Add("@Nickel", SqlDbType.VarChar).Value = HeatFileArray(16)
                        .Add("@Chromium", SqlDbType.VarChar).Value = HeatFileArray(17)
                        .Add("@Molybdenum", SqlDbType.VarChar).Value = HeatFileArray(18)
                        .Add("@Copper", SqlDbType.VarChar).Value = HeatFileArray(19)
                        .Add("@Tin", SqlDbType.VarChar).Value = HeatFileArray(20)
                        .Add("@Vanadium", SqlDbType.VarChar).Value = HeatFileArray(21)
                        .Add("@Aluminum", SqlDbType.VarChar).Value = HeatFileArray(22)
                        .Add("@Nitrogen", SqlDbType.VarChar).Value = HeatFileArray(23)
                        .Add("@Boron", SqlDbType.VarChar).Value = HeatFileArray(24)
                        .Add("@Titanium", SqlDbType.VarChar).Value = HeatFileArray(25)
                        .Add("@Niobium", SqlDbType.VarChar).Value = HeatFileArray(26)
                        .Add("@Cobalt", SqlDbType.VarChar).Value = HeatFileArray(27)
                        .Add("@Zinc", SqlDbType.VarChar).Value = HeatFileArray(28)
                        .Add("@Iron", SqlDbType.VarChar).Value = HeatFileArray(29)
                        .Add("@Lead", SqlDbType.VarChar).Value = HeatFileArray(30)
                        .Add("@Tungsten", SqlDbType.VarChar).Value = HeatFileArray(31)
                        .Add("@Magnesium", SqlDbType.VarChar).Value = HeatFileArray(32)
                        .Add("@CoilsInHeat", SqlDbType.VarChar).Value = HeatFileArray(33)
                        .Add("@PoundsInHeat", SqlDbType.VarChar).Value = HeatFileArray(34)
                        .Add("@UltimateYield", SqlDbType.VarChar).Value = HeatFileArray(35)
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@MaterialOrigin", SqlDbType.VarChar).Value = HeatFileArray(37)
                        .Add("@BOLNumber", SqlDbType.VarChar).Value = HeatFileArray(38)
                        .Add("@CEVValue", SqlDbType.VarChar).Value = HeatFileArray(39)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                    MsgBox("File failed to upload. Heat File may already be uploaded. Contact system Admin.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End Try
            End While

            MsgBox("File uploaded.", MsgBoxStyle.OkOnly)
        End Using
    End Sub

    Public Sub LoadSteelFromRMID()
        Dim GetDescription, GetCarbon, GetSteelSize As String

        Dim GetDescriptionStatement As String = "SELECT Description FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetDescriptionCommand As New SqlCommand(GetDescriptionStatement, con)
        GetDescriptionCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text

        Dim GetCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetCarbonCommand As New SqlCommand(GetCarbonStatement, con)
        GetCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text

        Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
        GetSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetDescription = CStr(GetDescriptionCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetDescription = ""
        End Try
        Try
            GetCarbon = CStr(GetCarbonCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetCarbon = ""
        End Try
        Try
            GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetSteelSize = ""
        End Try
        con.Close()

        txtNewCarbon.Text = GetCarbon
        txtNewDescription.Text = GetDescription
        txtNewSteelSize.Text = GetSteelSize
    End Sub

    Public Sub LoadOldCarbonAndSteelSizeFromOldRMID()
        Dim GetOldCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetOldCarbonCommand As New SqlCommand(GetOldCarbonStatement, con)
        GetOldCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtOldRMID.Text

        Dim GetOldSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim GetOldSteelSizeCommand As New SqlCommand(GetOldSteelSizeStatement, con)
        GetOldSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtOldRMID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetOldCarbon = CStr(GetOldCarbonCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetOldCarbon = ""
        End Try
        Try
            GetOldSteelSize = CStr(GetOldSteelSizeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetOldSteelSize = ""
        End Try
        con.Close()
    End Sub

    Private Sub cmdUpdateRMID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateRMID.Click
        'Check RMIDS
        Dim ValidateOldRMID As Integer = 0
        Dim ValidateNewRMID As Integer = 0

        Dim ValidateOldRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim ValidateOldRMIDCommand As New SqlCommand(ValidateOldRMIDStatement, con)
        ValidateOldRMIDCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtOldRMID.Text

        Dim ValidateNewRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE RMID = @RMID"
        Dim ValidateNewRMIDCommand As New SqlCommand(ValidateNewRMIDStatement, con)
        ValidateNewRMIDCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ValidateOldRMID = CInt(ValidateOldRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            ValidateOldRMID = 0
        End Try
        Try
            ValidateNewRMID = CInt(ValidateNewRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            ValidateNewRMID = 0
        End Try
        con.Close()

        If ValidateOldRMID >= 1 Then
            'Continue
        Else
            MsgBox("Old RMID does not exist.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If ValidateNewRMID = 1 Then
            'Continue
        Else
            'Check all fields for entries
            If txtNewCarbon.Text = "" Then
                MsgBox("Enter Carbon.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            If txtNewDescription.Text = "" Then
                MsgBox("Enter Description.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            If txtNewSteelSize.Text = "" Then
                MsgBox("Enter Steel Size.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            If txtNewRMID.Text = "" Then
                MsgBox("Enter RMID.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '***********************************************************************************
            'Create New RMID
            Try
                cmd = New SqlCommand("INSERT INTO RawMaterialsTable (RMID, Description, Carbon, SteelSize, BeginningBalance, CreationDate, DivisionID, SteelClass, SteelStatus) Values (@RMID, @Description, @Carbon, @SteelSize, @BeginningBalance, @CreationDate, @DivisionID, @SteelClass, @SteelStatus)", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtNewDescription.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
                    .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@SteelClass", SqlDbType.VarChar).Value = "TWD STEEL(INVENTORY)"
                    .Add("@SteelStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = "Failed to create new RMID"
                ErrorDivision = "TWD"
                ErrorDescription = "Database Utilities - Update Steel RMID"
                ErrorReferenceNumber = txtOldRMID.Text
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
        '***********************************************************************************
        'Update Steel RMID with new details (Raw Materials Table)
        Try
            cmd = New SqlCommand("UPDATE RawMaterialsTable SET Description = @Description, Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMID", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@Description", SqlDbType.VarChar).Value = txtNewDescription.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Raw Materials Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Transaction Table
        Try
            cmd = New SqlCommand("UPDATE SteelTransactionTable SET RMID = @RMID, Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Transaction Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update FOXES (Preferred and Alternate)
        Try
            cmd = New SqlCommand("UPDATE FOXTable SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update FOX Table #1"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        Try
            cmd = New SqlCommand("UPDATE FOXTable SET ScheduledRMID = @RMID WHERE ScheduledRMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update FOX Table #2"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Heat Number Log
        LoadOldCarbonAndSteelSizeFromOldRMID()

        Try
            cmd = New SqlCommand("UPDATE HeatNumberLog SET SteelType = @SteelType, SteelSize = @SteelSize WHERE SteelType = @SteelTypeOld AND SteelSize = @SteelSizeOld", con)

            With cmd.Parameters
                .Add("@SteelType", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
                .Add("@SteelTypeOld", SqlDbType.VarChar).Value = GetOldCarbon
                .Add("@SteelSizeOld", SqlDbType.VarChar).Value = GetOldSteelSize
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Heat Number Log"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Adjustment Table
        Try
            cmd = New SqlCommand("UPDATE SteelAdjustmentTable SET RMID = @RMID, SteelCarbon = @SteelCarbon, SteelSize = @SteelSize WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@SteelCarbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Adjustment Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Coil Table
        Try
            cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Carbon = @Carbon, SteelSize = @SteelSize WHERE Carbon = @CarbonOld AND SteelSize = @SteelSizeOld", con)

            With cmd.Parameters
                .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
                .Add("@CarbonOld", SqlDbType.VarChar).Value = GetOldCarbon
                .Add("@SteelSizeOld", SqlDbType.VarChar).Value = GetOldSteelSize
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Coil Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Purchase Lines
        Try
            cmd = New SqlCommand("UPDATE SteelPurchaseLine SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Purchase Lines"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Receiver Lines
        Try
            cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel receiver Lines"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Return Lines
        Try
            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Return Lines"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Voucher Lines
        Try
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartNumber = @PartNumber, PartDescription = @PartDescription WHERE PartNumber = @PartNumberOld", con)

            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = txtNewCarbon.Text + " - " + txtNewSteelSize.Text
                .Add("@PartNumberOld", SqlDbType.VarChar).Value = txtOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update ROI Lines"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Coil Change Coil And RMID
        Try
            cmd = New SqlCommand("UPDATE SteelChangeCoilAndRMID SET RMID = @RMID, Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Change Coil #1"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        Try
            cmd = New SqlCommand("UPDATE SteelChangeCoilAndRMID SET ReworkRMID = @RMID, ReworkCarbon = @Carbon, ReworkSteelSize = @SteelSize WHERE ReworkRMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Change Coil #2"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Costing Table
        Try
            cmd = New SqlCommand("UPDATE SteelCostingTable SET RMID = @RMID, Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Costing Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Special Orders
        Try
            cmd = New SqlCommand("UPDATE SteelSpecialOrders SET RMID = @RMID, Carbon = @Carbon, SteelSize = @SteelSize WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Special Orders"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Usage Table
        Try
            cmd = New SqlCommand("UPDATE SteelUsageTable SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Usage Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Yard Entry Table
        Try
            cmd = New SqlCommand("UPDATE SteelYardEntryTable SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Yard Entry Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Steel Heat Treat Inspection Log
        Try
            cmd = New SqlCommand("UPDATE HeatTreatInspectionLog SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Heat Treat Inspection Log"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Time Slip Table
        Try
            cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Time Slip Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Pull Test Table
        Try
            cmd = New SqlCommand("UPDATE PullTestData SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Pull Test Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Lot Number Table
        Try
            cmd = New SqlCommand("UPDATE LotNumber SET RMID = @RMID, SteelType = @SteelType, SteelSize = @SteelSize, SteelDescription = @SteelDescription WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@SteelType", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
                .Add("@SteelDescription", SqlDbType.VarChar).Value = txtNewDescription.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Lot Number Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Update Annealing Log
        Try
            cmd = New SqlCommand("UPDATE AnnealingLog SET RMID = @RMID WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Annealing Log #1"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        Try
            cmd = New SqlCommand("UPDATE AnnealingLog SET AnnealedRMID = @RMID, AnnealedCarbon = @SteelType, AnnealedSteelSize = @SteelSize WHERE AnnealedRMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
                .Add("@RMID", SqlDbType.VarChar).Value = txtNewRMID.Text
                .Add("@SteelType", SqlDbType.VarChar).Value = txtNewCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = txtNewSteelSize.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to update Steel Annealing Log #2"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '***********************************************************************************
        'Delete Old RMID
        Try
            cmd = New SqlCommand("DELETE FROM RawMaterialsTable WHERE RMID = @RMIDOLD", con)

            With cmd.Parameters
                .Add("@RMIDOLD", SqlDbType.VarChar).Value = txtOldRMID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorComment = "Failed to delete from Raw Materials Table"
            ErrorDivision = "TWD"
            ErrorDescription = "Database Utilities - Update Steel RMID"
            ErrorReferenceNumber = txtOldRMID.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        '***********************************************************************************
        MsgBox("All entries have been updated.", MsgBoxStyle.OkOnly)

        txtOldRMID.Clear()
        txtNewCarbon.Clear()
        txtNewRMID.Clear()
        txtNewSteelSize.Clear()
        txtNewDescription.Clear()

        GetOldCarbon = ""
        GetOldSteelSize = ""
    End Sub

    Private Sub txtNewRMID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewRMID.TextChanged
        LoadSteelFromRMID()
    End Sub

    Private Sub cmdClearRMID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearRMID.Click
        txtNewRMID.Clear()
        txtOldRMID.Clear()
    End Sub

    Private Sub cmdUploadCoilFlatFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadCoilFlatFiles.Click
        'Variables
        Dim ArrayIndex As Integer = 0
        Dim SteelFileArray(0 To 20) As String
        Dim CharterFileName As String = ""
        Dim strFileDateExtension As String = ""
        Dim TempFileName As String = ""

        'Create Filename
        Dim MinuteDate As Date = Now()
        Dim TodaysDate As Date = Today()
        Dim strDay, strMonth, strYear, strMinute, strHour As String
        Dim intDay, intMonth, intYear, intMinute, intHour As Integer

        intDay = TodaysDate.Day
        intMonth = TodaysDate.Month
        intYear = TodaysDate.Year
        intMinute = MinuteDate.Minute
        intHour = MinuteDate.Hour

        strDay = CStr(intDay)
        strMonth = CStr(intMonth)
        strYear = CStr(intYear)
        strMinute = CStr(intMinute)
        strHour = CStr(intHour)

        If intDay < 10 Then
            strDay = "0" + strDay
        Else
            'Do nothing
        End If
        If intMonth < 10 Then
            strMonth = "0" + strMonth
        Else
            'Do nothing
        End If

        strFileDateExtension = strMonth + strDay + strYear + strHour + strMinute
        CharterFileName = "\\TFP-SQL\TransferData\Charter Coil ID's\Charter Steel Flat File - Manual Upload - " + strFileDateExtension + ".csv"

        'Open File Dialog Box
        If ofdOpenFlatFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        'Get filename from dialog box
        TempFileName = ofdOpenFlatFile.FileName

        If TempFileName = "" Then
            Exit Sub
        End If

        Try
            'Rename file
            File.Copy(TempFileName, CharterFileName)
        Catch ex As Exception
            'Rename file
            MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
            Exit Sub
        End Try

        'Read from file and write to table
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(CharterFileName)

            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")

            Dim currentRow As String()

            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String

                    For Each currentField In currentRow

                        SteelFileArray(ArrayIndex) = currentField
                        ArrayIndex = ArrayIndex + 1
                    Next

                    ArrayIndex = 0

                    'Get Raw Material Data from PO
                    Dim GetCoilCarbon, GetCoilSize, GetCoilDescription As String

                    Dim GetCoilCarbonStatement As String = "SELECT Carbon FROM SteelPurchaseLineQuery WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber"
                    Dim GetCoilCarbonCommand As New SqlCommand(GetCoilCarbonStatement, con)
                    GetCoilCarbonCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = SteelFileArray(9)
                    GetCoilCarbonCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = 1

                    Dim GetCoilSizeStatement As String = "SELECT SteelSize FROM SteelPurchaseLineQuery WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber"
                    Dim GetCoilSizeCommand As New SqlCommand(GetCoilSizeStatement, con)
                    GetCoilSizeCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = SteelFileArray(9)
                    GetCoilSizeCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = 1

                    Dim GetCoilDescriptionStatement As String = "SELECT Description FROM SteelPurchaseLineQuery WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber"
                    Dim GetCoilDescriptionCommand As New SqlCommand(GetCoilDescriptionStatement, con)
                    GetCoilDescriptionCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = SteelFileArray(9)
                    GetCoilDescriptionCommand.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = 1

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetCoilCarbon = CStr(GetCoilCarbonCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetCoilCarbon = ""
                    End Try
                    Try
                        GetCoilSize = CStr(GetCoilSizeCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetCoilSize = ""
                    End Try
                    Try
                        GetCoilDescription = CStr(GetCoilDescriptionCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetCoilDescription = ""
                    End Try
                    con.Close()

                    If SteelFileArray(0) = "" Or GetCoilCarbon = "" Or GetCoilSize = "" Or SteelFileArray(9) = "" Then
                        MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    'Insert Into Steel Coil Table
                    cmd = New SqlCommand("INSERT INTO CharterSteelCoilIdentification (CoilID, HeatNumber, Weight, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, Status, Location, InventoryID, AnnealLot, Comment) Values (@CoilID, @HeatNumber, @Weight, @LotNumber, @Carbon, @SteelSize, @ReceiveDate, @DespatchNumber, @SalesOrderNumber, @PurchaseOrderNumber, @Description, @Status, @Location, @InventoryID, @AnnealLot, @Comment)", con)

                    With cmd.Parameters
                        .Add("@CoilID", SqlDbType.VarChar).Value = SteelFileArray(0)
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = SteelFileArray(1)
                        .Add("@Weight", SqlDbType.VarChar).Value = SteelFileArray(2)
                        .Add("@LotNumber", SqlDbType.VarChar).Value = SteelFileArray(3)
                        .Add("@Carbon", SqlDbType.VarChar).Value = GetCoilCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = GetCoilSize
                        .Add("@ReceiveDate", SqlDbType.VarChar).Value = Today()
                        .Add("@DespatchNumber", SqlDbType.VarChar).Value = SteelFileArray(7)
                        .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SteelFileArray(8)
                        .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = SteelFileArray(9)
                        .Add("@Description", SqlDbType.VarChar).Value = GetCoilDescription
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Location", SqlDbType.VarChar).Value = ""
                        .Add("@InventoryID", SqlDbType.VarChar).Value = ""
                        .Add("@AnnealLot", SqlDbType.VarChar).Value = ""
                        .Add("@Comment", SqlDbType.VarChar).Value = "Manual Upload"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("File uploaded.", MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    'Skip
                    MsgBox("File failed to upload. Coils may already be uploaded. Contact system Admin.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End Try
            End While
        End Using
    End Sub

    Private Sub cmdResetShipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetShipment.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to reset this shipment for posting?", "RESET SHIPMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then

            Dim ResetShipmentNumber As Integer = 0
            Dim ResetDivisionID As String = ""
            Dim ResetShipmentStatus As String = ""

            'Check Shipping Data
            Dim CheckShipDivisionStatement As String = "SELECT DivisionID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim CheckShipDivisionCommand As New SqlCommand(CheckShipDivisionStatement, con)
            CheckShipDivisionCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ResetDivisionID = CStr(CheckShipDivisionCommand.ExecuteScalar)
            Catch ex As Exception
                ResetDivisionID = ""
            End Try
            con.Close()

            ResetShipmentNumber = Val(txtShipmentNumber.Text)

            If txtShipmentDivision.Text = "" Or ResetDivisionID = "" Or txtShipmentDivision.Text <> ResetDivisionID Then
                MsgBox("Invalid division or does not match shipment.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Check status of the shipment
                Dim CheckShipStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
                Dim CheckShipStatusCommand As New SqlCommand(CheckShipStatusStatement, con)
                CheckShipStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ResetShipmentNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ResetShipmentStatus = CStr(CheckShipStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    ResetShipmentStatus = ""
                End Try
                con.Close()

                If ResetShipmentStatus <> "PENDING" Then
                    MsgBox("Only a pending shipment can be reset.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If

                Try
                    'Delete Inventory Transaction Numbers
                    cmd = New SqlCommand("DELETE FROM InventoryTransactionTable WHERE TransactionTypeNumber = @TransactionTypeNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = ResetShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = ResetDivisionID
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Delete GL Transaction Numbers
                    cmd = New SqlCommand("DELETE FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ResetShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = ResetDivisionID
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Update Shipment Line Numbers
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ResetShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = ResetDivisionID
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditShipmentNumber As Integer = 0
                    Dim strShipmentNumber As String = ""

                    AuditShipmentNumber = Val(txtShipmentNumber.Text)
                    strShipmentNumber = CStr(AuditShipmentNumber)
                    AuditComment = "Shipment #" + strShipmentNumber + " was reset for posting on " + Today()

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "SHIPMENT RESET"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strShipmentNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex5 As Exception
                        'Skip
                    End Try

                    MsgBox("Shipment has been reset and can be posted again.", MsgBoxStyle.OkOnly)

                    txtShipmentDivision.Clear()
                    txtShipmentNumber.Clear()
                Catch ex As Exception
                    'Error Log
                    Dim TempShipmentNumber As Integer = 0
                    Dim strShipmentNumber As String = ""
                    TempShipmentNumber = Val(txtShipmentNumber.Text)
                    strShipmentNumber = CStr(TempShipmentNumber)

                    ErrorDate = Today()
                    ErrorComment = "Failed to reset shipment"
                    ErrorDivision = ResetDivisionID
                    ErrorDescription = "Database Utilities - Reset Shipment"
                    ErrorReferenceNumber = "Shipment # " + strShipmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        ElseIf button = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub cmdResetClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetClear.Click
        txtShipmentDivision.Clear()
        txtShipmentNumber.Clear()

    End Sub

    Private Sub cmdChangePart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePart.Click
        'Validate - make sure Part Number Two Exists - if not, create it
        Dim CheckPartNumber As String = ""
        Dim CountPartNumber As Integer = 0





        If txtPartNumberOne.Text = "" Or txtPartNumberTwo.Text = "" Then
            MsgBox("You need a valid part #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check if part exists
        Dim CountPartNumberStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CountPartNumberCommand As New SqlCommand(CountPartNumberStatement, con)
        CountPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
        CountPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountPartNumber = CInt(CountPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CountPartNumber = 0
        End Try
        con.Close()

        If CountPartNumber = 0 Then
            'Update existing part to current part
            cmd = New SqlCommand("UPDATE ItemList SET ItemID = @ItemID WHERE DivisionID = @DivisionID AND ItemID = @ItemID2", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@ItemID2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Delete old part number
            cmd = New SqlCommand("DELETE FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID2", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@ItemID2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If

        Try
            'Run routines to change every instance of Part Number One
            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET ItemID = @ItemID WHERE DivisionID = @DivisionID AND ItemID = @ItemID2", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@ItemID2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE PickListLineTable SET ItemID = @ItemID WHERE DivisionID = @DivisionID AND ItemID = @ItemID2", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@ItemID2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ShipmentLineTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InvoiceLineTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InventoryCosting SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InventoryTransactionTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ReceivingLineTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ReturnProductLineTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE VendorReturnLine SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE RackingTransactionTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE FOXTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ItemPriceSheet SET PartNumber = @PartNumber WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber2", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
            cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Try
                cmd = New SqlCommand("UPDATE AssemblyLineTable SET ComponentPartNumber = @ComponentPartNumber WHERE DivisionID = @DivisionID AND ComponentPartNumber = @ComponentPartNumber2", con)
                cmd.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
                cmd.Parameters.Add("@ComponentPartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("UPDATE AssemblyLineTable SET AssemblyPartNumber = @AssemblyPartNumber WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber2", con)
                cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
                cmd.Parameters.Add("@AssemblyPartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET AssemblyPartNumber = @AssemblyPartNumber WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber2", con)
                cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
                cmd.Parameters.Add("@AssemblyPartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("UPDATE AssemblyBuildLineTable SET ComponentPartNumber = @ComponentPartNumber WHERE DivisionID = @DivisionID AND ComponentPartNumber = @ComponentPartNumber2", con)
                cmd.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
                cmd.Parameters.Add("@ComponentPartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET AssemblyPartNumber = @AssemblyPartNumber WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber2", con)
                cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtChangeDivision.Text
                cmd.Parameters.Add("@AssemblyPartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim strPartNumber1 As String
                Dim strPartNumber2 As String
                strPartNumber1 = txtPartNumberOne.Text
                strPartNumber2 = txtPartNumberTwo.Text

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = txtChangeDivision.Text
                ErrorDescription = "Database Utilities --- Update Assembly data"
                ErrorReferenceNumber = "Change part number fail - " + strPartNumber1 + " to " + strPartNumber2
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            If txtChangeDivision.Text = "CHT" Then
                cmd = New SqlCommand("UPDATE FerruleProductionLines SET PartNumber = @PartNumber WHERE PartNumber = @PartNumber2", con)
                cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumberTwo.Text
                cmd.Parameters.Add("@PartNumber2", SqlDbType.VarChar).Value = txtPartNumberOne.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Skip
            End If

            MsgBox("Part Number has been changed.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Log error on update failure
            Dim strPartNumber1 As String
            Dim strPartNumber2 As String
            strPartNumber1 = txtPartNumberOne.Text
            strPartNumber2 = txtPartNumberTwo.Text

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = txtChangeDivision.Text
            ErrorDescription = "Database Utilities --- Update Part Number"
            ErrorReferenceNumber = "Change part number fail - " + strPartNumber1 + " to " + strPartNumber2
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdChangeCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeCustomer.Click
        'Change every instance of the Customer for a specific Division
        Try
            Try
                cmd = New SqlCommand("UPDATE CustomerList SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
                cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip Customer Update in case of duplicate
            End Try

            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET CustomerID = @CustomerID WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE PickListHeaderTable SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE AdditionalShipTo SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*******************************************************************************************************************************************
            cmd = New SqlCommand("UPDATE ARCustomerPayment SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ARPaymentLog SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE CustomerContacts SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE CustomerNotes SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE FOXTable SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************************************************************
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET PODropShipCustomerID = @PODropShipCustomerID WHERE DivisionID = @DivisionID AND PODropShipCustomerID = @PODropShipCustomerID2", con)
            cmd.Parameters.Add("@PODropShipCustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@PODropShipCustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE Quotation SET CustomerID = @CustomerID WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID2", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNewCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerDivision.Text
            cmd.Parameters.Add("@CustomerID2", SqlDbType.VarChar).Value = txtOldCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Customer has been changed.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Log error on update failure
            Dim strCustomer1 As String
            Dim strCustomer2 As String
            strCustomer1 = txtNewCustomerID.Text
            strCustomer2 = txtOldCustomerID.Text

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = txtCustomerDivision.Text
            ErrorDescription = "Database Utilities --- Update Customer"
            ErrorReferenceNumber = "Change Customer fail - " + strCustomer1 + " to " + strCustomer2
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdChangeVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeVendor.Click
        'Change every instance of the Vendor ID for a specific Division
        Try
            cmd = New SqlCommand("UPDATE Vendor SET VendorCode = @VendorCode WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode2", con)
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@VendorCode2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try

        Try
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET VendorID = @VendorID WHERE DivisionID = @DivisionID AND VendorID = @VendorID2", con)
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET VendorCode = @VendorCode WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode2", con)
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@VendorCode2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VendorID = @VendorID WHERE DivisionID = @DivisionID AND VendorID = @VendorID2", con)
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE APCheckLog SET VendorID = @VendorID WHERE DivisionID = @DivisionID AND VendorID = @VendorID2", con)
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE APVoucherTable SET VendorID = @VendorID WHERE DivisionID = @DivisionID AND VendorID = @VendorID2", con)
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE VendorReturn SET VendorID = @VendorID WHERE DivisionID = @DivisionID AND VendorID = @VendorID2", con)
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET SteelVendorID = @SteelVendorID WHERE DivisionID = @DivisionID AND SteelVendorID = @SteelVendorID2", con)
            cmd.Parameters.Add("@SteelVendorID", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@SteelVendorID2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET SteelVendor = @SteelVendor WHERE DivisionID = @DivisionID AND SteelVendor = @SteelVendor2", con)
            cmd.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@SteelVendor2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET SteelVendor = @SteelVendor WHERE DivisionID = @DivisionID AND SteelVendor = @SteelVendor2", con)
            cmd.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@SteelVendor2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ItemList SET PreferredVendor = @PreferredVendor WHERE DivisionID = @DivisionID AND PreferredVendor = @PreferredVendor2", con)
            cmd.Parameters.Add("@PreferredVendor", SqlDbType.VarChar).Value = txtNewVendor.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtVendorDivision.Text
            cmd.Parameters.Add("@PreferredVendor2", SqlDbType.VarChar).Value = txtOldVendor.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Vendor has been changed.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Log error on update failure
            Dim strVendor1 As String
            Dim strVendor2 As String
            strVendor1 = txtNewVendor.Text
            strVendor2 = txtOldVendor.Text

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = txtChangeDivision.Text
            ErrorDescription = "Database Utilities --- Update Vendor"
            ErrorReferenceNumber = "Change Vendor fail - " + strVendor1 + " to " + strVendor2
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub txtChangeDivision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChangeDivision.TextChanged
        If txtChangeDivision.Text = "" Then
            'Do nothing
        Else
            chkChangeAllDivisions.Checked = False
        End If
    End Sub

    Private Sub chkChangeAllDivisions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangeAllDivisions.CheckedChanged
        If chkChangeAllDivisions.Checked = True Then
            txtChangeDivision.Clear()
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdUploadExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadExcel.Click
        'Variables
        Dim ArrayIndex As Integer = 0
        Dim CustomerFileArray(0 To 3) As String
        Dim CustomerFileName As String = ""
        Dim CustomerFileNameAndPath As String = ""
        Dim TempFileName As String = ""
        '*************************************************************************************************
        'Create Unique file name
        Dim FileDate As Date = Now()
        Dim FileMonth As Integer = 0
        Dim FileDay As Integer = 0
        Dim FileMinute As Integer = 0
        Dim FileYear As Integer = 0
        Dim strFileDay As String = ""
        Dim strFileMonth As String = ""
        Dim strFileYear As String = ""
        Dim strFileMinute As String = ""

        FileMonth = FileDate.Month
        FileDay = FileDate.Day
        FileYear = FileDate.Year
        FileMinute = FileDate.Minute

        If FileMonth < 10 Then
            strFileMonth = "0" + CStr(FileMonth)
        Else
            strFileMonth = CStr(FileMonth)
        End If
        If FileDay < 10 Then
            strFileDay = "0" + CStr(FileDay)
        Else
            strFileDay = CStr(FileDay)
        End If

        strFileYear = CStr(FileYear)
        strFileMinute = CStr(FileMinute)

        CustomerFileName = strFileMonth + strFileDay + strFileYear + strFileMinute
        CustomerFileNameAndPath = "\\TFP-FS\TransferData\SalesConfirmations\" + CustomerFileName + ".csv"

        'Open File Dialog Box
        If ofdOpenFlatFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        'Get filename from dialog box
        TempFileName = ofdOpenFlatFile.FileName

        If TempFileName = "" Then
            Exit Sub
        End If

        Try
            'Rename file
            File.Copy(TempFileName, CustomerFileNameAndPath)
        Catch ex As Exception
            'Rename file
            MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
            Exit Sub
        End Try

        'File Created
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'Read from file and write to table
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(CustomerFileNameAndPath)

            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")

            Dim currentRow As String()

            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()

                    Dim currentField As String

                    For Each currentField In currentRow

                        CustomerFileArray(ArrayIndex) = currentField

                        ArrayIndex = ArrayIndex + 1
                    Next

                    If CustomerFileArray(0) = "" Then
                        MsgBox("Customer ID is missing.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    If CustomerFileArray(2) = "" Then
                        'MsgBox("Custom Field is missing.", MsgBoxStyle.OkOnly)
                        'Exit Sub
                    End If

                    'Update Database
                    cmd = New SqlCommand("Update CustomerList SET " + txtUpdateColumn.Text + " = @CustomField WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerFileArray(0)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerUploadDivision.Text
                        .Add("@CustomField", SqlDbType.VarChar).Value = CustomerFileArray(2)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ArrayIndex = 0
                Catch ex As Exception
                    'Skip
                    MsgBox("File failed to upload. Contact system Admin.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End Try
            End While

            MsgBox("File uploaded.", MsgBoxStyle.OkOnly)
        End Using
    End Sub

    Private Sub TestLabelSetup(ByVal labels As Integer)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Boxes (Horizontal Lines)
        LabelFormat(8) = "LO640,0,5,1210"
        LabelFormat(9) = "LO480,0,5,1210"
        LabelFormat(10) = "LO320,0,5,1210"
        LabelFormat(11) = "LO160,0,5,1210"

        'Print Boxes - vertical lines
        LabelFormat(12) = "LO000,900,160,5"
        LabelFormat(13) = "LO160,900,160,5"
        LabelFormat(14) = "LO320,800,160,5"

        labels = 1

        'Fill in stationary fields
        LabelFormat(15) = "A780,10,1,3,2,1,N," & Chr(34) & "PART" & Chr(34)
        LabelFormat(16) = "A620,10,1,3,2,1,N," & Chr(34) & "LOT" & Chr(34)
        LabelFormat(17) = "A460,10,1,3,1,1,N," & Chr(34) & "DESC" & Chr(34)
        LabelFormat(18) = "A380,10,1,3,1,1,N," & Chr(34) & "SUPPLIER" & Chr(34)
        LabelFormat(19) = "A460,810,1,3,1,1,N," & Chr(34) & "QTY" & Chr(34)
        LabelFormat(20) = "A310,10,1,3,1,1,N," & Chr(34) & "PO" & Chr(34)
        LabelFormat(21) = "A310,910,1,3,1,1,N," & Chr(34) & "PO LINE" & Chr(34)
        LabelFormat(22) = "A220,910,1,3,1,1,N," & Chr(34) & "SHIP DATE" & Chr(34)
        LabelFormat(23) = "A140,910,1,3,1,1,N," & Chr(34) & "COO" & Chr(34)

        'Fill in variable fields
        LabelFormat(24) = "A780,160,1,2,5,2,N," & Chr(34) & "AF263763" & Chr(34)
        LabelFormat(25) = "A620,160,1,2,5,2,N," & Chr(34) & "2181821355" & Chr(34)
        LabelFormat(26) = "A460,160,1,3,2,1,N," & Chr(34) & "1/2-20 UNF X 28MM WITH 15.9MM HEX" & Chr(34)
        LabelFormat(27) = "A380,160,1,3,2,1,N," & Chr(34) & "TRUFIT PRODUCTS DIVISION" & Chr(34)
        LabelFormat(28) = "A460,920,1,3,2,2,N," & Chr(34) & "450" & Chr(34)
        LabelFormat(29) = "A310,160,1,3,2,2,N," & Chr(34) & "155648" & Chr(34)
        LabelFormat(30) = "A310,1060,1,3,2,1,N," & Chr(34) & "001" & Chr(34)
        LabelFormat(31) = "A220,1060,1,3,2,1,N," & Chr(34) & "02/09/2021" & Chr(34)
        LabelFormat(32) = "A140,1060,1,3,2,2,N," & Chr(34) & "US" & Chr(34)

        'Fill in barcode fields
        LabelFormat(33) = "B700,160,1,3,2,4,40,N," & Chr(34) & "AF263763" & Chr(34)
        LabelFormat(34) = "B540,160,1,3,2,4,40,N," & Chr(34) & "2181821355" & Chr(34)
        LabelFormat(35) = "B230,160,1,3,2,4,40,N," & Chr(34) & "155648" & Chr(34)
        LabelFormat(36) = "B380,920,1,3,2,4,40,N," & Chr(34) & "450" & Chr(34)
        LabelFormat(37) = "B060,1000,1,3,2,4,40,N," & Chr(34) & "US" & Chr(34)
        LabelFormat(38) = "b060,160,P,900,200," & Chr(34) & "ABCDEFGHIJLLMNOP" & Chr(34)


        'Print Label
        LabelFormat(39) = "P" + labels.ToString()
        LabelFormat(40) = vbFormFeed
        LabelLines = 40

    End Sub

    Private Sub PrintBarcodeLine(ByVal labels As Integer)
        ' Click event handler for a button - designed to show how to use the
        ' SendBytesToPrinter function to send a string to the printer.

        Dim s As String = ""
        Dim pd As New PrintDialog()
        Dim i As Integer
        pd.UseEXDialog = True
        pd.PrinterSettings = New PrinterSettings()
        Dim printers(pd.PrinterSettings.InstalledPrinters.Count) As [String]
        pd.PrinterSettings.InstalledPrinters.CopyTo(printers, 0)
        pd.PrinterSettings.PrinterName = ""
        ''checks to see if the designated printer is present
        While i < printers.Count() - 1
            If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains("Zebra" + EmployeeCompanyCode) Then
                pd.PrinterSettings.PrinterName = printers(i)
            End If
            i += 1
        End While
        ''checks to see if a printer was selected and if not will show the dialog
        If String.IsNullOrEmpty(pd.PrinterSettings.PrinterName) Then
            ' Open the printer dialog box, and then allow the user to select a printer.
            If pd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sendToPrinter(pd.PrinterSettings.PrinterName)
            End If
        Else
            sendToPrinter(pd.PrinterSettings.PrinterName)
        End If
    End Sub

    Private Sub sendToPrinter(ByVal printerName As String)
        Dim s As String = ""
        For i = 0 To LabelLines
            ' You need a string to send.
            s += LabelFormat(i) + Environment.NewLine
        Next i
        If s <> "" Then
            RawPrinter.SendStringToPrinter(printerName, s)
        End If
    End Sub

    Private Sub cmdPrintTestLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintTestLabel.Click
        TestLabelSetup(1)
        PrintBarcodeLine(1)
    End Sub

    Private Sub cmdTestTrailingZeroes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Convert Double into string value with two decimal places
        Dim strSubjectCheckAmount As String
        strSubjectCheckAmount = txtBeforeDecimal.Text

        If strSubjectCheckAmount.Contains(".") Then
            'Loop to see where the decimal point is
            Dim TotalStringLength As Integer = strSubjectCheckAmount.Length
            Dim CharacterCounter As Integer = 1
            Dim CurrentCharascter As String = ""

            Do Until CurrentCharascter = "."
                CurrentCharascter = strSubjectCheckAmount.Substring(TotalStringLength - CharacterCounter, 1)
                CharacterCounter = CharacterCounter + 1
            Loop

            If CharacterCounter = 4 Then
                'Do nothing - number has two decimals
            ElseIf CharacterCounter = 3 Then
                'Add trailing zero
                strSubjectCheckAmount = strSubjectCheckAmount + "0"
            ElseIf CharacterCounter = 2 Then
                'Ends with a decimal - add the zeroes
                strSubjectCheckAmount = strSubjectCheckAmount + "00"
            Else
                'No decimal - add decimal and the zeroes
                strSubjectCheckAmount = strSubjectCheckAmount + ".00"
            End If
        Else
            strSubjectCheckAmount = strSubjectCheckAmount + ".00"
        End If

        txtAfterDecimal.Text = strSubjectCheckAmount
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewEmailSpecial As New EmailSpecial
        NewEmailSpecial.Show()
    End Sub

    Private Sub cmdResetShipmentDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetShipmentDate.Click
        'Validate fields
        If txtResetShipmentNumber.Text <> "" Then
            'Shipment Number Exists - validate
            Dim CheckShipmentNumber As Integer = 0

            Dim CountInvoiceNumberStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim CountInvoiceNumberCommand As New SqlCommand(CountInvoiceNumberStatement, con)
            CountInvoiceNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckShipmentNumber = CInt(CountInvoiceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CheckShipmentNumber = 0
            End Try
            con.Close()

            If CheckShipmentNumber = 0 Then
                MsgBox("This shipment does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing - continue
            End If
            '********************************************

            'Change Shipment Date, Inventory Transaction Date, and GL Post Date for Shipment

            'Update Shipment
            cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipDate = @ShipDate WHERE ShipmentNumber = @ShipmentNumber", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************
            'Update Inventory Transaction Table
            cmd = New SqlCommand("Update InventoryTransactionTable SET TransactionDate = @TransactionDate WHERE TransactionTypeNumber = @TransactionTypeNumber", con)

            With cmd.Parameters
                .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)
                .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************
            'Update GL Transaction Table
            cmd = New SqlCommand("Update GLTransactionMasterList SET GLTransactionDate = @GLTransactionDate WHERE GLReferenceNumber = @GLReferenceNumber", con)

            With cmd.Parameters
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Do nothing - no shipment to reset
        End If

        '***********************************************************************************************************************************************************

        'Reset the Invoice (If it exists)
        If txtResetInvoiceNumber.Text <> "" Then
            'Shipment Number Exists - validate
            Dim CheckInvoiceNumber As Integer = 0

            Dim CountInvoiceNumberStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
            Dim CountInvoiceNumberCommand As New SqlCommand(CountInvoiceNumberStatement, con)
            CountInvoiceNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckInvoiceNumber = CInt(CountInvoiceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CheckInvoiceNumber = 0
            End Try
            con.Close()

            If CheckInvoiceNumber = 0 Then
                MsgBox("This invoice does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing - continue
            End If
            '********************************************

            'Change Invoice Date and GL Post Date for Invoice

            'Update Invoice
            cmd = New SqlCommand("Update InvoiceHeaderTable SET InvoiceDate = @InvoiceDate WHERE InvoiceNumber = @InvoiceNumber", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************
            'Update GL Transaction Table
            cmd = New SqlCommand("Update GLTransactionMasterList SET GLTransactionDate = @GLTransactionDate WHERE GLReferenceNumber = @GLReferenceNumber", con)

            With cmd.Parameters
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Do nothing - no invoice to reset
        End If

        MsgBox("Shipment and/or Invoice is reset to the date selected.", MsgBoxStyle.OkOnly)

        cmdClearReset_Click(sender, e)

    End Sub

    Private Sub txtResetShipmentNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResetShipmentNumber.TextChanged
        If Val(txtResetShipmentNumber.Text) = 0 Then
            'skip loading the Invoice
        Else
            'Load Invoice Number (if invoice exists)
            Dim ResetInvoiceNumber As Integer = 0

            Dim GetInvoiceNumberStatement As String = "SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim GetInvoiceNumberCommand As New SqlCommand(GetInvoiceNumberStatement, con)
            GetInvoiceNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ResetInvoiceNumber = CInt(GetInvoiceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ResetInvoiceNumber = 0
            End Try
            con.Close()

            If ResetInvoiceNumber = 0 Then
                'Do nothing
            Else
                txtResetInvoiceNumber.Text = ResetInvoiceNumber
            End If
        End If
    End Sub

    Private Sub txtResetInvoiceNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResetInvoiceNumber.TextChanged
        If Val(txtResetInvoiceNumber.Text) = 0 Then
            'Skip loading the shipment
        Else
            'Load Shipment Number (if shipment exists)
            Dim ResetShipmentNumber As Integer = 0

            Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
            Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
            GetShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ResetShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ResetShipmentNumber = 0
            End Try
            con.Close()

            If ResetShipmentNumber = 0 Then
                'Do nothing
            Else
                txtResetShipmentNumber.Text = ResetShipmentNumber
            End If
        End If
    End Sub

    Private Sub cmdClearReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearReset.Click
        txtResetInvoiceNumber.Clear()
        txtResetShipmentNumber.Clear()
        dtpResetDate.Value = Today()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim NewDailySalesForm As New DailySalesForYear
        NewDailySalesForm.Show()
    End Sub

End Class