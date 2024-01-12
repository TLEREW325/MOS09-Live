Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class PrintHeaderSetupSheet

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal setupKey As Integer)
        InitializeComponent()

        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT SetupKey, FOXNumber, Date, Description, BlueprintNumber, BlueprintRevision, Operator, MachineNumber, CustomerID, Comments FROM HeaderSetupHeaderTable WHERE SetupKey = @SetupKey", con)
        cmd.Parameters.Add("@SetupKey", SqlDbType.Int).Value = setupKey
        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        Dim cmd2 As New SqlCommand("SELECT SetupKey, StationNumber, HammerLength, HammerPinLength, HammerFillerLength, HammerBlockFillerLength, PositiveKnockOutPinLength, WedgeLength, LengthAdjuster, Buttons FROM HeaderSetupLineTable WHERE SetupKey = @SetupKey Order BY StationNumber", con)
        cmd2.Parameters.Add("@SetupKey", SqlDbType.Int).Value = setupKey
        Dim adap2 As New SqlDataAdapter(cmd2)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "HeaderSetupHeaderTable")
        adap2.Fill(tempds, "HeaderSetupLineTable")
        con.Close()

        Dim rw As DataRow = tempds.Tables("HeaderSetupLineTable").NewRow()
        rw.Item(0) = setupKey
        rw.Item(1) = 0

        tempds.Tables("HeaderSetupLineTable").Rows.InsertAt(rw, 0)

        While tempds.Tables("HeaderSetupLineTable").Rows.Count <> 7
            tempds.Tables("HeaderSetupLineTable").Rows.Add(setupKey, tempds.Tables("HeaderSetupLineTable").Rows.Count)
        End While
        Dim MyReport As New CRXHeaderSetupSheet()
        MyReport.SetDataSource(tempds)

        CRVHeaderSetupSheet.ReportSource = MyReport
    End Sub
End Class