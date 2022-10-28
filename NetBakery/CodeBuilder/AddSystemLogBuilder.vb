Namespace My.Templates.CodeBuilders
    Partial Public Class AddSystemLog
        Implements iCBTemplate

        Public Property Name As String Implements iCBTemplate.Name


        Public Property CBParameters As List(Of CBParameter) Implements iCBTemplate.CBParameters

        Sub New()
            CBParameters = New List(Of CBParameter)({
                                                New CBParameter With {.Name = "EmaillistID", .Value = "1"},
                                                New CBParameter With {.Name = "Condition", .Value = "SEND"},
                                                New CBParameter With {.Name = "LinkFile", .Value = "True", .IsBoolean = True}
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
