Imports Newtonsoft.Json
Public Class Form1
    Private tables As List(Of infoSchema.table)
    Private ControlMovers As List(Of Helper.ControlMover)

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            tables = JsonConvert.DeserializeObject(Of List(Of infoSchema.table))(IO.File.ReadAllText("d:\test\tables.json"))
            tables.RemoveAll(Function(c) c.isView)
            ControlMovers = New List(Of Helper.ControlMover)

            Dim x, y As Integer

            x = 5
            y = 30

            For Each table In tables
                Dim ctrl As New ERDiagram.cTable

                ctrl.Title = table.name
                ctrl.SetFields(table.columns.ToArray, "name")
                ctrl.Name = table.name

                ctrl.Left = x
                ctrl.Top = y

                x += ctrl.Width + 5

                If x > Width Then
                    x = 5
                    y += ctrl.Height + 5
                End If

                ControlMovers.Add(New Helper.ControlMover(ctrl, Panel1, Helper.ControlMover.Direction.Any))
                Panel1.Controls.Add(ctrl)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
