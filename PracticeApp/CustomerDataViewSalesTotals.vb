Imports System.Data.SqlClient

Public Class CustomerDataViewSalesTotals
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal customerID As String, ByVal DivisionID As String)
        InitializeComponent()
        lblCustomerID.Text = "Customer ID: " + customerID

        cmd = New SqlCommand("SELECT SUM(ExtendedAmount) as SalesTotal, SUM(ExtendedCOS) as TotalCost, ItemClass FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID and InvoiceDate BETWEEN @BeginDate AND @EndDate GROUP By ItemClass;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime(Today.Date.Month.ToString + "/01/" + Today.Date.Year.ToString)
        Dim endmonth As String = ""
        Dim endyear As String = Today.Date.Year.ToString
        If Today.Date.Month = 12 Then
            endmonth = "1"
            endyear = (Today.Date.Year + 1).ToString
        Else
            endmonth = (Today.Date.Month + 1).ToString
        End If

        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(endmonth + "/01/" + endyear))

        Dim MTDSalesThreaded, MTDSalesShear, MTDSalesConcrete, MTDSalesRebar, MTDSalesCDStud, MTDSalesEquipSales, MTDSalesEquipRental, MTDSalesFerrules, MTDSalesOthers As Double
        Dim MTDCostThreaded, MTDCostShear, MTDCostConcrete, MTDCostRebar, MTDCostCDStud, MTDCostEquipSales, MTDCostEquipRental, MTDCostFerrules, MTDCostOthers As Double

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                Select Case reader.Item("ItemClass")
                    Case "TW TP", "TW TF", "TW TT", "TW TR"
                        MTDSalesThreaded += reader.Item("SalesTotal")
                        MTDCostThreaded += reader.Item("TotalCost")
                    Case "TW SC", "TW DS", "TW PS"
                        MTDSalesShear += reader.Item("SalesTotal")
                        MTDCostShear += reader.Item("TotalCost")
                    Case "TW CA"
                        MTDSalesConcrete += reader.Item("SalesTotal")
                        MTDCostConcrete += reader.Item("TotalCost")
                    Case "TW DB"
                        MTDSalesRebar += reader.Item("SalesTotal")
                        MTDCostRebar += reader.Item("TotalCost")
                    Case "TW CD", "TW IT", "TW KO", "TW NT", "TW RA", "TW SH", "TW SK", "TW TD"
                        MTDSalesCDStud += reader.Item("SalesTotal")
                        MTDCostCDStud += reader.Item("TotalCost")
                    Case "TWE GENERATORS", "TWE ASSEMBLIES"
                        MTDSalesEquipSales += reader.Item("SalesTotal")
                        MTDCostEquipSales += reader.Item("TotalCost")
                    Case "RENTAL"
                        MTDSalesEquipRental += reader.Item("SalesTotal")
                        MTDCostEquipRental += reader.Item("TotalCost")
                    Case "TW FER", "WC FERRULES", "FERRULE"
                        MTDSalesFerrules += reader.Item("SalesTotal")
                        MTDCostFerrules += reader.Item("TotalCost")
                    Case Else
                        MTDSalesOthers += reader.Item("SalesTotal")
                        MTDCostOthers += reader.Item("TotalCost")
                End Select
            End While
        End If
        reader.Close()
        ''Sales for MTD
        lblMTDSalesThreaded.Text = FormatCurrency(MTDSalesThreaded)
        lblMTDSalesShear.Text = FormatCurrency(MTDSalesShear)
        lblMTDSalesConcrete.Text = FormatCurrency(MTDSalesConcrete)
        lblMTDSalesRebar.Text = FormatCurrency(MTDSalesRebar)
        lblMTDSalesCDStuds.Text = FormatCurrency(MTDSalesCDStud)
        lblMTDSalesEquipSales.Text = FormatCurrency(MTDSalesEquipSales)
        lblMTDSalesEquipRental.Text = FormatCurrency(MTDSalesEquipRental)
        lblMTDSalesFerrules.Text = FormatCurrency(MTDSalesFerrules)
        lblMTDSalesOthers.Text = FormatCurrency(MTDSalesOthers)
        ''Cost for MTD
        lblMTDCostThreaded.Text = FormatCurrency(MTDCostThreaded)
        lblMTDCostShear.Text = FormatCurrency(MTDCostShear)
        lblMTDCostConcrete.Text = FormatCurrency(MTDCostConcrete)
        lblMTDCostRebar.Text = FormatCurrency(MTDCostRebar)
        lblMTDCostCDStuds.Text = FormatCurrency(MTDCostCDStud)
        lblMTDCostEquipSales.Text = FormatCurrency(MTDCostEquipSales)
        lblMTDCostEquipRental.Text = FormatCurrency(MTDCostEquipRental)
        lblMTDCostFerrules.Text = FormatCurrency(MTDCostFerrules)
        lblMTDCostOthers.Text = FormatCurrency(MTDCostOthers)
        ''margins for MTD
        If (MTDSalesThreaded <> 0 And MTDCostThreaded <> 0) Then
            lblMTDMarginThreaded.Text = Math.Round(((MTDSalesThreaded - MTDCostThreaded) / MTDCostThreaded) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostThreaded = 0 And MTDSalesThreaded <> 0 Then
            lblMTDMarginThreaded.Text = Math.Round(((MTDSalesThreaded - MTDCostThreaded) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginThreaded.Text = "0%"
        End If
        If (MTDSalesShear <> 0 And MTDCostShear <> 0) Then
            lblMTDMarginShear.Text = Math.Round(((MTDSalesShear - MTDCostShear) / MTDCostShear) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostShear = 0 And MTDSalesShear <> 0 Then
            lblMTDMarginShear.Text = Math.Round(((MTDSalesShear - MTDCostShear) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginShear.Text = "0%"
        End If
        If (MTDSalesConcrete <> 0 And MTDCostConcrete <> 0) Then
            lblMTDMarginConcrete.Text = Math.Round(((MTDSalesConcrete - MTDCostConcrete) / MTDCostConcrete) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostConcrete = 0 And MTDSalesConcrete <> 0 Then
            lblMTDMarginConcrete.Text = Math.Round(((MTDSalesConcrete - MTDCostConcrete) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginConcrete.Text = "0%"
        End If
        If (MTDSalesRebar <> 0 And MTDCostRebar <> 0) Then
            lblMTDMarginRebar.Text = Math.Round(((MTDSalesRebar - MTDCostRebar) / MTDCostRebar) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostRebar = 0 And MTDSalesRebar <> 0 Then
            lblMTDMarginRebar.Text = Math.Round(((MTDSalesRebar - MTDCostRebar) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginRebar.Text = "0%"
        End If
        If (MTDSalesCDStud <> 0 And MTDCostCDStud <> 0) Then
            lblMTDMarginCDStuds.Text = Math.Round(((MTDSalesCDStud - MTDCostCDStud) / MTDCostCDStud) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostCDStud = 0 And MTDSalesCDStud <> 0 Then
            lblMTDMarginCDStuds.Text = Math.Round(((MTDSalesCDStud - MTDCostCDStud) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginCDStuds.Text = "0%"
        End If
        If (MTDSalesEquipSales <> 0 And MTDCostEquipSales <> 0) Then
            lblMTDMarginEquipSales.Text = Math.Round(((MTDSalesEquipSales - MTDCostEquipSales) / MTDCostEquipSales) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostEquipSales = 0 And MTDSalesEquipSales <> 0 Then
            lblMTDMarginEquipSales.Text = Math.Round(((MTDSalesEquipSales - MTDCostEquipSales) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginEquipSales.Text = "0%"
        End If
        If (MTDSalesEquipRental <> 0 And MTDCostEquipRental <> 0) Then
            lblMTDMarginEquipRental.Text = Math.Round(((MTDSalesEquipRental - MTDCostEquipRental) / MTDCostEquipRental) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostEquipRental = 0 And MTDSalesEquipRental <> 0 Then
            lblMTDMarginEquipRental.Text = Math.Round(((MTDSalesEquipRental - MTDCostEquipRental) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginEquipRental.Text = "0%"
        End If
        If (MTDSalesFerrules <> 0 And MTDCostFerrules <> 0) Then
            lblMTDMarginFerrules.Text = Math.Round(((MTDSalesFerrules - MTDCostFerrules) / MTDCostFerrules) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostFerrules = 0 And MTDSalesFerrules <> 0 Then
            lblMTDMarginFerrules.Text = Math.Round(((MTDSalesFerrules - MTDCostFerrules) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginFerrules.Text = "0%"
        End If
        If (MTDSalesOthers <> 0 And MTDCostOthers <> 0) Then
            lblMTDMarginOthers.Text = Math.Round(((MTDSalesOthers - MTDCostOthers) / MTDCostOthers) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostOthers = 0 And MTDSalesOthers <> 0 Then
            lblMTDMarginOthers.Text = Math.Round(((MTDSalesOthers - MTDCostOthers) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginOthers.Text = "0%"
        End If
        ''Total Sales for MTD
        Dim MTDSalesTotal As Double = MTDSalesThreaded + MTDSalesShear + MTDSalesConcrete + MTDSalesRebar + MTDSalesCDStud + MTDSalesEquipSales + MTDSalesEquipRental + MTDSalesFerrules + MTDSalesOthers
        lblMTDSalesTotal.Text = FormatCurrency(MTDSalesTotal)
        ''Total Cost for MTD
        Dim MTDCostTotal As Double = MTDCostThreaded + MTDCostShear + MTDCostConcrete + MTDCostRebar + MTDCostCDStud + MTDCostEquipSales + MTDCostEquipRental + MTDCostFerrules + MTDCostOthers
        lblMTDCostTotal.Text = FormatCurrency(MTDCostTotal)
        ''Total Margin for MTD
        If (MTDSalesTotal <> 0 And MTDCostTotal <> 0) Then
            lblMTDMarginTotal.Text = Math.Round(((MTDSalesTotal - MTDCostTotal) / MTDCostTotal) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf MTDCostTotal = 0 And MTDSalesTotal <> 0 Then
            lblMTDMarginTotal.Text = Math.Round(((MTDSalesTotal - MTDCostTotal) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblMTDMarginTotal.Text = "0%"
        End If

        cmd = New SqlCommand("SELECT SUM(ExtendedAmount) as SalesTotal, SUM(ExtendedCOS) as TotalCost, ItemClass FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID and InvoiceDate BETWEEN @BeginDate AND @EndDate GROUP By ItemClass;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        If Today.Date.Month < 5 Then
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + (Today.Date.Year - 1).ToString)
        Else
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + Today.Date.Year.ToString)
        End If

        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Today.Date

        Dim YTDSalesThreaded, YTDSalesShear, YTDSalesConcrete, YTDSalesRebar, YTDSalesCDStud, YTDSalesEquipSales, YTDSalesEquipRental, YTDSalesFerrules, YTDSalesOthers As Double
        Dim YTDCostThreaded, YTDCostShear, YTDCostConcrete, YTDCostRebar, YTDCostCDStud, YTDCostEquipSales, YTDCostEquipRental, YTDCostFerrules, YTDCostOthers As Double
        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                Select Case reader.Item("ItemClass")
                    Case "TW TP", "TW TF", "TW TT", "TW TR"
                        YTDSalesThreaded += reader.Item("SalesTotal")
                        YTDCostThreaded += reader.Item("TotalCost")
                    Case "TW SC", "TW DS", "TW PS"
                        YTDSalesShear += reader.Item("SalesTotal")
                        YTDCostShear += reader.Item("TotalCost")
                    Case "TW CA"
                        YTDSalesConcrete += reader.Item("SalesTotal")
                        YTDCostConcrete += reader.Item("TotalCost")
                    Case "TW DB"
                        YTDSalesRebar += reader.Item("SalesTotal")
                        YTDCostRebar += reader.Item("TotalCost")
                    Case "TW CD", "TW IT", "TW KO", "TW NT", "TW RA", "TW SH", "TW SK", "TW TD"
                        YTDSalesCDStud += reader.Item("SalesTotal")
                        YTDCostCDStud += reader.Item("TotalCost")
                    Case "TWE GENERATORS", "TWE ASSEMBLIES"
                        YTDSalesEquipSales += reader.Item("SalesTotal")
                        YTDCostEquipSales += reader.Item("TotalCost")
                    Case "RENTAL"
                        YTDSalesEquipRental += reader.Item("SalesTotal")
                        YTDCostEquipRental += reader.Item("TotalCost")
                    Case "TW FER", "WC FERRULES", "FERRULE"
                        YTDSalesFerrules += reader.Item("SalesTotal")
                        YTDCostFerrules += reader.Item("TotalCost")
                    Case Else
                        YTDSalesOthers += reader.Item("SalesTotal")
                        YTDCostOthers += reader.Item("TotalCost")
                End Select
            End While
        End If
        reader.Close()
        lblYTDSalesThreaded.Text = FormatCurrency(YTDSalesThreaded)
        lblYTDSalesShear.Text = FormatCurrency(YTDSalesShear)
        lblYTDSalesConcrete.Text = FormatCurrency(YTDSalesConcrete)
        lblYTDSalesRebar.Text = FormatCurrency(YTDSalesRebar)
        lblYTDSalesCDStuds.Text = FormatCurrency(YTDSalesCDStud)
        lblYTDSalesEquipSales.Text = FormatCurrency(YTDSalesEquipSales)
        lblYTDSalesEquipRental.Text = FormatCurrency(YTDSalesEquipRental)
        lblYTDSalesFerrules.Text = FormatCurrency(YTDSalesFerrules)
        lblYTDSalesOthers.Text = FormatCurrency(YTDSalesOthers)

        lblYTDCostThreaded.Text = FormatCurrency(YTDCostThreaded)
        lblYTDCostShear.Text = FormatCurrency(YTDCostShear)
        lblYTDCostConcrete.Text = FormatCurrency(YTDCostConcrete)
        lblYTDCostRebar.Text = FormatCurrency(YTDCostRebar)
        lblYTDCostCDStuds.Text = FormatCurrency(YTDCostCDStud)
        lblYTDCostEquipSales.Text = FormatCurrency(YTDCostEquipSales)
        lblYTDCostEquipRental.Text = FormatCurrency(YTDCostEquipRental)
        lblYTDCostFerrules.Text = FormatCurrency(YTDCostFerrules)
        lblYTDCostOthers.Text = FormatCurrency(YTDCostOthers)

        ''margins for YTD
        If (YTDSalesThreaded <> 0 And YTDCostThreaded <> 0) Then
            lblYTDMarginThreaded.Text = Math.Round(((YTDSalesThreaded - YTDCostThreaded) / YTDCostThreaded) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostThreaded = 0 And YTDSalesThreaded <> 0 Then
            lblYTDMarginThreaded.Text = Math.Round(((YTDSalesThreaded - YTDCostThreaded) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginThreaded.Text = "0%"
        End If
        If (YTDSalesShear <> 0 And YTDCostShear <> 0) Then
            lblYTDMarginShear.Text = Math.Round(((YTDSalesShear - YTDCostShear) / YTDCostShear) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostShear = 0 And YTDSalesShear <> 0 Then
            lblYTDMarginShear.Text = Math.Round(((YTDSalesShear - YTDCostShear) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginShear.Text = "0%"
        End If
        If (YTDSalesConcrete <> 0 And YTDCostConcrete <> 0) Then
            lblYTDMarginConcrete.Text = Math.Round(((YTDSalesConcrete - YTDCostConcrete) / YTDCostConcrete) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostConcrete = 0 And YTDSalesConcrete <> 0 Then
            lblYTDMarginConcrete.Text = Math.Round(((YTDSalesConcrete - YTDCostConcrete) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginConcrete.Text = "0%"
        End If
        If (YTDSalesRebar <> 0 And YTDCostRebar <> 0) Then
            lblYTDMarginRebar.Text = Math.Round(((YTDSalesRebar - YTDCostRebar) / YTDCostRebar) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostRebar = 0 And YTDSalesRebar <> 0 Then
            lblYTDMarginRebar.Text = Math.Round(((YTDSalesRebar - YTDCostRebar) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginRebar.Text = "0%"
        End If
        If (YTDSalesCDStud <> 0 And YTDCostCDStud <> 0) Then
            lblYTDMarginCDStuds.Text = Math.Round(((YTDSalesCDStud - YTDCostCDStud) / YTDCostCDStud) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostCDStud = 0 And YTDSalesCDStud <> 0 Then
            lblYTDMarginCDStuds.Text = Math.Round(((YTDSalesCDStud - YTDCostCDStud) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginCDStuds.Text = "0%"
        End If
        If (YTDSalesEquipSales <> 0 And YTDCostEquipSales <> 0) Then
            lblYTDMarginEquipSales.Text = Math.Round(((YTDSalesEquipSales - YTDCostEquipSales) / YTDCostEquipSales) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostEquipSales = 0 And YTDSalesEquipSales <> 0 Then
            lblYTDMarginEquipSales.Text = Math.Round(((YTDSalesEquipSales - YTDCostEquipSales) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginEquipSales.Text = "0%"
        End If
        If (YTDSalesEquipRental <> 0 And YTDCostEquipRental <> 0) Then
            lblYTDMarginEquipRental.Text = Math.Round(((YTDSalesEquipRental - YTDCostEquipRental) / YTDCostEquipRental) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostEquipRental = 0 And YTDSalesEquipRental <> 0 Then
            lblYTDMarginEquipRental.Text = Math.Round(((YTDSalesEquipRental - YTDCostEquipRental) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginEquipRental.Text = "0%"
        End If
        If (YTDSalesFerrules <> 0 And YTDCostFerrules <> 0) Then
            lblYTDMarginFerrules.Text = Math.Round(((YTDSalesFerrules - YTDCostFerrules) / YTDCostFerrules) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostFerrules = 0 And YTDSalesFerrules <> 0 Then
            lblYTDMarginFerrules.Text = Math.Round(((YTDSalesFerrules - YTDCostFerrules) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginFerrules.Text = "0%"
        End If
        If (YTDSalesOthers <> 0 And YTDCostOthers <> 0) Then
            lblYTDMarginOthers.Text = Math.Round(((YTDSalesOthers - YTDCostOthers) / YTDCostOthers) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostOthers = 0 And YTDSalesOthers <> 0 Then
            lblYTDMarginOthers.Text = Math.Round(((YTDSalesOthers - YTDCostOthers) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginOthers.Text = "0%"
        End If
        ''Total Sales for YTD
        Dim YTDSalesTotal As Double = YTDSalesThreaded + YTDSalesShear + YTDSalesConcrete + YTDSalesRebar + YTDSalesCDStud + YTDSalesEquipSales + YTDSalesEquipRental + YTDSalesFerrules + YTDSalesOthers
        lblYTDSalesTotal.Text = FormatCurrency(YTDSalesTotal)
        ''Total Cost for YTD
        Dim YTDCostTotal As Double = YTDCostThreaded + YTDCostShear + YTDCostConcrete + YTDCostRebar + YTDCostCDStud + YTDCostEquipSales + YTDCostEquipRental + YTDCostFerrules + YTDCostOthers
        lblYTDCostTotal.Text = FormatCurrency(YTDCostTotal)
        ''Total Margin for YTD
        If (YTDSalesTotal <> 0 And YTDCostTotal <> 0) Then
            lblYTDMarginTotal.Text = Math.Round(((YTDSalesTotal - YTDCostTotal) / YTDCostTotal) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        ElseIf YTDCostTotal = 0 And YTDSalesTotal <> 0 Then
            lblYTDMarginTotal.Text = Math.Round(((YTDSalesTotal - YTDCostTotal) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%"
        Else
            lblYTDMarginTotal.Text = "0%"
        End If

        ''Gets FY One Data
        cmd = New SqlCommand("SELECT isnull(SUM(ExtendedAmount),0) as SalesTotal, isnull(SUM(ExtendedCOS),0) as TotalCost FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID and InvoiceDate BETWEEN @BeginDate AND @EndDate;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        If Today.Date.Month < 5 Then
            lblFYOneLabel.Text = (Today.Year - 1).ToString()
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + (Today.Date.Year - 2).ToString)
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime("04/30/" + (Today.Date.Year - 1).ToString)
        Else
            lblFYOneLabel.Text = Today.Year.ToString()
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + (Today.Date.Year - 1).ToString)
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime("04/30/" + Today.Date.Year.ToString)
        End If

        Dim salesTotal As Double = 0D
        Dim costTotal As Double = 0D
        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            salesTotal = reader.Item("SalesTotal")
            costTotal = reader.Item("TotalCost")
        End If
        reader.Close()
        lblFYOneSales.Text = FormatCurrency(salesTotal)
        lblFYOneCost.Text = FormatCurrency(costTotal)

        If salesTotal <> 0 And costTotal <> 0 Then
            lblFYOneMargin.Text = Math.Round(((salesTotal - costTotal) / costTotal) * 100, 2, MidpointRounding.AwayFromZero).ToString + "%"
        ElseIf costTotal = 0 And salesTotal <> 0 Then
            lblFYOneMargin.Text = Math.Round(((salesTotal - costTotal) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString + "%"
        Else
            lblFYOneMargin.Text = "0%"
        End If

        ''Gets FY Two Data
        cmd = New SqlCommand("SELECT isnull(SUM(ExtendedAmount),0) as SalesTotal, isnull(SUM(ExtendedCOS),0) as TotalCost FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID and InvoiceDate BETWEEN @BeginDate AND @EndDate;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        If Today.Date.Month < 5 Then
            lblFYTwoLabel.Text = (Today.Year - 2).ToString()
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + (Today.Date.Year - 3).ToString)
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime("04/30/" + (Today.Date.Year - 2).ToString)
        Else
            lblFYTwoLabel.Text = (Today.Year - 1).ToString()
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + (Today.Date.Year - 2).ToString)
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime("04/30/" + (Today.Date.Year - 1).ToString)
        End If

        salesTotal = 0D
        costTotal = 0D

        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            salesTotal = reader.Item("SalesTotal")
            costTotal = reader.Item("TotalCost")
        End If
        reader.Close()
        lblFYTwoSales.Text = FormatCurrency(salesTotal)
        lblFYTwoCost.Text = FormatCurrency(costTotal)

        If salesTotal <> 0 And costTotal <> 0 Then
            lblFYTwoMargin.Text = Math.Round(((salesTotal - costTotal) / costTotal) * 100, 2, MidpointRounding.AwayFromZero).ToString + "%"
        ElseIf costTotal = 0 And salesTotal <> 0 Then
            lblFYTwoMargin.Text = Math.Round(((salesTotal - costTotal) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString + "%"
        Else
            lblFYTwoMargin.Text = "0%"
        End If

        ''Gets FY Three Data
        cmd = New SqlCommand("SELECT isnull(SUM(ExtendedAmount),0) as SalesTotal, isnull(SUM(ExtendedCOS),0) as TotalCost FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID and InvoiceDate BETWEEN @BeginDate AND @EndDate;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        If Today.Date.Month < 5 Then
            lblFYThreeLabel.Text = (Today.Year - 3).ToString()
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + (Today.Date.Year - 4).ToString)
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime("04/30/" + (Today.Date.Year - 3).ToString)
        Else
            lblFYThreeLabel.Text = (Today.Year - 2).ToString()
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = Convert.ToDateTime("05/01/" + (Today.Date.Year - 3).ToString)
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime("04/30/" + (Today.Date.Year - 2).ToString)
        End If

        salesTotal = 0D
        costTotal = 0D

        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            salesTotal = reader.Item("SalesTotal")
            costTotal = reader.Item("TotalCost")
        End If
        reader.Close()
        lblFYThreeSales.Text = FormatCurrency(salesTotal)
        lblFYThreeCost.Text = FormatCurrency(costTotal)

        If salesTotal <> 0 And costTotal <> 0 Then
            lblFYThreeMargin.Text = Math.Round(((salesTotal - costTotal) / costTotal) * 100, 2, MidpointRounding.AwayFromZero).ToString + "%"
        ElseIf costTotal = 0 And salesTotal <> 0 Then
            lblFYThreeMargin.Text = Math.Round(((salesTotal - costTotal) / 1) * 100, 2, MidpointRounding.AwayFromZero).ToString + "%"
        Else
            lblFYThreeMargin.Text = "0%"
        End If
        con.Close()
    End Sub

    Private Sub CustomerDataViewSalesTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class