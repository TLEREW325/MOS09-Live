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
Public Class ProductionScheduling
    Inherits System.Windows.Forms.Form

    Dim ItemClassFilter, FoxFilter, TextFilter As String
    Public ctmMenu As New ContextMenu
    Dim CompletionTasks As New List(Of ProductionCompletion)

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ProductionScheduling2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ctmMenu.MenuItems.Add("Start New Production", AddressOf StartNewProduction_Click)
        ctmMenu.MenuItems(0).Name = "StartNewProduction"

        LoadFOXNumber()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Public Sub ShowDataByFilters()
        Dim ItemGroup As String = ""
        ItemGroup = cboItemClass.Text

        'Define Item Class from combo Box
        Select Case ItemGroup
            Case "CA/SC/DSC"
                ItemClassFilter = " AND (ItemClass = 'TW CA' OR ItemClass = 'TW SC' OR ItemClass = 'TW DS')"
            Case "TP/TT"
                ItemClassFilter = " AND (ItemClass = 'TW TP' OR ItemClass = 'TW TT')"
            Case "CS"
                ItemClassFilter = " AND ItemClass = 'TW CS'"
            Case "NT"
                ItemClassFilter = " AND ItemClass = 'TW NT'"
            Case "PSR"
                ItemClassFilter = " AND ItemClass = 'TW PS'"
            Case "DBA"
                ItemClassFilter = " AND ItemClass = 'TW DB'"
            Case "SWR/HSR"
                ItemClassFilter = " AND (ItemClass = 'TW SWR' OR ItemClass = 'TW HSR')"
            Case "GS"
                ItemClassFilter = " AND ItemClass = 'TW GS'"
            Case "KO"
                ItemClassFilter = " AND ItemClass = 'TW KO'"
            Case "HX"
                ItemClassFilter = " AND ItemClass = 'TW HX'"
            Case "TR/TDR"
                ItemClassFilter = " AND (ItemClass = 'TW TR' OR ItemClass = 'TW TD')"
            Case "Trufit Parts"
                ItemClassFilter = " AND ItemClass = 'Trufit Parts'"
            Case "TWE Parts"
                ItemClassFilter = " AND ItemClass = 'TW WELD PROD'"
            Case "Misc Production"
                ItemClassFilter = " AND (ItemClass = 'TW IT' OR ItemClass = 'TW SH' OR ItemClass = 'TW SK' OR ItemClass = 'TW TF' OR ItemClass = 'TW RA')"
            Case Else
                ItemClassFilter = ""
        End Select
        If cboFOXNumber.Text = "" Then
            FoxFilter = ""
        Else
            FoxFilter = " AND FOXNumber = '" + cboFOXNumber.Text + "'"
        End If
        If txtTextFilter.Text = "" Then
            TextFilter = ""
        Else
            TextFilter = " AND ItemID LIKE '" + txtTextFilter.Text + "%'"
        End If

        cmd = New SqlCommand("SELECT * FROM ProductionSchedulingFinished WHERE DivisionID <> @DivisionID AND ManufactureQuantity > 0" + ItemClassFilter + FoxFilter + TextFilter + " ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ProductionSchedulingFinished")
        dgvProductionScheduling.DataSource = ds.Tables("ProductionSchedulingFinished")
        con.Close()

        LoadFormatting()
        LoadPromiseDate()
        LoadBlanks()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvProductionScheduling.DataSource = Nothing
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable ORDER BY FOXNumber DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "FOXTable")
        cboFOXNumber.DataSource = ds1.Tables("FOXTable")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBlanks()
        Dim RowFoxNumber As Integer = 0
        Dim RowGetBlanks As Integer = 0
        Dim RowDivision As String = ""
        Dim GetMAXProductionNumber As Integer = 0
        Dim GetHeadingStep As Integer = 0
        Dim GetFinishedGoodStep As Integer = 0
        Dim GetHeadingQuantity As Double = 0
        Dim GetFinishedGoodsQuantity As Double = 0
        Dim CalculateBlanks As Double = 0

        'Clear Temp Table
        cmd = New SqlCommand("DELETE FROM FOXTempBlanksTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvProductionScheduling.Rows
            Try
                RowFoxNumber = row.Cells("FOXNumberColumn").Value
            Catch ex As System.Exception
                RowFoxNumber = 0
            End Try
            Try
                RowDivision = row.Cells("DivisionIDColumn").Value
            Catch ex As System.Exception
                RowDivision = ""
            End Try

            'New Way of Calculating Blanks
            Dim GetFinishedStepString As String = "SELECT ProcessStep FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = @ProcessAddFG"
            Dim GetFinishedStepCommand As New SqlCommand(GetFinishedStepString, con)
            GetFinishedStepCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber
            GetFinishedStepCommand.Parameters.Add("@ProcessAddFG", SqlDbType.VarChar).Value = "ADDINVENTORY"

            Dim GetHeadingStepString As String = "SELECT MIN(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG <> @ProcessAddFG AND ProcessStep <> 0"
            Dim GetHeadingStepCommand As New SqlCommand(GetHeadingStepString, con)
            GetHeadingStepCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber
            GetHeadingStepCommand.Parameters.Add("@ProcessAddFG", SqlDbType.VarChar).Value = "ADDINVENTORY"

            Dim GetMAXProductionNumberString As String = "SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber"
            Dim GetMAXProductionNumberCommand As New SqlCommand(GetMAXProductionNumberString, con)
            GetMAXProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetFinishedGoodStep = CInt(GetFinishedStepCommand.ExecuteScalar)
            Catch ex As Exception
                GetFinishedGoodStep = 0
            End Try
            Try
                GetHeadingStep = CInt(GetHeadingStepCommand.ExecuteScalar)
            Catch ex As Exception
                GetHeadingStep = 1
            End Try
            Try
                GetMAXProductionNumber = CInt(GetMAXProductionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetMAXProductionNumber = 0
            End Try
            con.Close()

            'Get Summation of Headed Goods minus Finished Goods
            Dim GetHeadedQuantityString As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND FOXStep = @FOXStep AND ProductionStatus <> 'CLOSED'"
            Dim GetHeadedQuantityCommand As New SqlCommand(GetHeadedQuantityString, con)
            GetHeadedQuantityCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber
            GetHeadedQuantityCommand.Parameters.Add("@ProductionNumber", SqlDbType.VarChar).Value = GetMAXProductionNumber
            GetHeadedQuantityCommand.Parameters.Add("@FOXStep", SqlDbType.VarChar).Value = GetHeadingStep

            Dim GetFinishedQuantityString As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND FOXStep = @FOXStep AND ProductionStatus <> 'CLOSED'"
            Dim GetFinishedQuantityCommand As New SqlCommand(GetFinishedQuantityString, con)
            GetFinishedQuantityCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber
            GetFinishedQuantityCommand.Parameters.Add("@ProductionNumber", SqlDbType.VarChar).Value = GetMAXProductionNumber
            GetFinishedQuantityCommand.Parameters.Add("@FOXStep", SqlDbType.VarChar).Value = GetFinishedGoodStep

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetHeadingQuantity = CDbl(GetHeadedQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                GetHeadingQuantity = 0
            End Try
            Try
                GetFinishedGoodsQuantity = CDbl(GetFinishedQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                GetFinishedGoodsQuantity = 0
            End Try
            con.Close()

            RowGetBlanks = GetHeadingQuantity - GetFinishedGoodsQuantity

            If RowGetBlanks <> 0 Then
                row.Cells("GetBlanksColumn").Value = RowGetBlanks
            End If

            If RowGetBlanks < 0 Then
                row.Cells("ItemIDColumn").Style.ForeColor = Color.Red
            End If

            'Write to temp table
            cmd = New SqlCommand("INSERT INTO FOXTempBlanksTable (FOXNumber, DivisionID, Blanks, LoadDate) values (@FOXNumber, @DivisionID, @Blanks, @LoadDate)", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                .Add("@Blanks", SqlDbType.VarChar).Value = RowGetBlanks
                .Add("@LoadDate", SqlDbType.VarChar).Value = Today()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            RowFoxNumber = 0
            RowDivision = ""
            RowGetBlanks = 0
        Next
    End Sub

    Public Sub NewLoadBlanks()
        Dim RowFoxNumber As Integer = 0
        Dim RowGetBlanks As Integer = 0
        Dim RowDivision As String = ""

        'Clear Temp Table
        cmd = New SqlCommand("DELETE FROM FOXTempBlanksTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataGridViewRow In dgvProductionScheduling.Rows
            Try
                RowFoxNumber = row.Cells("FOXNumberColumn").Value
            Catch ex As System.Exception
                RowFoxNumber = 0
            End Try
            Try
                RowDivision = row.Cells("DivisionIDColumn").Value
            Catch ex As System.Exception
                RowDivision = ""
            End Try

            If con.State = ConnectionState.Closed Then con.Open()
            RowGetBlanks = ProductionAPI.GetWIP(RowFoxNumber, con)
            con.Close()

            If RowGetBlanks <> 0 Then
                row.Cells("GetBlanksColumn").Value = RowGetBlanks
            End If

            If RowGetBlanks < 0 Then
                row.Cells("ItemIDColumn").Style.ForeColor = Color.Red
            End If

            'Write to temp table
            cmd = New SqlCommand("INSERT INTO FOXTempBlanksTable (FOXNumber, DivisionID, Blanks, LoadDate) values (@FOXNumber, @DivisionID, @Blanks, @LoadDate)", con)

            With cmd.Parameters
                .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                .Add("@Blanks", SqlDbType.VarChar).Value = RowGetBlanks
                .Add("@LoadDate", SqlDbType.VarChar).Value = Today()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            RowFoxNumber = 0
            RowDivision = ""
            RowGetBlanks = 0
        Next
    End Sub

    Public Sub LoadPromiseDate()
        Dim RowPartNumber As String = ""
        Dim RowSOQuantity As Integer = 0

        For Each row As DataGridViewRow In dgvProductionScheduling.Rows
            If row.Cells("CommittedQuantityColumn").Value > 0 Then
                Try
                    RowPartNumber = row.Cells("ItemIDColumn").Value
                Catch ex As System.Exception
                    RowPartNumber = ""
                End Try

                Dim GetLeadTime As String = ""

                Dim GetLeadTimeString As String = "SELECT MIN (LeadTimeDate) FROM SalesOrderLineQueryLeadTimes WHERE LineStatus = @LineStatus AND ItemID = @ItemID AND DivisionKey = @DivisionKey AND QuantityOpen > 0"
                Dim GetLeadTimeCommand As New SqlCommand(GetLeadTimeString, con)
                GetLeadTimeCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                GetLeadTimeCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                GetLeadTimeCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TWD"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLeadTime = CStr(GetLeadTimeCommand.ExecuteScalar)
                Catch ex As Exception
                    GetLeadTime = ""
                End Try
                con.Close()

                If GetLeadTime <> "" Then
                    row.Cells("PromiseDateColumn").Value = GetLeadTime
                End If
            End If
        Next
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
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

    Public Sub LoadFormatting()
        Dim SOQuantity, QuantityOnHand As Integer
        Dim SteelQOH, SteelRequired As Double

        For Each row As DataGridViewRow In dgvProductionScheduling.Rows
            Try
                SOQuantity = row.Cells("CommittedQuantityColumn").Value
            Catch ex As System.Exception
                SOQuantity = 0
            End Try
            Try
                QuantityOnHand = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                QuantityOnHand = 0
            End Try
            Try
                SteelQOH = row.Cells("SteelQOHColumn").Value
            Catch ex As System.Exception
                SteelQOH = 0
            End Try
            Try
                SteelRequired = row.Cells("SteelRequiredColumn").Value
            Catch ex As System.Exception
                SteelRequired = 0
            End Try

            If SOQuantity > QuantityOnHand Then
                row.Cells("CommittedQuantityColumn").Style.BackColor = Color.LightBlue
            ElseIf SOQuantity < QuantityOnHand Then
                row.Cells("CommittedQuantityColumn").Style.BackColor = Color.White
            Else
                row.Cells("CommittedQuantityColumn").Style.BackColor = Color.White
            End If

            If SteelRequired > SteelQOH Then
                row.Cells("SteelRequiredColumn").Style.BackColor = Color.LightCoral
            ElseIf SteelRequired < SteelQOH Then
                row.Cells("SteelRequiredColumn").Style.BackColor = Color.White
            Else
                row.Cells("SteelRequiredColumn").Style.BackColor = Color.White
            End If

            row.Cells("ShortDescriptionColumn").Style.BackColor = Color.LightGray
            row.Cells("ItemIDColumn").Style.BackColor = Color.LightGray
        Next
    End Sub

    Public Sub ClearData()
        txtTextFilter.Clear()

        cboFOXNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1

        cboItemClass.Focus()
    End Sub

    Public Sub ClearVariables()
        ItemClassFilter = ""
        FoxFilter = ""
        TextFilter = ""
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvProductionScheduling_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductionScheduling.CellDoubleClick
        If dgvProductionScheduling.Rows.Count <> 0 Then
            Dim RowFOXNumber As Integer = 0
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvProductionScheduling.CurrentCell.RowIndex

            RowFOXNumber = Me.dgvProductionScheduling.Rows(RowIndex).Cells("FOXNumberColumn").Value
            RowDivisionID = Me.dgvProductionScheduling.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalFOXNumber = RowFOXNumber
            GlobalDivisionCode = RowDivisionID
            GlobalProductionWorkOrder = "Production Order"
            GlobalProductionOrderAutoprint = "YES"

            Using NewPrintProductionOrderNew As New PrintProductionOrderNew
                Dim Result = NewPrintProductionOrderNew.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvProductionScheduling_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductionScheduling.CellValueChanged
        'Update Promise Date in the FOX
        If dgvProductionScheduling.Rows.Count <> 0 Then
            Dim RowFOXNumber As Integer = 0
            Dim RowDivisionID As String = ""
            Dim RowPromiseDate As String = ""

            Dim RowIndex As Integer = Me.dgvProductionScheduling.CurrentCell.RowIndex

            RowFOXNumber = Me.dgvProductionScheduling.Rows(RowIndex).Cells("FOXNumberColumn").Value
            RowDivisionID = Me.dgvProductionScheduling.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Try
                RowPromiseDate = Me.dgvProductionScheduling.Rows(RowIndex).Cells("FOXPromiseDateColumn").Value
            Catch ex As Exception
                RowPromiseDate = "01/01/2016"
            End Try

            If RowFOXNumber <> 0 Then
                Try
                    'Update FOX Table
                    cmd = New SqlCommand("UPDATE FOXTable SET PromiseDate = @PromiseDate WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        .Add("@PromiseDate", SqlDbType.VarChar).Value = RowPromiseDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    Dim ErrorDate As String = Now()
                    Dim ErrorDescription As String = "Production Scheduling - Update FOX Promise Date"
                    Dim ErrorUser As String = EmployeeLoginName
                    Dim ErrorComment As String = ex.ToString
                    Dim ErrorDivision As String = EmployeeCompanyCode
                    Dim ErrorReferenceNumber As String = RowFOXNumber

                    TFPErrorLogUpdate()
                End Try
            End If
        End If
    End Sub

    Private Sub dgvProductionScheduling_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProductionScheduling.ColumnHeaderMouseClick
        LoadFormatting()
        LoadPromiseDate()
        LoadBlanks()
    End Sub

    Private Sub dgvProductionScheduling_ColumnSortModeChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvProductionScheduling.ColumnSortModeChanged
        LoadFormatting()
        LoadPromiseDate()
        LoadBlanks()
    End Sub

    Private Sub cmdPrintWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintWorkOrder.Click
        If dgvProductionScheduling.Rows.Count <> 0 Then
            Dim RowFOXNumber As Integer = 0
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvProductionScheduling.CurrentCell.RowIndex

            RowFOXNumber = Me.dgvProductionScheduling.Rows(RowIndex).Cells("FOXNumberColumn").Value
            RowDivisionID = Me.dgvProductionScheduling.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalFOXNumber = RowFOXNumber
            GlobalDivisionCode = RowDivisionID
            GlobalProductionWorkOrder = "Production Order"
            GlobalProductionOrderAutoprint = "YES"

            Using NewPrintProductionOrderNew As New PrintProductionOrderNew
                Dim Result = NewPrintProductionOrderNew.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdProductionOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProductionOrder.Click
        If dgvProductionScheduling.Rows.Count <> 0 Then
            Dim RowFOXNumber As Integer = 0
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvProductionScheduling.CurrentCell.RowIndex

            RowFOXNumber = Me.dgvProductionScheduling.Rows(RowIndex).Cells("FOXNumberColumn").Value
            RowDivisionID = Me.dgvProductionScheduling.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalFOXNumber = RowFOXNumber
            GlobalDivisionCode = RowDivisionID
            GlobalProductionWorkOrder = "Work Order"
            GlobalProductionOrderAutoprint = "YES"

            Using NewPrintProductionOrderNew As New PrintProductionOrderNew
                Dim Result = NewPrintProductionOrderNew.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdViewProductionOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewProductionOrder.Click
        If dgvProductionScheduling.Rows.Count <> 0 Then
            Dim RowFOXNumber As Integer = 0
            Dim RowDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvProductionScheduling.CurrentCell.RowIndex

            RowFOXNumber = Me.dgvProductionScheduling.Rows(RowIndex).Cells("FOXNumberColumn").Value
            RowDivisionID = Me.dgvProductionScheduling.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalFOXNumber = RowFOXNumber
            GlobalDivisionCode = RowDivisionID
            GlobalProductionWorkOrder = "Work Order"
            GlobalProductionOrderAutoprint = "NO"

            Using NewPrintProductionOrderNew As New PrintProductionOrderNew
                Dim Result = NewPrintProductionOrderNew.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdClearFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFilters.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintProductionScheduling As New PrintProductionSchedulingList2
            Dim Result = NewPrintProductionScheduling.ShowDialog()
        End Using

        '***********************************************************************************
        '***********************************************************************************

        'Convert to Excel Doc and autoprint








    End Sub

    Private Sub StartNewProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RowFoxNumber As Integer = 0
        Dim RowIndex As Integer = Me.dgvProductionScheduling.CurrentCell.RowIndex

        RowFoxNumber = Me.dgvProductionScheduling.Rows(RowIndex).Cells("FOXNumberColumn").Value
        'Get Production Number from the FOX
        Dim GetProductionNumber As Integer = 0

        Dim GetProductionNumberString As String = "SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = @Status"
        Dim GetProductionNumberCommand As New SqlCommand(GetProductionNumberString, con)
        GetProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFoxNumber
        GetProductionNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetProductionNumber = CInt(GetProductionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetProductionNumber = 0
        End Try
        con.Close()

        Dim newProducitonQuantity As Integer = GenerateNewProductionQuantityByFOX(RowFoxNumber, con)
        Dim newProductionNumber As String = ProductionAPI.StartNewProduction(GetProductionNumber, RowFoxNumber, newProducitonQuantity)
        ''check to see if there was a new production number genereated
        If Not newProductionNumber.Equals("0") Then
            ''starts the old production run completion process for Accounting.
            CompletionTasks.Add(New ProductionCompletion(GetProductionNumber, RowFoxNumber, True))
            'ProductionAPI.LoadSingleFOXProductionData(New WIPDataPassed(dgvProductionData, RowFoxNumber, pnlNoWIPData, True))
            MessageBox.Show("New production has been created.", "New Production success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ShowDataByFilters()
        Else
            MessageBox.Show("There was a problem creating the new production number, contact system admin.", "Unable to create new production number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvProductionScheduling_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvProductionScheduling.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo = dgvProductionScheduling.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                dgvProductionScheduling.SelectedCells(0).Selected = False
                dgvProductionScheduling.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                dgvProductionScheduling.CurrentCell = dgvProductionScheduling.Rows(ht.RowIndex).Cells(ht.ColumnIndex)
                'If ht.RowIndex <> -1 Then
                '    If dgvProductionScheduling.Rows(ht.RowIndex).Cells("ProductionNumber").Value = 0 Then
                '        ctmMenu.MenuItems("UpdateProductionQuantity").Enabled = False
                '    Else
                '        ctmMenu.MenuItems("UpdateProductionQuantity").Enabled = True
                '    End If
                'End If

                ctmMenu.Show(dgvProductionScheduling, New System.Drawing.Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub PrintWorkOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintWorkOrderToolStripMenuItem1.Click
        cmdPrintWorkOrder_Click(sender, e)
    End Sub

    Private Sub PrintProductionOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintProductionOrderToolStripMenuItem.Click
        cmdProductionOrder_Click(sender, e)
    End Sub

    Private Sub ViewProductionOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewProductionOrderToolStripMenuItem1.Click
        cmdViewProductionOrder_Click(sender, e)
    End Sub

End Class