
Public Class main
    Private _is As informationSchema
    Private _g As New generator

    Private _selectedRoutine As Models.Routine

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        Try
            If txtServer.Text = "" Then
                MessageBox.Show("Missing server")
                Exit Sub
            End If

            If txtUser.Text = "" Then
                MessageBox.Show("Missing username")
                Exit Sub
            End If

            If txtPass.Text = "" Then
                MessageBox.Show("Missing password")
                Exit Sub
            End If

            Dim sslMode As String
            If chkSsl.Checked Then
                sslMode = "Required"
            Else
                sslMode = "Prefered"
            End If

            Cursor = Cursors.WaitCursor

            _is = New informationSchema
            _is.connectionString = String.Format(My.Settings.defaultConnectionString, txtServer.Text, txtUser.Text, txtPass.Text, sslMode)

            If _is.TryConnect Then
                cboDatabases.DataSource = _is.databases.ToList
                cboDatabases.Enabled = True
                pContext.Visible = True
                cmdExport.Enabled = True
            End If
        Catch ex As Exception
            FormHelpers.dumpException(ex)

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDatabases.SelectedIndexChanged
        Try
            Cursor = Cursors.WaitCursor
            _is.database = cboDatabases.SelectedItem.ToString
            _is.enumAsString = chkEnum.Checked

            _is.fetchInfo()

            clearNodes()
            fillNodes()



        Catch ex As Exception
            FormHelpers.dumpException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#Region "treeview stuff"
    Private Sub clearNodes()
        Try
            tvObjects.Nodes.Item(0).Nodes.Clear()
            tvObjects.Nodes.Item(1).Nodes.Clear()
            tvObjects.Nodes.Item(2).Nodes.Clear()
            tvObjects.Nodes.Item(3).Nodes.Clear()
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub fillNodes()
        Try
            ' tables
            For Each itm In _is.tables.Where(Function(x) x.isView = False)
                tvObjects.Nodes.Item(0).Nodes.Add(itm.tableName)
                tvObjects.Nodes.Item(0).LastNode.ImageIndex = tvObjects.Nodes.Item(0).ImageIndex
                tvObjects.Nodes.Item(0).LastNode.SelectedImageIndex = tvObjects.Nodes.Item(0).SelectedImageIndex
                tvObjects.Nodes.Item(0).LastNode.Checked = True
            Next

            ' views
            For Each itm In _is.tables.Where(Function(x) x.isView = True)
                tvObjects.Nodes.Item(1).Nodes.Add(itm.tableName)
                tvObjects.Nodes.Item(1).LastNode.ImageIndex = tvObjects.Nodes.Item(1).ImageIndex
                tvObjects.Nodes.Item(1).LastNode.SelectedImageIndex = tvObjects.Nodes.Item(1).SelectedImageIndex
                tvObjects.Nodes.Item(1).LastNode.Checked = True
            Next

            ' functions
            For Each itm In _is.routines.Where(Function(r) r.isFunction)
                tvObjects.Nodes.Item(2).Nodes.Add(itm.routineName)
                tvObjects.Nodes.Item(2).LastNode.ImageIndex = tvObjects.Nodes.Item(2).ImageIndex
                tvObjects.Nodes.Item(2).LastNode.SelectedImageIndex = tvObjects.Nodes.Item(2).SelectedImageIndex
                tvObjects.Nodes.Item(2).LastNode.Checked = True
            Next

            ' procedures
            For Each itm In _is.routines.Where(Function(r) Not r.isFunction)
                tvObjects.Nodes.Item(3).Nodes.Add(itm.routineName)
                tvObjects.Nodes.Item(3).LastNode.ImageIndex = tvObjects.Nodes.Item(3).ImageIndex
                tvObjects.Nodes.Item(3).LastNode.SelectedImageIndex = tvObjects.Nodes.Item(3).SelectedImageIndex
                tvObjects.Nodes.Item(3).LastNode.Checked = True

                If itm.returnsRecordset Then
                    tvObjects.Nodes.Item(3).LastNode.ImageIndex = 11
                    tvObjects.Nodes.Item(3).LastNode.SelectedImageIndex = 11
                End If
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub tsbAll_Click(sender As Object, e As EventArgs) Handles tsbAll.Click
        Try
            Dim pNode As TreeNode

            If tvObjects.SelectedNode.Parent Is Nothing Then
                pNode = tvObjects.SelectedNode
            Else
                pNode = tvObjects.SelectedNode.Parent
            End If
            For Each cNode As TreeNode In pNode.Nodes
                cNode.Checked = True
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub tsbNone_Click(sender As Object, e As EventArgs) Handles tsbNone.Click
        Try
            Dim pNode As TreeNode

            If tvObjects.SelectedNode.Parent Is Nothing Then
                pNode = tvObjects.SelectedNode
            Else
                pNode = tvObjects.SelectedNode.Parent
            End If


            For Each cNode As TreeNode In pNode.Nodes
                cNode.Checked = False
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub tsbInvert_Click(sender As Object, e As EventArgs) Handles tsbInvert.Click
        Try
            Dim pNode As TreeNode

            If tvObjects.SelectedNode.Parent Is Nothing Then
                pNode = tvObjects.SelectedNode
            Else
                pNode = tvObjects.SelectedNode.Parent
            End If
            For Each cNode As TreeNode In pNode.Nodes
                cNode.Checked = Not cNode.Checked
            Next
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub


    Private Sub tvObjects_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvObjects.NodeMouseClick
        Try
            tvObjects.SelectedNode = e.Node
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub tvObjects_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvObjects.AfterCheck
        Try
            If e.Node.Parent Is Nothing Then
                For Each n As TreeNode In e.Node.Nodes
                    n.Checked = e.Node.Checked
                Next
            Else
                Select Case e.Node.Parent.Name
                    Case "tables", "views"
                        Dim tbl As Models.Table = _is.tables.Where(Function(t) t.tableName = e.Node.Text).FirstOrDefault

                        If Not tbl Is Nothing Then
                            tbl.export = e.Node.Checked
                        End If

                    Case "functions", "procedures"
                        Dim tbl As Models.Routine = _is.routines.Where(Function(t) t.routineName = e.Node.Text).FirstOrDefault

                        If Not tbl Is Nothing Then
                            tbl.export = e.Node.Checked
                        End If
                End Select
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub tvObjects_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvObjects.AfterSelect
        Try
            If e.Node.Level = 1 Then
                Select Case e.Node.Parent.Name
                    Case "tables"
                        Dim tableFields = (From f In _is.tables Where f.isView = False AndAlso f.tableName = e.Node.Text Select f).FirstOrDefault

                        If tableFields IsNot Nothing Then
                            dgv1.DataSource = tableFields.columns.ToArray
                        End If
                        dgv1.Refresh()

                        Dim foreignKeys = (From fk In _is.foreignKeys Where fk.referencedTableName = e.Node.Text Order By fk.ordinalPosition Select fk).ToList
                        dgv2.DataSource = foreignKeys
                        dgv2.Refresh()

                        'Dim ls = (From lk In _is.foreignKeys Where lk.tableName = e.Node.Text And lk.referencedTableName <> "" Order By lk.ordinalPosition Select lk).ToList


                        Dim tmp As String = _g.generateModel(tableFields, foreignKeys)

                        sPreviewModel.ReadOnly = False
                        sPreviewModel.Text = tmp
                        sPreviewModel.Colorize(0, sPreviewModel.TextLength)
                        sPreviewModel.ReadOnly = True

                        tmp = _g.generateMap(tableFields, foreignKeys)

                        sPreviewMap.ReadOnly = False
                        sPreviewMap.Text = tmp
                        sPreviewMap.Colorize(0, sPreviewMap.TextLength)
                        sPreviewMap.ReadOnly = True

                        TabControl1.SelectedTab = tabTable

                    Case "views"
                        Dim viewFields = (From v In _is.tables Where v.isView = True AndAlso v.tableName = e.Node.Text Select v).FirstOrDefault

                        If viewFields IsNot Nothing Then
                            dgv1.DataSource = viewFields.columns.ToArray
                        End If
                        dgv1.Refresh()

                        dgv2.DataSource = Nothing
                        dgv2.Refresh()

                        Dim tmp As String = _g.generateModel(viewFields, New List(Of Models.foreignKey))

                        sPreviewModel.ReadOnly = False
                        sPreviewModel.Text = tmp
                        sPreviewModel.Colorize(0, sPreviewModel.TextLength)
                        sPreviewModel.ReadOnly = True

                        tmp = _g.generateMap(viewFields, New List(Of Models.foreignKey))

                        sPreviewMap.ReadOnly = False
                        sPreviewMap.Text = tmp
                        sPreviewMap.Colorize(0, sPreviewMap.TextLength)
                        sPreviewMap.ReadOnly = True

                        TabControl1.SelectedTab = tabTable


                    Case "procedures", "functions"
                        _selectedRoutine = (From p In _is.routines Where p.routineName = e.Node.Text Select p).FirstOrDefault

                        If _selectedRoutine IsNot Nothing Then
                            scProcedure.ReadOnly = False
                            scProcedure.Text = _selectedRoutine.definition
                            scProcedure.Colorize(0, scProcedure.TextLength)
                            scProcedure.ReadOnly = True

                            If _selectedRoutine.params IsNot Nothing Then
                                dgProcedure.DataSource = (From par In _selectedRoutine.params Select New With {.name = par.paramName, .type = par.dataType, .value = par.value}).ToList
                                dgProcedure.Refresh()
                                dgProcedure.Columns.Item(0).ReadOnly = True
                                dgProcedure.Columns.Item(1).ReadOnly = True
                            End If

                            ListView1.Items.Clear()

                            If _selectedRoutine.returnLayout IsNot Nothing AndAlso _selectedRoutine.returnLayout.columns IsNot Nothing Then
                                For Each c In _selectedRoutine.returnLayout.columns
                                    Dim col As New ListViewItem
                                    col.Text = c.columnName
                                    col.SubItems.Add(c.vbType)
                                    ListView1.Items.Add(col)
                                Next
                            End If

                        End If

                        TabControl1.SelectedTab = tabProcedure

                    Case Else

                End Select

            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub
#End Region

#Region "Scintilla Lexer style"
    Private Sub InitLexer(_lexer As ScintillaNET.Scintilla)
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

            _lexer.Lexer = ScintillaNET.Lexer.Vb

            _lexer.CreateDocument()

            _lexer.Styles(ScintillaNET.Style.Vb.Default).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Default).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Default).ForeColor = Color.Gainsboro
            _lexer.Styles(ScintillaNET.Style.Vb.Default).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Default).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Comment).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Comment).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Comment).ForeColor = Color.FromArgb(-11033014)
            _lexer.Styles(ScintillaNET.Style.Vb.Comment).Italic = True
            _lexer.Styles(ScintillaNET.Style.Vb.Comment).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Comment).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Number).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Number).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Number).ForeColor = Color.FromArgb(-4862296)
            _lexer.Styles(ScintillaNET.Style.Vb.Number).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Number).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword).Bold = True
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword).ForeColor = Color.FromArgb(-11100970)
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword).Weight = 700
            _lexer.Styles(ScintillaNET.Style.Vb.[String]).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.[String]).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.[String]).ForeColor = Color.FromArgb(-2712187)
            _lexer.Styles(ScintillaNET.Style.Vb.[String]).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.[String]).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Preprocessor).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Preprocessor).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Preprocessor).ForeColor = Color.Gainsboro
            _lexer.Styles(ScintillaNET.Style.Vb.Preprocessor).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Preprocessor).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.[Operator]).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.[Operator]).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.[Operator]).ForeColor = Color.FromArgb(-4934476)
            _lexer.Styles(ScintillaNET.Style.Vb.[Operator]).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.[Operator]).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Identifier).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Identifier).ForeColor = Color.Gainsboro
            _lexer.Styles(ScintillaNET.Style.Vb.[Date]).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.[Date]).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.[Date]).ForeColor = Color.Green
            _lexer.Styles(ScintillaNET.Style.Vb.[Date]).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.[Date]).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.StringEol).ForeColor = Color.Navy
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword2).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword2).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword2).ForeColor = Color.Olive
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword2).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword2).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword3).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword3).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword3).ForeColor = Color.Purple
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword3).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword3).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword4).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword4).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword4).ForeColor = Color.Teal
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword4).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Keyword4).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Constant).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Constant).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Constant).ForeColor = Color.Gray
            _lexer.Styles(ScintillaNET.Style.Vb.Constant).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Constant).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.Asm).ForeColor = Color.FromArgb(-4194304)
            _lexer.Styles(ScintillaNET.Style.Vb.Label).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.Label).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.Label).ForeColor = Color.FromArgb(-16728064)
            _lexer.Styles(ScintillaNET.Style.Vb.Label).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.Label).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.[Error]).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.[Error]).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.[Error]).ForeColor = Color.FromArgb(-2600880)
            _lexer.Styles(ScintillaNET.Style.Vb.[Error]).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.[Error]).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.HexNumber).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.HexNumber).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.HexNumber).ForeColor = Color.FromArgb(-4145152)
            _lexer.Styles(ScintillaNET.Style.Vb.HexNumber).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.HexNumber).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.BinNumber).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.BinNumber).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.BinNumber).ForeColor = Color.FromArgb(-4194112)
            _lexer.Styles(ScintillaNET.Style.Vb.BinNumber).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.BinNumber).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).ForeColor = Color.FromArgb(-11033014)
            _lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).Italic = True
            _lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.CommentBlock).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.DocLine).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.DocLine).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.DocLine).ForeColor = Color.Silver
            _lexer.Styles(ScintillaNET.Style.Vb.DocLine).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.DocLine).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.DocBlock).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.DocBlock).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.DocBlock).ForeColor = Color.FromArgb(-4862296)
            _lexer.Styles(ScintillaNET.Style.Vb.DocBlock).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.DocBlock).SizeF = 10.0F
            _lexer.Styles(ScintillaNET.Style.Vb.DocKeyword).BackColor = Color.FromArgb(-14803426)
            _lexer.Styles(ScintillaNET.Style.Vb.DocKeyword).Font = "Consolas"
            _lexer.Styles(ScintillaNET.Style.Vb.DocKeyword).ForeColor = Color.FromArgb(-4862296)
            _lexer.Styles(ScintillaNET.Style.Vb.DocKeyword).Size = 10
            _lexer.Styles(ScintillaNET.Style.Vb.DocKeyword).SizeF = 10.0F


            _lexer.SetKeywords(0, My.Settings.keywords)

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub InitSqlLexer(_lexer As ScintillaNET.Scintilla)
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

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Text = FormHelpers.ApplicationTitle

            If Not FormHelpers.isDebug Then
                txtServer.Text = "dbext036441.bytenet.nl"
                txtUser.Text = "u036441_root"
                txtPass.Text = ""
                chkSsl.Checked = True
            End If

            InitLexer(sPreviewContext)
            InitLexer(sPreviewModel)
            InitLexer(sPreviewMap)
            InitSqlLexer(scProcedure)

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub cmdPreviewContext_Click(sender As Object, e As EventArgs) Handles cmdPreviewContext.Click
        Try
            If txtContextName.Text = "" Then
                MessageBox.Show("Missing contextname")
                Exit Sub
            End If

            Dim ts = (From t In _is.tables Where t.export Order By t.tableName Select t).ToList

            Dim tmp As String = _g.generateContext(ts, txtContextName.Text, chkRecovery.Checked)

            sPreviewContext.ReadOnly = False
            sPreviewContext.Text = tmp
            sPreviewContext.Colorize(0, sPreviewContext.TextLength)
            sPreviewContext.ReadOnly = True

            TabControl1.SelectedTab = tabContext


        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        cboDatabases_SelectedIndexChanged(Me, e)
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Try
            If txtContextName.Text = "" Then
                MessageBox.Show("Missing contextname")
                Exit Sub
            End If

            Dim exportPath As String = ""
            Dim modelPath As String = ""
            Dim mapPath As String = ""
            Dim storeModelPath As String = ""
            Dim output As String = ""
            Dim _p As New My.Templates.PluralizationService

            If fbdExport.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            exportPath = fbdExport.SelectedPath

            modelPath = String.Format("{0}\Models\", exportPath)
            mapPath = String.Format("{0}Mapping\", modelPath)
            storeModelPath = String.Format("{0}\Models\StoreCommandSchemas\", exportPath)

            If Not IO.Directory.Exists(modelPath) Then IO.Directory.CreateDirectory(modelPath)
            If Not IO.Directory.Exists(mapPath) Then IO.Directory.CreateDirectory(mapPath)
            If Not IO.Directory.Exists(storeModelPath) Then IO.Directory.CreateDirectory(storeModelPath)

            ' Export models & mappings
            For Each table In _is.tables.Where(Function(t) t.export)
                Dim foreignKeys = (From fk In _is.foreignKeys Where fk.referencedTableName = table.tableName Order By fk.ordinalPosition Select fk).ToList

                output = _g.generateModel(table, foreignKeys)

                Using fs As New IO.FileStream(String.Format("{0}{1}.vb", modelPath, table.singleName), IO.FileMode.Create)
                    Using sw As New IO.StreamWriter(fs, System.Text.Encoding.UTF8)
                        sw.Write(output)
                        sw.Flush()
                    End Using
                End Using

                output = _g.generateMap(table, New List(Of Models.foreignKey))

                Using fs As New IO.FileStream(String.Format("{0}{1}Map.vb", mapPath, table.singleName), IO.FileMode.Create)
                    Using sw As New IO.StreamWriter(fs, System.Text.Encoding.UTF8)
                        sw.Write(output)
                        sw.Flush()
                    End Using
                End Using
            Next

            ' Export Context
            Dim ts = (From t In _is.tables Where t.export Order By t.tableName Select t).ToList
            output = _g.generateContext(ts, txtContextName.Text, chkRecovery.Checked)

            Using fs As New IO.FileStream(String.Format("{0}{1}DataContext.vb", modelPath, txtContextName.Text), IO.FileMode.Create)
                Using sw As New IO.StreamWriter(fs, System.Text.Encoding.UTF8)
                    sw.Write(output)
                    sw.Flush()
                End Using
            End Using

            ' Export StoreCommands
            output = _g.generateStoreCommands(_is.routines.Where(Function(rr) rr.isFunction AndAlso rr.export).ToList, _is.routines.Where(Function(aa) Not aa.isFunction AndAlso aa.export).ToList, txtContextName.Text)
            Using fs As New IO.FileStream(String.Format("{0}{1}DataStoreCommands.vb", modelPath, txtContextName.Text), IO.FileMode.Create)
                Using sw As New IO.StreamWriter(fs, System.Text.Encoding.UTF8)
                    sw.Write(output)
                    sw.Flush()
                End Using
            End Using

            For Each _r In _is.routines.Where(Function(x) x.export AndAlso Not x.isFunction AndAlso x.returnsRecordset AndAlso x.returnLayout.columns.Any()).ToList
                output = _g.generateStoreCommandSchema(_r)

                Using fs As New IO.FileStream(String.Format("{0}{1}.vb", storeModelPath, _r.returnLayout.singleName), IO.FileMode.Create)
                    Using sw As New IO.StreamWriter(fs, System.Text.Encoding.UTF8)
                        sw.Write(output)
                        sw.Flush()
                    End Using
                End Using

            Next

            MessageBox.Show("All done")

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cmdExecuteProcedure_Click(sender As Object, e As EventArgs) Handles cmdExecuteProcedure.Click
        Try

            If _selectedRoutine Is Nothing Then
                MessageBox.Show("No procedure selected")
                Exit Sub
            End If

            For Each row As DataGridViewRow In dgProcedure.Rows
                Dim param = _selectedRoutine.params.FirstOrDefault(Function(p) p.paramName = row.Cells(0).Value.ToString)

                If param IsNot Nothing Then
                    param.value = row.Cells(2).Value.ToString
                End If
            Next

            _is.getRoutineLayout(_selectedRoutine)

            ListView1.Items.Clear()

            If _selectedRoutine.returnLayout IsNot Nothing AndAlso _selectedRoutine.returnLayout.columns IsNot Nothing Then
                For Each c In _selectedRoutine.returnLayout.columns
                    Dim col As New ListViewItem
                    col.Text = c.columnName
                    col.SubItems.Add(c.vbType)
                    ListView1.Items.Add(col)
                Next
            End If

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub cmdDict_Click(sender As Object, e As EventArgs) Handles cmdDict.Click
        Try
            Dim frx As New customDictionaryEdit

            If frx.ShowDialog() = DialogResult.OK Then
                _is.updatePluralizationService()
            End If

            frx.Dispose()

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub


End Class
