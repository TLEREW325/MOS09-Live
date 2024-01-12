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
Public Class SOAccessoriesForm
    Inherits System.Windows.Forms.Form

    Dim NewOrderQuantity, GetLineNumber, CheckOrderQuantity, BoxCount, OrderQuantity, LineBoxes, LastLineNumber, NextLineNumber As Integer
    Dim LineWeight, PieceWeight As Double
    Dim CheckPartNumber As String
    Dim FerruleDiameter As Double = 0
    Dim PreferredFerrule As String = ""
    Dim GetLastSalesPrice As Double = 0
    Dim GetMAXDate As Integer = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet

    Private Sub SOAccessoriesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdAdd
        Me.CenterToScreen()

        txtQuantity.Text = GlobalOrderQuantity

        LoadItemList()
        AutoselectFerrule()

        cmdAdd.Focus()
    End Sub

    Private Sub LoadItemList()
        'Create commands to load Item List for each division
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND NominalDiameter = @NominalDiameter AND ItemClass = @ItemClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = GlobalNominalDiameter
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "FERRULE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        dgvSelectAccessory.DataSource = ds1.Tables("ItemList")
        con.Close()
    End Sub

    Public Sub AutoselectFerrule()
        Dim ADDLP As String = ""

        If GlobalNominalLength <= 1 Then
            ADDLP = "L"
        Else
            ADDLP = ""
        End If

        'Write exception for ATL (-Q) Parts
        If GlobalSOPartNumber.EndsWith("-Q") Then
            ADDLP = "-Q"
        Else
            'Skip
        End If

        Select Case GlobalItemClass
            Case "TW SC"
                Select Case GlobalNominalDiameter
                    Case 0.75
                        PreferredFerrule = "FER12-F"
                    Case 0.875
                        PreferredFerrule = "FER14-F"
                    Case 1.0
                        PreferredFerrule = "FER16-F"
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW CA"
                Select Case GlobalNominalDiameter
                    Case 0.25
                        PreferredFerrule = "FER04-FHD"
                    Case 0.375
                        PreferredFerrule = "FER06-FHD"
                    Case 0.5
                        If GlobalDivisionCode = "SLC" Then
                            PreferredFerrule = "FER08-FHDS"
                        Else
                            PreferredFerrule = "FER08-FHD"
                        End If
                    Case 0.625
                        If GlobalDivisionCode = "SLC" Then
                            PreferredFerrule = "FER10-FHDS"
                        Else
                            PreferredFerrule = "FER10-FHD"
                        End If
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW DS"
                PreferredFerrule = "FER12-TD"
            Case "TW PS"
                Select Case GlobalNominalDiameter
                    Case 0.25
                        PreferredFerrule = "FER04-FHD"
                    Case 0.375
                        PreferredFerrule = "FER06-FHD"
                    Case 0.5
                        PreferredFerrule = "FER08-FHD"
                    Case 0.625
                        PreferredFerrule = "FER10-FHD"
                    Case 0.75
                        PreferredFerrule = "FER12-F"
                    Case 0.875
                        PreferredFerrule = "FER14-F"
                    Case 1.0
                        PreferredFerrule = "FER16-F"
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW TT"
                Select Case GlobalNominalDiameter
                    Case 0.25
                        PreferredFerrule = "FER04-F" + ADDLP
                    Case 0.375
                        PreferredFerrule = "FER06-F" + ADDLP
                    Case 0.3125
                        PreferredFerrule = "FER05-F" + ADDLP
                    Case 0.5
                        PreferredFerrule = "FER08-F" + ADDLP
                    Case 0.625
                        PreferredFerrule = "FER10-F" + ADDLP
                    Case 0.75
                        PreferredFerrule = "FER12-F" + ADDLP
                    Case 0.875
                        PreferredFerrule = "FER14-F" + ADDLP
                    Case 1.0
                        PreferredFerrule = "FER16-F" + ADDLP
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW TP"
                Select Case GlobalNominalDiameter
                    Case 0.25
                        PreferredFerrule = "FER04-P"
                    Case 0.375
                        If GlobalSOPartNumber.EndsWith("-Q") Then
                            PreferredFerrule = "FER06-F-Q"
                        Else
                            PreferredFerrule = "FER06-P"
                        End If
                    Case 0.3125
                        PreferredFerrule = "FER05-P"
                    Case 0.5
                        PreferredFerrule = "FER08-P"
                    Case 0.625
                        PreferredFerrule = "FER10-P"
                    Case 0.75
                        PreferredFerrule = "FER12-P"
                    Case 0.875
                        PreferredFerrule = "FER14-P"
                    Case 1.0
                        PreferredFerrule = "FER16-P"
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW DB"
                Select Case GlobalNominalDiameter
                    Case 0.25
                        PreferredFerrule = "FER04-FHD"
                    Case 0.375
                        PreferredFerrule = "FER06-FHD"
                    Case 0.5
                        If GlobalDivisionCode = "SLC" Then
                            PreferredFerrule = "FER08-FHDS"
                        Else
                            PreferredFerrule = "FER08-FHD"
                        End If
                    Case 0.625
                        If GlobalDivisionCode = "SLC" Then
                            PreferredFerrule = "FER10-FHDS"
                        Else
                            PreferredFerrule = "FER10-FHD"
                        End If
                    Case 0.75
                        PreferredFerrule = "FER12-F"
                    Case 0.875
                        PreferredFerrule = "FER14-F"
                    Case 1.0
                        PreferredFerrule = "FER16-F"
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW SWR"
                Select Case GlobalNominalDiameter
                    Case 0.5
                        PreferredFerrule = "FER08-P"
                    Case 0.625
                        PreferredFerrule = "FER10-P"
                    Case 0.75
                        PreferredFerrule = "FER12-P"
                    Case 0.875
                        PreferredFerrule = "FER14-P"
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW HSR"
                Select Case GlobalNominalDiameter
                    Case 0.5
                        PreferredFerrule = "FER08-P"
                    Case 0.625
                        PreferredFerrule = "FER10-P"
                    Case 0.75
                        PreferredFerrule = "FER12-P"
                    Case 0.875
                        PreferredFerrule = "FER14-P"
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case "TW CS"
                Select Case GlobalNominalDiameter
                    Case 0.1875
                        PreferredFerrule = "FER03-C"
                    Case 0.25
                        PreferredFerrule = "FER04-C"
                    Case 0.3125
                        PreferredFerrule = "FER05-C"
                    Case 0.375
                        PreferredFerrule = "FER06-C"
                    Case 0.4375
                        PreferredFerrule = "FER07-C"
                    Case 0.5
                        PreferredFerrule = "FER08-C"
                    Case Else
                        PreferredFerrule = "NONE"
                End Select
            Case Else
                PreferredFerrule = "NONE"
        End Select

        Dim RowIndex As Integer = 0

        If PreferredFerrule = "NONE" Then
            'Skip - no preferred ferrule
        Else
            Try
                'Retrieve line data from SO Table
                For Each row As DataGridViewRow In dgvSelectAccessory.Rows
                    If Me.dgvSelectAccessory.Rows(RowIndex).Cells("ItemIDColumn").Value = PreferredFerrule Then

                        'Check this field and exit subroutine
                        Me.dgvSelectAccessory.Rows(RowIndex).Cells("SelectAccessory").Value = "CHECKED"
                        dgvSelectAccessory.FirstDisplayedScrollingRowIndex = RowIndex

                        Exit Sub
                    Else
                        'Skip
                        RowIndex = RowIndex + 1
                    End If
                Next
            Catch ex As Exception
                'Do nothing - no autocheck
            End Try
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalCustomerID = ""
        GlobalSOPartNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim GetFerruleQuantity As Double = 0

        For Each row As DataGridViewRow In dgvSelectAccessory.Rows
            'Dim cell As DataGridViewCheckBoxCell = row.Cells(0)

            If row.Cells("SelectAccessory").Value = "CHECKED" Then
                Dim PartNumber As String = row.Cells("ItemIDColumn").Value
                Dim PartDescription As String = row.Cells("ShortDescriptionColumn").Value

                'Check to verify if Part is already added to the Sales Order
                Dim CheckPartNumberStatement As String = "SELECT ItemID FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND ItemID = @ItemID And Price = @Price"
                Dim CheckPartNumberCommand As New SqlCommand(CheckPartNumberStatement, con)
                CheckPartNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
                CheckPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                CheckPartNumberCommand.Parameters.Add("@Price", SqlDbType.VarChar).Value = 0

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckPartNumber = CStr(CheckPartNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    CheckPartNumber = "NEW PART"
                End Try
                con.Close()

                If CheckPartNumber = "NEW PART" Or CheckPartNumber = "" Then
                    'Find Item data
                    Dim PieceWeightStatement As String = "SELECT PieceWeight, BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
                    PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader As SqlDataReader = PieceWeightCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("PieceWeight")) Then
                            PieceWeight = 0
                        Else
                            PieceWeight = reader.Item("PieceWeight")
                        End If
                        If IsDBNull(reader.Item("BoxCount")) Then
                            BoxCount = 0
                        Else
                            BoxCount = reader.Item("BoxCount")
                        End If
                    Else
                        PieceWeight = 0
                        BoxCount = 0
                    End If
                    reader.Close()
                    con.Close()

                    'Get last sales price if it is a wired ferrule
                    Select Case PartNumber
                        Case "FER14-FW", "FER12-FW", "FER12-TDW"
                            Dim GetMAXDate5Statement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE CustomerID = @CustomerID AND ItemID = @ItemID AND DivisionKey = @DivisionKey"
                            Dim GetMAXDate5Command As New SqlCommand(GetMAXDate5Statement, con)
                            GetMAXDate5Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
                            GetMAXDate5Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetMAXDate5Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetMAXDate = CInt(GetMAXDate5Command.ExecuteScalar)
                            Catch ex As System.Exception
                                GetMAXDate = 0
                            End Try
                            con.Close()

                            Dim GetLastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE CustomerID = @CustomerID AND ItemID = @ItemID And DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey"
                            Dim GetLastPriceCommand As New SqlCommand(GetLastPriceStatement, con)
                            GetLastPriceCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
                            GetLastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetLastPriceCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
                            GetLastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetMAXDate

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetLastSalesPrice = CDbl(GetLastPriceCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                GetLastSalesPrice = 0
                            End Try
                            con.Close()
                        Case Else
                            'Set to zero for all other ferrules
                            GetLastSalesPrice = 0
                    End Select

                    'Calculate line weight and number of boxes
                    OrderQuantity = Val(txtQuantity.Text)

                    If BoxCount = 0 Then
                        LineBoxes = 0
                    Else
                        LineBoxes = OrderQuantity / BoxCount
                    End If

                    LineWeight = PieceWeight * OrderQuantity

                    'Write Data to Sales Order Line Database Table (Line Items)
                    cmd = New SqlCommand("Insert Into SalesOrderLineTable(SalesOrderKey, SalesOrderLineKey, ItemID, Description, Quantity, Price, LineComment, SalesTax, DivisionID, ExtendedAmount, LineWeight, LineBoxes, LineStatus, DebitGLAccount, CreditGLAccount, LeadTime, CertificationType, EstExtendedCOS, ShippedPrevious)Values(@SalesOrderKey, (SELECT isnull(MAX(SalesOrderLineKey) + 1, 1) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey), @ItemID, @Description, @Quantity, @Price, @LineComment, @SalesTax, @DivisionID, @ExtendedAmount, @LineWeight, @LineBoxes, @LineStatus, @DebitGLAccount, @CreditGLAccount, @LeadTime, @CertificationType, @EstExtendedCOS, @ShippedPrevious)", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
                        .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                        .Add("@Quantity", SqlDbType.VarChar).Value = OrderQuantity
                        .Add("@Price", SqlDbType.VarChar).Value = GetLastSalesPrice
                        .Add("@LineComment", SqlDbType.VarChar).Value = ""
                        .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = OrderQuantity * GetLastSalesPrice
                        .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                        .Add("@LineStatus", SqlDbType.VarChar).Value = GlobalSOStatus
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = "12110"
                        .Add("@LeadTime", SqlDbType.VarChar).Value = "  /  /"
                        .Add("@CertificationType", SqlDbType.VarChar).Value = "0"
                        .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                        .Add("@ShippedPrevious", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Get last sales price if it is a wired ferrule
                    Select Case PartNumber
                        Case "FER14-FW", "FER12-FW", "FER12-TDW"
                            Dim GetMAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE CustomerID = @CustomerID AND ItemID = @ItemID And DivisionKey = @DivisionKey"
                            Dim GetMAXDateCommand As New SqlCommand(GetMAXDateStatement, con)
                            GetMAXDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
                            GetMAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetMAXDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetMAXDate = CInt(GetMAXDateCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                GetMAXDate = 0
                            End Try
                            con.Close()

                            Dim GetLastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE CustomerID = @CustomerID AND ItemID = @ItemID And DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey"
                            Dim GetLastPriceCommand As New SqlCommand(GetLastPriceStatement, con)
                            GetLastPriceCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
                            GetLastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            GetLastPriceCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
                            GetLastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetMAXDate

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetLastSalesPrice = CDbl(GetLastPriceCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                GetLastSalesPrice = 0
                            End Try
                            con.Close()
                        Case Else
                            'Set to zero for all other ferrules
                            GetLastSalesPrice = 0
                    End Select

                    'Find Item data
                    Dim PieceWeightStatement As String = "SELECT PieceWeight, BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
                    PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader As SqlDataReader = PieceWeightCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("PieceWeight")) Then
                            PieceWeight = 0
                        Else
                            PieceWeight = reader.Item("PieceWeight")
                        End If
                        If IsDBNull(reader.Item("BoxCount")) Then
                            BoxCount = 0
                        Else
                            BoxCount = reader.Item("BoxCount")
                        End If
                    Else
                        PieceWeight = 0
                        BoxCount = 0
                    End If
                    reader.Close()
                    con.Close()

                    'get previous quantity
                    Dim GetFerruleQuantityStatement As String = "SELECT Quantity FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND ItemID = @ItemID And Price = @Price"
                    Dim GetFerruleQuantityCommand As New SqlCommand(GetFerruleQuantityStatement, con)
                    GetFerruleQuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
                    GetFerruleQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    GetFerruleQuantityCommand.Parameters.Add("@Price", SqlDbType.VarChar).Value = 0

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetFerruleQuantity = CDbl(GetFerruleQuantityCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        GetFerruleQuantity = 0
                    End Try
                    con.Close()

                    'Calculate line weight and number of boxes
                    OrderQuantity = Val(txtQuantity.Text)

                    If BoxCount = 0 Then
                        LineBoxes = 0
                    Else
                        LineBoxes = (OrderQuantity + GetFerruleQuantity) / BoxCount
                    End If

                    LineWeight = PieceWeight * (OrderQuantity + GetFerruleQuantity)

                    'Update existing line item with new quantity
                    cmd = New SqlCommand("UPDATE SalesOrderLineTable SET Quantity = @Quantity, ExtendedAmount = Price * @Quantity, LineWeight = @LineWeight, LineBoxes = @LineBoxes WHERE SalesOrderKey = @SalesOrderKey AND ItemID = @ItemID And Price = @Price", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
                        .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GlobalSONumber
                        .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        .Add("@Price", SqlDbType.VarChar).Value = 0
                        .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text) + GetFerruleQuantity
                        .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        Next

        GlobalCustomerID = ""
        GlobalSOPartNumber = ""

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvSelectAccessory_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSelectAccessory.CellContentClick
        Dim CheckedPart As String = ""

        If Me.dgvSelectAccessory.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvSelectAccessory.CurrentCell.RowIndex

            'Try
            'CheckedPart = Me.dgvSelectAccessory.Rows(RowIndex).Cells("ItemIDColumn").Value
            'Catch ex As Exception
            'CheckedPart = ""
            'End Try

            For Each row As DataGridViewRow In dgvSelectAccessory.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectAccessory")
                cell.Value = "UNCHECKED"
            Next

            Me.dgvSelectAccessory.Rows(RowIndex).Cells("SelectAccessory").Value = "CHECKED"
        Else
            'Skip
        End If
    End Sub

    Private Sub dgvSelectAccessory_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSelectAccessory.CurrentCellDirtyStateChanged
        If dgvSelectAccessory.IsCurrentCellDirty Then
            dgvSelectAccessory.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
End Class