<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Explorer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Explorer))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.bHome = New DevComponents.DotNetBar.ButtonItem()
        Me.brefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.bExport = New DevComponents.DotNetBar.ButtonItem()
        Me.tSearch = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.advtreeOutputExplorer = New DevComponents.AdvTree.AdvTree()
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
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.StyleManagerAmbient1 = New DevComponents.DotNetBar.StyleManagerAmbient(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.advtreeOutputExplorer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "application.png")
        Me.ImageList1.Images.SetKeyName(1, "application-add.png")
        Me.ImageList1.Images.SetKeyName(2, "application-check.png")
        Me.ImageList1.Images.SetKeyName(3, "application-error.png")
        Me.ImageList1.Images.SetKeyName(4, "application-remove.png")
        Me.ImageList1.Images.SetKeyName(5, "document_text.png")
        Me.ImageList1.Images.SetKeyName(6, "document_text-add.png")
        Me.ImageList1.Images.SetKeyName(7, "document_text-check.png")
        Me.ImageList1.Images.SetKeyName(8, "document_text-error.png")
        Me.ImageList1.Images.SetKeyName(9, "document_text-remove.png")
        Me.ImageList1.Images.SetKeyName(10, "folder.png")
        Me.ImageList1.Images.SetKeyName(11, "folder-add.png")
        Me.ImageList1.Images.SetKeyName(12, "folder-check.png")
        Me.ImageList1.Images.SetKeyName(13, "folder-error.png")
        Me.ImageList1.Images.SetKeyName(14, "folder-remove.png")
        Me.ImageList1.Images.SetKeyName(15, "folder_open.png")
        Me.ImageList1.Images.SetKeyName(16, "folder_open-add.png")
        Me.ImageList1.Images.SetKeyName(17, "folder_open-check.png")
        Me.ImageList1.Images.SetKeyName(18, "folder_open-error.png")
        Me.ImageList1.Images.SetKeyName(19, "folder_open-remove.png")
        Me.ImageList1.Images.SetKeyName(20, "list.png")
        Me.ImageList1.Images.SetKeyName(21, "list-add.png")
        Me.ImageList1.Images.SetKeyName(22, "list-check.png")
        Me.ImageList1.Images.SetKeyName(23, "list-error.png")
        Me.ImageList1.Images.SetKeyName(24, "list-remove.png")
        Me.ImageList1.Images.SetKeyName(25, "notepad.png")
        Me.ImageList1.Images.SetKeyName(26, "notepad-add.png")
        Me.ImageList1.Images.SetKeyName(27, "notepad-check.png")
        Me.ImageList1.Images.SetKeyName(28, "notepad-error.png")
        Me.ImageList1.Images.SetKeyName(29, "notepad-remove.png")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Bar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tSearch, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.advtreeOutputExplorer, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(317, 480)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.CanCustomize = False
        Me.Bar1.CanDockBottom = False
        Me.Bar1.CanDockLeft = False
        Me.Bar1.CanDockRight = False
        Me.Bar1.CanDockTab = False
        Me.Bar1.CanDockTop = False
        Me.Bar1.CanMaximizeFloating = False
        Me.Bar1.CanMove = False
        Me.Bar1.CanReorderTabs = False
        Me.Bar1.CanUndock = False
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.DoubleClickBehavior = DevComponents.DotNetBar.eDoubleClickBarBehavior.None
        Me.Bar1.EqualButtonSize = True
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Images = Me.ImageList2
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bHome, Me.brefresh, Me.bExport})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Margin = New System.Windows.Forms.Padding(0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(317, 35)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 1
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "asset.png")
        Me.ImageList2.Images.SetKeyName(1, "refresh.png")
        Me.ImageList2.Images.SetKeyName(2, "save.png")
        Me.ImageList2.Images.SetKeyName(3, "save-add.png")
        Me.ImageList2.Images.SetKeyName(4, "save-check.png")
        Me.ImageList2.Images.SetKeyName(5, "save-error.png")
        Me.ImageList2.Images.SetKeyName(6, "save-remove.png")
        Me.ImageList2.Images.SetKeyName(7, "zoom.png")
        '
        'bHome
        '
        Me.bHome.FixedSize = New System.Drawing.Size(32, 32)
        Me.bHome.ImageIndex = 0
        Me.bHome.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.bHome.Name = "bHome"
        '
        'brefresh
        '
        Me.brefresh.FixedSize = New System.Drawing.Size(32, 32)
        Me.brefresh.ImageIndex = 1
        Me.brefresh.Name = "brefresh"
        Me.brefresh.Text = "ButtonItem2"
        '
        'bExport
        '
        Me.bExport.FixedSize = New System.Drawing.Size(32, 32)
        Me.bExport.ImageIndex = 2
        Me.bExport.Name = "bExport"
        Me.bExport.Text = "ButtonItem3"
        '
        'tSearch
        '
        Me.tSearch.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.tSearch.Border.Class = "TextBoxBorder"
        Me.tSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tSearch.ButtonCustom.Image = Global.FileOutput.My.Resources.Resources.zoom
        Me.tSearch.ButtonCustom.Visible = True
        Me.tSearch.ButtonCustom2.Image = Global.FileOutput.My.Resources.Resources.cancel
        Me.tSearch.ButtonCustom2.Visible = True
        Me.tSearch.DisabledBackColor = System.Drawing.Color.Black
        Me.tSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSearch.ForeColor = System.Drawing.Color.White
        Me.tSearch.Location = New System.Drawing.Point(0, 35)
        Me.tSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.tSearch.MaxLength = 100
        Me.tSearch.Name = "tSearch"
        Me.tSearch.PreventEnterBeep = True
        Me.tSearch.Size = New System.Drawing.Size(317, 23)
        Me.tSearch.TabIndex = 2
        Me.tSearch.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.tSearch.WatermarkText = "Enter search text..."
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
        Me.advtreeOutputExplorer.ImageList = Me.ImageList1
        Me.advtreeOutputExplorer.Location = New System.Drawing.Point(0, 58)
        Me.advtreeOutputExplorer.Margin = New System.Windows.Forms.Padding(0)
        Me.advtreeOutputExplorer.MultiNodeDragCountVisible = False
        Me.advtreeOutputExplorer.MultiNodeDragDropAllowed = False
        Me.advtreeOutputExplorer.Name = "advtreeOutputExplorer"
        Me.advtreeOutputExplorer.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.nModels})
        Me.advtreeOutputExplorer.NodesConnector = Me.NodeConnector2
        Me.advtreeOutputExplorer.NodeStyle = Me.ElementStyle2
        Me.advtreeOutputExplorer.PaintDragDropInsertMarker = False
        Me.advtreeOutputExplorer.PathSeparator = ";"
        Me.advtreeOutputExplorer.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.advtreeOutputExplorer.Size = New System.Drawing.Size(317, 422)
        Me.advtreeOutputExplorer.Styles.Add(Me.ElementStyle2)
        Me.advtreeOutputExplorer.TabIndex = 3
        Me.advtreeOutputExplorer.Text = "AdvTree1"
        '
        'nModels
        '
        Me.nModels.DragDropEnabled = False
        Me.nModels.Editable = False
        Me.nModels.Expanded = True
        Me.nModels.ImageExpandedIndex = 11
        Me.nModels.ImageIndex = 10
        Me.nModels.Name = "nModels"
        Me.nModels.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.mapMapping, Me.mapStoreCommands, Me.nContext, Me.nStoreCommands, Me.tplModel})
        Me.nModels.Text = "Models"
        '
        'mapMapping
        '
        Me.mapMapping.DragDropEnabled = False
        Me.mapMapping.Editable = False
        Me.mapMapping.Expanded = True
        Me.mapMapping.ImageExpandedIndex = 11
        Me.mapMapping.ImageIndex = 10
        Me.mapMapping.Name = "mapMapping"
        Me.mapMapping.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.tplMapping})
        Me.mapMapping.Text = "Mapping"
        '
        'tplMapping
        '
        Me.tplMapping.DragDropEnabled = False
        Me.tplMapping.Editable = False
        Me.tplMapping.ImageIndex = 5
        Me.tplMapping.Name = "tplMapping"
        Me.tplMapping.Text = "mapping.vb"
        '
        'mapStoreCommands
        '
        Me.mapStoreCommands.DragDropEnabled = False
        Me.mapStoreCommands.Editable = False
        Me.mapStoreCommands.Expanded = True
        Me.mapStoreCommands.ImageExpandedIndex = 11
        Me.mapStoreCommands.ImageIndex = 10
        Me.mapStoreCommands.Name = "mapStoreCommands"
        Me.mapStoreCommands.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.mapStoreCommandModels, Me.tplFunction, Me.tplProcedure})
        Me.mapStoreCommands.Text = "StoreCommands"
        '
        'mapStoreCommandModels
        '
        Me.mapStoreCommandModels.DragDropEnabled = False
        Me.mapStoreCommandModels.Editable = False
        Me.mapStoreCommandModels.Expanded = True
        Me.mapStoreCommandModels.ImageExpandedIndex = 11
        Me.mapStoreCommandModels.ImageIndex = 10
        Me.mapStoreCommandModels.Name = "mapStoreCommandModels"
        Me.mapStoreCommandModels.Text = "Models"
        '
        'tplFunction
        '
        Me.tplFunction.DragDropEnabled = False
        Me.tplFunction.Editable = False
        Me.tplFunction.ImageIndex = 25
        Me.tplFunction.Name = "tplFunction"
        Me.tplFunction.Text = "function.vb"
        '
        'tplProcedure
        '
        Me.tplProcedure.DragDropEnabled = False
        Me.tplProcedure.Editable = False
        Me.tplProcedure.ImageIndex = 20
        Me.tplProcedure.Name = "tplProcedure"
        Me.tplProcedure.Text = "procedure.vb"
        '
        'nContext
        '
        Me.nContext.DragDropEnabled = False
        Me.nContext.Editable = False
        Me.nContext.ImageIndex = 0
        Me.nContext.Name = "nContext"
        Me.nContext.Text = "context.vb"
        '
        'nStoreCommands
        '
        Me.nStoreCommands.DragDropEnabled = False
        Me.nStoreCommands.Editable = False
        Me.nStoreCommands.ImageIndex = 20
        Me.nStoreCommands.Name = "nStoreCommands"
        Me.nStoreCommands.Text = "storeCommands.vb"
        '
        'tplModel
        '
        Me.tplModel.DragDropEnabled = False
        Me.tplModel.Editable = False
        Me.tplModel.ImageIndex = 5
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
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'Explorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Explorer"
        Me.Size = New System.Drawing.Size(317, 480)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.advtreeOutputExplorer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents bHome As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents brefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bExport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents tSearch As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents advtreeOutputExplorer As DevComponents.AdvTree.AdvTree
    Friend WithEvents nModels As DevComponents.AdvTree.Node
    Friend WithEvents mapMapping As DevComponents.AdvTree.Node
    Friend WithEvents tplMapping As DevComponents.AdvTree.Node
    Friend WithEvents mapStoreCommands As DevComponents.AdvTree.Node
    Friend WithEvents mapStoreCommandModels As DevComponents.AdvTree.Node
    Friend WithEvents tplFunction As DevComponents.AdvTree.Node
    Friend WithEvents tplProcedure As DevComponents.AdvTree.Node
    Friend WithEvents nContext As DevComponents.AdvTree.Node
    Friend WithEvents nStoreCommands As DevComponents.AdvTree.Node
    Friend WithEvents tplModel As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents StyleManagerAmbient1 As DevComponents.DotNetBar.StyleManagerAmbient
End Class
