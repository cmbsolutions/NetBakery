Public Class preferences
    Public Overrides Sub btnOk_Click(sender As Object, e As EventArgs)
        My.Settings.Save()

        MyBase.btnOk_Click(sender, e)
    End Sub

    Public Overrides Sub btnCancel_Click(sender As Object, e As EventArgs)
        My.Settings.Reload()

        MyBase.btnCancel_Click(sender, e)
    End Sub
End Class
