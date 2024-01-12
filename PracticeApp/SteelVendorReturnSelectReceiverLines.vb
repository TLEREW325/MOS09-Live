Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class SteelVendorReturnSelectReceiverLines
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim ReturnNumber As Integer
    Dim PONumber As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    ''passed return information
    Public Sub New(ByVal ReturnNum As Integer, ByVal po As Integer)
        InitializeComponent()

        ReturnNumber = ReturnNum
        PONumber = po

        cmd = New SqlCommand("SELECT SteelReceivingHeaderKey, SteelReceivingLineKey, Carbon, SteelSize, ReceiveWeight FROM SteelReceivingLineTable LEFT OUTER JOIN RawMaterialsTable ON SteelReceivingLineTable.RMID = RawMaterialsTable.RMID WHERE SteelReceivingHeaderKey in (SELECT SteelReceivingHeaderKey FROM SteelReceivingCoilLines WHERE PONumber = @PONumber AND CoilID not in (SELECT CoilID FROM SteelReturnCoilLines)) AND LineStatus = 'RECEIVED'", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = PONumber

        Dim tempds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "SteelReceivingLineTable")
        con.Close()

        dgvReturnLines.DataSource = tempds.Tables("SteelReceivingLineTable")
        dgvReturnLines.Columns("SteelReceivingHeaderKey").HeaderText = "Receiver #"
        dgvReturnLines.Columns("SteelReceivingHeaderKey").ReadOnly = True
        dgvReturnLines.Columns("SteelReceivingLineKey").HeaderText = "Line #"
        dgvReturnLines.Columns("SteelReceivingLineKey").ReadOnly = True
        dgvReturnLines.Columns("Carbon").ReadOnly = True
        dgvReturnLines.Columns("SteelSize").ReadOnly = True
        dgvReturnLines.Columns("ReceiveWeight").HeaderText = "Received Weight"
        dgvReturnLines.Columns("ReceiveWeight").ReadOnly = True
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For i As Integer = 0 To dgvReturnLines.Rows.Count - 1
            dgvReturnLines.Rows(i).Cells("Selected").Value = True
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For i As Integer = 0 To dgvReturnLines.Rows.Count - 1
            dgvReturnLines.Rows(i).Cells("Selected").Value = False
        Next
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdAddLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLines.Click
        For i As Integer = 0 To dgvReturnLines.Rows.Count - 1
            If dgvReturnLines.Rows(i).Cells("Selected").Value Then
                AddToVendorReturn(i)
            End If
        Next
        If con.State = ConnectionState.Open Then con.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub AddToVendorReturn(ByVal i As Integer)
        ''adds the return line to the return and will copy the coil information from the receiver to the return
        cmd = New SqlCommand("DECLARE @LineNumber as int = (SELECT isnull(MAX(SteelReturnLine) + 1, 1) FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber); INSERT INTO SteelReturnLineTable (SteelReturnNumber, SteelReturnLine, RMID, ReturnQuantity, UnitCost, ExtendedCost, LineStatus, GLDebitAccount, GLCreditAccount, LineComment) SELECT @SteelReturnNumber, @LineNumber, RMID, ReceiveWeight, ROUND(ReceiveWeight / SteelExtendedCost, 5), SteelExtendedCost, 'OPEN', DebitGLAccount, CreditGLAccount, '' FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey; INSERT INTO SteelReturnCoilLines (SteelReturnNumber, SteelReturnLine, CoilID, CoilWeight, CoilCostPerPound, CoilExtendedCost, SteelPONumber, SteelPOLine, HeatNumber, SteelReceiverNumber, SteelReceiverLineNumber) SELECT @SteelReturnNumber, @LineNumber, CoilID, CoilWeight, SteelCostPerPound, SteelExtendedAmount, PONumber, POLineNumber, HeatNumber, @SteelReceivingHeaderKey, @SteelReceivingLineKey FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey;", con)
        cmd.Parameters.Add("@SteelReturnNumber", SqlDbType.Int).Value = ReturnNumber
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.Int).Value = dgvReturnLines.Rows(i).Cells("SteelReceivingHeaderKey").Value
        cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.Int).Value = dgvReturnLines.Rows(i).Cells("SteelReceivingLineKey").Value

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub
End Class