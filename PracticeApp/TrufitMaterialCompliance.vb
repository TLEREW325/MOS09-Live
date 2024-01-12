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
Imports System.ComponentModel
Imports System.Drawing.Printing
Public Class TrufitMaterialCompliance
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Dim checkedItemsNames As New System.Collections.Specialized.StringCollection
    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False
    Dim CanCheckPickTicket As Boolean = False
    Dim LoadingScreen As New Loading()

    Public Sub New()
        InitializeComponent()
        usefulFunctions.LoadSecurity(Me)
        LoadFOXNumber()
        LoadTrufitCertNumber()
        isLoaded = True
    End Sub

    Public Sub LoadTrufitCertNumber()
        cmd = New SqlCommand("SELECT TrufitCertNumber FROM TrufitCertificationTable where DivisionID = 'TFP' ORDER BY TrufitCertNumber DESC;", con)
        Dim dt = New Data.DataTable("TrufitCertificationTable")
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        con.Close()

        cboTrufitCertNumber.DisplayMember = "TrufitCertNumber"
        cboTrufitCertNumber.DataSource = dt
        cboTrufitCertNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable where DivisionID = 'TFP';", con)
        Dim dt As New Data.DataTable("FOXTable")
        Dim myAdapter2 As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(dt)
        con.Close()

        cboFOXNumber.DisplayMember = "FOXNumber"
        cboFOXNumber.DataSource = dt
        cboFOXNumber.SelectedIndex = -1
        cboReferenceFOXNumber.DisplayMember = "FOXNumber"
        cboReferenceFOXNumber.DataSource = dt.Copy()
        cboReferenceFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadLotData()
        cmd = New SqlCommand("SELECT HeatNumber, SteelType, SteelSize, PartNumber, ShortDescription, LongDescription FROM LotNumber WHERE LotNumber = @LotNumber;", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        Dim dt As New Data.DataTable("LotNumber")
        Dim myAdapter3 As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("HeatNumber")) Then
                lblHeatNumber.Text = ""
            Else
                lblHeatNumber.Text = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("SteelType")) Then
                lblLotCarbon.Text = ""
            Else
                lblLotCarbon.Text = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                lblLotSteelSize.Text = ""
            Else
                lblLotSteelSize.Text = reader.Item("SteelSize")
            End If

            If IsDBNull(reader.Item("PartNumber")) Then
                lblLotPartNumber.Text = ""
            Else
                lblLotPartNumber.Text = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                lblLotShortDescription.Text = ""
            Else
                lblLotShortDescription.Text = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("LongDescription")) Then
                lblLotSteelSize.Text = ""
            Else
                lblLotLongDescription.Text = reader.Item("LongDescription")
            End If
        Else
            lblHeatNumber.Text = ""
            lblLotCarbon.Text = ""
            lblLotSteelSize.Text = ""
            lblLotPartNumber.Text = ""
            lblLotShortDescription.Text = ""
            lblLotLongDescription.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub LoadFOXData()
        Dim CustomerID, Carbon, SteelSize, RMID, PartNumber, ShortDescription, LongDescription As String
        Dim OrderReferenceNumber As Integer

        Dim RMIDStatement As String = "SELECT PartNumber, OrderReferenceNumber, CustomerID, Carbon, SteelSize, ItemList.ShortDescription, ItemList.LongDescription FROM FOXTable LEFT OUTER JOIN RawMaterialsTable ON FOXTable.ScheduledRMID = RawMaterialsTable.RMID LEFT OUTER JOIN ItemList ON FOXTable.PartNumber = ItemList.ItemID AND FOXTable.DivisionID = ItemList.DivisionID WHERE FOXTable.FOXNumber = @FOXNumber AND FOXTable.DivisionID = 'TFP';"
        Dim RMIDCommand As New SqlCommand(RMIDStatement, con)
        RMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = RMIDCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("OrderReferenceNumber")) Then
                OrderReferenceNumber = ""
            Else
                OrderReferenceNumber = reader.Item("OrderReferenceNumber")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("Carbon")) Then
                Carbon = ""
            Else
                Carbon = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                ShortDescription = ""
            Else
                ShortDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("LongDescription")) Then
                LongDescription = ""
            Else
                LongDescription = reader.Item("LongDescription")
            End If
        Else
            RMID = ""
            PartNumber = ""
            OrderReferenceNumber = 0
            CustomerID = ""
            Carbon = ""
            SteelSize = ""
            ShortDescription = ""
            LongDescription = ""
        End If
        reader.Close()
        con.Close()

        lblPartNumber.Text = PartNumber
        lblOrderNumber.Text = OrderReferenceNumber
        If CustomerID = "" Then

        Else
            lblCustomerID.Text = CustomerID
            LoadSaltSprayInspections()
        End If

        lblFOXCarbon.Text = Carbon
        lblFOXSteelSize.Text = SteelSize
        lblShortDescription.Text = ShortDescription
        lblLongDescription.Text = LongDescription
    End Sub

    Public Sub LoadTrufitCertData()
        Dim CertDate, ShipDate, LotNumber, Comment1, Comment2, Comment3 As String
        Dim SalesOrderNumber, Quantity, FOXNumber As Integer

        Dim CertDateStatement As String = "SELECT CertDate, ShipDate, FOXNumber, Quantity, SalesOrderNumber, Comment1, Comment2, Comment3 FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber AND DivisionID = 'TFP';"
        Dim CertDateCommand As New SqlCommand(CertDateStatement, con)
        CertDateCommand.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(cboTrufitCertNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CertDateCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CertDate")) Then
                CertDate = ""
            Else
                CertDate = reader.Item("CertDate")
            End If
            If IsDBNull(reader.Item("ShipDate")) Then
                ShipDate = ""
            Else
                ShipDate = reader.Item("ShipDate")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = ""
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("Quantity")) Then
                Quantity = ""
            Else
                Quantity = reader.Item("Quantity")
            End If
            If IsDBNull(reader.Item("SalesOrderNumber")) Then
                SalesOrderNumber = ""
            Else
                SalesOrderNumber = reader.Item("SalesOrderNumber")
            End If
            If IsDBNull(reader.Item("Comment1")) Then
                Comment1 = ""
            Else
                Comment1 = reader.Item("Comment1")
            End If
            If IsDBNull(reader.Item("Comment2")) Then
                Comment2 = ""
            Else
                Comment2 = reader.Item("Comment2")
            End If
            If IsDBNull(reader.Item("Comment3")) Then
                Comment3 = ""
            Else
                Comment3 = reader.Item("Comment3")
            End If
        Else
            CertDate = ""
            ShipDate = ""
            FOXNumber = 0
            LotNumber = ""
            Quantity = 0
            SalesOrderNumber = 0
            Comment1 = ""
            Comment2 = ""
            Comment3 = ""
        End If
        reader.Close()
        con.Close()

        cboFOXNumber.Text = FOXNumber
        dtpDate.Text = CertDate
        dtpShipDate.Text = ShipDate
        txtComment1.Text = Comment1
        txtComment2.Text = Comment2
        txtComment3.Text = Comment3
        txtQuantity.Text = Quantity
    End Sub

    Public Sub ClearData()
        cboFOXNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboTrufitCertNumber.SelectedIndex = -1

        txtTorqueRequirement.Clear()
        txtComment1.Clear()
        txtComment2.Clear()
        txtComment3.Clear()
        txtQuantity.Clear()

        lblOrderNumber.Text = ""
        lblPartNumber.Text = ""
        lblShortDescription.Text = ""
        lblLongDescription.Text = ""
        lblState.Text = ""
        lblZipCode.Text = ""
        lblAddress1.Text = ""
        lblAddress2.Text = ""
        lblCity.Text = ""
        lblCountry.Text = ""
        lblCustomerName.Text = ""
        dtpDate.Text = ""
        dtpShipDate.Text = ""
        lblFOXCarbon.Text = ""
        lblFOXSteelSize.Text = ""
        lblLotCarbon.Text = ""
        lblLotSteelSize.Text = ""
        lblLotPartNumber.Text = ""
        lblLotShortDescription.Text = ""
        lblLotLongDescription.Text = ""
        lblCustomerID.Text = ""
        lblCustomerName.Text = ""

        cboTrufitCertNumber.Focus()
        dgvHeatNumbers.DataSource = Nothing
        lblFPIForLot.Hide()
        lblFPI.Hide()
        dgvHeatRecords.DataSource = Nothing
        chlSaltSpray.Items.Clear()
        chklstPickTickets.Items.Clear()
    End Sub

    Public Sub LoadCustomerData()
        Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry As String
        Dim BillToAddress1Statement As String = "SELECT BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = 'TFP';"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = BillToAddress1Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("BillToAddress1")) Then
                BillToAddress1 = ""
            Else
                BillToAddress1 = reader.Item("BillToAddress1")
            End If
            If IsDBNull(reader.Item("BillToAddress2")) Then
                BillToAddress2 = ""
            Else
                BillToAddress2 = reader.Item("BillToAddress2")
            End If
            If IsDBNull(reader.Item("BillToCity")) Then
                BillToCity = ""
            Else
                BillToCity = reader.Item("BillToCity")
            End If
            If IsDBNull(reader.Item("BillToState")) Then
                BillToState = ""
            Else
                BillToState = reader.Item("BillToState")
            End If
            If IsDBNull(reader.Item("BillToZip")) Then
                BillToZip = ""
            Else
                BillToZip = reader.Item("BillToZip")
            End If
            If IsDBNull(reader.Item("BillToCountry")) Then
                BillToCountry = ""
            Else
                BillToCountry = reader.Item("BillToCountry")
            End If
            If IsDBNull(reader.Item("CustomerName")) Then
                lblCustomerName.Text = ""
            Else
                lblCustomerName.Text = reader.Item("CustomerName")
            End If
        Else
            BillToAddress1 = ""
            BillToAddress2 = ""
            BillToCity = ""
            BillToState = ""
            BillToZip = ""
            BillToCountry = ""
            lblCustomerName.Text = ""
        End If
        reader.Close()
        con.Close()

        lblAddress1.Text = BillToAddress1
        lblAddress2.Text = BillToAddress2
        lblCity.Text = BillToCity
        lblState.Text = BillToState
        lblCountry.Text = BillToCountry
        lblZipCode.Text = BillToZip
    End Sub

    Private Sub LoadLotNumbers()
        cmd = New SqlCommand("SELECT LotNumber, QCInspected FROM LotNumber WHERE PartNumber like (SELECT '%'+ PartNumber + '%' FROM FOXTable WHERE FOXNumber = @FOXNumber) UNION SELECT LotNumber, QCInspected FROM LotNumber  WHERE  (SELECT PartNumber + '%' FROM FOXTable WHERE FOXNumber = @FOXNumber)like '%' + PartNumber + '%' ORDER BY LotNumber ASC;", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboReferenceFOXNumber.Text
        ''will make it so that lots that were created in the wang still will show for the given FOX

        Dim dt As New Data.DataTable("LotNumber")
        Dim myAdapter6 As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(dt)
        con.Close()

        isLoaded = False
        cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = dt
        cboLotNumber.SelectedIndex = -1
        lblHeatNumber.Text = ""
        lblLotCarbon.Text = ""
        lblLotSteelSize.Text = ""
        isLoaded = True
    End Sub

    Private Sub LoadHeatRecordNumbers()
        cmd = New SqlCommand("SELECT DISTINCT(HeatTreatRecordNumber), HeatTreatInspectionLog.LotNumber FROM HeatTreatInspectionLog INNER JOIN TrufitCertificationHeatLines ON HeatTreatInspectionLog.LotNumber LIKE TrufitCertificationHeatLines.LotNumber + '%' WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber;", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = cboTrufitCertNumber.Text
        ''will make it so that lots that were created in the wang still will show for the given FOX

        Dim dt As New Data.DataTable("HeatTreatInspectionLog")
        Dim myAdapter7 As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter7.Fill(dt)
        con.Close()

        cboHeatTreatLotNumber.DisplayMember = "LotNumber"
        cboHeatTreatLotNumber.DataSource = dt
        cboHeatTreatLotNumber.SelectedIndex = -1
        txtHeatTreatRecordNumber.Text = ""
    End Sub

    Private Sub ShowHeats()
        cmd = New SqlCommand("SELECT TrufitCertificationHeatLines.LotNumber, TrufitCertificationHeatLines.HeatNumber, LotQuantity, LotNumber.ShortDescription FROM TrufitCertificationHeatLines LEFT OUTER JOIN LotNumber ON TrufitCertificationHeatLines.LotNumber = LotNumber.LotNumber WHERE TrufitCertNumber = @TrufitCertNumber;", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text
        Dim dsTemp As New DataSet()
        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(dsTemp, "TrufitCertificationHeatLines")
        con.Close()

        dgvHeatNumbers.DataSource = dsTemp.Tables("TrufitCertificationHeatLines")
        dgvHeatNumbers.Columns("LotNumber").HeaderText = "Lot Number"
        dgvHeatNumbers.Columns("LotNumber").ReadOnly = True
        dgvHeatNumbers.Columns("LotNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvHeatNumbers.Columns("HeatNumber").HeaderText = "Heat Number"
        dgvHeatNumbers.Columns("HeatNumber").ReadOnly = True
        dgvHeatNumbers.Columns("HeatNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvHeatNumbers.Columns("LotQuantity").HeaderText = "Lot Qty"
        dgvHeatNumbers.Columns("LotQuantity").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvHeatNumbers.Columns("ShortDescription").HeaderText = "Short Description"
        dgvHeatNumbers.Columns("ShortDescription").ReadOnly = True
        dgvHeatNumbers.Columns("ShortDescription").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If dgvHeatNumbers.Rows.Count > 0 Then
            dgvHeatNumbers.CurrentCell = dgvHeatNumbers.Rows(0).Cells("HeatNumber")
            cmdDeleteSelectedHeat.Enabled = True
        Else
            cmdDeleteSelectedHeat.Enabled = False
        End If

        CheckCertFPI()
        LoadSaltSprayInspections()
    End Sub

    Private Sub ShowHeatTreatRecords()
        cmd = New SqlCommand("SELECT LotNumber, HeatRecordNumber, EntryNumber FROM TrufitCertificationHeatTreatLines WHERE TrufitCertNumber = @TrufitCertNumber;", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text
        Dim dsTemp As New DataSet()
        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(dsTemp, "TrufitCertificationHeatTreatLines")
        con.Close()

        dgvHeatRecords.DataSource = dsTemp.Tables("TrufitCertificationHeatTreatLines")
        dgvHeatRecords.Columns("LotNumber").HeaderText = "Lot Number"
        dgvHeatRecords.Columns("LotNumber").ReadOnly = True
        dgvHeatRecords.Columns("LotNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvHeatRecords.Columns("HeatRecordNumber").HeaderText = "Heat Record Number"
        dgvHeatRecords.Columns("HeatRecordNumber").ReadOnly = True
        dgvHeatRecords.Columns("HeatRecordNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvHeatRecords.Columns("EntryNumber").Visible = False
        If dgvHeatRecords.Rows.Count > 0 Then
            dgvHeatRecords.CurrentCell = dgvHeatRecords.Rows(0).Cells("LotNumber")
            cmdDeleteHeatTreat.Enabled = True
        Else
            cmdDeleteHeatTreat.Enabled = False
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveDataToolStripMenuItem.Click
        If canSave() Then
            Try
                'Save Data to Header Table Table
                cmd = New SqlCommand("UPDATE TrufitCertificationTable SET CertDate = @CertDate, ShipDate = @ShipDate, FOXNumber = @FOXNumber, Quantity = @Quantity, SalesOrderNumber = @SalesOrderNumber, TorqueRequirement = @TorqueRequirement, Comment1 = @Comment1, Comment2 = @Comment2, Comment3 = @Comment3, DivisionID = 'TFP', Status = @Status WHERE TrufitCertNumber = @TrufitCertNumber;", con)

                With cmd.Parameters
                    .Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(cboTrufitCertNumber.Text)
                    .Add("@CertDate", SqlDbType.VarChar).Value = dtpDate.Text
                    .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(lblOrderNumber.Text)
                    .Add("@TorqueRequirement", SqlDbType.Float).Value = Val(txtTorqueRequirement.Text)
                    .Add("@Comment1", SqlDbType.VarChar).Value = txtComment1.Text
                    .Add("@Comment2", SqlDbType.VarChar).Value = txtComment2.Text
                    .Add("@Comment3", SqlDbType.VarChar).Value = txtComment3.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("TrufitMaterialCompliance - cmdSave_Click --Error trying to save updated Trufit cert data", "Trufit Cert #" + cboTrufitCertNumber.Text, ex.ToString())
                MessageBox.Show("There was an error saving your data. contact system admin.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
            SaveSelectedPickTickets()
            MsgBox("Your data has been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must enter a Certification Number", "Enter a Cert Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If cboTrufitCertNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Certification Number", "Enter a valid Cert Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.SelectAll()
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Trufit Certification is Completed and can't be save", "Unable to Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            If cboFOXNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid FOX Number", "Enter a valid FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboFOXNumber.SelectAll()
                cboFOXNumber.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SaveSelectedPickTickets()
        cmd = New SqlCommand("DELETE TrufitCertificationPickTicket WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

        If chklstPickTickets.CheckedItems.Count > 0 Then
            cmd.CommandText += " INSERT INTO TrufitCertificationPickTicket (TrufitCertNumber, PickTicket) VALUES"
            Dim pos As Integer = 0
            For Each chk In chklstPickTickets.CheckedItems
                If pos = 0 Then
                    cmd.CommandText += " (@TrufitCertNumber, @PickTicket" + pos.ToString + ")"
                Else
                    cmd.CommandText += ", (@TrufitCertNumber, @PickTicket" + pos.ToString + ")"
                End If
                cmd.Parameters.Add("@PickTicket" + pos.ToString, SqlDbType.Int).Value = chk.ToString
                pos += 1
            Next
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        isLoaded = False
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboTrufitCertNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTrufitCertNumber.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            Dim temp As String = cboTrufitCertNumber.Text
            ClearData()
            cboTrufitCertNumber.Text = temp
            ShowHeats()
            isLoaded = True
            LoadHeatRecordNumbers()
            LoadTrufitCertData()
            ShowHeatTreatRecords()
            CheckFOXTorqueCertification()
            IsLocked()
            CheckCertFPI()
        End If
        CheckOutsideCertifications()
    End Sub

    Private Sub cboFOXNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOXNumber.SelectedIndexChanged
        If isLoaded Then
            cboReferenceFOXNumber.Text = cboFOXNumber.Text
            LoadFOXData()
            LoadCustomerData()
        Else
            cboReferenceFOXNumber.SelectedIndex = -1
            If Not String.IsNullOrEmpty(cboReferenceFOXNumber.Text) Then
                cboReferenceFOXNumber.Text = ""
            End If
        End If
    End Sub

    Private Sub cboRefereneFOXNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReferenceFOXNumber.SelectedIndexChanged
        If isLoaded Then
            LoadLotNumbers()
            LoadHeatRecordNumbers()
            CheckFOXTorqueCertification()
        End If
    End Sub

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        If isLoaded Then
            LoadLotData()
            If cboLotNumber.SelectedIndex = -1 Then
                lblFPIForLot.Hide()
            ElseIf CType(cboLotNumber.DataSource, Data.DataTable).Rows(cboLotNumber.SelectedIndex).Item("QCInspected").Equals("NO") Then
                lblFPIForLot.Show()
            Else
                lblFPIForLot.Hide()
            End If
        End If

    End Sub

    Private Sub cmdAddHeats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddHeats.Click
        If canAddHeat() Then
            Try
                'Save Data to Header Table Table
                cmd = New SqlCommand("UPDATE TrufitCertificationTable SET CertDate = @CertDate, ShipDate = @ShipDate, FOXNumber = @FOXNumber, Quantity = @Quantity, SalesOrderNumber = SalesOrderNumber, Comment1 = Comment1, Comment2 = Comment2, Comment3 = Comment3, DivisionID = 'TFP' WHERE TrufitCertNumber = @TrufitCertNumber;", con)

                With cmd.Parameters
                    .Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(cboTrufitCertNumber.Text)
                    .Add("@CertDate", SqlDbType.VarChar).Value = dtpDate.Text
                    .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(lblOrderNumber.Text)
                    .Add("@Comment1", SqlDbType.VarChar).Value = txtComment1.Text
                    .Add("@Comment2", SqlDbType.VarChar).Value = txtComment2.Text
                    .Add("@Comment3", SqlDbType.VarChar).Value = txtComment3.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("TrufitMaterialCompliance - cmdAddHeats_Click --Error trying to save updated Trufit cert data", "Trufit Cert #" + cboTrufitCertNumber.Text, ex.ToString())
                MessageBox.Show("There was an error saving your data. contact system admin.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
            Try
                'Write Line data to new table
                cmd = New SqlCommand("Insert Into TrufitCertificationHeatLines(TrufitCertNumber, HeatLineNumber, LotNumber, HeatNumber, Carbon, LotQuantity)Values(@TrufitCertNumber, (SELECT isnull(MAX(HeatLineNumber) + 1, 1) FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber), @LotNumber, @HeatNumber, @Carbon,@LotQuantity);", con)

                With cmd.Parameters
                    .Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(cboTrufitCertNumber.Text)
                    .Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = lblHeatNumber.Text
                    .Add("@Carbon", SqlDbType.VarChar).Value = lblLotCarbon.Text
                    .Add("@LotQuantity", SqlDbType.Int).Value = Val(txtLotQuantity.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("TrufitMaterialCompliance - cmdAddHeats_Click --Error inserting Heat Number", "Trufit Cert #" + cboTrufitCertNumber.Text, ex.ToString())
                MessageBox.Show("There was an error adding the heat. contact system admin.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
            isLoaded = False
            ShowHeats()
            isLoaded = True
            cboLotNumber.SelectedIndex = -1
            txtLotQuantity.Clear()
            cboLotNumber.Focus()
            LoadHeatRecordNumbers()
        End If
    End Sub

    Private Function canAddHeat() As Boolean
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must enter a Certification Number", "Enter a Cert Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If cboTrufitCertNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Certification Number", "Enter a valid Cert Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.SelectAll()
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLotNumber.Text) Then
            MessageBox.Show("You must enter a Lot Number", "Enter a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.Focus()
            Return False
        End If
        If cboLotNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Lot Number", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLotNumber.SelectAll()
            cboLotNumber.Focus()
            Return False
        End If
        cmd = New SqlCommand("SELECT COUNT(LotNumber) FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber AND LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("Heat Number has already been added", "Not able to add Heat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        con.Close()
        If String.IsNullOrEmpty(txtLotQuantity.Text) Then
            MessageBox.Show("You must enter a lot quantity", "Enter a lot quantity")
            txtLotQuantity.Focus()
            Return False
        End If
        If Not IsNumeric(txtLotQuantity.Text) Then
            MessageBox.Show("You must enter a valid number for lot quantity", "Enter a valid number")
            txtLotQuantity.SelectAll()
            txtLotQuantity.Focus()
            Return False
        End If
        If Val(txtLotQuantity.Text) = 0 Then
            MessageBox.Show("You must enter a number greate than 0 for lot quantity", "Enter a valid number")
            txtLotQuantity.SelectAll()
            txtLotQuantity.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click, ClearDataToolStripMenuItem.Click
        isLoaded = False
        ClearData()
        LoadLotData()
        isLoaded = True
        If cmdPrintAll.Enabled = False Then
            cmdPrintAll.Enabled = True
        End If
        IsLocked()
    End Sub

    Private Sub cmdGenerateNextNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNextNumber.Click
        ClearData()
        Dim key As String = ""
        Try
            'Save Data to Header Table
            cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(TrufitCertNumber) + 1, 670000001) FROM TrufitCertificationTable); Insert Into TrufitCertificationTable (TrufitCertNumber, CertDate, ShipDate, FOXNumber, Quantity, SalesOrderNumber, Comment1, Comment2, Comment3, DivisionID, Status)Values(@Key, @CertDate, @ShipDate, @FOXNumber, @Quantity, @SalesOrderNumber, @Comment1, @Comment2, @Comment3, 'TFP', 'OPEN'); SELECT @Key; COMMIT TRAN;", con)

            With cmd.Parameters
                .Add("@CertDate", SqlDbType.VarChar).Value = dtpDate.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(lblOrderNumber.Text)
                .Add("@Comment1", SqlDbType.VarChar).Value = txtComment1.Text
                .Add("@Comment2", SqlDbType.VarChar).Value = txtComment2.Text
                .Add("@Comment3", SqlDbType.VarChar).Value = txtComment3.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            key = cmd.ExecuteScalar()
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("TrufitMaterialCompliance - cmdGenerateNextNumber_Click --Error inserting Heat Number", "Trufit Cert #" + cboTrufitCertNumber.Text, ex.ToString())
            MessageBox.Show("There was an error adding the heat. contact system admin.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
        isLoaded = False
        LoadTrufitCertNumber()
        cboTrufitCertNumber.Text = key
        isLoaded = True
        IsLocked("OPEN")
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCertificationToolStripMenuItem.Click
        If Not IsLocked() Then
            Try
                'Save Data to Header Table Table
                cmd = New SqlCommand("UPDATE TrufitCertificationTable SET CertDate = @CertDate, ShipDate = @ShipDate, FOXNumber = @FOXNumber, Quantity = @Quantity, SalesOrderNumber = @SalesOrderNumber, Comment1 = @Comment1, Comment2 = @Comment2, Comment3 = @Comment3, DivisionID = 'TFP' WHERE TrufitCertNumber = @TrufitCertNumber;", con)

                With cmd.Parameters
                    .Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(cboTrufitCertNumber.Text)
                    .Add("@CertDate", SqlDbType.VarChar).Value = dtpDate.Text
                    .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(lblOrderNumber.Text)
                    .Add("@Comment1", SqlDbType.VarChar).Value = txtComment1.Text
                    .Add("@Comment2", SqlDbType.VarChar).Value = txtComment2.Text
                    .Add("@Comment3", SqlDbType.VarChar).Value = txtComment3.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("TrufitMaterialCompliance - cmdSave_Click --Error trying to save updated Trufit cert data", "Trufit Cert #" + cboTrufitCertNumber.Text, ex.ToString())
                MessageBox.Show("There was an error saving your data. contact system admin.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
        End If

        Dim NewPrintTrufitCert As New PrintTrufitCert(Val(cboTrufitCertNumber.Text))
        NewPrintTrufitCert.ShowDialog()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteDataToolStripMenuItem.Click
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MsgBox("You must select a valid Trufit Cert Number to delete.", MsgBoxStyle.OkOnly)
        Else
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this CERT?", "DELETE CERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                cmd = New SqlCommand("Delete FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber;", con)
                cmd.CommandText += " Delete FROM TrufitCertificationMechanicalTest WHERE TrufitCertNumber = @TrufitCertNumber;"
                cmd.CommandText += " DELETE TrufitCertificationPickTicket WHERE TrufitCertNumber = @TrufitCertNumber"
                cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(cboTrufitCertNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear all text boxes after entry
                isLoaded = False
                ClearData()
                LoadLotData()
                LoadTrufitCertNumber()
                isLoaded = True
            ElseIf button = DialogResult.No Then
                cmdDelete.Focus()
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

    Private Function IsLocked(Optional ByVal stat As String = "NONE") As Boolean
        If stat.Equals("NONE") Then
            cmd = New SqlCommand("SELECT Status FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber;", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text
            stat = "OPEN"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("Status")) Then
                    stat = reader.Item("Status")
                End If
            End If
            reader.Close()
            con.Close()
        End If

        If stat.Equals("COMPLETED") Then
            cboFOXNumber.Enabled = False
            dtpShipDate.Enabled = False
            txtQuantity.Enabled = False
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            cmdComplete.Enabled = False
            DeleteDataToolStripMenuItem.Enabled = False
            SaveDataToolStripMenuItem.Enabled = False
            PrintToolStripMenuItem.Enabled = True
            gpxLotNumber.Enabled = False
            cmdDeleteSelectedHeat.Enabled = False
            dgvHeatNumbers.ReadOnly = True
            gpxHeatRecordEntry.Enabled = False
            gpxComments.Enabled = False
            gpxHeatRecords.Enabled = False
            cmdPrintAll.Enabled = True
            CanCheckPickTicket = False
            Return True
        End If
        cboFOXNumber.Enabled = True
        dtpShipDate.Enabled = True
        txtQuantity.Enabled = True
        cmdDelete.Enabled = True
        cmdSave.Enabled = True
        cmdComplete.Enabled = True
        DeleteDataToolStripMenuItem.Enabled = True
        SaveDataToolStripMenuItem.Enabled = True
        PrintToolStripMenuItem.Enabled = False
        gpxLotNumber.Enabled = True
        cmdDeleteSelectedHeat.Enabled = True
        dgvHeatNumbers.ReadOnly = False
        gpxHeatRecordEntry.Enabled = True
        gpxComments.Enabled = True
        gpxHeatRecords.Enabled = True
        cmdPrintAll.Enabled = False
        CanCheckPickTicket = True
        Return False
    End Function

    Private Sub UnLockCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockCertToolStripMenuItem.Click
        If canUnlock() Then
            cmd = New SqlCommand("UPDATE TrufitCertificationTable SET Status = 'OPEN' WHERE TrufitCertNumber = @TrufitCertNumber;", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            IsLocked("OPEN")
        End If
    End Sub

    Private Function canUnlock() As Boolean
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must enter a Trufit Certification Number", "Enter a Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If cboTrufitCertNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Trufit Certification Number", "Enter a valid Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.SelectAll()
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If Not IsLocked() Then
            MessageBox.Show("Trufit Certification is not locked.", "Already unlocked", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelectedHeat.Click
        If canDeleteHeat() Then
            cmd = New SqlCommand("DELETE TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber AND HeatNumber = @HeatNumber;", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = dgvHeatNumbers.Rows(dgvHeatNumbers.CurrentCell.RowIndex).Cells("HeatNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            isLoaded = False
            ShowHeats()
            isLoaded = True
            LoadLotNumbers()
        End If
    End Sub

    Private Function canDeleteHeat() As Boolean
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must enter a Trufit Certification Number", "Enter a Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.SelectAll()
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If cboTrufitCertNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Trufit Certification Number", "Enter a valid Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.SelectAll()
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Trufit Certification is Completed and no more changes can be made.", "Unable to Delete Heat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If dgvHeatNumbers.Rows.Count = 0 Then
            MessageBox.Show("There are no Heat Numbers added.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cmdComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComplete.Click
        If canComplete() Then
            cmdSave_Click(sender, e)

            Dim pass As New PasswordEntry(True)
            If pass.ShowDialog() = System.Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE TrufitCertificationTable SET Status = 'COMPLETED', UserID = CASE WHEN UserID is not null then UserID ELSE @UserID END, SignoffDateTime = CASE WHEN SignoffDateTime is not null then SignoffDateTime ELSE CURRENT_TIMESTAMP END WHERE TrufitCertNumber = @TrufitCertNumber;", con)
                cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = pass.txtUserName.Text.ToUpper

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                IsLocked("COMPLETED")
            Else
                MessageBox.Show("Username and password was not valid", "Invalid username and password", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function canComplete() As Boolean
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must enter a Trufit Certification Number", "Enter a Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If cboTrufitCertNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Trufit Certification Number", "Enter a valid Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.SelectAll()
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX for the certification.", "Enter a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid FOX for the certification.", "Enter a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If IsLocked() Then
            MessageBox.Show("Trufit Certification is already Completed.", "Unable to Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If dgvHeatNumbers.Rows.Count = 0 Then
            MessageBox.Show("There are no Heat Numbers added.", "Unable to Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If txtTorqueRequirement.Enabled Then
            If String.IsNullOrEmpty(txtTorqueRequirement.Text) Then
                MessageBox.Show("You msut enter a torque requirement for this customer.", "Enter a torque requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTorqueRequirement.Focus()
                Return False
            End If
            If Val(txtTorqueRequirement.Text) = 0 Then
                MessageBox.Show("You must enter a torque requirement larger than 0.", "Enter a torque requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTorqueRequirement.SelectAll()
                txtTorqueRequirement.Focus()
                Return False
            End If
        End If
        CheckCertFPI()
        If lblFPI.Visible Then
            MessageBox.Show("You can't certify lot numbers that still require a final piece inspection.", "Unable to complete.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtQuantity.Text) Then
            MessageBox.Show("You must enter a total quantity shipped", "Enter a total quantity shipped.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return False
        End If
        If Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("You must enter a valid number for quantity shipped.", "Enter a valid number")
            txtQuantity.SelectAll()
            txtQuantity.Focus()
            Return False
        End If
        If Val(txtQuantity.Text) = 0 Then
            MessageBox.Show("You must enter a number greater than 0 for quantity shipped.", "Enter a valid number")
            txtQuantity.SelectAll()
            txtQuantity.Focus()
            Return False
        End If
        If chklstPickTickets.CheckedItems.Count = 0 Then
            MessageBox.Show("You must select at least 1 pick ticket.", "Select a pick ticket", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tabctrl.SelectTab("tabTorqueAndComments")
            Return False
        End If
        cmd = New SqlCommand("IF ((SELECT SUM(isnull(LotQuantity, 0)) FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) = @TotalShipped) SELECT 1 ELSE SELECT 0", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        cmd.Parameters.Add("@TotalShipped", SqlDbType.Int).Value = Val(txtQuantity.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()

        If obj IsNot Nothing Then
            If CType(obj, Integer) = 0 Then
                MessageBox.Show("Total quantity entered is not the same as total entered for lots. Verify the quantities entered.", "Unable to continue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQuantity.SelectAll()
                txtQuantity.Focus()
                Return False
            End If
        Else
            MessageBox.Show("You must enter a total quantity shipped and quantity per lot.", "Unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClearLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLot.Click
        cboLotNumber.SelectedIndex = -1
        txtLotQuantity.Clear()
    End Sub

    Private Sub cmdMechanicalTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintMechanicalCertificationToolStripMenuItem.Click
        Dim newPrintMechanicalTest As New PrintTrufitCertificationMechanicalTest(cboTrufitCertNumber.Text)
        newPrintMechanicalTest.ShowDialog()
    End Sub

    Private Sub cboHeatTreatLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatTreatLotNumber.SelectedIndexChanged
        If isLoaded And cboHeatTreatLotNumber.SelectedIndex <> -1 Then
            txtHeatTreatRecordNumber.Text = CType(cboHeatTreatLotNumber.DataSource, Data.DataTable).Rows(cboHeatTreatLotNumber.SelectedIndex).Item("HeatTreatRecordNumber").ToString
        End If
    End Sub

    Private Sub cmdAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRecord.Click
        If canAddRecord() Then

            cmd = New SqlCommand("IF Not Exists(SELECT EntryNumber FROM TrufitCertificationHeatTreatLines WHERE TrufitCertNumber = @TrufitCertNumber AND HeatRecordNumber = @HeatRecordNumber) INSERT INTO TrufitCertificationHeatTreatLines VALUES (@TrufitCertNumber, (SELECT isnull(MAX(EntryNumber) + 1, 1) FROM TrufitCertificationHeatTreatLines), @HeatRecordNumber, @LotNumber);", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboHeatTreatLotNumber.Text
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
            cmd.Parameters.Add("@HeatRecordNumber", SqlDbType.Int).Value = Val(txtHeatTreatRecordNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ShowHeatTreatRecords()
            cmdClearRecord_Click(sender, e)
        End If
    End Sub

    Private Function canAddRecord() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must enter a Certification Number", "Enter a Cert Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboHeatTreatLotNumber.Text) Then
            MessageBox.Show("You must enter a Lot Number.", "Enter a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatLotNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtHeatTreatRecordNumber.Text) Then
            MessageBox.Show("You must enter a valid Lot Number.", "Enter a valid Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatLotNumber.SelectAll()
            cboHeatTreatLotNumber.Focus()
            Return False
        End If

        cmd = New SqlCommand("SELECT Status FROM HeatTreatInspectionLog WHERE HeatTreatRecordNumber = @HeatTreatRecordNumber", con)
        cmd.Parameters.Add("@HeatTreatRecordNumber", SqlDbType.Int).Value = txtHeatTreatRecordNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If Not IsDBNull(obj) Then
            If obj.ToString.Equals("OPEN") Then
                con.Close()
                MessageBox.Show("Heat Record selected has not been locked. Unable to add.", "Record not locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmdClearRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearRecord.Click
        cboHeatTreatLotNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatTreatLotNumber.Text) Then
            cboHeatTreatLotNumber.Text = ""
        End If
        txtHeatTreatRecordNumber.Text = ""
        cboHeatTreatLotNumber.Focus()
    End Sub

    Private Sub cmdDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteHeatTreat.Click
        If canDeleteRecord() Then
            cmd = New SqlCommand("DELETE TrufitCertificationHeatTreatLines WHERE TrufitCertNumber = @TrufitCertNumber AND EntryNumber = @EntryNumber", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
            cmd.Parameters.Add("@EntryNumber", SqlDbType.Int).Value = dgvHeatRecords.CurrentRow.Cells("EntryNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            ShowHeatTreatRecords()
        End If
    End Sub

    Private Function canDeleteRecord() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must select a Trufit Certification", "Select a Trufit Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If dgvHeatRecords.Rows.Count = 0 Then
            MessageBox.Show("There are no records to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvHeatRecords.CurrentRow Is Nothing Then
            MessageBox.Show("You must select a record to delete", "Select a record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintHeatCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintHeatTreatCertificationToolStripMenuItem1.Click
        If canPrintHeatTreat() Then
            Dim heatRecords(dgvHeatRecords.Rows.Count - 1) As String
            For i As Integer = 0 To dgvHeatRecords.Rows.Count - 1
                heatRecords(i) = dgvHeatRecords.Rows(i).Cells("HeatRecordNumber").Value.ToString()
            Next
            Using NewPrintHeatTreatCert As New PrintHeatTreatCert(heatRecords, lblCustomerID.Text, lblPartNumber.Text)
                Dim result = NewPrintHeatTreatCert.ShowDialog()
            End Using
        End If
    End Sub

    Private Function canPrintHeatTreat() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            MessageBox.Show("You must select a Trufit Certification number", "Select a Cert Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If cboTrufitCertNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Trufit Certification number", "Enter a valid Cert number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTrufitCertNumber.SelectAll()
            cboTrufitCertNumber.Focus()
            Return False
        End If
        If dgvHeatRecords.Rows.Count = 0 Then
            MessageBox.Show("There are no heat files to create a certification, add lots", "No Heat Records", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatTreatLotNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAll.Click, PrintAllCertificationsToolStripMenuItem.Click
        cmdPrintAll.Enabled = False
        Dim tempds As New DataSet()
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim cmd1, cmd2, cmd3, cmd4 As SqlCommand
        ''fills the dataset for the TFP Cert

        If cmdPrintOutsideCerts.Enabled = True Then
            Dim fls As IO.FileInfo() = CheckOutsideCertifications()
            If fls.Length > 0 Then
                Dim bgwk As New BackgroundWorker()
                AddHandler bgwk.DoWork, AddressOf bgwk_Run
                AddHandler bgwk.RunWorkerCompleted, AddressOf bgwk_Completed

                LoadingScreen.Text = "Combining PDFs"
                LoadingScreen.Label1.Text = "Combining PDF files please wait"
                bgwk.RunWorkerAsync(fls)
                LoadingScreen.Show()
                LoadingScreen.TopMost = True
                Dim fle As IO.FileInfo = UploadAPIOutsideCertification.CombineCertFiles(fls)
            End If
        End If

        If cmdPrintOutsideCerts.Enabled = True Then
            Dim fls As IO.FileInfo() = CheckOutsideCertifications()
            Dim fles As IO.FileInfo
            If fls.Length > 0 Then
                Dim bgwk As New BackgroundWorker()
                AddHandler bgwk.DoWork, AddressOf bgwk_Run
                AddHandler bgwk.RunWorkerCompleted, AddressOf bgwk_Completed
                fles = UploadAPIOutsideCertification.CombineCertFiles(fls)
                'Dim newPrintUploadedPickTickets As New PrintUploadedPickTicket(fles.FullName)'
                Dim MyProcess As New Process
                MyProcess.StartInfo.UseShellExecute = True
                MyProcess.StartInfo.CreateNoWindow = True
                MyProcess.StartInfo.Verb = "print"
                MyProcess.StartInfo.FileName = fles.FullName
                MyProcess.Start()
                MyProcess.WaitForInputIdle()
                MyProcess.CloseMainWindow()
                MyProcess.Close()
            Else
                MessageBox.Show("No outside certifications were found.", "No outside certifications.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If



        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = 'TFP'", con)

        cmd3 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd3.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

        cmd4 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE DivisionID = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd4.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

        Dim myAdapter1 As New SqlDataAdapter(cmd1)
        Dim myAdapter3 As New SqlDataAdapter(cmd3)
        Dim myAdapter4 As New SqlDataAdapter(cmd4)

        If con.State = ConnectionState.Closed Then con.Open()
        tempds.Tables.Add(GetFOXTable())
        tempds.Tables.Add(GetRawMaterialsTable())
        tempds.Tables.Add(GetCustomerList())
        tempds.Tables.Add(GetTrufitCertificationTable())
        tempds.Tables.Add(GetTrufitCertHeatLines())

        myAdapter1.Fill(tempds, "DivisionTable")
        myAdapter3.Fill(tempds, "SalesOrderHeaderTable")
        myAdapter4.Fill(tempds, "SalesOrderLineTable")

        Dim cmd10 As New SqlCommand("SELECT CustomerPO FROM TrufitCertificationPickTicket INNER JOIN PickListHeaderTable ON TrufitCertificationPickTicket.PickTicket = PickListHeaderTable.PickListHeaderKey WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd10.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim myAdapter10 As New SqlDataAdapter(cmd10)
        myAdapter10.Fill(tempds, "TrufitCertificationPickTicket")

        If tempds.Tables("TrufitCertificationPickTicket").Rows.Count > 0 Then
            Dim lst As New List(Of String)
            For i As Integer = 0 To tempds.Tables("TrufitCertificationPickTicket").Rows.Count - 1
                If Not lst.Contains(tempds.Tables("TrufitCertificationPickTicket").Rows(i).Item("CustomerPO").ToString) Then
                    lst.Add(tempds.Tables("TrufitCertificationPickTicket").Rows(i).Item("CustomerPO").ToString)
                End If
            Next
            If lst.Count > 0 Then
                tempds.Tables("TrufitCertificationPickTicket").Rows(0).Item("CustomerPO") = String.Join(",", lst.ToArray())
            End If
        End If

        cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = (SELECT TOP 1 LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber)"

        Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()
        ''changes the part nubmer to show revision level behind it, only for Branam
        If tempds.Tables("FOXTable").Rows.Count > 0 And BlueprintRevLevel IsNot Nothing And lblCustomerID.Text.Equals("BRANAMFASTEN") Then
            For i As Integer = 0 To tempds.Tables("FOXTable").Rows.Count - 1
                tempds.Tables("FOXTable").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
            Next
        End If

        ''check to see if there are any heat treat records added and if so will print the cert for that
        If dgvHeatRecords.Rows.Count > 0 Then
            Dim tempds2 As New DataSet()

            If con.State = ConnectionState.Closed Then con.Open()
            tempds2.Tables.Add(GetHeatTreatInspectionLog())
            tempds2.Tables.Add(GetHeatTreatRockwellTest())
            tempds2.Tables.Add(GetHeatTreatTemperatureDraw())
            tempds2.Tables.Add(GetRawMaterialsTable())
            tempds2.Tables.Add(GetItemList())
            tempds2.Tables.Add(GetCustomerList())
            ''changes the part nubmer to show revision level behind it, only for Branam
            For i As Integer = 0 To tempds2.Tables("HeatTreatInspectionLog").Rows.Count - 1
                tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("CustomerID") = lblCustomerID.Text
                If BlueprintRevLevel IsNot Nothing And lblCustomerID.Text.Equals("BRANAMFASTEN") Then
                    tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("PartNumber") = lblPartNumber.Text + " Rev. " + BlueprintRevLevel.ToString()
                Else
                    tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("PartNumber") = lblPartNumber.Text
                End If
            Next

            cmd = New SqlCommand("SELECT COUNT(TestNumber) as RowCnt FROM TrufitCertificationMechanicalTestHeader WHERE LotNumber in (SELECT LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) and Status = 'CLOSED'", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            reader.Read()
            If reader.Item("RowCnt") > 0 Then
                reader.Close()
                Dim tempds3 As New DataSet()

                Dim CustomerName As String = ""
                If con.State = ConnectionState.Closed Then con.Open()
                tempds3.Tables.Add(GetTrufitCertificationMechanicalTestHeader())
                tempds3.Tables.Add(GetTrufitCertificationMechanicalTestLine())

                cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) as FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID", con)
                cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd2.ExecuteScalar()
                con.Close()
                If Not IsDBNull(obj) Then
                    If obj IsNot Nothing Then
                        CustomerName = obj
                    End If
                End If
                ''changes the part nubmer to show revision level behind it, only for Branam
                For i As Integer = 0 To tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count - 1
                    If BlueprintRevLevel IsNot Nothing And lblCustomerID.Text.Equals("BRANAMFASTEN") Then
                        tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") = lblPartNumber.Text + " Rev. " + BlueprintRevLevel.ToString()
                    Else
                        tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") = lblPartNumber.Text
                    End If
                Next

                ''prints tfp cert
                MyReport = New MOS09Program.CRXTFCert()
                MyReport.SetDataSource(tempds)
                MyReport.PrintToPrinter(1, True, 0, 0)
                ''prints heat treat certs
                Dim MyReport1 = New MOS09Program.CRXHeatTreatCert
                MyReport1.SetDataSource(tempds2)
                MyReport1.PrintToPrinter(1, True, 0, 0)
                ''prints mechanical testing
                Dim MyReport2 = New MOS09Program.CRXTrufitCertMechanicalTest
                CType(MyReport2.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName
                MyReport2.SetDataSource(tempds3)
                MyReport2.PrintToPrinter(1, True, 0, 0)
            Else
                reader.Close()
                con.Close()
                'Sets up viewer to display data from the loaded dataset
                MyReport = New MOS09Program.CRXTFCert()
                MyReport.SetDataSource(tempds)
                MyReport.PrintToPrinter(1, True, 0, 0)
                ''prints heat treat certs
                Dim MyReport1 = New MOS09Program.CRXHeatTreatCert
                MyReport1.SetDataSource(tempds2)
                MyReport1.PrintToPrinter(1, True, 0, 0)
            End If
        Else
            cmd = New SqlCommand("SELECT COUNT(TestNumber) as RowCnt FROM TrufitCertificationMechanicalTestHeader WHERE LotNumber in (SELECT LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) and Status = 'CLOSED'", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            reader.Read()
            If reader.Item("RowCnt") > 0 Then
                reader.Close()
                Dim tempds3 As New DataSet()

                Dim CustomerName As String = ""
                If con.State = ConnectionState.Closed Then con.Open()
                tempds3.Tables.Add(GetTrufitCertificationMechanicalTestHeader())
                tempds3.Tables.Add(GetTrufitCertificationMechanicalTestLine())

                cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) as FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID", con)
                cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd2.ExecuteScalar()
                con.Close()
                If Not IsDBNull(obj) Then
                    If obj IsNot Nothing Then
                        CustomerName = obj
                    End If
                End If

                ''changes the part nubmer to show revision level behind it, only for Branam
                For i As Integer = 0 To tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count - 1
                    If BlueprintRevLevel IsNot Nothing And lblCustomerID.Text.Equals("BRANAMFASTEN") Then
                        tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") = lblPartNumber.Text + " Rev. " + BlueprintRevLevel.ToString()
                    Else
                        tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") = lblPartNumber.Text
                    End If
                Next
                ''prints the TFP cert
                MyReport = New MOS09Program.CRXTFCert()
                MyReport.SetDataSource(tempds)
                MyReport.PrintToPrinter(1, True, 0, 0)
                ''prints the mechanical tests
                Dim MyReport2 = New MOS09Program.CRXTrufitCertMechanicalTest
                CType(MyReport2.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName
                MyReport2.SetDataSource(tempds3)
                MyReport2.PrintToPrinter(1, True, 0, 0)
            Else
                reader.Close()
                con.Close()
                '' prints the TFP Cert
                MyReport = New MOS09Program.CRXTFCert()
                MyReport.SetDataSource(tempds)
                MyReport.PrintToPrinter(1, True, 0, 0)
            End If
        End If

        cmd = New SqlCommand("SELECT COUNT(TrufitCertificationTorqueTestHeader.LotNumber) FROM TrufitCertificationTorqueTestHeader INNER JOIN (SELECT LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) as TFPCert ON TFPCert.LotNumber = TrufitCertificationTorqueTestHeader.LotNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            Dim ds As New DataSet
            Dim CustomerName As String = ""
            Dim TorqueRequirement As Double = 0

            If con.State = ConnectionState.Closed Then con.Open()
            ds.Tables.Add(GetTrufitCertificationTorqueTestHeader())
            ds.Tables.Add(GetTrufitCertificationTorqueTestLine())

            cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) as FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID", con)
            cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd2.ExecuteScalar()

            If Not IsDBNull(obj) Then
                If obj IsNot Nothing Then
                    CustomerName = obj
                End If
            End If

            cmd.CommandText = "SELECT TorqueRequirement FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber"
            obj = cmd.ExecuteScalar()
            If Not IsDBNull(obj) Then
                If obj IsNot Nothing Then
                    TorqueRequirement = Val(obj)
                End If
            End If
            con.Close()
            ''changes the part nubmer to show revision level behind it, only for Branam
            For p As Integer = 0 To ds.Tables("TrufitCertificationTorqueTestHeader").Rows.Count - 1
                If BlueprintRevLevel IsNot Nothing And lblCustomerID.Text.Equals("BRANAMFASTEN") Then
                    ds.Tables("TrufitCertificationTorqueTestHeader").Rows(p).Item("PartNumber") = lblPartNumber.Text + " Rev. " + BlueprintRevLevel.ToString()
                Else
                    ds.Tables("TrufitCertificationTorqueTestHeader").Rows(p).Item("PartNumber") = lblPartNumber.Text
                End If
            Next

            Dim i As Integer = 0

            While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count
                Dim sample As Integer = 1
                Dim currentTest As String = ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber")
                While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count AndAlso currentTest.Equals(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber"))
                    ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") = TorqueRequirement
                    If ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") > ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") Then
                        ds.Tables("TrufitCertificationTorqueTestLine").Rows.RemoveAt(i)
                    Else
                        ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("SampleNumber") = sample
                        ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") = Math.Ceiling(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque"))
                        i += 1
                        sample += 1
                    End If
                End While
            End While
            MyReport = New CRXTrufitCertificationTorqueTest
            CType(MyReport.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName

            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 0, 0)
        End If

        Dim CertFiles As Dictionary(Of String, IO.FileInfo) = GetMillCertFiles(tempds)

        For Each CertFile As IO.FileInfo In CertFiles.Values
            Try
                Dim MyProcess As New Process
                MyProcess.StartInfo.UseShellExecute = True
                MyProcess.StartInfo.CreateNoWindow = True
                MyProcess.StartInfo.Verb = "print"
                MyProcess.StartInfo.FileName = CertFile.FullName
                MyProcess.Start()
                MyProcess.WaitForInputIdle()
                MyProcess.CloseMainWindow()
                MyProcess.Close()
            Catch ex As System.Exception

            End Try
        Next
        cmdPrintAll.Enabled = True
    End Sub

    Private Function GetTrufitCertificationTable() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT * FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

        Dim dt As New Data.DataTable("TrufitCertificationTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertHeatTreatLines() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT * FROM TrufitCertificationHeatTreatLines  WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

        Dim dt As New Data.DataTable("TrufitCertificationHeatTreatLines")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertHeatLines() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationHeatLines.*, LotNumber.SteelSize FROM TrufitCertificationHeatLines INNER JOIN LotNumber ON TrufitCertificationHeatLines.LotNumber = LotNumber.LotNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("TrufitCertificationHeatLines")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetFOXTable() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT FOXTable.* FROM FOXTable INNER JOIN TrufitCertificationTable ON FOXTable.FOXNumber = TrufitCertificationTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("FOXTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetHeatTreatInspectionLog() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT HeatTreatInspectionLog.HeatTreatRecordNumber, HeatTreatInspectionLog.HeatNumber, HeatTreatInspectionLog.LotNumber, HeatTreatInspectionLog.CreationDate, HeatTreatInspectionLog.RMID, FOXTable.CustomerID, FOXTable.DivisionID, FOXTable.PartNumber FROM HeatTreatInspectionLog INNER JOIN TrufitCertificationHeatTreatLines ON HeatTreatInspectionLog.LotNumber = TrufitCertificationHeatTreatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatTreatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatTreatLines.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("HeatTreatInspectionLog")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetHeatTreatRockwellTest() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT HeatTreatRockwellTest.HeatTreatRecordNumber, HeatTreatRockwellTest.SampleNumber, HeatTreatRockwellTest.TestType, HeatTreatRockwellTest.LineAverage, HeatTreatRockwellTest.CoreHardnessScale FROM HeatTreatRockwellTest INNER JOIN HeatTreatInspectionLog ON HeatTreatRockwellTest.HeatTreatRecordNumber = HeatTreatInspectionLog.HeatTreatRecordNumber INNER JOIN TrufitCertificationHeatTreatLines ON HeatTreatInspectionLog.LotNumber = TrufitCertificationHeatTreatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatTreatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber WHERE TrufitCertificationHeatTreatLines.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("HeatTreatRockwellTest")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetHeatTreatTemperatureDraw() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT HeatTreatTemperatureDraw.HeatTreatRecordNumber, HeatTreatTemperatureDraw.TemperatureDrawNumber, HeatTreatTemperatureDraw.TemperingTemperature, HeatTreatTemperatureDraw.TemperingTime, HeatTreatTemperatureDraw.TemperingType FROM HeatTreatTemperatureDraw INNER JOIN HeatTreatInspectionLog ON HeatTreatTemperatureDraw.HeatTreatRecordNumber = HeatTreatInspectionLog.HeatTreatRecordNumber INNER JOIN TrufitCertificationHeatTreatLines ON HeatTreatInspectionLog.LotNumber = TrufitCertificationHeatTreatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatTreatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber WHERE TrufitCertificationHeatTreatLines.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("HeatTreatTemperatureDraw")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetRawMaterialsTable() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT * FROM RawMaterialsTable", con)
        Dim dt As New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetItemList() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT * FROM ItemList INNER JOIN FOXTable ON ItemList.ItemID = FOXTable.PartNumber AND ItemList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON FOXTable.FOXNumber = TrufitCertificationTable.FOXNumber WHERE TrufitCertificationTable.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("ItemList")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetCustomerList() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT CustomerList.* FROM CustomerList INNER JOIN FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("CustomerList")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationMechanicalTestHeader() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TestNumber, TrufitCertificationMechanicalTestHeader.LotNumber, TrufitCertificationMechanicalTestHeader.HeatNumber, FOXTable.PartNumber, Description, TestedBy, ApprovedBy FROM TrufitCertificationMechanicalTestHeader INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("TrufitCertificationMechanicalTestHeader")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationMechanicalTestLine() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationMechanicalTestLine.TestNumber, ResultNumber, Area, ProofPound, LoadPSI, UltimatePound, TensilePSI, LoadMPA, TensileMPA, Results FROM TrufitCertificationMechanicalTestLine INNER JOIN TrufitCertificationMechanicalTestHeader ON TrufitCertificationMechanicalTestLine.TestNumber = TrufitCertificationMechanicalTestHeader.TestNumber INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable on TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber inner join FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("TrufitCertificationMechanicalTestLine")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationTorqueTestHeader() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationTorqueTestHeader.TestNumber, TrufitCertificationTorqueTestHeader.LotNumber, TrufitCertificationTorqueTestHeader.HeatNumber, FOXTable.PartNumber, TrufitCertificationTorqueTestHeader.Description, TrufitCertificationTorqueTestHeader.TestedBy, TrufitCertificationTorqueTestHeader.ApprovedBy FROM TrufitCertificationTorqueTestHeader INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationTorqueTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationTorqueTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("TrufitCertificationTorqueTestHeader")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationTorqueTestLine() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationTorqueTestLine.TestNumber, SampleNumber, RequiredTorque, ActualTorque, Remarks FROM TrufitCertificationTorqueTestLine INNER JOIN TrufitCertificationTorqueTestHeader ON TrufitCertificationTorqueTestLine.TestNumber = TrufitCertificationTorqueTestHeader.TestNumber INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationTorqueTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber WHERE TrufitCertificationTorqueTestHeader.Status = 'CLOSED' AND TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber ORDER BY TrufitCertificationTorqueTestLine.TestNumber, SampleNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
        Dim dt As New Data.DataTable("TrufitCertificationTorqueTestLine")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Sub txtQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress, txtTorqueRequirement.KeyPress, txtLotQuantity.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txtQuantity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown, txtLotQuantity.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Tab Then
            controlKey = True
        End If
    End Sub

    Private Sub PrintTorqueCertificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintTorqueCertificationToolStripMenuItem.Click
        Dim newPrintTorque As New PrintTrufitCertificationTorqueTest(cboTrufitCertNumber.Text)
        newPrintTorque.ShowDialog()
    End Sub

    Private Sub CheckFOXTorqueCertification()
        cmd = New SqlCommand("SELECT COUNT(Certification) FROM FOXCertifications WHERE FOXNumber = @FOXNumber and Certification = 'Torque Test'", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

        Dim lst As New List(Of String)

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            txtTorqueRequirement.Enabled = True
        Else
            txtTorqueRequirement.Enabled = False
        End If
        con.Close()
    End Sub

    Private Sub txtTorqueRequirement_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTorqueRequirement.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Then
            controlKey = True
        ElseIf e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Then
            If Not CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") Then
                controlKey = True
            End If
        End If
    End Sub

    Private Sub CheckCertFPI()
        If RequiresFPI() Then lblFPI.Show() Else lblFPI.Hide()
    End Sub

    Private Function RequiresFPI() As Boolean
        If Not String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            cmd = New SqlCommand("SELECT isnull(Count(QCInspected),0) FROM LotNumber INNER JOIN TrufitCertificationHeatLines ON LotNumber.LotNumber = TrufitCertificationHeatLines.LotNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND LotNumber.QCInspected = 'NO'", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If obj IsNot Nothing Then
                If Val(obj) > 0 Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Sub PrintMillCertificationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintMillCertificationToolStripMenuItem1.Click
        Dim tempds As New DataSet()
        Dim cmd1, cmd3, cmd4 As SqlCommand
        ''fills the dataset for the TFP Cert

        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = 'TFP'", con)

        cmd3 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd3.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

        cmd4 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE DivisionID = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd4.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

        Dim myAdapter1 As New SqlDataAdapter(cmd1)
        Dim myAdapter3 As New SqlDataAdapter(cmd3)
        Dim myAdapter4 As New SqlDataAdapter(cmd4)

        If con.State = ConnectionState.Closed Then con.Open()
        tempds.Tables.Add(GetFOXTable())
        tempds.Tables.Add(GetRawMaterialsTable())
        tempds.Tables.Add(GetCustomerList())
        tempds.Tables.Add(GetTrufitCertificationTable())
        tempds.Tables.Add(GetTrufitCertHeatLines())

        myAdapter1.Fill(tempds, "DivisionTable")
        myAdapter3.Fill(tempds, "SalesOrderHeaderTable")
        myAdapter4.Fill(tempds, "SalesOrderLineTable")
        con.Close()
        Dim CertFiles As Dictionary(Of String, IO.FileInfo) = GetMillCertFiles(tempds)

        For Each CertFile As IO.FileInfo In CertFiles.Values
            Try
                Dim MyProcess As New Process
                MyProcess.StartInfo.UseShellExecute = True
                MyProcess.StartInfo.CreateNoWindow = True
                MyProcess.StartInfo.Verb = "print"
                MyProcess.StartInfo.FileName = CertFile.FullName
                MyProcess.Start()
                MyProcess.WaitForInputIdle()
                MyProcess.CloseMainWindow()
                MyProcess.Close()
            Catch ex As System.Exception

            End Try
        Next
    End Sub

    Private Function GetMillCertFiles(ByVal tempds As Data.DataSet) As Dictionary(Of String, IO.FileInfo)
        Dim rootDirPath As String = "\\TFP-SQL\TransferData\Mill Certifications"
        Dim FoundFiles As New Dictionary(Of String, IO.FileInfo)

        For i As Integer = 0 To tempds.Tables("TrufitCertificationHeatLines").Rows.Count - 1
            Dim dirInfo As New System.IO.DirectoryInfo(rootDirPath)
            Dim FIs As System.IO.FileInfo() = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString.Replace("/", "-").Replace("\", "-").Replace(".", "-") + ".pdf", IO.SearchOption.AllDirectories)

            If FIs.Count() >= 1 Then
                For Each fi As IO.FileInfo In FIs
                    If Not FoundFiles.ContainsKey(fi.FullName) Then
                        FoundFiles.Add(fi.FullName, fi)
                    End If
                Next

            Else
                ''Checks size to see if it is a fraction, if it is will change to decimal, else changes to fraction
                If tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString.Contains("/") Then
                    FIs = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + usefulFunctions.ConvertToDecimal(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString).Replace("/", "-").Replace("\", "-").Replace(".", "-") + ".pdf", IO.SearchOption.AllDirectories)
                Else
                    FIs = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + usefulFunctions.GetFractional(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString).Replace("/", "-").Replace("\", "-") + ".pdf", IO.SearchOption.AllDirectories)
                End If

                For Each fi As IO.FileInfo In FIs
                    If Not FoundFiles.ContainsKey(fi.FullName) Then
                        FoundFiles.Add(fi.FullName, fi)
                    End If
                Next
            End If
        Next

        Return FoundFiles
    End Function

    Private Sub dgvHeatNumbers_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHeatNumbers.CellValueChanged
        If isLoaded Then
            cmd = New SqlCommand("UPDATE TrufitCertificationHeatLines SET LotQuantity = @LotQuantity WHERE TrufitCertNumber = @TrufitCertNumber AND LotNumber = @LotNumber;", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = cboTrufitCertNumber.Text
            cmd.Parameters.Add("@Lotnumber", SqlDbType.VarChar).Value = dgvHeatNumbers.Rows(e.RowIndex).Cells("Lotnumber").Value
            cmd.Parameters.Add("@LotQuantity", SqlDbType.Int).Value = dgvHeatNumbers.Rows(e.RowIndex).Cells("LotQuantity").Value
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub lblOrderNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOrderNumber.TextChanged
        If isLoaded AndAlso Val(lblOrderNumber.Text) <> 0 Then
            chklstPickTickets.Items.Clear()
            cmd = New SqlCommand("SELECT PickListHeaderTable.PickListHeaderKey FROM PickListHeaderTable WHERE SalesOrderHeaderKey = @SalesOrderHeaderKey ORDER BY PickListHeaderTable.PickListHeaderKey DESC", con)
            cmd.Parameters.Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = lblOrderNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read
                    chklstPickTickets.Items.Add(reader.Item(0).ToString)
                End While
            End If
            If Not reader.IsClosed Then reader.Close()
            con.Close()

            Dim lst As New List(Of String)
            cmd = New SqlCommand("SELECT PickTicket FROM TrufitCertificationPickTicket WHERE TrufitCertNumber = @TrufitCertNumber ORDER BY PickTicket DESC", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read
                    lst.Add(reader.Item(0).ToString)
                End While
            End If
            If Not reader.IsClosed Then reader.Close()
            con.Close()
            If lst.Count > 0 Then
                Dim SelectPTPos As Integer = 0
                Dim PTPos As Integer = 0
                While PTPos < chklstPickTickets.Items.Count AndAlso SelectPTPos < lst.Count
                    If chklstPickTickets.Items(PTPos).ToString.Equals(lst(SelectPTPos)) Then
                        chklstPickTickets.SetItemChecked(PTPos, True)
                        SelectPTPos += 1
                    End If
                    PTPos += 1
                End While
            End If
        End If

    End Sub

    Private Sub cmdPrintOutsideCerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintOutsideCerts.Click
        Dim fls As IO.FileInfo() = CheckOutsideCertifications()
        If fls.Length > 0 Then
            'Check Each Lot Number and print cert if it exists
            For Each LineRow As DataGridViewRow In dgvHeatNumbers.Rows
                Dim FileName As String = ""
                Dim FilePath As String = ""
                Dim LotNumber As String = ""

                LotNumber = LineRow.Cells("LotNumber").Value

                FileName = LotNumber + ".pdf"

                FilePath = "\\TFP-FS\TransferData\Uploaded Outside Certifications\" + FileName

                Try
                    Dim MyProcess As New Process
                    MyProcess.StartInfo.UseShellExecute = True
                    MyProcess.StartInfo.CreateNoWindow = True
                    MyProcess.StartInfo.Verb = "print"
                    MyProcess.StartInfo.FileName = FilePath
                    MyProcess.Start()
                    MyProcess.WaitForInputIdle()
                    MyProcess.CloseMainWindow()
                    MyProcess.Close()
                Catch ex As System.Exception
                    'No cert found
                End Try
            Next
        Else
            MessageBox.Show("No outside certifications were found.", "No outside certifications.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function CheckOutsideCertifications() As IO.FileInfo()
        Dim lst As New List(Of IO.FileInfo)
        If Not String.IsNullOrEmpty(cboTrufitCertNumber.Text) Then
            cmd = New SqlCommand("SELECT LotNumber, TrufitCertificationTable.Status FROM TrufitCertificationHeatLines INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.TrufitCertNumber = TrufitCertificationHeatLines.TrufitCertNumber WHERE TrufitCertificationTable.TrufitCertNumber = @TrufitCertNumber", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(cboTrufitCertNumber.Text)

            Dim dt As New Data.DataTable("TrufitCertificationHeatLines")
            Dim adap As New SqlDataAdapter(cmd)
            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(dt)
            con.Close()

            Dim PDFDir As New IO.DirectoryInfo(UploadAPIOutsideCertification.OutsideCertPath)

            For Each rw As Data.DataRow In dt.Rows
                Dim foundFiles As IO.FileInfo() = PDFDir.GetFiles(rw.Item("LotNumber").ToString() + "*.pdf")
                If foundFiles.Length > 0 Then lst.AddRange(foundFiles)
            Next
            If lst.Count > 0 Then
                If dt.Rows(0).Item("Status").ToString.Equals("OPEN") Then
                    cmdPrintOutsideCerts.Enabled = False
                Else
                    cmdPrintOutsideCerts.Enabled = True
                End If
            Else
                cmdPrintOutsideCerts.Enabled = False
            End If
        Else
            cmdPrintOutsideCerts.Enabled = False
        End If
        Return lst.ToArray()
    End Function

    Private Sub bgwk_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Dim fls As IO.FileInfo() = CType(e.Argument, IO.FileInfo())
        e.Result = UploadAPIOutsideCertification.CombineCertFiles(fls)
    End Sub

    Private Sub bgwk_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        LoadingScreen.Hide()
        Dim fle As IO.FileInfo = CType(e.Result, IO.FileInfo)
        Dim newPrintUploadedPickTickets As New PrintUploadedPickTicket(fle.FullName)
        newPrintUploadedPickTickets.ShowDialog()
        Try
            fle.Delete()
        Catch ex As System.Exception

        End Try
    End Sub

    Public Sub LoadSaltSprayInspections()
        chlSaltSpray.Items.Clear()

        If Me.dgvHeatNumbers.RowCount > 0 Then
            Dim LotNumberString As String = ""
            Dim CustomerNameString As String = ""
            Dim CustomerNameLength As Integer = 0

            CustomerNameString = lblCustomerID.Text
            CustomerNameLength = CustomerNameString.Length
            LotNumberString = Me.dgvHeatNumbers.Rows(0).Cells("LotNumber").Value
            Try
                For Each FileName As String In My.Computer.FileSystem.GetFiles("\\TFP-FS\TransferData\Salt Spray Inspection\" + CustomerNameString + "\", FileIO.SearchOption.SearchTopLevelOnly)

                    FileName = FileName.Remove(0, 45 + CustomerNameLength)
                    chlSaltSpray.Items.Add(FileName)
                Next
            Catch ex As Exception
                'Skip
            End Try
        End If
    End Sub

    Private Sub cmdPrintSaltSpray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintSaltSpray.Click
        If lblCustomerID.Text = "" Then
            'Do nothing
        Else
            Dim Counter As Integer = 0

            For i As Integer = 0 To chlSaltSpray.CheckedItems.Count - 1
                Dim FileName As String = ""
                Dim FilePath As String = ""

                'If chlSaltSpray.GetItemChecked(Counter) = True Then
                Dim CustomerNameString As String = ""
                CustomerNameString = lblCustomerID.Text

                FileName = chlSaltSpray.CheckedItems.Item(Counter)

                FilePath = "\\TFP-FS\TransferData\Salt Spray Inspection\" + CustomerNameString + "\" + FileName

                'TextBox1.Text = FileName
                'TextBox2.Text = Counter
                'MsgBox("Pause", MsgBoxStyle.OkOnly)

                Counter = Counter + 1

                Try
                    Dim MyProcess As New Process
                    MyProcess.StartInfo.UseShellExecute = True
                    MyProcess.StartInfo.CreateNoWindow = True
                    MyProcess.StartInfo.Verb = "print"
                    MyProcess.StartInfo.FileName = FilePath
                    MyProcess.Start()
                    MyProcess.WaitForInputIdle()
                    MyProcess.CloseMainWindow()
                    MyProcess.Close()
                Catch ex As System.Exception
                    MsgBox("Try again.", MsgBoxStyle.OkOnly)
                End Try
                'Else
                ''    FileName = chlSaltSpray.CheckedItems(Index)
                'End If
            Next
        End If
    End Sub

    Private Sub lblCustomerID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCustomerID.TextChanged
        If lblCustomerID.Text = "" Then
            cmdPrintSaltSpray.Enabled = False
        Else
            cmdPrintSaltSpray.Enabled = True
            LoadSaltSprayInspections()
        End If
    End Sub

    Private Sub lblCustomerID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCustomerID.Click

    End Sub
End Class