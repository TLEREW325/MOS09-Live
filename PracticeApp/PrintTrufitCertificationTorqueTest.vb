Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PrintTrufitCertificationTorqueTest
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim MyReport As New CRXTrufitCertificationTorqueTest

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal TFPCert As String)
        InitializeComponent()
        GenerateReport(TFPCert)

    End Sub

    Public Sub New(ByRef ds As DataSet)
        InitializeComponent()
        GenerateReport(ds)
    End Sub

    Private Sub GenerateReport(ByVal TFPCertNumber As String)
        Dim cmd As New SqlCommand("SELECT TrufitCertificationTorqueTestHeader.TestNumber, TrufitCertificationTorqueTestHeader.LotNumber, TrufitCertificationTorqueTestHeader.HeatNumber, FOXTable.PartNumber, TrufitCertificationTorqueTestHeader.Description, TrufitCertificationTorqueTestHeader.TestedBy, TrufitCertificationTorqueTestHeader.ApprovedBy FROM TrufitCertificationTorqueTestHeader INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationTorqueTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationTorqueTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(TFPCertNumber)
        Dim ds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)
        Dim cmd1 As New SqlCommand("SELECT TrufitCertificationTorqueTestLine.TestNumber, SampleNumber, RequiredTorque, ActualTorque, Remarks FROM TrufitCertificationTorqueTestLine INNER JOIN TrufitCertificationTorqueTestHeader ON TrufitCertificationTorqueTestLine.TestNumber = TrufitCertificationTorqueTestHeader.TestNumber INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationTorqueTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber WHERE TrufitCertificationTorqueTestHeader.Status = 'CLOSED' AND TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber ORDER BY TrufitCertificationTorqueTestLine.TestNumber, TrufitCertificationTorqueTestLine.SampleNumber", con)
        cmd1.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(TFPCertNumber)
        Dim adap1 As New SqlDataAdapter(cmd1)
        Dim cmd2 As New SqlCommand("SELECT CustomerName FROM CustomerList INNER JOIN FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(TFPCertNumber)

        Dim CustomerName As String = ""
        Dim TorqueRequirement As Double = 0
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "TrufitCertificationTorqueTestHeader")
        adap1.Fill(ds, "TrufitCertificationTorqueTestLine")

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd2.ExecuteScalar()

        If Not IsDBNull(obj) Then
            If obj IsNot Nothing Then
                CustomerName = obj
            End If
        End If

        cmd.CommandText = "SELECT TorqueRequirement FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber"
        obj = cmd.ExecuteScalar()
        If Not IsDBNull(obj) Then
            If obj IsNot Nothing Then
                TorqueRequirement = Val(obj)
            End If
        End If

        cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber INNER JOIN TrufitCertificationHeatLines ON LotNumber.LotNumber = TrufitCertificationHeatLines.LotNumber WHERE TrufitCertNumber = @TrufitCertNumber"

        Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()
        con.Close()
        ''changes the part nubmer to show revision level behind it, only for Branam
        If ds.Tables("TrufitCertificationTorqueTestHeader").Rows.Count > 0 And BlueprintRevLevel IsNot Nothing And CustomerName.Contains("BRANAM") Then
            For p As Integer = 0 To ds.Tables("TrufitCertificationTorqueTestHeader").Rows.Count - 1
                ds.Tables("TrufitCertificationTorqueTestHeader").Rows(p).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
            Next
        End If


        Dim i As Integer = 0

        While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count
            Dim sample As Integer = 1
            Dim currentTest As String = ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber")
            While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count AndAlso currentTest.Equals(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber"))
                ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") = TorqueRequirement
                If ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") > ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") Then
                    ds.Tables("TrufitCertificationTorqueTestLine").Rows.RemoveAt(i)
                Else
                    ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("SampleNumber") = sample
                    ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") = Math.Ceiling(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque"))
                    i += 1
                    sample += 1
                End If
            End While
        End While

        CType(MyReport.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName

        MyReport.SetDataSource(ds)
        CRVViewTorqueTest.ReportSource = MyReport
    End Sub

    Private Sub GenerateReport(ByRef ds As DataSet)
        Dim inp As New StringNumberInputBox("Input a Required Torque", 0, 6, True)
        If inp.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim i As Integer = 0
            Dim sample As Integer = 1
            While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count
                ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") = Val(inp.txtInput.Text)
                If ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") > ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") Then
                    ds.Tables("TrufitCertificationTorqueTestLine").Rows.RemoveAt(i)
                Else
                    ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("SampleNumber") = sample
                    ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") = Math.Ceiling(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque"))
                    i += 1
                    sample += 1
                End If
            End While

            Dim cmd As SqlCommand
            Dim CustomerName As String = ""
            If Not ds.Tables.Contains("TrufitCertificationTable") And ds.Tables.Contains("TrufitCertificationTorqueTestHeader") Then
                cmd = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM LotNumber WHERE LotNumber = (SELECT LotNumber FROM TrufitCertificationTorqueTestHeader WHERE TestNumber = @TestNumber))) as tmp on CustomerList.CustomerID = tmp.CustomerID AND CustomerList.DivisionID = tmp.DivisionID", con)
                cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = ds.Tables("TrufitCertificationTorqueTestHeader").Rows(0).Item("TestNumber")
            Else
                cmd = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber) ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = ds.Tables("TrufitCertificationTable").Rows(0).Item("FOXNumber")
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If Not IsDBNull(obj) Then
                If obj IsNot Nothing Then
                    CustomerName = obj
                End If
            End If

            CType(MyReport.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName

            MyReport.SetDataSource(ds)
            CRVViewTorqueTest.ReportSource = MyReport
        End If

    End Sub
End Class