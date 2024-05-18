Namespace infoSchema
    <Serializable>
    Public Class routine
        Inherits infoSchemaObject

        Property name As String
        Property isFunction As Boolean
        Property returnsRecordset As Boolean
        Property returnParam As parameter
        Property returnLayout As table
        Property params As New List(Of parameter)
        Property hasExport As Boolean
        Property executiontime As TimeSpan
        Property UseBaseLayout As Boolean
        Property BaseLayoutName As String
        Property CanExecute As Boolean
    End Class
End Namespace
