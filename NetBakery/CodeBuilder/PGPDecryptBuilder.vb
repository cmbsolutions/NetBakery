Namespace My.Templates.CodeBuilders
    Partial Public Class PGPDecrypt
        Implements iCBTemplate

        Public Property Name As String Implements iCBTemplate.Name

        Public Property CBParameters As List(Of CBParameter) Implements iCBTemplate.CBParameters

        Sub New()
            CBParameters = New List(Of CBParameter)({
                                                    New CBParameter With {.Name = "PGPClientKey", .Value = "pgp_public_client_keyfile"},
                                                    New CBParameter With {.Name = "PGPPrivateKey", .Value = "pgp_private_local_key"},
                                                    New CBParameter With {.Name = "PGPPassphrase", .Value = "pgp_private_key_passphrase"},
                                                    New CBParameter With {.Name = "PGPEnabled", .Value = "pgp_enabled"}
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
