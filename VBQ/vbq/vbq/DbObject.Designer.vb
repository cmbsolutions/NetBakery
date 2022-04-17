<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DbObject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DbObject))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pRight = New System.Windows.Forms.Panel()
        Me.pCenter = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lTitle = New DevComponents.DotNetBar.LabelX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lFields = New DevComponents.DotNetBar.ListBoxAdv()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ItemTemplate = New DevComponents.DotNetBar.ListBoxItem()
        Me.normalFieldTemplate = New DevComponents.DotNetBar.LabelItem()
        Me.pLeft = New System.Windows.Forms.Panel()
        Me.Field = New DevComponents.DotNetBar.ListBoxItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pRight, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pCenter, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lFields, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pLeft, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(150, 150)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pRight
        '
        Me.pRight.BackColor = System.Drawing.Color.SlateGray
        Me.pRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.pRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pRight.Location = New System.Drawing.Point(125, 149)
        Me.pRight.Margin = New System.Windows.Forms.Padding(0)
        Me.pRight.Name = "pRight"
        Me.pRight.Size = New System.Drawing.Size(24, 1)
        Me.pRight.TabIndex = 0
        '
        'pCenter
        '
        Me.pCenter.BackColor = System.Drawing.Color.SlateGray
        Me.TableLayoutPanel1.SetColumnSpan(Me.pCenter, 2)
        Me.pCenter.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.pCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pCenter.Location = New System.Drawing.Point(0, 149)
        Me.pCenter.Margin = New System.Windows.Forms.Padding(0)
        Me.pCenter.Name = "pCenter"
        Me.pCenter.Size = New System.Drawing.Size(125, 1)
        Me.pCenter.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.vbq.My.Resources.Resources.head_left
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(24, 24)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.vbq.My.Resources.Resources.head_mid
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lTitle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(24, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(101, 24)
        Me.Panel2.TabIndex = 0
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
        Me.lTitle.FontBold = True
        Me.lTitle.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lTitle.Location = New System.Drawing.Point(0, 0)
        Me.lTitle.Name = "lTitle"
        Me.lTitle.Size = New System.Drawing.Size(101, 24)
        Me.lTitle.TabIndex = 0
        Me.lTitle.Text = "Tablename"
        Me.lTitle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.vbq.My.Resources.Resources.head_right
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(125, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(24, 24)
        Me.Panel3.TabIndex = 0
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.lFields, 3)
        Me.lFields.ContainerControlProcessDialogKey = True
        Me.lFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lFields.DragDropSupport = True
        Me.lFields.EnableDragDrop = True
        Me.lFields.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lFields.Images = Me.ImageList1
        Me.lFields.Items.Add(Me.ItemTemplate)
        Me.lFields.ItemSpacing = 0
        Me.lFields.ItemTemplate = Me.normalFieldTemplate
        Me.lFields.Location = New System.Drawing.Point(0, 24)
        Me.lFields.Margin = New System.Windows.Forms.Padding(0)
        Me.lFields.Name = "lFields"
        Me.lFields.Size = New System.Drawing.Size(149, 125)
        Me.lFields.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lFields.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "key.png")
        Me.ImageList1.Images.SetKeyName(1, "link.png")
        '
        'ItemTemplate
        '
        Me.ItemTemplate.AutoCollapseOnClick = False
        Me.ItemTemplate.CanCustomize = False
        Me.ItemTemplate.Image = Global.vbq.My.Resources.Resources.key
        Me.ItemTemplate.IsSelected = True
        Me.ItemTemplate.Name = "ItemTemplate"
        Me.ItemTemplate.ShowSubItems = False
        Me.ItemTemplate.Text = "<span width=""20px""> </span><font color=""WhiteSmoke""><b>{name}</b></font> <font co" &
    "lor=""DarkGray"">: {[type]}</font>"
        Me.ItemTemplate.Visible = False
        '
        'normalFieldTemplate
        '
        Me.normalFieldTemplate.CanCustomize = False
        Me.normalFieldTemplate.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.normalFieldTemplate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.normalFieldTemplate.GlobalItem = False
        Me.normalFieldTemplate.Name = "normalFieldTemplate"
        Me.normalFieldTemplate.PaddingLeft = 20
        Me.normalFieldTemplate.ShowSubItems = False
        Me.normalFieldTemplate.Text = "<font color=""WhiteSmoke""><b>{{fieldname}}</b></font> <font color=""DarkGrey"">:{{fi" &
    "eldtype}}</font>"
        '
        'pLeft
        '
        Me.pLeft.BackColor = System.Drawing.Color.SlateGray
        Me.pLeft.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.pLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pLeft.Location = New System.Drawing.Point(149, 0)
        Me.pLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.pLeft.Name = "pLeft"
        Me.TableLayoutPanel1.SetRowSpan(Me.pLeft, 3)
        Me.pLeft.Size = New System.Drawing.Size(1, 150)
        Me.pLeft.TabIndex = 3
        '
        'Field
        '
        Me.Field.AutoCollapseOnClick = False
        Me.Field.CanCustomize = False
        Me.Field.Image = Global.vbq.My.Resources.Resources.key
        Me.Field.Name = "Field"
        Me.Field.ShowSubItems = False
        Me.Field.Text = "<b>example_id</b> <font color=""DarkGray"">: int(10)</font>"
        Me.Field.TextColor = System.Drawing.Color.WhiteSmoke
        Me.Field.ThemeAware = True
        '
        'DbObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DbObject"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lFields As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents Field As DevComponents.DotNetBar.ListBoxItem
    Friend WithEvents normalFieldTemplate As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pRight As Panel
    Friend WithEvents pCenter As Panel
    Friend WithEvents lTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ItemTemplate As DevComponents.DotNetBar.ListBoxItem
    Friend WithEvents pLeft As Panel
End Class
