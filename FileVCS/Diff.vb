Public Class Diff
    Private Sub Diff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.git_diff_icon_175166

        DiffViewer1.OldTextHeader = "Old file on disk"
        DiffViewer1.NewTextHeader = "New file in memory"
    End Sub

    Public Property originalFileContents As String
    Public Property newFileContents As String

    Public Sub showDiff()

        DiffViewer1.OldText = originalFileContents
        DiffViewer1.NewText = newFileContents

        DiffViewer1.RefreshCore()
    End Sub
End Class