using System.Xml.Serialization;

namespace TypeKitExporter.Models;

public class Font
{
    [XmlElement(ElementName = "url")]
    public string Url { get; set; } = string.Empty;

    [XmlElement(ElementName = "id")]
    public int Id { get; set; }

    [XmlElement(ElementName = "properties")]
    public FontProperties Properties { get; set; } = new();
}
