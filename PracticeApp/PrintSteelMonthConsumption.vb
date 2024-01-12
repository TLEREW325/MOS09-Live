Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintSteelMonthConsumption
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim ds As New DataSet

    Public Sub New()
        InitializeComponent()
        ds = New DataSet()
    End Sub

    Public Sub New(ByVal dat As DataSet)
        InitializeComponent()
        ds = dat
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelMonthConsumption1
        MyReport.SetDataSource(ds)
        CRSteelViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    'Private Sub CRSteelViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRSteelViewer.Load
    '    'Loads data into dataset for viewing
    '    If ds.Tables.Count = 0 Then
    '        ds = getDataSet()
    '    End If
    '    'Sets up viewer to display data from the loaded dataset
    '    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '    MyReport = CRXSteelMonthConsumption1
    '    MyReport.SetDataSource(ds)
    '    CRSteelViewer.ReportSource = MyReport
    'End Sub

    Private Function getDataSet() As DataSet
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As SqlCommand = New SqlCommand("SELECT Carbon, SteelSize ", con)
        Dim count As Integer = 0
        Dim month As Integer = Today.Date.Month
        Dim year As Integer = Today.Date.Year
        Dim columns As New List(Of String)
        Dim selectStatments As String = ""
        ''goes through 12 months and generates the selections
        While count < 12
            columns.Add("[" + getMonthWord(month) + " " + year.ToString() + "]")
            If count = 0 Then
                selectStatments += " FROM (SELECT Carbon, SteelSize, CASE WHEN UsageDate >= '" + getBeginMonth(month, year).ToShortDateString() + "' AND UsageDate <= '" + getEndOfMonth(month, year).ToShortDateString() + "' THEN UsageWeight ELSE 0 END AS " + columns(columns.Count - 1)
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
        cmd.CommandText += " RIGHT OUTER JOIN "
        cmd.CommandText += "RawMaterialsTable on RawMaterialsTable.RMID = SteelUsageTable.RMID) AS SteelUsageTable GROUP By Carbon, SteelSize"
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelUsageTable")
        con.Close()
        ds.Tables("SteelUsageTable").TableName = "SteelUsageMonthSummary"
        For i As Integer = 2 To ds.Tables("SteelUsageMonthSummary").Columns.Count - 1
            ds.Tables("SteelUsageMonthSummary").Columns(i).ColumnName = ds.Tables("SteelUsageMonthSummary").Columns(i).ColumnName.Substring(0, ds.Tables("SteelUsageMonthSummary").Columns(i).ColumnName.IndexOf(" ")) + "2011Total"
        Next
        Return ds
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

    Private Sub CRSteelViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRSteelViewer.Load

    End Sub
End Class