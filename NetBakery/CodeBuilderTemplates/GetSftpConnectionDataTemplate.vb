﻿Namespace My.Templates.CodeBuilder
    Partial Public Class GetSftpConnectionData
        Implements iCodeBuilderTemplate

        Public Property InputParams As List(Of InputParam) Implements iCodeBuilderTemplate.InputParams

        Public Property Name As String Implements iCodeBuilderTemplate.Name

        Sub New()
            InputParams = New List(Of InputParam)({
                                                  New InputParam With {.Name = "SettingDefaultName", .Value = "sftp_id"}
                                                  })
        End Sub
    End Class
End Namespace