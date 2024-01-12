Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class MillCertForm
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim ValidateRMID As Integer = 0

    'Dim isLoaded As Boolean = False
    Dim NoStopSkip As Boolean = True
    Dim controlKey As Boolean = False

    Private Const InspectionDir As String = "\\TFP-FS\TransferData\Steel Receiving Inspection"

    'Form Events

    Private Sub MillCertForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        usefulFunctions.LoadSecurity(Me)

        LoadVendor()
        LoadHeatFileNumber()
        LoadHeatNumber()
        LoadSteelCarbon()
        LoadSteelSize()
        ClearData()

        If GlobalHeatFileNumber <> 0 Then
            cboHeatFileNumber.Text = GlobalHeatFileNumber
        End If

        cboHeatNumber.Focus()
    End Sub

    Private Sub MillCertForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        GlobalHeatFileNumber = 0
    End Sub

    'Load Commands

    Private Sub LoadHeatFileNumber()
        cmd = New SqlCommand("SELECT HeatFileNumber FROM HeatNumberLog ORDER BY HeatFileNumber DESC;", con)
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "HeatNumberLog")
        con.Close()

        cboHeatFileNumber.DisplayMember = "HeatFileNumber"
        cboHeatFileNumber.DataSource = ds5.Tables("HeatNumberLog")
        cboHeatFileNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon ASC", con)
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(ds6, "RawMaterialsTable")
        con.Close()

        cboSteelCarbon.DisplayMember = "Carbon"
        cboSteelCarbon.DataSource = ds6.Tables("RawMaterialsTable")
        cboSteelCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize ASC", con)
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter7.Fill(ds7, "RawMaterialsTable")
        con.Close()

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = ds7.Tables("RawMaterialsTable")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadTolerances()
        Dim NiobiumMinimum, NiobiumMaximum, CarbonMinimum, CarbonMaximum, ManganeseMinimum, ManganeseMaximum, PhosphorusMinimum, PhosphorusMaximum, SulfurMinimum, SulfurMaximum, SiliconMinimum, SiliconMaximum, CopperMinimum, CopperMaximum, NickelMinimum, NickelMaximum, ChromiumMinimum, ChromiumMaximum, MolybdenumMinimum, MolybdenumMaximum, TinMinimum, TinMaximum, AluminumMinimum, AluminumMaximum, NitrogenMinimum, NitrogenMaximum, VanadiumMinimum, VanadiumMaximum, BoronMinimum, BoronMaximum, TitaniumMinimum, TitaniumMaximum, CarbideMinimum, CarbideMaximum, CobaltMinimum, CobaltMaximum, ZincMinimum, ZincMaximum, IronMinimum, IronMaximum, LeadMinimum, LeadMaximum, TungstenMinimum, TungstenMaximum, MagnesiumMinimum, MagnesiumMaximum As Double

        cmd = New SqlCommand("SELECT * FROM SteelChemistryTolerances WHERE Alloy = @Alloy;", con)
        If cboSteelCarbon.Text.EndsWith("DB") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = cboSteelCarbon.Text.Substring(0, cboSteelCarbon.Text.IndexOf("DB"))
        ElseIf cboSteelCarbon.Text.Contains("C1010X") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1010XAK"
        ElseIf cboSteelCarbon.Text.Contains("C1015X") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1015XAK"
        ElseIf cboSteelCarbon.Text.Contains("C1015AK") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1015XAK"
        ElseIf cboSteelCarbon.Text.Contains("C1015APP") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1015"
        ElseIf cboSteelCarbon.Text.Contains("C1010APP") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1010"
        ElseIf cboSteelCarbon.Text.Contains("C1015S") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1015"
        ElseIf cboSteelCarbon.Text.Contains("C1010AK") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1010"
        ElseIf cboSteelCarbon.Text.Contains("C1018AK") Then
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = "C1018XAK"
        Else
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CarbonMinimum")) Then
                CarbonMinimum = 0
            Else
                CarbonMinimum = reader.Item("CarbonMinimum")
            End If
            If IsDBNull(reader.Item("CarbonMaximum")) Then
                CarbonMaximum = 0
            Else
                CarbonMaximum = reader.Item("CarbonMaximum")
            End If
            If IsDBNull(reader.Item("ManganeseMinimum")) Then
                ManganeseMinimum = 0
            Else
                ManganeseMinimum = reader.Item("ManganeseMinimum")
            End If
            If IsDBNull(reader.Item("ManganeseMaximum")) Then
                ManganeseMaximum = 0
            Else
                ManganeseMaximum = reader.Item("ManganeseMaximum")
            End If
            If IsDBNull(reader.Item("PhosphorusMinimum")) Then
                PhosphorusMinimum = 0
            Else
                PhosphorusMinimum = reader.Item("PhosphorusMinimum")
            End If
            If IsDBNull(reader.Item("PhosphorusMaximum")) Then
                PhosphorusMaximum = 0
            Else
                PhosphorusMaximum = reader.Item("PhosphorusMaximum")
            End If
            If IsDBNull(reader.Item("SulfurMinimum")) Then
                SulfurMinimum = 0
            Else
                SulfurMinimum = reader.Item("SulfurMinimum")
            End If
            If IsDBNull(reader.Item("SulfurMaximum")) Then
                SulfurMaximum = 0
            Else
                SulfurMaximum = reader.Item("SulfurMaximum")
            End If
            If IsDBNull(reader.Item("SiliconMinimum")) Then
                SiliconMinimum = 0
            Else
                SiliconMinimum = reader.Item("SiliconMinimum")
            End If
            If IsDBNull(reader.Item("SiliconMaximum")) Then
                SiliconMaximum = 0
            Else
                SiliconMaximum = reader.Item("SiliconMaximum")
            End If
            If IsDBNull(reader.Item("CopperMinimum")) Then
                CopperMinimum = 0
            Else
                CopperMinimum = reader.Item("CopperMinimum")
            End If
            If IsDBNull(reader.Item("CopperMaximum")) Then
                CopperMaximum = 0
            Else
                CopperMaximum = reader.Item("CopperMaximum")
            End If
            If IsDBNull(reader.Item("NickelMinimum")) Then
                NickelMinimum = 0
            Else
                NickelMinimum = reader.Item("NickelMinimum")
            End If
            If IsDBNull(reader.Item("NickelMaximum")) Then
                NickelMaximum = 0
            Else
                NickelMaximum = reader.Item("NickelMaximum")
            End If
            If IsDBNull(reader.Item("ChromiumMinimum")) Then
                ChromiumMinimum = 0
            Else
                ChromiumMinimum = reader.Item("ChromiumMinimum")
            End If
            If IsDBNull(reader.Item("ChromiumMaximum")) Then
                ChromiumMaximum = 0
            Else
                ChromiumMaximum = reader.Item("ChromiumMaximum")
            End If
            If IsDBNull(reader.Item("MolybdenumMinimum")) Then
                MolybdenumMinimum = 0
            Else
                MolybdenumMinimum = reader.Item("MolybdenumMinimum")
            End If
            If IsDBNull(reader.Item("MolybdenumMaximum")) Then
                MolybdenumMaximum = 0
            Else
                MolybdenumMaximum = reader.Item("MolybdenumMaximum")
            End If
            If IsDBNull(reader.Item("TinMinimum")) Then
                TinMinimum = 0
            Else
                TinMinimum = reader.Item("TinMinimum")
            End If
            If IsDBNull(reader.Item("TinMaximum")) Then
                TinMaximum = 0
            Else
                TinMaximum = reader.Item("TinMaximum")
            End If
            If IsDBNull(reader.Item("AluminumMinimum")) Then
                AluminumMinimum = 0
            Else
                AluminumMinimum = reader.Item("AluminumMinimum")
            End If
            If IsDBNull(reader.Item("AluminumMaximum")) Then
                AluminumMaximum = 0
            Else
                AluminumMaximum = reader.Item("AluminumMaximum")
            End If
            If IsDBNull(reader.Item("NitrogenMinimum")) Then
                NitrogenMinimum = 0
            Else
                NitrogenMinimum = reader.Item("NitrogenMinimum")
            End If
            If IsDBNull(reader.Item("NitrogenMaximum")) Then
                NitrogenMaximum = 0
            Else
                NitrogenMaximum = reader.Item("NitrogenMaximum")
            End If
            If IsDBNull(reader.Item("VanadiumMinimum")) Then
                VanadiumMinimum = 0
            Else
                VanadiumMinimum = reader.Item("VanadiumMinimum")
            End If
            If IsDBNull(reader.Item("VanadiumMaximum")) Then
                VanadiumMaximum = 0
            Else
                VanadiumMaximum = reader.Item("VanadiumMaximum")
            End If
            If IsDBNull(reader.Item("BoronMinimum")) Then
                BoronMinimum = 0
            Else
                BoronMinimum = reader.Item("BoronMinimum")
            End If
            If IsDBNull(reader.Item("BoronMaximum")) Then
                BoronMaximum = 0
            Else
                BoronMaximum = reader.Item("BoronMaximum")
            End If
            If IsDBNull(reader.Item("TitaniumMinimum")) Then
                TitaniumMinimum = 0
            Else
                TitaniumMinimum = reader.Item("TitaniumMinimum")
            End If
            If IsDBNull(reader.Item("TitaniumMaximum")) Then
                TitaniumMaximum = 0
            Else
                TitaniumMaximum = reader.Item("TitaniumMaximum")
            End If
            If IsDBNull(reader.Item("CarbideMinimum")) Then
                CarbideMinimum = 0
            Else
                CarbideMinimum = reader.Item("CarbideMinimum")
            End If
            If IsDBNull(reader.Item("CarbideMaximum")) Then
                CarbideMaximum = 0
            Else
                CarbideMaximum = reader.Item("CarbideMaximum")
            End If
            If IsDBNull(reader.Item("CobaltMinimum")) Then
                CobaltMinimum = 0
            Else
                CobaltMinimum = reader.Item("CobaltMinimum")
            End If
            If IsDBNull(reader.Item("CobaltMaximum")) Then
                CobaltMaximum = 0
            Else
                CobaltMaximum = reader.Item("CobaltMaximum")
            End If
            If IsDBNull(reader.Item("ZincMinimum")) Then
                ZincMinimum = 0
            Else
                ZincMinimum = reader.Item("ZincMinimum")
            End If
            If IsDBNull(reader.Item("ZincMaximum")) Then
                ZincMaximum = 0
            Else
                ZincMaximum = reader.Item("ZincMaximum")
            End If
            If IsDBNull(reader.Item("IronMinimum")) Then
                IronMinimum = 0
            Else
                IronMinimum = reader.Item("IronMinimum")
            End If
            If IsDBNull(reader.Item("IronMaximum")) Then
                IronMaximum = 0
            Else
                IronMaximum = reader.Item("IronMaximum")
            End If
            If IsDBNull(reader.Item("LeadMinimum")) Then
                LeadMinimum = 0
            Else
                LeadMinimum = reader.Item("LeadMinimum")
            End If
            If IsDBNull(reader.Item("LeadMaximum")) Then
                LeadMaximum = 0
            Else
                LeadMaximum = reader.Item("LeadMaximum")
            End If
            If IsDBNull(reader.Item("NiobiumMinimum")) Then
                NiobiumMinimum = 0
            Else
                NiobiumMinimum = reader.Item("NiobiumMinimum")
            End If
            If IsDBNull(reader.Item("NiobiumMaximum")) Then
                NiobiumMaximum = 0
            Else
                NiobiumMaximum = reader.Item("NiobiumMaximum")
            End If
            If IsDBNull(reader.Item("TungstenMinimum")) Then
                TungstenMinimum = 0
            Else
                TungstenMinimum = reader.Item("TungstenMinimum")
            End If
            If IsDBNull(reader.Item("TungstenMaximum")) Then
                TungstenMaximum = 0
            Else
                TungstenMaximum = reader.Item("TungstenMaximum")
            End If
            If IsDBNull(reader.Item("MagnesiumMinimum")) Then
                MagnesiumMinimum = 0
            Else
                MagnesiumMinimum = reader.Item("MagnesiumMinimum")
            End If
            If IsDBNull(reader.Item("MagnesiumMaximum")) Then
                MagnesiumMaximum = 0
            Else
                MagnesiumMaximum = reader.Item("MagnesiumMaximum")
            End If
        Else
            CarbonMinimum = 0
            CarbonMaximum = 0
            ManganeseMinimum = 0
            ManganeseMaximum = 0
            PhosphorusMinimum = 0
            PhosphorusMaximum = 0
            SulfurMinimum = 0
            SulfurMaximum = 0
            SiliconMinimum = 0
            SiliconMaximum = 0
            CopperMinimum = 0
            CopperMaximum = 0
            NickelMinimum = 0
            NickelMaximum = 0
            ChromiumMinimum = 0
            ChromiumMaximum = 0
            MolybdenumMinimum = 0
            MolybdenumMaximum = 0
            TinMinimum = 0
            TinMaximum = 0
            AluminumMinimum = 0
            AluminumMaximum = 0
            NitrogenMinimum = 0
            NitrogenMaximum = 0
            VanadiumMinimum = 0
            VanadiumMaximum = 0
            BoronMinimum = 0
            BoronMaximum = 0
            TitaniumMinimum = 0
            TitaniumMaximum = 0
            CarbideMinimum = 0
            CarbideMaximum = 0
            CobaltMinimum = 0
            CobaltMaximum = 0
            ZincMinimum = 0
            ZincMaximum = 0
            IronMinimum = 0
            IronMaximum = 0
            LeadMinimum = 0
            LeadMaximum = 0
            NiobiumMinimum = 0
            NiobiumMaximum = 0
            TungstenMinimum = 0
            TungstenMaximum = 0
            MagnesiumMinimum = 0
            MagnesiumMaximum = 0
        End If
        reader.Close()
        con.Close()

        LowCarbon.Text = CarbonMinimum.ToString
        LowManganese.Text = ManganeseMinimum.ToString
        LowPhosporus.Text = PhosphorusMinimum.ToString
        LowSulfur.Text = SulfurMinimum.ToString
        LowSilicon.Text = SiliconMinimum.ToString
        LowNickel.Text = NickelMinimum.ToString
        LowChromium.Text = ChromiumMinimum.ToString
        LowMolybdenum.Text = MolybdenumMinimum.ToString
        LowCopper.Text = CopperMinimum.ToString
        LowTin.Text = TinMinimum.ToString
        LowVanadium.Text = VanadiumMinimum.ToString
        LowAluminum.Text = AluminumMinimum.ToString
        LowNitrogen.Text = NitrogenMinimum.ToString
        LowBoron.Text = BoronMinimum.ToString
        LowTitanium.Text = TitaniumMinimum.ToString
        LowNiobium.Text = NiobiumMinimum.ToString
        LowIron.Text = IronMinimum.ToString
        LowZinc.Text = ZincMinimum.ToString
        LowLead.Text = LeadMinimum.ToString
        LowCobalt.Text = CobaltMinimum.ToString
        LowTungsten.Text = TungstenMinimum.ToString
        LowMagnesium.Text = MagnesiumMinimum.ToString
        HighCarbon.Text = CarbonMaximum.ToString
        HighManganese.Text = ManganeseMaximum.ToString
        HighPhosporus.Text = PhosphorusMaximum.ToString
        HighSulfur.Text = SulfurMaximum.ToString
        HighSilicon.Text = SiliconMaximum.ToString
        HighNickel.Text = NickelMaximum.ToString
        HighChromium.Text = ChromiumMaximum.ToString
        HighMolybdenum.Text = MolybdenumMaximum.ToString
        HighCopper.Text = CopperMaximum.ToString
        HighTin.Text = TinMaximum.ToString
        HighVanadium.Text = VanadiumMaximum.ToString
        HighAluminum.Text = AluminumMaximum.ToString
        HighNitrogen.Text = NitrogenMaximum.ToString
        HighBoron.Text = BoronMaximum.ToString
        HighTitanium.Text = TitaniumMaximum.ToString
        HighNiobium.Text = NiobiumMaximum.ToString
        HighIron.Text = IronMaximum.ToString
        HighZinc.Text = ZincMaximum.ToString
        HighLead.Text = LeadMaximum.ToString
        HighCobalt.Text = CobaltMaximum.ToString
        HighTungsten.Text = TungstenMaximum.ToString
        HighMagnesium.Text = MagnesiumMaximum.ToString
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM HeatNumberLog", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "HeatNumberLog")
        con.Close()

        cboHeatNumber.DataSource = ds2.Tables("HeatNumberLog")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE VendorClass = 'SteelVendor';", con)
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "Vendor")
        con.Close()

        cboVendorID.DataSource = ds3.Tables("Vendor")
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadMillCertData()
        Dim CoilsInHeat, PoundsInHeat As Integer
        Dim HeatNumber, SteelSize, VendorID, DateReceived, SteelPONumber, Comments As String
        Dim Yield, ReductionOfArea, Elongation, UltimateYield, CEVValue As Double
        Dim Carbon, Manganese, Phosphorus, Sulfur, Silicon, Nickel, Chromium, Molybdenum, Copper, Tin, Vanadium, Aluminum, Nitrogen, Boron, Titanium, Niobium, Cobalt, Zinc, Iron, Lead, Tungsten, Magnesium As Double

        Dim SteelCarbon As String = ""
        cmd = New SqlCommand("SELECT * FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber", con)
        cmd.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = Val(cboHeatFileNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = 0
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If Not IsDBNull(reader.Item("SteelType")) Then
                SteelCarbon = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = cboVendorID.Text
            Else
                VendorID = reader.Item("VendorID")
            End If
            If IsDBNull(reader.Item("DateReceived")) Then
                DateReceived = dtpMillReceivingDate.Text
            Else
                DateReceived = reader.Item("DateReceived")
            End If
            If IsDBNull(reader.Item("SteelPONumber")) Then
                SteelPONumber = txtSteelPONumber.Text
            Else
                SteelPONumber = reader.Item("SteelPONumber")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                Comments = txtComment.Text
            Else
                Comments = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("Yield")) Then
                Yield = 0.0
            Else
                Yield = reader.Item("Yield")
            End If
            If IsDBNull(reader.Item("ReductionOfArea")) Then
                ReductionOfArea = 0.0
            Else
                ReductionOfArea = reader.Item("ReductionOfArea")
            End If
            If IsDBNull(reader.Item("Elongation")) Then
                Elongation = 0.0
            Else
                Elongation = reader.Item("Elongation")
            End If
            If IsDBNull(reader.Item("CoilsInHeat")) Then
                CoilsInHeat = 0
            Else
                CoilsInHeat = reader.Item("CoilsInHeat")
            End If
            If IsDBNull(reader.Item("PoundsInHeat")) Then
                PoundsInHeat = 0.0
            Else
                PoundsInHeat = reader.Item("PoundsInHeat")
            End If
            If IsDBNull(reader.Item("UltimateYield")) Then
                UltimateYield = 0.0
            Else
                UltimateYield = reader.Item("UltimateYield")
            End If
            If IsDBNull(reader.Item("Status")) Then
                txtStatus.Text = "OPEN"
            Else
                txtStatus.Text = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("MaterialOrigin")) Then
                cboMaterialOrigin.Text = ""
            Else
                cboMaterialOrigin.Text = reader.Item("MaterialOrigin")
            End If
            If IsDBNull(reader.Item("BOLNumber")) Then
                txtBOLNumber.Text = ""
            Else
                txtBOLNumber.Text = reader.Item("BOLNumber")
            End If
            If IsDBNull(reader.Item("CEVValue")) Then
                CEVValue = 0
            Else
                CEVValue = reader.Item("CEVValue")
            End If
            If IsDBNull(reader.Item("Carbon")) Then
                Carbon = 0.0
            Else
                Carbon = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("Manganese")) Then
                Manganese = 0.0
            Else
                Manganese = reader.Item("Manganese")
            End If
            If IsDBNull(reader.Item("Phosphorus")) Then
                Phosphorus = 0.0
            Else
                Phosphorus = reader.Item("Phosphorus")
            End If
            If IsDBNull(reader.Item("Sulfur")) Then
                Sulfur = 0.0
            Else
                Sulfur = reader.Item("Sulfur")
            End If
            If IsDBNull(reader.Item("Silicon")) Then
                Silicon = 0.0
            Else
                Silicon = reader.Item("Silicon")
            End If
            If IsDBNull(reader.Item("Nickel")) Then
                Nickel = 0.0
            Else
                Nickel = reader.Item("Nickel")
            End If
            If IsDBNull(reader.Item("Chromium")) Then
                Chromium = 0.0
            Else
                Chromium = reader.Item("Chromium")
            End If
            If IsDBNull(reader.Item("Molybdenum")) Then
                Molybdenum = 0.0
            Else
                Molybdenum = reader.Item("Molybdenum")
            End If
            If IsDBNull(reader.Item("Copper")) Then
                Copper = 0.0
            Else
                Copper = reader.Item("Copper")
            End If
            If IsDBNull(reader.Item("Tin")) Then
                Tin = 0.0
            Else
                Tin = reader.Item("Tin")
            End If
            If IsDBNull(reader.Item("Vanadium")) Then
                Vanadium = 0.0
            Else
                Vanadium = reader.Item("Vanadium")
            End If
            If IsDBNull(reader.Item("Aluminum")) Then
                Aluminum = 0.0
            Else
                Aluminum = reader.Item("Aluminum")
            End If
            If IsDBNull(reader.Item("Nitrogen")) Then
                Nitrogen = 0.0
            Else
                Nitrogen = reader.Item("Nitrogen")
            End If
            If IsDBNull(reader.Item("Boron")) Then
                Boron = 0.0
            Else
                Boron = reader.Item("Boron")
            End If
            If IsDBNull(reader.Item("Titanium")) Then
                Titanium = 0.0
            Else
                Titanium = reader.Item("Titanium")
            End If
            If IsDBNull(reader.Item("Niobium")) Then
                Niobium = 0.0
            Else
                Niobium = reader.Item("Niobium")
            End If
            If IsDBNull(reader.Item("Cobalt")) Then
                Cobalt = 0.0
            Else
                Cobalt = reader.Item("Cobalt")
            End If
            If IsDBNull(reader.Item("Zinc")) Then
                Zinc = 0.0
            Else
                Zinc = reader.Item("Zinc")
            End If
            If IsDBNull(reader.Item("Iron")) Then
                Iron = 0.0
            Else
                Iron = reader.Item("Iron")
            End If
            If IsDBNull(reader.Item("Lead")) Then
                Lead = 0.0
            Else
                Lead = reader.Item("Lead")
            End If
            If IsDBNull(reader.Item("Tungsten")) Then
                Tungsten = 0.0
            Else
                Tungsten = reader.Item("Tungsten")
            End If
            If IsDBNull(reader.Item("Magnesium")) Then
                Magnesium = 0.0
            Else
                Magnesium = reader.Item("Magnesium")
            End If
        Else
            HeatNumber = 0
            SteelCarbon = ""
            SteelSize = ""
            VendorID = cboVendorID.Text
            DateReceived = dtpMillReceivingDate.Text
            SteelPONumber = txtSteelPONumber.Text
            Comments = txtComment.Text
            ReductionOfArea = 0.0
            Yield = 0.0
            ReductionOfArea = 0.0
            Elongation = 0.0
            CoilsInHeat = 0
            PoundsInHeat = 0.0
            UltimateYield = 0.0
            txtStatus.Text = "OPEN"
            cboMaterialOrigin.Text = ""
            CEVValue = 0
            Carbon = 0.0
            Manganese = 0.0
            Phosphorus = 0.0
            Sulfur = 0.0
            Silicon = 0.0
            Nickel = 0.0
            Chromium = 0.0
            Molybdenum = 0.0
            Copper = 0.0
            Tin = 0.0
            Vanadium = 0.0
            Aluminum = 0.0
            Nitrogen = 0.0
            Boron = 0.0
            Titanium = 0.0
            Niobium = 0.0
            Cobalt = 0.0
            Zinc = 0.0
            Iron = 0.0
            Lead = 0.0
            Tungsten = 0.0
            Magnesium = 0.0
        End If
        reader.Close()
        con.Close()

        cboHeatNumber.Text = HeatNumber
        cboSteelCarbon.Text = SteelCarbon
        cboSteelSize.Text = SteelSize
        cboVendorID.Text = VendorID
        dtpMillReceivingDate.Text = DateReceived
        txtSteelPONumber.Text = SteelPONumber
        txtComment.Text = Comments
        txtYield.Text = Yield
        txtReductionOfArea.Text = ReductionOfArea
        txtElongation.Text = Elongation
        txtCoilsInHeat.Text = CoilsInHeat
        txtPoundsInHeat.Text = PoundsInHeat
        txtUltimateTensile.Text = UltimateYield
        txtCEV.Text = CEVValue
        txtCarbon.Text = Carbon
        txtManganese.Text = Manganese
        txtPhosphorus.Text = Phosphorus
        txtSulfur.Text = Sulfur
        txtSilicon.Text = Silicon
        txtNickel.Text = Nickel
        txtChromium.Text = Chromium
        txtMolybdenum.Text = Molybdenum
        txtCopper.Text = Copper
        txtTin.Text = Tin
        txtVanadium.Text = Vanadium
        txtAluminum.Text = Aluminum
        txtNitrogen.Text = Nitrogen
        txtBoron.Text = Boron
        txtTitanium.Text = Titanium
        txtNiobium.Text = Niobium
        txtCobalt.Text = Cobalt
        txtZinc.Text = Zinc
        txtIron.Text = Iron
        txtLead.Text = Lead
        txtTungsten.Text = Tungsten
        txtMagnesium.Text = Magnesium

        checkChemicalComposition()
        LoadTolerances()
        CheckTolerances()
        checkStatus()
    End Sub

    Private Sub loadChemicalComposition()
        Dim Carbon, Manganese, Phosphorus, Sulfur, Silicon, Nickel, Chromium, Molybdenum, Copper, Tin, Vanadium, Aluminum, Nitrogen, Boron, Titanium, Niobium, Cobalt, Zinc, Iron, Lead, Tungsten, Magnesium As Double

        Dim HeatNumberCommand As New SqlCommand("SELECT * FROM HeatNumberLog WHERE HeatNumber = @HeatNumber", con1)
        HeatNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text

        If con1.State = ConnectionState.Closed Then con1.Open()
        Dim reader As SqlDataReader = HeatNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Carbon")) Then
                Carbon = 0.0
            Else
                Carbon = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("Manganese")) Then
                Manganese = 0.0
            Else
                Manganese = reader.Item("Manganese")
            End If
            If IsDBNull(reader.Item("Phosphorus")) Then
                Phosphorus = 0.0
            Else
                Phosphorus = reader.Item("Phosphorus")
            End If
            If IsDBNull(reader.Item("Sulfur")) Then
                Sulfur = 0.0
            Else
                Sulfur = reader.Item("Sulfur")
            End If
            If IsDBNull(reader.Item("Silicon")) Then
                Silicon = 0.0
            Else
                Silicon = reader.Item("Silicon")
            End If
            If IsDBNull(reader.Item("Nickel")) Then
                Nickel = 0.0
            Else
                Nickel = reader.Item("Nickel")
            End If
            If IsDBNull(reader.Item("Chromium")) Then
                Chromium = 0.0
            Else
                Chromium = reader.Item("Chromium")
            End If
            If IsDBNull(reader.Item("Molybdenum")) Then
                Molybdenum = 0.0
            Else
                Molybdenum = reader.Item("Molybdenum")
            End If
            If IsDBNull(reader.Item("Copper")) Then
                Copper = 0.0
            Else
                Copper = reader.Item("Copper")
            End If
            If IsDBNull(reader.Item("Tin")) Then
                Tin = 0.0
            Else
                Tin = reader.Item("Tin")
            End If
            If IsDBNull(reader.Item("Vanadium")) Then
                Vanadium = 0.0
            Else
                Vanadium = reader.Item("Vanadium")
            End If
            If IsDBNull(reader.Item("Aluminum")) Then
                Aluminum = 0.0
            Else
                Aluminum = reader.Item("Aluminum")
            End If
            If IsDBNull(reader.Item("Nitrogen")) Then
                Nitrogen = 0.0
            Else
                Nitrogen = reader.Item("Nitrogen")
            End If
            If IsDBNull(reader.Item("Boron")) Then
                Boron = 0.0
            Else
                Boron = reader.Item("Boron")
            End If
            If IsDBNull(reader.Item("Titanium")) Then
                Titanium = 0.0
            Else
                Titanium = reader.Item("Titanium")
            End If
            If IsDBNull(reader.Item("Niobium")) Then
                Niobium = 0.0
            Else
                Niobium = reader.Item("Niobium")
            End If
            If IsDBNull(reader.Item("Cobalt")) Then
                Cobalt = 0.0
            Else
                Cobalt = reader.Item("Cobalt")
            End If
            If IsDBNull(reader.Item("Zinc")) Then
                Zinc = 0.0
            Else
                Zinc = reader.Item("Zinc")
            End If
            If IsDBNull(reader.Item("Iron")) Then
                Iron = 0.0
            Else
                Iron = reader.Item("Iron")
            End If
            If IsDBNull(reader.Item("Lead")) Then
                Lead = 0.0
            Else
                Lead = reader.Item("Lead")
            End If
            If IsDBNull(reader.Item("Tungsten")) Then
                Tungsten = 0.0
            Else
                Tungsten = reader.Item("Tungsten")
            End If
            If IsDBNull(reader.Item("Magnesium")) Then
                Magnesium = 0.0
            Else
                Magnesium = reader.Item("Magnesium")
            End If
        Else
            Carbon = 0.0
            Manganese = 0.0
            Phosphorus = 0.0
            Sulfur = 0.0
            Silicon = 0.0
            Nickel = 0.0
            Chromium = 0.0
            Molybdenum = 0.0
            Copper = 0.0
            Tin = 0.0
            Vanadium = 0.0
            Aluminum = 0.0
            Nitrogen = 0.0
            Boron = 0.0
            Titanium = 0.0
            Niobium = 0.0
            Cobalt = 0.0
            Zinc = 0.0
            Iron = 0.0
            Lead = 0.0
            Tungsten = 0.0
            Magnesium = 0.0
        End If
        reader.Close()
        con1.Close()

        txtCarbon.Text = Carbon
        txtManganese.Text = Manganese
        txtPhosphorus.Text = Phosphorus
        txtSulfur.Text = Sulfur
        txtSilicon.Text = Silicon
        txtNickel.Text = Nickel
        txtChromium.Text = Chromium
        txtMolybdenum.Text = Molybdenum
        txtCopper.Text = Copper
        txtTin.Text = Tin
        txtVanadium.Text = Vanadium
        txtAluminum.Text = Aluminum
        txtNitrogen.Text = Nitrogen
        txtBoron.Text = Boron
        txtTitanium.Text = Titanium
        txtNiobium.Text = Niobium
        txtCobalt.Text = Cobalt
        txtZinc.Text = Zinc
        txtIron.Text = Iron
        txtLead.Text = Lead
        txtTungsten.Text = Tungsten
        txtMagnesium.Text = Magnesium

        updateCEV()
    End Sub

    Private Sub LoadSizeData()
        cmd = New SqlCommand("SELECT Yield, ReductionOfArea, Elongation, UltimateYield FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND SteelType = @Carbon AND SteelSize = @SteelSize AND VendorID = @VendorID ORDER BY HeatFileNumber DESC;", con)
        cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()

            If Not IsDBNull(reader.Item("Yield")) Then
                txtYield.Text = reader.Item("Yield")
            End If
            If Not IsDBNull(reader.Item("ReductionOfArea")) Then
                txtReductionOfArea.Text = reader.Item("ReductionOfArea")
            End If
            If Not IsDBNull(reader.Item("Elongation")) Then
                txtElongation.Text = reader.Item("Elongation")
            End If
            If Not IsDBNull(reader.Item("UltimateYield")) Then
                txtUltimateTensile.Text = reader.Item("UltimateYield")
            End If
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Function LoadUploadedFileCount() As Integer
        If Not String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            Dim fileCount As Integer = System.IO.Directory.GetFiles(InspectionDir, cboHeatFileNumber.Text + "*.pdf").Length
            If fileCount > 0 Then
                lblFileCountMessage.ForeColor = Color.Green
                lblFileCountMessage.Text = fileCount.ToString + " files have been uploded."
            Else
                lblFileCountMessage.ForeColor = Color.Red
                lblFileCountMessage.Text = "No files have been uploaded"
            End If
            Return fileCount
        End If
        Return 0
    End Function

    'Command Buttons

    Private Sub cmdPullTestData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPullTestData.Click
        Me.Hide()
        Using NewPullTestData As New PullTestData()
            Dim result = NewPullTestData.ShowDialog()
        End Using
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If canComplete() Then
            Try
                updateHeatNumberLog("CLOSED")
            Catch ex As System.Exception
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                sendErrorToDataBase("MillCertForm - cmdEnter_Click --Error trying to insert/update the heat file in HeatNumberLog", "File #" + cboHeatFileNumber.Text, ex.ToString())
                MessageBox.Show("There was an error completing the mill certification entry", "Unable to complete mill certification entry", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            MessageBox.Show("Mill certification entry has been completed sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadHeatFileNumber()
            LoadHeatNumber()

            ClearData()
            checkStatus()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        If canExit() Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Mill Certification Data?", "SAVE MILL CERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                cmdSave_Click(sender, e)
            End If
        End If

        'isLoaded = False
        ClearData()
        GlobalHeatFileNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewLotNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewLotNumbers.Click
        GlobalDivisionCode = EmployeeCompanyCode
        Me.Hide()
        Using NewViewLotNumbers As New ViewLotNumbers()
            Dim result = NewViewLotNumbers.ShowDialog()
        End Using
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearDataToolStripMenuItem.Click
        ClearData()
        checkStatus()
        CheckTolerances()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveDataToolStripMenuItem.Click
        If canSave() Then
            Try
                updateCEV()
                updateHeatNumberLog("OPEN")
                'Verify data has been written
                MsgBox("Heat record has been saved sucessfully", MsgBoxStyle.OkOnly)
            Catch ex As System.Exception
                sendErrorToDataBase("MillCertForm - cmdSave_Click --Error trying to insert/update in HeatNumberLog", "File #" + cboHeatFileNumber.Text, ex.ToString())
            End Try
        End If
    End Sub

    Private Sub cmdFOXForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFOXForm.Click
        GlobalDivisionCode = EmployeeCompanyCode
        Me.Hide()
        Using NewFOXMenu As New FOXMenu()
            Dim result = NewFOXMenu.ShowDialog()
        End Using
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintDataToolStripMenuItem.Click
        If canPrint() Then
            If txtStatus.Text <> "CLOSED" Then
                Try
                    updateHeatNumberLog("OPEN")
                Catch ex As System.Exception
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    sendErrorToDataBase("MillCertForm - cmdPrint_Click --Error tring to insert/update heat file in HeatNumberLog", "File #" + cboHeatFileNumber.Text, ex.ToString())
                End Try
            End If
            Me.Hide()
            Dim NewPrintHeatFileRecord As New PrintHeatFileRecord(cboHeatFileNumber.Text)
            NewPrintHeatFileRecord.ShowDialog()
            Me.Show()
            Me.BringToFront()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteDataToolStripMenuItem.Click
        If canDelete() Then
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete heat file record?", "Delete heat file record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Create command to delete data from text boxes
                    cmd = New SqlCommand("DELETE FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber;", con)
                    cmd.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = cboHeatFileNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    sendErrorToDataBase("MillCertForm - cmdDelete_Click --Error trying to delete heat file number form HeatNumberLog", "file #" + cboHeatFileNumber.Text, ex.ToString())
                    MessageBox.Show("There was a problem deleting the record. Contact system admin", "Unable to delete file number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try

                'isLoaded = False
                LoadHeatFileNumber()
                ClearData()
                'isLoaded = True
                ''checkStatus()
            End If
        End If
    End Sub

    Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
        If Not String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            Dim fileDialog As New OpenFileDialog
            ''makes the file dialog box open to the directory currently used
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)") Then
                fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples (PaperPort 12)"
            ElseIf System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples") Then
                fileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "My PaperPort Documents\Samples"
            End If
            ''will restore to the initial directory
            fileDialog.RestoreDirectory = True
            fileDialog.Multiselect = False
            fileDialog.DefaultExt = ".pdf"
            fileDialog.Filter = "PDF documents (.pdf)|*.pdf"
            If System.IO.File.Exists(InspectionDir + "\" + cboHeatFileNumber.Text + " " + cboHeatNumber.Text + " " + dtpMillReceivingDate.Value.ToString("MM-dd-yyyy") + ".pdf") Then
                Dim resp As DialogResult = MessageBox.Show("Inspection file has already been uploaded, do you wish to overwrite the current inspection file?", "Overwrite file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If resp = System.Windows.Forms.DialogResult.Yes Then
                    If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        My.Computer.FileSystem.DeleteFile(InspectionDir + "\" + cboHeatFileNumber.Text + " " + cboHeatNumber.Text + " " + dtpMillReceivingDate.Value.ToString("MM-dd-yyyy") + ".pdf")
                        Try
                            My.Computer.FileSystem.CopyFile(fileDialog.FileName, InspectionDir + "\" + cboHeatFileNumber.Text + " " + cboHeatNumber.Text + " " + dtpMillReceivingDate.Value.ToString("MM-dd-yyyy") + ".pdf")
                            LoadUploadedFileCount()
                            MessageBox.Show("File has been uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As System.Exception
                            sendErrorToDataBase("MillCertForm - cmdSelectFile --Error trying to upload receiving inspection file.", "Heat File # " + cboHeatFileNumber.Text, ex.ToString())
                        End Try
                    End If
                ElseIf resp = System.Windows.Forms.DialogResult.No Then
                    If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Dim adder As Integer = 0
                        While System.IO.File.Exists(InspectionDir + "\" + cboHeatFileNumber.Text + " " + cboHeatNumber.Text + " " + dtpMillReceivingDate.Value.ToString("MM-dd-yyyy") + " " + adder.ToString + ".pdf")
                            adder += 1
                        End While
                        Try
                            My.Computer.FileSystem.CopyFile(fileDialog.FileName, InspectionDir + "\" + cboHeatFileNumber.Text + " " + cboHeatNumber.Text + " " + dtpMillReceivingDate.Value.ToString("MM-dd-yyyy") + " " + adder.ToString + ".pdf")
                            LoadUploadedFileCount()
                            MessageBox.Show("File has been uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As System.Exception
                            sendErrorToDataBase("MillCertForm - cmdSelectFile --Error trying to upload receiving inspection file.", "Heat File # " + cboHeatFileNumber.Text, ex.ToString())
                        End Try
                    End If
                End If
            Else
                If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    Try
                        My.Computer.FileSystem.CopyFile(fileDialog.FileName, InspectionDir + "\" + cboHeatFileNumber.Text + " " + cboHeatNumber.Text + " " + dtpMillReceivingDate.Value.ToString("MM-dd-yyyy") + ".pdf")
                        LoadUploadedFileCount()
                        MessageBox.Show("File has been uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As System.Exception
                        sendErrorToDataBase("MillCertForm - cmdSelectFile --Error trying to upload receiving inspection file.", "Heat File # " + cboHeatFileNumber.Text, ex.ToString())
                    End Try
                End If
            End If
        Else
            MessageBox.Show("You must enter a heat file number", "Enter heat file number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmdSelectFile.Enabled = False
        End If
    End Sub

    Private Sub cmdGenerateHeatFileNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateHeatFileNumber.Click
        Try
            insertIntoHeatNumberLog("OPEN")
            txtStatus.Text = "OPEN"
        Catch ex As System.Exception
            sendErrorToDataBase("MillCertForm - cmdGenerateHeatFileNumber_Click --Error inserting new file number", "Heat Number #" + cboHeatNumber.Text, ex.ToString())
            MessageBox.Show("Unable to generate new file number. Contact system admin", "Unable to generate new file number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub

    'Text Box Lost Focus Routines

    Private Sub txtCarbon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarbon.Leave
        If Val(LowCarbon.Text) > 0 Or Val(HighCarbon.Text) > 0 Then
            If Val(LowCarbon.Text) <= Val(txtCarbon.Text) AndAlso Val(txtCarbon.Text) <= Val(HighCarbon.Text) Then
                lblCarbon.BackColor = Me.BackColor
            Else
                lblCarbon.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowCarbon.Text) = 0 AndAlso Val(HighCarbon.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblCarbon.BackColor = Me.BackColor
                Else
                    If Val(txtCarbon.Text) >= 1 Then
                        lblCarbon.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblCarbon.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblCarbon.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtZinc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZinc.Leave
        If Val(LowZinc.Text) > 0 Or Val(HighZinc.Text) > 0 Then
            If Val(LowZinc.Text) <= Val(txtZinc.Text) AndAlso Val(txtZinc.Text) <= Val(HighZinc.Text) Then
                lblZinc.BackColor = Me.BackColor
            Else
                lblZinc.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowZinc.Text) = 0 AndAlso Val(HighZinc.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblZinc.BackColor = Me.BackColor
                Else
                    If Val(txtZinc.Text) >= 1 Then
                        lblZinc.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblZinc.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblZinc.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtManganese_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManganese.Leave
        If Val(LowManganese.Text) > 0 Or Val(HighManganese.Text) > 0 Then
            If Val(txtManganese.Text) >= Val(LowManganese.Text) AndAlso Val(txtManganese.Text) <= Val(HighManganese.Text) Then
                lblManganese.BackColor = Me.BackColor
            Else
                lblManganese.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowManganese.Text) = 0 AndAlso Val(HighManganese.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblManganese.BackColor = Me.BackColor
                Else
                    If Val(txtManganese.Text) >= 1 Then
                        lblManganese.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblManganese.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblManganese.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtPhosphorus_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhosphorus.Leave
        If Val(LowPhosporus.Text) > 0 Or Val(HighPhosporus.Text) > 0 Then
            If Val(LowPhosporus.Text) <= Val(txtPhosphorus.Text) AndAlso Val(txtPhosphorus.Text) <= Val(HighPhosporus.Text) Then
                lblPhosporus.BackColor = Me.BackColor
            Else
                lblPhosporus.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowPhosporus.Text) = 0 AndAlso Val(HighPhosporus.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblPhosporus.BackColor = Me.BackColor
                Else
                    If Val(txtPhosphorus.Text) >= 1 Then
                        lblPhosporus.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblPhosporus.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblPhosporus.BackColor = Me.BackColor
            End If
            End If
    End Sub

    Private Sub txtSulfur_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSulfur.Leave
        If Val(LowSulfur.Text) > 0 Or Val(HighSulfur.Text) > 0 Then
            If Val(LowSulfur.Text) <= Val(txtSulfur.Text) AndAlso Val(txtSulfur.Text) <= Val(HighSulfur.Text) Then
                lblSulfur.BackColor = Me.BackColor
            Else
                lblSulfur.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowSulfur.Text) = 0 AndAlso Val(HighSulfur.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblSulfur.BackColor = Me.BackColor
                Else
                    If Val(txtSulfur.Text) >= 1 Then
                        lblSulfur.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblSulfur.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblSulfur.BackColor = Me.BackColor
            End If
            End If
    End Sub

    Private Sub txtSilicon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSilicon.Leave
        If Val(LowSilicon.Text) > 0 Or Val(HighSilicon.Text) > 0 Then
            If Val(LowSilicon.Text) <= Val(txtSilicon.Text) AndAlso Val(txtSilicon.Text) <= Val(HighSilicon.Text) Then
                lblSilicon.BackColor = Me.BackColor
            Else
                lblSilicon.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowSilicon.Text) = 0 AndAlso Val(HighSilicon.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblSilicon.BackColor = Me.BackColor
                Else
                    If Val(txtSilicon.Text) >= 1 Then
                        lblSilicon.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblSilicon.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblSilicon.BackColor = Me.BackColor
            End If
            End If
    End Sub

    Private Sub txtNickel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNickel.Leave
        If Val(LowNickel.Text) > 0 Or Val(HighNickel.Text) > 0 Then
            If Val(LowNickel.Text) <= Val(txtNickel.Text) AndAlso Val(txtNickel.Text) <= Val(HighNickel.Text) Then
                lblNickel.BackColor = Me.BackColor
            Else
                lblNickel.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowNickel.Text) = 0 AndAlso Val(HighNickel.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblNickel.BackColor = Me.BackColor
                Else
                    If Val(txtNickel.Text) >= 1 Then
                        lblNickel.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblNickel.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblNickel.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtChromium_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChromium.Leave
        If Val(LowChromium.Text) > 0 Or Val(HighChromium.Text) > 0 Then
            If Val(LowChromium.Text) <= Val(txtChromium.Text) AndAlso Val(txtChromium.Text) <= Val(HighChromium.Text) Then
                lblChromium.BackColor = Me.BackColor
            Else
                lblChromium.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowChromium.Text) = 0 AndAlso Val(HighChromium.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblChromium.BackColor = Me.BackColor
                Else
                    If Val(txtChromium.Text) >= 1 Then
                        lblChromium.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblChromium.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblChromium.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtMolybdenum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMolybdenum.Leave
        If Val(LowMolybdenum.Text) > 0 Or Val(HighMolybdenum.Text) > 0 Then
            If Val(LowMolybdenum.Text) <= Val(txtMolybdenum.Text) AndAlso Val(txtMolybdenum.Text) <= Val(HighMolybdenum.Text) Then
                lblMolybdenum.BackColor = Me.BackColor
            Else
                lblMolybdenum.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowMolybdenum.Text) = 0 AndAlso Val(HighMolybdenum.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblMolybdenum.BackColor = Me.BackColor
                Else
                    If Val(txtMolybdenum.Text) >= 1 Then
                        lblMolybdenum.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblMolybdenum.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblMolybdenum.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtCopper_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCopper.Leave
        If Val(LowCopper.Text) > 0 Or Val(HighCopper.Text) > 0 Then
            If Val(LowCopper.Text) <= Val(txtCopper.Text) AndAlso Val(txtCopper.Text) <= Val(HighCopper.Text) Then
                lblCopper.BackColor = Me.BackColor
            Else
                lblCopper.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowCopper.Text) = 0 AndAlso Val(HighCopper.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblCopper.BackColor = Me.BackColor
                Else
                    If Val(txtCopper.Text) >= 1 Then
                        lblCopper.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblCopper.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblCopper.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtTin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTin.Leave
        If Val(LowTin.Text) > 0 Or Val(HighTin.Text) > 0 Then
            If Val(LowTin.Text) <= Val(txtTin.Text) AndAlso Val(txtTin.Text) <= Val(HighTin.Text) Then
                lblTin.BackColor = Me.BackColor
            Else
                lblTin.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowTin.Text) = 0 AndAlso Val(HighTin.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblTin.BackColor = Me.BackColor
                Else
                    If Val(txtTin.Text) >= 1 Then
                        lblTin.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblTin.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblTin.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtVanadium_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVanadium.Leave
        If Val(LowVanadium.Text) > 0 Or Val(HighVanadium.Text) > 0 Then
            If Val(LowVanadium.Text) <= Val(txtVanadium.Text) AndAlso Val(txtVanadium.Text) <= Val(HighVanadium.Text) Then
                lblVanadium.BackColor = Me.BackColor
            Else
                lblVanadium.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowVanadium.Text) = 0 AndAlso Val(HighVanadium.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblVanadium.BackColor = Me.BackColor
                Else
                    If Val(txtVanadium.Text) >= 1 Then
                        lblVanadium.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblVanadium.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblVanadium.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtAluminum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAluminum.Leave
        If Val(LowAluminum.Text) > 0 Or Val(HighAluminum.Text) > 0 Then
            If Val(LowAluminum.Text) <= Val(txtAluminum.Text) AndAlso Val(txtAluminum.Text) <= Val(HighAluminum.Text) Then
                lblAluminum.BackColor = Me.BackColor
            Else
                lblAluminum.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowAluminum.Text) = 0 AndAlso Val(HighAluminum.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblAluminum.BackColor = Me.BackColor
                Else
                    If Val(txtAluminum.Text) >= 1 Then
                        lblAluminum.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblAluminum.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblAluminum.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtNitrogen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNitrogen.Leave
        If Val(LowNitrogen.Text) > 0 Or Val(HighNitrogen.Text) > 0 Then
            If Val(LowNitrogen.Text) <= Val(txtNitrogen.Text) AndAlso Val(txtNitrogen.Text) <= Val(HighNitrogen.Text) Then
                lblNitrogen.BackColor = Me.BackColor
            Else
                lblNitrogen.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowNitrogen.Text) = 0 AndAlso Val(HighNitrogen.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblNitrogen.BackColor = Me.BackColor
                Else
                    If Val(txtNitrogen.Text) >= 1 Then
                        lblNitrogen.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblNitrogen.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblNitrogen.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtBoron_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoron.Leave
        If Val(LowBoron.Text) > 0 Or Val(HighBoron.Text) > 0 Then
            If Val(LowBoron.Text) <= Val(txtBoron.Text) AndAlso Val(txtBoron.Text) <= Val(HighBoron.Text) Then
                lblBoron.BackColor = Me.BackColor
            Else
                lblBoron.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowBoron.Text) = 0 AndAlso Val(HighBoron.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblBoron.BackColor = Me.BackColor
                Else
                    If Val(txtBoron.Text) >= 1 Then
                        lblBoron.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblBoron.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblBoron.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtTitanium_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTitanium.Leave
        If Val(LowTitanium.Text) > 0 Or Val(HighTitanium.Text) > 0 Then
            If Val(LowTitanium.Text) <= Val(txtTitanium.Text) AndAlso Val(txtTitanium.Text) <= Val(HighTitanium.Text) Then
                lblTitanium.BackColor = Me.BackColor
            Else
                lblTitanium.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowTitanium.Text) = 0 AndAlso Val(HighTitanium.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblTitanium.BackColor = Me.BackColor
                Else
                    If Val(txtTitanium.Text) >= 1 Then
                        lblTitanium.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblTitanium.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblTitanium.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtNiobium_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNiobium.Leave
        If Val(LowNiobium.Text) > 0 Or Val(HighNiobium.Text) > 0 Then
            If Val(LowNiobium.Text) <= Val(txtNiobium.Text) AndAlso Val(txtNiobium.Text) <= Val(HighNiobium.Text) Then
                lblNiobium.BackColor = Me.BackColor
            Else
                lblNiobium.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowNiobium.Text) = 0 AndAlso Val(HighNiobium.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblNiobium.BackColor = Me.BackColor
                Else
                    If Val(txtNiobium.Text) >= 1 Then
                        lblNiobium.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblNiobium.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblNiobium.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtIron_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIron.Leave
        If Val(LowIron.Text) > 0 Or Val(HighIron.Text) > 0 Then
            If Val(LowIron.Text) <= Val(txtIron.Text) AndAlso Val(txtIron.Text) <= Val(HighIron.Text) Then
                lblIron.BackColor = Me.BackColor
            Else
                lblIron.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowIron.Text) = 0 AndAlso Val(HighIron.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblIron.BackColor = Me.BackColor
                Else
                    If Val(txtIron.Text) >= 1 Then
                        lblIron.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblIron.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblIron.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtLead_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLead.Leave
        If Val(LowLead.Text) > 0 Or Val(HighLead.Text) > 0 Then
            If Val(LowLead.Text) <= Val(txtLead.Text) AndAlso Val(txtLead.Text) <= Val(HighLead.Text) Then
                lblLead.BackColor = Me.BackColor
            Else
                lblLead.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowLead.Text) = 0 AndAlso Val(HighLead.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblLead.BackColor = Me.BackColor
                Else
                    If Val(txtLead.Text) >= 1 Then
                        lblLead.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblLead.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblLead.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtCobalt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCobalt.Leave
        If Val(LowCobalt.Text) > 0 Or Val(HighCobalt.Text) > 0 Then
            If Val(LowCobalt.Text) <= Val(txtCobalt.Text) AndAlso Val(txtCobalt.Text) <= Val(HighCobalt.Text) Then
                lblCobalt.BackColor = Me.BackColor
            Else
                lblCobalt.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowCobalt.Text) = 0 AndAlso Val(HighCobalt.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblCobalt.BackColor = Me.BackColor
                Else
                    If Val(txtCobalt.Text) >= 1 Then
                        lblCobalt.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblCobalt.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblCobalt.BackColor = Me.BackColor
            End If
        End If
    End Sub

    Private Sub txtMagnesium_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMagnesium.LostFocus
        If Val(LowMagnesium.Text) > 0 Or Val(HighMagnesium.Text) > 0 Then
            If Val(LowMagnesium.Text) <= Val(txtMagnesium.Text) AndAlso Val(txtMagnesium.Text) <= Val(HighMagnesium.Text) Then
                lblMagnesium.BackColor = Me.BackColor
            Else
                lblMagnesium.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowMagnesium.Text) = 0 AndAlso Val(HighMagnesium.Text) = 0 Then
                If cboSteelCarbon.Text.StartsWith("SS") Then
                    lblMagnesium.BackColor = Me.BackColor
                Else
                    If Val(txtMagnesium.Text) >= 1 Then
                        lblMagnesium.BackColor = Color.LightCoral
                        NoStopSkip = False
                    Else
                        lblMagnesium.BackColor = Me.BackColor
                    End If
                End If
            Else
                lblMagnesium.BackColor = Me.BackColor
            End If
        End If
    End Sub

    'Validation and Error checking

    Public Sub ClearData()
        LowCarbon.Text = ""
        LowManganese.Text = ""
        LowPhosporus.Text = ""
        LowSulfur.Text = ""
        LowSilicon.Text = ""
        LowNickel.Text = ""
        LowChromium.Text = ""
        LowMolybdenum.Text = ""
        LowCopper.Text = ""
        LowTin.Text = ""
        LowVanadium.Text = ""
        LowAluminum.Text = ""
        LowNitrogen.Text = ""
        LowBoron.Text = ""
        LowTitanium.Text = ""
        LowNiobium.Text = ""
        LowIron.Text = ""
        LowZinc.Text = ""
        LowLead.Text = ""
        LowCobalt.Text = ""
        LowTungsten.Text = ""
        LowMagnesium.Text = ""

        HighCarbon.Text = ""
        HighManganese.Text = ""
        HighPhosporus.Text = ""
        HighSulfur.Text = ""
        HighSilicon.Text = ""
        HighNickel.Text = ""
        HighChromium.Text = ""
        HighMolybdenum.Text = ""
        HighCopper.Text = ""
        HighTin.Text = ""
        HighVanadium.Text = ""
        HighAluminum.Text = ""
        HighNitrogen.Text = ""
        HighBoron.Text = ""
        HighTitanium.Text = ""
        HighNiobium.Text = ""
        HighIron.Text = ""
        HighZinc.Text = ""
        HighLead.Text = ""
        HighCobalt.Text = ""
        HighTungsten.Text = ""
        HighMagnesium.Text = ""

        lblCarbon.BackColor = Me.BackColor
        lblManganese.BackColor = Me.BackColor
        lblPhosporus.BackColor = Me.BackColor
        lblSulfur.BackColor = Me.BackColor
        lblSilicon.BackColor = Me.BackColor
        lblNickel.BackColor = Me.BackColor
        lblChromium.BackColor = Me.BackColor
        lblMolybdenum.BackColor = Me.BackColor
        lblCopper.BackColor = Me.BackColor
        lblTin.BackColor = Me.BackColor
        lblVanadium.BackColor = Me.BackColor
        lblAluminum.BackColor = Me.BackColor
        lblNitrogen.BackColor = Me.BackColor
        lblBoron.BackColor = Me.BackColor
        lblTitanium.BackColor = Me.BackColor
        lblNiobium.BackColor = Me.BackColor
        lblIron.BackColor = Me.BackColor
        lblZinc.BackColor = Me.BackColor
        lblLead.BackColor = Me.BackColor
        lblCobalt.BackColor = Me.BackColor
        lblTungsten.BackColor = Me.BackColor
        lblMagnesium.BackColor = Me.BackColor

        txtVendorName.BackColor = Me.BackColor

        cboVendorID.SelectedIndex = -1
        cboSteelCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If

        cboHeatFileNumber.SelectedIndex = -1
        dtpMillReceivingDate.Value = Now

        ''clears the text in the vendor ID if it is still populated
        If Not String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            cboHeatFileNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboVendorID.Text) Then
            cboVendorID.Text = ""
        End If
        txtVendorName.Clear()
        If Not String.IsNullOrEmpty(cboSteelCarbon.Text) Then
            cboSteelCarbon.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
        cboMaterialOrigin.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboMaterialOrigin.Text) Then
            cboMaterialOrigin.Text = ""
        End If

        txtAluminum.Clear()
        txtBoron.Clear()
        txtCarbon.Clear()
        txtChromium.Clear()
        txtCobalt.Clear()
        txtCoilsInHeat.Clear()
        txtComment.Clear()
        txtCopper.Clear()
        txtElongation.Clear()
        txtIron.Clear()
        txtLead.Clear()
        txtManganese.Clear()
        txtMolybdenum.Clear()
        txtNickel.Clear()
        txtNiobium.Clear()
        txtNitrogen.Clear()
        txtPhosphorus.Clear()
        txtPoundsInHeat.Clear()
        txtReductionOfArea.Clear()
        txtSilicon.Clear()
        txtSteelPONumber.Clear()
        txtSulfur.Clear()
        txtTin.Clear()
        txtTitanium.Clear()
        txtUltimateTensile.Clear()
        txtVanadium.Clear()
        txtYield.Clear()
        txtZinc.Clear()
        txtTungsten.Clear()
        txtMagnesium.Clear()

        txtStatus.Text = "OPEN"
        txtBOLNumber.Clear()

        checkStatus()

        txtCarbon.ReadOnly = False
        txtManganese.ReadOnly = False
        txtPhosphorus.ReadOnly = False
        txtSulfur.ReadOnly = False
        txtSilicon.ReadOnly = False
        txtNickel.ReadOnly = False
        txtChromium.ReadOnly = False
        txtMolybdenum.ReadOnly = False
        txtCopper.ReadOnly = False
        txtTin.ReadOnly = False
        txtTitanium.ReadOnly = False
        txtVanadium.ReadOnly = False
        txtAluminum.ReadOnly = False
        txtNitrogen.ReadOnly = False
        txtBoron.ReadOnly = False
        txtNiobium.ReadOnly = False
        txtCobalt.ReadOnly = False
        txtZinc.ReadOnly = False
        txtIron.ReadOnly = False
        txtLead.ReadOnly = False
        txtTungsten.ReadOnly = False
        txtMagnesium.ReadOnly = False

        cmdSelectFile.Enabled = False
        cboHeatFileNumber.Focus()
    End Sub

    Private Sub checkStatus()
        cmd = New SqlCommand("SELECT Status FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber;", con)
        cmd.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = Val(cboHeatFileNumber.Text)
        Dim stat As String = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            stat = cmd.ExecuteScalar()
        Catch ex As System.Exception

        End Try
        con.Close()
        txtStatus.Text = stat

        If txtStatus.Text = "CLOSED" Then
            cboHeatNumber.Enabled = False
            cboSteelCarbon.Enabled = False
            cboSteelSize.Enabled = False
            cboVendorID.Enabled = False
            cboMaterialOrigin.Enabled = False
            dtpMillReceivingDate.Enabled = False
            txtSteelPONumber.ReadOnly = True
            txtComment.ReadOnly = True
            txtYield.ReadOnly = True
            txtReductionOfArea.ReadOnly = True
            txtElongation.ReadOnly = True
            txtCoilsInHeat.ReadOnly = True
            txtPoundsInHeat.ReadOnly = True
            txtUltimateTensile.ReadOnly = True
            txtBOLNumber.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdSelectFile.Enabled = False
        Else
            cboHeatNumber.Enabled = True
            cboSteelCarbon.Enabled = True
            cboSteelSize.Enabled = True
            cboVendorID.Enabled = True
            cboMaterialOrigin.Enabled = True
            dtpMillReceivingDate.Enabled = True
            txtSteelPONumber.ReadOnly = False
            txtComment.ReadOnly = False
            txtYield.ReadOnly = False
            txtReductionOfArea.ReadOnly = False
            txtElongation.ReadOnly = False
            txtCoilsInHeat.ReadOnly = False
            txtPoundsInHeat.ReadOnly = False
            txtUltimateTensile.ReadOnly = False
            txtBOLNumber.Enabled = True
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdSelectFile.Enabled = True
        End If
    End Sub

    Private Sub CheckTolerances()
        txtCarbon_LostFocus(Nothing, Nothing)
        txtManganese_LostFocus(Nothing, Nothing)
        txtPhosphorus_LostFocus(Nothing, Nothing)
        txtSulfur_LostFocus(Nothing, Nothing)
        txtSilicon_LostFocus(Nothing, Nothing)
        txtNickel_LostFocus(Nothing, Nothing)
        txtChromium_LostFocus(Nothing, Nothing)
        txtMolybdenum_LostFocus(Nothing, Nothing)
        txtCopper_LostFocus(Nothing, Nothing)
        txtTin_LostFocus(Nothing, Nothing)
        txtVanadium_LostFocus(Nothing, Nothing)
        txtAluminum_LostFocus(Nothing, Nothing)
        txtNitrogen_LostFocus(Nothing, Nothing)
        txtBoron_LostFocus(Nothing, Nothing)
        txtTitanium_LostFocus(Nothing, Nothing)
        txtIron_LostFocus(Nothing, Nothing)
        txtZinc_LostFocus(Nothing, Nothing)
        txtLead_LostFocus(Nothing, Nothing)
        txtCobalt_LostFocus(Nothing, Nothing)
        txtTungsten_Leave(Nothing, Nothing)
        txtMagnesium_LostFocus(Nothing, Nothing)
    End Sub

    Private Function canComplete() As Boolean
        'Check if RMID Exists
        ValidateSteelRMID()

        If ValidateRMID = 1 Then
            'skip
        Else
            MessageBox.Show("Steel Grade and Size doesn't exist.", "Enter a valid Grade/Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If
        If txtStatus.Text = "CLOSED" Then
            MessageBox.Show("You can't complete a completed mill certification entry", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboHeatNumber.Text) Then
            MessageBox.Show("You must enter a heat number", "Enter a heat number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelCarbon.Text) Then
            MessageBox.Show("You must select a steel carbon", "Select a carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelCarbon.Focus()
            Return False
        End If
        If cboSteelCarbon.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid steel carbon", "Enter a valid carbo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelCarbon.SelectAll()
            cboSteelCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            MessageBox.Show("You must select a steel size", "Select a steel size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If
        If cboSteelSize.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid steel size", "Enter a valid steel size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.SelectAll()
            cboSteelSize.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorID.Text) Then
            MessageBox.Show("You must select a vendor ID", "Select a vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorID.Focus()
            Return False
        End If
        If cboVendorID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid vendor", "Enter a valid vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorID.SelectAll()
            cboVendorID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCoilsInHeat.Text) Then
            MessageBox.Show("You must enter a number of coils in this heat", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilsInHeat.Focus()
            Return False
        End If
        If IsNumeric(txtCoilsInHeat.Text) = False Then
            MessageBox.Show("You must enter a number for coils in heat", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilsInHeat.SelectAll()
            txtCoilsInHeat.Focus()
            Return False
        End If
        If Val(txtCoilsInHeat.Text) <= 0 Then
            MessageBox.Show("You must enter a number of coils in heat", "Enter a number of coils", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCoilsInHeat.SelectAll()
            txtCoilsInHeat.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPoundsInHeat.Text) Then
            MessageBox.Show("You must enter a weight", "Enter a weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPoundsInHeat.Focus()
            Return False
        End If
        If IsNumeric(txtPoundsInHeat.Text) = False Then
            MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPoundsInHeat.SelectAll()
            txtPoundsInHeat.Focus()
            Return False
        End If
        If Val(txtPoundsInHeat.Text) <= 0 Then
            MessageBox.Show("You must enter a valid number for pounds in heat", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPoundsInHeat.SelectAll()
            txtPoundsInHeat.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtUltimateTensile.Text) Then
            txtUltimateTensile.Text = "0"
        End If
        If IsNumeric(txtUltimateTensile.Text) = False Then
            MessageBox.Show("You must enter a number for ultimate tensile", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUltimateTensile.SelectAll()
            txtUltimateTensile.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtYield.Text) Then
            txtYield.Text = "0"
        End If
        If IsNumeric(txtYield.Text) = False Then
            MessageBox.Show("You must enter a number for yield", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtYield.SelectAll()
            txtYield.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtReductionOfArea.Text) Then
            txtReductionOfArea.Text = "0"
        End If
        If IsNumeric(txtReductionOfArea.Text) = False Then
            MessageBox.Show("You must enter a number for reduction of area", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReductionOfArea.SelectAll()
            txtReductionOfArea.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtElongation.Text) Then
            txtElongation.Text = "0"
        End If
        If IsNumeric(txtElongation.Text) = False Then
            MessageBox.Show("You must enter a number for elongation", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtElongation.SelectAll()
            txtElongation.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboMaterialOrigin.Text) Then
            MessageBox.Show("You must select a material origin", "Select a material origin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMaterialOrigin.Focus()
            Return False
        End If
        If cboMaterialOrigin.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid material origin", "enter a valid material origin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMaterialOrigin.SelectAll()
            cboMaterialOrigin.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCarbon.Text) Then
            MessageBox.Show("You must enter a number for carbon", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCarbon.SelectAll()
            txtCarbon.Focus()
            Return False
        End If
        If IsNumeric(txtCarbon.Text) = False Then
            MessageBox.Show("You must enter a number for carbon", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCarbon.SelectAll()
            txtCarbon.Focus()
            Return False
        ElseIf lblCarbon.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for carbon is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCarbon.SelectAll()
            txtCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtManganese.Text) Then
            MessageBox.Show("You must enter a number for manganese", "Enter a number for manganese", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtManganese.SelectAll()
            txtManganese.Focus()
            Return False
        End If
        If IsNumeric(txtManganese.Text) = False Then
            MessageBox.Show("You must enter a number for manganese", "Enter a number for manganese", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtManganese.SelectAll()
            txtManganese.Focus()
            Return False
        ElseIf lblManganese.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for manganese is not within tolerance", "Enter a number for manganese", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtManganese.SelectAll()
            txtManganese.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPhosphorus.Text) Then
            MessageBox.Show("You must enter a number for phosphorus", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhosphorus.SelectAll()
            txtPhosphorus.Focus()
            Return False
        End If
        If IsNumeric(txtPhosphorus.Text) = False Then
            MessageBox.Show("You must enter a number for phosphorus", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhosphorus.SelectAll()
            txtPhosphorus.Focus()
            Return False
        ElseIf lblPhosporus.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for phosphorus is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhosphorus.SelectAll()
            txtPhosphorus.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSulfur.Text) Then
            MessageBox.Show("You must enter a number for sulfur", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSulfur.SelectAll()
            txtSulfur.Focus()
            Return False
        End If
        If IsNumeric(txtSulfur.Text) = False Then
            MessageBox.Show("You must enter a number for sulfur", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSulfur.SelectAll()
            txtSulfur.Focus()
            Return False
        ElseIf lblSulfur.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for sulfur is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSulfur.SelectAll()
            txtSulfur.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSilicon.Text) Then
            MessageBox.Show("You must enter a number for silicon", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSilicon.SelectAll()
            txtSilicon.Focus()
            Return False
        End If
        If IsNumeric(txtSilicon.Text) = False Then
            MessageBox.Show("You must enter a number for silicon", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSilicon.SelectAll()
            txtSilicon.Focus()
            Return False
        ElseIf lblSilicon.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for silicon is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSilicon.SelectAll()
            txtSilicon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtNickel.Text) Then
            txtNickel.Text = "0"
        End If
        If IsNumeric(txtNickel.Text) = False Then
            MessageBox.Show("You must enter a number for nickel", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNickel.SelectAll()
            txtNickel.Focus()
            Return False
        ElseIf lblNickel.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Nickel is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNickel.SelectAll()
            txtNickel.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtChromium.Text) Then
            txtChromium.Text = "0"
        End If
        If IsNumeric(txtChromium.Text) = False Then
            MessageBox.Show("You must enter a number for chromium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtChromium.SelectAll()
            txtChromium.Focus()
            Return False
        ElseIf lblChromium.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Chromium is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtChromium.SelectAll()
            txtChromium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtMolybdenum.Text) Then
            txtMolybdenum.Text = "0"
        End If
        If IsNumeric(txtMolybdenum.Text) = False Then
            MessageBox.Show("You must enter a number for molybdenum", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMolybdenum.SelectAll()
            txtMolybdenum.Focus()
            Return False
        ElseIf lblMolybdenum.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Molybdenum is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMolybdenum.SelectAll()
            txtMolybdenum.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCopper.Text) Then
            txtCopper.Text = "0"
        End If
        If IsNumeric(txtCopper.Text) = False Then
            MessageBox.Show("You must enter a number for copper", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCopper.SelectAll()
            txtCopper.Focus()
            Return False
        ElseIf lblCopper.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Copper is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCopper.SelectAll()
            txtCopper.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTin.Text) Then
            txtTin.Text = "0"
        End If
        If IsNumeric(txtTin.Text) = False Then
            MessageBox.Show("You must enter a number for tin", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTin.SelectAll()
            txtTin.Focus()
            Return False
        ElseIf lblTin.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Tin is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTin.SelectAll()
            txtTin.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtVanadium.Text) Then
            txtVanadium.Text = "0"
        End If
        If IsNumeric(txtVanadium.Text) = False Then
            MessageBox.Show("You must enter a number for vanadium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtVanadium.SelectAll()
            txtVanadium.Focus()
            Return False
        ElseIf lblVanadium.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Vanadium is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtVanadium.SelectAll()
            txtVanadium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAluminum.Text) Then
            txtAluminum.Text = "0"
        End If
        If IsNumeric(txtAluminum.Text) = False Then
            MessageBox.Show("You must enter a number for aluminum", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAluminum.SelectAll()
            txtAluminum.Focus()
            Return False
        ElseIf lblAluminum.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Aluminum is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAluminum.SelectAll()
            txtAluminum.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtNitrogen.Text) Then
            txtNitrogen.Text = "0"
        End If
        If IsNumeric(txtNitrogen.Text) = False Then
            MessageBox.Show("You must enter a number for nitrogen", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNitrogen.SelectAll()
            txtNitrogen.Focus()
            Return False
        ElseIf lblNitrogen.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Nitrogen is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNitrogen.SelectAll()
            txtNitrogen.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBoron.Text) Then
            txtBoron.Text = "0"
        End If
        If IsNumeric(txtBoron.Text) = False Then
            MessageBox.Show("You must enter a number for boron", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoron.SelectAll()
            txtBoron.Focus()
            Return False
        ElseIf lblBoron.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Boron is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoron.SelectAll()
            txtBoron.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTitanium.Text) Then
            txtTitanium.Text = "0"
        End If
        If IsNumeric(txtTitanium.Text) = False Then
            MessageBox.Show("You must enter a number for titanium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTitanium.SelectAll()
            txtTitanium.Focus()
            Return False
        ElseIf lblTitanium.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Titanium is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTitanium.SelectAll()
            txtTitanium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtNiobium.Text) Then
            txtNiobium.Text = "0"
        End If
        If IsNumeric(txtNiobium.Text) = False Then
            MessageBox.Show("You must enter a number for niobium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNiobium.SelectAll()
            txtNiobium.Focus()
            Return False
        ElseIf lblNiobium.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Niobium is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNiobium.SelectAll()
            txtNiobium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtIron.Text) Then
            txtIron.Text = "0"
        End If
        If IsNumeric(txtIron.Text) = False Then
            MessageBox.Show("You must enter a number for iron", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIron.SelectAll()
            txtIron.Focus()
            Return False
        ElseIf lblIron.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Iron is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIron.SelectAll()
            txtIron.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtZinc.Text) Then
            txtZinc.Text = "0"
        End If
        If IsNumeric(txtZinc.Text) = False Then
            MessageBox.Show("You must enter a number for zinc", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtZinc.SelectAll()
            txtZinc.Focus()
            Return False
        ElseIf lblZinc.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Zinc is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtZinc.SelectAll()
            txtZinc.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLead.Text) Then
            txtLead.Text = "0"
        End If
        If IsNumeric(txtLead.Text) = False Then
            MessageBox.Show("You must enter a number for lead", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLead.SelectAll()
            txtLead.Focus()
            Return False
        ElseIf lblLead.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Lead is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLead.SelectAll()
            txtLead.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCobalt.Text) Then
            txtCobalt.Text = "0"
        End If
        If IsNumeric(txtCobalt.Text) = False Then
            MessageBox.Show("You must enter a number for cobalt", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCobalt.SelectAll()
            txtCobalt.Focus()
            Return False
        ElseIf lblCobalt.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Cobalt is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCobalt.SelectAll()
            txtCobalt.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTungsten.Text) Then
            txtTungsten.Text = "0"
        End If
        If IsNumeric(txtTungsten.Text) = False Then
            MessageBox.Show("You must enter a number for Tungsten", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTungsten.SelectAll()
            txtCobalt.Focus()
            Return False
        ElseIf lblTungsten.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Tungsten is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTungsten.SelectAll()
            txtTungsten.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtMagnesium.Text) Then
            txtMagnesium.Text = "0"
        End If
        If IsNumeric(txtMagnesium.Text) = False Then
            MessageBox.Show("You must enter a number for Magnesium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMagnesium.SelectAll()
            txtCobalt.Focus()
            Return False
        ElseIf lblMagnesium.BackColor = Color.LightCoral Then
            MessageBox.Show("Value entered for Magnesium is not within tolerance", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMagnesium.SelectAll()
            txtMagnesium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBOLNumber.Text.Replace(" ", "")) Then
            MessageBox.Show("You must enter a Bill of Lading", "Enter Bill of Lading", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not System.IO.File.Exists(InspectionDir + "\" + cboHeatFileNumber.Text + " " + cboHeatNumber.Text + " " + dtpMillReceivingDate.Value.ToString("MM-dd-yyyy") + ".pdf") AndAlso EmployeeSecurityCode > 1002 Then
            MessageBox.Show("You must upload a receiving inspection file", "Upload inspection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim rslt As DialogResult = MessageBox.Show("Are you sure you wish to complete this heat file record?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If rslt = System.Windows.Forms.DialogResult.No Then
            Return False
        End If
        Return True
    End Function

    Private Function canExit() As Boolean
        If String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            Return False
        End If
        If txtStatus.Text = "CLOSED" Then
            Return False
        End If
        Return True
    End Function

    Private Function canSave() As Boolean
        If txtStatus.Text = "CLOSED" Then
            MessageBox.Show("You can't make any changes to a completed mill certification entry", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            MessageBox.Show("You must select a Heat File number", "Select a Heat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatFileNumber.Focus()
            Return False
        End If
        If cboHeatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Heat File number", "Enter a valid Heat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatFileNumber.SelectAll()
            cboHeatFileNumber.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            If cboHeatNumber.Text = "0" Then
                MessageBox.Show("You must enter a valid heat number", "Enter a valid heat number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboHeatNumber.SelectAll()
                cboHeatNumber.Focus()
                Return False
            End If
        End If

        'Validate that no slashes (/) are in the heat number.
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            If cboHeatNumber.Text.Contains("/") Then
                MessageBox.Show("Heat # cannot contain a slash - replace with a dash (-).", "Enter a valid heat number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboHeatNumber.SelectAll()
                cboHeatNumber.Focus()
                Return False
            End If
        End If

        'Check if RMID Exists
        ValidateSteelRMID()

        If ValidateRMID = 1 Then
            'skip
        Else
            MessageBox.Show("Steel Grade and Size doesn't exist.", "Enter a valid Grade/Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        If Not String.IsNullOrEmpty(cboSteelCarbon.Text) Then
            If cboSteelCarbon.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Grade", "Enter a valid Grade", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSteelCarbon.SelectAll()
                cboSteelCarbon.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            If cboSteelSize.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Steel Size", "Enter a valid Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSteelSize.SelectAll()
                cboSteelSize.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(cboVendorID.Text) Then
            If cboVendorID.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Vendor", "Enter a valid Vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboVendorID.SelectAll()
                cboVendorID.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtCoilsInHeat.Text) Then
            If IsNumeric(txtCoilsInHeat.Text) = False Then
                MessageBox.Show("You must enter a number for coils in heat", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCoilsInHeat.SelectAll()
                txtCoilsInHeat.Focus()
                Return False
            End If
        End If
        If Not String.IsNullOrEmpty(txtPoundsInHeat.Text) Then
            If IsNumeric(txtPoundsInHeat.Text) = False Then
                MessageBox.Show("You must enter a number for weight", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPoundsInHeat.SelectAll()
                txtPoundsInHeat.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtUltimateTensile.Text) Then
            txtUltimateTensile.Text = "0"
        End If
        If IsNumeric(txtUltimateTensile.Text) = False Then
            MessageBox.Show("You must enter a number for ultimate tensile", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUltimateTensile.SelectAll()
            txtUltimateTensile.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtYield.Text) Then
            txtYield.Text = "0"
        End If
        If IsNumeric(txtYield.Text) = False Then
            MessageBox.Show("You must enter a number for yield", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtYield.SelectAll()
            txtYield.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtReductionOfArea.Text) Then
            txtReductionOfArea.Text = "0"
        End If
        If IsNumeric(txtReductionOfArea.Text) = False Then
            MessageBox.Show("You must enter a number for reduction of area", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReductionOfArea.SelectAll()
            txtReductionOfArea.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtElongation.Text) Then
            txtElongation.Text = "0"
        End If
        If IsNumeric(txtElongation.Text) = False Then
            MessageBox.Show("You must enter a number for elongation", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtElongation.SelectAll()
            txtElongation.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCarbon.Text) Then
            txtCarbon.Text = "0"
        End If
        If IsNumeric(txtCarbon.Text) = False Then
            MessageBox.Show("You must enter a number for carbon", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCarbon.SelectAll()
            txtCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtManganese.Text) Then
            txtManganese.Text = "0"
        End If
        If IsNumeric(txtManganese.Text) = False Then
            MessageBox.Show("You must enter a number for manganese", "Enter a number for manganese", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtManganese.SelectAll()
            txtManganese.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPhosphorus.Text) Then
            txtPhosphorus.Text = "0"
        End If
        If IsNumeric(txtPhosphorus.Text) = False Then
            MessageBox.Show("You must enter a number for phosphorus", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhosphorus.SelectAll()
            txtPhosphorus.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSulfur.Text) Then
            txtSulfur.Text = "0"
        End If
        If IsNumeric(txtSulfur.Text) = False Then
            MessageBox.Show("You must enter a number for sulfur", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSulfur.SelectAll()
            txtSulfur.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtSilicon.Text) Then
            txtSilicon.Text = "0"
        End If
        If IsNumeric(txtSilicon.Text) = False Then
            MessageBox.Show("You must enter a number for silicon", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSilicon.SelectAll()
            txtSilicon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtNickel.Text) Then
            txtNickel.Text = "0"
        End If
        If IsNumeric(txtNickel.Text) = False Then
            MessageBox.Show("You must enter a number for nickel", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNickel.SelectAll()
            txtNickel.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtChromium.Text) Then
            txtChromium.Text = "0"
        End If
        If IsNumeric(txtChromium.Text) = False Then
            MessageBox.Show("You must enter a number for chromium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtChromium.SelectAll()
            txtChromium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtMolybdenum.Text) Then
            txtMolybdenum.Text = "0"
        End If
        If IsNumeric(txtMolybdenum.Text) = False Then
            MessageBox.Show("You must enter a number for molybdenum", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMolybdenum.SelectAll()
            txtMolybdenum.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCopper.Text) Then
            txtCopper.Text = "0"
        End If
        If IsNumeric(txtCopper.Text) = False Then
            MessageBox.Show("You must enter a number for copper", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCopper.SelectAll()
            txtCopper.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTin.Text) Then
            txtTin.Text = "0"
        End If
        If IsNumeric(txtTin.Text) = False Then
            MessageBox.Show("You must enter a number for tin", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTin.SelectAll()
            txtTin.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtVanadium.Text) Then
            txtVanadium.Text = "0"
        End If
        If IsNumeric(txtVanadium.Text) = False Then
            MessageBox.Show("You must enter a number for vanadium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtVanadium.SelectAll()
            txtVanadium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAluminum.Text) Then
            txtAluminum.Text = "0"
        End If
        If IsNumeric(txtAluminum.Text) = False Then
            MessageBox.Show("You must enter a number for aluminum", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAluminum.SelectAll()
            txtAluminum.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtNitrogen.Text) Then
            txtNitrogen.Text = "0"
        End If
        If IsNumeric(txtNitrogen.Text) = False Then
            MessageBox.Show("You must enter a number for nitrogen", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNitrogen.SelectAll()
            txtNitrogen.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBoron.Text) Then
            txtBoron.Text = "0"
        End If
        If IsNumeric(txtBoron.Text) = False Then
            MessageBox.Show("You must enter a number for boron", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBoron.SelectAll()
            txtBoron.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtTitanium.Text) Then
            txtTitanium.Text = "0"
        End If
        If IsNumeric(txtTitanium.Text) = False Then
            MessageBox.Show("You must enter a number for titanium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTitanium.SelectAll()
            txtTitanium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtNiobium.Text) Then
            txtNiobium.Text = "0"
        End If
        If IsNumeric(txtNiobium.Text) = False Then
            MessageBox.Show("You must enter a number for niobium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNiobium.SelectAll()
            txtNiobium.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtIron.Text) Then
            txtIron.Text = "0"
        End If
        If IsNumeric(txtIron.Text) = False Then
            MessageBox.Show("You must enter a number for iron", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIron.SelectAll()
            txtIron.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtZinc.Text) Then
            txtZinc.Text = "0"
        End If
        If IsNumeric(txtZinc.Text) = False Then
            MessageBox.Show("You must enter a number for zinc", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtZinc.SelectAll()
            txtZinc.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLead.Text) Then
            txtLead.Text = "0"
        End If
        If IsNumeric(txtLead.Text) = False Then
            MessageBox.Show("You must enter a number for lead", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLead.SelectAll()
            txtLead.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCobalt.Text) Then
            txtCobalt.Text = "0"
        End If
        If IsNumeric(txtCobalt.Text) = False Then
            MessageBox.Show("You must enter a number for cobalt", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCobalt.SelectAll()
            txtCobalt.Focus()
            Return False
        End If
        If IsNumeric(txtMagnesium.Text) = False Then
            MessageBox.Show("You must enter a number for magnesium", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMagnesium.SelectAll()
            txtMagnesium.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboHeatFileNumber.Text) Then
            MessageBox.Show("You must select a Heat File Number", "Select a Heat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatFileNumber.Focus()
            Return False
        End If
        If cboHeatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("Enter a valid Heat File Number", "Enter a valid Heat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If txtStatus.Text.Equals("CLOSED") Then
            MessageBox.Show("You can't delete a completed mill certification entry", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.Focus()
            Return False
        End If
        cmd = New SqlCommand("SELECT Count(HeatNumber) FROM LotNumber WHERE HeatNumberID = @HeatNumberID", con)
        cmd.Parameters.Add("@HeatNumberID", SqlDbType.Int).Value = Val(cboHeatFileNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("Unable to delete, there is a lot number associated to this heat file.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboHeatNumber.Text) Then
            MessageBox.Show("You must select a heat number", "Select a heat file number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatNumber.Focus()
            Return False
        End If
        If cboHeatNumber.SelectedIndex = -1 Then
            MessageBox.Show("No record for heat number found", "Enter a valid heat number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelCarbon.Text) Then
            MessageBox.Show("You must select a steel carbon", "Select a steel carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelCarbon.Focus()
            Return False
        End If
        If cboSteelCarbon.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid steel carbon", "Enter a valid steel carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelCarbon.SelectAll()
            cboSteelCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            MessageBox.Show("You must select a steel size", "Select a steel size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.Focus()
            Return False
        End If
        If cboSteelSize.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid steel size", "Enter a valid steel size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSteelSize.SelectAll()
            cboSteelSize.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub checkChemicalComposition()
        Dim cnt As Integer = 0
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cmd = New SqlCommand("SELECT COUNT(HeatFileNumber) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND Status = 'CLOSED'", con1)
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text

            If con1.State = ConnectionState.Closed Then con1.Open()
            cnt = cmd.ExecuteScalar()
            con.Close()
        End If

        If cnt >= 1 Then
            txtCarbon.ReadOnly = True
            txtManganese.ReadOnly = True
            txtPhosphorus.ReadOnly = True
            txtSulfur.ReadOnly = True
            txtSilicon.ReadOnly = True
            txtNickel.ReadOnly = True
            txtChromium.ReadOnly = True
            txtMolybdenum.ReadOnly = True
            txtCopper.ReadOnly = True
            txtTin.ReadOnly = True
            txtTitanium.ReadOnly = True
            txtVanadium.ReadOnly = True
            txtAluminum.ReadOnly = True
            txtNitrogen.ReadOnly = True
            txtBoron.ReadOnly = True
            txtNiobium.ReadOnly = True
            txtCobalt.ReadOnly = True
            txtZinc.ReadOnly = True
            txtIron.ReadOnly = True
            txtLead.ReadOnly = True
            txtTungsten.ReadOnly = True
            txtMagnesium.ReadOnly = True
        Else
            txtCarbon.ReadOnly = False
            txtManganese.ReadOnly = False
            txtPhosphorus.ReadOnly = False
            txtSulfur.ReadOnly = False
            txtSilicon.ReadOnly = False
            txtNickel.ReadOnly = False
            txtChromium.ReadOnly = False
            txtMolybdenum.ReadOnly = False
            txtCopper.ReadOnly = False
            txtTin.ReadOnly = False
            txtTitanium.ReadOnly = False
            txtVanadium.ReadOnly = False
            txtAluminum.ReadOnly = False
            txtNitrogen.ReadOnly = False
            txtBoron.ReadOnly = False
            txtNiobium.ReadOnly = False
            txtCobalt.ReadOnly = False
            txtZinc.ReadOnly = False
            txtIron.ReadOnly = False
            txtLead.ReadOnly = False
            txtTungsten.ReadOnly = False
            txtMagnesium.ReadOnly = False
        End If
    End Sub

    Public Sub ValidateSteelRMID()
        'Check to see if part exists
        Dim ValidateRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND SteelStatus <> 'CLOSED'"
        Dim ValidateRMIDCommand As New SqlCommand(ValidateRMIDStatement, con)
        ValidateRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        ValidateRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ValidateRMID = CInt(ValidateRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            ValidateRMID = 0
        End Try
        con.Close()
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

    Private Function canFillSizeData() As Boolean
        If String.IsNullOrEmpty(cboHeatNumber.Text) Then
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelCarbon.Text) Then
            Return False
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) Then
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorID.Text) Then
            Return False
        End If
        Return True
    End Function

    'Update/Insert Commands

    Private Sub updateHeatNumberLog(ByVal status As String)
        'Write data to the database
        cmd = New SqlCommand("Update HeatNumberLog SET HeatNumber = @HeatNumber, SteelType = @SteelType, SteelSize = @SteelSize, VendorID = @VendorID, DateReceived = @DateReceived, SteelPONumber = @SteelPONumber, Comments = @Comments, Yield = @Yield, ReductionOfArea = @ReductionOfArea, Elongation = @Elongation, CoilsInHeat = @CoilsInHeat, PoundsInHeat = @PoundsInHeat, UltimateYield = @UltimateYield, Status = @Status, Carbon = @Carbon, Manganese = @Manganese, Phosphorus = @Phosphorus, Sulfur = @Sulfur, Silicon = @Silicon, Nickel = @Nickel, Chromium = @Chromium, Molybdenum = @Molybdenum, Copper = @Copper, Tin = @Tin, Vanadium = @Vanadium, Aluminum = @Aluminum, Nitrogen = @Nitrogen, Boron = @Boron, Titanium = @Titanium, Niobium = @Niobium, Cobalt = @Cobalt, Zinc = @Zinc, Iron = @Iron, Lead = @Lead, Tungsten = @Tungsten, Magnesium = @Magnesium, MaterialOrigin = @MaterialOrigin, BOLNumber = @BOLNumber, CEVValue = @CEVValue WHERE HeatFileNumber = @HeatFileNumber;", con)

        With cmd.Parameters
            .Add("@HeatFileNumber", SqlDbType.VarChar).Value = Val(cboHeatFileNumber.Text)
            .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            .Add("@SteelType", SqlDbType.VarChar).Value = cboSteelCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@DateReceived", SqlDbType.VarChar).Value = dtpMillReceivingDate.Text
            .Add("@SteelPONumber", SqlDbType.VarChar).Value = txtSteelPONumber.Text
            .Add("@Comments", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@Yield", SqlDbType.VarChar).Value = Val(txtYield.Text)
            .Add("@ReductionOfArea", SqlDbType.VarChar).Value = Val(txtReductionOfArea.Text)
            .Add("@Elongation", SqlDbType.VarChar).Value = Val(txtElongation.Text)
            .Add("@CoilsInHeat", SqlDbType.VarChar).Value = Val(txtCoilsInHeat.Text)
            .Add("@PoundsInHeat", SqlDbType.VarChar).Value = Val(txtPoundsInHeat.Text)
            .Add("@UltimateYield", SqlDbType.VarChar).Value = Val(txtUltimateTensile.Text)
            .Add("@Status", SqlDbType.VarChar).Value = status
            .Add("@Carbon", SqlDbType.VarChar).Value = Val(txtCarbon.Text)
            .Add("@Manganese", SqlDbType.VarChar).Value = Val(txtManganese.Text)
            .Add("@Phosphorus", SqlDbType.VarChar).Value = Val(txtPhosphorus.Text)
            .Add("@Sulfur", SqlDbType.VarChar).Value = Val(txtSulfur.Text)
            .Add("@Silicon", SqlDbType.VarChar).Value = Val(txtSilicon.Text)
            .Add("@Nickel", SqlDbType.VarChar).Value = Val(txtNickel.Text)
            .Add("@Chromium", SqlDbType.VarChar).Value = Val(txtChromium.Text)
            .Add("@Molybdenum", SqlDbType.VarChar).Value = Val(txtMolybdenum.Text)
            .Add("@Copper", SqlDbType.VarChar).Value = Val(txtCopper.Text)
            .Add("@Tin", SqlDbType.VarChar).Value = Val(txtTin.Text)
            .Add("@Vanadium", SqlDbType.VarChar).Value = Val(txtVanadium.Text)
            .Add("@Aluminum", SqlDbType.VarChar).Value = Val(txtAluminum.Text)
            .Add("@Nitrogen", SqlDbType.VarChar).Value = Val(txtNitrogen.Text)
            .Add("@Boron", SqlDbType.VarChar).Value = Val(txtBoron.Text)
            .Add("@Titanium", SqlDbType.VarChar).Value = Val(txtTitanium.Text)
            .Add("@Niobium", SqlDbType.VarChar).Value = Val(txtNiobium.Text)
            .Add("@Cobalt", SqlDbType.VarChar).Value = Val(txtCobalt.Text)
            .Add("@Zinc", SqlDbType.VarChar).Value = Val(txtZinc.Text)
            .Add("@Iron", SqlDbType.VarChar).Value = Val(txtIron.Text)
            .Add("@Lead", SqlDbType.VarChar).Value = Val(txtLead.Text)
            .Add("@Tungsten", SqlDbType.VarChar).Value = Val(txtTungsten.Text)
            .Add("@Magnesium", SqlDbType.VarChar).Value = Val(txtMagnesium.Text)
            .Add("@MaterialOrigin", SqlDbType.VarChar).Value = cboMaterialOrigin.Text
            .Add("@BOLNumber", SqlDbType.VarChar).Value = txtBOLNumber.Text
            .Add("@CEVValue", SqlDbType.VarChar).Value = Val(txtCEV.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub updateChemicalComposition()
        'Save to database
        cmd = New SqlCommand("UPDATE HeatNumberLog SET Carbon = @Carbon, Manganese = @Manganese, Phosphorus = @Phosphorus, Sulfur = @Sulfur, Silicon = @Silicon, Nickel = @Nickel, Chromium = @Chromium, Molybdenum = @Molybdenum, Copper = @Copper, Tin = @Tin, Vanadium = @Vanadium, Aluminum = @Aluminum, Nitrogen = @Nitrogen, Boron = @Boron, Titanium = @Titanium, Niobium = @Niobium, Cobalt = @Cobalt, Zinc = @Zinc, Iron = @Iron, Lead = @Lead, Tungsten = @Tungsten, Magnesium = @Magnesium WHERE HeatNumber = @HeatNumber;", con)

        With cmd.Parameters
            .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            .Add("@Carbon", SqlDbType.Float).Value = Val(txtCarbon.Text)
            .Add("@Manganese", SqlDbType.Float).Value = Val(txtManganese.Text)
            .Add("@Phosphorus", SqlDbType.Float).Value = Val(txtPhosphorus.Text)
            .Add("@Sulfur", SqlDbType.Float).Value = Val(txtSulfur.Text)
            .Add("@Silicon", SqlDbType.Float).Value = Val(txtSilicon.Text)
            .Add("@Nickel", SqlDbType.Float).Value = Val(txtNickel.Text)
            .Add("@Chromium", SqlDbType.Float).Value = Val(txtChromium.Text)
            .Add("@Molybdenum", SqlDbType.Float).Value = Val(txtMolybdenum.Text)
            .Add("@Copper", SqlDbType.Float).Value = Val(txtCopper.Text)
            .Add("@Tin", SqlDbType.Float).Value = Val(txtTin.Text)
            .Add("@Vanadium", SqlDbType.Float).Value = Val(txtVanadium.Text)
            .Add("@Aluminum", SqlDbType.Float).Value = Val(txtAluminum.Text)
            .Add("@Nitrogen", SqlDbType.Float).Value = Val(txtNitrogen.Text)
            .Add("@Boron", SqlDbType.Float).Value = Val(txtBoron.Text)
            .Add("@Titanium", SqlDbType.Float).Value = Val(txtTitanium.Text)
            .Add("@Niobium", SqlDbType.Float).Value = Val(txtNiobium.Text)
            .Add("@Cobalt", SqlDbType.Float).Value = Val(txtCobalt.Text)
            .Add("@Zinc", SqlDbType.Float).Value = Val(txtZinc.Text)
            .Add("@Iron", SqlDbType.Float).Value = Val(txtIron.Text)
            .Add("@Lead", SqlDbType.Float).Value = Val(txtLead.Text)
            .Add("@Tungsten", SqlDbType.Float).Value = Val(txtTungsten.Text)
            .Add("@Magnesium", SqlDbType.Float).Value = Val(txtMagnesium.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub insertIntoHeatNumberLog(ByVal status As String)
        'Write data to the database
        cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(HeatFileNumber) + 1, 78001) FROM HeatNumberLog); Insert Into HeatNumberLog(HeatFileNumber, HeatNumber, SteelType, SteelSize, VendorID, DateReceived, SteelPONumber, Comments, Yield, ReductionOfArea, Elongation, Carbon, Manganese, Phosphorus, Sulfur, Silicon, Nickel, Chromium, Molybdenum, Copper, Tin, Vanadium, Aluminum, Nitrogen, Boron, Titanium, Niobium, Cobalt, Zinc, Iron, Lead, Tungsten, Magnesium, CoilsInHeat, PoundsInHeat, UltimateYield, Status, MaterialOrigin, BOLNumber, CEVValue) Values (@Key, @HeatNumber, @SteelType, @SteelSize, @VendorID, @DateReceived, @SteelPONumber, @Comments, @Yield, @ReductionOfArea, @Elongation, @Carbon, @Manganese, @Phosphorus, @Sulfur, @Silicon, @Nickel, @Chromium, @Molybdenum, @Copper, @Tin, @Vanadium, @Aluminum, @Nitrogen, @Boron, @Titanium, @Niobium, @Cobalt, @Zinc, @Iron, @Lead, @Tungsten, @Magnesium, @CoilsInHeat, @PoundsInHeat, @UltimateYield, @Status, @MaterialOrigin, @BOLNumber, @CEVValue); SELECT @Key;", con)

        With cmd.Parameters
            .Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
            .Add("@SteelType", SqlDbType.VarChar).Value = cboSteelCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@DateReceived", SqlDbType.VarChar).Value = dtpMillReceivingDate.Text
            .Add("@SteelPONumber", SqlDbType.VarChar).Value = Val(txtSteelPONumber.Text)
            .Add("@Comments", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@Yield", SqlDbType.VarChar).Value = Val(txtYield.Text)
            .Add("@ReductionOfArea", SqlDbType.VarChar).Value = Val(txtReductionOfArea.Text)
            .Add("@Elongation", SqlDbType.VarChar).Value = Val(txtElongation.Text)
            .Add("@Carbon", SqlDbType.VarChar).Value = Val(txtCarbon.Text)
            .Add("@Manganese", SqlDbType.VarChar).Value = Val(txtManganese.Text)
            .Add("@Phosphorus", SqlDbType.VarChar).Value = Val(txtPhosphorus.Text)
            .Add("@Sulfur", SqlDbType.VarChar).Value = Val(txtSulfur.Text)
            .Add("@Silicon", SqlDbType.VarChar).Value = Val(txtSilicon.Text)
            .Add("@Nickel", SqlDbType.VarChar).Value = Val(txtNickel.Text)
            .Add("@Chromium", SqlDbType.VarChar).Value = Val(txtChromium.Text)
            .Add("@Molybdenum", SqlDbType.VarChar).Value = Val(txtMolybdenum.Text)
            .Add("@Copper", SqlDbType.VarChar).Value = Val(txtCopper.Text)
            .Add("@Tin", SqlDbType.VarChar).Value = Val(txtTin.Text)
            .Add("@Vanadium", SqlDbType.VarChar).Value = Val(txtVanadium.Text)
            .Add("@Aluminum", SqlDbType.VarChar).Value = Val(txtAluminum.Text)
            .Add("@Nitrogen", SqlDbType.VarChar).Value = Val(txtNitrogen.Text)
            .Add("@Boron", SqlDbType.VarChar).Value = Val(txtBoron.Text)
            .Add("@Titanium", SqlDbType.VarChar).Value = Val(txtTitanium.Text)
            .Add("@Niobium", SqlDbType.VarChar).Value = Val(txtNiobium.Text)
            .Add("@Cobalt", SqlDbType.VarChar).Value = Val(txtCobalt.Text)
            .Add("@Zinc", SqlDbType.VarChar).Value = Val(txtZinc.Text)
            .Add("@Iron", SqlDbType.VarChar).Value = Val(txtIron.Text)
            .Add("@Lead", SqlDbType.VarChar).Value = Val(txtLead.Text)
            .Add("@Tungsten", SqlDbType.VarChar).Value = Val(txtTungsten.Text)
            .Add("@Magnesium", SqlDbType.VarChar).Value = Val(txtMagnesium.Text)
            .Add("@CoilsInHeat", SqlDbType.VarChar).Value = Val(txtCoilsInHeat.Text)
            .Add("@PoundsInHeat", SqlDbType.VarChar).Value = Val(txtPoundsInHeat.Text)
            .Add("@UltimateYield", SqlDbType.VarChar).Value = Val(txtUltimateTensile.Text)
            .Add("@Status", SqlDbType.VarChar).Value = status
            .Add("@MaterialOrigin", SqlDbType.VarChar).Value = cboMaterialOrigin.Text
            .Add("@BOLNumber", SqlDbType.VarChar).Value = txtBOLNumber.Text
            .Add("@CEVValue", SqlDbType.VarChar).Value = Val(txtCEV.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()

        LoadHeatFileNumber()

        If Not IsDBNull(obj) Then
            cboHeatFileNumber.Text = obj.ToString()
        End If
    End Sub

    Private Sub updateCEV()
        Dim CEV As Double = 0

        If cboSteelCarbon.Text.StartsWith("A706") Then
            CEV = Val(txtCarbon.Text) + (Val(txtManganese.Text) / 6) + (Val(txtCopper.Text) / 40) + (Val(txtNickel.Text) / 20) + (Val(txtChromium.Text) / 10) - (Val(txtMolybdenum.Text) / 50) - (Val(txtVanadium.Text) / 10)
        Else
            CEV = (Val(txtCarbon.Text) + (Val(txtManganese.Text)) / 6 + (Val(txtChromium.Text) + Val(txtMolybdenum.Text) + Val(txtVanadium.Text)) / 5 + (Val(txtCopper.Text) + Val(txtNickel.Text)) / 15)
        End If

        CEV = Math.Round(CEV, 4)

        If cboSteelCarbon.Text.StartsWith("A706") Then
            If CEV < 0.31 Or CEV > 0.42 Then
                txtCEV.BackColor = Color.Yellow
            Else
                txtCEV.BackColor = Me.BackColor
            End If
        Else
            If CEV > 0.35 AndAlso cboSteelCarbon.Text.StartsWith("C10") AndAlso Val(cboSteelCarbon.Text.Substring(2, 2)) <= 18 Then
                txtCEV.BackColor = Color.LightCoral
            Else
                txtCEV.BackColor = Me.BackColor
            End If
        End If

        txtCEV.Text = CEV.ToString
    End Sub

    'Menu Items

    Private Sub UnLockCompositionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockCompositionToolStripMenuItem.Click
        txtCarbon.ReadOnly = False
        txtManganese.ReadOnly = False
        txtPhosphorus.ReadOnly = False
        txtSulfur.ReadOnly = False
        txtSilicon.ReadOnly = False
        txtNickel.ReadOnly = False
        txtChromium.ReadOnly = False
        txtMolybdenum.ReadOnly = False
        txtCopper.ReadOnly = False
        txtTin.ReadOnly = False
        txtTitanium.ReadOnly = False
        txtVanadium.ReadOnly = False
        txtAluminum.ReadOnly = False
        txtNitrogen.ReadOnly = False
        txtBoron.ReadOnly = False
        txtNiobium.ReadOnly = False
        txtCobalt.ReadOnly = False
        txtZinc.ReadOnly = False
        txtIron.ReadOnly = False
        txtLead.ReadOnly = False
        txtTungsten.ReadOnly = False
        txtMagnesium.ReadOnly = False
    End Sub

    Private Sub UnLockMillCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockMillCertToolStripMenuItem.Click
        If cboHeatFileNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a Heat File Number", "Select a Heat File Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboHeatFileNumber.Focus()
            Exit Sub
        End If
        cmd = New SqlCommand("UPDATE HeatNumberLog Set Status = 'OPEN' WHERE HeatFileNumber = @HeatFileNumber;", con)
        cmd.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = Val(cboHeatFileNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        checkStatus()
    End Sub

    Private Sub ViewReceivingInspectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewReceivingInspectionToolStripMenuItem.Click
        'Dim files As String() = System.IO.Directory.GetFiles(InspectionDir, cboHeatFileNumber.Text + "*.pdf")
        'If files.Length > 0 Then
        '    If File.Exists(files) Then
        '        System.Diagnostics.Process.Start(files)
        '    Else
        '        MsgBox("File can not be found", MsgBoxStyle.OkOnly)
        '    End If
        'Else
        '    MessageBox.Show("There are no receiving inspection reports to view.", "No receiving inspections", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    'Text Box Text Changed Events

    Private Sub txtCarbon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCarbon.TextChanged, txtManganese.TextChanged, txtSilicon.TextChanged, txtNickel.TextChanged, txtChromium.TextChanged, txtMolybdenum.TextChanged, txtCopper.TextChanged, txtVanadium.TextChanged, txtTitanium.TextChanged, txtNiobium.TextChanged, txtBoron.TextChanged, txtMagnesium.TextChanged
        updateCEV()
        CheckTolerances()
    End Sub

    Private Sub txtTitanium_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitanium.TextChanged

    End Sub

    Private Sub txtNiobium_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNiobium.TextChanged

    End Sub

    Private Sub txtBoron_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoron.TextChanged

    End Sub

    Private Sub txtNitrogen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNitrogen.TextChanged

    End Sub

    Private Sub txtAluminum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAluminum.TextChanged

    End Sub

    Private Sub txtPhosphorus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPhosphorus.TextChanged

    End Sub

    Private Sub txtSulfur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSulfur.TextChanged

    End Sub

    Private Sub txtTin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTin.TextChanged

    End Sub

    Private Sub txtIron_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIron.TextChanged

    End Sub

    Private Sub txtZinc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZinc.TextChanged

    End Sub

    Private Sub txtLead_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLead.TextChanged

    End Sub

    Private Sub txtCobalt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCobalt.TextChanged

    End Sub

    Private Sub txtTungsten_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTungsten.TextChanged

    End Sub

    Private Sub txtMagnesium_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMagnesium.TextChanged

    End Sub

    'Combo Box Index Changed Events

    Private Sub cboHeatNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatNumber.SelectedIndexChanged
        ''check to make sure that we can load previous data about the given heat and size
        If canFillSizeData() Then
            LoadSizeData()
        End If

        loadChemicalComposition()
        checkChemicalComposition()
        CheckTolerances()
    End Sub

    Private Sub cboHeatFileNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeatFileNumber.SelectedIndexChanged
        'Load Data
        LoadMillCertData()
        LoadUploadedFileCount()
        updateCEV()

        If String.IsNullOrEmpty(cboHeatFileNumber.Text) Or LoadUploadedFileCount() > 0 Then
            cmdSelectFile.Enabled = False
        Else
            cmdSelectFile.Enabled = True
        End If
    End Sub

    Private Sub cboSteelCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelCarbon.SelectedIndexChanged
        ''check to make sure that we can load previous data about the given heat and size
        If canFillSizeData() Then
            LoadSizeData()
        End If

        LoadTolerances()
        updateCEV()

        If cboHeatNumber.Text <> "" Then
            CheckTolerances()
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        ''check to make sure that we can load previous data about the given heat and size
        If canFillSizeData() Then
            LoadSizeData()
        End If
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        ''check to make sure that we can load previous data about the given heat and size
        If canFillSizeData() Then
            LoadSizeData()
        End If
        If Not String.IsNullOrEmpty(cboVendorID.Text) Then
            Dim SteelVendorName As String = ""
            cmd = New SqlCommand("SELECT VendorName FROM Vendor WHERE DivisionID = 'TWD' AND VendorCode = @VendorCode;", con)
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SteelVendorName = cmd.ExecuteScalar
            Catch ex As System.Exception
                SteelVendorName = ""
            End Try
            con.Close()
            txtVendorName.Text = SteelVendorName
        Else
            txtVendorName.Text = ""
        End If
    End Sub

    'Text Box/Combo Box -  Key up, Key Down, Key Press Events

    Private Sub txt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarbon.KeyUp, txtManganese.KeyUp, txtPhosphorus.KeyUp, txtSulfur.KeyUp, txtSilicon.KeyUp, txtNickel.KeyUp, txtChromium.KeyUp, txtMolybdenum.KeyUp, txtCopper.KeyUp, txtTin.KeyUp, txtVanadium.KeyUp, txtAluminum.KeyUp, txtNitrogen.KeyUp, txtBoron.KeyUp, txtTitanium.KeyUp, txtNiobium.KeyUp, txtIron.KeyUp, txtZinc.KeyUp, txtLead.KeyUp, txtCobalt.KeyUp, txtTungsten.KeyUp
        If e.KeyCode = Keys.Enter And NoStopSkip Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            e.Handled = True
        Else
            NoStopSkip = True
        End If
    End Sub

    Private Sub txtSteelPONumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSteelPONumber.KeyUp, txtCoilsInHeat.KeyUp, txtPoundsInHeat.KeyUp, txtUltimateTensile.KeyUp, txtYield.KeyUp, txtReductionOfArea.KeyUp, txtElongation.KeyUp, txtComment.KeyUp, cboHeatFileNumber.KeyUp, cboHeatNumber.KeyUp, cboSteelCarbon.KeyUp, cboSteelSize.KeyUp, cboVendorID.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub dtpMillReceivingDate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpMillReceivingDate.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtSteelPONumber.SelectAll()
            txtSteelPONumber.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub Field_Number_Only_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPoundsInHeat.KeyPress, txtCoilsInHeat.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub Field_Number_Only_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoilsInHeat.KeyDown, txtPoundsInHeat.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Then
            controlKey = True
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAluminum.KeyPress, txtNitrogen.KeyPress, txtBoron.KeyPress, txtCarbon.KeyPress, txtManganese.KeyPress, txtPhosphorus.KeyPress, txtSulfur.KeyPress, txtSilicon.KeyPress, txtNickel.KeyPress, txtChromium.KeyPress, txtMolybdenum.KeyPress, txtCopper.KeyPress, txtTin.KeyPress, txtVanadium.KeyPress, txtTitanium.KeyPress, txtNiobium.KeyPress, txtIron.KeyPress, txtZinc.KeyPress, txtLead.KeyPress, txtCobalt.KeyPress, txtTungsten.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAluminum.KeyDown, txtNitrogen.KeyDown, txtBoron.KeyDown, txtCarbon.KeyDown, txtManganese.KeyDown, txtPhosphorus.KeyDown, txtSulfur.KeyDown, txtSilicon.KeyDown, txtNickel.KeyDown, txtChromium.KeyDown, txtMolybdenum.KeyDown, txtCopper.KeyDown, txtTin.KeyDown, txtVanadium.KeyDown, txtTitanium.KeyDown, txtNiobium.KeyDown, txtIron.KeyDown, txtZinc.KeyDown, txtLead.KeyDown, txtCobalt.KeyDown, txtTungsten.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod Then
            If e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod Then
                If Not CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") Then
                    controlKey = True
                End If
            Else
                controlKey = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
        If e.KeyChar.Equals("."c) And (cboSteelSize.Text.Length = 0 Or cboSteelSize.SelectionLength = cboSteelSize.Text.Length) Then
            cboSteelSize.Text = "0."
            e.KeyChar = Nothing
            cboSteelSize.SelectionStart = cboSteelSize.Text.Length
            cboSteelSize.SelectionLength = 0
        End If
    End Sub

    Private Sub cboMaterialOrigin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMaterialOrigin.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub txtTungsten_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTungsten.Leave
        If Val(LowTungsten.Text) > 0 Or Val(HighTungsten.Text) > 0 Then
            If Val(LowTungsten.Text) <= Val(txtTungsten.Text) AndAlso Val(txtTungsten.Text) <= Val(HighTungsten.Text) Then
                lblTungsten.BackColor = Me.BackColor
            Else
                lblTungsten.BackColor = Color.LightCoral
                NoStopSkip = False
            End If
        Else
            If Val(LowTungsten.Text) = 0 AndAlso Val(HighTungsten.Text) = 0 Then
                If Val(txtTungsten.Text) >= 99 Then
                    lblTungsten.BackColor = Color.LightCoral
                    NoStopSkip = False
                Else
                    lblTungsten.BackColor = Me.BackColor
                End If
            Else
                lblTungsten.BackColor = Me.BackColor
            End If
        End If
    End Sub

End Class