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
Public Class CustomerInfoPopup
    Inherits System.Windows.Forms.Form

    Dim CustomerName, CustomerPhone, CustomerFax, CustomerEmail, CustomerContact As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub CustomerInfoPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerData()
    End Sub

    Public Sub LoadCustomerData()
        Dim CustomerNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerNameCommand As New SqlCommand(CustomerNameStatement, con)
        CustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        CustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim CustomerPhoneStatement As String = "SELECT APPhoneNumber FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerPhoneCommand As New SqlCommand(CustomerPhoneStatement, con)
        CustomerPhoneCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        CustomerPhoneCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim CustomerFaxStatement As String = "SELECT APFaxNumber FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerFaxCommand As New SqlCommand(CustomerFaxStatement, con)
        CustomerFaxCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        CustomerFaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim InvoiceEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim InvoiceEmailCommand As New SqlCommand(InvoiceEmailStatement, con)
        InvoiceEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        InvoiceEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim ContactNameStatement As String = "SELECT APContactName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ContactNameCommand As New SqlCommand(ContactNameStatement, con)
        ContactNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        ContactNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName = CStr(CustomerNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerName = ""
        End Try
        Try
            CustomerPhone = CStr(CustomerPhoneCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerPhone = ""
        End Try
        Try
            CustomerFax = CStr(CustomerFaxCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerFax = ""
        End Try
        Try
            CustomerEmail = CStr(InvoiceEmailCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerEmail = ""
        End Try
        Try
            CustomerContact = CStr(ContactNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerContact = ""
        End Try
        con.Close()

        txtCustomerContact.Text = CustomerContact
        txtCustomerName.Text = CustomerName
        txtEmail.Text = CustomerEmail
        txtPhone.Text = CustomerPhone
        txtFax.Text = CustomerFax
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class