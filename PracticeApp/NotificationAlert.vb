Imports Microsoft.Office.Interop.Outlook
Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class NotificationAlert
    Dim notifications As NotificationAPI
    Dim newNotificationShow As NotificationsShow

    Public Class CustomerData
        Public Name As String
        Public DivisionID As String
        Public Email As String
        Public FileList As List(Of String)

        Public Sub New(ByVal nme As String, ByVal di As String, ByVal em As String)
            Name = nme
            DivisionID = di
            Email = em
            FileList = New List(Of String)
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByRef notify As System.Data.DataSet)
        InitializeComponent()
        notifications = New NotificationAPI(notify)
        lblAlertMessage.Text = "You have " + notifications.Count().ToString() + " total notifications pending."
        Dim cnt As Integer = 0
        Dim recurringCnt As Integer = 0
        For i As Integer = 0 To notifications.Count - 1
            If notifications.Data(i).NotificationType.Equals("Invoice Payment") Then
                cnt += 1
            ElseIf notifications.Data(i).NotificationType.Equals("Recurring Invoice") Then
                recurringCnt += 1
            End If
        Next
        ''if recurring payment found will print the count to the user and show the button
        If cnt > 0 Then
            cmdPrintPaymentCoupons.Show()
            lblAlertMessage.Text += Environment.NewLine + "You have " + cnt.ToString() + " pending invoice payment reminders."
        Else
            cmdPrintPaymentCoupons.Hide()
        End If
        ''if recurring invoices found will print the count to the user and show the button
        If recurringCnt > 0 Then
            cmdCreateInvoice.Show()
            lblAlertMessage.Text += Environment.NewLine + "You have " + recurringCnt.ToString() + " pending recurring invoices to create."
        Else
            cmdCreateInvoice.Hide()
        End If
    End Sub

    ''if the user decides to snooze the notifications this will set it to go off again in 30 minutes
    Private Sub cmdSnooze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSnooze.Click
        notifications.Snooze(30)
        Me.Close()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        newNotificationShow = New NotificationsShow(notifications)
        Me.Hide()
        newNotificationShow.Parent = Me.Parent
        newNotificationShow.ShowDialog()
        Me.Close()
    End Sub

    Public Function NotificationViewShowing() As Boolean
        If newNotificationShow IsNot Nothing Then
            Return True
        End If
        Return False
    End Function

    ''if the user decides to snooze the notifications this will set it to go off again in 1 day
    Private Sub cmdSnoozeOneDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSnoozeOneDay.Click
        Dim timediff = -1 * Now.Hour + 8
        If Now.Hour < 8 Then
            timediff = Now.Hour - 8
        End If

        notifications.Snooze(DateDiff(DateInterval.Minute, Now, Now.AddDays(1).AddHours(timediff).AddMinutes((-1 * Now.Minute)).AddSeconds(-1 * Now.Second).AddMilliseconds(-1 * Now.Millisecond)))

        Me.Close()
    End Sub

    Private Sub cmdPrintPaymentCoupons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPaymentCoupons.Click
        If MessageBox.Show("Do you wish to email?", "Email?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim customerList As New Dictionary(Of String, CustomerData)
            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")

            Dim cmd As New SqlCommand("SELECT InvoiceHeaderTable.CustomerID, isnull(InvoiceEmail, '') as InvoiceEmail FROM InvoiceHeaderTable LEFT OUTER JOIN CustomerList ON InvoiceHeaderTable.CustomerID = CustomerList.CustomerID AND InvoiceHeaderTable.DivisionID = CustomerList.DivisionID WHERE InvoiceNumber = (SELECT InvoiceNumber FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentLineTable WHERE NotificationNumber = @NotificationNumber))", con)
            cmd.Parameters.Add("@NotificationNumber", SqlDbType.Int)

            Dim reader As SqlDataReader
            ''goes through all notificaitons and will create PDF files for the invoice payments as well as log the customer ID
            For i As Integer = 0 To notifications.Count() - 1
                If notifications.Data(i).NotificationType.Equals("Invoice Payment") Then
                    ''gets the customer ID
                    cmd.Parameters("@NotificationNumber").Value = Val(notifications.Data(i).NotificationKey)
                    If con.State = ConnectionState.Closed Then con.Open()
                    reader = cmd.ExecuteReader()
                    reader.Read()

                    Dim customerID As String = reader.Item("CustomerID")
                    Dim customerEmail As String = reader.Item("InvoiceEmail")
                    reader.Close()

                    ''checks to see if the customer ID was already added if not will add and check to see if the directory has been created / is empty
                    If Not customerList.ContainsKey(customerID) Then
                        customerList.Add(customerID, New CustomerData("", notifications.Data(i).Division, customerEmail))
                        If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerID) Then
                            Dim curDir As New System.IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerID)
                            For Each File As System.IO.FileInfo In curDir.GetFiles()
                                File.Delete()
                            Next
                        Else
                            My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerID)
                        End If
                    End If
                    ''generates the file
                    Dim newPrintARRecurringPayment As New PrintRecurringPayment(notifications.Data(i), True)
                End If
            Next

            cmd = New SqlCommand("SELECT CompanyName, DivisionKey FROM DivisionTable", con)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim companyList As New Dictionary(Of String, String)
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    If Not companyList.ContainsKey(reader.Item(1)) Then
                        companyList.Add(reader.Item(1), reader.Item(0))
                    End If
                End While
            End If
            reader.Close()
            If con.State = ConnectionState.Open Then con.Close()

            ''goes through the list of customers and will make the emails for the customer with the proper attached payments
            For i As Integer = 0 To customerList.Count - 1
                Dim OLApp As New Application
                Dim mail As MailItem
                mail = OLApp.CreateItem(OlItemType.olMailItem)
                mail.To = customerList(customerList.Keys(i)).Email
                mail.Subject = "Payment Coupon(s)"
                mail.Body = "Attached are the payment coupon(s) for " + companyList(customerList.Keys(i)) + "."
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerList.Keys(i)) Then
                    Dim dirInfo As New System.IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerList.Keys(i))
                    For Each File As System.IO.FileInfo In dirInfo.GetFiles()
                        mail.Attachments.Add(File.FullName)
                    Next
                End If
                mail.Display()
            Next

        Else
            ''goes through all the notificaitons and checks to see if it's and invoice payment. if it is will print without viewer
            For i As Integer = 0 To notifications.Count() - 1
                If notifications.Data(i).NotificationType.Equals("Invoice Payment") Then
                    Dim newPrintARRecurringPayment As New PrintRecurringPayment(notifications.Data(i))
                End If
            Next
        End If
        ''removes all the either printed or emailed invoice payments
        Dim j As Integer = 0
        While j < notifications.Count()
            If notifications.Data(j).NotificationType.Equals("Invoice Payment") Then
                notifications.RemoveNotification(j)
            Else
                j += 1
            End If
        End While
        ReloadAlertMessage()
    End Sub

    Private Sub ReloadAlertMessage()
        ''check to make sure there are still notifications if so will update the text, else closes
        If notifications.Count > 0 Then
            lblAlertMessage.Text = "You have " + notifications.Count().ToString() + " total notifications pending."
            Dim cnt As Integer = 0
            Dim recurringCnt As Integer = 0
            For i As Integer = 0 To notifications.Count - 1
                If notifications.Data(i).NotificationType.Equals("Invoice Payment") Then
                    ''counts the invoice payments
                    cnt += 1
                ElseIf notifications.Data(i).NotificationType.Equals("Recurring Invoice") Then
                    ''counts the recurring invoices
                    recurringCnt += 1
                End If
            Next
            If cnt > 0 Then
                ''if it finds invoices to print will display the button print button and show how many there are to the user
                cmdPrintPaymentCoupons.Show()
                lblAlertMessage.Text += Environment.NewLine + "You have " + cnt.ToString() + " pending invoice payment reminders."
            Else
                cmdPrintPaymentCoupons.Hide()
            End If
            If recurringCnt > 0 Then
                ''if there are recurring invoices found this will show the button to generate the invoiceable entries and show how many
                cmdPrintPaymentCoupons.Show()
                lblAlertMessage.Text += Environment.NewLine + "You have " + recurringCnt.ToString() + " pending recurring invoices to create."
            Else
                cmdCreateInvoice.Hide()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmdCreateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateInvoice.Click
        If MessageBox.Show("Are you sure you wish to make all recurring invoices?" + Environment.NewLine + "(This action can't be undone)", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
            ''goes through all the notifications to create the invoices for the ones that are recurring
            For i As Integer = 0 To notifications.Count - 1
                ''check to see if it is a recurring invoice or not.
                If notifications.Data(i).NotificationType.Equals("Recurring Invoice") Then
                    Dim PartNumbers As String = notifications.Data(i).Details.Substring(notifications.Data(i).Details.IndexOf("Part Number(s): ") + 16)
                    If PartNumbers.Contains(Environment.NewLine) Then
                        PartNumbers = PartNumbers.Substring(PartNumbers.IndexOf("(s): ") + 5, PartNumbers.IndexOf(Environment.NewLine))
                    End If

                    Dim spl As String() = PartNumbers.Split(New String() {", "}, StringSplitOptions.RemoveEmptyEntries)
                    ''declares and fills PickListHeaderKey, BatchNumber, OldPickListHeaderKey
                    Dim cmd As New SqlCommand("DECLARE @PickListHeaderKey as int = (SELECT isnull(MAX(PickListHeaderKey) + 1, 659900) FROM PickListHeaderTable), @BatchNumber as int = (SELECT isnull(MAX(BatchNumber) + 1, 870000000) FROM PickListHeaderTable), @OldPickListHeaderKey as int = (SELECT isnull(MAX(PickListHeaderKey) + 1, 659900) FROM PickListHeaderTable WHERE SalesOrderHeaderKey = @SalesOrderHeaderKey AND DivisionID = @DivisionID); ", con)
                    cmd.Parameters.Add("@SalesOrderHeaderKey", SqlDbType.Int).Value = Val(notifications.Data(i).ReferenceNumber)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = notifications.Data(i).Division
                    ''INSERTS Duplicate data into the PickListHeaderTable from the last time the Sales Order was shipped. Uses a new PickListHeaderKey and BatchNumber
                    cmd.CommandText += " INSERT INTO PickListHeaderTable (PickListHeaderKey, SalesOrderHeaderKey, PickDate, DivisionID, Comment, PLStatus, CustomerID, CustomerPO, ShipVia, AdditionalShipTo, BatchNumber, PRONumber, SalesmanID, SpecialInstructions, ShipDate, PickCount, RunningCount, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry) SELECT @PickListHeaderKey, @SalesOrderHeaderKey, @CurrentDate, DivisionKey, HeaderComment, 'SHIPPED', CustomerID, CustomerPO, ShipVia, AdditionalShipTo, @BatchNumber, PRONumber, Salesperson, SpecialInstructions, @CurrentDate, 1, 1, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderHeaderKey AND DivisionKey = @DivisionID;"
                    cmd.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = Now
                    ''INSERTS duplicated rental lines into PickListLineTable under new PickListHeaderKey 
                    cmd.CommandText += " INSERT INTO PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) SELECT @PickListHeaderKey, SalesOrderLineKey, ItemID, Description, QuantityOpen, Price, SalesTaxOpen, OpenExtendedAmount, LineComment, LineStatus, DivisionKey, OpenLineWeight, LineBoxes, DebitGLAccount, CreditGLAccount, CertificationType, SalesOrderLineKey, '', 0 FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderHeaderKey AND QuantityOpen > 0"
                    Dim itemsText As String = ""
                    ''loop to get all the different itemIDs specified in the details section of the notification
                    For k As Integer = 0 To spl.Count - 1
                        If k = 0 Then
                            cmd.CommandText += " AND ( ItemID = @ItemID" + k.ToString()
                            itemsText = " AND ( PartNumber = @ItemID" + k.ToString()
                        Else
                            cmd.CommandText += " OR ItemID = @ItemID" + k.ToString()
                            itemsText += " OR PartNumber = @ItemID" + k.ToString()
                        End If
                        cmd.Parameters.Add("@ItemID" + k.ToString(), SqlDbType.VarChar).Value = spl(k)
                    Next
                    If spl.Count > 0 Then
                        itemsText += ")"
                        cmd.CommandText += ");"
                    End If

                    ''DECLARES ShipmentNumber
                    cmd.CommandText += " DECLARE @ShipmentNumber as int = (SELECT isnull(MAX(ShipmentNumber) + 1, 456000) FROM ShipmentHeaderTable), @ShipmentBatchNumber as int = (SELECT isnull(MAX(BatchNumber) + 1, 880000000) FROM ShipmentHeaderTable), @OldShipmentNumber as int = (SELECT MAX(ShipmentNumber) FROM ShipmentHeaderTable WHERE SalesOrderKey = @SalesOrderHeaderKey AND DivisionID = @DivisionID);"
                    ''INSERTS duplicated shipment header under new shipment number and new picklist number into ShipmetnHeaderTable
                    cmd.CommandText += " INSERT INTO ShipmentHeaderTable(ShipmentNumber, SalesOrderKey, ShipDate, DivisionID, Comment, PickTicketNumber, ShipVia, PRONumber, FreightQuoteNumber, FreightQuoteAmount, FreightActualAmount, ShippingWeight, NumberOfPallets, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, CustomerPO, ShipmentStatus, ProductTotal, TaxTotal, ShipmentTotal, BatchNumber, SalesmanID, SpecialInstructions, Tax2Total, Tax3Total, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, Locked, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, ShipToName) SELECT @ShipmentNumber, SalesOrderKey, @CurrentDate, DivisionID, Comment, @PickListHeaderKey, ShipVia, PRONumber, FreightQuoteNumber, FreightQuoteAmount, FreightActualAmount, ShippingWeight, NumberOfPallets, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, CustomerPO, 'SHIPPED', ProductTotal, TaxTotal, ShipmentTotal, @ShipmentBatchNumber, SalesmanID, SpecialInstructions, Tax2Total, Tax3Total, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, Locked, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, ShipToName FROM ShipmentHeaderTable WHERE ShipmentNumber = @OldShipmentNumber AND DivisionID = @DivisionID;"
                    ''INSERTS duplicated rental lines into ShipmentLineTable
                    cmd.CommandText += " INSERT INTO ShipmentLineTable(ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, SerialNumber, Dropship, BoxWeight, LineComplete) SELECT @ShipmentNumber, SalesOrderLineKey, ItemID, Description, 1, Price, LineComment, LineWeight, LineBoxes, SalesTaxOpen, Price + SalesTaxOpen, 'SHIPPED', DivisionKey, DebitGLAccount, CreditGLAccount, CertificationType, 0, SalesOrderLineKey, '', 'NO', 0, 'NO' FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderHeaderKey AND QuantityOpen > 0"
                    cmd.CommandText += itemsText.Replace("PartNumber", "ItemID") + ";"
                    ''Update ShipmentHeaderTable Total
                    cmd.CommandText += " DECLARE @ShipmentTotal as float = (SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber), @TaxTotal as float = (SELECT SUM(SalesTax) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber); UPDATE ShipmentHeaderTable SET ProductTotal = @ShipmentTotal, TaxTotal = @TaxTotal, ShipmentTotal = @ShipmentTotal + @TaxTotal WHERE ShipmentNumber = @ShipmentNumber;"
                    ''INSERT duplicated entry from previous shipment, with changing the transaction number, batch number and reference number
                    cmd.CommandText += " SELECT ExtendedAmount, DivisionID, GLDebitAccount, GLCreditAccount, ShipmentLineNumber, @ShipmentNumber as ShipmentNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber"
                    cmd.CommandText += itemsText + ";"
                    Dim tempds As New DataSet
                    Dim adap As New SqlDataAdapter(cmd)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        adap.Fill(tempds, "GL")
                    Catch ex As System.Exception
                        sendErrorToDataBase("NotificationsShow - cmdCreateInvoice --Error trying to insert PickList and Shipment Header and/or lines or retrieving shipment lines.", "Notification #" + notifications.Data(i).NotificationKey, ex.ToString())
                        MessageBox.Show("There was an issue with creating entries, contact system admin.", "Unable to create entries", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End Try

                    ''gets the first new GL key and batch number
                    cmd = New SqlCommand("BEGIN TRAN DECLARE @GLTransactionKey as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @GLBatchNumber as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 101001) FROM GLTransactionMasterList); INSERT INTO GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES", con)

                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = notifications.Data(i).Division
                    cmd.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = Now
                    cmd.Parameters.Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order # " + notifications.Data(i).ReferenceNumber

                    Dim glCount As Integer = 0
                    ''loops through all lines and will create the debit and credit for the GL postings
                    For l As Integer = 0 To tempds.Tables("GL").Rows.Count - 1
                        If glCount = 0 Then
                            cmd.CommandText += " (@GLTransactionKey+" + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Shipment', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment, @DivisionID, 'SALESJOURNAL', @GLBatchNumber, @GLReferenceNumber" + glCount.ToString() + ", @GLReferenceLine" + glCount.ToString() + ",'POSTED')"
                        Else
                            cmd.CommandText += ", (@GLTransactionKey+" + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Shipment', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment, @DivisionID, 'SALESJOURNAL', @GLBatchNumber, @GLReferenceNumber" + glCount.ToString() + ", @GLReferenceLine" + glCount.ToString() + ",'POSTED')"
                        End If
                        'DEBIT
                        With cmd.Parameters
                            .Add("@GLAccountNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(l).Item("GLDebitAccount")
                            .Add("@GLTransactionDebitAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                            .Add("@GLReferenceNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(l).Item("ShipmentNumber")
                            .Add("@GLReferenceLine" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(l).Item("ShipmentLineNumber")
                        End With
                        glCount += 1

                        cmd.CommandText += ", (@GLTransactionKey+" + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Shipment', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment, @DivisionID, 'SALESJOURNAL', @GLBatchNumber, @GLReferenceNumber" + glCount.ToString() + ", @GLReferenceLine" + glCount.ToString() + ",'POSTED')"
                        'CREDIT
                        With cmd.Parameters
                            .Add("@GLAccountNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(l).Item("GLCreditAccount")
                            .Add("@GLTransactionDebitAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                            .Add("@GLReferenceNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(l).Item("ShipmentNumber")
                            .Add("@GLReferenceLine" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(l).Item("ShipmentLineNumber")
                        End With
                        glCount += 1
                    Next

                    ''updates the notification to be completed
                    cmd.CommandText += " UPDATE NotificationTable SET Status = 'COMPLETED' WHERE NotificationKey = @NotificationKey;"
                    cmd.Parameters.Add("@NotificationKey", SqlDbType.Int).Value = Val(notifications.Data(i).NotificationKey)
                    ''Needed for the transaction
                    cmd.CommandText += " COMMIT TRAN"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As System.Exception
                        con.Close()
                        sendErrorToDataBase("NotificationsShow - cmdCreateInvoice --Error trying to insert GL transactions or update notification status.", "Notification #" + notifications.Data(i).NotificationKey, ex.ToString())
                        MessageBox.Show("There was an issue with creating entries, contact system admin.", "Unable to create entries", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End Try
                End If
            Next
            If con.State = ConnectionState.Open Then con.Close()
            Dim j As Integer = 0
            ''goes through the notifications and removes the recurring invoices
            While j < notifications.Count()
                If notifications.Data(j).NotificationType.Equals("Recurring Invoice") Then
                    notifications.RemoveNotification(j)
                Else
                    j += 1
                End If
            End While
            If con.State = ConnectionState.Open Then con.Close()
            MessageBox.Show("Invoices have been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReloadAlertMessage()
        End If
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
        Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class