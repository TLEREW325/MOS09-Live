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
Public Class ItemPriceSheetMaintenance
    Inherits System.Windows.Forms.Form

    Dim StandardCost, StandardPrice, StartPrice, PercentDiscount, PriceLevel_1, PriceLevel_2, PriceLevel_3, PriceLevel_4, PriceLevel_5, PriceLevel_6, PriceLevel_7, PriceLevel_8, PriceLevel_9, PriceLevel_10, PriceLevel_11, PriceLevel_12, PriceLevel_13 As Double
    Dim Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, Level10, Level11, Level12, Level13 As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ItemPriceSheetMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        cboDivisionID.Text = EmployeeCompanyCode
        usefulFunctions.LoadSecurity(Me)

        LoadPartNumber()
        LoadPartDescription()
        ClearData()
        ClearDatagrid()

        If GlobalMaintenancePartNumber = "" Then
            cboPartNumber.SelectedIndex = -1
        Else
            cboPartNumber.Text = GlobalMaintenancePartNumber
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

    Public Sub ClearData()
        cboDivisionID.Text = EmployeeCompanyCode
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        txt100000To.Clear()
        txt10000To.Clear()
        txt1000To.Clear()
        txt100To.Clear()
        txt200To.Clear()
        txt25000To.Clear()
        txt2500To.Clear()
        txt300To.Clear()
        txt400To.Clear()
        txt50000To.Clear()
        txt500To.Clear()
        txt750To.Clear()
        txtQuantityDiscount.Clear()
        txtStandardUnitCost.Clear()
        txtStandardUnitPrice.Clear()
        txtStartPrice.Clear()
        cboPartNumber.Focus()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ItemPriceSheet WHERE DivisionID = @DivisionID And PartNumber = @PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheet")
        dgvItemPriceSheets.DataSource = ds.Tables("ItemPriceSheet")
        con.Close()
    End Sub

    Public Sub ClearDatagrid()
        dgvItemPriceSheets.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
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

    Public Sub LoadPartNumberData()
        Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID And DivisionID = @DivisionID"
        Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
        StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim StandardPriceStatement As String = "SELECT StandardPrice FROM ItemList WHERE ItemID = @ItemID And DivisionID = @DivisionID"
        Dim StandardPriceCommand As New SqlCommand(StandardPriceStatement, con)
        StandardPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
        Catch ex As Exception
            StandardCost = 0
        End Try
        Try
            StandardPrice = CDbl(StandardPriceCommand.ExecuteScalar)
        Catch ex As Exception
            StandardPrice = 0
        End Try
        con.Close()

        txtStandardUnitCost.Text = StandardCost
        txtStandardUnitPrice.Text = StandardPrice
    End Sub

    Public Sub LoadPriceBrackets()
        Dim Level1Statement As String = "SELECT B100To199 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level1Command As New SqlCommand(Level1Statement, con)
        Level1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level2Statement As String = "SELECT B200To299 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level2Command As New SqlCommand(Level2Statement, con)
        Level2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level3Statement As String = "SELECT B300To399 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level3Command As New SqlCommand(Level3Statement, con)
        Level3Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level4Statement As String = "SELECT B400To499 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level4Command As New SqlCommand(Level4Statement, con)
        Level4Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level5Statement As String = "SELECT B500To749 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level5Command As New SqlCommand(Level5Statement, con)
        Level5Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level6Statement As String = "SELECT B750To999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level6Command As New SqlCommand(Level6Statement, con)
        Level6Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level7Statement As String = "SELECT B1000To2499 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level7Command As New SqlCommand(Level7Statement, con)
        Level7Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level7Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level8Statement As String = "SELECT B2500To4999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level8Command As New SqlCommand(Level8Statement, con)
        Level8Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level8Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level9Statement As String = "SELECT B5000To9999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level9Command As New SqlCommand(Level9Statement, con)
        Level9Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level9Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level10Statement As String = "SELECT B10000To24999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level10Command As New SqlCommand(Level10Statement, con)
        Level10Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level10Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level11Statement As String = "SELECT B25000To49999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level11Command As New SqlCommand(Level11Statement, con)
        Level11Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level11Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level12Statement As String = "SELECT B50000To99999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level12Command As New SqlCommand(Level12Statement, con)
        Level12Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level12Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Level13Statement As String = "SELECT B100000AndUp FROM ItemPriceSheet WHERE PartNumber = @PartNumber And DivisionID = @DivisionID"
        Dim Level13Command As New SqlCommand(Level13Statement, con)
        Level13Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        Level13Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Level1 = CDbl(Level1Command.ExecuteScalar)
        Catch ex As Exception
            Level1 = 0
        End Try
        Try
            Level2 = CDbl(Level2Command.ExecuteScalar)
        Catch ex As Exception
            Level2 = 0
        End Try
        Try
            Level3 = CDbl(Level3Command.ExecuteScalar)
        Catch ex As Exception
            Level3 = 0
        End Try
        Try
            Level4 = CDbl(Level4Command.ExecuteScalar)
        Catch ex As Exception
            Level4 = 0
        End Try
        Try
            Level5 = CDbl(Level5Command.ExecuteScalar)
        Catch ex As Exception
            Level5 = 0
        End Try
        Try
            Level6 = CDbl(Level6Command.ExecuteScalar)
        Catch ex As Exception
            Level6 = 0
        End Try
        Try
            Level7 = CDbl(Level7Command.ExecuteScalar)
        Catch ex As Exception
            Level7 = 0
        End Try
        Try
            Level8 = CDbl(Level8Command.ExecuteScalar)
        Catch ex As Exception
            Level8 = 0
        End Try
        Try
            Level9 = CDbl(Level9Command.ExecuteScalar)
        Catch ex As Exception
            Level9 = 0
        End Try
        Try
            Level10 = CDbl(Level10Command.ExecuteScalar)
        Catch ex As Exception
            Level10 = 0
        End Try
        Try
            Level11 = CDbl(Level11Command.ExecuteScalar)
        Catch ex As Exception
            Level11 = 0
        End Try
        Try
            Level12 = CDbl(Level12Command.ExecuteScalar)
        Catch ex As Exception
            Level12 = 0
        End Try
        Try
            Level13 = CDbl(Level13Command.ExecuteScalar)
        Catch ex As Exception
            Level13 = 0
        End Try
        con.Close()

        txt100To.Text = Level1
        txt200To.Text = Level2
        txt300To.Text = Level3
        txt400To.Text = Level4
        txt500To.Text = Level5
        txt750To.Text = Level6
        txt1000To.Text = Level7
        txt2500To.Text = Level8
        txt5000To.Text = Level9
        txt10000To.Text = Level10
        txt25000To.Text = Level11
        txt50000To.Text = Level12
        txt100000To.Text = Level13
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        ShowData()
        LoadDescriptionByPart()
        LoadPartNumberData()
        LoadPriceBrackets()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Write Data to Item Price Sheet Database Table
                cmd = New SqlCommand("Insert Into ItemPriceSheet(PartNumber, PartDescription, DivisionID, StandardUnitCost, StandardUnitPrice, B100To199, B200To299, B300To399, B400To499, B500To749, B750To999, B1000To2499, B2500To4999, B5000To9999, B10000To24999, B25000To49999, B50000To99999, B100000AndUp)Values(@PartNumber, @PartDescription, @DivisionID, @StandardUnitCost, @StandardUnitPrice, @B100To199, @B200To299, @B300To399, @B400To499, @B500To749, @B750To999, @B1000To2499, @B2500To4999, @B5000To9999, @B10000To24999, @B25000To49999, @B50000To99999, @B100000AndUp)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@StandardUnitCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
                    .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
                    .Add("@B100To199", SqlDbType.VarChar).Value = Val(txt100To.Text)
                    .Add("@B200To299", SqlDbType.VarChar).Value = Val(txt200To.Text)
                    .Add("@B300To399", SqlDbType.VarChar).Value = Val(txt300To.Text)
                    .Add("@B400To499", SqlDbType.VarChar).Value = Val(txt400To.Text)
                    .Add("@B500To749", SqlDbType.VarChar).Value = Val(txt500To.Text)
                    .Add("@B750To999", SqlDbType.VarChar).Value = Val(txt750To.Text)
                    .Add("@B1000To2499", SqlDbType.VarChar).Value = Val(txt1000To.Text)
                    .Add("@B2500To4999", SqlDbType.VarChar).Value = Val(txt2500To.Text)
                    .Add("@B5000To9999", SqlDbType.VarChar).Value = Val(txt5000To.Text)
                    .Add("@B10000To24999", SqlDbType.VarChar).Value = Val(txt10000To.Text)
                    .Add("@B25000To49999", SqlDbType.VarChar).Value = Val(txt25000To.Text)
                    .Add("@B50000To99999", SqlDbType.VarChar).Value = Val(txt50000To.Text)
                    .Add("@B100000AndUp", SqlDbType.VarChar).Value = Val(txt100000To.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowData()
            Catch ex As Exception
                'Write Data to Item Price Sheet Database Table
                cmd = New SqlCommand("UPDATE ItemPriceSheet SET PartDescription = @PartDescription, StandardUnitCost = @StandardUnitCost, StandardUnitPrice = @StandardUnitCost, B100To199 = @B100To199, B200To299 = @B200To299, B300To399 = @B300To399, B400To499 = @B400To499, B500To749 = @B500To749, B750To999 = @B750To999, B1000To2499 = @B1000To2499, B2500To4999 = @B2500To4999, B5000To9999 = @B5000To9999, B10000To24999 = @B10000To24999, B25000To49999 = @B25000To49999, B50000To99999 = @B50000To99999, B100000AndUp = @B100000AndUp WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@StandardUnitCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
                    .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
                    .Add("@B100To199", SqlDbType.VarChar).Value = Val(txt100To.Text)
                    .Add("@B200To299", SqlDbType.VarChar).Value = Val(txt200To.Text)
                    .Add("@B300To399", SqlDbType.VarChar).Value = Val(txt300To.Text)
                    .Add("@B400To499", SqlDbType.VarChar).Value = Val(txt400To.Text)
                    .Add("@B500To749", SqlDbType.VarChar).Value = Val(txt500To.Text)
                    .Add("@B750To999", SqlDbType.VarChar).Value = Val(txt750To.Text)
                    .Add("@B1000To2499", SqlDbType.VarChar).Value = Val(txt1000To.Text)
                    .Add("@B2500To4999", SqlDbType.VarChar).Value = Val(txt2500To.Text)
                    .Add("@B5000To9999", SqlDbType.VarChar).Value = Val(txt5000To.Text)
                    .Add("@B10000To24999", SqlDbType.VarChar).Value = Val(txt10000To.Text)
                    .Add("@B25000To49999", SqlDbType.VarChar).Value = Val(txt25000To.Text)
                    .Add("@B50000To99999", SqlDbType.VarChar).Value = Val(txt50000To.Text)
                    .Add("@B100000AndUp", SqlDbType.VarChar).Value = Val(txt100000To.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowData()
            End Try
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cmdCalculatePricing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculatePricing.Click
        'Calculate Price Brackets
        StartPrice = Val(txtStartPrice.Text)
        PercentDiscount = Val(txtQuantityDiscount.Text)

        PriceLevel_1 = StartPrice - (StartPrice * PercentDiscount)
        PriceLevel_2 = PriceLevel_1 - (PriceLevel_1 * PercentDiscount)
        PriceLevel_3 = PriceLevel_2 - (PriceLevel_2 * PercentDiscount)
        PriceLevel_4 = PriceLevel_3 - (PriceLevel_3 * PercentDiscount)
        PriceLevel_5 = PriceLevel_4 - (PriceLevel_4 * PercentDiscount)
        PriceLevel_6 = PriceLevel_5 - (PriceLevel_5 * PercentDiscount)
        PriceLevel_7 = PriceLevel_6 - (PriceLevel_6 * PercentDiscount)
        PriceLevel_8 = PriceLevel_7 - (PriceLevel_7 * PercentDiscount)
        PriceLevel_9 = PriceLevel_8 - (PriceLevel_8 * PercentDiscount)
        PriceLevel_10 = PriceLevel_9 - (PriceLevel_9 * PercentDiscount)
        PriceLevel_11 = PriceLevel_10 - (PriceLevel_10 * PercentDiscount)
        PriceLevel_12 = PriceLevel_11 - (PriceLevel_11 * PercentDiscount)
        PriceLevel_13 = PriceLevel_12 - (PriceLevel_12 * PercentDiscount)

        txt100To.Text = PriceLevel_1
        txt200To.Text = PriceLevel_2
        txt300To.Text = PriceLevel_3
        txt400To.Text = PriceLevel_4
        txt500To.Text = PriceLevel_5
        txt750To.Text = PriceLevel_6
        txt1000To.Text = PriceLevel_7
        txt2500To.Text = PriceLevel_8
        txt5000To.Text = PriceLevel_9
        txt10000To.Text = PriceLevel_10
        txt25000To.Text = PriceLevel_11
        txt50000To.Text = PriceLevel_12
        txt100000To.Text = PriceLevel_13
    End Sub

    Private Sub cmdUpdateCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCost.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            'UPDATE Standard Unit Cost in Item List
            cmd = New SqlCommand("UPDATE ItemList SET StandardCost = @StandardCost WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@StandardCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'UPDATE Standard Unit Price in Item Price Sheet
            cmd = New SqlCommand("UPDATE ItemPriceSheet SET StandardUnitCost = @StandardUnitCost WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@StandardUnitCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowData()
            MsgBox("Standard Unit Cost has been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdUpdatePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdatePrice.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            'UPDATE Standard Unit Price in Item List
            cmd = New SqlCommand("UPDATE ItemList SET StandardPrice = @StandardPrice WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@StandardPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'UPDATE Standard Unit Price in Item Price Sheet
            cmd = New SqlCommand("UPDATE ItemPriceSheet SET StandardUnitPrice = @StandardUnitPrice WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@StandardUnitPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowData()
            MsgBox("Standard Unit Price has been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub


    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If cboPartNumber.Text = "" Then
            Me.Dispose()
            Me.Close()
        End If

        'Prompt before Exiting
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Price List?", "SAVE PRICE LIST", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Try
                'Write Data to Item Price Sheet Database Table
                cmd = New SqlCommand("Insert Into ItemPriceSheet(PartNumber, PartDescription, DivisionID, StandardUnitCost, StandardUnitPrice, B100To199, B200To299, B300To399, B400To499, B500To749, B750To999, B1000To2499, B2500To4999, B5000To9999, B10000To24999, B25000To49999, B50000To99999, B100000AndUp)Values(@PartNumber, @PartDescription, @DivisionID, @StandardUnitCost, @StandardUnitPrice, @B100To199, @B200To299, @B300To399, @B400To499, @B500To749, @B750To999, @B1000To2499, @B2500To4999, @B5000To9999, @B10000To24999, @B25000To49999, @B50000To99999, @B100000AndUp)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@StandardUnitCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
                    .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
                    .Add("@B100To199", SqlDbType.VarChar).Value = Val(txt100To.Text)
                    .Add("@B200To299", SqlDbType.VarChar).Value = Val(txt200To.Text)
                    .Add("@B300To399", SqlDbType.VarChar).Value = Val(txt300To.Text)
                    .Add("@B400To499", SqlDbType.VarChar).Value = Val(txt400To.Text)
                    .Add("@B500To749", SqlDbType.VarChar).Value = Val(txt500To.Text)
                    .Add("@B750To999", SqlDbType.VarChar).Value = Val(txt750To.Text)
                    .Add("@B1000To2499", SqlDbType.VarChar).Value = Val(txt1000To.Text)
                    .Add("@B2500To4999", SqlDbType.VarChar).Value = Val(txt2500To.Text)
                    .Add("@B5000To9999", SqlDbType.VarChar).Value = Val(txt5000To.Text)
                    .Add("@B10000To24999", SqlDbType.VarChar).Value = Val(txt10000To.Text)
                    .Add("@B25000To49999", SqlDbType.VarChar).Value = Val(txt25000To.Text)
                    .Add("@B50000To99999", SqlDbType.VarChar).Value = Val(txt50000To.Text)
                    .Add("@B100000AndUp", SqlDbType.VarChar).Value = Val(txt100000To.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Me.Dispose()
                Me.Close()
            Catch ex As Exception
                'Write Data to Item Price Sheet Database Table
                cmd = New SqlCommand("UPDATE ItemPriceSheet SET PartDescription = @PartDescription, StandardUnitCost = @StandardUnitCost, StandardUnitPrice = @StandardUnitCost, B100To199 = @B100To199, B200To299 = @B200To299, B300To399 = @B300To399, B400To499 = @B400To499, B500To749 = @B500To749, B750To999 = @B750To999, B1000To2499 = @B1000To2499, B2500To4999 = @B2500To4999, B5000To9999 = @B5000To9999, B10000To24999 = @B10000To24999, B25000To49999 = @B25000To49999, B50000To99999 = @B50000To99999, B100000AndUp = @B100000AndUp WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@StandardUnitCost", SqlDbType.VarChar).Value = Val(txtStandardUnitCost.Text)
                    .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = Val(txtStandardUnitPrice.Text)
                    .Add("@B100To199", SqlDbType.VarChar).Value = Val(txt100To.Text)
                    .Add("@B200To299", SqlDbType.VarChar).Value = Val(txt200To.Text)
                    .Add("@B300To399", SqlDbType.VarChar).Value = Val(txt300To.Text)
                    .Add("@B400To499", SqlDbType.VarChar).Value = Val(txt400To.Text)
                    .Add("@B500To749", SqlDbType.VarChar).Value = Val(txt500To.Text)
                    .Add("@B750To999", SqlDbType.VarChar).Value = Val(txt750To.Text)
                    .Add("@B1000To2499", SqlDbType.VarChar).Value = Val(txt1000To.Text)
                    .Add("@B2500To4999", SqlDbType.VarChar).Value = Val(txt2500To.Text)
                    .Add("@B5000To9999", SqlDbType.VarChar).Value = Val(txt5000To.Text)
                    .Add("@B10000To24999", SqlDbType.VarChar).Value = Val(txt10000To.Text)
                    .Add("@B25000To49999", SqlDbType.VarChar).Value = Val(txt25000To.Text)
                    .Add("@B50000To99999", SqlDbType.VarChar).Value = Val(txt50000To.Text)
                    .Add("@B100000AndUp", SqlDbType.VarChar).Value = Val(txt100000To.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Me.Dispose()
                Me.Close()
            End Try
        ElseIf button = DialogResult.No Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub dgvItemPriceSheets_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemPriceSheets.CellValueChanged
        Dim LineInvoiceNumber, LineInvoiceLineNumber As Integer
        Dim LineComment, SerialNumber, RowDivision As String
        Dim LineExtendedCOS As Double = 0

        If Me.dgvItemPriceSheets.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvItemPriceSheets.CurrentCell.RowIndex

            Try
                LineInvoiceNumber = Me.dgvItemPriceSheets.Rows(RowIndex).Cells("InvoiceHeaderKeyColumn").Value
            Catch ex As Exception
                LineInvoiceNumber = 0
            End Try
            Try
                LineInvoiceLineNumber = Me.dgvItemPriceSheets.Rows(RowIndex).Cells("InvoiceLineKeyColumn").Value
            Catch ex As Exception
                LineInvoiceLineNumber = 0
            End Try
            Try
                LineComment = Me.dgvItemPriceSheets.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try
            Try
                SerialNumber = Me.dgvItemPriceSheets.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                SerialNumber = ""
            End Try
            Try
                LineExtendedCOS = Me.dgvItemPriceSheets.Rows(RowIndex).Cells("ExtendedCOSColumn").Value
            Catch ex As Exception
                LineExtendedCOS = 0
            End Try
            Try
                RowDivision = Me.dgvItemPriceSheets.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try

            If EmployeeSecurityCode = "1001" Then
                'UPDATE Invoice Lines
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineComment = @LineComment, SerialNumber = @SerialNumber WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = LineInvoiceNumber
                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = LineInvoiceLineNumber
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = LineExtendedCOS
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub
End Class