Namespace Models
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
        Property TextField As String

        <Xml.Serialization.XmlAttributeAttribute()>
        Property ImageIndex As Integer = 18

        <Xml.Serialization.XmlAttributeAttribute()>
        Property ImageExpandedIndex As Integer = 23
    End Class
End Namespace




