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
Public Class UploadMillCertPopup
    Inherits System.Windows.Forms.Form

    Dim MillCertFilename As String = ""
    Dim MillCertFilenameAndPath As String = ""
    Dim MillCertNumber As String = ""
    Dim MillCertDiameter As String = ""
    Dim ModifiedMillCertDiameter As String = ""
    Dim MillCertVendor As String = ""
    Dim PrintType As String = ""
    Dim TempFileName As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2 As DataSet

    Private Sub UploadMillCertPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSteelVendor()
        cboSteelVendor.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadDiameterFromHeat()
        Dim GetMaxHeatFileNumber As Integer = 0
        Dim GetSizeFromHeat As String = ""

        'Get last entry for this heat number
        Dim GetMaxHeatFileNumberStatement As String = "SELECT MAX(HeatFileNumber) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber"
        Dim GetMaxHeatFileNumberCommand As New SqlCommand(GetMaxHeatFileNumberStatement, con)
        GetMaxHeatFileNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetMaxHeatFileNumber = CInt(GetMaxHeatFileNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetMaxHeatFileNumber = 0
        End Try
        con.Close()

        Dim GetSizeFromHeatStatement As String = "SELECT SteelSize FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
        Dim GetSizeFromHeatCommand As New SqlCommand(GetSizeFromHeatStatement, con)
        GetSizeFromHeatCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = GetMaxHeatFileNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSizeFromHeat = CStr(GetSizeFromHeatCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetSizeFromHeat = ""
        End Try
        con.Close()

        txtSteelDiameter.Text = GetSizeFromHeat
    End Sub

    Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
        'Verify Data
        If txtHeatNumber.Text = "" Or cboSteelVendor.Text = "" Or txtSteelDiameter.Text = "" Then
            MsgBox("You must enter a heat #, steel vendor, and steel diameter.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Based on entries, create Mill Cert Filename
        Dim DecimalStringLength As Integer = 0

        MillCertNumber = txtHeatNumber.Text
        MillCertVendor = cboSteelVendor.Text

        MillCertDiameter = txtSteelDiameter.Text

        'Add trailing zeros if necessary
        If MillCertDiameter.StartsWith(".") Then
            DecimalStringLength = MillCertDiameter.Length

            If DecimalStringLength = 3 Then
                MillCertDiameter = MillCertDiameter + "0"
            ElseIf DecimalStringLength = 2 Then
                MillCertDiameter = MillCertDiameter + "00"
            ElseIf DecimalStringLength = 1 Then
                MsgBox("Invalid steel diameter", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing
            End If
        ElseIf MillCertDiameter.StartsWith("0.") Then
            DecimalStringLength = MillCertDiameter.Length

            If DecimalStringLength = 4 Then
                MillCertDiameter = MillCertDiameter + "0"
            ElseIf DecimalStringLength = 3 Then
                MillCertDiameter = MillCertDiameter + "00"
            ElseIf DecimalStringLength = 2 Then
                MsgBox("Invalid steel diameter", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing
            End If
        ElseIf MillCertDiameter.StartsWith("1.") Then
            DecimalStringLength = MillCertDiameter.Length

            If DecimalStringLength = 4 Then
                MillCertDiameter = MillCertDiameter + "0"
            ElseIf DecimalStringLength = 3 Then
                MillCertDiameter = MillCertDiameter + "00"
            ElseIf DecimalStringLength = 2 Then
                MsgBox("Invalid steel diameter", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing
            End If
        ElseIf MillCertDiameter.StartsWith("2.") Then
            DecimalStringLength = MillCertDiameter.Length

            If DecimalStringLength = 4 Then
                MillCertDiameter = MillCertDiameter + "0"
            ElseIf DecimalStringLength = 3 Then
                MillCertDiameter = MillCertDiameter + "00"
            ElseIf DecimalStringLength = 2 Then
                MsgBox("Invalid steel diameter", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing
            End If
        ElseIf MillCertDiameter.StartsWith("3.") Then
            DecimalStringLength = MillCertDiameter.Length

            If DecimalStringLength = 4 Then
                MillCertDiameter = MillCertDiameter + "0"
            ElseIf DecimalStringLength = 3 Then
                MillCertDiameter = MillCertDiameter + "00"
            ElseIf DecimalStringLength = 2 Then
                MsgBox("Invalid steel diameter", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing
            End If
        Else
            'Do nothing - not a decimal
        End If

        'Add leading zero to decimals
        If MillCertDiameter.StartsWith(".") Then
            MillCertDiameter = "0" + MillCertDiameter
        End If

        'Replace dots with dashes
        MillCertDiameter = MillCertDiameter.Replace(".", "-")

        'Replace exes with dashes
        MillCertDiameter = MillCertDiameter.Replace("X", "-")

        'Replace slashes with dashes
        MillCertDiameter = MillCertDiameter.Replace("/", "-")

        'Add leading dash if necessary
        If MillCertDiameter.StartsWith("-") Then
            'Do nothing
        Else
            MillCertDiameter = "-" + MillCertDiameter
        End If

        MillCertFilename = MillCertNumber + MillCertDiameter + ".pdf"
        MillCertFilenameAndPath = "\\TFP-SQL\TransferData\Mill Certifications\" + MillCertVendor + "\" + MillCertFilename

        txtUploadPath.Text = MillCertFilenameAndPath

        'Find path to my docs for local user
        Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ofdSelectFile.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

        'Open File Dialog Box
        If ofdSelectFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        'Get filename from dialog box
        TempFileName = ofdSelectFile.FileName

        txtSourcePath.Text = TempFileName

        If TempFileName = "" Then
            Exit Sub
        End If

        Try
            'Rename file
            File.Copy(TempFileName, MillCertFilenameAndPath)
            MsgBox("Mill Cert Uploaded", MsgBoxStyle.OkOnly)

            txtHeatNumber.Clear()
            txtSteelDiameter.Clear()
            txtSourcePath.Clear()
            txtUploadPath.Clear()

            cboSteelVendor.SelectedIndex = -1

            MillCertFilename = ""
            MillCertFilenameAndPath = ""
            MillCertNumber = ""
            MillCertDiameter = ""
            ModifiedMillCertDiameter = ""
            MillCertVendor = ""
            PrintType = ""
            TempFileName = ""

            cboSteelVendor.Focus()
        Catch ex As Exception
            'Rename file
            MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
            Exit Sub
        End Try
    End Sub

    Public Sub LoadSteelVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass ORDER BY VendorCode ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "Vendor")
        cboSteelVendor.DataSource = ds.Tables("Vendor")
        con.Close()
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        LoadDiameterFromHeat()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtHeatNumber.Clear()
        txtSteelDiameter.Clear()
        txtSourcePath.Clear()
        txtUploadPath.Clear()

        cboSteelVendor.SelectedIndex = -1

        MillCertFilename = ""
        MillCertFilenameAndPath = ""
        MillCertNumber = ""
        MillCertDiameter = ""
        ModifiedMillCertDiameter = ""
        MillCertVendor = ""
        PrintType = ""
        TempFileName = ""

        cboSteelVendor.Focus()
    End Sub

End Class