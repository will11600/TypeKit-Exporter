using System.Diagnostics;

namespace TypeKitExporter.Infrastructure;

internal sealed class FontConverter(string fontsPath = FontConverter.FONTS_DIRECTORY)
{
    private const string FONTS_DIRECTORY = @"%APPDATA%\Adobe\CoreSync\plugins\livetype\r";

    private readonly string _fontsPath = Environment.ExpandEnvironmentVariables(fontsPath);

    public void Save(int fontId, string outputPath)
    {
        Debug.Assert(outputPath.EndsWith(".ttf"), "Output path must be a .ttf file");
        File.Copy(GetFontPath(fontId), outputPath);
        File.SetAttributes(outputPath, FileAttributes.Normal);
    }

    private string GetFontPath(int fontId) => Path.Combine(_fontsPath, fontId.ToString());
}
