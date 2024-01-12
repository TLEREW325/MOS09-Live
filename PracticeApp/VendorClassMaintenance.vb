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
Public Class VendorClassMaintenance
    Inherits System.Windows.Forms.Form

    Dim VendorClassDescription As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cnd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub VendorClassMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If

        LoadVendorClass()
        ShowData()
        ClearData()
    End Sub

    Private Sub ShowData()
        'Command to load Vendor Table for specific division
        cmd = New SqlCommand("SELECT * FROM VendorClass", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "VendorClass")
        dgvVendorClass.DataSource = ds.Tables("VendorClass")
        con.Close()
    End Sub

    Private Sub LoadVendorClass()
        'Command to load Vendor Table for specific division
        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "VendorClass")
        cboVendorClass.DataSource = ds1.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub

    Public Sub LoadDescription()
        Dim VendorClassDescriptionStatement As String = "SELECT VendClassName FROM VendorClass WHERE VendClassID = @VendClassID"
        Dim VendorClassDescriptionCommand As New SqlCommand(VendorClassDescriptionStatement, con)
        VendorClassDescriptionCommand.Parameters.Add("@VendClassID", SqlDbType.VarChar).Value = cboVendorClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorClassDescription = CStr(VendorClassDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            VendorClassDescription = ""
        End Try
        con.Close()

        txtDescription.Text = VendorClassDescription
    End Sub

    Public Sub ClearData()
        cboVendorClass.SelectedIndex = -1
        txtDescription.Clear()
        cboVendorClass.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboVendorClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorClass.SelectedIndexChanged
        LoadDescription()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ShowData()
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        If cboVendorClass.Text = "" Then
            MsgBox("You must have a valid Vendor Class ID selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                cmd = New SqlCommand("INSERT INTO VendorClass (VendClassID, VendClassName)Values(@VendClassID, @VendClassName)", con)

                With cmd.Parameters
                    .Add("@VendClassID", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@VendClassName", SqlDbType.VarChar).Value = txtDescription.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteScalar()
                con.Close()
            Catch ex As Exception
                cmd = New SqlCommand("UPDATE VendorClass SET VendClassName = @VendClassName WHERE VendClassID = @VendClassID", con)

                With cmd.Parameters
                    .Add("@VendClassID", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@VendClassName", SqlDbType.VarChar).Value = txtDescription.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteScalar()
                con.Close()
            End Try
        End If

        ShowData()
        ClearData()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Save data in datagrid
        Dim Updater As New SqlCommandBuilder(myAdapter)
        Me.Validate()
        Me.myAdapter.Update(Me.ds.Tables("VendorClass"))
        Me.ds.AcceptChanges()

        ShowData()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboVendorClass.Text = "" Then
            MsgBox("You must have a valid Vendor Class ID selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                cmd = New SqlCommand("DELETE FROM VendorClass WHERE VendClassID = @VendClassID", con)

                With cmd.Parameters
                    .Add("@VendorClassID", SqlDbType.VarChar).Value = cboVendorClass.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteScalar()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If

        LoadVendorClass()
        ShowData()
        ClearData()
    End Sub
End Class