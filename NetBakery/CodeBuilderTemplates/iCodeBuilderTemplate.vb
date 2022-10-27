Public Interface iCodeBuilderTemplate
    Property Name As String
    Property InputParams As List(Of InputParam)
    Function BuildText() As String
    Sub ResetText()
End Interface

Public Class InputParam
    Property Name As String
    Property Value As String
End Class