Imports System
Imports System.Windows.Forms
Imports System.Net.Mail
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class MainInterface
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    '***************************************************
    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    '***************************************************
    'Variables for Shipping Timer and Invoice email timer
    'Get current time in minutes
    Dim CurrentDate As Date = Now()
    Dim CurrentHour As Integer = CurrentDate.Hour
    Dim CurrentMinute As Integer = CurrentDate.Minute
    Dim DefineNumberOfMinutes As Integer = 0
    Dim HourDifference As Integer = 0
    Dim HoursToMinutes As Integer = 0
    Dim TimerCounter As Integer = 0
    Dim MinutesLeftInHour As Integer = 0
    '***************************************************

    Dim newNotificationAlert As NotificationAlert

    Private Const MOD_ALT As Integer = &H1 'Alt key
    Private Const MOD_CONTROL As Integer = &H2 'Control Key
    Private Const MOD_SHIFT As Integer = &H4 'Shift Key
    Private Const WM_HOTKEY As Integer = &H312

    Private Declare Function RegisterHotKey Lib "User32" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Private Declare Function UnregisterHotKey Lib "User32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_HOTKEY Then

            Select Case CInt(m.WParam)
                Case 1100
                    'Control Q
                    Dim NewSOForm As New SOForm
                    NewSOForm.Show()
                Case 1101
                    'Control W
                    Dim NewPOForm As New POForm
                    NewPOForm.Show()
                Case 1102
                    'Control E
                    Dim NewCustomerData As New CustomerData
                    NewCustomerData.Show()
                Case 1103
                    'Control R
                    Dim NewViewShipmentStatus As New ViewShipmentStatus
                    NewViewShipmentStatus.Show()
                Case 1104
                    'Control T
                    Dim NewVendorInformation As New VendorInformation
                    NewVendorInformation.Show()
                Case 1105
                    'Control Y
                    Dim NewItemMaintenance As New ItemMaintenance
                    NewItemMaintenance.Show()
                Case 1106
                    'Control U
                    Dim FoundForm As Boolean = False

                    For Each OpenForm As Form In Application.OpenForms
                        If TypeOf OpenForm Is ShipmentCompletion Then
                            OpenForm.BringToFront()
                            OpenForm.WindowState = FormWindowState.Normal
                            OpenForm.Focus()
                            FoundForm = True
                        End If
                    Next

                    If Not FoundForm Then
                        GlobalDivisionCode = EmployeeCompanyCode
                        Dim NewShipmentCompletion As New ShipmentCompletion
                        NewShipmentCompletion.Show()
                    End If
                Case 1107
                    'Control I
                    If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1003 Or EmployeeSecurityCode = 1004 Or EmployeeSecurityCode = 1014 Then
                        Dim FoundForm As Boolean = False

                        For Each OpenForm As Form In Application.OpenForms
                            If TypeOf OpenForm Is ARProcessBatch Then
                                OpenForm.BringToFront()
                                OpenForm.WindowState = FormWindowState.Normal
                                OpenForm.Focus()
                                FoundForm = True
                            End If
                        Next

                        If Not FoundForm Then
                            Dim NewARProcessBatch As New ARProcessBatch
                            NewARProcessBatch.Show()
                        End If
                    Else
                        'Do nothing - do not open form
                    End If
                Case 1108
                    'Control O
                    Dim NewReceiving As New Receiving
                    NewReceiving.Show()
                Case 1200
                    'F1
                    Dim NewSOForm As New SOForm
                    NewSOForm.Show()
                Case 1201
                    'F2
                    Dim NewInventoryStatus As New InventoryStatus
                    NewInventoryStatus.Show()
                Case 1202
                    'F3
                    Dim NewCustomerData As New CustomerData
                    NewCustomerData.Show()
                Case 1203
                    'F4
                    Dim NewItemMaintenance As New ItemMaintenance
                    NewItemMaintenance.Show()
                Case 1204
                    'F5
                    Dim NewDivisionLookupForm As New DivisionLookupForm
                    NewDivisionLookupForm.Show()
                Case 1205
                    'F6
                    Dim NewCheckShipmentWeight As New CheckShipmentWeight
                    NewCheckShipmentWeight.Show()
                Case 1206
                    'F7
                    Dim NewShipmentCheckFreight As New ShipmentCheckFreight
                    NewShipmentCheckFreight.Show()
                Case 1207
                    'F8
                    Dim NewQuoteForm As New QuoteForm
                    NewQuoteForm.Show()
                Case 1208
                    'F9
                    If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Or EmployeeCompanyCode = "SLC" Then
                        Dim NewRackingPopup As New RackingPopup
                        NewRackingPopup.Show()
                    Else
                        'Do not open popup - no racking
                    End If
                Case 1209
                    'F10
                    Dim NewItemLookup As New ItemLookup
                    NewItemLookup.Show()
                Case 1210
                    'F11
                    Dim NewPriceLookup As New PriceLookup
                    NewPriceLookup.Show()
                Case 1211
                    'F12
                    Dim NewOrderTracking As New OrderTracking
                    NewOrderTracking.Show()
                Case 1300
                    'Control Z
                    Dim NewElectronicSchedulingBoard As New ElectronicSchedulingBoard
                    NewElectronicSchedulingBoard.Show()
                Case 1301
                    'Control N
                    Dim NewViewBlueprintPopup As New ViewBlueprintPopup
                    NewViewBlueprintPopup.Show()
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub MainInterface_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()

        LoginPage.ShowDialog()

        tmrNotifications.Start()

        RegisterHotKey(Me.Handle, 1100, MOD_CONTROL, Keys.Q)
        RegisterHotKey(Me.Handle, 1101, MOD_CONTROL, Keys.W)
        RegisterHotKey(Me.Handle, 1102, MOD_CONTROL, Keys.E)
        RegisterHotKey(Me.Handle, 1103, MOD_CONTROL, Keys.R)
        RegisterHotKey(Me.Handle, 1104, MOD_CONTROL, Keys.T)
        RegisterHotKey(Me.Handle, 1105, MOD_CONTROL, Keys.Y)
        RegisterHotKey(Me.Handle, 1106, MOD_CONTROL, Keys.U)
        RegisterHotKey(Me.Handle, 1107, MOD_CONTROL, Keys.I)
        RegisterHotKey(Me.Handle, 1108, MOD_CONTROL, Keys.O)

        RegisterHotKey(Me.Handle, 1200, 0, Keys.F1)
        RegisterHotKey(Me.Handle, 1201, 0, Keys.F2)
        RegisterHotKey(Me.Handle, 1202, 0, Keys.F3)
        RegisterHotKey(Me.Handle, 1203, 0, Keys.F4)
        RegisterHotKey(Me.Handle, 1204, 0, Keys.F5)
        RegisterHotKey(Me.Handle, 1205, 0, Keys.F6)
        RegisterHotKey(Me.Handle, 1206, 0, Keys.F7)
        RegisterHotKey(Me.Handle, 1207, 0, Keys.F8)
        RegisterHotKey(Me.Handle, 1208, 0, Keys.F9)
        RegisterHotKey(Me.Handle, 1209, 0, Keys.F10)
        RegisterHotKey(Me.Handle, 1210, 0, Keys.F11)
        RegisterHotKey(Me.Handle, 1211, 0, Keys.F12)

        RegisterHotKey(Me.Handle, 1300, MOD_CONTROL, Keys.Z)
        RegisterHotKey(Me.Handle, 1301, MOD_CONTROL, Keys.N)

        If GlobalVerifyCode <> "PASSED" Then
            End
        Else
            'Passed verify if enter key is pressed
        End If

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' taSystem.TypeInitializationException: 'The type initializer for 'Microsoft.Data.SqlClient.SqlAuthenticationProviderManager' threw an exception.'
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.EmployeeData' table. You can move, or remove it, as needed.
        Me.EmployeeDataTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.EmployeeData)

        lblTimeLabel.Text = "What time is it now"
        lblLoginLast.Text = LoginLast & " is currently logged in " & EmployeeCompanyCode

        txtLoginName.Clear()
        txtLoginPassword.Clear()

        txtLoginName.Text = EmployeeLoginName
        txtLoginPassword.Text = LoginPassword2

        cboSecurityCode.SelectedIndex = -1
        cboCompanyName.SelectedIndex = -1
        cboLoginName.SelectedIndex = -1
        cboLoginPassword.SelectedIndex = -1
        cboCompanyCode.SelectedIndex = -1
        txtLoginName.Focus()

        LoginPage.Close()

        If Environment.MachineName.ToLower.Contains("wireyard") Then
            LoadWireyardTabletView()
        End If

        '**************************************************************************************************************
        'Security Defaults By Division

        Select Case EmployeeCompanyCode
            Case "ADM"
                SecurityPreferencesADM()
            Case "ALB"
                SecurityPreferencesALB()
            Case "ATL"
                SecurityPreferencesATL()
            Case "CBS"
                SecurityPreferencesCBS()
            Case "CGO"
                SecurityPreferencesCGO()
            Case "CHT"
                SecurityPreferencesCHT()
            Case "DEN"
                SecurityPreferencesDEN()
            Case "HOU"
                SecurityPreferencesHOU()
            Case "SLC"
                SecurityPreferencesSLC()
            Case "TFF"
                SecurityPreferencesTFF()
            Case "TFJ"
                SecurityPreferencesTFJ()
            Case "TFP"
                SecurityPreferencesTFP()
            Case "TFT"
                SecurityPreferencesTFT()
            Case "TOR"
                SecurityPreferencesTOR()
            Case "TST"
                SecurityPreferencesTST()
            Case "TWD"
                SecurityPreferencesTWD()
            Case "TWE"
                SecurityPreferencesTWE()
            Case Else
                SecurityPreferencesADM()
        End Select
        '**************************************************************************************************************
        'Security Defaults by Security Code

        'Enable all inks in Computer Tools for 1001 - disable certain links for 1002
        If EmployeeSecurityCode = "1001" Then
            llEditItemClassesIV.Enabled = True
            llUserInfoMenuCT.Enabled = True
            llEditCompanyDataCT.Enabled = True
            llComputerUtilitiesCT.Enabled = True
            llDatabaseUtilitiesCT.Enabled = True
            llCompanyTotalsCT.Enabled = True
            llViewCompanyTotalsSO.Enabled = True
            llCreateLotManuallyPM.Enabled = True
            llShippingLabelsSH.Enabled = True
            pnlGLReports.Enabled = True
        ElseIf EmployeeSecurityCode = "1002" Then
            llEditItemClassesIV.Enabled = True
            llUserInfoMenuCT.Enabled = False
            llEditCompanyDataCT.Enabled = False
            llComputerUtilitiesCT.Enabled = False
            llDatabaseUtilitiesCT.Enabled = False
            llCompanyTotalsCT.Enabled = True
            llViewCompanyTotalsSO.Enabled = True
            pnlGLReports.Enabled = True
        Else
            llEditItemClassesIV.Enabled = False
            llUserInfoMenuCT.Enabled = False
            llEditCompanyDataCT.Enabled = False
            llComputerUtilitiesCT.Enabled = False
            llDatabaseUtilitiesCT.Enabled = False
            llCompanyTotalsCT.Enabled = False
            llViewCompanyTotalsSO.Enabled = False
            llCreateLotManuallyPM.Enabled = False
            pnlGLReports.Enabled = False
        End If
        '*************************************************************************************************************

        'Load Security from the security management module
        usefulFunctions.LoadSecurity(Me)

        '*************************************************************************************************************

        If EmployeeSecurityCode = "1021" Then
            Dim NewViewBlueprints As New ViewBlueprintPopup
            NewViewBlueprints.ShowDialog()
            End
        ElseIf EmployeeSecurityCode = "1022" Then
            Dim NewElectronicScheduling As New ElectronicSchedulingBoard
            NewElectronicScheduling.ShowDialog()
            End
        ElseIf EmployeeSecurityCode = "1023" Then
            Dim NewToolRoomInventory As New ToolRoomInventory()
            NewToolRoomInventory.ShowDialog()
            Me.Close()
        ElseIf EmployeeSecurityCode = "1032" Then
            'Load Defaults for Machine Operators
            LoadMachineOperatorDefaults()
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            cmdProductionMenu_Click(sender, e)
        ElseIf EmployeeSecurityCode = "1007" Then
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            cmdInventoryMenu_Click(sender, e)
        ElseIf EmployeeSecurityCode = "1009" Then
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            cmdInventoryMenu_Click(sender, e)
        ElseIf EmployeeSecurityCode = "1010" Then
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            cmdInventoryMenu_Click(sender, e)
        ElseIf EmployeeSecurityCode = "1016" Then
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            cmdInventoryMenu_Click(sender, e)
        ElseIf EmployeeSecurityCode = "1017" Then
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            cmdInventoryMenu_Click(sender, e)
        ElseIf EmployeeSecurityCode = "1031" Then
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            cmdInventoryMenu_Click(sender, e)
        Else
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
        End If
        '**************************************************************************************************************
        If EmployeeSecurityCode = 1021 Or EmployeeSecurityCode = 1031 Or EmployeeSecurityCode = 1017 Or EmployeeSecurityCode = 1016 Then
            gpxFunctionKeys.Visible = False
        Else
            gpxFunctionKeys.Visible = True
        End If
        '**************************************************************************************************************
        'Set Timer for shipping email to FEDEX
        If EmployeeLoginName = "KVONDUYKE" Then
            llShippingLabelsSH.Enabled = True

            If CurrentHour > 16 Then
                'Skip setting timer - logged in after 4:00PM
            Else
                TimerCounter = 0
                HourDifference = 16 - (CurrentHour + 1)
                HoursToMinutes = HourDifference * 60

                DefineNumberOfMinutes = HoursToMinutes + (60 - CurrentMinute)

                tmrShippingEmail.Interval = 60000
                tmrShippingEmail.Start()
            End If
        End If
        '****************************************************************************************************************
        'Set Timer for Invoice Email to customers
        If EmployeeLoginName = "ADMINUSER" Then
            'Get current time and set timer deafults
            TimerCounter = 0

            MinutesLeftInHour = 60 - CurrentMinute

            'Set Timer
            tmrInvoiceEmail.Interval = 60000
            tmrInvoiceEmail.Start()
        Else
            'Do nothing
        End If
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 400)
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

    Private Sub tmrShippingEmail_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrShippingEmail.Tick
        'Count Down Number of Minutes to fire event
        TimerCounter = TimerCounter + 1

        If DefineNumberOfMinutes - TimerCounter = 0 Then
            'Fire Event and stop timer
            FEDEXEmailAutoSend()

            tmrShippingEmail.Stop()
        Else
            'Continue
        End If
    End Sub

    Private Sub tmrInvoiceEmail_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrInvoiceEmail.Tick
        'Count Down Number of Minutes to fire event
        TimerCounter = TimerCounter + 1

        If TimerCounter = 60 Then
            'Create recurring loop for every sixty minutes
            AutoEmailInvoices()

            TimerCounter = 0
        ElseIf (60 - MinutesLeftInHour) + TimerCounter = 60 Then
            AutoEmailInvoices()
        Else
            'Skip
        End If
    End Sub

    Public Sub AutoEmailInvoices()
        '*************************************************************************************************************
        'Check database every hour to see if there is any emails scheduled to be sent
        Dim InvoiceDate As Date = Now()
        Dim InvoiceHours As Integer = InvoiceDate.Hour
        Dim InvoiceMinutes As Integer = InvoiceDate.Minute
        Dim strCheckTime As String = ""
        Dim AMorPM As String = ""
        Dim StartTime As String = ""
        Dim EndTime As String = ""
        Dim strInvoiceHours As String = CStr(InvoiceHours)
        Dim strInvoiceMinutes As String = CStr(InvoiceMinutes)

        If InvoiceHours < 10 Then
            strInvoiceHours = "0" + strInvoiceHours
        Else
            'Do nothing
        End If
        If InvoiceMinutes < 10 Then
            strInvoiceMinutes = "0" + strInvoiceMinutes
        Else
            'Do nothing
        End If
        If InvoiceHours < 12 Then
            AMorPM = "AM"
        Else
            AMorPM = "PM"
        End If

        If InvoiceHours > 12 Then InvoiceHours = InvoiceHours - 12
        strCheckTime = CStr(InvoiceHours) + ":00" + AMorPM
        StartTime = strInvoiceHours + ":" + strInvoiceMinutes + AMorPM
        '*************************************************************************************************************
        'Query database to see if there is any invoices scheduled to be sent at this time.
        Dim CountEmails As Integer = 0

        Dim CountEmailsStatement As String = "SELECT COUNT(DivisionID) FROM InvoiceEmailLog WHERE EmailTime = @EmailTime AND EmailStatus = @EmailStatus"
        Dim CountEmailsCommand As New SqlCommand(CountEmailsStatement, con)
        CountEmailsCommand.Parameters.Add("@EmailTime", SqlDbType.VarChar).Value = strCheckTime
        CountEmailsCommand.Parameters.Add("@EmailStatus", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountEmails = CInt(CountEmailsCommand.ExecuteScalar)
        Catch ex As Exception
            CountEmails = 0
        End Try
        con.Close()
        '*************************************************************************************************************
        'If Count equals zero, there is no emails to send at this time
        If CountEmails = 0 Then
            Exit Sub
        Else
            'If CountEmails <> 0 then query database and fill a datatable to run a for each loop on to send out invoices
            cmd = New SqlCommand("SELECT * FROM InvoiceEmailLog WHERE EmailTime = @EmailTime AND EmailStatus = @EmailStatus", con)
            cmd.Parameters.Add("@EmailTime", SqlDbType.VarChar).Value = strCheckTime
            cmd.Parameters.Add("@EmailStatus", SqlDbType.VarChar).Value = "OPEN"
            Dim dt As New Data.DataTable("InvoiceEmailLog")
            Dim adap As New SqlDataAdapter(cmd)
            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(dt)
            con.Close()

            'Run loop on datatable to each line by line.
            Dim RowDivision, RowCustomer, RowInvoiceEmailAddress, RowCertEmailAddress, RowUserID, RowEmailType As String
            Dim RowInvoiceNumber, RowShipmentNumber As Integer

            For Each DataTableRow In dt.Rows
                Try
                    RowDivision = DataTableRow("DivisionID")
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    RowCustomer = DataTableRow("CustomerID")
                Catch ex As Exception
                    RowCustomer = ""
                End Try
                Try
                    RowInvoiceEmailAddress = DataTableRow("InvoiceEmailAddress")
                Catch ex As Exception
                    RowInvoiceEmailAddress = ""
                End Try
                Try
                    RowCertEmailAddress = DataTableRow("CertEmailAddress")
                Catch ex As Exception
                    RowCertEmailAddress = ""
                End Try
                Try
                    RowUserID = DataTableRow("UserID")
                Catch ex As Exception
                    RowUserID = ""
                End Try
                Try
                    RowInvoiceNumber = DataTableRow("InvoiceNumber")
                Catch ex As Exception
                    RowInvoiceNumber = 0
                End Try
                Try
                    RowShipmentNumber = DataTableRow("ShipmentNumber")
                Catch ex As Exception
                    RowShipmentNumber = 0
                End Try
                Try
                    RowEmailType = DataTableRow("EmailType")
                Catch ex As Exception
                    RowEmailType = ""
                End Try
                '***********************************************************************************
                'Validate email addresses
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(vbCr, " ")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(vbCrLf, " ")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(vbLf, " ")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(vbCr, " ")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(vbCrLf, " ")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(vbLf, " ")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(",", ";")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(":", ";")
                RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace("  ", " ")

                RowCertEmailAddress = RowCertEmailAddress.Replace(vbCr, " ")
                RowCertEmailAddress = RowCertEmailAddress.Replace(vbCrLf, " ")
                RowCertEmailAddress = RowCertEmailAddress.Replace(vbLf, " ")
                RowCertEmailAddress = RowCertEmailAddress.Replace(vbCr, " ")
                RowCertEmailAddress = RowCertEmailAddress.Replace(vbCrLf, " ")
                RowCertEmailAddress = RowCertEmailAddress.Replace(vbLf, " ")
                RowCertEmailAddress = RowCertEmailAddress.Replace(",", ";")
                RowCertEmailAddress = RowCertEmailAddress.Replace(":", ";")
                RowCertEmailAddress = RowCertEmailAddress.Replace("  ", " ")

                'Check for invalid email address formats




                '***********************************************************************************
                'Get user ID email address to use as the reply to email.
                Dim UserEmailAddress As String = ""

                Dim UserEmailAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
                Dim UserEmailAddressCommand As New SqlCommand(UserEmailAddressStatement, con)
                UserEmailAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = RowUserID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    UserEmailAddress = CStr(UserEmailAddressCommand.ExecuteScalar)
                Catch ex As Exception
                    UserEmailAddress = ""
                End Try
                con.Close()
                '***********************************************************************************
                If RowEmailType = "BOTH" Then 'Send invoice and certs
                    'Get invoice data and create pdf
                    cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                    cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                    cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = RowDivision

                    cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                    cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd6 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                    cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd7 = New SqlCommand("SELECT * FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd7.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd8 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd8.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd9 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionID", con)
                    cmd9.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    If con.State = ConnectionState.Closed Then con.Open()
                    ds = New DataSet()
                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(ds, "InvoiceHeaderTable")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(ds, "InvoiceLineQuery")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(ds, "ShipmentHeaderTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(ds, "DivisionTable")

                    myAdapter4.SelectCommand = cmd4
                    myAdapter4.Fill(ds, "CustomerList")

                    myAdapter5.SelectCommand = cmd5
                    myAdapter5.Fill(ds, "AdditionalShipTo")

                    myAdapter6.SelectCommand = cmd6
                    myAdapter6.Fill(ds, "ARCustomerPayment")

                    myAdapter7.SelectCommand = cmd7
                    myAdapter7.Fill(ds, "InvoiceLotLineTable")

                    myAdapter8.SelectCommand = cmd8
                    myAdapter8.Fill(ds, "InvoiceSerialLineTable")

                    myAdapter9.SelectCommand = cmd9
                    myAdapter9.Fill(ds, "SalesOrderHeaderTable")

                    'Sets up viewer to display data from the loaded dataset
                    Dim InvoiceAutoEmail = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                    'Sets up viewer to display data from the loaded dataset
                    If RowDivision = "TWD" Then
                        InvoiceAutoEmail = crxInvoice1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    ElseIf RowDivision = "TFF" Then
                        InvoiceAutoEmail = crxInvoiceTFF1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    ElseIf RowDivision = "TOR" Then
                        InvoiceAutoEmail = crxInvoiceTFF1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    ElseIf RowDivision = "ALB" Then
                        InvoiceAutoEmail = crxInvoiceTFF1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    Else
                        InvoiceAutoEmail = crxInvoice1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    End If

                    Dim InvoiceFileName, InvoiceFileNameAndPath As String

                    InvoiceFileName = RowDivision + CStr(RowInvoiceNumber) + ".pdf"
                    InvoiceFileNameAndPath = "\\TFP-FS\TransferData\TruweldInvoices\" + InvoiceFileName

                    'Export Document to Folder
                    InvoiceAutoEmail.ExportToDisk(ExportFormatType.PortableDocFormat, InvoiceFileNameAndPath)
                    '************************************************************************************************
                    Dim CheckForCerts As Integer = 0

                    'Check to see if there are any certs that will not print
                    Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber <> 'NO CERT'"
                    Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
                    CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckForCerts = CInt(CheckForCertsCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckForCerts = 0
                    End Try
                    con.Close()
                    '*****************************************************************************************
                    'Get cert data and save to a pdf
                    cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber

                    cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

                    cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    ds = New DataSet()

                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(ds, "TruweldCertData")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(ds, "CustomerList")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(ds, "DivisionTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(ds, "PullTestLineTable")

                    'Sets up viewer to display data from the loaded dataset
                    Dim CertAutoEmail = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                    'Sets up viewer to display data from the loaded dataset
                    CertAutoEmail = crxtwCert011
                    CertAutoEmail.SetDataSource(ds)
                    con.Close()

                    Dim CertFileName, CertFileNameAndPath As String

                    CertFileName = RowDivision + CStr(RowShipmentNumber) + ".pdf"
                    CertFileNameAndPath = "\\TFP-FS\TransferData\TruweldInvoices\" + CertFileName

                    'Export Document to Folder
                    CertAutoEmail.ExportToDisk(ExportFormatType.PortableDocFormat, CertFileNameAndPath)

                    'If Cert Email is the same as Invoice Email, send one email with two attachments
                    'If Cert Email and Invoice are different, send two emails, each with an attachment

                    'Replace spaces in email address if they exist
                    RowCertEmailAddress = RowCertEmailAddress.Replace(" ", "")
                    RowInvoiceEmailAddress = RowInvoiceEmailAddress.Replace(" ", "")

                    If RowCertEmailAddress = RowInvoiceEmailAddress Then
                        'Check if file exists
                        If File.Exists(InvoiceFileNameAndPath) Then
                            '***********************************************************************************************
                            Try
                                'Set up email to be sent
                                Dim MyMailMessage As New MailMessage()
                                MyMailMessage.From = New MailAddress("Invoicing@tfpcorp.com")

                                'Add array of email addresses if necessay
                                'Parse email field to determine how many addresses 
                                If RowInvoiceEmailAddress.Contains(";") Then
                                    Dim EmailArray As Array
                                    Dim ArrayCount As Integer = 0
                                    Dim CurrentEmail As String = ""

                                    EmailArray = Split(RowInvoiceEmailAddress, ";")
                                    ArrayCount = UBound(EmailArray) + 1
                                    Dim Counter As Integer = 1

                                    For i As Integer = 0 To UBound(EmailArray)
                                        CurrentEmail = EmailArray(ArrayCount - Counter)
                                        MyMailMessage.To.Add(CurrentEmail)
                                        Counter = Counter + 1
                                    Next
                                Else
                                    MyMailMessage.To.Add(RowInvoiceEmailAddress)
                                End If

                                Dim BodyText As String = "**********PLEASE DO NOT REPLY TO THIS E-MAIL**********" + Environment.NewLine + Environment.NewLine + "THIS IS AN AUTOMATED E-MAIL FROM AN UNMANAGED ACCOUNT." + Environment.NewLine + Environment.NewLine + "IF YOU HAVE ANY QUESTION ABOUT THIS E-MAIL PLEASE CONTACT AR@TFPCORP.COM OR CALL 330.661.0372"
                                Dim SubjectText As String = RowDivision + CStr(RowInvoiceNumber)

                                MyMailMessage.Attachments.Add(New Attachment(InvoiceFileNameAndPath))
                                If CheckForCerts = 0 Then
                                    'Skip - no certs
                                Else
                                    MyMailMessage.Attachments.Add(New Attachment(CertFileNameAndPath))
                                End If
                                MyMailMessage.Subject = "Customer Invoice - " + SubjectText
                                MyMailMessage.ReplyTo = New MailAddress(UserEmailAddress)
                                MyMailMessage.Bcc.Add("invoicingsent@tfpcorp.com")
                                MyMailMessage.Body = BodyText
                                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                                SMPT.Port = 587
                                'SMPT.Timeout = 1500
                                SMPT.EnableSsl = False
                                SMPT.Credentials = New System.Net.NetworkCredential("Invoicing@tfpcorp.com", "RfvCft1")
                                SMPT.Send(MyMailMessage)

                                'Create customer note
                                Dim LastNoteNumber, NextNoteNumber As Integer

                                'Get Next Note Number
                                Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                                Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
                                MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                                If con.State = ConnectionState.Closed Then con.Open()
                                Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
                                If reader.HasRows Then
                                    reader.Read()
                                    If IsDBNull(reader.Item("MAXNoteID")) Then
                                        LastNoteNumber = 0
                                    Else
                                        LastNoteNumber = reader.Item("MAXNoteID")
                                    End If
                                Else
                                    LastNoteNumber = 0
                                End If
                                reader.Close()
                                con.Close()

                                NextNoteNumber = LastNoteNumber + 1

                                Dim MessageBodyText As String = ""

                                MessageBodyText = EmployeeLoginName + " emailed a Customer Invoice to " + RowCustomer + " Invoice#" + SubjectText

                                'Write Data to Customer Note Table
                                cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@NoteDate", SqlDbType.VarChar).Value = Now()
                                    .Add("@NoteSubject", SqlDbType.VarChar).Value = "Auto-Email Customer Invoices"
                                    .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                                    .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Invoice to show email sent
                                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + Now.ToShortDateString
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Invoice Auto-email to closed for this line item
                                cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailStatus = 'CLOSED' WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceNumber = @InvoiceNumber AND EmailStatus = 'OPEN'", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Clear Variables used inside of the try
                                MessageBodyText = ""
                                BodyText = ""
                                SubjectText = ""
                            Catch ex As Exception
                                Dim CheckEx As String
                                CheckEx = ex.ToString()
                                If CheckEx.Length() > 400 Then
                                    CheckEx = ""
                                Else
                                    CheckEx = ex.ToString()
                                End If

                                'Log error on update failure
                                ErrorDate = Now()
                                ErrorComment = CheckEx
                                ErrorDivision = RowDivision
                                ErrorDescription = "Auto-email Invoices --- Failure"
                                ErrorReferenceNumber = "Invoice failed " + RowDivision + RowCustomer + " -- " + InvoiceFileName
                                ErrorUser = RowUserID

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            MsgBox("File does not exist.", MsgBoxStyle.OkOnly)
                        End If
                    Else
                        '************************************************************************************
                        'Send Invoice Email

                        If File.Exists(InvoiceFileNameAndPath) Then
                            '***********************************************************************************************
                            Try
                                'Set up email to be sent
                                Dim MyMailMessage As New MailMessage()
                                MyMailMessage.From = New MailAddress("Invoicing@tfpcorp.com")

                                'Add array of email addresses if necessay
                                'Parse email field to determine how many addresses 
                                If RowInvoiceEmailAddress.Contains(";") Then
                                    Dim EmailArray As Array
                                    Dim ArrayCount As Integer = 0
                                    Dim CurrentEmail As String = ""

                                    EmailArray = Split(RowInvoiceEmailAddress, ";")
                                    ArrayCount = UBound(EmailArray) + 1
                                    Dim Counter As Integer = 1

                                    For i As Integer = 0 To UBound(EmailArray)
                                        CurrentEmail = EmailArray(ArrayCount - Counter)
                                        MyMailMessage.To.Add(CurrentEmail)
                                        Counter = Counter + 1
                                    Next
                                Else
                                    MyMailMessage.To.Add(RowInvoiceEmailAddress)
                                End If

                                Dim BodyText As String = "**********PLEASE DO NOT REPLY TO THIS E-MAIL**********" + Environment.NewLine + Environment.NewLine + "THIS IS AN AUTOMATED E-MAIL FROM AN UNMANAGED ACCOUNT." + Environment.NewLine + Environment.NewLine + "IF YOU HAVE ANY QUESTION ABOUT THIS E-MAIL PLEASE CONTACT AR@TFPCORP.COM OR CALL 330.661.0372"
                                Dim SubjectText As String = RowDivision + CStr(RowInvoiceNumber)

                                MyMailMessage.Attachments.Add(New Attachment(InvoiceFileNameAndPath))
                                MyMailMessage.Subject = "Customer Invoice - " + SubjectText
                                MyMailMessage.ReplyTo = New MailAddress(UserEmailAddress)
                                MyMailMessage.Bcc.Add("invoicingsent@tfpcorp.com")
                                MyMailMessage.Body = BodyText
                                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                                SMPT.Port = 587
                                'SMPT.Timeout = 1500
                                SMPT.EnableSsl = False
                                SMPT.Credentials = New System.Net.NetworkCredential("Invoicing@tfpcorp.com", "RfvCft1")
                                SMPT.Send(MyMailMessage)

                                'Create customer note
                                Dim LastNoteNumber, NextNoteNumber As Integer

                                'Get Next Note Number
                                Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                                Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
                                MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                                If con.State = ConnectionState.Closed Then con.Open()
                                Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
                                If reader.HasRows Then
                                    reader.Read()
                                    If IsDBNull(reader.Item("MAXNoteID")) Then
                                        LastNoteNumber = 0
                                    Else
                                        LastNoteNumber = reader.Item("MAXNoteID")
                                    End If
                                Else
                                    LastNoteNumber = 0
                                End If
                                reader.Close()
                                con.Close()

                                NextNoteNumber = LastNoteNumber + 1

                                Dim MessageBodyText As String = ""

                                MessageBodyText = EmployeeLoginName + " emailed a Customer Invoice to " + RowCustomer + " Invoice#" + SubjectText

                                'Write Data to Customer Note Table
                                cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@NoteDate", SqlDbType.VarChar).Value = Now()
                                    .Add("@NoteSubject", SqlDbType.VarChar).Value = "Auto-Email Customer Invoices"
                                    .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                                    .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Invoice to show email sent
                                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + Now.ToShortDateString
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Invoice Auto-email to closed for this line item
                                cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailStatus = 'CLOSED' WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceNumber = @InvoiceNumber AND EmailStatus = 'OPEN'", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Clear Variables used inside of the try
                                MessageBodyText = ""
                                BodyText = ""
                                SubjectText = ""
                            Catch ex As Exception
                                Dim CheckEx As String
                                CheckEx = ex.ToString()
                                If CheckEx.Length() > 400 Then
                                    CheckEx = ""
                                Else
                                    CheckEx = ex.ToString()
                                End If

                                'Log error on update failure
                                ErrorDate = Now()
                                ErrorComment = CheckEx
                                ErrorDivision = RowDivision
                                ErrorDescription = "Auto-email Invoices --- Failure"
                                ErrorReferenceNumber = "Invoice failed " + RowDivision + RowCustomer + " -- " + InvoiceFileName
                                ErrorUser = RowUserID

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            MsgBox("File does not exist.", MsgBoxStyle.OkOnly)
                        End If
                        '************************************************************************************
                        'Send Cert Email
                        If CheckForCerts = 0 Then
                            'Skip Cert
                        Else
                            'Check if file exists
                            If File.Exists(CertFileNameAndPath) Then
                                '***********************************************************************************************
                                Try
                                    'Set up email to be sent
                                    Dim MyMailMessage As New MailMessage()
                                    MyMailMessage.From = New MailAddress("Invoicing@tfpcorp.com")

                                    'Add array of email addresses if necessay
                                    'Parse email field to determine how many addresses 
                                    If RowCertEmailAddress.Contains(";") Then
                                        Dim EmailArray As Array
                                        Dim ArrayCount As Integer = 0
                                        Dim CurrentEmail As String = ""

                                        EmailArray = Split(RowCertEmailAddress, ";")
                                        ArrayCount = UBound(EmailArray) + 1
                                        Dim Counter As Integer = 1

                                        For i As Integer = 0 To UBound(EmailArray)
                                            CurrentEmail = EmailArray(ArrayCount - Counter)
                                            MyMailMessage.To.Add(CurrentEmail)
                                            Counter = Counter + 1
                                        Next
                                    Else
                                        MyMailMessage.To.Add(RowCertEmailAddress)
                                    End If

                                    Dim BodyText As String = "**********PLEASE DO NOT REPLY TO THIS E-MAIL**********" + Environment.NewLine + Environment.NewLine + "THIS IS AN AUTOMATED E-MAIL FROM AN UNMANAGED ACCOUNT." + Environment.NewLine + Environment.NewLine + "IF YOU HAVE ANY QUESTION ABOUT THIS E-MAIL PLEASE CONTACT AR@TFPCORP.COM OR CALL 330.661.0372"
                                    Dim SubjectText As String = RowDivision + CStr(RowInvoiceNumber)

                                    MyMailMessage.Attachments.Add(New Attachment(CertFileNameAndPath))
                                    MyMailMessage.Subject = "Customer Cert - " + SubjectText
                                    MyMailMessage.ReplyTo = New MailAddress(UserEmailAddress)
                                    MyMailMessage.Bcc.Add("invoicingsent@tfpcorp.com")
                                    MyMailMessage.Body = BodyText
                                    Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                                    SMPT.Port = 587
                                    'SMPT.Timeout = 1500
                                    SMPT.EnableSsl = False
                                    SMPT.Credentials = New System.Net.NetworkCredential("Invoicing@tfpcorp.com", "RfvCft1")
                                    SMPT.Send(MyMailMessage)

                                    'Create customer note
                                    Dim LastNoteNumber, NextNoteNumber As Integer

                                    'Get Next Note Number
                                    Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                                    Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
                                    MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                    MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
                                    If reader.HasRows Then
                                        reader.Read()
                                        If IsDBNull(reader.Item("MAXNoteID")) Then
                                            LastNoteNumber = 0
                                        Else
                                            LastNoteNumber = reader.Item("MAXNoteID")
                                        End If
                                    Else
                                        LastNoteNumber = 0
                                    End If
                                    reader.Close()
                                    con.Close()

                                    NextNoteNumber = LastNoteNumber + 1

                                    Dim MessageBodyText As String = ""

                                    MessageBodyText = EmployeeLoginName + " emailed a Customer Cert to " + RowCustomer + " Invoice#" + SubjectText

                                    'Write Data to Customer Note Table
                                    cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

                                    With cmd.Parameters
                                        .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                        .Add("@NoteDate", SqlDbType.VarChar).Value = Now()
                                        .Add("@NoteSubject", SqlDbType.VarChar).Value = "Auto-Email Customer Certs"
                                        .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                                        .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Update Invoice to show email sent
                                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                        .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + Now.ToShortDateString
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Update Invoice Auto-email to closed for this line item
                                    cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailStatus = 'CLOSED' WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceNumber = @InvoiceNumber AND EmailStatus = 'OPEN'", con)

                                    With cmd.Parameters
                                        .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Clear Variables used inside of the try
                                    MessageBodyText = ""
                                    BodyText = ""
                                    SubjectText = ""
                                Catch ex As Exception
                                    Dim CheckEx As String
                                    CheckEx = ex.ToString()
                                    If CheckEx.Length() > 400 Then
                                        CheckEx = ""
                                    Else
                                        CheckEx = ex.ToString()
                                    End If

                                    'Log error on update failure
                                    ErrorDate = Now()
                                    ErrorComment = CheckEx
                                    ErrorDivision = RowDivision
                                    ErrorDescription = "Auto-email Certs --- Failure"
                                    ErrorReferenceNumber = "Cert failed " + RowDivision + RowCustomer + " -- " + CertFileName
                                    ErrorUser = RowUserID

                                    TFPErrorLogUpdate()
                                End Try
                            Else
                                MsgBox("File does not exist.", MsgBoxStyle.OkOnly)
                            End If
                        End If
                    End If
                ElseIf RowEmailType = "INVOICE" Then 'Just send the invoice
                    'Get invoice data and create pdf
                    cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                    cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                    cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = RowDivision

                    cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                    cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd6 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                    cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    cmd7 = New SqlCommand("SELECT * FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd7.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd8 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd8.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

                    cmd9 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionID", con)
                    cmd9.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                    If con.State = ConnectionState.Closed Then con.Open()
                    ds = New DataSet()

                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(ds, "InvoiceHeaderTable")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(ds, "InvoiceLineQuery")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(ds, "ShipmentHeaderTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(ds, "DivisionTable")

                    myAdapter4.SelectCommand = cmd4
                    myAdapter4.Fill(ds, "CustomerList")

                    myAdapter5.SelectCommand = cmd5
                    myAdapter5.Fill(ds, "AdditionalShipTo")

                    myAdapter6.SelectCommand = cmd6
                    myAdapter6.Fill(ds, "ARCustomerPayment")

                    myAdapter7.SelectCommand = cmd7
                    myAdapter7.Fill(ds, "InvoiceLotLineTable")

                    myAdapter8.SelectCommand = cmd8
                    myAdapter8.Fill(ds, "InvoiceSerialLineTable")

                    myAdapter9.SelectCommand = cmd9
                    myAdapter9.Fill(ds, "SalesOrderHeaderTable")

                    'Sets up viewer to display data from the loaded dataset
                    Dim InvoiceAutoEmail = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                    'Sets up viewer to display data from the loaded dataset
                    If RowDivision = "TWD" Then
                        InvoiceAutoEmail = crxInvoice1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    ElseIf RowDivision = "TFF" Then
                        InvoiceAutoEmail = crxInvoiceTFF1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    ElseIf RowDivision = "TOR" Then
                        InvoiceAutoEmail = crxInvoiceTFF1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    ElseIf RowDivision = "ALB" Then
                        InvoiceAutoEmail = crxInvoiceTFF1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    Else
                        InvoiceAutoEmail = crxInvoice1
                        InvoiceAutoEmail.SetDataSource(ds)
                        con.Close()
                    End If

                    Dim InvoiceFileName, InvoiceFileNameAndPath As String

                    InvoiceFileName = RowDivision + CStr(RowInvoiceNumber) + ".pdf"
                    InvoiceFileNameAndPath = "\\TFP-FS\TransferData\TruweldInvoices\" + InvoiceFileName

                    'Export Document to Folder
                    InvoiceAutoEmail.ExportToDisk(ExportFormatType.PortableDocFormat, InvoiceFileNameAndPath)

                    'Create Email Fields and send email
                    'Attach and send email
                    '***********************************************************************************************
                    'Check if file exists
                    If File.Exists(InvoiceFileNameAndPath) Then
                        '***********************************************************************************************
                        Try
                            'Set up email to be sent
                            Dim MyMailMessage As New MailMessage()
                            MyMailMessage.From = New MailAddress("Invoicing@tfpcorp.com")

                            'Add array of email addresses if necessay
                            'Parse email field to determine how many addresses 
                            If RowInvoiceEmailAddress.Contains(";") Then
                                Dim EmailArray As Array
                                Dim ArrayCount As Integer = 0
                                Dim CurrentEmail As String = ""

                                EmailArray = Split(RowInvoiceEmailAddress, ";")
                                ArrayCount = UBound(EmailArray) + 1
                                Dim Counter As Integer = 1

                                For i As Integer = 0 To UBound(EmailArray)
                                    CurrentEmail = EmailArray(ArrayCount - Counter)
                                    MyMailMessage.To.Add(CurrentEmail)
                                    Counter = Counter + 1
                                Next
                            Else
                                MyMailMessage.To.Add(RowInvoiceEmailAddress)
                            End If

                            Dim BodyText As String = "**********PLEASE DO NOT REPLY TO THIS E-MAIL**********" + Environment.NewLine + Environment.NewLine + "THIS IS AN AUTOMATED E-MAIL FROM AN UNMANAGED ACCOUNT." + Environment.NewLine + Environment.NewLine + "IF YOU HAVE ANY QUESTION ABOUT THIS E-MAIL PLEASE CONTACT AR@TFPCORP.COM OR CALL 330.661.0372"
                            Dim SubjectText As String = RowDivision + CStr(RowInvoiceNumber)

                            MyMailMessage.Attachments.Add(New Attachment(InvoiceFileNameAndPath))
                            MyMailMessage.Subject = "Customer Invoice - " + SubjectText
                            MyMailMessage.ReplyTo = New MailAddress(UserEmailAddress)
                            MyMailMessage.Bcc.Add("invoicingsent@tfpcorp.com")
                            MyMailMessage.Body = BodyText
                            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                            SMPT.Port = 587
                            'SMPT.Timeout = 1500
                            SMPT.EnableSsl = False
                            SMPT.Credentials = New System.Net.NetworkCredential("Invoicing@tfpcorp.com", "RfvCft1")
                            SMPT.Send(MyMailMessage)

                            'Create customer note
                            Dim LastNoteNumber, NextNoteNumber As Integer

                            'Get Next Note Number
                            Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                            Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
                            MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                            MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                            If con.State = ConnectionState.Closed Then con.Open()
                            Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
                            If reader.HasRows Then
                                reader.Read()
                                If IsDBNull(reader.Item("MAXNoteID")) Then
                                    LastNoteNumber = 0
                                Else
                                    LastNoteNumber = reader.Item("MAXNoteID")
                                End If
                            Else
                                LastNoteNumber = 0
                            End If
                            reader.Close()
                            con.Close()

                            NextNoteNumber = LastNoteNumber + 1

                            Dim MessageBodyText As String = ""

                            MessageBodyText = EmployeeLoginName + " emailed a Customer Invoice to " + RowCustomer + " Invoice#" + SubjectText

                            'Write Data to Customer Note Table
                            cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

                            With cmd.Parameters
                                .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                .Add("@NoteDate", SqlDbType.VarChar).Value = Now()
                                .Add("@NoteSubject", SqlDbType.VarChar).Value = "Auto-Email Customer Invoices"
                                .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                                .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Update Invoice to show email sent
                            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + Now.ToShortDateString
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            'Update Invoice Auto-email to closed for this line item
                            cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailStatus = 'CLOSED' WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceNumber = @InvoiceNumber AND EmailStatus = 'OPEN'", con)

                            With cmd.Parameters
                                .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Clear Variables used inside of the try
                            MessageBodyText = ""
                            BodyText = ""
                            SubjectText = ""
                        Catch ex As Exception
                            Dim CheckEx As String
                            CheckEx = ex.ToString()
                            If CheckEx.Length() > 400 Then
                                CheckEx = ""
                            Else
                                CheckEx = ex.ToString()
                            End If

                            'Log error on update failure
                            ErrorDate = Now()
                            ErrorComment = CheckEx
                            ErrorDivision = RowDivision
                            ErrorDescription = "Auto-email Invoices --- Failure"
                            ErrorReferenceNumber = "Invoice failed " + RowDivision + RowCustomer + " -- " + InvoiceFileName
                            ErrorUser = RowUserID

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        MsgBox("File does not exist.", MsgBoxStyle.OkOnly)
                    End If
                ElseIf RowEmailType = "CERTS" Then ' Certs only
                    Dim CheckForCerts As Integer = 0

                    'Check to see if there are any certs that will not print
                    Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber <> 'NO CERT'"
                    Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
                    CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckForCerts = CInt(CheckForCertsCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckForCerts = 0
                    End Try
                    con.Close()

                    If CheckForCerts = 0 Then 'THere are no cert to attach to this email.
                        'Skip and go to next Invoice
                    Else
                        'Get cert data and save to a pdf
                        cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
                        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber

                        cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                        cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

                        cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        ds = New DataSet()

                        myAdapter.SelectCommand = cmd
                        myAdapter.Fill(ds, "TruweldCertData")

                        myAdapter1.SelectCommand = cmd1
                        myAdapter1.Fill(ds, "CustomerList")

                        myAdapter2.SelectCommand = cmd2
                        myAdapter2.Fill(ds, "DivisionTable")

                        myAdapter3.SelectCommand = cmd3
                        myAdapter3.Fill(ds, "PullTestLineTable")

                        'Sets up viewer to display data from the loaded dataset
                        Dim CertAutoEmail = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                        'Sets up viewer to display data from the loaded dataset
                        CertAutoEmail = crxtwCert011
                        CertAutoEmail.SetDataSource(ds)
                        con.Close()

                        Dim CertFileName, CertFileNameAndPath As String

                        CertFileName = RowDivision + CStr(RowShipmentNumber) + ".pdf"
                        CertFileNameAndPath = "\\TFP-FS\TransferData\TruweldInvoices\" + CertFileName

                        'Export Document to Folder
                        CertAutoEmail.ExportToDisk(ExportFormatType.PortableDocFormat, CertFileNameAndPath)

                        'Create Email Fields and send email
                        'Attach and send email
                        '***********************************************************************************************
                        'Check if file exists
                        If File.Exists(CertFileNameAndPath) Then
                            '***********************************************************************************************
                            Try
                                'Set up email to be sent
                                Dim MyMailMessage As New MailMessage()
                                MyMailMessage.From = New MailAddress("Invoicing@tfpcorp.com")

                                'Add array of email addresses if necessay
                                'Parse email field to determine how many addresses 
                                If RowCertEmailAddress.Contains(";") Then
                                    Dim EmailArray As Array
                                    Dim ArrayCount As Integer = 0
                                    Dim CurrentEmail As String = ""

                                    EmailArray = Split(RowCertEmailAddress, ";")
                                    ArrayCount = UBound(EmailArray) + 1
                                    Dim Counter As Integer = 1

                                    For i As Integer = 0 To UBound(EmailArray)
                                        CurrentEmail = EmailArray(ArrayCount - Counter)
                                        MyMailMessage.To.Add(CurrentEmail)
                                        Counter = Counter + 1
                                    Next
                                Else
                                    MyMailMessage.To.Add(RowCertEmailAddress)
                                End If

                                Dim BodyText As String = "**********PLEASE DO NOT REPLY TO THIS E-MAIL**********" + Environment.NewLine + Environment.NewLine + "THIS IS AN AUTOMATED E-MAIL FROM AN UNMANAGED ACCOUNT." + Environment.NewLine + Environment.NewLine + "IF YOU HAVE ANY QUESTION ABOUT THIS E-MAIL PLEASE CONTACT AR@TFPCORP.COM OR CALL 330.661.0372"
                                Dim SubjectText As String = RowDivision + CStr(RowInvoiceNumber)

                                MyMailMessage.Attachments.Add(New Attachment(CertFileNameAndPath))
                                MyMailMessage.Subject = "Customer Cert - " + SubjectText
                                MyMailMessage.ReplyTo = New MailAddress(UserEmailAddress)
                                MyMailMessage.Bcc.Add("invoicingsent@tfpcorp.com")
                                MyMailMessage.Body = BodyText
                                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                                SMPT.Port = 587
                                'SMPT.Timeout = 1500
                                SMPT.EnableSsl = False
                                SMPT.Credentials = New System.Net.NetworkCredential("Invoicing@tfpcorp.com", "RfvCft1")
                                SMPT.Send(MyMailMessage)

                                'Create customer note
                                Dim LastNoteNumber, NextNoteNumber As Integer

                                'Get Next Note Number
                                Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                                Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
                                MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                                If con.State = ConnectionState.Closed Then con.Open()
                                Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
                                If reader.HasRows Then
                                    reader.Read()
                                    If IsDBNull(reader.Item("MAXNoteID")) Then
                                        LastNoteNumber = 0
                                    Else
                                        LastNoteNumber = reader.Item("MAXNoteID")
                                    End If
                                Else
                                    LastNoteNumber = 0
                                End If
                                reader.Close()
                                con.Close()

                                NextNoteNumber = LastNoteNumber + 1

                                Dim MessageBodyText As String = ""

                                MessageBodyText = EmployeeLoginName + " emailed a Customer Cert to " + RowCustomer + " Invoice#" + SubjectText

                                'Write Data to Customer Note Table
                                cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@NoteDate", SqlDbType.VarChar).Value = Now()
                                    .Add("@NoteSubject", SqlDbType.VarChar).Value = "Auto-Email Customer Certs"
                                    .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                                    .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Invoice Auto-email to closed for this line item
                                cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailStatus = 'CLOSED' WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceNumber = @InvoiceNumber AND EmailStatus = 'OPEN'", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Clear Variables used inside of the try
                                MessageBodyText = ""
                                BodyText = ""
                                SubjectText = ""
                            Catch ex As Exception
                                Dim CheckEx As String
                                CheckEx = ex.ToString()
                                If CheckEx.Length() > 400 Then
                                    CheckEx = ""
                                Else
                                    CheckEx = ex.ToString()
                                End If

                                'Log error on update failure
                                ErrorDate = Now()
                                ErrorComment = CheckEx
                                ErrorDivision = RowDivision
                                ErrorDescription = "Auto-email Certs --- Failure"
                                ErrorReferenceNumber = "Cert failed " + RowDivision + RowCustomer + " -- " + CertFileName
                                ErrorUser = RowUserID

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            MsgBox("File does not exist.", MsgBoxStyle.OkOnly)
                        End If
                    End If
                Else
                    'Do not send anything
                End If
            Next

            Try
                'Get Ending Time
                Dim EndDate As Date = Now()
                Dim EndHour As Integer = EndDate.Hour
                Dim EndMinute As Integer = EndDate.Minute
                Dim strEndHour As String = CStr(EndHour)
                Dim strEndMinute As String = CStr(EndMinute)

                If EndHour < 10 Then
                    strEndHour = "0" + strEndHour
                Else
                    'Do nothing
                End If
                If EndMinute < 10 Then
                    strEndMinute = "0" + strEndMinute
                Else
                    'Do nothing
                End If

                EndTime = strEndHour + ":" + strEndMinute + AMorPM

                'Update Audit Trail
                cmd = New SqlCommand("Insert Into AuditTrail(AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID)Values(@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Now()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "Invoice Auto-Emailer"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = ""
                    .Add("@AuditComment", SqlDbType.VarChar).Value = "Process started at " + StartTime + " and ended at " + EndTime
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Dim CheckEx As String
                CheckEx = ex.ToString()
                If CheckEx.Length() > 400 Then
                    CheckEx = ""
                Else
                    CheckEx = ex.ToString()
                End If

                'Log error on update failure
                ErrorDate = Now()
                ErrorComment = CheckEx
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Auto-email Audit Trail --- Failure"
                ErrorReferenceNumber = "Auto-Email Failed "
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Public Sub FEDEXEmailAutoSend()
        'Get Report Data and save as a pdf to attach to email
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipDate = @ShipDate AND ShipVia LIKE 'FEDEX %' AND (ShipmentStatus = 'SHIPPED' OR ShipmentStatus = 'INVOICED') AND (DivisionID = 'TWD' OR DivisionID = 'TFP')", con)
        cmd.Parameters.Add("ShipDate", SqlDbType.VarChar).Value = Today()
        Dim dt As New Data.DataTable("ShipmentHeaderTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim FedexDailyLogReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        FedexDailyLogReport = crxDailyShipmentLog1
        FedexDailyLogReport.SetDataSource(dt)

        'Create new Filename for Cert
        Dim FedExReportName As String = ""
        Dim TodaysDate As Date = Today()
        Dim TodaysMonth, TodaysDay, TodaysYear As Integer
        Dim strMonth, strDay, strYear As String
        Dim strTodaysDate As String

        TodaysMonth = TodaysDate.Month
        TodaysDay = TodaysDate.Day
        TodaysYear = TodaysDate.Year

        If TodaysMonth < 10 Then
            strMonth = CStr(TodaysMonth)
            strMonth = "0" + strMonth
        Else
            strMonth = CStr(TodaysMonth)
        End If
        If TodaysDay < 10 Then
            strDay = CStr(TodaysDay)
            strDay = "0" + strDay
        Else
            strDay = CStr(TodaysDay)
        End If

        strYear = CStr(TodaysYear)

        strTodaysDate = strMonth + strDay + strYear

        FedExReportName = "TFPCORP" + strTodaysDate + ".pdf"

        'Export Document to Folder
        FedexDailyLogReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" + FedExReportName)

        'Get Shipment Details to send to Fedex
        Dim NumberOfOrders As Integer = 0
        Dim TotalWeightOfOrders As Double = 0
        Dim NumberOfPalletsOfOrders As Integer = 0
        '********************************************************************************
        Dim NumberOfOrdersStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipDate = @ShipDate AND ShipVia LIKE 'FEDEX %' AND (ShipmentStatus = 'SHIPPED' OR ShipmentStatus = 'INVOICED') AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim NumberOfOrdersCommand As New SqlCommand(NumberOfOrdersStatement, con)
        NumberOfOrdersCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = Today()

        Dim TotalWeightOfOrdersStatement As String = "SELECT SUM(ShippingWeight) FROM ShipmentHeaderTable WHERE ShipDate = @ShipDate AND ShipVia LIKE 'FEDEX %' AND (ShipmentStatus = 'SHIPPED' OR ShipmentStatus = 'INVOICED') AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim TotalWeightOfOrdersCommand As New SqlCommand(TotalWeightOfOrdersStatement, con)
        TotalWeightOfOrdersCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = Today()

        Dim NumberOfPalletsOfOrdersStatement As String = "SELECT SUM(NumberOfPallets) FROM ShipmentHeaderTable WHERE ShipDate = @ShipDate AND ShipVia LIKE 'FEDEX %' AND (ShipmentStatus = 'SHIPPED' OR ShipmentStatus = 'INVOICED') AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim NumberOfPalletsOfOrdersCommand As New SqlCommand(NumberOfPalletsOfOrdersStatement, con)
        NumberOfPalletsOfOrdersCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = Today()

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NumberOfOrders = CInt(NumberOfOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfOrders = 0
        End Try
        Try
            TotalWeightOfOrders = CDbl(TotalWeightOfOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            TotalWeightOfOrders = 0
        End Try
        Try
            NumberOfPalletsOfOrders = CInt(NumberOfPalletsOfOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfPalletsOfOrders = 0
        End Try
        con.Close()

        'Create Email Fields and send email
        Dim strNumberOfPallets As String = ""
        Dim strTotalWeightOfOrders As String = ""
        Dim strNumberOfOrders As String = ""
        Dim EmailBody As String = ""
        Dim ShippingDate As String = ""
        Dim BodyHeader As String = ""
        Dim BodyFooter As String = ""

        ShippingDate = Today()

        'Creat Body Email
        strNumberOfPallets = CStr(NumberOfPalletsOfOrders)
        strTotalWeightOfOrders = CStr(TotalWeightOfOrders)
        strNumberOfOrders = CStr(NumberOfOrders)

        EmailBody = "TFP Corporation / Truweld / Trufit Products" + Environment.NewLine + "460 Lake Road, Medina Ohio 44256" + Environment.NewLine + "1-330-725-7741 Ext. 265" + Environment.NewLine + "FEDEX Shipping Manifest for " + ShippingDate + Environment.NewLine + Environment.NewLine + "Number of Orders -- " + strNumberOfOrders + Environment.NewLine + "Number of Pallets -- " + strNumberOfPallets + Environment.NewLine + "Total Weight of Orders -- " + strTotalWeightOfOrders + Environment.NewLine + Environment.NewLine + "Please note -- these numbers above are as of 4:00PM EST. These numbers can change as more orders can be added."

        'Send Email
        Try
            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld-shipping@tfpcorp.com")
            MyMailMessage.To.Add("t.lerew@tfpcorp.com")
            MyMailMessage.To.Add("k.vonduyke@tfpcorp.com")
            MyMailMessage.To.Add("ryan.stibi@fedex.com")
            MyMailMessage.To.Add("joseph.steppenbacker@fedex.com")
            MyMailMessage.To.Add("anthony.m.brown@fedex.com")
            MyMailMessage.To.Add("kevin.yelinek@fedex.com")
            MyMailMessage.To.Add("Jamie.surrento@fedex.com")
            MyMailMessage.To.Add("christopher.tilley@fedex.com")
            MyMailMessage.To.Add("bryan.ferguson@fedex.com")
            MyMailMessage.Subject = "TFP Corporation FEDEX Shipment Log - " + ShippingDate
            MyMailMessage.ReplyTo = New MailAddress("truweld-shipping@tfpcorp.com")
            MyMailMessage.Body = EmailBody
            MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldPackList\" + FedExReportName))
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = "587"
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld-shipping@tfpcorp.com", "VonDuyke@3")
            SMPT.Send(MyMailMessage)

            'MsgBox("Email sent.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'MsgBox("Email not sent.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Public Sub LoadMachineOperatorDefaults()
        'Lock out all modules
        cmdAPMenu.Enabled = False
        cmdARMenu.Enabled = False
        cmdComputerToolsMenu.Enabled = False
        cmdFactoryOrderMenu.Enabled = False
        cmdGeneralInfo.Enabled = False
        cmdInventoryMenu.Enabled = False
        cmdProductionMenu.Enabled = True
        cmdPurchaseOrderMenu.Enabled = False
        cmdSalesOrderMenu.Enabled = False
        cmdQualityControlMenu.Enabled = False
        cmdRawMaterialsMenu.Enabled = False
        cmdTruFitModule.Enabled = False
        cmdToolRoom.Enabled = False
        cmdTFPReports.Enabled = False
        cmdShippingMenu.Enabled = False

        'Lock out all links in Production Menu
        llFOXMenuPM.Enabled = False
        llViewFOXListingPM.Enabled = False
        llTimeSlipMenuPM.Enabled = False
        llTimeSlipPostingPM.Enabled = False
        llViewTimeSlipPostingsPM.Enabled = False
        llViewSteelCoilsPM.Enabled = False
        llViewFOXReleaseSchedulePM.Enabled = False
        llProductionSchedulingPM.Enabled = False
        llViewSteelListPM.Enabled = False
        llSteelConsumptionPM.Enabled = False
        llMaintainMachineDataPM.Enabled = False
        llViewLeadTimesPM.Enabled = False
        llProductionGraphingPM.Enabled = False
        llEnterDailyProductionPM.Enabled = False
        llViewWCProductionPM.Enabled = False
        llFerruleProductionSchedulingPM.Enabled = False
        llAssemblyProgramPM.Enabled = False
        llViewAssemblyListingPM.Enabled = False
        llViewSerializedLogPM.Enabled = False
        llViewBuildListingPM.Enabled = False
        llViewFOXWIPPM.Enabled = False
        llViewFOXStepCostingPM.Enabled = False
        llHeaderSetupSheetPM.Enabled = True
        llViewHeaderSetupSheetsPM.Enabled = True
        llViewCoilInventoryRM.Enabled = False
        llViewTimeSlipRosterPM.Enabled = False
        llViewAllTimeSlipsPM.Enabled = False
        llProductionTotalsPM.Enabled = False
        llProductionInventoryTubsPM.Enabled = False
        llViewBlueprintsPM.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Timer2.Interval = 1000 Then
            Select Case EmployeeCompanyCode
                ''CASE for 1 hour behind
                Case "CGO", "HOU", "TFT"
                    lblTimeLabel.Text = convertTimeToLocal(-1)

                    ''CASE for 2 hours behind
                Case "SLC", "DEN", "ALB"
                    lblTimeLabel.Text = convertTimeToLocal(-2)

                    ''CASE FOR 3 hours behind
                Case "TFF", "CBS"
                    lblTimeLabel.Text = convertTimeToLocal(-3)

                    ''Eastern Timezone
                Case Else
                    lblTimeLabel.Text = Now.ToString
            End Select
        End If
    End Sub

    Private Sub tmrNotifications_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrNotifications.Tick
        ''***************************************************************************************************************************************
        ''When not building with framework 3.5 anymore, will need to open the connection differently and remove Async=true from connection string.
        ''***************************************************************************************************************************************
        Dim NotificationCon As New SqlConnection("Data Source=TFP-SQL; Async=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim NotificationCommand As SqlCommand
        If EmployeeCompanyCode = "ADM" Then
            NotificationCommand = New SqlCommand("SELECT NotificationKey, DivisionID, EmployeeFirst, EmployeeLast, NotificationType, ReferenceNumber, NotificationDateTime, Details, Status, AddedBy FROM NotificationTable LEFT OUTER JOIN EmployeeData ON NotificationTable.EmployeeID = EmployeeData.EmployeeID WHERE NotificationTable.EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE LoginName = @LoginName) AND SnoozeTime <= @CurrentDate AND Status = 'ACTIVE' ORDER BY NotificationDateTime", NotificationCon)
        Else
            NotificationCommand = New SqlCommand("SELECT NotificationKey, DivisionID, EmployeeFirst, EmployeeLast, NotificationType, ReferenceNumber, NotificationDateTime, Details, Status, AddedBy FROM NotificationTable LEFT OUTER JOIN EmployeeData ON NotificationTable.EmployeeID = EmployeeData.EmployeeID WHERE NotificationTable.EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE LoginName = @LoginName) and NotificationTable.DivisionID = @DivisionID AND SnoozeTime <= @CurrentDate AND Status = 'ACTIVE' ORDER BY NotificationDateTime", NotificationCon)
            NotificationCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End If
        With NotificationCommand.Parameters
            .Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@CurrentDate", SqlDbType.DateTime).Value = DateTime.Now
        End With

        Dim tempds As New DataSet
        Dim adapter As New SqlDataAdapter(NotificationCommand)
        Try
            If NotificationCon.State = ConnectionState.Closed Then NotificationCon.Open()
            adapter.Fill(tempds, "Notifications")
            NotificationCon.Close()

            If tempds.Tables("Notifications").Rows.Count > 0 Then
                tmrNotifications.Stop()
                If newNotificationAlert Is Nothing Then
                    newNotificationAlert = New NotificationAlert(tempds)
                    newNotificationAlert.TopMost = True
                    AddHandler newNotificationAlert.VisibleChanged, AddressOf newNotificationAlert_VisibilityChanged
                    AddHandler newNotificationAlert.FormClosing, AddressOf newNotificationAlert_Closing
                    newNotificationAlert.Show()
                    newNotificationAlert.TopMost = False
                    'newNotificationAlert.BringToFront()
                    'Me.SendToBack()
                    'tmrNotifications.Start()
                End If
            End If
        Catch ex As Exception
            adapter.Dispose()
        End Try
        If NotificationCon.State = ConnectionState.Open Then NotificationCon.Close()
    End Sub

    Private Sub newNotificationAlert_VisibilityChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not newNotificationAlert.Visible AndAlso Not newNotificationAlert.NotificationViewShowing() Then
            If Not tmrNotifications.Enabled Then tmrNotifications.Start()
            newNotificationAlert.Dispose()
            newNotificationAlert = Nothing
        End If
    End Sub

    Private Sub newNotificationAlert_Closing(ByVal sender As System.Object, ByVal e As FormClosingEventArgs)
        If newNotificationAlert IsNot Nothing Then
            If Not tmrNotifications.Enabled Then tmrNotifications.Start()
            newNotificationAlert = Nothing
        End If
    End Sub

    Private Function convertTimeToLocal(ByVal diff As Integer) As String
        Dim tempHour As Integer = Now.TimeOfDay.Hours + diff
        Dim tempDate As Date = Today.Date
        Dim ampm As String = "AM"
        Select Case tempHour
            Case Is > 12
                ampm = "PM"
                tempHour = tempHour - 12
            Case Is < 0
                tempDate = tempDate.AddDays(-1)
                tempHour = 12
            Case Is = 0
                tempHour = 12
        End Select
        Return tempDate.ToShortDateString() + " " + tempHour.ToString() + Now.TimeOfDay.ToString.Substring(Now.TimeOfDay.ToString.IndexOf(":"), Now.TimeOfDay.ToString.IndexOf(".") - Now.TimeOfDay.ToString.IndexOf(":")) + " " + ampm
    End Function

    Private Sub MainInterface_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        WriteLogoffLog()

        UnregisterHotKey(Me.Handle, 1100)
        UnregisterHotKey(Me.Handle, 1101)
        UnregisterHotKey(Me.Handle, 1102)
        UnregisterHotKey(Me.Handle, 1103)
        UnregisterHotKey(Me.Handle, 1104)
        UnregisterHotKey(Me.Handle, 1105)
        UnregisterHotKey(Me.Handle, 1106)
        UnregisterHotKey(Me.Handle, 1107)
        UnregisterHotKey(Me.Handle, 1108)
        UnregisterHotKey(Me.Handle, 1200)
        UnregisterHotKey(Me.Handle, 1201)
        UnregisterHotKey(Me.Handle, 1202)
        UnregisterHotKey(Me.Handle, 1203)
        UnregisterHotKey(Me.Handle, 1204)
        UnregisterHotKey(Me.Handle, 1205)
        UnregisterHotKey(Me.Handle, 1206)
        UnregisterHotKey(Me.Handle, 1207)
        UnregisterHotKey(Me.Handle, 1208)
        UnregisterHotKey(Me.Handle, 1209)
        UnregisterHotKey(Me.Handle, 1210)
        UnregisterHotKey(Me.Handle, 1211)
        UnregisterHotKey(Me.Handle, 1300)
        UnregisterHotKey(Me.Handle, 1301)

        'Unlock any forms
        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET Locked = @Locked WHERE Locked = @Locked2", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""
        cmd.Parameters.Add("@Locked2", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub DumpGlobalVariables()
        RackingTransactionKeyRunningTotal = 0
        FerruleProductionKey = 0
        PartNumberLookup = ""
        PartDescriptionLookup = ""
        CustomerCodeLookup = ""
        VendorPartLookup = ""
        VendorNameLookup = ""
        QuoteNumberListing = 0
        SalesOrderLookup = 0
        PickListStyle = ""
        GlobalSteelCarbon = ""

        'Global Variables to autofill forms on load from other forms
        GlobalPickListNumber = 0
        GlobalPONumber = 0
        GlobalSONumber = 0
        GlobalCustomerName = ""
        GlobalShipmentNumber = 0
        GlobalProductionPartNumber = ""
        GlobalMaintenancePartNumber = ""
        GlobalMaintenancePartDescription = ""
        GlobalCustomerReturnNumber = 0
        GlobalCustomerID = ""
        GlobalVendorID = ""
        GlobalItemClass = ""
        GlobalFOXNumber = 0
        GlobalVendorName = ""
        GlobalAPBatchNumber = 0
        GlobalARBatchNumber = 0
        GlobalAPDivisionID = ""
        GlobalVoucherNumber = 0
        GlobalReceiverNumber = 0
        GlobalVendorReturnNumber = 0
        GlobalProductionEntry = 0
        GlobalTransferOrderNumber = 0
        GlobalSteelReceivingNumber = 0
        GlobalSteelPONumber = 0
        GlobalShipmentStatus = ""
        GlobalLotNumber = ""
        GlobalInvoiceNumber = 0
        GlobalTWQuoteNumber = 0
        GlobalDivisionCode = ""
        GlobalSteelRMID = ""
        GlobalSteelBatchNumber = 0
        GlobalTrufitCertNumber = 0
        GlobalHeatTreatFileNumber = 0
        GlobalHeatFileNumber = 0
        GlobalPickBatchNumber = 0
        GlobalSteelAdjustmentNumber = 0
        GlobalARTransactionNumber = 0
        GlobalTFPQuoteNumber = 0
        GlobalTimeSlipNumber = 0
        GlobalRequisitionNumber = 0
        GlobalHeaderTransactionNumber = 0
        GlobalInventoryAdjustmentBatchNumber = 0
        GlobalInventoryAdjustmentNumber = 0
        GlobalARPaymentID = 0
        GlobalPullTestNumber = 0
        GlobalAnnealLotNumber = 0
        GlobalAPStartingCheckNumber = 0
        GlobalReturnNumber = 0
        GlobalCustomerID2 = ""
        GlobalBankAccountID = ""
        GlobalBOLNumber = 0
        GlobalWCProductionNumber = 0
        GlobalSOStatus = ""
        GlobalGLBatchNumber = 0

        'Variables used in Sales Order Broken Box Charge
        GlobalSalesOrderQuantity = 0
        GlobalSalesOrderHigher = 0
        GlobalSalesOrderLower = 0
        GlobalBrokenBoxCharge = ""

        'Variables used in Accessory Form
        GlobalOrderQuantity = 0
        GlobalNominalDiameter = 0
        GlobalSOUnitPrice = 0

        'Global QC Data
        GlobalQCBPNumber = ""
        GlobalQCPartNumber = ""
        GlobalInspectionKey = ""

        'Division Code Reloads for specific forms
        ReloadAPDivisionCode = ""
        GlobalARDivisionCode = ""

        GlobalNewAPBatchNumber = 0
        GlobalNewARBatchNumber = 0
        GlobalAPPONumber = 0
        GlobalSelectLinesReceiverNumber = 0
        GlobalSelectLinesPONumber = 0
    End Sub

    Private Sub cmdGeneralInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneralInfo.Click
        gpxRawMaterialsInterface.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = True
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.Yellow
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdComputerToolsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComputerToolsMenu.Click
        gpxSalesMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = True
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.Yellow
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdRawMaterialsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRawMaterialsMenu.Click
        gpxRawMaterialsInterface.Visible = True
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.Yellow
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdTruFitModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTruFitModule.Click
        gpxSalesMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = True
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.Yellow
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdToolRoomMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTFPReports.Click
        gpxSalesMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = True
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.Yellow
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdQualityControlMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQualityControlMenu.Click
        gpxRawMaterialsInterface.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxQualityControlMenu.Visible = True
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.Yellow
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdFactoryOrderMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFactoryOrderMenu.Click
        gpxFOXMenu.Visible = True
        gpxSalesMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.Yellow
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdInventoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInventoryMenu.Click
        gpxInventoryMenu.Visible = True
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.Yellow
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdSalesOrderMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalesOrderMenu.Click
        gpxSalesMenu.Visible = True
        gpxPurchaseOrderMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.Yellow
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdPurchaseOrderMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPurchaseOrderMenu.Click
        gpxSalesMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = True
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.Yellow
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdProductionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProductionMenu.Click
        gpxRawMaterialsInterface.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = True
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.Yellow
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdShippingMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShippingMenu.Click
        gpxARData.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxShippingMenu.Visible = True
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.Yellow
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdARMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdARMenu.Click
        gpxARData.Visible = True
        gpxRawMaterialsInterface.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.Yellow
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdAPMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAPMenu.Click
        gpxSalesMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = True
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.Yellow
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
    End Sub

    Private Sub cmdToolRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolRoom.Click
        gpxSalesMenu.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxRawMaterialsInterface.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = False
        gpxToolRoom.Visible = True
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.LightGray
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray

        cmdToolRoom.BackColor = Color.Yellow
    End Sub

    Private Sub cmdExitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExitProgram.Click
        Me.Close()
    End Sub

    Private Sub cmdChangeCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeCompany.Click
        gpxRawMaterialsInterface.Visible = False
        gpxInventoryMenu.Visible = False
        gpxPurchaseOrderMenu.Visible = False
        gpxSalesMenu.Visible = False
        gpxQualityControlMenu.Visible = False
        gpxGeneralInfo.Visible = False
        gpxComputerToolsMenu.Visible = False
        gpxProductionMenu.Visible = False
        gpxARData.Visible = False
        gpxShippingMenu.Visible = False
        gpxAPMenu.Visible = False
        gpxFOXMenu.Visible = False
        gpxTFPReports.Visible = False
        gpxTrufitPrograms.Visible = False
        gpxChangeUser.Visible = True
        gpxToolRoom.Visible = False
        cmdGeneralInfo.BackColor = Color.LightGray
        cmdAPMenu.BackColor = Color.LightGray
        cmdARMenu.BackColor = Color.LightGray
        cmdChangeCompany.BackColor = Color.Yellow
        cmdComputerToolsMenu.BackColor = Color.LightGray
        cmdFactoryOrderMenu.BackColor = Color.LightGray
        cmdInventoryMenu.BackColor = Color.LightGray
        cmdProductionMenu.BackColor = Color.LightGray
        cmdPurchaseOrderMenu.BackColor = Color.LightGray
        cmdQualityControlMenu.BackColor = Color.LightGray
        cmdRawMaterialsMenu.BackColor = Color.LightGray
        cmdSalesOrderMenu.BackColor = Color.LightGray
        cmdShippingMenu.BackColor = Color.LightGray
        cmdTFPReports.BackColor = Color.LightGray
        cmdTruFitModule.BackColor = Color.LightGray
        cmdToolRoom.BackColor = Color.LightGray
        txtLoginName.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtLoginName.Clear()
        txtLoginPassword.Clear()
        cboCompanyName.SelectedIndex = -1
        cboLoginName.SelectedIndex = -1
        cboLoginPassword.SelectedIndex = -1
        txtLoginName.Focus()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If canChangeCompany() Then
            'Do nor allow to change user - only change division - user must log out to change
            If EmployeeLoginName <> txtLoginName.Text Then
                MsgBox("You cannot change user - only division. You must log out then back in again.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '**********************************************************************************************************
            Dim ChangePassword, ChangeLogin, Password, DivisionCode As String

            ChangePassword = txtLoginPassword.Text
            ChangeLogin = txtLoginName.Text

            cmd = New SqlCommand("SELECT LoginPassword, DivisionKey, SecurityGroupID FROM EmployeeData WHERE LoginName = @LoginName", con)
            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = ChangeLogin

            Dim SecurityLevel As Integer = 0
            Password = ""
            DivisionCode = ""

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("LoginPassword")) Then
                    Password = reader.Item("LoginPassword")
                End If
                If Not IsDBNull(reader.Item("DivisionKey")) Then
                    DivisionCode = reader.Item("DivisionKey")
                End If
                If Not IsDBNull(reader.Item("SecurityGroupID")) Then
                    SecurityLevel = reader.Item("SecurityGroupID")
                End If
            End If
            reader.Close()
            con.Close()

            If cboCompanyName.Text = "LLH" Then
                If DivisionCode = "ADM" And (EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1003) Then
                    'Continue
                Else
                    MsgBox("You cannot log into this division.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If

            If DivisionCode = "ADM" Or SecurityLevel = 1001 Or SecurityLevel = 1002 Or SecurityLevel = 1030 Or EmployeeLoginName.Equals("TBLACKBURN") Then
                If Password = ChangePassword Then
                    If SecurityLevel = 1030 AndAlso cboCompanyName.Text <> "TWD" AndAlso cboCompanyName.Text <> "TFP" AndAlso Not EmployeeLoginName.Equals("SAMRAY") Then
                        MessageBox.Show("You are only authorized to be in TWD or TFP", "Unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        EmployeeCompanyCode = cboCompanyName.Text

                        lblLoginLast.Text = ChangeLogin & " is currently logged in " & EmployeeCompanyCode
                        DumpGlobalVariables()
                    End If
                Else
                    MsgBox("Login Information Incorrect", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("You are not Authorized to change companies.", MsgBoxStyle.Information)
            End If

            'Clear Text Boxes after change
            cboCompanyName.SelectedIndex = -1
            cboLoginName.SelectedIndex = -1
            cboLoginPassword.SelectedIndex = -1
            txtLoginName.Focus()

            '**************************************************************************************************************
            'Security Defaults By Division

            Select Case EmployeeCompanyCode
                Case "ADM"
                    SecurityPreferencesADM()
                Case "ALB"
                    SecurityPreferencesALB()
                Case "ATL"
                    SecurityPreferencesATL()
                Case "CBS"
                    SecurityPreferencesCBS()
                Case "CGO"
                    SecurityPreferencesCGO()
                Case "CHT"
                    SecurityPreferencesCHT()
                Case "DEN"
                    SecurityPreferencesDEN()
                Case "HOU"
                    SecurityPreferencesHOU()
                Case "SLC"
                    SecurityPreferencesSLC()
                Case "TFF"
                    SecurityPreferencesTFF()
                Case "TFJ"
                    SecurityPreferencesTFJ()
                Case "TFP"
                    SecurityPreferencesTFP()
                Case "TFT"
                    SecurityPreferencesTFT()
                Case "TOR"
                    SecurityPreferencesTOR()
                Case "TST"
                    SecurityPreferencesTST()
                Case "TWD"
                    SecurityPreferencesTWD()
                Case "TWE"
                    SecurityPreferencesTWE()
                Case Else
                    SecurityPreferencesADM()
            End Select
            '**************************************************************************************************************
            'Security Defaults by Security Code

            'Enable all inks in Computer Tools for 1001 - disable certain links for 1002
            If EmployeeSecurityCode = "1001" Then
                llEditItemClassesIV.Enabled = True
                llUserInfoMenuCT.Enabled = True
                llEditCompanyDataCT.Enabled = True
                llComputerUtilitiesCT.Enabled = True
                llDatabaseUtilitiesCT.Enabled = True
                llCompanyTotalsCT.Enabled = True
                llViewCompanyTotalsSO.Enabled = True
            ElseIf EmployeeSecurityCode = "1002" Then
                llEditItemClassesIV.Enabled = True
                llUserInfoMenuCT.Enabled = False
                llEditCompanyDataCT.Enabled = False
                llComputerUtilitiesCT.Enabled = False
                llDatabaseUtilitiesCT.Enabled = False
                llCompanyTotalsCT.Enabled = True
                llViewCompanyTotalsSO.Enabled = True
            Else
                llEditItemClassesIV.Enabled = False
                llUserInfoMenuCT.Enabled = False
                llEditCompanyDataCT.Enabled = False
                llComputerUtilitiesCT.Enabled = False
                llDatabaseUtilitiesCT.Enabled = False
                llCompanyTotalsCT.Enabled = False
                llViewCompanyTotalsSO.Enabled = False
            End If
            '*************************************************************************************************************

            'Load Security from the security management module
            usefulFunctions.LoadSecurity(Me)

        End If
    End Sub

    Private Sub cmdWireyardInventoryTubs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWireyardInventoryTubs.Click
        Dim newInventoryTubs As New InventoryTubs
        newInventoryTubs.Show()
    End Sub

    Private Sub cmdWireyardInvnetoryCoilWIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWireyardInvnetoryCoilWIP.Click
        Dim newCoilWIPInventory As New CoilWIPInventory
        newCoilWIPInventory.Show()
    End Sub

    Private Function canChangeCompany() As Boolean
        If System.Windows.Forms.Application.OpenForms.Count > 1 Then
            Dim dial As DialogResult = MessageBox.Show("Any open form will close and all unsaved data will be lost. Do you wish to continue?", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If dial = Windows.Forms.DialogResult.Yes Then
                Dim i As Integer = 0
                While i < System.Windows.Forms.Application.OpenForms.Count
                    If Not System.Windows.Forms.Application.OpenForms(i).Name.Equals(Me.Name) Then
                        System.Windows.Forms.Application.OpenForms(i).Close()
                    Else
                        i += 1
                    End If
                End While
            ElseIf dial = Windows.Forms.DialogResult.No Then
                MsgBox("You cannot change company with open forms. Please close all other forms first.", MsgBoxStyle.OkOnly)
                Return False
            Else
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboCompanyName.Text) Then
            MessageBox.Show("You must select a company code", "Select a comapny code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCompanyName.Focus()
            Return False
        End If
        If cboCompanyName.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid company code", "Enter a valid company code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCompanyName.SelectAll()
            cboCompanyName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub txtLoginName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginName.TextChanged
        LoginLast = txtLoginName.Text
        cboLoginName.Text = LoginLast
    End Sub

    Private Sub txtLoginPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoginPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdEnter.PerformClick()
        End If
    End Sub

    Private Sub txtLoginPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginPassword.TextChanged
        EmployeeSalespersonCode = cboSalesPersonID.Text
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub WriteLogoffLog()

        cmd = New SqlCommand("UPDATE UserLoginTable SET LogoutDateTime = @LogoutDateTime, TodaysDate = @TodaysDate WHERE SessionID = @SessionID", con)

        With cmd.Parameters
            .Add("@SessionID", SqlDbType.VarChar).Value = GlobalSessionID
            .Add("@LogoutDateTime", SqlDbType.VarChar).Value = Today.Now.ToString()
            .Add("@TodaysDate", SqlDbType.VarChar).Value = Now()
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboCompanyName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCompanyName.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdEnter.PerformClick()
        End If
    End Sub

    Private Sub LoadWireyardTabletView()
        gpxWireyardTabletView.Visible = True
        gpxWireyardTabletView.BringToFront()
        RemoveDesktopMenu()
    End Sub

    Private Sub RemoveDesktopMenu()
        gpxGeneralInfo.Visible = False
        cmdAPMenu.Visible = False
        cmdARMenu.Visible = False
        cmdChangeCompany.Visible = False
        cmdComputerToolsMenu.Visible = False
        cmdFactoryOrderMenu.Visible = False
        cmdGeneralInfo.Visible = False
        cmdInventoryMenu.Visible = False
        cmdProductionMenu.Visible = False
        cmdQualityControlMenu.Visible = False
        cmdRawMaterialsMenu.Visible = False
        cmdSalesOrderMenu.Visible = False
        cmdShippingMenu.Visible = False
        cmdTFPReports.Visible = False
        cmdToolRoom.Visible = False
        cmdPurchaseOrderMenu.Visible = False
        cmdTruFitModule.Visible = False
        cmdExitProgram.Size = New System.Drawing.Size(180, 75)
        cmdExitProgram.Location = New System.Drawing.Point(cmdExitProgram.Location.X, cmdExitProgram.Location.Y - 100)
    End Sub

    Private Sub cmdWireRemovalTablet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWireRemovalTablet.Click
        Dim NewSteelWireYardRemoval As New SteelWireYardRemoval
        NewSteelWireYardRemoval.Show()
    End Sub

    Private Sub cmdWireyardAdditionTablet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWireyardAdditionTablet.Click
        Dim NewSteelWireYardEntry As New SteelWireYardEntry
        NewSteelWireYardEntry.Show()
    End Sub

    Private Sub cmdSplitCoilTablet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitCoilTablet.Click
        Dim newSplitCoil As New SplitCoilForm
        newSplitCoil.Show()
    End Sub

    Private Sub cmdDrawSteelTablet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDrawSteelTablet.Click
        Dim newDrawSteel As New DrawSteelForm
        newDrawSteel.Show()
    End Sub

    Private Sub cmdAnnealingLongTablet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnealingLongTablet.Click
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewAnnealingLogForm As New AnnealingLogForm
        NewAnnealingLogForm.Show()
    End Sub

    Private Sub cmdViewSteelCoilsTablet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSteelCoilsTablet.Click
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewCharterSteelCoils As New ViewCharterSteelCoils
        NewViewCharterSteelCoils.Show()
    End Sub

    Private Sub cmdViewAnnealingLogTablet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAnnealingLogTablet.Click
        Dim NewViewAnnealingLog As New ViewAnnealingLog
        NewViewAnnealingLog.Show()
    End Sub

    Private Sub cmdPrintCoilLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCoilLabel.Click
        Dim newPrintCoilLabel As New PrintCoilLabel
        newPrintCoilLabel.Show()
    End Sub

    Private Sub llEnterDailyProductionPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterDailyProductionPM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is FerruleProductionEntry Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewFerruleProductionEntry As New FerruleProductionEntry
            NewFerruleProductionEntry.Show()
        End If
    End Sub

    Private Sub llCreateOrderFromPOSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateOrderFromPOSO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is CreateSOFromPO Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewCreateSOFromPO As New CreateSOFromPO
            NewCreateSOFromPO.Show()
        End If
    End Sub

    Private Sub llEditItemClassesIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEditItemClassesIV.LinkClicked
        Dim NewItemClassMaintenance As New ItemClassMaintenance
        NewItemClassMaintenance.Show()
    End Sub

    Private Sub llInventoryAdjustmentsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInventoryAdjustmentsIV.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is InventoryAdjustmentForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewInventoryAdjustmentForm As New InventoryAdjustmentForm
            NewInventoryAdjustmentForm.Show()
        End If
    End Sub

    Private Sub llViewCustomerListingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerListingSO.LinkClicked
        Dim NewViewCustomerListing As New ViewCustomerListing
        NewViewCustomerListing.Show()
    End Sub

    Private Sub llViewPendingShipmentsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPendingShipmentsSH.LinkClicked
        Dim NewViewPendingShipments As New ViewPendingShipments
        NewViewPendingShipments.Show()
    End Sub

    Private Sub llMillCertMenuQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMillCertMenuQC.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is MillCertForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewMillCertForm As New MillCertForm
            NewMillCertForm.Show()
        End If
    End Sub

    Private Sub llTWPullTestQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTWPullTestQC.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is PullTestData Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewPullTestData As New PullTestData
            NewPullTestData.Show()
        End If
    End Sub

    Private Sub llLotNumberMaintenanceQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLotNumberMaintenanceQC.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is LotNumberMaintenance Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewLotNumberMaintenance As New LotNumberMaintenance
            NewLotNumberMaintenance.Show()
        End If
    End Sub

    Private Sub llQCToolsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQCToolsQC.LinkClicked
        Dim NewQCTools As New QCTools
        NewQCTools.Show()
    End Sub

    Private Sub llOpenVendorCertsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQCViewSDSQC.LinkClicked
        Dim newSDS As New ViewUploadedSafetySheets
        newSDS.Show()
    End Sub

    Private Sub llViewVendorListingPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVendorListingPO.LinkClicked
        Dim NewViewVendorListing As New ViewVendorListing
        NewViewVendorListing.Show()
    End Sub

    Private Sub llFOXMaintenance05_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXMaintenanceIV.LinkClicked
        Dim NewFOXMenu As New FOXMenu
        NewFOXMenu.Show()
    End Sub

    Private Sub llSteelVendorReturnRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelVendorReturnRM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is SteelVendorReturnForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewSteelVendorReturn As New SteelVendorReturnForm
            NewSteelVendorReturn.Show()
        End If
    End Sub

    Private Sub llOpenOrdersSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOpenOrdersSO.LinkClicked
        Dim NewViewOpenSOLines As New ViewOpenSOLines
        NewViewOpenSOLines.Show()
    End Sub

    Private Sub llEnterRequisitionPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterRequisitionPO.LinkClicked
        Dim NewRequisitionForm As New RequisitionForm
        NewRequisitionForm.Show()
    End Sub

    Private Sub llSteelAdjustmentsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelAdjustmentsRM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is SteelAdjustmentForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewSteelAdjustmentForm As New SteelAdjustmentForm
            NewSteelAdjustmentForm.Show()
        End If
    End Sub

    Private Sub llViewSteelReceiptsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelReceiptsRM.LinkClicked
        Dim NewViewSteelReceipts As New ViewSteelReceipts
        NewViewSteelReceipts.Show()
    End Sub

    Private Sub llSteelCoilReceivingRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelCoilReceivingRM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is SteelReceivingByCoil Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewSteelCoilReceiving As New SteelReceivingByCoil()
            NewSteelCoilReceiving.Show()
        End If
    End Sub

    Private Sub llTruweldFOXListingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTruweldFOXListingFX.LinkClicked
        Dim NewViewFOXListing As New ViewFOXListing
        NewViewFOXListing.Show()
    End Sub

    Private Sub llVendorReturnPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorReturnPO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is VendorReturnForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewVendorReturnForm As New VendorReturnForm
            NewVendorReturnForm.Show()
        End If
    End Sub

    Private Sub llFOXMenuPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXMenuPM.LinkClicked
        Dim NewFOXMenu As New FOXMenu
        NewFOXMenu.Show()
    End Sub

    Private Sub llCreatePOFromSOPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreatePOFromSOPO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ConvertSOToPO Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewConvertSOToPO As New ConvertSOToPO
            NewConvertSOToPO.Show()
        End If
    End Sub

    Private Sub llMaintainPriceSheetsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainPriceSheetsIV.LinkClicked
        Dim NewItemPriceSheetMaintenance As New ItemPriceSheetMaintenance
        NewItemPriceSheetMaintenance.Show()
    End Sub

    Private Sub llProductionSchedulingPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProductionSchedulingPM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ProductionScheduling Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewProductionScheduling As New ProductionScheduling
            NewProductionScheduling.Show()
        End If
    End Sub

    Private Sub llViewQuoteListingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewQuoteListingSO.LinkClicked
        Dim NewViewQuoteListing As New ViewQuoteListing
        NewViewQuoteListing.Show()
    End Sub

    Private Sub llProductionSchedulingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProductionSchedulingFX.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ProductionScheduling Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewProductionScheduling As New ProductionScheduling
            NewProductionScheduling.Show()
        End If
    End Sub

    Private Sub llMinMaxMaintenanceFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMinMaxMaintenanceFX.LinkClicked
        Dim NewItemMinMaxMaintenance As New ItemMinMaxMaintenance
        NewItemMinMaxMaintenance.Show()
    End Sub

    Private Sub llMaintainMinMaxDataIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainMinMaxDataIV.LinkClicked
        Dim NewItemMinMaxMaintenance As New ItemMinMaxMaintenance
        NewItemMinMaxMaintenance.Show()
    End Sub

    Private Sub llGLChartOfAccountsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLChartOfAccountsCT.LinkClicked
        Dim NewViewGLChartOfAccounts As New ViewGLChartOfAccounts
        NewViewGLChartOfAccounts.Show()
    End Sub

    Private Sub llGLTransactionListingCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLTransactionListingCT.LinkClicked
        Dim NewViewGLTransactionListing As New ViewGLTransactionListing
        NewViewGLTransactionListing.Show()
    End Sub

    Private Sub llManufacturingSetupFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llManufacturingSetupFX.LinkClicked
        Dim NewManufacturingMaintenance As New ManufacturingMaintenance
        NewManufacturingMaintenance.Show()
    End Sub

    Private Sub llWireYardAdditionRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llWireYardAdditionRM.LinkClicked
        Dim NewSteelWireYardEntry As New SteelWireYardEntry
        NewSteelWireYardEntry.Show()
    End Sub

    Private Sub llJournalTransactionsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llJournalTransactionsCT.LinkClicked
        Dim NewGLJournalTransactions As New GLJournalTransactions
        NewGLJournalTransactions.Show()
    End Sub

    Private Sub llViewReceivingTickets_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReceivingTickets.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewReceivingHeaders As New ViewReceivingHeaders
        NewViewReceivingHeaders.Show()
    End Sub

    Private Sub llCreateAPBatchesAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateAPBatchesAP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is APProcessBatch Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewAPProcessBatch As New APProcessBatch
            NewAPProcessBatch.Show()
        End If
    End Sub

    Private Sub llCompanyTotalsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCompanyTotalsCT.LinkClicked
        Dim NewAllCompanyTotals As New AllCompanyTotals
        NewAllCompanyTotals.Show()
    End Sub

    Private Sub llViewCustomerListingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerListingAR.LinkClicked
        Dim NewViewCustomerListing As New ViewCustomerListing
        NewViewCustomerListing.Show()
    End Sub

    Private Sub llProcessInvoiceBatchAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProcessInvoiceBatchAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ARProcessBatch Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewARProcessBatch As New ARProcessBatch
            NewARProcessBatch.Show()
        End If
    End Sub

    Private Sub llProcessInvoiceForPaymentAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProcessInvoiceForPaymentAP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is APProcessForPayment Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewAPProcessForPayment As New APProcessForPayment
            NewAPProcessForPayment.Show()
        End If
    End Sub

    Private Sub llViewPickTicketsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPickTicketsSH.LinkClicked
        Dim NewViewPickTickets As New ViewPickTickets
        NewViewPickTickets.Show()
    End Sub

    Private Sub llLotNumberListingQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLotNumberListingQC.LinkClicked
        Dim NewViewLotNumbers As New ViewLotNumbers
        NewViewLotNumbers.Show()
    End Sub

    Private Sub llViewVendorReturnListingPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVendorReturnListingPO.LinkClicked
        Dim NewViewVendorReturns As New ViewVendorReturns
        NewViewVendorReturns.Show()
    End Sub

    Private Sub llMaintainRecurringAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainRecurringAP.LinkClicked
        Dim NewMaintainRecurringVouchers As New MaintainRecurringVouchers
        NewMaintainRecurringVouchers.Show()
    End Sub

    Private Sub llMaintainBackOrdersSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainBackOrdersSH.LinkClicked
        Dim NewViewBackOrders As New ViewBackOrders
        NewViewBackOrders.Show()
    End Sub

    Private Sub llViewTimeSlipPostingsPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewTimeSlipPostingsPM.LinkClicked
        Dim NewViewTimeSlipTotals As New ViewTimeSlipTotals
        NewViewTimeSlipTotals.Show()
    End Sub

    Private Sub llMaintainMachineDataPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainMachineDataPM.LinkClicked
        Dim NewManufacturingMaintenance As New ManufacturingMaintenance
        NewManufacturingMaintenance.Show()
    End Sub

    Private Sub llViewFOXListingPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFOXListingPM.LinkClicked
        Dim NewViewFOXListing As New ViewFOXListing
        NewViewFOXListing.Show()
    End Sub

    Private Sub llViewShippingChargesAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShippingChargesAP.LinkClicked
        Dim NewViewShippingFreightDetails As New ViewShippingFreightDetails
        NewViewShippingFreightDetails.Show()
    End Sub

    Private Sub llViewVendorListingAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVendorListingAP.LinkClicked
        Dim NewViewVendorListing As New ViewVendorListing
        NewViewVendorListing.Show()
    End Sub

    Private Sub llViewVendorReturnsAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVendorReturnsAP.LinkClicked
        Dim NewViewVendorReturns As New ViewVendorReturns
        NewViewVendorReturns.Show()
    End Sub

    Private Sub llViewVoucherListingAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVoucherListingAP.LinkClicked
        Dim NewViewVoucherListing As New ViewVoucherListing
        NewViewVoucherListing.Show()
    End Sub

    Private Sub llItemMaintenanceSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemMaintenanceSH.LinkClicked
        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub llViewLotNumbersSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLotNumbersSH.LinkClicked
        Dim NewViewLotNumbers As New ViewLotNumbers
        NewViewLotNumbers.Show()
    End Sub

    Private Sub llCompleteShipmentsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCompleteShipmentsSH.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ShipmentCompletion Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewShipmentCompletion As New ShipmentCompletion
            NewShipmentCompletion.Show()
        End If
    End Sub

    Private Sub llInventoryRackingSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInventoryRackingSH.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is InventoryRacking Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewInventoryRacking As New InventoryRacking
            NewInventoryRacking.Show()
        End If
    End Sub

    Private Sub llStockStatusSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llStockStatusSH.LinkClicked
        Dim NewInventoryStatus As New InventoryStatus
        NewInventoryStatus.Show()
    End Sub

    Private Sub llShipmentStatusSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShipmentStatusSH.LinkClicked
        Dim NewViewShipmentStatus As New ViewShipmentStatus
        NewViewShipmentStatus.Show()
    End Sub

    Private Sub llViewItemListingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewItemListingIV.LinkClicked
        Dim NewViewItemListing As New ViewItemListing
        NewViewItemListing.Show()
    End Sub

    Private Sub llDailySnapShotGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDailySnapShotGI.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is DailyTotals Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewDailyTotals As New DailyTotals
            NewDailyTotals.Show()
        End If
    End Sub

    Private Sub llMaintainCustomerAccountsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainCustomerAccountsAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ARCustomerAccounts Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewARCustomerAccounts As New ARCustomerAccounts
            NewARCustomerAccounts.Show()
        End If
    End Sub

    Private Sub llSteelPurchaseForm_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelPurchaseFormRM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is SteelPurchaseOrder Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewSteelPurchaseOrder As New SteelPurchaseOrder
            NewSteelPurchaseOrder.Show()
        End If
    End Sub

    Private Sub llWireYardSteelRemovalRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llWireYardSteelRemovalRM.LinkClicked
        Dim NewSteelWireYardRemoval As New SteelWireYardRemoval
        NewSteelWireYardRemoval.Show()
    End Sub

    Private Sub llShippingLabelsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShippingLabelsSH.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is Barcode1 Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewBarcode1 As New Barcode1
            NewBarcode1.Show()
        End If
    End Sub

    Private Sub llViewAgedPayablesByDateCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAgedPayablesByDateCT.LinkClicked
        Dim NewAPAgedPayablesDated As New APAgedPayablesDated
        NewAPAgedPayablesDated.Show()
    End Sub

    Private Sub llViewShipmentsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentsSO.LinkClicked
        Dim NewViewShipmentStatus As New ViewShipmentStatus
        NewViewShipmentStatus.Show()
    End Sub

    Private Sub llViewShipmentLines_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentLinesSO.LinkClicked
        Dim NewViewShipmentLines As New ViewShipmentLines
        NewViewShipmentLines.Show()
    End Sub

    Private Sub llViewShippingCharges_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShippingChargesSH.LinkClicked
        Dim NewViewShippingFreightDetails As New ViewShippingFreightDetails
        NewViewShippingFreightDetails.Show()
    End Sub

    Private Sub llProcessCashReceiptsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProcessCashReceiptsAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ARProcessPaymentBatch Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewARProcessPaymentBatch As New ARProcessPaymentBatch
            NewARProcessPaymentBatch.Show()
        End If
    End Sub

    Private Sub llFastenerInventoryLogFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFastenerInventoryLogFX.LinkClicked
        Dim NewViewTFPInventory As New ViewTFPInventory
        NewViewTFPInventory.Show()
    End Sub

    Private Sub llViewReleaseScheduleSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReleaseScheduleSH.LinkClicked
        Dim NewViewFOXReleaseSchedule As New ViewFOXReleaseSchedule
        NewViewFOXReleaseSchedule.Show()
    End Sub

    Private Sub llViewSalesLinesGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesLinesGI.LinkClicked
        Dim NewViewSalesLines As New ViewSalesLines
        NewViewSalesLines.Show()
    End Sub

    Private Sub llViewShipmentLinesGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentLinesGI.LinkClicked
        Dim NewViewShipmentLines As New ViewShipmentLines
        NewViewShipmentLines.Show()
    End Sub

    Private Sub llViewPurchaseLinesGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPurchaseLinesGI.LinkClicked
        Dim NewViewPurchaseLines As New ViewPurchaseLines
        NewViewPurchaseLines.Show()
    End Sub

    Private Sub llViewReceiverLinesGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReceiverLinesGI.LinkClicked
        Dim NewViewReceiverLines As New ViewReceiverLines
        NewViewReceiverLines.Show()
    End Sub

    Private Sub llCurrentAnnouncementsGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCurrentAnnouncementsGI.LinkClicked
        Dim NewCurrentAnnouncements As New CurrentAnnouncements
        NewCurrentAnnouncements.Show()
    End Sub

    Private Sub llViewAPAgingAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAPAgingAP.LinkClicked
        Dim NewViewAPAging As New ViewAPAging
        NewViewAPAging.Show()
    End Sub

    Private Sub llViewARAgingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewARAgingAR.LinkClicked
        Dim NewViewARAging As New ViewARAging
        NewViewARAging.Show()
    End Sub

    Private Sub llViewSteelAdjustmentsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelAdjustmentsRM.LinkClicked
        Dim NewViewSteelAdjustments As New ViewSteelAdjustments
        NewViewSteelAdjustments.Show()
    End Sub

    Private Sub llViewWireYardRemovalRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewWireYardRemovalRM.LinkClicked
        Dim NewViewSteelUsage As New ViewSteelUsage
        NewViewSteelUsage.Show()
    End Sub

    Private Sub llItemMaintenanceFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemMaintenanceFX.LinkClicked
        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub llStockStatusFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llStockStatusFX.LinkClicked
        Dim NewInventoryStatus As New InventoryStatus
        NewInventoryStatus.Show()
    End Sub

    Private Sub llViewLotNumberListingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLotNumberListingFX.LinkClicked
        Dim NewViewLotNumbers As New ViewLotNumbers
        NewViewLotNumbers.Show()
    End Sub

    Private Sub llSteelUsageByMonthRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelUsageByMonthRM.LinkClicked
        Dim NewViewSteelUsageByMonth As New ViewSteelUsageByMonth
        NewViewSteelUsageByMonth.Show()
    End Sub

    Private Sub llCheckRegisterAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCheckRegisterAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintCheckRegister As New PrintCheckRegister
        NewPrintCheckRegister.Show()
    End Sub

    Private Sub llDiscreptancyReportIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDiscreptancyReportIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintTWDDiscreptancyReport As New PrintTFPDiscrepancyReport
        NewPrintTWDDiscreptancyReport.Show()
    End Sub

    Private Sub llTFPCertificationMenu_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim NewTrufitMaterialCompliance As New TrufitMaterialCompliance
        NewTrufitMaterialCompliance.Show()
    End Sub

    Private Sub llCustomerMenuTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerMenuTFP.LinkClicked
        Dim NewCustomerData As New CustomerData
        NewCustomerData.Show()
    End Sub

    Private Sub llFOXProgramTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXProgramTFP.LinkClicked
        Dim NewFOXMenu As New FOXMenu
        NewFOXMenu.Show()
    End Sub

    Private Sub llQuoteProgramTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQuoteProgramTFP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is TFPQuoteForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewTFPQuoteForm As New TFPQuoteForm
            NewTFPQuoteForm.Show()
        End If
    End Sub

    Private Sub llViewPendingShipmentsTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPendingShipmentsTFP.LinkClicked
        Dim NewViewPendingShipments As New ViewPendingShipments
        NewViewPendingShipments.Show()
    End Sub

    Private Sub llEnterRequisitionsTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterRequisitionsTFP.LinkClicked
        Dim NewRequisitionForm As New RequisitionForm
        NewRequisitionForm.Show()
    End Sub

    Private Sub llCertificateOfMaterialQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCertificateOfMaterialQC.LinkClicked
        Dim NewTrufitMaterialCompliance As New TrufitMaterialCompliance
        NewTrufitMaterialCompliance.Show()
    End Sub

    Private Sub llHeatTreatInspectionLogQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llHeatTreatInspectionLogQC.LinkClicked
        Dim NewHeatTreatDataForm As New HeatTreatDataForm
        NewHeatTreatDataForm.Show()
    End Sub

    Private Sub llViewFOXListingQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFOXListingQC.LinkClicked
        Dim NewViewFOXListing As New ViewFOXListing
        NewViewFOXListing.Show()
    End Sub

    Private Sub llViewInventoryTransactionsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInventoryTransactionsIV.LinkClicked
        Dim NewViewInventoryTransactions As New ViewInventoryTransactions
        NewViewInventoryTransactions.Show()
    End Sub

    Private Sub llEnterMillCertDataFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterMillCertDataFX.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is MillCertForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewMillCertForm As New MillCertForm
            NewMillCertForm.Show()
        End If
    End Sub

    Private Sub llViewPOHeadersPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPOHeadersPO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewPOHeaders As New ViewPOHeaders
        NewViewPOHeaders.Show()
    End Sub

    Private Sub llViewPOLines_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPOLines.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewPurchaseLines As New ViewPurchaseLines
        NewViewPurchaseLines.Show()
    End Sub

    Private Sub llViewFOXReleaseSchedulePM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFOXReleaseSchedulePM.LinkClicked
        Dim NewViewFOXReleaseSchedule As New ViewFOXReleaseSchedule
        NewViewFOXReleaseSchedule.Show()
    End Sub

    Private Sub llFoxReleaseScheduleTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFoxReleaseScheduleTFP.LinkClicked
        Dim NewViewFOXReleaseSchedule As New ViewFOXReleaseSchedule
        NewViewFOXReleaseSchedule.Show()
    End Sub

    Private Sub llSalesOrderTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSalesOrderTFP.LinkClicked
        Dim NewSOForm As New SOForm
        NewSOForm.Show()
    End Sub

    Private Sub llViewPickTicketsTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPickTicketsTFP.LinkClicked
        Dim NewViewPickQuantityOnHand As New ViewPickQuantityOnHand
        NewViewPickQuantityOnHand.Show()
    End Sub

    Private Sub llShipmentCompletionTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShipmentCompletionTFP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ShipmentCompletion Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewShipmentCompletion As New ShipmentCompletion
            NewShipmentCompletion.Show()
        End If
    End Sub

    Private Sub llTFPItemListing_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewItemListingTFP.LinkClicked
        Dim NewViewItemListing As New ViewItemListing
        NewViewItemListing.Show()
    End Sub

    Private Sub llItemMaintenanceTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemMaintenanceTFP.LinkClicked
        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub llViewHeatTreatLogQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewHeatTreatLogQC.LinkClicked
        Dim NewViewHeatTreatInspectionLog As New ViewHeatTreatInspectionLog
        NewViewHeatTreatInspectionLog.Show()
    End Sub

    Private Sub llConsignmentShippingGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentShippingGI.LinkClicked
        Dim NewViewConsignmentShipping As New ViewConsignmentShipping
        NewViewConsignmentShipping.Show()
    End Sub

    Private Sub llConsignmentBillingGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentBillingGI.LinkClicked
        Dim NewViewConsignmentBilling As New ViewConsignmentBilling
        NewViewConsignmentBilling.Show()
    End Sub

    Private Sub llConsignmentAdjustmentsGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentAdjustmentsGI.LinkClicked
        Dim NewViewConsignmentAdjustments As New ViewConsignmentAdjustments
        NewViewConsignmentAdjustments.Show()
    End Sub

    Private Sub llViewAnnealingLogRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAnnealingLogRM.LinkClicked
        Dim NewViewAnnealingLog As New ViewAnnealingLog
        NewViewAnnealingLog.Show()
    End Sub

    Private Sub llViewSteelListRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelListRM.LinkClicked
        Dim NewViewSteelList As New ViewSteelList
        NewViewSteelList.Show()
    End Sub

    Private Sub llViewSteelListGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelListGI.LinkClicked
        Dim NewViewSteelList As New ViewSteelList
        NewViewSteelList.Show()
    End Sub

    Private Sub llViewPullTestsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPullTestsQC.LinkClicked
        Dim NewViewPullTests As New ViewPullTests
        NewViewPullTests.Show()
    End Sub

    Private Sub llViewCashReceiptsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCashReceiptsAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewCashReceipts As New ViewCashReceipts
        NewViewCashReceipts.Show()
    End Sub

    Private Sub llOpenInventoryValuationCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOpenInventoryValuationCT.LinkClicked
        Dim NewInventoryValuation As New InventoryValuation
        NewInventoryValuation.Show()
    End Sub

    Private Sub llGLTrialBalanceCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLTrialBalanceCT.LinkClicked
        Dim NewGLAccountsByDate As New GLAccountsByDate
        NewGLAccountsByDate.Show()
    End Sub

    Private Sub llViewShipmentListingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentListingTFP.LinkClicked
        Dim NewViewShipmentStatus As New ViewShipmentStatus
        NewViewShipmentStatus.Show()
    End Sub

    Private Sub llViewShipmentDetailsTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentDetailsTFP.LinkClicked
        Dim NewViewShipmentLines As New ViewShipmentLines
        NewViewShipmentLines.Show()
    End Sub

    Private Sub llViewQuoteListingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewQuoteListingTFP.LinkClicked
        Dim NewViewTFPQuoteListing As New ViewTFPQuoteListing
        NewViewTFPQuoteListing.Show()
    End Sub

    Private Sub llViewSalesOrderListingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesOrderListingTFP.LinkClicked
        Dim NewViewSalesOrderHeaders As New ViewSalesOrderHeaders
        NewViewSalesOrderHeaders.Show()
    End Sub

    Private Sub llEnterCustomerReturnTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterCustomerReturnTFP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ReturnProductForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewReturnProductForm As New ReturnProductForm
            NewReturnProductForm.Show()
        End If
    End Sub

    Private Sub llViewSteelPurchasesRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelPurchasesRM.LinkClicked
        Dim NewViewSteelPurchaseLines As New ViewSteelPurchaseLines
        NewViewSteelPurchaseLines.Show()
    End Sub

    Private Sub llSteelInventoryValueRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelInventoryValueRM.LinkClicked
        Dim NewSteelValue As New ViewSteelInventoryValue
        NewSteelValue.Show()
    End Sub

    Private Sub llViewCoilInventoryRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCoilInventoryRM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        If Environment.MachineName.ToUpper.Contains("TABLET") Then 'Or Environment.MachineName.ToLower.Contains("agler") Then
            Dim NewViewCharterSteelCoils As New ViewCharterSteelCoils
            NewViewCharterSteelCoils.Show()
        Else
            Dim NewViewSteelCoils As New ViewSteelCoils
            NewViewSteelCoils.Show()
        End If
    End Sub

    Private Sub llViewInvoiceListingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInvoiceListingAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewInvoiceListing As New ViewInvoiceListing
        NewViewInvoiceListing.Show()
    End Sub

    Private Sub llViewSteelListPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelListPM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSteelList As New ViewSteelList
        NewViewSteelList.Show()
    End Sub

    Private Sub llSteelConsumptionPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelConsumptionPM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSteelUsage As New ViewSteelUsage
        NewViewSteelUsage.Show()
    End Sub

    Private Sub llPurchaseOrderFormAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPurchaseOrderFormAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPOForm As New POForm
        NewPOForm.Show()
    End Sub

    Private Sub llVendorReturnFormAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorReturnFormAP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is VendorReturnForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewVendorReturnForm As New VendorReturnForm
            NewVendorReturnForm.Show()
        End If
    End Sub

    Private Sub llARAgingRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llARAgingRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintARAging As New PrintARAging
            Dim Result = NewPrintARAging.ShowDialog
        End Using
    End Sub

    Private Sub llRackingReportRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRackingReportRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintInventoryDiscrepancyReport As New PrintInventoryDiscrepancyReport
            Dim Result = NewPrintInventoryDiscrepancyReport.ShowDialog
        End Using
    End Sub

    Private Sub llCashReceiptsRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCashReceiptsRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintCashReceipts As New PrintCashReceipts
            Dim Result = NewPrintCashReceipts.ShowDialog
        End Using
    End Sub

    Private Sub llCustomerPaymentHistoryRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerPaymentHistoryRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintCustomerPaymentActivity As New PrintCustomerPaymentActivity
            Dim Result = NewPrintCustomerPaymentActivity.ShowDialog()
        End Using
    End Sub

    Private Sub llInvoiceRegisterRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInvoiceRegisterRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintInvoiceRegister As New PrintInvoiceRegister
            Dim Result = NewPrintInvoiceRegister.ShowDialog
        End Using
    End Sub

    Private Sub llDiscrepancyReportRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDiscrepancyReportRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintTFPDiscrepancyReport As New PrintTFPDiscrepancyReport
            Dim Result = NewPrintTFPDiscrepancyReport.ShowDialog
        End Using
    End Sub

    Private Sub llSteelFOXReportRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelFOXReportRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintSteelReport As New PrintSteelReport
            Dim Result = NewPrintSteelReport.ShowDialog
        End Using
    End Sub

    Private Sub llAPAgingRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAPAgingRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintAPAging As New PrintAPAging
            Dim Result = NewPrintAPAging.ShowDialog
        End Using
    End Sub

    Private Sub llAPCheckRegisterRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAPCheckRegisterRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintCheckRegister As New PrintCheckRegister
            Dim Result = NewPrintCheckRegister.ShowDialog
        End Using
    End Sub

    Private Sub llVendorListingRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorListingRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintVendorList As New PrintVendorList
            Dim Result = NewPrintVendorList.ShowDialog
        End Using
    End Sub

    Private Sub llCommissionReportRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCommissionReportRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintCommissionReport As New PrintCommissionReport
            Dim Result = NewPrintCommissionReport.ShowDialog
        End Using
    End Sub

    Private Sub llDailySalesReportRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDailySalesReportRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintInvoiceDailyTotals As New PrintInvoiceDailyTotals
            Dim Result = NewPrintInvoiceDailyTotals.ShowDialog
        End Using
    End Sub

    Private Sub llCustomerOrderHistoryRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerOrderHistoryRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintCustomerOrderHistory As New PrintCustomerOrderHistory
            Dim Result = NewPrintCustomerOrderHistory.ShowDialog
        End Using
    End Sub

    Private Sub llCustomerSalesByMonthRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerSalesByMonthRP.LinkClicked
        If EmployeeCompanyCode = "TFF" Or EmployeeCompanyCode = "TOR" Or EmployeeCompanyCode = "ALB" Then
            GlobalDivisionCode = EmployeeCompanyCode
            Using NewPrintCustomerSalesReport As New PrintCustomerSalesReportCAN
                Dim Result = NewPrintCustomerSalesReport.ShowDialog
            End Using
        Else
            GlobalDivisionCode = EmployeeCompanyCode
            Using NewPrintCustomerSalesReport As New PrintCustomerSalesReport
                Dim Result = NewPrintCustomerSalesReport.ShowDialog
            End Using
        End If
    End Sub

    Private Sub llCustomerMTDYTDRP_YTDInvoices_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerMTDYTDRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintCustomerMTDYTDTotals As New PrintCustomerMTDYTDTotals
            Dim Result = NewPrintCustomerMTDYTDTotals.ShowDialog
        End Using
    End Sub

    Private Sub llFOXByDateRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXByDateRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintFOXbyDate As New PrintFOXByDate
            Dim Result = NewPrintFOXbyDate.ShowDialog
        End Using
    End Sub

    Private Sub llFOXPostingReportRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXPostingReportRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintFOXPostingReport As New PrintFOXPostingReport
            Dim Result = NewPrintFOXPostingReport.ShowDialog
        End Using
    End Sub

    Private Sub llFOXReleaseScheduleFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXReleaseScheduleRP.LinkClicked, llFOXReleaseScheduleFX.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewFOXReleaseSchedule As New ViewFOXReleaseSchedule
        NewViewFOXReleaseSchedule.Show()
    End Sub

    Private Sub llChartOfAccountsRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llChartOfAccountsRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintGLChartOfAccounts As New PrintGLChartOfAccounts
            Dim Result = NewPrintGLChartOfAccounts.ShowDialog
        End Using
    End Sub

    Private Sub llGLWTBRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLWTBRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintGLWTB As New PrintGLWTB
            Dim Result = NewPrintGLWTB.ShowDialog
        End Using
    End Sub

    Private Sub llItemsSoldToCustomerRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemsSoldToCustomerRP.LinkClicked
        If EmployeeCompanyCode = "TFF" Or EmployeeCompanyCode = "TOR" Or EmployeeCompanyCode = "ALB" Then
            GlobalDivisionCode = EmployeeCompanyCode
            Using NewPrintItemsSoldToCustomer As New PrintItemSoldToCustomerCanadian
                Dim Result = NewPrintItemsSoldToCustomer.ShowDialog
            End Using
        Else
            GlobalDivisionCode = EmployeeCompanyCode
            Using NewPrintItemsSoldToCustomer As New PrintItemsSoldToCustomer
                Dim Result = NewPrintItemsSoldToCustomer.ShowDialog
            End Using
        End If
    End Sub

    Private Sub llVenpaymentHistoryRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVenpaymentHistoryRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintVendorPaymentHistory As New PrintVendorPaymentHistory
            Dim Result = NewPrintVendorPaymentHistory.ShowDialog
        End Using
    End Sub

    Private Sub lllItemsPurfromVendorRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lllItemsPurfromVendorRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintItemspurchasedFromVendor As New PrintItemsPurchasedFromVendor
            Dim Result = NewPrintItemspurchasedFromVendor.ShowDialog
        End Using
    End Sub

    Private Sub llCostCenterReportRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCostCenterReportRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintMachineCOStCenterReport As New PrintMachineCostCenterReport
            Dim Result = NewPrintMachineCOStCenterReport.ShowDialog
        End Using
    End Sub

    Private Sub llTFPEmailListingGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTFPEmailListingGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintEmailList As New PrintEmailList
            Dim Result = NewPrintEmailList.ShowDialog
        End Using
    End Sub

    Private Sub llTFPPhoneDirectoryGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTFPPhoneDirectoryGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintPhoneList As New PrintPhoneList
            Dim Result = NewPrintPhoneList.ShowDialog
        End Using
    End Sub

    Private Sub llViewPriceBracketsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPriceBracketsIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewItemPriceSheet As New ItemPriceSheet
        NewItemPriceSheet.Show()
    End Sub

    Private Sub llViewLotNumberListingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLotNumberListingIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewLotNumbers As New ViewLotNumbers
        NewViewLotNumbers.Show()
    End Sub

    Private Sub llViewItemListingGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewItemListingGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewItemListing As New ViewItemListing
        NewViewItemListing.Show()
    End Sub

    Private Sub llViewFOXListingGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFOXListingGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewFOXListing As New ViewFOXListing
        NewViewFOXListing.Show()
    End Sub

    Private Sub llViewDailyShipmentLogSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewDailyShipmentLogSH.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewDailyShipmentLog As New ViewDailyShipmentLog
        NewViewDailyShipmentLog.Show()
    End Sub

    Private Sub llSalesOrderHeaderListingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSalesOrderHeaderListingSO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSalesOrderHeaders As New ViewSalesOrderHeaders
        NewViewSalesOrderHeaders.Show()
    End Sub

    Private Sub llViewCustomerReturnListingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerReturnListingAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewCustomerReturnListing As New ViewCustomerReturnListing
        NewViewCustomerReturnListing.Show()
    End Sub

    Private Sub llVendorReturnListingRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorReturnListingRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintVendorReturnListing As New PrintVendorReturnListing
        NewPrintVendorReturnListing.Show()
    End Sub

    Private Sub llViewSteelRequirementsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelRequirementsRM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSteelRequirements As New ViewSteelRequirements
        NewViewSteelRequirements.Show()
    End Sub

    Private Sub llItemPriceSheetRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemPriceSheetRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintItemPriceSheet As New PrintItemPriceSheet
            Dim Result = NewPrintItemPriceSheet.ShowDialog
        End Using
    End Sub

    Private Sub llViewSalesLinesAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesLinesAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSalesLines As New ViewSalesLines
        NewViewSalesLines.Show()
    End Sub

    Private Sub llViewHeatNumberListingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewHeatNumberListingFX.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewHeatNumberLog As New ViewHeatNumberLog
        NewViewHeatNumberLog.Show()
    End Sub

    Private Sub llViewPurchaseHeadersGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPurchaseHeadersGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewPOHeaders As New ViewPOHeaders
        NewViewPOHeaders.Show()
    End Sub

    Private Sub llViewSalesHeadersGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesHeadersGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSalesOrderHeaders As New ViewSalesOrderHeaders
        NewViewSalesOrderHeaders.Show()
    End Sub

    Private Sub llViewShipmentHeadersGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentHeadersGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewShipmentStatus As New ViewShipmentStatus
        NewViewShipmentStatus.Show()
    End Sub

    Private Sub llViewReceivingHeadersGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReceivingHeadersGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewReceivingHeaders As New ViewReceivingHeaders
        NewViewReceivingHeaders.Show()
    End Sub

    Private Sub llViewReceivingLine4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReceivingLine4.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewReceiverLines As New ViewReceiverLines
        NewViewReceiverLines.Show()
    End Sub

    Private Sub llViewItemListingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewItemListingFX.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewItemListing As New ViewItemListing
        NewViewItemListing.Show()
    End Sub

    Private Sub llItemMaintenanceQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemMaintenanceQC.LinkClicked
        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub llViewItemListingQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewItemListingQC.LinkClicked
        Dim NewViewItemListing As New ViewItemListing
        NewViewItemListing.Show()
    End Sub

    Private Sub llViewSalesHeadersAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesHeadersAR.LinkClicked
        Dim NewViewSalesOrderHeaders As New ViewSalesOrderHeaders
        NewViewSalesOrderHeaders.Show()
    End Sub

    Private Sub llDesignatePayablesAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDesignatePayablesAP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is APDesignatePayables Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewAPDesignatePayables As New APDesignatePayables
            NewAPDesignatePayables.Show()
        End If
    End Sub

    Private Sub llViewCustomerPaymentActivityAR_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerPaymentsAR.LinkClicked
        Dim NewViewCustomerPaymentActivity As New ViewCustomerPaymentActivity
        NewViewCustomerPaymentActivity.Show()
    End Sub

    Private Sub llViewLeadTimesPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLeadTimesPM.LinkClicked
        Dim NewViewLeadTimes As New ViewLeadTimes
        NewViewLeadTimes.Show()
    End Sub

    Private Sub llViewARAgingDatedCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewARAgingDatedCT.LinkClicked
        Dim NewARAgedReceivablesDated As New ARAgedReceivablesDated
        NewARAgedReceivablesDated.Show()
    End Sub

    Private Sub llViewAnnealingLogFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAnnealingLogFX.LinkClicked
        Dim NewViewAnnealingLog As New ViewAnnealingLog
        NewViewAnnealingLog.Show()
    End Sub

    Private Sub llInvoicingFormBillOnlyAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInvoicingFormBillOnlyAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is InvoiceBillOnly Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewInvoiceBillOnly As New InvoiceBillOnly
            NewInvoiceBillOnly.Show()
        End If
    End Sub

    Private Sub llReleaseDropShipsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llReleaseDropShipsAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ARSelectDropShipsForInvoicing Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewARSelectDropShipsForInvoicing As New ARSelectDropShipsForInvoicing
            NewARSelectDropShipsForInvoicing.Show()
        End If
    End Sub

    Private Sub llHeatLogListingQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llHeatLogListingQC.LinkClicked
        Dim NewViewHeatNumberLog As New ViewHeatNumberLog
        NewViewHeatNumberLog.Show()
    End Sub

    Private Sub llMaintainSteelTolerancesQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainSteelTolerancesQC.LinkClicked
        Dim NewSteelTolerances As New SteelTolerances
        NewSteelTolerances.Show()
    End Sub

    Private Sub llSalesRegister07_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintSalesOrderRegister As New PrintSalesbyMonth
        NewPrintSalesOrderRegister.Show()
    End Sub

    Private Sub llCreateBOLSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateBOLSH.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewShipmentBOLForm As New ShipmentBOLForm
        NewShipmentBOLForm.Show()
    End Sub

    Private Sub llViewOpenPOsPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewOpenPOsPO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewOpenPurchaseLines As New ViewOpenPurchaseLines
        NewViewOpenPurchaseLines.Show()
    End Sub

    Private Sub llViewVendorPurchaseHistory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim NewViewVendorPurchaseHistory As New ViewPurchaseLines
        NewViewVendorPurchaseHistory.Show()
    End Sub

    Private Sub llViewVendorPurchaseHistory1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVendorPurchaseHistory1.LinkClicked
        Dim NewViewVendorPurchaseHistory As New ViewPurchaseLines
        NewViewVendorPurchaseHistory.Show()
    End Sub

    Private Sub llGLAccountBalancesCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLAccountBalancesCT.LinkClicked
        Dim NewGLAccountBalances As New GLAccountBalances
        NewGLAccountBalances.Show()
    End Sub

    Private Sub llViewShipmentsForInvoicingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentsForInvoicingAR.LinkClicked
        Dim NewViewShipmentsForInvoicing As New ViewShipmentsForInvoicing
        NewViewShipmentsForInvoicing.Show()
    End Sub

    Private Sub llViewPendingShipmentsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPendingShipmentsSO.LinkClicked
        Dim NewViewPendingShipments As New ViewPendingShipments
        NewViewPendingShipments.Show()
    End Sub

    Private Sub llProcessReceiptOfGoodsPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProcessReceiptOfGoodsPO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is Receiving Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewReceiving As New Receiving
            NewReceiving.Show()
        End If
    End Sub

    Private Sub llEnterSalesOrderSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterSalesOrderSO.LinkClicked
        Dim NewSOForm As New SOForm
        NewSOForm.Show()
    End Sub

    Private Sub llEndProgram_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        End
    End Sub

    Private Sub llUserInfoMenuCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llUserInfoMenuCT.LinkClicked
        Dim NewEmployeeDataForm As New EmployeeData
        NewEmployeeDataForm.Show()
    End Sub

    Private Sub llEnterQuoteSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterQuoteSO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is QuoteForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewQuoteForm As New QuoteForm
            NewQuoteForm.Show()
        End If
    End Sub

    Private Sub llViewPendingPicksSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPendingPicksSO.LinkClicked
        Dim NewViewPickQuantityOnHand As New ViewPickQuantityOnHand
        NewViewPickQuantityOnHand.Show()
    End Sub

    Private Sub llItemMaintenanceFormIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemMaintenanceFormIV.LinkClicked
        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub llEnterPurchaseOrderPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterPurchaseOrderPO.LinkClicked
        Dim NewPOForm As New POForm
        NewPOForm.Show()
    End Sub

    Private Sub llVendorFormPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorFormPO.LinkClicked
        Dim NewVendorInformation As New VendorInformation
        NewVendorInformation.Show()
    End Sub

    Private Sub llViewReturnListingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReturnListingSO.LinkClicked
        Dim NewViewCustomerReturnListing As New ViewCustomerReturnListing
        NewViewCustomerReturnListing.Show()
    End Sub

    Private Sub llCustomerMaintenanceAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerMaintenanceAR.LinkClicked
        Dim NewCustomerData As New CustomerData
        NewCustomerData.Show()
    End Sub

    Private Sub llCustomerMaintenanceSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerMaintenanceSO.LinkClicked
        Dim NewCustomerData As New CustomerData
        NewCustomerData.Show()
    End Sub

    Private Sub llMaintainNonInventoryItemsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainNonInventoryItemsIV.LinkClicked
        Dim NewNonInventoryItems As New NonInventoryItems
        NewNonInventoryItems.Show()
    End Sub

    Private Sub llSteelReceivingFormRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelReceivingFormRM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is SteelReceivingForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewSteelReceivingForm As New SteelReceivingForm
            NewSteelReceivingForm.Show()
        End If
    End Sub

    Private Sub llInventoryRackingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInventoryRackingIV.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is InventoryRacking Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewInventoryRacking As New InventoryRacking
            NewInventoryRacking.Show()
        End If
    End Sub

    Private Sub llViewOpenPicksSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewOpenPicksSH.LinkClicked
        Dim NewViewPickQuantityOnHand As New ViewPickQuantityOnHand
        NewViewPickQuantityOnHand.Show()
    End Sub

    Private Sub llRawMaterialFormRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRawMaterialFormRM.LinkClicked
        Dim NewRawMaterialMaintenanceForm As New RawMaterialMaintenanceForm
        NewRawMaterialMaintenanceForm.Show()
    End Sub

    Private Sub llVendorFormAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorFormAP.LinkClicked
        Dim NewVendorInformation As New VendorInformation
        NewVendorInformation.Show()
    End Sub

    Private Sub llFOXDataFormFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXDataFormFX.LinkClicked
        Dim NewFOXMenu As New FOXMenu
        NewFOXMenu.Show()
    End Sub

    Private Sub llEnterCustomerReturnSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterCustomerReturnSO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ReturnProductForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewReturnProductForm As New ReturnProductForm
            NewReturnProductForm.Show()
        End If
    End Sub

    Private Sub llAssemblyProgramPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAssemblyProgramPM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is AssemblyBuildForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewAssemblyBuildForm As New AssemblyBuildForm
            NewAssemblyBuildForm.Show()
        End If
    End Sub

    Private Sub llTimeSlipMenuPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTimeSlipMenuPM.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is TimeSlipForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewTimeSlipForm As New TimeSlipForm
            NewTimeSlipForm.Show()
        End If
    End Sub

    Private Sub llMaintainShippingMethodFormSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainShippingMethodFormSH.LinkClicked
        Dim NewShipperInfo As New ShipperInfo
        NewShipperInfo.Show()
    End Sub

    Private Sub llFOXFormQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFOXFormQC.LinkClicked
        Dim NewFOXMenu As New FOXMenu
        NewFOXMenu.Show()
    End Sub

    Private Sub llViewInvoiceLinesAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInvoiceLinesAR.LinkClicked
        Dim NewViewInvoiceLines As New ViewInvoiceLines
        NewViewInvoiceLines.Show()
    End Sub

    Private Sub llDailySnapshotAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDailySnapshotAR.LinkClicked
        Dim NewDailyTotals As New DailyTotals
        NewDailyTotals.Show()
    End Sub

    Private Sub llViewCustomerNotesSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerNotesSO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode

        Dim NewCustomerNotes As New CustomerNotes
        NewCustomerNotes.Show()
    End Sub

    Private Sub llFilterByDateAccountCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFilterByDateAccountCT.LinkClicked
        Dim NewGLAccountsByDate As New GLAccountsByDate
        NewGLAccountsByDate.Show()
    End Sub

    Private Sub llViewAllShipmentsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAllShipmentsSH.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ShipmentLineComments Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewShipmentLineComments As New ShipmentLineComments
            NewShipmentLineComments.Show()
        End If
    End Sub

    Private Sub llViewPaidVouchersAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPaidVouchersAP.LinkClicked
        Dim NewViewAPVouchersPaid As New ViewAPVouchersPaid
        NewViewAPVouchersPaid.Show()
    End Sub

    Private Sub llAPCheckReversalAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAPCheckReversalAP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is APCheckReversal Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewAPCheckReversal As New APCheckReversal
            NewAPCheckReversal.Show()
        End If
    End Sub

    Private Sub llGLInvoiceLinesRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLInvoiceLinesRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintInvoiceGLAccountDetail As New PrintInvoiceGLAccountDetail
            Dim Result = NewPrintInvoiceGLAccountDetail.ShowDialog
        End Using
    End Sub

    Private Sub llPurchaseClearingReportAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPurchaseClearingReportAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintPurchaseClearingReport2 As New PrintPurchaseClearingReport2
            Dim Result = NewPrintPurchaseClearingReport2.ShowDialog
        End Using
    End Sub

    Private Sub llViewInvoiceLinesGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInvoiceLinesGI.LinkClicked
        Dim NewViewInvoiceLines As New ViewInvoiceLines
        NewViewInvoiceLines.Show()
    End Sub

    Private Sub llViewInvoiceHeadersGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInvoiceHeadersGI.LinkClicked
        Dim NewViewInvoiceListing As New ViewInvoiceListing
        NewViewInvoiceListing.Show()
    End Sub

    Private Sub llViewAPChecksAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAPChecksAP.LinkClicked
        Dim NewViewAPCheckLog As New ViewAPCheckLog
        NewViewAPCheckLog.Show()
    End Sub

    Private Sub llViewWCProductionPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewWCProductionPM.LinkClicked
        Dim NewViewWCProductionPostings As New ViewWCProductionPostings
        NewViewWCProductionPostings.Show()
    End Sub

    Private Sub llFinancialReportsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFinancialReportsCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewFinancialReports As New FinancialReports
        NewFinancialReports.Show()
    End Sub

    Private Sub llCreateAssembliesIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateAssembliesIV.LinkClicked
        If EmployeeCompanyCode = "TWE" Or EmployeeCompanyCode = "TST" Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewAssemblyBuildSerialized As New AssemblyBuildSerialized
            NewAssemblyBuildSerialized.Show()
        Else
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewAssemblyBuildForm As New AssemblyBuildForm
            NewAssemblyBuildForm.Show()
        End If
    End Sub

    Private Sub llViewEditPostedInvoiceAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewEditPostedInvoiceAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewInvoiceDetails As New ViewInvoiceDetails
        NewViewInvoiceDetails.Show()
    End Sub

    Private Sub llInspectionFormQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInspectionFormQC.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewInspectionReport As New InspectionReport
        NewInspectionReport.Show()
    End Sub

    Private Sub llCustomerSalesRankingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerSalesRankingSO.LinkClicked
        Dim NewCustomerSalesRanking As New CustomerSalesRanking
        NewCustomerSalesRanking.Show()
    End Sub

    Private Sub llInventoryCostTiersIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInventoryCostTiersIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewInventoryCosting As New InventoryCosting
        NewInventoryCosting.Show()
    End Sub

    Private Sub llShipmentCompletionSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShipmentCompletionSO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ShipmentCompletion Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewShipmentCompletion As New ShipmentCompletion
            NewShipmentCompletion.Show()
        End If
    End Sub

    Private Sub llViewInventoryAdjustmentsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInventoryAdjustmentsIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewInventoryAdjustments As New ViewInventoryAdjustments
        NewViewInventoryAdjustments.Show()
    End Sub

    Private Sub llViewVendorPurchaseSummary_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVendorPurchaseSummary.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewVendorSummary As New ViewVendorSummary
        NewViewVendorSummary.Show()
    End Sub

    Private Sub llEditCompanyDataCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEditCompanyDataCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewEditCompanyInfo As New EditCompanyInfo
        NewEditCompanyInfo.Show()
    End Sub

    Private Sub llMaintainPaymentTermsAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainPaymentTermsAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPaymentTermsMaintenance As New PaymentTermsMaintenance
        NewPaymentTermsMaintenance.Show()
    End Sub

    Private Sub llMaintainVendorClassesAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainVendorClassesAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewVendorClassMaintenance As New VendorClassMaintenance
        NewVendorClassMaintenance.Show()
    End Sub

    Private Sub llStockStatusWithValuationCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llStockStatusWithValuationCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewStockStatusValuation As New ViewStockStatusValuation
        NewViewStockStatusValuation.Show()
    End Sub

    Private Sub llBankReconciliationCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llBankReconciliationCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewBankReconciliation As New BankReconciliation
        NewBankReconciliation.Show()
    End Sub

    Private Sub llViewDailyShipmentLogGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewDailyShipmentLogGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewDailyShipmentLog As New ViewDailyShipmentLog
        NewViewDailyShipmentLog.Show()
    End Sub

    Private Sub llViewReceivingLinesAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReceivingLinesAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewReceiverLines As New ViewReceiverLines
        NewViewReceiverLines.Show()
    End Sub

    Private Sub llViewSalesLinesSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesLinesSO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSalesLines As New ViewSalesLines
        NewViewSalesLines.Show()
    End Sub

    Private Sub llItemMaintenanceSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemMaintenanceSO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub llViewEditVoucherAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewEditVoucherAP.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is APViewVoucherLines Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewAPViewVoucherLines As New APViewVoucherLines
            NewAPViewVoucherLines.Show()
        End If
    End Sub

    Private Sub llViewLeadTimesSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLeadTimesSO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewLeadTimes As New ViewLeadTimes
        NewViewLeadTimes.Show()
    End Sub

    Private Sub llViewManualBOLsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewManualBOLsSH.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewManualBOLs As New ViewManualBOLs
        NewViewManualBOLs.Show()
    End Sub

    Private Sub llViewVoucherPostings_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVoucherPostingsAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewAPVoucherPostings As New ViewAPVoucherPostings
        NewViewAPVoucherPostings.Show()
    End Sub

    Private Sub llViewItemListingSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewItemListingSH.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewItemListing As New ViewItemListing
        NewViewItemListing.Show()
    End Sub

    Private Sub llPaymentReversalAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPaymentReversalAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ARPaymentReversal Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalDivisionCode = EmployeeCompanyCode
            Dim NewARPaymentReversal As New ARPaymentReversal
            NewARPaymentReversal.Show()
        End If
    End Sub

    Private Sub llGLTransactionDetailsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLTransactionDetailsCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewGLTransactionBalanceDetails As New GLTransactionBalanceDetails
        GLTransactionBalanceDetails.Show()
    End Sub

    Private Sub llSalesTaxSummaryAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSalesTaxSummaryAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewTaxCollected As New ViewTaxCollected
        NewViewTaxCollected.Show()
    End Sub

    Private Sub llViewSerializedLogPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSerializedLogPM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewAssemblySerialLog As New ViewAssemblySerialLog
        NewViewAssemblySerialLog.Show()
    End Sub

    Private Sub llViewAssemblyListingPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAssemblyListingPM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewAssemblyListing As New ViewAssemblyListing
        NewViewAssemblyListing.Show()
    End Sub

    Private Sub llViewBuildListingPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewBuildListingPM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewAssemblyBuildListing As New ViewAssemblyBuildListing
        NewViewAssemblyBuildListing.Show()
    End Sub

    Private Sub llViewAssemblyHeadersIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAssemblyHeadersIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewAssemblyListing As New ViewAssemblyListing
        NewViewAssemblyListing.Show()
    End Sub

    Private Sub llViewAssemblyBuildListingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAssemblyBuildListingIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewAssemblyBuildListing As New ViewAssemblyBuildListing
        NewViewAssemblyBuildListing.Show()
    End Sub

    Private Sub llViewAssemblySerialLogIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAssemblySerialLogIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewAssemblySerialLog As New ViewAssemblySerialLog
        NewViewAssemblySerialLog.Show()
    End Sub

    Private Sub llInvoiceCostingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInvoiceCostingAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewInvoiceLines As New ViewInvoiceLines
        NewViewInvoiceLines.Show()
    End Sub

    Private Sub llViewSalesByCategorySO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesByCategorySO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSalesByCategory As New ViewSalesByCategory
        NewViewSalesByCategory.Show()
    End Sub

    Private Sub llPrintVendorPaymentHistory6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintVendorPaymentHistory6.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintVendorPaymentHistory As New PrintVendorPaymentHistory
        NewPrintVendorPaymentHistory.Show()
    End Sub

    Private Sub llPrintPurchaseClearingReport6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintPurchaseClearingReport6.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintPurchaseClearingReport2 As New PrintPurchaseClearingReport2
        NewPrintPurchaseClearingReport2.Show()
    End Sub

    Private Sub llSalesByStateRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSalesByStateRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintSalesByState As New PrintSalesByState
            Dim Result = NewPrintSalesByState.ShowDialog
        End Using
    End Sub

    Private Sub llInventoryUseByMonthRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInventoryUseByMonthRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintInventoryUsageByMonth As New PrintInventoryUsageByMonth
            Dim Result = NewPrintInventoryUsageByMonth.ShowDialog
        End Using
    End Sub

    Private Sub llViewAgedReceivablesAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAgedReceivablesAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewARAgedReceivablesDated As New ARAgedReceivablesDated
        NewARAgedReceivablesDated.Show()
    End Sub

    Private Sub llViewEditCustomerPaymentAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewEditCustomerPaymentAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is AREditCustomerPayment Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewAREditCustomerPayment As New AREditCustomerPayment
            NewAREditCustomerPayment.Show()
        End If
    End Sub

    Private Sub llMaintainBackOrdersSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainBackOrdersSO.LinkClicked
        Dim NewViewBackOrders As New ViewBackOrders
        NewViewBackOrders.Show()
    End Sub

    Private Sub llLetterHeadGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLetterHeadGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        System.Diagnostics.Process.Start("\\TFP-FS\TransferData\MOS PDF\Company Header.pdf")
    End Sub

    Private Sub llPurchaseClearingReportCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPurchaseClearingReportCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintPurchaseClearingReport2 As New PrintPurchaseClearingReport2
        NewPrintPurchaseClearingReport2.Show()
    End Sub

    Private Sub llViewPickTicketListingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPickTicketListingSO.LinkClicked
        Dim NewViewPickTickets As New ViewPickTickets
        NewViewPickTickets.Show()
    End Sub

    Private Sub llViewStockStatusPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewStockStatusPO.LinkClicked
        Dim NewInventoryStatus As New InventoryStatus
        NewInventoryStatus.Show()
    End Sub

    Private Sub llManualBankEntryCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llManualBankEntryCT.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is BankTransactionEntry Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewBankTransactionEntry As New BankTransactionEntry
            NewBankTransactionEntry.Show()
        End If
    End Sub

    Private Sub llCreateGLTemplateCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateGLTemplateCT.LinkClicked
        Dim NewGLTransactionTemplate As New GLTransactionTemplate
        NewGLTransactionTemplate.Show()
    End Sub

    Private Sub llViewInvoiceLinesSortedAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInvoiceLinesSortedAR.LinkClicked
        Dim NewViewInvoiceLinesBySort As New ViewInvoiceLinesBySort
        NewViewInvoiceLinesBySort.Show()
    End Sub

    Private Sub llSortedSalesViewerSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSortedSalesViewerSO.LinkClicked
        Dim NewViewInvoiceLinesBySort As New ViewInvoiceLinesBySort
        NewViewInvoiceLinesBySort.Show()
    End Sub

    Private Sub llViewMechTestListingQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewMechTestListingQC.LinkClicked
        Dim NewViewTFPMechanicalTests As New ViewTFPMechanicalTests
        NewViewTFPMechanicalTests.Show()
    End Sub

    Private Sub llViewCustomerHoldsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerHoldsAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintARCustomerHolds As New PrintARCustomerHolds
        Dim Result = NewPrintARCustomerHolds.ShowDialog()
    End Sub

    Private Sub llTimeSlipPostingPM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llTimeSlipPostingPM.Click
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is TimeSlipPostingNew Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim newTimeSlipPosting As New TimeSlipPosting()
            newTimeSlipPosting.Show()
        End If
    End Sub

    Private Sub llSteelBalanceDiscreptancyReportRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelBalanceDiscreptancyReportRM.LinkClicked
        Dim newSteelBalanceDiscreptancyReport As New SteelBalanceDiscreptancyReport
        newSteelBalanceDiscreptancyReport.Show()
    End Sub

    Private Sub llCertDataEditQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCertDataEditQC.LinkClicked
        Dim NewEditCertData As New CertificationSpec
        NewEditCertData.Show()
    End Sub

    Private Sub llViewInventoryTransactionsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInventoryTransactionsCT.LinkClicked
        Dim NewViewInventoryTransactions As New ViewInventoryTransactions
        NewViewInventoryTransactions.Show()
    End Sub

    Private Sub llManualInventoryTransactionCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llManualInventoryTransactionCT.LinkClicked
        Dim NewEnterManualTransaction As New InventoryTransactionMaintenance
        NewEnterManualTransaction.Show()
    End Sub

    Private Sub llInventoryAdjustmentsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInventoryAdjustmentsCT.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is InventoryAdjustmentForm Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewInventoryAdjustments05 As New InventoryAdjustmentForm
            NewInventoryAdjustments05.Show()
        End If
    End Sub

    Private Sub llPrintLabelsDocsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintLabelsDocsFX.LinkClicked
        Dim NewElectronicSchedulingBoard As New ElectronicSchedulingBoard
        NewElectronicSchedulingBoard.Show()
    End Sub

    Private Sub llViewBlueprintsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewBlueprintsFX.LinkClicked
        Dim NewViewBlueprints As New ViewBlueprintPopup
        NewViewBlueprints.Show()
    End Sub

    Private Sub llCreateRecurringVoucherAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateRecurringVoucherAP.LinkClicked
        Dim NewAPCreateRecurringVoucher As New APCreateRecurringVouchers
        NewAPCreateRecurringVoucher.Show()
    End Sub

    Private Sub llViewMillCertRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewMillCertRM.LinkClicked
        Dim newViewMillCert As New ViewMillCertPopup
        newViewMillCert.Show()
    End Sub

    Private Sub llViewMillCertificationsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewMillCertificationsSH.LinkClicked
        Dim newViewMillCert As New ViewMillCertPopup
        newViewMillCert.Show()
    End Sub

    Private Sub llViewBOLQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQCViewBOLQC.LinkClicked
        Dim newViewBOL As New ViewMillCertPopup
        newViewBOL.Show()
    End Sub

    Private Sub llShippingViewBOLSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShippingViewBOLSH.LinkClicked
        Dim newViewBOL As New ViewMillCertPopup
        newViewBOL.Show()
    End Sub

    Private Sub llGLLinePostingsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLLinePostingsCT.LinkClicked
        Dim NewViewGLLinePostings As New ViewGLLinePostings
        NewViewGLLinePostings.Show()
    End Sub

    Private Sub llAnnealLotTestResultEntryQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAnnealLotTestResultEntryQC.LinkClicked
        Dim newAnnealLotResultEntry As New AnnealLotTestResultsEntry
        newAnnealLotResultEntry.Show()
    End Sub

    Private Sub llViewSteelCostTiersRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelCostTiersRM.LinkClicked
        Dim newSteelCosting As New SteelCosting
        newSteelCosting.Show()
    End Sub

    Private Sub llViewFOXWIPPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFOXWIPPM.LinkClicked
        Dim newViewWIP As New ViewWIP
        newViewWIP.Show()
    End Sub

    Private Sub llSplitCoilRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSplitCoilRM.LinkClicked
        Dim newSplitCoil As New SplitCoilForm
        newSplitCoil.Show()
    End Sub

    Private Sub llDrawSteelRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDrawSteelRM.LinkClicked
        Dim newDrawSteel As New DrawSteelForm
        newDrawSteel.Show()
    End Sub

    Private Sub llViewInventoryValueByFilterIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInventoryValueByFilterIV.LinkClicked
        Dim NewViewInventoryValueByFilter As New ViewInventoryValueByFilter
        NewViewInventoryValueByFilter.Show()
    End Sub

    Private Sub llViewConsignmentShippingSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewConsignmentShippingSH.LinkClicked
        Dim NewViewConsignmentShipping5 As New ViewConsignmentShipping
        NewViewConsignmentShipping5.Show()
    End Sub

    Private Sub llViewOpenSteelPOsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewOpenSteelPOsRM.LinkClicked
        Dim NewViewOpenSteelPO As New ViewOpenSteelPO
        NewViewOpenSteelPO.Show()
    End Sub

    Private Sub llTFPStockStatusIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTFPStockStatusIV.LinkClicked
        Dim newTFPInventory As New ViewTFPInventory
        newTFPInventory.Show()
    End Sub

    Private Sub llViewConsignmentInventoryIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewConsignmentInventoryIV.LinkClicked
        Dim newViewConsignmentInventory As New ViewConsignmentInventory
        newViewConsignmentInventory.Show()
    End Sub

    Private Sub llViewSteelTransactionsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelTransactionsRM.LinkClicked
        Dim newViewSteelTrans As New ViewSteelTransactions
        newViewSteelTrans.Show()
    End Sub

    Private Sub llInvoicingMenuSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInvoicingMenuSO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ARProcessBatch Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewARProcessBatch As New ARProcessBatch
            NewARProcessBatch.Show()
        End If
    End Sub

    Private Sub llNegativeInventoryRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llNegativeInventoryRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintNegativeInventory As New PrintNegativeInventory
            Dim Result = NewPrintNegativeInventory.ShowDialog
        End Using
    End Sub

    Private Sub llViewShipmentLotNumbersSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentLotNumbersSH.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewShipmentLotNumbers As New ViewShipmentLotNumbers
        NewViewShipmentLotNumbers.Show()
    End Sub

    Private Sub llViewSaltSprayInspectionQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSaltSprayInspectionQC.LinkClicked
        Dim newViewSaltSprayInspection As New ViewUploadedSaltSprayInspections()
        newViewSaltSprayInspection.Show()
    End Sub

    Private Sub llMechanicalTestingQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMechanicalTestingQC.LinkClicked
        Dim newMechanical As New TrufitCertificationMechanicalTest
        newMechanical.Show()
    End Sub

    Private Sub llViewTFPCertQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewTFPCertQC.LinkClicked
        Dim newViewTFPCert As New ViewTrufitCertifications
        newViewTFPCert.Show()
    End Sub

    Private Sub llViewTrufitCertTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewTrufitCertTFP.LinkClicked
        Dim newViewTFPCert As New ViewTrufitCertifications
        newViewTFPCert.Show()
    End Sub

    Private Sub llStockStatusTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llStockStatusTFP.LinkClicked
        Dim NewViewTFPInventory As New ViewTFPInventory
        NewViewTFPInventory.Show()
    End Sub

    Private Sub llViewRackingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewRackingTFP.LinkClicked
        Dim NewInventoryRacking As New InventoryRacking
        NewInventoryRacking.Show()
    End Sub

    Private Sub llViewRetutnListingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReturnListingTFP.LinkClicked
        Dim NewViewCustomerReturnListing As New ViewCustomerReturnListing
        NewViewCustomerReturnListing.Show()
    End Sub

    Private Sub llViewOpenOrdersTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewOpenOrdersTFP.LinkClicked
        Dim NewViewOpenSOLines As New ViewOpenSOLines
        NewViewOpenSOLines.Show()
    End Sub

    Private Sub llViewCustomerListingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerListingTFP.LinkClicked
        Dim NewViewCustomerListing As New ViewCustomerListing
        NewViewCustomerListing.Show()
    End Sub

    Private Sub llViewFOXListingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFOXListingTFP.LinkClicked
        Dim NewViewFOXListing As New ViewFOXListing
        NewViewFOXListing.Show()
    End Sub

    Private Sub llViewInvoiceListingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInvoiceListingTFP.LinkClicked
        Dim NewViewInvoiceListing As New ViewInvoiceListing
        NewViewInvoiceListing.Show()
    End Sub

    Private Sub llToolInventory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llToolInventory.LinkClicked
        Dim newToolInventory As New ToolRoomInventory
        newToolInventory.Show()
    End Sub

    Private Sub llViewSDSSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSDSSH.LinkClicked
        Dim newViewSDS As New ViewUploadedSafetySheets
        newViewSDS.Show()
    End Sub

    Private Sub llViewMillCertsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewMillCertsFX.LinkClicked
        Dim NewViewPrintMillCert As New ViewMillCertPopup
        NewViewPrintMillCert.Show()
    End Sub

    Private Sub llViewCompanyTotalsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCompanyTotalsSO.LinkClicked
        Dim NewAllCompanyTotals As New AllCompanyTotals
        NewAllCompanyTotals.Show()
    End Sub

    Private Sub llQuotationMachineCostingTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQuotationMachineCostingTFP.LinkClicked
        Dim NewTFPQuotationMachineCosting As New TFPQuotationMachineCosting
        NewTFPQuotationMachineCosting.Show()
    End Sub

    Private Sub llPartialPalletRackingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPartialPalletRackingIV.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is InventoryPartialPalletRacking Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim newPartialPalletRacking As New InventoryPartialPalletRacking
            newPartialPalletRacking.Show()
        End If
    End Sub

    Private Sub llShippingPartialPalletRackingSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShippingPartialPalletRackingSH.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is InventoryPartialPalletRacking Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim newPartialPalletRacking As New InventoryPartialPalletRacking
            newPartialPalletRacking.Show()
        End If
    End Sub

    Private Sub llViewAuditTrailCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAuditTrailCT.LinkClicked
        Dim NewViewAuditTrail As New ViewAuditTrail
        NewViewAuditTrail.Show()
    End Sub

    Private Sub llViewCertErrorLogQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCertErrorLogQC.LinkClicked
        Dim NewViewCertErrorLog As New ViewCertErrorLog
        NewViewCertErrorLog.Show()
    End Sub

    Private Sub llViewCustomerOrdersByFOXTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerOrdersByFOXTFP.LinkClicked
        Dim NewViewCustomerOrders As New ViewCustomerOrders
        NewViewCustomerOrders.Show()
    End Sub

    Private Sub llViewRackingReportIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewRackingReportIV.LinkClicked
        If EmployeeCompanyCode = "SLC" Then
            Dim NewPrintInventoryDiscrepancyReportSLC As New PrintInventoryDiscrepancyReportSLC
            NewPrintInventoryDiscrepancyReportSLC.Show()
        Else
            Dim NewPrintInventoryDiscrepancyReport As New PrintInventoryDiscrepancyReport
            NewPrintInventoryDiscrepancyReport.Show()
        End If
    End Sub

    Private Sub llCertErrorLogSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCertErrorLogSH.LinkClicked
        Dim NewViewCertErrorLog As New ViewCertErrorLog
        NewViewCertErrorLog.Show()
    End Sub

    Private Sub llViewTFCertsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewTFCertsAR.LinkClicked
        Dim newViewTrufitCertifications As New ViewTrufitCertifications
        newViewTrufitCertifications.Show()
    End Sub

    Private Sub llBankTransactionsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llBankTransactionsAR.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is BankTransactionEntry Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewBankTransactionEntry As New BankTransactionEntry
            NewBankTransactionEntry.Show()
        End If
    End Sub

    Private Sub llViewWeeklySteelUsageRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewWeeklySteelUsageRM.LinkClicked
        Dim newViewSteelByWeek As New ViewSteelUsageByWeek
        newViewSteelByWeek.Show()
    End Sub

    Private Sub llTFPRackDiscrepancyTFP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTFPRackDiscrepancyTFP.LinkClicked
        Using NewPrintTFPRackingReport As New PrintTFPDiscrepancyReport
            Dim Result = NewPrintTFPRackingReport.ShowDialog()
        End Using
    End Sub

    Private Sub llAPViewNotificationCalendarAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAPViewNotificationCalendarAP.LinkClicked
        Dim newNotificationCalendar As New NotificationCalendar()
        newNotificationCalendar.Show()
    End Sub

    Private Sub llARViewNotificationCalendarAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llARViewNotificationCalendarAR.LinkClicked
        Dim newNotificationCalendar As New NotificationCalendar()
        newNotificationCalendar.Show()
    End Sub

    Private Sub llSOViewNotificationCalendarSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSOViewNotificationCalendarSO.LinkClicked
        Dim newNotificationCalendar As New NotificationCalendar()
        newNotificationCalendar.Show()
    End Sub

    Private Sub llInventoryTubsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llInventoryTubsCT.LinkClicked
        Dim newInventoryTubs As New InventoryTubs()
        newInventoryTubs.Show()
    End Sub

    Private Sub llPrintCoilLabelRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintCoilLabelRM.LinkClicked
        Dim newPrintCoilLabel As New PrintCoilLabel
        newPrintCoilLabel.Show()
    End Sub

    Private Sub llSalesByItemClassRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSalesByItemClassRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintSalesByItemClassTWD As New PrintSalesByItemClass
            Dim result = NewPrintSalesByItemClassTWD.ShowDialog()
        End Using
    End Sub

    Private Sub llHeaderSetupSheetPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llHeaderSetupSheetPM.LinkClicked
        Dim newHeaderSetupSheet As New HeaderSetupSheet()
        newHeaderSetupSheet.Show()
    End Sub

    Private Sub llViewHeaderSetupSheetsPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewHeaderSetupSheetsPM.LinkClicked
        Dim newViewHeaderSetupSheets As New ViewHeaderSetupSheets()
        newViewHeaderSetupSheets.Show()
    End Sub

    Private Sub llViewSteelVendorReturnLinesRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelVendorReturnLinesRM.LinkClicked
        Dim newViewSteelVendorReturns As New ViewSteelVendorReturns()
        newViewSteelVendorReturns.Show()
    End Sub

    Private Sub llProductionInventoryTubsPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProductionInventoryTubsPM.LinkClicked
        Dim newInventoryTubs As New InventoryTubs
        newInventoryTubs.Show()
    End Sub

    Private Sub llWIPCoilInventoryPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llWIPCoilInventoryPM.LinkClicked
        Dim newCoilWIPInventory As New CoilWIPInventory
        newCoilWIPInventory.Show()
    End Sub

    Private Sub llCashSheetCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCashSheetCT.LinkClicked
        Dim NewCashSheet As New CashSheet
        NewCashSheet.Show()
    End Sub

    Private Sub llQCOnHoldRackingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQCOnHoldRackingFX.LinkClicked
        Dim NewQCHoldRacking As New QCNonConformanceRacking
        NewQCHoldRacking.Show()
    End Sub

    Private Sub llQCOnHoldListingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQCOnHoldListingFX.LinkClicked
        Dim NewQCHoldListing As New ViewQCNonConformance
        NewQCHoldListing.Show()
    End Sub

    Private Sub llQCPlaceOnHoldFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llQCPlaceOnHoldFX.LinkClicked
        Dim NewQCHoldAdjustment As New QCNonConformance
        NewQCHoldAdjustment.Show()
    End Sub

    Private Sub llViewInspectionReportsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInspectionReportsQC.LinkClicked
        Dim newInspectionEntries As New ViewUploadedInspectionReport
        newInspectionEntries.Show()
    End Sub

    Private Sub llViewFOXStepCostingPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFOXStepCostingPM.LinkClicked
        Dim newViewFOXStepCosting As New ViewFOXStepCosting
        newViewFOXStepCosting.Show()
    End Sub

    Private Sub llManageShipmentsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llManageShipmentsSO.LinkClicked
        Dim NewManageShipments As New ManageShipments
        NewManageShipments.Show()
    End Sub

    Private Sub llViewConsignmentShippingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewConsignmentShippingSO.LinkClicked
        Dim NewViewConsignmentShipping As New ViewConsignmentShipping
        NewViewConsignmentShipping.Show()
    End Sub

    Private Sub llViewConsignmentBillingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewConsignmentBillingSO.LinkClicked
        Dim NewViewConsignmentBilling As New ViewConsignmentBilling
        NewViewConsignmentBilling.Show()
    End Sub

    Private Sub llViewConsignmentAdjustmentsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewConsignmentAdjustmentsSO.LinkClicked
        Dim NewViewConsignmentAdjustments As New ViewConsignmentAdjustments
        NewViewConsignmentAdjustments.Show()
    End Sub

    Private Sub llConsignmentStockStatusSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentStockStatusSO.LinkClicked
        Dim NewViewConsignmentInventory As New ViewConsignmentInventory
        NewViewConsignmentInventory.Show()
    End Sub

    Private Sub llMonthEndReportsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMonthEndReportsCT.LinkClicked
        Dim NewMonthEndReports As New MonthEndReports
        NewMonthEndReports.Show()
    End Sub

    Private Sub llViewSteelReceivingSummaryRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelReceivingSummaryRM.LinkClicked
        Dim NewViewSteelReceivingSummary As New ViewSteelReceivingMonthlySummary
        NewViewSteelReceivingSummary.Show()
    End Sub

    Private Sub llViewPartSalesDataSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPartSalesDataSO.LinkClicked
        Dim NewViewPartNumberSalesTotals As New ViewPartNumberSalesTotals
        NewViewPartNumberSalesTotals.Show()
    End Sub

    Private Sub llRecurringPaymentAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRecurringPaymentAR.LinkClicked
        Dim newARRecurringPayment As New ARRecurringPayment
        newARRecurringPayment.Show()
    End Sub

    Private Sub llViewRecurringPaymentsAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewRecurringPaymentsAR.LinkClicked
        Dim newViewARRecurringPayments As New ViewARRecurringPayment
        newViewARRecurringPayments.Show()
    End Sub

    Private Sub llCustomerSatisfactionSurveyQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerSatisfactionSurveyQC.LinkClicked
        Dim CustomerSurveyAndPath As String = "\\TFP-FS\TransferData\MOS PDF\CustomerSurvey.pdf"

        If File.Exists(CustomerSurveyAndPath) Then
            System.Diagnostics.Process.Start(CustomerSurveyAndPath)
        Else
            MsgBox("File can not be found", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub llViewRackActivityIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewRackActivityIV.LinkClicked
        Dim newViewRackingActivityLog As New ViewRackingActivityLog()
        newViewRackingActivityLog.Show()
    End Sub

    Private Sub llViewAssemblyLinesIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAssemblyLinesIV.LinkClicked
        Dim NewViewAssemblyLines As New ViewAssemblyLines
        NewViewAssemblyLines.Show()
    End Sub

    Private Sub llViewBuildLinesIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewBuildLinesIV.LinkClicked
        Dim NewViewAssemblyBuildLines As New ViewAssemblyBuildLines
        NewViewAssemblyBuildLines.Show()
    End Sub

    Private Sub llViewConsignmentReturnsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewConsignmentReturnsSO.LinkClicked
        Dim NewViewConsignmentReturns As New ViewConsignmentReturns
        NewViewConsignmentReturns.Show()
    End Sub

    Private Sub llViewPullTestLogQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPullTestLogQC.LinkClicked
        Dim newViewPullTestLog As New ViewTestLog()
        newViewPullTestLog.Show()
    End Sub

    Private Sub llBlueprintJournalQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llBlueprintJournalQC.LinkClicked
        Dim newBlueprintJournal As New BlueprintJournal()
        newBlueprintJournal.Show()
    End Sub

    Private Sub llSalesbyMonthRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSalesbyMonthRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewPrintSalesbyMonth As New PrintSalesbyMonth
            Dim result = NewPrintSalesbyMonth.ShowDialog()
        End Using
    End Sub

    Private Sub llLabelCreatorSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLabelCreatorSH.LinkClicked
        Dim newLabelCreator As New LabelCreator()
        newLabelCreator.Show()
    End Sub

    Private Sub llViewShipmentSerialNumbersSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShipmentSerialNumbersSH.LinkClicked
        Dim NewViewShipmentLineSerialNumbers As New ViewShipmentLineSerialNumbers
        NewViewShipmentLineSerialNumbers.Show()
    End Sub

    Private Sub llTorqueTestingQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTorqueTestingQC.LinkClicked
        Dim newTrufitTorqueTesting As New TrufitCertificationTorqueTest()
        newTrufitTorqueTesting.Show()
    End Sub

    Private Sub llDropShipSalesbyStateCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDropShipSalesbyStateCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewPrintDropShipSalesbyState As New PrintDropShipSalesbyState
            Dim result = NewPrintDropShipSalesbyState.ShowDialog()
        End Using
    End Sub

    Private Sub llConsignmentItemMaintenanceIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentItemMaintenanceIV.LinkClicked
        Dim NewItemMaintenanceConsignment As New ItemMaintenanceConsignment
        NewItemMaintenanceConsignment.Show()
    End Sub

    Private Sub llConsignmentTotalsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentTotalsSO.LinkClicked
        Dim NewViewConsignmentTotals As New ViewConsignmentTotals
        NewViewConsignmentTotals.Show()
    End Sub

    Private Sub llShipLinesSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShipLinesSH.LinkClicked
        Dim NewViewShipmentLines As New ViewShipmentLines
        NewViewShipmentLines.Show()
    End Sub

    Private Sub llFPISignOffQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFPISignOffQC.LinkClicked
        Dim NewFinalPieceInspectionSignOff As New FinalPieceInspectionSignoff
        NewFinalPieceInspectionSignOff.Show()
    End Sub

    Private Sub llViewVendorReturnLinesPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVendorReturnLinesPO.LinkClicked
        Dim NewViewVendorReturnLines As New ViewVendorReturnLines
        NewViewVendorReturnLines.Show()
    End Sub

    Private Sub llViewSteelCoilsReceivedRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelCoilsReceivedRM.LinkClicked
        Dim newViewSteelReceivingCoilLines As New ViewSteelReceivingCoilLines
        newViewSteelReceivingCoilLines.Show()
    End Sub

    Private Sub llPrintFinalPieceSignOffsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintFinalPieceSignOffsQC.LinkClicked
        Using NewPrintQCFinalPieceSignOff As New PrintQCFinalPieceSignOffs
            Dim result = NewPrintQCFinalPieceSignOff.ShowDialog()
        End Using
    End Sub

    Private Sub llViewSteelSpecialOrdersPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelSpecialOrdersPO.LinkClicked
        Dim newViewSteelSpecialOrders As New ViewSteelSpecialOrders()
        newViewSteelSpecialOrders.Show()
    End Sub

    Private Sub llTFPShipmentSignOffQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTFPShipmentSignOffQC.LinkClicked
        Using shipmentSignOff As New QCShipmentSignOff
            shipmentSignOff.ShowDialog()
        End Using
    End Sub

    Private Sub llMonthSnapshotGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMonthSnapshotGI.LinkClicked
        Dim NewMonthSnapshot As New MonthSnapshot
        NewMonthSnapshot.Show()
    End Sub

    Private Sub llCreateNAFTADocsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateNAFTADocsSH.LinkClicked
        Dim NewShipmentNaftaDocuments As New ShipmentNaftaForm
        NewShipmentNaftaDocuments.Show()
    End Sub

    Private Sub llProductionGraphingPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProductionGraphingPM.LinkClicked
        Dim NewProductionGraph As New ProductionGraphing
        NewProductionGraph.Show()
    End Sub

    Private Sub llWireYardEntryRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llWireYardEntryRM.LinkClicked
        Dim NewViewSteelWireYardEntry As New ViewSteelWireYardEntry
        NewViewSteelWireYardEntry.Show()
    End Sub

    Private Sub llViewEditTrufitCertsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewEditTrufitCertsSH.LinkClicked
        Dim NewViewEditTrufitCerts As New ViewEditTrufitCerts
        NewViewEditTrufitCerts.Show()
    End Sub

    Private Sub llCreateStudweldingCertIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateStudweldingCertIV.LinkClicked
        Dim NewCreateStudweldingCertificate As New CreateStudweldingCert
        NewCreateStudweldingCertificate.Show()
    End Sub

    Private Sub llManageShipmentsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llManageShipmentsSH.LinkClicked
        Dim NewManageShipments As New ManageShipments
        NewManageShipments.Show()
    End Sub

    Private Sub llSerialNumberQOHIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSerialNumberQOHIV.LinkClicked
        Dim NewSerialNumberInventory As New SerialNumberInventory
        NewSerialNumberInventory.Show()
    End Sub

    Private Sub llViewInspectionFirstPieceQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInspectionFirstPieceQC.LinkClicked
        Dim newViewFirstPiece As New ViewFirstPieceInspectionEntries()
        newViewFirstPiece.Show()
    End Sub

    Private Sub llViewCustomerNotesAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCustomerNotesAR.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode

        Dim newCustomerNotes As New CustomerNotes
        newCustomerNotes.Show()
    End Sub

    Private Sub llViewFiveYearSalesSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewFiveYearSalesSO.LinkClicked
        Dim NewInventorySalesData As New InventorySalesHistory
        NewInventorySalesData.Show()
    End Sub

    Private Sub llPrintBlankGaugeSignoutQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintBlankGaugeSignoutQC.LinkClicked
        Dim newPrintBlankGaugeSignout As New PrintBlankGaugeSignout
        newPrintBlankGaugeSignout.ShowDialog()
    End Sub

    Private Sub llViewGaugeSignoutsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewGaugeSignoutsQC.LinkClicked
        Dim newViewGaugeSignouts As New ViewGaugeSignouts()
        newViewGaugeSignouts.Show()
    End Sub

    Private Sub llPrintPriceSheetsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintPriceSheetsIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        If GlobalDivisionCode = "TWE" Then
            Dim NewPrintPriceSheetIncreaseTWE As New PrintPriceSheetIncreaseTWE
            NewPrintPriceSheetIncreaseTWE.Show()
        Else
            Dim NewPrintPriceSheetIncrease As New PrintPriceSheetIncrease
            NewPrintPriceSheetIncrease.Show()
        End If
    End Sub

    Private Sub llCanamSalesCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCanamSalesCT.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintCanamSales As New PrintCanamSales
        NewPrintCanamSales.Show()
    End Sub

    Private Sub llCanamSalesReportSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCanamSalesReportSO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintCanamSales As New PrintCanamSales
        NewPrintCanamSales.Show()
    End Sub

    Private Sub llTabletRackingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTabletRackingIV.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewLiftTruckRacking As New LiftTruckRacking
        NewLiftTruckRacking.Show()
    End Sub

    Private Sub llDatabaseMonitoringCT_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDatabaseMonitoringCT.LinkClicked
        Dim NewDatabaseMonitoring As New DatabaseMonitoring
        NewDatabaseMonitoring.Show()
    End Sub

    Private Sub llDatabaseMonitoringAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDatabaseMonitoringAR.LinkClicked
        Dim NewDatabaseMonitoring As New DatabaseMonitoring
        NewDatabaseMonitoring.Show()
    End Sub

    Private Sub llRackingTabletSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRackingTabletSH.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewLiftTruckRacking As New LiftTruckRacking
        NewLiftTruckRacking.Show()
    End Sub

    Private Sub llViewPickRackingSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPickRackingSH.LinkClicked
        Dim NewShippingUpdater As New ShippingUpdater
        NewShippingUpdater.Show()
    End Sub

    Private Sub llViewAllTimeSlipsPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewAllTimeSlipsPM.LinkClicked
        Dim NewViewTimeSlips As New ViewTimeSlips
        NewViewTimeSlips.Show()
    End Sub

    Private Sub llViewEFTRemittanceAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewEFTRemittanceAP.LinkClicked
        Dim NewViewEFTRemmittance As New ViewEFTRemittance
        NewViewEFTRemmittance.Show()
    End Sub

    Private Sub llViewTimeSlipRosterPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewTimeSlipRosterPM.LinkClicked
        Dim NewViewTimeSlipRoster As New ViewTimeSlipRoster
        NewViewTimeSlipRoster.Show()
    End Sub

    Private Sub llViewPickTicketListingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPickTicketListingAR.LinkClicked
        Dim NewViewPickListListing As New ViewPickTickets
        NewViewPickListListing.Show()
    End Sub

    Private Sub cmdViewShipmentListingAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles cmdViewShipmentListingAR.LinkClicked
        Dim NewViewShipmentListing As New ViewShipmentStatus
        NewViewShipmentListing.Show()
    End Sub

    Private Sub llFerruleProductionSchedulingPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFerruleProductionSchedulingPM.LinkClicked
        Dim NewFerruleProductionScheduling As New FerruleProductionScheduling
        NewFerruleProductionScheduling.Show()
    End Sub

    Private Sub llViewPulledLinesOnPickListSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPulledLinesOnPickListSH.LinkClicked
        Dim NewViewPickPulledLines As New ViewPickPulledLines
        NewViewPickPulledLines.Show()
    End Sub

    Private Sub llProductionTotalsPM_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llProductionTotalsPM.LinkClicked
        Dim NewProductionTotals As New ProductionTotals
        NewProductionTotals.Show()
    End Sub

    Private Sub llCustomerAnnouncementCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerAnnouncementCT.LinkClicked
        Dim NewCustomerAnnouncements As New CustomerAnnouncements
        NewCustomerAnnouncements.Show()
    End Sub

    Private Sub llDatabaseUtilitiesCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDatabaseUtilitiesCT.LinkClicked
        Dim NewDatabaseUtilities As New DatabaseUtilities
        NewDatabaseUtilities.Show()
    End Sub

    Private Sub llComputerUtilitiesCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llComputerUtilitiesCT.LinkClicked
        Dim NewComputerUtilities As New ComputerUtilities
        NewComputerUtilities.Show()
    End Sub

    Private Sub llCanadianBankingUploadCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCanadianBankingUploadCT.LinkClicked
        Dim NewCanadianBankUpload As New CanadianBankUpload
        NewCanadianBankUpload.Show()
    End Sub

    Private Sub llEnterSaltSprayLogQC_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterSaltSprayLogQC.LinkClicked
        Dim NewSaltSprayLogForm As New SaltSprayLogForm
        NewSaltSprayLogForm.Show()
    End Sub

    Private Sub llViewOnTimeReceivingFX_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewOnTimeReceivingFX.LinkClicked
        Dim NewViewReceivingOnTime As New ViewReceivingOnTime
        NewViewReceivingOnTime.Show()
    End Sub

    Private Sub llShipmentDockChecksFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShipmentDockChecksFX.LinkClicked
        Dim NewQCShipmentDockChecks As New QCShipmentDockChecks
        NewQCShipmentDockChecks.Show()
    End Sub

    Private Sub llIntercompanyEliminationsCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llIntercompanyEliminationsCT.LinkClicked
        Dim NewIntercompanyEliminations As New IntercompanyEliminations
        NewIntercompanyEliminations.Show()
    End Sub

    Private Sub llEnterGLTransactionCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterGLTransactionCT.LinkClicked
        Dim NewGLTransactionEntry As New GLTransactionEntry
        NewGLTransactionEntry.Show()
    End Sub

    Private Sub llViewBlueprintsPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewBlueprintsPM.LinkClicked
        Dim NewViewBlueprints As New ViewBlueprintPopup
        NewViewBlueprints.ShowDialog()
    End Sub

    Private Sub llOrderTrackingSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOrderTrackingSO.LinkClicked
        Dim NewOrderTracking As New OrderTracking
        NewOrderTracking.ShowDialog()
    End Sub

    Private Sub llEnterSteelTransactionCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEnterSteelTransactionCT.LinkClicked
        Dim NewSteelTransactionEntry As New SteelTransactionEntry
        NewSteelTransactionEntry.Show()
    End Sub

    Private Sub llConsignmentAdjustmentIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentAdjustmentIV.LinkClicked
        Dim NewInventoryAdjustmentConsignment As New InventoryAdjustmentConsignment
        NewInventoryAdjustmentConsignment.Show()
    End Sub

    Private Sub llShipmentDocsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShipmentDocsSH.LinkClicked
        Dim NewPrintLabelPortal As New ElectronicSchedulingBoard
        NewPrintLabelPortal.Show()
    End Sub

    Private Sub llViewSteelBOLsSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelBOLsSH.LinkClicked
        Dim NewViewUploadedSteelBOL As New ViewUploadedSteelBOL
        NewViewUploadedSteelBOL.Show()
    End Sub

    Private Sub llViewSteelBOLsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelBOLsRM.LinkClicked
        Dim NewViewUploadedSteelBOL As New ViewUploadedSteelBOL
        NewViewUploadedSteelBOL.Show()
    End Sub

    Private Sub llViewSteelReceivingInspectionsRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelReceivingInspectionsRM.LinkClicked
        Dim NewViewUploadedSteelInspections As New ViewUploadedSteelInspections
        NewViewUploadedSteelInspections.Show()
    End Sub

    Private Sub llViewOutsideCertsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewOutsideCertsFX.LinkClicked
        Dim NewViewUploadedOutsideCerts As New ViewUploadedOutsideCerts
        NewViewUploadedOutsideCerts.Show()
    End Sub

    Private Sub llViewSaltSprayFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSaltSprayFX.LinkClicked
        Dim NewViewUploadedSaltSprayInspections As New ViewUploadedSaltSprayInspections
        NewViewUploadedSaltSprayInspections.Show()
    End Sub

    Private Sub llViewInspectionReportsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewInspectionReportsFX.LinkClicked
        Dim NewViewUploadedInspectionReport As New ViewUploadedInspectionReport
        NewViewUploadedInspectionReport.Show()
    End Sub

    Private Sub llViewSteelReceivingInspectionFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelReceivingInspectionFX.LinkClicked
        Dim NewViewUploadedSteelInspections As New ViewUploadedSteelInspections
        NewViewUploadedSteelInspections.Show()
    End Sub

    Private Sub llSteelBOLsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteelBOLsFX.LinkClicked
        Dim NewViewUploadedSteelBOL As New ViewUploadedSteelBOL
        NewViewUploadedSteelBOL.Show()
    End Sub

    Private Sub llViewBlueprintsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewBlueprintsQC.LinkClicked
        Dim NewViewBlueprints As New ViewBlueprintPopup
        NewViewBlueprints.ShowDialog()
    End Sub

    Private Sub llViewSafetyDataSheetsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSafetyDataSheetsFX.LinkClicked
        Dim NewViewUploadedSafetySheets As New ViewUploadedSafetySheets
        NewViewUploadedSafetySheets.ShowDialog()
    End Sub

    Private Sub llBinPreferencesIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llBinPreferencesIV.LinkClicked
        Dim NewViewBinPreferences As New ViewBinPreferences
        NewViewBinPreferences.Show()
    End Sub

    Private Sub llResendFedexEmailCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llResendFedexEmailCT.LinkClicked
        FEDEXEmailAutoSend()
    End Sub

    Private Sub llSLCRackingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSLCRackingIV.LinkClicked
        Dim NewRackForm As New InventoryRackingWithPreferences
        NewRackForm.Show()
    End Sub

    Private Sub llSLCRackingSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSLCRackingSH.LinkClicked
        Dim NewRackForm As New InventoryRackingWithPreferences
        NewRackForm.Show()
    End Sub

    Private Sub llMOSEmailProgramSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMOSEmailProgramSO.LinkClicked
        TFPMailTransactionType = "OPEN NEW"
        Dim NewEmailPage As New EmailPage
        NewEmailPage.Show()
    End Sub

    Private Sub llUploadInspectionReportsFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llUploadInspectionReportsFX.LinkClicked
        Dim NewViewInspectionReportUploadFiles As New ViewInspectionReportUploadFiles
        NewViewInspectionReportUploadFiles.Show()
    End Sub

    Private Sub llCustomerAnnouncementsSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerAnnouncementsSO.LinkClicked
        Dim NewCustomerAnnouncements As New CustomerAnnouncements
        NewCustomerAnnouncements.Show()
    End Sub

    Private Sub llOpenRemoteEmailGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOpenRemoteEmailGI.LinkClicked
        TFPMailTransactionType = "OPEN NEW"

        Dim NewEmailPage As New EmailPage
        NewEmailPage.Show()
    End Sub

    Private Sub llCreateSpecialLotNumberFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateSpecialLotNumberFX.LinkClicked
        Dim NewLotNumberCreateSpecial As New LotNumberCreateSpecial
        NewLotNumberCreateSpecial.Show()
    End Sub

    Private Sub llViewLotNumbersGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLotNumbersGI.LinkClicked
        Dim NewViewLotNumbers As New ViewLotNumbers
        NewViewLotNumbers.Show()
    End Sub

    Private Sub llViewHeatNumbersGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewHeatNumbersGI.LinkClicked
        Dim NewViewHeatNumberLog As New ViewHeatNumberLog
        NewViewHeatNumberLog.Show()
    End Sub

    Private Sub llViewItemListingPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewItemListingPO.LinkClicked
        Dim NewViewItemListing As New ViewItemListing
        NewViewItemListing.Show()
    End Sub

    Private Sub llViewCreditApplicationAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewCreditApplicationAR.LinkClicked
        Dim AmericanFileNameAndPath As String = "\\TFP-FS\TransferData\MOS PDF\Credit App US 2022.pdf"
        Dim CanadianFileNameAndPath As String = "\\TFP-FS\TransferData\MOS PDF\Credit App CAN 2022.pdf"

        cmd = New SqlCommand("SELECT DivisionClass FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        Dim divisionClass As String
        Try
            divisionClass = CStr(cmd.ExecuteScalar)
        Catch ex As Exception
            divisionClass = ""
        End Try
        con.Close()

        Select Case divisionClass
            Case "AMERICAN"
                If File.Exists(AmericanFileNameAndPath) Then
                    System.Diagnostics.Process.Start(AmericanFileNameAndPath)
                Else
                    MsgBox("File can not be found", MsgBoxStyle.OkOnly)
                End If
            Case "CANADIAN"
                If File.Exists(CanadianFileNameAndPath) Then
                    System.Diagnostics.Process.Start(CanadianFileNameAndPath)
                Else
                    MsgBox("File can not be found", MsgBoxStyle.OkOnly)
                End If
            Case Else
                If File.Exists(AmericanFileNameAndPath) Then
                    System.Diagnostics.Process.Start(AmericanFileNameAndPath)
                Else
                    MsgBox("File can not be found", MsgBoxStyle.OkOnly)
                End If
        End Select
    End Sub

    Private Sub llBlueprintActivityLogQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llBlueprintActivityLogQC.LinkClicked
        Dim NewBlueprintActivityLog As New ViewBlueprintJournalActivity
        NewBlueprintActivityLog.Show()
    End Sub

    Private Sub llDailyRegisterGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llDailyRegisterGI.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewPrintDailyRegister As New PrintDailyRegister
            Dim result = NewPrintDailyRegister.ShowDialog()
        End Using
    End Sub

    Private Sub llRackingUtilitySH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRackingUtilitySH.LinkClicked
        Dim NewRackingUtilitySH As New RackingUtility
        NewRackingUtilitySH.Show()
    End Sub

    Private Sub llCreateVendorBOLPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateVendorBOLPO.LinkClicked
        Dim NewCreateVendorBOL As New CreateVendorBOL
        NewCreateVendorBOL.Show()
    End Sub

    Private Sub llEquipmentProductionSchedulingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEquipmentProductionSchedulingFX.LinkClicked
        Dim NewEquipmentProductionScheduling As New EquipmentProductionScheduling
        NewEquipmentProductionScheduling.Show()
    End Sub

    Private Sub llEquipmentProductionIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEquipmentProductionIV.LinkClicked
        Dim NewEquipmentProductionScheduling As New EquipmentProductionScheduling
        NewEquipmentProductionScheduling.Show()
    End Sub

    Private Sub llFerruleToolingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFerruleToolingIV.LinkClicked
        Dim NewViewFerruleToolingBlueprints As New ViewFerruleToolingBlueprints
        NewViewFerruleToolingBlueprints.Show()
    End Sub

    Private Sub llMaintainPriceLevelsIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintainPriceLevelsIV.LinkClicked
        Dim NewInventoryPriceLevels As New InventoryPriceLevels
        NewInventoryPriceLevels.Show()
    End Sub

    Private Sub llCheckBackOrdersSH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCheckBackOrdersSH.LinkClicked
        Dim NewCheckBackOrders As New CheckBackOrders
        NewCheckBackOrders.Show()
    End Sub

    Private Sub llViewStockStatusIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewStockStatusIV.LinkClicked
        Dim NewInventoryStatus As New InventoryStatus
        NewInventoryStatus.Show()
    End Sub

    Private Sub llViewRackActivitySH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewRackActivitySH.LinkClicked
        Dim NewViewRackingActivityLog As New ViewRackingActivityLog
        NewViewRackingActivityLog.Show()
    End Sub

    Private Sub llPrintDocsAndLabelsQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintDocsAndLabelsQC.LinkClicked
        Dim NewElectronicSchedulingBoard As New ElectronicSchedulingBoard
        NewElectronicSchedulingBoard.Show()
    End Sub

    Private Sub llPrintCustomerRMAQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintCustomerRMAQC.LinkClicked
        Dim NewPrintCustomerReturnAuthorization As New PrintCustomerReturnAuthorization
        NewPrintCustomerReturnAuthorization.Show()
    End Sub

    Private Sub llViewSalesByCustomerSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSalesByCustomerSO.LinkClicked
        Dim NewViewCustomerSalesHistory As New ViewCustomerSalesHistory
        NewViewCustomerSalesHistory.Show()
    End Sub

    Private Sub llLotNumberMaintenanceFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLotNumberMaintenanceFX.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is LotNumberMaintenance Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewLotNumberMaintenance As New LotNumberMaintenance
            NewLotNumberMaintenance.Show()
        End If
    End Sub

    Private Sub llViewRackingFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewRackingFX.LinkClicked
        Dim NewInventoryRacking As New InventoryRacking
        NewInventoryRacking.Show()
    End Sub

    Private Sub llReceiverEditModePO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llReceiverEditModePO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ReceiverEditMode Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewReceiverEditMode As New ReceiverEditMode
            NewReceiverEditMode.Show()
        End If
    End Sub

    Private Sub llItemMaintenancePO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llItemMaintenancePO.LinkClicked
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ItemMaintenance Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            Dim NewItemMaintenance As New ItemMaintenance
            NewItemMaintenance.Show()
        End If
    End Sub

    Private Sub llConsignmentReturnsGI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llConsignmentReturnsGI.LinkClicked
        Dim NewViewConsignmentReturns As New ViewConsignmentReturns
        NewViewConsignmentReturns.Show()
    End Sub

    Private Sub llViewSteelPOsPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelPOsPO.LinkClicked
        Dim NewViewSteelPurchaseLines As New ViewSteelPurchaseLines
        NewViewSteelPurchaseLines.Show()
    End Sub

    Private Sub llViewSteelCoilsPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelCoilsPM.LinkClicked
        Dim NewViewSteelCoils As New ViewSteelCoils
        NewViewSteelCoils.Show()
    End Sub

    Private Sub llLabelProgramPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLabelProgramPM.LinkClicked
        Dim NewElectronicSchedulingBoard As New ElectronicSchedulingBoard
        NewElectronicSchedulingBoard.Show()
    End Sub

    Private Sub llViewWIPValueCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewWIPValueCT.LinkClicked
        Dim NewViewWIPValue As New ViewWIPValue
        NewViewWIPValue.Show()
    End Sub

    Private Sub llViewVoucherLinesAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewVoucherLinesAP.LinkClicked
        Dim NewViewVoucherLines As New ViewVoucherLines
        NewViewVoucherLines.Show()
    End Sub

    Private Sub llViewPOHeadersAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPOHeadersAP.LinkClicked
        Dim NewViewPOHeaders As New ViewPOHeaders
        NewViewPOHeaders.Show()
    End Sub

    Private Sub llViewReceivingHeadersAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewReceivingHeadersAP.LinkClicked
        Dim NewViewReceivingHeaders As New ViewReceivingHeaders
        NewViewReceivingHeaders.Show()
    End Sub

    Private Sub llViewPOLinesAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewPOLinesAP.LinkClicked
        Dim NewViewPurchaseLines As New ViewPurchaseLines
        NewViewPurchaseLines.Show()
    End Sub

    Private Sub llTransferCoilRMIDRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTransferCoilRMIDRM.LinkClicked
        Dim NewSteelChangeCoilAndRMIDAdjustment As New SteelChangeCoilAndRMIDAdjustment
        NewSteelChangeCoilAndRMIDAdjustment.Show()
    End Sub

    Private Sub llIncomeStatement2YearRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llIncomeStatement2YearRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintIncomeStatement2Year As New PrintIncomeStatement2Year
            Dim Result = NewPrintIncomeStatement2Year.ShowDialog
        End Using
    End Sub

    Private Sub llGLShipmentLineDataRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLShipmentLineDataRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintGLShippingLinesFiltered As New PrintGLShippingLinesFiltered
            Dim Result = NewPrintGLShippingLinesFiltered.ShowDialog
        End Using
    End Sub

    Private Sub llGLReceiverLineDataRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llGLReceiverLineDataRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintGLReceivingLinesFiltered As New PrintGLReceivingLinesFiltered
            Dim Result = NewPrintGLReceivingLinesFiltered.ShowDialog
        End Using
    End Sub

    Private Sub llllRackContentsRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRackContentsRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintRackContents As New PrintRackContents
            Dim Result = NewPrintRackContents.ShowDialog
        End Using
    End Sub

    Private Sub llARCustomerStatementRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llARCustomerStatementRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintCustomerStatement As New PrintCustomerStatement
            Dim Result = NewPrintCustomerStatement.ShowDialog
        End Using
    End Sub

    Private Sub llReceivingJournalRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llReceivingJournalRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintReceivingHeaders As New PrintReceivingHeaders
            Dim Result = NewPrintReceivingHeaders.ShowDialog
        End Using
    End Sub

    Private Sub llPrintCustomerCARQC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintCustomerCARQC.LinkClicked
        Dim NewPrintRMA As New PrintCorrectivePreventiceActionReport
        NewPrintRMA.Show()
    End Sub

    Private Sub llViewIntercompanyShipmentsPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewIntercompanyShipmentsPO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewIntercompanyShipments As New ViewIntercompanyShipments
        NewViewIntercompanyShipments.Show()
    End Sub

    Private Sub llResetShipmentDateCT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llResetShipmentDateCT.LinkClicked
        Using NewShipmentInvoiceDateReset As New ShipmentInvoiceDateReset
            Dim Result = NewShipmentInvoiceDateReset.ShowDialog()
        End Using
    End Sub

    Private Sub llViewSteelReceiversAP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewSteelReceiversAP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewSteelReceipts As New ViewSteelReceipts
        NewViewSteelReceipts.Show()
    End Sub

    Private Sub llOkayToShipRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOkayToShipRP.LinkClicked
        Using NewPrintOkToShip As New PrintOkToShip
            Dim Result = NewPrintOkToShip.ShowDialog()
        End Using
    End Sub

    Private Sub llOkayToProcessRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOkayToProcessRP.LinkClicked
        Using NewPrintOkToProcess As New PrintOkToProcess
            Dim Result = NewPrintOkToProcess.ShowDialog()
        End Using
    End Sub

    Private Sub llPrintBlankGaugeSheetRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintBlankGaugeSheetRP.LinkClicked
        Using NewPrintBlankGaugeSignout As New PrintBlankGaugeSignout
            Dim Result = NewPrintBlankGaugeSignout.ShowDialog()
        End Using
    End Sub

    Private Sub llPrintInventoryTubsRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintInventoryTubsRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintInventoryTubWIPReport As New PrintInventoryTubWIPReport
            Dim Result = NewPrintInventoryTubWIPReport.ShowDialog()
        End Using
    End Sub

    Private Sub llPrintInventoryFIFOValue_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPrintInventoryFIFOValue.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintInventoryFIFOValue As New PrintInventoryFIFOValue
            Dim Result = NewPrintInventoryFIFOValue.ShowDialog()
        End Using
    End Sub

    Private Sub lloCustomersOnHoldRP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lloCustomersOnHoldRP.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Using NewPrintARCustomerHolds As New PrintARCustomerHolds
            Dim Result = NewPrintARCustomerHolds.ShowDialog()
        End Using
    End Sub

    Private Sub llFabSouthSalesReportSO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFabSouthSalesReportSO.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewPrintFabSouthSales As New PrintFabSouthSales
        NewPrintFabSouthSales.Show()
    End Sub

    Private Sub llViewLeadTimesFX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLeadTimesFX.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewLeadTimes As New ViewLeadTimes
        NewViewLeadTimes.Show()
    End Sub

    Private Sub llViewShotAnalsisReportRM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewShotAnalsisReportRM.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        Dim NewViewShotTest As New ViewShotTest
        NewViewShotTest.Show()
    End Sub

    Private Sub llCreateLotManuallyPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateLotManuallyPM.LinkClicked
        Dim NewLotNumberManualCreate As New LotNumberManualCreate
        NewLotNumberManualCreate.Show()
    End Sub

    Private Sub llCreateWorkOrderPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCreateWorkOrderPM.LinkClicked
        Dim NewWorkOrder As New WorkOrder
        NewWorkOrder.Show()
    End Sub

    Private Sub llMaintenanceRackingIV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llMaintenanceRackingIV.LinkClicked
        Dim NewViewMaintenanceRacking As New ViewMaintenanceRacking
        NewViewMaintenanceRacking.Show()
    End Sub

    Private Sub llViewWorkOrdersPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewWorkOrdersPM.LinkClicked
        Dim NewViewWorkOrders As New ViewWorkOrders
        NewViewWorkOrders.Show()
    End Sub

    Private Sub llEmailScheduler_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEmailScheduler.LinkClicked
        Dim NewViewInvoicesToEmail As New ViewInvoicesToEmail
        NewViewInvoicesToEmail.Show()
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class