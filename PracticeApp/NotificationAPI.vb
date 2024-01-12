Imports System.Data.SqlClient

Public Class NotificationAPI
    ''class to hold the data for a given notification
    Public Class NotificationData
        Private key As Integer
        Public Property NotificationKey() As String
            Get
                Return key
            End Get
            Set(ByVal value As String)
                key = value
            End Set
        End Property

        Private Div As String
        Public Property Division() As String
            Get
                If Div Is Nothing Then Return ""
                Return Div
            End Get
            Set(ByVal value As String)
                Div = value
            End Set
        End Property

        Private Empl As String
        Public Property EmployeeName() As String
            Get
                If Empl Is Nothing Then Return ""
                Return Empl
            End Get
            Set(ByVal value As String)
                Empl = value
            End Set
        End Property

        Private type As String
        Public Property NotificationType() As String
            Get
                If type Is Nothing Then Return ""
                Return type
            End Get
            Set(ByVal value As String)
                If value.Length > 50 Then value = value.Substring(0, 50)
                type = value
            End Set
        End Property

        Private refer As String
        Public Property ReferenceNumber() As String
            Get
                If refer Is Nothing Then Return ""
                Return refer
            End Get
            Set(ByVal value As String)
                refer = value
            End Set
        End Property

        Private Freq As String
        Public Property Frequency() As String
            Get
                If Freq Is Nothing Then Return "Only Once"
                Return Freq
            End Get
            Set(ByVal value As String)
                Freq = value
            End Set
        End Property

        Private NotDateTime As DateTime
        Public Property NotificationDateTime() As DateTime
            Get
                If NotDateTime = DateTime.MinValue Then Return Now
                Return NotDateTime
            End Get
            Set(ByVal value As DateTime)
                NotDateTime = value
            End Set
        End Property

        Private EnDateTime As DateTime
        Public Property EndDateTime() As DateTime
            Get
                If EnDateTime = DateTime.MinValue Then Return Now
                Return EnDateTime
            End Get
            Set(ByVal value As DateTime)
                EnDateTime = value
            End Set
        End Property

        Private det As String
        Public Property Details() As String
            Get
                If det Is Nothing Then Return ""
                Return det
            End Get
            Set(ByVal value As String)
                If value.Length > 500 Then value = value.Substring(0, 500)
                det = value
            End Set
        End Property

        Private stat As String
        Public Property Status() As String
            Get
                If stat Is Nothing Then
                    Return "ACTIVE"
                Else
                    Return stat
                End If
            End Get
            Set(ByVal value As String)
                stat = value
            End Set
        End Property

        Private AddBy As String
        Public Property AddedBy() As String
            Get
                If AddBy Is Nothing Then Return ""
                Return AddBy
            End Get
            Set(ByVal value As String)
                AddBy = value
            End Set
        End Property

        Private grpID As Integer
        Public Property GroupID() As Integer
            Get
                Return grpID
            End Get
            Set(ByVal value As Integer)
                grpID = value
            End Set
        End Property
        Public Sub New()
        End Sub

        Public Sub New(ByVal ky As Integer, ByVal divis As String, ByVal Employ As String, ByVal refe As String, ByVal tpe As String, ByVal fre As String, ByVal nodDate As DateTime, ByVal deta As String, ByVal sta As String, ByVal ad As String, ByVal gpd As Integer)
            key = ky
            Div = divis
            EmployeeName = Employ
            refer = refe
            type = tpe
            Freq = fre
            NotDateTime = nodDate
            If IsDBNull(deta) Then
                det = ""
            Else
                det = deta
            End If
            stat = sta
            AddBy = ad
            grpID = gpd
        End Sub

        Public Sub New(ByVal ds As DataSet)
            If ds.Tables.Contains("Notifications") Then
                key = ds.Tables("Notifications").Rows(0).Item("NotificationKey")
                Div = ds.Tables("Notifications").Rows(0).Item("DivisionID")
                If ds.Tables("Notifications").Columns.Contains("EmployeeName") Then
                    EmployeeName = ds.Tables("Notifications").Rows(0).Item("EmployeeName")
                ElseIf ds.Tables("Notifications").Columns.Contains("EmployeeFirst") And ds.Tables("Notifications").Columns.Contains("EmployeeLast") Then
                    EmployeeName = ds.Tables("Notifications").Rows(0).Item("EmployeeFirst") + " " + ds.Tables("Notifications").Rows(0).Item("EmployeeLast")
                End If
                If ds.Tables("Notifications").Columns.Contains("ReferenceNumber") Then
                    refer = ds.Tables("Notifications").Rows(0).Item("ReferenceNumber")
                End If
                If ds.Tables("Notifications").Columns.Contains("NotificationType") Then
                    type = ds.Tables("Notifications").Rows(0).Item("NotificationType")
                End If
                If ds.Tables("Notifications").Columns.Contains("Frequency") Then
                    Freq = ds.Tables("Notifications").Rows(0).Item("Frequency")
                End If
                If ds.Tables("Notifications").Columns.Contains("NotificationDateTime") Then
                    NotDateTime = ds.Tables("Notifications").Rows(0).Item("NotificationDateTime")
                End If
                If ds.Tables("Notifications").Columns.Contains("Details") Then
                    det = ds.Tables("Notifications").Rows(0).Item("Details")
                End If
                If ds.Tables("Notifications").Columns.Contains("Status") Then
                    stat = ds.Tables("Notifications").Rows(0).Item("Status")
                End If
                If ds.Tables("Notifications").Columns.Contains("AddedBy") Then
                    AddBy = ds.Tables("Notifications").Rows(0).Item("AddedBy")
                End If
                If ds.Tables("Notifications").Columns.Contains("GroupID") Then
                    grpID = ds.Tables("Notifications").Rows(0).Item("GroupID")
                End If
            End If
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal dc As DataColumnCollection)
            key = dr.Item("NotificationKey")
            Div = dr.Item("DivisionID")
            If dc.Contains("EmployeeName") Then
                EmployeeName = dr.Item("EmployeeName")
            ElseIf dc.Contains("EmployeeFirst") And dc.Contains("EmployeeLast") Then
                EmployeeName = dr.Item("EmployeeFirst") + " " + dr.Item("EmployeeLast")
            End If
            If dc.Contains("ReferenceNumber") Then
                refer = dr.Item("ReferenceNumber")
            End If
            If dc.Contains("NotificationType") Then
                type = dr.Item("NotificationType")
            End If
            If dc.Contains("Frequency") Then
                Freq = dr.Item("Frequency")
            End If
            If dc.Contains("NotificationDateTime") Then
                NotDateTime = dr.Item("NotificationDateTime")
            End If
            If dc.Contains("Details") Then
                det = dr.Item("Details")
            End If
            If dc.Contains("Status") Then
                stat = dr.Item("Status")
            End If
            If dc.Contains("AddedBy") Then
                AddBy = dr.Item("AddedBy")
            End If
            If dc.Contains("GroupID") Then
                grpID = dr.Item("GroupID")
            End If
        End Sub
    End Class

    Dim MultipleNotifications As Boolean = False
    Public NotifData As New List(Of NotificationData)

    Dim con As New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Public Sub New()
        NotifData.Add(New NotificationData())
    End Sub

    ''creates an entry given minimal information needed Date, employee and division
    Public Sub New(ByVal dat As Date, ByVal employee As String, ByVal div As String)
        GetNotifications(dat, div, employee)
    End Sub

    ''create a new notification object from a given dataset
    Public Sub New(ByVal inData As DataSet)
        If inData.Tables.Contains("Notifications") Then
            For i As Integer = 0 To inData.Tables("Notifications").Rows.Count - 1
                NotifData.Add(New NotificationData(inData.Tables("Notifications").Rows(i), inData.Tables("Notifications").Columns))
            Next
        End If
        MultipleNotifications = True
    End Sub

    Public Sub New(ByVal NotData As NotificationData)
        NotifData.Add(NotData)
    End Sub

    Private Sub GetNotifications(ByVal notDate As DateTime, ByVal div As String, ByVal emp As String)
        Dim ds As New DataSet
        Dim cmd As New SqlCommand("SELECT NotificationKey, DivisionID, EmployeeFirst, EmployeeLast, NotificationType, ReferenceNumber, NotificationDateTime, Details, Status, AddedBy FROM NotificationTable LEFT OUTER JOIN EmployeeData ON NotificationTable.EmployeeID = EmployeeData.EmployeeID WHERE DATEDIFF( dy,NotificationDateTime, @NotificationDateTime) = 0 AND NotificationTable. EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst + ' ' + EmployeeLast = @EmployeeName) AND DivisionID = @DivisionID ORDER BY NotificationDateTime", con)
        cmd.Parameters.Add("@NotificationDateTime", SqlDbType.DateTime).Value = notDate
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = div
        cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = emp

        Dim tempAdap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        tempAdap.Fill(ds, "Notifications")
        con.Close()
        NotifData.Clear()
        For i As Integer = 0 To ds.Tables("Notifications").Rows.Count - 1
            NotifData.Add(New NotificationData(ds.Tables("Notifications").Rows(i), ds.Tables("Notifications").Columns))
        Next
        If ds.Tables("Notifications").Rows.Count > 1 Then
            MultipleNotifications = True
        Else
            MultipleNotifications = False
        End If
    End Sub

    ''gets only the specified notification (Will Clear any notifications currently in the list)
    Public Sub GetNotification(ByVal NotificationKey As Integer)
        Dim cmd As New SqlCommand("SELECT NotificationKey, DivisionID, EmployeeFirst, EmployeeLast, NotificationType, ReferenceNumber, NotificationDateTime, Details, Status, AddedBy FROM NotificationTable LEFT OUTER JOIN EmployeeData ON NotificationTable.EmployeeID = EmployeeData.EmployeeID WHERE NotificationKey = @NotificationKey ORDER BY NotificationDateTime", con)
        cmd.Parameters.Add("@NotificationKey", SqlDbType.Int).Value = NotificationKey

        NotifData.Clear()

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            NotifData.Add(New NotificationData(reader.Item("NotificaitonKey"), reader.Item("DivisionID"), reader.Item("EmployeeFirst") + " " + reader.Item("EmployeeLast"), reader.Item("ReferenceNumber"), reader.Item("NotificaitonType"), reader.Item("Frequency"), reader.Item("NotificaitonDateTime"), reader.Item("Details"), reader.Item("Status"), reader.Item("AddedBy"), reader.Item("GroupID")))
        End If
        reader.Close()
        con.Close()
        MultipleNotifications = False
    End Sub

    ''reloads the data from the existing notification keys
    Public Sub RefreshNotificationData()
        Dim ds As New DataSet
        Dim cmd As New SqlCommand("SELECT NotificationKey, DivisionID, EmployeeFirst, EmployeeLast, NotificationType, ReferenceNumber, NotificationDateTime, Details, Status, AddedBy FROM NotificationTable LEFT OUTER JOIN EmployeeData ON NotificationTable.EmployeeID = EmployeeData.EmployeeID WHERE ", con)

        For i As Integer = 0 To NotifData.Count - 1
            If i = 0 Then
                cmd.CommandText += "NotificationKey = " + Data(i).NotificationKey.ToString()
            Else
                cmd.CommandText += " OR NotificationKey = " + Data(i).NotificationKey.ToString()
            End If
        Next

        cmd.CommandText += " ORDER BY NotificationDateTime"
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "Notifications")
        con.Close()
        NotifData.Clear()
        For i As Integer = 0 To ds.Tables("Notifications").Rows.Count - 1
            NotifData.Add(New NotificationData(ds.Tables("Notifications").Rows(i), ds.Tables("Notifications").Columns))
        Next
        If ds.Tables("Notifications").Rows.Count > 1 Then
            MultipleNotifications = True
        Else
            MultipleNotifications = False
        End If
    End Sub

    Public Sub UpdateNotification(Optional ByVal NotificationNumber As Integer = 0)
        Dim cmd As New SqlCommand("UPDATE NotificationTable SET DivisionID = @DivisionID, EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst + ' ' + EmployeeLast = @EmployeeName), NotificationType = @NotificationType, ReferenceNumber = @ReferenceNumber, NotificationDateTime = @NotificationDateTime, Details = @Details, SnoozeTime = @NotificationDateTime WHERE NotificationKey = @NotificationKey", con)

        With cmd.Parameters
            .Add("@NotificationKey", SqlDbType.Int).Value = NotifData(NotificationNumber).NotificationKey
            .Add("@DivisionID", SqlDbType.VarChar).Value = NotifData(NotificationNumber).Division
            .Add("@EmployeeName", SqlDbType.VarChar).Value = NotifData(NotificationNumber).EmployeeName
            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NotifData(NotificationNumber).ReferenceNumber
            .Add("@NotificationType", SqlDbType.VarChar).Value = NotifData(NotificationNumber).NotificationType
            .Add("@NotificationDateTime", SqlDbType.DateTime).Value = NotifData(NotificationNumber).NotificationDateTime
            .Add("@Details", SqlDbType.VarChar).Value = NotifData(NotificationNumber).Details
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub AddNotification(Optional ByVal part As String = "", Optional ByVal addFOX As Boolean = False)

        Dim cmd As SqlCommand
        If Not addFOX Then
            cmd = New SqlCommand("DECLARE @Key as int = (SELECT ISNULL(MAX(NotificationKey) + 1, 1) FROM NotificationTable), @EmployeeID as varchar(20) = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst + ' ' + EmployeeLast = @EmployeeName), @GroupID as int = (SELECT isnull(MAX(GroupID)+1, 1) FROM NotificationTable); INSERT INTO NotificationTable VALUES ", con)
        Else
            cmd = New SqlCommand("DECLARE @Key as int = (SELECT ISNULL(MAX(NotificationKey) + 1, 1) FROM NotificationTable), @EmployeeID as varchar(20) = (SELECT EmployeeID FROM EmployeeData WHERE EmployeeFirst + ' ' + EmployeeLast = @EmployeeName), @GroupID as int = (SELECT isnull(MAX(GroupID)+1, 1) FROM NotificationTable), @FOXNumber as Varchar(50) = (SELECT TOP 1 CAST (FOXNumber as Varchar) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID); INSERT INTO NotificationTable VALUES ", con)
            cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = part
        End If
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = NotifData(0).Division
        cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = NotifData(0).EmployeeName
        cmd.Parameters.Add("@NotificationType", SqlDbType.VarChar).Value = NotifData(0).NotificationType
        cmd.Parameters.Add("@Frequency", SqlDbType.VarChar).Value = NotifData(0).Frequency
        cmd.Parameters.Add("@ReferenceNumber", SqlDbType.VarChar).Value = NotifData(0).ReferenceNumber
        cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = NotifData(0).Details
        cmd.Parameters.Add("@AddedBy", SqlDbType.VarChar).Value = NotifData(0).AddedBy

        Select Case NotifData(0).Frequency
            Case "Every Other Month"
                Dim monthCount As Integer = DateDiff(DateInterval.Month, NotifData(0).NotificationDateTime, NotifData(0).EndDateTime) / 2
                Dim i As Integer = 0
                Dim currentDate As DateTime = NotifData(0).NotificationDateTime
                While i <= monthCount
                    If Not addFOX Then
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    Else
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    End If


                    cmd.Parameters.Add("@NotificationDateTime" + i.ToString(), SqlDbType.DateTime).Value = currentDate
                    currentDate = currentDate.AddMonths(2)
                    i += 1
                End While
            Case "Every Other Week"
                Dim weekCount As Integer = DateDiff(DateInterval.Day, NotifData(0).NotificationDateTime, NotifData(0).EndDateTime) / 14
                Dim i As Integer = 0
                Dim currentDate As DateTime = NotifData(0).NotificationDateTime
                While i <= weekCount
                    If Not addFOX Then
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    Else
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    End If

                    cmd.Parameters.Add("@NotificationDateTime" + i.ToString(), SqlDbType.DateTime).Value = currentDate
                    currentDate = currentDate.AddDays(14)
                    i += 1
                End While
            Case "Monthly"
                Dim monthCount As Integer = DateDiff(DateInterval.Month, NotifData(0).NotificationDateTime, NotifData(0).EndDateTime)
                Dim i As Integer = 0
                Dim currentDate As DateTime = NotifData(0).NotificationDateTime
                While i <= monthCount
                    If Not addFOX Then
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    Else
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    End If

                    cmd.Parameters.Add("@NotificationDateTime" + i.ToString(), SqlDbType.DateTime).Value = currentDate
                    currentDate = currentDate.AddMonths(1)
                    i += 1
                End While
            Case "Weekly"
                Dim weekCount As Integer = DateDiff(DateInterval.Day, NotifData(0).NotificationDateTime, NotifData(0).EndDateTime) / 7
                Dim i As Integer = 0
                Dim currentDate As DateTime = NotifData(0).NotificationDateTime
                While i <= weekCount
                    If Not addFOX Then
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    Else
                        If i = 0 Then
                            cmd.CommandText += " (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@Key + " + i.ToString() + ", @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime" + i.ToString() + ", @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If
                    End If

                    cmd.Parameters.Add("@NotificationDateTime" + i.ToString(), SqlDbType.DateTime).Value = currentDate
                    currentDate = currentDate.AddDays(7)
                    i += 1
                End While
            Case "Only Once"
                If Not addFOX Then
                    cmd.CommandText += " (@Key, @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime, @Details, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime)"
                Else
                    cmd.CommandText += " (@Key, @DivisionID, @EmployeeID, @NotificationType, @ReferenceNumber, @Frequency, @NotificationDateTime, @Details + @FOXNumber, 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime)"
                End If
                cmd.Parameters.Add("@NotificationDateTime", SqlDbType.DateTime).Value = NotifData(0).NotificationDateTime
        End Select

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    ''will provide the pass through for the data
    Public Function Data(Optional ByVal atPos As Integer = 0) As NotificationData
        If atPos >= NotifData.Count Then
            Return Nothing
        End If
        Return NotifData(atPos)
    End Function

    ''returns the notification count
    Public Function Count() As Integer
        Return NotifData.Count
    End Function

    ''provides the snooze for current notifications (in minutes)
    Public Sub Snooze(Optional ByVal duration As Integer = 30)
        Dim cmd As New SqlCommand("UPDATE NotificationTable SET SnoozeTime = @SnoozeTime WHERE ", con)

        cmd.Parameters.Add("@SnoozeTime", SqlDbType.DateTime).Value = DateTime.Now.AddMinutes(duration)
        For i As Integer = 0 To NotifData.Count - 1
            If i = 0 Then
                cmd.CommandText += "NotificationKey = " + NotifData(i).NotificationKey.ToString()
            Else
                cmd.CommandText += " OR NotificationKey = " + NotifData(i).NotificationKey.ToString()
            End If
        Next
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub RemoveNotification(ByVal position As Integer)
        NotifData.RemoveAt(position)
    End Sub
End Class
