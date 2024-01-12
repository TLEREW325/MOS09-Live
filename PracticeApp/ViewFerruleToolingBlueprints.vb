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
Public Class ViewFerruleToolingBlueprints
    Inherits System.Windows.Forms.Form

    Dim FolderPrefix As String = ""
    Dim BlueprintFilename As String = ""
    Dim BlueprintFilenameAndPath As String = ""
    Dim DirectoryLength As Integer = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dgvToolingFileViewer.DataSource = Nothing
        Me.dgvToolingFileViewer.RowCount = 0
    End Sub

    Private Sub cmdViewBlueprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewBlueprint.Click
        Dim DirectoryPrefix, RowFilename As String
        Dim BlueprintFileName, BlueprintFilenameAndPath As String

        If rdoDefaultFolder.Checked = True Then
            DirectoryPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\DEFAULT\"
        ElseIf rdoExtrusionTooling.Checked = True Then
            DirectoryPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\EXTRUSION TOOLING\"
        ElseIf rdoFStylePress.Checked = True Then
            DirectoryPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\F-STYLE PRESS\"
        ElseIf rdoRStylePress.Checked = True Then
            DirectoryPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\R-STYLE PRESS\"
        ElseIf rdoTStylePress.Checked = True Then
            DirectoryPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\T-STYLE PRESS\"
        ElseIf rdoEricoR.Checked = True Then
            DirectoryPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\ERICO-R\"
        Else
            'Do nothing
            Exit Sub
        End If

        If Me.dgvToolingFileViewer.RowCount > 0 Then

            Dim RowIndex As Integer = Me.dgvToolingFileViewer.CurrentCell.RowIndex

            RowFilename = Me.dgvToolingFileViewer.Rows(RowIndex).Cells("BPFilenameColumn").Value

            BlueprintFileName = RowFilename
            BlueprintFilenameAndPath = DirectoryPrefix + BlueprintFileName

            If File.Exists(BlueprintFilenameAndPath) Then
                System.Diagnostics.Process.Start(BlueprintFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdViewFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFiles.Click
        dgvToolingFileViewer.DataSource = Nothing
        Me.dgvToolingFileViewer.RowCount = 0

        If rdoDefaultFolder.Checked = True Then
            FolderPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\DEFAULT\"
            DirectoryLength = 56
        ElseIf rdoExtrusionTooling.Checked = True Then
            FolderPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\EXTRUSION TOOLING\"
            DirectoryLength = 66
        ElseIf rdoFStylePress.Checked = True Then
            FolderPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\F-STYLE PRESS\"
            DirectoryLength = 62
        ElseIf rdoRStylePress.Checked = True Then
            FolderPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\R-STYLE PRESS\"
            DirectoryLength = 62
        ElseIf rdoTStylePress.Checked = True Then
            FolderPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\T-STYLE PRESS\"
            DirectoryLength = 62
        ElseIf rdoEricoR.Checked = True Then
            FolderPrefix = "\\TFP-FS\TransferData\Blueprint\Ferrule Tooling\ERICO-R\"
            DirectoryLength = 56
        Else
            'Do nothing
            Exit Sub
        End If

        Dim BlueprintReportPath As String = FolderPrefix
        Dim BlueprintReportDir As DirectoryInfo
        Dim SearchPath As String = ""

        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim RawFilename As String = ""
        Dim DiscardedFileName As String = ""

        BlueprintReportDir = New DirectoryInfo(BlueprintReportPath)
        Dim files As List(Of FileInfo) = BlueprintReportDir.GetFiles(SearchPath + "*", SearchOption.AllDirectories).ToList()

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(DirectoryLength, FilenameLength - DirectoryLength)

            'Add line to datagrid
            Me.dgvToolingFileViewer.Rows.Add(Filename)
        Next
    End Sub
End Class