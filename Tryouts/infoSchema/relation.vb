Namespace infoSchema
    <Serializable>
    Public Class relation
        Property toTable As table
        Property toColumn As column
        Property localColumn As column
        Property isOptional As Boolean
        Property [alias] As String
    End Class
End Namespace

