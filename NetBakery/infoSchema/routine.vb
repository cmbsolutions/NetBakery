Namespace infoSchema
    <Serializable>
    Public Class routine
        Property name As String
        Property isFunction As Boolean
        Property returnsRecordset As Boolean
        Property returnParam As parameter
        Property returnLayout As table
        Property params As New List(Of parameter)
        Property hasExport As Boolean
        Property definition As String
        Property executiontime As TimeSpan
    End Class
End Namespace
