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
Public Class ViewSteelUsage
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable

    Dim SteelDT As DataTable
    Dim isLoaded As Boolean = False

    Private Sub ViewSteelUsage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        LoadCoilID()
        LoadHeatNumber()
        LoadSteel()

        ClearData()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelRemoval.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        cmd = New SqlCommand("SELECT * FROM SteelUsageQuery WHERE DivisionID = 'TWD'", con)
        Dim TotalCMD As New SqlCommand("SELECT SUM(UsageWeight) as TotalWeight, COUNT(SteelUsageKey) as Entries FROM SteelUsageQuery WHERE DivisionID = 'TWD'", con)
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            If chkAllTypes.Checked Then
                cmd.CommandText += " AND Carbon Like @Carbon"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
                TotalCMD.CommandText += " AND Carbon Like @Carbon"
                TotalCMD.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
            Else
                cmd.CommandText += " AND Carbon = @Carbon"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                TotalCMD.CommandText += " AND Carbon = @Carbon"
                TotalCMD.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            End If
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cmd.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize1)"
            TotalCMD.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize1)"
            If cboSteelSize.Text.Contains("/") Then
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                cmd.Parameters.Add("@SteelSize1", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                TotalCMD.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                TotalCMD.Parameters.Add("@SteelSize1", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd.Parameters.Add("@SteelSize1", SqlDbType.VarChar).Value = usefulFunctions.GetFractional(cboSteelSize.Text)
                TotalCMD.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                TotalCMD.Parameters.Add("@SteelSize1", SqlDbType.VarChar).Value = usefulFunctions.GetFractional(cboSteelSize.Text)
            End If
        End If
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cmd.CommandText += " AND HeatNumber = @HeatNumber"
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            TotalCMD.CommandText += " AND HeatNumber = @HeatNumber"
            TotalCMD.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboCoilID.Text) Then
            cmd.CommandText += " AND ReferenceNumber = @CoilID"
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
            TotalCMD.CommandText += " AND ReferenceNumber = @CoilID"
            TotalCMD.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
        End If

        If chkDateRange.Checked Then
            cmd.CommandText += " AND UsageDate BETWEEN @BeginDate AND @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
            TotalCMD.CommandText += " AND UsageDate BETWEEN @BeginDate AND @EndDate"
            TotalCMD.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            TotalCMD.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        cmd.CommandText += " ORDER BY SteelUsageKey"
        Dim dt As New Data.DataTable("SteelUsageQuery")
        Dim totalDT As New Data.DataTable("SteelUsageQuery")
        Dim adap As New SqlDataAdapter(cmd)
        Dim totalADAP As New SqlDataAdapter(TotalCMD)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        totalADAP.Fill(totalDT)
        con.Close()

        dgvSteelRemoval.DataSource = dt
        If totalDT.Rows.Count > 0 Then
            If Not IsDBNull(totalDT.Rows(0).Item("TotalWeight")) Then txtCoilWeight.Text = totalDT.Rows(0).Item("TotalWeight") Else txtCoilWeight.Text = "0"
            If Not IsDBNull(totalDT.Rows(0).Item("Entries")) Then txtNumberOfCoils.Text = totalDT.Rows(0).Item("Entries") Else txtNumberOfCoils.Text = "0"
        Else
            txtCoilWeight.Text = "0"
            txtNumberOfCoils.Text = "0"
        End If
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM HeatNumberLog ORDER BY HeatNumber", con)
        Dim dt As New Data.DataTable("HeatNumberLog")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboHeatNumber.DataSource = dt
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCoilID()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification ORDER BY CoilID", con)
        Dim dt As New Data.DataTable("CharterSteelCoilIdentification")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboCoilID.DataSource = dt
        cboCoilID.SelectedIndex = -1
    End Sub

    Public Sub LoadSteel()
        cmd = New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable ORDER BY RMID", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(SteelDT)
        con.Close()

        cboCarbon.DataSource = SteelDT
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DataSource = SteelDT
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        isLoaded = False
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then cboCarbon.Text = ""
        cboCoilID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCoilID.Text) Then cboCoilID.Text = ""
        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then cboHeatNumber.Text = ""
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then cboSteelSize.Text = ""

        txtCoilWeight.Clear()
        txtNumberOfCoils.Clear()

        chkAllTypes.Checked = False
        chkDateRange.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCarbon.Focus()
        isLoaded = True
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If dgvSteelRemoval.DataSource IsNot Nothing Then
            Dim NewPrintSteelUsage As New PrintSteelUsage(CType(dgvSteelRemoval.DataSource, Data.DataTable))
            NewPrintSteelUsage.ShowDialog()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearDataInDatagrid()
        ClearData()
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
        ElseIf cboSteelSize.SelectedIndex = -1 Then
            Dim tmp As String = cboCarbon.Text
            isloaded = False
            cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
            cboCarbon.Text = tmp
            isloaded = True
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