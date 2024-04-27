using System.Xml.Serialization;

namespace TypeKitExporter.Models;

public struct TypekitSyncState
{
    [XmlElement(ElementName = "state")]
    public string State { get; set; }

    [XmlArray("fonts")]
    [XmlArrayItem("font")]
    public List<Font> Fonts { get; set; }
}
