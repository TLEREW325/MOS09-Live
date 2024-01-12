Public Class ViewPictureFullScreen
    Dim isLoaded As Boolean = False
    Dim controlKey As Boolean = False
    Dim OriginalImage As Image

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal img As Image)
        InitializeComponent()

        OriginalImage = img
        Dim resizeHeightPercent As Double = 1
        If img.Height > picbxFullScreenPicture.Height Then
            resizeHeightPercent = Convert.ToDouble(picbxFullScreenPicture.Height) / Convert.ToDouble(img.Height)
        End If
        picbxFullScreenPicture.Image = img.GetThumbnailImage(Convert.ToInt32(resizeHeightPercent * img.Width), Convert.ToInt32(resizeHeightPercent * img.Height), Nothing, IntPtr.Zero)
        SetScrollBars()

        resizeHeightPercent = Math.Round(resizeHeightPercent * 100, 0)
        Dim pos As Integer = 0
        Dim notFound As Boolean = True
        While pos < cboScale.Items.Count And notFound
            If Val(cboScale.Items(pos)) > resizeHeightPercent Then
                notFound = False
            Else
                pos += 1
            End If
        End While
        If Not notFound And Not cboScale.Items.Contains(resizeHeightPercent.ToString()) Then
            cboScale.Items.Insert(pos, resizeHeightPercent.ToString())
        End If
        cboScale.Text = resizeHeightPercent
        isLoaded = True
    End Sub


    Private Sub SetScrollBars()
        If picbxFullScreenPicture.Image IsNot Nothing Then
            ''checks the width of the current picture and will adjust the scroll bar accordingly
            If picbxFullScreenPicture.Image.Width > picbxFullScreenPicture.Width Then
                hscrlFullScreenPicture.Maximum = picbxFullScreenPicture.Image.Width - picbxFullScreenPicture.Width
                hscrlFullScreenPicture.Enabled = True
            Else
                hscrlFullScreenPicture.Maximum = 0
                hscrlFullScreenPicture.Enabled = False
            End If
            ''checks the height of the current picture and will adjust the scroll bar accordingly
            If picbxFullScreenPicture.Image.Height > picbxFullScreenPicture.Height Then
                vscrlFullScreenPicture.Maximum = picbxFullScreenPicture.Image.Height - picbxFullScreenPicture.Height
                vscrlFullScreenPicture.Enabled = True
            Else
                vscrlFullScreenPicture.Maximum = 0
                vscrlFullScreenPicture.Enabled = False
            End If
        Else
            hscrlFullScreenPicture.Maximum = 0
            hscrlFullScreenPicture.Enabled = False
            vscrlFullScreenPicture.Maximum = 0
            vscrlFullScreenPicture.Enabled = False
        End If
    End Sub

    Private Sub HandleScroll(ByVal sender As System.Object, ByVal e As ScrollEventArgs) Handles hscrlFullScreenPicture.Scroll, vscrlFullScreenPicture.Scroll
        If picbxFullScreenPicture.Image IsNot Nothing Then
            Dim graps As Graphics = picbxFullScreenPicture.CreateGraphics()

            Dim picbxWidth As Integer = picbxFullScreenPicture.Width
            Dim picbxHeight As Integer = picbxFullScreenPicture.Height

            Dim x As Integer
            Dim y As Integer
            ''check to see how the user scrolled
            If (e.ScrollOrientation = ScrollOrientation.HorizontalScroll) Then
                x = e.NewValue
                y = vscrlFullScreenPicture.Value
            Else
                x = hscrlFullScreenPicture.Value
                y = e.NewValue
            End If
            ''redraws the image *I think it just draws the image on the image that was already there without clearing the draw space
            graps.DrawImage(picbxFullScreenPicture.Image, New System.Drawing.Rectangle(0, 0, picbxWidth, picbxHeight), New System.Drawing.Rectangle(x, y, picbxWidth, picbxHeight), GraphicsUnit.Pixel)

            picbxFullScreenPicture.Update()
        End If
    End Sub

    Private Sub picbxFullScreenPicture_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picbxFullScreenPicture.SizeChanged
        SetScrollBars()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Hide()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintToolStripMenuItem.Click
        Dim pd As New PrintDialog()
        Dim doc As New System.Drawing.Printing.PrintDocument()
        pd.UseEXDialog = True
        pd.Document = doc
        ''opens the print dialog and if the user hits print will print the image
        If pd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AddHandler doc.PrintPage, AddressOf PrintDocument_PrintPage
            doc.Print()
        End If
    End Sub

    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim xbound As Integer = e.Graphics.VisibleClipBounds.Width
        Dim ybound As Integer = e.Graphics.VisibleClipBounds.Height

        ''checks to see which bound is smaller and will use the smaller bound for the image for width
        If picbxFullScreenPicture.Image.Width < e.Graphics.VisibleClipBounds.Width Then
            xbound = picbxFullScreenPicture.Image.Width
        End If
        ''checks to see which bound is smaller and will use the smaller bound for the image for height
        If picbxFullScreenPicture.Image.Height < e.Graphics.VisibleClipBounds.Height Then
            ybound = picbxFullScreenPicture.Image.Height
        End If

        e.Graphics.DrawImage(picbxFullScreenPicture.Image, New System.Drawing.Rectangle(0, 0, xbound, ybound))

    End Sub

    Private Sub cboScale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScale.SelectedIndexChanged
        If isLoaded Then
            ''rescales the image based on the value in the combobox
            picbxFullScreenPicture.Image = OriginalImage.GetThumbnailImage(OriginalImage.Width * (Val(cboScale.Text) / 100), OriginalImage.Height * (Val(cboScale.Text) / 100), Nothing, IntPtr.Zero)
            SetScrollBars()
            CheckSizeButtons()
        End If
    End Sub

    Private Sub CheckSizeButtons()
        If cboScale.SelectedIndex = cboScale.Items.Count - 1 Then
            cmdIncreaseSize.Enabled = False
        Else
            cmdIncreaseSize.Enabled = True
        End If
        If cboScale.SelectedIndex = 0 Then
            cmdDecreaseSize.Enabled = False
        Else
            cmdDecreaseSize.Enabled = True
        End If
    End Sub

    Private Sub cboScale_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboScale.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub cboScale_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboScale.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            controlKey = True
        End If
    End Sub

    Private Sub cmdIncreaseSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncreaseSize.Click
        If cboScale.SelectedIndex < cboScale.Items.Count - 1 Then
            cboScale.SelectedIndex = cboScale.SelectedIndex + 1
        End If
        CheckSizeButtons()
    End Sub

    Private Sub cmdDecreaseSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDecreaseSize.Click
        If cboScale.SelectedIndex > 0 Then
            cboScale.SelectedIndex = cboScale.SelectedIndex - 1
        End If
        CheckSizeButtons()
    End Sub

    Private Sub BlueprintJournalPictureFullScreen_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If picbxFullScreenPicture.Image IsNot Nothing Then
            picbxFullScreenPicture.Image.Dispose()
            picbxFullScreenPicture.Image = Nothing
        End If
    End Sub

    Private Sub picbxFullScreenPicture_MouseWheel(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picbxFullScreenPicture.MouseWheel
        If vscrlFullScreenPicture.Enabled Then
            ''check to see if the user scrolled up or down
            If e.Delta > 0 Then
                ''check ot make sure we are not going below 0
                If vscrlFullScreenPicture.Value > 0 Then
                    If vscrlFullScreenPicture.Value - 5 < 0 Then
                        vscrlFullScreenPicture.Value = 0
                    Else
                        vscrlFullScreenPicture.Value -= 5
                    End If
                End If
            Else
                ''check to make sure we are not going above the max
                If vscrlFullScreenPicture.Value < vscrlFullScreenPicture.Maximum Then
                    If vscrlFullScreenPicture.Value + 5 > vscrlFullScreenPicture.Maximum Then
                        vscrlFullScreenPicture.Value = vscrlFullScreenPicture.Maximum
                    Else
                        vscrlFullScreenPicture.Value += 5
                    End If
                End If
            End If
            Dim graps As Graphics = picbxFullScreenPicture.CreateGraphics()

            Dim picbxWidth As Integer = picbxFullScreenPicture.Width
            Dim picbxHeight As Integer = picbxFullScreenPicture.Height

            Dim x As Integer = hscrlFullScreenPicture.Value
            Dim y As Integer = vscrlFullScreenPicture.Value
            ''redraws the image *I think it just draws the image on the image that was already there without clearing the draw space
            graps.DrawImage(picbxFullScreenPicture.Image, New System.Drawing.Rectangle(0, 0, picbxWidth, picbxHeight), New System.Drawing.Rectangle(x, y, picbxWidth, picbxHeight), GraphicsUnit.Pixel)

            picbxFullScreenPicture.Update()
        End If
    End Sub
End Class