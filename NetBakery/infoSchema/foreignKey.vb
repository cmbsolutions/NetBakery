Namespace infoSchema
    Public Class foreignKey
        Public Property name As String
        Public Property table As table
        Public Property propertyAlias As String
        Public Property columns As New List(Of fkColumn)
        Public Property ordinalPosition As Integer
        Public Property positionInUniqueConstraint As Integer
        Public Property referencedTable As table
        Public Property referencedColumns As New List(Of fkColumn)
        Public Property MissingReferencedTable As Boolean
    End Class

    Public Class fkColumn
        Property fkPosition As Integer
        Property column As column
    End Class
End Namespace
