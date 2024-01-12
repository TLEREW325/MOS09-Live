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
Public Class ManufacturingMaintenance
    Inherits System.Windows.Forms.Form

    Dim DepartmentName, DepartmentDescription As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;async=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15, ds16, ds17, ds18 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ManufacturingMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        'Initialize Data
        usefulFunctions.LoadSecurity(Me)
        If EmployeeCompanyCode.Equals("TFP") Or EmployeeCompanyCode.Equals("TWD") Then
            cboDivisionID.Text = "TWD"
        Else
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadMachineClass()
        LoadDepartmentID()
        LoadMachineID()

        ShowData()

        ClearData()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM MachineTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "MachineTable")
        dgvMachineTable.DataSource = ds.Tables("MachineTable")
        con.Close()
    End Sub

    Public Sub LoadMachineID()
        cmd = New SqlCommand("SELECT MachineID FROM MachineTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "MachineTable")
        cboMachineID.DataSource = ds1.Tables("MachineTable")
        con.Close()
        cboMachineID.SelectedIndex = -1
    End Sub

    Public Sub LoadDepartmentID()
        cmd = New SqlCommand("SELECT * FROM Departments", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Departments")
        cboDepartmentID.DataSource = ds2.Tables("Departments")
        con.Close()
        cboDepartmentID.SelectedIndex = -1
    End Sub

    Public Sub LoadMachineClass()
        cmd = New SqlCommand("SELECT DISTINCT(MachineClass) FROM MachineTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "MachineTable")
        cboMachineClass.DataSource = ds3.Tables("MachineTable")
        con.Close()
        cboMachineClass.SelectedIndex = -1
    End Sub

    Public Sub LoadMachineData()
        Dim MachineDescription, MachineClass As String
        Dim MachineCostPerHour, MaxPiecesPerHour, MinDiameter, MaxDiameter, MinLength, MaxLength, Tonnage As Double

        Dim DescriptionStatement As String = "SELECT Description FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim DescriptionCommand As New SqlCommand(DescriptionStatement, con)
        DescriptionCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        DescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim MachineClassStatement As String = "SELECT MachineClass FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim MachineClassCommand As New SqlCommand(MachineClassStatement, con)
        MachineClassCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        MachineClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim MachineCostPerHourStatement As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim MachineCostPerHourCommand As New SqlCommand(MachineCostPerHourStatement, con)
        MachineCostPerHourCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        MachineCostPerHourCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim MaxPiecesPerHourStatement As String = "SELECT MaxPiecesPerHour FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim MaxPiecesPerHourCommand As New SqlCommand(MaxPiecesPerHourStatement, con)
        MaxPiecesPerHourCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        MaxPiecesPerHourCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim MinDiameterStatement As String = "SELECT MinDiameter FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim MinDiameterCommand As New SqlCommand(MinDiameterStatement, con)
        MinDiameterCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        MinDiameterCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim MaxDiameterStatement As String = "SELECT MaxDiameter FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim MaxDiameterCommand As New SqlCommand(MaxDiameterStatement, con)
        MaxDiameterCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        MaxDiameterCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim MinLengthStatement As String = "SELECT MinLength FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim MinLengthCommand As New SqlCommand(MinLengthStatement, con)
        MinLengthCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        MinLengthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim MaxLengthStatement As String = "SELECT MaxLength FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim MaxLengthCommand As New SqlCommand(MaxLengthStatement, con)
        MaxLengthCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        MaxLengthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TonnageStatement As String = "SELECT Tonnage FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
        Dim TonnageCommand As New SqlCommand(TonnageStatement, con)
        TonnageCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
        TonnageCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MachineDescription = CStr(DescriptionCommand.ExecuteScalar)
        Catch ex As System.Exception
            MachineDescription = ""
        End Try
        Try
            MachineClass = CStr(MachineClassCommand.ExecuteScalar)
        Catch ex As System.Exception
            MachineClass = ""
        End Try
        Try
            MachineCostPerHour = CDbl(MachineCostPerHourCommand.ExecuteScalar)
        Catch ex As System.Exception
            MachineCostPerHour = 0
        End Try
        Try
            MaxPiecesPerHour = CDbl(MaxPiecesPerHourCommand.ExecuteScalar)
        Catch ex As System.Exception
            MaxPiecesPerHour = 0
        End Try
        Try
            MinDiameter = CDbl(MinDiameterCommand.ExecuteScalar)
        Catch ex As System.Exception
            MinDiameter = 0
        End Try
        Try
            MaxDiameter = CDbl(MaxDiameterCommand.ExecuteScalar)
        Catch ex As System.Exception
            MaxDiameter = 0
        End Try
        Try
            MinLength = CDbl(MinLengthCommand.ExecuteScalar)
        Catch ex As System.Exception
            MinLength = 0
        End Try
        Try
            MaxLength = CDbl(MaxLengthCommand.ExecuteScalar)
        Catch ex As System.Exception
            MaxLength = 0
        End Try
        Try
            Tonnage = CDbl(TonnageCommand.ExecuteScalar)
        Catch ex As System.Exception
            Tonnage = 0
        End Try
        con.Close()

        txtMachineDescription.Text = MachineDescription
        cboMachineClass.Text = MachineClass
        txtMachineCost.Text = MachineCostPerHour
        txtMaxPiecesPerHour.Text = MaxPiecesPerHour
        txtMaxDiameter.Text = MaxDiameter
        txtMaxLength.Text = MaxLength
        txtMinDiameter.Text = MinDiameter
        txtMinLength.Text = MinLength
        txtTonnage.Text = Tonnage
    End Sub

    Public Sub LoadDepartmentData()
        Dim DepartmentNameStatement As String = "SELECT DepartmentName FROM Departments WHERE DepartmentID = @DepartmentID"
        Dim DepartmentNameCommand As New SqlCommand(DepartmentNameStatement, con)
        DepartmentNameCommand.Parameters.Add("@DepartmentID", SqlDbType.VarChar).Value = cboDepartmentID.Text

        Dim DepartmentDescriptionStatement As String = "SELECT DepartmentDescription FROM Departments WHERE DepartmentID = @DepartmentID"
        Dim DepartmentDescriptionCommand As New SqlCommand(DepartmentDescriptionStatement, con)
        DepartmentDescriptionCommand.Parameters.Add("@DepartmentID", SqlDbType.VarChar).Value = cboDepartmentID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DepartmentName = CStr(DepartmentNameCommand.ExecuteScalar)
        Catch ex As System.Exception
            DepartmentName = ""
        End Try
        Try
            DepartmentDescription = CStr(DepartmentDescriptionCommand.ExecuteScalar)
        Catch ex As System.Exception
            DepartmentDescription = ""
        End Try
        con.Close()

        txtDepartmentDescription.Text = DepartmentDescription
        txtDepartmentName.Text = DepartmentName
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub InsertIntoDatabase()
        'Insert into Database
        cmd = New SqlCommand("INSERT INTO MachineTable (MachineID, DivisionID, Description, MachineCostPerHour, MachineClass, MaxPiecesPerHour, MinDiameter, MaxDiameter, MinLength, MaxLength, Tonnage) values (@MachineID, @DivisionID, @Description, @MachineCostPerHour, @MachineClass, @MaxPiecesPerHour, @MinDiameter, @MaxDiameter, @MinLength, @MaxLength, @Tonnage)", con)

        With cmd.Parameters
            .Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            .Add("@Description", SqlDbType.VarChar).Value = txtMachineDescription.Text
            .Add("@MachineClass", SqlDbType.VarChar).Value = cboMachineClass.Text
            .Add("@MachineCostPerHour", SqlDbType.VarChar).Value = Val(txtMachineCost.Text)
            .Add("@MaxPiecesPerHour", SqlDbType.VarChar).Value = Val(txtMaxPiecesPerHour.Text)
            .Add("@MinDiameter", SqlDbType.VarChar).Value = Val(txtMinDiameter.Text)
            .Add("@MaxDiameter", SqlDbType.VarChar).Value = Val(txtMaxDiameter.Text)
            .Add("@MinLength", SqlDbType.VarChar).Value = Val(txtMinLength.Text)
            .Add("@MaxLength", SqlDbType.VarChar).Value = Val(txtMaxLength.Text)
            .Add("@Tonnage", SqlDbType.VarChar).Value = Val(txtTonnage.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateDatabase()
        'Update Database
        cmd = New SqlCommand("UPDATE MachineTable SET Description = @Description, MachineClass = @MachineClass, MachineCostPerHour = @MachineCostPerHour, MaxPiecesPerHour = @MaxPiecesPerHour, MinDiameter = @MinDiameter, MaxDiameter = @MaxDiameter, MinLength = @MinLength, MaxLength = @MaxLength, Tonnage = @Tonnage WHERE MachineID = @MachineID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@MachineID", SqlDbType.VarChar).Value = cboMachineID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            .Add("@Description", SqlDbType.VarChar).Value = txtMachineDescription.Text
            .Add("@MachineClass", SqlDbType.VarChar).Value = cboMachineClass.Text
            .Add("@MachineCostPerHour", SqlDbType.VarChar).Value = Val(txtMachineCost.Text)
            .Add("@MaxPiecesPerHour", SqlDbType.VarChar).Value = Val(txtMaxPiecesPerHour.Text)
            .Add("@MinDiameter", SqlDbType.VarChar).Value = Val(txtMinDiameter.Text)
            .Add("@MaxDiameter", SqlDbType.VarChar).Value = Val(txtMaxDiameter.Text)
            .Add("@MinLength", SqlDbType.VarChar).Value = Val(txtMinLength.Text)
            .Add("@MaxLength", SqlDbType.VarChar).Value = Val(txtMaxLength.Text)
            .Add("@Tonnage", SqlDbType.VarChar).Value = Val(txtTonnage.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ClearData()
        cboDepartmentID.SelectedIndex = -1
        cboMachineClass.SelectedIndex = -1
        cboMachineID.SelectedIndex = -1
        txtDepartmentDescription.Clear()
        txtDepartmentName.Clear()
        txtMachineCost.Clear()
        txtMachineDescription.Clear()
        txtMaxDiameter.Clear()
        txtMaxLength.Clear()
        txtMaxPiecesPerHour.Clear()
        txtMinDiameter.Clear()
        txtMinLength.Clear()
        txtTonnage.Clear()
    End Sub

    Private Sub cmdAddUpdateMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUpdateMachine.Click
        If canAddMachine() Then
            Try
                InsertIntoDatabase()
            Catch ex As Exception
                UpdateDatabase()
            End Try

            'Refresh Datagrid
            ShowData()
            LoadMachineID()

            'Clear Fields
            ClearData()

            MsgBox("Database has been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canAddMachine() As Boolean
        If String.IsNullOrEmpty(cboMachineID.Text) Then
            MessageBox.Show("You must enter a Machine ID", "Enter a machine ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtMachineDescription.Text) Then
            MessageBox.Show("You must enter a Machine Description", "Enter a Machine Description", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMachineDescription.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboMachineClass.Text) Then
            MessageBox.Show("You must enter a Machine Class", "Enter a Machine Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineClass.Focus()
        End If
        Return True
    End Function

    Private Function canAddDepartment() As Boolean
        If String.IsNullOrEmpty(cboDepartmentID.Text) Then
            MessageBox.Show("You must enter a Department ID", "Enter a Department ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDepartmentID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtDepartmentDescription.Text) Then
            MessageBox.Show("You must enter a Department Description", "Enter a Department Description", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDepartmentDescription.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboDivisionID.Text) Then
            MessageBox.Show("You must enter a Division ID", "Enter a Division ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDivisionID.Focus()
            Return False
        End If
        Return True
    End Function



    Private Sub cmdClear1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear1.Click
        ClearData()
    End Sub

    Private Sub cmdClear2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear2.Click
        ClearData()
    End Sub

    Private Sub cboMachineID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineID.SelectedIndexChanged
        If cboMachineID.Text <> "" Then
            LoadMachineData()
        End If
    End Sub

    Private Sub cboDepartmentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartmentID.SelectedIndexChanged
        LoadDepartmentData()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim newPrintMachineList As New PrintMachineList(ds1)
        newPrintMachineList.ShowDialog()
    End Sub

End Class