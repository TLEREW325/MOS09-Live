Imports System
Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class PrintQCFinalPieceSignOffs
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("Select Distinct LotNumber from LotNumber", con)

        Dim ds As New DataSet()
        Dim adap As New SqlDataAdapter

        If con.State = ConnectionState.Closed Then con.Open()

        adap.SelectCommand = cmd
        adap.Fill(ds, "LotNumber")
        cboLotNumber.DisplayMember = "LotNumber"
        cboLotNumber.DataSource = ds.Tables("LotNumber")
        con.Close()
        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("Select Distinct PartNumber from LotNumber", con)

        Dim ds As New DataSet
        Dim adap As New SqlDataAdapter
        If con.State = ConnectionState.Closed Then con.Open()

        adap.SelectCommand = cmd
        adap.Fill(ds, "LotNumber")
        cboPartNumber.DisplayMember = "PartNumber"
        cboPartNumber.DataSource = ds.Tables("LotNumber")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadFoxNumber()
        cmd = New SqlCommand("Select Distinct FoxNumber from LotNumber", con)

        Dim ds As New DataSet
        Dim adap As New SqlDataAdapter
        If con.State = ConnectionState.Closed Then con.Open()

        adap.SelectCommand = cmd
        adap.Fill(ds, "LotNumber")
        cboFox.DisplayMember = "FoxNumber"
        cboFox.DataSource = ds.Tables("LotNumber")
        con.Close()
        cboFox.SelectedIndex = -1
    End Sub

    Public Sub LoadQCInspector()
        cmd = New SqlCommand("Select Distinct QCInspector from LotNumber WHERE QCInspected = 'YES'", con)

        Dim ds As New DataSet()
        Dim adap As New SqlDataAdapter
        If con.State = ConnectionState.Closed Then con.Open()

        adap.SelectCommand = cmd
        adap.Fill(ds, "LotNumber")
        cboInspector.DisplayMember = "QCInspector"
        cboInspector.DataSource = ds.Tables("LotNumber")
        con.Close()
        cboInspector.SelectedIndex = -1
    End Sub

    Private Sub QCInspected_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFoxNumber()
        LoadLotNumber()
        LoadPartNumber()
        LoadQCInspector()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        cmd = New SqlCommand("Select * from LotNumber where QCInspected <> '' ", con)

        If Not String.IsNullOrEmpty(cboFox.Text) Then
            cmd.CommandText += " and FoxNumber = @FoxNumber"
            cmd.Parameters.Add("@FoxNumber", SqlDbType.VarChar).Value = cboFox.Text
        End If
        If Not String.IsNullOrEmpty(cboInspected.Text) Then
            cmd.CommandText += " and QCInspected = @QCInspected"
            cmd.Parameters.Add("@QCInspected", SqlDbType.VarChar).Value = cboInspected.Text
        End If
        If Not String.IsNullOrEmpty(cboInspector.Text) Then
            cmd.CommandText += " and QCInspector = @QCInspector"
            cmd.Parameters.Add("@QCInspector", SqlDbType.VarChar).Value = cboInspector.Text
        End If
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cmd.CommandText += " and LotNumber = @LotNumber"
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cmd.CommandText += " and PartNumber = @PartNumber"
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If

        cmd.CommandText += " ORDER BY CreationDate"

        Dim ds As New DataSet()
        Dim adap As New SqlDataAdapter

        If con.State = ConnectionState.Closed Then con.Open()

        adap.SelectCommand = cmd
        adap.Fill(ds, "LotNumber")

        Dim MyReport = New CRXQCInspectedReport
        MyReport.SetDataSource(ds)
        CRXQCInspectedViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboFox.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboInspected.SelectedIndex = -1
        cboInspector.SelectedIndex = -1
        CRXQCInspectedViewer.ReportSource = Nothing

        If Not String.IsNullOrEmpty(cboFox.Text) Then
            cboFox.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboInspected.Text) Then
            cboInspected.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboInspector.Text) Then
            cboInspector.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cboLotNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class