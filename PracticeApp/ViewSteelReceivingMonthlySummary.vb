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
Public Class ViewSteelReceivingMonthlySummary
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim dt As DataTable

    Dim GetRMID As String = ""
    Dim SteelDT As Data.DataTable
    Dim isLoaded As Boolean = False

    Public Sub New()
        InitializeComponent()

        If con.State = ConnectionState.Closed Then con.Open()
        LoadVendors()
        LoadSteel()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Private Sub LoadVendors()
        cmd = New SqlCommand("SELECT VendorCode, VendorName FROM Vendor WHERE DivisionID = 'TWD' AND VendorClass = 'SteelVendor'", con)
        Dim dt As New Data.DataTable("Vendor")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)

        cboVendorID.DisplayMember = "VendorCode"
        cboVendorID.DataSource = dt
        cboVendorID.SelectedIndex = -1
    End Sub

    Private Sub LoadSteel()
        cmd = New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(SteelDT)

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        If cboVendorID.SelectedIndex <> -1 Then
            lblVendorName.Text = CType(cboVendorID.DataSource, Data.DataTable).Rows(cboVendorID.SelectedIndex).Item("VendorName")
        Else
            lblVendorName.Text = ""
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        'Get RMID for Steel type / Steel Size
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetRMID = ""
        End Try
        con.Close()

        cmd = New SqlCommand("", con)
        If Not String.IsNullOrEmpty(cboCarbon.Text) Or Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cmd.CommandText = "SELECT SteelVendor, ReceivingMonthYear, RMID, SUM(ReceiveWeight) as TotalWeight, SUM(SteelExtendedCost) as TotalCost FROM (SELECT SteelReceivingHeaderTable.SteelVendor, (Cast(DATEPART(mm, SteelReceivingHeaderTable.ReceivingDate) as varchar) + '/' +  Cast(DATEPART(yyyy, SteelReceivingHeaderTable.ReceivingDate) as varchar)) as ReceivingMonthYear, LineTable.RMID, LineTable.ReceiveWeight, LineTable.SteelExtendedCost FROM (SELECT SteelReceivingLineTable.SteelReceivingHeaderKey, SteelReceivingLineTable.SteelReceivingLineKey, SteelReceivingLineTable.RMID, SteelReceivingLineTable.ReceiveWeight, SteelReceivingLineTable.SteelExtendedCost FROM SteelReceivingLineTable WHERE RMID like @RMID AND LineStatus <> 'OPEN') as LineTable INNER JOIN SteelReceivingHeaderTable ON SteelReceivingHeaderTable.SteelReceivingHeaderKey = LineTable.SteelReceivingHeaderKey "
            If Not String.IsNullOrEmpty(cboCarbon.Text) And Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
            ElseIf Not String.IsNullOrEmpty(cboCarbon.Text) Then
                cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
            ElseIf Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = "%" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            End If
        Else
            cmd.CommandText = "SELECT SteelVendor, ReceivingMonthYear, RMID, SUM(ReceiveWeight) as TotalWeight, SUM(SteelExtendedCost) as TotalCost FROM (SELECT SteelReceivingHeaderTable.SteelVendor, (Cast(DATEPART(mm, SteelReceivingHeaderTable.ReceivingDate) as varchar) + '/' +  Cast(DATEPART(yyyy, SteelReceivingHeaderTable.ReceivingDate) as varchar)) as ReceivingMonthYear, LineTable.RMID, LineTable.ReceiveWeight, LineTable.SteelExtendedCost FROM (SELECT SteelReceivingLineTable.SteelReceivingHeaderKey, SteelReceivingLineTable.SteelReceivingLineKey, SteelReceivingLineTable.RMID, SteelReceivingLineTable.ReceiveWeight, SteelReceivingLineTable.SteelExtendedCost FROM SteelReceivingLineTable WHERE LineStatus <> 'OPEN') as LineTable INNER JOIN SteelReceivingHeaderTable ON SteelReceivingHeaderTable.SteelReceivingHeaderKey = LineTable.SteelReceivingHeaderKey "
        End If
        Dim isFirst As Boolean = True

        If Not String.IsNullOrEmpty(cboVendorID.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE SteelVendor = @VendorID"
            Else
                cmd.CommandText += " AND SteelVendor = @VendorID"
            End If
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        End If
        Dim StartDate As DateTime
        Dim EndDate As DateTime
        If chkUseDateRange.Checked Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE ReceivingDate BETWEEN @BeginDate AND @EndDate"
            Else
                cmd.CommandText += " AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
            End If
            StartDate = dtpBeginningDate.Value
            EndDate = dtpEndingDate.Value
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = StartDate
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate
        Else
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE ReceivingDate BETWEEN @BeginDate AND @EndDate"
            Else
                cmd.CommandText += " AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
            End If
            StartDate = New DateTime(2016, 1, 1)
            EndDate = Now
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = New DateTime(2016, 1, 1)
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Now
        End If
        cmd.CommandText += ") as temp GROUP BY SteelVendor, RMID, ReceivingMonthYear ORDER BY SteelVendor, RMID, ReceivingMonthYear"
        Dim dt As New Data.DataTable("SteelReceivingLineTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        SetupDGV(StartDate, EndDate)
        InsertDataIntoDGV(dt)
    End Sub

    Private Sub SetupDGV(ByVal StartDate As DateTime, ByVal EndDate As DateTime)
        dgvReceivingMonthlySummary.SuspendLayout()
        dgvReceivingMonthlySummary.Columns.Clear()
        dgvReceivingMonthlySummary.Columns.Add("Vendor", "Vendor")
        dgvReceivingMonthlySummary.Columns("Vendor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvReceivingMonthlySummary.Columns.Add("RMID", "Material")
        dgvReceivingMonthlySummary.Columns("RMID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        While DateDiff(DateInterval.Month, StartDate, EndDate) >= 0
            dgvReceivingMonthlySummary.Columns.Add(StartDate.Month.ToString() + "/" + StartDate.Year.ToString() + "Weight", MonthName(StartDate.Month) + " " + StartDate.Year.ToString() + " Weight")
            dgvReceivingMonthlySummary.Columns(StartDate.Month.ToString() + "/" + StartDate.Year.ToString() + "Weight").DefaultCellStyle.Format = "N2"
            dgvReceivingMonthlySummary.Columns(StartDate.Month.ToString() + "/" + StartDate.Year.ToString() + "Weight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvReceivingMonthlySummary.Columns.Add(StartDate.Month.ToString() + "/" + StartDate.Year.ToString() + "Cost", MonthName(StartDate.Month) + " " + StartDate.Year.ToString() + " Cost")
            dgvReceivingMonthlySummary.Columns(StartDate.Month.ToString() + "/" + StartDate.Year.ToString() + "Cost").DefaultCellStyle.Format = "C2"
            dgvReceivingMonthlySummary.Columns(StartDate.Month.ToString() + "/" + StartDate.Year.ToString() + "Cost").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            StartDate = StartDate.AddMonths(1)
        End While
        dgvReceivingMonthlySummary.ResumeLayout()
    End Sub

    Private Sub InsertDataIntoDGV(ByRef dt As Data.DataTable)
        Dim i As Integer = 0
        Dim currentVendor As String = ""
        Dim currentMaterial As String = ""

        While i < dt.Rows.Count
            Dim newRowCreated As Boolean = False
            If Not currentVendor.Equals(dt.Rows(i).Item("SteelVendor")) Then
                newRowCreated = True
                currentVendor = dt.Rows(i).Item("SteelVendor")
                dgvReceivingMonthlySummary.Rows.Add(currentVendor)
            End If
            If Not currentMaterial.Equals(dt.Rows(i).Item("RMID")) Then
                currentMaterial = dt.Rows(i).Item("RMID")
                If Not newRowCreated Then
                    newRowCreated = True
                    dgvReceivingMonthlySummary.Rows.Add(currentVendor, currentMaterial)
                Else
                    dgvReceivingMonthlySummary.Rows(dgvReceivingMonthlySummary.Rows.Count - 1).Cells("RMID").Value = currentMaterial
                End If
            End If
            dgvReceivingMonthlySummary.Rows(dgvReceivingMonthlySummary.Rows.Count - 1).Cells(dt.Rows(i).Item("ReceivingMonthYear") + "Weight").Value = FormatNumber(dt.Rows(i).Item("TotalWeight"), 0).ToString()
            dgvReceivingMonthlySummary.Rows(dgvReceivingMonthlySummary.Rows.Count - 1).Cells(dt.Rows(i).Item("ReceivingMonthYear") + "Cost").Value = FormatCurrency(dt.Rows(i).Item("TotalCost")).ToString()
            i += 1
        End While
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dtpBeginningDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBeginningDate.ValueChanged
        If dtpBeginningDate.Focused Then
            If Not chkUseDateRange.Checked Then
                chkUseDateRange.Checked = True
            End If
        End If
    End Sub

    Private Sub dtpEndingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEndingDate.ValueChanged
        If dtpEndingDate.Focused Then
            If Not chkUseDateRange.Checked Then
                chkUseDateRange.Checked = True
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isLoaded = False
        cboVendorID.SelectedIndex = -1
        If String.IsNullOrEmpty(cboVendorID.Text) Then
            cboVendorID.Text = ""
            lblVendorName.Text = ""
        End If
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
        chkUseDateRange.Checked = False
        dtpBeginningDate.Value = Now
        dtpEndingDate.Value = Now
        dgvReceivingMonthlySummary.Rows.Clear()
        dgvReceivingMonthlySummary.Columns.Clear()
        isLoaded = True
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim columnList As New List(Of String)
        If dgvReceivingMonthlySummary.Columns.Count > 0 Then
            For i As Integer = 2 To dgvReceivingMonthlySummary.Columns.Count - 1 Step 2
                columnList.Add(dgvReceivingMonthlySummary.Columns(i).HeaderText.Substring(0, dgvReceivingMonthlySummary.Columns(i).HeaderText.IndexOf(" ")))
            Next
        End If
        Dim tempds As New DataSet
        tempds.Tables.Add("SteelUsageMonthSummary")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("DivisionID")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("RMID")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("January2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("January2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("Febuary2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("Febuary2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("March2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("March2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("April2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("April2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("May2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("May2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("June2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("June2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("July2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("July2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("August2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("August2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("September2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("September2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("October2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("October2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("November2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("November2012Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("December2011Total")
        tempds.Tables("SteelUsageMonthSummary").Columns.Add("December2012Total")

        For i As Integer = 0 To dgvReceivingMonthlySummary.Rows.Count - 1
            tempds.Tables("SteelUsageMonthSummary").Rows.Add(dgvReceivingMonthlySummary.Rows(i).Cells("Vendor").Value, dgvReceivingMonthlySummary.Rows(i).Cells("RMID").Value)
            If dgvReceivingMonthlySummary.Columns.Count <= 26 Then
                For j As Integer = 2 To dgvReceivingMonthlySummary.Columns.Count - 1
                    If dgvReceivingMonthlySummary.Rows(i).Cells(j).Value Is Nothing Then
                        tempds.Tables("SteelUsageMonthSummary").Rows(tempds.Tables("SteelUsageMonthSummary").Rows.Count - 1).Item(j) = 0
                    Else
                        tempds.Tables("SteelUsageMonthSummary").Rows(tempds.Tables("SteelUsageMonthSummary").Rows.Count - 1).Item(j) = dgvReceivingMonthlySummary.Rows(i).Cells(j).Value
                    End If
                Next
            Else
                For j As Integer = 2 To 25
                    If dgvReceivingMonthlySummary.Rows(i).Cells(j).Value Is Nothing Then
                        tempds.Tables("SteelUsageMonthSummary").Rows(tempds.Tables("SteelUsageMonthSummary").Rows.Count - 1).Item(j) = 0
                    Else
                        tempds.Tables("SteelUsageMonthSummary").Rows(tempds.Tables("SteelUsageMonthSummary").Rows.Count - 1).Item(j) = dgvReceivingMonthlySummary.Rows(i).Cells(j).Value
                    End If
                Next
            End If
        Next
        Dim newPrintSteelReceivingSummary As New PrintSteelReceivingSummary(tempds, columnList)
        newPrintSteelReceivingSummary.ShowDialog()
    End Sub

    Private Sub cboVendorID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.TextChanged
        If String.IsNullOrEmpty(cboVendorID.Text) Then
            lblVendorName.Text = ""
        End If
    End Sub

    Private Sub cboSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
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

    Private Sub ViewSteelReceivingMonthlySummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class