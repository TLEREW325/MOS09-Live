<Serializable()> Public Class ImageImage
    Inherits ImageObject

    Public Value As Image
    Public Width As Integer
    Public Height As Integer

    ''Specifies the object name, x postion and y postion
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer)
        Name = n
        XPos = x
        YPos = y
    End Sub
    ''Specifies the object name, x postion, y postion and image
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal i As Image)
        Name = n
        XPos = x
        YPos = y
        Value = i
    End Sub
    ''Specifies the object name, x postion, y postion, height and width
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal i As Image, ByVal h As Integer, ByVal w As Integer)
        Name = n
        XPos = x
        YPos = y
        Value = i
        Height = h
        Width = w
    End Sub
    ''Specifies the object name, x postion, y postion, height, width and rotation
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal i As Image, ByVal h As Integer, ByVal w As Integer, ByVal r As Double)
        Name = n
        XPos = x
        YPos = y
        Value = i
        Height = h
        Width = w
        Rotation = r
    End Sub
    ''Takes an image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageObject)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Value = Nothing
        Rotation = obj.Rotation
        Height = 100
        Width = 100
    End Sub
    ''Takes an text image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageText)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Value = Nothing
        Rotation = obj.Rotation
        Height = 100
        Width = 100
    End Sub
    ''Takes an text image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageLine)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = Nothing
        Width = 100
        Height = 100
    End Sub
    ''Takes an Image image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageBarcode)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Value = Nothing
        Width = 100
        Height = 100
    End Sub
End Class
