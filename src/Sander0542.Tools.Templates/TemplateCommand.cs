using McMaster.Extensions.CommandLineUtils;
using Sander0542.Tools.Common;
using Sander0542.Tools.Templates.Dotnet;

namespace Sander0542.Tools.Templates
{
    [Command(Description = "Create templates for your projects")]
    [Subcommand(
        typeof(DotnetCommand)
    )]
    public class TemplateCommand : CommandBase
    {
    }
}
