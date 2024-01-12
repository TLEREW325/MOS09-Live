Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewItemClassPriceChangeTiers
    Inherits System.Windows.Forms.Form

    Dim DateFilter, ItemClassFilter As String
    Dim BeginDate As Date


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, tempDS As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewItemClassPriceChangeTiers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdFilter

        LoadCurrentDivision()
        LoadItemClass()
        LoadAddItemClass()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub LoadItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass ORDER BY ItemClassID", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemClass")
        cboItemClass.DataSource = ds1.Tables("ItemClass")
        con.Close()
        cboItemClass.SelectedIndex = -1
    End Sub

    Public Sub LoadAddItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass ORDER BY ItemClassID", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemClass")
        cboAddItemClass.DataSource = ds2.Tables("ItemClass")
        con.Close()
        cboAddItemClass.SelectedIndex = -1
    End Sub

    Public Sub ShowDataByFilters()
        'Create Filters
        BeginDate = dtpBracketDate.Value

        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND PriceClass = '" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If chkFilterDate.Checked = True Then
            DateFilter = " AND @BeginDate BETWEEN BeginDate AND EndDate"
        Else
            DateFilter = ""
        End If

        'Load Data Into Dataset
        cmd = New SqlCommand("SELECT * FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID" + ItemClassFilter + DateFilter + " ORDER BY DivisionID, BeginDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceChangeTable")
        dgvPriceChangeTiers.DataSource = ds.Tables("ItemPriceChangeTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvPriceChangeTiers.DataSource = Nothing
    End Sub

    Public Sub ClearData()
        cboItemClass.SelectedIndex = -1
        chkFilterDate.Checked = False
        dtpBracketDate.Text = ""

        cboItemClass.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddTier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddTier.Click
        'Validate for blank fields
        If cboAddItemClass.Text = "" Or txtAdjustmentRate.Text = "" Then
            MsgBox("You must have a valid Item Class and Rate entered.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check to see if it's a valid Item Class
        Dim CountItemClass As Integer = 0

        Dim CountItemClassStatement As String = "SELECT COUNT(ItemClassID) FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim CountItemClassCommand As New SqlCommand(CountItemClassStatement, con)
        CountItemClassCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboAddItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountItemClass = CInt(CountItemClassCommand.ExecuteScalar)
        Catch ex As System.Exception
            CountItemClass = 0
        End Try
        con.Close()

        If CountItemClass = 1 Then
            'Continue
        Else
            MsgBox("You must have a valid Item Class selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Verify that no duplicates are entered and it's the last cost tier
        Dim CountCostTier As Integer = 0

        Dim CountCostTierStatement As String = "SELECT COUNT(PriceClass) FROM ItemPriceChangeTable WHERE PriceClass = @PriceClass AND DivisionID = @DivisionID AND CostTierNumber = @CostTierNumber"
        Dim CountCostTierCommand As New SqlCommand(CountCostTierStatement, con)
        CountCostTierCommand.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = cboAddItemClass.Text
        CountCostTierCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CountCostTierCommand.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = nbrAddTierNumber.Value

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountCostTier = CInt(CountCostTierCommand.ExecuteScalar)
        Catch ex As System.Exception
            CountCostTier = 0
        End Try
        con.Close()

        If CountCostTier = 0 Then
            'Continue
        Else
            MsgBox("A Tier already exists for this division, item class, and tier number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Validate number in the rate field
        If IsNumeric(txtAdjustmentRate.Text) Then
            'Continue
        Else
            MsgBox("You must have a valid number in the rate field.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Val(txtAdjustmentRate.Text) > 0 And Val(txtAdjustmentRate.Text) < 1 Then
            'Continue
        Else
            MsgBox("Adjustment rate must be a decimal less than 1 and greater than zero.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            'INSERT INTO Price Change Table
            cmd = New SqlCommand("INSERT INTO ItemPriceChangeTable (PriceClass, DivisionID, BeginDate, EndDate, PriceAdjustment, CostTierNumber, Comment) values (@PriceClass, @DivisionID, @BeginDate, @EndDate, @PriceAdjustment, @CostTierNumber, @Comment)", con)

            With cmd.Parameters
                .Add("@PriceClass", SqlDbType.VarChar).Value = cboAddItemClass.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Value
                .Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Value
                .Add("@PriceAdjustment", SqlDbType.VarChar).Value = Val(txtAdjustmentRate.Text)
                .Add("@CostTierNumber", SqlDbType.VarChar).Value = nbrAddTierNumber.Value
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox("Entry failed.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try

        ShowDataByFilters()
        MsgBox("Price change tier entered.", MsgBoxStyle.OkOnly)
        cmdClearTier_Click(sender, e)
    End Sub

    Private Sub cmdClearTier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTier.Click
        cboAddItemClass.SelectedIndex = -1
        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""
        txtAdjustmentRate.Clear()
        nbrAddTierNumber.Value = 1
        txtComment.Clear()
        cboAddItemClass.Focus()
    End Sub

    Private Sub cmdDeleteTier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteTier.Click
        If Me.dgvPriceChangeTiers.RowCount <> 0 Then
            Dim RowPriceClass, RowDivision As String
            Dim RowTierNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvPriceChangeTiers.CurrentCell.RowIndex

            Try
                RowPriceClass = Me.dgvPriceChangeTiers.Rows(RowIndex).Cells("PriceClassColumn").Value
            Catch ex As Exception
                RowPriceClass = ""
            End Try
            Try
                RowDivision = Me.dgvPriceChangeTiers.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = EmployeeCompanyCode
            End Try
            Try
                RowTierNumber = Me.dgvPriceChangeTiers.Rows(RowIndex).Cells("CostTierNumberColumn").Value
            Catch ex As Exception
                RowTierNumber = 0
            End Try

            'Get MAX Tier Number and dont allow them to delete a tier before the last one

            'Get highest cost tier number
            Dim MAXCostTier As Integer = 0

            Dim MAXCostTierStatement As String = "SELECT MAX(CostTierNumber) FROM ItemPriceChangeTable WHERE PriceClass = @PriceClass AND DivisionID = @DivisionID"
            Dim MAXCostTierCommand As New SqlCommand(MAXCostTierStatement, con)
            MAXCostTierCommand.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = RowPriceClass
            MAXCostTierCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostTier = CInt(MAXCostTierCommand.ExecuteScalar)
            Catch ex As System.Exception
                MAXCostTier = 0
            End Try
            con.Close()

            If MAXCostTier = RowTierNumber Then
                'Continue with deletion
                Try
                    'INSERT INTO Price Change Table
                    cmd = New SqlCommand("DELETE FROM ItemPriceChangeTable WHERE PriceClass = @PriceClass AND DivisionID = @DivisionID AND CostTierNumber = @CostTierNumber", con)

                    With cmd.Parameters
                        .Add("@PriceClass", SqlDbType.VarChar).Value = cboAddItemClass.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@CostTierNumber", SqlDbType.VarChar).Value = nbrAddTierNumber.Value
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    MsgBox("Entry failed.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End Try

                MsgBox("Price Change Tier has been deleted.", MsgBoxStyle.OkOnly)

                ShowDataByFilters()
            Else
                MsgBox("You cannot delete this price change tier because there are tiers after it.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
    End Sub
End Class