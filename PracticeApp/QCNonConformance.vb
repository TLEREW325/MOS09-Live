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
Public Class QCNonConformance
    Inherits System.Windows.Forms.Form

    'Variables for additional Costs
    Dim LaborCost, MachineCost As Double
    Const LaborRate As Double = 20.0
    Const MachineRate As Double = 10.0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim AddLotControl As New QCNonConformanceAddLot()
    Dim isLoaded As Boolean = False
    Dim PartSuggest As AutoCompleteStringCollection

    Private Const NonConformanceRootFolder As String = "\\TFP-FS\TransferData\NonConformance"
    Dim FullScreenForm As ViewPictureFullScreen

    Private Class picData
        Public img As Image
        Public FileName As String
        Public Sub New(ByVal inImg As Image, ByVal nme As String)
            img = inImg
            FileName = nme
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
        LoadPartNumberDescription()
        LoadQCAdjustmentNumber()
        If con.State = ConnectionState.Open Then con.Close()

        AddHandler AddLotControl.VisibleChanged, AddressOf AddLotNumber_Visibility_Changed
        dgvLotNumbers.Columns.Add("LotNumber", "Lot Number(s)")
        dgvLotNumbers.Columns("LotNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        isLoaded = True
        SetControls()
    End Sub

    Public Sub New(ByVal adj As String)
        InitializeComponent()
        LoadPartNumberDescription()
        LoadQCAdjustmentNumber()
        If con.State = ConnectionState.Open Then con.Close()

        AddHandler AddLotControl.VisibleChanged, AddressOf AddLotNumber_Visibility_Changed
        dgvLotNumbers.Columns.Add("LotNumber", "Lot Number(s)")
        dgvLotNumbers.Columns("LotNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        isLoaded = True
        cboAdjustmentNumber.Text = adj
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub LoadPartNumberDescription()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE (DivisionID = 'TWD' OR DivisionID = 'TFP') AND ItemClass <> 'DEACTIVATED-PART' AND FOXNumber <> 0 AND FOXNumber is Not null UNION SELECT ItemID, ShortDescription FROM ItemList WHERE ItemClass = 'FERRULE' AND (DivisionID = 'TWD' OR DivisionID = 'TFP') Order By ItemID", con)
        ds = New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "ItemList")

        cboPartNumber.DisplayMember = "ItemID"
        cboPartDescription.DisplayMember = "ShortDescription"
        cboPartNumber.DataSource = ds.Tables("ItemList")
        cboPartDescription.DataSource = ds.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadQCAdjustmentNumber()
        If cboAdjustmentNumber.Items.Count > 0 Then
            cboAdjustmentNumber.Items.Clear()
        End If
        cmd = New SqlCommand("SELECT QCTransactionNumber FROM QCHoldAdjustment ORDER BY QCTransactionNumber DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboAdjustmentNumber.Items.Add(reader.Item("QCTransactionNumber"))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Public Sub LoadPartDescriptionByPartNumber()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As System.Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As System.Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub ClearData()
        isLoaded = False
        cboAdjustmentNumber.Text = ""
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""

        cboAdjustmentNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1

        txtComment.Clear()
        txtFOXNumber.Clear()
        txtQCAgent.Clear()
        txtQuantity.Clear()
        txtReason.Clear()
        txtReworkHours.Clear()
        txtReworkInstructions.Clear()
        lblStatus.Text = ""
        txtTransferPart.Clear()
        txtMachineNumber.Clear()
        txtMachineOperator.Clear()

        chkAddToInventory.Checked = False
        chkDoNothing.Checked = False
        chkRemoveFromInventory.Checked = False
        chkTransferPart.Checked = False

        rdoRework.Checked = True

        dgvLotNumbers.Rows.Clear()
        dgvAdjustmentLines.DataSource = Nothing
        dgvPictures.Rows.Clear()

        DisposePictureShown()
        picbxSelectedPicture.Image = Nothing
        LoadStatus()
        isLoaded = True
        cboAdjustmentNumber.Focus()
    End Sub

    Public Sub LoadStatus()
        If Val(cboAdjustmentNumber.Text) <> 0 Then
            cmd = New SqlCommand("SELECT Status FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber", con)
            cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If Not IsDBNull(obj) Then
                lblStatus.Text = obj.ToString()
            Else
                lblStatus.Text = "OPEN"
            End If
        End If

        SetControls()
    End Sub

    Private Sub LoadFOXNumbers()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable", con)
        Dim sug As New AutoCompleteStringCollection
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    sug.Add(reader.Item("FOXNumber"))
                End If
            End While
        End If
        con.Close()
        txtFOXNumber.AutoCompleteCustomSource = sug
    End Sub

    Public Sub LoadQCHoldData()
        isLoaded = False
        Dim LoadQCHoldDataStatement As String = "SELECT * FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber"
        Dim LoadQCHoldDataCommand As New SqlCommand(LoadQCHoldDataStatement, con)
        LoadQCHoldDataCommand.Parameters.Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadQCHoldDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                cboPartNumber.SelectedIndex = -1
                If String.IsNullOrEmpty(cboPartNumber.Text) Then
                    cboPartNumber.Text = ""
                End If
            Else
                cboPartNumber.Text = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("PartDescription")) Then
                cboPartDescription.SelectedIndex = -1
                If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
                    cboPartDescription.Text = ""
                End If
            Else
                cboPartDescription.Text = reader.Item("PartDescription")
            End If
            If IsDBNull(reader.Item("QCDate")) Then
                dtpQCHoldDate.Value = Now
            Else
                dtpQCHoldDate.Value = reader.Item("QCDate")
            End If
            If IsDBNull(reader.Item("Status")) Then
                lblStatus.Text = "OPEN"
            Else
                lblStatus.Text = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("QCAgent")) Then
                txtQCAgent.Text = EmployeeLoginName
            Else
                txtQCAgent.Text = reader.Item("QCAgent")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                txtFOXNumber.Text = ""
            Else
                If reader.Item("FOXNumber").Equals(0) Then
                    txtFOXNumber.Text = ""
                Else
                    txtFOXNumber.Text = reader.Item("FOXNumber")
                End If
            End If
            If IsDBNull(reader.Item("QuantityOnHold")) Then
                txtQuantity.Text = 0
            Else
                txtQuantity.Text = reader.Item("QuantityOnHold")
            End If
            If IsDBNull(reader.Item("ReworkHours")) Then
                txtReworkHours.Text = 0
            Else
                txtReworkHours.Text = reader.Item("ReworkHours")
            End If
            If IsDBNull(reader.Item("CorrectiveAction")) Then
                rdoRework.Checked = True
            Else
                Select Case reader.Item("CorrectiveAction")
                    Case "REWORK"
                        rdoRework.Checked = True
                    Case "SCRAP"
                        rdoScrap.Checked = True
                    Case "USEASIS"
                        rdoUseAsIs.Checked = True
                    Case Else
                End Select
            End If
            If IsDBNull(reader.Item("NonConformanceReason")) Then
                txtReason.Text = ""
            Else
                txtReason.Text = reader.Item("NonConformanceReason")
            End If
            If IsDBNull(reader.Item("ReworkInstructions")) Then
                txtReworkInstructions.Text = ""
            Else
                txtReworkInstructions.Text = reader.Item("ReworkInstructions")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                txtComment.Text = ""
            Else
                txtComment.Text = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("MachineNumber")) Then
                txtMachineNumber.Text = ""
            Else
                txtMachineNumber.Text = reader.Item("MachineNumber")
            End If
            If IsDBNull(reader.Item("MachineOperator")) Then
                txtMachineOperator.Text = ""
            Else
                txtMachineOperator.Text = reader.Item("MachineOperator")
            End If
        Else
            cboPartNumber.SelectedIndex = -1
            If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
                cboPartNumber.Text = ""
            End If
            cboPartDescription.SelectedIndex = -1
            If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
                cboPartDescription.Text = ""
            End If
            dtpQCHoldDate.Value = Now.Date
            txtQCAgent.Text = EmployeeLoginName
            lblStatus.Text = "OPEN"
            txtFOXNumber.Text = ""
            txtQuantity.Text = 0
            txtReworkHours.Text = 0
            rdoRework.Checked = True
            txtReason.Text = ""
            txtComment.Text = ""
            txtMachineOperator.Clear()
            txtMachineNumber.Clear()
        End If
        reader.Close()
        con.Close()
        isLoaded = True
        SetControls()
    End Sub

    Private Sub SetControls()
        If lblStatus.Text.Equals("OPEN") Then
            cmdDelete.Enabled = True
            cmdPostEntry.Enabled = True
            cmdSave.Enabled = True
            cmdCloseEntry.Enabled = True
            cmdPrint.Enabled = True
            cmdAddLot.Enabled = True
            cmdQCRacking.Enabled = True
            ManuallyReOpenToolStripMenuItem.Enabled = False
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
            rdoRework.Enabled = True
            rdoScrap.Enabled = True
            rdoUseAsIs.Enabled = True
            chkAddToInventory.Enabled = True
            chkDoNothing.Enabled = True
            chkRemoveFromInventory.Enabled = True
            chkTransferPart.Enabled = True
            txtTransferPart.Enabled = True
            txtQCAgent.Enabled = True
            txtFOXNumber.Enabled = True
            cboPartNumber.Enabled = True
            cboPartDescription.Enabled = True
            txtQuantity.Enabled = True
            gpxQCNotes.Enabled = True
            txtReworkHours.Enabled = True
            txtAdjustmentQuantity.Enabled = True
            txtMachineNumber.Enabled = True
            txtMachineOperator.Enabled = True
        ElseIf lblStatus.Text.Equals("CLOSED") Then
            cmdDelete.Enabled = False
            cmdPostEntry.Enabled = False
            cmdSave.Enabled = False
            cmdCloseEntry.Enabled = False
            cmdAddLot.Enabled = False
            cmdDeleteLot.Enabled = False
            cmdQCRacking.Enabled = True
            ManuallyReOpenToolStripMenuItem.Enabled = True
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
            cmdPrint.Enabled = True
            rdoRework.Enabled = False
            rdoScrap.Enabled = False
            rdoUseAsIs.Enabled = False
            chkAddToInventory.Enabled = False
            chkDoNothing.Enabled = False
            chkRemoveFromInventory.Enabled = False
            chkTransferPart.Enabled = False
            txtTransferPart.Enabled = False
            txtQCAgent.Enabled = False
            cboPartNumber.Enabled = False
            cboPartDescription.Enabled = False
            txtQuantity.Enabled = False
            gpxQCNotes.Enabled = False
            txtReworkHours.Enabled = False
            txtAdjustmentQuantity.Enabled = False
            txtFOXNumber.Enabled = False
            cboPartNumber.Enabled = False
            cboPartDescription.Enabled = False
            txtMachineNumber.Enabled = False
            txtMachineOperator.Enabled = False
        Else
            cmdDelete.Enabled = False
            cmdPostEntry.Enabled = False
            cmdSave.Enabled = False
            cmdCloseEntry.Enabled = False
            cmdPrint.Enabled = False
            cmdAddLot.Enabled = False
            cmdDeleteLot.Enabled = False
            cmdQCRacking.Enabled = False
            ManuallyReOpenToolStripMenuItem.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
            txtReworkHours.Enabled = True
            gpxQCNotes.Enabled = True
            txtAdjustmentQuantity.Enabled = True
            txtFOXNumber.Enabled = True
            lblStatus.Text = "OPEN"
        End If
    End Sub

    Private Sub chkTransferPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTransferPart.CheckedChanged
        If chkTransferPart.Checked Then
            Dim custSug As New AutoCompleteStringCollection
            If PartSuggest Is Nothing Then
                PartSuggest = New AutoCompleteStringCollection
                For i As Integer = 0 To ds.Tables("ItemList").Rows.Count - 1
                    PartSuggest.Add(ds.Tables("ItemList").Rows(i).Item("ItemID"))
                Next
            End If

            txtTransferPart.AutoCompleteCustomSource = PartSuggest
            lblTransferPartNumber.Show()
            txtTransferPart.Show()
            chkAddToInventory.Checked = False
            chkDoNothing.Checked = False
            chkRemoveFromInventory.Checked = False
            txtTransferPart.Focus()
        Else
            txtTransferPart.Clear()
            lblTransferPartNumber.Hide()
            txtTransferPart.Hide()
        End If
    End Sub

    Private Sub chkDoNothing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDoNothing.CheckedChanged
        If chkDoNothing.Checked = True Then
            chkAddToInventory.Checked = False
            chkTransferPart.Checked = False
            chkRemoveFromInventory.Checked = False
        End If
    End Sub

    Private Sub chkAddToInventory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddToInventory.CheckedChanged
        If chkAddToInventory.Checked = True Then
            chkDoNothing.Checked = False
            chkTransferPart.Checked = False
            chkRemoveFromInventory.Checked = False
        End If
    End Sub

    Private Sub chkRemoveFromInventory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRemoveFromInventory.CheckedChanged
        If chkRemoveFromInventory.Checked = True Then
            chkDoNothing.Checked = False
            chkTransferPart.Checked = False
            chkAddToInventory.Checked = False
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadPartDescriptionByPartNumber()
            If String.IsNullOrEmpty(txtFOXNumber.Text) And Not String.IsNullOrEmpty(cboPartNumber.Text) Then
                cmd = New SqlCommand("SELECT FOXNumber FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')", con)
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd.ExecuteScalar()
                con.Close()
                If Not IsDBNull(obj) And obj IsNot Nothing Then
                    If obj <> 0 Then
                        txtFOXNumber.Text = obj.ToString()
                    Else
                        txtFOXNumber.Text = ""
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        If isLoaded Then
            LoadPartNumberByDescription()
        End If
    End Sub

    Private Sub cmdGenerateNewAdjustmentNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewAdjustmentNumber.Click
        isLoaded = False
        ClearData()
        isLoaded = True

        lblStatus.Text = "OPEN"
        txtQCAgent.Text = EmployeeLoginName

        Try
            'Write to table to reserve number
            cmd = New SqlCommand("DECLARE @QCTransactionNumber as int = (SELECT isnull(MAX(QCTransactionNumber) + 1, 36001) FROM QCHoldAdjustment);INSERT INTO QCHoldAdjustment (QCTransactionNumber, QCDate, DivisionID, Status, QCAgent, FOXNumber, PartNumber, PartDescription, QuantityOnHold, ReworkHours, CorrectiveAction, AdjustmentAction, TransferPartNumber, NonConformanceReason, ReworkInstructions, Comment, InventoryAdjustmentNumber, ApprovedBy, ApprovalDate, MachineNumber, MachineOperator) Values (@QCTransactionNumber, @QCDate, (SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber), @Status, @QCAgent, @FOXNumber, @PartNumber, @PartDescription, @QuantityOnHold, @ReworkHours, @CorrectiveAction, @AdjustmentAction, @TransferPartNumber, @NonConformanceReason, @ReworkInstructions, @Comment, @InventoryAdjustmentNumber, @ApprovedBy, @ApprovalDate, @MachineNumber, @MachineOperator); SELECT @QCTransactionNumber;", con)

            With cmd.Parameters
                .Add("@QCDate", SqlDbType.VarChar).Value = dtpQCHoldDate.Text
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@QCAgent", SqlDbType.VarChar).Value = txtQCAgent.Text
                .Add("@FOXNumber", SqlDbType.VarChar).Value = txtFOXNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@QuantityOnHold", SqlDbType.VarChar).Value = 0
                .Add("@ReworkHours", SqlDbType.VarChar).Value = 0
                .Add("@CorrectiveAction", SqlDbType.VarChar).Value = ""
                .Add("@AdjustmentAction", SqlDbType.VarChar).Value = ""
                .Add("@TransferPartNumber", SqlDbType.VarChar).Value = ""
                .Add("@NonConformanceReason", SqlDbType.VarChar).Value = txtReason.Text
                .Add("@ReworkInstructions", SqlDbType.VarChar).Value = txtReworkInstructions.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@InventoryAdjustmentNumber", SqlDbType.VarChar).Value = 0
                .Add("@ApprovedBy", SqlDbType.VarChar).Value = ""
                .Add("@ApprovalDate", SqlDbType.VarChar).Value = ""
                .Add("@MachineNumber", SqlDbType.VarChar).Value = txtMachineNumber.Text
                .Add("@MachineOperator", SqlDbType.VarChar).Value = txtMachineOperator.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If Not IsDBNull(obj) Then
                isLoaded = False
                LoadQCAdjustmentNumber()
                cboAdjustmentNumber.Text = obj
                isLoaded = True
            End If
        Catch ex As System.Exception
            'Error Log
            Dim TempQCNumber As Integer = 0
            Dim strQCNumber As String
            TempQCNumber = Val(cboAdjustmentNumber.Text)
            strQCNumber = CStr(TempQCNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = EmployeeCompanyCode
            ErrorDescription = "QC Hold Form --- Create New Failure"
            ErrorReferenceNumber = "QC Hold  # " + strQCNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        SetControls()
        cboAdjustmentNumber.Focus()
    End Sub

    Public Sub UPDATEQCHoldTable()

        If lblStatus.Text.Equals("OPEN") Then
            'Update database table
            cmd = New SqlCommand("UPDATE QCHoldAdjustment SET QCDate = @QCDate, Status = @Status, QCAgent = @QCAgent, FOXNumber = @FOXNumber, PartNumber = @PartNumber, PartDescription = @PartDescription, LongDescription = (SELECT TOP 1 LongDescription FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP')), QuantityOnHold = @QuantityOnHold, ReworkHours = @ReworkHours, CorrectiveAction = @CorrectiveAction, NonConformanceReason = @NonConformanceReason, ReworkInstructions = @ReworkInstructions, Comment = @Comment, ApprovedBy = @ApprovedBy, ApprovalDate = @ApprovalDate, MachineNumber = @MachineNumber, MachineOperator = @MachineOperator, DivisionID = (case when EXISTS(SELECT TOP 1 DivisionID FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP')) THEN (SELECT TOP 1 DivisionID FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP')) ELSE (SELECT 'TWD') END) WHERE QCTransactionNumber = @QCTransactionNumber", con)

            With cmd.Parameters
                .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                .Add("@QCDate", SqlDbType.VarChar).Value = dtpQCHoldDate.Text
                .Add("@Status", SqlDbType.VarChar).Value = lblStatus.Text
                .Add("@QCAgent", SqlDbType.VarChar).Value = txtQCAgent.Text
                .Add("@FOXNumber", SqlDbType.VarChar).Value = txtFOXNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@QuantityOnHold", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@ReworkHours", SqlDbType.VarChar).Value = Val(txtReworkHours.Text)
                .Add("@TransferPartNumber", SqlDbType.VarChar).Value = txtTransferPart.Text
                .Add("@NonConformanceReason", SqlDbType.VarChar).Value = txtReason.Text
                .Add("@ReworkInstructions", SqlDbType.VarChar).Value = txtReworkInstructions.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@ApprovedBy", SqlDbType.VarChar).Value = ""
                .Add("@ApprovalDate", SqlDbType.VarChar).Value = ""
                .Add("@MachineNumber", SqlDbType.VarChar).Value = txtMachineNumber.Text
                .Add("@MachineOperator", SqlDbType.VarChar).Value = txtMachineOperator.Text
            End With

            Select Case True
                Case rdoRework.Checked
                    cmd.Parameters.Add("@CorrectiveAction", SqlDbType.VarChar).Value = "REWORK"
                Case rdoScrap.Checked
                    cmd.Parameters.Add("@CorrectiveAction", SqlDbType.VarChar).Value = "SCRAP"
                Case rdoUseAsIs.Checked
                    cmd.Parameters.Add("@CorrectiveAction", SqlDbType.VarChar).Value = "USEASIS"
                Case rdoSort.Checked
                    cmd.Parameters.Add("@CorrectiveAction", SqlDbType.VarChar).Value = "SORT PARTS"
            End Select
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Public Sub InsertIntoInventoryTransactionTable(ByVal part As String, ByVal description As String, ByVal glaccount As String, ByVal cost As Double, ByVal division As String, ByVal ITQuantity As Double)
        '******************************************************************************************************************************************
        'Write Data to the Inventory Transaction Table
        cmd = New SqlCommand("DECLARE @TransactionNumber as int = (SELECT isnull(MAX(TransactionNumber)+1, 867500001) FROM InventoryTransactionTable);Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpQCHoldDate.Text
            .Add("@TransactionType", SqlDbType.VarChar).Value = "QC Inventory Adjustment"
            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = 1
            .Add("@PartNumber", SqlDbType.VarChar).Value = part
            .Add("@PartDescription", SqlDbType.VarChar).Value = description
            .Add("@Quantity", SqlDbType.VarChar).Value = ITQuantity
            .Add("@ItemCost", SqlDbType.VarChar).Value = cost
            .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
            .Add("@ExtendedCost", SqlDbType.VarChar).Value = Math.Round(cost * Val(txtAdjustmentQuantity.Text), 2)
            .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
            .Add("@GLAccount", SqlDbType.VarChar).Value = glaccount
            .Add("@DivisionID", SqlDbType.VarChar).Value = division
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Function InsertIntoInventoryAdjustmentTable(ByVal part As String, ByVal description As String, ByVal ITGLAccount As String, ByVal ITCost As Double, ByVal division As String, ByVal ITQuantity As Double) As Integer
        'Write Data to Inventory Adjustment Header Database Table
        cmd = New SqlCommand("BEGIN TRAN DECLARE @BatchNumber as int = (SELECT isnull(MAX(BatchNumber)+1, 337000001) FROM InventoryAdjustmentBatchNumbers), @AdjustmentNumber as int = (SELECT isnull(MAX(AdjustmentNumber)+1, 547000001) FROM InventoryAdjustmentTable); INSERT INTO InventoryAdjustmentBatchNumbers (BatchNumber, DivisionID, Locked) Values (@BatchNumber, @DivisionID, @Locked);" _
                             + " Insert Into InventoryAdjustmentTable(AdjustmentNumber, AdjustmentDate, DivisionID, PartNumber, Description, Reason, Quantity, Cost, Total, Status, BatchNumber, InventoryAccount, AdjustmentAccount, AdjustmentAgent)" _
                             + " Values(@AdjustmentNumber, @AdjustmentDate, @DivisionID, @PartNumber, @Description, @Reason, @Quantity, @Cost, @Total, @Status, @BatchNumber, @InventoryAccount, @AdjustmentAccount, @AdjustmentAgent); SELECT @AdjustmentNumber; COMMIT TRAN;", con)

        With cmd.Parameters
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpQCHoldDate.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = part
            .Add("@Description", SqlDbType.VarChar).Value = description
            .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
            .Add("@Quantity", SqlDbType.VarChar).Value = ITQuantity
            .Add("@Cost", SqlDbType.VarChar).Value = ITCost
            .Add("@Total", SqlDbType.VarChar).Value = Math.Round(Val(txtAdjustmentQuantity.Text) * ITCost, 2)
            .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
            .Add("@InventoryAccount", SqlDbType.VarChar).Value = ITGLAccount
            .Add("@AdjustmentAccount", SqlDbType.VarChar).Value = "59790"
            .Add("@AdjustmentAgent", SqlDbType.VarChar).Value = txtQCAgent.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = division
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()

        If Not IsDBNull(obj) And obj IsNot Nothing Then
            Return Convert.ToInt32(obj)
        Else
            'Error Log
            Dim TempQCNumber As Integer = 0
            Dim strQCNumber As String
            TempQCNumber = Val(cboAdjustmentNumber.Text)
            strQCNumber = CStr(TempQCNumber)

            ErrorDate = Today()
            ErrorComment = "No Returned AdjustmentNumber"
            ErrorDivision = EmployeeCompanyCode
            ErrorDescription = "QC Hold Form --- Insert Into Inventory AdjustmentTable Failure"
            ErrorReferenceNumber = "QC Hold  # " + strQCNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
            Return 0
        End If
    End Function

    Public Sub PostToGeneralLedger(ByVal GLDebitAccount As String, ByVal GLCreditAccount As String, ByVal Amount As Double)

        '*****************************************************************************************************************************************
        'Command to write Line Amount to GL
        cmd = New SqlCommand("BEGIN TRAN DECLARE @GLTransactionKey as int = (SELECT isnull(MAX(GLTransactionKey)+1,220001) FROM GLTransactionMasterList); SET xact_abort on;" _
                             + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)" _
                             + " values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, 'TWD', @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

        With cmd.Parameters
            .Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = " QC Inventory Adjustment"
            .Add("@GLTransactionDate", SqlDbType.Date).Value = Now
            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Amount
            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtReason.Text
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 887100000
            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        End With

        '*****************************************************************************************************************************************
        'Command to write Line Amount to GL
        cmd.CommandText += ", (@GLTransactionKey +1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, 'TWD', @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus);" _
        + " COMMIT TRAN; SET xact_abort OFF;"

        With cmd.Parameters
            .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLCreditAccount
            .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = Amount
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            If ex.ToString.ToLower.Contains("primary") Then
                cmd.ExecuteNonQuery()
            Else
                'Error Log
                Dim TempQCNumber As Integer = 0
                Dim strQCNumber As String
                TempQCNumber = Val(cboAdjustmentNumber.Text)
                strQCNumber = CStr(TempQCNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "QC Hold Form --- GL Posting Failure"
                ErrorReferenceNumber = "QC Hold  # " + strQCNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End If
        End Try

        con.Close()
    End Sub

    Public Sub InsertIntoCostTier(ByVal part As String, ByVal ITCost As Double, ByVal division As String, ByVal ITQuantity As Double)
        'Write Adjustment Data to the Inventory Costing Table
        'Extract the Upper and Lower Limit of the Inventory Costing Table
        Dim NewUpperLimit, LowerLimit As Double
        Dim UpperLimit As Double = 0

        Dim UpperLimitCommand As New SqlCommand("SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID) AND DivisionID = @DivisionID", con)
        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = part
        UpperLimitCommand.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)
        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
        Catch ex As System.Exception
            UpperLimit = 0
        End Try

        If ITQuantity < 0 Then
            LowerLimit = UpperLimit
            NewUpperLimit = LowerLimit + ITQuantity
        Else
            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + ITQuantity - 1
        End If

        'Write Values to Inventory Costing Table
        cmd = New SqlCommand("DECLARE @TransactionNumber as int = (SELECT isnull(MAX(TransactionNumber)+1, 63600001) FROM InventoryCosting); Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

        With cmd.Parameters
            .Add("@PartNumber", SqlDbType.VarChar).Value = part
            .Add("@CostingDate", SqlDbType.Date).Value = Now
            .Add("@ItemCost", SqlDbType.VarChar).Value = ITCost
            .Add("@CostQuantity", SqlDbType.VarChar).Value = ITQuantity
            .Add("@Status", SqlDbType.VarChar).Value = "QC INVENTORY ADJUSTMENT"
            .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
            .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
            .Add("@ReferenceLine", SqlDbType.VarChar).Value = 1
            .Add("@DivisionID", SqlDbType.VarChar).Value = division
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Function GetItemCost(ByVal part As String, ByVal division As String) As Double
        Dim TotalQuantityShipped As Double = 0
        Dim TransactionCost As Double = 0
        Dim MaxCost As Integer = 0
        Dim GetMaxTransactionNumber As Integer = 0
        Dim GetUpperLimit As Double = 0
        Dim FIFOCost As Double = 0
        Dim StandardCost As Double = 0

        '******************************************************************************************************************************************
        'Determine Total Quantity Shipped
        Dim TotalQuantityShippedStatement As String = "SELECT isnull(SUM(QuantityShipped), 0) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship AND LineStatus <> @LineStatus"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = part
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
        TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.Date).Value = Now
        TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"
        TotalQuantityShippedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalQuantityShipped = 0
        End Try

        Dim GetUpperLimitStatement As String = "DECLARE @TransactionNumber as int = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate); SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
        Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
        GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
        GetUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = part
        GetUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.Date).Value = Now

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetUpperLimit = 0
        End Try

        If TotalQuantityShipped = 0 Then
            TotalQuantityShipped = 1
        Else
            TotalQuantityShipped = TotalQuantityShipped + 1
        End If

        If TotalQuantityShipped < GetUpperLimit Then
            'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
            Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
            ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = part
            ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
            ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
            'ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
            Catch ex As System.Exception
                FIFOCost = 0
            End Try
        Else
            FIFOCost = 0
        End If
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            Dim LastPurchaseCost As Double = 0
            Dim MaxDate As Integer = 0

            Dim LastPriceStatement As String = "DECLARE @ReceivingHeaderKey as int = (SELECT isnull(MAX(ReceivingHeaderKey), 0) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber); SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = part

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastPurchaseCost = 0
            End Try

            FIFOCost = LastPurchaseCost
        End If
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            'Load Last Transaction Cost if FIFO = 0
            Dim TransactionCostStatement As String = "DECLARE @MaxCost as int = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID); SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber =  @MaxCost"
            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
            TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = part
            TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
            Catch ex As System.Exception
                TransactionCost = 0
            End Try

            FIFOCost = TransactionCost
        End If
        '*****************************************************************************************************************************************
        'Load Standard Unit Cost if Transaction Cost = 0
        If FIFOCost = 0 Then
            'Select Last Transaction
            Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
            StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
            Catch ex As System.Exception
                StandardCost = 0
            End Try

            FIFOCost = StandardCost
        End If
        If con.State = ConnectionState.Open Then con.Close()
        '*****************************************************************************************************************************************
        Return Math.Round(FIFOCost, 4)
    End Function

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If canPrint() Then
            'Save routine with error logging
            Try
                UPDATEQCHoldTable()
            Catch ex As System.Exception
                'Log error on update failure
                Dim TempQCNumber As Integer = 0
                Dim strQCNumber As String
                TempQCNumber = Val(cboAdjustmentNumber.Text)
                strQCNumber = CStr(TempQCNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "QC Hold Form --- Save Button Update Failure"
                ErrorReferenceNumber = "QC Hold  # " + strQCNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try


            Using NewPrintQCNonconReport As New PrintQCNonconReport(cboAdjustmentNumber.Text)
                Dim Result = NewPrintQCNonconReport.ShowDialog()
            End Using
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must select an adjustment number", "Select an adjustment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdPostEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostEntry.Click
        If canAddAdjustment() Then
            Dim ITGLAccount As String = "12100"
            Dim ITExtendedAmount As Double = 0
            Dim ITCost As Double = 0
            Dim ITQuantity As Double = 0

            'Save routine with error logging
            Try
                UPDATEQCHoldTable()
            Catch ex As System.Exception
                'Log error on update failure
                Dim TempQCNumber As Integer = 0
                Dim strQCNumber As String
                TempQCNumber = Val(cboAdjustmentNumber.Text)
                strQCNumber = CStr(TempQCNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "QC Hold Form --- ON HOLD Update Failure"
                ErrorReferenceNumber = "QC Hold  # " + strQCNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            cmd = New SqlCommand("SELECT DivisionID FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber", con)
            cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim division As String = cmd.ExecuteScalar().ToString()
            If EmployeeCompanyCode.Equals("TST") Then division = "TST"

            If chkAddToInventory.Checked Then
                'Get Item Cost
                ITCost = GetItemCost(cboPartNumber.Text, division)
                ITQuantity = Val(txtAdjustmentQuantity.Text)
                Dim LaborCostPerPiece = 0
                Dim MachineCostPerPiece = 0

                'Add additional cost, if applicable
                If Val(txtReworkHours.Text) <> 0 Then
                    'No additional Cost
                Else
                    Dim AddReworkHours As Double = Val(txtReworkHours.Text)
                    MachineCost = MachineRate * AddReworkHours
                    LaborCost = LaborRate * AddReworkHours
                    If ITQuantity <> 0 Then
                        LaborCostPerPiece = LaborCost / ITQuantity
                        MachineCostPerPiece = MachineCost / ITQuantity
                    End If
                End If

                ITCost = ITCost + MachineCostPerPiece + LaborCostPerPiece

                If ITQuantity < 0 Then ITQuantity = ITQuantity * -1
                ITExtendedAmount = Math.Round(ITQuantity * ITCost, 2)

                'Define other variables
                If division = "TFP" Then ITGLAccount = "12500"

                InsertIntoInventoryTransactionTable(cboPartNumber.Text, cboPartDescription.Text, ITGLAccount, ITCost, division, ITQuantity)
                'Create Inventory Adjustment
                Dim adjustKey As Integer = InsertIntoInventoryAdjustmentTable(cboPartNumber.Text, cboPartDescription.Text, ITGLAccount, ITCost, division, ITQuantity)

                'Create Cost Tier
                InsertIntoCostTier(cboPartNumber.Text, ITCost, division, ITQuantity)

                'Make GL Entry
                Dim GLCreditAccount As String = "12850"
                Dim GLDebitAccount As Double = ITGLAccount
                PostToGeneralLedger(GLDebitAccount, GLCreditAccount, Math.Abs(ITExtendedAmount))

                lblStatus.Text = "CLOSED"

                'Write Adjustment Number to QC Line Table
                cmd = New SqlCommand("INSERT INTO QCHoldAdjustmentLineTable (QCTransactionNumber, AdjustmentLineNumber, AdjustmentDate, InventoryAdjustmentType, InventoryAdjustmentNumber, AdjustmentQuantity, TransferPartNumber, PrintDate) VALUES (@QCTransactionNumber, (SELECT isnull(MAX(AdjustmentLineNumber)+1, 1) FROM QCHoldAdjustmentLineTable WHERE QcTransactionNumber = @QCTransactionNumber), @AdjustmentDate, 'AddToInventory' , @InventoryAdjustmentNumber, @AdjustmentQuantity, 'N/A', @PrintDate)", con)

                With cmd.Parameters
                    .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                    .Add("@InventoryAdjustmentNumber", SqlDbType.VarChar).Value = adjustKey
                    .Add("@Status", SqlDbType.VarChar).Value = lblStatus.Text
                    .Add("@AdjustmentDate", SqlDbType.Date).Value = Now
                    .Add("@AdjustmentQuantity", SqlDbType.Int).Value = Val(txtAdjustmentQuantity.Text)
                    .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf chkRemoveFromInventory.Checked Then

                'Define other variables
                If division.Equals("TFP") Then ITGLAccount = "12500"

                'Define GL Accounts depending on if you scrap or rework the parts
                Dim GLCreditAccount As String = ITGLAccount
                Dim GLDebitAccount As String = "12850"
                If rdoScrap.Checked = True Then
                    GLCreditAccount = ITGLAccount
                    GLDebitAccount = "59500"
                    lblStatus.Text = "CLOSED"
                End If

                'Get Item Cost
                ITCost = GetItemCost(cboPartNumber.Text, division)
                ITQuantity = Val(txtAdjustmentQuantity.Text)

                Dim LaborCostPerPiece As Double = 0
                Dim MachineCostPerPiece As Double = 0
                'Add additional cost, if applicable
                If Val(txtReworkHours.Text) <> 0 Then
                    'No additional Cost
                Else
                    Dim AddReworkHours As Double = Val(txtReworkHours.Text)
                    MachineCost = MachineRate * AddReworkHours
                    LaborCost = LaborRate * AddReworkHours
                    If ITQuantity <> 0 Then
                        LaborCostPerPiece = LaborCost / ITQuantity
                        MachineCostPerPiece = MachineCost / ITQuantity
                    End If
                End If

                ITCost = ITCost + MachineCostPerPiece + LaborCostPerPiece

                If ITQuantity > 0 Then ITQuantity = ITQuantity * -1
                ITExtendedAmount = ITQuantity * ITCost
                ITExtendedAmount = Math.Round(ITExtendedAmount, 2)

                'Write to Inventory Transaction Table
                InsertIntoInventoryTransactionTable(cboPartNumber.Text, cboPartDescription.Text, ITGLAccount, ITCost, division, ITQuantity)

                'Create Inventory Adjustment
                Dim adjustKey As Integer = InsertIntoInventoryAdjustmentTable(cboPartNumber.Text, cboPartDescription.Text, ITGLAccount, ITCost, division, ITQuantity)

                'Create Cost Tier
                InsertIntoCostTier(cboPartNumber.Text, ITCost, division, ITQuantity)

                'Make GL Entry
                If ITExtendedAmount < 0 Then ITExtendedAmount = ITExtendedAmount * -1

                PostToGeneralLedger(GLDebitAccount, GLCreditAccount, Math.Abs(ITExtendedAmount))

                'Write Adjustment Number to QC Line Table
                cmd = New SqlCommand("INSERT INTO QCHoldAdjustmentLineTable (QCTransactionNumber, AdjustmentLineNumber, AdjustmentDate, InventoryAdjustmentType, InventoryAdjustmentNumber, AdjustmentQuantity, TransferPartNumber, PrintDate) VALUES (@QCTransactionNumber, (SELECT isnull(MAX(AdjustmentLineNumber)+1, 1) FROM QCHoldAdjustmentLineTable WHERE QcTransactionNumber = @QCTransactionNumber), @AdjustmentDate, 'RemoveFromInventory' , @InventoryAdjustmentNumber, @AdjustmentQuantity, 'N/A', @PrintDate)", con)

                With cmd.Parameters
                    .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                    .Add("@InventoryAdjustmentNumber", SqlDbType.VarChar).Value = adjustKey
                    .Add("@Status", SqlDbType.VarChar).Value = lblStatus.Text
                    .Add("@AdjustmentDate", SqlDbType.Date).Value = Now
                    .Add("@AdjustmentQuantity", SqlDbType.Int).Value = Val(txtAdjustmentQuantity.Text)
                    .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf chkTransferPart.Checked Then
                'Get Item Cost
                ITCost = GetItemCost(cboPartNumber.Text, division)

                ITQuantity = Val(txtAdjustmentQuantity.Text)
                If ITQuantity > 0 Then ITQuantity = ITQuantity * -1
                ITExtendedAmount = ITQuantity * ITCost
                ITExtendedAmount = Math.Round(ITExtendedAmount, 2)

                'Define other variables
                If division.Equals("TWD") Then
                    ITGLAccount = "12100"
                ElseIf division.Equals("TFP") Then
                    ITGLAccount = "12500"
                End If


                'Write to Inventory Transaction Table
                InsertIntoInventoryTransactionTable(cboPartNumber.Text, cboPartDescription.Text, ITGLAccount, ITCost, division, ITQuantity)

                'Create Inventory Adjustment
                Dim adjust As Integer = InsertIntoInventoryAdjustmentTable(cboPartNumber.Text, cboPartDescription.Text, ITGLAccount, ITCost, division, ITQuantity)

                'Create Cost Tier
                InsertIntoCostTier(cboPartNumber.Text, ITCost, division, ITQuantity)

                If Val(txtReworkHours.Text) = 0 Then
                    'No GL Posting
                Else
                    PostToGeneralLedger("12850", ITGLAccount, Math.Abs(ITExtendedAmount))
                End If
                '******************************************************************************************
                'Transfer details for part number 2
                ITQuantity = Math.Abs(ITQuantity)
                Dim LaborCostPerPiece As Double = 0
                Dim MachineCostPerPiece As Double = 0
                'Add additional cost, if applicable
                If Val(txtReworkHours.Text) <> 0 Then
                    'No additional Cost
                Else
                    Dim AddReworkHours As Double = Val(txtReworkHours.Text)
                    MachineCost = MachineRate * AddReworkHours
                    LaborCost = LaborRate * AddReworkHours
                    If ITQuantity <> 0 Then
                        LaborCostPerPiece = LaborCost / ITQuantity
                        MachineCostPerPiece = MachineCost / ITQuantity
                    End If
                End If

                ITCost = ITCost + MachineCostPerPiece + LaborCostPerPiece

                ITExtendedAmount = ITQuantity * ITCost
                ITExtendedAmount = Math.Round(ITExtendedAmount, 2)

                'Define other variables
                If division.Equals("TWD") Then
                    ITGLAccount = "12100"
                ElseIf division.Equals("TFP") Then
                    ITGLAccount = "12500"
                End If

                'Get Transfer Part Description
                Dim LongDescriptionStatement As String = "IF EXISTS(SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID) SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID ELSE SELECT TOP 1 ShortDescription FROM ItemList WHERE ItemID = @ItemID"
                Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
                LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtTransferPart.Text
                LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division

                Dim ITPartDescription As String = ""
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ITPartDescription = CStr(LongDescriptionCommand.ExecuteScalar)
                Catch ex As System.Exception
                    ITPartDescription = ""
                End Try
                con.Close()

                'Write to Inventory Transaction Table
                InsertIntoInventoryTransactionTable(txtTransferPart.Text, ITPartDescription, ITGLAccount, ITCost, division, ITQuantity)

                'Create Inventory Adjustment
                adjust = InsertIntoInventoryAdjustmentTable(txtTransferPart.Text, ITPartDescription, ITGLAccount, ITCost, division, ITQuantity)

                'Create Cost Tier
                InsertIntoCostTier(txtTransferPart.Text, ITCost, division, ITQuantity)

                If Val(txtReworkHours.Text) = 0 Then
                    'No GL Posting
                Else
                    PostToGeneralLedger(ITGLAccount, "12850", Math.Abs(ITExtendedAmount))
                End If

                'Write Data to Inventory Adjustment Header Database Table
                cmd = New SqlCommand("DECLARE @LineNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(AdjustmentLineNumber)+1, 1) FROM QCHoldAdjustmentLineTable WHERE QcTransactionNumber = @QCTransactionNumber) THEN (SELECT isnull(MAX(AdjustmentLineNumber)+1, 1) FROM QCHoldAdjustmentLineTable WHERE QcTransactionNumber = @QCTransactionNumber) ELSE (SELECT 1) END; " _
                                      + "INSERT INTO QCHoldAdjustmentLineTable (QCTransactionNumber, AdjustmentLineNumber, AdjustmentDate, InventoryAdjustmentType, InventoryAdjustmentNumber, AdjustmentQuantity, TransferPartNumber, PrintDate)" _
                                      + " VALUES (@QCTransactionNumber, @LineNumber, @AdjustmentDate, 'TransferPartRemoval' , @InventoryAdjustmentNumber, @AdjustmentQuantity, 'N\A', CURRENT_TIMESTAMP)" _
                                      + " , (@QCTransactionNumber, @LineNumber + 1, @AdjustmentDate, 'TransferPartAddition' , @InventoryAdjustmentNumber, @AdjustmentQuantity, @TransferPartNumber, @PrintDate)", con)

                With cmd.Parameters
                    .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                    .Add("@InventoryAdjustmentNumber", SqlDbType.VarChar).Value = adjust
                    .Add("@AdjustmentDate", SqlDbType.Date).Value = Now
                    .Add("@AdjustmentQuantity", SqlDbType.Int).Value = Val(txtAdjustmentQuantity.Text)
                    .Add("@TransferPartNumber", SqlDbType.VarChar).Value = txtTransferPart.Text
                    .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf chkDoNothing.Checked Then
                'Write Data to Inventory Adjustment Header Database Table
                cmd = New SqlCommand("INSERT INTO QCHoldAdjustmentLineTable (QCTransactionNumber, AdjustmentLineNumber, AdjustmentDate, InventoryAdjustmentType, TransferPartNumber) VALUES (@QCTransactionNumber, (SELECT isnull(MAX(AdjustmentLineNumber)+1, 1) FROM QCHoldAdjustmentLineTable WHERE QcTransactionNumber = @QCTransactionNumber), @AdjustmentDate, 'DoNothing', 'N/A')", con)

                With cmd.Parameters
                    .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = lblStatus.Text
                    .Add("@AdjustmentDate", SqlDbType.Date).Value = Now
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                MsgBox("You must choose an Inventory Action.", MsgBoxStyle.OkOnly)
            End If

            'Load Status
            LoadStatus()
            ShowAdjustmentLines()
            chkAddToInventory.Checked = False
            chkDoNothing.Checked = False
            chkRemoveFromInventory.Checked = False
            chkTransferPart.Checked = False
            txtAdjustmentQuantity.Text = ""
        End If

    End Sub

    Private Function canAddAdjustment() As Boolean

        If chkAddToInventory.Checked Or chkRemoveFromInventory.Checked Or chkTransferPart.Checked Then
            If String.IsNullOrEmpty(cboPartNumber.Text) Then
                MessageBox.Show("You must enter an part number", "Enter a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboPartNumber.Focus()
                Return False
            End If
            If cboPartNumber.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid part number", "Enter a valid part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboPartNumber.SelectAll()
                cboPartNumber.Focus()
                Return False
            End If
            If chkTransferPart.Checked Then
                If String.IsNullOrEmpty(txtTransferPart.Text) Then
                    MessageBox.Show("You must enter a part number to transfer quantity", "Enter a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    tabCtrl.TabPages("tabAdjustments").Show()
                    txtTransferPart.Focus()
                    Return False
                End If
                If Not PartSuggest.Contains(txtTransferPart.Text) Then
                    MessageBox.Show("You must enter a valid part number", "Enter a valid part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    tabCtrl.TabPages("tabAdjustments").Show()
                    txtTransferPart.SelectAll()
                    txtTransferPart.Focus()
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(txtAdjustmentQuantity.Text) Then
                MessageBox.Show("You must enter an adjustment Quantity", "Enter and adjustment quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tabCtrl.TabPages("tabAdjustments").Show()
                txtAdjustmentQuantity.Focus()
                Return False
            End If
            If Val(txtAdjustmentQuantity.Text) = 0 Then
                MessageBox.Show("You must enter an adjustment quantity greater than 0", "Enter a value greater than 0", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tabCtrl.TabPages("tabAdjustments").Show()
                txtAdjustmentQuantity.SelectAll()
                txtAdjustmentQuantity.Focus()
                Return False
            End If
        Else
            If Not chkDoNothing.Checked Then
                MessageBox.Show("You must select an inventory action to perform.", "Select an inventory action", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tabCtrl.TabPages("tabAdjustments").Show()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmdCloseEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseEntry.Click
        If canCloseEntry() Then
            Try
                cmd = New SqlCommand("UPDATE QCHoldAdjustment SET Status = @Status WHERE QCTransactionNumber = @QCTransactionNumber", con)

                With cmd.Parameters
                    .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("QC Record has been closed.", MsgBoxStyle.OkOnly)

                lblStatus.Text = "CLOSED"
                SetControls()
            Catch ex As System.Exception
                'Error Log
                Dim TempQCNumber As Integer = 0
                Dim strQCNumber As String
                TempQCNumber = Val(cboAdjustmentNumber.Text)
                strQCNumber = CStr(TempQCNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "QC Hold Form --- Close Button Failure"
                ErrorReferenceNumber = "QC Hold  # " + strQCNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Function canCloseEntry() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must select an adjustment number", "Select and adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        LoadStatus()
        If lblStatus.Text.Equals("CLOSED") Then
            MessageBox.Show("QC hold is already closed", " QC hold already closed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cmdQCRacking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQCRacking.Click
        GlobalDivisionCode = EmployeeCompanyCode
        GlobalQCTransactionNumber = Val(cboAdjustmentNumber.Text)

        Using NewQCAddToRack As New QCNonConformanceRackingAddToRacking()
            Dim Result = NewQCAddToRack.ShowDialog()
        End Using
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDelete() Then
            cmd = New SqlCommand("DELETE FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber", con)
            cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
            Dim nonConformanceNumber As String = cboAdjustmentNumber.Text
            Try

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("QC Data has been deleted.", MsgBoxStyle.OkOnly)

                ClearData()
                LoadQCAdjustmentNumber()
            Catch ex As System.Exception
                'Error Log
                Dim TempQCNumber As Integer = 0
                Dim strQCNumber As String
                TempQCNumber = Val(cboAdjustmentNumber.Text)
                strQCNumber = CStr(TempQCNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "QC Hold Form --- Delete Button Failure"
                ErrorReferenceNumber = "QC Hold  # " + strQCNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
                Exit Sub
            End Try
            ''tries to delete the directory that has the pictures in it.
            Try
                If System.IO.Directory.Exists(NonConformanceRootFolder + "\" + nonConformanceNumber) Then
                    System.IO.Directory.Delete(NonConformanceRootFolder + "\" + nonConformanceNumber, True)
                End If
            Catch ex As System.Exception
                sendErrorToDataBase("QCInvnetoryAdjustment - cmdDelete --Error trying to delete picture directory", "nonConformance #" + nonConformanceNumber, ex.ToString())
            End Try
        End If
    End Sub

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must enter an adjustment number", "Enter an adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        LoadStatus()
        If Not lblStatus.Text.Equals("OPEN") Then
            MessageBox.Show("QC hold not in a state that can be deleted.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        cmd = New SqlCommand("SELECT COUNT(AdjustmentLineNumber) FROM QCHoldAdjustmentLineTable WHERE QCTransactionNumber = @QCTransactionNumber AND InventoryAdjustmentType <> 'DoNothing'", con)
        cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
            con.Close()
            MessageBox.Show("Unable to delete QC hold because there are adjustments associated to it.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        con.Close()
        If MessageBox.Show("Are you sure you wish to delete the Non-Conformance?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            'Save routine with error logging
            Try
                UPDATEQCHoldTable()
            Catch ex As System.Exception
                'Log error on update failure
                Dim TempQCNumber As Integer = 0
                Dim strQCNumber As String
                TempQCNumber = Val(cboAdjustmentNumber.Text)
                strQCNumber = CStr(TempQCNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "QC Hold Form --- Save Button Update Failure"
                ErrorReferenceNumber = "QC Hold  # " + strQCNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must enter an adjustment number", "Enter an adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        LoadStatus()
        If lblStatus.Text.Equals("CLOSED") Then
            MessageBox.Show("QC hold not in a state that can be saved", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cboAdjustmentNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdjustmentNumber.SelectedIndexChanged
        If isloaded Then
            LoadQCHoldData()
            LoadLotNumbers()
            ShowAdjustmentLines()
            LoadPictures()
        End If
    End Sub

    Private Sub ManuallyReOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyReOpenToolStripMenuItem.Click
        If canManuallyReOpen() Then
            Try
                cmd = New SqlCommand("UPDATE QCHoldAdjustment SET Status = @Status WHERE QCTransactionNumber = @QCTransactionNumber", con)

                With cmd.Parameters
                    .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("QC Data has now been re-opened.", MsgBoxStyle.OkOnly)

                lblStatus.Text = "OPEN"
            Catch ex As System.Exception
                'Error Log
                Dim TempQCNumber As Integer = 0
                Dim strQCNumber As String
                TempQCNumber = Val(cboAdjustmentNumber.Text)
                strQCNumber = CStr(TempQCNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = EmployeeCompanyCode
                ErrorDescription = "QC Hold Form --- Re-Open Failure"
                ErrorReferenceNumber = "QC Hold  # " + strQCNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
        'Load Status
        LoadStatus()
    End Sub

    Private Function canManuallyReOpen() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must select an adjustment number", "Select an adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        LoadStatus()
        If Not lblStatus.Text.Equals("CLOSED") Then
            MessageBox.Show("QC hold is not closed.", "QC hold is not closed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click, ClearToolStripMenuItem.Click
        ClearData()
        SetControls()
        SetPictureButtons()
        SetScrollBars()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalQCTransactionNumber = 0
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalQCTransactionNumber = 0
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLot.Click
        If canAddLot() Then
            AddLotControl.SetPNC(Val(cboAdjustmentNumber.Text))
            AddLotControl.Show()
            AddLotControl.txtlotNumber.Focus()
        End If
    End Sub

    Public Function canAddLot() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must select an adjustmetn number", "Select an adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        LoadStatus()
        If Not lblStatus.Text.Equals("OPEN") Then
            MessageBox.Show("QC Hold is not in a state where a lot number cna be added.", "Unable to add lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub AddLotNumber_Visibility_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If AddLotControl.Visible Then
            Me.Enabled = False
        Else
            Me.Enabled = True
            Me.BringToFront()
            LoadLotNumbers()
            If dgvLotNumbers.Rows.Count > 0 Then
                cmd = New SqlCommand("SELECT FOXNumber, PartNumber FROM LotNumber WHERE LotNumber = (SELECT TOP 1 LotNumber FROM QCHoldAdjustmentLotNumber WHERE QCTransactionNumber = @QCTransactionNumber)", con)
                cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If Not reader.IsDBNull(0) Then
                        txtFOXNumber.Text = reader.Item("FOXNumber").ToString()
                    End If
                    If Not reader.IsDBNull(1) Then
                        Dim part As String = reader.Item("Partnumber")
                        reader.Close()
                        cboPartNumber.Text = part
                    End If
                End If
                If Not reader.IsClosed() Then
                    reader.Close()
                End If
                con.Close()
            End If

        End If
    End Sub

    Private Sub QCInventoryAdjustment_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Not Me.Enabled Then
            Me.BringToFront()
            AddLotControl.BringToFront()
        End If
    End Sub

    Private Sub LoadLotNumbers()
        If dgvLotNumbers.Rows.Count > 0 Then
            dgvLotNumbers.Rows.Clear()
        End If
        cmd = New SqlCommand("SELECT LotNumber FROM QCHoldAdjustmentLotNumber WHERE QCTransactionNumber = @QCTransactionNumber", con)
        cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    dgvLotNumbers.Rows.Add(reader.Item("LotNumber"))
                End If
            End While
        End If
        reader.Close()
        con.Close()
        If dgvLotNumbers.Rows.Count > 0 Then
            If lblStatus.Text.Equals("CLOSED") Then
                cmdDeleteLot.Enabled = False
            Else
                cmdDeleteLot.Enabled = True
            End If

            txtFOXNumber.Enabled = False
            If String.IsNullOrEmpty(cboPartNumber.Text) Then
                GetPartNumber()
            End If
            cboPartNumber.Enabled = False
            cboPartDescription.Enabled = False
        Else
            cmdDeleteLot.Enabled = False
            txtFOXNumber.Enabled = True
            cboPartNumber.Enabled = True
            cboPartDescription.Enabled = True
        End If
    End Sub

    Private Sub ShowAdjustmentLines()
        cmd = New SqlCommand("SELECT AdjustmentLineNumber, AdjustmentDate, InventoryAdjustmentType, InventoryAdjustmentNumber, AdjustmentQuantity, TransferPartNumber FROM QCHoldAdjustmentLineTable WHERE QCTransactionNumber = @QCTransactionNumber ORDER BY AdjustmentLineNumber", con)
        cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)
        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "QCHoldAdjustmentLineTable")
        con.Close()

        dgvAdjustmentLines.DataSource = tempds.Tables("QCHoldAdjustmentLineTable")
        dgvAdjustmentLines.Columns("AdjustmentLineNumber").HeaderText = "Entry Number"
        dgvAdjustmentLines.Columns("AdjustmentDate").HeaderText = "Date"
        dgvAdjustmentLines.Columns("InventoryAdjustmentType").HeaderText = "Adjustment Type"
        dgvAdjustmentLines.Columns("InventoryAdjustmentType").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvAdjustmentLines.Columns("InventoryAdjustmentNumber").HeaderText = "Inventory Adjustment #"
        dgvAdjustmentLines.Columns("AdjustmentQuantity").HeaderText = "Quantity"
        dgvAdjustmentLines.Columns("TransferPartNumber").HeaderText = "New Part Number"
        dgvAdjustmentLines.Columns("TransferPartNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If dgvAdjustmentLines.Rows.Count > 0 Then
            txtFOXNumber.Enabled = False
            cboPartNumber.Enabled = False
            cboPartDescription.Enabled = False
        End If
    End Sub

    Private Sub cmdDeleteLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLot.Click
        If canDeleteLot() Then
            cmd = New SqlCommand("DELETE QCHoldAdjustmentLotNumber WHERE QCTransactionNumber = @QCTransactionNumber AND LotNumber = @LotNumber", con)
            cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(cboAdjustmentNumber.Text)
            cmd.Parameters.Add("@LotNumber", SqlDbType.Int).Value = dgvLotNumbers.Rows(dgvLotNumbers.SelectedCells(0).RowIndex).Cells("LotNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            LoadLotNumbers()
            If con.State = ConnectionState.Open Then con.Close()
        End If
    End Sub

    Private Function canDeleteLot() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must enter an adjustment number", "Enter an adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvLotNumbers.SelectedCells.Count = 0 Then
            MessageBox.Show("You must select a lot to delete.", "Select a lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        LoadStatus()
        If Not lblStatus.Text.Equals("OPEN") Then
            MessageBox.Show("QC hold is not in a state where a lot can be deleted.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub txtAdjustmentQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdjustmentQuantity.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtFOXNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFOXNumber.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtReworkHours_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReworkHours.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> "."c Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtFOXNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFOXNumber.Leave
        If String.IsNullOrEmpty(cboPartNumber.Text) And txtFOXNumber.Text.Length > 3 Then
            GetPartNumber()
        End If
    End Sub

    Private Sub GetPartNumber()
        cmd = New SqlCommand("SELECT PartNumber FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(txtFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If Not IsDBNull(obj) And obj IsNot Nothing Then
            cboPartNumber.Text = obj
        End If
    End Sub

    Private Sub cboAdjustmentNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAdjustmentNumber.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub cmdAddPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddPicture.Click
        Dim fileSelect As New OpenFileDialog()
        fileSelect.Multiselect = True
        fileSelect.Filter = "Image Files (*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png)|*.bmp;*.jpg;*.gif*.jpeg;*.tiff;*.png"
        fileSelect.FilterIndex = 1

        If fileSelect.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ''check to make sure the blueprint journal directory exists if it doesn't this wil lcreate it
            If Not System.IO.Directory.Exists(NonConformanceRootFolder) Then
                System.IO.Directory.CreateDirectory(NonConformanceRootFolder)
            End If
            ''chekc to see if the directory for the blueprint exists, if not will create
            If Not System.IO.Directory.Exists(NonConformanceRootFolder + "\" + cboAdjustmentNumber.Text) Then
                System.IO.Directory.CreateDirectory(NonConformanceRootFolder + "\" + cboAdjustmentNumber.Text)
            End If
            For Each fileName As String In fileSelect.FileNames
                ''check to see if the file already exists, if it does will ask the user if they want to overwrite.
                If System.IO.File.Exists(NonConformanceRootFolder + "\" + cboAdjustmentNumber.Text + "\" + fileName.Substring(fileName.LastIndexOf("\") + 1)) Then
                    If MessageBox.Show("File " + fileName.Substring(fileName.LastIndexOf("\") + 1) + " exists, do you wish to overwrite it?", "Overwrite existing file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                        System.IO.File.Copy(fileName, NonConformanceRootFolder + "\" + cboAdjustmentNumber.Text + "\" + fileName.Substring(fileName.LastIndexOf("\") + 1), True)
                    End If
                Else
                    System.IO.File.Copy(fileName, NonConformanceRootFolder + "\" + cboAdjustmentNumber.Text + "\" + fileName.Substring(fileName.LastIndexOf("\") + 1))
                End If
            Next
            LoadPictures()
        End If
    End Sub

    Private Sub DisposePictureShown()
        If picbxSelectedPicture.Image IsNot Nothing Then
            picbxSelectedPicture.Image.Dispose()
            picbxSelectedPicture.Image = Nothing
        End If
    End Sub

    Private Sub LoadPictures()
        DisposePictureShown()
        dgvPictures.Rows.Clear()
        ''Gets the directory info for the root directory of blueprint journal directories
        Dim dir As New System.IO.DirectoryInfo(NonConformanceRootFolder)

        Dim RecordDir() As System.IO.DirectoryInfo = dir.GetDirectories(cboAdjustmentNumber.Text, IO.SearchOption.TopDirectoryOnly)
        If RecordDir.Count > 0 Then
            Dim foundFileInfo As New List(Of System.IO.FileInfo)
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.jpg"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.bmp"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.gif"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.jpeg"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.png"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.tiff"))
            foundFileInfo.Sort(Function(x As System.IO.FileInfo, y As System.IO.FileInfo) x.LastWriteTime < y.LastWriteTime)

            isLoaded = False
            ''Loads all the pictures into the DGV
            For Each fle As System.IO.FileInfo In foundFileInfo
                Dim picCell As New DataGridViewImageCell()

                Dim tmpImg As picData
                Using Str As System.IO.Stream = System.IO.File.OpenRead(fle.FullName)
                    tmpImg = New picData(Image.FromStream(Str), fle.FullName)
                End Using
                picCell.Value = tmpImg.img.GetThumbnailImage(150, 150, Nothing, IntPtr.Zero)
                picCell.Tag = tmpImg
                dgvPictures.Rows.Add()
                dgvPictures.Rows(dgvPictures.Rows.Count - 1).Height = 150
                dgvPictures.Rows(dgvPictures.Rows.Count - 1).Cells(0) = picCell
            Next
            isLoaded = True

            ''Selects the first picture if there is one
            If dgvPictures.Rows.Count > 0 Then
                dgvPictures.CurrentCell = dgvPictures.Rows(0).Cells(0)
                dgvPictures.Rows(0).Cells(0).Selected = True
                Dim tmpImg As Image = DirectCast(dgvPictures.Rows(0).Cells(0).Tag, picData).img.Clone()
                Dim resizeHeightPercent As Double = 1
                If tmpImg.Height > picbxSelectedPicture.Height Then
                    resizeHeightPercent = picbxSelectedPicture.Height / tmpImg.Height
                End If
                picbxSelectedPicture.Image = tmpImg.GetThumbnailImage(resizeHeightPercent * tmpImg.Width, resizeHeightPercent * tmpImg.Height, Nothing, IntPtr.Zero)
            Else
                picbxSelectedPicture.Image = Nothing
            End If
        End If
        SetPictureButtons()
        SetScrollBars()
    End Sub

    Private Sub SetPictureButtons()
        If dgvPictures.Rows.Count > 0 Then
            If lblStatus.Text.Equals("OPEN") Then
                cmdDeletePicture.Enabled = True
                cmdAddPicture.Enabled = True
            Else
                cmdDeletePicture.Enabled = False
                cmdAddPicture.Enabled = False
            End If
            cmdPrintPicture.Enabled = True
            cmdFullScreenPicture.Enabled = True
        Else
            If lblStatus.Text.Equals("OPEN") Then
                cmdAddPicture.Enabled = True
            Else
                cmdAddPicture.Enabled = False
            End If

            cmdDeletePicture.Enabled = False
            cmdPrintPicture.Enabled = False
            cmdFullScreenPicture.Enabled = False
        End If
    End Sub

    Private Sub SetScrollBars()
        If picbxSelectedPicture.Image IsNot Nothing Then
            ''checks the width of the current picture and will adjust the scroll bar accordingly
            If picbxSelectedPicture.Image.Width > picbxSelectedPicture.Width Then
                hscrlPicture.Maximum = picbxSelectedPicture.Image.Width - picbxSelectedPicture.Width
                hscrlPicture.Enabled = True
            Else
                hscrlPicture.Maximum = 0
                hscrlPicture.Enabled = False
            End If
            ''checks the height of the current picture and will adjust the scroll bar accordingly
            If picbxSelectedPicture.Image.Height > picbxSelectedPicture.Height Then
                vscrlPicture.Maximum = picbxSelectedPicture.Image.Height - picbxSelectedPicture.Height
                vscrlPicture.Enabled = True
            Else
                vscrlPicture.Maximum = 0
                vscrlPicture.Enabled = False
            End If
        Else
            hscrlPicture.Maximum = 0
            hscrlPicture.Enabled = False
            vscrlPicture.Maximum = 0
            vscrlPicture.Enabled = False
        End If

    End Sub

    Private Sub dgvPictures_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPictures.CellEnter
        If isLoaded Then
            DisposePictureShown()
            If e.RowIndex <> -1 Then
                Dim tmpImg As Image = DirectCast(dgvPictures.Rows(dgvPictures.CurrentCell.RowIndex).Cells(0).Tag, picData).img.Clone()
                Dim resizeHeightPercent As Double = 1
                If tmpImg.Height > picbxSelectedPicture.Height Then
                    resizeHeightPercent = picbxSelectedPicture.Height / tmpImg.Height
                End If
                picbxSelectedPicture.Image = tmpImg.GetThumbnailImage(resizeHeightPercent * tmpImg.Width, resizeHeightPercent * tmpImg.Height, Nothing, IntPtr.Zero)
            Else
                picbxSelectedPicture.Image = Nothing
            End If
            SetPictureButtons()
            SetScrollBars()
        End If
    End Sub

    Private Sub HandleScroll(ByVal sender As System.Object, ByVal e As ScrollEventArgs) Handles hscrlPicture.Scroll, vscrlPicture.Scroll
        If picbxSelectedPicture.Image IsNot Nothing Then
            Dim graps As Graphics = picbxSelectedPicture.CreateGraphics()

            Dim picbxWidth As Integer = picbxSelectedPicture.Width
            Dim picbxHeight As Integer = picbxSelectedPicture.Height

            Dim x As Integer
            Dim y As Integer
            ''check to see how the user scrolled
            If (e.ScrollOrientation = ScrollOrientation.HorizontalScroll) Then
                x = e.NewValue
                y = vscrlPicture.Value
            Else
                x = hscrlPicture.Value
                y = e.NewValue
            End If
            ''redraws the image *I think it just draws the image on the image that was already there without clearing the draw space
            graps.DrawImage(picbxSelectedPicture.Image, New System.Drawing.Rectangle(0, 0, picbxWidth, picbxHeight), New System.Drawing.Rectangle(x, y, picbxWidth, picbxHeight), GraphicsUnit.Pixel)

            picbxSelectedPicture.Update()
        End If
    End Sub

    Private Sub cmdDeletePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePicture.Click
        If canDeletePicture() Then
            Dim FileName As String = CType(dgvPictures.CurrentCell.Tag, picData).FileName
            dgvPictures.Rows.Clear()
            picbxSelectedPicture.Image.Dispose()
            picbxSelectedPicture.Image = Nothing

            Try
                System.IO.File.Delete(FileName)
            Catch ex As System.Exception
                sendErrorToDataBase("QCInventoryAdjustment - cmdDeletePicture_Click --Error trying to delete file", FileName, ex.ToString())
            End Try
            LoadPictures()
        End If
    End Sub

    Private Function canDeletePicture() As Boolean
        If dgvPictures.SelectedCells.Count = 0 Then
            MessageBox.Show("You must select an image to print.", "Select an image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to delete this image?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
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

    Private Sub cmdPrintPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPicture.Click
        Dim pd As New PrintDialog()
        Dim doc As New System.Drawing.Printing.PrintDocument()
        pd.UseEXDialog = True
        pd.Document = doc
        ''opens the print dialog and if the user hits print will print the image
        If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AddHandler doc.PrintPage, AddressOf PrintPictureDocument_PrintPage
            doc.Print()
        End If
    End Sub

    Private Function CanPrintJournalImage() As Boolean
        If picbxSelectedPicture.Image Is Nothing Then
            MessageBox.Show("There is no image selected to print", "Select an image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintPictureDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim xbound As Integer = e.Graphics.VisibleClipBounds.Width
        Dim ybound As Integer = e.Graphics.VisibleClipBounds.Height

        ''checks to see which bound is smaller and will use the smaller bound for the image for width
        If picbxSelectedPicture.Image.Width < e.Graphics.VisibleClipBounds.Width Then
            xbound = picbxSelectedPicture.Image.Width
        End If
        ''checks to see which bound is smaller and will use the smaller bound for the image for height
        If picbxSelectedPicture.Image.Height < e.Graphics.VisibleClipBounds.Height Then
            ybound = picbxSelectedPicture.Image.Height
        End If
        ''draws the image on the document being printed
        e.Graphics.DrawImage(picbxSelectedPicture.Image, New System.Drawing.Rectangle(0, 0, xbound, ybound))
    End Sub

    Private Sub cmdFullScreenPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFullScreenPicture.Click
        FullScreenForm = New ViewPictureFullScreen(picbxSelectedPicture.Image)
        FullScreenForm.Show()
    End Sub

    Private Sub QCInventoryAdjustment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If FullScreenForm IsNot Nothing Then
            If FullScreenForm.picbxFullScreenPicture.Image IsNot Nothing Then
                FullScreenForm.picbxFullScreenPicture.Image.Dispose()
            End If
            FullScreenForm.Close()
        End If
    End Sub

    Private Sub picbxSelectedPicture_MouseWheel(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picbxSelectedPicture.MouseWheel
        If vscrlPicture.Enabled Then
            ''check to see if the user scrolled up or down
            If e.Delta > 0 Then
                ''check to see if we will be going below 0 when changing the vertical scroll value
                If vscrlPicture.Value > 0 Then
                    If vscrlPicture.Value - 5 < 0 Then
                        vscrlPicture.Value = 0
                    Else
                        vscrlPicture.Value -= 5
                    End If
                End If
            Else
                ''check to see if we will be going above the scroll max when changing the vertical scroll value
                If vscrlPicture.Value < vscrlPicture.Maximum Then
                    If vscrlPicture.Value + 5 > vscrlPicture.Maximum Then
                        vscrlPicture.Value = vscrlPicture.Maximum
                    Else
                        vscrlPicture.Value += 5
                    End If

                End If
            End If
            Dim graps As Graphics = picbxSelectedPicture.CreateGraphics()

            Dim picbxWidth As Integer = picbxSelectedPicture.Width
            Dim picbxHeight As Integer = picbxSelectedPicture.Height

            Dim x As Integer = hscrlPicture.Value
            Dim y As Integer = vscrlPicture.Value
            ''redraws the image *I think it just draws the image on the image that was already there without clearing the draw space
            graps.DrawImage(picbxSelectedPicture.Image, New System.Drawing.Rectangle(0, 0, picbxWidth, picbxHeight), New System.Drawing.Rectangle(x, y, picbxWidth, picbxHeight), GraphicsUnit.Pixel)

            picbxSelectedPicture.Update()
        End If
    End Sub

    Private Sub picbxSelectedPicture_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picbxSelectedPicture.Resize
        vscrlPicture.Value = 0
        hscrlPicture.Value = 0
        SetScrollBars()
    End Sub

    Private Sub QCNonConformance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class