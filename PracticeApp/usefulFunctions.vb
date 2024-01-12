Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Printing
Module usefulFunctions

    Public Class PDFFileData
        Public CurrentFileName As String
        Public BlueprintNumber As String
        Public RevisionLevel As String
        Public FOXNumber As String
        Public InspectionDate As DateTime
        Public HeatNumber As String
        Public Size As String
        Public Vendor As String
        Public LotNumber As String
        Public CustomerID As String
    End Class

    ''USED FOR TRACKING FIELD CHANGES
    Structure FieldData
        Public ColumnName As String
        Public OriginalValue As String
        Public NewValue As String
    End Structure

    Public Class ChangedFields
        Dim lst As New List(Of FieldData)
        ''Checks to see if field is in the list and updates the list item else adds it to the list
        Public Sub Add(ByVal fld As FieldData)
            Remove(fld)
            lst.Add(fld)
        End Sub

        Public Sub InsertAt(ByVal idx As Integer, ByVal fld As FieldData)
            Remove(fld)
            If lst.Count > 0 Then
                If idx < 0 Then
                    lst.Insert(0, fld)
                ElseIf idx >= lst.Count Then
                    lst.Add(fld)
                Else
                    lst.Insert(idx, fld)
                End If
            Else
                lst.Add(fld)
            End If
        End Sub

        Public Sub Remove(ByVal fld As FieldData)
            Dim found As Boolean = False
            Dim i As Integer = 0
            While Not found AndAlso i < lst.Count
                If lst(i).ColumnName.Equals(fld.ColumnName) Then
                    found = True
                Else
                    i += 1
                End If
            End While
            If found Then
                lst.RemoveAt(i)
            End If
        End Sub

        ''gets list
        Public Function GetList() As List(Of FieldData)
            Return lst
        End Function

        ''Clears the list of changed fields
        Public Sub Clear()
            lst.Clear()
        End Sub
    End Class

    Public shippingPrinterName As String = "PickTicketPrinter"
    'Public shippingPrinterName As String = "Brother HL-2240"

    Public Function checkQuote(ByVal inText As String) As String
        If inText.Contains("'") Then
            Dim sep As String() = inText.Split(New String() {"'"}, StringSplitOptions.None)
            inText = sep(0)
            For i As Integer = 1 To sep.Count - 1
                inText += "''" + sep(1)
            Next
        End If
        If inText.Contains("""") Then
            Dim sep As String() = inText.Split(New String() {""""}, StringSplitOptions.None)
            inText = sep(0)
            For i As Integer = 1 To sep.Count - 1
                inText += """" + sep(1)
            Next
        End If
        Return inText
    End Function

    ''for use with the custom date time picker for checking the case on key down
    Public Sub keyDownCheckCase(ByRef dtpCheck As System.Object, ByRef nxtControl As System.Object)
        Select Case True
            Case (dtpCheck.SelectionStart > 2 And dtpCheck.SelectionStart < 6)
                Dim tst As Integer = dtpCheck.Text.Substring(dtpCheck.Text.IndexOf("/"), dtpCheck.Text.LastIndexOf("/") - dtpCheck.Text.IndexOf("/")).Length
                If dtpCheck.Text.Substring(dtpCheck.Text.IndexOf("/"), dtpCheck.Text.LastIndexOf("/") - dtpCheck.Text.IndexOf("/")).Length < 3 Then
                    Dim txt As String() = dtpCheck.Text.Split(New String() {"/"}, StringSplitOptions.None)
                    If txt.Count > 2 Then
                        If txt(1) = "0" Then
                            dtpCheck.Text = txt(0) + "/01" + "/" + txt(2)
                        Else
                            dtpCheck.Text = txt(0) + "/0" + txt(1) + "/" + txt(2)
                        End If

                    Else
                        dtpCheck.Text = txt(0) + "/01" + "/" + txt(2)
                    End If
                End If
                dtpCheck.SelectionStart = 6
                dtpCheck.Select(6, 4)
            Case (dtpCheck.SelectionStart <= 2)
                If dtpCheck.Text.Substring(0, dtpCheck.Text.IndexOf("/")).Length < 2 Then
                    If dtpCheck.Text.Substring(0, dtpCheck.Text.IndexOf("/")).Length < 1 Then
                        dtpCheck.Text = "01" + dtpCheck.Text
                    Else
                        If dtpCheck.Text(0) = "0" Then
                            dtpCheck.Text = dtpCheck.Text(0) + "1" + dtpCheck.Text.Substring(1, dtpCheck.Text.Length - 1)
                        Else
                            dtpCheck.Text = "0" + dtpCheck.Text
                        End If
                    End If
                End If
                dtpCheck.SelectionStart = 3
                dtpCheck.Select(3, 2)
            Case (dtpCheck.SelectionStart >= 6)
                nxtControl.Focus()
        End Select
    End Sub

    ''this will take in a date and format it to the correct MM/DD/YYYY that is needed
    Public Function formatDate(ByRef dat As String) As String
        Dim spl As String() = dat.Split(New String() {"/"}, StringSplitOptions.None)
        If spl(0).Length < 2 Then
            spl(0) = "0" + spl(0)
        End If
        If spl(1).Length < 2 Then
            spl(1) = "0" + spl(1)
        End If
        If spl(2).Length < 4 Then
            spl(2) = Today.Date.Year.ToString()
        End If
        Return (spl(0) + "/" + spl(1) + "/" + spl(2))
    End Function

    ''based on the mouse click this will select the proper location in the string
    Public Sub selectDTPLocation(ByRef dtpCheck As System.Object)
        Select Case True
            Case (dtpCheck.SelectionStart > 2 And dtpCheck.SelectionStart < 6)
                dtpCheck.SelectionStart = 3
                dtpCheck.Select(3, 2)
            Case (dtpCheck.SelectionStart <= 2)
                dtpCheck.SelectionStart = 0
                dtpCheck.Select(0, 2)
            Case (dtpCheck.SelectionStart >= 6)
                dtpCheck.SelectionStart = 6
                dtpCheck.Select(6, 4)
        End Select
    End Sub

    ''will check to see if the current location in the date string is where it should auto move to the next location
    Public Sub autoMoveInDateString(ByRef dtpCheck As System.Object)
        Select Case dtpCheck.SelectionStart
            Case 2
                dtpCheck.SelectionStart = 3
                dtpCheck.Select(3, 2)
            Case 5
                dtpCheck.SelectionStart = 6
                dtpCheck.Select(6, 4)
        End Select
    End Sub

    ''checks the status of the shipping computer to make sure it is not showing offline
    Public Function ShippingPrinterStatus(ByVal printerName As String) As Boolean
        ' Add a Reference to System.Management
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject
        Try
            moSearch = New Management.ManagementObjectSearcher("Select * from Win32_Printer")
            moReturn = moSearch.Get
            If moReturn.Count = 0 Then
                Return False
            End If
            Dim found As Boolean = False
            Dim pos As Integer = 0
            For i As Integer = 0 To moReturn.Count - 1 And Not found
                If moReturn(i).Properties("Name").Value.Equals(printerName) Then
                    pos = i
                    found = True
                End If
            Next
            mo = moReturn(pos)
            Dim statusCode As UInt16 = mo.Properties("PrinterStatus").Value
            ''check to see if the pritner is in a state that it can print
            '' STATUS CODES
            '' 1 - Other
            '' 2 - Unknown
            '' 3 - Idle
            '' 4 - Printing
            '' 5 - Warming Up
            '' 6 - Stopped Printing
            '' 7 - Offline
            Select Case statusCode
                Case 1, 2, 3, 4, 5
                    Return True
                Case Else
                    Return False
            End Select
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    ''generates the next coil ID based on the coil id given and number
    Public Function generateNextID(ByVal id As String, ByVal numb As Integer) As String
        Dim coil As String = ""
        Dim spl As String() = id.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
        ''check to see if there are more than 3 parts to the coilID, if so this will add 1 to the number if the last field is a number, else it will default back to just adding -01
        If spl.Count > 3 Then
            If IsNumeric(spl(spl.Count - 1)) Then
                Dim nbr As Integer = Val(spl(spl.Count - 1)) + numb
                ''check to see if the number is greater than 9 and if not will add a leading 0
                If nbr > 9 Then
                    spl(spl.Count - 1) = nbr
                Else
                    spl(spl.Count - 1) = "0" + nbr.ToString()
                End If
                For i As Integer = 0 To spl.Count - 1
                    If String.IsNullOrEmpty(coil) Then
                        coil = spl(i)
                    Else
                        coil += "-" + spl(i)
                    End If

                Next
            Else
                coil = id + "-0" + numb.ToString()
            End If
        Else
            coil = id + "-0" + numb.ToString()
        End If
        Return coil
    End Function

    Public Class FocusedItem
        Private combObj As System.Windows.Forms.ComboBox
        Private textObj As System.Windows.Forms.TextBox
        Private pos As Integer
        Private leng As Integer

        Public Sub New()
            combObj = Nothing
            textObj = Nothing
            pos = 0
        End Sub

        Public Sub New(ByRef obj As System.Windows.Forms.TextBox)
            textObj = obj
            combObj = Nothing
            pos = obj.SelectionStart
            leng = obj.SelectionLength
        End Sub

        Public Sub New(ByRef obj As System.Windows.Forms.ComboBox)
            textObj = Nothing
            combObj = obj
            pos = obj.SelectionStart
            leng = obj.Text.Length
        End Sub

        ''masks the object but returns the position
        Public Property Position() As Integer
            Get
                Return pos
            End Get
            Set(ByVal value As Integer)
                pos = value
            End Set
        End Property

        ''masks the object but will return the length of the selection
        Public Property SelectionLength() As Integer
            Get
                Return leng
            End Get
            Set(ByVal value As Integer)
                leng = value
            End Set
        End Property

        ''masks the object but returns the text in it
        Public Property Text() As String
            Get
                If textObj IsNot Nothing Then
                    Return textObj.Text
                End If
                If combObj IsNot Nothing Then
                    Return combObj.Text
                End If
                Return ""
            End Get
            Set(ByVal value As String)
                If textObj IsNot Nothing Then
                    textObj.Text = value
                End If
                If combObj IsNot Nothing Then
                    combObj.Text = value
                End If
            End Set
        End Property

        ''masks the object but returns the name in it
        Public Property Name() As String
            Get
                If textObj IsNot Nothing Then
                    Return textObj.Name
                End If
                If combObj IsNot Nothing Then
                    Return combObj.Name
                End If
                Return ""
            End Get
            Set(ByVal value As String)
                If textObj IsNot Nothing Then
                    textObj.Name = value
                End If
                If combObj IsNot Nothing Then
                    combObj.Name = value
                End If
            End Set
        End Property

        Public Sub Focus()
            If textObj IsNot Nothing Then
                textObj.Focus()
            End If
            If combObj IsNot Nothing Then
                combObj.Focus()
            End If
        End Sub

        Public Function isSet() As Boolean
            If textObj Is Nothing And combObj Is Nothing Then
                Return False
            End If
            Return True
        End Function
    End Class

    Public Function ConvertToDecimal(ByVal stringVal As String) As String
        If stringVal.Contains("X") Then
            Dim dimensions As String() = stringVal.Split("X"c)

            If dimensions.Count > 1 Then
                Return DivideStringArray(dimensions(0)) + "X" + DivideStringArray(dimensions(1))
            Else
                Return DivideStringArray(dimensions(0)) + "X"
            End If
        Else
            If Not stringVal.Contains("/") AndAlso Not stringVal.Contains("-") Then
                Return stringVal
            End If
            Try
                Dim nmr As String() = stringVal.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)
                ''checks to see if there is a whole number and if there is it will convert the whole number
                If nmr(0).Contains("-") Then
                    Dim tmp As String() = nmr(0).Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
                    If tmp.Count > 1 Then
                        If nmr.Count > 1 Then
                            nmr(0) = Convert.ToInt32(tmp(0) * nmr(1) + tmp(1))
                        Else
                            nmr(0) = Convert.ToInt32(tmp(0) + tmp(1))
                        End If
                    Else
                        nmr(0) = Convert.ToInt32(tmp(0))
                    End If
                End If
                Dim dml As String = nmr(0)
                If nmr(0).Contains(".") = False And nmr.Count > 1 Then
                    If Not nmr(1).Equals("0") And Not nmr(1).Equals("0.") Then
                        dml = Convert.ToDouble(nmr(0)) / Convert.ToDouble(nmr(1))
                        Dim sepDml As String() = dml.Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
                        ''checks to make sure that the decimal is only 3 positions if not will add 0 if its more will remove
                        If sepDml.Count > 1 Then
                            If sepDml(1).Length > 3 Then
                                dml = dml.Substring(0, dml.Length - (sepDml(1).Length - 3))
                            Else
                                While sepDml(1).Length < 3
                                    sepDml(1) = sepDml(1) + "0"
                                End While
                                dml = sepDml(0) + "." + sepDml(1)
                            End If
                        End If
                    End If
                End If
                ''checks to make sure the decimal number is no more than 3 digits on the decimal if it is will round
                dml = Val(dml)
                If dml.Length - dml.LastIndexOf(".") > 3 Then
                    Dim tmpNbr As Double = Val(dml)
                    If dml.LastIndexOf(".") = 0 Then
                        dml = tmpNbr.ToString().Substring(dml.LastIndexOf("."), 4)
                    ElseIf dml.LastIndexOf(".") > 0 Then
                        dml = tmpNbr.ToString().Substring(0, dml.LastIndexOf(".")) + tmpNbr.ToString().Substring(dml.LastIndexOf("."), 4)
                    End If
                End If
                If dml(0).Equals("."c) Then
                    dml = "0" + dml
                End If
                While dml(dml.Length - 1).Equals("0"c)
                    dml = dml.Substring(0, dml.Length - 1)
                End While
                Return dml
            Catch ex As System.Exception
                Return stringVal
            End Try
        End If

    End Function

    ''Divides an array of strings to get a decimal
    Private Function DivideStringArray(ByVal inString As String) As String
        Dim returnValue As String = ""
        Dim wholeNumber As Integer = 0
        If inString.Contains("-"c) Then
            If inString.IndexOf("-"c) > inString.IndexOf("/"c) AndAlso inString.IndexOf("-"c) <> -1 Then
                Return inString
            End If
            wholeNumber = Val(inString.Substring(0, inString.IndexOf("-"c)))
            inString = inString.Substring(inString.IndexOf("-"c) + 1)
        End If
        If inString.Contains("/"c) Then
            Dim spl As String() = inString.Split("/"c)
            If spl.Count > 1 AndAlso spl(1).Length > 0 Then
                Dim decim As Double = Val(spl(0)) / Val(spl(1))
                Dim decimalString As String = ""
                If decim.ToString.Substring(decim.ToString.IndexOf("."c) + 1).Length > 3 Then
                    decimalString = decim.ToString.Substring(decim.ToString.IndexOf("."c), 4)
                Else
                    decimalString = decim.ToString.Substring(decim.ToString.IndexOf("."c))
                End If
                returnValue = wholeNumber.ToString + decimalString
            End If
        Else
            Return inString
        End If
        Return returnValue
    End Function

    ''Gets the fractional for a string
    Public Function GetFractional(ByVal inString As String) As String
        Dim fract As String = ""
        Dim inValue As Double = Math.Round(Val(inString), 3, MidpointRounding.AwayFromZero)
        If inValue > 1 Then
            If inString.Contains(".") Then
                fract = inString.Substring(0, inString.IndexOf(".")) + "-"
            Else
                fract = inString + "-"
            End If
            inValue -= Val(fract)
        End If
        Select Case inValue
            Case 0.015
                fract += "1/64"
            Case 0.016
                fract += "1/64"
            Case 0.031
                fract += "1/32"
            Case 0.062
                fract += "1/16"
            Case 0.063
                fract += "1/16"
            Case 0.125
                fract += "1/8"
            Case 0.25
                fract += "1/4"
            Case 0.333
                fract += "1/3"
            Case 0.5
                fract += "1/2"
            Case 0.046
                fract += "3/64"
            Case 0.047
                fract += "3/64"
            Case 0.093
                fract += "3/32"
            Case 0.094
                fract += "3/32"
            Case 0.187
                fract += "3/16"
            Case 0.188
                fract += "3/16"
            Case 0.375
                fract += "3/8"
            Case 0.75
                fract += "3/4"
            Case 0.078
                fract += "5/64"
            Case 0.156
                fract += "5/32"
            Case 0.312
                fract += "5/16"
            Case 0.313
                fract += "5/16"
            Case 0.625
                fract += "5/8"
            Case 0.11
                fract += "7/64"
            Case 0.219
                fract += "7/32"
            Case 0.437
                fract += "7/16"
            Case 0.438
                fract += "7/16"
            Case 0.875
                fract += "7/8"
            Case 0.14
                fract += "9/64"
            Case 0.141
                fract += "9/64"
            Case 0.281
                fract += "9/32"
            Case 0.562
                fract += "9/16"
            Case 0.563
                fract += "9/16"
            Case 0.171
                fract += "11/64"
            Case 0.172
                fract += "11/64"
            Case 0.343
                fract += "11/32"
            Case 0.344
                fract += "11/32"
            Case 0.687
                fract += "11/16"
            Case 0.688
                fract += "11/16"
            Case 0.203
                fract += "13/64"
            Case 0.406
                fract += "13/32"
            Case 0.812
                fract += "13/16"
            Case 0.813
                fract += "13/16"
            Case 0.234
                fract += "15/64"
            Case 0.468
                fract += "15/32"
            Case 0.469
                fract += "15/32"
            Case 0.937
                fract += "15/16"
            Case 0.938
                fract += "15/16"
            Case 0.265
                fract += "17/64"
            Case 0.266
                fract += "17/64"
            Case 0.531
                fract += "17/32"
            Case 0.296
                fract += "19/64"
            Case 0.297
                fract += "19/64"
            Case 0.593
                fract += "19/32"
            Case 0.594
                fract += "19/32"
            Case 0.328
                fract += "21/64"
            Case 0.656
                fract += "21/32"
            Case 0.359
                fract += "23/64"
            Case 0.718
                fract += "23/32"
            Case 0.719
                fract += "23/32"
            Case 0.39
                fract += "25/64"
            Case 0.391
                fract += "25/64"
            Case 0.781
                fract += "25/32"
            Case 0.421
                fract += "27/64"
            Case 0.422
                fract += "27/64"
            Case 0.843
                fract += "27/32"
            Case 0.844
                fract += "27/32"
            Case 0.453
                fract += "29/64"
            Case 0.906
                fract += "29/32"
            Case 0.484
                fract += "31/64"
            Case 0.968
                fract += "31/32"
            Case 0.969
                fract += "31/32"
            Case 0.515
                fract += "33/64"
            Case 0.516
                fract += "33/64"
            Case 0.546
                fract += "35/64"
            Case 0.547
                fract += "35/64"
            Case 0.578
                fract += "37/64"
            Case 0.609
                fract += "39/64"
            Case 0.64
                fract += "41/64"
            Case 0.641
                fract += "41/64"
            Case 0.671
                fract += "43/64"
            Case 0.672
                fract += "43/64"
            Case 0.703
                fract += "45/64"
            Case 0.734
                fract += "47/64"
            Case 0.765
                fract += "49/64"
            Case 0.766
                fract += "49/64"
            Case 0.797
                fract += "51/64"
            Case 0.828
                fract += "53/64"
            Case 0.859
                fract += "55/64"
            Case 0.89
                fract += "57/64"
            Case 0.891
                fract += "57/64"
            Case 0.921
                fract += "59/64"
            Case 0.922
                fract += "59/64"
            Case 0.953
                fract += "61/64"
            Case 0.984
                fract += "63/64"
            Case Else
                fract = inValue
        End Select
        Return fract
    End Function

    ''Handles Loading security for a given form
    Public Sub LoadSecurity(ByRef baseForm As System.Windows.Forms.Form, Optional ByVal DivisionID As String = "")
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT ControlName, ControlProperty, ControlValue, ColumnName, 1 as PermissionType FROM SpecialSecurityPermissions WHERE EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE LoginName = @LoginName) AND FormName = @FormName UNION (SELECT ControlName, ControlProperty, ControlValue, ColumnName, 3 as PermissionType FROM StandardSecurityPermissions t1 WHERE FormName = @FormName AND SecurityGroupID = @SecurityGroupID and not exists(SELECT ControlName, ControlProperty, ControlValue as PermissionType FROM SpecialSecurityPermissions t2 WHERE EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE LoginName = @LoginName) and t2.ControlName = t1.ControlName and t2.ControlProperty = t1.ControlProperty and t2.FormName = @FormName) and not exists(SELECT ControlName, ControlProperty, ControlValue as PermissionType FROM DivisionSecurityPermissions t3 WHERE DivisionID = @DivisionID and t3.ControlName = t1.ControlName and t3.ControlProperty = t1.ControlProperty and t3.FormName = @FormName) UNION SELECT ControlName, ControlProperty, ControlValue, ColumnName, 2 as PermissionType FROM DivisionSecurityPermissions t1 WHERE DivisionID = @DivisionID and FormName = @FormName and not exists(SELECT ControlName, ControlProperty, ControlValue as PermissionType FROM SpecialSecurityPermissions t2 WHERE EmployeeID = (SELECT EmployeeID FROM EmployeeData WHERE LoginName = @LoginName) and t2.ControlName = t1.ControlName and t2.ControlProperty = t1.ControlProperty and t2.FormName = @FormName)) ORDER BY PermissionType DESC", con)
        cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = baseForm.Name
        cmd.Parameters.Add("@SecurityGroupID", SqlDbType.Int).Value = EmployeeSecurityCode
        cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar)

        If String.IsNullOrEmpty(DivisionID) Then
            cmd.Parameters("@DivisionID").Value = EmployeeCompanyCode
        Else
            cmd.Parameters("@DivisionID").Value = DivisionID
        End If

        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "StandardSecurityPermissions")
        con.Close()

        For i As Integer = 0 To tempds.Tables("StandardSecurityPermissions").Rows.Count - 1
            Dim matchedControl As Object = FindControl(tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlName"), baseForm)
            Dim ctrlName As String = tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlName")
            If matchedControl IsNot Nothing Then
                Try
                    If Not IsDBNull(tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ColumnName")) Then
                        If Not String.IsNullOrEmpty(tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ColumnName")) Then
                            SetControlProperty(matchedControl, tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlProperty"), tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlValue"), tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ColumnName"))
                        Else
                            SetControlProperty(matchedControl, tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlProperty"), tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlValue"))
                        End If
                    Else
                        SetControlProperty(matchedControl, tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlProperty"), tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlValue"))
                    End If

                Catch ex As Exception
                    cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
                    With cmd.Parameters
                        .Add("@Date", SqlDbType.Date).Value = Now.Date
                        .Add("@Description", SqlDbType.VarChar).Value = baseForm.Name + " - Error trying to set control property " + tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlProperty") + " to value " + tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlValue")
                        .Add("@ErrorReference", SqlDbType.VarChar).Value = "Control name: " + tempds.Tables("StandardSecurityPermissions").Rows(i).Item("ControlName")
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@Comment", SqlDbType.VarChar).Value = ex.ToString.Substring(0, 300)
                    End With
                    If String.IsNullOrEmpty(DivisionID) Then
                        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    Else
                        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = DivisionID
                    End If
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Try
            End If
        Next
    End Sub

    ''handles setting the properties of a given control/ToolStripMenuItem
    Private Sub SetControlProperty(ByRef matchedControl As Object, ByVal controlProperty As String, ByVal controlValue As String, Optional ByVal columnName As String = "none")
        If TypeOf (matchedControl) Is Control Or TypeOf (matchedControl) Is ToolStripMenuItem Then
            Select Case controlProperty
                Case "Enabled"
                    matchedControl.Enabled = Convert.ToBoolean(controlValue)
                Case "Visible"
                    matchedControl.Visible = Convert.ToBoolean(controlValue)
                Case "ReadOnly"
                    matchedControl.ReadOnly = Convert.ToBoolean(controlValue)
                Case "Text"
                    matchedControl.Text = controlValue
            End Select
        ElseIf TypeOf (matchedControl) Is DataGridView Then
            Dim dgv As DataGridView = matchedControl
            If dgv.Columns.Contains(columnName) AndAlso Not columnName.Equals("none") Then
                Select Case controlProperty
                    Case "Visible"
                        dgv.Columns(columnName).Visible = Convert.ToBoolean(controlValue)
                    Case "ReadOnly"
                        dgv.Columns(columnName).ReadOnly = Convert.ToBoolean(controlValue)
                End Select
            Else
                Select Case controlProperty
                    Case "Visible"
                        dgv.Visible = Convert.ToBoolean(controlValue)
                    Case "ReadOnly"
                        dgv.ReadOnly = Convert.ToBoolean(controlValue)
                End Select
            End If
        End If
    End Sub

    Public Function FindControl(ByVal controlName As String, ByVal ctrl As Object) As Object
        ''makes sure we are not trying to process nothing
        If ctrl Is Nothing Then
            Return Nothing
        End If
        If TypeOf (ctrl) Is MenuStrip Then
            Dim mnu As System.Windows.Forms.MenuStrip = ctrl
            If mnu.Items.Count > 0 Then
                For Each mnuItem As ToolStripMenuItem In mnu.Items
                    If mnuItem.DropDownItems.Count > 0 Then
                        For Each subMnuItem As ToolStripMenuItem In mnuItem.DropDownItems
                            If subMnuItem.Name.Equals(controlName) Then
                                Return subMnuItem
                            End If
                        Next
                    End If
                Next
            End If
            Return Nothing
        ElseIf TypeOf (ctrl) Is Control Then
            ''check to see if the control is the one we need, if not will dig a bit deeper
            If ctrl.Name.Equals(controlName) Then
                Return ctrl
            Else
                If ctrl.Controls.Count > 0 Then
                    For Each subCtrl As Control In ctrl.Controls
                        Dim foundCtrl As Object = FindControl(controlName, subCtrl)
                        If foundCtrl IsNot Nothing Then
                            Return foundCtrl
                        End If
                    Next
                End If
                Return Nothing
            End If
        End If
        Return Nothing
    End Function

    Public Sub CheckBinNumber(ByRef sender As System.Windows.Forms.ComboBox)
        If ShouldCorrectBin(sender) Then
            Dim pos As Integer = 0
            Dim notFound As Boolean = True
            While pos < sender.Text.Length And notFound
                If IsNumeric(sender.Text(pos)) Then
                    notFound = False
                Else
                    pos += 1
                End If
            End While
            Dim rw As String = sender.Text.Substring(0, pos)
            Dim position As String = sender.Text.Substring(pos)
            ''Front loads the zeros that are required
            While position.Length < 3
                position = "0" + position
            End While
            ''check to make sure it didn't just create the position 0
            If Val(position) = 0 Then
                position = "001"
            End If
            sender.Text = rw + position
        End If
    End Sub

    Public Sub CheckBinNumber(ByRef sender As System.Windows.Forms.TextBox)
        If ShouldCorrectBin(sender) Then
            Dim pos As Integer = 0
            Dim notFound As Boolean = True
            While pos < sender.Text.Length And notFound
                If IsNumeric(sender.Text(pos)) Then
                    notFound = False
                Else
                    pos += 1
                End If
            End While
            Dim rw As String = sender.Text.Substring(0, pos)
            Dim position As String = sender.Text.Substring(pos)
            ''Front loads the zeros that are required
            While position.Length < 3
                position = "0" + position
            End While
            ''check to make sure it didn't just create the position 0
            If Val(position) = 0 Then
                position = "001"
            End If
            sender.Text = rw + position
        End If
    End Sub

    Private Function ShouldCorrectBin(ByRef sender As System.Windows.Forms.ComboBox) As Boolean
        If String.IsNullOrEmpty(sender.Text) Then
            Return False
        End If
        If sender.Text.Length >= 5 Then
            Return False
        End If
        Return True
    End Function

    Private Function ShouldCorrectBin(ByRef sender As System.Windows.Forms.TextBox) As Boolean
        If String.IsNullOrEmpty(sender.Text) Then
            Return False
        End If
        If sender.Text.Length >= 5 Then
            Return False
        End If
        Return True
    End Function
End Module
