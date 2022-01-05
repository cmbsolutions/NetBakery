Namespace infoSchema
    Public Class index
        Property Name As String
        Property IsUnique As Boolean
        Property IsNullable As Boolean
        Property columns As New List(Of indexColumn)
    End Class

    Public Class indexColumn
        Property indexPosition As Integer
        Property column As column
    End Class
End Namespace
