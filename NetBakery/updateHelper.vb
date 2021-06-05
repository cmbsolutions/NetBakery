Imports System.Net

Public Class updateHelper
    Property currentVersion As String = $"{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}"
    Property updateVersion As String = ""

    Public Function needsUpdate() As updateFile
        Try
            Dim client As New RestSharp.RestClient(My.Resources.updateLocation) With {
                .Timeout = -1
            }
            Dim request As New RestSharp.RestRequest(RestSharp.Method.GET)
            Dim response = client.Execute(request)

            If response.IsSuccessful Then
                Dim uf As updateFile = Newtonsoft.Json.JsonConvert.DeserializeObject(Of updateFile)(response.Content)

                If uf.major > My.Application.Info.Version.Major Then uf.doUpdate = True
                If uf.major >= My.Application.Info.Version.Major And uf.minor > My.Application.Info.Version.Minor Then uf.doUpdate = True
                If uf.major >= My.Application.Info.Version.Major And uf.minor >= My.Application.Info.Version.Minor And uf.revision > My.Application.Info.Version.Build Then uf.doUpdate = True
                uf.doUpdate = True
                Return uf
            End If

            Return New updateFile With {.doUpdate = False}

        Catch ex As Exception
            FormHelpers.dumpException(ex)
            Return Nothing
        End Try
    End Function

    Public Async Function downloadUpdate(setupfile As String, saveto As String) As Task(Of Boolean)
        Try
            Using client As New WebClient()
                If IO.File.Exists(saveto) Then IO.File.Delete(saveto)
                If Not IO.Directory.Exists(IO.Path.GetDirectoryName(saveto)) Then IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(saveto))

                Dim dl As Task = client.DownloadFileTaskAsync(New Uri($"https://cmbsolutions.nl/netbakery/v2/{setupfile}"), saveto)

                Await dl

                If IO.File.Exists(saveto) Then
                    Return True
                Else
                    Return False
                End If

            End Using
        Catch ex As Exception
            FormHelpers.dumpException(ex)

            Return False
        End Try
    End Function
End Class

Public Class updateFile
    Property doUpdate As Boolean
    Property version As String
    Property major As Integer
    Property minor As Integer
    Property revision As Integer
    Property setupfile As String
End Class
