Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System.ComponentModel
Imports iTextSharp
Imports System.Reflection

Public Class View1096Misc
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim tableName As String = "StructuralCertTable"

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Dim BeginDate, EndDate As Date

    Dim taxid1, taxid2, name1099, vendorName, vendorAddress1, vendorAddress2, vendorCity, vendorState, vendorCountry, vendorZip, name10992, vendorName2, vendorAddress12, vendorAddress22, vendorCity2, vendorState2, vendorCountry2, vendorZip2, company1, company2 As String

    Private Sub View1099Misc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        'Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.Vendor' table. You can move, or remove it, as needed.
        'Me.VendorTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.Vendor)
        MyReport = CRX1096MiscForm1

        cmd = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalVariables.stringVar2

        cmd2 = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalVariables.stringVar2

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "DivisionTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "Vendor")

        MyReport.SetDataSource(ds)



        Dim parameter As String
        parameter = GlobalVariables.stringVar
        CRX1096MiscForm1.SetParameterValue("totalamount", parameter)
        parameter = CStr(GlobalVariables.totalfiles)
        CRX1096MiscForm1.SetParameterValue("count", parameter)
        
        CRX1096MiscForm1 = MyReport
        CrystalReportViewer1.ReportSource = CRX1096MiscForm1


    End Sub
    

End Class