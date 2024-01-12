Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Bitmap
Imports System.Drawing.Graphics
Imports System.IO

Public Class Barcode39
    Private _encoding As Hashtable = New Hashtable
    Private Const _wideBarWidth As Short = 4
    Private Const _narrowBarWidth As Short = 1
    Private Const _barHeight As Short = 100

    Public Sub New()
        ''Creates the hash table of the different characters
        _encoding.Add("*", "bWbwBwBwb")
        _encoding.Add("-", "bWbwbwBwB")
        _encoding.Add("$", "bWbWbWbwb")
        _encoding.Add("%", "bwbWbWbWb")
        _encoding.Add(" ", "bWBwbwBwb")
        _encoding.Add(".", "BWbwbwBwb")
        _encoding.Add("/", "bWbWbwbWb")
        _encoding.Add("+", "bWbwbWbWb")
        _encoding.Add("0", "bwbWBwBwb")
        _encoding.Add("1", "BwbWbwbwB")
        _encoding.Add("2", "bwBWbwbwB")
        _encoding.Add("3", "BwBWbwbwb")
        _encoding.Add("4", "bwbWBwbwB")
        _encoding.Add("5", "BwbWBwbwb")
        _encoding.Add("6", "bwBWBwbwb")
        _encoding.Add("7", "bwbWbwBwB")
        _encoding.Add("8", "BwbWbwBwb")
        _encoding.Add("9", "bwBWbwBwb")
        _encoding.Add("A", "BwbwbWbwB")
        _encoding.Add("B", "bwBwbWbwB")
        _encoding.Add("C", "BwBwbWbwb")
        _encoding.Add("D", "bwbwBWbwB")
        _encoding.Add("E", "BwbwBWbwb")
        _encoding.Add("F", "bwBwBWbwb")
        _encoding.Add("G", "bwbwbWBwB")
        _encoding.Add("H", "BwbwbWBwb")
        _encoding.Add("I", "bwBwbWBwb")
        _encoding.Add("J", "bwbwBWBwb")
        _encoding.Add("K", "BwbwbwbWB")
        _encoding.Add("L", "bwBwbwbWB")
        _encoding.Add("M", "BwBwbwbWb")
        _encoding.Add("N", "bwbwBwbWB")
        _encoding.Add("O", "BwbwBwbWb")
        _encoding.Add("P", "bwBwBwbWb")
        _encoding.Add("Q", "bwbwbwBWB")
        _encoding.Add("R", "BwbwbwBWb")
        _encoding.Add("S", "bwBwbwBWb")
        _encoding.Add("T", "bwbwBwBWb")
        _encoding.Add("U", "BWbwbwbwB")
        _encoding.Add("V", "bWBwbwbwB")
        _encoding.Add("W", "BWBwbwbwb")
        _encoding.Add("X", "bWbwBwbwB")
        _encoding.Add("Y", "BWbwBwbwb")
        _encoding.Add("Z", "bWBwBwbwb")
    End Sub

    Public Function GetBarcode(ByVal toEncode As String) As Bitmap
        Dim ImageWidth As Integer = GetBarcodeWidth(toEncode) + 10
        Dim b As New Bitmap(ImageWidth, 100)
        Dim canvas As New Rectangle(0, 0, ImageWidth, 100)

        Using g As Graphics = Graphics.FromImage(b)
            g.FillRectangle(Brushes.White, 0, 0, ImageWidth, 100)

            Dim UseCode As String = String.Format("{0}{1}{0}", "*", toEncode)

            Dim XPosition As Short = 1
            Dim YPosition As Short = 1

            Dim invalidCharacter As Boolean = False
            Dim CurrentSymbol As String = String.Empty
            Dim textBrush As New SolidBrush(Color.Black)

            For j As Short = 0 To CShort(UseCode.Length - 1)
                CurrentSymbol = UseCode.Substring(j, 1)
                'check if symbol can be used
                If Not IsNothing(_encoding(CurrentSymbol)) Then
                    Dim EncodedSymbol As String = _encoding(CurrentSymbol).ToString

                    For i As Short = 0 To CShort(EncodedSymbol.Length - 1)
                        Dim CurrentCode As String = EncodedSymbol.Substring(i, 1)
                        g.FillRectangle(getBCSymbolColor(CurrentCode), XPosition, YPosition, getBCSymbolWidth(CurrentCode), _barHeight)
                        XPosition = XPosition + getBCSymbolWidth(CurrentCode)
                    Next

                    'After each written full symbol we need a whitespace (narrow width)
                    g.FillRectangle(getBCSymbolColor("w"), XPosition, YPosition, getBCSymbolWidth("w"), _barHeight)
                    XPosition = XPosition + getBCSymbolWidth("w")
                Else
                    invalidCharacter = True
                End If
            Next

            'errorhandling when an invalid character is found
            If invalidCharacter Then
                g.FillRectangle(Brushes.White, 0, 0, ImageWidth, 100)
                g.DrawString("Invalid characters found,", New Font("Courier New", 8), textBrush, 0, 0)
                g.DrawString("no barcode generated", New Font("Courier New", 8), textBrush, 0, 10)
                g.DrawString("Input was: ", New Font("Courier New", 8), textBrush, 0, 30)
                g.DrawString(toEncode, New Font("Courier New", 8), textBrush, 0, 40)
            End If
        End Using
        Return b
    End Function

    ''attempts to calculate the width of the image to be produced
    Public Function GetBarcodeWidth(ByRef toEncode As String) As Integer
        Return ((toEncode.Length + 2) * ((3 * _wideBarWidth) + (6 * _narrowBarWidth)) + (toEncode.Length + 1) * _narrowBarWidth)
    End Function

    Protected Function getBCSymbolColor(ByVal symbol As String) As System.Drawing.Brush
        getBCSymbolColor = Brushes.Black
        If symbol = "W" Or symbol = "w" Then
            getBCSymbolColor = Brushes.White
        End If
    End Function

    Protected Function getBCSymbolWidth(ByVal symbol As String) As Short
        getBCSymbolWidth = _narrowBarWidth
        If symbol = "B" Or symbol = "W" Then
            getBCSymbolWidth = _wideBarWidth
        End If
    End Function

    Protected Overridable Function FindCodecInfo(ByVal codec As String) As ImageCodecInfo
        Dim encoders As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders
        For Each e As ImageCodecInfo In encoders
            If e.FormatDescription.Equals(codec) Then Return e
        Next
        Return Nothing
    End Function
End Class
