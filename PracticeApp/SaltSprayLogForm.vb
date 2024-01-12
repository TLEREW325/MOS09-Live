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
Public Class SaltSprayLogForm
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub SaltSprayLogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDivisionID.Text = EmployeeCompanyCode
        txtUserID.Text = EmployeeLoginName

        LoadSaltSprayNumber()

        ShowData()
    End Sub

    Public Sub LoadSaltSprayData()
        Dim SaltSprayDate, SaltSprayTime, TemperatureDry, TemperatureWet, CentralCollect, CornerCollect, PHRange, TowerTemperature, TowerPressure, Comments, DivisionID, UserID As String

        Dim LoadSaltSprayDataStatement As String = "SELECT * FROM SaltSprayLog WHERE SaltSprayID = @SaltSprayID"
        Dim LoadSaltSprayDataCommand As New SqlCommand(LoadSaltSprayDataStatement, con)
        LoadSaltSprayDataCommand.Parameters.Add("@SaltSprayID", SqlDbType.VarChar).Value = Val(cboSaltSprayID.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadSaltSprayDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SaltSprayDate")) Then
                SaltSprayDate = ""
            Else
                SaltSprayDate = reader.Item("SaltSprayDate")
            End If
            If IsDBNull(reader.Item("SaltSprayTime")) Then
                SaltSprayTime = ""
            Else
                SaltSprayTime = reader.Item("SaltSprayTime")
            End If
            If IsDBNull(reader.Item("TemperatureDry")) Then
                TemperatureDry = ""
            Else
                TemperatureDry = reader.Item("TemperatureDry")
            End If
            If IsDBNull(reader.Item("TemperatureWet")) Then
                TemperatureWet = ""
            Else
                TemperatureWet = reader.Item("TemperatureWet")
            End If
            If IsDBNull(reader.Item("CentralCollect")) Then
                CentralCollect = ""
            Else
                CentralCollect = reader.Item("CentralCollect")
            End If
            If IsDBNull(reader.Item("CornerCollect")) Then
                CornerCollect = ""
            Else
                CornerCollect = reader.Item("CornerCollect")
            End If
            If IsDBNull(reader.Item("PHRange")) Then
                PHRange = ""
            Else
                PHRange = reader.Item("PHRange")
            End If
            If IsDBNull(reader.Item("TowerTemperature")) Then
                TowerTemperature = ""
            Else
                TowerTemperature = reader.Item("TowerTemperature")
            End If
            If IsDBNull(reader.Item("TowerPressure")) Then
                TowerPressure = ""
            Else
                TowerPressure = reader.Item("TowerPressure")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                Comments = ""
            Else
                Comments = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                DivisionID = ""
            Else
                DivisionID = reader.Item("DivisionID")
            End If
            If IsDBNull(reader.Item("UserID")) Then
                UserID = ""
            Else
                UserID = reader.Item("UserID")
            End If
        Else
            SaltSprayDate = ""
            SaltSprayTime = ""
            TemperatureDry = ""
            TemperatureWet = ""
            CentralCollect = ""
            CornerCollect = ""
            PHRange = ""
            TowerTemperature = ""
            TowerPressure = ""
            Comments = ""
            DivisionID = "TWD"
            UserID = EmployeeLoginName
        End If
        reader.Close()
        con.Close()

        txtCentralCollect.Text = CentralCollect
        txtComments.Text = Comments
        txtCornerCollect.Text = CornerCollect
        txtLogTime.Text = SaltSprayTime
        txtPHRange.Text = PHRange
        txtTemperatureDry.Text = TemperatureDry
        txtTemperatureWet.Text = TemperatureWet
        txtTowerPressure.Text = TowerPressure
        txtTowerTemperature.Text = TowerTemperature
        txtUserID.Text = UserID
        txtDivisionID.Text = DivisionID
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM SaltSprayLog WHERE DivisionID = @DivisionID ORDER BY SaltSprayID DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SaltSprayLog")
        dgvSaltSprayLog.DataSource = ds.Tables("SaltSprayLog")
        con.Close()
    End Sub

    Public Sub LoadSaltSprayNumber()
        cmd = New SqlCommand("SELECT SaltSprayID FROM SaltSprayLog ORDER BY SaltSprayID DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SaltSprayLog")
        cboSaltSprayID.DataSource = ds1.Tables("SaltSprayLog")
        con.Close()
        cboSaltSprayID.SelectedIndex = -1
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvSaltSprayLog.DataSource = Nothing
    End Sub

    Public Sub InsertIntoSaltSprayLog()
        Try
            'Insert into Database
            cmd = New SqlCommand("INSERT INTO SaltSprayLog (SaltSprayID, SaltSprayDate, SaltSprayTime, TemperatureDry, TemperatureWet, CentralCollect, CornerCollect, PHRange, TowerTemperature, TowerPressure, Comments, DivisionID, UserID) values (@SaltSprayID, @SaltSprayDate, @SaltSprayTime, @TemperatureDry, @TemperatureWet, @CentralCollect, @CornerCollect, @PHRange, @TowerTemperature, @TowerPressure, @Comments, @DivisionID, @UserID)", con)

            With cmd.Parameters
                .Add("@SaltSprayID", SqlDbType.VarChar).Value = Val(cboSaltSprayID.Text)
                .Add("@SaltSprayDate", SqlDbType.VarChar).Value = dtpLogDate.Text
                .Add("@SaltSprayTime", SqlDbType.VarChar).Value = txtLogTime.Text
                .Add("@TemperatureDry", SqlDbType.VarChar).Value = txtTemperatureDry.Text
                .Add("@TemperatureWet", SqlDbType.VarChar).Value = txtTemperatureWet.Text
                .Add("@CentralCollect", SqlDbType.VarChar).Value = txtCentralCollect.Text
                .Add("@CornerCollect", SqlDbType.VarChar).Value = txtCornerCollect.Text
                .Add("@PHRange", SqlDbType.VarChar).Value = txtPHRange.Text
                .Add("@TowerTemperature", SqlDbType.VarChar).Value = txtTowerTemperature.Text
                .Add("@TowerPressure", SqlDbType.VarChar).Value = txtTowerPressure.Text
                .Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                .Add("@UserID", SqlDbType.VarChar).Value = txtUserID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorDescription = "Salt Spray Form"
            ErrorUser = EmployeeLoginName
            ErrorComment = "Error on Insert into database"
            ErrorDivision = EmployeeCompanyCode
            ErrorReferenceNumber = cboSaltSprayID.Text

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub UpdateSaltSprayLog()
        Try
            'Update Database
            cmd = New SqlCommand("UPDATE SaltSprayLog SET SaltSprayDate = @SaltSprayDate, SaltSprayTime = @SaltSprayTime, TemperatureDry = @TemperatureDry, TemperatureWet = @TemperatureWet, CentralCollect = @CentralCollect, CornerCollect = @CornerCollect, PHRange = @PHRange, TowerTemperature = @TowerTemperature, TowerPressure = @TowerPressure, Comments = @Comments, DivisionID = @DivisionID, UserID = @UserID WHERE SaltSprayID = @SaltSprayID", con)

            With cmd.Parameters
                .Add("@SaltSprayID", SqlDbType.VarChar).Value = Val(cboSaltSprayID.Text)
                .Add("@SaltSprayDate", SqlDbType.VarChar).Value = dtpLogDate.Text
                .Add("@SaltSprayTime", SqlDbType.VarChar).Value = txtLogTime.Text
                .Add("@TemperatureDry", SqlDbType.VarChar).Value = txtTemperatureDry.Text
                .Add("@TemperatureWet", SqlDbType.VarChar).Value = txtTemperatureWet.Text
                .Add("@CentralCollect", SqlDbType.VarChar).Value = txtCentralCollect.Text
                .Add("@CornerCollect", SqlDbType.VarChar).Value = txtCornerCollect.Text
                .Add("@PHRange", SqlDbType.VarChar).Value = txtPHRange.Text
                .Add("@TowerTemperature", SqlDbType.VarChar).Value = txtTowerTemperature.Text
                .Add("@TowerPressure", SqlDbType.VarChar).Value = txtTowerPressure.Text
                .Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                .Add("@UserID", SqlDbType.VarChar).Value = txtUserID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            ErrorDate = Today()
            ErrorDescription = "Salt Spray Form"
            ErrorUser = EmployeeLoginName
            ErrorComment = "Error on Update database"
            ErrorDivision = EmployeeCompanyCode
            ErrorReferenceNumber = cboSaltSprayID.Text

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub DeleteSaltSprayLog()
        If cboSaltSprayID.Text <> "" Then
            Try
                'Delete Record
                cmd = New SqlCommand("DELETE FROM SaltSprayLog WHERE SaltSprayID = @SaltSprayID", con)

                With cmd.Parameters
                    .Add("@SaltSprayID", SqlDbType.VarChar).Value = Val(cboSaltSprayID.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ClearData()
                ClearVariables()
                ShowData()

                MsgBox("Record has been deleted.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorDescription = "Salt Spray Form"
                ErrorUser = EmployeeLoginName
                ErrorComment = "Error on delete into database"
                ErrorDivision = EmployeeCompanyCode
                ErrorReferenceNumber = cboSaltSprayID.Text

                TFPErrorLogUpdate()
            End Try
        Else
            MsgBox("You must have a valid Salt Spray number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Public Sub ClearData()
        txtCentralCollect.Clear()
        txtComments.Clear()
        txtCornerCollect.Clear()
        txtLogTime.Clear()
        txtPHRange.Clear()
        txtTemperatureDry.Clear()
        txtTemperatureWet.Clear()
        txtTowerPressure.Clear()
        txtTowerTemperature.Clear()
        txtUserID.Clear()
        txtDivisionID.Clear()

        cboSaltSprayID.Text = ""
        cboSaltSprayID.SelectedIndex = -1

        cboSaltSprayID.Focus()
    End Sub

    Public Sub ClearVariables()

    End Sub

    Private Sub cmdAddData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddData.Click
        If cboSaltSprayID.Text <> "" Then
            UpdateSaltSprayLog()
            ShowData()
        Else
            MsgBox("You must have a valid salt spray number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
    End Sub

    Private Sub cboSaltSprayID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSaltSprayID.SelectedIndexChanged
        If cboSaltSprayID.Text = "" Then
            ClearData()
        Else
            LoadSaltSprayData()
        End If
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        'Get new number and enter into combo box
        Dim NextSaltSprayNumber, LastSaltSprayNumber As Integer

        Dim LastSaltSprayNumberStatement As String = "SELECT MAX(SaltSprayID) FROM SaltSprayLog"
        Dim LastSaltSprayNumberCommand As New SqlCommand(LastSaltSprayNumberStatement, con)
   
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastSaltSprayNumber = CInt(LastSaltSprayNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastSaltSprayNumber = 440000
        End Try
        con.Close()

        NextSaltSprayNumber = LastSaltSprayNumber + 1
        cboSaltSprayID.Text = NextSaltSprayNumber

        'Enter into database
        InsertIntoSaltSprayLog()
    End Sub

    Private Sub dgvSaltSprayLog_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSaltSprayLog.CellValueChanged
        If Me.dgvSaltSprayLog.RowCount > 0 Then
            Dim RowSaltSprayNumber As Integer = 0
            Dim RowSaltSprayDate As String = ""
            Dim RowSaltSprayTime As String = ""
            Dim RowTemperatureDry As String = ""
            Dim RowTemperatureWet As String = ""
            Dim RowCentralCollect As String = ""
            Dim RowCornerCollect As String = ""
            Dim RowPHRange As String = ""
            Dim RowTowerTemperature As String = ""
            Dim RowTowerPressure As String = ""
            Dim RowComments As String = ""

            Dim RowIndex As Integer = Me.dgvSaltSprayLog.CurrentCell.RowIndex

            RowSaltSprayNumber = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("SaltSprayIDColumn").Value
            RowSaltSprayDate = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("SaltSprayDateColumn").Value
            RowSaltSprayTime = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("SaltSprayTimeColumn").Value
            RowTemperatureDry = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("TemperatureDryColumn").Value
            RowTemperatureWet = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("TemperatureWetColumn").Value
            RowCentralCollect = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("CentralCollectColumn").Value
            RowCornerCollect = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("CornerCollectColumn").Value
            RowPHRange = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("PHRangeColumn").Value
            RowTowerTemperature = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("TowerTemperatureColumn").Value
            RowTowerPressure = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("TowerPressureColumn").Value
            RowComments = Me.dgvSaltSprayLog.Rows(RowIndex).Cells("CommentsColumn").Value

            Try
                'Insert into Database
                cmd = New SqlCommand("UPDATE SaltSprayLog SET SaltSprayDate = @SaltSprayDate, SaltSprayTime = @SaltSprayTime, TemperatureDry = @TemperatureDry, TemperatureWet = @TemperatureWet, CentralCollect = @CentralCollect, CornerCollect = @CornerCollect, PHRange = @PHRange, TowerTemperature = @TowerTemperature, TowerPressure = @TowerPressure, Comments = @Comments WHERE SaltSprayID = @SaltSprayID", con)

                With cmd.Parameters
                    .Add("@SaltSprayID", SqlDbType.VarChar).Value = RowSaltSprayNumber
                    .Add("@SaltSprayDate", SqlDbType.VarChar).Value = RowSaltSprayDate
                    .Add("@SaltSprayTime", SqlDbType.VarChar).Value = RowSaltSprayTime
                    .Add("@TemperatureDry", SqlDbType.VarChar).Value = RowTemperatureDry
                    .Add("@TemperatureWet", SqlDbType.VarChar).Value = RowTemperatureWet
                    .Add("@CentralCollect", SqlDbType.VarChar).Value = RowCentralCollect
                    .Add("@CornerCollect", SqlDbType.VarChar).Value = RowCornerCollect
                    .Add("@PHRange", SqlDbType.VarChar).Value = RowPHRange
                    .Add("@TowerTemperature", SqlDbType.VarChar).Value = RowTowerTemperature
                    .Add("@TowerPressure", SqlDbType.VarChar).Value = RowTowerPressure
                    .Add("@Comments", SqlDbType.VarChar).Value = RowComments
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
                ErrorDate = Today()
                ErrorDescription = "Salt Spray Form"
                ErrorUser = EmployeeLoginName
                ErrorComment = "Error on update from datagrid"
                ErrorDivision = EmployeeCompanyCode
                ErrorReferenceNumber = cboSaltSprayID.Text

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        DeleteSaltSprayLog()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

    End Sub
End Class