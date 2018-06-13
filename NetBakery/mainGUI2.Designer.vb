<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainGUI2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainGUI2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dnbStyleManagerAmbient = New DevComponents.DotNetBar.StyleManagerAmbient(Me.components)
        Me.dnbStyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.CheckBoxItem1 = New DevComponents.DotNetBar.CheckBoxItem()
        Me.dnbBarManager = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
        Me.DockSite4 = New DevComponents.DotNetBar.DockSite()
        Me.barLogging = New DevComponents.DotNetBar.Bar()
        Me.PanelDockContainer2 = New DevComponents.DotNetBar.PanelDockContainer()
        Me.txtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DockContainerItem2 = New DevComponents.DotNetBar.DockContainerItem()
        Me.DockSite9 = New DevComponents.DotNetBar.DockSite()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.pdcProjectSettings = New DevComponents.DotNetBar.PanelDockContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtOutputFolder = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtProjectFolder = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtProjectName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cboOutputType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ilDatabaseObjects = New System.Windows.Forms.ImageList(Me.components)
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.pdcObjectInfo = New DevComponents.DotNetBar.PanelDockContainer()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.dgvFields = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.scGeneratedMapping = New ScintillaNET.Scintilla()
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.scGeneratedModel = New ScintillaNET.Scintilla()
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.dgvForeignKeys = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.pdcCodePreview = New DevComponents.DotNetBar.PanelDockContainer()
        Me.scCodePreview = New ScintillaNET.Scintilla()
        Me.dcProjectSettings = New DevComponents.DotNetBar.DockContainerItem()
        Me.dcObjectInfo = New DevComponents.DotNetBar.DockContainerItem()
        Me.dcCodePreview = New DevComponents.DotNetBar.DockContainerItem()
        Me.ilDark = New System.Windows.Forms.ImageList(Me.components)
        Me.DockSite1 = New DevComponents.DotNetBar.DockSite()
        Me.BarDatabases = New DevComponents.DotNetBar.Bar()
        Me.PanelDockContainer1 = New DevComponents.DotNetBar.PanelDockContainer()
        Me.advtreeDatabases = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNewConnection = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditConnection = New DevComponents.DotNetBar.ButtonItem()
        Me.btnConnect = New DevComponents.DotNetBar.ButtonItem()
        Me.cboConnecions = New DevComponents.DotNetBar.ComboBoxItem()
        Me.DockContainerItem1 = New DevComponents.DotNetBar.DockContainerItem()
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.PanelDockContainer3 = New DevComponents.DotNetBar.PanelDockContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSearchOutput = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.advtreeOutputExplorer = New DevComponents.AdvTree.AdvTree()
        Me.ilExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.nModels = New DevComponents.AdvTree.Node()
        Me.mapMapping = New DevComponents.AdvTree.Node()
        Me.tplMapping = New DevComponents.AdvTree.Node()
        Me.mapStoreCommands = New DevComponents.AdvTree.Node()
        Me.mapStoreCommandModels = New DevComponents.AdvTree.Node()
        Me.tplFunction = New DevComponents.AdvTree.Node()
        Me.tplProcedure = New DevComponents.AdvTree.Node()
        Me.nContext = New DevComponents.AdvTree.Node()
        Me.nStoreCommands = New DevComponents.AdvTree.Node()
        Me.tplModel = New DevComponents.AdvTree.Node()
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.btnHomeOutputExplorer = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshOutputExplorer = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSaveLayout = New DevComponents.DotNetBar.ButtonItem()
        Me.DockContainerItem3 = New DevComponents.DotNetBar.DockContainerItem()
        Me.DockSite8 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite5 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite6 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite7 = New DevComponents.DotNetBar.DockSite()
        Me.barMainMenu = New DevComponents.DotNetBar.Bar()
        Me.btnFile = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSettings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFile_Close = New DevComponents.DotNetBar.ButtonItem()
        Me.DockSite3 = New DevComponents.DotNetBar.DockSite()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.DockSite4.SuspendLayout()
        CType(Me.barLogging, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barLogging.SuspendLayout()
        Me.PanelDockContainer2.SuspendLayout()
        Me.DockSite9.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar4.SuspendLayout()
        Me.pdcProjectSettings.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pdcObjectInfo.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.dgvFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.dgvForeignKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pdcCodePreview.SuspendLayout()
        Me.DockSite1.SuspendLayout()
        CType(Me.BarDatabases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarDatabases.SuspendLayout()
        Me.PanelDockContainer1.SuspendLayout()
        CType(Me.advtreeDatabases, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockSite2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.PanelDockContainer3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.advtreeOutputExplorer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockSite7.SuspendLayout()
        CType(Me.barMainMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dnbStyleManager
        '
        Me.dnbStyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.dnbStyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'CheckBoxItem1
        '
        Me.CheckBoxItem1.Name = "CheckBoxItem1"
        Me.CheckBoxItem1.Text = "CheckBoxItem1"
        '
        'dnbBarManager
        '
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.dnbBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins)
        Me.dnbBarManager.BottomDockSite = Me.DockSite4
        Me.dnbBarManager.EnableFullSizeDock = False
        Me.dnbBarManager.FillDockSite = Me.DockSite9
        Me.dnbBarManager.Images = Me.ilDark
        Me.dnbBarManager.LeftDockSite = Me.DockSite1
        Me.dnbBarManager.MenuDropShadow = DevComponents.DotNetBar.eMenuDropShadow.Show
        Me.dnbBarManager.ParentForm = Me
        Me.dnbBarManager.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.Fade
        Me.dnbBarManager.RightDockSite = Me.DockSite2
        Me.dnbBarManager.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dnbBarManager.ToolbarBottomDockSite = Me.DockSite8
        Me.dnbBarManager.ToolbarLeftDockSite = Me.DockSite5
        Me.dnbBarManager.ToolbarRightDockSite = Me.DockSite6
        Me.dnbBarManager.ToolbarTopDockSite = Me.DockSite7
        Me.dnbBarManager.TopDockSite = Me.DockSite3
        Me.dnbBarManager.UseHook = True
        '
        'DockSite4
        '
        Me.DockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite4.Controls.Add(Me.barLogging)
        Me.DockSite4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite4.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.barLogging, 1464, 89), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Vertical)
        Me.DockSite4.Location = New System.Drawing.Point(0, 469)
        Me.DockSite4.Name = "DockSite4"
        Me.DockSite4.Size = New System.Drawing.Size(1464, 92)
        Me.DockSite4.TabIndex = 3
        Me.DockSite4.TabStop = False
        '
        'barLogging
        '
        Me.barLogging.AccessibleDescription = "DotNetBar Bar (barLogging)"
        Me.barLogging.AccessibleName = "DotNetBar Bar"
        Me.barLogging.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.barLogging.AntiAlias = True
        Me.barLogging.AutoHide = True
        Me.barLogging.AutoSyncBarCaption = True
        Me.barLogging.CanCustomize = False
        Me.barLogging.CloseSingleTab = True
        Me.barLogging.Controls.Add(Me.PanelDockContainer2)
        Me.barLogging.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barLogging.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption
        Me.barLogging.IsMaximized = False
        Me.barLogging.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem2})
        Me.barLogging.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
        Me.barLogging.Location = New System.Drawing.Point(0, 3)
        Me.barLogging.Name = "barLogging"
        Me.barLogging.Size = New System.Drawing.Size(1464, 89)
        Me.barLogging.Stretch = True
        Me.barLogging.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.barLogging.TabIndex = 0
        Me.barLogging.TabStop = False
        Me.barLogging.Text = "Logging"
        '
        'PanelDockContainer2
        '
        Me.PanelDockContainer2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelDockContainer2.Controls.Add(Me.txtLog)
        Me.PanelDockContainer2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelDockContainer2.Location = New System.Drawing.Point(3, 23)
        Me.PanelDockContainer2.Name = "PanelDockContainer2"
        Me.PanelDockContainer2.Size = New System.Drawing.Size(1458, 63)
        Me.PanelDockContainer2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelDockContainer2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelDockContainer2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.PanelDockContainer2.Style.GradientAngle = 90
        Me.PanelDockContainer2.TabIndex = 0
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtLog.Border.Class = "TextBoxBorder"
        Me.txtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLog.DisabledBackColor = System.Drawing.Color.Black
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.White
        Me.txtLog.Location = New System.Drawing.Point(0, 0)
        Me.txtLog.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLog.MaxLength = 2147483647
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.PreventEnterBeep = True
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(1458, 63)
        Me.txtLog.TabIndex = 0
        '
        'DockContainerItem2
        '
        Me.DockContainerItem2.Control = Me.PanelDockContainer2
        Me.DockContainerItem2.Name = "DockContainerItem2"
        Me.DockContainerItem2.Text = "Logging"
        '
        'DockSite9
        '
        Me.DockSite9.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite9.Controls.Add(Me.Bar4)
        Me.DockSite9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockSite9.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.Bar4, 912, 443), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Horizontal)
        Me.DockSite9.Location = New System.Drawing.Point(272, 26)
        Me.DockSite9.Name = "DockSite9"
        Me.DockSite9.Size = New System.Drawing.Size(912, 443)
        Me.DockSite9.TabIndex = 8
        Me.DockSite9.TabStop = False
        '
        'Bar4
        '
        Me.Bar4.AccessibleDescription = "DotNetBar Bar (Bar4)"
        Me.Bar4.AccessibleName = "DotNetBar Bar"
        Me.Bar4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.Bar4.AlwaysDisplayDockTab = True
        Me.Bar4.AntiAlias = True
        Me.Bar4.CanCustomize = False
        Me.Bar4.CanDockBottom = False
        Me.Bar4.CanDockDocument = True
        Me.Bar4.CanDockLeft = False
        Me.Bar4.CanDockRight = False
        Me.Bar4.CanDockTop = False
        Me.Bar4.CanHide = True
        Me.Bar4.CanUndock = False
        Me.Bar4.Controls.Add(Me.pdcProjectSettings)
        Me.Bar4.Controls.Add(Me.pdcObjectInfo)
        Me.Bar4.Controls.Add(Me.pdcCodePreview)
        Me.Bar4.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.dcProjectSettings, Me.dcObjectInfo, Me.dcCodePreview})
        Me.Bar4.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
        Me.Bar4.Location = New System.Drawing.Point(0, 0)
        Me.Bar4.Margin = New System.Windows.Forms.Padding(0)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.SelectedDockTab = 0
        Me.Bar4.Size = New System.Drawing.Size(912, 443)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 0
        Me.Bar4.TabNavigation = True
        Me.Bar4.TabStop = False
        '
        'pdcProjectSettings
        '
        Me.pdcProjectSettings.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pdcProjectSettings.Controls.Add(Me.TableLayoutPanel2)
        Me.pdcProjectSettings.DisabledBackColor = System.Drawing.Color.Empty
        Me.pdcProjectSettings.Location = New System.Drawing.Point(3, 28)
        Me.pdcProjectSettings.Name = "pdcProjectSettings"
        Me.pdcProjectSettings.Size = New System.Drawing.Size(906, 412)
        Me.pdcProjectSettings.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pdcProjectSettings.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pdcProjectSettings.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.pdcProjectSettings.Style.GradientAngle = 90
        Me.pdcProjectSettings.TabIndex = 10
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.txtOutputFolder, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtProjectFolder, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX5, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtProjectName, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboOutputType, 1, 3)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 11)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(900, 261)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtOutputFolder.Border.Class = "TextBoxBorder"
        Me.txtOutputFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOutputFolder.ButtonCustom.Image = Global.NetBakery.My.Resources.Resources.folder_search
        Me.txtOutputFolder.ButtonCustom.Tooltip = "Search output folder"
        Me.txtOutputFolder.ButtonCustom.Visible = True
        Me.txtOutputFolder.DisabledBackColor = System.Drawing.Color.Black
        Me.txtOutputFolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutputFolder.ForeColor = System.Drawing.Color.White
        Me.txtOutputFolder.Location = New System.Drawing.Point(153, 67)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.PreventEnterBeep = True
        Me.txtOutputFolder.Size = New System.Drawing.Size(294, 25)
        Me.txtOutputFolder.TabIndex = 5
        Me.txtOutputFolder.WordWrap = False
        '
        'txtProjectFolder
        '
        Me.txtProjectFolder.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtProjectFolder.Border.Class = "TextBoxBorder"
        Me.txtProjectFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtProjectFolder.ButtonCustom.Image = Global.NetBakery.My.Resources.Resources.folder_search
        Me.txtProjectFolder.ButtonCustom.Tooltip = "Search project folder"
        Me.txtProjectFolder.ButtonCustom.Visible = True
        Me.txtProjectFolder.DisabledBackColor = System.Drawing.Color.Black
        Me.txtProjectFolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProjectFolder.ForeColor = System.Drawing.Color.White
        Me.txtProjectFolder.Location = New System.Drawing.Point(153, 35)
        Me.txtProjectFolder.Name = "txtProjectFolder"
        Me.txtProjectFolder.PreventEnterBeep = True
        Me.txtProjectFolder.Size = New System.Drawing.Size(294, 25)
        Me.txtProjectFolder.TabIndex = 5
        Me.txtProjectFolder.WordWrap = False
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.FontBold = True
        Me.LabelX5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelX5.Location = New System.Drawing.Point(3, 131)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(114, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX5.TabIndex = 5
        Me.LabelX5.Text = "Output type:"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.FontBold = True
        Me.LabelX4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelX4.Location = New System.Drawing.Point(3, 99)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(114, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Output type"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelX3.FontBold = True
        Me.LabelX3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelX3.Location = New System.Drawing.Point(3, 67)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(144, 26)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "Output location"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelX1.FontBold = True
        Me.LabelX1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelX1.Location = New System.Drawing.Point(3, 35)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(144, 26)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Project location"
        '
        'txtProjectName
        '
        Me.txtProjectName.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtProjectName.Border.Class = "TextBoxBorder"
        Me.txtProjectName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtProjectName.DisabledBackColor = System.Drawing.Color.Black
        Me.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProjectName.ForeColor = System.Drawing.Color.White
        Me.txtProjectName.Location = New System.Drawing.Point(153, 3)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.PreventEnterBeep = True
        Me.txtProjectName.Size = New System.Drawing.Size(294, 25)
        Me.txtProjectName.TabIndex = 2
        Me.txtProjectName.WatermarkText = "Enter projectname..."
        Me.txtProjectName.WordWrap = False
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelX2.FontBold = True
        Me.LabelX2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(144, 26)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Projectname"
        '
        'cboOutputType
        '
        Me.cboOutputType.DisplayMember = "Text"
        Me.cboOutputType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboOutputType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboOutputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOutputType.ForeColor = System.Drawing.Color.White
        Me.cboOutputType.FormattingEnabled = True
        Me.cboOutputType.Images = Me.ilDatabaseObjects
        Me.cboOutputType.ItemHeight = 20
        Me.cboOutputType.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cboOutputType.Location = New System.Drawing.Point(153, 99)
        Me.cboOutputType.Name = "cboOutputType"
        Me.cboOutputType.Size = New System.Drawing.Size(294, 26)
        Me.cboOutputType.Sorted = True
        Me.cboOutputType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboOutputType.TabIndex = 0
        Me.cboOutputType.WatermarkText = "Please select..."
        '
        'ilDatabaseObjects
        '
        Me.ilDatabaseObjects.ImageStream = CType(resources.GetObject("ilDatabaseObjects.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilDatabaseObjects.TransparentColor = System.Drawing.Color.Transparent
        Me.ilDatabaseObjects.Images.SetKeyName(0, "table.png")
        Me.ilDatabaseObjects.Images.SetKeyName(1, "view.png")
        Me.ilDatabaseObjects.Images.SetKeyName(2, "function.png")
        Me.ilDatabaseObjects.Images.SetKeyName(3, "procedure.png")
        Me.ilDatabaseObjects.Images.SetKeyName(4, "data_field.png")
        Me.ilDatabaseObjects.Images.SetKeyName(5, "action_log.png")
        Me.ilDatabaseObjects.Images.SetKeyName(6, "table_key.png")
        Me.ilDatabaseObjects.Images.SetKeyName(7, "script_visual_studio.png")
        Me.ilDatabaseObjects.Images.SetKeyName(8, "script_php.png")
        Me.ilDatabaseObjects.Images.SetKeyName(9, "data_table.png")
        Me.ilDatabaseObjects.Images.SetKeyName(10, "map.png")
        '
        'ComboItem1
        '
        Me.ComboItem1.ImageIndex = 8
        Me.ComboItem1.Text = "CakePHP 2.x"
        Me.ComboItem1.Value = "php"
        '
        'ComboItem2
        '
        Me.ComboItem2.ImageIndex = 7
        Me.ComboItem2.Text = "vb.NET"
        Me.ComboItem2.Value = "net"
        '
        'pdcObjectInfo
        '
        Me.pdcObjectInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pdcObjectInfo.Controls.Add(Me.TabControl1)
        Me.pdcObjectInfo.DisabledBackColor = System.Drawing.Color.Empty
        Me.pdcObjectInfo.Location = New System.Drawing.Point(3, 28)
        Me.pdcObjectInfo.Name = "pdcObjectInfo"
        Me.pdcObjectInfo.Size = New System.Drawing.Size(906, 412)
        Me.pdcObjectInfo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pdcObjectInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pdcObjectInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.pdcObjectInfo.Style.GradientAngle = 90
        Me.pdcObjectInfo.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.CloseButtonOnTabsAlwaysDisplayed = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ForeColor = System.Drawing.Color.White
        Me.TabControl1.ImageList = Me.ilDatabaseObjects
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.MultiLinePanelAlignSelectedTab = False
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(906, 412)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Tabs.Add(Me.TabItem3)
        Me.TabControl1.Tabs.Add(Me.TabItem4)
        Me.TabControl1.Text = "TabControl1"
        Me.TabControl1.ThemeAware = True
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.dgvFields)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(906, 385)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = -90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'dgvFields
        '
        Me.dgvFields.AllowUserToAddRows = False
        Me.dgvFields.AllowUserToDeleteRows = False
        Me.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFields.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFields.GridColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.dgvFields.Location = New System.Drawing.Point(1, 1)
        Me.dgvFields.Name = "dgvFields"
        Me.dgvFields.Size = New System.Drawing.Size(904, 383)
        Me.dgvFields.TabIndex = 0
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.CloseButtonVisible = False
        Me.TabItem1.ImageIndex = 4
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Fields"
        Me.TabItem1.Tooltip = "Fields"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.scGeneratedMapping)
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(906, 385)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = -90
        Me.TabControlPanel4.TabIndex = 13
        Me.TabControlPanel4.TabItem = Me.TabItem4
        '
        'scGeneratedMapping
        '
        Me.scGeneratedMapping.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.scGeneratedMapping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scGeneratedMapping.FontQuality = ScintillaNET.FontQuality.AntiAliased
        Me.scGeneratedMapping.IndentationGuides = ScintillaNET.IndentView.LookBoth
        Me.scGeneratedMapping.Lexer = ScintillaNET.Lexer.Null
        Me.scGeneratedMapping.Location = New System.Drawing.Point(1, 1)
        Me.scGeneratedMapping.Margin = New System.Windows.Forms.Padding(0)
        Me.scGeneratedMapping.Name = "scGeneratedMapping"
        Me.scGeneratedMapping.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.scGeneratedMapping.Size = New System.Drawing.Size(904, 383)
        Me.scGeneratedMapping.TabIndex = 1
        Me.scGeneratedMapping.UseTabs = True
        '
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel4
        Me.TabItem4.ImageIndex = 10
        Me.TabItem4.Name = "TabItem4"
        Me.TabItem4.Text = "Generated mapping"
        Me.TabItem4.Tooltip = "Generated mapping"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.scGeneratedModel)
        Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(906, 385)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = -90
        Me.TabControlPanel3.TabIndex = 9
        Me.TabControlPanel3.TabItem = Me.TabItem3
        '
        'scGeneratedModel
        '
        Me.scGeneratedModel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.scGeneratedModel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scGeneratedModel.FontQuality = ScintillaNET.FontQuality.AntiAliased
        Me.scGeneratedModel.IndentationGuides = ScintillaNET.IndentView.LookBoth
        Me.scGeneratedModel.Lexer = ScintillaNET.Lexer.Null
        Me.scGeneratedModel.Location = New System.Drawing.Point(1, 1)
        Me.scGeneratedModel.Margin = New System.Windows.Forms.Padding(0)
        Me.scGeneratedModel.Name = "scGeneratedModel"
        Me.scGeneratedModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.scGeneratedModel.Size = New System.Drawing.Size(904, 383)
        Me.scGeneratedModel.TabIndex = 1
        Me.scGeneratedModel.UseTabs = True
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel3
        Me.TabItem3.ImageIndex = 9
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Generated model"
        Me.TabItem3.Tooltip = "Generated model"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.dgvForeignKeys)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(906, 385)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = -90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'dgvForeignKeys
        '
        Me.dgvForeignKeys.AllowUserToAddRows = False
        Me.dgvForeignKeys.AllowUserToDeleteRows = False
        Me.dgvForeignKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvForeignKeys.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvForeignKeys.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForeignKeys.GridColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.dgvForeignKeys.Location = New System.Drawing.Point(1, 1)
        Me.dgvForeignKeys.Name = "dgvForeignKeys"
        Me.dgvForeignKeys.Size = New System.Drawing.Size(904, 383)
        Me.dgvForeignKeys.TabIndex = 1
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.ImageIndex = 6
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Foreign keys"
        Me.TabItem2.Tooltip = "Foreign keys"
        '
        'pdcCodePreview
        '
        Me.pdcCodePreview.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pdcCodePreview.Controls.Add(Me.scCodePreview)
        Me.pdcCodePreview.DisabledBackColor = System.Drawing.Color.Empty
        Me.pdcCodePreview.Location = New System.Drawing.Point(3, 28)
        Me.pdcCodePreview.Margin = New System.Windows.Forms.Padding(0)
        Me.pdcCodePreview.Name = "pdcCodePreview"
        Me.pdcCodePreview.Size = New System.Drawing.Size(906, 412)
        Me.pdcCodePreview.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pdcCodePreview.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pdcCodePreview.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.pdcCodePreview.Style.GradientAngle = 90
        Me.pdcCodePreview.TabIndex = 5
        '
        'scCodePreview
        '
        Me.scCodePreview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.scCodePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scCodePreview.FontQuality = ScintillaNET.FontQuality.AntiAliased
        Me.scCodePreview.IndentationGuides = ScintillaNET.IndentView.LookBoth
        Me.scCodePreview.Lexer = ScintillaNET.Lexer.Null
        Me.scCodePreview.Location = New System.Drawing.Point(0, 0)
        Me.scCodePreview.Margin = New System.Windows.Forms.Padding(0)
        Me.scCodePreview.Name = "scCodePreview"
        Me.scCodePreview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.scCodePreview.Size = New System.Drawing.Size(906, 412)
        Me.scCodePreview.TabIndex = 0
        Me.scCodePreview.UseTabs = True
        '
        'dcProjectSettings
        '
        Me.dcProjectSettings.CanClose = DevComponents.DotNetBar.eDockContainerClose.No
        Me.dcProjectSettings.Control = Me.pdcProjectSettings
        Me.dcProjectSettings.Name = "dcProjectSettings"
        Me.dcProjectSettings.Text = "Project settings"
        '
        'dcObjectInfo
        '
        Me.dcObjectInfo.Control = Me.pdcObjectInfo
        Me.dcObjectInfo.Name = "dcObjectInfo"
        Me.dcObjectInfo.Text = "Object information"
        '
        'dcCodePreview
        '
        Me.dcCodePreview.Control = Me.pdcCodePreview
        Me.dcCodePreview.Name = "dcCodePreview"
        Me.dcCodePreview.Text = "Code preview"
        '
        'ilDark
        '
        Me.ilDark.ImageStream = CType(resources.GetObject("ilDark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilDark.TransparentColor = System.Drawing.Color.Transparent
        Me.ilDark.Images.SetKeyName(0, "BackDark.png")
        Me.ilDark.Images.SetKeyName(1, "ForwardDark.png")
        Me.ilDark.Images.SetKeyName(2, "NewProjectDark.png")
        Me.ilDark.Images.SetKeyName(3, "OpenFileDark.png")
        Me.ilDark.Images.SetKeyName(4, "RedoDark.png")
        Me.ilDark.Images.SetKeyName(5, "SaveAllButtonDark.png")
        Me.ilDark.Images.SetKeyName(6, "SaveButtonDark.png")
        Me.ilDark.Images.SetKeyName(7, "StartDark.png")
        Me.ilDark.Images.SetKeyName(8, "UndoDark.png")
        Me.ilDark.Images.SetKeyName(9, "refresh.png")
        Me.ilDark.Images.SetKeyName(10, "house.png")
        Me.ilDark.Images.SetKeyName(11, "arrow_redo.png")
        Me.ilDark.Images.SetKeyName(12, "arrow_refresh.png")
        Me.ilDark.Images.SetKeyName(13, "arrow_undo.png")
        '
        'DockSite1
        '
        Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite1.Controls.Add(Me.BarDatabases)
        Me.DockSite1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite1.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.BarDatabases, 269, 443), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Horizontal)
        Me.DockSite1.Location = New System.Drawing.Point(0, 26)
        Me.DockSite1.Name = "DockSite1"
        Me.DockSite1.Size = New System.Drawing.Size(272, 443)
        Me.DockSite1.TabIndex = 0
        Me.DockSite1.TabStop = False
        '
        'BarDatabases
        '
        Me.BarDatabases.AccessibleDescription = "DotNetBar Bar (BarDatabases)"
        Me.BarDatabases.AccessibleName = "DotNetBar Bar"
        Me.BarDatabases.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.BarDatabases.AntiAlias = True
        Me.BarDatabases.AutoSyncBarCaption = True
        Me.BarDatabases.CanCustomize = False
        Me.BarDatabases.CanMaximizeFloating = False
        Me.BarDatabases.CloseSingleTab = True
        Me.BarDatabases.Controls.Add(Me.PanelDockContainer1)
        Me.BarDatabases.FadeEffect = True
        Me.BarDatabases.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarDatabases.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption
        Me.BarDatabases.Images = Me.ilDark
        Me.BarDatabases.IsMaximized = False
        Me.BarDatabases.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem1})
        Me.BarDatabases.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
        Me.BarDatabases.Location = New System.Drawing.Point(0, 0)
        Me.BarDatabases.Name = "BarDatabases"
        Me.BarDatabases.Size = New System.Drawing.Size(269, 443)
        Me.BarDatabases.Stretch = True
        Me.BarDatabases.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BarDatabases.TabIndex = 0
        Me.BarDatabases.TabStop = False
        Me.BarDatabases.Text = "Databases"
        '
        'PanelDockContainer1
        '
        Me.PanelDockContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelDockContainer1.Controls.Add(Me.advtreeDatabases)
        Me.PanelDockContainer1.Controls.Add(Me.Bar1)
        Me.PanelDockContainer1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelDockContainer1.Location = New System.Drawing.Point(3, 23)
        Me.PanelDockContainer1.Name = "PanelDockContainer1"
        Me.PanelDockContainer1.Size = New System.Drawing.Size(263, 417)
        Me.PanelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.PanelDockContainer1.Style.GradientAngle = 90
        Me.PanelDockContainer1.TabIndex = 0
        '
        'advtreeDatabases
        '
        Me.advtreeDatabases.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advtreeDatabases.AllowDrop = False
        Me.advtreeDatabases.AllowExternalDrop = False
        Me.advtreeDatabases.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advtreeDatabases.BackgroundStyle.Class = "TreeBorderKey"
        Me.advtreeDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advtreeDatabases.ColumnsVisible = False
        Me.advtreeDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.advtreeDatabases.DragDropEnabled = False
        Me.advtreeDatabases.DragDropNodeCopyEnabled = False
        Me.advtreeDatabases.GridColumnLines = False
        Me.advtreeDatabases.ImageList = Me.ilDatabaseObjects
        Me.advtreeDatabases.Location = New System.Drawing.Point(0, 35)
        Me.advtreeDatabases.Margin = New System.Windows.Forms.Padding(0)
        Me.advtreeDatabases.MultiNodeDragCountVisible = False
        Me.advtreeDatabases.MultiNodeDragDropAllowed = False
        Me.advtreeDatabases.Name = "advtreeDatabases"
        Me.advtreeDatabases.NodesConnector = Me.NodeConnector1
        Me.advtreeDatabases.NodeStyle = Me.ElementStyle1
        Me.advtreeDatabases.PathSeparator = ";"
        Me.advtreeDatabases.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.advtreeDatabases.Size = New System.Drawing.Size(263, 382)
        Me.advtreeDatabases.Styles.Add(Me.ElementStyle1)
        Me.advtreeDatabases.TabIndex = 1
        Me.advtreeDatabases.Text = "AdvTree1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.InactiveCaption
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "Bar1 (Bar1)"
        Me.Bar1.AccessibleName = "Bar1"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar1.AntiAlias = True
        Me.Bar1.CanCustomize = False
        Me.Bar1.CanDockBottom = False
        Me.Bar1.CanDockLeft = False
        Me.Bar1.CanDockRight = False
        Me.Bar1.CanDockTab = False
        Me.Bar1.CanDockTop = False
        Me.Bar1.CanMove = False
        Me.Bar1.CanReorderTabs = False
        Me.Bar1.CanUndock = False
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.EqualButtonSize = True
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Images = Me.ilDark
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewConnection, Me.btnEditConnection, Me.btnConnect, Me.cboConnecions})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(263, 35)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNewConnection
        '
        Me.btnNewConnection.CanCustomize = False
        Me.btnNewConnection.FixedSize = New System.Drawing.Size(32, 32)
        Me.btnNewConnection.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnNewConnection.Name = "btnNewConnection"
        Me.btnNewConnection.Symbol = ""
        Me.btnNewConnection.SymbolColor = System.Drawing.SystemColors.Highlight
        Me.btnNewConnection.Tooltip = "Create new connection"
        '
        'btnEditConnection
        '
        Me.btnEditConnection.CanCustomize = False
        Me.btnEditConnection.FixedSize = New System.Drawing.Size(32, 32)
        Me.btnEditConnection.Name = "btnEditConnection"
        Me.btnEditConnection.Symbol = ""
        Me.btnEditConnection.SymbolColor = System.Drawing.SystemColors.Highlight
        Me.btnEditConnection.Tooltip = "Edit connection"
        '
        'btnConnect
        '
        Me.btnConnect.CanCustomize = False
        Me.btnConnect.FixedSize = New System.Drawing.Size(32, 32)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Symbol = ""
        Me.btnConnect.SymbolColor = System.Drawing.SystemColors.Highlight
        Me.btnConnect.Tooltip = "Connect"
        '
        'cboConnecions
        '
        Me.cboConnecions.BeginGroup = True
        Me.cboConnecions.CanCustomize = False
        Me.cboConnecions.ComboWidth = 200
        Me.cboConnecions.DropDownHeight = 106
        Me.cboConnecions.ItemHeight = 18
        Me.cboConnecions.Name = "cboConnecions"
        Me.cboConnecions.Stretch = True
        Me.cboConnecions.WatermarkFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConnecions.WatermarkText = "Select connection"
        '
        'DockContainerItem1
        '
        Me.DockContainerItem1.Control = Me.PanelDockContainer1
        Me.DockContainerItem1.Name = "DockContainerItem1"
        Me.DockContainerItem1.Text = "Databases"
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite2.Controls.Add(Me.Bar2)
        Me.DockSite2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite2.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.Bar2, 277, 443), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Horizontal)
        Me.DockSite2.Location = New System.Drawing.Point(1184, 26)
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.Size = New System.Drawing.Size(280, 443)
        Me.DockSite2.TabIndex = 1
        Me.DockSite2.TabStop = False
        '
        'Bar2
        '
        Me.Bar2.AccessibleDescription = "DotNetBar Bar (Bar2)"
        Me.Bar2.AccessibleName = "DotNetBar Bar"
        Me.Bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.Bar2.AntiAlias = True
        Me.Bar2.AutoHide = True
        Me.Bar2.AutoSyncBarCaption = True
        Me.Bar2.CanCustomize = False
        Me.Bar2.Controls.Add(Me.PanelDockContainer3)
        Me.Bar2.DisplayMoreItemsOnMenu = True
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bar2.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem3})
        Me.Bar2.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
        Me.Bar2.Location = New System.Drawing.Point(3, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(277, 443)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 0
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Output explorer"
        '
        'PanelDockContainer3
        '
        Me.PanelDockContainer3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelDockContainer3.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelDockContainer3.Controls.Add(Me.Bar3)
        Me.PanelDockContainer3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelDockContainer3.Location = New System.Drawing.Point(3, 23)
        Me.PanelDockContainer3.Name = "PanelDockContainer3"
        Me.PanelDockContainer3.Size = New System.Drawing.Size(271, 417)
        Me.PanelDockContainer3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelDockContainer3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelDockContainer3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.PanelDockContainer3.Style.GradientAngle = 90
        Me.PanelDockContainer3.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtSearchOutput, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.advtreeOutputExplorer, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 35)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(271, 382)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'txtSearchOutput
        '
        Me.txtSearchOutput.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtSearchOutput.Border.Class = "TextBoxBorder"
        Me.txtSearchOutput.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSearchOutput.ButtonCustom.Symbol = "59574"
        Me.txtSearchOutput.ButtonCustom.SymbolColor = System.Drawing.SystemColors.Highlight
        Me.txtSearchOutput.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.txtSearchOutput.ButtonCustom.Visible = True
        Me.txtSearchOutput.DisabledBackColor = System.Drawing.Color.Black
        Me.txtSearchOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchOutput.ForeColor = System.Drawing.Color.White
        Me.txtSearchOutput.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchOutput.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSearchOutput.MaxLength = 255
        Me.txtSearchOutput.Name = "txtSearchOutput"
        Me.txtSearchOutput.PreventEnterBeep = True
        Me.txtSearchOutput.Size = New System.Drawing.Size(271, 25)
        Me.txtSearchOutput.TabIndex = 0
        Me.txtSearchOutput.WatermarkText = "Search output explorer..."
        '
        'advtreeOutputExplorer
        '
        Me.advtreeOutputExplorer.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advtreeOutputExplorer.AllowDrop = False
        Me.advtreeOutputExplorer.AllowExternalDrop = False
        Me.advtreeOutputExplorer.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advtreeOutputExplorer.BackgroundStyle.Class = "TreeBorderKey"
        Me.advtreeOutputExplorer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advtreeOutputExplorer.ColumnsVisible = False
        Me.advtreeOutputExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.advtreeOutputExplorer.DragDropEnabled = False
        Me.advtreeOutputExplorer.DragDropNodeCopyEnabled = False
        Me.advtreeOutputExplorer.GridColumnLines = False
        Me.advtreeOutputExplorer.ImageList = Me.ilExplorer
        Me.advtreeOutputExplorer.Location = New System.Drawing.Point(0, 25)
        Me.advtreeOutputExplorer.Margin = New System.Windows.Forms.Padding(0)
        Me.advtreeOutputExplorer.MultiNodeDragCountVisible = False
        Me.advtreeOutputExplorer.MultiNodeDragDropAllowed = False
        Me.advtreeOutputExplorer.Name = "advtreeOutputExplorer"
        Me.advtreeOutputExplorer.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.nModels})
        Me.advtreeOutputExplorer.NodesConnector = Me.NodeConnector2
        Me.advtreeOutputExplorer.NodeStyle = Me.ElementStyle2
        Me.advtreeOutputExplorer.PathSeparator = ";"
        Me.advtreeOutputExplorer.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.advtreeOutputExplorer.Size = New System.Drawing.Size(271, 357)
        Me.advtreeOutputExplorer.Styles.Add(Me.ElementStyle2)
        Me.advtreeOutputExplorer.TabIndex = 1
        Me.advtreeOutputExplorer.Text = "AdvTree1"
        '
        'ilExplorer
        '
        Me.ilExplorer.ImageStream = CType(resources.GetObject("ilExplorer.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilExplorer.TransparentColor = System.Drawing.Color.Transparent
        Me.ilExplorer.Images.SetKeyName(0, "folder.png")
        Me.ilExplorer.Images.SetKeyName(1, "folder_closed.png")
        Me.ilExplorer.Images.SetKeyName(2, "application_form.png")
        Me.ilExplorer.Images.SetKeyName(3, "file_extension_txt.png")
        Me.ilExplorer.Images.SetKeyName(4, "file_extension_vb.png")
        Me.ilExplorer.Images.SetKeyName(5, "sitemap_image.png")
        Me.ilExplorer.Images.SetKeyName(6, "file_extension_mcd.png")
        Me.ilExplorer.Images.SetKeyName(7, "file_extension_ses.png")
        '
        'nModels
        '
        Me.nModels.DragDropEnabled = False
        Me.nModels.Editable = False
        Me.nModels.Expanded = True
        Me.nModels.ImageExpandedIndex = 0
        Me.nModels.ImageIndex = 1
        Me.nModels.Name = "nModels"
        Me.nModels.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.mapMapping, Me.mapStoreCommands, Me.nContext, Me.nStoreCommands, Me.tplModel})
        Me.nModels.Text = "Models"
        '
        'mapMapping
        '
        Me.mapMapping.DragDropEnabled = False
        Me.mapMapping.Editable = False
        Me.mapMapping.Expanded = True
        Me.mapMapping.ImageExpandedIndex = 0
        Me.mapMapping.ImageIndex = 1
        Me.mapMapping.Name = "mapMapping"
        Me.mapMapping.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.tplMapping})
        Me.mapMapping.Text = "Mapping"
        '
        'tplMapping
        '
        Me.tplMapping.DragDropEnabled = False
        Me.tplMapping.Editable = False
        Me.tplMapping.ImageIndex = 4
        Me.tplMapping.Name = "tplMapping"
        Me.tplMapping.Text = "mapping.vb"
        '
        'mapStoreCommands
        '
        Me.mapStoreCommands.DragDropEnabled = False
        Me.mapStoreCommands.Editable = False
        Me.mapStoreCommands.Expanded = True
        Me.mapStoreCommands.ImageExpandedIndex = 0
        Me.mapStoreCommands.ImageIndex = 1
        Me.mapStoreCommands.Name = "mapStoreCommands"
        Me.mapStoreCommands.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.mapStoreCommandModels, Me.tplFunction, Me.tplProcedure})
        Me.mapStoreCommands.Text = "StoreCommands"
        '
        'mapStoreCommandModels
        '
        Me.mapStoreCommandModels.DragDropEnabled = False
        Me.mapStoreCommandModels.Editable = False
        Me.mapStoreCommandModels.Expanded = True
        Me.mapStoreCommandModels.ImageExpandedIndex = 0
        Me.mapStoreCommandModels.ImageIndex = 1
        Me.mapStoreCommandModels.Name = "mapStoreCommandModels"
        Me.mapStoreCommandModels.Text = "Models"
        '
        'tplFunction
        '
        Me.tplFunction.DragDropEnabled = False
        Me.tplFunction.Editable = False
        Me.tplFunction.ImageIndex = 6
        Me.tplFunction.Name = "tplFunction"
        Me.tplFunction.Text = "function.vb"
        '
        'tplProcedure
        '
        Me.tplProcedure.DragDropEnabled = False
        Me.tplProcedure.Editable = False
        Me.tplProcedure.ImageIndex = 7
        Me.tplProcedure.Name = "tplProcedure"
        Me.tplProcedure.Text = "procedure.vb"
        '
        'nContext
        '
        Me.nContext.DragDropEnabled = False
        Me.nContext.Editable = False
        Me.nContext.ImageIndex = 5
        Me.nContext.Name = "nContext"
        Me.nContext.Text = "context.vb"
        '
        'nStoreCommands
        '
        Me.nStoreCommands.DragDropEnabled = False
        Me.nStoreCommands.Editable = False
        Me.nStoreCommands.ImageIndex = 5
        Me.nStoreCommands.Name = "nStoreCommands"
        Me.nStoreCommands.Text = "storeCommands.vb"
        '
        'tplModel
        '
        Me.tplModel.DragDropEnabled = False
        Me.tplModel.Editable = False
        Me.tplModel.ImageIndex = 4
        Me.tplModel.Name = "tplModel"
        Me.tplModel.Text = "model.vb"
        '
        'NodeConnector2
        '
        Me.NodeConnector2.LineColor = System.Drawing.SystemColors.InactiveCaption
        '
        'ElementStyle2
        '
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.CanCustomize = False
        Me.Bar3.CanDockBottom = False
        Me.Bar3.CanDockLeft = False
        Me.Bar3.CanDockRight = False
        Me.Bar3.CanDockTab = False
        Me.Bar3.CanMaximizeFloating = False
        Me.Bar3.CanMove = False
        Me.Bar3.CanReorderTabs = False
        Me.Bar3.CanUndock = False
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DoubleClickBehavior = DevComponents.DotNetBar.eDoubleClickBarBehavior.None
        Me.Bar3.EqualButtonSize = True
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.Images = Me.ilDark
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnHomeOutputExplorer, Me.btnRefreshOutputExplorer, Me.btnSaveLayout})
        Me.Bar3.Location = New System.Drawing.Point(0, 0)
        Me.Bar3.Margin = New System.Windows.Forms.Padding(0)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(271, 35)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 2
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'btnHomeOutputExplorer
        '
        Me.btnHomeOutputExplorer.CanCustomize = False
        Me.btnHomeOutputExplorer.FixedSize = New System.Drawing.Size(32, 32)
        Me.btnHomeOutputExplorer.ImageIndex = 10
        Me.btnHomeOutputExplorer.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnHomeOutputExplorer.ImagePaddingHorizontal = 1
        Me.btnHomeOutputExplorer.ImagePaddingVertical = 1
        Me.btnHomeOutputExplorer.Name = "btnHomeOutputExplorer"
        '
        'btnRefreshOutputExplorer
        '
        Me.btnRefreshOutputExplorer.CanCustomize = False
        Me.btnRefreshOutputExplorer.FixedSize = New System.Drawing.Size(32, 32)
        Me.btnRefreshOutputExplorer.ImageIndex = 12
        Me.btnRefreshOutputExplorer.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnRefreshOutputExplorer.ImagePaddingHorizontal = 1
        Me.btnRefreshOutputExplorer.ImagePaddingVertical = 1
        Me.btnRefreshOutputExplorer.Name = "btnRefreshOutputExplorer"
        '
        'btnSaveLayout
        '
        Me.btnSaveLayout.CanCustomize = False
        Me.btnSaveLayout.ImageIndex = 6
        Me.btnSaveLayout.Name = "btnSaveLayout"
        '
        'DockContainerItem3
        '
        Me.DockContainerItem3.Control = Me.PanelDockContainer3
        Me.DockContainerItem3.Name = "DockContainerItem3"
        Me.DockContainerItem3.Text = "Output explorer"
        '
        'DockSite8
        '
        Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite8.Location = New System.Drawing.Point(0, 561)
        Me.DockSite8.Name = "DockSite8"
        Me.DockSite8.Size = New System.Drawing.Size(1464, 0)
        Me.DockSite8.TabIndex = 7
        Me.DockSite8.TabStop = False
        '
        'DockSite5
        '
        Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite5.Location = New System.Drawing.Point(0, 26)
        Me.DockSite5.Name = "DockSite5"
        Me.DockSite5.Size = New System.Drawing.Size(0, 535)
        Me.DockSite5.TabIndex = 4
        Me.DockSite5.TabStop = False
        '
        'DockSite6
        '
        Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite6.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite6.Location = New System.Drawing.Point(1464, 26)
        Me.DockSite6.Name = "DockSite6"
        Me.DockSite6.Size = New System.Drawing.Size(0, 535)
        Me.DockSite6.TabIndex = 5
        Me.DockSite6.TabStop = False
        '
        'DockSite7
        '
        Me.DockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite7.Controls.Add(Me.barMainMenu)
        Me.DockSite7.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite7.Location = New System.Drawing.Point(0, 0)
        Me.DockSite7.Name = "DockSite7"
        Me.DockSite7.Size = New System.Drawing.Size(1464, 26)
        Me.DockSite7.TabIndex = 6
        Me.DockSite7.TabStop = False
        '
        'barMainMenu
        '
        Me.barMainMenu.AccessibleDescription = "DotNetBar Bar (barMainMenu)"
        Me.barMainMenu.AccessibleName = "DotNetBar Bar"
        Me.barMainMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.barMainMenu.BarType = DevComponents.DotNetBar.eBarType.MenuBar
        Me.barMainMenu.CanAutoHide = False
        Me.barMainMenu.CanDockBottom = False
        Me.barMainMenu.CanDockLeft = False
        Me.barMainMenu.CanDockRight = False
        Me.barMainMenu.CanDockTab = False
        Me.barMainMenu.CanDockTop = False
        Me.barMainMenu.CanMaximizeFloating = False
        Me.barMainMenu.CanMove = False
        Me.barMainMenu.CanReorderTabs = False
        Me.barMainMenu.CanUndock = False
        Me.barMainMenu.DockSide = DevComponents.DotNetBar.eDockSide.Top
        Me.barMainMenu.DoubleClickBehavior = DevComponents.DotNetBar.eDoubleClickBarBehavior.None
        Me.barMainMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barMainMenu.IsMaximized = False
        Me.barMainMenu.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnFile})
        Me.barMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMainMenu.MenuBar = True
        Me.barMainMenu.Name = "barMainMenu"
        Me.barMainMenu.Size = New System.Drawing.Size(34, 26)
        Me.barMainMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.barMainMenu.TabIndex = 0
        Me.barMainMenu.TabStop = False
        Me.barMainMenu.Text = "MainMenu"
        '
        'btnFile
        '
        Me.btnFile.Name = "btnFile"
        Me.btnFile.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSettings, Me.btnFile_Close})
        Me.btnFile.Text = "File"
        '
        'btnSettings
        '
        Me.btnSettings.CanCustomize = False
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Symbol = ""
        Me.btnSettings.SymbolColor = System.Drawing.SystemColors.Highlight
        Me.btnSettings.Text = "Settings..."
        '
        'btnFile_Close
        '
        Me.btnFile_Close.BeginGroup = True
        Me.btnFile_Close.Name = "btnFile_Close"
        Me.btnFile_Close.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.None
        Me.btnFile_Close.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.btnFile_Close.Text = "Close"
        '
        'DockSite3
        '
        Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite3.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite3.Location = New System.Drawing.Point(0, 26)
        Me.DockSite3.Name = "DockSite3"
        Me.DockSite3.Size = New System.Drawing.Size(1464, 0)
        Me.DockSite3.TabIndex = 2
        Me.DockSite3.TabStop = False
        '
        'LabelItem1
        '
        Me.LabelItem1.GlobalItem = False
        Me.LabelItem1.Name = "LabelItem1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.AllowMerge = False
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.InvertSelectionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(130, 70)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select all"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Select none"
        '
        'InvertSelectionToolStripMenuItem
        '
        Me.InvertSelectionToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.InvertSelectionToolStripMenuItem.Name = "InvertSelectionToolStripMenuItem"
        Me.InvertSelectionToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.InvertSelectionToolStripMenuItem.Text = "Invert selection"
        '
        'mainGUI2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1464, 561)
        Me.Controls.Add(Me.DockSite9)
        Me.Controls.Add(Me.DockSite2)
        Me.Controls.Add(Me.DockSite1)
        Me.Controls.Add(Me.DockSite3)
        Me.Controls.Add(Me.DockSite4)
        Me.Controls.Add(Me.DockSite5)
        Me.Controls.Add(Me.DockSite6)
        Me.Controls.Add(Me.DockSite7)
        Me.Controls.Add(Me.DockSite8)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "mainGUI2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mainGUI2"
        Me.DockSite4.ResumeLayout(False)
        CType(Me.barLogging, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barLogging.ResumeLayout(False)
        Me.PanelDockContainer2.ResumeLayout(False)
        Me.DockSite9.ResumeLayout(False)
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar4.ResumeLayout(False)
        Me.pdcProjectSettings.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pdcObjectInfo.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        CType(Me.dgvFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        CType(Me.dgvForeignKeys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pdcCodePreview.ResumeLayout(False)
        Me.DockSite1.ResumeLayout(False)
        CType(Me.BarDatabases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarDatabases.ResumeLayout(False)
        Me.PanelDockContainer1.ResumeLayout(False)
        CType(Me.advtreeDatabases, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockSite2.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.PanelDockContainer3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.advtreeOutputExplorer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockSite7.ResumeLayout(False)
        CType(Me.barMainMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dnbStyleManagerAmbient As DevComponents.DotNetBar.StyleManagerAmbient
    Friend WithEvents dnbStyleManager As DevComponents.DotNetBar.StyleManager
    Friend WithEvents CheckBoxItem1 As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents dnbBarManager As DevComponents.DotNetBar.DotNetBarManager
    Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite7 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
    Friend WithEvents barMainMenu As DevComponents.DotNetBar.Bar
    Friend WithEvents btnFile As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFile_Close As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents BarDatabases As DevComponents.DotNetBar.Bar
    Friend WithEvents PanelDockContainer1 As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents DockContainerItem1 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents ilDark As ImageList
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewConnection As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditConnection As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnConnect As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cboConnecions As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents advtreeDatabases As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents btnSettings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents barLogging As DevComponents.DotNetBar.Bar
    Friend WithEvents PanelDockContainer2 As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents DockContainerItem2 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents txtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ilDatabaseObjects As ImageList
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents PanelDockContainer3 As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents DockContainerItem3 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents advtreeOutputExplorer As DevComponents.AdvTree.AdvTree
    Friend WithEvents ilExplorer As ImageList
    Friend WithEvents nModels As DevComponents.AdvTree.Node
    Friend WithEvents mapMapping As DevComponents.AdvTree.Node
    Friend WithEvents tplMapping As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents txtSearchOutput As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents mapStoreCommands As DevComponents.AdvTree.Node
    Friend WithEvents nContext As DevComponents.AdvTree.Node
    Friend WithEvents nStoreCommands As DevComponents.AdvTree.Node
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnHomeOutputExplorer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshOutputExplorer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvertSelectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DockSite9 As DevComponents.DotNetBar.DockSite
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents pdcObjectInfo As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents dcObjectInfo As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents pdcCodePreview As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents scCodePreview As ScintillaNET.Scintilla
    Friend WithEvents dcCodePreview As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents tplModel As DevComponents.AdvTree.Node
    Friend WithEvents btnSaveLayout As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mapStoreCommandModels As DevComponents.AdvTree.Node
    Friend WithEvents tplFunction As DevComponents.AdvTree.Node
    Friend WithEvents tplProcedure As DevComponents.AdvTree.Node
    Friend WithEvents pdcProjectSettings As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents dcProjectSettings As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboOutputType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents dgvFields As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvForeignKeys As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents scGeneratedModel As ScintillaNET.Scintilla
    Friend WithEvents scGeneratedMapping As ScintillaNET.Scintilla
    Friend WithEvents txtProjectName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txtOutputFolder As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtProjectFolder As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
