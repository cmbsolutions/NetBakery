Imports System.Data.Entity.Infrastructure.Pluralization
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls.WebParts


Namespace infoSchema
    <Serializable>
    Public Class Manager
        Implements IDisposable

        Public Property Connection As connection
        Private Property DbConnections As Dictionary(Of String, MySqlConnection)
        Private Property DbCommand As MySqlCommand
        Private Property DbInfoCommand As MySqlCommand
        Private Property Pservice As New PluralizationService
        Private Property Keywords As New List(Of String)
        Private Property DatabaseName As String = ""

        Public Property ProjectTables As New List(Of table)
        Public Property ProjectRoutines As New List(Of routine)

        Public Property Databases As List(Of String)
        Public Property Tables As List(Of table)
        Public Property Routines As List(Of routine)
        Public Property UseEnums As Boolean
        Private Property UseGenerator As String = "net5"

        Private Generator As iGenerator = New net5Generator

        Public Sub SetGenerator(_v As String)
            UseGenerator = _v

            Keywords = New List(Of String)

            Select Case UseGenerator
                Case "net"
                    Generator = New legacy_netGenerator
                    Keywords.AddRange(My.Resources.vb_keywords.Split(" "c))
                Case "net5"
                    Generator = New net5Generator
                    Keywords.AddRange(My.Resources.vb_keywords.Split(" "c))
                Case "php"
                    Generator = New phpGenerator
                    Keywords.AddRange(My.Resources.php_keywords.Split(" "c))
                Case Else

            End Select
        End Sub

        Public Function GenerateModel(t As table, Optional IsStoreCommand As Boolean = False) As String
            Try
                Return Generator.generateModel(t, IsStoreCommand)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GenerateMap(t As table) As String
            Try
                Return Generator.generateMap(t)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GenerateContext(name As String) As String
            Try
                Return Generator.generateContext(Tables.Where(Function(c) c.hasExport).ToList, name, False, Routines.Where(Function(c) c.hasExport).ToList)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GenerateStoreCommands(name As String, withLock As Boolean) As String
            Try
                Return Generator.generateStoreCommands(Routines.Where(Function(c) c.isFunction And c.hasExport).ToList, Routines.Where(Function(c) Not c.isFunction And c.hasExport).ToList, name, withLock)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GenerateStoreCommand(r As infoSchema.routine, name As String, withLock As Boolean) As String
            Try
                Return Generator.generateStoreCommand(r, name, withLock)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Sub New()
            InitSchema()
        End Sub

        Public Sub SetDatabase(database As String)
            DatabaseName = database
        End Sub
        Public Function GetDatabase() As String
            Return DatabaseName
        End Function

        Public Sub HarvestObjects()
            Try
                Tables = New List(Of table)
                Routines = New List(Of routine)
                GetTables()
                GetColumns()
                GetIndexes()
                GetForeignKeys()
                GetRoutines()

            Catch ex As Exception
                Throw
            End Try
        End Sub

#Region "object readers"
        Private Sub GetDatabases()
            Try
                Using _dbCommand = New MySqlCommand

                    _dbCommand.Connection = DbConnection("infoSchema", "INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT SCHEMA_NAME FROM SCHEMATA WHERE SCHEMA_NAME NOT IN ('information_schema', 'mysql', 'performance_schema', 'sys') ORDER BY SCHEMA_NAME"

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Databases.Add(rdr(0).ToString)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub GetTables()
            Try
                Using _dbCommand = New MySqlCommand

                    _dbCommand.Connection = DbConnection("infoSchema", "INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT T.TABLE_NAME, T.TABLE_TYPE, V.VIEW_DEFINITION, T.TABLE_COLLATION FROM `TABLES` AS T LEFT JOIN VIEWS AS V ON T.TABLE_SCHEMA = V.TABLE_SCHEMA AND T.TABLE_NAME = V.TABLE_NAME WHERE T.TABLE_SCHEMA = @database;"
                    _dbCommand.Parameters.AddWithValue("database", DatabaseName)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Dim t As table
                            If rdr.GetString("TABLE_TYPE") = "VIEW" Then
                                t = New table With {.name = rdr.GetString("TABLE_NAME").ToString, .singleName = Pservice.Singularize(rdr.GetString("TABLE_NAME")), .pluralName = Pservice.Pluralize(rdr.GetString("TABLE_NAME")), .isView = True, .hasExport = True}
                            Else
                                t = New table With {.name = rdr.GetString("TABLE_NAME"), .singleName = Pservice.Singularize(rdr.GetString("TABLE_NAME")), .pluralName = Pservice.Pluralize(rdr.GetString("TABLE_NAME")), .hasExport = True, .table_collation = rdr.GetString("TABLE_COLLATION")}
                            End If

                            t.escapeName = Keywords IsNot Nothing AndAlso Keywords.Exists(Function(c) c = t.singleName)
                            t.NoAutoNumber = True

                            Tables.Add(t)

                            Using _dbInfoCommand = New MySqlCommand
                                _dbInfoCommand.Connection = DbConnection("definition", DatabaseName)
                                _dbInfoCommand.CommandText = $"SHOW CREATE {rdr.GetString("TABLE_TYPE").Replace("BASE ", "")} {rdr("TABLE_NAME")}"

                                Try
                                    Using irdr As MySqlDataReader = _dbInfoCommand.ExecuteReader
                                        While irdr.Read
                                            t.definition = irdr($"Create {UcFirst(rdr.GetString("TABLE_TYPE").Replace("BASE ", ""))}").ToString
                                            t.hash = FileVCS.Utils.Gethash(input:=t.definition)
                                        End While
                                    End Using
                                Catch rex As Exception
                                    Trace.WriteLine(rex.Message)
                                End Try

                                If t.isView AndAlso My.Settings.timeViews Then
                                    Dim starttime = Now
                                    _dbInfoCommand.CommandText = $"SELECT * FROM {t.name};"
                                    Try
                                        Dim cnt = _dbInfoCommand.ExecuteNonQuery
                                    Catch mex As Exception

                                    End Try
                                    Dim endtime = Now
                                    t.executiontime = endtime.Subtract(starttime)
                                End If
                            End Using
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub GetColumns()
            Try
                For Each t In Tables

                    t.columns = New List(Of column)

                    Using _dbCommand = New MySqlCommand
                        _dbCommand.Connection = DbConnection("infoSchema", "INFORMATION_SCHEMA")
                        _dbCommand.CommandText = "SELECT COLUMN_NAME,ORDINAL_POSITION,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE,COLUMN_TYPE,COLUMN_KEY,EXTRA,CHARACTER_SET_NAME,COLLATION_NAME FROM COLUMNS WHERE TABLE_SCHEMA = @database AND TABLE_NAME = @table ORDER BY ORDINAL_POSITION ASC"
                        _dbCommand.Parameters.AddWithValue("database", DatabaseName)
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
                                c.maximumLength = If(rdr("CHARACTER_MAXIMUM_LENGTH").ToString = "", 0, ToInt(rdr("CHARACTER_MAXIMUM_LENGTH")))
                                c.numericPrecision = ToInt(rdr("NUMERIC_PRECISION"))
                                c.numericScale = ToInt(rdr("NUMERIC_SCALE"))
                                c.key = rdr("COLUMN_KEY").ToString
                                If Not t.isView Then
                                    If rdr("EXTRA").ToString = "auto_increment" Then
                                        c.autoIncrement = True
                                        t.NoAutoNumber = False
                                    End If
                                Else
                                    Dim pt = ProjectTables.FirstOrDefault(Function(x) x.name = t.name)
                                    If pt IsNot Nothing Then
                                        Dim ct = pt.columns.FirstOrDefault(Function(y) y.name = c.name)

                                        If ct IsNot Nothing Then
                                            c.IsUserSelectedKey = ct.IsUserSelectedKey
                                        End If
                                    End If
                                End If
                                c.vbType = GetVbType(rdr("DATA_TYPE").ToString)
                                c.MySqlColumnType = rdr("COLUMN_TYPE").ToString
                                c.phpType = GetPHPType(c.mysqlType)
                                If rdr("DATA_TYPE").ToString = "enum" Then
                                    Dim RegexObj As New Regex("\(([^)]+)")
                                    Dim tmpData As String = RegexObj.Match(rdr("COLUMN_TYPE").ToString()).Groups(1).Value

                                    c.enums = New List(Of String)
                                    c.enums.AddRange(tmpData.Replace("'", "").Split(","c))
                                End If

                                c.character_set_name = If(rdr("CHARACTER_SET_NAME").ToString = "", "", rdr.GetString("CHARACTER_SET_NAME"))
                                c.collation_name = If(rdr("COLLATION_NAME").ToString = "", "", rdr.GetString("COLLATION_NAME"))

                                t.columns.Add(c)
                            End While
                        End Using

                        If t.isView AndAlso t.columns.Count = 0 Then t.HasMissingFields = True
                    End Using
                Next

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub GetIndexes()
            Try
                Using _dbCommand = New MySqlCommand
                    _dbCommand.Connection = DbConnection("infoSchema", "INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT TABLE_NAME, NON_UNIQUE, NULLABLE, INDEX_NAME, COLUMN_NAME, SEQ_IN_INDEX FROM STATISTICS WHERE TABLE_SCHEMA=@database ORDER BY TABLE_NAME, INDEX_NAME, SEQ_IN_INDEX"
                    _dbCommand.Parameters.AddWithValue("database", DatabaseName)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Dim table = Tables.FirstOrDefault(Function(c) c.name = rdr("TABLE_NAME").ToString)

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

        Private Sub GetForeignKeys()
            Try
                Using _dbCommand = New MySqlCommand
                    _dbCommand.Connection = DbConnection("infoSchema", "INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "SELECT CONSTRAINT_NAME, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, POSITION_IN_UNIQUE_CONSTRAINT, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME FROM KEY_COLUMN_USAGE WHERE CONSTRAINT_SCHEMA = @database AND REFERENCED_TABLE_NAME is not null ORDER BY TABLE_NAME, ORDINAL_POSITION, POSITION_IN_UNIQUE_CONSTRAINT"
                    _dbCommand.Parameters.AddWithValue("database", DatabaseName)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Dim table = Tables.FirstOrDefault(Function(c) c.name = rdr("TABLE_NAME").ToString)

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

                            If col.name.Replace("_id", "") <> col.name Then
                                fk.propertyAlias = FixKeyword(col.name.Replace("_id", ""))
                            Else
                                fk.propertyAlias = $"{col.name}_"
                            End If

                            Dim reftable As table = Nothing
                            Try
                                reftable = Tables.First(Function(c) c.name = rdr("REFERENCED_TABLE_NAME").ToString)
                            Catch rex As Exception
                                Throw New Exception($"Foreign key error on {table.name} to {rdr("REFERENCED_TABLE_NAME")}, are you missing the table?", rex)
                            End Try

                            If fk.referencedTable Is Nothing Then
                                fk.referencedTable = reftable
                            End If

                            Dim refcol As column = Nothing

                            Try
                                refcol = reftable.columns.FirstOrDefault(Function(c) c.name = rdr("REFERENCED_COLUMN_NAME").ToString)
                            Catch rex As Exception
                                Throw New Exception($"Foreign key error on {table.name} to {rdr("REFERENCED_TABLE_NAME")} and column {rdr("REFERENCED_COLUMN_NAME")}, are you missing the table?", rex)
                            End Try

                            fk.referencedColumns.Add(New fkColumn With {
                                .fkPosition = ToInt(rdr("ORDINAL_POSITION")),
                                .column = refcol
                            })

                            If fk.propertyAlias = reftable.singleName Then
                                reftable.relations.Add(New relation With {
                                                    .toTable = table,
                                                    .toColumn = col,
                                                    .localColumn = refcol,
                                                    .isOptional = col.isNullable,
                                                    .[alias] = table.pluralName
                                                    })
                            Else
                                Dim alreadyExists = reftable.relations.FirstOrDefault(Function(c) c.alias = table.singleName & reftable.pluralName)
                                If alreadyExists Is Nothing Then
                                    reftable.relations.Add(New relation With {
                                                    .toTable = table,
                                                    .toColumn = col,
                                                    .localColumn = refcol,
                                                    .isOptional = col.isNullable,
                                                    .[alias] = table.singleName & reftable.pluralName})

                                Else
                                    alreadyExists.alias = $"{alreadyExists.toTable.singleName}{alreadyExists.toColumn.name.Replace("_id", "")}"
                                    reftable.relations.Add(New relation With {
                                                    .toTable = table,
                                                    .toColumn = col,
                                                    .localColumn = refcol,
                                                    .isOptional = col.isNullable,
                                                    .[alias] = $"{table.singleName}{col.name.Replace("_id", "")}"})

                                End If
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub ForeignKeyAliasBuilder()
            Try
                For Each table In Tables.Where(Function(c) c.foreignKeys.Count > 0)
                    For Each fk In table.foreignKeys
                        If table.foreignKeys.LongCount(Function(c) c.referencedTable.Equals(fk.referencedTable)) > 1 Then
                            fk.propertyAlias = FixKeyword(fk.columns.First.column.name.Replace("_id", ""))
                        Else
                            fk.propertyAlias = FixKeyword(fk.referencedTable.singleName)
                        End If
                    Next
                Next
            Catch ex As Exception
                Throw
            End Try
        End Sub
        Private Sub RelationAliasBuilder()
            Try
                For Each table In Tables.Where(Function(c) c.relations.Count > 0)
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

        Private Sub GetRoutines()
            Try
                Using _dbCommand = New MySqlCommand

                    _dbCommand.Connection = DbConnection("infoSchema", "INFORMATION_SCHEMA")
                    _dbCommand.CommandText = "Select r.ROUTINE_TYPE, r.ROUTINE_NAME, r.ROUTINE_DEFINITION, p.ORDINAL_POSITION, p.PARAMETER_NAME, p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION FROM ROUTINES As r LEFT JOIN PARAMETERS As p On r.ROUTINE_SCHEMA = p.SPECIFIC_SCHEMA And r.ROUTINE_NAME = p.SPECIFIC_NAME WHERE r.ROUTINE_SCHEMA = @database ORDER BY r.ROUTINE_TYPE, p.SPECIFIC_NAME, p.ORDINAL_POSITION"
                    _dbCommand.Parameters.AddWithValue("database", DatabaseName)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        Dim rt As routine = Nothing

                        While rdr.Read
                            If rt Is Nothing OrElse rt.name <> rdr("ROUTINE_NAME").ToString Then
                                If rt IsNot Nothing Then
                                    Dim prt = ProjectRoutines.FirstOrDefault(Function(c) c.name = rt.name)
                                    If (rt.returnsRecordset AndAlso Not rt.isFunction) OrElse (prt IsNot Nothing AndAlso prt.returnsRecordset AndAlso Not prt.isFunction) Then
                                        If My.Settings.autoExecuteSP Then
                                            Dim pvalues = rt.params.OrderBy(Function(d) d.ordinalPosition).Select(Function(c) c.PreviewValue).ToArray
                                            GetRoutineLayout(rt, pvalues, Nothing)
                                        End If
                                    End If
                                    Routines.Add(rt)
                                End If
                                rt = New routine With {.name = rdr("ROUTINE_NAME").ToString, .hasExport = True}

                                If rdr("ROUTINE_TYPE").ToString = "PROCEDURE" Then
                                    rt.returnsRecordset = Regex.IsMatch(rdr("ROUTINE_DEFINITION").ToString, My.Settings.routineRegex, RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Multiline)
                                    If rt.returnsRecordset Then
                                        rt.returnLayout = New table With {.name = rt.name, .singleName = Pservice.Singularize(rt.name), .pluralName = Pservice.Pluralize(rt.name)}
                                    End If
                                End If
                            End If

                            Dim p As New parameter
                            p.mysqlType = rdr("DATA_TYPE").ToString
                            p.maximumLength = ToInt(rdr("CHARACTER_MAXIMUM_LENGTH"))
                            p.numericPrecision = ToInt(rdr("NUMERIC_PRECISION"))
                            p.vbType = GetVbType(rdr("DATA_TYPE").ToString)
                            p.name = rdr("PARAMETER_NAME").ToString


                            If rdr("ROUTINE_TYPE").ToString = "FUNCTION" Then
                                rt.isFunction = True
                                rt.returnsRecordset = True

                                If ToInt(rdr("ORDINAL_POSITION")) = 0 Then
                                    rt.returnParam = p
                                    Dim specName = $"{p.vbType}Model"
                                    Dim routineWithSameReturnLayout = Routines.FirstOrDefault(Function(c) c.isFunction And c.returnLayout.name = specName)

                                    If routineWithSameReturnLayout Is Nothing Then
                                        rt.returnLayout = New table With {
                                            .name = specName,
                                            .singleName = Pservice.Singularize(.name),
                                            .pluralName = Pservice.Pluralize(.name),
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
                                p.ordinalPosition = ToInt(rdr("ORDINAL_POSITION"))

                                Dim prt = ProjectRoutines.FirstOrDefault(Function(c) c.name = rt.name)

                                If prt IsNot Nothing AndAlso prt.params.Any Then
                                    Dim pvalue = prt.params.FirstOrDefault(Function(d) d.ordinalPosition = p.ordinalPosition)

                                    If pvalue IsNot Nothing AndAlso pvalue.PreviewValue IsNot Nothing Then
                                        p.PreviewValue = pvalue.PreviewValue
                                    End If
                                End If
                                rt.params.Add(p)
                            End If

                            If rt.definition = "" Then
                                Using _dbInfoCommand = New MySqlCommand
                                    _dbInfoCommand.Connection = DbConnection("definition", DatabaseName)
                                    _dbInfoCommand.CommandText = $"SHOW CREATE {rdr("ROUTINE_TYPE")} {rdr("ROUTINE_NAME")}"
                                    _dbInfoCommand.CommandType = CommandType.Text

                                    Using irdr As MySqlDataReader = _dbInfoCommand.ExecuteReader
                                        While irdr.Read
                                            rt.definition = irdr($"Create {UcFirst(rdr("ROUTINE_TYPE").ToString)}").ToString

                                            If rt.definition = "" Then ' definer is not current user or lacking rights. Use less complete definition
                                                rt.definition = $"#### You are not the definer and/or are lacking the rights to see this ####"
                                            Else
                                                rt.definition = Regex.Replace(rt.definition, "definer=[^ ]* (?=procedure|function|sql|view)", "", RegexOptions.IgnoreCase)
                                            End If
                                            rt.hash = FileVCS.Utils.Gethash(input:=rt.definition)
                                        End While
                                    End Using

                                End Using
                            End If
                        End While

                        If rt IsNot Nothing Then
                            If rt.returnsRecordset AndAlso Not rt.isFunction Then
                                If My.Settings.autoExecuteSP Then
                                    Dim pvalues = rt.params.OrderBy(Function(d) d.ordinalPosition).Select(Function(c) c.PreviewValue).ToArray
                                    GetRoutineLayout(rt, pvalues, Nothing)
                                End If
                            End If
                            Routines.Add(rt)
                        End If
                    End Using
                End Using

                If My.Settings.mergeRoutineLayouts Then
                    Dim matched As New List(Of String)
                    ' Check for Routines with same returnlayouts, those will be merged to a base layout
                    For Each r1 In Routines.Where(Function(c) c.returnsRecordset AndAlso Not c.isFunction)
                        If matched.Contains(r1.name) Then Continue For

                        For Each r2 In Routines.Where(Function(c) c.returnsRecordset AndAlso Not c.isFunction AndAlso Not c.name = r1.name)
                            Dim sameLayout As Boolean = True
                            For Each c1 In r1.returnLayout.columns
                                If Not r2.returnLayout.columns.Item(r1.returnLayout.columns.IndexOf(c1)).Equals(c1) Then
                                    sameLayout = False
                                    Exit For
                                End If
                            Next

                            If sameLayout Then
                                matched.Add(r2.name)
                                r2.returnLayout = r1.returnLayout
                            End If
                        Next
                    Next
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub GetRoutineLayout(ByRef _r As routine, paramValues As String(), ByRef fieldNames As List(Of String))
            Try
                Using _dbxCommand = New MySqlCommand
                    Dim startTime = Now
                    _dbxCommand.Connection = DbConnection("definition", DatabaseName)
                    _dbxCommand.CommandTimeout = 3600
                    _dbxCommand.CommandType = CommandType.Text
                    _dbxCommand.CommandText = $"CALL {_r.name}({String.Join(",", (From r In _r.params Order By r.ordinalPosition Select "@" & r.name))})"

                    For Each param In _r.params.OrderBy(Function(o) o.ordinalPosition)
                        If paramValues IsNot Nothing Then
                            _dbxCommand.Parameters.AddWithValue("@" & param.name, paramValues(param.ordinalPosition - 1))
                            param.PreviewValue = paramValues(param.ordinalPosition - 1)
                        Else
                            _dbxCommand.Parameters.AddWithValue("@" & param.name, 1)
                            param.PreviewValue = "1"
                        End If
                    Next

                    Try
                        Using rdr As MySqlDataReader = _dbxCommand.ExecuteReader()

                            Using d As DataTable = rdr.GetSchemaTable
                                If d IsNot Nothing Then
                                    If _r.returnLayout Is Nothing Then
                                        _r.returnLayout = New table With {.name = _r.name, .singleName = Pservice.Singularize(_r.name), .pluralName = Pservice.Pluralize(_r.name)}
                                    End If
                                    _r.returnsRecordset = True
                                    For Each row As DataRow In d.Rows
                                        Dim c As New column

                                        c.name = row.ItemArray(d.Columns.IndexOf("ColumnName")).ToString
                                        c.alias = AliasGenerator(c.name)

                                        c.ordinalPosition = CInt(row.ItemArray(d.Columns.IndexOf("ColumnOrdinal")))
                                        c.isNullable = CBool(row.ItemArray(d.Columns.IndexOf("AllowDBNull")))
                                        c.mysqlType = [Enum].GetName(GetType(MySqlDbType), row.ItemArray(d.Columns.IndexOf("ProviderType")))
                                        c.vbType = GetVbType(c.mysqlType)
                                        c.phpType = GetPHPType(c.mysqlType)
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

                            Dim endTime = Now
                            _r.executiontime = endTime.Subtract(startTime)
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
        Public Sub InitSchema()
            Try
                Databases = New List(Of String)
                DbConnections = New Dictionary(Of String, MySqlConnection)

                Tables = New List(Of table)
                Routines = New List(Of routine)

            Catch ex As Exception
                Throw
            End Try
        End Sub
        Public Function TryConnect() As Boolean
            Try
                GetDatabases()

                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function

        Private Function DbConnection(connectionName As String, databasename As String) As MySqlConnection
            Try
                If DbConnections Is Nothing Then
                    DbConnections = New Dictionary(Of String, MySqlConnection)
                End If
                Dim con As MySqlConnection

                If DbConnections.ContainsKey(connectionName) Then
                    con = DbConnections.First(Function(c) c.Key = connectionName).Value
                Else
                    con = New MySqlConnection(Connection.ToString)

                    DbConnections.Add(connectionName, con)
                End If

                If con.State = ConnectionState.Closed Or con.State = ConnectionState.Broken Then
                    Try
                        con.Open()
                    Catch msex As Exception
                        Connection.sslmode = eSslMode.None
                        con.ConnectionString = Connection.ToString
                        con.Open()
                    End Try
                    con.ChangeDatabase(databasename)
                End If
                Return con

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
        Private Function GetVbType(mysqlType As String) As String
            If mysqlType Is Nothing Then
                Return "Integer"
            End If
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

        Private Function GetPHPType(mysqlType As String) As String
            If mysqlType Is Nothing Then
                Return "int"
            End If
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
                While Tables.Exists(Function(t) t.name.ToLower = ali Or t.singleName.ToLower = ali Or t.pluralName.ToLower = ali)
                    ali = $"{original.ToLower}_{inc}"
                    inc += 1
                End While

                ' Then check if first char is a number
                If IsNumeric(ali.First) Then
                    ali = $"x{ali}"
                End If

                ' Then check keywords (depending on generatortype)
                If Keywords.Exists(Function(k) k = ali) Then
                    ali = $"[{ali}]"
                End If

                ' replace spaces with _
                Dim RegexObj As New Regex("[^a-z\d\-_]", RegexOptions.IgnoreCase Or RegexOptions.Multiline)

                ali = RegexObj.Replace(ali, "_")

                Return ali
            Catch ex As Exception
                Throw
            End Try
        End Function

        Private Function FixKeyword(inData As String) As String
            ' Then check keywords (depending on generatortype)
            If Keywords.Exists(Function(k) k = inData) Then
                Return $"[{inData}]"
            Else
                Return inData
            End If
        End Function

#End Region

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If DbConnections IsNot Nothing Then
                        DbConnections.Values.ToList.ForEach(Sub(c) c.Dispose())
                        DbConnections.Clear()
                    End If
                    If DbCommand IsNot Nothing Then DbCommand.Dispose()
                    If Pservice IsNot Nothing Then Pservice.Dispose()
                End If

                Keywords = Nothing
                Databases = Nothing
                Tables = Nothing
                Routines = Nothing

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

        Public Function IsSingle(s As Object) As Boolean
            Return isSingle(s.ToString)
        End Function

        Public Function isSingle(s As String) As Boolean
            Dim tmp As String = Singularize(s)

            Return tmp.Equals(s)
        End Function

        Public Function IsPlural(s As Object) As Boolean
            Return IsPlural(s.ToString)
        End Function

        Public Function IsPlural(s As String) As Boolean
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
