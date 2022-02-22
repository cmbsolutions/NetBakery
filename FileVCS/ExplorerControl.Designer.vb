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
        Me.atExplorer = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
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
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.atExplorer)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(250, 383)
        CType(Me.atExplorer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents atExplorer As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
End Class
