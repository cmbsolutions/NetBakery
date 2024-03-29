Imports System.Net
Imports AutoUpdaterDotNET

Public Class splash
    Private _t As Integer = 0
    Private Delegate Sub AutoUpdaterCheckUpdateHandlerDelegate(args As AutoUpdaterDotNET.UpdateInfoEventArgs)

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
            AddHandler AutoUpdater.CheckForUpdateEvent, AddressOf AutoUpdaterCheckUpdateHandler
            ProgressBarX1.Text = "Checking for updates..."

            If My.Settings.checkUpdates Then
                AutoUpdater.Synchronous = True
                AutoUpdater.Start("https://netbakery.cmbsolutions.nl/v2/netbakery_update.php")
            Else
                ProgressBarX1.Text = "No updates. Loading program..."
                Timer1.Enabled = True
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub AutoUpdaterCheckUpdateHandler(args As AutoUpdaterDotNET.UpdateInfoEventArgs)
        Try
            If InvokeRequired Then
                Dim d As New AutoUpdaterCheckUpdateHandlerDelegate(AddressOf AutoUpdaterCheckUpdateHandler)

                Invoke(d)
            End If

            If args.Error Is Nothing Then
                If args.IsUpdateAvailable Then
                    Timer1.Enabled = False
                    ProgressBarX1.Text = "Found new update!"

                    args.InstallerArgs = "/VERYSILENT /SUPPRESSMSGBOXES /NOCANCEL /NORESTART /CLOSEAPPLICATIONS /FORCECLOSEAPPLICATIONS /RESTARTAPPLICATIONS"

                    AutoUpdater.ShowUpdateForm(args)

                    Try
                        ProgressBarX1.Text = "Downloading new version..."
                        If AutoUpdater.DownloadUpdate(args) Then
                            ProgressBarX1.Text = "Installing new version..."
                        End If
                    Catch exception As Exception
                        FormHelpers.dumpException(exception)
                    End Try
                Else
                    ProgressBarX1.Text = "No updates found!"
                End If
            Else
                If TypeOf args.Error Is WebException Then
                    ProgressBarX1.Text = "Error reaching updateserver!"
                Else
                    FormHelpers.dumpException(args.Error)
                End If
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
End Class