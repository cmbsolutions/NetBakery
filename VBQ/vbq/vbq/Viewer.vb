Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices

Public Class Viewer
    Private DbLinkPairs As List(Of DbLinkPair)
    Private myPath As GraphicsPath()

    Private xOffset, yOffset As Integer

    Public Sub AddLink(fromName As String, toName As String)
        If DbLinkPairs Is Nothing Then DbLinkPairs = New List(Of DbLinkPair)

        Dim idx = playpen.Controls.IndexOfKey(fromName)
        Dim f = playpen.Controls.Item(idx)
        idx = playpen.Controls.IndexOfKey(toName)
        Dim t = playpen.Controls.Item(idx)

        DbLinkPairs.Add(New DbLinkPair With {
                        .fromCtrl = f,
                        .toCtrl = t
                        })

    End Sub

    Public Sub AddTable(name As String, fields As List(Of DbFieldInfo))
        Dim t As New DbObject
        t.lTitle.Text = name
        t.Name = name
        t.Left = xOffset + 10
        t.Top = yOffset + 10

        xOffset = t.Right

        If xOffset > playpen.Width Then
            xOffset = 0
            yOffset += t.Bottom
        End If

        For Each f In fields
            t.AddField(f.name, f.type, f.isKey)
        Next

        playpen.Controls.Add(t)
    End Sub

    Public Sub RemoveTable(name As String)
        Dim idx = playpen.Controls.IndexOfKey(name)
        Dim t = playpen.Controls.Item(idx)

        If t IsNot Nothing Then
            playpen.Controls.Remove(t)
        End If
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
        Dim graphics As Graphics = playpen.CreateGraphics
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim pen As New Pen(Color.SlateGray, 2.0!)

        Try

            If DbLinkPairs IsNot Nothing Then
                For Each d In DbLinkPairs
                    Dim fp As New Point(d.fromCtrl.Right, d.fromCtrl.Bottom - CInt(d.fromCtrl.Height / 2))
                    Dim tp As New Point(d.toCtrl.Left, d.toCtrl.Bottom - CInt(d.toCtrl.Height / 2))

                    Dim xDist = CInt(Math.Abs(fp.X - tp.X) / 2)

                    graphics.DrawLine(pen, fp, New Point(fp.X + xDist, fp.Y))
                    graphics.DrawLine(pen, tp, New Point(tp.X - xDist, tp.Y))
                    graphics.DrawLine(pen, New Point(fp.X + xDist, fp.Y), New Point(tp.X - xDist, tp.Y))
                Next
            End If
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

Public Class DbLinkPair
    Property fromCtrl As Control
    Property toCtrl As Control
    Property StartFromLink As Point
    Property EndAtLink As Point
End Class