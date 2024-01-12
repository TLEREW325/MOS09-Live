Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports WIA
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports System.Drawing
Public Class TestScan
    'Dim Scanner As WIA.Device
    'Public Scanning As EventHandler(Of WIA.DeviceEvents
    Dim isLoaded As Boolean = False
    Dim InspectionDirectory As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\Inspection Reports")
    Dim FilesToDelete As List(Of String)


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""


    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        Dim CanScan As Boolean = True

        Try
            Dim mgr As New DeviceManager
        Catch ex As System.Exception
            CanScan = False
            MessageBox.Show("Computer doesn't have required applications installed to scan pick tickets.", "Unable to scan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        If CanScan Then

            ScanPages()
        End If
    End Sub


    Private Sub ScanPages(Optional ByVal newPDF As Boolean = True)
        Dim mgr As New DeviceManager
        Dim Scanner As WIA.Device = Nothing


        'Set connection properties
        'Scanner = mgr.DeviceInfos(1).("\\192.168.1.192\Brother MFC-L2700DW series")


        ''Only 1 scanner is connected
        Scanner = mgr.DeviceInfos(1).Connect()


        If Scanner IsNot Nothing Then
            'Dim item As WIA.Item = Scanner.Items(1)
            'Dim obj As Object

            'Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed

            ' ''Specific scanning properties
            'For Each prop As WIA.Property In Scanner.Items(1).Properties
            '    Dim x As WIA.IProperty = prop
            '    Select Case prop.PropertyID
            '        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
            '            obj = 0
            '            x.let_Value(obj)
            '        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
            '            obj = 2
            '            x.let_Value(obj)
            '        Case "6147" ''(DPI) Horizontal Resolution
            '            obj = 200
            '            x.let_Value(obj)
            '        Case "6148" ''(DPI) Vertical Resolution
            '            obj = 200
            '            x.let_Value(obj)
            '        Case "6151" ''horizontal extent (width)
            '            obj = 1700
            '            x.let_Value(obj)
            '        Case "6152" ''vertical extent (height)
            '            obj = 2338
            '            x.let_Value(obj)
            '    End Select
            'Next

            'Dim dial As New WIA.CommonDialog

            '********************************************************************************************************************************************
            'Dim CD As New WIA.CommonDialog
            'Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
            'F.SaveFile("C:\Temp\WIA." + F.FileExtension)

            Dim MyDialog As New WIA.CommonDialog
            Dim item As WIA.Item = Scanner.Items(1)

            MyDialog.ShowTransfer(item, WIA.FormatID.wiaFormatJPEG, False)

            Dim MyDialogImage As WIA.ImageFile = MyDialog.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.GrayscaleIntent, WiaImageBias.MaximizeQuality, , False, False, False)


            'Try
            '    Scanner = MyDialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, True)
            'Catch ex As Exception
            '    MsgBox("An error occured")
            '    Return
            'End Try

            'With Scanner.Items(1)
            '    .Properties("6146").Value = 2 '4 is Black-white,gray is 2, color 1 (Color Intent)
            '    .Properties("6147").Value = 200  'dots per inch/horizontal
            '    .Properties("6148").Value = 200 'dots per inch/vertical
            '    .Properties("6149").Value = 0 'x point where to start scan
            '    .Properties("6150").Value = 0 'y-point where to start scan
            '    .Properties("3088").Value = 1 '0 = Flatbed, 1 = ADF

            '    'Following is A4 paper size. (Not 100% accurate because real A4 Ht errors)
            '    .Properties("6151").Value = 1700 'horizontal exent DPI x inches wide
            '    .Properties("6152").Value = 2196 'vertical extent DPI x inches tall
            'End With

            ''******************************************************************************************************************************************************
            Dim hasMorePages As Boolean = True
            Dim ScannedAtleastOnePage As Boolean = False
            Dim pages As Integer = 0
            Dim ScannedImages As New List(Of System.Drawing.Image)
            FilesToDelete = New List(Of String)

            ''Loops untill all pages are scanned.
            'While hasMorePages
            '    pages += 1
            '    Try
            '        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            '        Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + Now.ToShortDateString.Replace("/", "-") + " " + Now.ToShortTimeString.Replace(":", "") + " " + pages.ToString + ".jpg"
            '        ErrorComment = "Temp File - (" + tmp + ")"
            '        Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatJPEG, False)
            '        Img.SaveFile(tmp)
            '        ScannedImages.Add(Image.FromFile(tmp))
            '        ScannedAtleastOnePage = True
            '        FilesToDelete.Add(tmp)
            '    Catch ex As System.Exception

            '    End Try
            'End While


            'Try
            Dim Counter As Integer = 1
            Dim strNumber As String = ""

            While hasMorePages
                'pages += 1
                Try
                    strNumber = CStr(Counter)

                    Dim tmp As String = "C:\ScannedImages\TempFile" + strNumber + ".jpg"

                    Dim Img As WIA.ImageFile = MyDialog.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.GrayscaleIntent, WiaImageBias.MaximizeQuality, , False, False, False)

                    Img.SaveFile(tmp)

                    ScannedImages.Add(System.Drawing.Image.FromFile(tmp))
                    ScannedAtleastOnePage = True
                    FilesToDelete.Add(tmp)
                    Counter = Counter + 1
                Catch ex As Exception
                    hasMorePages = False
                End Try
            End While

            pbxScannedImage.Image = System.Drawing.Image.FromFile("C:\ScannedImages\TempFile1.jpg")


            'Catch ex As System.Exception
            '    MsgBox("Failed - Save as File", MsgBoxStyle.OkOnly)
            'End Try
            '(item, WIA.FormatID.wiaFormatJPEG, False)

        End If
    End Sub

    Private Sub cmdLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadImage.Click

        pbxScannedImage.Image = System.Drawing.Image.FromFile("C:\ScannedImages\TempFile.jpg")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class