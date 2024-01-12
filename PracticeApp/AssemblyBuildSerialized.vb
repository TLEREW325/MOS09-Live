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
Public Class AssemblyBuildSerialized
    Inherits System.Windows.Forms.Form

    Dim LastBatchNumber, NextBatchNumber As Integer
    Dim PartSearchPrefix As String = ""
    Dim PartType As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim ModalBuildNumber, ModalLineNumber As Integer

    Dim GetPPL, GLIssuesAccount, CurrentPartNumber, PreferredVendor, VendorClass, PartDescription, GLInventoryAccount, GetItemClass, AssemblyDescription, ComponentLineComment, ComponentPartNumber, ComponentPartDescription, LongDescription, AssemblyDate, AssemblyComment, SerializedStatus, AssemblySerialNumber As String
    Dim TotalAssemblyCost, StandardCost, ComponentCost, UnitBuildCost, TransactionCost, AssemblyStandardCost, ComponentUnitCost, ComponentExtendedCost, SumComponentCost As Double
    Dim NextCostingTransactionNumber, LastCostingTransactionNumber, NextBuildNumber, LastBuildNumber, NextComponentLineNumber, LastComponentLineNumber, CheckSerialNumber As Integer
    Dim LastTransactionNumber, NextTransactionNumber, QuantityMultiplier As Integer
    Dim ComponentQuantity, UpperLimit, LowerLimit, NewUpperLimit As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isLoaded = False

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

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
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
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
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
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

    Private Sub AssemblyBuildSerialized_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        'Set default for division and enable beginning inventory edits
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        pnlAssemblyLines.Visible = True
        pnlSerialLog.Visible = False
    End Sub

    Public Sub LoadFormatting()
        'Get QOH for components and format datagrid
        If dgvAssemblyLineTable.RowCount > 0 Then
            'For each Line, get QOH and load in the datagrid
            Dim ComponentLineNumber As Integer = 0
            Dim ComponentPartNumber As String = ""
            Dim ComponentQuantity As Double = 0
            Dim ComponentQOH As Double = 0
            Dim RowIndex As Integer = 0

            For Each row As DataGridViewRow In dgvAssemblyLineTable.Rows
                Try
                    ComponentPartNumber = row.Cells("ComponentPartNumberColumn").Value
                Catch ex As Exception
                    ComponentPartNumber = ""
                End Try
                Try
                    ComponentLineNumber = row.Cells("ComponentPartDescriptionColumn").Value
                Catch ex As Exception
                    ComponentLineNumber = 0
                End Try
                Try
                    ComponentQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    ComponentQuantity = 0
                End Try


                If ComponentPartNumber = "UNITSUPPLIES" Or ComponentPartNumber = "ASSEMBLYLABOR" Or ComponentPartNumber = "TFPLABOR" Or ComponentPartNumber = "LABOR" Or ComponentPartNumber = "TFPLATHE" Or ComponentPartNumber = "TFPMILL" Or ComponentPartNumber = "TFPGRIND" Or ComponentPartNumber = "TFPSAW" Or ComponentPartNumber = "TFPHEATTREAT" Then
                    ComponentQOH = 0
                Else
                    'Get QOH
                    Dim QOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim QOHCommand As New SqlCommand(QOHStatement, con)
                    QOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                    QOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ComponentQOH = CDbl(QOHCommand.ExecuteScalar)
                        ComponentQOH = Math.Round(ComponentQOH, 0)
                    Catch ex As Exception
                        ComponentQOH = 0
                    End Try
                    con.Close()
                End If

                'Load QOH in datagrid
                Me.dgvAssemblyLineTable.Rows(RowIndex).Cells("QOHColumn").Value = ComponentQOH
                Me.dgvAssemblyLineTable.Columns("QOHColumn").DefaultCellStyle.ForeColor = Color.Blue

                ComponentQuantity = 0
                ComponentPartNumber = ""
                ComponentLineNumber = 0
                ComponentQOH = 0
                RowIndex = RowIndex + 1
            Next
        End If
    End Sub

    Public Sub LoadQOHFormatting()
        'Get QOH for components and format datagrid
        Dim QuantityMultiplier As Integer
        Dim NonInventoryPart As String = ""
        QuantityMultiplier = Val(txtBuildQuantity.Text)

        If dgvAssemblyLineTable.RowCount > 0 Then
            'For each Line, get QOH and load in the datagrid
            Dim ComponentLineNumber As Integer = 0
            Dim ComponentPartNumber As String = ""
            Dim ComponentQuantity As Double = 0
            Dim ComponentQOH As Double = 0
            Dim RowIndex As Integer = 0
            Dim Counter As Integer = 0

            For Each row As DataGridViewRow In dgvAssemblyLineTable.Rows
                Try
                    ComponentPartNumber = row.Cells("ComponentPartNumberColumn").Value
                Catch ex As Exception
                    ComponentPartNumber = ""
                End Try
                Try
                    ComponentLineNumber = row.Cells("ComponentPartDescriptionColumn").Value
                Catch ex As Exception
                    ComponentLineNumber = 0
                End Try
                Try
                    ComponentQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    ComponentQuantity = 0
                End Try
                Try
                    ComponentQOH = row.Cells("QOHColumn").Value
                Catch ex As Exception
                    ComponentQOH = 0
                End Try

                Select Case ComponentPartNumber
                    Case "UNITSUPPLIES", "ASSEMBLYLABOR", "LABOR", "TFPLABOR", "TFPLATHE", "TFPGRIND", "TFPMILL", "TFPSAW", "TFPHEATTREAT"
                        NonInventoryPart = "YES"
                    Case Else
                        NonInventoryPart = "NO"
                End Select

                If (ComponentQuantity * QuantityMultiplier <= ComponentQOH) Or NonInventoryPart = "YES" Then
                    Me.dgvAssemblyLineTable.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                    'Counter = 0
                Else
                    Me.dgvAssemblyLineTable.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                    Counter = Counter + 1
                End If

                ComponentQuantity = 0
                ComponentPartNumber = ""
                ComponentLineNumber = 0
                ComponentQOH = 0
                RowIndex = RowIndex + 1
            Next

            If Counter = 0 Then
                'Do nothing
            Else
                MsgBox("Line items shaded gray have insufficient quantities for this # of builds.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub ShowData()
        cboDeletePartNumber.Text = ""
        cboDeletePartDescription.Text = ""

        cmd = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblyLineTable")
        dgvAssemblyLineTable.DataSource = ds.Tables("AssemblyLineTable")
        cboDeletePartNumber.DataSource = ds.Tables("AssemblyLineTable")
        cboDeletePartDescription.DataSource = ds.Tables("AssemblyLineTable")
        con.Close()

        LoadFormatting()
    End Sub

    Public Sub ClearDataInDatagrid()
        cboDeletePartNumber.Text = ""
        cboDeletePartDescription.Text = ""

        dgvAssemblyLineTable.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboAssemblyPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboAssemblyPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboAssemblyPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboAssemblyPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadComponentPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboComponentPart.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboComponentPart.SelectedIndex = -1
    End Sub

    Public Sub LoadComponentPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboComponentDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboComponentDescription.SelectedIndex = -1
    End Sub

    Public Sub ShowSerialLogAvailable()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "AssemblySerialLog")
        dgvTempSerialLog.DataSource = ds5.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Public Sub ShowSerialLogAvailableLikeFilter()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND Status = @Status AND AssemblyPartNumber LIKE @AssemblyPartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartSearchPrefix
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "AssemblySerialLog")
        dgvTempSerialLog.DataSource = ds5.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Public Sub ShowSerialLogOpen()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "AssemblySerialLog")
        dgvTempSerialLog.DataSource = ds5.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Public Sub ClearSerialLog()
        dgvTempSerialLog.DataSource = Nothing
    End Sub

    Public Sub LoadLongDescription()
        Dim LongDescription As String = ""

        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        con.Close()

        txtAssemblyDescription.Text = LongDescription
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboAssemblyPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPartNumber()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboAssemblyPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadComponentPartNumberByDescription()
        Dim ComponentPartNumber1 As String = ""

        Dim ComponentPartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim ComponentPartNumber1Command As New SqlCommand(ComponentPartNumber1Statement, con)
        ComponentPartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboComponentDescription.Text
        ComponentPartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentPartNumber1 = CStr(ComponentPartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            ComponentPartNumber1 = ""
        End Try
        con.Close()

        cboComponentPart.Text = ComponentPartNumber1
    End Sub

    Public Sub LoadComponentDescriptionByPartNumber()
        Dim ComponentPartDescription1 As String = ""

        Dim ComponentPartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ComponentPartDescription1Command As New SqlCommand(ComponentPartDescription1Statement, con)
        ComponentPartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboComponentPart.Text
        ComponentPartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentPartDescription1 = CStr(ComponentPartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            ComponentPartDescription1 = ""
        End Try
        con.Close()

        cboComponentDescription.Text = ComponentPartDescription1
    End Sub

    Public Sub LoadTotalAssemblyCost()
        Dim TotalAssemblyCostStatement As String = "SELECT SUM(ExtendedCost) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim TotalAssemblyCostCommand As New SqlCommand(TotalAssemblyCostStatement, con)
        TotalAssemblyCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        TotalAssemblyCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalAssemblyCost = CDbl(TotalAssemblyCostCommand.ExecuteScalar)
        Catch ex As Exception
            TotalAssemblyCost = 0
        End Try
        con.Close()

        txtAssemblyCost.Text = TotalAssemblyCost
    End Sub

    Public Sub LoadAssemblyQOH()
        Dim AssemblyQOH As Double = 0

        Dim AssemblyQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim AssemblyQOHCommand As New SqlCommand(AssemblyQOHStatement, con)
        AssemblyQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        AssemblyQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AssemblyQOH = CDbl(AssemblyQOHCommand.ExecuteScalar)
        Catch ex As Exception
            AssemblyQOH = 0
        End Try
        con.Close()

        txtQOH.Text = AssemblyQOH
    End Sub

    Public Sub LoadComponentCost()
        Dim TotalQuantityShipped As Double = 0
        Dim GetMaxTransactionNumber As Integer = 0
        Dim ComponentCost As Double = 0

        'Get TQS for part
        Dim TotalQuantityShippedString As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND Dropship = @Dropship"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedString, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "NO"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalQuantityShipped = 0
        End Try
        con.Close()
        '******************************************************************************************************************************************
        'Add Total Quantity used in assemblies
        Dim GetBuildQuantity As Double = 0

        Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
        Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
        TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetBuildQuantity = 0
        End Try
        con.Close()

        GetBuildQuantity = GetBuildQuantity * -1

        TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity + 1
        '******************************************************************************************************************************************

        'Get Max Transaction Number for the Correct Cost Tier
        Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
        Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
        GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
        GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = Today()

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetMaxTransactionNumber = 0
        End Try
        con.Close()

        'Get FIFO Cost for the next piece sold
        Dim NextPieceSoldStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND PartNumber = @PartNumber"
        Dim NextPieceSoldCommand As New SqlCommand(NextPieceSoldStatement, con)
        NextPieceSoldCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboComponentPart.Text
        NextPieceSoldCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        NextPieceSoldCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ComponentCost = CDbl(NextPieceSoldCommand.ExecuteScalar)
        Catch ex As System.Exception
            ComponentCost = 0
        End Try
        con.Close()

        txtUnitCost.Text = ComponentCost
    End Sub

    Public Sub ClearData()
        cboAssemblyPartDescription.SelectedIndex = -1
        cboAssemblyPartNumber.SelectedIndex = -1
        cboComponentDescription.SelectedIndex = -1
        cboComponentPart.SelectedIndex = -1
        cboDeletePartDescription.SelectedIndex = -1
        cboDeletePartNumber.SelectedIndex = -1

        txtAssemblyDescription.Clear()
        txtBuildComment.Clear()
        txtBuildQuantity.Clear()
        txtComponentQuantity.Clear()
        txtUnitCost.Clear()
        txtAssemblyCost.Clear()
        txtQOH.Clear()

        dtpBuildDate.Text = ""

        gpxBuildGroupBox.Enabled = True
        gpxAdd.Enabled = True
        gpxDelete.Enabled = True
        gpxItemInformation.Enabled = True

        cmdContinue.Enabled = False
        cmdClearTab.Enabled = False

        pnlAssemblyLines.Visible = True
        pnlSerialLog.Visible = False

        cboAssemblyPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        TotalAssemblyCost = 0
        GLIssuesAccount = ""
        CurrentPartNumber = ""
        PartDescription = ""
        GLInventoryAccount = ""
        GetItemClass = ""
        AssemblyDescription = ""
        ComponentLineComment = ""
        ComponentPartNumber = ""
        ComponentPartDescription = ""
        LongDescription = ""
        AssemblyDate = ""
        AssemblyComment = ""
        SerializedStatus = ""
        AssemblySerialNumber = ""
        ComponentCost = 0
        UnitBuildCost = 0
        TransactionCost = 0
        AssemblyStandardCost = 0
        ComponentUnitCost = 0
        ComponentExtendedCost = 0
        SumComponentCost = 0
        NextCostingTransactionNumber = 0
        LastCostingTransactionNumber = 0
        NextBuildNumber = 0
        LastBuildNumber = 0
        NextComponentLineNumber = 0
        LastComponentLineNumber = 0
        CheckSerialNumber = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        ComponentQuantity = 0
        UpperLimit = 0
        LowerLimit = 0
        NewUpperLimit = 0
        LastBatchNumber = 0
        NextBatchNumber = 0
        PartSearchPrefix = ""
        PartType = ""
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadComponentPartNumber()
        LoadComponentPartDescription()
        LoadPartNumber()
        LoadPartDescription()
    End Sub

    Private Sub cboAssemblyPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssemblyPartNumber.SelectedIndexChanged
        If cboAssemblyPartNumber.Text = "" Then
            cmdClearAll_Click(sender, e)
        Else
            LoadDescriptionByPartNumber()
            LoadLongDescription()
            LoadTotalAssemblyCost()
            LoadAssemblyQOH()
            ShowData()
        End If
    End Sub

    Private Sub cboAssemblyPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssemblyPartDescription.SelectedIndexChanged
        If cboAssemblyPartDescription.Text = "" Then
            cboAssemblyPartNumber.SelectedIndex = -1
        Else
            LoadPartNumberByDescription()
        End If
    End Sub

    Private Sub cboComponentPart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentPart.SelectedIndexChanged
        If cboComponentPart.Text = "" Then
            cboComponentDescription.SelectedIndex = -1
        Else
            LoadComponentDescriptionByPartNumber()
            LoadComponentCost()
        End If
    End Sub

    Private Sub cboComponentDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComponentDescription.SelectedIndexChanged
        If cboComponentDescription.Text = "" Then
            cboComponentPart.SelectedIndex = -1
        Else
            LoadComponentPartNumberByDescription()
        End If
    End Sub

    Private Sub cmdBuildAssembly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuildAssembly.Click
        'Check for serial numbers
        Dim CheckSerializedAssembly As String = ""

        Dim CheckSerializedAssemblyStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CheckSerializedAssemblyCommand As New SqlCommand(CheckSerializedAssemblyStatement, con)
        CheckSerializedAssemblyCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        CheckSerializedAssemblyCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckSerializedAssembly = CStr(CheckSerializedAssemblyCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSerializedAssembly = "NO"
        End Try
        con.Close()

        If CheckSerializedAssembly = "YES" Then
            'Make datagrid tab invisible and bring up Serial Log tab
            pnlAssemblyLines.Visible = False
            pnlSerialLog.Visible = True
            cmdContinue.Visible = True
            cmdRemoveSerialNumbers.Visible = False

            Dim CurrentPartNumber As String = ""

            CurrentPartNumber = cboAssemblyPartNumber.Text
            PartType = CurrentPartNumber

            Select Case PartType
                Case "TWE17000", "TWE17000N", "TWE17000S", "TWE17000T", "TWE17000-USED", "TWE17000T-USED", "TWE17000S-USED", "TWE17000N-USED", "TWE17000H", "TWE17000H-USED"
                    PartSearchPrefix = "TWE17000%"
                Case "TWE18500", "TWE18500T", "TWE18500N", "TWE18500S", "TWE18500-USED", "TWE18500T-USED", "TWE18500S-USED"
                    PartSearchPrefix = "TWE18500%"
                Case "TWE19000", "TWE19000N", "TWE19000T", "TWE19000S", "TWE19000-USED", "TWE19000T-USED", "TWE19000S-USED"
                    PartSearchPrefix = "TWE19000%"
                Case "TWE250", "TWE250CP", "TWE250CPP", "TWE250-USED", "TWE250CP-USED", "TWE250CPP-USED", "TWE250SPC", "TWE250SPC-USED"
                    PartSearchPrefix = "TWE250%"
                Case "TWE321", "TWE321CP", "TWE321CPP", "TWE321-USED", "TWE321CP-USED", "TWE321CPP-USED", "TWE321SPC", "TWE321SPC-USED"
                    PartSearchPrefix = "TWE321%"
                Case "TWE375", "TWE375CP", "TWE375CPP", "TWE375-USED", "TWE375CP-USED", "TWE375CPP-USED", "TWE375SPC", "TWE375SPC-USED"
                    PartSearchPrefix = "TWE375%"
                Case "TWI250", "TWI250CP", "TWI250CPP", "TWI250-USED", "TWI250CP-USED", "TWI250CPP-USED", "TWI250SPC", "TWI250SPC-USED"
                    PartSearchPrefix = "TWI250%"
                Case "TWI321", "TWI321CP", "TWI321CPP", "TWI321-USED", "TWI321CP-USED", "TWI321CPP-USED", "TWI321SPC", "TWI321SPC-USED"
                    PartSearchPrefix = "TWI321%"
                Case "TWI375", "TWI375CP", "TWI375CPP", "TWI375-USED", "TWI375CP-USED", "TWI375CPP-USED", "TWI375SPC", "TWI375SPC-USED"
                    PartSearchPrefix = "TWI375%"
                Case Else
                    PartSearchPrefix = "SKIP"
            End Select

            If PartSearchPrefix = "SKIP" Then
                ShowSerialLogAvailable()
            Else
                ShowSerialLogAvailableLikeFilter()
            End If

            'Disable Build GroupBox
            gpxBuildGroupBox.Enabled = False
            gpxAdd.Enabled = False
            gpxDelete.Enabled = False
            gpxItemInformation.Enabled = False

            cmdContinue.Enabled = True
            cmdClearTab.Enabled = True
        Else
            '****************************************************************************************************************************************************
            'Continue without serial numbers
            '****************************************************************************************************************************************************

            'Batch items
            '===========

            Dim BuildQuantity As Integer = 0
            Dim BOMComponentCost As Double = 0

            BuildQuantity = Val(txtBuildQuantity.Text)
            '**********************************************************************************
            'Create Build Header Record
            'Get next Build Number
            Dim MAXTransactionNumberStatement As String = "SELECT MAX(BuildTransactionNumber) FROM AssemblyBuildHeaderTable"
            Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBuildNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastBuildNumber = 8820000
            End Try
            con.Close()

            NextBuildNumber = LastBuildNumber + 1

            Try
                'Write Data to Assembly Build Header Table
                cmd = New SqlCommand("Insert Into AssemblyBuildHeaderTable(BuildTransactionNumber, AssemblyPartNumber, AssemblyPartDescription, SerialNumber, BuildComment, DivisionID, BuildDate, BuildCost, BuildStatus)Values(@BuildTransactionNumber, @AssemblyPartNumber, @AssemblyPartDescription, @SerialNumber, @BuildComment, @DivisionID, @BuildDate, @BuildCost, @BuildStatus)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@AssemblyPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                    .Add("@BuildComment", SqlDbType.VarChar).Value = "Build Assembly - " + txtBuildComment.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@BuildCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Serial Form --- Insert Assembly Build Header Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("There was an issue with this build.", MsgBoxStyle.OkOnly)
                Exit Sub
            End Try
            '**********************************************************************************
            'For each line in the datagrid, get line data and get FIFO Cost
            For Each row As DataGridViewRow In dgvAssemblyLineTable.Rows
                Try
                    ComponentPartNumber = row.Cells("ComponentPartNumberColumn").Value
                Catch ex As Exception
                    ComponentPartNumber = ""
                End Try
                Try
                    ComponentPartDescription = row.Cells("ComponentPartDescriptionColumn").Value
                Catch ex As Exception
                    ComponentPartDescription = ""
                End Try
                Try
                    ComponentQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    ComponentQuantity = 0
                End Try
                Try
                    BOMComponentCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    BOMComponentCost = 0
                End Try
                Try
                    ComponentLineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    ComponentLineComment = 0
                End Try
                '*****************************************************************************************************************************************************
                'Get Item Class of Components to write to the GL
                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = ""
                End Try
                Try
                    GetPPL = CStr(GetPPLCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPPL = ""
                End Try
                con.Close()
                '*****************************************************************************************************************************************************
                'Get GL Accounts for Assembly Components
                Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
                GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GLInventoryAccount = "12150"
                End Try
                con.Close()
                '*****************************************************************************************************************************************************
                'Get FIFO Cost of components to calculate Total Cost
                '******************************************************************************************************************************************
                'Determine FIFO Cost on Part Number to remove from Inventory
                Dim TotalQuantityShipped As Double
                '******************************************************************************************************************************************
                'Determine Total Quantity Shipped
                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND LineStatus = 'SHIPPED'"
                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantityShipped = 1
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'Add Total Quantity used in assemblies
                Dim GetBuildQuantity As Double = 0

                Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBuildQuantity = 0
                End Try
                con.Close()

                GetBuildQuantity = GetBuildQuantity * -1

                TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity
                '******************************************************************************************************************************************
                'Get MAX Cost Tier
                Dim MAXCTTransactionNumber As Integer = 0

                Dim MAXCTTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim MAXCTTransactionNumberCommand As New SqlCommand(MAXCTTransactionNumberStatement, con)
                MAXTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                MAXCTTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXCTTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXCTTransactionNumber = CInt(MAXCTTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXCTTransactionNumber = 0
                End Try
                con.Close()

                'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCTTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
                Catch ex As Exception
                    ComponentUnitCost = 0
                End Try
                con.Close()
                '*****************************************************************************************************************************************
                'Get Last Transaction Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim MaxTransactionNumber As Integer = 0

                    Dim MAXTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim MAXTransactionNumber2Command As New SqlCommand(MAXTransactionNumber2Statement, con)
                    MAXTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    MAXTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxTransactionNumber = CInt(MAXTransactionNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        MAXTransactionNumber = 0
                    End Try
                    con.Close()

                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        TransactionCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = TransactionCost
                Else
                    'Do nothing
                End If
                '*****************************************************************************************************************************************
                'Get Last Purchase Cost if Transaction Cost is zero
                If ComponentUnitCost = 0 Then
                    Dim LastPurchaseCost As Double = 0
                    Dim MAXDate2 As Integer = 0

                    Dim MAXDate2Statement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                    MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXDate2 = CInt(MAXDate2Command.ExecuteScalar)
                    Catch ex As Exception
                        MAXDate2 = 0
                    End Try
                    con.Close()

                    Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                    Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                    LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MAXDate2

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastPurchaseCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = LastPurchaseCost
                End If
                '*****************************************************************************************************************************************
                'Get Standard Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        StandardCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = StandardCost

                    'Log component cost as standard
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = "Standard Cost pulled as the component cost -Part # " + ComponentPartNumber
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Serial Form --- Build Assembly"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                Else
                    'Do nothing
                End If
                '*****************************************************************************************************************************************
                'Get cost from BOM if all other methods of costing is zero
                If ComponentUnitCost = 0 Then
                    ComponentUnitCost = BOMComponentCost
                End If
                '*****************************************************************************************************************************************
                ComponentExtendedCost = ComponentUnitCost * ComponentQuantity * BuildQuantity
                ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
                '*****************************************************************************************************************************************
                'Get Next Line Number
                Dim MAXLineNumber1Statement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildtransactionNumber = @BuildTransactionNumber"
                Dim MAXLineNumber1Command As New SqlCommand(MAXLineNumber1Statement, con)
                MAXLineNumber1Command.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastComponentLineNumber = CInt(MAXLineNumber1Command.ExecuteScalar)
                Catch ex As Exception
                    LastComponentLineNumber = 0
                End Try
                con.Close()

                NextComponentLineNumber = LastComponentLineNumber + 1

                Try
                    'Write Data to Assembly Build Line Table - Component Part Number
                    cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                        .Add("@BuildQuantity", SqlDbType.VarChar).Value = BuildQuantity * ComponentQuantity * -1
                        .Add("@BuildUnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                        .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost * -1
                        .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Build Assembly - " + ComponentLineComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Serial Form --- Insert Assembly Build Line Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                'Convert to a positive number
                If ComponentExtendedCost < 0 Then
                    ComponentExtendedCost = ComponentExtendedCost * -1
                End If

                If ComponentQuantity < 0 Then
                    ComponentQuantity = ComponentQuantity * -1
                End If

                ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
                '*****************************************************************************************************************************************
                Try
                    'Write to GL Transaction Table - Component Line Data
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = ComponentPartNumber + " # --- Component"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Serial Form --- Insert GL Table"
                    ErrorReferenceNumber = "FAILURE - Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                If GetPPL = "NON-INVENTORY" Then
                    'Skip
                Else
                    Try
                        'Add transactions to Inventory Transaction Table
                        cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                        With cmd.Parameters
                            '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                            .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "Build Serial Assembly - Components"
                            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = ComponentQuantity * BuildQuantity
                            .Add("@ItemCost", SqlDbType.VarChar).Value = ComponentUnitCost
                            .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                            .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Serial Form --- Insert Inventory Transaction Table"
                        ErrorReferenceNumber = "FAILURE - Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
            Next
            '**********************************************************************************************************
            'Update Total Cost of the assembly based on line cost
            '******************************************************************************************************
            'After all lines are written to the tables - write the assembly part to the tables
            'Update Cost of Assembly Part in Header Table
            Dim SumComponentCostStatement As String = "SELECT SUM(BuildExtendedCost) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
            Dim SumComponentCostCommand As New SqlCommand(SumComponentCostStatement, con)
            SumComponentCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
            SumComponentCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumComponentCost = CDbl(SumComponentCostCommand.ExecuteScalar)
            Catch ex As Exception
                SumComponentCost = 0
            End Try
            con.Close()

            'Determine the Per Unit Component Cost
            UnitBuildCost = SumComponentCost / BuildQuantity
            UnitBuildCost = Math.Round(UnitBuildCost, 5)
            '******************************************************************************************************
            Try
                'UPDATE Assembly Build Table with cost
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildCost", SqlDbType.VarChar).Value = UnitBuildCost * -1
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (NON S/N) --- Update Cost Build Header Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Get Item Class of Assembly to write to the GL
            Dim GetItemClass1Statement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetItemClass1Command As New SqlCommand(GetItemClass1Statement, con)
            GetItemClass1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            GetItemClass1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetItemClass = CStr(GetItemClass1Command.ExecuteScalar)
            Catch ex As Exception
                GetItemClass = "TW WELD PROD"
            End Try
            con.Close()

            'Get GL Accounts for Assembly Components
            Dim GLInventoryAccount1Statement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim GLInventoryAccount1Command As New SqlCommand(GLInventoryAccount1Statement, con)
            GLInventoryAccount1Command.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GLInventoryAccount = CStr(GLInventoryAccount1Command.ExecuteScalar)
            Catch ex As Exception
                GLInventoryAccount = "12150"
            End Try
            con.Close()
            '******************************************************************************************************
            'Convert to a positive number
            If SumComponentCost < 0 Then
                SumComponentCost = SumComponentCost * -1
            End If

            'Round to two decimals
            SumComponentCost = Math.Round(SumComponentCost, 2)
            '******************************************************************************************************
            Try
                'Write to GL Transaction Table - Component Line Data
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly - Full Assembly"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text + " # --- Full Assembly"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Serial Assembly Build Form --- Insert GL Table"
                ErrorReferenceNumber = "FAILURE - Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            Dim MAXLineNumberStatement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
            Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
            MAXLineNumberCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastComponentLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastComponentLineNumber = 0
            End Try
            con.Close()

            NextComponentLineNumber = LastComponentLineNumber + 1
            '*****************************************************************************************************************************************
            'Convert to a positive number
            If UnitBuildCost < 0 Then
                UnitBuildCost = UnitBuildCost * -1
            End If

            Try
                'Add transactions to Inventory Transaction Table
                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                With cmd.Parameters
                    '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Build Serial Assembly - Full Assembly"
                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = BuildQuantity
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Serial Assembly Build Form --- Insert Invetory Transaction Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************************************
            'Write Data to Assembly Build Line Table - Assembly Part Number
            Try
                cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@BuildQuantity", SqlDbType.VarChar).Value = BuildQuantity
                    .Add("@BuildUnitCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Assembly Part Number"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Serial Assembly Build Form --- Insert Assembly Build Line Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Update Build Header Table to include updated cost
            Try
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildCost", SqlDbType.VarChar).Value = SumComponentCost
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Serial Assembly Build Form --- Update Assembly Build Header Cost"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**********************************************************************************************************
            'Create Cost Tier for assembly in Costing Table
            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double
            Dim MaxDate As Date
            Dim MAXCostingNumber As Integer = 0

            Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CDate(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = Today()
            End Try
            con.Close()
            '******************************************************************************************************
            Dim MAXCostingNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
            Dim MAXCostingNumberCommand As New SqlCommand(MAXCostingNumberStatement, con)
            MAXCostingNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            MAXCostingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXCostingNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostingNumber = CInt(MAXCostingNumberCommand.ExecuteScalar)
            Catch ex As Exception
                MAXCostingNumber = 0
            End Try
            con.Close()
            '******************************************************************************************************
            Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostingNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimit = 0
            End Try
            con.Close()
            '******************************************************************************************************
            'Get next Transaction Number
            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1
            '******************************************************************************************************
            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + Val(txtBuildQuantity.Text) - 1

            'Write Values to Inventory Costing Table
            Try
                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "BUILD ASSEMBLY"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = ModalLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Serial Assembly Build Form --- Insert Inventory Costing Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Clear Variables
            UnitBuildCost = 0
            LowerLimit = 0
            UpperLimit = 0
            NewUpperLimit = 0
            LastCostingTransactionNumber = 0

            ClearVariables()
            ClearData()
            ClearDataInDatagrid()

            MsgBox("Assemblies have been built.", MsgBoxStyle.OkOnly)
            '**********************************************************************************************************
        End If
    End Sub

    Private Sub cmdReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReverse.Click
        'Check to see if serialized
        Dim CheckIfSerialized As String = ""

        Dim CheckIfSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CheckIfSerializedCommand As New SqlCommand(CheckIfSerializedStatement, con)
        CheckIfSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        CheckIfSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckIfSerialized = CStr(CheckIfSerializedCommand.ExecuteScalar)
        Catch ex As Exception
            CheckIfSerialized = "NO"
        End Try
        con.Close()

        If CheckIfSerialized = "NO" Then
            'Run Loop for number of assemblies to be un-built
            Dim UnbuildLoopCounter As Integer = 0
            UnbuildLoopCounter = Val(txtBuildQuantity.Text)

            For i As Integer = 1 To UnbuildLoopCounter

                'Get next Build Number
                Dim MAXTransactionNumberStatement As String = "SELECT MAX(BuildTransactionNumber) FROM AssemblyBuildHeaderTable"
                Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastBuildNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastBuildNumber = 8820000
                End Try
                con.Close()

                NextBuildNumber = LastBuildNumber + 1

                'Write Data to Assembly Build Header Table
                Try
                    cmd = New SqlCommand("INSERT INTO AssemblyBuildHeaderTable(BuildTransactionNumber, AssemblyPartNumber, AssemblyPartDescription, SerialNumber, BuildComment, DivisionID, BuildDate, BuildCost, BuildStatus)Values(@BuildTransactionNumber, @AssemblyPartNumber, @AssemblyPartDescription, @SerialNumber, @BuildComment, @DivisionID, @BuildDate, @BuildCost, @BuildStatus)", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                        .Add("@AssemblyPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                        .Add("@BuildComment", SqlDbType.VarChar).Value = "Un-Build - " + txtBuildComment.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BuildDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@BuildCost", SqlDbType.VarChar).Value = 0
                        .Add("@BuildStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Header Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                    MsgBox("Failure to create Build Transaction.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End Try
                '******************************************************************************************************
                'Extract data from grid to write to Line Table
                For Each row As DataGridViewRow In dgvAssemblyLineTable.Rows
                    Try
                        ComponentPartNumber = row.Cells("ComponentPartNumberColumn").Value
                    Catch ex As Exception
                        ComponentPartNumber = ""
                    End Try
                    Try
                        ComponentPartDescription = row.Cells("ComponentPartDescriptionColumn").Value
                    Catch ex As Exception
                        ComponentPartDescription = ""
                    End Try
                    Try
                        ComponentQuantity = row.Cells("QuantityColumn").Value
                    Catch ex As Exception
                        ComponentQuantity = 0
                    End Try
                    Try
                        ComponentCost = row.Cells("UnitCostColumn").Value
                    Catch ex As Exception
                        ComponentCost = 0
                    End Try
                    Try
                        ComponentLineComment = row.Cells("LineCommentColumn").Value
                    Catch ex As Exception
                        ComponentLineComment = 0
                    End Try
                    '*****************************************************************************************************************************************
                    'Get Item Class of Components to write to the GL
                    Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                    GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                    GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                    GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                    GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetItemClass = ""
                    End Try
                    Try
                        GetPPL = CStr(GetPPLCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPPL = ""
                    End Try
                    con.Close()

                    'Get GL Accounts for Assembly Components
                    Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                    Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
                    GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        GLInventoryAccount = "12150"
                    End Try
                    con.Close()

                    GLIssuesAccount = "59790"
                    '*****************************************************************************************************************************************************
                    'Get FIFO Cost of components to calculate Total Cost
                    '******************************************************************************************************************************************
                    'Determine FIFO Cost on Part Number to remove from Inventory
                    Dim TotalQuantityShipped As Double
                    '******************************************************************************************************************************************
                    'Determine Total Quantity Shipped
                    Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND LineStatus = 'SHIPPED'"
                    Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                    TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                    Catch ex As Exception
                        TotalQuantityShipped = 1
                    End Try
                    con.Close()
                    '******************************************************************************************************************************************
                    'Add Total Quantity used in assemblies
                    Dim GetBuildQuantity As Double = 0

                    Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                    Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                    TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetBuildQuantity = 0
                    End Try
                    con.Close()

                    GetBuildQuantity = GetBuildQuantity * -1

                    TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity
                    '******************************************************************************************************************************************
                    'Get MAX Cost Tier
                    Dim MAXCTTransactionNumber As Integer = 0

                    Dim MAXCTTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim MAXCTTransactionNumberCommand As New SqlCommand(MAXCTTransactionNumberStatement, con)
                    MAXTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    MAXCTTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MAXCTTransactionNumberCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MAXCTTransactionNumber = CInt(MAXCTTransactionNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        MAXCTTransactionNumber = 0
                    End Try
                    con.Close()

                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                    Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                    ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                    ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCTTransactionNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        ComponentUnitCost = 0
                    End Try
                    con.Close()
                    '******************************************************************************************************************************************
                    'Get Last Transaction Cost if FIFO Cost is Zero
                    If ComponentUnitCost = 0 Then
                        Dim MaxTransactionNumber As Integer = 0

                        Dim MAXTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                        Dim MAXTransactionNumber2Command As New SqlCommand(MAXTransactionNumber2Statement, con)
                        MAXTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        MAXTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MaxTransactionNumber = CInt(MAXTransactionNumber2Command.ExecuteScalar)
                        Catch ex As Exception
                            MaxTransactionNumber = 0
                        End Try
                        con.Close()

                        Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                        Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                        TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                        TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            TransactionCost = 0
                        End Try
                        con.Close()

                        ComponentUnitCost = TransactionCost
                    Else
                        'Do nothing
                    End If
                    '*****************************************************************************************************************************************
                    'Get Last Purchase Cost if FIFO Cost is zero
                    If ComponentUnitCost = 0 Then
                        Dim LastPurchaseCost As Double = 0
                        Dim MAXDate2 As Integer = 0

                        Dim MAXDate2Statement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                        Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                        MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MAXDate2 = CInt(MAXDate2Command.ExecuteScalar)
                        Catch ex As Exception
                            MAXDate2 = 0
                        End Try
                        con.Close()

                        Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MAXDate2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastPurchaseCost = 0
                        End Try
                        con.Close()

                        ComponentUnitCost = LastPurchaseCost
                    End If
                    '***************************************************************************************************************
                    'Get Standard Cost if FIFO Cost is Zero
                    If ComponentUnitCost = 0 Then
                        Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                        StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                        StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            StandardCost = 0
                        End Try
                        con.Close()

                        ComponentUnitCost = StandardCost

                        'Log component cost as standard
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = "Standard Cost pulled as the component cost -Part # " + ComponentPartNumber
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Serial Form --- Build Assembly"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Do nothing
                    End If
                    '****************************************************************************************************************************************
                    'Get cost from BOM
                    If ComponentUnitCost = 0 Then
                        ComponentUnitCost = ComponentCost
                    End If
                    '****************************************************************************************************************************************
                    ComponentExtendedCost = ComponentUnitCost * ComponentQuantity
                    ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
                    '*****************************************************************************************************************************************
                    'Get Next Line Number
                    Dim MAXLineNumber1Statement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildtransactionNumber = @BuildTransactionNumber"
                    Dim MAXLineNumber1Command As New SqlCommand(MAXLineNumber1Statement, con)
                    MAXLineNumber1Command.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastComponentLineNumber = CInt(MAXLineNumber1Command.ExecuteScalar)
                    Catch ex As Exception
                        LastComponentLineNumber = 0
                    End Try
                    con.Close()

                    NextComponentLineNumber = LastComponentLineNumber + 1

                    'Write Data to Assembly Build Line Table - Component Part Number
                    Try
                        cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                            .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                            .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                            .Add("@BuildQuantity", SqlDbType.VarChar).Value = ComponentQuantity
                            .Add("@BuildUnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                            .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                            .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Un-Build - " + ComponentLineComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Build Form (NON S/N) --- Insert Assembly Build Line Table"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************
                    'Write Components to the GL

                    'Convert to a positive number
                    If ComponentExtendedCost < 0 Then
                        ComponentExtendedCost = ComponentExtendedCost * -1
                    End If

                    If ComponentQuantity < 0 Then
                        ComponentQuantity = ComponentQuantity * -1
                    End If

                    'Write dual transactions to Inventory/Issues Accounts

                    'Write to GL Transaction Table - Component Line Data
                    Try
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Component"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + " Part # - " + ComponentPartNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                        ErrorReferenceNumber = "FAILURE - Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    'Write to GL Transaction Table - Component Line Data
                    Try
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber + 1
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Component"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + " Part # - " + ComponentPartNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                        ErrorReferenceNumber = "FAILURE - Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '*****************************************************************************************************************************************
                    If GetPPL = "NON-INVENTORY" Then
                        'Skip transaction table
                    Else
                        'Add transactions to Inventory Transaction Table
                        Try
                            cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                            With cmd.Parameters
                                '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                                .Add("@TransactionType", SqlDbType.VarChar).Value = "Un-Build Assembly - Components"
                                .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                                .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                                .Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                                .Add("@PartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                                .Add("@Quantity", SqlDbType.VarChar).Value = ComponentQuantity
                                .Add("@ItemCost", SqlDbType.VarChar).Value = ComponentUnitCost
                                .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                                .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                                .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempBuildNumber As Integer = 0
                            Dim strBuildNumber As String
                            TempBuildNumber = NextBuildNumber
                            strBuildNumber = CStr(TempBuildNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Assembly Build Form (S/N) --- Insert Inventory Transaction Table"
                            ErrorReferenceNumber = "Build # " + strBuildNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End If
                Next
                '******************************************************************************************************
                'After all lines are written to the tables - write the assembly part to the tables
                'Update Cost of Assembly Part in Header Table
                Dim SumComponentCostStatement As String = "SELECT SUM(BuildExtendedCost) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
                Dim SumComponentCostCommand As New SqlCommand(SumComponentCostStatement, con)
                SumComponentCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                SumComponentCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumComponentCost = CDbl(SumComponentCostCommand.ExecuteScalar)
                Catch ex As Exception
                    SumComponentCost = 0
                End Try
                con.Close()

                'Determine the Per Unit Component Cost
                UnitBuildCost = SumComponentCost / Val(txtBuildQuantity.Text)
                UnitBuildCost = Math.Round(UnitBuildCost, 5)

                'UPDATE Assembly Build Table with cost
                Try
                    cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@BuildCost", SqlDbType.VarChar).Value = UnitBuildCost * -1
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Update Assembly Build Header Cost"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '******************************************************************************************************
                'Get Item Class of Assembly to write to the GL
                Dim GetItemClass1Statement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClass1Command As New SqlCommand(GetItemClass1Statement, con)
                GetItemClass1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                GetItemClass1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(GetItemClass1Command.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = ""
                End Try
                con.Close()

                'Get GL Accounts for Assembly
                Dim GLInventoryAccount1Statement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GLInventoryAccount1Command As New SqlCommand(GLInventoryAccount1Statement, con)
                GLInventoryAccount1Command.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLInventoryAccount = CStr(GLInventoryAccount1Command.ExecuteScalar)
                Catch ex As Exception
                    GLInventoryAccount = "12100"
                End Try
                con.Close()
                '******************************************************************************************************
                'Write Assembly Cost (Total Component Cost) to the GL

                'Convert to a positive number
                If SumComponentCost < 0 Then
                    SumComponentCost = SumComponentCost * -1
                End If

                'Write to GL Transaction Table - Component Line Data
                Try
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Full Assembly"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SumComponentCost
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + " Part # - " + cboAssemblyPartNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                    ErrorReferenceNumber = "FAILURE - Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Write to GL Transaction Table - Component Line Data
                Try
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Full Assembly"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SumComponentCost
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + cboAssemblyPartNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                    ErrorReferenceNumber = "FAILURE - Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '******************************************************************************************************
                Dim MAXLineNumberStatement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
                Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
                MAXLineNumberCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastComponentLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastComponentLineNumber = 0
                End Try
                con.Close()

                NextComponentLineNumber = LastComponentLineNumber + 1
                '*****************************************************************************************************************************************
                'Convert to a positive number
                If UnitBuildCost < 0 Then
                    UnitBuildCost = UnitBuildCost * -1
                End If

                'Add transactions to Inventory Transaction Table
                Try
                    cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                    With cmd.Parameters
                        '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "Un-Build Assembly"
                        .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                        .Add("@Quantity", SqlDbType.VarChar).Value = 1
                        .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                        .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text) * UnitBuildCost
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                        .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert Inventory Transaction Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                'Write Data to Assembly Build Line Table - Assembly Part Number
                Try
                    cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                        .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                        .Add("@BuildQuantity", SqlDbType.VarChar).Value = -1
                        .Add("@BuildUnitCost", SqlDbType.VarChar).Value = 0
                        .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = 0
                        .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Assembly Part Number"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert Assembly Build Line Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '******************************************************************************************************
                'Update Build Header Table to include updated cost
                Try
                    cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BuildCost", SqlDbType.VarChar).Value = SumComponentCost
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Update Assembly Build Header Cost"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            
                'End of loop for number of unbuilds
            Next i

            '******************************************************************************************************
            'Create Cost Tier for assembly in Costing Table
            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double
            Dim MaxDate As Date
            Dim MAXCostingNumber As Integer = 0

            Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CDate(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = Today()
            End Try
            con.Close()
            '******************************************************************************************************
            Dim MAXCostingNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
            Dim MAXCostingNumberCommand As New SqlCommand(MAXCostingNumberStatement, con)
            MAXCostingNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            MAXCostingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXCostingNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostingNumber = CInt(MAXCostingNumberCommand.ExecuteScalar)
            Catch ex As Exception
                MAXCostingNumber = 0
            End Try
            con.Close()
            '******************************************************************************************************
            Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostingNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimit = 0
            End Try
            con.Close()

            'Get next Transaction Number
            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + Val(txtBuildQuantity.Text) - 1

            'Write Values to Inventory Costing Table
            Try
                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = -1 * Val(txtBuildQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "UN-BUILD ASSEMBLY"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = LastCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Insert Inventory Costing Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Reset Form 
            isLoaded = False
            ClearVariables()
            ClearData()
            ShowData()
            isLoaded = True
            MsgBox("Assembly has been Un-built and added to inventory", MsgBoxStyle.OkOnly)
        Else
            'Make datagrid tab invisible and bring up Serial Log tab
            pnlAssemblyLines.Visible = False
            pnlSerialLog.Visible = True
            cmdContinue.Visible = False
            cmdRemoveSerialNumbers.Visible = True

            ShowSerialLogOpen()

            'Disable Build GroupBox
            gpxBuildGroupBox.Enabled = False
            gpxAdd.Enabled = False
            gpxDelete.Enabled = False
            gpxItemInformation.Enabled = False

            cmdClearTab.Enabled = True
            cmdRemoveSerialNumbers.Enabled = True
        End If
    End Sub

    Private Sub cmdRemoveSerialNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSerialNumbers.Click
        Dim Counter As Integer = 0
        Dim BuildQuantity As Integer = 0
        BuildQuantity = Val(txtBuildQuantity.Text)

        'Verify that # of serial numbers selected equals build quantity
        For Each row As DataGridViewRow In dgvTempSerialLog.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

            If cell.Value = "SELECTED" Then
                Counter = Counter + 1
            End If
        Next
        '************************************************************************************
        Dim LineSerialNumber As String = ""
        Dim LineStatus As String = ""

        If Counter = BuildQuantity Then
            For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                If cell.Value = "SELECTED" Then
                    Try
                        LineSerialNumber = row.Cells("SerialNumberColumn").Value
                    Catch ex As Exception
                        LineSerialNumber = ""
                    End Try
                    Try
                        LineStatus = row.Cells("StatusColumn").Value
                    Catch ex As Exception
                        LineStatus = "OPEN"
                    End Try

                    If LineSerialNumber <> "" And LineStatus = "OPEN" Then
                        Try
                            'Add Entry in Serial Log
                            cmd = New SqlCommand("UPDATE AssemblySerialLog SET TotalCost = @TotalCost, Comment = @Comment, BuildDate = @BuildDate, Status = @Status, TransactionNumber = @TransactionNumber, CustomerID = @CustomerID, BatchNumber = @BatchNumber, BuildNumber = @BuildNumber WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = LineSerialNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@TotalCost", SqlDbType.VarChar).Value = 0
                                .Add("@Comment", SqlDbType.VarChar).Value = "Un-Build Assembly"
                                .Add("@BuildDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                                .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                                .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempBuildNumber As Integer = 0
                            Dim strBuildNumber As String
                            TempBuildNumber = NextBuildNumber
                            strBuildNumber = CStr(TempBuildNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Assembly Serial Form --- Reset Serial Log"
                            ErrorReferenceNumber = "Build # " + strBuildNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip
                    End If
                End If
            Next
            '**********************************************************************************
            'Serial Number are reset - proceed with unbuild
            'Get next Build Number
            Dim MAXTransactionNumberStatement As String = "SELECT MAX(BuildTransactionNumber) FROM AssemblyBuildHeaderTable"
            Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBuildNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastBuildNumber = 8820000
            End Try
            con.Close()

            NextBuildNumber = LastBuildNumber + 1

            'Write Data to Assembly Build Header Table
            Try
                cmd = New SqlCommand("Insert Into AssemblyBuildHeaderTable(BuildTransactionNumber, AssemblyPartNumber, AssemblyPartDescription, SerialNumber, BuildComment, DivisionID, BuildDate, BuildCost, BuildStatus)Values(@BuildTransactionNumber, @AssemblyPartNumber, @AssemblyPartDescription, @SerialNumber, @BuildComment, @DivisionID, @BuildDate, @BuildCost, @BuildStatus)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@AssemblyPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                    .Add("@BuildComment", SqlDbType.VarChar).Value = "Un-Build Assembly - " + txtBuildComment.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@BuildCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Insert Assembly Build Header Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
                MsgBox("Error creating Build Transaction.", MsgBoxStyle.OkOnly)
                Exit Sub
            End Try
            '******************************************************************************************************
            'Extract data from grid to write to Line Table
            For Each row As DataGridViewRow In dgvAssemblyLineTable.Rows
                Try
                    ComponentPartNumber = row.Cells("ComponentPartNumberColumn").Value
                Catch ex As Exception
                    ComponentPartNumber = ""
                End Try
                Try
                    ComponentPartDescription = row.Cells("ComponentPartDescriptionColumn").Value
                Catch ex As Exception
                    ComponentPartDescription = ""
                End Try
                Try
                    ComponentQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    ComponentQuantity = 0
                End Try
                Try
                    ComponentCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    ComponentCost = 0
                End Try
                Try
                    ComponentLineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    ComponentLineComment = ""
                End Try
                '*****************************************************************************************************************************************
                'Get Item Class of Components to write to the GL
                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = ""
                End Try
                Try
                    GetPPL = CStr(GetPPLCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPPL = ""
                End Try
                con.Close()

                'Get GL Accounts for Assembly Components
                Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
                GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GLInventoryAccount = "12150"
                End Try
                con.Close()

                GLIssuesAccount = "59790"
                '*****************************************************************************************************************************************
                'Get FIFO Cost of components to calculate Total Cost
                '******************************************************************************************************************************************
                'Determine FIFO Cost on Part Number to remove from Inventory
                Dim TotalQuantityShipped As Double
                '******************************************************************************************************************************************
                'Determine Total Quantity Shipped
                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantityShipped = 1
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'Add Total Quantity used in assemblies
                Dim GetBuildQuantity As Double = 0

                Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBuildQuantity = 0
                End Try
                con.Close()

                GetBuildQuantity = GetBuildQuantity * -1

                TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity
                '******************************************************************************************************************************************
                'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
                Catch ex As Exception
                    ComponentUnitCost = 0
                End Try
                con.Close()

                'Get Last Transaction Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim MaxInventoryTransactionNumber As Integer = 0

                    Dim MaxInventoryTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim MaxInventoryTransactionNumberCommand As New SqlCommand(MaxInventoryTransactionNumberStatement, con)
                    MaxInventoryTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    MaxInventoryTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxInventoryTransactionNumber = CInt(MaxInventoryTransactionNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxInventoryTransactionNumber = 0
                    End Try
                    con.Close()
                    '**************************************************
                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxInventoryTransactionNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        TransactionCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = TransactionCost
                Else
                    'Do nothing
                End If

                'Get Standard Cost if FIFO Cost is Zero
                If ComponentUnitCost = 0 Then
                    Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                    StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                    StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        StandardCost = 0
                    End Try
                    con.Close()

                    ComponentUnitCost = StandardCost
                Else
                    'Do nothing
                End If

                ComponentExtendedCost = ComponentUnitCost * ComponentQuantity
                '*****************************************************************************************************************************************
                'Calculate totals for multiple entries

                QuantityMultiplier = Val(txtBuildQuantity.Text)

                ComponentExtendedCost = ComponentExtendedCost * QuantityMultiplier
                ComponentQuantity = ComponentQuantity * QuantityMultiplier
                ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
                '*****************************************************************************************************************************************
                'Get Next Line Number
                Dim MAXLineNumber1Statement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildtransactionNumber = @BuildTransactionNumber"
                Dim MAXLineNumber1Command As New SqlCommand(MAXLineNumber1Statement, con)
                MAXLineNumber1Command.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastComponentLineNumber = CInt(MAXLineNumber1Command.ExecuteScalar)
                Catch ex As Exception
                    LastComponentLineNumber = 0
                End Try
                con.Close()

                NextComponentLineNumber = LastComponentLineNumber + 1

                'Write Line Comment if blank
                If ComponentLineComment = "" Then
                    ComponentLineComment = "Remove Component"
                End If

                'Write Data to Assembly Build Line Table - Component Part Number
                Try
                    cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                        .Add("@BuildQuantity", SqlDbType.VarChar).Value = ComponentQuantity
                        .Add("@BuildUnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                        .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@BuildLineComment", SqlDbType.VarChar).Value = ComponentLineComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert Assembly Build Line Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '******************************************************************************************************
                'Convert to a positive number
                If ComponentExtendedCost < 0 Then
                    ComponentExtendedCost = ComponentExtendedCost * -1
                End If

                If ComponentQuantity < 0 Then
                    ComponentQuantity = ComponentQuantity * -1
                End If

                'Write dual transactions to Inventory/Issues Accounts

                'Write to GL Transaction Table - Component Line Data
                Try
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Remove Component"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + " - S/N " + LineSerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Write to GL Transaction Table - Component Line Data
                Try
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Component"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + " - S/N " + LineSerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                'Add transactions to Inventory Transaction Table
                Try
                    cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                    With cmd.Parameters
                        '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "Un-Build Assembly - Component"
                        .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                        .Add("@Quantity", SqlDbType.VarChar).Value = ComponentQuantity
                        .Add("@ItemCost", SqlDbType.VarChar).Value = ComponentUnitCost
                        .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                        .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBuildNumber As Integer = 0
                    Dim strBuildNumber As String
                    TempBuildNumber = NextBuildNumber
                    strBuildNumber = CStr(TempBuildNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Assembly Build Form (S/N) --- Insert Inventory Transaction Table"
                    ErrorReferenceNumber = "Build # " + strBuildNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next
            '******************************************************************************************************
            'After all lines are written to the tables - write the assembly part to the tables
            'Update Cost of Assembly Part in Header Table
            Dim SumComponentCostStatement As String = "SELECT SUM(BuildExtendedCost) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
            Dim SumComponentCostCommand As New SqlCommand(SumComponentCostStatement, con)
            SumComponentCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
            SumComponentCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumComponentCost = CDbl(SumComponentCostCommand.ExecuteScalar)
            Catch ex As Exception
                SumComponentCost = 0
            End Try
            con.Close()

            'Determine the Per Unit Component Cost
            UnitBuildCost = SumComponentCost / Val(txtBuildQuantity.Text)
            UnitBuildCost = Math.Round(UnitBuildCost, 5)

            'UPDATE Assembly Build Table with cost
            Try
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildCost", SqlDbType.VarChar).Value = UnitBuildCost * -1
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Update Assembly Build Header Cost"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Get Item Class of Assembly to write to the GL
            Dim GetItemClass1Statement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetItemClass1Command As New SqlCommand(GetItemClass1Statement, con)
            GetItemClass1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            GetItemClass1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetItemClass = CStr(GetItemClass1Command.ExecuteScalar)
            Catch ex As Exception
                GetItemClass = ""
            End Try
            con.Close()

            'Get GL Accounts for Assembly
            Dim GLInventoryAccount1Statement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim GLInventoryAccount1Command As New SqlCommand(GLInventoryAccount1Statement, con)
            GLInventoryAccount1Command.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GLInventoryAccount = CStr(GLInventoryAccount1Command.ExecuteScalar)
            Catch ex As Exception
                GLInventoryAccount = "12100"
            End Try
            con.Close()
            '******************************************************************************************************
            'Convert to a positive number
            If SumComponentCost < 0 Then
                SumComponentCost = SumComponentCost * -1
            End If

            'Write to GL Transaction Table - Component Line Data
            Try
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Full Assembly"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + " - S/N " + LineSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Write to GL Transaction Table - Component Line Data
            Try
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber + 1
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Un-Build Assembly - Full Assembly"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtBuildComment.Text + " - S/N " + LineSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Insert GL Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            Dim MAXLineNumberStatement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
            Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
            MAXLineNumberCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastComponentLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastComponentLineNumber = 0
            End Try
            con.Close()

            NextComponentLineNumber = LastComponentLineNumber + 1
            '*****************************************************************************************************************************************
            'Convert to a positive number
            If UnitBuildCost < 0 Then
                UnitBuildCost = UnitBuildCost * -1
            End If

            'Add transactions to Inventory Transaction Table
            Try
                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                With cmd.Parameters
                    '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Un-Build Assembly -- S/N " + LineSerialNumber
                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text) * UnitBuildCost
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Insert Inventory Transaction Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*****************************************************************************************************************************************
            'Write Data to Assembly Build Line Table - Assembly Part Number
            Try
                cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                    .Add("@BuildQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text) * -1
                    .Add("@BuildUnitCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = 0
                    .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Assembly Part Number " + LineSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Insert Assembly Build Line Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Create Cost Tier for assembly in Costing Table
            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double
            Dim MaxDate As Date
            Dim MAXCostingNumber As Integer = 0

            Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CDate(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = Today()
            End Try
            con.Close()
            '******************************************************************************************************
            Dim MAXCostingNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
            Dim MAXCostingNumberCommand As New SqlCommand(MAXCostingNumberStatement, con)
            MAXCostingNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            MAXCostingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXCostingNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostingNumber = CInt(MAXCostingNumberCommand.ExecuteScalar)
            Catch ex As Exception
                MAXCostingNumber = 0
            End Try
            con.Close()
            '******************************************************************************************************
            Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostingNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimit = 0
            End Try
            con.Close()

            'Get next Transaction Number
            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + Val(txtBuildQuantity.Text) - 1

            'Write Values to Inventory Costing Table
            Try
                cmd = New SqlCommand("INSERT INTO InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)
                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "UN-BUILD ASSEMBLY"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = LastCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Insert Inventory Costing Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Update Build Header Table to include updated cost
            Try
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost, BuildComment = @BuildComment WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BuildCost", SqlDbType.VarChar).Value = SumComponentCost
                    .Add("@BuildComment", SqlDbType.VarChar).Value = "UN-BUILD ASSEMBLY"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Assembly Build Form (S/N) --- Update Assembly Build Header Cost"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            'Reset Form 
            isLoaded = False
            ClearVariables()
            ClearData()
            ShowData()
            isLoaded = True
            MsgBox("Assembly has been Un-built and added to inventory", MsgBoxStyle.OkOnly)
        Else
            MsgBox("Quantity selected does not match quantity unbuilt.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        ClearSerialLog()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddComponent.Click
        pnlAssemblyLines.Visible = True
        pnlSerialLog.Visible = False

        'Get MAX Line Number
        Dim LastLineNumber, NextLineNumber As Integer

        Dim MaxLineNumberStatement As String = "SELECT MAX(ComponentLineNumber) FROM AssemblyLineTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim MaxLineNumberCommand As New SqlCommand(MaxLineNumberStatement, con)
        MaxLineNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
        MaxLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastLineNumber = CInt(MaxLineNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastLineNumber = 0
        End Try
        con.Close()

        NextLineNumber = LastLineNumber + 1

        ds.Tables("AssemblyLineTable").Rows.Add(cboAssemblyPartNumber.Text, NextLineNumber, cboDivisionID.Text, cboComponentPart.Text, cboComponentDescription.Text, txtComponentQuantity.Text, txtUnitCost.Text, Convert.ToDouble(txtComponentQuantity.Text) * Convert.ToDouble(txtUnitCost.Text), "TEMP PART")
        'Clear Line Data
        cboComponentPart.SelectedIndex = -1
        cboComponentDescription.SelectedIndex = -1
        txtUnitCost.Clear()
        txtComponentQuantity.Clear()
    End Sub

    Private Sub cmdDeleteComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteComponent.Click
        pnlAssemblyLines.Visible = True
        pnlSerialLog.Visible = False

        Dim currentRow As Integer = dgvAssemblyLineTable.CurrentCell.RowIndex
        dgvAssemblyLineTable.Rows.RemoveAt(currentRow)
    End Sub

    Private Sub cmdContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinue.Click
        Dim Counter As Integer = 0
        Dim BuildQuantity As Integer = 0
        BuildQuantity = Val(txtBuildQuantity.Text)

        'Verify that # of serial numbers selected equals build quantity
        For Each row As DataGridViewRow In dgvTempSerialLog.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

            If cell.Value = "SELECTED" Then
                Counter = Counter + 1
            End If
        Next
        '*******************************************************************************************
        If Counter = BuildQuantity Then
            Dim SerialNumber As String = ""
            Dim RowPartNumber As String = ""

            '*******************************************************************************************************************************
            'Continue with Build Procedure
            '*******************************************************************************************************************************
            For Each row As DataGridViewRow In dgvTempSerialLog.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectColumn")

                If cell.Value = "SELECTED" Then
                    Try
                        SerialNumber = row.Cells("SerialNumberColumn").Value
                    Catch ex As Exception
                        SerialNumber = ""
                    End Try
                    Try
                        RowPartNumber = row.Cells("AssemblyPartNumberColumn2").Value
                    Catch ex As Exception
                        RowPartNumber = ""
                    End Try
                    '***********************************************************************************************************************
                    If SerialNumber = "" Or RowPartNumber = "" Then
                        MsgBox("Part # and Serial # required.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    '************************************************************************************************************************
                    If RowPartNumber <> cboAssemblyPartNumber.Text Then
                        'Update serial log
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET AssemblyPartNumber = @AssemblyPartNumber WHERE AssemblyPartNumber = @AssemblyPartNumber2 AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                            .Add("@AssemblyPartNumber2", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                    '************************************************************************************************************************
                    'Get next Build Number
                    Dim MAXTransactionNumberStatement As String = "SELECT MAX(BuildTransactionNumber) FROM AssemblyBuildHeaderTable"
                    Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastBuildNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastBuildNumber = 8820000
                    End Try
                    con.Close()

                    NextBuildNumber = LastBuildNumber + 1

                    Try
                        'Write Data to Assembly Build Header Table
                        cmd = New SqlCommand("Insert Into AssemblyBuildHeaderTable(BuildTransactionNumber, AssemblyPartNumber, AssemblyPartDescription, SerialNumber, BuildComment, DivisionID, BuildDate, BuildCost, BuildStatus)Values(@BuildTransactionNumber, @AssemblyPartNumber, @AssemblyPartDescription, @SerialNumber, @BuildComment, @DivisionID, @BuildDate, @BuildCost, @BuildStatus)", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                            .Add("@AssemblyPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                            .Add("@BuildComment", SqlDbType.VarChar).Value = txtBuildComment.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BuildDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                            .Add("@BuildCost", SqlDbType.VarChar).Value = 0
                            .Add("@BuildStatus", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Serial Form --- Insert Assembly Build Header Table"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '**********************************************************************************************************
                    'For each line in the datagrid, get line data and get FIFO Cost
                    For Each row2 As DataGridViewRow In dgvAssemblyLineTable.Rows
                        Try
                            ComponentPartNumber = row2.Cells("ComponentPartNumberColumn").Value
                        Catch ex As Exception
                            ComponentPartNumber = ""
                        End Try
                        Try
                            ComponentPartDescription = row2.Cells("ComponentPartDescriptionColumn").Value
                        Catch ex As Exception
                            ComponentPartDescription = ""
                        End Try
                        Try
                            ComponentQuantity = row2.Cells("QuantityColumn").Value
                        Catch ex As Exception
                            ComponentQuantity = 0
                        End Try
                        Try
                            ComponentCost = row2.Cells("UnitCostColumn").Value
                        Catch ex As Exception
                            ComponentCost = 0
                        End Try
                        Try
                            ComponentLineComment = row2.Cells("LineCommentColumn").Value
                        Catch ex As Exception
                            ComponentLineComment = 0
                        End Try
                        '*****************************************************************************************************************************************************
                        'Get Item Class of Components to write to the GL
                        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                        GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                        GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetItemClass = ""
                        End Try
                        Try
                            GetPPL = CStr(GetPPLCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetPPL = ""
                        End Try
                        con.Close()

                        'Get GL Accounts for Assembly Components
                        Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                        Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
                        GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            GLInventoryAccount = "12150"
                        End Try
                        con.Close()

                        '*****************************************************************************************************************************************************
                        'Get FIFO Cost of components to calculate Total Cost
                        '******************************************************************************************************************************************
                        'Determine FIFO Cost on Part Number to remove from Inventory
                        Dim TotalQuantityShipped As Double
                        '******************************************************************************************************************************************
                        'Determine Total Quantity Shipped
                        Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND Dropship <> @Dropship AND LineStatus <> @LineStatus"
                        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"
                        TotalQuantityShippedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                        Catch ex As Exception
                            TotalQuantityShipped = 0
                        End Try
                        con.Close()
                        '******************************************************************************************************************************************
                        'Add Total Quantity used in assemblies
                        Dim GetBuildQuantity As Double = 0

                        Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                        Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                        TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetBuildQuantity = 0
                        End Try
                        con.Close()

                        GetBuildQuantity = GetBuildQuantity * -1

                        TotalQuantityShipped = GetBuildQuantity + TotalQuantityShipped
                        '******************************************************************************************************************************************
                        'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                        Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                        Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
                        ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ComponentUnitCost = CDbl(ItemCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            ComponentUnitCost = 0
                        End Try
                        con.Close()
                        '*******************************************************************************************************************************************
                        'Get Last Transaction Cost if FIFO Cost is Zero
                        If ComponentUnitCost = 0 Then
                            Dim MaxDate As Integer = 0

                            Dim MaxDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                            Dim MaxDateCommand As New SqlCommand(MaxDateStatement, con)
                            MaxDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                            MaxDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                MaxDate = CInt(MaxDateCommand.ExecuteScalar)
                            Catch ex As Exception
                                MaxDate = 0
                            End Try
                            con.Close()

                            Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE TransactionNumnber = @TransactionNumber"
                            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                            TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxDate

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                            Catch ex As Exception
                                TransactionCost = 0
                            End Try
                            con.Close()

                            ComponentUnitCost = TransactionCost

                            'Log error on update failure
                            Dim TempBuildNumber As Integer = 0
                            Dim strBuildNumber As String
                            TempBuildNumber = NextBuildNumber
                            strBuildNumber = CStr(TempBuildNumber)

                            ErrorDate = Today()
                            ErrorComment = "Part Number - " + ComponentPartNumber + " pulled last transaction cost."
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Assembly Serial Form --- Get Last Transaction Cost"
                            ErrorReferenceNumber = "Build # " + strBuildNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Do nothing
                        End If
                        '*******************************************************************************************************************************************
                        'Get Standard Cost if FIFO Cost is Zero
                        If ComponentUnitCost = 0 Then
                            Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                            StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber
                            StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                            Catch ex As Exception
                                StandardCost = 0
                            End Try
                            con.Close()

                            ComponentUnitCost = StandardCost

                            'Log error on update failure
                            Dim TempBuildNumber As Integer = 0
                            Dim strBuildNumber As String
                            TempBuildNumber = NextBuildNumber
                            strBuildNumber = CStr(TempBuildNumber)

                            ErrorDate = Today()
                            ErrorComment = "Part Number - " + ComponentPartNumber + " pulled standard cost."
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Assembly Serial Form --- Get Standard Cost"
                            ErrorReferenceNumber = "Build # " + strBuildNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Do nothing
                        End If
                    
                        ComponentExtendedCost = ComponentUnitCost * ComponentQuantity
                        ComponentExtendedCost = Math.Round(ComponentExtendedCost, 2)
                        '*****************************************************************************************************************************************
                        'Get Next Line Number
                        Dim MAXLineNumber1Statement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildtransactionNumber = @BuildTransactionNumber"
                        Dim MAXLineNumber1Command As New SqlCommand(MAXLineNumber1Statement, con)
                        MAXLineNumber1Command.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastComponentLineNumber = CInt(MAXLineNumber1Command.ExecuteScalar)
                        Catch ex As Exception
                            LastComponentLineNumber = 0
                        End Try
                        con.Close()

                        NextComponentLineNumber = LastComponentLineNumber + 1

                        Try
                            'Write Data to Assembly Build Line Table - Component Part Number
                            cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                                .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                                .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                                .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                                .Add("@BuildQuantity", SqlDbType.VarChar).Value = ComponentQuantity * -1
                                .Add("@BuildUnitCost", SqlDbType.VarChar).Value = ComponentUnitCost
                                .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost * -1
                                .Add("@BuildLineComment", SqlDbType.VarChar).Value = ComponentLineComment
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempBuildNumber As Integer = 0
                            Dim strBuildNumber As String
                            TempBuildNumber = NextBuildNumber
                            strBuildNumber = CStr(TempBuildNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Assembly Serial Form --- Insert Assembly Build Line Table"
                            ErrorReferenceNumber = "Build # " + strBuildNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*****************************************************************************************************************************************
                        'Convert to a positive number
                        If ComponentExtendedCost < 0 Then
                            ComponentExtendedCost = ComponentExtendedCost * -1
                        End If

                        If ComponentQuantity < 0 Then
                            ComponentQuantity = ComponentQuantity * -1
                        End If

                        Try
                            'Write to GL Transaction Table - Component Line Data
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ComponentExtendedCost
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = ComponentPartNumber + " - S/N " + SerialNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = NextComponentLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempBuildNumber As Integer = 0
                            Dim strBuildNumber As String
                            TempBuildNumber = NextBuildNumber
                            strBuildNumber = CStr(TempBuildNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Assembly Serial Form --- Insert GL Table"
                            ErrorReferenceNumber = "Build # " + strBuildNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*****************************************************************************************************************************************
                        If GetPPL = "NON-INVENTORY" Then
                            'Skip Inventory Transaction entry
                        Else
                            Try
                                'Add transactions to Inventory Transaction Table
                                cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                                With cmd.Parameters
                                    '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Build Serial Assembly - Components"
                                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = ComponentPartDescription
                                    .Add("@Quantity", SqlDbType.VarChar).Value = ComponentQuantity
                                    .Add("@ItemCost", SqlDbType.VarChar).Value = ComponentUnitCost
                                    .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ComponentExtendedCost
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempBuildNumber As Integer = 0
                                Dim strBuildNumber As String
                                TempBuildNumber = NextBuildNumber
                                strBuildNumber = CStr(TempBuildNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Assembly Serial Form --- Insert Inventory Transaction Table"
                                ErrorReferenceNumber = "Build # " + strBuildNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End If
                    Next
                    'End of Component Routine
                    '**********************************************************************************************************



                    '**********************************************************************************************************
                    'Update Total Cost of the assembly based on line cost
                    '******************************************************************************************************
                    'After all lines are written to the tables - write the assembly part to the tables
                    'Update Cost of Assembly Part in Header Table
                    Dim SumComponentCostStatement As String = "SELECT SUM(BuildExtendedCost) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
                    Dim SumComponentCostCommand As New SqlCommand(SumComponentCostStatement, con)
                    SumComponentCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                    SumComponentCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SumComponentCost = CDbl(SumComponentCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        SumComponentCost = 0
                    End Try
                    con.Close()

                    'Determine the Per Unit Component Cost
                    UnitBuildCost = SumComponentCost
                    SumComponentCost = Math.Round(SumComponentCost, 5)
                    UnitBuildCost = Math.Round(UnitBuildCost, 5)
                    '******************************************************************************************************
                    Try
                        'UPDATE Assembly Build Table with cost
                        cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@BuildCost", SqlDbType.VarChar).Value = UnitBuildCost * -1
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Build Form (NON S/N) --- Update Cost Build Header Table"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '**********************************************************************************************************
                    'Update record in the Serial Log Table
                    Try
                        'Add Entry in Serial Log
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET TotalCost = @TotalCost, Comment = @Comment, BuildDate = @BuildDate, Status = @Status, TransactionNumber = @TransactionNumber, CustomerID = @CustomerID, BatchNumber = @BatchNumber, BuildNumber = @BuildNumber WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TotalCost", SqlDbType.VarChar).Value = SumComponentCost * -1
                            .Add("@Comment", SqlDbType.VarChar).Value = txtBuildComment.Text
                            .Add("@BuildDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = NextBuildNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Assembly Serial Form --- Insert Serial Log"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************
                    'Get Item Class of Assembly to write to the GL
                    Dim GetItemClass1Statement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim GetItemClass1Command As New SqlCommand(GetItemClass1Statement, con)
                    GetItemClass1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    GetItemClass1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetItemClass = CStr(GetItemClass1Command.ExecuteScalar)
                    Catch ex As Exception
                        GetItemClass = "TW WELD PROD"
                    End Try
                    con.Close()

                    'Get GL Accounts for Assembly Components
                    Dim GLInventoryAccount1Statement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                    Dim GLInventoryAccount1Command As New SqlCommand(GLInventoryAccount1Statement, con)
                    GLInventoryAccount1Command.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GLInventoryAccount = CStr(GLInventoryAccount1Command.ExecuteScalar)
                    Catch ex As Exception
                        GLInventoryAccount = "12150"
                    End Try
                    con.Close()
                    '******************************************************************************************************
                    'Convert to a positive number
                    If SumComponentCost < 0 Then
                        SumComponentCost = SumComponentCost * -1
                    End If

                    Try
                        'Write to GL Transaction Table - Component Line Data
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Build Assembly - Full Assembly"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SumComponentCost
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text + " - S/N " + SerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Serial Assembly Build Form --- Insert GL Table"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************
                    Dim MAXLineNumberStatement As String = "SELECT MAX(BuildLineNumber) FROM AssemblyBuildLineTable WHERE BuildTransactionNumber = @BuildTransactionNumber"
                    Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
                    MAXLineNumberCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastComponentLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastComponentLineNumber = 0
                    End Try
                    con.Close()

                    NextComponentLineNumber = LastComponentLineNumber + 1
                    '*****************************************************************************************************************************************
                    'Convert to a positive number
                    If UnitBuildCost < 0 Then
                        UnitBuildCost = UnitBuildCost * -1
                    End If

                    Try
                        'Add transactions to Inventory Transaction Table
                        cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                        With cmd.Parameters
                            '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                            .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "Build Serial Assembly - Full Assembly S/N - " + SerialNumber
                            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                            .Add("@PartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                            .Add("@Quantity", SqlDbType.VarChar).Value = 1
                            .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                            .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = UnitBuildCost
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                            .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Serial Assembly Form --- Insert Inventory Transaction Table"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '*****************************************************************************************************************************************
                    'Write Data to Assembly Build Line Table - Assembly Part Number
                    Try
                        cmd = New SqlCommand("Insert Into AssemblyBuildLineTable(BuildTransactionNumber, BuildLineNumber, ComponentPartNumber, ComponentPartDescription, BuildQuantity, BuildUnitCost, BuildExtendedCost, BuildLineComment, DivisionID)Values(@BuildTransactionNumber, @BuildLineNumber, @ComponentPartNumber, @ComponentPartDescription, @BuildQuantity, @BuildUnitCost, @BuildExtendedCost, @BuildLineComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@BuildLineNumber", SqlDbType.VarChar).Value = NextComponentLineNumber
                            .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                            .Add("@ComponentPartDescription", SqlDbType.VarChar).Value = cboAssemblyPartDescription.Text
                            .Add("@BuildQuantity", SqlDbType.VarChar).Value = 1
                            .Add("@BuildUnitCost", SqlDbType.VarChar).Value = 0
                            .Add("@BuildExtendedCost", SqlDbType.VarChar).Value = 0
                            .Add("@BuildLineComment", SqlDbType.VarChar).Value = "Assembly Part Number"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Serial Assembly Form --- Insert Assembly Build Line Table"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '*****************************************************************************************************************
                    'Update Build Header Table to include updated cost
                    Try
                        cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET BuildCost = @BuildCost WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = NextBuildNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BuildCost", SqlDbType.VarChar).Value = SumComponentCost
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBuildNumber As Integer = 0
                        Dim strBuildNumber As String
                        TempBuildNumber = NextBuildNumber
                        strBuildNumber = CStr(TempBuildNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Serial Assembly Form --- Update Assembly Build Header Cost"
                        ErrorReferenceNumber = "Build # " + strBuildNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************
                    'Clear data before next loop re-iteration
                    ModalBuildNumber = NextBuildNumber
                    ModalLineNumber = NextComponentLineNumber

                    SumComponentCost = 0
                    LastComponentLineNumber = 0
                    NextComponentLineNumber = 0
                    NextBuildNumber = 0
                    GLInventoryAccount = ""
                    GetItemClass = ""
                    SerialNumber = ""
                End If
            Next
            '******************************************************************************************************
            'Create Cost Tier for assembly in Costing Table
            'Extract the Upper and Lower Limit of the Inventory Costing Table
            Dim NewUpperLimit, LowerLimit, UpperLimit As Double

            Dim UpperLimitStatement As String = "SELECT MAX(UpperLimit) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
            UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
            UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
            Catch ex As Exception
                UpperLimit = 0
            End Try
            con.Close()

            'Get next Transaction Number
            Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
            Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastCostingTransactionNumber = 63600000
            End Try
            con.Close()

            NextCostingTransactionNumber = LastCostingTransactionNumber + 1

            'Calculate the NEW Lower/Upper Limit for the next post
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + Val(txtBuildQuantity.Text) - 1

            'Write Values to Inventory Costing Table
            Try
                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboAssemblyPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpBuildDate.Text
                    .Add("@ItemCost", SqlDbType.VarChar).Value = UnitBuildCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = Val(txtBuildQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "BUILD ASSEMBLY"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = LastCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ModalBuildNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = ModalLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBuildNumber As Integer = 0
                Dim strBuildNumber As String
                TempBuildNumber = NextBuildNumber
                strBuildNumber = CStr(TempBuildNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Serial Assembly Form --- Insert Inventory Costing Table"
                ErrorReferenceNumber = "Build # " + strBuildNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************
            LastCostingTransactionNumber = 0
            UnitBuildCost = 0
            LowerLimit = 0
            UpperLimit = 0
            NewUpperLimit = 0

            ClearSerialLog()
            ClearData()
            ClearVariables()
            ClearDataInDatagrid()

            MsgBox("Assemblies are built and serial numbers assigned.", MsgBoxStyle.OkOnly)
        Else
            MsgBox("The number selected has to match the build quantity.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdClearTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTab.Click
        'Make datagrid tab invisible and bring up Serial Log tab
        pnlAssemblyLines.Visible = True
        pnlSerialLog.Visible = False

        gpxBuildGroupBox.Enabled = True
        gpxAdd.Enabled = True
        gpxDelete.Enabled = True
        gpxItemInformation.Enabled = True

        ClearSerialLog()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalAssemblyPartNumber = cboAssemblyPartNumber.Text

        Using NewPrintAssemblyBOM As New PrintAssemblyBOM
            Dim Result = NewPrintAssemblyBOM.ShowDialog()
        End Using
    End Sub

    Private Sub txtBuildQuantity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildQuantity.Leave
        If txtBuildQuantity.Text = "" Or Val(txtBuildQuantity.Text) = 0 Then
            'Do nothing
        Else
            LoadQOHFormatting()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintBOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBOMToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub dgvAssemblyLineTable_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAssemblyLineTable.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub
End Class