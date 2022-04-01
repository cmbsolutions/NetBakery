<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cTable
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.panel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.fields = New DevComponents.DotNetBar.ListBoxAdv()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.AutoSize = True
        Me.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.panel1.Controls.Add(Me.fields)
        Me.panel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel1.HideControlsWhenCollapsed = True
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(155, 116)
        Me.panel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.panel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.panel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.panel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.panel1.Style.GradientAngle = 90
        Me.panel1.TabIndex = 0
        Me.panel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.panel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.panel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.panel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.panel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.panel1.TitleStyle.GradientAngle = 90
        Me.panel1.TitleText = "Title Bar"
        '
        'fields
        '
        Me.fields.AutoScroll = True
        '
        '
        '
        Me.fields.BackgroundStyle.Class = "ListBoxAdv"
        Me.fields.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fields.CheckStateMember = Nothing
        Me.fields.ContainerControlProcessDialogKey = True
        Me.fields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fields.DragDropSupport = True
        Me.fields.Location = New System.Drawing.Point(0, 26)
        Me.fields.Name = "fields"
        Me.fields.Size = New System.Drawing.Size(155, 90)
        Me.fields.TabIndex = 4
        Me.fields.Text = "ListBoxAdv1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 116)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(155, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'cTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(100, 26)
        Me.Name = "cTable"
        Me.Size = New System.Drawing.Size(155, 138)
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents fields As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents StatusStrip1 As StatusStrip
End Class
