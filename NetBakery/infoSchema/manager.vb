Imports System.Data.Entity.Infrastructure.Pluralization
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions


Namespace infoSchema
    <Serializable>
    Public Class manager
        Implements IDisposable

        Public Property connection As connection
        Private Property _dbConnection As MySqlConnection
        Private Property _dbCommand As MySqlCommand
        Private Property _p As New PluralizationService
        Private Property _keywords As New List(Of String)
        Public Property database As String = ""
        Public Property databases As List(Of String)
        Public Property tables As List(Of table)
        Public Property routines As List(Of routine)
        Public Property useEnums As Boolean
        Private Property useGenerator As String = "net5"

        Private _generator As iGenerator = New net5Generator

        Public Sub setGenerator(_v As String)
            useGenerator = _v

            Select Case useGenerator
                Case "net"
                    _generator = New legacy_netGenerator
                Case "net5"
                    _generator = New net5Generator
                Case "php"
                    _generator = New phpGenerator
                Case Else

            End Select
        End Sub

        Public Function generateModel(t As table) As String
            Try
                Return _generator.generateModel(t)
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
                Return _generator.generateContext(tables, name, False)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function generateStoreCommands(name As String) As String
            Try
                Return _generator.generateStoreCommands(routines.Where(Function(c) c.isFunction And c.hasExport).ToList, routines.Where(Function(c) Not c.isFunction And c.hasExport).ToList, name)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function generateStoreCommand(r As infoSchema.routine) As String
            Try
                Return _generator.generateStoreCommand(r)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Sub New()
            initSchema()
        End Sub

        Public Sub harvestObjects()
            Try
                tables = New List(Of table)
                routines = New List(Of routine)

                getTables()
                getColumns()
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

                    _dbCommand.Connection = dbConnection()
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

                    _dbCommand.Connection = dbConnection()
                    _dbCommand.CommandText = "SELECT TABLE_NAME, TABLE_TYPE FROM TABLES WHERE TABLE_SCHEMA=@database"
                    _dbCommand.Parameters.AddWithValue("database", database)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            If rdr("TABLE_TYPE").ToString = "VIEW" Then
                                tables.Add(New table With {.name = rdr("TABLE_NAME").ToString, .singleName = _p.Singularize(rdr("TABLE_NAME").ToString), .pluralName = _p.Pluralize(rdr("TABLE_NAME").ToString), .isView = True, .hasExport = True})
                            Else
                                tables.Add(New table With {.name = rdr("TABLE_NAME").ToString, .singleName = _p.Singularize(rdr("TABLE_NAME").ToString), .pluralName = _p.Pluralize(rdr("TABLE_NAME").ToString), .hasExport = True})
                            End If
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
                        _dbCommand.Connection = dbConnection()
                        _dbCommand.CommandText = "SELECT COLUMN_NAME,ORDINAL_POSITION,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE,COLUMN_TYPE,COLUMN_KEY,EXTRA FROM COLUMNS WHERE TABLE_SCHEMA = @database AND TABLE_NAME = @table ORDER BY ORDINAL_POSITION ASC"
                        _dbCommand.Parameters.AddWithValue("database", database)
                        _dbCommand.Parameters.AddWithValue("table", t.name)
                        'Debug.WriteLine(t.tableName)
                        Using rdr As MySqlDataReader = _dbCommand.ExecuteReader()
                            While rdr.Read
                                Dim c As New column
                                'Debug.WriteLine(rdr("COLUMN_NAME").ToString)
                                c.name = rdr("COLUMN_NAME").ToString
                                c.alias = AliasGenerator(rdr("COLUMN_NAME").ToString)
                                c.ordinalPosition = CInt(rdr("ORDINAL_POSITION"))
                                c.defaultValue = rdr("COLUMN_DEFAULT").ToString
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

        Private Sub getForeignKeys()
            Try
                Using _dbCommand = New MySqlCommand
                    _dbCommand.Connection = dbConnection()
                    _dbCommand.CommandText = "SELECT CONSTRAINT_NAME, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, POSITION_IN_UNIQUE_CONSTRAINT, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME FROM KEY_COLUMN_USAGE WHERE CONSTRAINT_SCHEMA = @database AND REFERENCED_TABLE_NAME is not null ORDER BY TABLE_NAME, ORDINAL_POSITION, POSITION_IN_UNIQUE_CONSTRAINT"
                    _dbCommand.Parameters.AddWithValue("database", database)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        While rdr.Read
                            Dim f As New foreignKey
                            f.name = rdr("CONSTRAINT_NAME").ToString

                            Dim t As table = (From t1 In tables Where t1.name = rdr("TABLE_NAME").ToString Select t1).FirstOrDefault
                            If t IsNot Nothing Then f.table = t

                            Dim c As column = (From c1 In t.columns Where c1.name = rdr("COLUMN_NAME").ToString Select c1).FirstOrDefault
                            If c IsNot Nothing Then f.column = c

                            f.ordinalPosition = ToInt(rdr("ORDINAL_POSITION"))
                            f.positionInUniqueConstraint = ToInt(rdr("POSITION_IN_UNIQUE_CONSTRAINT"))

                            Dim rt As table = (From t1 In tables Where t1.name = rdr("REFERENCED_TABLE_NAME").ToString Select t1).FirstOrDefault
                            If rt IsNot Nothing Then f.referencedTable = rt

                            Dim rc As column = (From c1 In rt.columns Where c1.name = rdr("REFERENCED_COLUMN_NAME").ToString Select c1).FirstOrDefault
                            If rc IsNot Nothing Then f.referencedColumn = rc

                            If t.foreignKeys.Where(Function(d) d.table.name = f.table.name AndAlso d.referencedTable.name = f.referencedTable.name).Count > 0 Then
                                f.propertyAlias = String.Format("{0}1", f.table.name)
                            Else
                                f.propertyAlias = f.table.name
                            End If

                            t.foreignKeys.Add(f)

                            t.relations.Add(New relation With {.toTable = rt, .toColumn = rc, .localColumn = c, .isOptional = c.isNullable, .alias = AliasGenerator(f.table.name)})

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
                    _dbCommand.CommandText = "SELECT r.ROUTINE_TYPE, r.ROUTINE_NAME, r.ROUTINE_DEFINITION, p.ORDINAL_POSITION, p.PARAMETER_NAME, p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION FROM ROUTINES AS r LEFT JOIN PARAMETERS AS p ON r.ROUTINE_SCHEMA = p.SPECIFIC_SCHEMA AND r.ROUTINE_NAME = p.SPECIFIC_NAME WHERE r.ROUTINE_SCHEMA = @database ORDER BY r.ROUTINE_TYPE, p.SPECIFIC_NAME, p.ORDINAL_POSITION"
                    _dbCommand.Parameters.AddWithValue("database", database)

                    Using rdr As MySqlDataReader = _dbCommand.ExecuteReader
                        Dim rt As routine = Nothing

                        While rdr.Read
                            If rt Is Nothing OrElse rt.name <> rdr("ROUTINE_NAME").ToString Then
                                If rt IsNot Nothing Then
                                    If rt.returnsRecordset Then
                                        getRoutineLayout(rt)
                                    End If
                                    routines.Add(rt)
                                End If
                                rt = New routine With {.name = rdr("ROUTINE_NAME").ToString, .hasExport = True, .definition = rdr("ROUTINE_DEFINITION").ToString}

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

                                If ToInt(rdr("ORDINAL_POSITION")) = 0 Then
                                    rt.returnParam = p
                                End If
                            End If

                            If ToInt(rdr("ORDINAL_POSITION")) > 0 Then
                                rt.params.Add(p)
                            End If
                        End While

                        If rt IsNot Nothing Then
                            If rt.returnsRecordset Then
                                getRoutineLayout(rt)
                            End If
                            routines.Add(rt)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub getRoutineLayout(ByRef _r As routine)
            Try
                Using localConnection As New MySqlConnection(_dbConnection.ConnectionString)
                    localConnection.Open()

                    Using _dbxCommand = New MySqlCommand
                        _dbxCommand.Connection = localConnection
                        localConnection.ChangeDatabase(database)

                        _dbxCommand.CommandType = CommandType.Text
                        _dbxCommand.CommandText = $"CALL {_r.name}({String.Join(",", (From r In _r.params Order By r.ordinalPosition Select "@" & r.name))})"

                        For Each param In _r.params.OrderBy(Function(o) o.ordinalPosition)
                            _dbxCommand.Parameters.AddWithValue("@" & param.name, 1)
                        Next

                        Try
                            Using rdr As MySqlDataReader = _dbxCommand.ExecuteReader()

                                Using d As DataTable = rdr.GetSchemaTable
                                    If d IsNot Nothing Then
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
                tables = New List(Of table)
                routines = New List(Of routine)


                _keywords = New List(Of String)
                _keywords.AddRange(My.Settings.keywords.Split(" "c))

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

        Private Function dbConnection() As MySqlConnection
            Try
                If _dbConnection Is Nothing OrElse _dbConnection.State = ConnectionState.Closed Then
                    Try
                        _dbConnection = New MySqlConnection(connection.ToString)
                        _dbConnection.Open()
                    Catch msex As MySqlException
                        connection.sslmode = eSslMode.Prefered
                        _dbConnection = New MySqlConnection(connection.ToString)
                        _dbConnection.Open()
                    End Try
                Else
                    If _dbConnection.ConnectionString <> connection.ToString Then
                        _dbConnection.Close()
                        Try
                            _dbConnection = New MySqlConnection(connection.ToString)
                            _dbConnection.Open()
                        Catch msex As MySqlException
                            connection.sslmode = eSslMode.Prefered
                            _dbConnection = New MySqlConnection(connection.ToString)
                            _dbConnection.Open()
                        End Try
                    End If
                End If

                _dbConnection.ChangeDatabase("INFORMATION_SCHEMA")

                Return _dbConnection
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

        Private Function getVbType(mysqlType As String) As Type
            Select Case mysqlType.ToLower
                Case "tinyint", "mediumint", "integer", "int", "smallint", "int16", "int24", "int32", "uint16", "uint24", "uint32"
                    Return GetType(Integer)
                Case "bigint", "int64", "uint64"
                    Return GetType(Long)
                Case "char", "varchar", "text", "tinytext", "mediumtext", "longtext", "string", "varstring", "varbinary", "binary", "tinyblob", "mediumblob", "longblob", "set", "enum"
                    Return GetType(String)
                Case "time", "timestamp"
                    Return GetType(TimeSpan)
                Case "date", "datetime"
                    Return GetType(Date)
                Case "double", "float"
                    Return GetType(Double)
                Case "decimal", "numeric", "newdecimal"
                    Return GetType(Decimal)
                Case "byte", "bit"
                    Return GetType(Boolean)
                Case Else
                    Return GetType(Object)
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
                    Return "Unknown"
            End Select
        End Function
        Private Function AliasGenerator(original As String) As String
            Try
                Dim [alias] As String = original
                Dim inc As Integer = 1

                ' First check tablenames
                While tables.Exists(Function(t) t.name = [alias] Or t.singleName = [alias] Or t.pluralName = [alias])
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
#End Region

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If _dbConnection IsNot Nothing Then _dbConnection.Dispose()
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
            _service = New EnglishPluralizationService()
        End Sub

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
        Public Function Pluralize(s As String) As String
            Dim ret As String = _service.Pluralize(s)
            Dim test As String = Singularize(s)

            If s = ret AndAlso s = test AndAlso test = ret Then ret &= "s"

            Return ret
        End Function
        Public Function isSingle(s As String) As Boolean
            Dim tmp As String = Singularize(s)

            Return tmp.Equals(s)
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
