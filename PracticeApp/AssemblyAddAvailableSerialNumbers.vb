Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class AssemblyAddAvailableSerialNumbers
    Inherits System.Windows.Forms.Form

    Dim FirstSerialNumber As String = ""
    Dim NextSerialNumber As String = ""

    Dim NumberOfLabels As Integer = 0
    Dim Counter As Integer = 0
    Dim BeginningNumberOfSerialDigits As Integer = 0
    Dim EndingNumberOfSerialDigits As Integer = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 300)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub AssemblyAddAvailableSerialNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPartNumber()
        LoadPartDescription()

        If EmployeeLoginName = "LEREW" Then
            cmdTestCode.Visible = True
            txtTestCode.Visible = True
        Else
            cmdTestCode.Visible = True
            txtTestCode.Visible = False
        End If

        ClearData()
        ClearVariables()
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPartNumber()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboDescription.Text = PartDescription1
    End Sub

    Public Sub ClearVariables()
        FirstSerialNumber = ""
        NumberOfLabels = 0
        Counter = 0
    End Sub

    Public Sub ClearData()
        cboDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        txtFirstSerialNumber.Clear()
        txtNumberOfLabels.Clear()
        cboPartNumber.Focus()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPartNumber()
    End Sub

    Private Sub cboDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescription.SelectedIndexChanged
        LoadPartNumberByDescription()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddSerialNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSerialNumbers.Click
        'CHECK TO SEE IF SERIAL NUMBER IS NUMERIC OR ALPHANUMERIC
        Dim SerialIntegerValue As Integer = 0
        Dim SerialNumberType As String = ""

        If Integer.TryParse(txtFirstSerialNumber.Text, SerialIntegerValue) Then
            SerialNumberType = "NUMERIC"
        Else
            SerialNumberType = "ALPHANUMERIC"
        End If

        If SerialNumberType = "NUMERIC" Then
            'Check number of digits
            Dim CheckNumberOfDigits As Integer = 0
            Dim CheckNumberOfSerialNumbers As Integer = 0

            CheckNumberOfDigits = txtFirstSerialNumber.Text.Length
            CheckNumberOfSerialNumbers = Val(txtNumberOfLabels.Text)

            'Check if left number is zero
            If txtFirstSerialNumber.Text.Substring(0, 1) = "0" Then
                NumberOfLabels = Val(txtNumberOfLabels.Text)
                FirstSerialNumber = txtFirstSerialNumber.Text
                Dim intFirstSerialNumber As Integer = 0
                intFirstSerialNumber = Val(txtFirstSerialNumber.Text)
                Dim NextSerialNumber As String = ""
                Dim intNextSerialNumber As Integer = 0

                'Initialize Variables to start
                intNextSerialNumber = intFirstSerialNumber + 1
                NextSerialNumber = "0" + CStr(intNextSerialNumber)

                Try
                    'Insert beginning serial number and run loop for the rest.
                    cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = txtFirstSerialNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                        .Add("@Comment", SqlDbType.VarChar).Value = ""
                        .Add("@BuildDate", SqlDbType.VarChar).Value = Today()
                        .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    MsgBox("Beginning serial # could not be added.", MsgBoxStyle.OkOnly)
                    'Error Log
                    Dim strSerialNumber As String
                    strSerialNumber = txtFirstSerialNumber.Text

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
                    ErrorReferenceNumber = "Serial # " + strSerialNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try
                '*****************************************************************************************************
                For i As Integer = 1 To (NumberOfLabels - 1)
                    Try
                        'Insert subsequential Serial Numbers
                        cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = NextSerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                            .Add("@Comment", SqlDbType.VarChar).Value = ""
                            .Add("@BuildDate", SqlDbType.VarChar).Value = Today()
                            .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex2 As Exception
                        MsgBox("Beginning serial # could not be added.", MsgBoxStyle.OkOnly)
                        'Error Log
                        Dim strSerialNumber As String
                        strSerialNumber = txtFirstSerialNumber.Text

                        ErrorDate = Today()
                        ErrorComment = ex2.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
                        ErrorReferenceNumber = "Serial # " + strSerialNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        Exit Sub
                    End Try

                    'Advance integer serial number
                    intNextSerialNumber = intNextSerialNumber + 1
                    NextSerialNumber = "0" + CStr(intNextSerialNumber)
                Next i

                'After Loop
                'Clear Fields
                ClearVariables()
                ClearData()

                MsgBox("Serial Numbers entered.", MsgBoxStyle.OkOnly)
            Else 'Serial number does not begin with zero
                NumberOfLabels = Val(txtNumberOfLabels.Text)
                FirstSerialNumber = txtFirstSerialNumber.Text
                Dim intFirstSerialNumber As Integer = 0
                intFirstSerialNumber = Val(txtFirstSerialNumber.Text)
                Dim NextSerialNumber As String = ""
                Dim intNextSerialNumber As Integer = 0

                'Initialize Variables to start
                intNextSerialNumber = intFirstSerialNumber + 1
                NextSerialNumber = CStr(intNextSerialNumber)

                Try
                    'Insert beginning serial number and run loop for the rest.
                    cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = txtFirstSerialNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                        .Add("@Comment", SqlDbType.VarChar).Value = ""
                        .Add("@BuildDate", SqlDbType.VarChar).Value = Today()
                        .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    MsgBox("Beginning serial # could not be added.", MsgBoxStyle.OkOnly)
                    'Error Log
                    Dim strSerialNumber As String
                    strSerialNumber = txtFirstSerialNumber.Text

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
                    ErrorReferenceNumber = "Serial # " + strSerialNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try

                'Initialize Counter before the loop
                Counter = 1
                '*****************************************************************************************************
                For i As Integer = 1 To (NumberOfLabels - 1)
                    Try
                        'Insert subsequential Serial Numbers
                        cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = NextSerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                            .Add("@Comment", SqlDbType.VarChar).Value = ""
                            .Add("@BuildDate", SqlDbType.VarChar).Value = Today()
                            .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex2 As Exception
                        MsgBox("Beginning serial # could not be added.", MsgBoxStyle.OkOnly)
                        'Error Log
                        Dim strSerialNumber As String
                        strSerialNumber = txtFirstSerialNumber.Text

                        ErrorDate = Today()
                        ErrorComment = ex2.ToString()
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
                        ErrorReferenceNumber = "Serial # " + strSerialNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        Exit Sub
                    End Try

                    'Advance integer serial number
                    intNextSerialNumber = intNextSerialNumber + 1
                    NextSerialNumber = CStr(intNextSerialNumber)
                Next i

                'After Loop
                'Clear Fields
                ClearVariables()
                ClearData()

                MsgBox("Serial Numbers entered.", MsgBoxStyle.OkOnly)
            End If
        Else 'Serial number is alphanumeric
            'Validate fieLds
            NumberOfLabels = Val(txtNumberOfLabels.Text)
            FirstSerialNumber = txtFirstSerialNumber.Text

            Dim NextSerialNumber As String = ""
            Dim OriginalAddZero As String = ""

            Dim NumberOfSerialDigits As Integer = 0
            NumberOfSerialDigits = txtFirstSerialNumber.Text.Length

            'Run Check to see when first non-number character is in string from the right of ther serial number

            Dim Counter As Integer = 1
            Dim CheckDigit As String = ""
            Dim MarkDigit As Integer = 0

            For i As Integer = 0 To NumberOfSerialDigits - 1
                'Check character position
                CheckDigit = FirstSerialNumber.Substring(NumberOfSerialDigits - Counter, 1)

                'Check if character is numeric
                If IsNumeric(CheckDigit) Then
                    'Continue to next
                Else
                    MarkDigit = Counter - 1
                    Exit For
                End If

                Counter = Counter + 1
            Next

            BeginningNumberOfSerialDigits = NumberOfSerialDigits

            Dim StartingSerialSequence As String = FirstSerialNumber.Substring(0, NumberOfSerialDigits - MarkDigit)

            Dim EndingSerialSequence As String = FirstSerialNumber.Substring(NumberOfSerialDigits - MarkDigit, MarkDigit)

            If EndingSerialSequence.Substring(0, 1) = "0" Then
                If EndingSerialSequence.Substring(0, 2) = "00" Then
                    If EndingSerialSequence.Substring(0, 3) = "000" Then
                        OriginalAddZero = "000"
                    Else
                        OriginalAddZero = "00"
                    End If
                Else
                    OriginalAddZero = "0"
                End If
            Else
                OriginalAddZero = ""
            End If

            Dim intEndingSerialSequence As Integer = CInt(EndingSerialSequence)
            Dim intEndOfSerialNumber As Integer = 0
            '********************************************************************************************************
            Try
                'Insert First Serial Number
                cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, Status, CustomerID, BuildNumber, BuildDate, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, ShipmentPrice, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, Status, @CustomerID, @BuildNumber, @BuildDate, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @ShipmentPrice, @InvoiceNumber, @InvoiceDate)", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = txtFirstSerialNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                    .Add("@Comment", SqlDbType.VarChar).Value = ""
                    .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                    .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                    .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                    .Add("@BuildDate", SqlDbType.VarChar).Value = ""
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                    .Add("@ShipmentDate", SqlDbType.VarChar).Value = ""
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ""
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = ""
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                MsgBox("Beginning serial # could not be added.", MsgBoxStyle.OkOnly)

                'Error Log
                Dim strSerialNumber As String
                strSerialNumber = txtFirstSerialNumber.Text

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "Add Serial Numbers --- Add First Serial Number Failure"
                ErrorReferenceNumber = "Serial # " + strSerialNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                Exit Sub
            End Try

            'Initialize Counter before the loop
            Counter = 1
            '*****************************************************************************************************
            For i As Integer = 1 To (NumberOfLabels - 1)
                Dim EndOfSerialNumber As String = ""
                Dim AddZero As String = ""

                intEndOfSerialNumber = intEndingSerialSequence + Counter
                EndOfSerialNumber = CStr(intEndOfSerialNumber)

                NextSerialNumber = StartingSerialSequence + OriginalAddZero + EndOfSerialNumber

                EndingNumberOfSerialDigits = NextSerialNumber.Length

                If BeginningNumberOfSerialDigits - EndingNumberOfSerialDigits = 1 Then
                    'MsgBox("There was a problem creating the next serial #. First one was entered correctly. Contact System Admin.", MsgBoxStyle.OkOnly)
                    'Exit Sub
                    AddZero = OriginalAddZero + "0"
                    NextSerialNumber = StartingSerialSequence + AddZero + EndOfSerialNumber
                Else
                    AddZero = OriginalAddZero
                    NextSerialNumber = StartingSerialSequence + AddZero + EndOfSerialNumber
                End If

                Try
                    'Insert subsequential Serial Numbers
                    cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = NextSerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                        .Add("@Comment", SqlDbType.VarChar).Value = ""
                        .Add("@BuildDate", SqlDbType.VarChar).Value = Today()
                        .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex2 As Exception
                    MsgBox("Beginning serial # could not be added.", MsgBoxStyle.OkOnly)
                    'Error Log
                    Dim strSerialNumber As String
                    strSerialNumber = txtFirstSerialNumber.Text

                    ErrorDate = Today()
                    ErrorComment = ex2.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
                    ErrorReferenceNumber = "Serial # " + strSerialNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try
                '********************************************************************************************
                'Clear variables for next entry
                intEndOfSerialNumber = 0
                EndOfSerialNumber = ""
                NextSerialNumber = ""
                Counter = Counter + 1
                AddZero = ""
            Next i

            'Clear Fields
            ClearVariables()
            ClearData()

            MsgBox("Serial Numbers entered.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdTestCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestCode.Click
        '================================================================================
        If cboPartNumber.Text = "" Then
            MsgBox("You must select a valid part number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtFirstSerialNumber.Text = "" Then
            MsgBox("You must enter the first serial number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtNumberOfLabels.Text = "" Then
            MsgBox("You must enter the number of serial numbers to add.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '================================================================================
        'Test creation of serial numbers
        Dim SerialNumberPrefix As String = ""
        Dim SerialNumberSuffix As String = ""
        Dim TempSerialNumberSuffix As String = ""
        Dim intTempSerialNumberSuffix As Integer = 0
        Dim intNextSuffix As Integer = 0
        Dim strNextSuffix As String = ""
        Dim NumberOfSerialNumbers As Integer = 0

        Dim PrefixLength As Integer = 0
        Dim SuffixLength As Integer = 0

        Dim TestSerialNumber As String = ""
        Dim TestNumberOfDigits As Integer = 0
        Dim CheckSingleDigit As String = ""
        Dim LoopCounter As Integer = 1
        Dim TestMarkNumericPosition As Integer = 0

        TestSerialNumber = txtFirstSerialNumber.Text
        TestNumberOfDigits = TestSerialNumber.Length
        NumberOfSerialNumbers = Val(txtNumberOfLabels.Text)

        'Insert First Serial Number
        Try
            InsertIntoSerialLog()
        Catch ex As Exception
            MsgBox("Beginning serial # could not be added.", MsgBoxStyle.OkOnly)
            'Error Log
            Dim strSerialNumber As String
            strSerialNumber = txtFirstSerialNumber.Text

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = EmployeeCompanyCode
            ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
            ErrorReferenceNumber = "Serial # " + strSerialNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            Exit Sub
        End Try

        'Start from right to find first non-numeric character
        For i As Integer = 1 To (TestNumberOfDigits - 1)
            CheckSingleDigit = TestSerialNumber.Substring(TestNumberOfDigits - LoopCounter, 1)

            If IsNumeric(CheckSingleDigit) Then
                'Continue
            Else
                TestMarkNumericPOsition = TestNumberOfDigits - LoopCounter
                Exit For
            End If

            LoopCounter = LoopCounter + 1
        Next

        'Number of characters from the right that are numeric - TestMarkNumericPosition

        'Create Variable to create serial number
        Dim TestFrontHalf As String = ""
        Dim TestBackHalf As String = ""

        TestFrontHalf = TestSerialNumber.Substring(0, TestMarkNumericPosition + 1)
        SerialNumberPrefix = TestFrontHalf
        PrefixLength = TestFrontHalf.Length

        '###########################################################################
        'Prefix of serial number is established - generate suffix
        '###########################################################################

        TempSerialNumberSuffix = TestSerialNumber.Substring(PrefixLength, TestNumberOfDigits - PrefixLength)
        SuffixLength = TempSerialNumberSuffix.Length

        'Check for leading zeros on suffix
        If TempSerialNumberSuffix.StartsWith("0") Then
            'Reset Counter
            Dim TempCounter As Integer = 1

            For i As Integer = 1 To NumberOfSerialNumbers - 1
                'Check to see how many leading zeros are needed
                Dim intSuffixLength As Integer = 0
                intNextSuffix = CInt(TempSerialNumberSuffix)
                intNextSuffix = intNextSuffix + TempCounter
                strNextSuffix = CStr(intNextSuffix)
                intSuffixLength = strNextSuffix.Length

                If SuffixLength - intSuffixLength = 1 Then
                    strNextSuffix = "0" + strNextSuffix
                ElseIf SuffixLength - intSuffixLength = 2 Then
                    strNextSuffix = "00" + strNextSuffix
                ElseIf SuffixLength - intSuffixLength = 3 Then
                    strNextSuffix = "000" + strNextSuffix
                ElseIf SuffixLength - intSuffixLength = 4 Then
                    strNextSuffix = "0000" + strNextSuffix
                ElseIf SuffixLength - intSuffixLength = 5 Then
                    strNextSuffix = "00000" + strNextSuffix
                Else
                    MsgBox("Pause1", MsgBoxStyle.OkOnly)
                End If

                NextSerialNumber = SerialNumberPrefix + strNextSuffix

                TempCounter = TempCounter + 1

                Try
                    InsertNextSerialNumber()
                Catch ex As Exception
                    'Error Log
                    Dim strSerialNumber As String
                    strSerialNumber = txtFirstSerialNumber.Text

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
                    ErrorReferenceNumber = "Serial # " + strSerialNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try
            Next
        Else
            Dim TempCounter As Integer = 1

            For i As Integer = 1 To NumberOfSerialNumbers - 1

                intTempSerialNumberSuffix = CInt(TempSerialNumberSuffix)

                intNextSuffix = intTempSerialNumberSuffix + TempCounter
                strNextSuffix = CStr(intNextSuffix)

                NextSerialNumber = SerialNumberPrefix + strNextSuffix

                TempCounter = TempCounter + 1

                Try
                    InsertNextSerialNumber()
                Catch ex As Exception
                    'Error Log
                    Dim strSerialNumber As String
                    strSerialNumber = txtFirstSerialNumber.Text

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "Add Serial Numbers --- Add Additional Serial Number Failure"
                    ErrorReferenceNumber = "Serial # " + strSerialNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try
            Next
        End If

        'Clear Fields
        ClearVariables()
        ClearData()

        MsgBox("Serial Numbers entered.", MsgBoxStyle.OkOnly)

    End Sub

    Public Sub InsertIntoSerialLog()
        'Insert First Serial Number
        cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, Status, CustomerID, BuildNumber, BuildDate, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, ShipmentPrice, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @Status, @CustomerID, @BuildNumber, @BuildDate, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @ShipmentPrice, @InvoiceNumber, @InvoiceDate)", con)

        With cmd.Parameters
            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@SerialNumber", SqlDbType.VarChar).Value = txtFirstSerialNumber.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@TotalCost", SqlDbType.VarChar).Value = 0
            .Add("@Comment", SqlDbType.VarChar).Value = ""
            .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
            .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
            .Add("@BuildDate", SqlDbType.VarChar).Value = ""
            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
            .Add("@ShipmentPrice", SqlDbType.VarChar).Value = 0
            .Add("@ShipmentDate", SqlDbType.VarChar).Value = ""
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ""
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub InsertNextSerialNumber()
        'Insert First Serial Number
        cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, Status, CustomerID, BuildNumber, BuildDate, BatchNumber, TransactionNumber, ShipmentNumber, ShipmentDate, ShipmentPrice, InvoiceNumber, InvoiceDate) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @Status, @CustomerID, @BuildNumber, @BuildDate, @BatchNumber, @TransactionNumber, @ShipmentNumber, @ShipmentDate, @ShipmentPrice, @InvoiceNumber, @InvoiceDate)", con)

        With cmd.Parameters
            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@SerialNumber", SqlDbType.VarChar).Value = NextSerialNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@TotalCost", SqlDbType.VarChar).Value = 0
            .Add("@Comment", SqlDbType.VarChar).Value = ""
            .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
            .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
            .Add("@BuildDate", SqlDbType.VarChar).Value = ""
            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
            .Add("@ShipmentPrice", SqlDbType.VarChar).Value = 0
            .Add("@ShipmentDate", SqlDbType.VarChar).Value = ""
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ""
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class