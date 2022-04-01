Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text

Module Extensions
    <Extension()>
    Public Function ParseToInt(ByVal i As String) As Integer
        Try
            Dim out As Integer = 0

            Integer.TryParse(i, NumberStyles.Any, New CultureInfo("en-US"), out)

            Return out
        Catch ex As Exception
            Return 0
        End Try

    End Function

    <Extension()>
    Public Function ParseToDecimal(ByVal i As String) As Decimal
        Try
            Dim out As Decimal = 0.0D

            Decimal.TryParse(i, NumberStyles.Any, New CultureInfo("en-US"), out)

            Return out
        Catch ex As Exception
            Return 0.0D
        End Try

    End Function
End Module

Module TestExtensions
    <Extension()>
    Public Function [in](ByVal needle As String, ByVal haystack As String()) As Boolean
        Try
            If haystack.Contains(needle) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    <Extension()>
    Public Function notIn(ByVal needle As String, ByVal haystack As String()) As Boolean
        Try
            If Not haystack.Contains(needle) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    <Extension()>
    Public Function maxLength(ByVal input As String, ByVal length As Integer) As String
        Try
            If input.Length > length Then
                Return input.Substring(0, length)
            Else
                Return input
            End If
        Catch ex As Exception
            Return input
        End Try
    End Function
End Module

Module ConvertExtensions
    <Extension>
    Public Function ToMD5(input As String) As String
        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() = hasher.ComputeHash(Encoding.UTF8.GetBytes(input))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString().ToLower
        End Using
    End Function
End Module

Module FileInfoExtensions

    <Extension()>
    Public Function InUse(ByVal f As IO.FileInfo) As Boolean
        Try
            Using fs As New IO.FileStream(f.FullName, IO.FileMode.Open, IO.FileAccess.ReadWrite, IO.FileShare.None)

            End Using
        Catch ex As IO.IOException
            Return True
        Catch ex As Exception
            Return True
        End Try
        Return False
    End Function
End Module

Module ExceptionExtensions

    <Extension()>
    Public Function GetLineNumber(e As Exception) As ExceptionData
        Try

            Dim trace = New StackTrace(e, True)
            Dim x As New ExceptionData

            For Each frame In trace.GetFrames
                If frame.GetFileLineNumber > 0 OrElse frame.GetFileColumnNumber > 0 Then

                    x.FileLineNumber = frame.GetFileLineNumber
                    x.FileColumnNumber = frame.GetFileColumnNumber
                    x.FileName = frame.GetFileName
                    x.FileMethod = frame.GetMethod.Name

                    Exit For
                End If
            Next

            Return x
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Module

Module ArrayExtensions
    <Extension()>
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        Array.Resize(arr, arr.Length + 1)
        arr(arr.Length - 1) = item
    End Sub
End Module
Class ExceptionData
    Public Property FileLineNumber As Integer = 0
    Public Property FileColumnNumber As Integer = 0
    Public Property FileName As String = ""
    Public Property FileMethod As String = ""

    Public Overrides Function ToString() As String
        Dim str = String.Format("{4} : File: {0}, Method: {1}, Line: {2}, Column: {3}", FileName, FileMethod, FileLineNumber.ToString, FileColumnNumber.ToString, Now.ToString("yyyy-MM-dd HH:mm:ss"))
        Return str
    End Function
End Class