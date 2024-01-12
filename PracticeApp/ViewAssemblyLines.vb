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
Public Class ViewAssemblyLines
    Inherits System.Windows.Forms.Form

    Dim AssemblyPartFilter, ComponentPartFilter, DateFilter, TextFilter, SerialFilter, NonSerialFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ViewAssemblyLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Public Sub ShowDataByFilter()
        If cboPartNumber.Text <> "" Then
            AssemblyPartFilter = " AND AssemblyPartNumber = '" + cboPartNumber.Text + "'"
        Else
            AssemblyPartFilter = ""
        End If
        If cboComponentPart.Text <> "" Then
            ComponentPartFilter = " AND ComponentPartNumber = '" + cboComponentPart.Text + "'"
        Else
            ComponentPartFilter = ""
        End If
        If chkSerialized.Checked = True Then
            SerialFilter = " AND SerializedStatus = 'YES'"
        Else
            SerialFilter = ""
        End If
        If chkNonSerial.Checked = True Then
            NonSerialFilter = " AND SerializedStatus = 'NO'"
        Else
            NonSerialFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (ComponentPartNumber LIKE '%" + txtTextFilter.Text + "%' OR AssemblyPartNumber LIKE '%" + txtTextFilter.Text + "%' OR ComponentPartDescription LIKE '%" + txtTextFilter.Text + "%' OR AssemblyDescription LIKE '%" + txtTextFilter.Text + "%' OR LineComment LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND AssemblyDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM AssemblyLineQuery2 WHERE DivisionID = @DivisionID" + AssemblyPartFilter + ComponentPartFilter + SerialFilter + NonSerialFilter + TextFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblyLineQuery2")
        dgvAssemblyLineQuery.DataSource = ds.Tables("AssemblyLineQuery2")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAssemblyLineQuery.DataSource = Nothing
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

    Public Sub LoadComponentPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboComponentPart.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboComponentPart.SelectedIndex = -1
    End Sub

    Public Sub LoadComponentPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboComponentDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboComponentDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadOldBOM()
        cmd = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber ORDER BY ComponentLineNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtOldAssemblyPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "AssemblyLineTable")
        dgvOldAssemblyLines.DataSource = ds5.Tables("AssemblyLineTable")
        con.Close()
    End Sub

    Public Sub ClearOldAssemblyLines()
        dgvOldAssemblyLines.DataSource = Nothing
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

    Public Sub LoadComponentPartByDescription()
        Dim ComponentPartNumber As String = ""

        Dim ComponentPartNumberStatement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim ComponentPartNumberCommand As New SqlCommand(ComponentPartNumberStatement, con)
        ComponentPartNumberCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboComponentDescription.Text
        ComponentPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentPartNumber = CStr(ComponentPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            ComponentPartNumber = ""
        End Try
        con.Close()

        cboComponentPart.Text = ComponentPartNumber
    End Sub

    Public Sub ClearData()
        cboComponentPart.SelectedIndex = -1
        cboComponentDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        txtTextFilter.Clear()
        txtNewAssemblyPartNumber.Clear()
        txtOldAssemblyPartNumber.Clear()

        chkDateRange.Checked = False
        chkNonSerial.Checked = False
        chkSerialized.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        AssemblyPartFilter = ""
        ComponentPartFilter = ""
        DateFilter = ""
        TextFilter = ""
        SerialFilter = ""
        NonSerialFilter = ""
    End Sub

    Public Sub LoadComponentDescriptionByPart()
        Dim ComponentPartDescription As String = ""

        Dim ComponentPartDescriptionStatement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ComponentPartDescriptionCommand As New SqlCommand(ComponentPartDescriptionStatement, con)
        ComponentPartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboComponentPart.Text
        ComponentPartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentPartDescription = CStr(ComponentPartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            ComponentPartDescription = ""
        End Try
        con.Close()

        cboComponentDescription.Text = ComponentPartDescription
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        LoadPartNumber()
        LoadPartDescription()
        LoadComponentPartNumber()
        LoadComponentPartDescription()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboComponentPart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentPart.SelectedIndexChanged
        LoadComponentDescriptionByPart()
    End Sub

    Private Sub cboComponentDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentDescription.SelectedIndexChanged
        LoadComponentPartByDescription()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintAssemblyLinesFiltered As New PrintAssemblyLinesFiltered
            Dim Result = NewPrintAssemblyLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub dgvAssemblyLineQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssemblyLineQuery.CellDoubleClick
        If Me.dgvAssemblyLineQuery.RowCount <> 0 Then
            Dim RowPartNumber As String = ""
            Dim RowIndex As Integer = Me.dgvAssemblyLineQuery.CurrentCell.RowIndex

            RowPartNumber = Me.dgvAssemblyLineQuery.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value

            GlobalAssemblyPartNumber = RowPartNumber

            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintAssemblyBOM As New PrintAssemblyBOM
                Dim Result = NewPrintAssemblyBOM.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdCreateDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateDuplicate.Click
        'Validate both part numbers
        If txtNewAssemblyPartNumber.Text = "" Or txtOldAssemblyPartNumber.Text = "" Then
            MsgBox("You must have a part # in both fields.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check to see if Old Part Number is an assembly
        Dim CountAssembly As Integer = 0

        Dim CountAssemblyStatement As String = "SELECT COUNT(AssemblyPartNumber) FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CountAssemblyCommand As New SqlCommand(CountAssemblyStatement, con)
        CountAssemblyCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtOldAssemblyPartNumber.Text
        CountAssemblyCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountAssembly = CInt(CountAssemblyCommand.ExecuteScalar)
        Catch ex As Exception
            CountAssembly = 0
        End Try
        con.Close()

        If CountAssembly = 0 Then
            MsgBox("This part is not in the assembly table.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Count Assembly Lines
        Dim CountAssemblyLines As Integer = 0

        Dim CountAssemblyLinesStatement As String = "SELECT COUNT(AssemblyPartNumber) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CountAssemblyLinesCommand As New SqlCommand(CountAssemblyLinesStatement, con)
        CountAssemblyLinesCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtOldAssemblyPartNumber.Text
        CountAssemblyLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountAssemblyLines = CInt(CountAssemblyLinesCommand.ExecuteScalar)
        Catch ex As Exception
            CountAssemblyLines = 0
        End Try
        con.Close()

        If CountAssemblyLines = 0 Then
            MsgBox("This assembly has no components.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check if new part number exists
        Dim CheckNewPart As Integer = 0

        Dim CheckNewPartStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CheckNewPartCommand As New SqlCommand(CheckNewPartStatement, con)
        CheckNewPartCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtNewAssemblyPartNumber.Text
        CheckNewPartCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckNewPart = CInt(CheckNewPartCommand.ExecuteScalar)
        Catch ex As Exception
            CheckNewPart = 0
        End Try
        con.Close()

        If CheckNewPart = 0 Then
            MsgBox("The new part # does not exist. You must create it first.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check if new part number already is an assembly with components
        Dim CheckNewAssembly As Integer = 0

        Dim CheckNewAssemblyStatement As String = "SELECT COUNT(AssemblyPartNumber) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CheckNewAssemblyCommand As New SqlCommand(CheckNewAssemblyStatement, con)
        CheckNewAssemblyCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtNewAssemblyPartNumber.Text
        CheckNewAssemblyCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckNewAssembly = CInt(CheckNewAssemblyCommand.ExecuteScalar)
        Catch ex As Exception
            CheckNewAssembly = 0
        End Try
        con.Close()

        If CheckNewAssembly > 0 Then
            Dim button As DialogResult = MessageBox.Show("This assembly already exists with components. Overwrite and continue?", "OVERWRITE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing lines to rewrite
                cmd = New SqlCommand("DELETE FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtNewAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        End If

        'Load BOM for old part number
        LoadOldBOM()

        'Get Header Data
        Dim AssemblyDescription, Comment, SerializedStatus As String
        Dim TotalCost As Double = 0

        Dim GetHeaderDataStatement As String = "SELECT * FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim GetHeaderDataCommand As New SqlCommand(GetHeaderDataStatement, con)
        GetHeaderDataCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtOldAssemblyPartNumber.Text
        GetHeaderDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetHeaderDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("AssemblyDescription")) Then
                AssemblyDescription = ""
            Else
                AssemblyDescription = reader.Item("AssemblyDescription")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("TotalCost")) Then
                TotalCost = 0
            Else
                TotalCost = reader.Item("TotalCost")
            End If
            If IsDBNull(reader.Item("SerializedStatus")) Then
                SerializedStatus = "NO"
            Else
                SerializedStatus = reader.Item("SerializedStatus")
            End If
        Else
            AssemblyDescription = ""
            Comment = ""
            SerializedStatus = "NO"
            TotalCost = 0
        End If
        reader.Close()
        con.Close()

        Try
            'Create new Assembly Header
            cmd = New SqlCommand("INSERT INTO AssemblyHeaderTable(AssemblyPartNumber, DivisionID, AssemblyDate, AssemblyDescription, Comment, TotalCost, SerializedStatus) Values (@AssemblyPartNumber, @DivisionID, @AssemblyDate, @AssemblyDescription, @Comment, @TotalCost, @SerializedStatus)", con)

            With cmd.Parameters
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtNewAssemblyPartNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@AssemblyDate", SqlDbType.VarChar).Value = Today()
                .Add("@AssemblyDescription", SqlDbType.VarChar).Value = AssemblyDescription
                .Add("@Comment", SqlDbType.VarChar).Value = Comment
                .Add("@TotalCost", SqlDbType.VarChar).Value = TotalCost
                .Add("@SerializedStatus", SqlDbType.VarChar).Value = SerializedStatus
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Update Assembly Header
            cmd = New SqlCommand("UPDATE AssemblyHeaderTable SET AssemblyDate = @AssemblyDate, AssemblyDescription = @AssemblyDescription, Comment = @Comment, TotalCost = @TotalCost, SerializedStatus = @SerializedStatus WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtNewAssemblyPartNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@AssemblyDate", SqlDbType.VarChar).Value = Today()
                .Add("@AssemblyDescription", SqlDbType.VarChar).Value = AssemblyDescription
                .Add("@Comment", SqlDbType.VarChar).Value = Comment
                .Add("@TotalCost", SqlDbType.VarChar).Value = TotalCost
                .Add("@SerializedStatus", SqlDbType.VarChar).Value = SerializedStatus
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try

        'Get Line Data and Add New Assembly Lines
        Dim ComponentLineNumber As Integer = 0
        Dim ComponentPartNumber As String = ""
        Dim ComponentPartDescription As String = ""
        Dim Quantity As Double = 0
        Dim UnitCost As Double = 0
        Dim ExtendedAmount As Double = 0
        Dim LineComment As String = ""

        For Each LineRow As DataGridViewRow In dgvOldAssemblyLines.Rows
            Try
                ComponentLineNumber = LineRow.Cells("ComponentLineNumberColumn2").Value
            Catch ex As System.Exception
                ComponentLineNumber = 0
            End Try
            Try
                ComponentPartNumber = LineRow.Cells("ComponentPartNumberColumn2").Value
            Catch ex As System.Exception
                ComponentPartNumber = ""
            End Try
            Try
                ComponentPartDescription = LineRow.Cells("ComponentPartDescriptionColumn2").Value
            Catch ex As System.Exception
                ComponentPartDescription = 0
            End Try
            Try
                Quantity = LineRow.Cells("QuantityColumn2").Value
            Catch ex As System.Exception
                Quantity = 0
            End Try
            Try
                UnitCost = LineRow.Cells("UnitCostColumn2").Value
            Catch ex As System.Exception
                UnitCost = 0
            End Try
            Try
                ExtendedAmount = LineRow.Cells("ExtendedAmountColumn2").Value
            Catch ex As System.Exception
                ExtendedAmount = 0
            End Try
            Try
                LineComment = LineRow.Cells("LineCommentColumn2").Value
            Catch ex As System.Exception
                LineComment = 0
            End Try

            Try
                'Add to line table
                cmd = New SqlCommand("INSERT INTO AssemblyLineTable(AssemblyPartNumber, ComponentLineNumber, DivisionID, ComponentPartNumber, ComponentPartDescription, Quantity, UnitCost, ExtendedCost, LineComment) Values (@AssemblyPartNumber, @ComponentLineNumber, @DivisionID, @ComponentPartNumber, @ComponentPartDescription, @Quantity, @UnitCost, @ExtendedCost, @LineComment)", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtNewAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ComponentLineNumber", SqlDbType.VarChar).Value = ComponentLineNumber
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = UnitCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedAmount
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Add to line table
                cmd = New SqlCommand("UPDATE AssemblyLineTable SET ComponentPartNumber = @ComponentPartNumber, ComponentPartDescription = @ComponentPartDescription, Quantity = @Quantity, UnitCost = @UnitCost, ExtendedCost = @ExtendedCost, LineComment = @LineComment WHERE AssemblyPartNumber = @AssemblyPartNumber AND ComponentLineNumber = @ComponentLineNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtNewAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ComponentLineNumber", SqlDbType.VarChar).Value = ComponentLineNumber
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = UnitCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedAmount
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try

            'Clear Variables
            ComponentLineNumber = 0
            ComponentPartDescription = ""
            ComponentPartNumber = ""
            Quantity = 0
            UnitCost = 0
            ExtendedAmount = 0
            LineComment = ""
        Next

        'Clear and load
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        ClearOldAssemblyLines()

        LoadPartNumber()
        LoadPartDescription()

        MsgBox("Assembly has been created", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdClearTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTwo.Click
        txtNewAssemblyPartNumber.Clear()
        txtOldAssemblyPartNumber.Clear()
    End Sub

End Class