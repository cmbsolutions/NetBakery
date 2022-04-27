Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices

Public Class Viewer
    Private DbLinkPairs As List(Of DbLinkPair)

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
        Dim t As New DbTableObject
        t.lTitle.Text = name
        t.Name = name
        t.Left = xOffset + 50
        t.Top = yOffset + 50

        xOffset = t.Right

        If xOffset > playpen.Width Then
            xOffset = 0
            yOffset += t.Bottom
        End If

        For Each f In fields
            t.AddField(f.name, f.type, f.isKey, f.isLink)
        Next

        t.EnsureVisible()
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

    Private Sub playpen_Paint(sender As Object, e As PaintEventArgs) Handles playpen.Paint
        Dim graphics As Graphics = e.Graphics
        'graphics.InterpolationMode = InterpolationMode.HighQualityBilinear
        'graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim pen As New Pen(Color.Yellow, 3.0!)

        Try

            If DbLinkPairs IsNot Nothing Then

                For Each d In DbLinkPairs
                    Dim gp As New GraphicsPath
                    Dim startLeft, endLeft As Boolean

                    Dim fmpx As Integer = d.fromCtrl.Left + CInt(d.fromCtrl.Width / 2)
                    Dim tmpx As Integer = d.toCtrl.Left + CInt(d.toCtrl.Width / 2)
                    Dim fmpy As Integer = d.fromCtrl.Top + CInt(d.fromCtrl.Height / 2)
                    Dim tmpy As Integer = d.toCtrl.Top + CInt(d.toCtrl.Height / 2)

                    If d.fromCtrl.Right < d.toCtrl.Left Then
                        startLeft = False
                        endLeft = True
                    ElseIf d.fromCtrl.Left > d.toCtrl.Right Then
                        startLeft = True
                        endLeft = False
                    ElseIf fmpx < tmpx Then
                        startLeft = True
                        endLeft = True
                    Else
                        startLeft = False
                        endLeft = False
                    End If

                    If startLeft And endLeft Then
                        Dim xmin = Math.Min(d.fromCtrl.Left, d.toCtrl.Left)

                        gp.AddLine(New Point(d.fromCtrl.Left, fmpy), New Point(xmin - 10, fmpy))
                        gp.AddLine(New Point(xmin - 10, fmpy), New Point(xmin - 10, tmpy))
                        gp.AddLine(New Point(xmin - 10, tmpy), New Point(d.toCtrl.Left, tmpy))
                    End If

                    If Not startLeft And Not endLeft Then
                        Dim xmax = Math.Max(d.fromCtrl.Right, d.toCtrl.Right)

                        gp.AddLine(New Point(d.fromCtrl.Right, fmpy), New Point(xmax + 10, fmpy))
                        gp.AddLine(New Point(xmax + 10, fmpy), New Point(xmax + 10, tmpy))
                        gp.AddLine(New Point(xmax + 10, tmpy), New Point(d.toCtrl.Right, tmpy))
                    End If

                    If startLeft And Not endLeft Then
                        Dim xdist = CInt(Math.Abs(d.fromCtrl.Left - d.toCtrl.Right) / 2)

                        gp.AddLine(New Point(d.fromCtrl.Left, fmpy), New Point(d.fromCtrl.Left - xdist, fmpy))
                        gp.AddLine(New Point(d.fromCtrl.Left - xdist, fmpy), New Point(d.fromCtrl.Left - xdist, tmpy))
                        gp.AddLine(New Point(d.fromCtrl.Left - xdist, tmpy), New Point(d.toCtrl.Right, tmpy))
                    End If

                    If Not startLeft And endLeft Then
                        Dim xdist = CInt(Math.Abs(d.fromCtrl.Right - d.toCtrl.Left) / 2)

                        gp.AddLine(New Point(d.fromCtrl.Right, fmpy), New Point(d.fromCtrl.Right + xdist, fmpy))
                        gp.AddLine(New Point(d.fromCtrl.Right + xdist, fmpy), New Point(d.fromCtrl.Right + xdist, tmpy))
                        gp.AddLine(New Point(d.fromCtrl.Right + xdist, tmpy), New Point(d.toCtrl.Left, tmpy))
                    End If
                    graphics.DrawPath(pen, gp)
                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class

Public Class DbFieldInfo
    Property name As String
    Property [type] As String
    Property isKey As Boolean
    Property isLink As Boolean
End Class

Public Class DbLinkPair
    Property fromCtrl As Control
    Property toCtrl As Control
    Property StartFromLink As Point
    Property EndAtLink As Point
End Class