<Serializable()> Public Class ImageLine
    Inherits ImageObject

    Public Length As Integer
    Public Width As Integer
    ''Specifies the object name, x postion and y postion
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer)
        Name = n
        XPos = x
        YPos = y
    End Sub
    ''Specifies the object name, x postion, y postion, length and width
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal l As Integer, ByVal w As Integer)
        Name = n
        XPos = x
        YPos = y
        Length = l
        Width = w
    End Sub
    ''Specifies the object name, x postion, y postion, length, width and rotation
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal l As Integer, ByVal w As Integer, ByVal r As Double)
        Name = n
        XPos = x
        YPos = y
        Length = l
        Width = w
        Rotation = r
    End Sub
    ''Takes an image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageObject)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Length = 10
        Width = 1
    End Sub
    ''Takes an text image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageText)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Length = 10
        Width = 1
    End Sub
    ''Takes an Image image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageImage)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Length = 10
        Width = 1
    End Sub
    ''Takes an Image image object and converts it to a line image object
    Public Sub New(ByVal obj As ImageBarcode)
        Name = obj.Name
        XPos = obj.XPos
        YPos = obj.YPos
        Rotation = obj.Rotation
        Length = 10
        Width = 1
    End Sub
End Class
