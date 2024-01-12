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
Public Class SelectItemsForCustomerReturn
    Inherits System.Windows.Forms.Form

    Dim FreightTotal, SalesTaxTotal, ProductTotal, ReturnTotal As Double
    Dim NextLineNumber, MAXLineNumber, LineNumber, SOLineNumber, LastGLNumber, NextGLNumber As Integer
    Dim ExtendedAmount As Double
    Dim GSTRate, PSTRate, HSTRate, GSTTotal, PSTTotal, HSTTotal As Double
    Dim salesOrderNumber As String = ""
    Dim returnNumber As String = ""
    Dim divisionID As String = ""
    Dim customerID As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub CalculateReturnTotals()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber

        Dim FreightTotalStatement As String = "SELECT FreightTotal FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber"
        Dim FreightTotalCommand As New SqlCommand(FreightTotalStatement, con)
        FreightTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber

        Dim SalesTaxTotalStatement As String = "SELECT SUM(SalesTax) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber"
        Dim SalesTaxTotalCommand As New SqlCommand(SalesTaxTotalStatement, con)
        SalesTaxTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
        Catch ex As Exception
            FreightTotal = 0
        End Try
        Try
            SalesTaxTotal = CDbl(SalesTaxTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTaxTotal = 0
        End Try
        con.Close()

        ProductTotal = Math.Round(ProductTotal, 2)
        SalesTaxTotal = Math.Round(SalesTaxTotal, 2)

        ReturnTotal = ProductTotal + FreightTotal + SalesTaxTotal
        PSTTotal = 0
        HSTTotal = 0
    End Sub

    Public Sub CalculateReturnTotalsCanadian()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber

        Dim FreightTotalStatement As String = "SELECT FreightTotal FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber"
        Dim FreightTotalCommand As New SqlCommand(FreightTotalStatement, con)
        FreightTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            FreightTotal = CDbl(FreightTotalCommand.ExecuteScalar)
        Catch ex As Exception
            FreightTotal = 0
        End Try
        con.Close()

        'Get Canadian Tax Rates
        GSTTotal = ProductTotal * GSTRate
        PSTTotal = ProductTotal * PSTRate
        HSTTotal = ProductTotal * HSTRate

        GSTTotal = Math.Round(GSTTotal, 2)
        PSTTotal = Math.Round(PSTTotal, 2)
        HSTTotal = Math.Round(HSTTotal, 2)
        SalesTaxTotal = GSTTotal

        ReturnTotal = ProductTotal + FreightTotal + SalesTaxTotal + PSTTotal + HSTTotal
    End Sub

    Public Sub LoadCanadianTaxRate()
        Dim GSTRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GSTRateCommand As New SqlCommand(GSTRateStatement, con)
        GSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        GSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID

        Dim PSTRateStatement As String = "SELECT SalesTaxRate2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim PSTRateCommand As New SqlCommand(PSTRateStatement, con)
        PSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        PSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID

        Dim HSTRateStatement As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim HSTRateCommand As New SqlCommand(HSTRateStatement, con)
        HSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerID
        HSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GSTRate = CDbl(GSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            GSTRate = 0
        End Try
        Try
            PSTRate = CDbl(PSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            PSTRate = 0
        End Try
        Try
            HSTRate = CDbl(HSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            HSTRate = 0
        End Try
        con.Close()
    End Sub

    Public Sub ShowSalesOrderLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = salesOrderNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineTable")
        con.Close()
        dgvSalesOrderLines.DataSource = ds.Tables("SalesOrderLineTable")
    End Sub

    Private Sub SelectItemsForCustomerReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call Disable(Me)
        GlobalVerifyCode = "FAILED"
        'ShowSalesOrderLines()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvSalesOrderLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForCustomerReturn")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvSalesOrderLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForCustomerReturn")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        'Retrieve line data from PO Table and write to Receipt Of Invoice Table
        Dim SOLineNumber As Integer
        Dim LineComment, PartNumber, PartDescription, CreditGLAccount, DebitGLAccount As String
        Dim Quantity, Price, SalesTax, LineSalesTax As Double

        For Each row As DataGridViewRow In dgvSalesOrderLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForCustomerReturn")

            If cell.Value = "SELECTED" Then
                Try
                    SOLineNumber = row.Cells("SalesOrderLineKeyColumn").Value
                Catch ex As Exception
                    SOLineNumber = 0
                End Try
                Try
                    PartNumber = row.Cells("ItemIDColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("DescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    Price = row.Cells("PriceColumn").Value
                Catch ex As Exception
                    Price = 0
                End Try
                Try
                    SalesTax = row.Cells("SalesTaxColumn").Value
                Catch ex As Exception
                    SalesTax = 0
                End Try
                Try
                    CreditGLAccount = row.Cells("CreditGLAccountColumn").Value
                Catch ex As Exception
                    CreditGLAccount = "12100"
                End Try
                Try
                    DebitGLAccount = row.Cells("DebitGLAccountColumn").Value
                Catch ex As Exception
                    DebitGLAccount = "49999"
                End Try
                Try
                    LineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    LineComment = ""
                End Try

                ExtendedAmount = Quantity * Price
                LineNumber = SOLineNumber
                ExtendedAmount = Math.Round(ExtendedAmount, 2)

                If divisionID = "TFF" Or divisionID = "TOR" Or divisionID = "ALB" Then
                    LineSalesTax = 0
                End If

                cmd = New SqlCommand("SELECT Quantity FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND SOLineNumber= @SOLine", con)
                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber
                cmd.Parameters.Add("@SOLine", SqlDbType.VarChar).Value = SOLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    Quantity += reader.GetValue(0)
                    reader.Close()
                    con.Close()
                    Dim taxAmount As Double = 0
                    If SalesTax > 0 Then
                        taxAmount = SalesTax / ExtendedAmount
                    End If

                    ExtendedAmount = Quantity * Price
                    SalesTax = Math.Round((taxAmount * ExtendedAmount), 5)
                    ExtendedAmount = Math.Round(ExtendedAmount, 2)

                    If divisionID = "TFF" Or divisionID = "TOR" Or divisionID = "ALB" Then
                        LineSalesTax = 0
                    End If

                    Try
                        cmd = New SqlCommand("UPDATE ReturnProductLineTable SET Quantity = @Quantity, ExtendedAmount = @ExtendedAmount, SalesTax = @SalesTax WHERE ReturnNumber = @ReturnNumber AND SOLineNumber= @SOLine", con)
                        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber
                        cmd.Parameters.Add("@SOLine", SqlDbType.VarChar).Value = SOLineNumber
                        cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                        cmd.Parameters.Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                        cmd.Parameters.Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        sendErrorToDataBase("SelectItemsForCustomerReturn - cmdSaveLines_Click --Error updating sales order line #" + SOLineNumber.ToString() + " in ReturnProductLineTable", "Return #" + returnNumber, ex.ToString())
                        MessageBox.Show("An error has occured, please contact system admin and report this", "Unable to complete process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End Try
                Else
                    reader.Close()
                    con.Close()
                    'Get Max Line
                    Dim MAXLineNumberStatement As String = "SELECT MAX(ReturnLineNumber) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber"
                    Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
                    MAXLineNumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXLineNumber = 0
                    End Try
                    con.Close()

                    NextLineNumber = MAXLineNumber + 1

                    'Rounds Variables
                    SalesTax = Math.Round(SalesTax, 2)
                    ExtendedAmount = Math.Round(ExtendedAmount, 2)

                    Try
                        'Write Data to Receiving Line Database Table
                        cmd = New SqlCommand("Insert Into ReturnProductLineTable(ReturnNumber, ReturnLineNumber, PartNumber, Description, Quantity, UnitPrice, ExtendedAmount, DivisionID, LineStatus, DebitGLAccount, CreditGLAccount, SalesTax, SOLineNumber, ExtendedCOS, LineComment) Values (@ReturnNumber, @ReturnLineNumber, @PartNumber, @Description, @Quantity, @UnitPrice, @ExtendedAmount, @DivisionID, @LineStatus, @DebitGLAccount, @CreditGLAccount, @SalesTax, @SOLineNumber, @ExtendedCOS, @LineComment)", con)

                        With cmd.Parameters
                            .Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber
                            .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                            .Add("@UnitPrice", SqlDbType.VarChar).Value = Price
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                            .Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@DebitGLAccount", SqlDbType.VarChar).Value = CreditGLAccount
                            .Add("@CreditGLAccount", SqlDbType.VarChar).Value = DebitGLAccount
                            .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                            .Add("@SOLineNumber", SqlDbType.VarChar).Value = SOLineNumber
                            .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                            .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        sendErrorToDataBase("SelectItemForCustomerReturn - cmdSaveLine_Click --Error trying to insert part #" + PartNumber + " from sales order #" + salesOrderNumber.ToString() + "into ReturnProductLineTable", "Return #" + returnNumber, ex.ToString())
                        MessageBox.Show("An error has occured, please contact system admin and report this", "Unable to complete process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End Try
                End If
            End If
        Next

        'UPDATE Totals
        If divisionID = "TFF" Or divisionID = "TOR" Or divisionID = "ALB" Then
            LoadCanadianTaxRate()
            CalculateReturnTotalsCanadian()
        Else
            CalculateReturnTotals()
        End If

        Try
            'Update Return Header Table
            cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET FreightTotal = @FreightTotal, SalesTaxTotal = @SalesTaxTotal, ProductTotal = @ProductTotal, OtherTotal = @OtherTotal, ReturnTotal = @ReturnTotal, SalesTax2Total = @SalesTax2Total, SalesTax3Total = @SalesTax3Total WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
                .Add("@FreightTotal", SqlDbType.VarChar).Value = FreightTotal
                .Add("SalesTaxTotal", SqlDbType.VarChar).Value = SalesTaxTotal
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@OtherTotal", SqlDbType.VarChar).Value = 0
                .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
                .Add("@SalesTax2Total", SqlDbType.VarChar).Value = PSTTotal
                .Add("@SalesTax3Total", SqlDbType.VarChar).Value = HSTTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            sendErrorToDataBase("SelectItemForCustomerReturn - cmdSaveLine_Click --Error trying to update ReturnProductHeaderTable with updated totals", "Return #" + returnNumber, ex.ToString())
            MessageBox.Show("An error has occured, please contact system admin and report this", "Unable to complete process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

        'Prompt before continuing
        MsgBox("Return Items have been selected.", MsgBoxStyle.OkOnly)

        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Dispose()
        Me.Close()
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Private Sub LoginPage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    ''sets the SO number
    Public Sub setSalesOrderNumber(ByVal inSO As String)
        salesOrderNumber = inSO
    End Sub

    ''sets the return number
    Public Sub setReturnNumber(ByVal inReturn As String)
        returnNumber = inReturn
    End Sub

    ''sets the division ID
    Public Sub setDivisionID(ByVal inDivision As String)
        divisionID = inDivision
    End Sub

    ''sets the customer ID
    Public Sub setCustomerID(ByVal inCustomer As String)
        customerID = inCustomer
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 200 Then
            errorMessage = errorMessage.Substring(0, 200)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)

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