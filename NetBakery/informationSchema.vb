Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports NetBakery.Models

Public Class informationSchema
    Property connectionString As String = ""
    Private _dbConnection As MySqlConnection
    Private _dbCommand As MySqlCommand
    Private _p As New PluralizationService
    Private _keywords As New List(Of String)

    Property database As String = ""
    Property enumAsString As Boolean = False

    Property databases As List(Of String)
    Property tables As List(Of Table)
    Property foreignKeys As List(Of foreignKey)
    Property routines As List(Of Routine)

    Public Sub New()
        _keywords.AddRange(My.Resources.vb_keywords.Split(" "c))
    End Sub
    Public Sub updatePluralizationService()
        _p = New PluralizationService
    End Sub
    Public Function TryConnect() As Boolean
        Try
            getDatabases()

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub fetchInfo()
        Try
            getTables()
            getTableFields()
            getRelations()
            getForeignKeys()
            getViews()
            getViewFields()
            getRoutines()

        Catch ex As Exception
            Throw
        End Try
    End Sub



#Region "read objects"

    Private Sub getDatabases()
        Try
            Using _dbCommand = New MySqlCommand

                _dbCommand.Connection = dbConnection()
                _dbCommand.CommandText = "SELECT SCHEMA_NAME FROM SCHEMATA WHERE SCHEMA_NAME NOT IN ('information_schema', 'mysql', 'performance_schema', 'sys') ORDER BY SCHEMA_NAME"

                Using rdr As MySqlDataReader = _dbCommand.ExecuteReader

                    databases = New List(Of String)

                    While rdr.Read
                        databases.Add(rdr(0).ToString)
                    End While
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub getTables()
        Try
            Using _dbCommand = New MySqlCommand

                _dbCommand.Connection = dbConnection()
                _dbCommand.CommandText = "SELECT TABLE_NAME FROM TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_SCHEMA='" & database & "'"

                Using rdr As MySqlDataReader = _dbCommand.ExecuteReader

                    tables = New List(Of Table)

                    While rdr.Read
                        tables.Add(New Table With {.tableName = rdr("TABLE_NAME").ToString, .singleName = _p.Singularize(rdr("TABLE_NAME").ToString), .pluralName = _p.Pluralize(rdr("TABLE_NAME").ToString)})
                    End While
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub getViews()
        Try
            Using _dbCommand = New MySqlCommand

                _dbCommand.Connection = dbConnection()
                _dbCommand.CommandText = "SELECT TABLE_NAME FROM TABLES WHERE TABLE_TYPE='VIEW' AND TABLE_SCHEMA='" & database & "'"

                Using rdr As MySqlDataReader = _dbCommand.ExecuteReader

                    While rdr.Read
                        tables.Add(New Table With {.tableName = rdr("TABLE_NAME").ToString, .isView = True, .singleName = _p.Singularize(rdr("TABLE_NAME").ToString), .pluralName = _p.Pluralize(rdr("TABLE_NAME").ToString)})
                    End While
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub getRoutines()
        Try
            Using _dbCommand = New MySqlCommand

                _dbCommand.Connection = dbConnection()
                _dbCommand.CommandText = "SELECT r.ROUTINE_TYPE, r.ROUTINE_NAME, r.ROUTINE_DEFINITION, p.ORDINAL_POSITION, p.PARAMETER_NAME, p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION FROM ROUTINES AS r LEFT JOIN PARAMETERS AS p ON r.ROUTINE_SCHEMA = p.SPECIFIC_SCHEMA AND r.ROUTINE_NAME = p.SPECIFIC_NAME WHERE r.ROUTINE_SCHEMA = '" & database & "' ORDER BY p.SPECIFIC_NAME ASC, p.ORDINAL_POSITION ASC"

                Using rdr As MySqlDataReader = _dbCommand.ExecuteReader

                    routines = New List(Of Routine)

                    Dim rt As Routine = Nothing

                    While rdr.Read
                        If rt Is Nothing OrElse rt.routineName <> rdr("ROUTINE_NAME").ToString Then
                            If rt IsNot Nothing Then
                                If Not rt.isFunction AndAlso rt.returnsRecordset Then
                                    getRoutineLayout(rt, False)
                                End If
                                routines.Add(rt)
                            End If
                            rt = New Routine With {.routineName = rdr("ROUTINE_NAME").ToString}
                            rt.returnsRecordset = Regex.IsMatch(rdr("ROUTINE_DEFINITION").ToString, My.Settings.routineRegex, RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Multiline)
                            If rt.returnsRecordset Then
                                rt.returnLayout = New Table With {.tableName = rt.routineName, .singleName = _p.Singularize(rt.routineName), .pluralName = _p.Pluralize(rt.routineName), .columns = New List(Of Column)}
                            End If
                            rt.definition = rdr("ROUTINE_DEFINITION").ToString
                        End If

                        Dim p As New Parameter

                        p.dataType = rdr("DATA_TYPE").ToString
                        p.maximumLength = toLong(rdr("CHARACTER_MAXIMUM_LENGTH"))
                        p.numericPrecision = toInteger(rdr("NUMERIC_PRECISION"))
                        p.vbType = getVbType(rdr("DATA_TYPE").ToString)
                        p.paramName = rdr("PARAMETER_NAME").ToString

                        If rdr("ROUTINE_TYPE").ToString = "FUNCTION" Then
                            rt.isFunction = True

                            If toInteger(rdr("ORDINAL_POSITION")) = 0 Then
                                rt.returnParam = p
                            End If
                        End If

                        If toInteger(rdr("ORDINAL_POSITION")) > 0 Then
                            If Not rt.isFunction AndAlso rt.returnsRecordset Then
                                p.value = "1"
                            End If
                            rt.params.Add(p)
                        End If
                    End While

                    If rt IsNot Nothing Then
                        If Not rt.isFunction AndAlso rt.returnsRecordset Then
                            getRoutineLayout(rt, False)
                        End If
                        routines.Add(rt)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub getTableFields()
        Try
            For Each t In tables.Where(Function(x) x.isView = False)
                Debug.WriteLine(t.tableName)
                Debug.Indent()
                t.columns = New List(Of Column)

                Using _dbCommand = New MySqlCommand
                    _dbCommand.Connection = dbConnection()
                    _dbCommand.CommandText = "SELECT COLUMN_NAME,ORDINAL_POSITION,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE,COLUMN_TYPE,COLUMN_KEY,EXTRA FROM COLUMNS WHERE TABLE_SCHEMA = '" & database & "' AND TABLE_NAME = '" & t.tableName & "' ORDER BY ORDINAL_POSITION ASC"

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader()
                        While rdr.Read
                            Dim c As New Column
                            c.columnName = rdr("COLUMN_NAME").ToString

                            Debug.WriteLine(c.columnName)
                            c.columnAlias = AliasGenerator(rdr("COLUMN_NAME").ToString)

                            c.ordinalPosition = CInt(rdr("ORDINAL_POSITION"))
                            c.defaultValue = rdr("COLUMN_DEFAULT").ToString
                            c.isNullable = If(rdr("IS_NULLABLE").ToString = "YES", True, False)
                            c.dataType = rdr("DATA_TYPE").ToString
                            c.maximumLength = toLong(rdr("CHARACTER_MAXIMUM_LENGTH"))
                            c.numericPrecision = toInteger(rdr("NUMERIC_PRECISION"))
                            c.numericScale = toInteger(rdr("NUMERIC_SCALE"))
                            c.key = rdr("COLUMN_KEY").ToString
                            c.autoIncrement = If(rdr("EXTRA").ToString = "auto_increment", True, False)
                            c.vbType = getVbType(rdr("DATA_TYPE").ToString)

                            If c.vbType = "Enum" Then
                                c.enumData = parseEnum(rdr("COLUMN_TYPE").ToString)
                                c.vbType = "e" & c.columnName
                            End If
                            t.columns.Add(c)
                        End While
                    End Using
                    Debug.Unindent()
                End Using
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub getViewFields()
        Try
            For Each t In tables.Where(Function(x) x.isView = True)

                t.columns = New List(Of Column)

                Using _dbCommand = New MySqlCommand
                    _dbCommand.Connection = dbConnection()
                    _dbCommand.CommandText = "SELECT COLUMN_NAME,ORDINAL_POSITION,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE,COLUMN_TYPE,COLUMN_KEY,EXTRA FROM COLUMNS WHERE TABLE_SCHEMA = '" & database & "' AND TABLE_NAME = '" & t.tableName & "' ORDER BY ORDINAL_POSITION ASC"

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader()
                        While rdr.Read
                            Dim c As New Column
                            c.columnName = rdr("COLUMN_NAME").ToString
                            c.columnAlias = AliasGenerator(rdr("COLUMN_NAME").ToString)
                            c.ordinalPosition = CInt(rdr("ORDINAL_POSITION"))
                            c.defaultValue = rdr("COLUMN_DEFAULT").ToString
                            c.isNullable = If(rdr("IS_NULLABLE").ToString = "YES", True, False)
                            c.dataType = rdr("DATA_TYPE").ToString
                            c.maximumLength = toLong(rdr("CHARACTER_MAXIMUM_LENGTH"))
                            c.numericPrecision = toInteger(rdr("NUMERIC_PRECISION"))
                            c.numericScale = toInteger(rdr("NUMERIC_SCALE"))
                            c.key = rdr("COLUMN_KEY").ToString
                            'c.autoIncrement = If(rdr("EXTRA").ToString = "auto_increment", True, False)
                            c.vbType = getVbType(rdr("DATA_TYPE").ToString)
                            If c.vbType = "Enum" Then
                                c.enumData = parseEnum(rdr("COLUMN_TYPE").ToString)
                                c.vbType = "e" & c.columnName
                            End If
                            t.columns.Add(c)
                        End While
                    End Using
                End Using
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub getForeignKeys()
        Try
            Using _dbCommand = New MySqlCommand
                _dbCommand.Connection = dbConnection()
                _dbCommand.CommandText = "SELECT CONSTRAINT_NAME, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, POSITION_IN_UNIQUE_CONSTRAINT, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME FROM KEY_COLUMN_USAGE WHERE CONSTRAINT_SCHEMA = '" & database & "'"

                Using rdr As MySqlDataReader = _dbCommand.ExecuteReader()

                    foreignKeys = New List(Of foreignKey)

                    While rdr.Read
                        Dim f As New foreignKey
                        f.constraintName = rdr("CONSTRAINT_NAME").ToString
                        f.tableName = rdr("TABLE_NAME").ToString
                        f.columnName = rdr("COLUMN_NAME").ToString
                        f.ordinalPosition = toInteger(rdr("ORDINAL_POSITION"))
                        f.positionInUniqueConstraint = toInteger(rdr("POSITION_IN_UNIQUE_CONSTRAINT"))
                        f.referencedTableName = rdr("REFERENCED_TABLE_NAME").ToString
                        f.referencedColumnName = rdr("REFERENCED_COLUMN_NAME").ToString

                        ' hack
                        If foreignKeys.Where(Function(d) d.tableName = f.tableName AndAlso d.referencedTableName = f.referencedTableName).Count > 0 Then
                            f.propertyAlias = String.Format("{0}1", f.tableName)
                        Else
                            f.propertyAlias = f.tableName
                        End If

                        foreignKeys.Add(f)
                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub getRelations()
        Try
            Using _dbCommand = New MySqlCommand
                _dbCommand.Connection = dbConnection()
                _dbCommand.CommandText = "SELECT t.TABLE_NAME AS thistable, kcu.COLUMN_NAME AS thiscolumn, kcu.REFERENCED_TABLE_NAME AS othertable, kcu.REFERENCED_COLUMN_NAME AS othercolumn, kcu.ORDINAL_POSITION AS thisposition, IF(c.IS_NULLABLE = 'YES', TRUE, FALSE) AS optional FROM `TABLES` AS t LEFT JOIN KEY_COLUMN_USAGE AS kcu ON t.TABLE_SCHEMA = kcu.TABLE_SCHEMA AND t.TABLE_NAME = kcu.TABLE_NAME LEFT JOIN `COLUMNS` AS c ON kcu.TABLE_SCHEMA = c.TABLE_SCHEMA AND kcu.TABLE_NAME = c.TABLE_NAME AND kcu.COLUMN_NAME = c.COLUMN_NAME WHERE t.TABLE_SCHEMA = '" & database & "' AND kcu.REFERENCED_TABLE_NAME IS NOT NULL"

                Using rdr As MySqlDataReader = _dbCommand.ExecuteReader()

                    While rdr.Read
                        Dim r As New relation

                        r.thistable = rdr("thistable").ToString
                        r.thiscolumn = rdr("thiscolumn").ToString
                        r.othertable = rdr("othertable").ToString
                        r.othercolumn = rdr("othercolumn").ToString
                        r.optional = CBool(toInteger(rdr("optional")))
                        r.thisposition = toInteger(rdr("thisposition"))

                        ' add to another relation as multi
                        'If r.thisposition > 1 Then
                        '    Dim t = (From table In tables Where table.tableName = r.thistable Select table).FirstOrDefault

                        '    If t IsNot Nothing Then
                        '        Dim tr = (From m In t.relations Where m.othertable = r.othertable Select m).FirstOrDefault

                        '        If tr IsNot Nothing Then
                        '            tr.multi.Add(r)
                        '        End If
                        '    End If
                        'Else ' add to table
                        Dim t = (From table In tables Where table.tableName = r.thistable Select table).FirstOrDefault

                        If t IsNot Nothing Then
                            Dim tr = (From m In t.relations Where m.othertable = r.othertable Select m).FirstOrDefault

                            If tr IsNot Nothing Then
                                Dim i As Integer = 1

                                Dim newalias As String = String.Format("{0}{1}", _p.Singularize(r.othertable), i)

                                Dim tr2 = (From m2 In t.relations Where m2.alias = newalias Select m2).FirstOrDefault

                                While tr2 IsNot Nothing
                                    i += 1
                                    newalias = String.Format("{0}{1}", _p.Singularize(r.othertable), i)

                                    tr2 = (From m2 In t.relations Where m2.alias = newalias Select m2).FirstOrDefault
                                End While

                                r.alias = newalias
                                ' hack
                                r.thistable = r.thistable & i.ToString
                            Else
                                r.alias = _p.Singularize(r.othertable)
                            End If
                            t.relations.Add(r)
                        End If
                        'End If

                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getRoutineLayout(ByRef _routine As Models.Routine, Optional throwExceptions As Boolean = True)
        Try
            Using localConnection As New MySqlConnection(connectionString)
                localConnection.Open()

                Using _dbxCommand = New MySqlCommand
                    _dbxCommand.Connection = localConnection
                    localConnection.ChangeDatabase(database)

                    _dbxCommand.CommandType = CommandType.Text
                    _dbxCommand.CommandText = String.Format("CALL {0}({1})", _routine.routineName, String.Join(",", (From r In _routine.params Order By r.ordinalPosition Select "@" & r.paramName)))

                    For Each param In _routine.params.OrderBy(Function(o) o.ordinalPosition)
                        _dbxCommand.Parameters.AddWithValue("@" & param.paramName, param.value)
                    Next

                    Using rdr As MySqlDataReader = _dbxCommand.ExecuteReader()

                        Using d As DataTable = rdr.GetSchemaTable

                            For Each row As DataRow In d.Rows
                                Dim c As New Column

                                c.columnName = row.ItemArray(d.Columns.IndexOf("ColumnName")).ToString
                                c.columnAlias = AliasGenerator(c.columnName)
                                c.dataType = [Enum].GetName(GetType(MySqlDbType), row.ItemArray(d.Columns.IndexOf("ProviderType")))
                                c.vbType = getVbType(c.dataType)
                                c.ordinalPosition = CInt(row.ItemArray(d.Columns.IndexOf("ColumnOrdinal")))
                                c.isNullable = CBool(row.ItemArray(d.Columns.IndexOf("AllowDBNull")))

                                If _routine.returnLayout Is Nothing Then
                                    _routine.returnsRecordset = True
                                    _routine.returnLayout = New Table With {.tableName = _routine.routineName, .singleName = _p.Singularize(_routine.routineName), .pluralName = _p.Pluralize(_routine.routineName), .columns = New List(Of Column)}
                                End If
                                _routine.returnLayout.columns.Add(c)
                            Next
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            If throwExceptions Then Throw
        End Try
    End Sub


#End Region

    Public Function dbConnection() As MySqlConnection
        Try
            If _dbConnection Is Nothing OrElse _dbConnection.State = ConnectionState.Closed Then
                _dbConnection = New MySqlConnection(connectionString)
                _dbConnection.Open()
            End If

            _dbConnection.ChangeDatabase("information_schema")

            Return _dbConnection
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function toInteger(obj As Object) As Integer
        Try
            If obj.ToString = "" Then
                Return 0
            Else
                Return CInt(obj.ToString)
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function toLong(obj As Object) As Long
        Try
            If obj.ToString = "" Then
                Return 0
            Else
                Return CLng(obj.ToString)
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Function getVbType(mysqlType As String) As String
        Select Case mysqlType.ToLower
            Case "tinyint", "mediumint", "integer", "int", "smallint", "int16", "int24", "int32", "uint16", "uint24", "uint32"
                Return "Integer"
            Case "bigint", "int64", "uint64"
                Return "Long"
            Case "char", "varchar", "text", "tinytext", "mediumtext", "longtext", "string", "varstring", "varbinary", "binary", "tinyblob", "mediumblob", "longblob"
                Return "String"
            Case "time", "timestamp"
                Return "TimeSpan"
            Case "date", "datetime"
                Return "Date"
            Case "double", "float"
                Return "Double"
            Case "decimal", "numeric"
                Return "Decimal"
            Case "byte"
                Return "Boolean"
            Case "enum"
                If enumAsString Then
                    Return "String"
                Else
                    Return "Enum"
                End If
            Case Else
                Return "Unknown"
        End Select
    End Function


    Private Function parseEnum(_l As String) As List(Of String)
        Dim tmp = Regex.Replace(_l, "^[^']+([^)]+).*$", "$1", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        tmp = tmp.Replace("'"c, "")

        Dim r As New List(Of String)
        r.AddRange(tmp.Split(","c))

        For i As Integer = 0 To r.Count - 1
            Dim data As String = r.Item(i)
            If _keywords.Exists(Function(k) k = data.ToLower) Then
                r.Item(i) = String.Format("[{0}]", data)
            End If
        Next

        Return r
    End Function

    Private Function AliasGenerator(original As String) As String
        Try
            Dim [alias] As String = original
            Dim inc As Integer = 1

            ' check if the first character is a number
            If IsNumeric(original.First) Then
                original = String.Format("_{0}", original)
            End If

            ' replace spaces with underscores
            original = original.Replace(" "c, "_"c)
            [alias] = original

            ' check tablenames
            While tables.Exists(Function(t) t.tableName = [alias] Or t.singleName = [alias] Or t.pluralName = [alias])
                [alias] = String.Format("{0}_{1}", original, inc)
                inc += 1
            End While

            ' Then check vb keywords
            If _keywords.Exists(Function(k) k = [alias]) Then
                [alias] = String.Format("[{0}]", [alias])
            End If

            Return [alias]
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
