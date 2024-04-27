using Spectre.Console;
using Spectre.Console.Cli;
using TypeKitExporter.Infrastructure;

namespace TypeKitExporter;

internal sealed class ListFontsCommand(EntitlementsReader reader) : Command
{
    private readonly EntitlementsReader _reader = reader;

    public override int Execute(CommandContext context)
    {
        var root = new Tree("[bold yellow]Fonts[/]");

        var fonts = _reader.GetFonts().GroupBy(f => f.Properties.FamilyName);
        foreach ( var font in fonts)
        {
            var family = root.AddNode($"[bold yellow]{font.Key}[/]");
            foreach (var f in font)
            {
                family.AddNode(f.Properties.FullName);
            }
        }

        AnsiConsole.Write(root);

        return 0;
    }
}
