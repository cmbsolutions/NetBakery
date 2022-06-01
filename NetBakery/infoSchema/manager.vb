Imports System.Data.Entity.Infrastructure.Pluralization
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions


Namespace infoSchema
    <Serializable>
    Public Class manager
        Implements IDisposable

        Public Property connection As connection
        Private Property _dbConnections As Dictionary(Of String, MySqlConnection)
        Private Property _dbCommand As MySqlCommand
        Private Property _dbInfoCommand As MySqlCommand
        Private Property _p As New PluralizationService
        Private Property _keywords As New List(Of String)
        Private Property _database As String = ""
        Public Property databases As List(Of String)
        Public Property tables As List(Of table)
        Public Property routines As List(Of routine)
        Public Property useEnums As Boolean
        Private Property useGenerator As String = "net5"

        Private _generator As iGenerator = New net5Generator

        Public Sub setGenerator(_v As String)
            useGenerator = _v

            _keywords = New List(Of String)

            Select Case useGenerator
                Case "net"
                    _generator = New legacy_netGenerator
                    _keywords.AddRange(My.Resources.vb_keywords.Split(" "c))
                Case "net5"
                    _generator = New net5Generator
                    _keywords.AddRange(My.Resources.vb_keywords.Split(" "c))
                Case "php"
                    _generator = New phpGenerator
                    _keywords.AddRange(My.Resources.php_keywords.Split(" "c))
                Case Else

            End Select
        End Sub

        Public Function generateModel(t As table, Optional IsStoreCommand As Boolean = False) As String
            Try
                Return _generator.generateModel(t, IsStoreCommand)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function generateMap(t As table) As String
            Try
                Return _generator.generateMap(t)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function generateContext(name As String) As String
            Try
                Return _generator.generateContext(tables, name, False, routines)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function generateStoreCommands(name As String, withLock As Boolean) As String
            Try
                Return _generator.generateStoreCommands(routines.Where(Function(c) c.isFunction And c.hasExport).ToList, routines.Where(Function(c) Not c.isFunction And c.hasExport).ToList, name, withLock)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function generateStoreCommand(r As infoSchema.routine, name As String, withLock As Boolean) As String
            Try
                Return _generator.generateStoreCommand(r, name, withLock)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Sub New()
            initSchema()
        End Sub

        Public Sub SetDatabase(database As String)
            _database = database
        End Sub
        Public Function GetDatabase() As String
            Return _database
        End Function

        Public Sub harvestObjects()
            Try
                tables = New List(Of table)
                routines = New List(Of routine)

                getTables()
                getColumns()
                getIndexes()
                getForeignKeys()
                getRoutines()

            Catch ex As Exception
                Throw
            End Try
        End Sub

#Region "object readers"
        Private Sub getDatabases()
            Try
                Using _dbCommand = New MySqlCommand

                    _dbCommand.Connection = dbConnection("INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT SCHEMA_NAME FROM SCHEMATA WHERE SCHEMA_NAME NOT IN ('information_schema', 'mysql', 'performance_schema', 'sys') ORDER BY SCHEMA_NAME"

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
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

                    _dbCommand.Connection = dbConnection("INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT T.TABLE_NAME, T.TABLE_TYPE, V.VIEW_DEFINITION FROM	`TABLES` AS T LEFT JOIN	VIEWS AS V ON T.TABLE_SCHEMA = V.TABLE_SCHEMA AND T.TABLE_NAME = V.TABLE_NAME WHERE	T.TABLE_SCHEMA = @database;"
                    _dbCommand.Parameters.AddWithValue("database", _database)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Dim t As table
                            If rdr("TABLE_TYPE").ToString = "VIEW" Then
                                t = New table With {.name = rdr("TABLE_NAME").ToString, .singleName = _p.Singularize(rdr("TABLE_NAME").ToString), .pluralName = _p.Pluralize(rdr("TABLE_NAME").ToString), .isView = True, .hasExport = True}
                            Else
                                t = New table With {.name = rdr("TABLE_NAME").ToString, .singleName = _p.Singularize(rdr("TABLE_NAME").ToString), .pluralName = _p.Pluralize(rdr("TABLE_NAME").ToString), .hasExport = True}
                            End If

                            t.escapeName = _keywords IsNot Nothing AndAlso _keywords.Exists(Function(c) c = t.singleName)

                            tables.Add(t)

                            Using _dbInfoCommand = New MySqlCommand
                                _dbInfoCommand.Connection = dbConnection(_database)
                                _dbInfoCommand.CommandText = $"SHOW CREATE {rdr("TABLE_TYPE").ToString.Replace("BASE ", "")} {rdr("TABLE_NAME")}"

                                Using irdr As MySqlDataReader = _dbInfoCommand.ExecuteReader
                                    While irdr.Read
                                        t.definition = irdr($"Create {UcFirst(rdr("TABLE_TYPE").ToString.Replace("BASE ", ""))}").ToString
                                    End While
                                End Using

                            End Using
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub getColumns()
            Try
                For Each t In tables

                    t.columns = New List(Of column)

                    Using _dbCommand = New MySqlCommand
                        _dbCommand.Connection = dbConnection("INFORMATION_SCHEMA")
                        _dbCommand.CommandText = "SELECT COLUMN_NAME,ORDINAL_POSITION,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE,COLUMN_TYPE,COLUMN_KEY,EXTRA FROM COLUMNS WHERE TABLE_SCHEMA = @database AND TABLE_NAME = @table ORDER BY ORDINAL_POSITION ASC"
                        _dbCommand.Parameters.AddWithValue("database", _database)
                        _dbCommand.Parameters.AddWithValue("table", t.name)
                        'Debug.WriteLine(t.tableName)
                        Using rdr As MySqlDataReader = _dbCommand.ExecuteReader()
                            While rdr.Read
                                Dim c As New column
                                'Debug.WriteLine(rdr("COLUMN_NAME").ToString)
                                c.name = rdr("COLUMN_NAME").ToString
                                c.alias = AliasGenerator(rdr("COLUMN_NAME").ToString)
                                c.ordinalPosition = CInt(rdr("ORDINAL_POSITION"))
                                c.defaultValue = If(rdr("COLUMN_DEFAULT").ToString = "", "NULL", rdr("COLUMN_DEFAULT").ToString)
                                c.isNullable = If(rdr("IS_NULLABLE").ToString = "YES", True, False)
                                c.mysqlType = rdr("DATA_TYPE").ToString
                                c.maximumLength = ToInt(rdr("CHARACTER_MAXIMUM_LENGTH"))
                                c.numericPrecision = ToInt(rdr("NUMERIC_PRECISION"))
                                c.numericScale = ToInt(rdr("NUMERIC_SCALE"))
                                c.key = rdr("COLUMN_KEY").ToString
                                If Not t.isView Then
                                    c.autoIncrement = If(rdr("EXTRA").ToString = "auto_increment", True, False)
                                End If
                                c.vbType = getVbType(rdr("DATA_TYPE").ToString)
                                c.MySqlColumnType = rdr("COLUMN_TYPE").ToString
                                c.phpType = getPHPType(c.mysqlType)
                                If rdr("DATA_TYPE").ToString = "enum" Then
                                    Dim RegexObj As New Regex("\(([^)]+)")
                                    Dim tmpData As String = RegexObj.Match(rdr("COLUMN_TYPE").ToString()).Groups(1).Value

                                    c.enums = New List(Of String)
                                    c.enums.AddRange(tmpData.Replace("'", "").Split(","c))
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

        Private Sub getIndexes()
            Try
                Using _dbCommand = New MySqlCommand
                    _dbCommand.Connection = dbConnection("INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT TABLE_NAME, NON_UNIQUE, NULLABLE, INDEX_NAME, COLUMN_NAME, SEQ_IN_INDEX FROM STATISTICS WHERE TABLE_SCHEMA=@database ORDER BY TABLE_NAME, INDEX_NAME, SEQ_IN_INDEX"
                    _dbCommand.Parameters.AddWithValue("database", _database)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Dim table = tables.FirstOrDefault(Function(c) c.name = rdr("TABLE_NAME").ToString)

                            Dim idx = table.indexes.FirstOrDefault(Function(c) c.Name = rdr("INDEX_NAME").ToString)

                            If idx Is Nothing Then
                                idx = New index With {
                                    .Name = rdr("INDEX_NAME").ToString,
                                    .IsUnique = Not CBool(rdr("NON_UNIQUE")),
                                    .IsNullable = rdr("NULLABLE").ToString = "YES"
                                }
                                table.indexes.Add(idx)
                            End If

                            Dim col = table.columns.FirstOrDefault(Function(c) c.name = rdr("COLUMN_NAME").ToString)

                            idx.columns.Add(New indexColumn With {
                                            .indexPosition = ToInt(rdr("SEQ_IN_INDEX")),
                                            .column = col
                            })

                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub getForeignKeys()
            Try
                Using _dbCommand = New MySqlCommand
                    _dbCommand.Connection = dbConnection("INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT CONSTRAINT_NAME, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, POSITION_IN_UNIQUE_CONSTRAINT, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME FROM KEY_COLUMN_USAGE WHERE CONSTRAINT_SCHEMA = @database AND REFERENCED_TABLE_NAME is not null ORDER BY TABLE_NAME, ORDINAL_POSITION, POSITION_IN_UNIQUE_CONSTRAINT"
                    _dbCommand.Parameters.AddWithValue("database", _database)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Dim table = tables.FirstOrDefault(Function(c) c.name = rdr("TABLE_NAME").ToString)

                            Dim fk = table.foreignKeys.FirstOrDefault(Function(c) c.name = rdr("CONSTRAINT_NAME").ToString)

                            If fk Is Nothing Then
                                fk = New foreignKey With {
                                    .name = rdr("CONSTRAINT_NAME").ToString,
                                    .table = table
                                }
                                table.foreignKeys.Add(fk)
                            End If

                            Dim col = table.columns.FirstOrDefault(Function(c) c.name = rdr("COLUMN_NAME").ToString)

                            fk.columns.Add(New fkColumn With {
                                .fkPosition = ToInt(rdr("ORDINAL_POSITION")),
                                .column = col
                            })

                            fk.propertyAlias = col.name.Replace("_id", "")

                            Dim reftable = tables.FirstOrDefault(Function(c) c.name = rdr("REFERENCED_TABLE_NAME").ToString)

                            If fk.referencedTable Is Nothing Then
                                fk.referencedTable = reftable
                            End If

                            Dim refcol = reftable.columns.FirstOrDefault(Function(c) c.name = rdr("REFERENCED_COLUMN_NAME").ToString)

                            fk.referencedColumns.Add(New fkColumn With {
                                .fkPosition = ToInt(rdr("ORDINAL_POSITION")),
                                .column = refcol
                            })

                            'table.parents.Add(reftable)
                            'reftable.children.Add(table)

                            If fk.propertyAlias = reftable.singleName Then
                                reftable.relations.Add(New relation With {
                                                    .toTable = table,
                                                    .toColumn = col,
                                                    .localColumn = refcol,
                                                    .isOptional = col.isNullable,
                                                    .[alias] = table.pluralName
                                                    })
                            Else
                                reftable.relations.Add(New relation With {
                                                    .toTable = table,
                                                    .toColumn = col,
                                                    .localColumn = refcol,
                                                    .isOptional = col.isNullable,
                                                    .[alias] = table.singleName & _p.Pluralize(fk.propertyAlias)})
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub foreignKeyAliasBuilder()
            Try
                For Each table In tables.Where(Function(c) c.foreignKeys.Count > 0)
                    For Each fk In table.foreignKeys
                        If table.foreignKeys.LongCount(Function(c) c.referencedTable.Equals(fk.referencedTable)) > 1 Then
                            fk.propertyAlias = fk.columns.First.column.name.Replace("_id", "")
                        Else
                            fk.propertyAlias = fk.referencedTable.singleName
                        End If
                    Next
                Next
            Catch ex As Exception
                Throw
            End Try
        End Sub
        Private Sub relationAliasBuilder()
            Try
                For Each table In tables.Where(Function(c) c.relations.Count > 0)
                    For Each re In table.relations
                        If table.relations.LongCount(Function(c) c.toTable.Equals(re.toTable)) > 1 Then
                            re.alias = re.toColumn.name.Replace("_id", "")
                        Else
                            re.alias = re.toTable.singleName
                        End If
                    Next
                Next
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub getRoutines()
            Try
                Using _dbCommand = New MySqlCommand

                    _dbCommand.Connection = dbConnection("INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "Select r.ROUTINE_TYPE, r.ROUTINE_NAME, r.ROUTINE_DEFINITION, p.ORDINAL_POSITION, p.PARAMETER_NAME, p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION FROM ROUTINES As r LEFT JOIN PARAMETERS As p On r.ROUTINE_SCHEMA = p.SPECIFIC_SCHEMA And r.ROUTINE_NAME = p.SPECIFIC_NAME WHERE r.ROUTINE_SCHEMA = @database ORDER BY r.ROUTINE_TYPE, p.SPECIFIC_NAME, p.ORDINAL_POSITION"
                    _dbCommand.Parameters.AddWithValue("database", _database)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        Dim rt As routine = Nothing

                        While rdr.Read
                            If rt Is Nothing OrElse rt.name <> rdr("ROUTINE_NAME").ToString Then
                                If rt IsNot Nothing Then
                                    If rt.returnsRecordset AndAlso Not rt.isFunction Then
                                        getRoutineLayout(rt, Nothing, Nothing)
                                    End If
                                    routines.Add(rt)
                                End If
                                rt = New routine With {.name = rdr("ROUTINE_NAME").ToString, .hasExport = True}

                                If rdr("ROUTINE_TYPE").ToString = "PROCEDURE" Then
                                    rt.returnsRecordset = Regex.IsMatch(rdr("ROUTINE_DEFINITION").ToString, My.Settings.routineRegex, RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Multiline)
                                    If rt.returnsRecordset Then
                                        rt.returnLayout = New table With {.name = rt.name, .singleName = _p.Singularize(rt.name), .pluralName = _p.Pluralize(rt.name)}
                                    End If
                                End If
                            End If

                            Dim p As New parameter
                            p.mysqlType = rdr("DATA_TYPE").ToString
                            p.maximumLength = ToInt(rdr("CHARACTER_MAXIMUM_LENGTH"))
                            p.numericPrecision = ToInt(rdr("NUMERIC_PRECISION"))
                            p.vbType = getVbType(rdr("DATA_TYPE").ToString)
                            p.name = rdr("PARAMETER_NAME").ToString

                            If rdr("ROUTINE_TYPE").ToString = "FUNCTION" Then
                                rt.isFunction = True
                                rt.returnsRecordset = True

                                If ToInt(rdr("ORDINAL_POSITION")) = 0 Then
                                    rt.returnParam = p
                                    Dim specName = $"{p.vbType}Model"
                                    Dim routineWithSameReturnLayout = routines.FirstOrDefault(Function(c) c.isFunction And c.returnLayout.name = specName)

                                    If routineWithSameReturnLayout Is Nothing Then
                                        rt.returnLayout = New table With {
                                            .name = specName,
                                            .singleName = _p.Singularize(.name),
                                            .pluralName = _p.Pluralize(.name),
                                            .columns = New List(Of column)({
                                                                           New column With {
                                                                                .name = "value",
                                                                                .[alias] = AliasGenerator(.name),
                                                                                .isNullable = True,
                                                                                .vbType = p.vbType,
                                                                                .mysqlType = p.mysqlType,
                                                                                .maximumLength = p.maximumLength,
                                                                                .numericPrecision = p.numericPrecision
                                                                           }}
                                            )}
                                    Else
                                        rt.returnLayout = routineWithSameReturnLayout.returnLayout
                                    End If
                                End If
                            End If

                            If ToInt(rdr("ORDINAL_POSITION")) > 0 Then
                                rt.params.Add(p)
                            End If

                            Using _dbInfoCommand = New MySqlCommand
                                _dbInfoCommand.Connection = dbConnection(_database)
                                _dbInfoCommand.CommandTimeout = 3600
                                _dbInfoCommand.CommandText = $"SHOW CREATE {rdr("ROUTINE_TYPE")} {rdr("ROUTINE_NAME")}"

                                Using irdr As MySqlDataReader = _dbInfoCommand.ExecuteReader
                                    While irdr.Read
                                        rt.definition = irdr($"Create {UcFirst(rdr("ROUTINE_TYPE").ToString)}").ToString
                                    End While
                                End Using

                            End Using
                        End While

                        If rt IsNot Nothing Then
                            If rt.returnsRecordset AndAlso Not rt.isFunction Then
                                getRoutineLayout(rt, Nothing, Nothing)
                            End If
                            routines.Add(rt)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub getRoutineLayout(ByRef _r As routine, paramValues As String(), ByRef fieldNames As List(Of String))
            Try
                Using _dbxCommand = New MySqlCommand
                    _dbxCommand.Connection = dbConnection(_database)
                    _dbxCommand.CommandTimeout = 3600
                    _dbxCommand.CommandType = CommandType.Text
                    _dbxCommand.CommandText = $"CALL {_r.name}({String.Join(",", (From r In _r.params Order By r.ordinalPosition Select "@" & r.name))})"

                    For Each param In _r.params.OrderBy(Function(o) o.ordinalPosition)
                        If paramValues IsNot Nothing Then
                            _dbxCommand.Parameters.AddWithValue("@" & param.name, paramValues(param.ordinalPosition))
                        Else
                            _dbxCommand.Parameters.AddWithValue("@" & param.name, 1)
                        End If
                    Next

                    Try
                        Using rdr As MySqlDataReader = _dbxCommand.ExecuteReader()

                            Using d As DataTable = rdr.GetSchemaTable
                                If d IsNot Nothing Then
                                    If _r.returnLayout Is Nothing Then _r.returnLayout = New table
                                    For Each row As DataRow In d.Rows
                                        Dim c As New column

                                        c.name = row.ItemArray(d.Columns.IndexOf("ColumnName")).ToString
                                        c.alias = AliasGenerator(c.name)

                                        c.ordinalPosition = CInt(row.ItemArray(d.Columns.IndexOf("ColumnOrdinal")))
                                        'c.defaultValue = rdr("COLUMN_DEFAULT").ToString
                                        c.isNullable = CBool(row.ItemArray(d.Columns.IndexOf("AllowDBNull")))
                                        c.mysqlType = [Enum].GetName(GetType(MySqlDbType), row.ItemArray(d.Columns.IndexOf("ProviderType")))
                                        'c.maximumLength = ToInt(rdr("CHARACTER_MAXIMUM_LENGTH"))
                                        'c.numericPrecision = ToInt(rdr("NUMERIC_PRECISION"))
                                        'c.numericScale = ToInt(rdr("NUMERIC_SCALE"))
                                        'c.key = rdr("COLUMN_KEY").ToString
                                        c.vbType = getVbType(c.mysqlType)
                                        c.phpType = getPHPType(c.mysqlType)
                                        _r.returnLayout.columns.Add(c)

                                        If fieldNames IsNot Nothing Then
                                            fieldNames.Add(c.name)
                                        End If
                                    Next
                                Else
                                    _r.returnLayout = Nothing
                                    _r.returnsRecordset = False
                                End If
                            End Using
                        End Using
                    Catch mex As MySqlException
                        _r.returnLayout = Nothing
                        _r.returnsRecordset = False
                    End Try
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub
#End Region

#Region "helpers"
        Public Sub initSchema()
            Try
                databases = New List(Of String)
                _dbConnections = New Dictionary(Of String, MySqlConnection)

                tables = New List(Of table)
                routines = New List(Of routine)

            Catch ex As Exception
                Throw
            End Try
        End Sub
        Public Function TryConnect() As Boolean
            Try
                getDatabases()

                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function

        Private Function dbConnection(databasename As String) As MySqlConnection
            Try
                If _dbConnections Is Nothing Then
                    _dbConnections = New Dictionary(Of String, MySqlConnection)
                End If

                If _dbConnections.ContainsKey(databasename) Then
                    Return _dbConnections.First(Function(c) c.Key = databasename).Value
                Else
                    Dim con = New MySqlConnection(connection.ToString)
                    Try
                        con.Open()
                    Catch msex As MySqlException
                        connection.sslmode = eSslMode.Prefered
                        con = New MySqlConnection(connection.ToString)
                        con.Open()
                    End Try

                    _dbConnections.Add(databasename, con)
                    con.ChangeDatabase(databasename)
                    Return con
                End If
            Catch ex As Exception
                Throw
            End Try
        End Function

        Private Function ToInt(obj As Object) As Integer
            If obj.ToString = "" Then
                Return 0
            Else
                Dim result As Integer

                If Not Integer.TryParse(obj.ToString, result) Then
                    Return 0
                End If

                Return result
            End If
        End Function

        Private Function UcFirst(s As String) As String
            Return s.Substring(0, 1).ToUpper & s.Substring(1).ToLower

        End Function
        Private Function getVbType(mysqlType As String) As String
            Select Case mysqlType.ToLower
                Case "tinyint", "mediumint", "integer", "int", "smallint", "int16", "int24", "int32", "uint16", "uint24", "uint32"
                    Return "Integer"
                Case "bigint", "int64", "uint64"
                    Return "Long"
                Case "char", "varchar", "text", "tinytext", "mediumtext", "longtext", "string", "varstring", "varbinary", "binary", "tinyblob", "mediumblob", "longblob", "set", "enum"
                    Return "String"
                Case "time", "timestamp"
                    Return "TimeSpan"
                Case "date", "datetime"
                    Return "Date"
                Case "double", "float"
                    Return "Double"
                Case "decimal", "numeric", "newdecimal"
                    Return "Decimal"
                Case "byte", "bit"
                    Return "Boolean"
                Case Else
                    Return "Object"
            End Select
        End Function

        Private Function getPHPType(mysqlType As String) As String
            Select Case mysqlType.ToLower
                Case "tinyint", "mediumint", "integer", "int", "smallint", "int16", "int24", "int32", "uint16", "uint24", "uint32"
                    Return "int"
                Case "bigint", "int64", "uint64"
                    Return "int"
                Case "char", "varchar", "text", "tinytext", "mediumtext", "longtext", "string", "varstring", "varbinary", "binary", "tinyblob", "mediumblob", "longblob", "set", "enum"
                    Return "string"
                Case "time", "timestamp"
                    Return "\Cake\I18n\FrozenTime"
                Case "date", "datetime"
                    Return "\Cake\I18n\FrozenTime"
                Case "double", "float"
                    Return "float"
                Case "decimal", "numeric", "newdecimal"
                    Return "float"
                Case "byte", "bit"
                    Return "bool"
                Case Else
                    Return "null"
            End Select
        End Function
        Private Function AliasGenerator(original As String) As String
            Try
                Dim ali As String = original.ToLower
                Dim inc As Integer = 1

                ' First check tablenames
                While tables.Exists(Function(t) t.name.ToLower = ali Or t.singleName.ToLower = ali Or t.pluralName.ToLower = ali)
                    ali = $"{original.ToLower}_{inc}"
                    inc += 1
                End While

                ' Then check keywords (depending on generatortype)
                If _keywords.Exists(Function(k) k = ali) Then
                    ali = $"[{ali}]"
                End If

                Return ali
            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If _dbConnections IsNot Nothing Then
                        _dbConnections.Values.ToList.ForEach(Sub(c) c.Dispose())
                        _dbConnections.Clear()
                    End If
                    If _dbCommand IsNot Nothing Then _dbCommand.Dispose()
                    If _p IsNot Nothing Then _p.Dispose()
                End If

                _keywords = Nothing
                databases = Nothing
                tables = Nothing
                routines = Nothing

            End If
            disposedValue = True
        End Sub

        Protected Overrides Sub Finalize()
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(False)
            MyBase.Finalize()
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)

            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class PluralizationService
        Implements IDisposable

        Private _service As EnglishPluralizationService

        Public Sub New()
            Try
                If My.Settings.customDictionary.Count > 0 Then

                    Dim userEntries As New List(Of CustomPluralizationEntry)

                    For Each s In My.Settings.customDictionary
                        userEntries.Add(New CustomPluralizationEntry(s.Split("|"c).First, s.Split("|"c).Last))
                    Next
                    _service = New EnglishPluralizationService(userEntries)
                Else
                    _service = New EnglishPluralizationService()
                End If

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Function Singularize(s As Object) As String
            Return Singularize(s.ToString)
        End Function

        Public Function Singularize(s As String) As String
            Dim ret As String = _service.Singularize(s)

            Dim test As String

            ' it did not singularize, is it already single?
            If ret = s Then
                test = _service.Pluralize(s)


                If test = s Then ' it did not pluralize either, maybe its two words....
                    If s.Contains("_"c) AndAlso Not s.EndsWith("_"c) Then
                        Dim l = s.Split("_"c).LastOrDefault

                        test = _service.Singularize(l)
                        ret = s.Replace(l, test)


                        If ret = s Then ' no way to make it single, return s

                            ret = s
                        End If

                    Else
                        ret = s
                    End If

                Else ' it did pluralize, return s
                    ret = s
                End If
            End If

            Return ret
        End Function

        Public Function Pluralize(s As Object) As String
            Return Pluralize(s.ToString)
        End Function

        Public Function Pluralize(s As String) As String
            Dim ret As String = _service.Pluralize(s)
            Dim test As String = Singularize(s)

            If s = ret AndAlso s = test AndAlso test = ret Then ret &= "s"

            Return ret
        End Function

        Public Function isSingle(s As Object) As Boolean
            Return isSingle(s.ToString)
        End Function

        Public Function isSingle(s As String) As Boolean
            Dim tmp As String = Singularize(s)

            Return tmp.Equals(s)
        End Function

        Public Function isPlural(s As Object) As Boolean
            Return isPlural(s.ToString)
        End Function

        Public Function isPlural(s As String) As Boolean
            Dim tmp As String = Pluralize(s)

            Return tmp.Equals(s)
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    _service = Nothing
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace
