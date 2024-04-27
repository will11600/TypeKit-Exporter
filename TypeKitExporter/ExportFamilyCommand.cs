using Spectre.Console;
using Spectre.Console.Cli;
using TypeKitExporter.Infrastructure;

namespace TypeKitExporter
{
    internal sealed class ExportFamilyCommand(EntitlementsReader entitlementsReader, FontConverter fontConverter) : Command<ExportFamilyCommand.Settings>
    {
        public sealed class Settings : ExportCommandSettings
        {
            [CommandArgument(0, "[familyName]")]
            public string FamilyName { get; set; } = string.Empty;
        }

        private readonly EntitlementsReader _reader = entitlementsReader;
        private readonly FontConverter _converter = fontConverter;

        public override int Execute(CommandContext context, Settings settings)
        {
            var fonts = _reader.GetFamily(settings.FamilyName);

            string outputPath = string.IsNullOrEmpty(settings.OutputPath) ? settings.FamilyName : settings.OutputPath;

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            foreach (var font in fonts)
            {
                _converter.Save(font.Id, Path.Combine(outputPath, $"{font.Properties.FullName}.ttf"));
            }

            AnsiConsole.MarkupLine($"Exported {fonts.Count()} font(s) to [link=file://{outputPath}]{outputPath}[/]");

            return 0;
        }
    }
}
