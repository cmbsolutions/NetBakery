Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Xml.Serialization

Public Class FileManager
    Property PhysicalFiles As List(Of outputItem)
    Property ChangedFiles As New List(Of outputItem)

    Private ScanPath As String

    Public Sub ScanForFiles(location As String)
        If Not IO.Directory.Exists(location) Then Exit Sub

        ScanPath = location
        PhysicalFiles = New List(Of outputItem)

        For Each f In IO.Directory.EnumerateFiles(location, "*.*", IO.SearchOption.AllDirectories)
            If IO.Path.GetDirectoryName(f).Replace(location, "") <> "" Then
                PhysicalFiles.Add(New outputItem With {
                        .filename = IO.Path.GetFileName(f),
                        .location = IO.Path.GetDirectoryName(f).Replace(location, ""),
                        .hash = GetFileHash(f)
                        })
            End If
        Next
    End Sub

    Public Function GetPhysicalFilesTree() As XmlDocument
        If PhysicalFiles Is Nothing Then Return New XmlDocument

        Dim tInfo As TextInfo = New CultureInfo("nl-NL", False).TextInfo

        Dim at As New Models.AdvTree
        Dim lastDir As String = ""
        Dim pNode As Models.AdvTreeNode = Nothing
        Dim cNode As Models.AdvTreeNode = Nothing


        Dim groupedFiles = From file In PhysicalFiles
                           Group By fileLocation = file.location Into Group = Group
                           Select New GroupedFiles With {.Parent = fileLocation, .Files = Group.ToList}


        For Each p In groupedFiles
            If lastDir <> p.Parent Then
                cNode = New Models.AdvTreeNode With {
                    .Expanded = True,
                    .TextField = p.Parent
                }

                If lastDir = "" Then
                    pNode = cNode
                    at.Node = pNode
                    lastDir = p.Parent
                ElseIf p.Parent.StartsWith(lastDir) Then
                    cNode.TextField = p.Parent.Replace(lastDir, "")
                    cNode.ParentNode = pNode
                    pNode.Node.Add(cNode)
                    pNode = cNode
                    lastDir = p.Parent
                Else
                    pNode = pNode.ParentNode
                    cNode.ParentNode = pNode
                    cNode.TextField = p.Parent.Replace(pNode.TextField, "")
                    pNode.Node.Add(cNode)
                    pNode = cNode
                    lastDir = p.Parent
                End If
            End If

            For Each child In p.Files
                pNode.Node.Add(New Models.AdvTreeNode With {
                   .ParentNode = pNode,
                   .Expanded = False,
                   .Name = child.filename,
                   .TextField = child.filename,
                   .ImageIndex = GetFileType($"{ScanPath}{child.location}\{child.filename}")
               })
            Next
        Next

        Dim seri As New XmlSerializer(GetType(Models.AdvTree), "")
        Dim buffer() As Byte
        Using ms As New IO.MemoryStream
            Using sw As New IO.StreamWriter(ms)
                seri.Serialize(sw, at)
            End Using

            buffer = ms.GetBuffer
        End Using

        Dim doc As New XmlDocument
        doc.LoadXml(Text.Encoding.UTF8.GetString(buffer))
        Return doc
    End Function


    Private Function GetFileType(filename As String) As Integer
        If Not IO.File.Exists(filename) Then Return 42

        Dim contents As String = IO.File.ReadAllText(filename)

        If Regex.IsMatch(contents, "Models.{1,30}StoreCommands", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return 39
        If Regex.IsMatch(contents, "Inherits Models.*?Context", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return 38
        If Regex.IsMatch(contents, "Models.*?qprod", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return 41
        If Regex.IsMatch(contents, "Models.*?qfunc", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return 41
        If Regex.IsMatch(contents, "Models.*?Map", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return 43
        If Regex.IsMatch(contents, "Models.*?qsel", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return 40


        Return 42
    End Function

    Public Function GetFileHash(filename As String) As String
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

    Public Function GetHash(ByVal hashAlgorithm As HashAlgorithm, ByVal input As String) As String

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

Public Class GroupedFiles
    Property Parent As String
    Property Files As List(Of outputItem)
End Class