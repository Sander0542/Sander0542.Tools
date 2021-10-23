using System.Reflection;
using McMaster.Extensions.CommandLineUtils;
using Sander0542.Tools.Common;
using Sander0542.Tools.Templates;

namespace Sander0542.Tools.Cli
{
    [Command("sander0542")]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(
        typeof(TemplateCommand)
    )]
    public class MainCommand : CommandBase
    {
        private static string GetVersion() => typeof(MainCommand).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
    }
}
