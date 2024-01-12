Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ViewSteelUsageByMonth
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim SteelDT As Data.DataTable
    Dim isLoaded As Boolean = False

    Public Sub New()
        InitializeComponent()

        LoadSteel()
        isLoaded = True
    End Sub

    Private Sub LoadCarbon()
        Dim cmd As New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable;", con)
        Dim ds As New DataSet
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "RawMaterialsTable")
        con.Close()
    End Sub

    Private Sub LoadSteel()
        Dim cmd As New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable;", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(SteelDT)
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim limitStatement As String = ""

        Dim cmd As New SqlCommand("SELECT Carbon, SteelSize", con)
        If Not String.IsNullOrEmpty(cboCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            If chkAllTypes.Checked Then
                limitStatement = " WHERE Carbon like @Carbon AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
            Else
                limitStatement = " WHERE Carbon = @Carbon AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            End If

            If cboSteelSize.Text.Contains("/") Then
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
            End If
        Else
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                If chkAllTypes.Checked Then
                    limitStatement = " WHERE Carbon like @Carbon"
                    cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
                Else
                    limitStatement = " WHERE Carbon = @Carbon"
                    cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                End If

            Else
                If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                    limitStatement = " WHERE (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"

                    If cboSteelSize.Text.Contains("/") Then
                        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                        cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                    Else
                        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                        cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
                    End If
                End If
            End If
        End If
        Dim count As Integer = 0
        Dim month As Integer = dtpEndDate.Value.Month
        Dim year As Integer = dtpEndDate.Value.Year
        Dim columns As New List(Of String)
        Dim selectStatments As String = ""
        ''goes through 12 months and generates the selections
        While count < 12
            ''adds the column name with the desired month and year
            columns.Add("[" + getMonthWord(month) + " " + year.ToString() + "]")
            If count = 0 Then
                selectStatments += " FROM (SELECT SteelUsageTable.RMID, Carbon, SteelSize, CASE WHEN UsageDate >= '" + getBeginMonth(month, year).ToShortDateString() + "' AND UsageDate <= '" + getEndOfMonth(month, year).ToShortDateString() + "' THEN UsageWeight ELSE 0 END AS " + columns(columns.Count - 1)

            Else
                selectStatments += ", CASE WHEN UsageDate >= '" + getBeginMonth(month, year).ToShortDateString() + "' AND UsageDate <= '" + getEndOfMonth(month, year).ToShortDateString() + "' THEN UsageWeight ELSE 0 END AS " + columns(columns.Count - 1)
            End If

            month -= 1
            If month = 0 Then
                month = 12
                year -= 1
            End If
            count += 1
        End While
        For i As Integer = 0 To columns.Count - 1
            cmd.CommandText += ", SUM(" + columns(i) + ") as " + columns(i)
        Next

        cmd.CommandText += selectStatments + " FROM SteelUsageTable "
        If chkOmitZeroTotals.Checked Then
            cmd.CommandText += " INNER JOIN "
        Else
            cmd.CommandText += " RIGHT OUTER JOIN "
        End If
        cmd.CommandText += "RawMaterialsTable on RawMaterialsTable.RMID = SteelUsageTable.RMID" + limitStatement + ") AS SteelUsageTable GROUP By SteelUsageTable.RMID, Carbon, SteelSize ORDER BY SteelUsageTable.RMID;"
        Dim dt As New Data.DataTable("SteelUsageTable")
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        con.Close()

        Dim totals(12) As Double

        For i As Integer = 0 To dt.Rows.Count - 1
            If Not dt.Rows(i).Item("Carbon").ToString.Contains("ABALL") Then
                totals(0) += dt.Rows(i).Item(2)
                totals(1) += dt.Rows(i).Item(3)
                totals(2) += dt.Rows(i).Item(4)
                totals(3) += dt.Rows(i).Item(5)
                totals(4) += dt.Rows(i).Item(6)
                totals(5) += dt.Rows(i).Item(7)
                totals(6) += dt.Rows(i).Item(8)
                totals(7) += dt.Rows(i).Item(9)
                totals(8) += dt.Rows(i).Item(10)
                totals(9) += dt.Rows(i).Item(11)
                totals(10) += dt.Rows(i).Item(12)
                totals(11) += dt.Rows(i).Item(13)
            End If
        Next
        dt.Rows.Add("")
        dt.Rows.Add("TOTALS", "", totals(0), totals(1), totals(2), totals(3), totals(4), totals(5), totals(6), totals(7), totals(8), totals(9), totals(10), totals(11))

        dgvSteelMonthSummary.DataSource = dt

        dgvSteelMonthSummary.Columns("SteelSize").HeaderText = "Steel Size"
        If dgvSteelMonthSummary.Rows.Count > 0 Then
            dgvSteelMonthSummary.Rows(dgvSteelMonthSummary.Rows.Count - 1).Cells(0).Style.Font = New System.Drawing.Font(dgvSteelMonthSummary.DefaultCellStyle.Font.FontFamily, dgvSteelMonthSummary.DefaultCellStyle.Font.Size + 1, FontStyle.Bold, dgvSteelMonthSummary.DefaultCellStyle.Font.Unit)
            dgvSteelMonthSummary.Columns(2).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(3).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(4).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(5).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(6).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(7).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(8).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(9).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(10).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(11).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(12).DefaultCellStyle.Format = "N0"
            dgvSteelMonthSummary.Columns(13).DefaultCellStyle.Format = "N0"
        End If

        dgvSteelMonthSummary.Columns("Carbon").Frozen = True
        dgvSteelMonthSummary.Columns("SteelSize").Frozen = True
    End Sub
    ''returns the date of the first day of the month
    Private Function getBeginMonth(ByVal month As Integer, ByVal year As Integer) As DateTime
        Return New DateTime(year, month, 1)
    End Function
    ''returns the date of the last day of the current month
    Private Function getEndOfMonth(ByVal month As Integer, ByVal year As Integer) As DateTime
        Dim dat As DateTime
        If month = 12 Then
            dat = New DateTime(year + 1, 1, 1)
        Else
            dat = New DateTime(year, month + 1, 1)
        End If
        Return dat.AddDays(-1)
    End Function
    ''returns the month for the given numeric month value
    Private Function getMonthWord(ByVal month As Integer) As String
        Select Case month
            Case 1
                Return "January"
            Case 2
                Return "Febuary"
            Case 3
                Return "March"
            Case 4
                Return "April"
            Case 5
                Return "May"
            Case 6
                Return "June"
            Case 7
                Return "July"
            Case 8
                Return "August"
            Case 9
                Return "September"
            Case 10
                Return "October"
            Case 11
                Return "November"
            Case 12
                Return "December"
        End Select
        Return getMonthWord(Today.Month)
    End Function

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintListingToolStripMenuItem.Click
        If dgvSteelMonthSummary.DataSource IsNot Nothing Then
            Dim dat As New DataSet()
            dat.Tables.Add(CType(dgvSteelMonthSummary.DataSource, Data.DataTable).Copy())
            dat.Tables("SteelUsageTable").TableName = "SteelUsageMonthSummary"
            For i As Integer = 2 To dat.Tables("SteelUsageMonthSummary").Columns.Count - 1
                dat.Tables("SteelUsageMonthSummary").Columns(i).ColumnName = dat.Tables("SteelUsageMonthSummary").Columns(i).ColumnName.Substring(0, dat.Tables("SteelUsageMonthSummary").Columns(i).ColumnName.IndexOf(" ")) + "2011Total"
            Next
            Using NewPrintSteelMonthConsumption As New PrintSteelMonthConsumption(dat)
                Dim result = NewPrintSteelMonthConsumption.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If cboSteelSize.Text.StartsWith(".") Then
            cboSteelSize.Text = "0."
            cboSteelSize.Select(cboSteelSize.Text.Length, 0)
        End If
    End Sub
   
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isLoaded = False
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1
        If String.IsNullOrEmpty(cboCarbon.Text) = False Then
            cboCarbon.Text = ""
        End If
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        If String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            cboSteelSize.Text = ""
        End If
        dtpEndDate.Value = Now
        chkAllTypes.Checked = False
        chkOmitZeroTotals.Checked = False
        cboCarbon.Focus()
        dgvSteelMonthSummary.DataSource = Nothing
        isLoaded = True
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
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isLoaded = True
            End If
        End If
    End Sub

    Private Sub ViewSteelUsageByMonth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class