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
Imports Microsoft.Office.Interop.Outlook

Public Class PrintCustomerReturnAuthorization
    Inherits System.Windows.Forms.Form

    Dim CustomerFilter, SalespersonFilter, SalesTerritoryFilter, DateFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim LastTransactionNumber, NextTransactionNumber, counter As Integer
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        'Closes form
        Me.Dispose()
        Me.Close()
    End Sub

    

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this RMA Form?", "SAVE RMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If Validation() Then
                Dim exists As Boolean = False
                Dim autho As Integer = 0
                Dim ItemDataStatement As String = "SELECT AuthorizationNumber FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber"
                Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
                ItemDataCommand.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("AuthorizationNumber")) Then
                            autho = 0
                        Else
                            autho = reader.Item("AuthorizationNumber")
                        End If
                    End If
                    reader.Close()
                    Dim chosenautho = cboReturnGoodNum.Text
                    If chosenautho = autho Then
                        'update
                        cmd7 = New SqlCommand("UPDATE RMATable SET  Customer = @Customer, Date = @Date, FOXNumber = @FOXNumber, Quantity = @Quantity, Reason = @Reason, Remarks = @Remarks, AuthorizedTruckingFirm = @AuthorizedTruckingFirm, PurchaseOrderNumber = @PurchaseOrderNumber, DivisionID = @DivisionID, TypeFix = @TypeFix, CustomerContact = @CustomerContact, NeedPartsBy = @NeedPartsBy, QARepresentative = @QARepresentative, QARepDate = @QARepDate WHERE AuthorizationNumber = @OldAuthoNumber", con)
                        With cmd7.Parameters
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                            .Add("@Date", SqlDbType.VarChar).Value = Now
                            .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
                            .Add("@Quantity", SqlDbType.VarChar).Value = txtNumberofParts.Text
                            .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                            .Add("@Remarks", SqlDbType.VarChar).Value = txtRemark.Text
                            .Add("@AuthorizedTruckingFirm", SqlDbType.VarChar).Value = txtDelivery.Text
                            .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = txtPO.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                            .Add("@TypeFix", SqlDbType.VarChar).Value = cboReturnType.Text
                            .Add("@OldAuthoNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
                            .Add("@CustomerContact", SqlDbType.VarChar).Value = cboCustomerName.Text
                            .Add("@NeedPartsBy", SqlDbType.VarChar).Value = txtPartsBy.Text
                            .Add("@QARepresentative", SqlDbType.VarChar).Value = txtSignature.Text
                            .Add("@QARepDate", SqlDbType.VarChar).Value = txtSignatureDate.Text
                        End With
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd7.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Updated RMA")
                    Else
                        'insert
                        cmd7 = New SqlCommand("INSERT INTO RMATable (AuthorizationNumber, Customer, Date, FOXNumber, Quantity, Reason, Remarks, AuthorizedTruckingFirm, PurchaseOrderNumber, DivisionID, TypeFix, CustomerContact, NeedPartsBy, QARepresentative, QARepDate)Values(@AuthorizationNumber, @Customer, @Date, @FOXNumber, @Quantity, @Reason, @Remarks, @AuthorizedTruckingFirm, @PurchaseOrderNumber, @DivisionID, @TypeFix, @CustomerContact, @NeedPartsBy, @QARepresentative, @QARepDate)", con)

                        With cmd7.Parameters
                            .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomerName.Text
                            .Add("@Date", SqlDbType.VarChar).Value = Now
                            .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
                            .Add("@Quantity", SqlDbType.VarChar).Value = txtNumberofParts.Text
                            .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                            .Add("@Remarks", SqlDbType.VarChar).Value = txtRemark.Text
                            .Add("@AuthorizedTruckingFirm", SqlDbType.VarChar).Value = txtDelivery.Text
                            .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = txtPO.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                            .Add("@TypeFix", SqlDbType.VarChar).Value = cboReturnType.Text
                            .Add("@CustomerContact", SqlDbType.VarChar).Value = cboCustomerName.Text
                            .Add("@NeedPartsBy", SqlDbType.VarChar).Value = txtPartsBy.Text
                            .Add("@QARepresentative", SqlDbType.VarChar).Value = txtSignature.Text
                            .Add("@QARepDate", SqlDbType.VarChar).Value = txtSignatureDate.Text

                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd7.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved New RMA")
                    End If
                End Using

            End If
        End If
        Dim parameter As String
        Dim authorNumber1st As String
        Dim authorNumber2nd As String
        'Splits RMA Number into the single digit RMA Number and the ending of the year. I.E. 0422 becomes 04 and 22
        If cboReturnGoodNum.Text.Length = 4 Then
            Try
                authorNumber1st = cboReturnGoodNum.Text.Substring(0, 2)
                authorNumber2nd = cboReturnGoodNum.Text.Substring(2, 2)
            Catch ex As System.Exception
                authorNumber1st = "N/A"
                authorNumber2nd = "ERROR"
            End Try
        Else
            Try
                authorNumber1st = "0" & cboReturnGoodNum.Text.Substring(0, 1)
                authorNumber2nd = cboReturnGoodNum.Text.Substring(1, 2)
            Catch ex As System.Exception
                authorNumber1st = "N/A"
                authorNumber2nd = "ERROR"
            End Try
        End If
        'Sets up viewer to display data from the loaded dataset
        cmd = New SqlCommand("SELECT PartNumber, BlueprintRevision FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text


        cmd1 = New SqlCommand("SELECT BlueprintNumber, LongDescription FROM FOXTableQuery WHERE FOXNumber = @FOXNumber", con)
        cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text

        cmd2 = New SqlCommand("SELECT * FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber", con)
        cmd2.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTable")
        MyReport = CRXCustReturnGoods1
        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "FOXTableQuery")
        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "RMATable")
        MyReport.SetDataSource(ds)

        ''Fills parameters with the variables saved locally
        parameter = txtPO.Text
        CRXCustReturnGoods1.SetParameterValue("PurchaseOrderNumber", parameter)
        parameter = authorNumber1st + "-" + authorNumber2nd
        CRXCustReturnGoods1.SetParameterValue("GoodsAuthorizationNumber", parameter)
        parameter = cboCustomer.Text
        CRXCustReturnGoods1.SetParameterValue("Customer", parameter)
        parameter = cboCustomerName.Text
        CRXCustReturnGoods1.SetParameterValue("CustomerContact", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Fox", parameter)
        parameter = ""
        CRXCustReturnGoods1.SetParameterValue("Quantity", parameter)
        parameter = txtReason.Text
        CRXCustReturnGoods1.SetParameterValue("Reason", parameter)
        parameter = cboReturnType.Text
        CRXCustReturnGoods1.SetParameterValue("TypeOfReturn", parameter)
        parameter = txtRemark.Text
        CRXCustReturnGoods1.SetParameterValue("Remarks", parameter)
        parameter = txtDelivery.Text
        CRXCustReturnGoods1.SetParameterValue("AuthorizedTruckingFirm", parameter)
        parameter = txtPartsBy.Text
        CRXCustReturnGoods1.SetParameterValue("CustDate", parameter)
        parameter = txtSignature.Text
        CRXCustReturnGoods1.SetParameterValue("Signature", parameter)
        parameter = txtSignatureDate.Text
        CRXCustReturnGoods1.SetParameterValue("Date", parameter)


        CRXCustReturnGoods1 = MyReport
        CRCustomerYTDViewer.ReportSource = CRXCustReturnGoods1
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        clearItems()
    End Sub


    Private Sub CRCustomerYTDViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCustomerYTDViewer.Load
        Dim parameter As String
        'Sets up viewer to display data from the loaded dataset

        MyReport = CRXCustReturnGoods1
        CRXCustReturnGoods1 = MyReport
        parameter = cboReturnGoodNum.Text
        CRXCustReturnGoods1.SetParameterValue("GoodsAuthorizationNumber", parameter)
        parameter = cboCustomer.Text
        CRXCustReturnGoods1.SetParameterValue("Customer", parameter)
        parameter = cboCustomerName.Text
        CRXCustReturnGoods1.SetParameterValue("CustomerContact", parameter)
        parameter = cboFox.Text
        CRXCustReturnGoods1.SetParameterValue("Fox", parameter)
        parameter = txtNumberofParts.Text
        CRXCustReturnGoods1.SetParameterValue("Quantity", parameter)
        parameter = txtReason.Text
        CRXCustReturnGoods1.SetParameterValue("Reason", parameter)
        parameter = cboReturnType.Text
        CRXCustReturnGoods1.SetParameterValue("TypeOfReturn", parameter)
        parameter = txtRemark.Text
        CRXCustReturnGoods1.SetParameterValue("Remarks", parameter)
        parameter = txtDelivery.Text
        CRXCustReturnGoods1.SetParameterValue("AuthorizedTruckingFirm", parameter)
        parameter = txtPO.Text
        CRXCustReturnGoods1.SetParameterValue("PurchaseOrderNumber", parameter)
        parameter = txtPartsBy.Text
        CRXCustReturnGoods1.SetParameterValue("CustDate", parameter)
        parameter = txtSignature.Text
        CRXCustReturnGoods1.SetParameterValue("Signature", parameter)
        parameter = txtSignatureDate.Text
        CRXCustReturnGoods1.SetParameterValue("Date", parameter)

        MyReport.Refresh()
        CRXCustReturnGoods1.Refresh()
        con.Close()
    End Sub

    

    Private Sub clearItems()
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboFox.Text = ""
        txtPO.Text = ""
        cboReturnType.SelectedIndex = -1
        txtNumberofParts.Text = ""
        txtReason.Text = ""
        txtRemark.Text = ""
        txtDelivery.Text = ""
        cboDivision.SelectedIndex = -1
        cboReturnGoodNum.SelectedIndex = -1
        txtPartsBy.Text = ""
        txtSignature.Text = ""
        txtSignature.Text = ""

    End Sub
    Private Sub cmdGenerateNewSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewSO.Click
        clearItems()
        Dim dates As String = Date.Now.ToString("yy")
        Dim datestatement As String = "SELECT MAX(AuthorizationNumber) FROM RMATable Where Date BETWEEN @Value1 AND @Value2"
        Dim date1 As New Date(Now.Year, 1, 1)
        Dim date2 As New Date(Now.Year, 12, 31)

        Dim MAXCommand As New SqlCommand(datestatement, con)
        MAXCommand.Parameters.Add("@Value1", SqlDbType.VarChar).Value = date1
        MAXCommand.Parameters.Add("@Value2", SqlDbType.VarChar).Value = date2
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            LastTransactionNumber = LastTransactionNumber \ 100
        Catch ex As System.Exception
            LastTransactionNumber = 0
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        If NextTransactionNumber < 10 Then
            cboReturnGoodNum.Text = "0" + NextTransactionNumber.ToString + dates.ToString
        Else
            cboReturnGoodNum.Text = NextTransactionNumber.ToString + dates.ToString
        End If

       
    End Sub

    Private Sub LoadDivision()
        cboDivision.Items.Add("TWD")
        cboDivision.Items.Add("TFP")

        If EmployeeCompanyCode.Equals("TST") Then
            cboDivision.Items.Add("TST")
        End If

        cboDivision.SelectedIndex = -1
    End Sub

    Private Sub LoadRMA()
        Using cmd As New SqlCommand
            Try
                If GlobalDivisionCode = "TWD" Or GlobalDivisionCode = "TFP" Then

                    cmd2 = New SqlCommand("SELECT AuthorizationNumber FROM RMATable WHERE DivisionID = @DivisionID", con)
                    cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    If con.State = ConnectionState.Closed Then con.Open()
                    ds5 = New DataSet()
                    myAdapter5.SelectCommand = cmd2
                    myAdapter5.Fill(ds5, "RMATable")
                    cboReturnGoodNum.DataSource = ds5.Tables(0)
                    cboReturnGoodNum.ValueMember = "RMATable"
                    con.Close()
                    cboReturnGoodNum.SelectedIndex = -1
                End If
            Catch ex As System.Exception
            End Try
        End Using

    End Sub

    Private Sub LoadCustomer()
        Using cmd As New SqlCommand
            cmd2 = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd2
            myAdapter5.Fill(ds5, "CustomerList")
            cboCustomer.DataSource = ds5.Tables(0)
            cboCustomer.ValueMember = "CustomerID"
            con.Close()
            cboCustomer.SelectedIndex = -1
        End Using
    End Sub

    Private Sub LoadCustomerName()
        Using cm3 As New SqlCommand
            cmd3 = New SqlCommand("SELECT APContactName FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY APContactName", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd3
            myAdapter1.Fill(ds1, "CustomerList")
            cboCustomerName.DataSource = ds1.Tables("CustomerList")
            con.Close()
            cboCustomer.SelectedIndex = -1
        End Using
    End Sub

    Private Sub LoadFoxNumber()
        Using cmd4 As New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID ORDER BY FOXNumber", con)

            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd4
            myAdapter2.Fill(ds2, "FOXTable")
            cboFox.DataSource = ds2.Tables("FOXTable")
            con.Close()

        End Using
    End Sub



    Private Sub cboDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivision.SelectedIndexChanged
        LoadCustomer()
        'LoadCustomerName()

        LoadFoxNumber()
        If cboReturnGoodNum.Text = "" Then
            LoadAuthorizationNumber()
        End If
        cboFox.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboFox.Text = ""
        cboCustomerName.Text = ""
    End Sub

    Private Sub PrintCustomerReturnAuthorization_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadRMA()

        cboReturnGoodNum.SelectedIndex = -1
        LoadDivision()
        cboFox.Text = ""

        If GlobalDivisionCode = "TFP" Or GlobalDivisionCode = "TST" Or GlobalDivisionCode = "TWD" Then
            cboDivision.Text = GlobalDivisionCode
            LoadCustomer()
            LoadCustomerName()
            LoadFoxNumber()
        End If

    End Sub

    Private Sub LoadAuthorizationNumber()
        cmd5 = New SqlCommand("SELECT AuthorizationNumber FROM RMATable WHERE DivisionID = @DivisionID ORDER BY AuthorizationNumber", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds4, "RMATable")
        cboReturnGoodNum.DataSource = ds4.Tables("RMATable")
        con.Close()
        cboReturnGoodNum.SelectedIndex = -1
    End Sub
    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged
        Dim ItemDataStatement As String = "SELECT APContactName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        ItemDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text
        ItemDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Using reader As SqlDataReader = ItemDataCommand.ExecuteReader

            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("APContactName")) Then
                    cboCustomerName.Text = " "
                Else
                    cboCustomerName.Text = reader.Item("APContactName")
                End If
            End If
            reader.Close()
        End Using
    End Sub

    'Will ask if want to save information before closing the form
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this RMA Form?", "SAVE RMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If Validation() Then
                Dim exists As Boolean = False
                Dim autho As Integer = 0
                Dim ItemDataStatement As String = "SELECT AuthorizationNumber FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber"
                Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
                ItemDataCommand.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("AuthorizationNumber")) Then
                            autho = 0
                        Else
                            autho = reader.Item("AuthorizationNumber")
                        End If
                    End If
                    reader.Close()
                    Dim chosenautho = cboReturnGoodNum.Text
                    If chosenautho = autho Then
                        'update
                        cmd7 = New SqlCommand("UPDATE RMATable SET  Customer = @Customer, Date = @Date, FOXNumber = @FOXNumber, Quantity = @Quantity, Reason = @Reason, Remarks = @Remarks, AuthorizedTruckingFirm = @AuthorizedTruckingFirm, PurchaseOrderNumber = @PurchaseOrderNumber, DivisionID = @DivisionID, TypeFix = @TypeFix, CustomerContact = @CustomerContact, NeedPartsBy = @NeedPartsBy, QARepresentative = @QARepresentative, QARepDate = @QARepDate WHERE AuthorizationNumber = @OldAuthoNumber", con)
                        With cmd7.Parameters
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                            .Add("@Date", SqlDbType.VarChar).Value = Now
                            .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
                            .Add("@Quantity", SqlDbType.VarChar).Value = txtNumberofParts.Text
                            .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                            .Add("@Remarks", SqlDbType.VarChar).Value = txtRemark.Text
                            .Add("@AuthorizedTruckingFirm", SqlDbType.VarChar).Value = txtDelivery.Text
                            .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = txtPO.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                            .Add("@TypeFix", SqlDbType.VarChar).Value = cboReturnType.Text
                            .Add("@OldAuthoNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
                            .Add("@CustomerContact", SqlDbType.VarChar).Value = cboCustomerName.Text
                            .Add("@NeedPartsBy", SqlDbType.VarChar).Value = txtPartsBy.Text
                            .Add("@QARepresentative", SqlDbType.VarChar).Value = txtSignature.Text
                            .Add("@QARepDate", SqlDbType.VarChar).Value = txtSignatureDate.Text
                        End With
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd7.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Updated RMA")
                    Else
                        'insert
                        cmd7 = New SqlCommand("INSERT INTO RMATable (AuthorizationNumber, Customer, Date, FOXNumber, Quantity, Reason, Remarks, AuthorizedTruckingFirm, PurchaseOrderNumber, DivisionID, TypeFix, CustomerContact, NeedPartsBy, QARepresentative, QARepDate)Values(@AuthorizedNumber, @Customer, @Date, @FOXNumber, @Quantity, @Reason, @Remarks, @AuthorizedTruckingFirm, @PurchaseOrderNumber, @DivisionID, @TypeFix, @CustomerContact, @NeedPartsBy, @QARepresentative, @QARepDate)", con)

                        With cmd7.Parameters
                            .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomerName.Text
                            .Add("@Date", SqlDbType.VarChar).Value = Now
                            .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
                            .Add("@Quantity", SqlDbType.VarChar).Value = txtNumberofParts.Text
                            .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                            .Add("@Remarks", SqlDbType.VarChar).Value = txtRemark.Text
                            .Add("@AuthorizedTruckingFirm", SqlDbType.VarChar).Value = txtDelivery.Text
                            .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = txtPO.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                            .Add("@TypeFix", SqlDbType.VarChar).Value = cboReturnType.Text
                            .Add("@CustomerContact", SqlDbType.VarChar).Value = cboCustomerName.Text
                            .Add("@NeedPartsBy", SqlDbType.VarChar).Value = txtPartsBy.Text
                            .Add("@QARepresentative", SqlDbType.VarChar).Value = txtSignature.Text
                            .Add("@QARepDate", SqlDbType.VarChar).Value = txtSignatureDate.Text

                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd7.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved New RMA")
                    End If
                End Using
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
        End If
    End Sub
    Function Validation() As Boolean

        If cboCustomer.Text = "" Then
            MsgBox("Please Choose A Customer")
            cboCustomer.Focus()
            Return False
        End If
        If cboCustomerName.Text = "" Then
            MsgBox("Please Choose A Customers Name")
            cboCustomerName.Focus()
            Return False
        End If
        If cboDivision.Text = "" Then
            MsgBox("Please Choose A Division")
            cboDivision.Focus()
            Return False
        End If
        If cboFox.Text = "" Then
            MsgBox("Please Choose A Fox Number")
            cboFox.Focus()
            Return False
        End If
        If txtNumberofParts.Text = "" Then
            MsgBox("Please State A Quantity")
            txtNumberofParts.Focus()
            Return False
        End If
        If txtReason.Text = "" Then
            MsgBox("Please State The Reason For The Return")
            txtReason.Focus()
            Return False
        End If
        If cboReturnType.Text = "" Then
            MsgBox("Please Choose A Selection")
            cboReturnType.Focus()
            Return False
        End If
        If txtRemark.Text = "" Then
            MsgBox("Please State A Remark")
            txtRemark.Focus()
            Return False
        End If
        If txtDelivery.Text = "" Then
            MsgBox("Please State A Authorized Trucking Firm")
            txtDelivery.Focus()
            Return False
        End If
        If txtPO.Text = "" Then
            MsgBox("Please State A Purchase Order Number")
            txtPO.Focus()
            Return False
        End If
        If txtNumberofParts.Text = "" Then
            MsgBox("Please Insert A Parts By")
            txtNumberofParts.Focus()
            Return False
        End If
        If txtSignature.Text = "" Then
            MsgBox("Please Insert A Signature")
            txtSignature.Focus()
            Return False
        End If
        If txtSignature.Text = "" Then
            MsgBox("Please Insert A Signature")
            txtSignature.Focus()
            Return False
        End If
        If txtSignatureDate.Text = "" Then
            MsgBox("Please Insert A Signature Date")
            txtSignatureDate.Focus()
            Return False
        End If
        Dim ItemDataStatement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        ItemDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text
        ItemDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("CustomerID")) Then
                    cboCustomerName.Text = " "
                    MsgBox("Customer Not Valid")
                    cboCustomer.Focus()
                    reader.Close()
                    con.Close()
                    Return False
                End If
            End If
        End Using


        Dim ItemDataStatement2 As String = "SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber"
        Dim ItemDataCommand2 As New SqlCommand(ItemDataStatement2, con)
        ItemDataCommand2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        ItemDataCommand2.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Using reader2 As SqlDataReader = ItemDataCommand2.ExecuteReader()
            If reader2.HasRows Then
                reader2.Read()
                If IsDBNull(reader2.Item("FOXNumber")) Then
                    cboCustomerName.Text = " "
                    MsgBox("FOXNumber Not Valid")
                    cboFox.Focus()
                    reader2.Close()
                    con.Close()
                    Return False
                End If
            End If
        End Using
        Return True
    End Function
    Private Sub EmailAuthorizationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailAuthorizationToolStripMenuItem.Click
        'Get Login Type
        viewer()
        Dim GetLoginType As String = ""

        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetLoginType = ""
        End Try
        con.Close()

        DeleteDirectory("\\TFP-FS\TransferData\Test")
        If Not System.IO.Directory.Exists("\\TFP-FS\TransferData\Test") Then System.IO.Directory.CreateDirectory("\\TFP-FS\TransferData\Test")
        If GetLoginType = "REMOTE" Then
            'Create new Filename for Sales Confirmation
            FileDate = Today()
            monthofyear = FileDate.Month
            dayofyear = FileDate.DayOfYear
            yearofyear = FileDate.Year
            minuteofyear = FileDate.Minute
            strMonth = CStr(monthofyear)
            strDay = CStr(dayofyear)
            strYear = CStr(yearofyear)
            strMinute = CStr(minuteofyear)
            strCompany = GlobalDivisionCode

            ConfirmName = cboCustomer.Text + cboReturnGoodNum.Text

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilePath3 = ""
            TFPMailTransactionType = "Return Goods Authorization Form"
            TFPMailTransactionNumber = 0
            TFPMailCustomer = CreditVariables.emailID

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        Else

            'Create new Filename for Statement
            FileDate = Now()
            monthofyear = FileDate.Month
            dayofyear = FileDate.DayOfYear
            yearofyear = FileDate.Year
            minuteofyear = FileDate.Minute
            strMonth = CStr(monthofyear)
            strDay = CStr(dayofyear)
            strYear = CStr(yearofyear)
            strMinute = CStr(minuteofyear)
            strCompany = GlobalDivisionCode

            ConfirmName = cboCustomer.Text + cboReturnGoodNum.Text

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)

            'adding subject information to the mail message
            mail.Subject = "Return Goods Authorization Form"

            'Address Email To
            mail.To = ""

            'adding body message information to the mail message
            mail.Body = ""

            'adding attachment
            Try
                mail.Attachments.Add("\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")
            Catch ex As System.Exception

            End Try

            'display mail
            mail.Display()

            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Saves or updates information after checking if all information filled
        If Validation() Then
            Dim exists As Boolean = False
            Dim autho As Integer = 0
            Dim ItemDataStatement As String = "SELECT AuthorizationNumber FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber"
            Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
            ItemDataCommand.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("AuthorizationNumber")) Then
                        autho = 0
                    Else
                        autho = reader.Item("AuthorizationNumber")
                    End If
                End If
                reader.Close()
            End Using
            Dim chosenautho = cboReturnGoodNum.Text
            Dim comString = autho.ToString
            Dim length As Integer = comString.Length
            If length = 3 Then
                comString = "0" + comString
            End If
            If chosenautho = comString Then
                'update
                cmd = New SqlCommand("UPDATE RMATable SET  Customer = @Customer, Date = @Date, FOXNumber = @FOXNumber, Quantity = @Quantity, Reason = @Reason, Remarks = @Remarks, AuthorizedTruckingFirm = @AuthorizedTruckingFirm, PurchaseOrderNumber = @PurchaseOrderNumber, DivisionID = @DivisionID, TypeFix = @TypeFix, CustomerContact = @CustomerContact, NeedPartsBy = @NeedPartsBy, QARepresentative = @QARepresentative, QARepDate = @QARepDate WHERE AuthorizationNumber = @OldAuthoNumber", con)
                With cmd.Parameters
                    .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                    .Add("@Date", SqlDbType.VarChar).Value = Now
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = txtNumberofParts.Text
                    .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                    .Add("@Remarks", SqlDbType.VarChar).Value = txtRemark.Text
                    .Add("@AuthorizedTruckingFirm", SqlDbType.VarChar).Value = txtDelivery.Text
                    .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = txtPO.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                    .Add("@TypeFix", SqlDbType.VarChar).Value = cboReturnType.Text
                    .Add("@OldAuthoNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
                    .Add("@CustomerContact", SqlDbType.VarChar).Value = cboCustomerName.Text
                    .Add("@NeedPartsBy", SqlDbType.VarChar).Value = txtPartsBy.Text
                    .Add("@QARepresentative", SqlDbType.VarChar).Value = txtSignature.Text
                    .Add("@QARepDate", SqlDbType.VarChar).Value = txtSignatureDate.Text
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Updated RMA")
            Else
                'insert
                cmd = New SqlCommand("INSERT INTO RMATable (AuthorizationNumber, Customer, Date, FOXNumber, Quantity, Reason, Remarks, AuthorizedTruckingFirm, PurchaseOrderNumber, DivisionID, TypeFix, CustomerContact, NeedPartsBy, QARepresentative, QARepDate)Values(@AuthorizationNumber, @Customer, @Date, @FOXNumber, @Quantity, @Reason, @Remarks, @AuthorizedTruckingFirm, @PurchaseOrderNumber, @DivisionID, @TypeFix, @CustomerContact, @NeedPartsBy, @QARepresentative, @QARepDate)", con)

                With cmd.Parameters
                    .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
                    .Add("@Customer", SqlDbType.VarChar).Value = cboCustomerName.Text
                    .Add("@Date", SqlDbType.VarChar).Value = Now
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = txtNumberofParts.Text
                    .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                    .Add("@Remarks", SqlDbType.VarChar).Value = txtRemark.Text
                    .Add("@AuthorizedTruckingFirm", SqlDbType.VarChar).Value = txtDelivery.Text
                    .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = txtPO.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                    .Add("@TypeFix", SqlDbType.VarChar).Value = cboReturnType.Text
                    .Add("@CustomerContact", SqlDbType.VarChar).Value = cboCustomerName.Text
                    .Add("@NeedPartsBy", SqlDbType.VarChar).Value = txtPartsBy.Text
                    .Add("@QARepresentative", SqlDbType.VarChar).Value = txtSignature.Text
                    .Add("@QARepDate", SqlDbType.VarChar).Value = txtSignatureDate.Text

                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Saved New RMA")
            End If
            If GlobalDivisionCode = "TFP" Or GlobalDivisionCode = "TST" Or GlobalDivisionCode = "TWD" Then
                cmd = New SqlCommand("SELECT DISTINCT AuthorizationNumber FROM RMATable WHERE DivisionID = @DivisionID ORDER BY AuthorizationNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                If con.State = ConnectionState.Closed Then con.Open()
                ds3 = New DataSet()
                myAdapter3.SelectCommand = cmd
                myAdapter3.Fill(ds3, "RMATable")
                cboReturnGoodNum.DataSource = ds3.Tables("RMATable")
                con.Close()
                cboReturnGoodNum.SelectedIndex = -1
            End If
        End If
    End Sub

    'Displays relevant information for the selected Authorization number
    Private Sub cboReturnGoodNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReturnGoodNum.SelectedIndexChanged
        Dim ItemDataStatement5 As String = "SELECT Customer, FOXNumber, Quantity, Reason, Remarks, PurchaseOrderNumber, DivisionID, TypeFix, AuthorizedTruckingFirm, CustomerContact, NeedPartsBy, QARepresentative, QARepDate FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber"
        Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
        ItemDataCommand5.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
        Dim Customer, Fox, Quantity, Reason, Remarks, PO, Division, Fix, ATF, CC, NPB, QAR, QARD As String
        If con.State = ConnectionState.Closed Then con.Open()
        Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
            Try

                If reader5.HasRows Then
                    reader5.Read()
                    If IsDBNull(reader5.Item("Customer")) Then
                        Customer = " "
                    Else
                        Customer = reader5.Item("Customer")
                    End If
                    If IsDBNull(reader5.Item("FOXNumber")) Then
                        Fox = " "
                    Else
                        Fox = reader5.Item("FOXNumber")
                    End If
                    If IsDBNull(reader5.Item("Quantity")) Then
                        Quantity = " "
                    Else
                        Quantity = reader5.Item("Quantity")
                    End If
                    If IsDBNull(reader5.Item("Reason")) Then
                        Reason = " "
                    Else
                        Reason = reader5.Item("Reason")
                    End If
                    If IsDBNull(reader5.Item("Remarks")) Then
                        Remarks = " "
                    Else
                        Remarks = reader5.Item("Remarks")
                    End If
                    If IsDBNull(reader5.Item("PurchaseOrderNumber")) Then
                        PO = " "
                    Else
                        PO = reader5.Item("PurchaseOrderNumber")
                    End If
                    If IsDBNull(reader5.Item("DivisionID")) Then
                        Division = " "
                    Else
                        Division = reader5.Item("DivisionID")
                    End If
                    If IsDBNull(reader5.Item("TypeFix")) Then
                        Fix = " "
                    Else
                        Fix = reader5.Item("TypeFix")
                    End If
                    If IsDBNull(reader5.Item("AuthorizedTruckingFirm")) Then
                        ATF = " "
                    Else
                        ATF = reader5.Item("AuthorizedTruckingFirm")
                    End If
                    If IsDBNull(reader5.Item("CustomerContact")) Then
                        CC = ""
                    Else
                        CC = reader5.Item("CustomerContact")
                    End If
                    If IsDBNull(reader5.Item("NeedPartsBy")) Then
                        NPB = ""
                    Else
                        NPB = reader5.Item("NeedPartsBy")
                    End If
                    If IsDBNull(reader5.Item("QARepresentative")) Then
                        QAR = ""
                    Else
                        QAR = reader5.Item("QARepresentative")
                    End If
                    If IsDBNull(reader5.Item("QARepDate")) Then
                        QARD = ""
                    Else
                        QARD = reader5.Item("QARepDate")
                    End If
                    reader5.Close()
                Else
                    Division = ""
                    Customer = ""
                    Fox = ""
                    Remarks = ""
                    Reason = ""
                    PO = ""
                    ATF = ""
                    Quantity = ""
                    Fix = ""
                    CC = ""
                    NPB = ""
                    QAR = ""
                    QARD = ""
                End If
                cboCustomer.Text = Customer
                cboDivision.Text = Division
                cboFox.Text = Fox
                txtRemark.Text = Remarks
                txtReason.Text = Reason
                txtPO.Text = PO
                txtDelivery.Text = ATF
                txtNumberofParts.Text = Quantity
                cboReturnType.Text = Fix
                cboCustomerName.Text = CC
                txtPartsBy.Text = NPB
                txtSignature.Text = QAR
                txtSignatureDate.Text = QARD

               

            Catch ex As System.Exception

            End Try
        End Using

    End Sub
    Private Sub viewer()
        Dim parameter As String



        'Sets up viewer to display data from the loaded dataset
        cmd = New SqlCommand("SELECT PartNumber, BlueprintRevision FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text


        cmd1 = New SqlCommand("SELECT BlueprintNumber, LongDescription FROM FOXTableQuery WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFox.Text
        cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTable")
        MyReport = CRXCustReturnGoods1
        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "FOXTableQuery")
        MyReport.SetDataSource(ds)

        parameter = cboReturnGoodNum.Text
        CRXCustReturnGoods1.SetParameterValue("GoodsAuthorizationNumber", parameter)
        parameter = cboCustomer.Text
        CRXCustReturnGoods1.SetParameterValue("Customer", parameter)
        parameter = cboCustomerName.Text
        CRXCustReturnGoods1.SetParameterValue("CustomerContact", parameter)
        parameter = cboFox.Text
        CRXCustReturnGoods1.SetParameterValue("Fox", parameter)
        parameter = txtNumberofParts.Text
        CRXCustReturnGoods1.SetParameterValue("Quantity", parameter)
        parameter = txtReason.Text
        CRXCustReturnGoods1.SetParameterValue("Reason", parameter)
        parameter = cboReturnType.Text
        CRXCustReturnGoods1.SetParameterValue("TypeOfReturn", parameter)
        parameter = txtRemark.Text
        CRXCustReturnGoods1.SetParameterValue("Remarks", parameter)
        parameter = txtDelivery.Text
        CRXCustReturnGoods1.SetParameterValue("AuthorizedTruckingFirm", parameter)
        parameter = txtPO.Text
        CRXCustReturnGoods1.SetParameterValue("PurchaseOrderNumber", parameter)



        CRXCustReturnGoods1 = MyReport
        CRCustomerYTDViewer.ReportSource = CRXCustReturnGoods1
        con.Close()
    End Sub

    'Depending on the number written into the combobox, will try to display the relevant information
    Private Sub cboReturnGoodNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReturnGoodNum.TextChanged
        Try
            Dim ItemDataStatement5 As String = "SELECT Customer, FOXNumber, Quantity, Reason, Remarks, PurchaseOrderNumber, DivisionID, TypeFix, AuthorizedTruckingFirm, CustomerContact, NeedPartsBy, QARepresentative, QARepDate FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber"
            Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
            ItemDataCommand5.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text
            Dim Customer, Fox, Quantity, Reason, Remarks, PO, Division, Fix, ATF, CC, NPB, QAR, QARD As String
            If con.State = ConnectionState.Closed Then con.Open()
            Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
                Try

                    If reader5.HasRows Then
                        reader5.Read()
                        If IsDBNull(reader5.Item("Customer")) Then
                            Customer = " "
                        Else
                            Customer = reader5.Item("Customer")
                        End If
                        If IsDBNull(reader5.Item("FOXNumber")) Then
                            Fox = " "
                        Else
                            Fox = reader5.Item("FOXNumber")
                        End If
                        If IsDBNull(reader5.Item("Quantity")) Then
                            Quantity = " "
                        Else
                            Quantity = reader5.Item("Quantity")
                        End If
                        If IsDBNull(reader5.Item("Reason")) Then
                            Reason = " "
                        Else
                            Reason = reader5.Item("Reason")
                        End If
                        If IsDBNull(reader5.Item("Remarks")) Then
                            Remarks = " "
                        Else
                            Remarks = reader5.Item("Remarks")
                        End If
                        If IsDBNull(reader5.Item("PurchaseOrderNumber")) Then
                            PO = " "
                        Else
                            PO = reader5.Item("PurchaseOrderNumber")
                        End If
                        If IsDBNull(reader5.Item("DivisionID")) Then
                            Division = " "
                        Else
                            Division = reader5.Item("DivisionID")
                        End If
                        If IsDBNull(reader5.Item("TypeFix")) Then
                            Fix = " "
                        Else
                            Fix = reader5.Item("TypeFix")
                        End If
                        If IsDBNull(reader5.Item("AuthorizedTruckingFirm")) Then
                            ATF = " "
                        Else
                            ATF = reader5.Item("AuthorizedTruckingFirm")
                        End If
                        If IsDBNull(reader5.Item("CustomerContact")) Then
                            CC = ""
                        Else
                            CC = reader5.Item("CustomerContact")
                        End If
                        If IsDBNull(reader5.Item("NeedPartsBy")) Then
                            NPB = ""
                        Else
                            NPB = reader5.Item("NeedPartsBy")
                        End If
                        If IsDBNull(reader5.Item("QARepresentative")) Then
                            QAR = ""
                        Else
                            QAR = reader5.Item("QARepresentative")
                        End If
                        If IsDBNull(reader5.Item("QARepDate")) Then
                            QARD = ""
                        Else
                            QARD = reader5.Item("QARepDate")
                        End If
                        reader5.Close()
                    Else
                        Division = ""
                        Customer = ""
                        Fox = ""
                        Remarks = ""
                        Reason = ""
                        PO = ""
                        ATF = ""
                        Quantity = ""
                        Fix = ""
                        CC = ""
                        NPB = ""
                        QAR = ""
                        QARD = ""
                    End If
                    cboCustomer.Text = Customer
                    cboDivision.Text = Division
                    cboFox.Text = Fox
                    txtRemark.Text = Remarks
                    txtReason.Text = Reason
                    txtPO.Text = PO
                    txtDelivery.Text = ATF
                    txtNumberofParts.Text = Quantity
                    cboReturnType.Text = Fix
                    cboCustomerName.Text = CC
                    txtPartsBy.Text = NPB
                    txtSignature.Text = QAR
                    txtSignatureDate.Text = QARD

                    

                Catch ex As System.Exception

                End Try
            End Using


        Catch ex As System.Exception

        End Try
    End Sub


    Private Sub ViewAllRMAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllRMAsToolStripMenuItem.Click
        Dim NewViewAllRMA As New ViewAllRMA
        NewViewAllRMA.Show()
    End Sub

    Private Sub DeleteCurrentRMAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCurrentRMAToolStripMenuItem.Click
        'Delete Data in the RMATable
        Try
            cmd = New SqlCommand("DELETE FROM RMATable WHERE AuthorizationNumber = @AuthorizationNumber", con)
            cmd.Parameters.Add("@AuthorizationNumber", SqlDbType.VarChar).Value = cboReturnGoodNum.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Record Deleted")
        Catch ex As System.Exception
            MsgBox("Record Does Not Exists")

        End Try
    End Sub

End Class