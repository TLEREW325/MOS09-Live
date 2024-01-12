Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Data.SqlClient
Public Class SelectCoilsForReceiving
    Inherits System.Windows.Forms.Form

    ''subclass to keep all the info for one RMID in one place
    Public Class rmidInfo
        Public carbon As String
        Public steelSize As String
        Public weight As Double
        Public cost As Double
        Public poLine As Integer
        Public coils As List(Of String)
        Public isInLines As Boolean
    End Class

    Dim LastGLNumber, NextGLNumber, LineNumber As Integer
    Dim DebitGLAccount, CreditGLAccount As String
    Dim ExtendedAmount, FreightCharge, SalesTax, ProductTotal, ReceiverTotal As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet

    Dim receiverNumber As Integer

    Dim isloaded = False

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For i As Integer = 0 To dgvCoilsToReceive.Rows.Count - 1
            dgvCoilsToReceive.Rows(i).Cells("selectCoil").Value = True
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For i As Integer = 0 To dgvCoilsToReceive.Rows.Count - 1
            dgvCoilsToReceive.Rows(i).Cells("selectCoil").Value = False
        Next
    End Sub

    Private Sub cmdReceiveCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceiveCoils.Click
        If PONotExist() Then
            combineLikeCarbonSteelSize()
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub

    Private Function PONotExist() As Boolean
        For i As Integer = 0 To dgvCoilsToReceive.Rows.Count - 1
            cmd = New SqlCommand("SELECT SteelPurchaseOrderKey, Status FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @PONumber;", con)
            cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = Val(dgvCoilsToReceive.Rows(i).Cells("PurchaseOrderNumber").Value)
            Dim cnt As Integer = 0
            Dim stat As String = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("SteelPurchaseOrderKey")) Then
                    cnt = reader.Item("SteelPurchaseOrderKey")
                End If
                If Not IsDBNull(reader.Item("Status")) Then
                    stat = reader.Item("Status")
                End If
            End If
            reader.Close()
            con.Close()

            If cnt.Equals(0) Then
                MessageBox.Show("Purchase Order doesn't exist for coils. Make sure the Purchase Order has been entered for the coils. Purchase Order #" + dgvCoilsToReceive.Rows(i).Cells("PurchaseOrderNumber").Value.ToString(), "PO doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            If Not stat.Equals("OPEN") Then
                MessageBox.Show("Purchase Order has been CLOSED. You are not able to receive against a CLOSED Purchase Order.", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub loadData(ByVal despatchNumber As String, ByVal receiving As Integer)
        cmd = New SqlCommand("SELECT CoilID, Carbon, SteelSize, Weight, PurchaseOrderNumber FROM CharterSteelCoilIdentification WHERE DespatchNumber = @DespatchNumber AND Status = 'OPEN';", con)
        cmd.Parameters.Add("@DespatchNumber", SqlDbType.VarChar).Value = despatchNumber
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "CharterSteelCoilIdentification")
        con.Close()
        dgvCoilsToReceive.DataSource = ds.Tables("CharterSteelCoilIdentification")
        dgvCoilsToReceive.Columns("Carbon").ReadOnly = True
        dgvCoilsToReceive.Columns("SteelSize").ReadOnly = True
        dgvCoilsToReceive.Columns("SteelSize").HeaderText = "Steel Size"
        dgvCoilsToReceive.Columns("Weight").ReadOnly = True
        dgvCoilsToReceive.Columns("CoilID").ReadOnly = True
        dgvCoilsToReceive.Columns("PurchaseOrderNumber").Visible = False

        receiverNumber = receiving
    End Sub

    Private Sub combineLikeCarbonSteelSize()
        getSteelReceivingLines()

        Dim lst As New List(Of rmidInfo)
        ''goes through all the rows in the lines table to see what is there already and will add it to a list to be checked by all checked coil lines
        For j As Integer = 0 To ds2.Tables("SteelReceivingLineTable").Rows.Count - 1
            Dim rmid As New rmidInfo
            rmid.carbon = ds2.Tables("SteelReceivingLineTable").Rows(j).Item("Carbon")
            rmid.steelSize = ds2.Tables("SteelReceivingLineTable").Rows(j).Item("SteelSize")
            rmid.weight = ds2.Tables("SteelReceivingLineTable").Rows(j).Item("ReceiveWeight")
            rmid.cost = 0
            rmid.coils = New List(Of String)
            rmid.isInLines = True
            lst.Add(rmid)
        Next

        Dim changeMade As Boolean = False

        For i As Integer = 0 To dgvCoilsToReceive.Rows.Count - 1
            ''checks to see if the coil was selected to be added
            If dgvCoilsToReceive.Rows(i).Cells("selectCoil").Value = True Then
                changeMade = True
                Dim notFound As Boolean = True
                Dim j As Integer = 0

                ''check to make sure there are elements before trying anything
                If lst.Count > 0 Then
                    While notFound And j < lst.Count
                        notFound = False
                        Dim carb As String = dgvCoilsToReceive.Rows(i).Cells("Carbon").Value
                        Dim siz As String = dgvCoilsToReceive.Rows(i).Cells("SteelSize").Value
                        If lst(j).carbon <> dgvCoilsToReceive.Rows(i).Cells("Carbon").Value Or lst(j).steelSize <> dgvCoilsToReceive.Rows(i).Cells("SteelSize").Value Then
                            notFound = True
                            j += 1
                        End If
                    End While
                End If

                ''checks to see if the value was found in the list or not
                If notFound Then
                    Dim rmid As New rmidInfo
                    rmid.carbon = dgvCoilsToReceive.Rows(i).Cells("Carbon").Value
                    rmid.steelSize = dgvCoilsToReceive.Rows(i).Cells("SteelSize").Value
                    rmid.weight = dgvCoilsToReceive.Rows(i).Cells("Weight").Value
                    rmid.coils = New List(Of String)
                    rmid.coils.Add(dgvCoilsToReceive.Rows(i).Cells("CoilID").Value)
                    rmid.isInLines = False
                    lst.Add(rmid)
                Else
                    lst(j).weight = lst(j).weight + dgvCoilsToReceive.Rows(i).Cells("Weight").Value
                    lst(j).coils.Add(dgvCoilsToReceive.Rows(i).Cells("CoilID").Value)
                End If
            End If
        Next

        ''checks to see if anything was added to the list
        If changeMade Then
            For i As Integer = 0 To lst.Count - 1
                If lst(i).coils.Count > 0 Then
                    If lst(i).isInLines Then
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET ReceiveWeight = @Weight WHERE SteelReceivingHeaderKey = @HeaderKey AND SteelReceivingLineKey = @LineNumber;", con)
                        cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = lst(i).weight
                        cmd.Parameters.Add("@HeaderKey", SqlDbType.Int).Value = receiverNumber
                        cmd.Parameters.Add("@LineNumber", SqlDbType.Int).Value = i + 1
                    Else
                        cmd = New SqlCommand("INSERT INTO SteelReceivingLineTable (SteelReceivingHeaderKey, SteelReceivingLineKey, RMID, ReceiveWeight, SteelExtendedCost, LineStatus, SelectForInvoice, DebitGLAccount, CreditGLAccount, LineComment, SteelPONumber, SteelPOLineNumber) VALUES (@HeaderKey, @LineNumber, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @Weight, (@Weight * (SELECT isnull(AVG(PurchasePricePerPound), (SELECT TOP 1 PurchasePricePerPound FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = (SELECT PurchaseOrderNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID) AND RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize))) FROM SteelPurchaseLine WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND LineStatus = 'OPEN' AND  SteelPurchaseOrderHeaderKey = (SELECT PurchaseOrderNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID))), 'PENDING', 'OPEN', 20995, 12000, (SELECT LineComment FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = (SELECT PurchaseOrderNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID) AND SteelPurchaseLineNumber = (SELECT SteelPurchaseLineNumber FROM SteelPurchaseLine WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND SteelPurchaseOrderHeaderKey = (SELECT PurchaseOrderNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID))), @SteelPONumber, @SteelPOLineNumber)", con)

                        With cmd.Parameters
                            .Add("@HeaderKey", SqlDbType.Int).Value = receiverNumber
                            .Add("@LineNumber", SqlDbType.Int).Value = i + 1
                            .Add("@Carbon", SqlDbType.VarChar).Value = lst(i).carbon
                            .Add("@SteelSize", SqlDbType.VarChar).Value = lst(i).steelSize
                            .Add("@Weight", SqlDbType.VarChar).Value = lst(i).weight
                            .Add("@CoilID", SqlDbType.VarChar).Value = lst(i).coils(0)
                            .Add("@SteelPONumber", SqlDbType.VarChar).Value = 0
                            .Add("@SteelPOLineNumber", SqlDbType.VarChar).Value = 0
                        End With
                    End If
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    addCoilToReceivingTable(i + 1, lst(i).coils)
                End If
            Next
            con.Close()
        End If

        ''recalculates the extended amounts for each line
        sumExtendedCost()
        updateProductTotal()
    End Sub

    Private Sub addCoilToReceivingTable(ByVal lineNumber As Integer, ByRef coils As List(Of String))
        Dim receiveCMD As New SqlCommand("begin tran INSERT INTO SteelReceivingCoilLines (SteelReceivingHeaderKey, SteelReceivingLineKey, CoilID, CoilWeight, HeatNumber, PONumber, POLineNumber, SteelCostPerPound, SteelExtendedAmount) VALUES ", con)
        With receiveCMD.Parameters
            .Add("@SteelReceivingHeaderKey", SqlDbType.Int).Value = receiverNumber
            .Add("@SteelReceivingLineKey", SqlDbType.Int).Value = lineNumber
        End With
        Dim POList As New List(Of Integer)
        Dim pendingCMD As String = "UPDATE CharterSteelCoilIdentification SET Status = 'PENDING' WHERE "
        For i As Integer = 0 To coils.Count - 1
            Dim poNumber As Integer = 0
            Dim poLine As Integer = 1
            Dim cost As Double = 0.0
            Dim rmid As String = ""
            Dim wei As Double = 0.0
            Dim heat As String = ""
            cmd = New SqlCommand("SELECT CoilIdent.PurchaseOrderNumber, SteelPurchaseLineNumber, PurchasePricePerPound, CoilIdent.RMID, CoilIdent.Weight, CoilIdent.HeatNumber FROM SteelPurchaseLine Right join  (SELECT RMID, PurchaseOrderNumber, CharterSteelCoilIdentification.Carbon, CharterSteelCoilIdentification.SteelSize, Weight, HeatNumber From CharterSteelCoilIdentification Left Outer Join RawMaterialsTable on CharterSteelCoilIdentification.Carbon = RawMaterialsTable.Carbon And CharterSteelCoilIdentification.SteelSize = RawMaterialsTable.SteelSize WHERE CoilID = @CoilID)as CoilIdent on SteelPurchaseLine.SteelPurchaseOrderHeaderKey = CoilIdent.PurchaseOrderNumber AND SteelPurchaseLine.RMID = CoilIdent.RMID;", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = coils(i)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("PurchaseOrderNumber")) = False Then
                    poNumber = reader.Item("PurchaseOrderNumber")
                End If
                If IsDBNull(reader.Item("SteelPurchaseLineNumber")) = False Then
                    poLine = reader.Item("SteelPurchaseLineNumber")
                End If
                If IsDBNull(reader.Item("PurchasePricePerPound")) = False Then
                    cost = reader.Item("PurchasePricePerPound")
                End If
                If IsDBNull(reader.Item("RMID")) = False Then
                    rmid = reader.Item("RMID")
                End If
                If IsDBNull(reader.Item("Weight")) = False Then
                    wei = reader.Item("Weight")
                End If
                If IsDBNull(reader.Item("HeatNumber")) = False Then
                    heat = reader.Item("HeatNumber")
                End If
            End If
            reader.Close()
            If i > 0 Then
                receiveCMD.CommandText += ", (@SteelReceivingHeaderKey, @SteelReceivingLineKey, @CoilID" + i.ToString() + ", @CoilWeight" + i.ToString() + ", @HeatNumber" + i.ToString() + ", @PONumber" + i.ToString() + ", @POLineNumber" + i.ToString() + ", @SteelCostPerPound" + i.ToString() + ", @SteelExtendedAmount" + i.ToString() + ")"
                pendingCMD += " OR CoilID = @CoilID" + i.ToString()
            Else
                receiveCMD.CommandText += "(@SteelReceivingHeaderKey, @SteelReceivingLineKey, @CoilID" + i.ToString() + ", @CoilWeight" + i.ToString() + ", @HeatNumber" + i.ToString() + ", @PONumber" + i.ToString() + ", @POLineNumber" + i.ToString() + ", @SteelCostPerPound" + i.ToString() + ", @SteelExtendedAmount" + i.ToString() + ")"
                pendingCMD += "CoilID = @CoilID" + i.ToString()
            End If
            With receiveCMD.Parameters
                .Add("@CoilID" + i.ToString(), SqlDbType.VarChar).Value = coils(i)
                .Add("@CoilWeight" + i.ToString(), SqlDbType.Float).Value = wei
                .Add("@HeatNumber" + i.ToString(), SqlDbType.VarChar).Value = heat
                .Add("@PONumber" + i.ToString(), SqlDbType.Int).Value = poNumber
                .Add("@POLineNumber" + i.ToString(), SqlDbType.Int).Value = poLine
                .Add("@SteelCostPerPound" + i.ToString(), SqlDbType.Float).Value = cost
                .Add("@SteelExtendedAmount" + i.ToString(), SqlDbType.VarChar).Value = Math.Round(cost * wei, 2)
            End With
            If Not POList.Contains(poNumber) Then
                POList.Add(poNumber)
            End If
        Next
        If coils.Count > 0 Then
            receiveCMD.CommandText += "; " + pendingCMD + "; commit tran;"
            If con.State = ConnectionState.Closed Then con.Open()
            receiveCMD.ExecuteNonQuery()
        End If
        If POList.Count > 0 Then
            Dim POCondition As String = ""

            For i As Integer = 0 To POList.Count - 1
                If i = 0 Then
                    POCondition += " SteelPurchaseOrderKey = " + POList(i).ToString
                Else
                    POCondition += " OR SteelPurchaseOrderKey = " + POList(i).ToString
                End If
            Next
            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET SteelFreightCharges = (SELECT SUM(FreightTotal) FROM SteelPurchaseOrderHeader WHERE " + POCondition + "), SteelOtherCHarges = (SELECT SUM(OtherTotal) FROM SteelPurchaseOrderHeader WHERE " + POCondition + ") WHERE SteelReceivingHeaderKey = @HeaderKey;", con)
            cmd.Parameters.Add("@HeaderKey", SqlDbType.Int).Value = receiverNumber
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub sumExtendedCost()
        cmd = New SqlCommand("SELECT COUNT(SteelReceivingLineKey) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @HeaderKey;", con)
        cmd.Parameters.Add("@HeaderKey", SqlDbType.VarChar).Value = receiverNumber
        If con.State = ConnectionState.Closed Then con.Open()
        Dim cnt As Integer = cmd.ExecuteScalar()
        con.Close()
        For i As Integer = 1 To cnt
            cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SteelExtendedCost = (SELECT SUM(SteelExtendedAmount) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @HeaderKey AND SteelReceivingLineKey = @LineKey) WHERE SteelReceivingHeaderKey = @HeaderKey AND SteelReceivingLineKey = @LineKey;", con)
            cmd.Parameters.Add("@HeaderKey", SqlDbType.Int).Value = receiverNumber
            cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = i

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Private Sub updateProductTotal()
        cmd = New SqlCommand("DECLARE @ExtendedCost as float = (SELECT SUM(SteelExtendedCost) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @HeaderKey); UPDATE SteelReceivingHeaderTable SET InvoiceTotal = (@ExtendedCost + SteelFreightCharges + SteelOtherCharges), SteelTotalWeight = (SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @HeaderKey), SteelTotal = @ExtendedCost WHERE SteelReceivingHeaderKey = @HeaderKey;", con)
        cmd.Parameters.Add("@HeaderKey", SqlDbType.Int).Value = receiverNumber
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub getSteelReceivingLines()
        cmd = New SqlCommand("SELECT RawMaterialsTable.Carbon, RawMaterialsTable.SteelSize, SteelReceivingHeaderKey, SteelReceivingLineKey, ReceiveWeight, SteelExtendedCost FROM SteelReceivingLineTable Left outer join RawMaterialsTable on SteelReceivingLineTable.RMID = RawMaterialsTable.RMID WHERE SteelReceivingLineTable.SteelReceivingHeaderKey = @SteelReceivingHeaderKey;", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = receiverNumber.ToString()
        ds2 = New DataSet()
        myAdapter1.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds2, "SteelReceivingLineTable")
        con.Close()
    End Sub
End Class