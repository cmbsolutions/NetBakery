Imports System.Runtime.CompilerServices

Module Extensions
    <Extension()>
    Public Function [in](s As String, lst() As String) As Boolean
        For Each itm In lst
            If s.Contains(itm) Then Return True
        Next

        Return False
    End Function
End Module
