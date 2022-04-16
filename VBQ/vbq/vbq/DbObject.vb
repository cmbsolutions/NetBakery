Public Class DbObject
    Private DbLinkPairs As List(Of DbLinkPair)

    Private IsMoving As Boolean
    Private IsResizing As Boolean
    Private x, y As Integer

    Public Sub AddLink(ByVal prm_LeadingLink As Char, ByVal prm_fLink As DbLink, ByVal prm_tLink As DbLink)
        If DbLinkPairs Is Nothing Then DbLinkPairs = New List(Of DbLinkPair)

        DbLinkPairs.Add(New DbLinkPair With {
                        .StartFromLink = prm_fLink,
                        .EndAtLink = prm_tLink
                        })

    End Sub

    Public Sub AddField(name As String, [type] As String, isKey As Boolean)
        Dim f As New DevComponents.DotNetBar.LabelItem(name)

        f.Text = $"<font color=""WhiteSmoke""><b>{name}</b></font> <font color=""DarkGray"">: {[type]}</font>"
        If isKey Then
            f.Image = My.Resources.key
        Else
            f.PaddingLeft = 20
        End If

        lFields.Items.Add(f)
    End Sub

    Public Sub ClearFields()
        lFields.Items.Clear()
    End Sub
    Private Sub lTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles lTitle.MouseDown
        If Not IsMoving And Not IsResizing And e.Button = MouseButtons.Left Then
            IsMoving = True
            x = e.X
            y = e.Y
        End If
    End Sub

    Private Sub lTitle_MouseUp(sender As Object, e As MouseEventArgs) Handles lTitle.MouseUp
        If IsMoving And e.Button = MouseButtons.Left Then IsMoving = False
    End Sub

    Private Sub lTitle_MouseMove(sender As Object, e As MouseEventArgs) Handles lTitle.MouseMove
        If IsMoving And e.Button = MouseButtons.Left Then
            Left += e.X - x
            Top += e.Y - y
            'If (Not Me.uLink Is Nothing) Then
            '    Dim num2 As Integer = Information.UBound(Me.uLink, 1)
            '    Dim i As Integer = 0
            '    Do While (i <= num2)
            '        If (Conversions.ToString(Me.sLeading(i)) = "F") Then
            '            Me.uLink(i, 0).Left = (Me.uLink(i, 0).Left + (e.X - Me.iDiffX))
            '            Me.uLink(i, 0).Top = (Me.uLink(i, 0).Top + (e.Y - Me.iDiffY))
            '        ElseIf (Conversions.ToString(Me.sLeading(i)) = "T") Then
            '            Me.uLink(i, 1).Left = (Me.uLink(i, 1).Left + (e.X - Me.iDiffX))
            '            Me.uLink(i, 1).Top = (Me.uLink(i, 1).Top + (e.Y - Me.iDiffY))
            '        End If
            '        i += 1
            '    Loop
            'End If
            Parent.Refresh()
        End If
    End Sub

    Private Sub p_MouseDown(sender As Object, e As MouseEventArgs) Handles pCenter.MouseDown, pLeft.MouseDown, pRight.MouseDown
        If Not IsMoving And Not IsResizing And e.Button = MouseButtons.Left Then
            IsResizing = True
            x = e.X
            y = e.Y
        End If
    End Sub

    Private Sub p_MouseUp(sender As Object, e As MouseEventArgs) Handles pCenter.MouseUp, pLeft.MouseUp, pRight.MouseUp
        If IsResizing And e.Button = MouseButtons.Left Then IsResizing = False
    End Sub

    Private Sub pCenter_MouseMove(sender As Object, e As MouseEventArgs) Handles pCenter.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Height += e.Y - y
            Parent.Refresh()
        End If
    End Sub

    Private Sub pLeft_MouseMove(sender As Object, e As MouseEventArgs) Handles pLeft.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Height += e.Y - y
            Width += e.X - x
            Left += e.X - x
        End If
    End Sub

    Private Sub pRight_MouseMove(sender As Object, e As MouseEventArgs) Handles pRight.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Height += e.Y - y
            Width += e.X - x
        End If
    End Sub
End Class

Public Class DbLinkPair
    Property StartFromLink As DbLink
    Property EndAtLink As DbLink
End Class