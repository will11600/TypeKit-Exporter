using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using TypeKitExporter.Infrastructure;

namespace TypeKitExporter
{
    public class Program
    {
        [RequiresUnreferencedCode("Calls System.Xml.Serialization.XmlSerializer.Deserialize(TextReader)")]
        public static int Main(string[] args)
        {
            var registrations = new ServiceCollection();
            registrations.AddSingleton<EntitlementsReader>();
            registrations.AddSingleton<FontConverter>();
            var registrar = new TypeRegistrar(registrations);

            var app = new CommandApp(registrar);
            app.Configure(config =>
            {
#if DEBUG
                config.PropagateExceptions();
                config.ValidateExamples();
#endif
                config.AddBranch("export", b =>
                {
                    b.SetDescription("Export fonts from Adobe Typekit");
                    b.AddCommand<ExportSingleCommand>("single")
                        .WithDescription("Export a single font")
                        .WithExample(["export", "single", "Myriad Pro"]);
                    b.AddCommand<ExportFamilyCommand>("family")
                        .WithDescription("Export a family of fonts")
                        .WithExample(["export", "family", "Myriad Pro"]);
                });
            });

            return app.Run(args);
        }
    }
}