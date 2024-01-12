Imports System.Data.SqlClient

Public Class CustomerSalesRanking
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As SqlDataAdapter
    Dim ds As DataSet
    Dim isloaded As Boolean = False
    Public Sub New()
        InitializeComponent()

        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboDivisionID.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
        con.Close()
        isloaded = True
        cboDivisionID.Text = EmployeeCompanyCode
        If EmployeeCompanyCode.Equals("ADM") Then
            cboDivisionID.Enabled = True
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            'ShowData()
        End If
    End Sub

    Private Sub ShowData()
        cmd = New SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY InvoiceTotal DESC) as BatchNumber, DivisionID, CustomerID, CustomerName, ProductTotal, BilledFreight, SalesTax, InvoiceTotal, InvoiceCOS FROM (SELECT InvoiceHeaderTable.CustomerID, CustomerList.CustomerName, SUM(ProductTotal) as ProductTotal, SUM(BilledFreight) as BilledFreight, SUM(SalesTax + SalesTax2 + SalesTax3) as SalesTax, SUM(InvoiceTotal) as InvoiceTotal, SUM(InvoiceCOS) as InvoiceCOS, InvoiceHeaderTable.DivisionID FROM InvoiceHeaderTable LEFT OUTER JOIN CustomerList ON InvoiceHeaderTable.CustomerID = CustomerList.CustomerID AND InvoiceHeaderTable.DivisionID = CustomerList.DivisionID ", con)
        Dim SumCMD As New SqlCommand("SELECT SUM(ProductTotal) as ProductTotal, SUM(BilledFreight) as BilledFreight, SUM(SalesTax + SalesTax2 + SalesTax3) as SalesTax, SUM(InvoiceTotal) as InvoiceTotal, SUM(InvoiceCOS) as InvoiceCOS FROM InvoiceHeaderTable ", con)
        Dim isfirst As Boolean = True
        If Not cboDivisionID.Text.Equals("ADM") Then
            isfirst = False
            cmd.CommandText += " WHERE InvoiceHeaderTable.DivisionID = @DivisionID"
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumCMD.CommandText += " WHERE InvoiceHeaderTable.DivisionID = @DivisionID"
            SumCMD.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If chkFiscalYear.Checked Then
            If isfirst Then
                cmd.CommandText += " WHERE InvoiceDate BETWEEN @BeginDate AND @EndDate"
                SUMcmd.CommandText += " WHERE InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Else
                cmd.CommandText += " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
                SUMcmd.CommandText += " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            End If
            If Now.Month >= 5 Then
                cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = New Date(Now.Year, 5, 1)
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = New Date(Now.Year + 1, 4, 30)
                SumCMD.Parameters.Add("@BeginDate", SqlDbType.Date).Value = New Date(Now.Year, 5, 1)
                SumCMD.Parameters.Add("@EndDate", SqlDbType.Date).Value = New Date(Now.Year + 1, 4, 30)
            Else
                cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = New Date(Now.Year - 1, 5, 1)
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = New Date(Now.Year, 4, 30)
                SumCMD.Parameters.Add("@BeginDate", SqlDbType.Date).Value = New Date(Now.Year - 1, 5, 1)
                SumCMD.Parameters.Add("@EndDate", SqlDbType.Date).Value = New Date(Now.Year, 4, 30)
            End If
        ElseIf chkUseDateRange.Checked Then
            If isfirst Then
                cmd.CommandText += " WHERE InvoiceDate BETWEEN @BeginDate AND @EndDate"
                SumCMD.CommandText += " WHERE InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Else
                cmd.CommandText += " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
                SumCMD.CommandText += " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            End If
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value.Date
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value.Date
            SumCMD.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value.Date
            SumCMD.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value.Date
        End If
        cmd.CommandText += " GROUP BY InvoiceHeaderTable.DivisionID, InvoiceHeaderTable.CustomerID, CustomerList.CustomerName) as InvoiceHeaderTable ORDER BY InvoiceTotal DESC"
        ds = New DataSet()
        myAdapter = New SqlDataAdapter(cmd)

        Dim invoiceTotal = 0D

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "InvoiceHeaderTable")
        ds.Tables("InvoiceHeaderTable").Rows.Add()
        Dim reader As SqlDataReader = SumCMD.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("InvoiceTotal")) Then
                invoiceTotal = reader.Item("InvoiceTotal")
            End If
            Dim rw As DataRow = ds.Tables("InvoiceHeaderTable").NewRow()
            rw.Item("BatchNumber") = DBNull.Value
            rw.Item("DivisionID") = ""
            rw.Item("CustomerID") = "TOTALS"
            rw.Item("CustomerName") = "TOTALS"
            rw.Item("ProductTotal") = reader.Item("ProductTotal")
            rw.Item("BilledFreight") = reader.Item("BilledFreight")
            rw.Item("SalesTax") = reader.Item("SalesTax")
            rw.Item("InvoiceTotal") = reader.Item("InvoiceTotal")
            rw.Item("InvoiceCOS") = reader.Item("InvoiceCOS")

            ds.Tables("InvoiceHeaderTable").Rows.Add(rw)
        End If
        con.Close()
        ds.Tables("InvoiceHeaderTable").Columns.Add("SalesTax2")

        For i As Integer = 0 To ds.Tables("InvoiceHeaderTable").Rows.Count - 3
            If Not IsDBNull(ds.Tables("InvoiceHeaderTable").Rows(i).Item("InvoiceTotal")) Then
                ds.Tables("InvoiceHeaderTable").Rows(i).Item("SalesTax2") = Math.Round((ds.Tables("InvoiceHeaderTable").Rows(i).Item("InvoiceTotal") / invoiceTotal) * 100, 4, MidpointRounding.AwayFromZero)
            End If
        Next

        dgvCustomerRanking.DataSource = ds.Tables("InvoiceHeaderTable")
        SetupDGV()
    End Sub

    Private Sub SetupDGV()
        dgvCustomerRanking.Columns("CustomerID").Visible = False
        If Not cboDivisionID.Text.Equals("ADM") Then
            dgvCustomerRanking.Columns("DivisionID").Visible = False
        Else
            dgvCustomerRanking.Columns("DivisionID").Visible = True
        End If
        dgvCustomerRanking.Columns("BatchNumber").HeaderText = "Ranking"
        dgvCustomerRanking.Columns("CustomerName").HeaderText = "Customer Name"
        dgvCustomerRanking.Columns("CustomerName").DefaultCellStyle.Format = "C2"
        dgvCustomerRanking.Columns("ProductTotal").HeaderText = "Product Total"
        dgvCustomerRanking.Columns("ProductTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCustomerRanking.Columns("ProductTotal").DefaultCellStyle.Format = "C2"
        dgvCustomerRanking.Columns("BilledFreight").HeaderText = "Billed Freight Total"
        dgvCustomerRanking.Columns("BilledFreight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCustomerRanking.Columns("BilledFreight").DefaultCellStyle.Format = "C2"
        dgvCustomerRanking.Columns("SalesTax").HeaderText = "Sales Tax Total"
        dgvCustomerRanking.Columns("SalesTax").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCustomerRanking.Columns("SalesTax").DefaultCellStyle.Format = "C2"
        dgvCustomerRanking.Columns("SalesTax2").HeaderText = " Percent of Total"
        dgvCustomerRanking.Columns("SalesTax2").DefaultCellStyle.Format = "p4"
        dgvCustomerRanking.Columns("SalesTax2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvCustomerRanking.Columns("InvoiceTotal").HeaderText = "Invoice Total"
        dgvCustomerRanking.Columns("InvoiceTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCustomerRanking.Columns("InvoiceTotal").DefaultCellStyle.Format = "C2"
        ''will only format the COS column if security level is 1001 or 1002. If not will make invisible
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            dgvCustomerRanking.Columns("InvoiceCOS").HeaderText = "Invoice COS"
            dgvCustomerRanking.Columns("InvoiceCOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvCustomerRanking.Columns("InvoiceCOS").DefaultCellStyle.Format = "C2"
        Else
            dgvCustomerRanking.Columns("InvoiceCOS").Visible = False
        End If
        dgvCustomerRanking.Columns("DivisionID").HeaderText = "Division ID"
        dgvCustomerRanking.Rows(dgvCustomerRanking.Rows.Count - 1).Cells("CustomerName").Style.Font = New System.Drawing.Font(dgvCustomerRanking.DefaultCellStyle.Font.FontFamily, dgvCustomerRanking.DefaultCellStyle.Font.Size, FontStyle.Bold, dgvCustomerRanking.DefaultCellStyle.Font.Unit)
        dgvCustomerRanking.Refresh()
    End Sub

    Private Sub chkFiscalYear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiscalYear.CheckedChanged
        If chkFiscalYear.Checked Then
            chkAllTime.Checked = False
            chkUseDateRange.Checked = False
            If isloaded Then
                'ShowData()
            End If
        ElseIf Not chkAllTime.Checked And Not chkUseDateRange.Checked Then
            isloaded = False
            chkFiscalYear.Checked = True
            isloaded = True
        End If
    End Sub

    Private Sub chkAllTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTime.CheckedChanged
        If chkAllTime.Checked Then
            chkFiscalYear.Checked = False
            chkUseDateRange.Checked = False
            If isloaded Then
                'ShowData()
            End If
        ElseIf Not chkFiscalYear.Checked And Not chkUseDateRange.Checked Then
            isloaded = False
            chkAllTime.Checked = True
            isloaded = True
        End If
    End Sub

    Private Sub cmdReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReload.Click
        ShowData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        isloaded = False
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        isloaded = False
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim tempds As New DataSet
        If ds IsNot Nothing Then
            tempds = ds.Copy()
            tempds.Tables("InvoiceHeaderTable").Columns.Add("InvoiceNumber")
            tempds.Tables("InvoiceHeaderTable").Columns("CustomerID").ColumnName = "CustomerID2"
            tempds.Tables("InvoiceHeaderTable").Columns("CustomerName").ColumnName = "CustomerID"
            Dim addDivisionID As Integer = 0
            If Not cboDivisionID.Text.Equals("ADM") Then
                addDivisionID = 1
            End If
            For i As Integer = 0 To tempds.Tables("InvoiceHeaderTable").Rows.Count - 1
                tempds.Tables("InvoiceHeaderTable").Rows(i).Item("InvoiceNumber") = addDivisionID
            Next
        End If
        Dim newPrintCustomerSalesRanking As New PrintCustomerSalesRanking(tempds)
        newPrintCustomerSalesRanking.ShowDialog()
    End Sub

    Private Sub chkUseDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseDateRange.CheckedChanged
        If chkUseDateRange.Checked Then
            chkAllTime.Checked = False
            chkFiscalYear.Checked = False
            If isloaded Then
                'ShowData()
            End If
        ElseIf Not chkAllTime.Checked And Not chkFiscalYear.Checked Then
            isloaded = False
            chkUseDateRange.Checked = True
            isloaded = True
        End If
    End Sub

    Private Sub dtpBeginDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBeginDate.ValueChanged
        If Not chkUseDateRange.Checked Then
            chkUseDateRange.Checked = True
        ElseIf isloaded Then
            'ShowData()
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEndDate.ValueChanged
        If Not chkUseDateRange.Checked Then
            chkUseDateRange.Checked = True
        ElseIf isloaded Then
            'ShowData()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dgvCustomerRanking.DataSource = Nothing
    End Sub

    Private Sub CustomerSalesRanking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class