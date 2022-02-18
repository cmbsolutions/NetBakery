Imports Ardalis.SmartEnum

Namespace Models
    Public Class Explorer
        Property files As List(Of File)


    End Class

    Public Class File
        Property filename As String
        Property location As String
        Property treepath As String
        Property fileType As FileTypeEnum
        Property known_hash As String
        Property actual_hash As String
        Property new_hash As String

        ''' <summary>
        ''' normal +0
        ''' add +1
        ''' check +2
        ''' error +3
        ''' remove + 4
        ''' </summary>
        ''' <returns></returns>
        Public Function GetIconIndex() As Integer
            ' New file
            If known_hash = "" And actual_hash = "" And new_hash <> "" Then Return fileType.Value + 1
            Return fileType.Value
        End Function
    End Class

    Public NotInheritable Class FileTypeEnum
        Inherits SmartEnum(Of FileTypeEnum)

        Public Shared ReadOnly Folder As New FileTypeEnum(NameOf(Folder), 10)
        Public Shared ReadOnly Model As New FileTypeEnum(NameOf(Model), 5)
        Public Shared ReadOnly Map As New FileTypeEnum(NameOf(Map), 5)
        Public Shared ReadOnly Func As New FileTypeEnum(NameOf(Func), 25)
        Public Shared ReadOnly Proc As New FileTypeEnum(NameOf(Proc), 20)
        Public Shared ReadOnly Context As New FileTypeEnum(NameOf(Context), 0)
        Public Shared ReadOnly StoreComms As New FileTypeEnum(NameOf(StoreComms), 20)

        Private Sub New(ByVal name As String, ByVal value As Integer)
            MyBase.New(name, value)
        End Sub
    End Class
End Namespace