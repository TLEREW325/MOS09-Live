Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Module ProductionAPI
    Private Const ConstLaborCost As Double = 28.0
    ''Holds the Labor/Machine cost
    Public Structure LaborMachineCost
        Public LaborCost As Double
        Public MachineCost As Double
    End Structure
    ''hold the data for WIP
    Public Structure WIPParameter
        Public ColumnName As String
        Public sign As String
        Public Value As Object
    End Structure
    ''Hold the FOX Sched Data
    Public Class FOXStep
        Public ProcessStep As Integer
        Public ProcessAddFG As String
        Public Sub New(ByVal procStep As Integer, ByVal AddFG As String)
            ProcessStep = procStep
            ProcessAddFG = AddFG
        End Sub
    End Class
    ''small class to handle the WIP data
    Public Class WIPDataPassed
        Public dgv As DataGridView
        Public PartNumber As String
        Public PartNumbers As List(Of String)
        Public FOXNumbers As List(Of String)
        Public FOXNumber As String
        Public pnl As Panel
        Public Sub New()
        End Sub
        ''' <summary>
        ''' Create a new instance of the production API.
        ''' </summary>
        ''' <param name="datgv">DataGridView for the final result.</param>
        ''' <param name="lst">List of either part numbers or FOXs</param>
        ''' <param name="pan">ASYNC panel for UI to the user.</param>
        ''' <param name="isPartNumbers">True if part numbers from source.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal datgv As DataGridView, ByVal lst As List(Of String), Optional ByVal pan As Panel = Nothing, Optional ByVal isPartNumbers As Boolean = True)
            dgv = datgv
            If isPartNumbers Then
                PartNumbers = lst
            Else
                FOXNumbers = lst
            End If

            If pan IsNot Nothing Then
                pnl = pan
            End If
        End Sub
        ''' <summary>
        ''' Create a new instance of the production API.
        ''' </summary>
        ''' <param name="datgv">DataGridView for the final result</param>
        ''' <param name="par">Part number of FOX</param>
        ''' <param name="pan">ASYNC panel for UI to the user.</param>
        ''' <param name="isFOXNumber">True if FOX from source.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal datgv As DataGridView, ByVal par As String, Optional ByVal pan As Panel = Nothing, Optional ByVal isFOXNumber As Boolean = False)
            dgv = datgv
            If isFOXNumber Then
                FOXNumber = par
                PartNumber = Nothing
            Else
                PartNumber = par
                FOXNumber = Nothing
            End If

            If pan IsNot Nothing Then
                pnl = pan
            End If
        End Sub
    End Class

    ''This is for closing an existing Production run and then creating a new production run.
    Public Function StartNewProduction(ByVal CurrentProductionNumber As Integer, ByVal FOXNumber As Integer, ByVal NewProductionQuantity As Integer) As Integer
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=120")
        Dim cmd As New SqlCommand("", con)
        ''checks to see if there was a passed production number, of not this will skip the update portion and just genereate a new production number
        If CurrentProductionNumber <> 0 Then
            cmd.CommandText = "UPDATE FOXProductionNumberHeaderTable SET Status = 'CLOSED', EndDate = @StartDate WHERE ProductionNumber = @OldProductionNumber AND FOXNumber = @FOXNumber AND Status = 'OPEN'; DECLARE @DivisionID as Varchar(50) = (SELECT TOP 1 DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber); DECLARE @NewProductionNumber as int = CASE WHEN (EXISTS(SELECT isnull(MAX(ProductionNumber), 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) AND @DivisionID = 'TWD') THEN (SELECT isnull(MAX(ProductionNumber) + 1, 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) ELSE (SELECT 80316) END; IF NOT EXISTS(SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE ProductionNumber = @NewProductionNumber AND FOXNumber = @FOXNumber) BEGIN INSERT INTO FOXProductionNumberHeaderTable( ProductionNumber, FOXnumber, StartDate, ProductionQuantity, Status) VALUES (@NewProductionNumber, @FOXNumber, @StartDate, @ProductionQuantity, 'OPEN'); INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) SELECT @NewProductionNumber, @FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FoxSched WHERE FOXNumber = @FOXnumber; END ELSE BEGIN IF @DivisionID = 'TFP' UPDATE FOXProductionNumberHeaderTable SET Status = 'OPEN' WHERE ProductionNumber = @NewProductionNumber AND FOXNumber = @FOXNumber; END SELECT @NewProductionNumber;"
        Else
            cmd.CommandText = "DECLARE @DivisionID as Varchar(50) = (SELECT TOP 1 DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber); DECLARE @NewProductionNumber as int = CASE WHEN (EXISTS(SELECT isnull(MAX(ProductionNumber), 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) AND @DivisionID = 'TWD') THEN (SELECT isnull(MAX(ProductionNumber) + 1, 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) ELSE (SELECT 80316) END; IF NOT EXISTS(SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE ProductionNumber = @NewProductionNumber AND FOXNumber = @FOXNumber) BEGIN INSERT INTO FOXProductionNumberHeaderTable( ProductionNumber, FOXnumber, StartDate, ProductionQuantity, Status) VALUES (@NewProductionNumber, @FOXNumber, @StartDate, @ProductionQuantity, 'OPEN'); INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) SELECT @NewProductionNumber, @FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FoxSched WHERE FOXNumber = @FOXnumber; END ELSE BEGIN IF @DivisionID = 'TFP' UPDATE FOXProductionNumberHeaderTable SET Status = 'OPEN' WHERE ProductionNumber = @NewProductionNumber AND FOXNumber = @FOXNumber; END SELECT @NewProductionNumber;"
        End If
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = FOXNumber
        cmd.Parameters.Add("@OldProductionNumber", SqlDbType.Int).Value = CurrentProductionNumber
        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Now
        cmd.Parameters.Add("@ProductionQuantity", SqlDbType.Int).Value = NewProductionQuantity

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()

        If Not IsDBNull(obj) And obj IsNot Nothing Then
            Return obj.ToString()
        Else
            Return "0"
        End If
    End Function

    ''' <summary>
    ''' handles getting Labor and machine cost for a given Machine (Note: A SQL Connection is required to be passed)
    ''' </summary>
    ''' <param name="machine">Maching Number</param>
    ''' <param name="hours">Hours</param>
    ''' <param name="con">SQL Connection</param>
    ''' <returns>Labor and machine costing</returns>
    ''' <remarks></remarks>
    Public Function GetLaborMachineCosting(ByVal machine As String, ByVal hours As Double, ByVal con As SqlConnection) As LaborMachineCost
        Dim MachineCost As Double = 0
        Dim cmd As New SqlCommand("SELECT MachineCostPerHour WHERE MachineID = @MachineID AND DivisionID = 'TWD'", con)
        cmd.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = machine

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If Not IsDBNull(obj) And obj IsNot Nothing Then
            MachineCost = obj
        End If
        Dim temp As New LaborMachineCost
        temp.MachineCost = MachineCost * hours
        temp.LaborCost = hours * ConstLaborCost
        Return temp
    End Function

    ''' <summary>
    ''' gets the blanks for the passed FOX (Note: SQL Connection is required to be passed)
    ''' </summary>
    ''' <param name="FOXNumber">FOX</param>
    ''' <param name="con">SQL Connection</param>
    ''' <returns>How namy pieces were headed.</returns>
    ''' <remarks></remarks>
    Public Function GetBlanks(ByVal FOXNumber As Integer, ByVal con As SqlConnection) As Integer
        Dim blanks As Integer = 0
        '''AndAlso CType(obj, Integer) > 0
        Dim cmd As New SqlCommand("DECLARE @ProductionNumber as int = (SELECT TOP 1 isnull(MAX(ProductionNumber), 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber);" _
                                  + " SELECT isnull(SUM((CASE WHEN TimeSlipLineItemTable.InventoryPieces > 0 THEN 0 ELSE TimeSlipLineItemTable.PiecesProduced END) - TimeSlipLineItemTable.InventoryPieces), 0) as TotalBlanks FROM" _
                                  + " (SELECT TimeSlipCombinedData.TimeSlipKey, TimeslipCombinedData.FOXNumber, case when ProcessAddFG = 'ADDINVENTORY' then 0 else PiecesProduced end as PiecesProduced, FOXStep, ProcessAddFG FROM TimeSlipCombinedData LEFT OUTER JOIN (SELECT ProcessAddFG, ProcessStep FROM FoxSched WHERE ProcessStep = 1 and FOXNumber = @FOXNumber) as FOXSched ON TimeSlipCombinedData.FOXStep = FoxSched.ProcessStep WHERE TimeSlipCombinedData.FOXNumber = @FOXNumber and FOXStep = 1 AND InventoryPieces = 0 AND ProductionNumber = @ProductionNumber GROUP BY TimeSlipCombinedData.TimeSlipKey,TimeSlipCombinedData.FOXNumber, FOXStep, ProcessAddFG, PiecesProduced UNION ALL (SELECT TimeSlipCombinedData.TimeSlipKey, TimeslipCombinedData.FOXNumber, (-1 * PiecesProduced) as PiecesProduced, FOXStep, ProcessAddFG FROM TimeSlipCombinedData LEFT OUTER JOIN (SELECT ProcessAddFG, ProcessStep FROM FoxSched WHERE ProcessStep = 2 and FOXNumber = @FOXNumber) as FOXSched ON TimeSlipCombinedData.FOXStep = FoxSched.ProcessStep WHERE TimeSlipCombinedData.FOXNumber = @FOXNumber and FOXStep = 2 AND ProductionNumber = @ProductionNumber GROUP BY TimeSlipCombinedData.TimeSlipKey,TimeSlipCombinedData.FOXNumber, FOXStep, ProcessAddFG, PiecesProduced)) as Steps", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = FOXNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If obj IsNot Nothing AndAlso CType(obj, Integer) > 0 Then
            blanks = CType(obj, Integer)
        End If
        Return blanks
    End Function

    ''' <summary>
    ''' gets the blanks for the passed FOX (Note: SQL Connection is required to be passed)
    ''' </summary>
    ''' <param name="FOXNumber">FOX</param>
    ''' <param name="con">SQL Connection</param>
    ''' <returns>Total number of pieces in WIP</returns>
    ''' <remarks></remarks>
    Public Function GetWIP(ByVal FOXNumber As Integer, ByVal con As SqlConnection) As Integer
        Dim blanks As Integer = 0
        '''AndAlso CType(obj, Integer) > 0 
        Dim cmd As New SqlCommand("SELECT isnull(SUM((CASE WHEN TimeSlipLineItemTable.InventoryPieces <> 0 THEN 0 ELSE TimeSlipLineItemTable.PiecesProduced END) - TimeSlipLineItemTable.InventoryPieces), 0) as TotalBlanks FROM TimeSlipLineItemTable" _
                                  + " INNER JOIN TimeSlipHeaderTable ON TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey" _
                                  + " INNER JOIN FOXProductionNumberHeaderTable ON TimeSlipLineItemTable.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND TimeSlipLineItemTable.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber" _
                                  + " LEFT OUTER JOIN FOXProductionNumberSched ON TimeSlipLineItemTable.ProductionNumber = FOXProductionNumberSched.ProductionNumber AND TimeSlipLineItemTable.FOXNumber = FOXProductionNumberSched.FOXNumber AND TimeSlipLineItemTable.FOXStep = FOXProductionNumberSched.ProcessStep" _
                                  + " WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber AND TimeSlipHeaderTable.Status = 'POSTED' AND FOXProductionNumberHeaderTable.Status = 'OPEN' AND TimeSlipLineItemTable.LineKey < 100 AND (TimeSlipLineItemTable.FOXStep = 1 OR FOXProductionNumberSched.ProcessAddFG = 'ADDINVENTORY' OR TimeSlipLineItemTable.InventoryPieces <> 0)", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = FOXNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If obj IsNot Nothing AndAlso CType(obj, Integer) > 0 Then
            blanks = CType(obj, Integer)
        End If
        Return blanks
    End Function

    ''' <summary>
    ''' Gets a dataset containing all the production data for the FOX provided
    ''' </summary>
    ''' <param name="FOXNumber">FOX</param>
    ''' <param name="ds">Dataset for which to get production data</param>
    ''' <returns>True if not errored and FOX is setup properly.</returns>
    ''' <remarks></remarks>
    Public Function GetProductionOrderDataSet(ByVal FOXNumber As String, ByRef ds As DataSet) As Boolean
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 As SqlCommand
        Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myadapter7, myadapter8 As New SqlDataAdapter
        'Loads data into dataset for viewing
        cmd1 = New SqlCommand("SELECT FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, Status, Case WHEN EXISTS(SELECT TOP 1 ShortDescription FROM ItemList WHERE ItemID = (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber)) THEN (SELECT TOP 1 ShortDescription FROM ItemList WHERE ItemID = (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber)) ELSE (SELECT TOP 1 ShortDescription FROM ItemList WHERE ItemID = (SELECT ItemID FROM BoxType WHERE BoxTypeID = (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber))) END as BoxType, CustomerID, PromiseDate, OrderReferenceNumber, BlueprintRevision, Locked, QuoteNumber, QuotePrice, ScheduledRMID FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

        cmd2 = New SqlCommand("SELECT * FROM ItemList RIGHT OUTER JOIN (SELECT PartNumber, DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber) as FOXTable ON ItemList.ItemID = FOXTable.PartNumber AND ItemList.DivisionID = FOXTable.DivisionID", con)
        cmd2.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

        ''cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE RMID = (SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber) UNION ALL SELECT * FROM RawMaterialsTable WHERE RMID = (SELECT ScheduledRMID FROM FOXTable WHERE FOXNumber = @FOXNumber)", con)
        cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE RMID = (SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber)", con)
        cmd3.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
        ''TimeSlipCombinedData
        cmd4 = New SqlCommand("SELECT FOXNumber, '' as LineKey, ProcessID as MachineNumber, isnull(TotalPieces, 0) as PiecesProduced, MachineTable.Description as PartNumber, ProcessAddFG, MachineTable.MachineClass  FROM (SELECT FOXProductionNumberSched.FOXNumber, isnull(FOXStep, ProcessStep) as FOXStep, ProcessID, isnull(SUM(PiecesProduced), 0) as TotalPieces, ProcessAddFG FROM TimeSlipCombinedData RIGHT OUTER JOIN FOXProductionNumberSched ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberSched.FOXNumber and TimeSlipCombinedData.ProductionNumber = FOXProductionNumberSched.ProductionNumber AND TimeSlipCombinedData.FOXStep = FOXProductionNumberSched.ProcessStep WHERE FOXProductionNumberSched.FOXNumber = @FOXNumber and FOXProductionNumberSched.ProductionNumber in (SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') GROUP BY FOXProductionNumberSched.FOXNumber, FOXStep, ProcessStep, ProcessID, ProcessAddFG) as TimeProdComb LEFT OUTER JOIN MachineTable ON TimeProdComb.ProcessID = MachineTable.MachineID ORDER BY FOXStep ASC", con)
        cmd4.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
        ''ADMInventoryTotal
        cmd6 = New SqlCommand("SELECT ADMInventoryTotal.MaximumStock, ADMInventoryTotal.QuantityOnHand, ADMInventoryTotal.OpenSOQuantity, (SELECT TOP 1 ProductionQuantity FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') as ProductionQuantity FROM ADMInventoryTotal RIGHT OUTER JOIN (SELECT PartNumber, DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber) as FOXTable ON ADMInventoryTotal.ItemID = FOXTable.PartNumber AND ADMInventoryTotal.DivisionID = FOXTable.DivisionID", con)
        cmd6.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

        myAdapter1.SelectCommand = cmd1
        myAdapter2.SelectCommand = cmd2
        myAdapter3.SelectCommand = cmd3
        myAdapter4.SelectCommand = cmd4
        myAdapter6.SelectCommand = cmd6

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds, "FOXTable")
        myAdapter2.Fill(ds, "ItemList")
        myAdapter3.Fill(ds, "RawMaterialsTable")
        myAdapter4.Fill(ds, "TimeSlipCombinedData")

        If ds.Tables("TimeSlipCombinedData").Rows.Count = 0 Then
            cmd4 = New SqlCommand("SELECT COUNT(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status <> 'CLOSED'", con)
            cmd4.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
            If cmd4.ExecuteScalar() = 0 Then
                MessageBox.Show("There is not active Production Number, unable to print.", "Unable to print", MessageBoxButtons.OK, MessageBoxIcon.Question)
                con.Close()
                Return False
            Else
                If MessageBox.Show("There are no steps for this FOX. Do you still wish to print?", "Unable to print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    con.Close()
                    Return False
                End If
            End If
        End If
        Dim HeadedAmount As Double = 0

        ''gets the sales order data for TFP, since the production quantity is based on the sales order amount.
        If ds.Tables("FOXTable").Rows(0).Item("DivisionID") = "TFP" Then
            ''only FOR TFP FOXES
            cmd5 = New SqlCommand("SELECT TOP 1 * FROM SalesOrderQuantityStatus WHERE LineStatus = 'OPEN' AND SalesOrderKey = (SELECT OrderReferenceNumber FROM FOXTable WHERE FOXNumber = @FOXNumber) ORDER BY SalesOrderDate DESC", con)
            cmd5.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
            ''SalesOrderHeaderTable
            cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE SalesOrderKey = (SELECT OrderReferenceNumber FROM FOXTable WHERE FOXNumber = @FOXNumber)", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
            ''CustomerList
            cmd7 = New SqlCommand("SELECT * FROM CustomerList WHERE CustomerID = (SELECT CustomerID FROM FOXTable WHERE FOXNumber = @FOXNumber)", con)
            cmd7.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
            ''FOXReleaseSchedule
            cmd8 = New SqlCommand("IF EXISTS(SELECT TOP 1 FOXNumber, ReleaseDate FROM FOXReleaseSchedule WHERE FOXNumber = @FOXNumber AND Status <> 'SHIPPED' ORDER BY ReleaseDate ASC) SELECT TOP 1 FOXNumber, ReleaseDate FROM FOXReleaseSchedule WHERE FOXNumber = @FOXNumber AND Status <> 'SHIPPED' ORDER BY ReleaseDate ASC ELSE SELECT FOXNumber, PromiseDate as ReleaseDate FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd8.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

            myAdapter5.SelectCommand = cmd5
            myAdapter.SelectCommand = cmd
            myadapter7.SelectCommand = cmd7
            myadapter8.SelectCommand = cmd8

            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter5.Fill(ds, "SalesOrderQuantityStatus")
            myAdapter.Fill(ds, "SalesOrderHeaderTable")
            myadapter7.Fill(ds, "CustomerList")
            myadapter8.Fill(ds, "FOXReleaseSchedule")

            cmd6 = New SqlCommand("SELECT SalesOrderQuantityStatus.Description, SalesorderQuantityStatus.ItemID, FOXTable.FOXNumber, CustomerList.CustomerName, ADMInventoryTotal.QuantityOnHand, FOXTable.MinimumStock, FOXTable.MaximumStock, SalesOrderQuantityStatus.QuantityOrdered * 1.1 - SalesOrderQuantityStatus.QuantityShipped as QuantityOpen, (SELECT TOP 1 ProductionQuantity FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') as ProductionQuantity, SalesOrderQuantityStatus.SalesOrderDate as [Oldest Date], SalesOrderQuantityStatus.SalesOrderKey as SONumber FROM SalesOrderQuantityStatus RIGHT OUTER JOIN (SELECT FOXTable.FOXNumber, FOXTable.OrderReferenceNumber, ItemList.MaximumStock, ItemList.MinimumStock, ItemList.ItemClass FROM FOXTable LEFT OUTER JOIN ItemList on FOXTable.DivisionID = ItemList.DivisionID and FOXTable.PartNumber = ItemList.ItemID WHERE FOXTable.DivisionID = 'TFP' and FOXTable.Status <> 'INACTIVE') as FOXTable ON SalesOrderQuantityStatus.SalesOrderKey = FOXTable.OrderReferenceNumber LEFT OUTER JOIN ADMInventoryTotal on SalesOrderQuantityStatus.ItemID = ADMInventoryTotal.ItemID and ADMInventoryTotal.DivisionID = SalesOrderQuantityStatus.DivisionKey LEFT OUTER JOIN (SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = 'TFP') as CustomerList ON SalesOrderQuantityStatus.CustomerID = CustomerList.CustomerID  WHERE SalesOrderQuantityStatus.DivisionKey = 'TFP' and SalesOrderQuantityStatus.LineStatus = 'OPEN' AND SalesorderQuantityStatus.ItemID = @ItemID and SalesOrderQuantityStatus.QuantityOpen > 0 and FOXTable.ItemClass = 'Trufit Parts' ORDER BY SalesOrderQuantityStatus.ItemID, [Oldest Date], FOXTable.FOXNumber", con)
            cmd6.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ds.Tables("FOXTable").Rows(0).Item("PartNumber")
            cmd6.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
            myAdapter6.SelectCommand = cmd6
            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter6.Fill(ds, "ADMInventoryTotal")
            con.Close()
            ''check to see if there was any data pulled from a sales order, if not will give user message and exit.
            If ds.Tables("ADMInventoryTotal").Rows.Count = 0 Then
                MessageBox.Show("There are no active Sales Orders. Have Sales check to make sure the Sales Order exists and is not closed.", "Unable to continue", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            Dim qty As Double = ds.Tables("ADMInventoryTotal").Rows(0).Item("QuantityOnHand")
            Dim i As Integer = 0
            ''Combines all the sales order quantities to one line and then will remove un-needed lines, as long as they are pointing to the same FOX number.
            While i < ds.Tables("ADMInventoryTotal").Rows.Count
                If qty > 0 Then
                    If qty > ds.Tables("ADMInventoryTotal").Rows(i).Item("QuantityOpen") Then
                        qty = qty - ds.Tables("ADMInventoryTotal").Rows(i).Item("QuantityOpen")
                        If ds.Tables("ADMInventoryTotal").Rows(i).Item("FOXNumber") <> FOXNumber Then
                            ds.Tables("ADMInventoryTotal").Rows.RemoveAt(i)
                        Else
                            i += 1
                        End If
                    ElseIf qty < ds.Tables("ADMInventoryTotal").Rows(i).Item("QuantityOpen") Then
                        'ds.Tables("ADMInventoryTotal").Rows(i).Item("ProductionQuantity") -= qty
                        ds.Tables("ADMInventoryTotal").Rows(i).Item("QuantityOnHand") = 0
                        qty = 0
                        If ds.Tables("ADMInventoryTotal").Rows(i).Item("FOXNumber") <> FOXNumber Then
                            ds.Tables("ADMInventoryTotal").Rows.RemoveAt(i)
                        Else
                            i += 1
                        End If
                    Else
                        If ds.Tables("ADMInventoryTotal").Rows(i).Item("FOXNumber") <> FOXNumber Then
                            ds.Tables("ADMInventoryTotal").Rows.RemoveAt(i)
                        Else
                            i += 1
                        End If
                    End If
                Else
                    ds.Tables("ADMInventoryTotal").Rows(i).Item("QuantityOnHand") = 0
                    If ds.Tables("ADMInventoryTotal").Rows(i).Item("FOXNumber") <> FOXNumber Then
                        ds.Tables("ADMInventoryTotal").Rows.RemoveAt(i)
                    Else
                        i += 1
                    End If
                End If
            End While
            Dim FGAmount As Double = 0
            For j As Integer = ds.Tables("TimeSlipCombinedData").Rows.Count - 1 To 0 Step -1
                If ds.Tables("TimeSlipCombinedData").Rows(j).Item("ProcessAddFG").Equals("ADDINVENTORY") Then
                    FGAmount = ds.Tables("TimeSlipCombinedData").Rows(j).Item("PiecesProduced")
                ElseIf ds.Tables("TimeSlipCombinedData").Rows(j).Item("MachineClass").Equals("HDR") Then
                    HeadedAmount = ds.Tables("TimeSlipCombinedData").Rows(j).Item("PiecesProduced") - FGAmount
                End If
                ds.Tables("TimeSlipCombinedData").Rows(j).Item("PiecesProduced") -= FGAmount
                If ds.Tables("TimeSlipCombinedData").Rows(j).Item("PiecesProduced") < 0 Then
                    ds.Tables("TimeSlipCombinedData").Rows(j).Item("PiecesProduced") = 0
                End If
            Next
        Else
            Dim FGAmount As Double = 0
            For i As Integer = ds.Tables("TimeSlipCombinedData").Rows.Count - 1 To 0 Step -1
                If ds.Tables("TimeSlipCombinedData").Rows(i).Item("ProcessAddFG").Equals("ADDINVENTORY") Then
                    FGAmount = ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")
                ElseIf ds.Tables("TimeSlipCombinedData").Rows(i).Item("MachineClass").Equals("HDR") Then
                    HeadedAmount = ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") - FGAmount
                End If
                ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") -= FGAmount
            Next

            myAdapter6.Fill(ds, "ADMInventoryTotal")
            con.Close()
            'If ds.Tables("ADMInventoryTotal").Rows.Count <> 0 Then
            '    If ds.Tables("ADMInventoryTotal").Rows(0).Item("ProductionQuantity").Equals(0) Then

            '    End If
            'End If
        End If
        ''Adjusts the FOX steps for the parts that have been produced already, if any have been produced
        If ds.Tables("ADMInventoryTotal").Rows.Count <> 0 Then
            Dim ProductionQty As Double = ds.Tables("ADMInventoryTotal").Rows(0).Item("ProductionQuantity")
            If ProductionQty <= 0 Then
                If HeadedAmount < 0 Then
                    ds.Tables("ADMInventoryTotal").Rows(0).Item("ProductionQuantity") = 0
                Else
                    ds.Tables("ADMInventoryTotal").Rows(0).Item("ProductionQuantity") = HeadedAmount
                End If

                For i As Integer = 0 To ds.Tables("TimeSlipCombinedData").Rows.Count - 1
                    Dim remainder As Double = HeadedAmount - ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")
                    If remainder < 0 Then
                        ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") = 0
                    Else
                        ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") = remainder
                    End If
                Next
            Else
                For i As Integer = 0 To ds.Tables("TimeSlipCombinedData").Rows.Count - 1
                    Dim remainder As Double = ds.Tables("ADMInventoryTotal").Rows(0).Item("ProductionQuantity") - ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")
                    If remainder < 0 Then

                        ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") = 0
                    Else
                        ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") = remainder
                    End If
                Next
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' Gets the FOX Production data for the passed either PartNumber of FOX Number
    ''' </summary>
    ''' <param name="WIPData"></param>
    ''' <remarks></remarks>
    Public Sub LoadSingleFOXProductionData(ByRef WIPData As WIPDataPassed)
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("DECLARE @FOXNumber as int = (SELECT TOP 1 FOXNumber FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')); DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT PostingDate, MachineNumber, SUM(TotalHours) as TotalHours, FOXStep, SUM(PiecesProduced) as TotalPieces, ProcessAddFG FROM (SELECT TimeSlipKey, TimeSlipLineItemTable.FOXNumber, MachineNumber, TotalHours, FOXStep, PiecesProduced, LineKey, TimeSlipLineItemTable.ProductionNumber FROM TimeSlipLineItemTable INNER JOIN (SELECT ProductionNumber, FOXNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') as FOXProductionNumberHeaderTable ON TimeSlipLineItemTable.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND TimeSlipLineItemTable.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber) as TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable On TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN FoxProductionNumberSched ON TimeSlipLineItemTable.FOXNumber = FoxProductionNumberSched.FOXNumber and TimeSlipLineItemTable.FOXStep = FoxProductionNumberSched.ProcessStep WHERE LineKey < 100 and FOXStep <= @FGStep GROUP BY  FOXStep, PostingDate, MachineNumber, TotalHours, ProcessAddFG ORDER BY FOXStep, PostingDate ASC", con)
        Dim cmd1 As New SqlCommand("DECLARE @FOXNumber as int = (SELECT TOP 1 FOXNumber FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')); DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT ProcessStep, ProcessAddFG FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') AND ProcessStep <= @FGStep ORDER BY ProcessStep DESC", con)
        If WIPData.PartNumber IsNot Nothing Then
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = WIPData.PartNumber
            cmd1.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = WIPData.PartNumber
        Else
            cmd = New SqlCommand("DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT PostingDate, MachineNumber, SUM(TotalHours) as TotalHours, FOXStep, SUM(PiecesProduced) as TotalPieces, ProcessAddFG FROM (SELECT TimeSlipKey, LineKey, TimeSlipLineItemTable.FOXNumber, MachineNumber, TotalHours, FOXStep, PiecesProduced, TimeSlipLineItemTable.ProductionNumber FROM TimeSlipLineItemTable INNER JOIN (SELECT ProductionNumber, FOXNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') as FOXProductionNumberHeaderTable ON TimeSlipLineItemTable.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND TimeSlipLineItemTable.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber) as TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable On TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN FoxSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber and TimeSlipLineItemTable.FOXStep = FoxSched.ProcessStep WHERE LineKey < 100 and FOXStep <= @FGStep GROUP BY  FOXStep, PostingDate, MachineNumber, TotalHours, ProcessAddFG ORDER BY FOXStep, PostingDate ASC", con)
            cmd1 = New SqlCommand("DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT ProcessStep, ProcessAddFG FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') AND ProcessStep <= @FGStep ORDER BY ProcessStep DESC", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = WIPData.FOXNumber
            cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = WIPData.FOXNumber
        End If

        Dim tempds As New DataSet()
        Dim tempadap As New SqlDataAdapter(cmd)
        Dim StepList As New List(Of FOXStep)

        If con.State = ConnectionState.Closed Then con.Open()
        tempadap.Fill(tempds, "TimeSlipData")
        Dim reader As SqlDataReader = cmd1.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("ProcessStep")) And Not IsDBNull(reader.Item("ProcessAddFG")) Then
                    StepList.Add(New FOXStep(reader.Item("ProcessStep"), reader.Item("ProcessAddFG")))
                End If
            End While
        End If
        reader.Close()
        con.Close()

        If tempds.Tables("TimeSlipData").Rows.Count > 0 And StepList.Count > 0 Then
            Dim i As Integer = tempds.Tables("TimeSlipData").Rows.Count - 1
            Dim stepAmount As Integer = 0
            Dim prevAmount As Integer = 0
            Dim FGAmount As Integer = 0
            Dim HighestPrevStep As Integer = 0
            While i >= 0
                Dim currentStep As Integer = tempds.Tables("TimeSlipData").Rows(i).Item("FOXStep")
                ''check to see if we are at a new step or still on the current timeslip step
                If currentStep < StepList(0).ProcessStep Then
                    ''removes entries until we are on the current timeslip step
                    While currentStep <> StepList(0).ProcessStep
                        StepList.RemoveAt(0)
                    End While
                    prevAmount = FGAmount
                    ''will always use the highest step amount if it was after the current step
                    If HighestPrevStep < prevAmount Then
                        HighestPrevStep = prevAmount
                    Else
                        prevAmount = HighestPrevStep
                    End If
                    stepAmount = 0
                End If
                Dim stepEnd As Integer = i
                Dim sameStep As Boolean = True
                ''while still on the same step will subtract amounts
                While stepEnd >= 0 And sameStep
                    If Not tempds.Tables("TimeSlipData").Rows(stepEnd).Item("FOXStep").Equals(currentStep) Then
                        sameStep = False
                    Else
                        stepAmount += tempds.Tables("TimeSlipData").Rows(stepEnd).Item("TotalPieces")
                        stepEnd -= 1
                    End If
                End While
                If stepAmount <= prevAmount Then
                    While stepEnd <> i
                        tempds.Tables("TimeSlipData").Rows.RemoveAt(i)
                        i -= 1
                    End While
                    If FGAmount > stepAmount Then
                        prevAmount = FGAmount
                    Else
                        prevAmount = stepAmount
                    End If
                    ''will always use the highest step amount if it was after the current step
                    If HighestPrevStep < prevAmount Then
                        HighestPrevStep = prevAmount
                    Else
                        prevAmount = HighestPrevStep
                    End If
                    stepAmount = 0
                Else
                    If StepList(0).ProcessAddFG.Equals("ADDINVENTORY") Then
                        While i <> stepEnd
                            FGAmount += tempds.Tables("TimeSlipData").Rows(i).Item("TotalPieces")
                            tempds.Tables("TimeSlipData").Rows.RemoveAt(i)
                            i -= 1
                        End While
                    Else
                        While prevAmount > 0 And i <> stepEnd
                            If tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces") > prevAmount Then
                                tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces") -= prevAmount
                                prevAmount = 0
                                i -= 1
                            ElseIf tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces") < prevAmount Then
                                prevAmount -= tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces")
                                tempds.Tables("TimeSlipData").Rows.RemoveAt(stepEnd + 1)
                                i -= 1
                            Else
                                tempds.Tables("TimeSlipData").Rows.RemoveAt(stepEnd + 1)
                                prevAmount = 0
                            End If
                        End While
                    End If
                    ''will use the finished goods amount if it is higher than the step amount
                    If FGAmount > stepAmount Then
                        prevAmount = FGAmount
                    Else
                        prevAmount = stepAmount
                    End If
                    ''will always use the highest step amount if it was after the current step
                    If HighestPrevStep < prevAmount Then
                        HighestPrevStep = prevAmount
                    Else
                        prevAmount = HighestPrevStep
                    End If
                    stepAmount = 0
                    i = stepEnd
                End If
                StepList.RemoveAt(0)
            End While

            i = 0
            WIPData.dgv.Rows.Clear()
            WIPData.dgv.Columns.Clear()
            WIPData.dgv.Columns.Add("", "")
            WIPData.dgv.Columns.Add("", "")
            WIPData.dgv.Columns.Add("", "")
            WIPData.dgv.Columns.Add("", "")
            WIPData.dgv.Columns.Add("", "")
            If WIPData.dgv.Name.Equals("dgvWIP") And tempds.Tables("TimeSlipData").Rows.Count > 0 Then
                WIPData.dgv.Columns.Add("", "")
                If WIPData.PartNumber IsNot Nothing Then
                    AddFOXHeader(WIPData.PartNumber, WIPData.dgv, con)
                Else
                    AddFOXHeader(WIPData.FOXNumber, WIPData.dgv, con, True)
                End If

            End If
            cmd = New SqlCommand("", con)
            If WIPData.PartNumber IsNot Nothing Then
                cmd.CommandText = "SELECT ISNULL(SUM(PiecesProduced),0) FROM TimeSlipLineItemTable WHERE PartNumber = @PartNumber AND FOXStep = 1 AND ProductionNumber = (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = (SELECT MAX(FOXNumber) FROM FOXTable WHERE PartNumber = @PartNumber AND Status <> 'INACTIVE'))"
                cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = WIPData.PartNumber
            Else
                cmd.CommandText = "SELECT ISNULL(SUM(PiecesProduced),0) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND FOXStep = 1 AND ProductionNumber = (SELECT isnull(MAX(ProductionNumber), 0 ) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')"
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = WIPData.FOXNumber
            End If
            If con.State = ConnectionState.Closed Then con.Open()
            Dim headedPieces As Integer = cmd.ExecuteScalar()
            While i < tempds.Tables("TimeSlipData").Rows.Count
                If WIPData.PartNumber IsNot Nothing Then
                    AddStepHeader(i, tempds, WIPData.PartNumber, WIPData.dgv, con)
                Else
                    AddStepHeader(i, tempds, WIPData.FOXNumber, WIPData.dgv, con, True)
                End If
                AddStepDetails(i, tempds, WIPData.dgv)
            End While
            If con.State = ConnectionState.Open Then con.Close()
            If WIPData.dgv.Rows.Count > 0 Then
                WIPData.dgv.Rows.Add("")
                If (headedPieces - FGAmount) < 0 Then
                    WIPData.dgv.Rows.Add("", "", "", "Total WIP - ", (0).ToString())
                Else
                    WIPData.dgv.Rows.Add("", "", "", "Total WIP - ", (headedPieces - FGAmount).ToString())
                End If

            End If
        Else
            WIPData.dgv.Rows.Clear()
            WIPData.dgv.Columns.Clear()
        End If
        If WIPData.dgv.Rows.Count = 0 Then
            WIPData.pnl.Visible = True
        Else
            WIPData.pnl.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Loads the Production Data from the given Part Numbers and/or FOX Number
    ''' </summary>
    ''' <param name="WIPData">Part numberss or FOX numbers</param>
    ''' <remarks></remarks>
    Public Sub LoadMultipleFOXProductionData(ByRef WIPData As WIPDataPassed)
        WIPData.dgv.Rows.Clear()
        WIPData.dgv.Columns.Clear()
        WIPData.dgv.Columns.Add("", "")
        WIPData.dgv.Columns.Add("", "")
        WIPData.dgv.Columns.Add("", "")
        WIPData.dgv.Columns.Add("", "")
        WIPData.dgv.Columns.Add("", "")
        WIPData.dgv.Columns.Add("", "")
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim loopcount As Integer = 0
        If WIPData.PartNumbers IsNot Nothing Then
            loopcount = WIPData.PartNumbers.Count - 1
        Else
            loopcount = WIPData.FOXNumbers.Count - 1
        End If
        For j As Integer = 0 To loopcount
            Dim cmd As New SqlCommand("DECLARE @FOXNumber as int = (SELECT TOP 1 FOXNumber FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')); DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT PostingDate, MachineNumber, SUM(TotalHours) as TotalHours, FOXStep, SUM(PiecesProduced) as TotalPieces, ProcessAddFG FROM (SELECT TimeSlipKey, TimeSlipLineItemTable.FOXNumber, TimeSlipLineItemTable.LineKey, MachineNumber, FOXStep, PiecesProduced, TotalHours, TimeSlipLineItemTable.ProductionNumber FROM TimeSlipLineItemTable INNER JOIN (SELECT FOXNumber, ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') as FOXProductionNumberHeaderTable ON TimeSlipLineItemTable.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber AND TimeSlipLineItemTable.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber) as TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable On TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN FoxSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber and TimeSlipLineItemTable.FOXStep = FoxSched.ProcessStep WHERE LineKey < 100 and FOXStep <= @FGStep GROUP BY  FOXStep, PostingDate, MachineNumber, TotalHours, ProcessAddFG ORDER BY FOXStep, PostingDate ASC", con)
            Dim cmd1 As New SqlCommand("DECLARE @FOXNumber as int = (SELECT TOP 1 FOXNumber FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')); DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT ProcessStep, ProcessAddFG FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber in (SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') AND ProcessStep <= @FGStep ORDER BY ProcessStep DESC", con)
            If WIPData.PartNumbers IsNot Nothing Then
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = WIPData.PartNumbers(j)
                cmd1.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = WIPData.PartNumbers(j)
            Else
                cmd = New SqlCommand("DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT PostingDate, MachineNumber, SUM(TotalHours) as TotalHours, FOXStep, SUM(PiecesProduced) as TotalPieces, ProcessAddFG FROM (SELECT TimeSlipKey, LineKey, TimeSlipLineItemTable.FOXNumber, MachineNumber, TotalHours, FOXStep, PiecesProduced, TimeSlipLineItemTable.ProductionNumber FROM TimeSlipLineItemTable INNER JOIN (SELECT ProductionNumber, FOXNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') as FOXProductionNumberHeaderTable ON TimeSlipLineItemTable.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND TimeSlipLineItemTable.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber) as TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable On TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN FoxSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber and TimeSlipLineItemTable.FOXStep = FoxSched.ProcessStep WHERE LineKey < 100 and FOXStep <= @FGStep GROUP BY  FOXStep, PostingDate, MachineNumber, TotalHours, ProcessAddFG ORDER BY FOXStep, PostingDate ASC", con)
                cmd1 = New SqlCommand("DECLARE @FGStep as int = (SELECT MAX(ProcessStep) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY' AND ProductionNumber = (SELECT isnull(ProductionNumber, 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN')); SELECT ProcessStep, ProcessAddFG FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') AND ProcessStep <= @FGStep ORDER BY ProcessStep DESC", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = WIPData.FOXNumbers(j)
                cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = WIPData.FOXNumbers(j)
            End If
            Dim tempds As New DataSet()
            Dim tempadap As New SqlDataAdapter(cmd)
            Dim StepList As New List(Of FOXStep)

            If con.State = ConnectionState.Closed Then con.Open()
            tempadap.Fill(tempds, "TimeSlipData")
            Dim reader As SqlDataReader = cmd1.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    If Not IsDBNull(reader.Item("ProcessStep")) And Not IsDBNull(reader.Item("ProcessAddFG")) Then
                        StepList.Add(New FOXStep(reader.Item("ProcessStep"), reader.Item("ProcessAddFG")))
                    End If
                End While
            End If
            reader.Close()
            con.Close()

            If tempds.Tables("TimeSlipData").Rows.Count > 0 And StepList.Count > 0 Then
                Dim i As Integer = tempds.Tables("TimeSlipData").Rows.Count - 1
                Dim stepAmount As Integer = 0
                Dim prevAmount As Integer = 0
                Dim FGAmount As Integer = 0
                Dim HighestPrevStep As Integer = 0

                While i >= 0
                    Dim currentStep As Integer = tempds.Tables("TimeSlipData").Rows(i).Item("FOXStep")
                    If currentStep < StepList(0).ProcessStep Then
                        While currentStep <> StepList(0).ProcessStep
                            StepList.RemoveAt(0)
                        End While
                        ''will always use the highest step amount if it was after the current step
                        If HighestPrevStep < prevAmount Then
                            HighestPrevStep = prevAmount
                        Else
                            prevAmount = HighestPrevStep
                        End If
                        stepAmount = 0
                    End If
                    Dim stepEnd As Integer = i
                    Dim sameStep As Boolean = True
                    While stepEnd >= 0 And sameStep
                        If Not tempds.Tables("TimeSlipData").Rows(stepEnd).Item("FOXStep").Equals(currentStep) Then
                            sameStep = False
                        Else
                            stepAmount += tempds.Tables("TimeSlipData").Rows(stepEnd).Item("TotalPieces")
                            stepEnd -= 1
                        End If
                    End While
                    If stepAmount <= prevAmount Then
                        While stepEnd <> i
                            tempds.Tables("TimeSlipData").Rows.RemoveAt(i)
                            i -= 1
                        End While
                        ''will use the finished goods amount if it is higher than the step amount
                        If FGAmount > stepAmount Then
                            prevAmount = FGAmount
                        Else
                            prevAmount = stepAmount
                        End If
                        ''will always use the highest step amount if it was after the current step
                        If HighestPrevStep < prevAmount Then
                            HighestPrevStep = prevAmount
                        Else
                            prevAmount = HighestPrevStep
                        End If
                        stepAmount = 0
                    Else
                        If StepList(0).ProcessAddFG.Equals("ADDINVENTORY") Then
                            While i <> stepEnd
                                tempds.Tables("TimeSlipData").Rows.RemoveAt(i)
                                i -= 1
                            End While
                        Else
                            While prevAmount > 0 And i <> stepEnd
                                If tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces") > prevAmount Then
                                    tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces") -= prevAmount
                                    prevAmount = 0
                                    i -= 1
                                ElseIf tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces") < prevAmount Then
                                    prevAmount -= tempds.Tables("TimeSlipData").Rows(stepEnd + 1).Item("TotalPieces")
                                    tempds.Tables("TimeSlipData").Rows.RemoveAt(stepEnd + 1)
                                    i -= 1
                                Else
                                    tempds.Tables("TimeSlipData").Rows.RemoveAt(stepEnd + 1)
                                    prevAmount = 0
                                End If
                            End While
                        End If

                        ''will use the finished goods amount if it is higher than the step amount
                        If FGAmount > stepAmount Then
                            prevAmount = FGAmount
                        Else
                            prevAmount = stepAmount
                        End If
                        ''will always use the highest step amount if it was after the current step
                        If HighestPrevStep < prevAmount Then
                            HighestPrevStep = prevAmount
                        Else
                            prevAmount = HighestPrevStep
                        End If
                        stepAmount = 0
                        i = stepEnd
                    End If
                    StepList.RemoveAt(0)
                End While

                i = 0

                If WIPData.PartNumbers IsNot Nothing Then
                    AddFOXHeader(WIPData.PartNumbers(j), WIPData.dgv, con)
                Else
                    AddFOXHeader(WIPData.FOXNumbers(j), WIPData.dgv, con, True)
                End If

                While i < tempds.Tables("TimeSlipData").Rows.Count
                    If WIPData.PartNumbers IsNot Nothing Then
                        AddStepHeader(i, tempds, WIPData.PartNumbers(j), WIPData.dgv, con)
                    Else
                        AddStepHeader(i, tempds, WIPData.FOXNumbers(j), WIPData.dgv, con, True)
                    End If

                    AddStepDetails(i, tempds, WIPData.dgv)
                End While
                If tempds.Tables("TimeSlipData").Rows.Count = 0 Then
                    WIPData.dgv.Rows.Add("", "NO WIP")
                End If
            Else
                If WIPData.PartNumbers IsNot Nothing Then
                    AddFOXHeader(WIPData.PartNumbers(j), WIPData.dgv, con)
                Else
                    AddFOXHeader(WIPData.FOXNumbers(j), WIPData.dgv, con, True)
                End If

                WIPData.dgv.Rows.Add("", "NO WIP")
            End If
        Next
        If con.State = ConnectionState.Open Then con.Close()
    End Sub
    ''
    ''' <summary>
    ''' Adds the header data for a DGV so it is readable ot the user
    ''' </summary>
    ''' <param name="partNumber">FOX or Part number</param>
    ''' <param name="dgv">DataGridView for final UI</param>
    ''' <param name="con">SQL Connection</param>
    ''' <param name="isFOXNumber">True if it is a FOX number.</param>
    ''' <remarks></remarks>
    Private Sub AddFOXHeader(ByVal partNumber As String, ByRef dgv As DataGridView, ByRef con As SqlConnection, Optional ByVal isFOXNumber As Boolean = False)
        Dim cmd As New SqlCommand("SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')", con)
        If isFOXNumber Then
            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE ItemID = (SELECT PartNumber FROM FOXTable WHERE FOXNumber = @FOXNumber) AND (DivisionID = 'TWD' OR DivisionID = 'TFP')", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = partNumber
        Else
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = partNumber
        End If

        Dim description As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If Not IsDBNull(obj) Then
            If obj IsNot Nothing Then
                description = obj.ToString()
            End If
        End If
        dgv.Rows.Add(description)
    End Sub

    ''' <summary>
    ''' Adds the header data for the steps so it is readable in a DGV to the user
    ''' </summary>
    ''' <param name="i">Row position</param>
    ''' <param name="tempds">Dataset of time slip data</param>
    ''' <param name="partNumber">FOX or Part number</param>
    ''' <param name="dgv">End UI for user</param>
    ''' <param name="con">SQL Connection</param>
    ''' <param name="isFOXNumber">true if FOX number</param>
    ''' <remarks></remarks>
    Private Sub AddStepHeader(ByVal i As Integer, ByRef tempds As DataSet, ByVal partNumber As String, ByRef dgv As DataGridView, ByRef con As SqlConnection, Optional ByVal isFOXNumber As Boolean = False)
        Dim cmd As New SqlCommand("Select ProcessID FROM FOXSched WHERE FOXnumber = (SELECT TOP 1 FOXNumber FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')) and ProcessStep = @ProcessStep", con)
        If isFOXNumber Then
            cmd = New SqlCommand("Select ProcessID FROM FOXSched WHERE FOXnumber = @FOXNumber and ProcessStep = @ProcessStep", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = partNumber
        Else
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = partNumber
        End If

        cmd.Parameters.Add("@ProcessStep", SqlDbType.Int).Value = tempds.Tables("TimeSlipData").Rows(i).Item("FOXStep")
        Dim procID As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If Not IsDBNull(obj) Then
            procID = obj.ToString()
        End If
        dgv.Rows.Add("FOX Step #" + tempds.Tables("TimeSlipData").Rows(i).Item("FOXStep").ToString() + " - " + procID)
    End Sub

    ''' <summary>
    ''' Adds the header info for the details of the steps in the DGv so it is readable to the user
    ''' </summary>
    ''' <param name="i">ow position</param>
    ''' <param name="tempds">Dataset of time slip data</param>
    ''' <param name="dgv">End UI for user</param>
    ''' <returns>returns the total number of pieces for the given step.</returns>
    ''' <remarks></remarks>
    ''' 
    Private Function AddStepDetails(ByRef i As Integer, ByRef tempds As DataSet, ByRef dgv As DataGridView) As Integer
        Dim stepNumber As Integer = tempds.Tables("TimeSlipData").Rows(i).Item("FOXStep")
        Dim notStep As Boolean = True
        Dim TotalPieces As Double = 0D
        dgv.Rows.Add("", "Posting Date", "Machine #", "Pieces Produced")
        While i < tempds.Tables("TimeSlipData").Rows.Count And notStep
            If tempds.Tables("TimeSlipData").Rows(i).Item("FOXStep") <> stepNumber Then
                notStep = False
            Else
                If tempds.Tables("TimeSlipData").Rows(i).Item("TotalPieces") > 0 Then
                    dgv.Rows.Add("", tempds.Tables("TimeSlipData").Rows(i).Item("PostingDate").ToString().Substring(0, tempds.Tables("TimeSlipData").Rows(i).Item("PostingDate").ToString().IndexOf(" ")), tempds.Tables("TimeSlipData").Rows(i).Item("MachineNumber").ToString(), tempds.Tables("TimeSlipData").Rows(i).Item("TotalPieces").ToString())
                End If

                TotalPieces += tempds.Tables("TimeSlipData").Rows(i).Item("TotalPieces")
                i += 1
            End If
        End While
        dgv.Rows.Add("", "", "", "Total Pieces - ", TotalPieces.ToString())
        Return TotalPieces
    End Function

    ''' <summary>
    ''' Generates a new Production Quantity from the given FOX Number (Note: SQL Connection is required)
    ''' </summary>
    ''' <param name="FOXNumber">FOX</param>
    ''' <param name="con">SQL Connection</param>
    ''' <returns>Pieces to produce</returns>
    ''' <remarks></remarks>
    ''' 
    Public Function GenerateNewProductionQuantityByFOX(ByVal FOXNumber As String, ByRef con As SqlConnection) As String
        Dim cmd As New SqlCommand("DECLARE @DivisionID as Varchar(50) = (SELECT TOP 1 DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber); IF @DivisionID = 'TWD' SELECT isnull(SUM(MaximumStock + OpenSOQuantity - QuantityOnHand), 0) as ProductionQuantity FROM ADMInventoryTotal WHERE ItemID = (SELECT TOP 1 PartNumber FROM FOXTable WHERE FOXNumber = @FOXNumber) AND DivisionID = 'TWD' ELSE SELECT NULL", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If obj IsNot Nothing Then
            ''If the object returned is a null value it means that it is a TFP FOX and will require extensive calculations.
            If Not IsDBNull(obj) Then
                If Val(obj) < 0 Then
                    obj = 0
                End If
            Else
                cmd.CommandText = "DECLARE @PartNumber as varchar(50) = CASE WHEN EXISTS(SELECT isnull(PartNumber,'NO PART') FROM FOXTable where FOXNumber = @FOXNumber) THEN (SELECT isnull(PartNumber, 'NO PART') FROM FOXTable where foxnumber = @FOXNumber) ELSE (SELECT 'NO PART') END;"
                cmd.CommandText += " IF @PartNumber <> 'NO PART'"
                cmd.CommandText += "  BEGIN"
                cmd.CommandText += "   DECLARE @QOH as float = (SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @PartNumber AND DivisionID = 'TFP');"
                cmd.CommandText += "   SELECT FOXNumber, ((1.1*isnull(ProductionQuantity,0)) - isnull(QuantityShipped,0)) as RemainingQuantity, @QOH as QuantityOnHand, SO.SOStatus FROM (SELECT * FROM FOXTable WHERE PartNumber = @PartNumber AND Status <> 'INACTIVE' AND DivisionID = 'TFP') as CurrentFOXS LEFT OUTER JOIN (SELECT * FROM SalesOrderQuantityStatus WHERE ItemID = @PartNumber AND DivisionKey = 'TFP' and SOStatus <> 'CLOSED') as SO ON CurrentFOXS.PartNumber = SO.ItemID AND CurrentFOXS.OrderReferenceNumber = SO.SalesOrderKey ORDER BY FOXNumber, CreationDate;"
                cmd.CommandText += "  END"

                Dim tempds As New DataSet


                If con.State = ConnectionState.Closed Then con.Open()
                Dim adap As New SqlDataAdapter(cmd)
                adap.Fill(tempds, "FOXS")
                con.Close()
                Dim QOH As Integer = 0
                If tempds.Tables("FOXS").Rows.Count > 0 Then
                    QOH = Val(tempds.Tables("FOXS").Rows(0).Item("QuantityOnHand"))

                    Dim pos As Integer = 0
                    Dim NotFOX As Boolean = True
                    While pos < tempds.Tables("FOXS").Rows.Count And NotFOX
                        If Not tempds.Tables("FOXS").Rows(pos).Item("FOXNumber").ToString.Equals(FOXNumber) Then
                            QOH = QOH - Val(tempds.Tables("FOXS").Rows(pos).Item("RemainingQuantity"))
                            pos += 1
                        Else
                            NotFOX = False
                        End If
                    End While
                    If Not NotFOX Then
                        If QOH < 0 Then
                            obj = Val(tempds.Tables("FOXS").Rows(pos).Item("RemainingQuantity"))
                        Else
                            obj = QOH - Val(tempds.Tables("FOXS").Rows(pos).Item("RemainingQuantity"))
                            If obj < 0 Then
                                obj = Math.Abs(obj)
                            Else
                                obj = 0
                            End If
                        End If
                    End If
                Else
                    obj = 0
                End If
            End If
        Else
            obj = 0
        End If
        If con.State = ConnectionState.Open Then con.Close()
        Return obj.ToString()
    End Function

    ''' <summary>
    ''' Updates the Production Quantity for the given FOX and production number (Note: SQL Connection is required)
    ''' </summary>
    ''' <param name="ProductionNumber">Current production number</param>
    ''' <param name="FOXnumber">FOX</param>
    ''' <param name="ProductionQuantity">New quantity</param>
    ''' <param name="con">SQL Connection</param>
    ''' <returns>true if not failed.</returns>
    ''' <remarks></remarks>
    ''' 
    Public Function UpdateProductionQuantity(ByVal ProductionNumber As String, ByVal FOXnumber As String, ByVal ProductionQuantity As String, ByRef con As SqlConnection) As Boolean
        Dim cmd As New SqlCommand("UPDATE FOXProductionNumberHeaderTable SET ProductionQuantity = @ProductionQuantity WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND Status = 'OPEN'", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FOXnumber)
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = Val(ProductionNumber)
        cmd.Parameters.Add("@ProductionQuantity", SqlDbType.Int).Value = Val(ProductionQuantity)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            con.Close()
            Return False
        End Try

        con.Close()
        Return True
    End Function

    ''' <summary>
    ''' Updates the Production Quantity for the given FOX (Note: SQL Connection is required)
    ''' </summary>
    ''' <param name="FOXnumber">FOC</param>
    ''' <param name="ProductionQuantity">New Quantity</param>
    ''' <param name="con">SQL Connection</param>
    ''' <returns>true if not failed.</returns>
    ''' <remarks></remarks>
    Public Function UpdateProductionQuantityByFOX(ByVal FOXnumber As String, ByVal ProductionQuantity As String, ByRef con As SqlConnection) As Boolean
        Dim cmd As New SqlCommand("DECLARE @ProductionNumber as int = case when ((SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') <> 0) then (SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') else case when exists(SELECT isnull(MAX(ProductionNumber) + 1, 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) then (SELECT isnull(MAX(ProductionNumber) + 1, 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) ELSE (SELECT 80316) end end; IF EXISTS(SELECT * FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber) UPDATE FOXProductionNumberHeaderTable SET ProductionQuantity = @ProductionQuantity WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND Status = 'OPEN' ELSE BEGIN IF ((SELECT COUNT(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber) = 1) BEGIN INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) VALUES (@ProductionNumber, @FOXNumber, @CurrentDateTime, @ProductionQuantity, 'OPEN'); INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) SELECT @ProductionNumber, @FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber END END", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FOXnumber)
        cmd.Parameters.Add("@ProductionQuantity", SqlDbType.Int).Value = Val(ProductionQuantity)
        cmd.Parameters.Add("@CurrentDateTime", SqlDbType.DateTime).Value = Now

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            con.Close()
            Return False
        End Try

        con.Close()
        Return True
    End Function

    ''' <summary>
    ''' Get the value of WIP
    ''' </summary>
    ''' <param name="whereCond">Complex where condition to limit query</param>
    ''' <param name="con">SQL Connection</param>
    ''' <returns>The value of WIP in DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetWIPValue(ByVal whereCond As Dictionary(Of String, Object), ByRef con As SqlConnection) As Data.DataTable
        ''Where conditions need to be a certain type
        ''If using a start and end date they must be StartDate and EndDate
        ''If using just a
        Dim dt As New Data.DataTable("WIP")
        Dim bld As New System.Text.StringBuilder()
        Dim cmd As New SqlCommand("", con)
        bld.Append("IF OBJECT_ID('tempdb..#WIPTimeslipEntries') IS NOT NULL DROP TABLE #WIPTimeslipEntries;")
        bld.Append(" CREATE TABLE #WIPTimeslipEntries(PostingDate date, FOXNumber int, MachineNumber varchar(10), Description varchar(50), PiecesProduced int, ShortDescription varchar(100), MachineClass varchar(10), PiecesPerHour float, MachineCostPerHour float, TotalHours float, FOXStep int, TimeSlipKey int, LineKey int, PartNumber varchar(50), RMID varchar(30), LineWeight float);")
        If whereCond.Keys.Count > 0 Then
            bld.Append(" DECLARE fox_cursor SCROLL CURSOR FOR SELECT TimeSlipCombinedData.FOXNumber, SUM((CASE WHEN TimeSlipCombinedData.InventoryPieces <> 0 THEN 0 ELSE PiecesProduced END) - InventoryPieces) as TotalWIPPieces  FROM TimeSlipCombinedData LEFT OUTER JOIN FoxSched ON TimeSlipCombinedData. FOXNumber = FoxSched.FOXNumber AND TimeSlipCombinedData.FOXStep = FoxSched.ProcessStep INNER JOIN FOXProductionNumberHeaderTable ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber  AND TimeSlipCombinedData.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber INNER JOIN FOXTable ON TimeSlipCombinedData.FOXNumber = FOXTable.FOXNumber WHERE (TimeslipCombinedData.FOXStep = 1 OR FOXSched.ProcessAddFG = 'ADDINVENTORY' OR InventoryPieces > 0)")
            ''Check to see if this condition is a FOX number
            If whereCond.ContainsKey("FOXNumber") Then
                bld.Append(" AND TimeSlipCombinedData.FOXNumber = @FOXNumber")
                cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(whereCond("FOXNumber"))
            End If
            ''StartDate must be accompanied by EndDate in the passed conditions
            If whereCond.ContainsKey("StartDate") AndAlso whereCond.ContainsKey("EndDate") Then
                bld.Append(" AND TimeSlipCombinedData.PostingDate BETWEEN @StartDate AND @EndDate")
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Date.Parse(whereCond("StartDate"))
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Date.Parse(whereCond("EndDate"))
            End If
            If whereCond.ContainsKey("PostingDate") Then
                bld.Append(" AND TimeSlipCombinedData.PostingDate = @PostingDate")
                cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = Date.Parse(whereCond("PostingDate"))
            End If
            If whereCond.ContainsKey("PartNumber") Then
                bld.Append(" AND TimeSlipCombinedData.PartNumber = @PartNumber")
                cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = whereCond("PartNumber")
            End If
            If whereCond.ContainsKey("PartNumber") Then
                bld.Append(" AND TimeSlipCombinedData.PartNumber = @PartNumber")
                cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = whereCond("PartNumber")
            End If
            If whereCond.ContainsKey("DivisionID") Then
                bld.Append(" AND TimeSlipCombinedData.DivisionID = @DivisionID")
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = whereCond("DivisionID")
            End If
            If whereCond.ContainsKey("FOXProductionNumberHeaderTable.Status") Then
                If whereCond.ContainsKey("FOXTable.Status") Then
                    bld.Append(" AND FOXTable.Status = @FOXStatus AND FOXProductionNumberHeaderTable.Status = @ProdStatus")
                    cmd.Parameters.Add("@FOXStatus", SqlDbType.VarChar).Value = whereCond("FOXTable.Status")
                Else
                    bld.Append(" AND FOXProductionNumberHeaderTable.Status = @ProdStatus")
                End If

                cmd.Parameters.Add("@ProdStatus", SqlDbType.VarChar).Value = whereCond("FOXProductionNumberHeaderTable.Status")
            Else
                If whereCond.ContainsKey("FOXTable.Status") Then
                    bld.Append(" AND FOXTable.Status = @FOXStatus")
                    cmd.Parameters.Add("@FOXStatus", SqlDbType.VarChar).Value = whereCond("FOXTable.Status")
                End If
            End If

            bld.Append(" GROUP BY TimeSlipCombinedData.FOXNumber HAVING SUM((CASE WHEN TimeSlipCombinedData.InventoryPieces <> 0 THEN 0 ELSE PiecesProduced END) - InventoryPieces) > 0 ORDER BY TimeSlipCombinedData.FOXNumber;")
        Else
            bld.Append(" DECLARE fox_cursor SCROLL CURSOR FOR SELECT TimeSlipCombinedData.FOXNumber, SUM((CASE WHEN TimeSlipCombinedData.InventoryPieces <> 0 THEN 0 ELSE PiecesProduced END) - InventoryPieces) as TotalWIPPieces  FROM TimeSlipCombinedData LEFT OUTER JOIN FoxSched ON TimeSlipCombinedData. FOXNumber = FoxSched.FOXNumber AND TimeSlipCombinedData.FOXStep = FoxSched.ProcessStep INNER JOIN FOXProductionNumberHeaderTable ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber  AND TimeSlipCombinedData.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber INNER JOIN FOXTable ON TimeSlipCombinedData.FOXNumber = FOXTable.FOXNumber WHERE (TimeslipCombinedData.FOXStep = 1 OR FOXSched.ProcessAddFG = 'ADDINVENTORY' OR InventoryPieces > 0) AND FOXProductionNumberHeaderTable.Status = 'OPEN' AND FOXTable.Status <> 'INACTIVE' GROUP BY TimeSlipCombinedData.FOXNumber HAVING SUM((CASE WHEN TimeSlipCombinedData.InventoryPieces <> 0 THEN 0 ELSE PiecesProduced END) - InventoryPieces) > 0 ORDER BY TimeSlipCombinedData.FOXNumber;")
        End If
        bld.Append(" DECLARE @CurrentFOX int = 0, @CurrentTotalWIp as int = 0 ,@CurrentFOXStep int = 0, @CurrentStepPieces int = 0;")
        bld.Append(" OPEN fox_cursor; FETCH NEXT FROM fox_cursor INTO @CurrentFOX, @CurrentTotalWIP;")
        ''Loops through all foxes found to have WIP given the where conditions
        bld.Append(" WHILE @@FETCH_STATUS = 0 BEGIN")
        bld.Append(" DECLARE @InventoryPieces as int = (SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData LEFT OUTER JOIN FOXProductionNumberHeaderTable ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND TimeSlipCombinedData.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber WHERE TimeSlipCombinedData.FOXNumber = @CurrentFOX AND FOXProductionNumberHeaderTable.Status = 'OPEN')")
        bld.Append(" , @FGStep int = (SELECT ProcessStep FROM FoxSched WHERE FOXNumber = @CurrentFOX AND ProcessAddFG = 'ADDINVENTORY');")
        bld.Append(" DECLARE foxdata_cursor SCROLL CURSOR FOR SELECT FOXStep, SUM(PiecesProduced - InventoryPieces) as StepPieces FROM TimeSlipCombinedData LEFT OUTER JOIN FOXProductionNumberHeaderTable ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND TimeSlipCombinedData.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber WHERE TimeSlipCombinedData.FOXNumber = @CurrentFOX AND FOXProductionNumberHeaderTable.Status = 'OPEN' AND FOXStep < @FGStep GROUP BY FOXStep HAVING SUM(PiecesProduced - InventoryPieces) > @InventoryPieces ORDER BY FOXStep DESC;")
        bld.Append(" OPEN foxdata_cursor; FETCH NEXT FROM foxdata_cursor INTO @CurrentFOXStep, @CurrentStepPieces;")
        bld.Append(" DECLARE @LastStepPieces int = 0;")
        ''Loops through all the fox steps lower than the finished goods step in reverse
        bld.Append(" WHILE @@FETCH_STATUS = 0 BEGIN")
        bld.Append(" IF (@CurrentStepPieces > (@InventoryPieces + @LastStepPieces)) BEGIN")
        bld.Append(" DECLARE @StepDifference int = CASE WHEN @InventoryPieces > @LastStepPieces THEN @CurrentStepPieces - @InventoryPieces ELSE @CurrentStepPieces - @LastStepPieces END, @CurrentTimeSlipKey int = 0, @CurrentLineKey int = 0, @CurrentTimeSlipPieces int = 0;")
        bld.Append(" DECLARE foxstep_cursor SCROLL CURSOR FOR SELECT TimeSlipCombinedData.TimeSlipKey, TimeSlipCombinedData.LineKey, TimeSlipCombinedData.PiecesProduced - TimeSlipCombinedData.InventoryPieces FROm TimeSlipCombinedData INNER JOIN FOXProductionNumberHeaderTable ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND TimeSlipCombinedData.ProductionNumber = FOXProductionNumberHeaderTable.ProductionNumber WHERE TimeSlipCombinedData.FOXNumber = @CurrentFOX AND FOXProductionNumberHeaderTable.Status = 'OPEN' AND FOXStep = @CurrentFOXStep ")
        If whereCond.ContainsKey("StartDate") AndAlso whereCond.ContainsKey("EndDate") Then
            bld.Append(" AND TimeSlipCombinedData.PostingDate BETWEEN @StartDate AND @EndDate")
        End If
        If whereCond.ContainsKey("PostingDate") Then
            bld.Append(" AND TimeSlipCombinedData.PostingDate = @PostingDate")
        End If
        bld.Append(" ORDER BY PostingDate DESC, TimeSlipCombinedData.TimeSlipKey desc, TimeSlipCombinedData.LineKey desc;")

        bld.Append(" OPEN foxstep_cursor; FETCH NEXT FROM foxstep_cursor INTO @CurrentTimeSlipKey, @CurrentLineKey, @CurrentTimeSlipPieces;")
        ''Loops through all the timeslip entries for a give FOX step ordered by posting date until it gets enough pieces for the particular step
        bld.Append(" WHILE @@FETCH_STATUS = 0 AND @StepDifference > 0 BEGIN")
        bld.Append(" if (@StepDifference >= @CurrentTimeSlipPieces) BEGIN")
        bld.Append(" INSERT INTO #WIPTimeslipEntries(PostingDate, FOXNumber, MachineNumber, Description, PiecesProduced, ShortDescription, MachineClass, PiecesPerHour, MachineCostPerHour, TotalHours, FOXStep, TimeSlipKey, LineKey, PartNumber, RMID, LineWeight)")
        bld.Append(" SELECT TimeSlipCombinedData.PostingDate, TimeSlipCombinedData.FOXNumber, TimeSlipCombinedData.MachineNumber, MachineTable.Description, TimeSlipCombinedData.PiecesProduced, ItemList.ShortDescription, MachineTable.MachineClass, ROUND(TimeslipCombinedData.PiecesProduced / (CASE WHEN TimeslipCombinedData.TotalHours = 0 THEN 1 ELSE TimeslipCombinedData.TotalHours END), 5) AS PiecesPerHour, MachineTable.MachineCostPerHour, TimeSlipCombinedData.TotalHours, TimeSlipCombinedData.FOXStep, TimeSlipCombinedData.TimeSlipKey, TimeSlipCombinedData.LineKey, TimeSlipCombinedData.PartNumber, TimeSlipCombinedData.RMID, TimeSlipCombinedData.LineWeight FROM TimeSlipCombinedData LEFT OUTER JOIN ItemList ON TimeSlipCombinedData.PartNumber = ItemList.ItemID AND TimeSlipCombinedData.DivisionID = ItemList.DivisionID LEFT OUTER JOIN MachineTable ON TimeSlipCombinedData.MachineNumber = MachineTable.MachineID AND MachineTable.DivisionID = 'TWD' WHERE TimeSlipCombinedData.TimeSlipKey = @CurrentTimeSlipKey AND TimeSlipCombinedData.LineKey = @CurrentLineKey;")
        bld.Append(" SET @StepDifference = @StepDifference - @CurrentTimeSlipPieces; END")
        bld.Append(" ELSE BEGIN")
        bld.Append(" INSERT INTO #WIPTimeslipEntries(PostingDate, FOXNumber, MachineNumber, Description, PiecesProduced, ShortDescription, MachineClass, PiecesPerHour, MachineCostPerHour, TotalHours, FOXStep, TimeSlipKey, LineKey, PartNumber, RMID, LineWeight)")
        bld.Append(" SELECT TimeSlipCombinedData.PostingDate, TimeSlipCombinedData.FOXNumber, TimeSlipCombinedData.MachineNumber, MachineTable.Description, @StepDifference, ItemList.ShortDescription, MachineTable.MachineClass, ROUND(TimeslipCombinedData.PiecesProduced / (CASE WHEN TimeslipCombinedData.TotalHours = 0 THEN 1 ELSE TimeslipCombinedData.TotalHours END), 5) AS PiecesPerHour, MachineTable.MachineCostPerHour, ROUND((TimeSlipCombinedData.TotalHours / TimeSlipCombinedData.PiecesProduced) * @StepDifference, 3), TimeSlipCombinedData.FOXStep, TimeSlipCombinedData.TimeSlipKey, TimeSlipCombinedData.LineKey, TimeSlipCombinedData.PartNumber, TimeSlipCombinedData.RMID, ROUND((TimeSlipCombinedData.LineWeight / TimeSlipCombinedData.PiecesProduced) * @StepDifference, 4) FROM TimeSlipCombinedData LEFT OUTER JOIN ItemList ON TimeSlipCombinedData.PartNumber = ItemList.ItemID AND TimeSlipCombinedData.DivisionID = ItemList.DivisionID LEFT OUTER JOIN MachineTable ON TimeSlipCombinedData.MachineNumber = MachineTable.MachineID AND MachineTable.DivisionID = 'TWD' WHERE TimeSlipCombinedData.TimeSlipKey = @CurrentTimeSlipKey AND TimeSlipCombinedData.LineKey = @CurrentLineKey;")
        bld.Append(" SET @StepDifference = 0; END")
        bld.Append(" FETCH NEXT FROM foxstep_cursor INTO @CurrentTimeSlipKey, @CurrentLineKey, @CurrentTimeSlipPieces; END")
        bld.Append(" CLOSE foxstep_cursor; DEALLOCATE foxstep_cursor; END")
        bld.Append(" SET @LastStepPieces = CASE WHEN @CurrentStepPieces > @InventoryPieces THEN @CurrentStepPieces - @InventoryPieces ELSE 0 END;")
        bld.Append(" FETCH NEXT FROM foxdata_cursor INTO @CurrentFOXStep, @CurrentStepPieces; END")
        bld.Append(" CLOSE foxdata_cursor; DEALLOCATE foxdata_cursor;")
        bld.Append(" FETCH NEXT FROM fox_cursor INTO @CurrentFOX, @CurrentTotalWIP; END")
        bld.Append(" CLOSE fox_cursor; DEALLOCATE fox_cursor;")
        bld.Append(" SELECT PostingDate, FOXNumber, FOXStep, MachineNumber, Description, PartNumber, ShortDescription, TotalHours, PiecesProduced, LineWeight, Round(TotalHours * MachineCostPerHour, 2) as MachineCost, ROUND(TotalHours * 20, 2) as LaborCost, RMID, LineWeight FROM #WIPTimeslipEntries WHERE PiecesProduced > 0 ORDER BY FOXNumber, FOXStep, PostingDate;")
        bld.Append(" DROP TABLE #WIPTimeslipEntries")
        cmd.CommandText = bld.ToString()

        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        GetApproxSteelCost(dt, con)
        If con.State = ConnectionState.Open Then con.Close()
        Return dt
    End Function

    ''' <summary>
    ''' Attempts to locate the steel cost for FOXs given.
    ''' </summary>
    ''' <param name="dt">DataTable of FOXs</param>
    ''' <param name="con">SQL Connection</param>
    ''' <remarks></remarks>
    Private Sub GetApproxSteelCost(ByRef dt As Data.DataTable, ByRef con As SqlConnection)
        If Not dt.Columns.Contains("SteelCost") Then
            dt.Columns.Add("SteelCost")
        End If
        Dim cmd As New SqlCommand("DECLARE @PoundsUsed float = (SELECT isnull(SUM(UsageWeight), 0) FROM SteelUsageTable  WHERE UsageDate < @PostingDate AND RMID = @RMID AND Status = 'POSTED')", con)
        cmd.CommandText += " IF EXISTS(SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate < @PostingDate AND (@PoundsUsed + @LineWeight) BETWEEN LowerLimit AND UpperLimit ORDER BY TransactionNumber DESC) BEGIN"
        cmd.CommandText += " SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate < @PostingDate AND (@PoundsUsed + @LineWeight) BETWEEN LowerLimit AND UpperLimit ORDER BY TransactionNumber DESC END"
        cmd.CommandText += " ELSE BEGIN"
        cmd.CommandText += " IF EXISTS(SELECT TOP 1 ROUND(SteelReceivingLineTable.SteelExtendedCost / SteelReceivingLineTable.ReceiveWeight, 5) as SteelCostPerPound FROM SteelReceivingLineTable INNER JOIN SteelReceivingHeaderTable ON SteelReceivingLineTable.SteelReceivingHeaderKey = SteelReceivingHeaderTable.SteelReceivingHeaderKey WHERE RMID = @RMID AND ReceivingDate < @PostingDate AND SteelReceivingLineTable.LineStatus <> 'OPEN' ORDER BY ReceivingDate DESC, SteelReceivingLineTable.SteelReceivingHeaderKey DESC) BEGIN"
        cmd.CommandText += " SELECT TOP 1 ROUND(SteelReceivingLineTable.SteelExtendedCost / SteelReceivingLineTable.ReceiveWeight, 5) as SteelCostPerPound FROM SteelReceivingLineTable INNER JOIN SteelReceivingHeaderTable ON SteelReceivingLineTable.SteelReceivingHeaderKey = SteelReceivingHeaderTable.SteelReceivingHeaderKey WHERE RMID = @RMID AND ReceivingDate < @PostingDate AND SteelReceivingLineTable.LineStatus <> 'OPEN' ORDER BY ReceivingDate DESC, SteelReceivingLineTable.SteelReceivingHeaderKey DESC END"
        cmd.CommandText += " ELSE BEGIN"
        cmd.CommandText += " SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate < @PostingDate ORDER BY TransactionNumber DESC END END"

        cmd.Parameters.Add("@RMID", SqlDbType.VarChar)
        cmd.Parameters.Add("@PostingDate", SqlDbType.Date)
        cmd.Parameters.Add("@LineWeight", SqlDbType.Float)

        For Each rw As Data.DataRow In dt.Rows
            Dim cost As Double = 0D
            cmd.Parameters("@RMID").Value = rw.Item("RMID")
            cmd.Parameters("@PostingDate").Value = rw.Item("PostingDate")
            cmd.Parameters("@LineWeight").Value = rw.Item("LineWeight")

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            If obj IsNot Nothing Then
                cost = Val(obj)
            End If
            rw.Item("SteelCost") = Math.Round(cost * rw.Item("LineWeight"), 2, MidpointRounding.AwayFromZero)
        Next

    End Sub
End Module
