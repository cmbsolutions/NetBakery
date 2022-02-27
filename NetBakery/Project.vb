''' <summary>
''' These classes and properties represent a complete project that can be saved and loaded.
''' It will detect any changes made outside of NetBakery 
''' </summary>
Public Class Project
    Property application_version As String
    Property save_date As Date
    Property projectname As String
    Property projectlocation As String
    Property projectoutputlocation As String
    Property outputtype As String
    Property useEnums As Boolean
    Property generateProcedureLocks As Boolean

    Property needsSave As Boolean
    Property projectfilename As String

    Property database As databaseObjects

    Property generatedoutputs As List(Of FileVCS.Models.vcsObject)
End Class

Public Class databaseObjects
    Property connection As infoSchema.connection
    Property databasename As String
    Property tables As List(Of infoSchema.table)
    Property routines As List(Of infoSchema.routine)
End Class