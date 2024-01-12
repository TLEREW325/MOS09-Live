Imports System
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class ViewTimeSlipTotals
    Inherits System.Windows.Forms.Form

    Dim MachineFilter, DateFilter, PartFilter, FOXFilter, EmployeeFilter As String
    Dim FOXNumber As Integer
    Dim strFOXNumber, EmployeeFirst, EmployeeLast As String
    Dim cmsAdminMenu As New ContextMenu()

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter2 As New SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim isLoaded As Boolean = False
    Dim dt, SteelDT As Data.DataTable

    Public Sub New()
        InitializeComponent()
        cmsAdminMenu.MenuItems.Add("Reverse Posting", AddressOf ReverseTimeSlipPosting)
        cmsAdminMenu.MenuItems(0).Name = "ReversePosting"
        cmsAdminMenu.MenuItems.Add("Add To Finished Goods", AddressOf AddToFinishedGoods)
        cmsAdminMenu.MenuItems(1).Name = "AddToFinishedGoods"
        cmsAdminMenu.MenuItems.Add("Manual WIP Flush", AddressOf ManualWIPFlush)
        cmsAdminMenu.MenuItems.Add("Fiscal Year WIP Flush", AddressOf FYWIPFlush)

        LoadPartNumber()
        LoadPartDescription()
        LoadFOXNumber()
        LoadMachineNumber()
        LoadEmployee()
        LoadSteel()
        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True
        Me.AcceptButton = cmdViewByFilter
    End Sub

    Private Sub ViewTimeSlipTotals_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        isLoaded = False
        ClearVariables()
        ClearData()
    End Sub

    Public Sub ShowPostingsByFilters()
        isLoaded = False
        Dim TotalCMD As New SqlCommand("", con)
        If EmployeeCompanyCode.Equals("TST") Then
            cmd = New SqlCommand("SELECT TimeSlipHeaderTable.PostingDate, TimeSlipLineItemTable.TimeSlipKey, TimeSlipLineItemTable.RMID, TimeSlipHeaderTable.EmployeeID, EmployeeName, Shift, FOXNumber, MachineNumber, PartNumber, RawMaterialsTable.Carbon, RawMaterialsTable.SteelSize, MachineHours, TotalHours, PiecesProduced, TimeSlipLineItemTable.InventoryPieces, ROUND(LineWeight, 2) as LineWeight, CASE WHEN MachineHours = 0 OR isnull(MaxPiecesPerHour, 0) = 0 THEN 0 ELSE ROUND((PiecesProduced / TotalHours) / MaxPiecesPerHour, 5) END as PercentToMax, ScrapWeight, isnull(PostingReversed, 'False') as PostingReversed, LineKey, isnull(PostingAddFG, 'False') as PostingAddFG, PostingChanger, PostingChangedDate, PostingChangeComment, TimeSlipLineItemTable.DivisionID, TimeSlipLineItemTable.FOXStep, TimeSlipLineItemTable.ProductionNumber, TimeSlipLineItemTable.Cost, TimeSlipLineItemTable.ExtendedCost, TimeSlipLineItemTable.ExtendedSteelCost FROM TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable on TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN RawMaterialsTable on TimeSlipLineItemTable.RMID = RawMaterialsTable.RMID INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID WHERE (TimeSlipLineItemTable.DivisionID = 'TWD' OR TimeSlipLineItemTable.DivisionID = 'TFP' OR TimeSlipLineItemTable.DivisionID = 'TST') AND TimeSlipLineItemTable.LineKey < 100 AND MachineTable.DivisionID = 'TWD'", con)
        Else
            cmd = New SqlCommand("SELECT TimeSlipHeaderTable.PostingDate, TimeSlipLineItemTable.TimeSlipKey, TimeSlipLineItemTable.RMID, TimeSlipHeaderTable.EmployeeID, EmployeeName, Shift, FOXNumber, MachineNumber, PartNumber, RawMaterialsTable.Carbon, RawMaterialsTable.SteelSize, MachineHours, TotalHours, PiecesProduced, TimeSlipLineItemTable.InventoryPieces, ROUND(LineWeight, 2) as LineWeight, CASE WHEN MachineHours = 0 OR isnull(MaxPiecesPerHour, 0) = 0 THEN 0 ELSE ROUND((PiecesProduced / TotalHours) / MaxPiecesPerHour, 5) END as PercentToMax, ScrapWeight, isnull(PostingReversed, 'False') as PostingReversed, LineKey, isnull(PostingAddFG, 'False') as PostingAddFG, PostingChanger, PostingChangedDate, PostingChangeComment, TimeSlipLineItemTable.DivisionID, TimeSlipLineItemTable.FOXStep, TimeSlipLineItemTable.ProductionNumber, TimeSlipLineItemTable.Cost, TimeSlipLineItemTable.ExtendedCost, TimeSlipLineItemTable.ExtendedSteelCost FROM TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable on TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN RawMaterialsTable on TimeSlipLineItemTable.RMID = RawMaterialsTable.RMID INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID WHERE (TimeSlipLineItemTable.DivisionID = 'TWD' OR TimeSlipLineItemTable.DivisionID = 'TFP') AND TimeSlipLineItemTable.LineKey < 100 AND MachineTable.DivisionID = 'TWD'", con)
        End If

        Dim Filters As String = ""
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cmd.CommandText += " AND PartNumber = @PartNumber"
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            Filters += " AND TimeSlipLineItemTable.PartNumber = @PartNumber"
            TotalCMD.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboEmployeeID.Text) Then
            cmd.CommandText += " AND EmployeeID = @EmployeeID"
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text

            Filters += " AND EmployeeID = @EmployeeID"
            TotalCMD.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
        End If
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cmd.CommandText += " AND FOXNumber = @FOXNumber"
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

            Filters += " AND TimeSlipLineItemTable.FOXNumber = @FOXNumber"
            TotalCMD.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cmd.CommandText += " AND Carbon = @Carbon"
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text

            Filters += " AND RawMaterialsTable.Carbon = @Carbon"
            TotalCMD.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cmd.CommandText += " AND SteelSize = @SteelSize"
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

            Filters += " AND RawMaterialsTable.SteelSize = @SteelSize"
            TotalCMD.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        End If
        If Not String.IsNullOrEmpty(cboShiftNumber.Text) Then
            cmd.CommandText += " AND Shift = @Shift"
            cmd.Parameters.Add("@Shift", SqlDbType.Int).Value = Val(cboShiftNumber.Text)

            Filters += " AND Shift = @Shift"
            TotalCMD.Parameters.Add("@Shift", SqlDbType.Int).Value = Val(cboShiftNumber.Text)
        End If
        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            cmd.CommandText += " AND MachineNumber = @MachineNumber"
            cmd.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text

            Filters += " AND MachineNumber = @MachineNumber"
            TotalCMD.Parameters.Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboStatus.Text) Then
            cmd.CommandText += " AND Status = @Status"
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = cboStatus.Text

            Filters += " AND TimeSlipHeaderTable.Status = @Status"
            TotalCMD.Parameters.Add("@Status", SqlDbType.VarChar).Value = cboStatus.Text
        End If
        If chkDateRange.Checked Then
            cmd.CommandText += " AND PostingDate BETWEEN @BeginDate AND @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

            Filters += " AND PostingDate BETWEEN @BeginDate AND @EndDate"
            TotalCMD.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            TotalCMD.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        End If

        cmd.CommandText += " order by TimeSlipHeaderTable.TimeSlipKey;"
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "TimeSlipCombinedData")

        TotalCMD.CommandText = " SELECT SUM(InventoryPieces) as TotalInventoryPieces FROM TimeSlipLineItemTable INNER JOIN RawMaterialsTable ON TimeSlipLineItemTable.RMID = RawMaterialsTable.RMID LEFT OUTER JOIN TimeSlipHeaderTable ON TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey WHERE (TimeSlipLineItemTable.DivisionID = 'TWD' OR TimeSlipLineItemTable.DivisionID = 'TFP') AND TimeSlipLineItemTable.LineKey < 100 " + Filters
        Dim TotalBlanks As Integer = 0
        Dim TotalInventoryPieces As Integer = 0
        Dim TotalWeight As Double = 0D

        Dim reader As SqlDataReader = TotalCMD.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("TotalInventoryPieces")) Then
                    TotalInventoryPieces += reader.Item("TotalInventoryPieces")
                End If
            End While
        End If
        reader.Close()

        TotalCMD.CommandText = "SELECT ROUND(SUM(RawMaterialWeight), 2) as RawMaterialConsumed FROM (SELECT TimeSlipLineItemTable.FOXNumber, (PiecesProduced * (isnull(FoxTable.RawMaterialWeight, 0) / 1000)) as RawMaterialWeight FROM TimeSlipLineItemTable INNER JOIN RawMaterialsTable ON TimeSlipLineItemTable.RMID = RawMaterialsTable.RMID INNER JOIN TimeSlipHeaderTable ON TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey INNER JOIN FOXTable ON TimeSlipLineItemTable.FOXNumber = FOXTable.FOXNumber WHERE (TimeSlipLineItemTable.DivisionID = 'TWD' OR TimeSlipLineItemTable.DivisionID = 'TFP') AND TimeSlipLineItemTable.LineKey < 100 AND FOXStep = 1 AND LineKey < 100 AND PiecesProduced > 0 " + Filters + " ) as Weights"

        reader = TotalCMD.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("RawMaterialConsumed")) Then
                    TotalWeight += reader.Item("RawMaterialConsumed")
                End If
            End While
        End If
        reader.Close()

        ''Gets the timeslip entries based on the filters applied, summing the pieces produced grouping them by the FOX number.
        ''The first line gets only the first FOX step that did not add to inventory and have a pieces produced > 0.
        ''The first line left outer joins with the second line on the FOX number.
        ''The ending SELECT statement is subtracting the second steps pieces from the first steps but if it is < 0 will just use 0 in the summation.
        TotalCMD.CommandText = "SELECT SUM(StepOneTotalPieces) as TotalBlanks FROM (SELECT FOXNumber, isnull(SUM(PiecesProduced), 0) as StepOneTotalPieces FROM (SELECT FOXNumber, PiecesProduced, FOXStep, InventoryPieces FROM TimeSlipLineItemTable INNER JOIN TimeSlipHeaderTable on TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey INNER JOIN RawMaterialsTable on TimeSlipLineItemTable.RMID = RawMaterialsTable.RMID INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID WHERE (TimeSlipLineItemTable.DivisionID = 'TWD' OR TimeSlipLineItemTable.DivisionID = 'TFP' OR TimeSlipLineItemTable.DivisionID = 'TST') AND TimeSlipLineItemTable.LineKey < 100 AND MachineTable.DivisionID = 'TWD' " + Filters + ") as TimeSlipStepOne WHERE FOXStep = 1 and InventoryPieces = 0  GROUP BY FOXNumber UNION ALL"
        ''gets timeslips associated with fox step 2 and sums them grouped by FOX number.
        TotalCMD.CommandText += " SELECT FOXNumber, (-1 * isnull(SUM(PiecesProduced), 0)) as StepTwoTotalPieces FROM (SELECT  FOXNumber, PiecesProduced, FOXStep  FROM TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable on TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN RawMaterialsTable on TimeSlipLineItemTable.RMID = RawMaterialsTable.RMID INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID WHERE (TimeSlipLineItemTable.DivisionID = 'TWD' OR TimeSlipLineItemTable.DivisionID = 'TFP' OR TimeSlipLineItemTable.DivisionID = 'TST') AND TimeSlipLineItemTable.LineKey < 100 AND MachineTable.DivisionID = 'TWD' " + Filters + ")as TimeSlipFOXStepTwo WHERE FOXStep = 2 GROUP BY FOXNumber) as tmp"
        reader = TotalCMD.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("TotalBlanks")) Then
                    TotalBlanks += reader.Item("TotalBlanks")
                End If
            End While
        End If
        reader.Close()
        con.Close()

        lblTotalBlanks.Text = FormatNumber(TotalBlanks, 0)
        lblTotalInventoryPieces.Text = FormatNumber(TotalInventoryPieces, 0)
        lblTotalWeight.Text = FormatNumber(Math.Round(TotalWeight, 2, MidpointRounding.AwayFromZero), 2)

        dgvTimeSlipPostings.DataSource = ds.Tables("TimeSlipCombinedData")
        setupTimeSlipPostingsDGV()
        isLoaded = True
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = 'TWD'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        If PartNumber1 = "" Then
            Dim PartNumber2Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = 'TFP'"
            Dim PartNumber2Command As New SqlCommand(PartNumber2Statement, con)
            PartNumber2Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartNumber1 = CStr(PartNumber2Command.ExecuteScalar)
            Catch ex As Exception
                PartNumber1 = ""
            End Try
            con.Close()
        End If

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = 'TWD'"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        If PartDescription1 = "" Then
            Dim PartDescription2Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = 'TFP'"
            Dim PartDescription2Command As New SqlCommand(PartDescription2Statement, con)
            PartDescription2Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PartDescription1 = CStr(PartDescription2Command.ExecuteScalar)
            Catch ex As Exception
                PartDescription1 = ""
            End Try
            con.Close()
        End If

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub setupTimeSlipPostingsDGV()
        dgvTimeSlipPostings.Columns("PostingDate").HeaderText = "Production Date"
        dgvTimeSlipPostings.Columns("RMID").Visible = False
        dgvTimeSlipPostings.Columns("EmployeeID").HeaderText = "Employee ID"
        dgvTimeSlipPostings.Columns("EmployeeName").HeaderText = "Employee Name"
        dgvTimeSlipPostings.Columns("FOXNumber").HeaderText = "FOX Number"
        dgvTimeSlipPostings.Columns("MachineNumber").HeaderText = "Machine Number"
        dgvTimeSlipPostings.Columns("SteelSize").HeaderText = "Steel Size"
        dgvTimeSlipPostings.Columns("MachineHours").HeaderText = "Machine Hours"
        dgvTimeSlipPostings.Columns("TotalHours").HeaderText = "Total Hours"
        dgvTimeSlipPostings.Columns("PiecesProduced").HeaderText = "Pieces Produced"
        dgvTimeSlipPostings.Columns("PiecesProduced").DefaultCellStyle.Format = "N0"
        dgvTimeSlipPostings.Columns("LineWeight").HeaderText = "Total Piece Weight"
        dgvTimeSlipPostings.Columns("TimeSlipKey").HeaderText = "Time Slip #"
        dgvTimeSlipPostings.Columns("LineKey").Visible = False
        dgvTimeSlipPostings.Columns("PercentToMax").HeaderText = "Percent To Max"
        dgvTimeSlipPostings.Columns("PercentToMax").DefaultCellStyle.Format = "P2"
        dgvTimeSlipPostings.Columns("ScrapWeight").HeaderText = "Scrap Weight"
        dgvTimeSlipPostings.Columns("InventoryPieces").HeaderText = "Inventory Pieces"
        'dgvTimeSlipPostings.Columns("DivisionID").Visible = False
        'dgvTimeSlipPostings.Columns("FOXStep").Visible = False
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            dgvTimeSlipPostings.Columns("PostingReversed").HeaderText = "Posting ADMIN Reversed"
            dgvTimeSlipPostings.Columns("PostingAddFG").HeaderText = "Posting ADMIN Add FG"
            dgvTimeSlipPostings.Columns("PostingChanger").HeaderText = "Posting Changer"
            dgvTimeSlipPostings.Columns("PostingChangedDate").HeaderText = "Posting Changed Date"
            dgvTimeSlipPostings.Columns("PostingChangeComment").HeaderText = "Posting Changed Comment"
            dgvTimeSlipPostings.Columns("ProductionNumber").HeaderText = "Production Number"
            dgvTimeSlipPostings.Columns("Cost").HeaderText = "Cost Per Piece"
            dgvTimeSlipPostings.Columns("Cost").DefaultCellStyle.Format = "N5"
            dgvTimeSlipPostings.Columns("ExtendedCost").HeaderText = "Total Machine & Labor Cost"
            dgvTimeSlipPostings.Columns("ExtendedCost").DefaultCellStyle.Format = "N2"
            dgvTimeSlipPostings.Columns("ExtendedSteelCost").HeaderText = "Total Steel Cost"
            dgvTimeSlipPostings.Columns("ExtendedSteelCost").DefaultCellStyle.Format = "N2"
            ColorRows()
        Else
            dgvTimeSlipPostings.Columns("PostingReversed").Visible = False
            dgvTimeSlipPostings.Columns("PostingAddFG").Visible = False
            dgvTimeSlipPostings.Columns("PostingChanger").Visible = False
            dgvTimeSlipPostings.Columns("PostingChangedDate").Visible = False
            dgvTimeSlipPostings.Columns("PostingChangeComment").Visible = False
            dgvTimeSlipPostings.Columns("ProductionNumber").Visible = False
            dgvTimeSlipPostings.Columns("Cost").Visible = False
            dgvTimeSlipPostings.Columns("ExtendedCost").Visible = False
            dgvTimeSlipPostings.Columns("ExtendedSteelCost").Visible = False
        End If
        For i As Integer = 0 To dgvTimeSlipPostings.Columns.Count - 1
            If EmployeeSecurityCode <= 1002 Then
                If dgvTimeSlipPostings.Columns(i).DataPropertyName.Equals("ProductionNumber") Or dgvTimeSlipPostings.Columns(i).DataPropertyName.Equals("PostingChangeComment") Then
                    dgvTimeSlipPostings.Columns(i).ReadOnly = False
                Else
                    dgvTimeSlipPostings.Columns(i).ReadOnly = True
                End If
            Else
                dgvTimeSlipPostings.Columns(i).ReadOnly = True
            End If
        Next
        If EmployeeSecurityCode <= 1002 Then
            For i As Integer = 0 To dgvTimeSlipPostings.Rows.Count - 1
                If Not dgvTimeSlipPostings.Rows(i).Cells("PostingReversed").ToString.Equals("True") And Not dgvTimeSlipPostings.Rows(i).Cells("PostingAddFG").ToString.Equals("True") Then
                    dgvTimeSlipPostings.Rows(i).Cells("PostingChangeComment").ReadOnly = True
                End If
            Next
        End If
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboFOXNumber.Items.Add(reader.Item("FOXNumber"))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP';", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()
        cboPartNumber.DisplayMember = "ItemID"
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP';", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()
        cboPartDescription.DisplayMember = "ShortDescription"
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadLongDescription()
        cmd = New SqlCommand("SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP');", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            txtPartDescription.Text = cmd.ExecuteScalar()
        Catch ex As Exception
            txtPartDescription.Text = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadMachineNumber()
        cmd = New SqlCommand("SELECT DISTINCT(MachineID) as MachineID FROM MachineTable WHERE DivisionID = 'TWD' OR DivisionID = 'TFP';", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboMachineNumber.Items.Add(reader.Item("MachineID"))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Public Sub LoadEmployee()
        cmd = New SqlCommand("SELECT EmployeeID FROM EmployeeData;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboEmployeeID.Items.Add(reader.Item("EmployeeID"))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadSteel()
        cmd = New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable;", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(SteelDT)

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub dgvTimeSlipPostings_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTimeSlipPostings.CellDoubleClick
        Dim RowTimeSlipNumber As Integer
        Dim RowIndex As Integer = Me.dgvTimeSlipPostings.CurrentCell.RowIndex

        RowTimeSlipNumber = Me.dgvTimeSlipPostings.Rows(RowIndex).Cells("TimeSlipKey").Value

        GlobalTimeSlipNumber = RowTimeSlipNumber

        Using NewPrintTimeSlipPostings As New PrintTimeSlipPostings
            Dim result = NewPrintTimeSlipPostings.ShowDialog()
        End Using
    End Sub

    Public Sub LoadEmployeeName()
        Dim EmployeeLastStatement As String = "SELECT EmployeeLast, EmployeeFirst FROM EmployeeData WHERE EmployeeID = @EmployeeID;"
        Dim EmployeeLastCommand As New SqlCommand(EmployeeLastStatement, con)
        EmployeeLastCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = EmployeeLastCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("EmployeeLast")) Then
                EmployeeLast = ""
            Else
                EmployeeLast = reader.Item("EmployeeLast")
            End If
            If IsDBNull(reader.Item("EmployeeFirst")) Then
                EmployeeFirst = ""
            Else
                EmployeeFirst = reader.Item("EmployeeFirst")
            End If
        Else
            EmployeeLast = ""
            EmployeeFirst = ""
        End If
        reader.Close()
        con.Close()

        txtEmployeeName.Text = EmployeeFirst + " " + EmployeeLast
    End Sub

    Private Sub cboEmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployeeID.SelectedIndexChanged
        If isLoaded Then
            LoadEmployeeName()
        End If
    End Sub

    Public Sub ClearData()
        cboEmployeeID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboEmployeeID.Text) Then
            cboEmployeeID.Text = ""
        End If
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        cboMachineNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboMachineNumber.Text) Then
            cboMachineNumber.Text = ""
        End If
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        cboPartDescription.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            cboPartDescription.Text = ""
        End If
        cboShiftNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboShiftNumber.Text) Then
            cboShiftNumber.Text = ""
        End If
        cboCarbon.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        cboSteelSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If

        txtEmployeeName.Clear()
        txtPartDescription.Clear()

        chkDateRange.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        lblTotalBlanks.Text = ""
        lblTotalInventoryPieces.Text = ""
        lblTotalWeight.Text = ""

        dgvTimeSlipPostings.DataSource = Nothing

        cboFOXNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        MachineFilter = ""
        DateFilter = ""
        PartFilter = ""
        FOXFilter = ""
        EmployeeFilter = ""
        FOXNumber = 0
        strFOXNumber = ""
        EmployeeFirst = ""
        EmployeeLast = ""
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowPostingsByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isLoaded = False
        ClearVariables()
        ClearData()
        isLoaded = True
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        Using NewPrintTimeSlipPostings As New PrintTimeSlipPostings(ds)
            Dim result = NewPrintTimeSlipPostings.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintTimeSlipPostings As New PrintTimeSlipPostings(ds)
            Dim result = NewPrintTimeSlipPostings.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        isLoaded = False
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        isLoaded = False
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadDescriptionByPart()
            LoadLongDescription()
        End If
    End Sub

    Private Sub cmdPrintListingWithTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintListingWithTotals.Click
        Using NewPrintTimeSlipPostings As New PrintTimeSlipPostings(ds, True)
            Dim result = NewPrintTimeSlipPostings.ShowDialog()
        End Using
    End Sub

    Private Sub ReverseTimeSlipPosting(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgvTimeSlipPostings.CurrentCell IsNot Nothing And MessageBox.Show("Are you sure you wish to reverse this posting?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            If Not dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingReversed").Value.Equals("True") Then
                Dim addComment As New CommentInputBox()

                If addComment.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If

                ''this will generate the new time slip entry to negate the origional entry and will get the new timeslip key
                cmd = New SqlCommand("DECLARE @TimeSlipKey as int = (SELECT isnull(MAX(TimeSlipKey) + 1, 1) FROM TimeSlipHeaderTable);" _
                                    + " INSERT INTO TimeSlipHeaderTable (TimeSlipKey, PostingDate, EmployeeID, Shift, DivisionID, Status, EmployeeName, PrintDate) SELECT @TimeSlipKey, @PostingDate, EmployeeID, Shift, DivisionID, Status, EmployeeName, @PrintDate FROM TimeSlipHeaderTable WHERE TimeSlipKey = @OrigionalKey;" _
                                    + " INSERT INTO TimeSlipLineItemTable (TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, InventoryPieces, RMID, ExtendedCost, Cost, FOXStep, DivisionID, ExtendedSteelCost, PostedSpecial, PostingReversed, ProductionNumber) SELECT @TimeSlipKey, 1, FOXNumber, MachineNumber, PartNumber, (MachineHours * -1), (SetupHours * -1), (ToolingHours * -1), (OtherHours * -1), (TotalHours * -1), (PiecesProduced * -1), (LineWeight * -1), (ScrapWeight * -1), (InventoryPieces * -1), RMID, (ExtendedCost * -1), (Cost * -1), FOXStep, DivisionID, (ExtendedSteelCost * -1), PostedSpecial, PostingReversed, ProductionNumber FROM TimeSlipLineItemTable WHERE TimeSlipKey = @OrigionalKey AND LineKey = @LineKey;" _
                                    + " SELECT @TimeSlipKey;", con)
                cmd.Parameters.Add("@OrigionalKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value
                cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value
                cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value
                cmd.Parameters.Add("@PrintDate", SqlDbType.Date).Value = Now
                ''If the the month is not the same as the posting month, this will change the date to the current date not the date of the posting
                If DateDiff(DateInterval.Month, dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value, Now) <> 0 Then
                    cmd.Parameters("@PostingDate").Value = Now
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                Dim newTimeSlipEntryKey As Integer = cmd.ExecuteScalar()

                ''handles the GL posting reversal
                cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList);" _
                                     + " SET xact_abort on;" _
                                     + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
                With cmd.Parameters
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@GLTransactionDate", SqlDbType.Date).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value
                    .Add("@GLReferenceLine", SqlDbType.Int).Value = 1
                    .Add("@GLReferenceNumber", SqlDbType.Int).Value = newTimeSlipEntryKey
                End With
                ''If the the month is not the same as the posting month, this will change the date to the current date not the date of the posting
                If DateDiff(DateInterval.Month, dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value, Now) <> 0 Then
                    cmd.Parameters("@GLTransactionDate").Value = Now
                End If
                If EmployeeCompanyCode.Equals("TST") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                End If
                ''this section gets al lthe GL entries from the specified posting and will create the reversal posting lines form them. (Would of liked to keep this at the DB level but no good way to do so since the GLTransactionKey was not auto incremental.
                Dim glCMD As New SqlCommand("SELECT GLAccountNumber, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND GLReferenceLine = @GLReferenceLine", con)
                glCMD.Parameters.Add("@GLReferenceNumber", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value
                glCMD.Parameters.Add("@GLReferenceLine", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value

                Dim addedFG As Boolean = False
                Dim glCount As Integer = 0
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = glCMD.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim accountNumber As String = reader.Item("GLAccountNumber")
                        Dim debitAmount As Double = reader.Item("GLTransactionDebitAmount")
                        Dim creditAmount As Double = reader.Item("GLTransactionCreditAmount")
                        Dim comment As String = reader.Item("GLTransactionComment")

                        If accountNumber.Equals("12100") Or accountNumber.Equals("12500") Then
                            addedFG = True
                        End If
                        If glCount = 0 Then
                            cmd.CommandText += "(@Key + " + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Time Slip Posting Reversal', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment" + glCount.ToString() + ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"
                        Else
                            cmd.CommandText += ", (@Key + " + glCount.ToString() + ", @GLAccountNumber" + glCount.ToString() + ", 'Time Slip Posting Reversal', @GLTransactionDate, @GLTransactionDebitAmount" + glCount.ToString() + ", @GLTransactionCreditAmount" + glCount.ToString() + ",  @GLTransactionComment" + glCount.ToString() + ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"
                        End If
                        cmd.Parameters.Add("@GLAccountNumber" + glCount.ToString(), SqlDbType.VarChar).Value = accountNumber
                        cmd.Parameters.Add("@GLTransactionComment" + glCount.ToString(), SqlDbType.VarChar).Value = comment + " Reversal"
                        cmd.Parameters.Add("@GLTransactionDebitAmount" + glCount.ToString(), SqlDbType.Float).Value = creditAmount
                        cmd.Parameters.Add("@GLTransactionCreditAmount" + glCount.ToString(), SqlDbType.Float).Value = debitAmount
                        glCount += 1
                    End While
                End If
                reader.Close()
                '**********************************
                'End of Ledger Entry
                '**********************************
                cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                Catch exSQL As SqlException
                    ''if primary key violation is found will try again to post
                    If exSQL.ToString.Contains("Violation of PRIMARY KEY") Then
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As SqlException
                            sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to reverse GL Entries. Line #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value.ToString(), "Timeslip #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value.ToString(), ex.ToString())
                            MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Else
                        sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to reverse GL Entries. Line #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value.ToString(), "Timeslip #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value.ToString(), exSQL.ToString())
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Catch ex As System.Exception
                    sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to reverse GL Entries. Line #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value.ToString(), "Timeslip #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value.ToString(), ex.ToString())
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
                ''if the GL entries were found to have 12100 or 12500 which are the manufactured accounts, this will reverse the inventory entries and cost tier
                If addedFG Then
                    ''reverses the inventory transaction posting
                    cmd = New SqlCommand("INSERT INTO InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount) SELECT (SELECT isnull(MAX(TransactionNumber) + 1, 1) FROM InventoryTransactionTable), @TransactionDate, TransactionType, @NewRefNumber, 1, PartNumber, PartDescription, (Quantity * -1), ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount FROM InventoryTransactionTable WHERE TransactionTypeNumber = @TransactionTypeNumber AND TransactionTypeLineNumber = @TransactionTypeLineNumber;" _
                                          + " SELECT @@ROWCOUNT;", con)
                    cmd.Parameters.Add("@TransactionTypeNumber", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value
                    cmd.Parameters.Add("@TransactionTypeLineNumber", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value
                    cmd.Parameters.Add("@NewRefNumber", SqlDbType.Int).Value = newTimeSlipEntryKey
                    cmd.Parameters.Add("@TransactionDate", SqlDbType.Date).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value
                    ''If the the month is not the same as the posting month, this will change the date to the current date not the date of the posting
                    If DateDiff(DateInterval.Month, dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value, Now) <> 0 Then
                        cmd.Parameters("@TransactionDate").Value = Now
                    End If
                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim rowsAdded As Integer = cmd.ExecuteScalar()
                    If rowsAdded = 0 Then
                        sendErrorToDataBase("ViewTimeSlipTotals - ReverseTimeSlipPosting --Error trying to reverse Inventory Transaction. Line #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value.ToString(), "Timeslip #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value.ToString(), "No rows inserted on insertion")
                    End If
                    '' reverses the cost tier
                    cmd.CommandText = "INSERT INTO InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, LowerLimit, UpperLimit, Status, TransactionNumber, ReferenceNumber, ReferenceLine) SELECT PartNumber, DivisionID, @TransactionDate, ItemCost, (-1 * CostQuantity), UpperLimit, (UpperLimit - CostQuantity), Status, (SELECT isnull(MAX(TransactionNumber) +1, 1) FROM InventoryCosting), @NewRefNumber, 1 FROM InventoryCosting WHERE ReferenceNumber = @TransactionTypeNumber AND ReferenceLine = @TransactionTypeLineNumber;" _
                    + " SELECT @@ROWCOUNT;"

                    If con.State = ConnectionState.Closed Then con.Open()
                    rowsAdded = cmd.ExecuteScalar()
                    If rowsAdded = 0 Then
                        sendErrorToDataBase("ViewTimeSlipTotals - ReverseTimeSlipPosting --Error trying to reverse Invnetory Costing. Line #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value.ToString(), "Timeslip #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value.ToString(), "No rows inserted on insertion")
                    End If
                End If
                cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET PostingReversed = 'True', PostingChanger = @PostingChanger, PostingChangedDate = @PostingChangedDate, PostingChangeComment = @PostingChangeComment WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)
                cmd.Parameters.Add("@TimeSlipKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value
                cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value
                cmd.Parameters.Add("@PostingChanger", SqlDbType.VarChar).Value = EmployeeLoginName
                cmd.Parameters.Add("@PostingChangedDate", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@PostingChangeComment", SqlDbType.VarChar).Value = addComment.txtComment.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                cmdViewByFilter_Click(sender, e)
                MessageBox.Show("Time Slip posting has been reversed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Posting was already reversed.", "Unable to reverse", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
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

    Private Sub dgvTimeSlipPostings_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvTimeSlipPostings.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right And (EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002) Then
            Dim ht As DataGridView.HitTestInfo = dgvTimeSlipPostings.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                dgvTimeSlipPostings.SelectedCells(0).Selected = False
                dgvTimeSlipPostings.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                dgvTimeSlipPostings.CurrentCell = dgvTimeSlipPostings.Rows(ht.RowIndex).Cells(ht.ColumnIndex)
                ''check to se if a posting has been reversed, if so will not enable the menu item and will disable other menu items 
                If Not IsDBNull(dgvTimeSlipPostings.Rows(ht.RowIndex).Cells("PostingReversed").Value) Then
                    If dgvTimeSlipPostings.Rows(ht.RowIndex).Cells("PostingReversed").Value.Equals("True") Then
                        For i As Integer = 0 To cmsAdminMenu.MenuItems.Count - 1
                            cmsAdminMenu.MenuItems(i).Enabled = False
                        Next
                    Else
                        cmsAdminMenu.MenuItems("ReversePosting").Enabled = True

                        If Not IsDBNull(dgvTimeSlipPostings.Rows(ht.RowIndex).Cells("PostingAddFG").Value) Then
                            If dgvTimeSlipPostings.Rows(ht.RowIndex).Cells("InventoryPieces").Value > 0 Then
                                cmsAdminMenu.MenuItems("AddToFinishedGoods").Enabled = False
                            Else
                                cmsAdminMenu.MenuItems("AddToFinishedGoods").Enabled = True
                            End If
                        Else
                            cmsAdminMenu.MenuItems("AddToFinishedGoods").Enabled = True
                        End If
                    End If
                Else
                    cmsAdminMenu.MenuItems("ReversePosting").Enabled = True

                    If Not IsDBNull(dgvTimeSlipPostings.Rows(ht.RowIndex).Cells("PostingAddFG").Value) Then
                        If dgvTimeSlipPostings.Rows(ht.RowIndex).Cells("InventoryPieces").Value > 0 Then
                            cmsAdminMenu.MenuItems("AddToFinishedGoods").Enabled = False
                        Else
                            cmsAdminMenu.MenuItems("AddToFinishedGoods").Enabled = True
                        End If
                    Else
                        cmsAdminMenu.MenuItems("AddToFinishedGoods").Enabled = True
                    End If
                End If

                cmsAdminMenu.Show(dgvTimeSlipPostings, New System.Drawing.Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub AddToFinishedGoods()
        If dgvTimeSlipPostings.CurrentCell IsNot Nothing And MessageBox.Show("Are you sure you wish to Add Finished Goods for this posting?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim addComment As New CommentInputBox()

            If addComment.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            Dim GLFirstAccount As String = ""
            Dim GLSecondAccount As String = "12800"

            Dim cmd1 As New SqlCommand("SELECT FluxLoadNumber FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd1.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd1.ExecuteReader()
            Dim FluxLoad As String = ""

            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("FluxLoadNumber")) Then
                    FluxLoad = reader.Item("FluxLoadNumber")
                End If
            End If
            reader.Close()

            If dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("DivisionID").Value.ToString().Equals("TFP") Then
                GLFirstAccount = "12500"
            Else
                GLFirstAccount = "12100"
            End If
            ''gets the Labor and machine cost per piece to make, piece weight, and steel cost per pound for the posting date.
            cmd = New SqlCommand("SELECT (SELECT FinishedWeight / 1000 FROM FOXTable WHERE FOXNumber = @FOXNumber) as PieceWeight," _
                                 + " (SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED' AND UsageDate < (SELECT isnull(MAX(PostingDate), @PostingDate) FROM TimeSlipLineItemTable" _
                                 + " LEFT OUTER JOIN TimeSlipHeaderTable ON TimeSlipHeaderTable.TimeSlipKey = TimeSlipLineItemTable.TimeSlipKey" _
                                 + " WHERE MachineNumber = (SELECT ProcessID FROM FOXSched WHERE ProcessStep = 1 AND FOXNumber = @FOXNumber))) BETWEEN LowerLimit AND UpperLimit + 1" _
                                 + " ORDER BY CostingDate DESC) as SteelCostPerPound FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND FOXStep <= @FOXStep and FOXStep > 0" _
                                 + " AND MachineNumber in (SELECT MachineID FROM (SELECT ProcessID, MachineClass FROM FoxSched inner join MachineTable on ProcessID = MachineID WHERE FOXNumber = @FOXNumber) as FOXSched left outer join MachineTable on FoxSched.MachineClass = MachineTable.MachineClass) GROUP BY FOXNumber;", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value
            cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("RMID").Value
            cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value
            cmd.Parameters.Add("@FOXStep", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXStep").Value

            Dim LaborMachineCostPer As Double = 0D
            Dim partWeight As Double = 0D
            Dim SteelCost As Double = 0D

            If con.State = ConnectionState.Closed Then con.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("pieceWeight")) Then
                    partWeight = reader.Item("pieceWeight")
                End If
                If Not IsDBNull(reader.Item("SteelCostPerPound")) Then
                    SteelCost = reader.Item("SteelCostPerPound")
                End If
            End If
            reader.Close()
            ''Gets the cost per piece
            cmd.CommandText = "SELECT SUM(CASE WHEN TotalPieces <= 0 then 0 else TotalCost / TotalPieces END) FROM (SELECT TimeSlipLineItemTable.FOXStep, CASE WHEN SUM(ExtendedCost) < 0 THEN 0 ELSE SUM(ExtendedCost) END as TotalCost, SUM(TimeSlipLineItemTable.PiecesProduced) as TotalPieces FROM TimeSlipLineItemTable INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID INNER JOIN (SELECT FOXNumber, PRocessStep, ProcessADdFG FROM FoxSched WHERE ProcessAddFG = 'ADDINVENTORY') AS FOXSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber AND LineKey < 100 AND FOXStep <> 999 AND FOXStep <= CASE WHEN (FOXSched.ProcessStep is not null) THEN FOXSched.ProcessStep ELSE 10 END GROUP BY TimeslipLineItemTable.FOXStep) as tmp"
            Dim obj As Object = cmd.ExecuteScalar()
            If obj IsNot Nothing Then
                LaborMachineCostPer = obj
            End If
            ''double check to make sure there is a steel cost
            If SteelCost = 0 Then
                cmd = New SqlCommand("IF EXISTS(SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC)" _
                                     + " SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC" _
                                     + " ELSE SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID and TransactionNumber = (SELECT TOP 1 MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID) ORDER BY TransactionNumber;", con)
                cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("RMID").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelCost = Val(cmd.ExecuteScalar())
                Catch ex As Exception
                    SteelCost = 0
                End Try
            End If
            Dim GLLinePostAmount As Double = Math.Round((LaborMachineCostPer * dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value) + (dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value * partWeight * SteelCost), 2, MidpointRounding.AwayFromZero)
            ''adds entry to costing tiers for finished goods
            If dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value <> 0 Then
                If dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value <> 0 Then
                    addToInventoryCosting(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex), Math.Round(GLLinePostAmount / dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value, 5, MidpointRounding.AwayFromZero), con)
                Else
                    addToInventoryCosting(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex), Math.Round(GLLinePostAmount / Math.Abs(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value), 5, MidpointRounding.AwayFromZero), con)
                End If
            End If
            ''adds to inventory transaction table
            addToInventoryTransaction(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex), Math.Abs(GLLinePostAmount), GLFirstAccount, con)

            ''Removes boxes from Inventory if necessary
            removeBoxes(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex), dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("DivisionID").Value, con)
            ''Remove ball inventory from Steel
            If Not String.IsNullOrEmpty(FluxLoad) And FluxLoad.Contains("ABALL") Then
                removeBalls(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex), FluxLoad, dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("DivisionID").Value, con)
            End If

            cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET ExtendedSteelCost = @ExtendedSteelCost, InventoryPieces = PiecesProduced, PostingAddFG = 'True', PostingChanger = @PostingChanger, PostingChangedDate = @PostingChangedDate, PostingChangeComment = @PostingChangeComment, AVGCostPerPiece = @AVGCostPerPiece WHERE TimeSlipKey = @TimeSlipKey and LineKey = @LineKey", con)
            cmd.Parameters.Add("@TimeslipKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value
            cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value
            cmd.Parameters.Add("@ExtendedSteelCost", SqlDbType.Float).Value = Math.Round((dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value * partWeight * SteelCost), 2, MidpointRounding.AwayFromZero)
            cmd.Parameters.Add("@PostingChanger", SqlDbType.VarChar).Value = EmployeeLoginName
            cmd.Parameters.Add("@PostingChangedDate", SqlDbType.Date).Value = Now
            cmd.Parameters.Add("@PostingChangeComment", SqlDbType.VarChar).Value = addComment.txtComment.Text
            cmd.Parameters.Add("@AVGCostPerPiece", SqlDbType.Float).Value = LaborMachineCostPer

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                sendErrorToDataBase("ViewTimeSlipTotals - AddToFinishedGoods --Error adding ExtendedSteelCost to TimeSlipLineItemTable. " + Math.Round((dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value * partWeight * SteelCost), 2, MidpointRounding.AwayFromZero).ToString(), "TimeSlip #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value + " Line #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value, ex.ToString())
            End Try

            '**********************************
            'Write to General Ledger -- ADD INVENTORY
            '**********************************
            cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList);" _
                                 + " SET xact_abort on;" _
                                 + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
            With cmd.Parameters
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                .Add("@GLTransactionDate", SqlDbType.Date).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value
                .Add("@PostingDate", SqlDbType.VarChar).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PostingDate").Value
                .Add("@EmployeeID", SqlDbType.VarChar).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("EmployeeID").Value
                .Add("@GLReferenceLine", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("LineKey").Value
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("TimeSlipKey").Value.ToString()
            End With

            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            End If
            'Write Values to General Ledger (DEBIT)
            cmd.CommandText += "(@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

            If dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value > 0 Then
                cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFirstAccount
                cmd.Parameters.Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adding Inventory for FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString()
            Else
                cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLSecondAccount
                cmd.Parameters.Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adjusting Inventory for FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString()
            End If
            With cmd.Parameters
                .Add("GLTransactionDebitAmount", SqlDbType.Float).Value = Math.Abs(GLLinePostAmount)
                .Add("@GLTransactionCreditAmount", SqlDbType.Float).Value = 0
            End With

            ''GL Credit for WIP from the inventory entry
            cmd.CommandText += ", (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment1, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

            If dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("PiecesProduced").Value > 0 Then
                cmd.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLSecondAccount
                cmd.Parameters.Add("@GLTransactionComment1", SqlDbType.VarChar).Value = "Adding Inventory for FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString()
            Else
                cmd.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLFirstAccount
                cmd.Parameters.Add("@GLTransactionComment1", SqlDbType.VarChar).Value = "Adjusting Inventory for FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString()
            End If
            With cmd.Parameters
                .Add("@GLTransactionDebitAmount1", SqlDbType.Float).Value = 0
                .Add("@GLTransactionCreditAmount1", SqlDbType.Float).Value = Math.Abs(GLLinePostAmount)
            End With

            '**********************************
            'End of Ledger Entry
            '**********************************
            cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Catch exSQL As SqlException
                ''if primary key violation is found will try again to post
                If exSQL.ToString.Contains("Violation of PRIMARY KEY") Then
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As SqlException
                        sendErrorToDataBase("ViewTimeSlipTotals - AddToFinishedGoods --Error trying to insert Add Finished Goods GL Entries into GLTransactionMasterList.", "EmployeeID #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("EmployeeID").Value.ToString(), ex.ToString())
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    sendErrorToDataBase("ViewTimeSlipTotals - AddToFinishedGoods --Error trying to insert Add Finished Goods GL Entries into GLTransactionMasterList.", "EmployeeID #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("EmployeeID").Value.ToString(), exSQL.ToString())
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As System.Exception
                sendErrorToDataBase("ViewTimeSlipTotals - AddToFinishedGoods --Error trying to insert Add Finished Goods GL Entries into GLTransactionMasterList.", "EmployeeID #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("EmployeeID").Value.ToString(), ex.ToString())
                MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            cmdViewByFilter_Click(New Object(), New System.EventArgs())
        End If

    End Sub

    Private Sub addToInventoryCosting(ByRef row As DataGridViewRow, ByVal itemCost As Double, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        Try
            If row.Cells("PiecesProduced").Value >= 0 Then
                cmd = New SqlCommand("BEGIN TRAN DECLARE @LowerLimit as int =" _
                                     + " (case when exists(SELECT TOP 1 isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID))" _
                                     + " then (SELECT TOP 1isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID))" _
                                     + " else (select 0) end) + 1;" _
                                     + " Insert Into InventoryCosting (TransactionNumber, PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, ReferenceNumber, ReferenceLine)values((SELECT isnull(MAX(TransactionNumber) + 1, 63000001) FROM InventoryCosting),@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @LowerLimit + @CostQuantity - 1, @ReferenceNumber, @ReferenceLine);" _
                                     + " commit tran;", con)
                cmd.Parameters.Add("@CostQuantity", SqlDbType.VarChar).Value = row.Cells("PiecesProduced").Value
            Else
                cmd = New SqlCommand("BEGIN TRAN DECLARE @LowerLimit as int =" _
                                     + " (case when exists(SELECT isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID))" _
                                     + " then (SELECT TOP 1 isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID))" _
                                     + " else (select 0) end);" _
                                     + " Insert Into InventoryCosting (TransactionNumber, PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, ReferenceNumber, ReferenceLine)values((SELECT isnull(MAX(TransactionNumber) + 1, 63000001) FROM InventoryCosting),@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @LowerLimit - ABS(@CostQuantity), @ReferenceNumber, @ReferenceLine);" _
                                     + " commit tran;", con)
                cmd.Parameters.Add("@CostQuantity", SqlDbType.VarChar).Value = row.Cells("PiecesProduced").Value
            End If
            'Write Values to Inventory Costing Table
            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = row.Cells("PartNumber").Value
                .Add("@CostingDate", SqlDbType.VarChar).Value = row.Cells("PostingDate").Value
                .Add("@ItemCost", SqlDbType.VarChar).Value = Math.Abs(itemCost)
                .Add("@Status", SqlDbType.VarChar).Value = "TIME SLIP"
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = row.Cells("TimeSlipKey").Value
                .Add("@ReferenceLine", SqlDbType.VarChar).Value = row.Cells("LineKey").Value
                .Add("@DivisionID", SqlDbType.VarChar).Value = row.Cells("DivisionID").Value
            End With

            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters("@DivisionID").Value = "TST"
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            sendErrorToDataBase("ViewTimeSlipTotals - addToInventoryCosting --Error trying to insert into InventoryCosting", "Part #" + row.Cells("PartNumber").Value, ex.ToString())
            MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub addToInventoryTransaction(ByRef row As DataGridViewRow, ByVal extendedCost As Double, ByVal GLAccount As String, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        ''adds the entry into the InventoryTransactionTable
        cmd = New SqlCommand("INSERT INTO InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount)" _
                             + " VALUES((SELECT isnull(MAX(TransactionNumber) + 1, 867500001) FROM InventoryTransactionTable), @TransactionDate, @Comment, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, (SELECT ShortDescription FROM ItemList WHERE ItemID = @PartNumber AND DivisionID = @DivisionID), @PiecesProduced, @ItemCost, @ExtendedCost, 0, 0, @DivisionID, @TransactionMath, @GLAccount);", con)

        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = row.Cells("PostingDate").Value
            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = row.Cells("TimeSlipKey").Value
            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = row.Cells("LineKey").Value
            .Add("@PartNumber", SqlDbType.VarChar).Value = row.Cells("PartNumber").Value
            .Add("@PiecesProduced", SqlDbType.Int).Value = row.Cells("PiecesProduced").Value
            .Add("@ExtendedCost", SqlDbType.Float).Value = extendedCost
            .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
            .Add("@DivisionID", SqlDbType.VarChar).Value = row.Cells("DivisionID").Value
        End With
        If row.Cells("PiecesProduced").Value >= 0 Then
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = "Post Production Adjustment"
            cmd.Parameters.Add("@ItemCost", SqlDbType.Float).Value = Math.Round(extendedCost / row.Cells("PiecesProduced").Value, 5, MidpointRounding.AwayFromZero)
            cmd.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
        Else
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = "Post Production Adjustment"
            cmd.Parameters.Add("@ItemCost", SqlDbType.Float).Value = Math.Round(extendedCost / Math.Abs(row.Cells("PiecesProduced").Value), 5, MidpointRounding.AwayFromZero)
            cmd.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
        End If

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters("@DivisionID").Value = "TST"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub removeBoxes(ByRef row As DataGridViewRow, ByVal division As String, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        Try
            'Write Data to Time Slip Line Database Table (Line Items)
            cmd = New SqlCommand("begin tran declare @box as varchar(50) =" _
                                 + " (CASE WHEN EXISTS(SELECT ItemID FROM BoxType WHERE BoxTypeID = (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber))" _
                                 + " THEN (SELECT ItemID FROM BoxType WHERE BoxTypeID = (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber))" _
                                 + " ELSE (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber) END)" _
                                 + ", @BoxCount as float = (SELECT TOP 1 BoxCount FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP'));" _
                                 + " if (@box is null or @BoxCount = 0) select 0 else" _
                                 + " begin Insert Into TimeSlipLineItemTable(TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, InventoryPieces, RMID, ExtendedCost, Cost, DivisionID)" _
                                 + " Values(@TimeslipKey, @LineKey, @FOXNumber, @MachineNumber, @box, 0, 0, 0, 0, 0, -1 * ceiling(@PiecesProduced / @BoxCount), 0, 0, -1 * ceiling(@PiecesProduced / @BoxCount), '', 0, 0, @DivisionID) end;" _
                                 + " commit tran;", con)

            With cmd.Parameters
                .Add("@TimeSlipKey", SqlDbType.Int).Value = Val(row.Cells("TimeSlipKey").Value)
                .Add("@LineKey", SqlDbType.Int).Value = Val(row.Cells("LineKey").Value) + 100
                .Add("@PostingDate", SqlDbType.Date).Value = row.Cells("PostingDate").Value.ToString()
                .Add("@EmployeeID", SqlDbType.VarChar).Value = row.Cells("EmployeeID").Value.ToString()
                .Add("@FOXNumber", SqlDbType.Int).Value = Val(row.Cells("FOXNumber").Value)
                .Add("@MachineNumber", SqlDbType.VarChar).Value = row.Cells("MachineNumber").Value
                .Add("@PartNumber", SqlDbType.VarChar).Value = row.Cells("PartNumber").Value
                .Add("@PiecesProduced", SqlDbType.Float).Value = row.Cells("PiecesProduced").Value
                .Add("@ProductionNumber", SqlDbType.Int).Value = row.Cells("ProductionNumber").Value
            End With
            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            sendErrorToDataBase("ViewTimeSlipTotals - removeBoxes --Error trying to insert box removal entry into TimeSlipLineItemTable", "Employee ID #" + row.Cells("EmployeeID").Value.ToString(), ex.ToString())
        End Try
    End Sub

    Private Sub removeBalls(ByRef row As DataGridViewRow, ByVal FluxLoad As String, ByVal division As String, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        Try
            'Write Data to Time Slip Line Database Table (Line Items)
            cmd = New SqlCommand("begin tran declare @SteelCost as float = isnull((SELECT SteelCostPerPound FROM SteelCostingTable WHERE TransactionNumber = (SELECT TOP 1 isnull(MAX(TransactionNumber), 0) FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT case when SUM(UsageWeight) = 0 or SUM(UsageWeight) is null then 1 else SUM(UsageWeight) end FROM SteelUsageTable WHERE RMID = @RMID) BETWEEN LowerLimit and UpperLimit)),0);", con)
            ''this is the entry into the steelTransactionTable
            cmd.CommandText += " INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, SteelTransactionDate, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType) VALUES ((SELECT isnull(MAX(TransactionNumber) + 1,8800001) FROM SteelTransactionTable), @DivisionID, @PostingDate, (SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID), (SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID), @PiecesProduced, @SteelCost, ROUND(@PiecesProduced * @SteelCost,2), @TimeSlipKey, 1, @RMID, 'SUBTRACT', 'TIMESLIP POSTING');"
            ''this is hte entry into the SteelUsageTable
            cmd.CommandText += " INSERT INTO SteelUsageTable (SteelUsageKey, UsageDate, ReferenceNumber, UsageWeight, RMID, DivisionID, Status, PrintDate) VALUES ((SELECT isnull(MAX(SteelUsageKey) + 1, 2200001) FROM SteelUsageTable), @PostingDate, @TimeSlipKey, @PiecesProduced, @RMID, @DivisionID, 'POSTED', @PostingDate); COMMIT TRAN;"
            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = FluxLoad
                .Add("@TimeSlipKey", SqlDbType.Int).Value = row.Cells("TimeSlipKey").Value
                .Add("@PostingDate", SqlDbType.Date).Value = row.Cells("PostingDate").Value.ToString()
                .Add("@EmployeeID", SqlDbType.VarChar).Value = row.Cells("EmployeeID").Value.ToString()
                .Add("@PiecesProduced", SqlDbType.Float).Value = row.Cells("PiecesProduced").Value
            End With
            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            sendErrorToDataBase("ViewTimeSlipTotals - removeBoxes --Error trying to insert BALL REMOVAL entry into TimeSlipLineItemTable. FOX " + row.Cells("FOXNumber").Value.ToString(), "Employee ID #" + row.Cells("EmployeeID").Value.ToString(), ex.ToString())
        End Try
    End Sub

    Private Sub dgvTimeSlipPostings_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTimeSlipPostings.Sorted
        ColorRows()
    End Sub

    Private Sub ColorRows()
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            For i As Integer = 0 To dgvTimeSlipPostings.Rows.Count - 1
                If dgvTimeSlipPostings.Rows(i).Cells("PostingAddFG").Value.Equals("True") Then
                    dgvTimeSlipPostings.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                End If
                If dgvTimeSlipPostings.Rows(i).Cells("PostingReversed").Value.Equals("True") Then
                    dgvTimeSlipPostings.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
                End If
            Next
        End If
    End Sub

    Private Sub dgvTimeSlipPostings_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTimeSlipPostings.CellValueChanged
        If isLoaded Then
            If EmployeeSecurityCode <= 1002 And (dgvTimeSlipPostings.Columns(e.ColumnIndex).DataPropertyName.Equals("ProductionNumber") Or dgvTimeSlipPostings.Columns(e.ColumnIndex).DataPropertyName.Equals("PostingChangeComment")) Then
                cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET " + dgvTimeSlipPostings.Columns(e.ColumnIndex).DataPropertyName + " = @Value WHERE TimeSlipLineItemTable.TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)
                cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = dgvTimeSlipPostings.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                cmd.Parameters.Add("@TimeSlipKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(e.RowIndex).Cells("TimeSlipKey").Value
                cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipPostings.Rows(e.RowIndex).Cells("LineKey").Value

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

        End If
    End Sub

    Private Sub cboSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
        If cboSteelSize.Text.Length = 0 Then
            If e.KeyChar = "."c Then
                cboSteelSize.Text = "0."
                e.KeyChar = Nothing
                cboSteelSize.SelectionStart = cboSteelSize.Text.Length
                cboSteelSize.SelectionLength = 0
            End If
        ElseIf cboSteelSize.SelectionLength = cboSteelSize.Text.Length Then
            If e.KeyChar = "."c Then
                cboSteelSize.Text = "0."
                e.KeyChar = Nothing
                cboSteelSize.SelectionStart = cboSteelSize.Text.Length
                cboSteelSize.SelectionLength = 0
            End If
        ElseIf e.KeyChar.Equals("."c) And cboSteelSize.Text.Contains(".") Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub ManualWIPFlush()
        If dgvTimeSlipPostings.CurrentCell IsNot Nothing Then
            If MessageBox.Show("Are you sure you wish to manually flush FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString() + " on the production #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("ProductionNumber").Value.ToString(), "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Dim prodComp As New ProductionCompletion(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("ProductionNumber").Value, dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value, True, True)

                While prodComp.IsRunning
                    System.Threading.Thread.Sleep(500)
                End While
                MessageBox.Show("WIP has been flushed for the FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString + " on Production #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("ProductionNumber").Value.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub FYWIPFlush()
        If dgvTimeSlipPostings.CurrentCell IsNot Nothing Then
            If MessageBox.Show("Are you sure you wish to manually flush FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString() + " on the production #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("ProductionNumber").Value.ToString(), "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Dim prodComp As New ProductionCompletion(dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("ProductionNumber").Value, dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value, True, True, True)

                While prodComp.IsRunning
                    System.Threading.Thread.Sleep(500)
                End While
                MessageBox.Show("WIP has been flushed for the FOX #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("FOXNumber").Value.ToString + " on Production #" + dgvTimeSlipPostings.Rows(dgvTimeSlipPostings.CurrentCell.RowIndex).Cells("ProductionNumber").Value.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ExportTotalMaterialConsumedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportTotalMaterialConsumedToolStripMenuItem.Click
        If canExport() Then
            Dim oExcel As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet

            oExcel = CreateObject("Excel.Application")

            Dim RowIndex As Integer = 1
            If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Total Material Consumed Report.xls") Then
                ''attempts to open the excel document that exists
                Try
                    oBook = oExcel.Workbooks.Open(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Total Material Consumed Report.xls")
                Catch ex As Exception
                    MessageBox.Show("There was a problem opening the Total Material Consumed Report Excel document.", "Unable to open report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    sendErrorToDataBase("ViewTimeslipTotals - ExportTotalMaterialConsutmedToolStripMenuItem --Error trying to open the file", "Total Material Consumed", ex.ToString())
                    oExcel.Quit()
                    releaseObject(oExcel)
                    Exit Sub
                End Try
                ''attempts to get access to the spreadsheet that will be used for the data
                Try
                    oSheet = oBook.Worksheets("Total Material Consumed")
                Catch ex As Exception
                    MessageBox.Show("There was a problem reading Excel sheet in the document.", "Unable to open report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    sendErrorToDataBase("ViewTimeslipTotals - ExportTotalMaterialConsutmedToolStripMenuItem --Error trying to access the spreadsheet", "Total Material Consumed", ex.ToString())
                    oBook.Close(False, Type.Missing, Type.Missing)
                    releaseObject(oBook)
                    oExcel.Quit()
                    releaseObject(oExcel)
                    Exit Sub
                End Try
                ''gets the currently used row count and adds 1 to it.
                RowIndex = oSheet.UsedRange.Rows.Count + 1
            Else

                ''sets the default column information.
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)
                oSheet.Name = "Total Material Consumed"

                oSheet.Cells(1, 1) = "Beginning Date"
                oSheet.Cells(1, 2) = "Ending Date"
                oSheet.Cells(1, 3) = "Total Material Consumed"
                RowIndex += 1
            End If
            ''attempts to add the data to the excel object
            Try
                oSheet.Cells(RowIndex, 1) = dtpBeginDate.Value.ToShortDateString()
                oSheet.Cells(RowIndex, 2) = dtpEndDate.Value.ToShortDateString()
                oSheet.Cells(RowIndex, 3) = lblTotalWeight.Text
                oSheet.Columns.AutoFit()
            Catch ex As Exception
                MessageBox.Show("Unable to add data to the spreadsheet.", "Unable to add data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sendErrorToDataBase("ViewTimeslipTotals - ExportTotalMaterialConsutmedToolStripMenuItem --Error trying to add the data to the spreadsheet", "Total Material Consumed", ex.ToString())
                releaseObject(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                releaseObject(oBook)
                oExcel.Quit()
                releaseObject(oExcel)
                Exit Sub
            End Try
            'Dim chartObjs As Excel.ChartObjects = oChartSheet.ChartObjects

            'If chartObjs.Count > 0 Then

            'Else
            '    Dim xlChart = DirectCast(oBook.Charts.Add(After:=oSheet), Excel.Chart)

            '    Dim cellRange As Excel.Range = DirectCast(oSheet.Cells(2, 3), Excel.Range)
            '    xlChart.ChartWizard(Source:=cellRange.CurrentRegion, Gallery:=Excel.Constants.xl3DBar, PlotBy:=Excel.XlRowCol.xlColumns, CategoryLabels:=1, SeriesLabels:=1, HasLegend:=False, Title:="Total Material Consumed Chart")
            '    ''xlChart.ChartTitle = "Total Material Consumed Chart"
            '    xlChart.Name = "Charts"

            '    With DirectCast(xlChart.ChartGroups(1),  _
            '            Excel.ChartGroup)
            '        .GapWidth = 20
            '        .VaryByCategories = True
            '    End With
            '    With xlChart.ChartTitle
            '        .Font.Size = 16
            '        .Shadow = True
            '        .Border.LineStyle = Excel.Constants.xlSolid
            '    End With
            'End If

            ''attempts to either save a new file or update an existing file.
            If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Total Material Consumed Report.xls") Then
                Dim fi As New System.IO.FileInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Total Material Consumed Report.xls")
                If Not fi.IsReadOnly Then
                    oBook.Save()
                Else
                    MessageBox.Show("File is currently open, unable to save.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    releaseObject(oSheet)
                    oBook.Close(False, Type.Missing, Type.Missing)
                    releaseObject(oBook)
                    oExcel.Quit()
                    releaseObject(oExcel)
                    Exit Sub
                End If
            Else
                oBook.SaveAs(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Total Material Consumed Report.xls", XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
            End If

            'Release the objects
            releaseObject(oSheet)
            oBook.Close(False, Type.Missing, Type.Missing)
            releaseObject(oBook)
            oExcel.Quit()
            releaseObject(oExcel)
            'Some time Office application does not quit after automation: 
            'so i am calling GC.Collect method.
            GC.Collect()
            MessageBox.Show("Data has been exported successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canExport() As Boolean
        If String.IsNullOrEmpty(lblTotalWeight.Text) Then
            MessageBox.Show("There is no total material consumed.", "Unable to export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not chkDateRange.Checked Then
            MessageBox.Show("You can only export total material consumed if you used a date range", "Use a date range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub cboFOXNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFOXNumber.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Return) AndAlso e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isLoaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                Dim tmp As String = cboCarbon.Text
                isLoaded = False
                If cboSteelSize.Text.Contains("/") Then
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                Else
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                End If
                cboCarbon.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboCarbon.Text
                isLoaded = False
                cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
                cboCarbon.Text = tmp
                isLoaded = True
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

    Private Sub chkAllTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTypes.CheckedChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If

                cboSteelSize.Text = tmp
                isLoaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isLoaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isLoaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If cboSteelSize.Text.StartsWith(".") Then
            cboSteelSize.Text = "0."
            cboSteelSize.Select(cboSteelSize.Text.Length, 0)
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub ViewTimeSlipTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class