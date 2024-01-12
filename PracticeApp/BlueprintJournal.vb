Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class BlueprintJournal
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Dim ds, ds1 As DataSet
    Dim isLoaded As Boolean = False
    Dim AddEntryForm As BlueprintJournalAddEntry
    Dim EditEntryForm As BlueprintJournalEditEntry
    Dim PictureFullScreen As ViewPictureFullScreen

    Private Const BlueprintJournalRootFolder As String = "\\TFP-FS\TransferData\Blueprint Journal"
    Private Const NonConformanceRootFolder As String = "\\TFP-FS\TransferData\NonConformance"

    Private Class picData
        Public img As Image
        Public FileName As String
        Public Sub New(ByVal inImg As Image, ByVal nme As String)
            img = inImg
            FileName = nme
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
        LoadBlueprints()
        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True
        usefulFunctions.LoadSecurity(Me)

        SetJournalPictureControls()
        SetJournalScrollBars()
        SetNonConformancePictureControls()
        SetNonConformanceScrollBars()
    End Sub
    Public Sub New(ByVal passedBP As String)
        InitializeComponent()
        LoadBlueprints()
        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True

        cboBlueprint.Text = passedBP
        usefulFunctions.LoadSecurity(Me)

        SetJournalPictureControls()
        SetJournalScrollBars()
        SetNonConformancePictureControls()
        SetNonConformanceScrollBars()
    End Sub

    Private Sub LoadBlueprints()
        cmd = New SqlCommand("SELECT DISTINCT(BlueprintNumber) FROM (SELECT BlueprintNumber FROM LotNumber UNION SELECT BlueprintNumber FROM FOXTable) as tmp", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            cboBlueprint.Items.Add(reader.Item(0))
        End While
        reader.Close()
    End Sub

    Private Sub cboBlueprint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBlueprint.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            lstJournalEntries.DataSource = Nothing
            lstNonConformanceEntries.DataSource = Nothing
            ClearNonConformanceFields()
            ClearBlueprintJournalEntries()
            isLoaded = True
            If cboBlueprint.SelectedIndex <> -1 Then
                ds = New DataSet()
                ds1 = New DataSet()
                cmd = New SqlCommand("SELECT EntryKey, EntryTitle, EntryDetails, EntryDate, LastUpdated FROM BlueprintJournal WHERE BlueprintNumber = @BlueprintNumber Order by EntryDate", con)
                cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBlueprint.Text

                Dim adap As New SqlDataAdapter(cmd)

                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(ds, "BlueprintJournal")

                cmd.CommandText = "SELECT QCTransactionNumber, QCDate, LotNumber, FOXNumber, PartNumber, LongDescription, NonConformanceReason, ReworkInstructions, Comment FROM QCHoldAdjustment WHERE LotNumber in (SELECT LotNumber FROM LotNumber WHERE BlueprintNumber = @BlueprintNumber) OR FOXNumber in (SELEct FOXNumber FROM FOXTable where BlueprintNumber = @BlueprintNumber)"
                adap.SelectCommand = cmd
                adap.Fill(ds1, "QCHoldAdjustment")
                con.Close()

                lstJournalEntries.DisplayMember = "EntryTitle"
                lstNonConformanceEntries.DisplayMember = "QCTransactionNumber"
                lstJournalEntries.DataSource = ds.Tables("BlueprintJournal")
                lstNonConformanceEntries.DataSource = ds1.Tables("QCHoldAdjustment")

                If lstJournalEntries.Items.Count > 0 Then
                    cmdEditSelected.Enabled = True
                Else
                    cmdEditSelected.Enabled = False
                End If

                cmdAddEntry.Enabled = True
            Else
                cmdEditSelected.Enabled = False
                cmdAddEntry.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Hide()
    End Sub

    Private Sub lstNonConformanceEntries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstNonConformanceEntries.SelectedIndexChanged
        If isLoaded Then
            ClearNonConformanceFields()
            If lstNonConformanceEntries.SelectedIndex <> -1 Then
                If Not IsDBNull(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("Comment")) Then
                    lblNonConformanceComment.Text = ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("Comment")
                Else
                    lblNonConformanceComment.Text = ""
                End If
                If Not IsDBNull(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("QCDate")) Then
                    lblNonConformanceDate.Text = Convert.ToDateTime(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("QCDate")).ToShortDateString()
                Else
                    lblNonConformanceDate.Text = ""
                End If
                If Not IsDBNull(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("FOXNumber")) Then
                    lblNonConformanceFOXNumber.Text = ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("FOXNumber")
                Else
                    lblNonConformanceFOXNumber.Text = ""
                End If
                If Not IsDBNull(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("LongDescription")) Then
                    lblNonConformancePartDescription.Text = ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("LongDescription")
                Else
                    lblNonConformancePartDescription.Text = ""
                End If
                If Not IsDBNull(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("PartNumber")) Then
                    lblNonConformancePartNumber.Text = ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("PartNumber")
                Else
                    lblNonConformancePartNumber.Text = ""
                End If
                If Not IsDBNull(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("NonConformanceReason")) Then
                    lblNonConformanceReason.Text = ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("NonConformanceReason")
                Else
                    lblNonConformanceReason.Text = ""
                End If
                If Not IsDBNull(ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("ReworkInstructions")) Then
                    lblNonConformanceReworkInstructions.Text = ds1.Tables("QCHoldAdjustment").Rows(lstNonConformanceEntries.SelectedIndex).Item("ReworkInstructions")
                Else
                    lblNonConformanceReworkInstructions.Text = ""
                End If

                cmd = New SqlCommand("SELECT isnull(LotNumber, 0) FROM QCHoldAdjustmentLotNumber WHERE QCTransactionNumber = @QCTransactionNumber", con)
                cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = Val(lstNonConformanceEntries.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    Dim isFirst As Boolean = True
                    While reader.Read()
                        If isFirst Then
                            isFirst = False
                            lblNonConformanceLotNumber.Text = reader.Item(0)
                        Else
                            lblNonConformanceLotNumber.Text += ", " + reader.Item(0)
                        End If
                    End While
                End If
                reader.Close()
                con.Close()
                LoadNonConformancePictures()
            End If
        End If
    End Sub

    Private Sub LoadNonConformancePictures()
        ''Gets the directory info for the root directory of blueprint journal directories
        Dim dir As New System.IO.DirectoryInfo(NonConformanceRootFolder)

        Dim RecordDir() As System.IO.DirectoryInfo = dir.GetDirectories(lstNonConformanceEntries.Text, IO.SearchOption.TopDirectoryOnly)
        If RecordDir.Count > 0 Then
            Dim foundFileInfo As New List(Of System.IO.FileInfo)
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.jpg"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.bmp"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.gif"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.jpeg"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.png"))
            foundFileInfo.AddRange(RecordDir(0).GetFiles("*.tiff"))
            foundFileInfo.Sort(Function(x As System.IO.FileInfo, y As System.IO.FileInfo) x.LastWriteTime < y.LastWriteTime)

            isLoaded = False
            ''Loads all the pictures into the DGV
            For Each fle As System.IO.FileInfo In foundFileInfo
                Dim picCell As New DataGridViewImageCell()
                Dim tmpImg As picData
                Using Str As System.IO.Stream = System.IO.File.OpenRead(fle.FullName)
                    tmpImg = New picData(Image.FromStream(Str), fle.FullName)
                End Using
                picCell.Value = tmpImg.img.GetThumbnailImage(150, 150, Nothing, IntPtr.Zero)
                picCell.Tag = tmpImg
                dgvNonConformancePictures.Rows.Add()
                dgvNonConformancePictures.Rows(dgvNonConformancePictures.Rows.Count - 1).Height = 150
                dgvNonConformancePictures.Rows(dgvNonConformancePictures.Rows.Count - 1).Cells(0) = picCell
            Next
            isLoaded = True
            DisposeNonConformancePictureShown()
            ''Selects the first picture if there is one
            If dgvNonConformancePictures.Rows.Count > 0 Then
                dgvNonConformancePictures.CurrentCell = dgvNonConformancePictures.Rows(0).Cells(0)
                dgvNonConformancePictures.Rows(0).Cells(0).Selected = True
                Dim resizeHeightPercent As Double = 0
                Dim tmpImg As Image = DirectCast(dgvNonConformancePictures.Rows(0).Cells(0).Tag, picData).img.Clone()
                If tmpImg.Height > picbxNonConformancePicture.Height Then
                    resizeHeightPercent = Convert.ToDouble(picbxNonConformancePicture.Height) / Convert.ToDouble(tmpImg.Height)
                Else
                    resizeHeightPercent = 1
                End If

                picbxNonConformancePicture.Image = tmpImg.GetThumbnailImage(Convert.ToInt32(tmpImg.Width * resizeHeightPercent), Convert.ToInt32(tmpImg.Height * resizeHeightPercent), Nothing, IntPtr.Zero)
            Else
                picbxNonConformancePicture.Image = Nothing
            End If
            vscrlNonConformancePicture.Value = 0
            hscrlNonConformancePicture.Value = 0
        End If
        SetNonConformancePictureControls()
        SetNonConformanceScrollBars()
    End Sub

    Private Sub ClearNonConformanceFields()
        lblNonConformanceComment.Text = ""
        lblNonConformanceDate.Text = ""
        lblNonConformanceLotNumber.Text = ""
        lblNonConformanceFOXNumber.Text = ""
        lblNonConformancePartDescription.Text = ""
        lblNonConformancePartNumber.Text = ""
        lblNonConformanceReason.Text = ""
        lblNonConformanceReworkInstructions.Text = ""
        DisposeNonConformancePictureShown()
        dgvNonConformancePictures.Rows.Clear()
    End Sub

    Private Sub ClearBlueprintJournalEntries()
        lblDateEntered.Text = ""
        lblLastUpdated.Text = ""
        lblDetails.Text = ""
        DisposeJournalPictureShown()
        dgvPictureList.Rows.Clear()
    End Sub

    Private Sub BlueprintJournal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub lstEntries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstJournalEntries.SelectedIndexChanged
        If isLoaded Then
            ClearBlueprintJournalEntries()
            If lstJournalEntries.SelectedIndex <> -1 Then
                lblDateEntered.Text = Convert.ToDateTime(ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryDate")).ToShortDateString()
                lblLastUpdated.Text = Convert.ToDateTime(ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("LastUpdated")).ToShortDateString()
                lblDetails.Text = ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryDetails")

                ''Gets the directory info for the root directory of blueprint journal directories
                Dim dir As New System.IO.DirectoryInfo(BlueprintJournalRootFolder)

                Dim bpDir() As System.IO.DirectoryInfo = dir.GetDirectories(cboBlueprint.Text, IO.SearchOption.TopDirectoryOnly)
                If bpDir.Count > 0 Then
                    Dim entryDir() As System.IO.DirectoryInfo = bpDir(0).GetDirectories(ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryKey"), IO.SearchOption.TopDirectoryOnly)
                    If entryDir.Count > 0 Then
                        Dim foundFileInfo As New List(Of System.IO.FileInfo)
                        foundFileInfo.AddRange(entryDir(0).GetFiles("*.jpg"))
                        foundFileInfo.AddRange(entryDir(0).GetFiles("*.bmp"))
                        foundFileInfo.AddRange(entryDir(0).GetFiles("*.gif"))
                        foundFileInfo.AddRange(entryDir(0).GetFiles("*.jpeg"))
                        foundFileInfo.AddRange(entryDir(0).GetFiles("*.png"))
                        foundFileInfo.AddRange(entryDir(0).GetFiles("*.tiff"))
                        foundFileInfo.Sort(Function(x As System.IO.FileInfo, y As System.IO.FileInfo) x.LastWriteTime < y.LastWriteTime)

                        isLoaded = False
                        ''Loads all found entries into the DGV
                        For Each fle As System.IO.FileInfo In foundFileInfo
                            Dim picCell As New DataGridViewImageCell()
                            Dim tmpImg As picData
                            Using Str As System.IO.Stream = System.IO.File.OpenRead(fle.FullName)
                                tmpImg = New picData(Image.FromStream(Str), fle.FullName)
                            End Using
                            picCell.Value = tmpImg.img.GetThumbnailImage(150, 150, Nothing, IntPtr.Zero)
                            picCell.Tag = tmpImg
                            dgvPictureList.Rows.Add()
                            dgvPictureList.Rows(dgvPictureList.Rows.Count - 1).Height = 150
                            dgvPictureList.Rows(dgvPictureList.Rows.Count - 1).Cells(0) = picCell
                        Next
                        isLoaded = True
                        DisposeJournalPictureShown()
                        ''Selects the first entry if there is one
                        If dgvPictureList.Rows.Count > 0 Then
                            dgvPictureList.CurrentCell = dgvPictureList.Rows(0).Cells(0)
                            dgvPictureList.Rows(0).Cells(0).Selected = True
                            Dim tmpImg As Image = DirectCast(dgvPictureList.Rows(0).Cells(0).Tag, picData).img.Clone()
                            Dim resizeHeightPercent As Double = 0
                            If tmpImg.Height > picbxJournalPicture.Height Then
                                resizeHeightPercent = Convert.ToDouble(picbxJournalPicture.Height) / Convert.ToDouble(tmpImg.Height)
                            Else
                                resizeHeightPercent = 1
                            End If

                            picbxJournalPicture.Image = tmpImg.GetThumbnailImage(Convert.ToInt32(tmpImg.Width * resizeHeightPercent), Convert.ToInt32(tmpImg.Height * resizeHeightPercent), Nothing, IntPtr.Zero)
                        Else
                            picbxJournalPicture.Image = Nothing
                        End If
                        vscrlJournalPicture.Value = 0
                        hscrlJournalPicture.Value = 0
                    End If
                End If
                cmdEditSelected.Enabled = True
            Else
                cmdEditSelected.Enabled = False
            End If
            SetJournalPictureControls()
            SetJournalScrollBars()
        End If
    End Sub
    ''gives garbage collection go ahead to clean the image up. ***MUST BE DONE BEFORE DELETING A DISPLAYED IMAGE***
    Private Sub DisposeJournalPictureShown()
        If picbxJournalPicture.Image IsNot Nothing Then
            picbxJournalPicture.Image.Dispose()
            picbxJournalPicture.Image = Nothing
        End If
    End Sub
    ''gives garbage collection go ahead to clean the image up. ***MUST BE DONE BEFORE DELETING A DISPLAYED IMAGE***
    Private Sub DisposeNonConformancePictureShown()
        If picbxNonConformancePicture.Image IsNot Nothing Then
            picbxNonConformancePicture.Image.Dispose()
            picbxNonConformancePicture.Image = Nothing
        End If
    End Sub
    ''Handles setting the controls based on if there is an image selected
    Private Sub SetJournalPictureControls()
        If picbxJournalPicture.Image Is Nothing Then
            cmdPrintJournalImage.Enabled = False
            cmdFullScreenJournal.Enabled = False
        Else
            cmdPrintJournalImage.Enabled = True
            cmdFullScreenJournal.Enabled = True
        End If
    End Sub

    Private Sub cmdAddEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddEntry.Click
        If CanAddEntry() Then
            AddEntryForm = New BlueprintJournalAddEntry(cboBlueprint.Text)
            AddHandler AddEntryForm.VisibleChanged, AddressOf AddEntryForm_VisibilityChanged
            AddEntryForm.Show()
        End If
    End Sub

    Private Function CanAddEntry() As Boolean
        If String.IsNullOrEmpty(cboBlueprint.Text) Then
            MessageBox.Show("You must select a blueprint number", "Select a blueprint number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboBlueprint.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid blueprint number", "Select a valid blueprint number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Public Sub AddEntryForm_VisibilityChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If AddEntryForm.Visible Then
            Me.Enabled = False
        Else
            If AddEntryForm.DialogResult = System.Windows.Forms.DialogResult.OK Then
                ReLoadEntryData()
            End If
            AddEntryForm.Close()
            AddEntryForm = Nothing
            Me.Enabled = True
            Me.BringToFront()
        End If
    End Sub

    Private Sub BlueprintJournal_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If AddEntryForm IsNot Nothing Then
            If AddEntryForm.Visible Then
                AddEntryForm.BringToFront()
            ElseIf EditEntryForm IsNot Nothing Then
                If EditEntryForm.Visible Then
                    EditEntryForm.BringToFront()
                Else
                    Me.BringToFront()
                End If
            Else
                Me.BringToFront()
            End If
        ElseIf EditEntryForm IsNot Nothing Then
            If EditEntryForm.Visible Then
                EditEntryForm.BringToFront()
            Else
                Me.BringToFront()
            End If
        Else
            Me.BringToFront()
        End If
    End Sub

    Public Sub EditEntryForm_VisibilityChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditEntryForm.Visible Then
            Me.Enabled = False
        Else
            ReLoadEntryData()
            EditEntryForm.Close()
            EditEntryForm = Nothing
            Me.Enabled = True
            Me.BringToFront()
        End If
    End Sub

    Private Sub dgvPictureList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPictureList.CellEnter
        If isLoaded Then
            DisposeJournalPictureShown()
            If e.RowIndex <> -1 Then
                Dim tmpImg As Image = DirectCast(dgvPictureList.Rows(e.RowIndex).Cells(0).Tag, picData).img.Clone()

                Dim resizeHeightPercent As Double = 0
                If tmpImg.Height > picbxJournalPicture.Height Then
                    resizeHeightPercent = Convert.ToDouble(picbxJournalPicture.Height) / Convert.ToDouble(tmpImg.Height)
                Else
                    resizeHeightPercent = 1
                End If

                picbxJournalPicture.Image = tmpImg.GetThumbnailImage(Convert.ToInt32(tmpImg.Width * resizeHeightPercent), Convert.ToInt32(tmpImg.Height * resizeHeightPercent), Nothing, IntPtr.Zero)
            Else
                picbxJournalPicture.Image = Nothing
            End If
            SetJournalPictureControls()
            SetJournalScrollBars()
        End If
    End Sub

    Private Sub SetJournalScrollBars()
        If picbxJournalPicture.Image IsNot Nothing Then
            ''checks the width of the current picture and will adjust the scroll bar accordingly
            If picbxJournalPicture.Image.Width > picbxJournalPicture.Width Then
                hscrlJournalPicture.Maximum = picbxJournalPicture.Image.Width - picbxJournalPicture.Width
                hscrlJournalPicture.Enabled = True
            Else
                hscrlJournalPicture.Maximum = 0
                hscrlJournalPicture.Enabled = False
            End If
            ''checks the height of the current picture and will adjust the scroll bar accordingly
            If picbxJournalPicture.Image.Height > picbxJournalPicture.Height Then
                vscrlJournalPicture.Maximum = picbxJournalPicture.Image.Height - picbxJournalPicture.Height
                vscrlJournalPicture.Enabled = True
            Else
                vscrlJournalPicture.Maximum = 0
                vscrlJournalPicture.Enabled = False
            End If
        Else
            hscrlJournalPicture.Maximum = 0
            hscrlJournalPicture.Enabled = False
            vscrlJournalPicture.Maximum = 0
            vscrlJournalPicture.Enabled = False
        End If

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboBlueprint.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBlueprint.Text) Then
            cboBlueprint.Text = ""
        End If
        ClearNonConformanceFields()
        ClearBlueprintJournalEntries()
    End Sub

    Private Sub cmdEditSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditSelected.Click
        If lstJournalEntries.SelectedIndex <> -1 Then
            DisposeJournalPictureShown()
            picbxJournalPicture.Image = Nothing
            dgvPictureList.Rows.Clear()
            EditEntryForm = New BlueprintJournalEditEntry(ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryKey"), cboBlueprint.Text)
            AddHandler EditEntryForm.VisibleChanged, AddressOf EditEntryForm_VisibilityChanged
            EditEntryForm.Show()
        Else
            MessageBox.Show("You must select an entry to edit", "Select an entr", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ReLoadEntryData()
        Dim entryIndex As Integer = lstJournalEntries.SelectedIndex
        isLoaded = False
        lstJournalEntries.DataSource = Nothing
        ClearBlueprintJournalEntries()
        isLoaded = True
        ds = New DataSet()
        cmd = New SqlCommand("SELECT EntryKey, EntryTitle, EntryDetails, EntryDate, LastUpdated FROM BlueprintJournal WHERE BlueprintNumber = @BlueprintNumber Order by EntryDate", con)
        cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBlueprint.Text

        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "BlueprintJournal")
        con.Close()

        lstJournalEntries.DisplayMember = "EntryTitle"
        lstJournalEntries.DataSource = ds.Tables("BlueprintJournal")
        If lstJournalEntries.Items.Count > entryIndex Then
            If entryIndex = -1 Then
                lstJournalEntries.SelectedIndex = 0
            Else
                lstJournalEntries.SelectedIndex = entryIndex
            End If
        Else
            If lstJournalEntries.Items.Count > 0 Then
                lstJournalEntries.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub HandleScroll(ByVal sender As System.Object, ByVal e As ScrollEventArgs) Handles hscrlJournalPicture.Scroll, vscrlJournalPicture.Scroll
        If picbxJournalPicture.Image IsNot Nothing Then
            Dim graps As Graphics = picbxJournalPicture.CreateGraphics()

            Dim picbxWidth As Integer = picbxJournalPicture.Width
            Dim picbxHeight As Integer = picbxJournalPicture.Height

            Dim x As Integer
            Dim y As Integer
            ''check to see how the user scrolled
            If (e.ScrollOrientation = ScrollOrientation.HorizontalScroll) Then
                x = e.NewValue
                y = vscrlJournalPicture.Value
            Else
                x = hscrlJournalPicture.Value
                y = e.NewValue
            End If
            ''redraws the image *I think it just draws the image on the image that was already there without clearing the draw space
            graps.DrawImage(picbxJournalPicture.Image, New System.Drawing.Rectangle(0, 0, picbxWidth, picbxHeight), New System.Drawing.Rectangle(x, y, picbxWidth, picbxHeight), GraphicsUnit.Pixel)

            picbxJournalPicture.Update()
        End If
    End Sub

    Private Sub cmdPrintJournalImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintJournalImage.Click
        Dim pd As New PrintDialog()
        Dim doc As New System.Drawing.Printing.PrintDocument()
        pd.UseEXDialog = True
        pd.Document = doc
        ''opens the print dialog and if the user hits print will print the image
        If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
            doc.Print()
        End If
    End Sub

    Private Function CanPrintJournalImage() As Boolean
        If picbxJournalPicture.Image Is Nothing Then
            MessageBox.Show("There is no image selected to print", "Select an image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintJournalDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim xbound As Integer = e.Graphics.VisibleClipBounds.Width
        Dim ybound As Integer = e.Graphics.VisibleClipBounds.Height

        ''checks to see which bound is smaller and will use the smaller bound for the image for width
        If picbxJournalPicture.Image.Width < e.Graphics.VisibleClipBounds.Width Then
            xbound = picbxJournalPicture.Image.Width
        End If
        ''checks to see which bound is smaller and will use the smaller bound for the image for height
        If picbxJournalPicture.Image.Height < e.Graphics.VisibleClipBounds.Height Then
            ybound = picbxJournalPicture.Image.Height
        End If
        ''draws the image on the document being printed
        e.Graphics.DrawImage(DirectCast(dgvPictureList.Rows(dgvPictureList.CurrentCell.RowIndex).Cells(0).Tag, picData).img.Clone(), New System.Drawing.Rectangle(0, 0, xbound, ybound))
    End Sub

    Private Sub cmdFullScreenJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFullScreenJournal.Click
        If CanViewFullScreen() Then
            PictureFullScreen = New ViewPictureFullScreen(DirectCast(dgvPictureList.Rows(dgvPictureList.CurrentCell.RowIndex).Cells(0).Tag, picData).img.Clone())
            PictureFullScreen.Show()
        End If
    End Sub

    Private Function CanViewFullScreen() As Boolean
        If picbxJournalPicture.Image Is Nothing Then
            MessageBox.Show("There is no image selected to view", "Select an image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub NonConformance_HandleScroll(ByVal sender As System.Object, ByVal e As ScrollEventArgs) Handles hscrlNonConformancePicture.Scroll, vscrlNonConformancePicture.Scroll
        If picbxNonConformancePicture.Image IsNot Nothing Then
            Dim graps As Graphics = picbxNonConformancePicture.CreateGraphics()

            Dim picbxWidth As Integer = picbxNonConformancePicture.Width
            Dim picbxHeight As Integer = picbxNonConformancePicture.Height

            Dim x As Integer
            Dim y As Integer
            ''check to see how the user scrolled
            If (e.ScrollOrientation = ScrollOrientation.HorizontalScroll) Then
                x = e.NewValue
                y = vscrlNonConformancePicture.Value
            Else
                x = hscrlNonConformancePicture.Value
                y = e.NewValue
            End If
            ''redraws the image *I think it just draws the image on the image that was already there without clearing the draw space
            graps.DrawImage(picbxNonConformancePicture.Image, New System.Drawing.Rectangle(0, 0, picbxWidth, picbxHeight), New System.Drawing.Rectangle(x, y, picbxWidth, picbxHeight), GraphicsUnit.Pixel)

            picbxNonConformancePicture.Update()
        End If
    End Sub

    Private Sub SetNonConformanceScrollBars()
        If picbxNonConformancePicture.Image IsNot Nothing Then
            ''checks the width of the current picture and will adjust the scroll bar accordingly
            If picbxNonConformancePicture.Image.Width > picbxNonConformancePicture.Width Then
                hscrlNonConformancePicture.Maximum = picbxNonConformancePicture.Image.Width - picbxNonConformancePicture.Width
                hscrlNonConformancePicture.Enabled = True
            Else
                hscrlNonConformancePicture.Maximum = 0
                hscrlNonConformancePicture.Enabled = False
            End If
            ''checks the height of the current picture and will adjust the scroll bar accordingly
            If picbxNonConformancePicture.Image.Height > picbxNonConformancePicture.Height Then
                vscrlNonConformancePicture.Maximum = picbxNonConformancePicture.Image.Height - picbxNonConformancePicture.Height
                vscrlNonConformancePicture.Enabled = True
            Else
                vscrlNonConformancePicture.Maximum = 0
                vscrlNonConformancePicture.Enabled = False
            End If
        Else
            hscrlNonConformancePicture.Maximum = 0
            hscrlNonConformancePicture.Enabled = False
            vscrlNonConformancePicture.Maximum = 0
            vscrlNonConformancePicture.Enabled = False
        End If
    End Sub
    ''Handles setting the controls based on if there is an image selected
    Private Sub SetNonConformancePictureControls()
        If picbxNonConformancePicture.Image Is Nothing Then
            cmdPrintNonConformancePicture.Enabled = False
            cmdFullScreenNonConformancePicture.Enabled = False
        Else
            cmdPrintNonConformancePicture.Enabled = True
            cmdFullScreenNonConformancePicture.Enabled = True
        End If
    End Sub

    Private Sub dgvNonConformancePictures_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNonConformancePictures.CellEnter
        If isLoaded Then
            DisposeNonConformancePictureShown()
            ''check to make sure there is an entry to try and get an image file
            If e.RowIndex <> -1 Then
                Dim tmpImg As Image = DirectCast(dgvNonConformancePictures.Rows(dgvNonConformancePictures.CurrentCell.RowIndex).Cells(0).Tag, picData).img.Clone()
                Dim resizeHeightPercent As Double = 0
                If tmpImg.Height > picbxNonConformancePicture.Height Then
                    resizeHeightPercent = Convert.ToDouble(picbxNonConformancePicture.Height) / Convert.ToDouble(tmpImg.Height)
                Else
                    resizeHeightPercent = 1
                End If
                picbxNonConformancePicture.Image = tmpImg.GetThumbnailImage(tmpImg.Width * resizeHeightPercent, tmpImg.Height * resizeHeightPercent, Nothing, IntPtr.Zero)
            End If
            SetNonConformancePictureControls()
            SetNonConformanceScrollBars()
        End If
    End Sub

    Private Sub cmdPrintNonConformancePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintNonConformancePicture.Click
        If CanPrintNonconformanceImage() Then
            Dim pd As New PrintDialog()
            Dim doc As New System.Drawing.Printing.PrintDocument()
            pd.UseEXDialog = True
            pd.Document = doc
            ''opens the print dialog and if the user hits print will print the image
            If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                AddHandler doc.PrintPage, AddressOf PrintNonConformanceDocument_PrintPage
                doc.Print()
            End If
        End If
    End Sub

    Private Function CanPrintNonconformanceImage() As Boolean
        If picbxNonConformancePicture.Image Is Nothing Then
            MessageBox.Show("There is no image selected to print", "Select an image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintNonConformanceDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim xbound As Integer = e.Graphics.VisibleClipBounds.Width
        Dim ybound As Integer = e.Graphics.VisibleClipBounds.Height

        ''checks to see which bound is smaller and will use the smaller bound for the image for width
        If picbxNonConformancePicture.Image.Width < e.Graphics.VisibleClipBounds.Width Then
            xbound = picbxNonConformancePicture.Image.Width
        End If
        ''checks to see which bound is smaller and will use the smaller bound for the image for height
        If picbxNonConformancePicture.Image.Height < e.Graphics.VisibleClipBounds.Height Then
            ybound = picbxNonConformancePicture.Image.Height
        End If
        ''Draws the image onto the document being printed
        e.Graphics.DrawImage(DirectCast(dgvNonConformancePictures.Rows(dgvNonConformancePictures.CurrentCell.RowIndex).Cells(0).Tag, picData).img, New System.Drawing.Rectangle(0, 0, xbound, ybound))
    End Sub

    Private Sub cmdFullScreenNonConformancePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFullScreenNonConformancePicture.Click
        If CanViewNonConformanceFullScreen() Then
            PictureFullScreen = New ViewPictureFullScreen(DirectCast(dgvNonConformancePictures.Rows(dgvNonConformancePictures.CurrentCell.RowIndex).Cells(0).Tag, picData).img.Clone())
            PictureFullScreen.Show()
        End If
    End Sub

    Private Function CanViewNonConformanceFullScreen() As Boolean
        If picbxNonConformancePicture.Image Is Nothing Then
            MessageBox.Show("There is no image selected to view full screen.", "Select an image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub RemoveJournalEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveJournalEntryToolStripMenuItem.Click
        If CanRemoveEntry() Then
            DisposeJournalPictureShown()
            dgvPictureList.Rows.Clear()
            If System.IO.Directory.Exists(BlueprintJournalRootFolder + "\" + cboBlueprint.Text + "\" + ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryKey").ToString()) Then
                Try
                    System.IO.Directory.Delete(BlueprintJournalRootFolder + "\" + cboBlueprint.Text + "\" + ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryKey").ToString(), True)
                Catch ex As System.Exception
                    sendErrorToDataBase("BlueprintJournal - RemoveJournalEntry --Error remobing the directory", BlueprintJournalRootFolder + "\" + cboBlueprint.Text + "\" + ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryKey").ToString(), ex.ToString())
                End Try
            End If
            cmd = New SqlCommand("DELETE BlueprintJournal WHERE EntryKey = @EntryKey", con)
            cmd.Parameters.Add("@EntryKey", SqlDbType.Int).Value = ds.Tables("BlueprintJournal").Rows(lstJournalEntries.SelectedIndex).Item("EntryKey")

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            ReLoadEntryData()
            SetJournalPictureControls()
            SetJournalScrollBars()
        End If
    End Sub

    Private Function CanRemoveEntry() As Boolean
        If lstJournalEntries.SelectedIndex = -1 Then
            MessageBox.Show("You must select an entry", "Select a journal entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If MessageBox.Show("Are you sure you want to delete the selected entry?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function
    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub BlueprintJournal_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Not Visible Then
            ''If the add entry form was opened at some point, this will explicitly close it.
            If AddEntryForm IsNot Nothing Then
                AddEntryForm.Close()
                AddEntryForm = Nothing
            End If
            ''If the edit entry form was opened at some point, this will explicitly close it.
            If EditEntryForm IsNot Nothing Then
                EditEntryForm.Close()
                EditEntryForm = Nothing
            End If
            ''if the full screen picture was opened at one point this will explicitly close it.
            If PictureFullScreen IsNot Nothing Then
                PictureFullScreen.Close()
                PictureFullScreen = Nothing
            End If
        End If
    End Sub

    Private Sub picbxJournalPicture_MouseWheel(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picbxJournalPicture.MouseWheel
        If vscrlJournalPicture.Enabled Then
            ''check to see if the user scrolled up or down
            If e.Delta > 0 Then
                ''check to see if we will be going below 0 when changing the vertical scroll value
                If vscrlJournalPicture.Value > 0 Then
                    If vscrlJournalPicture.Value - 5 < 0 Then
                        vscrlJournalPicture.Value = 0
                    Else
                        vscrlJournalPicture.Value -= 5
                    End If
                End If
            Else
                ''check to see if we will be going above the scroll max when changing the vertical scroll value
                If vscrlJournalPicture.Value < vscrlJournalPicture.Maximum Then
                    If vscrlJournalPicture.Value + 5 > vscrlJournalPicture.Maximum Then
                        vscrlJournalPicture.Value = vscrlJournalPicture.Maximum
                    Else
                        vscrlJournalPicture.Value += 5
                    End If

                End If
            End If
            Dim graps As Graphics = picbxJournalPicture.CreateGraphics()

            Dim picbxWidth As Integer = picbxJournalPicture.Width
            Dim picbxHeight As Integer = picbxJournalPicture.Height

            Dim x As Integer = hscrlJournalPicture.Value
            Dim y As Integer = vscrlJournalPicture.Value
            ''redraws the image *I think it just draws the image on the image that was already there without clearing the draw space
            graps.DrawImage(picbxJournalPicture.Image, New System.Drawing.Rectangle(0, 0, picbxWidth, picbxHeight), New System.Drawing.Rectangle(x, y, picbxWidth, picbxHeight), GraphicsUnit.Pixel)

            picbxJournalPicture.Update()
        End If
    End Sub

    Private Sub picbxJournalPicture_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picbxJournalPicture.Resize
        If picbxJournalPicture.Image IsNot Nothing Then
            Dim tmpImg As Image = DirectCast(dgvPictureList.Rows(dgvPictureList.CurrentCell.RowIndex).Cells(0).Tag, picData).img.Clone()

            Dim resizeHeightPercent As Double = 0
            If tmpImg.Height > picbxJournalPicture.Height Then
                resizeHeightPercent = Convert.ToDouble(picbxJournalPicture.Height) / Convert.ToDouble(tmpImg.Height)
            Else
                resizeHeightPercent = 1
            End If
            picbxJournalPicture.Image = tmpImg.GetThumbnailImage(Convert.ToInt32(tmpImg.Width * resizeHeightPercent), Convert.ToInt32(tmpImg.Height * resizeHeightPercent), Nothing, IntPtr.Zero)
        End If
    End Sub

    Private Sub BlueprintJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class