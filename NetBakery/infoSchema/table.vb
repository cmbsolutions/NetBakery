Namespace infoSchema

    <Serializable>
    Public Class table
        Property tableName As String
        Property singleName As String
        Property pluralName As String
        Property isView As Boolean
        Property columns As New List(Of column)
        Property foreignKeys As New List(Of foreignKey)
        Property hasExport As Boolean
    End Class
End Namespace
