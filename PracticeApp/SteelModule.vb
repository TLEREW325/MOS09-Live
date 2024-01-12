Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Module SteelModule
    Public Function GetSteelCosting(ByVal rmid As String, ByVal inQty As Double, ByVal con As SqlConnection, Optional ByVal costingDate As Date = Nothing, Optional ByVal reportAbove As Boolean = True) As Double
        Dim cmd As New SqlCommand("SELECT isnull(SUM(UsageWeight),0) as TotalUsedWeight FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED'", con)
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = rmid
        If costingDate <> Nothing Then
            cmd.CommandText += " AND UsageDate <= @CostingDate"
            cmd.Parameters.Add("@CostingDate", SqlDbType.Date).Value = costingDate
        End If
        Dim obj As Object = Nothing
        Dim TotalWeightUsed As Double = 0D

        If con.State = ConnectionState.Closed Then con.Open()
        obj = cmd.ExecuteScalar()
        If obj IsNot Nothing Then
            TotalWeightUsed = obj
        End If
        ''Check to make sure it will hit a cost tier
        If TotalWeightUsed = 0 Then TotalWeightUsed = 1

        Dim remainingQtyToCost As Double = inQty

        Dim SteelCostTierCMD As New SqlCommand("SELECT SteelCostPerPound, UpperLimit, LowerLimit FROM SteelCostingTable WHERE RMID = @RMID AND @Weight BETWEEN LowerLimit AND UpperLimit", con)
        SteelCostTierCMD.Parameters.Add("@RMID", SqlDbType.VarChar).Value = rmid
        ''uses total weight used to find the first cost tier to be used
        SteelCostTierCMD.Parameters.Add("@Weight", SqlDbType.Int).Value = TotalWeightUsed

        ''Check to see if a costing date was supplied
        If costingDate <> Nothing Then
            SteelCostTierCMD.CommandText += " AND CostingDate <= @CostingDate"
            SteelCostTierCMD.Parameters.Add("@CostingDate", SqlDbType.Date).Value = costingDate
        End If

        ''Adds the ordering in to get the best cost tier available
        SteelCostTierCMD.CommandText += " ORDER BY SteelCostingTable.CostingDate, SteelCostingTable.TransactionNumber DESC"
        Dim first As Boolean = True
        Dim UpperLimit As Integer = 0
        Dim LowerLimit As Integer = 0
        Dim SteelCostPerPound As Double = 0D
        Dim TotalExtendedCost As Double = 0D
        Dim FIFOAbort As Boolean = False
        Dim reader As SqlDataReader

        While remainingQtyToCost > 0 AndAlso Not FIFOAbort
            If con.State = ConnectionState.Closed Then con.Open()
            reader = SteelCostTierCMD.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                SteelCostPerPound = reader.Item("SteelCostPerPound")
                UpperLimit = reader.Item("UpperLimit")
                LowerLimit = reader.Item("LowerLimit")
                reader.Close()
                If first Then
                    first = False
                    Dim remCostTierWeight As Integer = (TotalWeightUsed - LowerLimit) + 1
                    If remCostTierWeight >= remainingQtyToCost Then
                        TotalExtendedCost += Math.Round(remainingQtyToCost * SteelCostPerPound, 2, MidpointRounding.AwayFromZero)
                        remainingQtyToCost = 0
                    Else
                        TotalExtendedCost += Math.Round(remCostTierWeight * SteelCostPerPound, 2, MidpointRounding.AwayFromZero)
                        remainingQtyToCost -= remCostTierWeight
                    End If
                Else
                    Dim remCostTierWeight As Integer = (UpperLimit - LowerLimit) + 1
                    If remCostTierWeight >= remainingQtyToCost Then
                        TotalExtendedCost += Math.Round(remainingQtyToCost * SteelCostPerPound, 2, MidpointRounding.AwayFromZero)
                        remainingQtyToCost = 0
                    Else
                        TotalExtendedCost += Math.Round(remCostTierWeight * SteelCostPerPound, 2, MidpointRounding.AwayFromZero)
                        remainingQtyToCost -= remCostTierWeight
                    End If

                End If
                ''Stest the parameter to the upper limit + 1
                SteelCostTierCMD.Parameters("@Weight").Value = UpperLimit + 1
            Else
                If Not reader.IsClosed Then
                    reader.Close()
                End If
                ''aborts out if a cost tier is not found
                FIFOAbort = True
            End If
        End While

        ''If the cost tier is not hit or if the total cost was found to be 0, this will do last transaction then last received
        If FIFOAbort Or (TotalExtendedCost AndAlso TotalExtendedCost = 0) Then
            cmd = New SqlCommand("SELECT TOP 1 isnull(SteelCost, 0) FROM SteelTransactionTable WHERE RMID = @RMID", con)
            cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = rmid

            ''Check to see if a costing date was supplied
            If costingDate <> Nothing Then
                cmd.CommandText += " AND SteelTransactionDate <= @CostingDate"
                cmd.Parameters.Add("@CostingDate", SqlDbType.Date).Value = costingDate
            End If
            cmd.CommandText += " ORDER BY TransactionNumber DESC"
            If con.State = ConnectionState.Closed Then con.Open()
            obj = cmd.ExecuteScalar()
            If obj IsNot Nothing Then
                TotalExtendedCost = Math.Round(obj * inQty, 2, MidpointRounding.AwayFromZero)
            Else
                TotalExtendedCost = 0
            End If
            ''Check to see if we hit a transaction
            If TotalExtendedCost = 0 Then
                cmd.CommandText = "SELECT TOP 1 ISNULL(SteelCostPerPound, 0) FROM SteelReceivingLineQuery WHERE RMID = @RMID"
                ''Check to see if a costing date was supplied
                If costingDate <> Nothing Then
                    cmd.CommandText += " AND ReceivingDate <= @CostingDate"
                End If
                cmd.CommandText += " ORDER BY SteelReceivingHeaderKey DESC"
                If con.State = ConnectionState.Closed Then con.Open()
                obj = cmd.ExecuteScalar()
                If obj IsNot Nothing Then
                    TotalExtendedCost = Math.Round(obj * inQty, 2, MidpointRounding.AwayFromZero)
                Else
                    TotalExtendedCost = 0
                End If
            End If
            ''if we get this far without an extended cost, will throw error but continue
            If TotalExtendedCost = 0 AndAlso reportAbove Then
                sendErrorToDataBase("Unable to locate a cost for RMID with costing date of " + costingDate.ToShortDateString(), "RMID " + rmid, "Missed cost tier, no last transaction found and no receiver found", con)
            End If
        End If
        If con.State = ConnectionState.Open Then con.Close()
        ''ADD TRANSACTIONS
        Return TotalExtendedCost
    End Function

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String, ByVal con As SqlConnection)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

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
End Module
