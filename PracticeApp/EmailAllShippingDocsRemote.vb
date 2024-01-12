Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class EmailAllShippingDocsRemote
    Inherits System.Windows.Forms.Form

    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim MyReport1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport3 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport4 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRShippingViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRShippingViewer.Load
        'Compile and attach Packing List
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE ShipmentNumber = @ShipmentNumber ORDER BY ShipmentNumber, ShipmentLineNumber", con)
        cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM CountryCodes", con)

        cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd7 = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID", con)
        cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd8 = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd9 = New SqlCommand("SELECT * FROM ShipmentLineHeatNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd9.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

        cmd10 = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd10.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

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

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "CountryCodes")

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
        '******************************************************************************************
        'Create Packing List Name
        Dim PackingListName As String = ""
        Dim strShipmentNumber As String = ""

        strShipmentNumber = CStr(EmailShipmentNumber)

        PackingListName = "TWPL-" + GlobalDivisionCode + strShipmentNumber
        '******************************************************************************************
        'Sets up viewer to display data from the loaded dataset
        MyReport1 = CRXPackingSlip1
        MyReport1.SetDataSource(ds)
        con.Close()

        'Export Document to Folder
        MyReport1.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & PackingListName & ".pdf")
        '*******************************************************************************************
        'Compile and attach BOL
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

        cmd1 = New SqlCommand("SELECT * FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd1.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds2, "ShipmentHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds2, "ShipmentLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds2, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds2, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds2, "CustomerContacts")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds2, "AdditionalShipTo")
        '*****************************************************************************************
        'Create BOL Name
        Dim BOLName As String = ""
        Dim strBOLShipmentNumber As String = ""

        strBOLShipmentNumber = CStr(EmailShipmentNumber)

        BOLName = "TWBOL-" + GlobalDivisionCode + strBOLShipmentNumber
        '******************************************************************************************
        'Sets up viewer to display data from the loaded dataset
        MyReport2 = CRXBOL1
        MyReport2.SetDataSource(ds2)
        con.Close()

        'Export Document to Folder
        MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & BOLName & ".pdf")
        '******************************************************************************************
        'Check for certs first
        '*******************************************************************************************************************************************
        'Check to make sure at least one cert will print otherwise do not open Print Form
        Dim CheckForCerts As Integer = 0

        'Get Pull Test Number for selected Lot Number Data
        Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
        CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber
        CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
        If reader2.HasRows Then
            reader2.Read()
            If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                CheckForCerts = 0
            Else
                CheckForCerts = reader2.Item("CountShipmentNumber")
            End If
        Else
            CheckForCerts = 0
        End If
        reader2.Close()
        con.Close()
        '******************************************************************************************
        'Create Cert Name
        Dim CertName As String = ""
        Dim strCertShipmentNumber As String = ""

        strCertShipmentNumber = CStr(EmailShipmentNumber)

        CertName = "CERT-" + GlobalDivisionCode + strBOLShipmentNumber
        '*****************************************************************************************
        If CheckForCerts = 0 Then
            'Skip certs
        Else
            'Compile and attach Certs
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

            cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

            cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds3, "TruweldCertData")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds3, "CustomerList")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds3, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds3, "PullTestLineTable")
            '******************************************************************************************
            'Sets up viewer to display data from the loaded dataset
            MyReport3 = CRXTWCert011
            MyReport3.SetDataSource(ds3)
            con.Close()

            'Export Document to Folder
            MyReport3.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & CertName & ".pdf")
        End If
        '******************************************************************************************
        'Attach all files to email
        'Attach both files to email
        TFPMailFilename = PackingListName + ".pdf"
        TFPMailFilename2 = BOLName & ".pdf"
        TFPMailFilename2 = CertName & ".pdf"
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldPackList\" & PackingListName & ".pdf"
        TFPMailFilePath2 = "\\TFP-FS\TransferData\TruweldPackList\" & BOLName & ".pdf"
        TFPMailFilePath2 = "\\TFP-FS\TransferData\TruweldPackList\" & CertName & ".pdf"

        TFPMailTransactionType = "Email All Shipping Docs"
        TFPMailTransactionNumber = strShipmentNumber

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using

        Me.Close()
    End Sub
End Class