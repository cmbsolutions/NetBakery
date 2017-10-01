<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class preferences
    Inherits NetBakery.iDefaultDialog

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtDescription = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cboStyle = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.VisualStudio2012Light = New DevComponents.Editors.ComboItem()
        Me.VisualStudio2012Dark = New DevComponents.Editors.ComboItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(125, 20)
        Me.LabelX1.TabIndex = 15
        Me.LabelX1.Text = "Routine regex"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtDescription.Border.Class = "TextBoxBorder"
        Me.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.NetBakery.My.MySettings.Default, "routineRegex", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDescription.DisabledBackColor = System.Drawing.Color.Black
        Me.txtDescription.ForeColor = System.Drawing.Color.White
        Me.txtDescription.Location = New System.Drawing.Point(143, 12)
        Me.txtDescription.MaxLength = 255
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PreventEnterBeep = True
        Me.txtDescription.Size = New System.Drawing.Size(261, 23)
        Me.txtDescription.TabIndex = 14
        Me.txtDescription.Text = Global.NetBakery.My.MySettings.Default.routineRegex
        Me.txtDescription.WatermarkText = "Enter a description..."
        '
        'cboStyle
        '
        Me.cboStyle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.NetBakery.My.MySettings.Default, "gui_style", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cboStyle.DisplayMember = "Text"
        Me.cboStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboStyle.ForeColor = System.Drawing.Color.White
        Me.cboStyle.FormattingEnabled = True
        Me.cboStyle.ItemHeight = 17
        Me.cboStyle.Items.AddRange(New Object() {Me.VisualStudio2012Light, Me.VisualStudio2012Dark})
        Me.cboStyle.Location = New System.Drawing.Point(143, 41)
        Me.cboStyle.Name = "cboStyle"
        Me.cboStyle.Size = New System.Drawing.Size(261, 23)
        Me.cboStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboStyle.TabIndex = 16
        Me.cboStyle.Text = Global.NetBakery.My.MySettings.Default.gui_style
        '
        'VisualStudio2012Light
        '
        Me.VisualStudio2012Light.Text = "VisualStudio2012Light"
        Me.VisualStudio2012Light.Value = "VisualStudio2012Light"
        '
        'VisualStudio2012Dark
        '
        Me.VisualStudio2012Dark.Text = "VisualStudio2012Dark"
        Me.VisualStudio2012Dark.Value = "VisualStudio2012Dark"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 41)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(125, 20)
        Me.LabelX2.TabIndex = 17
        Me.LabelX2.Text = "Overall style"
        '
        'preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(503, 220)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.cboStyle)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtDescription)
        Me.Name = "preferences"
        Me.Controls.SetChildIndex(Me.txtDescription, 0)
        Me.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.Controls.SetChildIndex(Me.cboStyle, 0)
        Me.Controls.SetChildIndex(Me.LabelX2, 0)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDescription As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cboStyle As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents VisualStudio2012Light As DevComponents.Editors.ComboItem
    Friend WithEvents VisualStudio2012Dark As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
