Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class BarcodeLabel
    Dim bmp As Bitmap
    ''all needed data for the tubtag
    Structure tubTag
        Public LotNumber As String
        Public CustomerID As String
        Public FOXNumber As String
        Public Blueprint As String
        Public BlueprintRev As String
        Public PartNumber As String
        Public dat As String
        Public ProductionQuantity As String
        Public FinishedWeight As String
        Public TotalWeight As String
        Public SteelCarbon As String
        Public SteelSize As String
        Public HeatNumber As String
        Public AnnealLot As String
        Public ShortDescription As String
    End Structure

    ''all data needed for standard label
    Structure standardLabel
        Public quantityPerPallet As String
        Public weightPerPallet As String
        Public heat As String
        Public dat As String
        Public serialLotNumber As String
        Public rackLocation As String
        Public description1 As String
        Public description2 As String
        Public description3 As String
        Public partNumber As String
        Public customerPO As String
        Public country As String
    End Structure

    ''all data needed for standard label
    Structure MasterLabel
        Public quantityPerBox As String
        Public weightPerBox As String
        Public heat As String
        Public dat As String
        Public shift As String
        Public serialLotNumber As String
        Public rackLocation As String
        Public description1 As String
        Public description2 As String
        Public description3 As String
        Public partNumber As String
        Public customerPO As String
        Public esrNumber As String
        Public country As String
    End Structure

    ''used for branam label
    Structure branamLabel
        Public customerPO As String
        Public shortDescription As String
        Public PartNumber As String
        Public reference As String
        Public prductionQty As String
        Public supplierNumber As String
        Public engineeringChangeLvl As String
        Public country As String
        Public serialLot As String
        Public harmCode As String
    End Structure

    ''used for fryer label
    Structure FryerLabel
        Public Lot As String
        Public Quantity As String
        Public SupplierCode As String
        Public PONumber As String
        Public PartNumber As String
        Public PartDescription As String
        Public PartRev As String
    End Structure

    ''used for fryer label
    Structure NordicLabel
        Public Lot As String
        Public Quantity As String
        Public LotComment As String
        Public PONumber As String
        Public PartNumber As String
        Public PartDescription As String
        Public PartRev As String
        Public HeatNumber As String
        Public BoxWeight As String
    End Structure

    ''used for fryer label
    Structure OptimasLabel
        Public OptimasPartNumber As String
        Public OptimasLotNumber As String
        Public OptimasDescription As String
        Public OptimasSupplier As String
        Public OptimasQuantity As String
        Public OptimasPONumber As String
        Public OptimasPOLineNumber As String
        Public OPtimasShipDate As String
        Public OptimasCountryOfOrigin As String
    End Structure

    ''used for item comment label
    Structure itemComment
        Public partNumber As String
        Public description1 As String
        Public description2 As String
        Public description3 As String
        Public comment1 As String
        Public comment2 As String
        Public comment3 As String
        Public additionalComment As String
        Public quantity As String
    End Structure

    Structure shippingPallet
        Public shipTo As String
        Public divisionInfo As String
        Public address1 As String
        Public address2 As String
        Public address3 As String
        Public street As String
        Public country As String
    End Structure

    Structure toolLabel
        Public OD As Double
        Public FirstLen As Double
        Public FirstID As Double
        Public SecondLen As Double
        Public SecondID As Double
        Public ThirdLen As Double
        Public ThirdID As Double
        Public FourthLen As Double
        Public FourthID As Double
        Public blueprint As String
        Public Section As String
        Public Row As String
        Public Column As String
        Public WangType As String
        Public material As String
        Public Dat As String
    End Structure

    ''used for printing labels
    Dim LabelFormat(70), ZLabelFormat(70) As String
    Dim V04, V05, V06 As String
    Dim LabelLines, ZLabelLines As Integer
    Dim printerName As String = ""
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Public Sub clearFormat()
        For i As Integer = 0 To 69
            LabelFormat(i) = ""
            ZLabelFormat(i) = ""
        Next
    End Sub

    ''new Label for steel in inventory
    Public Sub setupYardLabel(ByVal coilID As String, Optional ByVal lblCount As Integer = 2)
        Dim carb As String = ""
        Dim siz As String = ""
        Dim hea As String = ""
        Dim wei As Double = 0.0
        Dim ann As String = ""

        Dim cmd As SqlCommand = New SqlCommand("SELECT Carbon, SteelSize, HeatNumber, Weight, isnull(AnnealLot, '') as AnnealLot FROM CharterSteelCoilIdentification WHERE CharterSteelCoilIdentification.CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = coilID

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            carb = reader.Item("Carbon")
            siz = reader.Item("SteelSize")
            hea = reader.Item("HeatNumber")
            wei = reader.Item("Weight")
            ann = reader.Item("AnnealLot")
        End If
        reader.Close()
        con.Close()
        If ann.Equals("0") Then
            ann = ""
        End If
        Dim td As String = Today.Date.ToString().Substring(0, Today.Date.ToString().IndexOf(" "))

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        LabelFormat(8) = "A250,40,0,3,2,3,N," + Chr(34) + coilID + Chr(34)
        LabelFormat(9) = "A800,175,1,3,4,3,N," + Chr(34) + coilID + Chr(34)
        LabelFormat(10) = "B720,300,1,3,2,4,102,N," + Chr(34) + coilID + Chr(34)
        LabelFormat(11) = "A590,175,1,2,4,3,N," + Chr(34) + "Carbon - " + carb + Chr(34)
        LabelFormat(12) = "A520,175,1,2,4,3,N," + Chr(34) + "Steel Size - " + siz + Chr(34)
        LabelFormat(13) = "A450,175,1,2,4,3,N," + Chr(34) + "Heat - " + hea + Chr(34)
        LabelFormat(14) = "A380,175,1,2,4,3,N," + Chr(34) + "Weight - " + wei.ToString() + Chr(34)
        LabelFormat(15) = "A310,175,1,2,4,3,N," + Chr(34) + "Lot - " + ann.ToString() + Chr(34)
        LabelFormat(16) = "A240,75,1,2,3,3,N," + Chr(34) + "Date Created - " + td + Chr(34)
        LabelFormat(17) = "A25,100,1,2,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH. 44256 (330) 725-7741" + Chr(34)
        LabelFormat(18) = "A250,1130,0,3,2,3,N," + Chr(34) + coilID + Chr(34)
        LabelFormat(19) = "B250,1030,0,3,2,3,75,N," + Chr(34) + coilID + Chr(34)
        'Print Label
        LabelFormat(20) = "P" + lblCount.ToString()
        LabelLines = 20

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO650,300^AGR,100,12^FD" + coilID + "^FS"
        ZLabelFormat(3) = "^FO570,400^B3R,N,100,N,N^FD" + coilID + "^FS"
        ZLabelFormat(4) = "^FO495,300^AVR,15,12^FDCarbon - " + carb + "^FS"
        ZLabelFormat(5) = "^FO430,300^AVR,15,12^FDSteel Size - " + siz + "^FS"
        ZLabelFormat(6) = "^FO365,300^AVR,15,12^FDHeat - " + hea + "^FS"
        ZLabelFormat(7) = "^FO300,300^AVR,15,12^FDWeight - " + wei.ToString() + "^FS"
        ZLabelFormat(8) = "^FO240,300^AVR,15,12^FDLot - " + ann + "^FS"
        ZLabelFormat(9) = "^FO170,300^AVR,15,12^FDDate Created - " + td + "^FS"
        ZLabelFormat(10) = "^FO20,50^AAR,20,10^FDTFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(11) = "^FO300,30^ADN,50,20^FD" + coilID + "^FS"
        ZLabelFormat(12) = "^FO300,1175^ADN,50,20^FD" + coilID + "^FS"
        ZLabelFormat(13) = "^FO170,1075^B3N,N,75,N,N^FD" + coilID + "^FS"
        ZLabelFormat(14) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(15) = "^XZ"
        ZLabelLines = 15
    End Sub

    ''setsup a label for Mixed Load
    Public Sub MixedLabelSetup(Optional ByVal lblCount As Integer = 1)

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "MIXED" + Chr(34)
        LabelFormat(15) = "A374,540,1,5,4,3,N," + Chr(34) + "LOAD" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + lblCount.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO50,50^GB700,1140,10,B0^FS"
        ZLabelFormat(3) = "^FO400,150^AGR,300,100^FDMIXED^FS"
        ZLabelFormat(4) = "^FO50,550^AGR,300,100^FDLOAD^FS"
        ZLabelFormat(5) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(6) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(7) = "^XZ"
        ZLabelLines = 7
    End Sub

    ''setsup a label for Mixed Load
    Public Sub StainlessLabelSetup(Optional ByVal lblCount As Integer = 1)

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,145,1,5,4,3,N," + Chr(34) + "STAINLESS" + Chr(34)
        LabelFormat(15) = "A374,540,1,5,4,3,N," + Chr(34) + "STEEL" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + lblCount.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO50,50^GB700,1140,10,B0^FS"
        ZLabelFormat(3) = "^FO400,100^AGR,300,100^FDSTAINLESS^FS"
        ZLabelFormat(4) = "^FO50,550^AGR,300,100^FDSTEEL^FS"
        ZLabelFormat(5) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(6) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(7) = "^XZ"
        ZLabelLines = 7
    End Sub

    ''setsup a label for Mixed Load
    Public Sub ZincLabelSetup(Optional ByVal lblCount As Integer = 1)

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "ZINC" + Chr(34)
        LabelFormat(15) = "A374,440,1,5,4,3,N," + Chr(34) + "PLATED" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + lblCount.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO50,50^GB700,1140,10,B0^FS"
        ZLabelFormat(3) = "^FO400,150^AGR,300,100^FDZINC^FS"
        ZLabelFormat(4) = "^FO50,450^AGR,300,100^FDPLATED^FS"
        ZLabelFormat(5) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(6) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(7) = "^XZ"
        ZLabelLines = 7
    End Sub

    ''setsup a label for Mixed Load
    Public Sub NickelLabelSetup(Optional ByVal lblCount As Integer = 1)

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "NICKEL" + Chr(34)
        LabelFormat(15) = "A374,440,1,5,4,3,N," + Chr(34) + "PLATED" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + lblCount.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO50,50^GB700,1140,10,B0^FS"
        ZLabelFormat(3) = "^FO400,150^AGR,300,100^FDNICKEL^FS"
        ZLabelFormat(4) = "^FO50,450^AGR,300,100^FDPLATED^FS"
        ZLabelFormat(5) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(6) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(7) = "^XZ"
        ZLabelLines = 7
    End Sub

    ''setsup a label for Mixed Load
    Public Sub PartialPalletLabelSetup(Optional ByVal lblCount As Integer = 1)

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "PARTIAL" + Chr(34)
        LabelFormat(15) = "A374,440,1,5,4,3,N," + Chr(34) + "PALLET" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + lblCount.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO50,50^GB700,1140,10,B0^FS"
        ZLabelFormat(3) = "^FO400,150^AGR,300,100^FDPARTIAL^FS"
        ZLabelFormat(4) = "^FO50,250^AGR,300,100^FDPALLET^FS"
        ZLabelFormat(5) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(6) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(7) = "^XZ"
        ZLabelLines = 7
    End Sub

    ''Setup for Universal Waste Label
    Public Sub UniversalWasteSetup(Optional ByVal lblCount As Integer = 1)

        'Standard 4x6 AIAG Label setup

        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage

        LabelFormat(8) = "A35,10,1,3,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH 44256 330-725-7741" + Chr(34)
        LabelFormat(9) = "A662,40,1,5,2,1,N," + Chr(34) + "UNIVERSAL WASTE -- LAMPS/BULBS" + Chr(34)
        LabelFormat(10) = "A450,40,1,4,2,1,N," + Chr(34) + "ACCUMULATION START DATE:" + Chr(34)
        LabelFormat(11) = "A300,40,1,4,2,1,N," + Chr(34) + "TYPE OF LAMP:" + Chr(34)
        LabelFormat(12) = "A150,40,1,4,2,1,N," + Chr(34) + "FINAL QUANTITY:" + Chr(34)

        'Print Label

        LabelFormat(13) = "P" + lblCount.ToString()
        LabelFormat(14) = vbFormFeed
        LabelLines = 13

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO550,100^AVR,150,100^FDUNIVERSAL WASTE -- LAMPS/BULBS^FS"
        ZLabelFormat(3) = "^FO450,100^ASR,15,12^FDACCUMULATION START DATE:^FS"
        ZLabelFormat(4) = "^FO300,100^ASR,15,12^FDTYPE OF LAMP:^FS"
        ZLabelFormat(5) = "^FO150,100^ASR,15,12^FDFINAL QUANTITY:^FS"
        ZLabelFormat(6) = "^FO20,50^AAR,20,10^FDTFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(7) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(8) = "^XZ"
        ZLabelLines = 8
    End Sub

    Public Sub AddressLabelSetup(ByVal lst As String(), Optional ByVal lblCount As Integer = 1)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes
        LabelFormat(8) = "LO60,900,1,100"
        LabelFormat(9) = "LO60,950,1,100"

        'Fill in Verbiage
        LabelFormat(10) = "A35,10,1,3,1,1,N," + Chr(34) + lst(0).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + Chr(34)
        LabelFormat(11) = "A662,40,1,5,2,1,N," + Chr(34) + lst(1).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + Chr(34)
        LabelFormat(12) = "A554,40,1,5,2,1,N," + Chr(34) + lst(2).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + Chr(34)
        LabelFormat(13) = "A432,40,1,5,2,1,N," + Chr(34) + lst(3).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + Chr(34)
        LabelFormat(14) = "A323,40,1,5,2,1,N," + Chr(34) + lst(4).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + Chr(34)
        LabelFormat(15) = "A223,40,1,5,2,1,N," + Chr(34) + lst(5).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + Chr(34)
        LabelFormat(16) = "A100,700,1,4,2,1,N," + Chr(34) + "PALLET        OF" + Chr(34)

        'Print Label
        LabelFormat(17) = "P" + lblCount.ToString()
        LabelFormat(18) = vbFormFeed
        LabelLines = 17

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO600,100^A0R,150,75^FD" + lst(1).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + "^FS"
        ZLabelFormat(3) = "^FO475,100^A0R,150,75^FD" + lst(2).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + "^FS"
        ZLabelFormat(4) = "^FO350,100^A0R,150,75^FD" + lst(3).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + "^FS"
        ZLabelFormat(5) = "^FO225,100^A0R,150,75^FD" + lst(4).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + "^FS"
        ZLabelFormat(6) = "^FO100,100^A0R,150,75^FD" + lst(5).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper() + "^FS"
        ZLabelFormat(7) = "^FO50,700^ASR,15,12^FDPALLET             OF^FS"
        ZLabelFormat(8) = "^FO20,50^AAR,20,10^FD" + lst(0) + "^FS"
        ZLabelFormat(9) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(10) = "^XZ"
        ZLabelLines = 10
    End Sub

    ''setup a label for TFP
    Private Sub TFPAddressLabelSetup(Optional ByVal lblCount As Integer = 1)

        'Standard 4x6 AIAG Label setup

        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage

        LabelFormat(8) = "A35,300,1,3,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH 44256 330-725-7741" + Chr(34)
        LabelFormat(9) = "A662,40,1,5,2,1,N," + Chr(34) + "      MADE IN THE USA" + Chr(34)
        LabelFormat(10) = "A454,40,1,5,2,1,N," + Chr(34) + "         TRU-WELD" + Chr(34)
        LabelFormat(11) = "A323,40,1,5,2,1,N," + Chr(34) + " MEDINA, OH.  44256 U.S.A." + Chr(34)
        LabelFormat(12) = "A100,350,1,4,2,1,N," + Chr(34) + "www.truweldstudwelding.com" + Chr(34)

        'Print Label

        LabelFormat(13) = "P" + lblCount.ToString()
        LabelFormat(14) = vbFormFeed
        LabelLines = 13

    End Sub

    Public Sub standardLabelSetup(ByVal stand As standardLabel, Optional ByVal lblCount As Integer = 1)
        Dim cmd As New SqlCommand("SELECT DivisionID, BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = stand.serialLotNumber.Replace("S", "")
        Dim revLevel As String = ""
        Dim division As String = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("DivisionID")) Then
                If reader.Item("DivisionID").ToString.Equals("TFP") Then
                    division = "TFP"
                    If Not IsDBNull(reader.Item("BlueprintRevision")) Then
                        revLevel = reader.Item("BlueprintRevision")
                    End If
                End If
            End If
        End If
        reader.Close()
        con.Close()

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "LO609,8,1,1196"
        LabelFormat(9) = "LO406,8,1,1196"
        LabelFormat(10) = "LO213,8,1,1196"
        LabelFormat(11) = "LO213,479,193,1"
        LabelFormat(12) = "LO213,863,193,1"
        LabelFormat(13) = "LO2,753,211,1"
        LabelFormat(14) = "LO406,650,204,1"
        LabelFormat(15) = "A800,35,1,3,2,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(16) = "A786,552,1,4,2,2,N," + Chr(34) + stand.description1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(17) = "A727,75,1,4,2,2,N," + Chr(34) + stand.description2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(18) = "A668,75,1,4,2,2,N," + Chr(34) + stand.description3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(19) = "A603,35,1,3,2,1,N," + Chr(34) + "(P) PART NUMBER" + Chr(34)

        Dim part As String = ""
        If Not stand.partNumber.ToUpper.StartsWith("P") Then
            part = "P" + stand.partNumber
        Else
            part = stand.partNumber
        End If
        If division.Equals("TFP") Then
            If Not stand.partNumber.ToUpper.Contains("REV. ") And Not part.ToUpper.Contains("REV ") Then
                LabelFormat(20) = "B560,35,1,3,2,4,102,B," + Chr(34) + part + " Rev. " + revLevel + Chr(34)
            Else
                LabelFormat(20) = "B560,35,1,3,2,4,102,B," + Chr(34) + part + Chr(34)
            End If
        Else
            LabelFormat(20) = "B560,35,1,3,2,4,102,B," + Chr(34) + part + Chr(34)
        End If

        LabelFormat(21) = "A398,35,1,3,2,1,N," + Chr(34) + "(Q) QUANTITY" + Chr(34)
        LabelFormat(22) = "B355,35,1,3,2,4,102,B," + Chr(34) + stand.quantityPerPallet + Chr(34)
        LabelFormat(23) = "A207,35,1,3,2,1,N," + Chr(34) + "(EH) HEAT NUMBER" + Chr(34)
        LabelFormat(24) = "B165,35,1,3,2,4,102,B," + Chr(34) + stand.heat + Chr(34)
        LabelFormat(25) = "A398,508,1,3,2,1,N," + Chr(34) + "(W) WEIGHT" + Chr(34)
        LabelFormat(26) = "B355,508,1,3,2,4,102,B," + Chr(34) + stand.weightPerPallet + Chr(34)
        LabelFormat(27) = "A398,871,1,3,2,1,N," + Chr(34) + "DATE" + Chr(34)
        LabelFormat(28) = "A335,871,1,4,2,2,N," + Chr(34) + stand.dat + Chr(34)
        LabelFormat(29) = "A207,772,1,3,2,1,N," + Chr(34) + "BIN" + Chr(34)
        LabelFormat(30) = "B165,772,1,3,2,4,102,B," + Chr(34) + stand.rackLocation + Chr(34)
        LabelFormat(31) = "A597,665,1,3,2,1,N," + Chr(34) + "(S) SERIAL(LOT) NUMBER" + Chr(34)
        LabelFormat(32) = "B550,665,1,3,2,4,102,B," + Chr(34) + stand.serialLotNumber + Chr(34)
        LabelFormat(33) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(34) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(35) = "P" + lblCount.ToString()
        LabelFormat(36) = vbFormFeed
        LabelLines = 35

        ' ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO750,35^ARR,15,12^FDDESCRIPTION^FS"
        ZLabelFormat(3) = "^FO725,600^ATR,80,12^FD" + stand.description1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(4) = "^FO650,75^ATR,80,12^FD" + stand.description2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(5) = "^FO575,75^ATR,80,12^FD" + stand.description3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(6) = "^FO575,10^GB0,1190,5,B0^FS"

        ZLabelFormat(7) = "^FO530,35^ARR,15,12^FD(P) PART NUMBER^FS"
        If division.Equals("TFP") Then
            If Not stand.partNumber.ToUpper.Contains("REV. ") And Not part.ToUpper.Contains("REV ") Then
                ZLabelFormat(8) = "^FO425,35^B3R,N,100,Y,N^FD" + part.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + " Rev. " + revLevel + "^FS"
            Else
                ZLabelFormat(8) = "^FO425,35^B3R,N,100,Y,N^FD" + part.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
            End If
        Else
            ZLabelFormat(8) = "^FO425,35^B3R,N,100,Y,N^FD" + part.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        End If

        ZLabelFormat(9) = "^FO395,600^GB180,0,5,B0^FS"
        ZLabelFormat(10) = "^FO530,665^ARR,15,12^FD(S) SERIAL(LOT) NUMBER^FS"
        ZLabelFormat(11) = "^FO425,665^B3R,N,100,Y,N^FD" + stand.serialLotNumber + "^FS"
        ZLabelFormat(12) = "^FO395,10^GB0,1190,5,B0^FS"

        ZLabelFormat(13) = "^FO355,35^ARR,15,12^FD(Q) QUANTITY^FS"
        ZLabelFormat(14) = "^FO250,35^B3R,N,100,Y,N^FD" + stand.quantityPerPallet + "^FS"
        ZLabelFormat(15) = "^FO220,435^GB180,0,5,B0^FS"
        ZLabelFormat(16) = "^FO355,500^ARR,15,12^FD(W) WEIGHT^FS"
        ZLabelFormat(17) = "^FO250,500^B3R,N,100,Y,N^FD" + stand.weightPerPallet + "^FS"
        ZLabelFormat(18) = "^FO220,860^GB180,0,5,B0^FS"
        ZLabelFormat(19) = "^FO355,870^ARR,15,12^FDDATE^FS"
        ZLabelFormat(20) = "^FO250,870^ATR,80,12^FD" + stand.dat + "^FS"
        ZLabelFormat(21) = "^FO220,10^GB0,1190,5,B0^FS"

        ZLabelFormat(22) = "^FO180,35^ARR,15,12^FD(EH) HEAT NUMBER^FS"
        ZLabelFormat(23) = "^FO75,35^B3R,N,100,Y,N^FD" + stand.heat + "^FS"
        ZLabelFormat(24) = "^FO180,770^ARR,15,12^FDBIN^FS"
        ZLabelFormat(25) = "^FO75,770^B3R,N,100,Y,N^FD" + stand.rackLocation + "^FS"
        ZLabelFormat(26) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(27) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(28) = "^XZ"
        ZLabelLines = 28
    End Sub

    Public Sub setupTempLabel(ByVal LastCoilUsed As String, Optional ByVal lblCount As Integer = 1)
        Dim carb As String = ""
        Dim siz As String = ""
        Dim hea As String = ""

        Dim cmd As SqlCommand = New SqlCommand("SELECT Carbon, SteelSize, HeatNumber FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID;", con)
        cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = LastCoilUsed

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            carb = reader.Item("Carbon")
            siz = reader.Item("SteelSize")
            hea = reader.Item("HeatNumber")
        End If
        reader.Close()
        con.Close()

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        LabelFormat(8) = "A800,400,1,4,4,4,N," + Chr(34) + "Temp Tag" + Chr(34)
        LabelFormat(9) = "A600,100,1,3,4,4,N," + Chr(34) + "ID #" + LastCoilUsed + Chr(34)
        LabelFormat(10) = "B500,400,1,3,2,4,102,N," + Chr(34) + LastCoilUsed + Chr(34)
        LabelFormat(11) = "A350,100,1,3,4,4,N," + Chr(34) + "Carbon - " + carb + Chr(34)
        LabelFormat(12) = "A250,100,1,3,4,4,N," + Chr(34) + "Steel Size - " + siz + Chr(34)
        LabelFormat(13) = "A150,100,1,3,4,4,N," + Chr(34) + "Heat - " + hea + Chr(34)
        LabelFormat(14) = "A35,100,1,2,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH. 44256 (330) 725-7741" + Chr(34)

        'Print Label
        LabelFormat(15) = "P" + lblCount.ToString()
        LabelFormat(16) = vbFormFeed
        LabelLines = 15

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO650,400^ATR,150,75^FDTemp Tag^FS"
        ZLabelFormat(3) = "^FO500,300^A0R,150,75^FDID #" + LastCoilUsed + "^FS"
        ZLabelFormat(4) = "^FO400,400^B3R,N,100,N,N^FD" + LastCoilUsed + "^FS"
        ZLabelFormat(5) = "^FO250,100^A0R,100,75^FDCarbon - " + carb + "^FS"
        ZLabelFormat(6) = "^FO150,100^A0R,100,75^FDSteel Size - " + siz + "^FS"
        ZLabelFormat(7) = "^FO50,100^A0R,100,75^FDHeat - " + hea + "^FS"
        ZLabelFormat(8) = "^FO20,50^AAR,20,10^FDTFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(9) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(10) = "^XZ"
        ZLabelLines = 10
    End Sub

    Public Sub setupTubTag(ByVal lot As String, Optional ByVal lblCount As Integer = 1)
        Dim tag As New tubTag
        tag.LotNumber = lot
        ''fills variables needed for this label
        tubTagVarFill(tag)
        If String.IsNullOrEmpty(tag.TotalWeight) Then
            If Not String.IsNullOrEmpty(tag.FinishedWeight) And Not String.IsNullOrEmpty(tag.ProductionQuantity) Then
                tag.TotalWeight = Math.Round((tag.FinishedWeight / 1000) * tag.ProductionQuantity, 0, MidpointRounding.AwayFromZero).ToString()
            Else
                tag.TotalWeight = "0"
            End If

        End If
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D10"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "A275,10,0,5,1,1,N," + Chr(34) + "TUB TAG" + Chr(34)
        LabelFormat(9) = "B235,65,0,3,2,4,102,B," + Chr(34) + "S" + tag.LotNumber + Chr(34)
        LabelFormat(10) = "LO10,195,790,3"
        LabelFormat(11) = "LO400,198,3,990"
        LabelFormat(12) = "A15,198,0,2,1,1,N," + Chr(34) + "Customer" + Chr(34)
        LabelFormat(13) = "A15,225,0,2,1,2,N," + Chr(34) + tag.CustomerID + Chr(34)
        LabelFormat(14) = "A410,198,0,2,1,1,N," + Chr(34) + "Sign-off" + Chr(34)
        LabelFormat(15) = "A605,198,0,2,1,1,N," + Chr(34) + "Routing" + Chr(34)
        LabelFormat(16) = "A15,0275,0,3,1,1,N," + Chr(34) + "Fox" + Chr(34)
        LabelFormat(17) = "A15,300,0,3,2,2,N," + Chr(34) + tag.FOXNumber + Chr(34)
        LabelFormat(18) = "A195,275,0,3,1,1,N," + Chr(34) + "Blueprint No." + Chr(34)
        LabelFormat(19) = "A195,300,0,3,2,2,N," + Chr(34) + tag.Blueprint + tag.BlueprintRev + Chr(34)
        LabelFormat(20) = "A15,350,0,3,1,1,N," + Chr(34) + "Part Number" + Chr(34)
        LabelFormat(21) = "A15,375,0,3,1,2,N," + Chr(34) + tag.PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(22) = "A15,410,0,3,1,2,N," + Chr(34) + V04 + Chr(34)
        LabelFormat(23) = "A15,445,0,3,1,2,N," + Chr(34) + V05 + Chr(34)
        LabelFormat(24) = "A15,530,0,3,1,1,N," + Chr(34) + "Promised" + Chr(34)
        LabelFormat(25) = "A185,520,0,3,1,2,N," + Chr(34) + tag.dat + Chr(34)
        LabelFormat(26) = "A15,590,0,3,1,1,N," + Chr(34) + "Quantity" + Chr(34)
        LabelFormat(27) = "A185,580,0,3,1,2,N," + Chr(34) + tag.ProductionQuantity + Chr(34)
        LabelFormat(28) = "A15,650,0,3,1,1,N," + Chr(34) + "Fin Wt./M" + Chr(34)
        LabelFormat(29) = "A185,640,0,3,1,2,N," + Chr(34) + tag.FinishedWeight + Chr(34)
        LabelFormat(30) = "A15,710,0,3,1,1,N," + Chr(34) + "Total Wt." + Chr(34)
        LabelFormat(31) = "A185,700,0,3,1,2,N," + Chr(34) + tag.TotalWeight + Chr(34)
        LabelFormat(32) = "A15,750,0,3,1,1,N," + Chr(34) + "Raw Carbon" + Chr(34)
        LabelFormat(33) = "A15,775,0,3,2,3,N," + Chr(34) + tag.SteelCarbon + Chr(34)
        LabelFormat(34) = "A245,750,0,3,1,1,N," + Chr(34) + "Raw Size" + Chr(34)
        LabelFormat(35) = "A235,775,0,3,2,3,N," + Chr(34) + tag.SteelSize + Chr(34)
        LabelFormat(36) = "A15,850,0,3,1,1,N," + Chr(34) + "Heat Number" + Chr(34)
        LabelFormat(37) = "A185,850,0,3,1,2,N," + Chr(34) + tag.HeatNumber + Chr(34)
        LabelFormat(38) = "A15,925,0,3,1,1,N," + Chr(34) + "Ann. Lot No." + Chr(34)
        LabelFormat(39) = "A185,925,0,3,1,2,N," + Chr(34) + tag.AnnealLot + Chr(34)
        LabelFormat(40) = "A155,1000,0,4,1,2,N," + Chr(34) + "DATE" + Chr(34)
        LabelFormat(41) = "A141,1050,0,4,1,2,N," + Chr(34) + "SHIFT" + Chr(34)
        LabelFormat(42) = "A45,1100,0,4,1,2,N," + Chr(34) + "Pcs. in Tub" + Chr(34)
        LabelFormat(43) = "LO255,1035,100,2"
        LabelFormat(44) = "LO255,1085,100,2"
        LabelFormat(45) = "LO255,1135,100,2"
        LabelFormat(46) = "A75,1170,0,3,1,2,N," + Chr(34) + "Keep this tag with the parts through shipping" + Chr(34)

        ' ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO300,30^AVN,15,12^FDTUB TAG^FS"
        ZLabelFormat(3) = "^FO250,100^B3N,N,100,Y,N^FDS" + tag.LotNumber + "^FS"
        ZLabelFormat(4) = "^FO10,225^GB790,0,2,B0^FS"
        ZLabelFormat(5) = "^FO400,225^GB0,960,2,B0^FS"
        ZLabelFormat(6) = "^FO10,225^AQN,15,12^FDCustomer^FS"
        ZLabelFormat(7) = "^FO450,225^AQN,15,12^FDSign-off^FS"
        ZLabelFormat(8) = "^FO700,225^AQN,15,12^FDRouting^FS"
        ZLabelFormat(9) = "^FO10,250^ATN,15,12^FD" + tag.CustomerID + "^FS"
        ZLabelFormat(10) = "^FO10,300^AQN,15,12^FDFOX^FS"
        ZLabelFormat(11) = "^FO200,300^AQN,15,12^FDBlueprint No.^FS"
        ZLabelFormat(12) = "^FO10,325^ATN,20,12^FD" + tag.FOXNumber + "^FS"
        ZLabelFormat(13) = "^FO200,325^ATN,20,12^FD" + tag.Blueprint + tag.BlueprintRev + "^FS"
        ZLabelFormat(14) = "^FO10,375^AQN,15,12^FDPart Number^FS"
        ZLabelFormat(15) = "^FO10,400^ASN,20,12^FD" + tag.PartNumber + "^FS"
        ZLabelFormat(16) = "^FO10,450^ASN,20,12^FD" + V04 + "^FS"
        ZLabelFormat(17) = "^FO10,500^ASN,20,12^FD" + V05 + "^FS"
        ZLabelFormat(18) = "^FO10,550^AQN,15,12^FDPromised^FS"
        ZLabelFormat(19) = "^FO200,550^ATN,20,12^FD" + tag.dat + "^FS"
        ZLabelFormat(20) = "^FO10,600^AQN,15,12^FDQuantity^FS"
        ZLabelFormat(21) = "^FO200,600^ATN,20,12^FD" + tag.ProductionQuantity + "^FS"
        ZLabelFormat(22) = "^FO10,650^AQN,15,12^FDFin Wt./M^FS"
        ZLabelFormat(23) = "^FO200,650^ATN,20,12^FD" + tag.FinishedWeight + "^FS"
        ZLabelFormat(24) = "^FO10,700^AQN,15,12^FDTotal Wt.^FS"
        ZLabelFormat(25) = "^FO200,700^ATN,20,12^FD" + tag.TotalWeight + "^FS"
        ZLabelFormat(26) = "^FO10,750^AQN,15,12^FDRaw Carbon^FS"
        ZLabelFormat(27) = "^FO250,750^AQN,15,12^FDRaw Size^FS"
        ZLabelFormat(28) = "^FO10,775^ATN,20,12^FD" + tag.SteelCarbon + "^FS"
        ZLabelFormat(29) = "^FO250,775^ATN,20,12^FD" + tag.SteelSize + "^FS"
        ZLabelFormat(30) = "^FO10,825^AQN,15,12^FDHeat Number^FS"
        ZLabelFormat(31) = "^FO200,825^ATN,20,12^FD" + tag.HeatNumber + "^FS"
        ZLabelFormat(32) = "^FO10,875^AQN,15,12^FDAnn. Lot No.^FS"
        ZLabelFormat(33) = "^FO200,875^ATN,20,12^FD" + tag.AnnealLot + "^FS"
        ZLabelFormat(34) = "^FO150,950^ATN,15,12^FDDATE^FS"
        ZLabelFormat(35) = "^FO275,990^GB100,0,2,B0^FS"
        ZLabelFormat(36) = "^FO150,1000^ATN,15,12^FDSHIFT^FS"
        ZLabelFormat(37) = "^FO275,1040^GB100,0,2,B0^FS"
        ZLabelFormat(38) = "^FO60,1050^ATN,15,12^FDPcs. in Tub^FS"
        ZLabelFormat(39) = "^FO275,1090^GB100,0,2,B0^FS"
        ZLabelFormat(40) = "^FO100,1180^ARN,20,10^FDKeep this tag with the parts through shipping^FS"


        Dim lineCount As Integer = loadProcess(46, 40, tag.FOXNumber) + 2
        Dim zlineCount As Integer = (lineCount - 46) + 40
        LabelFormat(lineCount) = "P" + lblCount.ToString()
        LabelFormat(lineCount + 1) = vbFormFeed
        LabelLines = lineCount

        ZLabelFormat(zlineCount) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(zlineCount + 1) = "^XZ"
        ZLabelLines = zlineCount + 1
    End Sub

    Private Sub tubTagVarFill(ByRef tag As tubTag)
        Dim PartNumberString As String = "SELECT LotNumber.PartNumber, HeatNumber, ShortDescription, LotNumber.FOXNumber, SteelType, SteelSize, AnnealedHeatNumber, LotNumber.BlueprintNumber, FOXTable.BlueprintRevision, FOXTable.FinishedWeight, CustomerID, PromiseDate, ProductionQuantity FROM LotNumber LEFT OUTER JOIN FOXTable on LotNumber.FOXNumber = FOXTable.FOXNumber WHERE LotNumber = @LotNumber;"
        Dim PartNumberCommand As New SqlCommand(PartNumberString, con)
        PartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = tag.LotNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = PartNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                tag.PartNumber = ""
            Else
                tag.PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                tag.HeatNumber = ""
            Else
                tag.HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                tag.ShortDescription = ""
            Else
                tag.ShortDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                tag.FOXNumber = ""
            Else
                tag.FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("SteelType")) Then
                tag.SteelCarbon = ""
            Else
                tag.SteelCarbon = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                tag.SteelSize = ""
            Else
                tag.SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("AnnealedHeatNumber")) Then
                tag.AnnealLot = ""
            Else
                tag.AnnealLot = reader.Item("AnnealedHeatNumber")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                tag.Blueprint = ""
            Else
                tag.Blueprint = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("BlueprintRevision")) Then
                tag.BlueprintRev = ""
            Else
                tag.BlueprintRev = reader.Item("BlueprintRevision")
            End If
            If IsDBNull(reader.Item("FinishedWeight")) Then
                tag.FinishedWeight = ""
            Else
                tag.FinishedWeight = reader.Item("FinishedWeight")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                tag.CustomerID = ""
            Else
                tag.CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("PromiseDate")) Then
                tag.dat = ""
            Else
                tag.dat = reader.Item("PromiseDate")
            End If
            If IsDBNull(reader.Item("ProductionQuantity")) Then
                tag.ProductionQuantity = ""
            Else
                tag.ProductionQuantity = reader.Item("ProductionQuantity")
            End If
        Else
            tag.PartNumber = ""
            tag.HeatNumber = ""
            tag.ShortDescription = ""
            tag.FOXNumber = ""
            tag.SteelCarbon = ""
            tag.SteelSize = ""
            tag.AnnealLot = ""
            tag.Blueprint = ""
            tag.BlueprintRev = ""
            tag.FinishedWeight = ""
            tag.CustomerID = ""
            tag.dat = ""
            tag.ProductionQuantity = ""
        End If
        reader.Close()
        con.Close()
        If tag.Blueprint.Length > 0 Then
            If Not IsNumeric(tag.Blueprint.ElementAt(tag.Blueprint.Length - 1)) Then
                tag.BlueprintRev = ""
            End If
        End If

        setDescription(tag.ShortDescription)
    End Sub

    Private Sub setDescription(ByVal ShortDescription As String, Optional ByVal cutLength As Integer = 27)
        If ShortDescription.Length > cutLength Then
            V04 = ShortDescription.Substring(0, cutLength)
            If ShortDescription.Length > cutLength * 2 Then
                If ShortDescription.Length > cutLength * 3 Then
                    V06 = ShortDescription.Substring(cutLength * 3, cutLength)
                Else
                    V06 = ShortDescription.Substring(cutLength * 2, ShortDescription.Length - cutLength)
                End If
                V05 = ShortDescription.Substring(cutLength, cutLength)
            Else
                V05 = ShortDescription.Substring(cutLength, ShortDescription.Length - cutLength)
                V06 = ""
            End If
        Else
            V04 = ShortDescription
            V05 = ""
            V06 = ""
        End If
    End Sub

    Private Function loadProcess(ByVal lineCount As Integer, ByVal zlineCount As Integer, ByVal fox As String) As Integer
        Dim yPosition As Integer = 260
        Dim processID As List(Of String) = New List(Of String)
        Dim lineText As List(Of String) = New List(Of String)

        Dim cmd As New SqlCommand("SELECT ProcessID, isnull(Description, '') as Description FROM FOXSched LEFT OUTER JOIN MachineTable ON FOXSched.ProcessID = MachineTable.MachineID AND DivisionID = 'TWD' WHERE FOXNumber = @FOXNumber ORDER BY ProcessStep;", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = fox
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            Do While reader.Read()
                processID.Add(reader.Item("ProcessID").ToString())
                lineText.Add(reader.Item("ProcessID").ToString() + " - " + reader.Item("Description").ToString())
                If lineText(lineText.Count - 1).Length > 20 Then
                    lineText(lineText.Count - 1) = lineText(lineText.Count - 1).Substring(0, 20)
                End If
            Loop
        End If
        reader.Close()

        lineText.Add("")
        lineText.Add("")

        cmd = New SqlCommand("SELECT Certification FROM FOXCertifications WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(fox)
        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            Do While reader.Read()
                lineText.Add(reader.Item("Certification").ToString())
                If lineText(lineText.Count - 1).Length > 23 Then
                    lineText(lineText.Count - 1) = lineText(lineText.Count - 1).Substring(0, 23)
                End If
            Loop
        End If
        con.Close()
        Dim i As Integer = 0
        Dim blankCount As Integer = 0
        While (i < lineText.Count)
            If String.IsNullOrEmpty(lineText(i)) Then
                blankCount += 1
                If blankCount = 2 Then
                    lineCount += 1
                    zlineCount += 1
                    LabelFormat(lineCount) = "A520," + yPosition.ToString() + ",0,3,1,2,N," + Chr(34) + "Certifications" + Chr(34)
                    ZLabelFormat(zlineCount) = "^FO520," + yPosition.ToString() + "^ASN,15,12^FD" + "Certifications" + "^FS"
                End If
            Else
                If blankCount >= 2 Then
                    lineCount += 1
                    zlineCount += 1
                    LabelFormat(lineCount) = "LO410," + Convert.ToString(yPosition + 30) + ",100,2"
                    ZLabelFormat(zlineCount) = "^FO410," + Convert.ToString(yPosition + 30) + "^GB100,0,2,B0^FS"
                    lineCount += 1
                    zlineCount += 1
                    LabelFormat(lineCount) = "A520," + yPosition.ToString() + ",0,2,1,2,N," + Chr(34) + lineText(i) + Chr(34)
                    ZLabelFormat(zlineCount) = "^FO520," + yPosition.ToString() + "^ASN,15,12^FD" + lineText(i) + "^FS"
                Else
                    lineCount += 1
                    zlineCount += 1
                    LabelFormat(lineCount) = "LO410," + Convert.ToString(yPosition + 30) + ",100,2"
                    ZLabelFormat(zlineCount) = "^FO410," + Convert.ToString(yPosition + 30) + "^GB100,0,2,B0^FS"
                    lineCount += 1
                    zlineCount += 1
                    LabelFormat(lineCount) = "A520," + yPosition.ToString() + ",0,3,1,2,N," + Chr(34) + lineText(i) + Chr(34)
                    ZLabelFormat(zlineCount) = "^FO520," + yPosition.ToString() + "^ASN,15,12^FD" + lineText(i) + "^FS"
                End If
            End If
            yPosition += 50
            i += 1
        End While

        Return lineCount
    End Function

    Public Sub masterLabelSetup(ByVal master As MasterLabel, Optional ByVal lblCount As Integer = 1)
        Dim cmd As New SqlCommand("SELECT DivisionID, BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = master.serialLotNumber
        Dim revLevel As String = ""
        Dim division As String = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("DivisionID")) Then
                If reader.Item("DivisionID").ToString.Equals("TFP") Then
                    division = "TFP"
                    If Not IsDBNull(reader.Item("BlueprintRevision")) Then
                        revLevel = reader.Item("BlueprintRevision")
                    End If
                End If
            End If
        End If
        reader.Close()
        con.Close()

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes
        LabelFormat(8) = "LO609,8,1,1196"
        LabelFormat(9) = "LO406,8,1,1196"
        LabelFormat(10) = "LO203,8,1,1196"
        LabelFormat(11) = "LO406,438,204,1"
        LabelFormat(12) = "LO14,812,393,1"
        LabelFormat(13) = "LO203,340,204,1"
        LabelFormat(14) = "LO102,812,1,398"

        'Fill in Verbiage
        LabelFormat(15) = "A35,10,1,3,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH 44256 330-725-7741" + Chr(34)
        LabelFormat(16) = "A794,12,1,3,1,1,N," + Chr(34) + "PRODUCT IDENTIFICATION" + Chr(34)
        LabelFormat(17) = "A774,12,1,3,1,1,N," + Chr(34) + "(P)" + Chr(34)
        LabelFormat(18) = "A601,12,1,3,1,1,N," + Chr(34) + "QUANTITY" + Chr(34)
        LabelFormat(19) = "A581,12,1,3,1,1,N," + Chr(34) + "(Q)" + Chr(34)
        LabelFormat(20) = "A601,475,1,3,1,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(21) = "A398,12,1,3,1,1,N," + Chr(34) + "WEIGHT" + Chr(34)
        LabelFormat(22) = "A378,12,1,3,1,1,N," + Chr(34) + "(W)" + Chr(34)
        LabelFormat(23) = "A398,350,1,3,1,1,N," + Chr(34) + "HT.NO." + Chr(34)
        LabelFormat(24) = "A378,350,1,3,1,1,N," + Chr(34) + "(EH)" + Chr(34)
        If Not String.IsNullOrEmpty(master.partNumber) Then
            LabelFormat(25) = "A392,816,1,3,1,1,N," + Chr(34) + "P.O. NUMBER" + Chr(34)
            LabelFormat(26) = "A372,816,1,3,1,1,N," + Chr(34) + "(A)" + Chr(34)
            If master.partNumber.StartsWith("DBA") Or master.partNumber.StartsWith("CA") Or master.partNumber.StartsWith("SC") Or master.partNumber.StartsWith("DSC") Or master.partNumber.StartsWith("PSR") Then
                LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + "SHIFT" + Chr(34)
            ElseIf master.partNumber.StartsWith("TT") Or master.partNumber.StartsWith("NT") Or master.partNumber.StartsWith("TP") Then
                LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + "Operator" + Chr(34)
            Else
                LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + " " + Chr(34)
            End If
        Else
            LabelFormat(25) = "A392,816,1,3,1,1,N," + Chr(34) + "P.O. NUMBER" + Chr(34)
            LabelFormat(26) = "A372,816,1,3,1,1,N," + Chr(34) + "(A)" + Chr(34)
            LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + " " + Chr(34)
        End If

        LabelFormat(27) = "A191,12,1,3,1,1,N," + Chr(34) + "SERIAL NO." + Chr(34)
        LabelFormat(28) = "A171,12,1,3,1,1,N," + Chr(34) + "(S)" + Chr(34)
        LabelFormat(29) = "A191,816,1,3,1,1,N," + Chr(34) + "DATE" + Chr(34)
        LabelFormat(31) = "A89,816,1,3,1,1,N," + Chr(34) + "COUNTRY OF ORIGIN" + Chr(34)


        LabelFormat(33) = "A601,136,1,4,3,2,N," + Chr(34) + master.quantityPerBox + Chr(34)
        LabelFormat(34) = "A386,108,1,4,3,2,N," + Chr(34) + Math.Round(Val(master.weightPerBox), 0, MidpointRounding.AwayFromZero).ToString() + Chr(34)
        LabelFormat(35) = "A200,210,1,4,3,2,N," + Chr(34) + master.serialLotNumber + Chr(34)
        LabelFormat(36) = "A575,452,1,3,3,2,N," + Chr(34) + master.description1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(37) = "A525,452,1,3,3,2,N," + Chr(34) + master.description2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(38) = "A475,452,1,3,3,2,N," + Chr(34) + master.description3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        If master.heat.Length >= 10 Then
            If master.heat.Length >= 14 Then
                LabelFormat(39) = "A380,420,1,2,3,2,N," + Chr(34) + master.heat + Chr(34)
                LabelFormat(47) = "B313,360,1,3,1,2,102,N," + Chr(34) + "EH" + master.heat + Chr(34)
            Else
                LabelFormat(39) = "A380,420,1,3,3,2,N," + Chr(34) + master.heat + Chr(34)
                LabelFormat(47) = "B313,360,1,3,1,2,102,N," + Chr(34) + "EH" + master.heat + Chr(34)
            End If
        Else
            LabelFormat(39) = "A380,420,1,4,3,2,N," + Chr(34) + master.heat + Chr(34)
            LabelFormat(47) = "B313,360,1,3,2,4,102,N," + Chr(34) + "EH" + master.heat + Chr(34)
        End If

        If master.customerPO.Length < 12 Then
            LabelFormat(40) = "A345,825,1,3,3,2,N," + Chr(34) + master.customerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        ElseIf master.customerPO.Length >= 12 And master.customerPO.Length < 14 Then
            LabelFormat(40) = "A345,825,1,3,3,2,N," + Chr(34) + master.customerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        ElseIf master.customerPO.Length >= 14 And master.customerPO.Length < 16 Then
            LabelFormat(40) = "A345,825,1,2,3,2,N," + Chr(34) + master.customerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        Else
            LabelFormat(40) = "A345,825,1,1,3,2,N," + Chr(34) + master.customerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        End If

        LabelFormat(41) = "A170,816,1,4,2,1,N," + Chr(34) + master.dat + Chr(34)
        LabelFormat(42) = "A63,822,1,4,2,1,N," + Chr(34) + master.country + Chr(34)

        ''check to see if the part number is going to go off label, if os will re-adjust it
        If division.Equals("TFP") Then
            If Not master.partNumber.ToUpper.Contains("REV. ") And Not master.partNumber.ToUpper.Contains("REV ") Then
                If (master.partNumber.Length + revLevel.Length) >= 20 Then
                    LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + master.partNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + " REV. " + revLevel + Chr(34)
                    LabelFormat(43) = "B717,100,1,3,2,4,102,N," + Chr(34) + "P" + master.partNumber + " REV. " + revLevel + Chr(34)
                Else
                    LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + master.partNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + " REV. " + revLevel + Chr(34)
                    LabelFormat(43) = "B717,320,1,3,2,4,102,N," + Chr(34) + "P" + master.partNumber + " REV. " + revLevel + Chr(34)
                End If
            Else
                If master.partNumber.Length >= 20 Then
                    LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + master.partNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                    LabelFormat(43) = "B717,100,1,3,2,4,102,N," + Chr(34) + "P" + master.partNumber + Chr(34)
                Else
                    LabelFormat(32) = "A790,320,1,4,3,2,N," + Chr(34) + master.partNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                    LabelFormat(43) = "B717,320,1,3,2,4,102,N," + Chr(34) + "P" + master.partNumber + Chr(34)
                End If
            End If
        Else
            If master.partNumber.Length >= 20 Then
                LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + master.partNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                LabelFormat(43) = "B717,100,1,3,2,4,102,N," + Chr(34) + "P" + master.partNumber + Chr(34)
            Else
                LabelFormat(32) = "A790,320,1,4,3,2,N," + Chr(34) + master.partNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                LabelFormat(43) = "B717,320,1,3,2,4,102,N," + Chr(34) + "P" + master.partNumber + Chr(34)
            End If
        End If

        LabelFormat(44) = "B520,81,1,3,2,4,102,N," + Chr(34) + "Q" + master.quantityPerBox + Chr(34)
        LabelFormat(45) = "B319,50,1,3,2,4,102,N," + Chr(34) + "W" + Math.Round(Val(master.weightPerBox), 0, MidpointRounding.AwayFromZero).ToString() + Chr(34)
        LabelFormat(46) = "B140,231,1,3,2,4,102,N," + Chr(34) + "S" + master.serialLotNumber + Chr(34)

        If Not String.IsNullOrEmpty(master.partNumber) Then
            If master.partNumber.StartsWith("DBA") Or master.partNumber.StartsWith("CA") Or master.partNumber.StartsWith("SC") Or master.partNumber.StartsWith("DSC") Or master.partNumber.StartsWith("PSR") Then
                LabelFormat(48) = "A282,816,1,3,1,1,N," + Chr(34) + "ESR REPORT" + Chr(34)
                LabelFormat(49) = "A170,1050,1,4,2,1,N," + Chr(34) + master.shift + Chr(34)
                LabelFormat(50) = "A255,825,1,4,2,2,N," + Chr(34) + master.esrNumber + Chr(34)
            End If
        End If
        'Print Label
        LabelFormat(51) = "P" + lblCount.ToString()
        LabelFormat(52) = vbFormFeed
        LabelLines = 51

        ' ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO750,35^ARR,15,12^FDProduct Identification^FS"
        ZLabelFormat(3) = "^FO725,35^ARR,15,12^FD(P)^FS"
        ZLabelFormat(4) = "^FO725,400^AVR,80,12^FD" + master.partNumber.Substring(1, master.partNumber.Length - 1).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(5) = "^FO625,400^B3R,N,100,N,N^FDP" + master.partNumber + "^FS"
        ZLabelFormat(6) = "^FO600,10^GB0,1190,5,B0^FS"

        ZLabelFormat(7) = "^FO570,35^ARR,15,12^FDQUANTITY^FS"
        ZLabelFormat(8) = "^FO545,35^ARR,15,12^FD(Q)^FS"
        ZLabelFormat(9) = "^FO525,200^AVR,15,12^FD" + master.quantityPerBox + "^FS"
        ZLabelFormat(10) = "^FO425,100^B3R,N,100,N,N^FDQ" + master.quantityPerBox + "^FS"
        ZLabelFormat(11) = "^FO400,435^GB200,0,5,B0^FS"

        ZLabelFormat(12) = "^FO570,475^ARR,15,12^FDDESCRIPTION^FS"
        ZLabelFormat(13) = "^FO500,500^AVR,15,12^FD" + master.description1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(14) = "^FO440,500^AVR,15,12^FD" + master.description2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(15) = "^FO400,10^GB0,1190,5,B0^FS"

        ZLabelFormat(16) = "^FO370,35^ARR,15,12^FDWeight^FS"
        ZLabelFormat(17) = "^FO345,35^ARR,15,12^FD(W)^FS"
        ZLabelFormat(18) = "^FO325,150^AVR,15,12^FD" + master.weightPerBox + "^FS"
        ZLabelFormat(19) = "^FO225,50^B3R,N,100,N,N^FDW" + master.weightPerBox + "^FS"
        ZLabelFormat(20) = "^FO200,350^GB200,0,5,B0^FS"

        ZLabelFormat(21) = "^FO370,360^ARR,15,12^FDHT. NO.^FS"
        ZLabelFormat(22) = "^FO345,360^ARR,15,12^FD(EH)^FS"
        ZLabelFormat(23) = "^FO325,450^AVR,15,12^FD" + master.heat + "^FS"
        ZLabelFormat(24) = "^FO225,400^B3R,N,100,N,N^FDEH" + master.heat + "^FS"
        ZLabelFormat(25) = "^FO200,850^GB200,0,5,B0^FS"

        ZLabelFormat(26) = "^FO370,875^ARR,15,12^FDP.O. NUMBER^FS"
        ZLabelFormat(27) = "^FO345,875^ARR,15,12^FD(A)^FS"
        ZLabelFormat(28) = "^FO250,900^AVR,15,12^FD" + master.customerPO + "^FS"
        ZLabelFormat(29) = "^FO200,10^GB0,1190,5,B0^FS"

        ZLabelFormat(30) = "^FO170,35^ARR,15,12^FDSERIAL NO.^FS"
        ZLabelFormat(31) = "^FO145,35^ARR,15,12^FD(S)^FS"
        ZLabelFormat(32) = "^FO125,200^AVR,15,12^FD" + master.serialLotNumber + "^FS"
        ZLabelFormat(33) = "^FO35,100^B3R,N,100,N,N^FDS" + master.serialLotNumber + "^FS"
        ZLabelFormat(34) = "^FO20,850^GB200,0,5,B0^FS"

        ZLabelFormat(35) = "^FO170,875^ARR,15,12^FDDATE^FS"
        ZLabelFormat(36) = "^FO110,900^AVR,15,12^FD" + master.dat + "^FS"
        ZLabelFormat(37) = "^FO100,850^GB0,325,5,B0^FS"

        ZLabelFormat(38) = "^FO70,875^ARR,15,12^FDCOUNTRY OF ORIGIN^FS"
        ZLabelFormat(39) = "^FO10,900^AVR,15,12^FD" + master.country + "^FS"

        ZLabelFormat(40) = "^FO10,30^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(41) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(42) = "^XZ"
        ZLabelLines = 42
    End Sub

    Public Sub BinTagLabelSetup(ByVal location1 As String, ByVal location2 As String, Optional ByVal lblCount As Integer = 1)
        'Standard 4x6 AIAG Label setup

        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage
        LabelFormat(8) = "A300,10,1,4,9,4,N," + Chr(34) + location1 + Chr(34)
        LabelFormat(9) = "A700,10,1,4,9,4,N," + Chr(34) + location2 + Chr(34)

        'Print Barcodes
        LabelFormat(10) = "B300,600,1,3,5,10,200,N," + Chr(34) + location1 + Chr(34)
        LabelFormat(11) = "B700,600,1,3,5,10,200,N," + Chr(34) + location2 + Chr(34)

        'Print Label
        LabelFormat(12) = "P" + lblCount.ToString()
        LabelFormat(13) = vbFormFeed
        LabelLines = 12

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO30,10^A0R,300,200^FD" + location1 + "^FS"
        ZLabelFormat(3) = "^FO55,700^B3R,N,250,N,N^FD" + location1 + "^FS"
        ZLabelFormat(4) = "^FO400,10^A0R,300,200^FD" + location2 + "^FS"
        ZLabelFormat(5) = "^FO425,700^B3R,N,250,N,N^FD" + location2 + "^FS"
        ZLabelFormat(6) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(7) = "^XZ"
        ZLabelLines = 7
    End Sub

    Public Sub PalletBinLabelSetup(ByVal location1 As String, Optional ByVal lblCount As Integer = 1)
        'Standard 4x6 AIAG Label setup

        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage
        LabelFormat(8) = "A750,150,1,5,5,5,N," + Chr(34) + location1 + Chr(34)

        'Print Barcodes
        LabelFormat(9) = "B450,200,1,3,5,20,400,N," + Chr(34) + location1 + Chr(34)

        'Print Label
        LabelFormat(10) = "P" + lblCount.ToString()
        LabelFormat(11) = vbFormFeed
        LabelLines = 10

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO75,150^A0R,400,300^FD" + location1 + "^FS"
        ZLabelFormat(3) = "^FO450,200^B3R,N,450,N,N^FD" + location1 + "^FS"
        ZLabelFormat(4) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(5) = "^XZ"
        ZLabelLines = 5
    End Sub

    Public Sub blankLineLabelPrint(ByVal lst As List(Of String), Optional ByVal lblCount As Integer = 1)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "A800,10,1,2,4,4,N," + Chr(34) + lst(0).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(9) = "A700,10,1,2,4,4,N," + Chr(34) + lst(1).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(10) = "A600,10,1,2,4,4,N," + Chr(34) + lst(2).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(11) = "A500,10,1,2,4,4,N," + Chr(34) + lst(3).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(12) = "A400,10,1,2,4,4,N," + Chr(34) + lst(4).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(13) = "A300,10,1,2,4,4,N," + Chr(34) + lst(5).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(14) = "A200,10,1,2,4,4,N," + Chr(34) + lst(6).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(15) = "A100,10,1,2,4,4,N," + Chr(34) + lst(7).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(16) = "P" + lblCount.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO710,10^A0R,100,75^FD" + lst(0).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(3) = "^FO610,10^A0R,100,75^FD" + lst(1).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(4) = "^FO510,10^A0R,100,75^FD" + lst(2).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(5) = "^FO410,10^A0R,100,75^FD" + lst(3).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(6) = "^FO310,10^A0R,100,75^FD" + lst(4).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(7) = "^FO210,10^A0R,100,75^FD" + lst(5).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(8) = "^FO110,10^A0R,100,75^FD" + lst(6).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(9) = "^FO10,10^A0R,100,75^FD" + lst(7).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + "^FS"
        ZLabelFormat(10) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(11) = "^XZ"
        ZLabelLines = 11
    End Sub

    Public Sub blank3LineLabelPrint(ByVal lst As List(Of String), Optional ByVal lblCount As Integer = 1)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        Dim lineCnt As Integer = 0
        Dim HorDrawPos As Integer = 775
        While lineCnt < lst.Count And HorDrawPos > 0
            lst(lineCnt) = lst(lineCnt).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
            Dim position As Integer = 0
            Select Case lst(lineCnt).Length
                Case Is <= 8
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (135 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,9,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 12
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (95 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,6,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 14
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (77 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,5,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 18
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (61 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,4,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 24
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (47 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,3,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 21
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,5,4,1,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 24
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,4,5,3,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 27
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,4,5,2,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 30
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,3,5,6,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Else
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,3,5,1,N," + Chr(34) + lst(lineCnt) + Chr(34)
            End Select
            lineCnt += 1
            HorDrawPos -= 250
        End While
        LabelFormat(8 + lineCnt) = "P" + lblCount.ToString()
        LabelFormat(lineCnt + 9) = vbFormFeed
        LabelLines = 8 + lineCnt

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO510,10^AGR,250,75^FD" + lst(0) + "^FS"
        ZLabelFormat(3) = "^FO260,10^AGR,250,75^FD" + lst(1) + "^FS"
        ZLabelFormat(4) = "^FO010,10^AGR,250,75^FD" + lst(2) + "^FS"
        ZLabelFormat(5) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(6) = "^XZ"
        ZLabelLines = 6
    End Sub

    Public Sub BranamLabelSetup(ByVal bran As branamLabel, Optional ByVal lblCount As Integer = 1)
        Dim cmd As New SqlCommand("SELECT DivisionID, BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = bran.serialLot
        Dim revLevel As String = ""
        Dim division As String = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("DivisionID")) Then
                If reader.Item("DivisionID").ToString.Equals("TFP") Then
                    division = "TFP"
                    If Not IsDBNull(reader.Item("BlueprintRevision")) Then
                        revLevel = reader.Item("BlueprintRevision")
                    End If
                End If
            End If
        End If
        reader.Close()
        con.Close()
        'Branam BC_6156 from Wang
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "LO670,0,1,1210"
        LabelFormat(9) = "LO528,0,1,1210"
        LabelFormat(10) = "LO386,0,1,1210"
        LabelFormat(11) = "LO244,0,1,1210"
        LabelFormat(12) = "LO102,0,1,1210"
        LabelFormat(13) = "LO812,609,1,1"
        LabelFormat(14) = "LO670,609,141,1"
        LabelFormat(15) = "LO528,711,141,1"
        LabelFormat(16) = "LO244,508,141,1"
        LabelFormat(17) = "LO102,508,141,1"
        LabelFormat(18) = "A800,20,1,1,1,1,N," + Chr(34) + "P.O. (K)" + Chr(34)
        LabelFormat(19) = "A798,219,1,3,2,1,N," + Chr(34) + bran.customerPO + Chr(34)
        LabelFormat(20) = "B753,164,1,3,2,4,81,N," + Chr(34) + "K" + bran.customerPO + Chr(34)
        LabelFormat(21) = "A800,613,1,1,1,1,N," + Chr(34) + "EC# (2P)" + Chr(34)
        LabelFormat(22) = "A800,869,1,3,2,1,N," + Chr(34) + bran.engineeringChangeLvl + Chr(34)
        LabelFormat(23) = "B753,784,1,3,2,4,81,N," + Chr(34) + "2P" + bran.engineeringChangeLvl + Chr(34)
        LabelFormat(24) = "A656,20,1,1,1,1,N," + Chr(34) + "PART NO. (P)" + Chr(34)
        If division.Equals("TFP") Then
            If Not bran.PartNumber.ToUpper.Contains("REV. ") And Not bran.PartNumber.ToUpper.Contains("REV ") Then
                LabelFormat(25) = "A658,223,1,3,2,1,N," + Chr(34) + bran.PartNumber + " REV. " + revLevel + Chr(34)
                LabelFormat(26) = "B611,156,1,3,2,4,81,N," + Chr(34) + "P" + bran.PartNumber + " REV. " + revLevel + Chr(34)
            Else
                LabelFormat(25) = "A658,223,1,3,2,1,N," + Chr(34) + bran.PartNumber + Chr(34)
                LabelFormat(26) = "B611,156,1,3,2,4,81,N," + Chr(34) + "P" + bran.PartNumber + Chr(34)
            End If
        Else
            LabelFormat(25) = "A658,223,1,3,2,1,N," + Chr(34) + bran.PartNumber + Chr(34)
            LabelFormat(26) = "B611,156,1,3,2,4,81,N," + Chr(34) + "P" + bran.PartNumber + Chr(34)
        End If

        LabelFormat(27) = "A656,715,1,1,1,1,N," + Chr(34) + "COUNTRY OF" + Chr(34)
        LabelFormat(28) = "A633,715,1,1,1,1,N," + Chr(34) + "ORIGIN (4L)" + Chr(34)
        LabelFormat(29) = "A656,946,1,3,2,1,N," + Chr(34) + bran.country + Chr(34)
        LabelFormat(30) = "B611,903,1,3,2,4,81,N," + Chr(34) + "4L" + bran.country + Chr(34)
        LabelFormat(31) = "A520,20,1,1,1,1,N," + Chr(34) + "REF (Z)" + Chr(34)
        LabelFormat(32) = "A514,244,1,3,2,1,N," + Chr(34) + bran.reference + Chr(34)
        LabelFormat(33) = "B469,154,1,3,2,4,81,N," + Chr(34) + "Z" + bran.reference + Chr(34)
        LabelFormat(34) = "A374,20,1,1,1,1,N," + Chr(34) + "QUANTITY U/M (7Q)" + Chr(34)
        LabelFormat(35) = "A367,213,1,3,2,1,N," + Chr(34) + bran.prductionQty + Chr(34)
        LabelFormat(36) = "B323,150,1,3,2,4,81,N," + Chr(34) + "7Q" + bran.prductionQty + Chr(34)
        LabelFormat(37) = "A231,20,1,1,1,1,N," + Chr(34) + "SUPPLIER (V)" + Chr(34)
        LabelFormat(38) = "A229,209,1,3,2,1,N," + Chr(34) + bran.supplierNumber + Chr(34)
        LabelFormat(39) = "B183,142,1,3,2,4,81,N," + Chr(34) + "V" + bran.supplierNumber + Chr(34)
        LabelFormat(40) = "A93,20,1,1,1,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(41) = "A83,156,1,4,2,1,N," + Chr(34) + bran.shortDescription + Chr(34)
        LabelFormat(42) = "A374,509,1,1,1,1,N," + Chr(34) + "LOT# SPLR (1T)" + Chr(34)
        LabelFormat(43) = "A374,774,1,3,2,1,N," + Chr(34) + bran.serialLot + Chr(34)
        LabelFormat(44) = "B327,662,1,3,2,4,81,N," + Chr(34) + "1T" + bran.serialLot + Chr(34)
        LabelFormat(45) = "A231,509,1,1,1,1,N," + Chr(34) + "HARMONIZED CODE (HC)" + Chr(34)
        LabelFormat(46) = "A231,836,1,3,2,1,N," + Chr(34) + bran.harmCode + Chr(34)
        LabelFormat(47) = "B185,622,1,3,2,4,81,N," + Chr(34) + "HC" + bran.harmCode + Chr(34)
        LabelFormat(48) = "P" + lblCount.ToString()
        LabelLines = 48

        ''NEEDS DONE IF NEEDED
        '' ''ZPL Commands
        'ZLabelFormat(0) = "^XA"
        'ZLabelFormat(1) = "^PW800"
        'ZLabelFormat(2) = "^FO750,35^ARR,15,12^FDProduct Identification^FS"
        'ZLabelFormat(3) = "^FO725,35^ARR,15,12^FD(P)^FS"
        'ZLabelFormat(4) = "^FO725,400^AVR,80,12^FD" + bran.PartNumber.Substring(1, bran.PartNumber.Length - 1) + "^FS"
        'ZLabelFormat(5) = "^FO625,400^B3R,N,100,N,N^FDP" + bran.PartNumber + "^FS"
        'ZLabelFormat(6) = "^FO600,10^GB0,1190,5,B0^FS"

        'ZLabelFormat(7) = "^FO570,35^ARR,15,12^FDQUANTITY^FS"
        'ZLabelFormat(8) = "^FO545,35^ARR,15,12^FD(Q)^FS"
        'ZLabelFormat(9) = "^FO525,200^AVR,15,12^FD" + bran.prductionQty + "^FS"
        'ZLabelFormat(10) = "^FO425,100^B3R,N,100,N,N^FDQ" + bran.prductionQty + "^FS"
        'ZLabelFormat(11) = "^FO400,435^GB200,0,5,B0^FS"

        'ZLabelFormat(12) = "^FO570,475^ARR,15,12^FDDESCRIPTION^FS"
        'ZLabelFormat(13) = "^FO500,500^AVR,15,12^FD" + bran.shortDescription + "^FS"
        'ZLabelFormat(14) = "^FO440,500^AVR,15,12^FD" + bran.shortDescription + "^FS"
        'ZLabelFormat(15) = "^FO400,10^GB0,1190,5,B0^FS"

        'ZLabelFormat(16) = "^FO370,35^ARR,15,12^FDWeight^FS"
        'ZLabelFormat(17) = "^FO345,35^ARR,15,12^FD(W)^FS"
        'ZLabelFormat(18) = "^FO325,150^AVR,15,12^FD" + bran.prductionQty + "^FS"
        'ZLabelFormat(19) = "^FO225,50^B3R,N,100,N,N^FDW" + bran.prductionQty + "^FS"
        'ZLabelFormat(20) = "^FO200,350^GB200,0,5,B0^FS"

        'ZLabelFormat(40) = "^FO10,30^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        'ZLabelFormat(41) = "^PQ" + lblCount.ToString() + ",0,0,N"
        'ZLabelFormat(42) = "^XZ"
        'ZLabelLines = 42
    End Sub

    Public Sub FryerLabelSetup(ByVal fryer As FryerLabel, Optional ByVal lblCount As Integer = 1)
        Dim cmd As New SqlCommand("SELECT DivisionID, BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = fryer.Lot
        Dim revLevel As String = ""
        Dim division As String = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("DivisionID")) Then
                If reader.Item("DivisionID").ToString.Equals("TFP") Then
                    division = "TFP"
                    If Not IsDBNull(reader.Item("BlueprintRevision")) Then
                        revLevel = reader.Item("BlueprintRevision")
                    End If
                End If
            End If
        End If
        reader.Close()
        con.Close()
        'BC_2387 from Wang
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        LabelFormat(25) = "A790,750,1,1,1,1,N," + Chr(34) + "PURCHASE ORDER NO." + Chr(34)
        LabelFormat(16) = "A780,24,1,1,1,1,N," + Chr(34) + "FROM:" + Chr(34)
        LabelFormat(21) = "A780,350,1,1,1,1,N," + Chr(34) + "TO:" + Chr(34)
        LabelFormat(26) = "A770,750,1,1,1,1,N," + Chr(34) + "(K)" + Chr(34)
        LabelFormat(46) = "A770,810,1,4,2,1,N," + Chr(34) + fryer.PONumber + Chr(34)
        LabelFormat(17) = "A760,24,1,1,1,1,N," + Chr(34) + "FRYER INDUSTRIES" + Chr(34)
        LabelFormat(22) = "A760,350,1,1,1,1,N," + Chr(34) + "FRYER INDUSTRIES" + Chr(34)
        LabelFormat(18) = "A740,24,1,1,1,1,N," + Chr(34) + "7067 SMITH INDUSTRIAL DRIVE" + Chr(34)
        LabelFormat(23) = "A740,350,1,1,1,1,N," + Chr(34) + "100 S. SUMMIT ST" + Chr(34)
        LabelFormat(19) = "A720,24,1,1,1,1,N," + Chr(34) + "MCGREGOR, ONT  N0R-1J0" + Chr(34)
        LabelFormat(24) = "A720,350,1,1,1,1,N," + Chr(34) + "DETROIT, MI 24477" + Chr(34)
        LabelFormat(54) = "B720,790,1,3,2,4,60,N," + Chr(34) + "K" + fryer.PONumber + Chr(34)
        LabelFormat(20) = "A700,24,1,1,1,1,N," + Chr(34) + "TEL:(519)726-4446" + Chr(34)
        LabelFormat(11) = "LO650,20,1,1190"
        LabelFormat(12) = "LO650,334,148,1"
        LabelFormat(13) = "LO650,737,148,1"
        LabelFormat(27) = "A640,20,1,1,1,1,N," + Chr(34) + "PART NO." + Chr(34)
        If division.Equals("TFP") Then
            If Not fryer.PartNumber.ToUpper.Contains("REV. ") And Not fryer.PartNumber.ToUpper.Contains("REV ") Then
                LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + fryer.PartNumber + " REV. " + revLevel + Chr(34)
                LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + fryer.PartNumber + " REV. " + revLevel + Chr(34)
            Else
                LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + fryer.PartNumber + Chr(34)
                LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + fryer.PartNumber + Chr(34)
            End If
        Else
            LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + fryer.PartNumber + Chr(34)
            LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + fryer.PartNumber + Chr(34)
        End If

        LabelFormat(28) = "A620,20,1,1,1,1,N," + Chr(34) + "(P)" + Chr(34)

        LabelFormat(31) = "A510,20,1,1,1,1,N," + Chr(34) + "PART DESCRIPTION:" + Chr(34)
        LabelFormat(40) = "A510,1000,1,1,1,1,N," + Chr(34) + "PART REV LEVEL" + Chr(34)
        LabelFormat(42) = "A490,180,1,4,2,1,N," + Chr(34) + fryer.PartDescription + Chr(34)
        LabelFormat(49) = "A490,1050,1,4,2,1,N," + Chr(34) + fryer.PartRev + Chr(34)
        LabelFormat(10) = "LO440,20,1,1190"
        LabelFormat(29) = "A430,20,1,1,1,1,N," + Chr(34) + "MFG LOT NO." + Chr(34)
        LabelFormat(43) = "A435,180,1,4,2,1,N," + Chr(34) + fryer.Lot + Chr(34)
        LabelFormat(47) = "A435,800,1,4,2,1,N," + Chr(34) + fryer.SupplierCode + Chr(34)
        LabelFormat(36) = "A430,660,1,1,1,1,N," + Chr(34) + "SUPPLIER CODE" + Chr(34)
        LabelFormat(30) = "A410,20,1,1,1,1,N," + Chr(34) + "(T)" + Chr(34)
        LabelFormat(37) = "A410,660,1,1,1,1,N," + Chr(34) + "(V)" + Chr(34)
        LabelFormat(51) = "B390,100,1,3,2,4,80,N," + Chr(34) + "T" + fryer.Lot + Chr(34)
        LabelFormat(55) = "B385,700,1,3,2,4,60,N," + Chr(34) + "V" + fryer.SupplierCode + Chr(34)
        LabelFormat(15) = "LO320,650,1,560"
        LabelFormat(38) = "A310,660,1,1,1,1,N," + Chr(34) + "SERIAL NO." + Chr(34)
        LabelFormat(9) = "LO300,20,1,630"
        LabelFormat(32) = "A290,20,1,1,1,1,N," + Chr(34) + "QTY" + Chr(34)
        LabelFormat(44) = "A290,180,1,4,2,1,N," + Chr(34) + fryer.Quantity + Chr(34)
        LabelFormat(39) = "A290,660,1,1,1,1,N," + Chr(34) + "(S)" + Chr(34)
        LabelFormat(48) = "A290,800,1,4,2,1,N," + Chr(34) + fryer.Lot + Chr(34)
        LabelFormat(33) = "A270,20,1,1,1,1,N," + Chr(34) + "(Q)" + Chr(34)
        LabelFormat(52) = "B240,100,1,3,2,4,80,N," + Chr(34) + "Q" + fryer.Quantity + Chr(34)
        LabelFormat(56) = "B240,700,1,3,2,4,80,N," + Chr(34) + "S" + fryer.Lot + Chr(34)
        LabelFormat(8) = "LO150,20,1,1190"
        LabelFormat(14) = "LO150,650,290,1"
        LabelFormat(34) = "A145,20,1,1,1,1,N," + Chr(34) + "SUPPLIER CODE/SERIAL NO." + Chr(34)
        LabelFormat(35) = "A120,20,1,1,1,1,N," + Chr(34) + "(3S)" + Chr(34)
        LabelFormat(45) = "A130,180,1,4,2,1,N," + Chr(34) + fryer.Lot + Chr(34)
        LabelFormat(53) = "B80,100,1,3,2,4,60,N," + Chr(34) + "3S" + fryer.Lot + Chr(34)

        'Print Label
        LabelFormat(57) = "P" + lblCount.ToString()
        LabelLines = 57

    End Sub

    Public Sub NordicLabelSetup(ByVal Nordic As NordicLabel, Optional ByVal lblCount As Integer = 1)
        Dim cmd As New SqlCommand("SELECT DivisionID, BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = Nordic.Lot
        Dim revLevel As String = ""
        Dim division As String = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("DivisionID")) Then
                If reader.Item("DivisionID").ToString.Equals("TFP") Then
                    division = "TFP"
                    If Not IsDBNull(reader.Item("BlueprintRevision")) Then
                        revLevel = reader.Item("BlueprintRevision")
                    End If
                End If
            End If
        End If
        reader.Close()
        con.Close()
        'BC_2387 from Wang
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        LabelFormat(25) = "A790,750,1,1,1,1,N," + Chr(34) + "PURCHASE ORDER NO." + Chr(34)
        LabelFormat(16) = "A780,24,1,1,1,1,N," + Chr(34) + "FROM:" + Chr(34)
        LabelFormat(21) = "A780,350,1,1,1,1,N," + Chr(34) + "TO:" + Chr(34)
        LabelFormat(26) = "A770,750,1,1,1,1,N," + Chr(34) + "(K)" + Chr(34)
        LabelFormat(46) = "A770,810,1,4,2,1,N," + Chr(34) + Nordic.PONumber + Chr(34)
        LabelFormat(17) = "A760,24,1,1,1,1,N," + Chr(34) + "TFP CORPORATION" + Chr(34)
        LabelFormat(22) = "A760,350,1,1,1,1,N," + Chr(34) + "NORDIC FIBERGLASS INC" + Chr(34)
        LabelFormat(18) = "A740,24,1,1,1,1,N," + Chr(34) + "460 LAKE ROAD" + Chr(34)
        LabelFormat(23) = "A740,350,1,1,1,1,N," + Chr(34) + "21415 U.S. HWY 75 NW" + Chr(34)
        LabelFormat(19) = "A720,24,1,1,1,1,N," + Chr(34) + "MEDINA, OHIO 44256" + Chr(34)
        LabelFormat(24) = "A720,350,1,1,1,1,N," + Chr(34) + "WARREN, MN 56762" + Chr(34)
        'LabelFormat(54) = "B720,790,1,3,2,4,60,N," + Chr(34) + "K" + Nordic.PONumber + Chr(34)
        LabelFormat(20) = "A700,24,1,1,1,1,N," + Chr(34) + "TEL:(330)725-7741" + Chr(34)
        LabelFormat(11) = "LO650,20,1,1190"
        LabelFormat(12) = "LO650,334,148,1"
        LabelFormat(13) = "LO650,737,148,1"
        LabelFormat(27) = "A640,20,1,1,1,1,N," + Chr(34) + "PART NO." + Chr(34)
        If division.Equals("TFP") Then
            If Not Nordic.PartNumber.ToUpper.Contains("REV. ") And Not Nordic.PartNumber.ToUpper.Contains("REV ") Then
                LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + Nordic.PartNumber + " REV. " + revLevel + Chr(34)
                LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + Nordic.PartNumber + " REV. " + revLevel + Chr(34)
            Else
                LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + Nordic.PartNumber + Chr(34)
                LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + Nordic.PartNumber + Chr(34)
            End If
        Else
            LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + Nordic.PartNumber + Chr(34)
            LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + Nordic.PartNumber + Chr(34)
        End If

        LabelFormat(28) = "A620,20,1,1,1,1,N," + Chr(34) + "(P)" + Chr(34)

        LabelFormat(31) = "A510,20,1,1,1,1,N," + Chr(34) + "PART DESCRIPTION:" + Chr(34)
        LabelFormat(40) = "A510,1000,1,1,1,1,N," + Chr(34) + "PART REV LEVEL" + Chr(34)
        LabelFormat(42) = "A490,180,1,4,2,1,N," + Chr(34) + Nordic.PartDescription + Chr(34)
        LabelFormat(49) = "A490,1050,1,4,2,1,N," + Chr(34) + Nordic.PartRev + Chr(34)
        LabelFormat(10) = "LO440,20,1,1190"
        LabelFormat(29) = "A430,20,1,1,1,1,N," + Chr(34) + "MFG LOT NO." + Chr(34)
        LabelFormat(43) = "A435,180,1,4,2,1,N," + Chr(34) + Nordic.Lot + Chr(34)
        LabelFormat(47) = "A435,800,1,4,2,1,N," + Chr(34) + Nordic.HeatNumber + Chr(34)
        LabelFormat(36) = "A430,660,1,1,1,1,N," + Chr(34) + "HEAT NO." + Chr(34)
        LabelFormat(30) = "A410,20,1,1,1,1,N," + Chr(34) + "(T)" + Chr(34)
        LabelFormat(37) = "A410,660,1,1,1,1,N," + Chr(34) + "(V)" + Chr(34)
        LabelFormat(51) = "B390,100,1,3,2,4,80,N," + Chr(34) + "T" + Nordic.Lot + Chr(34)
        'LabelFormat(55) = "B385,700,1,3,2,4,60,N," + Chr(34) + "V" + Nordic.HeatNumber + Chr(34)
        LabelFormat(15) = "LO320,650,1,560"
        LabelFormat(38) = "A310,660,1,1,1,1,N," + Chr(34) + "BOX WEIGHT" + Chr(34)
        LabelFormat(9) = "LO300,20,1,630"
        LabelFormat(32) = "A290,20,1,1,1,1,N," + Chr(34) + "QTY" + Chr(34)
        LabelFormat(44) = "A290,180,1,4,2,1,N," + Chr(34) + Nordic.Quantity + Chr(34)
        LabelFormat(39) = "A290,660,1,1,1,1,N," + Chr(34) + "(S)" + Chr(34)
        LabelFormat(48) = "A290,800,1,4,2,1,N," + Chr(34) + Nordic.BoxWeight + Chr(34)
        LabelFormat(33) = "A270,20,1,1,1,1,N," + Chr(34) + "(Q)" + Chr(34)
        'LabelFormat(52) = "B240,100,1,3,2,4,80,N," + Chr(34) + "Q" + Nordic.Quantity + Chr(34)
        'LabelFormat(56) = "B240,700,1,3,2,4,80,N," + Chr(34) + "S" + Nordic.BoxWeight + Chr(34)
        LabelFormat(8) = "LO150,20,1,1190"
        LabelFormat(14) = "LO150,650,290,1"
        LabelFormat(34) = "A145,20,1,1,1,1,N," + Chr(34) + "LOT/BATCH NO." + Chr(34)
        LabelFormat(35) = "A120,20,1,1,1,1,N," + Chr(34) + "(3S)" + Chr(34)
        LabelFormat(45) = "A130,180,1,4,2,1,N," + Chr(34) + Nordic.LotComment + Chr(34)
        'LabelFormat(53) = "B80,100,1,3,2,4,60,N," + Chr(34) + "3S" + Nordic.Lot + Chr(34)

        'Print Label
        LabelFormat(57) = "P" + lblCount.ToString()
        LabelLines = 57

    End Sub

    Public Sub OptimasLabelSetup(ByVal optimas As OptimasLabel, Optional ByVal lblCount As Integer = 1)
        'Label Fields

        'Field One - Optimas Part Number (Part Number over barcode)

        'Field Two - Optimas Lot Number (Lot Number over Barcose)

        'Field Three - Description over Optimas Supplier Name - No bar codes

        'Field Five - Optimas Quantity (Same Line as Description/Supplier)

        'Field Six - Optimas PO Number (Barcose over PO NUmber)

        'Field Seven - Optimas PO Line / Ship Date (Same line as PO Number - no barcode)

        'Field Eight - 2D Barcode

        'Field Nine - Country of Origin Over barcode


        'Optimas Label - set up Boxes
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "LO670,0,1,1210"
        LabelFormat(9) = "LO528,0,1,1210"
        LabelFormat(10) = "LO386,0,1,1210"
        LabelFormat(11) = "LO244,0,1,1210"
        LabelFormat(12) = "LO102,0,1,1210"
        LabelFormat(13) = "LO812,609,1,1"
        LabelFormat(14) = "LO670,609,141,1"
        LabelFormat(15) = "LO528,711,141,1"
        LabelFormat(16) = "LO244,508,141,1"
        LabelFormat(17) = "LO102,508,141,1"

        'Optimas Label - set up fields
        LabelFormat(18) = "A800,20,1,1,1,1,N," + Chr(34) + "Part" + Chr(34)
        LabelFormat(19) = "A798,219,1,3,2,1,N," + Chr(34) + optimas.OptimasPartNumber + Chr(34)
        LabelFormat(20) = "B753,164,1,3,2,4,81,N," + Chr(34) + "K" + optimas.OptimasPartNumber + Chr(34)

        LabelFormat(21) = "A800,613,1,1,1,1,N," + Chr(34) + "Lot" + Chr(34)
        LabelFormat(22) = "A800,869,1,3,2,1,N," + Chr(34) + optimas.OptimasLotNumber + Chr(34)
        LabelFormat(23) = "B753,784,1,3,2,4,81,N," + Chr(34) + "2P" + optimas.OptimasLotNumber + Chr(34)

        LabelFormat(24) = "A656,20,1,1,1,1,N," + Chr(34) + "Desc" + Chr(34)
        LabelFormat(25) = "A658,223,1,3,2,1,N," + Chr(34) + optimas.OptimasDescription + Chr(34)
        LabelFormat(26) = "B611,156,1,3,2,4,81,N," + Chr(34) + "P" + optimas.OptimasPartNumber + Chr(34)

        LabelFormat(27) = "A656,715,1,1,1,1,N," + Chr(34) + "COUNTRY OF" + Chr(34)
        LabelFormat(28) = "A633,715,1,1,1,1,N," + Chr(34) + "ORIGIN (4L)" + Chr(34)
        LabelFormat(29) = "A656,946,1,3,2,1,N," + Chr(34) + optimas.OptimasCountryOfOrigin + Chr(34)
        LabelFormat(30) = "B611,903,1,3,2,4,81,N," + Chr(34) + "4L" + optimas.OptimasCountryOfOrigin + Chr(34)

        LabelFormat(31) = "A520,20,1,1,1,1,N," + Chr(34) + "REF (Z)" + Chr(34)
        LabelFormat(32) = "A514,244,1,3,2,1,N," + Chr(34) + optimas.OptimasPartNumber + Chr(34)
        LabelFormat(33) = "B469,154,1,3,2,4,81,N," + Chr(34) + "Z" + optimas.OptimasPartNumber + Chr(34)

        LabelFormat(34) = "A374,20,1,1,1,1,N," + Chr(34) + "QUANTITY U/M (7Q)" + Chr(34)
        LabelFormat(35) = "A367,213,1,3,2,1,N," + Chr(34) + optimas.OptimasQuantity + Chr(34)
        LabelFormat(36) = "B323,150,1,3,2,4,81,N," + Chr(34) + "7Q" + optimas.OptimasQuantity + Chr(34)

        LabelFormat(37) = "A231,20,1,1,1,1,N," + Chr(34) + "SUPPLIER (V)" + Chr(34)
        LabelFormat(38) = "A229,209,1,3,2,1,N," + Chr(34) + optimas.OptimasSupplier + Chr(34)
        LabelFormat(39) = "B183,142,1,3,2,4,81,N," + Chr(34) + "V" + optimas.OptimasSupplier + Chr(34)

        LabelFormat(40) = "A93,20,1,1,1,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(41) = "A83,156,1,4,2,1,N," + Chr(34) + optimas.OptimasDescription + Chr(34)

        LabelFormat(42) = "A374,509,1,1,1,1,N," + Chr(34) + "LOT# SPLR (1T)" + Chr(34)
        LabelFormat(43) = "A374,774,1,3,2,1,N," + Chr(34) + optimas.OptimasLotNumber + Chr(34)
        LabelFormat(44) = "B327,662,1,3,2,4,81,N," + Chr(34) + "1T" + optimas.OptimasLotNumber + Chr(34)

        LabelFormat(45) = "A231,509,1,1,1,1,N," + Chr(34) + "HARMONIZED CODE (HC)" + Chr(34)
        LabelFormat(46) = "A231,836,1,3,2,1,N," + Chr(34) + optimas.OptimasPartNumber + Chr(34)
        LabelFormat(47) = "B185,622,1,3,2,4,81,N," + Chr(34) + "HC" + optimas.OptimasPartNumber + Chr(34)

        LabelFormat(48) = "P" + lblCount.ToString()
        LabelLines = 48

        ''NEEDS DONE IF NEEDED
        '' ''ZPL Commands
        'ZLabelFormat(0) = "^XA"
        'ZLabelFormat(1) = "^PW800"
        'ZLabelFormat(2) = "^FO750,35^ARR,15,12^FDProduct Identification^FS"
        'ZLabelFormat(3) = "^FO725,35^ARR,15,12^FD(P)^FS"
        'ZLabelFormat(4) = "^FO725,400^AVR,80,12^FD" + bran.PartNumber.Substring(1, bran.PartNumber.Length - 1) + "^FS"
        'ZLabelFormat(5) = "^FO625,400^B3R,N,100,N,N^FDP" + bran.PartNumber + "^FS"
        'ZLabelFormat(6) = "^FO600,10^GB0,1190,5,B0^FS"

        'ZLabelFormat(7) = "^FO570,35^ARR,15,12^FDQUANTITY^FS"
        'ZLabelFormat(8) = "^FO545,35^ARR,15,12^FD(Q)^FS"
        'ZLabelFormat(9) = "^FO525,200^AVR,15,12^FD" + bran.prductionQty + "^FS"
        'ZLabelFormat(10) = "^FO425,100^B3R,N,100,N,N^FDQ" + bran.prductionQty + "^FS"
        'ZLabelFormat(11) = "^FO400,435^GB200,0,5,B0^FS"

        'ZLabelFormat(12) = "^FO570,475^ARR,15,12^FDDESCRIPTION^FS"
        'ZLabelFormat(13) = "^FO500,500^AVR,15,12^FD" + bran.shortDescription + "^FS"
        'ZLabelFormat(14) = "^FO440,500^AVR,15,12^FD" + bran.shortDescription + "^FS"
        'ZLabelFormat(15) = "^FO400,10^GB0,1190,5,B0^FS"

        'ZLabelFormat(16) = "^FO370,35^ARR,15,12^FDWeight^FS"
        'ZLabelFormat(17) = "^FO345,35^ARR,15,12^FD(W)^FS"
        'ZLabelFormat(18) = "^FO325,150^AVR,15,12^FD" + bran.prductionQty + "^FS"
        'ZLabelFormat(19) = "^FO225,50^B3R,N,100,N,N^FDW" + bran.prductionQty + "^FS"
        'ZLabelFormat(20) = "^FO200,350^GB200,0,5,B0^FS"

        'ZLabelFormat(40) = "^FO10,30^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        'ZLabelFormat(41) = "^PQ" + lblCount.ToString() + ",0,0,N"
        'ZLabelFormat(42) = "^XZ"
        'ZLabelLines = 42
    End Sub

    Public Sub PrintBlankLabelForSetup()
        'Create blank label with boxes only
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

        ''Fill in Verbiage

        'LabelFormat(13) = "A800,12,1,2,1,1,N," & Chr(34) & "PART NO." & Chr(34)
        'LabelFormat(14) = "A784,12,1,2,1,1,N," & Chr(34) & "CUST (P)" & Chr(34)
        'LabelFormat(15) = "A601,12,1,2,1,1,N," & Chr(34) & "QUANTITY" & Chr(34)
        'LabelFormat(16) = "A581,12,1,2,1,1,N," & Chr(34) & "(Q)" & Chr(34)
        'LabelFormat(17) = "A388,12,1,2,1,1,N," & Chr(34) & "SUPLR ID" & Chr(34)
        'LabelFormat(18) = "A365,12,1,2,1,1,N," & Chr(34) & "CUST ASSGN (V)" & Chr(34)
        'LabelFormat(19) = "A197,12,1,2,1,1,N," & Chr(34) & "PKG ID-UNIT" & Chr(34)
        'LabelFormat(20) = "A175,12,1,2,1,1,N," & Chr(34) & "(3S)" & Chr(34)
        'LabelFormat(21) = "A388,715,1,2,1,1,N," & Chr(34) & "SHIP FROM:" & Chr(34)
        'LabelFormat(22) = "A191,715,1,2,1,1,N," & Chr(34) & "DESCRIPTION" & Chr(34)
        'LabelFormat(23) = "A365,784,1,4,2,1,N," & Chr(34) & "TFP CORPORATION" & Chr(34)
        'LabelFormat(24) = "A315,784,1,4,2,1,N," & Chr(34) & "460 LAKE ROAD" & Chr(34)
        'LabelFormat(25) = "A264,784,1,4,2,1,N," & Chr(34) & "MEDINA, OHIO 44256  USA" & Chr(34)
        'LabelFormat(26) = "A219,784,1,4,2,1,N," & Chr(34) & "(330) 725-7741" & Chr(34)

        'LabelFormat(27) = "A800,122,1,4,2,1,N," & Chr(34) & V00.Substring(1, V00.Length - 1) & Chr(34)
        'LabelFormat(28) = "A601,116,1,4,2,1,N," & Chr(34) & txtQuantity.Text & Chr(34)
        'LabelFormat(29) = "A384,213,1,4,2,1,N," & Chr(34) & txtSupplierNumber.Text & Chr(34)
        'LabelFormat(30) = "A197,163,1,4,2,1,N," & Chr(34) & txtSerialLotNumber.Text & Chr(34)
        'LabelFormat(31) = "A164,721,1,3,2,1,N," & Chr(34) & V04 & Chr(34)
        'LabelFormat(32) = "A120,721,1,3,2,1,N," & Chr(34) & V05 & Chr(34)
        'LabelFormat(33) = "A63,721,1,3,2,1,N," & Chr(34) & V06 & Chr(34)

        ''Print Barcodes

        'LabelFormat(34) = "B727,81,1,3,2,4,102,N," & Chr(34) & V00 & Chr(34)
        'LabelFormat(35) = "B522,81,1,3,2,4,102,N," & Chr(34) & "Q" + txtQuantity.Text & Chr(34)
        'LabelFormat(36) = "B319,81,1,3,2,4,102,N," & Chr(34) & "V" + txtSupplierNumber.Text & Chr(34)
        'LabelFormat(37) = "B128,81,1,3,2,4,102,N," & Chr(34) & "3S" + txtSerialLotNumber.Text & Chr(34)

        'Print Label
        LabelFormat(39) = vbFormFeed
        LabelLines = 38
    End Sub

    Public Sub itemCommentLabel(ByVal itm As itemComment, Optional ByVal lblCount As Integer = 1)
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "A800,35,1,3,2,1,N," + Chr(34) + "PART NUMBER" + Chr(34)
        LabelFormat(13) = "A763,75,1,4,2,2,N," + Chr(34) + itm.partNumber + Chr(34)
        LabelFormat(9) = "A713,35,1,3,2,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(15) = "A676,75,1,4,2,2,N," + Chr(34) + itm.description1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(16) = "A617,75,1,4,2,2,N," + Chr(34) + itm.description2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(17) = "A558,75,1,4,2,2,N," + Chr(34) + itm.description3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(18) = "LO504,8,1,1196"
        LabelFormat(10) = "A501,35,1,3,2,1,N," + Chr(34) + "COMMENTS" + Chr(34)
        LabelFormat(19) = "A464,75,1,4,2,2,N," + Chr(34) + itm.comment1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(20) = "A405,75,1,4,2,2,N," + Chr(34) + itm.comment2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(21) = "A346,75,1,4,2,2,N," + Chr(34) + itm.comment3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(22) = "LO291,8,1,1196"
        LabelFormat(11) = "A289,35,1,3,2,1,N," + Chr(34) + "ADDITIONAL COMMENTS" + Chr(34)
        LabelFormat(23) = "A252,75,1,4,2,2,N," + Chr(34) + itm.additionalComment.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(24) = "LO198,8,1,1196"
        LabelFormat(12) = "A195,35,1,3,2,1,N," + Chr(34) + "QUANTITY" + Chr(34)
        LabelFormat(25) = "A158,75,1,5,2,2,N," + Chr(34) + itm.quantity + Chr(34)
        LabelFormat(14) = "LO716,8,1,1196"
        LabelFormat(26) = "P" + lblCount.ToString()
        LabelFormat(27) = vbFormFeed
        LabelLines = 26

        ' ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO770,35^ARR,15,12^FDPART NUMBER^FS"
        ZLabelFormat(4) = "^FO700,75^AVR,80,12^FD" + itm.partNumber + "^FS"
        ZLabelFormat(5) = "^FO700,10^GB0,1190,3,B0^FS"

        ZLabelFormat(6) = "^FO665,35^ARR,15,12^FDDESCRIPTION^FS"
        ZLabelFormat(7) = "^FO600,75^AVR,15,12^FD" + itm.description1 + "^FS"
        ZLabelFormat(8) = "^FO535,75^AVR,15,12^FD" + itm.description2 + "^FS"
        ZLabelFormat(9) = "^FO470,75^AVR,15,12^FD" + itm.description3 + "^FS"
        ZLabelFormat(10) = "^FO470,10^GB0,1190,3,B0^FS"

        ZLabelFormat(11) = "^FO435,35^ARR,15,12^FDCOMMENTS^FS"
        ZLabelFormat(12) = "^FO370,75^AVR,15,12^FD" + itm.comment1 + "^FS"
        ZLabelFormat(13) = "^FO305,75^AVR,15,12^FD" + itm.comment2 + "^FS"
        ZLabelFormat(14) = "^FO240,75^AVR,15,12^FD" + itm.comment3 + "^FS"
        ZLabelFormat(15) = "^FO240,10^GB0,1190,3,B0^FS"

        ZLabelFormat(16) = "^FO205,35^ARR,15,12^FDADDITIONAL COMMENTS^FS"
        ZLabelFormat(17) = "^FO140,75^AVR,15,12^FD" + itm.additionalComment + "^FS"
        ZLabelFormat(18) = "^FO140,10^GB0,1190,3,B0^FS"

        ZLabelFormat(19) = "^FO105,35^ARR,15,12^FDQUANTITY^FS"
        ZLabelFormat(20) = "^FO10,100^A0R,100,100^FD" + itm.quantity + "^FS"

        ZLabelFormat(21) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(22) = "^XZ"
        ZLabelLines = 22
    End Sub

    Public Sub shippingPalletLabel(ByVal ship As shippingPallet, Optional ByVal lblCount As Integer = 1)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "LO60,900,1,100"
        LabelFormat(9) = "LO60,950,1,100"
        LabelFormat(10) = "A35,10,1,3,1,1,N," + Chr(34) + ship.divisionInfo.ToUpper() + Chr(34)
        LabelFormat(11) = "A662,40,1,5,2,1,N," + Chr(34) + ship.shipTo.ToUpper() + Chr(34)
        LabelFormat(12) = "A554,40,1,5,2,1,N," + Chr(34) + ship.street.ToUpper() + Chr(34)
        LabelFormat(13) = "A432,40,1,5,2,1,N," + Chr(34) + ship.address2.ToUpper() + Chr(34)
        LabelFormat(14) = "A323,40,1,5,2,1,N," + Chr(34) + ship.address1.ToUpper() + Chr(34)
        LabelFormat(15) = "A223,40,1,5,2,1,N," + Chr(34) + ship.country.ToUpper() + Chr(34)
        LabelFormat(16) = "A100,700,1,4,2,1,N," + Chr(34) + "PALLET        OF" + Chr(34)
        LabelFormat(17) = "P" + lblCount.ToString()
        LabelFormat(18) = vbFormFeed
        LabelLines = 17

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO560,20^A0R,100,75^FD" + ship.shipTo.ToUpper() + "^FS"
        ZLabelFormat(3) = "^FO460,20^A0R,100,75^FD" + ship.street.ToUpper() + "^FS"
        ZLabelFormat(4) = "^FO360,20^A0R,100,75^FD" + ship.address2.ToUpper() + "^FS"
        ZLabelFormat(5) = "^FO260,20^A0R,100,75^FD" + ship.address1.ToUpper() + "^FS"
        ZLabelFormat(6) = "^FO160,20^A0R,100,75^FD" + ship.country.ToUpper() + "^FS"
        ZLabelFormat(7) = "^FO50,550^AVR,15,12^FDPALLET        OF^FS"
        ZLabelFormat(8) = "^FO20,10^AAR,20,10^FD" + ship.divisionInfo.ToUpper() + "^FS"
        ZLabelFormat(9) = "^PQ" + lblCount.ToString() + ",0,0,N"
        ZLabelFormat(10) = "^XZ"
        ZLabelLines = 10
    End Sub

    Public Sub setupToolLabel(Optional ByVal toolID As Integer = 0)
        Dim cmd As New SqlCommand("", con)
        Dim tool As New toolLabel
        If toolID = 0 Then
            cmd.CommandText = "SELECT ToolOD, ToolFirstLength, ToolFirstID, ToolSecondLength, ToolSecondID, ToolThirdLength, ToolThirdID, ToolFourthLength, ToolFourthID, BluePrint, Section, WangTypeID, Material, SectionRow, SectionColumn, DateCreated FROM ToolInventory WHERE ToolID = (SELECT isnull(MAX(ToolID), 1) FROM ToolInventory);"
        Else
            cmd.CommandText = "SELECT ToolOD, ToolFirstLength, ToolFirstID, ToolSecondLength, ToolSecondID, ToolThirdLength, ToolThirdID, ToolFourthLength, ToolFourthID, BluePrint, Section, WangTypeID, Material, SectionRow, SectionColumn, DateCreated FROM ToolInventory WHERE ToolID = @ToolID;"
            cmd.Parameters.Add("@ToolID", SqlDbType.Int).Value = toolID
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ToolOD")) Then
                tool.OD = 0
            Else
                tool.OD = reader.Item("ToolOD")
            End If
            If IsDBNull(reader.Item("ToolFirstLength")) Then
                tool.FirstLen = 0
            Else
                tool.FirstLen = reader.Item("ToolFirstLength")
            End If
            If IsDBNull(reader.Item("ToolFirstID")) Then
                tool.FirstID = 0
            Else
                tool.FirstID = reader.Item("ToolFirstID")
            End If
            If IsDBNull(reader.Item("ToolSecondLength")) Then
                tool.SecondLen = 0
            Else
                tool.SecondLen = reader.Item("ToolSecondLength")
            End If
            If IsDBNull(reader.Item("ToolSecondID")) Then
                tool.SecondID = 0
            Else
                tool.SecondID = reader.Item("ToolSecondID")
            End If
            If IsDBNull(reader.Item("ToolThirdLength")) Then
                tool.ThirdLen = 0
            Else
                tool.ThirdLen = reader.Item("ToolThirdLength")
            End If
            If IsDBNull(reader.Item("ToolThirdID")) Then
                tool.ThirdID = 0
            Else
                tool.ThirdID = reader.Item("ToolThirdID")
            End If
            If IsDBNull(reader.Item("ToolFourthLength")) Then
                tool.FourthLen = 0
            Else
                tool.FourthLen = reader.Item("ToolFourthLength")
            End If
            If IsDBNull(reader.Item("ToolFourthID")) Then
                tool.FourthID = 0
            Else
                tool.FourthID = reader.Item("ToolFourthID")
            End If
            If IsDBNull(reader.Item("BluePrint")) Then
                tool.blueprint = ""
            Else
                tool.blueprint = reader.Item("BluePrint")
            End If
            If IsDBNull(reader.Item("Section")) Then
                tool.Section = ""
            Else
                tool.Section = reader.Item("Section")
            End If
            If IsDBNull(reader.Item("WangTypeID")) Then
                tool.WangType = ""
            Else
                tool.WangType = reader.Item("WangTypeID")
            End If
            If IsDBNull(reader.Item("Material")) Then
                tool.material = ""
            Else
                tool.material = reader.Item("Material")
            End If
            If IsDBNull(reader.Item("SectionRow")) Then
                tool.Row = ""
            Else
                tool.Row = reader.Item("SectionRow")
            End If
            If IsDBNull(reader.Item("SectionColumn")) Then
                tool.Column = ""
            Else
                tool.Column = reader.Item("SectionColumn")
            End If
            If IsDBNull(reader.Item("DateCreated")) Then
                tool.Dat = Today.Date.ToShortDateString()
            Else
                tool.Dat = reader.Item("DateCreated")
            End If
        Else
            tool.OD = 0
            tool.FirstLen = 0
            tool.FirstID = 0
            tool.SecondLen = 0
            tool.SecondID = 0
            tool.ThirdLen = 0
            tool.ThirdID = 0
            tool.FourthLen = 0
            tool.FourthID = 0
            tool.blueprint = ""
            tool.Section = ""
            tool.material = ""
            tool.Row = ""
            tool.Column = ""
            tool.Dat = Today.Date.ToShortDateString()
        End If
        reader.Close()
        con.Close()

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q609"
        LabelFormat(2) = "Q203,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        Dim rw As String = ""
        If tool.Row < 10 Then
            rw = "0" + tool.Row.ToString()
        End If
        Dim cl As String = ""
        If tool.Column < 10 Then
            cl = "0" + tool.Column.ToString()
        Else
            cl = tool.Column.ToString()
        End If
        LabelFormat(8) = "A75,20,0,4,1,1,N," + Chr(34) + tool.WangType + " S" + tool.Section + " R" + rw + " C" + cl + "  " + tool.Dat + Chr(34)
        LabelFormat(9) = "A40,50,0,4,1,1,N," + Chr(34) + "O.D.  LEN   ID-1  ID-2  LEN2  ID-3" + Chr(34)
        LabelFormat(10) = "A40,80,0,4,1,1,N," + Chr(34) + tool.OD.ToString()
        For i As Integer = tool.OD.ToString.Count() To 5
            LabelFormat(10) += " "
        Next
        LabelFormat(10) += tool.FirstLen.ToString()
        For i As Integer = tool.FirstLen.ToString.Count() To 5
            LabelFormat(10) += " "
        Next
        LabelFormat(10) += tool.FirstID.ToString()
        For i As Integer = tool.FirstID.ToString.Count() To 5
            LabelFormat(10) += " "
        Next
        If tool.SecondID <> 0 Then
            LabelFormat(10) += tool.SecondID.ToString()
            For i As Integer = tool.SecondID.ToString().Count() To 5
                LabelFormat(10) += " "
            Next
        Else
            LabelFormat(10) += "     "
        End If
        If tool.SecondLen <> 0 Then
            LabelFormat(10) += tool.SecondLen.ToString()
            For i As Integer = tool.SecondLen.ToString().Count() To 5
                LabelFormat(10) += " "
            Next
        Else
            LabelFormat(10) += "     "
        End If
        If tool.ThirdID <> 0 Then
            LabelFormat(10) += tool.ThirdID.ToString() + Chr(34)
        Else
            LabelFormat(10) += Chr(34)
        End If
        LabelFormat(11) = "A40,110,0,4,1,1,N," + Chr(34) + "LEN3  ID-4  LEN4    B/P  MTL" + Chr(34)
        If tool.ThirdLen <> 0 Then
            LabelFormat(12) = "A40,140,0,4,1,1,N," + Chr(34) + tool.ThirdLen.ToString()
            For i As Integer = tool.ThirdLen.ToString.Count() To 5
                LabelFormat(12) += " "
            Next
        Else
            LabelFormat(12) = "A40,140,0,4,1,1,N," + Chr(34) + "       "
        End If
        If tool.FourthID <> 0 Then
            LabelFormat(12) += tool.FourthID.ToString()
            For i As Integer = tool.FourthID.ToString.Count() To 5
                LabelFormat(12) += " "
            Next
        Else
            LabelFormat(12) += "      "
        End If
        If tool.FourthLen <> 0 Then
            LabelFormat(12) += tool.FourthLen.ToString()
            For i As Integer = tool.FourthLen.ToString.Count() To 5
                LabelFormat(12) += " "
            Next
        Else
            LabelFormat(12) += "      "
        End If
        If Not tool.blueprint.Equals("0") Then
            LabelFormat(12) += tool.blueprint + "  " + tool.material + Chr(34)
        Else
            LabelFormat(12) += "  " + tool.blueprint + "    " + tool.material + Chr(34)
        End If
        'LabelFormat(12) += tool.blueprint + "  " + tool.material + Chr(34)
        LabelFormat(13) = "P1"
        LabelLines = 13

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW609^LL203"
        ZLabelFormat(2) = "^FO40,20^ARN,15,12^FD" + tool.WangType + "  S" + tool.Section + "  R" + rw + "  C" + cl + "  " + tool.Dat + "^FS"
        ZLabelFormat(3) = "^FO10,50^ARN,15,12^FDO.D.   LEN    ID-1   ID-2   LEN2   ID-3^FS"
        ZLabelFormat(4) = "^FO10,80^ARN,15,12^FD" + tool.OD.ToString() + "^FS"
        ZLabelFormat(5) = "^FO90,80^ARN,15,12^FD" + tool.FirstLen.ToString() + "^FS"
        ZLabelFormat(6) = "^FO180,80^ARN,15,12^FD" + tool.FirstID.ToString() + "^FS"
        If tool.SecondID <> 0 Then
            ZLabelFormat(7) = "^FO270,80^ARN,15,12^FD" + tool.SecondID.ToString() + "^FS"
        Else
            ZLabelFormat(7) = "^FO270,80^ARN,15,12^FD ^FS"
        End If
        If tool.SecondLen <> 0 Then
            ZLabelFormat(8) = "^FO360,80^ARN,15,12^FD" + tool.SecondLen.ToString() + "^FS"
        Else
            ZLabelFormat(8) = "^FO360,80^ARN,15,12^FD ^FS"
        End If
        If tool.ThirdID <> 0 Then
            ZLabelFormat(9) = "^FO450,80^ARN,15,12^FD" + tool.ThirdID.ToString() + "^FS"
        Else
            ZLabelFormat(9) = "^FO450,80^ARN,15,12^FD ^FS"
        End If
        ZLabelFormat(10) = "^FO10,110^ARN,15,12^FDLEN3   ID-4   LEN4     B/P   MTL^FS"
        If tool.ThirdLen <> 0 Then
            ZLabelFormat(12) = "^FO10,140^ARN,15,12^FD" + tool.ThirdLen.ToString() + "^FS"
        Else
            ZLabelFormat(12) = "^FO10,140^ARN,15,12^FD ^FS"
        End If
        If tool.FourthID <> 0 Then
            ZLabelFormat(13) = "^FO100,140^ARN,15,12^FD" + tool.FourthID.ToString() + "^FS"
        Else
            ZLabelFormat(13) = "^FO100,140^ARN,15,12^FD ^FS"
        End If
        If tool.FourthLen <> 0 Then
            ZLabelFormat(14) = "^FO190,140^ARN,15,12^FD" + tool.FourthLen.ToString() + "^FS"
        Else
            ZLabelFormat(14) = "^FO190,140^ARN,15,12^FD ^FS"
        End If
        ZLabelFormat(15) = "^FO280,140^ARN,15,12^FD" + tool.blueprint + "^FS"
        ZLabelFormat(16) = "^FO370,140^ARN,15,12^FD" + tool.material + "^FS"
        ZLabelFormat(17) = "^PQ1,0,0,N"
        ZLabelFormat(18) = "^XZ"
        ZLabelLines = 18
    End Sub

    Public Sub SetupSampleLabel(ByVal annealLot As String)
        Dim cmd As SqlCommand = New SqlCommand("SELECT Carbon, SteelSize, HeatNumber, Base, Program, TotalPoundsAnnealed, DateIn, DateOut FROM AnnealingLog LEFT OUTER JOIN RawMaterialsTable ON AnnealingLog.RMID = RawMaterialsTable.RMID WHERE AnnealLotNumber = @AnnealLotNumber;", con)
        cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = annealLot
        Dim carb As String = ""
        Dim siz As String = ""
        Dim heat As String = ""
        Dim base As String = ""
        Dim prog As String = ""
        Dim totPounds As Double = 0D
        Dim dateIn As DateTime = Today.Date
        Dim dateOut As DateTime = Today.Date

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            carb = reader.Item("Carbon")
            siz = reader.Item("SteelSize")
            heat = reader.Item("HeatNumber")
            base = reader.Item("Base")
            prog = reader.Item("Program")
            totPounds = reader.Item("TotalPoundsAnnealed")
            dateIn = reader.Item("DateIn")
            dateOut = reader.Item("DateOut")
        End If
        reader.Close()
        con.Close()

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "A800,175,1,3,4,3,N," + Chr(34) + "Anneal Sample Piece" + Chr(34)
        LabelFormat(9) = "A700,75,1,2,4,3,N," + Chr(34) + "Carbon - " + carb + Chr(34)
        LabelFormat(10) = "A630,75,1,2,4,3,N," + Chr(34) + "Steel Size - " + siz + Chr(34)
        LabelFormat(11) = "A560,75,1,2,4,3,N," + Chr(34) + "Heat - " + heat + Chr(34)
        LabelFormat(12) = "A490,75,1,2,4,3,N," + Chr(34) + "Total Weight Annealed - " + totPounds.ToString() + Chr(34)
        LabelFormat(13) = "A420,75,1,2,4,3,N," + Chr(34) + "Anneal Lot - " + annealLot + Chr(34)
        LabelFormat(14) = "A350,75,1,2,4,3,N," + Chr(34) + "Base - " + base + Chr(34)
        LabelFormat(15) = "A280,75,1,2,4,3,N," + Chr(34) + "Program - " + prog + Chr(34)
        LabelFormat(16) = "A210,75,1,2,3,3,N," + Chr(34) + "Date In - " + dateIn.ToShortDateString() + Chr(34)
        LabelFormat(17) = "A160,75,1,2,3,3,N," + Chr(34) + "Date Out - " + dateOut.ToShortDateString() + Chr(34)
        LabelFormat(18) = "A25,100,1,2,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH. 44256 (330) 725-7741" + Chr(34)
        'Print Label
        LabelFormat(19) = "P1"
        LabelLines = 19

        ''ZPL Commands
        ZLabelFormat(0) = "^XA"
        ZLabelFormat(1) = "^PW800"
        ZLabelFormat(2) = "^FO650,200^AGR,100,12^FDAnneal Sample Piece^FS"
        ZLabelFormat(3) = "^FO550,250^AVR,15,12^FDCarbon - " + carb + "^FS"
        ZLabelFormat(4) = "^FO485,250^AVR,15,12^FDSteel Size - " + siz + "^FS"
        ZLabelFormat(5) = "^FO420,250^AVR,15,12^FDHeat - " + heat + "^FS"
        ZLabelFormat(6) = "^FO355,250^AVR,15,12^FDTotal Weight Annealed - " + totPounds.ToString() + "^FS"
        ZLabelFormat(7) = "^FO290,250^AVR,15,12^FDAnneal Lot - " + annealLot + "^FS"
        ZLabelFormat(8) = "^FO225,250^AVR,15,12^FDBase - " + base + "^FS"
        ZLabelFormat(9) = "^FO160,250^AVR,15,12^FDProgram - " + prog + "^FS"
        ZLabelFormat(10) = "^FO95,250^AVR,15,12^FDDate In - " + dateIn.ToShortDateString() + "^FS"
        ZLabelFormat(11) = "^FO30,250^AVR,15,12^FDDate Out - " + dateOut.ToShortDateString() + "^FS"
        ZLabelFormat(12) = "^FO10,50^AAR,20,10^FDTFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
        ZLabelFormat(13) = "^PQ1,0,0,N"
        ZLabelFormat(14) = "^XZ"
        ZLabelLines = 14
    End Sub

    Public Sub PrintBarcodeLine(Optional ByVal findPrinter As String = "")
        If String.IsNullOrEmpty(findPrinter) Then
            findPrinter = "Zebra" + EmployeeCompanyCode
        End If
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
            If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains(findPrinter) Then
                pd.PrinterSettings.PrinterName = printers(i)
            End If
            i += 1
        End While
        ''checks to see if a printer was selected and if not will show the dialog
        If String.IsNullOrEmpty(pd.PrinterSettings.PrinterName) Then
            If String.IsNullOrEmpty(printerName) Then
                pd.PrinterSettings.Copies = Val(LabelFormat(LabelLines).Substring(1, LabelFormat(LabelLines).Length - 1))
                ' Open the printer dialog box, and then allow the user to select a printer.
                If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    LabelFormat(LabelLines) = "P" + pd.PrinterSettings.Copies.ToString()
                    sendToPrinter(pd.PrinterSettings.PrinterName)
                    printerName = pd.PrinterSettings.PrinterName
                End If
            Else
                sendToPrinter(printerName)
            End If
        Else
            sendToPrinter(pd.PrinterSettings.PrinterName)
        End If
    End Sub

    Private Sub sendToPrinter(ByVal printerName As String)
        Dim s As String = ""
        If canPrintZPL(printerName) Then
            For i = 0 To ZLabelLines
                ' You need a string to send.
                s += ZLabelFormat(i) + Environment.NewLine
            Next i
        Else
            For i = 0 To LabelLines
                ' You need a string to send.
                s += LabelFormat(i) + Environment.NewLine
            Next i
        End If
        If s <> "" Then
            RawPrinter.SendStringToPrinter(printerName, s)
        End If
        clearFormat()
    End Sub

    Private Function canPrintZPL(ByVal printer As String) As Boolean
        ' Add a Reference to System.Management
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Try
            moSearch = New Management.ManagementObjectSearcher("Select * from Win32_Printer Where Name = '" + printer + "'")
            moReturn = moSearch.Get
            If moReturn.Count = 0 Then
                Return False
            End If
            Dim driverName As String = moReturn(0)("DriverName")

            Select Case driverName
                Case "ZDesigner TLP 2844"
                    Return False
                Case "ZDesigner TLP 2844-Z"
                    Return True
                Case "ZDesigner GC420t"
                    Return False
                Case Else
                    Return False
            End Select
        Catch ex As System.Exception

        End Try
        Return False
    End Function

    Public Sub MixedHeatLabelSetup(Optional ByVal lblCount As Integer = 1)

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage
        If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Then
            LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
            LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
            LabelFormat(14) = "A641,150,1,5,4,3,N," + Chr(34) + "MIXED" + Chr(34)
            LabelFormat(15) = "A374,150,1,5,4,3,N," + Chr(34) + "HEAT" + Chr(34)
            LabelFormat(16) = "A375,600,1,1,4,3,N," + Chr(34) + "QUANTITY" + Chr(34)
            LabelFormat(17) = "LO325,850,5,250"
            LabelFormat(18) = "A275,600,1,1,4,3,N," + Chr(34) + "LOT #" + Chr(34)
            LabelFormat(19) = "LO225,850,5,250"
            LabelFormat(20) = "A175,600,1,1,4,3,N," + Chr(34) + "HEAT #" + Chr(34)
            LabelFormat(21) = "LO125,850,5,250"

            'Print Label
            LabelFormat(22) = "P" + lblCount.ToString()
            LabelFormat(23) = vbFormFeed
            LabelLines = 22

            ''ZPL Commands
            ZLabelFormat(0) = "^XA"
            ZLabelFormat(1) = "^PW800"
            ZLabelFormat(2) = "^FO50,50^GB700,1140,10,B0^FS"
            ZLabelFormat(3) = "^FO400,100^AGR,300,100^FDMIXED^FS"
            ZLabelFormat(4) = "^FO50,100^AGR,300,100^FDHEAT^FS"
            ZLabelFormat(5) = "^FO300,700^AER,50,20^FDQuantity^FS"
            ZLabelFormat(6) = "^FO300,900^GB5,250,5,B0^FS"
            ZLabelFormat(7) = "^FO200,700^AER,50,20^FDLot #^FS"
            ZLabelFormat(8) = "^FO200,900^GB5,250,5,B0^FS"
            ZLabelFormat(9) = "^FO100,700^AER,50,20^FDHEAT #^FS"
            ZLabelFormat(10) = "^FO100,900^GB5,250,5,B0^FS"

            ZLabelFormat(11) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
            ZLabelFormat(12) = "^PQ" + lblCount.ToString() + ",0,0,N"
            ZLabelFormat(13) = "^XZ"
            ZLabelLines = 13
        Else
            LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
            LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
            LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "MIXED" + Chr(34)
            LabelFormat(15) = "A374,540,1,5,4,3,N," + Chr(34) + "HEAT" + Chr(34)

            'Print Label

            LabelFormat(16) = "P" + lblCount.ToString()
            LabelFormat(17) = vbFormFeed
            LabelLines = 16

            ''ZPL Commands
            ZLabelFormat(0) = "^XA"
            ZLabelFormat(1) = "^PW800"
            ZLabelFormat(2) = "^FO50,50^GB700,1140,10,B0^FS"
            ZLabelFormat(3) = "^FO400,150^AGR,300,100^FDMIXED^FS"
            ZLabelFormat(4) = "^FO50,550^AGR,300,100^FDHEAT^FS"
            ZLabelFormat(5) = "^FO20,50^AAR,20,10^FDTRU-WELD DIVISION TFP CORP. MEDINA, OH. 44256 (330) 725-7741^FS"
            ZLabelFormat(6) = "^PQ" + lblCount.ToString() + ",0,0,N"
            ZLabelFormat(7) = "^XZ"
            ZLabelLines = 7
        End If

    End Sub

    Public Sub itemLabelSetup(ByVal itemId As String, ByVal Custom1 As String, ByVal Custom2 As String, Optional ByVal labelcount As Integer = 1)
        Dim cmd As New SqlCommand("SELECT ShortDescription, BoxWeight, BoxCount FROM ItemList WHERE ItemID = @ItemID and ", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = itemId
        If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            cmd.CommandText += "(DivisionID = 'TWD' or DivisionID = 'TFP')" 'employees from both division'
        Else
            cmd.CommandText += "DivisionID = @DivisionID" 'for any division'
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        End If
        Dim ds As New DataSet
        Dim myadapter As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        myadapter.Fill(ds, "ItemList")
        con.Close()

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "A750,350,1,4,3,3,N," + Chr(34) + itemId + Chr(34)
        LabelFormat(9) = "LO670,10,1,1196"
        LabelFormat(10) = "A660,10,1,4,1,1,N," + Chr(34) + "Description" + Chr(34)
        LabelFormat(11) = "LO200,10,1,1196"
        LabelFormat(12) = "A195,10,1,4,1,1,N," + Chr(34) + "Box Weight" + Chr(34)
        LabelFormat(13) = "LO5,500,200,1"
        LabelFormat(14) = "A195,505,1,4,1,1,N," + Chr(34) + "Box Quantity" + Chr(34)
        LabelFormat(15) = "A100,850,1,4,4,4,N," + Chr(34) + ds.Tables("ItemList").Rows(0).Item("BoxCount").ToString + Chr(34)
        LabelFormat(16) = "A100,200,1,4,4,4,N," + Chr(34) + ds.Tables("ItemList").Rows(0).Item("BoxWeight").ToString + Chr(34)
        LabelFormat(17) = "A790,10,1,3,1,1,N," + Chr(34) + "Part Number" + Chr(34)

        Dim lineCount As Integer = 18
        Dim description As String = ds.Tables("ItemList").Rows(0).Item("ShortDescription").ToString
        If description.Length > 22 Then
            Dim xPos As Integer = 600
            While description.Length > 0
                If description.Length <= 21 Then
                    LabelFormat(lineCount) = "A" + xPos.ToString + ",100,1,4,2,3,N," + Chr(34) + description + Chr(34)
                    description = ""
                ElseIf description(21) = " "c Then
                    LabelFormat(lineCount) = "A" + xPos.ToString + ",100,1,4,2,3,N," + Chr(34) + description.Substring(0, 22) + Chr(34)
                    If description.Length > 22 Then
                        description = description.Substring(22)
                    Else
                        description = ""
                    End If

                ElseIf description(22) = " "c Then
                    LabelFormat(lineCount) = "A" + xPos.ToString + ",100,1,4,2,3,N," + Chr(34) + description.Substring(0, 22) + Chr(34)
                    If description.Length > 23 Then
                        description = description.Substring(23)
                    Else
                        description = ""
                    End If

                Else
                    Dim currentPos As Integer = 21
                    While currentPos > 0 AndAlso description(currentPos) <> " "c
                        currentPos -= 1
                    End While
                    If currentPos = 0 Then
                        LabelFormat(lineCount) = "A" + xPos.ToString + ",100,1,4,2,3,N," + Chr(34) + description.Substring(0, 22) + Chr(34)
                        If description.Length > 22 Then
                            description = description.Substring(22)
                        Else
                            description = ""
                        End If
                    Else
                        LabelFormat(lineCount) = "A" + xPos.ToString + ",100,1,4,2,3,N," + Chr(34) + description.Substring(0, currentPos + 1) + Chr(34)
                        If description.Length > currentPos Then
                            description = description.Substring(currentPos)
                        Else
                            description = ""
                        End If
                    End If
                End If
                xPos -= 45
                lineCount += 1
            End While
        End If
        LabelFormat(lineCount) = "A350,10,1,4,2,2,N," + Chr(34) + Custom1 + Chr(34)
        lineCount += 1
        LabelFormat(lineCount) = "A280,10,1,4,2,2,N," + Chr(34) + Custom2 + Chr(34)
        lineCount += 1
        LabelFormat(lineCount) = "LO280,10,1,1196"
        lineCount += 1
        LabelFormat(lineCount) = "LO350,10,1,1196"
        lineCount += 1
        LabelFormat(lineCount) = "P" + labelcount.ToString

        LabelLines = lineCount
    End Sub

    Public Sub BinLabelWithArrow(ByVal location As String, ByVal copies As Integer, ByVal ArrowPoint As String)
        bmp = New Bitmap(600, 800)
        Dim gr As Graphics = Graphics.FromImage(bmp)
        Dim pn As New System.Drawing.Pen(Color.Black, 20)
        ''Should hlep with resolution issues
        gr.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        gr.InterpolationMode = Drawing2D.InterpolationMode.Bicubic
        gr.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

        Select Case ArrowPoint
            Case "Up"
                ''LEFT
                gr.DrawLine(pn, 20, 150, 100, 50)
                ''RIGHT
                gr.DrawLine(pn, 100, 50, 180, 150)
                ''CENTER
                gr.DrawLine(pn, 100, 45, 100, 355)
            Case "Down"
                ''LEFT
                gr.DrawLine(pn, 100, 350, 20, 250)
                ''RIGHT
                gr.DrawLine(pn, 180, 250, 100, 350)
                ''CENTER
                gr.DrawLine(pn, 100, 45, 100, 355)
            Case "Left"
                ''TOP
                gr.DrawLine(pn, 25, 200, 100, 100)
                ''BOTTOM
                gr.DrawLine(pn, 25, 200, 100, 300)
                ''CENTER
                gr.DrawLine(pn, 15, 200, 255, 200)
            Case "Right"
                ''TOP
                gr.DrawLine(pn, 170, 100, 250, 200)
                ''BOTTOM
                gr.DrawLine(pn, 170, 300, 250, 200)
                ''CENTER
                gr.DrawLine(pn, 15, 200, 258, 200)
        End Select
        gr.DrawString(location, New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 85, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 200, 20)

        If CBool(String.Compare("IDAutomationHC39M Free Version", New System.Drawing.Font("IDAutomationHC39M Free Version", 10).Name, StringComparison.InvariantCultureIgnoreCase) = 0) Then
            gr.DrawString("*" + location + "*", New System.Drawing.Font("IDAutomationHC39M Free Version", 36, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 200, 200)
            gr.FillRectangle(Brushes.White, 200, 350, 600, 100)
        Else
            Dim bar As New Barcode39
            gr.DrawImage(bar.GetBarcode(location), 300, 150, 250, 200)
        End If

        PrintLabelDocument()
    End Sub

    Private Sub PrintLabelDocument()
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
                pd.PrinterSettings.Copies = 1
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
                pd.PrinterSettings.Copies = 1
                pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
                pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                pd.PrinterSettings.DefaultPageSettings.Landscape = True
                pd.PrinterSettings.PrinterName = printerName
                doc.PrinterSettings = pd.PrinterSettings
                AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
                doc.Print()
            End If
        Else
            pd.PrinterSettings.Copies = 1
            pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
            pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
            pd.PrinterSettings.DefaultPageSettings.Landscape = True
            doc.PrinterSettings = pd.PrinterSettings
            AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
            doc.Print()
        End If
    End Sub

    Private Sub PrintJournalDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        ''draws the image on the document being printed
        e.Graphics.DrawImage(bmp.GetThumbnailImage(600, 600, Nothing, Nothing), New System.Drawing.Rectangle(0, 0, 600, 600))
    End Sub
End Class
