Imports System.Drawing.Drawing2D

Public Class DbTableObject
    <System.Runtime.InteropServices.DllImport("gdi32.dll")>
    Private Shared Function CreateRoundRectRgn(nLeftRect As Integer, nTopRect As Integer, nRightRect As Integer, nBottomRect As Integer, nWidthEllipse As Integer, nHeightEllipse As Integer) As IntPtr
    End Function


    Private _radius As Integer = 24
    Public Property Radius() As Integer
        Get
            Return _radius
        End Get
        Set(value As Integer)
            _radius = value
            RecreateRegion()
        End Set
    End Property

    Private Function GetRoundRectagle(bounds As Rectangle, radius As Integer) As GraphicsPath
        Dim r As Single = radius
        Dim r2 As Single = 0.0!
        Dim path As New GraphicsPath()

        path.StartFigure()
        path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90)
        path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90)
        path.AddLine(bounds.Right, bounds.Top + r, bounds.Right, bounds.Bottom)
        path.AddLine(bounds.Right, bounds.Bottom, bounds.Left, bounds.Bottom)
        path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Top + r)

        '        path.AddArc(bounds.Right - r2, bounds.Bottom - r2, r2, r2, 0, 90)
        '        path.AddArc(bounds.Left, bounds.Bottom - r2, r2, r2, 90, 90)
        path.CloseFigure()

        Return path
    End Function

    Private Sub RecreateRegion()
        Dim bounds = ClientRectangle

        Dim path = GetRoundRectagle(bounds, Radius)
        Region = New Region(path)

        'Better round rectangle
        'Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top, bounds.Right, bounds.Bottom, Radius, Radius))
        Invalidate()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        RecreateRegion()
    End Sub

    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    '    PaintTransparentBackground(Me, e)
    '    ' TODO: Paint your actual content here with rounded corners
    'End Sub

    'Private Shared Sub PaintTransparentBackground(ByVal c As Control, ByVal e As PaintEventArgs)
    '    If c.Parent Is Nothing OrElse Not Application.RenderWithVisualStyles Then
    '        Exit Sub
    '    End If

    '    ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c)
    'End Sub

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

    Private Sub p_MouseDown(sender As Object, e As MouseEventArgs) Handles pLeft.MouseDown, pRight.MouseDown, pBottomRight.MouseDown, pBottom.MouseDown
        If Not IsMoving And Not IsResizing And e.Button = MouseButtons.Left Then
            IsResizing = True
            x = e.X
            y = e.Y
        End If
    End Sub

    Private Sub p_MouseUp(sender As Object, e As MouseEventArgs) Handles pLeft.MouseUp, pRight.MouseUp, pBottomRight.MouseUp, pBottom.MouseUp
        If IsResizing And e.Button = MouseButtons.Left Then IsResizing = False
    End Sub

    Private Sub pBottom_MouseMove(sender As Object, e As MouseEventArgs) Handles pBottom.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Height += e.Y - y
            Parent.Refresh()
        End If
    End Sub

    Private Sub pBottomRight_MouseMove(sender As Object, e As MouseEventArgs) Handles pBottomRight.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Height += e.Y - y
            Width += e.X - x
            Parent.Refresh()
        End If
    End Sub

    Private Sub lFields_MouseClick(sender As Object, e As MouseEventArgs) Handles lFields.MouseClick
        Debug.WriteLine("Click")
    End Sub

    Private Sub pLeft_MouseMove(sender As Object, e As MouseEventArgs) Handles pRight.MouseMove
        If IsResizing And e.Button = MouseButtons.Left Then
            Width += e.X - x
            Parent.Refresh()
        End If
    End Sub
End Class
