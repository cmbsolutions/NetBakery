Public Interface iCBTemplate
    Property Name As String
    Property CBParameters As List(Of CBParameter)
    Function BuildText() As String
    Sub ResetText()
End Interface
