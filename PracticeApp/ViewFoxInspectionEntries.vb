Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewFOXInspectionEntries
    Inherits System.Windows.Forms.Form

    Dim dsFox, dsMachine, dsOperator, dsEntries As DataSet

    ''custom structure for sorting purposes
    Structure entryInfo
        Public HeaderKey As String
        Public lineNumber As Integer
        Public HeaderOperator As String
        Public HeaderProductionDate As String
        Public HeaderProductionTime As String
        Public lowSpec As String
        Public HighSpec As String
        Public HeaderProductionMeasurement As String
        ''constructor for the object to start with values
        Public Sub entryInfo(ByVal key As String, ByVal line As Integer, ByVal op As String, ByVal dat As String, ByVal tm As String, ByVal meas As String, ByVal low As String, ByVal high As String)
            HeaderKey = key
            lineNumber = line
            HeaderOperator = op
            HeaderProductionDate = dat
            HeaderProductionTime = tm
            HeaderProductionMeasurement = meas
            lowSpec = low
            HighSpec = high
        End Sub
    End Structure

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        clearAll()
        ''waits for the worker to become free again but will still allow the application to function
        While bgFoxLoad.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While
        bgFoxLoad.RunWorkerAsync()
        While bgOperatorLoad.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While
        bgOperatorLoad.RunWorkerAsync()
    End Sub

    Private Sub clearAll()
        cboFOX.SelectedIndex = -1
        cboMachine.SelectedIndex = -1
        dtpBeginningDate.Value = Today
        dtpEndingDate.Value = Today
        Dim current As String = ""
        If Today.Now.Hour > 12 Then
            current = Convert.ToString(Today.Now.Hour - 12) + ":00PM"
        Else
            current = Today.Now.Hour.ToString + ":00AM"
        End If
        cboBeginningTime.SelectedIndex = -1
        cboEndingTime.SelectedIndex = -1
        cboBeginningTime.Text = current
        cboEndingTime.Text = current
        dgvEntries.Rows.Clear()
        dsEntries = New DataSet()
        chkDaily.Checked = False
    End Sub

    Private Sub ViewFOXInspectionEntries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''bgFoxLoad.RunWorkerAsync()
        Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT FOXNumber FROM FOXTable;", con)
        Dim adapt As New SqlDataAdapter(cmd)
        dsFox = New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(dsFox, "FOXTable")
        con.Close()

        cboFOX.DisplayMember = "FOXNumber"
        cboFOX.DataSource = dsFox.Tables("FOXTable")
        cboFOX.SelectedIndex = -1

        bgMachineLoad.RunWorkerAsync()
        bgOperatorLoad.RunWorkerAsync()
        Dim current As String = ""
        ''getst hte current time and will checl against if it is afternoon and will roun to the hour it is

        If Today.Now.Hour > 12 Then
            current = Convert.ToString(Today.Now.Hour - 12) + ":00PM"
        Else
            current = Today.Now.Hour.ToString + ":00AM"
        End If
        setupDGV()
        cboBeginningTime.Text = current
        cboEndingTime.Text = current
    End Sub

    Private Sub bgFoxLoad_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgFoxLoad.DoWork
        Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT FOXNumber FROM FOXTable;", con)
        Dim adapt As New SqlDataAdapter
        dsFox = New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.SelectCommand = cmd
        adapt.Fill(dsFox, "FOXTable")
        con.Close()
    End Sub

    Private Sub bgFoxLoad_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgFoxLoad.RunWorkerCompleted
        cboFOX.DisplayMember = "FOXNumber"
        cboFOX.DataSource = dsFox.Tables("FOXTable")
        cboFOX.SelectedIndex = -1
    End Sub

    Private Sub bgMachineLoad_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgMachineLoad.DoWork
        Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT MachineID FROM MachineTable;", con)
        Dim adapt As New SqlDataAdapter
        dsMachine = New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.SelectCommand = cmd
        adapt.Fill(dsMachine, "MachineTable")
        con.Close()
    End Sub

    Private Sub bgMachineLoad_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgMachineLoad.RunWorkerCompleted
        cboMachine.DisplayMember = "MachineID"
        cboMachine.DataSource = dsMachine.Tables("MachineTable")
        cboMachine.SelectedIndex = -1
    End Sub

    Private Sub bgOperatorLoad_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgOperatorLoad.DoWork
        Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT LoginName FROM EmployeeData WHERE SecurityGroupID = 1004;", con)
        Dim adapt As New SqlDataAdapter
        dsOperator = New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.SelectCommand = cmd
        adapt.Fill(dsOperator, "EmployeeData")
        con.Close()
    End Sub

    Private Sub bgOperatorLoad_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgOperatorLoad.RunWorkerCompleted
        cboOperator.DisplayMember = "LoginName"
        cboOperator.DataSource = dsOperator.Tables("EmployeeData")
        cboOperator.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        If canView() Then
            dgvEntries.Rows.Clear()
            Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
            Dim cmd As New SqlCommand("SELECT LowSpec, HighSpec, HeaderOperator, HeaderProductionDate, HeaderProductionTime, HeaderProductionMeasurement, HeaderKey, HeaderLineNumber FROM HeaderProductionTable inner join QCInspectionLineTable on QCInspectionLineTable.InspectionKey = HeaderProductionTable.HeaderKey and QCInspectionLineTable.InspectionLineNumber = HeaderProductionTable.HeaderLineNumber WHERE ", con)
            Dim adapt As New SqlDataAdapter
            dsEntries = New DataSet()
            Dim lst As List(Of entryInfo) = generateQuery(cmd)
            If lst.Count > 0 Then
                fillDGV(lst)
            Else
                MessageBox.Show("No Entries found", "No entries", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function canView() As Boolean
        If cboBeginningTime.SelectedIndex > cboEndingTime.SelectedIndex Then
            If dtpBeginningDate.Text = dtpEndingDate.Text Then
                MessageBox.Show("You can't have a beginning date before the end date.", "End date is before beginning date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        If chkDaily.Checked Then
            If cboBeginningTime.Text.Contains("PM") And cboEndingTime.Text.Contains("AM") Then
                MessageBox.Show("To use daily start time can't be PM while end time is AM", "Unable to view", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        Return True
    End Function

    Private Function generateQuery(ByRef cmd As SqlCommand) As List(Of entryInfo)
        Dim first As Boolean = True
        ''checks to see if a FOX was entered
        If cboFOX.SelectedIndex <> -1 Then
            'checks to see if a machine number was entrered in addition to the FOX
            If cboMachine.SelectedIndex <> -1 Then
                Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
                Dim cmd1 As New SqlCommand("SELECT InspectionKey FROM QCInspectionHeaderTable WHERE FOXNumber = @FOXNumber;", con)
                cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOX.Text
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd1.ExecuteReader()
                ''will add each FOXOperation found to the query
                If reader.HasRows Then
                    Dim tmp As String = "("
                    While reader.Read()
                        If first Then
                            tmp += "HeaderKey = '" + reader.GetValue(0) + "'"
                            first = False
                        Else
                            tmp += " OR HeaderKey = '" + reader.GetValue(0) + "'"
                        End If
                    End While
                    cmd.CommandText += tmp + ")"
                End If
                reader.Close()
                con.Close()
            Else
                ''if no machine was entered will just all all the FOXOperations to the query
                Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
                Dim cmd1 As New SqlCommand("SELECT InspectionKey FROM QCInspectionHeaderTable WHERE FOXNumber = @FOXNumber;", con)
                cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOX.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd1.ExecuteReader()
                ''will add each FOXOperation found to the query
                If reader.HasRows Then
                    Dim tmp As String = "("
                    While reader.Read()
                        If first Then
                            tmp += "HeaderKey = '" + reader.GetValue(0) + "'"
                            first = False
                        Else
                            tmp += " OR HeaderKey = '" + reader.GetValue(0) + "'"
                        End If
                    End While
                    cmd.CommandText += tmp + ")"
                Else
                    If first Then
                        cmd.CommandText += "HeaderKey = ''"
                        first = False
                    Else
                        cmd.CommandText += " AND HeaderKey = ''"
                    End If
                End If
                reader.Close()
                con.Close()
            End If
        Else
            ''if the FOX is not entered will see if hte Machine numer was entered and if it was will add the FOXOperations to the query
            If cboMachine.SelectedIndex <> -1 Then
                Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
                Dim cmd1 As New SqlCommand("SELECT InspectionKey FROM QCInspectionHeaderTable WHERE MachineNumber = @MachineNumber;", con)
                cmd1.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachine.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd1.ExecuteReader()
                ''will add each FOXOperation found to the query
                If reader.HasRows Then
                    Dim tmp As String = "("
                    While reader.Read()
                        If first Then
                            tmp += "HeaderKey = '" + reader.GetValue(0) + "'"
                            first = False
                        Else
                            tmp += " OR HeaderKey = '" + reader.GetValue(0) + "'"
                        End If
                    End While
                    cmd.CommandText += tmp + ")"
                End If
                reader.Close()
                con.Close()

            End If
        End If
        If dtpBeginningDate.Text <> dtpEndingDate.Text Then
            If first Then
                cmd.CommandText += "HeaderProductionTable.HeaderProductionDate BETWEEN @BeginningDate AND  @EndingDate"
                first = False
            Else
                cmd.CommandText += " AND HeaderProductionTable.HeaderProductionDate BETWEEN @BeginningDate AND  @EndingDate"
            End If
            cmd.Parameters.Add("@BeginningDate", SqlDbType.Date).Value = dtpBeginningDate.Text
            cmd.Parameters.Add("@EndingDate", SqlDbType.Date).Value = dtpEndingDate.Text
        Else
            If first Then
                cmd.CommandText += "HeaderProductionTable.HeaderProductionDate = @HeaderProductionDate"
                first = False
            Else
                cmd.CommandText += " AND HeaderProductionTable.HeaderProductionDate = @HeaderProductionDate"
            End If
            cmd.Parameters.Add("@HeaderProductionDate", SqlDbType.Date).Value = dtpBeginningDate.Text
        End If
        If cboOperator.SelectedIndex <> -1 Then
            If first Then
                cmd.CommandText += "HeaderOperator = '" + cboOperator.Text + "'"
                first = False
            Else
                cmd.CommandText += " AND HeaderOperator = '" + cboOperator.Text + "'"
            End If
        End If
        ''checks to see if there is a change to the times and if there is will make a query based on that
        Dim lst As List(Of List(Of entryInfo)) = sortTime(cmd)
        Dim comp As New List(Of entryInfo)
        If cboBeginningTime.Text <> cboEndingTime.Text Then
            If lst.Count > 0 Then
                If chkDaily.Checked Then
                    comp = filterTimeDaily(lst)
                Else
                    comp = filterTime(lst)
                End If
            End If
        Else
            ''combines them into one list
            For i As Integer = 0 To lst.Count - 1
                If lst(i).Count > 0 Then
                    For j As Integer = 0 To lst(i).Count - 1
                        comp.Add(lst(i)(j))
                    Next
                End If
            Next
        End If
        Return comp
    End Function
    ''combines all the lists of date times and returns the list of lists
    Private Function sortTime(ByVal cmd As SqlCommand) As List(Of List(Of entryInfo))
        Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim ds As New DataSet()
        Dim adap As New SqlDataAdapter
        cmd.CommandText += " ORDER BY HeaderProductionDate;"
        If con.State = ConnectionState.Closed Then con.Open()
        adap.SelectCommand = cmd
        adap.Fill(ds, "HeaderProductionTable")
        con.Close()
        If ds.Tables("HeaderProductionTable").Rows.Count > 0 Then
            Dim currentDate As String = ds.Tables("HeaderProductionTable").Rows(0).Item("HeaderProductionDate")
            Dim lst As New List(Of entryInfo)
            Dim mstr As New List(Of List(Of entryInfo))
            For Each rw As DataRow In ds.Tables("HeaderProductionTable").Rows
                Dim nw As New entryInfo
                nw.entryInfo(rw.Item("HeaderKey"), rw.Item("HeaderLineNumber"), rw.Item("HeaderOperator"), rw.Item("HeaderProductionDate"), rw.Item("HeaderProductionTime"), rw.Item("HeaderProductionMeasurement"), rw.Item("LowSpec"), rw.Item("HighSpec"))
                If nw.HeaderProductionDate = currentDate Then
                    lst.Add(nw)
                Else
                    lst = timeSortDate(lst)
                    mstr.Add(lst)
                    lst = New List(Of entryInfo)
                    currentDate = nw.HeaderProductionDate
                    lst.Add(nw)
                End If
            Next
            lst = timeSortDate(lst)
            mstr.Add(lst)
            Return addEmpty(mstr)
        End If
        Return New List(Of List(Of entryInfo))
    End Function
    ''sorts the list of times
    Private Function timeSortDate(ByVal dateList As List(Of entryInfo)) As List(Of entryInfo)
        Dim amList As New List(Of entryInfo)
        Dim pmList As New List(Of entryInfo)
        For i As Integer = 0 To dateList.Count - 1
            If getAMPM(dateList(i).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)) = "AM" Then
                amList.Add(dateList(i))
            Else
                pmList.Add(dateList(i))
            End If
        Next
        If amList.Count > 1 Then
            sortList(amList)
        End If
        If pmList.Count > 1 Then
            sortList(pmList)
        End If
        Dim lst As New List(Of entryInfo)
        lst = amList
        If pmList.Count > 0 Then
            For i As Integer = 0 To pmList.Count - 1
                lst.Add(pmList(i))
            Next
        End If
        Return lst
    End Function
    ''gets the am or pm from a given string
    Private Function getAMPM(ByVal tme As String()) As String
        If tme(tme.Count - 1).Contains("AM") Then
            Return "AM"
        Else
            Return "PM"
        End If
    End Function
    ''checks to make sure there are the same amount of lists as there are days selected
    Private Function addEmpty(ByVal mstr As List(Of List(Of entryInfo))) As List(Of List(Of entryInfo))
        Dim cnt As Integer = dtpEndingDate.Value.Day - dtpBeginningDate.Value.Day
        If mstr.Count = cnt Then
            Return mstr
        End If
        Dim dte As String() = mstr(0)(0).HeaderProductionDate.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)
        Dim diff As Integer = Val(dte(1)) - dtpBeginningDate.Value.Day
        If diff > 0 Then
            While diff > 0
                mstr.Insert(0, New List(Of entryInfo))
                diff -= 1
            End While
        End If
        dte = mstr(mstr.Count - 1)(0).HeaderProductionDate.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)
        diff = dtpEndingDate.Value.Day - Val(dte(1))
        If diff > 0 Then
            While diff > 0
                mstr.Add(New List(Of entryInfo))
                diff -= 1
            End While
        End If
        Return mstr
    End Function
    ''sorts the given list of entryInfo elements
    Private Sub sortList(ByRef lst As List(Of entryInfo))
        Dim tempNode As New entryInfo
        Dim notSorted As Boolean = True
        Dim pos As Integer = 0
        Dim ampm As String = getAMPM(lst(0).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries))
        Dim firstTime As String() = lst(0).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
        If firstTime(0) = "12" Then
            firstTime(0) = "0"
        End If
        While pos < lst.Count
            Dim i As Integer = pos
            While i < lst.Count
                Dim secondTime As String() = lst(i).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                If secondTime(0) = "12" Then
                    secondTime(0) = "0"
                End If
                ''check to make sure we need to go into the other method
                If Val(firstTime(0)) >= Val(secondTime(0)) Then
                    ''if both are equal hours but first's minutes are higher will swap
                    If canSwap(firstTime, secondTime, ampm.Substring(0, 1)) Then
                        tempNode = New entryInfo
                        tempNode = lst(pos)
                        'lst(pos) = lst(i)
                        'lst(i) = tempNode
                        lst.Insert(pos, lst(i))
                        lst.RemoveAt(pos + 1)
                        lst.Insert(i, tempNode)
                        lst.RemoveAt(i + 1)
                        firstTime = lst(pos).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                        If firstTime(0) = "12" Then
                            firstTime(0) = "0"
                        End If
                    End If
                End If
                i += 1
            End While
            pos += 1
            If pos < lst.Count - 1 Then
                firstTime = lst(pos).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                If firstTime(0) = "12" Then
                    firstTime(0) = "0"
                End If
            End If
        End While
    End Sub
    ''determines if the nodes should be swapped
    Private Function canSwap(ByRef firstTime As String(), ByVal secondTime As String(), ByVal amPM As String) As Boolean
        If Val(firstTime(0)) = Val(secondTime(0)) Then
            If Val(firstTime(1)) > Val(secondTime(1)) Then
                Return True
            Else
                If Val(firstTime(1)) = Val(secondTime(1)) Then
                    If Val(firstTime(2).Substring(0, 2)) > Val(secondTime(2).Substring(0, 2)) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    If Val(firstTime(1)) > Val(secondTime(1)) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End If
        If Val(secondTime(0)) = 0 Then
            Return True
        End If
        If Val(firstTime(0)) > Val(secondTime(0)) Then
            Return True
        End If
        Return False
    End Function
    ''filters the list based on the imformation supplied
    Private Function filterTime(ByVal lst As List(Of List(Of entryInfo))) As List(Of entryInfo)
        If cboBeginningTime.SelectedIndex > cboEndingTime.SelectedIndex Then
            Return filterTimeDayOverlap(lst)
        End If
        Dim beginTime As String() = cboBeginningTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
        If beginTime(0) = "12" Then
            beginTime(0) = "0"
        End If
        Dim beginAMPM As String = getAMPM(beginTime)
        Dim endTime As String() = cboEndingTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
        ''checks to make sure that if the beginning time is 12 won't remove any items
        If endTime(0) = "12" Then
            endTime(0) = "0"
        End If
        Dim endAMPM As String = getAMPM(endTime)

        If dtpBeginningDate.Value.Day <> dtpEndingDate.Value.Day Then
            If lst.Count > 1 Then
                Dim i As Integer = 0
                While i < lst(0).Count
                    Dim removed As Boolean = False
                    Dim curr As String() = lst(0)(i).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                    If curr(0) = "12" Then
                        curr(0) = "0"
                    End If
                    Dim ampm As String = getAMPM(curr)
                    If beginAMPM = ampm Then
                        If Val(beginTime(0)) > Val(curr(0)) Then
                            removed = True
                            lst(0).RemoveAt(i)
                        End If
                    Else
                        If beginAMPM = "PM" And ampm = "AM" Then
                            removed = True
                            lst(0).RemoveAt(i)
                        End If
                    End If
                    If removed = False Then
                        i += 1
                    End If
                End While
                Dim last As Integer = lst.Count - 1
                While i < lst(last).Count
                    Dim removed As Boolean = False
                    Dim curr As String() = lst(last)(i).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                    If curr(0) = "12" Then
                        curr(0) = "0"
                    End If
                    Dim ampm As String = getAMPM(curr)
                    If endAMPM = ampm Then
                        If Val(endTime(0)) <= Val(curr(0)) Then
                            removed = True
                            lst(last).RemoveAt(i)
                        End If
                    Else
                        If endAMPM = "PM" And ampm <> "AM" Then
                            removed = True
                            lst(last).RemoveAt(i)
                        Else
                            If endAMPM = "AM" And ampm = "PM" Then
                                removed = True
                                lst(last).RemoveAt(i)
                            End If
                        End If
                    End If
                    If removed = False Then
                        i += 1
                    End If
                End While
            End If
        Else
            Dim i As Integer = 0
            Dim removed As Boolean = False
            While i < lst(0).Count
                Dim curr As String() = lst(0)(i).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                If curr(0) = "12" Then
                    curr(0) = "0"
                End If
                Dim ampm As String = getAMPM(curr)
                If ampm = "AM" Then
                    If beginAMPM <> "AM" Then
                        removed = True
                        lst(0).RemoveAt(i)
                    Else
                        If Val(beginTime(0)) > Val(curr(0)) Then
                            removed = True
                            lst(0).RemoveAt(i)
                        Else
                            If endAMPM = "AM" Then
                                If Val(endTime(0)) <= Val(curr(0)) Then
                                    removed = True
                                    lst(0).RemoveAt(i)
                                End If
                            End If
                        End If
                    End If
                Else
                    If endAMPM <> "PM" Then
                        removed = True
                        lst(0).RemoveAt(i)
                    Else
                        If Val(endTime(0)) <= Val(curr(0)) Then
                            removed = True
                            lst(0).RemoveAt(i)
                        Else
                            If beginAMPM = "PM" Then
                                If Val(beginTime(0)) > Val(curr(0)) Then
                                    removed = True
                                    lst(0).RemoveAt(i)
                                End If
                            End If
                        End If
                    End If
                End If
                If removed Then
                    removed = False
                Else
                    i += 1
                End If
            End While
        End If
        Dim comp As New List(Of entryInfo)
        ''combines them into one list
        For i As Integer = 0 To lst.Count - 1
            If lst(i).Count > 0 Then
                For j As Integer = 0 To lst(i).Count - 1
                    comp.Add(lst(i)(j))
                Next
            End If
        Next
        Return comp
    End Function

    Private Function filterTimeDaily(ByVal lst As List(Of List(Of entryInfo))) As List(Of entryInfo)
        If dtpBeginningDate.Text = dtpEndingDate.Text Then
            Return filterTime(lst)
        Else
            For i As Integer = 0 To lst.Count - 1
                Dim beginTime As String() = cboBeginningTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                If beginTime(0) = "12" Then
                    beginTime(0) = "0"
                End If
                Dim beginAMPM As String = getAMPM(beginTime)
                Dim endTime As String() = cboEndingTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                ''checks to make sure that if the beginning time is 12 won't remove any items
                If endTime(0) = "12" Then
                    endTime(0) = "0"
                End If
                Dim endAMPM As String = getAMPM(endTime)
                Dim j As Integer = 0
                Dim removed As Boolean = False
                While j < lst(i).Count
                    Dim curr As String() = lst(i)(j).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                    If curr(0) = "12" Then
                        curr(0) = "0"
                    End If
                    Dim ampm As String = getAMPM(curr)
                    If ampm = "AM" Then
                        If beginAMPM <> "AM" Then
                            removed = True
                            lst(i).RemoveAt(j)
                        Else
                            If Val(beginTime(0)) > Val(curr(0)) Then
                                removed = True
                                lst(i).RemoveAt(j)
                            Else
                                If endAMPM = "AM" Then
                                    If Val(endTime(0)) <= Val(curr(0)) Then
                                        removed = True
                                        lst(i).RemoveAt(j)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If endAMPM <> "PM" Then
                            removed = True
                            lst(i).RemoveAt(j)
                        Else
                            If Val(endTime(0)) <= Val(curr(0)) Then
                                removed = True
                                lst(i).RemoveAt(j)
                            Else
                                If beginAMPM = "PM" Then
                                    If Val(beginTime(0)) > Val(curr(0)) Then
                                        removed = True
                                        lst(i).RemoveAt(j)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If removed Then
                        removed = False
                    Else
                        j += 1
                    End If
                End While
            Next
        End If
        Dim comp As New List(Of entryInfo)
        ''combines them into one list
        For i As Integer = 0 To lst.Count - 1
            If lst(i).Count > 0 Then
                For j As Integer = 0 To lst(i).Count - 1
                    comp.Add(lst(i)(j))
                Next
            End If
        Next
        Return comp
    End Function

    Private Function filterTimeDayOverlap(ByVal lst As List(Of List(Of entryInfo))) As List(Of entryInfo)
        Dim last As Integer = lst.Count - 1
        For i As Integer = 0 To lst.Count - 1
            Dim beginTime As String() = cboBeginningTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
            If beginTime(0) = "12" Then
                beginTime(0) = "0"
            End If
            Dim beginAMPM As String = getAMPM(beginTime)
            Dim endTime As String() = cboEndingTime.Text.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
            ''checks to make sure that if the beginning time is 12 won't remove any items
            If endTime(0) = "12" Then
                endTime(0) = "0"
            End If
            Dim endAMPM As String = getAMPM(endTime)
            ''goes through the each day and removes un-needed data
            Dim j As Integer = 0
            While j < lst(i).Count

                Dim removed As Boolean = False
                Dim curr As String() = lst(i)(j).HeaderProductionTime.Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                If curr(0) = "12" Then
                    curr(0) = "0"
                End If
                Dim ampm As String = getAMPM(curr)
                ''if this is the first day in the range, this will just filter the beginning time
                If i = 0 Then
                    If beginAMPM = ampm Then
                        If Val(beginTime(0)) > Val(curr(0)) Then
                            removed = True
                            lst(i).RemoveAt(j)
                        End If
                    Else
                        If beginAMPM = "PM" And ampm = "AM" Then
                            removed = True
                            lst(i).RemoveAt(j)
                        End If
                    End If
                Else
                    ''checks to see if this is the last day in the range, if it is this will filter just on the end time
                    If i = last Then
                        If endAMPM = ampm Then
                            If Val(endTime(0)) <= Val(curr(0)) Then
                                removed = True
                                lst(last).RemoveAt(j)
                            End If
                        Else
                            If endAMPM = "PM" And ampm = "AM" Then
                                removed = True
                                lst(last).RemoveAt(j)
                            End If
                        End If
                    Else
                        If endAMPM = beginAMPM Then
                            If ampm = endAMPM Then
                                If Val(curr(0)) >= Val(endTime(0)) Then
                                    If Val(curr(0)) < Val(beginTime(0)) Then
                                        removed = True
                                        lst(i).RemoveAt(j)
                                    End If
                                End If
                            End If
                        Else
                            If ampm = endAMPM Then
                                If Val(endTime(0)) <= Val(curr(0)) Then
                                    removed = True
                                    lst(last).RemoveAt(j)
                                End If
                            Else
                                If Val(beginTime(0)) > Val(curr(0)) Then
                                    removed = True
                                    lst(last).RemoveAt(j)
                                End If
                            End If
                        End If
                    End If
                End If
                If removed = False Then
                    j += 1
                End If
            End While
        Next
        Dim comp As New List(Of entryInfo)
        ''combines them into one list
        For i As Integer = 0 To lst.Count - 1
            If lst(i).Count > 0 Then
                For j As Integer = 0 To lst(i).Count - 1
                    comp.Add(lst(i)(j))
                Next
            End If
        Next
        Return comp
    End Function

    Private Sub setupDGV()
        dgvEntries.Columns.Add("lowSpec", "Low Spec")
        dgvEntries.Columns("lowSpec").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvEntries.Columns.Add("highSpec", "High Spec")
        dgvEntries.Columns("highSpec").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvEntries.Columns.Add("operator", "Operator")
        dgvEntries.Columns("operator").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvEntries.Columns.Add("date", "Date")
        dgvEntries.Columns("date").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvEntries.Columns.Add("time", "Time")
        dgvEntries.Columns("time").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvEntries.Columns.Add("measurement", "Measurement")
        dgvEntries.Columns("measurement").SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub fillDGV(ByVal lst As List(Of entryInfo))
        dgvEntries.Rows.Clear()
        dgvEntries.Rows.Add()
        dgvEntries.Rows(0).Cells("date").Value = lst(0).HeaderProductionDate
        dgvEntries.Rows(0).Cells("date").Style.Font = New System.Drawing.Font(DefaultFont.FontFamily, 11, FontStyle.Bold, GraphicsUnit.Point)

        For i As Integer = 0 To lst.Count - 1
            If i > 0 Then
                If lst(i - 1).HeaderProductionDate <> lst(i).HeaderProductionDate Then
                    dgvEntries.Rows.Add()
                    dgvEntries.Rows(dgvEntries.Rows.Count - 1).Cells("date").Value = lst(i).HeaderProductionDate
                    dgvEntries.Rows(dgvEntries.Rows.Count - 1).Cells("date").Style.Font = New System.Drawing.Font(DefaultFont.FontFamily, 11, FontStyle.Bold, GraphicsUnit.Point)
                End If
            End If

            dgvEntries.Rows.Add(lst(i).lowSpec, lst(i).HighSpec, lst(i).HeaderOperator, lst(i).HeaderProductionDate, lst(i).HeaderProductionTime, lst(i).HeaderProductionMeasurement)
            withinTol()
        Next
    End Sub

    Private Sub withinTol()
        Dim rwNum As Integer = dgvEntries.Rows.Count - 1
        Dim low As String = dgvEntries.Rows(rwNum).Cells("lowSpec").Value
        Dim high As String = dgvEntries.Rows(rwNum).Cells("highSpec").Value
        Dim measure As String = dgvEntries.Rows(rwNum).Cells("measurement").Value
        If String.IsNullOrEmpty(low) = False Then
            If low.Contains("MIN") Then
                low = low.Substring(0, low.IndexOf("M"))
            End If
            If IsNumeric(low) Then
                If Val(low) > Val(measure) Then
                    dgvEntries.Rows(rwNum).Cells("measurement").Style.BackColor = Color.LightCoral
                    Exit Sub
                End If
            End If
        End If
        If String.IsNullOrEmpty(high) = False Then
            If high.Contains("MAX") Then
                high = high.Substring(0, high.IndexOf("M"))
            End If
            If Val(high) < Val(measure) Then
                dgvEntries.Rows(rwNum).Cells("measurement").Style.BackColor = Color.LightCoral
                Exit Sub
            End If
        End If
        If IsNumeric(measure) = False Then
            If measure = "NOT OK" Then
                dgvEntries.Rows(rwNum).Cells("measurement").Style.BackColor = Color.LightCoral
                Exit Sub
            End If
        End If
        dgvEntries.Rows(rwNum).Cells("measurement").Style.BackColor = Color.LightGreen
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub lblRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRed.Click

    End Sub
End Class