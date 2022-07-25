Public Class ExplorerControl
    Property ExplorerManager As Manager
    Public Event ShowFileContentsEvent(fileName As String)

    Public Sub RefreshExplorer()
        If ExplorerManager Is Nothing Then Exit Sub

        atExplorer.Nodes.Clear()
        atExplorer.Load(ExplorerManager.GetCurrentFilesTree)
        atExplorer.DeepSort = True
        atExplorer.Nodes.Sort()
        atExplorer.Refresh()
    End Sub

    Public Sub ClearExplorer()
        atExplorer.Nodes.Clear()
    End Sub

    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click
        ExplorerManager.ScanAgain()
        RefreshExplorer()
    End Sub

    Private Sub atExplorer_NodeDoubleClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles atExplorer.NodeDoubleClick
        Try
            If Not e.Node.HasChildNodes Then
                RaiseEvent ShowFileContentsEvent(e.Node.Name)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
