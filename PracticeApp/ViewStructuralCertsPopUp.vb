Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports iTextSharp.text.Image
Imports iTextSharp.text.pdf
Imports document = iTextSharp.text.Document

Public Class ViewStructuralCertsPopUp

    'Remote
    Dim isLoaded As Boolean = False
    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\StructuralCerts")
    Dim FilesToDelete As List(Of String)
    Dim bgPDF As BackgroundWorker
    Dim bgAppendPDF As BackgroundWorker
    Dim LoadingScreen As New Loading
    Dim ShipmentNumber As Integer = 0

    ''Remote WIA variables
    Dim remoteWIA As MOSRemoteWIA
    Dim bgwkRemoteWIA As BackgroundWorker
    Dim frm As System.Windows.Forms.Form
    Dim remoteCheck As Boolean = False
    Dim TodaysDate As Date = Now()

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd, cmd2, cmd3 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim tableName As String = "StructuralCertTable"

    Dim BeginDate, EndDate As Date

    Dim LotNumFilter, HeatNumFilter, PartFilter, DescriptionFilter, SalesIDFilter, VendorFilter, PDFStatusFilter, StatusFilter, DateFilter As String

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdScan_Click(sender As Object, e As EventArgs) Handles cmdScan.Click
        If My.Computer.Name.StartsWith("TFP") Then
            Dim exists As Boolean = False
            Dim autho As String = ""
            Dim ItemDataStatement As String = "SELECT LotNumber FROM StructuralCertTable WHERE LotNumber = @LotNumber"
            Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
            ItemDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("LotNumber")) Then
                        autho = ""
                    Else
                        autho = reader.Item("LotNumber")
                    End If
                End If
                reader.Close()
            End Using

            Dim chosenautho = txtLotNumber.Text
            Dim comString = autho
            If chosenautho = comString Then

                Dim ReceiptFilename As String = ""
                Dim ReceiptFilenameAndPath As String = ""
                Dim strReceiptNumber As String = ""

                'Verify that they have a Receipt selected
                If txtLotNumber.Text = "" Then
                    MsgBox("You must select a valid lot number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    strReceiptNumber = txtLotNumber.Text
                End If

                Dim UploadedReceiptNumber As String = txtLotNumber.Text

                ReceiptFilename = strReceiptNumber + ".pdf"
                ReceiptFilenameAndPath = "\\TFP-FS\TransferData\StructuralCerts\" + ReceiptFilename

                If File.Exists(ReceiptFilenameAndPath) Then
                    Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Cert?", "OVERWRITE EXISTING CERT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        'Delete existing Receipt before upload
                        File.Delete(ReceiptFilenameAndPath)

                        Dim My_Process As New Process()
                        'Dim My_Process_Info As New ProcessStartInfo

                        Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                        strReceiptNumber = CStr(txtLotNumber.Text)

                        ReceiptFilename = strReceiptNumber + ".pdf"
                        ReceiptFilenameAndPath = "\\TFP-FS\TransferData\StructuralCerts\" + ReceiptFilename

                        'My_Process_Info.UseShellExecute = False
                        'My_Process_Info.RedirectStandardOutput = True
                        'My_Process_Info.RedirectStandardError = True
                        'My_Process_Info.CreateNoWindow = True

                        Try
                            My_Process.Start(ApplicationFileAndPath, "-o " & ReceiptFilenameAndPath)
                            'My_Process.WaitForExit()
                            My_Process.Close()
                        Catch ex As system.Exception
                            MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                        End Try
                    ElseIf button = DialogResult.No Then
                        Exit Sub
                    End If
                Else
                    Dim My_Process As New Process()
                    'Dim My_Process_Info As New ProcessStartInfo

                    Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                    strReceiptNumber = CStr(txtLotNumber.Text)

                    ReceiptFilename = strReceiptNumber + ".pdf"
                    ReceiptFilenameAndPath = "\\TFP-FS\TransferData\StructuralCerts\" + ReceiptFilename

                    'My_Process_Info.UseShellExecute = False
                    'My_Process_Info.RedirectStandardOutput = True
                    'My_Process_Info.RedirectStandardError = True
                    'My_Process_Info.CreateNoWindow = True

                    Try
                        My_Process.Start(ApplicationFileAndPath, "-o " & ReceiptFilenameAndPath)
                        'My_Process.WaitForExit()
                        My_Process.Close()
                    Catch ex As system.Exception

                    End Try

                End If
                
            Else
                MsgBox("Lot Number Does Not Exist")
            End If
        Else
            Dim exists As Boolean = False
            Dim autho As String = ""
            Dim ItemDataStatement As String = "SELECT LotNumber FROM StructuralCertTable WHERE LotNumber = @LotNumber"
            Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
            ItemDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("LotNumber")) Then
                        autho = ""
                    Else
                        autho = reader.Item("LotNumber")
                    End If
                End If
                reader.Close()
            End Using

            Dim chosenautho = txtLotNumber.Text
            Dim comString = autho
            If chosenautho = comString Then
                ScanStrucCert()

            Else
                MsgBox("Lot Number Does Not Exist")
            End If
        End If
        Me.Close()
    End Sub

    Public Sub ScanStrucCert(Optional ByVal newPDF As Boolean = True)
        Dim yes As Boolean = True
        If yes Then

            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")

            If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf")

            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0

            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For l As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(l).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(l)
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
                    Dim loadingScreen As New Loading


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
                        Dim Imgs As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                        Imgs.SaveFile(tmp)
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

                End If
            End If
            'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
            GlobalVariables.previousScan = True
            GlobalVariables.NextPrevious = 1


            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

            'counts the files in the folder
            Dim fileCount As Integer
            For h As Integer = 0 To extensions.Count - 1
                fileCount += Directory.GetFiles(pathname2, extensions(h), SearchOption.AllDirectories).Length
            Next
            GlobalVariables.totalfiles = fileCount
        End If

        Dim boolCheck As Boolean = True
        Dim FilesInFolder As Integer
        Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
        FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count

        'Variables Declared
        Dim comboboxSelection As String = txtLotNumber.Text

        Dim strDir As String = "\\TFP-FS\TransferData\StructuralCerts\"

        'Dim pdfDoc As New document()

        'Name of file
        Dim strFilename As String = txtLotNumber.Text + ".pdf"
        Dim pdfDoc As New document()
        Dim i As Integer = 1
        Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
        'path to bmp
        Dim strCompletePath As String = strDir & strFilename
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
        pdfDoc.Open()
        'Grabs the bmp image seen on screen
        Dim img As iTextSharp.text.Image = GetInstance(strPathname)
        'structures it to fit on pdf file
        img.ScalePercent(72.0F / img.DpiX * 100)
        img.SetAbsolutePosition(0, 0)
        'adds image to the document
        pdfDoc.Add(img)

        i += 1
        While i <= FilesInFolder
            pdfDoc.NewPage()
            strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
            'path to bmp
            strCompletePath = strDir & strFilename
            'Grabs the bmp image seen on screen
            img = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)
            i += 1
        End While
        pdfDoc.Close()


    End Sub

    Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
        GlobalVariables.stringVar = "Upload"
        Dim exists As Boolean = False
        Dim autho As String = ""
        Dim ItemDataStatement As String = "SELECT LotNumber FROM StructuralCertTable WHERE LotNumber = @LotNumber"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        ItemDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("LotNumber")) Then
                    autho = ""
                Else
                    autho = reader.Item("LotNumber")
                End If
            End If
            reader.Close()
        End Using
        Dim yes As Boolean = True
        Dim chosenautho = txtLotNumber.Text
        Dim comString = autho
        If chosenautho = comString Then
            If yes Then
                Try
                    Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf")
                Catch ex As System.Exception
                End Try
                Try
                    Dim MoveLocation As String = "\\TFP-FS\TransferData\StructuralCerts\"
                    Dim destinationPath As String = ""

                    Dim fd As OpenFileDialog = New OpenFileDialog()
                    Dim strFileName As String = ""

                    fd.Title = "Open File Dialog"
                    fd.InitialDirectory = "C:\"
                    fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
                    fd.FilterIndex = 2
                    fd.RestoreDirectory = True

                    If fd.ShowDialog() = DialogResult.OK Then
                        strFileName = fd.FileName
                    End If

                    If File.Exists(strFileName) Then
                        Dim filename As String = System.IO.Path.GetFileName(strFileName)
                        destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                        If File.Exists(destinationPath) Then
                            File.Delete(destinationPath)
                        End If
                        File.Move(strFileName, destinationPath)
                        Dim rename As String = txtLotNumber.Text + ".pdf"
                        My.Computer.FileSystem.RenameFile(destinationPath, rename)
                        MsgBox("File Moved")

                    Else
                        MsgBox("File Not Moved")
                    End If

                Catch ex As System.Exception
                End Try

            End If
        Else
            MsgBox("Lot Number Does Not Exist")
        End If
        Me.Close()
    End Sub

    Private Sub ViewStructuralCertsPopUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtLotNumber.Text = GlobalVariables.stringVar2
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
End Class