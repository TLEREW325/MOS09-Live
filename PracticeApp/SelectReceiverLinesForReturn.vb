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
Public Class SelectReceiverLinesForReturn
    Inherits System.Windows.Forms.Form

    Dim LastLineNumber, NextLineNumber As Integer
    Dim ExtendedCost As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, nmyAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Dim poNumber As String = ""
    Dim returnNumber As String = ""
    Dim divisionID As String = ""

    Private Sub SelectReceiverLinesForReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Disable Close Button on form
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"
    End Sub

    Public Sub LoadReceiverLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM ReceivingLineQuery WHERE PONumber = @PONumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = poNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingLineQuery")
        dgvReceivingLines.DataSource = ds.Tables("ReceivingLineQuery")
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        'Retrieve line data from Receiver Table and write to Vendor Return Table
        For Each row As DataGridViewRow In dgvReceivingLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReturn")

            If cell.Value = "SELECTED" Then
                Dim ReceiverNumber As Integer = row.Cells("ReceivingHeaderKeyColumn").Value
                Dim ReceiverLineNumber As Integer = row.Cells("ReceivingLineKeyColumn").Value
                Dim PartNumber As String = row.Cells("PartNumberColumn").Value
                Dim PartDescription As String = row.Cells("PartDescriptionColumn").Value
                Dim Quantity As Double = row.Cells("QuantityReceivedColumn").Value
                Dim UnitCost As Double = row.Cells("UnitCostColumn").Value
                Dim CreditGLAccount As String = row.Cells("CreditGLAccountColumn").Value
                Dim DebitGLAccount As String = row.Cells("DebitGLAccountColumn").Value

                ExtendedCost = Quantity * UnitCost
                ExtendedCost = Math.Round(ExtendedCost, 2)

                'Make sure Debit GL Account is not drop ship clearing
                If DebitGLAccount = "20990" Then
                    DebitGLAccount = "20999"
                End If

                'Find next Line Number
                Dim MAXLineStatement As String = "SELECT MAX(ReturnLineNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                MAXLineCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber
                MAXLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = divisionID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                Catch ex As Exception
                    LastLineNumber = 0
                End Try
                con.Close()

                NextLineNumber = LastLineNumber + 1

                'Write Line data to new table
                Try

                    cmd = New SqlCommand("Insert Into VendorReturnLine(ReturnNumber, ReturnLineNumber, PartNumber, PartDescription, Quantity, Cost, LineComment, ExtendedAmount, DebitGLAccount, CreditGLAccount, LineStatus, DivisionID, ReceiverNumber, ReceiverLineNumber)Values(@ReturnNumber, @ReturnLineNumber, @PartNumber, @PartDescription, @Quantity, @Cost, @LineComment, @ExtendedAmount, @DebitGLAccount, @CreditGLAccount, @LineStatus, @DivisionID, @ReceiverNumber, @ReceiverLineNumber)", con)

                    With cmd.Parameters
                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = returnNumber
                        .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                        .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                        .Add("@Cost", SqlDbType.VarChar).Value = UnitCost
                        .Add("@LineComment", SqlDbType.VarChar).Value = "VENDOR RETURN"
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedCost
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = DebitGLAccount
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = CreditGLAccount
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
                        .Add("@ReceiverNumber", SqlDbType.VarChar).Value = ReceiverNumber
                        .Add("@ReceiverLineNumber", SqlDbType.VarChar).Value = ReceiverLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    sendErrorToDataBase("SelectReceiverLinesForReturn - cmdSaveLines_Click --Error trying to insert line part #" + PartNumber + " to VendorReturnLine", "Return #" + returnNumber, ex.ToString())
                    MessageBox.Show("There was an error with processing the selected lines. Contact system admin", "Error processing lines", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        Next

        MsgBox("Lines have been selected", MsgBoxStyle.OkOnly)

        Me.DialogResult = Windows.Forms.DialogResult.Yes

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvReceivingLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReturn")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvReceivingLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForReturn")
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
    End Sub

    Public Sub setReturnNumber(ByVal ret As String)
        returnNumber = ret
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
End Class