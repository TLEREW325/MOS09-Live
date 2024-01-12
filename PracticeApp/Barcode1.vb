Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing.Text
Public Class Barcode1
    Inherits System.Windows.Forms.Form

    Dim SteelSize1, SteelType, VendorID, DateReceived, SteelPONumber, SteelSize, Carbon, Description, BoxType, RMID, PartNumber, BlueprintNumber, CertificationType, FluxLoadNumber, LongDescription, ShortDescription, PromiseDate, HeatNumber, AnnealHeat As String
    Dim RawMaterialWeight, FinishedWeight, ScrapWeight, ProductionQuantity As Double
    Dim LotDate As Date
    Dim dayofyear, year As Integer
    Dim FOXNumber, LotSerialNumber, strDayofYear, strYear, HLSteelSize, FOXSteelSize, strBatchNumber, ScanVariable As String
    Dim PieceWeight, BoxWeight, PalletWeight As Double
    Dim BoxCount, PalletCount, PalletPieces, DailyBatchNumber, NewBatchNumber, HeatFileNumber As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet

    'Setup for barcode
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLables, AnnealType As Integer

    'Setup for Customer file shipping info
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry As String
    Dim ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry As String
    Dim CustomerID, CustomerName As String

    'Nordic Variables
    Dim NordicBoxWeight As String = ""
    Dim NordicHeatNumber As String = ""

    'Variables for Shipping Label Table
    Dim LabelSalesOrderNumber, LabelPickTicketNumber, LabelNumberOfLabels As Integer
    Dim LabelUsername, LabelDivisionID, LabelDoesSpecialLabelExist As String
    Dim SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3 As String
    Dim LabelSpecialLabelExists As String

    Dim currentActiveControls As New List(Of String)
    Dim canPrint = True
    Dim bc As New BarcodeLabel()
    Dim bc2 As New BarcodeLabel()
    Dim ImageObjects As Dictionary(Of String, ImageObject)
    Dim barCode39 As New Barcode39()

    Dim grayscale As New Imaging.ColorMatrix(New Single()() _
    { _
        New Single() {0.299, 0.299, 0.299, 0, 0}, _
        New Single() {0.587, 0.587, 0.587, 0, 0}, _
        New Single() {0.114, 0.114, 0.114, 0, 0}, _
        New Single() {0, 0, 0, 1, 0}, _
        New Single() {0, 0, 0, 0, 1} _
    })

    Public Sub New()
        InitializeComponent()
        If EmployeeCompanyCode <> "ADM" And EmployeeCompanyCode <> "TWD" And EmployeeCompanyCode <> "TST" Then
            rbuCoilYardLabel.Enabled = False
        End If
        InitializeBarcodeVariables()
        LoadCustomerList()
        bgwkCoilLoad.RunWorkerAsync()
        LoadSecurity()

        If EmployeeLoginName = "PROD" Then
            rbuMasterBarcode.Checked = True
        End If
    End Sub

    Private Sub LoadSecurity()
        Select Case EmployeeSecurityCode
            Case 1010
                txtSerialLotNumber.Enabled = False
                txtPartNumber.Enabled = False
                txtHeatNumber.Enabled = False
                txtWeightPerBox.Enabled = False
                txtQuantityPerBox.Enabled = False
                txtQuantityPerPallet.Enabled = False
                txtShortDescription.Enabled = False
        End Select
        Select Case EmployeeLoginName
            Case "PROD"
                txtSerialLotNumber.Enabled = False
                txtPartNumber.Enabled = False
                txtHeatNumber.Enabled = False
                txtWeightPerBox.Enabled = False
                txtQuantityPerBox.Enabled = False
                txtQuantityPerPallet.Enabled = False
                txtShortDescription.Enabled = False
        End Select
    End Sub

    Private Sub InitializeBarcodeVariables()
        resetControls(currentActiveControls)
        Dim I As Integer

        For I = 0 To 69
            LabelFormat(I) = ""
        Next I

        V00 = ""
        V01 = ""
        V02 = ""
        V03 = ""
        V04 = ""
        V05 = ""
        V06 = ""
        V07 = ""
        V08 = ""
        V09 = ""
        V10 = ""
        V11 = ""
        V12 = ""
        V13 = ""
        V14 = ""
        V15 = ""
        V16 = ""
        V17 = ""
        V18 = ""
        V19 = ""
        V20 = ""
        V21 = ""
        V22 = ""
        V23 = ""
        V24 = ""
        V25 = ""
        V26 = ""
        V27 = ""
        V28 = ""

        VDATA = ""
        VDATA1 = ""
        VBAR = ""
        VBAR1 = ""

        LabelLines = 0
        NumberOfLables = 1
        AnnealType = 0
        currentActiveControls = New List(Of String)
    End Sub

    Private Sub InitializeFormBoxes()
        lblCustomerPO.Text = "Customer P.O."

        txtCountry.Clear()
        txtCity.Clear()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboRackingLocation.Items.Clear()
        cboRackingLocation.Text = ""
        txtCustomerPO.Clear()
        txtState.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtZip.Clear()
        txtEngineeringChangeLevel.Clear()
        txtHarmCode.Clear()
        txtHeatNumber.Clear()
        txtKanBanNumber.Clear()
        txtLongDescription.Clear()
        txtWeightPerPallet.Clear()
        txtPartNumber.Clear()
        txtQuantityPerBox.Clear()
        txtQuantityPerPallet.Clear()
        txtReference.Clear()
        txtRevisionLevel.Clear()
        txtSerialLotNumber.Clear()
        txtShortDescription.Clear()
        txtSupplierNumber.Clear()
        txtThirdPartyPO.Clear()
        txtWeightPerBox.Clear()
        txtScannerEntry.Clear()
        txtFinishedWeight.Clear()
        txtProductionQuantity.Clear()
        txtDate.Clear()
        txtCustomerID.Clear()
        txtFinishedWeight.Clear()
        txtSteelCarbon.Clear()
        txtSteelSize.Clear()
        txtTotalWeight.Clear()
        txtAnnealingLotNumber.Clear()
        txtAnnealingLotNumber.ReadOnly = True
        txtFoxNumber.Clear()
        txtBlueprintNumber.Clear()
        txtBlankLineFour.Clear()
        txtBlankLineOne.Clear()
        txtBlankLineThree.Clear()
        txtBlankLineTwo.Clear()
        cboShiftNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboShiftNumber.Text) Then
            cboShiftNumber.Text = ""
        End If

        rbuStandardBarcode.Checked = False
        rbuTubTag.Checked = False
        rbuBranam.Checked = False
        rbuMasterBarcode.Checked = False
        rbuMixedLabel.Checked = False
        rbuTubTag.Checked = False
        rbuShippingLabel.Checked = False
        rbuBlank4Line.Checked = False
        rbuCoilYardLabel.Checked = False
        rdoAnnealSample.Checked = False
        rdoShippingLabelByPickTicket.Checked = False
        rdoZincPlatedLabel.Checked = False
        rdoNickelPlatedLabel.Checked = False
        rdoStainlessSteelLabel.Checked = False
        rdoFryerLabel.Checked = False
        rdoPartialPallet.Checked = False
        rdoPalletBinLabel.Checked = False
        rdoThreeLineBlank.Checked = False
        rdoCustomLabel.Checked = False
        rdoUniversalWaste.Checked = False

        nbrPrintAmount.Value = 1

        activateControls(New List(Of String))
    End Sub

    Private Sub PrintBarcodeLine()
        ' Click event handler for a button - designed to show how to use the
        ' SendBytesToPrinter function to send a string to the printer.

        Dim pd As New PrintDialog()
        Dim i As Integer
        pd.UseEXDialog = True

        pd.PrinterSettings = New PrinterSettings()
        Dim printers(pd.PrinterSettings.InstalledPrinters.Count) As [String]
        pd.PrinterSettings.InstalledPrinters.CopyTo(printers, 0)
        pd.PrinterSettings.PrinterName = ""
        ''checks to see if the designated printer is present
        While i < printers.Count() - 1
            If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains("Zebra" + EmployeeCompanyCode) Then
                pd.PrinterSettings.PrinterName = printers(i)
            End If
            i += 1
        End While
        ''checks to see if a printer was selected and if not will show the dialog
        If String.IsNullOrEmpty(pd.PrinterSettings.PrinterName) Then
            ' Open the printer dialog box, and then allow the user to select a printer.
            If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                sendToPrinter(pd.PrinterSettings.PrinterName)
            End If
        Else
            sendToPrinter(pd.PrinterSettings.PrinterName)
        End If
    End Sub

    Private Sub sendToPrinter(ByVal printerName As String)
        Dim s As String = ""
        For i = 0 To LabelLines
            ' You need a string to send.
            s += LabelFormat(i) + Environment.NewLine
        Next i
        If s <> "" Then
            RawPrinter.SendStringToPrinter(printerName, s)
        End If
    End Sub

    Private Sub AddressLabelSetup()
        'Standard 4x6 AIAG Label setup
        addressVarFill()
        Dim lst(5) As String
        lst(0) = V28
        lst(1) = V10
        lst(2) = V11
        lst(3) = V17
        lst(4) = V12
        lst(5) = V18
        bc.AddressLabelSetup(lst, nbrPrintAmount.Value)
        bc.PrintBarcodeLine()
    End Sub

    Private Sub addressVarFill()
        If BarCodeType = 17 Then
            V00 = txtCustomerName.Text
        Else
            If String.IsNullOrEmpty(cboCustomerName.Text) Then
                V00 = getCustomerName()
            Else

                V00 = cboCustomerName.Text
            End If
        End If

        V01 = txtAddress1.Text
        V02 = txtCity.Text & ", " & txtState.Text & " " & txtZip.Text
        V03 = txtAddress2.Text
        V04 = txtCountry.Text

        If V00.Length < 32 Then
            V10 = V00
        Else
            V10 = V00.Substring(0, 32)
        End If

        If V01.Length < 32 Then
            V11 = V01
        Else
            V11 = V01.Substring(0, 32)
        End If

        If V02.Length < 32 Then
            V12 = V02
        Else
            V12 = V02.Substring(0, 32)
        End If

        If V03.Length < 32 Then
            V17 = V03
        Else
            V17 = V03.Substring(0, 32)
        End If

        If V04.Length < 35 Then
            V18 = V04
        Else
            V18 = V04.Substring(0, 32)
        End If
        If EmployeeCompanyCode = "CHT" Then
            V28 = "WELDING CERAMICS "
        Else
            V28 = "TFP CORP. "
        End If

        cmd = New SqlCommand("SELECT City, State, ZipCode, Phone FROM DivisionTable WHERE DivisionKey = @DivisionKey;", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            V28 += reader.Item("City") + ", " + reader.Item("State") + " " + reader.Item("ZipCode") + " " + reader.Item("Phone")
        Else

        End If
        reader.Close()
        con.Close()
    End Sub

    Private Function getCustomerName() As String
        cmd = New SqlCommand("Select CustomerName FROM CustomerList WHERE CustomerID = @CustomerID;", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim nme As String = cmd.ExecuteScalar()
        con.Close()
        Return nme
    End Function

    Private Sub SerialLableSetup()
        'Small 1-1/2 x 3 AIAG Label setup
        LabelFormat(0) = "N"
        LabelFormat(1) = "q446"
        LabelFormat(2) = "Q152,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Barcodes
        LabelFormat(8) = "B70,10,0,3,2,4,102,N" & Chr(34) & V03 & Chr(34)

        'Print Label
        LabelFormat(9) = "P1"
        LabelFormat(10) = vbFormFeed
        LabelLines = 9
    End Sub

    Private Sub setStandardPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 61)
        txtScannerEntry.Location = New Point(330, 77)
        txtScannerEntry.TabIndex = 0
        lblDate.Location = New Point(456, 61)
        dtpDate.Location = New Point(459, 77)
        dtpDate.TabIndex = 1
        lblSerialLotNumber.Location = New Point(327, 107)
        txtSerialLotNumber.Location = New Point(330, 123)
        txtSerialLotNumber.TabIndex = 2
        lblPartNumber.Location = New Point(327, 146)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 3
        lblHeatNumber.Location = New Point(327, 183)
        txtHeatNumber.Location = New Point(330, 200)
        txtHeatNumber.TabIndex = 4
        lblWeightPerBox.Location = New Point(327, 223)
        txtWeightPerBox.Location = New Point(330, 240)
        txtWeightPerBox.TabIndex = 5
        lblWeightPerPallet.Location = New Point(456, 223)
        txtWeightPerPallet.Location = New Point(459, 239)
        txtWeightPerPallet.TabIndex = 6
        lblQuantityPerBox.Location = New Point(327, 263)
        txtQuantityPerBox.Location = New Point(330, 280)
        txtQuantityPerBox.TabIndex = 7
        lblQuantityPerPallet.Location = New Point(456, 262)
        txtQuantityPerPallet.Location = New Point(459, 278)
        txtQuantityPerPallet.TabIndex = 8
        lblShortDescription.Location = New Point(327, 303)
        txtShortDescription.Location = New Point(330, 320)
        txtShortDescription.TabIndex = 9
        lblLongDescription.Location = New Point(327, 343)
        txtLongDescription.Location = New Point(330, 360)
        txtLongDescription.TabIndex = 10
        lblRackingLocation.Location = New Point(327, 426)
        cboRackingLocation.Location = New Point(330, 443)
        cboRackingLocation.TabIndex = 11

        nbrPrintAmount.TabIndex = 12
        cmdClear.TabIndex = 13
        cmdPrintLabel.TabIndex = 14
        cmdExit.TabIndex = 15
        ''list of all controls that have been repositioned
        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblDate", "dtpDate", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblHeatNumber", "txtHeatNumber", "lblWeightPerBox", "txtWeightPerBox", "lblWeightPerPallet", "txtWeightPerPallet", "lblQuantityPerBox", "txtQuantityPerBox", "lblQuantityPerPallet", "txtQuantityPerPallet", "lblShortDescription", "txtShortDescription", "lblLongDescription", "txtLongDescription", "lblRackingLocation", "cboRackingLocation"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub standardLabelSetup()
        'Same as WeldStudLabelSetup() except for barcoded V23
        standardLabelVarFill()

        Dim stand As New BarcodeLabel.standardLabel
        stand.dat = V09
        stand.description1 = V04
        stand.description2 = V05
        stand.description3 = V06
        stand.heat = V16
        stand.partNumber = V00
        stand.quantityPerPallet = V01
        stand.rackLocation = V23
        stand.serialLotNumber = V03
        stand.weightPerPallet = V02

        bc.standardLabelSetup(stand, nbrPrintAmount.Value)
    End Sub

    Private Sub standardLabelVarFill()
        setDescription(34)
        V06 = V05
        V05 = V04
        V04 = "FULL PALLET"

        setPartNumber()

        V01 = "Q" + txtQuantityPerPallet.Text
        V02 = "W" + txtWeightPerPallet.Text
        V16 = "EH" + txtHeatNumber.Text
        V09 = dtpDate.Value.Date
        V03 = "S" + txtSerialLotNumber.Text
        V23 = cboRackingLocation.Text
    End Sub

    Private Sub masterLabelSetup()
        'Standard 4x6 AIAG Label setup
        masterLabelVarFill()

        Dim master As New BarcodeLabel.MasterLabel
        master.dat = V09
        master.description1 = V04
        master.description2 = V05
        master.description3 = V06
        master.heat = V16
        master.partNumber = V00
        master.quantityPerBox = V01
        master.rackLocation = V23
        master.serialLotNumber = V03
        master.weightPerBox = V02
        master.customerPO = V07
        master.country = V15
        master.shift = cboShiftNumber.Text
        master.esrNumber = txtESRNumber.Text

        bc.masterLabelSetup(master, nbrPrintAmount.Value)
    End Sub

    Private Sub masterLabelVarFill()
        setDescription()

        setPartNumber()

        V01 = txtQuantityPerBox.Text
        V02 = txtWeightPerBox.Text
        V03 = txtSerialLotNumber.Text
        V07 = txtCustomerPO.Text
        V09 = dtpDate.Value.Date
        If String.IsNullOrEmpty(txtCountry.Text) Then
            V15 = "USA"
        Else
            V15 = txtCountry.Text
        End If

        V16 = txtHeatNumber.Text
    End Sub

    Private Sub activateControls(ByRef currentActiveControls As List(Of String))
        For i As Integer = 0 To currentActiveControls.Count - 1
            Me.Controls.Item(currentActiveControls(i)).Visible = True
            Me.Controls.Item(currentActiveControls(i)).TabStop = True
        Next
    End Sub

    Private Function canPrintBinLable() As Boolean
        If txtRackingLocation.Text.Length < 5 Then
            MessageBox.Show("Not correct format for bin location label", "Invalid bin location", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRackingLocation.SelectAll()
            txtRackingLocation.Focus()
            canPrint = False
            Return False
        End If
        If IsNumeric(txtRackingLocation.Text.Substring(2, 3)) = False Then
            MessageBox.Show("Invalid bin location format. You must have 2 letters and 3 digits", "Invalid bin location", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRackingLocation.SelectAll()
            txtRackingLocation.Focus()
            canPrint = False
            Return False
        End If
        If txtRackingLocation2.Text.Length = 0 Then
            Return True
        End If
        If txtRackingLocation2.Text.Length < 5 Then
            MessageBox.Show("Not correct format for bin location label", "Invalid bin location", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRackingLocation2.SelectAll()
            txtRackingLocation2.Focus()
            canPrint = False
            Return False
        End If
        If IsNumeric(txtRackingLocation2.Text.Substring(2, 3)) = False Then
            MessageBox.Show("Invalid bin location format. You must have 2 letters and 3 digits", "Invalid bin location", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRackingLocation2.SelectAll()
            txtRackingLocation2.Focus()
            canPrint = False
            Return False
        End If
        Return True
    End Function

    Private Sub ValeoLabelSetup()
        'BC_3379 from Wang
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes

        LabelFormat(8) = "LO548,8,1,1196"
        LabelFormat(9) = "LO252,8,1,1196"
        LabelFormat(10) = "LO548,556,265,1"
        LabelFormat(11) = "LO2,556,247,206,1"
        LabelFormat(12) = "LO2,272,251,1"
        LabelFormat(13) = "LO2,800,547,1"

        'Fill in Verbiage

        LabelFormat(14) = "A792,10,1,3,1,1,N," & Chr(34) & "FROM:" & Chr(34)
        LabelFormat(15) = "A739,94,1,3,1,1,N," & Chr(34) & "TFP Corp." & Chr(34)
        LabelFormat(16) = "A708,94,1,3,1,1,N," & Chr(34) & "460 Lake Road" & Chr(34)
        LabelFormat(17) = "A664,94,1,3,1,1,N," & Chr(34) & "Medina, Oh.  44256 USA" & Chr(34)
        LabelFormat(18) = "A790,575,1,3,1,1,N," & Chr(34) & "SHIP TO:" & Chr(34)
        LabelFormat(19) = "A753,703,1,4,1,1,N," & Chr(34) & "Valeo Climate Control" & Chr(34)
        LabelFormat(20) = "A713,703,1,4,1,1,N," & Chr(34) & "2001 110th Street" & Chr(34)
        LabelFormat(21) = "A670,703,1,4,1,1,N," & Chr(34) & "Suite 100 East Docks" & Chr(34)
        LabelFormat(22) = "A623,703,1,4,1,1,N," & Chr(34) & "Grand Prairie, Tx.  75050" & Chr(34)
        LabelFormat(23) = "A526,12,1,3,1,1,N," & Chr(34) & "PART NUMBER" & Chr(34)
        LabelFormat(24) = "A528,885,1,3,1,1,N," & Chr(34) & "REVISION" & Chr(34)
        LabelFormat(25) = "A235,6,1,3,1,1,N," & Chr(34) & "QTY" & Chr(34)
        LabelFormat(26) = "A235,276,1,3,1,1,N," & Chr(34) & "PROD DATE" & Chr(34)
        LabelFormat(27) = "A235,569,1,3,1,1,N," & Chr(34) & "DESCRIPTION" & Chr(34)
        LabelFormat(28) = "A238,887,1,3,1,1,N," & Chr(34) & "PKG ID NO," & Chr(34)

        LabelFormat(29) = "A479,193,1,5,1,1,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(30) = "A485,979,1,5,1,1,N," & Chr(34) & V08 & Chr(34)
        LabelFormat(31) = "A195,18,1,5,1,1,N," & Chr(34) & V01 & Chr(34)
        LabelFormat(32) = "A95,317,1,4,1,1,N," & Chr(34) & V09 & Chr(34)
        LabelFormat(33) = "A177,569,1,4,1,1,N," & Chr(34) & V04 & Chr(34)
        LabelFormat(34) = "A197,810,1,5,1,1,N," & Chr(34) & V03 & Chr(34)
        LabelFormat(35) = "A120,569,1,4,1,1,N," & Chr(34) & V05 & Chr(34)

        'Print Barcodes

        LabelFormat(36) = "B424,231,1,3,2,4,102,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(37) = "B434,974,1,3,2,4,102,N," & Chr(34) & V08 & Chr(34)
        LabelFormat(38) = "B144,28,1,3,2,4,102,N," & Chr(34) & V01 & Chr(34)
        LabelFormat(39) = "B130,810,1,3,2,4,102,N," & Chr(34) & V03 & Chr(34)

        'Print Label

        LabelFormat(40) = "P1"
        LabelFormat(41) = vbFormFeed
        LabelLines = 40

    End Sub

    Public Sub LoadFryerTextBoxes()
        Dim GetFOXFromLot As Integer = 0
        Dim GetBlueprintRevision As String = ""
        Dim GetBoxCount As Double = 0
        Dim GetCustomerPO As String = ""
        Dim GetSONumber As Integer = 0

        'Get data from lot number and fox for fryer
        Dim GetFOXFromLotStatement As String = "SELECT FOXNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetFOXFromLotCommand As New SqlCommand(GetFOXFromLotStatement, con)
        GetFOXFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        'Get data from lot number and fox for fryer
        Dim GetBlueprintRevisionStatement As String = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetBlueprintRevisionCommand As New SqlCommand(GetBlueprintRevisionStatement, con)
        GetBlueprintRevisionCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        'Get data from lot number and fox for fryer
        Dim GetBoxCountStatement As String = "SELECT BoxCount FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetBoxCountCommand As New SqlCommand(GetBoxCountStatement, con)
        GetBoxCountCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetFOXFromLot = CInt(GetFOXFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            GetFOXFromLot = 0
        End Try
        Try
            GetBlueprintRevision = CStr(GetBlueprintRevisionCommand.ExecuteScalar)
        Catch ex As Exception
            GetBlueprintRevision = ""
        End Try
        Try
            GetBoxCount = CDbl(GetBoxCountCommand.ExecuteScalar)
        Catch ex As Exception
            GetBoxCount = ""
        End Try
        con.Close()

        'Get Sales Order From FOX
        Dim GetSONumberStatement As String = "SELECT OrderReferenceNumber FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim GetSONumberCommand As New SqlCommand(GetSONumberStatement, con)
        GetSONumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = GetFOXFromLot
        GetSONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSONumber = CInt(GetSONumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetSONumber = 0
        End Try
        con.Close()

        'Get Customer PO Number from Sales Order
        Dim GetCustomerPOStatement As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim GetCustomerPOCommand As New SqlCommand(GetCustomerPOStatement, con)
        GetCustomerPOCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetSONumber
        GetCustomerPOCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetCustomerPO = CStr(GetCustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            GetCustomerPO = ""
        End Try
        con.Close()

        txtQuantity.Text = GetBoxCount
        txtCustomerPO.Text = ""
        txtRevisionLevel.Text = GetBlueprintRevision
    End Sub

    Private Sub FryerLabelSetup()
        Dim fryer As New BarcodeLabel.FryerLabel()
        fryer.Lot = txtSerialLotNumber.Text
        fryer.PartNumber = txtPartNumber.Text
        fryer.PartDescription = txtShortDescription.Text
        fryer.Quantity = txtQuantity.Text
        fryer.SupplierCode = txtSupplierNumber.Text
        fryer.PONumber = txtCustomerPO.Text
        fryer.PartRev = txtRevisionLevel.Text
        bc.FryerLabelSetup(fryer, nbrPrintAmount.Value)
    End Sub

    Private Sub NordicLabelSetup()
        Dim Nordic As New BarcodeLabel.NordicLabel()
        Nordic.Lot = txtSerialLotNumber.Text
        Nordic.PartNumber = txtPartNumber.Text
        Nordic.PartDescription = txtShortDescription.Text
        Nordic.Quantity = txtQuantity.Text
        Nordic.LotComment = txtSupplierNumber.Text
        Nordic.PONumber = txtCustomerPO.Text
        Nordic.PartRev = txtRevisionLevel.Text
        Nordic.HeatNumber = NordicHeatNumber
        Nordic.BoxWeight = NordicBoxWeight
        bc.NordicLabelSetup(Nordic, nbrPrintAmount.Value)
    End Sub

    Private Sub JohnsonRubberLableSetup()
        'BC_6960 FROM WANG  Johnson Rubber (T/W)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes

        LabelFormat(8) = "LO609,6,1,654"
        LabelFormat(9) = "LO406,6,1,654"
        LabelFormat(10) = "LO203,6,1,1196"
        LabelFormat(11) = "LO203,660,604,1"
        LabelFormat(12) = "LO708,660,1,536"
        LabelFormat(13) = "LO554,660,1,536"
        LabelFormat(14) = "LO426,660,1,536"
        LabelFormat(15) = "LO264,660,1,536"
        LabelFormat(16) = "LO10,731,193,1"

        'Fill in Verbiage

        LabelFormat(17) = "A800,10,1,2,1,1,N," & Chr(34) & "PART NO." & Chr(34)
        LabelFormat(18) = "A777,10,1,2,1,1,N," & Chr(34) & "(P)" & Chr(34)
        LabelFormat(19) = "A601,10,1,2,1,1,N," & Chr(34) & "QUANTITY" & Chr(34)
        LabelFormat(20) = "A581,10,1,2,1,1,N," & Chr(34) & "(Q)" & Chr(34)
        LabelFormat(21) = "A197,10,1,2,1,1,N," & Chr(34) & "SERIAL NO." & Chr(34)
        LabelFormat(22) = "A177,10,1,2,1,1,N," & Chr(34) & "(3S)" & Chr(34)
        LabelFormat(23) = "A392,10,1,2,1,1,N," & Chr(34) & "SUPPLIER" & Chr(34)
        LabelFormat(24) = "A365,10,1,2,1,1,N," & Chr(34) & "(V)" & Chr(34)
        LabelFormat(25) = "A26,10,1,2,1,1,N," & Chr(34) & "TFP CORP. MEDINA, OH. 44256 USA 330-725-7741" & Chr(34)
        LabelFormat(26) = "A804,670,1,2,1,1,N," & Chr(34) & "DESCRIPTION" & Chr(34)
        LabelFormat(27) = "A696,670,1,2,1,1,N," & Chr(34) & "P.O. NUMBER" & Chr(34)
        LabelFormat(28) = "A672,670,1,2,1,1,N," & Chr(34) & "(K)" & Chr(34)
        LabelFormat(29) = "A542,670,1,2,1,1,N," & Chr(34) & "ENGR. CHANGE LEVEL" & Chr(34)
        LabelFormat(30) = "A414,670,1,2,1,1,N," & Chr(34) & "LOT NUMBER" & Chr(34)
        LabelFormat(31) = "A258,670,1,2,1,1,N," & Chr(34) & "DATE" & Chr(34)
        LabelFormat(32) = "A522,670,1,2,1,1,N," & Chr(34) & "(2P)" & Chr(34)
        LabelFormat(33) = "A388,670,1,2,1,1,N," & Chr(34) & "(1T)" & Chr(34)

        LabelFormat(34) = "A786,130,1,4,3,2,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(35) = "A597,112,1,4,3,2,N," & Chr(34) & V01 & Chr(34)
        LabelFormat(36) = "A197,126,1,4,3,2,N," & Chr(34) & V18 & Chr(34)
        LabelFormat(37) = "A786,700,1,4,3,2,N," & Chr(34) & V05 & Chr(34)
        LabelFormat(38) = "A702,822,1,4,3,2,N," & Chr(34) & V19 & Chr(34)
        LabelFormat(39) = "A548,940,1,4,3,2,N," & Chr(34) & V08 & Chr(34)
        LabelFormat(40) = "A418,822,1,4,3,2,N," & Chr(34) & V13 & Chr(34)
        LabelFormat(41) = "A255,851,1,4,3,2,N," & Chr(34) & V09 & Chr(34)
        LabelFormat(42) = "A389,122,1,4,3,2,N," & Chr(34) & V14 & Chr(34)

        'Print Barcodes

        LabelFormat(43) = "B717,75,1,3,2,6,102,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(44) = "B528,89,1,3,2,6,102,N," & Chr(34) & V01 & Chr(34)
        LabelFormat(45) = "B136,85,1,3,2,6,102,N," & Chr(34) & V18 & Chr(34)
        LabelFormat(46) = "B641,765,1,3,2,6,81,N," & Chr(34) & V19 & Chr(34)
        LabelFormat(47) = "B508,895,1,3,2,6,81,N," & Chr(34) & V20 & Chr(34)
        LabelFormat(48) = "B351,704,1,3,2,6,81,N," & Chr(34) & V21 & Chr(34)
        LabelFormat(46) = "B323,89,1,3,2,6,102,N," & Chr(34) & V14 & Chr(34)

        'Print Label

        LabelFormat(46) = "P1"
        LabelFormat(47) = vbFormFeed
        LabelLines = 46

    End Sub

    Private Sub NavistarLableSetup()
        'BC_3153 FROM WANG  Navistar
        'Standard 4x6 AIAG Label setup
        navistarVarFill()

        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes

        LabelFormat(8) = "LO609,8,1,1196"
        LabelFormat(9) = "LO398,8,1,1196"
        LabelFormat(10) = "LO203,8,1,1196"
        LabelFormat(11) = "LO8,711,602,1"
        LabelFormat(12) = "LO8,32,9,679"

        'Fill in Verbiage

        LabelFormat(13) = "A800,12,1,2,1,1,N," & Chr(34) & "PART NO." & Chr(34)
        LabelFormat(14) = "A784,12,1,2,1,1,N," & Chr(34) & "CUST (P)" & Chr(34)
        LabelFormat(15) = "A601,12,1,2,1,1,N," & Chr(34) & "QUANTITY" & Chr(34)
        LabelFormat(16) = "A581,12,1,2,1,1,N," & Chr(34) & "(Q)" & Chr(34)
        LabelFormat(17) = "A388,12,1,2,1,1,N," & Chr(34) & "SUPLR ID" & Chr(34)
        LabelFormat(18) = "A365,12,1,2,1,1,N," & Chr(34) & "CUST ASSGN (V)" & Chr(34)
        LabelFormat(19) = "A197,12,1,2,1,1,N," & Chr(34) & "PKG ID-UNIT" & Chr(34)
        LabelFormat(20) = "A175,12,1,2,1,1,N," & Chr(34) & "(3S)" & Chr(34)
        LabelFormat(21) = "A388,715,1,2,1,1,N," & Chr(34) & "SHIP FROM:" & Chr(34)
        LabelFormat(22) = "A191,715,1,2,1,1,N," & Chr(34) & "DESCRIPTION" & Chr(34)
        LabelFormat(23) = "A365,784,1,4,2,1,N," & Chr(34) & "TFP CORPORATION" & Chr(34)
        LabelFormat(24) = "A315,784,1,4,2,1,N," & Chr(34) & "460 LAKE ROAD" & Chr(34)
        LabelFormat(25) = "A264,784,1,4,2,1,N," & Chr(34) & "MEDINA, OHIO 44256 USA" & Chr(34)
        LabelFormat(26) = "A219,784,1,4,2,1,N," & Chr(34) & "(330) 725-7741" & Chr(34)

        LabelFormat(27) = "A800,122,1,4,2,1,N," & Chr(34) & V00.Substring(1, V00.Length - 1) & Chr(34)
        LabelFormat(28) = "A601,116,1,4,2,1,N," & Chr(34) & txtQuantity.Text & Chr(34)
        LabelFormat(29) = "A384,213,1,4,2,1,N," & Chr(34) & txtSupplierNumber.Text & Chr(34)
        LabelFormat(30) = "A197,163,1,4,2,1,N," & Chr(34) & txtSerialLotNumber.Text & Chr(34)
        LabelFormat(31) = "A164,721,1,3,2,1,N," & Chr(34) & V04 & Chr(34)
        LabelFormat(32) = "A120,721,1,3,2,1,N," & Chr(34) & V05 & Chr(34)
        LabelFormat(33) = "A63,721,1,3,2,1,N," & Chr(34) & V06 & Chr(34)

        'Print Barcodes

        LabelFormat(34) = "B727,81,1,3,2,4,102,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(35) = "B522,81,1,3,2,4,102,N," & Chr(34) & "Q" + txtQuantity.Text & Chr(34)
        LabelFormat(36) = "B319,81,1,3,2,4,102,N," & Chr(34) & "V" + txtSupplierNumber.Text & Chr(34)
        LabelFormat(37) = "B128,81,1,3,2,4,102,N," & Chr(34) & "3S" + txtSerialLotNumber.Text & Chr(34)

        'Print Label
        LabelFormat(39) = vbFormFeed
        LabelLines = 38

    End Sub

    Private Sub navistarVarFill()
        setPartNumber()
        setDescription()
    End Sub

    Private Sub setPartNumber()
        V00 = txtPartNumber.Text
        'If txtPartNumber.Text.Contains("-") Then
        '    Dim sep As String() = txtPartNumber.Text.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
        '    V00 = "P"
        '    For Each part As String In sep
        '        V00 += part
        '    Next
        'Else
        '    V00 = "P" + txtPartNumber.Text
        'End If
    End Sub

    Private Sub setDescription(Optional ByVal cutLength As Integer = 27)
        If txtShortDescription.Text.Length > cutLength Then
            Dim offset As Integer = 0
            While txtShortDescription.Text(cutLength - offset) <> " "c
                offset += 1
            End While
            Dim firstCut As Integer = (cutLength - offset)
            V04 = txtShortDescription.Text.Substring(0, firstCut)
            If txtShortDescription.Text.Length > firstCut + cutLength Then
                offset = 0
                While txtShortDescription.Text(firstCut + cutLength - offset) <> " "c
                    offset += 1
                End While
                Dim secondCut As Integer = cutLength - offset
                If txtShortDescription.Text.Length > firstCut + secondCut + cutLength Then
                    offset = 0
                    While txtShortDescription.Text((firstCut + secondCut) + cutLength - offset) <> " "c
                        offset += 1
                    End While
                    Dim thirdCut = cutLength - offset
                    V06 = txtShortDescription.Text.Substring(firstCut + secondCut, thirdCut)
                Else
                    V06 = txtShortDescription.Text.Substring(firstCut + secondCut, txtShortDescription.Text.Length - (firstCut + secondCut))
                End If
                V05 = txtShortDescription.Text.Substring(firstCut, secondCut)
            Else
                V05 = txtShortDescription.Text.Substring(firstCut, txtShortDescription.Text.Length - firstCut)
                V06 = ""
            End If
        Else
            V04 = txtShortDescription.Text
            V05 = ""
            V06 = ""
        End If
    End Sub

    Private Sub BranamLabelSetup()
        'Branam BC_6156 from Wang
        BranamLabelVarFill()

        Dim bran As New BarcodeLabel.branamLabel

        bran.customerPO = txtCustomerPO.Text
        bran.engineeringChangeLvl = txtEngineeringChangeLevel.Text
        bran.PartNumber = V00
        bran.country = txtCountry.Text
        bran.reference = txtReference.Text
        bran.prductionQty = txtQuantity.Text
        bran.supplierNumber = txtSupplierNumber.Text
        bran.shortDescription = txtShortDescription.Text
        bran.serialLot = txtSerialLotNumber.Text
        bran.harmCode = txtHarmCode.Text

        bc.BranamLabelSetup(bran, nbrPrintAmount.Value)
    End Sub

    Private Sub BranamLabelVarFill()
        setPartNumber()
    End Sub

    Private Sub DelphiLabelSetup()
        'BC_2777  Delphi Label
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes

        LabelFormat(8) = "LO586,20,1,1190"
        LabelFormat(9) = "LO400,20,1,1190"
        LabelFormat(10) = "LO203,20,1,1190"
        LabelFormat(11) = "LO8,610,196,1"
        LabelFormat(12) = "LO400,770,407,1"
        LabelFormat(13) = "LO203,910,198,1"

        'Fill in Verbiage

        LabelFormat(14) = "A773,24,1,1,1,1,N," & Chr(34) & "PART NO." & Chr(34)
        LabelFormat(15) = "A749,24,1,1,1,1,N," & Chr(34) & "(P)" & Chr(34)
        LabelFormat(16) = "A682,24,1,1,1,1,N," & Chr(34) & "QUANTITY" & Chr(34)
        LabelFormat(17) = "A656,24,1,1,1,1,N," & Chr(34) & "(Q)" & Chr(34)
        LabelFormat(18) = "A392,24,1,1,1,1,N," & Chr(34) & "SERIAL NO." & Chr(34)
        LabelFormat(19) = "A367,24,1,1,1,1,N," & Chr(34) & "(3S)" & Chr(34)
        LabelFormat(20) = "A183,24,1,1,1,1,N," & Chr(34) & "ENG. CHANGE" & Chr(34)
        LabelFormat(21) = "A140,24,1,1,1,1,N," & Chr(34) & "MFG. SHIP DATE" & Chr(34)
        LabelFormat(22) = "A392,24,1,1,1,1,N," & Chr(34) & "PLT/DOCK" & Chr(34)
        LabelFormat(23) = "A392,24,1,1,1,1,N," & Chr(34) & "PLT 17/GATE 4" & Chr(34)
        LabelFormat(24) = "A120,24,1,1,1,1,N," & Chr(34) & "SUPPLIER ID: 051514057" & Chr(34)
        LabelFormat(25) = "A91,24,1,1,1,1,N," & Chr(34) & "TFP CORP" & Chr(34)
        LabelFormat(26) = "A39,24,1,1,1,1,N," & Chr(34) & "MEDINA, OHIO 44256 USA" & Chr(34)

        LabelFormat(27) = "A794,163,1,4,4,2,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(28) = "A683,871,1,4,4,2,N," & Chr(34) & V01 & Chr(34)
        LabelFormat(29) = "A400,320,1,4,4,2,N," & Chr(34) & V18 & Chr(34)
        LabelFormat(30) = "A195,140,1,4,2,1,N," & Chr(34) & V08 & Chr(34)
        LabelFormat(31) = "A154,175,1,4,2,1,N," & Chr(34) & V09 & Chr(34)
        LabelFormat(32) = "A171,621,1,3,2,1,N," & Chr(34) & V05 & Chr(34)
        LabelFormat(33) = "A80,24,1,1,1,1,N," & Chr(34) & "HEAT NUMBER" & Chr(34)
        LabelFormat(34) = "A94,175,1,4,2,1,N," & Chr(34) & V16 & Chr(34)
        LabelFormat(35) = "A570,24,1,1,1,1,N," & Chr(34) & "KANBAN ID" & Chr(34)
        LabelFormat(36) = "A545,24,1,1,1,1,N," & Chr(34) & "(15K)" & Chr(34)
        LabelFormat(37) = "A570,781,1,1,1,1,N," & Chr(34) & "DLOC" & Chr(34)
        LabelFormat(38) = "A855,163,1,4,4,2,N," & Chr(34) & V22 & Chr(34)

        'Print Barcodes

        LabelFormat(39) = "B698,75,1,3,2,4,102,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(40) = "B792,867,1,3,2,4,102,N," & Chr(34) & V01 & Chr(34)
        LabelFormat(41) = "B317,264,1,4,4,2,102,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(42) = "B500,75,1,3,2,4,102,N," & Chr(34) & V22 & Chr(34)


        'Print Label

        LabelFormat(43) = "P1"
        LabelFormat(44) = vbFormFeed
        LabelLines = 43
    End Sub

    Private Sub DelphiVarFill()
        setPartNumber()
        setDescription()
    End Sub

    Private Sub ValeoClimateControlLabelSetup()
        'BC_5150 Valeo Climate Control
        'Standard 4x6 AIAG Label setup
        ValeoClimateControlVarFill()

        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes

        LabelFormat(8) = "LO609,6,1,654"
        LabelFormat(9) = "LO406,6,1,654"
        LabelFormat(10) = "LO203,6,1,1196"
        LabelFormat(11) = "LO203,660,604,1"
        LabelFormat(12) = "LO708,660,1,536"
        LabelFormat(13) = "LO554,660,1,536"
        LabelFormat(14) = "LO426,660,1,536"
        LabelFormat(15) = "LO264,660,1,536"
        LabelFormat(16) = "LO10,731,193,1"

        'Fill in Verbiage

        LabelFormat(17) = "A800,10,1,2,1,1,N," & Chr(34) & "PART NO." & Chr(34)
        LabelFormat(18) = "A777,10,1,2,1,1,N," & Chr(34) & "(P)" & Chr(34)
        LabelFormat(19) = "A601,10,1,2,1,1,N," & Chr(34) & "QUANTITY" & Chr(34)
        LabelFormat(20) = "A581,10,1,2,1,1,N," & Chr(34) & "(Q)" & Chr(34)
        LabelFormat(21) = "A197,10,1,2,1,1,N," & Chr(34) & "SERIAL NO." & Chr(34)
        LabelFormat(22) = "A177,10,1,2,1,1,N," & Chr(34) & "(3S)" & Chr(34)
        LabelFormat(23) = "A392,10,1,2,1,1,N," & Chr(34) & "SUPPLIER" & Chr(34)
        LabelFormat(24) = "A365,10,1,2,1,1,N," & Chr(34) & "(V)" & Chr(34)
        LabelFormat(25) = "A26,10,1,2,1,1,N," & Chr(34) & "TFP CORP. MEDINA, OH 44256 USA (330)725-7741" & Chr(34)
        LabelFormat(26) = "A804,670,1,2,1,1,N," & Chr(34) & "DESCRIPTION" & Chr(34)
        LabelFormat(27) = "A696,670,1,2,1,1,N," & Chr(34) & "P.O. NUMBER" & Chr(34)
        LabelFormat(28) = "A672,670,1,2,1,1,N," & Chr(34) & "(K)" & Chr(34)
        LabelFormat(29) = "A542,670,1,2,1,1,N," & Chr(34) & "ENGR. CHANGE LEVEL" & Chr(34)
        LabelFormat(30) = "A414,670,1,2,1,1,N," & Chr(34) & "LOT NUMBER" & Chr(34)
        LabelFormat(31) = "A258,670,1,2,1,1,N," & Chr(34) & "DATE" & Chr(34)
        LabelFormat(32) = "A522,670,1,2,1,1,N," & Chr(34) & "(2P)" & Chr(34)
        LabelFormat(33) = "A388,670,1,2,1,1,N," & Chr(34) & "(1T)" & Chr(34)

        LabelFormat(34) = "A786,130,1,4,3,2,N," & Chr(34) & V00.Substring(1, V00.Length - 1) & Chr(34)
        LabelFormat(35) = "A597,112,1,4,3,2,N," & Chr(34) & txtQuantity.Text & Chr(34)
        LabelFormat(36) = "A197,126,1,4,3,2,N," & Chr(34) & txtSerialLotNumber.Text & Chr(34)
        LabelFormat(37) = "A786,700,1,4,3,1,N," & Chr(34) & V04 & Chr(34)
        LabelFormat(38) = "A702,822,1,4,3,2,N," & Chr(34) & txtCustomerPO.Text & Chr(34)
        LabelFormat(39) = "A548,940,1,4,2,1,N," & Chr(34) & txtEngineeringChangeLevel.Text & Chr(34)
        LabelFormat(40) = "A418,822,1,4,3,1,N," & Chr(34) & txtSerialLotNumber.Text & Chr(34)
        LabelFormat(41) = "A255,851,1,4,2,1,N," & Chr(34) & V09 & Chr(34)
        LabelFormat(42) = "A389,122,1,4,3,2,N," & Chr(34) & txtSupplierNumber.Text & Chr(34)

        'Print Barcodes
        LabelFormat(43) = "B717,75,1,3,2,6,102,N," & Chr(34) & V00 & Chr(34)
        LabelFormat(44) = "B528,89,1,3,2,6,102,N," & Chr(34) & "Q" + txtQuantity.Text & Chr(34)
        LabelFormat(45) = "B136,85,1,3,2,6,102,N," & Chr(34) & "3S" + txtSerialLotNumber.Text & Chr(34)
        LabelFormat(46) = "B641,765,1,3,2,6,102,N," & Chr(34) & "K" + txtCustomerPO.Text & Chr(34)
        LabelFormat(47) = "B508,895,1,3,2,6,102,N," & Chr(34) & "2P" + txtEngineeringChangeLevel.Text & Chr(34)
        LabelFormat(48) = "B351,704,1,3,2,4,102,N," & Chr(34) & "1T" + txtSerialLotNumber.Text & Chr(34)
        LabelFormat(49) = "B323,89,1,3,2,6,102,N," & Chr(34) & "V" + txtSupplierNumber.Text & Chr(34)

        'Print Label
        LabelFormat(51) = vbFormFeed
        LabelLines = 50
    End Sub

    Private Sub ValeoClimateControlVarFill()
        setPartNumber()

        setDescription()
        Dim fixDate As String = dtpDate.Value.Date
        V09 = fixDate.Substring(0, fixDate.IndexOf(" "))
    End Sub

    Private Sub CoilLabelSetup()
        'Replacement of Coil Yard Label
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage

        LabelFormat(8) = "A800,100,1,5,2,1,N," & Chr(34) & "TFP CORP." & Chr(34)
        LabelFormat(9) = "A670,100,1,4,2,1,N," & Chr(34) & "VENDOR" & Chr(34)
        'LabelFormat(10) = "A670,250,1,4,2,1,N," & Chr(34) & txtVendorName.Text & Chr(34)
        LabelFormat(11) = "A600,100,1,5,2,1,N," & Chr(34) & "HEAT" & Chr(34)
        'LabelFormat(12) = "A600,300,1,5,2,1,N," & Chr(34) & txtCoilHeat.Text & Chr(34)
        ' LabelFormat(13) = "A500,100,1,4,2,1,N," & Chr(34) & txtCoilDescription.Text & Chr(34)
        LabelFormat(14) = "A400,100,1,5,2,1,N," & Chr(34) & "COIL" & Chr(34)
        'LabelFormat(15) = "A400,300,1,5,2,1,N," & Chr(34) & txtCoilID.Text & Chr(34)
        'LabelFormat(16) = "A200,1000,0,5,2,1,N," & Chr(34) & txtCoilID.Text & Chr(34)
        'LabelFormat(17) = "A200,800,0,5,2,1,N," & Chr(34) & txtCoilWeight.Text & "LBS." & Chr(34)

        Select Case AnnealType
            Case 0
                LabelFormat(18) = "A200,900,0,4,2,1,N," & Chr(34) & "" & Chr(34)
            Case 1
                LabelFormat(18) = "A250,900,0,4,2,1,N," & Chr(34) & "ANNEALED" & Chr(34)
            Case 2
                LabelFormat(18) = "A250,900,0,4,2,1,N," & Chr(34) & "SPHERIDIZED" & Chr(34)
        End Select

        'Print Barcodes

        'LabelFormat(19) = "B300,100,1,3,4,8,120,N," & Chr(34) & txtCoilID.Text & Chr(34)
        'LabelFormat(20) = "B200,1050,0,3,4,8,120,N," & Chr(34) & txtCoilID.Text & Chr(34)

        'Print Label

        LabelFormat(21) = "P1"
        'LabelFormat(22) = vbFormFeed
        LabelLines = 21

    End Sub

    Private Sub resetControls(ByRef currentActiveControls As List(Of String))
        Dim i As Integer = 0
        While i < currentActiveControls.Count
            If Not currentActiveControls(i).Substring(0, 3).Contains("lbl") Then
                Me.Controls(currentActiveControls(i)).ResetText()
            ElseIf currentActiveControls(i).Equals("lblCustomerPO") Then
                Me.Controls(currentActiveControls(i)).Text = "Customer P.O."
            ElseIf currentActiveControls(i).Equals("txtCustomerPO") Then
                Me.Controls(currentActiveControls(i)).Enabled = True
            End If
            If currentActiveControls(i).Equals("txtAnnealingLotNumber") Then
                txtAnnealingLotNumber.ReadOnly = True
            End If
            Me.Controls(currentActiveControls(i)).TabStop = False
            Me.Controls(currentActiveControls(i)).Visible = False
            Me.Controls(currentActiveControls(i)).Refresh()
            i += 1
        End While
        ''Resets the controls that are associated to Branam to make sure they are editable the next time they are used.
        If currentActiveControls.Contains("txtPartNumber") Then
            If txtPartNumber.ReadOnly Then
                txtPartNumber.ReadOnly = False
                txtShortDescription.ReadOnly = False
                txtHarmCode.ReadOnly = False
                txtSupplierNumber.ReadOnly = False
                txtCountry.ReadOnly = False
                txtEngineeringChangeLevel.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub rbuStandardBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuStandardBarcode.CheckedChanged
        If rbuStandardBarcode.Checked Then
            cboRackingLocation.Items.Clear()
            resetControls(currentActiveControls)
            setStandardPosition()
            'Standard Label
            BarCodeType = 1

            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub rbuMasterBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuMasterBarcode.CheckedChanged
        If rbuMasterBarcode.Checked Then
            resetControls(currentActiveControls)
            'Master Bar Code Label
            setMasterPosition()
            BarCodeType = 2

            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub setMasterPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblDate.Location = New Point(456, 65)
        dtpDate.Location = New Point(459, 80)
        dtpDate.TabIndex = 1
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 2
        lblPartNumber.Location = New Point(327, 145)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 3
        lblHeatNumber.Location = New Point(327, 185)
        txtHeatNumber.Location = New Point(330, 200)
        txtHeatNumber.TabIndex = 4
        lblWeightPerBox.Location = New Point(327, 225)
        txtWeightPerBox.Location = New Point(330, 240)
        txtWeightPerBox.TabIndex = 5
        lblQuantityPerBox.Location = New Point(327, 265)
        txtQuantityPerBox.Location = New Point(330, 280)
        txtQuantityPerBox.TabIndex = 6
        lblQuantityPerPallet.Location = New Point(456, 265)
        txtQuantityPerPallet.Location = New Point(459, 280)
        txtQuantityPerPallet.TabIndex = 7
        lblShortDescription.Location = New Point(327, 305)
        txtShortDescription.Location = New Point(330, 320)
        txtShortDescription.TabIndex = 8
        lblCustomerPO.Location = New Point(327, 345)
        txtCustomerPO.Location = New Point(330, 360)
        txtCustomerPO.TabIndex = 9
        lblESRNumber.Location = New Point(327, 385)
        txtESRNumber.Location = New Point(330, 400)
        txtESRNumber.TabIndex = 10
        lblCountry.Location = New Point(327, 425)
        txtCountry.Location = New Point(330, 440)
        txtCountry.TabIndex = 11

        nbrPrintAmount.TabIndex = 12
        cmdClear.TabIndex = 13
        cmdPrintLabel.TabIndex = 14
        cmdExit.TabIndex = 15

        ''list of all controls that have been repositioned
        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblDate", "dtpDate", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblHeatNumber", "txtHeatNumber", "lblWeightPerBox", "txtWeightPerBox", "lblQuantityPerBox", "txtQuantityPerBox", "lblQuantityPerPallet", "txtQuantityPerPallet", "lblShortDescription", "txtShortDescription", "lblCustomerPO", "txtCustomerPO", "lblESRNumber", "txtESRNumber", "lblCountry", "txtCountry"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rbuMixedLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuMixedLabel.CheckedChanged
        'Mixed Label
        BarCodeType = 3
        resetControls(currentActiveControls)
        activateControls(New List(Of String))
        nbrPrintAmount.Focus()
    End Sub

    Private Sub rbuShippingAddressLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuShippingLabel.CheckedChanged
        If rbuShippingLabel.Checked Then
            resetControls(currentActiveControls)
            'Tru-Weld Order Address Label
            BarCodeType = 4

            setShippingAddressPosition()

            cboCustomerID.Focus()
        End If
    End Sub

    Private Sub setShippingAddressPosition()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "CustomerList")
        con.Close()

        cboCustomerID.DataSource = ds.Tables("CustomerList")
        cboCustomerID.DisplayMember = "CustomerID"
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.DataSource = ds.Tables("CustomerList")
        cboCustomerName.DisplayMember = "CustomerName"
        cboCustomerName.SelectedIndex = -1

        ''changing the position of the controls that are needed for the label
        lblCustomerID.Location = New Point(327, 65)
        cboCustomerID.Location = New Point(330, 80)
        cboCustomerID.TabIndex = 0
        lblCustomerName.Location = New Point(327, 105)
        cboCustomerName.Location = New Point(330, 120)
        cboCustomerName.TabIndex = 1
        lblAddress1.Location = New Point(327, 145)
        txtAddress1.Location = New Point(330, 160)
        txtAddress1.TabIndex = 2
        lblAddress2.Location = New Point(327, 185)
        txtAddress2.Location = New Point(330, 200)
        txtAddress2.TabIndex = 3
        lblCity.Location = New Point(327, 225)
        txtCity.Location = New Point(330, 240)
        txtCity.TabIndex = 4
        lblState.Location = New Point(327, 265)
        txtState.Location = New Point(330, 280)
        txtState.TabIndex = 5
        lblZip.Location = New Point(327, 305)
        txtZip.Location = New Point(330, 320)
        txtZip.TabIndex = 6

        nbrPrintAmount.TabIndex = 7
        cmdClear.TabIndex = 8
        cmdPrintLabel.TabIndex = 9
        cmdExit.TabIndex = 10
        ''list of all controls that have been repositioned
        currentActiveControls = (New String() {"lblCustomerID", "cboCustomerID", "lblCustomerName", "cboCustomerName", "lblAddress1", "txtAddress1", "lblAddress2", "txtAddress2", "lblCity", "txtCity", "lblState", "txtState", "lblZip", "txtZip"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rbuTubTag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuTubTag.CheckedChanged
        If rbuTubTag.Checked Then
            resetControls(currentActiveControls)
            'Serial Number Label
            setTubTagPosition()

            BarCodeType = 5

            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub setTubTagPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 1
        lblCustomerID.Location = New Point(327, 145)
        txtCustomerID.Location = New Point(330, 160)
        txtCustomerID.TabIndex = 2
        lblFoxNumber.Location = New Point(327, 185)
        txtFoxNumber.Location = New Point(330, 200)
        txtFoxNumber.TabIndex = 3
        lblBlueprintNumber.Location = New Point(456, 185)
        txtBlueprintNumber.Location = New Point(459, 200)
        txtBlueprintNumber.TabIndex = 4
        lblPartNumber.Location = New Point(327, 225)
        txtPartNumber.Location = New Point(330, 240)
        txtPartNumber.TabIndex = 5
        lblShortDescription.Location = New Point(327, 265)
        txtShortDescription.Location = New Point(330, 280)
        txtShortDescription.TabIndex = 6
        lblPromiseDate.Location = New Point(327, 305)
        txtDate.Location = New Point(330, 320)
        txtDate.TabIndex = 7
        lblProductionQuantity.Location = New Point(456, 305)
        txtProductionQuantity.Location = New Point(459, 320)
        txtProductionQuantity.TabIndex = 8
        lblFinishedWeight.Location = New Point(327, 345)
        txtFinishedWeight.Location = New Point(330, 360)
        txtFinishedWeight.TabIndex = 9
        lblTotalWeight.Location = New Point(456, 345)
        txtTotalWeight.Location = New Point(459, 360)
        txtTotalWeight.TabIndex = 10
        lblSteelCarbon.Location = New Point(327, 385)
        txtSteelCarbon.Location = New Point(330, 400)
        txtSteelCarbon.TabIndex = 11
        lblSteelSize.Location = New Point(456, 385)
        txtSteelSize.Location = New Point(459, 400)
        txtSteelSize.TabIndex = 12
        lblHeatNumber.Location = New Point(327, 425)
        txtHeatNumber.Location = New Point(330, 440)
        txtHeatNumber.TabIndex = 13
        lblAnnealingLotNumber.Location = New Point(327, 465)
        txtAnnealingLotNumber.Location = New Point(330, 480)
        txtAnnealingLotNumber.TabIndex = 14

        nbrPrintAmount.TabIndex = 15
        cmdClear.TabIndex = 16
        cmdPrintLabel.TabIndex = 17
        cmdExit.TabIndex = 18

        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblHeatNumber", "txtHeatNumber", "lblShortDescription", "txtShortDescription", "lblFoxNumber", "txtFoxNumber", "lblSteelCarbon", "txtSteelCarbon", "lblSteelSize", "txtSteelSize", "lblBlueprintNumber", "txtBluePrintNumber", "lblAnnealingLotNumber", "txtAnnealingLotNumber", "lblProductionQuantity", "txtProductionQuantity", "lblPromiseDate", "txtDate", "lblFinishedWeight", "txtFinishedWeight", "lblTotalWeight", "txtTotalWeight", "lblCustomerID", "txtCustomerID"}).ToList()
        activateControls(currentActiveControls)

        txtScannerEntry.Focus()
    End Sub

    Private Sub rbuBinLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuTubTag.CheckedChanged, rbuBinLabel.CheckedChanged
        If rbuBinLabel.Checked Then
            resetControls(currentActiveControls)
            'Bin Label
            BarCodeType = 6

            setBinLabelPosition()
        End If
    End Sub

    Private Sub setBinLabelPosition()
        lblRackingLocation.Location = New Point(327, 65)
        txtRackingLocation.Location = New Point(330, 80)
        txtRackingLocation.TabIndex = 0
        lblRackingLocation2.Location = New Point(327, 105)
        txtRackingLocation2.Location = New Point(330, 120)
        txtRackingLocation2.TabIndex = 1

        nbrPrintAmount.TabIndex = 2
        cmdClear.TabIndex = 3
        cmdPrintLabel.TabIndex = 4
        cmdExit.TabIndex = 5

        currentActiveControls = (New String() {"lblRackingLocation", "txtRackingLocation", "lblRackingLocation2", "txtRackingLocation2"}).ToList()
        activateControls(currentActiveControls)
        txtRackingLocation.Focus()
    End Sub

    Private Sub rbuBranam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuBranam.CheckedChanged
        If rbuBranam.Checked Then
            resetControls(currentActiveControls)
            'Branam Label
            BarCodeType = 7

            setBranamPosition()
            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub setBranamPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 1
        lblPartNumber.Location = New Point(327, 145)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 2
        lblShortDescription.Location = New Point(327, 185)
        txtShortDescription.Location = New Point(330, 200)
        txtShortDescription.TabIndex = 3
        lblQuantity.Location = New Point(327, 225)
        txtQuantity.Location = New Point(330, 240)
        txtQuantity.TabIndex = 4
        lblHarmCode.Location = New Point(456, 225)
        txtHarmCode.Location = New Point(459, 240)
        txtHarmCode.TabIndex = 5
        txtHarmCode.Text = "7318.15.9000"
        lblReference.Location = New Point(327, 265)
        txtReference.Location = New Point(330, 280)
        txtReference.TabIndex = 6
        lblCustomerPO.Location = New Point(327, 305)
        txtCustomerPO.Location = New Point(330, 320)
        txtCustomerPO.TabIndex = 7
        lblSupplierNumber.Location = New Point(456, 305)
        txtSupplierNumber.Location = New Point(459, 320)
        txtSupplierNumber.TabIndex = 8
        txtSupplierNumber.Text = "100254"
        lblCountry.Location = New Point(327, 345)
        txtCountry.Location = New Point(330, 360)
        txtCountry.TabIndex = 9
        txtCountry.Text = "USA"
        lblEngineeringChangeLevel.Location = New Point(327, 385)
        txtEngineeringChangeLevel.Location = New Point(330, 400)
        txtEngineeringChangeLevel.TabIndex = 10

        nbrPrintAmount.TabIndex = 11
        cmdClear.TabIndex = 12
        cmdPrintLabel.TabIndex = 13
        cmdExit.TabIndex = 14

        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblShortDescription", "txtShortDescription", "lblQuantity", "txtQuantity", "lblHarmCode", "txtHarmCode", "lblReference", "txtReference", "lblEngineeringChangeLevel", "txtEngineeringChangeLevel", "lblSupplierNumber", "txtSupplierNumber", "lblCountry", "txtCountry", "lblCustomerPO", "txtCustomerPO"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rbuUniversalWaste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUniversalWaste.CheckedChanged
        If rdoUniversalWaste.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 9

            currentActiveControls = New List(Of String)
            activateControls(currentActiveControls)

            nbrPrintAmount.Focus()
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrPrintAmount.ValueChanged
        NumberOfLables = nbrPrintAmount.Value
        LabelNumberOfLabels = nbrPrintAmount.Value
    End Sub

    Private Sub cmdPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabel.Click
        If canprintLabels() Then
            cmdPrintLabel.Enabled = False

            Select Case BarCodeType
                Case 1
                    standardLabelSetup()
                Case 2
                    masterLabelSetup()
                Case 3
                    bc.MixedLabelSetup(nbrPrintAmount.Value)
                Case 4
                    AddressLabelSetup()
                Case 5
                    bc.setupTubTag(txtSerialLotNumber.Text, nbrPrintAmount.Value)
                Case 6
                    If canPrintBinLable() Then
                        bc.BinTagLabelSetup(txtRackingLocation.Text, txtRackingLocation2.Text, nbrPrintAmount.Value)
                    End If
                Case 7
                    BranamLabelSetup()
                Case 8
                    If canPrintYard() Then
                        bc.setupYardLabel(cboCoilID.Text, nbrPrintAmount.Value)
                    End If
                Case 9
                    bc.UniversalWasteSetup(nbrPrintAmount.Value)
                Case 10
                    ValeoLabelSetup()
                Case 11
                    NavistarLableSetup()
                Case 12
                    DelphiLabelSetup()
                Case 13
                    blankLineLabelPrint()
                Case 15
                    bc.setupTempLabel("201-855625-00", nbrPrintAmount.Value)
                Case 16
                    bc.SetupSampleLabel(txtAnnealingLotNumber.Text)
                Case 17
                    AddressLabelSetup()
                Case 18
                    bc.MixedHeatLabelSetup(nbrPrintAmount.Value)
                Case 19
                    bc.ZincLabelSetup(nbrPrintAmount.Value)
                Case 20
                    bc.NickelLabelSetup(nbrPrintAmount.Value)
                Case 21
                    bc.StainlessLabelSetup(nbrPrintAmount.Value)
                Case 22
                    FryerLabelSetup()
                Case 23
                    bc.PartialPalletLabelSetup()
                Case 24
                    blank3LineLabelPrint()
                Case 25
                    PrintCustom()
                Case 26
                    bc.PalletBinLabelSetup(txtRackingLocation.Text, nbrPrintAmount.Value)
                Case 27
                    NordicLabelSetup()
                Case Else
                    BarCodeType = 0
            End Select

            If BarCodeType = 17 Then
                LabelNumberOfLabels = nbrPrintAmount.Value

                'Fill variables
                FillShippingLabelVariables()

                'Check to see if special label exists
                CheckIfSpecialLabelExists()

                'Write to database that label was printed
                InsertIntoShippingLabelTable()

                'Print Special Pallet Label if necessary
                If LabelDoesSpecialLabelExist = "YES" Then
                    'Print
                    SetupAndPrintSpecialLabel()
                Else
                    'Don't print
                End If
            End If

            If BarCodeType <> 0 And canPrint And BarCodeType <> 25 Then
                If BarCodeType <> 26 Or (BarCodeType = 26 And String.IsNullOrEmpty(cboArrowDirection.Text)) Then
                    bc.PrintBarcodeLine()
                Else
                    bc.BinLabelWithArrow(txtRackingLocation.Text, nbrPrintAmount.Value, cboArrowDirection.Text)
                End If
            Else
                canPrint = True
            End If
            cmdPrintLabel.Enabled = True
        End If

    End Sub

    Private Sub blank3LineLabelPrint()
        Dim First As New List(Of String)
        First.Add(txtBlankLineOne.Text)
        First.Add(txtBlankLineTwo.Text)
        First.Add(txtBlankLineThree.Text)

        bc.blank3LineLabelPrint(First, LabelNumberOfLabels)
        bc.PrintBarcodeLine()
    End Sub

    Private Sub SetupAndPrintSpecialLabel()
        txtBlankLineOne.Text = SpecialLabelLine1
        txtBlankLineTwo.Text = SpecialLabelLine2
        txtBlankLineThree.Text = SpecialLabelLine3

        blank3LineLabelPrint()
    End Sub

    Private Sub InsertIntoShippingLabelTable()
        'Insert into table
        cmd = New SqlCommand("INSERT INTO ShippingAddressLabels (SalesOrderNumber, PickTicketNumber, LabelsPrinted, Username, DivisionID) values (@SalesOrderNumber, @PickTicketNumber, @LabelsPrinted, @Username, @DivisionID)", con)

        With cmd.Parameters
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = LabelSalesOrderNumber
            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = LabelPickTicketNumber
            .Add("@LabelsPrinted", SqlDbType.VarChar).Value = LabelDoesSpecialLabelExist
            .Add("@Username", SqlDbType.VarChar).Value = LabelUsername
            .Add("@DivisionID", SqlDbType.VarChar).Value = LabelDivisionID
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub CheckIfSpecialLabelExists()
        Dim CheckForLabelStatement As String = "SELECT * FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey"
        Dim CheckForLabelCommand As New SqlCommand(CheckForLabelStatement, con)
        CheckForLabelCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicket.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CheckForLabelCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SpecialLabelLine1")) Then
                SpecialLabelLine1 = ""
            Else
                SpecialLabelLine1 = reader.Item("SpecialLabelLine1")
            End If
            If IsDBNull(reader.Item("SpecialLabelLine2")) Then
                SpecialLabelLine2 = ""
            Else
                SpecialLabelLine2 = reader.Item("SpecialLabelLine2")
            End If
            If IsDBNull(reader.Item("SpecialLabelLine3")) Then
                SpecialLabelLine3 = ""
            Else
                SpecialLabelLine3 = reader.Item("SpecialLabelLine3")
            End If
        Else
            SpecialLabelLine1 = ""
            SpecialLabelLine2 = ""
            SpecialLabelLine3 = ""
        End If
        reader.Close()
        con.Close()

        If SpecialLabelLine1 = "" And SpecialLabelLine2 = "" And SpecialLabelLine3 = "" Then
            LabelDoesSpecialLabelExist = "NO"
        Else
            LabelDoesSpecialLabelExist = "YES"
        End If
    End Sub

    Private Sub FillShippingLabelVariables()
        'Get Sales Order Number
        Dim GetSONumberStatement As String = "SELECT SalesOrderHeaderKey FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey"
        Dim GetSONumberCommand As New SqlCommand(GetSONumberStatement, con)
        GetSONumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(txtPickTicket.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LabelSalesOrderNumber = CInt(GetSONumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LabelSalesOrderNumber = 0
        End Try
        con.Close()

        LabelPickTicketNumber = Val(txtPickTicket.Text)
        LabelDivisionID = EmployeeCompanyCode
        LabelUsername = EmployeeLoginName
    End Sub

    Private Function canprintLabels() As Boolean
        If txtSerialLotNumber.Visible Then
            Return ValidLot()
        End If
        Return True
    End Function

    Private Function ValidLot() As Boolean
        cmd = New SqlCommand("SELECT isnull(Status,'OPEN') as Status, isnull(QCInspected, '') as QCInspected FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            If reader.Item("Status").Equals("OPEN") Then
                reader.Close()
                con.Close()
                MessageBox.Show("Lot entered has not been completed by QC. Contact QC, unable to print labels.", "Unable to print labels", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            If reader.Item("QCInspected").Equals("NO") Then
                reader.Close()
                con.Close()
                MessageBox.Show("Lot has not been checked for final piece inspection. Contact QC, to perform final piece inspection.", "Unable to print labels", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            reader.Close()
            con.Close()
            MessageBox.Show("Lot does not exist.", "Unable to print labels", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        reader.Close()
        con.Close()
        Return True
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadLotNumberData()
        Dim PartNumberString As String = "SELECT PartNumber, HeatNumber, ItemList.BoxCount, ItemList.PalletCount * ItemList.BoxCount as PalletPieces, ItemList.PalletCount * (case when isnull(itemlist.BoxWeight, ItemList.PieceWeight * ItemList.BoxCount) = 0 then (ItemList.PieceWeight * ItemList.BoxCount) else isnull(itemlist.BoxWeight, ItemList.PieceWeight * ItemList.BoxCount) end) as PalletWeight, (case when isnull(itemlist.BoxWeight, ItemList.PieceWeight * ItemList.BoxCount) = 0 then (ItemList.PieceWeight * ItemList.BoxCount) else isnull(itemlist.BoxWeight, ItemList.PieceWeight * ItemList.BoxCount) end) as BoxWeight, LotNumber.BoxType, LotNumber.ShortDescription, LotNumber.LongDescription, LotNumber.FOXNumber, SteelType, SteelSize, AnnealedHeatNumber FROM LotNumber LEFT OUTER JOIN (SELECT * FROM ItemList WHERE DivisionID = 'TWD' OR DivisionID = 'TFP') as ItemList on LotNumber.PartNumber = ItemList.ItemID  WHERE LotNumber = @LotNumber;"
        Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
        PartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = PartNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                BoxCount = 0
            Else
                BoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                PalletPieces = 0
            Else
                PalletPieces = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("PalletWeight")) Then
                PalletWeight = 0
            Else
                PalletWeight = Math.Ceiling(reader.Item("PalletWeight"))
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                BoxWeight = 0
            Else
                BoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("BoxType")) Then
                BoxType = ""
            Else
                BoxType = reader.Item("BoxType")
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
            If IsDBNull(reader.Item("FOXNumber")) Then
                txtFoxNumber.Text = ""
            Else
                txtFoxNumber.Text = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("SteelType")) Then
                txtSteelCarbon.Text = ""
            Else
                txtSteelCarbon.Text = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                txtSteelSize.Text = ""
            Else
                txtSteelSize.Text = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("AnnealedHeatNumber")) Then
                AnnealHeat = ""
            Else
                AnnealHeat = reader.Item("AnnealedHeatNumber")
            End If
        Else
            PartNumber = ""
            HeatNumber = ""
            BoxCount = 0
            PalletPieces = 0
            PalletWeight = 0
            BoxWeight = 0
            BoxType = ""
            ShortDescription = ""
            LongDescription = ""
            txtFoxNumber.Text = ""
            txtSteelCarbon.Text = ""
            txtSteelSize.Text = ""
            AnnealHeat = ""
        End If
        reader.Close()
        con.Close()

        If rbuStandardBarcode.Checked Then
            loadBinLocations()
        End If
        If rbuTubTag.Checked Then
            loadFoxTableData()
        End If
        txtQuantityPerPallet.Text = PalletPieces
        txtWeightPerPallet.Text = PalletWeight
        txtQuantityPerBox.Text = BoxCount
        txtWeightPerBox.Text = BoxWeight
        'txtContainer.Text = BoxType
        txtHeatNumber.Text = HeatNumber
        txtPartNumber.Text = PartNumber
        txtShortDescription.Text = ShortDescription
        txtLongDescription.Text = LongDescription
    End Sub

    Private Sub LoadCustomerPO()
        If Not String.IsNullOrEmpty(txtSerialLotNumber.Text) Then
            cmd = New SqlCommand("SELECT isnull(CustomerPO, 0) FROM SalesOrderHeaderTable WHERE SalesOrderKey = (SELECT OrderReferenceNumber FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM LotNumber WHERE LotNumber = @LotNumber))", con)
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                txtCustomerPO.Text = ""
            Catch ex As System.Exception
                txtCustomerPO.Text = ""
            End Try
        End If
    End Sub

    Private Sub LoadBranamData()
        Dim PartNumberString As String = "SELECT PartNumber, ShortDescription, BoxCount FROM LotNumber WHERE LotNumber = @LotNumber;"
        Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
        PartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = PartNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                ShortDescription = ""
            Else
                ShortDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                BoxCount = 0
            Else
                BoxCount = reader.Item("BoxCount")
            End If
        Else
            PartNumber = ""
            ShortDescription = ""
            BoxCount = 0
        End If
        reader.Close()
        con.Close()

        If rbuStandardBarcode.Checked Then
            loadBinLocations()
        End If
        If rbuTubTag.Checked Then
            loadFoxTableData()
        End If
        txtPartNumber.Text = PartNumber
        txtShortDescription.Text = ShortDescription
        txtQuantity.Text = BoxCount.ToString
    End Sub

    Private Sub loadBinLocations()
        cboRackingLocation.Items.Clear()
        cboRackingLocation.Text = ""
        cmd = New SqlCommand("SELECT BinNumber FROM RackingTransactionTable WHERE LotNumber = @LotNumber;", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            Do While reader.Read()
                cboRackingLocation.Items.Add(reader.Item("BinNumber"))
            Loop
        End If
        con.Close()
        If cboRackingLocation.Items.Count > 0 Then
            cboRackingLocation.SelectedIndex = 0
        End If
    End Sub

    Private Sub loadFoxTableData()
        cmd = New SqlCommand("SELECT BlueprintNumber, FinishedWeight, ScrapWeight, CustomerID, PromiseDate, ProductionQuantity  FROM FOXTable WHERE FOXNumber = @FoxNumber;", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = txtFoxNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                txtBlueprintNumber.Text = ""
            Else
                txtBlueprintNumber.Text = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("FinishedWeight")) Then
                txtFinishedWeight.Text = ""
            Else
                txtFinishedWeight.Text = reader.Item("FinishedWeight")
            End If
            If IsDBNull(reader.Item("ScrapWeight")) Then
                txtTotalWeight.Text = "0"
            Else
                txtTotalWeight.Text = reader.Item("FinishedWeight") + reader.Item("ScrapWeight")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                txtCustomerID.Text = ""
            Else
                txtCustomerID.Text = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("PromiseDate")) Then
                txtDate.Text = ""
            Else
                txtDate.Text = reader.Item("PromiseDate")
            End If
            If IsDBNull(reader.Item("ProductionQuantity")) Then
                txtProductionQuantity.Text = "0"
            Else
                txtProductionQuantity.Text = reader.Item("ProductionQuantity")
            End If
        Else
            txtBlueprintNumber.Text = ""
            txtCustomerID.Text = ""
            txtTotalWeight.Text = "0"
            txtDate.Text = ""
            txtProductionQuantity.Text = "0"
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub txtSerialLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerialLotNumber.TextChanged, txtSerialLotNumber.TextChanged
        If txtSerialLotNumber.Text.Length > 8 Then
            Select Case BarCodeType
                ''master label (FOX LABEL) (BOX LABEL)
                Case 2
                    LoadLotNumberData()
                    If Not String.IsNullOrEmpty(txtPartNumber.Text) And txtPartNumber.Text.Length > 3 Then
                        If txtPartNumber.Text.StartsWith("DBA") Or txtPartNumber.Text.StartsWith("CA") Or txtPartNumber.Text.StartsWith("SC") Or txtPartNumber.Text.StartsWith("DSC") Or txtPartNumber.Text.StartsWith("PSR") Then
                            lblShiftNumber.Location = New Point(456, 345)
                            cboShiftNumber.Location = New Point(459, 360)
                            If txtPartNumber.Text.StartsWith("DBA") Then
                                txtESRNumber.Text = "ESR 2823"
                                txtESRNumber.ReadOnly = False
                            ElseIf txtPartNumber.Text.StartsWith("CA") Or txtPartNumber.Text.StartsWith("SC") Or txtPartNumber.Text.StartsWith("DSC") Then
                                If txtPartNumber.Text.StartsWith("SCR") Then
                                    txtESRNumber.Text = "N/A"
                                    txtESRNumber.ReadOnly = True
                                Else
                                    txtESRNumber.Text = "ESR 2577"
                                    txtESRNumber.ReadOnly = False
                                End If
                            ElseIf txtPartNumber.Text.StartsWith("PSR") Then
                                txtESRNumber.Text = "ESR 2822"
                                txtESRNumber.ReadOnly = False
                            Else
                                txtESRNumber.Text = "N/A"
                                txtESRNumber.ReadOnly = True
                            End If

                            txtCustomerPO.TabIndex = 10
                            txtESRNumber.TabIndex = 11
                            txtCountry.TabIndex = 12

                            nbrPrintAmount.TabIndex = 13
                            cmdClear.TabIndex = 14
                            cmdPrintLabel.TabIndex = 15
                            cmdExit.TabIndex = 16
                            currentActiveControls.Add("lblShiftNumber")
                            currentActiveControls.Add("cboShiftNumber")
                            activateControls(currentActiveControls)
                        Else
                            lblShiftNumber.Visible = False
                            cboShiftNumber.Visible = False
                            If currentActiveControls.Contains("lblShiftNumber") Then
                                currentActiveControls.Remove("lblShiftNumber")
                                currentActiveControls.Remove("cboShiftNumber")
                            End If
                            txtESRNumber.Text = "N/A"
                            txtESRNumber.ReadOnly = True
                            txtCustomerPO.TabIndex = 10
                            txtESRNumber.TabIndex = 11
                            txtCountry.TabIndex = 12

                            nbrPrintAmount.TabIndex = 13
                            cmdClear.TabIndex = 14
                            cmdPrintLabel.TabIndex = 15
                            cmdExit.TabIndex = 16
                            LoadCustomerPO()
                        End If
                    Else
                        lblShiftNumber.Visible = False
                        cboShiftNumber.Visible = False
                        If currentActiveControls.Contains("lblShiftNumber") Then
                            currentActiveControls.Remove("lblShiftNumber")
                            currentActiveControls.Remove("cboShiftNumber")
                        End If
                        txtESRNumber.Text = "N/A"
                        txtESRNumber.ReadOnly = True
                        txtCustomerPO.TabIndex = 9
                        txtESRNumber.TabIndex = 10
                        txtCountry.TabIndex = 11

                        nbrPrintAmount.TabIndex = 12
                        cmdClear.TabIndex = 13
                        cmdPrintLabel.TabIndex = 14
                        cmdExit.TabIndex = 15
                        LoadCustomerPO()
                    End If
                Case 7
                    LoadBranamData()
                    ''Locks all controls except Lot Number and PO Number. This was due to a lack of people not changing the part number to the customer part number for this part.
                    If txtSerialLotNumber.Text.StartsWith("3416") Then
                        If Not txtPartNumber.ReadOnly() Then
                            txtPartNumber.ReadOnly = True
                            txtShortDescription.ReadOnly = True
                            txtHarmCode.ReadOnly = True
                            txtSupplierNumber.ReadOnly = True
                            txtCountry.ReadOnly = True
                            txtEngineeringChangeLevel.ReadOnly = True
                        End If
                        txtPartNumber.Text = "WD00108ABU"
                    ElseIf txtSerialLotNumber.Text.StartsWith("3872") Then
                        If Not txtPartNumber.ReadOnly() Then
                            txtPartNumber.ReadOnly = True
                            txtShortDescription.ReadOnly = True
                            txtHarmCode.ReadOnly = True
                            txtSupplierNumber.ReadOnly = True
                            txtCountry.ReadOnly = True
                            txtEngineeringChangeLevel.ReadOnly = True
                        End If
                        txtPartNumber.Text = "WD00112ADD"
                    ElseIf txtSerialLotNumber.Text.StartsWith("3603") Then
                        If Not txtPartNumber.ReadOnly() Then
                            txtPartNumber.ReadOnly = True
                            txtShortDescription.ReadOnly = True
                            txtHarmCode.ReadOnly = True
                            txtSupplierNumber.ReadOnly = True
                            txtCountry.ReadOnly = True
                            txtEngineeringChangeLevel.ReadOnly = True
                        End If
                        txtPartNumber.Text = "WD00307ADD"
                    ElseIf txtSerialLotNumber.Text.StartsWith("3444") Then
                        If Not txtPartNumber.ReadOnly() Then
                            txtPartNumber.ReadOnly = True
                            txtShortDescription.ReadOnly = True
                            txtHarmCode.ReadOnly = True
                            txtSupplierNumber.ReadOnly = True
                            txtCountry.ReadOnly = True
                            txtEngineeringChangeLevel.ReadOnly = True
                        End If
                        txtPartNumber.Text = "WD00311ADD"
                    Else
                        txtPartNumber.ReadOnly = False
                        txtShortDescription.ReadOnly = False
                        txtHarmCode.ReadOnly = False
                        txtSupplierNumber.ReadOnly = False
                        txtCountry.ReadOnly = False
                        txtEngineeringChangeLevel.ReadOnly = False
                    End If
                Case 8
                    CoilLabelSetup()
                Case 10
                    LoadValeoClimateControlData()
                Case 11

                Case 12

                Case Else
                    LoadLotNumberData()
            End Select
        End If
    End Sub

    Private Sub LoadValeoClimateControlData()

    End Sub

    Private Sub txtEntryBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScannerEntry.TextChanged
        'txtSerialLotNumber.Text = ""
        If txtScannerEntry.Text.Length > 0 Then
            Select Case txtScannerEntry.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScannerEntry.Text.Length = 1 Then
                        txtSerialLotNumber.Text = ""
                    Else
                        txtSerialLotNumber.Text = txtScannerEntry.Text.Substring(1)
                    End If

                Case Else
                    txtSerialLotNumber.Text = txtScannerEntry.Text
            End Select

            If rdoFryerLabel.Checked = True Then
                LoadFryerTextBoxes()
            ElseIf rdoNordicLabel.Checked = True Then
                LoadNordicTextBoxes()
            End If
        End If
    End Sub

    Public Sub LoadCustomerData()
        'Extract data from source table
        Dim ShipToAddress1String As String = "SELECT CustomerList.CustomerName, CustomerList.ShipToAddress1, CustomerList.ShipToAddress2, CustomerList.ShipToCity, CustomerList.ShipToState, CustomerList.ShipToZip, CASE WHEN CountryCodes.Country is null THEN CustomerList.ShipToCountry ELSE CountryCodes.Country END as ShipToCountry  FROM CustomerList LEFT OUTER JOIN CountryCodes ON CustomerList.ShipToCountry = CountryCodes.CountryCode WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID;"
        Dim ShipToAddress1Command As New SqlCommand(ShipToAddress1String, con)
        ShipToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ShipToAddress1Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerName")) Then
                CustomerName = ""
            Else
                CustomerName = reader.Item("CustomerName")
            End If
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                ShipToAddress1 = ""
            Else
                ShipToAddress1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                ShipToAddress2 = ""
            Else
                ShipToAddress2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                ShipToCity = ""
            Else
                ShipToCity = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                ShipToState = ""
            Else
                ShipToState = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                ShipToZip = ""
            Else
                ShipToZip = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                ShipToCountry = ""
            Else
                ShipToCountry = reader.Item("ShipToCountry")
            End If
        Else
            CustomerName = ""
            ShipToAddress1 = ""
            ShipToAddress2 = ""
            ShipToCity = ""
            ShipToState = ""
            ShipToZip = ""
            ShipToCountry = ""
        End If
        reader.Close()
        con.Close()

        'Load customer data into text fields
        txtAddress1.Text = ShipToAddress1
        txtAddress2.Text = ShipToAddress2
        txtCity.Text = ShipToCity
        txtState.Text = ShipToState
        txtZip.Text = ShipToZip
        txtCountry.Text = ShipToCountry
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadCustomerList()
    End Sub

    Private Sub LoadCustomerList()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "CustomerList")
        con.Close()

        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        cboCustomerName.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerData()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        cmdClear_Click(sender, e)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        InitializeBarcodeVariables()
        InitializeFormBoxes()
        If Not cmdPrintLabel.Enabled Then
            cmdPrintLabel.Enabled = True
        End If
    End Sub

    Private Sub rbuValeoClimateControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuValeoClimateControl.CheckedChanged
        If rbuValeoClimateControl.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 10

            setValeoClimateControlPosition()
            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub setValeoClimateControlPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 1
        lblPartNumber.Location = New Point(327, 145)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 2
        lblShortDescription.Location = New Point(327, 185)
        txtShortDescription.Location = New Point(330, 200)
        txtShortDescription.TabIndex = 3
        lblQuantity.Location = New Point(327, 225)
        txtQuantity.Location = New Point(330, 240)
        txtQuantity.TabIndex = 4
        lblCustomerPO.Location = New Point(456, 225)
        txtCustomerPO.Location = New Point(459, 240)
        txtCustomerPO.TabIndex = 5
        lblSupplierNumber.Location = New Point(327, 265)
        txtSupplierNumber.Location = New Point(330, 280)
        txtSupplierNumber.TabIndex = 6
        lblEngineeringChangeLevel.Location = New Point(456, 265)
        txtEngineeringChangeLevel.Location = New Point(459, 280)
        txtEngineeringChangeLevel.TabIndex = 7

        nbrPrintAmount.TabIndex = 8
        cmdClear.TabIndex = 9
        cmdPrintLabel.TabIndex = 10
        cmdExit.TabIndex = 11

        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblShortDescription", "txtShortDescription", "lblQuantity", "txtQuantity", "lblEngineeringChangeLevel", "txtEngineeringChangeLevel", "lblSupplierNumber", "txtSupplierNumber", "lblCustomerPO", "txtCustomerPO"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rbuNavistar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuNavistar.CheckedChanged
        If rbuNavistar.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 11

            setNavistarPosition()
            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub setNavistarPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 1
        lblPartNumber.Location = New Point(327, 145)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 2
        lblShortDescription.Location = New Point(327, 185)
        txtShortDescription.Location = New Point(330, 200)
        txtShortDescription.TabIndex = 3
        lblQuantity.Location = New Point(327, 225)
        txtQuantity.Location = New Point(330, 240)
        txtQuantity.TabIndex = 4
        lblCustomerPO.Location = New Point(456, 225)
        txtCustomerPO.Location = New Point(459, 240)
        txtCustomerPO.TabIndex = 5
        lblSupplierNumber.Location = New Point(327, 265)
        txtSupplierNumber.Location = New Point(330, 280)
        txtSupplierNumber.TabIndex = 6
        lblEngineeringChangeLevel.Location = New Point(456, 265)
        txtEngineeringChangeLevel.Location = New Point(459, 280)
        txtEngineeringChangeLevel.TabIndex = 7

        nbrPrintAmount.TabIndex = 8
        cmdClear.TabIndex = 9
        cmdPrintLabel.TabIndex = 10
        cmdExit.TabIndex = 11

        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblShortDescription", "txtShortDescription", "lblQuantity", "txtQuantity", "lblEngineeringChangeLevel", "txtEngineeringChangeLevel", "lblSupplierNumber", "txtSupplierNumber", "lblCustomerPO", "txtCustomerPO"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rbuDelphi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuDelphi.CheckedChanged
        If rbuDelphi.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 12

            setDelphiPosition()
            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub setDelphiPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblMFGDate.Location = New Point(456, 65)
        txtDate.Location = New Point(459, 80)
        dtpDate.TabIndex = 1
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 2
        lblPartNumber.Location = New Point(327, 145)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 3
        lblShortDescription.Location = New Point(327, 185)
        txtShortDescription.Location = New Point(330, 200)
        txtShortDescription.TabIndex = 4
        lblHeatNumber.Location = New Point(327, 225)
        txtHeatNumber.Location = New Point(330, 240)
        txtHeatNumber.TabIndex = 5
        lblQuantity.Location = New Point(327, 265)
        txtQuantity.Location = New Point(330, 280)
        txtQuantity.TabIndex = 6
        lblEngineeringChangeLevel.Location = New Point(456, 265)
        txtEngineeringChangeLevel.Location = New Point(459, 280)
        txtEngineeringChangeLevel.TabIndex = 7
        lblSupplierNumber.Location = New Point(327, 305)
        txtSupplierNumber.Location = New Point(330, 320)
        txtSupplierNumber.TabIndex = 8
        lblKanBanNumber.Location = New Point(456, 305)
        txtKanBanNumber.Location = New Point(459, 320)
        txtKanBanNumber.TabIndex = 9

        nbrPrintAmount.TabIndex = 10
        cmdClear.TabIndex = 11
        cmdPrintLabel.TabIndex = 12
        cmdExit.TabIndex = 13

        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblMFGDate", "txtDate", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblShortDescription", "txtShortDescription", "lblQuantity", "txtQuantity", "lblEngineeringChangeLevel", "txtEngineeringChangeLevel", "lblSupplierNumber", "txtSupplierNumber", "lblHeatNumber", "txtHeatNumber", "lblKanBanNumber", "txtKanBanNumber"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rbuBlank4Line_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuBlank4Line.CheckedChanged
        If rbuBlank4Line.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 13
            setupBlankLabelPosition()
        End If
    End Sub

    Private Sub setupBlankLabelPosition()
        lblBlankLineOne.Location = New Point(327, 65)
        txtBlankLineOne.Location = New Point(330, 80)
        txtBlankLineOne.TabIndex = 0
        txtBlankLineOne.MaxLength = 25
        lblBlankLineTwo.Location = New Point(327, 105)
        txtBlankLineTwo.Location = New Point(330, 120)
        txtBlankLineTwo.TabIndex = 1
        txtBlankLineTwo.MaxLength = 25
        lblBlankLineThree.Location = New Point(327, 145)
        txtBlankLineThree.Location = New Point(330, 160)
        txtBlankLineThree.TabIndex = 2
        txtBlankLineThree.MaxLength = 25
        lblBlankLineFour.Location = New Point(327, 185)
        txtBlankLineFour.Location = New Point(330, 200)
        txtBlankLineFour.TabIndex = 3
        lblBlankLineFive.Location = New Point(327, 225)
        txtBlankLineFive.Location = New Point(330, 240)
        txtBlankLineFive.TabIndex = 4
        lblBlankLineSix.Location = New Point(327, 265)
        txtBlankLineSix.Location = New Point(330, 280)
        txtBlankLineSix.TabIndex = 5
        lblBlankLineSeven.Location = New Point(327, 305)
        txtBlankLineSeven.Location = New Point(330, 320)
        txtBlankLineSeven.TabIndex = 6
        lblBlankLineEight.Location = New Point(327, 345)
        txtBlankLineEight.Location = New Point(330, 360)
        txtBlankLineEight.TabIndex = 7

        lblBlankLineMessage.Location = New Point(327, 385)

        nbrPrintAmount.TabIndex = 8
        cmdClear.TabIndex = 9
        cmdPrintLabel.TabIndex = 10
        cmdExit.TabIndex = 11

        currentActiveControls = (New String() {"lblBlankLineOne", "txtBlankLineOne", "lblBlankLineTwo", "txtBlankLineTwo", "lblBlankLineThree", "txtBlankLineThree", "lblBlankLineFour", "txtBlankLineFour", "lblBlankLineFive", "txtBlankLineFive", "lblBlankLineSix", "txtBlankLineSix", "lblBlankLineSeven", "txtBlankLineSeven", "lblBlankLineEight", "txtBlankLineEight", "lblBlankLineMessage"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub blankLineLabelPrint()
        Dim lst As New List(Of String)
        lst.Add(txtBlankLineOne.Text)
        lst.Add(txtBlankLineTwo.Text)
        lst.Add(txtBlankLineThree.Text)
        lst.Add(txtBlankLineFour.Text)
        lst.Add(txtBlankLineFive.Text)
        lst.Add(txtBlankLineSix.Text)
        lst.Add(txtBlankLineSeven.Text)
        lst.Add(txtBlankLineEight.Text)

        bc.blankLineLabelPrint(lst, nbrPrintAmount.Value)
    End Sub

    Private Sub rdoCoilYardLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbuCoilYardLabel.CheckedChanged
        If rbuCoilYardLabel.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 8
            setupCoilYardLabelPosition()
        End If
    End Sub

    Private Sub setupCoilYardLabelPosition()
        lblCoilID.Location = New Point(327, 65)
        cboCoilID.Location = New Point(330, 80)
        cboCoilID.TabIndex = 0
        lblCoilCarbon.Location = New Point(327, 105)
        txtCoilCarbon.Location = New Point(330, 120)

        lblCoilSteelSize.Location = New Point(456, 105)
        txtCoilSteelSize.Location = New Point(459, 120)

        lblCoilHeat.Location = New Point(327, 145)
        txtCoilHeat.Location = New Point(330, 160)

        lblCoilWeight.Location = New Point(327, 185)
        txtCoilWeight.Location = New Point(330, 200)

        nbrPrintAmount.TabIndex = 1
        cmdClear.TabIndex = 2
        cmdPrintLabel.TabIndex = 3
        cmdExit.TabIndex = 4

        currentActiveControls = (New String() {"lblCoilID", "cboCoilID", "lblCoilCarbon", "txtCoilCarbon", "lblCoilSteelSize", "txtCoilSteelSize", "lblCoilHeat", "txtCoilHeat", "lblCoilWeight", "txtCoilWeight"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Function CoilYardLabelPrint() As Boolean
        If canPrintYard() Then
            bc.setupYardLabel(cboCoilID.Text, nbrPrintAmount.Value)
        End If
    End Function

    Private Function canPrintYard() As Boolean
        If String.IsNullOrEmpty(cboCoilID.Text) Then
            MessageBox.Show("You must enter a Coil ID", "Enter a Coild ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.Focus()
            Return False
        End If
        If cboCoilID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Coil ID", "Enter a valid Coil ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCoilID.SelectAll()
            cboCoilID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cboCoilID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.SelectedIndexChanged
        If cboCoilID.Focused Then
            cmd = New SqlCommand("SELECT Carbon, SteelSize, HeatNumber, Weight FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID", con)
            cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboCoilID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("Carbon")) Then
                    txtCoilCarbon.Text = ""
                Else
                    txtCoilCarbon.Text = reader.Item("Carbon")
                End If
                If IsDBNull(reader.Item("SteelSize")) Then
                    txtCoilSteelSize.Text = ""
                Else
                    txtCoilSteelSize.Text = reader.Item("SteelSize")
                End If
                If IsDBNull(reader.Item("HeatNumber")) Then
                    txtCoilHeat.Text = ""
                Else
                    txtCoilHeat.Text = reader.Item("HeatNumber")
                End If
                If IsDBNull(reader.Item("Weight")) Then
                    txtCoilWeight.Text = ""
                Else
                    txtCoilWeight.Text = reader.Item("Weight")
                End If
            Else
                txtCoilCarbon.Text = ""
                txtCoilSteelSize.Text = ""
                txtCoilHeat.Text = ""
                txtCoilWeight.Text = ""
            End If
            reader.Close()
            con.Close()
        End If
    End Sub

    Private Sub cboCoilID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoilID.TextChanged
        If cboCoilID.Text.Length > 1 And cboCoilID.Text.Length < 3 Then
            If Char.ToLower(cboCoilID.Text.ElementAt(0)) = "s" Then
                cboCoilID.Text = cboCoilID.Text.Substring(1, cboCoilID.Text.Length - 1)
                cboCoilID.Select(cboCoilID.Text.Length, 0)
            End If
        End If
    End Sub

    Private Sub bgwkCoilLoad_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCoilLoad.DoWork
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification WHERE Status <> 'CLOSED' AND Status <> 'OPEN';", con)
        Dim lst As New List(Of String)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                lst.Add(reader.Item("CoilID"))
            End While
        End If
        reader.Close()
        con.Close()
        e.Result = lst
    End Sub

    Private Sub bgwkCoilLoad_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkCoilLoad.RunWorkerCompleted
        cboCoilID.DataSource = e.Result
    End Sub

    Private Sub rdoAnnealSample_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAnnealSample.CheckedChanged
        If rdoAnnealSample.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 16
            setupAnnealSamplePosition()
        End If
    End Sub

    Private Sub setupAnnealSamplePosition()
        lblAnnealingLotNumber.Location = New Point(327, 65)
        txtAnnealingLotNumber.Location = New Point(330, 80)
        txtAnnealingLotNumber.TabIndex = 0
        txtAnnealingLotNumber.ReadOnly = False

        nbrPrintAmount.TabIndex = 1
        cmdClear.TabIndex = 2
        cmdPrintLabel.TabIndex = 3
        cmdExit.TabIndex = 4

        currentActiveControls = (New String() {"lblAnnealingLotNumber", "txtAnnealingLotNumber"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rdoShippingLabelByPickTicket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoShippingLabelByPickTicket.CheckedChanged
        If rdoShippingLabelByPickTicket.Checked Then
            resetControls(currentActiveControls)
            'Tru-Weld Order Address Label
            BarCodeType = 17

            setShippingAddressPositionByPickTicket()

            txtPickTicket.Focus()
        End If
    End Sub

    Private Sub setShippingAddressPositionByPickTicket()
        ''changing the position of the controls that are needed for the label
        lblPickTicket.Location = New Point(327, 65)
        txtPickTicket.Location = New Point(330, 80)
        txtPickTicket.TabIndex = 0
        lblCustomerName.Location = New Point(327, 105)
        txtCustomerName.Location = New Point(330, 120)
        lblAddress1.Location = New Point(327, 145)
        txtAddress1.Location = New Point(330, 160)
        txtAddress1.TabIndex = 2
        lblAddress2.Location = New Point(327, 185)
        txtAddress2.Location = New Point(330, 200)
        txtAddress2.TabIndex = 3
        lblCity.Location = New Point(327, 225)
        txtCity.Location = New Point(330, 240)
        txtCity.TabIndex = 4
        lblState.Location = New Point(327, 265)
        txtState.Location = New Point(330, 280)
        txtState.TabIndex = 5
        lblZip.Location = New Point(327, 305)
        txtZip.Location = New Point(330, 320)
        txtZip.TabIndex = 6

        nbrPrintAmount.TabIndex = 7
        cmdClear.TabIndex = 8
        cmdPrintLabel.TabIndex = 9
        cmdExit.TabIndex = 10
        ''list of all controls that have been repositioned
        currentActiveControls = (New String() {"lblPickTicket", "txtPickTicket", "lblCustomerName", "txtCustomerName", "lblAddress1", "txtAddress1", "lblAddress2", "txtAddress2", "lblCity", "txtCity", "lblState", "txtState", "lblZip", "txtZip"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub txtPickTicket_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPickTicket.TextChanged
        If txtPickTicket.Text.Length > 5 Then
            cmd = New SqlCommand("SELECT ShipmentHeaderTable.ShipAddress1 as Address1, ShipmentHeaderTable.ShipAddress2 as Address2, ShipmentHeaderTable.ShipCity as City, ShipmentHeaderTable.ShipState as State, ShipmentHeaderTable.ShipZip as Zip, CASE WHEN  CountryCodes.Country is null THEN ShipmentHeaderTable.ShipCountry ELSE CountryCodes.Country END as Country, ShipToName as Name FROM ShipmentHeaderTable LEFT OUTER JOIN CountryCodes ON ShipmentHeaderTable.ShipCountry = CountryCodes.CountryCode WHERE PickTicketNumber = @PickTicket;", con)
            cmd.Parameters.Add("@PickTicket", SqlDbType.Int).Value = Val(txtPickTicket.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("Address1")) Then
                    txtAddress1.Text = ""
                Else
                    txtAddress1.Text = reader.Item("Address1")
                End If
                If IsDBNull(reader.Item("Address2")) Then
                    txtAddress2.Text = ""
                Else
                    txtAddress2.Text = reader.Item("Address2")
                End If
                If IsDBNull(reader.Item("City")) Then
                    txtCity.Text = ""
                Else
                    txtCity.Text = reader.Item("City")
                End If
                If IsDBNull(reader.Item("State")) Then
                    txtState.Text = ""
                Else
                    txtState.Text = reader.Item("State")
                End If
                If IsDBNull(reader.Item("Zip")) Then
                    txtZip.Text = ""
                Else
                    txtZip.Text = reader.Item("Zip")
                End If
                If IsDBNull(reader.Item("Country")) Then
                    txtCountry.Text = ""
                Else
                    txtCountry.Text = reader.Item("Country")
                End If
                If IsDBNull(reader.Item("Name")) Then
                    txtCustomerName.Text = ""
                Else
                    txtCustomerName.Text = reader.Item("Name")
                End If
            End If
            reader.Close()
            con.Close()
        End If
    End Sub

    Private Sub rdoMixedHeat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMixedHeat.CheckedChanged
        ''Mixed Heat
        BarCodeType = 18
        resetControls(currentActiveControls)
        activateControls(New List(Of String))
        nbrPrintAmount.Focus()
    End Sub

    Private Sub rdoZincPlatedLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoZincPlatedLabel.CheckedChanged
        ''Zinc Plated
        BarCodeType = 19
        resetControls(currentActiveControls)
        currentActiveControls = New List(Of String)
    End Sub

    Private Sub rdoNickelPlatedLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNickelPlatedLabel.CheckedChanged
        BarCodeType = 20
        resetControls(currentActiveControls)
        currentActiveControls = New List(Of String)
    End Sub

    Private Sub rdoStainlessSteelLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoStainlessSteelLabel.CheckedChanged
        BarCodeType = 21
        resetControls(currentActiveControls)
        currentActiveControls = New List(Of String)
    End Sub

    Private Sub rdoFryerLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFryerLabel.CheckedChanged
        If rdoFryerLabel.Checked Then
            resetControls(currentActiveControls)
            'Branam Label
            BarCodeType = 22

            SetFryerPosition()
            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub SetFryerPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 1
        lblPartNumber.Location = New Point(327, 145)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 2
        lblShortDescription.Location = New Point(327, 185)
        txtShortDescription.Location = New Point(330, 200)
        txtShortDescription.TabIndex = 3
        lblQuantity.Location = New Point(327, 225)
        txtQuantity.Location = New Point(330, 240)
        txtQuantity.TabIndex = 4
        lblRevisionLevel.Location = New Point(456, 225)
        txtRevisionLevel.Location = New Point(459, 240)
        txtRevisionLevel.TabIndex = 5
        lblCustomerPO.Location = New Point(327, 305)
        txtCustomerPO.Location = New Point(330, 320)
        txtCustomerPO.TabIndex = 6
        lblSupplierNumber.Location = New Point(456, 305)
        txtSupplierNumber.Location = New Point(459, 320)
        txtSupplierNumber.TabIndex = 7
        txtSupplierNumber.Text = "0507"

        nbrPrintAmount.TabIndex = 8
        cmdClear.TabIndex = 9
        cmdPrintLabel.TabIndex = 10
        cmdExit.TabIndex = 11

        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblShortDescription", "txtShortDescription", "lblQuantity", "txtQuantity", "lblRevisionLevel", "txtRevisionLevel", "lblSupplierNumber", "txtSupplierNumber", "lblCustomerPO", "txtCustomerPO"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub rdoNordicLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNordicLabel.CheckedChanged
        If rdoNordicLabel.Checked Then
            resetControls(currentActiveControls)
            'Branam Label
            BarCodeType = 27

            SetNordicPosition()
            txtScannerEntry.Focus()
        End If
    End Sub

    Private Sub SetNordicPosition()
        ''changing the position of the controls that are needed for the label
        lblScannerEntry.Location = New Point(327, 65)
        txtScannerEntry.Location = New Point(330, 80)
        txtScannerEntry.TabIndex = 0
        lblSerialLotNumber.Location = New Point(327, 105)
        txtSerialLotNumber.Location = New Point(330, 120)
        txtSerialLotNumber.TabIndex = 1
        lblPartNumber.Location = New Point(327, 145)
        txtPartNumber.Location = New Point(330, 160)
        txtPartNumber.TabIndex = 2
        lblShortDescription.Location = New Point(327, 185)
        txtShortDescription.Location = New Point(330, 200)
        txtShortDescription.TabIndex = 3
        lblQuantity.Location = New Point(327, 225)
        txtQuantity.Location = New Point(330, 240)
        txtQuantity.TabIndex = 4
        lblRevisionLevel.Location = New Point(456, 225)
        txtRevisionLevel.Location = New Point(459, 240)
        txtRevisionLevel.TabIndex = 5
        lblCustomerPO.Location = New Point(327, 305)
        txtCustomerPO.Location = New Point(330, 320)
        txtCustomerPO.TabIndex = 6
        lblSupplierNumber.Location = New Point(456, 305)
        txtSupplierNumber.Location = New Point(459, 320)
        txtSupplierNumber.TabIndex = 7

        nbrPrintAmount.TabIndex = 8
        cmdClear.TabIndex = 9
        cmdPrintLabel.TabIndex = 10
        cmdExit.TabIndex = 11

        currentActiveControls = (New String() {"lblScannerEntry", "txtScannerEntry", "lblSerialLotNumber", "txtSerialLotNumber", "lblPartNumber", "txtPartNumber", "lblShortDescription", "txtShortDescription", "lblQuantity", "txtQuantity", "lblRevisionLevel", "txtRevisionLevel", "lblSupplierNumber", "txtSupplierNumber", "lblCustomerPO", "txtCustomerPO"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Public Sub LoadNordicTextBoxes()
        Dim GetCommentFromLot As String = ""
        Dim GetBlueprintRevision As String = ""
        Dim GetBoxCount As Double = 0
        Dim GetCustomerPO As String = ""
        Dim GetSONumber As Integer = 0
        Dim GetFOXNumberFromLot As Integer = 0
        Dim GetHeatNumberFromLot As String = ""
        Dim GetBoxWeightFromLot As Double = 0

        Dim GetCommentFromLotStatement As String = "SELECT Comment FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetCommentFromLotCommand As New SqlCommand(GetCommentFromLotStatement, con)
        GetCommentFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        Dim GetBlueprintRevisionStatement As String = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetBlueprintRevisionCommand As New SqlCommand(GetBlueprintRevisionStatement, con)
        GetBlueprintRevisionCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        Dim GetBoxCountStatement As String = "SELECT BoxCount FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetBoxCountCommand As New SqlCommand(GetBoxCountStatement, con)
        GetBoxCountCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        Dim GetFOXNumberFromLotStatement As String = "SELECT FOXNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetFOXNumberFromLotCommand As New SqlCommand(GetFOXNumberFromLotStatement, con)
        GetFOXNumberFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        Dim GetHeatNumberFromLotStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetHeatNumberFromLotCommand As New SqlCommand(GetHeatNumberFromLotStatement, con)
        GetHeatNumberFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        Dim GetBoxWeightFromLotStatement As String = "SELECT BoxWeight FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetBoxWeightFromLotCommand As New SqlCommand(GetBoxWeightFromLotStatement, con)
        GetBoxWeightFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtSerialLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetCommentFromLot = CStr(GetCommentFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            GetCommentFromLot = ""
        End Try
        Try
            GetBlueprintRevision = CStr(GetBlueprintRevisionCommand.ExecuteScalar)
        Catch ex As Exception
            GetBlueprintRevision = ""
        End Try
        Try
            GetBoxCount = CDbl(GetBoxCountCommand.ExecuteScalar)
        Catch ex As Exception
            GetBoxCount = ""
        End Try
        Try
            GetFOXNumberFromLot = CInt(GetFOXNumberFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            GetFOXNumberFromLot = 0
        End Try
        Try
            GetHeatNumberFromLot = CStr(GetHeatNumberFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            GetHeatNumberFromLot = 0
        End Try
        Try
            GetBoxWeightFromLot = CDbl(GetBoxWeightFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            GetBoxWeightFromLot = 0
        End Try
        con.Close()

        'Get Sales Order From FOX
        Dim GetSONumberStatement As String = "SELECT OrderReferenceNumber FROM FOXTable WHERE FOXNumber = @FOXNumber AND DivisionID = @DivisionID"
        Dim GetSONumberCommand As New SqlCommand(GetSONumberStatement, con)
        GetSONumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = GetFOXNumberFromLot
        GetSONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSONumber = CInt(GetSONumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetSONumber = 0
        End Try
        con.Close()

        'Get Customer PO Number from Sales Order
        Dim GetCustomerPOStatement As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim GetCustomerPOCommand As New SqlCommand(GetCustomerPOStatement, con)
        GetCustomerPOCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetSONumber
        GetCustomerPOCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetCustomerPO = CStr(GetCustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            GetCustomerPO = ""
        End Try
        con.Close()

        NordicBoxWeight = CStr(GetBoxWeightFromLot)
        NordicHeatNumber = GetHeatNumberFromLot
        txtSupplierNumber.Text = GetCommentFromLot
        txtQuantity.Text = GetBoxCount
        txtCustomerPO.Text = GetCustomerPO
        txtRevisionLevel.Text = GetBlueprintRevision
    End Sub

    Private Sub rdoPartialPallet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPartialPallet.CheckedChanged
        BarCodeType = 23
        resetControls(currentActiveControls)
        currentActiveControls = New List(Of String)
    End Sub

    Private Sub rdoThreeLineBlank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoThreeLineBlank.CheckedChanged
        If rdoThreeLineBlank.Checked Then
            resetControls(currentActiveControls)
            BarCodeType = 24
            setup3BlankLabelPosition()
        End If
    End Sub

    Private Sub setup3BlankLabelPosition()
        lblBlankLineOne.Location = New Point(327, 65)
        txtBlankLineOne.Location = New Point(330, 80)
        txtBlankLineOne.TabIndex = 0
        txtBlankLineOne.MaxLength = 24
        lblBlankLineTwo.Location = New Point(327, 105)
        txtBlankLineTwo.Location = New Point(330, 120)
        txtBlankLineTwo.TabIndex = 1
        txtBlankLineTwo.MaxLength = 24
        lblBlankLineThree.Location = New Point(327, 145)
        txtBlankLineThree.Location = New Point(330, 160)
        txtBlankLineThree.TabIndex = 2
        txtBlankLineThree.MaxLength = 24

        lbl3BlankLineMessage.Location = New Point(327, 385)

        nbrPrintAmount.TabIndex = 3
        cmdClear.TabIndex = 4
        cmdPrintLabel.TabIndex = 5
        cmdExit.TabIndex = 6

        currentActiveControls = (New String() {"lblBlankLineOne", "txtBlankLineOne", "lblBlankLineTwo", "txtBlankLineTwo", "lblBlankLineThree", "txtBlankLineThree", "lbl3BlankLineMessage"}).ToList()
        activateControls(currentActiveControls)
    End Sub

    Private Sub cmdSelectLabelFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectLabelFile.Click
        Dim fd As New OpenFileDialog
        fd.DefaultExt = ".TFPlbl"
        fd.Filter = "Label(*.TFPlbl)|*.TFPlbl"

        If fd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If ImageObjects IsNot Nothing Then
                If ImageObjects.Count > 0 Then
                    Dim i As Integer = 0
                    While i < pnlCustomFields.Controls.Count
                        If Not pnlCustomFields.Controls(i).Name.StartsWith("cmd") AndAlso Not pnlCustomFields.Controls(i).Name.StartsWith("picbx") Then
                            pnlCustomFields.Controls.RemoveAt(i)
                        Else
                            i += 1
                        End If
                    End While
                    ImageObjects.Clear()
                End If
            Else
                ImageObjects = New Dictionary(Of String, ImageObject)
            End If
            Dim serializer As New BinaryFormatter()
            Using fw As System.IO.FileStream = System.IO.File.OpenRead(fd.FileName)
                ImageObjects = serializer.Deserialize(fw)
            End Using
            Dim Ypos As Integer = 5
            For Each obj As ImageObject In ImageObjects.Values
                If TypeOf obj Is ImageBarcode Then
                    Dim lbl As New System.Windows.Forms.Label
                    lbl.Text = obj.Name + " (Barcode)"
                    lbl.Location = New System.Drawing.Point(10, Ypos)
                    lbl.AutoSize = False
                    lbl.Width = 150
                    Dim txt As New System.Windows.Forms.TextBox
                    txt.Name = obj.Name
                    txt.Text = CType(obj, ImageBarcode).Value
                    txt.Location = New System.Drawing.Point(160, Ypos)
                    txt.Width = 165
                    txt.CharacterCasing = CharacterCasing.Upper
                    AddHandler txt.TextChanged, AddressOf Control_TextChanged
                    pnlCustomFields.Controls.Add(lbl)
                    pnlCustomFields.Controls.Add(txt)
                    Ypos += 30
                ElseIf TypeOf obj Is ImageText Then
                    If CType(obj, ImageText).textEditable Then
                        Dim lbl As New System.Windows.Forms.Label
                        lbl.Text = obj.Name + " (Text)"
                        lbl.Location = New System.Drawing.Point(10, Ypos)
                        lbl.AutoSize = False
                        lbl.Width = 150
                        Dim txt As New System.Windows.Forms.TextBox
                        txt.Name = obj.Name
                        txt.Text = CType(obj, ImageText).Value
                        txt.Location = New System.Drawing.Point(160, Ypos)
                        txt.Width = 165
                        AddHandler txt.TextChanged, AddressOf Control_TextChanged
                        pnlCustomFields.Controls.Add(lbl)
                        pnlCustomFields.Controls.Add(txt)
                        Ypos += 30
                    End If
                End If
            Next
            DrawImage()
        End If
    End Sub

    Private Sub DrawImage()
        Dim bmp = New System.Drawing.Bitmap(600, 400)
        Using gr As System.Drawing.Graphics = Graphics.FromImage(bmp)
            gr.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit
            For i As Integer = 0 To ImageObjects.Count - 1
                If TypeOf ImageObjects.ElementAt(i).Value Is ImageText Then
                    Dim br As New SolidBrush(Color.Black)
                    Dim obj As ImageText = ImageObjects.ElementAt(i).Value

                    Dim fnt As System.Drawing.Font
                    Select Case obj.Style
                        Case "Bold"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Bold, GraphicsUnit.Point)
                        Case "Italic"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Italic, GraphicsUnit.Point)
                        Case "Normal"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                        Case Else
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                    End Select
                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawString(obj.Value, fnt, br, 0, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawString(obj.Value, fnt, br, obj.XPos, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageLine Then
                    Dim obj As ImageLine = ImageObjects.ElementAt(i).Value
                    Dim pn As New Pen(Color.Black, obj.Width)
                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawLine(pn, 0, 0, obj.Length, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawLine(pn, obj.XPos, obj.YPos, obj.XPos + obj.Length, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageImage Then
                    Dim obj As ImageImage = ImageObjects.ElementAt(i).Value
                    If obj.Value IsNot Nothing Then
                        Using pic As Bitmap = New Bitmap(obj.Value.GetThumbnailImage(obj.Width, obj.Height, Nothing, IntPtr.Zero))
                            Dim imgattr As New Imaging.ImageAttributes()

                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                            End If
                        End Using
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageBarcode Then
                    Dim obj As ImageBarcode = ImageObjects.ElementAt(i).Value
                    Dim fnt = New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point)

                    If obj.Value IsNot Nothing Then
                        Dim br As New SolidBrush(Color.Black)
                        Dim tmpImg As Bitmap = barCode39.GetBarcode(obj.Value)
                        Using pic As Bitmap = tmpImg.GetThumbnailImage(tmpImg.Width, obj.Height, Nothing, IntPtr.Zero)
                            Dim imgattr As New Imaging.ImageAttributes()
                            imgattr.SetColorMatrix(grayscale)
                            Dim textSize As SizeF = gr.MeasureString(obj.Value, fnt)
                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(((pic.Width - textSize.Width) / 2), obj.Height + 3))
                                End If

                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using

                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(obj.XPos + ((pic.Width - textSize.Width) / 2), obj.YPos + obj.Height + 3))
                                End If

                            End If
                        End Using
                    End If
                End If
            Next
        End Using
        If picbxCustomLabel.Image IsNot Nothing Then
            picbxCustomLabel.Image.Dispose()
            picbxCustomLabel.Image = Nothing
        End If
        picbxCustomLabel.Image = bmp.GetThumbnailImage(300, 200, Nothing, IntPtr.Zero)
    End Sub

    Private Sub rdoCustomLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCustomLabel.CheckedChanged
        If rdoCustomLabel.Checked Then
            BarCodeType = 25
            resetControls(currentActiveControls)
            currentActiveControls = (New String() {"pnlCustomLabel"}).ToList()
            pnlCustomLabel.Show()
        End If
    End Sub

    Private Sub pnlCustomLabel_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlCustomLabel.VisibleChanged
        If pnlCustomLabel.Visible Then
            Dim i As Integer = 0
            While i < pnlCustomFields.Controls.Count
                If Not pnlCustomFields.Controls(i).Name.StartsWith("cmd") AndAlso Not pnlCustomFields.Controls(i).Name.StartsWith("picbx") Then
                    pnlCustomFields.Controls.RemoveAt(i)
                Else
                    i += 1
                End If
            End While
            If picbxCustomLabel.Image IsNot Nothing Then
                picbxCustomLabel.Image.Dispose()
                picbxCustomLabel.Image = Nothing
            End If
        End If
    End Sub

    Private Sub Control_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TypeOf sender Is System.Windows.Forms.TextBox Then
            Dim obj As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            If obj.Focused Then
                If ImageObjects IsNot Nothing Then
                    If ImageObjects.ContainsKey(obj.Name) Then
                        If TypeOf ImageObjects(obj.Name) Is ImageBarcode Then
                            CType(ImageObjects(obj.Name), ImageBarcode).Value = obj.Text
                        ElseIf TypeOf ImageObjects(obj.Name) Is ImageText Then
                            CType(ImageObjects(obj.Name), ImageText).Value = obj.Text
                        End If
                    End If
                End If
            End If
            DrawImage()
        End If
    End Sub

    Private Sub PrintCustom()
        If CanPrintCustom() Then
            Dim findPrinter As String = "Zebra" + EmployeeCompanyCode

            Dim pd As New PrintDialog()
            Dim i As Integer
            pd.UseEXDialog = True
            Dim doc As New System.Drawing.Printing.PrintDocument()
            pd.Document = doc

            pd.PrinterSettings = New PrinterSettings()
            Dim printers(pd.PrinterSettings.InstalledPrinters.Count) As [String]
            pd.PrinterSettings.InstalledPrinters.CopyTo(printers, 0)
            pd.PrinterSettings.PrinterName = ""


            ''checks to see if the designated printer is present
            While i < printers.Count() - 1
                If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains(findPrinter) Then
                    pd.PrinterSettings.PrinterName = printers(i)
                End If
                i += 1
            End While
            Dim printerName As String = ""
            ''checks to see if a printer was selected and if not will show the dialog
            If String.IsNullOrEmpty(pd.PrinterSettings.PrinterName) Then
                If String.IsNullOrEmpty(printerName) Then
                    pd.PrinterSettings.Copies = nbrPrintAmount.Value
                    ' Open the printer dialog box, and then allow the user to select a printer.
                    If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
                        pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                        pd.PrinterSettings.DefaultPageSettings.Landscape = True

                        doc.PrinterSettings = pd.PrinterSettings
                        AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
                        doc.Print()
                    End If
                Else
                    pd.PrinterSettings.Copies = nbrPrintAmount.Value
                    pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
                    pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                    pd.PrinterSettings.DefaultPageSettings.Landscape = True
                    pd.PrinterSettings.PrinterName = printerName
                    doc.PrinterSettings = pd.PrinterSettings
                    AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
                    doc.Print()
                End If
            Else
                pd.PrinterSettings.Copies = nbrPrintAmount.Value
                pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
                pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                pd.PrinterSettings.DefaultPageSettings.Landscape = True
                doc.PrinterSettings = pd.PrinterSettings
                AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
                doc.Print()
            End If
        End If
    End Sub

    Private Function CanPrintCustom() As Boolean
        If ImageObjects.Count = 0 Then
            MessageBox.Show("There is nothing to print", "Nothing to print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintJournalDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim bmp = New System.Drawing.Bitmap(600, 400)
        Using gr As System.Drawing.Graphics = Graphics.FromImage(bmp)
            gr.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit
            For i As Integer = 0 To ImageObjects.Count - 1
                If TypeOf ImageObjects.ElementAt(i).Value Is ImageText Then
                    Dim br As New SolidBrush(Color.Black)

                    Dim obj As ImageText = ImageObjects.ElementAt(i).Value

                    Dim fnt As System.Drawing.Font
                    Select Case obj.Style
                        Case "Bold"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Bold, GraphicsUnit.Point)
                        Case "Italic"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Italic, GraphicsUnit.Point)
                        Case "Normal"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                        Case Else
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                    End Select

                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawString(obj.Value, fnt, br, 0, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawString(obj.Value, fnt, br, obj.XPos, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageLine Then
                    Dim obj As ImageLine = ImageObjects.ElementAt(i).Value
                    Dim pn As New Pen(Color.Black, obj.Width)

                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawLine(pn, 0, 0, obj.Length, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawLine(pn, obj.XPos, obj.YPos, obj.XPos + obj.Length, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageImage Then
                    Dim obj As ImageImage = ImageObjects.ElementAt(i).Value
                    If obj.Value IsNot Nothing Then
                        Using pic As Bitmap = New Bitmap(obj.Value.GetThumbnailImage(obj.Width, obj.Height, Nothing, IntPtr.Zero))

                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                            End If
                        End Using
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageBarcode Then
                    Dim obj As ImageBarcode = ImageObjects.ElementAt(i).Value
                    If obj.Value IsNot Nothing Then
                        Dim fnt = New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point)
                        Dim br As New SolidBrush(Color.Black)
                        Dim tmpImg As Bitmap = barCode39.GetBarcode(obj.Value)
                        Using pic As Bitmap = tmpImg.GetThumbnailImage(tmpImg.Width, obj.Height, Nothing, IntPtr.Zero)
                            ''gets the size of the current text
                            Dim textSize As SizeF = gr.MeasureString(obj.Value, fnt)
                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(((pic.Width - textSize.Width) / 2), obj.Height + 3))
                                End If

                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using

                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(obj.XPos + ((pic.Width - textSize.Width) / 2), obj.YPos + obj.Height + 3))
                                End If

                            End If
                        End Using
                    End If
                End If
            Next
        End Using
        ''draws the image on the document being printed
        e.Graphics.DrawImage(bmp, New System.Drawing.Rectangle(0, 0, 600, 400))
    End Sub

    Private Sub rdoPalletBinLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPalletBinLabel.CheckedChanged
        If rdoPalletBinLabel.Checked Then
            BarCodeType = 26
            resetControls(currentActiveControls)
            setPalletBinLabelPosition()
        End If
    End Sub

    Private Sub setPalletBinLabelPosition()
        lblRackingLocation.Location = New Point(327, 65)
        txtRackingLocation.Location = New Point(330, 80)
        txtRackingLocation.TabIndex = 0
        lblArrowDirection.Location = New Point(327, 105)
        cboArrowDirection.Location = New Point(330, 120)
        cboArrowDirection.TabIndex = 1
        nbrPrintAmount.TabIndex = 2
        cmdClear.TabIndex = 3
        cmdPrintLabel.TabIndex = 4
        cmdExit.TabIndex = 5

        currentActiveControls = (New String() {"lblRackingLocation", "txtRackingLocation", "lblArrowDirection", "cboArrowDirection"}).ToList()
        activateControls(currentActiveControls)
        txtRackingLocation.Focus()
    End Sub

    Private Sub txtRackingLocation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRackingLocation.Leave, txtRackingLocation2.Leave
        If Not String.IsNullOrEmpty(CType(sender, System.Windows.Forms.TextBox).Text) Then
            Dim cmd As New SqlCommand("SELECT COUNT(BinNumber) FROM BinNumber WHERE BinNumber = @BinNumber AND DivisionID = @DivisionID AND RackPosition <> 'UNAVAILABLE'", con)
            cmd.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = CType(sender, System.Windows.Forms.TextBox).Text
            If EmployeeCompanyCode.Equals("TFP") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() = 0 Then
                MessageBox.Show("Bin number entered is not a valid bin location. It maybe marked as UNAVAILABLE.", "Unable to use current location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CType(sender, System.Windows.Forms.TextBox).SelectAll()
                CType(sender, System.Windows.Forms.TextBox).Focus()
            End If
            con.Close()
        End If
    End Sub

    Private Sub cmdTestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestButton.Click
        '' bc.TestLabel()
    End Sub

    Private Sub txtQuantityPerBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantityPerBox.TextChanged
        'Get piece weight and calculate weight of box
        Dim GetPieceWeight As Double = 0
        Dim GetBoxQuantity As Integer = 0
        Dim UpdatedBoxWeight As Double = 0

        Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
        GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text
        GetPieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        GetPieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
        con.Close()

        GetBoxQuantity = Val(txtQuantityPerBox.Text)
        UpdatedBoxWeight = GetBoxQuantity * GetPieceWeight
        UpdatedBoxWeight = Math.Round(UpdatedBoxWeight, 0)
        txtWeightPerBox.Text = UpdatedBoxWeight
    End Sub

  
End Class