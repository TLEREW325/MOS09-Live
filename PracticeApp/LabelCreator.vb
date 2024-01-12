Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

Public Class LabelCreator
    ''limiting the maximum image that can be selected. This wil lhelp prevent an issue with memory copying.
    Private Const MaxImageSize As Integer = 2332800
    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False

    Dim ImageObjects As Dictionary(Of String, ImageObject)
    Dim SavedFileName As String
    Dim NeedsSaved As Boolean = False
    Dim grayscale As New Imaging.ColorMatrix(New Single()() _
        { _
            New Single() {0.299, 0.299, 0.299, 0, 0}, _
            New Single() {0.587, 0.587, 0.587, 0, 0}, _
            New Single() {0.114, 0.114, 0.114, 0, 0}, _
            New Single() {0, 0, 0, 1, 0}, _
            New Single() {0, 0, 0, 0, 1} _
        })
    Dim redscale As New Imaging.ColorMatrix(New Single()() _
        { _
            New Single() {0.299, 0, 0, 0, 0}, _
            New Single() {0.587, 0, 0, 0, 0}, _
            New Single() {0.114, 0, 0, 0, 0}, _
            New Single() {0, 0, 0, 1, 0}, _
            New Single() {0, 0, 0, 0, 1} _
        })
    Dim barCode39 As New Barcode39()
    Public Sub New()
        InitializeComponent()
        isLoaded = True

        ImageObjects = New Dictionary(Of String, ImageObject)
    End Sub

    Private Sub cboFields_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFields.SelectedIndexChanged
        If isLoaded Then
            ClearFieldControls()
            If ImageObjects.ContainsKey(cboFields.Text) Then
                isLoaded = False
                HideVisiblePanel()
                txtFieldName.Text = ImageObjects(cboFields.Text).Name
                txtXPos.Text = ImageObjects(cboFields.Text).XPos.ToString()
                txtYPos.Text = ImageObjects(cboFields.Text).YPos.ToString()
                txtRotation.Text = ImageObjects(cboFields.Text).Rotation.ToString()

                If TypeOf ImageObjects(cboFields.Text) Is ImageText Then
                    Dim obj As ImageText = ImageObjects(cboFields.Text)
                    cboFieldType.Text = "Text"
                    pnlText.Show()
                    txtFontSize.Text = obj.FontSize.ToString()
                    txtText.Text = obj.Value
                    chkEditable.Checked = obj.textEditable
                    cboFontStyle.Text = obj.Style
                ElseIf TypeOf ImageObjects(cboFields.Text) Is ImageLine Then
                    Dim obj As ImageLine = ImageObjects(cboFields.Text)
                    cboFieldType.Text = "Line"
                    pnlLine.Show()
                    txtLineLength.Text = obj.Length
                    txtLineWidth.Text = obj.Width
                ElseIf TypeOf ImageObjects(cboFields.Text) Is ImageImage Then
                    Dim obj As ImageImage = ImageObjects(cboFields.Text)
                    cboFieldType.Text = "Picture"
                    pnlImage.Show()
                    txtImageHeight.Text = obj.Height.ToString()
                    txtImageWidth.Text = obj.Width.ToString()
                ElseIf TypeOf ImageObjects(cboFields.Text) Is ImageBarcode Then
                    Dim obj As ImageBarcode = ImageObjects(cboFields.Text)
                    cboFieldType.Text = "Barcode"
                    pnlBarcode.Show()
                    txtBarcodeHeight.Text = obj.Height.ToString()
                    txtBarcodeValue.Text = obj.Value
                    chkUnderlayText.Checked = obj.includeText
                End If
                isLoaded = True
                DrawImage()
            End If
        End If
    End Sub

    Private Sub cmdPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabel.Click
        If CanPrint() Then
            Dim findPrinter As String = "Zebra" + EmployeeCompanyCode

            Dim pd As New PrintDialog()
            Dim i As Integer
            pd.UseEXDialog = True
            Dim doc As New System.Drawing.Printing.PrintDocument()
            pd.Document = doc

            pd.PrinterSettings = New PrinterSettings()
            Dim printers(pd.PrinterSettings.InstalledPrinters.Count) As [String]
            pd.PrinterSettings.InstalledPrinters.CopyTo(printers, 0)
            pd.PrinterSettings.PrinterName = ""


            ''checks to see if the designated printer is present
            While i < printers.Count() - 1
                If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains(findPrinter) Then
                    pd.PrinterSettings.PrinterName = printers(i)
                End If
                i += 1
            End While
            Dim printerName As String = ""
            ''checks to see if a printer was selected and if not will show the dialog
            If String.IsNullOrEmpty(pd.PrinterSettings.PrinterName) Then
                If String.IsNullOrEmpty(printerName) Then
                    pd.PrinterSettings.Copies = nbrCopies.Value
                    ' Open the printer dialog box, and then allow the user to select a printer.
                    If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
                        pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                        pd.PrinterSettings.DefaultPageSettings.Landscape = True

                        doc.PrinterSettings = pd.PrinterSettings
                        AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
                        doc.Print()
                    End If
                Else
                    pd.PrinterSettings.Copies = nbrCopies.Value
                    pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
                    pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                    pd.PrinterSettings.DefaultPageSettings.Landscape = True
                    pd.PrinterSettings.PrinterName = printerName
                    doc.PrinterSettings = pd.PrinterSettings
                    AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
                    doc.Print()
                End If
            Else
                pd.PrinterSettings.Copies = nbrCopies.Value
                pd.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Label", 425, 600)
                pd.PrinterSettings.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                pd.PrinterSettings.DefaultPageSettings.Landscape = True
                doc.PrinterSettings = pd.PrinterSettings
                AddHandler doc.PrintPage, AddressOf PrintJournalDocument_PrintPage
                doc.Print()
            End If
        End If
    End Sub

    Private Function CanPrint() As Boolean
        If ImageObjects.Count = 0 Then
            MessageBox.Show("There is nothing to print", "Nothing to print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintJournalDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim bmp = New System.Drawing.Bitmap(600, 400)
        Using gr As System.Drawing.Graphics = Graphics.FromImage(bmp)
            gr.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit
            For i As Integer = 0 To ImageObjects.Count - 1
                If TypeOf ImageObjects.ElementAt(i).Value Is ImageText Then
                    Dim br As New SolidBrush(Color.Black)

                    Dim obj As ImageText = ImageObjects.ElementAt(i).Value

                    Dim fnt As System.Drawing.Font
                    Select Case obj.Style
                        Case "Bold"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Bold, GraphicsUnit.Point)
                        Case "Italic"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Italic, GraphicsUnit.Point)
                        Case "Normal"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                        Case Else
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                    End Select

                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawString(obj.Value, fnt, br, 0, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawString(obj.Value, fnt, br, obj.XPos, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageLine Then
                    Dim obj As ImageLine = ImageObjects.ElementAt(i).Value
                    Dim pn As New Pen(Color.Black, obj.Width)

                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawLine(pn, 0, 0, obj.Length, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawLine(pn, obj.XPos, obj.YPos, obj.XPos + obj.Length, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageImage Then
                    Dim obj As ImageImage = ImageObjects.ElementAt(i).Value
                    If obj.Value IsNot Nothing Then
                        Using pic As Bitmap = New Bitmap(obj.Value.GetThumbnailImage(obj.Width, obj.Height, Nothing, IntPtr.Zero))

                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                            End If
                        End Using
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageBarcode Then
                    Dim obj As ImageBarcode = ImageObjects.ElementAt(i).Value
                    If obj.Value IsNot Nothing Then
                        Dim fnt = New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point)
                        Dim br As New SolidBrush(Color.Black)
                        Dim tmpImg As Bitmap = barCode39.GetBarcode(obj.Value)
                        Using pic As Bitmap = tmpImg.GetThumbnailImage(tmpImg.Width, obj.Height, Nothing, IntPtr.Zero)
                            ''gets the size of the current text
                            Dim textSize As SizeF = gr.MeasureString(obj.Value, fnt)
                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(((pic.Width - textSize.Width) / 2), obj.Height + 3))
                                End If

                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel)
                                End Using

                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(obj.XPos + ((pic.Width - textSize.Width) / 2), obj.YPos + obj.Height + 3))
                                End If

                            End If
                        End Using
                    End If
                End If
            Next
        End Using
        ''draws the image on the document being printed
        e.Graphics.DrawImage(bmp, New System.Drawing.Rectangle(0, 0, 600, 400))
    End Sub

    Private Sub cboFields_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFields.Leave
        If cboFields.SelectedIndex = -1 Then
            If cboFields.Items.Count > 0 Then
                cboFields.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cboFieldType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFieldType.SelectedIndexChanged
        If isLoaded Then
            HideVisiblePanel()
            Select Case cboFieldType.Text
                Case "Text"
                    If ImageObjects.ContainsKey(cboFields.Text) Then
                        If Not (TypeOf ImageObjects(cboFields.Text) Is ImageText) Then
                            ImageObjects(cboFields.Text) = New ImageText(ImageObjects(cboFields.Text))
                        End If
                    End If
                    pnlText.Show()
                Case "Line"
                    If ImageObjects.ContainsKey(cboFields.Text) Then
                        If Not (TypeOf ImageObjects(cboFields.Text) Is ImageLine) Then
                            ImageObjects(cboFields.Text) = New ImageLine(ImageObjects(cboFields.Text))
                        End If
                    End If
                    pnlLine.Show()
                Case "Picture"
                    If ImageObjects.ContainsKey(cboFields.Text) Then
                        If Not (TypeOf ImageObjects(cboFields.Text) Is ImageImage) Then
                            ImageObjects(cboFields.Text) = New ImageImage(ImageObjects(cboFields.Text))
                        End If
                    End If
                    pnlImage.Show()
                Case "Barcode"
                    If ImageObjects.ContainsKey(cboFields.Text) Then
                        If Not (TypeOf ImageObjects(cboFields.Text) Is ImageBarcode) Then
                            ImageObjects(cboFields.Text) = New ImageBarcode(ImageObjects(cboFields.Text))
                        End If
                    End If
                    pnlBarcode.Show()
            End Select
            If cboFieldType.Focused Then
                DrawImage()
            End If
        End If
    End Sub

    Private Sub HideVisiblePanel()
        If pnlText.Visible Then
            pnlText.Hide()
        End If
        If pnlLine.Visible Then
            pnlLine.Hide()
        End If
        If pnlImage.Visible Then
            pnlImage.Hide()
        End If
        If pnlBarcode.Visible Then
            pnlBarcode.Hide()
        End If
    End Sub

    Private Sub pnlText_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlText.VisibleChanged
        If pnlText.Visible Then
            txtFontSize.Text = "10"
            txtText.Text = "Text"
            cboFontStyle.Text = "Normal"
        Else
            txtFontSize.Clear()
            txtText.Clear()
            chkEditable.Checked = False
            cboFontStyle.Text = "Normal"
        End If
    End Sub

    Private Sub XYPosition_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtXPos.KeyPress, txtYPos.KeyPress, txtRotation.KeyPress, txtFontSize.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub XYPosition_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtXPos.KeyDown, txtYPos.KeyDown, txtFontSize.KeyDown
        CheckControlKey(e)
    End Sub

    Private Sub CheckControlKey(ByVal e As System.Windows.Forms.KeyEventArgs, Optional ByVal AllowDecimal As Boolean = False)
        If e.KeyCode = Keys.Tab Then
            controlKey = True
        End If
        If e.KeyCode = Keys.Enter Then
            controlKey = True
        End If
        If e.KeyCode = Keys.Back Then
            controlKey = True
        End If
        If AllowDecimal Then
            If e.KeyCode = Keys.Decimal Then
                controlKey = True
            End If
            If e.KeyCode = Keys.OemPeriod Then
                controlKey = True
            End If
        End If
    End Sub

    Private Sub XYPosition_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtXPos.KeyUp, txtYPos.KeyUp, txtRotation.KeyUp, txtFontSize.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub txtRotation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRotation.KeyDown
        If e.KeyCode = Keys.OemMinus Or e.KeyCode = Keys.Subtract Then
            controlKey = True
        Else
            CheckControlKey(e)
        End If
    End Sub

    Private Sub cmdNewField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewField.Click
        isLoaded = False
        NeedsSaved = True
        UpdateFormTitle()
        ClearFieldControls()
        Dim cnt As Integer = 0
        If ImageObjects.ContainsKey("Field") Then
            While ImageObjects.ContainsKey("Field" + cnt.ToString)
                cnt += 1
            End While
            ImageObjects.Add("Field" + cnt.ToString, New ImageText("Field" + cnt.ToString, 0, 0))
            cboFields.Items.Add("Field" + cnt.ToString)
        Else
            ImageObjects.Add("Field", New ImageText("Field", 0, 0))
            cboFields.Items.Add("Field")
        End If
        cboFields.SelectedIndex = cboFields.Items.Count - 1
        txtFieldName.Text = cboFields.Text
        isLoaded = True
        DrawImage()
    End Sub

    Private Sub ClearFieldControls()
        Dim tmpIsLoaded As Boolean = isLoaded
        isLoaded = False
        txtFieldName.Clear()
        cboFieldType.Text = "Text"
        txtXPos.Text = "0"
        txtYPos.Text = "0"
        txtRotation.Text = "0"
        HideVisiblePanel()
        pnlText.Show()
        nbrCopies.Value = 1
        isLoaded = tmpIsLoaded
    End Sub

    Private Sub txtFieldName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFieldName.Leave
        If isLoaded Then
            If Not cboFields.Text.Equals(txtFieldName.Text) Then
                If Not ImageObjects.ContainsKey(txtFieldName.Text) Then
                    Dim tmpIndex As Integer = cboFields.SelectedIndex
                    Dim oldName As String = cboFields.Text
                    isLoaded = False

                    cboFields.Items.RemoveAt(tmpIndex)
                    cboFields.Items.Add(txtFieldName.Text)
                    cboFields.Text = txtFieldName.Text
                    isLoaded = True
                    Dim obj As ImageObject = ImageObjects(oldName)
                    obj.Name = txtFieldName.Text
                    ''removes the old key and enters the object under the new key
                    ImageObjects.Remove(oldName)
                    ImageObjects.Add(txtFieldName.Text, obj)
                Else
                    MessageBox.Show("Field name has already been taken by another field. Unable to use field name", "unable to rename", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtFieldName.SelectAll()
                    txtFieldName.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtXPos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtXPos.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtXPos.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    ImageObjects(cboFields.Text).XPos = Val(txtXPos.Text)
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub txtYPos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYPos.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtYPos.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    ImageObjects(cboFields.Text).YPos = Val(txtYPos.Text)
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub txtRotation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRotation.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtRotation.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    ImageObjects(cboFields.Text).Rotation = Val(txtRotation.Text)
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub txtFontSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFontSize.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtFontSize.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    If Val(txtFontSize.Text) = 0 Then
                        CType(ImageObjects(cboFields.Text), ImageText).FontSize = 1
                    Else
                        CType(ImageObjects(cboFields.Text), ImageText).FontSize = Val(txtFontSize.Text)
                    End If

                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub txtText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtText.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtText.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    CType(ImageObjects(cboFields.Text), ImageText).Value = txtText.Text
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub DrawImage()
        Dim bmp = New System.Drawing.Bitmap(600, 400)
        Using gr As System.Drawing.Graphics = Graphics.FromImage(bmp)
            gr.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit
            For i As Integer = 0 To ImageObjects.Count - 1
                If TypeOf ImageObjects.ElementAt(i).Value Is ImageText Then
                    Dim br As New SolidBrush(Color.Black)

                    Dim obj As ImageText = ImageObjects.ElementAt(i).Value
                    If cboFields.Text.Equals(obj.Name) Then
                        br = New SolidBrush(Color.Red)
                    End If
                    Dim fnt As System.Drawing.Font
                    Select Case obj.Style
                        Case "Bold"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Bold, GraphicsUnit.Point)
                        Case "Italic"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Italic, GraphicsUnit.Point)
                        Case "Normal"
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                        Case Else
                            fnt = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, obj.FontSize, FontStyle.Regular, GraphicsUnit.Point)
                    End Select
                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawString(obj.Value, fnt, br, 0, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawString(obj.Value, fnt, br, obj.XPos, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageLine Then
                    Dim obj As ImageLine = ImageObjects.ElementAt(i).Value
                    Dim pn As New Pen(Color.Black, obj.Width)
                    If cboFields.Text.Equals(obj.Name) Then
                        pn = New Pen(Color.Red, obj.Width)
                    End If
                    If obj.Rotation <> 0 Then
                        gr.TranslateTransform(obj.XPos, obj.YPos)
                        gr.RotateTransform(obj.Rotation)
                        gr.DrawLine(pn, 0, 0, obj.Length, 0)
                        gr.ResetTransform()
                    Else
                        gr.DrawLine(pn, obj.XPos, obj.YPos, obj.XPos + obj.Length, obj.YPos)
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageImage Then
                    Dim obj As ImageImage = ImageObjects.ElementAt(i).Value
                    If obj.Value IsNot Nothing Then
                        Using pic As Bitmap = New Bitmap(obj.Value.GetThumbnailImage(obj.Width, obj.Height, Nothing, IntPtr.Zero))
                            Dim imgattr As New Imaging.ImageAttributes()
                            If cboFields.Text.Equals(obj.Name) Then
                                imgattr.SetColorMatrix(redscale)
                            End If

                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                            End If
                        End Using
                    End If
                ElseIf TypeOf ImageObjects.ElementAt(i).Value Is ImageBarcode Then
                    Dim obj As ImageBarcode = ImageObjects.ElementAt(i).Value
                    Dim fnt = New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point)

                    If obj.Value IsNot Nothing Then
                        Dim br As New SolidBrush(Color.Black)
                        If cboFields.Text.Equals(obj.Name) Then
                            br = New SolidBrush(Color.Red)
                        End If
                        Dim tmpImg As Bitmap = barCode39.GetBarcode(obj.Value)
                        Using pic As Bitmap = tmpImg.GetThumbnailImage(tmpImg.Width, obj.Height, Nothing, IntPtr.Zero)
                            Dim imgattr As New Imaging.ImageAttributes()
                            If cboFields.Text.Equals(obj.Name) Then
                                imgattr.SetColorMatrix(redscale)
                            Else
                                imgattr.SetColorMatrix(grayscale)
                            End If
                            Dim textSize As SizeF = gr.MeasureString(obj.Value, fnt)
                            If obj.Rotation <> 0 Then
                                gr.TranslateTransform(obj.XPos, obj.YPos)
                                gr.RotateTransform(obj.Rotation)
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using
                                gr.DrawImage(pic, New System.Drawing.PointF(0, 0))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(((pic.Width - textSize.Width) / 2), obj.Height + 3))
                                End If

                                gr.ResetTransform()
                            Else
                                Using g As Graphics = Graphics.FromImage(pic)
                                    g.DrawImage(pic, New System.Drawing.Rectangle(0, 0, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel, imgattr)
                                End Using

                                gr.DrawImage(pic, New System.Drawing.PointF(obj.XPos, obj.YPos))
                                If obj.includeText Then
                                    gr.DrawString(obj.Value, fnt, br, New System.Drawing.PointF(obj.XPos + ((pic.Width - textSize.Width) / 2), obj.YPos + obj.Height + 3))
                                End If

                            End If
                        End Using
                    End If
                End If
            Next
        End Using

        picbxLabel.Image = bmp
    End Sub

    Private Sub pnlLine_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlLine.VisibleChanged
        If pnlLine.Visible Then
            txtLineLength.Text = 10
            txtLineWidth.Text = 1
        Else
            txtLineLength.Clear()
            txtLineWidth.Clear()
        End If
    End Sub

    Private Sub txtLineLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineLength.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtLineLength.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    CType(ImageObjects(cboFields.Text), ImageLine).Length = Val(txtLineLength.Text)
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub txtLineWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineWidth.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtLineWidth.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    CType(ImageObjects(cboFields.Text), ImageLine).Width = Val(txtLineWidth.Text)
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub SaveLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveLabelToolStripMenuItem.Click, cmdSave.Click
        If canSave() Then
            If SavedFileName Is Nothing Then
                ''sends it to the save as because it does not have a saved file associated to it.
                SaveAs_Click(sender, e)
            ElseIf String.IsNullOrEmpty(SavedFileName) Then
                ''sends it to the save as because it does not have a saved file associated to it.
                SaveAs_Click(sender, e)
            Else
                ''saves the serialized image objects for the current label.
                SaveFile()
                UpdateFormTitle()
            End If
        End If
    End Sub

    Private Function canSave() As Boolean
        If ImageObjects.Count = 0 Then
            MessageBox.Show("There is nothing to save.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub SaveFile()
        Try
            Dim serializer As New BinaryFormatter()
            Using fs As System.IO.FileStream = System.IO.File.Create(SavedFileName)
                serializer.Serialize(fs, ImageObjects)
            End Using
            NeedsSaved = False
            MessageBox.Show(SavedFileName.Substring(SavedFileName.LastIndexOf("\") + 1) + " has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As System.Exception
            sendErrorToDataBase("LabelCreator - cmdSave --Error trying to save label file.", "File " + SavedFileName, ex.ToString())
            MessageBox.Show("There was an issue saving the file. Try again and if issue persists contact system admin.", "Unable to save file", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadLabelToolStripMenuItem.Click, cmdLoad.Click
        Dim fd As New OpenFileDialog()
        fd.DefaultExt = ".TFPlbl"
        fd.Filter = "Label(*.TFPlbl)|*.TFPlbl"

        If fd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If canLoad() Then
                Dim serializer As New BinaryFormatter()
                Using fw As System.IO.FileStream = System.IO.File.OpenRead(fd.FileName)
                    ImageObjects = serializer.Deserialize(fw)
                End Using
                LoadFields()
                SavedFileName = fd.FileName
                UpdateFormTitle()
            End If
        End If
    End Sub

    Private Function canLoad()
        If ImageObjects.Count > 0 Then
            If MessageBox.Show("Are you sure you want to load a saved label? Any unsaved data will be lost.", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub LoadFields()
        Dim tmpIsLoaded As Boolean = isLoaded
        isLoaded = False
        ClearFieldControls()
        cboFields.Items.Clear()
        For i As Integer = 0 To ImageObjects.Count - 1
            cboFields.Items.Add(ImageObjects.ElementAt(i).Key)
        Next
        isLoaded = tmpIsLoaded
        cboFields.SelectedIndex = cboFields.Items.Count - 1
    End Sub
    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Now
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

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDeleteFiled() Then
            ImageObjects.Remove(cboFields.Text)
            LoadFields()
            If cboFields.Items.Count = 0 Then
                cboFields.Text = ""
                DrawImage()
                NeedsSaved = False
            End If
        End If
    End Sub

    Private Function canDeleteFiled() As Boolean
        If String.IsNullOrEmpty(cboFields.Text) Then
            MessageBox.Show("There is not field selected to delete", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFields.Focus()
            Return False
        End If
        If cboFields.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid field to delete", "Enter a valid field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFields.SelectAll()
            cboFields.Focus()
            Return False
        End If
        If MessageBox.Show("Are you sure you wish to delete " + cboFields.Text, "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, NewLabelToolStripMenuItem.Click
        If NeedsSaved Then
            If MessageBox.Show("You have unsaved changes. Do you wish to save?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                SaveLabel_Click(sender, e)
            End If
        End If
        ImageObjects.Clear()
        cboFields.Text = ""
        DrawImage()
        ClearFieldControls()
        SavedFileName = Nothing
        NeedsSaved = False
        UpdateFormTitle()
    End Sub

    Private Sub txtImageHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImageHeight.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtImageHeight.Focused Then
                    NeedsSaved = True
                    If Val(txtImageHeight.Text) > 0 Then
                        CType(ImageObjects(cboFields.Text), ImageImage).Height = Val(txtImageHeight.Text)
                    Else
                        CType(ImageObjects(cboFields.Text), ImageImage).Height = 1
                    End If
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub txtImageWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImageWidth.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtImageWidth.Focused Then
                    NeedsSaved = True
                    If Val(txtImageWidth.Text) > 0 Then
                        CType(ImageObjects(cboFields.Text), ImageImage).Width = Val(txtImageWidth.Text)
                    Else
                        CType(ImageObjects(cboFields.Text), ImageImage).Width = 1
                    End If

                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub pnlImage_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlImage.VisibleChanged
        If pnlImage.Visible Then
            txtImageHeight.Text = "100"
            txtImageWidth.Text = "100"
        Else
            txtImageHeight.Clear()
            txtImageWidth.Clear()
        End If
    End Sub

    Private Sub cmdSelectPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectPicture.Click
        Dim fileSelect As New OpenFileDialog()
        fileSelect.Filter = "Image Files (*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png)|*.bmp;*.jpg;*.gif;*.jpeg;*.tiff;*.png"
        fileSelect.FilterIndex = 1

        If fileSelect.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim tmpImg As Image
            Using fs As System.IO.Stream = System.IO.File.OpenRead(fileSelect.FileName)
                tmpImg = Image.FromStream(fs)
            End Using
            CType(ImageObjects(cboFields.Text), ImageImage).Value = CopyImage(tmpImg)
            tmpImg.Dispose()
            DrawImage()
        End If
    End Sub

    Private Function CopyImage(ByRef img As Image) As Bitmap
        If (img.Height * img.Width) <= MaxImageSize Then
            Dim bmp As New Bitmap(img)
            Dim bmpData As BitmapData = bmp.LockBits(New System.Drawing.Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, bmp.PixelFormat)

            Dim byteCount As Integer = bmpData.Stride * bmpData.Height
            Dim bytes(byteCount) As Byte

            Marshal.Copy(bmpData.Scan0, bytes, 0, byteCount)
            bmp.UnlockBits(bmpData)

            Dim bmpNew As Bitmap = New Bitmap(bmp.Width, bmp.Height)
            Try
                Dim bmpData1 As BitmapData = bmpNew.LockBits(New System.Drawing.Rectangle(New System.Drawing.Point(), bmpNew.Size), ImageLockMode.ReadWrite, bmp.PixelFormat)
                Marshal.Copy(bytes, 0, bmpData1.Scan0, bytes.Length)
                bmpNew.UnlockBits(bmpData1)
            Catch ex As System.Exception
                MessageBox.Show("There was an issue processing the selected picture.", "Unable to add picture", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return Nothing
            End Try

            bmp.Dispose()
            Return bmpNew
        Else
            MessageBox.Show("Picture selected was larger than what can be processed (maximum size is 1527 X 1527). Try reselecting the image or cropping the image in paint.", "Unable to add picture", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End If
    End Function

    Private Sub SaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveLabelAsToolStripMenuItem.Click
        If canSave() Then
            Dim sv As New SaveFileDialog()
            sv.DefaultExt = ".TFPlbl"
            sv.Filter = "Label(*.TFPlbl)|*.TFPlbl"
            sv.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            sv.AddExtension = True
            sv.OverwritePrompt = True

            If SavedFileName IsNot Nothing Then
                If Not String.IsNullOrEmpty(SavedFileName) Then
                    Dim startIndex As Integer = SavedFileName.LastIndexOf("\") + 1
                    sv.FileName = SavedFileName.Substring(startIndex, SavedFileName.LastIndexOf(".") - startIndex)
                End If
            End If

            If sv.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                SavedFileName = sv.FileName
                ''Saves a serialized object with all the different image objects
                SaveFile()
                UpdateFormTitle()
            End If
        End If

    End Sub

    Private Sub UpdateFormTitle()
        If SavedFileName IsNot Nothing Then
            If Not String.IsNullOrEmpty(SavedFileName) Then
                If NeedsSaved Then
                    Me.Text = "Label Creator* (" + SavedFileName.Substring(SavedFileName.LastIndexOf("\") + 1) + ")"
                Else
                    Me.Text = "Label Creator (" + SavedFileName.Substring(SavedFileName.LastIndexOf("\") + 1) + ")"
                End If
            Else
                If NeedsSaved Then
                    Me.Text = "Label Creator*"
                Else
                    Me.Text = "Label Creator"
                End If
            End If
        Else
            If NeedsSaved Then
                Me.Text = "Label Creator*"
            Else
                Me.Text = "Label Creator"
            End If
        End If

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub DisposeObjects()
        For i As Integer = 0 To ImageObjects.Count - 1
            If TypeOf ImageObjects.ElementAt(i).Value Is ImageImage Then
                Dim obj As ImageImage = ImageObjects.ElementAt(i).Value
                If obj.Value IsNot Nothing Then
                    obj.Value.Dispose()
                End If
            End If
        Next
        Me.Dispose()
    End Sub

    Private Sub LabelCreator_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If NeedsSaved Then
            Dim rslt As DialogResult = MessageBox.Show("Do you wish to save changes before exiting? Any unsaved changes will be discarded.", "Save label", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rslt = System.Windows.Forms.DialogResult.Yes Then
                SaveLabel_Click(sender, e)
            End If
        End If
        DisposeObjects()
    End Sub

    Private Sub pnlBarcode_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlBarcode.VisibleChanged
        If pnlBarcode.Visible Then
            txtBarcodeHeight.Text = "50"
            txtBarcodeValue.Text = "Text"
        Else
            txtBarcodeHeight.Clear()
            txtBarcodeValue.Clear()
        End If
    End Sub

    Private Sub txtBarcodeHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcodeHeight.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtBarcodeHeight.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    If Val(txtBarcodeHeight.Text) <> 0 Then
                        CType(ImageObjects(cboFields.Text), ImageBarcode).Height = Val(txtBarcodeHeight.Text)
                    Else
                        CType(ImageObjects(cboFields.Text), ImageBarcode).Height = 100
                    End If
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub txtBarcodeValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcodeValue.TextChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(cboFields.Text) Then
                If txtBarcodeValue.Focused Then
                    NeedsSaved = True
                    UpdateFormTitle()
                    CType(ImageObjects(cboFields.Text), ImageBarcode).Value = txtBarcodeValue.Text
                    DrawImage()
                End If
            End If
        End If
    End Sub

    Private Sub chkUnderlayText_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnderlayText.CheckedChanged
        If isLoaded Then
            If chkUnderlayText.Focused And Not String.IsNullOrEmpty(cboFields.Text) Then
                NeedsSaved = True
                UpdateFormTitle()
                CType(ImageObjects(cboFields.Text), ImageBarcode).includeText = chkUnderlayText.Checked
                DrawImage()
            End If
        End If
    End Sub

    Private Sub chkEditable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEditable.CheckedChanged
        If isLoaded Then
            If chkEditable.Focused And Not String.IsNullOrEmpty(cboFields.Text) Then
                NeedsSaved = True
                UpdateFormTitle()
                CType(ImageObjects(cboFields.Text), ImageText).textEditable = chkEditable.Checked
                DrawImage()
            End If
        End If
    End Sub

    Private Sub cboFontStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFontStyle.SelectedIndexChanged
        If isLoaded Then
            If cboFontStyle.Focused And Not String.IsNullOrEmpty(cboFields.Text) Then
                NeedsSaved = True
                UpdateFormTitle()
                If Not String.IsNullOrEmpty(cboFontStyle.Text) And cboFontStyle.SelectedIndex <> -1 Then
                    CType(ImageObjects(cboFields.Text), ImageText).Style = cboFontStyle.Text
                Else
                    CType(ImageObjects(cboFields.Text), ImageText).Style = "Normal"
                End If
                DrawImage()
            End If
        End If
    End Sub
End Class
