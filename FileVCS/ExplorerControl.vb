Public Class ExplorerControl
    Property ExplorerManager As Manager

    Public Sub RefreshExplorer()
        If ExplorerManager Is Nothing Then Exit Sub

        atExplorer.Nodes.Clear()
        atExplorer.Load(ExplorerManager.GetCurrentFilesTree)
        atExplorer.DeepSort = True
        atExplorer.Nodes.Sort()
        atExplorer.Refresh()
    End Sub
End Class
