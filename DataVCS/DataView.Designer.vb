<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataView))
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.StyleManagerAmbient1 = New DevComponents.DotNetBar.StyleManagerAmbient(Me.components)
        Me.grid = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.navigator = New DevComponents.DotNetBar.Controls.BindingNavigatorEx(Me.components)
        Me.BindingNavigatorMoveFirstItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorMovePreviousItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorPositionItem = New DevComponents.DotNetBar.TextBoxItem()
        Me.BindingNavigatorCountItem = New DevComponents.DotNetBar.LabelItem()
        Me.BindingNavigatorMoveNextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorMoveLastItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorAddNewItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorDeleteItem = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.navigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'grid
        '
        Me.grid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.DefaultCellStyle = DataGridViewCellStyle2
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.grid.Location = New System.Drawing.Point(0, 0)
        Me.grid.Margin = New System.Windows.Forms.Padding(0)
        Me.grid.Name = "grid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grid.Size = New System.Drawing.Size(803, 357)
        Me.grid.TabIndex = 0
        Me.grid.UseCustomBackgroundColor = True
        '
        'navigator
        '
        Me.navigator.AddNewRecordButton = Me.BindingNavigatorAddNewItem
        Me.navigator.AntiAlias = True
        Me.navigator.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.navigator.CanMaximizeFloating = False
        Me.navigator.ColorScheme.BarBackground = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.navigator.ColorScheme.BarBackground2 = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.navigator.ColorScheme.BarCaptionBackground = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.navigator.ColorScheme.BarCaptionInactiveBackground = System.Drawing.SystemColors.WindowFrame
        Me.navigator.ColorScheme.BarCaptionInactiveText = System.Drawing.SystemColors.InactiveCaption
        Me.navigator.ColorScheme.BarCaptionText = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.navigator.ColorScheme.BarFloatingBorder = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.navigator.ColorScheme.BarPopupBackground = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.navigator.ColorScheme.MenuBackground = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.navigator.ColorScheme.MenuBarBackground = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.navigator.ColorScheme.MenuSide = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.navigator.CountLabel = Me.BindingNavigatorCountItem
        Me.navigator.CountLabelFormat = "of {0}"
        Me.navigator.DeleteButton = Me.BindingNavigatorDeleteItem
        Me.navigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.navigator.DoubleClickBehavior = DevComponents.DotNetBar.eDoubleClickBarBehavior.None
        Me.navigator.FadeEffect = True
        Me.navigator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.navigator.IsMaximized = False
        Me.navigator.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.navigator.Location = New System.Drawing.Point(0, 357)
        Me.navigator.MoveFirstButton = Me.BindingNavigatorMoveFirstItem
        Me.navigator.MoveLastButton = Me.BindingNavigatorMoveLastItem
        Me.navigator.MoveNextButton = Me.BindingNavigatorMoveNextItem
        Me.navigator.MovePreviousButton = Me.BindingNavigatorMovePreviousItem
        Me.navigator.Name = "navigator"
        Me.navigator.PositionTextBox = Me.BindingNavigatorPositionItem
        Me.navigator.Size = New System.Drawing.Size(803, 25)
        Me.navigator.Stretch = True
        Me.navigator.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.navigator.TabIndex = 1
        Me.navigator.TabStop = False
        Me.navigator.Text = "Navigator"
        Me.navigator.ThemeAware = True
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        Me.BindingNavigatorMoveFirstItem.ThemeAware = True
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        Me.BindingNavigatorMovePreviousItem.ThemeAware = True
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.BeginGroup = True
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.TextBoxWidth = 54
        Me.BindingNavigatorPositionItem.ThemeAware = True
        Me.BindingNavigatorPositionItem.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ThemeAware = True
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.BeginGroup = True
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        Me.BindingNavigatorMoveNextItem.ThemeAware = True
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        Me.BindingNavigatorMoveLastItem.ThemeAware = True
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        Me.BindingNavigatorAddNewItem.ThemeAware = True
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.ThemeAware = True
        '
        'DataView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.navigator)
        Me.Name = "DataView"
        Me.Size = New System.Drawing.Size(803, 382)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.navigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents StyleManagerAmbient1 As DevComponents.DotNetBar.StyleManagerAmbient
    Friend WithEvents grid As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents navigator As DevComponents.DotNetBar.Controls.BindingNavigatorEx
    Friend WithEvents BindingNavigatorAddNewItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorCountItem As DevComponents.DotNetBar.LabelItem
    Friend WithEvents BindingNavigatorDeleteItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorMoveFirstItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorMovePreviousItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorPositionItem As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents BindingNavigatorMoveNextItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorMoveLastItem As DevComponents.DotNetBar.ButtonItem
End Class
