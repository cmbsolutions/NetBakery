Imports System.Data.Entity.Infrastructure.Pluralization

Namespace infoSchema
    Public Class inflector
        Implements IDisposable

        Private ReadOnly Property _plural As New List(Of KeyValuePair(Of String, String)) From {
            New KeyValuePair(Of String, String)("(s)tatus$", "$1tatuses"),
            New KeyValuePair(Of String, String)("(quiz)$", "$1zes"),
            New KeyValuePair(Of String, String)("^(ox)$", "$1$2en"),
            New KeyValuePair(Of String, String)("([m|l])ouse$", "$1ice"),
            New KeyValuePair(Of String, String)("(matr|vert|ind)(ix|ex)$", "$1ices"),
            New KeyValuePair(Of String, String)("(x|ch|ss|sh)$", "$1es"),
            New KeyValuePair(Of String, String)("([^aeiouy]|qu)y$", "$1ies"),
            New KeyValuePair(Of String, String)("(hive)$", "$1s"),
            New KeyValuePair(Of String, String)("(chef)$", "$1s"),
            New KeyValuePair(Of String, String)("(?:([^f])fe|([lre])f)$", "$1$2ves"),
            New KeyValuePair(Of String, String)("sis$", "ses"),
            New KeyValuePair(Of String, String)("([ti])um$", "$1a"),
            New KeyValuePair(Of String, String)("(p)erson$", "$1eople"),
            New KeyValuePair(Of String, String)("(?<!u)(m)an$", "$1en"),
            New KeyValuePair(Of String, String)("(c)hild$", "$1hildren"),
            New KeyValuePair(Of String, String)("(buffal|tomat)o$", "$1$2oes"),
            New KeyValuePair(Of String, String)("(alumn|bacill|cact|foc|fung|nucle|radi|stimul|syllab|termin)us$", "$1i"),
            New KeyValuePair(Of String, String)("us$", "uses"),
            New KeyValuePair(Of String, String)("(alias)$", "$1es"),
            New KeyValuePair(Of String, String)("(ax|cris|test)is$", "$1es"),
            New KeyValuePair(Of String, String)("s$/", "s"),
            New KeyValuePair(Of String, String)("^$/", ""),
            New KeyValuePair(Of String, String)("$/", "s")
        }




#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class

    'Public Class PluralizationService
    '    Private _service As EnglishPluralizationService

    '    Public Sub New()
    '        Try
    '            If My.Settings.customDictionary.Count > 0 Then

    '                Dim userEntries As New List(Of CustomPluralizationEntry)

    '                For Each s In My.Settings.customDictionary
    '                    userEntries.Add(New CustomPluralizationEntry(s.Split("|"c).First, s.Split("|"c).Last))
    '                Next
    '                _service = New EnglishPluralizationService(userEntries)
    '            Else
    '                _service = New EnglishPluralizationService()
    '            End If

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    '    Public Function Singularize(s As String) As String
    '        'Return ret
    '        Dim ret As String = _service.Singularize(s)

    '        Dim test As String

    '        ' it did not singularize, is it already single?
    '        If ret = s Then
    '            test = _service.Pluralize(s)


    '            If test = s Then ' it did not pluralize either, maybe its two words....
    '                If s.Contains("_"c) AndAlso Not s.EndsWith("_"c) Then
    '                    Dim l = s.Split("_"c).LastOrDefault

    '                    test = _service.Singularize(l)
    '                    ret = s.Replace(l, test)


    '                    If ret = s Then ' no way to make it single, return s

    '                        ret = s
    '                    End If

    '                Else
    '                    ret = s
    '                End If

    '            Else ' it did pluralize, return s
    '                ret = s
    '            End If
    '        End If

    '        Return ret
    '    End Function

    '    Public Function Pluralize(s As String) As String
    '        Dim ret As String = _service.Pluralize(s)
    '        Dim test As String = Singularize(s)

    '        If s = ret AndAlso s = test AndAlso test = ret Then ret &= "s"

    '        Return ret
    '    End Function

    '    Public Function isSingle(s As String) As Boolean
    '        Dim tmp As String = Singularize(s)

    '        Return tmp.Equals(s)
    '    End Function

    '    Public Function TryParse(s As String) As CustomPluralizationEntry
    '        Try
    '            Dim singleName As String
    '            Dim pluralName As String

    '            If isSingle(s) Then
    '                singleName = s
    '                pluralName = Pluralize(s)
    '            Else
    '                singleName = Singularize(s)
    '                pluralName = s
    '            End If

    '            Return New CustomPluralizationEntry(singleName, pluralName)
    '        Catch ex As Exception
    '            Return Nothing
    '        End Try
    '    End Function
    'End Class

End Namespace


