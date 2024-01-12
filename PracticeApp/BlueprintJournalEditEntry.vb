Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class BlueprintJournalEditEntry
    Dim BlueprintNumber As String = ""
    Dim EntryKey As Integer = 0
    Private Const BlueprintJournalRootFolder As String = "\\TFP-FS\TransferData\Blueprint Journal"

    Dim fileSelect As New OpenFileDialog()

    Dim isLoaded As Boolean = False
    Private Class FileData
        Public FileNames As List(Of String)
        Public EntryKey As Integer
        Public Sub New(ByVal fleNames As String(), ByVal Entry As Integer)
            FileNames = fleNames.ToList()
            EntryKey = Entry
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
        fileSelect.Multiselect = True
        fileSelect.Filter = "Image Files (*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png)|*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png"
        fileSelect.FilterIndex = 1
        isLoaded = True
    End Sub

    Public Sub New(ByVal key As Integer, ByVal bp As String)
        InitializeComponent()
        BlueprintNumber = bp
        EntryKey = key
        fileSelect.Multiselect = True
        fileSelect.Filter = "Image Files (*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png)|*.bmp;*.jpg;*.gif*.jpeg;*.tiff;*.png"
        fileSelect.FilterIndex = 1

        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT EntryTitle, EntryDetails FROM BlueprintJournal WHERE EntryKey = @EntryKey;", con)
        cmd.Parameters.Add("@EntryKey", SqlDbType.Int).Value = EntryKey

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("EntryTitle")) Then
                txtTitle.Text = reader.Item("EntryTitle")
            End If
            If Not IsDBNull(reader.Item("EntryDetails")) Then
                txtDetails.Text = reader.Item("EntryDetails")
            End If
        End If
        reader.Close()
        If con.State = ConnectionState.Open Then con.Close()

        Dim dir As New System.IO.DirectoryInfo(BlueprintJournalRootFolder)

        Dim bpDir() As System.IO.DirectoryInfo = dir.GetDirectories(BlueprintNumber, IO.SearchOption.TopDirectoryOnly)
        If bpDir.Count > 0 Then
            Dim entryDir() As System.IO.DirectoryInfo = bpDir(0).GetDirectories(EntryKey, IO.SearchOption.TopDirectoryOnly)
            If entryDir.Count > 0 Then
                Dim foundFileInfo As New List(Of System.IO.FileInfo)
                foundFileInfo.AddRange(entryDir(0).GetFiles("*.jpg"))
                foundFileInfo.AddRange(entryDir(0).GetFiles("*.bmp"))
                foundFileInfo.AddRange(entryDir(0).GetFiles("*.gif"))
                foundFileInfo.AddRange(entryDir(0).GetFiles("*.jpeg"))
                foundFileInfo.AddRange(entryDir(0).GetFiles("*.png"))
                foundFileInfo.AddRange(entryDir(0).GetFiles("*.tiff"))
                foundFileInfo.Sort(Function(x As System.IO.FileInfo, y As System.IO.FileInfo) x.LastWriteTime < y.LastWriteTime)

                For Each fle As System.IO.FileInfo In foundFileInfo
                    lstCurrentPictures.Items.Add(fle.FullName.Substring(fle.FullName.LastIndexOf("\") + 1))
                Next
            End If
        End If
        isLoaded = True
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If CanEditEntry() Then
            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
            Dim cmd As New SqlCommand("UPDATE BlueprintJournal SET EntryTitle = @EntryTitle, EntryDetails = @EntryDetails, LastUpdated = @LastUpdated WHERE EntryKey = @EntryKey;", con)
            cmd.Parameters.Add("@EntryTitle", SqlDbType.VarChar).Value = txtTitle.Text
            cmd.Parameters.Add("@EntryDetails", SqlDbType.VarChar).Value = txtDetails.Text
            cmd.Parameters.Add("@LastUpdated", SqlDbType.DateTime2).Value = Now
            cmd.Parameters.Add("@EntryKey", SqlDbType.Int).Value = EntryKey


            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            If lstPictureFiles.Items.Count > 0 Then
                ''check to make sure the blueprint journal directory exists if it doesn't this wil lcreate it
                If Not System.IO.Directory.Exists(BlueprintJournalRootFolder) Then
                    System.IO.Directory.CreateDirectory(BlueprintJournalRootFolder)
                End If
                ''chekc to see if the directory for the blueprint exists, if not will create
                If Not System.IO.Directory.Exists(BlueprintJournalRootFolder + "\" + BlueprintNumber) Then
                    System.IO.Directory.CreateDirectory(BlueprintJournalRootFolder + "\" + BlueprintNumber)
                End If
                ''check to see if the directory or the title exists, if not will create
                If Not System.IO.Directory.Exists(BlueprintJournalRootFolder + "\" + BlueprintNumber + "\" + EntryKey.ToString()) Then
                    System.IO.Directory.CreateDirectory(BlueprintJournalRootFolder + "\" + BlueprintNumber + "\" + EntryKey.ToString())
                End If
                bgwkCopyImage.RunWorkerAsync(New FileData(fileSelect.FileNames, EntryKey))
                lblImageCount.Text = "1"
                lblTotalCount.Text = "of " + fileSelect.FileNames.Count.ToString()
                pnlImageCopy.Show()
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Hide()
            End If
        End If
    End Sub

    Private Function CanEditEntry() As Boolean
        If String.IsNullOrEmpty(txtDetails.Text) Then
            MessageBox.Show("You must enter details", "Enter details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub


    Private Sub cmdSelectPictures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectPictures.Click
        If fileSelect.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            lstPictureFiles.Items.Clear()
            For Each fle As String In fileSelect.FileNames
                lstPictureFiles.Items.Add(fle.Substring(fle.LastIndexOf("\") + 1))
            Next
        End If
    End Sub

    Private Sub cmdDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelected.Click
        If lstCurrentPictures.SelectedIndex <> -1 Then
            If MessageBox.Show("Are you sure you want to delete this picture?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    System.IO.File.Delete(BlueprintJournalRootFolder + "\" + BlueprintNumber + "\" + EntryKey.ToString() + "\" + lstCurrentPictures.Text)
                    lstCurrentPictures.Items.RemoveAt(lstCurrentPictures.SelectedIndex)
                Catch ex As System.Exception
                    MessageBox.Show("There was an issue deleting the image", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        Else
            MessageBox.Show("You must select an image to delete", "Select an image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub bgwkCopyImage_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCopyImage.DoWork
        If e.Argument IsNot Nothing Then
            Dim fleData As FileData = DirectCast(e.Argument, FileData)
            'check to see if the file already exists, if it does will ask the user if they want to overwrite.
            If System.IO.File.Exists(BlueprintJournalRootFolder + "\" + BlueprintNumber + "\" + fleData.EntryKey.ToString() + "\" + fleData.FileNames(0).Substring(fleData.FileNames(0).LastIndexOf("\") + 1)) Then
                If MessageBox.Show("File " + fleData.FileNames(0).Substring(fleData.FileNames(0).LastIndexOf("\") + 1) + " exists, do you wish to overwrite it?", "Overwrite existing file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                    System.IO.File.Copy(fleData.FileNames(0), BlueprintJournalRootFolder + "\" + BlueprintNumber + "\" + fleData.EntryKey.ToString() + "\" + fleData.FileNames(0).Substring(fleData.FileNames(0).LastIndexOf("\") + 1), True)
                End If
            Else
                System.IO.File.Copy(fleData.FileNames(0), BlueprintJournalRootFolder + "\" + BlueprintNumber + "\" + fleData.EntryKey.ToString() + "\" + fleData.FileNames(0).Substring(fleData.FileNames(0).LastIndexOf("\") + 1))
            End If
            e.Result = fleData
        End If
    End Sub

    Private Sub bgwkCopyImage_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkCopyImage.RunWorkerCompleted
        If e.Result IsNot Nothing Then
            Dim tmp As FileData = DirectCast(e.Result, FileData)
            tmp.FileNames.RemoveAt(0)
            If tmp.FileNames.Count > 0 Then
                bgwkCopyImage.RunWorkerAsync(tmp)
                lblImageCount.Text = Val(lblImageCount.Text) + 1
            Else
                pnlImageCopy.Hide()
            End If
        Else
            pnlImageCopy.Hide()
        End If
    End Sub

    Private Sub pnlImageCopy_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlImageCopy.VisibleChanged
        If isLoaded Then
            If pnlImageCopy.Visible Then
                tmrCopyMessageChange.Start()
                cmdSelectPictures.Enabled = False
                cmdAdd.Enabled = False
                cmdCancel.Enabled = False
                cmdDeleteSelected.Enabled = False
                lstCurrentPictures.Enabled = False
                txtDetails.Enabled = False
                txtTitle.Enabled = False
            Else
                tmrCopyMessageChange.Stop()
                lblCopyMessage.Text = "Copying image please wait"
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub tmrCopyMessageChange_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCopyMessageChange.Tick
        Select Case lblCopyMessage.Text
            Case "Copying image please wait"
                lblCopyMessage.Text = "Copying image please wait."
            Case "Copying image please wait."
                lblCopyMessage.Text = "Copying image please wait.."
            Case "Copying image please wait.."
                lblCopyMessage.Text = "Copying image please wait..."
            Case "Copying image please wait..."
                lblCopyMessage.Text = "Copying image please wait"
        End Select
    End Sub
End Class