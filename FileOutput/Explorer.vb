Public Class Explorer
    Private Sub btnHomeOutputExplorer_Click(sender As Object, e As EventArgs) Handles btnHomeOutputExplorer.Click
        Try
            If _currentProject IsNot Nothing AndAlso _currentProject.outputtype = ".NET" Then
                Using ts As New IO.StringReader(My.Resources.net5OutputExplorer)
                    advtreeOutputExplorer.Nodes.Clear()
                    advtreeOutputExplorer.Load(ts)
                End Using
            Else
                Using ts As New IO.StringReader(My.Resources.defaultOutputExplorer)
                    advtreeOutputExplorer.Nodes.Clear()
                    advtreeOutputExplorer.Load(ts)
                End Using
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

            Dim tplModelAndMapping As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 4}
            Dim tplContextAndStoreCommands As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 5}
            Dim tplFunctions As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 6}
            Dim tplProcedures As New AdvTree.Node With {.DragDropEnabled = False, .Editable = False, .Expanded = False, .ImageIndex = 7}

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
                    mModel.Nodes.Add(tmpModel)

                    tmpMapping.Name = $"n{table.name}Table"
                    tmpMapping.TagString = table.name
                    tmpMapping.Text = $"{table.pluralName}Table.php"
                    AddHandler tmpMapping.NodeClick, AddressOf explorerMappingNodeHandler

                    mMapping.Nodes.Add(tmpMapping)
                Next

            Else
                Dim mModel As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapModels", True).FirstOrDefault
                Dim mMapping As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapMapping", True).FirstOrDefault
                Dim mStoreCommands As AdvTree.Node = advtreeOutputExplorer.Nodes.Find("mapStoreCommands", True).FirstOrDefault
                Dim mStoreCommandFunctions As AdvTree.Node = mStoreCommands.Nodes.Find("mapStoreCommandFunctions", True).FirstOrDefault
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
                    mModel.Nodes.Add(tmpModel)

                    tmpMapping.Name = $"n{table.name}Map"
                    tmpMapping.TagString = table.name
                    tmpMapping.Text = $"{table.singleName}Map.vb"
                    AddHandler tmpMapping.NodeClick, AddressOf explorerMappingNodeHandler

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
                        tmpNode = tplModelAndMapping.DeepCopy
                        tmpNode.Name = $"n{routine.name}Model"
                        tmpNode.TagString = routine.name
                        tmpNode.Text = $"{routine.name}Model.vb"
                        AddHandler tmpNode.NodeClick, AddressOf explorerRoutineModelNodeHandler

                        mStoreCommandModels.Nodes.Add(tmpNode)
                    End If
                Next

                ' Context
                Dim tmpContext As AdvTree.Node = tplContextAndStoreCommands.DeepCopy

                tmpContext.Name = "nContext"
                tmpContext.Text = $"{txtProjectName.Text}Context.vb"
                AddHandler tmpContext.NodeClick, AddressOf explorerContextNodeHandler
                mModel.Nodes.Add(tmpContext)

                If _currentProject IsNot Nothing AndAlso _currentProject.outputtype.ToLower = "net" Then
                    ' StoreCommandsContext
                    tmpContext = tplContextAndStoreCommands.DeepCopy

                    tmpContext.Name = "nStoreCommandsContext"
                    tmpContext.Text = $"{txtProjectName.Text}StoreCommandsContext.vb"
                    AddHandler tmpContext.NodeClick, AddressOf explorerStoreCommandsNodeHandler
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
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\StoreCommands") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\StoreCommands")
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\StoreCommands\Functions") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\StoreCommands\Functions")
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\StoreCommands\Procedures") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\StoreCommands\Procedures")
                If Not IO.Directory.Exists($"{txtOutputFolder.Text}\StoreCommands\Procedures\Models") Then IO.Directory.CreateDirectory($"{txtOutputFolder.Text}\StoreCommands\Procedures\Models")
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
                        IO.File.WriteAllText($"{txtOutputFolder.Text}\StoreCommands\Functions\{s.name}.vb", _mngr.generateStoreCommand(s, $"{txtProjectName.Text}", sbProcedureLocks.Value))
                    Else
                        IO.File.WriteAllText($"{txtOutputFolder.Text}\StoreCommands\Procedures\{s.name}.vb", _mngr.generateStoreCommand(s, $"{txtProjectName.Text}", sbProcedureLocks.Value))
                        If s.returnsRecordset Then
                            IO.File.WriteAllText($"{txtOutputFolder.Text}\StoreCommands\Procedures\Models\{s.returnLayout.singleName}.vb", _mngr.generateModel(s.returnLayout))
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

    Private Sub bHome_Click(sender As Object, e As EventArgs) Handles bHome.Click
        Try
            If _currentProject IsNot Nothing AndAlso _currentProject.outputtype = ".NET" Then
                Using ts As New IO.StringReader(My.Resources.net5OutputExplorer)
                    advtreeOutputExplorer.Nodes.Clear()
                    advtreeOutputExplorer.Load(ts)
                End Using
            Else
                Using ts As New IO.StringReader(My.Resources.defaultOutputExplorer)
                    advtreeOutputExplorer.Nodes.Clear()
                    advtreeOutputExplorer.Load(ts)
                End Using
            End If
            advtreeOutputExplorer.Refresh()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
End Class
