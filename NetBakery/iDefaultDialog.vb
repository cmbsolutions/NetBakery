Public Class iDefaultDialog
    Public Overridable Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class