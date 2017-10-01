Namespace Models
    Public Class Routine
        Property routineName As String
        Property isFunction As Boolean
        Property returnsRecordset As Boolean
        Property returnParam As Parameter
        Property returnLayout As Table
        Property params As New List(Of Parameter)
        Property export As Boolean = True
        Property definition As String
    End Class
End Namespace

