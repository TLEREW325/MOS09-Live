Imports System.Data.SqlClient

Public Class ViewARRecurringPayment
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand

    Public Sub New()
        InitializeComponent()

        LoadDivisionID()
        If EmployeeSecurityCode > 1002 And Not EmployeeLoginName.Equals("JBASSETTI") And Not EmployeeLoginName.Equals("ALEHNER") Then
            cboDivisionID.Enabled = False
        End If
        LoadNotificationRecipients()
        cboNotificationRecipient.Text = GetCurrentUserName()
        cboDivisionID.Text = EmployeeCompanyCode
    End Sub

    Private Sub LoadDivisionID()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboDivisionID.Items.Add(reader.Item(0))
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadInvoiceNumbers()

        If cboDivisionID.Text.Equals("ADM") Then
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable", con)
        Else
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        Dim tempds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "InvoiceHeaderTable")

        cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        cboInvoiceNumber.DataSource = tempds.Tables("InvoiceHeaderTable")
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomers()
        If cboDivisionID.Text.Equals("ADM") Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerID, CustomerName FROM CustomerList", con)
        Else
            cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If

        Dim tempadap As New SqlDataAdapter(cmd)
        Dim dt As New Data.DataTable("CustomerList")
        If con.State = ConnectionState.Closed Then con.Open()
        tempadap.Fill(dt)
        con.Close()

        cboCustomerID.DisplayMember = "CustomerID"
        cboCustomerID.DataSource = dt
        cboCustomerName.DisplayMember = "CustomerName"
        cboCustomerName.DataSource = dt
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub LoadNotificationRecipients()
        cmd = New SqlCommand("SELECT EmployeeFirst + ' ' + EmployeeLast FROM EmployeeData WHERE SecurityGroupID = 1001 OR SecurityGroupID = 1002 OR SecurityGroupID  = 1003", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboNotificationRecipient.Items.Add(reader.Item(0).ToString.ToUpper())
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadInvoiceNumbers()
        LoadCustomers()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectionChangeCommitted
        If cboCustomerName.SelectedIndex <> cboCustomerID.SelectedIndex And cboCustomerID.Focused() Then
            cboCustomerName.SelectedIndex = cboCustomerID.SelectedIndex
        Else
            cboCustomerName.Text = ""
        End If
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectionChangeCommitted
        If cboCustomerName.SelectedIndex <> cboCustomerID.SelectedIndex And cboCustomerName.Focused() Then
            cboCustomerID.SelectedIndex = cboCustomerName.SelectedIndex
        Else
            cboCustomerID.Text = ""
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim isFirst As Boolean = True
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            If Not String.IsNullOrEmpty(cboDivisionID.Text) Then
                If cboDivisionID.Text.Equals("ADM") Then
                    cmd = New SqlCommand("SELECT RecurringPaymentLineTable.RecurringPaymentNumber, LineNumber, InvoiceNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, NotificationNumber, Printed FROM RecurringPaymentLineTable INNER JOIN (SELECT RecurringPaymentNumber, InvoiceNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber in (SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE CustomerID = @CustomerID)) as RecurringPaymentHeaderTable ON RecurringPaymentLineTable.RecurringPaymentNumber = RecurringPaymentHeaderTable.RecurringPaymentNumber ", con)
                Else
                    cmd = New SqlCommand("SELECT RecurringPaymentLineTable.RecurringPaymentNumber, LineNumber, InvoiceNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, NotificationNumber, Printed FROM RecurringPaymentLineTable INNER JOIN (SELECT RecurringPaymentNumber, InvoiceNumber, DivisionID FROM RecurringPaymentHeaderTable WHERE InvoiceNumber in (SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID)) as RecurringPaymentHeaderTable ON RecurringPaymentLineTable.RecurringPaymentNumber = RecurringPaymentHeaderTable.RecurringPaymentNumber WHERE DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    isFirst = False
                End If
            Else
                cmd = New SqlCommand("SELECT RecurringPaymentLineTable.RecurringPaymentNumber, LineNumber, InvoiceNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, NotificationNumber, Printed FROM RecurringPaymentLineTable INNER JOIN (SELECT RecurringPaymentNumber, InvoiceNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber in (SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE CustomerID = @CustomerID)) as RecurringPaymentHeaderTable ON RecurringPaymentLineTable.RecurringPaymentNumber = RecurringPaymentHeaderTable.RecurringPaymentNumber ", con)
            End If
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Else
            If Not String.IsNullOrEmpty(cboDivisionID.Text) Then
                If cboDivisionID.Text.Equals("ADM") Then
                    cmd = New SqlCommand("SELECT RecurringPaymentLineTable.RecurringPaymentNumber, LineNumber, InvoiceNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, NotificationNumber, Printed FROM RecurringPaymentLineTable INNER JOIN RecurringPaymentHeaderTable ON RecurringPaymentLineTable.RecurringPaymentNumber = RecurringPaymentHeaderTable.RecurringPaymentNumber ", con)
                Else
                    cmd = New SqlCommand("SELECT RecurringPaymentLineTable.RecurringPaymentNumber, LineNumber, InvoiceNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, NotificationNumber, Printed FROM RecurringPaymentLineTable INNER JOIN RecurringPaymentHeaderTable ON RecurringPaymentLineTable.RecurringPaymentNumber = RecurringPaymentHeaderTable.RecurringPaymentNumber WHERE DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    isFirst = False
                End If
            Else
                cmd = New SqlCommand("SELECT RecurringPaymentLineTable.RecurringPaymentNumber, LineNumber, InvoiceNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, NotificationNumber, Printed FROM RecurringPaymentLineTable INNER JOIN RecurringPaymentHeaderTable ON RecurringPaymentLineTable.RecurringPaymentNumber = RecurringPaymentHeaderTable.RecurringPaymentNumber ", con)
            End If
        End If
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE InvoiceNumber = @InvoiceNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND InvoiceNumber = @InvoiceNumber"
            End If
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = Val(cboInvoiceNumber.Text)
        End If
        If chkUseDates.Checked Then
            If isFirst Then
                cmd.CommandText += " WHERE PaymentDate BETWEEN @StartDate AND @EndDate"
                isFirst = False
            Else
                cmd.CommandText += " AND PaymentDate BETWEEN @StartDate AND @EndDate"
            End If
        End If

        Dim tempdt As New Data.DataTable("RecurringPaymentLineTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempdt)
        con.Close()

        dgvRecurringPaymentLineTable.DataSource = tempdt
        FormatDGV()
    End Sub

    Private Sub FormatDGV()
        dgvRecurringPaymentLineTable.Columns("RecurringPaymentNumber").Visible = False
        dgvRecurringPaymentLineTable.Columns("LineNumber").Visible = False
        dgvRecurringPaymentLineTable.Columns("InvoiceNumber").HeaderText = "Invoice Number"
        dgvRecurringPaymentLineTable.Columns("PaymentDate").HeaderText = "Payment Date"
        dgvRecurringPaymentLineTable.Columns("BaseAmount").HeaderText = "Base Amount"
        dgvRecurringPaymentLineTable.Columns("BaseAmount").DefaultCellStyle.Format = "C2"
        dgvRecurringPaymentLineTable.Columns("FinanceCharge").HeaderText = "Finance Charge"
        dgvRecurringPaymentLineTable.Columns("FinanceCharge").DefaultCellStyle.Format = "C2"
        dgvRecurringPaymentLineTable.Columns("PaymentAmount").HeaderText = "Payment Amount"
        dgvRecurringPaymentLineTable.Columns("PaymentAmount").DefaultCellStyle.Format = "C2"
        dgvRecurringPaymentLineTable.Columns("NotificationNumber").Visible = False
        dgvRecurringPaymentLineTable.Columns("Printed").Visible = False
        ColorRows()
    End Sub

    Private Sub ColorRows()
        For i As Integer = 0 To dgvRecurringPaymentLineTable.Rows.Count - 1
            If dgvRecurringPaymentLineTable.Rows(i).Cells("Printed").Value.ToString.Equals("True") Then
                dgvRecurringPaymentLineTable.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
    End Sub

    Private Sub dgvRecurringPaymentLineTable_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvRecurringPaymentLineTable.Sorted
        ColorRows()
    End Sub

    Private Sub cmdPrintSelectedCoupons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintSelectedCoupons.Click
        If dgvRecurringPaymentLineTable.SelectedCells.Count > 0 Then
            Dim newPrintARRecurringPayments As New PrintRecurringPayment(dgvRecurringPaymentLineTable)
            newPrintARRecurringPayments.ShowDialog()
        Else
            MessageBox.Show("You must select a payment to print.", "Select a payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cmdUpdateSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSelected.Click
        If canUpdate() Then
            cmd = New SqlCommand("UPDATE NotificationTable SET EmployeeID = (SELECT EmployeID FROM EmployeData WHERE EmployeeFirst + ' ' + EmployeeLast = @EmployeeName) WHERE ", con)
            Dim lst As New List(Of Integer)
            For i As Integer = 0 To dgvRecurringPaymentLineTable.SelectedCells.Count - 1
                If Not lst.Contains(dgvRecurringPaymentLineTable.Rows(dgvRecurringPaymentLineTable.SelectedCells(i).RowIndex).Cells("NotificationNumber").Value) Then
                    lst.Add(dgvRecurringPaymentLineTable.Rows(dgvRecurringPaymentLineTable.SelectedCells(i).RowIndex).Cells("NotificationNumber").Value)
                End If
            Next
            For i As Integer = 0 To lst.Count - 1
                If i = 0 Then
                    cmd.CommandText += " NotificationKey = @NotificationKey" + i.ToString()
                Else
                    cmd.CommandText += " AND NotificationKey = @NotificationKey" + i.ToString()
                End If

                cmd.Parameters.Add("@NotificationKey" + i.ToString(), SqlDbType.Int).Value = lst(i)
            Next
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Notification(s) have been updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canUpdate()
        If String.IsNullOrEmpty(cboNotificationRecipient.Text) Then
            MessageBox.Show("You must select a recipient for the Notifications", "Select a notification recipient", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboNotificationRecipient.Focus()
            Return False
        End If
        If cboNotificationRecipient.SelectedIndex = -1 Then
            If Not cboNotificationRecipient.Items.Contains(cboNotificationRecipient.Text) Then
                MessageBox.Show("You must enter a valid recipient", "Enter a valid recipeint", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboNotificationRecipient.SelectAll()
                cboNotificationRecipient.Focus()
                Return False
            End If
        End If
        If dgvRecurringPaymentLineTable.SelectedCells.Count = 0 Then
            MessageBox.Show("You must select payments to change the notification recipient.", "Select payments", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Function GetCurrentUserName() As String
        cmd = New SqlCommand("SELECT EmployeeFirst + ' ' + EmployeeLast FROM EmployeeData WHERE LoginName = @LoginName", con)
        cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Dim employeeName As String = cmd.ExecuteScalar().ToString.ToUpper()
        con.Close()
        Return employeeName
    End Function

    Private Sub cmdOpenPaymentScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPaymentScreen.Click
        If dgvRecurringPaymentLineTable.SelectedCells.Count > 0 Then
            Dim newRecurringPayment As New ARRecurringPayment(dgvRecurringPaymentLineTable.Rows(dgvRecurringPaymentLineTable.SelectedCells(0).RowIndex).Cells("InvoiceNumber").Value)
            newRecurringPayment.Show()
            newRecurringPayment.Parent = Me.Parent
            Me.Close()
        Else
            MessageBox.Show("You must select a payment", "Select a payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvRecurringPaymentLineTable_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvRecurringPaymentLineTable.MouseDoubleClick
        If dgvRecurringPaymentLineTable.CurrentCell.RowIndex <> -1 And dgvRecurringPaymentLineTable.CurrentCell.ColumnIndex <> -1 Then
            If dgvRecurringPaymentLineTable.SelectedCells.Count > 0 Then
                Dim newPrintARRecurringPayments As New PrintRecurringPayment(dgvRecurringPaymentLineTable)
                newPrintARRecurringPayments.ShowDialog()
            Else
                MessageBox.Show("You must select a payment to print.", "Select a payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboInvoiceNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            cboInvoiceNumber.Text = ""
        End If
        cboCustomerID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cboCustomerID.Text = ""
        End If
        cboCustomerName.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        chkUseDates.Checked = False
        dtpStartDate.Value = Now
        dtpEndDate.Value = Now
       dgvRecurringPaymentLineTable.DataSource = Nothing

    End Sub

    Private Sub ViewARRecurringPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class