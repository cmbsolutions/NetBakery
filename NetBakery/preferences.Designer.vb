<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class preferences
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
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
        Me.SwitchButton2 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.sbDebug = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.sbRoutineLayouts = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.erdepth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AntiAlias = True
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(316, 333)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 25)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.Symbol = ""
        Me.btnCancel.SymbolColor = System.Drawing.Color.Red
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AntiAlias = True
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(235, 333)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 25)
        Me.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOk.Symbol = ""
        Me.btnOk.SymbolColor = System.Drawing.Color.Lime
        Me.btnOk.TabIndex = 5
        Me.btnOk.Text = "Save"
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
        Me.cboStyle.Location = New System.Drawing.Point(205, 95)
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
        Me.LabelX2.Location = New System.Drawing.Point(12, 99)
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
        Me.erdepth.Location = New System.Drawing.Point(294, 125)
        Me.erdepth.MaxValue = 10
        Me.erdepth.MinValue = 1
        Me.erdepth.MouseWheelValueChangeEnabled = False
        Me.erdepth.Name = "erdepth"
        Me.erdepth.ShowUpDown = True
        Me.erdepth.Size = New System.Drawing.Size(66, 23)
        Me.erdepth.TabIndex = 18
        Me.erdepth.Value = Global.NetBakery.My.MySettings.Default.maxERDiagramDepth
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 128)
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
        Me.LabelX4.Location = New System.Drawing.Point(12, 150)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(125, 26)
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
        Me.SwitchButton1.Location = New System.Drawing.Point(294, 154)
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
        Me.SwitchButton1.ValueObject = "False"
        Me.SwitchButton1.ValueTrue = "True"
        '
        'SwitchButton2
        '
        '
        '
        '
        Me.SwitchButton2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.NetBakery.My.MySettings.Default, "autoExecuteSP", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SwitchButton2.Location = New System.Drawing.Point(294, 182)
        Me.SwitchButton2.Name = "SwitchButton2"
        Me.SwitchButton2.OffBackColor = System.Drawing.Color.Maroon
        Me.SwitchButton2.OffText = "No"
        Me.SwitchButton2.OnBackColor = System.Drawing.Color.DarkGreen
        Me.SwitchButton2.OnText = "Yes"
        Me.SwitchButton2.Size = New System.Drawing.Size(66, 22)
        Me.SwitchButton2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton2.SwitchClickTogglesValue = True
        Me.SwitchButton2.TabIndex = 23
        Me.SwitchButton2.Value = Global.NetBakery.My.MySettings.Default.autoExecuteSP
        Me.SwitchButton2.ValueFalse = "False"
        Me.SwitchButton2.ValueObject = "False"
        Me.SwitchButton2.ValueTrue = "True"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(12, 178)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(211, 26)
        Me.LabelX5.TabIndex = 22
        Me.LabelX5.Text = "Auto discover Stored Procedure layout"
        Me.LabelX5.WordWrap = True
        '
        'sbDebug
        '
        '
        '
        '
        Me.sbDebug.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbDebug.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.NetBakery.My.MySettings.Default, "showDebug", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.sbDebug.Location = New System.Drawing.Point(294, 210)
        Me.sbDebug.Name = "sbDebug"
        Me.sbDebug.OffBackColor = System.Drawing.Color.Maroon
        Me.sbDebug.OffText = "No"
        Me.sbDebug.OnBackColor = System.Drawing.Color.DarkGreen
        Me.sbDebug.OnText = "Yes"
        Me.sbDebug.Size = New System.Drawing.Size(66, 22)
        Me.sbDebug.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbDebug.SwitchClickTogglesValue = True
        Me.sbDebug.TabIndex = 25
        Me.sbDebug.Value = Global.NetBakery.My.MySettings.Default.showDebug
        Me.sbDebug.ValueFalse = "False"
        Me.sbDebug.ValueObject = "False"
        Me.sbDebug.ValueTrue = "True"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(12, 206)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(138, 26)
        Me.LabelX6.TabIndex = 24
        Me.LabelX6.Text = "Show debug information"
        Me.LabelX6.WordWrap = True
        '
        'sbRoutineLayouts
        '
        '
        '
        '
        Me.sbRoutineLayouts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbRoutineLayouts.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.NetBakery.My.MySettings.Default, "mergeRoutineLayouts", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.sbRoutineLayouts.Location = New System.Drawing.Point(294, 238)
        Me.sbRoutineLayouts.Name = "sbRoutineLayouts"
        Me.sbRoutineLayouts.OffBackColor = System.Drawing.Color.Maroon
        Me.sbRoutineLayouts.OffText = "No"
        Me.sbRoutineLayouts.OnBackColor = System.Drawing.Color.DarkGreen
        Me.sbRoutineLayouts.OnText = "Yes"
        Me.sbRoutineLayouts.Size = New System.Drawing.Size(66, 22)
        Me.sbRoutineLayouts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.sbRoutineLayouts, New DevComponents.DotNetBar.SuperTooltipInfo("Share routine layouts", "", "Set this to ""yes"" to use one layout for routines that have the same output struct" &
            "ure.", Global.NetBakery.My.Resources.Resources.info, Nothing, DevComponents.DotNetBar.eTooltipColor.System))
        Me.sbRoutineLayouts.SwitchClickTogglesValue = True
        Me.sbRoutineLayouts.TabIndex = 27
        Me.sbRoutineLayouts.Value = Global.NetBakery.My.MySettings.Default.mergeRoutineLayouts
        Me.sbRoutineLayouts.ValueFalse = "False"
        Me.sbRoutineLayouts.ValueObject = "True"
        Me.sbRoutineLayouts.ValueTrue = "True"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(12, 234)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(138, 26)
        Me.LabelX7.TabIndex = 26
        Me.LabelX7.Text = "Share routine layouts"
        Me.LabelX7.WordWrap = True
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.System)
        Me.SuperTooltip1.DelayTooltipHideDuration = 100
        Me.SuperTooltip1.TooltipDuration = 10
        '
        'preferences
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(398, 367)
        Me.Controls.Add(Me.sbRoutineLayouts)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.sbDebug)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.SwitchButton2)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.SwitchButton1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.erdepth)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.cboStyle)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtDescription)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "preferences"
        Me.RenderFormIcon = False
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Preferences"
        Me.TitleText = "Preferences"
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
    Friend WithEvents SwitchButton2 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents sbDebug As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents sbRoutineLayouts As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
End Class
