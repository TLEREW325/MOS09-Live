Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class SelectSteelLinesForReceiving
    Inherits System.Windows.Forms.Form

    Dim LastGLNumber, NextGLNumber, LineNumber, LastLineNumber As Integer
    Dim DebitGLAccount, CreditGLAccount As String
    Dim ExtendedAmount, FreightCharge, SalesTax, ProductTotal, ReceiverTotal As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim receivingNumber As String = ""
    Dim poNumber As String = ""

    Dim isLoaded As Boolean = False

    Public Sub ShowReceiverLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT SteelPurchaseOrderHeaderKey, SteelPurchaseLineNumber, RMID, Carbon, SteelSize, PurchasePricePerPound, PurchaseQuantity, ReceivedWeight, QuantityOpen FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @PONumber AND LineStatus = @LineStatus AND QuantityOpen > 0", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = poNumber
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelPurchaseQuantityStatus")
        con.Close()

        dgvSteelPOLines.DataSource = ds.Tables("SteelPurchaseQuantityStatus")

        dgvSteelPOLines.Columns("SteelPurchaseOrderHeaderKey").Visible = False
        dgvSteelPOLines.Columns("SteelPurchaseLineNumber").Visible = False
        dgvSteelPOLines.Columns("RMID").Visible = False
        dgvSteelPOLines.Columns("PurchasePricePerPound").Visible = False

        dgvSteelPOLines.Columns("PurchaseQuantity").ReadOnly = True
        dgvSteelPOLines.Columns("ReceivedWeight").ReadOnly = True
        dgvSteelPOLines.Columns("Carbon").ReadOnly = True
        dgvSteelPOLines.Columns("SteelSize").ReadOnly = True

        dgvSteelPOLines.Columns("ReceivedWeight").HeaderText = "Received Weight"
        dgvSteelPOLines.Columns("PurchaseQuantity").HeaderText = "Purchase Quantity"
        dgvSteelPOLines.Columns("SteelSize").HeaderText = "Steel Size"
        dgvSteelPOLines.Columns("QuantityOpen").HeaderText = "Quantity Open"

        dgvSteelPOLines.Columns("QuantityOpen").DefaultCellStyle.BackColor = Color.LightGray
    End Sub

    Private Sub SelectSteelLinesForReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        'GlobalVerifyCode = "FAILED"
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For i As Integer = 0 To dgvSteelPOLines.Rows.Count - 1
            dgvSteelPOLines.Rows(i).Cells("selectForReceiving").Value = True
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For i As Integer = 0 To dgvSteelPOLines.Rows.Count - 1
            dgvSteelPOLines.Rows(i).Cells("selectForReceiving").Value = False
        Next
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        If checkReceivingAmount() Then
            addToCoilLines()
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub

    ''checks all the selected items to see if any are being received in with a higher weight that was purchased
    Private Function checkReceivingAmount() As Boolean
        Dim weightOver As New List(Of String)
        For i As Integer = 0 To dgvSteelPOLines.Rows.Count - 1
            If dgvSteelPOLines.Rows(i).Cells("selectForReceiving").Value And dgvSteelPOLines.Rows(i).Cells("QuantityOpen").Value > (dgvSteelPOLines.Rows(i).Cells("PurchaseQuantity").Value - dgvSteelPOLines.Rows(i).Cells("ReceivedWeight").Value) Then
                weightOver.Add("    " + dgvSteelPOLines.Rows(i).Cells("Carbon").Value + "        " + dgvSteelPOLines.Rows(i).Cells("SteelSize").Value + Environment.NewLine)
            End If
        Next
        If weightOver.Count > 0 Then
            Dim msg As String = "You are trying to receive in more than wa purchased for the following items:" + Environment.NewLine
            While weightOver.Count > 0
                msg += weightOver(0)
                weightOver.RemoveAt(0)
            End While
            msg += "Do you wish to continue?"
            If MessageBox.Show(msg, "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub addToCoilLines()
        cmd = New SqlCommand("SELECT RMID, ReceiveWeight FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber

        Dim lst As New List(Of String)
        Dim wei As New List(Of Integer)
        ''gets the currently added RMID's
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                lst.Add(reader.Item("RMID"))
                wei.Add(reader.Item("ReceiveWeight"))
            End While
        End If
        reader.Close()
        con.Close()
        ''goes through all the lines and checks to see if they are selected
        For i As Integer = 0 To dgvSteelPOLines.Rows.Count - 1
            If dgvSteelPOLines.Rows(i).Cells("selectForReceiving").Value Then
                Dim found As Boolean = False
                For j As Integer = 0 To lst.Count - 1
                    If lst(j) = dgvSteelPOLines.Rows(i).Cells("RMID").Value Then
                        updatingReceiveLines(i, wei(j))
                        found = True
                        Exit For
                    End If
                Next
                ''if the selected line is already added to the receiver
                If Not found Then
                    insertingReceiveLines(i)
                End If
            End If
        Next

        cmd = New SqlCommand("DECLARE @POFreight as float = (SELECT FreightTotal FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey), @POOther as float = (SELECT OtherTotal FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey); UPDATE SteelReceivingHeaderTable SET InvoiceTotal = ((SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @HeaderKey) + SteelFreightCharges +  SteelOtherCharges + @POFreight + @POOther), SteelTotalWeight = (SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @HeaderKey), SteelTotal = (SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @HeaderKey), SteelFreightCharges = @POFreight, SteelOtherCharges = @POOther WHERE SteelReceivingHeaderKey = @HeaderKey;", con)
        cmd.Parameters.Add("@HeaderKey", SqlDbType.VarChar).Value = receivingNumber
        cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.Int).Value = dgvSteelPOLines.Rows(0).Cells("SteelPurchaseOrderHeaderKey").Value
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    ''will add the entries into the receivingLine and receivingCoil
    Private Sub insertingReceiveLines(ByVal i As Integer)
        Dim OpenQuantity As Integer = dgvSteelPOLines.Rows(i).Cells("QuantityOpen").Value
        Dim PurchasePricePerPound As Double = dgvSteelPOLines.Rows(i).Cells("PurchasePricePerPound").Value

        ExtendedAmount = Math.Round(OpenQuantity * PurchasePricePerPound, 2, MidpointRounding.AwayFromZero)
        cmd = New SqlCommand("SELECT MAX(SteelReceivingLineKey) + 1 FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber

        Dim nextLine As Integer = 1
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            nextLine = cmd.ExecuteScalar()
        Catch ex As Exception
        End Try
        con.Close()

        'Command to enter into Steel Receiving Line Table
        cmd = New SqlCommand("INSERT INTO SteelReceivingLineTable (SteelReceivingLineKey, SteelReceivingHeaderKey, RMID, ReceiveWeight, SteelExtendedCost, LineStatus, SelectForInvoice, DebitGLAccount, CreditGLAccount, LineComment, SteelPONumber, SteelPOLineNumber) VALUES(@SteelReceivingLineKey, @SteelReceivingHeaderKey, @RMID, @ReceiveWeight, @SteelExtendedCost, 'OPEN', 'OPEN', '12000', '20995', (SELECT LineComment From SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPONumber AND SteelPurchaseLineNumber = @SteelPOLineNumber), @SteelPONumber, @SteelPOLineNumber)", con)

        With cmd.Parameters
            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = nextLine
            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
            .Add("@RMID", SqlDbType.VarChar).Value = dgvSteelPOLines.Rows(i).Cells("RMID").Value
            .Add("@ReceiveWeight", SqlDbType.VarChar).Value = OpenQuantity
            .Add("@SteelExtendedCost", SqlDbType.VarChar).Value = ExtendedAmount
            .Add("@SteelPONumber", SqlDbType.VarChar).Value = dgvSteelPOLines.Rows(i).Cells("SteelPurchaseOrderHeaderKey").Value
            .Add("@SteelPOLineNumber", SqlDbType.VarChar).Value = dgvSteelPOLines.Rows(i).Cells("SteelPurchaseLineNumber").Value
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Insert Into SteelReceivingCoilLines (SteelReceivingLineKey, SteelReceivingHeaderKey, CoilID, CoilWeight, SteelCostPerPound, SteelExtendedAmount, PONumber, POLineNumber)Values(@SteelReceivingLineKey, @SteelReceivingHeaderKey, @CoilID, @CoilWeight, @SteelCostPerPound, @SteelExtendedAmount, @PONumber, @POLineNumber)", con)

        With cmd.Parameters
            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = nextLine
            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
            .Add("@CoilID", SqlDbType.VarChar).Value = dgvSteelPOLines.Rows(i).Cells("RMID").Value
            .Add("@CoilWeight", SqlDbType.VarChar).Value = OpenQuantity
            .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = PurchasePricePerPound
            .Add("@SteelExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
            .Add("@PONumber", SqlDbType.VarChar).Value = dgvSteelPOLines.Rows(i).Cells("SteelPurchaseOrderHeaderKey").Value
            .Add("@POLineNumber", SqlDbType.VarChar).Value = dgvSteelPOLines.Rows(i).Cells("SteelPurchaseLineNumber").Value
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    ''will update the entries into the receivingLine and receiving Coil
    Private Sub updatingReceiveLines(ByVal i As Integer, ByRef wei As Integer)
        Dim OpenQuantity As Integer = dgvSteelPOLines.Rows(i).Cells("QuantityOpen").Value + wei
        Dim PurchasePricePerPound As Double = dgvSteelPOLines.Rows(i).Cells("PurchasePricePerPound").Value

        ExtendedAmount = Math.Round(OpenQuantity * PurchasePricePerPound, 2)

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET ReceiveWeight = @ReceiveWeight, SteelExtendedCost = @SteelExtendedCost WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

        With cmd.Parameters
            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = i + 1
            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
            .Add("@ReceiveWeight", SqlDbType.VarChar).Value = OpenQuantity
            .Add("@SteelExtendedCost", SqlDbType.VarChar).Value = ExtendedAmount
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("UPDATE SteelReceivingCoilLines SET CoilWeight = @CoilWeight, SteelCostPerPound = @SteelCostPerPound, SteelExtendedAmount = @SteelExtendedAmount WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

        With cmd.Parameters
            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = i + 1
            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = receivingNumber
            .Add("@CoilWeight", SqlDbType.VarChar).Value = OpenQuantity
            .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = PurchasePricePerPound
            .Add("@SteelExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
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

    Public Sub setReceiveAndPO(ByVal po As String, ByVal receive As String)
        poNumber = po
        receivingNumber = receive
        ShowReceiverLines()
        isLoaded = True
    End Sub

    Private Sub dgvSteelPOLines_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelPOLines.CellValueChanged
        If isLoaded Then
            If dgvSteelPOLines.Rows.Count > 0 Then
                If dgvSteelPOLines.CurrentCell.ColumnIndex = dgvSteelPOLines.Columns("QuantityOpen").Index Then
                    If dgvSteelPOLines.Rows(dgvSteelPOLines.CurrentCell.RowIndex).Cells("selectForReceiving").Value = False Then
                        dgvSteelPOLines.Rows(dgvSteelPOLines.CurrentCell.RowIndex).Cells("selectForReceiving").Value = True
                    End If
                End If
            End If
        End If
    End Sub
End Class