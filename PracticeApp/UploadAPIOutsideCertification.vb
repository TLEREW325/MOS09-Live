Imports System.IO
Imports iTextSharp
Imports System.ComponentModel
Imports WIA
Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class UploadAPIOutsideCertification
    Private LotNumber As String = String.Empty
    Public Const OutsideCertPath As String = "\\TFP-FS\TransferData\Uploaded Outside Certifications"
    Private PDFDir As New IO.DirectoryInfo(OutsideCertPath)
    Private frm As System.Windows.Forms.Form

    ''PDF Generation variables
    Dim FilesToDelete As List(Of String)
    Dim bgNewPDF As BackgroundWorker
    Dim bgAppendPDF As BackgroundWorker
    Dim LoadingScreen As New Loading
    Dim UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Dim ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Dim ReUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Public Sub New(ByVal infrm As System.Windows.Forms.Form, ByVal upload As System.Windows.Forms.ToolStripMenuItem, ByVal view As System.Windows.Forms.ToolStripMenuItem, ByVal reUpload As System.Windows.Forms.ToolStripMenuItem)
        frm = infrm
        If Not PDFDir.Exists Then
            PDFDir.Create()
        End If
        bgNewPDF = New BackgroundWorker()
        AddHandler bgNewPDF.DoWork, AddressOf bgwkNewPDF_Run
        AddHandler bgNewPDF.RunWorkerCompleted, AddressOf bgwkPDF_Completed
        bgAppendPDF = New BackgroundWorker()
        AddHandler bgAppendPDF.DoWork, AddressOf bgwkAppendPDF_Run
        AddHandler bgAppendPDF.RunWorkerCompleted, AddressOf bgwkPDF_Completed
        LoadingScreen.Text = "Generating PDF"
        LoadingScreen.Label1.Text = "Generating PDF please wait"
        LoadingScreen.StartPosition = FormStartPosition.CenterScreen
        UploadToolStripMenuItem = upload
        AddHandler UploadToolStripMenuItem.Click, AddressOf UploadOutsideCertificationToolStripMenuItem_Click
        ViewToolStripMenuItem = view
        AddHandler ViewToolStripMenuItem.Click, AddressOf ViewOutsideCertificationToolStripMenuItem_Click
        ReUploadToolStripMenuItem = reUpload
        AddHandler ReUploadToolStripMenuItem.Click, AddressOf ReUploadOutsideCertificationToolStripMenuItem_Click
    End Sub

    Public Sub New(ByVal lot As String, ByVal infrm As System.Windows.Forms.Form, ByVal upload As System.Windows.Forms.ToolStripMenuItem, ByVal view As System.Windows.Forms.ToolStripMenuItem)
        LotNumber = lot
        frm = infrm
        If Not PDFDir.Exists Then
            PDFDir.Create()
        End If
        bgNewPDF = New BackgroundWorker()
        AddHandler bgNewPDF.DoWork, AddressOf bgwkNewPDF_Run
        AddHandler bgNewPDF.RunWorkerCompleted, AddressOf bgwkPDF_Completed
        bgAppendPDF = New BackgroundWorker()
        AddHandler bgAppendPDF.DoWork, AddressOf bgwkAppendPDF_Run
        AddHandler bgAppendPDF.RunWorkerCompleted, AddressOf bgwkPDF_Completed
        LoadingScreen.Text = "Generating PDF"
        LoadingScreen.Label1.Text = "Generating PDF please wait"
        LoadingScreen.StartPosition = FormStartPosition.CenterScreen
        UploadToolStripMenuItem = upload
        ViewToolStripMenuItem = view
    End Sub

    Public Sub ChangeLotNumber(ByVal lot As String)
        LotNumber = lot
        CheckUploadCertifications()
    End Sub

    Public Sub UploadCertification()
        Dim fls As IO.FileInfo() = PDFDir.GetFiles(LotNumber + "*.pdf")
        If fls.Length > 0 Then
            Dim fl As IO.FileInfo = PDFDir.GetFiles(LotNumber + ".pdf")(0)
            If fls.Length > 1 Then
                LoadingScreen.Label1.Text = "Merging multiple PDF, please wait"
                If Not MergePDFFiles(fls) Then
                    ''SEND ERROR TO DB
                End If
            End If
            ScanPages(False)
        Else
            ScanPages(True)
        End If
    End Sub

    Private Function MergePDFFiles(ByVal fls As FileInfo()) As Boolean
        Dim Merged As Boolean = True
        Using tempStream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim copyDoc As New iTextSharp.text.Document()
            Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
            Dim reader As iTextSharp.text.pdf.PdfReader
            Try
                copyDoc.Open()
                Dim pageCounter As Integer = 0
                For Each fle As FileInfo In fls
                    reader = New iTextSharp.text.pdf.PdfReader(fle.FullName)
                    Dim numberOfPages As Integer = reader.NumberOfPages
                    For currentPage As Integer = 1 To numberOfPages
                        pageCounter += 1
                        Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                        copy.AddPage(importedPage)
                    Next
                    copy.FreeReader(reader)
                    reader.Close()
                    fle.Delete()
                Next

                copyDoc.Close()
            Catch ex As System.Exception
                Return False
            Finally
                If copyDoc.IsOpen Then
                    copyDoc.Close()
                End If
            End Try

            Using fs As New FileStream(PDFDir.FullName + "\" + LotNumber + ".pdf", FileMode.OpenOrCreate, FileAccess.Write)
                fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
            End Using

        End Using
        Return merged
    End Function

    Private Sub UploadNewFile()
        ScanPages(True)
    End Sub

    Private Sub bgwkNewPDF_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Dim images As List(Of Image) = CType(e.Argument, List(Of Image))
        Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
        iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(PDFDir.FullName + "\" + LotNumber.ToString + ".pdf", IO.FileMode.Create)).SetFullCompression()
        doc.Open()
        For Each img As Image In images
            Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
            iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
            doc.Add(iImage)
            doc.Add(New iTextSharp.text.Paragraph())
        Next
        doc.Close()
        e.Result = images
    End Sub

    Private Sub bgwkAppendPDF_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Dim images As List(Of Image) = CType(e.Argument, List(Of Image))

        Using tempStream As New System.IO.MemoryStream()
            Dim copyDoc As New iTextSharp.text.Document()
            Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
            copyDoc.Open()
            Dim pageCounter As Integer = 0
            Dim reader As New iTextSharp.text.pdf.PdfReader(PDFDir.FullName + "\" + LotNumber + ".pdf")
            Dim numberOfPages As Integer = reader.NumberOfPages
            For currentPage As Integer = 1 To numberOfPages
                pageCounter += 1
                Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                copy.AddPage(importedPage)
            Next
            copy.FreeReader(reader)
            reader.Close()
            System.IO.File.Delete(PDFDir.FullName + "\" + LotNumber + ".pdf")
            ''Creates a document in memory of the newly scanned pages
            Dim imageStream As New System.IO.MemoryStream()
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, imageStream).SetFullCompression()
            doc.Open()
            For Each img As Image In images
                Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                doc.Add(iImage)
                doc.Add(New iTextSharp.text.Paragraph())
            Next
            doc.Close()
            ''Merges the newly scanned image document into the current document
            reader = New iTextSharp.text.pdf.PdfReader(imageStream.GetBuffer())
            numberOfPages = reader.NumberOfPages
            For currentPage As Integer = 1 To numberOfPages
                pageCounter += 1
                Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                copy.AddPage(importedPage)
            Next
            copy.FreeReader(reader)
            reader.Close()
            copyDoc.Close()
            imageStream.Close()
            imageStream.Dispose()
            Using fs As New FileStream(PDFDir.FullName + "\" + LotNumber + ".pdf", FileMode.OpenOrCreate, FileAccess.Write)
                fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
            End Using
        End Using

        e.Result = images
    End Sub

    Private Sub bgwkPDF_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of Image) = CType(e.Result, List(Of Image))
        Dim TotalPages As Integer = images.Count
        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While
        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If
        frm.Enabled = True
        LoadingScreen.Hide()
        CheckUploadCertifications()
        MessageBox.Show(TotalPages.ToString + " pages have been scanned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        frm.TopMost = True
        frm.TopMost = False
    End Sub


    ''' <summary>
    ''' Scans pages from a WIA device into an image file. Then will pass to the PDF generater.
    ''' </summary>
    ''' <param name="newPDF">Boolean to tell if we are creating a new file or appending a file.</param>
    ''' <remarks></remarks>
    Private Sub ScanPages(Optional ByVal newPDF As Boolean = True)
        Dim mgr As New DeviceManager
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
                Scanner = selectScanner.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, True, False)
            Else
                Scanner = mgr.DeviceInfos(lst(0)).Connect()
            End If
        ElseIf mgr.DeviceInfos.Count = 0 Then
            ''No scanners were detected
            MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim ScannedImages As New List(Of Image)
            FilesToDelete = New List(Of String)

            While hasMorePages
                pages += 1
                Try
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + Now.ToShortDateString.Replace("/", "-") + " " + Now.ToShortTimeString.Replace(":", "") + " " + pages.ToString + ".jpg"
                    Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatJPEG, False)
                    Img.SaveFile(tmp)
                    ScannedImages.Add(Image.FromFile(tmp))
                    ScannedAtleastOnePage = True
                    FilesToDelete.Add(tmp)
                Catch ex As System.Exception
                    If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                        If Not ScannedAtleastOnePage Then
                            MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        hasMorePages = False
                    Else
                        If Not ScannedAtleastOnePage Then
                            sendErrorToDataBase("PickTicketScannerUploadAPI - ScanPages --Error trying to scan pages.", "User: " + EmployeeLoginName, ex.ToString())
                            MessageBox.Show("There was an issue scanning the pages.", "Unable to scan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        hasMorePages = False
                    End If
                End Try
            End While
            If ScannedImages.Count > 0 Then
                LoadingScreen.Show()
                LoadingScreen.BringToFront()
                frm.Enabled = False
                If newPDF Then
                    bgNewPDF.RunWorkerAsync(ScannedImages)
                Else
                    bgAppendPDF.RunWorkerAsync(ScannedImages)
                End If

            End If
        End If
    End Sub

    Public Sub CheckUploadCertifications()
        If Not String.IsNullOrEmpty(LotNumber) Then
            UploadToolStripMenuItem.Enabled = True
            If PDFDir.GetFiles(LotNumber + ".pdf").Length > 0 Then
                UploadToolStripMenuItem.Text = "Append Outside Certification"
                ViewToolStripMenuItem.Enabled = True
                ReUploadToolStripMenuItem.Enabled = True
            Else
                UploadToolStripMenuItem.Text = "Upload Outside Certification"
                ViewToolStripMenuItem.Enabled = False
                ReUploadToolStripMenuItem.Enabled = False
            End If
        Else
            ViewToolStripMenuItem.Enabled = False
            ReUploadToolStripMenuItem.Enabled = False
            UploadToolStripMenuItem.Enabled = False
        End If

    End Sub

    Public Sub ViewCertification()
        Dim TempFileNameAndPath As String = OutsideCertPath + "\" + LotNumber + ".pdf"

        Dim fls As IO.FileInfo() = PDFDir.GetFiles(LotNumber + ".pdf")
        If fls.Length > 0 Then
            If File.Exists(TempFileNameAndPath) Then
                System.Diagnostics.Process.Start(TempFileNameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub UploadOutsideCertificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(LotNumber) Then
            UploadCertification()
        End If
    End Sub

    Private Sub ViewOutsideCertificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(LotNumber) Then
            ViewCertification()
        End If
    End Sub

    Private Sub ReUploadOutsideCertificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(LotNumber) AndAlso MessageBox.Show("Are you sure you wish to re-upload the outside certificaitons?", "Are you sure", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim fls As IO.FileInfo() = PDFDir.GetFiles(LotNumber + "*.pdf")
            If fls.Length > 0 Then
                For Each fle As IO.FileInfo In fls
                    fle.Delete()
                Next
            End If
            UploadCertification()
        End If
    End Sub

    Public Shared Function CombineCertFiles(ByVal fls As IO.FileInfo()) As IO.FileInfo
        Using tempStream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim copyDoc As New iTextSharp.text.Document()
            Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
            Dim reader As iTextSharp.text.pdf.PdfReader
            copyDoc.Open()
            Dim pageCounter As Integer = 0
            For Each fle As FileInfo In fls
                reader = New iTextSharp.text.pdf.PdfReader(fle.FullName)
                Dim numberOfPages As Integer = reader.NumberOfPages
                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next
                copy.FreeReader(reader)
                reader.Close()
            Next
            copyDoc.Close()
            If copyDoc.IsOpen Then
                copyDoc.Close()
            End If
            ''Check to see if the file exists, if it does then deletes it
            Try
                If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\CombinedPDF.pdf") Then
                    IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp + "\CombinedPDF.pdf")
                End If

                ''Writes the combined file
                Using fss As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp + "\CombinedPDF.pdf", FileMode.OpenOrCreate, FileAccess.Write)

                    fss.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)

                End Using
            Catch ex As IOException
                'MessageBox.Show(ex.Message)
            
            End Try

        End Using
        Return New IO.FileInfo(My.Computer.FileSystem.SpecialDirectories.Temp + "\CombinedPDF.pdf")


    End Function
    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
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
End Class
