using System.Xml.Serialization;

namespace TypeKitExporter.Models;

[XmlRoot(ElementName = "typekitSyncState")]
public class TypekitSyncState
{
    [XmlElement(ElementName = "state")]
    public string State { get; set; } = string.Empty;

    [XmlArray("fonts")]
    [XmlArrayItem("font")]
    public List<Font> Fonts { get; set; } = [];
}
