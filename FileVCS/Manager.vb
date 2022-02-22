Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Globalization

Public Class Manager
    Property PhysicalFiles As List(Of Models.vcsObject)
    Property ChangedFiles As List(Of Models.vcsObject)

    Private ScanPath As String

    Public Sub ScanForFiles(location As String)
        If Not IO.Directory.Exists(location) Then Exit Sub

        ScanPath = location
        PhysicalFiles = New List(Of Models.vcsObject)

        For Each f In IO.Directory.EnumerateFiles(location, "*.*", IO.SearchOption.AllDirectories)
            PhysicalFiles.Add(New Models.vcsObject With {
                        .filename = IO.Path.GetFileName(f),
                        .location = IO.Path.GetDirectoryName(f).Replace(location, ""),
                        .hash = Utils.GetFileHash(f)
                        })
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
                           Select New Models.GroupedFiles With {.Parent = fileLocation, .Files = Group.ToList}


        For Each p In groupedFiles
            If lastDir <> p.Parent Then
                cNode = New Models.AdvTreeNode With {
                    .Expanded = True,
                    .Text = p.Parent
                }

                If lastDir = "" Then
                    pNode = cNode
                    at.Node = pNode
                    lastDir = p.Parent
                ElseIf p.Parent.StartsWith(lastDir) Then
                    cNode.Text = p.Parent.Replace(lastDir, "")
                    cNode.ParentNode = pNode
                    pNode.Node.Add(cNode)
                    pNode = cNode
                    lastDir = p.Parent
                Else
                    pNode = pNode.ParentNode
                    cNode.ParentNode = pNode
                    cNode.Text = p.Parent.Replace(pNode.Text, "")
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
                   .Text = child.filename,
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
End Class