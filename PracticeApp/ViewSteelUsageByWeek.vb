Imports System.Data.SqlClient
Imports System.Data

Public Class ViewSteelUsageByWeek
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Dim RawMaterials As New Dictionary(Of String, MatData)

    Dim SteelDT As Data.DataTable
    Dim isLoaded As Boolean = False

    Private Structure MatData
        Public Carbon As String
        Public SteelSize As String
        Public weeks As List(Of Double)
        Public Sub New(ByVal car As String, ByVal size As String)
            Carbon = car
            SteelSize = size
            weeks = New List(Of Double)
            For i As Integer = 1 To 6
                weeks.Add(0)
            Next
        End Sub
    End Structure

    Public Sub New()
        InitializeComponent()
        LoadSteel()

        Me.AcceptButton = cmdView
        isLoaded = True
    End Sub

    Private Sub LoadSteel()
        cmd = New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable;", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(SteelDT)
        con.Close()

        For i As Integer = 0 To SteelDT.Rows.Count - 1
            RawMaterials.Add(SteelDT.Rows(i).Item("RMID"), New MatData(SteelDT.Rows(i).Item("Carbon"), SteelDT.Rows(i).Item("SteelSize")))
        Next

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        For i As Integer = 0 To RawMaterials.Count - 1
            For j As Integer = 0 To 5
                RawMaterials.ElementAt(i).Value.weeks(j) = 0
            Next
        Next
        dgvSteelMonthSummary.Rows.Clear()
        dgvSteelMonthSummary.Columns.Clear()
        Dim month As Integer = dtpMonthYear.Value.Date.Month
        Dim year As Integer = dtpMonthYear.Value.Date.Year
        Dim StartDate As Date = New Date(year, month, 1)
        Dim EndDate As Date = New Date(year, month, Date.DaysInMonth(year, month))
        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter()
        cmd = New SqlCommand("SELECT isnull(RMID, '') as RMID, Carbon, SteelSize, SteelTransactionDate, (case when SUM(isnull(TotalRemoved, 0)) < 0 then 0 ELSE SUM(isnull(TotalRemoved, 0)) end) as DailyTotal FROM (SELECT SteelTransactionDate, RawMaterialsTable.RMID, RawMaterialsTable.Carbon, RawMaterialsTable.SteelSize, SUM(Quantity)as TotalRemoved FROM SteelTransactionTable LEFT OUTER JOIN RawMaterialsTable ON SteelTransactionTable.RMID = RawMaterialsTable.RMID WHERE TransactionMath = 'SUBTRACT' and TransactionType <> 'VENDOR RETURN' AND SteelTransactionDate BETWEEN @BeginDate and @EndDate GROUP BY SteelTransactionDate, RawMaterialsTable.RMID, RawMaterialsTable.Carbon, RawMaterialsTable.SteelSize UNION ALL SELECT SteelTransactionDate, SteelTransactionTable.RMID, SteelTransactionTable.Carbon, SteelTransactionTable.SteelSize, (-1 * SUM(Quantity)) as TotalRemoved FROM SteelTransactionTable LEFT OUTER JOIN RawMaterialsTable ON SteelTransactionTable.RMID = RawMaterialsTable.RMID WHERE TransactionMath = 'ADD' and TransactionType <> 'RECEIPT OF GOODS' and TransactionType <> 'BEG BALANCE' AND SteelTransactionDate BETWEEN @BeginDate and @EndDate GROUP BY SteelTransactionDate, SteelTransactionTable.RMID, SteelTransactionTable.Carbon, SteelTransactionTable.SteelSize) as Usage WHERE SteelTransactionDate BETWEEN @BeginDate and @EndDate", con)

        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            If chkAllTypes.Checked Then
                cmd.CommandText += " AND Carbon LIKE @Carbon"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
            Else
                cmd.CommandText += " AND Carbon = @Carbon"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            End If

        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cmd.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
            If cboSteelSize.Text.Contains("/") Then
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
            End If
        End If
        cmd.CommandText += " GROUP BY SteelTransactionDate, RMID, Carbon, SteelSize ORDER BY SteelTransactionDate, RMID, Carbon, SteelSize"
        cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = StartDate
        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate

        adap.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "SteelTransactionTable")
        con.Close()
        Dim currentDate As Date = StartDate
        Dim currentWeek As Integer = 0
        Dim currentRow As Integer = 0
        Dim weekStarts As New List(Of Date)
        weekStarts.Add(currentDate)
        While DateDiff(DateInterval.Day, currentDate, EndDate) <> 0 And currentRow < tempds.Tables("SteelTransactionTable").Rows.Count
            Select Case DateDiff(DateInterval.Day, currentDate, tempds.Tables("SteelTransactionTable").Rows(currentRow).Item("SteelTransactionDate"))
                Case Is = 0
                    If Not tempds.Tables("SteelTransactionTable").Rows(currentRow).Item("RMID").Equals("") Then
                        RawMaterials(tempds.Tables("SteelTransactionTable").Rows(currentRow).Item("RMID")).weeks(currentWeek) += tempds.Tables("SteelTransactionTable").Rows(currentRow).Item("DailyTotal")
                    End If
                    currentRow += 1
                Case Is > 0
                    While DateDiff(DateInterval.Day, currentDate, tempds.Tables("SteelTransactionTable").Rows(currentRow).Item("SteelTransactionDate")) > 0 And DateDiff(DateInterval.Day, currentDate, EndDate) <> 0
                        currentDate = currentDate.AddDays(1)
                        If currentDate.DayOfWeek.ToString.Equals("Monday") Then
                            currentWeek += 1
                            weekStarts.Add(currentDate)
                        End If
                    End While
                Case Is < 0
                    currentRow += 1
            End Select
        End While
        If tempds.Tables("SteelTransactionTable").Rows.Count = 0 Then
            While DateDiff(DateInterval.Day, currentDate, EndDate) <> 0
                currentDate = currentDate.AddDays(1)
                If currentDate.DayOfWeek.ToString.Equals("Monday") Then
                    currentWeek += 1
                    weekStarts.Add(currentDate)
                End If
            End While
        End If
        If DateDiff(DateInterval.Day, currentDate, EndDate) <> 0 Then
            currentDate = currentDate.AddDays(1)
            If currentDate.DayOfWeek.ToString.Equals("Monday") Then
                currentWeek += 1
                weekStarts.Add(currentDate)
            End If
        End If
        dgvSteelMonthSummary.Columns.Add("Carbon", "Carbon")
        dgvSteelMonthSummary.Columns("Carbon").Frozen = True
        dgvSteelMonthSummary.Columns.Add("SteelSize", "Size")
        dgvSteelMonthSummary.Columns("SteelSize").Frozen = True
        ''creates the week columns with the dates
        For i As Integer = 0 To weekStarts.Count - 1
            If i <> weekStarts.Count - 1 Then
                dgvSteelMonthSummary.Columns.Add(weekStarts(i).ToShortDateString() + "TO" + weekStarts(i + 1).AddDays(-1).ToShortDateString(), weekStarts(i).ToShortDateString() + " TO " + weekStarts(i + 1).AddDays(-1).ToShortDateString())
            Else
                dgvSteelMonthSummary.Columns.Add(weekStarts(i).ToShortDateString() + "TO" + EndDate.ToShortDateString(), weekStarts(i).ToShortDateString() + " TO " + EndDate.ToShortDateString())
            End If
        Next
        If String.IsNullOrEmpty(cboCarbon.Text) And String.IsNullOrEmpty(cboSteelSize.Text) Then
            ''adds the raw materials to the dgv
            For Each rawMat As MatData In RawMaterials.Values
                dgvSteelMonthSummary.Rows.Add(rawMat.Carbon, rawMat.SteelSize)
                ''adds the weekly totals to the columns for the given RMID
                For i As Integer = 0 To currentWeek
                    dgvSteelMonthSummary.Rows(dgvSteelMonthSummary.Rows.Count - 1).Cells(2 + i).Value = rawMat.weeks(i)
                Next
            Next
        ElseIf String.IsNullOrEmpty(cboCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            ''adds the raw materials to the dgv
            For Each rawMat As MatData In RawMaterials.Values
                If rawMat.SteelSize.Equals(cboSteelSize.Text) Then
                    dgvSteelMonthSummary.Rows.Add(rawMat.Carbon, rawMat.SteelSize)
                    ''adds the weekly totals to the columns for the given RMID
                    For i As Integer = 0 To currentWeek
                        dgvSteelMonthSummary.Rows(dgvSteelMonthSummary.Rows.Count - 1).Cells(2 + i).Value = rawMat.weeks(i)
                    Next
                End If
            Next
        ElseIf Not String.IsNullOrEmpty(cboCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            ''adds the raw materials to the dgv
            For Each rawMat As MatData In RawMaterials.Values
                If rawMat.SteelSize.Equals(cboSteelSize.Text) And rawMat.Carbon.Equals(cboCarbon.Text) Then
                    dgvSteelMonthSummary.Rows.Add(rawMat.Carbon, rawMat.SteelSize)
                    ''adds the weekly totals to the columns for the given RMID
                    For i As Integer = 0 To currentWeek
                        dgvSteelMonthSummary.Rows(dgvSteelMonthSummary.Rows.Count - 1).Cells(2 + i).Value = rawMat.weeks(i)
                    Next
                End If
            Next
        Else
            ''adds the raw materials to the dgv
            For Each rawMat As MatData In RawMaterials.Values
                If rawMat.Carbon.Equals(cboCarbon.Text) Then
                    dgvSteelMonthSummary.Rows.Add(rawMat.Carbon, rawMat.SteelSize)
                    ''adds the weekly totals to the columns for the given RMID
                    For i As Integer = 0 To currentWeek
                        dgvSteelMonthSummary.Rows(dgvSteelMonthSummary.Rows.Count - 1).Cells(2 + i).Value = rawMat.weeks(i)
                    Next
                End If
            Next
        End If
        If chkOmitZeroTotals.Checked Then
            Dim i As Integer = 0
            While i < dgvSteelMonthSummary.Rows.Count
                Dim allZero As Boolean = True
                For j As Integer = 2 To dgvSteelMonthSummary.Columns.Count - 1
                    If dgvSteelMonthSummary.Rows(i).Cells(j).Value <> 0 Then
                        allZero = False
                    End If
                Next
                If allZero Then
                    dgvSteelMonthSummary.Rows.RemoveAt(i)
                Else
                    i += 1
                End If
            End While
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isLoaded = False
        dgvSteelMonthSummary.Rows.Clear()
        dgvSteelMonthSummary.Columns.Clear()

        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
        chkOmitZeroTotals.Checked = False
        chkAllTypes.Checked = False
        dtpMonthYear.Value = Now
        cboCarbon.Focus()
        isLoaded = True
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cboSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
        If e.KeyChar.Equals("."c) And (cboSteelSize.Text.Length = 0 Or cboSteelSize.SelectionLength = cboSteelSize.Text.Length) Then
            cboSteelSize.Text = "0."
            e.KeyChar = Nothing
            cboSteelSize.SelectionStart = cboSteelSize.Text.Length
            cboSteelSize.SelectionLength = 0
        End If
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                If cboSteelSize.Text.Contains("/") Then
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                Else
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                End If
                cboCarbon.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
                cboCarbon.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Leave
        If Not String.IsNullOrEmpty(cboSteelSize.Text) AndAlso cboSteelSize.SelectedIndex = -1 Then
            If cboSteelSize.Text.Contains("/") Then
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                End If
            Else
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.GetFractional(cboSteelSize.Text)
                End If
            End If
        ElseIf cboSteelSize.SelectedIndex = -1 Then
            Dim tmp As String = cboCarbon.Text
            isloaded = False
            cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
            cboCarbon.Text = tmp
            isloaded = True
        End If
    End Sub

    Private Sub chkShowAllTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTypes.CheckedChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub ViewSteelUsageByWeek_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub



End Class