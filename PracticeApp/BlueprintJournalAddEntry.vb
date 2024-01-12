Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class BlueprintJournalAddEntry
    Dim BlueprintNumber As String = ""
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

    Public Sub New(ByVal bp As String)
        InitializeComponent()
        BlueprintNumber = bp
        fileSelect.Multiselect = True
        fileSelect.Filter = "Image Files (*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png)|*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png"
        fileSelect.FilterIndex = 1
        isLoaded = True
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If CanAddEntry() Then
            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
            Dim cmd As New SqlCommand("DECLARE @EntryKey as int = (SELECT isnull(MAX(EntryKey) + 1, 1) FROM BlueprintJournal); INSERT INTO BlueprintJournal (EntryKey, BlueprintNumber, EntryTitle, EntryDetails, EntryDate, LastUpdated) VALUES (@EntryKey,@BlueprintNumber, @EntryTitle, @EntryDetails, @EntryDate, @EntryDate); Select @EntryKey;", con)

            cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = BlueprintNumber
            cmd.Parameters.Add("@EntryTitle", SqlDbType.VarChar).Value = txtTitle.Text
            cmd.Parameters.Add("@EntryDetails", SqlDbType.VarChar).Value = txtDetails.Text
            cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime2).Value = Now


            If con.State = ConnectionState.Closed Then con.Open()
            Dim EntryKey As Integer = cmd.ExecuteScalar()
            con.Close()

            If lstPictureFiles.Items.Count > 0 Then
                ''check to make sure the blueprint journal directory exists if it doesn't this will create it
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

    Private Function CanAddEntry() As Boolean
        If String.IsNullOrEmpty(txtTitle.Text) Then
            MessageBox.Show("You must enter a title", "Enter a title", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
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