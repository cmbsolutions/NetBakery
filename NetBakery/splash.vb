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

                Dim frx As New mainGUI2

                frx.Show()

                Close()
            Else
                Timer1.Enabled = True
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub splash_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Try
            Timer1.Enabled = False

            Dim frx As New mainGUI2

            frx.Show()

            Close()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub splash_Shown(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            ProgressBarX1.Text = "Checking for updates..."

            If My.Settings.checkUpdates Then
                Dim uh As New updateHelper
                Dim uf As updateFile = uh.needsUpdate
                If uf IsNot Nothing AndAlso uf.doUpdate Then
                    ProgressBarX1.Text = "Downloading update..."
                    Dim _setupFile = New IO.FileInfo($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\CMBSolutions\NetBakery\tempsetup\{uf.setupfile}")
                    If Task.Run(Function() uh.downloadUpdate(uf.setupfile, _setupFile.FullName)).Result Then
                        ProgressBarX1.Text = "Running update..."
                        Dim p As New Process
                        p.StartInfo.FileName = _setupFile.FullName
                        p.StartInfo.UseShellExecute = True
                        p.EnableRaisingEvents = False

                        p.Start()

                        Close()
                    End If

                Else
                    ProgressBarX1.Text = "No updates. Loading program..."
                    Timer1.Enabled = True
                End If
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
End Class