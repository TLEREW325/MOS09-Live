Imports System
Imports System.Math
Imports System.IO
Imports System.Data
'Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook
Imports System.Runtime.InteropServices
Public Class PrintRMAGrid
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")

    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    'Public Sub New()
    '    InitializeComponent()

    'End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalVariables.stringVar = ""
        GlobalVariables.stringVar2 = ""
        GlobalVariables.Counter = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRPickViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPickViewer.Load
        Dim ItemDataStatement5 As String = "SELECT Customer, FOXNumber, Quantity, Reason, Remarks, PurchaseOrderNumber, DivisionID, TypeFix, AuthorizedTruckingFirm, CustomerContact, NeedPartsBy, QARepresentative, QARepDate FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber"
        Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
        ItemDataCommand5.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = GlobalVariables.Counter
        Dim Customer, Fox, Quantity, Reason, Remarks, PO, Division, Fix, ATF, CC, NPB, QAR, QARD As String
        If con.State = ConnectionState.Closed Then con.Open()
        Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
            Try

                If reader5.HasRows Then
                    reader5.Read()
                    If IsDBNull(reader5.Item("Customer")) Then
                        Customer = " "
                    Else
                        Customer = reader5.Item("Customer")
                    End If
                    If IsDBNull(reader5.Item("FOXNumber")) Then
                        Fox = " "
                    Else
                        Fox = reader5.Item("FOXNumber")
                    End If
                    If IsDBNull(reader5.Item("Quantity")) Then
                        Quantity = " "
                    Else
                        Quantity = reader5.Item("Quantity")
                    End If
                    If IsDBNull(reader5.Item("Reason")) Then
                        Reason = " "
                    Else
                        Reason = reader5.Item("Reason")
                    End If
                    If IsDBNull(reader5.Item("Remarks")) Then
                        Remarks = " "
                    Else
                        Remarks = reader5.Item("Remarks")
                    End If
                    If IsDBNull(reader5.Item("PurchaseOrderNumber")) Then
                        PO = " "
                    Else
                        PO = reader5.Item("PurchaseOrderNumber")
                    End If
                    If IsDBNull(reader5.Item("DivisionID")) Then
                        Division = " "
                    Else
                        Division = reader5.Item("DivisionID")
                    End If
                    If IsDBNull(reader5.Item("TypeFix")) Then
                        Fix = " "
                    Else
                        Fix = reader5.Item("TypeFix")
                    End If
                    If IsDBNull(reader5.Item("AuthorizedTruckingFirm")) Then
                        ATF = " "
                    Else
                        ATF = reader5.Item("AuthorizedTruckingFirm")
                    End If
                    If IsDBNull(reader5.Item("CustomerContact")) Then
                        CC = ""
                    Else
                        CC = reader5.Item("CustomerContact")
                    End If
                    If IsDBNull(reader5.Item("NeedPartsBy")) Then
                        NPB = ""
                    Else
                        NPB = reader5.Item("NeedPartsBy")
                    End If
                    If IsDBNull(reader5.Item("QARepresentative")) Then
                        QAR = ""
                    Else
                        QAR = reader5.Item("QARepresentative")
                    End If
                    If IsDBNull(reader5.Item("QARepDate")) Then
                        QARD = ""
                    Else
                        QARD = reader5.Item("QARepDate")
                    End If
                    reader5.Close()
                Else
                    Division = ""
                    Customer = ""
                    Fox = ""
                    Remarks = ""
                    Reason = ""
                    PO = ""
                    ATF = ""
                    Quantity = ""
                    Fix = ""
                    CC = ""
                    NPB = ""
                    QAR = ""
                    QARD = ""
                End If



            Catch ex As System.Exception

            End Try
        End Using
        'Sets up viewer to display data from the loaded dataset
        cmd = New SqlCommand("SELECT PartNumber, BlueprintRevision FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Fox


        cmd1 = New SqlCommand("SELECT BlueprintNumber, LongDescription FROM FOXTableQuery WHERE FOXNumber = @FOXNumber", con)
        cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Fox

        cmd2 = New SqlCommand("SELECT * FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber", con)
        cmd2.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = GlobalVariables.Counter

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTable")
        MyReport = CRXCustReturnGoods1
        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "FOXTableQuery")
        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "RMATable")
        MyReport.SetDataSource(ds)

        ''Fills parameters with the variables saved locally
        Dim parameter As String
        parameter = PO
        CRXCustReturnGoods1.SetParameterValue("PurchaseOrderNumber", parameter)
        parameter = GlobalVariables.stringVar
        CRXCustReturnGoods1.SetParameterValue("GoodsAuthorizationNumber", parameter)
        parameter = Customer
        CRXCustReturnGoods1.SetParameterValue("Customer", parameter)
        parameter = CC
        CRXCustReturnGoods1.SetParameterValue("CustomerContact", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Fox", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Quantity", parameter)
        parameter = Reason
        CRXCustReturnGoods1.SetParameterValue("Reason", parameter)
        parameter = Fix
        CRXCustReturnGoods1.SetParameterValue("TypeOfReturn", parameter)
        parameter = Remarks
        CRXCustReturnGoods1.SetParameterValue("Remarks", parameter)
        parameter = ATF
        CRXCustReturnGoods1.SetParameterValue("AuthorizedTruckingFirm", parameter)
        parameter = NPB
        CRXCustReturnGoods1.SetParameterValue("CustDate", parameter)
        parameter = QAR
        CRXCustReturnGoods1.SetParameterValue("Signature", parameter)
        parameter = QARD
        CRXCustReturnGoods1.SetParameterValue("Date", parameter)


        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXCustReturnGoods1

        ''Fills parameters with the variables saved locally

        parameter = PO
        CRXCustReturnGoods1.SetParameterValue("PurchaseOrderNumber", parameter)
        parameter = GlobalVariables.stringVar
        CRXCustReturnGoods1.SetParameterValue("GoodsAuthorizationNumber", parameter)
        parameter = Customer
        CRXCustReturnGoods1.SetParameterValue("Customer", parameter)
        parameter = CC
        CRXCustReturnGoods1.SetParameterValue("CustomerContact", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Fox", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Quantity", parameter)
        parameter = Reason
        CRXCustReturnGoods1.SetParameterValue("Reason", parameter)
        parameter = Fix
        CRXCustReturnGoods1.SetParameterValue("TypeOfReturn", parameter)
        parameter = Remarks
        CRXCustReturnGoods1.SetParameterValue("Remarks", parameter)
        parameter = ATF
        CRXCustReturnGoods1.SetParameterValue("AuthorizedTruckingFirm", parameter)
        parameter = NPB
        CRXCustReturnGoods1.SetParameterValue("CustDate", parameter)
        parameter = QAR
        CRXCustReturnGoods1.SetParameterValue("Signature", parameter)
        parameter = QARD
        CRXCustReturnGoods1.SetParameterValue("Date", parameter)


        MyReport.SetDataSource(ds)

        ''Fills parameters with the variables saved locally

        parameter = PO
        CRXCustReturnGoods1.SetParameterValue("PurchaseOrderNumber", parameter)
        parameter = GlobalVariables.stringVar
        CRXCustReturnGoods1.SetParameterValue("GoodsAuthorizationNumber", parameter)
        parameter = Customer
        CRXCustReturnGoods1.SetParameterValue("Customer", parameter)
        parameter = CC
        CRXCustReturnGoods1.SetParameterValue("CustomerContact", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Fox", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Quantity", parameter)
        parameter = Reason
        CRXCustReturnGoods1.SetParameterValue("Reason", parameter)
        parameter = Fix
        CRXCustReturnGoods1.SetParameterValue("TypeOfReturn", parameter)
        parameter = Remarks
        CRXCustReturnGoods1.SetParameterValue("Remarks", parameter)
        parameter = ATF
        CRXCustReturnGoods1.SetParameterValue("AuthorizedTruckingFirm", parameter)
        parameter = NPB
        CRXCustReturnGoods1.SetParameterValue("CustDate", parameter)
        parameter = QAR
        CRXCustReturnGoods1.SetParameterValue("Signature", parameter)
        parameter = QARD
        CRXCustReturnGoods1.SetParameterValue("Date", parameter)


        CRPickViewer.ReportSource = MyReport
        con.Close()
        con2.Close()

            

    End Sub

    Private Sub EmailFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailFormToolStripMenuItem.Click
        'Get Login Type
        'viewer()
        Dim GetLoginType As String = ""

        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetLoginType = ""
        End Try
        con.Close()

        DeleteDirectory("\\TFP-FS\TransferData\Test")
        If Not System.IO.Directory.Exists("\\TFP-FS\TransferData\Test") Then System.IO.Directory.CreateDirectory("\\TFP-FS\TransferData\Test")
        If GetLoginType = "REMOTE" Then
            'Create new Filename for RMA Report
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

            ConfirmName = strCompany + strMinute + strYear + strDay + strMonth + minuteofyear.ToString + dayofyear.ToString + monthofyear.ToString + yearofyear.ToString

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilePath3 = ""
            TFPMailTransactionType = "Return Goods Authorization Form"
            TFPMailTransactionNumber = 0
            TFPMailCustomer = CreditVariables.emailID

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        Else

            'Create new Filename for RMA Report
            FileDate = Now()
            monthofyear = FileDate.Month
            dayofyear = FileDate.DayOfYear
            yearofyear = FileDate.Year
            minuteofyear = FileDate.Minute
            strMonth = CStr(monthofyear)
            strDay = CStr(dayofyear)
            strYear = CStr(yearofyear)
            strMinute = CStr(minuteofyear)
            strCompany = GlobalDivisionCode

            ConfirmName = strCompany + strMinute + strYear + strDay + strMonth + minuteofyear.ToString + dayofyear.ToString + monthofyear.ToString + yearofyear.ToString

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)

            'adding subject information to the mail message
            mail.Subject = "Return Goods Authorization Form"

            'Address Email To
            mail.To = ""

            'adding body message information to the mail message
            mail.Body = ""

            'adding attachment
            Try
                mail.Attachments.Add("\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")
            Catch ex As System.Exception

            End Try

            'display mail
            mail.Display()

            Me.Close()
        End If
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
        End If
    End Sub
End Class