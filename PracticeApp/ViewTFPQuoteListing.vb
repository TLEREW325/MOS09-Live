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
Public Class ViewTFPQuoteListing

    Dim FOXFilter, CustomerFilter, PartFilter, InquiryNumberFilter, QuoteNumberFilter, PreparerFilter, DateFilter As String
    Dim strQuoteNumber As String = ""
    Dim QuoteNumber As Integer = 0
    Dim FOXNumber As Integer = 0
    Dim strFOXNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewTFPQuoteListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerID()
        LoadCustomerName()
        LoadFOXNumbers()
        LoadPartNumbers()
        LoadPreparers()
        LoadQuoteNumbers()
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
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text = "" Then
            CustomerFilter = ""
        Else
            CustomerFilter = " AND CustomerID = '" + cboCustomerID.Text + "'"
        End If
        If cboPartNumber.Text = "" Then
            PartFilter = ""
        Else
            PartFilter = " AND (CustPartNo = '" + cboPartNumber.Text + "' OR TFPPartNo = '" + cboPartNumber.Text + "')"
        End If
        If cboPreparer.Text = "" Then
            PreparerFilter = ""
        Else
            PreparerFilter = " AND Preparer = '" + cboPreparer.Text + "'"
        End If
        If txtCustomerInquiryNumber.Text = "" Then
            InquiryNumberFilter = ""
        Else
            InquiryNumberFilter = " AND CustomerInqueryNumber = '" + txtCustomerInquiryNumber.Text + "'"
        End If
        If cboFOXNumber.Text = "" Then
            FOXFilter = ""
        Else
            FOXNumber = Val(cboFOXNumber.Text)
            strFOXNumber = CStr(FOXNumber)
            FOXFilter = " AND FOXNumber = '" + strFOXNumber + "'"
        End If
        If cboQuoteNumber.Text = "" Then
            QuoteNumberFilter = ""
        Else
            QuoteNumber = Val(cboQuoteNumber.Text)
            strQuoteNumber = CStr(QuoteNumber)
            QuoteNumberFilter = " AND QuoteID = '" + strQuoteNumber + "'"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND QuoteDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM TFPQuotationQuery WHERE DivisionID = @DivisionID" + CustomerFilter + FOXFilter + PartFilter + InquiryNumberFilter + QuoteNumberFilter + PreparerFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TFPQuotationQuery")
        dgvQuoteListing.DataSource = ds.Tables("TFPQuotationQuery")
        con.Close()
    End Sub

    Private Sub LoadPreparers()
        cmd = New SqlCommand("SELECT DISTINCT(Preparer) FROM Quotation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "Quotation")
        con.Close()

        cboPreparer.DisplayMember = "Preparer"
        cboPreparer.DataSource = ds1.Tables("Quotation")
        cboPreparer.SelectedIndex = -1
    End Sub

    Private Sub LoadQuoteNumbers()
        cmd = New SqlCommand("SELECT QuoteID FROM Quotation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "Quotation")
        con.Close()

        cboQuoteNumber.DisplayMember = "QuoteID"
        cboQuoteNumber.DataSource = ds2.Tables("Quotation")
        cboQuoteNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerID.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Private Sub LoadFOXNumbers()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "FOXTable")
        cboFOXNumber.DataSource = ds4.Tables("FOXTable")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadPartNumbers()
        cmd = New SqlCommand("SELECT DISTINCT(CustPartNo) as CustPartNo FROM Quotation UNION ALL SELECT DISTINCT(TFPPartNo) as CustPartNo FROM Quotation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "Quotation")
        con.Close()

        cboPartNumber.DisplayMember = "CustPartNo"
        cboPartNumber.DataSource = ds5.Tables("Quotation")
        cboPartNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerList")
        cboCustomerName.DataSource = ds6.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cboCustomerID.Text = ""
        End If
        cboPreparer.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPreparer.Text) Then
            cboPreparer.Text = ""
        End If
        txtCustomerInquiryNumber.Clear()
        cboQuoteNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            cboQuoteNumber.Text = ""
        End If
        chkDateRange.Checked = False
        dtpBeginDate.Value = Today.Date
        dtpEndDate.Value = Today.Date
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If

        dgvQuoteListing.DataSource = Nothing

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdOpenQuoteForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenQuoteForm.Click
        If dgvQuoteListing.CurrentRow IsNot Nothing Then
            Dim newQuoteForm As New TFPQuoteForm(dgvQuoteListing.CurrentRow.Cells("QuoteIDColumn").Value.ToString())
            newQuoteForm.Show()
            newQuoteForm.Parent = Me.Parent
            Me.Close()
            Me.Dispose()
        Else
            MessageBox.Show("You select a Quote from the data grid.", "Select a Quote", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cmdReprintQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintQuote.Click
        If dgvQuoteListing.CurrentRow IsNot Nothing Then
            GlobalTFPQuoteNumber = dgvQuoteListing.CurrentRow.Cells("QuoteIDColumn").Value
            GlobalDivisionCode = EmployeeCompanyCode

            Using NewPrintTFQuote As New PrintTFQuote
                Dim result = NewPrintTFQuote.ShowDialog()
            End Using
        Else
            MessageBox.Show("You select a Quote from the data grid.", "Select a Quote", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ReprintQuoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprintQuoteToolStripMenuItem.Click
        cmdReprintQuote_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintTFQuoteList As New PrintTFPQuoteList()
            Dim result = NewPrintTFQuoteList.ShowDialog()
        End Using
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub dgvQuoteListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuoteListing.CellDoubleClick
        If dgvQuoteListing.Rows.Count > 0 Then
            If e.RowIndex >= 0 Then
                Dim newQuoteForm As New TFPQuoteForm(dgvQuoteListing.CurrentRow.Cells("QuoteIDColumn").Value.ToString())
                newQuoteForm.Show()
                newQuoteForm.Parent = Me.Parent
                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub
End Class