Imports DevComponents.DotNetBar

Public Class cTable
    Private IsMoving As Boolean
    Private IsResizing As Boolean

    Private InitialX, InitialY, ih As Integer

    Public Event Close(name As String)

    Public Property Title() As String
        Get
            Return panel1.TitleText
        End Get
        Set(ByVal value As String)
            panel1.TitleText = value
        End Set
    End Property

    Public Sub SetFields(f As Array)
        fields.DataSource = f
        fields.DisplayMember = "name"
    End Sub

    Public Sub SetFields(f As Array, displayMember As String)
        fields.DataSource = f
        fields.DisplayMember = displayMember
    End Sub

    Public Sub ClearFields()
        fields.DataSource = Nothing
        fields.Refresh()
    End Sub

    Private Sub panel1_ExpandedChanged(sender As Object, e As ExpandedChangeEventArgs) Handles panel1.ExpandedChanged
        If Not panel1.Expanded Then
            ih = Height
            Height = 26
        Else
            Height = ih
        End If

    End Sub

    'Private Sub panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles panel1.MouseDown
    '    If e.Button = MouseButtons.Left Then
    '        IsMoving = True
    '        InitialX = e.X
    '        InitialY = e.Y
    '    End If
    'End Sub

    'Private Sub panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles panel1.MouseMove
    '    If IsMoving AndAlso e.Button = MouseButtons.Left Then
    '        Left = e.X - InitialX
    '        Top = e.Y - InitialY
    '    End If
    'End Sub

    'Private Sub panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles panel1.MouseUp
    '    If e.Button = MouseButtons.Left Then
    '        IsMoving = False
    '    End If
    'End Sub

    'Private Sub bGripper_MouseDown(sender As Object, e As MouseEventArgs)
    '    If e.Button = MouseButtons.Left Then
    '        IsResizing = True
    '        InitialX = e.X
    '        InitialY = e.Y
    '    End If
    'End Sub

    'Private Sub bGripper_MouseMove(sender As Object, e As MouseEventArgs)
    '    If IsResizing AndAlso e.Button = MouseButtons.Left Then
    '        Width = e.X - InitialX
    '        Height = e.Y - InitialY
    '    End If
    'End Sub

    'Private Sub bGripper_MouseUp(sender As Object, e As MouseEventArgs)
    '    If e.Button = MouseButtons.Left Then
    '        IsResizing = False
    '    End If
    'End Sub
End Class
