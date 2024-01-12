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
Public Class ViewUploadedSteelInspections
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Private Sub ViewUploadedSteelInspections_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadHeatNumber()
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT (HeatNumber) FROM HeatNumberLog WHERE Status = @Status ORDER BY HeatNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "HeatNumberLog")
        cboHeatNumber.DataSource = ds.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboHeatNumber.Text = ""
        cboHeatNumber.SelectedIndex = -1
        Me.dgvSteelReceiving.RowCount = 0
    End Sub

    Private Sub cmdViewFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFiles.Click
        'Clear Datagrid first
        Me.dgvSteelReceiving.RowCount = 0

        Dim SteelRECPath As String = "\\TFP-FS\TransferData\Steel Receiving Inspection\"
        Dim SteelRECDir As DirectoryInfo

        Dim HeatNumberSearchPath As String = ""

        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim HeatFilename As String = ""
        Dim BOLFilename As String = ""

        SteelRECDir = New DirectoryInfo(SteelRECPath)

        If cboHeatNumber.Text <> "" Then
            HeatNumberSearchPath = cboHeatNumber.Text
        Else
            HeatNumberSearchPath = ""
        End If
        '***********************************************************************************************************

        Dim files As List(Of FileInfo) = SteelRECDir.GetFiles("*" + HeatNumberSearchPath + "*", SearchOption.AllDirectories).ToList()

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(49, FilenameLength - 49)

            'Add line to datagrid
            Me.dgvSteelReceiving.Rows.Add(Filename)
        Next
    End Sub

    Private Sub cmdLoadRecInspection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadRecInspection.Click
        If Me.dgvSteelReceiving.RowCount > 0 Then
            Dim RowFilename As String
            Dim RECFileName, RECFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvSteelReceiving.CurrentCell.RowIndex

            RowFilename = Me.dgvSteelReceiving.Rows(RowIndex).Cells("HeatColumn").Value

            RECFileName = RowFilename
            RECFilenameAndPath = "\\TFP-FS\TransferData\Steel Receiving Inspection\" + RECFileName

            If File.Exists(RECFilenameAndPath) Then
                System.Diagnostics.Process.Start(RECFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub dgvSteelReceiving_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelReceiving.CellDoubleClick
        If Me.dgvSteelReceiving.RowCount > 0 Then
            Dim RowFilename As String
            Dim RECFileName, RECFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvSteelReceiving.CurrentCell.RowIndex

            RowFilename = Me.dgvSteelReceiving.Rows(RowIndex).Cells("HeatColumn").Value

            RECFileName = RowFilename
            RECFilenameAndPath = "\\TFP-FS\TransferData\Steel Receiving Inspection\" + RECFileName

            If File.Exists(RECFilenameAndPath) Then
                System.Diagnostics.Process.Start(RECFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdUploadInspection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadInspection.Click
        If cboHeatNumber.Text = "" Then
            MsgBox("You must have a valid Heat #.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim HeatNumber As String = ""
            Dim HeatFileNumber As Integer = 0
            Dim strHeatFileNumber As String = ""
            Dim TodaysDate As Date = Now()
            Dim strTodaysDate As String = ""
            Dim SteelInspectionFileName As String = ""
            Dim SteelInspectionFilenameAndPath As String = ""
            Dim TempFilename As String = ""

            HeatNumber = cboHeatNumber.Text

            'Get Last Heat File Number
            Dim GetHeatFileNumberStatement As String = "SELECT MAX(HeatFileNumber) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber"
            Dim GetHeatFileNumberCommand As New SqlCommand(GetHeatFileNumberStatement, con)
            GetHeatFileNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                HeatFileNumber = CInt(GetHeatFileNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                HeatFileNumber = 0
            End Try
            con.Close()

            If HeatFileNumber <> 0 Then
                strHeatFileNumber = CStr(HeatFileNumber)
            Else
                strHeatFileNumber = "111111"
            End If

            'Format Date
            strTodaysDate = TodaysDate.ToShortDateString()
            strTodaysDate = strTodaysDate.Replace("/", "-")

            If TodaysDate.Month < 10 Then
                strTodaysDate = "0" + strTodaysDate
            End If

            SteelInspectionFileName = strHeatFileNumber + " " + HeatNumber + " " + strTodaysDate + ".pdf"
            SteelInspectionFilenameAndPath = "\\TFP-FS\TransferData\Steel Receiving Inspection\" + SteelInspectionFileName

            'Open Dialog Box
            Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            ofdSteelInspection.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

            'Open File Dialog Box
            If ofdSteelInspection.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Get filename from dialog box
            TempFilename = ofdSteelInspection.FileName

            If TempFilename = "" Then
                Exit Sub
            End If

            'If Filename exists, delete the old file and copy over a new file
            If File.Exists(SteelInspectionFilenameAndPath) Then
                File.Delete(SteelInspectionFilenameAndPath)
            Else
                'Continue
            End If

            Try
                'Rename file
                File.Copy(TempFilename, SteelInspectionFilenameAndPath)
                MsgBox("Steel Inspection Uploaded", MsgBoxStyle.OkOnly)

                HeatNumber = ""
                SteelInspectionFileName = ""
                SteelInspectionFilenameAndPath = ""
                TempFilename = ""

                cboHeatNumber.SelectedIndex = -1

                cboHeatNumber.Focus()
            Catch ex As Exception
                'Rename(File)
                MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
                Exit Sub
            End Try
        End If
    End Sub
End Class