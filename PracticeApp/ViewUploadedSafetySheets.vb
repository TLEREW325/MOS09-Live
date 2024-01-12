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
Public Class ViewUploadedSafetySheets
    Inherits System.Windows.Forms.Form

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

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim FileName As String = ""
        Dim FileNameAndPath As String = ""

        If rdoCarbonSteel.Checked = True Then
            FileName = "TWD0010rev1.pdf"
            FileNameAndPath = "\\TFP-FS\TransferData\Safety Data Sheets\" + FileName

            If File.Exists(FileNameAndPath) Then
                System.Diagnostics.Process.Start(FileNameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        ElseIf rdoStainlessSteel.Checked = True Then
            FileName = "TWD0013.pdf"
            FileNameAndPath = "\\TFP-FS\TransferData\Safety Data Sheets\" + FileName

            If File.Exists(FileNameAndPath) Then
                System.Diagnostics.Process.Start(FileNameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        ElseIf rdoNickel.Checked = True Then
            FileName = "TWD0014.pdf"
            FileNameAndPath = "\\TFP-FS\TransferData\Safety Data Sheets\" + FileName

            If File.Exists(FileNameAndPath) Then
                System.Diagnostics.Process.Start(FileNameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        ElseIf rdoFerrules.Checked = True Then
            FileName = "TWD0011.pdf"
            FileNameAndPath = "\\TFP-FS\TransferData\Safety Data Sheets\" + FileName

            If File.Exists(FileNameAndPath) Then
                System.Diagnostics.Process.Start(FileNameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        ElseIf rdoWeldTiles.Checked = True Then
            FileName = "TWD0012.pdf"
            FileNameAndPath = "\\TFP-FS\TransferData\Safety Data Sheets\" + FileName

            If File.Exists(FileNameAndPath) Then
                System.Diagnostics.Process.Start(FileNameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            'Do nothing
        End If
    End Sub
End Class