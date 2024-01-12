Imports System.Data.SqlClient

Public Class ViewActivityLog
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim DivisionID As String = ""
    Dim LogType As String = ""

    Public Sub New()
        InitializeComponent()
        usefulFunctions.LoadSecurity(Me)
    End Sub
    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()
        dgvActivity.DataSource = dt
        Dim totalWidth As Integer = 0
        For i As Integer = 0 To dgvActivity.Columns.Count - 1
            totalWidth += dgvActivity.Columns(i).Width
            If dgvActivity.Columns(i).HeaderText.Contains("Time") Then
                dgvActivity.Columns(i).DefaultCellStyle.Format = "hh:mm:ss tt"
            ElseIf dgvActivity.Columns(i).HeaderText.Contains("Date") Then
                dgvActivity.Columns(i).DefaultCellStyle.Format = "MM/dd/yyyy"
            End If
        Next
        Me.Width = totalWidth
    End Sub
    Public Sub New(ByVal tpe As String, ByVal division As String)
        InitializeComponent()
        LogType = tpe
        Select Case LogType
            Case "ItemList"
                dgvActivity.Size = New System.Drawing.Size(768, 641)
                dgvActivity.Location = New System.Drawing.Point(254, 12)
                DivisionID = division
                LoadDivisions()
                gpxItemListFilters.Show()
                Me.AcceptButton = cmdView
            Case "LotNumber"
                dgvActivity.Size = New System.Drawing.Size(768, 641)
                dgvActivity.Location = New System.Drawing.Point(254, 12)
                LoadLotNumbers()
                LoadFOXNumbers()
                LoadLotPartNumbers()
                gpxLotFilters.Show()
                Me.AcceptButton = cmdLotView
        End Select

    End Sub
    Private Sub LoadDivisions()
        Dim cmd As New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
        Dim dt As New Data.DataTable("Divisions")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        adap.Dispose()
        cmd.Dispose()
        con.Close()

        cboDivisionID.DisplayMember = "DivisionKey"
        cboDivisionID.DataSource = dt
        cboDivisionID.Text = DivisionID
        LoadPartNumbers()
    End Sub

    Private Sub LoadPartNumbers()
        Dim cmd As New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID UNION SELECT ItemID FROM TFPItemListActivityLog WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim dt As New Data.DataTable("ItemList")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        adap.Dispose()
        cmd.Dispose()
        con.Close()

        If Not cboPartNumber.DisplayMember.Equals("ItemID") Then cboPartNumber.DisplayMember = "ItemID"
        cboPartNumber.DataSource = dt
        cboPartNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadLotPartNumbers()
        Dim cmd As New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP' UNION SELECT PartNumber FROM LotNumber", con)

        Dim dt As New Data.DataTable("ItemList")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        adap.Dispose()
        cmd.Dispose()
        con.Close()

        If Not cboLotPartNumber.DisplayMember.Equals("ItemID") Then cboLotPartNumber.DisplayMember = "ItemID"
        cboLotPartNumber.DataSource = dt
        cboLotPartNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadFOXNumbers()
        Dim cmd As New SqlCommand("SELECT FOXNumber FROM FOXTable ORDER BY FOXNumber", con)
        Dim dt As New Data.DataTable("FOXTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        adap.Dispose()
        cmd.Dispose()
        con.Close()

        If Not cboFOXNumber.DisplayMember.Equals("FOXNumber") Then cboFOXNumber.DisplayMember = "FOXNumber"
        cboFOXNumber.DataSource = dt
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadLotNumbers()
        Dim cmd As New SqlCommand("SELECT LotNumber FROM LotNumber UNION SELECT LotNumber FROM TFPLotActivityLog", con)
        Dim dt As New Data.DataTable("LotNumber")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        adap.Dispose()
        cmd.Dispose()
        con.Close()

        If Not cboLotNumber.DisplayMember.Equals("LotNumber") Then cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = dt
        cboLotNumber.SelectedIndex = -1
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cboDivisionID_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectionChangeCommitted
        If Not String.IsNullOrEmpty(cboDivisionID.Text) Then
            LoadPartNumbers()
        Else
            cboPartNumber.DataSource = Nothing
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim cmd As New SqlCommand("SELECT TFPItemListActivityLog.ActivityDateTime as [Activity Date], TFPItemListActivityLog.ActivityDateTime as [Activity Time], TFPItemListActivityLog.UserID as [User], TFPItemListActivityLog.ItemID as [Part Number], TFPItemListActivityLog.ChangedField as [Changed Field], TFPItemListActivityLog.OriginalValue as [Original Value], TFPItemListActivityLog.NewValue as [New Value]  FROM TFPItemListActivityLog INNER JOIN ItemList ON TFPItemListActivityLog.ItemID = ItemList.ItemID AND TFPItemListActivityLog.DivisionID = ItemList.DivisionID WHERE TFPItemListActivityLog.DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cmd.CommandText += " AND TFPItemListActivityLog.ItemID = @ItemID"
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If

        If chkUseDateRange.Checked Then
            cmd.CommandText += " AND ActivityDateTime BETWEEN @StartTime AND @EndTime"
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime2).Value = New DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, 0, 0, 0)
            cmd.Parameters.Add("@EndTime", SqlDbType.DateTime2).Value = New DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day, 23, 59, 59)
        End If

        If Not String.IsNullOrEmpty(txtTextFilter.Text) Then
            cmd.CommandText += " AND (TFPItemListActivityLog.ItemID like @TextFilter OR ItemList.ShortDescription like @TextFilter OR ChangedField like @TextFilter OR OriginalValue like @TextFilter OR NewValue like @TextFilter)"
            cmd.Parameters.Add("@TextFilter", SqlDbType.VarChar).Value = "%" + txtTextFilter.Text + "%"
        End If
        cmd.CommandText += " ORDER BY [Activity Date] DESC, [Activity Time] DESC"

        Dim dt As New Data.DataTable("ItemList")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        adap.Dispose()
        cmd.Dispose()
        con.Close()

        dgvActivity.DataSource = dt
        dgvActivity.Columns("Activity Date").DefaultCellStyle.Format = "MM/dd/yyyy"
        dgvActivity.Columns("Activity Time").DefaultCellStyle.Format = "hh:mm:ss tt"
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        chkUseDateRange.Checked = False
        dtpStartDate.Value = Now
        dtpEndDate.Value = Now
        txtTextFilter.Clear()
        dgvActivity.DataSource = Nothing
        cboPartNumber.Focus()
    End Sub

    Private Sub cmdLotView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLotView.Click
        Dim cmd As New SqlCommand("SELECT TFPLotActivityLog.ActivityDateTime as [Activity Date], TFPLotActivityLog.ActivityDateTime as [Activity Time], TFPLotActivityLog.LoginName as [User], TFPLotActivityLog.LotNumber as [Lot Number], TFPLotActivityLog.ChangedField as [Changed Field], TFPLotActivityLog.OriginalValue as [Original Value], TFPLotActivityLog.NewValue as [New Value]  FROM TFPLotActivityLog LEFT OUTER JOIN LotNumber ON TFPLotActivityLog.LotNumber = LotNumber.LotNumber  LEFT OUTER JOIN FOXTable ON CAST( CASE WHEN LEN(TFPLotActivityLog.LotNumber) = 10 THEN LEFT(TFPLotActivityLog.LotNumber,5) ELSE LEFT(TFPLotActivityLog.LotNumber,4) END as int) = FOXTable.FOXNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim isFirst As Boolean = True

        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE TFPLotActivityLog.LotNumber = @LotNumber"
            Else
                cmd.CommandText += " AND TFPLotActivityLog.LotNumber = @LotNumber"
            End If

            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE (FOXTable.FOXNumber = @FOXNumber OR LotNumber.FOXNumber = @FOXNumber)"
            Else
                cmd.CommandText += " AND (FOXTable.FOXNumber = @FOXNumber OR LotNumber.FOXNumber = @FOXNumber)"
            End If

            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboLotPartNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE (LotNumber.PartNumber = @PartNumber OR FOXTable.PartNumber = @PartNumber)"
            Else
                cmd.CommandText += " AND (LotNumber.PartNumber = @PartNumber OR FOXTable.PartNumber = @PartNumber)"
            End If

            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboLotPartNumber.Text
        End If
        If chkLotUseDateRange.Checked Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE ActivityDateTime BETWEEN @StartTime AND @EndTime"
            Else
                cmd.CommandText += " AND ActivityDateTime BETWEEN @StartTime AND @EndTime"
            End If

            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime2).Value = New DateTime(dtpLotStartDate.Value.Year, dtpLotStartDate.Value.Month, dtpLotStartDate.Value.Day, 0, 0, 0)
            cmd.Parameters.Add("@EndTime", SqlDbType.DateTime2).Value = New DateTime(dtpLotEndDate.Value.Year, dtpLotEndDate.Value.Month, dtpLotEndDate.Value.Day, 23, 59, 59)
        End If

        If Not String.IsNullOrEmpty(txtTextFilter.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE (LotNumber.PartNumber like @TextFilter OR LotNumber.ShortDescription like @TextFilter OR ChangedField like @TextFilter OR OriginalValue like @TextFilter OR NewValue like @TextFilter)"
            Else
                cmd.CommandText += " AND (LotNumber.PartNumber like @TextFilter OR LotNumber.ShortDescription like @TextFilter OR ChangedField like @TextFilter OR OriginalValue like @TextFilter OR NewValue like @TextFilter)"
            End If

            cmd.Parameters.Add("@TextFilter", SqlDbType.VarChar).Value = "%" + txtTextFilter.Text + "%"
        End If
        cmd.CommandText += " ORDER BY [Activity Date] DESC, [Activity Time] DESC"

        Dim dt As New Data.DataTable("LotNumber")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        adap.Dispose()
        cmd.Dispose()
        con.Close()

        dgvActivity.DataSource = dt
        dgvActivity.Columns("Activity Date").DefaultCellStyle.Format = "MM/dd/yyyy"
        dgvActivity.Columns("Activity Time").DefaultCellStyle.Format = "hh:mm:ss tt"
    End Sub

    Private Sub cmdlotClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlotClear.Click
        cboLotNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cboLotNumber.Text = ""
        End If
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        cboLotPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboLotPartNumber.Text) Then
            cboLotPartNumber.Text = ""
        End If
        chkLotUseDateRange.Checked = False
        dtpLotStartDate.Value = Now
        dtpLotEndDate.Value = Now
        txtLotTextFilter.Clear()
        dgvActivity.DataSource = Nothing
    End Sub

    Private Sub ViewActivityLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class