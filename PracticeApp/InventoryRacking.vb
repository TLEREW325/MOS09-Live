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
Imports System.Drawing.Printing
Public Class InventoryRacking
    Inherits System.Windows.Forms.Form

    Dim RackingKey, counter, LastTransactionNumber, NextTransactionNumber As Integer
    Dim DateFilter, RackFilter, PartFilter, TextFilter, HeatFilter, FOXFilter As String
    Dim TotalRackWeight, PieceWeight As Double
    Dim TotalPieces, PiecesPerBox, NumberOfBoxes As Integer
    Dim CheckRackNumber As String = ""
    Dim TotalPiecesInRack, TotalBoxesInRack, TotalQOH As Double
    Dim DeleteEntireRack As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim LoginPCName As String = My.Computer.Name

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet


    'Form load, eror checking, clear, etc.

    Private Sub InventoryRacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdRackSearch

        LoadPartNumber()
        LoadPartDescription()
        LoadAddPartNumber()
        LoadAddPartDescription()
        LoadSearchByRackNumber()
        LoadAddRackNumber()

        ClearAllFields()
        ClearVariables()
        ClearDataInDatagrid()

        CalculateEmptyRacks()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 399 Then
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

    Public Sub ClearLines()
        txtSearchByFOX.Clear()
        txtSearchByHeat.Clear()
        txtSearchByText.Clear()
        txtSearchByDate.Clear()

        cboSearchByRack.SelectedIndex = -1
        cboSearchPartNumber.SelectedIndex = -1
        cboSearchPartDescription.SelectedIndex = -1

        cboSearchPartNumber.Focus()

        CalculateEmptyRacks()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvRackingTransactions.DataSource = Nothing
        txtPieceTotal.Clear()
        txtBoxTotal.Clear()
        txtInventoryTotal.Clear()
    End Sub

    Public Sub CalculateEmptyRacks()
        If EmployeeCompanyCode = "SLC" Then
            'If TFP or TWD, get total number of racks
            Dim CountTotalRacks, CountFilledRacks, CountEmptyRacks As Integer

            Dim CountTotalRacksStatement As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE DivisionID = 'SLC' AND RackPosition <> 'UNAVAILABLE'"
            Dim CountTotalRacksCommand As New SqlCommand(CountTotalRacksStatement, con)

            Dim CountFilledRacksStatement As String = "SELECT COUNT(DISTINCT(BinNumber)) FROM RackingTransactionTable WHERE DivisionID = 'SLC'"
            Dim CountFilledRacksCommand As New SqlCommand(CountFilledRacksStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTotalRacks = CInt(CountTotalRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountTotalRacks = 0
            End Try
            Try
                CountFilledRacks = CInt(CountFilledRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountFilledRacks = 0
            End Try
            con.Close()

            CountEmptyRacks = CountTotalRacks - CountFilledRacks

            txtTotalEmptyLocations.Text = CountEmptyRacks
        ElseIf EmployeeCompanyCode = "TFF" Then
            'If TFP or TWD, get total number of racks
            Dim CountTotalRacks, CountFilledRacks, CountEmptyRacks As Integer

            Dim CountTotalRacksStatement As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE DivisionID = 'TFF' AND RackPosition <> 'UNAVAILABLE'"
            Dim CountTotalRacksCommand As New SqlCommand(CountTotalRacksStatement, con)

            Dim CountFilledRacksStatement As String = "SELECT COUNT(DISTINCT(BinNumber)) FROM RackingTransactionTable WHERE DivisionID = 'TFF'"
            Dim CountFilledRacksCommand As New SqlCommand(CountFilledRacksStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTotalRacks = CInt(CountTotalRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountTotalRacks = 0
            End Try
            Try
                CountFilledRacks = CInt(CountFilledRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountFilledRacks = 0
            End Try
            con.Close()

            CountEmptyRacks = CountTotalRacks - CountFilledRacks

            txtTotalEmptyLocations.Text = CountEmptyRacks
        Else
            'If TFP or TWD, get total number of racks
            Dim CountTotalRacks, CountFilledRacks, CountEmptyRacks As Integer
            Dim ActualEmptyRackCount As Integer = 0

            Dim CountTotalRacksStatement As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE DivisionID <> 'SLC' AND RackPosition <> 'UNAVAILABLE' AND BinNumber NOT LIKE 'FL%' AND BinNumber NOT LIKE 'PF%'"
            Dim CountTotalRacksCommand As New SqlCommand(CountTotalRacksStatement, con)

            Dim CountFilledRacksStatement As String = "SELECT COUNT(DISTINCT(BinNumber)) FROM RackingTransactionTable WHERE DivisionID <> 'SLC'"
            Dim CountFilledRacksCommand As New SqlCommand(CountFilledRacksStatement, con)

            Dim ActualEmptyRackCountStatement As String = "SELECT COUNT(BinNumber) FROM EmptyBinQueryTWD"
            Dim ActualEmptyRackCountCommand As New SqlCommand(ActualEmptyRackCountStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTotalRacks = CInt(CountTotalRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountTotalRacks = 0
            End Try
            Try
                CountFilledRacks = CInt(CountFilledRacksCommand.ExecuteScalar)
            Catch ex As Exception
                CountFilledRacks = 0
            End Try
            Try
                ActualEmptyRackCount = CInt(ActualEmptyRackCountCommand.ExecuteScalar)
            Catch ex As Exception
                ActualEmptyRackCount = 0
            End Try
            con.Close()

            CountEmptyRacks = CountTotalRacks - CountFilledRacks

            If CountEmptyRacks <> ActualEmptyRackCount Then
                txtTotalEmptyLocations.Text = ActualEmptyRackCount
            Else
                txtTotalEmptyLocations.Text = ActualEmptyRackCount
            End If
        End If
    End Sub

    Public Sub ValidateRackNumber()
        If cboSearchByRack.Text <> "" Then
            If cboSearchByRack.Text.Length = 5 Then
                'Do nothing
            ElseIf cboSearchByRack.Text.Length = 4 Then
                CheckRackNumber = cboSearchByRack.Text.Substring(0, 2) + "0" + cboSearchByRack.Text.Substring(2, 2)
                cboSearchByRack.Text = CheckRackNumber
            ElseIf cboSearchByRack.Text.Length = 3 Then
                CheckRackNumber = cboSearchByRack.Text.Substring(0, 2) + "00" + cboSearchByRack.Text.Substring(2, 1)
                cboSearchByRack.Text = CheckRackNumber
            Else
                MsgBox("You must select a valid rack #.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub LoadFormatting()
        Dim RowComment As String = ""
        Dim RowRackComment As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvRackingTransactions.Rows
            Try
                RowComment = row.Cells("CommentColumn").Value
            Catch ex As System.Exception
                RowComment = ""
            End Try
            Try
                RowRackComment = row.Cells("RackCommentColumn").Value
            Catch ex As System.Exception
                RowRackComment = ""
            End Try

            If RowComment = "" And RowRackComment = "" Then
                Me.dgvRackingTransactions.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvRackingTransactions.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub ClearVariables()
        RackingKey = 0
        counter = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        RackFilter = ""
        PartFilter = ""
        TextFilter = ""
        HeatFilter = ""
        FOXFilter = ""
        TotalRackWeight = 0
        PieceWeight = 0
        TotalPieces = 0
        PiecesPerBox = 0
        NumberOfBoxes = 0
        CheckRackNumber = ""
        TotalPiecesInRack = 0
        TotalBoxesInRack = 0
        TotalQOH = 0

        CalculateEmptyRacks()
    End Sub

    Public Sub ClearAllFields()
        txtAddHeatNumber.Clear()
        txtAddLotNumber.Clear()
        txtBoxQuantity.Clear()
        txtBoxTotal.Clear()
        txtInventoryTotal.Clear()
        txtPickTicketNumber.Clear()
        txtPiecesPerBox.Clear()
        txtPieceTotal.Clear()
        txtSearchByFOX.Clear()
        txtSearchByHeat.Clear()
        txtSearchByText.Clear()

        lblPieceWeight.Text = ""
        txtAddRackingWeight.Text = ""
        txtAddTotalPieces.Text = ""
        txtTotalEmptyLocations.Text = ""

        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboRackNumber.SelectedIndex = -1
        cboSearchByRack.SelectedIndex = -1
        cboSearchPartDescription.SelectedIndex = -1
        cboSearchPartNumber.SelectedIndex = -1

        lblQOH.Visible = False
        lblPartQOH.Visible = False

        CalculateEmptyRacks()
    End Sub

    'Load datasets

    Public Sub ShowDataByFilters()
        'Validate Rack
        ValidateRackNumber()

        'Define Filters
        If cboSearchPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboSearchPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboSearchByRack.Text <> "" Then
            RackFilter = " AND BinNumber = '" + cboSearchByRack.Text + "'"
        Else
            RackFilter = ""
        End If
        If txtSearchByHeat.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + txtSearchByHeat.Text + "'"
        Else
            HeatFilter = ""
        End If
        If txtSearchByDate.Text <> "" Then
            DateFilter = " AND ActivityDate = '" + txtSearchByDate.Text + "'"
        Else
            DateFilter = ""
        End If
        If txtSearchByFOX.Text <> "" Then
            FOXFilter = " AND FOXNumber = '" + txtSearchByFOX.Text + "'"
        Else
            FOXFilter = ""
        End If
        If txtSearchByText.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + txtSearchByText.Text + "%' OR PartDescription LIKE '%" + txtSearchByText.Text + "%')"
        Else
            TextFilter = ""
        End If

        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            cmd = New SqlCommand("SELECT * FROM RackingTransactionQuery WHERE (DivisionID = 'TFP' OR DivisionID = 'TWD') AND DivisionID <> 'ADM'" + PartFilter + HeatFilter + FOXFilter + TextFilter + DateFilter + RackFilter + " ORDER BY BinNumber, PartNumber ASC", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "RackingTransactionQuery")
            dgvRackingTransactions.DataSource = ds.Tables("RackingTransactionQuery")
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM RackingTransactionQuery WHERE DivisionID = @DivisionID" + PartFilter + HeatFilter + FOXFilter + TextFilter + DateFilter + RackFilter + " ORDER BY BinNumber, PartNumber ASC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "RackingTransactionQuery")
            dgvRackingTransactions.DataSource = ds.Tables("RackingTransactionQuery")
            con.Close()
        End If

        LoadFormatting()
        LoadrackTotalsOnFilter()
    End Sub

    'Load routines

    Public Sub LoadSearchByRackNumber()
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then

            cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE (DivisionID = 'TWD' OR DivisionID = 'TFP') AND RackPosition <> 'UNAVAILABLE' ORDER BY BinNumber", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "BinNumber")
            cboSearchByRack.DataSource = ds2.Tables("BinNumber")
            con.Close()
            cboSearchByRack.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE DivisionID = @DivisionID AND RackPosition <> 'UNAVAILABLE' ORDER BY BinNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "BinNumber")
            cboSearchByRack.DataSource = ds2.Tables("BinNumber")
            con.Close()
            cboSearchByRack.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadAddPartNumber()
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE PurchProdLineID <> 'NON-INVENTORY' AND SalesProdLineID <> 'SUPPLY' AND (DivisionID = 'TWD' OR DivisionID = 'TFP') ORDER BY ItemID", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "ItemList")
            cboPartNumber.DataSource = ds3.Tables("ItemList")
            con.Close()
            cboSearchPartNumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "ItemList")
            cboPartNumber.DataSource = ds3.Tables("ItemList")
            con.Close()
            cboPartNumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadAddPartDescription()
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE PurchProdLineID <> 'NON-INVENTORY' AND SalesProdLineID <> 'SUPPLY' AND (DivisionID = 'TWD' OR DivisionID = 'TFP') ORDER BY ShortDescription", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "ItemList")
            cboPartDescription.DataSource = ds4.Tables("ItemList")
            con.Close()
            cboPartDescription.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ShortDescription", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "ItemList")
            cboPartDescription.DataSource = ds4.Tables("ItemList")
            con.Close()
            cboPartDescription.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartNumber()
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE PurchProdLineID <> 'NON-INVENTORY' AND SalesProdLineID <> 'SUPPLY' AND (DivisionID = 'TWD' OR DivisionID = 'TFP') ORDER BY ItemID", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd
            myAdapter5.Fill(ds5, "ItemList")
            cboSearchPartNumber.DataSource = ds5.Tables("ItemList")
            con.Close()
            cboSearchPartNumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd
            myAdapter5.Fill(ds5, "ItemList")
            cboSearchPartNumber.DataSource = ds5.Tables("ItemList")
            con.Close()
            cboSearchPartNumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartDescription()
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE PurchProdLineID <> 'NON-INVENTORY' AND SalesProdLineID <> 'SUPPLY' AND (DivisionID = 'TWD' OR DivisionID = 'TFP') ORDER BY ShortDescription", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "ItemList")
            cboSearchPartDescription.DataSource = ds6.Tables("ItemList")
            con.Close()
            cboSearchPartDescription.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ShortDescription", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "ItemList")
            cboSearchPartDescription.DataSource = ds6.Tables("ItemList")
            con.Close()
            cboSearchPartDescription.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadAddRackNumber()
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE (DivisionID = 'TWD' OR DivisionID = 'TFP') AND RackPosition <> 'UNAVAILABLE' ORDER BY BinNumber", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds7 = New DataSet()
            myAdapter7.SelectCommand = cmd
            myAdapter7.Fill(ds7, "BinNumber")
            cboRackNumber.DataSource = ds7.Tables("BinNumber")
            con.Close()
            cboRackNumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE DivisionID = @DivisionID AND RackPosition <> 'UNAVAILABLE' ORDER BY BinNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds7 = New DataSet()
            myAdapter7.SelectCommand = cmd
            myAdapter7.Fill(ds7, "BinNumber")
            cboRackNumber.DataSource = ds7.Tables("BinNumber")
            con.Close()
            cboRackNumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            Dim PartNumber1Statement As String = "SELECT MAX(ItemID) FROM ItemList WHERE ShortDescription = @ShortDescription AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
            Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
            PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboSearchPartDescription.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
            Catch ex As Exception
                PartNumber1 = ""
            End Try
            con.Close()

            cboSearchPartNumber.Text = PartNumber1
        Else
            Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
            Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
            PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboSearchPartDescription.Text
            PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
            Catch ex As Exception
                PartNumber1 = ""
            End Try
            con.Close()

            cboSearchPartNumber.Text = PartNumber1
        End If
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            Dim PartDescription1Statement As String = "SELECT MAX(ShortDescription) FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' or DivisionID = 'TFP')"
            Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
            PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboSearchPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
            Catch ex As Exception
                PartDescription1 = ""
            End Try
            con.Close()

            cboSearchPartDescription.Text = PartDescription1
        Else
            Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
            Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
            PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboSearchPartNumber.Text
            PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
            Catch ex As Exception
                PartDescription1 = ""
            End Try
            con.Close()

            cboSearchPartDescription.Text = PartDescription1
        End If
    End Sub

    Public Sub LoadAddPartByDescription()
        Dim AddPartNumber1 As String = ""

        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            Dim PartNumber1Statement As String = "SELECT MAX(ItemID) FROM ItemList WHERE ShortDescription = @ShortDescription AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
            Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
            PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                AddPartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
            Catch ex As Exception
                AddPartNumber1 = ""
            End Try
            con.Close()

            cboPartNumber.Text = AddPartNumber1
        Else
            Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
            Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
            PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                AddPartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
            Catch ex As Exception
                AddPartNumber1 = ""
            End Try
            con.Close()

            cboPartNumber.Text = AddPartNumber1
        End If
    End Sub

    Public Sub LoadAddDescriptionByPart()
        Dim AddPartDescription1 As String = ""

        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            Dim PartDescription1Statement As String = "SELECT MAX(ShortDescription) FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
            Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
            PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                AddPartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
            Catch ex As Exception
                AddPartDescription1 = ""
            End Try
            con.Close()

            cboPartDescription.Text = AddPartDescription1
        Else
            Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
            Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
            PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                AddPartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
            Catch ex As Exception
                AddPartDescription1 = ""
            End Try
            con.Close()

            cboPartDescription.Text = AddPartDescription1
        End If
    End Sub

    Public Sub LoadQOHForPart()
        'Get QOH for part
        Dim PartQOH As Double = 0

        If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            Dim PartQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
            Dim PartQOHCommand As New SqlCommand(PartQOHStatement, con)
            PartQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboSearchPartNumber.Text
            PartQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            PartQOHCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartQOH = CDbl(PartQOHCommand.ExecuteScalar)
                PartQOH = Math.Round(PartQOH, 0)
            Catch ex As Exception
                PartQOH = 0
            End Try
            con.Close()
        Else
            Dim PartQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PartQOHCommand As New SqlCommand(PartQOHStatement, con)
            PartQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboSearchPartNumber.Text
            PartQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartQOH = CDbl(PartQOHCommand.ExecuteScalar)
                PartQOH = Math.Round(PartQOH, 0)
            Catch ex As Exception
                PartQOH = 0
            End Try
            con.Close()
        End If

        lblPartQOH.Text = PartQOH
    End Sub

    Public Sub LoadLotData()
        Dim LotPieceWeight, LotBoxCount, LotPalletCount, LotTotalPieces, LotTotalWeight As Double
        Dim LotHeatNumber As String = ""
        Dim LotPartNumber As String = ""
        Dim CurrentDivision As String = ""

        Dim LotDataStatement As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim LotDataCommand As New SqlCommand(LotDataStatement, con)
        LotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PieceWeight")) Then
                LotPieceWeight = 0
            Else
                LotPieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                LotBoxCount = 0
            Else
                LotBoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                LotPalletCount = 0
            Else
                LotPalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                LotPartNumber = ""
            Else
                LotPartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                LotHeatNumber = ""
            Else
                LotHeatNumber = reader.Item("HeatNumber")
            End If
        Else
            LotPieceWeight = 0
            LotBoxCount = 0
            LotPalletCount = 0
            LotPartNumber = ""
            LotHeatNumber = ""
        End If
        reader.Close()
        con.Close()

        'Determine the division
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            CurrentDivision = "TWD"
        Else
            CurrentDivision = EmployeeCompanyCode
        End If

        If LotPieceWeight = 0 Then
            'Get Item Maintenance Piece Weight
            Dim PartPieceWeight As Double = 0

            Dim PartPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PartPieceWeightCommand As New SqlCommand(PartPieceWeightStatement, con)
            PartPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LotPartNumber
            PartPieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartPieceWeight = CDbl(PartPieceWeightCommand.ExecuteScalar)
            Catch ex As Exception
                PartPieceWeight = 0
            End Try
            con.Close()

            LotPieceWeight = PartPieceWeight
        End If

        If LotBoxCount = 0 Then
            'Get Item Maintenance Box Count
            Dim PartBoxCount As Double = 0

            Dim PartPieceWeightStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PartPieceWeightCommand As New SqlCommand(PartPieceWeightStatement, con)
            PartPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LotPartNumber
            PartPieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartBoxCount = CDbl(PartPieceWeightCommand.ExecuteScalar)
            Catch ex As Exception
                PartBoxCount = 0
            End Try
            con.Close()

            LotBoxCount = PartBoxCount
        End If

        'Calculate Data and load fields
        LotTotalPieces = LotBoxCount * LotPalletCount
        LotTotalPieces = Math.Round(LotTotalPieces, 0)
        LotTotalWeight = LotTotalPieces * LotPieceWeight
        LotTotalWeight = Math.Round(LotTotalWeight, 0)
        LotBoxCount = Math.Round(LotBoxCount, 0)
        LotPalletCount = Math.Round(LotPalletCount, 0)

        cboPartNumber.Text = LotPartNumber
        txtBoxQuantity.Text = LotPalletCount
        txtPiecesPerBox.Text = LotBoxCount
        txtAddTotalPieces.Text = LotTotalPieces
        txtAddRackingWeight.Text = LotTotalWeight
        txtAddHeatNumber.Text = LotHeatNumber
        lblPieceWeight.Text = LotPieceWeight
    End Sub

    Public Sub LoadPartData()
        Dim ItemPieceWeight, ItemBoxCount, ItemPalletCount, ItemTotalPieces, ItemTotalWeight As Double
        Dim CurrentDivision As String = ""

        'Determine the division
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            CurrentDivision = "TWD"
        Else
            CurrentDivision = EmployeeCompanyCode
        End If

        Dim ItemDataStatement As String = "SELECT * FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        ItemDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ItemDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PieceWeight")) Then
                ItemPieceWeight = 0
            Else
                ItemPieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                ItemBoxCount = 0
            Else
                ItemBoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                ItemPalletCount = 0
            Else
                ItemPalletCount = reader.Item("PalletCount")
            End If
        Else
            ItemPieceWeight = 0
            ItemBoxCount = 0
            ItemPalletCount = 0
        End If
        reader.Close()
        con.Close()

        'Calculate Data and load fields
        ItemTotalPieces = ItemBoxCount * ItemPalletCount
        ItemTotalPieces = Math.Round(ItemTotalPieces, 0)
        ItemTotalWeight = ItemTotalPieces * ItemPieceWeight
        ItemTotalWeight = Math.Round(ItemTotalWeight, 0)
        ItemBoxCount = Math.Round(ItemBoxCount, 0)
        ItemPalletCount = Math.Round(ItemPalletCount, 0)

        txtBoxQuantity.Text = ItemPalletCount
        txtPiecesPerBox.Text = ItemBoxCount
        txtAddTotalPieces.Text = ItemTotalPieces
        txtAddRackingWeight.Text = ItemTotalWeight
        lblPieceWeight.Text = ItemPieceWeight
    End Sub

    Public Sub LoadRackTotalsOnFilter()
        Dim RowPartNumber, RowDivision As String

        If Me.dgvRackingTransactions.RowCount <> 0 Then
            Try
                RowPartNumber = Me.dgvRackingTransactions.Rows(0).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowDivision = Me.dgvRackingTransactions.Rows(0).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = EmployeeCompanyCode
            End Try

            Dim TotalPiecesInRackStatement As String = "SELECT SUM(TotalPieces) FROM RackingTransactionQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim TotalPiecesInRackCommand As New SqlCommand(TotalPiecesInRackStatement, con)
            TotalPiecesInRackCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            TotalPiecesInRackCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            Dim TotalBoxesInRackStatement As String = "SELECT SUM(BoxQuantity) FROM RackingTransactionQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim TotalBoxesInRackCommand As New SqlCommand(TotalBoxesInRackStatement, con)
            TotalBoxesInRackCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            TotalBoxesInRackCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            Dim TotalQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim TotalQOHCommand As New SqlCommand(TotalQOHStatement, con)
            TotalQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            TotalQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalPiecesInRack = CDbl(TotalPiecesInRackCommand.ExecuteScalar)
                TotalPiecesInRack = Math.Round(TotalPiecesInRack, 0)
            Catch ex As Exception
                TotalPiecesInRack = 0
            End Try
            Try
                TotalBoxesInRack = CDbl(TotalBoxesInRackCommand.ExecuteScalar)
                TotalBoxesInRack = Math.Round(TotalBoxesInRack, 0)
            Catch ex As Exception
                TotalBoxesInRack = 0
            End Try
            Try
                TotalQOH = CDbl(TotalQOHCommand.ExecuteScalar)
                TotalQOH = Math.Round(TotalQOH, 0)
            Catch ex As Exception
                TotalQOH = 0
            End Try
            con.Close()

            txtPieceTotal.Text = TotalPiecesInRack
            txtBoxTotal.Text = TotalBoxesInRack
            txtInventoryTotal.Text = TotalQOH
        End If
    End Sub

    Public Sub LoadRackTotals()
        Dim RowPartNumber, RowDivision As String

        If Me.dgvRackingTransactions.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRackingTransactions.CurrentCell.RowIndex

            Try
                RowPartNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowDivision = Me.dgvRackingTransactions.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = EmployeeCompanyCode
            End Try

            Dim TotalPiecesInRackStatement As String = "SELECT SUM(TotalPieces) FROM RackingTransactionQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim TotalPiecesInRackCommand As New SqlCommand(TotalPiecesInRackStatement, con)
            TotalPiecesInRackCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            TotalPiecesInRackCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            Dim TotalBoxesInRackStatement As String = "SELECT SUM(BoxQuantity) FROM RackingTransactionQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim TotalBoxesInRackCommand As New SqlCommand(TotalBoxesInRackStatement, con)
            TotalBoxesInRackCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            TotalBoxesInRackCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            Dim TotalQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim TotalQOHCommand As New SqlCommand(TotalQOHStatement, con)
            TotalQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            TotalQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalPiecesInRack = CDbl(TotalPiecesInRackCommand.ExecuteScalar)
                TotalPiecesInRack = Math.Round(TotalPiecesInRack, 0)
            Catch ex As Exception
                TotalPiecesInRack = 0
            End Try
            Try
                TotalBoxesInRack = CDbl(TotalBoxesInRackCommand.ExecuteScalar)
                TotalBoxesInRack = Math.Round(TotalBoxesInRack, 0)
            Catch ex As Exception
                TotalBoxesInRack = 0
            End Try
            Try
                TotalQOH = CDbl(TotalQOHCommand.ExecuteScalar)
                TotalQOH = Math.Round(TotalQOH, 0)
            Catch ex As Exception
                TotalQOH = 0
            End Try
            con.Close()

            txtPieceTotal.Text = TotalPiecesInRack
            txtBoxTotal.Text = TotalBoxesInRack
            txtInventoryTotal.Text = TotalQOH
        End If
    End Sub

    'Command Buttons

    Private Sub cmdRackSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRackSearch.Click
        ShowDataByFilters()

        If cboSearchPartNumber.Text = "" Then
            txtPieceTotal.Clear()
            txtBoxTotal.Clear()
            txtInventoryTotal.Clear()
            LoadrackTotalsOnFilter()
        Else
            LoadrackTotalsOnFilter()
        End If
    End Sub

    Private Sub cmdClearRackSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearRackSearch.Click
        ClearLines()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdClearAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAddItem.Click
        txtAddLotNumber.Clear()
        txtAddHeatNumber.Clear()
        txtBoxQuantity.Clear()
        txtPiecesPerBox.Clear()

        txtAddTotalPieces.Text = ""
        txtAddRackingWeight.Text = ""
        lblPieceWeight.Text = ""

        cboRackNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1

        txtAddLotNumber.Focus()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        'Validate Fields
        Dim CurrentDivision As String = ""
        Dim TempCurrentDivision As String = ""

        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            CurrentDivision = "TWD"
            TempCurrentDivision = "TFP"
        Else
            CurrentDivision = EmployeeCompanyCode
            TempCurrentDivision = EmployeeCompanyCode
        End If

        If cboPartNumber.Text = "" Or cboPartDescription.Text = "" Then
            MsgBox("You must have a valid part number and description.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtAddTotalPieces.Text = "" Or txtBoxQuantity.Text = "" Or txtPiecesPerBox.Text = "" Then
            MsgBox("You must have a valid quantity.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Validate Rack Number
        Dim CountBinNumber As Integer = 0

        Dim CountBinNumberString As String = "SELECT COUNT(BinNumber) FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID AND RackPosition <> 'UNAVAILABLE'"
        Dim CountBinNumberCommand As New SqlCommand(CountBinNumberString, con)
        CountBinNumberCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
        CountBinNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountBinNumber = CInt(CountBinNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            CountBinNumber = 0
        End Try
        con.Close()

        If CountBinNumber = 0 Then
            MsgBox("You must select a valid Rack #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Validate Part Number
        Dim CountPartNumber As Integer = 0

        Dim CountPartNumberString As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim CountPartNumberCommand As New SqlCommand(CountPartNumberString, con)
        CountPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CountPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
        CountPartNumberCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = TempCurrentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountPartNumber = CInt(CountPartNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            CountPartNumber = 0
        End Try
        con.Close()

        If CountPartNumber = 0 Then
            MsgBox("You must select a valid part #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Get Item Class to check if lot number needed
        Dim GetItemClass As String = ""

        Dim GetItemClassString As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim GetItemClassCommand As New SqlCommand(GetItemClassString, con)
        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
        GetItemClassCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = TempCurrentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetItemClass = ""
        End Try
        con.Close()

        If GetItemClass = "Trufit Parts" Then
            CurrentDivision = "TFP"
        Else
            'Do nothing
        End If

        If txtAddLotNumber.Text = "" Then
            Select Case GetItemClass
                Case "TW CA", "TW DS", "TW TT", "TW TP", "TW PS", "TW CS", "TW NT", "TW SC", "TW DB", "TW IT"
                    MsgBox("A valid lot # is required for this part.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Case Else
                    'Continue
            End Select
        End If

        'Verify that lot number and part number match
        If txtAddLotNumber.Text <> "" Then
            Dim GetLotPart As String = ""

            Dim GetLotPartString As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
            Dim GetLotPartCommand As New SqlCommand(GetLotPartString, con)
            GetLotPartCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLotPart = CStr(GetLotPartCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLotPart = ""
            End Try
            con.Close()

            If GetLotPart <> cboPartNumber.Text Then
                MsgBox("Lot # does not match the part #.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        '*****************************************************************************************************************
        'Check if rack is empty
        Dim GetRackContents As Double = 0

        Dim GetRackContentsString As String = "SELECT SUM(TotalPieces) FROM RackingTransactionTable WHERE BinNumber = @BinNumber and DivisionID = @DivisionID"
        Dim GetRackContentsCommand As New SqlCommand(GetRackContentsString, con)
        GetRackContentsCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
        GetRackContentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRackContents = CDbl(GetRackContentsCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetRackContents = 0
        End Try
        con.Close()

        If GetRackContents = 0 Then
            'skip
        Else
            Dim button As DialogResult = MessageBox.Show("This rack is not empty. Do you wish to add to this rack?", "ADD TO RACK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Continue
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        End If
        '*****************************************************************************************************************
        Try
            'Update Racking Activity Log
            'Get Time and Date
            Dim TodaysDate As Date = Now()
            Dim intHours, intMinutes, intSeconds As Integer
            Dim strHours, strMinutes, strSeconds As String
            Dim RackTime As String = ""
            Dim RackDate As String = ""

            intHours = TodaysDate.Hour
            intMinutes = TodaysDate.Minute
            intSeconds = TodaysDate.Second

            strHours = CStr(intHours)
            strMinutes = CStr(intMinutes)
            strSeconds = CStr(intSeconds)

            RackTime = strHours + ":" + strMinutes + ":" + strSeconds
            RackDate = TodaysDate.ToString()

            If Val(txtAddTotalPieces.Text) = 0 Then
                'Skip Activity Log if no pieces added
            Else
                'Update Racking Activity Log
                cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)", con)

                With cmd.Parameters
                    .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                    .Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = txtAddHeatNumber.Text
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text
                    .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = 0
                    .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = Val(txtAddTotalPieces.Text)
                    .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = Val(txtAddTotalPieces.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "CREATED"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                    .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                    .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                    .Add("@PickTicketNumber", SqlDbType.VarChar).Value = ""
                    .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorDescription = "Inventory Racking - Activity Log Update"
            ErrorUser = EmployeeLoginName
            ErrorComment = "Bin # - " + cboRackNumber.Text + " Part # - " + cboPartNumber.Text
            ErrorDivision = EmployeeCompanyCode
            ErrorReferenceNumber = cboRackNumber.Text

            TFPErrorLogUpdate()
        End Try

        'Get Max Racking Key
        Dim LastRackingKey, NextRackingKey As Integer

        Dim LastRackingKeyString As String = "SELECT MAX(RackingKey) FROM RackingTransactionTable"
        Dim LastRackingKeyCommand As New SqlCommand(LastRackingKeyString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastRackingKey = CInt(LastRackingKeyCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastRackingKey = 0
        End Try
        con.Close()

        NextRackingKey = LastRackingKey + 1

        Try
            'Update Line
            cmd = New SqlCommand("INSERT INTO RackingTransactionTable (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, ActivityDate, DivisionID, CreationDate, AddedBy, Comment) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @ActivityDate, @DivisionID, @CreationDate, @AddedBy, @Comment)", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = NextRackingKey
                .Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtAddHeatNumber.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtBoxQuantity.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtPiecesPerBox.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtAddTotalPieces.Text)
                .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtAddRackingWeight.Text)
                .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                .Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@Comment", SqlDbType.VarChar).Value = txtRackComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorDescription = "Inventory Racking - Racking Transaction Table"
            ErrorUser = EmployeeLoginName
            ErrorComment = "Bin # - " + cboRackNumber.Text + " Part # - " + cboPartNumber.Text
            ErrorDivision = EmployeeCompanyCode
            ErrorReferenceNumber = cboRackNumber.Text

            TFPErrorLogUpdate()
        End Try

        Try
            'Update Line
            cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = NextRackingKey
                .Add("@BinNumber", SqlDbType.VarChar).Value = cboRackNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@HeatNumber", SqlDbType.VarChar).Value = txtAddHeatNumber.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtAddLotNumber.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtBoxQuantity.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtPiecesPerBox.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtAddTotalPieces.Text)
                .Add("@RackingWeight", SqlDbType.VarChar).Value = Val(txtAddRackingWeight.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorDescription = "Inventory Racking - Racking Master List"
            ErrorUser = EmployeeLoginName
            ErrorComment = "Bin # - " + cboRackNumber.Text + " Part # - " + cboPartNumber.Text
            ErrorDivision = EmployeeCompanyCode
            ErrorReferenceNumber = cboRackNumber.Text

            TFPErrorLogUpdate()
        End Try

        'Refresh datagrid
        ShowDataByFilters()
        CalculateEmptyRacks()

        'Clear Lines
        cmdClearAddItem_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearAllFields()
        ClearVariables()
        ClearDataInDatagrid()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalPrintRackingType = "PrintListing"
        GDS = ds

        Using NewPrintRackingByFilter As New PrintRackingByFilter
            Dim Result = NewPrintRackingByFilter.ShowDialog()
        End Using
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim RowRackingKey As Integer = 0
        Dim RowPartNumber, RowBinNumber, RowHeatNumber, RowLotNumber, RowDivisionID As String
        Dim RowTotalPieces As Double = 0
        Dim GetTotalPieces As Double = 0
        Dim GetDifference As Double = 0
        Dim CountSelectedRows As Integer = 0
        Dim Counter As Integer = 0

        If Me.dgvRackingTransactions.RowCount <> 0 Then
            'Count selected rows
            For Each row As DataGridViewRow In Me.dgvRackingTransactions.SelectedRows
                Counter = Counter + 1
            Next

            If Counter = 0 Or Counter = 1 Then

                Dim RowIndex As Integer = Me.dgvRackingTransactions.CurrentCell.RowIndex

                Try
                    RowRackingKey = Me.dgvRackingTransactions.Rows(RowIndex).Cells("RackingKeyColumn").Value
                Catch ex As Exception
                    RowRackingKey = 0
                End Try
                Try
                    RowPartNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("PartNumberColumn").Value
                Catch ex As Exception
                    RowPartNumber = ""
                End Try
                Try
                    RowBinNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("BinNumberColumn").Value
                Catch ex As Exception
                    RowBinNumber = ""
                End Try
                Try
                    RowHeatNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("HeatNumberColumn").Value
                Catch ex As Exception
                    RowHeatNumber = ""
                End Try
                Try
                    RowLotNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("LotNumberColumn").Value
                Catch ex As Exception
                    RowLotNumber = ""
                End Try
                Try
                    RowDivisionID = Me.dgvRackingTransactions.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = EmployeeCompanyCode
                End Try
                Try
                    RowTotalPieces = Me.dgvRackingTransactions.Rows(RowIndex).Cells("TotalPiecesColumn").Value
                Catch ex As Exception
                    RowTotalPieces = 0
                End Try

                'Prompt before deleting
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this selected line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Get Time and Date
                    Dim TodaysDate As DateTime = Now()
                    Dim intHours, intMinutes, intSeconds As Integer
                    Dim strHours, strMinutes, strSeconds As String
                    Dim RackTime As String = ""
                    Dim RackDate As String = ""

                    intHours = TodaysDate.Hour
                    intMinutes = TodaysDate.Minute
                    intSeconds = TodaysDate.Second

                    strHours = CStr(intHours)
                    strMinutes = CStr(intMinutes)
                    strSeconds = CStr(intSeconds)

                    RackTime = strHours + ":" + strMinutes + ":" + strSeconds
                    RackDate = TodaysDate.ToString()

                    Try
                        'Update Racking Activity Log
                        cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)", con)

                        With cmd.Parameters
                            .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                            .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                            .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                            .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                            .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = 0
                            .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = RowTotalPieces * -1
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "DELETED"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                            .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                            .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = ""
                            .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Now()
                        ErrorDescription = "Inventory Racking - Activity Log Update"
                        ErrorUser = EmployeeLoginName
                        ErrorComment = "Bin # - " + RowBinNumber + " Part # - " + RowPartNumber
                        ErrorDivision = EmployeeCompanyCode
                        ErrorReferenceNumber = RowBinNumber

                        TFPErrorLogUpdate()
                    End Try

                    'Update Item List with new Standard Cost and Price
                    cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE RackingKey = @RackingKey", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = RowRackingKey
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Reload Datagrid
                    ShowDataByFilters()
                    CalculateEmptyRacks()
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            ElseIf Counter > 1 And Counter <= 10 Then
                'Prompt before deleting
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete these selected lines?", "DELETE LINES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    For Each row As DataGridViewRow In Me.dgvRackingTransactions.SelectedRows

                        Try
                            RowRackingKey = row.Cells("RackingKeyColumn").Value
                        Catch ex As Exception
                            RowRackingKey = 0
                        End Try
                        Try
                            RowPartNumber = row.Cells("PartNumberColumn").Value
                        Catch ex As Exception
                            RowPartNumber = ""
                        End Try
                        Try
                            RowBinNumber = row.Cells("BinNumberColumn").Value
                        Catch ex As Exception
                            RowBinNumber = ""
                        End Try
                        Try
                            RowHeatNumber = row.Cells("HeatNumberColumn").Value
                        Catch ex As Exception
                            RowHeatNumber = ""
                        End Try
                        Try
                            RowLotNumber = row.Cells("LotNumberColumn").Value
                        Catch ex As Exception
                            RowLotNumber = ""
                        End Try
                        Try
                            RowDivisionID = row.Cells("DivisionIDColumn").Value
                        Catch ex As Exception
                            RowDivisionID = EmployeeCompanyCode
                        End Try
                        Try
                            RowTotalPieces = row.Cells("TotalPiecesColumn").Value
                        Catch ex As Exception
                            RowTotalPieces = 0
                        End Try

                        Try
                            'Get Time and Date
                            Dim TodaysDate As DateTime = Now()
                            Dim intHours, intMinutes, intSeconds As Integer
                            Dim strHours, strMinutes, strSeconds As String
                            Dim RackTime As String = ""
                            Dim RackDate As String = ""

                            intHours = TodaysDate.Hour
                            intMinutes = TodaysDate.Minute
                            intSeconds = TodaysDate.Second

                            strHours = CStr(intHours)
                            strMinutes = CStr(intMinutes)
                            strSeconds = CStr(intSeconds)

                            RackTime = strHours + ":" + strMinutes + ":" + strSeconds
                            RackDate = TodaysDate.ToString()

                            'Update Racking Activity Log
                            cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)", con)

                            With cmd.Parameters
                                .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                                .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                                .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                                .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                                .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                                .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                                .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = 0
                                .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = RowTotalPieces * -1
                                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                                .Add("@TransactionType", SqlDbType.VarChar).Value = "DELETED"
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                                .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                                .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                                .Add("@PickTicketNumber", SqlDbType.VarChar).Value = ""
                                .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error Log
                            ErrorDate = Now()
                            ErrorDescription = "Inventory Racking - Activity Log Update"
                            ErrorUser = EmployeeLoginName
                            ErrorComment = "Bin # - " + RowBinNumber + " Part # - " + RowPartNumber
                            ErrorDivision = EmployeeCompanyCode
                            ErrorReferenceNumber = RowBinNumber

                            TFPErrorLogUpdate()
                        End Try

                        'Update Item List with new Standard Cost and Price
                        cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE RackingKey = @RackingKey", con)

                        With cmd.Parameters
                            .Add("@RackingKey", SqlDbType.VarChar).Value = RowRackingKey
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Next

                    'Reload Datagrid
                    ShowDataByFilters()
                    CalculateEmptyRacks()
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            ElseIf Counter > 10 Then
                MsgBox("You may not select this many rows to delete", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdDeleteEntireRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteEntireRack.Click
        Dim RowRackingNumber As String = ""
        Dim DeleteRowPart, DeleteRowHeat, DeleteRowLot, DeleteRowDivision As String
        Dim DeleteRowPieces As Integer = 0

        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this entire rack?", "DELETE RACK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TFP" Or EmployeeCompanyCode = "SLC" Or EmployeeCompanyCode = "TFF" Then
                If Me.dgvRackingTransactions.RowCount <> 0 Then
                    Dim RowIndex As Integer = Me.dgvRackingTransactions.CurrentCell.RowIndex

                    Try
                        RowRackingNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("BinNumberColumn").Value
                    Catch ex As Exception
                        RowRackingNumber = ""
                    End Try
                    Try
                        DeleteRowPart = Me.dgvRackingTransactions.Rows(RowIndex).Cells("PartNumberColumn").Value
                    Catch ex As System.Exception
                        DeleteRowPart = ""
                    End Try
                    Try
                        DeleteRowHeat = Me.dgvRackingTransactions.Rows(RowIndex).Cells("HeatNumberColumn").Value
                    Catch ex As System.Exception
                        DeleteRowHeat = ""
                    End Try
                    Try
                        DeleteRowLot = Me.dgvRackingTransactions.Rows(RowIndex).Cells("LotNumberColumn").Value
                    Catch ex As System.Exception
                        DeleteRowLot = ""
                    End Try
                    Try
                        DeleteRowPieces = Me.dgvRackingTransactions.Rows(RowIndex).Cells("TotalPiecesColumn").Value
                    Catch ex As System.Exception
                        DeleteRowPieces = 0
                    End Try
                    Try
                        DeleteRowDivision = Me.dgvRackingTransactions.Rows(RowIndex).Cells("DivisionIDColumn").Value
                    Catch ex As System.Exception
                        DeleteRowDivision = ""
                    End Try

                    DeleteEntireRack = RowRackingNumber
                    GlobalDivisionCode = DeleteRowDivision

                    'Activity Log
                    Try
                        'Get Time and Date
                        Dim TodaysDate As Date = Now()
                        Dim intHours, intMinutes, intSeconds As Integer
                        Dim strHours, strMinutes, strSeconds As String
                        Dim RackTime As String = ""
                        Dim RackDate As String = ""

                        intHours = TodaysDate.Hour
                        intMinutes = TodaysDate.Minute
                        intSeconds = TodaysDate.Second

                        strHours = CStr(intHours)
                        strMinutes = CStr(intMinutes)
                        strSeconds = CStr(intSeconds)

                        RackTime = strHours + ":" + strMinutes + ":" + strSeconds
                        RackDate = TodaysDate.ToString()

                        'Update Racking Activity Log
                        cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)", con)

                        With cmd.Parameters
                            .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                            .Add("@BinNumber", SqlDbType.VarChar).Value = DeleteEntireRack
                            .Add("@PartNumber", SqlDbType.VarChar).Value = DeleteRowPart
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = DeleteRowHeat
                            .Add("@LotNumber", SqlDbType.VarChar).Value = DeleteRowLot
                            .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = DeleteRowPieces
                            .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = 0
                            .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = DeleteRowPieces * -1
                            .Add("@DivisionID", SqlDbType.VarChar).Value = DeleteRowDivision
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "DELETED"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                            .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                            .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = ""
                            .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Error Log
                        ErrorDate = Today()
                        ErrorDescription = "Inventory Racking - Activity Log Update"
                        ErrorUser = EmployeeLoginName
                        ErrorComment = "Bin # - " + DeleteEntireRack + " Part # - " + DeleteRowPart
                        ErrorDivision = EmployeeCompanyCode
                        ErrorReferenceNumber = DeleteEntireRack

                        TFPErrorLogUpdate()
                    End Try

                    'Delete entire rack
                    cmd = New SqlCommand("DELETE FROM RackingTransactionTable WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BinNumber", SqlDbType.VarChar).Value = DeleteEntireRack
                        .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If

            'Reload Datagrid
            ShowDataByFilters()
            CalculateEmptyRacks()
        ElseIf button = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub cmdPrintItemLocations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintItemLocations.Click
        GlobalPrintRackingType = "PrintPickTicket"
        GlobalPickListNumber = Val(txtPickTicketNumber.Text)
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            GlobalDivisionCode = "TWD"
        Else
            GlobalDivisionCode = EmployeeCompanyCode
        End If

        Using NewPrintRackingByFilter As New PrintRackingByFilter
            Dim Result = NewPrintRackingByFilter.ShowDialog()
        End Using
    End Sub

    'Menu Strip Items

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearAllFields()
        ClearVariables()
        ClearDataInDatagrid()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintRackContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintRackContentsToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    'Combo boxes

    Private Sub cboSearchPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        If cboSearchPartNumber.Text = "" Then
            lblQOH.Visible = False
            lblPartQOH.Visible = False
        Else
            LoadQOHForPart()
            lblPartQOH.Visible = True
            lblQOH.Visible = True
        End If
    End Sub

    Private Sub cboSearchPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadAddDescriptionByPart()

        If txtAddLotNumber.Text = "" And cboPartNumber.Text = "" Then
            'Do nothing
        ElseIf txtAddLotNumber.Text = "" And cboPartNumber.Text <> "" Then
            LoadPartData()
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadAddPartByDescription()
    End Sub

    'Text boxes

    Private Sub txtAddLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddLotNumber.TextChanged
        If txtAddLotNumber.Text = "" Then
            'Do nothing
        Else
            LoadLotData()
        End If
    End Sub

    Private Sub txtBoxQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxQuantity.TextChanged
        Dim TotalPieces, TotalWeight As Double

        If txtBoxQuantity.Text <> "" And txtPiecesPerBox.Text <> "" Then
            TotalPieces = Val(txtBoxQuantity.Text) * Val(txtPiecesPerBox.Text)
            TotalPieces = Math.Round(TotalPieces, 0)
            TotalWeight = TotalPieces * Val(lblPieceWeight.Text)
            TotalWeight = Math.Round(TotalWeight, 0)

            txtAddRackingWeight.Text = TotalWeight
            txtAddTotalPieces.Text = TotalPieces
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtPiecesPerBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiecesPerBox.TextChanged
        Dim TotalPieces, TotalWeight As Double

        If txtBoxQuantity.Text <> "" And txtPiecesPerBox.Text <> "" Then
            TotalPieces = Val(txtBoxQuantity.Text) * Val(txtPiecesPerBox.Text)
            TotalPieces = Math.Round(TotalPieces, 0)
            TotalWeight = TotalPieces * Val(lblPieceWeight.Text)
            TotalWeight = Math.Round(TotalWeight, 0)

            txtAddRackingWeight.Text = TotalWeight
            txtAddTotalPieces.Text = TotalPieces
        Else
            'Do nothing
        End If
    End Sub

    'Datagrid events

    Private Sub dgvRackingTransactions_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRackingTransactions.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvRackingTransactions_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRackingTransactions.RowHeaderMouseClick
        LoadRackTotals()
    End Sub

    Private Sub dgvRackingTransactions_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRackingTransactions.CellClick
        LoadRackTotals()
    End Sub

    Private Sub dgvRackingTransactions_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRackingTransactions.CellContentClick
        LoadRackTotals()
    End Sub

    Private Sub dgvRackingTransactions_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRackingTransactions.CellValueChanged
        Dim RowRackingKey As Integer = 0
        Dim RowTotalPieces, RowTotalBoxes, RowPiecesPerBox, RowRackingWeight, GetPieceWeight, RowPieceWeight As Double
        Dim RowDivisionID As String = ""
        Dim RowPartNumber As String = ""
        Dim RowPartDescription As String = ""
        Dim RowBinNumber, RowHeatNumber, RowLotNumber, RowRackComment As String

        If Me.dgvRackingTransactions.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvRackingTransactions.CurrentCell.RowIndex

            Try
                RowRackingKey = Me.dgvRackingTransactions.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As Exception
                RowRackingKey = 0
            End Try
            Try
                RowTotalBoxes = Me.dgvRackingTransactions.Rows(RowIndex).Cells("BoxQuantityColumn").Value
                RowTotalBoxes = Math.Round(RowTotalBoxes, 0)
            Catch ex As Exception
                RowTotalBoxes = 0
            End Try
            Try
                RowPiecesPerBox = Me.dgvRackingTransactions.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
                RowPiecesPerBox = Math.Round(RowPiecesPerBox, 0)
            Catch ex As Exception
                RowPiecesPerBox = 0
            End Try
            Try
                RowPieceWeight = Me.dgvRackingTransactions.Rows(RowIndex).Cells("PieceWeightColumn").Value
            Catch ex As Exception
                RowPieceWeight = 0
            End Try
            Try
                RowDivisionID = Me.dgvRackingTransactions.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivisionID = EmployeeCompanyCode
            End Try
            Try
                RowPartNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowPartDescription = Me.dgvRackingTransactions.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                RowPartDescription = ""
            End Try
            Try
                RowBinNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("BinNumberColumn").Value
            Catch ex As Exception
                RowBinNumber = ""
            End Try
            Try
                RowHeatNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("HeatNumberColumn").Value
            Catch ex As Exception
                RowHeatNumber = ""
            End Try
            Try
                RowLotNumber = Me.dgvRackingTransactions.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As Exception
                RowLotNumber = ""
            End Try
            Try
                RowRackComment = Me.dgvRackingTransactions.Rows(RowIndex).Cells("RackCommentColumn").Value
            Catch ex As Exception
                RowRackComment = ""
            End Try

            If RowPieceWeight = 0 Then
                'Get Piece weight
                Dim GetPieceWeightString As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TFP' OR DivisionID = 'TWD')"
                Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightString, con)
                GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                GetPieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetPieceWeight = 0
                End Try
                con.Close()

                RowPieceWeight = GetPieceWeight
            End If

            RowTotalPieces = RowTotalBoxes * RowPiecesPerBox
            RowRackingWeight = RowTotalPieces * RowPieceWeight
            RowRackingWeight = Math.Round(RowRackingWeight, 0)

            'Get Original Pieces before update
            Dim GetOriginalPieces As Integer = 0

            Dim GetOriginalPiecesString As String = "SELECT TotalPieces FROM RackingTransactionTable WHERE RackingKey = @RackingKey"
            Dim GetOriginalPiecesCommand As New SqlCommand(GetOriginalPiecesString, con)
            GetOriginalPiecesCommand.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RowRackingKey

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetOriginalPieces = CInt(GetOriginalPiecesCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetOriginalPieces = 0
            End Try
            con.Close()
            '***********************************************************************************************************************************
            'Get Time and Date
            Dim TodaysDate As DateTime = Now()
            Dim intHours, intMinutes, intSeconds As Integer
            Dim strHours, strMinutes, strSeconds As String
            Dim RackTime As String = ""
            Dim RackDate As String = ""

            intHours = TodaysDate.Hour
            intMinutes = TodaysDate.Minute
            intSeconds = TodaysDate.Second

            strHours = CStr(intHours)
            strMinutes = CStr(intMinutes)
            strSeconds = CStr(intSeconds)

            RackTime = strHours + ":" + strMinutes + ":" + strSeconds
            RackDate = TodaysDate.ToString()
            '********************************************************************************************************
            If RowTotalPieces - GetOriginalPieces = 0 Then
                'Skip - no activity if piece count did not change
            Else
                Try
                    'Update Racking Activity Log
                    cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID, ReferenceNumber, RackTime, RackDate, PickTicketNumber, LoginComputer) Values (@ActivityDateTime, @BinNumber, @PartNumber, @HeatNumber, @LotNumber, @OriginalTotalPieces, @CurrentTotalPieces, @TotalPiecesDifference, @DivisionID, @TransactionType, @UserID, @ReferenceNumber, @RackTime, @RackDate, @PickTicketNumber, @LoginComputer)", con)

                    With cmd.Parameters
                        .Add("@ActivityDateTime", SqlDbType.VarChar).Value = Now()
                        .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                        .Add("@OriginalTotalPieces", SqlDbType.VarChar).Value = GetOriginalPieces
                        .Add("@CurrentTotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                        .Add("@TotalPiecesDifference", SqlDbType.VarChar).Value = RowTotalPieces - GetOriginalPieces
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "UPDATED"
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                        .Add("@RackTime", SqlDbType.VarChar).Value = RackTime
                        .Add("@RackDate", SqlDbType.VarChar).Value = RackDate
                        .Add("@PickTicketNumber", SqlDbType.VarChar).Value = ""
                        .Add("@LoginComputer", SqlDbType.VarChar).Value = LoginPCName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                    Dim TempBinNumber As String = ""

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = RowDivisionID
                    ErrorDescription = "Inventory Racking - Rack Activity - changes in datagrid"
                    ErrorReferenceNumber = "Bin # " + TempBinNumber + ", Part # - " + RowPartNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
            '********************************************************************************************************
            Try
                'Update Line
                cmd = New SqlCommand("UPDATE RackingTransactionTable SET BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate, AddedBy = @AddedBy, Comment = @Comment WHERE RackingKey = @RackingKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RowRackingKey
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = RowTotalBoxes
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = RowPiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = RowRackingWeight
                    .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@Comment", SqlDbType.VarChar).Value = RowRackComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                Dim strRackingKey As String = ""
                Dim TempRackingKey As Integer = 0

                TempRackingKey = RowRackingKey
                strRackingKey = CStr(TempRackingKey)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = RowDivisionID
                ErrorDescription = "Inventory Racking - UPDATE Racking Transactions"
                ErrorReferenceNumber = "Racking Key - " + strRackingKey
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*************************************************************************************************************
            Try
                'Update Racking Master List (records all entries)
                cmd = New SqlCommand("INSERT INTO RackingMasterList (RackingKey, BinNumber, PartNumber, PartDescription, HeatNumber, LotNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, DivisionID, CreationDate) Values (@RackingKey, @BinNumber, @PartNumber, @PartDescription, @HeatNumber, @LotNumber, @BoxQuantity, @PiecesPerBox, @TotalPieces, @RackingWeight, @DivisionID, @CreationDate)", con)

                With cmd.Parameters
                    .Add("@RackingKey", SqlDbType.VarChar).Value = RowRackingKey
                    .Add("@BinNumber", SqlDbType.VarChar).Value = RowBinNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = RowPartDescription
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                    .Add("@BoxQuantity", SqlDbType.VarChar).Value = RowTotalBoxes
                    .Add("@PiecesPerBox", SqlDbType.VarChar).Value = RowPiecesPerBox
                    .Add("@TotalPieces", SqlDbType.VarChar).Value = RowTotalPieces
                    .Add("@RackingWeight", SqlDbType.VarChar).Value = RowRackingWeight
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = RowDivisionID
                ErrorDescription = "View/Edit Racks - Racking Master List - changes in datagrid"
                ErrorReferenceNumber = "Bin # " + RowBinNumber + ", Part # - " + RowPartNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************************
            'Load(DataGrid)
            ShowDataByFilters()
        End If
    End Sub

    'Misc

    Private Sub llTotalEmptyRacks_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTotalEmptyRacks.LinkClicked
        If EmployeeCompanyCode = "ADM" Or EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            GlobalDivisionCode = "TWD"
        Else
            GlobalDivisionCode = EmployeeCompanyCode
        End If

        Using NewInventoryRackingEmptyBins As New InventoryRackingEmptyBins
            Dim Result = NewInventoryRackingEmptyBins.ShowDialog()
        End Using
    End Sub

End Class