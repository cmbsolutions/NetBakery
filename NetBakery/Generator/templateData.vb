Imports System.Data.Entity.Infrastructure.Pluralization

Namespace My.Templates
    Partial Public Class Model
        Private _t As infoSchema.table
        Private _i As Integer
        Private p As New PluralizationService

        Public Sub New(ByVal t As infoSchema.table)
            _t = t

        End Sub
    End Class

    Partial Public Class Map
        Private _t As infoSchema.table
        Private _i As Integer
        Private p As New PluralizationService

        Public Sub New(ByVal t As infoSchema.table)
            _t = t

            'If _t.columns.First.vbType = GetType(System.String) Then

            'End If
        End Sub
    End Class

    Partial Public Class Context
        Private _tables As List(Of infoSchema.table)
        Private _name As String
        Private _recovery As Boolean
        Private p As New PluralizationService

        Public Sub New(ByVal tables As List(Of infoSchema.table), ByVal name As String, ByVal recovery As Boolean)
            _tables = tables
            _name = name
            _recovery = recovery
        End Sub
    End Class

    Partial Public Class StoreCommands
        Private _functions As List(Of infoSchema.routine)
        Private _procedures As List(Of infoSchema.routine)
        Private _name As String

        Public Sub New(ByVal functions As List(Of infoSchema.routine), ByVal procedures As List(Of infoSchema.routine), ByVal name As String)
            _functions = functions
            _procedures = procedures
            _name = name
        End Sub
    End Class

    Partial Public Class StoreCommandModel
        Private _procedure As infoSchema.routine

        Public Sub New(ByVal procedure As infoSchema.routine)
            _procedure = procedure
        End Sub
    End Class

    Public Class PluralizationService
        Private _service As EnglishPluralizationService

        Public Sub New()
            Try
                If My.Settings.customDictionary.Count > 0 Then

                    Dim userEntries As New List(Of CustomPluralizationEntry)

                    For Each s In My.Settings.customDictionary
                        userEntries.Add(New CustomPluralizationEntry(s.Split("|"c).First, s.Split("|"c).Last))
                    Next
                    _service = New EnglishPluralizationService(userEntries)
                Else
                    _service = New EnglishPluralizationService()
                End If

            Catch ex As Exception
                Throw
            End Try
        End Sub
        Public Function Singularize(s As String) As String
            'Return ret
            Dim ret As String = _service.Singularize(s)

            Dim test As String

            ' it did not singularize, is it already single?
            If ret = s Then
                test = _service.Pluralize(s)


                If test = s Then ' it did not pluralize either, maybe its two words....
                    If s.Contains("_"c) AndAlso Not s.EndsWith("_"c) Then
                        Dim l = s.Split("_"c).LastOrDefault

                        test = _service.Singularize(l)
                        ret = s.Replace(l, test)


                        If ret = s Then ' no way to make it single, return s

                            ret = s
                        End If

                    Else
                        ret = s
                    End If

                Else ' it did pluralize, return s
                    ret = s
                End If
            End If

            Return ret
        End Function
        Public Function Pluralize(s As String) As String
            Dim ret As String = _service.Pluralize(s)
            Dim test As String = Singularize(s)

            If s = ret AndAlso s = test AndAlso test = ret Then ret &= "s"

            Return ret
        End Function
        Public Function isSingle(s As String) As Boolean
            Dim tmp As String = Singularize(s)

            Return tmp.Equals(s)
        End Function

        Public Function TryParse(s As String) As CustomPluralizationEntry
            Try
                Dim singleName As String
                Dim pluralName As String

                If isSingle(s) Then
                    singleName = s
                    pluralName = Pluralize(s)
                Else
                    singleName = Singularize(s)
                    pluralName = s
                End If

                Return New CustomPluralizationEntry(singleName, pluralName)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
