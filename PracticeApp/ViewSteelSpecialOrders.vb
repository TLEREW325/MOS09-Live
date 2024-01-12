Imports System
Imports System.Math
Imports System.IO
Imports System.Data
'Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook
Public Class ViewSteelSpecialOrders
    Inherits System.Windows.Forms.Form

    Dim StatusFilter, CarbonFilter, SteelSizeFilter, TextFilter, PartFilter, FOXFilter, VendorFilter, DateFilter As String
    Dim FOXNumber As Integer = 0
    Dim strFOXNumber As String = ""
    Dim OLApp As New Application

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub ViewSteelSpecialOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.SelectedIndex = -1
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        cboStatus.Text = "OPEN"
        ShowData()

        LoadCarbon()
        LoadSteelSize()
        LoadSteelVendor()
        LoadPartDescription()
        LoadPartNumber()
        LoadFOXNumber()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM SteelSpecialOrders WHERE Status = @Status", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelSpecialOrders")
        dgvSteelSpecialOrders.DataSource = ds.Tables("SteelSpecialOrders")
        con.Close()
    End Sub

    Public Sub ShowDataByFilter()
        If cboSteelVendor.Text <> "" Then
            VendorFilter = " AND SteelVendor = '" + usefulFunctions.checkQuote(cboSteelVendor.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboCarbon.Text <> "" Then
            CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
        Else
            CarbonFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (Carbon LIKE '%" + txtTextFilter.Text + "%' OR SteelSize LIKE '%" + txtTextFilter.Text + "%' OR PartNumber LIKE '%" + txtTextFilter.Text + "%' OR SteelDescription LIKE '%" + txtTextFilter.Text + "%' OR RMID LIKE '%" + txtTextFilter.Text + "%' OR SteelVendor LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboFoxNumber.Text <> "" Then
            FOXNumber = Val(cboFoxNumber.Text)
            strFOXNumber = CStr(FOXNumber)
            FOXFilter = " AND FOXNumber = '" + strFOXNumber + "'"
        Else
            FOXFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        Else
            SteelSizeFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboStatus.Text = "OPEN" Then
            SteelSizeFilter = " AND Status = 'OPEN'"
        ElseIf cboStatus.Text = "CLOSED" Then
            SteelSizeFilter = " AND Status = 'CLOSED'"
        Else
            SteelSizeFilter = " AND Status = 'OPEN'"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND OrderDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM SteelSpecialOrders WHERE DivisionID <> @DivisionID" + PartFilter + CarbonFilter + SteelSizeFilter + FOXFilter + StatusFilter + VendorFilter + TextFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelSpecialOrders")
        dgvSteelSpecialOrders.DataSource = ds.Tables("SteelSpecialOrders")
        con.Close()
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelVendor()
        cmd = New SqlCommand("SELECT * FROM Vendor WHERE VendorClass = @VendorClass AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "Vendor")
        cboSteelVendor.DataSource = ds3.Tables("Vendor")
        con.Close()
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE ItemClass <> @ItemClass AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartNumber.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE ItemClass <> @ItemClass AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartDescription.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT * FROM FOXTable WHERE Status = @Status ORDER BY FOXNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "FOXTable")
        cboFoxNumber.DataSource = ds6.Tables("FOXTable")
        con.Close()
        cboFoxNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        PartNumber1Command.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As NullReferenceException
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        PartDescription1Command.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As NullReferenceException
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboFoxNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboSteelVendor.SelectedIndex = -1
        cboStatus.Text = "OPEN"

        txtTextFilter.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboCarbon.Focus()
    End Sub

    Public Sub ClearVariables()
        StatusFilter = ""
        CarbonFilter = ""
        SteelSizeFilter = ""
        TextFilter = ""
        PartFilter = ""
        FOXFilter = ""
        VendorFilter = ""
        DateFilter = ""
        FOXNumber = 0
        strFOXNumber = ""
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub dgvSteelSpecialOrders_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelSpecialOrders.CellValueChanged
        Dim CheckValue As String = ""
        Dim RMID As String = ""
        Dim FOXNumber As Integer = 0
        Dim OrderDate As String = ""
        Dim RequiredDate As String = ""

        If Me.dgvSteelSpecialOrders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvSteelSpecialOrders.CurrentCell.RowIndex

            Try
                CheckValue = Me.dgvSteelSpecialOrders.Rows(RowIndex).Cells("OnOrderColumn").Value
            Catch ex As NullReferenceException
                CheckValue = "NO"
            End Try
            Try
                RMID = Me.dgvSteelSpecialOrders.Rows(RowIndex).Cells("RMIDColumn").Value
            Catch ex As NullReferenceException
                RMID = ""
            End Try
            Try
                FOXNumber = Me.dgvSteelSpecialOrders.Rows(RowIndex).Cells("FOXNumberColumn").Value
            Catch ex As NullReferenceException
                FOXNumber = 0
            End Try
            Try
                OrderDate = Me.dgvSteelSpecialOrders.Rows(RowIndex).Cells("OrderDateColumn").Value
            Catch ex As NullReferenceException
                OrderDate = ""
            End Try
            Try
                RequiredDate = Me.dgvSteelSpecialOrders.Rows(RowIndex).Cells("EstDeliveryDateColumn").Value
            Catch ex As NullReferenceException
                RequiredDate = ""
            End Try

            If CheckValue = "NO" Then
                Dim button As DialogResult = MessageBox.Show("Do you wish to re-open this suggested order?", "ORDER STEEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Update order to closed
                    cmd = New SqlCommand("UPDATE SteelSpecialOrders SET Status = @Status, OnOrder = @OnOrder, PurchaseAgent = @PurchaseAgent WHERE RMID = @RMID AND FOXNumber = @FOXNumber AND OrderDate = @OrderDate", con)

                    With cmd.Parameters
                        .Add("@RMID", SqlDbType.VarChar).Value = RMID
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                        .Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@OnOrder", SqlDbType.VarChar).Value = "NO"
                        .Add("@PurchaseAgent", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ShowData()
                ElseIf button = DialogResult.No Then
                    'Do nothing
                End If
            Else
                Dim button As DialogResult = MessageBox.Show("Has steel been ordered for this FOX or do you wish to close this order?", "ORDER STEEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Update order to closed
                    cmd = New SqlCommand("UPDATE SteelSpecialOrders SET Status = @Status, OnOrder = @OnOrder, PurchaseAgent = @PurchaseAgent WHERE RMID = @RMID AND FOXNumber = @FOXNumber AND OrderDate = @OrderDate", con)

                    With cmd.Parameters
                        .Add("@RMID", SqlDbType.VarChar).Value = RMID
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                        .Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                        .Add("@OnOrder", SqlDbType.VarChar).Value = "YES"
                        .Add("@PurchaseAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Create Calendar Event
                    Dim CalendarEvent As AppointmentItem

                    CalendarEvent = DirectCast(OLApp.CreateItem(OlItemType.olAppointmentItem), AppointmentItem)
                    CalendarEvent.Start = OrderDate
                    CalendarEvent.End = RequiredDate
                    CalendarEvent.Location = "TFP Purchasing Dept."
                    CalendarEvent.Subject = "ORDER STEEL - FOX # " + strFOXNumber
                    CalendarEvent.Body = "This is a request to order steel for this FOX."
                    CalendarEvent.AllDayEvent = True
                    CalendarEvent.ReminderPlaySound = True
                    CalendarEvent.ReminderSet = True
                    CalendarEvent.ResponseRequested = True

                    CalendarEvent.Save()

                    ShowData()
                ElseIf button = DialogResult.No Then
                    'Do nothing
                End If
            End If
        End If
    End Sub

    Private Sub dgvSteelSpecialOrders_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSteelSpecialOrders.CurrentCellDirtyStateChanged
        If dgvSteelSpecialOrders.IsCurrentCellDirty Then
            dgvSteelSpecialOrders.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintSteelSpecialOrders As New PrintSteelSpecialOrders
            Dim Result = NewPrintSteelSpecialOrders.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdOpenSteelPOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenSteelPOForm.Click
        Dim NewSteelPurchaseOrderForm As New SteelPurchaseOrder
        NewSteelPurchaseOrderForm.Show()
    End Sub
End Class