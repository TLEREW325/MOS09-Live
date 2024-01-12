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
Public Class SteelPurchaseOrder
    Inherits System.Windows.Forms.Form

    Dim PassedPONumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    ''check to make sure the fomr is loaded
    Dim isLoaded As Boolean = False
    Dim needsSaved As Boolean = False
    Dim controlKey As Boolean = False
    Dim GetRMID As String = ""
    Dim IsSteelTypeValid As String = ""

    ''For drag and drop line reorder
    Dim dragBoxFromMouseDown As System.Drawing.Rectangle
    Dim rowIndexFromMouseDown As Integer = -1
    Dim rowIndexOfItemUnderMouseToDrop As Integer = -1

    Public Sub New()
        InitializeComponent()
        LoadControlContent()
    End Sub

    Public Sub New(ByVal po As String)
        InitializeComponent()
        LoadControlContent(po)
    End Sub

    Private Sub LoadControlContent(Optional ByVal PassedPONumber As String = "")
        usefulFunctions.LoadSecurity(Me)
        LoadDivisionID()
        isLoaded = True
        ''ClearData()
        cboDivisionID.Text = EmployeeCompanyCode

        If Not String.IsNullOrEmpty(PassedPONumber) Then
            cboSteelPONumber.Text = PassedPONumber
            PassedPONumber = ""
        Else
            cboShipMethod.SelectedIndex = 0
        End If
    End Sub

    Public Sub ShowData()
        Dim tempIsLoaded As Boolean = isLoaded
        isLoaded = False
        cmd = New SqlCommand("SELECT SteelPurchaseLineNumber, RMID, Carbon, SteelSize, PurchaseQuantity, ReceivedWeight, QuantityOpen, PurchasePricePerPound, ExtendedAmount, LineComment, RequireDate, EstShipDate, ShipVia, LineStatus FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey;", con)
        cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelPurchaseLine")
        con.Close()

        dgvSteelPurchaseLines.DataSource = ds.Tables("SteelPurchaseLine")

        dgvSteelPurchaseLines.Columns("RMID").Visible = False
        dgvSteelPurchaseLines.Columns("SteelPurchaseLineNumber").ReadOnly = True
        dgvSteelPurchaseLines.Columns("ExtendedAmount").ReadOnly = True
        dgvSteelPurchaseLines.Columns("ShipVia").ReadOnly = True
        dgvSteelPurchaseLines.Columns("LineStatus").ReadOnly = True
        dgvSteelPurchaseLines.Columns("ReceivedWeight").ReadOnly = True
        dgvSteelPurchaseLines.Columns("QuantityOpen").ReadOnly = True

        dgvSteelPurchaseLines.Columns("SteelPurchaseLineNumber").HeaderText = "Line #"
        dgvSteelPurchaseLines.Columns("SteelSize").HeaderText = "Steel Size"
        dgvSteelPurchaseLines.Columns("PurchaseQuantity").HeaderText = "Order Qty"
        dgvSteelPurchaseLines.Columns("PurchasePricePerPound").HeaderText = "Cost / lb."
        dgvSteelPurchaseLines.Columns("ExtendedAmount").HeaderText = "Extended Amount"
        dgvSteelPurchaseLines.Columns("ExtendedAmount").DefaultCellStyle.Format = "N2"
        dgvSteelPurchaseLines.Columns("LineComment").HeaderText = "Line Comment"
        dgvSteelPurchaseLines.Columns("RequireDate").HeaderText = "Require Date"
        dgvSteelPurchaseLines.Columns("EstShipDate").HeaderText = "Est Ship Date"
        dgvSteelPurchaseLines.Columns("ShipVia").HeaderText = "Ship Via"
        dgvSteelPurchaseLines.Columns("LineStatus").HeaderText = " Line Status"
        dgvSteelPurchaseLines.Columns("ReceivedWeight").HeaderText = "Qty Received"
        dgvSteelPurchaseLines.Columns("QuantityOpen").HeaderText = "Qty Open"

        isLoaded = tempIsLoaded
    End Sub

    Public Sub LoadSteelPONumber()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID ORDER BY SteelPurchaseOrderKey DESC;", con)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "SteelPurchaseOrderHeader")
        con.Close()

        cboSteelPONumber.DisplayMember = "SteelPurchaseOrderKey"
        cboSteelPONumber.DataSource = ds1.Tables("SteelPurchaseOrderHeader")
        cboSteelPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadRawMaterialData()
        cmd = New SqlCommand("SELECT DISTINCT (Carbon) FROM RawMaterialsTable WHERE SteelStatus = @SteelStatus", con)
        cmd.Parameters.Add("@SteelStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "RawMaterialsTable")
        cboSteelCarbon.DataSource = ds7.Tables("RawMaterialsTable")
        con.Close()
        cboSteelCarbon.SelectedIndex = -1

        cmd = New SqlCommand("SELECT DISTINCT (SteelSize) FROM RawMaterialsTable WHERE SteelStatus = @SteelStatus", con)
        cmd.Parameters.Add("@SteelStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "RawMaterialsTable")
        cboSteelSize.DataSource = ds8.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE VendorClass = 'SteelVendor' AND DivisionID = @DivisionID;", con)
        If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TWD") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "Vendor")
        con.Close()

        cboSteelVendor.DisplayMember = "VendorCode"
        cboSteelVendor.DataSource = ds3.Tables("Vendor")
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Private Sub LoadDivisionID()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboDivisionID.Items.Add(reader.Item("DivisionKey"))
                End If
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub LoadStatus()
        If Val(cboSteelPONumber.Text) = 0 Then
            txtStatus.Text = "OPEN"
        Else
            Dim StatusStatement As String = "SELECT Status FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey;"
            Dim StatusCommand As New SqlCommand(StatusStatement, con)
            StatusCommand.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                txtStatus.Text = CStr(StatusCommand.ExecuteScalar)
            Catch ex As Exception
                txtStatus.Text = "OPEN"
            End Try
            con.Close()
        End If

        If String.IsNullOrEmpty(txtStatus.Text) Then
            Exit Sub
        End If
        If txtStatus.Text.Equals("CLOSED") Then
            cmdDelete.Enabled = False
            cmdEnterLines.Enabled = False
            cmdSave.Enabled = False
            SavePOToolStripMenuItem.Enabled = False
            DeletePOToolStripMenuItem.Enabled = False
            dgvSteelPurchaseLines.ReadOnly = True
            cmdDeleteSelected.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnterLines.Enabled = True
            cmdSave.Enabled = True
            SavePOToolStripMenuItem.Enabled = True
            DeletePOToolStripMenuItem.Enabled = True
            dgvSteelPurchaseLines.ReadOnly = False
            cmdDeleteSelected.Enabled = True
        End If
    End Sub

    Public Sub LoadSteelDescription()
        Dim SteelDescription As String = ""

        Dim GetSteelDescriptionStatement As String = "SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetSteelDescriptionCommand As New SqlCommand(GetSteelDescriptionStatement, con)
        GetSteelDescriptionCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        GetSteelDescriptionCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelDescription = CStr(GetSteelDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            SteelDescription = ""
        End Try
        con.Close()

        lblSteelDescription.Text = SteelDescription
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSteelPurchaseLines.CellValueChanged
        If canUpdateCell() Then
            Dim LineExtendedAmount, LinePurchasePricePerPound As Double
            Dim LinePurchaseQuantity, LineNumber As Integer
            Dim currentRow As Integer = dgvSteelPurchaseLines.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvSteelPurchaseLines.CurrentCell.ColumnIndex
            Dim ReqDate As String = ""
            Dim EstShipDate As String = ""
            Dim LineComment As String = ""

            'UPDATE Line Table on changes in the datagrid
            LinePurchasePricePerPound = dgvSteelPurchaseLines.Rows(currentRow).Cells("PurchasePricePerPound").Value
            LinePurchaseQuantity = dgvSteelPurchaseLines.Rows(currentRow).Cells("PurchaseQuantity").Value
            LineNumber = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value
            ReqDate = dgvSteelPurchaseLines.Rows(currentRow).Cells("RequireDate").Value
            EstShipDate = dgvSteelPurchaseLines.Rows(currentRow).Cells("EstShipDate").Value

            LineExtendedAmount = Math.Round(LinePurchasePricePerPound * LinePurchaseQuantity, 2)

            If ReqDate.Split(New String() {"/"}, StringSplitOptions.None).Length <> 3 And ReqDate.Split(New String() {"-"}, StringSplitOptions.None).Length <> 3 Then
                MessageBox.Show("Require date not in proper format. Reverting to todays date", "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ReqDate = Now.ToShortDateString()
            End If

            If EstShipDate.Split(New String() {"/"}, StringSplitOptions.None).Length <> 3 And EstShipDate.Split(New String() {"-"}, StringSplitOptions.None).Length <> 3 Then
                MessageBox.Show("Estimated ship date not in proper format. Reverting to todays date", "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                EstShipDate = Now.ToShortDateString()
            End If
            ''Check to see how long the comment is and if it is larger than 200 characters will ask if it should truncate.
            If dgvSteelPurchaseLines.Rows(currentRow).Cells("LineComment").Value.ToString.Length > 200 Then
                If MessageBox.Show("Line comment entered is larger than what can be stored. Any characters over the limit will be truncated. Do you wish to continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> MessageBoxButtons.YesNo Then
                    Exit Sub
                End If
                LineComment = dgvSteelPurchaseLines.Rows(currentRow).Cells("LineComment").Value.ToString.Substring(0, 200)
            Else
                LineComment = dgvSteelPurchaseLines.Rows(currentRow).Cells("LineComment").Value.ToString
            End If

            'UPDATE Purchase Order based on line changes
            If dgvSteelPurchaseLines.Columns(e.ColumnIndex).Name.Equals("Carbon") Or dgvSteelPurchaseLines.Columns(e.ColumnIndex).Name.Equals("SteelSize") Then

                'Get RMID from test fields - carbon, steel size
                Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
                Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
                GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = Me.dgvSteelPurchaseLines.Rows(e.RowIndex).Cells("Carbon").Value
                GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = Me.dgvSteelPurchaseLines.Rows(e.RowIndex).Cells("SteelSize").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetRMID = ""
                End Try
                con.Close()

                cmd = New SqlCommand("UPDATE SteelPurchaseLine SET PurchasePricePerPound = @PurchasePricePerPound, PurchaseQuantity = @PurchaseQuantity, ExtendedAmount = @ExtendedAmount, RequireDate = @RequireDate, EstShipDate = @EstShipDate, LineComment = @LineComment, RMID = @RMID WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
                cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID
            Else
                cmd = New SqlCommand("UPDATE SteelPurchaseLine SET PurchasePricePerPound = @PurchasePricePerPound, PurchaseQuantity = @PurchaseQuantity, ExtendedAmount = @ExtendedAmount, RequireDate = @RequireDate, EstShipDate = @EstShipDate, LineComment = @LineComment WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
            End If

            With cmd.Parameters
                .Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
                .Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = LineNumber
                .Add("@PurchasePricePerPound", SqlDbType.VarChar).Value = LinePurchasePricePerPound
                .Add("@PurchaseQuantity", SqlDbType.VarChar).Value = LinePurchaseQuantity
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                .Add("@RequireDate", SqlDbType.VarChar).Value = ReqDate
                .Add("@EstShipDate", SqlDbType.VarChar).Value = EstShipDate
                .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadTotals()

            ''check to see what amount is still open
            cmd = New SqlCommand("SELECT QuantityOpen FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
            cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
            cmd.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = LineNumber
            Dim qtyOpen As Double = 0
            If con.State = ConnectionState.Closed Then con.Open()
            qtyOpen = cmd.ExecuteScalar()
            con.Close()

            cmd = New SqlCommand("UPDATE SteelPurchaseLine SET LineStatus = @LineStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
            cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
            cmd.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = LineNumber

            If qtyOpen <= 0 Then
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                ''updates the status of the current purchase Order line
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Dim cnt As Integer = 0
                cmd = New SqlCommand("SELECT COUNT(LineStatus) FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND LineStatus = 'OPEN';", con)
                cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cnt = cmd.ExecuteScalar()
                con.Close()
                If cnt = 0 Then
                    If MessageBox.Show("Do you wish to close the Purchase Order?", "Close Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET Status = 'CLOSED' WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey;", con)
                        cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        LoadStatus()
                    End If
                End If
            Else
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                ''updates the status of the current purchase Order line
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            ShowData()
            dgvSteelPurchaseLines.CurrentCell = dgvSteelPurchaseLines.Rows(currentRow).Cells(currentColumn)
        End If
    End Sub

    Private Function canUpdateCell() As Boolean
        If isLoaded = False Then
            Return False
        End If
        If txtStatus.Text.Equals("CLOSED") Then
            MessageBox.Show("You can't modify line data in a CLOSED Purchase Order", "Unable to change data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim curRow As Integer = dgvSteelPurchaseLines.CurrentCell.RowIndex
            Dim curCell As Integer = dgvSteelPurchaseLines.CurrentCell.ColumnIndex
            ShowData()
            dgvSteelPurchaseLines.CurrentCell = dgvSteelPurchaseLines.Rows(curRow).Cells(curCell)
            Return False
        End If
        If dgvSteelPurchaseLines.Rows.Count = 0 Then
            Return False
        End If
        Dim currentRow As Integer = dgvSteelPurchaseLines.CurrentCell.RowIndex
        cmd = New SqlCommand("SELECT ReceivedWeight FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey and SteelPurchaseLineNumber = @LineNumber;", con)
        cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        cmd.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("ReceivedWeight")) Then
                Dim amount As Double = reader.Item("ReceivedWeight")
                If amount > dgvSteelPurchaseLines.Rows(currentRow).Cells("PurchaseQuantity").Value Then
                    reader.Close()
                    con.Close()
                    MessageBox.Show("You can not change the quantity below what has already been received in. " + amount.ToString() + " has already been received in", "quantity too low", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ShowData()
                    dgvSteelPurchaseLines.CurrentCell = dgvSteelPurchaseLines.Rows(currentRow).Cells("PurchaseQuantity")
                    Return False
                End If
            End If
        End If
        reader.Close()
        If dgvSteelPurchaseLines.Columns(dgvSteelPurchaseLines.CurrentCell.ColumnIndex).Name.Equals("SteelSize") Or dgvSteelPurchaseLines.Columns(dgvSteelPurchaseLines.CurrentCell.ColumnIndex).Name.Equals("Carbon") Then
            'Get RMID from test fields - carbon, steel size
            Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
            Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
            GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = Me.dgvSteelPurchaseLines.Rows(currentRow).Cells("Carbon").Value
            GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = Me.dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelSize").Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetRMID = ""
            End Try
            con.Close()

            cmd = New SqlCommand("SELECT COUNT(RMID) FROM RawMaterialsTable WHERE RMID like @RMID", con)
            cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = GetRMID

            If con.State = ConnectionState.Closed Then con.Open()
            If Convert.ToInt32(cmd.ExecuteScalar()).Equals(0) Then
                resetCarbonSteelSize(currentRow)
                con.Close()
                MessageBox.Show("Carbon and Size Entered is not a valid combination.", "Enter valid Carbon and Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            cmd = New SqlCommand("SELECT COUNT(CoilWeight) FROM SteelReceivingCoilLines WHERE PONumber = @PONumber AND POLineNumber = @POLineNumber", con)
            cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = Val(cboSteelPONumber.Text)
            cmd.Parameters.Add("@POLineNumber", SqlDbType.Int).Value = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                resetCarbonSteelSize(currentRow)
                con.Close()
                MessageBox.Show("You can't change carbon or size if there has been material received.", "Unable to change Carbon or Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            ''Checks to make sure no charter coils have been entered into the system prio to changing the RMID data.
            cmd = New SqlCommand("SELECT COUNT(Weight) FROM CharterSteelCoilIdentification WHERE PurchaseOrderNumber = @PONumber", con)
            cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                resetCarbonSteelSize(currentRow)
                con.Close()
                MessageBox.Show("You can't change carbon or size if there are coils in the system linked to this purchase order.", "Unable to change Carbon or Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        con.Close()
        Return True
    End Function

    Private Sub resetCarbonSteelSize(ByVal currentRow As Integer)
        cmd = New SqlCommand("SELECT Carbon, SteelSize FROM RawMaterialsTable WHERE RMID = (SELECT RMID FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber)", con)
        cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        cmd.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            Dim carbon As String = reader.Item("Carbon").ToString()
            Dim SteelSize As String = reader.Item("SteelSize").ToString()
            isLoaded = False
            dgvSteelPurchaseLines.Rows(currentRow).Cells("Carbon").Value = carbon
            dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelSize").Value = SteelSize
            isLoaded = True
        End If
        reader.Close()
    End Sub

    Public Sub LoadSteelPOData()
        Dim SteelPurchaseOrderDate As Date
        Dim SteelVendorID, Comment, Status As String
        Dim SteelTotal, FreightTotal, OtherTotal, SteelPurchaseTotal As Double

        Dim SteelPurchaseOrderDateCommand As New SqlCommand("SELECT * FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey;", con)
        SteelPurchaseOrderDateCommand.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = SteelPurchaseOrderDateCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SteelPurchaseOrderDate")) Then
                SteelPurchaseOrderDate = Now
            Else
                SteelPurchaseOrderDate = reader.Item("SteelPurchaseOrderDate")
            End If
            If IsDBNull(reader.Item("SteelVendorID")) Then
                SteelVendorID = cboSteelVendor.Text
            Else
                SteelVendorID = reader.Item("SteelVendorID")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("SteelTotal")) Then
                SteelTotal = 0
            Else
                SteelTotal = reader.Item("SteelTotal")
            End If
            If IsDBNull(reader.Item("FreightTotal")) Then
                FreightTotal = 0
            Else
                FreightTotal = reader.Item("FreightTotal")
            End If
            If IsDBNull(reader.Item("OtherTotal")) Then
                OtherTotal = 0
            Else
                OtherTotal = reader.Item("OtherTotal")
            End If
            If IsDBNull(reader.Item("SteelPurchaseTotal")) Then
                SteelPurchaseTotal = 0
            Else
                SteelPurchaseTotal = reader.Item("SteelPurchaseTotal")
            End If
            If IsDBNull(reader.Item("Status")) Then
                Status = "OPEN"
            Else
                Status = reader.Item("Status")
            End If
        Else
            SteelPurchaseOrderDate = Today()
            SteelVendorID = cboSteelVendor.Text
            Comment = ""
            SteelTotal = 0
            FreightTotal = 0
            OtherTotal = 0
            SteelPurchaseTotal = 0
            Status = "OPEN"
        End If
        reader.Close()
        con.Close()

        dtpSteelPODate.Value = SteelPurchaseOrderDate
        cboSteelVendor.Text = SteelVendorID
        txtComment.Text = Comment
        txtFreightTotal.Text = FreightTotal
        txtOtherTotal.Text = OtherTotal
        txtSteelPOTotal.Text = FormatCurrency(SteelPurchaseTotal, 2)
        txtSteelTotal.Text = FormatCurrency(SteelTotal, 2)
        txtStatus.Text = Status
    End Sub

    Public Sub LoadTotals()
        Dim SteelTotal As Double
        Dim SteelTotalCommand As New SqlCommand("SELECT SUM(ExtendedAmount) FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey;", con)
        SteelTotalCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelTotal = CDbl(SteelTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SteelTotal = 0
        End Try
        con.Close()

        Dim FreightTotal As Double = Val(txtFreightTotal.Text.Replace("$", "").Replace(",", ""))
        Dim OtherTotal As Double = Val(txtOtherTotal.Text.Replace("$", "").Replace(",", ""))

        Dim SteelPurchaseTotal As Double = SteelTotal + FreightTotal + OtherTotal
        txtSteelPOTotal.Text = FormatCurrency(SteelPurchaseTotal, 2)
        txtSteelTotal.Text = FormatCurrency(SteelTotal, 2)

        cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET SteelTotal = @SteelTotal, FreightTotal = @FreightTotal, OtherTotal = @OtherTotal, SteelPurchaseTotal = @SteelPurchaseTotal WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey;", con)
        With cmd.Parameters
            .Add("@SteelTotal", SqlDbType.Float).Value = SteelTotal
            .Add("@FreightTotal", SqlDbType.Float).Value = FreightTotal
            .Add("@OtherTotal", SqlDbType.Float).Value = OtherTotal
            .Add("@SteelPurchaseTotal", SqlDbType.Float).Value = SteelPurchaseTotal
            .Add("@SteelPurchaseOrderKey", SqlDbType.Int).Value = Val(cboSteelPONumber.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ClearVariables()
        IsSteelTypeValid = ""
        needsSaved = False
    End Sub

    Public Sub ClearData()
        cboSteelCarbon.Refresh()
        cboSteelPONumber.Refresh()
        cboSteelSize.Refresh()
        cboSteelVendor.Refresh()

        cboSteelCarbon.SelectedIndex = -1
        cboSteelPONumber.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboSteelVendor.SelectedIndex = -1

        If String.IsNullOrEmpty(cboSteelVendor.Text) Then
            cboSteelVendor.Text = ""
        End If

        txtComment.Refresh()
        txtCostPerPound.Refresh()
        txtExtendedAmount.Refresh()
        txtFreightTotal.Refresh()
        txtOtherTotal.Refresh()
        txtPurchaseQuantity.Refresh()
        txtSteelPOTotal.Refresh()
        txtSteelTotal.Refresh()

        txtComment.Clear()
        txtCostPerPound.Clear()
        txtExtendedAmount.Clear()
        txtFreightTotal.Clear()
        txtOtherTotal.Clear()
        txtPurchaseQuantity.Clear()
        txtSteelPOTotal.Clear()
        txtSteelTotal.Clear()

        lblSteelDescription.Text = ""
        cboSteelVendor.Enabled = True
        dtpSteelPODate.Text = ""

        cboSteelPONumber.Focus()
    End Sub

    Public Sub ClearLineData()
        cboSteelCarbon.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelCarbon.Text) Then
            cboSteelCarbon.Text = ""
        End If

        cboSteelSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If

        txtCostPerPound.Clear()
        txtExtendedAmount.Clear()
        txtPurchaseQuantity.Clear()
        txtSuggestedAmount.Clear()
        txtLastPurchasePrice.Clear()
        txtLineComment.Clear()
        cboSteelCarbon.Focus()
        dtpRequireDate.Value = Today
        dtpEstShipDate.Value = Today
        lblSteelDescription.Text = ""
    End Sub

    Private Sub Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        If canExit() Then
            If canSave() Then
                'Load Totals
                LoadTotals()

                ''determines the proper SQL statment to complete
                updateOrInsertSteelPurchaseOrderHeaderTable()
            Else
                Exit Sub
            End If
        End If
        isLoaded = False
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Function canExit() As Boolean
        If Not needsSaved Then
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            Return False
        End If
        'Load Status to determine if PO can be saved
        LoadStatus()
        If Not txtStatus.Text.Equals("OPEN") Then
            Return False
        End If
        If MessageBox.Show("Do you wish to save this Steel Purchase Order?", "SAVE STEEL PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return False
    End Function

    Private Sub cmdGeneratePONumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneratePONumber.Click
        'Clear for next number
        ClearVariables()
        ClearData()
        ShowData()
        Dim newPONumber As Integer = 0
        'Find the next Steel PO Number to use
        Dim MAXCommand As New SqlCommand("DECLARE @SteelPurchaseOrderKey as int = (SELECT isnull(MAX(SteelPurchaseOrderKey) + 1, 12001) FROM SteelPurchaseOrderHeader); INSERT INTO SteelPurchaseOrderHeader (SteelPurchaseOrderKey, DivisionID) VALUES (@SteelPurchaseOrderKey, @DivisionID); SELECT @SteelPurchaseOrderKey;", con)
        MAXCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            newPONumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            newPONumber = 12001
        End Try
        con.Close()

        isLoaded = False
        LoadSteelPONumber()
        isLoaded = True
        cboSteelPONumber.Text = newPONumber
        cboSteelPONumber.Focus()
    End Sub

    Public Sub ValidateSteel()
        Dim CheckRMIDInSteelList As Integer = 0

        Dim CheckScheduledRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND DivisionID = @DivisionID AND SteelStatus <> 'CLOSED'"
        Dim CheckScheduledRMIDCommand As New SqlCommand(CheckScheduledRMIDStatement, con)
        CheckScheduledRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        CheckScheduledRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        CheckScheduledRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRMIDInSteelList = CInt(CheckScheduledRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRMIDInSteelList = 0
        End Try
        con.Close()

        If CheckRMIDInSteelList = 0 Then
            IsSteelTypeValid = "INVALID STEEL"
        Else
            IsSteelTypeValid = "VALID STEEL"
        End If
    End Sub

    Public Sub LockSteelVendor()
        Dim CheckReceiverStatus As Integer = 0

        Dim CheckReceiverStatusStatement As String = "SELECT COUNT(SteelReceivingHeaderKey) FROM SteelReceivingLineTable WHERE SteelPONumber = @SteelPONumber"
        Dim CheckReceiverStatusCommand As New SqlCommand(CheckReceiverStatusStatement, con)
        CheckReceiverStatusCommand.Parameters.Add("@SteelPONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckReceiverStatus = CInt(CheckReceiverStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckReceiverStatus = 0
        End Try
        con.Close()

        If CheckReceiverStatus = 0 Then
            cboSteelVendor.Enabled = True
        Else
            cboSteelVendor.Enabled = False
        End If
    End Sub

    Private Sub cmdEnterLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterLines.Click
        If canAddLine() Then
            '********************************************************************************
            If cboSteelCarbon.Text = "C1010" Then
                Dim button As DialogResult = MessageBox.Show("This steel type is no longer used. Do you wish to continue?", "CONTINUE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Do nothing
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            End If
            '**********************************************************************************
            'Load Totals
            LoadTotals()

            If needsSaved Then
                ''determines the proper SQL statement to complete
                updateOrInsertSteelPurchaseOrderHeaderTable()
                needsSaved = False
            End If
            '**********************************************************************************
            'Check if RMID is valid
            ValidateSteel()

            If IsSteelTypeValid = "INVALID STEEL" Then
                MsgBox("Selected Steel is either closed or does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '**********************************************************************************
            Dim test As Double = Val(txtCostPerPound.Text)

            'Write Data to Steel Purchase Order Line Database Table
            cmd = New SqlCommand("Insert Into SteelPurchaseLine(SteelPurchaseOrderHeaderKey, SteelPurchaseLineNumber, RMID, PurchaseQuantity, PurchasePricePerPound, ExtendedAmount, LineStatus, DebitGLAccount, CreditGLAccount, RequireDate, EstShipDate, ShipVia, LineComment)Values(@SteelPurchaseOrderHeaderKey, (SELECT isnull(MAX(SteelPurchaseLineNumber)+ 1, 1) FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey), (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @PurchaseQuantity, @PurchasePricePerPound, @ExtendedAmount, @LineStatus, @DebitGLAccount, @CreditGLAccount, @RequireDate, @EstShipDate, @ShipVia, @LineComment);", con)

            With cmd.Parameters
                .Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
                .Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
                .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                .Add("@PurchaseQuantity", SqlDbType.VarChar).Value = Val(txtPurchaseQuantity.Text)
                .Add("@PurchasePricePerPound", SqlDbType.Float).Value = Val(txtCostPerPound.Text)
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtExtendedAmount.Text)
                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "20995"
                .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12000"
                .Add("@RequireDate", SqlDbType.VarChar).Value = dtpRequireDate.Text
                .Add("@EstShipDate", SqlDbType.VarChar).Value = dtpEstShipDate.Text
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Refresh datagrid and clear line entry
            ShowData()
            LoadStatus()
            ClearLineData()

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadTotals()
        End If
    End Sub

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            MessageBox.Show("Please enter select a purchase order number", "Select PO Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.Focus()
            Return False
        End If
        If cboSteelPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Purchase Order", "Enter a valid Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.SelectAll()
            cboSteelPONumber.Focus()
            Return False
        End If
        If cboSteelVendor.SelectedIndex = -1 Then
            MessageBox.Show("Please select a vendor", "Select a vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelVendor.Focus()
            Return False
        End If
        If cboSteelCarbon.SelectedIndex = -1 Then
            MessageBox.Show("Please enter a valid carbon", "Enter valid carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelCarbon.Focus()
            Return False
        End If
        If cboSteelSize.SelectedIndex = -1 Then
            MessageBox.Show("Please enter a valid steel size", "Enter valid steel size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If

        cmd = New SqlCommand("SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        ''check to make sure the RMID exists in the database
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("You can not put on a Purchase order for a Carbon/Steel Size combination that does not exist. Add Carbon/Steel Size combination to Raw Material Maintenance.", "Unable to add line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

        'Check to make sure RMID is not closed
        Dim GetSteelStatus As String = ""

        Dim GetSteelStatusStatement As String = "SELECT SteelStatus FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetSteelStatusCommand As New SqlCommand(GetSteelStatusStatement, con)
        GetSteelStatusCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        GetSteelStatusCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSteelStatus = CStr(GetSteelStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetSteelStatus = ""
        End Try
        con.Close()

        If GetSteelStatus = "CLOSED" Then
            MessageBox.Show("You cannot add a steel that is closed.", "Unable to add line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrEmpty(txtPurchaseQuantity.Text) Then
            MessageBox.Show("Please enter a valid Purchase Quantity", "Enter a valid Purchase Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPurchaseQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtPurchaseQuantity.Text) = False Then
            MessageBox.Show("Purchase Quantity must be a number", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPurchaseQuantity.SelectAll()
            txtPurchaseQuantity.Focus()
            Return False
        End If
        If Val(txtPurchaseQuantity.Text) <= 0 Then
            MessageBox.Show("Purchase Quantity must be a number greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPurchaseQuantity.SelectAll()
            txtPurchaseQuantity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCostPerPound.Text) Then
            MessageBox.Show("Please enter a valid cost per pound", "Enter valid cost per pound", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCostPerPound.Focus()
            Return False
        End If
        Dim dte As String = dtpRequireDate.Value.Date()
        If dte = Today() Then
            Dim rslt As DialogResult = MessageBox.Show("Required date is set to today's date. Is this ok?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rslt = Windows.Forms.DialogResult.No Then
                dtpRequireDate.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmdClearLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLines.Click
        ClearLineData()
    End Sub

    Private Sub cboSteelPONumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelPONumber.SelectedIndexChanged
        If isLoaded Then
            LoadSteelPOData()
            LockSteelVendor()
            LoadStatus()
            ShowData()
            needsSaved = False
        End If
    End Sub

    Private Sub txtPurchaseQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPurchaseQuantity.TextChanged, txtCostPerPound.TextChanged
        If isLoaded Then
            UpdateLineExtendedAmount()
        End If
    End Sub

    Private Sub UpdateLineExtendedAmount()
        txtExtendedAmount.Text = Val(txtPurchaseQuantity.Text) * Val(txtCostPerPound.Text)
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SavePOToolStripMenuItem.Click
        If canSave() Then
            '**********************************************************************
            'Check for discontinued steel type
            Dim CheckCarbon As Integer = 0

            Dim CheckCarbonString As String = "SELECT COUNT(SteelPurchaseOrderHeaderKey) FROM SteelPurchaseLine WHERE RMID LIKE 'C1010 %' AND SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
            Dim CheckCarbonCommand As New SqlCommand(CheckCarbonString, con)
            CheckCarbonCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCarbon = CInt(CheckCarbonCommand.ExecuteScalar)
            Catch ex As Exception
                CheckCarbon = 0
            End Try

            If CheckCarbon > 0 Then
                Dim button As DialogResult = MessageBox.Show("One of these steel types is no longer used. Do you wish to continue?", "CONTINUE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Do nothing
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            End If
            '**********************************************************************
            'Check if PO has a receiver and lock Vendor









            'Load Totals
            LoadTotals()
            ''determines the proper SQL statment to complete
            updateOrInsertSteelPurchaseOrderHeaderTable()
            'Refresh datagrid and clear line entry
            ShowData()
            LoadStatus()
            ClearLineData()
            needsSaved = False

            MsgBox("This Steel Purchase Order has been saved", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            MessageBox.Show("You must select a Steel Purchase Order", "Select a PO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.Focus()
            Return False
        End If
        If cboSteelPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Steel Purchase Order", "Enter a valid Steel PO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.SelectAll()
            cboSteelPONumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelVendor.Text) Then
            MessageBox.Show("You must select a Steel Vendor", "Select a Steel Vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelVendor.Focus()
            Return False
        End If
        If cboSteelVendor.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Steel Vendor", "Enter a valid Steel Vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelVendor.SelectAll()
            cboSteelVendor.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(txtFreightTotal.Text) Then
            If Not IsNumeric(txtFreightTotal.Text) Then
                MessageBox.Show("Freight Total must be a number", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFreightTotal.SelectAll()
                txtFreightTotal.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtOtherTotal.Text) Then
            If Not IsNumeric(txtOtherTotal.Text) Then
                MessageBox.Show("Other Total must be a number", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOtherTotal.SelectAll()
                txtOtherTotal.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeletePOToolStripMenuItem.Click
        'Prompt before deleting
        If canDeletePO() Then
            'Create command to save data from text boxes
            cmd = New SqlCommand("DELETE FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey;", con)
            cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear text boxes on delete
            ClearVariables()
            ClearLineData()
            ClearData()

            'Prompt after deletion
            MsgBox("This Steel Purchase Order has been deleted.", MsgBoxStyle.OkOnly)
            needsSaved = False
            isLoaded = False
            LoadSteelPONumber()
            isLoaded = True
        End If
    End Sub

    Private Function canDeletePO()
        If String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            MessageBox.Show("You must select a purchase order number", "Select a purchase order number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboSteelPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid purchase order number", "Enter a purchase order number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        cmd = New SqlCommand("SELECT SteelReceivingHeaderKey FROM SteelReceivingCoilLines WHERE PONumber = @PONumber;", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("SteelReceivingHeaderKey")) Then
                MessageBox.Show("Unable to delete PO, there is a receiving ticket #" + reader.Item("SteelReceivingHeaderKey").ToString() + " for this purchase order", "Already received in", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        reader.Close()
        con.Close()

        LoadStatus()

        If Not txtStatus.Text.Equals("OPEN") Then
            MessageBox.Show("Purchase Order is not in a state to be DELETED", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Steel Purchase Order?", "DELETE PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintPOToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            'Load Status
            LoadStatus()
            GlobalDivisionCode = EmployeeCompanyCode
            If txtStatus.Text.Equals("OPEN") Then
                If needsSaved Then
                    ''determines the proper SQL statment to complete
                    updateOrInsertSteelPurchaseOrderHeaderTable()
                    needsSaved = False
                End If

                GlobalSteelPONumber = Val(cboSteelPONumber.Text)
                Using NewPrintSteelPurchaseOrder As New PrintSteelPurchaseOrder
                    Dim result = NewPrintSteelPurchaseOrder.ShowDialog()
                End Using
            Else
                GlobalSteelPONumber = Val(cboSteelPONumber.Text)
                Using NewPrintSteelPurchaseOrder As New PrintSteelPurchaseOrder
                    Dim result = NewPrintSteelPurchaseOrder.ShowDialog()
                End Using
            End If
        Else
            MsgBox("You must select a valid Steel PO Number to print.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearPOToolStripMenuItem.Click
        ClearVariables()
        ClearLineData()
        ClearData()
        isLoaded = False
        LoadSteelPONumber()
        isLoaded = True
        ShowData()
        LoadStatus()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            LoadSteelPONumber()
            LoadRawMaterialData()
            LoadVendor()
            isLoaded = True
        End If
    End Sub

    Private Sub updateOrInsertSteelPurchaseOrderHeaderTable(Optional ByVal status As String = "OPEN")
        cmd = New SqlCommand("IF EXISTS(SELECT * FROM SteelPurchaseOrderHeader  WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey) UPDATE SteelPurchaseOrderHeader SET SteelPurchaseOrderDate = @SteelPurchaseOrderDate, SteelVendorID =@SteelVendorID, Comment = @Comment, SteelTotal = @SteelTotal, FreightTotal = @FreightTotal, OtherTotal = @OtherTotal, SteelPurchaseTotal = @SteelPurchaseTotal, Status = @Status, DivisionID = @DivisionID WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey ELSE Insert Into SteelPurchaseOrderHeader(SteelPurchaseOrderKey, SteelPurchaseOrderDate, SteelVendorID, Comment, SteelTotal, FreightTotal, OtherTotal, SteelPurchaseTotal, Status, DivisionID)Values(@SteelPurchaseOrderKey, @SteelPurchaseOrderDate, @SteelVendorID, @Comment, @SteelTotal, @FreightTotal, @OtherTotal, @SteelPurchaseTotal, @Status, @DivisionID);", con)
        With cmd.Parameters
            .Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
            .Add("@SteelPurchaseOrderDate", SqlDbType.VarChar).Value = dtpSteelPODate.Text
            .Add("@SteelVendorID", SqlDbType.VarChar).Value = cboSteelVendor.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@SteelTotal", SqlDbType.VarChar).Value = Val(txtSteelTotal.Text.Replace("$", "").Replace(",", ""))
            .Add("@FreightTotal", SqlDbType.VarChar).Value = Val(txtFreightTotal.Text)
            .Add("@OtherTotal", SqlDbType.VarChar).Value = Val(txtOtherTotal.Text)
            .Add("@SteelPurchaseTotal", SqlDbType.VarChar).Value = Val(txtSteelPOTotal.Text.Replace("$", "").Replace(",", ""))
            .Add("@Status", SqlDbType.VarChar).Value = status
        End With
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboSteelPONumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelPONumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            dtpSteelPODate.Focus()
        End If
    End Sub

    Private Sub cboSteelVendor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelVendor.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboSteelCarbon.Focus()
            cboSteelCarbon.SelectAll()
        End If
    End Sub

    Private Sub cboSteelCarbon_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelCarbon.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboSteelSize.Focus()
            cboSteelSize.SelectAll()
        End If
    End Sub

    Private Sub cboSteelSize_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelSize.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtPurchaseQuantity.Focus()
            txtPurchaseQuantity.SelectAll()
        End If
    End Sub

    Private Sub txtPurchaseQuantity_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPurchaseQuantity.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtCostPerPound.Focus()
            txtCostPerPound.SelectAll()
        End If
    End Sub

    Private Sub txtCostPerPound_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCostPerPound.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboShipMethod.Focus()
            cboShipMethod.SelectAll()
        End If
    End Sub

    Private Sub txtComment_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComment.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtFreightTotal.Focus()
            txtFreightTotal.SelectAll()
        End If
    End Sub

    Private Sub txtFreightTotal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFreightTotal.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtOtherTotal.Focus()
            txtOtherTotal.SelectAll()
        End If
    End Sub

    Private Sub dtpSteelPODate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpSteelPODate.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboSteelVendor.Focus()
            cboSteelVendor.SelectAll()
        End If
    End Sub

    Private Sub dtpRequireDate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpRequireDate.KeyUp
        If e.KeyCode = Keys.Enter Then
            dtpEstShipDate.Focus()
        End If
    End Sub

    Private Sub dtpEstShipDate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpEstShipDate.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtComment.Focus()
            txtComment.SelectAll()
        End If
    End Sub

    Private Sub cboShipMethod_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboShipMethod.KeyUp
        If e.KeyCode = Keys.Enter Then
            dtpRequireDate.Focus()
        End If
    End Sub

    Private Sub txtOtherTotal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtherTotal.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdSave.Focus()
        End If
    End Sub

    Private Sub cmdDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelected.Click
        deleteSelectedLine(dgvSteelPurchaseLines.CurrentCell.RowIndex)
        LoadTotals()
    End Sub

    Private Sub deleteSelectedLine(ByVal currentRow As Integer)
        If canDeleteSelectedLine(currentRow) Then
            Dim lineNumber As Integer = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value
            'Create command to save data from text boxes
            cmd = New SqlCommand("DELETE FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderKey AND SteelPurchaseLineNumber = @LineNumber;", con)
            cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
            cmd.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = lineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("SELECT COUNT(LineStatus) FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey and LineStatus = 'RECEIVED'", con)
            cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.Int).Value = Val(cboSteelPONumber.Text)

            If cmd.ExecuteScalar.Equals(0) Then
                If lineNumber < dgvSteelPurchaseLines.Rows.Count Then
                    Dim i As Integer = 0
                    While i < dgvSteelPurchaseLines.Rows.Count
                        If lineNumber < dgvSteelPurchaseLines.Rows(i).Cells("SteelPurchaseLineNumber").Value Then
                            ''updated the row in the table with the proper line number
                            updateLineNumberInTable(i)
                        End If
                        i += 1
                    End While
                    con.Close()
                End If
                ShowData()
            End If

        End If
    End Sub

    Private Sub updateLineNumberInTable(ByVal rw As Integer)
        Dim currentLineNumber As Integer = dgvSteelPurchaseLines.Rows(rw).Cells("SteelPurchaseLineNumber").Value
        Dim newlineNumber As Integer = currentLineNumber - 1
        'updates line numbers in the table
        cmd = New SqlCommand("UPDATE SteelPurchaseLine SET SteelPurchaseLineNumber = @NewLineNumber WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
        With cmd.Parameters
            .Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
            .Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = currentLineNumber
            .Add("@NewLineNumber", SqlDbType.VarChar).Value = newlineNumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub

    Private Function canDeleteSelectedLine(ByVal currentRow As Integer)
        cmd = New SqlCommand("SELECT ReceivedWeight FROM SteelPurchaseQuantityStatus WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey and SteelPurchaseLineNumber = @SteelPurchaseLineNumber;", con)
        cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        cmd.Parameters.Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value
        Dim teswt As String = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If reader.Item("ReceivedWeight") > 0 Then
                reader.Close()
                con.Close()
                MessageBox.Show("Part of line #" + dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value.ToString() + " has already been received in. ", "Already received in", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        reader.Close()
        ''Checks to make sure no charter coils have been entered into the system prio to changing the RMID data.
        cmd = New SqlCommand("SELECT COUNT(Weight) FROM CharterSteelCoilIdentification INNER JOIN RawMaterialsTable ON CharterSteelCoilIdentification.Carbon = RawMaterialsTable.Carbon AND CharterSteelCoilIdentification.SteelSize = RawMaterialsTable.SteelSize WHERE PurchaseOrderNumber = @PONumber AND RawMaterialsTable.RMID = (SELECT RMID FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @PONumber AND SteelPurchaseLineNumber = @POLine)", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)
        cmd.Parameters.Add("@POLine", SqlDbType.VarChar).Value = dgvSteelPurchaseLines.Rows(currentRow).Cells("SteelPurchaseLineNumber").Value

        If con.State = ConnectionState.Closed Then con.Open()
        If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
            resetCarbonSteelSize(currentRow)
            con.Close()
            MessageBox.Show("You can't change carbon or size if there are coils in the system linked to this purchase order.", "Unable to change Carbon or Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        con.Close()

        Return True
    End Function

    Private Sub cboSteelCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.SelectedIndexChanged
        If cboSteelSize.SelectedIndex <> -1 And cboSteelCarbon.SelectedIndex <> -1 Then
            UpdateSteelSize()
            getSuggestedQuantity()
            getLastPurchasePrice()
            LoadSteelDescription()
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If cboSteelSize.SelectedIndex <> -1 And cboSteelCarbon.SelectedIndex <> -1 Then
            UpdateSteelSize()
            getSuggestedQuantity()
            getLastPurchasePrice()
            LoadSteelDescription()
        End If
    End Sub

    Private Sub getSuggestedQuantity()
        Dim orderQty As Double = 0
        cmd = New SqlCommand("SELECT isnull(SteelRequirements, 0) FROM SteelFOXReportQuery WHERE Carbon = @Carbon AND SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        orderQty = cmd.ExecuteScalar()
        con.Close()

        txtSuggestedAmount.Text = Math.Round(Abs(orderQty), 0).ToString()
    End Sub

    Private Sub getLastPurchasePrice()
        Dim lastCost As Double = 0
        cmd = New SqlCommand("SELECT isnull(PurchasePricePerPound, 0) FROM SteelPurchaseLine WHERE SteelPurchaseLine.SteelPurchaseOrderHeaderKey = (SELECT MAX(SteelPurchaseOrderHeaderKey) FROM SteelPurchaseLine WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize)) AND RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize);", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        lastCost = cmd.ExecuteScalar()
        con.Close()

        txtLastPurchasePrice.Text = FormatCurrency(lastCost, 5).ToString()
    End Sub

    Public Sub setPO(ByVal po As String)
        cboSteelPONumber.Text = po
    End Sub

    Private Sub dtpSteelPODate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSteelPODate.ValueChanged
        If dtpSteelPODate.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboSteelVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelVendor.SelectedIndexChanged
        If cboSteelVendor.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub ManuallyClosePOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyClosePOToolStripMenuItem.Click
        If canManuallyClose() Then
            cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET Status = 'CLOSED' WHERE SteelPurchaseOrderKey = @PONumber", con)
            cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE SteelPurchaseLine SET LineStatus = 'RECEIVED' WHERE SteelPurchaseOrderHeaderKey = @PONumber", con)
            cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadStatus()
            ShowData()
            MessageBox.Show("Steel Purchase Order has been CLOSED", "Purchase Order CLOSED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canManuallyClose() As Boolean
        If String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            MessageBox.Show("You must select a Steel Purchase Order Number", "Select a PO Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.Focus()
            Return False
        End If
        If cboSteelPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Steel Purchase Order Number", "Enter a valid PO Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.SelectAll()
            cboSteelPONumber.Focus()
            Return False
        End If
        If Not txtStatus.Text.Equals("OPEN") Then
            MessageBox.Show("Steel Purchase Order is not in an OPEN State and can't be CLOSED", "Can't be closed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.Focus()
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to CLOSE this Purchase Order? Once CLOSED no changes can be made.", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function canOpenPO() As Boolean
        If String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            MessageBox.Show("You must select a Steel Purchase Order Number", "Select a PO Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.Focus()
            Return False
        End If
        If cboSteelPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Steel Purchase Order Number", "Enter a valid PO Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.SelectAll()
            cboSteelPONumber.Focus()
            Return False
        End If
        If Not txtStatus.Text.Equals("CLOSED") Then
            MessageBox.Show("Steel Purchase Order is not in an CLOSED State and can't be OPENED", "Can't be OPENED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.Focus()
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to OPEN this Purchase Order?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub ManuallyOpenPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyOpenPOToolStripMenuItem.Click
        If canOpenPO() Then
            cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET Status = 'OPEN' WHERE SteelPurchaseOrderKey = @PONumber;", con)
            cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = cboSteelPONumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadStatus()
            MessageBox.Show("Steel Purchase Order has been OPENED", "Purchase Order OPENED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cboSteelCarbon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelCarbon.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSteelPONumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelPONumber.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub txtPurchaseQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurchaseQuantity.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub txtCostPerPound_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostPerPound.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub txtFreightTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreightTotal.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub txtOtherTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherTotal.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub cboDivisionID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDivisionID.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSteelPONumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSteelPONumber.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
        End Select
    End Sub

    Private Sub txtPurchaseQuantity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPurchaseQuantity.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
        End Select
    End Sub

    Private Sub txtCostPerPound_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCostPerPound.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
            Case Keys.Decimal
                If Not txtCostPerPound.Text.Contains(".") Or (txtCostPerPound.SelectionLength = txtCostPerPound.Text.Length) Then
                    controlKey = True
                End If
        End Select
    End Sub

    Private Sub txtFreightTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFreightTotal.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
            Case Keys.Decimal
                If Not txtFreightTotal.Text.Contains(".") Or (txtFreightTotal.SelectionLength = txtFreightTotal.Text.Length) Then
                    controlKey = True
                End If
        End Select
    End Sub

    Private Sub txtOtherTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtherTotal.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete, Keys.Back
                controlKey = True
            Case Keys.Decimal
                If Not txtOtherTotal.Text.Contains(".") Or (txtOtherTotal.SelectionLength = txtOtherTotal.Text.Length) Then
                    controlKey = True
                End If
        End Select
    End Sub

    Private Sub cmdReissue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReissue.Click
        If canDuplicate() Then
            '**********************************************************************
            'Check for discontinued steel type
            Dim CheckCarbon As Integer = 0

            Dim CheckCarbonString As String = "SELECT COUNT(SteelPurchaseOrderHeaderKey) FROM SteelPurchaseLine WHERE RMID LIKE 'C1010 %' AND SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
            Dim CheckCarbonCommand As New SqlCommand(CheckCarbonString, con)
            CheckCarbonCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboSteelPONumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCarbon = CInt(CheckCarbonCommand.ExecuteScalar)
            Catch ex As Exception
                CheckCarbon = 0
            End Try

            If CheckCarbon > 0 Then
                Dim button As DialogResult = MessageBox.Show("One of these steel types is no longer used. Do you wish to continue?", "CONTINUE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Do nothing
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            End If
            '**********************************************************************
            cmd = New SqlCommand("BEGIN TRAN" _
                                 + " DECLARE @PONumber as int = (SELECT (MAX(SteelPurchaseOrderKey)+1) FROM SteelPurchaseOrderHeader);" _
                                + " INSERT INTO SteelPurchaseOrderHeader (SteelPurchaseOrderKey, SteelPurchaseOrderDate, SteelVendorID, Comment, SteelTotal, FreightTotal, OtherTotal, SteelPurchaseTotal, Status, DivisionID) SELECT @PONumber, CURRENT_TIMESTAMP, SteelVendorID, Comment, SteelTotal, FreightTotal, OtherTotal, SteelPurchaseTotal, 'OPEN', DivisionID FROM SteelPurchaseOrderHeader WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey;" _
                                + " INSERT INTO SteelPurchaseLine (SteelPurchaseOrderHeaderKey, SteelPurchaseLineNumber, RMID, PurchaseQuantity, PurchasePricePerPound, ExtendedAmount, LineStatus, DebitGLAccount, CreditGLAccount, RequireDate, EstShipDate, ShipVia, LineComment) SELECT @PONumber, SteelPurchaseLineNumber, RMID, PurchaseQuantity, PurchasePricePerPound, ExtendedAmount, 'OPEN', DebitGLAccount, CreditGLAccount, RequireDate, EstShipDate, ShipVia, LineComment FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderKey;" _
                                + " SELECT @PONumber;" _
                                + " Commit Tran;", con)
            cmd.Parameters.Add("@SteelPurchaseOrderKey", SqlDbType.Int).Value = Val(cboSteelPONumber.Text)
            Dim newPO As Integer = 0
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                newPO = cmd.ExecuteScalar()
                MessageBox.Show("New Purchase Order has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Exception
                sendErrorToDataBase("SteelPurchaseOrder - cmdReissue_Click --Error copying data to new Steel PO", "PO #" + cboSteelPONumber.Text, ex.ToString())
            End Try

            isLoaded = False
            ClearData()
            ClearVariables()
            LoadSteelPONumber()
            isLoaded = True
            cboSteelPONumber.Text = newPO.ToString()
        End If
    End Sub

    Private Function canDuplicate() As Boolean
        If String.IsNullOrEmpty(cboSteelPONumber.Text) Then
            MessageBox.Show("You must enter a Purchase Order", "Enter a PO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.Focus()
            Return False
        End If
        If cboSteelPONumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Steel Purchase Order number", "Enter a valid PO number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelPONumber.SelectAll()
            cboSteelPONumber.Focus()
            Return False
        End If
        If dgvSteelPurchaseLines.Rows.Count = 0 Then
            MessageBox.Show("There are no lines to duplicate.", "Unable to duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

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

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged, txtOtherTotal.TextChanged
        UpdatePOTotal()
    End Sub

    Private Sub UpdatePOTotal()
        txtSteelPOTotal.Text = FormatCurrency(Val(txtSteelTotal.Text.Replace("$", "").Replace(",", "")) + Val(txtFreightTotal.Text.Replace("$", "").Replace(",", "")) + Val(txtOtherTotal.Text.Replace("$", "").Replace(",", "")), 2)
    End Sub

    Private Sub cboSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Leave
        UpdateSteelSize()
    End Sub

    Private Sub UpdateSteelSize()

    End Sub

    Private Sub cboSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
        If e.KeyChar.Equals("."c) And (cboSteelSize.Text.Length = 0 Or cboSteelSize.SelectionLength = cboSteelSize.Text.Length) Then
            cboSteelSize.Text = "0."
            e.KeyChar = Nothing
            cboSteelSize.SelectionStart = cboSteelSize.Text.Length
            cboSteelSize.SelectionLength = 0
        End If
    End Sub

    Private Sub cboSteelCarbon_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.Leave
        UpdateSteelSize()
    End Sub

    Private Sub SteelPurchaseOrder_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If isLoaded Then
            isLoaded = False
        End If
    End Sub

    Private Sub dgvSteelPurchaseLines_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvSteelPurchaseLines.DragDrop
        ' The mouse locations are relative to the screen, so they must be converted to client coordinates.
        Dim clientPoint As System.Drawing.Point = dgvSteelPurchaseLines.PointToClient(New System.Drawing.Point(e.X, e.Y))
        ' Get the row index of the item the mouse is below.
        rowIndexOfItemUnderMouseToDrop = dgvSteelPurchaseLines.HitTest(clientPoint.X, clientPoint.Y).RowIndex

        ' If the drag operation was a move then remove and insert the row.
        If e.Effect = DragDropEffects.Move AndAlso CanReOrderLines() Then
            If rowIndexOfItemUnderMouseToDrop < rowIndexFromMouseDown AndAlso rowIndexOfItemUnderMouseToDrop <> -1 Then
                cmd = New SqlCommand("UPDATE SteelPurchaseLine SET SteelPurchaseOrderLineNumber = SteelPurchaseOrderLineNumber + 100 WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseOrderLineNumber = @FromLineNumber;" _
                                     + " UPDATE SteelPurchaseLine SET SteelPurchaseOrderLineNumber = SteelPurchaseOrderLineNumber + 1 WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseOrderLineNumber BETWEEN @DropLineNumber AND (@FromLineNumber - 1);" _
                                     + " UPDATE SteelPurchaseLine SET SteelPurchaseOrderLineNumber = @DropLineNumber WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseOrderLineNumber = @FromLineNumber + 100;", con)
                cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = cboSteelPONumber.Text
                cmd.Parameters.Add("@DropLineNumber", SqlDbType.Int).Value = dgvSteelPurchaseLines.Rows(rowIndexOfItemUnderMouseToDrop).Cells("SteelPurchaseOrderLineNumber").Value
                cmd.Parameters.Add("@FromLineNumber", SqlDbType.Int).Value = dgvSteelPurchaseLines.Rows(rowIndexFromMouseDown).Cells("SteelPurchaseOrderLineNumber").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    sendErrorToDataBase("SteelPurchaseOrder - dgvSteelPurchaseLines_DragDrop -- Error updating line table with new order", "Steel PO #" + cboSteelPONumber.Text, ex.ToString)
                    MessageBox.Show("There was an issue re-ordering the rows. Try again and if issue persists contact system admin.", "Unable to reorder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                con.Close()
            ElseIf rowIndexOfItemUnderMouseToDrop <> -1 AndAlso rowIndexOfItemUnderMouseToDrop <> rowIndexFromMouseDown Then
                cmd = New SqlCommand("UPDATE QCInspectionLineTable SET SteelPurchaseOrderLineNumber = SteelPurchaseOrderLineNumber + 100 WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseOrderLineNumber = @FromLineNumber;" _
                                     + " UPDATE QCInspectionLineTable SET SteelPurchaseOrderLineNumber = SteelPurchaseOrderLineNumber - 1 WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseOrderLineNumber BETWEEN (@FromLineNumber + 1) AND @DropLineNumber;" _
                                     + " UPDATE QCInspectionLineTable SET SteelPurchaseOrderLineNumber = @DropLineNumber WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseOrderLineNumber = @FromLineNumber + 100;", con)
                cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = cboSteelPONumber.Text
                cmd.Parameters.Add("@DropLineNumber", SqlDbType.Int).Value = dgvSteelPurchaseLines.Rows(rowIndexOfItemUnderMouseToDrop).Cells("SteelPurchaseOrderLineNumber").Value
                cmd.Parameters.Add("@FromLineNumber", SqlDbType.Int).Value = dgvSteelPurchaseLines.Rows(rowIndexFromMouseDown).Cells("SteelPurchaseOrderLineNumber").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As System.Exception
                    sendErrorToDataBase("SteelPurchaseOrder - dgvSteelPurchaseLines_DragDrop -- Error updating line table with new order", "Steel PO #" + cboSteelPONumber.Text, ex.ToString)
                    MessageBox.Show("There was an issue re-ordering the rows. Try again and if issue persists contact system admin.", "Unable to reorder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                con.Close()
            End If
            dgvSteelPurchaseLines.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvSteelPurchaseLines.DefaultCellStyle.BackColor
            rowIndexFromMouseDown = -1
            rowIndexFromMouseDown = -1
            dragBoxFromMouseDown = System.Drawing.Rectangle.Empty

            ShowData()
        Else
            dgvSteelPurchaseLines.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvSteelPurchaseLines.DefaultCellStyle.BackColor
            rowIndexFromMouseDown = -1
            rowIndexFromMouseDown = -1
            dragBoxFromMouseDown = System.Drawing.Rectangle.Empty
        End If
    End Sub

    Private Function CanReOrderLines() As Boolean
        cmd = New SqlCommand("SELECT Count(SteelReceivingHeaderKey) FROM SteelReceivingCoilLines WHERE PONumber = @PONumber", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = Val(cboSteelPONumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar > 0 Then
            con.Close()
            MessageBox.Show("Unable ot move lines, steel purchase order has at least 1 receiver against it.", "Unable to move line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub dgvSteelPurchaseLines_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvSteelPurchaseLines.DragOver
        e.Effect = DragDropEffects.Move
        If dragBoxFromMouseDown <> System.Drawing.Rectangle.Empty Then
            Dim clientPoint As System.Drawing.Point = dgvSteelPurchaseLines.PointToClient(New System.Drawing.Point(e.X, e.Y))
            Dim ht As DataGridView.HitTestInfo = dgvSteelPurchaseLines.HitTest(clientPoint.X, clientPoint.Y)
            If ht.RowIndex >= 0 Then
                dgvSteelPurchaseLines.ClearSelection()
                dgvSteelPurchaseLines.Rows(ht.RowIndex).Selected = True
                dgvSteelPurchaseLines.CurrentCell = dgvSteelPurchaseLines.Rows(ht.RowIndex).Cells("SteelPurchaseLineNumber")
            Else
                dgvSteelPurchaseLines.ClearSelection()
            End If
        End If
    End Sub

    Private Sub dgvSteelPurchaseLines_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvSteelPurchaseLines.MouseDown
        If rowIndexFromMouseDown <> -1 Then
            dgvSteelPurchaseLines.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = dgvSteelPurchaseLines.DefaultCellStyle.BackColor
        End If
        rowIndexFromMouseDown = dgvSteelPurchaseLines.HitTest(e.X, e.Y).RowIndex
        If rowIndexFromMouseDown <> -1 Then
            dgvSteelPurchaseLines.Rows(rowIndexFromMouseDown).DefaultCellStyle.BackColor = Color.LightGray
            ' Remember the point where the mouse down occurred. The DragSize indicates the size that the mouse can move before a drag event should be started.
            Dim dragSize As Size = SystemInformation.DragSize
            ' Create a rectangle using the DragSize, with the mouse position being at the center of the rectangle.
            dragBoxFromMouseDown = New System.Drawing.Rectangle(New System.Drawing.Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
        Else
            ' Reset the rectangle if the mouse is not over an item in the ListBox.
            dragBoxFromMouseDown = System.Drawing.Rectangle.Empty
        End If
    End Sub

    Private Sub dgvSteelPurchaseLines_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvSteelPurchaseLines.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If dragBoxFromMouseDown <> System.Drawing.Rectangle.Empty AndAlso (Not dragBoxFromMouseDown.Contains(e.X, e.Y)) Then
                'Sets drop icon
                Dim dropEffect As DragDropEffects = dgvSteelPurchaseLines.DoDragDrop(dgvSteelPurchaseLines.Rows(rowIndexFromMouseDown), DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub SteelPurchaseOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class