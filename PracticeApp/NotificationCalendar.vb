Imports System.Data.SqlClient

Public Class NotificationCalendar
    Dim Dates As Dictionary(Of Date, List(Of Notifications))
    Private Class Notifications
        Public NotificationType As String
        Public NotificationCount As Integer
        Public Sub New()
            NotificationType = ""
            NotificationCount = 0
        End Sub
        Public Sub New(ByVal NotType As String, ByVal NotCount As Integer)
            NotificationType = NotType
            NotificationCount = NotCount
        End Sub
    End Class

    Dim cmsDGVCalendar As New ContextMenu()
    Dim newAddNotifications As NotificationsAdd
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Dim isLoaded As Boolean = False

    Public Sub New()
        InitializeComponent()
        cmsDGVCalendar.MenuItems.Add("Add Notification", AddressOf AddNotifications)
        cmsDGVCalendar.MenuItems.Add("Show Notifications", AddressOf ShowNotifications)

        LoadSecurity()
        LoadDivisions()
        LoadEmployees()
        If con.State = ConnectionState.Open Then con.Close()
        cboDivisionID.Text = EmployeeCompanyCode
        UpdateCalendar(Today.Date)
    End Sub

    Public Sub New(ByVal inputDate As Date)
        InitializeComponent()
        cmsDGVCalendar.MenuItems.Add("Add Notification", AddressOf AddNotifications)
        cmsDGVCalendar.MenuItems.Add("Show Notifications", AddressOf ShowNotifications)

        LoadSecurity()
        LoadDivisions()
        LoadEmployees()
        If con.State = ConnectionState.Open Then con.Close()
        cboDivisionID.Text = EmployeeCompanyCode
        UpdateCalendar(inputDate)
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

    Private Sub UpdateCalendar(ByVal newDate As Date)
        cmd = New SqlCommand("SELECT COUNT(NotificationType) as NotificationCount, NotificationType, CAST(NotificationDateTime as date) as 'NotificationDate' FROM NotificationTable WHERE CAST(NotificationDateTime as date) BETWEEN @BeginDate AND @EndDate", con)
        cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = New Date(newDate.Year, newDate.Month, 1)
        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = New Date(newDate.Year, newDate.Month, newDate.AddMonths(1).AddDays(-1 * newDate.Day).Day)

        If Not String.IsNullOrEmpty(cboDivisionID.Text) Then
            If Not cboDivisionID.Text.Equals("ADM") Then
                If Not String.IsNullOrEmpty(cboEmployee.Text) Then
                    If cboEmployee.Text.Contains(" ") Then
                        cmd.CommandText += " AND DivisionID = @DivisionID AND EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst = @EmployeeFirst AND EmployeeLast = @EmployeeLast)"
                        cmd.Parameters.Add("@EmployeeFirst", SqlDbType.VarChar).Value = cboEmployee.Text.Substring(0, cboEmployee.Text.IndexOf(" "))
                        cmd.Parameters.Add("@EmployeeLast", SqlDbType.VarChar).Value = cboEmployee.Text.Substring(cboEmployee.Text.IndexOf(" ") + 1, cboEmployee.Text.Length - (cboEmployee.Text.IndexOf(" ") + 1))
                    Else
                        cmd.CommandText += " AND DivisionID = @DivisionID AND EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst Like @Employee OR EmployeeLast Like @Employee)"
                        cmd.Parameters.Add("@Employee", SqlDbType.VarChar).Value = "%" + cboEmployee.Text + "%"
                    End If
                Else
                    cmd.CommandText += " AND DivisionID = @DivisionID"
                End If
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End If
        ElseIf Not String.IsNullOrEmpty(cboEmployee.Text) Then
            If cboEmployee.Text.Contains(" ") Then
                cmd.CommandText += " AND EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst = @EmployeeFirst AND EmployeeLast = @EmployeeLast)"
                cmd.Parameters.Add("@EmployeeFirst", SqlDbType.VarChar).Value = cboEmployee.Text.Substring(0, cboEmployee.Text.IndexOf(" "))
                cmd.Parameters.Add("@EmployeeLast", SqlDbType.VarChar).Value = cboEmployee.Text.Substring(cboEmployee.Text.IndexOf(" ") + 1, cboEmployee.Text.Length - (cboEmployee.Text.IndexOf(" ") + 1))
            Else
                cmd.CommandText += " AND EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst Like @Employee OR EmployeeLast Like @Employee)"
                cmd.Parameters.Add("@Employee", SqlDbType.VarChar).Value = "%" + cboEmployee.Text + "%"
            End If
        End If

        cmd.CommandText += " GROUP BY NotificationDateTime, NotificationType ORDER BY NotificationDateTime"

        Dates = New Dictionary(Of Date, List(Of Notifications))

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Dates.ContainsKey(reader.Item("NotificationDate")) Then
                    Dates(reader.Item("NotificationDate")).Add(New Notifications(reader.Item("NotificationType"), reader.Item("NotificationCount")))
                Else
                    Dates.Add(reader.Item("NotificationDate"), New List(Of Notifications))
                    Dates(reader.Item("NotificationDate")).Add(New Notifications(reader.Item("NotificationType"), reader.Item("NotificationCount")))
                End If
            End While
        End If
        reader.Close()
        con.Close()

        Dim rowIndex As Integer = 0
        Dim colIndex As Integer = 0

        dgvCalendar.Rows.Clear()
        dgvCalendar.Columns.Clear()
        dgvCalendar.Columns.Add("Sunday", "Sunday")
        dgvCalendar.Columns.Add("Monday", "Monday")
        dgvCalendar.Columns.Add("Tuesday", "Tuesday")
        dgvCalendar.Columns.Add("Wednesday", "Wednesday")
        dgvCalendar.Columns.Add("Thursday", "Thursday")
        dgvCalendar.Columns.Add("Friday", "Friday")
        dgvCalendar.Columns.Add("Saturday", "Saturday")

        Dim i As Integer = 0
        While i < dgvCalendar.Columns.Count
            dgvCalendar.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            i += 1
        End While

        Dim currentDate As New Date(newDate.Year, newDate.Month, 1)
        ''finds what column the month starts in and will adjust the first row accordingly
        Select Case currentDate.DayOfWeek().ToString()
            Case "Sunday"
                dgvCalendar.Rows.Add(currentDate.Day.ToString, (currentDate.Day + 1).ToString(), (currentDate.Day + 2).ToString(), (currentDate.Day + 3).ToString(), (currentDate.Day + 4).ToString(), (currentDate.Day + 5).ToString(), (currentDate.Day + 6).ToString())
                currentDate = currentDate.AddDays(6)
            Case "Monday"
                dgvCalendar.Rows.Add("", (currentDate.Day).ToString(), (currentDate.Day + 1).ToString(), (currentDate.Day + 2).ToString(), (currentDate.Day + 3).ToString(), (currentDate.Day + 4).ToString(), (currentDate.Day + 5).ToString())
                If DateDiff(DateInterval.Day, currentDate, newDate) = 0 Then
                    colIndex = 1
                End If
                currentDate = currentDate.AddDays(5)
            Case "Tuesday"
                dgvCalendar.Rows.Add("", "", (currentDate.Day).ToString(), (currentDate.Day + 1).ToString(), (currentDate.Day + 2).ToString(), (currentDate.Day + 3).ToString(), (currentDate.Day + 4).ToString())
                If DateDiff(DateInterval.Day, currentDate, newDate) = 0 Then
                    colIndex = 2
                End If
                currentDate = currentDate.AddDays(4)
            Case "Wednesday"
                dgvCalendar.Rows.Add("", "", "", (currentDate.Day).ToString(), (currentDate.Day + 1).ToString(), (currentDate.Day + 2).ToString(), (currentDate.Day + 3).ToString())
                If DateDiff(DateInterval.Day, currentDate, newDate) = 0 Then
                    colIndex = 3
                End If
                currentDate = currentDate.AddDays(3)
            Case "Thursday"
                dgvCalendar.Rows.Add("", "", "", "", (currentDate.Day).ToString(), (currentDate.Day + 1).ToString(), (currentDate.Day + 2).ToString())
                If DateDiff(DateInterval.Day, currentDate, newDate) = 0 Then
                    colIndex = 4
                End If
                currentDate = currentDate.AddDays(2)
            Case "Friday"
                dgvCalendar.Rows.Add("", "", "", "", "", (currentDate.Day).ToString(), (currentDate.Day + 1).ToString())
                If DateDiff(DateInterval.Day, currentDate, newDate) = 0 Then
                    colIndex = 5
                End If
                currentDate = currentDate.AddDays(1)
            Case "Saturday"
                dgvCalendar.Rows.Add("", "", "", "", "", "", (currentDate.Day).ToString())
                If DateDiff(DateInterval.Day, currentDate, newDate) = 0 Then
                    colIndex = 6
                End If
        End Select
        ''adds the text to the first row
        If Dates.Count > 0 Then
            Dim firstDate As Integer = DateDiff(DateInterval.Day, currentDate, Dates.Keys(0))
            While firstDate <= 0
                While Dates(Dates.Keys(0)).Count > 0
                    dgvCalendar.Rows(0).Cells(6 + firstDate).Value += Environment.NewLine + Dates(Dates.Keys(0))(0).NotificationCount.ToString() + " - " + Dates(Dates.Keys(0))(0).NotificationType
                    Dates(Dates.Keys(0)).RemoveAt(0)
                End While
                Dates.Remove(Dates.Keys(0))
                If Dates.Count > 0 Then
                    firstDate = DateDiff(DateInterval.Day, currentDate, Dates.Keys(0))
                Else
                    firstDate = 1
                End If
            End While
        End If
        currentDate = currentDate.AddDays(1)
        '' adjusts height and increments the row counter
        dgvCalendar.Rows(dgvCalendar.RowCount - 1).Height = 100
        Dim rowCount As Integer = 1
        ''while we are not on the within the last 7 days adds a row then adds entries
        While currentDate.AddDays(7).Month = newDate.Month
            Dim daysleft As Integer = DateDiff(DateInterval.Day, currentDate, newDate)
            If daysleft < 7 And daysleft >= 0 Then
                rowIndex = rowCount
                colIndex = daysleft
            End If
            dgvCalendar.Rows.Add(currentDate.Day.ToString, (currentDate.Day + 1).ToString(), (currentDate.Day + 2).ToString(), (currentDate.Day + 3).ToString(), (currentDate.Day + 4).ToString(), (currentDate.Day + 5).ToString(), (currentDate.Day + 6).ToString())
            dgvCalendar.Rows(dgvCalendar.RowCount - 1).Height = 100

            currentDate = currentDate.AddDays(6)
            If Dates.Count > 0 Then
                Dim firstDate As Integer = DateDiff(DateInterval.Day, currentDate, Dates.Keys(0))
                While firstDate <= 0
                    While Dates(Dates.Keys(0)).Count > 0
                        dgvCalendar.Rows(rowCount).Cells(6 + firstDate).Value += Environment.NewLine + Dates(Dates.Keys(0))(0).NotificationCount.ToString() + " - " + Dates(Dates.Keys(0))(0).NotificationType
                        Dates(Dates.Keys(0)).RemoveAt(0)
                    End While
                    Dates.Remove(Dates.Keys(0))
                    If Dates.Count > 0 Then
                        firstDate = DateDiff(DateInterval.Day, currentDate, Dates.Keys(0))
                    Else
                        firstDate = 1
                    End If
                End While
            End If
            currentDate = currentDate.AddDays(1)
            rowCount += 1
        End While
        Dim daycount As Integer = 1
        dgvCalendar.Rows.Add(currentDate.Day.ToString())
        dgvCalendar.Rows(dgvCalendar.RowCount - 1).Height = 100

        ''adds the last week
        While currentDate.Month = newDate.Month
            dgvCalendar.Rows(dgvCalendar.RowCount - 1).Cells(daycount - 1).Value = currentDate.Day.ToString()
            If Dates.Count > 0 Then
                If Dates.ContainsKey(currentDate.Date) Then
                    While Dates.ContainsKey(currentDate.Date)
                        While Dates(Dates.Keys(0)).Count > 0
                            dgvCalendar.Rows(rowCount).Cells(daycount - 1).Value += Environment.NewLine + Dates(Dates.Keys(0))(0).NotificationCount.ToString() + " - " + Dates(Dates.Keys(0))(0).NotificationType
                            Dates(Dates.Keys(0)).RemoveAt(0)
                        End While
                        Dates.Remove(Dates.Keys(0))
                    End While
                End If
            End If
            currentDate = currentDate.AddDays(1)
            daycount += 1
        End While
        rowCount += 1
        While rowCount < 6
            dgvCalendar.Rows.Add()
            dgvCalendar.Rows(dgvCalendar.RowCount - 1).Height = 100
            rowCount += 1
        End While
        dgvCalendar.Rows(rowIndex).Cells(colIndex).Selected = True
        isLoaded = False
        cboCalendarMonth.Text = GetMonthString(newDate.Month)
        cboCalendarYear.Text = newDate.Year.ToString()
        isLoaded = True
    End Sub
    ''gets the integer value for the given month
    Private Function GetMonthInteger(ByVal month As String) As Integer
        Select Case month
            Case "January"
                Return 1
            Case "February"
                Return 2
            Case "March"
                Return 3
            Case "April"
                Return 4
            Case "May"
                Return 5
            Case "June"
                Return 6
            Case "July"
                Return 7
            Case "August"
                Return 8
            Case "September"
                Return 9
            Case "October"
                Return 10
            Case "November"
                Return 11
            Case "December"
                Return 12
            Case Else
                Return 0
        End Select
    End Function
    ''gets the integer value for the given month
    Private Function GetMonthString(ByVal month As Integer) As String
        Select Case month
            Case 1
                Return "January"
            Case 2
                Return "February"
            Case 3
                Return "March"
            Case 4
                Return "April"
            Case 5
                Return "May"
            Case 6
                Return "June"
            Case 7
                Return "July"
            Case 8
                Return "August"
            Case 9
                Return "September"
            Case 10
                Return "October"
            Case 11
                Return "November"
            Case 12
                Return "December"
            Case Else
                Return ""
        End Select
    End Function

    Private Sub cboCalendarMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCalendarMonth.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboCalendarMonth.Text) And Not String.IsNullOrEmpty(cboCalendarYear.Text) Then
                UpdateCalendar(New Date(Val(cboCalendarYear.Text), GetMonthInteger(cboCalendarMonth.Text), 1))
            End If
        End If
    End Sub

    Private Sub cboCalendarYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCalendarYear.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboCalendarMonth.Text) And Not String.IsNullOrEmpty(cboCalendarYear.Text) Then
                UpdateCalendar(New Date(Val(cboCalendarYear.Text), GetMonthInteger(cboCalendarMonth.Text), 1))
            End If
        End If
    End Sub

    Private Sub dgvCalendar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvCalendar.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo = dgvCalendar.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                dgvCalendar.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                If Not String.IsNullOrEmpty(dgvCalendar.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Value) Then
                    cmsDGVCalendar.Show(dgvCalendar, New System.Drawing.Point(e.X, e.Y))
                End If
            End If
        End If
    End Sub

    Private Sub AddNotifications(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim day As Integer = 0
        If dgvCalendar.SelectedCells(0).Value.ToString.Contains(Environment.NewLine) Then
            day = Val(dgvCalendar.SelectedCells(0).Value.ToString.Substring(0, dgvCalendar.SelectedCells(0).Value.ToString.IndexOf(Environment.NewLine)))
        Else
            day = Val(dgvCalendar.SelectedCells(0).Value.ToString)
        End If

        newAddNotifications = New NotificationsAdd(New Date(Val(cboCalendarYear.Text), GetMonthInteger(cboCalendarMonth.Text), day))
        newAddNotifications.Show()
        AddHandler newAddNotifications.FormClosed, AddressOf newAddNotifications_Close
    End Sub
    Private Sub ShowNotifications(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim day As Integer = 0
        If dgvCalendar.SelectedCells(0).Value.ToString.Contains(Environment.NewLine) Then
            day = Val(dgvCalendar.SelectedCells(0).Value.ToString.Substring(0, dgvCalendar.SelectedCells(0).Value.ToString.IndexOf(Environment.NewLine)))
        Else
            day = Val(dgvCalendar.SelectedCells(0).Value.ToString)
        End If

        Dim newShowNotifications As New NotificationsShow(New Date(Val(cboCalendarYear.Text), GetMonthInteger(cboCalendarMonth.Text), day), cboEmployee.Text, cboDivisionID.Text)
        newShowNotifications.ShowDialog()
        newAddNotifications_Close(sender, New System.Windows.Forms.FormClosedEventArgs(CloseReason.None))
    End Sub

    Private Sub newAddNotifications_Close(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        Dim day As Integer = 0
        If dgvCalendar.SelectedCells(0).Value.ToString.Contains(Environment.NewLine) Then
            day = Val(dgvCalendar.SelectedCells(0).Value.ToString.Substring(0, dgvCalendar.SelectedCells(0).Value.ToString.IndexOf(Environment.NewLine)))
        Else
            day = Val(dgvCalendar.SelectedCells(0).Value.ToString)
        End If
        UpdateCalendar(New Date(Val(cboCalendarYear.Text), GetMonthInteger(cboCalendarMonth.Text), day))
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded And cboDivisionID.SelectedIndex <> -1 Then
            UpdateCalendar(New Date(Val(cboCalendarYear.Text), GetMonthInteger(cboCalendarMonth.Text), 1))
        End If
    End Sub

    Private Sub cboEmployee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployee.SelectedIndexChanged
        If isLoaded And cboEmployee.SelectedIndex <> -1 Then
            UpdateCalendar(New Date(Val(cboCalendarYear.Text), GetMonthInteger(cboCalendarMonth.Text), 1))
        End If
    End Sub

    Private Sub cboDivisionID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDivisionID.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub cboEmployee_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEmployee.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub NotificationCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
