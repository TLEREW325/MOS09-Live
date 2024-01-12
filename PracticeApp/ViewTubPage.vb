Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports

Public Class ViewTubPage
    Dim LotNumber As String
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal FOX As String, ByVal Lot As String, Optional ByVal AddPullTestSignoff As Boolean = False, Optional ByVal AddTorqueSignOff As Boolean = False)
        InitializeComponent()
        LotNumber = Lot
        Dim TodaysDate As Date = Today()
        Dim intDay, intMonth, intYear As Integer
        Dim strDay, strMonth, strYear As String
        Dim NewDate As String

        intDay = TodaysDate.Day
        intMonth = TodaysDate.Month
        intYear = TodaysDate.Year

        strDay = CStr(intDay)
        strMonth = CStr(intMonth)
        strYear = CStr(intYear - 1)

        NewDate = strDay + "/" + strMonth + "/" + strYear


        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT FOXNumber, ProcessStep, ProcessID, FOXNumber as ProcessRemoveRM FROM FOXSched WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FOX)
        Dim cmd1 As New SqlCommand("SELECT * FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd1.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = Lot
        Dim cmd2 As New SqlCommand("SELECT * FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd2.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FOX)
        Dim cmd3 As New SqlCommand("SELECT ProcessStep as MachineCostPerHour, MachineID, Description, FOXNumber as DivisionID FROM MachineTable INNER JOIN FOXSched ON ProcessID = MachineID WHERE FOXNumber = @FOXNumber", con)
        cmd3.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FOX)
        Dim cmd4 As New SqlCommand("SELECT * FROM FOXCertifications WHERE FOXNumber = @FOXNumber", con)
        cmd4.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FOX)
        'Dim cmd5 As New SqlCommand("SELECT Comments, ShortDescription FROM ItemList", con)
        Dim cmd6 As New SqlCommand("SELECT TOP 5 (QCTransactionNumber),(FoxNumber),(NonConformanceReason) FROM QCHoldAdjustment WHERE FOXNumber = @FOXNumber order by QCTransactionNumber DESC", con)
        cmd6.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FOX)

        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)
        Dim adap1 As New SqlDataAdapter(cmd1)
        Dim adap2 As New SqlDataAdapter(cmd2)
        Dim adap3 As New SqlDataAdapter(cmd3)
        'Dim adap5 As New SqlDataAdapter(cmd5)
        Dim adap4 As New SqlDataAdapter(cmd4)

        Dim adap6 As New SqlDataAdapter(cmd6)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "FOXSched")
        adap1.Fill(tempds, "LotNumber")
        adap2.Fill(tempds, "FOXTable")
        adap3.Fill(tempds, "MachineTable")
        adap4.Fill(tempds, "FOXCertifications")
        'adap5.Fill(tempds, "ItemList")
        adap6.Fill(tempds, "QCHoldAdjustment")
        con.Close()

        If tempds.Tables("LotNumber").Rows.Count > 0 Then
            tempds.Tables("LotNumber").Rows(0).Item("UserID") = AddPullTestSignoff.ToString()
            tempds.Tables("LotNumber").Rows(0).Item("Status") = AddTorqueSignOff.ToString()
        End If

        MyReport = New CRXTubtag()
        MyReport.SetDataSource(tempds)

        CRVTubPage.ReportSource = MyReport
        ''Dim menus As IEnumerable(Of MenuStrip) = CRVTubPage.Controls.OfType(System.Windows.Forms.MenuStrip)
        For Each ctrl As Control In CRVTubPage.Controls
            If TypeOf ctrl Is System.Windows.Forms.ToolStrip Then
                AddHandler (CType(ctrl, ToolStrip).Items(1).Click), AddressOf AfterPrint
            End If
        Next
    End Sub

    Private Sub AfterPrint(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("INSERT INTO TFPLotActivityLog (ActivityDateTime, LotNumber, LoginName, ChangedField, OriginalValue, NewValue) VALUES (CURRENT_TIMESTAMP, @LotNumber, @LoginName, 'PRINTED', 'NO', 'YES')", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
        cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception

        End Try

        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Private Sub CRVTubPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVTubPage.Load

    End Sub
End Class