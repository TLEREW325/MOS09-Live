Imports System.IO
Public Class ViewGaugeSignouts
    Dim GaugeSheetDir As DirectoryInfo

    Public Sub New()
        InitializeComponent()

        LoadGaugeSheets()
    End Sub

    Private Sub LoadGaugeSheets()
        GaugeSheetDir = New DirectoryInfo("\\\\TFP-FS\\TransferData\\GaugeSignouts")
        If Not GaugeSheetDir.Exists() Then
            Directory.CreateDirectory("\\\\TFP-FS\\TransferData\\GaugeSignouts")
        End If
        Dim files As FileInfo() = GaugeSheetDir.GetFiles("*.pdf")

        If files.Length > 0 Then
            files = files.OrderBy(Function(x) x.Name).ToArray()
            If lstbxGaugeSignouts.DataSource Is Nothing Then lstbxGaugeSignouts.Items.Clear()
            lstbxGaugeSignouts.DataSource = files

            ''lstbxGaugeSignouts.Items.AddRange(files)
            If lstbxGaugeSignouts.DisplayMember Is Nothing Then lstbxGaugeSignouts.DisplayMember = "Name"
        Else
            If lstbxGaugeSignouts.DataSource Is Nothing Then
                lstbxGaugeSignouts.Items.Clear()
            Else
                lstbxGaugeSignouts.DataSource = Nothing
            End If

            lstbxGaugeSignouts.Items.Add("No files found")
        End If
    End Sub

    Private Sub UploadSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadSheetToolStripMenuItem.Click
        Dim fileDialog As New OpenFileDialog
        ''makes the file dialog box open to the directory currently used
        If Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)") Then
            fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)"
        ElseIf Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples") Then
            fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples"
        End If
        ''will restore to the initial directory
        fileDialog.RestoreDirectory = True
        fileDialog.DefaultExt = "PDF Files(*.pdf)"
        If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fn As String = "\\\\TFP-FS\\TransferData\\GaugeSignouts\\" + DateTime.Now.ToShortDateString().Replace("/", "-")

            If File.Exists(fn + ".pdf") Then
                Dim i As Integer = 0
                While File.Exists(fn + i.ToString + ".pdf")
                    i += 1
                End While
                File.Copy(fileDialog.FileName, fn + i.ToString + ".pdf")

            Else
                File.Copy(fileDialog.FileName, fn + ".pdf")
            End If
            LoadGaugeSheets()
        End If
    End Sub

    Private Sub lstbxGaugeSignouts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbxGaugeSignouts.SelectedIndexChanged
        If lstbxGaugeSignouts.SelectedIndex >= 0 AndAlso TryCast(lstbxGaugeSignouts.SelectedValue, FileInfo) IsNot Nothing Then
            bsrGaugeSignout.Navigate(CType(lstbxGaugeSignouts.SelectedItem, FileInfo).FullName)
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        bsrGaugeSignout.Print()
    End Sub

    Private Sub ViewGaugeSignouts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class