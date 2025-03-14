Public Class SearchTypeException : Inherits Exception
    Public Property ExceptionMessage As String


    Public Sub New(ByVal Message As String)
        MyBase.New($"{Message}")
        ExceptionMessage = Message
    End Sub
End Class
