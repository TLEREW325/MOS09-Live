Imports System.Data.SqlClient

Public Class ARRecurringPayment
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False
    Dim InvoiceData As DataSet

    Public Sub New()
        InitializeComponent()

        LoadDivisionID()
        LoadNotificationRecipients()
        cboNotificationRecipient.Text = GetCurrentUserName()
        isLoaded = True
        cboDivisionID.Text = EmployeeCompanyCode
        If con.State = ConnectionState.Open Then con.Close()
        usefulFunctions.LoadSecurity(Me)
    End Sub

    Public Sub New(ByVal invoiceNumber As String)
        InitializeComponent()

        LoadDivisionID()
        If EmployeeSecurityCode > 1002 And Not EmployeeLoginName.Equals("JBASSETTI") And Not EmployeeLoginName.Equals("ALEHNER") Then
            cboDivisionID.Enabled = False
        End If
        LoadNotificationRecipients()
        cboNotificationRecipient.Text = GetCurrentUserName()
        isLoaded = True
        cboDivisionID.Text = EmployeeCompanyCode
        If con.State = ConnectionState.Open Then con.Close()
        cboInvoiceNumber.Text = invoiceNumber
    End Sub

    Private Sub LoadDivisionID()
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
    End Sub

    Private Sub LoadInvoiceNumbers()
        InvoiceData = New DataSet

        cmd = New SqlCommand("SELECT InvoiceNumber, InvoiceHeaderTable.CustomerID, CustomerName, InvoiceTotal, PaymentsApplied FROM InvoiceHeaderTable LEFT OUTER JOIN CustomerList ON InvoiceHeaderTable.CustomerID = CustomerList.CustomerID AND InvoiceHeaderTable.DivisionID = CustomerList.DivisionID WHERE InvoiceHeaderTable.DivisionID = @DivisionID ORDER BY InvoiceNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim tempadap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        tempadap.Fill(InvoiceData, "InvoiceHeaderTable")
        con.Close()

        cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        cboInvoiceNumber.DataSource = InvoiceData.Tables("InvoiceHeaderTable")
        cboInvoiceNumber.SelectedIndex = -1
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

    Private Function GetCurrentUserName() As String
        cmd = New SqlCommand("SELECT EmployeeFirst + ' ' + EmployeeLast FROM EmployeeData WHERE LoginName = @LoginName", con)
        cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Dim employeeName As String = cmd.ExecuteScalar().ToString.ToUpper()
        con.Close()
        Return employeeName
    End Function

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            cmdClear_Click(sender, e)
            isLoaded = False
            LoadInvoiceNumbers()
            isLoaded = True
        End If
    End Sub

    Private Sub cboInvoiceNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceNumber.SelectedIndexChanged
        If isLoaded Then
            If cboInvoiceNumber.SelectedIndex <> -1 Then
                lblCustomerID.Text = InvoiceData.Tables("InvoiceHeaderTable").Rows(cboInvoiceNumber.SelectedIndex).Item("CustomerID").ToString()
                lblCustomerName.Text = InvoiceData.Tables("InvoiceHeaderTable").Rows(cboInvoiceNumber.SelectedIndex).Item("CustomerName").ToString()
                lblInvoiceTotal.Text = FormatCurrency(InvoiceData.Tables("InvoiceHeaderTable").Rows(cboInvoiceNumber.SelectedIndex).Item("InvoiceTotal"))
                lblPaymentsApplied.Text = FormatCurrency(InvoiceData.Tables("InvoiceHeaderTable").Rows(cboInvoiceNumber.SelectedIndex).Item("PaymentsApplied"))

                cmd = New SqlCommand("SELECT InvoiceLineKey as [Line Number], PartNumber as [Part Number], PartDescription as [Part Description], QuantityBilled as [Quantity Billed], Price, LineComment as [Line Comment], ExtendedAmount as [Extended Amount] FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.Int).Value = Val(cboInvoiceNumber.Text)
                Dim tempds As New DataSet
                Dim tempAdap As New SqlDataAdapter(cmd)
                If con.State = ConnectionState.Closed Then con.Open()
                tempAdap.Fill(tempds, "InvoiceLineTable")
                cmd.CommandText = "SELECT isnull(Percentage, 'True') as Percentage, isnull(PaymentMonths, 1) as PaymentMonths, isnull(BaseFinanceCharge,0) as BaseFinanceCharge, NotificationRecipient, NotificationLeadTime FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = Val(cboInvoiceNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Dim percentage As Boolean = True
                Dim PaymentMonths As Integer = 1
                Dim BaseFinancingCharge As Double = 0.2
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    percentage = Convert.ToBoolean(reader.Item("Percentage"))
                    PaymentMonths = reader.Item("PaymentMonths")
                    BaseFinancingCharge = reader.Item("BaseFinanceCharge")
                    cboNotificationRecipient.Text = reader.Item("NotificationRecipient")
                    txtNotificationLeadTime.Text = reader.Item("NotificationLeadTime")
                Else
                    reader.Close()
                    cboNotificationRecipient.Text = GetCurrentUserName()
                    txtNotificationLeadTime.Text = "3"
                End If
                If Not reader.IsClosed Then reader.Close()
                LoadRecurringPaymentLines()
                con.Close()
                If percentage Then
                    chkPercent.Checked = True
                Else
                    chkFlatFee.Checked = True
                End If
                txtPaymentMonths.Text = PaymentMonths.ToString()
                txtPaymentInterest.Text = BaseFinancingCharge.ToString()
                dgvInvoiceLines.DataSource = tempds.Tables("InvoiceLineTable")
                UpdatePaymentTotals()
            Else
                lblCustomerID.Text = ""
                lblCustomerName.Text = ""
                lblInvoiceTotal.Text = ""
                lblPaymentsApplied.Text = ""
                txtNotificationLeadTime.Text = "3"
                dgvInvoiceLines.DataSource = Nothing
                cboNotificationRecipient.SelectedIndex = -1
                If Not String.IsNullOrEmpty(cboNotificationRecipient.Text) Then
                    cboNotificationRecipient.Text = ""
                End If
            End If
            UpdateButtonState()
        End If
    End Sub

    Private Sub UpdateButtonState()
        ''changes the state of the add / update payment button
        If Not String.IsNullOrEmpty(lblRemainingTotal.Text) Then
            If Val(lblRemainingTotal.Text.Replace("$", "").Replace(",", "")) > 0 Then
                If dgvPayments.Rows.Count = 0 Then
                    cmdGenerateRecurringPayments.Text = "Add Payments"
                Else
                    cmdGenerateRecurringPayments.Text = "Update Payments"
                End If
                cmdGenerateRecurringPayments.Enabled = True
            Else
                If dgvPayments.Rows.Count = 0 Then
                    cmdGenerateRecurringPayments.Text = "Add Payments"
                    cmdGenerateRecurringPayments.Enabled = False
                Else
                    cmdGenerateRecurringPayments.Text = "Update Payments"
                    cmdGenerateRecurringPayments.Enabled = True
                End If
            End If
        Else
            cmdGenerateRecurringPayments.Text = "Add Payments"
            cmdGenerateRecurringPayments.Enabled = False
        End If
        ''changes the state of the print and delete buttons
        If dgvPayments.Rows.Count > 0 Then
            cmdPrintAllPaymentCoupons.Enabled = True
            cmdPrintPaymentCoupon.Enabled = True
            cmdDeleteSelected.Enabled = True
        Else
            cmdPrintAllPaymentCoupons.Enabled = False
            cmdPrintPaymentCoupon.Enabled = False
            cmdDeleteSelected.Enabled = False
        End If
    End Sub

    Private Sub LoadRecurringPaymentLines()
        cmd = New SqlCommand("SELECT LineNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, Cast(NotificationDateTime as date) as NotificationDate, Cast(NotificationDateTime as time(7)) as NotificationTime, NotificationNumber, Printed FROM RecurringPaymentLineTable LEFT OUTER JOIN NotificationTable ON RecurringPaymentLineTable.NotificationNumber = NotificationTable.NotificationKey WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) ORDER BY LineNumber", con)
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = Val(cboInvoiceNumber.Text)

        Dim tempds As New DataSet()
        Dim tempAdap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        tempAdap.Fill(tempds, "RecurringPaymentLineTable")
        cmd.CommandText = "SELECT Percentage FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
        Dim lockInterest As Object = cmd.ExecuteScalar()
        con.Close()

        isLoaded = False
        dgvPayments.DataSource = tempds.Tables("RecurringPaymentLineTable")

        dgvPayments.Columns("Printed").Visible = False
        dgvPayments.Columns("NotificationNumber").Visible = False
        dgvPayments.Columns("LineNumber").ReadOnly = True
        dgvPayments.Columns("LineNumber").HeaderText = "Line Number"
        dgvPayments.Columns("BaseAmount").DefaultCellStyle.Format = "C2"
        dgvPayments.Columns("BaseAmount").HeaderText = "Principle Amount"
        dgvPayments.Columns("FinanceCharge").DefaultCellStyle.Format = "C2"
        dgvPayments.Columns("FinanceCharge").HeaderText = "Interest Amount"
        dgvPayments.Columns("PaymentAmount").DefaultCellStyle.Format = "C2"
        dgvPayments.Columns("PaymentAmount").HeaderText = "Total Payment Amount"
        dgvPayments.Columns("PaymentAmount").ReadOnly = True
        dgvPayments.Columns("NotificationDate").ReadOnly = True
        dgvPayments.Columns("NotificationDate").HeaderText = "Notification Date"
        dgvPayments.Columns("NotificationTime").ReadOnly = True
        dgvPayments.Columns("NotificationTime").HeaderText = "Notification Time"

        If Not IsDBNull(lockInterest) Then
            If lockInterest IsNot Nothing Then
                dgvPayments.Columns("FinanceCharge").ReadOnly = Convert.ToBoolean(lockInterest)
            Else
                dgvPayments.Columns("FinanceCharge").ReadOnly = False
            End If
        Else
            dgvPayments.Columns("FinanceCharge").ReadOnly = False
        End If
        FormatPaymentRows()
        isLoaded = True
    End Sub

    Private Sub FormatPaymentRows()
        For i As Integer = 0 To dgvPayments.Rows.Count - 1
            If dgvPayments.Rows(i).Cells("Printed").Value.Equals("True") Then
                dgvPayments.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
    End Sub

    Private Sub lblPaymentsApplied_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPaymentsApplied.TextChanged
        If Not String.IsNullOrEmpty(lblInvoiceTotal.Text) Then
            lblRemainingTotal.Text = FormatCurrency(Val(lblInvoiceTotal.Text.Replace(",", "").Replace("$", "")) - Val(lblPaymentsApplied.Text.Replace(",", "").Replace("$", "")))
        Else
            lblRemainingTotal.Text = FormatCurrency(0)
        End If
    End Sub

    Private Sub lblInvoiceTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblInvoiceTotal.TextChanged
        If Not String.IsNullOrEmpty(lblPaymentsApplied.Text) Then
            lblRemainingTotal.Text = FormatCurrency(Val(lblInvoiceTotal.Text.Replace(",", "").Replace("$", "")) - Val(lblPaymentsApplied.Text.Replace(",", "").Replace("$", "")))
        Else
            lblRemainingTotal.Text = lblInvoiceTotal.Text
        End If
    End Sub

    Private Sub txtPaymentMonths_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaymentMonths.TextChanged
        UpdatePaymentTotals()
    End Sub

    Private Sub txtPaymentMonths_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaymentMonths.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub UpdatePaymentTotals()
        If isLoaded Then
            If Not String.IsNullOrEmpty(lblRemainingTotal.Text) Then
                Dim CalculatedInterest As Double = 0
                If Not String.IsNullOrEmpty(txtPaymentInterest.Text) Then

                    If chkFlatFee.Checked Then
                        lblTotalMonthlyPayment.Text = FormatCurrency((Val(lblRemainingTotal.Text.Replace(",", "").Replace("$", "")) / Val(txtPaymentMonths.Text)) + Val(txtPaymentInterest.Text))
                        CalculatedInterest = Val(txtPaymentInterest.Text)
                    Else
                        CalculatedInterest = Math.Round(Val(lblRemainingTotal.Text.Replace(",", "").Replace("$", "")) * (Val(txtPaymentInterest.Text) / 12), 2, MidpointRounding.AwayFromZero)
                        Dim rPV As Double = (Val(txtPaymentInterest.Text) / 12) * Val(lblRemainingTotal.Text.Replace(",", "").Replace("$", ""))
                        Dim bottom As Double = 1 - Math.Pow(1 + (Val(txtPaymentInterest.Text) / 12), -1 * Val(txtPaymentMonths.Text))
                        lblTotalMonthlyPayment.Text = FormatCurrency(((Val(txtPaymentInterest.Text) / 12) * Val(lblRemainingTotal.Text.Replace(",", "").Replace("$", ""))) / (1 - Math.Pow(1 + (Val(txtPaymentInterest.Text) / 12), (-1 * Val(txtPaymentMonths.Text)))))
                    End If
                Else
                    lblTotalMonthlyPayment.Text = FormatCurrency(Val(lblRemainingTotal.Text.Replace(",", "").Replace("$", "")) - CalculatedInterest)
                End If
                lblMonthlyPayment.Text = FormatCurrency(Val(lblTotalMonthlyPayment.Text.Replace(",", "").Replace("$", "")) - CalculatedInterest)
            Else
                lblMonthlyPayment.Text = FormatCurrency(0)
                lblTotalMonthlyPayment.Text = FormatCurrency(0)
            End If
        End If
    End Sub

    Private Sub txtPaymentInterest_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaymentInterest.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "."c And Not e.KeyChar = vbBack Then
            e.KeyChar = Nothing
        ElseIf e.KeyChar = "."c And (txtPaymentInterest.Text.Length = 0 Or txtPaymentInterest.Text.Length = txtPaymentInterest.SelectionLength) Then
            txtPaymentInterest.Text = "0."
            txtPaymentInterest.SelectionStart = txtPaymentInterest.Text.Length
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub chkPercent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPercent.CheckedChanged
        If chkPercent.Checked Then
            chkFlatFee.Checked = False
            UpdatePaymentTotals()
        End If
    End Sub

    Private Sub chkFlatFee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFlatFee.CheckedChanged
        If chkFlatFee.Checked Then
            chkPercent.Checked = False
            UpdatePaymentTotals()
        End If
    End Sub

    Private Sub cmdGenerateRecurringPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateRecurringPayments.Click
        If canAddPayments() Then

            cmd = New SqlCommand("IF EXISTS (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID)" _
                                 + " UPDATE RecurringPaymentHeaderTable SET Percentage = @Percentage, PaymentMonths = @PaymentMonths, BaseFinanceCharge = @BaseFinanceCharge, NotificationRecipient = @NotificationRecipient, NotificationLeadTime = @NotificationLeadTime WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID" _
                                 + " ELSE INSERT INTO RecurringPaymentHeaderTable (RecurringPaymentNumber, DivisionID, InvoiceNumber, Percentage, PaymentMonths, BaseFinanceCharge, NotificationRecipient, NotificationLeadTime, UserID)" _
                                 + " VALUES ((SELECT isnull(MAX(RecurringPaymentNumber) + 1, 1) FROM RecurringPaymentHeaderTable), @DivisionID, @InvoiceNumber, @Percentage, @PaymentMonths, @BaseFinanceCharge, @NotificationRecipient, @NotificationLeadTime, @UserID);" _
                                 + " SELECT isnull(COUNT(LineNumber),0) FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = " _
                                 + " CASE WHEN EXISTS(SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID)" _
                                 + " THEN (SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID)" _
                                 + " ELSE (SELECT 0) END", con)
            cmd.Parameters.Add("@Percentage", SqlDbType.VarChar).Value = chkPercent.Checked.ToString()
            cmd.Parameters.Add("@PaymentMonths", SqlDbType.VarChar).Value = Val(txtPaymentMonths.Text)
            cmd.Parameters.Add("@BaseFinanceCharge", SqlDbType.VarChar).Value = Val(txtPaymentInterest.Text)
            cmd.Parameters.Add("@NotificationRecipient", SqlDbType.VarChar).Value = cboNotificationRecipient.Text
            cmd.Parameters.Add("@NotificationLeadTime", SqlDbType.VarChar).Value = Val(txtNotificationLeadTime.Text)
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName

            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            Dim Cnt As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            If Cnt <> 0 Then
                cmd.CommandText = "SELECT isnull(COUNT(LineNumber),0) FROM RecurringPaymentLineTable WHERE Printed = 'True' AND RecurringPaymentNumber = CASE WHEN EXISTS(SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) THEN (SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) ELSE (SELECT 0) END"
                If con.State = ConnectionState.Closed Then con.Open()
                Cnt = Convert.ToInt32(cmd.ExecuteScalar())
                If Cnt > 0 Then
                    MessageBox.Show("There have already been payment coupons printed. Update will only update notification recipient.", "Update warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    cmd.CommandText = "UPDATE NotificationTable SET EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst + ' ' + EmployeeLast = @User) WHERE NotificationKey in (SELECT NotificationNumber FROM RecurringPaymentLineTable WHERE Printed = 'False' AND RecurringPaymentNumber = CASE WHEN EXISTS(SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) THEN (SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) ELSE (SELECT 0) END)"
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    cmd.CommandText = "DELETE NotificationTable WHERE NotificationKey in (SELECT NotificationNumber FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = CASE WHEN EXISTS(SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) THEN (SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) ELSE (SELECT 0) END);"
                    cmd.CommandText += " DELETE RecurringPaymentLineTable WHERE RecurringPaymentNumber = CASE WHEN EXISTS(SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) THEN (SELECT isnull(RecurringPaymentNumber, 0) FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber and DivisionID = @DivisionID) ELSE (SELECT 0) END;"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    AddEntries()
                End If
            Else
                AddEntries()
            End If

            LoadRecurringPaymentLines()
            If con.State = ConnectionState.Open Then con.Close()
            UpdateButtonState()
        End If
    End Sub

    Private Function canAddPayments() As Boolean
        If String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            MessageBox.Show("You must select an invoice number", "Select an invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.Focus()
            Return False
        End If
        If cboInvoiceNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid invoice number", "Enter a vlaid invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.SelectAll()
            cboInvoiceNumber.Focus()
            Return False
        End If
        If Val(lblRemainingTotal.Text.Replace("$", "").Replace(",", "")) <= 0 Then
            MessageBox.Show("You can't add payments on invoices with $0.00 or less remaining", "Unable to add payments", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtPaymentMonths.Text) Then
            MessageBox.Show("You must enter a number of months", "Enter a number of months", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPaymentMonths.Focus()
            Return False
        End If
        If Not IsNumeric(txtPaymentMonths.Text) Then
            MessageBox.Show("You must enter a number for payment months", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPaymentMonths.SelectAll()
            txtPaymentMonths.Focus()
            Return False
        End If
        If Val(txtPaymentMonths.Text) = 0 Then
            MessageBox.Show("Payment months must be greater than zero.", "Invalid payment months", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPaymentMonths.SelectAll()
            txtPaymentMonths.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPaymentInterest.Text) Then
            MessageBox.Show("You must enter an interest amount. If there is no interest you must enter 0.", "Enter an interest amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPaymentInterest.Focus()
            Return False
        End If
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
        Return True
    End Function

    Private Sub AddEntries()
        ''calculates the Finance charge, if needed
        Dim FinanceCharge As Double = 0D
        If chkFlatFee.Checked Then
            FinanceCharge = Math.Round(Val(txtPaymentInterest.Text), 2, MidpointRounding.AwayFromZero)
        Else
            FinanceCharge = Val(txtPaymentInterest.Text)
        End If
        ''Line declares the recurring payment number if it exists else sets it to max + 1 of the recurring payment numbers
        ''Gets the next GroupID and EmployeeID
        cmd = New SqlCommand("DECLARE @RecurringPaymentNumber as int = (Case WHEN EXISTS(SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) Then (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) ELSE (SELECT isnull(MAX(RecurringPaymentNumber) + 1, 1) FROM RecurringPaymentHeaderTable) END), @GroupID as int = (SELECT ISNULL(MAX(GroupID) + 1, 1) FROM NotificationTable), @EmployeeID as varchar(20) = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst + ' ' + EmployeeLast = @User), @CustomerID as varchar(50) = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber);", con)
        ''
        ''Adds the recurring payment header entry if it doesn't already exist
        cmd.CommandText += "  IF NOT EXISTS(SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber) INSERT INTO RecurringPaymentHeaderTable (RecurringPaymentNumber, DivisionID, InvoiceNumber, Percentage, BaseFinanceCharge, PaymentMonths, NotificationRecipient, NotificationLeadTime, UserID) VALUES (@RecurringPaymentNumber, @DivisionID, @InvoiceNumber, @Percentage, @BaseFinanceCharge, @PaymentMonths, @NotificationRecipient, @NotificationLeadTime, @UserID);"
        If chkPercent.Checked Then
            cmd.Parameters.Add("@Percentage", SqlDbType.VarChar).Value = "True"
        Else
            cmd.Parameters.Add("@Percentage", SqlDbType.VarChar).Value = "False"
        End If
        cmd.Parameters.Add("@BaseFinanceCharge", SqlDbType.VarChar).Value = Val(txtPaymentInterest.Text)
        cmd.Parameters.Add("@PaymentMonths", SqlDbType.VarChar).Value = Val(txtPaymentMonths.Text)
        cmd.Parameters.Add("@NotificationRecipient", SqlDbType.VarChar).Value = cboNotificationRecipient.Text
        cmd.Parameters.Add("@NotificationLeadTime", SqlDbType.VarChar).Value = Val(txtNotificationLeadTime.Text)
        cmd.CommandText += " DECLARE @MaxNotificationNumber as int = (SELECT isnull(MAX(NotificationKey)+1, 1) FROM NotificationTable); INSERT INTO NotificationTable (NotificationKey, DivisionID, EmployeeID, NotificationType, ReferenceNumber, Frequency, NotificationDateTime, Details, Status, AddedBy, GroupID, SnoozeTime) VALUES "
        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            .Add("@User", SqlDbType.VarChar).Value = cboNotificationRecipient.Text
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
        End With
        Dim RemainingPrincipal As Double = Val(lblRemainingTotal.Text.Replace(",", "").Replace("$", ""))
        Dim LineTableEntries As String = "  INSERT INTO RecurringPaymentLineTable (RecurringPaymentNumber, LineNumber, PaymentDate, BaseAmount, FinanceCharge, PaymentAmount, NotificationNumber, Printed) VALUES "
        For i As Integer = 0 To Val(txtPaymentMonths.Text) - 1
            Dim CalculatedInterest As Double = 0
            If chkFlatFee.Checked Then
                CalculatedInterest = Math.Round(FinanceCharge, 2, MidpointRounding.AwayFromZero)
            Else
                ''compounding interest monthly
                CalculatedInterest = Math.Round(RemainingPrincipal * (FinanceCharge / 12), 2, MidpointRounding.AwayFromZero)
            End If
            If i = 0 Then
                cmd.CommandText += " (@MaxNotificationNumber + " + i.ToString() + ", @DivisionID, @EmployeeID, 'Invoice Payment', @InvoiceNumber, 'Only Once', @NotificationDateTime" + i.ToString() + ", @CustomerID + ' ' + CONVERT(VARCHAR(10), @NotificationDateTime" + i.ToString() + ", 101) + ' Payment' + CHAR(13) + @Details" + i.ToString() + ", 'ACTIVE', @UserID, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                LineTableEntries += " (@RecurringPaymentNumber, " + i.ToString() + " + 1, @PaymentDate" + i.ToString() + ", @BaseAmount" + i.ToString() + ", @FinanceCharge" + i.ToString() + ", @PaymentAmount" + i.ToString() + ", @MaxNotificationNumber + " + i.ToString() + ", 'False')"
            Else
                cmd.CommandText += ", (@MaxNotificationNumber + " + i.ToString() + ", @DivisionID, @EmployeeID, 'Invoice Payment', @InvoiceNumber, 'Only Once', @NotificationDateTime" + i.ToString() + ", @CustomerID + ' ' + CONVERT(VARCHAR(10), @NotificationDateTime" + i.ToString() + ", 101) + ' Payment' + CHAR(13) + @Details" + i.ToString() + ", 'ACTIVE', @UserID, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                LineTableEntries += ", (@RecurringPaymentNumber, " + i.ToString() + " + 1, @PaymentDate" + i.ToString() + ", @BaseAmount" + i.ToString() + ", @FinanceCharge" + i.ToString() + ", @PaymentAmount" + i.ToString() + ", @MaxNotificationNumber + " + i.ToString() + ", 'False')"
            End If
            Dim NewNotificationDate As DateTime = dtpStartDate.Value.AddMonths(i).AddDays(-1 * Val(txtNotificationLeadTime.Text))

            With cmd.Parameters
                .Add("@PaymentDate" + i.ToString(), SqlDbType.VarChar).Value = dtpStartDate.Value.AddMonths(i)
                .Add("@NotificationDateTime" + i.ToString(), SqlDbType.VarChar).Value = New DateTime(NewNotificationDate.Year, NewNotificationDate.Month, NewNotificationDate.Day, 8, 0, 0)
                .Add("@BaseAmount" + i.ToString(), SqlDbType.VarChar).Value = Val(lblTotalMonthlyPayment.Text.Replace(",", "").Replace("$", "")) - CalculatedInterest
                .Add("@FinanceCharge" + i.ToString(), SqlDbType.VarChar).Value = CalculatedInterest
                .Add("@PaymentAmount" + i.ToString(), SqlDbType.VarChar).Value = Val(lblTotalMonthlyPayment.Text.Replace(",", "").Replace("$", ""))
                .Add("@Details" + i.ToString(), SqlDbType.VarChar).Value = "Base Amount: " + FormatCurrency(Val(lblTotalMonthlyPayment.Text.Replace(",", "").Replace("$", "")) - CalculatedInterest) + Environment.NewLine + "Finance Charge: " + FormatCurrency(CalculatedInterest) + Environment.NewLine + "Total Amount: " + lblTotalMonthlyPayment.Text
            End With
            RemainingPrincipal -= Val(lblTotalMonthlyPayment.Text.Replace(",", "").Replace("$", "")) - CalculatedInterest
        Next
        cmd.CommandText += LineTableEntries

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub dgvPayments_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvPayments.Sorted
        If dgvPayments.Rows.Count > 0 Then
            FormatPaymentRows()
        End If
    End Sub

    Private Sub txtPaymentInterest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaymentInterest.TextChanged
        UpdatePaymentTotals()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isLoaded = False
        cboInvoiceNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            cboInvoiceNumber.Text = ""
        End If
        cboDivisionID.Text = EmployeeCompanyCode
        lblCustomerID.Text = ""
        lblCustomerName.Text = ""
        lblInvoiceTotal.Text = ""
        lblPaymentsApplied.Text = ""
        dgvInvoiceLines.DataSource = Nothing
        txtPaymentInterest.Clear()
        txtPaymentMonths.Clear()
        lblMonthlyPayment.Text = ""
        lblTotalMonthlyPayment.Text = ""
        lblRemainingTotal.Text = ""
        txtNotificationLeadTime.Text = "3"
        dgvPayments.DataSource = Nothing
        isLoaded = True
        cboNotificationRecipient.Text = GetCurrentUserName()
        UpdateButtonState()
    End Sub

    Private Sub cmdDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelected.Click
        If canDelete() Then
            Dim lst As New List(Of Integer)
            For i As Integer = 0 To dgvPayments.SelectedCells.Count - 1
                If Not lst.Contains(dgvPayments.Rows(dgvPayments.SelectedCells(i).RowIndex).Cells("LineNumber").Value) And dgvPayments.Rows(dgvPayments.SelectedCells(i).RowIndex).Cells("Printed").Value.ToString.Equals("False") Then
                    lst.Add(dgvPayments.Rows(dgvPayments.SelectedCells(i).RowIndex).Cells("LineNumber").Value)
                End If
            Next
            ''Deletes the notification and the payment line
            cmd = New SqlCommand("DELETE NotificationTable WHERE NotificationKey = (SELECT NotificationNumber FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) AND LineNumber = @LineNumber); DELETE RecurringPaymentLineTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) AND LineNumber = @LineNumber", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = Val(cboInvoiceNumber.Text)
            cmd.Parameters.Add("@LineNumber", SqlDbType.Int)
            For i As Integer = 0 To lst.Count - 1
                cmd.Parameters("@LineNumber").Value = lst(i)
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Next
            ''gets the line numbers of the lines left
            cmd.CommandText = "SELECT LineNumber FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) ORDER BY LineNumber"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim OldNew As New List(Of Integer)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    OldNew.Add(reader.Item("LineNumber"))
                End While
            End If
            reader.Close()
            ''updates the numbers of the lines left
            cmd.CommandText = "UPDATE RecurringPaymentLineTable SET LineNumber = @NewLineNumber WHERE LineNumber = @OldLineNumber AND RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber)"
            cmd.Parameters.Add("@OldLineNumber", SqlDbType.Int)
            cmd.Parameters.Add("@NewLineNumber", SqlDbType.Int)
            Dim cnt As Integer = 1
            While cnt <= OldNew.Count
                cmd.Parameters("@OldLineNumber").Value = OldNew(cnt - 1)
                cmd.Parameters("@NewLineNumber").Value = cnt
                cmd.ExecuteNonQuery()
                cnt += 1
            End While
            LoadRecurringPaymentLines()
            If con.State = ConnectionState.Open Then con.Close()
            UpdateButtonState()
        End If
    End Sub

    Private Function canDelete()
        If dgvPayments.Rows.Count = 0 Then
            MessageBox.Show("There are no payments to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvPayments.SelectedCells.Count < 1 Then
            MessageBox.Show("There are no payments selected to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to delete payment?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        isLoaded = False
        Me.Close()
    End Sub

    Private Sub dgvPayments_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayments.CellValueChanged
        If isLoaded Then
            Select Case dgvPayments.Columns(e.ColumnIndex).Name
                Case "BaseAmount"
                    ''updates base amount & payment amount, then rewrites the details section in notifications
                    cmd = New SqlCommand("DECLARE @BaseFinanceCharge as float = (SELECT BaseFinanceCharge FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID), @CustomerID as varchar(50) = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber), @RecurringPaymentNumber as int = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID); DECLARE @NewfinanceCharge as float = ROUND(@BaseFinanceCharge * @BaseAmount, 2), @TotalMonthlyAmount as float = (SELECT PaymentAmount FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber AND LineNumber = @LineNumber);", con)
                    ''if the finance charge is a percent this will adjust the Line table entry base amount and update the notification
                    cmd.CommandText += " IF (SELECT Percentage FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) = 'True' BEGIN UPDATE NotificationTable SET Details = @CustomerID + ' ' + CONVERT(VARCHAR(10), @PaymentDate, 101) + ' Payment' + CHAR(13) + 'Base Amount: ' + Cast(@BaseAmount as varchar) + CHAR(13) + 'Interest Amount: ' + CAST((@TotalMonthlyAmount - @BaseAmount) as varchar) + CHAR(13) + 'Monthly Amount: ' + CAST(@TotalMonthlyAmount as varchar) WHERE NotificationKey = @NotificationNumber; UPDATE RecurringPaymentLineTable SET BaseAmount = @BaseAmount, FinanceCharge = (@TotalMonthlyAmount - @BaseAmount) WHERE RecurringPaymentNumber = @RecurringPaymentNumber AND LineNumber = @LineNumber; SET @NewFinanceCharge = @TotalMonthlyAmount - @BaseAmount; END"
                    ''If the finance charge was a flat rate this will adjust the total and base amount
                    cmd.CommandText += " ELSE BEGIN UPDATE NotificationTable SET Details = @CustomerID + ' ' + CONVERT(VARCHAR(10), @PaymentDate, 101) + ' Payment' + CHAR(13) + 'Base Amount: ' + Cast(@BaseAmount as varchar) + CHAR(13) + 'Finance Charge: ' + CAST(@BaseFinanceCharge as varchar) + CHAR(13) + 'Monthly Amount: ' + CAST((@BaseAmount + @BaseFinanceCharge) as varchar) WHERE NotificationKey = @NotificationNumber; UPDATE RecurringPaymentLineTable SET BaseAmount = @BaseAmount, FinanceCharge = @BaseFinanceCharge, PaymentAmount = (@BaseAmount + @BaseFinanceCharge) WHERE RecurringPaymentNumber = @RecurringPaymentnumber AND LineNumber = @LineNumber; SET @NewfinanceCharge = @BaseFinanceCharge; END SELECT @NewfinanceCharge;"
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@BaseAmount", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("BaseAmount").Value.ToString.Replace(",", "").Replace("$", "")
                    cmd.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("PaymentDate").Value
                    cmd.Parameters.Add("@NotificationNumber", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("NotificationNumber").Value
                    cmd.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("LineNumber").Value

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim FinanceCharge As Double = cmd.ExecuteScalar()
                    isLoaded = False
                    If Val(dgvPayments.Rows(e.RowIndex).Cells("FinanceCharge").Value.ToString.Replace(",", "").Replace("$", "")) <> FinanceCharge Then
                        dgvPayments.Rows(e.RowIndex).Cells("FinanceCharge").Value = FinanceCharge
                    End If

                    isLoaded = True
                Case "FinanceCharge"
                    ''updates finance charge & payment amount, then rewrites the details section in notifications
                    cmd = New SqlCommand("DECLARE @CustomerID as varchar(50) = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber); UPDATE NotificationTable SET Details = @CustomerID + ' ' + CONVERT(VARCHAR(10), @PaymentDate, 101) + ' Payment' + CHAR(13) + 'Base Amount: ' + Cast(@BaseAmount as varchar) + CHAR(13) + 'Interest Amount: ' + CAST(@FinanceCharge as varchar) + CHAR(13) + 'Monthly Amount: ' + CAST((@BaseAmount + @FinanceCharge) as varchar) WHERE NotificationKey = @NotificationNumber; UPDATE RecurringPaymentLineTable SET FinanceCharge = @FinanceCharge, PaymentAmount = (BaseAmount + @FinanceCharge) WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) AND LineNumber = @LineNumber;", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    cmd.Parameters.Add("@BaseAmount", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("BaseAmount").Value.ToString.Replace(",", "").Replace("$", "")
                    cmd.Parameters.Add("@FinanceCharge", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("FinanceCharge").Value.ToString.Replace(",", "").Replace("$", "")
                    cmd.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("PaymentDate").Value
                    cmd.Parameters.Add("@NotificationNumber", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("NotificationNumber").Value
                    cmd.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = dgvPayments.Rows(e.RowIndex).Cells("LineNumber").Value

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    isLoaded = False
                    dgvPayments.Rows(e.RowIndex).Cells("PaymentAmount").Value = Val(dgvPayments.Rows(e.RowIndex).Cells("BaseAmount").Value.ToString.Replace(",", "").Replace("$", "")) + Val(dgvPayments.Rows(e.RowIndex).Cells("FinanceCharge").Value.ToString.Replace(",", "").Replace("$", ""))
                    isLoaded = True
            End Select
        End If
    End Sub

    Private Sub cmdPrintAllPaymentCoupons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAllPaymentCoupons.Click
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            Dim newPrintRecurringPayment As New PrintRecurringPayment(Val(cboInvoiceNumber.Text))
            newPrintRecurringPayment.ShowDialog()
        Else
            MessageBox.Show("You must select an invoice number", "Select an invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cmdPrintPaymentCoupon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPaymentCoupon.Click
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) And dgvPayments.SelectedCells.Count > 0 Then
            Dim lst As New List(Of Integer)
            For i As Integer = 0 To dgvPayments.SelectedCells.Count - 1
                If Not lst.Contains(dgvPayments.Rows(dgvPayments.SelectedCells(i).RowIndex).Cells("LineNumber").Value) Then
                    lst.Add(dgvPayments.Rows(dgvPayments.SelectedCells(i).RowIndex).Cells("LineNumber").Value)
                End If
            Next
            Dim newPrintRecurringPayment As New PrintRecurringPayment(Val(cboInvoiceNumber.Text), lst.ToArray())
            newPrintRecurringPayment.ShowDialog()
        Else
            MessageBox.Show("You must select payment", "Select a payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub pnlNewDateTime_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlNewDateTime.Leave
        pnlNewDateTime.Hide()
        Dim testDate As String = dgvPayments.Rows(lblRowNumber.Text).Cells("NotificationDate").Value.ToString().Substring(0, dgvPayments.Rows(lblRowNumber.Text).Cells("NotificationDate").Value.ToString().IndexOf(" "))
        Dim dtpDate As String = dtpNotificationDate.Text
        Dim testTime As String = dgvPayments.Rows(lblRowNumber.Text).Cells("NotificationTime").Value.ToString()
        Dim dtpTime As String = dtpNotificationTime.Text.Substring(0, dtpNotificationTime.Text.IndexOf(" "))
        If dtpTime.IndexOf(":") <> 2 Then
            dtpTime = "0" + dtpTime
        End If
        If (testDate <> dtpDate) Or (testTime <> dtpTime) Then
            cmd = New SqlCommand("UPDATE NotificationTable SET NotificationDateTime = @NotificationDateTime WHERE NotificationKey = @NotificationNumber", con)
            cmd.Parameters.Add("@NotificationNumber", SqlDbType.VarChar).Value = dgvPayments.Rows(lblRowNumber.Text).Cells("NotificationNumber").Value
            cmd.Parameters.Add("@NotificationDateTime", SqlDbType.VarChar).Value = New DateTime(dtpNotificationDate.Value.Year, dtpNotificationDate.Value.Month, dtpNotificationDate.Value.Day, dtpNotificationTime.Value.Hour, dtpNotificationTime.Value.Minute, dtpNotificationTime.Value.Second)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            isLoaded = False
            dgvPayments.Rows(lblRowNumber.Text).Cells("NotificationDate").Value = dtpNotificationDate.Value
            dgvPayments.Rows(lblRowNumber.Text).Cells("NotificationTime").Value = dtpTime
            isLoaded = True
        End If

    End Sub

    Private Sub pnlNewDateTime_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlNewDateTime.Enter
        lblRowNumber.Text = dgvPayments.CurrentCell.RowIndex.ToString()
        dtpNotificationDate.Text = dgvPayments.Rows(dgvPayments.CurrentCell.RowIndex).Cells("NotificationDate").Value.ToString()
        dtpNotificationTime.Text = dgvPayments.Rows(dgvPayments.CurrentCell.RowIndex).Cells("NotificationTime").Value.ToString()

    End Sub

    Private Sub dgvPayments_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPayments.MouseUp
        Dim ht As DataGridView.HitTestInfo = dgvPayments.HitTest(e.X, e.Y)
        ''check to make sure we hit a cell
        If ht.Type = DataGridViewHitTestType.Cell Then
            ''check to see if that cell is the date or time cell for Notifications
            If dgvPayments.Columns(ht.ColumnIndex).Name.Equals("NotificationDate") Or dgvPayments.Columns(ht.ColumnIndex).Name.Equals("NotificationTime") Then
                Dim pnlXPos As Double = 0
                ''check to see if it was the date cell if so will change the x position variable accordingly
                If dgvPayments.Columns(ht.ColumnIndex).Name.Equals("NotificationDate") Then
                    pnlXPos = dgvPayments.Location.X + ht.ColumnX - (pnlNewDateTime.Width / 2)
                Else
                    pnlXPos = dgvPayments.Location.X + ht.ColumnX - pnlNewDateTime.Width
                End If
                ''check to see if the position of the panel plus the height wil lgo below the DGV, if so will position above the cell not below
                If dgvPayments.Location.Y + ht.RowY + dgvPayments.Rows(ht.RowIndex).Height + pnlNewDateTime.Height > dgvPayments.Location.Y + dgvPayments.Height Then
                    pnlNewDateTime.Location = New System.Drawing.Point(pnlXPos, dgvPayments.Location.Y + ht.RowY - pnlNewDateTime.Height)
                Else
                    pnlNewDateTime.Location = New System.Drawing.Point(pnlXPos, dgvPayments.Location.Y + ht.RowY + dgvPayments.Rows(ht.RowIndex).Height)
                End If
                ''makes sure that the current cell is the cell that was hit
                dgvPayments.CurrentCell = dgvPayments.Rows(ht.RowIndex).Cells(ht.ColumnIndex)
                pnlNewDateTime.Show()
                pnlNewDateTime.Focus()
            End If
        End If
    End Sub

    Private Sub txtNotificationLeadTime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNotificationLeadTime.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub ARRecurringPayment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        isLoaded = False
    End Sub

    Private Sub lblRemainingTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lblRemainingTotal.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
            Case Keys.Decimal, Keys.OemPeriod
                If Not lblRemainingTotal.Text.Contains(".") Then
                    controlKey = True
                End If
        End Select
    End Sub

    Private Sub lblRemainingTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lblRemainingTotal.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub ARRecurringPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class