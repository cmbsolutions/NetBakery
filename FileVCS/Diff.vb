Imports System.ComponentModel
Imports DiffPlex.WindowsForms.Controls

Public Class Diff
    Private diffView As DiffViewer = Nothing
    Public Property originalFileContents As String
    Public Property newFileContents As String


    Private Sub Diff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.git_diff_icon_175166

        diffView = New DiffViewer With {
            .Margin = New Padding(0),
            .Dock = DockStyle.Fill,
            .ForeColor = ForeColor,
            .OldTextHeader = "File on disk",
            .OldText = originalFileContents,
            .NewTextHeader = "File in memory",
            .NewText = newFileContents
        }

        MainPanel.Controls.Add(diffView)
    End Sub

    Private Sub bSwitchMode_Click(sender As Object, e As EventArgs) Handles bSwitchMode.Click
        If diffView.IsInlineViewMode Then
            diffView.ShowSideBySide()
            Exit Sub
        End If

        diffView.ShowInline()
    End Sub

    Private Sub bOtherActions_Click(sender As Object, e As EventArgs) Handles bOtherActions.Click
        diffView.OpenViewModeContextMenu()
    End Sub

    Private Sub Diff_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If diffView IsNot Nothing Then diffView.Dispose()
    End Sub
End Class