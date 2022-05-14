Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices

Public Class Viewer
    Private DbLinkPairs As List(Of DbLinkPair)
    Private playpenObjects As List(Of playpenObject)
    Private renderLinks As Boolean = True
    Private xOffset, yOffset As Integer

    Public Sub AddLink(fromName As String, toName As String)
        If DbLinkPairs Is Nothing Then DbLinkPairs = New List(Of DbLinkPair)

        Dim f = playpenObjects.FirstOrDefault(Function(c) c.name = fromName)
        Dim t = playpenObjects.FirstOrDefault(Function(c) c.name = toName)

        DbLinkPairs.Add(New DbLinkPair With {
                        .fromCtrl = f,
                        .toCtrl = t
                        })
    End Sub

    Public Sub AddTable(name As String, fields As List(Of DbFieldInfo))
        If playpenObjects Is Nothing Then playpenObjects = New List(Of PlaypenObject)

        Dim p As New PlaypenObject With {
            .name = name
        }

        p.ctrl = New DbTableObject
        p.ctrl.lTitle.Text = name
        p.ctrl.Name = name
        p.ctrl.Left = xOffset + 50
        p.ctrl.Top = yOffset + 50


        xOffset = p.Ctrl.Right

        If xOffset + 150 > playpen.Width Then
            xOffset = 0
            yOffset = p.Ctrl.Bottom
        End If

        For Each f In fields
            p.ctrl.AddField(f.name, f.type, f.isKey, f.isLink)
        Next

        AddHandler p.Ctrl.ManipulationDoneEvent, AddressOf ManipulationDoneEventHandler
        AddHandler p.Ctrl.ManipulationUpdateEvent, AddressOf ManipulationUpdateEventHandler
        AddHandler p.ctrl.ManipulationStartEvent, AddressOf ManipulationStartEventHandler
        AddHandler p.ctrl.GotFocus, AddressOf DbTableObjectFocusChangedEventHandler

        'p.ctrl.EnsureVisible()
        playpenObjects.Add(p)
        playpen.Controls.Add(p.ctrl)
    End Sub

    Private Sub ManipulationUpdateEventHandler(sender As Object, e As MovementEvent)
        lLeft.Text = $"Left: {e.left}"
        lTop.Text = $"Top: {e.top}"
        lRight.Text = $"Right: {e.right}"
        lBottom.Text = $"Bottom: {e.bottom}"
        lMx.Text = $"MouseX: {e.MouseX }"
        lMy.Text = $"MouseY: {e.MouseY}"
        lCx.Text = $"CurrentX: {e.CurrentX}"
        lCy.Text = $"CurrentY: {e.CurrentY}"

        pInfo.Invalidate()
    End Sub

    Private Sub DbTableObjectFocusChangedEventHandler(sender As DbTableObject)
        playpenObjects.ForEach(Sub(f) f.HasFocus = False)
        playpenObjects.FirstOrDefault(Function(c) c.Name = sender.Name).HasFocus = True
        playpenObjects.FirstOrDefault(Function(c) c.Name = sender.Name).Ctrl.BringToFront()
        playpen.Invalidate()
    End Sub

    Private Sub ManipulationStartEventHandler(sender As Object)
        renderLinks = False
        playpen.Invalidate()
    End Sub

    Private Sub ManipulationDoneEventHandler(sender As Object)
        renderLinks = True
        playpen.Invalidate()
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
        graphics.InterpolationMode = InterpolationMode.Low
        graphics.SmoothingMode = SmoothingMode.HighSpeed

        Dim Pen As New Pen(Color.DarkOrange, 2.5!)
        Dim focusPen As New Pen(Color.OrangeRed, 2.5!)

        Try

            If DbLinkPairs IsNot Nothing And renderLinks Then
                playpenObjects.ForEach(Sub(c) c.yOffset = 0)

                For Each d In DbLinkPairs
                    Dim gp As New GraphicsPath
                    If d.startLeft And d.endLeft Then
                        Dim xmin = Math.Min(d.fromCtrl.Ctrl.Left, d.toCtrl.Ctrl.Left)

                        gp.AddLine(New Point(d.fromCtrl.Ctrl.Left, d.fCtrlMidY), New Point(xmin - 10, d.fCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(xmin - 10, d.tCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(d.toCtrl.Ctrl.Left, d.tCtrlMidY))
                    End If

                    If Not d.startLeft And Not d.endLeft Then
                        Dim xmax = Math.Max(d.fromCtrl.Ctrl.Right, d.toCtrl.Ctrl.Right)

                        gp.AddLine(New Point(d.fromCtrl.Ctrl.Right, d.fCtrlMidY), New Point(xmax + 10, d.fCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(xmax + 10, d.tCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(d.toCtrl.Ctrl.Right, d.tCtrlMidY))
                    End If

                    If d.startLeft And Not d.endLeft Then
                        Dim xdist = CInt(Math.Abs(d.fromCtrl.Ctrl.Left - d.toCtrl.Ctrl.Right) / 2)

                        gp.AddLine(New Point(d.fromCtrl.Ctrl.Left, d.fCtrlMidY), New Point(d.fromCtrl.Ctrl.Left - xdist, d.fCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(d.fromCtrl.Ctrl.Left - xdist, d.tCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(d.toCtrl.Ctrl.Right, d.tCtrlMidY))
                    End If

                    If Not d.startLeft And d.endLeft Then
                        Dim xdist = CInt(Math.Abs(d.fromCtrl.Ctrl.Right - d.toCtrl.Ctrl.Left) / 2)

                        gp.AddLine(New Point(d.fromCtrl.Ctrl.Right, d.fCtrlMidY), New Point(d.fromCtrl.Ctrl.Right + xdist, d.fCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(d.fromCtrl.Ctrl.Right + xdist, d.tCtrlMidY))
                        gp.AddLine(gp.GetLastPoint, New Point(d.toCtrl.Ctrl.Left, d.tCtrlMidY))
                    End If

                    If d.fromCtrl.HasFocus Or d.toCtrl.HasFocus Then
                        graphics.DrawPath(focusPen, gp)
                    Else
                        graphics.DrawPath(Pen, gp)
                    End If

                    d.fromCtrl.yOffset += 6
                    d.toCtrl.yOffset += 6
                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Viewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Private Sub playpen_ControlAdded(sender As Object, e As ControlEventArgs) Handles playpen.ControlAdded
        Slider1.Maximum = playpen.Height
    End Sub
End Class

Public Class DbFieldInfo
    Property name As String
    Property [type] As String
    Property isKey As Boolean
    Property isLink As Boolean
End Class

Public Class PlaypenObject
    Property Ctrl As DbTableObject
    Property Name As String
    Property HasFocus As Boolean

    Property yOffset As Integer
End Class

Public Class DbLinkPair
    Property fromCtrl As PlaypenObject
    Property toCtrl As PlaypenObject



    ReadOnly Property fCtrlMidX As Integer
        Get
            Return fromCtrl.ctrl.Left + CInt(fromCtrl.ctrl.Width / 2)
        End Get
    End Property
    ReadOnly Property fCtrlMidY As Integer
        Get
            Return fromCtrl.Ctrl.Top + CInt(fromCtrl.Ctrl.Height / 2) + fromCtrl.yOffset
        End Get
    End Property
    ReadOnly Property tCtrlMidX As Integer
        Get
            Return toCtrl.ctrl.Left + CInt(toCtrl.ctrl.Width / 2)
        End Get
    End Property
    ReadOnly Property tCtrlMidY As Integer
        Get
            Return toCtrl.Ctrl.Top + CInt(toCtrl.Ctrl.Height / 2) + toCtrl.yOffset
        End Get
    End Property

    ReadOnly Property startLeft As Boolean
        Get
            If fromCtrl.ctrl.Right < toCtrl.ctrl.Left Then
                Return False
            ElseIf fromCtrl.ctrl.Left > toCtrl.ctrl.Right Then
                Return True
            ElseIf fCtrlMidX < tCtrlMidX Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    ReadOnly Property endLeft As Boolean
        Get
            If fromCtrl.ctrl.Right < toCtrl.ctrl.Left Then
                Return True
            ElseIf fromCtrl.ctrl.Left > toCtrl.ctrl.Right Then
                Return False
            ElseIf fCtrlMidX < tCtrlMidX Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
End Class