Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Helper
    Class ControlMover
        Public Enum Direction
            Any
            Horizontal
            Vertical
        End Enum

        Private Dragging As Boolean = False
        Private DragStart As Point = Point.Empty
        Private WithEvents ctrl As Control
        Private cont As Control
        Private dir As Direction

        Public Sub New(ByVal control As Control)
            Me.New(control, Direction.Any)
        End Sub

        Public Sub New(ByVal control As Control, ByVal direction As Direction)
            Me.New(control, control, direction)
        End Sub

        Public Sub New(ByVal control As Control, ByVal container As Control, ByVal direction As Direction)
            ctrl = control
            cont = container
            dir = direction

            AddHandler control.MouseDown, AddressOf MouseDownEventHandler
            AddHandler control.MouseUp, AddressOf MouseUpEventHandler
            AddHandler control.MouseMove, AddressOf MouseMoveEventHandler
        End Sub

        Public Sub MouseDownEventHandler(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ctrl.MouseDown
            Dragging = True
            DragStart = New Point(e.X, e.Y)
            ctrl.Capture = True
        End Sub

        Public Sub MouseUpEventHandler(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ctrl.MouseUp
            Dragging = False
            ctrl.Capture = False
        End Sub
        Public Sub MouseMoveEventHandler(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ctrl.MouseMove
            If Dragging Then
                If dir <> Direction.Vertical Then cont.Left = Math.Max(0, e.X + cont.Left - DragStart.X)
                If dir <> Direction.Horizontal Then cont.Top = Math.Max(0, e.Y + cont.Top - DragStart.Y)
            End If
        End Sub
    End Class
End Namespace