Imports NetBakery.infoSchema

Public Interface iGenerator
    Function generateModel(_t As infoSchema.table) As String
    Function generateMap(_t As infoSchema.table) As String
    Function generateContext(_t As List(Of infoSchema.table), name As String, recovery As Boolean) As String
    Function generateStoreCommands(_f As List(Of infoSchema.routine), _p As List(Of infoSchema.routine), name As String, withLock As Boolean) As String
    Function generateStoreCommandSchema(_r As infoSchema.routine) As String
    Function generateStoreCommand(_r As infoSchema.routine, contextName As String, withLock As Boolean) As String
End Interface
