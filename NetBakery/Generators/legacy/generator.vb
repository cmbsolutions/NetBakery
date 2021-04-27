Public Class generator
    Public Function generateModel(ByVal _t As infoSchema.table) As String
        Try
            Dim page = New My.Templates.Model(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateMap(ByVal _t As infoSchema.table) As String
        Try
            Dim page = New My.Templates.Map(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateContext(ByVal tables As List(Of infoSchema.table), ByVal name As String, ByVal recovery As Boolean) As String
        Try
            Dim page = New My.Templates.Context(tables, name, recovery)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommands(ByVal functions As List(Of infoSchema.routine), ByVal procedures As List(Of infoSchema.routine), ByVal name As String) As String
        Try
            Dim page = New My.Templates.StoreCommands(functions, procedures, name)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommandSchema(ByVal procedure As infoSchema.routine) As String
        Try
            Dim page = New My.Templates.StoreCommandModel(procedure)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
