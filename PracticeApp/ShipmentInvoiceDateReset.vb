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
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class ShipmentInvoiceDateReset
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtResetShipmentNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResetShipmentNumber.TextChanged
        If Val(txtResetShipmentNumber.Text) = 0 Then
            'skip loading the Invoice
        Else
            'Load Invoice Number (if invoice exists)
            Dim ResetInvoiceNumber As Integer = 0

            Dim GetInvoiceNumberStatement As String = "SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim GetInvoiceNumberCommand As New SqlCommand(GetInvoiceNumberStatement, con)
            GetInvoiceNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ResetInvoiceNumber = CInt(GetInvoiceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ResetInvoiceNumber = 0
            End Try
            con.Close()

            If ResetInvoiceNumber = 0 Then
                'Do nothing
            Else
                txtResetInvoiceNumber.Text = ResetInvoiceNumber
            End If
        End If
    End Sub

    Private Sub txtResetInvoiceNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResetInvoiceNumber.TextChanged
        If Val(txtResetInvoiceNumber.Text) = 0 Then
            'Skip loading the shipment
        Else
            'Load Shipment Number (if shipment exists)
            Dim ResetShipmentNumber As Integer = 0

            Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
            Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
            GetShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ResetShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ResetShipmentNumber = 0
            End Try
            con.Close()

            If ResetShipmentNumber = 0 Then
                'Do nothing
            Else
                txtResetShipmentNumber.Text = ResetShipmentNumber
            End If
        End If
    End Sub

    Private Sub cmdResetShipmentDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetShipmentDate.Click
        'Validate fields
        If txtResetShipmentNumber.Text <> "" Then
            'Shipment Number Exists - validate
            Dim CheckShipmentNumber As Integer = 0

            Dim CountInvoiceNumberStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim CountInvoiceNumberCommand As New SqlCommand(CountInvoiceNumberStatement, con)
            CountInvoiceNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckShipmentNumber = CInt(CountInvoiceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CheckShipmentNumber = 0
            End Try
            con.Close()

            If CheckShipmentNumber = 0 Then
                MsgBox("This shipment does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing - continue
            End If
            '********************************************

            'Change Shipment Date, Inventory Transaction Date, and GL Post Date for Shipment

            'Update Shipment
            cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipDate = @ShipDate WHERE ShipmentNumber = @ShipmentNumber", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************
            'Update Inventory Transaction Table
            cmd = New SqlCommand("Update InventoryTransactionTable SET TransactionDate = @TransactionDate WHERE TransactionTypeNumber = @TransactionTypeNumber", con)

            With cmd.Parameters
                .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)
                .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************
            'Update GL Transaction Table
            cmd = New SqlCommand("Update GLTransactionMasterList SET GLTransactionDate = @GLTransactionDate WHERE GLReferenceNumber = @GLReferenceNumber", con)

            With cmd.Parameters
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(txtResetShipmentNumber.Text)
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Do nothing - no shipment to reset
        End If

        '***********************************************************************************************************************************************************

        'Reset the Invoice (If it exists)
        If txtResetInvoiceNumber.Text <> "" Then
            'Shipment Number Exists - validate
            Dim CheckInvoiceNumber As Integer = 0

            Dim CountInvoiceNumberStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
            Dim CountInvoiceNumberCommand As New SqlCommand(CountInvoiceNumberStatement, con)
            CountInvoiceNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckInvoiceNumber = CInt(CountInvoiceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CheckInvoiceNumber = 0
            End Try
            con.Close()

            If CheckInvoiceNumber = 0 Then
                MsgBox("This invoice does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing - continue
            End If
            '********************************************

            'Change Invoice Date and GL Post Date for Invoice

            'Update Invoice
            cmd = New SqlCommand("Update InvoiceHeaderTable SET InvoiceDate = @InvoiceDate WHERE InvoiceNumber = @InvoiceNumber", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************
            'Update GL Transaction Table
            cmd = New SqlCommand("Update GLTransactionMasterList SET GLTransactionDate = @GLTransactionDate WHERE GLReferenceNumber = @GLReferenceNumber", con)

            With cmd.Parameters
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(txtResetInvoiceNumber.Text)
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpResetDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Do nothing - no invoice to reset
        End If

        MsgBox("Shipment and/or Invoice is reset to the date selected.", MsgBoxStyle.OkOnly)

        cmdClear_Click(sender, e)

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtResetInvoiceNumber.Clear()
        txtResetShipmentNumber.Clear()
        dtpResetDate.Value = Today()
    End Sub
End Class