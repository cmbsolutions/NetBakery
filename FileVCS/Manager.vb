Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Globalization

Public Class Manager
    Property CurrentFiles As New List(Of Models.vcsObject)
    Property OriginalFiles As New List(Of Models.vcsObject)
    Property ChangedFiles As New List(Of Models.vcsObject)
    Property NewFiles As New List(Of Models.vcsObject)
    Property DeletedFiles As New List(Of Models.vcsObject)
    Property MissingFiles As New List(Of Models.vcsObject)

    Private ScanPath As String

    Public Sub ScanForFiles(location As String)
        If Not IO.Directory.Exists(location) Then Exit Sub

        ScanPath = location

        CurrentFiles = New List(Of Models.vcsObject)

        For Each f In IO.Directory.EnumerateFiles(location, "*.*", IO.SearchOption.AllDirectories)
            Dim filePath = IO.Path.GetDirectoryName(f).Replace(location, "")

            If filePath.ToLower.in({"models", "storecommands", "model", "table"}) Then
                CurrentFiles.Add(New Models.vcsObject With {
                                            .filename = IO.Path.GetFileName(f),
                                            .location = IO.Path.GetDirectoryName(f).Replace(location, ""),
                                            .hash = Utils.GetFileHash(f)
                                            })
            End If
        Next

        CheckForChanged()
    End Sub

    Private Sub CheckForChanged()
        If CurrentFiles Is Nothing Or OriginalFiles Is Nothing Then Exit Sub

        Dim MatchedPs = (From v In OriginalFiles
                         Join p In CurrentFiles On p.filename Equals v.filename
                         Select p).ToList

        Dim MatchedVs = (From v In OriginalFiles
                         Join p In CurrentFiles On p.filename Equals v.filename
                         Select v).ToList

        'Dim newPs = CurrentFiles.Except(MatchedPs).ToList
        'Dim missingVs = OriginalFiles.Except(MatchedVs).ToList

        NewFiles = OriginalFiles.Except(MatchedVs).ToList

        ChangedFiles = MatchedPs.Except(From mp In MatchedPs
                                        Join mv In MatchedVs On mp.filename Equals mv.filename And mp.hash Equals mv.hash
                                        Select mp).ToList
    End Sub

    Public Function GetCurrentFilesTree() As XmlDocument
        If CurrentFiles Is Nothing Then Return New XmlDocument

        Dim at As New Models.AdvTree
        Dim lastDir As String = ""
        Dim pNode As Models.AdvTreeNode = Nothing
        Dim cNode As Models.AdvTreeNode = Nothing

        CheckForChanged()

        Dim groupedFiles = From file In CurrentFiles
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

        If Regex.IsMatch(contents, "Models.{1,30}StoreCommands", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return Models.ExplorerImage.DOCUMENTSCRIPT
        If Regex.IsMatch(contents, "Inherits Models.*?Context", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return Models.ExplorerImage.DATABASE
        If Regex.IsMatch(contents, "Models.*?qprod", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return Models.ExplorerImage.SCRIPT
        If Regex.IsMatch(contents, "Models.*?qfunc", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return Models.ExplorerImage.SCRIPT
        If Regex.IsMatch(contents, "Models.*?Map", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return Models.ExplorerImage.DATASHEET
        If Regex.IsMatch(contents, "Models.*?qsel", RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then Return Models.ExplorerImage.QUERY

        Return Models.ExplorerImage.TABLE
    End Function
End Class