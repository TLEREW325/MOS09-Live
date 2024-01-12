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
Public Class VendorInfoPopup
    Inherits System.Windows.Forms.Form

    Dim VendorName, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorPhone, VendorFax As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub VendorInfoPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadVendorData()
    End Sub

    Public Sub LoadVendorData()
        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim VendorAddress1Statement As String = "SELECT VendorAddress1 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorAddress1Command As New SqlCommand(VendorAddress1Statement, con)
        VendorAddress1Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim VendorAddress2Statement As String = "SELECT VendorAddress2 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorAddress2Command As New SqlCommand(VendorAddress2Statement, con)
        VendorAddress2Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim VendorCityStatement As String = "SELECT VendorCity FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorCityCommand As New SqlCommand(VendorCityStatement, con)
        VendorCityCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim VendorStateStatement As String = "SELECT VendorState FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorStateCommand As New SqlCommand(VendorStateStatement, con)
        VendorStateCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim VendorZipStatement As String = "SELECT VendorZip FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorZipCommand As New SqlCommand(VendorZipStatement, con)
        VendorZipCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim VendorPhoneStatement As String = "SELECT VendorPhone FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorPhoneCommand As New SqlCommand(VendorPhoneStatement, con)
        VendorPhoneCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorPhoneCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim VendorFaxStatement As String = "SELECT VendorFax FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorFaxCommand As New SqlCommand(VendorFaxStatement, con)
        VendorFaxCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
        VendorFaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        Try
            VendorAddress1 = CStr(VendorAddress1Command.ExecuteScalar)
        Catch ex As Exception
            VendorAddress1 = ""
        End Try
        Try
            VendorAddress2 = CStr(VendorAddress2Command.ExecuteScalar)
        Catch ex As Exception
            VendorAddress2 = ""
        End Try
        Try
            VendorCity = CStr(VendorCityCommand.ExecuteScalar)
        Catch ex As Exception
            VendorCity = ""
        End Try
        Try
            VendorState = CStr(VendorStateCommand.ExecuteScalar)
        Catch ex As Exception
            VendorState = ""
        End Try
        Try
            VendorZip = CStr(VendorZipCommand.ExecuteScalar)
        Catch ex As Exception
            VendorZip = ""
        End Try
        Try
            VendorPhone = CStr(VendorPhoneCommand.ExecuteScalar)
        Catch ex As Exception
            VendorPhone = ""
        End Try
        Try
            VendorFax = CStr(VendorFaxCommand.ExecuteScalar)
        Catch ex As Exception
            VendorFax = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
        txtAddress1.Text = VendorAddress1
        txtAddress2.Text = VendorAddress2
        txtCity.Text = VendorCity
        txtState.Text = VendorState
        txtZip.Text = VendorZip
        txtPhone.Text = VendorPhone
        txtFax.Text = VendorFax
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            'Update existing vendor with changes
            cmd = New SqlCommand("UPDATE Vendor SET VendorName = @VendorName, VendorAddress1 = @VendorAddress1, VendorAddress2 = @VendorAddress2, VendorCity = @VendorCity, VendorState = @VendorState, VendorZip = @VendorZip, VendorPhone = @VendorPhone, VendorFax = @VendorFax WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VendorCode", SqlDbType.VarChar).Value = GlobalVendorID
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@VendorName", SqlDbType.VarChar).Value = txtVendorName.Text
                .Add("@VendorAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@VendorAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@VendorCity", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@VendorState", SqlDbType.VarChar).Value = txtState.Text
                .Add("@VendorZip", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@VendorPhone", SqlDbType.VarChar).Value = txtPhone.Text
                .Add("@VendorFax", SqlDbType.VarChar).Value = txtFax.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Vendor changes saved.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("Changes cannot be saved at this time.", MsgBoxStyle.OkOnly)
        End Try
    End Sub
End Class