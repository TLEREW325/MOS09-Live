<Serializable()> Public Class ImageObject
    Public Name As String
    Public XPos As Integer
    Public YPos As Integer
    Public Rotation As Double
    ''Default constructor
    Public Sub New()
        Name = ""
        XPos = 0
        YPos = 0
        Rotation = 0
    End Sub
    ''Specifies object name, x postion and y position
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer)
        Name = n
        XPos = x
        YPos = y
        Rotation = 0
    End Sub
    ''Specifies object name, x postion, y position and rotation
    Public Sub New(ByVal n As String, ByVal x As Integer, ByVal y As Integer, ByVal r As Double)
        Name = n
        XPos = x
        YPos = y
        Rotation = r
    End Sub
End Class
