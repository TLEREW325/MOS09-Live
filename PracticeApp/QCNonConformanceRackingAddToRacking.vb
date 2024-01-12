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
Public Class QCNonConformanceRackingAddToRacking
    Inherits System.Windows.Forms.Form

    Dim PiecesPerBox, NumberOfBoxes, TotalPieces, TotalWeight, PieceWeight As Double
    Dim HoldReason As String = ""
    Dim PartNumber, PartDescription As String
    Dim FOXNumber As String = 0
    Dim LOtNumberDivisionID As String = ""

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
    Dim dt As DataTable

    Private Sub QCNonConformanceRackingAddToRacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBinLocations()
        LoadPNCNumber()

        If GlobalQCTransactionNumber > 0 Then
            cboPNCNumber.Text = GlobalQCTransactionNumber
        Else
            cboPNCNumber.SelectedIndex = -1
            ClearFields()
        End If
    End Sub

    Private Sub LoadPNCNumber()
        cmd = New SqlCommand("SELECT QCTransactionNumber FROM QCHoldAdjustment WHERE Status = @Status ORDER BY QCTransactionNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "QCHoldAdjustment")
        cboPNCNumber.DataSource = ds.Tables("QCHoldAdjustment")
        con.Close()
        cboPNCNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadBinLocations()
        cmd = New SqlCommand("SELECT BinNumber FROM BinNumber WHERE DivisionID = @DivisionID AND (BinNumber BETWEEN 'AB100' AND 'AB130' OR BinNumber BETWEEN 'QC001' AND 'QC030') ORDER BY BinNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "BinNumber")
        cboBinNumber.DataSource = ds1.Tables("BinNumber")
        con.Close()
        cboBinNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadLotNumbers()
        cmd = New SqlCommand("SELECT LotNumber FROM QCHoldAdjustmentLotNumber WHERE QCTransactionNumber = @QCTransactionNumber ORDER BY LotNumber", con)
        cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboPNCNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "QCHoldAdjustmentLotNumber")
        cboLotNumber.DataSource = ds2.Tables("QCHoldAdjustmentLotNumber")
        con.Close()
        cboLotNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadLotNumberData()
        Dim GetLotDataStatement As String = "SELECT * FROM LotNUmber WHERE LotNumber = @LotNumber"
        Dim GetLotDataCommand As New SqlCommand(GetLotDataStatement, con)
        GetLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                PartDescription = ""
            Else
                PartDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                PieceWeight = 0
            Else
                PieceWeight = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                PiecesPerBox = 0
            Else
                PiecesPerBox = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = 0
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                LOtNumberDivisionID = "TWD"
            Else
                LOtNumberDivisionID = reader.Item("DivisionID")
            End If
        Else
            PartNumber = ""
            PartDescription = ""
            PieceWeight = 0
            PiecesPerBox = 0
            FOXNumber = 0
            LOtNumberDivisionID = "TWD"
        End If
        reader.Close()
        con.Close()

        txtPiecesPerBox.Text = PiecesPerBox
        lblFOXNumber.Text = FOXNumber
        lblPartNumber.Text = PartNumber
        lblPartDescription.Text = PartDescription

        'Calculate total weight and number of pieces
        TotalPieces = PiecesPerBox * Val(txtBoxQuantity.Text)
        txtTotalPieces.Text = Math.Round(TotalPieces, 0)

        TotalWeight = PieceWeight * TotalPieces
        txtTotalWeight.Text = Math.Round(TotalWeight, 0)
    End Sub

    Private Sub txtPiecesPerBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiecesPerBox.TextChanged
        'Calculate total weight and number of pieces
        TotalPieces = PiecesPerBox * Val(txtBoxQuantity.Text)
        txtTotalPieces.Text = Math.Round(TotalPieces, 0)

        TotalWeight = PieceWeight * TotalPieces
        txtTotalWeight.Text = Math.Round(TotalWeight, 0)
    End Sub

    Private Sub txtBoxQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxQuantity.TextChanged
        'Calculate total weight and number of pieces
        TotalPieces = PiecesPerBox * Val(txtBoxQuantity.Text)
        txtTotalPieces.Text = Math.Round(TotalPieces, 0)

        TotalWeight = PieceWeight * TotalPieces
        txtTotalWeight.Text = Math.Round(TotalWeight, 0)
    End Sub

    Private Sub cboPNCNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPNCNumber.SelectedIndexChanged
        LoadLotNumbers()
        LoadHoldReason()
    End Sub

    Private Sub cboPNCNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPNCNumber.TextChanged
        LoadLotNumbers()
        LoadHoldReason()
    End Sub

    Public Sub ClearFields()
        cboBinNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboPNCNumber.SelectedIndex = -1

        txtBoxQuantity.Clear()
        txtHoldReason.Clear()
        txtPiecesPerBox.Clear()
        txtTotalPieces.Clear()
        txtTotalWeight.Clear()

        lblFOXNumber.Text = ""
        lblPartDescription.Text = ""
        lblPartNumber.Text = ""

        cboPNCNumber.Focus()
    End Sub

    Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
        LoadLotNumberData()
    End Sub

    Private Sub cmdAddToRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRack.Click
        'Validate fields
        If cboBinNumber.Text = "" Then
            MsgBox("You must select a rack.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboBinNumber.Focus()
        End If
        If cboPNCNumber.Text = "" Then
            MsgBox("You must select a transaction number.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboPNCNumber.Focus()
        End If
        If cboLotNumber.Text = "" Then
            MsgBox("You must select a Lot Number.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboLotNumber.Focus()
        End If

        If txtBoxQuantity.Text = "" Or Val(txtBoxQuantity.Text) = 0 Then
            MsgBox("You must enter # of boxes.", MsgBoxStyle.OkOnly)
            Exit Sub
            txtBoxQuantity.Focus()
        End If
        If txtPiecesPerBox.Text = "" Or Val(txtPiecesPerBox.Text) = 0 Then
            MsgBox("You must enter pieces per box.", MsgBoxStyle.OkOnly)
            Exit Sub
            txtPiecesPerBox.Focus()
        End If

        If txtTotalPieces.Text = "" Or Val(txtTotalPieces.Text) = 0 Then
            'Re-Calculate Total Pieces
            TotalPieces = PiecesPerBox * Val(txtBoxQuantity.Text)
            txtTotalPieces.Text = Math.Round(TotalPieces, 0)
        End If
        If txtTotalWeight.Text = "" Or Val(txtTotalWeight.Text) = 0 Then
            'Re-Calculate Total Weight
            TotalWeight = PieceWeight * TotalPieces
            txtTotalWeight.Text = Math.Round(TotalWeight, 0)
        End If
        '****************************************************************************************
        'Get Next Racking Number
        Dim NextRackingKey, LastRackingKey As Integer

        Dim MAXStatement As String = "SELECT MAX(RackingKey) FROM QCRackingTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastRackingKey = CInt(MAXCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastRackingKey = 1000
        End Try
        con.Close()

        NextRackingKey = LastRackingKey + 1

        Try
            'Command to write to racking table
            cmd = New SqlCommand("INSERT INTO QCRackingTable (RackingKey, BinNumber, PartNumber, Description, LotNumber, FOXNumber, HoldReason, BoxQuantity, PiecesPerBox, TotalPieces, TotalWeight, ActivityDate, DivisionID, PNCNumber) Values (@RackingKey, @BinNumber, @PartNumber, @Description, @LotNumber, @FOXNumber, @HoldReason, @BoxQuantity, @PiecesPerBox, @TotalPieces, @TotalWeight, @ActivityDate, @DivisionID, @PNCNumber)", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = NextRackingKey
                .Add("@BinNumber", SqlDbType.VarChar).Value = cboBinNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                .Add("@Description", SqlDbType.VarChar).Value = lblPartDescription.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
                .Add("@FoxNumber", SqlDbType.VarChar).Value = lblFOXNumber.Text
                .Add("@HoldReason", SqlDbType.VarChar).Value = txtHoldReason.Text
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = Val(txtBoxQuantity.Text)
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = Val(txtPiecesPerBox.Text)
                .Add("@TotalPieces", SqlDbType.VarChar).Value = Val(txtTotalPieces.Text)
                .Add("@TotalWeight", SqlDbType.VarChar).Value = Val(txtTotalWeight.Text)
                .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                .Add("@DivisionID", SqlDbType.VarChar).Value = LOtNumberDivisionID
                .Add("@PNCNumber", SqlDbType.VarChar).Value = Val(cboPNCNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearFields()
            MsgBox("Item has been added to QC Rack.", MsgBoxStyle.OkOnly)

            Me.Dispose()
            Me.Close()
        Catch ex As Exception
            'Error Check
            'Log error on update failure
            Dim TempQCNumber As Integer = 0
            Dim strQCNumber As String
            TempQCNumber = Val(cboPNCNumber.Text)
            strQCNumber = CStr(TempQCNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = GlobalDivisionCode
            ErrorDescription = "QC Nonconformance --- Add To Rack"
            ErrorReferenceNumber = "PO # " + strQCNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            MsgBox("Failed to enter into rack. Check data and try again.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 300 Then
            ErrorComment = ErrorComment.Substring(0, 300)
        End If

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

    Private Sub LoadHoldReason()
        Dim GetHoldDataStatement As String = "SELECT NonConformanceReason FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber"
        Dim GetHoldDataCommand As New SqlCommand(GetHoldDataStatement, con)
        GetHoldDataCommand.Parameters.Add("@QCTransactionNumber", SqlDbType.VarChar).Value = Val(cboPNCNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            HoldReason = CStr(GetHoldDataCommand.ExecuteScalar)
        Catch ex As System.Exception
            HoldReason = ""
        End Try
        con.Close()

        txtHoldReason.Text = HoldReason
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

End Class