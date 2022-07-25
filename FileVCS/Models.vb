Namespace Models
    Public Class GroupedFiles
        Property Parent As String
        Property Files As List(Of vcsObject)
    End Class

    Public Class vcsObject
        Property filename As String
        Property location As String
        Property objecttype As String
        Property hash As String
    End Class

    <SerializableAttribute(),
         ComponentModel.DesignerCategoryAttribute("code"),
         Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
         Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class AdvTree
        Property Node As AdvTreeNode
    End Class

    Partial Public Class AdvTreeNode

        <Xml.Serialization.XmlElementAttribute("Node")>
        Property Node As New List(Of AdvTreeNode)

        <Xml.Serialization.XmlIgnore()>
        Property ParentNode As AdvTreeNode

        <Xml.Serialization.XmlAttributeAttribute()>
        Property Expanded As Boolean

        <Xml.Serialization.XmlAttributeAttribute()>
        Property Name As String

        <Xml.Serialization.XmlAttributeAttribute()>
        Property DragDropEnabled As Boolean = False

        <Xml.Serialization.XmlAttributeAttribute("Text")>
        Property Text As String

        <Xml.Serialization.XmlAttributeAttribute()>
        Property ImageIndex As Integer = 10

        <Xml.Serialization.XmlAttributeAttribute()>
        Property ImageExpandedIndex As Integer = 15
    End Class

    ''' <summary>
    ''' Add 0 to get `original`
    ''' Add 1 to get `add`
    ''' Add 2 to get `check`
    ''' Add 3 to get `error`
    ''' Add 4 to get `remove`
    ''' The above only works below 30
    ''' </summary>
    Public Enum ExplorerImage
        APPLICATION = 0
        DOCUMENT = 5
        FOLDER = 10
        FOLDEROPEN = 15
        NOTEPAD = 20
        BOOKOPEN = 25
        DATABASE = 30
        DOCUMENTSCRIPT = 31
        QUERY = 32
        SCRIPT = 33
        TABLE = 34
        DATASHEET = 35
    End Enum
End Namespace

