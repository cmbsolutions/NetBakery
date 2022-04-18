Public Class DbObject


    Private IsMoving As Boolean
    Private IsResizing As Boolean
    Property IsSelected As Boolean
    Private x, y As Integer

    Public Sub AddField(name As String, [type] As String, isKey As Boolean)
        Dim f = DirectCast(ItemTemplate.Clone, DevComponents.DotNetBar.ListBoxItem)


        f.Text = $"<font color=""WhiteSmoke""><b>{name}</b></font> <font color=""DarkGray"">: {[type]}</font>"

        If isKey Then
            f.Image = ImageList1.Images.Item(0)
        Else
            f.Text = "<span width=""20""> </span>" & f.Text
        End If

        f.Visible = True
        f.SetIsSelected(False, DevComponents.DotNetBar.eEventSource.Code)
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

            Parent.Refresh()
        End If
    End Sub

    Private Sub p_MouseDown(sender As Object, e As MouseEventArgs) Handles pCenter.MouseDown, pRight.MouseDown, pLeft.MouseDown
        If Not IsMoving And Not IsResizing And e.Button = MouseButtons.Left Then
            IsResizing = True
            x = e.X
            y = e.Y
        End If
    End Sub

    Private Sub p_MouseUp(sender As Object, e As MouseEventArgs) Handles pCenter.MouseUp, pRight.MouseUp, pLeft.MouseUp
        If IsResizing And e.Button = MouseButtons.Left Then IsResizing = False
    End Sub

    Private Sub pCenter_MouseMove(sender As Object, e As MouseEventArgs) Handles pCenter.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Height += e.Y - y
            Parent.Refresh()
        End If
    End Sub

    Private Sub pRight_MouseMove(sender As Object, e As MouseEventArgs) Handles pRight.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Height += e.Y - y
            Width += e.X - x
            Parent.Refresh()
        End If
    End Sub

    Private Sub pLeft_MouseMove(sender As Object, e As MouseEventArgs) Handles pLeft.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Width += e.X - x
            Parent.Refresh()
        End If
    End Sub
End Class

