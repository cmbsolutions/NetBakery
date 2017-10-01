Public Class splash
    Private _t As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Enabled = False
            _t += 1

            If _t * 10 > ProgressBarX1.Maximum Then
                ProgressBarX1.Value = ProgressBarX1.Maximum
            Else
                ProgressBarX1.Value = _t * 10
            End If

            If _t >= 10 Then

                Dim frx As New main

                frx.Show()

                Close()
            Else
                Timer1.Enabled = True
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        Try
            Timer1.Enabled = False

            Dim frx As New main

            frx.Show()

            Close()

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnNewForm_Click(sender As Object, e As EventArgs) Handles btnNewForm.Click
        Try
            Timer1.Enabled = False

            Dim frx As New mainGUI2

            frx.Show()

            Close()

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
End Class