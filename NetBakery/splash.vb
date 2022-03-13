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
                AutoUpdater.Start("https://netbakery.cmbsolutions.nl/v2/netbakery_v2_update.xml")



                'Dim uh As New updateHelper
                'Dim uf As updateFile = uh.needsUpdate
                'If uf IsNot Nothing AndAlso uf.doUpdate Then
                '    ProgressBarX1.Text = "Downloading update..."
                '    Dim _setupFile = New IO.FileInfo($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\CMBSolutions\NetBakery\tempsetup\{uf.setupfile}")
                '    If Task.Run(Function() uh.downloadUpdate(uf.setupfile, _setupFile.FullName)).Result Then
                '        ProgressBarX1.Text = "Running update..."
                '        Dim p As New Process
                '        p.StartInfo.FileName = _setupFile.FullName
                '        p.StartInfo.UseShellExecute = True
                '        p.EnableRaisingEvents = False

                '        p.Start()

                '        Close()
                '    End If

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
            If ProgressBarX1.InvokeRequired Then
                Dim d As New AutoUpdaterCheckUpdateHandlerDelegate(AddressOf AutoUpdaterCheckUpdateHandler)

                ProgressBarX1.Invoke(d)
            End If

            If args.Error Is Nothing Then
                If args.IsUpdateAvailable Then
                    Timer1.Enabled = False
                    ProgressBarX1.Text = "Found new update"
                    'Dim dialogResult As DialogResult
                    'If args.Mandatory.Value Then
                    ' dialogResult = MessageBox.Show($"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}. This is required update. Press Ok to begin updating the application.", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Else
                    '             dialogResult = MessageBox.Show($"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}. Do you want to update the application now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    '         End If

                    ' Uncomment the following line if you want to show standard update dialog instead.
                    AutoUpdater.ShowUpdateForm(args)
                    'If dialogResult.Equals(DialogResult.Yes) OrElse dialogResult.Equals(DialogResult.OK) Then
                    Try
                        If AutoUpdater.DownloadUpdate(args) Then
                            Application.Exit()
                        End If
                    Catch exception As Exception
                        FormHelpers.dumpException(exception)
                    End Try
                Else
                    ProgressBarX1.Text = "No updates found"
                End If
            Else
                If TypeOf args.Error Is WebException Then
                    ProgressBarX1.Text = "Error reaching server"
                Else
                    FormHelpers.dumpException(args.Error)
                End If
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
End Class