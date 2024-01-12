Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook

Public Class PrintSteelPurchaseOrder
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds As DataSet
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalSteelPONumber = 0

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRPOViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPOViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey", con)
        cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = GlobalSteelPONumber

        cmd1 = New SqlCommand("SELECT * FROM SteelPurchaseQuantityStatus", con)

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM Vendor WHERE VendorClass = 'SteelVendor' AND DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelPurchaseOrderHeader")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "SteelPurchaseQuantityStatus")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "RawMaterialsTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "Vendor")

        'Sets up viewer to display data from the loaded dataset

        MyReport = CRXSteelPurchaseOrder1
        MyReport.SetDataSource(ds)
        CRPOViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailToolStripMenuItem.Click
        Dim VendorID As String = ""
        Dim VendorEmail As String = ""

        'Created Outlook Application object
        Dim OLApp As New Application

        'Variables for Date/Filename Creation
        Dim FileDate As Date
        Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
        Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
        'Get Vendor for specific PO
        Dim VendorIDStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim VendorIDCommand As New SqlCommand(VendorIDStatement, con)
        VendorIDCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber
        VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = VendorIDCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = ""
            Else
                VendorID = reader.Item("VendorID")
            End If
        Else
            VendorID = ""
        End If
        reader.Close()
        con.Close()

        'Get Vendor Email Address
        Dim VendorEmailStatement As String = "SELECT VendorEmail FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = 'TWD'"
        Dim VendorEmailCommand As New SqlCommand(VendorEmailStatement, con)
        VendorEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = VendorID

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = VendorEmailCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("VendorEmail")) Then
                VendorEmail = ""
            Else
                VendorEmail = reader1.Item("VendorEmail")
            End If
        Else
            VendorEmail = ""
        End If
        reader1.Close()
        con.Close()

        'Create new Filename for PO
        FileDate = Today()
        monthofyear = FileDate.Month
        dayofyear = FileDate.DayOfYear
        yearofyear = FileDate.Year
        minuteofyear = FileDate.Minute
        strMonth = CStr(monthofyear)
        strDay = CStr(dayofyear)
        strYear = CStr(yearofyear)
        strMinute = CStr(minuteofyear)
        strCompany = GlobalDivisionCode

        ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitSteelPOs\STEELPO" & ConfirmName & ".pdf")

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
        mail.Subject = "Trufit Steel Purchase Order"

        'Add Vendor Email
        mail.To = VendorEmail

        'adding body message information to the mail message
        mail.Body = "This is a Steel Purchase Order placed with Tru-Fit Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TrufitSteelPOs\STEELPO" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub
End Class