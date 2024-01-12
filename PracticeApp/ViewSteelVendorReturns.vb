Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewSteelVendorReturns
    Inherits System.Windows.Forms.Form

    Dim ReturnFilter, DateFilter, POFilter, ReceiverFilter, SteelCarbonFilter, SteelSizeFilter, VendorFilter, StatusFilter, HeatFilter As String
    Dim SteelPONumber, SteelReceiverNumber, SteelReturnNumber As Integer
    Dim strSteelPONumber, strSteelReceiverNumber, strSteelReturnNumber As String
    Dim SteelVendorName, LineStatus As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ViewSteelVendorReturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSteelReceiverNumber()
        LoadSteelPONumber()
        LoadSteelReturnNumber()
        LoadVendorID()
        LoadCarbon()
        LoadSteelSize()

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Public Sub ShowDataByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND SteelVendor = '" + cboVendorID.Text + "'"
        Else
            VendorFilter = ""
        End If
        If cboCarbon.Text <> "" Then
            SteelCarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
        Else
            SteelCarbonFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        Else
            SteelSizeFilter = ""
        End If
        If cboStatus.Text <> "" Then
            If cboStatus.Text = "OPEN" Then
                LineStatus = "POSTED"
            Else
                LineStatus = cboStatus.Text
            End If
            StatusFilter = " AND LineStatus = '" + LineStatus + "'"
        Else
            StatusFilter = ""
        End If
        If txtHeatNumber.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + txtHeatNumber.Text + "'"
        Else
            HeatFilter = ""
        End If
        If cboSteelPONumber.Text <> "" Then
            SteelPONumber = Val(cboSteelPONumber.Text)
            strSteelPONumber = CStr(SteelPONumber)
            POFilter = " AND SteelPONumber = '" + strSteelPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboSteelReceiver.Text <> "" Then
            SteelReceiverNumber = Val(cboSteelReceiver.Text)
            strSteelReceiverNumber = CStr(SteelReceiverNumber)
            ReceiverFilter = " AND SteelReceiverNumber = '" + strSteelReceiverNumber + "'"
        Else
            ReceiverFilter = ""
        End If
        If cboSteelReturnNumber.Text <> "" Then
            SteelReturnNumber = Val(cboSteelReturnNumber.Text)
            strSteelReturnNumber = CStr(SteelReturnNumber)
            ReturnFilter = " AND SteelReturnNumber = '" + strSteelReturnNumber + "'"
        Else
            ReturnFilter = ""
        End If
        If chkUseDates.Checked = True Then
            DateFilter = " AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM SteelReturnLineQuery WHERE DivisionID = @DivisionID" + POFilter + ReturnFilter + ReceiverFilter + VendorFilter + SteelSizeFilter + SteelCarbonFilter + HeatFilter + StatusFilter + DateFilter + " ORDER BY SteelReturnNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReturnLineQuery")
        dgvReturnLineQuery.DataSource = ds.Tables("SteelReturnLineQuery")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvReturnLineQuery.DataSource = Nothing
    End Sub

    Public Sub LoadSteelPONumber()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID ORDER BY SteelPurchaseOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SteelPurchaseOrderHeader")
        cboSteelPONumber.DataSource = ds1.Tables("SteelPurchaseOrderHeader")
        con.Close()
        cboSteelPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelReceiverNumber()
        cmd = New SqlCommand("SELECT SteelReceivingHeaderKey FROM SteelReceivingHeaderTable WHERE DivisionID = @DivisionID ORDER BY SteelReceivingHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SteelReceivingHeaderTable")
        cboSteelReceiver.DataSource = ds2.Tables("SteelReceivingHeaderTable")
        con.Close()
        cboSteelReceiver.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelReturnNumber()
        cmd = New SqlCommand("SELECT SteelReturnNumber FROM SteelReturnHeaderTable WHERE DivisionID = @DivisionID ORDER BY SteelReturnNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SteelReturnHeaderTable")
        cboSteelReturnNumber.DataSource = ds3.Tables("SteelReturnHeaderTable")
        con.Close()
        cboSteelReturnNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "Vendor")
        cboVendorID.DataSource = ds4.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY Carbon ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "Vendor")
        cboCarbon.DataSource = ds5.Tables("Vendor")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY SteelSize ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "Vendor")
        cboSteelSize.DataSource = ds6.Tables("Vendor")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorName()
        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelVendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            SteelVendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = SteelVendorName
    End Sub

    Private Sub dgvReturnLineQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnLineQuery.CellDoubleClick
        If dgvReturnLineQuery.RowCount = 0 Then
            'Skip
        Else
            Dim RowReturnNumber As Integer

            Dim RowIndex As Integer = Me.dgvReturnLineQuery.CurrentCell.RowIndex

            Try
                RowReturnNumber = Me.dgvReturnLineQuery.Rows(RowIndex).Cells("SteelReturnNumberColumn").Value
            Catch ex As Exception
                RowReturnNumber = 0
            End Try

            GlobalSteelVendorReturnNumber = RowReturnNumber
        
            Using NewPrintSteelReturn As New PrintSteelVendorReturn
                Dim Result = NewPrintSteelReturn.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvReturnLineQuery_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnLineQuery.CellValueChanged
        If dgvReturnLineQuery.RowCount = 0 Then
            'Skip
        Else
            Dim RowReturnNumber, RowReturnLine As Integer
            Dim RowLineComment As String

            Dim RowIndex As Integer = Me.dgvReturnLineQuery.CurrentCell.RowIndex

            Try
                RowReturnNumber = Me.dgvReturnLineQuery.Rows(RowIndex).Cells("SteelReturnNumberColumn").Value
            Catch ex As Exception
                RowReturnNumber = 0
            End Try
            Try
                RowReturnLine = Me.dgvReturnLineQuery.Rows(RowIndex).Cells("SteelReturnLineColumn").Value
            Catch ex As Exception
                RowReturnLine = 0
            End Try
            Try
                RowLineComment = Me.dgvReturnLineQuery.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                RowLineComment = ""
            End Try

            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineComment = @LineComment WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                With cmd.Parameters
                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = RowReturnNumber
                    .Add("@SteelReturnLine", SqlDbType.VarChar).Value = RowReturnLine
                    .Add("@LineComment", SqlDbType.VarChar).Value = RowLineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub

    Public Sub ClearData()
        txtHeatNumber.Clear()
        txtVendorName.Clear()

        cboStatus.SelectedIndex = -1
        cboSteelPONumber.SelectedIndex = -1
        cboSteelReceiver.SelectedIndex = -1
        cboSteelReturnNumber.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboCarbon.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkUseDates.Checked = False

        cboVendorID.Focus()
    End Sub

    Public Sub ClearVariables()
        ReturnFilter = ""
        DateFilter = ""
        POFilter = ""
        ReceiverFilter = ""
        SteelCarbonFilter = ""
        SteelSizeFilter = ""
        VendorFilter = ""
        StatusFilter = ""
        HeatFilter = ""
        SteelPONumber = 0
        SteelReceiverNumber = 0
        SteelReturnNumber = 0
        strSteelPONumber = ""
        strSteelReceiverNumber = ""
        strSteelReturnNumber = ""
        SteelVendorName = ""
        LineStatus = ""
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintSteelVendorReturnLines As New PrintSteelVendorReturnLines
            Dim Result = NewPrintSteelVendorReturnLines.ShowDialog()
        End Using
    End Sub

    Private Sub PrintReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReportsToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

End Class