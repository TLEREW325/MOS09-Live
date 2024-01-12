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
Public Class ViewSteelInventoryValue
    Inherits System.Windows.Forms.Form

    Dim DateFilter, CarbonFilter, SteelSizeFilter, CarbonTypeFilter, ZeroStockFilter, SteelClassFilter As String
    Dim LineRMID As String = ""
    Dim LineCarbon As String = ""
    Dim LineSteelSize As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myadapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewSteelInventoryValueNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSteelCarbon()
        LoadSteelClass()
        LoadSteelSize()

        ClearData()
        ClearDataInDatagrids()
    End Sub

    Public Sub LoadFilteredData()
        'Load raw material data by filters
        If cboCarbon.Text = "" Then
            CarbonFilter = ""
        Else
            CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
        End If
        If cboSteelSize.Text = "" Then
            SteelSizeFilter = ""
        Else
            SteelSizeFilter = " AND SteelSize = '" + cboSteelSize.Text + "'"
        End If
        If cboSteelClass.Text = "" Then
            SteelClassFilter = ""
        Else
            SteelClassFilter = " AND SteelClass = '" + cboSteelClass.Text + "'"
        End If
        If chkAllTypes.Checked = False Then
            CarbonTypeFilter = ""
        Else
            CarbonTypeFilter = " AND Carbon LIKE '%" + cboCarbon.Text + "%'"
        End If

        cmd = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE DivisionID = @DivisionID AND (SteelStatus = 'OPEN' OR CloseDate < @ValueDate)" + CarbonFilter + CarbonTypeFilter + SteelSizeFilter + SteelClassFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@SteelClass", SqlDbType.VarChar).Value = "CLOSED"
        cmd.Parameters.Add("@ValueDate", SqlDbType.VarChar).Value = dtpCostingDate.Value
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RawMaterialsTable")
        dgvRawMaterials.DataSource = ds.Tables("RawMaterialsTable")
        con.Close()
    End Sub

    Public Sub ShowSteelValue()
        cmd = New SqlCommand("SELECT * FROM SteelValuationTable WHERE UserID = @UserID AND CostingDate = @CostingDate ORDER BY RMID", con)
        cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
        cmd.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpCostingDate.Value
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SteelValuationTable")
        dgvSteelValueTable.DataSource = ds4.Tables("SteelValuationTable")
        con.Close()
    End Sub

    Public Sub LoadSteelCarbon()
        cmd = New SqlCommand("SELECT DISTINCT (Carbon) FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY Carbon", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT (SteelSize) FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY SteelSize", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelClass()
        cmd = New SqlCommand("SELECT DISTINCT (SteelClass) FROM RawMaterialsTable ORDER BY SteelClass", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "RawMaterialsTable")
        cboSteelClass.DataSource = ds3.Tables("RawMaterialsTable")
        con.Close()
        cboSteelClass.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ClearDataInDatagrids()

        'Get standard Format Date
        Dim PostingDate As Date = dtpCostingDate.Value
        PostingDate = PostingDate.ToShortDateString

        'Delete data from the value table if same date and user exists.
        cmd = New SqlCommand("DELETE FROM SteelValuationTable WHERE CostingDate = @CostingDate AND UserID = @UserID", con)

        With cmd.Parameters
            .Add("@CostingDate", SqlDbType.VarChar).Value = PostingDate
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '***********************************************************************************
        'Load Raw Material Data By Filters
        LoadFilteredData()
        '***********************************************************************************
        'Get Each Raw Material Data by date and write to Steel Value Table
        For Each LineRow As DataGridViewRow In dgvRawMaterials.Rows
            Try
                LineRMID = LineRow.Cells("RMIDColumnRM").Value
            Catch ex As System.Exception
                LineRMID = ""
            End Try
            Try
                LineCarbon = LineRow.Cells("CarbonColumnRM").Value
            Catch ex As System.Exception
                LineCarbon = ""
            End Try
            Try
                LineSteelSize = LineRow.Cells("SteelSizeColumnRM").Value
            Catch ex As System.Exception
                LineSteelSize = ""
            End Try

            If LineRMID = "" Then
                'Error check on blank RMID
            Else
                'Get QOH from Steel Transaction Table for the specific Date

                'Get Sum of the Adds
                Dim SumOfAdds As Double = 0
                Dim SumOfSubtracts As Double = 0
                Dim TransactionQOH As Double = 0

                Dim SumOfAddsStatement As String = "SELECT SUM(Quantity) FROM SteelTransactionTable WHERE RMID = @RMID AND DivisionID = @DivisionID AND SteelTransactionDate <= @SteelTransactionDate AND TransactionMath = 'ADD'"
                Dim SumOfAddsCommand As New SqlCommand(SumOfAddsStatement, con)
                SumOfAddsCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = LineRMID
                SumOfAddsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                SumOfAddsCommand.Parameters.Add("@SteelTransactionDate", SqlDbType.VarChar).Value = PostingDate

                Dim SumOfSubtractsStatement As String = "SELECT SUM(Quantity) FROM SteelTransactionTable WHERE RMID = @RMID AND DivisionID = @DivisionID AND SteelTransactionDate <= @SteelTransactionDate AND TransactionMath = 'SUBTRACT'"
                Dim SumOfSubtractsCommand As New SqlCommand(SumOfSubtractsStatement, con)
                SumOfSubtractsCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = LineRMID
                SumOfSubtractsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                SumOfSubtractsCommand.Parameters.Add("@SteelTransactionDate", SqlDbType.VarChar).Value = PostingDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumOfAdds = CDbl(SumOfAddsCommand.ExecuteScalar)
                Catch ex As Exception
                    SumOfAdds = 0
                End Try
                Try
                    SumOfSubtracts = CDbl(SumOfSubtractsCommand.ExecuteScalar)
                Catch ex As Exception
                    SumOfSubtracts = 0
                End Try
                con.Close()

                TransactionQOH = SumOfAdds - SumOfSubtracts
                TransactionQOH = Math.Round(TransactionQOH, 2)

                'Skip Entry if TRansaction QOH equals zero
                If TransactionQOH = 0 Then
                    'Skip zero entry
                Else
                    'Get steel cost
                    Dim SteelCost As Double = 0
                    Dim ExtendedSteelCost As Double = SteelModule.GetSteelCosting(LineRMID, TransactionQOH, con, PostingDate, False)
                    ExtendedSteelCost = Math.Round(ExtendedSteelCost, 2)

                    If TransactionQOH < 0 Then
                        SteelCost = ExtendedSteelCost / (TransactionQOH * -1)
                        SteelCost = Math.Round(SteelCost, 4)
                    Else
                        SteelCost = ExtendedSteelCost / TransactionQOH
                        SteelCost = Math.Round(SteelCost, 4)
                    End If

                    If SteelCost < 0 Then
                        SteelCost = SteelCost * -1
                    End If

                    'Insert into database
                    cmd = New SqlCommand("INSERT INTO SteelValuationTable (RMID, SteelCarbon, SteelSize, CostingDate, ValueQuantity, ValueCostPerPound, ValueExtendedCost, PrintDate, UserID) values (@RMID, @SteelCarbon, @SteelSize, @CostingDate, @ValueQuantity, @ValueCostPerPound, @ValueExtendedCost, @PrintDate, @UserID)", con)

                    With cmd.Parameters
                        .Add("@RMID", SqlDbType.VarChar).Value = LineRMID
                        .Add("@SteelCarbon", SqlDbType.VarChar).Value = LineCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = LineSteelSize
                        .Add("@CostingDate", SqlDbType.VarChar).Value = PostingDate
                        .Add("@ValueQuantity", SqlDbType.VarChar).Value = TransactionQOH
                        .Add("@ValueCostPerPound", SqlDbType.VarChar).Value = SteelCost
                        .Add("@ValueExtendedCost", SqlDbType.VarChar).Value = ExtendedSteelCost
                        .Add("@PrintDate", SqlDbType.VarChar).Value = Now()
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear variables
                    SteelCost = 0
                    ExtendedSteelCost = 0
                    LineRMID = ""
                    LineCarbon = ""
                    LineSteelSize = ""
                    SumOfAdds = 0
                    SumOfSubtracts = 0
                    TransactionQOH = 0
                End If
            End If
        Next

        MsgBox("Steel Calculations done - click OK to load data.", MsgBoxStyle.OkOnly)

        ShowSteelValue()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrids()
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboSteelClass.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        chkAllTypes.Checked = False
        chkOmit.Checked = False

        dtpCostingDate.Value = Now
    End Sub

    Public Sub ClearDataInDatagrids()
        ds = Nothing
        ds4 = Nothing
        Me.dgvRawMaterials.DataSource = Nothing
        Me.dgvSteelValueTable.DataSource = Nothing
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrintListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintListing.Click
        GDS = ds4

        Using NewPrintSteelValuation As New PrintSteelInventoryValue
            Dim Result = NewPrintSteelValuation.ShowDialog()
        End Using
    End Sub
End Class