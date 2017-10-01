Namespace Models
    Public Class Column
        Property columnName As String
        Property columnAlias As String
        Property dataType As String
        Property ordinalPosition As Integer
        Property defaultValue As String
        Property isNullable As Boolean
        Property maximumLength As Long
        Property numericPrecision As Integer
        Property numericScale As Integer
        Property key As String
        Property autoIncrement As Boolean
        Property vbType As String
        Property enumData As New List(Of String)
    End Class
End Namespace

