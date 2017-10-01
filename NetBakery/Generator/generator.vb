Public Class generator

    'Private _keywords As New List(Of String)

    Public Sub New()
        ' _keywords.AddRange(My.Settings.keywords.Split(" "c))
    End Sub

    Public Function generateModel(ByVal _t As Models.Table, ByVal _f As List(Of Models.foreignKey)) As String
        Try
            ' Try to find column names that are vb keywords and add []
            'For Each c As Models.Column In _t.columns
            '    If _keywords.Exists(Function(k) k = c.columnName) Then
            '        c.columnName = String.Format("[{0}]", c.columnName)
            '    End If

            '    For i As Integer = 0 To c.enumData.Count - 1
            '        Dim data As String = c.enumData.Item(i)
            '        If _keywords.Exists(Function(k) k = data.ToLower) Then
            '            c.enumData.Item(i) = String.Format("[{0}]", data)
            '        End If
            '    Next
            'Next

            Dim page = New My.Templates.Model(_t, _f)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generateMap(ByVal _t As Models.Table, ByVal _f As List(Of Models.foreignKey)) As String
        Try
            ' Try to find column names that are vb keywords and add []
            'For Each c As Models.Column In _t.columns
            '    If _keywords.Exists(Function(k) k = c.columnName) Then
            '        c.columnName = String.Format("[{0}]", c.columnName)
            '    End If

            '    For i As Integer = 0 To c.enumData.Count - 1
            '        Dim data As String = c.enumData.Item(i)
            '        If _keywords.Exists(Function(k) k = data.ToLower) Then
            '            c.enumData.Item(i) = String.Format("[{0}]", data)
            '        End If
            '    Next
            'Next

            Dim page = New My.Templates.Map(_t, _f)
            Dim pageContent = page.TransformText()
            Return pageContent
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generateContext(ByVal tables As List(Of Models.Table), ByVal name As String, ByVal recovery As Boolean) As String
        Try
            Dim page = New My.Templates.Context(tables, name, recovery)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generateStoreCommands(ByVal functions As List(Of Models.Routine), ByVal procedures As List(Of Models.Routine), ByVal name As String) As String
        Try
            Dim page = New My.Templates.StoreCommands(functions, procedures, name)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generateStoreCommandSchema(ByVal procedure As Models.Routine) As String
        Try
            Dim page = New My.Templates.StoreCommandModel(procedure)
            Dim pageContent = page.TransformText

            Return pageContent
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
