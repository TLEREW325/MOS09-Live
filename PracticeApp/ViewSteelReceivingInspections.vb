Imports System.IO
Imports System.ComponentModel
Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ViewSteelReceivingInspections
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim isloaded = False
    Dim RMIDDT As Data.DataTable
    Private Const InspectionDir As String = "\\TFP-FS\TransferData\Steel Receiving Inspection"
    Private bgwkLocateFiles As BackgroundWorker
    Private bgfiles As List(Of String)

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadRawMaterials()
        LoadBOLNumbers()
        LoadHeatNumber()
        LoadSteelVendors()
        LoadCarbon()
        LoadSize()
        If con.State = ConnectionState.Open Then con.Close()

        isloaded = True
        bgwkLocateFiles = New BackgroundWorker()
        AddHandler bgwkLocateFiles.DoWork, AddressOf bgwkLocateFiles_DoWork
        AddHandler bgwkLocateFiles.RunWorkerCompleted, AddressOf bgwkLocateFiles_RunWorkerCompleted
    End Sub

    Private Sub LoadRawMaterials()
        Dim cmd As New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable", con)

        RMIDDT = New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(RMIDDT)
    End Sub

    Private Sub LoadCarbon()
        If cboCarbon.DisplayMember <> "Carbon" Then cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = RMIDDT.DefaultView().ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSize()
        If cboSteelSize.DisplayMember <> "SteelSize" Then cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = RMIDDT.DefaultView().ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadBOLNumbers()
        Dim cmd As New SqlCommand("SELECT DISTINCT(SteelBOLNumber) FROM SteelReceivingHeaderTable", con)
        Dim dt As New Data.DataTable("SteelReceivingHeaderTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        If cboBOLNumber.DisplayMember <> "SteelBOLNumber" Then cboBOLNumber.DisplayMember = "SteelBOLNumber"
        cboBOLNumber.DataSource = dt
        cboBOLNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelVendors()
        Dim cmd As New SqlCommand("SELECT VendorCode, VendorName FROM Vendor WHERE VendorClass = 'SteelVendor' AND DivisionID = 'TWD';", con)
        Dim dt As New Data.DataTable("SteelReceivingHeaderTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        If cboSteelVendor.DisplayMember <> "VendorCode" Then cboSteelVendor.DisplayMember = "VendorCode"
        cboSteelVendor.DataSource = dt
        If cboSteelVendorName.DisplayMember <> "VendorName" Then cboSteelVendorName.DisplayMember = "VendorName"
        cboSteelVendorName.DataSource = dt
        cboSteelVendor.SelectedIndex = -1
        cboSteelVendorName.SelectedIndex = -1
    End Sub

    Private Sub LoadHeatNumber()
        Dim cmd As New SqlCommand("SELECT DISTINCT(HeatNumber) FROM HeatNumberLog;", con)
        Dim dt As New Data.DataTable("HeatNumberLog")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        If cboHeatNumber.DisplayMember <> "HeatNumber" Then cboHeatNumber.DisplayMember = "HeatNumber"
        cboHeatNumber.DataSource = dt
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Private Sub cboSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Leave
        If Not String.IsNullOrEmpty(cboSteelSize.Text) AndAlso cboSteelSize.SelectedIndex = -1 Then
            Try
                cboSteelSize.Text = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Catch ex As System.Exception

            End Try
        End If
        If String.IsNullOrEmpty(cboCarbon.Text) AndAlso Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            isloaded = False
            Dim searchOne As String = cboSteelSize.Text
            Dim searchTwo As String = ""
            If cboSteelSize.Text.Contains("/") Then
                searchTwo = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                searchTwo = usefulFunctions.GetFractional(cboSteelSize.Text)
            End If
            Dim tmpDT As Data.DataTable = RMIDDT.Select("SteelSize = '" + searchOne + "' OR SteelSize = '" + searchTwo + "'", "Carbon ASC").CopyToDataTable()
            If tmpDT.Rows.Count > 0 Then
                cboCarbon.DataSource = tmpDT.DefaultView().ToTable(True, "Carbon")
            Else
                cboCarbon.DataSource = RMIDDT.DefaultView().ToTable(True, "Carbon")
            End If
            cboCarbon.SelectedIndex = -1
            isloaded = True
        ElseIf String.IsNullOrEmpty(cboSteelSize.Text) Then
            isloaded = False
            Dim tmp As String = cboCarbon.Text
            cboCarbon.DataSource = RMIDDT.DefaultView().ToTable(True, "Carbon")
            If Not String.IsNullOrEmpty(tmp) Then
                cboCarbon.Text = tmp
            Else
                cboCarbon.SelectedIndex = -1
            End If

            isloaded = True
        End If
    End Sub

    Private Sub cboCarbon_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.Leave
        If String.IsNullOrEmpty(cboSteelSize.Text) AndAlso Not String.IsNullOrEmpty(cboCarbon.Text) Then
            isloaded = False
            Dim tmpdt As Data.DataTable = RMIDDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
            If tmpdt.Rows.Count > 0 Then
                cboSteelSize.DataSource = tmpdt.DefaultView().ToTable(True, "SteelSize")
            Else
                cboSteelSize.DataSource = RMIDDT.DefaultView().ToTable(True, "SteelSize")
            End If
            cboSteelSize.SelectedIndex = -1
            isloaded = True
        ElseIf String.IsNullOrEmpty(cboCarbon.Text) Then
            isloaded = False
            Dim tmp As String = cboSteelSize.Text
            cboSteelSize.DataSource = RMIDDT.DefaultView().ToTable(True, "SteelSize")
            If Not String.IsNullOrEmpty(tmp) Then
                cboSteelSize.Text = tmp
            Else
                cboSteelSize.SelectedIndex = -1
            End If
            isloaded = True
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        isloaded = False
        LoadCarbon()
        LoadSize()
        cboSteelVendor.SelectedIndex = -1
        cboSteelVendorName.SelectedIndex = -1
        cboBOLNumber.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then cboSteelVendor.Text = ""
        If Not String.IsNullOrEmpty(cboSteelVendorName.Text) Then cboSteelVendorName.Text = ""
        If Not String.IsNullOrEmpty(cboBOLNumber.Text) Then cboBOLNumber.Text = ""
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then cboHeatNumber.Text = ""
        chkUseDateRange.Checked = False
        dtpStartDate.Value = DateTime.Now
        dtpEndDate.Value = DateTime.Now
        dgvFoundFiles.Rows.Clear()
        bsrInspection.Navigate("about:blank")
        cboCarbon.Focus()
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        dgvFoundFiles.Rows.Clear()
        bsrInspection.Navigate("about:blank")
        Dim cmd As New SqlCommand("SELECT HeatFileNumber, DateReceived FROM HeatNumberLog", con)
        Dim isFirst As Boolean = True
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE SteelType  = @Carbon"
            Else
                cmd.CommandText += " AND SteelType  = @Carbon"
            End If
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        End If

        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
            Else
                cmd.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
            End If
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
            If cboSteelSize.Text.Contains("/") Then
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.GetFractional(cboSteelSize.Text)
            End If
        End If

        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE HeatNumber = @HeatNumber"
            Else
                cmd.CommandText += " AND HeatNumber = @HeatNumber"
            End If
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        End If

        If Not String.IsNullOrEmpty(cboBOLNumber.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE BOLNumber = @BOLNumber"
            Else
                cmd.CommandText += " AND BOLNumber = @BOLNumber"
            End If
            cmd.Parameters.Add("@BOLNumber", SqlDbType.VarChar).Value = cboBOLNumber.Text
        End If

        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE VendorID = @VendorID"
            Else
                cmd.CommandText += " AND VendorID = @VendorID"
            End If
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboSteelVendor.Text
        End If

        If chkUseDateRange.Checked Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE DateReceived BETWEEN @StartDate AND @EndDate"
            Else
                cmd.CommandText += " AND DateReceived BETWEEN @StartDate AND @EndDate"
            End If
            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dtpStartDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        cmd.CommandText += " ORDER BY DateReceived ASC"

        Dim dt As New Data.DataTable("tbl")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        If dt.Rows.Count > 1 Then
            pnlLoading.Show()
            bgwkLocateFiles.RunWorkerAsync(dt)
        ElseIf dt.Rows.Count = 1 Then
            Dim files As String()
            files = Directory.GetFiles(InspectionDir, dt.Rows(0).Item("HeatFileNumber").ToString + "*.pdf")
            If files.Length > 1 Then
                For Each fle As String In files
                    dgvFoundFiles.Rows.Add(fle.Substring(fle.LastIndexOf("/")))
                    dgvFoundFiles.Rows(dgvFoundFiles.Rows.Count - 1).Cells(0).Tag = fle
                Next
            ElseIf files.Length = 1 Then
                dgvFoundFiles.Rows.Add(files(0).Substring(files(0).LastIndexOf("/")))
                dgvFoundFiles.Rows(dgvFoundFiles.Rows.Count - 1).Cells(0).Tag = files(0)
                bsrInspection.Navigate(files(0))
            Else
                dgvFoundFiles.Rows.Clear()
            End If
        Else
            MessageBox.Show("No inspections were found.", "No inspections", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub bgwkLocateFiles_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim dt As Data.DataTable = CType(e.Argument, Data.DataTable)
        bgfiles = New List(Of String)
        Dim workers As New List(Of BackgroundWorker)
        For Each rw As Data.DataRow In dt.Rows
            Dim bgwk As New BackgroundWorker()
            AddHandler bgwk.DoWork, AddressOf bgwkFindFiles_DoWork
            AddHandler bgwk.RunWorkerCompleted, AddressOf bgwkFindFiles_RunWorkerCompleted
            bgwk.RunWorkerAsync(rw)
            workers.Add(bgwk)
        Next
        Dim completed As Boolean = False
        ''Loop to find out if all the workers have completed their tasks
        While Not completed
            completed = True
            Dim i As Integer = 0
            ''Checks all the workers to see if they have completed their tasks
            While completed AndAlso i < workers.Count
                If workers(i).IsBusy Then
                    completed = False
                Else
                    i += 1
                End If
            End While
        End While
    End Sub

    Private Sub bgwkLocateFiles_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        pnlLoading.Hide()
        isloaded = False
        bgfiles.Sort()
        For Each fle As String In bgfiles
            If fle IsNot Nothing AndAlso fle.Contains("\") Then
                Dim firstPos As Integer = fle.LastIndexOf("\") + 1
                Dim secondPos As Integer = fle.LastIndexOf(".")
                dgvFoundFiles.Rows.Add(fle.Substring(firstPos, secondPos - firstPos))
                dgvFoundFiles.Rows(dgvFoundFiles.Rows.Count - 1).Tag = fle
            End If
        Next
        isloaded = True
        If bgfiles.Count = 0 Then
            MessageBox.Show("No inspections were found.", "No inspections", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ''' <summary>
    ''' Finds the files for the given Heat file number
    ''' </summary>
    ''' <param name="sender">the object that sent the request</param>
    ''' <param name="e">A DataRow with the heat file number in it</param>
    ''' <remarks></remarks>
    Private Sub bgwkFindFiles_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim rw As Data.DataRow = CType(e.Argument, Data.DataRow)
        e.Result = Directory.GetFiles(InspectionDir, rw.Item("HeatFileNumber").ToString + "*.pdf")
    End Sub

    Private Sub bgwkFindFiles_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If e.Result IsNot Nothing Then
            Dim fls As String() = CType(e.Result, String())
            If fls.Length > 1 Then
                bgfiles.AddRange(fls)
            ElseIf fls.Length = 1 Then
                bgfiles.Add(fls(0))
            End If
        End If
    End Sub

    Private Sub pnlLoading_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlLoading.VisibleChanged
        If pnlLoading.Visible Then
            lblLoadingText.Text = "Locating entries, please wait."
            tmrChangeText.Start()
        Else
            tmrChangeText.Stop()
        End If
    End Sub

    Private Sub tmrChangeText_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrChangeText.Tick
        Select Case lblLoadingText.Text
            Case "Locating entries, please wait."
                lblLoadingText.Text = "Locating entries, please wait.."
            Case "Locating entries, please wait.."
                lblLoadingText.Text = "Locating entries, please wait..."
            Case "Locating entries, please wait..."
                lblLoadingText.Text = "Locating entries, please wait."
        End Select
    End Sub

    Private Sub dgvFoundFiles_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFoundFiles.SelectionChanged
        If isloaded AndAlso dgvFoundFiles.SelectedCells.Count > 0 AndAlso dgvFoundFiles.SelectedCells(0).RowIndex > -1 Then
            bsrInspection.Navigate(dgvFoundFiles.Rows(dgvFoundFiles.SelectedCells(0).RowIndex).Tag.ToString)
        End If
    End Sub

    Private Sub ViewSteelReceivingInspections_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        bsrInspection.Print()
    End Sub
End Class