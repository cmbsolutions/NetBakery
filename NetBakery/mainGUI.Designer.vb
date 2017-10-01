<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainGUI
    Inherits DevComponents.DotNetBar.Office2007Form



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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainGUI))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.tvImages = New System.Windows.Forms.ImageList(Me.components)
        Me.tables = New DevComponents.AdvTree.Node()
        Me.tableCount = New DevComponents.AdvTree.Cell()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.views = New DevComponents.AdvTree.Node()
        Me.viewCount = New DevComponents.AdvTree.Cell()
        Me.functions = New DevComponents.AdvTree.Node()
        Me.functionCount = New DevComponents.AdvTree.Cell()
        Me.procedures = New DevComponents.AdvTree.Node()
        Me.procedureCount = New DevComponents.AdvTree.Cell()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.SideBar1 = New DevComponents.DotNetBar.SideBar()
        Me.SideBarPanelItem2 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.txtContextname = New DevComponents.DotNetBar.TextBoxItem()
        Me.sbiEnum = New DevComponents.DotNetBar.SwitchButtonItem()
        Me.sbiRecovery = New DevComponents.DotNetBar.SwitchButtonItem()
        Me.ilSidepanel = New System.Windows.Forms.ImageList(Me.components)
        Me.SideBarPanelItem1 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.txtHost = New DevComponents.DotNetBar.TextBoxItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.txtUser = New DevComponents.DotNetBar.TextBoxItem()
        Me.label3 = New DevComponents.DotNetBar.LabelItem()
        Me.txtPass = New DevComponents.DotNetBar.TextBoxItem()
        Me.sbiSSL = New DevComponents.DotNetBar.SwitchButtonItem()
        Me.cmdConnect = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.cboDatabases = New DevComponents.DotNetBar.ComboBoxItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tvImagesMedium = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'AdvTree1
        '
        Me.AdvTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.AdvTree1.AlternateRowColor = System.Drawing.Color.White
        Me.AdvTree1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.AdvTree1.BackgroundStyle.Class = "TreeBorderKey"
        Me.AdvTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AdvTree1.ColumnsVisible = False
        Me.AdvTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvTree1.DragDropEnabled = False
        Me.AdvTree1.DragDropNodeCopyEnabled = False
        Me.AdvTree1.ExpandButtonSize = New System.Drawing.Size(10, 10)
        Me.AdvTree1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvTree1.ForeColor = System.Drawing.Color.Black
        Me.AdvTree1.GridLinesColor = System.Drawing.Color.Gray
        Me.AdvTree1.ImageList = Me.tvImages
        Me.AdvTree1.Location = New System.Drawing.Point(269, 1)
        Me.AdvTree1.Margin = New System.Windows.Forms.Padding(1)
        Me.AdvTree1.MultiNodeDragCountVisible = False
        Me.AdvTree1.MultiNodeDragDropAllowed = False
        Me.AdvTree1.Name = "AdvTree1"
        Me.AdvTree1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.tables, Me.views, Me.functions, Me.procedures})
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.NodeStyleExpanded = Me.ElementStyle1
        Me.AdvTree1.NodeStyleMouseOver = Me.ElementStyle2
        Me.AdvTree1.NodeStyleSelected = Me.ElementStyle2
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.AdvTree1.Size = New System.Drawing.Size(398, 576)
        Me.AdvTree1.Styles.Add(Me.ElementStyle1)
        Me.AdvTree1.Styles.Add(Me.ElementStyle2)
        Me.AdvTree1.TabIndex = 0
        Me.AdvTree1.Text = "AdvTree1"
        '
        'tvImages
        '
        Me.tvImages.ImageStream = CType(resources.GetObject("tvImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.tvImages.TransparentColor = System.Drawing.Color.Transparent
        Me.tvImages.Images.SetKeyName(0, "table")
        Me.tvImages.Images.SetKeyName(1, "view")
        Me.tvImages.Images.SetKeyName(2, "function")
        Me.tvImages.Images.SetKeyName(3, "procedure")
        Me.tvImages.Images.SetKeyName(4, "datetime")
        Me.tvImages.Images.SetKeyName(5, "char")
        Me.tvImages.Images.SetKeyName(6, "enum")
        Me.tvImages.Images.SetKeyName(7, "float")
        Me.tvImages.Images.SetKeyName(8, "int")
        Me.tvImages.Images.SetKeyName(9, "unknown")
        Me.tvImages.Images.SetKeyName(10, "key")
        '
        'tables
        '
        Me.tables.Cells.Add(Me.tableCount)
        Me.tables.CheckBoxThreeState = True
        Me.tables.CheckBoxVisible = True
        Me.tables.Checked = True
        Me.tables.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tables.DragDropEnabled = False
        Me.tables.Editable = False
        Me.tables.ImageExpandedIndex = 0
        Me.tables.ImageIndex = 0
        Me.tables.Name = "tables"
        Me.tables.StyleSelected = Me.ElementStyle2
        Me.tables.Text = "Tables"
        '
        'tableCount
        '
        Me.tableCount.Editable = False
        Me.tableCount.Name = "tableCount"
        Me.tableCount.StyleMouseOver = Nothing
        Me.tableCount.TextDisplayFormat = "(0)"
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ElementStyle2.BackColorGradientAngle = 90
        Me.ElementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderBottomWidth = 1
        Me.ElementStyle2.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderLeftWidth = 1
        Me.ElementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderRightWidth = 1
        Me.ElementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderTopWidth = 1
        Me.ElementStyle2.CornerDiameter = 4
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Description = "Yellow"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 1
        Me.ElementStyle2.PaddingLeft = 1
        Me.ElementStyle2.PaddingRight = 1
        Me.ElementStyle2.PaddingTop = 1
        Me.ElementStyle2.TextColor = System.Drawing.Color.Black
        '
        'views
        '
        Me.views.Cells.Add(Me.viewCount)
        Me.views.CheckBoxThreeState = True
        Me.views.CheckBoxVisible = True
        Me.views.Checked = True
        Me.views.CheckState = System.Windows.Forms.CheckState.Checked
        Me.views.DragDropEnabled = False
        Me.views.Editable = False
        Me.views.ImageExpandedIndex = 1
        Me.views.ImageIndex = 1
        Me.views.Name = "views"
        Me.views.StyleSelected = Me.ElementStyle2
        Me.views.Text = "Views"
        '
        'viewCount
        '
        Me.viewCount.Editable = False
        Me.viewCount.Name = "viewCount"
        Me.viewCount.StyleMouseOver = Nothing
        Me.viewCount.TextDisplayFormat = "(0)"
        '
        'functions
        '
        Me.functions.Cells.Add(Me.functionCount)
        Me.functions.CheckBoxThreeState = True
        Me.functions.CheckBoxVisible = True
        Me.functions.Checked = True
        Me.functions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.functions.DragDropEnabled = False
        Me.functions.Editable = False
        Me.functions.ImageExpandedIndex = 2
        Me.functions.ImageIndex = 2
        Me.functions.Name = "functions"
        Me.functions.StyleSelected = Me.ElementStyle2
        Me.functions.Text = "Functions"
        '
        'functionCount
        '
        Me.functionCount.Editable = False
        Me.functionCount.Name = "functionCount"
        Me.functionCount.StyleMouseOver = Nothing
        Me.functionCount.TextDisplayFormat = "(0)"
        '
        'procedures
        '
        Me.procedures.Cells.Add(Me.procedureCount)
        Me.procedures.CheckBoxThreeState = True
        Me.procedures.CheckBoxVisible = True
        Me.procedures.Checked = True
        Me.procedures.CheckState = System.Windows.Forms.CheckState.Checked
        Me.procedures.DragDropEnabled = False
        Me.procedures.Editable = False
        Me.procedures.ImageExpandedIndex = 3
        Me.procedures.ImageIndex = 3
        Me.procedures.Name = "procedures"
        Me.procedures.StyleSelected = Me.ElementStyle2
        Me.procedures.Text = "Procedures"
        '
        'procedureCount
        '
        Me.procedureCount.Editable = False
        Me.procedureCount.Name = "procedureCount"
        Me.procedureCount.StyleMouseOver = Nothing
        Me.procedureCount.TextDisplayFormat = "(0)"
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'SideBar1
        '
        Me.SideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.SideBar1.AllowUserCustomize = False
        Me.SideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None
        Me.SideBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideBar1.ExpandedPanel = Me.SideBarPanelItem1
        Me.SideBar1.ForeColor = System.Drawing.Color.White
        Me.SideBar1.Images = Me.ilSidepanel
        Me.SideBar1.Location = New System.Drawing.Point(3, 4)
        Me.SideBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SideBar1.Name = "SideBar1"
        Me.SideBar1.Panels.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideBarPanelItem1, Me.SideBarPanelItem2})
        Me.SideBar1.Size = New System.Drawing.Size(262, 570)
        Me.SideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SideBar1.TabIndex = 1
        Me.SideBar1.Text = "SideBar1"
        Me.SideBar1.UsingSystemColors = True
        '
        'SideBarPanelItem2
        '
        Me.SideBarPanelItem2.CanCustomize = False
        Me.SideBarPanelItem2.FontBold = True
        Me.SideBarPanelItem2.GlobalItem = False
        Me.SideBarPanelItem2.ImageIndex = 1
        Me.SideBarPanelItem2.Name = "SideBarPanelItem2"
        Me.SideBarPanelItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.txtContextname, Me.sbiEnum, Me.sbiRecovery})
        Me.SideBarPanelItem2.Text = "Generator Settings"
        '
        'LabelItem4
        '
        Me.LabelItem4.CanCustomize = False
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 8
        Me.LabelItem4.PaddingTop = 4
        Me.LabelItem4.Stretch = True
        Me.LabelItem4.Text = "Contextname:"
        Me.LabelItem4.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtContextname
        '
        Me.txtContextname.CanCustomize = False
        Me.txtContextname.FocusHighlightEnabled = True
        Me.txtContextname.GlobalItem = False
        Me.txtContextname.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.txtContextname.MaxLength = 50
        Me.txtContextname.Name = "txtContextname"
        Me.txtContextname.Stretch = True
        Me.txtContextname.Text = "MyCustom"
        Me.txtContextname.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'sbiEnum
        '
        Me.sbiEnum.CanCustomize = False
        Me.sbiEnum.GlobalItem = False
        Me.sbiEnum.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.sbiEnum.Margin.Bottom = 8
        Me.sbiEnum.Margin.Right = 3
        Me.sbiEnum.Name = "sbiEnum"
        Me.sbiEnum.OffBackColor = System.Drawing.Color.Red
        Me.sbiEnum.OffText = "NO"
        Me.sbiEnum.OffTextColor = System.Drawing.Color.White
        Me.sbiEnum.OnBackColor = System.Drawing.Color.Lime
        Me.sbiEnum.OnText = "YES"
        Me.sbiEnum.Stretch = True
        Me.sbiEnum.SwitchClickTogglesValue = True
        Me.sbiEnum.Text = "Enum as String"
        Me.sbiEnum.Value = True
        '
        'sbiRecovery
        '
        Me.sbiRecovery.CanCustomize = False
        Me.sbiRecovery.GlobalItem = False
        Me.sbiRecovery.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.sbiRecovery.Margin.Bottom = 8
        Me.sbiRecovery.Margin.Right = 3
        Me.sbiRecovery.Name = "sbiRecovery"
        Me.sbiRecovery.OffBackColor = System.Drawing.Color.Red
        Me.sbiRecovery.OffText = "NO"
        Me.sbiRecovery.OffTextColor = System.Drawing.Color.White
        Me.sbiRecovery.OnBackColor = System.Drawing.Color.Lime
        Me.sbiRecovery.OnText = "YES"
        Me.sbiRecovery.Stretch = True
        Me.sbiRecovery.SwitchClickTogglesValue = True
        Me.sbiRecovery.Text = "Generate recovery"
        '
        'ilSidepanel
        '
        Me.ilSidepanel.ImageStream = CType(resources.GetObject("ilSidepanel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilSidepanel.TransparentColor = System.Drawing.Color.Transparent
        Me.ilSidepanel.Images.SetKeyName(0, "Connectiions.png")
        Me.ilSidepanel.Images.SetKeyName(1, "Gear.png")
        Me.ilSidepanel.Images.SetKeyName(2, "Memory.png")
        Me.ilSidepanel.Images.SetKeyName(3, "Power.png")
        '
        'SideBarPanelItem1
        '
        Me.SideBarPanelItem1.CanCustomize = False
        Me.SideBarPanelItem1.FontBold = True
        Me.SideBarPanelItem1.GlobalItem = False
        Me.SideBarPanelItem1.ImageIndex = 0
        Me.SideBarPanelItem1.Name = "SideBarPanelItem1"
        Me.SideBarPanelItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.txtHost, Me.LabelItem1, Me.txtUser, Me.label3, Me.txtPass, Me.sbiSSL, Me.cmdConnect, Me.LabelItem2, Me.cboDatabases})
        Me.SideBarPanelItem1.Text = "Database Connection"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingTop = 4
        Me.LabelItem3.Text = "Host:"
        Me.LabelItem3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtHost
        '
        Me.txtHost.CanCustomize = False
        Me.txtHost.GlobalItem = False
        Me.txtHost.MaxLength = 25
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Stretch = True
        Me.txtHost.Text = "localhost"
        Me.txtHost.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingTop = 4
        Me.LabelItem1.Text = "User:"
        Me.LabelItem1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtUser
        '
        Me.txtUser.CanCustomize = False
        Me.txtUser.GlobalItem = False
        Me.txtUser.MaxLength = 25
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Stretch = True
        Me.txtUser.Text = "root"
        Me.txtUser.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'label3
        '
        Me.label3.CanCustomize = False
        Me.label3.GlobalItem = False
        Me.label3.Name = "label3"
        Me.label3.PaddingTop = 4
        Me.label3.Stretch = True
        Me.label3.Text = "Pass:"
        Me.label3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtPass
        '
        Me.txtPass.CanCustomize = False
        Me.txtPass.MaxLength = 32
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(215)
        Me.txtPass.Text = "playstation2!"
        Me.txtPass.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'sbiSSL
        '
        Me.sbiSSL.CanCustomize = False
        Me.sbiSSL.GlobalItem = False
        Me.sbiSSL.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.sbiSSL.Margin.Bottom = 8
        Me.sbiSSL.Margin.Right = 3
        Me.sbiSSL.Name = "sbiSSL"
        Me.sbiSSL.OffBackColor = System.Drawing.Color.Red
        Me.sbiSSL.OffTextColor = System.Drawing.Color.White
        Me.sbiSSL.OnBackColor = System.Drawing.Color.Lime
        Me.sbiSSL.Stretch = True
        Me.sbiSSL.SwitchClickTogglesValue = True
        Me.sbiSSL.Text = "SSL Mode required"
        '
        'cmdConnect
        '
        Me.cmdConnect.AutoCollapseOnClick = False
        Me.cmdConnect.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.cmdConnect.CanCustomize = False
        Me.cmdConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdConnect.FontBold = True
        Me.cmdConnect.GlobalItem = False
        Me.cmdConnect.Icon = CType(resources.GetObject("cmdConnect.Icon"), System.Drawing.Icon)
        Me.cmdConnect.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.Fade
        Me.cmdConnect.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.cmdConnect.Stretch = True
        Me.cmdConnect.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.cmdConnect.Text = "Connect"
        '
        'LabelItem2
        '
        Me.LabelItem2.CanCustomize = False
        Me.LabelItem2.DividerStyle = True
        Me.LabelItem2.GlobalItem = False
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingTop = 4
        Me.LabelItem2.Stretch = True
        Me.LabelItem2.Text = "Database"
        Me.LabelItem2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cboDatabases
        '
        Me.cboDatabases.CanCustomize = False
        Me.cboDatabases.ComboWidth = 200
        Me.cboDatabases.DropDownHeight = 106
        Me.cboDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboDatabases.GlobalItem = False
        Me.cboDatabases.ItemHeight = 22
        Me.cboDatabases.Name = "cboDatabases"
        Me.cboDatabases.Stretch = True
        Me.cboDatabases.Text = "Choose a database..."
        Me.cboDatabases.WatermarkEnabled = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.SideBar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AdvTree1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1503, 578)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridViewX1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(671, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(829, 572)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewX1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 30)
        Me.DataGridViewX1.Margin = New System.Windows.Forms.Padding(0)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewX1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewX1.Size = New System.Drawing.Size(829, 542)
        Me.DataGridViewX1.TabIndex = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX1.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.LabelX1.BackgroundStyle.BackColorGradientAngle = 90
        Me.LabelX1.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.LabelX1.BackgroundStyle.BackgroundImage = Global.NetBakery.My.Resources.Resources.RibbonGeometry
        Me.LabelX1.BackgroundStyle.BackgroundImageAlpha = CType(150, Byte)
        Me.LabelX1.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile
        Me.LabelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.LabelX1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.BackgroundStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Diagonal
        Me.LabelX1.BackgroundStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Diagonal
        Me.LabelX1.BackgroundStyle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.LabelX1.BackgroundStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText
        Me.LabelX1.BackgroundStyle.TextShadowColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemSeparatorShade
        Me.LabelX1.BackgroundStyle.TextShadowOffset = New System.Drawing.Point(1, 1)
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelX1.FontBold = True
        Me.LabelX1.Location = New System.Drawing.Point(0, 0)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(829, 30)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "..."
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'tvImagesMedium
        '
        Me.tvImagesMedium.ImageStream = CType(resources.GetObject("tvImagesMedium.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.tvImagesMedium.TransparentColor = System.Drawing.Color.Transparent
        Me.tvImagesMedium.Images.SetKeyName(0, "table.png")
        Me.tvImagesMedium.Images.SetKeyName(1, "view.png")
        Me.tvImagesMedium.Images.SetKeyName(2, "function.png")
        Me.tvImagesMedium.Images.SetKeyName(3, "procedure.png")
        '
        'mainGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BackgroundImage = Global.NetBakery.My.Resources.Resources.RibbonGeometry
        Me.BottomLeftCornerSize = 14
        Me.BottomRightCornerSize = 0
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(1503, 578)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "mainGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mainGUI"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 14
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents tables As DevComponents.AdvTree.Node
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents tvImages As ImageList
    Friend WithEvents views As DevComponents.AdvTree.Node
    Friend WithEvents functions As DevComponents.AdvTree.Node
    Friend WithEvents procedures As DevComponents.AdvTree.Node
    Friend WithEvents SideBar1 As DevComponents.DotNetBar.SideBar
    Friend WithEvents SideBarPanelItem1 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtHost As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtUser As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents label3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtPass As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents cmdConnect As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cboDatabases As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents sbiSSL As DevComponents.DotNetBar.SwitchButtonItem
    Friend WithEvents SideBarPanelItem2 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents ilSidepanel As ImageList
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents tableCount As DevComponents.AdvTree.Cell
    Friend WithEvents viewCount As DevComponents.AdvTree.Cell
    Friend WithEvents functionCount As DevComponents.AdvTree.Cell
    Friend WithEvents procedureCount As DevComponents.AdvTree.Cell
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtContextname As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents sbiEnum As DevComponents.DotNetBar.SwitchButtonItem
    Friend WithEvents sbiRecovery As DevComponents.DotNetBar.SwitchButtonItem
    Friend WithEvents tvImagesMedium As ImageList
End Class
