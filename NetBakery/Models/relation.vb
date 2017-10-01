Namespace Models
    Public Class relation
        Property thistable As String
        Property thiscolumn As String
        Property thisposition As Integer
        Property othertable As String
        Property [alias] As String
        Property othercolumn As String
        Property [optional] As Boolean
        Property multi As New List(Of relation)
    End Class
End Namespace