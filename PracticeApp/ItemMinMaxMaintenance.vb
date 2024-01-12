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
Public Class ItemMinMaxMaintenance
    Inherits System.Windows.Forms.Form

    Dim CopyMin, CopyMax As Integer
    Dim Text1Filter, Text2Filter, Text3Filter, PartFilter, ZeroQuantityFilter, ZeroShippedFilter, ItemClassFilter As String

    Dim TextFilterVariable1, TextFilterVariable2, TextFilterVariable3 As String

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ItemMinMaxMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode
    End Sub

    Public Sub ShowDataByFilter()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            Text1Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%')"
        Else
            Text1Filter = ""
        End If
        If txtTextFilter2.Text <> "" Then
            Text2Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter2.Text) + "%')"
        Else
            Text2Filter = ""
        End If
        If txtTextFilter3.Text <> "" Then
            Text3Filter = " AND (ShortDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%' OR ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter3.Text) + "%')"
        Else
            Text3Filter = ""
        End If
        If chkOnHand.Checked = True Then
            ZeroQuantityFilter = " AND QuantityOnHand <> '0'"
        Else
            ZeroQuantityFilter = ""
        End If
        If chkShipped.Checked = True Then
            ZeroShippedFilter = " AND TotalQuantityShipped <> '0'"
        Else
            ZeroShippedFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = @DivisionID" + PartFilter + ItemClassFilter + Text1Filter + Text2Filter + Text3Filter + ZeroQuantityFilter + ZeroShippedFilter + " ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ADMInventoryTotal")
        dgvItemList.DataSource = ds.Tables("ADMInventoryTotal")
        cboPartNumberLookup.DataSource = ds.Tables("ADMInventoryTotal")
        con.Close()
        Me.dgvItemList.Columns("MinimumStockColumn").ReadOnly = False
        Me.dgvItemList.Columns("MaximumStockColumn").ReadOnly = False
    End Sub

    Public Sub ClearDataInDatagrid()
        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ADMInventoryTotal")
        dgvItemList.DataSource = ds.Tables("ADMInventoryTotal")
        cboPartNumberLookup.DataSource = ds.Tables("ADMInventoryTotal")
        con.Close()
        Me.dgvItemList.Columns("MinimumStockColumn").ReadOnly = False
        Me.dgvItemList.Columns("MaximumStockColumn").ReadOnly = False
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        LoadPartNumber()
        LoadPartDescription()

        If GlobalMaintenancePartNumber = "" Then
            ClearDataInDatagrid()
        Else
            ShowDataByFilter()
        End If
    End Sub

    Private Sub cmdViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAll.Click
        ShowDataByFilter()
    End Sub



    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearData()
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1

        txtTextFilter.Clear()
        txtTextFilter2.Clear()
        txtTextFilter3.Clear()
        txtMaxFormula.Clear()
        txtMinFormula.Clear()

        chkOnHand.Checked = False
        chkShipped.Checked = False

        cboPartNumber.Focus()
    End Sub

    Private Sub dgvItemList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellValueChanged
        Dim PartNumber As String
        Dim MinQty, MaxQty As Integer
        If Me.dgvItemList.RowCount = 0 Then
            'Skip Update
        Else
            Dim RowIndex As Integer = Me.dgvItemList.CurrentCell.RowIndex

            PartNumber = Me.dgvItemList.Rows(RowIndex).Cells("ItemIDColumn").Value

            Try
                MinQty = Me.dgvItemList.Rows(RowIndex).Cells("MinimumStockColumn").Value
            Catch ex As Exception
                MinQty = 0
            End Try
            Try
                MaxQty = Me.dgvItemList.Rows(RowIndex).Cells("MaximumStockColumn").Value
            Catch ex As Exception
                MaxQty = 0
            End Try

            'Update Item List
            cmd = New SqlCommand("UPDATE ItemList SET MinimumStock = @MinimumStock, MaximumStock = @MaximumStock WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                .Add("@MinimumStock", SqlDbType.VarChar).Value = MinQty
                .Add("@MaximumStock", SqlDbType.VarChar).Value = MaxQty
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub cmdAutoUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoUpdate.Click
        Dim PartNumber As String
        Dim MinQty, MaxQty As Integer
        Dim MaxCalculator, MinCalculator As Double
        Dim YearShippedToDate, MinimumQuantity, MaximumQuantity As Double

        If Val(txtMinFormula.Text) <= 1 Then
            'Do nothing
        Else
            MsgBox("You must enter a decimal value that is less than or equal to 1.", MsgBoxStyle.OkOnly)
            txtMinFormula.Focus()
            Exit Sub
        End If

        If Val(txtMaxFormula.Text) > 0 Then
            'Do nothing
        Else
            MsgBox("You must enter a value that is greater than zero.", MsgBoxStyle.OkOnly)
            txtMaxFormula.Focus()
            Exit Sub
        End If

        For Each Row As DataGridViewRow In dgvItemList.Rows
            Try
                PartNumber = Row.Cells("ItemIDColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                YearShippedToDate = Row.Cells("LastYearShippedToDateColumn").Value
            Catch ex As Exception
                YearShippedToDate = 0
            End Try

            If YearShippedToDate = 0 Then
                'Skip
            Else
                If YearShippedToDate > 0 Then
                    MaxCalculator = Val(txtMaxFormula.Text)
                    MinCalculator = Val(txtMinFormula.Text)

                    'Calculate Min and Max based on Last Years Sales
                    MaximumQuantity = YearShippedToDate / MaxCalculator
                    MinimumQuantity = MaximumQuantity * MinCalculator

                    MinQty = Math.Round(MinimumQuantity, 0)
                    MaxQty = Math.Round(MaximumQuantity, 0)
                Else
                    MinQty = 0
                    MaxQty = 0
                End If

                Try
                    'Update Item List
                    cmd = New SqlCommand("UPDATE ItemList SET MinimumStock = @MinimumStock, MaximumStock = @MaximumStock WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        .Add("@MinimumStock", SqlDbType.VarChar).Value = MinQty
                        .Add("@MaximumStock", SqlDbType.VarChar).Value = MaxQty
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If

            'Clear Variables
            PartNumber = ""
            YearShippedToDate = 0
            MinQty = 0
            MaxQty = 0
            MinCalculator = 0
            MinCalculator = 0
            MaximumQuantity = 0
            MinimumQuantity = 0
        Next

        ShowDataByFilter()
        MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdOpenItemForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenItemForm.Click
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalMaintenancePartDescription = cboPartDescription.Text

        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        ClearData()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintItemMinMax As New PrintItemMinMax
            Dim result = NewPrintItemMinMax.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub
End Class