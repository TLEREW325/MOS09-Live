Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook

Public Class PrintTrufitCertificationMechanicalTest

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal dsIn As DataSet)
        InitializeComponent()
        GenerateReport(dsIn.Copy())
    End Sub

    Public Sub New(ByVal TPFCertNumber As String)
        InitializeComponent()
        GenerateReport(TPFCertNumber)
    End Sub
    'Created Outlook Application object
    Dim OLApp As New Application
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim ConfirmName As String

    Dim bgSaveFile As New System.ComponentModel.BackgroundWorker
    Dim MyReport As New CRXTrufitCertMechanicalTest

    Private Sub GenerateReport(ByRef ds As DataSet)

        Dim cmd As SqlCommand
        Dim CustomerName As String = ""
        If Not ds.Tables.Contains("TrufitCertificationTable") And ds.Tables.Contains("TrufitCertificationMechanicalTestHeader") Then
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM LotNumber WHERE LotNumber = (SELECT LotNumber FROM TrufitCertificationMechanicalTestHeader WHERE TestNumber = @TestNumber))) as tmp on CustomerList.CustomerID = tmp.CustomerID AND CustomerList.DivisionID = tmp.DivisionID", con)
            cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = ds.Tables("TrufitCertificationMechanicalTestHeader").Rows(0).Item("TestNumber")
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
        CRTFCertViewer.ReportSource = MyReport
        Dim mon As String = Today.Date.Month.ToString

        If mon.Length = 1 Then
            mon = "0" + mon
        End If

        Dim da As String = Today.Date.Day.ToString()
        If da.Length = 1 Then
            da = "0" + da
        End If
        ConfirmName = ds.Tables("TrufitCertificationMechanicalTestHeader").Rows(0).Item("LotNumber").ToString() + " " + ds.Tables("TrufitCertificationMechanicalTestHeader").Rows(0).Item("HeatNumber").ToString() + " " + mon + da + Now.Year.ToString()

        If System.IO.File.Exists("\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf") Then
            System.IO.File.Delete("\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf")
        End If

        AddHandler bgSaveFile.DoWork, AddressOf bgSaveFile_DoWork
        AddHandler bgSaveFile.RunWorkerCompleted, AddressOf bgSaveFile_RunWorkerCompleted

        bgSaveFile.RunWorkerAsync()
    End Sub
    Private Sub GenerateReport(ByVal TFPCertNumber As String)
        Dim cmd As New SqlCommand("SELECT TestNumber, TrufitCertificationMechanicalTestHeader.LotNumber, TrufitCertificationMechanicalTestHeader.HeatNumber, FOXTable.PartNumber, Description, TestedBy, ApprovedBy FROM TrufitCertificationMechanicalTestHeader INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(TFPCertNumber)
        Dim ds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)
        Dim cmd1 As New SqlCommand("SELECT TrufitCertificationMechanicalTestLine.TestNumber, ResultNumber, Area, ProofPound, LoadPSI, UltimatePound, TensilePSI, LoadMPA, TensileMPA, Results FROM TrufitCertificationMechanicalTestLine INNER JOIN TrufitCertificationMechanicalTestHeader ON TrufitCertificationMechanicalTestLine.TestNumber = TrufitCertificationMechanicalTestHeader.TestNumber INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable on TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber inner join FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
        cmd1.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(TFPCertNumber)
        Dim adap1 As New SqlDataAdapter(cmd1)
        Dim cmd2 As New SqlCommand("SELECT CustomerName FROM CustomerList INNER JOIN FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(TFPCertNumber)

        Dim CustomerName As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "TrufitCertificationMechanicalTestHeader")
        adap1.Fill(ds, "TrufitCertificationMechanicalTestLine")

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd2.ExecuteScalar()

        If Not IsDBNull(obj) Then
            If obj IsNot Nothing Then
                CustomerName = obj
            End If
        End If

        CType(MyReport.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName

        cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber INNER JOIN TrufitCertificationHeatLines ON LotNumber.LotNumber = TrufitCertificationHeatLines.LotNumber WHERE TrufitCertNumber = @TrufitCertNumber"

        Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()
        con.Close()
        ''changes the part nubmer to show revision level behind it, only for Branam
        If ds.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count > 0 And BlueprintRevLevel IsNot Nothing And CustomerName.Contains("BRANAM") Then
            For i As Integer = 0 To ds.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count - 1
                ds.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
            Next
        End If

        MyReport.SetDataSource(ds)
        CRTFCertViewer.ReportSource = MyReport
        Dim mon As String = Today.Date.Month.ToString

        If mon.Length = 1 Then
            mon = "0" + mon
        End If

        Dim da As String = Today.Date.Day.ToString()
        If da.Length = 1 Then
            da = "0" + da
        End If
        If ds.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count > 0 Then

            ConfirmName = ds.Tables("TrufitCertificationMechanicalTestHeader").Rows(0).Item("LotNumber").ToString() + " " + ds.Tables("TrufitCertificationMechanicalTestHeader").Rows(0).Item("HeatNumber").ToString() + " " + mon + da + Now.Year.ToString()
        Else
            ConfirmName = "tmpMechTestFile"
        End If
        If System.IO.File.Exists("\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf") Then
            System.IO.File.Delete("\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf")
        End If

        AddHandler bgSaveFile.DoWork, AddressOf bgSaveFile_DoWork
        AddHandler bgSaveFile.RunWorkerCompleted, AddressOf bgSaveFile_RunWorkerCompleted

        bgSaveFile.RunWorkerAsync()
    End Sub

    Private Sub bgSaveFile_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf")
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgSaveFile_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim checkFile As New System.IO.FileInfo("\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf")
        If Not checkFile.Exists() Then
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf")
        End If
    End Sub

    Private Sub EmailCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCertToolStripMenuItem.Click
        'creating outlook mailitem
        Dim mail As MailItem
        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'Dim recipient As Recipient
        'Adding recipeints to the mail message
        'recipient = mail.Recipients.Add("name@hotmail.com")
        'Do Check Name here
        'recipient.Resolve()

        'adding subject information to the mail message
        mail.Subject = "Trufit Mechanical Test"

        'adding body message information to the mail message
        mail.Body = "This is a Mechanical Test from Truweld / TFP Corporation."

        While bgSaveFile.IsBusy
            System.Threading.Thread.Sleep(1000)
        End While
        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TFPMechanicalTest\" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub

End Class