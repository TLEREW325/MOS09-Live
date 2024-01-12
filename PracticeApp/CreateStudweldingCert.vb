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
Public Class CreateStudweldingCert
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim TodaysDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub CreateStudweldingCert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        TodaysDate = Today.ToShortDateString()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If

        LoadCertificatesForDivision()
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadCertificatesForDivision()
        cmd = New SqlCommand("SELECT * FROM StudWeldingCertification WHERE DivisionID = @DivisionID ORDER BY IndividualName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "StudWeldingCertification")
        dgvStudweldingCertificate.DataSource = ds.Tables("StudWeldingCertification")
        con.Close()
    End Sub

    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        'Verify that all fields are filled in
        If txtTraineeCompany.Text = "" Or txtTraineeName.Text = "" Or txtTrainerCompany.Text = "" Or txtTrainerName.Text = "" Then
            MsgBox("You must fill in all fields for a certificate.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Write to database
        cmd = New SqlCommand("INSERT INTO StudWeldingCertification (DivisionID, CompanyName, IndividualName, CertificationDate, CertificationTrainer, CertificationCompany, PrintDate, Comment) values (@DivisionID, @CompanyName, @IndividualName, @CertificationDate, @CertificationTrainer, @CertificationCompany, @PrintDate, @Comment)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CompanyName", SqlDbType.VarChar).Value = txtTraineeCompany.Text
            .Add("@IndividualName", SqlDbType.VarChar).Value = txtTraineeName.Text
            .Add("@CertificationDate", SqlDbType.VarChar).Value = dtpCertDate.Text
            .Add("@CertificationTrainer", SqlDbType.VarChar).Value = txtTrainerName.Text
            .Add("@CertificationCompany", SqlDbType.VarChar).Value = txtTrainerCompany.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
            .Add("@Comment", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadCertificatesForDivision()

        'Bring up print form
        GlobalDivisionCode = cboDivisionID.Text
        GlobalTraineeName = txtTraineeName.Text
        GlobalTraineeCompany = txtTraineeCompany.Text
        GlobalStudweldingBatchPrinting = "NO"

        'Choose the correct Print Form (REMOTE or LOCAL)

        'Get Login Type
        Dim GetLoginType As String = ""

        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetLoginType = ""
        End Try
        con.Close()

        If GetLoginType = "REMOTE" Then
            Using NewPrintStudweldingCerticateRemote As New PrintStudweldingCerticateRemote
                Dim Result = NewPrintStudweldingCerticateRemote.ShowDialog()
            End Using
        Else
            Using NewPrintStudweldingCertificate As New PrintStudweldingCerticate
                Dim Result = NewPrintStudweldingCertificate.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtTraineeCompany.Clear()
        txtTraineeName.Clear()
        txtTrainerCompany.Clear()
        txtTrainerName.Clear()

        dtpCertDate.Text = ""

        txtTraineeName.Focus()
    End Sub

    Private Sub dgvStudweldingCertificate_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStudweldingCertificate.CellDoubleClick
        Dim RowTraineeName As String = ""
        Dim RowTraineeCompany As String = ""
        Dim RowDivision As String = ""

        If dgvStudweldingCertificate.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvStudweldingCertificate.CurrentCell.RowIndex

            RowTraineeName = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("IndividualNameColumn").Value
            RowTraineeCompany = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("CompanyNameColumn").Value
            RowDivision = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalDivisionCode = RowDivision
            GlobalTraineeName = RowTraineeName
            GlobalTraineeCompany = RowTraineeCompany
            GlobalStudweldingBatchPrinting = "NO"

            'Choose the correct Print Form (REMOTE or LOCAL)

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Using NewPrintStudweldingCerticateRemote As New PrintStudweldingCerticateRemote
                    Dim Result = NewPrintStudweldingCerticateRemote.ShowDialog()
                End Using
            Else
                Using NewPrintStudweldingCertificate As New PrintStudweldingCerticate
                    Dim Result = NewPrintStudweldingCertificate.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim RowTraineeName As String = ""
        Dim RowTraineeCompany As String = ""
        Dim RowDivision As String = ""

        If dgvStudweldingCertificate.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvStudweldingCertificate.CurrentCell.RowIndex

            RowTraineeName = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("IndividualNameColumn").Value
            RowTraineeCompany = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("CompanyNameColumn").Value
            RowDivision = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalDivisionCode = RowDivision
            GlobalTraineeName = RowTraineeName
            GlobalTraineeCompany = RowTraineeCompany
            GlobalStudweldingBatchPrinting = "NO"

            'Choose the correct Print Form (REMOTE or LOCAL)

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Using NewPrintStudweldingCerticateRemote As New PrintStudweldingCerticateRemote
                    Dim Result = NewPrintStudweldingCerticateRemote.ShowDialog()
                End Using
            Else
                Using NewPrintStudweldingCertification As New PrintStudweldingCerticate
                    Dim Result = NewPrintStudweldingCertification.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim RowTraineeName As String = ""
        Dim RowTraineeCompany As String = ""
        Dim RowDivision As String = ""

        If dgvStudweldingCertificate.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvStudweldingCertificate.CurrentCell.RowIndex

            RowTraineeName = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("IndividualNameColumn").Value
            RowTraineeCompany = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("CompanyNameColumn").Value
            RowDivision = Me.dgvStudweldingCertificate.Rows(RowIndex).Cells("DivisionIDColumn").Value

            cmd = New SqlCommand("DELETE FROM StudWeldingCertification WHERE DivisionID = @DivisionID AND CompanyName = @CompanyName AND IndividualName = @IndividualName", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                .Add("@CompanyName", SqlDbType.VarChar).Value = RowTraineeCompany
                .Add("@IndividualName", SqlDbType.VarChar).Value = RowTraineeName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Certificate has been deleted.", MsgBoxStyle.OkOnly)

            LoadCertificatesForDivision()
        End If
    End Sub

    Private Sub cmdPrintMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintMultiple.Click
        If dgvStudweldingCertificate.RowCount <> 0 Then
            Dim RowCompanyName, RowTraineeName As String

            'Clear Batch Number for division
            cmd = New SqlCommand("UPDATE StudWeldingCertification SET BatchNumber = @BatchNumber WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Get New Batch Number
            Dim LastBatchNumber, NextBatchNumber As Integer

            Dim LastBatchNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
            Dim LastBatchNumberCommand As New SqlCommand(LastBatchNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBatchNumber = CInt(LastBatchNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastBatchNumber = 8675309
            End Try
            con.Close()

            NextBatchNumber = LastBatchNumber + 1

            'Assign Batch Number to selected items
            For Each row As DataGridViewRow In Me.dgvStudweldingCertificate.SelectedRows
                Try
                    RowTraineeName = row.Cells("IndividualNameColumn").Value
                Catch ex As Exception
                    RowTraineeName = ""
                End Try
                Try
                    RowCompanyName = row.Cells("CompanyNameColumn").Value
                Catch ex As Exception
                    RowCompanyName = ""
                End Try

                'Write Batch Number to Table
                cmd = New SqlCommand("UPDATE StudWeldingCertification SET BatchNumber = @BatchNumber WHERE CompanyName = @CompanyName AND IndividualName = @IndividualName AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@CompanyName", SqlDbType.VarChar).Value = RowCompanyName
                    .Add("@IndividualName", SqlDbType.VarChar).Value = RowTraineeName
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                RowCompanyName = ""
                RowTraineeName = ""
            Next

            'Print
            GlobalDivisionCode = cboDivisionID.Text
            GlobalStudweldingBatchNumber = NextBatchNumber
            GlobalStudweldingBatchPrinting = "YES"

            'Choose the correct Print Form (REMOTE or LOCAL)

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Using NewPrintStudweldingCerticateRemote As New PrintStudweldingCerticateRemote
                    Dim Result = NewPrintStudweldingCerticateRemote.ShowDialog()
                End Using
            Else
                Using NewPrintStudweldingCertification As New PrintStudweldingCerticate
                    Dim Result = NewPrintStudweldingCertification.ShowDialog()
                End Using
            End If
        End If
    End Sub
End Class