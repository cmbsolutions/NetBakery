Imports DevComponents

Public Class mainGUI
    Private _mngr As infoSchema.manager
    Private _g As New generator

    Private Sub mainGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Text = FormHelpers.ApplicationTitle
            TitleText = Text

            SideBar1.ExpandedPanel = SideBarPanelItem1

            If Not FormHelpers.isDebug Then
                txtHost.Text = "dbext036441.bytenet.nl"
                txtUser.Text = "u036441_root"
                txtPass.Text = ""
                sbiSSL.Value = True
            End If

            'InitLexer(sPreviewModel)
            'InitLexer(sPreviewMap)
        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub

#Region "advTree methods"
    Private Sub clearTree(rootNode As String)
        Try
            AdvTree1.Nodes.Find(rootNode, False).First.Nodes.Clear()

        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub appendTables()
        Try
            Dim tableNode As AdvTree.Node = AdvTree1.Nodes.Find("tables", False).FirstOrDefault

            For Each table In _mngr.tables.Where(Function(t) Not t.isView)
                Dim node As New AdvTree.Node With {.Name = table.tableName, .CheckBoxVisible = True, .Checked = True, .DragDropEnabled = False, .Editable = False, .ImageIndex = 0, .Text = table.tableName, .StyleSelected = ElementStyle2}

                'For Each c In table.columns
                '    Dim cNode As New AdvTree.Node With {.Name = c.name, .Editable = False, .Text = c.name, .StyleSelected = ElementStyle2}

                '    Dim cc1 As New AdvTree.Cell With {.Name = c.name & "_type", .Editable = False, .Text = c.mysqlType}
                '    Dim cc2 As New AdvTree.Cell With {.Name = c.name & "_length", .Editable = False, .Text = c.maximumLength.ToString}

                '    cNode.Cells.Add(cc1)
                '    cNode.Cells.Add(cc2)

                '    node.Nodes.Add(cNode)
                'Next

                'Dim tc As New AdvTree.Cell With {.Name = table.tableName & "ColumnCount", .Editable = False, .TextDisplayFormat = "(0)", .Text = table.columns.Count.ToString}

                'node.Cells.Add(tc)
                tableNode.Nodes.Add(node)
            Next

            tableCount.Text = _mngr.tables.Where(Function(t) Not t.isView).Count.ToString
        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub appendViews()
        Try
            Dim viewNode As AdvTree.Node = AdvTree1.Nodes.Find("views", False).FirstOrDefault

            For Each view In _mngr.tables.Where(Function(t) t.isView)
                Dim node As New AdvTree.Node With {.Name = view.tableName, .CheckBoxVisible = True, .Checked = True, .DragDropEnabled = False, .Editable = False, .ImageIndex = 1, .Text = view.tableName, .StyleSelected = ElementStyle2}
                viewNode.Nodes.Add(node)
            Next

            viewCount.Text = _mngr.tables.Where(Function(t) t.isView).Count.ToString
        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub appendFunctions()
        Try
            Dim functionNode As AdvTree.Node = AdvTree1.Nodes.Find("functions", False).FirstOrDefault

            For Each func In _mngr.routines.Where(Function(t) t.isFunction)
                Dim node As New AdvTree.Node With {.Name = func.name, .CheckBoxVisible = True, .Checked = True, .DragDropEnabled = False, .Editable = False, .ImageIndex = 2, .Text = func.name, .StyleSelected = ElementStyle2}
                functionNode.Nodes.Add(node)
            Next

            functionCount.Text = _mngr.routines.Where(Function(t) t.isFunction).Count.ToString
        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub appendProcedures()
        Try
            Dim procedureNode As AdvTree.Node = AdvTree1.Nodes.Find("procedures", False).FirstOrDefault

            For Each func In _mngr.routines.Where(Function(t) Not t.isFunction)
                Dim node As New AdvTree.Node With {.Name = func.name, .CheckBoxVisible = True, .Checked = True, .DragDropEnabled = False, .Editable = False, .ImageIndex = 3, .Text = func.name, .StyleSelected = ElementStyle2}
                procedureNode.Nodes.Add(node)
            Next

            procedureCount.Text = _mngr.routines.Where(Function(t) Not t.isFunction).Count.ToString
        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub
    Private Sub AdvTree1_NodeClick(sender As Object, e As AdvTree.TreeNodeMouseEventArgs) Handles AdvTree1.NodeClick
        Try
            If e.Node Is Nothing Then Exit Sub

            Select Case e.Node.Name
                Case "tables"
                    DataGridViewX1.DataSource = (From t In _mngr.tables Where Not t.isView Select t.tableName, t.singleName, t.pluralName).ToList
                    DataGridViewX1.AutoResizeColumns()
                    DataGridViewX1.Refresh()
                    LabelX1.Text = "Tables"
                Case "views"
                    DataGridViewX1.DataSource = (From t In _mngr.tables Where t.isView Select t.tableName, t.singleName, t.pluralName).ToList
                    DataGridViewX1.AutoResizeColumns()
                    DataGridViewX1.Refresh()
                    LabelX1.Text = "Views"
                Case Else
                    If e.Node.Parent IsNot Nothing Then
                        Select Case e.Node.Parent.Name
                            Case "tables", "views"
                                DataGridViewX1.DataSource = (From t In _mngr.tables From c In t.columns Where t.tableName = e.Node.Text Select c.name, c.mysqlType, c.maximumLength).ToList
                                DataGridViewX1.AutoResizeColumns()
                                DataGridViewX1.Refresh()
                                LabelX1.Text = "Columns"
                            Case "functions", "procedures"
                                DataGridViewX1.DataSource = (From r In _mngr.routines From p In r.params Where r.name = e.Node.Text Select p.name, p.mysqlType, p.maximumLength).ToList
                                DataGridViewX1.AutoResizeColumns()
                                DataGridViewX1.Refresh()
                                LabelX1.Text = "Parameters"
                            Case Else
                        End Select
                    End If
            End Select
        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub

    '    Following code enumerates through all nodes And prints out node text To console
    'For Each node As Node In AllNodes(advTree1.Nodes)
    '	Console.WriteLine(node.Text)
    'Next node

    ' This is what makes flat access to tree nodes easy
    Private Shared Iterator Function AllNodes(ByVal nodes As AdvTree.NodeCollection) As IEnumerable
        For i As Integer = 0 To nodes.Count - 1
            Dim node As AdvTree.Node = nodes(i)
            Yield node
            If node.Nodes.Count > 0 Then
                For Each item As AdvTree.Node In AllNodes(node.Nodes)
                    Yield item
                Next item
            End If
        Next i
    End Function
#End Region

#Region "Global form methods"

#End Region

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        Try
            If txtHost.Text = "" Then
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
            If sbiSSL.Value Then
                sslMode = "Required"
            Else
                sslMode = "Prefered"
            End If

            _mngr = New infoSchema.manager
            '_mngr.connectionString = String.Format(My.Settings.defaultConnectionString, txtHost.Text, txtUser.Text, txtPass.Text, sslMode)

            If _mngr.TryConnect Then
                cboDatabases.ComboBoxEx.DataSource = _mngr.databases.ToList
                cboDatabases.Enabled = True
                cmdConnect.StopPulseOnMouseOver = True
                cmdConnect.Pulse()
            Else

            End If
        Catch mex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(mex.Message)
        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub

    Private Sub cboDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDatabases.SelectedIndexChanged
        Try
            _mngr.database = cboDatabases.SelectedItem.ToString

            _mngr.initSchema()
            clearTree("tables")
            clearTree("views")
            clearTree("functions")
            clearTree("procedures")

            _mngr.harvestObjects()


            appendTables()
            appendViews()
            appendFunctions()
            appendProcedures()

        Catch ex As Exception
            formHelpers.dumpException(ex)
        End Try
    End Sub


End Class