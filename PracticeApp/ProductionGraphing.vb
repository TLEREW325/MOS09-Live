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
Public Class ProductionGraphing
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim dt As DataTable

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim TotalProduction, TotalInventory, AverageProduction As Integer
    Dim CurrentMonth As String = ""
    Dim CurrentYear As String = ""
    Dim CurrentMonthNumber As String = ""
    Dim BeginDate, EndDate As String
    Dim AverageDays As Integer = 0

    Dim ProductionDay1, ProductionDay2, ProductionDay3, ProductionDay4, ProductionDay5, ProductionDay6, ProductionDay7, ProductionDay8, ProductionDay9, ProductionDay10, ProductionDay11, ProductionDay12, ProductionDay13, ProductionDay14, ProductionDay15, ProductionDay16, ProductionDay17, ProductionDay18, ProductionDay19, ProductionDay20, ProductionDay21, ProductionDay22, ProductionDay23, ProductionDay24, ProductionDay25, ProductionDay26, ProductionDay27, ProductionDay28, ProductionDay29, ProductionDay30, ProductionDay31 As Integer
    Dim strProductionDay1, strProductionDay2, strProductionDay3, strProductionDay4, strProductionDay5, strProductionDay6, strProductionDay7, strProductionDay8, strProductionDay9, strProductionDay10, strProductionDay11, strProductionDay12, strProductionDay13, strProductionDay14, strProductionDay15, strProductionDay16, strProductionDay17, strProductionDay18, strProductionDay19, strProductionDay20, strProductionDay21, strProductionDay22, strProductionDay23, strProductionDay24, strProductionDay25, strProductionDay26, strProductionDay27, strProductionDay28, strProductionDay29, strProductionDay30, strProductionDay31 As String
    Dim LabelDate1, LabelDate2, LabelDate3, LabelDate4, LabelDate5, LabelDate6, LabelDate7, LabelDate8, LabelDate9, LabelDate10, LabelDate11, LabelDate12, LabelDate13, LabelDate14, LabelDate15, LabelDate16, LabelDate17, LabelDate18, LabelDate19, LabelDate20, LabelDate21, LabelDate22, LabelDate23, LabelDate24, LabelDate25, LabelDate26, LabelDate27, LabelDate28, LabelDate29, LabelDate30, LabelDate31 As String
    Dim QueryDate1, QueryDate2, QueryDate3, QueryDate4, QueryDate5, QueryDate6, QueryDate7, QueryDate8, QueryDate9, QueryDate10, QueryDate11, QueryDate12, QueryDate13, QueryDate14, QueryDate15, QueryDate16, QueryDate17, QueryDate18, QueryDate19, QueryDate20, QueryDate21, QueryDate22, QueryDate23, QueryDate24, QueryDate25, QueryDate26, QueryDate27, QueryDate28, QueryDate29, QueryDate30, QueryDate31 As String

    Private Sub ProductionGraphing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.MachineTable' table. You can move, or remove it, as needed.
        Me.MachineTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.MachineTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If

        ClearVariables()
        ClearData()
        DefineGraphingBar()
        gpxGraph.Visible = False
    End Sub

    Public Sub ClearData()
        cboMachineNumber.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
        cboYear.SelectedIndex = -1

        lblAverageProduction.Text = ""
        lblTotalInventory.Text = "'"
        lblTotalProduction.Text = ""

        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label15.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        Label20.Text = ""
        Label21.Text = ""
        Label22.Text = ""
        Label23.Text = ""
        Label24.Text = ""
        Label25.Text = ""
        Label26.Text = ""
        Label27.Text = ""
        Label28.Text = ""
        Label29.Text = ""
        Label30.Text = ""
        Label31.Text = ""

        Date1.Text = ""
        Date2.Text = ""
        Date3.Text = ""
        Date4.Text = ""
        Date5.Text = ""
        Date6.Text = ""
        Date7.Text = ""
        Date8.Text = ""
        Date9.Text = ""
        Date10.Text = ""
        Date11.Text = ""
        Date12.Text = ""
        Date13.Text = ""
        Date14.Text = ""
        Date15.Text = ""
        Date16.Text = ""
        Date17.Text = ""
        Date18.Text = ""
        Date19.Text = ""
        Date20.Text = ""
        Date21.Text = ""
        Date22.Text = ""
        Date23.Text = ""
        Date24.Text = ""
        Date25.Text = ""
        Date26.Text = ""
        Date27.Text = ""
        Date28.Text = ""
        Date29.Text = ""
        Date30.Text = ""
        Date31.Text = ""

        PBTimerBar.Value = 0
    End Sub

    Public Sub ClearProgressBars()
        PBDayOne.Value = 0
        PBDayTwo.Value = 0
        PBDayThree.Value = 0
        PBDayFour.Value = 0
        PBDayFive.Value = 0
        PBDaySix.Value = 0
        PBDaySeven.Value = 0
        PBDayEight.Value = 0
        PBDayNine.Value = 0
        PBDayTen.Value = 0
        PBDayEleven.Value = 0
        PBDayTwelve.Value = 0
        PBDayThirteen.Value = 0
        PBDayFourteen.Value = 0
        PBDayFifteen.Value = 0
        PBDaySixteen.Value = 0
        PBDaySeventeen.Value = 0
        PBDayEighteen.Value = 0
        PBDayNineteen.Value = 0
        PBDayTwenty.Value = 0
        PBDayTwentyOne.Value = 0
        PBDayTwentyTwo.Value = 0
        PBDayTwentyThree.Value = 0
        PBDayTwentyFour.Value = 0
        PBDayTwentyFive.Value = 0
        PBDayTwentySix.Value = 0
        PBDayTwentySeven.Value = 0
        PBDayTwentyEight.Value = 0
        PBDayTwentyNine.Value = 0
        PBDayThirty.Value = 0
        PBDayThirtyOne.Value = 0

    End Sub

    Public Sub ClearVariables()
        TotalProduction = 0
        TotalInventory = 0
        AverageProduction = 0
        CurrentMonth = ""
        CurrentYear = ""
        CurrentMonthNumber = ""
        BeginDate = ""
        EndDate = ""
        ProductionDay1 = 0
        ProductionDay2 = 0
        ProductionDay3 = 0
        ProductionDay4 = 0
        ProductionDay5 = 0
        ProductionDay6 = 0
        ProductionDay7 = 0
        ProductionDay8 = 0
        ProductionDay9 = 0
        ProductionDay10 = 0
        ProductionDay11 = 0
        ProductionDay12 = 0
        ProductionDay13 = 0
        ProductionDay14 = 0
        ProductionDay15 = 0
        ProductionDay16 = 0
        ProductionDay17 = 0
        ProductionDay18 = 0
        ProductionDay19 = 0
        ProductionDay20 = 0
        ProductionDay21 = 0
        ProductionDay22 = 0
        ProductionDay23 = 0
        ProductionDay24 = 0
        ProductionDay25 = 0
        ProductionDay26 = 0
        ProductionDay27 = 0
        ProductionDay28 = 0
        ProductionDay29 = 0
        ProductionDay30 = 0
        ProductionDay31 = 0
        strProductionDay1 = ""
        strProductionDay2 = ""
        strProductionDay3 = ""
        strProductionDay4 = ""
        strProductionDay5 = ""
        strProductionDay6 = ""
        strProductionDay7 = ""
        strProductionDay8 = ""
        strProductionDay9 = ""
        strProductionDay10 = ""
        strProductionDay11 = ""
        strProductionDay12 = ""
        strProductionDay13 = ""
        strProductionDay14 = ""
        strProductionDay15 = ""
        strProductionDay16 = ""
        strProductionDay17 = ""
        strProductionDay18 = ""
        strProductionDay19 = ""
        strProductionDay20 = ""
        strProductionDay21 = ""
        strProductionDay22 = ""
        strProductionDay23 = ""
        strProductionDay24 = ""
        strProductionDay25 = ""
        strProductionDay26 = ""
        strProductionDay27 = ""
        strProductionDay28 = ""
        strProductionDay29 = ""
        strProductionDay30 = ""
        strProductionDay31 = ""
        LabelDate1 = ""
        LabelDate2 = ""
        LabelDate3 = ""
        LabelDate4 = ""
        LabelDate5 = ""
        LabelDate6 = ""
        LabelDate7 = ""
        LabelDate8 = ""
        LabelDate9 = ""
        LabelDate10 = ""
        LabelDate11 = ""
        LabelDate12 = ""
        LabelDate13 = ""
        LabelDate14 = ""
        LabelDate15 = ""
        LabelDate16 = ""
        LabelDate17 = ""
        LabelDate18 = ""
        LabelDate19 = ""
        LabelDate20 = ""
        LabelDate21 = ""
        LabelDate22 = ""
        LabelDate23 = ""
        LabelDate24 = ""
        LabelDate25 = ""
        LabelDate26 = ""
        LabelDate27 = ""
        LabelDate28 = ""
        LabelDate29 = ""
        LabelDate30 = ""
        LabelDate31 = ""
        QueryDate1 = ""
        QueryDate2 = ""
        QueryDate3 = ""
        QueryDate4 = ""
        QueryDate5 = ""
        QueryDate6 = ""
        QueryDate7 = ""
        QueryDate8 = ""
        QueryDate9 = ""
        QueryDate10 = ""
        QueryDate11 = ""
        QueryDate12 = ""
        QueryDate13 = ""
        QueryDate14 = ""
        QueryDate15 = ""
        QueryDate16 = ""
        QueryDate17 = ""
        QueryDate18 = ""
        QueryDate19 = ""
        QueryDate20 = ""
        QueryDate21 = ""
        QueryDate22 = ""
        QueryDate23 = ""
        QueryDate24 = ""
        QueryDate25 = ""
        QueryDate26 = ""
        QueryDate27 = ""
        QueryDate28 = ""
        QueryDate29 = ""
        QueryDate30 = ""
        QueryDate31 = ""
    End Sub

    Public Sub LoadProductionTotals()
        Dim GetTotalProductionStatement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim GetTotalProductionCommand As New SqlCommand(GetTotalProductionStatement, con)
        GetTotalProductionCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetTotalProductionCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        GetTotalProductionCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim GetTotalInventoryStatement As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim GetTotalInventoryCommand As New SqlCommand(GetTotalInventoryStatement, con)
        GetTotalInventoryCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetTotalInventoryCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        GetTotalInventoryCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalProduction = CInt(GetTotalProductionCommand.ExecuteScalar)
        Catch ex As Exception
            TotalProduction = 0
        End Try
        Try
            TotalInventory = CInt(GetTotalInventoryCommand.ExecuteScalar)
        Catch ex As Exception
            TotalInventory = 0
        End Try
        con.Close()
        If AverageDays = 0 Then
            AverageProduction = 0
        Else
            AverageProduction = TotalProduction / AverageDays
            AverageProduction = Math.Round(AverageProduction, 0)
        End If

        lblTotalProduction.Text = TotalProduction
        lblTotalInventory.Text = TotalInventory
        lblAverageProduction.Text = AverageProduction
    End Sub

    Public Sub DefineMonth()
        CurrentMonth = cboMonth.Text

        Select Case CurrentMonth
            Case "January"
                BeginDate = "1/1/" + cboYear.Text
                EndDate = "1/31/" + cboYear.Text
                AverageDays = 31
            Case "February"
                BeginDate = "2/1/" + cboYear.Text
                EndDate = "2/28/" + cboYear.Text
                AverageDays = 28
            Case "March"
                BeginDate = "3/1/" + cboYear.Text
                EndDate = "3/31/" + cboYear.Text
                AverageDays = 31
            Case "April"
                BeginDate = "4/1/" + cboYear.Text
                EndDate = "4/30/" + cboYear.Text
                AverageDays = 30
            Case "May"
                BeginDate = "5/1/" + cboYear.Text
                EndDate = "5/31/" + cboYear.Text
                AverageDays = 31
            Case "June"
                BeginDate = "6/1/" + cboYear.Text
                EndDate = "6/30/" + cboYear.Text
                AverageDays = 30
            Case "July"
                BeginDate = "7/1/" + cboYear.Text
                EndDate = "7/31/" + cboYear.Text
                AverageDays = 31
            Case "August"
                BeginDate = "8/1/" + cboYear.Text
                EndDate = "8/31/" + cboYear.Text
                AverageDays = 31
            Case "September"
                BeginDate = "9/1/" + cboYear.Text
                EndDate = "9/30/" + cboYear.Text
                AverageDays = 30
            Case "October"
                BeginDate = "10/1/" + cboYear.Text
                EndDate = "10/31/" + cboYear.Text
                AverageDays = 31
            Case "November"
                BeginDate = "11/1/" + cboYear.Text
                EndDate = "11/30/" + cboYear.Text
                AverageDays = 30
            Case "December"
                BeginDate = "12/1/" + cboYear.Text
                EndDate = "12/31/" + cboYear.Text
                AverageDays = 31
        End Select
    End Sub

    Public Sub LoadDateLabels()
        CurrentMonth = cboMonth.Text

        Select Case CurrentMonth
            Case "January"
                CurrentMonthNumber = "1"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = True
                PBDayThirtyOne.Visible = True
                Label31.Visible = True
            Case "February"
                CurrentMonthNumber = "2"

                Date29.Visible = False
                PBDayTwentyNine.Visible = False
                Label29.Visible = False

                Date30.Visible = False
                PBDayThirty.Visible = False
                Label30.Visible = False

                Date31.Visible = False
                PBDayThirtyOne.Visible = False
                Label31.Visible = False
            Case "March"
                CurrentMonthNumber = "3"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = True
                PBDayThirtyOne.Visible = True
                Label31.Visible = True
            Case "April"
                CurrentMonthNumber = "4"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = False
                PBDayThirtyOne.Visible = False
                Label31.Visible = False
            Case "May"
                CurrentMonthNumber = "5"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = True
                PBDayThirtyOne.Visible = True
                Label31.Visible = True
            Case "June"
                CurrentMonthNumber = "6"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = False
                PBDayThirtyOne.Visible = False
                Label31.Visible = False
            Case "July"
                CurrentMonthNumber = "7"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = True
                PBDayThirtyOne.Visible = True
                Label31.Visible = True
            Case "August"
                CurrentMonthNumber = "8"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = True
                PBDayThirtyOne.Visible = True
                Label31.Visible = True
            Case "September"
                CurrentMonthNumber = "9"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = False
                PBDayThirtyOne.Visible = False
                Label31.Visible = False
            Case "October"
                CurrentMonthNumber = "10"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = True
                PBDayThirtyOne.Visible = True
                Label31.Visible = True
            Case "November"
                CurrentMonthNumber = "11"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = False
                PBDayThirtyOne.Visible = False
                Label31.Visible = False
            Case "December"
                CurrentMonthNumber = "12"

                Date29.Visible = True
                PBDayTwentyNine.Visible = True
                Label29.Visible = True

                Date30.Visible = True
                PBDayThirty.Visible = True
                Label30.Visible = True

                Date31.Visible = True
                PBDayThirtyOne.Visible = True
                Label31.Visible = True
        End Select

        Date1.Text = CurrentMonthNumber + "/1/" + cboYear.Text
        Date2.Text = CurrentMonthNumber + "/2/" + cboYear.Text
        Date3.Text = CurrentMonthNumber + "/3/" + cboYear.Text
        Date4.Text = CurrentMonthNumber + "/4/" + cboYear.Text
        Date5.Text = CurrentMonthNumber + "/5/" + cboYear.Text
        Date6.Text = CurrentMonthNumber + "/6/" + cboYear.Text
        Date7.Text = CurrentMonthNumber + "/7/" + cboYear.Text
        Date8.Text = CurrentMonthNumber + "/8/" + cboYear.Text
        Date9.Text = CurrentMonthNumber + "/9/" + cboYear.Text
        Date10.Text = CurrentMonthNumber + "/10/" + cboYear.Text
        Date11.Text = CurrentMonthNumber + "/11/" + cboYear.Text
        Date12.Text = CurrentMonthNumber + "/12/" + cboYear.Text
        Date13.Text = CurrentMonthNumber + "/13/" + cboYear.Text
        Date14.Text = CurrentMonthNumber + "/14/" + cboYear.Text
        Date15.Text = CurrentMonthNumber + "/15/" + cboYear.Text
        Date16.Text = CurrentMonthNumber + "/16/" + cboYear.Text
        Date17.Text = CurrentMonthNumber + "/17/" + cboYear.Text
        Date18.Text = CurrentMonthNumber + "/18/" + cboYear.Text
        Date19.Text = CurrentMonthNumber + "/19/" + cboYear.Text
        Date20.Text = CurrentMonthNumber + "/20/" + cboYear.Text
        Date21.Text = CurrentMonthNumber + "/21/" + cboYear.Text
        Date22.Text = CurrentMonthNumber + "/22/" + cboYear.Text
        Date23.Text = CurrentMonthNumber + "/23/" + cboYear.Text
        Date24.Text = CurrentMonthNumber + "/24/" + cboYear.Text
        Date25.Text = CurrentMonthNumber + "/25/" + cboYear.Text
        Date26.Text = CurrentMonthNumber + "/26/" + cboYear.Text
        Date27.Text = CurrentMonthNumber + "/27/" + cboYear.Text
        Date28.Text = CurrentMonthNumber + "/28/" + cboYear.Text
        Date29.Text = CurrentMonthNumber + "/29/" + cboYear.Text
        Date30.Text = CurrentMonthNumber + "/30/" + cboYear.Text
        Date31.Text = CurrentMonthNumber + "/31/" + cboYear.Text

        QueryDate1 = CurrentMonthNumber + "/1/" + cboYear.Text
        QueryDate2 = CurrentMonthNumber + "/2/" + cboYear.Text
        QueryDate3 = CurrentMonthNumber + "/3/" + cboYear.Text
        QueryDate4 = CurrentMonthNumber + "/4/" + cboYear.Text
        QueryDate5 = CurrentMonthNumber + "/5/" + cboYear.Text
        QueryDate6 = CurrentMonthNumber + "/6/" + cboYear.Text
        QueryDate7 = CurrentMonthNumber + "/7/" + cboYear.Text
        QueryDate8 = CurrentMonthNumber + "/8/" + cboYear.Text
        QueryDate9 = CurrentMonthNumber + "/9/" + cboYear.Text
        QueryDate10 = CurrentMonthNumber + "/10/" + cboYear.Text
        QueryDate11 = CurrentMonthNumber + "/11/" + cboYear.Text
        QueryDate12 = CurrentMonthNumber + "/12/" + cboYear.Text
        QueryDate13 = CurrentMonthNumber + "/13/" + cboYear.Text
        QueryDate14 = CurrentMonthNumber + "/14/" + cboYear.Text
        QueryDate15 = CurrentMonthNumber + "/15/" + cboYear.Text
        QueryDate16 = CurrentMonthNumber + "/16/" + cboYear.Text
        QueryDate17 = CurrentMonthNumber + "/17/" + cboYear.Text
        QueryDate18 = CurrentMonthNumber + "/18/" + cboYear.Text
        QueryDate19 = CurrentMonthNumber + "/19/" + cboYear.Text
        QueryDate20 = CurrentMonthNumber + "/20/" + cboYear.Text
        QueryDate21 = CurrentMonthNumber + "/21/" + cboYear.Text
        QueryDate22 = CurrentMonthNumber + "/22/" + cboYear.Text
        QueryDate23 = CurrentMonthNumber + "/23/" + cboYear.Text
        QueryDate24 = CurrentMonthNumber + "/24/" + cboYear.Text
        QueryDate25 = CurrentMonthNumber + "/25/" + cboYear.Text
        QueryDate26 = CurrentMonthNumber + "/26/" + cboYear.Text
        QueryDate27 = CurrentMonthNumber + "/27/" + cboYear.Text
        QueryDate28 = CurrentMonthNumber + "/28/" + cboYear.Text
        QueryDate29 = CurrentMonthNumber + "/29/" + cboYear.Text
        QueryDate30 = CurrentMonthNumber + "/30/" + cboYear.Text
        QueryDate31 = CurrentMonthNumber + "/31/" + cboYear.Text
    End Sub

    Public Sub ClearDataLabels()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label15.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        Label20.Text = ""
        Label21.Text = ""
        Label22.Text = ""
        Label23.Text = ""
        Label24.Text = ""
        Label25.Text = ""
        Label26.Text = ""
        Label27.Text = ""
        Label28.Text = ""
        Label29.Text = ""
        Label30.Text = ""
        Label31.Text = ""
    End Sub

    Public Sub ClearDateLabels()
        Date1.Text = ""
        Date2.Text = ""
        Date3.Text = ""
        Date4.Text = ""
        Date5.Text = ""
        Date6.Text = ""
        Date7.Text = ""
        Date8.Text = ""
        Date9.Text = ""
        Date10.Text = ""
        Date11.Text = ""
        Date12.Text = ""
        Date13.Text = ""
        Date14.Text = ""
        Date15.Text = ""
        Date16.Text = ""
        Date17.Text = ""
        Date18.Text = ""
        Date19.Text = ""
        Date20.Text = ""
        Date21.Text = ""
        Date22.Text = ""
        Date23.Text = ""
        Date24.Text = ""
        Date25.Text = ""
        Date26.Text = ""
        Date27.Text = ""
        Date28.Text = ""
        Date29.Text = ""
        Date30.Text = ""
        Date31.Text = ""
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        If cboYear.Text <> "" And cboMonth.Text <> "" Then
            ClearDateLabels()
            ClearDataLabels()
            ClearProgressBars()
            LoadDateLabels()
        Else
            ClearDateLabels()
            ClearDataLabels()
            ClearProgressBars()
        End If
    End Sub

    Private Sub cboMachineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineNumber.SelectedIndexChanged
        If cboYear.Text <> "" And cboMonth.Text <> "" Then
            ClearDateLabels()
            ClearDataLabels()
            ClearProgressBars()
            LoadDateLabels()
        Else
            ClearDateLabels()
            ClearDataLabels()
            ClearProgressBars()
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If cboYear.Text <> "" And cboMonth.Text <> "" Then
            ClearDateLabels()
            ClearDataLabels()
            ClearProgressBars()
            LoadDateLabels()
        Else
            ClearDateLabels()
            ClearDataLabels()
            ClearProgressBars()
        End If
    End Sub

    Public Sub GetProductionData()
        'Determine Total Quantity Shipped
        Dim GetProductionDay1Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay1Command As New SqlCommand(GetProductionDay1Statement, con)
        GetProductionDay1Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay1Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate1

        Dim GetProductionDay2Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay2Command As New SqlCommand(GetProductionDay2Statement, con)
        GetProductionDay2Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay2Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate2

        Dim GetProductionDay3Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay3Command As New SqlCommand(GetProductionDay3Statement, con)
        GetProductionDay3Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay3Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate3

        Dim GetProductionDay4Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay4Command As New SqlCommand(GetProductionDay4Statement, con)
        GetProductionDay4Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay4Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate4

        Dim GetProductionDay5Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay5Command As New SqlCommand(GetProductionDay5Statement, con)
        GetProductionDay5Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay5Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate5

        Dim GetProductionDay6Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay6Command As New SqlCommand(GetProductionDay6Statement, con)
        GetProductionDay6Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay6Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate6

        Dim GetProductionDay7Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay7Command As New SqlCommand(GetProductionDay7Statement, con)
        GetProductionDay7Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay7Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate7

        Dim GetProductionDay8Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay8Command As New SqlCommand(GetProductionDay8Statement, con)
        GetProductionDay8Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay8Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate8

        Dim GetProductionDay9Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay9Command As New SqlCommand(GetProductionDay9Statement, con)
        GetProductionDay9Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay9Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate9

        Dim GetProductionDay10Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay10Command As New SqlCommand(GetProductionDay10Statement, con)
        GetProductionDay10Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay10Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate10

        Dim GetProductionDay11Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay11Command As New SqlCommand(GetProductionDay11Statement, con)
        GetProductionDay11Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay11Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate11

        Dim GetProductionDay12Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay12Command As New SqlCommand(GetProductionDay12Statement, con)
        GetProductionDay12Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay12Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate12

        Dim GetProductionDay13Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay13Command As New SqlCommand(GetProductionDay13Statement, con)
        GetProductionDay13Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay13Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate13

        Dim GetProductionDay14Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay14Command As New SqlCommand(GetProductionDay14Statement, con)
        GetProductionDay14Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay14Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate14

        Dim GetProductionDay15Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay15Command As New SqlCommand(GetProductionDay15Statement, con)
        GetProductionDay15Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay15Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate15

        Dim GetProductionDay16Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay16Command As New SqlCommand(GetProductionDay16Statement, con)
        GetProductionDay16Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay16Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate16

        Dim GetProductionDay17Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay17Command As New SqlCommand(GetProductionDay17Statement, con)
        GetProductionDay17Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay17Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate17

        Dim GetProductionDay18Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay18Command As New SqlCommand(GetProductionDay18Statement, con)
        GetProductionDay18Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay18Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate18

        Dim GetProductionDay19Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay19Command As New SqlCommand(GetProductionDay19Statement, con)
        GetProductionDay19Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay19Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate19

        Dim GetProductionDay20Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay20Command As New SqlCommand(GetProductionDay20Statement, con)
        GetProductionDay20Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay20Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate20

        Dim GetProductionDay21Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay21Command As New SqlCommand(GetProductionDay21Statement, con)
        GetProductionDay21Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay21Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate21

        Dim GetProductionDay22Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay22Command As New SqlCommand(GetProductionDay22Statement, con)
        GetProductionDay22Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay22Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate22

        Dim GetProductionDay23Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay23Command As New SqlCommand(GetProductionDay23Statement, con)
        GetProductionDay23Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay23Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate23

        Dim GetProductionDay24Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay24Command As New SqlCommand(GetProductionDay24Statement, con)
        GetProductionDay24Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay24Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate24

        Dim GetProductionDay25Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay25Command As New SqlCommand(GetProductionDay25Statement, con)
        GetProductionDay25Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay25Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate25

        Dim GetProductionDay26Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay26Command As New SqlCommand(GetProductionDay26Statement, con)
        GetProductionDay26Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay26Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate26

        Dim GetProductionDay27Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay27Command As New SqlCommand(GetProductionDay27Statement, con)
        GetProductionDay27Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay27Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate27

        Dim GetProductionDay28Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay28Command As New SqlCommand(GetProductionDay28Statement, con)
        GetProductionDay28Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay28Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate28

        Dim GetProductionDay29Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay29Command As New SqlCommand(GetProductionDay29Statement, con)
        GetProductionDay29Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay29Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate29

        Dim GetProductionDay30Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay30Command As New SqlCommand(GetProductionDay30Statement, con)
        GetProductionDay30Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay30Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate30

        Dim GetProductionDay31Statement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate = @PostingDate"
        Dim GetProductionDay31Command As New SqlCommand(GetProductionDay31Statement, con)
        GetProductionDay31Command.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        GetProductionDay31Command.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = QueryDate31

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductionDay1 = CInt(GetProductionDay1Command.ExecuteScalar)
            If ProductionDay1 < 0 Then ProductionDay1 = 0
            If ProductionDay1 > 200000 Then ProductionDay1 = 200000
        Catch ex As Exception
            ProductionDay1 = 0
        End Try
        Try
            ProductionDay2 = CInt(GetProductionDay2Command.ExecuteScalar)
            If ProductionDay2 < 0 Then ProductionDay2 = 0
            If ProductionDay2 > 200000 Then ProductionDay2 = 200000
        Catch ex As Exception
            ProductionDay2 = 0
        End Try
        Try
            ProductionDay3 = CInt(GetProductionDay3Command.ExecuteScalar)
            If ProductionDay3 < 0 Then ProductionDay3 = 0
            If ProductionDay3 > 200000 Then ProductionDay3 = 200000
        Catch ex As Exception
            ProductionDay3 = 0
        End Try
        Try
            ProductionDay4 = CInt(GetProductionDay4Command.ExecuteScalar)
            If ProductionDay4 < 0 Then ProductionDay4 = 0
            If ProductionDay4 > 200000 Then ProductionDay4 = 200000
        Catch ex As Exception
            ProductionDay4 = 0
        End Try
        Try
            ProductionDay5 = CInt(GetProductionDay5Command.ExecuteScalar)
            If ProductionDay5 < 0 Then ProductionDay5 = 0
            If ProductionDay5 > 200000 Then ProductionDay5 = 200000
        Catch ex As Exception
            ProductionDay5 = 0
        End Try
        Try
            ProductionDay6 = CInt(GetProductionDay6Command.ExecuteScalar)
            If ProductionDay6 < 0 Then ProductionDay6 = 0
            If ProductionDay6 > 200000 Then ProductionDay6 = 200000
        Catch ex As Exception
            ProductionDay6 = 0
        End Try
        Try
            ProductionDay7 = CInt(GetProductionDay7Command.ExecuteScalar)
            If ProductionDay7 < 0 Then ProductionDay7 = 0
            If ProductionDay7 > 200000 Then ProductionDay7 = 200000
        Catch ex As Exception
            ProductionDay7 = 0
        End Try
        Try
            ProductionDay8 = CInt(GetProductionDay8Command.ExecuteScalar)
            If ProductionDay8 < 0 Then ProductionDay8 = 0
            If ProductionDay8 > 200000 Then ProductionDay8 = 200000
        Catch ex As Exception
            ProductionDay8 = 0
        End Try
        Try
            ProductionDay9 = CInt(GetProductionDay9Command.ExecuteScalar)
            If ProductionDay9 < 0 Then ProductionDay9 = 0
            If ProductionDay9 > 200000 Then ProductionDay9 = 200000
        Catch ex As Exception
            ProductionDay9 = 0
        End Try
        Try
            ProductionDay10 = CInt(GetProductionDay10Command.ExecuteScalar)
            If ProductionDay10 < 0 Then ProductionDay10 = 0
            If ProductionDay10 > 200000 Then ProductionDay10 = 200000
        Catch ex As Exception
            ProductionDay10 = 0
        End Try
        Try
            ProductionDay11 = CInt(GetProductionDay11Command.ExecuteScalar)
            If ProductionDay11 < 0 Then ProductionDay11 = 0
            If ProductionDay11 > 200000 Then ProductionDay11 = 200000
        Catch ex As Exception
            ProductionDay11 = 0
        End Try
        Try
            ProductionDay12 = CInt(GetProductionDay12Command.ExecuteScalar)
            If ProductionDay12 < 0 Then ProductionDay12 = 0
            If ProductionDay12 > 200000 Then ProductionDay12 = 200000
        Catch ex As Exception
            ProductionDay12 = 0
        End Try
        Try
            ProductionDay13 = CInt(GetProductionDay13Command.ExecuteScalar)
            If ProductionDay13 < 0 Then ProductionDay13 = 0
            If ProductionDay13 > 200000 Then ProductionDay13 = 200000
        Catch ex As Exception
            ProductionDay13 = 0
        End Try
        Try
            ProductionDay14 = CInt(GetProductionDay14Command.ExecuteScalar)
            If ProductionDay14 < 0 Then ProductionDay14 = 0
            If ProductionDay14 > 200000 Then ProductionDay14 = 200000
        Catch ex As Exception
            ProductionDay14 = 0
        End Try
        Try
            ProductionDay15 = CInt(GetProductionDay15Command.ExecuteScalar)
            If ProductionDay15 < 0 Then ProductionDay15 = 0
            If ProductionDay15 > 200000 Then ProductionDay15 = 200000
        Catch ex As Exception
            ProductionDay15 = 0
        End Try
        Try
            ProductionDay16 = CInt(GetProductionDay16Command.ExecuteScalar)
            If ProductionDay16 < 0 Then ProductionDay16 = 0
            If ProductionDay16 > 200000 Then ProductionDay16 = 200000
        Catch ex As Exception
            ProductionDay16 = 0
        End Try
        Try
            ProductionDay17 = CInt(GetProductionDay17Command.ExecuteScalar)
            If ProductionDay17 < 0 Then ProductionDay17 = 0
            If ProductionDay17 > 200000 Then ProductionDay17 = 200000
        Catch ex As Exception
            ProductionDay17 = 0
        End Try
        Try
            ProductionDay18 = CInt(GetProductionDay18Command.ExecuteScalar)
            If ProductionDay18 < 0 Then ProductionDay18 = 0
            If ProductionDay18 > 200000 Then ProductionDay18 = 200000
        Catch ex As Exception
            ProductionDay18 = 0
        End Try
        Try
            ProductionDay19 = CInt(GetProductionDay19Command.ExecuteScalar)
            If ProductionDay19 < 0 Then ProductionDay19 = 0
            If ProductionDay19 > 200000 Then ProductionDay19 = 200000
        Catch ex As Exception
            ProductionDay19 = 0
        End Try
        Try
            ProductionDay20 = CInt(GetProductionDay20Command.ExecuteScalar)
            If ProductionDay20 < 0 Then ProductionDay20 = 0
            If ProductionDay20 > 200000 Then ProductionDay20 = 200000
        Catch ex As Exception
            ProductionDay20 = 0
        End Try
        Try
            ProductionDay21 = CInt(GetProductionDay21Command.ExecuteScalar)
            If ProductionDay21 < 0 Then ProductionDay21 = 0
            If ProductionDay21 > 200000 Then ProductionDay21 = 200000
        Catch ex As Exception
            ProductionDay21 = 0
        End Try
        Try
            ProductionDay22 = CInt(GetProductionDay22Command.ExecuteScalar)
            If ProductionDay22 < 0 Then ProductionDay22 = 0
            If ProductionDay22 > 200000 Then ProductionDay22 = 200000
        Catch ex As Exception
            ProductionDay22 = 0
        End Try
        Try
            ProductionDay23 = CInt(GetProductionDay23Command.ExecuteScalar)
            If ProductionDay23 < 0 Then ProductionDay23 = 0
            If ProductionDay23 > 200000 Then ProductionDay23 = 200000
        Catch ex As Exception
            ProductionDay23 = 0
        End Try
        Try
            ProductionDay24 = CInt(GetProductionDay24Command.ExecuteScalar)
            If ProductionDay24 < 0 Then ProductionDay24 = 0
            If ProductionDay24 > 200000 Then ProductionDay24 = 200000
        Catch ex As Exception
            ProductionDay24 = 0
        End Try
        Try
            ProductionDay25 = CInt(GetProductionDay25Command.ExecuteScalar)
            If ProductionDay25 < 0 Then ProductionDay25 = 0
            If ProductionDay25 > 200000 Then ProductionDay25 = 200000
        Catch ex As Exception
            ProductionDay25 = 0
        End Try
        Try
            ProductionDay26 = CInt(GetProductionDay26Command.ExecuteScalar)
            If ProductionDay26 < 0 Then ProductionDay26 = 0
            If ProductionDay26 > 200000 Then ProductionDay26 = 200000
        Catch ex As Exception
            ProductionDay26 = 0
        End Try
        Try
            ProductionDay27 = CInt(GetProductionDay27Command.ExecuteScalar)
            If ProductionDay27 < 0 Then ProductionDay27 = 0
            If ProductionDay27 > 200000 Then ProductionDay27 = 200000
        Catch ex As Exception
            ProductionDay27 = 0
        End Try
        Try
            ProductionDay28 = CInt(GetProductionDay28Command.ExecuteScalar)
            If ProductionDay28 < 0 Then ProductionDay28 = 0
            If ProductionDay28 > 200000 Then ProductionDay28 = 200000
        Catch ex As Exception
            ProductionDay28 = 0
        End Try
        Try
            ProductionDay29 = CInt(GetProductionDay29Command.ExecuteScalar)
            If ProductionDay29 < 0 Then ProductionDay29 = 0
            If ProductionDay29 > 200000 Then ProductionDay29 = 200000
        Catch ex As Exception
            ProductionDay29 = 0
        End Try
        Try
            ProductionDay30 = CInt(GetProductionDay30Command.ExecuteScalar)
            If ProductionDay30 < 0 Then ProductionDay30 = 0
            If ProductionDay30 > 200000 Then ProductionDay30 = 200000
        Catch ex As Exception
            ProductionDay30 = 0
        End Try
        Try
            ProductionDay31 = CInt(GetProductionDay31Command.ExecuteScalar)
            If ProductionDay31 < 0 Then ProductionDay31 = 0
            If ProductionDay31 > 200000 Then ProductionDay31 = 200000
        Catch ex As Exception
            ProductionDay31 = 0
        End Try
        con.Close()
    End Sub

    Private Sub cmdGetGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetGraph.Click
        Dim LabelString1, LabelString2, LabelString3, LabelString4, LabelString5, LabelString6, LabelString7, LabelString8, LabelString9, LabelString10, LabelString11, LabelString12, LabelString13, LabelString14, LabelString15, LabelString16, LabelString17, LabelString18, LabelString19, LabelString20, LabelString21, LabelString22, LabelString23, LabelString24, LabelString25, LabelString26, LabelString27, LabelString28, LabelString29, LabelString30, LabelString31 As String
        Dim Counter As Integer = 0

        If cboMachineNumber.Text = "" Or cboMonth.Text = "" Or cboYear.Text = "" Then
            MsgBox("You must select a machine #, month, and year to proceed.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Reset Progress Bar
        PBTimerBar.Visible = True
        PBTimerBar.Value = PBTimerBar.Minimum

        'Define Defaults and get data
        GetProductionData()

        gpxGraph.Visible = True

        Do While Counter < 10000
            PBTimerBar.PerformStep()
            Counter = Counter + 1
        Loop

        '1 Bar
        Me.PBDayOne.Value = ProductionDay1
        strProductionDay1 = CStr(ProductionDay1)
        LabelString1 = strProductionDay1 + " pieces produced"
        Label1.Text = LabelString1

        '2 Bar
        Me.PBDayTwo.Value = ProductionDay2
        strProductionDay2 = CStr(ProductionDay2)
        LabelString2 = strProductionDay2 + " pieces produced"
        Label2.Text = LabelString2

        '3 Bar
        Me.PBDayThree.Value = ProductionDay3
        strProductionDay3 = CStr(ProductionDay3)
        LabelString3 = strProductionDay3 + " pieces produced"
        Label3.Text = LabelString3

        '4 Bar
        Me.PBDayFour.Value = ProductionDay4
        strProductionDay4 = CStr(ProductionDay4)
        LabelString4 = strProductionDay4 + " pieces produced"
        Label4.Text = LabelString4

        '5 Bar
        Me.PBDayFive.Value = ProductionDay5
        strProductionDay5 = CStr(ProductionDay5)
        LabelString5 = strProductionDay5 + " pieces produced"
        Label5.Text = LabelString5

        '6 Bar
        Me.PBDaySix.Value = ProductionDay6
        strProductionDay6 = CStr(ProductionDay6)
        LabelString6 = strProductionDay6 + " pieces produced"
        Label6.Text = LabelString6

        '7 Bar
        Me.PBDaySeven.Value = ProductionDay7
        strProductionDay7 = CStr(ProductionDay7)
        LabelString7 = strProductionDay7 + " pieces produced"
        Label7.Text = LabelString7

        '8 Bar
        Me.PBDayEight.Value = ProductionDay8
        strProductionDay8 = CStr(ProductionDay8)
        LabelString8 = strProductionDay8 + " pieces produced"
        Label8.Text = LabelString8

        '9 Bar
        Me.PBDayNine.Value = ProductionDay9
        strProductionDay9 = CStr(ProductionDay9)
        LabelString9 = strProductionDay9 + " pieces produced"
        Label9.Text = LabelString9

        '10 Bar
        Me.PBDayTen.Value = ProductionDay10
        strProductionDay10 = CStr(ProductionDay10)
        LabelString10 = strProductionDay10 + " pieces produced"
        Label10.Text = LabelString10

        '11 Bar
        Me.PBDayEleven.Value = ProductionDay11
        strProductionDay11 = CStr(ProductionDay11)
        LabelString11 = strProductionDay11 + " pieces produced"
        Label11.Text = LabelString11

        '12 Bar
        Me.PBDayTwelve.Value = ProductionDay12
        strProductionDay12 = CStr(ProductionDay12)
        LabelString12 = strProductionDay12 + " pieces produced"
        Label12.Text = LabelString12

        '13 Bar
        Me.PBDayThirteen.Value = ProductionDay13
        strProductionDay13 = CStr(ProductionDay13)
        LabelString13 = strProductionDay13 + " pieces produced"
        Label13.Text = LabelString13

        '14 Bar
        Me.PBDayFourteen.Value = ProductionDay14
        strProductionDay14 = CStr(ProductionDay14)
        LabelString14 = strProductionDay14 + " pieces produced"
        Label14.Text = LabelString14

        '15 Bar
        Me.PBDayFifteen.Value = ProductionDay15
        strProductionDay15 = CStr(ProductionDay15)
        LabelString15 = strProductionDay15 + " pieces produced"
        Label15.Text = LabelString15

        '16 Bar
        Me.PBDaySixteen.Value = ProductionDay16
        strProductionDay16 = CStr(ProductionDay16)
        LabelString16 = strProductionDay16 + " pieces produced"
        Label16.Text = LabelString16

        '17 Bar
        Me.PBDaySeventeen.Value = ProductionDay17
        strProductionDay17 = CStr(ProductionDay17)
        LabelString17 = strProductionDay17 + " pieces produced"
        Label17.Text = LabelString17

        '18 Bar
        Me.PBDayEighteen.Value = ProductionDay18
        strProductionDay18 = CStr(ProductionDay18)
        LabelString18 = strProductionDay18 + " pieces produced"
        Label18.Text = LabelString18

        '19 Bar
        Me.PBDayNineteen.Value = ProductionDay19
        strProductionDay19 = CStr(ProductionDay19)
        LabelString19 = strProductionDay19 + " pieces produced"
        Label19.Text = LabelString19

        '20 Bar
        Me.PBDayTwenty.Value = ProductionDay20
        strProductionDay20 = CStr(ProductionDay20)
        LabelString20 = strProductionDay20 + " pieces produced"
        Label20.Text = LabelString20

        '21 Bar
        Me.PBDayTwentyOne.Value = ProductionDay21
        strProductionDay21 = CStr(ProductionDay21)
        LabelString21 = strProductionDay21 + " pieces produced"
        Label21.Text = LabelString21

        '22 Bar
        Me.PBDayTwentyTwo.Value = ProductionDay22
        strProductionDay22 = CStr(ProductionDay22)
        LabelString22 = strProductionDay22 + " pieces produced"
        Label22.Text = LabelString22

        '23 Bar
        Me.PBDayTwentyThree.Value = ProductionDay23
        strProductionDay23 = CStr(ProductionDay23)
        LabelString23 = strProductionDay23 + " pieces produced"
        Label23.Text = LabelString23

        '24 Bar
        Me.PBDayTwentyFour.Value = ProductionDay24
        strProductionDay24 = CStr(ProductionDay24)
        LabelString24 = strProductionDay24 + " pieces produced"
        Label24.Text = LabelString24

        '25 Bar
        Me.PBDayTwentyFive.Value = ProductionDay25
        strProductionDay25 = CStr(ProductionDay25)
        LabelString25 = strProductionDay25 + " pieces produced"
        Label25.Text = LabelString25

        '26 Bar
        Me.PBDayTwentySix.Value = ProductionDay26
        strProductionDay26 = CStr(ProductionDay26)
        LabelString26 = strProductionDay26 + " pieces produced"
        Label26.Text = LabelString26

        '27 Bar
        Me.PBDayTwentySeven.Value = ProductionDay27
        strProductionDay27 = CStr(ProductionDay27)
        LabelString27 = strProductionDay27 + " pieces produced"
        Label27.Text = LabelString27

        '28 Bar
        Me.PBDayTwentyEight.Value = ProductionDay28
        strProductionDay28 = CStr(ProductionDay28)
        LabelString28 = strProductionDay28 + " pieces produced"
        Label28.Text = LabelString28

        '29 Bar
        Me.PBDayTwentyNine.Value = ProductionDay29
        strProductionDay29 = CStr(ProductionDay29)
        LabelString29 = strProductionDay29 + " pieces produced"
        Label29.Text = LabelString29

        '30 Bar
        Me.PBDayThirty.Value = ProductionDay30
        strProductionDay30 = CStr(ProductionDay30)
        LabelString30 = strProductionDay30 + " pieces produced"
        Label30.Text = LabelString30

        '31 Bar
        Me.PBDayThirtyOne.Value = ProductionDay31
        strProductionDay31 = CStr(ProductionDay31)
        LabelString31 = strProductionDay31 + " pieces produced"
        Label31.Text = LabelString31

        'Timer bar disappears
        PBTimerBar.Visible = False

        'Load Totals
        DefineMonth()
        LoadProductionTotals()
    End Sub

    Public Sub DefineGraphingBar()
        'Set PB defaults
        Me.PBTimerBar.Maximum = 10000
        Me.PBTimerBar.Minimum = 0
        Me.PBTimerBar.Step = 1
        Me.PBTimerBar.Increment(1)

        Me.PBDayOne.Maximum = 200000
        Me.PBDayOne.Minimum = 0
        Me.PBDayOne.Step = 1
        Me.PBDayOne.Increment(1)

        Me.PBDayTwo.Maximum = 200000
        Me.PBDayTwo.Minimum = 0
        Me.PBDayTwo.Step = 1
        Me.PBDayTwo.Increment(1)

        Me.PBDayThree.Maximum = 200000
        Me.PBDayThree.Minimum = 0
        Me.PBDayThree.Step = 1
        Me.PBDayThree.Increment(1)

        Me.PBDayFour.Maximum = 200000
        Me.PBDayFour.Minimum = 0
        Me.PBDayFour.Step = 1
        Me.PBDayFour.Increment(1)

        Me.PBDayFive.Maximum = 200000
        Me.PBDayFive.Minimum = 0
        Me.PBDayFive.Step = 1
        Me.PBDayFive.Increment(1)

        Me.PBDaySix.Maximum = 200000
        Me.PBDaySix.Minimum = 0
        Me.PBDaySix.Step = 1
        Me.PBDaySix.Increment(1)

        Me.PBDaySeven.Maximum = 200000
        Me.PBDaySeven.Minimum = 0
        Me.PBDaySeven.Step = 1
        Me.PBDaySeven.Increment(1)

        Me.PBDayEight.Maximum = 200000
        Me.PBDayEight.Minimum = 0
        Me.PBDayEight.Step = 1
        Me.PBDayEight.Increment(1)

        Me.PBDayNine.Maximum = 200000
        Me.PBDayNine.Minimum = 0
        Me.PBDayNine.Step = 1
        Me.PBDayNine.Increment(1)

        Me.PBDayTen.Maximum = 200000
        Me.PBDayTen.Minimum = 0
        Me.PBDayTen.Step = 1
        Me.PBDayTen.Increment(1)

        Me.PBDayEleven.Maximum = 200000
        Me.PBDayEleven.Minimum = 0
        Me.PBDayEleven.Step = 1
        Me.PBDayEleven.Increment(1)

        Me.PBDayTwelve.Maximum = 200000
        Me.PBDayTwelve.Minimum = 0
        Me.PBDayTwelve.Step = 1
        Me.PBDayTwelve.Increment(1)

        Me.PBDayThirteen.Maximum = 200000
        Me.PBDayThirteen.Minimum = 0
        Me.PBDayThirteen.Step = 1
        Me.PBDayThirteen.Increment(1)

        Me.PBDayFourteen.Maximum = 200000
        Me.PBDayFourteen.Minimum = 0
        Me.PBDayFourteen.Step = 1
        Me.PBDayFourteen.Increment(1)

        Me.PBDayFifteen.Maximum = 200000
        Me.PBDayFifteen.Minimum = 0
        Me.PBDayFifteen.Step = 1
        Me.PBDayFifteen.Increment(1)

        Me.PBDaySixteen.Maximum = 200000
        Me.PBDaySixteen.Minimum = 0
        Me.PBDaySixteen.Step = 1
        Me.PBDaySixteen.Increment(1)

        Me.PBDaySeventeen.Maximum = 200000
        Me.PBDaySeventeen.Minimum = 0
        Me.PBDaySeventeen.Step = 1
        Me.PBDaySeventeen.Increment(1)

        Me.PBDayEighteen.Maximum = 200000
        Me.PBDayEighteen.Minimum = 0
        Me.PBDayEighteen.Step = 1
        Me.PBDayEighteen.Increment(1)

        Me.PBDayNineteen.Maximum = 200000
        Me.PBDayNineteen.Minimum = 0
        Me.PBDayNineteen.Step = 1
        Me.PBDayNineteen.Increment(1)

        Me.PBDayTwenty.Maximum = 200000
        Me.PBDayTwenty.Minimum = 0
        Me.PBDayTwenty.Step = 1
        Me.PBDayTwenty.Increment(1)

        Me.PBDayTwentyOne.Maximum = 200000
        Me.PBDayTwentyOne.Minimum = 0
        Me.PBDayTwentyOne.Step = 1
        Me.PBDayTwentyOne.Increment(1)

        Me.PBDayTwentyTwo.Maximum = 200000
        Me.PBDayTwentyTwo.Minimum = 0
        Me.PBDayTwentyTwo.Step = 1
        Me.PBDayTwentyTwo.Increment(1)

        Me.PBDayTwentyThree.Maximum = 200000
        Me.PBDayTwentyThree.Minimum = 0
        Me.PBDayTwentyThree.Step = 1
        Me.PBDayTwentyThree.Increment(1)

        Me.PBDayTwentyFour.Maximum = 200000
        Me.PBDayTwentyFour.Minimum = 0
        Me.PBDayTwentyFour.Step = 1
        Me.PBDayTwentyFour.Increment(1)

        Me.PBDayTwentyFive.Maximum = 200000
        Me.PBDayTwentyFive.Minimum = 0
        Me.PBDayTwentyFive.Step = 1
        Me.PBDayTwentyFive.Increment(1)

        Me.PBDayTwentySix.Maximum = 200000
        Me.PBDayTwentySix.Minimum = 0
        Me.PBDayTwentySix.Step = 1
        Me.PBDayTwentySix.Increment(1)

        Me.PBDayTwentySeven.Maximum = 200000
        Me.PBDayTwentySeven.Minimum = 0
        Me.PBDayTwentySeven.Step = 1
        Me.PBDayTwentySeven.Increment(1)

        Me.PBDayTwentyEight.Maximum = 200000
        Me.PBDayTwentyEight.Minimum = 0
        Me.PBDayTwentyEight.Step = 1
        Me.PBDayTwentyEight.Increment(1)

        Me.PBDayTwentyNine.Maximum = 200000
        Me.PBDayTwentyNine.Minimum = 0
        Me.PBDayTwentyNine.Step = 1
        Me.PBDayTwentyNine.Increment(1)

        Me.PBDayThirty.Maximum = 200000
        Me.PBDayThirty.Minimum = 0
        Me.PBDayThirty.Step = 1
        Me.PBDayThirty.Increment(1)

        Me.PBDayThirtyOne.Maximum = 200000
        Me.PBDayThirtyOne.Minimum = 0
        Me.PBDayThirtyOne.Step = 1
        Me.PBDayThirtyOne.Increment(1)
    End Sub

    Private Sub cmdClearGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearGraph.Click
        ClearData()
        ClearDateLabels()
        ClearVariables()
        ClearProgressBars()
        ClearDataLabels()
        gpxGraph.Visible = False
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub
End Class
