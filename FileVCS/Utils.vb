Imports System.Security.Cryptography
Imports System.Text

Public Class Utils
    Public Shared Function GetFileHash(filename As String) As String
        Using f = IO.File.OpenRead(filename)
            Using sha256Hash As SHA256 = SHA256.Create
                Dim data() As Byte = sha256Hash.ComputeHash(f)
                Dim sBuilder As New StringBuilder()

                For i As Integer = 0 To data.Length - 1
                    sBuilder.Append(data(i).ToString("x2"))
                Next

                Return sBuilder.ToString()
            End Using
        End Using
    End Function

    Public Shared Function GetHash(ByVal hashAlgorithm As HashAlgorithm, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next

        ' Return the hexadecimal string.
        Return sBuilder.ToString()
    End Function

    ' Verify a hash against a string.
    Private Function VerifyHash(hashAlgorithm As HashAlgorithm, input As String, hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetHash(hashAlgorithm, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        Return comparer.Compare(hashOfInput, hash) = 0
    End Function
End Class