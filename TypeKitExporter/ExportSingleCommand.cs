using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeKitExporter.Infrastructure;
using TypeKitExporter.Models;

namespace TypeKitExporter;

internal sealed class ExportSingleCommand(EntitlementsReader reader, FontConverter converter) : Command<ExportSingleCommand.Settings>
{
    public sealed class Settings : ExportCommandSettings
    {
        [Description("The font name to export")]
        [CommandArgument(0, "[fontName]")]
        public string FontName { get; init; } = string.Empty;
    }

    private readonly EntitlementsReader _reader = reader;
    private readonly FontConverter _converter = converter;

    public override int Execute([NotNull] CommandContext context, Settings settings)
    {
        Font font = _reader.GetFont(settings.FontName);

        string outputPath = string.IsNullOrEmpty(settings.OutputPath) ? $"{font.Properties.FullName}.ttf" : settings.OutputPath;
        _converter.Save(font.Id, outputPath);

        AnsiConsole.MarkupLine($"Exported 1 font(s) to [link=file://{outputPath}]{outputPath}[/]");

        return 0;
    }
}
