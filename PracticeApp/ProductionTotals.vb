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
Public Class ProductionTotals
    Inherits System.Windows.Forms.Form

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18, myAdapter19, myAdapter20, myAdapter21, myAdapter22, myAdapter23, myAdapter24, myAdapter25, myAdapter26, myAdapter27, myAdapter28, myAdapter29, myAdapter30, myAdapter31, myadapter32 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15, ds16, ds17, ds18, ds19, ds20, ds21, ds22, ds23, ds24, ds25, ds26, ds27, ds28, ds29, ds30, ds31, ds32 As DataSet
    Dim dt As DataTable

    Dim MachineFilter As String = ""
    Dim MachineCounter As Integer = 1
    Dim MachineIndex(64) As String
    Dim MachineTotalCount As Integer = 0

    Dim BeginDate, EndDate As Date
    Dim BeginDateLY, EndDateLY As Date
    Dim CurrentMonth As String = ""

    'Variables to fill datagrid
    Dim TotalProductionPieces, TotalInventoryPieces, LYTotalProductionPieces, LYTotalInventoryPieces As Double
    Dim TotalSteelWeight, TotalSteelCost, LYTotalSteelWeight, LYTotalSteelCost As Double
    Dim TotalMachineHours, LYTotalMachineHours As Double

    Public Sub DefineDateRange()
        Dim CurrentDate As Date
        Dim CurrentYear As Integer = 0
        Dim strCurrentYear As String = ""
        Dim LastYear As Integer = 0
        Dim strLastYear As String = ""
        Dim TodaysMonth As Integer = 0
        Dim CheckCurrentMonth As Integer = 0
        Dim MonthName As String = cboMonth.Text

        'Get month number for selected month
        Select Case MonthName
            Case "January"
                CheckCurrentMonth = 1
            Case "February"
                CheckCurrentMonth = 2
            Case "March"
                CheckCurrentMonth = 3
            Case "April"
                CheckCurrentMonth = 4
            Case "May"
                CheckCurrentMonth = 5
            Case "June"
                CheckCurrentMonth = 6
            Case "July"
                CheckCurrentMonth = 7
            Case "August"
                CheckCurrentMonth = 8
            Case "September"
                CheckCurrentMonth = 9
            Case "October"
                CheckCurrentMonth = 10
            Case "November"
                CheckCurrentMonth = 11
            Case "December"
                CheckCurrentMonth = 12
        End Select

        CurrentDate = Today()

        'If todays month is less than selected month, then go back one year

        TodaysMonth = CurrentDate.Month

        If TodaysMonth < CheckCurrentMonth Then
            CurrentYear = CurrentDate.Year - 1
            strCurrentYear = CStr(CurrentYear)
            LastYear = CurrentYear - 1
            strLastYear = CStr(LastYear)
        Else
            CurrentYear = CurrentDate.Year
            strCurrentYear = CStr(CurrentYear)
            LastYear = CurrentYear - 1
            strLastYear = CStr(LastYear)
        End If

        CurrentMonth = cboMonth.Text

        Select Case CurrentMonth
            Case "January"
                BeginDate = "01/01/" + strCurrentYear
                EndDate = "01/31/" + strCurrentYear
                BeginDateLY = "01/01/" + strLastYear
                EndDateLY = "01/31/" + strLastYear
            Case "February"
                BeginDate = "02/01/" + strCurrentYear
                EndDate = "02/28/" + strCurrentYear
                BeginDateLY = "02/01/" + strLastYear
                EndDateLY = "02/28/" + strLastYear
            Case "March"
                BeginDate = "03/01/" + strCurrentYear
                EndDate = "03/31/" + strCurrentYear
                BeginDateLY = "03/01/" + strLastYear
                EndDateLY = "03/31/" + strLastYear
            Case "April"
                BeginDate = "04/01/" + strCurrentYear
                EndDate = "04/30/" + strCurrentYear
                BeginDateLY = "04/01/" + strLastYear
                EndDateLY = "04/30/" + strLastYear
            Case "May"
                BeginDate = "05/01/" + strCurrentYear
                EndDate = "05/31/" + strCurrentYear
                BeginDateLY = "05/01/" + strLastYear
                EndDateLY = "05/31/" + strLastYear
            Case "June"
                BeginDate = "06/01/" + strCurrentYear
                EndDate = "06/30/" + strCurrentYear
                BeginDateLY = "06/01/" + strLastYear
                EndDateLY = "06/30/" + strLastYear
            Case "July"
                BeginDate = "07/01/" + strCurrentYear
                EndDate = "07/31/" + strCurrentYear
                BeginDateLY = "07/01/" + strLastYear
                EndDateLY = "07/31/" + strLastYear
            Case "August"
                BeginDate = "08/01/" + strCurrentYear
                EndDate = "08/31/" + strCurrentYear
                BeginDateLY = "08/01/" + strLastYear
                EndDateLY = "08/31/" + strLastYear
            Case "September"
                BeginDate = "09/01/" + strCurrentYear
                EndDate = "09/30/" + strCurrentYear
                BeginDateLY = "09/01/" + strLastYear
                EndDateLY = "09/30/" + strLastYear
            Case "October"
                BeginDate = "10/01/" + strCurrentYear
                EndDate = "10/31/" + strCurrentYear
                BeginDateLY = "10/01/" + strLastYear
                EndDateLY = "10/31/" + strLastYear
            Case "November"
                BeginDate = "11/01/" + strCurrentYear
                EndDate = "11/30/" + strCurrentYear
                BeginDateLY = "11/01/" + strLastYear
                EndDateLY = "11/30/" + strLastYear
            Case "December"
                BeginDate = "12/01/" + strCurrentYear
                EndDate = "12/31/" + strCurrentYear
                BeginDateLY = "12/01/" + strLastYear
                EndDateLY = "12/31/" + strLastYear
        End Select

    End Sub

    Public Sub LoadDataAllMachines()
        'Current Year
        Dim TotalPiecesProducedStatement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalPiecesProducedCommand As New SqlCommand(TotalPiecesProducedStatement, con)
        TotalPiecesProducedCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        TotalPiecesProducedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalPiecesProducedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalInventoryPiecesStatement As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalInventoryPiecesCommand As New SqlCommand(TotalInventoryPiecesStatement, con)
        TotalInventoryPiecesCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        TotalInventoryPiecesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalInventoryPiecesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalSteelWeightStatement As String = "SELECT SUM(LineWeight) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalSteelWeightCommand As New SqlCommand(TotalSteelWeightStatement, con)
        TotalSteelWeightCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        TotalSteelWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSteelWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalSteelCostStatement As String = "SELECT SUM(ExtendedSteelCost) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalSteelCostCommand As New SqlCommand(TotalSteelCostStatement, con)
        TotalSteelCostCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        TotalSteelCostCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSteelCostCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalMachineHoursStatement As String = "SELECT SUM(MachineHours) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalMachineHoursCommand As New SqlCommand(TotalMachineHoursStatement, con)
        TotalMachineHoursCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        TotalMachineHoursCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalMachineHoursCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        'Previous Year
        Dim LYTotalPiecesProducedStatement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim LYTotalPiecesProducedCommand As New SqlCommand(LYTotalPiecesProducedStatement, con)
        LYTotalPiecesProducedCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        LYTotalPiecesProducedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDateLY
        LYTotalPiecesProducedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDateLY

        Dim LYTotalInventoryPiecesStatement As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim LYTotalInventoryPiecesCommand As New SqlCommand(LYTotalInventoryPiecesStatement, con)
        LYTotalInventoryPiecesCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        LYTotalInventoryPiecesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDateLY
        LYTotalInventoryPiecesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDateLY

        Dim LYTotalSteelWeightStatement As String = "SELECT SUM(LineWeight) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim LYTotalSteelWeightCommand As New SqlCommand(LYTotalSteelWeightStatement, con)
        LYTotalSteelWeightCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        LYTotalSteelWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDateLY
        LYTotalSteelWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDateLY

        Dim LYTotalSteelCostStatement As String = "SELECT SUM(ExtendedSteelCost) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim LYTotalSteelCostCommand As New SqlCommand(LYTotalSteelCostStatement, con)
        LYTotalSteelCostCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        LYTotalSteelCostCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDateLY
        LYTotalSteelCostCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDateLY

        Dim LYTotalMachineHoursStatement As String = "SELECT SUM(MachineHours) FROM TimeSlipCombinedData WHERE MachineNumber = @MachineNumber AND PostingDate BETWEEN @BeginDate AND @EndDate"
        Dim LYTotalMachineHoursCommand As New SqlCommand(LYTotalMachineHoursStatement, con)
        LYTotalMachineHoursCommand.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = MachineIndex(MachineCounter)
        LYTotalMachineHoursCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDateLY
        LYTotalMachineHoursCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDateLY

        If con.State = ConnectionState.Closed Then con.Open()

        'Current Year
        Try
            TotalProductionPieces = CDbl(TotalPiecesProducedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalProductionPieces = 0
        End Try
        Try
            TotalInventoryPieces = CDbl(TotalInventoryPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            TotalInventoryPieces = 0
        End Try
        Try
            TotalSteelWeight = CDbl(TotalSteelWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSteelWeight = 0
        End Try
        Try
            TotalSteelCost = CDbl(TotalSteelCostCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSteelCost = 0
        End Try
        Try
            TotalMachineHours = CDbl(TotalMachineHoursCommand.ExecuteScalar)
        Catch ex As Exception
            TotalMachineHours = 0
        End Try

        'Previous Year
        Try
            LYTotalProductionPieces = CDbl(LYTotalPiecesProducedCommand.ExecuteScalar)
        Catch ex As Exception
            LYTotalProductionPieces = 0
        End Try
        Try
            LYTotalInventoryPieces = CDbl(LYTotalInventoryPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            LYTotalInventoryPieces = 0
        End Try
        Try
            LYTotalSteelWeight = CDbl(LYTotalSteelWeightCommand.ExecuteScalar)
        Catch ex As Exception
            LYTotalSteelWeight = 0
        End Try
        Try
            LYTotalSteelCost = CDbl(LYTotalSteelCostCommand.ExecuteScalar)
        Catch ex As Exception
            LYTotalSteelCost = 0
        End Try
        Try
            LYTotalMachineHours = CDbl(LYTotalMachineHoursCommand.ExecuteScalar)
        Catch ex As Exception
            LYTotalMachineHours = 0
        End Try
        con.Close()
    End Sub

    Public Function FillMachineArray()
        If cboMachineClass.Text = "Header" Then
            'Define Machines by index
            MachineIndex(1) = "001"
            MachineIndex(2) = "003"
            MachineIndex(3) = "005"
            MachineIndex(4) = "006"
            MachineIndex(5) = "007"
            MachineIndex(6) = "008"
            MachineIndex(7) = "009"
            MachineIndex(8) = "010"
            MachineIndex(9) = "011"
            MachineIndex(10) = "012"
            MachineIndex(11) = "014"
            MachineIndex(12) = "015"
            MachineIndex(13) = "017"
            MachineIndex(14) = "018"
            MachineIndex(15) = "019"
            MachineIndex(16) = "020"
            MachineIndex(17) = "021"
            MachineIndex(18) = "022"
            MachineIndex(19) = "097"
            MachineIndex(20) = "098"
            MachineIndex(21) = "099"
            MachineIndex(22) = "109"
            MachineIndex(23) = "111"
            MachineIndex(24) = "112"
            MachineIndex(25) = "706"
            MachineIndex(26) = "707"
            MachineIndex(27) = "708"
            MachineTotalCount = 27
        ElseIf cboMachineClass.Text = "Roller" Then
            'Define Machines by index
            MachineIndex(1) = "172"
            MachineIndex(2) = "173"
            MachineIndex(3) = "174"
            MachineIndex(4) = "175"
            MachineIndex(5) = "176"
            MachineIndex(6) = "177"
            MachineIndex(7) = "181"
            MachineIndex(8) = "184"
            MachineIndex(9) = "185"
            MachineIndex(10) = "186"
            MachineIndex(11) = "187"
            MachineIndex(12) = "188"
            MachineIndex(13) = "189"
            MachineIndex(14) = "190"
            MachineIndex(15) = "191"
            MachineIndex(16) = "RRL"
            MachineTotalCount = 16
        ElseIf cboMachineClass.Text = "Lathe" Then
            'Define Machines by index
            MachineIndex(1) = "252"
            MachineIndex(2) = "253"
            MachineIndex(3) = "301"
            MachineIndex(4) = "302"
            MachineIndex(5) = "313"
            MachineIndex(6) = "331"
            MachineIndex(7) = "340"
            MachineIndex(8) = "341"
            MachineIndex(9) = "342"
            MachineIndex(10) = "343"
            MachineIndex(11) = "344"
            MachineIndex(12) = "345"
            MachineIndex(13) = "346"
            MachineIndex(14) = "347"
            MachineIndex(15) = "438"
            MachineIndex(16) = "LTH"
            MachineTotalCount = 16
        ElseIf cboMachineClass.Text = "Mill" Then
            'Define Machines by index
            MachineIndex(1) = "241"
            MachineIndex(2) = "242"
            MachineIndex(3) = "243"
            MachineIndex(4) = "244"
            MachineIndex(5) = "245"
            MachineIndex(6) = "258"
            MachineIndex(7) = "262"
            MachineIndex(8) = "DRL"
            MachineTotalCount = 8
        ElseIf cboMachineClass.Text = "Drill" Then
            'Define Machines by index
            MachineIndex(1) = "311"
            MachineIndex(2) = "520"
            MachineIndex(3) = "617"
            MachineIndex(4) = "621"
            MachineIndex(5) = "REM"
            MachineTotalCount = 5
        ElseIf cboMachineClass.Text = "Grind" Then
            'Define Machines by index
            MachineIndex(1) = "400"
            MachineIndex(2) = "401"
            MachineIndex(3) = "402"
            MachineIndex(4) = "GRD"
            MachineTotalCount = 4
        ElseIf cboMachineClass.Text = "Harden & Draw" Then
            'Define Machines by index
            MachineIndex(1) = "434"
            MachineIndex(2) = "709"
            MachineIndex(3) = "912"
            MachineIndex(4) = "913"
            MachineIndex(5) = "922"
            MachineIndex(6) = "923"
            MachineIndex(7) = "H&D"
            MachineTotalCount = 7
        ElseIf cboMachineClass.Text = "All Others" Then
            MachineIndex(1) = "080"
            MachineIndex(2) = "150"
            MachineIndex(3) = "160"
            MachineIndex(4) = "161"
            MachineIndex(5) = "168"
            MachineIndex(6) = "169"
            MachineIndex(7) = "170"
            MachineIndex(8) = "268"
            MachineIndex(9) = "290"
            MachineIndex(10) = "303"
            MachineIndex(11) = "304"
            MachineIndex(12) = "305"
            MachineIndex(13) = "308"
            MachineIndex(14) = "310"
            MachineIndex(15) = "314"
            MachineIndex(16) = "315"
            MachineIndex(17) = "429"
            MachineIndex(18) = "430"
            MachineIndex(19) = "431"
            MachineIndex(20) = "432"
            MachineIndex(21) = "433"
            MachineIndex(22) = "435"
            MachineIndex(23) = "436"
            MachineIndex(24) = "437"
            MachineIndex(25) = "439"
            MachineIndex(26) = "440"
            MachineIndex(27) = "441"
            MachineIndex(28) = "500"
            MachineIndex(29) = "702"
            MachineIndex(30) = "703"
            MachineIndex(31) = "704"
            MachineIndex(32) = "710"
            MachineIndex(33) = "900"
            MachineIndex(34) = "903"
            MachineIndex(35) = "910"
            MachineIndex(36) = "911"
            MachineIndex(37) = "914"
            MachineIndex(38) = "920"
            MachineIndex(39) = "921"
            MachineIndex(40) = "ANN"
            MachineIndex(41) = "ASM"
            MachineIndex(42) = "BAK"
            MachineIndex(43) = "BOX"
            MachineIndex(44) = "BUF"
            MachineIndex(45) = "CAS"
            MachineIndex(46) = "CTK"
            MachineIndex(47) = "EXT"
            MachineIndex(48) = "FPI"
            MachineIndex(49) = "HLD"
            MachineIndex(50) = "NKL"
            MachineIndex(51) = "OBX"
            MachineIndex(52) = "PNT"
            MachineIndex(53) = "PPL"
            MachineIndex(54) = "PPL QA"
            MachineIndex(55) = "PUN"
            MachineIndex(56) = "RFP"
            MachineIndex(57) = "RWK"
            MachineIndex(58) = "SLT"
            MachineIndex(59) = "SRP"
            MachineIndex(60) = "SRT"
            MachineIndex(61) = "T/W"
            MachineIndex(62) = "TUM"
            MachineIndex(63) = "ZBG"
            MachineIndex(64) = "ZIN"
            MachineTotalCount = 64
        End If
    End Function

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewTotals.Click
        If cboMachineClass.Text = "" Or cboMonth.Text = "" Then
            MsgBox("You must select a month and machine class.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Make sure datagrid is empty
        Me.dgvProductionTotals.DataSource = Nothing
        Me.dgvProductionTotals.RowCount = 0
        Me.dgvProductionTotals.Refresh()

        DefineDateRange()
        MachineCounter = 1
        FillMachineArray()

        'Start Loop to fill data
        For i As Integer = 1 To MachineTotalCount
            'Get Data from database
            LoadDataAllMachines()

            'Add line to datagrid
            Me.dgvProductionTotals.Rows.Add(MachineIndex(MachineCounter), TotalMachineHours, TotalInventoryPieces, TotalProductionPieces, TotalSteelWeight, TotalSteelCost, LYTotalMachineHours, LYTotalInventoryPieces, LYTotalProductionPieces, LYTotalSteelWeight, LYTotalSteelCost)

            'Clear Data
            TotalInventoryPieces = 0
            TotalProductionPieces = 0
            TotalSteelCost = 0
            TotalSteelWeight = 0
            TotalMachineHours = 0
            LYTotalInventoryPieces = 0
            LYTotalProductionPieces = 0
            LYTotalSteelCost = 0
            LYTotalSteelWeight = 0
            LYTotalMachineHours = 0

            'Advance counter
            MachineCounter = MachineCounter + 1
        Next i

        lblBannerLabel.Text = "Machine Production results for " + cboMonth.Text + " of this year and last year."

        Me.dgvProductionTotals.Columns("TotalMachineHoursLYColumn").DefaultCellStyle.BackColor = Color.LightGray
        Me.dgvProductionTotals.Columns("TotalInventoryPiecesLYColumn").DefaultCellStyle.BackColor = Color.LightGray
        Me.dgvProductionTotals.Columns("TotalProductionQuantityLYColumn").DefaultCellStyle.BackColor = Color.LightGray
        Me.dgvProductionTotals.Columns("TotalSteelCostLYColumn").DefaultCellStyle.BackColor = Color.LightGray
        Me.dgvProductionTotals.Columns("TotalSteelUsedLYColumn").DefaultCellStyle.BackColor = Color.LightGray

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboMachineClass.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
        lblBannerLabel.Text = ""

        Me.dgvProductionTotals.DataSource = Nothing
        Me.dgvProductionTotals.RowCount = 0
        Me.dgvProductionTotals.Refresh()
    End Sub
End Class