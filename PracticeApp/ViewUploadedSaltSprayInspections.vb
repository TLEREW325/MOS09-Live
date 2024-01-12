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
Public Class ViewUploadedSaltSprayInspections
    Inherits System.Windows.Forms.Form

    Dim CustomerNameString As String = ""
    Dim CustomerNameLength As Integer = 0
    Dim FOXNumberString As String = ""
    Dim FOXNumberLength As Integer = 0
    Dim SaltSprayFilenameAndPath As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Private Sub ViewUploadedSaltSprayInspections_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerID()
        clearData()
    End Sub

    Public Sub LoadCustomerID()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerList")
        cboCustomerID.DataSource = ds.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadSaltSprayInspections()
        'Clear Datagrid first
        Me.dgvSaltSpray.RowCount = 0

        Dim SaltSprayReportPath As String = "\\TFP-FS\TransferData\Salt Spray Inspection\"
        Dim SaltSprayReportDir As DirectoryInfo
        Dim FOXSearchText As String = ""
        Dim CustomerSearchText As String = ""
        Dim SearchPath As String = ""

        Dim Filename As String = ""
        Dim FilenameLength As Integer = 0
        Dim FullFilename As String = ""
        Dim CustomerFilename As String = ""
        Dim RawFilename As String = ""

        SaltSprayReportDir = New DirectoryInfo(SaltSprayReportPath)

        If cboCustomerID.Text <> "" Then
            CustomerSearchText = cboCustomerID.Text + "\"
        Else
            CustomerSearchText = ""
        End If
        If txtLotNumber.Text <> "" Then
            FOXSearchText = txtLotNumber.Text
        Else
            FOXSearchText = ""
        End If

        SearchPath = CustomerSearchText + FOXSearchText
        '***********************************************************************************************************

        Dim files As List(Of FileInfo) = SaltSprayReportDir.GetFiles(SearchPath + "*", SearchOption.AllDirectories).ToList()

        For Each File As FileInfo In files
            FullFilename = File.FullName.ToString()
            FilenameLength = FullFilename.Length
            Filename = FullFilename.Substring(44, FilenameLength - 44)

            Dim SplitFile() As String = Filename.Split(New Char() {"\"c}, 2)

            CustomerFilename = SplitFile(0)
            RawFilename = SplitFile(1)

            'Add line to datagrid
            Me.dgvSaltSpray.Rows.Add(CustomerFilename, RawFilename)
        Next
    End Sub

    Public Sub ClearData()
        Me.dgvSaltSpray.RowCount = 0

        cboCustomerID.SelectedIndex = -1
        cboCustomerID.Text = ""

        txtLotNumber.Clear()

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cmdLoadReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadReport.Click
        If Me.dgvSaltSpray.RowCount > 0 Then
            Dim RowCustomer, RowFilename As String
            Dim InspectionFileName, InspectionFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvSaltSpray.CurrentCell.RowIndex

            RowCustomer = Me.dgvSaltSpray.Rows(RowIndex).Cells("CustomerColumn").Value
            RowFilename = Me.dgvSaltSpray.Rows(RowIndex).Cells("FilenameColumn").Value

            InspectionFileName = RowCustomer + "\" + RowFilename
            InspectionFilenameAndPath = "\\TFP-FS\TransferData\Salt Spray Inspection\" + InspectionFileName

            If File.Exists(InspectionFilenameAndPath) Then
                System.Diagnostics.Process.Start(InspectionFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        LoadSaltSprayInspections()
    End Sub

    Private Sub cmdUploadSaltSpray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadSaltSpray.Click
        If cboCustomerID.Text = "" Or txtLotNumber.Text = "" Then
            MsgBox("Before uploading, you must enter a customer and lot #.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Verify Customer and Lot Number
            Dim CheckCustomerID As Integer = 0
            Dim CheckLotNumber As Integer = 0

            Dim CheckCustomerIDStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CheckCustomerIDCommand As New SqlCommand(CheckCustomerIDStatement, con)
            CheckCustomerIDCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CheckCustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCustomerID = CInt(CheckCustomerIDCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckCustomerID = 0
            End Try
            con.Close()

            Dim CheckLotNumberStatement As String = "SELECT COUNT(LotNumber) FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
            Dim CheckLotNumberCommand As New SqlCommand(CheckLotNumberStatement, con)
            CheckLotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
            CheckLotNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckLotNumber = CInt(CheckLotNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckLotNumber = 0
            End Try
            con.Close()

            If CheckCustomerID + CheckLotNumber = 2 Then
                'Continue
            Else
                MsgBox("You must have a valid Lot # and customer.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Check if customer directory exists - if it doesn't, create it
            Dim CustomerDirectory As String = ""
            CustomerDirectory = "\\TFP-FS\TransferData\Salt Spray Inspection\" + cboCustomerID.Text

            If System.IO.Directory.Exists(CustomerDirectory) Then
                'Skip - folder already exists
            Else
                'Create customer folder
                System.IO.Directory.CreateDirectory(CustomerDirectory)
            End If

            'Create Filename (CUSTOMER\LOT NUMBER + DATE)
            Dim TodaysDate As Date = Now()
            Dim strTodaysDate As String = ""
            Dim SaltSprayFilename As String = ""
            Dim SaltSprayFilenameAndPath As String = ""
            Dim TempFileName As String = ""

            strTodaysDate = TodaysDate.ToShortDateString()
            strTodaysDate = strTodaysDate.Replace("/", "-")

            If TodaysDate.Month < 10 Then
                strTodaysDate = "0" + strTodaysDate
            End If

            SaltSprayFilename = txtLotNumber.Text + " " + strTodaysDate + ".pdf"
            SaltSprayFilenameAndPath = "\\TFP-FS\TransferData\Salt Spray Inspection\" + cboCustomerID.Text + "\" + SaltSprayFilename

            'Open Dialog Box
            Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            ofdSaltSpray.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

            'Open File Dialog Box
            If ofdSaltSpray.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Get filename from dialog box
            TempFileName = ofdSaltSpray.FileName

            If TempFileName = "" Then
                Exit Sub
            End If

            'If Filename exists, delete the old file and copy over a new file
            If File.Exists(SaltSprayFilenameAndPath) Then
                File.Delete(SaltSprayFilenameAndPath)
            Else
                'Continue
            End If

            Try
                'Rename file
                File.Copy(TempFileName, SaltSprayFilenameAndPath)
                MsgBox("Salt Spray Uploaded", MsgBoxStyle.OkOnly)

                txtLotNumber.Clear()
                cboCustomerID.SelectedIndex = -1
                SaltSprayFilename = ""
                SaltSprayFilenameAndPath = ""
                strTodaysDate = ""
                TempFileName = ""

                cboCustomerID.Focus()
            Catch ex As Exception
                'Rename file
                MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub dgvSaltSpray_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSaltSpray.CellDoubleClick
        If Me.dgvSaltSpray.RowCount > 0 Then
            Dim RowCustomer, RowFilename As String
            Dim InspectionFileName, InspectionFilenameAndPath As String

            Dim RowIndex As Integer = Me.dgvSaltSpray.CurrentCell.RowIndex

            RowCustomer = Me.dgvSaltSpray.Rows(RowIndex).Cells("CustomerColumn").Value
            RowFilename = Me.dgvSaltSpray.Rows(RowIndex).Cells("FilenameColumn").Value

            InspectionFileName = RowCustomer + "\" + RowFilename
            InspectionFilenameAndPath = "\\TFP-FS\TransferData\Salt Spray Inspection\" + InspectionFileName

            If File.Exists(InspectionFilenameAndPath) Then
                System.Diagnostics.Process.Start(InspectionFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
End Class