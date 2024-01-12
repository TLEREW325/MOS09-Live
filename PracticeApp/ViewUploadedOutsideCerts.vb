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
Public Class ViewUploadedOutsideCerts
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Private Sub ViewUploadedOutsideCerts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLotNumber()
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE Status = @Status ORDER BY LotNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "LotNumber")
        cboLotNumber.DataSource = ds.Tables("LotNumber")
        con.Close()
        cboLotNumber.SelectedIndex = -1
    End Sub

    Private Sub cmdViewFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFiles.Click
        'Clear Datagrid first
        Me.dgvViewCerts.RowCount = 0

        Dim VendorCertPath As String = "\\TFP-FS\TransferData\Uploaded Outside Certifications\"
        Dim VendorCertDir As DirectoryInfo

        Dim LotNumberSearchPath As String = ""

        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim HeatFilename As String = ""
        Dim BOLFilename As String = ""

        VendorCertDir = New DirectoryInfo(VendorCertPath)

        If cboLotNumber.Text <> "" Then
            LotNumberSearchPath = cboLotNumber.Text
        Else
            LotNumberSearchPath = ""
        End If
        '***********************************************************************************************************

        Dim files As List(Of FileInfo) = VendorCertDir.GetFiles(LotNumberSearchPath + "*", SearchOption.AllDirectories).ToList()

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(54, FilenameLength - 54)

            'Add line to datagrid
            Me.dgvViewCerts.Rows.Add(Filename)
        Next
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboLotNumber.Text = ""
        cboLotNumber.SelectedIndex = -1
        Me.dgvViewCerts.RowCount = 0
    End Sub

    Private Sub cmdLoadCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadCert.Click
        If Me.dgvViewCerts.RowCount > 0 Then
            Dim RowFilename As String
            Dim CertFileName, CertFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvViewCerts.CurrentCell.RowIndex

            RowFilename = Me.dgvViewCerts.Rows(RowIndex).Cells("FilenameColumn").Value

            CertFileName = RowFilename
            CertFilenameAndPath = "\\TFP-FS\TransferData\Uploaded Outside Certifications\" + CertFileName

            If File.Exists(CertFilenameAndPath) Then
                System.Diagnostics.Process.Start(CertFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub dgvViewCerts_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvViewCerts.CellDoubleClick
        If Me.dgvViewCerts.RowCount > 0 Then
            Dim RowFilename As String
            Dim CertFileName, CertFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvViewCerts.CurrentCell.RowIndex

            RowFilename = Me.dgvViewCerts.Rows(RowIndex).Cells("FilenameColumn").Value

            CertFileName = RowFilename
            CertFilenameAndPath = "\\TFP-FS\TransferData\Uploaded Outside Certifications\" + CertFileName

            If File.Exists(CertFilenameAndPath) Then
                System.Diagnostics.Process.Start(CertFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdUploadCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadCert.Click
        If cboLotNumber.Text = "" Then
            MsgBox("You must have a valid Lot #.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim LotNumber As String = ""
            Dim OutsideCertFileName As String = ""
            Dim OutsideCertFilenameAndPath As String = ""
            Dim TempFilename As String = ""

            LotNumber = cboLotNumber.Text

            OutsideCertFileName = LotNumber + ".pdf"
            OutsideCertFilenameAndPath = "\\TFP-FS\TransferData\Uploaded Outside Certifications\" + OutsideCertFileName

            'Open Dialog Box
            Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            ofdUploadCert.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

            'Open File Dialog Box
            If ofdUploadCert.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Get filename from dialog box
            TempFilename = ofdUploadCert.FileName

            If TempFilename = "" Then
                Exit Sub
            End If

            'If Filename exists, delete the old file and copy over a new file
            If File.Exists(OutsideCertFilenameAndPath) Then
                File.Delete(OutsideCertFilenameAndPath)
            Else
                'Continue
            End If

            Try
                'Rename file
                File.Copy(TempFilename, OutsideCertFilenameAndPath)
                MsgBox("Vendor Cert Uploaded", MsgBoxStyle.OkOnly)

                LotNumber = ""
                OutsideCertFileName = ""
                OutsideCertFilenameAndPath = ""
                TempFilename = ""

                cboLotNumber.SelectedIndex = -1

                cboLotNumber.Focus()
            Catch ex As Exception
                'Rename(File)
                MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
                Exit Sub
            End Try
        End If
    End Sub
End Class