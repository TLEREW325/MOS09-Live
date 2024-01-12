Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook

Public Class PrintRecurringPayment
    Dim crxRecurringPay As New CRXRecurringPayment()
    Dim ds As New DataSet
    Dim firstInvoiceNumber As Integer
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal invoiceNumber As Integer)
        InitializeComponent()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
        ''Invoice Header Table data
        Dim cmd As New SqlCommand("SELECT InvoiceNumber, InvoiceDate, SalesOrderNumber, DivisionID, CustomerPO, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, InvoiceTotal, PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Division Table Data
        Dim cmd1 As New SqlCommand("SELECT DivisionKey, DivisionDescription, CompanyName, Address1, Address2, City, State, Country, ZipCode, Phone, Fax FROM DivisionTable WHERE DivisionKey = (SELECT DivisionID FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
        cmd1.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Customer List Data
        Dim cmd2 As New SqlCommand("SELECT CustomerID, DivisionID, CustomerName FROM CustomerList WHERE CustomerID = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
        cmd2.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Recurring Header Table Data
        Dim cmd3 As New SqlCommand("SELECT RecurringPaymentNumber, DivisionID, InvoiceNumber, BaseFinanceCharge, Percentage  FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd3.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Recurring Line Table Data
        Dim cmd4 As New SqlCommand("SELECT RecurringPaymentNumber, LineNumber, PaymentDate, PaymentAmount, BaseAmount  FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber) ORDER BY RecurringPaymentNumber, LineNumber", con)
        cmd4.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber

        Dim adap As New SqlDataAdapter(cmd)
        ds = New DataSet
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "InvoiceHeaderTable")
        adap.SelectCommand = cmd1
        adap.Fill(ds, "DivisionTable")
        adap.SelectCommand = cmd2
        adap.Fill(ds, "CustomerList")
        adap.SelectCommand = cmd3
        adap.Fill(ds, "RecurringPaymentHeaderTable")
        adap.SelectCommand = cmd4
        adap.Fill(ds, "RecurringPaymentLineTable")
        con.Close()

        crxRecurringPay.SetDataSource(ds)
        CRVARRecurringPayment.ReportSource = crxRecurringPay
    End Sub
    Public Sub New(ByVal recurringPaymentNumber As Integer, ByVal lineNumber As Integer, Optional ByVal PrintOnly As Boolean = False)
        InitializeComponent()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
        ''Invoice Header Table data
        Dim cmd As New SqlCommand("SELECT InvoiceNumber, InvoiceDate, SalesOrderNumber, DivisionID, CustomerPO, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, InvoiceTotal, PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = (SELECT InvoiceNubmer FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber)", con)
        cmd.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Division Table Data
        Dim cmd1 As New SqlCommand("SELECT DivisionKey, DivisionDescription, CompanyName, Address1, Address2, City, State, Country, ZipCode, Phone, Fax FROM DivisionTable WHERE DivisionKey = (SELECT DivisionID FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber)", con)
        cmd1.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Customer List Data
        Dim cmd2 As New SqlCommand("SELECT CustomerID, DivisionID, CustomerName FROM CustomerList WHERE CustomerID = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = (SELECT InvoiceNumber FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber))", con)
        cmd2.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Recurring Header Table Data
        Dim cmd3 As New SqlCommand("SELECT RecurringPaymentNumber, DivisionID, InvoiceNumber, BaseFinanceCharge, Percentage  FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber", con)
        cmd3.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Recurring Line Table Data
        Dim cmd4 As New SqlCommand("SELECT RecurringPaymentNumber, LineNumber, PaymentDate, PaymentAmount, BaseAmount  FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber AND LineNumber = @LineNumber", con)
        cmd4.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        cmd4.Parameters.Add("@LineNumber", SqlDbType.Int).Value = lineNumber

        Dim adap As New SqlDataAdapter(cmd)
        ds = New DataSet
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "InvoiceHeaderTable")
        adap.SelectCommand = cmd1
        adap.Fill(ds, "DivisionTable")
        adap.SelectCommand = cmd2
        adap.Fill(ds, "CustomerList")
        adap.SelectCommand = cmd3
        adap.Fill(ds, "RecurringPaymentHeaderTable")
        adap.SelectCommand = cmd4
        adap.Fill(ds, "RecurringPaymentLineTable")
        con.Close()

        crxRecurringPay.SetDataSource(ds)
        If PrintOnly Then
            crxRecurringPay.PrintToPrinter(1, True, 0, 0)
        Else
            CRVARRecurringPayment.ReportSource = crxRecurringPay
        End If

    End Sub

    Public Sub New(ByVal invoiceNumber As Integer, ByVal ParamArray lineNumbers As Integer())
        InitializeComponent()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
        ''Invoice Header Table data
        Dim cmd As New SqlCommand("SELECT InvoiceNumber, InvoiceDate, SalesOrderNumber, DivisionID, CustomerPO, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, InvoiceTotal, PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Division Table Data
        Dim cmd1 As New SqlCommand("SELECT DivisionKey, DivisionDescription, CompanyName, Address1, Address2, City, State, Country, ZipCode, Phone, Fax FROM DivisionTable WHERE DivisionKey = (SELECT DivisionID FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
        cmd1.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Customer List Data
        Dim cmd2 As New SqlCommand("SELECT CustomerID, DivisionID, CustomerName FROM CustomerList WHERE CustomerID = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
        cmd2.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Recurring Header Table Data
        Dim cmd3 As New SqlCommand("SELECT RecurringPaymentNumber, DivisionID, InvoiceNumber, BaseFinanceCharge, Percentage FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd3.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
        ''Recurring Line Table Data
        Dim cmd4 As New SqlCommand("SELECT RecurringPaymentNumber, LineNumber, PaymentDate, PaymentAmount, BaseAmount  FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
        cmd4.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber

        For i As Integer = 0 To lineNumbers.Count - 1
            If i = 0 Then
                cmd4.CommandText += " AND (LineNumber =" + lineNumbers(i).ToString()
            Else
                cmd4.CommandText += " OR LineNumber =" + lineNumbers(i).ToString()
            End If
        Next
        If lineNumbers.Count > 0 Then
            cmd4.CommandText += ") ORDER BY RecurringPaymentNumber, LineNumber"
        Else
            cmd4.CommandText += " ORDER BY RecurringPaymentNumber, LineNumber"
        End If
        Dim adap As New SqlDataAdapter(cmd)
        ds = New DataSet
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "InvoiceHeaderTable")
        adap.SelectCommand = cmd1
        adap.Fill(ds, "DivisionTable")
        adap.SelectCommand = cmd2
        adap.Fill(ds, "CustomerList")
        adap.SelectCommand = cmd3
        adap.Fill(ds, "RecurringPaymentHeaderTable")
        adap.SelectCommand = cmd4
        adap.Fill(ds, "RecurringPaymentLineTable")

        con.Close()

        crxRecurringPay.SetDataSource(ds)
        CRVARRecurringPayment.ReportSource = crxRecurringPay
    End Sub

    Public Sub New(ByVal notify As NotificationAPI.NotificationData, Optional ByVal email As Boolean = False)
        InitializeComponent()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT RecurringPaymentNumber, LineNumber FROM RecurringPaymentLineTable WHERE NotificationNumber = @NotificationNumber", con)
        cmd.Parameters.Add("@NotificationNumber", SqlDbType.Int).Value = Val(notify.NotificationKey)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim recurringPaymentNumber As Integer = 0
        Dim lineNumber As Integer = 0
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            recurringPaymentNumber = reader.Item("RecurringPaymentNumber")
            lineNumber = reader.Item("LineNumber")
        End If
        reader.Close()
        ''Invoice Header Table data
        cmd = New SqlCommand("SELECT InvoiceNumber, InvoiceDate, SalesOrderNumber, DivisionID, CustomerID, CustomerPO, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, InvoiceTotal, PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = (SELECT InvoiceNumber FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber)", con)
        cmd.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Division Table Data
        Dim cmd1 As New SqlCommand("SELECT DivisionKey, DivisionDescription, CompanyName, Address1, Address2, City, State, Country, ZipCode, Phone, Fax FROM DivisionTable WHERE DivisionKey = (SELECT DivisionID FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber)", con)
        cmd1.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Customer List Data
        Dim cmd2 As New SqlCommand("SELECT CustomerID, DivisionID, CustomerName FROM CustomerList WHERE CustomerID = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = (SELECT InvoiceNumber FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber))", con)
        cmd2.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Recurring Header Table Data
        Dim cmd3 As New SqlCommand("SELECT RecurringPaymentNumber, DivisionID, InvoiceNumber, BaseFinanceCharge, Percentage FROM RecurringPaymentHeaderTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber", con)
        cmd3.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        ''Recurring Line Table Data and updates to show pritned and completes notification
        Dim cmd4 As New SqlCommand("UPDATE RecurringPaymentLineTable SET Printed = 'True' WHERE RecurringPaymentNumber = @RecurringPaymentNumber AND LineNumber = @LineNumber; UPDATE NotificationTable SET Status = 'COMPLETED' WHERE NotificationKey = @NotificationKey;  SELECT RecurringPaymentNumber, LineNumber, PaymentDate, PaymentAmount, BaseAmount FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = @RecurringPaymentNumber AND LineNumber = @LineNumber", con)
        cmd4.Parameters.Add("@RecurringPaymentNumber", SqlDbType.Int).Value = recurringPaymentNumber
        cmd4.Parameters.Add("@LineNumber", SqlDbType.Int).Value = lineNumber
        cmd4.Parameters.Add("@NotificationKey", SqlDbType.Int).Value = Val(notify.NotificationKey)

        Dim adap As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "InvoiceHeaderTable")
        adap.SelectCommand = cmd1
        adap.Fill(ds, "DivisionTable")
        adap.SelectCommand = cmd2
        adap.Fill(ds, "CustomerList")
        adap.SelectCommand = cmd3
        adap.Fill(ds, "RecurringPaymentHeaderTable")
        adap.SelectCommand = cmd4
        adap.Fill(ds, "RecurringPaymentLineTable")
        con.Close()
        Dim test As Double = ds.Tables("RecurringPaymentHeaderTable").Rows(0).Item("BaseFinanceCharge")
        Dim test2 As Double = ds.Tables("RecurringPaymentLineTable").Rows(0).Item("BaseAmount")
        crxRecurringPay.SetDataSource(ds)
        If email Then
            If ds.Tables("CustomerList").Rows.Count > 0 Then
                If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID") + "\" + Now.ToShortDateString().Replace("/", " ").Replace("-", " ") + ".pdf") Then
                    System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID") + "\" + Now.ToShortDateString().Replace("/", " ").Replace("-", " ") + ".pdf")
                End If
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID")) Then
                    System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID"))
                End If
                crxRecurringPay.ExportToDisk(ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID") + "\" + notify.ReferenceNumber + " " + Now.ToShortDateString().Replace("/", " ").Replace("-", " ") + ".pdf")
            End If
        Else
            crxRecurringPay.PrintToPrinter(1, True, 0, 0)
        End If

    End Sub

    Public Sub New(ByRef dgv As System.Windows.Forms.DataGridView)
        InitializeComponent()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
        Dim invoiceNumbers As New Dictionary(Of Integer, List(Of Integer))

        For i As Integer = 0 To dgv.SelectedCells.Count - 1
            If Not invoiceNumbers.Keys.Contains(dgv.Rows(dgv.SelectedCells(i).RowIndex).Cells("InvoiceNumber").Value) Then
                invoiceNumbers.Add(dgv.Rows(dgv.SelectedCells(i).RowIndex).Cells("InvoiceNumber").Value, New List(Of Integer))
            End If
            If Not invoiceNumbers(dgv.Rows(dgv.SelectedCells(i).RowIndex).Cells("InvoiceNumber").Value).Contains(dgv.Rows(dgv.SelectedCells(i).RowIndex).Cells("LineNumber").Value) Then
                invoiceNumbers(dgv.Rows(dgv.SelectedCells(i).RowIndex).Cells("InvoiceNumber").Value).Add(dgv.Rows(dgv.SelectedCells(i).RowIndex).Cells("LineNumber").Value)
            End If
        Next
        For i As Integer = 0 To invoiceNumbers.Count - 1
            Dim invoiceNumber As Integer = invoiceNumbers.ElementAt(i).Key
            ''Invoice Header Table data
            Dim cmd As New SqlCommand("SELECT InvoiceNumber, InvoiceDate, SalesOrderNumber, DivisionID, CustomerPO, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, InvoiceTotal, PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
            ''Division Table Data
            Dim cmd1 As New SqlCommand("SELECT DivisionKey, DivisionDescription, CompanyName, Address1, Address2, City, State, Country, ZipCode, Phone, Fax FROM DivisionTable WHERE DivisionKey = (SELECT DivisionID FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
            cmd1.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
            ''Customer List Data
            Dim cmd2 As New SqlCommand("SELECT CustomerID, DivisionID, CustomerName FROM CustomerList WHERE CustomerID = (SELECT CustomerID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
            cmd2.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
            ''Recurring Header Table Data
            Dim cmd3 As New SqlCommand("SELECT RecurringPaymentNumber, DivisionID, InvoiceNumber, BaseFinanceCharge, Percentage  FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd3.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber
            ''Recurring Line Table Data
            Dim cmd4 As New SqlCommand("SELECT RecurringPaymentNumber, LineNumber, PaymentDate, PaymentAmount, BaseAmount FROM RecurringPaymentLineTable WHERE RecurringPaymentNumber = (SELECT RecurringPaymentNumber FROM RecurringPaymentHeaderTable WHERE InvoiceNumber = @InvoiceNumber)", con)
            cmd4.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber

            For j As Integer = 0 To invoiceNumbers(invoiceNumber).Count - 1
                If j = 0 Then
                    cmd4.CommandText += " AND (LineNumber =" + invoiceNumbers(invoiceNumber)(j).ToString()
                Else
                    cmd4.CommandText += " OR LineNumber =" + invoiceNumbers(invoiceNumber)(j).ToString()
                End If
            Next
            If invoiceNumbers(invoiceNumber).Count > 0 Then
                cmd4.CommandText += ") ORDER BY RecurringPaymentNumber, LineNumber"
            Else
                cmd4.CommandText += " ORDER BY RecurringPaymentNumber, LineNumber"
            End If
            Dim adap As New SqlDataAdapter(cmd)

            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(ds, "InvoiceHeaderTable")
            adap.SelectCommand = cmd1
            adap.Fill(ds, "DivisionTable")
            adap.SelectCommand = cmd2
            adap.Fill(ds, "CustomerList")
            adap.SelectCommand = cmd3
            adap.Fill(ds, "RecurringPaymentHeaderTable")
            adap.SelectCommand = cmd4
            adap.Fill(ds, "RecurringPaymentLineTable")
        Next

        con.Close()
        If invoiceNumbers.Count > 0 Then
            firstInvoiceNumber = invoiceNumbers.ElementAt(0).Key
        End If

        crxRecurringPay.SetDataSource(ds)
        CRVARRecurringPayment.ReportSource = crxRecurringPay
    End Sub

    Private Sub EmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailToolStripMenuItem.Click

        If ds.Tables("CustomerList").Rows.Count > 0 Then
            If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID") + "\" + Now.ToShortDateString().Replace("/", " ").Replace("-", " ") + ".pdf") Then
                System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID") + "\" + Now.ToShortDateString().Replace("/", " ").Replace("-", " ") + ".pdf")
            End If
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID")) Then
                System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID"))
            End If
            crxRecurringPay.ExportToDisk(ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID") + "\" + Now.ToShortDateString().Replace("/", " ").Replace("-", " ") + ".pdf")

            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
            Dim cmd As New SqlCommand("SELECT isnull(InvoiceEmail, '') as InvoiceEmail, InvoiceHeaderTable.DivisionID FROM InvoiceHeaderTable LEFT OUTER JOIN CustomerList ON InvoiceHeaderTable.CustomerID = CustomerList.CustomerID AND InvoiceHeaderTable.DivisionID = CustomerList.DivisionID WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = firstInvoiceNumber

            Dim invoiceEmail As String = ""
            Dim division As String = ""
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("InvoiceEmail")) Then
                    invoiceEmail = reader.Item("InvoiceEmail")
                End If
                If Not IsDBNull(reader.Item("DivisionID")) Then
                    division = reader.Item("DivisionID")
                End If
            End If
            reader.Close()
            con.Close()
            'Created Outlook Application object
            Dim OLApp As New Application

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)


            'adding subject information to the mail message
            mail.Subject = ds.Tables("CustomerList").Rows(0).Item("CustomerID") + " - #" + division + firstInvoiceNumber.ToString()

            'adding body message information to the mail message
            mail.Body = "This is a payment coupon - " + invoiceEmail

            'adding to into the address field
            mail.To = invoiceEmail

            'adding attachment
            mail.Attachments.Add(My.Computer.FileSystem.SpecialDirectories.Temp + "\RecurringPayments\" + ds.Tables("CustomerList").Rows(0).Item("CustomerID") + "\" + Now.ToShortDateString().Replace("/", " ").Replace("-", " ") + ".pdf")

            'display mail
            mail.Display()
        End If

    End Sub

    Private Sub PrintARRecurringPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class