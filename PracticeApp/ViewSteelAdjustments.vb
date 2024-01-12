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
Public Class ViewSteelAdjustments
    Inherits System.Windows.Forms.Form

    Dim CarbonFilter, SteelFilter, AdjustmentFilter, BatchFilter, VendorFilter, DateFilter As String
    Dim AdjustmentNumber, BatchNumber As Integer
    Dim strAdjustmentNumber, strBatchNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim SteelDT As Data.DataTable
    Dim isLoaded As Boolean = False

    Private Sub ViewSteelAdjustments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadSteel()
        LoadAdjustmentNumber()
        isLoaded = True
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelAdjustments.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        cmd = New SqlCommand("", con)
        If cboBatchNumber.Text <> "" Then
            BatchNumber = Val(cboAdjustmentNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND BatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If cboAdjustmentNumber.Text <> "" Then
            AdjustmentNumber = Val(cboAdjustmentNumber.Text)
            strAdjustmentNumber = CStr(AdjustmentNumber)
            AdjustmentFilter = " AND SteelAdjustmentKey = '" + strAdjustmentNumber + "'"
        Else
            AdjustmentFilter = ""
        End If
        If cboCarbon.Text <> "" Then
            CarbonFilter = " AND SteelCarbon = '" + cboCarbon.Text + "'"
        Else
            CarbonFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelFilter = " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
            If cboSteelSize.Text.Contains("/") Then
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
            End If
        Else
            SteelFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            DateFilter = " AND AdjustmentDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd.CommandText = "SELECT * FROM SteelAdjustmentTable WHERE DivisionID = @DivisionID" + SteelFilter + CarbonFilter + AdjustmentFilter + BatchFilter + DateFilter
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBegin.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEnd.Text
        Dim dt As New Data.DataTable("SteelAdjustmentTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        dgvSteelAdjustments.DataSource = dt
    End Sub

    Private Sub LoadSteel()
        cmd = New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(SteelDT)
        con.Close()

        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadAdjustmentNumber()
        cmd = New SqlCommand("SELECT SteelAdjustmentKey FROM SteelAdjustmentTable WHERE DivisionID = @DivisionID", con)
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If
        Dim dt As New Data.DataTable("SteelAdjustmentTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboAdjustmentNumber.DataSource = dt
        cboAdjustmentNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT BatchNumber FROM SteelAdjustmentTable WHERE DivisionID = @DivisionID", con)
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        Dim dt As New Data.DataTable("SteelAdjustmentTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboBatchNumber.DataSource = dt
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearVariables()
        CarbonFilter = ""
        SteelFilter = ""
        AdjustmentFilter = ""
        BatchFilter = ""
        VendorFilter = ""
        DateFilter = ""
        AdjustmentNumber = 0
        BatchNumber = 0
        strAdjustmentNumber = ""
        strBatchNumber = ""
    End Sub

    Public Sub ClearData()
        isLoaded = False
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        cboBatchNumber.SelectedIndex = -1
        cboAdjustmentNumber.SelectedIndex = -1

        dtpBegin.Text = ""
        dtpEnd.Text = ""

        chkDateRange.Checked = False
        chkAllTypes.Checked = False
        isLoaded = True
        cboCarbon.Focus()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If dgvSteelAdjustments.DataSource IsNot Nothing Then
            Using NewPrintSteelAdjustment As New PrintSteelAdjustment(CType(dgvSteelAdjustments.DataSource, Data.DataTable))
                Dim result = NewPrintSteelAdjustment.ShowDialog()
            End Using
        Else
            MessageBox.Show("You need to view steel adjustments.", "Unable to print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSteelAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSteelAdjustment.Click
        Dim NewSteelAdjustmentForm As New SteelAdjustmentForm()
        NewSteelAdjustmentForm.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
        If e.KeyChar.Equals("."c) And (cboSteelSize.Text.Length = 0 Or cboSteelSize.SelectionLength = cboSteelSize.Text.Length) Then
            cboSteelSize.Text = "0."
            e.KeyChar = Nothing
            cboSteelSize.SelectionStart = cboSteelSize.Text.Length
            cboSteelSize.SelectionLength = 0
        End If
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                If cboSteelSize.Text.Contains("/") Then
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                Else
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                End If
                cboCarbon.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
                cboCarbon.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Leave
        If Not String.IsNullOrEmpty(cboSteelSize.Text) AndAlso cboSteelSize.SelectedIndex = -1 Then
            If cboSteelSize.Text.Contains("/") Then
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                End If
            Else
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.GetFractional(cboSteelSize.Text)
                End If
            End If
        End If
    End Sub

    Private Sub chkShowAllTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTypes.CheckedChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub
End Class