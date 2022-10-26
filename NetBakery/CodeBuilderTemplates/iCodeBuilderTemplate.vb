Public Interface iCodeBuilderTemplate
    Property Name As String
    Property InputParams As List(Of InputParam)
End Interface

Public Class InputParam
    Property Name As String
    Property Value As String
End Class