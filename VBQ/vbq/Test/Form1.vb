Imports Newtonsoft.Json

Public Class Form1
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' Turn on WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private tables As List(Of infoSchema.table)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'tables = CType(JsonConvert.DeserializeObject(IO.File.ReadAllText("d:\test\tables.json"), GetType(List(Of infoSchema.table))), List(Of infoSchema.table))

        'For Each t In tables.Where(Function(c) Not c.isView)
        '    Dim dfi As New List(Of vbq.DbFieldInfo)

        '    For Each c In t.columns
        '        dfi.Add(New vbq.DbFieldInfo With {
        '                .name = c.name,
        '                .type = c.MySqlColumnType,
        '                .isKey = c.autoIncrement
        '                })
        '    Next

        '    Viewer1.AddTable(t.name, dfi)
        'Next

        Viewer1.AddTable("examples", New List(Of vbq.DbFieldInfo)({
                                                                  New vbq.DbFieldInfo With {.name = "example_id", .type = "int(10)", .isKey = True},
                                                                  New vbq.DbFieldInfo With {.name = "created", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "modified", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "state", .type = "enum"},
                                                                  New vbq.DbFieldInfo With {.name = "condition_id", .type = "char(15)", .isLink = True},
                                                                  New vbq.DbFieldInfo With {.name = "condition_dt", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "description", .type = "varchar(255)"},
                                                                  New vbq.DbFieldInfo With {.name = "amount", .type = "decimal(10,2)"}
                                                                  }))

        Viewer1.AddTable("examplevalues", New List(Of vbq.DbFieldInfo)({
                                                          New vbq.DbFieldInfo With {.name = "examplevalue_id", .type = "int(10)", .isKey = True},
                                                          New vbq.DbFieldInfo With {.name = "created", .type = "datetime"},
                                                          New vbq.DbFieldInfo With {.name = "modified", .type = "datetime"},
                                                          New vbq.DbFieldInfo With {.name = "state", .type = "enum"},
                                                          New vbq.DbFieldInfo With {.name = "condition_id", .type = "char(15)", .isLink = True},
                                                          New vbq.DbFieldInfo With {.name = "condition_dt", .type = "datetime"},
                                                          New vbq.DbFieldInfo With {.name = "example_id", .type = "int(10)", .isLink = True},
                                                          New vbq.DbFieldInfo With {.name = "description", .type = "varchar(255)"},
                                                          New vbq.DbFieldInfo With {.name = "amount", .type = "decimal(10,2)"}
                                                          }))

        Viewer1.AddTable("exampleconditions", New List(Of vbq.DbFieldInfo)({
                                                                  New vbq.DbFieldInfo With {.name = "examplecondition_id", .type = "char(15)", .isKey = True},
                                                                  New vbq.DbFieldInfo With {.name = "created", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "modified", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "state", .type = "enum"},
                                                                  New vbq.DbFieldInfo With {.name = "label", .type = "varchar(150)"},
                                                                  New vbq.DbFieldInfo With {.name = "description", .type = "varchar(255)"}
                                                                  }))

        Viewer1.AddLink("examples", "examplevalues")
        Viewer1.AddLink("examples", "exampleconditions")
        Viewer1.AddLink("examplevalues", "exampleconditions")

    End Sub
End Class
