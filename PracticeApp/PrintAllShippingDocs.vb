Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Win32
Public Class PrintAllShippingDocs
    Inherits System.Windows.Forms.Form

    Dim FindLotNumber, PrintCerts, CertName As String
    Dim CountLines, ShipmentLineNumber As Integer
    Dim CheckForCerts As Integer = 0
    Dim EmailPackingSlip As String = ""

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport3 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable
    Dim SDSPrinted As New List(Of String)

    Private Sub CRPackListViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPackListViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE ShipmentNumber = @ShipmentNumber ORDER BY ShipmentNumber, ShipmentLineNumber", con)
        cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd7 = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID", con)
        cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd8 = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd9 = New SqlCommand("SELECT * FROM ShipmentLineHeatNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd9.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd10 = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd10.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ShipmentLineQuery2")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "CustomerList")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "FoxTable")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "AdditionalShipTo")

        myAdapter7.SelectCommand = cmd7
        myAdapter7.Fill(ds, "AssemblyLineTable")

        myAdapter8.SelectCommand = cmd8
        myAdapter8.Fill(ds, "AssemblyHeaderTable")

        myAdapter9.SelectCommand = cmd9
        myAdapter9.Fill(ds, "ShipmentLineHeatNumbers")

        myAdapter10.SelectCommand = cmd10
        myAdapter10.Fill(ds, "ShipmentLineSerialNumbers")

        ''Save pdf in folder
        Dim strShipmentNumber As String
        strShipmentNumber = CStr(GlobalShipmentNumber)
        EmailPackingSlip = GlobalDivisionCode + strShipmentNumber + ".pdf"

        MyReport = CRXPackingSlip1
        MyReport.SetDataSource(ds)
        MyReport.PrintToPrinter(2, True, 1, 999)
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)

        'Dispose resources
        con.Close()
        CRPackListViewer.Dispose()

        cmdExit.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalCheckIfCertsWillPrint = ""
        GlobalPrintNoCertPage = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRBOLViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBOLViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd1 = New SqlCommand("SELECT * FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ShipmentLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "CustomerContacts")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "AdditionalShipTo")

        'Sets up viewer to display data from the loaded dataset
        MyReport1 = CRXBOL1
        MyReport1.SetDataSource(ds)
        MyReport1.PrintToPrinter(2, True, 1, 999)

        'Dispose of resources
        con.Close()
        CRBOLViewer.Dispose()

        cmdExit.Focus()
    End Sub

    Private Sub CRCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        Dim CheckForCertsString As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber"
        Dim CheckForCertsCommand As New SqlCommand(CheckForCertsString, con)
        CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForCerts = CInt(CheckForCertsCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForCerts = 0
        End Try
        con.Close()

        If CheckForCerts = 0 Then
            'Skip - no certs to print
        Else
            If GlobalCheckIfCertsWillPrint = "YES" Then
                'Loads data into dataset for viewing
                cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

                cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

                cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "TruweldCertData")

                myAdapter1.SelectCommand = cmd1
                myAdapter1.Fill(ds, "CustomerList")

                myAdapter2.SelectCommand = cmd2
                myAdapter2.Fill(ds, "DivisionTable")

                myAdapter3.SelectCommand = cmd3
                myAdapter3.Fill(ds, "PullTestLineTable")

                If GlobalPrintNoCertPage = "YES" Then
                    MyReport3 = CRXTruweldNOCERT1
                    MyReport3.PrintToPrinter(1, True, 1, 999)
                Else
                    'Skip
                End If

                'Sets up viewer to display data from the loaded dataset
                MyReport2 = CRXTWCert011
                MyReport2.SetDataSource(ds)
                MyReport2.PrintToPrinter(1, True, 1, 999)

                con.Close()
                CRCertViewer.Dispose()

                'Create new Filename for Cert
                Dim strGlobalShipmentNumber As String = ""
                strGlobalShipmentNumber = CStr(GlobalShipmentNumber)

                CertName = GlobalCertCustomer & " Shipment #" & strGlobalShipmentNumber

                'Export Document to Folder
                'MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\ExportedCerts\" & GlobalDivisionCode + "\" & CertName & ".pdf")
            Else
                'Skip
            End If
        End If
    End Sub

    Private Sub cmdNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNo.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE ShipmentNumber = @ShipmentNumber ORDER BY ShipmentNumber, ShipmentLineNumber", con)
        cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd7 = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID", con)
        cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd8 = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd9 = New SqlCommand("SELECT * FROM ShipmentLineHeatNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd9.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd10 = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd10.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ShipmentLineQuery2")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "CustomerList")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "FoxTable")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "AdditionalShipTo")

        myAdapter7.SelectCommand = cmd7
        myAdapter7.Fill(ds, "AssemblyLineTable")

        myAdapter8.SelectCommand = cmd8
        myAdapter8.Fill(ds, "AssemblyHeaderTable")

        myAdapter9.SelectCommand = cmd9
        myAdapter9.Fill(ds, "ShipmentLineHeatNumbers")

        myAdapter10.SelectCommand = cmd10
        myAdapter10.Fill(ds, "ShipmentLineSerialNumbers")

        ''Save pdf in folder
        Dim strShipmentNumber As String
        strShipmentNumber = CStr(GlobalShipmentNumber)
        EmailPackingSlip = GlobalDivisionCode + strShipmentNumber + ".pdf"

        'Sets up viewer to display data from the loaded dataset
        If GlobalDivisionCode = "TFP" Then
            MyReport = CRXPackingSlipTFP1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)
            con.Close()

            'Dispose resources
            CRPackListViewer.Dispose()
        Else
            MyReport = CRXPackingSlip1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & EmailPackingSlip)

            con.Close()
            CRPackListViewer.Dispose()
        End If

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd1 = New SqlCommand("SELECT * FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ShipmentLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "CustomerContacts")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "AdditionalShipTo")

        'Sets up viewer to display data from the loaded dataset
        MyReport1 = CRXBOL1
        MyReport1.SetDataSource(ds)
        MyReport1.PrintToPrinter(2, True, 1, 999)

        con.Close()
        CRBOLViewer.Dispose()

        Dim CheckForCertsString As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CheckForCertsCommand As New SqlCommand(CheckForCertsString, con)
        CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForCerts = CInt(CheckForCertsCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForCerts = 0
        End Try
        con.Close()

        If CheckForCerts = 0 Then
            'Skip - no certs to print
        Else
            If GlobalCheckIfCertsWillPrint = "YES" Then
                'Loads data into dataset for viewing
                cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

                cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

                cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "TruweldCertData")

                myAdapter1.SelectCommand = cmd1
                myAdapter1.Fill(ds, "CustomerList")

                myAdapter2.SelectCommand = cmd2
                myAdapter2.Fill(ds, "DivisionTable")

                myAdapter3.SelectCommand = cmd3
                myAdapter3.Fill(ds, "PullTestLineTable")

                If GlobalPrintNoCertPage = "YES" Then
                    MyReport3 = CRXTruweldNOCERT1
                    MyReport3.PrintToPrinter(1, True, 1, 999)
                Else
                    'Skip
                End If

                'Sets up viewer to display data from the loaded dataset
                MyReport2 = CRXTWCert011
                MyReport2.SetDataSource(ds)
                MyReport2.PrintToPrinter(1, True, 1, 999)

                con.Close()
                CRCertViewer.Dispose()
            Else
                'Skip
            End If

            cmdExit.Focus()
        End If
    End Sub

    Private Sub reprintSDS()
        For i As Integer = 0 To SDSPrinted.Count - 1
            Dim localprintserver As New LocalPrintServer()
            Dim defaultprintqueue As PrintQueue = localprintserver.GetDefaultPrintQueue()

            Dim xpsprintjob As PrintSystemJobInfo = defaultprintqueue.AddJob(SDSPrinted(i), "\\TFP-FS\TransferData\Safety Data Sheets" + SDSPrinted(i), False)
        Next
    End Sub

    Private Sub PrintAllShippingDocs_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalCheckIfCertsWillPrint = ""
        GlobalPrintNoCertPage = ""
    End Sub

    Private Sub PrintAllShippingDocs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalPrintNoCertPage = "NO"

        Me.AcceptButton = cmdExit
        cmdExit.Focus()
        'printSDS()
    End Sub

    Private Sub printSDS()
        cmd1 = New SqlCommand("SELECT DISTINCT(isnull(SafetyDataSheet, '')) as SDSName, CustomerID, isnull(SafetyDataSheets.RevisionNumber, 0) as RevisionNumber FROM ShipmentLineTable LEFT OUTER JOIN ItemList on ShipmentLineTable.PartNumber = ItemList.ItemID LEFT OUTER JOIN ShipmentHeaderTable on ShipmentLineTable.ShipmentNumber = ShipmentHeaderTable.ShipmentNumber LEFT OUTER JOIN SafetyDataSheets on ItemList.SafetyDataSheet = SafetyDataSheets.Name WHERE ShipmentLineTable.ShipmentNumber = @ShipmentNumber", con)
        cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        Dim dsTemp As New DataSet()
        Dim adap As New SqlDataAdapter(cmd1)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dsTemp, "Shipment")
        con.Close()

        Dim lstSDSAdd As New List(Of String)
        cmd = New SqlCommand("SELECT isnull(RevisionNumber, 0), DateReceived FROM SafetyDataSheetsReceived WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND SDSName = @SDSName", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = dsTemp.Tables("Shipment").Rows(0).Item("CustomerID")
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SDSName", SqlDbType.VarChar)

        If con.State = ConnectionState.Closed Then con.Open()
        For i As Integer = 0 To dsTemp.Tables("Shipment").Rows.Count - 1
            If Not String.IsNullOrEmpty(dsTemp.Tables("Shipment").Rows(i).Item("SDSName")) Then
                cmd.Parameters("@SDSName").Value = dsTemp.Tables("Shipment").Rows(i).Item("SDSName")
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If reader.GetValue(0) > dsTemp.Tables("Shipment").Rows(i).Item("RevisionNumber") Then
                        If lstSDSAdd.IndexOf(dsTemp.Tables("Shipment").Rows(i).Item("SDSName")) = -1 Then
                            lstSDSAdd.Add(dsTemp.Tables("Shipment").Rows(i).Item("SDSName"))
                        End If
                    Else
                        If Not IsDBNull(reader.GetValue(1)) Then
                            If DateDiff(DateInterval.DayOfYear, reader.GetValue(1), Today.Date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) > 182 Then
                                If lstSDSAdd.IndexOf(dsTemp.Tables("Shipment").Rows(i).Item("SDSName")) = -1 Then
                                    lstSDSAdd.Add(dsTemp.Tables("Shipment").Rows(i).Item("SDSName"))
                                End If
                            End If
                        End If
                    End If
                Else
                    If lstSDSAdd.IndexOf(dsTemp.Tables("Shipment").Rows(i).Item("SDSName")) = -1 Then
                        lstSDSAdd.Add(dsTemp.Tables("Shipment").Rows(i).Item("SDSName"))
                    End If
                End If
                reader.Close()
            End If
        Next

        While lstSDSAdd.Count > 0
            cmd = New SqlCommand("SELECT COUNT(SDSName) FROM SafetyDataSheetsReceived WHERE CustomerID = @CustomerID AND SDSName = @SDSName AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = dsTemp.Tables("Shipment").Rows(0).Item("CustomerID")
            cmd.Parameters.Add("@SDSName", SqlDbType.VarChar).Value = lstSDSAdd(0)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() > 0 Then
                cmd.CommandText = "UPDATE SafetyDataSheetsReceived SET RevisionNumber = (SELECT RevisionNumber FROM SafetyDataSheets WHERE Name = @SDSName), DateReceived = @DateReceived WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND SDSName = @SDSName"
            Else
                cmd.CommandText = "INSERT INTO SafetyDataSheetsReceived (CustomerID, DivisionID, SDSName, RevisionNumber, DateReceived) VALUES (@CustomerID, @DivisionID, @SDSName, (SELECT RevisionNumber FROM SafetyDataSheets WHERE Name = @SDSName), @DateReceived)"
            End If
            cmd.Parameters.Add("@DateReceived", SqlDbType.DateTime).Value = Today.Date
            cmd.ExecuteNonQuery()
            cmd.CommandText = "SELECT FileName FROM SafetyDataSheets WHERE Name = @SDSName"
            Dim fle As String = cmd.ExecuteScalar()
            SDSPrinted.Add(fle)
            Dim localprintserver As New LocalPrintServer()
            Dim defaultprintqueue As PrintQueue = localprintserver.GetDefaultPrintQueue()

            Dim xpsprintjob As PrintSystemJobInfo = defaultprintqueue.AddJob(fle, "\\TFP-FS\TransferData\Safety Data Sheets" + fle, False)
            lstSDSAdd.RemoveAt(0)
        End While
        con.Close()
    End Sub
End Class