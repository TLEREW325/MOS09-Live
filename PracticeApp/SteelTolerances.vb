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
Public Class SteelTolerances
    Inherits System.Windows.Forms.Form

    Dim CarbonMinimum, CarbonMaximum, ManganeseMinimum, ManganeseMaximum, PhosphorusMinimum, PhosphorusMaximum, SulfurMinimum, SulfurMaximum, SiliconMinimum, SiliconMaximum, CopperMinimum, CopperMaximum, NickelMinimum, NickelMaximum, ChromiumMinimum, ChromiumMaximum, MolybdenumMinimum, MolybdenumMaximum, TinMinimum, TinMaximum, AluminumMinimum, AluminumMaximum, NitrogenMinimum, NitrogenMaximum, VanadiumMinimum, VanadiumMaximum, BoronMinimum, BoronMaximum, TitaniumMinimum, TitaniumMaximum, CarbideMinimum, CarbideMaximum, CobaltMinimum, CobaltMaximum, ZincMinimum, ZincMaximum, IronMinimum, IronMaximum, LeadMinimum, LeadMaximum, NiobiumMinimum, NiobiumMaximum, TungstenMinimum, TungstenMaximum, MagnesiumMinimum, MagnesiumMaximum As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim isControlKey As Boolean = False

    Private Sub SteelTolerances_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeLoginName = "SAMRAY" Then
            gpxSteelTolerances.Enabled = True
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        Else
            gpxSteelTolerances.Enabled = False
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        End If

        LoadRawMaterialData()
        ClearAll()

        If GlobalSteelCarbon = "" Then
            cboSteelAlloy.SelectedIndex = -1
        Else
            cboSteelAlloy.Text = GlobalSteelCarbon
        End If
    End Sub

    Public Sub LoadRawMaterialData()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RawMaterialsTable")
        cboSteelAlloy.DataSource = ds.Tables("RawMaterialsTable")
        con.Close()
        cboSteelAlloy.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelTolerances()
        cmd = New SqlCommand("SELECT * FROM SteelChemistryTolerances WHERE Alloy = @Alloy", con)
        cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = cboSteelAlloy.Text

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
            If IsDBNull(reader.Item("CarbideMinimum")) Then
                CarbideMinimum = 0
            Else
                CarbideMinimum = reader.Item("CarbideMinimum")
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
            AluminumMaximum = 0
            AluminumMinimum = 0
            BoronMaximum = 0
            BoronMinimum = 0
            CarbideMaximum = 0
            CarbideMinimum = 0
            CarbonMaximum = 0
            CarbonMinimum = 0
            ChromiumMaximum = 0
            ChromiumMinimum = 0
            CobaltMaximum = 0
            CobaltMinimum = 0
            CopperMaximum = 0
            CopperMinimum = 0
            IronMaximum = 0
            IronMinimum = 0
            LeadMaximum = 0
            LeadMinimum = 0
            ManganeseMaximum = 0
            ManganeseMinimum = 0
            MolybdenumMaximum = 0
            MolybdenumMinimum = 0
            NickelMaximum = 0
            NickelMinimum = 0
            NiobiumMaximum = 0
            NiobiumMinimum = 0
            NitrogenMaximum = 0
            NitrogenMinimum = 0
            PhosphorusMaximum = 0
            PhosphorusMinimum = 0
            SiliconMaximum = 0
            SiliconMinimum = 0
            SulfurMaximum = 0
            SulfurMinimum = 0
            TinMaximum = 0
            TinMinimum = 0
            TitaniumMaximum = 0
            TitaniumMinimum = 0
            VanadiumMaximum = 0
            VanadiumMinimum = 0
            ZincMaximum = 0
            ZincMinimum = 0
            TungstenMaximum = 0
            TungstenMinimum = 0
            MagnesiumMinimum = 0
            MagnesiumMaximum = 0
        End If
        reader.Close()
        con.Close()

        txtAluminumMax.Text = AluminumMaximum
        txtAluminumMin.Text = AluminumMinimum
        txtBoronMax.Text = BoronMaximum
        txtBoronMin.Text = BoronMinimum
        txtCarbideMax.Text = CarbideMaximum
        txtCarbideMin.Text = CarbideMinimum
        txtCarbonMax.Text = CarbonMaximum
        txtCarbonMin.Text = CarbonMinimum
        txtChromiumMax.Text = ChromiumMaximum
        txtChromiumMin.Text = ChromiumMinimum
        txtCobaltMax.Text = CobaltMaximum
        txtCobaltMin.Text = CobaltMinimum
        txtCopperMax.Text = CopperMaximum
        txtCopperMin.Text = CopperMinimum
        txtIronMax.Text = IronMaximum
        txtIronMin.Text = IronMinimum
        txtLeadMax.Text = LeadMaximum
        txtLeadMin.Text = LeadMinimum
        txtManganeseMax.Text = ManganeseMaximum
        txtManganeseMin.Text = ManganeseMinimum
        txtMolybdenumMax.Text = MolybdenumMaximum
        txtMolybdenumMin.Text = MolybdenumMinimum
        txtNickelMax.Text = NickelMaximum
        txtNickelMin.Text = NickelMinimum
        txtNiobiumMax.Text = NiobiumMaximum
        txtNiobiumMin.Text = NiobiumMinimum
        txtNitrogenMax.Text = NitrogenMaximum
        txtNitrogenMin.Text = NitrogenMinimum
        txtPhosphorusMax.Text = PhosphorusMaximum
        txtPhosphorusMin.Text = PhosphorusMinimum
        txtSiliconMax.Text = SiliconMaximum
        txtSiliconMin.Text = SiliconMinimum
        txtSulfurMax.Text = SulfurMaximum
        txtSulfurMin.Text = SulfurMinimum
        txtTinMax.Text = TinMaximum
        txtTinMin.Text = TinMinimum
        txtTitaniumMax.Text = TitaniumMaximum
        txtTitaniumMin.Text = TitaniumMinimum
        txtVanadiumMax.Text = VanadiumMaximum
        txtVanadiumMin.Text = VanadiumMinimum
        txtZincMax.Text = ZincMaximum
        txtZincMin.Text = ZincMinimum
        txtTungstenMin.Text = TungstenMinimum
        txtTungstenMax.Text = TungstenMaximum
        txtMagnesiumMin.Text = MagnesiumMinimum
        txtMagnesiumMax.Text = MagnesiumMaximum
    End Sub

    Public Sub ClearAll()
        cboSteelAlloy.Refresh()

        cboSteelAlloy.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboSteelAlloy.Text) Then
            cboSteelAlloy.Text = ""
        End If

        txtAluminumMax.Refresh()
        txtAluminumMin.Refresh()
        txtBoronMax.Refresh()
        txtBoronMin.Refresh()
        txtCarbideMax.Refresh()
        txtCarbideMin.Refresh()
        txtCarbonMax.Refresh()
        txtCarbonMin.Refresh()
        txtChromiumMax.Refresh()
        txtChromiumMin.Refresh()
        txtCobaltMax.Refresh()
        txtCobaltMin.Refresh()
        txtCopperMax.Refresh()
        txtCopperMin.Refresh()
        txtIronMax.Refresh()
        txtIronMin.Refresh()
        txtLeadMax.Refresh()
        txtLeadMin.Refresh()
        txtManganeseMax.Refresh()
        txtManganeseMin.Refresh()
        txtMolybdenumMax.Refresh()
        txtMolybdenumMin.Refresh()
        txtNickelMax.Refresh()
        txtNickelMin.Refresh()
        txtNiobiumMax.Refresh()
        txtNiobiumMin.Refresh()
        txtNitrogenMax.Refresh()
        txtNitrogenMin.Refresh()
        txtPhosphorusMax.Refresh()
        txtPhosphorusMin.Refresh()
        txtSiliconMax.Refresh()
        txtSiliconMin.Refresh()
        txtSulfurMax.Refresh()
        txtSulfurMin.Refresh()
        txtTinMax.Refresh()
        txtTinMin.Refresh()
        txtTitaniumMax.Refresh()
        txtTitaniumMin.Refresh()
        txtVanadiumMax.Refresh()
        txtVanadiumMin.Refresh()
        txtZincMax.Refresh()
        txtZincMin.Refresh()
        txtTungstenMax.Refresh()
        txtTungstenMin.Refresh()
        txtMagnesiumMin.Refresh()
        txtMagnesiumMax.Refresh()

        txtAluminumMax.Clear()
        txtAluminumMin.Clear()
        txtBoronMax.Clear()
        txtBoronMin.Clear()
        txtCarbideMax.Clear()
        txtCarbideMin.Clear()
        txtCarbonMax.Clear()
        txtCarbonMin.Clear()
        txtChromiumMax.Clear()
        txtChromiumMin.Clear()
        txtCobaltMax.Clear()
        txtCobaltMin.Clear()
        txtCopperMax.Clear()
        txtCopperMin.Clear()
        txtIronMax.Clear()
        txtIronMin.Clear()
        txtLeadMax.Clear()
        txtLeadMin.Clear()
        txtManganeseMax.Clear()
        txtManganeseMin.Clear()
        txtMolybdenumMax.Clear()
        txtMolybdenumMin.Clear()
        txtNickelMax.Clear()
        txtNickelMin.Clear()
        txtNiobiumMax.Clear()
        txtNiobiumMin.Clear()
        txtNitrogenMax.Clear()
        txtNitrogenMin.Clear()
        txtPhosphorusMax.Clear()
        txtPhosphorusMin.Clear()
        txtSiliconMax.Clear()
        txtSiliconMin.Clear()
        txtSulfurMax.Clear()
        txtSulfurMin.Clear()
        txtTinMax.Clear()
        txtTinMin.Clear()
        txtTitaniumMax.Clear()
        txtTitaniumMin.Clear()
        txtVanadiumMax.Clear()
        txtVanadiumMin.Clear()
        txtZincMax.Clear()
        txtZincMin.Clear()
        txtTungstenMax.Clear()
        txtTungstenMin.Clear()
        txtMagnesiumMin.Clear()
        txtMagnesiumMax.Clear()

        cboSteelAlloy.Focus()
    End Sub

    Private Sub cboSteelAlloy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelAlloy.SelectedIndexChanged
        LoadSteelTolerances()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveToolStripMenuItem.Click
        'Check to see if Alloy Field is present
        If String.IsNullOrEmpty(cboSteelAlloy.Text) Then
            MsgBox("You must have a valid Steel Alloy selected.", MsgBoxStyle.OkOnly)
        Else
            'Write to Steel Tolerances Table
            cmd = New SqlCommand("IF EXISTS(SELECT Alloy FROM SteelChemistryTolerances WHERE Alloy = @Alloy)" _
                                 + " UPDATE SteelChemistryTolerances SET CarbonMinimum = @CarbonMinimum, CarbonMaximum = @CarbonMaximum, ManganeseMinimum = @ManganeseMinimum, ManganeseMaximum = @ManganeseMaximum, PhosphorusMinimum = @PhosphorusMinimum, PhosphorusMaximum = @PhosphorusMaximum, SulfurMinimum = @SulfurMinimum, SulfurMaximum = @SulfurMaximum, SiliconMinimum = @SiliconMinimum, SiliconMaximum = @SiliconMaximum, CopperMinimum = @CopperMinimum, CopperMaximum = @CopperMaximum, NickelMinimum = @NickelMinimum, NickelMaximum = @NickelMaximum, ChromiumMinimum = @ChromiumMinimum, ChromiumMaximum = @ChromiumMaximum, MolybdenumMinimum = @MolybdenumMinimum, MolybdenumMaximum = @MolybdenumMaximum, TinMinimum = @TinMinimum, TinMaximum = @TinMaximum," _
                                 + " AluminumMinimum = @AluminumMinimum, AluminumMaximum = @AluminumMaximum, NitrogenMinimum = @NitrogenMinimum, NitrogenMaximum = @NitrogenMaximum, VanadiumMinimum = @VanadiumMinimum, VanadiumMaximum = @VanadiumMaximum, BoronMinimum = @BoronMinimum, BoronMaximum = @BoronMaximum, TitaniumMinimum = @TitaniumMinimum, TitaniumMaximum = @TitaniumMaximum, CarbideMinimum = @CarbideMinimum, CarbideMaximum = @CarbideMaximum, CobaltMinimum = @CobaltMinimum, CobaltMaximum = @CobaltMaximum, ZincMinimum = @ZincMinimum, ZincMaximum = @ZincMaximum, IronMinimum = @IronMinimum , IronMaximum = @IronMaximum, LeadMinimum = @LeadMinimum, LeadMaximum = @LeadMaximum, NiobiumMinimum = @NiobiumMinimum, NiobiumMaximum = @NiobiumMaximum, TungstenMinimum = @TungstenMinimum, TungstenMaximum = @TungstenMaximum, MagnesiumMinimum = @MagnesiumMinimum, MagnesiumMaximum = @MagnesiumMaximum WHERE Alloy = @Alloy" _
                                 + " ELSE Insert Into SteelChemistryTolerances(Alloy, CarbonMinimum, CarbonMaximum, ManganeseMinimum, ManganeseMaximum, PhosphorusMinimum, PhosphorusMaximum, SulfurMinimum, SulfurMaximum, SiliconMinimum, SiliconMaximum, CopperMinimum, CopperMaximum, NickelMinimum, NickelMaximum, ChromiumMinimum, ChromiumMaximum, MolybdenumMinimum, MolybdenumMaximum, TinMinimum, TinMaximum, AluminumMinimum, AluminumMaximum, NitrogenMinimum, NitrogenMaximum, VanadiumMinimum, VanadiumMaximum, BoronMinimum, BoronMaximum, TitaniumMinimum, TitaniumMaximum, CarbideMinimum, CarbideMaximum, CobaltMinimum, CobaltMaximum, ZincMinimum, ZincMaximum, IronMinimum, IronMaximum, LeadMinimum, LeadMaximum, NiobiumMinimum, NiobiumMaximum, TungstenMinimum, TungstenMaximum, MagnesiumMinimum, MagnesiumMaximum)" _
                                 + " Values(@Alloy, @CarbonMinimum, @CarbonMaximum, @ManganeseMinimum, @ManganeseMaximum, @PhosphorusMinimum, @PhosphorusMaximum, @SulfurMinimum, @SulfurMaximum, @SiliconMinimum, @SiliconMaximum, @CopperMinimum, @CopperMaximum, @NickelMinimum, @NickelMaximum, @ChromiumMinimum, @ChromiumMaximum, @MolybdenumMinimum, @MolybdenumMaximum, @TinMinimum, @TinMaximum, @AluminumMinimum, @AluminumMaximum, @NitrogenMinimum, @NitrogenMaximum, @VanadiumMinimum, @VanadiumMaximum, @BoronMinimum, @BoronMaximum, @TitaniumMinimum, @TitaniumMaximum, @CarbideMinimum, @CarbideMaximum, @CobaltMinimum, @CobaltMaximum, @ZincMinimum, @ZincMaximum, @IronMinimum, @IronMaximum, @LeadMinimum, @LeadMaximum, @NiobiumMinimum, @NiobiumMaximum, @TungstenMinimum, @TungstenMaximum, @MagnesiumMinimum, @MagnesiumMaximum)", con)
            With cmd.Parameters
                .Add("@Alloy", SqlDbType.VarChar).Value = cboSteelAlloy.Text
                .Add("@CarbonMinimum", SqlDbType.VarChar).Value = Val(txtCarbonMin.Text)
                .Add("@CarbonMaximum", SqlDbType.VarChar).Value = Val(txtCarbonMax.Text)
                .Add("@ManganeseMinimum", SqlDbType.VarChar).Value = Val(txtManganeseMin.Text)
                .Add("@ManganeseMaximum", SqlDbType.VarChar).Value = Val(txtManganeseMax.Text)
                .Add("@PhosphorusMinimum", SqlDbType.VarChar).Value = Val(txtPhosphorusMin.Text)
                .Add("@PhosphorusMaximum", SqlDbType.VarChar).Value = Val(txtPhosphorusMax.Text)
                .Add("@SulfurMinimum", SqlDbType.VarChar).Value = Val(txtSulfurMin.Text)
                .Add("@SulfurMaximum", SqlDbType.VarChar).Value = Val(txtSulfurMax.Text)
                .Add("@SiliconMinimum", SqlDbType.VarChar).Value = Val(txtSiliconMin.Text)
                .Add("@SiliconMaximum", SqlDbType.VarChar).Value = Val(txtSiliconMax.Text)
                .Add("@CopperMinimum", SqlDbType.VarChar).Value = Val(txtCopperMin.Text)
                .Add("@CopperMaximum", SqlDbType.VarChar).Value = Val(txtCopperMax.Text)
                .Add("@NickelMinimum", SqlDbType.VarChar).Value = Val(txtNickelMin.Text)
                .Add("@NickelMaximum", SqlDbType.VarChar).Value = Val(txtNickelMax.Text)
                .Add("@ChromiumMinimum", SqlDbType.VarChar).Value = Val(txtChromiumMin.Text)
                .Add("@ChromiumMaximum", SqlDbType.VarChar).Value = Val(txtChromiumMax.Text)
                .Add("@MolybdenumMinimum", SqlDbType.VarChar).Value = Val(txtMolybdenumMin.Text)
                .Add("@MolybdenumMaximum", SqlDbType.VarChar).Value = Val(txtMolybdenumMax.Text)
                .Add("@TinMinimum", SqlDbType.VarChar).Value = Val(txtTinMin.Text)
                .Add("@TinMaximum", SqlDbType.VarChar).Value = Val(txtTinMax.Text)
                .Add("@AluminumMinimum", SqlDbType.VarChar).Value = Val(txtAluminumMin.Text)
                .Add("@AluminumMaximum", SqlDbType.VarChar).Value = Val(txtAluminumMax.Text)
                .Add("@NitrogenMinimum", SqlDbType.VarChar).Value = Val(txtNitrogenMin.Text)
                .Add("@NitrogenMaximum", SqlDbType.VarChar).Value = Val(txtNitrogenMax.Text)
                .Add("@VanadiumMinimum", SqlDbType.VarChar).Value = Val(txtVanadiumMin.Text)
                .Add("@VanadiumMaximum", SqlDbType.VarChar).Value = Val(txtVanadiumMax.Text)
                .Add("@BoronMinimum", SqlDbType.VarChar).Value = Val(txtBoronMin.Text)
                .Add("@BoronMaximum", SqlDbType.VarChar).Value = Val(txtBoronMax.Text)
                .Add("@TitaniumMinimum", SqlDbType.VarChar).Value = Val(txtTitaniumMin.Text)
                .Add("@TitaniumMaximum", SqlDbType.VarChar).Value = Val(txtTitaniumMax.Text)
                .Add("@CarbideMinimum", SqlDbType.VarChar).Value = Val(txtCarbideMin.Text)
                .Add("@CarbideMaximum", SqlDbType.VarChar).Value = Val(txtCarbideMax.Text)
                .Add("@CobaltMinimum", SqlDbType.VarChar).Value = Val(txtCobaltMin.Text)
                .Add("@CobaltMaximum", SqlDbType.VarChar).Value = Val(txtCobaltMax.Text)
                .Add("@ZincMinimum", SqlDbType.VarChar).Value = Val(txtZincMin.Text)
                .Add("@ZincMaximum", SqlDbType.VarChar).Value = Val(txtZincMax.Text)
                .Add("@IronMinimum", SqlDbType.VarChar).Value = Val(txtIronMin.Text)
                .Add("@IronMaximum", SqlDbType.VarChar).Value = Val(txtIronMax.Text)
                .Add("@LeadMinimum", SqlDbType.VarChar).Value = Val(txtLeadMin.Text)
                .Add("@LeadMaximum", SqlDbType.VarChar).Value = Val(txtLeadMax.Text)
                .Add("@NiobiumMinimum", SqlDbType.VarChar).Value = Val(txtNiobiumMin.Text)
                .Add("@NiobiumMaximum", SqlDbType.VarChar).Value = Val(txtNiobiumMax.Text)
                .Add("@TungstenMinimum", SqlDbType.VarChar).Value = Val(txtTungstenMin.Text)
                .Add("@TungstenMaximum", SqlDbType.VarChar).Value = Val(txtTungstenMax.Text)
                .Add("@MagnesiumMinimum", SqlDbType.VarChar).Value = Val(txtMagnesiumMin.Text)
                .Add("@MagnesiumMaximum", SqlDbType.VarChar).Value = Val(txtMagnesiumMax.Text)
            End With
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                sendErrorToDataBase("SteelTolerances - cmdSave --Error inserting or updating steel alloy", "Alloy " + cboSteelAlloy.Text, ex.ToString)
            End Try

        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Steel Alloy?", "DELETE STEEL ALLOY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Delete Record From Steel Tolerances Table
            cmd = New SqlCommand("DELETE FROM SteelChemistryTolerances WHERE Alloy = @Alloy", con)
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = cboSteelAlloy.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearAll()
            MsgBox("Steel Alloy has been deleted.", MsgBoxStyle.OkOnly)
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Steel Alloy?", "DELETE STEEL ALLOY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Delete Record From Steel Tolerances Table
            cmd = New SqlCommand("DELETE FROM SteelChemistryTolerances WHERE Alloy = @Alloy", con)
            cmd.Parameters.Add("@Alloy", SqlDbType.VarChar).Value = cboSteelAlloy.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearAll()
            MsgBox("Steel Alloy has been deleted.", MsgBoxStyle.OkOnly)
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
        End If
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearAll()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearAll()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
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

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCarbonMin.KeyPress, txtCarbonMax.KeyPress, txtAluminumMax.KeyPress, txtAluminumMin.KeyPress, txtBoronMax.KeyPress, txtBoronMin.KeyPress, txtCarbideMax.KeyPress, txtCarbideMin.KeyPress, txtChromiumMax.KeyPress, txtChromiumMin.KeyPress, txtCobaltMax.KeyPress, txtCobaltMin.KeyPress, txtCopperMax.KeyPress, txtCopperMin.KeyPress, txtIronMax.KeyPress, txtIronMin.KeyPress, txtLeadMax.KeyPress, txtLeadMin.KeyPress, txtManganeseMax.KeyPress, txtManganeseMin.KeyPress, txtMolybdenumMax.KeyPress, txtMolybdenumMin.KeyPress, txtNickelMax.KeyPress, txtNickelMin.KeyPress, txtNiobiumMax.KeyPress, txtNiobiumMin.KeyPress, txtNitrogenMax.KeyPress, txtNitrogenMin.KeyPress, txtPhosphorusMax.KeyPress, txtPhosphorusMin.KeyPress, txtSiliconMax.KeyPress, txtSiliconMin.KeyPress, txtSulfurMax.KeyPress, txtSulfurMin.KeyPress, txtTinMax.KeyPress, txtTinMin.KeyPress, txtTungstenMax.KeyPress, txtTungstenMin.KeyPress, txtVanadiumMax.KeyPress, txtVanadiumMin.KeyPress, txtZincMax.KeyPress, txtZincMin.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If e.KeyChar = "."c AndAlso txt.Text.Contains(".") Then
            e.Handled = True
            e.KeyChar = Nothing
        ElseIf Not IsNumeric(e.KeyChar) AndAlso Not isControlKey Then
            e.Handled = True
            e.KeyChar = Nothing
        End If
        isControlKey = False
    End Sub

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarbonMin.KeyDown, txtCarbonMax.KeyDown, txtAluminumMax.KeyDown, txtAluminumMin.KeyDown, txtBoronMax.KeyDown, txtBoronMin.KeyDown, txtCarbideMax.KeyDown, txtCarbideMin.KeyDown, txtChromiumMax.KeyDown, txtChromiumMin.KeyDown, txtCobaltMax.KeyDown, txtCobaltMin.KeyDown, txtCopperMax.KeyDown, txtCopperMin.KeyDown, txtIronMax.KeyDown, txtIronMin.KeyDown, txtLeadMax.KeyDown, txtLeadMin.KeyDown, txtManganeseMax.KeyDown, txtManganeseMin.KeyDown, txtMolybdenumMax.KeyDown, txtMolybdenumMin.KeyDown, txtNickelMax.KeyDown, txtNickelMin.KeyDown, txtNiobiumMax.KeyDown, txtNiobiumMin.KeyDown, txtNitrogenMax.KeyDown, txtNitrogenMin.KeyDown, txtPhosphorusMax.KeyDown, txtPhosphorusMin.KeyDown, txtSiliconMax.KeyDown, txtSiliconMin.KeyDown, txtSulfurMax.KeyDown, txtSulfurMin.KeyDown, txtTinMax.KeyDown, txtTinMin.KeyDown, txtTungstenMax.KeyDown, txtTungstenMin.KeyDown, txtVanadiumMax.KeyDown, txtVanadiumMin.KeyDown, txtZincMax.KeyDown, txtZincMin.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.Back Then
            isControlKey = True
        End If
    End Sub
End Class