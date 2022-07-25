<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Diff
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Diff))
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.StyleManagerAmbient1 = New DevComponents.DotNetBar.StyleManagerAmbient(Me.components)
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.bSwitchMode = New DevComponents.DotNetBar.ButtonItem()
        Me.bOtherActions = New DevComponents.DotNetBar.ButtonItem()
        Me.MainPanel = New System.Windows.Forms.Panel()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "DotNetBar Bar (Bar1)"
        Me.Bar1.AccessibleName = "DotNetBar Bar"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Bar1.AntiAlias = True
        Me.Bar1.CanAutoHide = False
        Me.Bar1.CanCustomize = False
        Me.Bar1.CanDockLeft = False
        Me.Bar1.CanDockRight = False
        Me.Bar1.CanDockTab = False
        Me.Bar1.CanDockTop = False
        Me.Bar1.CanMaximizeFloating = False
        Me.Bar1.CanMove = False
        Me.Bar1.CanReorderTabs = False
        Me.Bar1.CanUndock = False
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockTabStripHeight = 30
        Me.Bar1.DoubleClickBehavior = DevComponents.DotNetBar.eDoubleClickBarBehavior.None
        Me.Bar1.EqualButtonSize = True
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bSwitchMode, Me.bOtherActions})
        Me.Bar1.ItemSpacing = 5
        Me.Bar1.Location = New System.Drawing.Point(0, 482)
        Me.Bar1.Margin = New System.Windows.Forms.Padding(0)
        Me.Bar1.MenuBar = True
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingTop = 2
        Me.Bar1.Size = New System.Drawing.Size(1053, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        Me.Bar1.ThemeAware = True
        '
        'bSwitchMode
        '
        Me.bSwitchMode.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.bSwitchMode.Name = "bSwitchMode"
        Me.bSwitchMode.Text = "Switch Mode"
        Me.bSwitchMode.ThemeAware = True
        '
        'bOtherActions
        '
        Me.bOtherActions.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.bOtherActions.Name = "bOtherActions"
        Me.bOtherActions.Text = "..."
        Me.bOtherActions.ThemeAware = True
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(1053, 482)
        Me.MainPanel.TabIndex = 1
        '
        'Diff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.CaptionFont = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(1053, 507)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Diff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diff"
        Me.TitleText = "Diff viewer"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents StyleManagerAmbient1 As DevComponents.DotNetBar.StyleManagerAmbient
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents bSwitchMode As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bOtherActions As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MainPanel As Panel
End Class
