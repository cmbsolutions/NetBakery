Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network Connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Try
                FormHelpers.upgradeMySettings()

                'If My.Settings.checkUpdates Then
                '    Dim uh As New updateHelper
                '    If uh.needsUpdate Then
                '        Debug.WriteLine($"New version {uh.updateVersion} detected. Please update current {uh.currentVersion} version.")
                '    Else
                '        Debug.WriteLine($"No updates detected. Current version {uh.currentVersion} is latest.")
                '    End If
                'End If
            Catch ex As Exception
                FormHelpers.dumpException(ex)
            End Try
        End Sub
    End Class
End Namespace
