Namespace infoSchema

    <Serializable>
    Public Class table
        Inherits infoSchemaObject

        Property name As String
        Property singleName As String
        Property pluralName As String
        Property isView As Boolean
        Property escapeName As Boolean
        Property columns As New List(Of column)
        Property indexes As New List(Of index)
        Property foreignKeys As New List(Of foreignKey)
        Property relations As New List(Of relation)
        Property hasExport As Boolean
        Property HasMissingFields As Boolean
        Property NoAutoNumber As Boolean
        Property executiontime As TimeSpan
        Property table_collation As String
        Property HasBrokenForeignKeys As Boolean
        Property HasJSoNFields As Boolean
        Property CamelCaseName As String
        Property CamelCasePluralName As String
    End Class
End Namespace
