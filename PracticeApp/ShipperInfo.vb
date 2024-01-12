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
Public Class ShipperInfo
    Inherits System.Windows.Forms.Form

    Dim ShipMethodType, Address1, Address2, ShipMethDesc, City, State, ZipCode, Phone, Fax, Email As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM  ShipMethod", con)
        cmd.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipMethod")
        dgvShipMethod.DataSource = ds.Tables("ShipMethod")
        con.Close()
    End Sub

    Public Sub LoadDataWithPhone()
        cmd = New SqlCommand("SELECT * FROM  ShipMethod WHERE Phone <> ''", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ShipMethod")
        con.Close()
    End Sub

    Public Sub LoadShipper()
        cmd = New SqlCommand("SELECT * FROM  ShipMethod", con)
        cmd.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ShipMethod")
        cboShipperID.DataSource = ds1.Tables("ShipMethod")
        con.Close()
        cboShipperID.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        'Clear all text boxes on load
        cboDivisionID.Text = EmployeeCompanyCode
        cboShipperID.Text = ""
        cboShipMethodType.Text = ""

        cboShipperID.Refresh()
        cboState.Refresh()
        cboShipMethodType.Refresh()

        cboShipperID.SelectedIndex = -1
        cboState.SelectedIndex = -1
        cboShipMethodType.SelectedIndex = -1

        txtAddress1.Refresh()
        txtAddress2.Refresh()
        txtCity.Refresh()
        txtEmail.Refresh()
        txtFax.Refresh()
        txtPhone.Refresh()
        txtShipperName.Refresh()
        txtZipCode.Refresh()

        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtEmail.Clear()
        txtFax.Clear()
        txtPhone.Clear()
        txtShipperName.Clear()
        txtZipCode.Clear()

        cboShipperID.Focus()
    End Sub

    Public Sub ClearVariables()
        Address1 = ""
        Address2 = ""
        ShipMethDesc = ""
        City = ""
        State = ""
        ZipCode = ""
        Phone = ""
        Fax = ""
        Email = ""
        ShipMethodType = ""
    End Sub

    Private Sub ShipperInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If EmployeeSecurityCode = 1001 Then
            cmdDelete.Enabled = True
        Else
            cmdDelete.Enabled = False
        End If

        LoadShipper()
        ClearData()
        ShowData()
    End Sub

    Public Sub LoadShipperData()
        Dim ShipMethDescStatement As String = "SELECT ShipMethDesc FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim ShipMethDescCommand As New SqlCommand(ShipMethDescStatement, con)
        ShipMethDescCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim Address1Statement As String = "SELECT Address1 FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim Address1Command As New SqlCommand(Address1Statement, con)
        Address1Command.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim Address2Statement As String = "SELECT Address2 FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim Address2Command As New SqlCommand(Address2Statement, con)
        Address2Command.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim CityStatement As String = "SELECT City FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim CityCommand As New SqlCommand(CityStatement, con)
        CityCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim StateStatement As String = "SELECT State FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim StateCommand As New SqlCommand(StateStatement, con)
        StateCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim ZipCodeStatement As String = "SELECT ZipCode FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim ZipCodeCommand As New SqlCommand(ZipCodeStatement, con)
        ZipCodeCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim PhoneStatement As String = "SELECT Phone FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim PhoneCommand As New SqlCommand(PhoneStatement, con)
        PhoneCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim FaxStatement As String = "SELECT Fax FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim FaxCommand As New SqlCommand(FaxStatement, con)
        FaxCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim EmailStatement As String = "SELECT Email FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim EmailCommand As New SqlCommand(EmailStatement, con)
        EmailCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        Dim ShipMethodTypeStatement As String = "SELECT ShipMethodType FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim ShipMethodTypeCommand As New SqlCommand(ShipMethodTypeStatement, con)
        ShipMethodTypeCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipMethDesc = CStr(ShipMethDescCommand.ExecuteScalar)
        Catch ex As Exception
            ShipMethDesc = ""
        End Try
        Try
            Address1 = CStr(Address1Command.ExecuteScalar)
        Catch ex As Exception
            Address1 = ""
        End Try
        Try
            Address2 = CStr(Address2Command.ExecuteScalar)
        Catch ex As Exception
            Address2 = ""
        End Try
        Try
            City = CStr(CityCommand.ExecuteScalar)
        Catch ex As Exception
            City = ""
        End Try
        Try
            State = CStr(StateCommand.ExecuteScalar)
        Catch ex As Exception
            State = ""
        End Try
        Try
            ZipCode = CStr(ZipCodeCommand.ExecuteScalar)
        Catch ex As Exception
            ZipCode = ""
        End Try
        Try
            Phone = CStr(PhoneCommand.ExecuteScalar)
        Catch ex As Exception
            Phone = ""
        End Try
        Try
            Fax = CStr(FaxCommand.ExecuteScalar)
        Catch ex As Exception
            Fax = ""
        End Try
        Try
            Email = CStr(EmailCommand.ExecuteScalar)
        Catch ex As Exception
            Email = ""
        End Try
        Try
            ShipMethodType = CStr(ShipMethodTypeCommand.ExecuteScalar)
        Catch ex As Exception
            ShipMethodType = ""
        End Try
        con.Close()

        txtAddress1.Text = Address1
        txtAddress2.Text = Address2
        txtCity.Text = City
        txtEmail.Text = Email
        txtFax.Text = Fax
        txtPhone.Text = Phone
        txtShipperName.Text = ShipMethDesc
        txtZipCode.Text = ZipCode
        cboState.Text = State
        cboShipMethodType.Text = ShipMethodType
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If cboShipperID.Text = "" Then
            MsgBox("You must have a valid Shipper ID selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Write Data to Quote Header Database Table (One Time)
                cmd = New SqlCommand("Insert Into ShipMethod(ShipMethID, ShipMethDesc, DivisionID, Address1, Address2, City, State, ZipCode, Phone, Fax, Email, ShipMethodType) Values (@ShipMethID, @ShipMethDesc, @DivisionID, @Address1, @Address2, @City, @State, @ZipCode, @Phone, @Fax, @Email, @ShipMethodType)", con)

                With cmd.Parameters
                    .Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text
                    .Add("@ShipMethDesc", SqlDbType.VarChar).Value = txtShipperName.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                    .Add("@ZipCode", SqlDbType.VarChar).Value = txtZipCode.Text
                    .Add("@Phone", SqlDbType.VarChar).Value = txtPhone.Text
                    .Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text
                    .Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text
                    .Add("@ShipMethodType", SqlDbType.VarChar).Value = cboShipMethodType.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If chkAddToVendor.Checked = True Then
                    Try
                        'Write Data to Vendor Database Table
                        cmd = New SqlCommand("Insert Into Vendor(VendorCode, VendorName, ContactName, VendorCity, VendorState, VendorZip, VendorPhone, VendorFax, VendorEmail, DivisionID, VendorAddress1, VendorAddress2, VendorCountry, VendorClass, VendorDate, VendorComment, VendorTaxID, VendorPreferredShipping, PaymentTerms, CreditLimit, DefaultGLAccount, DefaultItem)Values(@VendorCode, @VendorName, @ContactName, @VendorCity, @VendorState, @VendorZip, @VendorPhone, @VendorFax, @VendorEmail, @DivisionID, @VendorAddress1, @VendorAddress2, @VendorCountry, @VendorClass, @VendorDate, @VendorComment, @VendorTaxID, @VendorPreferredShipping, @PaymentTerms, @CreditLimit, @DefaultGLAccount, @DefaultItem)", con)

                        With cmd.Parameters
                            .Add("@VendorCode", SqlDbType.VarChar).Value = cboShipperID.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@VendorName", SqlDbType.VarChar).Value = txtShipperName.Text
                            .Add("@ContactName", SqlDbType.VarChar).Value = ""
                            .Add("@VendorAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                            .Add("@VendorAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                            .Add("@VendorCity", SqlDbType.VarChar).Value = txtCity.Text
                            .Add("@VendorState", SqlDbType.VarChar).Value = cboState.Text
                            .Add("@VendorZip", SqlDbType.VarChar).Value = txtZipCode.Text
                            .Add("@VendorCountry", SqlDbType.VarChar).Value = "USA"
                            .Add("@VendorPhone", SqlDbType.VarChar).Value = txtPhone.Text
                            .Add("@VendorFax", SqlDbType.VarChar).Value = txtFax.Text
                            .Add("@VendorEmail", SqlDbType.VarChar).Value = txtEmail.Text
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                            .Add("@VendorClass", SqlDbType.VarChar).Value = "FREIGHT"
                            .Add("@VendorDate", SqlDbType.VarChar).Value = Today()
                            .Add("@VendorComment", SqlDbType.VarChar).Value = ""
                            .Add("@VendorTaxID", SqlDbType.VarChar).Value = ""
                            .Add("@VendorPreferredShipping", SqlDbType.VarChar).Value = ""
                            .Add("@CreditLimit", SqlDbType.VarChar).Value = 0
                            .Add("@DefaultGLAccount", SqlDbType.VarChar).Value = ""
                            .Add("@DefaultItem", SqlDbType.VarChar).Value = ""
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Create command to update database and fill with text box enties
                        cmd = New SqlCommand("Update Vendor SET VendorName = @VendorName, ContactName = @ContactName, DivisionID = @DivisionID, VendorAddress1 = @VendorAddress1, VendorAddress2 = @VendorAddress2, VendorCity = @VendorCity, VendorState = @VendorState, VendorZip = @VendorZip, VendorCountry = @VendorCountry, VendorPhone = @VendorPhone, VendorFax = @VendorFax, VendorEmail = @VendorEmail, PaymentTerms = @PaymentTerms, VendorClass = @VendorClass, VendorDate = @VendorDate, VendorComment = @VendorComment, VendorTaxID = @VendorTaxID, VendorPreferredShipping = @VendorPreferredShipping, CreditLimit = @CreditLimit, DefaultGLAccount = @DefaultGLAccount, DefaultItem = @DefaultItem WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VendorCode", SqlDbType.VarChar).Value = cboShipperID.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@VendorName", SqlDbType.VarChar).Value = txtShipperName.Text
                            .Add("@ContactName", SqlDbType.VarChar).Value = ""
                            .Add("@VendorAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                            .Add("@VendorAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                            .Add("@VendorCity", SqlDbType.VarChar).Value = txtCity.Text
                            .Add("@VendorState", SqlDbType.VarChar).Value = cboState.Text
                            .Add("@VendorZip", SqlDbType.VarChar).Value = txtZipCode.Text
                            .Add("@VendorCountry", SqlDbType.VarChar).Value = "USA"
                            .Add("@VendorPhone", SqlDbType.VarChar).Value = txtPhone.Text
                            .Add("@VendorFax", SqlDbType.VarChar).Value = txtFax.Text
                            .Add("@VendorEmail", SqlDbType.VarChar).Value = txtEmail.Text
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                            .Add("@VendorClass", SqlDbType.VarChar).Value = "FREIGHT"
                            .Add("@VendorDate", SqlDbType.VarChar).Value = Today()
                            .Add("@VendorComment", SqlDbType.VarChar).Value = ""
                            .Add("@VendorTaxID", SqlDbType.VarChar).Value = ""
                            .Add("@VendorPreferredShipping", SqlDbType.VarChar).Value = ""
                            .Add("@CreditLimit", SqlDbType.VarChar).Value = 0
                            .Add("@DefaultGLAccount", SqlDbType.VarChar).Value = ""
                            .Add("@DefaultItem", SqlDbType.VarChar).Value = ""
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Try
                Else
                    'Do nothing
                End If

                'Clear all text boxes after entry
                ClearVariables()
                ClearData()
                ShowData()
            Catch ex As Exception
                'Write Data to Quote Header Database Table (One Time)
                cmd = New SqlCommand("UPDATE ShipMethod SET ShipMethDesc = @ShipMethDesc, DivisionID = @DivisionID, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, ZipCode = @ZipCode, Phone = @Phone, Fax = @Fax, Email = @Email, ShipMethodType = @ShipMethodType WHERE ShipMethID = @ShipMethID", con)

                With cmd.Parameters
                    .Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipperID.Text
                    .Add("@ShipMethDesc", SqlDbType.VarChar).Value = txtShipperName.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                    .Add("@ZipCode", SqlDbType.VarChar).Value = txtZipCode.Text
                    .Add("@Phone", SqlDbType.VarChar).Value = txtPhone.Text
                    .Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text
                    .Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text
                    .Add("@ShipMethodType", SqlDbType.VarChar).Value = cboShipMethodType.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear all text boxes after entry
                ClearVariables()
                ClearData()
                ShowData()
            End Try
        End If
    End Sub

    Private Sub cboShipperID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipperID.SelectedIndexChanged
        LoadShipperData()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Purchase Order?", "DELETE PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Dim RowShipMethodID As String
            Dim RowIndex As Integer = Me.dgvShipMethod.CurrentCell.RowIndex

            Try
                RowShipMethodID = Me.dgvShipMethod.Rows(RowIndex).Cells("ShipMethodIDColumn").Value
            Catch ex As Exception
                RowShipMethodID = 0
            End Try

            'Create command to delete data from text boxes
            cmd = New SqlCommand("DELETE FROM ShipMethod WHERE ShipMethID = @ShipMethID", con)
            cmd.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = RowShipMethodID

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear Text Boxes
            ClearVariables()
            ClearData()
            ShowData()

            'Prompt before deleting
            MsgBox("This Ship Via has been deleted", MsgBoxStyle.YesNo)
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Clear all text boxes
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        LoadDataWithPhone()
        GDS = ds2
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintShippers As New PrintShippers
            Dim result = NewPrintShippers.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub dgvShipMethod_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipMethod.CellValueChanged
        If Me.dgvShipMethod.RowCount <> 0 Then
            Dim RowEmail, RowShipMethodID, RowShipMethodDescription, RowShipMethodType, RowAddress1, RowAddress2, RowCity, RowState, RowZip, RowPhone, RowFax As String
            Dim RowIndex As Integer = Me.dgvShipMethod.CurrentCell.RowIndex

            Try
                RowShipMethodID = Me.dgvShipMethod.Rows(RowIndex).Cells("ShipMethIDColumn").Value
            Catch ex As Exception
                RowShipMethodID = 0
            End Try
            Try
                RowShipMethodDescription = Me.dgvShipMethod.Rows(RowIndex).Cells("ShipMethDescColumn").Value
            Catch ex As Exception
                RowShipMethodDescription = ""
            End Try
            Try
                RowShipMethodType = Me.dgvShipMethod.Rows(RowIndex).Cells("ShipMethodTypeColumn").Value
            Catch ex As Exception
                RowShipMethodType = ""
            End Try
            Try
                RowAddress1 = Me.dgvShipMethod.Rows(RowIndex).Cells("Address1Column").Value
            Catch ex As Exception
                RowAddress1 = ""
            End Try
            Try
                RowAddress2 = Me.dgvShipMethod.Rows(RowIndex).Cells("Address2Column").Value
            Catch ex As Exception
                RowAddress2 = ""
            End Try
            Try
                RowCity = Me.dgvShipMethod.Rows(RowIndex).Cells("CityColumn").Value
            Catch ex As Exception
                RowCity = ""
            End Try
            Try
                RowState = Me.dgvShipMethod.Rows(RowIndex).Cells("StateColumn").Value
            Catch ex As Exception
                RowState = ""
            End Try
            Try
                RowZip = Me.dgvShipMethod.Rows(RowIndex).Cells("ZipCodeColumn").Value
            Catch ex As Exception
                RowZip = ""
            End Try
            Try
                RowPhone = Me.dgvShipMethod.Rows(RowIndex).Cells("PhoneColumn").Value
            Catch ex As Exception
                RowPhone = ""
            End Try
            Try
                RowFax = Me.dgvShipMethod.Rows(RowIndex).Cells("FaxColumn").Value
            Catch ex As Exception
                RowFax = ""
            End Try
            Try
                RowEmail = Me.dgvShipMethod.Rows(RowIndex).Cells("EmailColumn").Value
            Catch ex As Exception
                RowEmail = ""
            End Try

            'Update Ship Method Table
            cmd = New SqlCommand("UPDATE ShipMethod SET ShipMethDesc = @ShipMethDesc, DivisionID = @DivisionID, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, ZipCode = @ZipCode, Phone = @Phone, Fax = @Fax, Email = @Email, ShipMethodType = @ShipMethodType WHERE ShipMethID = @ShipMethID", con)

            With cmd.Parameters
                .Add("@ShipMethID", SqlDbType.VarChar).Value = RowShipMethodID
                .Add("@ShipMethDesc", SqlDbType.VarChar).Value = RowShipMethodDescription
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Address1", SqlDbType.VarChar).Value = RowAddress1
                .Add("@Address2", SqlDbType.VarChar).Value = RowAddress2
                .Add("@City", SqlDbType.VarChar).Value = RowCity
                .Add("@State", SqlDbType.VarChar).Value = RowState
                .Add("@ZipCode", SqlDbType.VarChar).Value = RowZip
                .Add("@Phone", SqlDbType.VarChar).Value = RowPhone
                .Add("@Fax", SqlDbType.VarChar).Value = RowFax
                .Add("@Email", SqlDbType.VarChar).Value = RowEmail
                .Add("@ShipMethodType", SqlDbType.VarChar).Value = RowShipMethodType
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub
End Class