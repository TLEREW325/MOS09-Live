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
Public Class InventoryPriceLevels
    Inherits System.Windows.Forms.Form

    Dim LongDescription As String
    Dim Multiplier1, Multiplier2, Multiplier3, Multiplier4, Multiplier5 As Double
    Dim PriceLevel1, PriceLevel2, PriceLevel3, PriceLevel4, PriceLevel5 As Double
    Dim LastPurchaseCost, LastPurchaseCost2, BaseCost As Double
    Dim MaxDate, MaxDate2 As Integer
    Dim ItemMultiplier1, ItemMultiplier2, ItemMultiplier3, ItemMultiplier4, ItemMultiplier5 As Double
    Dim ItemPriceLevel1, ItemPriceLevel2, ItemPriceLevel3, ItemPriceLevel4, ItemPriceLevel5 As Double

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub InventoryPriceLevels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode
        LoadPartNumber()
        ClearVariables()
        ClearData()
    End Sub

    Public Sub ShowPartNumberByItemClass()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription, StandardCost, StandardPrice FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass = @ItemClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemList")
        dgvItemList.DataSource = ds.Tables("ItemList")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadLongDescription()
        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID And DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        con.Close()

        txtLongDescription.Text = LongDescription
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        ClearVariables()
        ClearData()
        ShowPartNumberByItemClass()
    End Sub

    Public Sub LoadLastPurchaseCost()
        'Determine last purchase date
        Dim MAXDateStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MAXDate = 0
        End Try
        con.Close()

        'Load values into Cost Field
        Dim LastCostStatement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
        Dim LastCostCommand As New SqlCommand(LastCostStatement, con)
        LastCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastCostCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MAXDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPurchaseCost = CDbl(LastCostCommand.ExecuteScalar)
        Catch ex As Exception
            LastPurchaseCost = 0
        End Try
        con.Close()

        txtLastPurchaseCost.Text = LastPurchaseCost
    End Sub

    Public Sub LoadPriceLevels()
        Dim BaseCostStatement As String = "SELECT BaseCost FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim BaseCostCommand As New SqlCommand(BaseCostStatement, con)
        BaseCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        BaseCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim PriceLevel1Statement As String = "SELECT PriceLevel1 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim PriceLevel1Command As New SqlCommand(PriceLevel1Statement, con)
        PriceLevel1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        PriceLevel1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim PriceLevel2Statement As String = "SELECT PriceLevel2 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim PriceLevel2Command As New SqlCommand(PriceLevel2Statement, con)
        PriceLevel2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        PriceLevel2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim PriceLevel3Statement As String = "SELECT PriceLevel3 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim PriceLevel3Command As New SqlCommand(PriceLevel3Statement, con)
        PriceLevel3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        PriceLevel3Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim PriceLevel4Statement As String = "SELECT PriceLevel4 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim PriceLevel4Command As New SqlCommand(PriceLevel4Statement, con)
        PriceLevel4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        PriceLevel4Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim PriceLevel5Statement As String = "SELECT PriceLevel5 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim PriceLevel5Command As New SqlCommand(PriceLevel5Statement, con)
        PriceLevel5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        PriceLevel5Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim Multiplier1Statement As String = "SELECT Multiplier1 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim Multiplier1Command As New SqlCommand(Multiplier1Statement, con)
        Multiplier1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Multiplier1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim Multiplier2Statement As String = "SELECT Multiplier2 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim Multiplier2Command As New SqlCommand(Multiplier2Statement, con)
        Multiplier2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Multiplier2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim Multiplier3Statement As String = "SELECT Multiplier3 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim Multiplier3Command As New SqlCommand(Multiplier3Statement, con)
        Multiplier3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Multiplier3Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim Multiplier4Statement As String = "SELECT Multiplier4 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim Multiplier4Command As New SqlCommand(Multiplier4Statement, con)
        Multiplier4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Multiplier4Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        Dim Multiplier5Statement As String = "SELECT Multiplier5 FROM InventoryPriceLevels WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim Multiplier5Command As New SqlCommand(Multiplier5Statement, con)
        Multiplier5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Multiplier5Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BaseCost = CDbl(BaseCostCommand.ExecuteScalar)
        Catch ex As Exception
            BaseCost = 0
        End Try
        Try
            PriceLevel1 = CDbl(PriceLevel1Command.ExecuteScalar)
        Catch ex As Exception
            PriceLevel1 = 0
        End Try
        Try
            PriceLevel2 = CDbl(PriceLevel2Command.ExecuteScalar)
        Catch ex As Exception
            PriceLevel2 = 0
        End Try
        Try
            PriceLevel3 = CDbl(PriceLevel3Command.ExecuteScalar)
        Catch ex As Exception
            PriceLevel3 = 0
        End Try
        Try
            PriceLevel4 = CDbl(PriceLevel4Command.ExecuteScalar)
        Catch ex As Exception
            PriceLevel4 = 0
        End Try
        Try
            PriceLevel5 = CDbl(PriceLevel5Command.ExecuteScalar)
        Catch ex As Exception
            PriceLevel5 = 0
        End Try
        Try
            Multiplier1 = CDbl(Multiplier1Command.ExecuteScalar)
        Catch ex As Exception
            Multiplier1 = 0
        End Try
        Try
            Multiplier2 = CDbl(Multiplier2Command.ExecuteScalar)
        Catch ex As Exception
            Multiplier2 = 0
        End Try
        Try
            Multiplier3 = CDbl(Multiplier3Command.ExecuteScalar)
        Catch ex As Exception
            Multiplier3 = 0
        End Try
        Try
            Multiplier4 = CDbl(Multiplier4Command.ExecuteScalar)
        Catch ex As Exception
            Multiplier4 = 0
        End Try
        Try
            Multiplier5 = CDbl(Multiplier5Command.ExecuteScalar)
        Catch ex As Exception
            Multiplier5 = 0
        End Try
        con.Close()

        txtBaseCost.Text = BaseCost
        txtMultiplier1.Text = Multiplier1
        txtMultiplier2.Text = Multiplier2
        txtMultiplier3.Text = Multiplier3
        txtMultiplier4.Text = Multiplier4
        txtMultiplier5.Text = Multiplier5
        txtPriceLevel1.Text = PriceLevel1
        txtPriceLevel2.Text = PriceLevel2
        txtPriceLevel3.Text = PriceLevel3
        txtPriceLevel4.Text = PriceLevel4
        txtPriceLevel5.Text = PriceLevel5
    End Sub

    Public Sub ClearData()
        cboItemClass.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        txtBaseCost.Clear()
        txtCalculatedMultiplier.Clear()
        txtGrossMargin.Clear()
        txtItemMultiplier1.Clear()
        txtItemMultiplier2.Clear()
        txtItemMultiplier3.Clear()
        txtItemMultiplier4.Clear()
        txtItemMultiplier5.Clear()
        txtLastPurchaseCost.Clear()
        txtLongDescription.Clear()
        txtMultiplier1.Clear()
        txtMultiplier2.Clear()
        txtMultiplier3.Clear()
        txtMultiplier4.Clear()
        txtMultiplier5.Clear()
        txtPriceLevel1.Clear()
        txtPriceLevel2.Clear()
        txtPriceLevel3.Clear()
        txtPriceLevel4.Clear()
        txtPriceLevel5.Clear()

        chkUpdateStandard.Checked = False
        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        LongDescription = ""
        Multiplier1 = 0
        Multiplier2 = 0
        Multiplier3 = 0
        Multiplier4 = 0
        Multiplier5 = 0
        PriceLevel1 = 0
        PriceLevel2 = 0
        PriceLevel3 = 0
        PriceLevel4 = 0
        PriceLevel5 = 0
        LastPurchaseCost = 0
        LastPurchaseCost2 = 0
        BaseCost = 0
        MaxDate = 0
        MaxDate2 = 0
        ItemMultiplier1 = 0
        ItemMultiplier2 = 0
        ItemMultiplier3 = 0
        ItemMultiplier4 = 0
        ItemMultiplier5 = 0
        ItemPriceLevel1 = 0
        ItemPriceLevel2 = 0
        ItemPriceLevel3 = 0
        ItemPriceLevel4 = 0
        ItemPriceLevel5 = 0
    End Sub

    Private Sub txtGrossMargin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrossMargin.TextChanged
        Dim GrossMargin, CalculatedMultipler As Double

        GrossMargin = Val(txtGrossMargin.Text)
        CalculatedMultipler = GrossMargin / (1 - GrossMargin)
        CalculatedMultipler = Math.Round(CalculatedMultipler, 3)
        CalculatedMultipler = 1 + CalculatedMultipler

        txtCalculatedMultiplier.Text = CalculatedMultipler
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        ShowPartNumberByItemClass()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadLongDescription()
        LoadLastPurchaseCost()
        LoadPriceLevels()
    End Sub

    Private Sub txtMultiplier1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplier1.TextChanged
        If Val(txtMultiplier1.Text) = 0 Then
            'Do nothing
        Else
            BaseCost = Val(txtBaseCost.Text)
            Multiplier1 = Val(txtMultiplier1.Text)
            PriceLevel1 = BaseCost * Multiplier1
            txtPriceLevel1.Text = PriceLevel1
        End If
    End Sub

    Private Sub txtMultiplier2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplier2.TextChanged
        If Val(txtMultiplier2.Text) = 0 Then
            'Do nothing
        Else
            BaseCost = Val(txtBaseCost.Text)
            Multiplier2 = Val(txtMultiplier2.Text)
            PriceLevel2 = BaseCost * Multiplier2
            txtPriceLevel2.Text = PriceLevel2
        End If
    End Sub

    Private Sub txtMultiplier3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplier3.TextChanged
        If Val(txtMultiplier3.Text) = 0 Then
            'Do nothing
        Else
            BaseCost = Val(txtBaseCost.Text)
            Multiplier3 = Val(txtMultiplier3.Text)
            PriceLevel3 = BaseCost * Multiplier3
            txtPriceLevel3.Text = PriceLevel3
        End If
    End Sub

    Private Sub txtMultiplier4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplier4.TextChanged
        If Val(txtMultiplier4.Text) = 0 Then
            'Do nothing
        Else
            BaseCost = Val(txtBaseCost.Text)
            Multiplier4 = Val(txtMultiplier4.Text)
            PriceLevel4 = BaseCost * Multiplier4
            txtPriceLevel4.Text = PriceLevel4
        End If
    End Sub

    Private Sub txtMultiplier5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplier5.TextChanged
        If Val(txtMultiplier5.Text) = 0 Then
            'Do nothing
        Else
            BaseCost = Val(txtBaseCost.Text)
            Multiplier5 = Val(txtMultiplier5.Text)
            PriceLevel5 = BaseCost * Multiplier5
            txtPriceLevel5.Text = PriceLevel5
        End If
    End Sub

    Private Sub cmdUpdateBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateBase.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            BaseCost = Val(txtBaseCost.Text)

            Multiplier1 = Val(txtMultiplier1.Text)
            Multiplier2 = Val(txtMultiplier2.Text)
            Multiplier3 = Val(txtMultiplier3.Text)
            Multiplier4 = Val(txtMultiplier4.Text)
            Multiplier5 = Val(txtMultiplier5.Text)

            If Multiplier1 <> 0 Then
                PriceLevel1 = BaseCost * Multiplier1
            Else
                PriceLevel1 = Val(txtPriceLevel1.Text)
            End If
            If Multiplier2 <> 0 Then
                PriceLevel2 = BaseCost * Multiplier2
            Else
                PriceLevel2 = Val(txtPriceLevel2.Text)
            End If
            If Multiplier3 <> 0 Then
                PriceLevel3 = BaseCost * Multiplier3
            Else
                PriceLevel3 = Val(txtPriceLevel3.Text)
            End If
            If Multiplier4 <> 0 Then
                PriceLevel4 = BaseCost * Multiplier4
            Else
                PriceLevel4 = Val(txtPriceLevel4.Text)
            End If
            If Multiplier5 <> 0 Then
                PriceLevel5 = BaseCost * Multiplier5
            Else
                PriceLevel5 = Val(txtPriceLevel5.Text)
            End If

            txtPriceLevel1.Text = PriceLevel1
            txtPriceLevel2.Text = PriceLevel2
            txtPriceLevel3.Text = PriceLevel3
            txtPriceLevel4.Text = PriceLevel4
            txtPriceLevel5.Text = PriceLevel5

            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("Insert Into InventoryPriceLevels(DivisionID, PartNumber, PartDescription, BaseCost)Values(@DivisionID, @PartNumber, @PartDescription, @BaseCost)", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@BaseCost", SqlDbType.VarChar).Value = Val(txtBaseCost.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE InventoryPriceLevels SET BaseCost = @BaseCost WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@BaseCost", SqlDbType.VarChar).Value = Val(txtBaseCost.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try
        End If
    End Sub

    Private Sub cmdUpdateLevels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateLevels.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
        Else
            BaseCost = Val(txtBaseCost.Text)

            Multiplier1 = Val(txtMultiplier1.Text)
            Multiplier2 = Val(txtMultiplier2.Text)
            Multiplier3 = Val(txtMultiplier3.Text)
            Multiplier4 = Val(txtMultiplier4.Text)
            Multiplier5 = Val(txtMultiplier5.Text)

            If Multiplier1 <> 0 Then
                PriceLevel1 = BaseCost * Multiplier1
            Else
                PriceLevel1 = Val(txtPriceLevel1.Text)
            End If
            If Multiplier2 <> 0 Then
                PriceLevel2 = BaseCost * Multiplier2
            Else
                PriceLevel2 = Val(txtPriceLevel2.Text)
            End If
            If Multiplier3 <> 0 Then
                PriceLevel3 = BaseCost * Multiplier3
            Else
                PriceLevel3 = Val(txtPriceLevel3.Text)
            End If
            If Multiplier4 <> 0 Then
                PriceLevel4 = BaseCost * Multiplier4
            Else
                PriceLevel4 = Val(txtPriceLevel4.Text)
            End If
            If Multiplier5 <> 0 Then
                PriceLevel5 = BaseCost * Multiplier5
            Else
                PriceLevel5 = Val(txtPriceLevel5.Text)
            End If

            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("Insert Into InventoryPriceLevels(DivisionID, PartNumber, PartDescription, BaseCost, PriceLevel1, PriceLevel2, PriceLevel3, PriceLevel4, PriceLevel5, Multiplier1, Multiplier2, Multiplier3, Multiplier4, Multiplier5)Values(@DivisionID, @PartNumber, @PartDescription, @BaseCost, @PriceLevel1, @PriceLevel2, @PriceLevel3, @PriceLevel4, @PriceLevel5, @Multiplier1, @Multiplier2, @Multiplier3, @Multiplier4, @Multiplier5)", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@BaseCost", SqlDbType.VarChar).Value = Val(txtBaseCost.Text)
                    .Add("@PriceLevel1", SqlDbType.VarChar).Value = PriceLevel1
                    .Add("@PriceLevel2", SqlDbType.VarChar).Value = PriceLevel2
                    .Add("@PriceLevel3", SqlDbType.VarChar).Value = PriceLevel3
                    .Add("@PriceLevel4", SqlDbType.VarChar).Value = PriceLevel4
                    .Add("@PriceLevel5", SqlDbType.VarChar).Value = PriceLevel5
                    .Add("@Multiplier1", SqlDbType.VarChar).Value = Multiplier1
                    .Add("@Multiplier2", SqlDbType.VarChar).Value = Multiplier2
                    .Add("@Multiplier3", SqlDbType.VarChar).Value = Multiplier3
                    .Add("@Multiplier4", SqlDbType.VarChar).Value = Multiplier4
                    .Add("@Multiplier5", SqlDbType.VarChar).Value = Multiplier5
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE InventoryPriceLevels SET BaseCost = @BaseCost, PartDescription = @PartDescription, PriceLevel1 = @PriceLevel1, PriceLevel2 = @PriceLevel2, PriceLevel3 = @PriceLevel3, PriceLevel4 = @PriceLevel4, PriceLevel5 = @PriceLevel5, Multiplier1 = @Multiplier1, Multiplier2 = @Multiplier2, Multiplier3 = @Multiplier3, Multiplier4 = @Multiplier4, Multiplier5 = @Multiplier5 WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@BaseCost", SqlDbType.VarChar).Value = Val(txtBaseCost.Text)
                    .Add("@PriceLevel1", SqlDbType.VarChar).Value = PriceLevel1
                    .Add("@PriceLevel2", SqlDbType.VarChar).Value = PriceLevel2
                    .Add("@PriceLevel3", SqlDbType.VarChar).Value = PriceLevel3
                    .Add("@PriceLevel4", SqlDbType.VarChar).Value = PriceLevel4
                    .Add("@PriceLevel5", SqlDbType.VarChar).Value = PriceLevel5
                    .Add("@Multiplier1", SqlDbType.VarChar).Value = Multiplier1
                    .Add("@Multiplier2", SqlDbType.VarChar).Value = Multiplier2
                    .Add("@Multiplier3", SqlDbType.VarChar).Value = Multiplier3
                    .Add("@Multiplier4", SqlDbType.VarChar).Value = Multiplier4
                    .Add("@Multiplier5", SqlDbType.VarChar).Value = Multiplier5
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try

            MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdUpdateItemClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateItemClass.Click
        'Validate Item Class
        Dim VerifyItemClass As Integer = 0

        Dim VerifyItemClassStatement As String = "SELECT COUNT(ItemClassID) FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim VerifyItemClassCommand As New SqlCommand(VerifyItemClassStatement, con)
        VerifyItemClassCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyItemClass = CInt(VerifyItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyItemClass = 0
        End Try
        con.Close()

        If cboItemClass.Text = "" Or VerifyItemClass = 0 Then
            MsgBox("You must have a valid Item Class selected.", MsgBoxStyle.OkOnly)
        Else
            Dim PartNumber, ShortDescription As String

            'Get Part Number from Datagrid
            For Each row As DataGridViewRow In dgvItemList.Rows
                Try
                    PartNumber = row.Cells("ItemIDColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    ShortDescription = row.Cells("ShortDescriptionColumn").Value
                Catch ex As Exception
                    ShortDescription = ""
                End Try

                'Get Last Purchase Cost for each part number
                Dim MAXDate2Statement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxDate2 = CInt(MAXDate2Command.ExecuteScalar)
                Catch ex As Exception
                    MaxDate2 = 0
                End Try
                con.Close()

                'Load values into Cost Field
                Dim LastCost2Statement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                Dim LastCost2Command As New SqlCommand(LastCost2Statement, con)
                LastCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                LastCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                LastCost2Command.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxDate2

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastPurchaseCost2 = CDbl(LastCost2Command.ExecuteScalar)
                Catch ex As Exception
                    LastPurchaseCost2 = 0
                End Try
                con.Close()

                'Create Price Levels if LPC > 0
                If LastPurchaseCost2 <> 0 Then
                    ItemMultiplier1 = Val(txtItemMultiplier1.Text)
                    ItemMultiplier2 = Val(txtItemMultiplier2.Text)
                    ItemMultiplier3 = Val(txtItemMultiplier3.Text)
                    ItemMultiplier4 = Val(txtItemMultiplier4.Text)
                    ItemMultiplier5 = Val(txtItemMultiplier5.Text)

                    ItemPriceLevel1 = LastPurchaseCost2 * ItemMultiplier1
                    ItemPriceLevel2 = LastPurchaseCost2 * ItemMultiplier2
                    ItemPriceLevel3 = LastPurchaseCost2 * ItemMultiplier3
                    ItemPriceLevel4 = LastPurchaseCost2 * ItemMultiplier4
                    ItemPriceLevel5 = LastPurchaseCost2 * ItemMultiplier5

                    Try
                        'Create command to update database and fill with text box enties
                        cmd = New SqlCommand("Insert Into InventoryPriceLevels(DivisionID, PartNumber, PartDescription, BaseCost, PriceLevel1, PriceLevel2, PriceLevel3, PriceLevel4, PriceLevel5, Multiplier1, Multiplier2, Multiplier3, Multiplier4, Multiplier5)Values(@DivisionID, @PartNumber, @PartDescription, @BaseCost, @PriceLevel1, @PriceLevel2, @PriceLevel3, @PriceLevel4, @PriceLevel5, @Multiplier1, @Multiplier2, @Multiplier3, @Multiplier4, @Multiplier5)", con)

                        With cmd.Parameters
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = ShortDescription
                            .Add("@BaseCost", SqlDbType.VarChar).Value = LastPurchaseCost2
                            .Add("@PriceLevel1", SqlDbType.VarChar).Value = ItemPriceLevel1
                            .Add("@PriceLevel2", SqlDbType.VarChar).Value = ItemPriceLevel2
                            .Add("@PriceLevel3", SqlDbType.VarChar).Value = ItemPriceLevel3
                            .Add("@PriceLevel4", SqlDbType.VarChar).Value = ItemPriceLevel4
                            .Add("@PriceLevel5", SqlDbType.VarChar).Value = ItemPriceLevel5
                            .Add("@Multiplier1", SqlDbType.VarChar).Value = ItemMultiplier1
                            .Add("@Multiplier2", SqlDbType.VarChar).Value = ItemMultiplier2
                            .Add("@Multiplier3", SqlDbType.VarChar).Value = ItemMultiplier3
                            .Add("@Multiplier4", SqlDbType.VarChar).Value = ItemMultiplier4
                            .Add("@Multiplier5", SqlDbType.VarChar).Value = ItemMultiplier5
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Create command to update database and fill with text box enties
                        cmd = New SqlCommand("UPDATE InventoryPriceLevels SET BaseCost = @BaseCost, PartDescription = @PartDescription, PriceLevel1 = @PriceLevel1, PriceLevel2 = @PriceLevel2, PriceLevel3 = @PriceLevel3, PriceLevel4 = @PriceLevel4, PriceLevel5 = @PriceLevel5, Multiplier1 = @Multiplier1, Multiplier2 = @Multiplier2, Multiplier3 = @Multiplier3, Multiplier4 = @Multiplier4, Multiplier5 = @Multiplier5 WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = ShortDescription
                            .Add("@BaseCost", SqlDbType.VarChar).Value = LastPurchaseCost2
                            .Add("@PriceLevel1", SqlDbType.VarChar).Value = ItemPriceLevel1
                            .Add("@PriceLevel2", SqlDbType.VarChar).Value = ItemPriceLevel2
                            .Add("@PriceLevel3", SqlDbType.VarChar).Value = ItemPriceLevel3
                            .Add("@PriceLevel4", SqlDbType.VarChar).Value = ItemPriceLevel4
                            .Add("@PriceLevel5", SqlDbType.VarChar).Value = ItemPriceLevel5
                            .Add("@Multiplier1", SqlDbType.VarChar).Value = ItemMultiplier1
                            .Add("@Multiplier2", SqlDbType.VarChar).Value = ItemMultiplier2
                            .Add("@Multiplier3", SqlDbType.VarChar).Value = ItemMultiplier3
                            .Add("@Multiplier4", SqlDbType.VarChar).Value = ItemMultiplier4
                            .Add("@Multiplier5", SqlDbType.VarChar).Value = ItemMultiplier5
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Try

                    If chkUpdateStandard.Checked = True Then
                        'Update Standard Purchase Cost in Item List
                        cmd = New SqlCommand("UPDATE ItemList SET StandardCost = @StandardCost, StandardPrice = @StandardPrice WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            .Add("@StandardCost", SqlDbType.VarChar).Value = LastPurchaseCost2
                            .Add("@StandardPrice", SqlDbType.VarChar).Value = ItemPriceLevel1
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Skip update to Item List
                    End If
                Else
                    'Skip Part Number - no cost basis
                End If
            Next

            ShowPartNumberByItemClass()
            MsgBox("Price Sheets have been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearVariables()
        ClearData()
        ShowPartNumberByItemClass()
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowPartNumberByItemClass()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintItemStandardCostPriceFiltered As New PrintItemStandardCostPriceFiltered
            Dim Result = NewPrintItemStandardCostPriceFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintItemStandardCostPriceFiltered As New PrintItemStandardCostPriceFiltered
            Dim Result = NewPrintItemStandardCostPriceFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

End Class