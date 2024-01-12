Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Diagnostics.Eventing.Reader
Imports System.Text
Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class MOSRemoteWIA
    Public tempFile As New FileInfo(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIAScanned.pdf")

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Public Class StateObject
        'Client  socket
        Public workSocket As Socket = Nothing
        'Size of receive buffer
        Public Const BufferSize As Integer = 1024
        'Receive buffer
        Public buffer As Byte() = New Byte(BufferSize) {}
        'Received data string
        Public sb As New StringBuilder()
        ''Raw list of bytes received 
        Public FileBytes As Byte()
    End Class

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet

    Private Const FTPServerDir As String = "\\192.168.1.31\Inetpub\ftproot\UploadedPDF\"
    Private bgwk As System.ComponentModel.BackgroundWorker

    'The port number for the remote device
    Private Const port As Integer = 39155
    Private client As Socket

    Private identNumber As Integer

    'ManualResetEvent instances signal completion
    Private connectDone As New ManualResetEvent(False)
    Private sendDone As New ManualResetEvent(False)
    Private CommandSent As New ManualResetEvent(False)

    Private FileReceived As New ManualResetEvent(False)
    Private AknowledgementReceived As New ManualResetEvent(False)
    Private FileSizeSent As New ManualResetEvent(False)
    Private PrinterSelectionSent As New ManualResetEvent(False)
    Private ReceiveErrorOrResponseHold As New ManualResetEvent(False)

    'The response from the remote device
    Private response As String = String.Empty
    Private FileUploaded As Boolean = False
    Private FileSize As Integer = 0

    Private Confirmed As Boolean = True
    Public TotalPages As Integer = 0
    Private PrinterSelectCancelled As Boolean = False
    Private PrinterWasSelected As Boolean = False
    Private ResetAll As Boolean = False
    Private CurrentlyAwaiting As String = "Nothing"

    Private tmrConnectionTimer As New System.Timers.Timer(30000)
    Private Attempts As Integer = 1
    Private tmrWaitTimer As New System.Timers.Timer(10000)
    Private FileBytes As Byte()

    Private tmrMaxConnectionTime As New System.Timers.Timer(120000)

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        'Insert Data into error log
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

    Public Sub New(ByVal bg As System.ComponentModel.BackgroundWorker, ByVal id As Integer)
        bgwk = bg
        identNumber = id
    End Sub

    Public Sub StartClient()
        bgwk.ReportProgress(0)
        AddHandler tmrConnectionTimer.Elapsed, AddressOf ConnectionTimer_Tick
        AddHandler tmrWaitTimer.Elapsed, AddressOf tmrFileWaitTimer_Tick
        AddHandler tmrMaxConnectionTime.Elapsed, AddressOf tmrMaxConnectionTime_Tick
        Dim UserIP As String = GetLastIPAddress()
        'Dim UserIP As String = ""

        ''Get IP Address From Database
        'Dim GetIPString As String = "SELECT IPAddress FROM EmployeeData WHERE LoginName = @LoginName"
        'Dim GetIPCommand As New SqlCommand(GetIPString, con)
        'GetIPCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        'If con.State = ConnectionState.Closed Then con.Open()
        'Try
        '    UserIP = CStr(GetIPCommand.ExecuteScalar)
        'Catch ex As System.Exception
        '    UserIP = "NONE"
        'End Try
        'con.Close()

        If Not UserIP.Equals("NONE") Then
            Console.WriteLine("Attempting to connect to IP " + UserIP + " on port " + port.ToString)
            Try
                Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(UserIP)
                Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)
                Dim remoteEP As IPEndPoint = New IPEndPoint(ipAddress, port)

                client = New Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                tmrConnectionTimer.Start()
                client.BeginConnect(remoteEP, New AsyncCallback(AddressOf ConnectCallback), client)
                connectDone.WaitOne()

                If client.Connected Then
                    tmrMaxConnectionTime.Start()
                    tmrConnectionTimer.Stop()
                    ''AKNOWLEDGEMENT FOR CONNECTION
                    ReceiveAknowledgement(client)
                    AknowledgementReceived.WaitOne()
                    AknowledgementReceived.Reset()
                    ''SEND COMMAND
                    SendCommand(client, "<MOS><ID>" + identNumber.ToString() + "</ID><Command>SCAN</Command></MOS>")
                    CommandSent.WaitOne()
                    CommandSent.Reset()
                    ''AKNOWLEDGEMENT FOR COMMAND
                    ReceiveAknowledgement(client)
                    AknowledgementReceived.WaitOne()
                    AknowledgementReceived.Reset()
                    ''WAIT FOR RESPONSE OF ERROR OR SCANNING COMPLETED
                    CurrentlyAwaiting = "ErrorOrResponse"
                    tmrWaitTimer.Start()
                    ReceiveErrorOrResponse(client)
                    ReceiveErrorOrResponseHold.WaitOne()
                    If tmrWaitTimer.Enabled Then tmrWaitTimer.Stop()
                    ''Check to see if the operation was cancelled
                    If Not ResetAll Then
                        CurrentlyAwaiting = "File"
                        Attempts = 1
                        ''Check to see if greater than 20 seconds
                        If 10000 * TotalPages > 20000 Then
                            ''Clamping the max wait time at 40 seconds
                            If 1000 * TotalPages > 40000 Then
                                tmrWaitTimer.Interval = 40000
                            Else
                                tmrWaitTimer.Interval = 10000 * TotalPages
                            End If
                        Else
                            tmrWaitTimer.Interval = 20000
                        End If
                        ''Resets the max connection timer to 2 minutes
                        tmrMaxConnectionTime.Stop()
                        tmrMaxConnectionTime.Interval = tmrWaitTimer.Interval + 60000
                        tmrMaxConnectionTime.Start()

                        ''Starting timer and starting wait for file transfer confirmation
                        tmrWaitTimer.Start()
                        ReceiveFile(client)
                        FileReceived.WaitOne()
                        If tmrWaitTimer.Enabled Then tmrWaitTimer.Stop()
                    End If
                    tmrMaxConnectionTime.Stop()
                    client.Shutdown(SocketShutdown.Both)
                    client.Close()
                Else
                    ErrorComment = "Client - (" + client.ToString() + ")" + " - " + My.Computer.Name
                    ErrorDate = Today()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Line 192 - IP Host - " + ipHostInfo.ToString() + " - Remote EP - " + remoteEP.ToString() + " - IP Address - " + ipAddress.ToString()
                    ErrorUser = EmployeeLoginName
                    ErrorReferenceNumber = ""

                    Try
                        TFPErrorLogUpdate()
                    Catch ex As System.Exception
                        MsgBox("Error Log Update Failed (L199).", MsgBoxStyle.OkOnly)
                    End Try

                    MessageBox.Show("Unable to connect to local system to scan (L198).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As System.Exception
                Console.WriteLine(ex.ToString())
            End Try
        Else
            Console.WriteLine("No valid IP address was found for the current user.")
        End If
    End Sub

    Private Sub ConnectionTimer_Tick(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
        connectDone.Set()
    End Sub

    Private Sub tmrFileWaitTimer_Tick(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
        ''Checks to see how many times the operation has tried to complete.
        If Attempts <= 3 Then
            Attempts += 1
            Select Case CurrentlyAwaiting
                Case "File"
                    SendCommand(client, "<MOS><Command>ReSend File</Command></MOS>")
                    CommandSent.WaitOne()
                    CommandSent.Reset()
            End Select

            tmrWaitTimer.Start()
        Else
            ResetAll = True
            Select Case CurrentlyAwaiting
                Case "ErrorOrResponse"
                    ReceiveErrorOrResponseHold.Set()
                Case "File"
                    FileReceived.Set()
            End Select
        End If
    End Sub

    Private Sub tmrMaxConnectionTime_Tick(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
        Try
            FileBytes = Nothing
            connectDone.Set()
            sendDone.Set()
            CommandSent.Set()

            FileReceived.Set()
            AknowledgementReceived.Set()
            FileSizeSent.Set()
            PrinterSelectionSent.Set()
            ReceiveErrorOrResponseHold.Set()

            client.Shutdown(SocketShutdown.Both)
            client.Close()

        Catch ex As System.Exception
            Dim test As String = ""
        End Try
        MessageBox.Show("File transfer took to long. Connection has been closed.", "Connection closed", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub ConnectCallback(ByVal ar As IAsyncResult)
        Try
            'Retrieve the socket from the state object
            Dim client As Socket = CType(ar.AsyncState, Socket)

            'Complete the connection
            client.EndConnect(ar)

            Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString())

            'Signal that the connection has been made
            connectDone.Set()
        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
        End Try
    End Sub

    Private Sub ReceiveAknowledgement(ByVal client As Socket)
        Console.WriteLine("Awaiting Aknowledgement")
        Try
            'Create the state object
            Dim state As New StateObject()
            state.workSocket = client
            'Begin receiving the data from the remote device
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveAknowledgementCallback), state)

        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
        End Try
    End Sub

    Private Sub ReceiveAknowledgementCallback(ByVal ar As IAsyncResult)
        Try
            'Retrieve the state object and the client socket from the asynchronous state object
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim client As Socket = state.workSocket

            'Read data from the remote device
            Dim bytesRead As Integer = client.EndReceive(ar)

            If (bytesRead > 0) Then
                Console.WriteLine("Received {0} bytes to client. data: {1}", bytesRead, Encoding.UTF32.GetString(state.buffer, 0, bytesRead))
                'There might be more data, so store the data received so far
                state.sb.Append(Encoding.UTF32.GetString(state.buffer, 0, bytesRead))

                response = state.sb.ToString()
                ''Gets the response from the listening computer
                If (response.IndexOf("</MOS>") > -1) Then
                    If response.Contains("<Response>Connected</Response>") Then
                        bgwk.ReportProgress(1)
                    ElseIf response.Contains("<Response>Scanning Started</Response>") Then
                        bgwk.ReportProgress(2)
                    ElseIf response.Contains("<Response>Scanning Completed</Response>") Then
                        bgwk.ReportProgress(3)
                        TotalPages = CType(response.Substring(response.IndexOf("<Pages>") + 7, response.IndexOf("</Pages>") - (response.IndexOf("<Pages>") + 7)), Integer)
                    ElseIf response.Contains("<Response>Correct Size</Response>") Then
                        Confirmed = True
                        bgwk.ReportProgress(4)
                    Else
                        ResetAll = True
                    End If
                    AknowledgementReceived.Set()
                Else
                    response = String.Empty
                    'Get the rest of the data
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveAknowledgementCallback), state)
                End If
            End If
        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error Line 362", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReceiveErrorOrResponse(ByVal client As Socket)
        Try
            'Create the state object
            Dim state As New StateObject()
            state.workSocket = client
            'Begin receiving the data from the remote device
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveErrorOrResponseCallback), state)

        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error Line 376", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReceiveErrorOrResponseCallback(ByVal ar As IAsyncResult)
        Try
            'Retrieve the state object and the client socket from the asynchronous state object
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim client As Socket = state.workSocket

            'Read data from the remote device
            Dim bytesRead As Integer = client.EndReceive(ar)

            If (bytesRead > 0) Then
                'Console.WriteLine("Sent {0} bytes to client.", bytesRead)
                'There might be more data, so store the data received so far
                state.sb.Append(Encoding.UTF32.GetString(state.buffer, 0, bytesRead))

                response = state.sb.ToString()
                If (response.IndexOf("</MOS>") > -1) Then
                    Console.WriteLine("Read {0} bytes from socket.", response.Length)
                    If response.IndexOf("<Error>") > -1 Then
                        MessageBox.Show(response.Substring(response.IndexOf("<Error>") + 7, response.IndexOf("</Error>") - (response.IndexOf("<Error>") + 7)), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Console.WriteLine(response.Substring(response.IndexOf("<Error>") + 7, response.IndexOf("</Error>") - (response.IndexOf("<Error>") + 7)))
                        ResetAll = True
                        ReceiveErrorOrResponseHold.Set()
                        ''For if we have to do a printer selection. This will show the printers and let the user decide which one to use.
                    ElseIf response.IndexOf("<Printers>") > -1 Then
                        Dim names As String() = response.Substring(response.IndexOf("<Printers>") + 10, response.IndexOf("</Printers>") - (response.IndexOf("<Printers>") + 10)).Split(",")
                        response = String.Empty
                        Dim WIAScanner As New WIAScannerSelection(names)
                        If WIAScanner.ShowDialog() = DialogResult.OK Then
                            PrinterWasSelected = True
                            SendPrinterSelected(client, "<MOS><SelectedPrinter>" + WIAScanner.SelectedPrinterName + "</SelectedPrinter></MOS>")
                            PrinterSelectionSent.WaitOne()
                            ReceiveErrorOrResponse(client)
                        ElseIf WIAScanner.DialogResult = DialogResult.Cancel Then
                            SendPrinterSelected(client, "<MOS><Cancelled></Cancelled></MOS>")
                            PrinterSelectionSent.WaitOne()
                            ResetAll = True
                            ReceiveErrorOrResponseHold.Set()
                        End If
                        ''Listening computer will send this once the scannign has completed.
                    ElseIf response.IndexOf("<Response>Scanning Completed</Response>") > -1 Then
                        bgwk.ReportProgress(3)
                        TotalPages = CType(response.Substring(response.IndexOf("<Pages>") + 7, response.IndexOf("</Pages>") - (response.IndexOf("<Pages>") + 7)), Integer)
                        ReceiveErrorOrResponseHold.Set()
                    End If
                Else
                    response = String.Empty
                    'Get the rest of the data
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveErrorOrResponseCallback), state)
                End If
            End If
        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error - Line 433", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReceiveFile(ByVal client As Socket)
        Try
            'Create the state object
            Dim state As New StateObject()
            state.workSocket = client
            'Begin receiving the data from the remote device
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveFileCallback), state)

        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error - Line 447", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReceiveFileCallback(ByVal ar As IAsyncResult)
        Try
            'Retrieve the state object and the client socket from the asynchronous state object
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim client As Socket = state.workSocket

            'Read data from the remote device
            Dim bytesRead As Integer = client.EndReceive(ar)

            If (bytesRead > 0) Then
                'Console.WriteLine("Sent {0} bytes to client.", bytesRead)
                'There might be more data, so store the data received so far
                state.sb.Append(Encoding.UTF32.GetString(state.buffer, 0, bytesRead))

                response = state.sb.ToString()
                If (response.IndexOf("</MOS>") > -1) Then
                    Console.WriteLine("Read {0} bytes from socket.", response.Length)
                    If response.IndexOf("<Response>File Uploaded</Response>") > -1 Then
                        If File.Exists(FTPServerDir + identNumber.ToString() + ".pdf") Then
                            FileUploaded = True
                            SendCommand(client, "<MOS><Response>File Confirmed</Response></MOS>")
                            CommandSent.WaitOne()
                            CommandSent.Reset()
                            FileReceived.Set()
                        Else
                            If Attempts <= 3 Then
                                Attempts += 1
                                SendCommand(client, "<MOS><Command>ReSend File</Command></MOS>")
                                CommandSent.WaitOne()
                                CommandSent.Reset()

                                state.sb = New StringBuilder
                                response = String.Empty
                                'Get the rest of the data
                                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveFileCallback), state)
                            Else
                                SendCommand(client, "<MOS><Response>File not found</Response></MOS>")
                                CommandSent.WaitOne()
                                CommandSent.Reset()
                                FileReceived.Set()
                            End If
                        End If
                    End If
                Else
                    response = String.Empty
                    'Get the rest of the data
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveFileCallback), state)
                End If
            End If
        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error - Line 502", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SendCommand(ByVal client As Socket, ByVal data As String)
        Console.WriteLine("Sending command: " + data)
        'Convert the string data to byte data using ASCII encoding
        Dim byteData As Byte() = Encoding.UTF32.GetBytes(data)
        'Begin sending the data to the remote devicetry
        Try
            client.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCommandCallback), client)
        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub SendCommandCallback(ByVal ar As IAsyncResult)
        Try
            'Retrieve the socket from the state object
            Dim client As Socket = CType(ar.AsyncState, Socket)
            'Complete sending the data to the remote device
            Dim bytesSent As Integer = client.EndSend(ar)
            Console.WriteLine("Sent {0} bytes to server.", bytesSent)
            'Signal that all bytes have been sent
            CommandSent.Set()
        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error - Line 529", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SendFileSize(ByVal client As Socket, ByVal data As String)
        Console.WriteLine("Sending data: {0}", data)
        'Convert the string data to byte data using ASCII encoding
        Dim byteData As Byte() = Encoding.UTF32.GetBytes(data)
        'Begin sending the data to the remote device
        client.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendFileSizeCallback), client)
    End Sub

    Private Sub SendFileSizeCallback(ByVal ar As IAsyncResult)
        Try
            'Retrieve the socket from the state object
            Dim client As Socket = CType(ar.AsyncState, Socket)
            'Complete sending the data to the remote device
            Dim bytesSent As Integer = client.EndSend(ar)
            Console.WriteLine("Sent {0} bytes to server.", bytesSent)
            'Signal that all bytes have been sent
            FileSizeSent.Set()
        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error - Line 552", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SendPrinterSelected(ByVal client As Socket, ByVal data As String)
        Console.WriteLine("Sending command: " + data)
        'Convert the string data to byte data using ASCII encoding
        Dim byteData As Byte() = Encoding.UTF32.GetBytes(data)
        'Begin sending the data to the remote device
        client.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendPrinterSelectedCallback), client)
    End Sub

    Private Sub SendPrinterSelectedCallback(ByVal ar As IAsyncResult)
        Try
            'Retrieve the socket from the state object
            Dim client As Socket = CType(ar.AsyncState, Socket)
            'Complete sending the data to the remote device
            Dim bytesSent As Integer = client.EndSend(ar)
            Console.WriteLine("Sent {0} bytes to server.", bytesSent)
            'Signal that all bytes have been sent 
            PrinterSelectionSent.Set()
        Catch ex As System.Exception
            Console.WriteLine(ex.ToString())
            MessageBox.Show(ex.ToString(), "Error - Line 575", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function SaveFile(ByVal FullFileName As String) As Boolean
        If FileUploaded Then
            File.Copy(FTPServerDir + identNumber.ToString + ".pdf", FullFileName, True)
            Return True
        End If
        Return False
    End Function

    Public Function PageCount() As String
        Return TotalPages.ToString()
    End Function
End Class
