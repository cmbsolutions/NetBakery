Imports System.Security.Cryptography
Imports System.Text

Public Class Utils
    Public Shared Function Gethash(Optional filename As String = Nothing, Optional input As String = Nothing) As String
        If filename IsNot Nothing AndAlso filename <> "" Then
            Return GetHash(filename)
        End If
        If input IsNot Nothing AndAlso input <> "" Then
            Return GetHash(SHA384.Create, input)
        End If

        Return ""
    End Function

    Public Shared Function GetHash(filename As String) As String
        If Not IO.File.Exists(filename) Then Return ""

        Dim contents = IO.File.ReadAllText(filename)

        Return GetHash(SHA384.Create, contents)
    End Function

    Public Shared Function GetHash(hashAlgorithm As HashAlgorithm, input As String) As String
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
    Public Shared Function VerifyHash(hashAlgorithm As HashAlgorithm, input As String, hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetHash(hashAlgorithm, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        Return comparer.Compare(hashOfInput, hash) = 0
    End Function

    ' Verify a hash against a string.
    Public Shared Function CompareHash(filename As String, input As String) As Boolean
        Dim fileHash = GetHash(filename)
        Dim inputHash = GetHash(SHA384.Create, input)

        ' Create a StringComparer and compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        Return comparer.Compare(fileHash, inputHash) = 0
    End Function
End Class