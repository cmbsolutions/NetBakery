Imports System.Data.Entity.Infrastructure.Pluralization

Namespace My.Templates.net5
    Partial Public Class Model
        Private _t As infoSchema.table
        Private _i As Integer
        Private p As New PluralizationService

        Public Sub New(ByVal t As infoSchema.table)
            _t = t
        End Sub
    End Class

    Partial Public Class Map
        Private _t As infoSchema.table
        Private _i As Integer
        Private p As New PluralizationService

        Public Sub New(ByVal t As infoSchema.table)
            _t = t
        End Sub
    End Class

    Partial Public Class Context
        Private _tables As List(Of infoSchema.table)
        Private _name As String
        Private _recovery As Boolean
        Private p As New PluralizationService

        Public Sub New(ByVal tables As List(Of infoSchema.table), ByVal name As String, ByVal recovery As Boolean)
            _tables = tables
            _name = name
            _recovery = recovery
        End Sub
    End Class

    Partial Public Class StoreCommands
        Private _functions As List(Of infoSchema.routine)
        Private _procedures As List(Of infoSchema.routine)
        Private _name As String
        Private _withLock As Boolean

        Public Sub New(ByVal functions As List(Of infoSchema.routine), ByVal procedures As List(Of infoSchema.routine), ByVal name As String, withLock As Boolean)
            _functions = functions
            _procedures = procedures
            _name = name
            _withLock = withLock
        End Sub
    End Class

    Partial Public Class StoreCommandModel
        Private _procedure As infoSchema.routine

        Public Sub New(ByVal procedure As infoSchema.routine)
            _procedure = procedure
        End Sub
    End Class

    Partial Public Class StoreCommand
        Private _routine As infoSchema.routine
        Private _ContextName As String
        Private _withLock As Boolean

        Sub New(_r As infoSchema.routine, contextName As String, withLock As Boolean)
            _routine = _r
            _ContextName = contextName
            _withLock = withLock
        End Sub
    End Class


End Namespace
