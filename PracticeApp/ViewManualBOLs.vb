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
Public Class ViewManualBOLs
    Inherits System.Windows.Forms.Form

    Dim CustomerFilter, ShipViaFilter, TextFilter, DateFilter As String
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewManualBOLs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub ClearDataInDatagrid()
        cboBOLNumber.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboShipVia.Text <> "" Then
            ShipViaFilter = " AND ShipVia = '" + cboShipVia.Text + "'"
        Else
            ShipViaFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (ShipVia LIKE '%" + txtTextFilter.Text + "%' OR CustomerID LIKE '%" + txtTextFilter.Text + "%' OR Address1 LIKE '%" + txtTextFilter.Text + "%' OR Address2 LIKE '%" + txtTextFilter.Text + "%' OR City LIKE '%" + txtTextFilter.Text + "%' OR State LIKE '%" + txtTextFilter.Text + "%' OR Zip LIKE '%" + txtTextFilter.Text + "%' OR Country LIKE '%" + txtTextFilter.Text + "%' OR FreightQuoteNumber LIKE '%" + txtTextFilter.Text + "%' OR SpecialInstructions LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM ShipmentBOLTable WHERE DivisionID = @DivisionID" + CustomerFilter + ShipViaFilter + TextFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentBOLTable")
        dgvShipmentBOL.DataSource = ds.Tables("ShipmentBOLTable")
        cboBOLNumber.DataSource = ds.Tables("ShipmentBOLTable")
        con.Close()
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadShipVia()
        cmd = New SqlCommand("SELECT ShipMethID FROM ShipMethod", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds1, "ShipMethod")
        cboShipVia.DataSource = ds2.Tables("ShipMethod")
        con.Close()
        cboShipVia.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerList()
        LoadCustomerName()
        LoadShipVia()
        ClearData()
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1

        txtTextFilter.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdPrintBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintBOL.Click
        GlobalBOLNumber = Val(cboBOLNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintShippingBOLMultiple As New PrintShippingBOLMultiple
            Dim Result = NewPrintShippingBOLMultiple.ShowDialog
        End Using
    End Sub

    Private Sub RePrintBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RePrintBOLToolStripMenuItem.Click
        GlobalBOLNumber = Val(cboBOLNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintShippingBOLMultiple As New PrintShippingBOLMultiple
            Dim Result = NewPrintShippingBOLMultiple.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvShipmentBOL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentBOL.CellDoubleClick
        Dim RowBOLNumber As Integer
        Dim RowIndex As Integer = Me.dgvShipmentBOL.CurrentCell.RowIndex

        RowBOLNumber = Me.dgvShipmentBOL.Rows(RowIndex).Cells("ShipmentBOLNumberColumn").Value

        GlobalBOLNumber = RowBOLNumber
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintShippingBOLMultiple As New PrintShippingBOLMultiple
            Dim Result = NewPrintShippingBOLMultiple.ShowDialog
        End Using
    End Sub

    Private Sub dgvShipmentBOL_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentBOL.CellValueChanged
        Dim TotalBoxes, TotalPallets, TotalWeight As Double
        Dim ShipDate, Address1, Address2, City, State, Zip, Country, ShipVia, FreightQuoteNumber, SpecialInstructions As String
        Dim ShipmentBOLNumber As Integer

        If Me.dgvShipmentBOL.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentBOL.CurrentCell.RowIndex

            Try
                ShipmentBOLNumber = Me.dgvShipmentBOL.Rows(RowIndex).Cells("ShipmentBOLNumberColumn").Value
            Catch ex As Exception
                ShipmentBOLNumber = 0
            End Try
            Try
                ShipDate = Me.dgvShipmentBOL.Rows(RowIndex).Cells("ShipDateColumn").Value
            Catch ex As Exception
                ShipDate = ""
            End Try
            Try
                Address1 = Me.dgvShipmentBOL.Rows(RowIndex).Cells("Address1Column").Value
            Catch ex As Exception
                Address1 = ""
            End Try
            Try
                Address2 = Me.dgvShipmentBOL.Rows(RowIndex).Cells("Address2Column").Value
            Catch ex As Exception
                Address2 = ""
            End Try
            Try
                City = Me.dgvShipmentBOL.Rows(RowIndex).Cells("CityColumn").Value
            Catch ex As Exception
                City = ""
            End Try
            Try
                State = Me.dgvShipmentBOL.Rows(RowIndex).Cells("StateColumn").Value
            Catch ex As Exception
                State = ""
            End Try
            Try
                Zip = Me.dgvShipmentBOL.Rows(RowIndex).Cells("ZipColumn").Value
            Catch ex As Exception
                Zip = 0
            End Try
            Try
                Country = Me.dgvShipmentBOL.Rows(RowIndex).Cells("CountryColumn").Value
            Catch ex As Exception
                Country = 0
            End Try
            Try
                ShipVia = Me.dgvShipmentBOL.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As Exception
                ShipVia = ""
            End Try
            Try
                FreightQuoteNumber = Me.dgvShipmentBOL.Rows(RowIndex).Cells("FreightQuoteNumberColumn").Value
            Catch ex As Exception
                FreightQuoteNumber = ""
            End Try
            Try
                SpecialInstructions = Me.dgvShipmentBOL.Rows(RowIndex).Cells("SpecialInstructionsColumn").Value
            Catch ex As Exception
                SpecialInstructions = ""
            End Try
            Try
                TotalBoxes = Me.dgvShipmentBOL.Rows(RowIndex).Cells("TotalBoxesColumn").Value
            Catch ex As Exception
                TotalBoxes = 0
            End Try
            Try
                TotalPallets = Me.dgvShipmentBOL.Rows(RowIndex).Cells("TotalPalletsColumn").Value
            Catch ex As Exception
                TotalPallets = 0
            End Try
            Try
                TotalWeight = Me.dgvShipmentBOL.Rows(RowIndex).Cells("TotalWeightColumn").Value
            Catch ex As Exception
                TotalWeight = 0
            End Try

            Try
                'UPDATE Shipment Header Table
                cmd = New SqlCommand("UPDATE ShipmentBOLTable SET ShipDate = @ShipDate, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, TotalBoxes = @TotalBoxes, TotalPallets = @TotalPallets, ActualWeight = @ActualWeight, ShipVia = @ShipVia, FreightQuoteNumber = @FreightQuoteNumber, SpecialInstructions = @SpecialInstructions WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = ShipmentBOLNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                    .Add("@Address1", SqlDbType.VarChar).Value = Address1
                    .Add("@Address2", SqlDbType.VarChar).Value = Address2
                    .Add("@City", SqlDbType.VarChar).Value = City
                    .Add("@State", SqlDbType.VarChar).Value = State
                    .Add("@Zip", SqlDbType.VarChar).Value = Zip
                    .Add("@Country", SqlDbType.VarChar).Value = Country
                    .Add("@TotalBoxes", SqlDbType.VarChar).Value = TotalBoxes
                    .Add("@TotalPallets", SqlDbType.VarChar).Value = TotalPallets
                    .Add("@ActualWeight", SqlDbType.VarChar).Value = TotalWeight
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = FreightQuoteNumber
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        Else
            'Skip update
        End If
    End Sub

    Private Sub cmdOpenBOLForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenBOLForm.Click
        Dim RowBOLNumber As Integer
        Dim RowIndex As Integer = Me.dgvShipmentBOL.CurrentCell.RowIndex

        RowBOLNumber = Me.dgvShipmentBOL.Rows(RowIndex).Cells("ShipmentBOLNumberColumn").Value

        GlobalBOLNumber = RowBOLNumber
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewShipmentBOLForm As New ShipmentBOLForm
        NewShipmentBOLForm.Show()
    End Sub
End Class