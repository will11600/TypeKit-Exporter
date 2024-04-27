using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using TypeKitExporter.Models;

namespace TypeKitExporter.Infrastructure;

[RequiresUnreferencedCode("Calls System.Xml.Serialization.XmlSerializer.Deserialize(TextReader)")]
internal sealed class EntitlementsReader
{
    private const string ENTITLEMENTS_PATH = @"%APPDATA%\Adobe\CoreSync\plugins\livetype\c\entitlements.xml";

    private readonly string _xmlData;
    private readonly XmlSerializer _serializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntitlementsReader"/> class.
    /// </summary>
    /// <param name="path">The path to the entitlements file.</param>
    public EntitlementsReader(string path = ENTITLEMENTS_PATH)
    {
        string expandedPath = Environment.ExpandEnvironmentVariables(path);
        _xmlData = File.ReadAllText(expandedPath);
        _serializer = new(typeof(TypekitSyncState));
    }

    /// <summary>
    /// Gets the fonts from the entitlements file.
    /// </summary>
    /// <returns>An enumerable of fonts.</returns>
    public IEnumerable<Font> GetFonts()
    {
        using TextReader reader = new StringReader(_xmlData);
        var result = (TypekitSyncState)_serializer.Deserialize(reader)!;
        return result.Fonts;
    }

    /// <summary>
    /// Gets a font by its name.
    /// </summary>
    /// <param name="fontName">The name of the font.</param>
    /// <returns>A font.</returns>
    public Font GetFont(string fontName)
    {
        return GetFonts().FirstOrDefault(f => f.Properties.FullName == fontName);
    }

    /// <summary>
    /// Gets a font by its ID.
    /// </summary>
    /// <param name="id">The ID of the font.</param>
    /// <returns>A font.</returns>
    public Font GetFont(int id)
    {
        return GetFonts().FirstOrDefault(f => f.Id == id);
    }

    /// <summary>
    /// Gets all fonts from a family.
    /// </summary>
    /// <param name="familyName">The name of the family.</param>
    /// <returns>An enumerable of fonts.</returns>
    public IEnumerable<Font> GetFamily(string familyName)
    {
        return GetFonts().Where(f => f.Properties.FamilyName == familyName);
    }
}
