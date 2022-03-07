Imports NetBakery.infoSchema

Public Class phpGenerator
    Implements iGenerator

    Public Function generateModel(_t As table) As String Implements iGenerator.generateModel
        Try
            Dim page = New My.Templates.php.Model(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateMap(_t As table) As String Implements iGenerator.generateMap
        Try
            Dim page = New My.Templates.php.Map(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateContext(_t As List(Of table), name As String, recovery As Boolean, routines As List(Of infoSchema.routine)) As String Implements iGenerator.generateContext
        Try
            Dim page = New My.Templates.php.Context(_t, name, recovery)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommands(_f As List(Of routine), _p As List(Of routine), name As String, withLock As Boolean) As String Implements iGenerator.generateStoreCommands
        Try
            Dim page = New My.Templates.php.StoreCommands(_f, _p, name)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommandSchema(_r As routine) As String Implements iGenerator.generateStoreCommandSchema
        Try
            Dim page = New My.Templates.php.StoreCommandModel(_r)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommand(_r As routine, contextName As String, withLock As Boolean) As String Implements iGenerator.generateStoreCommand
        Try
            Dim page = New My.Templates.php.StoreCommand(_r)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoredFunctionModels(vbType As String) As String Implements iGenerator.generateStoredFunctionModels
        Return ""
    End Function
End Class

