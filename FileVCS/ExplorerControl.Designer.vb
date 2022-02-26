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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExplorerControl))
        Me.atExplorer = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager()
        Me.StyleManagerAmbient1 = New DevComponents.DotNetBar.StyleManagerAmbient()
        Me.ilExplorer = New System.Windows.Forms.ImageList()
        CType(Me.atExplorer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'atExplorer
        '
        Me.atExplorer.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.atExplorer.AllowDrop = False
        Me.atExplorer.AllowExternalDrop = False
        Me.atExplorer.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.atExplorer.BackgroundStyle.Class = "TreeBorderKey"
        Me.atExplorer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.atExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.atExplorer.DragDropEnabled = False
        Me.atExplorer.DragDropNodeCopyEnabled = False
        Me.atExplorer.Location = New System.Drawing.Point(0, 0)
        Me.atExplorer.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.atExplorer.Name = "atExplorer"
        Me.atExplorer.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.atExplorer.NodesConnector = Me.NodeConnector1
        Me.atExplorer.NodeStyle = Me.ElementStyle1
        Me.atExplorer.PathSeparator = ";"
        Me.atExplorer.Size = New System.Drawing.Size(250, 383)
        Me.atExplorer.Styles.Add(Me.ElementStyle1)
        Me.atExplorer.TabIndex = 0
        Me.atExplorer.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
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
        Me.ilExplorer.Images.SetKeyName(8, "application.png")
        Me.ilExplorer.Images.SetKeyName(9, "application-add.png")
        Me.ilExplorer.Images.SetKeyName(10, "application-check.png")
        Me.ilExplorer.Images.SetKeyName(11, "application-error.png")
        Me.ilExplorer.Images.SetKeyName(12, "application-remove.png")
        Me.ilExplorer.Images.SetKeyName(13, "document_text.png")
        Me.ilExplorer.Images.SetKeyName(14, "document_text-add.png")
        Me.ilExplorer.Images.SetKeyName(15, "document_text-check.png")
        Me.ilExplorer.Images.SetKeyName(16, "document_text-error.png")
        Me.ilExplorer.Images.SetKeyName(17, "document_text-remove.png")
        Me.ilExplorer.Images.SetKeyName(18, "folder.png")
        Me.ilExplorer.Images.SetKeyName(19, "folder-add.png")
        Me.ilExplorer.Images.SetKeyName(20, "folder-check.png")
        Me.ilExplorer.Images.SetKeyName(21, "folder-error.png")
        Me.ilExplorer.Images.SetKeyName(22, "folder-remove.png")
        Me.ilExplorer.Images.SetKeyName(23, "folder_open.png")
        Me.ilExplorer.Images.SetKeyName(24, "folder_open-add.png")
        Me.ilExplorer.Images.SetKeyName(25, "folder_open-check.png")
        Me.ilExplorer.Images.SetKeyName(26, "folder_open-error.png")
        Me.ilExplorer.Images.SetKeyName(27, "folder_open-remove.png")
        Me.ilExplorer.Images.SetKeyName(28, "notepad.png")
        Me.ilExplorer.Images.SetKeyName(29, "notepad-add.png")
        Me.ilExplorer.Images.SetKeyName(30, "notepad-check.png")
        Me.ilExplorer.Images.SetKeyName(31, "notepad-error.png")
        Me.ilExplorer.Images.SetKeyName(32, "notepad-remove.png")
        Me.ilExplorer.Images.SetKeyName(33, "book_open.png")
        Me.ilExplorer.Images.SetKeyName(34, "book_open-add.png")
        Me.ilExplorer.Images.SetKeyName(35, "book_open-check.png")
        Me.ilExplorer.Images.SetKeyName(36, "book_open-error.png")
        Me.ilExplorer.Images.SetKeyName(37, "book_open-remove.png")
        Me.ilExplorer.Images.SetKeyName(38, "database.png")
        Me.ilExplorer.Images.SetKeyName(39, "document_script.png")
        Me.ilExplorer.Images.SetKeyName(40, "query.png")
        Me.ilExplorer.Images.SetKeyName(41, "script.png")
        Me.ilExplorer.Images.SetKeyName(42, "table.png")
        Me.ilExplorer.Images.SetKeyName(43, "datasheet.png")
        '
        'ExplorerControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.atExplorer)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "ExplorerControl"
        Me.Size = New System.Drawing.Size(250, 383)
        CType(Me.atExplorer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents atExplorer As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents StyleManagerAmbient1 As DevComponents.DotNetBar.StyleManagerAmbient
    Friend WithEvents ilExplorer As ImageList
End Class
