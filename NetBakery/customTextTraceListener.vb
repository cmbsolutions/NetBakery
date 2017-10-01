Public Class customTextTraceListener
    Inherits TraceListener

    Private _target As TextBox
    Private _invokeWrite As StringSendDelegate

    Public Sub New(target As TextBox)
        _target = target
        _invokeWrite = New StringSendDelegate(AddressOf SendString)
    End Sub

    Public Overrides Sub Write(message As String)
        _target.Invoke(_invokeWrite, New Object() {message})
    End Sub

    Public Overrides Sub WriteLine(message As String)
        _target.Invoke(_invokeWrite, New Object() {message + Environment.NewLine})
    End Sub

    Private Delegate Sub StringSendDelegate(message As String)
    Private Sub SendString(message As String)
        ' No need to lock text box as this function will only 
        ' ever be executed from the UI thread
        If _target.TextLength + message.Length > _target.MaxLength Then
            _target.Clear()
        End If
        _target.AppendText(message)
    End Sub
End Class


