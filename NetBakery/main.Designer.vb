<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tables", 0, 0)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Views", 1, 1)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Functions", 2, 2)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Procedures", 3, 3)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.checkSelector = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsbAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbInvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.tvObjects = New System.Windows.Forms.TreeView()
        Me.tvImages = New System.Windows.Forms.ImageList(Me.components)
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.cboDatabases = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabTable = New System.Windows.Forms.TabPage()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.sPreviewModel = New ScintillaNET.Scintilla()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.sPreviewMap = New ScintillaNET.Scintilla()
        Me.tabProcedure = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.scProcedure = New ScintillaNET.Scintilla()
        Me.cmdExecuteProcedure = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.cFieldName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cvbType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgProcedure = New System.Windows.Forms.DataGridView()
        Me.tabContext = New System.Windows.Forms.TabPage()
        Me.sPreviewContext = New ScintillaNET.Scintilla()
        Me.chkRecovery = New System.Windows.Forms.CheckBox()
        Me.txtContextName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdPreviewContext = New System.Windows.Forms.Button()
        Me.pContext = New System.Windows.Forms.Panel()
        Me.chkEnum = New System.Windows.Forms.CheckBox()
        Me.fbdExport = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.chkSsl = New System.Windows.Forms.CheckBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdDict = New System.Windows.Forms.Button()
        Me.checkSelector.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabTable.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage10.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage11.SuspendLayout()
        Me.TabPage12.SuspendLayout()
        Me.tabProcedure.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgProcedure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabContext.SuspendLayout()
        Me.pContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'checkSelector
        '
        Me.checkSelector.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAll, Me.tsbNone, Me.tsbInvert})
        Me.checkSelector.Name = "checkSelector"
        Me.checkSelector.Size = New System.Drawing.Size(155, 70)
        '
        'tsbAll
        '
        Me.tsbAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAll.Name = "tsbAll"
        Me.tsbAll.Size = New System.Drawing.Size(154, 22)
        Me.tsbAll.Text = "Select all"
        '
        'tsbNone
        '
        Me.tsbNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNone.Name = "tsbNone"
        Me.tsbNone.Size = New System.Drawing.Size(154, 22)
        Me.tsbNone.Text = "Select none"
        '
        'tsbInvert
        '
        Me.tsbInvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbInvert.Name = "tsbInvert"
        Me.tsbInvert.Size = New System.Drawing.Size(154, 22)
        Me.tsbInvert.Text = "Invert selection"
        '
        'tvObjects
        '
        Me.tvObjects.BackColor = System.Drawing.SystemColors.Window
        Me.tvObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvObjects.CheckBoxes = True
        Me.tvObjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvObjects.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvObjects.FullRowSelect = True
        Me.tvObjects.HideSelection = False
        Me.tvObjects.ImageIndex = 9
        Me.tvObjects.ImageList = Me.tvImages
        Me.tvObjects.Location = New System.Drawing.Point(0, 0)
        Me.tvObjects.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tvObjects.Name = "tvObjects"
        TreeNode1.Checked = True
        TreeNode1.ContextMenuStrip = Me.checkSelector
        TreeNode1.ImageIndex = 0
        TreeNode1.Name = "tables"
        TreeNode1.NodeFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode1.SelectedImageIndex = 0
        TreeNode1.Text = "Tables"
        TreeNode2.Checked = True
        TreeNode2.ContextMenuStrip = Me.checkSelector
        TreeNode2.ImageIndex = 1
        TreeNode2.Name = "views"
        TreeNode2.NodeFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode2.SelectedImageIndex = 1
        TreeNode2.Text = "Views"
        TreeNode3.Checked = True
        TreeNode3.ContextMenuStrip = Me.checkSelector
        TreeNode3.ImageIndex = 2
        TreeNode3.Name = "functions"
        TreeNode3.NodeFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode3.SelectedImageIndex = 2
        TreeNode3.Text = "Functions"
        TreeNode4.Checked = True
        TreeNode4.ContextMenuStrip = Me.checkSelector
        TreeNode4.ImageIndex = 3
        TreeNode4.Name = "procedures"
        TreeNode4.NodeFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode4.SelectedImageIndex = 3
        TreeNode4.Text = "Procedures"
        Me.tvObjects.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Me.tvObjects.PathSeparator = "."
        Me.tvObjects.SelectedImageIndex = 9
        Me.tvObjects.Size = New System.Drawing.Size(350, 514)
        Me.tvObjects.TabIndex = 0
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
        Me.tvImages.Images.SetKeyName(11, "question_frame.png")
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(91, 9)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(2)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(202, 25)
        Me.txtServer.TabIndex = 2
        Me.txtServer.Text = "localhost"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(376, 9)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(202, 25)
        Me.txtUser.TabIndex = 3
        Me.txtUser.Text = "root"
        '
        'txtPass
        '
        Me.txtPass.BackColor = System.Drawing.SystemColors.Window
        Me.txtPass.Location = New System.Drawing.Point(658, 9)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(202, 25)
        Me.txtPass.TabIndex = 4
        Me.txtPass.Text = "playstation2!"
        '
        'cboDatabases
        '
        Me.cboDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatabases.Enabled = False
        Me.cboDatabases.FormattingEnabled = True
        Me.cboDatabases.Location = New System.Drawing.Point(91, 38)
        Me.cboDatabases.Margin = New System.Windows.Forms.Padding(2)
        Me.cboDatabases.Name = "cboDatabases"
        Me.cboDatabases.Size = New System.Drawing.Size(300, 25)
        Me.cboDatabases.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Host:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(298, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(583, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Database:"
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(918, 9)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(75, 25)
        Me.cmdConnect.TabIndex = 10
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 68)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvObjects)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1427, 514)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.SplitterWidth = 8
        Me.SplitContainer1.TabIndex = 12
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.tabTable)
        Me.TabControl1.Controls.Add(Me.tabProcedure)
        Me.TabControl1.Controls.Add(Me.tabContext)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1069, 514)
        Me.TabControl1.TabIndex = 0
        '
        'tabTable
        '
        Me.tabTable.Controls.Add(Me.TabControl3)
        Me.tabTable.Location = New System.Drawing.Point(4, 29)
        Me.tabTable.Name = "tabTable"
        Me.tabTable.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTable.Size = New System.Drawing.Size(1061, 481)
        Me.tabTable.TabIndex = 4
        Me.tabTable.Text = "Table/View inspector"
        Me.tabTable.UseVisualStyleBackColor = True
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage9)
        Me.TabControl3.Controls.Add(Me.TabPage10)
        Me.TabControl3.Controls.Add(Me.TabPage11)
        Me.TabControl3.Controls.Add(Me.TabPage12)
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.Location = New System.Drawing.Point(3, 3)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(1055, 475)
        Me.TabControl3.TabIndex = 0
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.dgv1)
        Me.TabPage9.Location = New System.Drawing.Point(4, 26)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(1047, 445)
        Me.TabPage9.TabIndex = 0
        Me.TabPage9.Text = "Fields"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv1.Location = New System.Drawing.Point(3, 3)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(1041, 439)
        Me.dgv1.TabIndex = 12
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.dgv2)
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(1047, 449)
        Me.TabPage10.TabIndex = 1
        Me.TabPage10.Text = "Foreign keys"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv2.Location = New System.Drawing.Point(3, 3)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.RowHeadersVisible = False
        Me.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv2.Size = New System.Drawing.Size(1041, 443)
        Me.dgv2.TabIndex = 13
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.sPreviewModel)
        Me.TabPage11.Location = New System.Drawing.Point(4, 26)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage11.Size = New System.Drawing.Size(1047, 445)
        Me.TabPage11.TabIndex = 2
        Me.TabPage11.Text = "Model"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'sPreviewModel
        '
        Me.sPreviewModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sPreviewModel.CaretForeColor = System.Drawing.Color.Yellow
        Me.sPreviewModel.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sPreviewModel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sPreviewModel.IndentationGuides = ScintillaNET.IndentView.LookBoth
        Me.sPreviewModel.Lexer = ScintillaNET.Lexer.Vb
        Me.sPreviewModel.Location = New System.Drawing.Point(3, 3)
        Me.sPreviewModel.Name = "sPreviewModel"
        Me.sPreviewModel.ReadOnly = True
        Me.sPreviewModel.Size = New System.Drawing.Size(1041, 439)
        Me.sPreviewModel.TabIndex = 2
        Me.sPreviewModel.UseTabs = True
        '
        'TabPage12
        '
        Me.TabPage12.Controls.Add(Me.sPreviewMap)
        Me.TabPage12.Location = New System.Drawing.Point(4, 22)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage12.Size = New System.Drawing.Size(1047, 449)
        Me.TabPage12.TabIndex = 3
        Me.TabPage12.Text = "Mapping"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'sPreviewMap
        '
        Me.sPreviewMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sPreviewMap.CaretForeColor = System.Drawing.Color.Yellow
        Me.sPreviewMap.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sPreviewMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sPreviewMap.IndentationGuides = ScintillaNET.IndentView.LookBoth
        Me.sPreviewMap.Lexer = ScintillaNET.Lexer.Vb
        Me.sPreviewMap.Location = New System.Drawing.Point(3, 3)
        Me.sPreviewMap.Name = "sPreviewMap"
        Me.sPreviewMap.ReadOnly = True
        Me.sPreviewMap.Size = New System.Drawing.Size(1041, 443)
        Me.sPreviewMap.TabIndex = 3
        Me.sPreviewMap.UseTabs = True
        '
        'tabProcedure
        '
        Me.tabProcedure.Controls.Add(Me.TableLayoutPanel1)
        Me.tabProcedure.Location = New System.Drawing.Point(4, 25)
        Me.tabProcedure.Margin = New System.Windows.Forms.Padding(0)
        Me.tabProcedure.Name = "tabProcedure"
        Me.tabProcedure.Size = New System.Drawing.Size(1061, 485)
        Me.tabProcedure.TabIndex = 3
        Me.tabProcedure.Text = "Procedure inspector"
        Me.tabProcedure.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.95562!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.04438!))
        Me.TableLayoutPanel1.Controls.Add(Me.scProcedure, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdExecuteProcedure, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ListView1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dgProcedure, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1061, 485)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'scProcedure
        '
        Me.scProcedure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.scProcedure.CaretForeColor = System.Drawing.Color.Yellow
        Me.scProcedure.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.scProcedure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scProcedure.Lexer = ScintillaNET.Lexer.Sql
        Me.scProcedure.Location = New System.Drawing.Point(352, 3)
        Me.scProcedure.Name = "scProcedure"
        Me.scProcedure.ReadOnly = True
        Me.TableLayoutPanel1.SetRowSpan(Me.scProcedure, 3)
        Me.scProcedure.Size = New System.Drawing.Size(706, 479)
        Me.scProcedure.TabIndex = 3
        Me.scProcedure.UseTabs = True
        '
        'cmdExecuteProcedure
        '
        Me.cmdExecuteProcedure.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExecuteProcedure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdExecuteProcedure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExecuteProcedure.ForeColor = System.Drawing.Color.Red
        Me.cmdExecuteProcedure.Location = New System.Drawing.Point(0, 226)
        Me.cmdExecuteProcedure.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdExecuteProcedure.Name = "cmdExecuteProcedure"
        Me.cmdExecuteProcedure.Size = New System.Drawing.Size(349, 32)
        Me.cmdExecuteProcedure.TabIndex = 1
        Me.cmdExecuteProcedure.Text = "Execute procedure"
        Me.cmdExecuteProcedure.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cFieldName, Me.cvbType})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Location = New System.Drawing.Point(3, 261)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(343, 221)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'cFieldName
        '
        Me.cFieldName.Text = "Name"
        Me.cFieldName.Width = 188
        '
        'cvbType
        '
        Me.cvbType.Text = "Datatype"
        Me.cvbType.Width = 127
        '
        'dgProcedure
        '
        Me.dgProcedure.AllowUserToAddRows = False
        Me.dgProcedure.AllowUserToDeleteRows = False
        Me.dgProcedure.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgProcedure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProcedure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgProcedure.Location = New System.Drawing.Point(3, 3)
        Me.dgProcedure.MultiSelect = False
        Me.dgProcedure.Name = "dgProcedure"
        Me.dgProcedure.RowHeadersVisible = False
        Me.dgProcedure.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgProcedure.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgProcedure.Size = New System.Drawing.Size(343, 220)
        Me.dgProcedure.TabIndex = 4
        '
        'tabContext
        '
        Me.tabContext.Controls.Add(Me.sPreviewContext)
        Me.tabContext.Location = New System.Drawing.Point(4, 25)
        Me.tabContext.Name = "tabContext"
        Me.tabContext.Size = New System.Drawing.Size(1061, 485)
        Me.tabContext.TabIndex = 2
        Me.tabContext.Text = "Context"
        Me.tabContext.UseVisualStyleBackColor = True
        '
        'sPreviewContext
        '
        Me.sPreviewContext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sPreviewContext.CaretForeColor = System.Drawing.Color.Yellow
        Me.sPreviewContext.CaretLineBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sPreviewContext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sPreviewContext.IndentationGuides = ScintillaNET.IndentView.LookBoth
        Me.sPreviewContext.Lexer = ScintillaNET.Lexer.Vb
        Me.sPreviewContext.Location = New System.Drawing.Point(0, 0)
        Me.sPreviewContext.Name = "sPreviewContext"
        Me.sPreviewContext.ReadOnly = True
        Me.sPreviewContext.Size = New System.Drawing.Size(1061, 485)
        Me.sPreviewContext.TabIndex = 3
        Me.sPreviewContext.UseTabs = True
        '
        'chkRecovery
        '
        Me.chkRecovery.AutoSize = True
        Me.chkRecovery.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecovery.Location = New System.Drawing.Point(3, 36)
        Me.chkRecovery.Name = "chkRecovery"
        Me.chkRecovery.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkRecovery.Size = New System.Drawing.Size(138, 21)
        Me.chkRecovery.TabIndex = 3
        Me.chkRecovery.Text = "Generate recovery"
        Me.chkRecovery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRecovery.UseVisualStyleBackColor = True
        '
        'txtContextName
        '
        Me.txtContextName.Location = New System.Drawing.Point(109, 3)
        Me.txtContextName.Name = "txtContextName"
        Me.txtContextName.Size = New System.Drawing.Size(180, 25)
        Me.txtContextName.TabIndex = 13
        Me.txtContextName.Text = "MyCustom"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Contextname:"
        '
        'cmdPreviewContext
        '
        Me.cmdPreviewContext.Location = New System.Drawing.Point(155, 33)
        Me.cmdPreviewContext.Name = "cmdPreviewContext"
        Me.cmdPreviewContext.Size = New System.Drawing.Size(134, 25)
        Me.cmdPreviewContext.TabIndex = 15
        Me.cmdPreviewContext.Text = "Preview context"
        Me.cmdPreviewContext.UseVisualStyleBackColor = True
        '
        'pContext
        '
        Me.pContext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pContext.Controls.Add(Me.Label5)
        Me.pContext.Controls.Add(Me.cmdPreviewContext)
        Me.pContext.Controls.Add(Me.txtContextName)
        Me.pContext.Controls.Add(Me.chkRecovery)
        Me.pContext.Location = New System.Drawing.Point(1145, 5)
        Me.pContext.Name = "pContext"
        Me.pContext.Size = New System.Drawing.Size(294, 66)
        Me.pContext.TabIndex = 16
        Me.pContext.Visible = False
        '
        'chkEnum
        '
        Me.chkEnum.AutoSize = True
        Me.chkEnum.Checked = True
        Me.chkEnum.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnum.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnum.Location = New System.Drawing.Point(1025, 5)
        Me.chkEnum.Name = "chkEnum"
        Me.chkEnum.Size = New System.Drawing.Size(120, 21)
        Me.chkEnum.TabIndex = 17
        Me.chkEnum.Text = "Enum as String"
        Me.chkEnum.UseVisualStyleBackColor = True
        '
        'cmdExport
        '
        Me.cmdExport.Enabled = False
        Me.cmdExport.Location = New System.Drawing.Point(423, 37)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(127, 27)
        Me.cmdExport.TabIndex = 19
        Me.cmdExport.Text = "Export models"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'chkSsl
        '
        Me.chkSsl.AutoSize = True
        Me.chkSsl.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSsl.Location = New System.Drawing.Point(865, 11)
        Me.chkSsl.Name = "chkSsl"
        Me.chkSsl.Size = New System.Drawing.Size(48, 21)
        Me.chkSsl.TabIndex = 20
        Me.chkSsl.Text = "SSL"
        Me.chkSsl.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackgroundImage = Global.NetBakery.My.Resources.Resources.refresh
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.Location = New System.Drawing.Point(393, 37)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(29, 27)
        Me.cmdRefresh.TabIndex = 18
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdDict
        '
        Me.cmdDict.Location = New System.Drawing.Point(551, 37)
        Me.cmdDict.Name = "cmdDict"
        Me.cmdDict.Size = New System.Drawing.Size(127, 27)
        Me.cmdDict.TabIndex = 21
        Me.cmdDict.Text = "Custom dictionary"
        Me.cmdDict.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1451, 594)
        Me.Controls.Add(Me.cmdDict)
        Me.Controls.Add(Me.chkSsl)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chkEnum)
        Me.Controls.Add(Me.pContext)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboDatabases)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtServer)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "main"
        Me.Text = "Form1"
        Me.checkSelector.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabTable.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage10.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage11.ResumeLayout(False)
        Me.TabPage12.ResumeLayout(False)
        Me.tabProcedure.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgProcedure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabContext.ResumeLayout(False)
        Me.pContext.ResumeLayout(False)
        Me.pContext.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tvObjects As TreeView
    Friend WithEvents tvImages As ImageList
    Friend WithEvents txtServer As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents cboDatabases As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdConnect As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabContext As TabPage
    Friend WithEvents chkRecovery As CheckBox
    Friend WithEvents txtContextName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdPreviewContext As Button
    Friend WithEvents pContext As Panel
    Friend WithEvents chkEnum As CheckBox
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents fbdExport As FolderBrowserDialog
    Friend WithEvents cmdExport As Button
    Friend WithEvents chkSsl As CheckBox
    Friend WithEvents checkSelector As ContextMenuStrip
    Friend WithEvents tsbAll As ToolStripMenuItem
    Friend WithEvents tsbNone As ToolStripMenuItem
    Friend WithEvents tsbInvert As ToolStripMenuItem
    Friend WithEvents tabProcedure As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents scProcedure As ScintillaNET.Scintilla
    Friend WithEvents cmdExecuteProcedure As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents cFieldName As ColumnHeader
    Friend WithEvents cvbType As ColumnHeader
    Friend WithEvents dgProcedure As DataGridView
    Friend WithEvents cmdDict As Button
    Friend WithEvents tabTable As TabPage
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents dgv2 As DataGridView
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents sPreviewModel As ScintillaNET.Scintilla
    Friend WithEvents TabPage12 As TabPage
    Friend WithEvents sPreviewMap As ScintillaNET.Scintilla
    Friend WithEvents sPreviewContext As ScintillaNET.Scintilla
End Class
