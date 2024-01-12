Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintHeatTreatCert
    Inherits System.Windows.Forms.Form


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal heatRecord As String)
        InitializeComponent()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecord

        cmd1 = New SqlCommand("SELECT * FROM HeatTreatRockwellTest WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd1.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecord

        cmd2 = New SqlCommand("SELECT * FROM HeatTreatTemperatureDraw WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd2.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecord

        cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE RMID = (SELECT TOP 1 RMID FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber)", con)
        cmd3.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecord

        cmd4 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = (SELECT TOP 1 DivisionID FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber) AND ItemID = (SELECT TOP 1 PartNumber FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber)", con)
        cmd4.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecord

        cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = (SELECT TOP 1 DivisionID FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber)", con)
        cmd5.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecord

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "HeatTreatInspectionLog")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "HeatTreatRockwellTest")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "HeatTreatTemperatureDraw")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "RawMaterialsTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ItemList")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "CustomerList")

        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXHeatTreatCert1
        MyReport.SetDataSource(ds)
        CRHeatTreatViewer.ReportSource = MyReport
    End Sub

    Public Sub New(ByVal heatRecords As String())
        InitializeComponent()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd1 = New SqlCommand("SELECT * FROM HeatTreatRockwellTest WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd1.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd2 = New SqlCommand("SELECT * FROM HeatTreatTemperatureDraw WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd2.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable", con)

        cmd4 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = (SELECT TOP 1 DivisionID FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber) AND ItemID = (SELECT TOP 1 PartNumber FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber)", con)
        cmd4.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = (SELECT TOP 1 DivisionID FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber)", con)
        cmd5.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        If heatRecords.Count > 1 Then
            For i As Integer = 1 To heatRecords.Count - 1
                cmd.CommandText += " OR HeatTreatRecordNumber = @HeatTreatRecordNumber" + i.ToString()
                cmd.Parameters.Add("@HeatTreatRecordNumber" + i.ToString(), SqlDbType.VarChar).Value = heatRecords(i)
                cmd1.CommandText += " OR HeatTreatRecordNumber = @HeatTreatRecordNumber" + i.ToString()
                cmd1.Parameters.Add("@HeatTreatRecordNumber" + i.ToString(), SqlDbType.VarChar).Value = heatRecords(i)
                cmd2.CommandText += " OR HeatTreatRecordNumber = @HeatTreatRecordNumber" + i.ToString()
                cmd2.Parameters.Add("@HeatTreatRecordNumber" + i.ToString(), SqlDbType.VarChar).Value = heatRecords(i)

            Next
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "HeatTreatInspectionLog")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "HeatTreatRockwellTest")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "HeatTreatTemperatureDraw")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "RawMaterialsTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ItemList")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "CustomerList")

        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXHeatTreatCert1
        MyReport.SetDataSource(ds)
        CRHeatTreatViewer.ReportSource = MyReport
    End Sub


    Public Sub New(ByVal heatRecords As String(), ByVal customer As String, ByVal PartNumber As String)
        InitializeComponent()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd1 = New SqlCommand("SELECT * FROM HeatTreatRockwellTest WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd1.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd2 = New SqlCommand("SELECT * FROM HeatTreatTemperatureDraw WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd2.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable", con)

        cmd4 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = (SELECT TOP 1 DivisionID FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber) AND ItemID = (SELECT TOP 1 PartNumber FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber)", con)
        cmd4.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)

        cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = (SELECT TOP 1 DivisionID FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber) and CustomerID = @CustomerID", con)
        cmd5.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.VarChar).Value = heatRecords(0)
        cmd5.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customer

        If heatRecords.Count > 1 Then
            For i As Integer = 1 To heatRecords.Count - 1
                cmd.CommandText += " OR HeatTreatRecordNumber = @HeatTreatRecordNumber" + i.ToString()
                cmd.Parameters.Add("@HeatTreatRecordNumber" + i.ToString(), SqlDbType.VarChar).Value = heatRecords(i)
                cmd1.CommandText += " OR HeatTreatRecordNumber = @HeatTreatRecordNumber" + i.ToString()
                cmd1.Parameters.Add("@HeatTreatRecordNumber" + i.ToString(), SqlDbType.VarChar).Value = heatRecords(i)
                cmd2.CommandText += " OR HeatTreatRecordNumber = @HeatTreatRecordNumber" + i.ToString()
                cmd2.Parameters.Add("@HeatTreatRecordNumber" + i.ToString(), SqlDbType.VarChar).Value = heatRecords(i)
            Next
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "HeatTreatInspectionLog")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "HeatTreatRockwellTest")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "HeatTreatTemperatureDraw")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "RawMaterialsTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ItemList")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "CustomerList")

        cmd.CommandText = "SELECT TOP 1 LotNumber FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber"
        Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()
        If BlueprintRevLevel IsNot Nothing Then
            cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber"
            If BlueprintRevLevel.ToString.Contains("-") Then
                cmd.Parameters.Add("@LotNumber", SqlDbType.Int).Value = Val(BlueprintRevLevel.ToString.Substring(0, BlueprintRevLevel.ToString.LastIndexOf("-")))
            Else
                cmd.Parameters.Add("@LotNumber", SqlDbType.Int).Value = Val(BlueprintRevLevel.ToString)
            End If

            BlueprintRevLevel = cmd.ExecuteScalar()
        End If
        con.Close()

        For i As Integer = 0 To ds.Tables("HeatTreatInspectionLog").Rows.Count - 1
            ds.Tables("HeatTreatInspectionLog").Rows(i).Item("CustomerID") = customer
            If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                ds.Tables("HeatTreatInspectionLog").Rows(i).Item("PartNumber") = PartNumber + " Rev. " + BlueprintRevLevel.ToString()
            End If
        Next

        For j As Integer = 0 To ds.Tables("ItemList").Rows.Count - 1
            ds.Tables("ItemList").Rows(j).Item("ItemID") = PartNumber
        Next

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXHeatTreatCert1
        MyReport.SetDataSource(ds)
        CRHeatTreatViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRHeatTreatViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRHeatTreatViewer.Load

    End Sub
End Class