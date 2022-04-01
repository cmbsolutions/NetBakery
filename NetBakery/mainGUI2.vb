Imports System.Text
Imports DevComponents
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json


Public Class mainGUI2
    Private _mngr As New infoSchema.manager
    Private _currentConnection As infoSchema.connection
    Private _connections As New infoSchema.connections

    Private _tracelistener As customTextTraceListener

    Private _dockFile As IO.FileInfo
    Private _connectionsFile As IO.FileInfo
    Private _setupFile As IO.FileInfo

    Private _currentProject As Project
    Private _loadingProject As Boolean = False
    Private _TreeGXUnique As Dictionary(Of String, Tree.Node)
    Private _FileManager As New FileVCS.Manager

#Region "Start and close"
    Private Sub mainGUI2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            _tracelistener = New customTextTraceListener(txtLog)
            Trace.Listeners.Add(_tracelistener)

            FormHelpers.upgradeMySettings()

            dnbStyleManager.ManagerStyle = DirectCast([Enum].Parse(GetType(eStyle), My.Settings.gui_style), eStyle)

            If My.Settings.isMaximized Then
                WindowState = FormWindowState.Maximized
            Else
                WindowState = FormWindowState.Normal
                Size = My.Settings.windowSize
            End If

            maxDepth.Value = My.Settings.maxERDiagramDepth

            TitleText = FormHelpers.ApplicationTitle
            Text = TitleText
            cboOutputType.SelectedIndex = 2
            ExplorerControl1.ExplorerManager = _FileManager

            _dockFile = New IO.FileInfo(String.Format("{0}\{1}\{2}\layout.xml", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CMBSolutions", "NetBakery"))

            If _dockFile.Exists Then
                dnbBarManager.LoadLayout(_dockFile.FullName)
            Else
                If Not _dockFile.Directory.Exists Then _dockFile.Directory.Create()
            End If

            _connectionsFile = New IO.FileInfo(String.Format("{0}\{1}\{2}\connections.bin", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CMBSolutions", "NetBakery"))

            If _connectionsFile.Exists Then
                _connections.LoadFromFile(_connectionsFile)
            Else
                If Not _connectionsFile.Directory.Exists Then _connectionsFile.Directory.Create()
            End If

            _connections.LoadFromNavicat()

            cboConnecions.ComboBoxEx.DataSource = (From c In _connections Select c.description).ToList
            cboConnecions.Refresh()

            setVbStyle(scCodePreview)
            setVbStyle(scGeneratedModel)
            setVbStyle(scGeneratedMapping)
            setSQLStyle(scRoutine)

            dcProjectSettings.Selected = True

            enableOrDisableFields()

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub mainGUI2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            My.Settings.isMaximized = WindowState = FormWindowState.Maximized
            My.Settings.windowSize = Size

            My.Settings.Save()

            dnbBarManager.SaveLayout(_dockFile.FullName)

            saveConnections()

            If _currentProject IsNot Nothing AndAlso _currentProject.needsSave Then
                If MessageBox.Show("Project has changed. Save changes?", "Save changes?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    btnSaveProject.RaiseClick()
                End If
            End If

            For Each frm As Form In My.Application.OpenForms
                If frm.Name <> Name Then
                    frm.Close()
                End If
            Next

            _connections.Dispose()
            _mngr.Dispose()

            _dockFile = Nothing
            _connectionsFile = Nothing

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

#Region "Main menu items"
    Private Sub btnFile_Close_Click(sender As Object, e As EventArgs) Handles btnFile_Close.Click
        Try
            Close()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub bERDiagram_Click(sender As Object, e As EventArgs) Handles bERDiagram.Click
        dcERDiagram.Visible = Not dcERDiagram.Visible
    End Sub

    Private Sub bProjectSettings_Click(sender As Object, e As EventArgs) Handles bProjectSettings.Click
        dcProjectSettings.Visible = Not dcProjectSettings.Visible
    End Sub

    Private Sub bObjectInfo_Click(sender As Object, e As EventArgs) Handles bObjectInfo.Click
        dcObjectInfo.Visible = Not dcObjectInfo.Visible
    End Sub

    Private Sub bCodePreview_Click(sender As Object, e As EventArgs) Handles bCodePreview.Click
        dcCodePreview.Visible = Not dcCodePreview.Visible
    End Sub
#End Region

#Region "Databases and connections tab"

    Private Sub btnNewConnection_Click(sender As Object, e As EventArgs) Handles btnNewConnection.Click
        Using frx = New connection_editor

            frx._conn = _connections

            If frx.ShowDialog = DialogResult.OK Then
                saveConnections()
                cboConnecions.ComboBoxEx.DataSource = (From c In _connections Select c.description).ToList
                cboConnecions.Refresh()
            End If
        End Using
    End Sub

    Private Sub saveConnections()
        Try

            '            Dim connectionsFile As New IO.FileInfo(String.Format("{0}\{1}\{2}\connections.bin", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CMBSolutions", "NetBakery"))

            _connections.SaveToFile(_connectionsFile)

            'connectionsFile = Nothing
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub cboConnecions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConnecions.SelectedIndexChanged
        Try
            Dim c = _connections.Where(Function(a) a.description = cboConnecions.Text).FirstOrDefault

            If c IsNot Nothing Then
                _currentConnection = c
                btnConnect.Pulse(10)
            Else
                _currentConnection = Nothing
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnEditConnection_Click(sender As Object, e As EventArgs) Handles btnEditConnection.Click
        Try
            If cboConnecions.Text = "" Then
                MessageBoxEx.Show("Select a connection to edit", "No connection")
                Exit Sub
            End If

            If _currentConnection IsNot Nothing Then
                If _currentConnection.fromNavicat Then
                    MessageBoxEx.Show("You lack administrator rights to edit a navicat connection.", "No connection")
                    Exit Sub
                End If
            End If

            Using frx = New connection_editor

                frx._conn = _connections
                frx.loadConnection(cboConnecions.Text)

                If frx.ShowDialog = DialogResult.OK Then
                    saveConnections()
                    cboConnecions.ComboBoxEx.DataSource = (From c In _connections Select c.description).ToList
                    cboConnecions.Refresh()
                End If
            End Using
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            btnConnect.StopPulse()

            If _currentConnection Is Nothing Then
                MessageBoxEx.Show("No connection selected")
                Exit Sub
            End If

            _mngr.initSchema()
            _mngr.connection = _currentConnection

            If _mngr.TryConnect() Then
                advtreeDatabases.Nodes.Clear()

                For Each db In _mngr.databases
                    Dim node As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .Text = db, .Name = db, .ContextMenu = dbNodes}

                    AddHandler node.NodeDoubleClick, AddressOf databaseNodeHandler
                    advtreeDatabases.Nodes.Add(node)
                Next
                advtreeDatabases.Refresh()
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub CloseDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseDatabaseToolStripMenuItem.Click
        advtreeDatabases.SelectedNode.Nodes.Clear()
    End Sub

    Private Sub toolbtnSettings_Click(sender As Object, e As EventArgs)
        Try
            Throw New NotImplementedException("Not implemented")

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

#Region "AdvTree database"
    Private Sub populateTreeNode(ByRef _databaseNode As AdvTree.Node)
        Try
            Dim tableNode As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 0, .Text = "Tables", .ContextMenu = ContextMenuStrip1}
            Dim viewNode As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 1, .Text = "Views", .ContextMenu = ContextMenuStrip1}
            Dim routineNode As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 2, .Text = "Routines", .ContextMenu = ContextMenuStrip1}
            Dim itemNode As New AdvTree.Node With {.CheckBoxVisible = True, .Checked = True, .Editable = False, .DragDropEnabled = False}

            tableNode.Cells.Add(New AdvTree.Cell With {.Editable = False, .Text = "0", .TextDisplayFormat = "(0)", .ImageAlignment = AdvTree.eCellPartAlignment.NearCenter})
            viewNode.Cells.Add(New AdvTree.Cell With {.Editable = False, .Text = "0", .TextDisplayFormat = "(0)", .ImageAlignment = AdvTree.eCellPartAlignment.NearCenter})
            routineNode.Cells.Add(New AdvTree.Cell With {.Editable = False, .Text = "0", .TextDisplayFormat = "(0)", .ImageAlignment = AdvTree.eCellPartAlignment.NearCenter})

            ' Process all tables/views
            For Each table In _mngr.tables.Where(Function(c) c.isView = False)
                ' Clone the templates
                Dim tmpNode = itemNode.DeepCopy
                Dim tmpCell = New AdvTree.Cell With {.Editable = False, .Text = "0", .TextDisplayFormat = "(0)", .ImageAlignment = AdvTree.eCellPartAlignment.NearCenter}

                tmpCell.Text = table.columns.Count.ToString
                tmpNode.Text = table.name
                tmpNode.Cells.Add(tmpCell)

                AddHandler tmpNode.NodeClick, AddressOf tableNodeHandler

                tableNode.Nodes.Add(tmpNode)
            Next

            For Each view In _mngr.tables.Where(Function(c) c.isView = True)
                ' Clone the templates
                Dim tmpNode = itemNode.DeepCopy
                Dim tmpCell = New AdvTree.Cell With {.Editable = False, .Text = "0", .TextDisplayFormat = "(0)", .ImageAlignment = AdvTree.eCellPartAlignment.NearCenter}

                tmpCell.Text = view.columns.Count.ToString
                tmpNode.Text = view.name
                tmpNode.Cells.Add(tmpCell)

                AddHandler tmpNode.NodeClick, AddressOf viewNodeHandler
                viewNode.Nodes.Add(tmpNode)
            Next

            ' Process all routines
            For Each routine In _mngr.routines
                ' Clone the templates
                Dim tmpNode = itemNode.DeepCopy
                tmpNode.Text = routine.name

                AddHandler tmpNode.NodeClick, AddressOf routineNodeHandler

                routineNode.Nodes.Add(tmpNode)
            Next

            tableNode.Cells.Item(1).Text = tableNode.Nodes.Count.ToString
            viewNode.Cells.Item(1).Text = viewNode.Nodes.Count.ToString
            routineNode.Cells.Item(1).Text = routineNode.Nodes.Count.ToString

            _databaseNode.Nodes.AddRange(New AdvTree.Node() {tableNode, viewNode, routineNode})

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub databaseNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            For Each n As AdvTree.Node In advtreeDatabases.Nodes
                If n.Nodes.Count > 0 Then
                    n.Nodes.Clear()
                    n.Expanded = False

                    Exit For
                End If
            Next

            _mngr.SetDatabase(node.Text)
            _mngr.harvestObjects()

            populateTreeNode(node)

            node.Expand()

            WriteProject()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub tableNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)


            If nodeEvent.Button = MouseButtons.Left Then
                Dim tableFields = (From f In _mngr.tables Where f.isView = False AndAlso f.name = node.Text Select f).FirstOrDefault

                If tableFields IsNot Nothing Then
                    dgvFields.DataSource = tableFields.columns.ToArray

                    Dim fks = (From fk In tableFields.foreignKeys
                               From col In fk.columns
                               From refcol In fk.referencedColumns
                               Select New With {
                                            Key fk.name,
                                            .Table = fk.table.name,
                                            .Column = col.column.name,
                                            .Position = col.fkPosition,
                                            .RefTable = fk.referencedTable.name,
                                            .RefColumn = refcol.column.name,
                                            .Alias = fk.propertyAlias
                                })


                    dgvForeignKeys.DataSource = fks.ToArray

                    scGeneratedModel.Text = _mngr.generateModel(tableFields)
                    scGeneratedModel.Colorize(0, scGeneratedModel.Text.Length)

                    scGeneratedMapping.Text = _mngr.generateMap(tableFields)
                    scGeneratedMapping.Colorize(0, scGeneratedMapping.Text.Length)

                    scRoutine.Text = tableFields.definition
                    scRoutine.Colorize(0, scRoutine.Text.Length)

                    Dim idxs = (From idx In tableFields.indexes
                                From col In idx.columns
                                Select New With {
                                            Key idx.Name,
                                            .Unique = idx.IsUnique,
                                            .Nullable = idx.IsNullable,
                                            .Column = col.column.name,
                                            .Position = col.indexPosition
                                })
                    dgvIndexes.DataSource = idxs.ToArray

                    Dim refs = (From ref In tableFields.relations
                                Select New With {
                                    Key ref.alias,
                                    .Table = ref.toTable.name,
                                    .Column = ref.toColumn.name,
                                    .LocalColumn = ref.localColumn.name
                                })
                    dgvReferences.DataSource = refs.ToArray

                    LoadTreeGXTableClass(tableFields)

                End If

                dgvFields.Refresh()
                dgvForeignKeys.Refresh()
                dgvIndexes.Refresh()
                dgvReferences.Refresh()

                dcObjectInfo.Selected = True
                TabControl1.SelectedPanel = TabControlPanel1

            End If


            _mngr.tables.First(Function(c) c.name = node.Text).hasExport = node.Checked


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

#Region "TreeGX"
    Private Sub LoadTreeGXTableClass(ByVal rootTable As infoSchema.table)
        Try
            _TreeGXUnique = New Dictionary(Of String, Tree.Node)
            TreeGX1.BeginUpdate()
            TreeGX1.Nodes.Clear()
            TreeGX1.LayoutType = Tree.eNodeLayout.Map

            Dim node As New Tree.Node With {
                .Text = rootTable.name,
                .Name = rootTable.name,
                .Expanded = True
            }

            _TreeGXUnique.Add(rootTable.name, node)

            TreeGX1.Nodes.Add(node)

            For Each fk In rootTable.foreignKeys
                node.Nodes.AddRange(GetForeignKeyNodes(fk.referencedTable).ToArray)
            Next

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        Finally
            TreeGX1.EndUpdate()
        End Try
        _TreeGXUnique.Clear()

    End Sub

    Private Function GetForeignKeyNodes(t As infoSchema.table) As List(Of Tree.Node)
        Dim nodes As New List(Of Tree.Node)
        Try
            Dim n As New Tree.Node With {
                          .Text = t.name,
                          .Name = t.name,
                          .Expanded = True
                }

            nodes.Add(n)

            For Each fk In t.foreignKeys
                n.Nodes.AddRange(GetForeignKeyNodes(fk.referencedTable).ToArray)
            Next


        Catch ex As Exception

        End Try

        Return nodes

    End Function

    Private Sub LoadTableChildren(parent As infoSchema.table, ByRef parentNode As DevComponents.Tree.Node, currentDepth As Integer)
        Try
            If currentDepth > My.Settings.maxERDiagramDepth Then Exit Sub

            For Each child In parent.children
                Dim node As Tree.Node = Nothing

                If Not _TreeGXUnique.TryGetValue(child.name, node) Then
                    node = New Tree.Node With {
                        .Text = child.name,
                        .Name = child.name,
                        .Expanded = True
                    }

                    _TreeGXUnique.Add(child.name, node)

                    If currentDepth = My.Settings.maxERDiagramDepth Then
                        node.Style = ElementStyle4
                    Else
                        node.Style = ElementStyle3
                    End If

                    parentNode.Nodes.Add(node)
                Else
                    If Not node.Equals(parentNode) Then
                        parentNode.Nodes.Add(node)
                    End If
                End If

                LoadTableChildren(child, node, currentDepth + 1)
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
            Trace.WriteLine($"parent:{parent.name}, node: {parentNode.Name}, depth: {currentDepth}")
        End Try
    End Sub

    Private Sub maxDepth_ValueChanged(sender As Object, e As EventArgs) Handles maxDepth.ValueChanged
        My.Settings.maxERDiagramDepth = CInt(maxDepth.Value)
    End Sub

    Private Sub sliderZoom_ValueChanged(sender As Object, e As EventArgs) Handles sliderZoom.ValueChanged
        TreeGX1.Zoom = CSng(sliderZoom.Value / 100)
        sliderZoom.Text = $"{sliderZoom.Value}%"
    End Sub

    Private Sub LoadTreeGXTableClasses()

        _TreeGXUnique = New Dictionary(Of String, Tree.Node)

        TreeGX1.BeginUpdate()
        TreeGX1.Nodes.Clear()
        TreeGX1.LayoutType = Tree.eNodeLayout.Map

        Dim rootNode As New Tree.Node With {
            .Name = _mngr.GetDatabase,
            .Text = .Name,
            .Expanded = True
        }
        TreeGX1.Nodes.Add(rootNode)

        Try
            For Each t In _mngr.tables.Where(Function(c) Not c.isView)
                LoadTableUnique(t, rootNode)
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        Finally
            TreeGX1.EndUpdate()
        End Try
    End Sub

    Private Sub LoadTableUnique(table As infoSchema.table, parentNode As DevComponents.Tree.Node)
        Try
            Dim node As Tree.Node = Nothing

            If Not _TreeGXUnique.TryGetValue(table.name, node) Then
                node = New Tree.Node With {
                    .Text = table.name,
                    .Name = table.name,
                    .Expanded = True
                    }
                parentNode.Nodes.Add(node)
                _TreeGXUnique.Add(table.name, node)

            Else
                'If Not node.Equals(parentNode) Then parentNode.Nodes.Add(node)
                Dim pn = (From p As Tree.Node In parentNode.Nodes.OfType(Of Tree.Node) Where p.Name = table.name Select p).FirstOrDefault

                If pn Is Nothing Then
                    If Not node.Equals(parentNode) Then parentNode.Nodes.Add(node)
                Else
                    Dim ln As New Tree.LinkedNode With {
                        .Node = node
                    }
                    parentNode.LinkedNodes.Add(ln)
                End If
            End If

            For Each child In table.children.Where(Function(c) Not c.Equals(table))
                LoadTableUnique(child, node)
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

    Private Sub viewNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            If nodeEvent.Button = MouseButtons.Left Then
                Dim viewFields = (From f In _mngr.tables Where f.isView = True AndAlso f.name = node.Text Select f).FirstOrDefault

                If viewFields IsNot Nothing Then
                    dgvFields.DataSource = viewFields.columns.ToArray

                    dgvForeignKeys.DataSource = Nothing
                    dgvIndexes.DataSource = Nothing
                    dgvReferences.DataSource = Nothing

                    scGeneratedModel.Text = _mngr.generateModel(viewFields)
                    scGeneratedModel.Colorize(0, scGeneratedModel.Text.Length)

                    scGeneratedMapping.Text = _mngr.generateMap(viewFields)
                    scGeneratedMapping.Colorize(0, scGeneratedMapping.Text.Length)

                    scRoutine.Text = viewFields.definition
                    scRoutine.Colorize(0, scRoutine.Text.Length)
                End If

                dgvFields.Refresh()
                dgvForeignKeys.Refresh()
                dgvIndexes.Refresh()
                dgvReferences.Refresh()

                dcObjectInfo.Selected = True
                TabControl1.SelectedPanel = TabControlPanel1
            End If


            _mngr.tables.First(Function(c) c.name = node.Text).hasExport = node.Checked


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub routineNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            If nodeEvent.Button = MouseButtons.Left Then
                Dim rout = _mngr.routines.FirstOrDefault(Function(c) c.name = node.Text)

                If rout IsNot Nothing Then
                    If rout.returnsRecordset Then
                        dgvFields.DataSource = rout.returnLayout.columns.ToArray

                        dgvForeignKeys.DataSource = Nothing
                        dgvIndexes.DataSource = Nothing
                        dgvReferences.DataSource = Nothing

                        scGeneratedModel.Text = _mngr.generateModel(rout.returnLayout)
                        scGeneratedModel.Colorize(0, scGeneratedModel.Text.Length)
                    Else
                        dgvFields.DataSource = Nothing
                        dgvForeignKeys.DataSource = Nothing
                        dgvIndexes.DataSource = Nothing
                        dgvReferences.DataSource = Nothing
                    End If

                    scRoutine.Text = rout.definition
                    scRoutine.Colorize(0, scRoutine.Text.Length)
                End If
                dgvFields.Refresh()
                dgvForeignKeys.Refresh()
                dgvIndexes.Refresh()
                dgvReferences.Refresh()


                dcObjectInfo.Selected = True
                TabControl1.SelectedPanel = TabControlPanel1
            End If


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub


#End Region

#Region "outputExplorer"
    Private Sub btnHomeOutputExplorer_Click(sender As Object, e As EventArgs) Handles btnHomeOutputExplorer.Click
        Try
            If _currentProject IsNot Nothing Then
                Select Case _currentProject.outputtype.ToLower
                    Case "net5"
                        Using ts As New IO.StringReader(My.Resources.net5OutputExplorer)
                            advtreeOutputExplorer.Nodes.Clear()
                            advtreeOutputExplorer.Load(ts)
                        End Using
                    Case "php"
                        Using ts As New IO.StringReader(My.Resources.phpOutputExplorer)
                            advtreeOutputExplorer.Nodes.Clear()
                            advtreeOutputExplorer.Load(ts)
                        End Using
                    Case Else
                        Using ts As New IO.StringReader(My.Resources.defaultOutputExplorer)
                            advtreeOutputExplorer.Nodes.Clear()
                            advtreeOutputExplorer.Load(ts)
                        End Using
                End Select
            End If
            advtreeOutputExplorer.Refresh()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnRefreshOutputExplorer_Click(sender As Object, e As EventArgs) Handles btnRefreshOutputExplorer.Click
        Try
            If _currentProject IsNot Nothing Then
                Select Case _currentProject.outputtype.ToLower
                    Case "net5"
                        Using ts As New IO.StringReader(My.Resources.net5OutputExplorer)
                            advtreeOutputExplorer.Nodes.Clear()
                            advtreeOutputExplorer.Load(ts)
                        End Using
                    Case "php"
                        Using ts As New IO.StringReader(My.Resources.phpOutputExplorer)
                            advtreeOutputExplorer.Nodes.Clear()
                            advtreeOutputExplorer.Load(ts)
                        End Using
                    Case Else
                        Using ts As New IO.StringReader(My.Resources.defaultOutputExplorer)
                            advtreeOutputExplorer.Nodes.Clear()
                            advtreeOutputExplorer.Load(ts)
                        End Using
                End Select
            End If
            advtreeOutputExplorer.Refresh()

            'TODO: Move this code to FileVCS.dll
            Dim tplModelAndMapping As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 13}
            Dim tplContextAndStoreCommands As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 8}
            Dim tplFunctions As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 28}
            Dim tplProcedures As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 33}

            If _currentProject IsNot Nothing AndAlso _currentProject.outputtype.ToLower = "php" Then
                Dim mModel As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapModels", True).FirstOrDefault
                Dim mMapping As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapMapping", True).FirstOrDefault

                ' Tables and views
                For Each table In _mngr.tables.Where(Function(t) t.hasExport)
                    Dim tmpModel As AdvTree.Node = tplModelAndMapping.DeepCopy
                    Dim tmpMapping As AdvTree.Node = tplModelAndMapping.DeepCopy

                    tmpModel.Name = "n" & table.name
                    tmpModel.TagString = table.name

                    tmpModel.Text = $"{table.singleName}.php"
                    AddHandler tmpModel.NodeClick, AddressOf explorerModelNodeHandler

                    If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpModel.Text) > 0 Then
                        tmpModel.ImageIndex += 3
                        If mModel.ImageIndex = 18 Then
                            mModel.ImageIndex += 3
                            mModel.ImageExpandedIndex += 3
                        End If
                    End If

                    mModel.Nodes.Add(tmpModel)

                    tmpMapping.Name = $"n{table.name}Table"
                    tmpMapping.TagString = table.name
                    tmpMapping.Text = $"{table.pluralName}Table.php"
                    AddHandler tmpMapping.NodeClick, AddressOf explorerMappingNodeHandler

                    If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpMapping.Text) > 0 Then
                        tmpMapping.ImageIndex += 3
                        If mMapping.ImageIndex = 18 Then
                            mMapping.ImageIndex += 3
                            mMapping.ImageExpandedIndex += 3
                        End If
                    End If

                    mMapping.Nodes.Add(tmpMapping)
                Next

            Else
                Dim mModel As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapModels", True).FirstOrDefault
                Dim mMapping As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapMapping", True).FirstOrDefault
                Dim mStoreCommands As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapStoreCommands", True).FirstOrDefault
                Dim mStoreCommandFunctions As AdvTree.Node = mStoreCommands.Nodes.Find("mapStoreCommandFunctions", True).FirstOrDefault
                Dim mStoreCommandFunctionModels As AdvTree.Node

                If mStoreCommandFunctions IsNot Nothing Then
                    mStoreCommandFunctionModels = mStoreCommandFunctions.Nodes.Find("mapStoreCommandFunctionModels", True).FirstOrDefault
                Else
                    mStoreCommandFunctionModels = mStoreCommands.Nodes.Find("mapStoreCommandModels", True).FirstOrDefault
                End If

                Dim mStoreCommandsProcedures As AdvTree.Node = mStoreCommands.Nodes.Find("mapStoreCommandProcedures", True).FirstOrDefault
                Dim mStoreCommandModels As AdvTree.Node

                If mStoreCommandsProcedures IsNot Nothing Then
                    mStoreCommandModels = mStoreCommandsProcedures.Nodes.Find("mapStoreCommandModels", True).FirstOrDefault
                Else
                    mStoreCommandModels = mStoreCommands.Nodes.Find("mapStoreCommandModels", True).FirstOrDefault
                End If


                ' Tables and views
                For Each table In _mngr.tables.Where(Function(t) t.hasExport)
                    Dim tmpModel As AdvTree.Node = tplModelAndMapping.DeepCopy
                    Dim tmpMapping As AdvTree.Node = tplModelAndMapping.DeepCopy

                    tmpModel.Name = "n" & table.name
                    tmpModel.TagString = table.name

                    tmpModel.Text = $"{table.singleName}.vb"
                    AddHandler tmpModel.NodeClick, AddressOf explorerModelNodeHandler
                    If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpModel.Text) > 0 Then
                        tmpModel.ImageIndex += 3
                        If mModel.ImageIndex = 18 Then
                            mModel.ImageIndex += 3
                            mModel.ImageExpandedIndex += 3
                        End If
                    End If
                    mModel.Nodes.Add(tmpModel)

                    tmpMapping.Name = $"n{table.name}Map"
                    tmpMapping.TagString = table.name
                    tmpMapping.Text = $"{table.singleName}Map.vb"
                    AddHandler tmpMapping.NodeClick, AddressOf explorerMappingNodeHandler
                    If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpMapping.Text) > 0 Then
                        tmpMapping.ImageIndex += 3
                        If mMapping.ImageIndex = 18 Then
                            mMapping.ImageIndex += 3
                            mMapping.ImageExpandedIndex += 3
                        End If
                    End If
                    mMapping.Nodes.Add(tmpMapping)
                Next

                ' Routines
                For Each routine In _mngr.routines.Where(Function(r) r.hasExport)
                    Dim tmpNode As AdvTree.Node

                    If routine.isFunction Then
                        tmpNode = tplFunctions.DeepCopy
                    Else
                        tmpNode = tplProcedures.DeepCopy
                    End If

                    tmpNode.Name = $"n{routine.name}"
                    tmpNode.TagString = routine.name
                    tmpNode.Text = $"{routine.name}.vb"
                    AddHandler tmpNode.NodeClick, AddressOf explorerRoutineNodeHandler
                    If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpNode.Text) > 0 Then
                        tmpNode.ImageIndex += 3
                    End If

                    If routine.isFunction Then
                        If mStoreCommandFunctions IsNot Nothing Then
                            mStoreCommandFunctions.Nodes.Add(tmpNode)
                        End If
                    Else
                        If mStoreCommandsProcedures IsNot Nothing Then
                            mStoreCommandsProcedures.Nodes.Add(tmpNode)
                        End If
                    End If

                    If routine.returnsRecordset Then
                        If routine.isFunction Then
                            tmpNode = tplModelAndMapping.DeepCopy
                            tmpNode.Name = routine.returnLayout.name
                            tmpNode.TagString = routine.name
                            tmpNode.Text = routine.returnLayout.name
                            AddHandler tmpNode.NodeClick, AddressOf explorerRoutineModelNodeHandler
                            If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpNode.Text) > 0 Then
                                tmpNode.ImageIndex += 3
                                If mStoreCommandFunctionModels.ImageIndex = 23 Then mStoreCommandFunctionModels.ImageIndex += 3
                            End If

                            If mStoreCommandFunctionModels.Nodes.Find(tmpNode.Name, True).Length = 0 Then mStoreCommandFunctionModels.Nodes.Add(tmpNode)
                        Else
                            tmpNode = tplModelAndMapping.DeepCopy
                            tmpNode.Name = $"n{routine.name}Model"
                            tmpNode.TagString = routine.name
                            tmpNode.Text = $"{routine.name}Model.vb"
                            AddHandler tmpNode.NodeClick, AddressOf explorerRoutineModelNodeHandler
                            If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpNode.Text) > 0 Then
                                tmpNode.ImageIndex += 3
                                If mStoreCommandModels.ImageIndex = 23 Then mStoreCommandModels.ImageIndex += 3
                            End If
                            mStoreCommandModels.Nodes.Add(tmpNode)
                        End If
                    End If
                Next

                ' Context
                Dim tmpContext As AdvTree.Node = tplContextAndStoreCommands.DeepCopy

                tmpContext.Name = "nContext"
                tmpContext.Text = $"{txtProjectName.Text}Context.vb"
                AddHandler tmpContext.NodeClick, AddressOf explorerContextNodeHandler
                If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpContext.Text) > 0 Then
                    tmpContext.ImageIndex += 3
                End If
                mModel.Nodes.Add(tmpContext)

                If _currentProject IsNot Nothing AndAlso _currentProject.outputtype.ToLower = "net" Then
                    ' StoreCommandsContext
                    tmpContext = tplContextAndStoreCommands.DeepCopy

                    tmpContext.Name = "nStoreCommandsContext"
                    tmpContext.Text = $"{txtProjectName.Text}StoreCommandsContext.vb"
                    AddHandler tmpContext.NodeClick, AddressOf explorerStoreCommandsNodeHandler
                    If _FileManager.ChangedFiles.LongCount(Function(c) c.filename = tmpContext.Text) > 0 Then
                        tmpContext.ImageIndex += 3
                    End If
                    mModel.Nodes.Add(tmpContext)
                End If
            End If
            advtreeOutputExplorer.Refresh()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnSaveLayout_Click(sender As Object, e As EventArgs) Handles btnSaveLayout.Click
        Try
            If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models")
            If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models\Mapping") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models\Mapping")

            If _currentProject IsNot Nothing AndAlso _currentProject.outputtype.ToLower = "net5" Then
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models\StoreCommands") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models\StoreCommands")
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models\StoreCommands\Functions") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models\StoreCommands\Functions")
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models\StoreCommands\Functions\Models") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models\StoreCommands\Functions\Models")
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models\StoreCommands\Procedures") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models\StoreCommands\Procedures")
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models\StoreCommands\Procedures\Models") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models\StoreCommands\Procedures\Models")
            Else
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\Models\StoreCommandSchemas") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\Models\StoreCommandSchemas")
            End If

            For Each t In _mngr.tables.Where(Function(c) c.hasExport)
                IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\{t.singleName}.vb", _mngr.generateModel(t))
                IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\Mapping\{t.singleName}Map.vb", _mngr.generateMap(t))
            Next

            For Each s In _mngr.routines.Where(Function(c) c.hasExport)
                If _currentProject IsNot Nothing AndAlso _currentProject.outputtype.ToLower = "net5" Then
                    If s.isFunction Then
                        IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\StoreCommands\Functions\{s.name}.vb", _mngr.generateStoreCommand(s, $"{txtProjectName.Text}", sbProcedureLocks.Value))
                        IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\StoreCommands\Functions\Models\{s.returnLayout.singleName}.vb", _mngr.generateModel(s.returnLayout))
                    Else
                        IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\StoreCommands\Procedures\{s.name}.vb", _mngr.generateStoreCommand(s, $"{txtProjectName.Text}", sbProcedureLocks.Value))
                        If s.returnsRecordset Then
                            IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\StoreCommands\Procedures\Models\{s.returnLayout.singleName}.vb", _mngr.generateModel(s.returnLayout))
                        End If
                    End If
                Else
                    If s.returnsRecordset Then
                        IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\StoreCommandSchemas\{s.returnLayout.singleName}.vb", _mngr.generateModel(s.returnLayout))
                    End If
                End If
            Next

            IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\{txtProjectName.Text}DataContext.vb", _mngr.generateContext($"{txtProjectName.Text}"))

            If _currentProject IsNot Nothing AndAlso _currentProject.outputtype.ToLower = "net" Then
                IO.File.WriteAllText($"{txtOutputFolder.Text}\Models\{txtProjectName.Text}StoreCommands.vb", _mngr.generateStoreCommands($"{txtProjectName.Text}", sbProcedureLocks.Value))
            End If

            WriteProject()
            _FileManager.OriginalFiles = _FileManager.CurrentFiles
            _currentProject.generatedoutputs = _FileManager.OriginalFiles

            _FileManager.ScanForFiles(_currentProject.projectoutputlocation)

            ExplorerControl1.RefreshExplorer()

            MessageBox.Show("Output generated")
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub explorerModelNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            Dim t = _mngr.tables.FirstOrDefault(Function(c) c.name = node.TagString)

            If t IsNot Nothing Then
                scCodePreview.Text = _mngr.generateModel(t)
                scCodePreview.Colorize(0, scCodePreview.Text.Length)
                dcCodePreview.Selected = True
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerMappingNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            Dim t = _mngr.tables.FirstOrDefault(Function(c) c.name = node.TagString)

            If t IsNot Nothing Then
                scCodePreview.Text = _mngr.generateMap(t)
                scCodePreview.Colorize(0, scCodePreview.Text.Length)
                dcCodePreview.Selected = True
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerRoutineNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            Dim r = _mngr.routines.FirstOrDefault(Function(c) c.name = node.TagString)

            If r IsNot Nothing Then
                scCodePreview.Text = _mngr.generateStoreCommand(r, $"{txtProjectName.Text}Data", sbProcedureLocks.Value)
                scCodePreview.Colorize(0, scCodePreview.Text.Length)
                dcCodePreview.Selected = True
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerRoutineModelNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            Dim r = _mngr.routines.FirstOrDefault(Function(c) c.name = node.TagString)

            If r IsNot Nothing AndAlso r.returnLayout IsNot Nothing Then
                scCodePreview.Text = _mngr.generateModel(r.returnLayout)
                scCodePreview.Colorize(0, scCodePreview.Text.Length)
                dcCodePreview.Selected = True
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub explorerContextNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            scCodePreview.Text = _mngr.generateContext(txtProjectName.Text)
            scCodePreview.Colorize(0, scCodePreview.Text.Length)
            dcCodePreview.Selected = True

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerStoreCommandsNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            scCodePreview.Text = _mngr.generateStoreCommands(txtProjectName.Text, sbProcedureLocks.Value)
            scCodePreview.Colorize(0, scCodePreview.Text.Length)
            dcCodePreview.Selected = True

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

#Region "Logging"

#End Region

#Region "Contextmenus"
    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Try
            For Each n As AdvTree.Node In advtreeDatabases.SelectedNode.Nodes
                n.Checked = True

                Select Case advtreeDatabases.SelectedNode.Text
                    Case "Tables", "Views"
                        _mngr.tables.First(Function(c) c.name = n.Text).hasExport = n.Checked
                    Case "Routines"
                        _mngr.routines.First(Function(c) c.name = n.Text).hasExport = n.Checked
                    Case Else
                        'Dunno
                End Select
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Try
            For Each n As AdvTree.Node In advtreeDatabases.SelectedNode.Nodes
                n.Checked = False

                Select Case advtreeDatabases.SelectedNode.Text
                    Case "Tables", "Views"
                        _mngr.tables.First(Function(c) c.name = n.Text).hasExport = n.Checked
                    Case "Routines"
                        _mngr.routines.First(Function(c) c.name = n.Text).hasExport = n.Checked
                    Case Else
                        'Dunno
                End Select
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub InvertSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvertSelectionToolStripMenuItem.Click
        Try
            For Each n As AdvTree.Node In advtreeDatabases.SelectedNode.Nodes
                n.Checked = Not n.Checked

                Select Case advtreeDatabases.SelectedNode.Text
                    Case "Tables", "Views"
                        _mngr.tables.First(Function(c) c.name = n.Text).hasExport = n.Checked
                    Case "Routines"
                        _mngr.routines.First(Function(c) c.name = n.Text).hasExport = n.Checked
                    Case Else
                        'Dunno
                End Select
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

#Region "Scintilla lexer styles"

    Private Sub ResetLexer(lexer As ScintillaNET.Scintilla)
        lexer.StyleClearAll()

        lexer.HScrollBar = True
        lexer.VScrollBar = True

        lexer.Styles(ScintillaNET.Style.Default).BackColor = Color.FromArgb(30, 30, 30)
        lexer.Styles(ScintillaNET.Style.Default).Font = "Consolas"
        lexer.Styles(ScintillaNET.Style.Default).ForeColor = Color.FromArgb(220, 220, 220)
        lexer.Styles(ScintillaNET.Style.Default).Size = 10

        lexer.Styles(ScintillaNET.Style.LineNumber).BackColor = Color.FromArgb(30, 30, 30)
        lexer.Styles(ScintillaNET.Style.LineNumber).ForeColor = Color.FromArgb(43, 145, 175)
        lexer.Styles(ScintillaNET.Style.LineNumber).Font = lexer.Styles(ScintillaNET.Style.Default).Font
        lexer.Styles(ScintillaNET.Style.LineNumber).Size = lexer.Styles(ScintillaNET.Style.Default).Size

        lexer.Margins(0).Type = ScintillaNET.MarginType.Number
        lexer.Margins(0).Width = 30
    End Sub
    Private Sub setVbStyle(lexer As ScintillaNET.Scintilla)
        Try

            ResetLexer(lexer)

            lexer.Lexer = ScintillaNET.Lexer.Vb

            lexer.CreateDocument()

            lexer.Styles(ScintillaNET.Style.Vb.Default).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Default).ForeColor = lexer.Styles(ScintillaNET.Style.Default).ForeColor
            lexer.Styles(ScintillaNET.Style.Vb.Comment).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Comment).ForeColor = Color.FromArgb(87, 166, 74)
            lexer.Styles(ScintillaNET.Style.Vb.Comment).Italic = True
            lexer.Styles(ScintillaNET.Style.Vb.Number).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Number).ForeColor = Color.FromArgb(181, 206, 168)
            lexer.Styles(ScintillaNET.Style.Vb.Keyword).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Keyword).ForeColor = Color.FromArgb(86, 156, 214)
            lexer.Styles(ScintillaNET.Style.Vb.[String]).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.[String]).ForeColor = Color.FromArgb(255, 128, 0)
            lexer.Styles(ScintillaNET.Style.Vb.Preprocessor).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Preprocessor).ForeColor = Color.Gainsboro
            lexer.Styles(ScintillaNET.Style.Vb.[Operator]).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.[Operator]).ForeColor = Color.FromArgb(-4934476)
            lexer.Styles(ScintillaNET.Style.Vb.Identifier).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Identifier).ForeColor = Color.Gainsboro
            lexer.Styles(ScintillaNET.Style.Vb.[Date]).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.[Date]).ForeColor = Color.Green
            lexer.Styles(ScintillaNET.Style.Vb.StringEol).ForeColor = Color.Navy
            lexer.Styles(ScintillaNET.Style.Vb.Keyword2).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Keyword2).ForeColor = Color.Olive
            lexer.Styles(ScintillaNET.Style.Vb.Keyword3).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Keyword3).ForeColor = Color.Purple
            lexer.Styles(ScintillaNET.Style.Vb.Keyword4).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Keyword4).ForeColor = Color.Teal
            lexer.Styles(ScintillaNET.Style.Vb.Constant).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Constant).ForeColor = Color.Gray
            lexer.Styles(ScintillaNET.Style.Vb.Asm).ForeColor = Color.FromArgb(-4194304)
            lexer.Styles(ScintillaNET.Style.Vb.Label).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.Label).ForeColor = Color.FromArgb(-16728064)
            lexer.Styles(ScintillaNET.Style.Vb.[Error]).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.[Error]).ForeColor = Color.FromArgb(-2600880)
            lexer.Styles(ScintillaNET.Style.Vb.HexNumber).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.HexNumber).ForeColor = Color.FromArgb(-4145152)
            lexer.Styles(ScintillaNET.Style.Vb.BinNumber).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.BinNumber).ForeColor = Color.FromArgb(-4194112)
            lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).ForeColor = Color.FromArgb(-11033014)
            lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).Italic = True
            lexer.Styles(ScintillaNET.Style.Vb.DocLine).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.DocLine).ForeColor = Color.Silver
            lexer.Styles(ScintillaNET.Style.Vb.DocBlock).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.DocBlock).ForeColor = Color.FromArgb(-4862296)
            lexer.Styles(ScintillaNET.Style.Vb.DocKeyword).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.Vb.DocKeyword).ForeColor = Color.FromArgb(-4862296)

            lexer.SetKeywords(0, My.Resources.vb_keywords)


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub setPHPStyle(lexer As ScintillaNET.Scintilla)
        Try

            ResetLexer(lexer)

            lexer.Lexer = ScintillaNET.Lexer.PhpScript

            lexer.CreateDocument()

            lexer.Styles(ScintillaNET.Style.PhpScript.ComplexVariable).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.ComplexVariable).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.ComplexVariable).ForeColor = Color.FromArgb(-9990991)
            lexer.Styles(ScintillaNET.Style.PhpScript.Default).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.Default).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.Default).ForeColor = Color.FromArgb(-2039068)
            lexer.Styles(ScintillaNET.Style.PhpScript.HString).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.HString).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.HString).ForeColor = Color.FromArgb(-1280512)
            lexer.Styles(ScintillaNET.Style.PhpScript.SimpleString).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.SimpleString).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.SimpleString).ForeColor = Color.FromArgb(-31735)
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).Bold = True
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).ForeColor = Color.FromArgb(-7092381)
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).Hotspot = True
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).Weight = 700
            lexer.Styles(ScintillaNET.Style.PhpScript.Number).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.Number).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.Number).ForeColor = Color.FromArgb(-12957)
            lexer.Styles(ScintillaNET.Style.PhpScript.Variable).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.Variable).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.Variable).ForeColor = Color.FromArgb(-9990991)
            lexer.Styles(ScintillaNET.Style.PhpScript.Comment).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.Comment).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.Comment).ForeColor = Color.FromArgb(-10062725)
            lexer.Styles(ScintillaNET.Style.PhpScript.Comment).Italic = True
            lexer.Styles(ScintillaNET.Style.PhpScript.CommentLine).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.CommentLine).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.CommentLine).ForeColor = Color.FromArgb(-10062725)
            lexer.Styles(ScintillaNET.Style.PhpScript.CommentLine).Italic = True
            lexer.Styles(ScintillaNET.Style.PhpScript.HStringVariable).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.HStringVariable).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.HStringVariable).ForeColor = Color.FromArgb(-2910405)
            lexer.Styles(ScintillaNET.Style.PhpScript.Operator).BackColor = Color.FromArgb(-14077644)
            lexer.Styles(ScintillaNET.Style.PhpScript.Operator).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.PhpScript.Operator).ForeColor = Color.FromArgb(-1514820)


            lexer.SetKeywords(0, My.Resources.php_keywords)


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub setSQLStyle(lexer As ScintillaNET.Scintilla)
        Try
            ResetLexer(lexer)

            lexer.Lexer = ScintillaNET.Lexer.Sql

            lexer.CreateDocument()

            lexer.Styles(ScintillaNET.Style.Sql.Default).BackColor = Color.FromArgb(-14803426)
            lexer.Styles(ScintillaNET.Style.Sql.Default).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Sql.Default).ForeColor = Color.Gainsboro
            lexer.Styles(ScintillaNET.Style.Sql.Default).Size = 10
            lexer.Styles(ScintillaNET.Style.Sql.Default).SizeF = 10.0F
            lexer.Styles(ScintillaNET.Style.Sql.Comment).BackColor = Color.FromArgb(-14803426)
            lexer.Styles(ScintillaNET.Style.Sql.Comment).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Sql.Comment).ForeColor = Color.FromArgb(102, 116, 123)
            lexer.Styles(ScintillaNET.Style.Sql.Comment).Italic = True
            lexer.Styles(ScintillaNET.Style.Sql.Comment).Size = 10
            lexer.Styles(ScintillaNET.Style.Sql.Comment).SizeF = 10.0F
            lexer.Styles(ScintillaNET.Style.Sql.Number).BackColor = Color.FromArgb(-14803426)
            lexer.Styles(ScintillaNET.Style.Sql.Number).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Sql.Number).ForeColor = Color.FromArgb(255, 205, 34)
            lexer.Styles(ScintillaNET.Style.Sql.Number).Size = 10
            lexer.Styles(ScintillaNET.Style.Sql.Number).SizeF = 10.0F
            lexer.Styles(ScintillaNET.Style.Sql.Word).BackColor = Color.FromArgb(-14803426)
            lexer.Styles(ScintillaNET.Style.Sql.Word).Bold = True
            lexer.Styles(ScintillaNET.Style.Sql.Word).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Sql.Word).ForeColor = Color.FromArgb(147, 199, 99)
            lexer.Styles(ScintillaNET.Style.Sql.Word).Size = 10
            lexer.Styles(ScintillaNET.Style.Sql.Word).SizeF = 10.0F
            lexer.Styles(ScintillaNET.Style.Sql.Word).Weight = 700
            lexer.Styles(ScintillaNET.Style.Sql.[String]).BackColor = Color.FromArgb(-14803426)
            lexer.Styles(ScintillaNET.Style.Sql.[String]).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Sql.[String]).ForeColor = Color.FromArgb(236, 118, 0)
            lexer.Styles(ScintillaNET.Style.Sql.[String]).Size = 10
            lexer.Styles(ScintillaNET.Style.Sql.[String]).SizeF = 10.0F
            lexer.Styles(ScintillaNET.Style.Sql.[Operator]).BackColor = Color.FromArgb(-14803426)
            lexer.Styles(ScintillaNET.Style.Sql.[Operator]).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Sql.[Operator]).ForeColor = Color.FromArgb(232, 226, 183)
            lexer.Styles(ScintillaNET.Style.Sql.[Operator]).Size = 10
            lexer.Styles(ScintillaNET.Style.Sql.[Operator]).SizeF = 10.0F
            lexer.Styles(ScintillaNET.Style.Sql.Identifier).BackColor = Color.FromArgb(-14803426)
            lexer.Styles(ScintillaNET.Style.Sql.Identifier).ForeColor = Color.Gainsboro


            lexer.SetKeywords(0, My.Resources.sql_keywords)


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

#Region "Buttons"
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Try
            Dim frx As New preferences

            frx.ShowDialog()


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub txtProjectFolder_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtProjectFolder.ButtonCustomClick
        Try
            FolderBrowserDialog1.Description = "Select project folder"
            If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                txtProjectFolder.Text = FolderBrowserDialog1.SelectedPath
                WriteProject()
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try

    End Sub

    Private Sub txtOutputFolder_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtOutputFolder.ButtonCustomClick
        Try
            FolderBrowserDialog1.Description = "Select output folder"
            If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                txtOutputFolder.Text = FolderBrowserDialog1.SelectedPath
                WriteProject()
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnSaveProject_Click(sender As Object, e As EventArgs) Handles btnSaveProject.Click
        Try
            If _currentProject.projectfilename = "" Then _currentProject.projectfilename = IO.Path.Combine(_currentProject.projectlocation, $"{_currentProject.projectname}.nb2")

            'Create backup file
            If IO.File.Exists(_currentProject.projectfilename) Then
                Dim backupFile As String = _currentProject.projectfilename.Replace(".nb2", $"_{Now:yyyyMMdd_HHmmss_fffff}.nbz")
                Using zip As New Ionic.Zip.ZipFile(backupFile)
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression
                    zip.AddFile(_currentProject.projectfilename, "")
                    zip.Save()
                End Using
            End If
            Using fs As New IO.FileStream(_currentProject.projectfilename, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
                Using sw As New IO.StreamWriter(fs, System.Text.Encoding.UTF8)

                    sw.Write(JsonConvert.SerializeObject(_currentProject, Formatting.Indented, New JsonSerializerSettings With {
                                                                                                    .ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                                                                                    .PreserveReferencesHandling = PreserveReferencesHandling.Objects}))

                    'Dim js As New JsonSerializer
                    'js.Serialize(sw, _currentProject)
                End Using
            End Using
            _currentProject.needsSave = False
            _tracelistener.WriteLine("Project saved!")
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click
        Try
            If _currentProject IsNot Nothing AndAlso _currentProject.needsSave Then
                If MessageBox.Show("Project has changed. Save changes?", "Save changes?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    btnSaveProject.RaiseClick()
                End If
            End If

            _currentProject = New Project

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                _loadingProject = True
                _currentProject = CType(JsonConvert.DeserializeObject(IO.File.ReadAllText(OpenFileDialog1.FileName), GetType(Project)), Project)

                _currentProject.projectfilename = OpenFileDialog1.FileName

                txtProjectName.Text = _currentProject.projectname
                txtProjectFolder.Text = _currentProject.projectlocation
                txtOutputFolder.Text = _currentProject.projectoutputlocation
                Dim itm = cboOutputType.Items().Cast(Of DevComponents.Editors.ComboItem).FirstOrDefault(Function(c) c.Value.ToString = _currentProject.outputtype)
                cboOutputType.SelectedItem = itm
                sbEnums.SetValueAndAnimate(_currentProject.useEnums, eEventSource.Code)
                sbProcedureLocks.SetValueAndAnimate(_currentProject.generateProcedureLocks, eEventSource.Code)

                cboConnecions.Text = _currentProject.database.connection.description
                _currentConnection = _currentProject.database.connection

                btnConnect.RaiseClick(eEventSource.Code)
                'TODO: Create database vcs
                _mngr.setGenerator(CType(cboOutputType.SelectedItem, DevComponents.Editors.ComboItem).Value.ToString)
                _mngr.SetDatabase(_currentProject.database.databasename)
                _mngr.tables = _currentProject.database.tables
                _mngr.routines = _currentProject.database.routines

                Dim selectedDB = advtreeDatabases.FindNodeByName(_currentProject.database.databasename)

                If selectedDB IsNot Nothing Then
                    advtreeDatabases.SelectNode(selectedDB, AdvTree.eTreeAction.Code)
                    databaseNodeHandler(selectedDB, New AdvTree.AdvTreeNodeEventArgs(AdvTree.eTreeAction.Code, selectedDB))
                End If

                _FileManager = New FileVCS.Manager
                ExplorerControl1.ExplorerManager = _FileManager
                _FileManager.ScanForFiles(_currentProject.projectoutputlocation)
                If _currentProject.generatedoutputs IsNot Nothing Then _FileManager.OriginalFiles = _currentProject.generatedoutputs
                ExplorerControl1.ClearExplorer()
                ExplorerControl1.RefreshExplorer()

                _loadingProject = False
            End If
            enableOrDisableFields()

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnCloseProject_Click(sender As Object, e As EventArgs) Handles btnCloseProject.Click
        Try
            If _currentProject IsNot Nothing AndAlso _currentProject.needsSave Then
                If MessageBox.Show("Project has changed. Save changes?", "Save changes?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    btnSaveProject.RaiseClick()
                End If
            End If

            _currentProject = Nothing

            advtreeOutputExplorer.Nodes.Clear()
            advtreeDatabases.Nodes.Clear()
            ExplorerControl1.ClearExplorer()

            enableOrDisableFields()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnNewProject_Click(sender As Object, e As EventArgs) Handles btnNewProject.Click
        Try
            If _currentProject IsNot Nothing AndAlso _currentProject.needsSave Then
                If MessageBox.Show("Project has changed. Save changes?", "Save changes?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    btnSaveProject.RaiseClick()
                End If
            End If

            If cboOutputType.SelectedItem Is Nothing Then cboOutputType.SelectedIndex = 2
            _FileManager = New FileVCS.Manager
            ExplorerControl1.ClearExplorer()

            _currentProject = New Project
            Dim x As Editors.ComboItem = CType(cboOutputType.SelectedItem, Editors.ComboItem)
            _currentProject.outputtype = x.Value.ToString
            _currentProject.useEnums = sbEnums.Value
            _currentProject.generateProcedureLocks = sbProcedureLocks.Value

            enableOrDisableFields()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

    Private Sub WriteProject()
        Try
            If Not _loadingProject AndAlso _currentProject IsNot Nothing Then
                _currentProject.needsSave = True
                _currentProject.application_version = $"{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}"
                _currentProject.save_date = Now
                _currentProject.projectname = txtProjectName.Text
                _currentProject.projectlocation = txtProjectFolder.Text
                _currentProject.projectoutputlocation = txtOutputFolder.Text

                Dim x As Editors.ComboItem = CType(cboOutputType.SelectedItem, Editors.ComboItem)
                _currentProject.outputtype = x.Value.ToString
                _currentProject.useEnums = sbEnums.Value
                _currentProject.generateProcedureLocks = sbProcedureLocks.Value

                _currentProject.database = New databaseObjects With {
                    .connection = _currentConnection,
                    .databasename = _mngr.GetDatabase,
                    .tables = _mngr.tables,
                    .routines = _mngr.routines
                }
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub cboOutputType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOutputType.SelectedIndexChanged
        WriteProject()
        Select Case CType(cboOutputType.SelectedItem, DevComponents.Editors.ComboItem).Value.ToString
            Case "net5"
                Using ts As New IO.StringReader(My.Resources.net5OutputExplorer)
                    advtreeOutputExplorer.Nodes.Clear()
                    advtreeOutputExplorer.Load(ts)
                End Using
                setVbStyle(scCodePreview)
                setVbStyle(scGeneratedModel)
                setVbStyle(scGeneratedMapping)
            Case "php"
                Using ts As New IO.StringReader(My.Resources.phpOutputExplorer)
                    advtreeOutputExplorer.Nodes.Clear()
                    advtreeOutputExplorer.Load(ts)
                End Using
                setPHPStyle(scCodePreview)
                setPHPStyle(scGeneratedModel)
                setPHPStyle(scGeneratedMapping)
            Case Else
                Using ts As New IO.StringReader(My.Resources.defaultOutputExplorer)
                    advtreeOutputExplorer.Nodes.Clear()
                    advtreeOutputExplorer.Load(ts)
                End Using
                setVbStyle(scCodePreview)
                setVbStyle(scGeneratedModel)
                setVbStyle(scGeneratedMapping)
        End Select

        If _mngr IsNot Nothing Then _mngr.setGenerator(CType(cboOutputType.SelectedItem, DevComponents.Editors.ComboItem).Value.ToString.ToLower)
    End Sub

    Private Sub enableOrDisableFields()
        Try
            Dim enabled As Boolean = False

            If _currentProject IsNot Nothing Then enabled = True

            dcProjectSettings.Enabled = enabled
            'dcObjectInfo.Enabled = enabled
            dcCodePreview.Enabled = enabled
            dcERDiagram.Enabled = enabled
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub GenerateERDiagramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateERDiagramToolStripMenuItem.Click
        LoadTreeGXTableClasses()
    End Sub

    Private Sub sbEnums_ValueChanged(sender As Object, e As EventArgs) Handles sbEnums.ValueChanged

        If DirectCast(e, Events.EventSourceArgs).Source <> eEventSource.Code Then WriteProject()
    End Sub

    Private Sub sbProcedureLocks_ValueChanged(sender As Object, e As EventArgs) Handles sbProcedureLocks.ValueChanged
        If DirectCast(e, Events.EventSourceArgs).Source <> eEventSource.Code Then WriteProject()
    End Sub

    Private Sub ReloadDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadDatabaseToolStripMenuItem.Click
        advtreeDatabases.SelectedNode.Nodes.Clear()
        databaseNodeHandler(advtreeDatabases.SelectedNode, New EventArgs)
    End Sub

    Private Sub ExplorerControl1_ShowFileContentsEvent(fileName As String) Handles ExplorerControl1.ShowFileContentsEvent
        scCodePreview.Text = IO.File.ReadAllText(fileName)
        scCodePreview.Colorize(0, scCodePreview.Text.Length)
        dcCodePreview.Selected = True
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        IO.File.WriteAllText("d:\test\tables.json", JsonConvert.SerializeObject(_mngr.tables, Formatting.Indented, New JsonSerializerSettings With {
                                                                                                    .ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                                                                                    .PreserveReferencesHandling = PreserveReferencesHandling.Objects}))
    End Sub

    Private Sub cboConnecions_Click(sender As Object, e As EventArgs) Handles cboConnecions.Click

    End Sub
End Class