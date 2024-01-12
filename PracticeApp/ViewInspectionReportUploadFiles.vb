Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class ViewInspectionReportUploadFiles
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim fileData As List(Of usefulFunctions.PDFFileData)
    Dim position As Integer = 0
    Dim tempfolder As String = My.Computer.FileSystem.SpecialDirectories.Temp.Replace("\", "\\") + "\\InspectionReports"
    Dim InspectionReportDirectory As String = "\\\\TFP-SQL\\TransferData\\Inspection Reports"
    Dim DeleteFile As Boolean = False
    Dim DeleteAll As Boolean = False
    Dim UploadFiles As Boolean = False

    Public Sub New()
        InitializeComponent()
        cmdNext.Enabled = False
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
        loadcustomer()
        cmdScan.Enabled = True
    End Sub

    Public Sub loadcustomer()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = 'TFP'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        DivisionDataset = New DataSet()
        DivisionAdapter.SelectCommand = cmd
        DivisionAdapter.Fill(DivisionDataset, "CustomerList")
        cboCustomerID.DataSource = DivisionDataset.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub New(ByVal startingData As Object)
        InitializeComponent()
        If TypeOf (startingData) Is List(Of usefulFunctions.PDFFileData) Then
            fileData = startingData
        End If
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
        cmdScan.Enabled = True
    End Sub
    
    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Dim extensions As New List(Of String)
        extensions.Add("*.bmp")
        ' And so on, until all are in...
        Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

        Dim fileCount As Integer
        For i As Integer = 0 To extensions.Count - 1
            fileCount += Directory.GetFiles(pathname, extensions(i), SearchOption.AllDirectories).Length
        Next
        GlobalVariables.NextPrevious += 1
        lblTotalFiles.Text = GlobalVariables.NextPrevious & " / " & GlobalVariables.totalfiles
        If GlobalVariables.NextPrevious <= fileCount Then
            pathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.NextPrevious & ".bmp"
            Using fs As New System.IO.FileStream(pathname, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                picPDF.Image = System.Drawing.Image.FromStream(fs)
                Dim bmp As Bitmap = New Bitmap(picPDF.Image)
                bmp.RotateFlip(RotateFlipType.Rotate270FlipNone)
                picPDF.Image = bmp
            End Using
            cmdPrevious.Enabled = True
            cmdNext.Enabled = True
        Else
            cmdNext.Enabled = False
            cmdPrevious.Enabled = True
        End If
        If GlobalVariables.NextPrevious = fileCount Then
            cmdNext.Enabled = False
        End If
        txtBlueprintNumber.Clear()
        txtFOXNumber.Clear()
        txtRevisionLevel.Clear()
        cboCustomerID.SelectedIndex = -1
        cboCustomerID.Text = ""
    End Sub

    Private Function canSave() As Boolean
        'makes sure that there is an entry in the blueprint textbox
        If String.IsNullOrEmpty(txtBlueprintNumber.Text) Then
            MessageBox.Show("You must enter a blueprint number", "Enter a blueprint number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBlueprintNumber.Focus()
            Return False
        End If
        'makes sure that the fox number is not blank.
        If String.IsNullOrEmpty(txtFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFOXNumber.Focus()
            Return False
        End If

        ' selects the fox number from the FOXTable and then makes sure its a valid FOX number
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = txtFOXNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If obj Is Nothing Then
            MessageBox.Show("FOX number entered does not exist.", "FOX number doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFOXNumber.SelectAll()
            txtFOXNumber.Focus()
            Return False
        End If
        ' Selects the CustomerID from the CustomerList table and makes sure it exists.
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj2 As Object = cmd.ExecuteScalar()
        con.Close()
        If cboCustomerID.Text() = "TW STOCK" Or cboCustomerID.Text() = "" Then

        ElseIf obj2 Is Nothing Then
            MessageBox.Show("Customer ID number entered does not exist.", "Customer ID number doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If

        ' Selects the Blueprint number from the FOXTable and makes sure it exists.
        cmd = New SqlCommand("SELECT BlueprintNumber FROM FOXTable WHERE BlueprintNumber = @BlueprintNumber", con)
        cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = txtBlueprintNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj3 As Object = cmd.ExecuteScalar()
        con.Close()
        If obj3 Is Nothing Then
            MessageBox.Show("Blueprint number entered does not exist.", "Blueprint number doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBlueprintNumber.SelectAll()
            txtBlueprintNumber.Focus()
            Return False
        End If


        Return True
    End Function

    Private Sub SetButtons()
        If position = fileData.Count - 1 Then
            cmdNext.Enabled = False
            If fileData.Count = 0 Then
                cmdPrevious.Enabled = False

                cmdUploadFiles.Enabled = False
            Else
                cmdUploadFiles.Enabled = True
                cmdPrevious.Enabled = True
            End If
        ElseIf position = 0 Then
            If fileData.Count = 0 Then
                cmdPrevious.Enabled = False
                cmdNext.Enabled = False
                cmdUploadFiles.Enabled = False
            Else
                cmdUploadFiles.Enabled = False
                cmdPrevious.Enabled = False
                cmdNext.Enabled = True
            End If
        Else
            cmdUploadFiles.Enabled = False
            cmdPrevious.Enabled = True
            cmdNext.Enabled = True
        End If

    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        'setting up function to find all files in a folder with a .bmp extension
        Dim extensions As New List(Of String)
        extensions.Add("*.bmp")

        Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

        'counts how many bmp files in folder
        Dim fileCount As Integer
        For i As Integer = 0 To extensions.Count - 1
            fileCount += Directory.GetFiles(pathname, extensions(i), SearchOption.AllDirectories).Length
        Next
        GlobalVariables.NextPrevious -= 1
        lblTotalFiles.Text = GlobalVariables.NextPrevious & " / " & GlobalVariables.totalfiles
        If GlobalVariables.NextPrevious > 0 Then
            pathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.NextPrevious & ".bmp"
            Using fs As New System.IO.FileStream(pathname, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                picPDF.Image = System.Drawing.Image.FromStream(fs)
                Dim bmp As Bitmap = New Bitmap(picPDF.Image)
                bmp.RotateFlip(RotateFlipType.Rotate270FlipNone)
                picPDF.Image = bmp
            End Using
            cmdNext.Enabled = True
        Else
            cmdNext.Enabled = True
            cmdPrevious.Enabled = False
        End If
        If GlobalVariables.NextPrevious = 1 Then
            cmdPrevious.Enabled = False
        End If
        txtBlueprintNumber.Clear()
        txtFOXNumber.Clear()
        txtRevisionLevel.Clear()
        cboCustomerID.SelectedIndex = -1
        cboCustomerID.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBox.Show("Are you sure you wish to delete this file?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            DeleteFile = True
        End If
    End Sub

    Private Sub cmdUploadFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadFiles.Click
        If canSave() Then
            'Variables Declared
            Dim comboboxSelection As String = cboCustomerID.Text
            If cboCustomerID.Text = "" Then comboboxSelection = "TW STOCK"
            Dim strDir As String = "\\TFP-FS\TransferData\Inspection Reports\" & comboboxSelection & "\"
            If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)
            Dim strRevision As String = txtRevisionLevel.Text
            Dim strFox As String = txtFOXNumber.Text
            Dim strBlueprint As String = txtBlueprintNumber.Text
            Dim strNowDate As String = dtpDate.Value.ToString("MM-dd-yyyy")
            Dim strNowSeconds As String = dtpDate.Value.ToString("ss")
            'Name of file
            'Blueprint+Revision " " fox number " " month-day-year " " seconds
            Dim strFilename As String = strBlueprint + strRevision + " " + strFox + " " + strNowDate + " " + strNowSeconds + ".pdf"
            'path to bmp
            Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.NextPrevious & ".bmp"
            Dim strCompletePath As String = strDir & strFilename
            Dim pdfDoc As New document()
            Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
            pdfDoc.Open()
            'Grabs the bmp image seen on screen
            Dim img As iTextSharp.text.Image = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)
            'closes the pdf and saves it
            pdfDoc.Close()

            'messagebox confirmation on saving
            MessageBox.Show("Filename: " & strFilename & ".pdf", "Saved to: " & strCompletePath, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'declares list of bmp files to be counted
            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"


        End If
        GlobalVariables.previousScan = True

    End Sub

    'Wait Screen
    Private Sub lblWaitMessage_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWaitMessage.VisibleChanged
        If pnlWaitMessage.Visible Then
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdScan.Enabled = False
            cmdUploadFiles.Enabled = False
        End If
    End Sub

    Private Sub ViewInspectionReportUploadFiles_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
    End Sub

    Private Sub ViewInspectionReportUploadFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub


    Private Sub ViewInspectionReportUploadFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadcustomer()

    End Sub

    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        ' Deletes the WIA testing temp file
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
        ' Creates the folder if the temp folder is not currently created
        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
        txtBlueprintNumber.Text = Nothing
        txtFOXNumber.Text = Nothing
        txtRevisionLevel.Text = Nothing
        path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        'If there had been a previous scan then delete the picture from the picturebox
        GlobalVariables.Counter = 0
        Dim mgr As New WIA.DeviceManagerClass
        Dim Scanner As WIA.Device = Nothing
        If mgr.DeviceInfos.Count > 1 Then
            ''More than 1 scanner was detected
            Dim lst As New List(Of Integer)
            ''Finds all the USB scanners
            For i As Integer = 1 To mgr.DeviceInfos.Count()
                If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                    lst.Add(i)
                End If
            Next
            ''Check to see how many usb scanners were found
            If lst.Count > 1 Or lst.Count = 0 Then
                Dim selectScanner As New WIA.CommonDialog
                Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
            Else
                Scanner = mgr.DeviceInfos(lst(0)).Connect()
            End If
        ElseIf mgr.DeviceInfos.Count = 0 Then
            ''No scanners were detected
            If My.Computer.Name.ToString.StartsWith("TFP") Then
            Else
                ''No scanners were detected
                MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ''Only 1 scanner is connected
            Scanner = mgr.DeviceInfos(1).Connect()
        End If
        If Scanner IsNot Nothing Then
            Dim item As WIA.Item = Scanner.Items(1)
            Dim obj As Object
            Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
            ''Specific scanning properties
            For Each prop As WIA.Property In Scanner.Items(1).Properties
                Dim x As WIA.IProperty = prop
                Select Case prop.PropertyID
                    Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                        obj = 0
                        x.let_Value(obj)
                    Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                        obj = 2
                        x.let_Value(obj)
                    Case "6147" ''(DPI) Horizontal Resolution
                        obj = 200
                        x.let_Value(obj)
                    Case "6148" ''(DPI) Vertical Resolution
                        obj = 200
                        x.let_Value(obj)
                    Case "6151" ''horizontal extent (width)
                        obj = 1700
                        x.let_Value(obj)
                    Case "6152" ''vertical extent (height)
                        obj = 2338
                        x.let_Value(obj)
                End Select
            Next

            Dim dial As New WIA.CommonDialog
            Dim hasMorePages As Boolean = True
            Dim ScannedAtleastOnePage As Boolean = False
            Dim pages As Integer = 0
            Dim ScannedImages As New List(Of iTextSharp.text.Image)

            ''Loops until all pages are scanned.
            While hasMorePages
                GlobalVariables.Counter = GlobalVariables.Counter + 1
                pages += 1
                Try
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                    Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                    Img.SaveFile(tmp)
                    'ScannedImages.Add(Img.fromfile(tmp))
                    ScannedAtleastOnePage = True


                Catch ex As System.Exception
                    ''Looks for paper empty error to break the loop and/or to show error message
                    If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                        If Not ScannedAtleastOnePage Then
                            MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GlobalVariables.paperscan = False
                        Else
                            GlobalVariables.paperscan = True
                        End If
                        hasMorePages = False
                    End If
                End Try
            End While

            'Displays the first saved scan into the picturebox
            If GlobalVariables.paperscan Then
                GlobalVariables.StartCounter = 1
                Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                GlobalVariables.NextPrevious = GlobalVariables.StartCounter
                Using fs As New System.IO.FileStream(pathname, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    picPDF.Image = System.Drawing.Image.FromStream(fs)
                    Dim bmp As Bitmap = New Bitmap(picPDF.Image)
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipNone)
                    picPDF.Image = bmp
                End Using
            End If
        End If
        'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
        GlobalVariables.previousScan = True
        GlobalVariables.NextPrevious = 1
        cmdUploadFiles.Enabled = True

        Dim extensions As New List(Of String)
        extensions.Add("*.bmp")
        Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

        'counts the files in the folder
        Dim fileCount As Integer
        For i As Integer = 0 To extensions.Count - 1
            fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
        Next
        GlobalVariables.totalfiles = fileCount
        lblTotalFiles.Text = "1 /" & fileCount
        If fileCount > 1 Then cmdNext.Enabled = True
        cmdBackRotate.Enabled = True
        cmdForwRotate.Enabled = True
    End Sub
    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub
    
    Private Sub txtFOXNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFOXNumber.TextChanged

        cboCustomerID.Text = ""
        txtBlueprintNumber.Text = ""
        txtRevisionLevel.Text = ""

        'declares a sql command to find the correct blueprint number, revision, and customer based on the filled out fox number that is given
        Dim cmd As New SqlCommand("SELECT * FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = txtFOXNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                'if the reader doe not find anything, then it sets a string variable as blank
                If IsDBNull(reader.Item("FOXNumber")) Then
                    cboCustomerID.Text = ""
                    txtBlueprintNumber.Text = ""
                    txtRevisionLevel.Text = ""
                Else
                    'Fills out the information based on the fox number
                    cboCustomerID.Text = reader.Item("CustomerID")
                    txtBlueprintNumber.Text = reader.Item("BlueprintNumber")
                    txtRevisionLevel.Text = reader.Item("BlueprintRevision")
                End If
            End While
        End If
        con.Close()
        reader.Close()
    End Sub

    'Rotates the image -90 degrees
    Private Sub btnBackRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackRotate.Click
        Dim bmp As Bitmap = New Bitmap(picPDF.Image)
        bmp.RotateFlip(RotateFlipType.Rotate270FlipNone)
        picPDF.Image = bmp
    End Sub

    'Rotates the image 90 degrees
    Private Sub btnForwRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForwRotate.Click
        Dim bmp As Bitmap = New Bitmap(picPDF.Image)
        bmp.RotateFlip(RotateFlipType.Rotate90FlipNone)
        picPDF.Image = bmp
    End Sub
End Class

'global variables for the verification
Public Class GlobalVariables
    Public Shared Counter As Integer = 0
    Public Shared StartCounter As Integer = 1
    Public Shared NextPrevious As Integer
    Public Shared previousScan As Boolean = False
    Public Shared paperscan As Boolean = True
    Public Shared totalfiles As Integer
    Public Shared stringVar As String = ""
    Public Shared stringVar2 As String = ""
    Public Shared dblVar3 As Double = 0
End Class

