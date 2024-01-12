Public Class SuggestDescriptionAPI
    Dim cboPartDescription As System.Windows.Forms.ComboBox
    Dim cboPartNumber As System.Windows.Forms.ComboBox
    Dim lst As System.Windows.Forms.ListBox
    Dim ds As System.Data.DataSet
    Dim PartDescriptionFillSuggest As New System.ComponentModel.BackgroundWorker
    Dim PartDescriptionFillSuggest1 As New System.ComponentModel.BackgroundWorker
    Dim bwNeeded As New neededItems
    ''custom structure for the background worker
    Public Structure neededItems
        Dim height As Integer
        Dim textHeight As Integer
        Dim text As String
        Dim suggestions As List(Of String)
        Dim charCount As Integer
        Dim isVisible As Boolean
    End Structure
    Public Sub New()
        SetupBGWK()
    End Sub
    Public Sub New(ByRef cb As System.Windows.Forms.ComboBox, ByRef ls As System.Windows.Forms.ListBox, Optional ByRef cboPart As System.Windows.Forms.ComboBox = Nothing, Optional ByRef tmpDS As DataSet = Nothing)
        cboPartDescription = cb
        cboPartDescription.AutoCompleteSource = AutoCompleteSource.None
        cboPartDescription.AutoCompleteMode = AutoCompleteMode.None
        ''Adds the required handlers for the part description. These shouldn't interfere with any current handlers unless they are for suggestion, they may cause issues.
        AddHandler cboPartDescription.TextChanged, AddressOf cbo_TextChanged
        AddHandler cboPartDescription.KeyDown, AddressOf cbo_KeyDown
        AddHandler cboPartDescription.Leave, AddressOf cbo_DropDown
        AddHandler cboPartDescription.DropDown, AddressOf cbo_DropDown
        AddHandler cboPartDescription.PreviewKeyDown, AddressOf cbo_PreviewKeyDown

        lst = ls
        AddHandler lst.MouseUp, AddressOf lst_MouseUp
        AddHandler lst.MouseDown, AddressOf lst_MouseDown
        cboPartNumber = cboPart
        ds = tmpDS
        SetupBGWK()
    End Sub

    Private Sub SetupBGWK()
        PartDescriptionFillSuggest.WorkerSupportsCancellation = True
        PartDescriptionFillSuggest.WorkerReportsProgress = True
        AddHandler PartDescriptionFillSuggest.DoWork, AddressOf FillSuggestDoWork
        AddHandler PartDescriptionFillSuggest.RunWorkerCompleted, AddressOf FillSuggestRunWorkerCompleted
        PartDescriptionFillSuggest1.WorkerSupportsCancellation = True
        PartDescriptionFillSuggest1.WorkerReportsProgress = True
    End Sub

    Public Sub SetDS(ByRef dat As System.Data.DataSet)
        ds = dat
    End Sub

    Public Sub KeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        ''selects the function to do based on the key that is pressed
        Select Case e.KeyCode
            Case Keys.Down
                cboSearchDescriptionDownPress()
                e.Handled = True
            Case Keys.Up
                cboSearchDescriptionUpPress()
                e.Handled = True
            Case Keys.Enter
                cboPartDescriptionEnterPress()
                e.Handled = True
            Case Keys.Escape
                If lst.Visible Then
                    lst.Hide()
                End If
                e.Handled = True
        End Select
    End Sub

    Private Sub cboSearchDescriptionDownPress()
        ''checks to see if the suggestion list is open
        If lst.Visible Then
            ''checks to make sure that we are not at the end of the items in the selection list
            If lst.SelectedIndex < lst.Items.Count - 1 Then
                lst.SelectedIndex = lst.SelectedIndex + 1
            Else
                lst.SelectedIndex = lst.Items.Count - 1
            End If
        Else
            cboPartDescription.SelectedIndex = cboPartDescription.SelectedIndex + 1
        End If
    End Sub

    Private Sub cboSearchDescriptionUpPress()
        ''checks to see if the suggestion list is open
        If lst.Visible Then
            ''checks to see what items is currently selected and if it is the first item will not allow the selection to be hcnaged
            If lst.SelectedIndex > 0 Then
                lst.SelectedIndex = lst.SelectedIndex - 1
            Else
                lst.SelectedIndex = 0
            End If
        Else
            ''will change the selection in the combobox as long as the selection is not -1
            If cboPartDescription.SelectedIndex >= 0 Then
                cboPartDescription.SelectedIndex = cboPartDescription.SelectedIndex - 1
            Else
                cboPartDescription.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub cboPartDescriptionEnterPress()
        If lst.Visible Then
            cboPartDescription.Text = lst.SelectedItem
            cboPartDescription.SelectAll()
            lst.Hide()
            cboPartDescription.Focus()
        Else
            If cboPartDescription.SelectedIndex <> cboPartDescription.SelectedIndex Then
                If cboPartDescription.SelectedIndex = -1 And String.IsNullOrEmpty(cboPartDescription.Text) Then
                    cboPartDescription.SelectedIndex = cboPartDescription.SelectedIndex
                End If
            End If
            ''selects the next control after the control that was given
            cboPartDescription.SelectNextControl(cboPartDescription, True, False, True, True)
        End If
    End Sub

    Public Sub PreviewKeyDown(ByRef e As System.Windows.Forms.PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Tab Then
            If lst.Visible Then
                cboPartDescription.Text = lst.SelectedItem
            Else
                If cboPartNumber IsNot Nothing Then
                    If cboPartDescription.SelectedIndex <> cboPartNumber.SelectedIndex Then
                        If cboPartDescription.SelectedIndex = -1 And String.IsNullOrEmpty(cboPartDescription.Text) Then
                            cboPartNumber.SelectedIndex = cboPartDescription.SelectedIndex
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub TextChanged()
        If canSearchSuggest() Then
            ''checks to make sure that there isn't a thread working already, and if there is will cancel it
            If PartDescriptionFillSuggest.IsBusy() Then
                PartDescriptionFillSuggest.CancelAsync()
            End If
            ''checks the lengths of text in the and makes sure that it is focused and not dropped down
            lst.Items.Clear()
            bwNeeded.suggestions = New List(Of String)
            bwNeeded.text = cboPartDescription.Text
            bwNeeded.textHeight = lst.ItemHeight
            bwNeeded.height = lst.Height
            bwNeeded.charCount = 0
            bwNeeded.isVisible = lst.Visible
            lst.Hide()
            Try
                PartDescriptionFillSuggest.RunWorkerAsync()
            Catch ex As System.Exception

            End Try
        Else
            If lst.Visible Then
                lst.Hide()
            End If
        End If
    End Sub

    Private Function canSearchSuggest() As Boolean
        If cboPartDescription.Text.Length = 0 Then
            Return False
        End If
        If cboPartDescription.Focused() = False Then
            Return False
        End If
        If cboPartDescription.DroppedDown Then
            Return False
        End If
        Return True
    End Function

    Private Sub FillSuggestDoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        processInput()
    End Sub

    Private Sub FillSuggestRunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        processCompleted()
    End Sub

    Private Sub processInput()
        If ds IsNot Nothing Then
            If ds.Tables("ItemList") IsNot Nothing Then
                For Each rw As DataRow In ds.Tables("ItemList").Rows
                    ''check to see if there is a cancellation pending
                    If PartDescriptionFillSuggest.CancellationPending = False Then
                        Dim toTest As String = rw.Item("ShortDescription")
                        If bwNeeded.text.Length <= toTest.Length Then
                            Dim part As String = toTest.Substring(0, bwNeeded.text.Length).ToUpper
                            Dim textUpper As String = bwNeeded.text.ToUpper()
                            ''checks text in the row to see if it is all upper or lower
                            If textUpper.Equals(part) Then
                                bwNeeded.suggestions.Add(toTest)
                                If bwNeeded.charCount < toTest.Length Then
                                    bwNeeded.charCount = toTest.Length
                                End If
                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next
            End If
        End If

        ''checks to see if the suggestion box is visible or not, and if not will make it visible
        If bwNeeded.suggestions.Count >= 1 Then
            If bwNeeded.suggestions.Count >= 5 Then
                If bwNeeded.suggestions.Count > 15 Then
                    bwNeeded.height = 15 * 15
                Else
                    bwNeeded.height = 15 * 5
                End If

            Else
                If bwNeeded.suggestions.Count > 1 Then
                    bwNeeded.height = 15 * bwNeeded.suggestions.Count
                Else
                    bwNeeded.height = 22 * bwNeeded.suggestions.Count
                End If
            End If
            If bwNeeded.isVisible = False Then
                bwNeeded.isVisible = True
            End If
        Else
            If bwNeeded.isVisible = True Then
                bwNeeded.isVisible = False
            End If
        End If
    End Sub

    Private Sub processCompleted()
        lst.Height = bwNeeded.height
        ''if the character count is less than will make it 10
        If bwNeeded.charCount < 10 Then
            bwNeeded.charCount = 10
        End If
        lst.Width = bwNeeded.charCount * (lst.Font.Size * 0.9)
        ''makes sure that there are suggestions
        If bwNeeded.suggestions.Count > 0 Then
            For Each itm As String In bwNeeded.suggestions
                lst.Items.Add(itm)
            Next
            ''checks to see if the first item matches the one that was entered and will toggle the list accordingly
            If cboPartDescription.Text = lst.Items(0) Then
                If lst.Visible Then
                    lst.Hide()
                End If
            Else
                lst.Visible = bwNeeded.isVisible
                lst.SelectedIndex = 0
            End If
        Else
            lst.Hide()
        End If
    End Sub

    Public Sub ListMouseUp()
        cboPartDescription.Text = lst.SelectedItem
        cboPartDescription.SelectAll()
        cboPartDescription.Focus()
        lst.Hide()
    End Sub

    Private Sub cbo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextChanged()
    End Sub

    Private Sub cbo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        KeyDown(e)
    End Sub
    Private Sub lst_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ListMouseUp()
    End Sub

    Private Sub lst_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim index As Integer = lst.IndexFromPoint(e.Location)
        If index > 0 Then
            lst.SelectedItem = lst.Items(index)
        End If
    End Sub
    Private Sub cbo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''checks to see if the suggestion list got the focus
        If lst.Focused = False Then
            lst.Hide()
        End If
    End Sub
    ''resets the suggestion based on when the dropdown is open
    Private Sub cbo_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lst.Visible Then
            lst.Hide()
        End If
    End Sub

    Private Sub cbo_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        PreviewKeyDown(e)
    End Sub
End Class
