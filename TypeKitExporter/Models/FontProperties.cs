using System.Xml.Serialization;

namespace TypeKitExporter.Models;

public struct FontProperties
{
    [XmlElement(ElementName = "fullName")]
    public string FullName { get; set; }
    [XmlElement(ElementName = "familyName")]
    public string FamilyName { get; set; }
    [XmlElement(ElementName = "variationName")]
    public string VariationName { get; set; }
    [XmlElement(ElementName = "familyURL")]
    public string FamilyUrl { get; set; }
    [XmlElement(ElementName = "sortOrder")]
    public int SortOrder { get; set; }
    [XmlElement(ElementName = "owner")]
    public string Owner { get; set; }
    [XmlElement(ElementName = "installState")]
    public string InstallState { get; set; }
    [XmlElement(ElementName = "installStateUpdatedAt")]
    public DateTime InstallStateUpdatedAt { get; set; }
    [XmlElement(ElementName = "syncFontId")]
    public string SyncFontId { get; set; }
    [XmlElement(ElementName = "familyWebId")]
    public string FamilyWebId { get; set; }
    [XmlElement(ElementName = "fvd")]
    public string Fvd { get; set; }
    [XmlElement(ElementName = "isVariable")]
    public bool IsVariable { get; set; }
    [XmlElement(ElementName = "expiredAt")]
    public DateTime? ExpiredAt { get; set; }
}
