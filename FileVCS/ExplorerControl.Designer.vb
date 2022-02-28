<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExplorerControl
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExplorerControl))
        Me.atExplorer = New DevComponents.AdvTree.AdvTree()
        Me.ilExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.StyleManagerAmbient1 = New DevComponents.DotNetBar.StyleManagerAmbient(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tSearch = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.atExplorer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'atExplorer
        '
        Me.atExplorer.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.atExplorer.AllowDrop = False
        Me.atExplorer.AllowExternalDrop = False
        Me.atExplorer.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer))
        '
        '
        '
        Me.atExplorer.BackgroundStyle.Class = "TreeBorderKey"
        Me.atExplorer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.atExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.atExplorer.DragDropEnabled = False
        Me.atExplorer.DragDropNodeCopyEnabled = False
        Me.atExplorer.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.atExplorer.ImageList = Me.ilExplorer
        Me.atExplorer.Location = New System.Drawing.Point(0, 23)
        Me.atExplorer.Margin = New System.Windows.Forms.Padding(0)
        Me.atExplorer.Name = "atExplorer"
        Me.atExplorer.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.atExplorer.NodesConnector = Me.NodeConnector1
        Me.atExplorer.NodeStyle = Me.ElementStyle1
        Me.atExplorer.PathSeparator = ";"
        Me.atExplorer.Size = New System.Drawing.Size(250, 360)
        Me.atExplorer.Styles.Add(Me.ElementStyle1)
        Me.atExplorer.TabIndex = 0
        Me.atExplorer.Text = "AdvTree1"
        '
        'ilExplorer
        '
        Me.ilExplorer.ImageStream = CType(resources.GetObject("ilExplorer.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilExplorer.TransparentColor = System.Drawing.Color.Transparent
        Me.ilExplorer.Images.SetKeyName(0, "application.png")
        Me.ilExplorer.Images.SetKeyName(1, "application-add.png")
        Me.ilExplorer.Images.SetKeyName(2, "application-check.png")
        Me.ilExplorer.Images.SetKeyName(3, "application-error.png")
        Me.ilExplorer.Images.SetKeyName(4, "application-remove.png")
        Me.ilExplorer.Images.SetKeyName(5, "document_text.png")
        Me.ilExplorer.Images.SetKeyName(6, "document_text-add.png")
        Me.ilExplorer.Images.SetKeyName(7, "document_text-check.png")
        Me.ilExplorer.Images.SetKeyName(8, "document_text-error.png")
        Me.ilExplorer.Images.SetKeyName(9, "document_text-remove.png")
        Me.ilExplorer.Images.SetKeyName(10, "folder.png")
        Me.ilExplorer.Images.SetKeyName(11, "folder-add.png")
        Me.ilExplorer.Images.SetKeyName(12, "folder-check.png")
        Me.ilExplorer.Images.SetKeyName(13, "folder-error.png")
        Me.ilExplorer.Images.SetKeyName(14, "folder-remove.png")
        Me.ilExplorer.Images.SetKeyName(15, "folder_open.png")
        Me.ilExplorer.Images.SetKeyName(16, "folder_open-add.png")
        Me.ilExplorer.Images.SetKeyName(17, "folder_open-check.png")
        Me.ilExplorer.Images.SetKeyName(18, "folder_open-error.png")
        Me.ilExplorer.Images.SetKeyName(19, "folder_open-remove.png")
        Me.ilExplorer.Images.SetKeyName(20, "notepad.png")
        Me.ilExplorer.Images.SetKeyName(21, "notepad-add.png")
        Me.ilExplorer.Images.SetKeyName(22, "notepad-check.png")
        Me.ilExplorer.Images.SetKeyName(23, "notepad-error.png")
        Me.ilExplorer.Images.SetKeyName(24, "notepad-remove.png")
        Me.ilExplorer.Images.SetKeyName(25, "book_open.png")
        Me.ilExplorer.Images.SetKeyName(26, "book_open-add.png")
        Me.ilExplorer.Images.SetKeyName(27, "book_open-check.png")
        Me.ilExplorer.Images.SetKeyName(28, "book_open-error.png")
        Me.ilExplorer.Images.SetKeyName(29, "book_open-remove.png")
        Me.ilExplorer.Images.SetKeyName(30, "database.png")
        Me.ilExplorer.Images.SetKeyName(31, "document_script.png")
        Me.ilExplorer.Images.SetKeyName(32, "query.png")
        Me.ilExplorer.Images.SetKeyName(33, "script.png")
        Me.ilExplorer.Images.SetKeyName(34, "table.png")
        Me.ilExplorer.Images.SetKeyName(35, "datasheet.png")
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.Color.LightGray
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.Color.WhiteSmoke
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.atExplorer, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tSearch, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(250, 383)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'tSearch
        '
        Me.tSearch.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.tSearch.Border.Class = "TextBoxBorder"
        Me.tSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tSearch.ButtonCustom.Image = Global.FileVCS.My.Resources.Resources.find
        Me.tSearch.ButtonCustom.Visible = True
        Me.tSearch.DisabledBackColor = System.Drawing.Color.Black
        Me.tSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tSearch.ForeColor = System.Drawing.Color.White
        Me.tSearch.Location = New System.Drawing.Point(0, 0)
        Me.tSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.tSearch.MaxLength = 255
        Me.tSearch.Name = "tSearch"
        Me.tSearch.PreventEnterBeep = True
        Me.tSearch.Size = New System.Drawing.Size(250, 23)
        Me.tSearch.TabIndex = 1
        Me.tSearch.WatermarkText = "Search for files..."
        '
        'ExplorerControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "ExplorerControl"
        Me.Size = New System.Drawing.Size(250, 383)
        CType(Me.atExplorer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents StyleManagerAmbient1 As DevComponents.DotNetBar.StyleManagerAmbient
    Friend WithEvents ilExplorer As ImageList
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents tSearch As DevComponents.DotNetBar.Controls.TextBoxX
    Protected WithEvents atExplorer As DevComponents.AdvTree.AdvTree
End Class
