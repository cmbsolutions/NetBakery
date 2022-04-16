Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Viewer1.AddTable("examples", New List(Of vbq.DbFieldInfo)({
                                                                  New vbq.DbFieldInfo With {.name = "example_id", .type = "int(10)", .isKey = True},
                                                                  New vbq.DbFieldInfo With {.name = "created", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "modified", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "state", .type = "enum"},
                                                                  New vbq.DbFieldInfo With {.name = "condition_id", .type = "char(15)"},
                                                                  New vbq.DbFieldInfo With {.name = "condition_dt", .type = "datetime"},
                                                                  New vbq.DbFieldInfo With {.name = "description", .type = "varchar(255)"},
                                                                  New vbq.DbFieldInfo With {.name = "amount", .type = "decimal(10,2)"}
                                                                  }))

    End Sub
End Class
