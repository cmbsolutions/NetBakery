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
End Namespace


