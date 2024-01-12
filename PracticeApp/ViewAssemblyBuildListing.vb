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
Public Class ViewAssemblyBuildListing
    Inherits System.Windows.Forms.Form

    Dim PartFilter, SerialFilter, ZeroFilter, DateFilter As String
    Dim AssemblyDescription As String
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ViewAssemblyBuildListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        ClearDataInDatagrid()
        ClearData()
    End Sub

    Private Sub dgvAssemblyBuildHeader_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssemblyBuildHeader.CellDoubleClick
        Dim RowTransactionNumber As Integer

        If dgvAssemblyBuildHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvAssemblyBuildHeader.CurrentCell.RowIndex

            RowTransactionNumber = Me.dgvAssemblyBuildHeader.Rows(RowIndex).Cells("BuildTransactionNumberColumn").Value

            GlobalAssemblyTransactionNumber = RowTransactionNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintAssemblyBuildBOM As New PrintAssemblyBuildBOM
                Dim Result = NewPrintAssemblyBuildBOM.ShowDialog()
            End Using
        Else
            'Do nothing
        End If
    End Sub

    Private Sub dgvAssemblyBuildHeader_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssemblyBuildHeader.CellValueChanged
        Dim RowTransactionNumber As Integer = 0
        Dim RowSerialNumber As String = ""
        Dim RowComment As String = ""
        Dim RowPartNumber As String = ""
        Dim VerifySerialNumber As Integer = 0
        Dim RowBuildCost As Double = 0
        Dim RowBuildDate As String = ""
        Dim CheckOldSN As String = ""

        If dgvAssemblyBuildHeader.RowCount <> 0 And (cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST") Then
            Dim RowIndex As Integer = Me.dgvAssemblyBuildHeader.CurrentCell.RowIndex

            Try
                RowTransactionNumber = Me.dgvAssemblyBuildHeader.Rows(RowIndex).Cells("BuildTransactionNumberColumn").Value
            Catch ex As Exception
                RowTransactionNumber = 0
            End Try
            Try
                RowSerialNumber = Me.dgvAssemblyBuildHeader.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                RowSerialNumber = ""
            End Try
            Try
                RowComment = Me.dgvAssemblyBuildHeader.Rows(RowIndex).Cells("BuildCommentColumn").Value
            Catch ex As Exception
                RowComment = ""
            End Try
            Try
                RowPartNumber = Me.dgvAssemblyBuildHeader.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowBuildCost = Me.dgvAssemblyBuildHeader.Rows(RowIndex).Cells("BuildCostColumn").Value
            Catch ex As Exception
                RowBuildCost = 0
            End Try
            Try
                RowBuildDate = Me.dgvAssemblyBuildHeader.Rows(RowIndex).Cells("BuildDateColumn").Value
            Catch ex As Exception
                RowBuildDate = ""
            End Try
            '*********************************************************************************************************
            If RowTransactionNumber = 0 Or RowPartNumber = "" Then
                MsgBox("You cannot save the data w/o a Build # and Part #", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*********************************************************************************************************
            'Check to see if serial number has been used before
            Dim CheckIfUsed As Integer = 0

            Dim CheckIfUsedString As String = "SELECT COUNT(SerialNumber) FROM AssemblyBuildHeaderTable WHERE DivisionID = @DivisionID AND SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber"
            Dim CheckIfUsedCommand As New SqlCommand(CheckIfUsedString, con)
            CheckIfUsedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            CheckIfUsedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
            CheckIfUsedCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckIfUsed = CInt(CheckIfUsedCommand.ExecuteScalar)
            Catch ex As Exception
                CheckIfUsed = 0
            End Try
            con.Close()

            If CheckIfUsed = 0 Then
                'Continue
            Else
                MsgBox("This serial Number has already been used.", MsgBoxStyle.OkOnly)
                ShowData()
                Exit Sub
            End If
            '*********************************************************************************************************
            If RowSerialNumber = "" Then
                'Check if build already had a serial number associated with it
                Dim CheckOldSNString As String = "SELECT SerialNumber FROM AssemblyBuildHeaderTable WHERE DivisionID = @DivisionID AND BuildTransactionNumber = @BuildTransactionNumber"
                Dim CheckOldSNCommand As New SqlCommand(CheckOldSNString, con)
                CheckOldSNCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CheckOldSNCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckOldSN = CStr(CheckOldSNCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckOldSN = ""
                End Try
                con.Close()
                '******************************************************************************************************************
                If CheckOldSN = "" Then
                    'Update Build Table
                    cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET SerialNumber = @SerialNumber, BuildComment = @BuildComment WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                        .Add("@BuildComment", SqlDbType.VarChar).Value = RowComment
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else 'Old serial exists in serial log
                    Dim button As DialogResult = MessageBox.Show("Do you wish to delete this S/N from this build?", "DELETE SERIAL NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        'Update Build Table
                        cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET SerialNumber = @SerialNumber, BuildComment = @BuildComment WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@BuildComment", SqlDbType.VarChar).Value = RowComment
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '******************************************************************************************************************
                        'Update Serial Log
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET BuildNumber = @BuildNumber, BuildDate = @BuildDate, TotalCost = @TotalCost, Comment = @Comment, TransactionNumber = @TransactionNumber, BatchNumber = @BatchNumber, Status = @Status WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = CheckOldSN
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TotalCost", SqlDbType.VarChar).Value = RowComment
                            .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                            .Add("@BuildDate", SqlDbType.VarChar).Value = ""
                            .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    ElseIf button = DialogResult.No Then
                        ShowData()
                        Exit Sub
                    End If
                End If
                '******************************************************************************************************************
            Else 'If serial number is being saved (not blank), check to see if the same as associated with this build
                '******************************************************************************************************************
                'Check if serial exists in the Serial Log
                Dim CheckCurrentSerialNumber As Integer = 0

                Dim CheckCurrentSerialNumberString As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND Status <> @Status"
                Dim CheckCurrentSerialNumberCommand As New SqlCommand(CheckCurrentSerialNumberString, con)
                CheckCurrentSerialNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CheckCurrentSerialNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                CheckCurrentSerialNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                CheckCurrentSerialNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckCurrentSerialNumber = CInt(CheckCurrentSerialNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckCurrentSerialNumber = 0
                End Try
                con.Close()
                If CheckCurrentSerialNumber = 1 Then
                    'Do nothing - serial numnber exists and is available
                Else
                    Dim button As DialogResult = MessageBox.Show("This serial # does not exit. Do you wish to add it?", "ADD SERIAL NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        'Update Build Table
                        cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET SerialNumber = @SerialNumber, BuildComment = @BuildComment WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@BuildComment", SqlDbType.VarChar).Value = RowComment
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '******************************************************************************************************************
                        'Update Serial Log for new serial number
                        cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID,TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber)values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TotalCost", SqlDbType.VarChar).Value = RowBuildCost
                            .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                            .Add("@BuildDate", SqlDbType.VarChar).Value = RowBuildDate
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Refresh and exit
                        ShowData()
                        Exit Sub
                        '******************************************************************************************************************
                    ElseIf button = DialogResult.No Then
                        ShowData()
                        Exit Sub
                    End If
                End If
                '***************************************************************************************************************
                'Check if build already had a serial number associated with it
                Dim CheckOldSNString As String = "SELECT SerialNumber FROM AssemblyBuildHeaderTable WHERE DivisionID = @DivisionID AND BuildTransactionNumber = @BuildTransactionNumber"
                Dim CheckOldSNCommand As New SqlCommand(CheckOldSNString, con)
                CheckOldSNCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CheckOldSNCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckOldSN = CStr(CheckOldSNCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckOldSN = ""
                End Try
                con.Close()
                '******************************************************************************************************************
                If CheckOldSN = RowSerialNumber Then
                    'Update Build Table
                    cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET SerialNumber = @SerialNumber, BuildComment = @BuildComment WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                        .Add("@BuildComment", SqlDbType.VarChar).Value = RowComment
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************************************
                Else 'Current serial number does not match the one associated with the build
                    '******************************************************************************************************************
                    Dim button As DialogResult = MessageBox.Show("Do you wish to replace/add the S/N in this build?", "REPLACE/ADD SERIAL NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        'Update Build Table
                        cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET SerialNumber = @SerialNumber, BuildComment = @BuildComment WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@BuildComment", SqlDbType.VarChar).Value = RowComment
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '******************************************************************************************************************
                        'Update Serial Log for new serial number
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET BuildNumber = @BuildNumber, BuildDate = @BuildDate, TotalCost = @TotalCost, Comment = @Comment, TransactionNumber = @TransactionNumber, BatchNumber = @BatchNumber, Status = @Status WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TotalCost", SqlDbType.VarChar).Value = RowBuildCost
                            .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                            .Add("@BuildDate", SqlDbType.VarChar).Value = RowBuildDate
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '******************************************************************************************************************
                        'Update Serial Log for old serial number
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET BuildNumber = @BuildNumber, BuildDate = @BuildDate, TotalCost = @TotalCost, Comment = @Comment, TransactionNumber = @TransactionNumber, BatchNumber = @BatchNumber, Status = @Status WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = CheckOldSN
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TotalCost", SqlDbType.VarChar).Value = RowComment
                            .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                            .Add("@BuildDate", SqlDbType.VarChar).Value = ""
                            .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    ElseIf button = DialogResult.No Then
                        ShowData()
                        Exit Sub
                    End If
                End If
            End If
        Else
            'Do nothing
        End If
    End Sub

    Public Sub ShowData()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND AssemblyPartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtSerialNumber.Text <> "" Then
            SerialFilter = " AND SerialNumber LIKE '%" + txtSerialNumber.Text + "%'"
        Else
            SerialFilter = ""
        End If
        If chkShowWithout.Checked = True Then
            ZeroFilter = " AND SerialNumber = ''"
        Else
            ZeroFilter = ""
        End If
        If chkUseDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = " AND BuildDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM AssemblyBuildHeaderTable WHERE DivisionID = @DivisionID" + PartFilter + SerialFilter + ZeroFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblyBuildHeaderTable")
        dgvAssemblyBuildHeader.DataSource = ds.Tables("AssemblyBuildHeaderTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAssemblyBuildHeader.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND PurchProdLineID = @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND PurchProdLineID = @PurchProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadAssemblyDescription()
        Dim AssemblyDescriptionStatement As String = "SELECT AssemblyDescription FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
        Dim AssemblyDescriptionCommand As New SqlCommand(AssemblyDescriptionStatement, con)
        AssemblyDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AssemblyDescriptionCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AssemblyDescription = CStr(AssemblyDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            AssemblyDescription = ""
        End Try
        con.Close()

        txtAssemblyDescription.Text = AssemblyDescription
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        LoadAssemblyDescription()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub ClearData()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        txtAssemblyDescription.Clear()
        txtSerialNumber.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkUseDateRange.Checked = False
        chkShowWithout.Checked = False

        cboPartNumber.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintAssemblyBuildListingFiltered As New PrintAssemblyBuildListingFiltered
            Dim Result = NewPrintAssemblyBuildListingFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowData()
    End Sub

    Private Sub cmdAddSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSN.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must select a part number from above.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        GlobalSerialFormLocation = "ADDBUILDS"
        GlobalAssemblyPartNumber = cboPartNumber.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewAssemblySerialPopup As New AssemblySerialPopup
            Dim Result = NewAssemblySerialPopup.ShowDialog()
        End Using

        ShowData()
    End Sub
End Class