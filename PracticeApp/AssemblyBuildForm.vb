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
Public Class AssemblyBuildForm
    Inherits System.Windows.Forms.Form

    Dim GLIssuesAccount, CurrentPartNumber, PreferredVendor, VendorClass, PartDescription, GLInventoryAccount, GetItemClass, AssemblyDescription, ComponentLineComment, ComponentPartNumber, ComponentPartDescription, LongDescription, AssemblyDate, AssemblyComment, SerializedStatus, AssemblySerialNumber As String
    Dim ComponentCost, UnitBuildCost, TransactionCost, AssemblyStandardCost, ComponentUnitCost, ComponentExtendedCost, SumComponentCost As Double
    Dim NextCostingTransactionNumber, LastCostingTransactionNumber, LastInventoryTransactionNumber, NextInventoryTransactionNumber, NextBuildNumber, LastBuildNumber, NextComponentLineNumber, LastComponentLineNumber, CheckSerialNumber As Integer
    Dim LastTransactionNumber, NextTransactionNumber, QuantityMultiplier As Integer
    Dim ComponentQuantity, UpperLimit, LowerLimit, NewUpperLimit As Double
    Dim BuildDate As Date
    Dim TotalAssemblyCost As Double = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isLoaded = False

    Private Sub AssemblyBuildForm_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        ClearVariables()
        ClearData()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 300)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub AssemblyBuildForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        'Set default for division and enable beginning inventory edits
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            chkExchangeRate.Visible = True
            txtExchangeRate.Visible = True
            lblAdjusted.Visible = True
        Else
            chkExchangeRate.Visible = False
            txtExchangeRate.Visible = False
            lblAdjusted.Visible = False
        End If

        isLoaded = True
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            chkExchangeRate.Visible = True
            txtExchangeRate.Visible = True
            lblAdjusted.Visible = True
        Else
            chkExchangeRate.Visible = False
            txtExchangeRate.Visible = False
            lblAdjusted.Visible = False
        End If

        LoadPartNumber()
        LoadPartDescription()
        LoadComponentPartNumber()
        LoadComponentPartDescription()

        ClearData()
        ClearVariables()
    End Sub

    Public Sub ShowData()
        cboDeletePartNumber.Text = ""
        cboDeletePartDescription.Text = ""

        cmd = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblyLineTable")
        dgvAssemblyLines.DataSource = ds.Tables("AssemblyLineTable")
        cboDeletePartNumber.DataSource = ds.Tables("AssemblyLineTable")
        cboDeletePartDescription.DataSource = ds.Tables("AssemblyLineTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAssemblyLines.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboAssemblyPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboAssemblyPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboAssemblyPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboAssemblyPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadComponentPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboComponentPart.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboComponentPart.SelectedIndex = -1
    End Sub

    Public Sub LoadComponentPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboComponentDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboComponentDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboAssemblyPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPartNumber()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboAssemblyPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadComponentPartNumberByDescription()
        Dim ComponentPartNumber1 As String = ""

        Dim ComponentPartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim ComponentPartNumber1Command As New SqlCommand(ComponentPartNumber1Statement, con)
        ComponentPartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboComponentDescription.Text
        ComponentPartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentPartNumber1 = CStr(ComponentPartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            ComponentPartNumber1 = ""
        End Try
        con.Close()

        cboComponentPart.Text = ComponentPartNumber1
    End Sub

    Public Sub LoadComponentDescriptionByPartNumber()
        Dim ComponentPartDescription1 As String = ""

        Dim ComponentPartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ComponentPartDescription1Command As New SqlCommand(ComponentPartDescription1Statement, con)
        ComponentPartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboComponentPart.Text
        ComponentPartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentPartDescription1 = CStr(ComponentPartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            ComponentPartDescription1 = ""
        End Try
        con.Close()

        cboComponentDescription.Text = ComponentPartDescription1
    End Sub

    Public Sub LoadPreferredVendor()
        Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
        PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CurrentPartNumber
        PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
        Catch ex As Exception
            PreferredVendor = ""
        End Try
        con.Close()

        If PreferredVendor = "CANADIAN" Then
            VendorClass = "CANADIAN"
        ElseIf PreferredVendor = "AMERICAN" Then
            VendorClass = "AMERICAN"
        Else
            Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
            VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
            VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorClass = CStr(VendorClassCommand.ExecuteScalar)
            Catch ex As Exception
                VendorClass = "CANADIAN"
            End Try
            con.Close()
        End If
    End Sub

    Public Sub LoadAssemblyData()
        Dim AssemblyDescriptionStatement As String = "SELECT AssemblyDescription FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
        Dim AssemblyDescriptionCommand As New SqlCommand(AssemblyDescriptionStatement, con)
        AssemblyDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AssemblyDescriptionCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text

        Dim PartDescriptionStatement As String = "SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
        PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        PartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AssemblyDescription = CStr(AssemblyDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            AssemblyDescription = ""
        End Try
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            PartDescription = ""
        End Try
        con.Close()

        txtAssemblyDescription.Text = AssemblyDescription
        cboAssemblyPartDescription.Text = PartDescription
    End Sub

    Public Sub LoadTotalCost()
        'Load Total Cost from rows in the datagrid
        If Me.dgvAssemblyLines.RowCount = 0 Then
            'Skip
        Else
            If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
                Dim LineCost As Double = 0
                TotalAssemblyCost = 0
                Dim LinePartNumber As String = ""
                Dim LinePreferredVendor As String = ""
                Dim LineVendorClass As String = ""
                'Get Line Data
                For Each row As DataGridViewRow In dgvAssemblyLines.Rows
                    Try
                        LineCost = row.Cells("ExtendedCostColumn").Value
                    Catch ex As System.Exception
                        LineCost = 0
                    End Try
                    Try
                        LinePartNumber = row.Cells("ComponentPartNumberColumn").Value
                    Catch ex As System.Exception
                        LinePartNumber = ""
                    End Try
                    '***********************************************************************************************************
                    'If check box is checked get preferred vendor on each part and adjust cost for the exchange rate if American
                    If chkExchangeRate.Checked = True And IsNumeric(txtExchangeRate.Text) Then
                        Dim LinePreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                        Dim LinePreferredVendorCommand As New SqlCommand(LinePreferredVendorStatement, con)
                        LinePreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        LinePreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LinePreferredVendor = CStr(LinePreferredVendorCommand.ExecuteScalar)
                        Catch ex As Exception
                            LinePreferredVendor = ""
                        End Try
                        con.Close()
                        '********************************************************************************************************
                        'Look up Vendor Class if applicable
                        If LinePreferredVendor = "CANADIAN" Then
                            'No changes to line cost
                        ElseIf LinePreferredVendor = "AMERICAN" Then
                            LineCost = LineCost * Val(txtExchangeRate.Text)
                            lblAdjusted.Text = "(Adjusted)"
                        Else
                            Dim LineVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                            Dim LineVendorClassCommand As New SqlCommand(LineVendorClassStatement, con)
                            LineVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            LineVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = LinePreferredVendor

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LineVendorClass = CStr(LineVendorClassCommand.ExecuteScalar)
                            Catch ex As Exception
                                LineVendorClass = ""
                            End Try
                            con.Close()
                            '******************************************************************************************************
                            If LineVendorClass = "AMERICAN" Then
                                LineCost = LineCost * Val(txtExchangeRate.Text)
                                lblAdjusted.Text = "(Adjusted)"
                            Else
                                'No changes to line cost
                            End If
                        End If
                    Else
                        'No changes to line cost
                    End If
                    '******************************************************************************
                    TotalAssemblyCost = TotalAssemblyCost + LineCost
                Next
            Else 'Sum Extended Cost in datagrid - no adjustments
                Dim LineCost As Double = 0
                TotalAssemblyCost = 0

                'Get Line Data
                For Each row As DataGridViewRow In dgvAssemblyLines.Rows
                    Try
                        LineCost = row.Cells("ExtendedCostColumn").Value
                    Catch ex As System.Exception
                        LineCost = 0
                    End Try

                    TotalAssemblyCost = TotalAssemblyCost + LineCost
                Next
            End If
            '**************************************************************************
            'Load Total Cost in text box
            txtAssemblyCost.Text = FormatCurrency(TotalAssemblyCost, 4)
        End If
    End Sub

    Public Sub LoadFIFOComponentCost()
        'Get FIFO Cost of components to calculate Total Cost
        '*****************************************************************************************************************************************************
        'Determine FIFO Cost on Part Number to remove from Inventory
        Dim TotalQuantityShipped As Integer = 0
        Dim TotalQuantityAssembled As Integer = 0
        '******************************************************************************************************************************************
        'Determine Total Quantity Shipped
        Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CInt(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityShipped = 1
        End Try
        con.Close()

        'Determine Total Quantity Assembled
        Dim TotalQuantityAssembledStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber"
        Dim TotalQuantityAssembledCommand As New SqlCommand(TotalQuantityAssembledStatement, con)
        TotalQuantityAssembledCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        TotalQuantityAssembledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityAssembled = CInt(TotalQuantityAssembledCommand.ExecuteScalar)
            TotalQuantityAssembled = TotalQuantityAssembled * -1
        Catch ex As Exception
            TotalQuantityAssembled = 0
        End Try
        con.Close()

        TotalQuantityShipped = TotalQuantityShipped + TotalQuantityAssembled
        '******************************************************************************************************************************************
        'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table

        'Get MAX Number
        Dim MAXCostTransactionNumber As Integer = 0

        Dim MAXCostTransactionNumberStatement As String = "SELECT MAX (TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
        Dim MAXCostTransactionNumberCommand As New SqlCommand(MAXCostTransactionNumberStatement, con)
        MAXCostTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        MAXCostTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXCostTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXCostTransactionNumber = CInt(MAXCostTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            MAXCostTransactionNumber = 0
        End Try
        con.Close()

        Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
        Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
        ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
        ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostTransactionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
        Catch ex As Exception
            ComponentUnitCost = 0
        End Try
        con.Close()
        'Get Last Transaction Cost if FIFO Cost is Zero
        If ComponentUnitCost = 0 Then
            Dim MAXDate As Integer = 0

            Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXDate = 0
            End Try
            con.Close()

            Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
            TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
            TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
            Catch ex As Exception
                TransactionCost = 0
            End Try
            con.Close()

            ComponentUnitCost = TransactionCost
        Else
            'Do nothing
        End If

        'Get Stand Cost if FIFO Cost is Zero
        If ComponentUnitCost = 0 Then
            Dim ComponentStandardCost As Double = 0

            Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
            StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboComponentPart.Text
            StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ComponentStandardCost = CDbl(StandardCostCommand.ExecuteScalar)
            Catch ex As Exception
                ComponentStandardCost = 0
            End Try
            con.Close()

            ComponentUnitCost = ComponentStandardCost
        Else
            'Do nothing
        End If

        txtUnitCost.Text = ComponentUnitCost
    End Sub

    Private Sub cboComponentPart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentPart.SelectedIndexChanged
        If isLoaded Then
            LoadFIFOComponentCost()
            LoadComponentDescriptionByPartNumber()
        End If
    End Sub

    Private Sub cboAssemblyPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssemblyPartDescription.SelectedIndexChanged
        LoadPartNumberByDescription()
    End Sub

    Private Sub cboComponentDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentDescription.SelectedIndexChanged
        LoadComponentPartNumberByDescription()
    End Sub

    Public Sub ClearData()
        cboAssemblyPartDescription.Refresh()
        cboAssemblyPartNumber.Refresh()
        cboComponentPart.Refresh()
        cboComponentDescription.Refresh()

        txtBuildComment.Refresh()
        txtBuildQuantity.Refresh()
        txtComponentQuantity.Refresh()
        txtAssemblyCost.Refresh()
        txtExchangeRate.Refresh()

        cboComponentDescription.SelectedIndex = -1
        cboComponentPart.SelectedIndex = -1
        cboAssemblyPartDescription.SelectedIndex = -1
        cboAssemblyPartNumber.SelectedIndex = -1

        txtAssemblyDescription.Clear()
        txtBuildComment.Clear()
        txtBuildQuantity.Clear()
        txtComponentQuantity.Clear()
        txtAssemblyCost.Clear()
        txtExchangeRate.Clear()

        lblAdjusted.Text = ""

        chkExchangeRate.Checked = False
        dtpBuildDate.Text = ""

        cboAssemblyPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        GLInventoryAccount = ""
        GetItemClass = ""
        AssemblyDescription = ""
        ComponentLineComment = ""
        ComponentPartNumber = ""
        ComponentPartDescription = ""
        LongDescription = ""
        AssemblyDate = ""
        AssemblyComment = ""
        SerializedStatus = ""
        AssemblySerialNumber = ""
        ComponentCost = 0
        UnitBuildCost = 0
        TransactionCost = 0
        AssemblyStandardCost = 0
        ComponentUnitCost = 0
        ComponentExtendedCost = 0
        SumComponentCost = 0
        LastInventoryTransactionNumber = 0
        NextInventoryTransactionNumber = 0
        NextCostingTransactionNumber = 0
        LastCostingTransactionNumber = 0
        ComponentQuantity = 0
        NextBuildNumber = 0
        LastBuildNumber = 0
        NextComponentLineNumber = 0
        LastComponentLineNumber = 0
        CheckSerialNumber = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        UpperLimit = 0
        LowerLimit = 0
        NewUpperLimit = 0
        QuantityMultiplier = 0
        PartDescription = ""
        PreferredVendor = ""
        VendorClass = ""
        CurrentPartNumber = ""
        GLIssuesAccount = ""
        TotalAssemblyCost = 0
    End Sub

    Private Sub cmdAddComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddComponent.Click
        'Insert temp components into line table to be deleted later
        If canAddComponent() Then
            ds.Tables("AssemblyLineTable").Rows.Add(cboAssemblyPartNumber.Text, cboComponentPart.Text, cboComponentDescription.Text, txtComponentQuantity.Text, txtUnitCost.Text, Convert.ToDouble(txtComponentQuantity.Text) * Convert.ToDouble(txtUnitCost.Text), "TEMP PART", cboDivisionID.Text)

            'Load Total
            LoadTotalCost()

            'Clear Line Data
            cboComponentPart.SelectedIndex = -1
            cboComponentDescription.SelectedIndex = -1
            txtUnitCost.Clear()
            txtComponentQuantity.Clear()
        End If
    End Sub

    Private Function canAddComponent() As Boolean
        If String.IsNullOrEmpty(cboAssemblyPartNumber.Text) Then
            MessageBox.Show("You must select an assembly part number", "Select assembly part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAssemblyPartNumber.Focus()
            Return False
        End If
        If cboAssemblyPartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid assembly part number", "Enter a valid assembly part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAssemblyPartNumber.SelectAll()
            cboAssemblyPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboComponentPart.Text) Then
            MessageBox.Show("You must select a component part number", "Seelect a componenet part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboComponentPart.Focus()
            Return False
        End If
        If cboComponentPart.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid component part number", "Select valid component part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboComponentPart.SelectAll()
            cboComponentPart.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtComponentQuantity.Text) Then
            MessageBox.Show("You must enter a component quantity", "Enter a component quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComponentQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtComponentQuantity.Text) = False Then
            MessageBox.Show("You must enter a number for quantity", "Enter a numeric quanttiy", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComponentQuantity.SelectAll()
            txtComponentQuantity.Focus()
            Return False
        End If
        If txtComponentQuantity.Text = "0" Then
            MessageBox.Show("You must enter a component quantity greater than zero", "Enter a component quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComponentQuantity.SelectAll()
            txtComponentQuantity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtUnitCost.Text) Then
            MessageBox.Show("You must have a unit cost", "Enter a unit cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.Focus()
            Return False
        End If
        If IsNumeric(txtUnitCost.Text) = False Then
            MessageBox.Show("You must enter a numeric unit cost", "Enter a numeric unit cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.SelectAll()
            txtUnitCost.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteComponent.Click
        Dim currentRow As Integer = dgvAssemblyLines.CurrentCell.RowIndex
        dgvAssemblyLines.Rows.RemoveAt(currentRow)
    End Sub

    Private Sub cmdBuildAssembly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuildAssembly.Click
        If canBuildOrReverse() Then
            BuildDate = dtpBuildDate.Value
  
            'Get next Build Number
            Dim MAXTransactionNumberStatement As String = "SELECT MAX(BuildTransactionNumber) FROM AssemblyBuildHeaderTable"
            Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBuildNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastBuildNumber = 8820000
            End Try
            con.Close()

            NextBuildNumber = LastBuildNumber + 1

            Try
                'Write Data to Assembly Build Header Table
                cmd = New SqlCommand("Insert Into AssemblyBuildHeaderTable(BuildTransactionNumber, AssemblyPartNumber, AssemblyPartDescription, SerialNumber, BuildComment, DivisionID, BuildDate, BuildCost, BuildStatus)Values(@BuildTransactionNumber, @AssemblyPartNumber, @AssemblyPartDescription, @SerialNumber, @BuildComment, @DivisionID, @BuildDate, @BuildCost, @BuildStatus)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@AssemblyPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                    .Add("@BuildComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@BuildCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Header Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************************************************
            'Extract data from grid to write to Line Table
            For Each row As DataGridViewRow In dgvAssemblyLines.Rows
                Try
                    ComponentPartNumber = row.Cells("ComponentPartNumberColumn").Value
                Catch ex As Exception
                    ComponentPartNumber = ""
                End Try
                Try
                    ComponentPartDescription = row.Cells("ComponentPartDescriptionColumn").Value
                Catch ex As Exception
                    ComponentPartDescription = ""
                End Try
                Try
                    ComponentQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    ComponentQuantity = 0
                End Try
                Try
                    ComponentCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    ComponentCost = 0
                End Try
                Try
                    ComponentLineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    ComponentLineComment = 0
                End Try
                '*****************************************************************************************************************************************************
                'Get Item Class of Components to write to the GL
                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = ""
                End Try
                con.Close()
                '******************************************************************************************************************************************************
                'Get GL Accounts for Assembly Components
                Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
                GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GLInventoryAccount = "12100"
                End Try
                con.Close()
                '******************************************************************************************************************************************************
                'Change GL Accounts to CANADIAN if necessary
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CurrentPartNumber = ComponentPartNumber
                    LoadPreferredVendor()
                Else
                    'Do nothing
                End If
                '******************************************************************************************************************************************************
                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                    GLInventoryAccount = "C$" & GLInventoryAccount
                Else
                    'Do nothing - GL Accounts are correct
                End If
                '*****************************************************************************************************************************************************
                'Determine FIFO Cost on Part Number to remove from Inventory
                Dim TotalQuantityShipped As Integer = 0
                Dim TotalQuantityAssembled As Integer = 0
                '******************************************************************************************************************************************
                'Determine Total Quantity Shipped
                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND LineStatus = 'SHIPPED'"
                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityShipped = CInt(TotalQuantityShippedCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantityShipped = 1
                End Try
                con.Close()

                'Determine Total Quantity Assembled
                Dim TotalQuantityAssembledStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber"
                Dim TotalQuantityAssembledCommand As New SqlCommand(TotalQuantityAssembledStatement, con)
                TotalQuantityAssembledCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalQuantityAssembledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityAssembled = CInt(TotalQuantityAssembledCommand.ExecuteScalar)
                    TotalQuantityAssembled = TotalQuantityAssembled * -1
                Catch ex As Exception
                    TotalQuantityAssembled = 0
                End Try
                con.Close()

                TotalQuantityShipped = TotalQuantityShipped + TotalQuantityAssembled
                '******************************************************************************************************************************************
                'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table

                'Get MAX Number
                Dim MAXCostTransactionNumber As Integer = 0

                Dim MAXCostTransactionNumberStatement As String = "SELECT MAX (TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim MAXCostTransactionNumberCommand As New SqlCommand(MAXCostTransactionNumberStatement, con)
                MAXCostTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                MAXCostTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXCostTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXCostTransactionNumber = CInt(MAXCostTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXCostTransactionNumber = 0
                End Try
                con.Close()

                Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
                Catch ex As Exception
                    ComponentUnitCost = 0
                End Try
                con.Close()
                '*****************************************************************************************************************************************
                'Get Last Transaction Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim MAXDate As Integer = 0

                    Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXDate = CInt(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXDate = 0
                    End Try
                    con.Close()

                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        TransactionCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = TransactionCost
                Else
                    'Do nothing
                End If
                '*****************************************************************************************************************************************
                'Get Last Purchase Cost if FIFO Cost is zero
                If ComponentUnitCost = 0 Then
                    Dim LastPurchaseCost As Double = 0
                    Dim MAXDate As Integer = 0

                    Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXDate = CInt(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXDate = 0
                    End Try
                    con.Close()

                    Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MAXDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastPurchaseCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = LastPurchaseCost
                End If
                '*****************************************************************************************************************************************
                'Get Standard Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim ComponentStandardCost As Double = 0

                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ComponentStandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        ComponentStandardCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = ComponentStandardCost
                Else
                    ComponentUnitCost = ComponentCost
                End If

                ComponentExtendedCost = ComponentUnitCost * ComponentQuantity
                '*****************************************************************************************************************************************
                'Calculate totals for multiple entries

                QuantityMultiplier = Val(txtBuildQuantity.Text)

                ComponentExtendedCost = ComponentExtendedCost * QuantityMultiplier
                ComponentQuantity = ComponentQuantity * QuantityMultiplier
                ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
                '*****************************************************************************************************************************************
                'Get Next Line Number
                Dim MAXLineNumber1Statement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildtransactionNumber = @BuildTransactionNumber"
                Dim MAXLineNumber1Command As New SqlCommand(MAXLineNumber1Statement, con)
                MAXLineNumber1Command.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastComponentLineNumber = CInt(MAXLineNumber1Command.ExecuteScalar)
                Catch ex As Exception
                    LastComponentLineNumber = 0
                End Try
                con.Close()

                NextComponentLineNumber = LastComponentLineNumber + 1
                '******************************************************************************************************************************************************
                Try
                    'Write Data to Assembly Build Line Table - Component Part Number
                    cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                        .Add("@BuildQuantity", SqlDbType.VarChar).Value = ComponentQuantity * -1
                        .Add("@BuildUnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                        .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost * -1
                        .Add("@BuildLineComment", SqlDbType.VarChar).Value = ComponentLineComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Line Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                'Write Components to the GL
                Dim MAX1Statement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
                Dim MAX1Command As New SqlCommand(MAX1Statement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastTransactionNumber = CInt(MAX1Command.ExecuteScalar)
                Catch ex As Exception
                    LastTransactionNumber = 85000000
                End Try
                con.Close()

                NextTransactionNumber = LastTransactionNumber + 1
                '******************************************************************************************************************************************************
                'Convert to a positive number
                If ComponentExtendedCost < 0 Then
                    ComponentExtendedCost = ComponentExtendedCost * -1
                End If

                If ComponentQuantity < 0 Then
                    ComponentQuantity = ComponentQuantity * -1
                End If
                '******************************************************************************************************************************************************
                Try
                    'Write to GL Transaction Table - Component Line Data
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BuildDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (NON S/N) --- Insert GL Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                Dim GetPPL As String = ""

                Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPPL = CStr(GetPPLCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPPL = ""
                End Try
                con.Close()
                '*****************************************************************************************************************************************
                If GetPPL = "NON-INVENTORY" Then
                    'Skip - no transaction entry for non-inventory items
                Else
                    'Find Next Transaction Number
                    Dim InventoryTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
                    Dim InventoryTransactionNumber1Command As New SqlCommand(InventoryTransactionNumber1Statement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastInventoryTransactionNumber = CInt(InventoryTransactionNumber1Command.ExecuteScalar)
                    Catch ex As Exception
                        LastInventoryTransactionNumber = 867500000
                    End Try
                    con.Close()

                    NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1
                    '******************************************************************************************************************************************************
                    Try
                        'Add transactions to Inventory Transaction Table
                        cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                        With cmd.Parameters
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                            .Add("@TransactionDate", SqlDbType.VarChar).Value = BuildDate
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "Build Assembly - Components"
                            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = ComponentQuantity
                            .Add("@ItemCost", SqlDbType.VarChar).Value = ComponentUnitCost
                            .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                            .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Inventory Transaction Table"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
            Next
            '******************************************************************************************************
            'After all lines are written to the tables - write the assembly part to the tables
            'Update Cost of Assembly Part in Header Table
            Dim SumComponentCostStatement As String = "SELECT SUM(BuildExtendedCost) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
            Dim SumComponentCostCommand As New SqlCommand(SumComponentCostStatement, con)
            SumComponentCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
            SumComponentCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumComponentCost = CDbl(SumComponentCostCommand.ExecuteScalar)
            Catch ex As Exception
                SumComponentCost = 0
            End Try
            con.Close()

            'Determine the Per Unit Component Cost
            UnitBuildCost = SumComponentCost / Val(txtBuildQuantity.Text)
            '******************************************************************************************************
            Try
                'UPDATE Assembly Build Table with cost
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildCost", SqlDbType.VarChar).Value = UnitBuildCost * -1
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Update Cost Build Header Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Get Item Class of Assembly to write to the GL
            Dim GetItemClass1Statement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetItemClass1Command As New SqlCommand(GetItemClass1Statement, con)
            GetItemClass1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            GetItemClass1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetItemClass = CStr(GetItemClass1Command.ExecuteScalar)
            Catch ex As Exception
                GetItemClass = ""
            End Try
            con.Close()

            'Get GL Accounts for Assembly Components
            Dim GLInventoryAccount1Statement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim GLInventoryAccount1Command As New SqlCommand(GLInventoryAccount1Statement, con)
            GLInventoryAccount1Command.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GLInventoryAccount = CStr(GLInventoryAccount1Command.ExecuteScalar)
            Catch ex As Exception
                GLInventoryAccount = "12100"
            End Try
            con.Close()

            'Change GL Accounts to CANADIAN if necessary
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CurrentPartNumber = cboAssemblyPartNumber.Text
                LoadPreferredVendor()
            Else
                'Do nothing
            End If

            If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                GLInventoryAccount = "C$" & GLInventoryAccount
            Else
                'Do nothing - GL Accounts are correct
            End If
            '******************************************************************************************************
            'Write Assembly Cost (Total Component Cost) to the GL
            'Write Components to the GL
            Dim MAXStatement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastTransactionNumber = 85000000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1

            'Convert to a positive number
            If SumComponentCost < 0 Then
                SumComponentCost = SumComponentCost * -1
            End If

            Try
                'Write to GL Transaction Table - Component Line Data
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly - Full Assembly"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert GL Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            Dim MAXLineNumberStatement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
            Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
            MAXLineNumberCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastComponentLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastComponentLineNumber = 0
            End Try
            con.Close()

            NextComponentLineNumber = LastComponentLineNumber + 1
            '*****************************************************************************************************************************************
            'Find Next Transaction Number
            Dim InventoryTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
            Dim InventoryTransactionNumber2Command As New SqlCommand(InventoryTransactionNumber2Statement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastInventoryTransactionNumber = CInt(InventoryTransactionNumber2Command.ExecuteScalar)
            Catch ex As Exception
                LastInventoryTransactionNumber = 867500000
            End Try
            con.Close()

            NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1

            'Convert to a positive number
            If UnitBuildCost < 0 Then
                UnitBuildCost = UnitBuildCost * -1
            End If

            Try
                'Add transactions to Inventory Transaction Table
                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Build Assembly"
                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text) * UnitBuildCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Invetory Transaction Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************************************
            'Write Data to Assembly Build Line Table - Assembly Part Number
            Try
                cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@BuildQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@BuildUnitCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Assembly Part Number"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Line Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Create Cost Tier for assembly in Costing Table
            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double

            Dim UpperLimitStatement As String = "SELECT MAX(UpperLimit) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimit = 0
            End Try
            con.Close()

            'Get next Transaction Number
            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + Val(txtBuildQuantity.Text) - 1

            'Write Values to Inventory Costing Table
            Try
                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CostingDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "BUILD ASSEMBLY"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = LastCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Inventory Costing Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Update Build Header Table to include updated cost
            Try
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildCost", SqlDbType.VarChar).Value = SumComponentCost
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Update Assembly Build Header Cost"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Reset Form 
            isLoaded = False
            ClearVariables()
            ClearData()
            ShowData()
            isLoaded = True
            MsgBox("Assembly has been built and added to inventory", MsgBoxStyle.OkOnly)
        Else
            MsgBox("Check data and try again.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReverse.Click
        'Verify Build Part Number
        If canBuildOrReverse() Then
            BuildDate = dtpBuildDate.Value
       
            'Get next Build Number
            Dim MAXTransactionNumberStatement As String = "SELECT MAX(BuildTransactionNumber) FROM AssemblyBuildHeaderTable"
            Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBuildNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastBuildNumber = 8820000
            End Try
            con.Close()

            NextBuildNumber = LastBuildNumber + 1

            'Write Data to Assembly Build Header Table
            Try
                cmd = New SqlCommand("Insert Into AssemblyBuildHeaderTable(BuildTransactionNumber, AssemblyPartNumber, AssemblyPartDescription, SerialNumber, BuildComment, DivisionID, BuildDate, BuildCost, BuildStatus)Values(@BuildTransactionNumber, @AssemblyPartNumber, @AssemblyPartDescription, @SerialNumber, @BuildComment, @DivisionID, @BuildDate, @BuildCost, @BuildStatus)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@AssemblyPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                    .Add("@BuildComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@BuildCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Header Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Extract data from grid to write to Line Table
            For Each row As DataGridViewRow In dgvAssemblyLines.Rows
                Try
                    ComponentPartNumber = row.Cells("ComponentPartNumberColumn").Value
                Catch ex As Exception
                    ComponentPartNumber = ""
                End Try
                Try
                    ComponentPartDescription = row.Cells("ComponentPartDescriptionColumn").Value
                Catch ex As Exception
                    ComponentPartDescription = ""
                End Try
                Try
                    ComponentQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    ComponentQuantity = 0
                End Try
                Try
                    ComponentCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    ComponentCost = 0
                End Try
                Try
                    ComponentLineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    ComponentLineComment = 0
                End Try
                '*****************************************************************************************************************************************
                'Get Item Class of Components to write to the GL
                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = ""
                End Try
                con.Close()

                'Get GL Accounts for Assembly Components
                Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
                GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GLInventoryAccount = "12150"
                End Try
                con.Close()

                'Change GL Accounts to CANADIAN if necessary
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CurrentPartNumber = ComponentPartNumber
                    LoadPreferredVendor()
                Else
                    'Do nothing
                End If

                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                    GLInventoryAccount = "C$" & GLInventoryAccount
                    GLIssuesAccount = "C$59790"
                Else
                    GLIssuesAccount = "59790"
                End If
                '*****************************************************************************************************************************************************
                'Determine FIFO Cost on Part Number to remove from Inventory
                Dim TotalQuantityShipped As Integer = 0
                Dim TotalQuantityAssembled As Integer = 0
                '******************************************************************************************************************************************
                'Determine Total Quantity Shipped
                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityShipped = CInt(TotalQuantityShippedCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantityShipped = 1
                End Try
                con.Close()

                'Determine Total Quantity Assembled
                Dim TotalQuantityAssembledStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND AssemblyPartNumber <> ComponentPartNumber"
                Dim TotalQuantityAssembledCommand As New SqlCommand(TotalQuantityAssembledStatement, con)
                TotalQuantityAssembledCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalQuantityAssembledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityAssembled = CInt(TotalQuantityAssembledCommand.ExecuteScalar)
                    TotalQuantityAssembled = TotalQuantityAssembled * -1
                Catch ex As Exception
                    TotalQuantityAssembled = 0
                End Try
                con.Close()

                TotalQuantityShipped = TotalQuantityShipped + TotalQuantityAssembled
                '******************************************************************************************************************************************
                'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table

                'Get MAX Number
                Dim MAXCostTransactionNumber As Integer = 0

                Dim MAXCostTransactionNumberStatement As String = "SELECT MAX (TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim MAXCostTransactionNumberCommand As New SqlCommand(MAXCostTransactionNumberStatement, con)
                MAXCostTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                MAXCostTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXCostTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXCostTransactionNumber = CInt(MAXCostTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXCostTransactionNumber = 0
                End Try
                con.Close()

                Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
                Catch ex As Exception
                    ComponentUnitCost = 0
                End Try
                con.Close()
                '*****************************************************************************************************************************************
                'Get Last Transaction Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim MAXDate As Integer = 0

                    Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXDate = CInt(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXDate = 0
                    End Try
                    con.Close()

                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        TransactionCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = TransactionCost
                Else
                    'Do nothing
                End If
                '*****************************************************************************************************************************************
                If ComponentUnitCost = 0 Then
                    Dim LastPurchaseCost As Double = 0
                    Dim MAXDate As Integer = 0

                    Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXDate = CInt(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXDate = 0
                    End Try
                    con.Close()

                    Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MAXDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastPurchaseCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = LastPurchaseCost
                End If
                '*****************************************************************************************************************************************
                'Get Standard Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim ComponentStandardCost As Double = 0

                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ComponentStandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        ComponentStandardCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = ComponentStandardCost
                Else
                    ComponentUnitCost = ComponentCost
                End If
                '*****************************************************************************************************************************************
                ComponentExtendedCost = ComponentUnitCost * ComponentQuantity
                '*****************************************************************************************************************************************
                'Calculate totals for multiple entries

                QuantityMultiplier = Val(txtBuildQuantity.Text)

                ComponentExtendedCost = ComponentExtendedCost * QuantityMultiplier
                ComponentQuantity = ComponentQuantity * QuantityMultiplier
                ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
                '*****************************************************************************************************************************************
                'Get Next Line Number
                Dim MAXLineNumber1Statement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildtransactionNumber = @BuildTransactionNumber"
                Dim MAXLineNumber1Command As New SqlCommand(MAXLineNumber1Statement, con)
                MAXLineNumber1Command.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastComponentLineNumber = CInt(MAXLineNumber1Command.ExecuteScalar)
                Catch ex As Exception
                    LastComponentLineNumber = 0
                End Try
                con.Close()

                NextComponentLineNumber = LastComponentLineNumber + 1

                'Write Data to Assembly Build Line Table - Component Part Number
                Try
                    cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                        .Add("@BuildQuantity", SqlDbType.VarChar).Value = ComponentQuantity
                        .Add("@BuildUnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                        .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@BuildLineComment", SqlDbType.VarChar).Value = ComponentLineComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Line Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '******************************************************************************************************
                'Write Components to the GL
                Dim MAX1Statement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
                Dim MAX1Command As New SqlCommand(MAX1Statement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastTransactionNumber = CInt(MAX1Command.ExecuteScalar)
                Catch ex As Exception
                    LastTransactionNumber = 85000000
                End Try
                con.Close()

                NextTransactionNumber = LastTransactionNumber + 1

                'Convert to a positive number
                If ComponentExtendedCost < 0 Then
                    ComponentExtendedCost = ComponentExtendedCost * -1
                End If

                If ComponentQuantity < 0 Then
                    ComponentQuantity = ComponentQuantity * -1
                End If

                'Write dual transactions to Inventory/Issues Accounts

                'Write to GL Transaction Table - Component Line Data
                Try
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly - Component"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BuildDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (NON S/N) --- Insert GL Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Write to GL Transaction Table - Component Line Data
                Try
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly - Component"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BuildDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (NON S/N) --- Insert GL Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                'Find Next Transaction Number
                Dim InventoryTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
                Dim InventoryTransactionNumber1Command As New SqlCommand(InventoryTransactionNumber1Statement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastInventoryTransactionNumber = CInt(InventoryTransactionNumber1Command.ExecuteScalar)
                Catch ex As Exception
                    LastInventoryTransactionNumber = 867500000
                End Try
                con.Close()

                NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1

                'Add transactions to Inventory Transaction Table
                Try
                    cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                    With cmd.Parameters
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = BuildDate
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "Un-Build Assembly - Components"
                        .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                        .Add("@Quantity", SqlDbType.VarChar).Value = ComponentQuantity
                        .Add("@ItemCost", SqlDbType.VarChar).Value = ComponentUnitCost
                        .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                        .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Inventory Transaction Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next
            '******************************************************************************************************
            'After all lines are written to the tables - write the assembly part to the tables
            'Update Cost of Assembly Part in Header Table
            Dim SumComponentCostStatement As String = "SELECT SUM(BuildExtendedCost) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
            Dim SumComponentCostCommand As New SqlCommand(SumComponentCostStatement, con)
            SumComponentCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
            SumComponentCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumComponentCost = CDbl(SumComponentCostCommand.ExecuteScalar)
            Catch ex As Exception
                SumComponentCost = 0
            End Try
            con.Close()

            'Determine the Per Unit Component Cost
            UnitBuildCost = SumComponentCost / Val(txtBuildQuantity.Text)

            'UPDATE Assembly Build Table with cost
            Try
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildCost", SqlDbType.VarChar).Value = UnitBuildCost * -1
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Update Assembly Build Header Cost"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Get Item Class of Assembly to write to the GL
            Dim GetItemClass1Statement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetItemClass1Command As New SqlCommand(GetItemClass1Statement, con)
            GetItemClass1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            GetItemClass1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetItemClass = CStr(GetItemClass1Command.ExecuteScalar)
            Catch ex As Exception
                GetItemClass = ""
            End Try
            con.Close()

            'Get GL Accounts for Assembly
            Dim GLInventoryAccount1Statement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim GLInventoryAccount1Command As New SqlCommand(GLInventoryAccount1Statement, con)
            GLInventoryAccount1Command.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GLInventoryAccount = CStr(GLInventoryAccount1Command.ExecuteScalar)
            Catch ex As Exception
                GLInventoryAccount = "12100"
            End Try
            con.Close()

            'Change GL Accounts to CANADIAN if necessary
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CurrentPartNumber = cboAssemblyPartNumber.Text
                LoadPreferredVendor()
            Else
                'Do nothing
            End If

            If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                GLInventoryAccount = "C$" & GLInventoryAccount
                GLIssuesAccount = "C$59790"
            Else
                GLIssuesAccount = "59790"
            End If
            '******************************************************************************************************
            'Write Assembly Cost (Total Component Cost) to the GL
            'Write Components to the GL
            Dim MAXStatement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastTransactionNumber = 85000000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1

            'Convert to a positive number
            If SumComponentCost < 0 Then
                SumComponentCost = SumComponentCost * -1
            End If

            'Write to GL Transaction Table - Component Line Data
            Try
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Full Assembly"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert GL Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Write to GL Transaction Table - Component Line Data
            Try
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber + 1
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Full Assembly"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert GL Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            Dim MAXLineNumberStatement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
            Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
            MAXLineNumberCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastComponentLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastComponentLineNumber = 0
            End Try
            con.Close()

            NextComponentLineNumber = LastComponentLineNumber + 1
            '*****************************************************************************************************************************************
            'Find Next Transaction Number
            Dim InventoryTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
            Dim InventoryTransactionNumber2Command As New SqlCommand(InventoryTransactionNumber2Statement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastInventoryTransactionNumber = CInt(InventoryTransactionNumber2Command.ExecuteScalar)
            Catch ex As Exception
                LastInventoryTransactionNumber = 867500000
            End Try
            con.Close()

            NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1

            'Convert to a positive number
            If UnitBuildCost < 0 Then
                UnitBuildCost = UnitBuildCost * -1
            End If

            'Add transactions to Inventory Transaction Table
            Try
                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Un-Build Assembly"
                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text) * UnitBuildCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Inventory Transaction Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************************************
            'Write Data to Assembly Build Line Table - Assembly Part Number
            Try
                cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@BuildQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text) * -1
                    .Add("@BuildUnitCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Assembly Part Number"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Line Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Create Cost Tier for assembly in Costing Table
            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double

            Dim UpperLimitStatement As String = "SELECT MAX(UpperLimit) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimit = 0
            End Try
            con.Close()

            'Get next Transaction Number
            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + Val(txtBuildQuantity.Text) - 1

            'Write Values to Inventory Costing Table
            Try
                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CostingDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "UN-BUILD ASSEMBLY"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = LastCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Inventory Costing Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Update Build Header Table to include updated cost
            Try
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildCost", SqlDbType.VarChar).Value = SumComponentCost
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Update Assembly Build Header Cost"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Reset Form 
            isLoaded = False
            ClearVariables()
            ClearData()
            ShowData()
            isLoaded = True
            MsgBox("Assembly has been Un-built and added to inventory", MsgBoxStyle.OkOnly)
        Else
            MsgBox("Check Data and try again.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canBuildOrReverse() As Boolean
        If String.IsNullOrEmpty(cboAssemblyPartNumber.Text) Then
            MessageBox.Show("You must have an assembly part number selected", "Select an assembly part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAssemblyPartNumber.Focus()
            Return False
        End If
        If cboAssemblyPartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid assembly part number", "Select a vlaid assembly part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAssemblyPartNumber.SelectAll()
            cboAssemblyPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBuildQuantity.Text) Then
            MessageBox.Show("You must enter a build quantity", "Entere a build quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBuildQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtBuildQuantity.Text) = False Then
            MessageBox.Show("You must enter a numberic build quantity", "Enter a numberic build quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBuildQuantity.SelectAll()
            txtBuildQuantity.Focus()
            Return False
        End If
        If txtBuildQuantity.Text <= 0 Then
            MessageBox.Show("You must enter a build quantity greater than zero", "Enter a build quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBuildQuantity.SelectAll()
            txtBuildQuantity.Focus()
            Return False
        End If
        If dgvAssemblyLines.Rows.Count < 1 Then
            MessageBox.Show("You must enter at least 1 component", "Enter a component", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboComponentPart.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdViewAssemblyBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAssemblyBOM.Click
        ShowData()
        LoadTotalCost()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If hasTempParts() Then
            Exit Sub
        End If
        isLoaded = False
        ClearData()
        ClearVariables()
        ShowData()
        isLoaded = True
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllToolStripMenuItem.Click
        cmdClearAll_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalAssemblyPartNumber = cboAssemblyPartNumber.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintAssemblyBOM As New PrintAssemblyBOM
            Dim Result = NewPrintAssemblyBOM.ShowDialog()
        End Using
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboAssemblyPartNumber.Text) Then
            MessageBox.Show("You must select an assembly part", "Select an assembly", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAssemblyPartNumber.Focus()
            Return False
        End If
        If dgvAssemblyLines.Rows.Count < 1 Then
            MessageBox.Show("You must select at least 1 component", "Select a component", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboComponentPart.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub PrintBOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBOMToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If hasTempParts() Then
            Exit Sub
        End If
        isLoaded = False
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvAssemblyLines_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssemblyLines.CellValueChanged
        If isLoaded Then
            Dim currentRow As Integer = dgvAssemblyLines.CurrentCell.RowIndex
            Dim currentCell As Integer = dgvAssemblyLines.CurrentCell.ColumnIndex
            If currentCell = 3 Or currentCell = 4 Then
                dgvAssemblyLines.Rows(currentRow).Cells(5).Value = dgvAssemblyLines.Rows(currentRow).Cells(3).Value * dgvAssemblyLines.Rows(currentRow).Cells(4).Value
            End If

            'Load Total Cost
            LoadTotalCost()
        End If
    End Sub

    ''checks to see if there are any temp parts that were added and will display a message asking if they want to proceed because they will lose the temp parts data
    Private Function hasTempParts() As Boolean
        Dim hasTemp As Boolean = False
        If dgvAssemblyLines.Rows.Count > 0 Then
            For i As Integer = 0 To dgvAssemblyLines.Rows.Count - 1
                If dgvAssemblyLines.Rows(i).Cells("LineCommentColumn").Value = "TEMP PART" Then
                    hasTemp = True
                    Exit For
                End If
            Next
            If hasTemp Then
                Dim rslt As DialogResult = MessageBox.Show("You have temp parts added, if you proceed you will lose the data. Do you wish to continue?", "Data will be lost", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If rslt <> Windows.Forms.DialogResult.Yes Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Sub cboAssemblyPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssemblyPartNumber.SelectedIndexChanged
        txtAssemblyCost.Clear()
        LoadDescriptionByPartNumber()
        LoadAssemblyData()
    End Sub

    Private Sub chkExchangeRate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExchangeRate.CheckedChanged
        If chkExchangeRate.Checked = True Then
            txtExchangeRate.Enabled = True
            txtExchangeRate.Clear()
            txtExchangeRate.ForeColor = Color.Red
            txtExchangeRate.Text = "Enter Rate Here"
            txtExchangeRate.Focus()
        Else
            txtExchangeRate.Enabled = False
            txtExchangeRate.Clear()
        End If
    End Sub
End Class