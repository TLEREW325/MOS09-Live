Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class QCTools
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Dim MetricInput, DecimalInput, DecimalOutput, MetricOutput As Double
    Dim AverageEntry, AverageTotal, AverageFinal As Double
    Dim AverageCounter As Integer
    Dim PoundsAt2, PoundsUltimate, Area, PSIat2, MPAat2, KNat2, PSIult, MPAult, KNult As Double



    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtDecimalInput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDecimalInput.TextChanged
        DecimalInput = Val(txtDecimalInput.Text)
    End Sub

    Private Sub txtMetricInput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMetricInput.TextChanged
        MetricInput = Val(txtMetricInput.Text)
    End Sub

    Private Sub cmdClear01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear01.Click
        txtDecimalInput.Text = ""
        lblMetricConversion.Text = ""
    End Sub

    Private Sub cmdClear02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear02.Click
        txtMetricInput.Text = ""
        lblDecimalConversion.Text = ""
    End Sub

    Private Sub cmdConvert01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConvert01.Click
        MetricOutput = DecimalInput * 25.4000508001016
        lblMetricConversion.Text = FormatNumber(MetricOutput, 2) + " millimeters"
    End Sub

    Private Sub cmdConvert02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConvert02.Click
        DecimalOutput = MetricInput * 0.03937
        lblDecimalConversion.Text = FormatNumber(DecimalOutput, 2) + " inches"
    End Sub

    Private Sub txtAverageEntry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAverageEntry.TextChanged
        AverageEntry = Val(txtAverageEntry.Text)
    End Sub

    Private Sub cmdEnterValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterValues.Click
        AverageCounter = AverageCounter + 1
        AverageTotal = AverageTotal + AverageEntry
        AverageEntry = 0
        txtAverageEntry.Text = ""
        txtAverageEntry.Focus()
    End Sub

    Private Sub cmdAverage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAverage.Click
        lblRunningTotal.Text = FormatNumber(AverageTotal, 2)
        lblItems.Text = AverageCounter
        AverageFinal = AverageTotal / AverageCounter
        lblAverage.Text = FormatNumber(AverageFinal, 2)
        txtAverageEntry.Focus()
    End Sub

    Private Sub cmdClearAverage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAverage.Click
        txtAverageEntry.Text = ""
        lblAverage.Text = ""
        lblItems.Text = ""
        lblRunningTotal.Text = ""
        AverageCounter = 0
        AverageEntry = 0
        AverageFinal = 0
        AverageTotal = 0
        txtAverageEntry.Focus()
    End Sub

    Private Sub txtEnterPounds2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnterPounds2.TextChanged
        PoundsAt2 = Val(txtEnterPounds2.Text)
    End Sub

    Private Sub txtArea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        Area = Val(txtArea.Text)
    End Sub

    Private Sub txtEnterPoundsUlt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnterPoundsUlt.TextChanged
        PoundsUltimate = Val(txtEnterPoundsUlt.Text)
    End Sub

    Private Sub cmdClearTensile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTensile.Click
        txtEnterPoundsUlt.Text = ""
        txtArea.Text = ""
        txtEnterPounds2.Text = ""
        lblUltimateKN.Text = ""
        lblUltimateMPA.Text = ""
        lblUltimatePSI.Text = ""
        lblYieldKN.Text = ""
        lblYieldMPA.Text = ""
        lblYieldPSI.Text = ""
        PoundsAt2 = 0
        PoundsUltimate = 0
        Area = 0
        PSIat2 = 0
        PSIult = 0
        MPAat2 = 0
        MPAult = 0
        KNat2 = 0
        KNult = 0
        txtArea.Focus()
    End Sub

    Private Sub cmdCalculateTensile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateTensile.Click

        PSIat2 = PoundsAt2 / Area
        PSIult = PoundsUltimate / Area
        MPAat2 = PSIat2 / 145.04457
        MPAult = PSIult / 145.04457
        KNat2 = MPAat2 / 3.51961
        KNult = MPAult / 3.51961

        lblUltimateMPA.Text = FormatNumber(MPAult, 0)
        lblUltimatePSI.Text = FormatNumber(PSIult, 0)
        lblYieldMPA.Text = FormatNumber(MPAat2, 0)
        lblYieldPSI.Text = FormatNumber(PSIat2, 0)
        lblYieldKN.Text = FormatNumber(KNat2, 0)
        lblUltimateKN.Text = FormatNumber(KNult, 0)

        txtArea.Focus()

    End Sub

    Private Sub cmdUpdateBlueprints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateBlueprints.Click
        'Check Fields
        If txtOldBP.Text = "" Or txtNewBP.Text = "" Then
            MsgBox("You must enter an old and new blueprint number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtOldRevision.Text = "" And txtNewRevision.Text = "" Then
            'Update blueprint only
            cmd = New SqlCommand("UPDATE FOXTable SET BlueprintNumber = @NewBlueprintNumber WHERE BlueprintNumber = @OldBlueprintNumber", con)

            With cmd.Parameters
                .Add("@OldBlueprintNumber", SqlDbType.VarChar).Value = txtOldBP.Text
                .Add("@NewBlueprintNumber", SqlDbType.VarChar).Value = txtNewBP.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Foxes have been updated.", MsgBoxStyle.OkOnly)
        End If

        If txtOldRevision.Text <> "" Or txtNewRevision.Text <> "" Then
            'Update blueprint and revision number
            cmd = New SqlCommand("UPDATE FOXTable SET BlueprintNumber = @NewBlueprintNumber, BlueprintRevision = @BlueprintRevision WHERE BlueprintNumber = @OldBlueprintNumber", con)

            With cmd.Parameters
                .Add("@OldBlueprintNumber", SqlDbType.VarChar).Value = txtOldBP.Text
                .Add("@NewBlueprintNumber", SqlDbType.VarChar).Value = txtNewBP.Text
                .Add("@BlueprintRevision", SqlDbType.VarChar).Value = txtNewRevision.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Foxes have been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdClearBlueprints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBlueprints.Click
        txtOldBP.Clear()
        txtOldRevision.Clear()
        txtNewBP.Clear()
        txtNewRevision.Clear()
    End Sub

    Private Sub cmdAddClampcoPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddClampcoPart.Click
        'Validate Part Number
        Dim CountPartNumber As Integer = 0

        Dim CountPartNumberStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CountPartNumberCommand As New SqlCommand(CountPartNumberStatement, con)
        CountPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtClampcoPartNumber.Text
        CountPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtClampcoDivision.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountPartNumber = CInt(CountPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CountPartNumber = 0
        End Try
        con.Close()

        If CountPartNumber = 0 Then
            MsgBox("Part # does not exist in that division.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        'Validate Fields
        If txtClampcoPartNumber.Text = "" Then
            MsgBox("You must enter a part #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtClampcoDivision.Text = "" Then
            MsgBox("You must enter a Division ID.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Val(txtClampcoMaxPSI.Text) = 0 Then
            txtClampcoMaxPSI.Text = 0
        End If
        If Not IsNumeric(txtClampcoMaxPSI.Text) Then
            MsgBox("You must enter a number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Not IsNumeric(txtClampcoMinPSI.Text) Then
            MsgBox("You must enter a number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            'Insert into table
            cmd = New SqlCommand("INSERT INTO TrufitCertificationMechanicalTestTolerances (PartNumber, BlueprintNumber, UltimateMinPSI, UltimateMaxPSI, DivisionID, Comment) values (@PartNumber, @BlueprintNumber, @UltimateMinPSI, @UltimateMaxPSI, @DivisionID, @Comment)", con)

            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtClampcoPartNumber.Text
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtClampcoBP.Text
                .Add("@UltimateMinPSI", SqlDbType.VarChar).Value = txtClampcoMinPSI.Text
                .Add("@UltimateMaxPSI", SqlDbType.VarChar).Value = txtClampcoMaxPSI.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtClampcoDivision.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtClampcoComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Update table
            cmd = New SqlCommand("UPDATE TrufitCertificationMechanicalTestTolerances SET BlueprintNumber = @BlueprintNumber, UltimateMinPSI = @UltimateMinPSI, UltimateMaxPSI = @UltimateMaxPSI, Comment = @Comment WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = txtClampcoPartNumber.Text
                .Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtClampcoBP.Text
                .Add("@UltimateMinPSI", SqlDbType.VarChar).Value = txtClampcoMinPSI.Text
                .Add("@UltimateMaxPSI", SqlDbType.VarChar).Value = txtClampcoMaxPSI.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtClampcoDivision.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtClampcoComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try

        MsgBox("Part has been added/updated.", MsgBoxStyle.OkOnly)

        cmdClampcoClear_Click(sender, e)
    End Sub

    Private Sub cmdClampcoClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClampcoClear.Click
        txtClampcoBP.Clear()
        txtClampcoComment.Clear()
        txtClampcoDivision.Clear()
        txtClampcoMaxPSI.Clear()
        txtClampcoMinPSI.Clear()
        txtClampcoPartNumber.Clear()
    End Sub
End Class