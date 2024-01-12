Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook

Public Class NotificationsShow
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    ''Dim ds As DataSet
    Dim currentNotification As Integer = 0
    Dim Notifications As NotificationAPI

    Public Sub New()
        InitializeComponent()
        Notifications = New NotificationAPI()
    End Sub

    Public Sub New(ByVal currentDate As Date, ByVal employee As String, ByVal division As String)
        InitializeComponent()
        Notifications = New NotificationAPI(currentDate, employee, division)

        currentNotification = 1
        DisplayNotification()
    End Sub

    Public Sub New(ByVal inds As DataSet)
        InitializeComponent()

        Notifications = New NotificationAPI(inds)
        currentNotification = 1
        DisplayNotification()
    End Sub

    Public Sub New(ByVal inNotifications As NotificationAPI)
        InitializeComponent()
        Notifications = inNotifications
        currentNotification = 1
        DisplayNotification()
    End Sub

    Public Sub LoadNotifications()
        Notifications.RefreshNotificationData()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        currentNotification += 1
        DisplayNotification()
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        currentNotification -= 1
        DisplayNotification()
    End Sub

    Private Sub DisplayNotification()
        ClearControls()

        ''check to make sure we have at least 1 item in the dataset
        If Notifications.Count() < 1 Then
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            cmdComplete.Enabled = False
            Exit Sub
        End If

        ''check to make sure we are not trying to go beyond what is in teh dataset
        If currentNotification > Notifications.Count() Then
            currentNotification = Notifications.Count()
        End If

        lblNotificationType.Text = Notifications.Data(currentNotification - 1).NotificationType
        lblReferenceNumber.Text = Notifications.Data(currentNotification - 1).ReferenceNumber
        lblNotificationRecipient.Text = Notifications.Data(currentNotification - 1).EmployeeName
        lblNotificationTime.Text = Notifications.Data(currentNotification - 1).NotificationType

        lblStatus.Text = Notifications.Data(currentNotification - 1).Status
        If lblStatus.Text.Equals("COMPLETED") Then
            cmdComplete.Enabled = False
        End If

        lblDetails.Text = Notifications.Data(currentNotification - 1).Details

        ''check to see at what position we are currently and will set the previous button
        If currentNotification = 1 Then
            cmdPrevious.Enabled = False
        Else
            cmdPrevious.Enabled = True
        End If

        ''check to see if we are at the last position and if so will turn off the next button
        If Notifications.Count() = currentNotification Then
            cmdNext.Enabled = False
        ElseIf Not cmdNext.Enabled Then
            cmdNext.Enabled = True
        End If

        ''check to see if the displayed notification is an invoice payment if so wil ldisplay the print coupon button
        If lblNotificationType.Text.Equals("Invoice Payment") Then
            cmdPrintPaymentCoupons.Show()
        Else
            cmdPrintPaymentCoupons.Hide()
        End If

        ''check to see if the displayed notification is a recurring invoice if so and is active will show the crete invoice button
        If lblNotificationType.Text.Equals("Recurring Invoice") And lblStatus.Text.Equals("ACTIVE") Then
            cmdCreateInvoice.Show()
            cmdDelete.Enabled = True
            cmdEdit.Enabled = True
        ElseIf lblNotificationType.Text.Equals("Recurring Invoice") Then
            '' if completed will disable the delete and hide the create invoice
            cmdCreateInvoice.Hide()
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
        Else
            cmdCreateInvoice.Hide()
            cmdDelete.Enabled = True
            cmdEdit.Enabled = True
        End If

        lblCount.Text = currentNotification.ToString + " OF " + Notifications.Count().ToString
    End Sub

    Private Sub ClearControls()
        lblNotificationType.Text = ""
        lblNotificationRecipient.Text = ""
        lblNotificationTime.Text = ""
        lblReferenceNumber.Text = ""
        lblDetails.Text = ""
        lblStatus.Text = ""
        lblCount.Text = ""
        cmdComplete.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComplete.Click
        cmd = New SqlCommand("UPDATE NotificationTable SET Status = 'COMPLETED' WHERE NotificationKey = @NotificationKey", con)
        cmd.Parameters.Add("@NotificationKey", SqlDbType.Int).Value = Notifications.Data(currentNotification - 1).NotificationKey

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        lblStatus.Text = "COMPLETED"
        Notifications.Data(currentNotification - 1).Status = "COMPLETED"
        cmdComplete.Enabled = False
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        cmd = New SqlCommand("DELETE NotificationTable WHERE NotificationKey = @NotificationKey", con)
        cmd.Parameters.Add("@NotificationKey", SqlDbType.Int).Value = Notifications.Data(currentNotification - 1).NotificationKey

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadNotifications()
        currentNotification = 1
        DisplayNotification()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Me.Hide()

        Dim newEditNotificaiton As New NotificationEdit(Notifications.Data(currentNotification - 1))
        newEditNotificaiton.ShowDialog()

        If newEditNotificaiton.DialogResult = System.Windows.Forms.DialogResult.OK Then
            Dim tempLocation As Integer = currentNotification
            LoadNotifications()
            currentNotification = tempLocation
            DisplayNotification()
        End If
        Me.Show()
    End Sub

    Private Sub cmdPrintPaymentCoupons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPaymentCoupons.Click
        If MessageBox.Show("Do you wish to email?", "Email?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim customerList As New List(Of String)
            Dim CustomerEmailList As New List(Of String)
            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")

            Dim cmd As New SqlCommand("SELECT InvoiceHeaderTable.CustomerID, isnull(InvoiceEmail, '') as InvoiceEmail FROM InvoiceHeaderTable LEFT OUTER JOIN CustomerList ON InvoiceHeaderTable.CustomerID = CustomerList.CustomerID AND InvoiceHeaderTable.DivisionID = CustomerList.DivisionID WHERE InvoiceNumber = (SELECT InvoiceNumber FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentLineTable WHERE NotificationNumber = @NotificationNumber))", con)
            cmd.Parameters.Add("@NotificationNumber", SqlDbType.Int)
            ''goes through all notificaitons and will create PDF files for the invoice payments as well as log the customer ID

            If Notifications.Data(currentNotification - 1).NotificationType.Equals("Invoice Payment") Then
                ''gets the customer ID
                cmd.Parameters("@NotificationNumber").Value = Val(Notifications.Data(currentNotification - 1).NotificationKey)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                reader.Read()

                Dim customerID As String = reader.Item("CustomerID")
                Dim customerEmail As String = reader.Item("InvoiceEmail")
                reader.Close()

                ''checks to see if the customer ID was already added if not will add and check to see if the directory has been created / is empty
                If Not customerList.Contains(customerID) Then
                    customerList.Add(customerID)
                    CustomerEmailList.Add(customerEmail)
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerID) Then
                        Dim curDir As New System.IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerList(0))
                        For Each File As System.IO.FileInfo In curDir.GetFiles()
                            File.Delete()
                        Next
                    Else
                        My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerID)
                    End If
                End If
                ''generates the file
                Dim newPrintARRecurringPayment As New PrintRecurringPayment(Notifications.Data(currentNotification - 1), True)
            End If
            cmd = New SqlCommand("SELECT CompanyName FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = Notifications.Data(currentNotification - 1).Division

            If con.State = ConnectionState.Closed Then con.Open()
            Dim companyName As String = cmd.ExecuteScalar()
            If con.State = ConnectionState.Open Then con.Close()

            ''goes through the list of customers and will make the emails for the customer with the proper attached payments
            For i As Integer = 0 To customerList.Count - 1
                Dim OLApp As New Application
                Dim mail As MailItem
                mail = OLApp.CreateItem(OlItemType.olMailItem)
                mail.To = CustomerEmailList(i)
                mail.Subject = "Payment Coupon(s)"
                mail.Body = "Attached are the payment coupon(s) for " + companyName + "."
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerList(i)) Then
                    Dim dirInfo As New System.IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + customerList(i))
                    For Each File As System.IO.FileInfo In dirInfo.GetFiles()
                        mail.Attachments.Add(File.FullName)
                    Next
                End If
                mail.Display()
            Next

        Else
            ''print without viewer
            Dim newPrintARRecurringPayment As New PrintRecurringPayment(Notifications.Data(currentNotification - 1))
        End If

        ''removes all the either printed or emailed invoice payments
        Notifications.Data(currentNotification - 1).Status = "COMPLETED"
        DisplayNotification()
    End Sub

    Private Sub cmdCreateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateInvoice.Click
        If MessageBox.Show("Are you sure you wish to make all recurring invoices?" + Environment.NewLine + "(This action can't be undone)", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
            Dim PartNumbers As String = lblDetails.Text.Substring(lblDetails.Text.IndexOf("Part Number(s): ") + 16)
            If PartNumbers.Contains(Environment.NewLine) Then
                PartNumbers = PartNumbers.Substring(PartNumbers.IndexOf("(s): ") + 5, PartNumbers.IndexOf(Environment.NewLine))
            End If

            Dim spl As String() = PartNumbers.Split(New String() {", "}, StringSplitOptions.RemoveEmptyEntries)
            ''declares and fills PickListHeaderKey, BatchNumber, OldPickListHeaderKey
            Dim cmd As New SqlCommand("DECLARE @PickListHeaderKey as int = (SELECT isnull(MAX(PickListHeaderKey) + 1, 659900) FROM PickListHeaderTable), @BatchNumber as int = (SELECT isnull(MAX(BatchNumber) + 1, 870000000) FROM PickListHeaderTable), @OldPickListHeaderKey as int = (SELECT isnull(MAX(PickListHeaderKey) + 1, 659900) FROM PickListHeaderTable WHERE SalesOrderHeaderKey = @SalesOrderHeaderKey AND DivisionID = @DivisionID); ", con)
            cmd.Parameters.Add("@SalesOrderHeaderKey", SqlDbType.Int).Value = Val(lblReferenceNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Notifications.Data(currentNotification - 1).Division
            ''INSERTS Duplicate data into the PickListHeaderTable from the last time the Sales Order was shipped. Uses a new PickListHeaderKey and BatchNumber
            cmd.CommandText += " INSERT INTO PickListHeaderTable (PickListHeaderKey, SalesOrderHeaderKey, PickDate, DivisionID, Comment, PLStatus, CustomerID, CustomerPO, ShipVia, AdditionalShipTo, BatchNumber, PRONumber, SalesmanID, SpecialInstructions, ShipDate, PickCount, RunningCount, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry) SELECT @PickListHeaderKey, @SalesOrderHeaderKey, @CurrentDate, DivisionKey, HeaderComment, 'SHIPPED', CustomerID, CustomerPO, ShipVia, AdditionalShipTo, @BatchNumber, PRONumber, Salesperson, SpecialInstructions, @CurrentDate, 1, 1, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderHeaderKey AND DivisionKey = @DivisionID;"
            cmd.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = Now
            ''INSERTS duplicated rental lines into PickListLineTable under new PickListHeaderKey 
            cmd.CommandText += " INSERT INTO PickListLineTable(PickListHeaderKey, PickListLineKey, ItemID, Description, Quantity, Price, SalesTax, ExtendedAmount, LineComment, LineStatus, DivisionID, LineWeight, LineBoxes, GLDebitAccount, GLCreditAccount, CertificationType, SOLineNumber, SerialNumber, QOH) SELECT @PickListHeaderKey, SalesOrderLineKey, ItemID, Description, QuantityOpen, Price, SalesTaxOpen, OpenExtendedAmount, LineComment, LineStatus, DivisionKey, OpenLineWeight, LineBoxes, DebitGLAccount, CreditGLAccount, CertificationType, SalesOrderLineKey, '', 0 FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderHeaderKey AND QuantityOpen > 0"
            Dim itemsText As String = ""
            For i As Integer = 0 To spl.Count - 1
                If i = 0 Then
                    cmd.CommandText += " AND ( ItemID = @ItemID" + i.ToString()
                    itemsText = " AND ( PartNumber = @ItemID" + i.ToString()
                Else
                    cmd.CommandText += " OR ItemID = @ItemID" + i.ToString()
                    itemsText += " OR PartNumber = @ItemID" + i.ToString()
                End If
                cmd.Parameters.Add("@ItemID" + i.ToString(), SqlDbType.VarChar).Value = spl(i)
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
                sendErrorToDataBase("NotificationsShow - cmdCreateInvoice --Error trying to insert PickList and Shipment Header and/or lines or retrieving shipment lines.", "Notification #" + Notifications.Data(currentNotification - 1).NotificationKey, ex.ToString())
                MessageBox.Show("There was an issue with creating entries, contact system admin.", "Unable to create entries", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            cmd = New SqlCommand("BEGIN TRAN DECLARE @GLTransactionKey as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @GLBatchNumber as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 101001) FROM GLTransactionMasterList); INSERT INTO GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES", con)

            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(0).Item("DivisionID")
            cmd.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = Now
            cmd.Parameters.Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order # " + lblReferenceNumber.Text

            Dim glCount As Integer = 0
            For i As Integer = 0 To tempds.Tables("GL").Rows.Count - 1
                If glCount = 0 Then
                    cmd.CommandText += "(@GLTransactionKey+" + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Shipment', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment, @DivisionID, 'SALESJOURNAL', @GLBatchNumber, @GLReferenceNumber" + glCount.ToString() + ", @GLReferenceLine" + glCount.ToString() + ",'POSTED')"
                Else
                    cmd.CommandText += ", (@GLTransactionKey+" + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Shipment', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment, @DivisionID, 'SALESJOURNAL', @GLBatchNumber, @GLReferenceNumber" + glCount.ToString() + ", @GLReferenceLine" + glCount.ToString() + ",'POSTED')"
                End If
                'DEBIT
                With cmd.Parameters
                    .Add("@GLAccountNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(i).Item("GLDebitAccount")
                    .Add("@GLTransactionDebitAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(i).Item("ShipmentNumber")
                    .Add("@GLReferenceLine" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(i).Item("ShipmentLineNumber")
                End With
                glCount += 1

                cmd.CommandText += ", (@GLTransactionKey+" + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Shipment', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment, @DivisionID, 'SALESJOURNAL', @GLBatchNumber, @GLReferenceNumber" + glCount.ToString() + ", @GLReferenceLine" + glCount.ToString() + ",'POSTED')"
                'CREDIT
                With cmd.Parameters
                    .Add("@GLAccountNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(i).Item("GLCreditAccount")
                    .Add("@GLTransactionDebitAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount" + glCount.ToString(), SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(i).Item("ShipmentNumber")
                    .Add("@GLReferenceLine" + glCount.ToString(), SqlDbType.VarChar).Value = tempds.Tables("GL").Rows(i).Item("ShipmentLineNumber")
                End With
                glCount += 1
            Next

            ''updates the notification to be completed
            cmd.CommandText += " UPDATE NotificationTable SET Status = 'COMPLETED' WHERE NotificationKey = @NotificationKey;"
            cmd.Parameters.Add("@NotificationKey", SqlDbType.Int).Value = Val(Notifications.Data(currentNotification - 1).NotificationKey)
            ''Needed for the transaction
            cmd.CommandText += " COMMIT TRAN"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                cmd.ExecuteNonQuery()
            Catch ex As System.Exception
                con.Close()
                sendErrorToDataBase("NotificationsShow - cmdCreateInvoice --Error trying to insert GL transactions or update notification status.", "Notification #" + Notifications.Data(currentNotification - 1).NotificationKey, ex.ToString())
                MessageBox.Show("There was an issue with creating entries, contact system admin.", "Unable to create entries", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
            If con.State = ConnectionState.Open Then con.Close()
            Notifications.Data(currentNotification - 1).Status = "COMPLETED"
            MessageBox.Show("Invoices have been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayNotification()
        End If
    End Sub

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