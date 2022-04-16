Imports System.Runtime.CompilerServices

Public Class Viewer
    Public Sub AddTable(name As String, fields As List(Of DbFieldInfo))
        Dim t As New DbObject
        t.lTitle.Text = name

        For Each f In fields
            t.AddField(f.name, f.type, f.isKey)
        Next

        playpen.Controls.Add(t)
    End Sub

    Private Sub ViewerContainerItem_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
        'e.Effect = DragDropEffects.Move
    End Sub
    Private Sub ViewerContainerItem_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs)
        'DoDragDrop(RuntimeHelpers.GetObjectValue(e.Item), DragDropEffects.Move)
    End Sub
    Private Sub ViewerContainerItem_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
        '    Dim view As ListView = DirectCast(sender, ListView)
        '    Dim p As New Point(e.X, e.Y)
        '    Dim point2 As Point = view.PointToClient(p)
        '    Dim x As Integer = point2.X
        '    point2 = New Point(e.X, e.Y)
        '    Dim y As Integer = view.PointToClient(point2).Y
        '    Dim data As ListViewItem = DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem"), ListViewItem)
        '    Dim itemAt As ListViewItem = DirectCast(sender, ListView).GetItemAt(x, y)
        '    Dim listView As ListView = data.ListView
        '    Dim view5 As ListView = itemAt.ListView
        '    Dim parent As DbObject = DirectCast(listView.Parent.Parent, DbObject)
        '    Dim view4 As DbObject = DirectCast(view5.Parent.Parent, DbObject)
        '    Dim link As New DbLink With {
        '    .Left = parent.Right,
        '    .Top = ((parent.Top + data.Position.Y) + &H16)
        '}
        '    playpen.Controls.Add(link)
        '    Dim link2 As New DbLink With {
        '    .Left = (view4.Left - 6),
        '    .Top = ((view4.Top + itemAt.Position.Y) + &H16)
        '}
        '    playpen.Controls.Add(link2)
        '    parent.AddLink("F"c, link, link2)
        '    view4.AddLink("T"c, link, link2)
    End Sub

    Public Sub Redraw()
        Dim enumerator As IEnumerator
        Dim graphics As Graphics = playpen.CreateGraphics
        Dim pen As New Pen(Color.Black, 1.0!)
        Try
            enumerator = playpen.Controls.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As Control = DirectCast(enumerator.Current, Control)
                Dim view As DbObject = TryCast(current, DbObject)
                If view IsNot Nothing Then
                    'Dim array(,) As ucLink(0 To .,0 To .) = DirectCast(view.Get_uLink, ucLink(0 To .,0 To .)(,))
                    'Me.myPath = New GraphicsPath(1 - 1) {}
                    'If (Not array Is Nothing) Then
                    '    Dim num2 As Integer = Information.UBound(array, 1)
                    '    Dim i As Integer = 0
                    '    Do While (i <= num2)
                    '        Me.myPath = DirectCast(Utils.CopyArray(DirectCast(Me.myPath, Array), New GraphicsPath(((Information.UBound(Me.myPath, 1) + 1) + 1) - 1) {}), GraphicsPath())
                    '        Me.myPath(Information.UBound(Me.myPath, 1)) = New GraphicsPath
                    '        Me.myPath(Information.UBound(Me.myPath, 1)).AddLine((array(i, 0).Left + 6), (array(i, 0).Top + 2), array(i, 1).Left, (array(i, 1).Top + 2))
                    '        graphics.DrawPath(pen, Me.myPath(Information.UBound(Me.myPath, 1)))
                    '        i += 1
                    '    Loop
                    'End If
                End If
            Loop
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Viewer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Redraw()
    End Sub
End Class

Public Class DbFieldInfo
    Property name As String
    Property [type] As String
    Property isKey As Boolean
End Class
