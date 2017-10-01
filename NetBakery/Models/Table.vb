Namespace Models
    Public Class Table
        Property tableName As String
        Property singleName As String
        Property pluralName As String
        Property isView As Boolean
        Property columns As List(Of Column)

        Property relations As New List(Of relation)
        Property export As Boolean = True
    End Class
End Namespace
