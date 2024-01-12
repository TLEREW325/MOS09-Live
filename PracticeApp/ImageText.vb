<Serializable()> Public Class ImageText
    Inherits ImageObject

    Public Value As String
    Public FontSize As Integer
    Public textEditable As Boolean
    Public Style As String
    ''Specifies the object name, x positon and y position
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer)
        Name = n
        XPos = x
        YPos = y
        Value = "Text"
        Rotation = 0
        FontSize = 10
        textEditable = False
        Style = "Normal"
    End Sub
    ''Specifies the object name, x positon, y position and text
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = 0
        FontSize = 10
        textEditable = False
        Style = "Normal"
    End Sub
    ''Specifies the object name, x positon, y position, text and rotation
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal r As Double)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = r
        FontSize = 10
        textEditable = False
        Style = "Normal"
    End Sub
    ''Specifies the object name, x positon, y position, text, rotation and font size
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal r As Double, ByVal s As Integer)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = r
        FontSize = s
        textEditable = False
        Style = "Normal"
    End Sub
    ''Specifies the object name, x positon, y position, text, rotation, font size and editable when opening it
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal r As Double, ByVal s As Integer, ByVal ed As Boolean)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = r
        FontSize = s
        textEditable = ed
        Style = "Normal"
    End Sub
    ''Specifies the object name, x positon, y position, text, rotation, font size and editable when opening it
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal r As Double, ByVal s As Integer, ByVal ed As Boolean, ByVal sty As String)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = r
        FontSize = s
        textEditable = ed
        Style = sty
    End Sub
    ''Takes an image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageObject)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = "Text"
        FontSize = 10
        textEditable = False
        Style = "Normal"
    End Sub
    ''Takes an text image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageLine)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = "Text"
        FontSize = 10
        textEditable = False
        Style = "Normal"
    End Sub
    ''Takes an Image image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageImage)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = "Text"
        FontSize = 10
        textEditable = False
    End Sub
    ''Takes an Image image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageBarcode)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = obj.Value
        FontSize = 10
        textEditable = False
        Style = "Normal"
    End Sub
End Class
