﻿Imports System.ComponentModel
Imports WIA
Imports iTextSharp
Imports System.IO
Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PackingSlipScannerUploadAPI

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet

    'Dim Scanner As WIA.Device
    'Public Scanning As EventHandler(Of WIA.DeviceEvents
    Dim isLoaded As Boolean = False
    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\UploadedPackingSlips")
    Dim FilesToDelete As List(Of String)
    Dim bgPDF As BackgroundWorker
    Dim bgAppendPDF As BackgroundWorker
    Dim LoadingScreen As New Loading
    Dim ReceiverNumber As Integer = 0
    Dim tmp As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim btn As System.Windows.Forms.Button
    Dim mnu As System.Windows.Forms.ToolStripMenuItem
    Dim ReceiverControl As System.Windows.Forms.Control
    Dim frm As System.Windows.Forms.Form
    Dim ReUpload As System.Windows.Forms.ToolStripMenuItem
    Dim AppendUpload As System.Windows.Forms.ToolStripMenuItem

    ''Remote WIA variables
    Dim remoteWIA As MOSRemoteWIA
    Dim bgwkRemoteWIA As BackgroundWorker
    ''' <summary>
    ''' new instance of item
    ''' </summary>
    ''' <param name="inBTN">Visible button on the form</param>
    ''' <param name="receiverCtrl">Control with Receiver number text</param>
    ''' <param name="inReUpload">Reupload menu item</param>
    ''' <param name="infrm">Form that has instance of class.</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef inBTN As System.Windows.Forms.Button, ByRef receiverCtrl As System.Windows.Forms.Control, ByRef inReUpload As System.Windows.Forms.ToolStripMenuItem, ByRef infrm As System.Windows.Forms.Form, ByRef inAppendUpload As System.Windows.Forms.ToolStripMenuItem)
        If Not dir.Exists Then
            dir.Create()
        End If

        bgPDF = New BackgroundWorker()
        AddHandler bgPDF.DoWork, AddressOf bgwk_Run
        AddHandler bgPDF.RunWorkerCompleted, AddressOf bgwk_Completed
        bgAppendPDF = New BackgroundWorker()
        AddHandler bgAppendPDF.DoWork, AddressOf bgwkAppendPDF_Run
        AddHandler bgAppendPDF.RunWorkerCompleted, AddressOf bgwk_Completed
        LoadingScreen.Text = "Generating PDF"
        LoadingScreen.Label1.Text = "Generating PDF please wait"
        LoadingScreen.StartPosition = FormStartPosition.CenterScreen
        btn = inBTN
        mnu = Nothing
        ReceiverControl = receiverCtrl
        AddHandler btn.Click, AddressOf UploadShowPackingSlip_Click
        ReUpload = inReUpload
        AddHandler ReUpload.Click, AddressOf ReUpload_Click
        AppendUpload = inAppendUpload
        AddHandler AppendUpload.Click, AddressOf AppendUpload_Click
        frm = infrm
    End Sub

    ''' <summary>
    ''' new instance of class
    ''' </summary>
    ''' <param name="inMNU">Tool strip item of upload function</param>
    ''' <param name="receiverCtrl">Control that has receiver number as text</param>
    ''' <param name="inReUpload">Toolstrip item for reuploading</param>
    ''' <param name="infrm">Form that has instance of class</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef inMNU As System.Windows.Forms.ToolStripMenuItem, ByRef receiverCtrl As System.Windows.Forms.Control, ByRef inReUpload As System.Windows.Forms.ToolStripMenuItem, ByRef infrm As System.Windows.Forms.Form, ByRef inAppendUpload As System.Windows.Forms.ToolStripMenuItem)
        If Not dir.Exists Then
            dir.Create()
        End If

        bgPDF = New BackgroundWorker()
        AddHandler bgPDF.DoWork, AddressOf bgwk_Run
        AddHandler bgPDF.RunWorkerCompleted, AddressOf bgwk_Completed
        bgAppendPDF = New BackgroundWorker()
        AddHandler bgAppendPDF.DoWork, AddressOf bgwkAppendPDF_Run
        AddHandler bgAppendPDF.RunWorkerCompleted, AddressOf bgwk_Completed
        LoadingScreen.Text = "Generating PDF"
        LoadingScreen.Label1.Text = "Generating PDF please wait"
        LoadingScreen.StartPosition = FormStartPosition.CenterScreen
        btn = Nothing
        mnu = inMNU
        AddHandler mnu.Click, AddressOf UploadShowPackingSlip_Click
        ReceiverControl = receiverCtrl
        ReUpload = inReUpload
        AddHandler ReUpload.Click, AddressOf ReUpload_Click
        frm = infrm
        AppendUpload = inAppendUpload
        AddHandler AppendUpload.Click, AddressOf AppendUpload_Click
    End Sub

    Private Sub ReUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReUploadPackingSlip()
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = Now()
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ReUploadPackingSlip()
        If CanReUpload() Then
            Dim fls As System.IO.FileInfo() = dir.GetFiles(ReceiverControl.Text + ".pdf")

            For i As Integer = 0 To fls.Count - 1
                fls(i).Delete()
            Next

            CheckUploadPackingSlip()
            UploadPackingSlip()
        End If
    End Sub

    Private Function CanReUpload() As Boolean
        If ReceiverControl.Text = "" Then
            MessageBox.Show("You must select a receiver.", "No receiver selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dir.GetFiles(ReceiverControl.Text + ".pdf").Length = 0 Then
            MessageBox.Show("There is no uploaded packing slip (L154).", "No packing slip uploaded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CheckUploadPackingSlip()
            Return False
        End If
        Return True
    End Function

    Private Sub UploadShowPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UploadPackingSlip()
    End Sub

    Public Sub UploadPackingSlip()
        If CanScan() Then
            If Not String.IsNullOrEmpty(ReceiverControl.Text) AndAlso Val(ReceiverControl.Text) <> 0 Then
                ReceiverNumber = Val(ReceiverControl.Text)
                Dim files As System.IO.FileInfo() = dir.GetFiles(ReceiverControl.Text + ".pdf")
                If files.Length > 0 Then
                    Dim newPrintUploadedPickTickets As New PrintUploadedPickTicket(files(0).FullName)
                    newPrintUploadedPickTickets.ShowDialog()
                Else
                    ReceiverNumber = Val(ReceiverControl.Text)
                    ScanPages()
                End If
            Else
                MessageBox.Show("You must select a valid receiver number", "Select a valid receiver", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Function CanScan()
        If ReceiverControl.Text = "" Then
            MessageBox.Show("You must select a receiver.", "No receiver selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Try
            Dim mgr As New DeviceManager
        Catch ex As System.Exception
            MessageBox.Show("Computer doesn't have required applications installed to scan packing slip.", "Unable to scan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
        Return True
    End Function

    Private Sub AppendUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(ReceiverControl.Text) Then
            ReceiverNumber = Val(ReceiverControl.Text)
            ScanPages(False)
        End If
    End Sub

    Public Function CheckUploadPackingSlip() As Boolean
        If dir.GetFiles(ReceiverControl.Text + ".pdf").Length = 0 Then
            If btn IsNot Nothing Then
                btn.Text = "Upload Packing"
            Else
                mnu.Text = "Upload Packing"
            End If
            ReUpload.Enabled = False
            AppendUpload.Enabled = False
            Return True
        Else
            If btn IsNot Nothing Then
                btn.Text = "View Packing"
            Else
                mnu.Text = "View Packing"
            End If
            ReUpload.Enabled = True
            AppendUpload.Enabled = True
            Return False
        End If
    End Function

    Private Sub bgwk_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Dim images As List(Of Image) = CType(e.Argument, List(Of Image))
        Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
        iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(dir.FullName + "\" + ReceiverNumber.ToString + ".pdf", IO.FileMode.Create)).SetFullCompression()
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
        ''creates a memory stream for the document
        Using tempStream As New System.IO.MemoryStream()
            Dim copyDoc As New iTextSharp.text.Document()
            Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
            copyDoc.Open()
            Dim pageCounter As Integer = 0
            Dim reader As New iTextSharp.text.pdf.PdfReader(dir.FullName + "\" + ReceiverNumber.ToString + ".pdf")
            Dim numberOfPages As Integer = reader.NumberOfPages

            For currentPage As Integer = 1 To numberOfPages
                pageCounter += 1
                Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                copy.AddPage(importedPage)
            Next

            copy.FreeReader(reader)
            reader.Close()

            System.IO.File.Delete(dir.FullName + "\" + ReceiverNumber.ToString + ".pdf")

            ''Creates a document in memory of the newly scanned pages
            Dim imageStream As New System.IO.MemoryStream()
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, imageStream).SetFullCompression()

            doc.Open()
            ''Adds the images to the document
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

            ''loops to add images to page
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

            ''writes file to proper location
            Using fs As New IO.FileStream(dir.FullName + "\" + ReceiverNumber.ToString + ".pdf", IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
                fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
            End Using
        End Using

        e.Result = images
    End Sub

    Private Sub bgwk_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
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
        CheckUploadPackingSlip()

        MessageBox.Show("Packing slip uploaded with " + TotalPages.ToString + " pages.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        frm.TopMost = True
        frm.TopMost = False
    End Sub

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
            If My.Computer.Name.ToString.StartsWith("TFP") Then
                LoadingScreen.Show()
                LoadingScreen.BringToFront()
                frm.Enabled = False

                bgwkRemoteWIA = New BackgroundWorker()
                bgwkRemoteWIA.WorkerReportsProgress = True
                AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_Completed
                AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress

                remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ReceiverNumber)
                bgwkRemoteWIA.RunWorkerAsync()
            Else
                ''No scanners were detected
                MessageBox.Show("No scanners were detected (L383).", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim ScannedImages As New List(Of Image)
            FilesToDelete = New List(Of String)

            While hasMorePages
                pages += 1
                Try
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    tmp = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + Now.ToShortDateString.Replace("/", "-") + " " + Now.ToShortTimeString.Replace(":", "") + " " + pages.ToString + ".jpg"
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
                            ErrorDate = Now()
                            ErrorDescription = "PackingSlipScannerUploadAPI - ScanPages --Error trying to scan pages (Line 444)."
                            ErrorUser = EmployeeLoginName
                            ErrorComment = ex.ToString()
                            ErrorDivision = EmployeeCompanyCode
                            ErrorReferenceNumber = tmp

                            TFPErrorLogUpdate()
                            MessageBox.Show("There was an issue scanning the pages (L463).", "Unable to scan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                    bgPDF.RunWorkerAsync(ScannedImages)
                Else
                    bgAppendPDF.RunWorkerAsync(ScannedImages)
                End If
            End If
        End If
    End Sub

    Public Sub DeletePackingSlip()
        If Not CheckUploadPackingSlip() Then
            Dim fls As IO.FileInfo() = dir.GetFiles(ReceiverControl.Text + ".pdf")
            For i As Integer = 0 To fls.Length - 1
                fls(i).Delete()
            Next
            CheckUploadPackingSlip()
        End If
    End Sub

    Public Shared Sub ViewPackingSlip(ByVal dir As IO.DirectoryInfo, ByVal receiverNumb As String)
        Dim ReceiverNumber As Integer = Val(receiverNumb)
        Dim files As System.IO.FileInfo() = dir.GetFiles(receiverNumb + ".pdf")

        If files.Length > 0 Then
            Dim newPrintUploadedPickTickets As New PrintUploadedPickTicket(files(0).FullName)
            newPrintUploadedPickTickets.ShowDialog()
        Else
            MessageBox.Show("No packing slip found.", "No packing slip.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub bgwkRemoteWIA_run(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        remoteWIA.StartClient()
    End Sub

    Private Sub bgwkRemoteWIA_Progress(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Select Case e.ProgressPercentage
            Case 0
                LoadingScreen.Label1.Text = "Connecting to local system, please wait."
            Case 1
                LoadingScreen.Label1.Text = "Connected to local system, initializing scan."
            Case 2
                LoadingScreen.Label1.Text = "Attempting to scan, please wait."
            Case 3
                LoadingScreen.Label1.Text = "Waiting on file from local system."
            Case 4
                LoadingScreen.Label1.Text = "File received and being saved."
        End Select
    End Sub

    Private Sub bgwkRemoteWIA_Completed(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        LoadingScreen.Hide()

        If remoteWIA.SaveFile(dir.FullName + "\" + ReceiverNumber.ToString() + ".pdf") Then
            MessageBox.Show("Packing slip uploaded " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        frm.Enabled = True
        CheckUploadPackingSlip()
        frm.TopMost = True
        frm.TopMost = False
    End Sub
End Class
