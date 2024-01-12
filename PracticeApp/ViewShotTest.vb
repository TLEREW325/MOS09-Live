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



Public Class ViewShotTest

    Inherits System.Windows.Forms.Form

    Dim TextFilter, PartFilter, WarehouseFilter, DateFilter As String
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    'Button Events

    Private Sub cmdViewSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSave.Click
        ''Saves data to table and then viewed inside of the report
        viewSave()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Delete Data in the ScreenShotAnalysisTable
        Deletion()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Closes Form
        Me.Close()
    End Sub

    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        If validation() Then
            Dim wheel1, wheel2, wheel3, wheel4, wheel5, wheel6, north100, north104, north94, north95, north96, south100, south104, south94, south95, south96 As Double
            wheel1 = Val(txtBlastWheel1.Text)
            wheel2 = Val(txtBlastWheel2.Text)
            wheel3 = Val(txtBlastWheel3.Text)
            wheel4 = Val(txtBlastWheel4.Text)
            wheel5 = Val(txtBlastWheel5.Text)
            wheel6 = Val(txtBlastWheel6.Text)
            north100 = Val(txtNorth100.Text)
            north104 = Val(txtNorth104.Text)
            north94 = Val(txtNorth94.Text)
            north95 = Val(txtNorth95.Text)
            north96 = Val(txtNorth96.Text)
            south100 = Val(txtSouth100.Text)
            south104 = Val(txtSouth104.Text)
            south94 = Val(txtSouth94.Text)
            south95 = Val(txtSouth95.Text)
            south96 = Val(txtSouth96.Text)


            txtTotalNorth.Text = north100 + north104 + north94 + north95 + north96
            txtTotalSouth.Text = south100 + south104 + south94 + south95 + south96

            'Calculations
            wheel1 = Math.Round(((wheel1 / 30) * 100), 4)
            wheel2 = Math.Round(((wheel2 / 30) * 100), 4)
            wheel3 = Math.Round(((wheel3 / 30) * 100), 4)
            wheel4 = Math.Round(((wheel4 / 30) * 100), 4)
            wheel5 = Math.Round(((wheel5 / 60) * 100), 4)
            wheel6 = Math.Round(((wheel6 / 60) * 100), 4)

            north100 = Math.Round(((north100 / 104) * 100), 4)
            south100 = Math.Round(((south100 / 104) * 100), 4)
            north104 = Math.Round(((north104 / 108) * 100), 4)
            south104 = Math.Round(((south104 / 108) * 100), 4)
            north94 = Math.Round(((north94 / 97) * 100), 4)
            south94 = Math.Round(((south94 / 97) * 100), 4)
            north95 = Math.Round(((north95 / 97) * 100), 4)
            south95 = Math.Round(((south95 / 97) * 100), 4)
            north96 = Math.Round(((north96 / 99) * 100), 4)
            south96 = Math.Round(((south96 / 99) * 100), 4)

            'Averages
            Dim avgAmps, avgNorth, avgSouth As Double
            avgAmps = Math.Round(((wheel1 + wheel2 + wheel3 + wheel4 + wheel5 + wheel6) / 6), 2)
            avgNorth = Math.Round(((north96 + north95 + north94 + north104 + north100) / 5), 2)
            avgSouth = Math.Round(((south100 + south104 + south94 + south95 + south96) / 5), 2)
            txtTotalAmps.Text = avgAmps


            'Difference calculations
            Dim wheel1d, wheel2d, wheel3d, wheel4d, wheel5d, wheel6d, north100d, south100d, north104d, south104d, north94d, south94d, north95d, south95d, north96d, south96d As Double
            wheel1d = Math.Abs(wheel1 - 100)
            wheel2d = Math.Abs(wheel2 - 100)
            wheel3d = Math.Abs(wheel3 - 100)
            wheel4d = Math.Abs(wheel4 - 100)
            wheel5d = Math.Abs(wheel5 - 100)
            wheel6d = Math.Abs(wheel6 - 100)

            wheel1d = Math.Round(wheel1d, 2)
            wheel2d = Math.Round(wheel2d, 2)
            wheel3d = Math.Round(wheel3d, 2)
            wheel4d = Math.Round(wheel4d, 2)
            wheel5d = Math.Round(wheel5d, 2)
            wheel6d = Math.Round(wheel6d, 2)

            north100d = Math.Ceiling(Math.Abs(north100 - 100))
            south100d = Math.Ceiling(Math.Abs(south100 - 100))
            north104d = Math.Ceiling(Math.Abs(north104 - 100))
            south104d = Math.Ceiling(Math.Abs(south104 - 100))
            north94d = Math.Ceiling(Math.Abs(north94 - 100))
            south94d = Math.Ceiling(Math.Abs(south94 - 100))
            north95d = Math.Ceiling(Math.Abs(north95 - 100))
            south95d = Math.Ceiling(Math.Abs(south95 - 100))
            north96d = Math.Ceiling(Math.Abs(north96 - 100))
            south96d = Math.Ceiling(Math.Abs(south96 - 100))


            wheel1 = Math.Ceiling(wheel1)
            wheel2 = Math.Ceiling(wheel2)
            wheel3 = Math.Ceiling(wheel3)
            wheel4 = Math.Ceiling(wheel4)
            wheel5 = Math.Ceiling(wheel5)
            wheel6 = Math.Ceiling(wheel6)

            'Displays
            txtBlastWheel1Perc.Text = "%" + wheel1.ToString
            txtBlastWheel2Perc.Text = "%" + wheel2.ToString
            txtBlastWheel3Perc.Text = "%" + wheel3.ToString
            txtBlastWheel4Perc.Text = "%" + wheel4.ToString
            txtBlastWheel5Perc.Text = "%" + wheel5.ToString
            txtBlastWheel6Perc.Text = "%" + wheel6.ToString
            txtNorth100Perc.Text = "%" + north100.ToString
            txtNorth104Perc.Text = "%" + north104.ToString
            txtNorth94Perc.Text = "%" + north94.ToString
            txtNorth95Perc.Text = "%" + north95.ToString
            txtNorth96Perc.Text = "%" + north96.ToString
            txtSouth100Perc.Text = "%" + south100.ToString
            txtSouth104Perc.Text = "%" + south104.ToString
            txtSouth94Perc.Text = "%" + south94.ToString
            txtSouth95Perc.Text = "%" + south95.ToString
            txtSouth96Perc.Text = "%" + south96.ToString


        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Clear Blast Wheel
        txtBlastWheel1.Text = ""
        txtBlastWheel1Perc.Text = ""
        txtBlastWheel2.Text = ""
        txtBlastWheel2Perc.Text = ""
        txtBlastWheel3.Text = ""
        txtBlastWheel3Perc.Text = ""
        txtBlastWheel4.Text = ""
        txtBlastWheel4Perc.Text = ""
        txtBlastWheel5.Text = ""
        txtBlastWheel5Perc.Text = ""
        txtBlastWheel6.Text = ""
        txtBlastWheel6Perc.Text = ""
        'Clear North Mix
        txtNorth100.Text = ""
        txtNorth100Perc.Text = ""
        txtNorth104.Text = ""
        txtNorth104Perc.Text = ""
        txtNorth94.Text = ""
        txtNorth94Perc.Text = ""
        txtNorth95.Text = ""
        txtNorth95Perc.Text = ""
        txtNorth96.Text = ""
        txtNorth96Perc.Text = ""
        'Clear South Mix
        txtSouth100.Text = ""
        txtSouth100Perc.Text = ""
        txtSouth104.Text = ""
        txtSouth104Perc.Text = ""
        txtSouth94.Text = ""
        txtSouth94Perc.Text = ""
        txtSouth95.Text = ""
        txtSouth95Perc.Text = ""
        txtSouth96.Text = ""
        txtSouth96Perc.Text = ""
        'Clear ID and Abrasive
        cboShotID.Text = ""
        txtAbrSize.Text = ""
        txtPAN.Text = ""
        'Clears Totals
        txtTotalAmps.Text = ""
        txtTotalNorth.Text = ""
        txtTotalSouth.Text = ""
        'Clears ID
        cboShotID.Text = ""
        cboShotID.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        'Views report based on 
        ViewReport()
    End Sub

    'Functions

    Public Function validation()
        Dim n As Double
        If txtBlastWheel1.Text = "" Then
            MsgBox("Please enter the 1st blast wheel measurement")
            txtBlastWheel1.Focus()
            Return False
        ElseIf txtBlastWheel2.Text = "" Then
            MsgBox("Please enter the 2nd blast wheel measurement")
            txtBlastWheel2.Focus()
            Return False
        ElseIf txtBlastWheel3.Text = "" Then
            MsgBox("Please enter the 3rd blast wheel measurement")
            txtBlastWheel3.Focus()
            Return False
        ElseIf txtBlastWheel4.Text = "" Then
            MsgBox("Please enter the 4th blast wheel measurement")
            txtBlastWheel4.Focus()
            Return False
        ElseIf txtBlastWheel5.Text = "" Then
            MsgBox("Please enter the 5th blast wheel measurement")
            txtBlastWheel5.Focus()
            Return False
        ElseIf txtBlastWheel6.Text = "" Then
            MsgBox("Please enter the 6th blast wheel measurement")
            txtBlastWheel6.Focus()
            Return False
        ElseIf txtNorth100.Text = "" Then
            MsgBox("Please enter the Operating Mix North 100 measurement")
            txtNorth100.Focus()
            Return False
        ElseIf txtNorth104.Text = "" Then
            MsgBox("Please enter the Operating Mix North 104 measurement")
            txtNorth104.Focus()
            Return False
        ElseIf txtNorth94.Text = "" Then
            MsgBox("Please enter the Operating Mix North 94 measurement")
            txtNorth94.Focus()
            Return False
        ElseIf txtNorth95.Text = "" Then
            MsgBox("Please enter the Operating Mix North 95 measurement")
            txtNorth95.Focus()
            Return False
        ElseIf txtNorth96.Text = "" Then
            MsgBox("Please enter the Operating Mix North 96 measurement")
            txtNorth96.Focus()
            Return False
        ElseIf txtSouth100.Text = "" Then
            MsgBox("Please enter the Operating Mix South 100 measurement")
            txtSouth100.Focus()
            Return False
        ElseIf txtSouth104.Text = "" Then
            MsgBox("Please enter the Operating Mix South 104 measurement")
            txtSouth104.Focus()
            Return False
        ElseIf txtSouth94.Text = "" Then
            MsgBox("Please enter the Operating Mix South 94 measurement")
            txtSouth94.Focus()
            Return False
        ElseIf txtAbrSize.Text = "" Then
            MsgBox("Please enter the Abrasive Size")
            txtAbrSize.Focus()
            Return False
        ElseIf txtSouth95.Text = "" Then
            MsgBox("Please enter the Operating Mix South 95 measurement")
            txtSouth95.Focus()
            Return False
        ElseIf txtSouth96.Text = "" Then
            MsgBox("Please enter the Operating Mix South 96 measurement")
            txtSouth96.Focus()
            Return False
        ElseIf Not Double.TryParse(txtSouth96.Text, n) Then
            MsgBox("Please enter the Operating Mix South 96 measurement")
            txtSouth96.Focus()
            Return False
        ElseIf Not Double.TryParse(txtSouth95.Text, n) Then
            MsgBox("Please enter the Operating Mix South 95 measurement")
            txtSouth95.Focus()
            Return False
        ElseIf Not Double.TryParse(txtSouth94.Text, n) Then
            MsgBox("Please enter the Operating Mix South 94 measurement")
            txtSouth94.Focus()
            Return False
        ElseIf Not Double.TryParse(txtSouth104.Text, n) Then
            MsgBox("Please enter the Operating Mix South 104 measurement")
            txtSouth104.Focus()
            Return False
        ElseIf Not Double.TryParse(txtSouth100.Text, n) Then
            MsgBox("Please enter the Operating Mix South 100 measurement")
            txtSouth100.Focus()
            Return False
        ElseIf Not Double.TryParse(txtNorth96.Text, n) Then
            MsgBox("Please enter the Operating Mix North 96 measurement")
            txtNorth96.Focus()
            Return False
        ElseIf Not Double.TryParse(txtNorth95.Text, n) Then
            MsgBox("Please enter the Operating Mix North 95 measurement")
            txtNorth95.Focus()
            Return False
        ElseIf Not Double.TryParse(txtNorth94.Text, n) Then
            MsgBox("Please enter the Operating Mix North 94 measurement")
            txtNorth94.Focus()
            Return False
        ElseIf Not Double.TryParse(txtNorth104.Text, n) Then
            MsgBox("Please enter the Operating Mix North 104 measurement")
            txtNorth104.Focus()
            Return False
        ElseIf Not Double.TryParse(txtNorth100.Text, n) Then
            MsgBox("Please enter the Operating Mix North 100 measurement")
            txtNorth100.Focus()
            Return False
        ElseIf Not Double.TryParse(txtBlastWheel1.Text, n) Then
            MsgBox("Please enter the 1st blast wheel measurement")
            txtBlastWheel1.Focus()
            Return False
        ElseIf Not Double.TryParse(txtBlastWheel2.Text, n) Then
            MsgBox("Please enter the 2nd blast wheel measurement")
            txtBlastWheel2.Focus()
            Return False
        ElseIf Not Double.TryParse(txtBlastWheel3.Text, n) Then
            MsgBox("Please enter the 3rd blast wheel measurement")
            txtBlastWheel3.Focus()
            Return False
        ElseIf Not Double.TryParse(txtBlastWheel4.Text, n) Then
            MsgBox("Please enter the 4th blast wheel measurement")
            txtBlastWheel4.Focus()
            Return False
        ElseIf Not Double.TryParse(txtBlastWheel5.Text, n) Then
            MsgBox("Please enter the 5th blast wheel measurement")
            txtBlastWheel5.Focus()
            Return False
        ElseIf Not Double.TryParse(txtBlastWheel6.Text, n) Then
            MsgBox("Please enter the 6th blast wheel measurement")
            txtBlastWheel6.Focus()
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub viewSave()
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this shot analysis test?", "Save Shot Analysis", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If validation() Then
                If txtPAN.Text = "" Then
                    txtPAN.Text = "N/A"
                End If
                If txtPANSouth.Text = "" Then
                    txtPANSouth.Text = "N/A"
                End If
                Dim wheel1, wheel2, wheel3, wheel4, wheel5, wheel6, north100, north104, north94, north95, north96, south100, south104, south94, south95, south96 As Double
                wheel1 = Val(txtBlastWheel1.Text)
                wheel2 = Val(txtBlastWheel2.Text)
                wheel3 = Val(txtBlastWheel3.Text)
                wheel4 = Val(txtBlastWheel4.Text)
                wheel5 = Val(txtBlastWheel5.Text)
                wheel6 = Val(txtBlastWheel6.Text)
                north100 = Val(txtNorth100.Text)
                north104 = Val(txtNorth104.Text)
                north94 = Val(txtNorth94.Text)
                north95 = Val(txtNorth95.Text)
                north96 = Val(txtNorth96.Text)
                south100 = Val(txtSouth100.Text)
                south104 = Val(txtSouth104.Text)
                south94 = Val(txtSouth94.Text)
                south95 = Val(txtSouth95.Text)
                south96 = Val(txtSouth96.Text)


                txtTotalNorth.Text = north100 + north104 + north94 + north95 + north96
                txtTotalSouth.Text = south100 + south104 + south94 + south95 + south96

                'Calculations
                wheel1 = Math.Round(((wheel1 / 30) * 100), 4)
                wheel2 = Math.Round(((wheel2 / 30) * 100), 4)
                wheel3 = Math.Round(((wheel3 / 30) * 100), 4)
                wheel4 = Math.Round(((wheel4 / 30) * 100), 4)
                wheel5 = Math.Round(((wheel5 / 60) * 100), 4)
                wheel6 = Math.Round(((wheel6 / 60) * 100), 4)

                north100 = Math.Round(((north100 / 104) * 100), 4)
                south100 = Math.Round(((south100 / 104) * 100), 4)
                north104 = Math.Round(((north104 / 108) * 100), 4)
                south104 = Math.Round(((south104 / 108) * 100), 4)
                north94 = Math.Round(((north94 / 97) * 100), 4)
                south94 = Math.Round(((south94 / 97) * 100), 4)
                north95 = Math.Round(((north95 / 97) * 100), 4)
                south95 = Math.Round(((south95 / 97) * 100), 4)
                north96 = Math.Round(((north96 / 99) * 100), 4)
                south96 = Math.Round(((south96 / 99) * 100), 4)

                'ShotIDCalculation
                Dim month, day, second, hour, minute As Integer
                Dim shotIDC As String = ""
                Dim datecreated As Date = dtpDate.Value
                month = Now.Month
                day = Now.Day
                second = Now.Second
                hour = Now.Hour
                minute = Now.Minute
                second = Now.Second
                shotIDC = datecreated.Month.ToString + "-" + datecreated.Day.ToString + "-" + datecreated.Year.ToString + "-" + month.ToString + day.ToString + hour.ToString + minute.ToString + second.ToString

                'Averages
                Dim avgAmps, avgNorth, avgSouth As Double
                avgAmps = Math.Round(((wheel1 + wheel2 + wheel3 + wheel4 + wheel5 + wheel6) / 6), 2)
                avgNorth = Math.Round(((north96 + north95 + north94 + north104 + north100) / 5), 2)
                avgSouth = Math.Round(((south100 + south104 + south94 + south95 + south96) / 5), 2)
                txtTotalAmps.Text = avgAmps
                

                'Difference calculations
                Dim wheel1d, wheel2d, wheel3d, wheel4d, wheel5d, wheel6d, north100d, south100d, north104d, south104d, north94d, south94d, north95d, south95d, north96d, south96d As Double
                wheel1d = Math.Abs(wheel1 - 100)
                wheel2d = Math.Abs(wheel2 - 100)
                wheel3d = Math.Abs(wheel3 - 100)
                wheel4d = Math.Abs(wheel4 - 100)
                wheel5d = Math.Abs(wheel5 - 100)
                wheel6d = Math.Abs(wheel6 - 100)

                wheel1d = Math.Round(wheel1d, 2)
                wheel2d = Math.Round(wheel2d, 2)
                wheel3d = Math.Round(wheel3d, 2)
                wheel4d = Math.Round(wheel4d, 2)
                wheel5d = Math.Round(wheel5d, 2)
                wheel6d = Math.Round(wheel6d, 2)

                north100d = Math.Ceiling(Math.Abs(north100 - 100))
                south100d = Math.Ceiling(Math.Abs(south100 - 100))
                north104d = Math.Ceiling(Math.Abs(north104 - 100))
                south104d = Math.Ceiling(Math.Abs(south104 - 100))
                north94d = Math.Ceiling(Math.Abs(north94 - 100))
                south94d = Math.Ceiling(Math.Abs(south94 - 100))
                north95d = Math.Ceiling(Math.Abs(north95 - 100))
                south95d = Math.Ceiling(Math.Abs(south95 - 100))
                north96d = Math.Ceiling(Math.Abs(north96 - 100))
                south96d = Math.Ceiling(Math.Abs(south96 - 100))


                wheel1 = Math.Ceiling(wheel1)
                wheel2 = Math.Ceiling(wheel2)
                wheel3 = Math.Ceiling(wheel3)
                wheel4 = Math.Ceiling(wheel4)
                wheel5 = Math.Ceiling(wheel5)
                wheel6 = Math.Ceiling(wheel6)

                'Displays
                txtBlastWheel1Perc.Text = "%" + wheel1.ToString
                txtBlastWheel2Perc.Text = "%" + wheel2.ToString
                txtBlastWheel3Perc.Text = "%" + wheel3.ToString
                txtBlastWheel4Perc.Text = "%" + wheel4.ToString
                txtBlastWheel5Perc.Text = "%" + wheel5.ToString
                txtBlastWheel6Perc.Text = "%" + wheel6.ToString
                txtNorth100Perc.Text = "%" + north100.ToString
                txtNorth104Perc.Text = "%" + north104.ToString
                txtNorth94Perc.Text = "%" + north94.ToString
                txtNorth95Perc.Text = "%" + north95.ToString
                txtNorth96Perc.Text = "%" + north96.ToString
                txtSouth100Perc.Text = "%" + south100.ToString
                txtSouth104Perc.Text = "%" + south104.ToString
                txtSouth94Perc.Text = "%" + south94.ToString
                txtSouth95Perc.Text = "%" + south95.ToString
                txtSouth96Perc.Text = "%" + south96.ToString


                Dim saveDate As Date = Date.Now
                Dim rounding1, rounding2, rounding3 As Double
                rounding1 = Math.Round(((wheel1 + wheel2 + wheel3 + wheel4 + wheel5 + wheel6) / 6), 0)
                rounding2 = Math.Round(((north96 + north95 + north94 + north104 + north100) / 5), 0)
                rounding3 = Math.Round(((south100 + south104 + south94 + south95 + south96) / 5), 0)


                GlobalGroupByPartNumber = wheel1
                GlobalGroupByItemClass = wheel2
                GlobalGroupByMonth = wheel3
                GlobalGroupByCustomer = wheel4
                GlobalGroupBySubtotal = wheel5
                GlobalGroupByAll = wheel6
                GlobalSteelOrderPartNumber = north100d
                GlobalSteelOrderRMID = south100d
                GlobalSteelOrderCarbon = north104d
                GlobalSteelOrderSteelSize = south104d
                GlobalSteelOrderSteelDescription = north94d
                GlobalShipmentPrintType = south94d
                GlobalAutoPrintPackingList = north95d
                GlobalSteelReturnCarbon = south95d
                GlobalSteelReturnSize = north96d
                GlobalNoAutoPrintCheckRemittance = south96d
                GlobalAPRemittanceEmail = avgAmps
                GlobalCustomerCreditAPP = txtTotalNorth.Text
                GlobalAPPFPCheckBox = txtTotalSouth.Text
                GlobalTraineeCompany = wheel1d
                GlobalNaftaDate = wheel2d
                GlobalNaftaCustomerID = wheel3d
                GlobalNaftaPrintType = wheel4d
                GlobalNAFTAShipDate = wheel5d
                GlobalTraineeName = wheel6d

                'Insert into tables
                Dim exists As Boolean = False
                Dim autho As String = "test"
                Dim ItemDataStatement As String = "SELECT ShotID FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID"
                Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
                ItemDataCommand.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = cboShotID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("ShotID")) Then
                            autho = "test"
                        Else
                            autho = reader.Item("ShotID")
                        End If
                    End If
                    reader.Close()
                    Dim chosenautho = cboShotID.Text
                    If chosenautho = autho Then

                        'update
                        cmd7 = New SqlCommand("UPDATE ScreenShotAnalysisTable SET AbrasiveSize = @AbrasiveSize, PANNumber = @PANNumber, PANNumberSouth = @PANNumberSouth, DateCreated = @DateCreated, North104 = @North104, North100 = @North100, North96 = @North96, North95 = @North95, North94 = @North94, South104 = @South104, South100 = @South100, South96 = @South96, South95 = @South95, South94 = @South94, Wheel1 = @Wheel1, Wheel2 = @Wheel2, Wheel3 = @Wheel3, Wheel4 = @Wheel4, Wheel5 = @Wheel5, Wheel6 = @Wheel6 WHERE ShotID = @OldShotID", con)
                        With cmd7.Parameters
                            .Add("@OldShotID", SqlDbType.VarChar).Value = cboShotID.Text
                            .Add("@AbrasiveSize", SqlDbType.VarChar).Value = txtAbrSize.Text
                            .Add("@PANNumber", SqlDbType.VarChar).Value = txtPAN.Text
                            .Add("@PANNumberSouth", SqlDbType.VarChar).Value = txtPANSouth.Text
                            .Add("@DateCreated", SqlDbType.VarChar).Value = dtpDate.Value
                            .Add("@North104", SqlDbType.VarChar).Value = Val(txtNorth104.Text)
                            .Add("@North100", SqlDbType.VarChar).Value = Val(txtNorth100.Text)
                            .Add("@North96", SqlDbType.VarChar).Value = Val(txtNorth96.Text)
                            .Add("@North95", SqlDbType.VarChar).Value = Val(txtNorth95.Text)
                            .Add("@North94", SqlDbType.VarChar).Value = Val(txtNorth94.Text)
                            .Add("@South104", SqlDbType.VarChar).Value = Val(txtSouth104.Text)
                            .Add("@South100", SqlDbType.VarChar).Value = Val(txtSouth100.Text)
                            .Add("@South96", SqlDbType.VarChar).Value = Val(txtSouth96.Text)
                            .Add("@South95", SqlDbType.VarChar).Value = Val(txtSouth95.Text)
                            .Add("@South94", SqlDbType.VarChar).Value = Val(txtSouth94.Text)
                            .Add("@Wheel1", SqlDbType.VarChar).Value = Val(txtBlastWheel1.Text)
                            .Add("@Wheel2", SqlDbType.VarChar).Value = Val(txtBlastWheel2.Text)
                            .Add("@Wheel3", SqlDbType.VarChar).Value = Val(txtBlastWheel3.Text)
                            .Add("@Wheel4", SqlDbType.VarChar).Value = Val(txtBlastWheel4.Text)
                            .Add("@Wheel5", SqlDbType.VarChar).Value = Val(txtBlastWheel5.Text)
                            .Add("@Wheel6", SqlDbType.VarChar).Value = Val(txtBlastWheel6.Text)
                        End With
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd7.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Updated Shot Screening Analysis Report")

                        cmd1 = New SqlCommand("SELECT * FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID", con)
                        cmd1.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = cboShotID.Text

                        If con.State = ConnectionState.Closed Then con.Open()

                        GDS = New DataSet()
                        myAdapter.SelectCommand = cmd1
                        myAdapter.Fill(GDS, "ScreenShotAnalysisTable")

                    Else
                        'insert
                        cmd7 = New SqlCommand("INSERT INTO ScreenShotAnalysisTable (ShotID, AbrasiveSize, PANNumber, DateCreated, North104, North100, North96, North95, North94, South104, South100, South96, South95, South94, Wheel1, Wheel2, Wheel3, Wheel4, Wheel5, Wheel6, PANNumberSouth)Values(@ShotID, @AbrasiveSize, @PANNumber, @DateCreated, @North104, @North100, @North96, @North95, @North94, @South104, @South100, @South96, @South95, @South94, @Wheel1, @Wheel2, @Wheel3, @Wheel4, @Wheel5, @Wheel6, @PANNumberSouth)", con)

                        With cmd7.Parameters
                            .Add("@ShotID", SqlDbType.VarChar).Value = shotIDC
                            .Add("@AbrasiveSize", SqlDbType.VarChar).Value = txtAbrSize.Text
                            .Add("@PANNumber", SqlDbType.VarChar).Value = txtPAN.Text
                            .Add("@PANNumberSouth", SqlDbType.VarChar).Value = txtPANSouth.Text
                            .Add("@DateCreated", SqlDbType.VarChar).Value = dtpDate.Value
                            .Add("@North104", SqlDbType.VarChar).Value = Val(txtNorth104.Text)
                            .Add("@North100", SqlDbType.VarChar).Value = Val(txtNorth100.Text)
                            .Add("@North96", SqlDbType.VarChar).Value = Val(txtNorth96.Text)
                            .Add("@North95", SqlDbType.VarChar).Value = Val(txtNorth95.Text)
                            .Add("@North94", SqlDbType.VarChar).Value = Val(txtNorth94.Text)
                            .Add("@South104", SqlDbType.VarChar).Value = Val(txtSouth104.Text)
                            .Add("@South100", SqlDbType.VarChar).Value = Val(txtSouth100.Text)
                            .Add("@South96", SqlDbType.VarChar).Value = Val(txtSouth96.Text)
                            .Add("@South95", SqlDbType.VarChar).Value = Val(txtSouth95.Text)
                            .Add("@South94", SqlDbType.VarChar).Value = Val(txtSouth94.Text)
                            .Add("@Wheel1", SqlDbType.VarChar).Value = Val(txtBlastWheel1.Text)
                            .Add("@Wheel2", SqlDbType.VarChar).Value = Val(txtBlastWheel2.Text)
                            .Add("@Wheel3", SqlDbType.VarChar).Value = Val(txtBlastWheel3.Text)
                            .Add("@Wheel4", SqlDbType.VarChar).Value = Val(txtBlastWheel4.Text)
                            .Add("@Wheel5", SqlDbType.VarChar).Value = Val(txtBlastWheel5.Text)
                            .Add("@Wheel6", SqlDbType.VarChar).Value = Val(txtBlastWheel6.Text)
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd7.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved New Shot Screening Analysis Report")

                        cmd1 = New SqlCommand("SELECT * FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID", con)
                        cmd1.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = shotIDC

                        If con.State = ConnectionState.Closed Then con.Open()

                        GDS = New DataSet()
                        myAdapter.SelectCommand = cmd1
                        myAdapter.Fill(GDS, "ScreenShotAnalysisTable")

                    End If
                End Using

                'Display Report
                Dim NewPrintShotScreening As New PrintShotScreening
                NewPrintShotScreening.Show()

            End If
        End If
        LoadShotID()
        LoaddgvShotInfo()
    End Sub

    Public Sub Deletion()
        'Delete Data in the ScreenShotAnalysisTable
        Try
            cmd = New SqlCommand("DELETE FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID", con)
            cmd.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = cboShotID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Record Deleted")
        Catch ex As System.Exception
            MsgBox("Record Does Not Exists")

        End Try
        'Clear Blast Wheel
        txtBlastWheel1.Text = ""
        txtBlastWheel1Perc.Text = ""
        txtBlastWheel2.Text = ""
        txtBlastWheel2Perc.Text = ""
        txtBlastWheel3.Text = ""
        txtBlastWheel3Perc.Text = ""
        txtBlastWheel4.Text = ""
        txtBlastWheel4Perc.Text = ""
        txtBlastWheel5.Text = ""
        txtBlastWheel5Perc.Text = ""
        txtBlastWheel6.Text = ""
        txtBlastWheel6Perc.Text = ""
        'Clear North Mix
        txtNorth100.Text = ""
        txtNorth100Perc.Text = ""
        txtNorth104.Text = ""
        txtNorth104Perc.Text = ""
        txtNorth94.Text = ""
        txtNorth94Perc.Text = ""
        txtNorth95.Text = ""
        txtNorth95Perc.Text = ""
        txtNorth96.Text = ""
        txtNorth96Perc.Text = ""
        'Clear South Mix
        txtSouth100.Text = ""
        txtSouth100Perc.Text = ""
        txtSouth104.Text = ""
        txtSouth104Perc.Text = ""
        txtSouth94.Text = ""
        txtSouth94Perc.Text = ""
        txtSouth95.Text = ""
        txtSouth95Perc.Text = ""
        txtSouth96.Text = ""
        txtSouth96Perc.Text = ""
        'Clear ID and Abrasive
        cboShotID.Text = ""
        txtAbrSize.Text = ""
        txtPAN.Text = ""
        txtPANSouth.Text = ""
        'Clears Totals
        txtTotalAmps.Text = ""
        txtTotalNorth.Text = ""
        txtTotalSouth.Text = ""
        LoadShotID()
        LoaddgvShotInfo()
    End Sub

    Public Sub ViewReport()
        If validation() Then
            Dim wheel1, wheel2, wheel3, wheel4, wheel5, wheel6, north100, north104, north94, north95, north96, south100, south104, south94, south95, south96 As Double
            wheel1 = Val(txtBlastWheel1.Text)
            wheel2 = Val(txtBlastWheel2.Text)
            wheel3 = Val(txtBlastWheel3.Text)
            wheel4 = Val(txtBlastWheel4.Text)
            wheel5 = Val(txtBlastWheel5.Text)
            wheel6 = Val(txtBlastWheel6.Text)
            north100 = Val(txtNorth100.Text)
            north104 = Val(txtNorth104.Text)
            north94 = Val(txtNorth94.Text)
            north95 = Val(txtNorth95.Text)
            north96 = Val(txtNorth96.Text)
            south100 = Val(txtSouth100.Text)
            south104 = Val(txtSouth104.Text)
            south94 = Val(txtSouth94.Text)
            south95 = Val(txtSouth95.Text)
            south96 = Val(txtSouth96.Text)

            txtTotalNorth.Text = north100 + north104 + north94 + north95 + north96
            txtTotalSouth.Text = south100 + south104 + south94 + south95 + south96


            'Calculations
            wheel1 = Math.Round(((wheel1 / 30) * 100), 4)
            wheel2 = Math.Round(((wheel2 / 30) * 100), 4)
            wheel3 = Math.Round(((wheel3 / 30) * 100), 4)
            wheel4 = Math.Round(((wheel4 / 30) * 100), 4)
            wheel5 = Math.Round(((wheel5 / 60) * 100), 4)
            wheel6 = Math.Round(((wheel6 / 60) * 100), 4)
            north100 = Math.Round(((north100 / 104) * 100), 4)
            south100 = Math.Round(((south100 / 104) * 100), 4)
            north104 = Math.Round(((north104 / 108) * 100), 4)
            south104 = Math.Round(((south104 / 108) * 100), 4)
            north94 = Math.Round(((north94 / 97) * 100), 4)
            south94 = Math.Round(((south94 / 97) * 100), 4)
            north95 = Math.Round(((north95 / 97) * 100), 4)
            south95 = Math.Round(((south95 / 97) * 100), 4)
            north96 = Math.Round(((north96 / 99) * 100), 4)
            south96 = Math.Round(((south96 / 99) * 100), 4)

            'Averages
            Dim avgAmps, avgNorth, avgSouth As Double
            avgAmps = Math.Round(((wheel1 + wheel2 + wheel3 + wheel4 + wheel5 + wheel6) / 6), 2)
            avgNorth = Math.Round(((north96 + north95 + north94 + north104 + north100) / 5), 2)
            avgSouth = Math.Round(((south100 + south104 + south94 + south95 + south96) / 5), 2)
            txtTotalAmps.Text = avgAmps

            'Difference calculations
            Dim wheel1d, wheel2d, wheel3d, wheel4d, wheel5d, wheel6d, north100d, south100d, north104d, south104d, north94d, south94d, north95d, south95d, north96d, south96d As Double
            wheel1d = Math.Abs(wheel1 - 100)
            wheel2d = Math.Abs(wheel2 - 100)
            wheel3d = Math.Abs(wheel3 - 100)
            wheel4d = Math.Abs(wheel4 - 100)
            wheel5d = Math.Abs(wheel5 - 100)
            wheel6d = Math.Abs(wheel6 - 100)

            wheel1d = Math.Round(wheel1d, 2)
            wheel2d = Math.Round(wheel2d, 2)
            wheel3d = Math.Round(wheel3d, 2)
            wheel4d = Math.Round(wheel4d, 2)
            wheel5d = Math.Round(wheel5d, 2)
            wheel6d = Math.Round(wheel6d, 2)

            north100d = Math.Ceiling(Math.Abs(north100 - 100))
            south100d = Math.Ceiling(Math.Abs(south100 - 100))
            north104d = Math.Ceiling(Math.Abs(north104 - 100))
            south104d = Math.Ceiling(Math.Abs(south104 - 100))
            north94d = Math.Ceiling(Math.Abs(north94 - 100))
            south94d = Math.Ceiling(Math.Abs(south94 - 100))
            north95d = Math.Ceiling(Math.Abs(north95 - 100))
            south95d = Math.Ceiling(Math.Abs(south95 - 100))
            north96d = Math.Ceiling(Math.Abs(north96 - 100))
            south96d = Math.Ceiling(Math.Abs(south96 - 100))

            wheel1 = Math.Ceiling(wheel1)
            wheel2 = Math.Ceiling(wheel2)
            wheel3 = Math.Ceiling(wheel3)
            wheel4 = Math.Ceiling(wheel4)
            wheel5 = Math.Ceiling(wheel5)
            wheel6 = Math.Ceiling(wheel6)
            'Displays
            txtBlastWheel1Perc.Text = "%" + wheel1.ToString
            txtBlastWheel2Perc.Text = "%" + wheel2.ToString
            txtBlastWheel3Perc.Text = "%" + wheel3.ToString
            txtBlastWheel4Perc.Text = "%" + wheel4.ToString
            txtBlastWheel5Perc.Text = "%" + wheel5.ToString
            txtBlastWheel6Perc.Text = "%" + wheel6.ToString
            txtNorth100Perc.Text = "%" + north100.ToString
            txtNorth104Perc.Text = "%" + north104.ToString
            txtNorth94Perc.Text = "%" + north94.ToString
            txtNorth95Perc.Text = "%" + north95.ToString
            txtNorth96Perc.Text = "%" + north96.ToString
            txtSouth100Perc.Text = "%" + south100.ToString
            txtSouth104Perc.Text = "%" + south104.ToString
            txtSouth94Perc.Text = "%" + south94.ToString
            txtSouth95Perc.Text = "%" + south95.ToString
            txtSouth96Perc.Text = "%" + south96.ToString


            Dim saveDate As Date = Date.Now
            Dim rounding1, rounding2, rounding3 As Double
            rounding1 = Math.Round(((wheel1 + wheel2 + wheel3 + wheel4 + wheel5 + wheel6) / 6), 0)
            rounding2 = Math.Round(((north96 + north95 + north94 + north104 + north100) / 5), 0)
            rounding3 = Math.Round(((south100 + south104 + south94 + south95 + south96) / 5), 0)


            GlobalGroupByPartNumber = wheel1
            GlobalGroupByItemClass = wheel2
            GlobalGroupByMonth = wheel3
            GlobalGroupByCustomer = wheel4
            GlobalGroupBySubtotal = wheel5
            GlobalGroupByAll = wheel6
            GlobalSteelOrderPartNumber = north100d
            GlobalSteelOrderRMID = south100d
            GlobalSteelOrderCarbon = north104d
            GlobalSteelOrderSteelSize = south104d
            GlobalSteelOrderSteelDescription = north94d
            GlobalShipmentPrintType = south94d
            GlobalAutoPrintPackingList = north95d
            GlobalSteelReturnCarbon = south95d
            GlobalSteelReturnSize = north96d
            GlobalNoAutoPrintCheckRemittance = south96d
            GlobalAPRemittanceEmail = avgAmps
            GlobalCustomerCreditAPP = txtTotalNorth.Text
            GlobalAPPFPCheckBox = txtTotalSouth.Text
            GlobalTraineeCompany = wheel1d
            GlobalNaftaDate = wheel2d
            GlobalNaftaCustomerID = wheel3d
            GlobalNaftaPrintType = wheel4d
            GlobalNAFTAShipDate = wheel5d
            GlobalTraineeName = wheel6d



            Try
                cmd1 = New SqlCommand("SELECT * FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID", con)
                cmd1.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = cboShotID.Text

                If con.State = ConnectionState.Closed Then con.Open()

                GDS = New DataSet()
                myAdapter.SelectCommand = cmd1
                myAdapter.Fill(GDS, "ScreenShotAnalysisTable")

                'Display Report
                Dim NewPrintShotScreening As New PrintShotScreening
                NewPrintShotScreening.Show()
            Catch ex As System.Exception
            End Try
        End If
    End Sub

    'Load From Table

    Private Sub LoadShotID()
        Using cm3 As New SqlCommand("SELECT ShotID FROM ScreenShotAnalysisTable ORDER BY ShotID", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cm3
            myAdapter1.Fill(ds1, "ScreenShotAnalysisTable")
            cboShotID.DataSource = ds1.Tables("ScreenShotAnalysisTable")
            con.Close()
            cboShotID.SelectedIndex = -1
        End Using
    End Sub

    Private Sub LoaddgvShotInfo()
        Using cmdd3 As New SqlCommand("SELECT * FROM ScreenShotAnalysisTable ORDER BY ShotID", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmdd3
            myAdapter1.Fill(ds1, "ScreenShotAnalysisTable")
            dgvShotAnalysis.DataSource = ds1.Tables("ScreenShotAnalysisTable")
            con.Close()
        End Using
    End Sub

    Private Sub ViewShotTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadShotID()
        LoaddgvShotInfo()
    End Sub

    Private Sub ViewShotTest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt AndAlso (e.KeyCode = Keys.V)) Then
            ViewReport()
        End If
        If (e.Alt AndAlso (e.KeyCode = Keys.B)) Then
            viewSave()
        End If
        If (e.Alt AndAlso (e.KeyCode = Keys.D)) Then
            Deletion()
        End If
    End Sub

    'Form Events

    Private Sub cboShotID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShotID.SelectedIndexChanged
        'Displays relevant information for the selected Authorization number
        Dim ItemDataStatement5 As String = "SELECT * FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID"
        Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
        ItemDataCommand5.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = cboShotID.Text
        Dim AbrSize, PanNumber, PANNumberSouth, N104, N100, N96, N95, N94, W1, W2, W3, W4, W5, W6, S104, S100, S96, S95, S94 As String
        Dim dateC As Date
        If con.State = ConnectionState.Closed Then con.Open()
        Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
            Try

                If reader5.HasRows Then
                    reader5.Read()
                    If IsDBNull(reader5.Item("AbrasiveSize")) Then
                        AbrSize = " "
                    Else
                        AbrSize = reader5.Item("AbrasiveSize")
                    End If
                    If IsDBNull(reader5.Item("PANNumber")) Then
                        PanNumber = " "
                    Else
                        PanNumber = reader5.Item("PANNumber")
                    End If
                    If IsDBNull(reader5.Item("PANNumberSouth")) Then
                        PANNumberSouth = " "
                    Else
                        PANNumberSouth = reader5.Item("PANNumberSouth")
                    End If
                    If IsDBNull(reader5.Item("DateCreated")) Then
                        dateC = Now
                    Else
                        dateC = reader5.Item("DateCreated")
                    End If
                    If IsDBNull(reader5.Item("North104")) Then
                        N104 = " "
                    Else
                        N104 = reader5.Item("North104")
                    End If
                    If IsDBNull(reader5.Item("North100")) Then
                        N100 = " "
                    Else
                        N100 = reader5.Item("North100")
                    End If
                    If IsDBNull(reader5.Item("North96")) Then
                        N96 = " "
                    Else
                        N96 = reader5.Item("North96")
                    End If
                    If IsDBNull(reader5.Item("North95")) Then
                        N95 = " "
                    Else
                        N95 = reader5.Item("North95")
                    End If
                    If IsDBNull(reader5.Item("North94")) Then
                        N94 = " "
                    Else
                        N94 = reader5.Item("North94")
                    End If
                    If IsDBNull(reader5.Item("South104")) Then
                        S104 = " "
                    Else
                        S104 = reader5.Item("South104")
                    End If
                    If IsDBNull(reader5.Item("South100")) Then
                        S100 = " "
                    Else
                        S100 = reader5.Item("South100")
                    End If
                    If IsDBNull(reader5.Item("South96")) Then
                        S96 = " "
                    Else
                        S96 = reader5.Item("South96")
                    End If
                    If IsDBNull(reader5.Item("South95")) Then
                        S95 = " "
                    Else
                        S95 = reader5.Item("South95")
                    End If
                    If IsDBNull(reader5.Item("South94")) Then
                        S94 = " "
                    Else
                        S94 = reader5.Item("South94")
                    End If
                    If IsDBNull(reader5.Item("Wheel1")) Then
                        W1 = " "
                    Else
                        W1 = reader5.Item("Wheel1")
                    End If
                    If IsDBNull(reader5.Item("Wheel2")) Then
                        W2 = " "
                    Else
                        W2 = reader5.Item("Wheel2")
                    End If
                    If IsDBNull(reader5.Item("Wheel3")) Then
                        W3 = " "
                    Else
                        W3 = reader5.Item("Wheel3")
                    End If
                    If IsDBNull(reader5.Item("Wheel4")) Then
                        W4 = " "
                    Else
                        W4 = reader5.Item("Wheel4")
                    End If
                    If IsDBNull(reader5.Item("Wheel5")) Then
                        W5 = " "
                    Else
                        W5 = reader5.Item("Wheel5")
                    End If
                    If IsDBNull(reader5.Item("Wheel6")) Then
                        W6 = " "
                    Else
                        W6 = reader5.Item("Wheel6")
                    End If
                    reader5.Close()
                Else
                    AbrSize = ""
                    PanNumber = ""
                    PANNumberSouth = ""
                    dateC = Now
                    N104 = ""
                    N100 = ""
                    N96 = ""
                    N95 = ""
                    N94 = ""
                    S104 = ""
                    S100 = ""
                    S96 = ""
                    S95 = ""
                    S94 = ""
                    W1 = ""
                    W2 = ""
                    W3 = ""
                    W4 = ""
                    W5 = ""
                    W6 = ""
                End If
                txtPAN.Text = PanNumber
                txtPANSouth.Text = PANNumberSouth
                txtAbrSize.Text = AbrSize
                dtpDate.Value = dateC
                txtNorth104.Text = N104
                txtNorth100.Text = N100
                txtNorth96.Text = N96
                txtNorth95.Text = N95
                txtNorth94.Text = N94
                txtSouth104.Text = S104
                txtSouth100.Text = S100
                txtSouth96.Text = S96
                txtSouth95.Text = S95
                txtSouth94.Text = S94
                txtBlastWheel1.Text = W1
                txtBlastWheel2.Text = W2
                txtBlastWheel3.Text = W3
                txtBlastWheel4.Text = W4
                txtBlastWheel5.Text = W5
                txtBlastWheel6.Text = W6



            Catch ex As System.Exception

            End Try
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShotAnalysis.CellContentClick
        If dgvShotAnalysis.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvShotAnalysis.CurrentCell.RowIndex
            Dim data As String = Me.dgvShotAnalysis.Rows(RowIndex).Cells("ShotIDDataGridViewTextBoxColumn").Value.ToString()
            cboShotID.Text = data
            'Displays relevant information for the selected Authorization number
            Dim ItemDataStatement5 As String = "SELECT * FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID"
            Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
            ItemDataCommand5.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = data
            Dim AbrSize, PanNumber, PANNumberSouth, N104, N100, N96, N95, N94, W1, W2, W3, W4, W5, W6, S104, S100, S96, S95, S94 As String
            Dim dateC As Date
            If con.State = ConnectionState.Closed Then con.Open()
            Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
                Try

                    If reader5.HasRows Then
                        reader5.Read()
                        If IsDBNull(reader5.Item("AbrasiveSize")) Then
                            AbrSize = " "
                        Else
                            AbrSize = reader5.Item("AbrasiveSize")
                        End If
                        If IsDBNull(reader5.Item("PANNumber")) Then
                            PanNumber = " "
                        Else
                            PanNumber = reader5.Item("PANNumber")
                        End If
                        If IsDBNull(reader5.Item("PANNumberSouth")) Then
                            PANNumberSouth = " "
                        Else
                            PANNumberSouth = reader5.Item("PANNumberSouth")
                        End If
                        If IsDBNull(reader5.Item("DateCreated")) Then
                            dateC = Now
                        Else
                            dateC = reader5.Item("DateCreated")
                        End If
                        If IsDBNull(reader5.Item("North104")) Then
                            N104 = " "
                        Else
                            N104 = reader5.Item("North104")
                        End If
                        If IsDBNull(reader5.Item("North100")) Then
                            N100 = " "
                        Else
                            N100 = reader5.Item("North100")
                        End If
                        If IsDBNull(reader5.Item("North96")) Then
                            N96 = " "
                        Else
                            N96 = reader5.Item("North96")
                        End If
                        If IsDBNull(reader5.Item("North95")) Then
                            N95 = " "
                        Else
                            N95 = reader5.Item("North95")
                        End If
                        If IsDBNull(reader5.Item("North94")) Then
                            N94 = " "
                        Else
                            N94 = reader5.Item("North94")
                        End If
                        If IsDBNull(reader5.Item("South104")) Then
                            S104 = " "
                        Else
                            S104 = reader5.Item("South104")
                        End If
                        If IsDBNull(reader5.Item("South100")) Then
                            S100 = " "
                        Else
                            S100 = reader5.Item("South100")
                        End If
                        If IsDBNull(reader5.Item("South96")) Then
                            S96 = " "
                        Else
                            S96 = reader5.Item("South96")
                        End If
                        If IsDBNull(reader5.Item("South95")) Then
                            S95 = " "
                        Else
                            S95 = reader5.Item("South95")
                        End If
                        If IsDBNull(reader5.Item("South94")) Then
                            S94 = " "
                        Else
                            S94 = reader5.Item("South94")
                        End If
                        If IsDBNull(reader5.Item("Wheel1")) Then
                            W1 = " "
                        Else
                            W1 = reader5.Item("Wheel1")
                        End If
                        If IsDBNull(reader5.Item("Wheel2")) Then
                            W2 = " "
                        Else
                            W2 = reader5.Item("Wheel2")
                        End If
                        If IsDBNull(reader5.Item("Wheel3")) Then
                            W3 = " "
                        Else
                            W3 = reader5.Item("Wheel3")
                        End If
                        If IsDBNull(reader5.Item("Wheel4")) Then
                            W4 = " "
                        Else
                            W4 = reader5.Item("Wheel4")
                        End If
                        If IsDBNull(reader5.Item("Wheel5")) Then
                            W5 = " "
                        Else
                            W5 = reader5.Item("Wheel5")
                        End If
                        If IsDBNull(reader5.Item("Wheel6")) Then
                            W6 = " "
                        Else
                            W6 = reader5.Item("Wheel6")
                        End If
                        reader5.Close()
                    Else
                        AbrSize = ""
                        PanNumber = ""
                        PANNumberSouth = ""
                        dateC = Now
                        N104 = ""
                        N100 = ""
                        N96 = ""
                        N95 = ""
                        N94 = ""
                        S104 = ""
                        S100 = ""
                        S96 = ""
                        S95 = ""
                        S94 = ""
                        W1 = ""
                        W2 = ""
                        W3 = ""
                        W4 = ""
                        W5 = ""
                        W6 = ""
                    End If
                    txtPAN.Text = PanNumber
                    txtPANSouth.Text = PANNumberSouth
                    txtAbrSize.Text = AbrSize
                    dtpDate.Value = dateC
                    txtNorth104.Text = N104
                    txtNorth100.Text = N100
                    txtNorth96.Text = N96
                    txtNorth95.Text = N95
                    txtNorth94.Text = N94
                    txtSouth104.Text = S104
                    txtSouth100.Text = S100
                    txtSouth96.Text = S96
                    txtSouth95.Text = S95
                    txtSouth94.Text = S94
                    txtBlastWheel1.Text = W1
                    txtBlastWheel2.Text = W2
                    txtBlastWheel3.Text = W3
                    txtBlastWheel4.Text = W4
                    txtBlastWheel5.Text = W5
                    txtBlastWheel6.Text = W6


                Catch ex As System.Exception

                End Try
            End Using

        End If



    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShotAnalysis.CellContentDoubleClick
        If dgvShotAnalysis.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvShotAnalysis.CurrentCell.RowIndex
            Dim data As String = Me.dgvShotAnalysis.Rows(RowIndex).Cells("ShotIDDataGridViewTextBoxColumn").Value.ToString()
            cboShotID.Text = data
            'Displays relevant information for the selected Authorization number
            Dim ItemDataStatement5 As String = "SELECT * FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID"
            Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
            ItemDataCommand5.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = data
            Dim AbrSize, PanNumber, PANNumberSouth, N104, N100, N96, N95, N94, W1, W2, W3, W4, W5, W6, S104, S100, S96, S95, S94 As String
            Dim dateC As Date
            If con.State = ConnectionState.Closed Then con.Open()
            Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
                Try

                    If reader5.HasRows Then
                        reader5.Read()
                        If IsDBNull(reader5.Item("AbrasiveSize")) Then
                            AbrSize = " "
                        Else
                            AbrSize = reader5.Item("AbrasiveSize")
                        End If
                        If IsDBNull(reader5.Item("PANNumber")) Then
                            PanNumber = " "
                        Else
                            PanNumber = reader5.Item("PANNumber")
                        End If
                        If IsDBNull(reader5.Item("PANNumberSouth")) Then
                            PANNumberSouth = " "
                        Else
                            PANNumberSouth = reader5.Item("PANNumberSouth")
                        End If
                        If IsDBNull(reader5.Item("DateCreated")) Then
                            dateC = Now
                        Else
                            dateC = reader5.Item("DateCreated")
                        End If
                        If IsDBNull(reader5.Item("North104")) Then
                            N104 = " "
                        Else
                            N104 = reader5.Item("North104")
                        End If
                        If IsDBNull(reader5.Item("North100")) Then
                            N100 = " "
                        Else
                            N100 = reader5.Item("North100")
                        End If
                        If IsDBNull(reader5.Item("North96")) Then
                            N96 = " "
                        Else
                            N96 = reader5.Item("North96")
                        End If
                        If IsDBNull(reader5.Item("North95")) Then
                            N95 = " "
                        Else
                            N95 = reader5.Item("North95")
                        End If
                        If IsDBNull(reader5.Item("North94")) Then
                            N94 = " "
                        Else
                            N94 = reader5.Item("North94")
                        End If
                        If IsDBNull(reader5.Item("South104")) Then
                            S104 = " "
                        Else
                            S104 = reader5.Item("South104")
                        End If
                        If IsDBNull(reader5.Item("South100")) Then
                            S100 = " "
                        Else
                            S100 = reader5.Item("South100")
                        End If
                        If IsDBNull(reader5.Item("South96")) Then
                            S96 = " "
                        Else
                            S96 = reader5.Item("South96")
                        End If
                        If IsDBNull(reader5.Item("South95")) Then
                            S95 = " "
                        Else
                            S95 = reader5.Item("South95")
                        End If
                        If IsDBNull(reader5.Item("South94")) Then
                            S94 = " "
                        Else
                            S94 = reader5.Item("South94")
                        End If
                        If IsDBNull(reader5.Item("Wheel1")) Then
                            W1 = " "
                        Else
                            W1 = reader5.Item("Wheel1")
                        End If
                        If IsDBNull(reader5.Item("Wheel2")) Then
                            W2 = " "
                        Else
                            W2 = reader5.Item("Wheel2")
                        End If
                        If IsDBNull(reader5.Item("Wheel3")) Then
                            W3 = " "
                        Else
                            W3 = reader5.Item("Wheel3")
                        End If
                        If IsDBNull(reader5.Item("Wheel4")) Then
                            W4 = " "
                        Else
                            W4 = reader5.Item("Wheel4")
                        End If
                        If IsDBNull(reader5.Item("Wheel5")) Then
                            W5 = " "
                        Else
                            W5 = reader5.Item("Wheel5")
                        End If
                        If IsDBNull(reader5.Item("Wheel6")) Then
                            W6 = " "
                        Else
                            W6 = reader5.Item("Wheel6")
                        End If
                        reader5.Close()
                    Else
                        AbrSize = ""
                        PanNumber = ""
                        PANNumberSouth = ""
                        dateC = Now
                        N104 = ""
                        N100 = ""
                        N96 = ""
                        N95 = ""
                        N94 = ""
                        S104 = ""
                        S100 = ""
                        S96 = ""
                        S95 = ""
                        S94 = ""
                        W1 = ""
                        W2 = ""
                        W3 = ""
                        W4 = ""
                        W5 = ""
                        W6 = ""
                    End If
                    txtPAN.Text = PanNumber
                    txtPANSouth.Text = PANNumberSouth
                    txtAbrSize.Text = AbrSize
                    dtpDate.Value = dateC
                    txtNorth104.Text = N104
                    txtNorth100.Text = N100
                    txtNorth96.Text = N96
                    txtNorth95.Text = N95
                    txtNorth94.Text = N94
                    txtSouth104.Text = S104
                    txtSouth100.Text = S100
                    txtSouth96.Text = S96
                    txtSouth95.Text = S95
                    txtSouth94.Text = S94
                    txtBlastWheel1.Text = W1
                    txtBlastWheel2.Text = W2
                    txtBlastWheel3.Text = W3
                    txtBlastWheel4.Text = W4
                    txtBlastWheel5.Text = W5
                    txtBlastWheel6.Text = W6


                Catch ex As System.Exception

                End Try
            End Using

        End If

        If validation() Then
            Dim wheel1, wheel2, wheel3, wheel4, wheel5, wheel6, north100, north104, north94, north95, north96, south100, south104, south94, south95, south96 As Double
            wheel1 = Val(txtBlastWheel1.Text)
            wheel2 = Val(txtBlastWheel2.Text)
            wheel3 = Val(txtBlastWheel3.Text)
            wheel4 = Val(txtBlastWheel4.Text)
            wheel5 = Val(txtBlastWheel5.Text)
            wheel6 = Val(txtBlastWheel6.Text)
            north100 = Val(txtNorth100.Text)
            north104 = Val(txtNorth104.Text)
            north94 = Val(txtNorth94.Text)
            north95 = Val(txtNorth95.Text)
            north96 = Val(txtNorth96.Text)
            south100 = Val(txtSouth100.Text)
            south104 = Val(txtSouth104.Text)
            south94 = Val(txtSouth94.Text)
            south95 = Val(txtSouth95.Text)
            south96 = Val(txtSouth96.Text)

            txtTotalNorth.Text = north100 + north104 + north94 + north95 + north96
            txtTotalSouth.Text = south100 + south104 + south94 + south95 + south96


            'Calculations
            wheel1 = Math.Round(((wheel1 / 30) * 100), 4)
            wheel2 = Math.Round(((wheel2 / 30) * 100), 4)
            wheel3 = Math.Round(((wheel3 / 30) * 100), 4)
            wheel4 = Math.Round(((wheel4 / 30) * 100), 4)
            wheel5 = Math.Round(((wheel5 / 60) * 100), 4)
            wheel6 = Math.Round(((wheel6 / 60) * 100), 4)
            north100 = Math.Round(((north100 / 104) * 100), 4)
            south100 = Math.Round(((south100 / 104) * 100), 4)
            north104 = Math.Round(((north104 / 108) * 100), 4)
            south104 = Math.Round(((south104 / 108) * 100), 4)
            north94 = Math.Round(((north94 / 97) * 100), 4)
            south94 = Math.Round(((south94 / 97) * 100), 4)
            north95 = Math.Round(((north95 / 97) * 100), 4)
            south95 = Math.Round(((south95 / 97) * 100), 4)
            north96 = Math.Round(((north96 / 99) * 100), 4)
            south96 = Math.Round(((south96 / 99) * 100), 4)

            'Averages
            Dim avgAmps, avgNorth, avgSouth As Double
            avgAmps = Math.Round(((wheel1 + wheel2 + wheel3 + wheel4 + wheel5 + wheel6) / 6), 2)
            avgNorth = Math.Round(((north96 + north95 + north94 + north104 + north100) / 5), 2)
            avgSouth = Math.Round(((south100 + south104 + south94 + south95 + south96) / 5), 2)
            txtTotalAmps.Text = avgAmps

            'Difference calculations
            Dim wheel1d, wheel2d, wheel3d, wheel4d, wheel5d, wheel6d, north100d, south100d, north104d, south104d, north94d, south94d, north95d, south95d, north96d, south96d As Double
            wheel1d = Math.Abs(wheel1 - 100)
            wheel2d = Math.Abs(wheel2 - 100)
            wheel3d = Math.Abs(wheel3 - 100)
            wheel4d = Math.Abs(wheel4 - 100)
            wheel5d = Math.Abs(wheel5 - 100)
            wheel6d = Math.Abs(wheel6 - 100)

            wheel1d = Math.Round(wheel1d, 2)
            wheel2d = Math.Round(wheel2d, 2)
            wheel3d = Math.Round(wheel3d, 2)
            wheel4d = Math.Round(wheel4d, 2)
            wheel5d = Math.Round(wheel5d, 2)
            wheel6d = Math.Round(wheel6d, 2)

            north100d = Math.Ceiling(Math.Abs(north100 - 100))
            south100d = Math.Ceiling(Math.Abs(south100 - 100))
            north104d = Math.Ceiling(Math.Abs(north104 - 100))
            south104d = Math.Ceiling(Math.Abs(south104 - 100))
            north94d = Math.Ceiling(Math.Abs(north94 - 100))
            south94d = Math.Ceiling(Math.Abs(south94 - 100))
            north95d = Math.Ceiling(Math.Abs(north95 - 100))
            south95d = Math.Ceiling(Math.Abs(south95 - 100))
            north96d = Math.Ceiling(Math.Abs(north96 - 100))
            south96d = Math.Ceiling(Math.Abs(south96 - 100))

            wheel1 = Math.Ceiling(wheel1)
            wheel2 = Math.Ceiling(wheel2)
            wheel3 = Math.Ceiling(wheel3)
            wheel4 = Math.Ceiling(wheel4)
            wheel5 = Math.Ceiling(wheel5)
            wheel6 = Math.Ceiling(wheel6)
            'Displays
            txtBlastWheel1Perc.Text = "%" + wheel1.ToString
            txtBlastWheel2Perc.Text = "%" + wheel2.ToString
            txtBlastWheel3Perc.Text = "%" + wheel3.ToString
            txtBlastWheel4Perc.Text = "%" + wheel4.ToString
            txtBlastWheel5Perc.Text = "%" + wheel5.ToString
            txtBlastWheel6Perc.Text = "%" + wheel6.ToString
            txtNorth100Perc.Text = "%" + north100.ToString
            txtNorth104Perc.Text = "%" + north104.ToString
            txtNorth94Perc.Text = "%" + north94.ToString
            txtNorth95Perc.Text = "%" + north95.ToString
            txtNorth96Perc.Text = "%" + north96.ToString
            txtSouth100Perc.Text = "%" + south100.ToString
            txtSouth104Perc.Text = "%" + south104.ToString
            txtSouth94Perc.Text = "%" + south94.ToString
            txtSouth95Perc.Text = "%" + south95.ToString
            txtSouth96Perc.Text = "%" + south96.ToString


            Dim saveDate As Date = Date.Now
            Dim rounding1, rounding2, rounding3 As Double
            rounding1 = Math.Round(((wheel1 + wheel2 + wheel3 + wheel4 + wheel5 + wheel6) / 6), 0)
            rounding2 = Math.Round(((north96 + north95 + north94 + north104 + north100) / 5), 0)
            rounding3 = Math.Round(((south100 + south104 + south94 + south95 + south96) / 5), 0)


            GlobalGroupByPartNumber = wheel1
            GlobalGroupByItemClass = wheel2
            GlobalGroupByMonth = wheel3
            GlobalGroupByCustomer = wheel4
            GlobalGroupBySubtotal = wheel5
            GlobalGroupByAll = wheel6
            GlobalSteelOrderPartNumber = north100d
            GlobalSteelOrderRMID = south100d
            GlobalSteelOrderCarbon = north104d
            GlobalSteelOrderSteelSize = south104d
            GlobalSteelOrderSteelDescription = north94d
            GlobalShipmentPrintType = south94d
            GlobalAutoPrintPackingList = north95d
            GlobalSteelReturnCarbon = south95d
            GlobalSteelReturnSize = north96d
            GlobalNoAutoPrintCheckRemittance = south96d
            GlobalAPRemittanceEmail = avgAmps
            GlobalCustomerCreditAPP = txtTotalNorth.Text
            GlobalAPPFPCheckBox = txtTotalSouth.Text
            GlobalTraineeCompany = wheel1d
            GlobalNaftaDate = wheel2d
            GlobalNaftaCustomerID = wheel3d
            GlobalNaftaPrintType = wheel4d
            GlobalNAFTAShipDate = wheel5d
            GlobalTraineeName = wheel6d



            Try
                cmd1 = New SqlCommand("SELECT * FROM ScreenShotAnalysisTable WHERE ShotID = @ShotID", con)
                cmd1.Parameters.Add("@ShotID", SqlDbType.VarChar).Value = cboShotID.Text

                If con.State = ConnectionState.Closed Then con.Open()

                GDS = New DataSet()
                myAdapter.SelectCommand = cmd1
                myAdapter.Fill(GDS, "ScreenShotAnalysisTable")

                'Display Report
                Dim NewPrintShotScreening As New PrintShotScreening
                NewPrintShotScreening.Show()
            Catch ex As System.Exception
            End Try
        End If
    End Sub

    'Tool Strip Events

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ExportCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportCSVToolStripMenuItem.Click
        Dim headers = (From header As DataGridViewColumn In dgvShotAnalysis.Columns.Cast(Of DataGridViewColumn)() _
              Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In dgvShotAnalysis.Rows.Cast(Of DataGridViewRow)() _
                   Where Not row.IsNewRow _
                   Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
        Using sw As New IO.StreamWriter("ScreenShotAnalysisReport.csv")
            sw.WriteLine(String.Join(",", headers))
            For Each r In rows
                sw.WriteLine("""" & String.Join(""",""", r) & """")
            Next
        End Using
        Process.Start("ScreenShotAnalysisReport.csv")

    End Sub

End Class