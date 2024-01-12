Imports System.IO
Imports System.Data.SqlClient

Public Class UploadSDS
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim fle As String
    Dim chooseFile As New System.Windows.Forms.OpenFileDialog
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        cboName.DisplayMember = "Name"
        cboName.DataSource = ds.Tables("SafetyDataSheets")
        cboName.SelectedIndex = -1
    End Sub

    Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
        chooseFile.Multiselect = False
        chooseFile.ShowDialog()
        fle = chooseFile.FileName
        lblFile.Text = fle.Substring(fle.LastIndexOf("\") + 1, fle.Length - fle.LastIndexOf("\") - 1)
    End Sub

    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        If canUpload() Then
            'Setup data connection and variables
            cmd = New SqlCommand("", con)
            If cboName.SelectedIndex = -1 Then
                cmd.CommandText = "INSERT INTO SafetyDataSheets (Name, FileName, RevisionNumber, LastRevised) VALUES (@Name, @FileName, 0, @LastRevised);"
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                cmd.CommandText = "UPDATE SafetyDataSheets SET FileName = @FileName, RevisionNumber = (RevisionNumber + 1), LastRevised = @LastRevised WHERE Name = @Name;"
                Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            End If
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = cboName.Text
            cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = fle.Substring(fle.LastIndexOf("\"), fle.Length - fle.LastIndexOf("\"))
            cmd.Parameters.Add("@LastRevised", SqlDbType.Date).Value = Today.Date

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Try
                File.Copy(fle, "\\TFP-FS\TransferData\Safety Data Sheets" + fle.Substring(fle.LastIndexOf("\"), fle.Length - fle.LastIndexOf("\")), True)
            Catch ex As System.Exception
                MessageBox.Show("There was an error trying to copy the file. " + ex.ToString(), "Unable to copy", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Function canUpload() As Boolean
        If String.IsNullOrEmpty(cboName.Text) Then
            MessageBox.Show("You must enter a Name", "Enter a name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboName.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(chooseFile.FileName) Then
            MessageBox.Show("You must select a file to upload", "Select a file", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmdSelectFile.Focus()
            Return False
        End If
        cmd = New SqlCommand("IF ((SELECT COUNT(Name) FROM SafetyDataSheets WHERE FileName like @FileName) <> 0) (SELECT Name FROM SafetyDataSheets WHERE FileName like @FileName) else SELECT 'NONE';", con)
        cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = "%" + fle.Substring(fle.LastIndexOf("\"), fle.Length - fle.LastIndexOf("\"))

        If con.State = ConnectionState.Closed Then con.Open()
        Dim SDSName As String = cmd.ExecuteScalar()
        ''check to make sure we are not overwriting an existing SDS that is not the same as the SDS we are uploading
        If Not SDSName.Equals("NONE") Then
            If Not SDSName.Equals(cboName.Text) Then
                con.Close()
                MessageBox.Show("File name is already in use by " + SDSName + ". You need to check SDS to make sure it is named correctly.", "Unable to upload", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        Me.Dispose()
    End Sub
End Class