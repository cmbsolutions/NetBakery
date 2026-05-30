Imports System.Text.RegularExpressions

Public Class navicatConnectionHelper
    Private Const registryRoot As String = "Software\PremiumSoft\Navicat\Servers"

    Private accounts As New List(Of navicatAccount)

    Public Sub refreshAccounts()
        Try
            accounts.Clear()

            Using mainReg = My.Computer.Registry.CurrentUser.OpenSubKey(registryRoot, False)
                Dim RegexObj As New Regex("^AWS - (DEV|TST|APP|PRD) - (\w+)$", RegexOptions.IgnoreCase)

                For Each entry In mainReg.GetSubKeyNames
                    If RegexObj.IsMatch(entry) Then
                        Using subKey = mainReg.OpenSubKey(entry)
                            accounts.Add(New navicatAccount With {
                                         .host = subKey.GetValue("Host").ToString,
                                         .username = subKey.GetValue("UserName").ToString,
                                         .password = subKey.GetValue("Pwd").ToString,
                                         .displayName = entry.Replace("AWS - ", "")
                                         })
                        End Using
                    End If
                Next

            End Using
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Public Function getAccounts() As List(Of String)
        Return (From a In accounts Order By a.displayName Select a.displayName).ToList
    End Function

    Public Function getAccount(_name As String) As navicatAccount
        Try
            Dim acc = accounts.FirstOrDefault(Function(c) c.displayName = _name)
            Dim retAcc As navicatAccount = Nothing

            If acc IsNot Nothing Then
                Using navi As New CMBSolutions.NavicatEncrypt
                    retAcc = New navicatAccount With {
                        .host = acc.host,
                        .username = acc.username,
                        .password = navi.Decrypt(acc.password),
                        .displayName = acc.displayName
                    }
                End Using
            End If

            Return retAcc
        Catch ex As Exception
            FormHelpers.dumpException(ex)
            Return Nothing
        End Try
    End Function
End Class

Public Class navicatAccount
    Property username As String
    Property password As String
    Property host As String
    Property displayName As String
End Class