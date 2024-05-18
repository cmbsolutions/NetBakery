Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports Newtonsoft.Json
Imports Org.BouncyCastle.Pqc.Crypto
''' <summary>
''' These classes and properties represent a complete project that can be saved and loaded.
''' It will detect any changes made outside of NetBakery 
''' </summary>
Public Class Project
    Property Application_version As String
    Property Save_date As Date
    Property Projectname As String
    Property Projectlocation As String
    Property Projectoutputlocation As String
    Property Outputtype As String
    Property UseEnums As Boolean
    Property GenerateProcedureLocks As Boolean
    Property DiscoverProcedureLayouts As Integer
    Property ShareLayouts As Boolean

    Property NeedsSave As Boolean
    Property Projectfilename As String

    Property Database As DatabaseObjects

    Property Generatedoutputs As List(Of FileVCS.Models.vcsObject)

    Public Sub Save()
        Try
            If Projectlocation = "" Or Projectname = "" Then
                Trace.WriteLine("No active project to save!")
                Exit Sub
            End If

            If Projectfilename = "" Then
                Projectfilename = IO.Path.Combine(Projectlocation, $"{Projectname}.nb2")
            End If

            'Create backup file
            If IO.File.Exists(Projectfilename) Then
                Dim backupFile As String = Projectfilename.Replace(".nb2", $"_backup.nbz")

                Using fs As New IO.FileStream(backupFile, IO.FileMode.OpenOrCreate)
                    Using z As New ZipArchive(fs, ZipArchiveMode.Create, False)
                        z.CreateEntryFromFile(Projectfilename, $"{Now:yyyyMMdd_HHmmss}")
                    End Using
                End Using
            End If

            Using compressedStream As New IO.FileStream(Projectfilename, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Me, Formatting.Indented, New JsonSerializerSettings With {
                                                                                                    .ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                                                                                    .PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                                                                                    .MaxDepth = 128}))

                Using zipStream As New GZipStream(compressedStream, CompressionLevel.Optimal)
                    zipStream.Write(buffer, 0, buffer.Length)
                End Using
            End Using
            NeedsSave = False

            Trace.WriteLine("Project saved!")

        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try
    End Sub

    Public Shared Function Load(f As String) As Project
        Try
            Dim decompressedString As String = ""

            Using fs As New IO.FileStream(f, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
                If fs.ReadByte = 31 Then ' It's a zip file
                    fs.Position = 0

                    Using zipStream As New GZipStream(fs, CompressionMode.Decompress)
                        ' Create a memory stream to hold the decompressed data
                        Using decompressedStream As New MemoryStream()
                            ' Copy the decompressed data from the GZipStream to the memory stream
                            zipStream.CopyTo(decompressedStream)

                            ' Convert the decompressed data to a string
                            decompressedString = Encoding.UTF8.GetString(decompressedStream.ToArray())
                        End Using
                    End Using
                Else
                    fs.Position = 0

                    Using sr As New IO.StreamReader(fs, Encoding.UTF8)
                        decompressedString = sr.ReadToEnd
                    End Using
                End If
            End Using

            Return CType(JsonConvert.DeserializeObject(decompressedString, GetType(Project), New JsonSerializerSettings With {
                                                                                                    .ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                                                                                    .PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                                                                                    .MaxDepth = 128}), Project)
        Catch ex As Exception
            FormHelpers.dumpException(ex)
        End Try

        Return New Project
    End Function
End Class

Public Class DatabaseObjects
    Property Connection As infoSchema.connection
    Property Databasename As String
    Property Tables As List(Of infoSchema.table)
    Property Routines As List(Of infoSchema.routine)
End Class