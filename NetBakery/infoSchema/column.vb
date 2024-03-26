Imports System.Reflection

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
        Property IsUserSelectedKey As Boolean
        Property character_set_name As String
        Property collation_name As String
        Property IsVirtual As Boolean


        Public Overrides Function Equals(obj As Object) As Boolean
            Try
                Dim objB = TryCast(obj, column)

                If objB Is Nothing Then Return False

                For Each p As PropertyInfo In Me.GetType().GetProperties
                    If p.GetValue(Me) IsNot Nothing AndAlso p.GetValue(objB) IsNot Nothing AndAlso p.GetValue(Me).ToString <> p.GetValue(objB).ToString Then Return False
                Next
            Catch ex As Exception
                Return False
            End Try

            Return True
        End Function
    End Class
End Namespace
