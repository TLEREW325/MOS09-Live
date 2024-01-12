Imports System.IO
Imports System.Data
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook
Public Class PrintTrufitCert
    Inherits System.Windows.Forms.Form

    'Variables for Date/Filename Creation
    Dim ConfirmName As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim ds As DataSet

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim bgSaveFile As New System.ComponentModel.BackgroundWorker

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal tfpCertNumber As Integer)
        InitializeComponent()
        Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
        Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = tfpCertNumber

        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = 'TFP'", con)

        cmd2 = New SqlCommand("SELECT CustomerList.CustomerID, CustomerList.CustomerName, CustomerList.BillToAddress1, CustomerList.BillToAddress2, CustomerList.BillToCity, CustomerList.BillToState, CustomerList.BillToZip FROM CustomerList INNER JOIN (SELECT DivisionID, CustomerID FROM TrufitCertificationTable INNER JOIN SalesOrderHeaderTable ON TrufitCertificationTable.SalesOrderNumber = SalesOrderHeaderTable.SalesOrderKey WHERE TrufitCertNumber = @TrufitCertNumber) as TFPCert on CustomerList.CustomerID = TFPCert.CustomerID AND CustomerList.DivisionID = TFPCert.DivisionID", con)
        cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = tfpCertNumber

        cmd3 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd3.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = tfpCertNumber

        cmd4 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE DivisionID = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd4.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = tfpCertNumber

        cmd5 = New SqlCommand("SELECT * FROM FOXTable WHERE DivisionID = 'TFP' AND FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd5.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = tfpCertNumber

        cmd6 = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE DivisionID = 'TWD'", con)

        cmd7 = New SqlCommand("SELECT * FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd7.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = tfpCertNumber

        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter1.SelectCommand = cmd1
        myAdapter2.SelectCommand = cmd2
        myAdapter3.SelectCommand = cmd3
        myAdapter4.SelectCommand = cmd4
        myAdapter5.SelectCommand = cmd5
        myAdapter6.SelectCommand = cmd6
        myAdapter7.SelectCommand = cmd7

        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter.Fill(ds, "TrufitCertificationTable")
        myAdapter1.Fill(ds, "DivisionTable")
        myAdapter2.Fill(ds, "CustomerList")
        myAdapter3.Fill(ds, "SalesOrderHeaderTable")
        myAdapter4.Fill(ds, "SalesOrderLineTable")
        myAdapter5.Fill(ds, "FOXTable")
        myAdapter6.Fill(ds, "RawMaterialsTable")
        myAdapter7.Fill(ds, "TrufitCertificationHeatLines")

        Dim cmd10 As New SqlCommand("SELECT CustomerPO FROM TrufitCertificationPickTicket INNER JOIN PickListHeaderTable ON TrufitCertificationPickTicket.PickTicket = PickListHeaderTable.PickListHeaderKey WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd10.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = tfpCertNumber
        Dim myAdapter10 As New SqlDataAdapter(cmd10)
        myAdapter10.Fill(ds, "TrufitCertificationPickTicket")

        If ds.Tables("TrufitCertificationPickTicket").Rows.Count > 0 Then
            Dim lst As New List(Of String)
            For i As Integer = 0 To ds.Tables("TrufitCertificationPickTicket").Rows.Count - 1
                If Not lst.Contains(ds.Tables("TrufitCertificationPickTicket").Rows(i).Item("CustomerPO").ToString) Then
                    lst.Add(ds.Tables("TrufitCertificationPickTicket").Rows(i).Item("CustomerPO").ToString)
                End If
            Next
            If lst.Count > 0 Then
                ds.Tables("TrufitCertificationPickTicket").Rows(0).Item("CustomerPO") = String.Join(",", lst.ToArray())
            End If
        End If

        cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = (SELECT TOP 1 LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber)"

        Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()
        ''changes the part nubmer to show revision level behind it, only for Branam
        If ds.Tables("FOXTable").Rows.Count > 0 And BlueprintRevLevel IsNot Nothing And ds.Tables("CustomerList").Rows.Count > 0 Then
            If ds.Tables("CustomerList").Rows(0).Item("CustomerID").ToString().Equals("BRANAMFASTEN") Then
                For i As Integer = 0 To ds.Tables("FOXTable").Rows.Count - 1
                    ds.Tables("FOXTable").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                Next
            End If
        End If
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXTFCert1
        MyReport.SetDataSource(ds)
        CRTFCertViewer.ReportSource = MyReport
        AddHandler bgSaveFile.DoWork, AddressOf bgSaveFile_DoWork
        AddHandler bgSaveFile.RunWorkerCompleted, AddressOf bgSaveFile_RunWorkerCompleted

        Dim fileName As String = ""

        For i As Integer = 0 To ds.Tables("TrufitCertificationHeatLines").Rows.Count - 1
            fileName += ds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString() + " "
        Next

        Dim notfound As Boolean = True

        For i As Integer = 0 To ds.Tables("FOXTable").Rows.Count - 1 And notfound
            If ds.Tables("FOXTable").Rows(i).Item("FOXNumber").ToString().Equals(ds.Tables("TrufitCertificationTable").Rows(0).Item("FOXNumber").ToString()) Then
                notfound = False
                fileName += ds.Tables("FOXTable").Rows(i).Item("PartNumber").ToString()
            End If
        Next

        ConfirmName = ds.Tables("FOXTable").Rows(0).Item("CustomerID").ToString() + "\" + fileName + " " + tfpCertNumber.ToString()

        bgSaveFile.RunWorkerAsync()
    End Sub


    Private Sub bgSaveFile_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + ds.Tables("FOXTable").Rows(0).Item("CustomerID").ToString()) Then
            Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + ds.Tables("FOXTable").Rows(0).Item("CustomerID").ToString())
        End If
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + ConfirmName + ".pdf")
    End Sub

    Private Sub bgSaveFile_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim checkFile As New System.IO.FileInfo("\\TFP-FS\TransferData\TrufitCerts\" + ConfirmName + ".pdf")
        If Not checkFile.Exists() Then
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + ConfirmName + ".pdf")
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCertToolStripMenuItem.Click
        Dim OLApp As New Application
        'creating outlook mailitem
        Dim mail As MailItem
        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)
        'adding subject information to the mail message
        mail.Subject = "Trufit Certification"
        'adding body message information to the mail message
        mail.Body = "This is a Certification from TFP Corporation."
        While bgSaveFile.IsBusy
            System.Threading.Thread.Sleep(1000)
        End While
        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + ConfirmName + ".pdf")
        'display mail
        mail.Display()
    End Sub

    Private Sub CRTFCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRTFCertViewer.Load

    End Sub
End Class