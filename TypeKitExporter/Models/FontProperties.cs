using System.Xml.Serialization;

namespace TypeKitExporter.Models;

public class FontProperties
{
    [XmlElement(ElementName = "fullName")]
    public string FullName { get; set; } = string.Empty;

    [XmlElement(ElementName = "familyName")]
    public string FamilyName { get; set; } = string.Empty;

    //[XmlElement(ElementName = "variationName")]
    //public string VariationName { get; set; } = string.Empty;

    //[XmlElement(ElementName = "familyURL")]
    //public string FamilyUrl { get; set; } = string.Empty;

    //[XmlElement(ElementName = "sortOrder")]
    //public int SortOrder { get; set; }

    //[XmlElement(ElementName = "owner")]
    //public string Owner { get; set; } = string.Empty;

    //[XmlElement(ElementName = "installState")]
    //public string InstallState { get; set; } = string.Empty;

    //[XmlElement(ElementName = "installStateUpdatedAt")]
    //public DateTime InstallStateUpdatedAt { get; set; }

    //[XmlElement(ElementName = "syncFontId")]
    //public string SyncFontId { get; set; } = string.Empty;

    //[XmlElement(ElementName = "familyWebId")]
    //public string FamilyWebId { get; set; } = string.Empty;

    //[XmlElement(ElementName = "fvd")]
    //public string Fvd { get; set; } = string.Empty;

    //[XmlElement(ElementName = "isVariable")]
    //public bool IsVariable { get; set; }

    //[XmlElement(ElementName = "expiredAt")]
    //public DateTime? ExpiredAt { get; set; }
}
