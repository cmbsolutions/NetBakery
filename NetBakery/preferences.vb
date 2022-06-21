Public Class preferences
    Public Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        My.Settings.Save()
    End Sub

    Public Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        My.Settings.Reload()
    End Sub
End Class
