Imports System.Data.SqlClient

Public Class NotificationEdit
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim NotificaitonKey As Integer
    Dim Notification As NotificationAPI

    Public Sub New()
        InitializeComponent()
        Notification = New NotificationAPI()
    End Sub
    Public Sub New(ByVal dt As System.Data.DataTable, ByVal rowNumber As Integer)
        InitializeComponent()
        LoadDivisions()
        LoadEmployees()
        If con.State = ConnectionState.Open Then con.Close()

        Notification = New NotificationAPI(New NotificationAPI.NotificationData(dt.Rows(rowNumber), dt.Columns))
        NotificaitonKey = Notification.Data(0).NotificationKey
        cboDivisionID.Text = Notification.Data(0).Division
        cboEmployee.Text = Notification.Data(0).EmployeeName
        cboNotificationType.Text = Notification.Data(0).NotificationType
        txtReferenceNumber.Text = Notification.Data(0).ReferenceNumber
        dtpNotificationDate.Value = Notification.Data(0).NotificationDateTime.Date
        dtpTime.Value = Notification.Data(0).NotificationDateTime
        txtDetails.Text = Notification.Data(0).Details
    End Sub

    Public Sub New(ByVal passedNotification As NotificationAPI.NotificationData)
        InitializeComponent()
        LoadDivisions()
        LoadEmployees()
        If con.State = ConnectionState.Open Then con.Close()

        Notification = New NotificationAPI(passedNotification)
        NotificaitonKey = Notification.Data(0).NotificationKey
        cboDivisionID.Text = Notification.Data(0).Division
        cboEmployee.Text = Notification.Data(0).EmployeeName
        cboNotificationType.Text = Notification.Data(0).NotificationType
        txtReferenceNumber.Text = Notification.Data(0).ReferenceNumber
        dtpNotificationDate.Value = Notification.Data(0).NotificationDateTime.Date
        dtpTime.Value = Notification.Data(0).NotificationDateTime
        txtDetails.Text = Notification.Data(0).Details
    End Sub

    Private Sub LoadDivisions()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("DivisionKey")) Then
                    cboDivisionID.Items.Add(reader.Item("DivisionKey"))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadEmployees()
        cmd = New SqlCommand("SELECT EmployeeFirst + ' ' + EmployeeLast as EmployeeName FROM EmployeeData", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("EmployeeName")) Then
                    cboEmployee.Items.Add(reader.Item("EmployeeName"))
                End If
            End While
        End If
        reader.Close()
        cmd.CommandText += " WHERE LoginName = @EmployeeLoginName"
        cmd.Parameters.Add("@EmployeeLoginName", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("EmployeeName")) Then
                    cboEmployee.Text = reader.Item("EmployeeName")
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadSecurity()
        If EmployeeSecurityCode <= 1002 Then
            cboDivisionID.Enabled = True
            cboEmployee.Enabled = True
        ElseIf EmployeeSecurityCode = 1003 Then
            cboDivisionID.Enabled = True
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If canUpdate() Then
            Notification.Data(0).Division = cboDivisionID.Text
            Notification.Data(0).EmployeeName = cboEmployee.Text
            Notification.Data(0).ReferenceNumber = txtReferenceNumber.Text
            Notification.Data(0).NotificationType = cboNotificationType.Text
            Notification.Data(0).Details = txtDetails.Text
            Notification.Data(0).NotificationDateTime = New DateTime(dtpNotificationDate.Value.Year, dtpNotificationDate.Value.Month, dtpNotificationDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, 0)
            Notification.UpdateNotification()
            'cmd = New SqlCommand("UPDATE NotificationTable SET DivisionID = @DivisionID, EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst = @EmployeeFirst AND EmployeeLast = @EmployeeLast), NotificationType = @NotificationType, ReferenceNumber = @ReferenceNumber, NotificationDateTime = @NotificationDateTime, Details = @Details, SnoozeTime = @NotificationDateTime WHERE NotificationKey = @NotificationKey", con)
            'With cmd.Parameters
            '    .Add("@NotificationKey", SqlDbType.Int).Value = NotificaitonKey
            '    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            '    .Add("@EmployeeFirst", SqlDbType.VarChar).Value = cboEmployee.Text.Substring(0, cboEmployee.Text.IndexOf(" "))
            '    .Add("@EmployeeLast", SqlDbType.VarChar).Value = cboEmployee.Text.Substring(cboEmployee.Text.IndexOf(" ") + 1, cboEmployee.Text.Length - (cboEmployee.Text.IndexOf(" ") + 1))
            '    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
            '    .Add("@NotificationType", SqlDbType.VarChar).Value = cboNotificationType.Text
            '    .Add("@NotificationDateTime", SqlDbType.DateTime).Value = New DateTime(dtpNotificationDate.Value.Year, dtpNotificationDate.Value.Month, dtpNotificationDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, 0)
            '    .Add("@Details", SqlDbType.VarChar).Value = txtDetails.Text
            'End With

            'If con.State = ConnectionState.Closed Then con.Open()
            'cmd.ExecuteNonQuery()
            'con.Close()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function canUpdate() As Boolean
        If String.IsNullOrEmpty(cboDivisionID.Text) Then
            MessageBox.Show("You must select a Division ID", "Select a Division ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDivisionID.Focus()
            Return False
        End If
        If cboDivisionID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Divison ID", "Enter a valid DivisonID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDivisionID.SelectAll()
            cboDivisionID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboEmployee.Text) Then
            MessageBox.Show("You must select an Employee", "Select an Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmployee.Focus()
            Return False
        End If
        If cboEmployee.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Employee", "Enter a valid Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmployee.SelectAll()
            cboEmployee.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboNotificationType.Text) Then
            MessageBox.Show("You must enter a Notification Type", "Enter a Notification Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboNotificationType.Focus()
            Return False
        End If
        If cboNotificationType.Text.Equals("Recurring Invoice") Then
            ''check to see if details contains proper start position
            If Not txtDetails.Text.Contains("Part Number(s): ") Then
                MessageBox.Show("Details section must contain [Part Number(s): ] or it will not function properly with the create invoice button.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            Dim PartNumbers As String = txtDetails.Text.Substring(txtDetails.Text.IndexOf("Part Number(s): ") + 16)
            If PartNumbers.Contains(Environment.NewLine) Then
                PartNumbers = PartNumbers.Substring(0, PartNumbers.IndexOf(Environment.NewLine))
            End If

            Dim spl As String() = PartNumbers.Split(New String() {", "}, StringSplitOptions.RemoveEmptyEntries)
            ''check to make sure there is at least 1 part number entered
            If spl.Count = 0 Then
                MessageBox.Show("Part or parts associated with the recurring invoice must be entered after [Part Number(s): ] with a [, ] seperating them.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cboEmployee_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEmployee.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub cboDivisionID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDivisionID.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub
End Class