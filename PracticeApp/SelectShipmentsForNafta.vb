Imports System
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class SelectShipmentsForNafta
    Inherits System.Windows.Forms.Form

    Dim NumberOfPallets, ShipmentLineCount, LastTransactionNumber, NextTransactionNumber, ShipmentNumber, ShipmentLineNumber As Integer
    Dim ThirdPartyShipper, ShipMethod, ShipVia, PartNumber, PartDescription As String
    Dim ShippingWeight, Price, LineWeight, QuantityShipped, LineBoxes, SalesTax, ExtendedAmount As Double
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry As String

    Dim LastNaftaLineNumber, NextNaftaLineNumber As Integer
    Dim ShipmentAddress1, ShipmentAddress2, ShipmentCity, ShipmentState, ShipmentZipCode, ShipmentCountry, ShipmentName, ShipToID As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, nmyAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim ShipDate As Date

    Private Sub SelectShipmentsForNafta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalNaftaCustomerID = ""
        GlobalNaftaDate = ""
    End Sub

    Private Sub SelectShipmentsForNafta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadShipments()
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

    Public Sub LoadShipments()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND ShipDate >= @ShipDate ORDER BY ShipmentNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalNaftaCustomerID
        cmd.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = GlobalNAFTAShipDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeaders.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
    End Sub

    Public Sub LoadShippingAddressFromShipment()
        'Get shipping data from shipment
        Dim ShippingAddressString As String = "SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShippingAddressCommand As New SqlCommand(ShippingAddressString, con)
        ShippingAddressCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        ShippingAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ShippingAddressCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipAddress1")) Then
                ShipmentAddress1 = ""
            Else
                ShipmentAddress1 = reader.Item("ShipAddress1")
            End If
            If IsDBNull(reader.Item("ShipAddress2")) Then
                ShipmentAddress2 = ""
            Else
                ShipmentAddress2 = reader.Item("ShipAddress2")
            End If
            If IsDBNull(reader.Item("ShipCity")) Then
                ShipmentCity = ""
            Else
                ShipmentCity = reader.Item("ShipCity")
            End If
            If IsDBNull(reader.Item("ShipState")) Then
                ShipmentState = ""
            Else
                ShipmentState = reader.Item("ShipState")
            End If
            If IsDBNull(reader.Item("ShipZip")) Then
                ShipmentZipCode = ""
            Else
                ShipmentZipCode = reader.Item("ShipZip")
            End If
            If IsDBNull(reader.Item("ShipCountry")) Then
                ShipmentCountry = ""
            Else
                ShipmentCountry = reader.Item("ShipCountry")
            End If
            If IsDBNull(reader.Item("ShipToName")) Then
                ShipmentName = ""
            Else
                ShipmentName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("ShipToID")) Then
                ShipToID = ""
            Else
                ShipToID = reader.Item("ShipToID")
            End If
        Else
            ShipmentAddress1 = ""
            ShipmentAddress2 = ""
            ShipmentCity = ""
            ShipmentState = ""
            ShipmentZipCode = ""
            ShipmentCountry = ""
            ShipmentName = ""
            ShipToID = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        For Each row As DataGridViewRow In dgvShipmentHeaders.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForNafta")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdUnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnCheckAll.Click
        For Each row As DataGridViewRow In dgvShipmentHeaders.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForNafta")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdAddToNafta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToNafta.Click
        For Each row As DataGridViewRow In dgvShipmentHeaders.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForNafta")
            If cell.Value = "SELECTED" Then
                Try
                    ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
                Catch ex As Exception
                    ShipmentNumber = 0
                End Try
                Try
                    NumberOfPallets = row.Cells("NumberOfPalletsColumn").Value
                Catch ex As Exception
                    NumberOfPallets = 0
                End Try
                Try
                    ShippingWeight = row.Cells("ShippingWeightColumn").Value
                Catch ex As Exception
                    ShippingWeight = 0
                End Try

                'Get ship to address from shipment and update Nafta Table
                GlobalShipmentNumber = ShipmentNumber

                LoadShippingAddressFromShipment()

                'Update NAFTA Table with address
                cmd = New SqlCommand("UPDATE ShipmentNaftaTable SET ShipToID = @ShipToID, ShipToName = @ShipToName, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, ZipCode = @ZipCode, Country = @Country WHERE ShipmentNaftaKey = @ShipmentNaftaKey", con)

                With cmd.Parameters
                    .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey
                    .Add("@ShipToID", SqlDbType.VarChar).Value = ShipToID
                    .Add("@ShipToName", SqlDbType.VarChar).Value = ShipmentName
                    .Add("@Address1", SqlDbType.VarChar).Value = ShipmentAddress1
                    .Add("@Address2", SqlDbType.VarChar).Value = ShipmentAddress2
                    .Add("@City", SqlDbType.VarChar).Value = ShipmentCity
                    .Add("@State", SqlDbType.VarChar).Value = ShipmentState
                    .Add("@ZipCode", SqlDbType.VarChar).Value = ShipmentZipCode
                    .Add("@Country", SqlDbType.VarChar).Value = ShipmentCountry
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Count Lines in selected shipment
                Dim CountShipmentLinesString As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim CountShipmentLinesCommand As New SqlCommand(CountShipmentLinesString, con)
                CountShipmentLinesCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                CountShipmentLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ShipmentLineCount = CInt(CountShipmentLinesCommand.ExecuteScalar)
                Catch ex As Exception
                    ShipmentLineCount = 0
                End Try
                con.Close()

                ShipmentLineNumber = 1

                'Run FOR/NEXT Loop to extract line data for shipment
                For i As Integer = 1 To ShipmentLineCount
                    Dim GetLineDataString As String = "SELECT * FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim GetLineDataCommand As New SqlCommand(GetLineDataString, con)
                    GetLineDataCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    GetLineDataCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader As SqlDataReader = GetLineDataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("PartNumber")) Then
                            PartNumber = ""
                        Else
                            PartNumber = reader.Item("PartNumber")
                        End If
                        If IsDBNull(reader.Item("PartDescription")) Then
                            PartDescription = ""
                        Else
                            PartDescription = reader.Item("PartDescription")
                        End If
                        If IsDBNull(reader.Item("QuantityShipped")) Then
                            QuantityShipped = 0
                        Else
                            QuantityShipped = reader.Item("QuantityShipped")
                        End If
                        If IsDBNull(reader.Item("Price")) Then
                            Price = 0
                        Else
                            Price = reader.Item("Price")
                        End If
                        If IsDBNull(reader.Item("ExtendedAmount")) Then
                            ExtendedAmount = 0
                        Else
                            ExtendedAmount = reader.Item("ExtendedAmount")
                        End If
                        If IsDBNull(reader.Item("LineBoxes")) Then
                            LineBoxes = 0
                        Else
                            LineBoxes = reader.Item("LineBoxes")
                        End If
                        If IsDBNull(reader.Item("LineWeight")) Then
                            LineWeight = 0
                        Else
                            LineWeight = reader.Item("LineWeight")
                        End If
                    Else
                        PartNumber = ""
                        PartDescription = ""
                        QuantityShipped = 0
                        Price = 0
                        ExtendedAmount = 0
                        LineBoxes = 0
                        LineWeight = 0
                    End If
                    reader.Close()
                    con.Close()

                    'Get Item Class of Part Number
                    Dim ItemClass As String = ""
                    Dim ProductClass As String = ""

                    Dim GetItemClassString As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim GetItemClassCommand As New SqlCommand(GetItemClassString, con)
                    GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        ItemClass = ""
                    End Try
                    con.Close()

                    Select Case ItemClass
                        Case "TW CA", "TW CD", "TW DS", "TW PS", "TW TT", "TW TP", "TW NT", "TW DB", "TW CS", "TW TF", "TW SC", "TW RA", "TW TR", "TW TD", "TW KO", "TW IT", "TW FER", "TW SWR", "TW GS"
                            ProductClass = "STEEL WELD STUDS WITH FERRULES"
                        Case "TW WELD PROD", "TWE ASSEMBLIES", "TWE CD COMPONENTS", "TWE STUD EQUIP COMP", "TWE GENERATORS", "TWE REPAIR", "TWE TFP MACHINE COST"
                            ProductClass = "WELDER AND WELDER ACCESSORIES"
                        Case "FERRULE"
                            ProductClass = "STEEL WELD STUDS WITH FERRULES"
                        Case Else
                            ProductClass = "STEEL FASTENERS"
                    End Select

                    'Get new Line Number
                    Dim GetNextLineString As String = "SELECT MAX(ShipmentNaftaLineKey) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
                    Dim GetNextLineCommand As New SqlCommand(GetNextLineString, con)
                    GetNextLineCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastNaftaLineNumber = CInt(GetNextLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastNaftaLineNumber = 0
                    End Try
                    con.Close()

                    NextNaftaLineNumber = LastNaftaLineNumber + 1

                    'Update for TWE 9-20-2022: Replaces STEEL FASTENERS With WELDER AND WELDER ACCESSORIES For TWE 
                    If GlobalDivisionCode = "TWE" Then
                        If PartNumber = "REPAIR" Or PartNumber = "MISC ITEM" Then
                            ProductClass = "WELDER AND WELDER ACCESSORIES"
                        End If
                    End If

                    'Insert Data into Line Table
                    cmd = New SqlCommand("INSERT INTO ShipmentNaftaLineTable (ShipmentNaftaKey, ShipmentNaftaLineKey, ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, UnitPrice, ExtendedAmount, LineBoxes, LineWeight, Class) values (@ShipmentNaftaKey, @ShipmentNaftaLineKey, @ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @UnitPrice, @ExtendedAmount, @LineBoxes, @LineWeight, @Class)", con)

                    With cmd.Parameters
                        .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey
                        .Add("@ShipmentNaftaLineKey", SqlDbType.VarChar).Value = NextNaftaLineNumber
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                        .Add("@QuantityShipped", SqlDbType.VarChar).Value = QuantityShipped
                        .Add("@UnitPrice", SqlDbType.VarChar).Value = Price
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                        .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                        .Add("@Class", SqlDbType.VarChar).Value = ProductClass
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ShipmentLineNumber = ShipmentLineNumber + 1
                Next i

                'Clear variables from Shipment
                ShipmentNumber = 0
                GlobalShipmentNumber = 0
                NumberOfPallets = 0
                ShippingWeight = 0
                ShipToID = ""
                ShipmentName = ""
                ShipmentAddress1 = ""
                ShipmentAddress2 = ""
                ShipmentCity = ""
                ShipmentState = ""
                ShipmentZipCode = ""
                ShipmentCountry = ""
            Else
                'Skip to next line
            End If
        Next

        'Get Line Totals
        Dim SumLineBoxes, SumLineWeight, SumExtendedAmount As Double

        Dim SumLineBoxesString As String = "SELECT SUM(LineBoxes) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim SumLineBoxesCommand As New SqlCommand(SumLineBoxesString, con)
        SumLineBoxesCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey

        Dim SumLineWeightString As String = "SELECT SUM(LineWeight) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim SumLineWeightCommand As New SqlCommand(SumLineWeightString, con)
        SumLineWeightCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey

        Dim SumExtendedAmountString As String = "SELECT SUM(ExtendedAmount) FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey"
        Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountString, con)
        SumExtendedAmountCommand.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumLineBoxes = CDbl(SumLineBoxesCommand.ExecuteScalar)
        Catch ex As Exception
            SumLineBoxes = 0
        End Try
        Try
            SumLineWeight = CDbl(SumLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            SumLineWeight = 0
        End Try
        Try
            SumExtendedAmount = CDbl(SumExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            SumExtendedAmount = 0
        End Try
        con.Close()

        SumLineBoxes = Math.Round(SumLineBoxes, 0)
        SumLineWeight = Math.Round(SumLineWeight, 0)
        SumExtendedAmount = Math.Round(SumExtendedAmount, 2)

        'Update NAFTA Header Table
        cmd = New SqlCommand("UPDATE ShipmentNaftaTable SET TotalBoxes = @TotalBoxes, TotalWeight = @TotalWeight, TotalAmount = @TotalAmount WHERE ShipmentNaftaKey = @ShipmentNaftaKey", con)

        With cmd.Parameters
            .Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey
            .Add("@TotalBoxes", SqlDbType.VarChar).Value = SumLineBoxes
            .Add("@TotalWeight", SqlDbType.VarChar).Value = SumLineWeight
            .Add("@TotalAmount", SqlDbType.VarChar).Value = SumExtendedAmount
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("Shipments have been added.", MsgBoxStyle.OkOnly)

        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalNaftaCustomerID = ""
        GlobalNaftaDate = ""

        Me.Dispose()
        Me.Close()
    End Sub
End Class