using System.Xml.Serialization;

namespace TypeKitExporter.Models;

public struct Font
{
    [XmlElement(ElementName = "url")]
    public string Url { get; set; }
    [XmlElement(ElementName = "id")]
    public int Id { get; set; }
    [XmlElement(ElementName = "properties")]
    public FontProperties Properties { get; set; }
}
