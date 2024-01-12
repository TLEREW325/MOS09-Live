<Serializable()>Public Class ImageBarcode
    Inherits ImageObject

    Public Value As String
    Public Height As Integer
    Public includeText As Boolean
    ''Specifies the object name, x positon and y position
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer)
        Name = n
        XPos = x
        YPos = y
        Value = "Text"
        Rotation = 0
        Height = 50
        includeText = False
    End Sub
    ''Specifies the object name, x positon, y position and text
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = 0
        Height = 50
        includeText = False
    End Sub
    ''Specifies the object name, x positon, y position, text and rotation
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal r As Double)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = r
        Height = 50
        includeText = False
    End Sub
    ''Specifies the object name, x positon, y position, text, rotation and font size
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal r As Double, ByVal h As Integer)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = r
        Height = h
        includeText = False
    End Sub
    ''Specifies the object name, x positon, y position, text, rotation, font size, and to include text under
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal r As Double, ByVal h As Integer, ByVal inc As Boolean)
        Name = n
        XPos = x
        YPos = y
        Value = text
        Rotation = r
        Height = h
        includeText = inc
    End Sub
    ''Takes an image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageObject)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = "TEXT"
        Height = 50
        includeText = False
    End Sub
    ''Takes an text image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageLine)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = "TEXT"
        Height = 50
        includeText = False
    End Sub
    ''Takes an Image image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageImage)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = "TEXT"
        Height = 50
        includeText = False
    End Sub
    ''Takes an Image image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageText)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = obj.Value.ToUpper()
        Height = 50
        includeText = False
    End Sub
End Class
