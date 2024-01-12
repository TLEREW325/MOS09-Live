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
Public Class ViewUploadedInspectionReport
    Inherits System.Windows.Forms.Form

    Dim CustomerNameString As String = ""
    Dim CustomerNameLength As Integer = 0
    Dim BlueprintNumberString As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Public Sub LoadCustomerID()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = 'TFP' OR DivisionID = 'TWD' ORDER BY CustomerID ASC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerList")
        cboCustomerID.DataSource = ds.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadBlueprintDataFromFOX()
        Dim BlueprintNumber, BlueprintRevision As String

        Dim BlueprintNumberStatement As String = "SELECT BlueprintNumber FROM FOXTable WHERE FOXNumber = @FOXNumber"
        Dim BlueprintNumberCommand As New SqlCommand(BlueprintNumberStatement, con)
        BlueprintNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(txtFOXNumber.Text)

        Dim BlueprintRevisionStatement As String = "SELECT BlueprintRevision FROM FOXTable WHERE FOXNumber = @FOXNumber"
        Dim BlueprintRevisionCommand As New SqlCommand(BlueprintRevisionStatement, con)
        BlueprintRevisionCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(txtFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BlueprintNumber = CStr(BlueprintNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            BlueprintNumber = ""
        End Try
        Try
            BlueprintRevision = CStr(BlueprintRevisionCommand.ExecuteScalar)
        Catch ex As System.Exception
            BlueprintRevision = ""
        End Try
        con.Close()

        txtBlueprint.Text = BlueprintNumber
        txtRevisionLevel.Text = BlueprintRevision
    End Sub

    Public Sub ClearData()
        Me.dgvInspectionReports.RowCount = 0

        cboCustomerID.SelectedIndex = -1
        txtBlueprint.Clear()
        txtFOXNumber.Clear()
        txtRevisionLevel.Clear()

        cboCustomerID.Focus()
    End Sub

    Private Sub ViewUploadedInspectionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerID()
        ClearData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtFOXNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFOXNumber.TextChanged
        LoadBlueprintDataFromFOX()
    End Sub

    Private Sub cmdViewFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFiles.Click
        'Clear Datagrid first
        Me.dgvInspectionReports.RowCount = 0

        Dim InspectionReportPath As String = "\\TFP-FS\TransferData\Inspection Reports\"
        Dim InspectionReportDir As DirectoryInfo
        Dim BlueprintSearchText As String = ""
        Dim RevisionSearchText As String = ""
        Dim CustomerSearchText As String = ""
        Dim SearchPath As String = ""

        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim CustomerFilename As String = ""
        Dim RawFilename As String = ""

        InspectionReportDir = New DirectoryInfo(InspectionReportPath)

        If cboCustomerID.Text <> "" Then
            CustomerSearchText = cboCustomerID.Text + "\"
        Else
            CustomerSearchText = ""
        End If
        If txtBlueprint.Text <> "" Then
            BlueprintSearchText = txtBlueprint.Text
        Else
            BlueprintSearchText = ""
        End If
        If txtRevisionLevel.Text <> "" Then
            RevisionSearchText = txtRevisionLevel.Text
        Else
            RevisionSearchText = ""
        End If

        SearchPath = CustomerSearchText + BlueprintSearchText + RevisionSearchText
        '***********************************************************************************************************

        Dim files As List(Of FileInfo) = InspectionReportDir.GetFiles(SearchPath + "*", SearchOption.AllDirectories).ToList()

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(41, FilenameLength - 41)

            Dim SplitFile() As String = Filename.Split(New Char() {"\"c}, 2)
 
            CustomerFilename = SplitFile(0)
            RawFilename = SplitFile(1)

            'Add line to datagrid
            Me.dgvInspectionReports.Rows.Add(CustomerFilename, RawFilename)
        Next
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cmdLoadReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadReport.Click
        If Me.dgvInspectionReports.RowCount > 0 Then
            Dim RowCustomer, RowFilename As String
            Dim InspectionFileName, InspectionFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvInspectionReports.CurrentCell.RowIndex

            RowCustomer = Me.dgvInspectionReports.Rows(RowIndex).Cells("CustomerColumn").Value
            RowFilename = Me.dgvInspectionReports.Rows(RowIndex).Cells("FilenameColumn").Value

            InspectionFileName = RowCustomer + "\" + RowFilename
            InspectionFilenameAndPath = "\\TFP-FS\TransferData\Inspection Reports\" + InspectionFileName

            If File.Exists(InspectionFilenameAndPath) Then
                System.Diagnostics.Process.Start(InspectionFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub dgvInspectionReports_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInspectionReports.CellDoubleClick
        If Me.dgvInspectionReports.RowCount > 0 Then
            Dim RowCustomer, RowFilename As String
            Dim InspectionFileName, InspectionFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvInspectionReports.CurrentCell.RowIndex

            RowCustomer = Me.dgvInspectionReports.Rows(RowIndex).Cells("CustomerColumn").Value
            RowFilename = Me.dgvInspectionReports.Rows(RowIndex).Cells("FilenameColumn").Value

            InspectionFileName = RowCustomer + "\" + RowFilename
            InspectionFilenameAndPath = "\\TFP-FS\TransferData\Inspection Reports\" + InspectionFileName

            If File.Exists(InspectionFilenameAndPath) Then
                System.Diagnostics.Process.Start(InspectionFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdUploadInspection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadInspection.Click
        If cboCustomerID.Text = "" Or txtBlueprint.Text = "" Then
            MsgBox("You must have a valid customer and blueprint #.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim CustomerName As String = ""
            Dim BlueprintNumber As String = ""
            Dim RevisionLevel As String = ""
            Dim TodaysDate As Date = Now()
            Dim strTodaysDate As String = ""
            Dim TodaysMinute As Integer = 0
            Dim strTodaysMinute As String = ""
            Dim InspectionReportFileName As String = ""
            Dim InspectionReportFilenameAndPath As String = ""
            Dim TempFilename As String = ""
            Dim strFoxNumber As String = ""
            Dim FoxNumber As Integer = 0
            Dim SecondNumber As Integer = 0
            Dim strSecondNumber As String = ""

            SecondNumber = TodaysDate.Second
            strSecondNumber = CStr(SecondNumber)
            FoxNumber = txtFOXNumber.Text
            strFoxNumber = CStr(FoxNumber)
            CustomerName = cboCustomerID.Text
            BlueprintNumber = txtBlueprint.Text
            RevisionLevel = txtRevisionLevel.Text

            strTodaysDate = TodaysDate.ToShortDateString()
            TodaysMinute = TodaysDate.Minute
            strTodaysMinute = CStr(TodaysMinute)
            strTodaysDate = strTodaysDate.Replace("/", "-")

            If TodaysDate.Month < 10 Then
                strTodaysDate = "0" + strTodaysDate
            End If

            'Check if customer directory exists - if it doesn't, create it
            Dim CustomerDirectory As String = ""
            CustomerDirectory = "\\TFP-FS\TransferData\Inspection Reports\" + CustomerName

            If System.IO.Directory.Exists(CustomerDirectory) Then
                'Skip - folder already exists
            Else
                'Create customer folder
                System.IO.Directory.CreateDirectory(CustomerDirectory)
            End If
            InspectionReportFileName = CustomerName + "\" + BlueprintNumber + RevisionLevel + " " + strFoxNumber + " " + strTodaysDate + " " + strTodaysMinute + strSecondNumber + ".pdf"
            InspectionReportFilenameAndPath = "\\TFP-FS\TransferData\Inspection Reports\" + InspectionReportFileName

            'Open Dialog Box
            Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            ofdInspectionReport.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

            'Open File Dialog Box
            If ofdInspectionReport.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Get filename from dialog box
            TempFilename = ofdInspectionReport.FileName

            If TempFileName = "" Then
                Exit Sub
            End If

            'If Filename exists, delete the old file and copy over a new file
            If File.Exists(InspectionReportFilenameAndPath) Then
                File.Delete(InspectionReportFilenameAndPath)
            Else
                'Continue
            End If

            Try
                'Rename file
                File.Copy(TempFilename, InspectionReportFilenameAndPath)
                MsgBox("Inspection Report Uploaded", MsgBoxStyle.OkOnly)

                cboCustomerID.SelectedIndex = -1
                cboCustomerID.Text = ""
                txtBlueprint.Clear()
                txtFOXNumber.Clear()
                txtRevisionLevel.Clear()

                CustomerName = ""
                BlueprintNumber = ""
                RevisionLevel = ""
                TodaysDate = Now()
                strTodaysDate = ""
                TodaysMinute = 0
                strTodaysMinute = ""
                InspectionReportFileName = ""
                InspectionReportFilenameAndPath = ""
                TempFilename = ""

                cboCustomerID.Focus()
            Catch ex As Exception
                'Rename(File)
                MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
                Exit Sub
            End Try
        End If
    End Sub
End Class