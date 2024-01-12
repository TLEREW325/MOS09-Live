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
Public Class ViewMillCertPopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet
 
    Dim VendorDirectory As String = ""

    Private Sub ViewMillCertPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSteelVendor()
        LoadHeatNumber()
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT (HeatNumber) FROM HeatNumberLog WHERE Status = @Status ORDER BY HeatNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "HeatNumberLog")
        cboHeatNumber.DataSource = ds.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE VendorClass = @VendorClass AND DivisionID = @DivisionID ORDER BY VendorCode", con)
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboSteelVendor.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Public Sub GetSteelDiamaterForHeat()
        Dim GetSteelSize As String = ""
        Dim CountSteelSize As Integer = 0

        Dim CountSteelSizeStatement As String = "SELECT COUNT(SteelSize) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND Status = @Status"
        Dim CountSteelSizeCommand As New SqlCommand(CountSteelSizeStatement, con)
        CountSteelSizeCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        CountSteelSizeCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountSteelSize = CInt(CountSteelSizeCommand.ExecuteScalar)
        Catch ex As System.Exception
            CountSteelSize = 0
        End Try
        con.Close()

        If CountSteelSize = 1 Then
            Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND Status = @Status"
            Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
            GetSteelSizeCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            GetSteelSizeCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetSteelSize = ""
            End Try
            con.Close()

            txtSteelDiameter.Text = GetSteelSize
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Me.dgvMillCerts.RowCount = 0

        cboHeatNumber.Text = ""
        cboSteelVendor.Text = ""
        txtSteelDiameter.Clear()
        cboHeatNumber.SelectedIndex = -1
        cboSteelVendor.SelectedIndex = -1

        cboSteelVendor.Focus()
    End Sub

    Private Sub cmdUploadMillCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadMillCert.Click
        If cboSteelVendor.Text = "" Or cboHeatNumber.Text = "" Or txtSteelDiameter.Text = "" Then
            MsgBox("Before uploading, you must enter a vendor, steel size, and heat #.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Verify Customer and Lot Number
            Dim CheckVendorID As Integer = 0
            Dim CheckHeatNumber As Integer = 0

            Dim CheckVendorIDStatement As String = "SELECT COUNT(VendorCode) FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim CheckVendorIDCommand As New SqlCommand(CheckVendorIDStatement, con)
            CheckVendorIDCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboSteelVendor.Text
            CheckVendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVendorID = CInt(CheckVendorIDCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckVendorID = 0
            End Try
            con.Close()

            Dim CheckHeatNumberStatement As String = "SELECT COUNT(HeatNumber) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND Status = @Status"
            Dim CheckHeatNumberCommand As New SqlCommand(CheckHeatNumberStatement, con)
            CheckHeatNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            CheckHeatNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckHeatNumber = CInt(CheckHeatNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckHeatNumber = 0
            End Try
            con.Close()

            If CheckVendorID + CheckHeatNumber >= 2 Then
                'Continue
            Else
                MsgBox("You must have a valid Heat # and vendor.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Check if Steel Vendor Folder exists - if not, create it
            Dim MillCertPath As String = "\\TFP-SQL\TransferData\Mill Certifications"
            MillCertPath = MillCertPath + "\" + cboSteelVendor.Text
            Dim PDFDir As New IO.DirectoryInfo(MillCertPath)

            If Not PDFDir.Exists Then
                PDFDir.Create()
            End If

            'Create Filename (CUSTOMER\HEAT NUMBER + STEEL SIZE)
            Dim SteelSize As String = ""
            Dim ModifiedSteelSize As String = ""
            Dim MillCertFilename As String = ""
            Dim MillCertFilenameAndPath As String = ""
            Dim TempFileName As String = ""

            'Get Steel Size from Heat Number
            SteelSize = txtSteelDiameter.Text
            If SteelSize.StartsWith(".") Then
                SteelSize = "0" + SteelSize
            End If

            If SteelSize.Contains(".") And SteelSize.Contains("/") Then
                SteelSize = SteelSize.Replace(".", "-")
                SteelSize = SteelSize.Replace("/", "-")
            End If

            If SteelSize.Contains(".") Then
                SteelSize = SteelSize.Replace(".", "-")
            ElseIf SteelSize.Contains("/") Then
                SteelSize = SteelSize.Replace("/", "-")
            Else
                'Do nothing
            End If

            ModifiedSteelSize = "-" + SteelSize

            MillCertFilename = cboHeatNumber.Text + ModifiedSteelSize + ".pdf"
            MillCertFilenameAndPath = "\\TFP-SQL\TransferData\Mill Certifications\" + cboSteelVendor.Text + "\" + MillCertFilename

            'Open Dialog Box
            Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            ofdUploadMillCert.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

            'Open File Dialog Box
            If ofdUploadMillCert.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Get filename from dialog box
            TempFileName = ofdUploadMillCert.FileName

            If TempFileName = "" Then
                Exit Sub
            End If

            Try
                'Rename file
                File.Copy(TempFileName, MillCertFilenameAndPath)
                MsgBox("Mill Cert Uploaded", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Rename file
                MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)

                Dim button As DialogResult = MessageBox.Show("Do you wish to re-upload this Mill Cert and delete the existing one?", "UPLOAD MILL CERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    File.Delete(MillCertFilenameAndPath)

                    'Rename file
                    File.Copy(TempFileName, MillCertFilenameAndPath)
                    MsgBox("Mill Cert Uploaded", MsgBoxStyle.OkOnly)
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            End Try

            'Clear variables
            cboSteelVendor.Text = ""
            cboHeatNumber.Text = ""

            cboSteelVendor.SelectedIndex = -1
            cboHeatNumber.SelectedIndex = -1

            MillCertFilename = ""
            MillCertFilenameAndPath = ""
            SteelSize = ""
            ModifiedSteelSize = ""
            TempFileName = ""

            cboSteelVendor.Focus()
        End If
    End Sub

    Private Sub cmdLoadMillCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadMillCert.Click
        If Me.dgvMillCerts.RowCount > 0 Then
            Dim RowVendor, RowFilename As String
            Dim MillCertFileName, MillCertFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvMillCerts.CurrentCell.RowIndex

            RowVendor = Me.dgvMillCerts.Rows(RowIndex).Cells("VendorColumn").Value
            RowFilename = Me.dgvMillCerts.Rows(RowIndex).Cells("FilenameColumn").Value

            MillCertFileName = RowVendor + "\" + RowFilename
            MillCertFilenameAndPath = "\\TFP-SQL\TransferData\Mill Certifications\" + MillCertFileName

            If File.Exists(MillCertFilenameAndPath) Then
                System.Diagnostics.Process.Start(MillCertFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub dgvMillCerts_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMillCerts.CellDoubleClick
        If Me.dgvMillCerts.RowCount > 0 Then
            Dim RowVendor, RowFilename As String
            Dim MillCertFileName, MillCertFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvMillCerts.CurrentCell.RowIndex

            RowVendor = Me.dgvMillCerts.Rows(RowIndex).Cells("VendorColumn").Value
            RowFilename = Me.dgvMillCerts.Rows(RowIndex).Cells("FilenameColumn").Value

            MillCertFileName = RowVendor + "\" + RowFilename
            MillCertFilenameAndPath = "\\TFP-SQL\TransferData\Mill Certifications\" + MillCertFileName

            If File.Exists(MillCertFilenameAndPath) Then
                System.Diagnostics.Process.Start(MillCertFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdViewFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFiles.Click
        'Clear Datagrid first
        Me.dgvMillCerts.RowCount = 0

        Dim MillCertReportPath As String = "\\TFP-SQL\TransferData\Mill Certifications\"
        Dim MillCertReportDir As DirectoryInfo
        Dim HeatSearchText As String = ""
        Dim VendorSearchText As String = ""
        Dim SearchPath As String = ""

        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim VendorFilename As String = ""
        Dim RawFilename As String = ""

        MillCertReportDir = New DirectoryInfo(MillCertReportPath)

        If cboSteelVendor.Text <> "" Then
            VendorSearchText = cboSteelVendor.Text + "\"
        Else
            VendorSearchText = "*"
        End If
        If cboHeatNumber.Text <> "" Then
            HeatSearchText = cboHeatNumber.Text
        Else
            HeatSearchText = ""
        End If

        SearchPath = VendorSearchText + HeatSearchText
        '***********************************************************************************************************

        Dim files As List(Of FileInfo) = MillCertReportDir.GetFiles(SearchPath + "*", SearchOption.AllDirectories).ToList()

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(43, FilenameLength - 43)

            Dim SplitFile() As String = Filename.Split(New Char() {"\"c}, 2)

            VendorFilename = SplitFile(0)
            RawFilename = SplitFile(1)

            'Add line to datagrid
            Me.dgvMillCerts.Rows.Add(VendorFilename, RawFilename)
        Next
    End Sub

    Private Sub cboHeatNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.SelectedIndexChanged
        If cboHeatNumber.Text = "" Then
            'Do nothing
            txtSteelDiameter.Clear()
        Else
            GetSteelDiamaterForHeat()
        End If
    End Sub
End Class