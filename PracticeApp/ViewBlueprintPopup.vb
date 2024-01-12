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
Public Class ViewBlueprintPopup
    Inherits System.Windows.Forms.Form

    Dim BlueprintFilename As String = ""
    Dim BlueprintFilenameAndPath As String = ""
    Dim BlueprintNumber As String = ""
    Dim PrintType As String = ""
    Dim PrintRoutine As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Private Sub ViewBlueprintPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBlueprintNumber()
    End Sub

    Public Sub LoadBlueprintNumber()
        cmd = New SqlCommand("SELECT DISTINCT (BlueprintNumber) FROM FOXTable WHERE DivisionID <> @DivisionID ORDER BY BlueprintNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTable")
        cboBlueprintNumber.DataSource = ds.Tables("FOXTable")
        con.Close()
        cboBlueprintNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadMultipleBlueprints()
        'Clear Datagrid first
        Me.dgvExtensions.RowCount = 0

        Dim BlueprintReportDir As DirectoryInfo
        Dim BlueprintSearchText As String = ""
        Dim BlueprintType As String = ""
        Dim FolderLength As Integer = 0
        Dim FolderType As String = ""
        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim BlueprintFilename As String = ""
        Dim RawFilename As String = ""
        Dim SearchPath As String = ""

        If rdoFinishedPrint.Checked = True Then
            PrintType = "F"
            FolderLength = 13
            FolderType = "FinishedPart\"
        ElseIf rdoHeadingPrint.Checked = True Then
            PrintType = "H"
            FolderLength = 7
            FolderType = "Header\"
        ElseIf rdoMachiningPrint.Checked = True Then
            PrintType = "M"
            FolderLength = 10
            FolderType = "Machining\"
        ElseIf rdoToolingPrint.Checked = True Then
            PrintType = "BP"
            FolderLength = 11
            FolderType = "ToolLayout\"
        ElseIf rdoTWEPrint.Checked = True Then
            PrintType = "TWE"
            FolderLength = 16
            FolderType = "TWE Accessories\"
        ElseIf rdoFerrulePrint.Checked = True Then
            PrintType = "FERRULE"
            FolderLength = 9
            FolderType = "Ferrules\"
        ElseIf rdoHeatTreatPrint.Checked = True Then
            PrintType = "HEATTREAT"
            FolderLength = 11
            FolderType = "Heat Treat\"
        Else
            PrintType = ""
            FolderLength = 0
            FolderType = ""
        End If

        'Define Directory Info
        Dim BlueprintReportPath As String = "\\TFP-FS\TransferData\BluePrint\" + FolderType
        BlueprintReportDir = New DirectoryInfo(BlueprintReportPath)

        If cboBlueprintNumber.Text <> "" Then
            BlueprintSearchText = PrintType + cboBlueprintNumber.Text
        Else
            BlueprintSearchText = ""
        End If

        SearchPath = BlueprintSearchText
        '***********************************************************************************************************

        Dim files As List(Of FileInfo) = BlueprintReportDir.GetFiles("*" + SearchPath + "*", SearchOption.AllDirectories).ToList()
        Dim Counter As Integer = 0

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(32 + FolderLength, FilenameLength - (32 + FolderLength))

            'Add line to datagrid
            Me.dgvExtensions.Rows.Add(Filename)

            Counter = Counter + 1
        Next

        If Counter > 1 Then
            Me.dgvExtensions.Visible = True
            cmdViewSelected.Visible = True
            PrintRoutine = "SELECT ONE"
        Else
            Me.dgvExtensions.Visible = False
            cmdViewSelected.Visible = False
            PrintRoutine = "PRINT ONE"
        End If
    End Sub

    Private Sub cmdViewBlueprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewBlueprint.Click
        LoadMultipleBlueprints()

        If PrintRoutine = "PRINT ONE" Then
            If rdoFinishedPrint.Checked = True Then
                PrintType = "FINISHED"
            ElseIf rdoHeadingPrint.Checked = True Then
                PrintType = "HEADING"
            ElseIf rdoMachiningPrint.Checked = True Then
                PrintType = "MACHINING"
            ElseIf rdoToolingPrint.Checked = True Then
                PrintType = "TOOLING"
            ElseIf rdoTWEPrint.Checked = True Then
                PrintType = "TWE"
            ElseIf rdoFerrulePrint.Checked = True Then
                PrintType = "FERRULE"
            ElseIf rdoHeatTreatPrint.Checked = True Then
                PrintType = "HEATTREAT"
            Else
                PrintType = ""
            End If

            If PrintType = "" Or cboBlueprintNumber.Text = "" Then
                MsgBox("Select a valid B/P # and print type.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Load Blueprint
            BlueprintNumber = cboBlueprintNumber.Text

            Select Case PrintType
                Case "FINISHED"
                    BlueprintFilename = "F" + BlueprintNumber + ".pdf"
                    BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\FinishedPart\" + BlueprintFilename
                Case "HEADING"
                    BlueprintFilename = "H" + BlueprintNumber + ".pdf"
                    BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\Header\" + BlueprintFilename
                Case "MACHINING"
                    BlueprintFilename = "M" + BlueprintNumber + ".pdf"
                    BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\Machining\" + BlueprintFilename
                Case "TOOLING"
                    BlueprintFilename = "BP" + BlueprintNumber + ".pdf"
                    BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\ToolLayout\" + BlueprintFilename
                Case "TWE"
                    BlueprintFilename = BlueprintNumber + ".pdf"
                    BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\TWE Accessories\" + BlueprintFilename
                Case "FERRULE"
                    BlueprintFilename = BlueprintNumber + ".pdf"
                    BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\Ferrules\" + BlueprintFilename
                Case "HEATTREAT"
                    BlueprintFilename = "HT" + BlueprintNumber + ".pdf"
                    BlueprintFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\Heat Treat\" + BlueprintFilename

                Case Else
                    BlueprintFilenameAndPath = ""
                    MsgBox("Select a valid B/P # and print type.", MsgBoxStyle.OkOnly)
                    Exit Sub
            End Select

            If File.Exists(BlueprintFilenameAndPath) Then
                System.Diagnostics.Process.Start(BlueprintFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("Select Blueprint from the datagrid and press continue.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSelected.Click
        If Me.dgvExtensions.RowCount > 0 Then
            Dim RowFilename, FolderName As String
            Dim BPFileName, BPFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvExtensions.CurrentCell.RowIndex

            RowFilename = Me.dgvExtensions.Rows(RowIndex).Cells("FilenameColumn").Value

            BPFileName = RowFilename

            'Get Folder
            If rdoFinishedPrint.Checked = True Then
                FolderName = "FinishedPart\"
            ElseIf rdoHeadingPrint.Checked = True Then
                FolderName = "Header\"
            ElseIf rdoMachiningPrint.Checked = True Then
                FolderName = "Machining\"
            ElseIf rdoToolingPrint.Checked = True Then
                FolderName = "ToolLayout\"
            ElseIf rdoTWEPrint.Checked = True Then
                FolderName = "TWE Accessories\"
            ElseIf rdoFerrulePrint.Checked = True Then
                FolderName = "Ferrules\"
            ElseIf rdoHeatTreatPrint.Checked = True Then
                FolderName = "Heat Treat\"
            Else
                FolderName = ""
            End If

            BPFilenameAndPath = "\\TFP-FS\TransferData\BluePrint\" + FolderName + BPFileName

            If File.Exists(BPFilenameAndPath) Then
                System.Diagnostics.Process.Start(BPFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If

            cmdViewSelected.Visible = False
            Me.dgvExtensions.Visible = False
        End If
    End Sub
End Class