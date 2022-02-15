Imports NetBakery.infoSchema

Public Class legacy_netGenerator
    Implements iGenerator

    Public Function generateModel(_t As table) As String Implements iGenerator.generateModel
        Try
            Dim page = New My.Templates.legacy_net.Model(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateMap(_t As table) As String Implements iGenerator.generateMap
        Try
            Dim page = New My.Templates.legacy_net.Map(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateContext(_t As List(Of table), name As String, recovery As Boolean) As String Implements iGenerator.generateContext
        Try
            Dim page = New My.Templates.legacy_net.Context(_t, name, recovery)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommands(_f As List(Of routine), _p As List(Of routine), name As String, withLock As Boolean) As String Implements iGenerator.generateStoreCommands
        Try
            Dim page = New My.Templates.legacy_net.StoreCommands(_f, _p, name, withLock)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommandSchema(_r As routine) As String Implements iGenerator.generateStoreCommandSchema
        Try
            Dim page = New My.Templates.legacy_net.StoreCommandModel(_r)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommand(_r As routine, contextName As String, withLock As Boolean) As String Implements iGenerator.generateStoreCommand
        Throw New NotImplementedException()
    End Function
End Class
