Namespace infoSchema
    Public Class foreignKey
        Public Property name As String
        Public Property table As table
        Public Property propertyAlias As String
        Public Property column As column
        Public Property ordinalPosition As Integer
        Public Property positionInUniqueConstraint As Integer
        Public Property referencedTable As table
        Public Property referencedColumn As column
    End Class
End Namespace
