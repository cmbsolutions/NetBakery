Public Class updateHelper
    Property currentVersion As String = $"{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}"
    Property updateVersion As String = ""

    Public Function needsUpdate() As Boolean
        Try
            Dim doUpdate As Boolean = False

            Dim client As New RestSharp.RestClient(My.Resources.updateLocation) With {
                .Timeout = -1
            }
            Dim request As New RestSharp.RestRequest(RestSharp.Method.GET)
            Dim response = client.Execute(request)

            If response.IsSuccessful Then
                Dim uf As updateFile = Newtonsoft.Json.JsonConvert.DeserializeObject(Of updateFile)(response.Content)

                If uf.major > My.Application.Info.Version.Major Then doUpdate = True
                If uf.major >= My.Application.Info.Version.Major And uf.minor > My.Application.Info.Version.Minor Then doUpdate = True
                If uf.major >= My.Application.Info.Version.Major And uf.minor >= My.Application.Info.Version.Minor And uf.revision > My.Application.Info.Version.Build Then doUpdate = True

                If doUpdate Then
                    updateVersion = $"{uf.major}.{uf.minor}.{uf.revision}"
                Else
                    updateVersion = currentVersion
                End If
            End If

            Return doUpdate
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try

        Return False
    End Function
End Class

Public Class updateFile
    Property version As String
    Property major As Integer
    Property minor As Integer
    Property revision As Integer
    Property setupfile As String
End Class
