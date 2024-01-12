Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class SelectReceiverLines
    Inherits System.Windows.Forms.Form

    Dim LastGLNumber, NextGLNumber, LineNumber As Integer
    Dim DebitGLAccount, CreditGLAccount As String
    Dim ExtendedAmount, FreightCharge, SalesTax, ProductTotal, ReceiverTotal As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim poNumber As String = ""
    Dim receivingNumber As String = ""
    Dim divisionID As String = ""

    Dim isloaded = False

    Private Sub SelectReceiverLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"
        isloaded = True
    End Sub

    Public Sub ShowReceiverLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND LineStatus = @LineStatus AND DivisionID = @DivisionID AND POQuantityOpen > 0 ORDER BY PurchaseOrderLineNumber ASC", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = poNumber
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderQuantityStatus")
        dgvReceiverLines.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        con.Close()

        If dgvReceiverLines.Rows.Count > 0 And (divisionID = "TWD" Or divisionID = "TWE") Then
            Dim i As Integer = 0
            isloaded = False
            While i < dgvReceiverLines.Rows.Count
                dgvReceiverLines.Rows(i).Cells("POQuantityOpenColumn").Value = 0
                i += 1
            End While
            isloaded = True
        End If
    End Sub

    Public Sub CalculateReceiverTotals()
        Dim FreightChargeString As String = "SELECT FreightCharge, SalesTax FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim FreightChargeCommand As New SqlCommand(FreightChargeString, con)
        FreightChargeCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
        FreightChargeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID

        Dim ProductTotalString As String = "SELECT SUM(ExtendedAmount) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
        ProductTotalCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = FreightChargeCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                FreightCharge = 0
            Else
                FreightCharge = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                SalesTax = 0
            Else
                SalesTax = reader.GetValue(1)
            End If
        Else
            FreightCharge = 0
            SalesTax = 0
        End If
        reader.Close()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        If cantContinue() Then
            Exit Sub
        End If

        'Retrieve line data from PO Table and write to Receipt Of Invoice Table
        Dim LineComment, CreditGLAccount, DebitGLAccount, PartDescription, PartNumber As String
        Dim POLineNumber As Integer
        Dim UnitCost As Double = 0
        Dim OpenQuantity As Double = 0

        For Each row As DataGridViewRow In dgvReceiverLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReceipt")

            If cell.Value = "SELECTED" Then
                Try
                    POLineNumber = row.Cells("PurchaseOrderLineNumberColumn").Value
                Catch ex As Exception
                    POLineNumber = 1
                End Try
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    OpenQuantity = row.Cells("POQuantityOpenColumn").Value
                Catch ex As Exception
                    OpenQuantity = 0
                End Try
                Try
                    UnitCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    UnitCost = 0
                End Try
                Try
                    DebitGLAccount = row.Cells("DebitGLAccountColumn").Value
                    If DebitGLAccount = "" Then
                        DebitGLAccount = "20999"
                    End If
                Catch ex As Exception
                    DebitGLAccount = "20999"
                End Try
                Try
                    CreditGLAccount = row.Cells("CreditGLAccountColumn").Value
                    If CreditGLAccount = "" Then
                        CreditGLAccount = "12100"
                    End If
                Catch ex As Exception
                    CreditGLAccount = "12100"
                End Try
                Try
                    LineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    LineComment = ""
                End Try

                ExtendedAmount = OpenQuantity * UnitCost
                LineNumber = POLineNumber

                ExtendedAmount = Math.Round(ExtendedAmount, 2)
                UnitCost = Math.Round(UnitCost, 6)

                cmd = New SqlCommand("SELECT POLineNumber FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)
                cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                Dim shouldInsert As Boolean = True
                If reader.HasRows Then
                    While reader.Read()
                        If reader.GetValue(0) = POLineNumber Then
                            shouldInsert = False
                            Exit While
                        End If
                    End While
                End If
                reader.Close()
                con.Close()
                If shouldInsert Then

                    cmd = New SqlCommand("SELECT MAX(ReceivingLineKey) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)
                    cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim nextLineNumber As Integer = 1
                    Try
                        nextLineNumber = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                    Catch ex As Exception

                    End Try
                    con.Close()
                    Try
                        'Write Data to Receiving Line Database Table
                        cmd = New SqlCommand("Insert Into ReceivingLineTable(ReceivingHeaderKey, ReceivingLineKey, PartNumber, PartDescription, QuantityReceived, UnitCost, ExtendedAmount, LineStatus, DivisionID, SelectForInvoice, DebitGLAccount, CreditGLAccount, POLineNumber, LineComment, DropShip) Values (@ReceivingHeaderKey, @ReceivingLineKey, @PartNumber, @PartDescription, @QuantityReceived, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @SelectForInvoice, @DebitGLAccount, @CreditGLAccount, @POLineNumber, @LineComment, @DropShip)", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
                            .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = nextLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@QuantityReceived", SqlDbType.VarChar).Value = OpenQuantity
                            .Add("@UnitCost", SqlDbType.VarChar).Value = UnitCost
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@DebitGLAccount", SqlDbType.VarChar).Value = DebitGLAccount
                            .Add("@CreditGLAccount", SqlDbType.VarChar).Value = CreditGLAccount
                            .Add("@POLineNumber", SqlDbType.VarChar).Value = POLineNumber
                            .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                            .Add("@DropShip", SqlDbType.VarChar).Value = "NO"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        UnitCost = 0
                        OpenQuantity = 0
                        ExtendedAmount = 0
                        PartDescription = ""
                        PartNumber = ""
                        DebitGLAccount = ""
                        CreditGLAccount = ""
                        LineComment = ""
                        POLineNumber = 0
                    Catch ex As Exception
                        'Skip line if already added
                        sendErrorToDataBase("SelectReceiverLines - cmdSaveLines_Click --Line # " + nextLineNumber + " failed to insert", "Receiving #" + receivingNumber, ex.ToString())
                    End Try
                End If
            End If
        Next

        'UPDATE Totals
        CalculateReceiverTotals()

        FreightCharge = Math.Round(FreightCharge, 2)
        SalesTax = Math.Round(SalesTax, 2)
        ProductTotal = Math.Round(ProductTotal, 2)
        ReceiverTotal = Math.Round(ReceiverTotal, 2)

        Try
            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET FreightCharge = @FreightCharge, SalesTax = @SalesTax, ProductTotal = @ProductTotal, POTotal = @POTotal WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
                .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                .Add("SalesTax", SqlDbType.VarChar).Value = SalesTax
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@POTotal", SqlDbType.VarChar).Value = ReceiverTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            sendErrorToDataBase("SelectReceiverLines - cmdSaveLines_Click --Error trying to update totals in ReceivingHeaderTable", "Receiving #" + GlobalSelectLinesReceiverNumber.ToString(), ex.ToString())
        End Try

        'Prompt before continuing
        MsgBox("A Receiving Ticket has been created", MsgBoxStyle.OkOnly)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
        Me.Close()
    End Sub

    Private Function cantContinue() As Boolean
        Dim aboveFound As Boolean = False
        Dim msg As String = "You are receiving item(s)"
        For i As Integer = 0 To dgvReceiverLines.Rows.Count - 1
            If dgvReceiverLines.Rows(i).Cells("POQuantityOpenColumn").Value > dgvReceiverLines.Rows(i).Cells("OrderQuantityColumn").Value - dgvReceiverLines.Rows(i).Cells("POQuantityReceivedColumn").Value Then
                If aboveFound = False Then
                    aboveFound = True
                    msg += " " + dgvReceiverLines.Rows(i).Cells("PartNumberColumn").Value
                Else
                    msg += ", " + dgvReceiverLines.Rows(i).Cells("PartNumberColumn").Value
                End If

            End If
        Next
        If aboveFound Then
            Dim rslt As DialogResult = MessageBox.Show(msg + " with quantities above what is ordered, do you wish to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rslt <> DialogResult.Yes Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvReceiverLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReceipt")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvReceiverLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReceipt")
            cell.Value = "UNSELECTED"
        Next
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

    Public Sub setDivisionID(ByVal divis As String)
        divisionID = divis
        If divisionID = "ADM" Then
            cmdClearAll.Visible = False
            cmdSelectAll.Visible = False
            dgvReceiverLines.Columns("OrderQuantityColumn").Visible = False
            dgvReceiverLines.Columns("POQuantityReceivedColumn").Visible = False
        End If
        dgvReceiverLines.Columns("POQuantityOpenColumn").ReadOnly = False
    End Sub

    Public Sub setReceivingTicketNumber(ByVal receiving As String)
        receivingNumber = receiving
    End Sub

    Public Sub setPONumber(ByVal po As String)
        poNumber = po
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = divisionID
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub dgvReceiverLines_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceiverLines.CellValueChanged
        If isloaded Then
            If dgvReceiverLines.Rows.Count > 0 Then
                If dgvReceiverLines.CurrentCell.ColumnIndex = dgvReceiverLines.Columns("POQuantityOpenColumn").Index Then
                    If dgvReceiverLines.Rows(dgvReceiverLines.CurrentCell.RowIndex).Cells("SelectForReceipt").Value <> "SELECTED" Then
                        dgvReceiverLines.Rows(dgvReceiverLines.CurrentCell.RowIndex).Cells("SelectForReceipt").Value = "SELECTED"
                    End If
                End If
            End If
        End If
    End Sub
End Class