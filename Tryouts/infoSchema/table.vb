Namespace infoSchema

    <Serializable>
    Public Class table
        Property name As String
        Property singleName As String
        Property pluralName As String
        Property isView As Boolean
        Property columns As New List(Of column)
        Property indexes As New List(Of index)
        Property foreignKeys As New List(Of foreignKey)
        Property relations As New List(Of relation)
        Property hasExport As Boolean
        Property definition As String
        Property parents As New List(Of table)
        Property children As New List(Of table)
    End Class
End Namespace
