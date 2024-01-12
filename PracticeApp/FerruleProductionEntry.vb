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
Public Class FerruleProductionEntry
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Const LaborRate As Double = 0.56
    Const OverheadRate As Double = 0.56 * 0.75

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim LastFerruleTransactionKey, NextFerruleTransactionKey As Integer

    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False
    Dim ErrorOnPosting As Boolean = False

    Private Structure BatchCosts
        Public FCKaolinCost As Double
        Public M23ClayCost As Double
        Public SilverlineCost As Double
        Public MulliteCost As Double
        Public FeldsparCost As Double
        Public GoulacCost As Double
        Public BatchCost As Double
        Public CostPerPound As Double
        Public CostPerPoundRM As Double
    End Structure

    Private Sub FerruleProductionEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        usefulFunctions.LoadSecurity(Me)
        dgvFerruleProductionGrid.Enabled = True
        dgvFerruleProductionGrid.ReadOnly = False

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM FerruleProductionLines WHERE FerruleProductionKey = @FerruleProductionKey", con)
        cmd.Parameters.Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FerruleProductionLines")
        dgvFerruleProductionGrid.DataSource = ds.Tables("FerruleProductionLines")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvFerruleProductionGrid.DataSource = Nothing
    End Sub

    Public Sub LoadFerruleTransactionKeys()
        cmd = New SqlCommand("SELECT FerruleTransactionKey FROM FerruleProductionHeaderTable WHERE DivisionID = @DivisionID AND Status = 'OPEN'", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "FerruleProductionHeaderTable")
        cboFerruleProductionKey.DataSource = ds2.Tables("FerruleProductionHeaderTable")
        con.Close()
        cboFerruleProductionKey.SelectedIndex = -1
    End Sub

    Public Sub LoadFerruleLines()
        cmd = New SqlCommand("SELECT FerruleLineKey FROM FerruleProductionLines WHERE FerruleProductionKey = @FerruleProductionKey ORDER BY FerruleLineKey ASC", con)
        cmd.Parameters.Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "FerruleProductionLines")
        cboDeleteLine.DataSource = ds3.Tables("FerruleProductionLines")
        con.Close()
        cboDeleteLine.SelectedIndex = -1
    End Sub

    Private Sub LoadParts()
        Dim cmd As New SqlCommand("SELECT ItemID, ShortDescription, LongDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ds1 As New DataSet()
        Dim myAdapter1 As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "ItemList")
        con.Close()

        cboPartNumber.DisplayMember = "ItemID"
        cboPartDescription.DisplayMember = "ShortDescription"
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Private Sub LoadStatus()
        Dim StatusCommand As New SqlCommand("SELECT Status FROM FerruleProductionHeaderTable WHERE FerruleTransactionKey = @FerruleTransactionKey AND DivisionID = @DivisionID", con)
        StatusCommand.Parameters.Add("@FerruleTransactionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
        StatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            lblStatus.Text = CStr(StatusCommand.ExecuteScalar)
        Catch ex As Exception
            lblStatus.Text = "OPEN"
        End Try
        con.Close()

        If lblStatus.Text.Equals("CLOSED") Then
            cmdDelete.Enabled = False
            cmdAddLine.Enabled = False
            cmdPost.Enabled = False
            cmdSave.Enabled = False
            cmdDeleteLine.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdAddLine.Enabled = True
            cmdPost.Enabled = True
            cmdSave.Enabled = True
            cmdDeleteLine.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub LoadTransactionData()
        Dim cmd As New SqlCommand("SELECT ProductionDate, TotalCost, TotalWeight, Comment, Status FROM FerruleProductionHeaderTable WHERE FerruleTransactionKey = @FerruleTransactionKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@FerruleTransactionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ProductionDate")) Then
                dtpProductionDate.Value = Today()
            Else
                dtpProductionDate.Value = reader.Item("ProductionDate")
            End If
            If IsDBNull(reader.Item("TotalCost")) Then
                txtTotalCost.Text = FormatCurrency(0, 2)
            Else
                txtTotalCost.Text = FormatCurrency(reader.Item("TotalCost"), 2)
            End If
            If IsDBNull(reader.Item("TotalWeight")) Then
                txtTotalWeight.Text = FormatNumber(0, 2)
            Else
                txtTotalWeight.Text = FormatNumber(reader.Item("TotalWeight"), 2)
            End If
            If IsDBNull(reader.Item("Comment")) Then
                txtComments.Text = ""
            Else
                txtComments.Text = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("Status")) Then
                lblStatus.Text = "OPEN"
            Else
                lblStatus.Text = reader.Item("Status")
            End If
        Else
            dtpProductionDate.Value = Today()
            txtTotalCost.Text = FormatCurrency(0, 2)
            txtTotalWeight.Text = FormatNumber(0, 2)
            txtComments.Text = ""
            lblStatus.Text = "OPEN"
        End If
        reader.Close()
        LoadTotals()
        con.Close()

        If lblStatus.Text = "CLOSED" Then
            cmdDelete.Enabled = False
            cmdAddLine.Enabled = False
            cmdPost.Enabled = False
            cmdSave.Enabled = False
            cmdDeleteLine.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdAddLine.Enabled = True
            cmdPost.Enabled = True
            cmdSave.Enabled = True
            cmdDeleteLine.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub LoadTotals()
        Dim TotalCostStatement As String = "SELECT SUM(ExtendedCost) as TotalExtendedCost, SUM(LineWeight) as TotalLineWeight, SUM(ProductionQuantity) as TotalQuantity FROM FerruleProductionLines WHERE FerruleProductionKey = @FerruleProductionKey AND ExtendedCost > 0"
        Dim TotalCostCommand As New SqlCommand(TotalCostStatement, con)
        TotalCostCommand.Parameters.Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = TotalCostCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TotalExtendedCost")) Then
                txtTotalCost.Text = FormatCurrency(0, 2)
            Else
                txtTotalCost.Text = FormatCurrency(reader.Item("TotalExtendedCost"), 2)
            End If
            If IsDBNull(reader.Item("TotalLineWeight")) Then
                txtTotalWeight.Text = FormatNumber(0, 2)
            Else
                txtTotalWeight.Text = FormatNumber(reader.Item("TotalLineWeight"), 2)
            End If
            If IsDBNull(reader.Item("TotalQuantity")) Then
                txtTotalUnits.Text = 0
            Else
                txtTotalUnits.Text = reader.Item("TotalQuantity")
            End If
        Else
            txtTotalCost.Text = FormatCurrency(0, 2)
            txtTotalWeight.Text = FormatNumber(0, 2)
            txtTotalUnits.Text = 0
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cmdGenerateNewProductionNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewProductionNumber.Click
        isLoaded = False

        'Get next Batch Number
        Dim MAXBatchStatement As String = "SELECT MAX(FerruleTransactionKey) FROM FerruleProductionHeaderTable"
        Dim MAXBatchCommand As New SqlCommand(MAXBatchStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastFerruleTransactionKey = CInt(MAXBatchCommand.ExecuteScalar)
        Catch ex As Exception
            LastFerruleTransactionKey = 358000000
        End Try
        con.Close()

        NextFerruleTransactionKey = LastFerruleTransactionKey + 1
        cboFerruleProductionKey.Text = NextFerruleTransactionKey
        lblStatus.Text = "OPEN"

        Try
            'Command to write Header Data
            cmd = New SqlCommand("Insert Into FerruleProductionHeaderTable (FerruleTransactionKey, ProductionDate, DivisionID, Comment, TotalCost, TotalWeight, Status)values(@FerruleTransactionKey, @ProductionDate, @DivisionID, @Comment, @TotalCost, @TotalWeight, @Status)", con)

            With cmd.Parameters
                .Add("@FerruleTransactionKey", SqlDbType.VarChar).Value = NextFerruleTransactionKey
                .Add("@ProductionDate", SqlDbType.VarChar).Value = dtpProductionDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
                .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                .Add("@TotalWeight", SqlDbType.VarChar).Value = 0
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempFerruleProductionNumber As Integer = 0
            Dim strTempFerruleProductionNumber As String
            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Ferrule Production - Create New"
            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        isLoaded = True
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadFerruleTransactionKeys()
        LoadParts()
    End Sub

    Private Function GetBatchCost() As BatchCosts
        Dim FCKaolinCostStatement As String = "SELECT (SELECT StandardCost FROM ItemList WHERE ItemID = 'FC KAOLIN' AND DivisionID = @DivisionID) as FCKaolinCost" + _
            ",(SELECT StandardCost FROM ItemList WHERE ItemID = 'M-23CLAY' AND DivisionID = @DivisionID) as M23ClayCost" + _
            ", (SELECT StandardCost FROM ItemList WHERE ItemID = 'SILVERLINE 001 TALC' AND DivisionID = @DivisionID) as SilverlineCost" + _
            ", (SELECT StandardCost FROM ItemList WHERE ItemID = 'MULLITE' AND DivisionID = @DivisionID) as MulliteCost" + _
            ", (SELECT StandardCost FROM ItemList WHERE ItemID = 'FELDSPAR' AND DivisionID = @DivisionID) as FeldsparCost" + _
            ", (SELECT StandardCost FROM ItemList WHERE ItemID = 'GOULAC' AND DivisionID = @DivisionID) as GoulacCost" + _
            ", (SELECT PieceWeight FROM ItemList WHERE ItemID = 'Batch Mix' AND DivisionID = @DivisionID) as BatchMixWeight"
        Dim FCKaolinCostCommand As New SqlCommand(FCKaolinCostStatement, con)
        FCKaolinCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchCsts As New BatchCosts
        Dim batchWeight As Double = 0D

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = FCKaolinCostCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("FCKaolinCost")) Then
                BatchCsts.FCKaolinCost = 0
            Else
                BatchCsts.FCKaolinCost = reader.Item("FCKaolinCost")
            End If
            If IsDBNull(reader.Item("M23ClayCost")) Then
                BatchCsts.M23ClayCost = 0
            Else
                BatchCsts.M23ClayCost = reader.Item("M23ClayCost")
            End If
            If IsDBNull(reader.Item("SilverlineCost")) Then
                BatchCsts.SilverlineCost = 0
            Else
                BatchCsts.SilverlineCost = reader.Item("SilverlineCost")
            End If
            If IsDBNull(reader.Item("MulliteCost")) Then
                BatchCsts.MulliteCost = 0
            Else
                BatchCsts.MulliteCost = reader.Item("MulliteCost")
            End If
            If IsDBNull(reader.Item("FeldsparCost")) Then
                BatchCsts.FeldsparCost = 0
            Else
                BatchCsts.FeldsparCost = reader.Item("FeldsparCost")
            End If
            If IsDBNull(reader.Item("GoulacCost")) Then
                BatchCsts.GoulacCost = 0
            Else
                BatchCsts.GoulacCost = reader.Item("GoulacCost")
            End If
            If IsDBNull(reader.Item("BatchMixWeight")) Then
                batchWeight = 645
            Else
                batchWeight = reader.Item("BatchMixWeight")
            End If
        Else
            BatchCsts.FCKaolinCost = 0
            BatchCsts.M23ClayCost = 0
            BatchCsts.SilverlineCost = 0
            BatchCsts.MulliteCost = 0
            BatchCsts.FeldsparCost = 0
            BatchCsts.GoulacCost = 0
            batchWeight = 645
        End If
        reader.Close()
        con.Close()

        'Calculate Cost of Batch for Raw Materials
        BatchCsts.BatchCost = Math.Round((BatchCsts.FCKaolinCost * 150) + (BatchCsts.M23ClayCost * 175) + (BatchCsts.SilverlineCost * 200) + (BatchCsts.MulliteCost * 75) + (BatchCsts.FeldsparCost * 25) + (BatchCsts.GoulacCost * 20), 2, MidpointRounding.AwayFromZero)
        ''Batch cost per pound for only raw material
        BatchCsts.CostPerPoundRM = Math.Round(BatchCsts.BatchCost / batchWeight, 5, MidpointRounding.AwayFromZero)
        'Add Overhead and Labor
        BatchCsts.CostPerPound = Math.Round(BatchCsts.CostPerPoundRM + LaborRate + OverheadRate, 5, MidpointRounding.AwayFromZero)
        BatchCsts.BatchCost = BatchCsts.CostPerPound * batchWeight
        Return BatchCsts
    End Function

    Public Sub ClearLines()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        lblLongDescription.Text = ""
        lblLineWeight.Text = ""
        lblPieceWeight.Text = ""
        lblUnitCost.Text = ""
        lblExtendedAmount.Text = ""

        txtPiecesProduced.Clear()

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearAll()
        cboFerruleProductionKey.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFerruleProductionKey.Text) Then
            cboFerruleProductionKey.Text = ""
        End If
        cboPartDescription.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            cboPartDescription.Text = ""
        End If

        txtComments.Clear()
        txtPiecesProduced.Clear()
        txtTotalCost.Clear()
        txtTotalUnits.Clear()
        txtTotalWeight.Clear()

        lblExtendedAmount.Text = ""
        lblLineWeight.Text = ""
        lblPieceWeight.Text = ""
        lblUnitCost.Text = ""
        lblStatus.Text = ""
        lblLongDescription.Text = ""

        cmdDelete.Enabled = True
        cmdAddLine.Enabled = True
        cmdPost.Enabled = True
        cmdSave.Enabled = True
        cmdDeleteLine.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem.Enabled = True
        dgvFerruleProductionGrid.DataSource = Nothing

        dtpProductionDate.Text = ""

        cmdGenerateNewProductionNumber.Focus()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            If cboPartNumber.SelectedIndex <> -1 Then

                lblLongDescription.Text = CType(cboPartNumber.DataSource, DataTable).Rows(cboPartNumber.SelectedIndex).Item("LongDescription").ToString()
                If String.IsNullOrEmpty(cboPartDescription.Text) Then
                    cboPartDescription.Text = CType(cboPartNumber.DataSource, DataTable).Rows(cboPartNumber.SelectedIndex).Item("ShortDescription").ToString()
                End If

                LoadPartData()

                Dim BatchCst As BatchCosts = GetBatchCost()

                If cboPartNumber.Text.Equals("Batch Mix") Then
                    lblUnitCost.Text = FormatCurrency(BatchCst.BatchCost, 5)
                Else
                    Dim cmd As New SqlCommand("SELECT PurchProdLineID, SalesProdLineID FROM ItemList Where ItemID = @ItemID AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim TapeType, TapeSize As String
                    Dim TapeCost As Double = 0D

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("PurchProdLineID")) Then
                            TapeType = ""
                        Else
                            TapeType = reader.Item("PurchProdLineID")
                        End If
                        If IsDBNull(reader.Item("SalesProdLineID")) Then
                            TapeSize = ""
                        Else
                            TapeSize = reader.Item("SalesProdLineID")
                        End If
                    Else
                        TapeType = ""
                        TapeSize = ""
                    End If
                    reader.Close()
                    con.Close()

                    If TapeType.StartsWith("TAPE3") Then
                        If TapeSize.Equals("TAPE-1FT") Or TapeSize.Equals("TAPE-2FT") Then
                            TapeCost = GetFIFOCost(TapeType, 1)
                            If TapeSize.Equals("TAPE-2FT") Then
                                TapeCost = TapeCost * 2
                            End If
                        End If
                    Else
                        ''check to see if tape type needs changed
                        If TapeType.Equals("ORING-1FOOT") Then
                            TapeType = "O-RING"
                        End If
                        If TapeType.Equals("O-RING") Then
                            TapeCost = GetFIFOCost(TapeType, 1)
                        End If
                    End If
                    lblUnitCost.Text = FormatCurrency(BatchCst.CostPerPound * Val(lblPieceWeight.Text) + TapeCost, 5)
                End If
            Else
                lblLongDescription.Text = ""
                lblPieceWeight.Text = ""
                lblUnitCost.Text = ""
            End If
        End If
    End Sub

    Private Sub cboFerruleProductionKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFerruleProductionKey.SelectedIndexChanged
        If cboFerruleProductionKey.Text = "" Then
            ClearDataInDatagrid()
            ClearLines()
            dtpProductionDate.Value = Today()
        Else
            ClearLines()
            LoadTransactionData()
            LoadFerruleLines()
            LoadTotals()
            ShowData()
        End If
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        If canAddLine() Then
            'Load Totals
            LoadTotals()
            Dim BatchCst As BatchCosts = GetBatchCost()

            'Write to Ferrule Header Table if necessary
            Try
                updateFerruleProductionHeaderTable("OPEN")
            Catch ex As Exception
                'Log error on update failure
                Dim TempFerruleProductionNumber As Integer = 0
                Dim strTempFerruleProductionNumber As String
                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Ferrule Production - Add Line"
                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Write to line table
            Dim cmd = New SqlCommand("Insert Into FerruleProductionLines(FerruleProductionKey, FerruleLineKey, PartNumber, PartDescription, ProductionQuantity, UnitCost, ExtendedCost, LineWeight) Values(@FerruleProductionKey, (SELECT isnull(MAX(FerruleLineKey) + 1, 1) FROM FerruleProductionLines WHERE FerruleProductionKey = @FerruleProductionKey), @PartNumber, @PartDescription, @ProductionQuantity, @UnitCost, @ExtendedCost, @LineWeight);", con)

            With cmd.Parameters
                .Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@UnitCost", SqlDbType.Float).Value = Val(lblUnitCost.Text.Replace("$", "").Replace(",", ""))
                .Add("@ExtendedCost", SqlDbType.Float).Value = Val(lblExtendedAmount.Text.Replace("$", "").Replace(",", ""))
                .Add("@ProductionQuantity", SqlDbType.Float).Value = Val(txtPiecesProduced.Text.Replace(",", ""))
                .Add("@LineWeight", SqlDbType.Float).Value = Val(lblLineWeight.Text.Replace(",", ""))
            End With

            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                'Log error on update failure
                Dim TempFerruleProductionNumber As Integer = 0
                Dim strTempFerruleProductionNumber As String
                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Ferrule Production - Add Line"
                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            con.Close()

            isLoaded = False
            ClearLines()
            isLoaded = True
            LoadTransactionData()
            LoadTotals()
            ShowData()
        End If
    End Sub

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboFerruleProductionKey.Text) Then
            MsgBox("You must have a valid Transaction Number selected to continue.", MsgBoxStyle.OkOnly)
            cboFerruleProductionKey.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPiecesProduced.Text) Then
            MessageBox.Show("You must enter an amount producted", "Enter an amount produced", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesProduced.Focus()
            Return False
        End If
        If IsNumeric(txtPiecesProduced.Text) = False Then
            MessageBox.Show("You must enter a number for pieces produced", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesProduced.SelectAll()
            txtPiecesProduced.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub updateFerruleProductionHeaderTable(Optional ByVal status As String = "OPEN")
        Dim cmd = New SqlCommand("UPDATE FerruleProductionHeaderTable SET ProductionDate = @ProductionDate, Comment = @Comment, TotalCost = @TotalCost, TotalWeight = @TotalWeight, Status = @Status WHERE FerruleTransactionKey = @FerruleTransactionKey AND DivisionID = @DivisionID;", con)

        With cmd.Parameters
            .Add("@FerruleTransactionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
            .Add("@ProductionDate", SqlDbType.Date).Value = dtpProductionDate.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
            .Add("@TotalCost", SqlDbType.Float).Value = Val(txtTotalCost.Text.Replace("$", "").Replace(",", ""))
            .Add("@TotalWeight", SqlDbType.Float).Value = Val(txtTotalWeight.Text.Replace(",", ""))
            .Add("@Status", SqlDbType.VarChar).Value = status
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub LoadPartData()
        Dim cmd As New SqlCommand("SELECT LongDescription, PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                lblLongDescription.Text = ""
            Else
                lblLongDescription.Text = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                lblPieceWeight.Text = 0
            Else
                lblPieceWeight.Text = reader.Item("PieceWeight")
            End If
        Else
            lblLongDescription.Text = ""
            lblPieceWeight.Text = 0
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub txtPiecesProduced_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiecesProduced.TextChanged
        UpdateLineEntryTotals()
    End Sub

    Private Sub UpdateLineEntryTotals()
        If cboPartNumber.Text = "Batch Mix" Then
            Dim PiecesProduced As Double = Val(txtPiecesProduced.Text)
            Dim ExtendedAmount As Double = Val(lblUnitCost.Text.Replace("$", "").Replace(",", "")) * PiecesProduced
            Dim LineWeight As Double = PiecesProduced * Val(lblPieceWeight.Text)
            lblLineWeight.Text = FormatNumber(LineWeight, 2)
            lblExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
        Else
            Dim PiecesProduced As Double = Val(txtPiecesProduced.Text)
            Dim LineWeight As Double = PiecesProduced * Val(lblPieceWeight.Text)
            lblLineWeight.Text = FormatNumber(LineWeight, 2)
            Dim ExtendedAmount As Double = Val(lblUnitCost.Text.Replace("$", "").Replace(",", "")) * PiecesProduced
            lblExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
        End If
    End Sub

    Private Sub txtPiecesProduced_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPiecesProduced.KeyDown
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod Then
            controlKey = True
        End If
    End Sub

    Private Sub txtPiecesProduced_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPiecesProduced.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub DeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If canDeleteLine() Then
            Try
                ''command ot delete the line
                Dim cmd As New SqlCommand("DELETE FROM FerruleProductionLines WHERE FerruleProductionKey = @FerruleProductionKey AND FerruleLineKey = @FerruleLineKey;", con)
                ''command to renumber the lines
                cmd.CommandText += " UPDATE FerruleProductionLines SET FerruleLineKey = FerruleLineKey - 1 WHERE FerruleProductionKey = @FerruleProductionKey AND FerruleLineKey > @FerruleLineKey"

                With cmd.Parameters
                    .Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
                    .Add("@FerruleLineKey", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'sendErrorToDataBase("FerruleProductionEntry - cmdDeleteLine_Click --Error trying to delete line #" + cboDeleteLine.Text, "Ferrule production #" + cboFerruleProductionKey.Text, ex.ToString())
                MessageBox.Show("Error trying to delete seleted line, contact system admin", "Unable to delete line", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ShowData()
            LoadTotals()
        End If
    End Sub

    Private Function canDeleteLine() As Boolean
        If String.IsNullOrEmpty(cboFerruleProductionKey.Text) Then
            MsgBox("You must have a valid batch number selected to delete a line.", MsgBoxStyle.OkOnly)
            cboFerruleProductionKey.Focus()
            Return False
        End If
        If lblStatus.Text.Equals("CLOSED") Then
            MsgBox("This Production Batch has been posted - you cannot delete Lines.", MsgBoxStyle.OkOnly)
            Return False
        End If
        If dgvFerruleProductionGrid.Rows.Count = 0 Then
            MessageBox.Show("There are no lines to delete", "No lines to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboDeleteLine.Text) Then
            MessageBox.Show("You must select a line to delete", "Select a line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteLine.Focus()
            Return False
        End If
        If MessageBox.Show("Do you wish to delete this Production Line Entry?", "DELETE PRODUCTION Line ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub FerruleProductionEntry_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ClearAll()
        ClearDataInDatagrid()
    End Sub

    Private Sub Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        ClearAll()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearFormToolStripMenuItem.Click
        ClearAll()
        ClearDataInDatagrid()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveToolStripMenuItem.Click
        If canSave() Then
            'Load Totals
            LoadTotals()

            'Write to Ferrule Header Table if necessary
            Try
                updateFerruleProductionHeaderTable("OPEN")
                MessageBox.Show("Data has been saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                'Log error on update failure
                Dim TempFerruleProductionNumber As Integer = 0
                Dim strTempFerruleProductionNumber As String
                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Ferrule Production - Save Command"
                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboFerruleProductionKey.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteToolStripMenuItem.Click
        If canDelete() Then
            'Delete command
            Try
                Dim cmd As New SqlCommand("DELETE FROM FerruleProductionHeaderTable WHERE FerruleTransactionKey = @FerruleTransactionKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@FerruleTransactionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempFerruleProductionNumber As Integer = 0
                Dim strTempFerruleProductionNumber As String
                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Ferrule Production - Delete Command"
                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MessageBox.Show("There was an error trying to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            LoadFerruleTransactionKeys()
            ClearAll()
            ClearDataInDatagrid()
        End If
    End Sub

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboFerruleProductionKey.Text) Then
            MsgBox("You must have a valid Transaction Number selected.", MsgBoxStyle.OkOnly)
            cboFerruleProductionKey.Focus()
            Return False
        End If
        If lblStatus.Text.Equals("CLOSED") Then
            MsgBox("This Production Batch has been posted - you cannot delete.", MsgBoxStyle.OkOnly)
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Production Entry?", "DELETE PRODUCTION ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintToolStripMenuItem.Click
        If canPrint() Then
            If Not lblStatus.Text.Equals("CLOSED") Then
                ''Saves the data of the current batch
                Save_Click(sender, e)
            End If

            GlobalWCProductionNumber = Val(cboFerruleProductionKey.Text)

            Using NewPrintWCProduction As New PrintWCProduction
                Dim Result = NewPrintWCProduction.ShowDialog()
            End Using
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboFerruleProductionKey.Text) Then
            MessageBox.Show("There is no batch number entered", "Unable to print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboFerruleProductionKey.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPost.Click
        If canPost() Then
            Dim GLCommand As New SqlCommand("BEGIN TRAN DECLARE @GLTransactionKey as int = (SELECT isnull(MAX(GLTransactionKey), 22000000) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES ", con)
            GLCommand.Parameters.Add("@GLTransactionDate", SqlDbType.Date).Value = dtpProductionDate.Value
            GLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim GLLineCount As Integer = 1
            Dim firstGLLine As Boolean = True

            Dim InventoryTransCommand As New SqlCommand("BEGIN TRAN DECLARE @TransactionNumber as int = (SELECT isnull(MAX(TransactionNumber), 1000000) FROM InventoryTransactionTable); SET xact_abort on; Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount) VALUES", con)
            Dim InventoryTransNumber As Integer = 1
            InventoryTransCommand.Parameters.Add("@TransactionDate", SqlDbType.Date).Value = dtpProductionDate.Value
            InventoryTransCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            Dim firstTrans As Boolean = True

            Dim FerruleProductionLinesCommand As New SqlCommand("BEGIN TRAN SET xact_abort on; Insert Into FerruleProductionLines(FerruleProductionKey, FerruleLineKey, PartNumber, PartDescription, ProductionQuantity, UnitCost, ExtendedCost, LineWeight) Values ", con)
            FerruleProductionLinesCommand.Parameters.Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
            Dim FerruleLineCount As Integer = 1
            Dim firstFerrLine As Boolean = True
            Dim GetItemClass As String = ""

            Dim InventoryCostingCount As Integer = 1
            Dim InventoryCostingCommand As New SqlCommand("BEGIN TRAN DECLARE @TransactionNumber as int = (SELECT isnull(MAX(TransactionNumber), 63600000) FROM InventoryCosting); ", con)
            InventoryCostingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            InventoryCostingCommand.Parameters.Add("@CostingDate", SqlDbType.Date).Value = dtpProductionDate.Value
            Dim InventoryCostingInserts As String = "Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine) VALUES "
            Dim firstCosting As Boolean = True

            Dim UpdateCommand As New SqlCommand("", con)
            Dim UpdateCount As Integer = 1
            Dim firstUpdate As Boolean = True

            Dim cmd As New SqlCommand("SELECT isnull(MAX(FerruleLineKey) + 1, 1) FROM FerruleProductionLines WHERE FerruleProductionKey = @FerruleProductionKey", con)
            cmd.Parameters.Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim NextFerruleProductionLineNumber As Integer = cmd.ExecuteScalar()

            For Each row As DataGridViewRow In dgvFerruleProductionGrid.Rows
                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = row.Cells("PartNumberColumn").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = ""
                End Try
                con.Close()

                If row.Cells("PartNumberColumn").Value.ToString().Equals("Batch Mix") Then
                    AddBatchMixEntries(row, GLCommand, GLLineCount, firstGLLine, InventoryTransCommand, InventoryTransNumber, firstTrans, InventoryCostingCommand, _
                                       InventoryCostingCount, InventoryCostingInserts, firstCosting, FerruleProductionLinesCommand, FerruleLineCount, firstFerrLine, _
                                       NextFerruleProductionLineNumber, UpdateCommand, firstUpdate, UpdateCount)
                ElseIf GetItemClass = "WC WELD TILES" Then
                    AddWeldTiles(row, GLCommand, GLLineCount, firstGLLine, InventoryTransCommand, InventoryTransNumber, firstTrans, InventoryCostingCommand, _
                                 InventoryCostingCount, InventoryCostingInserts, firstCosting, FerruleProductionLinesCommand, FerruleLineCount, firstFerrLine, _
                                 NextFerruleProductionLineNumber, UpdateCommand, firstUpdate, UpdateCount)
                Else
                    AddFerruleEntry(row, GLCommand, GLLineCount, firstGLLine, InventoryTransCommand, InventoryTransNumber, firstTrans, InventoryCostingCommand, _
                                    InventoryCostingCount, InventoryCostingInserts, firstCosting, FerruleProductionLinesCommand, FerruleLineCount, firstFerrLine, _
                                    NextFerruleProductionLineNumber, UpdateCommand, firstUpdate, UpdateCount)
                End If

                ''check to make sure there is no errors on posting, if there are it will completely back out of the posting process
                If ErrorOnPosting Then
                    Exit Sub
                End If

                If GLCommand.Parameters.Count > 2000 Or InventoryTransCommand.Parameters.Count > 2000 Or InventoryCostingCommand.Parameters.Count > 2000 Or FerruleProductionLinesCommand.Parameters.Count > 2000 Then
                    InventoryTransCommand.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
                    FerruleProductionLinesCommand.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
                    InventoryCostingCommand.CommandText += "; SET xact_abort on;" + InventoryCostingInserts + "; COMMIT TRAN; SET xact_abort OFF;"
                    GLCommand.CommandText += " COMMIT TRAN; SET xact_abort OFF;"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        InventoryTransCommand.ExecuteNonQuery()
                    Catch ex As SqlException
                        If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                            Try
                                InventoryTransCommand.ExecuteNonQuery()
                            Catch ex1 As Exception
                                'sendErrorToDataBase("FerruleProductionEntryTable - cmdPost_Click --Error trying to inserting Inventory Transaction Lines", "Ferrule Production #" + cboFerruleProductionKey.Text, ex1.ToString())
                                MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try
                        Else
                            'Log error on update failure
                            Dim TempFerruleProductionNumber As Integer = 0
                            Dim strTempFerruleProductionNumber As String
                            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Ferrule Production - Post Command"
                            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End Try
                    If con.State = ConnectionState.Closed Then con.Open()

                    Try
                        FerruleProductionLinesCommand.ExecuteNonQuery()
                    Catch ex As SqlException
                        If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                            Try
                                FerruleProductionLinesCommand.ExecuteNonQuery()
                            Catch ex1 As Exception
                                'Log error on update failure
                                Dim TempFerruleProductionNumber As Integer = 0
                                Dim strTempFerruleProductionNumber As String
                                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Ferrule Production - Post Command"
                                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()

                                MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try
                        Else
                            'Log error on update failure
                            Dim TempFerruleProductionNumber As Integer = 0
                            Dim strTempFerruleProductionNumber As String
                            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Ferrule Production - Post Command"
                            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End Try
                    If con.State = ConnectionState.Closed Then con.Open()

                    Try
                        InventoryCostingCommand.ExecuteNonQuery()
                    Catch ex As SqlException
                        If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                            Try
                                InventoryCostingCommand.ExecuteNonQuery()
                            Catch ex1 As Exception
                                'Log error on update failure
                                Dim TempFerruleProductionNumber As Integer = 0
                                Dim strTempFerruleProductionNumber As String
                                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Ferrule Production - Post Command"
                                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()

                                MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try
                        Else
                            'Log error on update failure
                            Dim TempFerruleProductionNumber As Integer = 0
                            Dim strTempFerruleProductionNumber As String
                            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Ferrule Production - Post Command"
                            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End Try
                    If con.State = ConnectionState.Closed Then con.Open()

                    Try
                        'Writes second value to the General Ledger (Raw Materials)
                        GLCommand.ExecuteNonQuery()
                    Catch ex As SqlException
                        If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                            Try
                                GLCommand.ExecuteNonQuery()
                            Catch ex1 As Exception
                                'Log error on update failure
                                Dim TempFerruleProductionNumber As Integer = 0
                                Dim strTempFerruleProductionNumber As String
                                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Ferrule Production - Post Command"
                                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()

                                MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try
                        Else
                            'Log error on update failure
                            Dim TempFerruleProductionNumber As Integer = 0
                            Dim strTempFerruleProductionNumber As String
                            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Ferrule Production - Post Command"
                            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End Try

                    If UpdateCount > 1 Then
                        Try
                            UpdateCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempFerruleProductionNumber As Integer = 0
                            Dim strTempFerruleProductionNumber As String
                            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Ferrule Production - Post Command"
                            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    End If

                    GLCommand = New SqlCommand("BEGIN TRAN DECLARE @GLTransactionKey as int = (SELECT isnull(MAX(GLTransactionKey), 22000000) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES ", con)
                    GLCommand.Parameters.Add("@GLTransactionDate", SqlDbType.Date).Value = dtpProductionDate.Value
                    GLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    GLLineCount = 1
                    firstGLLine = True

                    InventoryTransCommand = New SqlCommand("BEGIN TRAN DECLARE @TransactionNumber as int = (SELECT isnull(MAX(TransactionNumber), 1000000) FROM InventoryTransactionTable); SET xact_abort on; Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount) VALUES", con)
                    InventoryTransNumber = 1
                    InventoryTransCommand.Parameters.Add("@TransactionDate", SqlDbType.Date).Value = dtpProductionDate.Value
                    InventoryTransCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    firstTrans = True

                    FerruleProductionLinesCommand = New SqlCommand("BEGIN TRAN SET xact_abort on; Insert Into FerruleProductionLines(FerruleProductionKey, FerruleLineKey, PartNumber, PartDescription, ProductionQuantity, UnitCost, ExtendedCost, LineWeight) Values ", con)
                    FerruleProductionLinesCommand.Parameters.Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
                    FerruleLineCount = 1
                    firstFerrLine = True

                    InventoryCostingCount = 1
                    InventoryCostingCommand = New SqlCommand("BEGIN TRAN DECLARE @TransactionNumber as int = (SELECT isnull(MAX(TransactionNumber), 63600000) FROM InventoryCosting); ", con)
                    InventoryCostingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    InventoryCostingCommand.Parameters.Add("@CostingDate", SqlDbType.Date).Value = dtpProductionDate.Value
                    InventoryCostingInserts = "Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine) VALUES "
                    firstCosting = True

                    UpdateCommand = New SqlCommand("", con)
                    UpdateCount = 1
                    firstUpdate = True

                    cmd = New SqlCommand("SELECT isnull(MAX(FerruleLineKey) + 1, 1) FROM FerruleProductionLines WHERE FerruleProductionKey = @FerruleProductionKey", con)
                    cmd.Parameters.Add("@FerruleProductionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    NextFerruleProductionLineNumber = cmd.ExecuteScalar()
                End If
            Next
            InventoryTransCommand.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
            FerruleProductionLinesCommand.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
            InventoryCostingCommand.CommandText += "; SET xact_abort on;" + InventoryCostingInserts + "; COMMIT TRAN; SET xact_abort OFF;"
            GLCommand.CommandText += " COMMIT TRAN; SET xact_abort OFF;"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                InventoryTransCommand.ExecuteNonQuery()
            Catch ex As SqlException
                If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                    Try
                        InventoryTransCommand.ExecuteNonQuery()
                    Catch ex1 As Exception
                        'Log error on update failure
                        Dim TempFerruleProductionNumber As Integer = 0
                        Dim strTempFerruleProductionNumber As String
                        TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                        strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Ferrule Production - Post Command"
                        ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    'Log error on update failure
                    Dim TempFerruleProductionNumber As Integer = 0
                    Dim strTempFerruleProductionNumber As String
                    TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                    strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Ferrule Production - Post Command"
                    ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Try
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FerruleProductionLinesCommand.ExecuteNonQuery()
            Catch ex As SqlException
                If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                    Try
                        FerruleProductionLinesCommand.ExecuteNonQuery()
                    Catch ex1 As Exception
                        'Log error on update failure
                        Dim TempFerruleProductionNumber As Integer = 0
                        Dim strTempFerruleProductionNumber As String
                        TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                        strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Ferrule Production - Post Command"
                        ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    'Log error on update failure
                    Dim TempFerruleProductionNumber As Integer = 0
                    Dim strTempFerruleProductionNumber As String
                    TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                    strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Ferrule Production - Post Command"
                    ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Try

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                InventoryCostingCommand.ExecuteNonQuery()
            Catch ex As SqlException
                If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                    Try
                        InventoryCostingCommand.ExecuteNonQuery()
                    Catch ex1 As Exception
                        'Log error on update failure
                        Dim TempFerruleProductionNumber As Integer = 0
                        Dim strTempFerruleProductionNumber As String
                        TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                        strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Ferrule Production - Post Command"
                        ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    'Log error on update failure
                    Dim TempFerruleProductionNumber As Integer = 0
                    Dim strTempFerruleProductionNumber As String
                    TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                    strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Ferrule Production - Post Command"
                    ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Try

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                'Writes second value to the General Ledger (Raw Materials)
                GLCommand.ExecuteNonQuery()
            Catch ex As SqlException
                If ex.ToString.Contains("Violation of PRIMARY KEY") Then
                    Try
                        GLCommand.ExecuteNonQuery()
                    Catch ex1 As Exception
                        'Log error on update failure
                        Dim TempFerruleProductionNumber As Integer = 0
                        Dim strTempFerruleProductionNumber As String
                        TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                        strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Ferrule Production - Post Command"
                        ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    'Log error on update failure
                    Dim TempFerruleProductionNumber As Integer = 0
                    Dim strTempFerruleProductionNumber As String
                    TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                    strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Ferrule Production - Post Command"
                    ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Try

            If con.State = ConnectionState.Closed Then con.Open()
            If UpdateCount > 1 Then
                Try
                    UpdateCommand.ExecuteNonQuery()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempFerruleProductionNumber As Integer = 0
                    Dim strTempFerruleProductionNumber As String
                    TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                    strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Ferrule Production - Post Command"
                    ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MessageBox.Show("There was an error trying to post, contact system admin", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
            Try
                cmd = New SqlCommand("UPDATE FerruleProductionHeaderTable SET Status = 'CLOSED', PostedBy = @PostedBy, PostDate = @PostDate WHERE FerruleTransactionKey = @FerruleTransactionKey AND DivisionID = @DivisionID;", con)
                ''Updates all Batch Mix lines to show the quantity produced as the line weight
                cmd.CommandText += "  UPDATE FerruleProductionLines SET ProductionQuantity = LineWeight WHERE PartNumber = 'BATCH MIX' AND FerruleProductionKey = @FerruleTransactionKey and ProductionQuantity > 0"
                With cmd.Parameters
                    .Add("@FerruleTransactionKey", SqlDbType.VarChar).Value = Val(cboFerruleProductionKey.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PostedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@PostDate", SqlDbType.VarChar).Value = Now()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempFerruleProductionNumber As Integer = 0
                Dim strTempFerruleProductionNumber As String
                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Ferrule Production - Post Command"
                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            isLoaded = False
            ClearAll()
            LoadFerruleTransactionKeys()
            isLoaded = True
            MessageBox.Show("Production has been posted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(cboFerruleProductionKey.Text) Then
            MessageBox.Show("You muse select a batch to post", "Select a batch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFerruleProductionKey.Focus()
            Return False
        End If

        LoadStatus()

        If Not lblStatus.Text.Equals("OPEN") Then
            MessageBox.Show("You cant post a status that isn't OPEN", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If dgvFerruleProductionGrid.Rows.Count = 0 Then
            MessageBox.Show("You must enter lines to post", "Enter lines", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        'If EmployeeSecurityCode > 1002 Then
        '    If DateDiff(DateInterval.Month, Now, dtpProductionDate.Value) > 1 Then
        '        MessageBox.Show("You can't post a future date", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return False
        '    ElseIf DateDiff(DateInterval.Month, Now, dtpProductionDate.Value) < 0 Then
        '        If Now.Month.Equals(5) Then
        '            MessageBox.Show("You can't post into a prior fiscal year", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Return False
        '        End If
        '    Else
        '        If DateDiff(DateInterval.Day, Now, dtpProductionDate.Value) < -5 Then
        '            MessageBox.Show("You can't post more than 5 days prior", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Return False
        '        End If
        '    End If
        'End If
        Return True
    End Function

    Private Sub AddBatchMixEntries(ByRef row As DataGridViewRow, ByRef GLCommand As SqlCommand, ByRef GLLineCount As Integer, ByRef firstGLLine As Boolean, _
                                   ByRef InventoryTransCommand As SqlCommand, ByRef InventoryTransNumber As Integer, ByRef firstTrans As Boolean, _
                                   ByRef InventoryCostingCommand As SqlCommand, ByRef InventoryCostingCount As Integer, ByRef InventoryCostingInserts As String, _
                                   ByRef firstCosting As Boolean, ByRef FerruleProductionLinesCommand As SqlCommand, ByRef FerruleLineCount As Integer, _
                                   ByRef firstFerrLine As Boolean, ByRef NextFerruleProductionLineNumber As Integer, ByRef UpdateCommand As SqlCommand, _
                                   ByRef firstUpdate As Boolean, ByRef UpdateCount As Integer)

        Dim FerruleLineKey As Integer = row.Cells("FerruleLineKeyColumn").Value
        Dim LineWeight As Double = Math.Round(row.Cells("LineWeightColumn").Value, 5, MidpointRounding.AwayFromZero)
        Dim ProductionQty As Double = row.Cells("ProductionQuantityColumn").Value
        Dim LinePartNumber As String = row.Cells("PartNumberColumn").Value
        Dim LineExtendedCost As Double = 0

        Dim BatchCsts As BatchCosts = GetBatchCost()
        '*************************************************************************************************************************
        'FC Kaolin
        Dim MaterialWeight As Double = Math.Round((-1 * ProductionQty * 150), 0, MidpointRounding.AwayFromZero)
        Dim MaterialExtendedCost As Double = Math.Round(Abs(MaterialWeight) * BatchCsts.FCKaolinCost, 2, MidpointRounding.AwayFromZero)
        ''Adds to the extended cost of the batch mix
        LineExtendedCost += MaterialExtendedCost
        ''ADD Line Entry for FC KAOLIN removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "FC KAOLIN", "FC KAOLIN", MaterialWeight, _
                      BatchCsts.FCKaolinCost, (-1 * MaterialExtendedCost), Abs(MaterialWeight), NextFerruleProductionLineNumber)
        ''Adds inventory transaction for FC KAOLIN removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "FC KAOLIN", "FC KAOLIN", Abs(MaterialWeight), BatchCsts.FCKaolinCost, _
                                MaterialExtendedCost, "SUBTRACT", "12000")
        NextFerruleProductionLineNumber += 1

        '******************************************************************************************************************************************
        'M23 Clay
        MaterialWeight = Math.Round((-1 * ProductionQty * 175), 0, MidpointRounding.AwayFromZero)
        MaterialExtendedCost = Math.Round(BatchCsts.M23ClayCost * Abs(MaterialWeight), 2, MidpointRounding.AwayFromZero)
        ''Adds to the extended cost of the batch mix
        LineExtendedCost += MaterialExtendedCost
        ''ADD Line Entry for M-23 Clay removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "M-23CLAY", "M-23 Clay", MaterialWeight, _
                      BatchCsts.M23ClayCost, (-1 * MaterialExtendedCost), Abs(MaterialWeight), NextFerruleProductionLineNumber)
        ''Adds inventory transaction for M-23 Clay removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "M-23CLAY", "M-23 Clay", Abs(MaterialWeight), BatchCsts.M23ClayCost, _
                                MaterialExtendedCost, "SUBTRACT", "12000")
        NextFerruleProductionLineNumber += 1

        '******************************************************************************************************************************************
        'TALC
        MaterialWeight = Math.Round((-1 * ProductionQty * 200), 0, MidpointRounding.AwayFromZero)
        MaterialExtendedCost = Math.Round(BatchCsts.SilverlineCost * Abs(MaterialWeight), 2, MidpointRounding.AwayFromZero)
        ''Adds to the extended cost of the batch mix
        LineExtendedCost += MaterialExtendedCost
        ''ADD Line Entry for SILVERLINE 001 TALC removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "SILVERLINE 001 TALC", "SILVERLINE 001 TALC", MaterialWeight, _
                      BatchCsts.SilverlineCost, (-1 * MaterialExtendedCost), Abs(MaterialWeight), NextFerruleProductionLineNumber)
        ''Adds inventory transaction for SILVERLINE 001 TALC removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "SILVERLINE 001 TALC", "SILVERLINE 001 TALC", Abs(MaterialWeight), BatchCsts.SilverlineCost, _
                                MaterialExtendedCost, "SUBTRACT", "12000")
        NextFerruleProductionLineNumber += 1

        '******************************************************************************************************************************************
        'MULLITE
        MaterialWeight = Math.Round((-1 * ProductionQty * 75), 0, MidpointRounding.AwayFromZero)
        MaterialExtendedCost = Math.Round(Abs(MaterialWeight) * BatchCsts.MulliteCost, 2, MidpointRounding.AwayFromZero)
        ''Adds to the extended cost of the batch mix
        LineExtendedCost += MaterialExtendedCost
        ''ADD Line Entry for Mullite removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "MULLITE", "200 Mess Mullite 50 lb bags", MaterialWeight, _
                      BatchCsts.MulliteCost, (-1 * MaterialExtendedCost), Abs(MaterialWeight), NextFerruleProductionLineNumber)
        ''Adds inventory transaction for Mullite removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "MULLITE", "200 Mess Mullite 50 lb bags", Abs(MaterialWeight), BatchCsts.MulliteCost, _
                                MaterialExtendedCost, "SUBTRACT", "12000")
        NextFerruleProductionLineNumber += 1

        '******************************************************************************************************************************************
        'FELDSPAR
        MaterialWeight = Math.Round((-1 * ProductionQty * 25), 0, MidpointRounding.AwayFromZero)
        MaterialExtendedCost = Math.Round(BatchCsts.FeldsparCost * Abs(MaterialWeight), 2, MidpointRounding.AwayFromZero)
        ''Adds to the extended cost of the batch mix
        LineExtendedCost += MaterialExtendedCost
        ''ADD Line Entry for Feldspar removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "FELDSPAR", "FELDSPAR", MaterialWeight, _
                      BatchCsts.FeldsparCost, (-1 * MaterialExtendedCost), Abs(MaterialWeight), NextFerruleProductionLineNumber)
        ''Adds inventory transaction for Feldspar removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "FELDSPAR", "FELDSPAR", Abs(MaterialWeight), BatchCsts.FeldsparCost, _
                                MaterialExtendedCost, "SUBTRACT", "12000")
        NextFerruleProductionLineNumber += 1

        '******************************************************************************************************************************************
        'GOULAC
        MaterialWeight = Math.Round((-1 * ProductionQty * 20), 0, MidpointRounding.AwayFromZero)
        MaterialExtendedCost = Math.Round(BatchCsts.GoulacCost * Abs(MaterialWeight), 2, MidpointRounding.AwayFromZero)
        ''Adds to the extended cost of the batch mix
        LineExtendedCost += MaterialExtendedCost
        ''ADD Line Entry for Goulac removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "GOULAC", "Goulac 50lb bags", MaterialWeight, _
                      BatchCsts.GoulacCost, (-1 * MaterialExtendedCost), Abs(MaterialWeight), NextFerruleProductionLineNumber)
        ''Adds inventory transaction for Goulac removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "GOULAC", "Goulac 50lb bags", Abs(MaterialWeight), BatchCsts.GoulacCost, _
                                MaterialExtendedCost, "SUBTRACT", "12000")
        NextFerruleProductionLineNumber += 1

        ''Adds inventory transaction for BATCH
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "Batch Mix", "BATCH MIX FOR FERRULES", LineWeight, BatchCsts.CostPerPound, _
                                LineExtendedCost, "ADD", "12800")
        ''Adds new cost tier for produced BATCH material
        AddInventoryCosting(InventoryCostingCommand, firstCosting, InventoryCostingCount, InventoryCostingInserts, LinePartNumber, BatchCsts.CostPerPound, _
                            LineWeight, Val(cboFerruleProductionKey.Text), FerruleLineKey)
        '*************************************************************************************************************************
        ''DEBIT FOR BATCH MIX RAW MATERIALS
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", LineExtendedCost, 0, "Add Raw Materials Into WIP", _
                   Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
        ''CREDIT FOR BATCH MIX RAW MATERIALS
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12000", "Production Entry - WC", 0, LineExtendedCost, "Subtract Raw Materials", _
                   Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
        ''Updates the line entry for batch mix
        Dim LaborLineExtendedCost As Double = Math.Round((LaborRate + OverheadRate) * LineWeight, 2, MidpointRounding.AwayFromZero)
        LineExtendedCost += LaborLineExtendedCost

        If Not row.Cells("ExtendedCostColumn").Value.Equals(LineExtendedCost) Then
            AddUpdateLineEntry(UpdateCommand, UpdateCount, firstUpdate, FerruleLineKey, Math.Round(LineExtendedCost / LineWeight, 5, MidpointRounding.AwayFromZero), LineExtendedCost)
        End If
        ''DEBIT FOR BATCH MIX LABOR
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", LaborLineExtendedCost, 0, "Add Labor/OH Into WIP", _
                   Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
        ''CREDIT FOR BATCH MIX LABOR
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "60099", "Production Entry - WC", 0, LaborLineExtendedCost, "Add Labor/OH to Labor Absorbed", _
                   Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
        '*************************************************************************************************************************
    End Sub

    Private Sub AddWeldTiles(ByRef row As DataGridViewRow, ByRef GLCommand As SqlCommand, ByRef GLLineCount As Integer, ByRef firstGLLine As Boolean, _
                             ByRef InventoryTransCommand As SqlCommand, ByRef InventoryTransNumber As Integer, ByRef firstTrans As Boolean, _
                             ByRef InventoryCostingCommand As SqlCommand, ByRef InventoryCostingCount As Integer, ByRef InventoryCostingInserts As String, _
                             ByRef firstCosting As Boolean, ByRef FerruleProductionLinesCommand As SqlCommand, ByRef FerruleLineCount As Integer, _
                             ByRef firstFerrLine As Boolean, ByRef NextFerruleProductionLineNumber As Integer, ByRef UpdateCommand As SqlCommand, _
                             ByRef firstUpdate As Boolean, ByRef UpdateCount As Integer)

        Dim LinePartNumber As String = row.Cells("PartNumberColumn").Value

        Dim batchCsts As BatchCosts = GetBatchCost()
        '***********************************************************************************************************************
        'Selecting TapeType, TapeSize, TapeDescription
        Dim FindTapeTypeCommand As New SqlCommand("SELECT PurchProdLineID, SalesProdLineID, ShortDescription FROM ItemList Where ItemID = @ItemID AND DivisionID = @DivisionID", con)
        FindTapeTypeCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
        FindTapeTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TapeType, TapeSize, TapeDescription As String
        Dim TapeCost As Double

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = FindTapeTypeCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PurchProdLineID")) Then
                TapeType = ""
            Else
                TapeType = reader.Item("PurchProdLineID")
            End If
            If IsDBNull(reader.Item("SalesProdLineID")) Then
                TapeSize = ""
            Else
                TapeSize = reader.Item("SalesProdLineID")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                TapeDescription = ""
            Else
                TapeDescription = reader.Item("ShortDescription")
            End If
        Else
            TapeType = ""
            TapeSize = ""
            TapeDescription = ""
        End If
        reader.Close()


        If TapeType.StartsWith("TAPE3") Then
            If TapeSize.Equals("TAPE-1FT") Or TapeSize.Equals("TAPE-2FT") Then
                AddTapeEntries(row, GLCommand, GLLineCount, firstGLLine, InventoryTransCommand, InventoryTransNumber, firstTrans, _
                               InventoryCostingCommand, InventoryCostingCount, InventoryCostingInserts, firstCosting, FerruleProductionLinesCommand, _
                               FerruleLineCount, firstFerrLine, NextFerruleProductionLineNumber, TapeType, TapeCost, TapeSize, TapeDescription, batchCsts, _
                               UpdateCommand, firstUpdate, UpdateCount)
            Else
                AddMiscTileEntry(row, GLCommand, GLLineCount, firstGLLine, InventoryTransCommand, InventoryTransNumber, firstTrans, _
                               InventoryCostingCommand, InventoryCostingCount, InventoryCostingInserts, firstCosting, FerruleProductionLinesCommand, _
                               FerruleLineCount, firstFerrLine, NextFerruleProductionLineNumber, batchCsts, UpdateCommand, firstUpdate, UpdateCount)
            End If
        Else
            ''check to see if tape type needs changed
            If TapeType.Equals("ORING-1FOOT") Then
                TapeType = "O-RING"
            End If
            If TapeType.Equals("O-RING") Then
                AddORingEntry(row, GLCommand, GLLineCount, firstGLLine, InventoryTransCommand, InventoryTransNumber, firstTrans, _
                               InventoryCostingCommand, InventoryCostingCount, InventoryCostingInserts, firstCosting, FerruleProductionLinesCommand, _
                               FerruleLineCount, firstFerrLine, NextFerruleProductionLineNumber, TapeType, TapeCost, TapeSize, TapeDescription, batchCsts, _
                               UpdateCommand, firstUpdate, UpdateCount)
            Else
                AddMiscTileEntry(row, GLCommand, GLLineCount, firstGLLine, InventoryTransCommand, InventoryTransNumber, firstTrans, _
                               InventoryCostingCommand, InventoryCostingCount, InventoryCostingInserts, firstCosting, FerruleProductionLinesCommand, _
                               FerruleLineCount, firstFerrLine, NextFerruleProductionLineNumber, batchCsts, UpdateCommand, firstUpdate, UpdateCount)
            End If
        End If
    End Sub

    Private Function GetFIFOCost(ByVal PartNumber As String, ByVal CostingQuantity As Double) As Double
        Dim ItemCost As Double = 0D
        Dim QuantityRemaining As Double = 0D
        Dim cmd As New SqlCommand("DECLARE @QuantityUsed as float = (SELECT isnull(SUM(Quantity), 1) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND TransactionDate <= @CurrentDate AND DivisionID = @DivisionID AND TransactionMath = 'SUBTRACT');", con)
        cmd.CommandText += " DECLARE @MaxTransactionNumber as int = (SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CurrentDate AND @QuantityUsed BETWEEN LowerLimit AND UpperLimit);"
        cmd.CommandText += " SELECT UpperLimit, ItemCost, @MaxTransactionNumber as MaxTransacitonNumber, @QuantityUsed as QuantityUsed FROM InventoryCosting WHERE TransactionNumber = @MaxTransactionNumber AND DivisionID = @DivisionID AND @QuantityUsed BETWEEN LowerLimit AND UpperLimit"

        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
        cmd.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = dtpProductionDate.Value

        Dim UpperLimit As Double = 0
        Dim LowerLimit As Double = 0
        Dim QuantityUsed As Double = 0
        Dim TotalCost As Double = 0
        Dim MaxTransactionNumber As Integer = 0
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("UpperLimit")) Then
                UpperLimit = reader.Item("UpperLimit")
            End If
            If Not IsDBNull(reader.Item("ItemCost")) Then
                ItemCost = reader.Item("ItemCost")
            End If
            If Not IsDBNull(reader.Item("MaxTransacitonNumber")) Then
                MaxTransactionNumber = reader.Item("MaxTransacitonNumber")
            End If
            If Not IsDBNull(reader.Item("QuantityUsed")) Then
                QuantityUsed = reader.Item("QuantityUsed")
            End If
        End If
        reader.Close()

        ''check to make sure it hit a cost tier, if it didnt will get last purchase price for the remaining and return
        If UpperLimit = 0 Or MaxTransactionNumber = 0 Then
            Return Math.Round(GetLastReceivedPrice(PartNumber), 5, MidpointRounding.AwayFromZero)
        End If

        Dim FIFOExtendedAmount As Double = 0D
        ''Check to see if we cross a cost tier
        If (QuantityUsed + CostingQuantity) > UpperLimit Then
            'Quantity crosses a cost tier
            QuantityRemaining = (QuantityUsed + CostingQuantity) - UpperLimit

            FIFOExtendedAmount = (UpperLimit - QuantityUsed) * ItemCost

            cmd.Parameters.Add("@QuantityUsed", SqlDbType.Float)

            While QuantityRemaining > 0
                Dim TempQuantity As Double = 0
                Dim NextUpperLimit As Integer = 0
                Dim NextLowerLimit As Integer = 0
                MaxTransactionNumber = 0
                ItemCost = 0
                cmd.CommandText = "SELECT TransactionNumber, ItemCost, UpperLimit, LowerLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @QuantityUsed BETWEEN LowerLimit AND UpperLimit ORDER BY TransactionNumber DESC"
                cmd.Parameters("@QuantityUsed").Value = UpperLimit + 1

                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If Not IsDBNull(reader.Item("TransactionNumber")) Then
                        MaxTransactionNumber = reader.Item("TransactionNumber")
                    End If
                    If Not IsDBNull(reader.Item("ItemCost")) Then
                        ItemCost = reader.Item("ItemCost")
                    End If
                    If Not IsDBNull(reader.Item("UpperLimit")) Then
                        UpperLimit = reader.Item("UpperLimit")
                    End If
                    If Not IsDBNull(reader.Item("LowerLimit")) Then
                        LowerLimit = reader.Item("LowerLimit")
                    End If
                End If
                reader.Close()

                TempQuantity = (NextUpperLimit + 1) - NextLowerLimit

                If QuantityRemaining > TempQuantity Then
                    'Add to existing FIFO Extended Amount
                    FIFOExtendedAmount += (TempQuantity * ItemCost)

                    'Redefine Quantity Remaining after the next cost tier
                    QuantityRemaining -= TempQuantity
                    UpperLimit = NextUpperLimit
                Else
                    FIFOExtendedAmount += (QuantityRemaining * ItemCost)
                    QuantityRemaining = 0
                End If
            End While

        Else
            'Entire quantity falls into one cost tier
            FIFOExtendedAmount = ItemCost * CostingQuantity
        End If

        If ItemCost = 0 Then
            Return Math.Round(GetLastReceivedPrice(PartNumber), 5, MidpointRounding.AwayFromZero)
        End If
        
        Return Math.Round(FIFOExtendedAmount / CostingQuantity, 5, MidpointRounding.AwayFromZero)
    End Function

    Private Function GetLastReceivedPrice(ByVal PartNumber As String) As Double
        Dim UnitPrice As Double = 0D
        ''Looks for Last received price then last transaction price then standard price
        Dim cmd As New SqlCommand("IF EXISTS(SELECT TOP 1 UnitCost as ItemCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND DivisionID = @DivisionID ORDER BY ReceivingHeaderKey DESC)", con)
        cmd.CommandText += " SELECT TOP 1 UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND DivisionID = @DivisionID ORDER BY ReceivingHeaderKey DESC"
        cmd.CommandText += " ELSE IF EXISTS(SELECT TOP 1 ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY TransactionNumber DESC)"
        cmd.CommandText += " SELECT TOP 1 ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY TransactionNumber DESC"
        cmd.CommandText += " ELSE SELECT StandardCost as ItemCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @PartNumber"

        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = dtpProductionDate.Value

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnitPrice = CDbl(cmd.ExecuteScalar)
        Catch ex As Exception
            UnitPrice = 0
        End Try
        con.Close()
        Return UnitPrice
    End Function

    Private Sub AddTapeEntries(ByRef row As DataGridViewRow, ByRef GLCommand As SqlCommand, ByRef GLLineCount As Integer, ByRef firstGLLine As Boolean, _
                               ByRef InventoryTransCommand As SqlCommand, ByRef InventoryTransNumber As Integer, ByRef firstTrans As Boolean, _
                               ByRef InventoryCostingCommand As SqlCommand, ByRef InventoryCostingCount As Integer, ByRef InventoryCostingInserts As String, _
                               ByRef firstCosting As Boolean, ByRef FerruleProductionLinesCommand As SqlCommand, ByRef FerruleLineCount As Integer, _
                               ByRef firstFerrLine As Boolean, ByRef NextFerruleProductionLineNumber As Integer, ByRef TapeType As String, ByRef TapeCost As Double, _
                               ByRef TapeSize As String, ByRef TapeDescription As String, ByRef batchCsts As BatchCosts, ByRef UpdateCommand As SqlCommand, _
                               ByRef firstUpdate As Boolean, ByRef UpdateCount As Integer)

        Dim LinePartNumber As String = row.Cells("PartNumberColumn").Value
        Dim LineQuantity As Double = row.Cells("ProductionQuantityColumn").Value
        Dim FerruleLineKey As Integer = row.Cells("FerruleLineKeyColumn").Value
        Dim LineWeight As Double = Math.Round(row.Cells("LineWeightColumn").Value, 0, MidpointRounding.AwayFromZero)
        Dim LinePartDescription As String = row.Cells("PartDescriptionColumn").Value

        Try
            TapeCost = GetFIFOCost(TapeType, LineQuantity)
        Catch ex As Exception
            'Log error on update failure
            Dim TempFerruleProductionNumber As Integer = 0
            Dim strTempFerruleProductionNumber As String
            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Ferrule Production - Add Tape Entry"
            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
            MessageBox.Show("There was an error costing the tape. Contact system admin.", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        TapeCost = Math.Round(TapeCost, 5, MidpointRounding.AwayFromZero)
        Dim TapeLineQuantity As Double = LineQuantity
        If TapeSize.Equals("TAPE-2FT") Then
            TapeLineQuantity = TapeLineQuantity * 2
        End If
        Dim ExtendedTapeLineCost As Double = Math.Round((TapeCost * TapeLineQuantity), 2, MidpointRounding.AwayFromZero)
        ''ADD Line Entry for Tape removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, TapeType, TapeDescription, (-1 * TapeLineQuantity), _
                      TapeCost, (-1 * ExtendedTapeLineCost), 0, NextFerruleProductionLineNumber)
        ''Adds inventory transaction for tape removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                FerruleLineKey, TapeType, TapeDescription, TapeLineQuantity, TapeCost, _
                                ExtendedTapeLineCost, "SUBTRACT", "12000")

        ''DEBIT FOR Tape to WIP
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", ExtendedTapeLineCost, 0, _
                   "Ferrule Production", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), NextFerruleProductionLineNumber)
        ''CREDIT FOR WIP FOR WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12000", "Production Entry - WC", 0, ExtendedTapeLineCost, _
                   "Remove quantity from WIP", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), NextFerruleProductionLineNumber)

        NextFerruleProductionLineNumber += 1

        Dim ExtendedBatchCostPerPound As Double = Math.Round(LineWeight * batchCsts.CostPerPound, 2, MidpointRounding.AwayFromZero)
        ''ADD Line Entry for Batch Mix removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "Batch Mix", "BATCH MIX FOR FERRULES", (-1 * LineWeight), _
                       batchCsts.CostPerPound, (-1 * ExtendedBatchCostPerPound), LineWeight, NextFerruleProductionLineNumber)
        ''ADD Transaction Entry for Batch MIX removed
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "Batch Mix", "BATCH MIX FOR FERRULES", LineWeight, batchCsts.CostPerPound, _
                                ExtendedBatchCostPerPound, "SUBTRACT", "12800")
        ''Advances the line counter for the current production
        NextFerruleProductionLineNumber += 1

        ''Sets the actual line extended cost
        Dim LineExtendedCost As Double = Math.Round(ExtendedTapeLineCost + ExtendedBatchCostPerPound, 2, MidpointRounding.AwayFromZero)
        Dim LineUnitCost As Double = Math.Round(LineExtendedCost / LineQuantity, 5, MidpointRounding.AwayFromZero)
        '***********************************************************************************************************************
        'updates unit and extended cost
        AddUpdateLineEntry(UpdateCommand, UpdateCount, firstUpdate, FerruleLineKey, LineUnitCost, LineExtendedCost)
        
        ''Adds inventory transaction for line item
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                FerruleLineKey, LinePartNumber, LinePartDescription, LineQuantity, LineUnitCost, _
                                LineExtendedCost, "ADD", "12950")
        ''Adds new cost tier for produced material
        AddInventoryCosting(InventoryCostingCommand, firstCosting, InventoryCostingCount, InventoryCostingInserts, LinePartNumber, LineUnitCost, _
                            LineQuantity, Val(cboFerruleProductionKey.Text), FerruleLineKey)

        ''DEBIT FOR PRODUCED WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12950", "Production Entry - WC", LineExtendedCost, 0, _
                   "Ferrule Production", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
        ''CREDIT FOR WIP FOR WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", 0, LineExtendedCost, _
                   "Remove quantity from WIP", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
    End Sub

    Private Sub AddMiscTileEntry(ByRef row As DataGridViewRow, ByRef GLCommand As SqlCommand, ByRef GLLineCount As Integer, ByRef firstGLLine As Boolean, _
                             ByRef InventoryTransCommand As SqlCommand, ByRef InventoryTransNumber As Integer, ByRef firstTrans As Boolean, ByRef InventoryCostingCommand As SqlCommand, _
                             ByRef InventoryCostingCount As Integer, ByRef InventoryCostingInserts As String, ByRef firstCosting As Boolean, _
                             ByRef FerruleProductionLinesCommand As SqlCommand, ByRef FerruleLineCount As Integer, ByRef firstFerrLine As Boolean, _
                             ByRef NextFerruleProductionLineNumber As Integer, ByRef batchCsts As BatchCosts, ByRef UpdateCommand As SqlCommand, _
                             ByRef firstUpdate As Boolean, ByRef UpdateCount As Integer)

        Dim LinePartNumber As String = row.Cells("PartNumberColumn").Value
        Dim LineQuantity As Double = row.Cells("ProductionQuantityColumn").Value
        Dim FerruleLineKey As Integer = row.Cells("FerruleLineKeyColumn").Value
        Dim LineWeight As Double = Math.Round(row.Cells("LineWeightColumn").Value, 0, MidpointRounding.AwayFromZero)
        Dim LinePartDescription As String = row.Cells("PartDescriptionColumn").Value

        Dim ExtendedBatchCostPerPound As Double = Math.Round(LineWeight * batchCsts.CostPerPound, 2)
        ''ADD Line Entry for Batch Mix removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "Batch Mix", "BATCH MIX FOR FERRULES", (-1 * LineWeight), _
                       batchCsts.CostPerPoundRM, (-1 * ExtendedBatchCostPerPound), LineWeight, NextFerruleProductionLineNumber)
        ''ADD Transaction Entry for Batch MIX removed
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "Batch Mix", "BATCH MIX FOR FERRULES", LineWeight, batchCsts.CostPerPoundRM, _
                                Math.Round(LineWeight * batchCsts.CostPerPoundRM, 2), "SUBTRACT", "12800")

        NextFerruleProductionLineNumber += 1

        AddUpdateLineEntry(UpdateCommand, UpdateCount, firstUpdate, FerruleLineKey, batchCsts.CostPerPoundRM, ExtendedBatchCostPerPound)

        ''Adds inventory transaction for line item
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                FerruleLineKey, LinePartNumber, LinePartDescription, LineQuantity, batchCsts.CostPerPoundRM, ExtendedBatchCostPerPound, "ADD", "12950")
        ''Adds new cost tier for produced material
        AddInventoryCosting(InventoryCostingCommand, firstCosting, InventoryCostingCount, InventoryCostingInserts, LinePartNumber, batchCsts.CostPerPoundRM, LineQuantity, _
                            Val(cboFerruleProductionKey.Text), FerruleLineKey)

        ''DEBIT FOR PRODUCED WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12950", "Production Entry - WC", ExtendedBatchCostPerPound, 0, "Ferrule Production", Val(cboFerruleProductionKey.Text), _
                   Val(cboFerruleProductionKey.Text), FerruleLineKey)
        ''CREDIT FOR WIP FOR WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", 0, ExtendedBatchCostPerPound, "Remove quantity from WIP", Val(cboFerruleProductionKey.Text), _
                   Val(cboFerruleProductionKey.Text), FerruleLineKey)

    End Sub

    Private Sub AddORingEntry(ByRef row As DataGridViewRow, ByRef GLCommand As SqlCommand, ByRef GLLineCount As Integer, ByRef firstGLLine As Boolean, _
                               ByRef InventoryTransCommand As SqlCommand, ByRef InventoryTransNumber As Integer, ByRef firstTrans As Boolean, _
                               ByRef InventoryCostingCommand As SqlCommand, ByRef InventoryCostingCount As Integer, ByRef InventoryCostingInserts As String, _
                               ByRef firstCosting As Boolean, ByRef FerruleProductionLinesCommand As SqlCommand, ByRef FerruleLineCount As Integer, _
                               ByRef firstFerrLine As Boolean, ByRef NextFerruleProductionLineNumber As Integer, ByRef TapeType As String, ByRef TapeCost As Double, _
                               ByRef TapeSize As String, ByRef TapeDescription As String, ByRef batchCsts As BatchCosts, ByRef UpdateCommand As SqlCommand, _
                               ByRef firstUpdate As Boolean, ByRef UpdateCount As Integer)

        Dim LinePartNumber As String = row.Cells("PartNumberColumn").Value
        Dim LineQuantity As Double = row.Cells("ProductionQuantityColumn").Value
        Dim FerruleLineKey As Integer = row.Cells("FerruleLineKeyColumn").Value
        Dim LineWeight As Double = Math.Round(row.Cells("LineWeightColumn").Value, 0, MidpointRounding.AwayFromZero)
        Dim LinePartDescription As String = row.Cells("PartDescriptionColumn").Value

        Try
            TapeCost = GetFIFOCost(TapeType, LineQuantity)
        Catch ex As Exception
            'Log error on update failure
            Dim TempFerruleProductionNumber As Integer = 0
            Dim strTempFerruleProductionNumber As String
            TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
            strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Ferrule Production - Add Misc Tile Entry"
            ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            MessageBox.Show("There was an error costing the tape. Contact system admin.", "Unable to complete posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        TapeCost = Math.Round(TapeCost, 5, MidpointRounding.AwayFromZero)
        Dim TapeExtendedCost As Double = Math.Round(TapeCost * LineQuantity, 2, MidpointRounding.AwayFromZero)
        '***********************************************************************************************************************
        ''ADD Line Entry for Tape removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, TapeType, TapeDescription, (-1 * LineQuantity), _
                      TapeCost, (-1 * TapeExtendedCost), 0, NextFerruleProductionLineNumber)
        ''Adds inventory transaction for tape removal
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                FerruleLineKey, TapeType, TapeDescription, LineQuantity, TapeCost, _
                                TapeExtendedCost, "SUBTRACT", "12000")
        ''DEBIT FOR Tape removed
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", TapeExtendedCost, 0, _
                   "Ferrule Production", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), NextFerruleProductionLineNumber)
        ''CREDIT FOR WIP FOR WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12000", "Production Entry - WC", 0, TapeExtendedCost, _
                   "Remove quantity from WIP", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), NextFerruleProductionLineNumber)
        NextFerruleProductionLineNumber += 1
        '******************************************************************************************************************************************

        'Enter Negative Production to remove Raw Materials
        Dim BatchExtendedCost As Double = Math.Round(LineWeight * batchCsts.CostPerPound, 2, MidpointRounding.AwayFromZero)

        ''ADD Line Entry for Batch Mix removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "Batch Mix", "BATCH MIX FOR FERRULES", (-1 * LineWeight), _
                       batchCsts.CostPerPoundRM, (-1 * BatchExtendedCost), LineWeight, NextFerruleProductionLineNumber)
        ''ADD Transaction Entry for Batch MIX removed
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "Batch Mix", "BATCH MIX FOR FERRULES", LineWeight, batchCsts.CostPerPoundRM, _
                                Math.Round(LineWeight * batchCsts.CostPerPoundRM, 2), "SUBTRACT", "12800")
        NextFerruleProductionLineNumber += 1

        '***********************************************************************************************************************
        Dim LineExtendedCost As Double = TapeExtendedCost + BatchExtendedCost
        Dim LineUnitCost As Double = Math.Round(LineExtendedCost / LineQuantity, 5, MidpointRounding.AwayFromZero)
        'Updates Line Cost for the Tile
        AddUpdateLineEntry(UpdateCommand, UpdateCount, firstUpdate, FerruleLineKey, LineUnitCost, LineExtendedCost)

        ''Adds inventory transaction for line item
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                FerruleLineKey, LinePartNumber, LinePartDescription, LineQuantity, LineUnitCost, _
                                LineExtendedCost, "ADD", "12950")
        ''Adds new cost tier for produced material
        AddInventoryCosting(InventoryCostingCommand, firstCosting, InventoryCostingCount, InventoryCostingInserts, LinePartNumber, LineUnitCost, _
                            LineQuantity, Val(cboFerruleProductionKey.Text), FerruleLineKey)

        '******************************************************************************************************************************************
        ''DEBIT FOR PRODUCED ORING
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12950", "Production Entry - WC", LineExtendedCost, 0, _
                   "Ferrule Production", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
        ''CREDIT FOR WIP FOR ORING
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", 0, LineExtendedCost, _
                   "Remove quantity from WIP", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
    End Sub

    Private Sub AddFerruleEntry(ByRef row As DataGridViewRow, ByRef GLCommand As SqlCommand, ByRef GLLineCount As Integer, ByRef firstGLLine As Boolean, _
                               ByRef InventoryTransCommand As SqlCommand, ByRef InventoryTransNumber As Integer, ByRef firstTrans As Boolean, _
                               ByRef InventoryCostingCommand As SqlCommand, ByRef InventoryCostingCount As Integer, ByRef InventoryCostingInserts As String, _
                               ByRef firstCosting As Boolean, ByRef FerruleProductionLinesCommand As SqlCommand, ByRef FerruleLineCount As Integer, _
                               ByRef firstFerrLine As Boolean, ByRef NextFerruleProductionLineNumber As Integer, ByRef UpdateCommand As SqlCommand, _
                               ByRef firstUpdate As Boolean, ByRef UpdateCount As Integer)

        Dim LinePartNumber As String = row.Cells("PartNumberColumn").Value
        Dim LineQuantity As Double = row.Cells("ProductionQuantityColumn").Value
        Dim LineExtendedCost As Double = Math.Round(row.Cells("ExtendedCostColumn").Value, 2, MidpointRounding.AwayFromZero)
        Dim FerruleLineKey As Integer = row.Cells("FerruleLineKeyColumn").Value
        Dim LineWeight As Double = Math.Round(row.Cells("LineWeightColumn").Value, 0, MidpointRounding.AwayFromZero)
        Dim LinePartDescription As String = row.Cells("PartDescriptionColumn").Value
        Dim batchCsts As BatchCosts = GetBatchCost()
        '******************************************************************************************************************************************
        'Enter Negative Production to remove Raw Materials

        Dim BatchLineExtendedCost As Double = Math.Round(LineWeight * batchCsts.CostPerPound, 2, MidpointRounding.AwayFromZero)

        ''ADD Line Entry for Batch Mix removal
        AddFerruleLine(FerruleProductionLinesCommand, firstFerrLine, FerruleLineCount, "Batch Mix", "BATCH MIX FOR FERRULES", (-1 * LineWeight), _
                       batchCsts.CostPerPound, (-1 * BatchLineExtendedCost), LineWeight, NextFerruleProductionLineNumber)
        ''ADD Transaction Entry for Batch MIX removed
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                NextFerruleProductionLineNumber, "Batch Mix", "BATCH MIX FOR FERRULES", LineWeight, batchCsts.CostPerPound, _
                                BatchLineExtendedCost, "SUBTRACT", "12800")

        NextFerruleProductionLineNumber += 1

        LineExtendedCost = BatchLineExtendedCost
        Dim LineUnitCost As Double = Math.Round(LineExtendedCost / LineQuantity, 5, MidpointRounding.AwayFromZero)
        ''updates unit cost extended cost and standard cost
        AddUpdateLineEntry(UpdateCommand, UpdateCount, firstUpdate, FerruleLineKey, LineUnitCost, LineExtendedCost)
        '******************************************************************************************************************************************
        'Write Data to the Inventory Transaction Table --- Ferrules/Tiles
        ''Adds inventory transaction for line item
        AddInventoryTransaction(InventoryTransCommand, firstTrans, InventoryTransNumber, Val(cboFerruleProductionKey.Text), _
                                FerruleLineKey, LinePartNumber, LinePartDescription, LineQuantity, LineUnitCost, LineExtendedCost, "ADD", "12110")
        ''Adds new cost tier for produced material
        AddInventoryCosting(InventoryCostingCommand, firstCosting, InventoryCostingCount, InventoryCostingInserts, LinePartNumber, LineUnitCost, LineQuantity, _
                            Val(cboFerruleProductionKey.Text), FerruleLineKey)

        ''DEBIT FOR PRODUCED WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12110", "Production Entry - WC", LineExtendedCost, 0, _
                   "Ferrule Production", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)
        ''CREDIT FOR WIP FOR WC Weld Tile
        AddGLEntry(GLCommand, firstGLLine, GLLineCount, "12800", "Production Entry - WC", 0, LineExtendedCost, _
                   "Remove quantity from WIP", Val(cboFerruleProductionKey.Text), Val(cboFerruleProductionKey.Text), FerruleLineKey)

    End Sub

    Private Sub AddGLEntry(ByRef GLCommand As SqlCommand, ByRef firstGLLine As Boolean, ByRef GLLineCount As Integer, ByVal AccountNumber As String, _
                           ByVal Description As String, ByVal DebitAmount As Double, ByVal CreditAmount As Double, ByVal Comment As String, ByVal BatchNumber As Integer, _
                           ByVal ReferenceNumber As Integer, ByVal ReferenceLine As Integer)
        If firstGLLine Then
            firstGLLine = False
        Else
            GLCommand.CommandText += ","
        End If

        GLCommand.CommandText += " (@GLTransactionKey + " + GLLineCount.ToString() + ", @GLAccountNumber" + GLLineCount.ToString() + ", @GLTransactionDescription" + GLLineCount.ToString() + ", @GLTransactionDate, @GLTransactionDebitAmount" + GLLineCount.ToString() + ", @GLTransactionCreditAmount" + GLLineCount.ToString() + ",  @GLTransactionComment" + GLLineCount.ToString() + ", @DivisionID, @GLJournalID" + GLLineCount.ToString() + ", @GLBatchNumber" + GLLineCount.ToString() + ", @GLReferenceNumber" + GLLineCount.ToString() + ", @GLReferenceLine" + GLLineCount.ToString() + ", 'POSTED')"

        With GLCommand.Parameters
            .Add("@GLAccountNumber" + GLLineCount.ToString(), SqlDbType.VarChar).Value = AccountNumber
            .Add("@GLTransactionDescription" + GLLineCount.ToString(), SqlDbType.VarChar).Value = Description
            .Add("@GLTransactionDebitAmount" + GLLineCount.ToString(), SqlDbType.Float).Value = DebitAmount
            .Add("@GLTransactionCreditAmount" + GLLineCount.ToString(), SqlDbType.Float).Value = CreditAmount
            .Add("@GLTransactionComment" + GLLineCount.ToString(), SqlDbType.VarChar).Value = Comment
            .Add("@GLJournalID" + GLLineCount.ToString(), SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@GLBatchNumber" + GLLineCount.ToString(), SqlDbType.Int).Value = BatchNumber
            .Add("@GLReferenceNumber" + GLLineCount.ToString(), SqlDbType.Int).Value = ReferenceNumber
            .Add("@GLReferenceLine" + GLLineCount.ToString(), SqlDbType.Int).Value = ReferenceLine
        End With
        GLLineCount += 1
    End Sub

    Private Sub AddFerruleLine(ByRef FerruleProductionLinesCommand As SqlCommand, ByRef firstFerrLine As Boolean, ByRef FerruleLineCount As Integer, ByVal PartNumber As String, _
                               ByVal PartDescription As String, ByVal ProductionQuantity As Double, ByVal UnitCost As Double, ByVal ExtendedCost As Double, ByVal LineWeight As Double, _
                               ByVal LineKey As Integer)
        If firstFerrLine Then
            firstFerrLine = False
        Else
            FerruleProductionLinesCommand.CommandText += ","
        End If
        FerruleProductionLinesCommand.CommandText += " (@FerruleProductionKey, @LineKey" + FerruleLineCount.ToString() + ", @PartNumber" + FerruleLineCount.ToString() + ", @PartDescription" + FerruleLineCount.ToString() + ", @ProductionQuantity" + FerruleLineCount.ToString() + ", @UnitCost" + FerruleLineCount.ToString() + ", @ExtendedCost" + FerruleLineCount.ToString() + ", @LineWeight" + FerruleLineCount.ToString() + ")"
        With FerruleProductionLinesCommand.Parameters
            .Add("@PartNumber" + FerruleLineCount.ToString(), SqlDbType.VarChar).Value = PartNumber
            .Add("@PartDescription" + FerruleLineCount.ToString(), SqlDbType.VarChar).Value = PartDescription
            .Add("@ProductionQuantity" + FerruleLineCount.ToString(), SqlDbType.VarChar).Value = ProductionQuantity
            .Add("@UnitCost" + FerruleLineCount.ToString(), SqlDbType.VarChar).Value = UnitCost
            .Add("@ExtendedCost" + FerruleLineCount.ToString(), SqlDbType.VarChar).Value = ExtendedCost
            .Add("@LineWeight" + FerruleLineCount.ToString(), SqlDbType.VarChar).Value = LineWeight
            .Add("@LineKey" + FerruleLineCount.ToString(), SqlDbType.Int).Value = LineKey
        End With
        FerruleLineCount += 1
    End Sub

    Private Sub AddInventoryTransaction(ByRef InventoryTransCommand As SqlCommand, ByRef firstTrans As Boolean, ByRef InventoryTransNumber As Integer, _
                                        ByVal TransactionTypeNumber As Integer, ByVal TransactionTypeLineNumber As Integer, ByVal PartNumber As String, _
                                        ByVal PartDescription As String, ByVal Quantity As Double, ByVal ItemCost As Double, ByVal ExtendedCost As Double, _
                                        ByVal TransactionMath As String, ByVal GLAccount As String)
        If firstTrans Then
            firstTrans = False
        Else
            InventoryTransCommand.CommandText += ","
        End If
        InventoryTransCommand.CommandText += " (@TransactionNumber + " + InventoryTransNumber.ToString() + ", @TransactionDate, @TransactionType" + InventoryTransNumber.ToString() + ", @TransactionTypeNumber" + InventoryTransNumber.ToString() + ", @TransactionTypeLineNumber" + InventoryTransNumber.ToString() + ", @PartNumber" + InventoryTransNumber.ToString() + ", @PartDescription" + InventoryTransNumber.ToString() + ", @Quantity" + InventoryTransNumber.ToString() + ", @ItemCost" + InventoryTransNumber.ToString() + ", @ItemPrice" + InventoryTransNumber.ToString() + ", @ExtendedAmount" + InventoryTransNumber.ToString() + ", @ExtendedCost" + InventoryTransNumber.ToString() + ", @DivisionID, @TransactionMath" + InventoryTransNumber.ToString() + ", @GLAccount" + InventoryTransNumber.ToString() + ")"
        With InventoryTransCommand.Parameters
            .Add("@TransactionType" + InventoryTransNumber.ToString(), SqlDbType.VarChar).Value = "Post Production"
            .Add("@TransactionTypeNumber" + InventoryTransNumber.ToString(), SqlDbType.VarChar).Value = TransactionTypeNumber
            .Add("@TransactionTypeLineNumber" + InventoryTransNumber.ToString(), SqlDbType.VarChar).Value = TransactionTypeLineNumber
            .Add("@PartNumber" + InventoryTransNumber.ToString(), SqlDbType.VarChar).Value = PartNumber
            .Add("@PartDescription" + InventoryTransNumber.ToString(), SqlDbType.VarChar).Value = PartDescription
            .Add("@Quantity" + InventoryTransNumber.ToString(), SqlDbType.Float).Value = Quantity
            .Add("@ItemCost" + InventoryTransNumber.ToString(), SqlDbType.Float).Value = ItemCost
            .Add("@ItemPrice" + InventoryTransNumber.ToString(), SqlDbType.Float).Value = 0
            .Add("@ExtendedAmount" + InventoryTransNumber.ToString(), SqlDbType.Float).Value = 0
            .Add("@ExtendedCost" + InventoryTransNumber.ToString(), SqlDbType.Float).Value = Math.Round(ExtendedCost, 2)
            .Add("@TransactionMath" + InventoryTransNumber.ToString(), SqlDbType.VarChar).Value = TransactionMath
            .Add("@GLAccount" + InventoryTransNumber.ToString(), SqlDbType.VarChar).Value = GLAccount
        End With
        InventoryTransNumber += 1
    End Sub

    Private Sub AddInventoryCosting(ByRef InventoryCostingCommand As SqlCommand, ByRef firstCosting As Boolean, ByRef InventoryCostingCount As Integer, _
                                    ByRef InventoryCostingInserts As String, ByVal PartNumber As String, ByVal ItemCost As Double, _
                                    ByVal CostQuantity As Double, ByVal ReferenceNumber As Integer, ByVal ReferenceLine As Integer)

        If firstCosting Then
            firstCosting = False
        Else
            InventoryCostingInserts += ", "
        End If
        InventoryCostingCommand.CommandText += " DECLARE @LowerLimit" + InventoryCostingCount.ToString() + " as int = 0; IF EXISTS(SELECT UpperLimit + 1 FROM InventoryCosting WHERE TransactionNumber = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryCosting WHERE PartNumber = @PartNumber" + InventoryCostingCount.ToString() + " AND DivisionID = @DivisionID) AND DivisionID = @DivisionID) SET @LowerLimit" + InventoryCostingCount.ToString() + " = (SELECT UpperLimit + 1 FROM InventoryCosting WHERE TransactionNumber = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryCosting WHERE PartNumber = @PartNumber" + InventoryCostingCount.ToString() + " AND DivisionID = @DivisionID) AND DivisionID = @DivisionID) ELSE SET @LowerLimit" + InventoryCostingCount.ToString() + " = (SELECT 1);"
        InventoryCostingInserts += " (@PartNumber" + InventoryCostingCount.ToString() + ", @DivisionID, @CostingDate, @ItemCost" + InventoryCostingCount.ToString() + ", @CostQuantity" + InventoryCostingCount.ToString() + ", @Status" + InventoryCostingCount.ToString() + ", @LowerLimit" + InventoryCostingCount.ToString() + ", (@LowerLimit" + InventoryCostingCount.ToString() + " + @CostQuantity" + InventoryCostingCount.ToString() + " - 1), @TransactionNumber+ " + InventoryCostingCount.ToString() + ", @ReferenceNumber" + InventoryCostingCount.ToString() + ", @ReferenceLine" + InventoryCostingCount.ToString() + ")"
        'Write Values to Inventory Costing Table

        With InventoryCostingCommand.Parameters
            .Add("@PartNumber" + InventoryCostingCount.ToString(), SqlDbType.VarChar).Value = PartNumber
            .Add("@ItemCost" + InventoryCostingCount.ToString(), SqlDbType.Float).Value = ItemCost
            .Add("@CostQuantity" + InventoryCostingCount.ToString(), SqlDbType.Float).Value = CostQuantity
            .Add("@Status" + InventoryCostingCount.ToString(), SqlDbType.VarChar).Value = "WC Production"
            .Add("@ReferenceNumber" + InventoryCostingCount.ToString(), SqlDbType.VarChar).Value = ReferenceNumber
            .Add("@ReferenceLine" + InventoryCostingCount.ToString(), SqlDbType.VarChar).Value = ReferenceLine
        End With
        InventoryCostingCount += 1
    End Sub

    Private Sub AddUpdateLineEntry(ByRef UpdateCommand As SqlCommand, ByRef UpdateCount As Integer, ByRef firstUpdate As Boolean, ByVal LineKey As Integer, ByVal UnitCost As Double, ByVal ExtendedCost As Double)
        If firstUpdate Then
            UpdateCommand.Parameters.Add("@FerruleProductionKey", SqlDbType.Int).Value = Val(cboFerruleProductionKey.Text)
            UpdateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            firstUpdate = False
        End If
        UpdateCommand.CommandText += " UPDATE FerruleProductionLines SET UnitCost = @UnitCost" + UpdateCount.ToString() + ", ExtendedCost = @ExtendedCost" + UpdateCount.ToString() + " WHERE FerruleProductionKey = @FerruleProductionKey AND FerruleLineKey = @FerruleLineKey" + UpdateCount.ToString() + "; UPDATE ItemList SET StandardCost = @UnitCost" + UpdateCount.ToString() + " WHERE ItemID = (SELECT PartNumber FROM FerruleProductionLines WHERE FerruleLineKey = @FerruleLineKey" + UpdateCount.ToString() + " AND FerruleProductionKey = @FerruleProductionKey) AND DivisionID = @DivisionID;"
        UpdateCommand.Parameters.Add("@FerruleLineKey" + UpdateCount.ToString(), SqlDbType.Int).Value = LineKey
        UpdateCommand.Parameters.Add("@UnitCost" + UpdateCount.ToString(), SqlDbType.Float).Value = UnitCost
        UpdateCommand.Parameters.Add("@ExtendedCost" + UpdateCount.ToString(), SqlDbType.Float).Value = ExtendedCost

        UpdateCount += 1
    End Sub

    Private Sub ClearAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAddLine.Click
        ClearLines()
    End Sub

    Private Sub dgvFerruleProductionGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFerruleProductionGrid.CellValueChanged
        If dgvFerruleProductionGrid.RowCount = 0 Then
            'Do nothing
        Else
            Dim RowProductionKey As Integer = 0
            Dim RowLineKey As Integer = 0
            Dim RowPartNumber As String = ""
            Dim RowDescription As String = ""
            Dim RowQuantity, RowUnitCost, RowExtendedCost, RowLineWeight As Double

            Dim RowIndex As Integer = Me.dgvFerruleProductionGrid.CurrentCell.RowIndex

            Try
                RowProductionKey = Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("FerruleProductionKeyColumn").Value
            Catch ex As Exception
                RowProductionKey = 0
            End Try
            Try
                RowLineKey = Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("FerruleLineKeyColumn").Value
            Catch ex As Exception
                RowLineKey = 0
            End Try
            Try
                RowPartNumber = Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowDescription = Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                RowDescription = ""
            End Try
            Try
                RowQuantity = Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("ProductionQuantityColumn").Value
            Catch ex As Exception
                RowQuantity = 0
            End Try
            Try
                RowUnitCost = Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("UnitCostColumn").Value
            Catch ex As Exception
                RowUnitCost = 0
            End Try

            RowExtendedCost = RowQuantity * RowUnitCost
            RowExtendedCost = Math.Round(RowExtendedCost, 2)
            Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("ExtendedCostColumn").Value = RowExtendedCost

            'Get Piece Weight to recalculate line weight
            Dim GetRowWeight As Double = 0

            Dim GetRowWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetRowWeightCommand As New SqlCommand(GetRowWeightStatement, con)
            GetRowWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetRowWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetRowWeight = CDbl(GetRowWeightCommand.ExecuteScalar)
            Catch ex As Exception
                GetRowWeight = 0
            End Try
            con.Close()

            RowLineWeight = GetRowWeight * RowQuantity
            RowLineWeight = Math.Round(RowLineWeight, 2)
            Me.dgvFerruleProductionGrid.Rows(RowIndex).Cells("LineWeightColumn").Value = RowLineWeight
            '****************************************************************************************************************************************
            Try
                cmd = New SqlCommand("UPDATE FerruleProductionLines SET ProductionQuantity = @ProductionQuantity, UnitCost = @UnitCost, ExtendedCost = @ExtendedCost, LineWeight = @LineWeight WHERE FerruleProductionKey = @FerruleProductionKey AND FerruleLineKey = @FerruleLineKey", con)

                With cmd.Parameters
                    .Add("@FerruleProductionKey", SqlDbType.VarChar).Value = RowProductionKey
                    .Add("@FerruleLineKey", SqlDbType.VarChar).Value = RowLineKey
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = RowDescription
                    .Add("@ProductionQuantity", SqlDbType.VarChar).Value = RowQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = RowUnitCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = RowExtendedCost
                    .Add("@LineWeight", SqlDbType.VarChar).Value = RowLineWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempFerruleProductionNumber As Integer = 0
                Dim strTempFerruleProductionNumber As String
                TempFerruleProductionNumber = Val(cboFerruleProductionKey.Text)
                strTempFerruleProductionNumber = CStr(TempFerruleProductionNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Ferrule Production - Cell changed in DGV"
                ErrorReferenceNumber = "Batch # " + strTempFerruleProductionNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

            End Try

            'Load Totals and updated Datagrid
            LoadTotals()
            'ShowData()
        End If
    End Sub
End Class