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
        Me.erdepth = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton1 = New DevComponents.DotNetBar.Controls.SwitchButton()
        CType(Me.erdepth, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LabelX1.Size = New System.Drawing.Size(84, 20)
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
        Me.txtDescription.Location = New System.Drawing.Point(12, 38)
        Me.txtDescription.MaxLength = 1000
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PreventEnterBeep = True
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescription.Size = New System.Drawing.Size(348, 50)
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
        Me.cboStyle.ItemHeight = 18
        Me.cboStyle.Items.AddRange(New Object() {Me.VisualStudio2012Light, Me.VisualStudio2012Dark})
        Me.cboStyle.Location = New System.Drawing.Point(145, 94)
        Me.cboStyle.Name = "cboStyle"
        Me.cboStyle.Size = New System.Drawing.Size(155, 24)
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
        Me.LabelX2.Location = New System.Drawing.Point(12, 94)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(84, 20)
        Me.LabelX2.TabIndex = 17
        Me.LabelX2.Text = "Overall style"
        '
        'erdepth
        '
        Me.erdepth.AllowEmptyState = False
        '
        '
        '
        Me.erdepth.BackgroundStyle.BackColor = System.Drawing.Color.Black
        Me.erdepth.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.erdepth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.erdepth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.erdepth.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.NetBakery.My.MySettings.Default, "maxERDiagramDepth", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.erdepth.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.erdepth.InputMouseWheelEnabled = False
        Me.erdepth.Location = New System.Drawing.Point(145, 124)
        Me.erdepth.MaxValue = 10
        Me.erdepth.MinValue = 1
        Me.erdepth.MouseWheelValueChangeEnabled = False
        Me.erdepth.Name = "erdepth"
        Me.erdepth.ShowUpDown = True
        Me.erdepth.Size = New System.Drawing.Size(59, 23)
        Me.erdepth.TabIndex = 18
        Me.erdepth.Value = Global.NetBakery.My.MySettings.Default.maxERDiagramDepth
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 124)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(125, 20)
        Me.LabelX3.TabIndex = 19
        Me.LabelX3.Text = "Max ERDiagram Depth"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(12, 153)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(125, 23)
        Me.LabelX4.TabIndex = 20
        Me.LabelX4.Text = "Open last project"
        '
        'SwitchButton1
        '
        '
        '
        '
        Me.SwitchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.NetBakery.My.MySettings.Default, "openLastProject", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SwitchButton1.Location = New System.Drawing.Point(145, 153)
        Me.SwitchButton1.Name = "SwitchButton1"
        Me.SwitchButton1.OffBackColor = System.Drawing.Color.Maroon
        Me.SwitchButton1.OffText = "No"
        Me.SwitchButton1.OnBackColor = System.Drawing.Color.DarkGreen
        Me.SwitchButton1.OnText = "Yes"
        Me.SwitchButton1.Size = New System.Drawing.Size(66, 22)
        Me.SwitchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton1.SwitchClickTogglesValue = True
        Me.SwitchButton1.TabIndex = 21
        Me.SwitchButton1.Value = Global.NetBakery.My.MySettings.Default.openLastProject
        Me.SwitchButton1.ValueFalse = "False"
        Me.SwitchButton1.ValueObject = "True"
        Me.SwitchButton1.ValueTrue = "True"
        '
        'preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(513, 349)
        Me.Controls.Add(Me.SwitchButton1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.erdepth)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.cboStyle)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtDescription)
        Me.Name = "preferences"
        Me.Controls.SetChildIndex(Me.txtDescription, 0)
        Me.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.Controls.SetChildIndex(Me.cboStyle, 0)
        Me.Controls.SetChildIndex(Me.LabelX2, 0)
        Me.Controls.SetChildIndex(Me.erdepth, 0)
        Me.Controls.SetChildIndex(Me.LabelX3, 0)
        Me.Controls.SetChildIndex(Me.LabelX4, 0)
        Me.Controls.SetChildIndex(Me.SwitchButton1, 0)
        CType(Me.erdepth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDescription As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cboStyle As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents VisualStudio2012Light As DevComponents.Editors.ComboItem
    Friend WithEvents VisualStudio2012Dark As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents erdepth As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton1 As DevComponents.DotNetBar.Controls.SwitchButton
End Class
