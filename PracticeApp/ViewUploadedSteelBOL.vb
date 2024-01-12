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
Public Class ViewUploadedSteelBOL
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Private Sub ViewUploadedSteelBOL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub cmdViewFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFiles.Click
        'Clear Datagrid first
        Me.dgvSteelBOLS.RowCount = 0

        Dim SteelBOLPath As String = "\\TFP-SQL\TransferData\Charter Steel BOLs\"
        Dim SteelBOLDir As DirectoryInfo

        Dim HeatNumberSearchPath As String = ""

        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim HeatFilename As String = ""
        Dim BOLFilename As String = ""

        SteelBOLDir = New DirectoryInfo(SteelBOLPath)

        If cboHeatNumber.Text <> "" Then
            HeatNumberSearchPath = cboHeatNumber.Text
        Else
            HeatNumberSearchPath = ""
        End If
        '***********************************************************************************************************

        Dim files As List(Of FileInfo) = SteelBOLDir.GetFiles(HeatNumberSearchPath + "*", SearchOption.AllDirectories).ToList()

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(42, FilenameLength - 42)

            'Add line to datagrid
            Me.dgvSteelBOLS.Rows.Add(Filename)
        Next
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboHeatNumber.Text = ""
        cboHeatNumber.SelectedIndex = -1
        Me.dgvSteelBOLS.RowCount = 0
    End Sub

    Private Sub cmdLoadBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadBOL.Click
        If Me.dgvSteelBOLS.RowCount > 0 Then
            Dim RowFilename As String
            Dim BOLFileName, BOLFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvSteelBOLS.CurrentCell.RowIndex

            RowFilename = Me.dgvSteelBOLS.Rows(RowIndex).Cells("HeatColumn").Value

            BOLFileName = RowFilename
            BOLFilenameAndPath = "\\TFP-SQL\TransferData\Charter Steel BOLs\" + BOLFileName

            If File.Exists(BOLFilenameAndPath) Then
                System.Diagnostics.Process.Start(BOLFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub dgvSteelBOLS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelBOLS.CellDoubleClick
        If Me.dgvSteelBOLS.RowCount > 0 Then
            Dim RowFilename As String
            Dim BOLFileName, BOLFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvSteelBOLS.CurrentCell.RowIndex

            RowFilename = Me.dgvSteelBOLS.Rows(RowIndex).Cells("HeatColumn").Value

            BOLFileName = RowFilename
            BOLFilenameAndPath = "\\TFP-SQL\TransferData\Charter Steel BOLs\" + BOLFileName

            If File.Exists(BOLFilenameAndPath) Then
                System.Diagnostics.Process.Start(BOLFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
End Class