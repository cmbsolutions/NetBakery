Namespace infoSchema
    Public Class column
        Property name As String
        Property [alias] As String
        Property mysqlType As String
        Property MySqlColumnType As String
        Property vbType As String
        Property phpType As String
        Property ordinalPosition As Integer
        Property defaultValue As String
        Property isNullable As Boolean
        Property maximumLength As Long
        Property numericPrecision As Integer
        Property numericScale As Integer
        Property key As String
        Property autoIncrement As Boolean
        Property enums As New List(Of String)
    End Class
End Namespace
