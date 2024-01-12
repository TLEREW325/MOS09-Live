Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class SerialNumberInventory
    Inherits System.Windows.Forms.Form

    Dim AssemblyPartNumber As String = ""


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Private Sub SerialNumberInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()


    End Sub

    Public Sub LoadSerializedAssemblies()
        cmd = New SqlCommand("SELECT * FROM AssemblyHeaderTable WHERE DivisionID = @DivisionID AND SerializedStatus = @SerializedStatus ORDER BY AssemblyPartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SerializedStatus", SqlDbType.VarChar).Value = "YES"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblyHeaderTable")
        dgvAssemblyHeaderTable.DataSource = ds.Tables("AssemblyHeaderTable")
        con.Close()
    End Sub

    Public Sub LoadSerialLog()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "AssemblySerialLog")
        dgvSerialLog.DataSource = ds1.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRunReport.Click
        'Load Assembly Header Table
        LoadSerializedAssemblies()

        'Go thru and check whether part has open serial numbers or quantity on hand
        Dim RowPartNumber As String = ""
        Dim RowDescription As String = ""
        Dim CheckQOH As Double = 0
        Dim CheckSerialCount As Integer = 0
        Dim RowDivision As String = cboDivisionID.Text

        For Each LineRow As DataGridViewRow In dgvAssemblyHeaderTable.Rows
            Try
                RowPartNumber = LineRow.Cells("AssemblyPartNumberColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowDescription = LineRow.Cells("AssemblyDescriptionColumn").Value
            Catch ex As System.Exception
                RowDescription = ""
            End Try

            'Check QOH
            Dim CheckQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim CheckQOHCommand As New SqlCommand(CheckQOHStatement, con)
            CheckQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            CheckQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckQOH = CDbl(CheckQOHCommand.ExecuteScalar)
            Catch ex As Exception
                CheckQOH = 0
            End Try
            con.Close()

            'Check Serial Numbers
            Dim CheckSerialCountStatement As String = "SELECT COUNT(AssemblyPartNumber) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
            Dim CheckSerialCountCommand As New SqlCommand(CheckSerialCountStatement, con)
            CheckSerialCountCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
            CheckSerialCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            CheckSerialCountCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckSerialCount = CInt(CheckSerialCountCommand.ExecuteScalar)
            Catch ex As Exception
                CheckSerialCount = 0
            End Try
            con.Close()

            If CheckQOH + CheckSerialCount = 0 Then
                'Skip Part Number
            Else
                'Write to Serial Table (Datagrid) - Header Line
                Me.dgvSerializedParts.Rows.Add(RowDivision, RowPartNumber, RowDescription, CheckQOH)

                'Clear Serial Log before adding serial numbers
                Me.dgvSerialLog.DataSource = Nothing

                If CheckSerialCount > 0 Then
                    'Add serial numbers to datagrid
                    AssemblyPartNumber = RowPartNumber
                    LoadSerialLog()

                    Dim SubRowSerialNumber As String = ""
                    Dim SubRowTotalCost As Double = 0
                    Dim SubRowBuildNumber As Integer = 0

                    For Each SubLineRow As DataGridViewRow In dgvSerialLog.Rows
                        Try
                            SubRowSerialNumber = SubLineRow.Cells("SerialNumberColumnSL").Value
                        Catch ex As System.Exception
                            SubRowSerialNumber = ""
                        End Try
                        Try
                            SubRowTotalCost = SubLineRow.Cells("TotalCostColumnSL").Value
                        Catch ex As System.Exception
                            SubRowTotalCost = 0
                        End Try
                        Try
                            SubRowBuildNumber = SubLineRow.Cells("BuildNumberColumnSL").Value
                        Catch ex As System.Exception
                            SubRowBuildNumber = 0
                        End Try

                        'Add line to datagrid
                        Me.dgvSerializedParts.Rows.Add("", "Serial Number -- " + SubRowSerialNumber, "Total Cost -- " + CStr(SubRowTotalCost), "Build # -- " + CStr(SubRowBuildNumber))

                        'Clear Data
                        SubRowBuildNumber = 0
                        SubRowTotalCost = 0
                        SubRowSerialNumber = ""
                    Next

                    'Add blank line
                    Me.dgvSerializedParts.Rows.Add("", "", "", "")
                Else
                    'Skip
                End If

                'Clear data
                RowDescription = ""
                RowPartNumber = ""
                CheckSerialCount = 0
                CheckQOH = 0
            End If
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        Me.dgvAssemblyHeaderTable.DataSource = Nothing
        Me.dgvSerializedParts.DataSource = Nothing
        Me.dgvSerialLog.DataSource = Nothing

        Me.dgvSerializedParts.Rows.Clear()
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        If Me.dgvSerializedParts.RowCount > 0 Then
            Dim ExcelObject As New Excel.Application
            Dim NewWB As Excel.Workbook
            Dim LineDivision As String = ""
            Dim LinePartNumber As String = ""
            Dim LineDescription As String = ""
            Dim LineQOH As String = ""

            Dim ExcelFileName As String = ""


            'Create Excel Sheet with Headers
            NewWB = ExcelObject.Workbooks.Add()

            ExcelObject.Range("A1").Select()
            ExcelObject.ActiveCell.Value = "Division"
            ExcelObject.Range("B1").Select()
            ExcelObject.ActiveCell.Value = "Part #"
            ExcelObject.Range("C1").Select()
            ExcelObject.ActiveCell.Value = "Description"
            ExcelObject.Range("D1").Select()
            ExcelObject.ActiveCell.Value = "Quantity On Hand"
      
            'Format the table
            ExcelObject.Range("A1:D1").Font.Size = 12
            ExcelObject.Range("A1:D1").Font.Bold = True
            ExcelObject.Range("A1:D1").RowHeight = 20

            ExcelObject.Range("A1").ColumnWidth = 10
            ExcelObject.Range("B1").ColumnWidth = 25
            ExcelObject.Range("C1").ColumnWidth = 35
            ExcelObject.Range("D1").ColumnWidth = 25

            Dim RowCounter As Integer = 1
            Dim strRow As String = ""

            For Each LineRow As DataGridViewRow In dgvSerializedParts.Rows
                RowCounter = RowCounter + 1
                strRow = CStr(RowCounter)

                Try
                    LineDivision = LineRow.Cells("DivisionColumn").Value
                Catch ex As System.Exception
                    LineDivision = ""
                End Try
                Try
                    LinePartNumber = LineRow.Cells("PartNumberColumn").Value
                Catch ex As System.Exception
                    LinePartNumber = ""
                End Try
                Try
                    LineDescription = LineRow.Cells("DescriptionColumn").Value
                Catch ex As System.Exception
                    LineDescription = ""
                End Try
                Try
                    LineQOH = LineRow.Cells("QOHColumn").Value
                Catch ex As System.Exception
                    LineQOH = ""
                End Try
         
                'Add datagrid lines
                ExcelObject.Range("A" + strRow).Select()
                ExcelObject.ActiveCell.Value = LineDivision

                ExcelObject.Range("B" + strRow).Select()
                ExcelObject.ActiveCell.Value = LinePartNumber

                ExcelObject.Range("C" + strRow).Select()
                ExcelObject.ActiveCell.Value = LineDescription

                ExcelObject.Range("D" + strRow).Select()
                ExcelObject.ActiveCell.Value = LineQOH
            Next

            'Create new filename and save file
            Dim TodaysDate As Date = Now()
            Dim strDay, strMonth, strYear, strMinute As String
            Dim intDay, intMonth, intYear, intMinute As Integer

            intDay = TodaysDate.Day
            intMonth = TodaysDate.Month
            intYear = TodaysDate.Year
            intMinute = TodaysDate.Minute

            strDay = CStr(intDay)
            strMonth = CStr(intMonth)
            strYear = CStr(intYear)
            strMinute = CStr(intMinute)

            If intDay < 10 Then
                strDay = "0" + strDay
            Else
                'Do nothing
            End If
            If intMonth < 10 Then
                strMonth = "0" + strMonth
            Else
                'Do nothing
            End If

            Dim Filename As String = ""

            Filename = "SerialQOH" + strMonth + strDay + strYear + strMinute + ".xls"
            ExcelFileName = Filename

            NewWB.SaveAs("\\TFP-FS\TransferData\TruweldAudits\" + Filename)

            ExcelObject.Visible = True
        End If
    End Sub
End Class