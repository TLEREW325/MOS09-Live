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
Public Class SOPriceBracket
    Inherits System.Windows.Forms.Form

    'Price Level 1 = 100 to 199
    Dim P1 As Double = 0
    'Price Level 2 = 200 to 299
    Dim P2 As Double = 0
    'Price Level 3 = 300 to 399
    Dim P3 As Double = 0
    'Price Level 4 = 400 to 499
    Dim P4 As Double = 0
    'Price Level 5 = 500 to 749
    Dim P5 As Double = 0
    'Price Level 6 = 750 to 999
    Dim P6 As Double = 0
    'Price Level 7 = 1000 to 2499
    Dim P7 As Double = 0
    'Price Level 8 = 2500 to 4999
    Dim P8 As Double = 0
    'Price Level 9 = 5000 to 9999
    Dim P9 As Double = 0
    'Price Level 10 = 10000 to 24999
    Dim P10 As Double = 0
    'Price Level 11 = 25000 to 49999
    Dim P11 As Double = 0
    'Price Level 12 = 50000 to 99999
    Dim P12 As Double = 0
    'Price Level 13 = 100000 and higher
    Dim P13 As Double = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub SOPriceBracket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GlobalPriceBracketSource = "Item Maintenance" Then
            LoadPartNumber()
            LoadPartDescription()
            ClearData()

            cboPartNumber.Text = GlobalMaintenancePartNumber
            cboPartNumber.Enabled = True
            cboPartDescription.Enabled = True
        ElseIf GlobalPriceBracketSource = "Sales Order" Then
            LoadPartNumber()
            LoadPartDescription()
            ClearData()

            cboPartNumber.Text = GlobalSOPartNumber
            cboPartNumber.Enabled = True
            cboPartDescription.Enabled = True
        Else
            cboPartNumber.Text = GlobalMaintenancePartNumber
            cboPartNumber.Enabled = False
            cboPartDescription.Enabled = False
            LoadDescriptionByPart()
            LoadPriceBrackets()
        End If

        'If TWE, rename labels and don't show other brackets.
        If GlobalDivisionCode = "TWE" Then
            SaveToolStripMenuItem.Enabled = True

            lblOne.Text = "Dist. Pricing"
            lblTwo.Text = "End-User Pricing"
            lblThree.Text = "SWP Pricing"
            lblFour.Text = "RED-D-ARC Pricing"
            lblFive.Text = "Hanlon Pricing"
            lblSix.Visible = False
            lblSeven.Visible = False
            lblEight.Visible = False
            lblNine.Visible = False
            lblTen.Visible = False
            lblEleven.Visible = False
            lblTwelve.Visible = False
            lblThirteen.Visible = False
            txtPrice6.Visible = False
            txtPrice7.Visible = False
            txtPrice8.Visible = False
            txtPrice9.Visible = False
            txtPrice10.Visible = False
            txtPrice11.Visible = False
            txtPrice11.Visible = False
            txtPrice12.Visible = False
            txtPrice13.Visible = False
        Else
            SaveToolStripMenuItem.Enabled = False

            lblOne.Text = "100 to 199 pcs."
            lblTwo.Text = "200 to 299 pcs."
            lblThree.Text = "300 to 399 pcs."
            lblFour.Text = "400 to 499 pcs."
            lblFive.Text = "500 to 749 pcs."
            lblSix.Visible = True
            lblSeven.Visible = True
            lblEight.Visible = True
            lblNine.Visible = True
            lblTen.Visible = True
            lblEleven.Visible = True
            lblTwelve.Visible = True
            lblThirteen.Visible = True
            txtPrice6.Visible = True
            txtPrice7.Visible = True
            txtPrice8.Visible = True
            txtPrice9.Visible = True
            txtPrice10.Visible = True
            txtPrice11.Visible = True
            txtPrice11.Visible = True
            txtPrice12.Visible = True
            txtPrice13.Visible = True
        End If
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartDescription.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadPriceBrackets()
        Dim PriceLevel1Statement As String = "SELECT B100To199 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel1Command As New SqlCommand(PriceLevel1Statement, con)
        PriceLevel1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel2Statement As String = "SELECT B200To299 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel2Command As New SqlCommand(PriceLevel2Statement, con)
        PriceLevel2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel3Statement As String = "SELECT B300To399 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel3Command As New SqlCommand(PriceLevel3Statement, con)
        PriceLevel3Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel4Statement As String = "SELECT B400To499 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel4Command As New SqlCommand(PriceLevel4Statement, con)
        PriceLevel4Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel5Statement As String = "SELECT B500To749 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel5Command As New SqlCommand(PriceLevel5Statement, con)
        PriceLevel5Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel6Statement As String = "SELECT B750To999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel6Command As New SqlCommand(PriceLevel6Statement, con)
        PriceLevel6Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel7Statement As String = "SELECT B1000To2499 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel7Command As New SqlCommand(PriceLevel7Statement, con)
        PriceLevel7Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel7Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel8Statement As String = "SELECT B2500To4999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel8Command As New SqlCommand(PriceLevel8Statement, con)
        PriceLevel8Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel8Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel9Statement As String = "SELECT B5000To9999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel9Command As New SqlCommand(PriceLevel9Statement, con)
        PriceLevel9Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel9Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel10Statement As String = "SELECT B10000To24999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel10Command As New SqlCommand(PriceLevel10Statement, con)
        PriceLevel10Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel10Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel11Statement As String = "SELECT B25000To49999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel11Command As New SqlCommand(PriceLevel11Statement, con)
        PriceLevel11Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel11Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel12Statement As String = "SELECT B50000To99999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel12Command As New SqlCommand(PriceLevel12Statement, con)
        PriceLevel12Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel12Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        Dim PriceLevel13Statement As String = "SELECT B100000AndUp FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel13Command As New SqlCommand(PriceLevel13Statement, con)
        PriceLevel13Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel13Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            P1 = CDbl(PriceLevel1Command.ExecuteScalar)
        Catch ex As Exception
            P1 = 0
        End Try
        Try
            P2 = CDbl(PriceLevel2Command.ExecuteScalar)
        Catch ex As Exception
            P2 = 0
        End Try
        Try
            P3 = CDbl(PriceLevel3Command.ExecuteScalar)
        Catch ex As Exception
            P3 = 0
        End Try
        Try
            P4 = CDbl(PriceLevel4Command.ExecuteScalar)
        Catch ex As Exception
            P4 = 0
        End Try
        Try
            P5 = CDbl(PriceLevel5Command.ExecuteScalar)
        Catch ex As Exception
            P5 = 0
        End Try
        Try
            P6 = CDbl(PriceLevel6Command.ExecuteScalar)
        Catch ex As Exception
            P6 = 0
        End Try
        Try
            P7 = CDbl(PriceLevel7Command.ExecuteScalar)
        Catch ex As Exception
            P7 = 0
        End Try
        Try
            P8 = CDbl(PriceLevel8Command.ExecuteScalar)
        Catch ex As Exception
            P8 = 0
        End Try
        Try
            P9 = CDbl(PriceLevel9Command.ExecuteScalar)
        Catch ex As Exception
            P9 = 0
        End Try
        Try
            P10 = CDbl(PriceLevel10Command.ExecuteScalar)
        Catch ex As Exception
            P10 = 0
        End Try
        Try
            P11 = CDbl(PriceLevel11Command.ExecuteScalar)
        Catch ex As Exception
            P11 = 0
        End Try
        Try
            P12 = CDbl(PriceLevel12Command.ExecuteScalar)
        Catch ex As Exception
            P12 = 0
        End Try
        Try
            P13 = CDbl(PriceLevel13Command.ExecuteScalar)
        Catch ex As Exception
            P13 = 0
        End Try
        con.Close()

        txtPrice1.Text = P1
        txtPrice2.Text = P2
        txtPrice3.Text = P3
        txtPrice4.Text = P4
        txtPrice5.Text = P5
        txtPrice6.Text = P6
        txtPrice7.Text = P7
        txtPrice8.Text = P8
        txtPrice9.Text = P9
        txtPrice10.Text = P10
        txtPrice11.Text = P11
        txtPrice12.Text = P12
        txtPrice13.Text = P13
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub ClearData()
        txtPrice1.Clear()
        txtPrice2.Clear()
        txtPrice3.Clear()
        txtPrice4.Clear()
        txtPrice5.Clear()
        txtPrice6.Clear()
        txtPrice7.Clear()
        txtPrice8.Clear()
        txtPrice9.Clear()
        txtPrice10.Clear()
        txtPrice11.Clear()
        txtPrice12.Clear()
        txtPrice13.Clear()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        LoadPriceBrackets()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub txtPrice1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice1.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice1.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice2.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice2.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice3_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice3.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice3.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice4_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice4.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice4.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice5_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice5.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice5.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice6_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice6.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice6.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice7_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice7.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice7.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice8_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice8.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice8.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice9_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice9.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice9.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice10_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice10.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice10.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice11_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice11.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice11.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice12_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice12.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice12.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub txtPrice13_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice13.DoubleClick
        If GlobalPriceBracketSource = "Sales Order" Then
            GlobalSOPriceBracket = Val(txtPrice13.Text)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        'Update Item Price Sheets (TWE ONLY)
        If cboPartNumber.Text = "" Then
            Exit Sub
        End If

        Try
            cmd = New SqlCommand("UPDATE ItemPriceSheet SET B100To199 = @B100To199, B200To299 = @B200To299, B300To399 = @B300To399, B400To499 = @B400To499, B500To749 = @B500To749 WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@B100To199", SqlDbType.VarChar).Value = Val(txtPrice1.Text)
                .Add("@B200To299", SqlDbType.VarChar).Value = Val(txtPrice2.Text)
                .Add("@B300To399", SqlDbType.VarChar).Value = Val(txtPrice3.Text)
                .Add("@B400To499", SqlDbType.VarChar).Value = Val(txtPrice4.Text)
                .Add("@B500To749", SqlDbType.VarChar).Value = Val(txtPrice5.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Error Log
            MsgBox("Error saving data - try again.", MsgBoxStyle.OkOnly)
        End Try
    End Sub
End Class