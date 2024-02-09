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

Public Class View1099Misc
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
        MyReport = CRX1099Misc1

        Dim parameter As String
        parameter = ""
        CRX1099Misc1.SetParameterValue("GrossProceeds", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Rents", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("GrossProceeds2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Rents2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorTaxID1", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorTaxID2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Name1", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Name2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorName1", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorName2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorAddressP1", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorAddressP2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorAddressO1", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("VendorAddressO2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Division1", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Division2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Company1", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Company2", parameter)
        parameter = ""
        CRX1099Misc1.SetParameterValue("Date2", parameter)
        CRX1099Misc1 = MyReport
        CrystalReportViewer1.ReportSource = CRX1099Misc1

        LoadCurrentDivision()

        cmd = New SqlCommand("SELECT DISTINCT VendorName FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter9.Fill(ds9, "Vendor")
        con.Close()

        cboName1.DataSource = ds9.Tables("Vendor")
        cboName1.ValueMember = "VendorName"
        cboName1.DisplayMember = "VendorName"
        cboName1.SelectedIndex = -1

        cmd2 = New SqlCommand("SELECT DISTINCT VendorName FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd2

        myAdapter5.Fill(ds5, "Vendor")
        cboName2.BindingContext = New BindingContext
        cboName2.DataSource = ds5.Tables("Vendor")
        con.Close()
        cboName2.ValueMember = "VendorName"
        cboName2.DisplayMember = "VendorName"
        cboName2.SelectedIndex = -1

        cboDiv2.SelectedIndex = -1


    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        txtRent1.Text = ""
        txtRent2.Text = ""
        txtGross1.Text = ""
        txtGross2.Text = ""
        cboDiv1.Text = ""
        cboDiv2.Text = ""
        cboName1.Text = ""
        cboName2.Text = ""

    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        MyReport = CRX1099Misc1
        LoadAllInfo()
        Dim parameter As String
        parameter = txtGross1.Text
        CRX1099Misc1.SetParameterValue("GrossProceeds", parameter)
        parameter = txtRent1.Text
        CRX1099Misc1.SetParameterValue("Rents", parameter)
        parameter = txtGross2.Text
        CRX1099Misc1.SetParameterValue("GrossProceeds2", parameter)
        parameter = txtRent2.Text
        CRX1099Misc1.SetParameterValue("Rents2", parameter)
        parameter = taxid1
        CRX1099Misc1.SetParameterValue("VendorTaxID1", parameter)
        parameter = taxid2
        CRX1099Misc1.SetParameterValue("VendorTaxID2", parameter)
        parameter = name1099
        CRX1099Misc1.SetParameterValue("Name1", parameter)
        parameter = name10992
        CRX1099Misc1.SetParameterValue("Name2", parameter)
        parameter = vendorName
        CRX1099Misc1.SetParameterValue("VendorName1", parameter)
        parameter = vendorName2
        CRX1099Misc1.SetParameterValue("VendorName2", parameter)
        parameter = vendorAddress1 + " " + vendorAddress2
        CRX1099Misc1.SetParameterValue("VendorAddressP1", parameter)
        parameter = vendorAddress12 + vendorAddress22
        CRX1099Misc1.SetParameterValue("VendorAddressP2", parameter)
        parameter = vendorCity + " " + vendorState + " " + vendorCountry + " " + vendorZip
        CRX1099Misc1.SetParameterValue("VendorAddressO1", parameter)
        parameter = vendorCity2 + " " + vendorState2 + " " + vendorCountry2 + " " + vendorZip2
        CRX1099Misc1.SetParameterValue("VendorAddressO2", parameter)
        parameter = cboDiv1.Text
        CRX1099Misc1.SetParameterValue("Division1", parameter)
        parameter = cboDiv2.Text
        CRX1099Misc1.SetParameterValue("Division2", parameter)
        If cboDiv2.Text = "" Or cboDiv2.SelectedIndex = -1 Then
            parameter = ""
        Else
            parameter = "23"
        End If
        CRX1099Misc1.SetParameterValue("Date2", parameter)
        parameter = company1
        CRX1099Misc1.SetParameterValue("Company1", parameter)
        parameter = company2
        CRX1099Misc1.SetParameterValue("Company2", parameter)
        CRX1099Misc1 = MyReport
        CrystalReportViewer1.ReportSource = CRX1099Misc1
        If String.IsNullOrEmpty(txtGross1.Text) Then
            txtGross1.Text = "0"
        End If
        If String.IsNullOrEmpty(txtGross2.Text) Then
            txtGross2.Text = "0"
        End If
        If String.IsNullOrEmpty(txtRent1.Text) Then
            txtRent1.Text = "0"
        End If
        If String.IsNullOrEmpty(txtRent2.Text) Then
            txtRent2.Text = "0"
        End If
        Dim gross1, gross2, rent1, rent2 As Decimal
        If Decimal.TryParse(txtGross1.Text, gross1) AndAlso Decimal.TryParse(txtGross2.Text, gross2) AndAlso Decimal.TryParse(txtRent1.Text, rent1) AndAlso Decimal.TryParse(txtRent2.Text, rent2) Then
            GlobalVariables.stringVar = CStr(gross1 + gross2 + rent1 + rent2)
        Else
            GlobalVariables.stringVar = "0"
        End If
        GlobalVariables.stringVar2 = cboDiv1.Text

        If chksecond.Checked = True Then
            GlobalVariables.totalfiles = 2
        Else
            GlobalVariables.totalfiles = 1
        End If

        Dim newPrint1096Misc As New View1096Misc
        newPrint1096Misc.Show()

    End Sub

    Public Sub LoadVendorName()
        cmd = New SqlCommand("SELECT DISTINCT VendorName FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter9.Fill(ds9, "Vendor")
        con.Close()

        cboName1.DataSource = ds9.Tables("Vendor")
        cboName1.ValueMember = "VendorName"
        cboName1.DisplayMember = "VendorName"
        cboName1.SelectedIndex = -1

        cmd2 = New SqlCommand("SELECT DISTINCT VendorName FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd2

        myAdapter5.Fill(ds5, "Vendor")
        cboName2.DataSource = ds5.Tables("Vendor")
        con.Close()
        cboName2.ValueMember = "VendorName"
        cboName2.DisplayMember = "VendorName"
        cboName2.SelectedIndex = -1
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Enabled = True
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()


                cboDiv2.Enabled = True
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "ALB"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "ALB"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "ATL"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "ATL"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "CBS"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "CBS"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "CHT"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "CBS"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "CGO"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "CGO"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "DEN"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "DEN"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "HOU"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "HOU"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "LLH"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "LLH"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "SLC"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "SLC"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "TFF"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "TFF"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "TFP"
                cboDiv1.Enabled = True
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "TFP"
                cboDiv2.Enabled = True
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "TFT"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "TFT"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "TOR"
                cboDiv1.Enabled = False
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "TOR"
                cboDiv2.Enabled = False
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "TWD"
                cboDiv1.Enabled = True
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "TWD"
                cboDiv2.Enabled = True
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv1.Text = "TWE"
                cboDiv1.Enabled = True
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDiv2.Text = "TWE"
                cboDiv2.Enabled = True
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv1.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()


                cboDiv1.Enabled = True
                cboDiv1.ValueMember = "DivisionKey"
                cboDiv1.DisplayMember = "DivisionKey"
                'cboDiv1.SelectedIndex = -1

                cmd3 = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd3
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDiv2.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()


                cboDiv2.Enabled = True
                cboDiv2.ValueMember = "DivisionKey"
                cboDiv2.DisplayMember = "DivisionKey"
                'cboDiv2.SelectedIndex = -1
        End Select
    End Sub

    Public Sub LoadItemVendorNameByDivision1()
        cmd = New SqlCommand("SELECT DISTINCT VendorName FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDiv1.Text
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter9.Fill(ds9, "Vendor")
        con.Close()

        cboName1.DataSource = ds9.Tables("Vendor")
        cboName1.ValueMember = "VendorName"
        cboName1.DisplayMember = "VendorName"
        cboName1.SelectedIndex = -1

    End Sub

    Public Sub LoadItemVendorNameByDivision2()
        cmd4 = New SqlCommand("SELECT DISTINCT VendorName FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDiv2.Text
        ds5 = New DataSet()
        myAdapter7.SelectCommand = cmd4

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter9.Fill(ds5, "Vendor")
        con.Close()
        cboName2.BindingContext = New BindingContext
        cboName2.DataSource = ds9.Tables("Vendor")
        cboName2.ValueMember = "VendorName"
        cboName2.DisplayMember = "VendorName"
        cboName2.SelectedIndex = -1
    End Sub

    Private Sub cboDiv1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiv1.SelectedIndexChanged
        LoadItemVendorNameByDivision1()
        If chksecond.Checked = True Then
            cboDiv2.Text = cboDiv1.Text
            LoadItemVendorNameByDivision2()
        End If
    End Sub

    Private Sub cboDiv2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiv2.SelectedIndexChanged
        If chksecond.Checked = True Then
            cboDiv1.Text = cboDiv2.Text
            LoadItemVendorNameByDivision2()
        End If
    End Sub

    Public Sub LoadAllInfo()
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Dim commandText As String = "SELECT Name1099, VendorName, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorCountry, VendorZip, VendorTaxID FROM Vendor WHERE DivisionID = @DivisionID AND VendorName = @VendorName"
            Using commands As SqlCommand = New SqlCommand(commandText, con)
                commands.Parameters.Add("@VendorName", SqlDbType.VarChar).Value = cboName1.Text
                commands.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDiv1.Text
                Using reader As SqlDataReader = commands.ExecuteReader
                    If reader.Read Then
                        name1099 = reader.GetValue(0)
                        vendorName = reader.GetValue(1)
                        vendorAddress1 = reader.GetValue(2)
                        vendorAddress2 = reader.GetValue(3)
                        vendorCity = reader.GetValue(4)
                        vendorState = reader.GetValue(5)
                        vendorCountry = reader.GetValue(6)
                        vendorZip = reader.GetValue(7)
                        taxid1 = reader.GetValue(8)
                    Else
                        name1099 = ""
                        vendorName = ""
                        vendorAddress1 = ""
                        vendorAddress2 = ""
                        vendorCity = ""
                        vendorState = ""
                        vendorCountry = ""
                        vendorZip = ""
                        taxid1 = ""
                    End If
                End Using
            End Using
            Dim commandText2 As String = "SELECT CompanyName FROM DivisionTable WHERE DivisionKey = @DivisionID"
            Using commands As SqlCommand = New SqlCommand(commandText2, con)
                commands.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDiv1.Text
                Using reader As SqlDataReader = commands.ExecuteReader
                    If reader.Read Then
                        company1 = reader.GetValue(0)
                    Else
                        company1 = ""
                    End If
                End Using
            End Using
        Catch ex As System.Exception
            name1099 = ""
            vendorName = ""
            vendorAddress1 = ""
            vendorAddress2 = ""
            vendorCity = ""
            vendorState = ""
            vendorCountry = ""
            vendorZip = ""
            company1 = ""
            taxid1 = ""
        End Try
        Try
            If chksecond.Checked = True Then
                Dim commandText As String = "SELECT Name1099, VendorName, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorCountry, VendorZip, VendorTaxID FROM Vendor WHERE DivisionID = @DivisionID AND VendorName = @VendorName"
                Using commands As SqlCommand = New SqlCommand(commandText, con)
                    commands.Parameters.Add("@VendorName", SqlDbType.VarChar).Value = cboName2.Text
                    commands.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDiv2.Text
                    Using reader As SqlDataReader = commands.ExecuteReader
                        If reader.Read Then
                            name10992 = reader.GetValue(0)
                            vendorName2 = reader.GetValue(1)
                            vendorAddress12 = reader.GetValue(2)
                            vendorAddress22 = reader.GetValue(3)
                            vendorCity2 = reader.GetValue(4)
                            vendorState2 = reader.GetValue(5)
                            vendorCountry2 = reader.GetValue(6)
                            vendorZip2 = reader.GetValue(7)
                            taxid2 = reader.GetValue(8)
                        Else
                            name10992 = ""
                            vendorName2 = ""
                            vendorAddress12 = ""
                            vendorAddress22 = ""
                            vendorCity2 = ""
                            vendorState2 = ""
                            vendorCountry2 = ""
                            vendorZip2 = ""
                            taxid2 = ""
                        End If
                    End Using
                End Using
                Dim commandText2 As String = "SELECT CompanyName FROM DivisionTable WHERE DivisionKey = @DivisionID"
                Using commands As SqlCommand = New SqlCommand(commandText2, con)
                    commands.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDiv2.Text
                    Using reader As SqlDataReader = commands.ExecuteReader
                        If reader.Read Then
                            company2 = reader.GetValue(0)
                        Else
                            company2 = ""
                        End If
                    End Using
                End Using
            Else
                name10992 = ""
                vendorName2 = ""
                vendorAddress12 = ""
                vendorAddress22 = ""
                vendorCity2 = ""
                vendorState2 = ""
                vendorCountry2 = ""
                vendorZip2 = ""
                company2 = ""
                taxid2 = ""
            End If



        Catch ex As System.Exception
            'MsgBox("Error")
            name10992 = ""
            vendorName2 = ""
            vendorAddress12 = ""
            vendorAddress22 = ""
            vendorCity2 = ""
            vendorState2 = ""
            vendorCountry2 = ""
            vendorZip2 = ""
            company2 = ""
            taxid2 = ""
        End Try
        con.Close()
    End Sub

    Private Sub chksecond_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksecond.CheckedChanged
        If chksecond.Checked = True Then
            GroupBox2.Enabled = True
            cboDiv2.Text = cboDiv1.Text
        Else
            GroupBox2.Enabled = False
            cboDiv2.SelectedIndex = -1
            cboName2.SelectedIndex = -1
            txtGross2.Text = ""
            txtRent2.Text = ""
        End If
    End Sub

    Private Sub cboName1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboName1.SelectedIndexChanged

    End Sub

    Private Sub chksecond_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chksecond.CheckStateChanged
        If chksecond.Checked = True Then
            GroupBox2.Enabled = True
            cboDiv2.Text = cboDiv1.Text
        Else
            GroupBox2.Enabled = False
            cboDiv2.SelectedIndex = -1
            cboName2.SelectedIndex = -1
            txtGross2.Text = ""
            txtRent2.Text = ""
        End If
    End Sub
End Class