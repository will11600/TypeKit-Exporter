using Spectre.Console.Cli;
using System.ComponentModel;

namespace TypeKitExporter;

internal abstract class ExportCommandSettings : CommandSettings
{
    [Description("The output directory")]
    [CommandOption("-o|--output")]
    public string OutputPath { get; init; } = string.Empty;
}
