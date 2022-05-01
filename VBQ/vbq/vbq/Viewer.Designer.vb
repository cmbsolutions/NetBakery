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
        Me.SuspendLayout()
        '
        'playpen
        '
        Me.playpen.AutoScroll = True
        Me.playpen.AutoSize = True
        Me.playpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.playpen.BackColor = System.Drawing.Color.Transparent
        Me.playpen.BackgroundImage = Global.vbq.My.Resources.Resources.grid1
        Me.playpen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.playpen.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.playpen.Location = New System.Drawing.Point(0, 0)
        Me.playpen.Margin = New System.Windows.Forms.Padding(0)
        Me.playpen.Name = "playpen"
        Me.playpen.Size = New System.Drawing.Size(1024, 512)
        Me.playpen.TabIndex = 4
        '
        'Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BackgroundImage = Global.vbq.My.Resources.Resources.grid1
        Me.Controls.Add(Me.playpen)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Viewer"
        Me.Size = New System.Drawing.Size(1024, 512)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents playpen As Panel
End Class
