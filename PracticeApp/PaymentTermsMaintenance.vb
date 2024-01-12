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
Public Class PaymentTermsMaintenance
    Inherits System.Windows.Forms.Form

    Dim Description As String
    Dim DiscountPercent As Double
    Dim DiscountDays, DueDays As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub ClearAll()
        cboPaymentTermID.SelectedIndex = -1
        txtDiscountDays.Clear()
        txtDiscountPercent.Clear()
        txtDueDays.Clear()
        txtPaymentTermDescription.Clear()
        cboPaymentTermID.Focus()
    End Sub

    Public Sub ShowPaymentLines()
        cmd = New SqlCommand("SELECT * FROM PaymentTerms", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PaymentTerms")
        dgvPaymentTerms.DataSource = ds.Tables("PaymentTerms")
        cboPaymentTermID.DataSource = ds.Tables("PaymentTerms")
        con.Close()
    End Sub

    Public Sub LoadPaymentTermsData()
        Dim DescriptionStatement As String = "SELECT Description FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DescriptionCommand As New SqlCommand(DescriptionStatement, con)
        DescriptionCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTermID.Text

        Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
        DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTermID.Text

        Dim DiscountDaysStatement As String = "SELECT DiscountDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountDaysCommand As New SqlCommand(DiscountDaysStatement, con)
        DiscountDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTermID.Text

        Dim DueDaysStatement As String = "SELECT DueDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DueDaysCommand As New SqlCommand(DueDaysStatement, con)
        DueDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTermID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Description = CStr(DescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            Description = ""
        End Try
        Try
            DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountPercent = 0
        End Try
        Try
            DiscountDays = CInt(DiscountDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDays = ""
        End Try
        Try
            DueDays = CInt(DueDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DueDays = ""
        End Try
        con.Close()

        txtDiscountDays.Text = DiscountDays
        txtDiscountPercent.Text = DiscountPercent
        txtDueDays.Text = DueDays
        txtPaymentTermDescription.Text = Description
    End Sub

    Private Sub PaymentTermsMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PaymentTerms' table. You can move, or remove it, as needed.
        Me.PaymentTermsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PaymentTerms)

        ShowPaymentLines()
        ClearAll()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If cboPaymentTermID.Text = "" Then
            MsgBox("A valid Payment Term ID must be selected to add a NEW Payment Term.", MsgBoxStyle.OkOnly)
            cboPaymentTermID.Focus()
        Else
            'Validation for number entry
            If Val(txtDiscountPercent.Text) > 1 Then
                MsgBox("Discount Percent must be a decimal.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If IsNumeric(txtDiscountDays.Text) = False Or IsNumeric(txtDueDays.Text) = False Or IsNumeric(txtDiscountPercent.Text) = False Then
                MsgBox("You must enter a valid number into the fields.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '**********************************************************************************************************
            Try
                'Write Data to Payment Terms Database Table
                cmd = New SqlCommand("Insert Into PaymentTerms(PmtTermsID, Description, DiscountPercent, DiscountDays, DueDays)Values(@PmtTermsID, @Description, @DiscountPercent, @DiscountDays, @DueDays)", con)

                With cmd.Parameters
                    .Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTermID.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtPaymentTermDescription.Text
                    .Add("@DiscountPercent", SqlDbType.VarChar).Value = Val(txtDiscountPercent.Text)
                    .Add("@DiscountDays", SqlDbType.VarChar).Value = Val(txtDiscountDays.Text)
                    .Add("@DueDays", SqlDbType.VarChar).Value = Val(txtDueDays.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Payment Term has been created.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'UPDATE Payment Terms Database Table
                cmd = New SqlCommand("UPDATE PaymentTerms SET Description = @Description, DiscountPercent = @DiscountPercent, DiscountDays = @DiscountDays, DueDays = @DueDays WHERE PmtTermsID = @PmtTermsID", con)

                With cmd.Parameters
                    .Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTermID.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtPaymentTermDescription.Text
                    .Add("@DiscountPercent", SqlDbType.VarChar).Value = Val(txtDiscountPercent.Text)
                    .Add("@DiscountDays", SqlDbType.VarChar).Value = Val(txtDiscountDays.Text)
                    .Add("@DueDays", SqlDbType.VarChar).Value = Val(txtDueDays.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Payment Terms has been updated.", MsgBoxStyle.OkOnly)
            End Try
        End If

        ClearAll()
        ShowPaymentLines()
        ClearAll()
    End Sub

    Private Sub cboPaymentTermID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTermID.SelectedIndexChanged
        LoadPaymentTermsData()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintPaymentTerms As New PrintPaymentTerms
            Dim Result = NewPrintPaymentTerms.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        Using NewPrintPaymentTerms As New PrintPaymentTerms
            Dim Result = NewPrintPaymentTerms.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPaymentTerms_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaymentTerms.CellValueChanged
        Dim PaymentID As String = ""
        Dim PaymentDescription As String = ""
        Dim DiscountPercent As Double = 0
        Dim DiscountDays As Integer = 0
        Dim DueDays As Integer = 0

        If Me.dgvPaymentTerms.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPaymentTerms.CurrentCell.RowIndex

            Try
                PaymentID = Me.dgvPaymentTerms.Rows(RowIndex).Cells("PmtTermdIDColumn").Value
            Catch ex As Exception
                PaymentID = ""
            End Try
            Try
                PaymentDescription = Me.dgvPaymentTerms.Rows(RowIndex).Cells("DescriptionColumn").Value
            Catch ex As Exception
                PaymentDescription = ""
            End Try
            Try
                DiscountPercent = Me.dgvPaymentTerms.Rows(RowIndex).Cells("DiscountPercentColumn").Value
            Catch ex As Exception
                DiscountPercent = 0
            End Try
            Try
                DiscountDays = Me.dgvPaymentTerms.Rows(RowIndex).Cells("DiscountDaysColumn").Value
            Catch ex As Exception
                DiscountDays = 0
            End Try
            Try
                DueDays = Me.dgvPaymentTerms.Rows(RowIndex).Cells("DueDaysColumn").Value
            Catch ex As Exception
                DueDays = 0
            End Try
            '**********************************************************************************************************
            'Validation for number entry
            If IsNumeric(DiscountPercent) = False Or IsNumeric(DueDays) = False Or IsNumeric(DiscountDays) = False Then
                MsgBox("One or more values must be numbers.", MsgBoxStyle.OkOnly)
                ShowPaymentLines()
                Exit Sub
            End If
            '**********************************************************************************************************
            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE PaymentTerms SET Description = @Description, DiscountPercent = @DiscountPercent, DiscountDays = @DiscountDays, DueDays = @DueDays WHERE PmtTermsID = @PmtTermsID", con)

                With cmd.Parameters
                    .Add("@PmtTermsID", SqlDbType.VarChar).Value = PaymentID
                    .Add("@Description", SqlDbType.VarChar).Value = Description
                    .Add("@DiscountPercent", SqlDbType.VarChar).Value = DiscountPercent
                    .Add("@DiscountDays", SqlDbType.VarChar).Value = DiscountDays
                    .Add("@DueDays", SqlDbType.VarChar).Value = DueDays
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        Else
            'Skip update
        End If
    End Sub
End Class