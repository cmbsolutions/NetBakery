<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Viewer
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.playpen = New System.Windows.Forms.Panel()
        Me.pInfo = New System.Windows.Forms.Panel()
        Me.lCy = New System.Windows.Forms.Label()
        Me.lCx = New System.Windows.Forms.Label()
        Me.lMy = New System.Windows.Forms.Label()
        Me.lMx = New System.Windows.Forms.Label()
        Me.lBottom = New System.Windows.Forms.Label()
        Me.lRight = New System.Windows.Forms.Label()
        Me.lLeft = New System.Windows.Forms.Label()
        Me.lTop = New System.Windows.Forms.Label()
        Me.Slider1 = New DevComponents.DotNetBar.Controls.Slider()
        Me.playpen.SuspendLayout()
        Me.pInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'playpen
        '
        Me.playpen.AutoScrollMinSize = New System.Drawing.Size(1024, 0)
        Me.playpen.AutoSize = True
        Me.playpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.playpen.BackColor = System.Drawing.Color.Transparent
        Me.playpen.BackgroundImage = Global.vbq.My.Resources.Resources.grid
        Me.playpen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.playpen.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.playpen.Location = New System.Drawing.Point(0, 0)
        Me.playpen.Margin = New System.Windows.Forms.Padding(0)
        Me.playpen.Name = "playpen"
        Me.playpen.Size = New System.Drawing.Size(1024, 512)
        Me.playpen.TabIndex = 4
        '
        'pInfo
        '
        Me.pInfo.BackColor = System.Drawing.Color.Transparent
        Me.pInfo.Controls.Add(Me.lCy)
        Me.pInfo.Controls.Add(Me.lCx)
        Me.pInfo.Controls.Add(Me.lMy)
        Me.pInfo.Controls.Add(Me.lMx)
        Me.pInfo.Controls.Add(Me.lBottom)
        Me.pInfo.Controls.Add(Me.lRight)
        Me.pInfo.Controls.Add(Me.lLeft)
        Me.pInfo.Controls.Add(Me.lTop)
        Me.pInfo.ForeColor = System.Drawing.Color.Lime
        Me.pInfo.Location = New System.Drawing.Point(3, 403)
        Me.pInfo.Name = "pInfo"
        Me.pInfo.Size = New System.Drawing.Size(107, 106)
        Me.pInfo.TabIndex = 5
        '
        'lCy
        '
        Me.lCy.AutoSize = True
        Me.lCy.Location = New System.Drawing.Point(3, 90)
        Me.lCy.Name = "lCy"
        Me.lCy.Size = New System.Drawing.Size(61, 13)
        Me.lCy.TabIndex = 7
        Me.lCy.Text = "CurrentY:"
        '
        'lCx
        '
        Me.lCx.AutoSize = True
        Me.lCx.Location = New System.Drawing.Point(3, 78)
        Me.lCx.Name = "lCx"
        Me.lCx.Size = New System.Drawing.Size(61, 13)
        Me.lCx.TabIndex = 6
        Me.lCx.Text = "CurrentX:"
        '
        'lMy
        '
        Me.lMy.AutoSize = True
        Me.lMy.Location = New System.Drawing.Point(3, 65)
        Me.lMy.Name = "lMy"
        Me.lMy.Size = New System.Drawing.Size(49, 13)
        Me.lMy.TabIndex = 5
        Me.lMy.Text = "MouseY:"
        '
        'lMx
        '
        Me.lMx.AutoSize = True
        Me.lMx.Location = New System.Drawing.Point(3, 52)
        Me.lMx.Name = "lMx"
        Me.lMx.Size = New System.Drawing.Size(49, 13)
        Me.lMx.TabIndex = 4
        Me.lMx.Text = "MouseX:"
        '
        'lBottom
        '
        Me.lBottom.AutoSize = True
        Me.lBottom.Location = New System.Drawing.Point(3, 39)
        Me.lBottom.Name = "lBottom"
        Me.lBottom.Size = New System.Drawing.Size(49, 13)
        Me.lBottom.TabIndex = 3
        Me.lBottom.Text = "Bottom:"
        '
        'lRight
        '
        Me.lRight.AutoSize = True
        Me.lRight.Location = New System.Drawing.Point(3, 26)
        Me.lRight.Name = "lRight"
        Me.lRight.Size = New System.Drawing.Size(43, 13)
        Me.lRight.TabIndex = 2
        Me.lRight.Text = "Right:"
        '
        'lLeft
        '
        Me.lLeft.AutoSize = True
        Me.lLeft.Location = New System.Drawing.Point(3, 0)
        Me.lLeft.Name = "lLeft"
        Me.lLeft.Size = New System.Drawing.Size(37, 13)
        Me.lLeft.TabIndex = 0
        Me.lLeft.Text = "Left:"
        '
        'lTop
        '
        Me.lTop.AutoSize = True
        Me.lTop.Location = New System.Drawing.Point(3, 13)
        Me.lTop.Name = "lTop"
        Me.lTop.Size = New System.Drawing.Size(31, 13)
        Me.lTop.TabIndex = 1
        Me.lTop.Text = "Top:"
        '
        'Slider1
        '
        '
        '
        '
        Me.Slider1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Slider1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Slider1.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top
        Me.Slider1.LabelVisible = False
        Me.Slider1.Location = New System.Drawing.Point(984, 0)
        Me.Slider1.Name = "Slider1"
        Me.Slider1.Size = New System.Drawing.Size(40, 512)
        Me.Slider1.SliderOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.Slider1.Step = 10
        Me.Slider1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Slider1.TabIndex = 6
        Me.Slider1.Value = 0
        '
        'Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BackgroundImage = Global.vbq.My.Resources.Resources.grid
        Me.Controls.Add(Me.playpen)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Viewer"
        Me.Size = New System.Drawing.Size(1024, 512)
        Me.playpen.ResumeLayout(False)
        Me.pInfo.ResumeLayout(False)
        Me.pInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents playpen As Panel
    Friend WithEvents pInfo As Panel
    Friend WithEvents lCy As Label
    Friend WithEvents lCx As Label
    Friend WithEvents lMy As Label
    Friend WithEvents lMx As Label
    Friend WithEvents lBottom As Label
    Friend WithEvents lRight As Label
    Friend WithEvents lLeft As Label
    Friend WithEvents lTop As Label
    Friend WithEvents Slider1 As DevComponents.DotNetBar.Controls.Slider
End Class
