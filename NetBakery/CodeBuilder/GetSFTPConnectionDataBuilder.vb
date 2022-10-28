Namespace My.Templates.CodeBuilders
    Partial Public Class GetSFTPConnectionData
        Implements iCBTemplate

        Public Property Name As String Implements iCBTemplate.Name

        Public Property CBParameters As List(Of CBParameter) Implements iCBTemplate.CBParameters

        Sub New()
            CBParameters = New List(Of CBParameter)({
                                                    New CBParameter With {.Name = "SettingDefaultName", .Value = "sftp_id"},
                                                    New CBParameter With {.Name = "AccountName", .Value = "4dms"},
                                                    New CBParameter With {.Name = "DatabaseName", .Value = "4dms_cde"}
                                                    })
        End Sub
        Public Sub ResetText() Implements iCBTemplate.ResetText
            MyClass.GenerationEnvironment.Clear()
        End Sub

        Public Function BuildText() As String Implements iCBTemplate.BuildText
            Return MyClass.TransformText()
        End Function
    End Class
End Namespace