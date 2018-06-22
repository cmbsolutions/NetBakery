Imports DevComponents
Imports DevComponents.DotNetBar

Public Class mainGUI2
    Private _mngr As New infoSchema.manager
    Private _currentConnection As infoSchema.connection
    Private _connections As New infoSchema.connections

    Private _tracelistener As customTextTraceListener

    Private _dockFile As IO.FileInfo
    Private _connectionsFile As IO.FileInfo

    Private Sub mainGUI2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            _tracelistener = New customTextTraceListener(txtLog)
            Trace.Listeners.Add(_tracelistener)

            FormHelpers.upgradeMySettings()

            dnbStyleManager.ManagerStyle = DirectCast([Enum].Parse(GetType(eStyle), My.Settings.gui_style), eStyle)

            TitleText = FormHelpers.ApplicationTitle
            Text = TitleText

            _dockFile = New IO.FileInfo(String.Format("{0}\{1}\{2}\layout.xml", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CMBSolutions", "NetBakery"))

            If _dockFile.Exists Then
                dnbBarManager.LoadLayout(_dockFile.FullName)
            End If

            _connectionsFile = New IO.FileInfo(String.Format("{0}\{1}\{2}\connections.bin", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CMBSolutions", "NetBakery"))

            If _connectionsFile.Exists Then
                _connections.LoadFromFile(_connectionsFile)
            End If

            cboConnecions.ComboBoxEx.DataSource = (From c In _connections Select c.description).ToList
            cboConnecions.Refresh()

            setVbStyle(scCodePreview)
            setVbStyle(scGeneratedModel)
            setVbStyle(scGeneratedMapping)

            dcProjectSettings.Selected = True

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub mainGUI2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            My.Settings.Save()

            dnbBarManager.SaveLayout(_dockFile.FullName)

            saveConnections()

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

#Region "Main menu items"
    Private Sub btnFile_Close_Click(sender As Object, e As EventArgs) Handles btnFile_Close.Click
        Try
            Close()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

#Region "Databases and connections tab"

    Private Sub btnNewConnection_Click(sender As Object, e As EventArgs) Handles btnNewConnection.Click
        Dim frx = New connection_editor

        frx._conn = _connections

        If frx.ShowDialog = DialogResult.OK Then
            saveConnections()
            cboConnecions.ComboBoxEx.DataSource = (From c In _connections Select c.description).ToList
            cboConnecions.Refresh()
        End If
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

            Dim frx = New connection_editor

            frx._conn = _connections
            frx.loadConnection(cboConnecions.Text)

            If frx.ShowDialog = DialogResult.OK Then
                saveConnections()
                cboConnecions.ComboBoxEx.DataSource = (From c In _connections Select c.description).ToList
                cboConnecions.Refresh()
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            If _currentConnection Is Nothing Then
                MessageBoxEx.Show("No connection selected")
                Exit Sub
            End If

            _mngr.initSchema()
            _mngr.connection = _currentConnection

            If _mngr.TryConnect() Then
                advtreeDatabases.Nodes.Clear()

                For Each db In _mngr.databases
                    Dim node As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .Text = db}

                    AddHandler node.NodeDoubleClick, AddressOf databaseNodeHandler
                    advtreeDatabases.Nodes.Add(node)
                Next
                advtreeDatabases.Refresh()
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
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
            For Each table In _mngr.tables
                ' Clone the templates
                Dim tmpNode = itemNode.DeepCopy
                Dim tmpCell = New AdvTree.Cell With {.Editable = False, .Text = "0", .TextDisplayFormat = "(0)", .ImageAlignment = AdvTree.eCellPartAlignment.NearCenter}

                tmpCell.Text = table.columns.Count.ToString
                tmpNode.Text = table.tableName
                tmpNode.Cells.Add(tmpCell)

                AddHandler tmpNode.NodeClick, AddressOf tableNodeHandler

                If table.isView Then
                    viewNode.Nodes.Add(tmpNode)
                Else
                    tableNode.Nodes.Add(tmpNode)
                End If
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

            _mngr.database = node.Text
            _mngr.harvestObjects()

            populateTreeNode(node)

            node.Expand()

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub tableNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)


            If nodeEvent.Button = MouseButtons.Left Then
                Dim tableFields = (From f In _mngr.tables Where f.isView = False AndAlso f.tableName = node.Text Select f).FirstOrDefault

                If tableFields IsNot Nothing Then
                    dgvFields.DataSource = tableFields.columns.ToArray

                    Dim fks = (From fk In tableFields.foreignKeys Order By fk.ordinalPosition Select New With {
                                                                      Key fk.constraintName,
                                                                      fk.table.tableName,
                                                                      fk.column.name,
                                                                      fk.ordinalPosition,
                                                                      fk.positionInUniqueConstraint,
                                                                      .referenceTable = fk.referencedTable.tableName,
                                                                      .referenceColumn = fk.referencedColumn.name})


                    dgvForeignKeys.DataSource = fks.ToArray
                End If
                dgvFields.Refresh()
                dgvForeignKeys.Refresh()

                dcObjectInfo.Selected = True
                TabControl1.SelectedPanel = TabControlPanel1

            End If


            _mngr.tables.First(Function(c) c.tableName = node.Text).hasExport = node.Checked


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub routineNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)

            _mngr.routines.First(Function(c) c.name = node.Text).hasExport = node.Checked

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub


#End Region

#Region "outputExplorer"
    Private Sub btnHomeOutputExplorer_Click(sender As Object, e As EventArgs) Handles btnHomeOutputExplorer.Click
        Try
            Using ts As New IO.StringReader(My.Resources.defaultOutputExplorer)
                advtreeOutputExplorer.Nodes.Clear()
                advtreeOutputExplorer.Load(ts)
                advtreeOutputExplorer.Refresh()
            End Using

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnRefreshOutputExplorer_Click(sender As Object, e As EventArgs) Handles btnRefreshOutputExplorer.Click
        Try
            Using ts As New IO.StringReader(My.Resources.defaultOutputExplorer)
                advtreeOutputExplorer.Nodes.Clear()
                advtreeOutputExplorer.Load(ts)
            End Using

            Dim tplModelAndMapping As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 4}
            Dim tplContextAndStoreCommands As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 5}
            Dim tplFunctions As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 6}
            Dim tplProcedures As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 7}


            Dim mModel As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapModels", True).FirstOrDefault
            Dim mMapping As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapMapping", True).FirstOrDefault
            Dim mStoreCommands As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapStoreCommands", True).FirstOrDefault
            Dim mStoreCommandModels As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapStoreCommandModels", True).FirstOrDefault

            ' Tables and views
            For Each table In _mngr.tables.Where(Function(t) t.hasExport)
                Dim tmpModel As AdvTree.Node = tplModelAndMapping.DeepCopy
                Dim tmpMapping As AdvTree.Node = tplModelAndMapping.DeepCopy

                tmpModel.Name = "n" & table.tableName
                tmpModel.TagString = table.tableName

                tmpModel.Text = String.Format("{0}.vb", table.singleName)
                AddHandler tmpModel.NodeDoubleClick, AddressOf explorerModelNodeHandler
                mModel.Nodes.Add(tmpModel)

                tmpMapping.Name = "n" & table.tableName & "Mapping"
                tmpMapping.TagString = table.tableName
                tmpMapping.Text = String.Format("{0}Mapping.vb", table.singleName)
                AddHandler tmpMapping.NodeDoubleClick, AddressOf explorerMappingNodeHandler

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

                tmpNode.Name = String.Format("n{0}", routine.name)
                tmpNode.TagString = routine.name
                tmpNode.Text = String.Format("{0}.vb", routine.name)
                AddHandler tmpNode.NodeDoubleClick, AddressOf explorerRoutineNodeHandler

                mStoreCommands.Nodes.Add(tmpNode)

                If routine.returnsRecordset Then
                    tmpNode = tplModelAndMapping.DeepCopy
                    tmpNode.Name = String.Format("n{0}Model", routine.name)
                    tmpNode.TagString = routine.name
                    tmpNode.Text = String.Format("{0}Model.vb", routine.name)
                    AddHandler tmpNode.NodeDoubleClick, AddressOf explorerModelNodeHandler

                    mStoreCommandModels.Nodes.Add(tmpNode)
                End If
            Next

            ' Context
            Dim tmpContext As AdvTree.Node = tplContextAndStoreCommands.DeepCopy

            tmpContext.Name = "nContext"
            tmpContext.Text = String.Format("{0}Context.vb", "<ProjectName>")
            AddHandler tmpContext.NodeDoubleClick, AddressOf explorerContextNodeHandler
            mModel.Nodes.Add(tmpContext)

            ' StoreCommandsContext
            tmpContext = tplContextAndStoreCommands.DeepCopy

            tmpContext.Name = "nStoreCommandsContext"
            tmpContext.Text = String.Format("{0}StoreCommandsContext.vb", "<ProjectName>")
            AddHandler tmpContext.NodeDoubleClick, AddressOf explorerStoreCommandsNodeHandler
            mModel.Nodes.Add(tmpContext)

            advtreeOutputExplorer.Refresh()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub btnSaveLayout_Click(sender As Object, e As EventArgs) Handles btnSaveLayout.Click
        Try
            advtreeOutputExplorer.Save("c:\test.xml")
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub explorerModelNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)



        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerMappingNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerRoutineNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerContextNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub explorerStoreCommandsNodeHandler(sender As Object, e As EventArgs)
        Try
            Dim node As AdvTree.Node = TryCast(sender, AdvTree.Node)
            Dim nodeEvent As AdvTree.TreeNodeMouseEventArgs = TryCast(e, AdvTree.TreeNodeMouseEventArgs)


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
                        _mngr.tables.First(Function(c) c.tableName = n.Text).hasExport = n.Checked
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
                        _mngr.tables.First(Function(c) c.tableName = n.Text).hasExport = n.Checked
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
                        _mngr.tables.First(Function(c) c.tableName = n.Text).hasExport = n.Checked
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
    Private Sub setVbStyle(lexer As ScintillaNET.Scintilla)
        Try

            lexer.StyleClearAll()

            lexer.HScrollBar = False
            lexer.VScrollBar = True

            lexer.Styles(ScintillaNET.Style.Default).BackColor = Color.FromArgb(30, 30, 30)
            lexer.Styles(ScintillaNET.Style.Default).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Default).ForeColor = Color.FromArgb(220, 220, 220)
            lexer.Styles(ScintillaNET.Style.Default).Size = 10

            'lexer.SetSelectionBackColor(True, Color.FromArgb(51, 153, 255))

            lexer.Styles(ScintillaNET.Style.LineNumber).BackColor = Color.FromArgb(30, 30, 30)
            lexer.Styles(ScintillaNET.Style.LineNumber).ForeColor = Color.FromArgb(43, 145, 175)
            lexer.Styles(ScintillaNET.Style.LineNumber).Font = lexer.Styles(ScintillaNET.Style.Default).Font
            lexer.Styles(ScintillaNET.Style.LineNumber).Size = lexer.Styles(ScintillaNET.Style.Default).Size

            lexer.Margins(0).Type = ScintillaNET.MarginType.Number
            lexer.Margins(0).Width = 30

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

            lexer.SetKeywords(0, My.Settings.keywords)

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub setPHPStyle(lexer As ScintillaNET.Scintilla)
        Try

            lexer.StyleClearAll()

            lexer.HScrollBar = False
            lexer.VScrollBar = True

            lexer.Styles(ScintillaNET.Style.Default).BackColor = Color.FromArgb(30, 30, 30)
            lexer.Styles(ScintillaNET.Style.Default).Font = "Consolas"
            lexer.Styles(ScintillaNET.Style.Default).ForeColor = Color.FromArgb(220, 220, 220)
            lexer.Styles(ScintillaNET.Style.Default).Size = 10

            'lexer.SetSelectionBackColor(True, Color.FromArgb(51, 153, 255))

            lexer.Styles(ScintillaNET.Style.LineNumber).BackColor = Color.FromArgb(30, 30, 30)
            lexer.Styles(ScintillaNET.Style.LineNumber).ForeColor = Color.FromArgb(43, 145, 175)
            lexer.Styles(ScintillaNET.Style.LineNumber).Font = lexer.Styles(ScintillaNET.Style.Default).Font
            lexer.Styles(ScintillaNET.Style.LineNumber).Size = lexer.Styles(ScintillaNET.Style.Default).Size

            lexer.Margins(0).Type = ScintillaNET.MarginType.Number
            lexer.Margins(0).Width = 30

            lexer.Lexer = ScintillaNET.Lexer.PhpScript

            lexer.CreateDocument()

            lexer.Styles(ScintillaNET.Style.PhpScript.Default).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.Default).ForeColor = lexer.Styles(ScintillaNET.Style.Default).ForeColor
            lexer.Styles(ScintillaNET.Style.PhpScript.Comment).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.Comment).ForeColor = Color.FromArgb(87, 166, 74)
            lexer.Styles(ScintillaNET.Style.PhpScript.Comment).Italic = True
            lexer.Styles(ScintillaNET.Style.PhpScript.Number).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.Number).ForeColor = Color.FromArgb(181, 206, 168)
            lexer.Styles(ScintillaNET.Style.PhpScript.ComplexVariable).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.ComplexVariable).ForeColor = Color.FromArgb(86, 156, 214)
            lexer.Styles(ScintillaNET.Style.PhpScript.SimpleString).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.SimpleString).ForeColor = Color.FromArgb(255, 128, 0)
            lexer.Styles(ScintillaNET.Style.PhpScript.Variable).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.Variable).ForeColor = Color.Gainsboro
            lexer.Styles(ScintillaNET.Style.PhpScript.Operator).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.Operator).ForeColor = Color.FromArgb(-4934476)
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.Word).ForeColor = Color.Gainsboro
            lexer.Styles(ScintillaNET.Style.PhpScript.HString).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.HString).ForeColor = Color.Green
            lexer.Styles(ScintillaNET.Style.PhpScript.HStringVariable).ForeColor = Color.Navy
            lexer.Styles(ScintillaNET.Style.PhpScript.HStringVariable).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.CommentLine).BackColor = lexer.Styles(ScintillaNET.Style.Default).BackColor
            lexer.Styles(ScintillaNET.Style.PhpScript.CommentLine).ForeColor = Color.FromArgb(-11033014)
            lexer.Styles(ScintillaNET.Style.PhpScript.CommentLine).Italic = True

            Using s As New IO.StreamReader(My.Resources.ResourceManager.GetStream("php_keywords"), False)
                lexer.SetKeywords(0, s.ReadToEnd())
            End Using

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub setSQLStyle(_lexer As ScintillaNET.Scintilla)
        Try
            _lexer.Styles(ScintillaNET.Style.Default).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Default).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Default).ForeColor = Color.Gainsboro
            _lexer.Styles(ScintillaNET.Style.Default).Size = 10
            _lexer.Styles(ScintillaNET.Style.Default).SizeF = 10.0F

            _lexer.StyleClearAll()

            _lexer.Styles(ScintillaNET.Style.LineNumber).BackColor = Color.FromArgb(83, 83, 83)
            _lexer.Styles(ScintillaNET.Style.LineNumber).ForeColor = Color.Gainsboro
            _lexer.Styles(ScintillaNET.Style.LineNumber).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.LineNumber).Size = 10
            _lexer.Styles(ScintillaNET.Style.LineNumber).SizeF = 10.0F


            _lexer.Margins(0).Type = ScintillaNET.MarginType.Number
            _lexer.Margins(0).Width = 30

            _lexer.Lexer = ScintillaNET.Lexer.Sql

            _lexer.CreateDocument()

            _lexer.Styles(ScintillaNET.Style.Sql.Default).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Sql.Default).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Sql.Default).ForeColor = Color.Gainsboro
            _lexer.Styles(ScintillaNET.Style.Sql.Default).Size = 10
            _lexer.Styles(ScintillaNET.Style.Sql.Default).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Sql.Comment).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Sql.Comment).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Sql.Comment).ForeColor = Color.FromArgb(102, 116, 123)
            _lexer.Styles(ScintillaNET.Style.Sql.Comment).Italic = True
            _lexer.Styles(ScintillaNET.Style.Sql.Comment).Size = 10
            _lexer.Styles(ScintillaNET.Style.Sql.Comment).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Sql.Number).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Sql.Number).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Sql.Number).ForeColor = Color.FromArgb(255, 205, 34)
            _lexer.Styles(ScintillaNET.Style.Sql.Number).Size = 10
            _lexer.Styles(ScintillaNET.Style.Sql.Number).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Sql.Word).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Sql.Word).Bold = True
            _lexer.Styles(ScintillaNET.Style.Sql.Word).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Sql.Word).ForeColor = Color.FromArgb(147, 199, 99)
            _lexer.Styles(ScintillaNET.Style.Sql.Word).Size = 10
            _lexer.Styles(ScintillaNET.Style.Sql.Word).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Sql.Word).Weight = 700
            _lexer.Styles(ScintillaNET.Style.Sql.[String]).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Sql.[String]).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Sql.[String]).ForeColor = Color.FromArgb(236, 118, 0)
            _lexer.Styles(ScintillaNET.Style.Sql.[String]).Size = 10
            _lexer.Styles(ScintillaNET.Style.Sql.[String]).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Sql.[Operator]).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Sql.[Operator]).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Sql.[Operator]).ForeColor = Color.FromArgb(232, 226, 183)
            _lexer.Styles(ScintillaNET.Style.Sql.[Operator]).Size = 10
            _lexer.Styles(ScintillaNET.Style.Sql.[Operator]).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Sql.Identifier).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Sql.Identifier).ForeColor = Color.Gainsboro

            _lexer.SetKeywords(0, My.Settings.sql_keywords)

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

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
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
End Class