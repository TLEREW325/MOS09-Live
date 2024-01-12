Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ViewCertErrorLog
    Inherits System.Windows.Forms.Form

    Dim HeatFilter, LotFilter, PartFilter, ShipmentFilter, DateFilter As String
    Dim strShipmentNumber As String
    Dim ShipmentNumber As Integer
    Dim StatusFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ViewCertErrorLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
        LoadSecurity()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub LoadSecurity()
        Select Case EmployeeSecurityCode
            Case 1016
                cmdCloseError.Enabled = False
        End Select
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvCertErrorLog.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboLotNumber.Text <> "" Then
            LotFilter = " AND LotNumber = '" + cboLotNumber.Text + "'"
        Else
            LotFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboHeatNumber.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + cboHeatNumber.Text + "'"
        Else
            HeatFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If rdoOpen.Checked = True Then
            StatusFilter = "OPEN"
        Else
            StatusFilter = "CLOSED"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND Date BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM CertErrorLog WHERE Status = @Status" + HeatFilter + LotFilter + ShipmentFilter + PartFilter + " ORDER BY LotNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = StatusFilter
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "CertErrorLog")
        con.Close()

        dgvCertErrorLog.DataSource = ds.Tables("CertErrorLog")
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT HeatNumber FROM HeatNumberLog;", con)
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "HeatNumberLog")

        con.Close()
        cboHeatNumber.DataSource = ds3.Tables("HeatNumberLog")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds5.Tables("ShipmentHeaderTable")
        con.Close()

        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber;", con)
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "LotNumber")
        cboLotNumber.DataSource = ds5.Tables("LotNumber")
        con.Close()

        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"

        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(ds6, "ItemList")
        cboPartDescription.DataSource = ds6.Tables("ItemList")
        con.Close()

        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboHeatNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboPartNumber.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadShipmentNumber()
        LoadLotNumber()
        LoadPartNumber()
        LoadPartDescription()
        LoadHeatNumber()

        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintCertErrorLog As New PrintCertErrorLog
            Dim result = NewPrintCertErrorLog.ShowDialog()
        End Using
    End Sub

    Private Sub cmdReprintCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintCert.Click
        'Get Pull Test Number for Lot if it exists
        Dim GetItemClass As String = ""

        Dim RowLotNumber, RowHeatNumber As String

        Dim RowIndex As Integer = Me.dgvCertErrorLog.CurrentCell.RowIndex

        RowLotNumber = Me.dgvCertErrorLog.Rows(RowIndex).Cells("LotNumberColumn").Value
        RowHeatNumber = Me.dgvCertErrorLog.Rows(RowIndex).Cells("HeatNumberColumn").Value

        Dim GetItemClassStatement As String = "SELECT LotItemClass FROM CertificationData WHERE LotNumber = @LotNumber"
        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
        GetItemClassCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            GetItemClass = "TW TT"
        End Try
        con.Close()

        If GetItemClass = "TW TT" Then
            GlobalReprintPullTestNumber = "NONE"
        Else
            MsgBox("You can't print a chemistry-only cert for this Lot Number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        GlobalReprintLotNumber = RowLotNumber
        GlobalDivisionCode = cboDivisionID.Text
        GlobalReprintHeatNumber = RowHeatNumber

        Using NewReprintCert As New ReprintCert
            Dim Result = NewReprintCert.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCloseError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseError.Click
        Dim RowLotNumber, RowStatus As String
        Dim RowShipmentNumber As Integer

        Try
            Dim RowIndex As Integer = Me.dgvCertErrorLog.CurrentCell.RowIndex

            RowLotNumber = Me.dgvCertErrorLog.Rows(RowIndex).Cells("LotNumberColumn").Value
            RowStatus = Me.dgvCertErrorLog.Rows(RowIndex).Cells("StatusColumn").Value
            RowShipmentNumber = Me.dgvCertErrorLog.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

            cmd = New SqlCommand("UPDATE CertErrorLog SET Status = @Status WHERE ShipmentNumber = @ShipmentNumber AND LotNumber = @LotNumber AND Status = @Status2", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                .Add("@Status2", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowDataByFilters()
        Catch ex As Exception
            'Skip
        End Try
    End Sub

    Private Sub dgvCertErrorLog_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCertErrorLog.CellValueChanged
        Dim RowLotNumber, RowComment As String
        Dim RowShipmentNumber As Integer

        Try
            Dim RowIndex As Integer = Me.dgvCertErrorLog.CurrentCell.RowIndex

            RowLotNumber = Me.dgvCertErrorLog.Rows(RowIndex).Cells("LotNumberColumn").Value
            RowShipmentNumber = Me.dgvCertErrorLog.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowComment = Me.dgvCertErrorLog.Rows(RowIndex).Cells("CommentColumn").Value

            cmd = New SqlCommand("UPDATE CertErrorLog SET Comment = @Comment WHERE ShipmentNumber = @ShipmentNumber AND LotNumber = @LotNumber", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
                .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                .Add("@Comment", SqlDbType.VarChar).Value = RowComment
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowDataByFilters()
        Catch ex As Exception
            'Skip
        End Try
    End Sub
End Class