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
Public Class ItemMaintenanceConsignment
    Inherits System.Windows.Forms.Form

    Dim FOBType As String = ""
    Dim WarehouseID As String = ""
    Dim ItemClass, PurchProdLineID, SalesProdLineID As String
    Dim PieceWeight, BoxWeight, PalletWeight As Double
    Dim PalletCount, BoxCount, PalletPieces As Integer
    Dim DivisionQOH, WarehouseQOH As Double
    Dim CheckItemClass As String = ""
    Dim VerifyItemClass As Integer = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ItemMaintenanceConsignment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesProductLine' table. You can move, or remove it, as needed.
        Me.SalesProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseProductLine' table. You can move, or remove it, as needed.
        Me.PurchaseProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
       
        'Clear Variables and fields on load
        ClearFormOnLoad()
        ClearDataInDatagrid()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemList")
        dgvItemList.DataSource = ds.Tables("ItemList")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvItemList.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
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
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadFOB()
        'Loads FOB
        cmd = New SqlCommand("SELECT FOBName FROM FOBTable WHERE DivisionID = @DivisionID AND Status = @Status AND Type = @Type", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = FOBType
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "FOBTable")
        cboWareName.DataSource = ds3.Tables("FOBTable")
        con.Close()
        cboWareName.SelectedIndex = -1
    End Sub

    Public Sub LoadWarehouseID()
        Dim WarehouseIDString As String = "SELECT FOBID FROM FOBTable WHERE FOBName = @FOBName AND DivisionID = @DivisionID AND Status <> 'INACTIVE'"
        Dim WarehouseIDCommand As New SqlCommand(WarehouseIDString, con)
        WarehouseIDCommand.Parameters.Add("@FOBName", SqlDbType.VarChar).Value = cboWareName.Text
        WarehouseIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            WarehouseID = CStr(WarehouseIDCommand.ExecuteScalar)
        Catch ex As Exception
            WarehouseID = ""
        End Try
        con.Close()

        lblWarehouseCode.Text = WarehouseID
    End Sub

    Public Sub LoadItemData()
        'Extract data from source table
        Dim GetItemDataString As String = "SELECT * FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetItemDataCommand As New SqlCommand(GetItemDataString, con)
        GetItemDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetItemDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetItemDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
            If IsDBNull(reader.Item("PurchProdLineID")) Then
                PurchProdLineID = ""
            Else
                PurchProdLineID = reader.Item("PurchProdLineID")
            End If
            If IsDBNull(reader.Item("SalesProdLineID")) Then
                SalesProdLineID = ""
            Else
                SalesProdLineID = reader.Item("SalesProdLineID")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                PieceWeight = 0
            Else
                PieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                BoxCount = 0
            Else
                BoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                BoxWeight = 0
            Else
                BoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                PalletCount = 0
            Else
                PalletCount = reader.Item("PalletCount")
            End If
        Else
            ItemClass = ""
            PurchProdLineID = ""
            SalesProdLineID = ""
            PieceWeight = 0
            BoxCount = 0
            BoxWeight = 0
            PalletCount = 0
        End If
        reader.Close()
        con.Close()

        cboItemClass.Text = ItemClass
        cboSPL.Text = SalesProdLineID
        cboPPL.Text = PurchProdLineID

        txtPieceWeight.Text = PieceWeight
        txtBoxCount.Text = BoxCount
        txtPalletCount.Text = PalletCount

        'Get Box Weight
        If BoxWeight = 0 Then
            BoxWeight = PieceWeight * BoxCount
            BoxWeight = Math.Round(BoxWeight, 0)
            txtBoxWeight.Text = BoxWeight
        Else
            txtBoxWeight.Text = BoxWeight
        End If

        'Calc Pallet Pieces
        PalletPieces = BoxCount * PalletCount
        txtPiecesPerPallet.Text = PalletPieces

        'Calc Pallet Weight
        PalletWeight = (BoxWeight * PalletCount) + 34
        PalletWeight = Math.Round(PalletWeight, 0)
        txtPalletWeight.Text = PalletWeight
    End Sub

    Public Sub ClearFormOnLoad()
        cboItemClass.SelectedIndex = -1
        cboPPL.SelectedIndex = -1
        cboSPL.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboWareName.SelectedIndex = -1

        txtBoxCount.Clear()
        txtBoxWeight.Clear()
        txtDivisionQOH.Clear()
        txtPalletCount.Clear()
        txtPalletWeight.Clear()
        txtPieceWeight.Clear()
        txtWarehouseQOH.Clear()
        txtDivisionQOH.Clear()

        lblWarehouseCode.Text = ""
    End Sub

    Public Sub ClearItemDataFields()
        cboItemClass.SelectedIndex = -1
        cboPPL.SelectedIndex = -1
        cboSPL.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        txtBoxCount.Clear()
        txtBoxWeight.Clear()
        txtDivisionQOH.Clear()
        txtPalletCount.Clear()
        txtPalletWeight.Clear()
        txtPieceWeight.Clear()
        txtWarehouseQOH.Clear()
        txtDivisionQOH.Clear()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TWD" Then
            FOBType = "AMERICAN"
            LoadFOB()
        ElseIf cboDivisionID.Text = "TWE" Then
            FOBType = "AMERICAN"
            LoadFOB()
        ElseIf cboDivisionID.Text = "TFF" Then
            FOBType = "CANADIAN"
            LoadFOB()
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cboWareName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWareName.SelectedIndexChanged
        If cboWareName.Text = "" Then
            'Do nothing
        Else
            LoadWarehouseID()
            LoadPartNumber()
            LoadPartDescription()
            ShowData()
        End If
    End Sub

    Public Sub VerifyItemClassID()
        Dim VerifyItemClassStatement As String = "SELECT COUNT(ItemClassID) FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim VerifyItemClassCommand As New SqlCommand(VerifyItemClassStatement, con)
        VerifyItemClassCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = CheckItemClass

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyItemClass = CInt(VerifyItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyItemClass = 0
        End Try
        con.Close()
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

    Public Sub LoadQOH()
        Dim WarehouseQOHStatement As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim WarehouseQOHCommand As New SqlCommand(WarehouseQOHStatement, con)
        WarehouseQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        WarehouseQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID

        Dim DivisionQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim DivisionQOHCommand As New SqlCommand(DivisionQOHStatement, con)
        DivisionQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        DivisionQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            WarehouseQOH = CDbl(WarehouseQOHCommand.ExecuteScalar)
        Catch ex As Exception
            WarehouseQOH = 0
        End Try
        Try
            DivisionQOH = CDbl(DivisionQOHCommand.ExecuteScalar)
        Catch ex As Exception
            DivisionQOH = 0
        End Try
        con.Close()

        txtWarehouseQOH.Text = WarehouseQOH
        txtDivisionQOH.Text = DivisionQOH
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboPartNumber.Text = "" Or cboPartDescription.Text = "" Then
            MsgBox("You must have a part # and description selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        If cboItemClass.Text = "" Then
            MsgBox("You must have an Item Class selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        CheckItemClass = cboItemClass.Text
        VerifyItemClassID()

        If VerifyItemClass = 0 Then
            MsgBox("Invalid Item Class", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            InsertIntoItemList()
        Catch ex As Exception
            UpdateItemList()
        End Try

        MsgBox("Part # created/saved.", MsgBoxStyle.OkOnly)

        ShowData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearItemDataFields()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        LoadItemData()
        LoadQOH()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub dgvItemList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellValueChanged
        If dgvItemList.RowCount <> 0 Then
            Dim RowPartNumber As String = ""
            Dim RowDescription As String = ""
            Dim RowItemClass As String = ""
            Dim RowPPL As String = ""
            Dim RowSPL As String = ""
            Dim RowBoxWeight As Double = 0
            Dim RowPalletCount As Integer = 0
            Dim RowBoxCount As Integer = 0
            Dim RowPieceWeight As Double = 0

            Dim RowIndex As Integer = Me.dgvItemList.CurrentCell.RowIndex

            RowPartNumber = Me.dgvItemList.Rows(RowIndex).Cells("ItemIDColumn").Value
            RowDescription = Me.dgvItemList.Rows(RowIndex).Cells("ShortDescriptionColumn").Value
            RowItemClass = Me.dgvItemList.Rows(RowIndex).Cells("ItemClassColumn").Value
            RowPPL = Me.dgvItemList.Rows(RowIndex).Cells("PurchProdLineIDColumn").Value
            RowSPL = Me.dgvItemList.Rows(RowIndex).Cells("SalesProdLineIDColumn").Value
            RowBoxWeight = Me.dgvItemList.Rows(RowIndex).Cells("BoxWeightColumn").Value
            RowPalletCount = Me.dgvItemList.Rows(RowIndex).Cells("PalletCountColumn").Value
            RowBoxCount = Me.dgvItemList.Rows(RowIndex).Cells("BoxCountColumn").Value
            RowPieceWeight = Me.dgvItemList.Rows(RowIndex).Cells("PieceWeightColumn").Value

            CheckItemClass = RowItemClass
            VerifyItemClassID()

            If VerifyItemClass = 0 Then
                MsgBox("Invalid Item Class", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE ItemList SET ShortDescription = @ShortDescription, ItemClass = @ItemClass, PurchProdLineID = @PurchProdLineID, SalesProdLineID = @SalesProdLineID, PieceWeight = @PieceWeight, BoxCount = @BoxCount, PalletCount = @PalletCount, BoxWeight = @BoxWeight WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
                    .Add("@ShortDescription", SqlDbType.VarChar).Value = RowDescription
                    .Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass
                    .Add("@PurchProdLineID", SqlDbType.VarChar).Value = RowPPL
                    .Add("@SalesProdLineID", SqlDbType.VarChar).Value = RowSPL
                    .Add("@PieceWeight", SqlDbType.VarChar).Value = RowPieceWeight
                    .Add("@BoxCount", SqlDbType.VarChar).Value = RowBoxCount
                    .Add("@PalletCount", SqlDbType.VarChar).Value = RowPalletCount
                    .Add("@BoxWeight", SqlDbType.VarChar).Value = RowBoxWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub

    Public Sub UpdateItemList()
        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("UPDATE ItemList SET ShortDescription = @ShortDescription, ItemClass = @ItemClass, PurchProdLineID = @PurchProdLineID, SalesProdLineID = @SalesProdLineID, PieceWeight = @PieceWeight, BoxCount = @BoxCount, PalletCount = @PalletCount, BoxWeight = @BoxWeight WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            .Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
            .Add("@PurchProdLineID", SqlDbType.VarChar).Value = cboPPL.Text
            .Add("@SalesProdLineID", SqlDbType.VarChar).Value = cboSPL.Text
            .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
            .Add("@BoxCount", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
            .Add("@PalletCount", SqlDbType.VarChar).Value = Val(txtPalletCount.Text)
            .Add("@BoxWeight", SqlDbType.VarChar).Value = Val(txtBoxWeight.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub InsertIntoItemList()
        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Insert Into ItemList(ItemID, DivisionID, ShortDescription, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, PieceWeight, BoxCount, PalletCount, StandardCost, StandardPrice, OldPartNumber, MinimumStock, MaximumStock, CreationDate, BeginningBalance, FOXNumber, BoxType, NominalDiameter, NominalLength, AddAccessory, PreferredVendor, Locked, SafetyDataSheet, BoxWeight)Values(@ItemID, @DivisionID, @ShortDescription, @LongDescription, @ItemClass, @PurchProdLineID, @SalesProdLineID, @PieceWeight, @BoxCount, @PalletCount, @StandardCost, @StandardPrice, @OldPartNumber, @MinimumStock, @MaximumStock, @CreationDate, @BeginningBalance, @FOXNumber, @BoxType, @NominalDiameter, @NominalLength, @AddAccessory, @PreferredVendor, @Locked, @SafetyDataSheet, @BoxWeight);", con)

        With cmd.Parameters
            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            .Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            .Add("@LongDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
            .Add("@PurchProdLineID", SqlDbType.VarChar).Value = cboPPL.Text
            .Add("@SalesProdLineID", SqlDbType.VarChar).Value = cboSPL.Text
            .Add("@PieceWeight", SqlDbType.VarChar).Value = Val(txtPieceWeight.Text)
            .Add("@BoxCount", SqlDbType.VarChar).Value = Val(txtBoxCount.Text)
            .Add("@PalletCount", SqlDbType.VarChar).Value = Val(txtPalletCount.Text)
            .Add("@StandardCost", SqlDbType.VarChar).Value = 0
            .Add("@StandardPrice", SqlDbType.VarChar).Value = 0
            .Add("@OldPartNumber", SqlDbType.VarChar).Value = ""
            .Add("@MinimumStock", SqlDbType.VarChar).Value = 0
            .Add("@MaximumStock", SqlDbType.VarChar).Value = 0
            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
            .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
            .Add("@FOXNumber", SqlDbType.VarChar).Value = 0
            .Add("@BoxType", SqlDbType.VarChar).Value = ""
            .Add("@NominalDiameter", SqlDbType.VarChar).Value = 0
            .Add("@NominalLength", SqlDbType.VarChar).Value = 0
            .Add("@AddAccessory", SqlDbType.VarChar).Value = "NO"
            .Add("@PreferredVendor", SqlDbType.VarChar).Value = "TFP CORP"
            .Add("@Locked", SqlDbType.VarChar).Value = ""
            .Add("@SafetyDataSheet", SqlDbType.VarChar).Value = ""
            .Add("@BoxWeight", SqlDbType.VarChar).Value = Val(txtBoxWeight.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub dgvItemList_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvItemList.RowHeaderMouseClick
        If dgvItemList.RowCount <> 0 Then
            Dim RowPartNumber As String = ""

            Dim RowIndex As Integer = Me.dgvItemList.CurrentCell.RowIndex

            RowPartNumber = Me.dgvItemList.Rows(RowIndex).Cells("ItemIDColumn").Value

            cboPartNumber.Text = RowPartNumber
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

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = WarehouseID
        GDS = ds

        Using NewPrintItemListFiltered As New PrintItemListFiltered
            Dim result = NewPrintItemListFiltered.ShowDialog()
        End Using
    End Sub
End Class