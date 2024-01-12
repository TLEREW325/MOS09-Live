Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class APCheckNumberInput
    Inherits System.Windows.Forms.Form

    Dim LastCheckNumber As Int64 = 0
    Dim NextCheckNumber As Int64 = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        GlobalAPStartingCheckNumber = Val(txtFirstCheckNumber.Text)
        '**********************************************************************************************************
        'Verify Check for Canadian Divisions
        If GlobalDivisionCode = "TOR" Then
            If GlobalVendorClass = "Canadian" And txtFirstCheckNumber.Text.StartsWith("181") Then
                'Do nothing
            ElseIf GlobalVendorClass = "American" And txtFirstCheckNumber.Text.StartsWith("180") Then
                'Do nothing
            Else
                MsgBox("Wrong check number for the Canadian Vendor Class", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        If GlobalDivisionCode = "ALB" Then
            If GlobalVendorClass = "American" And txtFirstCheckNumber.Text.StartsWith("220") Then
                'Do nothing
            ElseIf GlobalVendorClass = "Canadian" And txtFirstCheckNumber.Text.StartsWith("221") Then
                'Do nothing
            Else
                MsgBox("Wrong check number for the Canadian Vendor Class", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        If GlobalDivisionCode = "TFF" Then
            If GlobalVendorClass = "Canadian" And txtFirstCheckNumber.Text.StartsWith("211") Then
                'Do nothing
            ElseIf GlobalVendorClass = "American" And txtFirstCheckNumber.Text.StartsWith("212") Then
                'Do nothing
            Else
                MsgBox("Wrong check number for the Canadian Vendor Class", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        '************************************************************************************************************
        If GlobalAPStartingCheckNumber < NextCheckNumber Then
            'Prompt
            Dim button As DialogResult = MessageBox.Show("Do you wish to re-use these check numbers?", "RE-USE CHECK NUMBERS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                Me.Dispose()
                Me.Close()
            ElseIf button = DialogResult.No Then
                'Do nothing
            End If
        Else
            'Do nothing
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub APCheckNumberInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalAPStartingCheckNumber = 0

        'Get check number for TFF (two different check types)
        If GlobalDivisionCode = "TFF" Or GlobalDivisionCode = "TOR" Or GlobalDivisionCode = "ALB" Then
            If GlobalVendorClass = "Canadian" Then
                Dim LastCheckNumberStatement As String = "SELECT MAX(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass"
                Dim LastCheckNumberCommand As New SqlCommand(LastCheckNumberStatement, con)
                LastCheckNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                LastCheckNumberCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "CANADIAN"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastCheckNumber = CLng(LastCheckNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastCheckNumber = 0
                End Try
                con.Close()

                NextCheckNumber = LastCheckNumber + 1

                txtFirstCheckNumber.Text = NextCheckNumber
                txtFirstCheckNumber.Focus()
            ElseIf GlobalVendorClass = "American" Then
                Dim LastCheckNumberStatement As String = "SELECT MAX(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass"
                Dim LastCheckNumberCommand As New SqlCommand(LastCheckNumberStatement, con)
                LastCheckNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                LastCheckNumberCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "AMERICAN"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastCheckNumber = CLng(LastCheckNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastCheckNumber = 0
                End Try
                con.Close()

                NextCheckNumber = LastCheckNumber + 1

                txtFirstCheckNumber.Text = NextCheckNumber
                txtFirstCheckNumber.Focus()
            Else
                NextCheckNumber = 0

                txtFirstCheckNumber.Text = NextCheckNumber
                txtFirstCheckNumber.Focus()
            End If
        Else
            Dim LastCheckNumberStatement As String = "SELECT MAX(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID"
            Dim LastCheckNumberCommand As New SqlCommand(LastCheckNumberStatement, con)
            LastCheckNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCheckNumber = CLng(LastCheckNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCheckNumber = 0
            End Try
            con.Close()

            NextCheckNumber = LastCheckNumber + 1

            txtFirstCheckNumber.Text = NextCheckNumber
            txtFirstCheckNumber.Focus()
        End If
    End Sub
End Class