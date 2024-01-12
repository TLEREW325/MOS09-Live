Public Class ViewPDFFiles
    Private lstFiles As New List(Of String)
    Private index As Integer = 0
    Public Sub New(ByVal file As String)
        InitializeComponent()

        lstFiles.Add(file)
        cmdPrevious.Enabled = False
        cmdNext.Enabled = False
        bsrFile.Navigate(lstFiles(0))
    End Sub

    Public Sub New(ByVal files As String())
        InitializeComponent()

        lstFiles.AddRange(files)
        If lstFiles.Count <= 1 Then
            cmdNext.Enabled = False
        End If
        bsrFile.Navigate(lstFiles(0))
    End Sub

    Public Sub New(ByVal files As List(Of String))
        InitializeComponent()

        lstFiles = files
        If lstFiles.Count <= 1 Then
            cmdNext.Enabled = False
        End If
        bsrFile.Navigate(lstFiles(0))
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        index += 1
        If index = lstFiles.Count - 1 Then
            cmdNext.Enabled = False
        End If
        cmdPrevious.Enabled = True
        bsrFile.Navigate(lstFiles(index))
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        index -= 1
        If index = 0 Then
            cmdPrevious.Enabled = False
        End If
        cmdNext.Enabled = False
        bsrFile.Navigate(lstFiles(index))
    End Sub

    Private Sub ViewPDFFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class