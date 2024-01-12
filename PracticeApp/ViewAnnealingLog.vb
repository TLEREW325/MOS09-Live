Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ViewAnnealingLog
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim dt, SteelDT As New Data.DataTable
    Dim isLoaded As Boolean = False

    Public Sub New()
        InitializeComponent()
        LoadHeatNumber()
        LoadAnnealingLotNumber()
        LoadSteel()
        LoadPrograms()
        LoadBase()

        usefulFunctions.LoadSecurity(Me)
        AcceptButton = cmdView
        isLoaded = True
    End Sub

    Private Sub LoadAnnealingLotNumber()
        Dim cmd As New SqlCommand("SELECT AnnealLotNumber FROM AnnealingLog;", con)
        Dim dsAnnealLot As New DataSet()
        Dim adtAnnealLot As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adtAnnealLot.Fill(dsAnnealLot, "AnnealingLog")
        con.Close()

        cboAnnealedLot.DisplayMember = "AnnealLotNumber"
        cboAnnealedLot.DataSource = dsAnnealLot.Tables("AnnealingLog")
        cboAnnealedLot.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        Dim cmd As New SqlCommand("SELECT HeatNumber FROM AnnealingLog;", con)
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "AnnealingLog")
        con.Close()

        cboHeatNumber.DisplayMember = "HeatNumber"
        cboHeatNumber.DataSource = ds.Tables("AnnealingLog")
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadPrograms()
        Dim cmd As New SqlCommand("SELECT DISTINCT(Program) FROM AnnealingLog;", con)
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "AnnealingLog")
        con.Close()

        cboProgram.DisplayMember = "Program"
        cboProgram.DataSource = ds.Tables("AnnealingLog")
        cboProgram.SelectedIndex = -1
    End Sub

    Private Sub LoadBase()
        Dim cmd As New SqlCommand("SELECT DISTINCT(Base) FROM AnnealingLog;", con)
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "AnnealingLog")
        con.Close()

        cboBase.DisplayMember = "Base"
        cboBase.DataSource = ds.Tables("AnnealingLog")
        cboBase.SelectedIndex = -1
    End Sub

    Private Sub LoadSteel()
        Dim cmd As New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable;", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(SteelDT)
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim isfirst As Boolean = True
        Dim cmd As New SqlCommand("SELECT * FROM AnnealingLog", con)

        If String.IsNullOrEmpty(cboAnnealedLot.Text) = False Then
            If isfirst Then
                cmd.CommandText += " WHERE AnnealLotNumber = @AnnealLotNumber "
                isfirst = False
            Else
                cmd.CommandText += "AND AnnealLotNumber = @AnnealLotNumber "
            End If
            cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealedLot.Text
        End If
        If String.IsNullOrEmpty(cboCarbon.Text) = False Then
            If isfirst Then
                cmd.CommandText += " WHERE AnnealedCarbon = @AnnealedCarbon "
                isfirst = False
            Else
                cmd.CommandText += "AND AnnealedCarbon = @AnnealedCarbon "
            End If
            cmd.Parameters.Add("@AnnealedCarbon", SqlDbType.VarChar).Value = cboCarbon.Text
        End If
        If String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            If isfirst Then
                cmd.CommandText += " WHERE AnnealedSteelSize = @AnnealedSteelSize "
                isfirst = False
            Else
                cmd.CommandText += "AND AnnealedSteelSize = @AnnealedSteelSize "
            End If
            If cboSteelSize.Text.Contains("/") Then
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
            End If
            cmd.Parameters.Add("@AnnealedSteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        End If
        If String.IsNullOrEmpty(cboHeatNumber.Text) = False Then
            If isfirst Then
                cmd.CommandText += " WHERE HeatNumber = @HeatNumber "
                isfirst = False
            Else
                cmd.CommandText += "AND HeatNumber = @HeatNumber "
            End If
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        End If
        If String.IsNullOrEmpty(cboProgram.Text) = False Then
            If isfirst Then
                cmd.CommandText += " WHERE Program = @Program "
                isfirst = False
            Else
                cmd.CommandText += "AND Program = @Program "
            End If
            cmd.Parameters.Add("@Program", SqlDbType.VarChar).Value = cboProgram.Text
        End If
        If String.IsNullOrEmpty(cboBase.Text) = False Then
            If isfirst Then
                cmd.CommandText += " WHERE Base = @Base "
                isfirst = False
            Else
                cmd.CommandText += "AND Base = @Base "
            End If
            cmd.Parameters.Add("@Base", SqlDbType.VarChar).Value = cboBase.Text
        End If
        cmd.CommandText += ";"

        dt = New Data.DataTable("AnnealingLog")
        Dim myADapter As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        con.Close()

        dt.Columns("AnnealLotNumber").SetOrdinal(0)
        dt.Columns("AnnealedCarbon").SetOrdinal(1)
        dt.Columns("AnnealedSteelSize").SetOrdinal(2)
        dgvAnnealingLog.DataSource = dt
        dgvSetup()
    End Sub

    Private Sub dgvSetup()
        dgvAnnealingLog.Columns("RMID").Visible = False
        dgvAnnealingLog.Columns("AnnealedRMID").Visible = False
        dgvAnnealingLog.Columns("DivisionID").Visible = False
        dgvAnnealingLog.Columns("Status").Visible = False

        dgvAnnealingLog.Columns("AnnealLotNumber").HeaderText = "Anneal Lot #"
        dgvAnnealingLog.Columns("AnnealedCarbon").HeaderText = "Annealed Carbon"
        dgvAnnealingLog.Columns("AnnealedSteelSize").HeaderText = "Annealed Steel Size"
        dgvAnnealingLog.Columns("HeatNumber").HeaderText = "Heat Number"
        dgvAnnealingLog.Columns("TotalPoundsAnnealed").HeaderText = "Total Pounds Annealed"
        dgvAnnealingLog.Columns("NumberOfCoils").HeaderText = "Number of Coils"
        dgvAnnealingLog.Columns("DateIn").HeaderText = "Date In"
        dgvAnnealingLog.Columns("DateOut").HeaderText = "Date Out"
        dgvAnnealingLog.Columns("SurfaceHardness").HeaderText = "Surface Hardness"
        dgvAnnealingLog.Columns("CoreHardness").HeaderText = "Core Hardness"
        dgvAnnealingLog.Columns("FreeFerrite").HeaderText = "Free Ferrite"
        dgvAnnealingLog.Columns("TotalDecarb").HeaderText = "Total Decarb"
        dgvAnnealingLog.Columns("SpheroidPercent").HeaderText = "Spheroid Percent"
        dgvAnnealingLog.Columns("PreviousAnnealLotNumber").HeaderText = "Previous Annealing Lot"
        dgvAnnealingLog.Columns("SpheroSampleMicro").HeaderText = "Sphero Sample Micro"
        dgvAnnealingLog.Columns("SpheroSampleBox").HeaderText = "Sphero Sample Box"
        dgvAnnealingLog.Columns("DecarbSampleMicro").HeaderText = "Decarb Sample Micro"
        dgvAnnealingLog.Columns("DecarbSampleBox").HeaderText = "Decarb Sample Box"
        dgvAnnealingLog.Columns("RawMaterialTensile").HeaderText = "Raw Material Tensile"

        ColorDGV()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim NewPrintAnnealingLog As New PrintAnnealingLogFiltered(dt)
        NewPrintAnnealingLog.ShowDialog()

    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isLoaded = False
        cboAnnealedLot.SelectedIndex = -1
        If String.IsNullOrEmpty(cboAnnealedLot.Text) Then
            cboAnnealedLot.Text = ""
        End If
        cboHeatNumber.SelectedIndex = -1
        If String.IsNullOrEmpty(cboHeatNumber.Text) = False Then
            cboHeatNumber.Text = ""
        End If
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1
        If String.IsNullOrEmpty(cboCarbon.Text) = False Then
            cboCarbon.Text = ""
        End If
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        If String.IsNullOrEmpty(cboSteelSize.Text) = False Then
            cboSteelSize.Text = ""
        End If
        cboProgram.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboProgram.Text) Then
            cboProgram.Text = ""
        End If
        cboBase.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBase.Text) Then
            cboBase.Text = ""
        End If
        dgvAnnealingLog.DataSource = Nothing
        isLoaded = True
    End Sub
    Private Sub dgvAnnealingLog_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAnnealingLog.CellMouseDoubleClick
        If dgvAnnealingLog.Rows.Count > 0 Then
            If dgvAnnealingLog.CurrentCell.RowIndex >= 0 Then
                Dim newAnnealingLogMaintenance As New AnnealingLogForm(dgvAnnealingLog.Rows(dgvAnnealingLog.CurrentCell.RowIndex).Cells("AnnealLotNumber").Value)
                newAnnealingLogMaintenance.Show()
                newAnnealingLogMaintenance.Parent = Me.Parent
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub dgvAnnealingLog_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAnnealingLog.VisibleChanged
        ColorDGV()
    End Sub

    Private Sub cboAnnealedSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If cboSteelSize.Text.StartsWith(".") Then
            cboSteelSize.Text = "0."
            cboSteelSize.Select(cboSteelSize.Text.Length, 0)
        End If
    End Sub

    Private Sub dgvAnnealingLog_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAnnealingLog.Sorted
        ColorDGV()
    End Sub

    Private Sub ColorDGV()
        For i As Integer = 0 To dgvAnnealingLog.Rows.Count - 1
            If Not IsDBNull(dgvAnnealingLog.Rows(i).Cells("MaterialStatus").Value) Then
                Select Case dgvAnnealingLog.Rows(i).Cells("MaterialStatus").Value
                    Case "Ok To Process"
                        dgvAnnealingLog.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    Case "Ok - See Comment"
                        dgvAnnealingLog.Rows(i).DefaultCellStyle.BackColor = Color.DeepSkyBlue
                    Case "Hold - See Comment"
                        dgvAnnealingLog.Rows(i).DefaultCellStyle.BackColor = Color.Goldenrod
                    Case "Do Not Use - See Comment"
                        dgvAnnealingLog.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
                End Select
            End If
        Next
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                If cboSteelSize.Text.Contains("/") Then
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                Else
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                End If
                cboCarbon.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
                cboCarbon.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Leave
        If Not String.IsNullOrEmpty(cboSteelSize.Text) AndAlso cboSteelSize.SelectedIndex = -1 Then
            If cboSteelSize.Text.Contains("/") Then
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                End If
            Else
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.GetFractional(cboSteelSize.Text)
                End If
            End If
        End If
    End Sub

    Private Sub chkShowAllTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTypes.CheckedChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub
End Class