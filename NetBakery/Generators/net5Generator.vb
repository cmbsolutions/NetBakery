﻿Imports NetBakery.infoSchema

Public Class net5Generator
    Implements iGenerator

    Public Function generateModel(_t As table, Optional IsStoreCommand As Boolean = False, Optional Name As String = "") As String Implements iGenerator.generateModel
        Try
            Dim page = New My.Templates.net5.Model(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateMap(_t As table) As String Implements iGenerator.generateMap
        Try
            Dim page = New My.Templates.net5.Map(_t)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateContext(_t As List(Of table), name As String, recovery As Boolean, routines As List(Of infoSchema.routine)) As String Implements iGenerator.generateContext
        Try
            Dim page = New My.Templates.net5.Context(_t, name, routines.Where(Function(c) c.hasExport).ToList)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommands(_f As List(Of routine), _p As List(Of routine), name As String, withLock As Boolean) As String Implements iGenerator.generateStoreCommands
        Try
            Dim page = New My.Templates.net5.StoreCommands(_f, _p, name, withLock)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommandSchema(_r As routine) As String Implements iGenerator.generateStoreCommandSchema
        Try
            Dim page = New My.Templates.net5.StoreCommandModel(_r)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function generateStoreCommand(_r As routine, contextName As String, withLock As Boolean) As String Implements iGenerator.generateStoreCommand
        Try
            Dim page = New My.Templates.net5.StoreCommand(_r, contextName, withLock)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
