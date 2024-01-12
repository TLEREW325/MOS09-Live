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
Public Class TFPQuoteForm
    Const pi As Double = 3.14159
    Dim PassedQuote As String = ""
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet

    Dim ManualRevisionChange As Boolean = False
    Dim isloaded As Boolean = False
    Dim needsSaved As Boolean = False
    Dim shouldSave As Boolean = False
    Dim loadingData As Boolean = False
    Dim headerChanged As Boolean = False
    Dim saltSprayChanged As Boolean = False
    Dim QCList As New List(Of OperationData)

    Private Class ctrl
        Public name As String
        Public total As Double
        Public Sub New()
            name = ""
            total = 0
        End Sub
        Public Sub New(ByVal nm As String, ByVal tot As Double)
            name = nm
            total = tot
        End Sub
    End Class

    ''needed for the Operational data
    Private Class OperationData
        Public key As Integer = 0
        Public MachineType As String = ""
        Public MachineCost As Double = 0
        Public SetupCost As Double = 0
        Public times As Integer = 0
        Public Sub New()
        End Sub

        Public Sub New(ByVal ky As Integer, ByVal name As String, ByVal cst As Double, ByVal setup As Double, ByVal tim As Integer)
            MachineType = name
            MachineCost = cst
            SetupCost = setup
            key = ky
            times = tim
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
        LoadQuoteNumbers()
        LoadDivisionID()
        clearDataGrids()
        isloaded = True
        txtPreparedBy.Text = EmployeeLoginName
        cboDivisionID.Text = EmployeeCompanyCode
        AddControlHandlers()
    End Sub

    Public Sub New(ByVal qte As String)
        InitializeComponent()
        LoadQuoteNumbers()
        LoadDivisionID()
        clearDataGrids()
        isloaded = True
        txtPreparedBy.Text = EmployeeLoginName
        cboDivisionID.Text = EmployeeCompanyCode
        PassedQuote = qte
        cboQuoteNumber.Text = PassedQuote
        AddControlHandlers()
    End Sub

    Private Sub LoadQuoteNumbers()
        cmd = New SqlCommand("SELECT QuoteID FROM Quotation WHERE DivisionID = @DivisionID ORDER BY QuoteID DESC;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "Quotation")
        con.Close()

        cboQuoteNumber.DisplayMember = "QuoteID"
        cboQuoteNumber.DataSource = ds.Tables("Quotation")
        cboQuoteNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerIDName()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "CustomerList")
        con.Close()

        cboCustomerID.DisplayMember = "CustomerID"
        cboCustomerName.DisplayMember = "CustomerName"
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        cboCustomerName.DataSource = ds1.Tables("CustomerList")
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub LoadDivisionID()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable;", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "DivisionTable")
        con.Close()

        cboDivisionID.DisplayMember = "DivisionKey"
        cboDivisionID.DataSource = ds2.Tables("DivisionTable")
        cboDivisionID.SelectedIndex = -1
    End Sub

    Private Sub LoadQuoteData()
        cmd = New SqlCommand("SELECT * FROM Quotation LEFT OUTER JOIN QuoteOperations ON Quotation.QuoteID = QuoteOperations.QuoteID WHERE Quotation.QuoteID = @QuoteID;", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "temp")
        con.Close()

        If IsDBNull(tempds.Tables("temp").Rows(0).Item("RevisionLevel")) Then
            txtQuoteRevisionLevel.Text = ""
        Else
            txtQuoteRevisionLevel.Text = tempds.Tables("temp").Rows(0).Item("RevisionLevel")
        End If
        If IsDBNull(tempds.Tables("temp").Rows(0).Item("ReferenceQuoteNumber")) Then
            txtReferenceQuoteNumber.Text = ""
        Else
            txtReferenceQuoteNumber.Text = tempds.Tables("temp").Rows(0).Item("ReferenceQuoteNumber")
        End If
        If IsDBNull(tempds.Tables("temp").Rows(0).Item("CellPhoneNumber")) Then
            txtMobileNumber.Text = ""
        Else
            txtMobileNumber.Text = tempds.Tables("temp").Rows(0).Item("CellPhoneNumber")
        End If

        dtpQuoteDate.Value = tempds.Tables("temp").Rows(0).Item("QuoteDate")
        txtPreparedBy.Text = tempds.Tables("temp").Rows(0).Item("Preparer")
        cboCustomerID.Text = tempds.Tables("temp").Rows(0).Item("CustomerID")
        cboCustomerName.Text = tempds.Tables("temp").Rows(0).Item("CustomerName")
        txtContactName.Text = tempds.Tables("temp").Rows(0).Item("ContactName")
        txtPhone.Text = tempds.Tables("temp").Rows(0).Item("Phone")
        txtPhoneExtension.Text = tempds.Tables("temp").Rows(0).Item("Extension")
        txtFax.Text = tempds.Tables("temp").Rows(0).Item("Fax")
        txtEmail.Text = tempds.Tables("temp").Rows(0).Item("Email")
        txtCustPartNo.Text = tempds.Tables("temp").Rows(0).Item("CustPartNo")
        txtTFPPartNo.Text = tempds.Tables("temp").Rows(0).Item("TFPPartNo")
        txtPartDescription.Text = tempds.Tables("temp").Rows(0).Item("PartDescription")
        txtPartSize.Text = tempds.Tables("temp").Rows(0).Item("PartSize")
        txtNotes.Text = tempds.Tables("temp").Rows(0).Item("NotesComments")
        txtCustomerInqueryNumber.Text = tempds.Tables("temp").Rows(0).Item("CustomerInqueryNumber")
        txtRepAgency.Text = tempds.Tables("temp").Rows(0).Item("RepAgency")
        cboRFQSource.Text = tempds.Tables("temp").Rows(0).Item("RFQSource")

        If IsDBNull(tempds.Tables("temp").Rows(0).Item("InternalNotes")) Then
            txtInternalNotes.Text = ""
        Else
            txtInternalNotes.Text = tempds.Tables("temp").Rows(0).Item("InternalNotes")
        End If

        ''Primary Machining Tab
        If IsDBNull(tempds.Tables("temp").Rows(0).Item("Header")) Then
            Exit Sub
        End If

        Select Case tempds.Tables("temp").Rows(0).Item("Header").ToString()
            Case "None"
                rdoHeaderNone.Checked = True
            Case "Header Nos. 10,11"
                rdoHeader1011.Checked = True
            Case "Header Nos. 109,112"
                rdoHeader104109112.Checked = True
            Case "Header Nos. 12,21"
                rdoHeader1221.Checked = True
            Case "Header Nos. 1,3,7,8,14"
                rdoHeader137814.Checked = True
            Case "Header Nos. 18,19,22"
                rdoHeader1819.Checked = True
            Case "Header Nos. 20"
                rdoHeader20.Checked = True
            Case "Header Nos. 6,9"
                rdoHeader46917.Checked = True
            Case "Header Nos. 5"
                rdoHeader5.Checked = True
            Case "Debar 98,99"
                rdoHeader9899.Checked = True
            Case Else
                rdoHeaderNone.Checked = True
        End Select

        nbrExtrude.Value = tempds.Tables("temp").Rows(0).Item("Extrude")
        nbrTrim.Value = tempds.Tables("temp").Rows(0).Item("Trim")
        nbrPoint.Value = tempds.Tables("temp").Rows(0).Item("Point")
        nbrThreadCut.Value = tempds.Tables("temp").Rows(0).Item("ThreadCut")
        nbrSlot.Value = tempds.Tables("temp").Rows(0).Item("Slot")
        nbrHandSlot.Value = tempds.Tables("temp").Rows(0).Item("HandSlot")
        nbrShave.Value = tempds.Tables("temp").Rows(0).Item("Shave")
        nbrPunchPress.Value = tempds.Tables("temp").Rows(0).Item("PunchPress")
        nbrCenterless.Value = tempds.Tables("temp").Rows(0).Item("Centerless")
        nbrHotFormer.Value = tempds.Tables("temp").Rows(0).Item("HotFormer")
        nbrNo10Slow.Value = tempds.Tables("temp").Rows(0).Item("Roll10Slow")
        nbrNo20H20.Value = tempds.Tables("temp").Rows(0).Item("RollH20")
        nbrNo360H60.Value = tempds.Tables("temp").Rows(0).Item("RollH60")
        nbrNo40.Value = tempds.Tables("temp").Rows(0).Item("Roll40")
        nbrHandRoll.Value = tempds.Tables("temp").Rows(0).Item("RollHand")
        nbrHandRollNo50.Value = tempds.Tables("temp").Rows(0).Item("RollHand50")
        nbrReed.Value = tempds.Tables("temp").Rows(0).Item("RollReed")
        nbrBoltMaker.Value = tempds.Tables("temp").Rows(0).Item("RollBoltMaker")
        nbrFlatRoll.Value = tempds.Tables("temp").Rows(0).Item("RollFlat")
        nbrDrilling.Value = tempds.Tables("temp").Rows(0).Item("Drilling")
        nbrCounterSink.Value = tempds.Tables("temp").Rows(0).Item("CounterSink")
        nbrShotPeen.Value = tempds.Tables("temp").Rows(0).Item("ShotPeen")
        nbrLatheWork.Value = tempds.Tables("temp").Rows(0).Item("LatheWork")
        nbrMazakLathe.Value = tempds.Tables("temp").Rows(0).Item("MazakLathe")
        nbrMazakMill.Value = tempds.Tables("temp").Rows(0).Item("MazakMill")
        nbrGrinding.Value = tempds.Tables("temp").Rows(0).Item("Grinding")
        nbrTapping.Value = tempds.Tables("temp").Rows(0).Item("Tapping")
        nbrBarFeed.Value = tempds.Tables("temp").Rows(0).Item("BarFeed")
        nbrHaasMill.Value = tempds.Tables("temp").Rows(0).Item("HaasMill")
        nbrHaasMiniMill.Value = tempds.Tables("temp").Rows(0).Item("HaasMiniMill")
        ''Weight Operations Tab
        chkWireCleaning.Checked = CBool(tempds.Tables("temp").Rows(0).Item("WireClean"))
        chkTumbleAndWash.Checked = CBool(tempds.Tables("temp").Rows(0).Item("TumbleWash"))
        chkAnneal.Checked = CBool(tempds.Tables("temp").Rows(0).Item("Anneal"))
        chkZincPlating.Checked = CBool(tempds.Tables("temp").Rows(0).Item("ZincPlating"))
        chkPicklePlate.Checked = CBool(tempds.Tables("temp").Rows(0).Item("PicklePlating"))
        chkNickelPlating.Checked = CBool(tempds.Tables("temp").Rows(0).Item("NickelPlating"))
        chkBake.Checked = CBool(tempds.Tables("temp").Rows(0).Item("Bake"))
        chkHeatTreat.Checked = CBool(tempds.Tables("temp").Rows(0).Item("HeatTreat"))
        chkCaseHardening.Checked = CBool(tempds.Tables("temp").Rows(0).Item("CaseHarden"))
        chkOutsideHeatTreatOrPlating.Checked = CBool(tempds.Tables("temp").Rows(0).Item("OutsideHTorPlate"))
        chkPhosphateAndOil.Checked = CBool(tempds.Tables("temp").Rows(0).Item("Phosphate"))

        Select Case tempds.Tables("temp").Rows(0).Item("MaterialType")
            Case "C1010ToC1018"
                rdoC1010ToC1018.Checked = True
            Case "C1010ToC1018Annealed"
                rdoC1010ToC1018Annealed.Checked = True
            Case "Alloy"
                rdoAlloy.Checked = True
            Case "Rebar"
                rdoRebar.Checked = True
            Case "Stainless"
                rdoStainless.Checked = True
            Case Else
                rdoSpecialMaterial.Checked = True
                txtSpecialMaterialType.Text = tempds.Tables("temp").Rows(0).Item("MaterialType")
        End Select

        txtMaterialCostPer.Text = tempds.Tables("temp").Rows(0).Item("MaterialCost")
        txtToolingCharge.Text = tempds.Tables("temp").Rows(0).Item("ToolingCharge")
        txtSetupCharge.Text = tempds.Tables("temp").Rows(0).Item("SetupCharge")

        Select Case tempds.Tables("temp").Rows(0).Item("DensityType")
            Case 0
                rdoSteel.Checked = True
            Case 1
                rdoAluminum.Checked = True
            Case 2
                rdoCopper.Checked = True
            Case 3
                rdoFreeCutBrass.Checked = True
            Case 4
                rdoNavalBrass.Checked = True
            Case 5
                rdoBronze.Checked = True
            Case Else
                rdoSteel.Checked = True
        End Select

        ''Weight Calculator Tab
        Select Case tempds.Tables("temp").Rows(0).Item("DimensionUnits")
            Case 1
                rdoStandard.Checked = True
            Case 2
                rdoMetric.Checked = True
            Case Else
                rdoStandard.Checked = True
        End Select

        txtStartWeight.Text = tempds.Tables("temp").Rows(0).Item("WtPerM")
        txtScrapPercent.Text = tempds.Tables("temp").Rows(0).Item("ScrapPercent")

        ''QC/QA Tab
        Select Case True
            Case (tempds.Tables("temp").Rows(0).Item("SaltSpray") = 0)
                rdoSaltSprayNone.Checked = True
            Case (tempds.Tables("temp").Rows(0).Item("SaltSpray") = 24)
                rdo24Hours.Checked = True
            Case (tempds.Tables("temp").Rows(0).Item("SaltSpray") = 48)
                rdo48Hours.Checked = True
            Case (tempds.Tables("temp").Rows(0).Item("SaltSpray") = 72)
                rdo72Hours.Checked = True
            Case (tempds.Tables("temp").Rows(0).Item("SaltSpray") = 96)
                rdo96Hours.Checked = True
            Case (tempds.Tables("temp").Rows(0).Item("SaltSpray") = 120)
                rdo120Hours.Checked = True
            Case (tempds.Tables("temp").Rows(0).Item("SaltSpray") = 168)
                rdo168Hours.Checked = True
        End Select

        nbrSaltSprayQuantity.Value = tempds.Tables("temp").Rows(0).Item("SaltSprayQuantity")
        nbrSaltSprayAdditionalHours.Value = tempds.Tables("temp").Rows(0).Item("AdditionalSaltSpray")

        nbrSurfaceandCore.Value = tempds.Tables("temp").Rows(0).Item("SurfaceCore")
        nbrMicroCaseDepth.Value = tempds.Tables("temp").Rows(0).Item("MicroCaseDepth")
        nbrMicroDecarb.Value = tempds.Tables("temp").Rows(0).Item("MicroDecarb")
        nbrFurnaceChartCopy.Value = tempds.Tables("temp").Rows(0).Item("FurnaceChartCopy")
        chk5SpecimenMax.Checked = CBool(tempds.Tables("temp").Rows(0).Item("Tensile5Specimen"))
        nbrAdditionalSpecimen.Value = tempds.Tables("temp").Rows(0).Item("AdditionalTensile")
        nbrWedgeBendShear.Value = tempds.Tables("temp").Rows(0).Item("WedgeBandShear")
        nbrTWDTensile.Value = tempds.Tables("temp").Rows(0).Item("TruWeldTensile")
        nbrCertificateOfCompliance.Value = tempds.Tables("temp").Rows(0).Item("CertCompliance")
        nbrNylonPatch.Value = tempds.Tables("temp").Rows(0).Item("NylonPatch")
        nbrChemistry.Value = tempds.Tables("temp").Rows(0).Item("Chemistry")
        nbrMillCertification.Value = tempds.Tables("temp").Rows(0).Item("MillCert")
        nbrCertificationRequired.Value = tempds.Tables("temp").Rows(0).Item("CertRequired")
        nbrSamplesRequired.Value = tempds.Tables("temp").Rows(0).Item("SampleRequired")
        nbrSPCRequired.Value = tempds.Tables("temp").Rows(0).Item("SPCRequired")
        nbrDimensional.Value = tempds.Tables("temp").Rows(0).Item("Dimensional")
        nbrPlating.Value = tempds.Tables("temp").Rows(0).Item("Plating")
        nbrMagParticle.Value = tempds.Tables("temp").Rows(0).Item("MagParticle")
        nbrISIR.Value = tempds.Tables("temp").Rows(0).Item("ISIR")
        nbrPPap.Value = tempds.Tables("temp").Rows(0).Item("PPap")
        txtDeliveryRequirements.Text = tempds.Tables("temp").Rows(0).Item("DeliveryRequirements")
        chkOutsideHTCertification.Checked = CBool(tempds.Tables("temp").Rows(0).Item("OutsideHTCertification"))
        shouldSave = False
    End Sub

    Private Sub LoadMarkupData()
        dgvMarkupQuotes.Rows.Clear()
        dgvMarkupQuotes.Columns.Clear()

        cmd = New SqlCommand("SELECT * FROM QuoteMarkup WHERE QuoteID = @QuoteID ORDER BY QuoteID,QuoteNumber ASC;", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "QuoteMarkup")
        con.Close()

        Dim quoteNum As Integer = ds3.Tables("QuoteMarkup").Rows.Count - 1
        Dim values(8, ds3.Tables("QuoteMarkup").Rows.Count) As Double
        Dim rwVal(ds3.Tables("QuoteMarkup").Rows.Count) As String
        dgvMarkupQuotes.Columns.Add("Labels", " ")

        For i As Integer = 0 To quoteNum
            dgvMarkupQuotes.Columns.Add(ds3.Tables("QuoteMarkup").Rows(i).Item("QuoteNumber").ToString(), ds3.Tables("QuoteMarkup").Rows(i).Item("QuoteNumber").ToString())
            dgvMarkupQuotes.Columns(dgvMarkupQuotes.Columns.Count - 1).MinimumWidth = 75
            values(0, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("Quantity")
            values(1, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("Production")
            values(2, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("Tools")
            values(3, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("Setup")
            values(4, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("QualityControl")
            values(5, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("Total")
            values(6, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("Markup")
            values(7, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("QuoteTotal")
            If IsDBNull(ds3.Tables("QuoteMarkup").Rows(i).Item("ManualTool")) Then
                values(8, i) = 0
            Else
                values(8, i) = ds3.Tables("QuoteMarkup").Rows(i).Item("ManualTool")
            End If
        Next

        For i As Integer = 0 To 8
            Select Case i
                Case 0
                    rwVal(0) = "Quantity"
                Case 1
                    rwVal(0) = "Production"
                Case 2
                    rwVal(0) = "Tools"
                Case 3
                    rwVal(0) = "Setup"
                Case 4
                    rwVal(0) = "QualityControl"
                Case 5
                    rwVal(0) = "Total"
                Case 6
                    rwVal(0) = "Markup"
                Case 7
                    rwVal(0) = "QuoteTotal"
                Case 8
                    rwVal(0) = "ManualTool"
            End Select

            For j As Integer = 0 To quoteNum
                If i = 8 And values(i, j) = 0 Then
                    rwVal(j + 1) = ""
                Else
                    rwVal(j + 1) = values(i, j).ToString()
                End If
            Next
            dgvMarkupQuotes.Rows.Add(rwVal)
            dgvMarkupQuotes.Rows(dgvMarkupQuotes.Rows.Count - 1).MinimumHeight = 35
            dgvMarkupQuotes.Rows(dgvMarkupQuotes.Rows.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        setupMarkupQuotes()
    End Sub

    Private Sub setupMarkupQuotes()
        If dgvMarkupQuotes.Columns.Count = 0 Then
            dgvMarkupQuotes.Columns.Add("Labels", " ")
            dgvMarkupQuotes.Rows.Add("Quantity")
            dgvMarkupQuotes.Rows.Add("Production")
            dgvMarkupQuotes.Rows.Add("Tools")
            dgvMarkupQuotes.Rows.Add("Setup")
            dgvMarkupQuotes.Rows.Add("QualityControl", "Quality Control")
            dgvMarkupQuotes.Rows.Add("Total")
            dgvMarkupQuotes.Rows.Add("Markup")
            dgvMarkupQuotes.Rows.Add("QuoteTotal", "Quote Total")
            dgvMarkupQuotes.Rows.Add("ManualTool", "Manual Tool")
        End If
        dgvMarkupQuotes.Columns(0).DefaultCellStyle.BackColor = Me.BackColor
        dgvMarkupQuotes.Columns(0).Frozen = True
        dgvMarkupQuotes.Rows(0).Cells(0).ReadOnly = True
        dgvMarkupQuotes.Rows(1).Cells(0).ReadOnly = True
        dgvMarkupQuotes.Rows(2).Cells(0).ReadOnly = True
        dgvMarkupQuotes.Rows(3).Cells(0).ReadOnly = True
        dgvMarkupQuotes.Rows(4).Cells(0).ReadOnly = True
        dgvMarkupQuotes.Rows(5).Cells(0).ReadOnly = True
        dgvMarkupQuotes.Rows(6).Cells(0).ReadOnly = True
        For i As Integer = 1 To dgvMarkupQuotes.Columns.Count - 1
            dgvMarkupQuotes.Rows(1).Cells(i).ReadOnly = True
            dgvMarkupQuotes.Rows(1).Cells(i).Style.BackColor = Me.BackColor
            dgvMarkupQuotes.Rows(2).Cells(i).ReadOnly = True
            dgvMarkupQuotes.Rows(2).Cells(i).Style.BackColor = Me.BackColor
            dgvMarkupQuotes.Rows(3).Cells(i).ReadOnly = True
            dgvMarkupQuotes.Rows(3).Cells(i).Style.BackColor = Me.BackColor
            dgvMarkupQuotes.Rows(4).Cells(i).ReadOnly = True
            dgvMarkupQuotes.Rows(4).Cells(i).Style.BackColor = Me.BackColor
            dgvMarkupQuotes.Rows(5).Cells(i).ReadOnly = True
            dgvMarkupQuotes.Rows(5).Cells(i).Style.BackColor = Me.BackColor
        Next
    End Sub

    Private Sub LoadSegmentData()
        cmd = New SqlCommand("SELECT * FROM QuoteSegments WHERE QuoteID = @QuoteID ORDER BY DimNumber ASC;", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "QuoteSegments")
        con.Close()
        isloaded = False
        dgvSegments.DataSource = ds4.Tables("QuoteSegments")
        setupSegments()
        isloaded = True
    End Sub

    Private Sub setupSegments()
        dgvSegments.Columns("QuoteID").Visible = False
        dgvSegments.Columns("DimNumber").Visible = False
        dgvSegments.Columns("SegShape").HeaderText = "Shape"
        dgvSegments.Columns("Trim").Width = 30
        dgvSegments.Columns("Trim").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSegments.Columns("SegWt").ReadOnly = True
        dgvSegments.Columns("Dim1").Width = 60
        dgvSegments.Columns("Dim1").HeaderText = "Diameter"
        dgvSegments.Columns("Dim1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSegments.Columns("Dim2").Width = 60
        dgvSegments.Columns("Dim2").HeaderText = "Length"
        dgvSegments.Columns("Dim2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSegments.Columns("Dim3").Width = 60
        dgvSegments.Columns("Dim3").HeaderText = "N/A"
        dgvSegments.Columns("Dim3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSegments.Columns("SegWt").Width = 75
        dgvSegments.Columns("SegWt").HeaderText = "Segment Weight"

        For i As Integer = 0 To dgvSegments.Rows.Count - 1
            Dim viewcbo As New DataGridViewComboBoxCell
            Dim viewchk As New DataGridViewCheckBoxCell
            With viewcbo
                .Items.AddRange("None", "Round", "Hex", "Square", "Penta", "Carriage", "Rectangular", "Known Weight", "Remove Mat.")
            End With
            viewcbo.Value = dgvSegments.Rows(i).Cells("SegShape").Value
            viewchk.Value = CBool(dgvSegments.Rows(i).Cells("Trim").Value)
            dgvSegments.Rows(i).Cells("SegShape") = viewcbo
            dgvSegments.Rows(i).Cells("Trim") = viewchk
        Next
    End Sub

    Private Sub LoadOtherData()
        cmd = New SqlCommand("SELECT OtherNumber, isnull(Description, '') as Description, Cost, UnitType, Outside FROM QuoteOther WHERE QuoteID = @QuoteID ORDER BY OtherNumber ASC;", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "QuoteOther")
        con.Close()

        dgvOtherOperations.DataSource = ds5.Tables("QuoteOther")
        setupdgvOther()
        totaldgvOther()
    End Sub

    Private Sub setupdgvOther()
        dgvOtherOperations.Columns("OtherNumber").Visible = False
        dgvOtherOperations.Columns("Description").MinimumWidth = 200
        dgvOtherOperations.Columns("Cost").MinimumWidth = 30
        dgvOtherOperations.Columns("Cost").Width = 50
        dgvOtherOperations.Columns("UnitType").MinimumWidth = 50
        dgvOtherOperations.Columns("UnitType").HeaderText = "Unit Type"
        dgvOtherOperations.Columns("Outside").MinimumWidth = 20
        dgvOtherOperations.Columns("Outside").Width = 50
        dgvOtherOperations.Columns("Outside").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        For i As Integer = 0 To dgvOtherOperations.Rows.Count - 1
            Dim viewcbo As New DataGridViewComboBoxCell
            Dim chkbx As New DataGridViewCheckBoxCell
            With viewcbo
                .Items.AddRange("CWT", "Per/M")
            End With
            viewcbo.Value = dgvOtherOperations.Rows(i).Cells("UnitType").Value
            If Not IsDBNull(dgvOtherOperations.Rows(i).Cells("Outside").Value) Then
                chkbx.Value = Convert.ToBoolean(dgvOtherOperations.Rows(i).Cells("Outside").Value.ToString())
            End If

            dgvOtherOperations.Rows(i).Cells("UnitType") = viewcbo
            dgvOtherOperations.Rows(i).Cells("Outside") = chkbx

        Next
    End Sub

    Private Sub totaldgvOther()
        Dim total As Double = 0
        For i As Integer = 0 To dgvOtherOperations.Rows.Count - 1
            If Not Convert.ToBoolean(dgvOtherOperations.Rows(i).Cells("Outside").Value) Then
                Dim cst As Double = dgvOtherOperations.Rows(i).Cells("Cost").Value
                Dim otherNumb As Integer = dgvOtherOperations.Rows(i).Cells("OtherNumber").Value

                If dgvOtherOperations.Rows(i).Cells("UnitType").Value.Equals("CWT") Then
                    total += Math.Round(dgvOtherOperations.Rows(i).Cells("Cost").Value / 100 * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)), 2)
                    UpdateAddToList(1000 + dgvOtherOperations.Rows(i).Cells("OtherNumber").Value, 1, New OperationData(1000 + dgvOtherOperations.Rows(i).Cells("OtherNumber").Value, dgvOtherOperations.Rows(i).Cells("Description").Value, dgvOtherOperations.Rows(i).Cells("Cost").Value / 100 * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)), 0, 0))
                Else
                    total += dgvOtherOperations.Rows(i).Cells("Cost").Value
                    UpdateAddToList(1000 + dgvOtherOperations.Rows(i).Cells("OtherNumber").Value, 1, New OperationData(1000 + dgvOtherOperations.Rows(i).Cells("OtherNumber").Value, dgvOtherOperations.Rows(i).Cells("Description").Value, dgvOtherOperations.Rows(i).Cells("Cost").Value, 0, 0))
                End If
            Else
                UpdateAddToList(1000 + dgvOtherOperations.Rows(i).Cells("OtherNumber").Value, 0, New OperationData(1000 + dgvOtherOperations.Rows(i).Cells("OtherNumber").Value, dgvOtherOperations.Rows(i).Cells("Description").Value, dgvOtherOperations.Rows(i).Cells("Cost").Value, 0, 0))
            End If
        Next
        txtOtherOperationTotal.Text = Math.Round(total, 2).ToString()
    End Sub

    Private Sub ClearAll()
        cboQuoteNumber.SelectedIndex = -1
        txtQuoteRevisionLevel.Clear()
        txtReferenceQuoteNumber.Text = ""
        dtpQuoteDate.Value = Today.Date
        txtPreparedBy.Text = EmployeeLoginName
        cboCustomerID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cboCustomerID.Text = ""
        End If
        cboCustomerName.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        txtContactName.Clear()
        txtPhone.Clear()
        txtPhoneExtension.Clear()
        txtFax.Clear()
        txtEmail.Clear()
        txtCustPartNo.Clear()
        txtTFPPartNo.Clear()
        txtPartDescription.Clear()
        txtPartSize.Clear()
        txtCustomerInqueryNumber.Clear()
        txtRepAgency.Clear()
        txtMobileNumber.Clear()
        cboRFQSource.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboRFQSource.Text) Then
            cboRFQSource.Text = ""
        End If
        txtNotes.Clear()
        txtInternalNotes.Clear()
        ''Primary Machining Tab
        rdoHeader1011.Checked = False
        rdoHeader104109112.Checked = False
        rdoHeader1221.Checked = False
        rdoHeader137814.Checked = False
        rdoHeader1819.Checked = False
        rdoHeader20.Checked = False
        rdoHeader46917.Checked = False
        rdoHeader5.Checked = False
        rdoHeader9899.Checked = False
        rdoHeaderNone.Checked = True
        nbrExtrude.Value = 0
        nbrTrim.Value = 0
        nbrPoint.Value = 0
        nbrThreadCut.Value = 0
        nbrSlot.Value = 0
        nbrHandSlot.Value = 0
        nbrShave.Value = 0
        nbrPunchPress.Value = 0
        nbrCenterless.Value = 0
        nbrHotFormer.Value = 0
        nbrNo10Slow.Value = 0
        nbrNo20H20.Value = 0
        nbrNo360H60.Value = 0
        nbrNo40.Value = 0
        nbrHandRoll.Value = 0
        nbrHandRollNo50.Value = 0
        nbrReed.Value = 0
        nbrBoltMaker.Value = 0
        nbrFlatRoll.Value = 0
        nbrDrilling.Value = 0
        nbrCounterSink.Value = 0
        nbrShotPeen.Value = 0
        nbrLatheWork.Value = 0
        nbrMazakLathe.Value = 0
        nbrMazakMill.Value = 0
        nbrGrinding.Value = 0
        nbrTapping.Value = 0
        nbrBarFeed.Value = 0
        nbrHaasMill.Value = 0
        nbrHaasMiniMill.Value = 0
        ''Weight Operations Tab
        chkWireCleaning.Checked = False
        chkTumbleAndWash.Checked = False
        chkAnneal.Checked = False
        chkZincPlating.Checked = False
        chkPicklePlate.Checked = False
        chkBake.Checked = False
        chkNickelPlating.Checked = False
        chkHeatTreat.Checked = False
        chkCaseHardening.Checked = False
        chkOutsideHeatTreatOrPlating.Checked = False
        chkPhosphateAndOil.Checked = False
        rdoC1010ToC1018.Checked = False
        rdoC1010ToC1018Annealed.Checked = False
        rdoAlloy.Checked = False
        rdoRebar.Checked = False
        rdoStainless.Checked = False
        rdoSpecialMaterial.Checked = False
        txtSpecialMaterialType.Clear()
        txtMaterialCostPer.Clear()
        txtToolingCharge.Clear()
        txtSetupCharge.Clear()
        txtOutsideOtherOperationTotal.Text = ""
        txtOtherOperationTotal.Text = ""
        ''Weight Calculator Tab
        rdoSteel.Checked = True
        rdoAluminum.Checked = False
        rdoCopper.Checked = False
        rdoFreeCutBrass.Checked = False
        rdoNavalBrass.Checked = False
        rdoBronze.Checked = False
        rdoStandard.Checked = False
        rdoMetric.Checked = False
        txtScrapPercent.Clear()
        txtFinishedWeight.Clear()
        ''QC/QA Tab
        rdo24Hours.Checked = False
        rdo48Hours.Checked = False
        rdo72Hours.Checked = False
        rdo96Hours.Checked = False
        rdo120Hours.Checked = False
        rdo168Hours.Checked = False
        nbrSaltSprayAdditionalHours.Value = 0
        nbrSurfaceandCore.Value = 0
        nbrMicroCaseDepth.Value = 0
        nbrMicroDecarb.Value = 0
        nbrFurnaceChartCopy.Value = 0
        chk5SpecimenMax.Checked = False
        nbrAdditionalSpecimen.Value = 0
        nbrWedgeBendShear.Value = 0
        nbrTWDTensile.Value = 0
        nbrCertificateOfCompliance.Value = 0
        nbrNylonPatch.Value = 0
        nbrChemistry.Value = 0
        nbrMillCertification.Value = 0
        nbrCertificationRequired.Value = 0
        nbrSamplesRequired.Value = 0
        nbrSPCRequired.Value = 0
        nbrDimensional.Value = 0
        nbrPlating.Value = 0
        nbrMagParticle.Value = 0
        nbrISIR.Value = 0
        nbrPPap.Value = 0
        chkOutsideHTCertification.Checked = False
        txtDeliveryRequirements.Clear()
        ''clearing the all together DGV and totals
        dgvEstimatedCost.Rows.Clear()
        needsSaved = False
        shouldSave = False
        txtStartWeight.Text = ""
        txtScrapWeight.Text = ""
        QCList.Clear()
    End Sub

    Private Sub clearDataGrids()
        LoadMarkupData()
        LoadOtherData()
        LoadSegmentData()
        resetshipTotalDGV()
        UpdateDisplayedTotals()
    End Sub

    Private Sub resetshipTotalDGV()
        dgvEstimatedCost.Size = New System.Drawing.Size(274, 282)
        dgvShipTotalsOutsideOpQC.Location = New System.Drawing.Point(751, 315)
        dgvShipTotalsOutsideOpQC.Size = New System.Drawing.Size(274, 160)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            isloaded = False
            ClearAll()
            LoadQuoteNumbers()
            LoadCustomerIDName()
            isloaded = True
            shouldSave = True
            ''only allows TFP or TST to create entries at this time
            If cboDivisionID.Text.Equals("TFP") Or cboDivisionID.Text.Equals("TST") Then
                cmdCreateEntries.Enabled = True
            Else
                cmdCreateEntries.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdGenerateQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateQuote.Click
        If Not EmployeeCompanyCode.Equals("TFP") And Not EmployeeCompanyCode.Equals("TST") Then
            MessageBox.Show("Currently only TFP and TST divisions are allowed to use this. Check Division and try again.", "Not a valid Divison", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            isloaded = False
            ClearAll()
            isloaded = False
            clearDataGrids()
            isloaded = True
        End If

        txtRepAgency.Text = "Home"

        'Write Data to Quotation Primary Database Table (One Time)
        cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(QuoteID)+1, 30001) FROM Quotation); Insert Into Quotation(QuoteID, QuoteDate, Preparer, CustomerID, CustomerName, ContactName, Phone, Extension, Fax, Email, CustPartNo, TFPPartNo, PartDescription, PartSize, DivisionID, DeliveryRequirements, ToolingCharge, SetupCharge, WtPerM, NotesComments, FOXItemCreated, CustomerInqueryNumber, RepAgency, RFQSource, ScrapPercent) values(@Key, @QuoteDate, @Preparer, @CustomerID, @CustomerName, @ContactName, @Phone, @Extension, @Fax, @Email, @CustPartNo, @TFPPartNo, @PartDescription, @PartSize, @DivisionID, @DeliveryRequirements, @ToolingCharge, @SetupCharge, @WtPerM, @NotesComments, 'False', @CustomerInqueryNumber, @RepAgency, @RFQSource, @ScrapPercent); SELECT @Key;", con)

        With cmd.Parameters
            .Add("@QuoteDate", SqlDbType.Date).Value = dtpQuoteDate.Text
            .Add("@Preparer", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
            .Add("@ContactName", SqlDbType.VarChar).Value = txtContactName.Text
            .Add("@Phone", SqlDbType.VarChar).Value = txtPhone.Text
            .Add("@Extension", SqlDbType.VarChar).Value = txtPhoneExtension.Text
            .Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text
            .Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text
            .Add("@CustPartNo", SqlDbType.VarChar).Value = txtCustPartNo.Text
            .Add("@TFPPartNo", SqlDbType.VarChar).Value = txtTFPPartNo.Text
            .Add("@PartDescription", SqlDbType.VarChar).Value = txtPartDescription.Text
            .Add("@PartSize", SqlDbType.VarChar).Value = txtPartSize.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@DeliveryRequirements", SqlDbType.VarChar).Value = txtDeliveryRequirements.Text
            .Add("@ToolingCharge", SqlDbType.VarChar).Value = Val(txtToolingCharge.Text)
            .Add("@SetupCharge", SqlDbType.VarChar).Value = Val(txtSetupCharge.Text)
            .Add("@WtPerM", SqlDbType.VarChar).Value = Val(txtStartWeight.Text)
            .Add("@ScrapPercent", SqlDbType.Float).Value = Val(txtScrapPercent.Text)
            .Add("@NotesComments", SqlDbType.VarChar).Value = txtNotes.Text
            .Add("@CustomerInqueryNumber", SqlDbType.VarChar).Value = txtCustomerInqueryNumber.Text
            .Add("@RepAgency", SqlDbType.VarChar).Value = txtRepAgency.Text
            .Add("@RFQSource", SqlDbType.VarChar).Value = cboRFQSource.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()

        isloaded = False
        LoadQuoteNumbers()
        If Not IsDBNull(obj) Then
            cboQuoteNumber.Text = obj
        End If
        rdoC1010ToC1018.Checked = False
        SaveOperations()
        isloaded = True
        needsSaved = True
        shouldSave = False
        rdoC1010ToC1018.Checked = True
        rdoStandard.Checked = True
    End Sub

    Private Sub cboQuoteNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQuoteNumber.SelectedIndexChanged
        If isloaded Then
            loadingData = True
            needsSaved = False
            shouldSave = False
            If cboQuoteNumber.SelectedIndex <> -1 Then
                Dim temp As String = cboQuoteNumber.Text
                isloaded = False
                ClearAll()
                clearDataGrids()
                isloaded = False
                cboQuoteNumber.Text = temp
                isloaded = True
                LoadQuoteData()
                LoadMarkupData()
                LoadSegmentData()
                TotalWeightPerThousand()
                LoadOtherData()
                UpdateDisplayedTotals()
                CheckIfFOXCreated()
                loadingData = False
                Me.Text = "TFP Quote Form"
            End If
        End If
    End Sub

    Private Function SaveOperations() As Boolean
        Dim keys As New List(Of Integer)
        cmd = New SqlCommand("IF Exists(SELECT QuoteID FROM QuoteOperations WHERE QuoteID = @QuoteID) UPDATE QuoteOperations SET Header = @Header, Extrude = @Extrude, Trim = @Trim, Point = @Point, ThreadCut = @ThreadCut, Slot = @Slot, HandSlot = @HandSlot, Shave = @Shave, PunchPress = @PunchPress, Centerless = @Centerless, HotFormer = @HotFormer, Roll10Slow = @Roll10Slow, RollH20 = @RollH20, RollH60 = @RollH60, Roll40 = @Roll40, RollHand = @RollHand, RollHand50 = @RollHand50, RollReed = @RollReed, RollBoltMaker = @RollBoltMaker, RollFlat = @RollFlat, Drilling = @Drilling, CounterSink = @CounterSink, ShotPeen = @ShotPeen, LatheWork = @LatheWork, MazakLathe = @MazakLathe, MazakMill = @MazakMill, Grinding = @Grinding, Tapping = @Tapping, BarFeed = @BarFeed, HaasMill = @HaasMill, HaasMiniMill = @HaasMiniMill, WireClean = @WireClean, TumbleWash = @TumbleWash, Anneal = @Anneal, ZincPlating = @ZincPlating, PicklePlating = @PicklePlating, NickelPlating = @NickelPlating, Bake = @Bake, HeatTreat = @HeatTreat, CaseHarden = @CaseHarden, OutsideHTorPlate = @OutsideHTorPlate, Phosphate = @Phosphate, MaterialType = @MaterialType, MaterialCost = @MaterialCost, DensityType = @DensityType, DimensionUnits = @DimensionUnits, SaltSpray = @SaltSpray, SaltSprayQuantity = @SaltSprayQuantity, AdditionalSaltSpray = @AdditionalSaltSpray, SurfaceCore = @SurfaceCore, MicroCaseDepth = @MicroCaseDepth, MicroDecarb = @MicroDecarb, FurnaceChartCopy = @FurnaceChartCopy, Tensile5Specimen = @Tensile5Specimen, AdditionalTensile = @AdditionalTensile, WedgeBandShear = @WedgeBandShear, TruWeldTensile = @TruWeldTensile, CertCompliance = @CertCompliance, NylonPatch = @NylonPatch, Chemistry = @Chemistry, MillCert = @MillCert, CertRequired = @CertRequired, SampleRequired = @SampleRequired, SPCRequired = @SPCRequired, Dimensional = @Dimensional, Plating = @Plating, MagParticle = @MagParticle, ISIR = @ISIR, PPap = @PPap, OutsideHTCertification = @OutsideHTCertification WHERE QuoteID = @QuoteID ELSE INSERT INTO QuoteOperations (QuoteID, Header, Extrude, Trim, Point, ThreadCut, Slot, HandSlot, Shave, PunchPress, Centerless, HotFormer, Roll10Slow, RollH20, RollH60, Roll40, RollHand, RollHand50, RollReed, RollBoltMaker, RollFlat, Drilling, CounterSink, ShotPeen, LatheWork, MazakLathe, MazakMill, Grinding, Tapping, BarFeed, HaasMill, HaasMiniMill, WireClean, TumbleWash, Anneal, ZincPlating, PicklePlating, NickelPlating, Bake, HeatTreat, CaseHarden, OutsideHTorPlate, Phosphate, MaterialType, MaterialCost, DensityType, DimensionUnits, SaltSpray, SaltSprayQuantity, AdditionalSaltSpray, SurfaceCore, MicroCaseDepth, MicroDecarb, FurnaceChartCopy, Tensile5Specimen, AdditionalTensile, WedgeBandShear, TruWeldTensile, CertCompliance, NylonPatch, Chemistry, MillCert, CertRequired, SampleRequired, SPCRequired, Dimensional, Plating, MagParticle, ISIR, PPap, OutsideHTCertification) VALUES(@QuoteID, @Header, @Extrude, @Trim, @Point, @ThreadCut, @Slot, @HandSlot, @Shave, @PunchPress, @Centerless, @HotFormer, @Roll10Slow, @RollH20, @RollH60, @Roll40, @RollHand, @RollHand50, @RollReed, @RollBoltMaker, @RollFlat, @Drilling, @CounterSink, @ShotPeen, @LatheWork, @MazakLathe, @MazakMill, @Grinding, @Tapping, @BarFeed, @HaasMill, @HaasMiniMill, @WireClean, @TumbleWash, @Anneal, @ZincPlating, @PicklePlating, @NickelPlating, @Bake, @HeatTreat, @CaseHarden, @OutsideHTorPlate, @Phosphate, @MaterialType, @MaterialCost, @DensityType, @DimensionUnits, @SaltSpray, @SaltSprayQuantity, @AdditionalSaltSpray, @SurfaceCore, @MicroCaseDepth, @MicroDecarb, @FurnaceChartCopy, @Tensile5Specimen, @AdditionalTensile, @WedgeBandShear, @TruWeldTensile, @CertCompliance, @NylonPatch, @Chemistry, @MillCert, @CertRequired, @SampleRequired, @SPCRequired, @Dimensional, @Plating, @MagParticle, @ISIR, @PPap, @OutsideHTCertification);", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        Select Case True
            Case rdoHeaderNone.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "None"
                keys.Add(0)
            Case rdoHeader1011.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 10,11"
                keys.Add(1)
            Case rdoHeader104109112.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 109,112"
                keys.Add(8)
            Case rdoHeader1221.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 12,21"
                keys.Add(5)
            Case rdoHeader137814.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 1,3,7,8,14"
                keys.Add(2)
            Case rdoHeader1819.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 18,19,22"
                keys.Add(6)
            Case rdoHeader20.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 20"
                keys.Add(7)
            Case rdoHeader46917.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 6,9"
                keys.Add(3)
            Case rdoHeader5.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Header Nos. 5"
                keys.Add(4)
            Case rdoHeader9899.Checked
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "Debar 98,99"
                keys.Add(9)
            Case Else
                cmd.Parameters.Add("@Header", SqlDbType.VarChar).Value = "None"
                keys.Add(0)
        End Select
        cmd.Parameters.Add("@Extrude", SqlDbType.TinyInt).Value = nbrExtrude.Value
        shouldAddKey(keys, 10, nbrExtrude.Value)
        cmd.Parameters.Add("@Trim", SqlDbType.TinyInt).Value = nbrTrim.Value
        shouldAddKey(keys, 11, nbrTrim.Value)
        cmd.Parameters.Add("@Point", SqlDbType.TinyInt).Value = nbrPoint.Value
        shouldAddKey(keys, 12, nbrPoint.Value)
        cmd.Parameters.Add("@ThreadCut", SqlDbType.TinyInt).Value = nbrThreadCut.Value
        shouldAddKey(keys, 13, nbrThreadCut.Value)
        cmd.Parameters.Add("@Slot", SqlDbType.TinyInt).Value = nbrSlot.Value
        shouldAddKey(keys, 14, nbrSlot.Value)
        cmd.Parameters.Add("@HandSlot", SqlDbType.TinyInt).Value = nbrHandSlot.Value
        shouldAddKey(keys, 15, nbrHandSlot.Value)
        cmd.Parameters.Add("@Shave", SqlDbType.TinyInt).Value = nbrShave.Value
        shouldAddKey(keys, 16, nbrShave.Value)
        cmd.Parameters.Add("@PunchPress", SqlDbType.TinyInt).Value = nbrPunchPress.Value
        shouldAddKey(keys, 17, nbrPunchPress.Value)
        cmd.Parameters.Add("@Centerless", SqlDbType.TinyInt).Value = nbrCenterless.Value
        shouldAddKey(keys, 18, nbrCenterless.Value)
        cmd.Parameters.Add("@HotFormer", SqlDbType.TinyInt).Value = nbrHotFormer.Value
        shouldAddKey(keys, 19, nbrHotFormer.Value)
        cmd.Parameters.Add("@Roll10Slow", SqlDbType.TinyInt).Value = nbrNo10Slow.Value
        shouldAddKey(keys, 20, nbrNo10Slow.Value)
        cmd.Parameters.Add("@RollH20", SqlDbType.TinyInt).Value = nbrNo20H20.Value
        shouldAddKey(keys, 21, nbrNo20H20.Value)
        cmd.Parameters.Add("@RollH60", SqlDbType.TinyInt).Value = nbrNo360H60.Value
        shouldAddKey(keys, 22, nbrNo360H60.Value)
        cmd.Parameters.Add("@Roll40", SqlDbType.TinyInt).Value = nbrNo40.Value
        shouldAddKey(keys, 23, nbrNo40.Value)
        cmd.Parameters.Add("@RollHand", SqlDbType.TinyInt).Value = nbrHandRoll.Value
        shouldAddKey(keys, 24, nbrHandRoll.Value)
        cmd.Parameters.Add("@RollHand50", SqlDbType.TinyInt).Value = nbrHandRollNo50.Value
        shouldAddKey(keys, 25, nbrHandRollNo50.Value)
        cmd.Parameters.Add("@RollReed", SqlDbType.TinyInt).Value = nbrReed.Value
        shouldAddKey(keys, 26, nbrReed.Value)
        cmd.Parameters.Add("@RollBoltMaker", SqlDbType.TinyInt).Value = nbrBoltMaker.Value
        shouldAddKey(keys, 27, nbrBoltMaker.Value)
        cmd.Parameters.Add("@RollFlat", SqlDbType.TinyInt).Value = nbrFlatRoll.Value
        shouldAddKey(keys, 50, nbrFlatRoll.Value)
        cmd.Parameters.Add("@Drilling", SqlDbType.TinyInt).Value = nbrDrilling.Value
        shouldAddKey(keys, 28, nbrDrilling.Value)
        cmd.Parameters.Add("@CounterSink", SqlDbType.TinyInt).Value = nbrCounterSink.Value
        shouldAddKey(keys, 29, nbrCounterSink.Value)
        cmd.Parameters.Add("@ShotPeen", SqlDbType.TinyInt).Value = nbrShotPeen.Value
        shouldAddKey(keys, 30, nbrShotPeen.Value)
        cmd.Parameters.Add("@LatheWork", SqlDbType.TinyInt).Value = nbrLatheWork.Value
        shouldAddKey(keys, 31, nbrLatheWork.Value)
        cmd.Parameters.Add("@MazakLathe", SqlDbType.TinyInt).Value = nbrMazakLathe.Value
        shouldAddKey(keys, 32, nbrMazakLathe.Value)
        cmd.Parameters.Add("@MazakMill", SqlDbType.TinyInt).Value = nbrMazakMill.Value
        shouldAddKey(keys, 33, nbrMazakMill.Value)
        cmd.Parameters.Add("@Grinding", SqlDbType.TinyInt).Value = nbrGrinding.Value
        shouldAddKey(keys, 34, nbrGrinding.Value)
        cmd.Parameters.Add("@Tapping", SqlDbType.TinyInt).Value = nbrTapping.Value
        shouldAddKey(keys, 35, nbrTapping.Value)
        cmd.Parameters.Add("@BarFeed", SqlDbType.TinyInt).Value = nbrBarFeed.Value
        shouldAddKey(keys, 127, nbrBarFeed.Value)
        cmd.Parameters.Add("@HaasMill", SqlDbType.TinyInt).Value = nbrHaasMill.Value
        shouldAddKey(keys, 128, nbrHaasMill.Value)
        cmd.Parameters.Add("@HaasMiniMill", SqlDbType.TinyInt).Value = nbrHaasMiniMill.Value
        shouldAddKey(keys, 133, nbrHaasMiniMill.Value)
        cmd.Parameters.Add("@WireClean", SqlDbType.VarChar).Value = chkWireCleaning.Checked.ToString()
        shouldAddKey(keys, 36, chkWireCleaning.Checked)
        cmd.Parameters.Add("@TumbleWash", SqlDbType.VarChar).Value = chkTumbleAndWash.Checked.ToString()
        shouldAddKey(keys, 37, chkTumbleAndWash.Checked)
        cmd.Parameters.Add("@Anneal", SqlDbType.VarChar).Value = chkAnneal.Checked.ToString()
        shouldAddKey(keys, 38, chkAnneal.Checked)
        cmd.Parameters.Add("@ZincPlating", SqlDbType.VarChar).Value = chkZincPlating.Checked.ToString()
        shouldAddKey(keys, 39, chkZincPlating.Checked)
        cmd.Parameters.Add("@PicklePlating", SqlDbType.VarChar).Value = chkPicklePlate.Checked.ToString()
        shouldAddKey(keys, 129, chkPicklePlate.Checked)
        cmd.Parameters.Add("@NickelPlating", SqlDbType.VarChar).Value = chkNickelPlating.Checked.ToString()
        shouldAddKey(keys, 131, chkNickelPlating.Checked)
        cmd.Parameters.Add("@Bake", SqlDbType.VarChar).Value = chkBake.Checked.ToString()
        shouldAddKey(keys, 130, chkBake.Checked)
        cmd.Parameters.Add("@HeatTreat", SqlDbType.VarChar).Value = chkHeatTreat.Checked.ToString()
        shouldAddKey(keys, 40, chkHeatTreat.Checked)
        cmd.Parameters.Add("@CaseHarden", SqlDbType.VarChar).Value = chkCaseHardening.Checked.ToString()
        shouldAddKey(keys, 41, chkCaseHardening.Checked)
        cmd.Parameters.Add("@OutsideHTorPlate", SqlDbType.VarChar).Value = chkOutsideHeatTreatOrPlating.Checked.ToString()
        shouldAddKey(keys, 42, chkOutsideHeatTreatOrPlating.Checked)
        cmd.Parameters.Add("@Phosphate", SqlDbType.VarChar).Value = chkPhosphateAndOil.Checked.ToString()
        shouldAddKey(keys, 43, chkPhosphateAndOil.Checked)

        Select Case True
            Case rdoC1010ToC1018.Checked
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = "C1010ToC1018"
                keys.Add(44)
            Case rdoC1010ToC1018Annealed.Checked
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = "C1010ToC1018Annealed"
                keys.Add(45)
            Case rdoC1038.Checked
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = "C1038 Steel"
                keys.Add(46)
            Case rdoAlloy.Checked
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = "Alloy"
                keys.Add(47)
            Case rdoRebar.Checked
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = "Rebar"
                keys.Add(48)
            Case rdoStainless.Checked
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = "Stainless"
                keys.Add(49)
            Case rdoSpecialMaterial.Checked
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = txtSpecialMaterialType.Text
            Case Else
                cmd.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = "C1010ToC1018"
                keys.Add(44)
        End Select

        cmd.Parameters.Add("@MaterialCost", SqlDbType.Float).Value = Val(txtMaterialCostPer.Text)
        ''sends the selected density to the database
        Select Case True
            Case rdoSteel.Checked
                cmd.Parameters.Add("@DensityType", SqlDbType.TinyInt).Value = 0
            Case rdoAluminum.Checked
                cmd.Parameters.Add("@DensityType", SqlDbType.TinyInt).Value = 1
            Case rdoCopper.Checked
                cmd.Parameters.Add("@DensityType", SqlDbType.TinyInt).Value = 2
            Case rdoFreeCutBrass.Checked
                cmd.Parameters.Add("@DensityType", SqlDbType.TinyInt).Value = 3
            Case rdoNavalBrass.Checked
                cmd.Parameters.Add("@DensityType", SqlDbType.TinyInt).Value = 4
            Case rdoBronze.Checked
                cmd.Parameters.Add("@DensityType", SqlDbType.TinyInt).Value = 5
            Case Else
                cmd.Parameters.Add("@DensityType", SqlDbType.TinyInt).Value = 0
        End Select
        ''sends the selected units to the database
        Select Case True
            Case rdoStandard.Checked
                cmd.Parameters.Add("@DimensionUnits", SqlDbType.TinyInt).Value = 1
            Case rdoMetric.Checked
                cmd.Parameters.Add("@DimensionUnits", SqlDbType.TinyInt).Value = 2
            Case Else
                cmd.Parameters.Add("@DimensionUnits", SqlDbType.TinyInt).Value = 1
        End Select
        ''sends the salt spray number
        Select Case True
            Case rdo24Hours.Checked
                cmd.Parameters.Add("@SaltSpray", SqlDbType.TinyInt).Value = 24
                keys.Add(100)
            Case rdo48Hours.Checked
                cmd.Parameters.Add("@SaltSpray", SqlDbType.TinyInt).Value = 48
                keys.Add(101)
            Case rdo72Hours.Checked
                cmd.Parameters.Add("@SaltSpray", SqlDbType.TinyInt).Value = 72
                keys.Add(102)
            Case rdo96Hours.Checked
                cmd.Parameters.Add("@SaltSpray", SqlDbType.TinyInt).Value = 96
                keys.Add(103)
            Case rdo120Hours.Checked
                cmd.Parameters.Add("@SaltSpray", SqlDbType.TinyInt).Value = 120
                keys.Add(104)
            Case rdo168Hours.Checked
                cmd.Parameters.Add("@SaltSpray", SqlDbType.TinyInt).Value = 168
                keys.Add(105)
            Case Else
                cmd.Parameters.Add("@SaltSpray", SqlDbType.TinyInt).Value = 0
        End Select
        cmd.Parameters.Add("@SaltSprayQuantity", SqlDbType.Int).Value = nbrSaltSprayQuantity.Value
        cmd.Parameters.Add("@AdditionalSaltSpray", SqlDbType.Int).Value = nbrSaltSprayAdditionalHours.Value
        shouldAddKey(keys, 106, nbrSaltSprayAdditionalHours.Value)
        cmd.Parameters.Add("@SurfaceCore", SqlDbType.TinyInt).Value = nbrSurfaceandCore.Value
        shouldAddKey(keys, 107, nbrSurfaceandCore.Value)
        cmd.Parameters.Add("@MicroCaseDepth", SqlDbType.TinyInt).Value = nbrMicroCaseDepth.Value
        shouldAddKey(keys, 108, nbrMicroCaseDepth.Value)
        cmd.Parameters.Add("@MicroDecarb", SqlDbType.TinyInt).Value = nbrMicroDecarb.Value
        shouldAddKey(keys, 109, nbrMicroDecarb.Value)
        cmd.Parameters.Add("@FurnaceChartCopy", SqlDbType.TinyInt).Value = nbrFurnaceChartCopy.Value
        shouldAddKey(keys, 110, nbrFurnaceChartCopy.Value)
        cmd.Parameters.Add("@Tensile5Specimen", SqlDbType.VarChar).Value = chk5SpecimenMax.Checked.ToString()
        shouldAddKey(keys, 111, chk5SpecimenMax.Checked)
        cmd.Parameters.Add("@AdditionalTensile", SqlDbType.VarChar).Value = nbrAdditionalSpecimen.Value
        shouldAddKey(keys, 112, nbrAdditionalSpecimen.Value)
        cmd.Parameters.Add("@WedgeBandShear", SqlDbType.TinyInt).Value = nbrWedgeBendShear.Value
        shouldAddKey(keys, 113, nbrWedgeBendShear.Value)
        cmd.Parameters.Add("@TruWeldTensile", SqlDbType.TinyInt).Value = nbrTWDTensile.Value
        shouldAddKey(keys, 114, nbrTWDTensile.Value)
        cmd.Parameters.Add("@CertCompliance", SqlDbType.TinyInt).Value = nbrCertificateOfCompliance.Value
        shouldAddKey(keys, 115, nbrCertificateOfCompliance.Value)
        cmd.Parameters.Add("@NylonPatch", SqlDbType.TinyInt).Value = nbrNylonPatch.Value
        shouldAddKey(keys, 116, nbrNylonPatch.Value)
        cmd.Parameters.Add("@Chemistry", SqlDbType.TinyInt).Value = nbrChemistry.Value
        shouldAddKey(keys, 117, nbrChemistry.Value)
        cmd.Parameters.Add("@MillCert", SqlDbType.TinyInt).Value = nbrMillCertification.Value
        shouldAddKey(keys, 118, nbrMillCertification.Value)
        cmd.Parameters.Add("@CertRequired", SqlDbType.TinyInt).Value = nbrCertificationRequired.Value
        shouldAddKey(keys, 119, nbrCertificationRequired.Value)
        cmd.Parameters.Add("@SampleRequired", SqlDbType.TinyInt).Value = nbrSamplesRequired.Value
        shouldAddKey(keys, 120, nbrSamplesRequired.Value)
        cmd.Parameters.Add("@SPCRequired", SqlDbType.TinyInt).Value = nbrSPCRequired.Value
        shouldAddKey(keys, 121, nbrSPCRequired.Value)
        cmd.Parameters.Add("@Dimensional", SqlDbType.VarChar).Value = nbrDimensional.Value
        shouldAddKey(keys, 122, nbrDimensional.Value)
        cmd.Parameters.Add("@Plating", SqlDbType.TinyInt).Value = nbrPlating.Value
        shouldAddKey(keys, 123, nbrPlating.Value)
        cmd.Parameters.Add("@MagParticle", SqlDbType.TinyInt).Value = nbrMagParticle.Value
        shouldAddKey(keys, 124, nbrMagParticle.Value)
        cmd.Parameters.Add("@ISIR", SqlDbType.TinyInt).Value = nbrISIR.Value
        shouldAddKey(keys, 125, nbrISIR.Value)
        cmd.Parameters.Add("@PPap", SqlDbType.TinyInt).Value = nbrPPap.Value
        shouldAddKey(keys, 126, nbrPPap.Value)
        cmd.Parameters.Add("@OutsideHTCertification", SqlDbType.VarChar).Value = chkOutsideHTCertification.Checked.ToString()
        shouldAddKey(keys, 132, chkOutsideHTCertification.Checked)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("TFPQuoteForm - SaveOperations --Error saving the Operations", "Quote #" + cboQuoteNumber.Text, ex.ToString())
            Return False
        End Try
        If needsSaved Then
            needsSaved = False
        End If
        shouldSave = False
        removeUnusedOperations(keys)
        Return True
    End Function

    ''saves the data to the Quotation Table
    Private Function SaveQuotation(Optional ByVal preparer As String = "") As Boolean
        ''will only change the person to the preparer if not creating entries since it iwll be the only sub that will pass a value for preparer
        If String.IsNullOrEmpty(preparer) Then
            txtPreparedBy.Text = EmployeeLoginName
            preparer = EmployeeLoginName
        End If

        cmd = New SqlCommand("UPDATE Quotation SET QuoteDate = @QuoteDate, Preparer = @Preparer, CustomerID = @CustomerID, CustomerName = @CustomerName, ContactName = @ContactName, Phone = @Phone, Extension = @Extension, Fax = @Fax, Email = @Email, CustPartNo = @CustPartNo, TFPPartNo = @TFPPartNo, PartDescription = @PartDescription, PartSize = @PartSize, DivisionID = @DivisionID, DeliveryRequirements = @DeliveryRequirements, ToolingCharge = @ToolingCharge, SetupCharge = @SetupCharge, WtPerM = @WtPerM, NotesComments = @NotesComments, CustomerInqueryNumber = @CustomerInqueryNumber, RepAgency = @RepAgency, RFQSource = @RFQSource, ScrapPercent = @ScrapPercent, InternalNotes = @InternalNotes, RevisionLevel = @RevisionLevel, CellPhoneNumber = @CellPhoneNumber WHERE QuoteID = @QuoteID", con)

        With cmd.Parameters
            .Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            .Add("@QuoteDate", SqlDbType.Date).Value = dtpQuoteDate.Text
            .Add("@Preparer", SqlDbType.VarChar).Value = preparer
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
            .Add("@ContactName", SqlDbType.VarChar).Value = txtContactName.Text
            .Add("@Phone", SqlDbType.VarChar).Value = txtPhone.Text
            .Add("@Extension", SqlDbType.VarChar).Value = txtPhoneExtension.Text
            .Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text
            .Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text
            .Add("@CustPartNo", SqlDbType.VarChar).Value = txtCustPartNo.Text
            .Add("@TFPPartNo", SqlDbType.VarChar).Value = txtTFPPartNo.Text
            .Add("@PartDescription", SqlDbType.VarChar).Value = txtPartDescription.Text
            .Add("@PartSize", SqlDbType.VarChar).Value = txtPartSize.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@DeliveryRequirements", SqlDbType.VarChar).Value = txtDeliveryRequirements.Text
            .Add("@ToolingCharge", SqlDbType.VarChar).Value = Val(txtToolingCharge.Text)
            .Add("@SetupCharge", SqlDbType.VarChar).Value = Val(txtSetupCharge.Text)
            .Add("@WtPerM", SqlDbType.Int).Value = Math.Ceiling((Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)))
            .Add("@NotesComments", SqlDbType.VarChar).Value = txtNotes.Text
            .Add("@CustomerInqueryNumber", SqlDbType.VarChar).Value = txtCustomerInqueryNumber.Text
            .Add("@RepAgency", SqlDbType.VarChar).Value = txtRepAgency.Text
            .Add("@RFQSource", SqlDbType.VarChar).Value = cboRFQSource.Text
            .Add("@ScrapPercent", SqlDbType.Float).Value = Val(txtScrapPercent.Text)
            .Add("@InternalNotes", SqlDbType.VarChar).Value = txtInternalNotes.Text
            .Add("@RevisionLevel", SqlDbType.VarChar).Value = txtQuoteRevisionLevel.Text
            .Add("@CellPhoneNumber", SqlDbType.VarChar).Value = txtMobileNumber.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            If cmd.ExecuteNonQuery() > 0 Then
                con.Close()
                Return True
            Else
                con.Close()
                Return False
            End If
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("TFPQuoteForm - SaveOperations --Error saving the Quotation", "Quote #" + cboQuoteNumber.Text, ex.ToString())
            Return False
        End Try
        Return True
    End Function

    Private Sub SetRevisionLevel()
        If Not String.IsNullOrEmpty(txtQuoteRevisionLevel.Text) Then
            Select Case txtQuoteRevisionLevel.Text.Length
                Case 1
                    If txtQuoteRevisionLevel.Text(0).Equals("Z"c) Then
                        txtQuoteRevisionLevel.Text = "AA"
                    Else
                        Dim charVal As Integer = Asc(txtQuoteRevisionLevel.Text(0))
                        charVal += 1
                        txtQuoteRevisionLevel.Text = Chr(charVal)
                    End If
                Case 2
                    If txtQuoteRevisionLevel.Text(1).Equals("Z"c) And txtQuoteRevisionLevel.Text(0).Equals("Z"c) Then
                        txtQuoteRevisionLevel.Text = "AAA"
                    ElseIf txtQuoteRevisionLevel.Text(1).Equals("Z"c) Then
                        Dim charVal As Integer = Asc(txtQuoteRevisionLevel.Text(0))
                        charVal += 1
                        txtQuoteRevisionLevel.Text = Chr(charVal) + "A"
                    Else
                        Dim charVal As Integer = Asc(txtQuoteRevisionLevel.Text(1))
                        charVal += 1
                        txtQuoteRevisionLevel.Text = txtQuoteRevisionLevel.Text(0) + Chr(charVal)
                    End If
                Case 3
                    If txtQuoteRevisionLevel.Text(2).Equals("Z"c) And txtQuoteRevisionLevel.Text(1).Equals("Z"c) And txtQuoteRevisionLevel.Text(0).Equals("Z"c) Then
                        txtQuoteRevisionLevel.Text = "A"
                    ElseIf txtQuoteRevisionLevel.Text(2).Equals("Z"c) And txtQuoteRevisionLevel.Text(1).Equals("Z"c) Then
                        Dim charVal As Integer = Asc(txtQuoteRevisionLevel.Text(0))
                        charVal += 1
                        txtQuoteRevisionLevel.Text = Chr(charVal) + "AA"
                    ElseIf txtQuoteRevisionLevel.Text(2).Equals("Z"c) Then
                        Dim charVal As Integer = Asc(txtQuoteRevisionLevel.Text(2))
                        charVal += 1
                        txtQuoteRevisionLevel.Text = txtQuoteRevisionLevel.Text(0) + Chr(charVal) + "A"
                    Else
                        Dim charVal As Integer = Asc(txtQuoteRevisionLevel.Text(1))
                        charVal += 1
                        txtQuoteRevisionLevel.Text = txtQuoteRevisionLevel.Text(0) + txtQuoteRevisionLevel.Text(1) + Chr(charVal)
                    End If
            End Select
        Else
            txtQuoteRevisionLevel.Text = "A"
        End If
    End Sub

    Private Function SaveCostSheet(ByVal op As OperationData) As Boolean
        ''checks to see if there is an entry into the cost sheet table and if so will use that instead of getting a new value
        cmd = New SqlCommand("BEGIN TRANSACTION IF EXISTS (SELECT * FROM QuotationCostSheet WHERE QuoteID = @QuoteID AND QuoteCostKey = @QuoteCostKey) BEGIN UPDATE QuotationCostSheet SET QuoteCost = @QuoteCost, SetupCost = @SetupCost WHERE QuoteID = @QuoteID AND QuoteCostKey = @QuoteCostKey END ELSE BEGIN INSERT INTO QuotationCostSheet (QuoteID, QuoteCostKey, MachineType, QuoteCost, SetupCost) VALUES ( @QuoteID, @QuoteCostKey, @MachineType, @QuoteCost, @SetupCost)END COMMIT TRANSACTION;", con)

        With cmd.Parameters
            .Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            .Add("@QuoteCostKey", SqlDbType.Int).Value = op.key
            .Add("@MachineType", SqlDbType.VarChar).Value = op.MachineType
            .Add("@QuoteCost", SqlDbType.Float).Value = op.MachineCost
            .Add("@SetupCost", SqlDbType.Float).Value = op.SetupCost
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            If cmd.ExecuteNonQuery() > 0 Then
                con.Close()
                Return True
            Else
                con.Close()
                Return False
            End If
        Catch ex As System.Exception
            con.Close()
            sendErrorToDataBase("TFPQuoteForm - SaveCostSheet --Error saving the Costing for #" + op.key.ToString(), "Quote #" + cboQuoteNumber.Text, ex.ToString())
            Return False
        End Try
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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            If ManualRevisionChange Then
                ManualRevisionChange = False
            Else
                cmd = New SqlCommand("SELECT RevisionLevel FROM Quotation WHERE QuoteID = @QuoteID", con)
                cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
                If con.State = ConnectionState.Closed Then con.Open()
                If Not IsDBNull(cmd.ExecuteScalar()) Then
                    con.Close()
                    SetRevisionLevel()
                End If
            End If
            If SaveQuotation() And SaveOperations() Then
                Me.Text = "TFP Quote Form"
            Else
                MessageBox.Show("There was a problem saving the Quotation. Contact System admin", "Unable to complete Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must enter a Quote Number", "Enter a Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote Number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdAddMarkup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMarkup.Click
        Dim qty As Double = 0

        Dim setTot As Double = Math.Round(Val(txtSetupCharge.Text), 2)
        Dim toolTot As Double = Math.Round(Val(txtToolingCharge.Text), 2)
        Dim qcTot As Double = Math.Round(CalculateQC(False), 2)
        Dim subTot As Double = 0
        Dim mark As Double = 0
        Dim prodTot As Double = Math.Round(UpdateDisplayedTotals() - setTot - toolTot - qcTot, 2)
        Dim quoteTot As Double = Math.Round(subTot * (mark / 100), 2)

        cmd = New SqlCommand("INSERT INTO QuoteMarkup(QuoteID, QuoteNumber, Quantity, Production, Tools, Setup, QualityControl, Total, Markup, QuoteTotal) VALUES(@QuoteID, (SELECT isnull(MAX(QuoteNumber) + 1, 1) FROM QuoteMarkup WHERE QuoteID = @QuoteID), 0, @Production, @Tools, @Setup, @QualityControl, 0, 0, 0);", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        cmd.Parameters.Add("@Production", SqlDbType.Float).Value = prodTot
        cmd.Parameters.Add("@Tools", SqlDbType.Float).Value = toolTot
        cmd.Parameters.Add("@Setup", SqlDbType.Float).Value = setTot
        cmd.Parameters.Add("@QualityControl", SqlDbType.Float).Value = qcTot

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        LoadMarkupData()
        dgvMarkupQuotes.CurrentCell = dgvMarkupQuotes.Rows(0).Cells((dgvMarkupQuotes.Columns.Count - 1))
        dgvMarkupQuotes.Focus()
    End Sub

    Private Sub cmdDeleteSelectedMarkup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelectedMarkup.Click
        cmd = New SqlCommand("DELETE FROM QuoteMarkup WHERE QuoteID = @QuoteID AND QuoteNumber = @QuoteNumber;", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        cmd.Parameters.Add("@QuoteNumber", SqlDbType.TinyInt).Value = Val(dgvMarkupQuotes.Columns(dgvMarkupQuotes.CurrentCell.ColumnIndex).Name)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadMarkupData()
    End Sub

    Private Sub rdoSpecialMaterial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSpecialMaterial.CheckedChanged
        If isloaded Then
            If rdoSpecialMaterial.Checked Then
                txtSpecialMaterialType.ReadOnly = False
                txtMaterialCostPer.ReadOnly = False
                UpdateDisplayedTotals(False)
            Else
                txtSpecialMaterialType.ReadOnly = True
                txtMaterialCostPer.ReadOnly = True
            End If
            shouldSave = true
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'If needsSaved Then
        '    If MessageBox.Show("Quote has not been saved, if you leave without saving Quote will be deleted. Do you want to save?", "Save Quote", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
        '        If canSave() Then
        '            cmdSave_Click(sender, e)
        '        Else
        '            Exit Sub
        '        End If
        '    Else
        '        'DeleteUnsavedQuote()
        '    End If
        'Else

        'End If


        If Not String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            If shouldSave Then
                If MessageBox.Show("Do you want to save the changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    cmdSave_Click(sender, e)
                End If
            End If
        End If

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DeleteUnsavedQuote()
        'cmd = New SqlCommand("DELETE FROM Quotation WHERE QuoteID = @QuoteID;", con)
        'cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)

        'If con.State = ConnectionState.Closed Then con.Open()
        'cmd.ExecuteNonQuery()
        'con.Close()
    End Sub

    Private Sub TFPQuoteForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If needsSaved Then
            DeleteUnsavedQuote()
        End If
    End Sub

    Private Sub cmdAddSegment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSegment.Click
        If canAddSegments() Then
            cmd = New SqlCommand("INSERT INTO QuoteSegments (QuoteID, DimNumber, SegShape, Trim, Dim1, Dim2, Dim3, SegWt) VALUES (@QuoteID, (SELECT isnull(MAX(DimNumber) + 1, 1) FROM QuoteSegments WHERE QuoteID = @QuoteID), 'Round', 'False', 0, 0, 0, 0);", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadSegmentData()
        End If
    End Sub

    Private Function canAddSegments() As Boolean
        If Not isloaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must select a Quote ID", "Select a Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote Number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub dgvSegments_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSegments.VisibleChanged
        If isloaded Then
            If dgvSegments.Rows.Count > 0 Then
                setupSegments()
            End If
        End If
    End Sub

    Private Sub dgvSegments_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSegments.Sorted
        If isloaded Then
            If dgvSegments.Rows.Count > 0 Then
                setupSegments()
            End If
        End If
    End Sub

    Private Sub dgvSegments_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSegments.CellValueChanged
        If isloaded And e.RowIndex <> -1 Then
            isloaded = False
            If IsDBNull(dgvSegments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                isloaded = False
                dgvSegments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                isloaded = True
            End If
            recalculateWeight(dgvSegments.CurrentCell.RowIndex)

            cmd = New SqlCommand("UPDATE QuoteSegments SET SegShape = @SegShape, Trim = @Trim, Dim1 = @Dim1, Dim2 = @Dim2, Dim3 = @Dim3, SegWt = @SegWt WHERE QuoteID = @QuoteID AND DimNumber = @DimNumber;", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            cmd.Parameters.Add("@DimNumber", SqlDbType.Int).Value = dgvSegments.Rows(dgvSegments.CurrentCell.RowIndex).Cells("DimNumber").Value
            cmd.Parameters.Add("@SegShape", SqlDbType.VarChar).Value = dgvSegments.Rows(dgvSegments.CurrentCell.RowIndex).Cells("SegShape").Value
            cmd.Parameters.Add("@Trim", SqlDbType.VarChar).Value = dgvSegments.Rows(dgvSegments.CurrentCell.RowIndex).Cells("Trim").Value
            cmd.Parameters.Add("@Dim1", SqlDbType.Float).Value = dgvSegments.Rows(dgvSegments.CurrentCell.RowIndex).Cells("Dim1").Value
            cmd.Parameters.Add("@Dim2", SqlDbType.Float).Value = dgvSegments.Rows(dgvSegments.CurrentCell.RowIndex).Cells("Dim2").Value
            cmd.Parameters.Add("@Dim3", SqlDbType.Float).Value = dgvSegments.Rows(dgvSegments.CurrentCell.RowIndex).Cells("Dim3").Value
            cmd.Parameters.Add("@SegWt", SqlDbType.Float).Value = dgvSegments.Rows(dgvSegments.CurrentCell.RowIndex).Cells("SegWt").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            isloaded = True
            TotalWeightPerThousand()
            UpdateDisplayedTotals()
        End If
    End Sub

    Private Sub recalculateWeight(Optional ByVal rowNumber As Integer = -1)
        Dim startPoint As Integer = 0
        Dim endPoint As Integer = dgvSegments.Rows.Count - 1
        If rowNumber <> -1 Then
            startPoint = rowNumber
            endPoint = rowNumber
        End If
        Dim FastenerUnits As Double = 0
        If rdoStandard.Checked Then
            FastenerUnits = 1
        Else
            FastenerUnits = 25.4
        End If
        Dim MaterialDensity As Double = 0
        Select Case True
            Case rdoSteel.Checked
                MaterialDensity = 283.3
            Case rdoAluminum.Checked
                MaterialDensity = 97.9
            Case rdoCopper.Checked
                MaterialDensity = 323.0
            Case rdoFreeCutBrass.Checked
                MaterialDensity = 307.0
            Case rdoNavalBrass.Checked
                MaterialDensity = 304.0
            Case rdoBronze.Checked
                MaterialDensity = 304.0
            Case Else
                MaterialDensity = 283.3
        End Select

        For i As Integer = startPoint To endPoint
            Dim sqr As Double
            Dim trim As Double = 0
            Dim WtPerM As Double = 0
            If dgvSegments.Rows(i).Cells("Trim").Value Then
                trim = 0.02
            Else
                trim = 0
            End If

            Dim diameter As Double = (dgvSegments.Rows(i).Cells("Dim1").Value / FastenerUnits)
            Dim length As Double = (dgvSegments.Rows(i).Cells("Dim2").Value / FastenerUnits)
            Dim radius As Double = 0
            ''checks to see what shape we need to calculate against
            Select Case dgvSegments.Rows(i).Cells("SegShape").Value
                Case "None"
                    dgvSegments.Rows(i).Cells("Dim1").Value = 0
                    dgvSegments.Rows(i).Cells("Dim2").Value = 0
                    dgvSegments.Rows(i).Cells("Dim3").Value = 0
                    dgvSegments.Rows(i).Cells("SegWt").Value = 0
                Case "Round"
                    radius = diameter / 2 + trim
                    dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(MaterialDensity * length * pi * (radius ^ 2), 2)
                    dgvSegments.Rows(i).Cells("Dim3").Value = 0
                Case "Hex"
                    If dgvSegments.Rows(i).Cells("Trim").Value Then
                        radius = diameter / 2 * 1.1547 + trim
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(MaterialDensity * length * pi * (radius ^ 2), 2)
                    Else
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(MaterialDensity * length * 6 / 4 * 0.5773358 * (diameter ^ 2), 2)
                    End If
                Case "Square"
                    If dgvSegments.Rows(i).Cells("Trim").Value Then
                        radius = 1.414 * diameter / 2 + trim
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(MaterialDensity * length * pi * (radius ^ 2), 2)
                    Else
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(MaterialDensity * length * (diameter ^ 2), 2)
                    End If
                Case "Penta"
                    If dgvSegments.Rows(i).Cells("Trim").Value Then
                        radius = diameter / 1.17558 + trim
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(MaterialDensity * length * pi * (radius ^ 2), 2)
                    Else
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(MaterialDensity * length * 5 / 4 * 0.32492 * (diameter ^ 2), 2)
                    End If
                Case "Carriage"
                    dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(1 / 6 * MaterialDensity * pi * length * (3 * (diameter / 2) ^ 2 + length ^ 2), 2)
                Case "Rectangular"
                    radius = dgvSegments.Rows(i).Cells("Dim3").Value / FastenerUnits
                    sqr = Sqrt((diameter ^ 2) + (radius ^ 2))
                    If dgvSegments.Rows(i).Cells("Trim").Value Then
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(pi * MaterialDensity * length * ((sqr + (trim * 2)) / 2) ^ 2, 2)
                    Else
                        dgvSegments.Rows(i).Cells("SegWt").Value = Math.Round(diameter * length * radius * MaterialDensity, 2)
                    End If
                Case "Remove Mat."
                    radius = diameter / 2 + trim
                    dgvSegments.Rows(i).Cells("SegWt").Value = -1 * Math.Round(MaterialDensity * length * pi * (radius ^ 2), 2)
                    dgvSegments.Rows(i).Cells("Dim3").Value = 0
            End Select
        Next
        If rowNumber = -1 Then
            UpdateSegmentData()
        End If

        UpdateMarkup()
    End Sub

    Private Sub UpdateSegmentData()
        cmd = New SqlCommand("UPDATE QuoteSegments SET SegWt = @SegWt WHERE QuoteID = @QuoteID AND DimNumber = @DimNumber;", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
        cmd.Parameters.Add("@DimNumber", SqlDbType.TinyInt)
        cmd.Parameters.Add("@SegWt", SqlDbType.Float)
        For i As Integer = 0 To dgvSegments.Rows.Count - 1
            cmd.Parameters("@DimNumber").Value = dgvSegments.Rows(i).Cells("DimNumber").Value
            cmd.Parameters("@SegWt").Value = dgvSegments.Rows(i).Cells("SegWt").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Next
        con.Close()
    End Sub

    Private Sub TotalWeightPerThousand()
        Dim totalWeight As Double = 0
        For i As Integer = 0 To dgvSegments.Rows.Count - 1
            totalWeight += dgvSegments.Rows(i).Cells("SegWt").Value
        Next
        txtFinishedWeight.Text = totalWeight.ToString()
    End Sub

    Private Sub cmdDeleteSegment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSegment.Click
        If canDeleteSegments() Then
            cmd = New SqlCommand("DELETE FROM QuoteSegments WHERE QuoteID = @QuoteID AND DimNumber = @DimNumber;", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            cmd.Parameters.Add("@DimNumber", SqlDbType.Int).Value = dgvSegments.CurrentRow.Cells("DimNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadSegmentData()
        End If
    End Sub

    Private Function canDeleteSegments() As Boolean
        If Not isloaded Then
            Return False
        End If
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must enter a Quote Number", "Enter a Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote Number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        If dgvSegments.Rows.Count = 0 Then
            MessageBox.Show("There are no Segments to Delete", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If dgvSegments.CurrentRow Is Nothing Then
            MessageBox.Show("You must select a Select a segment", "Select a Segment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub rdoSteel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSteel.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoAluminum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAluminum.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoCopper_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCopper.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoFreeCutBrass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFreeCutBrass.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoNavalBrass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNavalBrass.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoBronze_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBronze.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoMetric_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMetric.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoStandard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoStandard.CheckedChanged
        If isloaded Then
            recalculateWeight()
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoC1010ToC1018_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoC1010ToC1018.CheckedChanged
        If isloaded Then
            If rdoC1010ToC1018.Checked Then
                txtMaterialCostPer.Text = GetOperationData(44).MachineCost.ToString()
            End If
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Function GetOperationData(ByVal key As Integer, Optional ByVal times As Integer = 1) As OperationData
        Dim op As New OperationData()
        op.key = key
        Dim dat As Long = DateDiff(DateInterval.Day, dtpQuoteDate.Value.Date, Today.Date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        ''check to see if within the quote valid period and FOX not created and not just loading the Quote
        If (dat > 30 Or dat = 0) And Not FOXCreated() And Not loadingData Then
            cmd = New SqlCommand("SELECT MachineType, QuoteCost, SetupCost FROM QuotationCosting WHERE QuoteCostKey = @QuoteCostKey;", con)
            cmd.Parameters.Add("@QuoteCostKey", SqlDbType.VarChar).Value = key
        Else
            cmd = New SqlCommand("SELECT COUNT(QuoteID) FROM QuotationCostSheet WHERE QuoteCostKey = @QuoteCostKey AND QuoteID = @QuoteID;", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            cmd.Parameters.Add("@QuoteCostKey", SqlDbType.Int).Value = key

            If con.State = ConnectionState.Closed Then con.Open()

            If cmd.ExecuteScalar() = 0 Then
                cmd.CommandText = "SELECT MachineType, QuoteCost, SetupCost FROM QuotationCosting WHERE QuoteCostKey = @QuoteCostKey;"
            Else
                cmd.CommandText = "SELECT MachineType, QuoteCost, SetupCost FROM QuotationCostSheet WHERE QuoteCostKey = @QuoteCostKey AND QuoteID = @QuoteID;"
            End If
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("MachineType")) Then
                op.MachineType = reader.Item("MachineType")
            End If
            If Not IsDBNull(reader.Item("QuoteCost")) Then
                op.MachineCost = reader.Item("QuoteCost")
            End If
            If Not IsDBNull(reader.Item("SetupCost")) Then
                op.SetupCost = reader.Item("SetupCost")
            End If
        End If
        reader.Close()
        con.Close()
        SaveCostSheet(op)
        Return op
    End Function

    Private Function FOXCreated() As Boolean
        cmd = New SqlCommand("SELECT FOXItemCreated FROM Quotation WHERE QuoteID = @QuoteID;", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim locked As Boolean = CBool(cmd.ExecuteScalar())
        con.Close()
        Return locked
    End Function

    Private Function GetTypeCost(ByVal key As Integer) As Double

        cmd = New SqlCommand("SELECT QuoteCost FROM QuotationCosting WHERE QuoteCostKey = @QuoteCostKey;", con)
        cmd.Parameters.Add("@QuoteCostKey", SqlDbType.Int).Value = key

        If con.State = ConnectionState.Closed Then con.Open()
        Dim cst As Double = cmd.ExecuteScalar()
        con.Close()

        Return cst
    End Function

    Private Function GetSetupCost(ByVal key As Integer) As Double

        cmd = New SqlCommand("SELECT SetupCost FROM QuotationCosting WHERE QuoteCostKey = @QuoteCostKey;", con)
        cmd.Parameters.Add("@QuoteCostKey", SqlDbType.Int).Value = key

        If con.State = ConnectionState.Closed Then con.Open()
        Dim cst As Double = cmd.ExecuteScalar()
        con.Close()

        Return cst
    End Function

    Private Sub rdoC1010ToC1018Annealed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoC1010ToC1018Annealed.CheckedChanged
        If isloaded Then
            If rdoC1010ToC1018Annealed.Checked Then
                txtMaterialCostPer.Text = GetOperationData(45).MachineCost.ToString()
            End If
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoC1038_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoC1038.CheckedChanged
        If isloaded Then
            If rdoC1038.Checked Then
                txtMaterialCostPer.Text = GetOperationData(46).MachineCost.ToString()
            End If
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoAlloy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAlloy.CheckedChanged
        If isloaded Then
            If rdoAlloy.Checked Then
                txtMaterialCostPer.Text = GetOperationData(47).MachineCost.ToString()
            End If
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoRebar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoRebar.CheckedChanged
        If isloaded Then
            If rdoRebar.Checked Then
                txtMaterialCostPer.Text = GetOperationData(48).MachineCost.ToString()
            End If
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoStainless_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoStainless.CheckedChanged
        If isloaded Then
            If rdoStainless.Checked Then
                txtMaterialCostPer.Text = GetOperationData(49).MachineCost.ToString()
            End If
            UpdateDisplayedTotals()
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeaderNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeaderNone.CheckedChanged
        If isloaded Then
            If rdoHeaderNone.Checked Then
                UpdateAddToList(0, 1, GetOperationData(0))
            Else
                UpdateAddToList(0, 0, GetOperationData(0))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub UpdateAddToList(ByVal key As Integer, ByVal quantity As Integer, ByVal op As OperationData)
        setupdgvEstimatedCost()
        Dim outsideTotal As Double = 0
        Dim total As Double = 0
        Dim SetupTotal As Double = 0
        Dim found As Boolean = False
        Dim i As Integer = 0
        While i < dgvEstimatedCost.Rows.Count
            If key = dgvEstimatedCost.Rows(i).Cells("key").Value Then
                found = True
                If quantity <> 0 Then
                    If quantity > 1 Then
                        dgvEstimatedCost.Rows(i).Cells("type").Value = op.MachineType + " X" + quantity.ToString
                    Else
                        dgvEstimatedCost.Rows(i).Cells("type").Value = op.MachineType
                    End If
                    dgvEstimatedCost.Rows(i).Cells("cost").Value = op.MachineCost.ToString()
                    dgvEstimatedCost.Rows(i).Cells("total").Value = FormatCurrency(quantity * op.MachineCost)
                    dgvEstimatedCost.Rows(i).Cells("quantity").Value = quantity
                    dgvEstimatedCost.Rows(i).Cells("SetupCost").Value = op.SetupCost
                    total += quantity * op.MachineCost
                    SetupTotal += op.SetupCost
                    i += 1
                Else
                    dgvEstimatedCost.Rows.RemoveAt(i)
                End If
            Else
                total += dgvEstimatedCost.Rows(i).Cells("cost").Value * dgvEstimatedCost.Rows(i).Cells("quantity").Value
                SetupTotal += dgvEstimatedCost.Rows(i).Cells("SetupCost").Value
                i += 1
            End If
        End While
        ''check to see if the item was found if not will add it
        If Not found And quantity > 0 Then
            If quantity > 1 Then
                dgvEstimatedCost.Rows.Add(key, op.MachineType + " X" + quantity.ToString, FormatCurrency(quantity * op.MachineCost), quantity, op.MachineCost, op.SetupCost)
            Else
                dgvEstimatedCost.Rows.Add(key, op.MachineType, FormatCurrency(quantity * op.MachineCost), quantity, op.MachineCost, op.SetupCost)
            End If
            total += quantity * op.MachineCost
            SetupTotal += op.SetupCost
        End If
        txtSetupCharge.Text = Math.Round(SetupTotal, 2)
        Dim ship As Double = Math.Round((Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)) * 0.025, 2)
        dgvShipTotalsOutsideOpQC.Rows.Add("Shipping Cost", FormatCurrency(ship))
        total = (total + ship) * 1.4
        dgvShipTotalsOutsideOpQC.Rows.Add("Total Cost X 140%", FormatCurrency(total))
        Dim MaterialCost As Double = Math.Round(((Val(txtMaterialCostPer.Text) / 100) * Val(txtStartWeight.Text)), 2, MidpointRounding.AwayFromZero)
        ''check to see what type of material is selected
        Select Case True
            Case rdoC1010ToC1018.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(44).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoC1010ToC1018Annealed.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(45).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoC1038.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(46).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoAlloy.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(47).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoRebar.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(48).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoStainless.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(49).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoSpecialMaterial.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(txtSpecialMaterialType.Text + " Cost", FormatCurrency(MaterialCost))
        End Select
        total += Math.Round(MaterialCost + addOutsideOtherOperations(), 2)
        dgvShipTotalsOutsideOpQC.Rows.Add("Sub Total", FormatCurrency((total)))
        dgvShipTotalsOutsideOpQC.Rows.Add("Total Cost X 273%", FormatCurrency(total * 2.73))
        dgvShipTotalsOutsideOpQC.Rows.Add("Quality Assurance", CalculateQC(False))
        expandShipTotalOutOPQC()

        UpdateMarkup()
    End Sub

    Private Sub setupdgvEstimatedCost()
        If dgvEstimatedCost.Columns.Count = 0 Then
            dgvEstimatedCost.Columns.Add("key", "key")
            dgvEstimatedCost.Columns("key").Visible = False
            dgvEstimatedCost.Columns.Add("type", "type")
            dgvEstimatedCost.Columns("type").MinimumWidth = 172
            dgvEstimatedCost.Columns.Add("total", "total")
            dgvEstimatedCost.Columns("total").MinimumWidth = 20
            dgvEstimatedCost.Columns("total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvEstimatedCost.Columns.Add("quantity", "quantity")
            dgvEstimatedCost.Columns("quantity").Visible = False
            dgvEstimatedCost.Columns.Add("cost", "cost")
            dgvEstimatedCost.Columns("cost").Visible = False
            dgvEstimatedCost.Columns.Add("SetupCost", "SetupCost")
            dgvEstimatedCost.Columns("SetupCost").Visible = False
        End If
    End Sub

    Private Sub rdoHeader1011_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader1011.CheckedChanged
        If isloaded Then
            If rdoHeader1011.Checked Then
                UpdateAddToList(1, 1, GetOperationData(1))
            Else
                UpdateAddToList(1, 0, GetOperationData(1))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader137814_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader137814.CheckedChanged
        If isloaded Then
            If rdoHeader137814.Checked Then
                UpdateAddToList(2, 1, GetOperationData(2))
            Else
                UpdateAddToList(2, 0, GetOperationData(2))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader46917_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader46917.CheckedChanged
        If isloaded Then
            If rdoHeader46917.Checked Then
                UpdateAddToList(3, 1, GetOperationData(3))
            Else
                UpdateAddToList(3, 0, GetOperationData(3))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader5.CheckedChanged
        If isloaded Then
            If rdoHeader5.Checked Then
                UpdateAddToList(4, 1, GetOperationData(4))
            Else
                UpdateAddToList(4, 0, GetOperationData(4))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader1221_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader1221.CheckedChanged
        If isloaded Then
            If rdoHeader1221.Checked Then
                UpdateAddToList(5, 1, GetOperationData(5))
            Else
                UpdateAddToList(5, 0, GetOperationData(5))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader1819_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader1819.CheckedChanged
        If isloaded Then
            If rdoHeader1819.Checked Then
                UpdateAddToList(6, 1, GetOperationData(6))
            Else
                UpdateAddToList(6, 0, GetOperationData(6))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader20.CheckedChanged
        If isloaded Then
            If rdoHeader20.Checked Then
                UpdateAddToList(7, 1, GetOperationData(7))
            Else
                UpdateAddToList(7, 0, GetOperationData(7))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader104109112_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader104109112.CheckedChanged
        If isloaded Then
            If rdoHeader104109112.Checked Then
                UpdateAddToList(8, 1, GetOperationData(8))
            Else
                UpdateAddToList(8, 0, GetOperationData(8))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoHeader9899_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHeader9899.CheckedChanged
        If isloaded Then
            If rdoHeader9899.Checked Then
                UpdateAddToList(9, 1, GetOperationData(9))
            Else
                UpdateAddToList(9, 0, GetOperationData(9))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub nbrExtrude_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrExtrude.ValueChanged
        If isloaded Then
            UpdateAddToList(10, nbrExtrude.Value, GetOperationData(10))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrTrim_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrTrim.ValueChanged
        If isloaded Then
            UpdateAddToList(11, nbrTrim.Value, GetOperationData(11))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrPoint_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrPoint.ValueChanged
        If isloaded Then
            UpdateAddToList(12, nbrPoint.Value, GetOperationData(12))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrThreadCut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrThreadCut.ValueChanged
        If isloaded Then
            UpdateAddToList(13, nbrThreadCut.Value, GetOperationData(13))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrSlot_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrSlot.ValueChanged
        If isloaded Then
            UpdateAddToList(14, nbrSlot.Value, GetOperationData(14))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrHandSlot_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrHandSlot.ValueChanged
        If isloaded Then
            UpdateAddToList(15, nbrHandSlot.Value, GetOperationData(15))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrShave_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrShave.ValueChanged
        If isloaded Then
            UpdateAddToList(16, nbrShave.Value, GetOperationData(16))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrPunchPress_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrPunchPress.ValueChanged
        If isloaded Then
            UpdateAddToList(17, nbrPunchPress.Value, GetOperationData(17))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrCenterless_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrCenterless.ValueChanged
        If isloaded Then
            UpdateAddToList(18, nbrCenterless.Value, GetOperationData(18))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrHotFormer_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrHotFormer.ValueChanged
        If isloaded Then
            UpdateAddToList(19, nbrHotFormer.Value, GetOperationData(19))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrNo10Slow_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrNo10Slow.ValueChanged
        If isloaded Then
            UpdateAddToList(20, nbrNo10Slow.Value, GetOperationData(20))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrNo20H20_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrNo20H20.ValueChanged
        If isloaded Then
            UpdateAddToList(21, nbrNo20H20.Value, GetOperationData(21))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrNo360H60_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrNo360H60.ValueChanged
        If isloaded Then
            UpdateAddToList(22, nbrNo360H60.Value, GetOperationData(22))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrNo40_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrNo40.ValueChanged
        If isloaded Then
            UpdateAddToList(23, nbrNo40.Value, GetOperationData(23))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrHandRoll_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrHandRoll.ValueChanged
        If isloaded Then
            UpdateAddToList(24, nbrHandRoll.Value, GetOperationData(24))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrHandRollNo50_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrHandRollNo50.ValueChanged
        If isloaded Then
            UpdateAddToList(25, nbrHandRollNo50.Value, GetOperationData(25))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrReed_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrReed.ValueChanged
        If isloaded Then
            UpdateAddToList(26, nbrReed.Value, GetOperationData(26))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrBoltMaker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrBoltMaker.ValueChanged
        If isloaded Then
            UpdateAddToList(27, nbrBoltMaker.Value, GetOperationData(27))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrFlatRoll_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrFlatRoll.ValueChanged
        If isloaded Then
            UpdateAddToList(50, nbrFlatRoll.Value, GetOperationData(50))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrDrilling_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrDrilling.ValueChanged
        If isloaded Then
            UpdateAddToList(28, nbrDrilling.Value, GetOperationData(28))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrCounterSink_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrCounterSink.ValueChanged
        If isloaded Then
            UpdateAddToList(29, nbrCounterSink.Value, GetOperationData(29))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrShotPeen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrShotPeen.ValueChanged
        If isloaded Then
            UpdateAddToList(30, nbrShotPeen.Value, GetOperationData(30))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrLatheWork_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrLatheWork.ValueChanged
        If isloaded Then
            UpdateAddToList(31, nbrLatheWork.Value, GetOperationData(31))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrMazakLathe_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrMazakLathe.ValueChanged
        If isloaded Then
            UpdateAddToList(32, nbrMazakLathe.Value, GetOperationData(32))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrMazakMill_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrMazakMill.ValueChanged
        If isloaded Then
            UpdateAddToList(33, nbrMazakMill.Value, GetOperationData(33))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrGrinding_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrGrinding.ValueChanged
        If isloaded Then
            UpdateAddToList(34, nbrGrinding.Value, GetOperationData(34))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrTapping_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrTapping.ValueChanged
        If isloaded Then
            UpdateAddToList(35, nbrTapping.Value, GetOperationData(35))
            shouldSave = True
        End If
    End Sub

    Private Sub chkWireCleaning_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWireCleaning.CheckedChanged
        If isloaded Then
            If chkWireCleaning.Checked Then
                Dim op As OperationData = GetOperationData(36)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(36, 1, op)
            Else
                UpdateAddToList(36, 0, GetOperationData(36))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkTumbleAndWash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTumbleAndWash.CheckedChanged
        If isloaded Then
            If chkTumbleAndWash.Checked Then
                Dim op As OperationData = GetOperationData(37)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(37, 1, op)
            Else
                UpdateAddToList(37, 0, GetOperationData(37))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkAnneal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnneal.CheckedChanged
        If isloaded Then
            If chkAnneal.Checked Then
                Dim op As OperationData = GetOperationData(38)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(38, 1, op)
            Else
                UpdateAddToList(38, 0, GetOperationData(38))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkZincPlating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkZincPlating.CheckedChanged
        If isloaded Then
            If chkZincPlating.Checked Then
                Dim op As OperationData = GetOperationData(39)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(39, 1, op)
            Else
                UpdateAddToList(39, 0, GetOperationData(39))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkHeatTreat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeatTreat.CheckedChanged
        If isloaded Then
            If chkHeatTreat.Checked Then
                Dim op As OperationData = GetOperationData(40)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(40, 1, op)
            Else
                UpdateAddToList(40, 0, GetOperationData(40))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkCaseHardening_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCaseHardening.CheckedChanged
        If isloaded Then
            If chkCaseHardening.Checked Then
                Dim op As OperationData = GetOperationData(41)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(41, 1, op)
            Else
                UpdateAddToList(41, 0, GetOperationData(41))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkOutsideHeatTreatOrPlating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOutsideHeatTreatOrPlating.CheckedChanged
        If isloaded Then
            If chkOutsideHeatTreatOrPlating.Checked Then
                Dim op As OperationData = GetOperationData(42)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(42, 1, op)
            Else
                UpdateAddToList(42, 0, GetOperationData(42))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkPhosphateAndOil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhosphateAndOil.CheckedChanged
        If isloaded Then
            If chkPhosphateAndOil.Checked Then
                Dim op As OperationData = GetOperationData(43)
                op.MachineCost = op.MachineCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(43, 1, op)
            Else
                UpdateAddToList(43, 0, GetOperationData(43))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub txtTotalWeightPerThousand_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isloaded Then
            UpdateDisplayedTotals()
        End If
    End Sub

    Private Function UpdateDisplayedTotals(Optional ByVal updateMark As Boolean = True) As Double
        Dim total As Double = 0
        'Dim outsideTotal As Double = 0
        For i As Integer = 0 To dgvEstimatedCost.Rows.Count - 1
            Dim tempCost As Double = GetTypeCost(dgvEstimatedCost.Rows(i).Cells("key").Value)
            Dim tempKey As String = dgvEstimatedCost.Rows(i).Cells("key").Value
            Dim tempQuant As Double = dgvEstimatedCost.Rows(i).Cells("quantity").Value
            Dim tempCst As Double = dgvEstimatedCost.Rows(i).Cells("cost").Value
            Select Case dgvEstimatedCost.Rows(i).Cells("key").Value
                Case 36, 37, 38, 39, 40, 41, 42, 43, 129, 130, 131
                    dgvEstimatedCost.Rows(i).Cells("total").Value = FormatCurrency(dgvEstimatedCost.Rows(i).Cells("quantity").Value * (tempCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))))
                    dgvEstimatedCost.Rows(i).Cells("cost").Value = tempCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                    total += dgvEstimatedCost.Rows(i).Cells("quantity").Value * (tempCost * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)))
                Case Else
                    ''check to see if outside operation, then will see what operation needs to be performed
                    If dgvEstimatedCost.Rows(i).Cells("key").Value > 999 And dgvEstimatedCost.Rows(i).Cells("key").Value < 2000 Then
                        Dim rowNum As Integer = GetOtherRowNumber(dgvEstimatedCost.Rows(i).Cells("key").Value - 1000)
                        If dgvOtherOperations.Rows(rowNum).Cells("UnitType").Value.ToString.Equals("CWT") Then
                            dgvEstimatedCost.Rows(i).Cells("total").Value = FormatCurrency(dgvOtherOperations.Rows(rowNum).Cells("Cost").Value / 100 * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)))
                            total += dgvOtherOperations.Rows(rowNum).Cells("Cost").Value / 100 * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                        Else
                            dgvEstimatedCost.Rows(i).Cells("total").Value = FormatCurrency(dgvOtherOperations.Rows(rowNum).Cells("Cost").Value)
                            total += dgvOtherOperations.Rows(rowNum).Cells("Cost").Value
                        End If
                    Else
                        dgvEstimatedCost.Rows(i).Cells("total").Value = FormatCurrency(dgvEstimatedCost.Rows(i).Cells("quantity").Value * dgvEstimatedCost.Rows(i).Cells("cost").Value)
                        total += dgvEstimatedCost.Rows(i).Cells("quantity").Value * dgvEstimatedCost.Rows(i).Cells("cost").Value
                    End If
            End Select
        Next
        clearDGVShipTotalOutOPQC()
        setupDGVShipTotalOutOpQC()
        Dim ship As Double = Math.Round((Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)) * 0.025, 2)
        dgvShipTotalsOutsideOpQC.Rows.Add("Shipping Cost", FormatCurrency(ship))
        total = Math.Round((total + ship) * 1.4, 2)
        dgvShipTotalsOutsideOpQC.Rows.Add("Total Cost X 140%", FormatCurrency(total))
        Dim MaterialCost As Double = Math.Round(((Val(txtMaterialCostPer.Text) / 100) * Val(txtStartWeight.Text)), 2, MidpointRounding.AwayFromZero)
        Select Case True
            Case rdoC1010ToC1018.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(44).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoC1010ToC1018Annealed.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(45).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoC1038.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(46).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoAlloy.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(47).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoRebar.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(48).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoStainless.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(GetOperationData(49).MachineType + " Cost", FormatCurrency(MaterialCost))
            Case rdoSpecialMaterial.Checked
                dgvShipTotalsOutsideOpQC.Rows.Add(txtSpecialMaterialType.Text + " Cost", FormatCurrency(MaterialCost))
        End Select
        total += Math.Round(MaterialCost + addOutsideOtherOperations(), 2)
        dgvShipTotalsOutsideOpQC.Rows.Add("Sub Total", FormatCurrency(total))
        dgvShipTotalsOutsideOpQC.Rows.Add("Total Cost X 273%", FormatCurrency(total * 2.73))
        dgvShipTotalsOutsideOpQC.Rows.Add("Quality Assurance", FormatCurrency(CalculateQC(False)))
        expandShipTotalOutOPQC()
        If updateMark Then
            UpdateMarkup(total)
        End If
        Return total
    End Function

    Private Function GetOtherRowNumber(ByVal key As Integer) As Integer
        For i As Integer = 0 To dgvOtherOperations.Rows.Count - 1
            If dgvOtherOperations.Rows(i).Cells("OtherNumber").Value = key Then
                Return i
            End If
        Next
        Return 0
    End Function

    Private Sub cmdAddOtherOperation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddOtherOperation.Click
        If canAddOtherOperation() Then
            cmd = New SqlCommand("INSERT INTO QuoteOther (QuoteID, OtherNumber, Description, Cost, UnitType, Outside) VALUES (@QuoteID, (SELECT isnull(MAX(OtherNumber) + 1, 1) FROM QuoteOther WHERE QuoteID = @QuoteID), '', 0, 'Per/M', 'False');", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadOtherData()
        End If
    End Sub

    Private Function canAddOtherOperation() As Boolean
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must select a Quote", "Select a Quote", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote Number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteOtherOperation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteOtherOperation.Click
        If canDeleteOtherOperation() Then
            Dim op As New OperationData(1000 + dgvOtherOperations.CurrentRow.Cells("OtherNumber").Value, dgvOtherOperations.CurrentRow.Cells("Description").Value, dgvOtherOperations.CurrentRow.Cells("Cost").Value * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text)), 0, 0)
            UpdateAddToList(1000 + dgvOtherOperations.CurrentRow.Cells("OtherNumber").Value, 0, op)
            cmd = New SqlCommand("DELETE QuoteOther WHERE QuoteID = @QuoteID AND OtherNumber = @OtherNumber;", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            cmd.Parameters.Add("@OtherNumber", SqlDbType.TinyInt).Value = dgvOtherOperations.CurrentRow.Cells("OtherNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadOtherData()
        End If
    End Sub

    Private Function canDeleteOtherOperation() As Boolean
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must select a Quote", "Select a Quote", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote Number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        If dgvOtherOperations.Rows.Count = 0 Then
            MessageBox.Show("There is nothing to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvEstimatedCost.CurrentCell Is Nothing Then
            MessageBox.Show("You must select an Operation to delete", "Select an Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub dgvOtherOperations_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherOperations.CellValueChanged
        If isloaded And e.RowIndex <> -1 Then
            If dgvOtherOperations.Columns(e.ColumnIndex).Name.Equals("Cost") And IsDBNull(dgvOtherOperations.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                isloaded = False
                dgvOtherOperations.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                isloaded = True
            End If
            cmd = New SqlCommand("UPDATE QuoteOther SET Description = @Description, Cost = @Cost, UnitType = @UnitType, Outside = @Outside WHERE QuoteID = @QuoteID AND OtherNumber = @OtherNumber;", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            cmd.Parameters.Add("@OtherNumber", SqlDbType.TinyInt).Value = dgvOtherOperations.Rows(e.RowIndex).Cells("OtherNumber").Value
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = dgvOtherOperations.Rows(e.RowIndex).Cells("Description").Value
            cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = dgvOtherOperations.Rows(e.RowIndex).Cells("Cost").Value
            cmd.Parameters.Add("@UnitType", SqlDbType.VarChar).Value = dgvOtherOperations.Rows(e.RowIndex).Cells("UnitType").Value
            cmd.Parameters.Add("@Outside", SqlDbType.VarChar).Value = dgvOtherOperations.Rows(e.RowIndex).Cells("Outside").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            totaldgvOther()
            UpdateDisplayedTotals()
        End If
    End Sub

    Private Sub rdo24Hours_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo24Hours.CheckedChanged
        If isloaded Then
            If rdo24Hours.Checked Then
                Dim op As OperationData = GetOperationData(100)
                UpdateQCList(nbrSaltSprayQuantity.Value, op)
            Else
                UpdateQCList(0, GetOperationData(100))
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub rdo48Hours_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo48Hours.CheckedChanged
        If isloaded Then
            If rdo48Hours.Checked Then
                Dim op As OperationData = GetOperationData(101)
                UpdateQCList(nbrSaltSprayQuantity.Value, op)
            Else
                UpdateQCList(0, GetOperationData(101))
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub rdo72Hours_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo72Hours.CheckedChanged
        If isloaded Then
            If rdo72Hours.Checked Then
                Dim op As OperationData = GetOperationData(102)
                UpdateQCList(nbrSaltSprayQuantity.Value, op)
            Else
                UpdateQCList(0, GetOperationData(102))
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub rdo96Hours_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo96Hours.CheckedChanged
        If isloaded Then
            If rdo96Hours.Checked Then
                Dim op As OperationData = GetOperationData(103)
                UpdateQCList(nbrSaltSprayQuantity.Value, op)
            Else
                UpdateQCList(0, GetOperationData(103))
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub rdo120Hours_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo120Hours.CheckedChanged
        If isloaded Then
            If rdo120Hours.Checked Then
                Dim op As OperationData = GetOperationData(104)
                UpdateQCList(nbrSaltSprayQuantity.Value, op)
            Else
                UpdateQCList(0, GetOperationData(104))
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub rdo168Hours_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo168Hours.CheckedChanged
        If isloaded Then
            If rdo168Hours.Checked Then
                Dim op As OperationData = GetOperationData(105)
                UpdateQCList(nbrSaltSprayQuantity.Value, op)
            Else
                UpdateQCList(0, GetOperationData(105))
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrSaltSprayAdditionalHours_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrSaltSprayAdditionalHours.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(106)
            UpdateQCList(nbrSaltSprayAdditionalHours.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub chk5SpecimenMax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk5SpecimenMax.CheckedChanged
        If isloaded Then
            If chk5SpecimenMax.Checked Then
                Dim op As OperationData = GetOperationData(111)
                UpdateQCList(1, op)
            Else
                UpdateQCList(0, GetOperationData(111))
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrAdditionalSpecimen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrAdditionalSpecimen.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(112)
            UpdateQCList(nbrAdditionalSpecimen.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrWedgeBendShear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrWedgeBendShear.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(113)
            UpdateQCList(nbrWedgeBendShear.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub dgvMarkupQuotes_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMarkupQuotes.CellValueChanged
        If isloaded Then
            Dim qty As Double = 0
            If Not IsDBNull(dgvMarkupQuotes.Rows(0).Cells(e.ColumnIndex).Value) Then
                qty = dgvMarkupQuotes.Rows(0).Cells(e.ColumnIndex).Value
            End If

            Dim toolTot As Double = 0D
            If e.RowIndex = 8 And Val(dgvMarkupQuotes.Rows(8).Cells(e.ColumnIndex).Value) > 0 Then
                toolTot = Val(dgvMarkupQuotes.Rows(8).Cells(e.ColumnIndex).Value)
            Else
                toolTot = Val(txtToolingCharge.Text)
            End If

            Dim setTot As Double = Val(txtSetupCharge.Text)
            Dim qcTot As Double = CalculateQC(False)
            Dim subTot As Double = 0
            Dim mark As Double = dgvMarkupQuotes.Rows(6).Cells(e.ColumnIndex).Value
            Dim quoteTot As Double = dgvMarkupQuotes.Rows(7).Cells(e.ColumnIndex).Value
            Dim prodTot As Double = Math.Round(UpdateDisplayedTotals() * 2.73, 2)

            ''check to make sure we aren't trying to divide by 0
            If qty > 0 Then
                If qty > 1000 Then
                    toolTot = Math.Round(toolTot / qty * 1000, 2)
                    setTot = Math.Round(setTot / qty * 1000, 2)
                Else
                    setTot = Math.Round(setTot, 2)
                    toolTot = Math.Round(toolTot, 2)
                End If
                subTot = prodTot + toolTot + setTot + Math.Round(qcTot / qty * 1000, 2)
            End If

            If e.RowIndex <> 7 Then
                quoteTot = Math.Round(subTot * (mark / 100), 2)
            Else
                mark = Math.Round((quoteTot / subTot) * 100, 4, MidpointRounding.AwayFromZero)
            End If

            cmd = New SqlCommand("UPDATE QuoteMarkup SET Quantity = @Quantity, Production = @Production, Tools = @Tools, Setup = @Setup, QualityControl = @QualityControl, Total = @Total, Markup = @Markup, QuoteTotal = @QuoteTotal WHERE QuoteID = @QuoteID AND QuoteNumber = @QuoteNumber;", con)

            With cmd.Parameters
                .Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
                .Add("@QuoteNumber", SqlDbType.TinyInt).Value = Val(dgvMarkupQuotes.Columns(e.ColumnIndex).Name)
                .Add("@Quantity", SqlDbType.Int).Value = qty
                .Add("@Production", SqlDbType.Float).Value = prodTot
                .Add("@Tools", SqlDbType.Float).Value = toolTot
                .Add("@Setup", SqlDbType.Float).Value = setTot
                .Add("@QualityControl", SqlDbType.Float).Value = qcTot
                .Add("@Total", SqlDbType.Float).Value = subTot
                .Add("@Markup", SqlDbType.Float).Value = mark
                .Add("@QuoteTotal", SqlDbType.Float).Value = quoteTot
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Dim rw As Integer = e.RowIndex
            Dim cl As Integer = e.ColumnIndex

            isloaded = False
            LoadMarkupData()
            dgvMarkupQuotes.CurrentCell = dgvMarkupQuotes.Rows(rw).Cells(cl)
            isloaded = True
        End If
    End Sub

    Private Sub UpdateMarkup(Optional ByVal origProdTot As Double = -1, Optional ByVal qcTotalPassed As Double = -1)
        If origProdTot = -1 Then
            origProdTot = UpdateDisplayedTotals(False)
        End If

        Try
            If Me.dgvMarkupQuotes.Rows(0).Cells(1).Value = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try


        ''goes through all the columns to update the date
        For i As Integer = 1 To dgvMarkupQuotes.Columns.Count - 1
            Dim qty As Double = 0
            If Not IsDBNull(dgvMarkupQuotes.Rows(0).Cells(i).Value) Then
                qty = dgvMarkupQuotes.Rows(0).Cells(i).Value
            End If
            Dim toolTot As Double = 0D
            If Val(dgvMarkupQuotes.Rows(8).Cells(i).Value) > 0 Then
                toolTot = Val(dgvMarkupQuotes.Rows(8).Cells(i).Value)
            Else
                toolTot = Val(txtToolingCharge.Text)
            End If
            Dim setTot As Double = Val(txtSetupCharge.Text)

            Dim qcTot As Double = 0
            If qcTotalPassed <> -1 Then
                qcTot = qcTotalPassed
            Else
                qcTot = CalculateQC(False)
            End If
            Dim subTot As Double = 0
            Dim mark As Double = dgvMarkupQuotes.Rows(6).Cells(i).Value
            Dim prodTot As Double = Math.Round(origProdTot * 2.73, 2)

            ''check to make sure we aren't trying to divide by 0
            If qty > 0 Then
                If qty > 1000 Then
                    setTot = Math.Round(setTot / qty * 1000, 2)
                    toolTot = Math.Round(toolTot / qty * 1000, 2)
                Else
                    setTot = Math.Round(setTot, 2)
                    toolTot = Math.Round(toolTot, 2)
                End If
                subTot = prodTot + toolTot + setTot + Math.Round(qcTot / qty * 1000, 2)
            End If

            Dim quoteTot As Double = Math.Round(subTot * (mark / 100), 2)

            cmd = New SqlCommand("UPDATE QuoteMarkup SET Quantity = @Quantity, Production = @Production, Tools = @Tools, Setup = @Setup, QualityControl = @QualityControl, Total = @Total, Markup = @Markup, QuoteTotal = @QuoteTotal, ManualTool = @ManualTool WHERE QuoteID = @QuoteID AND QuoteNumber = @QuoteNumber;", con)

            With cmd.Parameters
                .Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
                .Add("@QuoteNumber", SqlDbType.TinyInt).Value = Val(dgvMarkupQuotes.Columns(i).Name)
                .Add("@Quantity", SqlDbType.Int).Value = qty
                .Add("@Production", SqlDbType.Float).Value = prodTot
                .Add("@Tools", SqlDbType.Float).Value = toolTot
                .Add("@Setup", SqlDbType.Float).Value = setTot
                .Add("@QualityControl", SqlDbType.Float).Value = qcTot
                .Add("@Total", SqlDbType.Float).Value = subTot
                .Add("@Markup", SqlDbType.Float).Value = mark
                .Add("@QuoteTotal", SqlDbType.Float).Value = quoteTot
                .Add("@ManualTool", SqlDbType.Float).Value = Val(dgvMarkupQuotes.Rows(8).Cells(i).Value)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
        isloaded = False
        LoadMarkupData()
        isloaded = True
    End Sub

    Private Function removeCurrencyFormat(ByVal str As String) As Double
        Dim noDollar As String = str.Replace("$", "")
        Return Val(noDollar.Replace(",", ""))
    End Function

    Private Sub txtToolingCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToolingCharge.TextChanged
        If isloaded Then
            UpdateDisplayedTotals()
        End If
    End Sub

    Private Sub txtSetupCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSetupCharge.TextChanged
        If isloaded Then
            UpdateDisplayedTotals()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        needsSaved = False
        isloaded = False
        ClearAll()
        clearDataGrids()
        CheckIfFOXCreated()
        isloaded = True
        cboQuoteNumber.Focus()
        Me.Text = "TFP Quote Form"
    End Sub

    Private Sub txtMaterialCostPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaterialCostPer.TextChanged
        If isloaded Then
            UpdateDisplayedTotals()
            UpdateMarkup()
        End If
    End Sub

    Private Sub dgvSegments_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvSegments.DataError
        If dgvSegments.Rows.Count > 0 Then
            If e.Exception.Message.ToString().Contains("Input string was not in a correct") Then
                MessageBox.Show("Numbers can only be in decimal form.", "Unable to update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvSegments.RefreshEdit()
            End If
        End If
    End Sub

    Private Sub cmdCreateEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateEntries.Click
        If canCreateEntries() Then
            SaveQuotation(txtPreparedBy.Text)
            SaveOperations()
            cmd = New SqlCommand("UPDATE Quotation SET FOXItemCreated = 'True' WHERE QuoteID = @QuoteID;", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Dim selectNxtForm As New TFPQuoteSelectNextForm()
            If Not selectNxtForm.Created Then
                selectNxtForm.CreateControl()
            End If

            'adds the part entry into ItemList
            Dim fox As String = addPartNumber(selectNxtForm)
            If fox <> "0" Then
                selectNxtForm.lblItemMaintenance.Visible = False
                selectNxtForm.cmdItemMaintenance.Visible = False
            End If
            createFOXEntry(fox)
            selectNxtForm.Controls("lblFOXCreated").Text = "FOX #" + fox + " created"
            If cboCustomerID.SelectedIndex = -1 Then
                addCustomerEntry()
                selectNxtForm.lblCustomerMaintenance.Visible = True
                selectNxtForm.cmdCustomerMaintenance.Visible = True
                selectNxtForm.Controls("lblCustomerCreated").Text = "Customer ID " + cboCustomerID.Text + " created"
            Else
                selectNxtForm.Controls("lblCustomerCreated").Text = ""
            End If
            ''adds the purchasing contact as long as there is not one existing currently for the PURCHASING Department in Contacts for the customer
            If Not String.IsNullOrEmpty(txtContactName.Text) Then
                addPurchasingContact()
            End If

            Dim nxtForm As New System.Windows.Forms.Form
            Select Case selectNxtForm.ShowDialog()
                Case System.Windows.Forms.DialogResult.Retry
                    GlobalCustomerID = cboCustomerID.Text
                    nxtForm = New CustomerData()
                Case System.Windows.Forms.DialogResult.OK
                    GlobalFOXNumber = Val(fox)
                    GlobalDivisionCode = cboDivisionID.Text
                    nxtForm = New FOXMenu()
                Case System.Windows.Forms.DialogResult.No
                    If String.IsNullOrEmpty(txtTFPPartNo.Text) Then
                        GlobalItemListingPartNumber = txtCustPartNo.Text
                    Else
                        GlobalItemListingPartNumber = txtTFPPartNo.Text
                    End If
                    nxtForm = New ItemMaintenance()
                Case Else
                    selectNxtForm.Dispose()
                    Exit Sub
            End Select

            nxtForm.Parent = Me.ParentForm
            nxtForm.Show()
            Me.Hide()
            needsSaved = False
            isloaded = False
            ClearAll()
            clearDataGrids()
            isloaded = True
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Function canCreateEntries() As Boolean
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must Select a Quote Number", "Select a Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCustPartNo.Text) Then
            If String.IsNullOrEmpty(txtTFPPartNo.Text) Then
                MessageBox.Show("You must specify either a Customer Part Number or TFP Part Number", "Enter a Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustPartNo.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must Select a Customer ID", "Select a Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerName.Text) Then
            MessageBox.Show("You must Select a Customer Name", "Select a Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub createFOXEntry(ByRef fox As String)
        Dim fx As Integer = 10000
        If EmployeeCompanyCode.Equals("TWD") Then
            cmd = New SqlCommand("DECLARE @FOXNumber int = (SELECT isnull(MAX(FOXNumber) + 1, 1) FROM FOXTable WHERE DivisionID = 'TWD');" _
                                 + " IF @FOXNumber = 13999 SET @FOXNumber = 50000;" _
                                 + " Insert Into FOXTable(FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, Status, BoxType, CustomerID, ProductionQuantity, PromiseDate, OrderReferenceNumber, BlueprintRevision, Locked, QuoteNumber, QuotePrice)" _
                             + " VALUES (@FOXNumber, @RMID, @PartNumber, @BlueprintNumber, @DivisionID, @RawMaterialWeight, @FinishedWeight, @ScrapWeight, @FluxLoadNumber, @CreationDate, @Comments, @CertificationType, @Status, @BoxType, @CustomerID, (SELECT TOP 1 Quantity FROM QuoteMarkup WHERE QuoteID = @QuoteNumber), @PromiseDate, @OrderReferenceNumber, @BlueprintRevision, '', @QuoteNumber, CASE WHEN (SELECT TOP 1 QuoteTotal FROM QuoteMarkup WHERE QuoteID = @QuoteNumber) >= 0 THEN (SELECT TOP 1 ROUND(CASE WHEN Quantity > 0 THEN (QuoteTotal / Quantity) ELSE 0 END, 4) FROM QuoteMarkup WHERE QuoteID = @QuoteNumber) ELSE (SELECT 0) END);" _
                             + " SELECT @FOXNumber;", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = ""
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtCustPartNo.Text
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = "0"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = txtStartWeight.Text
                .Add("@FinishedWeight", SqlDbType.VarChar).Value = txtFinishedWeight.Text
                .Add("@ScrapWeight", SqlDbType.VarChar).Value = txtScrapWeight.Text
                .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = ""
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString()
                .Add("@Comments", SqlDbType.VarChar).Value = txtNotes.Text
                .Add("@CertificationType", SqlDbType.VarChar).Value = 0
                .Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
                .Add("@BoxType", SqlDbType.VarChar).Value = ""
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@PromiseDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString
                .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = 0
                .Add("@BlueprintRevision", SqlDbType.VarChar).Value = ""
                .Add("@Locked", SqlDbType.VarChar).Value = ""
                .Add("@QuoteNumber", SqlDbType.VarChar).Value = cboQuoteNumber.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                fx = cmd.ExecuteScalar()
            Catch ex As System.Exception
                sendErrorToDataBase("TFPQuoteForm - CreateFOXEntry --Error inserting into FOXTable FOX #" + fx.ToString(), "Quote #" + cboQuoteNumber.Text, ex.ToString())
                MessageBox.Show("There was an issue creating the FOX. Contact system admin", "Unable to insert FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try


        Else
            Dim oldFOX As Integer = 0
            cmd = New SqlCommand("SELECT isnull(MAX(FOXNumber), 0) as FOXNumber FROM FOXTable WHERE DivisionID = 'TFP' AND QuoteNumber = @QuoteNumber;", con)
            cmd.Parameters.Add("@QuoteNumber", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                oldFOX = cmd.ExecuteScalar()
            Catch ex As System.Exception

            End Try
            If oldFOX <> 0 Then
                cmd = New SqlCommand("DECLARE @FOXNumber int = (SELECT isnull(MAX(FOXNumber) + 1, 14001) as FOXNumber FROM FOXTable WHERE DivisionID = 'TFP'), @EntryNumber int = (SELECT MAX(EntryNumber) FROM FOXOutsideOperations);" _
                                    + " Insert Into FOXTable(FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, Status, BoxType, CustomerID, ProductionQuantity, PromiseDate, OrderReferenceNumber, BlueprintRevision, Locked, QuoteNumber, QuotePrice)" _
                                    + " SELECT @FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CURRENT_TIMESTAMP, '', CertificationType, 'ACTIVE', BoxType, CustomerID, ProductionQuantity, PromiseDate, 0, BlueprintRevision, '', QuoteNumber, QuotePrice FROM FOXTable WHERE FOXNumber = @OldFOXNumber" _
                                    + " INSERT INTO FOXSched (FOXNumber, ProcessStep, ProcessID, ProcessRemoveRM, ProcessAddFG)" _
                                    + " SELECT @FOXNumber, ProcessStep, ProcessID, ProcessRemoveRM, ProcessAddFG FROM FOXSched WHERE FOXNumber = @OldFOXNumber" _
                                    + " INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status)" _
                                    + " VALUES (80316, @FOXNumber, CURRENT_TIMESTAMP, 0, 'OPEN')" _
                                    + " INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG)" _
                                    + " SELECT 80316, @FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @OldFOXNumber" _
                                    + " INSERT INTO FOXCertifications (FOXNumber, Certification)" _
                                    + " SELECT @FOXNumber, Certification FROM FOXCertifications WHERE FOXNumber = @OldFOXNumber" _
                                    + " INSERT INTO FOXOutsideOperations (FOXNumber, Vendor, Operation, TurnAround, ProcessStep, EntryNumber)" _
                                    + " SELECT @FOXNumber, Vendor, Operation, TurnAround, ProcessStep, @EntryNumber FROM FOXOutsideOperations WHERE FOXNumber = @OldFOXNumber" _
                                    + " SELECT @FOXNumber;", con)
                cmd.Parameters.Add("@OldFOXNumber", SqlDbType.Int).Value = oldFOX
                Try
                    fx = cmd.ExecuteScalar()
                Catch ex As System.Exception
                    sendErrorToDataBase("TFPQuoteForm - CreateFOXEntry --Error inserting into FOXTable FOX #" + fx.ToString(), "Quote #" + cboQuoteNumber.Text, ex.ToString())
                    MessageBox.Show("There was an issue creating the FOX. Contact system admin", "Unable to insert FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            Else
                cmd = New SqlCommand("DECLARE @FOXNumber int = (SELECT isnull(MAX(FOXNumber) + 1, 14001) as FOXNumber FROM FOXTable WHERE DivisionID = 'TFP');" _
                                     + " Insert Into FOXTable(FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, Status, BoxType, CustomerID, ProductionQuantity, PromiseDate, OrderReferenceNumber, BlueprintRevision, Locked, QuoteNumber, QuotePrice)" _
                                 + " VALUES (@FOXNumber, @RMID, @PartNumber, @BlueprintNumber, @DivisionID, @RawMaterialWeight, @FinishedWeight, @ScrapWeight, @FluxLoadNumber, @CreationDate, @Comments, @CertificationType, @Status, @BoxType, @CustomerID, (SELECT TOP 1 Quantity FROM QuoteMarkup WHERE QuoteID = @QuoteNumber), @PromiseDate, @OrderReferenceNumber, @BlueprintRevision, '', @QuoteNumber, CASE WHEN (SELECT TOP 1 QuoteTotal FROM QuoteMarkup WHERE QuoteID = @QuoteNumber) >= 0 THEN (SELECT TOP 1 ROUND(CASE WHEN Quantity > 0 THEN (QuoteTotal / Quantity) ELSE 0 END, 4) FROM QuoteMarkup WHERE QuoteID = @QuoteNumber) ELSE (SELECT 0) END);" _
                                 + " SELECT @FOXNumber;", con)
                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = ""
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtCustPartNo.Text
                    .Add("@BlueprintNumber", SqlDbType.VarChar).Value = "0"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = txtStartWeight.Text
                    .Add("@FinishedWeight", SqlDbType.VarChar).Value = txtFinishedWeight.Text
                    .Add("@ScrapWeight", SqlDbType.VarChar).Value = txtScrapWeight.Text
                    .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = ""
                    .Add("@CreationDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString()
                    .Add("@Comments", SqlDbType.VarChar).Value = txtNotes.Text
                    .Add("@CertificationType", SqlDbType.VarChar).Value = 0
                    .Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
                    .Add("@BoxType", SqlDbType.VarChar).Value = ""
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@PromiseDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString
                    .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = 0
                    .Add("@BlueprintRevision", SqlDbType.VarChar).Value = ""
                    .Add("@Locked", SqlDbType.VarChar).Value = ""
                    .Add("@QuoteNumber", SqlDbType.VarChar).Value = cboQuoteNumber.Text
                End With
                Try
                    fx = cmd.ExecuteScalar()
                Catch ex As System.Exception
                    sendErrorToDataBase("TFPQuoteForm - CreateFOXEntry --Error inserting into FOXTable FOX #" + fx.ToString(), "Quote #" + cboQuoteNumber.Text, ex.ToString())
                    MessageBox.Show("There was an issue creating the FOX. Contact system admin", "Unable to insert FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End If

        
        'With cmd.Parameters
        '    .Add("@RMID", SqlDbType.VarChar).Value = ""
        '    .Add("@PartNumber", SqlDbType.VarChar).Value = txtCustPartNo.Text
        '    .Add("@BlueprintNumber", SqlDbType.VarChar).Value = "0"
        '    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        '    .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = txtStartWeight.Text
        '    .Add("@FinishedWeight", SqlDbType.VarChar).Value = txtFinishedWeight.Text
        '    .Add("@ScrapWeight", SqlDbType.VarChar).Value = txtScrapWeight.Text
        '    .Add("@FluxLoadNumber", SqlDbType.VarChar).Value = ""
        '    .Add("@CreationDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString()
        '    .Add("@Comments", SqlDbType.VarChar).Value = txtNotes.Text
        '    .Add("@CertificationType", SqlDbType.VarChar).Value = 0
        '    .Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        '    .Add("@BoxType", SqlDbType.VarChar).Value = ""
        '    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        '    .Add("@PromiseDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString
        '    .Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = 0
        '    .Add("@BlueprintRevision", SqlDbType.VarChar).Value = ""
        '    .Add("@Locked", SqlDbType.VarChar).Value = ""
        '    .Add("@QuoteNumber", SqlDbType.VarChar).Value = cboQuoteNumber.Text
        'End With
        'Try
        '    If con.State = ConnectionState.Closed Then con.Open()
        '    fx = cmd.ExecuteScalar()
        'Catch ex As System.Exception
        '    sendErrorToDataBase("TFPQuoteForm - CreateFOXEntry --Error inserting into FOXTable FOX #" + fx.ToString(), "Quote #" + cboQuoteNumber.Text, ex.ToString())
        '    MessageBox.Show("There was an issue creating the FOX. Contact system admin", "Unable to insert FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End Try
        'If fox <> "0" Then
        '    'Copies the FOX data from the old FOX to the new FOX
        '    cmd = New SqlCommand("Insert Into FOXTable(FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, Status, BoxType, CustomerID, ProductionQuantity, PromiseDate, OrderReferenceNumber, BlueprintRevision, Locked, QuoteNumber, QuotePrice) SELECT @FOXNumber, RMID, PartNumber, BlueprintNumber, DivisionID, RawMaterialWeight, FinishedWeight, ScrapWeight, FluxLoadNumber, CreationDate, Comments, CertificationType, 'ACTIVE', BoxType, CustomerID, (SELECT TOP 1 Quantity FROM QuoteMarkup WHERE QuoteID = @QuoteID), PromiseDate, OrderReferenceNumber, BlueprintRevision, '', QuoteNumber, (SELECT TOP 1 QuoteTotal FROM QuoteMarkup WHERE QuoteID = @QuoteID ORDER BY Quantity ASC) FROM FOXTable WHERE FOXNumber = @OldFOXNumber", con)
        '    With cmd.Parameters
        '        .Add("@FOXNumber", SqlDbType.VarChar).Value = fx.ToString()
        '        .Add("@OldFOXNumber", SqlDbType.VarChar).Value = fox
        '        .Add("@QuoteID", SqlDbType.VarChar).Value = cboQuoteNumber.Text
        '    End With
        '    Try
        '        If con.State = ConnectionState.Closed Then con.Open()
        '        cmd.ExecuteNonQuery()
        '        con.Close()
        '    Catch ex As System.Exception
        '        con.Close()
        '        sendErrorToDataBase("TFPQuoteForm - CreateFOXEntry --Error inserting into FOXTable", "FOX #" + fx.ToString(), ex.ToString())
        '    End Try
        '    ''copies over the rows in the FOXSched to the new FOX
        '    cmd = New SqlCommand("INSERT INTO FOXSched (FOXNumber, ProcessStep, ProcessID, ProcessRemoveRM, ProcessAddFG) SELECT @FOXNumber, ProcessStep, ProcessID, ProcessRemoveRM, ProcessAddFG FROM FOXSched WHERE FOXNumber = @OldFOXNumber", con)
        '    cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = fx
        '    cmd.Parameters.Add("@OldFOXNumber", SqlDbType.Int).Value = fox

        '    If con.State = ConnectionState.Closed Then con.Open()
        '    cmd.ExecuteNonQuery()
        '    con.Close()
        'Else

        'End If

        ''updates the Item in Item Maintenance so that the FOX Number is linked in there
        cmd = New SqlCommand("UPDATE ItemList SET FOXNumber = @FOXNumber WHERE ItemID = @ItemID AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = fx
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If fox = "0" Then
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtCustPartNo.Text
        Else
            If String.IsNullOrEmpty(txtTFPPartNo.Text) Then
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtCustPartNo.Text
            Else
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtTFPPartNo.Text
            End If
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        fox = fx
    End Sub

    Private Function addPartNumber(ByRef frm As System.Windows.Forms.Form) As String
        Dim fox As String = "0"

        cmd = New SqlCommand("SELECT COUNT(FOXNumber) as ItemCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID;", con)
        If Not String.IsNullOrEmpty(txtCustPartNo.Text) Then
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtCustPartNo.Text
        Else
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtTFPPartNo.Text
        End If

        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("ItemCount")) Then
                fox = reader.Item("ItemCount").ToString()
            End If
        End If
        reader.Close()

        If fox = "0" Then
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("Insert Into ItemList(ItemID, DivisionID, ShortDescription, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, PieceWeight, BoxCount, PalletCount, StandardCost, StandardPrice, OldPartNumber, MinimumStock, MaximumStock, CreationDate, BeginningBalance, BoxType, NominalDiameter, NominalLength, AddAccessory, PreferredVendor, Locked)Values(@ItemID, @DivisionID, @ShortDescription, @LongDescription, @ItemClass, @PurchProdLineID, @SalesProdLineID, @PieceWeight, @BoxCount, @PalletCount, @StandardCost, @StandardPrice, @OldPartNumber, @MinimumStock, @MaximumStock, @CreationDate, @BeginningBalance, @BoxType, @NominalDiameter, @NominalLength, @AddAccessory, @PreferredVendor, @Locked);", con)
            If Not String.IsNullOrEmpty(txtCustPartNo.Text) Then
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtCustPartNo.Text
            Else
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtTFPPartNo.Text
            End If
            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ShortDescription", SqlDbType.VarChar).Value = txtPartSize.Text
                .Add("@LongDescription", SqlDbType.VarChar).Value = txtPartDescription.Text
                .Add("@ItemClass", SqlDbType.VarChar).Value = "Trufit Parts"
                .Add("@PurchProdLineID", SqlDbType.VarChar).Value = "TFP-MANUFACTUREDPRODUCTS"
                .Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SPL-TFP"
                .Add("@PieceWeight", SqlDbType.VarChar).Value = Math.Round(Val(txtFinishedWeight.Text) / 1000, 4)
                .Add("@BoxCount", SqlDbType.VarChar).Value = 0
                .Add("@PalletCount", SqlDbType.VarChar).Value = 0
                .Add("@StandardCost", SqlDbType.VarChar).Value = 0
                .Add("@StandardPrice", SqlDbType.VarChar).Value = 0
                .Add("@OldPartNumber", SqlDbType.VarChar).Value = ""
                .Add("@MinimumStock", SqlDbType.VarChar).Value = 0
                .Add("@MaximumStock", SqlDbType.VarChar).Value = 0
                .Add("@CreationDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString()
                .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
                .Add("@BoxType", SqlDbType.VarChar).Value = "Z"
                .Add("@NominalDiameter", SqlDbType.VarChar).Value = 0
                .Add("@NominalLength", SqlDbType.VarChar).Value = 0
                .Add("@AddAccessory", SqlDbType.VarChar).Value = "NO"
                .Add("@PreferredVendor", SqlDbType.VarChar).Value = "AMERICAN"
                .Add("@Locked", SqlDbType.VarChar).Value = ""
            End With
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                con.Close()
                sendErrorToDataBase("TFPQuoteForm - addPartNumber --Error inserting into ItemList", "Part #" + txtCustPartNo.Text, ex.ToString())
            End Try
            frm.Controls("lblPartCreated").Text = "Part # " + txtCustPartNo.Text + " created"
        Else
            cmd = New SqlCommand("IF ((SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID) = 'DEACTIVATED-PART') UPDATE ItemList SET ItemClass = 'Trufit Parts' WHERE ItemID = @ItemID AND DivisionID = @DivisionID;", con)
            If String.IsNullOrEmpty(txtTFPPartNo.Text) Then
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtCustPartNo.Text
            Else
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtTFPPartNo.Text
            End If
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                cmd.ExecuteNonQuery()
            Catch ex As System.Exception
                sendErrorToDataBase("TFPQuoteForm - addPartNumber --Error reactivating part.", "Part #" + txtCustPartNo.Text, ex.ToString())
            End Try

            con.Close()

            frm.Controls("lblPartCreated").Text = ""
            frm.Controls("cmdItemMaintenance").Visible = False
            frm.Controls("lblItemMaintenance").Visible = False
        End If
        Return fox
    End Function

    Private Sub addCustomerEntry()
        'Create command to insert new record into database
        cmd = New SqlCommand("IF NOT EXISTS(SELECT CustomerID FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID) INSERT INTO CustomerList (CustomerID, CustomerName, CustomerDate, DivisionID, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, Comments, PaymentTerms, CreditLimit, SalesTaxRate, PreferredShipper, OldCustomerNumber, CustomerClass, SalesTerritory, ShippingDetails, OnHoldStatus, APContactName, APPhoneNumber, APFAXNumber, APEmailAddress, InvoiceEmail, SalesTaxRate2, SalesTaxRate3, SalesTaxID, AccountingHold)Values(@CustomerID, @CustomerName, @CustomerDate, @DivisionID, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @BillToAddress1, @BillToAddress2, @BillToCity, @BillToState, @BillToZip, @BillToCountry, @Comments, @PaymentTerms, @CreditLimit, @SalesTaxRate, @PreferredShipper, @OldCustomerNumber, @CustomerClass, @SalesTerritory, @ShippingDetails, @OnHoldStatus, @APContactName, @APPhoneNumber, @APFAXNumber, @APEmailAddress, @InvoiceEmail, @SalesTaxRate2, @SalesTaxRate3, @SalesTaxID, @AccountingHold);", con)

        With cmd.Parameters
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
            .Add("@CustomerDate", SqlDbType.VarChar).Value = Today.Date.ToShortDateString()
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = ""
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = ""
            .Add("@ShipToCity", SqlDbType.VarChar).Value = ""
            .Add("@ShipToState", SqlDbType.VarChar).Value = ""
            .Add("@ShipToZip", SqlDbType.VarChar).Value = ""
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = ""
            .Add("@BillToAddress1", SqlDbType.VarChar).Value = ""
            .Add("@BillToAddress2", SqlDbType.VarChar).Value = ""
            .Add("@BillToCity", SqlDbType.VarChar).Value = ""
            .Add("@BillToState", SqlDbType.VarChar).Value = ""
            .Add("@BillToZip", SqlDbType.VarChar).Value = ""
            .Add("@BillToCountry", SqlDbType.VarChar).Value = ""
            .Add("@Comments", SqlDbType.VarChar).Value = txtNotes.Text
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
            .Add("@CreditLimit", SqlDbType.VarChar).Value = 0
            .Add("@SalesTaxRate", SqlDbType.VarChar).Value = 0
            .Add("@PreferredShipper", SqlDbType.VarChar).Value = ""
            .Add("@OldCustomerNumber", SqlDbType.VarChar).Value = ""
            .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
            .Add("@SalesTerritory", SqlDbType.VarChar).Value = ""
            .Add("@ShippingDetails", SqlDbType.VarChar).Value = txtDeliveryRequirements.Text
            .Add("@OnHoldStatus", SqlDbType.VarChar).Value = "YES"
            .Add("@APContactName", SqlDbType.VarChar).Value = ""
            .Add("@APPhoneNumber", SqlDbType.VarChar).Value = ""
            .Add("@APFAXNumber", SqlDbType.VarChar).Value = ""
            .Add("@APEmailAddress", SqlDbType.VarChar).Value = ""
            .Add("@InvoiceEmail", SqlDbType.VarChar).Value = ""
            .Add("@SalesTaxRate2", SqlDbType.VarChar).Value = 0
            .Add("@SalesTaxRate3", SqlDbType.VarChar).Value = 0
            .Add("@SalesTaxID", SqlDbType.VarChar).Value = ""
            .Add("@AccountingHold", SqlDbType.VarChar).Value = 0
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub addPurchasingContact()
        cmd = New SqlCommand("SELECT COUNT(CustomerID) FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ContactDepartment = 'PURCHASING';", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = txtContactName.Text
        cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = txtEmail.Text
        cmd.Parameters.Add("@ContactFax", SqlDbType.VarChar).Value = txtFax.Text

        If String.IsNullOrEmpty(txtPhoneExtension.Text) Then
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = txtPhone.Text
        Else
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = txtPhone.Text + "x" + txtPhoneExtension.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ''check to see if the purchasing contact exists
        If cmd.ExecuteScalar() > 0 Then
            ''check to see if the user wants to update the contact data for the customer's purchasing department
            If MessageBox.Show("CustomerID already has a Purchasing contact, do you wish to update it with information from the quote?", "Update Purchasing contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                cmd.CommandText = "UPDATE CustomerContacts SET CustomerName = @CustomerName, ContactEmail = @ContactEmail, ContactPhone = @ContactPhone, ContactFax = @ContactFax WHERE CustomerID = @CustomerID AND ContactDepartment = 'PURCHASING' AND DivisionID = @DivisionID;"
            Else
                Dim cnt As Integer = 1
                cmd.CommandText = "SELECT COUNT(CustomerID) FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ContactDepartment = 'PURCHASING" + cnt.ToString() + "';"
                ''will keep lookign for an open purchasing dept until one is found
                While cmd.ExecuteScalar() > 0
                    cnt += 1
                    cmd.CommandText = "SELECT COUNT(CustomerID) FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ContactDepartment = 'PURCHASING" + cnt.ToString() + "';"
                End While
                cmd.CommandText = "IF Not EXISTS(SELECT TOP 1 ContactName FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ContactDepartment like 'PURCHASING%' AND ContactName = @ContactName) INSERT INTO CustomerContacts (ContactName, ContactEmail, ContactPhone, ContactFax, CustomerID, ContactDepartment, DivisionID) VALUES (@ContactName, @ContactEmail, @ContactPhone, @ContactFax, @CustomerID, 'PURCHASING" + cnt.ToString() + "', @DivisionID);"
                cmd.ExecuteNonQuery()
            End If
        Else
            cmd.CommandText = "IF NOT EXISTS(SELECT CustomerID FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID) INSERT INTO CustomerList (CustomerID, DivisionID, Comments, PaymentTerms, CustomerClass, ShippingDetails, OnHoldStatus) VALUES(@CustomerID, @DivisionID, @Comments, 'N30', 'STANDARD', @ShippingDetails, 'YES'); INSERT INTO CustomerContacts (ContactName, ContactEmail, ContactPhone, ContactFax, CustomerID, ContactDepartment, DivisionID) VALUES (@ContactName, @ContactEmail, @ContactPhone, @ContactFax, @CustomerID, 'PURCHASING', @DivisionID);"
            With cmd.Parameters
                .Add("@Comments", SqlDbType.VarChar).Value = txtNotes.Text
                .Add("@ShippingDetails", SqlDbType.VarChar).Value = txtDeliveryRequirements.Text
            End With
            cmd.ExecuteNonQuery()
        End If
        con.Close()
    End Sub

    ''changes the names of the columns for the different dimensions based on the shape that is selected
    Private Sub dgvSegments_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSegments.SelectionChanged
        If isloaded Then
            If dgvSegments.Rows.Count > 0 Then
                If Not dgvSegments.CurrentRow Is Nothing Then
                    Select Case dgvSegments.CurrentRow.Cells("SegShape").Value
                        Case "None"
                        Case "Round"
                            dgvSegments.Columns("Dim1").HeaderText = "Diameter"
                            dgvSegments.Columns("Dim1").ReadOnly = False
                            dgvSegments.Columns("Dim2").HeaderText = "Length"
                            dgvSegments.Columns("Dim2").ReadOnly = False
                            dgvSegments.Columns("Dim3").HeaderText = "N/A"
                            dgvSegments.Columns("Dim3").ReadOnly = False
                            dgvSegments.Columns("SegWt").ReadOnly = True
                        Case "Hex"
                            dgvSegments.Columns("Dim1").HeaderText = "Cross"
                            dgvSegments.Columns("Dim1").ReadOnly = False
                            dgvSegments.Columns("Dim2").HeaderText = "Length"
                            dgvSegments.Columns("Dim2").ReadOnly = False
                            dgvSegments.Columns("Dim3").HeaderText = "N/A"
                            dgvSegments.Columns("Dim3").ReadOnly = False
                            dgvSegments.Columns("SegWt").ReadOnly = True
                        Case "Square"
                            dgvSegments.Columns("Dim1").HeaderText = "Side"
                            dgvSegments.Columns("Dim1").ReadOnly = False
                            dgvSegments.Columns("Dim2").HeaderText = "Length"
                            dgvSegments.Columns("Dim2").ReadOnly = False
                            dgvSegments.Columns("Dim3").HeaderText = "N/A"
                            dgvSegments.Columns("Dim3").ReadOnly = False
                            dgvSegments.Columns("SegWt").ReadOnly = True
                        Case "Penta"
                            dgvSegments.Columns("Dim1").HeaderText = "Side"
                            dgvSegments.Columns("Dim1").ReadOnly = False
                            dgvSegments.Columns("Dim2").HeaderText = "Length"
                            dgvSegments.Columns("Dim2").ReadOnly = False
                            dgvSegments.Columns("Dim3").HeaderText = "N/A"
                            dgvSegments.Columns("Dim3").ReadOnly = False
                            dgvSegments.Columns("SegWt").ReadOnly = True
                        Case "Carriage"
                            dgvSegments.Columns("Dim1").HeaderText = "Diameter"
                            dgvSegments.Columns("Dim1").ReadOnly = False
                            dgvSegments.Columns("Dim2").HeaderText = "Length"
                            dgvSegments.Columns("Dim2").ReadOnly = False
                            dgvSegments.Columns("Dim3").HeaderText = "N/A"
                            dgvSegments.Columns("Dim3").ReadOnly = False
                            dgvSegments.Columns("SegWt").ReadOnly = True
                        Case "Rectangular"
                            dgvSegments.Columns("Dim1").HeaderText = "Short"
                            dgvSegments.Columns("Dim1").ReadOnly = False
                            dgvSegments.Columns("Dim2").HeaderText = "Length"
                            dgvSegments.Columns("Dim2").ReadOnly = False
                            dgvSegments.Columns("Dim3").HeaderText = "Long"
                            dgvSegments.Columns("Dim3").ReadOnly = False
                            dgvSegments.Columns("SegWt").ReadOnly = True
                        Case "Known Weight"
                            dgvSegments.Columns("Dim1").HeaderText = "N/A"
                            dgvSegments.Columns("Dim1").ReadOnly = True
                            dgvSegments.Columns("Dim2").HeaderText = "N/A"
                            dgvSegments.Columns("Dim2").ReadOnly = True
                            dgvSegments.Columns("Dim3").HeaderText = "N/A"
                            dgvSegments.Columns("Dim3").ReadOnly = True
                            dgvSegments.Columns("SegWt").ReadOnly = False
                        Case "Remove Mat."
                            dgvSegments.Columns("Dim1").HeaderText = "Diameter"
                            dgvSegments.Columns("Dim1").ReadOnly = False
                            dgvSegments.Columns("Dim2").HeaderText = "Length"
                            dgvSegments.Columns("Dim2").ReadOnly = False
                            dgvSegments.Columns("Dim3").HeaderText = "N/A"
                            dgvSegments.Columns("Dim3").ReadOnly = False
                            dgvSegments.Columns("SegWt").ReadOnly = True
                    End Select
                End If

            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        SaveQuotation(txtPreparedBy.Text)
        SaveOperations()

        GlobalTFPQuoteNumber = Val(cboQuoteNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewPrintTFQuote As New PrintTFQuote()
        NewPrintTFQuote.ShowDialog()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDelete() Then
            cmd = New SqlCommand("DELETE FROM Quotation WHERE QuoteID = @QuoteID;", con)
            cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM QuoteMarkup WHERE QuoteID = @QuoteID;"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM QuoteOperations WHERE QuoteID = @QuoteID;"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM QuoteOther WHERE QuoteID = @QuoteID;"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM QuoteSegments WHERE QuoteID = @QuoteID;"
            cmd.ExecuteNonQuery()
            con.Close()
            isloaded = False
            LoadQuoteNumbers()
            ClearAll()
            clearDataGrids()
            isloaded = True
            cboQuoteNumber.Focus()
            Me.Text = "TFP Quote Form"
        End If
    End Sub

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must Select a Quote Number", "Select a Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote Number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        If FOXCreated() Then
            MessageBox.Show("There was a FOX and/or Part Entry created by this Quote, it can't be Deleted", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to Delete this Quote?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub nbrCertificateOfCompliance_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrCertificateOfCompliance.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(115)
            UpdateQCList(nbrCertificateOfCompliance.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrNylonPatch_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrNylonPatch.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(116)
            UpdateQCList(nbrNylonPatch.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrChemistry_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrChemistry.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(117)
            UpdateQCList(nbrChemistry.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrMillCertification_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrMillCertification.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(118)
            UpdateQCList(nbrMillCertification.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrCertificationRequired_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrCertificationRequired.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(119)
            UpdateQCList(nbrCertificationRequired.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrSamplesRequired_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrSamplesRequired.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(120)
            UpdateQCList(nbrSamplesRequired.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrSPCRequired_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrSPCRequired.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(121)
            UpdateQCList(nbrSPCRequired.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrDimensional_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrDimensional.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(122)
            UpdateQCList(nbrDimensional.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrPlating_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrPlating.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(123)
            UpdateQCList(nbrPlating.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrMagParticle_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrMagParticle.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(124)
            UpdateQCList(nbrMagParticle.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrISIR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrISIR.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(125)
            UpdateQCList(nbrISIR.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrPPap_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrPPap.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(126)
            UpdateQCList(nbrPPap.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrSurfaceandCore_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrSurfaceandCore.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(107)
            UpdateQCList(nbrSurfaceandCore.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrMicroCaseDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrMicroCaseDepth.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(108)
            UpdateQCList(nbrMicroCaseDepth.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrMicroDecarb_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrMicroDecarb.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(109)
            UpdateQCList(nbrMicroDecarb.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrFurnaceChartCopy_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrFurnaceChartCopy.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(110)
            UpdateQCList(nbrFurnaceChartCopy.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub nbrTWDTensile_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrTWDTensile.ValueChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(114)
            UpdateQCList(nbrTWDTensile.Value, op)
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub UpdateQCList(ByVal times As Integer, ByVal op As OperationData)
        op.times = times
        For i As Integer = 0 To QCList.Count - 1
            If QCList(i).key = op.key Then
                If times > 0 Then
                    QCList(i).MachineCost = op.MachineCost * times
                    Exit Sub
                Else
                    QCList.RemoveAt(i)
                    Exit Sub
                End If
            End If
        Next
        If times > 0 Then
            QCList.Add(op)
        End If
    End Sub

    Private Function CalculateQC(Optional ByVal canUpdateMarkup As Boolean = True) As Double
        Dim total As Double = 0
        For i As Integer = 0 To QCList.Count - 1
            total += QCList(i).MachineCost * QCList(i).times
        Next
        If canUpdateMarkup Then
            UpdateMarkup(-1, total)
        End If
        Return total
    End Function

    Private Sub nbrBarFeed_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrBarFeed.ValueChanged
        If isloaded Then
            UpdateAddToList(127, nbrBarFeed.Value, GetOperationData(127))
            shouldSave = True
        End If
    End Sub

    Private Sub nbrHaasMill_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrHaasMill.ValueChanged
        If isloaded Then
            UpdateAddToList(128, nbrHaasMill.Value, GetOperationData(128))
            shouldSave = True
        End If
    End Sub

    Private Sub chkPicklePlate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPicklePlate.CheckedChanged
        If isloaded Then
            If chkPicklePlate.Checked Then
                Dim op As OperationData = GetOperationData(129)
                op.MachineCost *= (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(129, 1, op)
            Else
                UpdateAddToList(129, 0, GetOperationData(129))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkNickelPlating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNickelPlating.CheckedChanged
        If isloaded Then
            If chkNickelPlating.Checked Then
                Dim op As OperationData = GetOperationData(131)
                op.MachineCost *= (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(131, 1, op)
            Else
                UpdateAddToList(131, 0, GetOperationData(131))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub chkBake_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBake.CheckedChanged
        If isloaded Then
            If chkBake.Checked Then
                Dim op As OperationData = GetOperationData(130)
                op.MachineCost *= (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                UpdateAddToList(130, 1, op)
            Else
                UpdateAddToList(130, 0, GetOperationData(130))
            End If
            shouldSave = True
        End If
    End Sub

    Private Sub rdoSaltSprayNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSaltSprayNone.CheckedChanged
        If isloaded Then
            nbrSaltSprayAdditionalHours.Value = 0
            nbrSaltSprayQuantity.Value = 1
            removeSaltSpray()
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub removeSaltSpray()
        Dim i As Integer = 0
        While i < QCList.Count - 1
            If QCList(i).MachineType.Contains("Salt Spray") Then
                QCList.RemoveAt(i)
            Else
                i += 1
            End If
        End While
    End Sub

    Private Sub chkOutsideHTCertification_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOutsideHTCertification.CheckedChanged
        If isloaded Then
            Dim op As OperationData = GetOperationData(132)
            If chkOutsideHTCertification.Checked Then
                UpdateQCList(1, op)
            Else
                UpdateQCList(0, op)
            End If
            CalculateQC()
            shouldSave = True
        End If
    End Sub

    Private Sub dgvOtherOperations_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvOtherOperations.VisibleChanged
        If isloaded Then
            setupdgvOther()
            totaldgvOther()
        End If
    End Sub

    Private Sub dgvOtherOperations_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvOtherOperations.Sorted
        If isloaded Then
            setupdgvOther()
            totaldgvOther()
        End If
    End Sub

    Private Sub txtScrapWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScrapWeight.TextChanged
        If isloaded Then
            'UpdateMaterialCost()
            UpdateDisplayedTotals()
        End If
    End Sub

    Private Sub nbrSaltSprayQuantity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrSaltSprayQuantity.ValueChanged

        Select Case True
            Case rdo24Hours.Checked
                UpdateQCList(nbrSaltSprayQuantity.Value, GetOperationData(100))
            Case rdo48Hours.Checked
                UpdateQCList(nbrSaltSprayQuantity.Value, GetOperationData(101))
            Case rdo72Hours.Checked
                UpdateQCList(nbrSaltSprayQuantity.Value, GetOperationData(102))
            Case rdo96Hours.Checked
                UpdateQCList(nbrSaltSprayQuantity.Value, GetOperationData(103))
            Case rdo120Hours.Checked
                UpdateQCList(nbrSaltSprayQuantity.Value, GetOperationData(104))
            Case rdo168Hours.Checked
                UpdateQCList(nbrSaltSprayQuantity.Value, GetOperationData(105))
        End Select
        CalculateQC()
    End Sub

    Private Sub removeUnusedOperations(ByRef keys As List(Of Integer))
        If keys.Count > 0 Then
            Dim cmd1 As New SqlCommand("DELETE QuotationCostSheet", con)
            For i As Integer = 0 To keys.Count - 1
                If i > 0 Then
                    cmd1.CommandText += " AND QuoteCostKey <> " + keys(i).ToString()
                Else
                    cmd1.CommandText += " WHERE QuoteCostKey <> " + keys(i).ToString()
                End If
            Next
            cmd1.CommandText += ";"
            If con.State = ConnectionState.Closed Then con.Open()
            cmd1.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub shouldAddKey(ByRef keys As List(Of Integer), ByVal key As Integer, ByVal checked As Boolean)
        If checked Then
            keys.Add(key)
        End If
    End Sub

    Private Sub shouldAddKey(ByRef keys As List(Of Integer), ByVal key As Integer, ByVal nbr As Decimal)
        If nbr > 0 Then
            keys.Add(key)
        End If
    End Sub

    Private Sub txtFinishedWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinishedWeight.TextChanged
        If isloaded Then
            txtScrapWeight.Text = Math.Round(Val(txtFinishedWeight.Text) * (Val(txtScrapPercent.Text) / 100), 2).ToString
            txtStartWeight.Text = Math.Round(Val(txtFinishedWeight.Text) + Val(txtScrapWeight.Text), 2).ToString
        End If
    End Sub

    Private Sub cmdDuplicateQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDuplicateQuote.Click
        If canDuplicate() Then
            ''gets the new quote number and copies the data from the quote. with or without the customer data
            If MessageBox.Show("Is this a new customer?", "New customer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("DECLARE @NewQuoteNumber as int = (SELECT ISNULL(MAX(QuoteID) + 1, 1) FROM Quotation); INSERT INTO Quotation (QuoteID, QuoteDate, Preparer, CustomerID, ContactName, CustomerName, Phone, Fax, Email, CustPartNo, TFPPartNo, PartDescription, PartSize, DivisionID, DeliveryRequirements, ToolingCharge, SetupCharge, WtPerM, Extension, NotesComments, FOXItemCreated, CustomerInqueryNumber, RepAgency, RFQSource, ScrapPercent, ReferenceQuoteNumber, InternalNotes) output inserted.QuoteID SELECT @NewQuoteNumber, CURRENT_TIMESTAMP, @Preparer, '', '', '', '', '', '', CustPartNo, TFPPartNo, PartDescription, PartSize, DivisionID, DeliveryRequirements, ToolingCharge, SetupCharge, WtPerM, Extension, NotesComments, 'False', CustomerInqueryNumber, RepAgency, RFQSource, ScrapPercent, @OldQuoteID, InternalNotes FROM Quotation WHERE QuoteID  = @OldQuoteID; SELECT @NewQuoteNumber;", con)
            Else
                cmd = New SqlCommand("DECLARE @NewQuoteNumber as int = (SELECT ISNULL(MAX(QuoteID) + 1, 1) FROM Quotation); INSERT INTO Quotation (QuoteID, QuoteDate, Preparer, CustomerID, ContactName, CustomerName, Phone, Fax, Email, CustPartNo, TFPPartNo, PartDescription, PartSize, DivisionID, DeliveryRequirements, ToolingCharge, SetupCharge, WtPerM, Extension, NotesComments, FOXItemCreated, CustomerInqueryNumber, RepAgency, RFQSource, ScrapPercent, ReferenceQuoteNumber, InternalNotes) output inserted.QuoteID SELECT @NewQuoteNumber, CURRENT_TIMESTAMP, @Preparer, CustomerID, ContactName, CustomerName, Phone, Fax, Email, CustPartNo, TFPPartNo, PartDescription, PartSize, DivisionID, DeliveryRequirements, ToolingCharge, SetupCharge, WtPerM, Extension, NotesComments, 'False', CustomerInqueryNumber, RepAgency, RFQSource, ScrapPercent, @OldQuoteID, InternalNotes FROM Quotation WHERE QuoteID  = @OldQuoteID; SELECT @NewQuoteNumber;", con)
            End If
            cmd.Parameters.Add("@OldQuoteID", SqlDbType.Int).Value = Val(cboQuoteNumber.Text)
            cmd.Parameters.Add("@Preparer", SqlDbType.VarChar).Value = EmployeeLoginName

            ''copies the costing to the new Quote number
            cmd.CommandText += " INSERT INTO QuotationCostSheet (QuoteID, QuoteCostKey, MachineType, QuoteCost, SetupCost) SELECT @NewQuoteNumber, QuoteCostKey, MachineType, QuoteCost, SetupCost FROM QuotationCostSheet WHERE QuoteCostKey = @OldQuoteID;"
            ''copies the markup to the new Quote number
            cmd.CommandText += " INSERT INTO QuoteMarkup (QuoteID, QuoteNumber, Quantity, Production, Tools, Setup, QualityControl, Total, Markup, QuoteTotal) SELECT @NewQuoteNumber, QuoteNumber, Quantity, Production, Tools, Setup, QualityControl, Total, Markup, QuoteTotal FROM QuoteMarkup WHERE QuoteID = @OldQuoteID;"
            ''copies the operations to the new Quote number
            cmd.CommandText += " INSERT INTO QuoteOperations (QuoteID, Header, Extrude, Trim, Point, ThreadCut, Slot, HandSlot, Shave, PunchPress, Centerless, HotFormer, Roll10Slow, RollH20, RollH60, Roll40, RollHand, RollHand50, RollReed, RollBoltMaker, RollFlat, Drilling, CounterSink, ShotPeen, LatheWork, MazakLathe, MazakMill, Grinding, Tapping, BarFeed, HaasMill, HaasMiniMill, WireClean, TumbleWash, Anneal, ZincPlating, PicklePlating, NickelPlating, Bake, HeatTreat, CaseHarden, OutsideHTorPlate, Phosphate, MaterialType, MaterialCost, DensityType, DimensionUnits, SaltSpray, SaltSprayQuantity, AdditionalSaltSpray, SurfaceCore, MicroCaseDepth, MicroDecarb, FurnaceChartCopy, Tensile5Specimen, AdditionalTensile, WedgeBandShear, TruWeldTensile, CertCompliance, NylonPatch, Chemistry, MillCert, CertRequired, SampleRequired, SPCRequired, Dimensional, Plating, MagParticle, ISIR, PPap, OutsideHTCertification) SELECT @NewQuoteNumber, Header, Extrude, Trim, Point, ThreadCut, Slot, HandSlot, Shave, PunchPress, Centerless, HotFormer, Roll10Slow, RollH20, RollH60, Roll40, RollHand, RollHand50, RollReed, RollBoltMaker, RollFlat, Drilling, CounterSink, ShotPeen, LatheWork, MazakLathe, MazakMill, Grinding, Tapping, BarFeed, HaasMill, HaasMiniMill, WireClean, TumbleWash, Anneal, ZincPlating, PicklePlating, NickelPlating, Bake, HeatTreat, CaseHarden, OutsideHTorPlate, Phosphate, MaterialType, MaterialCost, DensityType, DimensionUnits, SaltSpray, SaltSprayQuantity, AdditionalSaltSpray, SurfaceCore, MicroCaseDepth, MicroDecarb, FurnaceChartCopy, Tensile5Specimen, AdditionalTensile, WedgeBandShear, TruWeldTensile, CertCompliance, NylonPatch, Chemistry, MillCert, CertRequired, SampleRequired, SPCRequired, Dimensional, Plating, MagParticle, ISIR, PPap, OutsideHTCertification FROM QuoteOperations WHERE QuoteID = @OldQuoteID;"
            ''copies the other operations to the new Quote number
            cmd.CommandText += " INSERT INTO QuoteOther (QuoteID, OtherNumber, Description, Cost, UnitType, Outside) SELECT @NewQuoteNumber, OtherNumber, Description, Cost, UnitType, Outside FROM QuoteOther WHERE QuoteID = @OldQuoteID;"
            ''copies the segments to the new Quote number
            cmd.CommandText += " INSERT INTO QuoteSegments (QuoteID, DimNumber, SegShape, Trim, Dim1, Dim2, Dim3, SegWt) SELECT @NewQuoteNumber, DimNumber, SegShape, Trim, Dim1, Dim2, Dim3, SegWt FROM QuoteSegments WHERE QuoteID = @OldQuoteID; SELECT @NewQuoteNumber"

            Dim newQuoteID As Integer = 0
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                newQuoteID = cmd.ExecuteScalar()
            Catch ex As SqlException
                sendErrorToDataBase("TFPQuoteForm - cmdDuplicateQuote --Error inserting duplicate quote entry", "Origional Quote #" + cboQuoteNumber.Text, ex.ToString())
            End Try

            If newQuoteID = 0 Then
                con.Close()
                MessageBox.Show("There was a problem duplicating the data. Contact system admin.", "Unable to duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            isloaded = False
            LoadQuoteNumbers()
            isloaded = True
            cboQuoteNumber.Text = newQuoteID.ToString()
            Me.Text = "TFP Quote Form*"
        End If
    End Sub

    Private Function canDuplicate() As Boolean
        If String.IsNullOrEmpty(cboQuoteNumber.Text) Then
            MessageBox.Show("You must enter a quote number", "Enter a quote number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.Focus()
            Return False
        End If
        If cboQuoteNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Quote Number", "Enter a valid Quote Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboQuoteNumber.SelectAll()
            cboQuoteNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub txtScrapPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScrapPercent.TextChanged
        If isloaded Then
            isloaded = False
            txtScrapWeight.Text = Math.Round(Val(txtFinishedWeight.Text) * (Val(txtScrapPercent.Text) / 100), 2).ToString
            txtStartWeight.Text = Math.Round(Val(txtFinishedWeight.Text) + Val(txtScrapWeight.Text), 2).ToString
            isloaded = True
            UpdateDisplayedTotals()
        End If
    End Sub

    Private Sub cboCustomerID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerName.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub nbrHaasMiniMill_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrHaasMiniMill.ValueChanged
        If isloaded Then
            UpdateAddToList(133, nbrHaasMiniMill.Value, GetOperationData(133))
            shouldSave = True
        End If
    End Sub

    Private Sub txtPhone_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPhone.Leave
        ''will format the number as long as it is a 10 digit number
        If txtPhone.Text.Length = 10 Then
            txtPhone.Text = "(" + txtPhone.Text.Substring(0, 3) + ")" + txtPhone.Text.Substring(3, 3) + "-" + txtPhone.Text.Substring(6, 4)
        End If
    End Sub

    Private Sub txtFax_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFax.Leave
        ''will format the number as long as it is a 10 digit number
        If txtFax.Text.Length = 10 Then
            txtFax.Text = "(" + txtFax.Text.Substring(0, 3) + ")" + txtFax.Text.Substring(3, 3) + "-" + txtFax.Text.Substring(6, 4)
        End If
    End Sub

    Private Sub setupDGVShipTotalOutOpQC()
        dgvShipTotalsOutsideOpQC.Columns.Add("Description", "")
        dgvShipTotalsOutsideOpQC.Columns("Description").Width = 175
        dgvShipTotalsOutsideOpQC.Columns.Add("Total", "")
        dgvShipTotalsOutsideOpQC.Columns("Total").Width = 100
    End Sub

    ''clears the rows and columns of the Ship Total Outside Op Qc DGV
    Private Sub clearDGVShipTotalOutOPQC()
        dgvShipTotalsOutsideOpQC.Rows.Clear()
        dgvShipTotalsOutsideOpQC.Columns.Clear()
    End Sub

    Private Function addOutsideOtherOperations() As Double
        Dim total As Double = 0D
        For i As Integer = 0 To dgvOtherOperations.Rows.Count - 1
            If Convert.ToBoolean(dgvOtherOperations.Rows(i).Cells("Outside").Value) Then
                If dgvOtherOperations.Rows(i).Cells("UnitType").Value.ToString.Equals("CWT") Then
                    dgvShipTotalsOutsideOpQC.Rows.Add("OUT. " + dgvOtherOperations.Rows(i).Cells("Description").Value, FormatCurrency(dgvOtherOperations.Rows(i).Cells("Cost").Value / 100 * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))))
                    total += dgvOtherOperations.Rows(i).Cells("Cost").Value / 100 * (Val(txtStartWeight.Text) - Val(txtScrapWeight.Text))
                Else
                    dgvShipTotalsOutsideOpQC.Rows.Add("OUT. " + dgvOtherOperations.Rows(i).Cells("Description").Value, FormatCurrency(dgvOtherOperations.Rows(i).Cells("Cost").Value))
                    total += dgvOtherOperations.Rows(i).Cells("Cost").Value
                End If
            End If
        Next
        txtOutsideOtherOperationTotal.Text = Math.Round(total, 2, MidpointRounding.AwayFromZero).ToString()
        Return total
    End Function

    Private Sub txtSpecialMaterialType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSpecialMaterialType.Leave
        UpdateDisplayedTotals(False)
    End Sub

    Private Sub txtSpecialMaterialType_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSpecialMaterialType.KeyUp
        If e.KeyCode = Keys.Enter Then
            UpdateDisplayedTotals(False)
        End If
    End Sub

    Private Sub expandShipTotalOutOPQC()
        dgvEstimatedCost.Visible = False
        dgvShipTotalsOutsideOpQC.Visible = False
        resetshipTotalDGV()
        ''check to make sure that not going ot make the inside operations box too small and check to see if it is needed
        If dgvEstimatedCost.Size.Height - (22 * (dgvShipTotalsOutsideOpQC.Rows.Count - 7)) > 100 And dgvShipTotalsOutsideOpQC.Rows.Count > 7 Then
            ''will make the box the max that it can without making the inside operations box too small
            dgvEstimatedCost.Size = New System.Drawing.Size(dgvEstimatedCost.Size.Width, dgvEstimatedCost.Size.Height - (22 * (dgvShipTotalsOutsideOpQC.Rows.Count - 7)))
            dgvShipTotalsOutsideOpQC.Location = New System.Drawing.Point(dgvShipTotalsOutsideOpQC.Location.X, dgvShipTotalsOutsideOpQC.Location.Y - (22 * (dgvShipTotalsOutsideOpQC.Rows.Count - 7)))
            dgvShipTotalsOutsideOpQC.Size = New System.Drawing.Size(dgvShipTotalsOutsideOpQC.Size.Width, dgvShipTotalsOutsideOpQC.Size.Height + (22 * (dgvShipTotalsOutsideOpQC.Rows.Count - 7)))
            ''check to see if just the box needs to be larger
        ElseIf dgvShipTotalsOutsideOpQC.Rows.Count > 7 Then
            dgvEstimatedCost.Size = New System.Drawing.Size(dgvEstimatedCost.Size.Width, dgvEstimatedCost.Size.Height - 110)
            dgvShipTotalsOutsideOpQC.Location = New System.Drawing.Point(dgvShipTotalsOutsideOpQC.Location.X, dgvShipTotalsOutsideOpQC.Location.Y - 110)
            dgvShipTotalsOutsideOpQC.Size = New System.Drawing.Size(dgvShipTotalsOutsideOpQC.Size.Width, dgvShipTotalsOutsideOpQC.Size.Height + 110)
        End If
        dgvEstimatedCost.Visible = True
        dgvShipTotalsOutsideOpQC.Visible = True
    End Sub

    ''will change the check box and combobox values without having to leave the cells for other operations
    Private Sub dgvOtherOperations_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvOtherOperations.CurrentCellDirtyStateChanged
        If dgvOtherOperations.IsCurrentCellDirty And isloaded And (dgvOtherOperations.Columns(dgvOtherOperations.CurrentCell.ColumnIndex).HeaderCell.Value = "Unit Type" Or dgvOtherOperations.Columns(dgvOtherOperations.CurrentCell.ColumnIndex).HeaderCell.Value = "Outside") Then
            dgvOtherOperations.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ''will change the values for checkboxes and comboboxes for segments witghout leaving the cell
    Private Sub dgvSegments_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSegments.CurrentCellDirtyStateChanged
        If dgvSegments.IsCurrentCellDirty And isloaded And (dgvSegments.Columns(dgvSegments.CurrentCell.ColumnIndex).HeaderCell.Value = "Shape" Or dgvSegments.Columns(dgvSegments.CurrentCell.ColumnIndex).HeaderCell.Value = "Trim") Then
            dgvSegments.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub txtQuoteRevisionLevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuoteRevisionLevel.TextChanged
        If isloaded And txtQuoteRevisionLevel.Focused Then
            ManualRevisionChange = True
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If isloaded Then
            ''gets the customer purchasing data if the customer already exists
            If cboCustomerID.SelectedIndex <> -1 Then
                cmd = New SqlCommand("SELECT ContactName, ContactEmail, ContactPhone, ContactFax FROM CustomerContacts WHERE ContactDepartment = 'PURCHASING' AND DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text


                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    If Not reader.IsDBNull(0) Then
                        txtContactName.Text = reader.Item("ContactName")
                    Else
                        txtContactName.Text = ""
                    End If
                    If Not reader.IsDBNull(1) Then
                        txtEmail.Text = reader.Item("ContactEmail")
                    Else
                        txtEmail.Text = ""
                    End If
                    If Not reader.IsDBNull(2) Then
                        If reader.Item("ContactPhone").ToString.Contains("x") Then
                            txtPhone.Text = reader.Item("ContactPhone").ToString.Substring(0, reader.Item("ContactPhone").ToString.IndexOf("x"))
                            txtPhoneExtension.Text = reader.Item("ContactPhone").ToString.Substring(reader.Item("ContactPhone").ToString.IndexOf("x") + 1)
                        Else
                            txtPhone.Text = reader.Item("ContactPhone")
                            txtPhoneExtension.Text = ""
                        End If

                    Else
                        txtPhone.Text = ""
                    End If
                    If Not reader.IsDBNull(3) Then
                        txtFax.Text = reader.Item("ContactFax")
                    Else
                        txtFax.Text = ""
                    End If
                Else
                    txtContactName.Text = ""
                    txtEmail.Text = ""
                    txtPhone.Text = ""
                    txtPhoneExtension.Text = ""
                    txtFax.Text = ""
                End If
                reader.Close()
                con.Close()
            End If
        End If
    End Sub

    Private Sub AddControlHandlers(Optional ByVal ctrl As Control = Nothing)
        If ctrl Is Nothing Then
            ctrl = Me
        End If
        For Each child As Control In ctrl.Controls
            If child.Controls.Count > 0 Then
                AddControlHandlers(child)
            End If
            If TypeOf (child) Is System.Windows.Forms.TextBox Then
                AddHandler CType(child, System.Windows.Forms.TextBox).TextChanged, AddressOf AddSaveTitle
            ElseIf TypeOf (child) Is System.Windows.Forms.ComboBox Then
                AddHandler CType(child, System.Windows.Forms.ComboBox).SelectedIndexChanged, AddressOf AddSaveTitle
            ElseIf TypeOf (child) Is System.Windows.Forms.NumericUpDown Then
                AddHandler CType(child, System.Windows.Forms.NumericUpDown).ValueChanged, AddressOf AddSaveTitle
            ElseIf TypeOf (child) Is System.Windows.Forms.RadioButton Then
                AddHandler CType(child, System.Windows.Forms.RadioButton).CheckedChanged, AddressOf AddSaveTitle
            ElseIf TypeOf (child) Is System.Windows.Forms.CheckBox Then
                AddHandler CType(child, System.Windows.Forms.CheckBox).CheckedChanged, AddressOf AddSaveTitle
            End If
        Next
    End Sub

    Private Sub AddSaveTitle(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.ActiveControl.Name.Equals("cboQuoteNumber") AndAlso CType(sender, Control).Name = Me.ActiveControl.Name AndAlso Me.Text.Equals("TFP Quote Form") Then
            Me.Text = "TFP Quote Form*"
        End If
    End Sub

    Private Sub CheckIfFOXCreated()
        If Val(cboQuoteNumber.Text) <> 0 Then
            cmd = New SqlCommand("SELECT COUNT(FOXNumber) FROM FOXTable WHERE QuoteNumber = @QuoteNumber", con)
            cmd.Parameters.Add("@QuoteNumber", SqlDbType.VarChar).Value = cboQuoteNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() > 0 Then
                gpxPartInfo.Enabled = False
            Else
                gpxPartInfo.Enabled = True
            End If
        Else
            gpxPartInfo.Enabled = True
        End If
        con.Close()

    End Sub

    Private Sub TFPQuoteForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
