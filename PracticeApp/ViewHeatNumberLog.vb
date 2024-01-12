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
Public Class ViewHeatNumberLog
    Inherits System.Windows.Forms.Form

    Dim StatusFilter, CarbonFilter, SteelSizeFilter, HeatNumberFilter, VendorFilter, PONumberFilter As String
    Dim PONumber As Integer = 0
    Dim strPONumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Const InspectionDir As String = "\\TFP-FS\TransferData\Steel Receiving Inspection"
    Dim cmsAdminMenu As New ContextMenu()

    Private Sub ViewHeatNumberLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView
        LoadCarbon()
        LoadSteelSize()
        LoadHeatNumber()
        LoadVendor()

        usefulFunctions.LoadSecurity(Me)
        cmsAdminMenu.MenuItems.Add("Add Receiving Inspection", AddressOf AddReceivingInspection)

        ColorText()
    End Sub

    Public Sub ShowDataByFilters()
        If cboCarbon.Text = "" Then
            CarbonFilter = ""
        Else
            CarbonFilter = " AND SteelType = '" + cboCarbon.Text + "'"
        End If
        If cboSteelSize.Text = "" Then
            SteelSizeFilter = ""
        Else
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        End If
        If cboHeatNumber.Text = "" Then
            HeatNumberFilter = ""
        Else
            HeatNumberFilter = " AND HeatNumber = '" + cboHeatNumber.Text + "'"
        End If
        If cboSteelVendor.Text = "" Then
            VendorFilter = ""
        Else
            VendorFilter = " AND VendorID = '" + cboSteelVendor.Text + "'"
        End If
        If txtSteelPONumber.Text = "" Then
            PONumberFilter = ""
        Else
            PONumber = Val(txtSteelPONumber.Text)
            strPONumber = CStr(PONumber)
            PONumberFilter = " AND SteelPONumber = '" + strPONumber + "'"
        End If
        If cboStatus.Text = "" Then
            StatusFilter = ""
        Else
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        End If

        cmd = New SqlCommand("SELECT * FROM HeatNumberLog WHERE HeatFileNumber <> 0" + CarbonFilter + SteelSizeFilter + HeatNumberFilter + PONumberFilter + VendorFilter + StatusFilter + " ORDER BY HeatFileNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "HeatNumberLog")
        dgvHeatNumberLog.DataSource = ds.Tables("HeatNumberLog")
        con.Close()

        If EmployeeSecurityCode <= 1002 Then ColorText()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvHeatNumberLog.DataSource = Nothing
    End Sub

    Private Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT HeatNumber FROM HeatNumberLog", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "HeatNumberLog")
        cboHeatNumber.DataSource = ds3.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = 'TWD' AND VendorClass = 'SteelVendor'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "Vendor")
        cboSteelVendor.DataSource = ds4.Tables("Vendor")
        con.Close()
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        cboSteelVendor.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then
            cboSteelVendor.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboStatus.Text) Then
            cboStatus.Text = ""
        End If

        txtSteelPONumber.Clear()
        txtVendorName.Clear()

        cboCarbon.Focus()
    End Sub

    Private Sub cmdHeatNumberForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHeatNumberForm.Click
        If dgvHeatNumberLog.Rows.Count > 0 Then
            If dgvHeatNumberLog.CurrentCell.RowIndex >= 0 Then
                GlobalHeatFileNumber = Val(dgvHeatNumberLog.Rows(dgvHeatNumberLog.CurrentCell.RowIndex).Cells("HeatFileNumberColumn").Value)
            Else
                GlobalHeatFileNumber = 0
            End If
        Else
            GlobalHeatFileNumber = 0
        End If

        Dim NewMillCertForm As New MillCertForm
        NewMillCertForm.Show()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub ColorText()
        For i As Integer = 0 To dgvHeatNumberLog.Rows.Count - 1
            Dim test As Object = dgvHeatNumberLog.Rows(i).Cells("DateReceivedColumn").Value
            If System.IO.File.Exists(InspectionDir + "\" + dgvHeatNumberLog.Rows(i).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(i).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(i).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + ".pdf") Then
                dgvHeatNumberLog.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            Else
                dgvHeatNumberLog.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
            End If
        Next
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintHeatNumberLog As New PrintHeatNumbersFiltered
            Dim result = NewPrintHeatNumberLog.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboCarbon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCarbon.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub AddReceivingInspection()
        Dim fileDialog As New OpenFileDialog
        ''makes the file dialog box open to the directory currently used
        If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)") Then
            fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)"
        ElseIf System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples") Then
            fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples"
        End If

        ''will restore to the initial directory
        fileDialog.RestoreDirectory = True
        fileDialog.Multiselect = False
        fileDialog.DefaultExt = ".pdf"
        fileDialog.Filter = "PDF documents (.pdf)|*.pdf"

        Dim selectedRow As Integer = dgvHeatNumberLog.CurrentCell.RowIndex
        If System.IO.File.Exists(InspectionDir + "\" + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(selectedRow).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + ".pdf") Then
            Dim resp As DialogResult = MessageBox.Show("Inspection file has already been uploaded, do you wish to overwrite the current inspection file?", "Overwrite file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = System.Windows.Forms.DialogResult.Yes Then
                If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    My.Computer.FileSystem.DeleteFile(InspectionDir + "\" + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(selectedRow).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + ".pdf")
                    Try
                        My.Computer.FileSystem.CopyFile(fileDialog.FileName, InspectionDir + "\" + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(selectedRow).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + ".pdf")
                        dgvHeatNumberLog.Rows(selectedRow).DefaultCellStyle.ForeColor = Color.Green
                    Catch ex As System.Exception
                        sendErrorToDataBase("ViewHeatNumberLog - AddReceivingInspection --Error trying to upload receiving inspection file.", "Heat File # " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString, ex.ToString())
                    End Try
                End If
            ElseIf resp = System.Windows.Forms.DialogResult.No Then
                If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    Dim adder As Integer = 0
                    While System.IO.File.Exists(InspectionDir + "\" + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(selectedRow).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + " " + adder.ToString + ".pdf")
                        adder += 1
                    End While
                    Try
                        My.Computer.FileSystem.CopyFile(fileDialog.FileName, InspectionDir + "\" + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(selectedRow).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + " " + adder.ToString + ".pdf")
                        dgvHeatNumberLog.Rows(selectedRow).DefaultCellStyle.ForeColor = Color.Green
                    Catch ex As System.Exception
                        sendErrorToDataBase("ViewHeatNumberLog - AddReceivingInspection --Error trying to upload receiving inspection file.", "Heat File # " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString, ex.ToString())
                    End Try
                End If
            End If
        Else
            If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    My.Computer.FileSystem.CopyFile(fileDialog.FileName, InspectionDir + "\" + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(selectedRow).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + ".pdf")
                    dgvHeatNumberLog.Rows(selectedRow).DefaultCellStyle.ForeColor = Color.Green
                Catch ex As System.Exception
                    sendErrorToDataBase("ViewHeatNumberLog - AddReceivingInspection --Error trying to upload receiving inspection file.", "Heat File # " + dgvHeatNumberLog.Rows(selectedRow).Cells("HeatFileNumberColumn").Value.ToString, ex.ToString())
                End Try
            End If
        End If
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdViewInspectionReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewInspectionReport.Click
        If dgvHeatNumberLog.SelectedCells.Count > 0 AndAlso dgvHeatNumberLog.SelectedCells(0).RowIndex >= 0 Then
            Dim files As String() = GetInspectionReportFiles()
            If files.Length > 0 Then
                Dim newViewPDF As New ViewPDFFiles(files)
                newViewPDF.ShowDialog()
                Me.BringToFront()
                Me.Focus()
            Else
                MessageBox.Show("There are no receiving inspection reports to view.", "No receiving inspections", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function GetInspectionReportFiles() As String()
        Return System.IO.Directory.GetFiles(InspectionDir, dgvHeatNumberLog.Rows(dgvHeatNumberLog.SelectedCells(0).RowIndex).Cells("HeatFileNumberColumn").Value.ToString + " " + dgvHeatNumberLog.Rows(dgvHeatNumberLog.SelectedCells(0).RowIndex).Cells("HeatNumberColumn").Value.ToString + " " + CType(dgvHeatNumberLog.Rows(dgvHeatNumberLog.SelectedCells(0).RowIndex).Cells("DateReceivedColumn").Value, Date).ToString("MM-dd-yyyy") + ".pdf")
    End Function

    Private Sub dgvHeatNumberLog_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHeatNumberLog.ColumnHeaderMouseClick
        ColorText()
    End Sub

    Private Sub dgvHeatNumberLog_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvHeatNumberLog.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right And (EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002) Then
            Dim ht As DataGridView.HitTestInfo = dgvHeatNumberLog.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                dgvHeatNumberLog.SelectedCells(0).Selected = False
                dgvHeatNumberLog.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                dgvHeatNumberLog.CurrentCell = dgvHeatNumberLog.Rows(ht.RowIndex).Cells(ht.ColumnIndex)
                cmsAdminMenu.Show(dgvHeatNumberLog, New System.Drawing.Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub dgvHeatNumberLog_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvHeatNumberLog.SelectionChanged
        If dgvHeatNumberLog.SelectedCells.Count > 0 AndAlso dgvHeatNumberLog.SelectedCells(0).RowIndex >= 0 Then
            Dim files As String() = GetInspectionReportFiles()
            If files.Length > 0 Then
                cmdViewInspectionReport.Enabled = True
            Else
                cmdViewInspectionReport.Enabled = False
            End If
        Else
            cmdViewInspectionReport.Enabled = False
        End If
    End Sub

    Private Sub cmdUploadMillCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadMillCert.Click
        Dim NewUploadMillCert As New UploadMillCertPopup
        NewUploadMillCert.Show()
    End Sub
End Class