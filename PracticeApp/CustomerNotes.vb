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
Public Class CustomerNotes
    Inherits System.Windows.Forms.Form

    Dim NextNoteNumber, LastNoteNumber As Integer
    Dim CustomerName As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub CustomerNotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        LoadCurrentDivision()

        If GlobalCustomerID = "" Then
            LoadCustomerList()
            LoadCustomerName()
            ShowData()
        Else
            LoadCustomerList()
            LoadCustomerName()
            cboDivisionID.Text = GlobalDivisionCode
            cboCustomerID.Text = GlobalCustomerID
            ShowData()
        End If
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerList()
        LoadCustomerName()
        ShowData()
    End Sub

    Public Sub ShowData()
        'Limit by Date - show last year by default, all if selected
        Dim DateFilter As String = ""
        Dim TodaysDate As Date = Today()
        Dim LastYearsDate As String = ""
        Dim strDay, strMonth, strYear As String
        Dim intDay, intMonth, intYear As Integer
        intDay = TodaysDate.Day
        intMonth = TodaysDate.Month
        intYear = TodaysDate.Year
        strDay = CStr(intDay)
        strMonth = CStr(intMonth)
        strYear = CStr(intYear - 1)

        LastYearsDate = strMonth + "/" + strDay + "/" + strYear

        If ViewPastYearToolStripMenuItem.Checked = True Then
            DateFilter = " AND NoteDate >= '" + LastYearsDate + "'"
        ElseIf ViewAllToolStripMenuItem.Checked = True Then
            DateFilter = ""
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID" + DateFilter + " ORDER BY NoteDate DESC", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerNotes")
        dgvCustomerNotes.DataSource = ds.Tables("CustomerNotes")
        con.Close()
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerID.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerName()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "CustomerList")
        con.Close()

        cboCustomerName.DataSource = ds5.Tables("CustomerList")
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvCustomerNotes.DataSource = Nothing
    End Sub

    Private Sub cmdTextSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTextSearch.Click
        If txtTextSearch.Text = "" Then
            ShowData()
        Else
            cmd = New SqlCommand("SELECT * FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND (NoteSubject LIKE '%" + txtTextSearch.Text + "%' OR NoteBody LIKE '%" + txtTextSearch.Text + "%') ORDER BY NoteDate DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "CustomerNotes")
            dgvCustomerNotes.DataSource = ds.Tables("CustomerNotes")
            con.Close()
        End If
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1String As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1String, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1String As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1String, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
        ShowData()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerNotes As New PrintCustomerNotes
            Dim Result = NewPrintCustomerNotes.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalCustomerID = ""
        GlobalDivisionCode = ""
        dtpNoteDate.Text = ""
        txtNoteSubject.Clear()
        txtNoteBody.Clear()
        txtTextSearch.Clear()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalCustomerID = ""
        GlobalDivisionCode = ""
        dtpNoteDate.Text = ""
        txtNoteSubject.Clear()
        txtNoteBody.Clear()
        txtTextSearch.Clear()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dtpNoteDate.Text = ""

        txtNoteSubject.Clear()
        txtNoteBody.Clear()

        dtpNoteDate.Focus()
    End Sub

    Private Sub cmdAddNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNote.Click
        If cboCustomerID.Text = "" Then
            MsgBox("You must have a valid Customer ID selected.", MsgBoxStyle.OkOnly)
        Else
            'Get Next Note Number
            Dim MaximumNoteString As String = "SELECT MAX(NoteID) FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
            MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastNoteNumber = CInt(MaximumNoteCommand.ExecuteScalar)
            Catch ex As Exception
                LastNoteNumber = 0
            End Try
            con.Close()

            NextNoteNumber = LastNoteNumber + 1

            'Write Data to Customer Note Table
            cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@NoteDate", SqlDbType.VarChar).Value = dtpNoteDate.Text
                .Add("@NoteSubject", SqlDbType.VarChar).Value = txtNoteSubject.Text
                .Add("@NoteBody", SqlDbType.VarChar).Value = txtNoteBody.Text
                .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            dtpNoteDate.Text = ""
            txtNoteSubject.Clear()
            txtNoteBody.Clear()
            dtpNoteDate.Focus()

            ShowData()
            MsgBox("Customer Note has been added.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub dgvCustomerNotes_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerNotes.CellValueChanged
        If dgvCustomerNotes.RowCount <> 0 Then
            Dim RowCustomer As String = ""
            Dim RowDivision As String = ""
            Dim RowNoteID As Integer = 0
            Dim NoteSubject As String = ""
            Dim NoteBody As String = ""

            Dim RowIndex As Integer = Me.dgvCustomerNotes.CurrentCell.RowIndex

            RowCustomer = Me.dgvCustomerNotes.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvCustomerNotes.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowNoteID = Me.dgvCustomerNotes.Rows(RowIndex).Cells("NoteIDColumn").Value
            NoteSubject = Me.dgvCustomerNotes.Rows(RowIndex).Cells("NoteSubjectColumn").Value
            NoteBody = Me.dgvCustomerNotes.Rows(RowIndex).Cells("NoteBodyColumn").Value

            'Write Data to Customer Note Table
            cmd = New SqlCommand("UPDATE CustomerNotes SET NoteSubject = @NoteSubject, NoteBody = @NoteBody WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND NoteID = @NoteID", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                .Add("@NoteID", SqlDbType.VarChar).Value = RowNoteID
                .Add("@NoteSubject", SqlDbType.VarChar).Value = NoteSubject
                .Add("@NoteBody", SqlDbType.VarChar).Value = NoteBody
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'ShowData()
        Else
            'Skip
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If dgvCustomerNotes.RowCount <> 0 Then
            Dim RowCustomer As String = ""
            Dim RowDivision As String = ""
            Dim RowNoteID As Integer = 0
            Dim RowIndex As Integer = Me.dgvCustomerNotes.CurrentCell.RowIndex

            RowCustomer = Me.dgvCustomerNotes.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvCustomerNotes.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowNoteID = Me.dgvCustomerNotes.Rows(RowIndex).Cells("NoteIDColumn").Value

            'Write Data to Customer Note Table
            cmd = New SqlCommand("DELETE FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND NoteID = @NoteID", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                .Add("@NoteID", SqlDbType.VarChar).Value = RowNoteID
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowData()

            MsgBox("Customer Note deleted.", MsgBoxStyle.OkOnly)
        Else
            'Skip
        End If
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

    Private Sub CustomerNotes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub cmdClearFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFilters.Click
        txtTextSearch.Clear()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

        ClearDataInDatagrid()

        cboCustomerID.Focus()
    End Sub

    Private Sub ViewPastYearToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewPastYearToolStripMenuItem.CheckedChanged
        If ViewPastYearToolStripMenuItem.Checked = True Then
            ViewAllToolStripMenuItem.Checked = False
        ElseIf ViewPastYearToolStripMenuItem.Checked = False Then
            ViewAllToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ViewAllToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewAllToolStripMenuItem.CheckedChanged
        If ViewAllToolStripMenuItem.Checked = True Then
            ViewPastYearToolStripMenuItem.Checked = False
        ElseIf ViewAllToolStripMenuItem.Checked = False Then
            ViewPastYearToolStripMenuItem.Checked = True
        End If
    End Sub
End Class