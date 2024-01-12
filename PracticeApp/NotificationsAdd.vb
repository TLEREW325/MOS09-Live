Imports System.Data.SqlClient

Public Class NotificationsAdd
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Public Sub New()
        InitializeComponent()

        LoadDivisions()
        LoadEmployees()
        If con.State = ConnectionState.Open Then con.Close()

        cboDivisionID.Text = EmployeeCompanyCode

        dtpTime.Text = "08:00 AM"
        cboFrequency.Text = "Only Once"
        LoadSecurity()
    End Sub

    Public Sub New(ByVal startDate As Date)
        InitializeComponent()

        'Starting from SOForm, if rental is on sales order then the following happens
        '--------------------------------------
        If GlobalVariables.paperscan = True Then
            txtDetails.Text = GlobalNaftaCustomerID + Environment.NewLine + GlobalVariables.stringVar + Environment.NewLine + GlobalVariables.stringVar2 + Environment.NewLine
            dtpTime.Text = "11:00 AM"
            '--------------------------------------
        Else
            dtpTime.Text = "08:00 AM"
        End If

        LoadDivisions()
        LoadEmployees()
        If con.State = ConnectionState.Open Then con.Close()

        cboDivisionID.Text = EmployeeCompanyCode


        dtpStartingDate.Value = startDate
        dtpEndingDate.Value = startDate
        cboFrequency.Text = "Only Once"
        LoadSecurity()
    End Sub

    Private Sub LoadSecurity()
        If EmployeeSecurityCode <= 1002 Then
            cboDivisionID.Enabled = True
            cboEmployee.Enabled = True
        ElseIf EmployeeSecurityCode = 1003 Then
            cboDivisionID.Enabled = True
        End If
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

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        GlobalVariables.paperscan = False
        GlobalVariables.stringVar = ""
        GlobalVariables.stringVar2 = ""
        GlobalNaftaCustomerID = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If canAdd() Then
            GlobalVariables.paperscan = False
            GlobalVariables.stringVar = ""
            GlobalVariables.stringVar2 = ""
            GlobalNaftaCustomerID = ""
            Dim notification As New NotificationAPI(New NotificationAPI.NotificationData(0, cboDivisionID.Text, cboEmployee.Text, txtReferenceNumber.Text, cboNotificationType.Text, cboFrequency.Text, New DateTime(dtpStartingDate.Value.Year, dtpStartingDate.Value.Month, dtpStartingDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, 0), txtDetails.Text, "ACTIVE", EmployeeLoginName, 0))
            notification.Data().EndDateTime = dtpEndingDate.Value
            notification.AddNotification()
            Me.Close()
        End If
    End Sub

    Private Function canAdd() As Boolean
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
        If String.IsNullOrEmpty(cboFrequency.Text) Then
            MessageBox.Show("You must select a Frequency", "Select a Frequency", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFrequency.Focus()
            Return False
        End If
        If cboFrequency.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Frequency", "Enter a valid Frequency", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFrequency.SelectAll()
            cboFrequency.Focus()
            Return False
        End If
        If DateDiff(DateInterval.Day, dtpStartingDate.Value, dtpEndingDate.Value) < 0 Then
            MessageBox.Show("Starting date must come before ending date", "incorrect dates", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpStartingDate.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cboEmployee_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEmployee.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub cboDivisionID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDivisionID.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged

    End Sub

End Class