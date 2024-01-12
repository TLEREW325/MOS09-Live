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
Public Class ShipmentNaftaForm
    Inherits System.Windows.Forms.Form

    Dim IsLoaded As Boolean = False

    Dim ShipToName, CustomerName, ShipZip, ShipState, ShipCity, ShipCountry, ShipAddress1, ShipAddress2, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToZip, ShipToCountry, ShipToState As String
    Dim LastNaftaNumber, NextNaftaNumber As Integer
    Dim ShipDate, BeginDate, EndDate As Date
    Dim NaftaCustomerID, NaftaShipToID, NaftaShipToName, NaftaAddress1, NaftaAddress2, NaftaCity, NaftaState, NaftaZipCode, NaftaCountry, NaftaShipVia, NaftaShipMethod, NaftaSpecialInstructions, NaftaThirdPartyShipper, NaftaShipDate As String
    Dim NaftaTotalPallets, NaftaTotalBoxes, NaftaTotalWeight, NaftaTotalAmount As Double
    Dim ShipMethod, CheckShippingMethod, CurrencyType As String
    Dim strBeginDate, strEndDate As String

    Dim LineQuantity, LinePrice, LineExtendedAmount As Double
    Dim PalletWeight As Double = 0

    'Variable for third party billing
    Dim BillToAddress, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToName As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ShipmentNaftaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()

        IsLoaded = False

        'Set Company Default
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TFP" Or EmployeeCompanyCode = "TWD" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearVariables()
        ClearData()

        IsLoaded = True
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
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
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

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey ORDER BY ShipmentNaftaLineKey", con)
        cmd.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentNaftaLineTable")
        dgvShipmentNaftaLines.DataSource = ds.Tables("ShipmentNaftaLineTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvShipmentNaftaLines.DataSource = Nothing
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
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

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadAdditionalShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "AdditionalShipTo")
        cboShipToID.DataSource = ds3.Tables("AdditionalShipTo")
        con.Close()
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartDescription.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNaftaKey()
        cmd = New SqlCommand("SELECT ShipmentNaftaKey FROM ShipmentNaftaTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNaftaKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "ShipmentNaftaTable")
        cboShipmentNaftaKey.DataSource = ds6.Tables("ShipmentNaftaTable")
        con.Close()
        cboShipmentNaftaKey.SelectedIndex = -1
    End Sub

    Public Sub UpdateHeaderTable()
        'Validate Header Data
        If cboCustomerID.Text = "" Or cboShipmentNaftaKey.Text = "" Or Val(cboShipmentNaftaKey.Text) = 0 Then
            MsgBox("You must have a valid customer and NAFTA Key.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim TempTotalBoxes As Integer = 0
        Dim TempTotalPallets As Integer = 0
        Dim TempTotalWeight As Integer = 0

        TempTotalBoxes = Math.Round(Val(txtTotalBoxes.Text), 0)
        TempTotalPallets = Math.Round(Val(txtTotalPallets.Text), 0)
        TempTotalWeight = Math.Round(Val(txtActualWeight.Text), 0)

        Try
            'Write Data to header table
            cmd = New SqlCommand("UPDATE ShipmentNaftaTable SET CustomerID = @CustomerID, ShipToID = @ShipToID, ShipToName = @ShipToName, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, ZipCode = @ZipCode, Country = @Country, TotalBoxes = @TotalBoxes, TotalPallets = @TotalPallets, TotalWeight = @TotalWeight, TotalAmount = @TotalAmount, ShipVia = @ShipVia, ShipMethod = @ShipMethod, SpecialInstructions = @SpecialInstructions, ThirdPartyShipper = @ThirdPartyShipper, ShipDate = @ShipDate, CurrencyType = @CurrencyType, BillToAddress = @BillToAddress WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@ShipToName", SqlDbType.VarChar).Value = txtCustomerName.Text
                .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                .Add("@ZipCode", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                .Add("@TotalBoxes", SqlDbType.VarChar).Value = TempTotalBoxes
                .Add("@TotalPallets", SqlDbType.VarChar).Value = TempTotalPallets
                .Add("@TotalWeight", SqlDbType.VarChar).Value = TempTotalWeight
                .Add("@TotalAmount", SqlDbType.VarChar).Value = NaftaTotalAmount
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                .Add("@CurrencyType", SqlDbType.VarChar).Value = cboCurrencyType.Text
                .Add("@BillToAddress", SqlDbType.VarChar).Value = txtBillToAddress.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempNaftaKey As Integer = 0
            Dim strNaftaKey As String
            TempNaftaKey = Val(cboShipmentNaftaKey.Text)
            strNaftaKey = CStr(TempNaftaKey)

            ErrorDate = Today()
            ErrorComment = "Error Updating Header Table"
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Nafta Form --- Update Header"
            ErrorReferenceNumber = "Shipment Nafta # " + strNaftaKey
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdGenerateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNew.Click
        Dim TempTotalBoxes As Integer = 0
        Dim TempTotalPallets As Integer = 0
        Dim TempTotalWeight As Integer = 0

        TempTotalBoxes = Math.Round(Val(txtTotalBoxes.Text), 0)
        TempTotalPallets = Math.Round(Val(txtTotalPallets.Text), 0)
        TempTotalWeight = Math.Round(Val(txtActualWeight.Text), 0)

        'Get next Nafta Number
        Dim MAXNaftaStatement As String = "SELECT MAX(ShipmentNaftaKey) FROM ShipmentNaftaTable"
        Dim MAXNaftaCommand As New SqlCommand(MAXNaftaStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastNaftaNumber = CInt(MAXNaftaCommand.ExecuteScalar)
        Catch ex As Exception
            LastNaftaNumber = 440000
        End Try
        con.Close()

        NextNaftaNumber = LastNaftaNumber + 1

        Try
            'Write Data to header table
            cmd = New SqlCommand("INSERT INTO ShipmentNaftaTable (ShipmentNaftaKey, DivisionID, CustomerID, ShipToID, ShipToName, Address1, Address2, City, State, ZipCode, Country, TotalBoxes, TotalPallets, TotalWeight, TotalAmount, ShipVia, ShipMethod, SpecialInstructions, ThirdPartyShipper, ShipDate, CurrencyType, BillToAddress) values (@ShipmentNaftaKey, @DivisionID, @CustomerID, @ShipToID, @ShipToName, @Address1, @Address2, @City, @State, @ZipCode, @Country, @TotalBoxes, @TotalPallets, @TotalWeight, @TotalAmount, @ShipVia, @ShipMethod, @SpecialInstructions, @ThirdPartyShipper, @ShipDate, @CurrencyType, @BillToAddress)", con)

            With cmd.Parameters
                .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = NextNaftaNumber
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@ShipToName", SqlDbType.VarChar).Value = txtCustomerName.Text
                .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                .Add("@ZipCode", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                .Add("@TotalBoxes", SqlDbType.VarChar).Value = TempTotalBoxes
                .Add("@TotalPallets", SqlDbType.VarChar).Value = TempTotalPallets
                .Add("@TotalWeight", SqlDbType.VarChar).Value = TempTotalWeight
                .Add("@TotalAmount", SqlDbType.VarChar).Value = 0
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = ""
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                .Add("@CurrencyType", SqlDbType.VarChar).Value = cboCurrencyType.Text
                .Add("@BillToAddress", SqlDbType.VarChar).Value = txtBillToAddress.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cboShipmentNaftaKey.Text = NextNaftaNumber
        Catch ex As Exception
            'Log error on update failure
            Dim TempNaftaKey As Integer = 0
            Dim strNaftaKey As String
            TempNaftaKey = Val(cboShipmentNaftaKey.Text)
            strNaftaKey = CStr(TempNaftaKey)

            ErrorDate = Today()
            ErrorComment = "Error creating new Shipment NAFTA Doc"
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Nafta Form --- Insert New"
            ErrorReferenceNumber = "Shipment Nafta # " + strNaftaKey
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub ClearLines()
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""

        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        txtLinePrice.Clear()
        txtLineBoxes.Clear()
        txtLineExtendedAmount.Clear()
        txtLineQuantity.Clear()
        txtLineWeight.Clear()

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboShipToID.Text = ""
        cboShipVia.Text = ""
        cboState.Text = ""
        cboShipMethod.Text = ""
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboShipToID.Text = ""
        cboShipmentNaftaKey.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboState.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboShipmentNaftaKey.SelectedIndex = -1
        cboCurrencyType.SelectedIndex = -1

        txtActualWeight.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtCountry.Clear()
        txtCustomerName.Clear()
        txtLineBoxes.Clear()
        txtLineExtendedAmount.Clear()
        txtLinePrice.Clear()
        txtLineQuantity.Clear()
        txtLineWeight.Clear()
        txtThirdPartyShipper.Clear()
        txtTotalAmount.Clear()
        txtTotalBoxes.Clear()
        txtTotalPallets.Clear()
        txtZip.Clear()
        txtSpecialInstructions.Clear()
        txtBillToAddress.Clear()

        dtpShipDate.Text = ""

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        BillToAddress = ""
        ShipToName = ""
        CustomerName = ""
        ShipZip = ""
        ShipState = ""
        ShipCity = ""
        ShipCountry = ""
        ShipAddress1 = ""
        ShipAddress2 = ""
        ShipToAddress1 = ""
        ShipToAddress2 = ""
        ShipToCity = ""
        ShipToZip = ""
        ShipToCountry = ""
        ShipToState = ""
        LastNaftaNumber = 0
        NextNaftaNumber = 0
        NaftaCustomerID = ""
        NaftaShipToID = ""
        NaftaShipToName = ""
        NaftaAddress1 = ""
        NaftaAddress2 = ""
        NaftaCity = ""
        NaftaState = ""
        NaftaZipCode = ""
        NaftaCountry = ""
        NaftaShipVia = ""
        NaftaShipMethod = ""
        NaftaSpecialInstructions = ""
        NaftaThirdPartyShipper = ""
        NaftaShipDate = "'"
        NaftaTotalPallets = 0
        NaftaTotalBoxes = 0
        NaftaTotalWeight = 0
        NaftaTotalAmount = 0
        ShipMethod = ""
        CheckShippingMethod = ""
        CurrencyType = ""
        strBeginDate = ""
        strEndDate = ""

    End Sub

    Public Sub ValidateShippingMethod()
        ShipMethod = cboShipMethod.Text

        Select Case ShipMethod
            Case "COLLECT"
                CheckShippingMethod = ""
            Case "PREPAID"
                CheckShippingMethod = ""
            Case "PREPAID/ADD"
                'Do nothing
            Case "THIRD PARTY"
                If txtThirdPartyShipper.Text = "" Then
                    MsgBox("You must fill-in third party shipping info", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    txtThirdPartyShipper.Focus()
                    Exit Sub
                End If
            Case "OTHER"
                CheckShippingMethod = ""
            Case Else
                MsgBox("You must select a valid Shipping Method", MsgBoxStyle.OkOnly)
                CheckShippingMethod = "EXIT SUB"
                cboShipMethod.Focus()
                Exit Sub
        End Select
    End Sub

    Public Sub LoadAddShippingData()
        Dim AddAddress1, AddAddress2, AddCity, AddState, AddZipCode, AddCountry, AddName As String

        Dim GetAddShippingDataString As String = "SELECT * FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetAddShippingDataCommand As New SqlCommand(GetAddShippingDataString, con)
        GetAddShippingDataCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
        GetAddShippingDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetAddShippingDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetAddShippingDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Address1")) Then
                AddAddress1 = ""
            Else
                AddAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                AddAddress2 = ""
            Else
                AddAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                AddCity = ""
            Else
                AddCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                AddState = ""
            Else
                AddState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                AddZipCode = ""
            Else
                AddZipCode = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                AddCountry = ""
            Else
                AddCountry = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("Name")) Then
                AddName = ""
            Else
                AddName = reader.Item("Name")
            End If
        Else
            AddAddress1 = ""
            AddAddress2 = ""
            AddCity = ""
            AddState = ""
            AddZipCode = ""
            AddCountry = ""
            AddName = ""
        End If
        reader.Close()
        con.Close()

        txtCity.Text = AddCity
        txtAddress1.Text = AddAddress1
        txtAddress2.Text = AddAddress2
        txtZip.Text = AddZipCode
        cboState.Text = AddState
        txtCountry.Text = AddCountry
        txtCustomerName.Text = AddName
    End Sub

    Public Sub LoadCustomerData()
        Dim ShipAddress1Statement As String = "SELECT ShipToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipAddress1Command As New SqlCommand(ShipAddress1Statement, con)
        ShipAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipAddress2Statement As String = "SELECT ShipToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipAddress2Command As New SqlCommand(ShipAddress2Statement, con)
        ShipAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCityStatement As String = "SELECT ShipToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipCityCommand As New SqlCommand(ShipCityStatement, con)
        ShipCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipStateStatement As String = "SELECT ShipToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipStateCommand As New SqlCommand(ShipStateStatement, con)
        ShipStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipZipStatement As String = "SELECT ShipToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipZipCommand As New SqlCommand(ShipZipStatement, con)
        ShipZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCountryStatement As String = "SELECT ShipToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipCountryCommand As New SqlCommand(ShipCountryStatement, con)
        ShipCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipNameCommand As New SqlCommand(ShipNameStatement, con)
        ShipNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipAddress1 = CStr(ShipAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipAddress1 = ""
        End Try
        Try
            ShipAddress2 = CStr(ShipAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipAddress2 = ""
        End Try
        Try
            ShipCity = CStr(ShipCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipCity = ""
        End Try
        Try
            ShipState = CStr(ShipStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipState = ""
        End Try
        Try
            ShipZip = CStr(ShipZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipZip = ""
        End Try
        Try
            ShipCountry = CStr(ShipCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipCountry = ""
        End Try
        Try
            CustomerName = CStr(ShipNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerName = ""
        End Try
        con.Close()

        txtAddress1.Text = ShipAddress1
        txtAddress2.Text = ShipAddress2
        txtCity.Text = ShipCity
        txtCountry.Text = ShipCountry
        txtZip.Text = ShipZip
        cboState.Text = ShipState
        txtCustomerName.Text = CustomerName

        If cboCustomerID.Text = "TFP VANCOUVER" Then
            txtSpecialInstructions.Text = "BROKER:  CARSON"
        ElseIf cboCustomerID.Text = "TFP TORONTO" Then
            txtSpecialInstructions.Text = "BROKER:  CARSON"
        ElseIf cboCustomerID.Text = "LESATTACHES" Then
            txtSpecialInstructions.Text = "BROKER:  JOURNEY"
        ElseIf cboCustomerID.Text = "JORDAHL" Then
            txtSpecialInstructions.Text = "BROKER:  WILLIAM L RUTHERFORD"
        ElseIf cboCustomerID.Text = "TFP ALBERTA" Then
            txtSpecialInstructions.Text = "BROKER:  CARSON"
        ElseIf cboCustomerID.Text = "REDDARC" Then
            txtSpecialInstructions.Text = "BROKER:  BOLLORE LOGISTICS"
        Else
            'Do nothing
        End If
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
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

    Public Sub LoadDateFilter()
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim BeginDayOfDate, BeginMonthOfDate, BeginYearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

        ShipDate = Today()

        DayOfDate = ShipDate.Day
        MonthOfDate = ShipDate.Month
        YearOfDate = ShipDate.Year

        If DayOfDate > 10 Then
            BeginDayOfDate = DayOfDate - 10
            BeginMonthOfDate = MonthOfDate
            BeginYearOfDate = YearOfDate
        ElseIf DayOfDate <= 10 Then
            If MonthOfDate = 1 Then
                BeginMonthOfDate = 12
                BeginYearOfDate = YearOfDate - 1
                BeginDayOfDate = 30 - (10 - DayOfDate)
            ElseIf MonthOfDate = 3 Then
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 28 - (10 - DayOfDate)
            Else
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 30 - (10 - DayOfDate)
            End If
        End If

        strDayOfDate = CStr(BeginDayOfDate)
        strMonthOfDate = CStr(BeginMonthOfDate)
        strYearOfDate = CStr(BeginYearOfDate)

        strBeginDate = strMonthOfDate + "/" + strDayOfDate + "/" + strYearOfDate
        GlobalNaftaDate = strBeginDate.ToString()
        GlobalNAFTAShipDate = strBeginDate.ToString()
    End Sub

    Public Sub LoadNaftaAddress()
        Dim GetNaftaAddressString As String = "SELECT * FROM ShipmentNaftaTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND DivisionID = @DivisionID"
        Dim GetNaftaAddressCommand As New SqlCommand(GetNaftaAddressString, con)
        GetNaftaAddressCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
        GetNaftaAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetNaftaAddressCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipToID")) Then
                NaftaShipToID = ""
            Else
                NaftaShipToID = reader.Item("ShipToID")
            End If
            If IsDBNull(reader.Item("ShipToName")) Then
                NaftaShipToName = ""
            Else
                NaftaShipToName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                NaftaAddress1 = ""
            Else
                NaftaAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                NaftaAddress2 = ""
            Else
                NaftaAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                NaftaCity = ""
            Else
                NaftaCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                NaftaState = ""
            Else
                NaftaState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("ZipCode")) Then
                NaftaZipCode = ""
            Else
                NaftaZipCode = reader.Item("ZipCode")
            End If
            If IsDBNull(reader.Item("Country")) Then
                NaftaCountry = ""
            Else
                NaftaCountry = reader.Item("Country")
            End If
        Else
            NaftaShipToID = ""
            NaftaShipToName = ""
            NaftaAddress1 = ""
            NaftaAddress2 = ""
            NaftaCity = ""
            NaftaState = ""
            NaftaZipCode = ""
            NaftaCountry = ""
        End If
        reader.Close()
        con.Close()

        cboShipToID.Text = NaftaShipToID
        txtCustomerName.Text = NaftaShipToName
        txtAddress1.Text = NaftaAddress1
        txtAddress2.Text = NaftaAddress2
        txtCity.Text = NaftaCity
        cboState.Text = NaftaState
        txtZip.Text = NaftaZipCode
        txtCountry.Text = NaftaCountry
    End Sub

    Public Sub LoadNaftaShipmentData()
        Dim GetNaftaShipmentDataString As String = "SELECT * FROM ShipmentNaftaTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND DivisionID = @DivisionID"
        Dim GetNaftaShipmentDataCommand As New SqlCommand(GetNaftaShipmentDataString, con)
        GetNaftaShipmentDataCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
        GetNaftaShipmentDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetNaftaShipmentDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerID")) Then
                NaftaCustomerID = ""
            Else
                NaftaCustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("ShipToID")) Then
                NaftaShipToID = ""
            Else
                NaftaShipToID = reader.Item("ShipToID")
            End If
            If IsDBNull(reader.Item("ShipToName")) Then
                NaftaShipToName = ""
            Else
                NaftaShipToName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                NaftaAddress1 = ""
            Else
                NaftaAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                NaftaAddress2 = ""
            Else
                NaftaAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                NaftaCity = ""
            Else
                NaftaCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                NaftaState = ""
            Else
                NaftaState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("ZipCode")) Then
                NaftaZipCode = ""
            Else
                NaftaZipCode = reader.Item("ZipCode")
            End If
            If IsDBNull(reader.Item("Country")) Then
                NaftaCountry = ""
            Else
                NaftaCountry = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("TotalBoxes")) Then
                NaftaTotalBoxes = 0
            Else
                NaftaTotalBoxes = reader.Item("TotalBoxes")
            End If
            If IsDBNull(reader.Item("TotalPallets")) Then
                NaftaTotalPallets = 0
            Else
                NaftaTotalPallets = reader.Item("TotalPallets")
            End If
            If IsDBNull(reader.Item("TotalWeight")) Then
                NaftaTotalWeight = 0
            Else
                NaftaTotalWeight = reader.Item("TotalWeight")
            End If
            If IsDBNull(reader.Item("TotalAmount")) Then
                NaftaTotalAmount = 0
            Else
                NaftaTotalAmount = reader.Item("TotalAmount")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                NaftaShipVia = ""
            Else
                NaftaShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("ShipMethod")) Then
                NaftaShipMethod = ""
            Else
                NaftaShipMethod = reader.Item("ShipMethod")
            End If
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                NaftaSpecialInstructions = ""
            Else
                NaftaSpecialInstructions = reader.Item("SpecialInstructions")
            End If
            If IsDBNull(reader.Item("ThirdPartyShipper")) Then
                NaftaThirdPartyShipper = ""
            Else
                NaftaThirdPartyShipper = reader.Item("ThirdPartyShipper")
            End If
            If IsDBNull(reader.Item("ShipDate")) Then
                NaftaShipDate = dtpShipDate.Value
            Else
                NaftaShipDate = reader.Item("ShipDate")
            End If
            If IsDBNull(reader.Item("CurrencyType")) Then
                CurrencyType = "US DOLLARS"
            Else
                CurrencyType = reader.Item("CurrencyType")
            End If
            If IsDBNull(reader.Item("BillToAddress")) Then
                BillToAddress = ""
            Else
                BillToAddress = reader.Item("BillToAddress")
            End If
        Else
            NaftaCustomerID = ""
            NaftaShipToID = ""
            NaftaShipToName = ""
            NaftaAddress1 = ""
            NaftaAddress2 = ""
            NaftaCity = ""
            NaftaState = ""
            NaftaZipCode = ""
            NaftaCountry = ""
            NaftaTotalBoxes = 0
            NaftaTotalWeight = 0
            NaftaTotalPallets = 0
            NaftaTotalAmount = 0
            NaftaShipVia = ""
            NaftaShipMethod = ""
            NaftaSpecialInstructions = ""
            NaftaThirdPartyShipper = ""
            NaftaShipDate = dtpShipDate.Value
            CurrencyType = "US DOLLARS"
            BillToAddress = ""
        End If
        reader.Close()
        con.Close()

        txtSpecialInstructions.Text = NaftaSpecialInstructions
        cboCustomerID.Text = NaftaCustomerID
        cboShipToID.Text = NaftaShipToID
        txtCustomerName.Text = NaftaShipToName
        txtAddress1.Text = NaftaAddress1
        txtAddress2.Text = NaftaAddress2
        txtCity.Text = NaftaCity
        cboState.Text = NaftaState
        txtZip.Text = NaftaZipCode
        txtCountry.Text = NaftaCountry
        txtTotalAmount.Text = FormatCurrency(NaftaTotalAmount, 2)
        txtTotalBoxes.Text = NaftaTotalBoxes
        txtTotalPallets.Text = NaftaTotalPallets
        txtActualWeight.Text = NaftaTotalWeight
        cboShipVia.Text = NaftaShipVia
        cboShipMethod.Text = NaftaShipMethod
        txtThirdPartyShipper.Text = NaftaThirdPartyShipper
        dtpShipDate.Text = NaftaShipDate
        cboCurrencyType.Text = CurrencyType
        txtBillToAddress.Text = BillToAddress
    End Sub

    Public Sub LoadNaftaTotals()
        Dim SumLineBoxesStatement As String = "SELECT SUM(LineBoxes) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim SumLineBoxesCommand As New SqlCommand(SumLineBoxesStatement, con)
        SumLineBoxesCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)

        Dim SumLineWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim SumLineWeightCommand As New SqlCommand(SumLineWeightStatement, con)
        SumLineWeightCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)

        Dim SumExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountStatement, con)
        SumExtendedAmountCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)

        Dim TotalPalletsStatement As String = "SELECT TotalPallets FROM ShipmentNaftaTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim TotalPalletsCommand As New SqlCommand(TotalPalletsStatement, con)
        TotalPalletsCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NaftaTotalBoxes = CDbl(SumLineBoxesCommand.ExecuteScalar)
        Catch ex As Exception
            NaftaTotalBoxes = 0
        End Try
        Try
            NaftaTotalWeight = CDbl(SumLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            NaftaTotalWeight = 0
        End Try
        Try
            NaftaTotalAmount = CDbl(SumExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            NaftaTotalAmount = 0
        End Try
        Try
            NaftaTotalPallets = CDbl(TotalPalletsCommand.ExecuteScalar)
        Catch ex As Exception
            NaftaTotalPallets = 0
        End Try
        con.Close()

        NaftaTotalAmount = Math.Round(NaftaTotalAmount, 2)
        NaftaTotalBoxes = Math.Round(NaftaTotalBoxes, 0)
        NaftaTotalPallets = Math.Round(NaftaTotalPallets, 0)
        NaftaTotalWeight = Math.Round(NaftaTotalWeight, 0)

        txtTotalAmount.Text = FormatCurrency(NaftaTotalAmount, 2)
        txtTotalBoxes.Text = NaftaTotalBoxes
        txtTotalPallets.Text = NaftaTotalPallets
        txtActualWeight.Text = NaftaTotalWeight
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If IsLoaded = True Then
            LoadCustomerData()
            LoadCustomerBillingAddress()
        End If

        IsLoaded = False
        LoadAdditionalShipTo()
        LoadCustomerNameByID()
        IsLoaded = True
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboShipmentNaftaKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipmentNaftaKey.SelectedIndexChanged
        ShowData()
        LoadNaftaShipmentData()
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        If IsLoaded = True Then
            LoadAddShippingData()
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerID()
        LoadCustomerName()
        LoadPartNumber()
        LoadPartDescription()
        LoadShipmentNaftaKey()
    End Sub

    Private Sub cmdAddShipments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddShipments.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalNaftaCustomerID = cboCustomerID.Text
        GlobalNaftaKey = Val(cboShipmentNaftaKey.Text)

        LoadDateFilter()
        UpdateHeaderTable()

        Using NewSelectShipmentsForNafta As New SelectShipmentsForNafta
            Dim Result = NewSelectShipmentsForNafta.ShowDialog()
        End Using

        'Load Totals to refresh Original Form
        cboShipmentNaftaKey.Text = GlobalNaftaKey
        LoadNaftaTotals()
        LoadNaftaAddress()
        ShowData()
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        'Validate Header Data
        If cboCustomerID.Text = "" Or cboShipmentNaftaKey.Text = "" Or Val(cboShipmentNaftaKey.Text) = 0 Then
            MsgBox("You must have a valid customer and Nafta Key.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***************************************************************************************
        'Validate Lines
        If cboPartNumber.Text = "" Then
            MsgBox("You must select a valid part number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboPartDescription.Text = "" Then
            MsgBox("You must select a valid part description.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Not IsNumeric(txtLineQuantity.Text) Then
            MsgBox("You must enter a numeric value.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Not IsNumeric(txtLinePrice.Text) Then
            MsgBox("You must enter a numeric value.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Not IsNumeric(txtLineBoxes.Text) Then
            MsgBox("You must enter a numeric value.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Not IsNumeric(txtLineWeight.Text) Then
            MsgBox("You must enter a numeric value.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**************************************************************************************
        'Save Header Data
        UpdateHeaderTable()
        '**************************************************************************************
        'Get next line number
        Dim LastNaftaLineNumber, NextNaftaLineNumber As Integer

        'Get next Nafta Number
        Dim MAXNaftaLineStatement As String = "SELECT MAX(ShipmentNaftaLineKey) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim MAXNaftaLineCommand As New SqlCommand(MAXNaftaLineStatement, con)
        MAXNaftaLineCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastNaftaLineNumber = CInt(MAXNaftaLineCommand.ExecuteScalar)
        Catch ex As Exception
            LastNaftaLineNumber = 0
        End Try
        con.Close()

        NextNaftaLineNumber = LastNaftaLineNumber + 1

        Try
            'Write Data to header table
            cmd = New SqlCommand("INSERT INTO ShipmentNaftaLineTable (ShipmentNaftaKey, ShipmentNaftaLineKey, ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, UnitPrice, ExtendedAmount, LineBoxes, LineWeight, Class) values (@ShipmentNaftaKey, @ShipmentNaftaLineKey, @ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @UnitPrice, @ExtendedAmount, @LineBoxes, @LineWeight, @Class)", con)

            With cmd.Parameters
                .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
                .Add("@ShipmentNaftaLineKey", SqlDbType.VarChar).Value = NextNaftaLineNumber
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = 0
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@QuantityShipped", SqlDbType.VarChar).Value = Val(txtLineQuantity.Text)
                .Add("@UnitPrice", SqlDbType.VarChar).Value = Val(txtLinePrice.Text)
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtLineExtendedAmount.Text)
                .Add("@LineBoxes", SqlDbType.VarChar).Value = Val(txtLineBoxes.Text)
                .Add("@LineWeight", SqlDbType.VarChar).Value = Val(txtLineWeight.Text)
                .Add("@Class", SqlDbType.VarChar).Value = cboPartNumber.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempNaftaKey As Integer = 0
            Dim strNaftaKey As String
            TempNaftaKey = Val(cboShipmentNaftaKey.Text)
            strNaftaKey = CStr(TempNaftaKey)

            ErrorDate = Today()
            ErrorComment = "Error adding new line"
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Nafta Form --- Insert Line"
            ErrorReferenceNumber = "Shipment Nafta # " + strNaftaKey
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        ShowData()
        LoadNaftaTotals()
        ClearLines()
    End Sub

    Private Sub cmdClearLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLine.Click
        ClearLines()
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Val(cboShipmentNaftaKey.Text) = 0 Or cboShipmentNaftaKey.Text = "" Then
            MsgBox("You must have a valid NAFTA Key.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Prompt before deletion
        Dim button2 As DialogResult = MessageBox.Show("Do you wish to delete this NAFTA Record?", "DELETE NAFTA RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button2 = DialogResult.Yes Then
            Try
                'Delete Doc
                cmd = New SqlCommand("DELETE FROM ShipmentNaftaTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                LoadShipmentNaftaKey()
                ClearVariables()
                ClearData()
                ClearDataInDatagrid()
                MsgBox("NAFTA Document has been deleted.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Error Log
            End Try
        ElseIf button2 = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub PrintNAFTADocsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintNAFTADocsToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Public Sub GetThirdPartyBillingData()
        Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BillToName = CStr(BillToNameCommand.ExecuteScalar)
        Catch ex As Exception
            BillToName = ""
        End Try
        Try
            BillToAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress1 = ""
        End Try
        Try
            BillToAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress2 = ""
        End Try
        Try
            BillToCity = CStr(BillToCityCommand.ExecuteScalar)
        Catch ex As Exception
            BillToCity = ""
        End Try
        Try
            BillToState = CStr(BillToStateCommand.ExecuteScalar)
        Catch ex As Exception
            BillToState = ""
        End Try
        Try
            BillToZip = CStr(BillToZipCommand.ExecuteScalar)
        Catch ex As Exception
            BillToZip = ""
        End Try
        con.Close()

        txtThirdPartyShipper.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Public Sub LoadCustomerBillingAddress()
        If cboCustomerID.Text = "TFP VANCOUVER" Or cboCustomerID.Text = "TFP TORONTO" Then
            Dim BillToName7 As String = ""
            Dim BillToAddress17 As String = ""
            Dim BillToAddress27 As String = ""
            Dim BillToCity7 As String = ""
            Dim BillToState7 As String = ""
            Dim BillToZip7 As String = ""

            BillToName7 = txtCustomerName.Text
            BillToAddress17 = txtAddress1.Text
            BillToAddress27 = txtAddress2.Text
            BillToCity7 = txtCity.Text
            BillToState7 = cboState.Text
            BillToZip7 = txtZip.Text

            txtBillToAddress.Text = BillToName7 + Environment.NewLine + BillToAddress17 + Environment.NewLine + BillToAddress27 + Environment.NewLine + BillToCity7 + ", " + BillToState7 + "  " + BillToZip7
        Else
            Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
            BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
            BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
            BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
            BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
            BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
            BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BillToName = CStr(BillToNameCommand.ExecuteScalar)
            Catch ex As Exception
                BillToName = ""
            End Try
            Try
                BillToAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
            Catch ex As Exception
                BillToAddress1 = ""
            End Try
            Try
                BillToAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
            Catch ex As Exception
                BillToAddress2 = ""
            End Try
            Try
                BillToCity = CStr(BillToCityCommand.ExecuteScalar)
            Catch ex As Exception
                BillToCity = ""
            End Try
            Try
                BillToState = CStr(BillToStateCommand.ExecuteScalar)
            Catch ex As Exception
                BillToState = ""
            End Try
            Try
                BillToZip = CStr(BillToZipCommand.ExecuteScalar)
            Catch ex As Exception
                BillToZip = ""
            End Try
            con.Close()

            txtBillToAddress.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        'Validate
        If cboShipmentNaftaKey.Text = "" Or Val(cboShipmentNaftaKey.Text) = 0 Or cboCurrencyType.Text = "" Then
            MsgBox("You must have a valid NAFTA number and currency type.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Run Save Routine
            UpdateHeaderTable()

            GlobalNaftaKey = Val(cboShipmentNaftaKey.Text)
            GlobalDivisionCode = cboDivisionID.Text
            GlobalNaftaPrintType = "AUTOPRINT"

            Using NewPrintNafta As New PrintNafta
                Dim result = NewPrintNafta.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub txtLineQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineQuantity.TextChanged
        LineQuantity = Val(txtLineQuantity.Text)
        LinePrice = Val(txtLinePrice.Text)

        LineExtendedAmount = LineQuantity * LinePrice
        LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

        txtLineExtendedAmount.Text = LineExtendedAmount
    End Sub

    Private Sub txtLinePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLinePrice.TextChanged
        LineQuantity = Val(txtLineQuantity.Text)
        LinePrice = Val(txtLinePrice.Text)

        LineExtendedAmount = LineQuantity * LinePrice
        LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

        txtLineExtendedAmount.Text = LineExtendedAmount
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Validate fields
        If cboShipmentNaftaKey.Text = "" Or Val(cboShipmentNaftaKey.Text) = 0 Or cboCurrencyType.Text = "" Then
            MsgBox("You must have a valid NAFTA number and currency type.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Validate Data












            'Write to header table
            UpdateHeaderTable()

            MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub dgvShipmentNaftaLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentNaftaLines.CellValueChanged
        Dim RowShipmentNaftaLineKey As Integer
        Dim RowPartNumber, RowPartDescription, RowClass As String
        Dim RowQuantityShipped, RowUnitPrice, RowExtendedAmount, RowLineBoxes, RowLineWeight As Double

        If Me.dgvShipmentNaftaLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentNaftaLines.CurrentCell.RowIndex

            Try
                RowShipmentNaftaLineKey = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("ShipmentNaftaLineKeyColumn").Value
            Catch ex As Exception
                RowShipmentNaftaLineKey = 0
            End Try
            Try
                RowPartNumber = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowPartDescription = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                RowPartDescription = ""
            End Try
            Try
                RowClass = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("ClassColumn").Value
            Catch ex As Exception
                RowClass = ""
            End Try
            Try
                RowQuantityShipped = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("QuantityShippedColumn").Value
            Catch ex As Exception
                RowQuantityShipped = 0
            End Try
            Try
                RowUnitPrice = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("UnitPriceColumn").Value
            Catch ex As Exception
                RowUnitPrice = 0
            End Try
            Try
                RowLineBoxes = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("LineBoxesColumn").Value
            Catch ex As Exception
                RowLineBoxes = 0
            End Try
            Try
                RowLineWeight = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("LineWeightColumn").Value
            Catch ex As Exception
                RowLineWeight = 0
            End Try

            RowExtendedAmount = RowUnitPrice * RowQuantityShipped
            RowExtendedAmount = Math.Round(RowExtendedAmount, 2)

            Try
                'Update NAFTA Lines
                cmd = New SqlCommand("UPDATE ShipmentNaftaLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, QuantityShipped = @QuantityShipped, UnitPrice = @UnitPrice, ExtendedAmount = @ExtendedAmount, LineBoxes = @LineBoxes, LineWeight = @LineWeight, Class = @Class WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND ShipmentNaftaLineKey = @ShipmentNaftaLineKey", con)

                With cmd.Parameters
                    .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
                    .Add("@ShipmentNaftaLineKey", SqlDbType.VarChar).Value = RowShipmentNaftaLineKey
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = RowPartDescription
                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = RowQuantityShipped
                    .Add("@UnitPrice", SqlDbType.VarChar).Value = RowUnitPrice
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = RowExtendedAmount
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = RowLineBoxes
                    .Add("@LineWeight", SqlDbType.VarChar).Value = RowLineWeight
                    .Add("@Class", SqlDbType.VarChar).Value = RowClass
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

            Catch ex As Exception
                'Log error on update failure
                Dim TempNaftaKey As Integer = 0
                Dim strNaftaKey As String
                TempNaftaKey = Val(cboShipmentNaftaKey.Text)
                strNaftaKey = CStr(TempNaftaKey)

                ErrorDate = Today()
                ErrorComment = "Error updating values in datagrid"
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Shipment Nafta Form --- Update datagrid"
                ErrorReferenceNumber = "Shipment Nafta # " + strNaftaKey
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Update Totals
            ShowData()
            UpdateHeaderTable()
            LoadNaftaTotals()
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        Dim RowShipmentNaftaKey, RowShipmentNaftaLineKey As Integer

        If Me.dgvShipmentNaftaLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentNaftaLines.CurrentCell.RowIndex

            Try
                RowShipmentNaftaKey = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("ShipmentNaftaKeyColumn").Value
            Catch ex As Exception
                RowShipmentNaftaKey = 0
            End Try
            Try
                RowShipmentNaftaLineKey = Me.dgvShipmentNaftaLines.Rows(RowIndex).Cells("ShipmentNaftaLineKeyColumn").Value
            Catch ex As Exception
                RowShipmentNaftaLineKey = 0
            End Try

            If RowShipmentNaftaKey <> 0 And RowShipmentNaftaLineKey <> 0 Then
                'Delete Line
                cmd = New SqlCommand("DELETE FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND ShipmentNaftaLineKey = @ShipmentNaftaLineKey", con)

                With cmd.Parameters
                    .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = RowShipmentNaftaKey
                    .Add("@ShipmentNaftaLineKey", SqlDbType.VarChar).Value = RowShipmentNaftaLineKey
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Renumber lines with For/Each loop
                'Update each line number to line number plus 1000
                cmd = New SqlCommand("UPDATE ShipmentNaftaLineTable SET ShipmentNaftaLineKey = ShipmentNaftaLineKey + 1000 WHERE ShipmentNaftaKey = @ShipmentNaftaKey", con)

                With cmd.Parameters
                    .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowData()

                Dim LineCounter As Integer = 1
                Dim RowNaftaLineKey As Integer = 0

                For Each row As DataGridViewRow In dgvShipmentNaftaLines.Rows
                    Try
                        RowNaftaLineKey = row.Cells("ShipmentNaftaLineKeyColumn").Value
                    Catch ex As Exception
                        RowNaftaLineKey = 1
                    End Try
              
                    'Update each line number to counter
                    cmd = New SqlCommand("UPDATE ShipmentNaftaLineTable SET ShipmentNaftaLineKey = @NewShipmentNaftaLineKey WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND ShipmentNaftaLineKey = @ShipmentNaftaLineKey", con)

                    With cmd.Parameters
                        .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = Val(cboShipmentNaftaKey.Text)
                        .Add("@ShipmentNaftaLineKey", SqlDbType.VarChar).Value = RowNaftaLineKey
                        .Add("@NewShipmentNaftaLineKey", SqlDbType.VarChar).Value = LineCounter
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    LineCounter = LineCounter + 1
                Next

                LoadNaftaTotals()
                ShowData()

                MsgBox("Line has been deleted.", MsgBoxStyle.OkOnly)
            Else
                MsgBox("Select a line to be deleted.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
            GetThirdPartyBillingData()
        Else
            txtThirdPartyShipper.Enabled = False
            txtThirdPartyShipper.Clear()
        End If
    End Sub

    Private Sub txtTotalPallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPallets.TextChanged
        txtActualWeight.Text = NaftaTotalWeight
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        If Label4.Text = "Shipping Date" Then
            Label4.Text = "Ship Date"
        Else
            Label4.Text = "Shipping Date"
        End If
    End Sub

    Private Sub PrintCustomsInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCustomsInvoiceToolStripMenuItem.Click
        'Validate
        If cboShipmentNaftaKey.Text = "" Or Val(cboShipmentNaftaKey.Text) = 0 Or cboCurrencyType.Text = "" Then
            MsgBox("You must have a valid NAFTA number and currency type.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Run Save Routine
            UpdateHeaderTable()

            GlobalNaftaKey = Val(cboShipmentNaftaKey.Text)
            GlobalDivisionCode = cboDivisionID.Text
            GlobalNaftaPrintType = "INVOICE"

            Using NewPrintNafta As New PrintNafta
                Dim result = NewPrintNafta.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintNAFTAFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintNAFTAFormToolStripMenuItem.Click
        'Validate
        If cboShipmentNaftaKey.Text = "" Or Val(cboShipmentNaftaKey.Text) = 0 Or cboCurrencyType.Text = "" Then
            MsgBox("You must have a valid NAFTA number and currency type.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Run Save Routine
            UpdateHeaderTable()

            GlobalNaftaKey = Val(cboShipmentNaftaKey.Text)
            GlobalDivisionCode = cboDivisionID.Text
            GlobalNaftaPrintType = "NAFTA"

            Using NewPrintNafta As New PrintNafta
                Dim result = NewPrintNafta.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintELFFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintELFFormToolStripMenuItem.Click
        Dim CashReceiptExists As String = "\\TFP-FS\TransferData\ExportedCerts\ELF.pdf"
        If File.Exists(CashReceiptExists) Then
            System.Diagnostics.Process.Start(CashReceiptExists)
        End If
    End Sub
End Class