Imports System.IO

Public Class BlueprintSelection
    Private blueprint As String = ""
    Public SelectedPrint As String = ""
    Public HeaderFile As String = ""
    Public MachiningFile As String = ""
    Public FinishedFile As String = ""
    Public ToolingFile As String = ""
    Public AccessoriesFile As String = ""

    Public Sub New(ByVal bp As String)
        InitializeComponent()
        blueprint = bp

        HeaderFile = "\\TFP-FS\TransferData\BluePrint\Header\H" + blueprint + ".pdf"
        If Not File.Exists(HeaderFile) Then
            cmdHeader.Enabled = False
        End If
        MachiningFile = "\\TFP-FS\TransferData\BluePrint\Machining\M" + blueprint + ".pdf"
        If Not File.Exists(MachiningFile) Then
            cmdMachining.Enabled = False
        End If
        FinishedFile = "\\TFP-FS\TransferData\BluePrint\FinishedPart\F" + blueprint + ".pdf"
        If Not File.Exists(FinishedFile) Then
            cmdFinished.Enabled = False
        End If
        AccessoriesFile = "\\TFP-FS\TransferData\BluePrint\TWE Accessories\" + blueprint + ".pdf"
        If Not File.Exists(AccessoriesFile) Then
            cmdTWEAccessories.Enabled = False
        End If
        If Not String.IsNullOrEmpty(bp) Then
            Dim dirInfo As New DirectoryInfo("\\TFP-FS\TransferData\BluePrint\ToolLayout")
            If dirInfo.Exists() Then
                Dim files As FileInfo() = dirInfo.GetFiles("*" + blueprint + ".pdf", SearchOption.AllDirectories)
                If files.Count = 0 Then
                    cmdTooling.Enabled = False
                End If
            End If
        Else
            cmdTooling.Enabled = False
        End If

    End Sub

    Private Sub cmdHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHeader.Click
        SelectedPrint = "HEADER"
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdMachining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMachining.Click
        SelectedPrint = "MACHINING"
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdFinished_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinished.Click
        SelectedPrint = "FINISHED"
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdTWEAccessories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWEAccessories.Click
        SelectedPrint = "TWE Accessories"
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdTooling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTooling.Click

        Dim files As FileInfo() = (New DirectoryInfo("\\TFP-FS\TransferData\BluePrint\ToolLayout")).GetFiles("*" + blueprint + ".pdf", SearchOption.AllDirectories)
        If files.Count = 1 Then
            ToolingFile = files(0).FullName
            SelectedPrint = "TOOLING"
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        ElseIf files.Count > 0 Then
            Dim newSelectFile As New ViewBlueprintSelectToolingPrint(files)
            If newSelectFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ToolingFile = newSelectFile.SelectedFilePath
                SelectedPrint = "TOOLING"
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If

        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub BlueprintSelection_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = System.Windows.Forms.DialogResult.None Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub
End Class