<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DbTableObject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DbTableObject))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pBottom = New System.Windows.Forms.Panel()
        Me.pLeft = New System.Windows.Forms.Panel()
        Me.pBottomRight = New System.Windows.Forms.Panel()
        Me.pRight = New System.Windows.Forms.Panel()
        Me.lTitle = New DevComponents.DotNetBar.LabelX()
        Me.lFields = New DevComponents.DotNetBar.ListBoxAdv()
        Me.ItemTemplate = New DevComponents.DotNetBar.ListBoxItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pBottom, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pLeft, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pBottomRight, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pRight, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lTitle, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lFields, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 255)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pBottom
        '
        Me.pBottom.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.pBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pBottom.Location = New System.Drawing.Point(3, 252)
        Me.pBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.pBottom.Name = "pBottom"
        Me.pBottom.Size = New System.Drawing.Size(194, 3)
        Me.pBottom.TabIndex = 0
        '
        'pLeft
        '
        Me.pLeft.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.pLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pLeft.Location = New System.Drawing.Point(0, 0)
        Me.pLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.pLeft.Name = "pLeft"
        Me.TableLayoutPanel1.SetRowSpan(Me.pLeft, 3)
        Me.pLeft.Size = New System.Drawing.Size(3, 255)
        Me.pLeft.TabIndex = 4
        '
        'pBottomRight
        '
        Me.pBottomRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.pBottomRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pBottomRight.Location = New System.Drawing.Point(197, 252)
        Me.pBottomRight.Margin = New System.Windows.Forms.Padding(0)
        Me.pBottomRight.Name = "pBottomRight"
        Me.pBottomRight.Size = New System.Drawing.Size(3, 3)
        Me.pBottomRight.TabIndex = 0
        '
        'pRight
        '
        Me.pRight.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.pRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pRight.Location = New System.Drawing.Point(197, 0)
        Me.pRight.Margin = New System.Windows.Forms.Padding(0)
        Me.pRight.Name = "pRight"
        Me.TableLayoutPanel1.SetRowSpan(Me.pRight, 2)
        Me.pRight.Size = New System.Drawing.Size(3, 252)
        Me.pRight.TabIndex = 0
        '
        'lTitle
        '
        Me.lTitle.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lTitle.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.lTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lTitle.BackgroundStyle.TextColor = System.Drawing.Color.WhiteSmoke
        Me.lTitle.BackgroundStyle.TextShadowColor = System.Drawing.Color.DimGray
        Me.lTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lTitle.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTitle.FontBold = True
        Me.lTitle.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lTitle.Location = New System.Drawing.Point(6, 3)
        Me.lTitle.Name = "lTitle"
        Me.lTitle.Size = New System.Drawing.Size(188, 24)
        Me.lTitle.TabIndex = 3
        Me.lTitle.Text = "Tablename"
        Me.lTitle.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lTitle.WordWrap = True
        '
        'lFields
        '
        Me.lFields.AllowDrop = True
        Me.lFields.AllowExternalDrop = True
        Me.lFields.AutoScroll = True
        Me.lFields.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(48, Byte), Integer))
        '
        '
        '
        Me.lFields.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lFields.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lFields.BackgroundStyle.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarFloatingBorder
        Me.lFields.BackgroundStyle.BorderBottomWidth = 1
        Me.lFields.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lFields.BackgroundStyle.BorderLeftColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarFloatingBorder
        Me.lFields.BackgroundStyle.BorderLeftWidth = 1
        Me.lFields.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lFields.BackgroundStyle.BorderRightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarFloatingBorder
        Me.lFields.BackgroundStyle.BorderRightWidth = 1
        Me.lFields.BackgroundStyle.BorderTopWidth = 1
        Me.lFields.BackgroundStyle.Class = "ListBoxAdv"
        Me.lFields.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lFields.BackgroundStyle.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lFields.BackgroundStyle.TextColor = System.Drawing.Color.WhiteSmoke
        Me.lFields.CausesValidation = False
        Me.lFields.ContainerControlProcessDialogKey = True
        Me.lFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lFields.DragDropSupport = True
        Me.lFields.EnableDragDrop = True
        Me.lFields.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lFields.Items.Add(Me.ItemTemplate)
        Me.lFields.ItemSpacing = 0
        Me.lFields.Location = New System.Drawing.Point(3, 30)
        Me.lFields.Margin = New System.Windows.Forms.Padding(0)
        Me.lFields.Name = "lFields"
        Me.lFields.Size = New System.Drawing.Size(194, 222)
        Me.lFields.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lFields.TabIndex = 2
        '
        'ItemTemplate
        '
        Me.ItemTemplate.AutoCollapseOnClick = False
        Me.ItemTemplate.BackColors = New System.Drawing.Color() {System.Drawing.Color.MistyRose, System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))}
        Me.ItemTemplate.CanCustomize = False
        Me.ItemTemplate.Image = Global.vbq.My.Resources.Resources.key
        Me.ItemTemplate.IsSelected = True
        Me.ItemTemplate.Name = "ItemTemplate"
        Me.ItemTemplate.ShowSubItems = False
        Me.ItemTemplate.Text = "<span width=""20px""> </span><font color=""WhiteSmoke""><b>{name}</b></font> <font co" &
    "lor=""DarkGray"">: {[type]}</font>"
        Me.ItemTemplate.ThemeAware = True
        Me.ItemTemplate.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "key.png")
        Me.ImageList1.Images.SetKeyName(1, "link.png")
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'DbTableObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(100, 150)
        Me.Name = "DbTableObject"
        Me.Size = New System.Drawing.Size(200, 255)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lFields As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents ItemTemplate As DevComponents.DotNetBar.ListBoxItem
    Friend WithEvents lTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents pBottom As Panel
    Friend WithEvents pLeft As Panel
    Friend WithEvents pBottomRight As Panel
    Friend WithEvents pRight As Panel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
End Class
